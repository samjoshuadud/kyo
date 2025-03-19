Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports MySql.Data.MySqlClient

Public Class ProductMain
    Private connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private connection As MySqlConnection

    Private Sub ProductMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Product Management"
        connection = New MySqlConnection(connectionString)
        LoadProducts()
        LoadCategories()
        LoadExpirationOptions() ' Load expiration options into ComboBox
        CustomizeDataGridView()
    End Sub

    ' Load Products into DataGridView
    ' Load Products into DataGridView
    Private Sub LoadProducts()
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim query As String = "
            SELECT p.product_id, p.product_name, p.barcode, p.selling_price, p.cost_price, p.description, 
            p.expiration_option AS expiration_status, 
            c.category_name 
            FROM products p 
            LEFT JOIN categories c ON p.category_id = c.category_id"

            Using cmd As New MySqlCommand(query, connection)
                Using adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    dgvProducts.DataSource = dt
                End Using
            End Using

            ' Adjust column headers and visibility
            dgvProducts.Columns("product_name").HeaderText = "Product Name"
            dgvProducts.Columns("barcode").HeaderText = "Barcode"
            dgvProducts.Columns("selling_price").HeaderText = "Selling Price"
            dgvProducts.Columns("cost_price").HeaderText = "Cost Price"
            dgvProducts.Columns("description").HeaderText = "Description"
            dgvProducts.Columns("expiration_status").HeaderText = "Expiration Status"
            dgvProducts.Columns("category_name").HeaderText = "Category"
            dgvProducts.Columns("product_id").Visible = False ' Hide product_id column
        Catch ex As MySqlException
            MessageBox.Show("MySQL Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub



    ' Load Categories into ComboBox
    Private Sub LoadCategories()
        Try
            If connection.State = ConnectionState.Closed Then connection.Open()
            Dim query As String = "SELECT category_id, category_name FROM categories"
            Dim cmd As New MySqlCommand(query, connection)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            cmbCategories.DataSource = dt
            cmbCategories.DisplayMember = "category_name"
            cmbCategories.ValueMember = "category_id"
        Catch ex As Exception
            MessageBox.Show("Error loading categories: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then connection.Close()
        End Try
    End Sub

    ' Load Expiration Options into ComboBox
    Private Sub LoadExpirationOptions()
        cmbExpirationOption.Items.Clear()
        cmbExpirationOption.Items.Add("With Expiration")
        cmbExpirationOption.Items.Add("Without Expiration")
        cmbExpirationOption.SelectedIndex = 0 ' Default selection
    End Sub

    ' Add Product
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validate inputs before proceeding
        If Not ValidateInputs() Then Exit Sub

        ' Check if the product name already exists in the database
        Dim checkQuery = "SELECT COUNT(*) FROM products WHERE product_name = @product_name"
        Dim checkCmd As New MySqlCommand(checkQuery, connection)
        checkCmd.Parameters.AddWithValue("@product_name", txtProductName.Text)

        Try
            ' Open connection if it's closed
            If connection.State = ConnectionState.Closed Then connection.Open()

            ' Check for existing product name in the database
            Dim count = Convert.ToInt32(checkCmd.ExecuteScalar)
            If count > 0 Then
                MessageBox.Show("This product already exists. Please check the product name and try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Proceed to insert the new product if no duplicates are found
            Dim insertQuery = "
        INSERT INTO products (product_name, barcode, selling_price, cost_price, description, expiration_option, category_id)
        VALUES (@product_name, @barcode, @selling_price, @cost_price, @description, @expiration_option, @category_id)"

            ' Create MySQL command and add parameters
            Dim cmd As New MySqlCommand(insertQuery, connection)
            cmd.Parameters.AddWithValue("@product_name", txtProductName.Text)
            cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text)
            cmd.Parameters.AddWithValue("@selling_price", txtSellingPrice.Text)
            cmd.Parameters.AddWithValue("@cost_price", txtCostPrice.Text)
            cmd.Parameters.AddWithValue("@description", txtDescription.Text)
            cmd.Parameters.AddWithValue("@expiration_option", cmbExpirationOption.SelectedItem.ToString)
            cmd.Parameters.AddWithValue("@category_id", cmbCategories.SelectedValue)

            ' Execute insert query
            cmd.ExecuteNonQuery()

            ' Log audit trail for adding the product (include category name if needed)
            Dim categoryName = cmbCategories.SelectedItem.ToString ' Getting the selected category name
            Logaudittrail(role, fullName, "Added product: " & txtProductName.Text)

            ' Show success message
            MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Reload product list and reset form
            LoadProducts()
            ResetForm()

        Catch ex As Exception
            ' Handle any errors that may occur
            MessageBox.Show("Error adding product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Ensure connection is closed
            If connection.State = ConnectionState.Open Then connection.Close()
        End Try
    End Sub



    ' Update Product
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
        If Not ValidateInputs() Then Exit Sub
        If dgvProducts.CurrentRow Is Nothing Then
            MessageBox.Show("Select a product to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            If connection.State = ConnectionState.Closed Then connection.Open()

            ' Retrieve original values before update
            Dim originalProduct As New Dictionary(Of String, String)
            Dim updatedProduct As New Dictionary(Of String, String)

            Dim selectQuery = "SELECT product_name, barcode, selling_price, cost_price, description, expiration_option, category_id FROM products WHERE product_id = @product_id"
            Dim selectCmd As New MySqlCommand(selectQuery, connection)
            selectCmd.Parameters.AddWithValue("@product_id", dgvProducts.CurrentRow.Cells("product_id").Value)

            Try
                Using reader = selectCmd.ExecuteReader
                    If reader.Read Then
                        originalProduct("product_name") = reader("product_name").ToString
                        originalProduct("barcode") = reader("barcode").ToString
                        originalProduct("selling_price") = reader("selling_price").ToString
                        originalProduct("cost_price") = reader("cost_price").ToString
                        originalProduct("description") = reader("description").ToString
                        originalProduct("expiration_option") = reader("expiration_option").ToString
                        originalProduct("category_id") = reader("category_id").ToString
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving original product data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try

            ' Prepare updated values from the form
            updatedProduct("product_name") = txtProductName.Text
            updatedProduct("barcode") = txtBarcode.Text
            updatedProduct("selling_price") = txtSellingPrice.Text
            updatedProduct("cost_price") = txtCostPrice.Text
            updatedProduct("description") = txtDescription.Text
            updatedProduct("expiration_option") = cmbExpirationOption.SelectedItem.ToString
            updatedProduct("category_id") = cmbCategories.SelectedValue.ToString

            ' Check for unique barcode (excluding the current product)
            Dim checkQuery = "SELECT COUNT(*) FROM products WHERE barcode = @barcode AND product_id != @product_id"
            Dim checkCmd As New MySqlCommand(checkQuery, connection)
            checkCmd.Parameters.AddWithValue("@barcode", txtBarcode.Text)
            checkCmd.Parameters.AddWithValue("@product_id", dgvProducts.CurrentRow.Cells("product_id").Value)
            Dim count = Convert.ToInt32(checkCmd.ExecuteScalar)

            If count > 0 Then
                MessageBox.Show("Barcode must be unique. This barcode already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Update Product
            Dim query = "
        UPDATE products SET product_name = @product_name, barcode = @barcode, selling_price = @selling_price, 
        cost_price = @cost_price, description = @description, expiration_option = @expiration_option, 
        category_id = @category_id WHERE product_id = @product_id"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@product_name", txtProductName.Text)
            cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text)
            cmd.Parameters.AddWithValue("@selling_price", txtSellingPrice.Text)
            cmd.Parameters.AddWithValue("@cost_price", txtCostPrice.Text)
            cmd.Parameters.AddWithValue("@description", txtDescription.Text)
            cmd.Parameters.AddWithValue("@expiration_option", cmbExpirationOption.SelectedItem.ToString)
            cmd.Parameters.AddWithValue("@category_id", cmbCategories.SelectedValue)
            cmd.Parameters.AddWithValue("@product_id", dgvProducts.CurrentRow.Cells("product_id").Value)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadProducts()
            ResetForm()

            ' Log detailed changes
            Dim changes = "Edited the product: " & txtProductName.Text & vbCrLf
            For Each key In originalProduct.Keys
                If originalProduct(key) <> updatedProduct(key) Then
                    changes &= $"{key} changed from '{originalProduct(key)}' to '{updatedProduct(key)}'" & vbCrLf
                End If
            Next

            ' ✅ Log Audit Trail for Edit Product
            Logaudittrail(role, fullName, changes)

        Catch ex As Exception
            MessageBox.Show("Error updating product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then connection.Close()
        End Try
    End Sub


    ' Delete Product
    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        If dgvProducts.CurrentRow Is Nothing Then
            MessageBox.Show("Select a product to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get the product ID and category name before deletion
        Dim productID As Integer = dgvProducts.CurrentRow.Cells("product_id").Value
        Dim productName = dgvProducts.CurrentRow.Cells("product_name").Value.ToString
        Dim categoryName = dgvProducts.CurrentRow.Cells("category_name").Value.ToString

        Try
            If connection.State = ConnectionState.Closed Then connection.Open()

            ' Prepare DELETE query
            Dim query = "DELETE FROM products WHERE product_id = @product_id"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@product_id", productID)

            ' Execute the delete command
            cmd.ExecuteNonQuery()

            ' Log the product deletion with category
            Logaudittrail(role, fullName, "Deleted product: " & txtProductName.Text)

            ' Show success message
            MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Reload product list and reset form
            LoadProducts()
            ResetForm()

        Catch ex As Exception
            ' Handle any errors that may occur
            MessageBox.Show("Error deleting product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Ensure connection is closed
            If connection.State = ConnectionState.Open Then connection.Close()
        End Try
    End Sub



    Private Function GetCategoryIdByName(categoryName As String) As Integer
        ' Check through each item in the ComboBox to find the matching category name
        For Each row As DataRowView In cmbCategories.Items
            If row("category_name").ToString().Trim().ToLower() = categoryName.Trim().ToLower() Then
                ' Return the category_id if the category name matches
                Return Convert.ToInt32(row("category_id"))
            End If
        Next
        ' Return -1 if no matching category is found
        Return -1
    End Function



    Private Sub dgvProducts_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellContentClick
        If e.RowIndex >= 0 Then ' Ensure the click is on a valid row (not on headers)
            Dim selectedRow As DataGridViewRow = dgvProducts.Rows(e.RowIndex)

            ' Populate input fields with the selected product's details
            txtProductName.Text = selectedRow.Cells("product_name").Value.ToString()
            txtBarcode.Text = selectedRow.Cells("barcode").Value.ToString()
            txtSellingPrice.Text = selectedRow.Cells("selling_price").Value.ToString()
            txtCostPrice.Text = selectedRow.Cells("cost_price").Value.ToString()
            txtDescription.Text = selectedRow.Cells("description").Value.ToString()
            cmbExpirationOption.SelectedItem = selectedRow.Cells("expiration_status").Value.ToString()

            ' Get the category ID and set the ComboBox
            Dim categoryId As Integer = GetCategoryIdByName(selectedRow.Cells("category_name").Value.ToString())
            If categoryId <> -1 Then
                cmbCategories.SelectedValue = categoryId
            Else
                MessageBox.Show("Category not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub


    ' Validate Input Fields
    Private Function ValidateInputs() As Boolean
        If txtProductName.Text = "" Or txtBarcode.Text = "" Or txtSellingPrice.Text = "" Or txtCostPrice.Text = "" Or txtDescription.Text = "" Then
            MessageBox.Show("Please fill out all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub ResetForm()
        ' Clear all text fields
        txtProductName.Clear()
        txtBarcode.Clear()
        txtSellingPrice.Clear()
        txtCostPrice.Clear()
        txtDescription.Clear()

        ' Reset ComboBoxes to their default values
        cmbExpirationOption.SelectedIndex = 0 ' Reset to first option
        cmbCategories.SelectedIndex = -1 ' Deselect the category ComboBox
    End Sub

    ' Reset Form Inputs
    Private Sub btnReset_Click(sender As Object, e As EventArgs)
        txtProductName.Clear()
        txtBarcode.Clear()
        txtSellingPrice.Clear()
        txtCostPrice.Clear()
        txtDescription.Clear()
        cmbExpirationOption.SelectedIndex = 0
        cmbCategories.SelectedIndex = -1
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
                    cmd.Parameters.AddWithValue("@Form", "ProductMain")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PanelProduct.Size = New Size(623, 548) ' Set panel size
        PanelProduct.Location = New Point(437, 59) ' Set panel location
    End Sub

    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        PanelProduct.Visible = True
    End Sub

    Private Sub CustomizeDataGridView()
        With dgvProducts
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
        For Each column As DataGridViewColumn In dgvProducts.Columns
            column.HeaderText = column.HeaderText.ToUpper()
        Next
    End Sub


End Class
