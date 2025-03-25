Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class SupplierMain
    Inherits Form

    Private connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private connection As MySqlConnection
    Private selectedSupplierId As Integer = -1 ' Tracks the selected Supplier ID

    Public Sub New()
        InitializeComponent()
        Me.Text = "Supplier Management"
        connection = New MySqlConnection(connectionString)

        ' Initialize button states
        SetInitialButtonStates()
        
        ' Load Suppliers
        LoadSuppliers()
    End Sub

    ' Set initial button states
    Private Sub SetInitialButtonStates()
        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        ClearFields()
    End Sub

    ' Load Suppliers into DataGridView
    Private Sub LoadSuppliers()
        Try
            If connection.State = ConnectionState.Closed Then connection.Open()
            Dim query As String = "SELECT supplier_id, supplier_name, contact_number, address, email FROM suppliers"
            Dim cmd As New MySqlCommand(query, connection)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            dgvSuppliers.DataSource = dt

            ' Format the DataGridView
            dgvSuppliers.Columns("supplier_id").Visible = False
            dgvSuppliers.Columns("supplier_name").HeaderText = "Name"
            dgvSuppliers.Columns("contact_number").HeaderText = "Contact Number"
            dgvSuppliers.Columns("address").HeaderText = "Address"
            dgvSuppliers.Columns("email").HeaderText = "Email"

            ' Auto-size columns
            dgvSuppliers.AutoResizeColumns()
        Catch ex As Exception
            MessageBox.Show("Error loading suppliers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Add Supplier
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ValidateInputs() Then Exit Sub

        Try
            If connection.State = ConnectionState.Closed Then connection.Open()
            Dim query As String = "INSERT INTO suppliers (supplier_name, contact_number, address, email) " &
                                  "VALUES (@name, @contact, @address, @email)"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@name", txtSupplierName.Text)
            cmd.Parameters.AddWithValue("@contact", txtContactNumber.Text)
            cmd.Parameters.AddWithValue("@address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@email", txtEmail.Text)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Supplier added successfully!")
            LoadSuppliers()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Error adding supplier: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Update Supplier
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If selectedSupplierId = -1 Then
            MessageBox.Show("Please select a supplier to edit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not ValidateInputs() Then Exit Sub

        Try
            If connection.State = ConnectionState.Closed Then connection.Open()
            Dim query As String = "UPDATE suppliers SET supplier_name = @name, contact_number = @contact, " &
                                  "address = @address, email = @email WHERE supplier_id = @id"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@name", txtSupplierName.Text)
            cmd.Parameters.AddWithValue("@contact", txtContactNumber.Text)
            cmd.Parameters.AddWithValue("@address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@id", selectedSupplierId)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Supplier updated successfully!")
            LoadSuppliers()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Error updating supplier: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Delete Supplier
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedSupplierId = -1 Then
            MessageBox.Show("Please select a supplier to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Ask for confirmation before deleting
        Dim confirmResult = MessageBox.Show("Are you sure you want to delete this supplier?", "Confirm Delete",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmResult = DialogResult.No Then
            Return
        End If

        Try
            If connection.State = ConnectionState.Closed Then connection.Open()
            Dim query As String = "DELETE FROM suppliers WHERE supplier_id = @id"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@id", selectedSupplierId)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Supplier deleted successfully!")
            LoadSuppliers()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Error deleting supplier: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Reset Fields
    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ClearFields()
    End Sub

    ' Clear all input fields and reset button states
    Private Sub ClearFields()
        txtSupplierName.Clear()
        txtContactNumber.Clear()
        txtAddress.Clear()
        txtEmail.Clear()
        selectedSupplierId = -1
        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False
    End Sub

    ' DataGridView Row Click
    Private Sub DgvSuppliers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSuppliers.CellClick
        Try
            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow = dgvSuppliers.Rows(e.RowIndex)

                ' Check if the row is empty or new
                If row.IsNewRow OrElse IsDBNull(row.Cells("supplier_id").Value) Then
                    ClearFields()
                    Return
                End If

                ' Get the supplier ID and update selected ID
                selectedSupplierId = Convert.ToInt32(row.Cells("supplier_id").Value)

                ' Populate input fields
                txtSupplierName.Text = If(row.Cells("supplier_name").Value IsNot Nothing, row.Cells("supplier_name").Value.ToString(), String.Empty)
                txtContactNumber.Text = If(row.Cells("contact_number").Value IsNot Nothing, row.Cells("contact_number").Value.ToString(), String.Empty)
                txtAddress.Text = If(row.Cells("address").Value IsNot Nothing, row.Cells("address").Value.ToString(), String.Empty)
                txtEmail.Text = If(row.Cells("email").Value IsNot Nothing, row.Cells("email").Value.ToString(), String.Empty)

                ' Update button states
                btnAdd.Enabled = False
                btnEdit.Enabled = True
                btnDelete.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show("Error selecting row: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Validate Inputs
    Private Function ValidateInputs() As Boolean
        ' Validate supplier name
        If String.IsNullOrWhiteSpace(txtSupplierName.Text) Then
            MessageBox.Show("Supplier name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate contact number (11 digits with optional +63 prefix)
        Dim contactPattern As String = "^(09\d{9}|(\+63)9\d{9})$"
        If Not Regex.IsMatch(txtContactNumber.Text, contactPattern) Then
            MessageBox.Show("Contact number must be 11 digits starting with 09 or prefixed with +63.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate address
        If String.IsNullOrWhiteSpace(txtAddress.Text) Then
            MessageBox.Show("Address is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate email
        If String.IsNullOrWhiteSpace(txtEmail.Text) OrElse Not txtEmail.Text.Contains("@"c) Then
            MessageBox.Show("Valid email is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    ' Check if Supplier Name already exists in the database
    Private Function CheckDuplicateSupplierName(supplierName As String, Optional excludeId As Integer = -1) As Boolean
        Try
            If connection.State = ConnectionState.Closed Then connection.Open()
            Dim query As String
            If excludeId > 0 Then
                query = "SELECT COUNT(*) FROM suppliers WHERE supplier_name = @name AND supplier_id <> @id"
            Else
                query = "SELECT COUNT(*) FROM suppliers WHERE supplier_name = @name"
            End If
            
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@name", supplierName)
            If excludeId > 0 Then
                cmd.Parameters.AddWithValue("@id", excludeId)
            End If
            
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return count > 0
        Catch ex As Exception
            MessageBox.Show("Error checking duplicate supplier name: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True
        Finally
            connection.Close()
        End Try
    End Function
End Class
