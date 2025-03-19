Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports Emgu.CV.Util
Imports System.Drawing
Imports System.Drawing.Imaging
Imports Mysqlx.Notice
Imports System.IO
Imports Emgu.CV
Imports Emgu.CV.Structure
Imports Emgu.CV.CvEnum

Public Class UserMain
    Inherits Form

    Private Shared ReadOnly connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private selectedUserID As String = String.Empty
    Private Shared ReadOnly Roles As String() = {"Cashier", "Staff"}
    Private Shared ReadOnly Genders As String() = {"Male", "Female"}



    ' Load Event
    Private Sub UserMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()

        ' Set Password Mask
        txtPassword.PasswordChar = "*"c
        txtConfirmPassword.PasswordChar = "*"c

        ' Ensure webcam is OFF at start
        picWebcam.Image = Nothing ' Clear PictureBox
        capture = Nothing ' Do not initialize yet
        Timer1.Enabled = False ' Stop timer initially
        For Each col As DataGridViewColumn In dgvUsers.Columns
            Debug.Print(col.Name) ' Ito ay maglalabas ng column names sa Immediate Window
        Next
        CustomizeDataGridView()

    End Sub


    ' Load Users into DataGridView
    Private Sub LoadUsers()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Query to get user data
                Dim query As String = "SELECT user_id, username, first_name, middle_initial, last_name, email, age, gender, role, address FROM users WHERE role != 'Admin'"
                Dim adapter As New MySqlDataAdapter(query, connection)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                ' Check if the DataTable has data before binding it to the DataGridView
                If dt.Rows.Count > 0 Then
                    dgvUsers.DataSource = dt
                Else
                    MessageBox.Show("No data available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                ' Ensure that the user_id column is hidden (if needed)
                If dgvUsers.Columns.Contains("user_id") Then
                    dgvUsers.Columns("user_id").Visible = False ' Hide 'user_id' column
                End If

                ' Optional: Resize columns to fit data
                dgvUsers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ' Add User
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ValidateInputs() Then Exit Sub

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query = "INSERT INTO users (username, first_name, middle_initial, last_name, full_name, email, password_hash, age, gender, address, role, profile_picture) " &
                                "VALUES (@username, @firstName, @middleInitial, @lastName, @fullName, @email, SHA2(@password, 256), @age, @gender, @address, @role, @profilePicture); " &
                                "SELECT LAST_INSERT_ID();"

                Using cmd As New MySqlCommand(query, connection)
                    ' 🟢 Add user details
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim)
                    cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim)
                    cmd.Parameters.AddWithValue("@middleInitial", txtMI.Text.Trim)
                    cmd.Parameters.AddWithValue("@lastName", txtLastName.Text.Trim)

                    ' 🔹 Auto-generate Full Name
                    Dim fullName = txtFirstName.Text.Trim & " " & txtMI.Text.Trim & " " & txtLastName.Text.Trim
                    cmd.Parameters.AddWithValue("@fullName", fullName.Trim) ' Remove extra spaces

                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim)
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim) ' Ensure password is securely handled
                    cmd.Parameters.AddWithValue("@age", txtAge.Text.Trim)
                    cmd.Parameters.AddWithValue("@gender", If(cmbGender.SelectedItem IsNot Nothing, cmbGender.SelectedItem.ToString.Trim, ""))
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim)
                    cmd.Parameters.AddWithValue("@role", If(cmbRole.SelectedItem IsNot Nothing, cmbRole.SelectedItem.ToString.Trim, ""))

                    ' ✅ Declare profilePicBytes before using it
                    Dim profilePicBytes As Byte() = Nothing

                    ' 🖼️ Convert Profile Picture to Byte() if available
                    If picWebcam.Image IsNot Nothing Then
                        ' Clone the image to avoid GDI+ errors
                        Dim clonedImage As Image = New Bitmap(picWebcam.Image)

                        Using ms As New MemoryStream
                            clonedImage.Save(ms, ImageFormat.Jpeg) ' Save as JPEG
                            profilePicBytes = ms.ToArray ' Convert to Byte()
                        End Using

                        clonedImage.Dispose() ' Release memory
                    End If

                    cmd.Parameters.AddWithValue("@profilePicture", If(profilePicBytes IsNot Nothing, profilePicBytes, DBNull.Value))

                    ' 🟢 Execute Query
                    Dim newUserId = Convert.ToInt32(cmd.ExecuteScalar)
                    MessageBox.Show("User added successfully! Assigned User ID: " & newUserId, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' 📝 Log the action
                    Dim role = If(cmbRole.SelectedItem IsNot Nothing, cmbRole.SelectedItem.ToString.Trim, "")
                    Logaudittrail(role, fullName, "User added successfully! Assigned User ID: " & newUserId)
                End Using
            End Using

            LoadUsers() ' Refresh user list
        Catch ex As Exception
            MessageBox.Show("Error adding user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        UserPanel.Visible = False
    End Sub

    ' Handle DataGridView cell click
    Private Sub dgvUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellClick
        If e.RowIndex < 0 Then Exit Sub ' Exit if header row is clicked

        Try
            Dim row As DataGridViewRow = dgvUsers.Rows(e.RowIndex)

            selectedUserID = If(IsDBNull(row.Cells("user_id").Value), "", row.Cells("user_id").Value.ToString())

            txtUsername.Text = If(IsDBNull(row.Cells("username").Value), "", row.Cells("username").Value.ToString())
            txtFirstName.Text = If(IsDBNull(row.Cells("first_name").Value), "", row.Cells("first_name").Value.ToString())
            txtMI.Text = If(IsDBNull(row.Cells("middle_initial").Value), "", row.Cells("middle_initial").Value.ToString())
            txtLastName.Text = If(IsDBNull(row.Cells("last_name").Value), "", row.Cells("last_name").Value.ToString())
            txtEmail.Text = If(IsDBNull(row.Cells("email").Value), "", row.Cells("email").Value.ToString())
            txtAge.Text = If(IsDBNull(row.Cells("age").Value), "", row.Cells("age").Value.ToString())
            cmbGender.SelectedItem = If(IsDBNull(row.Cells("gender").Value), Nothing, row.Cells("gender").Value.ToString())
            txtAddress.Text = If(IsDBNull(row.Cells("address").Value), "", row.Cells("address").Value.ToString())
            cmbRole.SelectedItem = If(IsDBNull(row.Cells("role").Value), Nothing, row.Cells("role").Value.ToString())

            ' ✅ ILOAD ANG IMAGE DIRECTLY MULA DATABASE
            LoadUserImage(selectedUserID)

        Catch ex As Exception
            MessageBox.Show("Error selecting user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        UserPanel.Visible = True
    End Sub






    ' Delete User
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles bntDelete.Click
        If String.IsNullOrEmpty(selectedUserID) Then
            MessageBox.Show("Please select a user to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query = "DELETE FROM users WHERE user_id = @user_id"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@user_id", selectedUserID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            ' Log the action with role and full name
            Dim role = If(cmbRole.SelectedItem IsNot Nothing, cmbRole.SelectedItem.ToString.Trim, "")
            Dim fullName = txtFirstName.Text & " " & txtLastName.Text
            Logaudittrail(role, fullName, "User deleted successfully! User ID: " & selectedUserID)
            LoadUsers()

        Catch ex As Exception
            ' Show error message if something went wrong
            MessageBox.Show("Error deleting user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' Update User
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' Ensure a user is selected before updating
        If String.IsNullOrEmpty(selectedUserID) Then
            MessageBox.Show("Please select a user to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Validate inputs before proceeding
        If Not ValidateInputs() Then Exit Sub

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Update query (excluding password)
                Dim query = "UPDATE users SET username = @username, first_name = @firstName, " &
                                          "middle_initial = @middleInitial, last_name = @lastName, email = @email, " &
                                          "age = @age, gender = @gender, address = @address, role = @role WHERE user_id = @userID"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text)
                    cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text)
                    cmd.Parameters.AddWithValue("@middleInitial", txtMI.Text)
                    cmd.Parameters.AddWithValue("@lastName", txtLastName.Text)
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text)
                    cmd.Parameters.AddWithValue("@age", txtAge.Text)
                    cmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem?.ToString)
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text)
                    cmd.Parameters.AddWithValue("@role", cmbRole.SelectedItem?.ToString)
                    cmd.Parameters.AddWithValue("@userID", selectedUserID)

                    Dim rowsAffected = cmd.ExecuteNonQuery

                    If rowsAffected > 0 Then
                        MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Log the action with role and full name
                        Dim role = If(cmbRole.SelectedItem IsNot Nothing, cmbRole.SelectedItem.ToString.Trim, "")
                        Dim fullName = txtFirstName.Text & " " & txtLastName.Text
                        Logaudittrail(role, fullName, "User updated successfully! User ID: " & selectedUserID)

                        LoadUsers()  ' Refresh DataGridView
                    Else
                        MessageBox.Show("No changes were made.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        UserPanel.Visible = False

    End Sub




    ' Validate Inputs
    Private Function ValidateInputs() As Boolean
        ' Validate Username
        If String.IsNullOrEmpty(txtUsername.Text) Then
            MessageBox.Show("Please enter a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate First Name
        If String.IsNullOrEmpty(txtFirstName.Text) Then
            MessageBox.Show("Please enter a first name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate Last Name
        If String.IsNullOrEmpty(txtLastName.Text) Then
            MessageBox.Show("Please enter a last name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate Email
        If String.IsNullOrEmpty(txtEmail.Text) OrElse Not txtEmail.Text.Contains("@") Then
            MessageBox.Show("Please enter a valid email address with '@'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate Age
        If String.IsNullOrEmpty(txtAge.Text) OrElse Not IsNumeric(txtAge.Text) Then
            MessageBox.Show("Please enter a valid age.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        ' Ensure age is 18 or above
        Dim age As Integer = Convert.ToInt32(txtAge.Text)
        If age < 18 Then
            MessageBox.Show("Age must be 18 or above.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate Gender selection
        If cmbGender.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate Role selection
        If cmbRole.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate Address
        If String.IsNullOrEmpty(txtAddress.Text) Then
            MessageBox.Show("Please enter an address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate Password
        If String.IsNullOrEmpty(txtPassword.Text) Then
            MessageBox.Show("Please enter a password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate Confirm Password
        If String.IsNullOrEmpty(txtConfirmPassword.Text) Then
            MessageBox.Show("Please confirm your password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Check if Password and Confirm Password match
        If txtPassword.Text <> txtConfirmPassword.Text Then
            MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True ' ✅ All validations passed
    End Function


    ' KeyPress Event for Name fields (First Name, MI, Last Name)
    Private Sub TextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFirstName.KeyPress, txtMI.KeyPress, txtLastName.KeyPress, txtAge.KeyPress
        Dim txtBox As TextBox = DirectCast(sender, TextBox)

        Select Case txtBox.Name
                ' Allow only letters, spaces, and backspace for name fields
            Case "txtFirstName", "txtMI", "txtLastName"
                If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = " " Then
                    e.Handled = True ' Ignore the key press
                End If

                ' Allow only numbers and backspace for age field
            Case "txtAge"
                If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
                    e.Handled = True ' Ignore the key press
                End If
        End Select
    End Sub

    ' Age validation to ensure 18 and above
    Private Sub txtAge_Leave(sender As Object, e As EventArgs) Handles txtAge.Leave
        If Not String.IsNullOrEmpty(txtAge.Text) AndAlso IsNumeric(txtAge.Text) Then
            Dim age As Integer = Convert.ToInt32(txtAge.Text)
            If age < 18 Then
                MessageBox.Show("Age must be 18 or above.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAge.Text = "" ' Clear the text box
                txtAge.Focus() ' Bring focus back to the field
            End If
        End If
    End Sub


    ' Show Password Checkbox CheckedChanged Event
    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            ' Show the actual password text (remove masking)
            txtPassword.PasswordChar = Nothing
            txtConfirmPassword.PasswordChar = Nothing
        Else
            ' Hide the password with asterisks (*****)
            txtPassword.PasswordChar = "*"c
            txtConfirmPassword.PasswordChar = "*"c
        End If
    End Sub


    Private Sub Logaudittrail(ByVal role As String, ByVal fullName As String, ByVal action As String)
        Try
            'Dim role As String = SessionData.role
            'Dim fullName As String = SessionData.fullName
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "INSERT INTO audittrail (Role, FullName, Action, Form, Date) VALUES (@Role, @FullName, @action, @Form, @Date)"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@Role", role)
                    cmd.Parameters.AddWithValue("@FullName", fullName)
                    cmd.Parameters.AddWithValue("@action", action)
                    cmd.Parameters.AddWithValue("@Form", "UserMain")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        UserPanel.Visible = False

    End Sub



    Private Sub adduser_Click(sender As Object, e As EventArgs)
        UserPanel.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' To hide (close) the panel
        UserPanel.Visible = False

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    '=======================================================================================
    ' Declare VideoCapture but do not initialize immediately
    Private Shadows capture As VideoCapture = Nothing
    Private frame As Mat
    Private capturedImage As Bitmap = Nothing ' Store captured image
    Private webcamCapture As VideoCapture = Nothing

    Private Sub LoadUserImage(userID As String)
        Try
            Dim connString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
            Dim query As String = "SELECT profile_picture FROM users WHERE user_id = @userID"

            Using conn As New MySqlConnection(connString),
              cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@userID", userID)
                conn.Open()

                Dim imgBytes As Byte() = TryCast(cmd.ExecuteScalar(), Byte())

                If imgBytes IsNot Nothing AndAlso imgBytes.Length > 0 Then
                    Using ms As New MemoryStream(imgBytes)
                        picWebcam.Image = Image.FromStream(ms)
                    End Using
                Else
                    picWebcam.Image = Nothing ' ❌ No default image
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading profile picture: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' START WEBCAM - Turns on webcam only when needed
    Private Sub btnStartWebcam_Click(sender As Object, e As EventArgs) Handles btnStartWebcam.Click
        Try
            If webcamCapture Is Nothing Then
                webcamCapture = New VideoCapture(0) ' Initialize webcam only when button is clicked
            End If

            If Not webcamCapture.IsOpened Then
                MessageBox.Show("Webcam failed to open. Check your camera connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Timer1.Interval = 30 ' Set refresh rate (30ms per frame)
            Timer1.Start() ' Start capturing frames

            MessageBox.Show("Webcam started!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error starting webcam: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' STOP WEBCAM - Turns off webcam when not needed
    Private Sub btnStopWebcam_Click(sender As Object, e As EventArgs) Handles btnStopWebcam.Click
        Try
            If webcamCapture IsNot Nothing Then
                Timer1.Stop() ' Stop capturing
                webcamCapture.Release()
                webcamCapture.Dispose()
                webcamCapture = Nothing
                picWebcam.Image = Nothing ' Clear the PictureBox
            End If
        Catch ex As Exception
            MessageBox.Show("Error stopping webcam: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' CAPTURE IMAGE - Take Picture and Stop Updating Live Feed
    Private Sub btnCapture_Click(sender As Object, e As EventArgs) Handles btnCapture.Click
        ' Ask for permission before taking a picture
        Dim result = MessageBox.Show("Do you want to capture the image?", "Permission Required", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Ensure the webcam is running
            If webcamCapture Is Nothing OrElse Not webcamCapture.IsOpened Then
                MessageBox.Show("Webcam is not initialized! Start the webcam first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Capture Frame (Ensure it's read properly)
            Dim frame As New Mat
            webcamCapture.Read(frame) ' Read the frame from the camera

            ' Double check if frame is captured
            If frame Is Nothing OrElse frame.IsEmpty Then
                MessageBox.Show("Failed to capture image. Try again.", "Capture Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Convert to Image and Display in PictureBox
            picWebcam.Image = frame.ToImage(Of Bgr, Byte).ToBitmap

            ' ✅ STOP WEBCAM AFTER CAPTURE
            Timer1.Stop() ' Stop live feed
            webcamCapture.Release()
            webcamCapture.Dispose()
            webcamCapture = Nothing
            MessageBox.Show("Image captured successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            ' ✅ Check kung na-initialize ang webcam bago mag-process
            If webcamCapture Is Nothing OrElse Not webcamCapture.IsOpened Then
                Timer1.Stop() ' Stop Timer if webcam is not running
                MessageBox.Show("Webcam not initialized. Please start the webcam first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Capture Frame
            Dim frame As New Mat()
            webcamCapture.Read(frame)

            If Not frame.IsEmpty Then
                picWebcam.Image = frame.ToImage(Of Bgr, Byte)().ToBitmap()
            End If
        Catch ex As Exception
            MessageBox.Show("Error capturing frame: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' CONVERT IMAGE TO BYTE ARRAY (For saving to database)
    Private Function ConvertImageToBytes(image As Image) As Byte()
        Using ms As New MemoryStream()
            image.Save(ms, Imaging.ImageFormat.Jpeg) ' Convert to JPEG format
            Return ms.ToArray() ' Convert to Byte Array
        End Using
    End Function

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Panelimage.Visible = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        UserPanel.Visible = True
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        UserPanel.Visible = False
    End Sub

    Private Sub btnUser_Click(sender As Object, e As EventArgs) Handles btnUser.Click
        UserPanel.Visible = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        UserPanel.Visible = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panelimage.Visible = False
    End Sub
    Private Sub CustomizeDataGridView()
        With dgvUsers
            ' Set black background and white text for the column headers
            .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            ' Set font for header
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)

            ' Set grid lines color and styles
            .GridColor = Color.LightBlue
            .CellBorderStyle = DataGridViewCellBorderStyle.Single

            ' Make the header text centered
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Adjust row height
            .RowTemplate.Height = 40

            ' Remove row headers (optional)
            .RowHeadersVisible = False

            ' Auto-size the columns to fill the entire DataGridView
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With

        ' Convert column headers to uppercase
        For Each column As DataGridViewColumn In dgvUsers.Columns
            column.HeaderText = column.HeaderText.ToUpper()
        Next
    End Sub


    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Panelimage.Visible = True
    End Sub

    Private Sub btnViewRecords_Click(sender As Object, e As EventArgs) Handles btnViewRecords.Click
        ' Create an instance of the CategoryMain form and show it
        Dim ExportUserForm As New ExportUser()
        ExportUserForm.Show()
    End Sub


    '======================================


End Class
