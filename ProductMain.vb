Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports MySql.Data.MySqlClient

Public Class ProductMain
    Private connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private connection As MySqlConnection

    Private Sub ProductMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Product & Inventory Management"
        connection = New MySqlConnection(connectionString)

        ' Set initial button states
        SetInitialButtonStates()

        ' Try the alternative loading method that doesn't use a subquery
        LoadProductsAlternate()

        LoadCategories()
        LoadSuppliers() ' Load suppliers into ComboBox
        LoadExpirationOptions() ' Load expiration options into ComboBox
        CustomizeDataGridView()
    End Sub

    ' Set initial button states
    Private Sub SetInitialButtonStates()
        btnSave.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnReceiveDelivery.Visible = False
        btnViewDeliveryHistory.Visible = False
    End Sub

    ' Load Products into DataGridView with Inventory Levels
    Private Sub LoadProducts()
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim query As String = "
            SELECT p.product_id, p.product_name, p.barcode, p.selling_price, p.cost_price, p.description, 
            p.expiration_option AS expiration_status, c.category_name,
            IFNULL((SELECT SUM(i.current_quantity) FROM inventory i WHERE i.product_id = p.product_id), 0) AS stock_level
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
            dgvProducts.Columns("stock_level").HeaderText = "Current Stock"
            dgvProducts.Columns("product_id").Visible = False ' Hide product_id column

            ' Apply conditional formatting to stock level column
            ApplyStockLevelFormatting()

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

    ' Alternative version using a JOIN instead of a subquery
    Private Sub LoadProductsAlternate()
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim query As String = "
            SELECT p.product_id, p.product_name, p.barcode, p.selling_price, p.cost_price, p.description, 
            p.expiration_option AS expiration_status, c.category_name, p.reorder_point, p.unit_of_measure,
            s.supplier_name, p.is_active,
            IFNULL(SUM(i.current_quantity), 0) AS stock_level
            FROM products p 
            LEFT JOIN categories c ON p.category_id = c.category_id
            LEFT JOIN suppliers s ON p.supplier_id = s.supplier_id
            LEFT JOIN inventory i ON p.product_id = i.product_id
            GROUP BY p.product_id, p.product_name, p.barcode, p.selling_price, p.cost_price, p.description, 
            p.expiration_option, c.category_name, p.reorder_point, p.unit_of_measure, s.supplier_name, p.is_active"

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
            dgvProducts.Columns("supplier_name").HeaderText = "Supplier"
            dgvProducts.Columns("reorder_point").HeaderText = "Reorder Point"
            dgvProducts.Columns("unit_of_measure").HeaderText = "Unit"
            dgvProducts.Columns("stock_level").HeaderText = "Current Stock"
            dgvProducts.Columns("product_id").Visible = False
            dgvProducts.Columns("is_active").Visible = False

            ' Apply conditional formatting to stock level column
            ApplyStockLevelFormatting()

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

    ' Apply conditional formatting to stock levels
    Private Sub ApplyStockLevelFormatting()
        Dim stockColumn As DataGridViewColumn = dgvProducts.Columns("stock_level")

        If stockColumn IsNot Nothing Then
            For Each row As DataGridViewRow In dgvProducts.Rows
                If row.Cells("stock_level").Value IsNot Nothing Then
                    Dim stockValue As Integer = Convert.ToInt32(row.Cells("stock_level").Value)

                    ' Color code based on stock levels
                    If stockValue <= 0 Then
                        ' Out of stock - Red
                        row.Cells("stock_level").Style.ForeColor = Color.White
                        row.Cells("stock_level").Style.BackColor = Color.Red
                    ElseIf stockValue < 10 Then
                        ' Low stock - Orange/Yellow
                        row.Cells("stock_level").Style.ForeColor = Color.Black
                        row.Cells("stock_level").Style.BackColor = Color.Orange
                    Else
                        ' Good stock - Green
                        row.Cells("stock_level").Style.ForeColor = Color.White
                        row.Cells("stock_level").Style.BackColor = Color.Green
                    End If
                End If
            Next
        End If
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

    ' Load Suppliers into ComboBox
    Private Sub LoadSuppliers()
        Try
            If connection.State = ConnectionState.Closed Then connection.Open()
            Dim query As String = "SELECT supplier_id, supplier_name FROM suppliers WHERE status = 'active'"
            Dim cmd As New MySqlCommand(query, connection)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            cmbSuppliers.DataSource = dt
            cmbSuppliers.DisplayMember = "supplier_name"
            cmbSuppliers.ValueMember = "supplier_id"
        Catch ex As Exception
            MessageBox.Show("Error loading suppliers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

        If cmbCategories.SelectedIndex = -1 Then
            MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

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
        INSERT INTO products (product_name, barcode, selling_price, cost_price, description, expiration_option, category_id, supplier_id)
        VALUES (@product_name, @barcode, @selling_price, @cost_price, @description, @expiration_option, @category_id, @supplier_id)"

            ' Create MySQL command and add parameters
            Dim cmd As New MySqlCommand(insertQuery, connection)
            cmd.Parameters.AddWithValue("@product_name", txtProductName.Text)
            cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text)
            cmd.Parameters.AddWithValue("@selling_price", txtSellingPrice.Text)
            cmd.Parameters.AddWithValue("@cost_price", txtCostPrice.Text)
            cmd.Parameters.AddWithValue("@description", txtDescription.Text)
            cmd.Parameters.AddWithValue("@expiration_option", cmbExpirationOption.SelectedItem.ToString)
            cmd.Parameters.AddWithValue("@category_id", cmbCategories.SelectedValue)
            
            ' Add supplier ID parameter
            If cmbSuppliers.SelectedValue IsNot Nothing Then
                cmd.Parameters.AddWithValue("@supplier_id", cmbSuppliers.SelectedValue)
            Else
                cmd.Parameters.AddWithValue("@supplier_id", DBNull.Value)
            End If

            ' Execute insert query
            cmd.ExecuteNonQuery()

            ' Log audit trail for adding the product (include category name if needed)
            Dim categoryName = cmbCategories.SelectedItem.ToString ' Getting the selected category name
            Logaudittrail(role, fullName, "Added product: " & txtProductName.Text)

            ' Show success message
            MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Reload product list and reset form
            LoadProductsAlternate()
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
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
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

            Dim selectQuery = "SELECT product_name, barcode, selling_price, cost_price, description, expiration_option, category_id, supplier_id FROM products WHERE product_id = @product_id"
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
                        originalProduct("supplier_id") = If(reader.IsDBNull(reader.GetOrdinal("supplier_id")), "NULL", reader("supplier_id").ToString)
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
            updatedProduct("supplier_id") = If(cmbSuppliers.SelectedValue IsNot Nothing, cmbSuppliers.SelectedValue.ToString, "NULL")

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
        category_id = @category_id, supplier_id = @supplier_id WHERE product_id = @product_id"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@product_name", txtProductName.Text)
            cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text)
            cmd.Parameters.AddWithValue("@selling_price", txtSellingPrice.Text)
            cmd.Parameters.AddWithValue("@cost_price", txtCostPrice.Text)
            cmd.Parameters.AddWithValue("@description", txtDescription.Text)
            cmd.Parameters.AddWithValue("@expiration_option", cmbExpirationOption.SelectedItem.ToString)
            cmd.Parameters.AddWithValue("@category_id", cmbCategories.SelectedValue)
            
            ' Add supplier ID parameter
            If cmbSuppliers.SelectedValue IsNot Nothing Then
                cmd.Parameters.AddWithValue("@supplier_id", cmbSuppliers.SelectedValue)
            Else
                cmd.Parameters.AddWithValue("@supplier_id", DBNull.Value)
            End If
            
            cmd.Parameters.AddWithValue("@product_id", dgvProducts.CurrentRow.Cells("product_id").Value)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadProductsAlternate()
            ResetForm()

            ' Log detailed changes
            Dim changes = "Edited the product: " & txtProductName.Text & vbCrLf
            For Each key In originalProduct.Keys
                If originalProduct(key) <> updatedProduct(key) Then
                    changes &= $"{key} changed from '{originalProduct(key)}' to '{updatedProduct(key)}'" & vbCrLf
                End If
            Next

            ' Log Audit Trail for Edit Product
            Logaudittrail(role, fullName, changes)

        Catch ex As Exception
            MessageBox.Show("Error updating product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then connection.Close()
        End Try
    End Sub

    ' Delete Product
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvProducts.CurrentRow Is Nothing Then
            MessageBox.Show("Select a product to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Ask for confirmation before deleting
        Dim confirmResult = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmResult = DialogResult.No Then
            Return
        End If

        ' Get the product ID and category name before deletion
        Dim productID As Integer = dgvProducts.CurrentRow.Cells("product_id").Value
        Dim productName = dgvProducts.CurrentRow.Cells("product_name").Value.ToString

        Try
            If connection.State = ConnectionState.Closed Then connection.Open()

            ' Prepare DELETE query
            Dim query = "DELETE FROM products WHERE product_id = @product_id"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@product_id", productID)

            ' Execute the delete command
            cmd.ExecuteNonQuery()

            ' Log the product deletion
            Logaudittrail(role, fullName, "Deleted product: " & productName)

            ' Show success message
            MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Reload product list and reset form
            LoadProductsAlternate()
            ResetForm()
            PanelProduct.Visible = False ' Hide the panel after deletion

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

    Private Sub dgvProducts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellClick
        If e.RowIndex >= 0 Then ' Ensure the click is on a valid row (not on headers)
            Dim selectedRow As DataGridViewRow = dgvProducts.Rows(e.RowIndex)

            ' Check if the row is empty (has no product_id or all cells are empty)
            If selectedRow.Cells("product_id").Value Is Nothing OrElse
               String.IsNullOrEmpty(selectedRow.Cells("product_id").Value.ToString()) Then
                ' Empty row - prepare for adding a new product
                ResetForm()
                PanelProduct.Visible = True
                ' Set button states for new product
                btnSave.Enabled = True
                btnEdit.Enabled = False
                btnDelete.Enabled = False
                ' Hide delivery-related buttons for new products
                btnReceiveDelivery.Visible = False
                btnViewDeliveryHistory.Visible = False
                Return
            End If

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

            ' Set button states for existing product
            btnSave.Enabled = False
            btnEdit.Enabled = True
            btnDelete.Enabled = True

            ' Show delivery-related buttons for existing products
            btnReceiveDelivery.Visible = True
            btnViewDeliveryHistory.Visible = True

            ' Show current stock level
            Dim stockLevel As Integer = Convert.ToInt32(selectedRow.Cells("stock_level").Value)
            lblStockLevel.Text = "Current Stock: " & stockLevel.ToString()

            ' Set stock status indicator
            If stockLevel <= 0 Then
                lblStockStatus.Text = "OUT OF STOCK"
                lblStockStatus.ForeColor = Color.Red
                lblStockStatus.BackColor = Color.LightPink
            ElseIf stockLevel < 10 Then
                lblStockStatus.Text = "LOW STOCK"
                lblStockStatus.ForeColor = Color.Black
                lblStockStatus.BackColor = Color.Yellow
            Else
                lblStockStatus.Text = "IN STOCK"
                lblStockStatus.ForeColor = Color.White
                lblStockStatus.BackColor = Color.Green
            End If

            ' Store selected product ID for later use
            _currentProductId = selectedRow.Cells("product_id").Value

            ' Make sure the panel becomes visible
            PanelProduct.Visible = True
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
        Me.Text = "Product & Inventory Management"
        connection = New MySqlConnection(connectionString)

        ' Set initial button states
        SetInitialButtonStates()

        ' Try the alternative loading method that doesn't use a subquery
        LoadProductsAlternate()

        LoadCategories()
        LoadSuppliers() ' Load suppliers into ComboBox
        LoadExpirationOptions() ' Load expiration options into ComboBox
        CustomizeDataGridView()
    End Sub

    'Private Sub btnAddProduct_Click(sender As Object, e As EventArgs)
    '    PanelProduct.Visible = True
    'End Sub

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

    Private Sub lblBarcode_Click(sender As Object, e As EventArgs) Handles lblBarcode.Click

    End Sub

    Private Sub lblDescription_Click(sender As Object, e As EventArgs) Handles lblDescription.Click

    End Sub

    Private Sub btnExitPanel_Click(sender As Object, e As EventArgs) Handles btnExitPanel.Click
        ' Hide the product panel when exit button is clicked
        PanelProduct.Visible = False

        ' Clear form fields
        ResetForm()
    End Sub

    ' Current selected product ID
    Private _currentProductId As Integer = 0

    ' View Delivery History button click handler
    Private Sub btnViewDeliveryHistory_Click(sender As Object, e As EventArgs) Handles btnViewDeliveryHistory.Click
        If _currentProductId <= 0 Then
            MessageBox.Show("Please select a product first.", "No Product Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Show delivery history for the selected product
        ShowDeliveryHistory(_currentProductId)
    End Sub

    ' Show Delivery History for selected product
    Private Sub ShowDeliveryHistory(productId As Integer)
        Try
            If connection.State = ConnectionState.Closed Then connection.Open()

            ' Use the correct query based on the actual table structure
            Dim query As String = "
            SELECT d.transaction_number, d.delivery_date, s.supplier_name, di.quantity
            FROM delivery_items di
            JOIN deliveries d ON di.delivery_id = d.delivery_id
            JOIN suppliers s ON d.supplier_id = s.supplier_id
            WHERE di.product_id = @product_id
            ORDER BY d.delivery_date DESC"

            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@product_id", productId)

            Dim dt As New DataTable()
            Using adapter As New MySqlDataAdapter(cmd)
                adapter.Fill(dt)
            End Using

            If dt.Rows.Count > 0 Then
                Dim lastDelivery = dt.Rows(0)
                Dim message = $"Last Delivery: {lastDelivery("delivery_date")} by {lastDelivery("supplier_name")}" &
                              Environment.NewLine & $"Quantity: {lastDelivery("quantity")}"

                MessageBox.Show(message, "Recent Delivery Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No delivery history found for this product.", "No History", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error retrieving delivery history: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then connection.Close()
        End Try
    End Sub

    ' Receive Delivery button click handler
    Private Sub btnReceiveDelivery_Click(sender As Object, e As EventArgs) Handles btnReceiveDelivery.Click
        If _currentProductId <= 0 Then
            MessageBox.Show("Please select a product first.", "No Product Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Verify the product exists in the database
        Try
            If connection.State = ConnectionState.Closed Then connection.Open()
            Dim checkProductQuery As String = "SELECT COUNT(*) FROM products WHERE product_id = @product_id"
            Dim checkCmd As New MySqlCommand(checkProductQuery, connection)
            checkCmd.Parameters.AddWithValue("@product_id", _currentProductId)
            Dim productExists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

            If productExists = 0 Then
                MessageBox.Show($"Product with ID {_currentProductId} does not exist in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        Catch ex As Exception
            MessageBox.Show($"Error checking product existence: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Finally
            If connection.State = ConnectionState.Open Then connection.Close()
        End Try

        ' Get the selected product details
        Dim productName As String = txtProductName.Text
        Dim barcode As String = txtBarcode.Text
        Dim category As String = cmbCategories.Text
        Dim currentStock As Integer = Convert.ToInt32(dgvProducts.CurrentRow.Cells("stock_level").Value)
        
        ' Store product details in variables for direct passing
        Dim productId As Integer = _currentProductId

        Try
            ' Open the delivery form and pass product data directly
            Dim deliveryForm As New DeliveryMain(productId, productName, barcode, category, currentStock)
            deliveryForm.ShowInProductContext()
        Catch ex As Exception
            MessageBox.Show($"Error creating delivery form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Method to reload data and reflect inventory changes after a delivery
    Public Sub RefreshAfterDelivery()
        ' Reload the products data using the alternative method
        LoadProductsAlternate()

        ' If the product detail panel is visible and we have a current product ID, update the stock display
        If PanelProduct.Visible AndAlso dgvProducts.CurrentRow IsNot Nothing Then
            Dim stockLevel As Integer = Convert.ToInt32(dgvProducts.CurrentRow.Cells("stock_level").Value)

            ' Update the stock level label
            If lblStockLevel IsNot Nothing Then
                lblStockLevel.Text = "Current Stock: " & stockLevel.ToString()
            End If

            ' Update stock status
            If lblStockStatus IsNot Nothing Then
                If stockLevel <= 0 Then
                    lblStockStatus.Text = "OUT OF STOCK"
                    lblStockStatus.ForeColor = Color.Red
                    lblStockStatus.BackColor = Color.LightPink
                ElseIf stockLevel < 10 Then
                    lblStockStatus.Text = "LOW STOCK"
                    lblStockStatus.ForeColor = Color.Black
                    lblStockStatus.BackColor = Color.Yellow
                Else
                    lblStockStatus.Text = "IN STOCK"
                    lblStockStatus.ForeColor = Color.White
                    lblStockStatus.BackColor = Color.Green
                End If
            End If
        End If
    End Sub

    ' Refresh button click handler
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadProductsAlternate()
        MessageBox.Show("Product data has been refreshed.", "Refresh Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub lblUnitOfMeasure_Click(sender As Object, e As EventArgs) Handles lblUnitOfMeasure.Click

    End Sub

    Private Sub PanelProduct_Paint(sender As Object, e As PaintEventArgs) Handles PanelProduct.Paint

    End Sub

    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged

    End Sub
End Class
