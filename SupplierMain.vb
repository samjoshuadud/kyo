Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class SupplierMain
    Inherits Form

    Private connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private connection As MySqlConnection



    Public Sub New()
        InitializeComponent()
        Me.Text = "Supplier Management"
        Me.Width = 900
        Me.Height = 700
        Me.StartPosition = FormStartPosition.CenterScreen

        connection = New MySqlConnection(connectionString)
        AddHandler Me.Load, AddressOf SupplierMain_Load
    End Sub

    ' Initialize UI Components



    ' Load Event
    Private Sub SupplierMain_Load(sender As Object, e As EventArgs)
        LoadSuppliers()
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

            ' Rename columns for readability
            dgvSuppliers.Columns("supplier_id").HeaderText = "Supplier ID"
            dgvSuppliers.Columns("supplier_name").HeaderText = "Name"
            dgvSuppliers.Columns("contact_number").HeaderText = "Contact Number"
            dgvSuppliers.Columns("address").HeaderText = "Address"
            dgvSuppliers.Columns("email").HeaderText = "Email"
        Catch ex As Exception
            MessageBox.Show("Error loading suppliers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Add Supplier
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs)
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
        Catch ex As Exception
            MessageBox.Show("Error adding supplier: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub


    ' Update Supplier
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtSupplierId.Text) OrElse Not ValidateInputs() Then Exit Sub

        Try
            If connection.State = ConnectionState.Closed Then connection.Open()
            Dim query As String = "UPDATE suppliers SET supplier_name = @name, contact_number = @contact, " &
                                  "address = @address, email = @email WHERE supplier_id = @id"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@name", txtSupplierName.Text)
            cmd.Parameters.AddWithValue("@contact", txtContactNumber.Text)
            cmd.Parameters.AddWithValue("@address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@id", txtSupplierId.Text)
            cmd.Parameters.AddWithValue("@email", txtEmail.Text)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Supplier updated successfully!")
            LoadSuppliers()
        Catch ex As Exception
            MessageBox.Show("Error updating supplier: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Delete Supplier
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtSupplierId.Text) Then
            MessageBox.Show("Select a supplier to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            If connection.State = ConnectionState.Closed Then connection.Open()
            Dim query As String = "DELETE FROM suppliers WHERE supplier_id = @id"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@id", txtSupplierId.Text)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Supplier deleted successfully!")
            LoadSuppliers()
        Catch ex As Exception
            MessageBox.Show("Error deleting supplier: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Reset Fields
    Private Sub BtnReset_Click(sender As Object, e As EventArgs)
        txtSupplierId.Clear()
        txtSupplierName.Clear()
        txtContactNumber.Clear()
        txtAddress.Clear()
        txtEmail.Clear()
    End Sub

    ' DataGridView Row Click
    Private Sub DgvSuppliers_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        Try
            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow = dgvSuppliers.Rows(e.RowIndex)

                txtSupplierId.Text = If(row.Cells("supplier_id").Value IsNot Nothing, row.Cells("supplier_id").Value.ToString(), String.Empty)
                txtSupplierName.Text = If(row.Cells("supplier_name").Value IsNot Nothing, row.Cells("supplier_name").Value.ToString(), String.Empty)
                txtContactNumber.Text = If(row.Cells("contact_number").Value IsNot Nothing, row.Cells("contact_number").Value.ToString(), String.Empty)
                txtAddress.Text = If(row.Cells("address").Value IsNot Nothing, row.Cells("address").Value.ToString(), String.Empty)
                txtEmail.Text = If(row.Cells("email").Value IsNot Nothing, row.Cells("email").Value.ToString(), String.Empty)
            End If
        Catch ex As Exception
            MessageBox.Show("Error selecting row: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Validate Inputs
    ' Validate Inputs
    Private Function ValidateInputs() As Boolean
        ' Validate supplier name
        If String.IsNullOrWhiteSpace(txtSupplierName.Text) Then
            MessageBox.Show("Supplier name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate duplicate supplier name
        If CheckDuplicateSupplierName(txtSupplierName.Text) Then
            MessageBox.Show("Supplier name already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

        ' Validate duplicate address
        If CheckDuplicateAddress(txtAddress.Text) Then
            MessageBox.Show("Address already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate email
        ' Use Contains(char) for single character search
        If String.IsNullOrWhiteSpace(txtEmail.Text) OrElse Not txtEmail.Text.Contains("@"c) Then
            MessageBox.Show("Valid email is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function
    ' Check if Supplier Name already exists in the database
    Private Function CheckDuplicateSupplierName(supplierName As String) As Boolean
        Try
            If connection.State = ConnectionState.Closed Then connection.Open()
            Dim query As String = "SELECT COUNT(*) FROM suppliers WHERE supplier_name = @name"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@name", supplierName)
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return count > 0 ' Returns True if supplier name already exists
        Catch ex As Exception
            MessageBox.Show("Error checking duplicate supplier name: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True ' Return True in case of error (so the action won't continue)
        Finally
            connection.Close()
        End Try
    End Function

    ' Check if Address already exists in the database
    Private Function CheckDuplicateAddress(address As String) As Boolean
        Try
            If connection.State = ConnectionState.Closed Then connection.Open()
            Dim query As String = "SELECT COUNT(*) FROM suppliers WHERE address = @address"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@address", address)
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return count > 0 ' Returns True if address already exists
        Catch ex As Exception
            MessageBox.Show("Error checking duplicate address: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True ' Return True in case of error (so the action won't continue)
        Finally
            connection.Close()
        End Try
    End Function


    Private Sub SupplierMain_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
