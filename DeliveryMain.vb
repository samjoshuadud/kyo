Imports MySql.Data.MySqlClient

Public Class DeliveryMain
    ' Connection String for the database
    Private connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private connection As MySqlConnection

    ' Flag to indicate if we're in product context mode
    Private _productContextMode As Boolean = False

    ' Constructor for the DeliveryMain Form
    Public Sub New()
        InitializeComponent()

        ' Initialize the form properties
        Me.Text = "Delivery Maintenance"
        Me.Width = 500
        Me.Height = 350
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = ColorTranslator.FromHtml("#B2DFEE") ' Light blue background

        ' Initialize UI components
        ' Initialize the database connection
        connection = New MySqlConnection(connectionString)

        ' Generate the transaction number
        GenerateTransactionNumber()
    End Sub

    ' Show the form in product context (called from ProductMain)
    Public Sub ShowInProductContext()
        ' Set flag to indicate we're in product context mode
        _productContextMode = True

        ' Get the product data from our data transfer object
        Dim productData = ProductDeliveryData.GetInstance()

        ' Set form title to indicate product context
        Me.Text = $"Receive Delivery - {productData.ProductName}"

        ' Display product information in the form
        PopulateProductInfo(productData)

        ' Show the form
        Me.ShowDialog()
    End Sub

    ' Populate the form with product information in product context mode
    Private Sub PopulateProductInfo(productData As ProductDeliveryData)
        ' Create a label to show which product we're receiving
        Dim lblProduct As New Label()
        lblProduct.Text = $"Product: {productData.ProductName} (Barcode: {productData.Barcode})"
        lblProduct.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblProduct.AutoSize = True
        lblProduct.Location = New Point(20, 70)
        Me.Controls.Add(lblProduct)

        ' Add stock level information
        Dim lblStock As New Label()
        lblStock.Text = $"Current Stock: {productData.CurrentStock}"
        lblStock.Font = New Font("Segoe UI", 9)
        lblStock.AutoSize = True
        lblStock.Location = New Point(20, 95)
        Me.Controls.Add(lblStock)

        ' Add quantity field for this specific product
        Dim lblQuantity As New Label()
        lblQuantity.Text = "Quantity to Receive:"
        lblQuantity.AutoSize = True
        lblQuantity.Location = New Point(20, 130)
        Me.Controls.Add(lblQuantity)

        Dim txtQuantity As New TextBox()
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(100, 25)
        txtQuantity.Location = New Point(150, 125)
        txtQuantity.Text = "1" ' Default quantity
        Me.Controls.Add(txtQuantity)

        ' Add unit price field
        Dim lblUnitPrice As New Label()
        lblUnitPrice.Text = "Unit Price:"
        lblUnitPrice.AutoSize = True
        lblUnitPrice.Location = New Point(20, 165)
        Me.Controls.Add(lblUnitPrice)

        Dim txtUnitPrice As New TextBox()
        txtUnitPrice.Name = "txtUnitPrice"
        txtUnitPrice.Size = New Size(100, 25)
        txtUnitPrice.Location = New Point(150, 160)
        Me.Controls.Add(txtUnitPrice)

        ' Add batch number field
        Dim lblBatchNumber As New Label()
        lblBatchNumber.Text = "Batch Number:"
        lblBatchNumber.AutoSize = True
        lblBatchNumber.Location = New Point(20, 200)
        Me.Controls.Add(lblBatchNumber)

        Dim txtBatchNumber As New TextBox()
        txtBatchNumber.Name = "txtBatchNumber"
        txtBatchNumber.Size = New Size(100, 25)
        txtBatchNumber.Location = New Point(150, 195)
        Me.Controls.Add(txtBatchNumber)

        ' Add notes field
        Dim lblNotes As New Label()
        lblNotes.Text = "Notes:"
        lblNotes.AutoSize = True
        lblNotes.Location = New Point(20, 235)
        Me.Controls.Add(lblNotes)

        Dim txtNotes As New TextBox()
        txtNotes.Name = "txtNotes"
        txtNotes.Size = New Size(300, 60)
        txtNotes.Location = New Point(150, 230)
        txtNotes.Multiline = True
        Me.Controls.Add(txtNotes)

        ' Create a "Return to Products" button
        Dim btnReturn As New Button()
        btnReturn.Text = "Return to Products"
        btnReturn.Size = New Size(150, 35)
        btnReturn.Location = New Point(20, 300)
        btnReturn.BackColor = Color.LightGray
        AddHandler btnReturn.Click, AddressOf ReturnToProducts
        Me.Controls.Add(btnReturn)
    End Sub

    ' Return to Products button click handler
    Private Sub ReturnToProducts(sender As Object, e As EventArgs)
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
        ' Validate inputs
        If cmbSupplier.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a supplier.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get quantity from the dynamically created TextBox
        Dim txtQuantity As TextBox = DirectCast(Me.Controls("txtQuantity"), TextBox)
        Dim txtUnitPrice As TextBox = DirectCast(Me.Controls("txtUnitPrice"), TextBox)
        Dim txtBatchNumber As TextBox = DirectCast(Me.Controls("txtBatchNumber"), TextBox)
        Dim txtNotes As TextBox = DirectCast(Me.Controls("txtNotes"), TextBox)

        If String.IsNullOrEmpty(txtQuantity.Text) OrElse Not IsNumeric(txtQuantity.Text) Then
            MessageBox.Show("Please enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrEmpty(txtUnitPrice.Text) OrElse Not IsNumeric(txtUnitPrice.Text) Then
            MessageBox.Show("Please enter a valid unit price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim quantity As Integer = Integer.Parse(txtQuantity.Text)
        Dim unitPrice As Decimal = Decimal.Parse(txtUnitPrice.Text)
        Dim batchNumber As String = If(String.IsNullOrEmpty(txtBatchNumber.Text), Nothing, txtBatchNumber.Text)
        Dim notes As String = If(String.IsNullOrEmpty(txtNotes.Text), Nothing, txtNotes.Text)

        ' Get product data from our data transfer object
        Dim productData = ProductDeliveryData.GetInstance()

        Try
            ' Begin a transaction to ensure data consistency
            If connection.State = ConnectionState.Closed Then connection.Open()
            Dim transaction As MySqlTransaction = connection.BeginTransaction()

            Try
                ' 1. Insert delivery record
                Dim deliveryId As Integer = InsertDeliveryRecord(transaction, notes)

                ' 2. Insert delivery item for the specific product
                InsertDeliveryItem(deliveryId, productData.ProductID, quantity, unitPrice, batchNumber, transaction)

                ' 3. Update inventory record
                UpdateInventory(productData.ProductID, quantity, transaction)

                ' 4. Record stock movement
                RecordStockMovement(productData.ProductID, quantity, "delivery", deliveryId, transaction)

                ' Commit the transaction
                transaction.Commit()

                ' Show success message
                MessageBox.Show($"Delivery of {quantity} units of {productData.ProductName} has been recorded successfully.",
                               "Delivery Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Close the form
                Me.DialogResult = DialogResult.OK
                Me.Close()

            Catch ex As Exception
                ' Rollback transaction on error
                transaction.Rollback()
                Throw ' Re-throw to be caught by the outer catch block
            End Try

        Catch ex As Exception
            MessageBox.Show("Error saving delivery: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        ' Insert into deliveries table
        Dim query As String = "INSERT INTO deliveries (transaction_number, supplier_id, delivery_date, status, notes, received_by) 
                             VALUES (@transaction_number, @supplier_id, @delivery_date, 'received', @notes, @received_by); 
                             SELECT LAST_INSERT_ID();"
        Dim cmd As New MySqlCommand(query, connection, transaction)
        cmd.Parameters.AddWithValue("@transaction_number", lblTransactionNumber.Text)
        cmd.Parameters.AddWithValue("@supplier_id", cmbSupplier.SelectedValue)
        cmd.Parameters.AddWithValue("@delivery_date", dtpDeliveryDate.Value)
        cmd.Parameters.AddWithValue("@notes", If(String.IsNullOrEmpty(notes), DBNull.Value, notes))
        cmd.Parameters.AddWithValue("@received_by", 1) ' TODO: Replace with actual user ID from login

        ' Get the newly inserted delivery_id
        Return Convert.ToInt32(cmd.ExecuteScalar())
    End Function

    ' Helper method to insert delivery item with batch number
    Private Sub InsertDeliveryItem(deliveryId As Integer, productId As Integer, quantity As Integer,
                                 unitPrice As Decimal, batchNumber As String, transaction As MySqlTransaction)
        Dim query As String = "INSERT INTO delivery_items (delivery_id, product_id, quantity, unit_price, batch_number, status) 
                             VALUES (@delivery_id, @product_id, @quantity, @unit_price, @batch_number, 'active')"
        Dim cmd As New MySqlCommand(query, connection, transaction)
        cmd.Parameters.AddWithValue("@delivery_id", deliveryId)
        cmd.Parameters.AddWithValue("@product_id", productId)
        cmd.Parameters.AddWithValue("@quantity", quantity)
        cmd.Parameters.AddWithValue("@unit_price", unitPrice)
        cmd.Parameters.AddWithValue("@batch_number", If(String.IsNullOrEmpty(batchNumber), DBNull.Value, batchNumber))
        cmd.ExecuteNonQuery()
    End Sub

    ' Helper method to record stock movement
    Private Sub RecordStockMovement(productId As Integer, quantity As Integer, movementType As String,
                                  referenceId As Integer, transaction As MySqlTransaction)
        Dim query As String = "INSERT INTO stock_movements (product_id, movement_type, quantity, reference_id, performed_by) 
                             VALUES (@product_id, @movement_type, @quantity, @reference_id, @performed_by)"
        Dim cmd As New MySqlCommand(query, connection, transaction)
        cmd.Parameters.AddWithValue("@product_id", productId)
        cmd.Parameters.AddWithValue("@movement_type", movementType)
        cmd.Parameters.AddWithValue("@quantity", quantity)
        cmd.Parameters.AddWithValue("@reference_id", referenceId.ToString())
        cmd.Parameters.AddWithValue("@performed_by", 1) ' TODO: Replace with actual user ID from login
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
            Dim updateQuery As String = "UPDATE inventory SET quantity = quantity + @quantity WHERE product_id = @product_id"
            Dim updateCmd As New MySqlCommand(updateQuery, connection, transaction)
            updateCmd.Parameters.AddWithValue("@product_id", productId)
            updateCmd.Parameters.AddWithValue("@quantity", quantity)
            updateCmd.ExecuteNonQuery()
        Else
            ' Insert new record
            Dim insertQuery As String = "INSERT INTO inventory (product_id, quantity) VALUES (@product_id, @quantity)"
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
End Class