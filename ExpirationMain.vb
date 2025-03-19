Imports MySql.Data.MySqlClient

Public Class ExpirationMain
    Private connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private connection As MySqlConnection
    Private selectedTrackingId As Integer = -1 ' Tracks the selected expiration record ID

    ' UI Controls
    Private dgvExpiration As DataGridView
    Private txtProductName, txtQuantity As TextBox
    Private dtpExpirationDate As DateTimePicker
    Private btnAdd, btnEdit, btnDelete, btnClose As Button
    Private pnlInputs As Panel

    Private Sub ExpirationMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeUI()
        connection = New MySqlConnection(connectionString)
        LoadExpirationData()
    End Sub

    Private Sub InitializeUI()
        Me.Text = "Expiration Management"
        Me.Width = 800
        Me.Height = 550
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.White

        ' DataGridView
        dgvExpiration = New DataGridView With {
            .Location = New Point(20, 20),
            .Width = 740,
            .Height = 200,
            .ReadOnly = True,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        }
        AddHandler dgvExpiration.CellClick, AddressOf DgvExpiration_CellClick

        ' Panel for inputs
        pnlInputs = New Panel With {
            .Location = New Point(20, 240),
            .Width = 740,
            .Height = 150,
            .BorderStyle = BorderStyle.FixedSingle,
            .BackColor = Color.White
        }

        ' Labels & Inputs
        Dim lblProductName As New Label With {.Text = "Product Name:", .Location = New Point(10, 20), .Font = New Font("Segoe UI", 10, FontStyle.Bold)}
        txtProductName = New TextBox With {.Location = New Point(150, 20), .Width = 200, .ReadOnly = True}

        Dim lblExpirationDate As New Label With {.Text = "Expiration Date:", .Location = New Point(380, 20), .Font = New Font("Segoe UI", 10, FontStyle.Bold)}
        dtpExpirationDate = New DateTimePicker With {.Location = New Point(500, 20), .Width = 200, .Format = DateTimePickerFormat.Short}

        Dim lblQuantity As New Label With {.Text = "Quantity:", .Location = New Point(10, 60), .Font = New Font("Segoe UI", 10, FontStyle.Bold)}
        txtQuantity = New TextBox With {.Location = New Point(150, 60), .Width = 200}

        pnlInputs.Controls.AddRange(New Control() {lblProductName, txtProductName, lblExpirationDate, dtpExpirationDate, lblQuantity, txtQuantity})

        ' Buttons
        btnAdd = CreateButton("Add", 20, AddressOf BtnAdd_Click)
        btnEdit = CreateButton("Edit", 180, AddressOf BtnEdit_Click)
        btnDelete = CreateButton("Delete", 340, AddressOf BtnDelete_Click)
        btnClose = CreateButton("Close", 500, AddressOf BtnClose_Click)

        ' Add controls to the form
        Me.Controls.AddRange(New Control() {dgvExpiration, pnlInputs, btnAdd, btnEdit, btnDelete, btnClose})
    End Sub

    Private Function CreateButton(text As String, x As Integer, clickEvent As EventHandler) As Button
        Dim btn As New Button With {
            .Text = text,
            .Location = New Point(x, 420),
            .Width = 150,
            .Height = 50,
            .BackColor = ColorTranslator.FromHtml("#B00020"),
            .FlatStyle = FlatStyle.Flat,
            .ForeColor = Color.White
        }
        AddHandler btn.Click, clickEvent
        Return btn
    End Function

    Private Sub LoadExpirationData()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT et.tracking_id, p.product_name, et.expiration_date, et.quantity AS current_quantity FROM expiration_tracking et JOIN products p ON et.product_id = p.product_id ORDER BY et.expiration_date ASC;"
                Dim dt As New DataTable()
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        dt.Load(reader)
                    End Using
                End Using
                dgvExpiration.DataSource = dt
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading expiration data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DgvExpiration_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvExpiration.Rows(e.RowIndex)
            selectedTrackingId = If(IsDBNull(row.Cells("tracking_id").Value), -1, Convert.ToInt32(row.Cells("tracking_id").Value))
            txtProductName.Text = row.Cells("product_name").Value.ToString()
            txtQuantity.Text = row.Cells("current_quantity").Value.ToString()
            dtpExpirationDate.Value = If(IsDBNull(row.Cells("expiration_date").Value), DateTime.Now, Convert.ToDateTime(row.Cells("expiration_date").Value))
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs)
        If Not ValidateInputs() Then Exit Sub
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Kunin ang product_id gamit ang product_name
                Dim productId As Integer = -1
                Dim getProductQuery As String = "SELECT product_id FROM products WHERE product_name = @product_name"
                Using cmd As New MySqlCommand(getProductQuery, conn)
                    cmd.Parameters.AddWithValue("@product_name", txtProductName.Text)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing Then productId = Convert.ToInt32(result)
                End Using

                If productId = -1 Then
                    MessageBox.Show("Product not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                ' Check kung may existing expiration entry na
                Dim checkQuery As String = "SELECT COUNT(*) FROM expiration_tracking WHERE product_id = @product_id AND expiration_date = @expiration_date"
                Dim recordExists As Boolean = False
                Using cmd As New MySqlCommand(checkQuery, conn)
                    cmd.Parameters.AddWithValue("@product_id", productId)
                    cmd.Parameters.AddWithValue("@expiration_date", dtpExpirationDate.Value)
                    recordExists = Convert.ToInt32(cmd.ExecuteScalar()) > 0
                End Using

                If recordExists Then
                    ' Update existing quantity
                    Dim updateQuery As String = "UPDATE expiration_tracking SET quantity = quantity + @quantity WHERE product_id = @product_id AND expiration_date = @expiration_date"
                    Using cmd As New MySqlCommand(updateQuery, conn)
                        cmd.Parameters.AddWithValue("@product_id", productId)
                        cmd.Parameters.AddWithValue("@expiration_date", dtpExpirationDate.Value)
                        cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text))
                        cmd.ExecuteNonQuery()
                    End Using
                Else
                    ' Insert new entry
                    Dim insertQuery As String = "INSERT INTO expiration_tracking (product_id, expiration_date, quantity) VALUES (@product_id, @expiration_date, @quantity)"
                    Using cmd As New MySqlCommand(insertQuery, conn)
                        cmd.Parameters.AddWithValue("@product_id", productId)
                        cmd.Parameters.AddWithValue("@expiration_date", dtpExpirationDate.Value)
                        cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text))
                        cmd.ExecuteNonQuery()
                    End Using
                End If

                MessageBox.Show("Expiration entry successfully saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadExpirationData()

            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving expiration entry: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub BtnEdit_Click(sender As Object, e As EventArgs)
        If selectedTrackingId = -1 Then
            MessageBox.Show("Please select a record to edit.", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not ValidateInputs() Then Exit Sub

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "UPDATE expiration_tracking SET expiration_date = @expiration_date, quantity = @quantity WHERE tracking_id = @tracking_id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@expiration_date", dtpExpirationDate.Value)
                    cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text))
                    cmd.Parameters.AddWithValue("@tracking_id", selectedTrackingId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Expiration entry updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadExpirationData()
        Catch ex As Exception
            MessageBox.Show("Error updating expiration entry: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs)
        If selectedTrackingId = -1 Then
            MessageBox.Show("Please select a record to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim confirmResult As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmResult = DialogResult.No Then Exit Sub

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "DELETE FROM expiration_tracking WHERE tracking_id = @tracking_id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@tracking_id", selectedTrackingId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Expiration entry deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            selectedTrackingId = -1
            txtProductName.Clear()
            txtQuantity.Clear()
            dtpExpirationDate.Value = DateTime.Now
            LoadExpirationData()
        Catch ex As Exception
            MessageBox.Show("Error deleting expiration entry: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub BtnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    ' Validate user inputs
    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtProductName.Text) Then
            MessageBox.Show("Please select a valid product.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtQuantity.Text) OrElse Not Integer.TryParse(txtQuantity.Text, Nothing) Then
            MessageBox.Show("Please enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function


End Class
