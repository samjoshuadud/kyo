Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Login
    Private connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private connection As MySqlConnection

    Public Sub New()
        connection = New MySqlConnection(connectionString)
        InitializeComponent()
    End Sub

    Private Sub LogHistoryEntry(ByVal Role As String, ByVal FullName As String, ByVal Action As String)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim cmd As New MySqlCommand("INSERT INTO loghistory (Role, FullName, Action, Date) VALUES (@Role, @FullName, @Action, NOW())", connection)
                cmd.Parameters.AddWithValue("@Role", Role)
                cmd.Parameters.AddWithValue("@FullName", FullName)
                cmd.Parameters.AddWithValue("@Action", Action)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging action: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Login Button Click Event
    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        ' Check for empty input
        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' SQL query to check for valid user with hashed password
                Dim query As String = "SELECT user_id, full_name, role FROM users WHERE username = @username AND password_hash = SHA2(@password, 256)"
                Using cmd As New MySqlCommand(query, conn)
                    ' Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", password)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Retrieve user information
                            Dim userId As Integer = reader("user_id")
                            Dim fullName As String = reader("full_name").ToString()
                            Dim role As String = reader("role").ToString()

                            ' Log successful login attempt
                            LogHistoryEntry(role, fullName, "Login")

                            ' Store session data for current user
                            SessionData.CurrentUserId = userId
                            SessionData.role = role
                            SessionData.fullName = fullName

                            ' Open the Main Form and hide login form
                            Dim mainForm As New Main(role)
                            Me.Hide()
                            mainForm.ShowDialog()
                            Me.Close()
                        Else
                            ' Handle incorrect login credentials
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As MySqlException
            ' Handle database-specific errors
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            ' Handle general errors
            MessageBox.Show("Error during login: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' Form Load Event
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Clear session data on login screen load
        SessionData.CurrentUserId = 0
        SessionData.role = String.Empty
        SessionData.fullName = String.Empty

        ' SA DESIGN 
        txtUsername.BorderStyle = BorderStyle.None
        txtPassword.BorderStyle = BorderStyle.None
        txtUsername.BackColor = Color.White
        txtPassword.BackColor = Color.White

        ' Set password field to show asterisks (*****)
        txtPassword.PasswordChar = "*"c
    End Sub

    ' Form Design Customization
    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint
        FlowLayoutPanel1.BackColor = Color.FromArgb(176, 0, 32) ' Using RGB equivalent of #B00020
    End Sub


    ' Button Styling
    Private Sub BtnLogin_Paint(sender As Object, e As PaintEventArgs) Handles BtnLogin.Paint
        ' Blended color: a mix of red (#B00020) and white (#FFFFFF)
        BtnLogin.FlatStyle = FlatStyle.Flat
        BtnLogin.BackColor = Color.FromArgb(176, 0, 32) ' Blended color close to #B00020
        BtnLogin.ForeColor = Color.White ' Text color
        BtnLogin.FlatAppearance.BorderSize = 0
        BtnLogin.Font = New Font("Segoe UI", 12, FontStyle.Bold)

    End Sub

    ' Show Password Checkbox CheckedChanged Event
    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            ' Show the actual password text (remove masking)
            txtPassword.PasswordChar = Nothing
        Else
            ' Hide the password with asterisks (*****)
            txtPassword.PasswordChar = "*"c
        End If
    End Sub

    ' Exit Button
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub
End Class
