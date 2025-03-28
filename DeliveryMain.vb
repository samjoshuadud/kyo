Imports MySql.Data.MySqlClient

Public Class DeliveryMain
    ' Connection String for the database
    Private connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private connection As MySqlConnection

    ' Flag to indicate if we're in product context mode
    Private _productContextMode As Boolean = False
    
    ' Store the product ID directly in the class
    Private _productId As Integer = 0

    ' Constructor for the DeliveryMain Form with direct product data
    Public Sub New(productId As Integer, productName As String, barcode As String, category As String, stock As Integer)
        InitializeComponent()

        ' Debug the incoming parameters
        MessageBox.Show($"Constructor received: Product ID={productId}, Name={productName}", "Debug Constructor")

        ' Store the product ID directly in this instance
        _productId = productId

        ' Initialize the form properties
        Me.Text = $"Receive Delivery - {productName}"
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.MinimumSize = New Size(500, 600)
        Me.MaximumSize = New Size(800, 800)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = ColorTranslator.FromHtml("#B2DFEE") ' Light blue background
        Me.AutoScroll = True

        ' Ensure valid product ID
        If productId <= 0 Then
            MessageBox.Show($"Invalid product ID: {productId}. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Return
        End If

        ' Set product context mode flag
        _productContextMode = True

        ' Initialize the database connection
        connection = New MySqlConnection(connectionString)

        ' Generate the transaction number
        GenerateTransactionNumber()
        
        ' Get the expiration option directly from the database
        Try
            If connection.State = ConnectionState.Closed Then connection.Open()
            
            ' Verify product exists
            Dim verifyQuery As String = "SELECT COUNT(*) FROM products WHERE product_id = @product_id"
            Dim verifyCmd As New MySqlCommand(verifyQuery, connection)
            verifyCmd.Parameters.AddWithValue("@product_id", productId)
            Dim productExists As Integer = Convert.ToInt32(verifyCmd.ExecuteScalar())
            
            If productExists = 0 Then
                MessageBox.Show($"Product with ID {productId} does not exist in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
                Return
            End If
            
            ' Get expiration option
            Dim query As String = "SELECT expiration_option FROM products WHERE product_id = @product_id"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@product_id", productId)
            Dim expirationOption As String = cmd.ExecuteScalar().ToString()

            MessageBox.Show($"Database Expiration Option: '{expirationOption}' for Product ID: {productId}", "Debug Database Value")

            ' Update the singleton with the database value
            Dim dataTransfer As ProductDeliveryData = ProductDeliveryData.GetInstance()
            dataTransfer.SetProductDetails(productId, productName, barcode, category, expirationOption)
            dataTransfer.CurrentStock = stock

            ' Set product data in the form
            lblProduct.Text = $"Product: {productName} (Barcode: {barcode})"
            lblProduct.Visible = True

            lblStock.Text = $"Current Stock: {stock}"
            lblStock.Visible = True

            lblQuantity.Visible = True
            txtQuantity.Text = "1"
            txtQuantity.Visible = True

            lblUnitPrice.Visible = True
            txtUnitPrice.Visible = True

            lblBatchNumber.Visible = True
            txtBatchNumber.Visible = True

            lblNotes.Visible = True
            txtNotes.Visible = True

            btnReturn.Visible = True

            ' Show/hide expiration date based on the database value
            If expirationOption.Trim() = "With Expiration" Then
                lblExpirationDate.Visible = True
                dtpExpirationDate.Visible = True
                dtpExpirationDate.MinDate = DateTime.Now.Date
            Else
                lblExpirationDate.Visible = False
                dtpExpirationDate.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show($"Error in DeliveryMain constructor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        Finally
            If connection.State = ConnectionState.Open Then connection.Close()
        End Try
    End Sub

    ' Default constructor for the DeliveryMain Form
    Public Sub New()
        InitializeComponent()

        ' Initialize the form properties
        Me.Text = "Delivery Maintenance"
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.MinimumSize = New Size(500, 600)
        Me.MaximumSize = New Size(800, 800)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = ColorTranslator.FromHtml("#B2DFEE") ' Light blue background
        Me.AutoScroll = True

        ' Initialize the database connection
        connection = New MySqlConnection(connectionString)

        ' Generate the transaction number
        GenerateTransactionNumber()
    End Sub

    ' Show the form in product context (called from ProductMain)
    Public Sub ShowInProductContext()
        ' This method assumes the form was created with the overloaded constructor
        ' that already passed in all the product data
        
        ' Make sure we're in product context mode (should have been set in constructor)
        If Not _productContextMode Then
            ' Get the product data from our data transfer object as a fallback
            Dim productData = ProductDeliveryData.GetInstance()
            
            ' Verify that we have a valid product ID before proceeding
            If productData.ProductID <= 0 Then
                MessageBox.Show($"Product ID is invalid (ID: {productData.ProductID}). This may be because the data wasn't properly passed from the Products screen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Return
            End If

            ' Display product information in the form
            PopulateProductInfo(productData)
            
            ' Set flag to indicate we're in product context mode
            _productContextMode = True
        End If

        ' Show the form
        Me.ShowDialog()
    End Sub

    ' Populate the form with product information in product context mode
    Private Sub PopulateProductInfo(productData As ProductDeliveryData)
        ' Update product information
        lblProduct.Text = $"Product: {productData.ProductName} (Barcode: {productData.Barcode})"
        lblProduct.Visible = True

        ' Update stock information
        lblStock.Text = $"Current Stock: {productData.CurrentStock}"
        lblStock.Visible = True

        ' Show quantity field
        lblQuantity.Visible = True
        txtQuantity.Text = "1"
        txtQuantity.Visible = True

        ' Show unit price field
        lblUnitPrice.Visible = True
        txtUnitPrice.Visible = True

        ' Show batch number field
        lblBatchNumber.Visible = True
        txtBatchNumber.Visible = True

        ' Show notes field
        lblNotes.Visible = True
        txtNotes.Visible = True

        ' Show return button
        btnReturn.Visible = True

        ' Check if product has expiration
        MessageBox.Show($"Product Expiration Option: '{productData.ExpirationOption}'", "Debug Info")
        If productData.ExpirationOption.Trim() = "With Expiration" Then
            lblExpirationDate.Visible = True
            dtpExpirationDate.Visible = True
            dtpExpirationDate.MinDate = DateTime.Now.Date
        Else
            lblExpirationDate.Visible = False
            dtpExpirationDate.Visible = False
        End If

        ' Make sure all controls are properly enabled
        txtQuantity.Enabled = True
        txtUnitPrice.Enabled = True
        txtBatchNumber.Enabled = True
        txtNotes.Enabled = True
        btnReturn.Enabled = True
    End Sub

    ' Return to Products button click handler
    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        ' Close this form and return to ProductMain
        Me.Close()
    End Sub

    ' Override Save button behavior based on context
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Check if we're in product context mode
        If _productContextMode Then
            SaveProductDelivery()
        Else
            ' Original save logic for normal delivery mode
            SaveRegularDelivery()
        End If
    End Sub

    ' Save product-specific delivery (when coming from ProductMain)
    Private Sub SaveProductDelivery()
        ' Debug message to trace execution flow
        MessageBox.Show("Starting SaveProductDelivery method", "Debug")
        
        ' Validate inputs
        If cmbSupplier.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a supplier.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get quantity and other inputs
        If String.IsNullOrEmpty(txtQuantity.Text) OrElse Not IsNumeric(txtQuantity.Text) Then
            MessageBox.Show("Please enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrEmpty(txtUnitPrice.Text) OrElse Not IsNumeric(txtUnitPrice.Text) Then
            MessageBox.Show("Please enter a valid unit price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get product data from our data transfer object for name and other details
        Dim productData = ProductDeliveryData.GetInstance()
        
        ' Debug the product data from singleton and our stored ID
        MessageBox.Show($"Product data: Singleton ID={productData.ProductID}, Direct ID={_productId}, Name={productData.ProductName}", "Debug Product IDs")
        
        ' Use our stored product ID which was passed directly in the constructor
        Dim productId As Integer = _productId
        
        ' Validate that we have a valid product ID
        If productId <= 0 Then
            MessageBox.Show($"Invalid product ID: {productId}. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Verify product exists in database before proceeding
        Try
            If connection.State = ConnectionState.Closed Then connection.Open()
            Dim checkQuery As String = "SELECT COUNT(*) FROM products WHERE product_id = @product_id"
            Dim checkCmd As New MySqlCommand(checkQuery, connection)
            checkCmd.Parameters.AddWithValue("@product_id", productId)
            Dim productExists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

            If productExists = 0 Then
                MessageBox.Show($"Product with ID {productId} does not exist in the database. Product Name: {productData.ProductName}, Barcode: {productData.Barcode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            
            ' Debug: confirm product exists
            MessageBox.Show($"Product with ID {productId} exists in the database", "Debug Product Exists")
            
        Catch ex As Exception
            MessageBox.Show($"Error checking product existence: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        Dim quantity As Integer = Integer.Parse(txtQuantity.Text)
        Dim unitPrice As Decimal = Decimal.Parse(txtUnitPrice.Text)
        Dim batchNumber As String = If(String.IsNullOrEmpty(txtBatchNumber.Text), Nothing, txtBatchNumber.Text)
        Dim notes As String = If(String.IsNullOrEmpty(txtNotes.Text), Nothing, txtNotes.Text)

        Try
            ' Begin a transaction to ensure data consistency
            If connection.State = ConnectionState.Closed Then connection.Open()
            Dim transaction As MySqlTransaction = connection.BeginTransaction()

            Try
                ' 1. Insert delivery record
                Dim deliveryId As Integer = InsertDeliveryRecord(transaction, notes)
                MessageBox.Show($"Created delivery record with ID: {deliveryId}", "Debug")

                ' 2. Insert delivery item for the specific product
                InsertDeliveryItem(deliveryId, productId, quantity, unitPrice, batchNumber, transaction)
                MessageBox.Show("Inserted delivery item", "Debug")

                ' 3. Update inventory record
                UpdateInventory(productId, quantity, transaction)
                MessageBox.Show("Updated inventory", "Debug")

                ' 4. Record stock movement
                RecordStockMovement(productId, quantity, "delivery", deliveryId, transaction)
                MessageBox.Show("Recorded stock movement", "Debug")

                ' Commit the transaction
                transaction.Commit()
                MessageBox.Show("Transaction committed successfully", "Debug")

                ' Show success message
                MessageBox.Show($"Delivery of {quantity} units of {productData.ProductName} has been recorded successfully.",
                               "Delivery Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Close the form
                Me.DialogResult = DialogResult.OK
                Me.Close()

            Catch ex As Exception
                ' Rollback transaction on error
                transaction.Rollback()
                MessageBox.Show($"Error during transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Catch ex As Exception
            MessageBox.Show($"Error saving delivery: {ex.Message}{Environment.NewLine}Product ID: {productId}{Environment.NewLine}Product Name: {productData.ProductName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then connection.Close()
        End Try
    End Sub

    ' Original save method renamed
    Private Sub SaveRegularDelivery()
        ' Validate inputs
        If cmbSupplier.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a supplier.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate if the delivery date is not in the future
        If dtpDeliveryDate.Value.Date > DateTime.Now.Date Then
            MessageBox.Show("The delivery date cannot be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' Ensure the connection is initialized
            If connection.State = ConnectionState.Open Then connection.Close()
            connection.Open()

            ' Check if a record with the same transaction number already exists
            Dim checkQuery As String = "SELECT COUNT(*) FROM deliveries WHERE transaction_number = @transaction_number"
            Dim checkCmd As New MySqlCommand(checkQuery, connection)
            checkCmd.Parameters.AddWithValue("@transaction_number", lblTransactionNumber.Text)
            Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

            If count > 0 Then
                MessageBox.Show("A delivery with this transaction number already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Query to insert delivery data
            Dim query As String = "INSERT INTO deliveries (transaction_number, supplier_id, delivery_date) VALUES (@transaction_number, @supplier_id, @delivery_date)"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@transaction_number", lblTransactionNumber.Text)
            cmd.Parameters.AddWithValue("@supplier_id", cmbSupplier.SelectedValue)
            cmd.Parameters.AddWithValue("@delivery_date", dtpDeliveryDate.Value)
            cmd.ExecuteNonQuery()

            ' Display success message
            MessageBox.Show("Delivery saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Hide the current form
            Me.Hide()

            ' Open Product Scanning Form and pass the required data
            Dim scanForm As New ProductScan(lblTransactionNumber.Text, cmbSupplier.Text, dtpDeliveryDate.Value)
            scanForm.ShowDialog()

            ' Open InventoryMain Form at position (211, 3)
            Dim inventoryForm As New InventoryMain()
            inventoryForm.Location = New Point(211, 3) ' Set position
            inventoryForm.Show()

            ' Close the current form after both are opened
            Me.Close()

        Catch ex As Exception
            ' Display error message if something goes wrong
            MessageBox.Show("Error saving delivery: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Close the database connection
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    ' Helper method to insert delivery record with notes
    Private Function InsertDeliveryRecord(transaction As MySqlTransaction, notes As String) As Integer
        ' Insert into deliveries table without received_by field
        Dim query As String = "INSERT INTO deliveries (transaction_number, supplier_id, delivery_date, status, notes) 
                             VALUES (@transaction_number, @supplier_id, @delivery_date, 'received', @notes); 
                             SELECT LAST_INSERT_ID();"
        Dim cmd As New MySqlCommand(query, connection, transaction)
        cmd.Parameters.AddWithValue("@transaction_number", lblTransactionNumber.Text)
        cmd.Parameters.AddWithValue("@supplier_id", cmbSupplier.SelectedValue)
        cmd.Parameters.AddWithValue("@delivery_date", dtpDeliveryDate.Value)
        cmd.Parameters.AddWithValue("@notes", If(String.IsNullOrEmpty(notes), DBNull.Value, notes))

        ' Get the newly inserted delivery_id
        Return Convert.ToInt32(cmd.ExecuteScalar())
    End Function

    ' Helper method to insert delivery item with batch number
    Private Sub InsertDeliveryItem(deliveryId As Integer, productId As Integer, quantity As Integer,
                                 unitPrice As Decimal, batchNumber As String, transaction As MySqlTransaction)
        ' First verify that the product exists
        Dim checkQuery As String = "SELECT COUNT(*) FROM products WHERE product_id = @product_id"
        Dim checkCmd As New MySqlCommand(checkQuery, connection, transaction)
        checkCmd.Parameters.AddWithValue("@product_id", productId)
        Dim productExists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

        If productExists = 0 Then
            Throw New Exception($"Product with ID {productId} does not exist.")
        End If

        ' If product exists, proceed with insertion
        Dim query As String = "INSERT INTO delivery_items (delivery_id, product_id, quantity, unit_price, batch_number, status, expiration_date) 
                             VALUES (@delivery_id, @product_id, @quantity, @unit_price, @batch_number, 'active', @expiration_date)"
        Dim cmd As New MySqlCommand(query, connection, transaction)
        cmd.Parameters.AddWithValue("@delivery_id", deliveryId)
        cmd.Parameters.AddWithValue("@product_id", productId)
        cmd.Parameters.AddWithValue("@quantity", quantity)
        cmd.Parameters.AddWithValue("@unit_price", unitPrice)
        cmd.Parameters.AddWithValue("@batch_number", If(String.IsNullOrEmpty(batchNumber), DBNull.Value, batchNumber))
        
        ' Add expiration date if product has expiration
        If dtpExpirationDate.Visible Then
            cmd.Parameters.AddWithValue("@expiration_date", dtpExpirationDate.Value)
        Else
            cmd.Parameters.AddWithValue("@expiration_date", DBNull.Value)
        End If
        
        cmd.ExecuteNonQuery()
    End Sub

    ' Helper method to record stock movement
    Private Sub RecordStockMovement(productId As Integer, quantity As Integer, movementType As String,
                                  referenceId As Integer, transaction As MySqlTransaction)
        Dim query As String = "INSERT INTO stock_movements (product_id, movement_type, quantity, reference_id) 
                             VALUES (@product_id, @movement_type, @quantity, @reference_id)"
        Dim cmd As New MySqlCommand(query, connection, transaction)
        cmd.Parameters.AddWithValue("@product_id", productId)
        cmd.Parameters.AddWithValue("@movement_type", movementType)
        cmd.Parameters.AddWithValue("@quantity", quantity)
        cmd.Parameters.AddWithValue("@reference_id", referenceId.ToString())
        cmd.ExecuteNonQuery()
    End Sub

    ' Helper method to update inventory
    Private Sub UpdateInventory(productId As Integer, quantity As Integer, transaction As MySqlTransaction)
        ' Check if inventory record exists for this product
        Dim checkQuery As String = "SELECT COUNT(*) FROM inventory WHERE product_id = @product_id"
        Dim checkCmd As New MySqlCommand(checkQuery, connection, transaction)
        checkCmd.Parameters.AddWithValue("@product_id", productId)
        Dim recordExists As Boolean = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0

        If recordExists Then
            ' Update existing record
            Dim updateQuery As String = "UPDATE inventory SET current_quantity = current_quantity + @quantity WHERE product_id = @product_id"
            Dim updateCmd As New MySqlCommand(updateQuery, connection, transaction)
            updateCmd.Parameters.AddWithValue("@product_id", productId)
            updateCmd.Parameters.AddWithValue("@quantity", quantity)
            updateCmd.ExecuteNonQuery()
        Else
            ' Insert new record
            Dim insertQuery As String = "INSERT INTO inventory (product_id, current_quantity) VALUES (@product_id, @quantity)"
            Dim insertCmd As New MySqlCommand(insertQuery, connection, transaction)
            insertCmd.Parameters.AddWithValue("@product_id", productId)
            insertCmd.Parameters.AddWithValue("@quantity", quantity)
            insertCmd.ExecuteNonQuery()
        End If
    End Sub

    ' Generate a Unique Transaction Number
    Private Sub GenerateTransactionNumber()
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            ' Generate a unique transaction number based on the current timestamp
            Dim timestamp As String = DateTime.Now.ToString("yyyyMMddHHmmss")
            Dim query As String = "SELECT COUNT(*) FROM deliveries WHERE transaction_number LIKE @baseNumber"
            Dim baseTransactionNumber As String = "TRX-" & timestamp

            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@baseNumber", baseTransactionNumber & "%")
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            ' Append a suffix if duplicates are found
            Dim uniqueTransactionNumber As String = baseTransactionNumber
            If count > 0 Then
                uniqueTransactionNumber &= "-" & (count + 1).ToString()
            End If

            lblTransactionNumber.Text = uniqueTransactionNumber
        Catch ex As Exception
            MessageBox.Show("Error generating transaction number: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    ' Load Suppliers from Database into ComboBox
    Private Sub LoadSuppliers()
        Try
            ' Ensure the connection is initialized
            If connection Is Nothing Then
                connection = New MySqlConnection(connectionString)
            End If

            ' Open the database connection
            If connection.State <> ConnectionState.Open Then
                connection.Open()
            End If

            ' Query to get supplier details
            Dim query As String = "SELECT supplier_id, supplier_name FROM suppliers"
            Dim cmd As New MySqlCommand(query, connection)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            ' Bind data to ComboBox
            cmbSupplier.DataSource = dt
            cmbSupplier.DisplayMember = "supplier_name"
            cmbSupplier.ValueMember = "supplier_id"

        Catch ex As Exception
            ' Display error message if something goes wrong
            MessageBox.Show("Error loading suppliers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Close the database connection
            If connection IsNot Nothing AndAlso connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub DeliveryMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSuppliers()
    End Sub

    ' Close button click handler
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class