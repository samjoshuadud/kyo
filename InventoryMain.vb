Imports MySql.Data.MySqlClient

Public Class InventoryMain
    Private connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private connection As MySqlConnection
    Private selectedInventoryId As Integer = -1 ' Tracks the selected inventory ID


    Public Sub New()
        InitializeComponent()
        ' Initialize form properties
        Me.Text = "Inventory Management"
        Me.Width = 850
        Me.Height = 550
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = ColorTranslator.FromHtml("#B2DFEE") ' Light blue background

        connection = New MySqlConnection(connectionString)

        ' Load inventory data into the grid
        LoadInventoryData()
    End Sub




    ' Load Inventory data into the grid
    Private Sub LoadInventoryData()
        Try
            ' Ensure the connection is open
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            ' Query to retrieve inventory data
            Dim query As String = "
                SELECT i.inventory_id, p.product_name, i.current_quantity
                FROM inventory i
                JOIN products p ON i.product_id = p.product_id
                ORDER BY p.product_name ASC"
            Dim cmd As New MySqlCommand(query, connection)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            ' Load data into DataGridView
            Dim dt As New DataTable()
            dt.Load(reader)
            dgvInventory.DataSource = dt

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading inventory data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    ' Handle row selection in the grid
    Private Sub DgvInventory_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvInventory.Rows(e.RowIndex)
            selectedInventoryId = Convert.ToInt32(row.Cells("inventory_id").Value)
            txtProductName.Text = row.Cells("product_name").Value.ToString()
            txtQuantity.Text = row.Cells("current_quantity").Value.ToString()
        End If
    End Sub

    ' Add new Inventory entry
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs)
        If Not ValidateInputs() Then Exit Sub

        Try
            connection.Open()

            ' First, check if the product already exists in the inventory
            Dim checkQuery As String = "
            SELECT COUNT(*) FROM inventory i
            JOIN products p ON i.product_id = p.product_id
            WHERE p.product_name = @product_name"
            Dim checkCmd As New MySqlCommand(checkQuery, connection)
            checkCmd.Parameters.AddWithValue("@product_name", txtProductName.Text)
            Dim existingProductCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

            ' If the product exists, update the quantity
            If existingProductCount > 0 Then
                Dim updateQuery As String = "
                UPDATE inventory
                SET current_quantity = current_quantity + @quantity
                WHERE product_id = (SELECT product_id FROM products WHERE product_name = @product_name)"
                Dim updateCmd As New MySqlCommand(updateQuery, connection)
                updateCmd.Parameters.AddWithValue("@product_name", txtProductName.Text)
                updateCmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text))
                updateCmd.ExecuteNonQuery()

                MessageBox.Show("Inventory quantity updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' If the product doesn't exist, insert a new inventory entry
                Dim insertQuery As String = "
                INSERT INTO inventory (product_id, current_quantity)
                SELECT product_id, @quantity FROM products WHERE product_name = @product_name"
                Dim insertCmd As New MySqlCommand(insertQuery, connection)
                insertCmd.Parameters.AddWithValue("@product_name", txtProductName.Text)
                insertCmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text))
                insertCmd.ExecuteNonQuery()

                MessageBox.Show("Inventory entry added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ' Reload inventory data after operation
            LoadInventoryData()
        Catch ex As Exception
            MessageBox.Show("Error adding/updating inventory entry: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Edit selected Inventory entry
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs)
        If selectedInventoryId = -1 Then
            MessageBox.Show("Please select an inventory entry to edit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidateInputs() Then Exit Sub

        Try
            connection.Open()
            Dim query As String = "
                UPDATE inventory 
                SET current_quantity = @quantity
                WHERE inventory_id = @inventory_id"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text))
            cmd.Parameters.AddWithValue("@inventory_id", selectedInventoryId)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Inventory entry updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadInventoryData()
        Catch ex As Exception
            MessageBox.Show("Error updating inventory entry: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Delete selected Inventory entry
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs)
        If selectedInventoryId = -1 Then
            MessageBox.Show("Please select an inventory entry to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            connection.Open()
            Dim query As String = "DELETE FROM inventory WHERE inventory_id = @inventory_id"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@inventory_id", selectedInventoryId)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Inventory entry deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadInventoryData()
        Catch ex As Exception
            MessageBox.Show("Error deleting inventory entry: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Close the form
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
    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
        ' Handle the text changed event here
        ' For example, you can validate the input or update other controls
    End Sub
    Private Sub InventoryMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvInventory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventory.CellContentClick

    End Sub
End Class