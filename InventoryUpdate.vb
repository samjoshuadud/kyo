Imports System.Transactions
Imports MySql.Data.MySqlClient
Imports Mysqlx.Crud

Public Class InventoryUpdate
    ' Database Connection String
    Private connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private connection As MySqlConnection

    ' Passed Parameters
    Private transactionNumber As String
    Private supplierName As String
    Private deliveryDate As Date
    Private barcode As String

    ' Product Details
    Public Overloads Property ProductName As String
    Public Property Description As String
    Public Property SellingPrice As Decimal
    Public Property CostPrice As Decimal
    Public Property ExpirationDate As Date
    Public Property CategoryName As String



    ' Constructor for InventoryUpdate Form
    Public Sub New(transactionNumber As String, supplierName As String, deliveryDate As Date, barcode As String)
        InitializeComponent()
        Me.transactionNumber = transactionNumber
        Me.supplierName = supplierName
        Me.deliveryDate = deliveryDate
        Me.barcode = barcode

        ' Initialize Form
        Me.Text = "Inventory Update"
        Me.Width = 800
        Me.Height = 500
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = ColorTranslator.FromHtml("#F5F5F5") ' Light gray background for a professional look

        ' Initialize Database Connection
        connection = New MySqlConnection(connectionString)

        ' Initialize UI Components


        ' Set Barcode Text
        txtBarcode.Text = barcode

        ' Fetch Product Details from Database
        FetchProductDetails()

        ' Dynamically Set Product Details to Labels
        UpdateProductDetails()
    End Sub

    ' Fetch Product Details from the Database
    Private Sub FetchProductDetails()
        ' Ensure the barcode is initialized or passed to the method
        Dim barcode As String = txtBarcode.Text ' Assuming barcode comes from txtBarcode, update as needed.

        ' Check if barcode is not empty or null
        If String.IsNullOrWhiteSpace(barcode) Then
            MessageBox.Show("Please scan or enter a valid barcode.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' Open the connection if it is not already open
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            ' SQL query to fetch product details
            Dim query As String = "
            SELECT p.product_name, p.description, p.selling_price, p.cost_price, p.expiration_date, c.category_name 
            FROM products p
            LEFT JOIN categories c ON p.category_id = c.category_id
            WHERE p.barcode = @barcode;"

            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@barcode", barcode)

            ' Execute the query
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    ' Read values, ensuring null checks for database fields
                    ProductName = reader("product_name").ToString()
                    Description = reader("description").ToString()
                    SellingPrice = Convert.ToDecimal(reader("selling_price"))
                    CostPrice = Convert.ToDecimal(reader("cost_price"))

                    ' Check for null ExpirationDate
                    If reader("expiration_date") IsNot DBNull.Value Then
                        ExpirationDate = Convert.ToDateTime(reader("expiration_date"))
                    Else
                        ExpirationDate = Nothing
                    End If

                    ' Check for null CategoryName
                    If reader("category_name") IsNot DBNull.Value Then
                        CategoryName = reader("category_name").ToString()
                    Else
                        CategoryName = String.Empty ' Or handle appropriately
                    End If
                Else
                    ' Handle case where product is not found
                    MessageBox.Show("Product not found for the provided barcode.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Using

        Catch ex As Exception
            ' Handle any database-related errors
            MessageBox.Show("Error fetching product details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Close the connection if it is open
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub


    Public Sub UpdateProductDetails()
        lblProductName.Text = "Product Name: " & ProductName
        lblDescription.Text = "Description: " & Description
        lblSellingPrice.Text = "Selling Price: " & SellingPrice.ToString("C")
        lblCostPrice.Text = "Cost Price: " & CostPrice.ToString("C")
        lblCategory.Text = "Category: " & CategoryName
    End Sub

    Private Sub BtnSubmit_Click(sender As Object, e As EventArgs)
        ' Disable submit button to prevent double clicks
        btnSubmit.Enabled = False

        ' Validate Inputs
        If Not ValidateInputs() Then
            btnSubmit.Enabled = True
            Exit Sub
        End If

        Dim transaction As MySqlTransaction = Nothing

        Try
            ' Open Database Connection
            connection.Open()

            ' Begin Transaction
            transaction = connection.BeginTransaction()

            ' Get Expiration Date from DateTimePicker
            Dim expirationDate As DateTime = dtpDate.Value

            ' Get Product ID from Barcode
            Dim productId As Integer = GetProductId(barcode)

            If productId <= 0 Then
                MessageBox.Show("Invalid product ID or barcode not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                transaction.Rollback()
                Return
            End If

            ' Debugging Message
            MessageBox.Show("Expiration Date: " & expirationDate.ToString("yyyy-MM-dd"))

            ' Step 1: Insert into Delivery Items
            Dim deliveryItemsQuery As String = "
        INSERT INTO delivery_items (delivery_id, product_id, quantity, expiration_date)
        SELECT d.delivery_id, p.product_id, @quantity, @expiration_date
        FROM deliveries d, products p
        WHERE d.transaction_number = @transaction_number AND p.barcode = @barcode;"

            Dim cmd1 As New MySqlCommand(deliveryItemsQuery, connection, transaction)
            cmd1.Parameters.AddWithValue("@transaction_number", transactionNumber)
            cmd1.Parameters.AddWithValue("@barcode", barcode)
            cmd1.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text))
            cmd1.Parameters.AddWithValue("@expiration_date", expirationDate.ToString("yyyy-MM-dd"))
            cmd1.ExecuteNonQuery()

            ' Step 2: Update Expiration Tracking
            Dim expirationQuery As String = "
        INSERT INTO expiration_tracking (product_id, quantity, expiration_date) 
        VALUES (@product_id, @quantity, @expiration_date)
        ON DUPLICATE KEY UPDATE 
            quantity = quantity + VALUES(quantity);"

            Dim cmd2 As New MySqlCommand(expirationQuery, connection, transaction)
            cmd2.Parameters.AddWithValue("@product_id", productId)
            cmd2.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text))
            cmd2.Parameters.AddWithValue("@expiration_date", expirationDate.ToString("yyyy-MM-dd"))
            cmd2.ExecuteNonQuery()

            ' Step 3: Update Inventory
            Dim inventoryQuery As String = "SELECT current_quantity FROM inventory WHERE product_id = @product_id;"
            Dim cmdCheck As New MySqlCommand(inventoryQuery, connection, transaction)
            cmdCheck.Parameters.AddWithValue("@product_id", productId)
            Dim currentQuantity As Object = cmdCheck.ExecuteScalar()

            If currentQuantity IsNot DBNull.Value AndAlso Convert.ToInt32(currentQuantity) > 0 Then
                ' Update Inventory Quantity with expiration date
                Dim updateInventoryQuery As String = "
            UPDATE inventory
            SET current_quantity = current_quantity + @quantity,
                expiration_date = @expiration_date
            WHERE product_id = @product_id;"

                Dim cmdUpdate As New MySqlCommand(updateInventoryQuery, connection, transaction)
                cmdUpdate.Parameters.AddWithValue("@product_id", productId)
                cmdUpdate.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text))
                cmdUpdate.Parameters.AddWithValue("@expiration_date", expirationDate.ToString("yyyy-MM-dd"))
                cmdUpdate.ExecuteNonQuery()
            Else
                ' Insert New Inventory Record with expiration date
                Dim insertInventoryQuery As String = "
            INSERT INTO inventory (product_id, current_quantity, expiration_date)
            VALUES (@product_id, @quantity, @expiration_date);"

                Dim cmdInsert As New MySqlCommand(insertInventoryQuery, connection, transaction)
                cmdInsert.Parameters.AddWithValue("@product_id", productId)
                cmdInsert.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text))
                cmdInsert.Parameters.AddWithValue("@expiration_date", expirationDate.ToString("yyyy-MM-dd"))
                cmdInsert.ExecuteNonQuery()
            End If

            ' Commit Transaction
            transaction.Commit()

            ' Success Message
            MessageBox.Show("Inventory updated successfully, including expiration tracking!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            Me.Dispose()

        Catch ex As Exception
            ' Rollback Transaction on Error
            Try
                transaction?.Rollback()
            Catch rollbackEx As Exception
                MessageBox.Show("Error rolling back transaction: " & rollbackEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            MessageBox.Show("Error updating inventory: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            ' Enable submit button after process is complete
            btnSubmit.Enabled = True
        End Try
    End Sub


    ' Helper Function to Get Product ID
    Private Function GetProductId(barcode As String) As Integer
        Dim query As String = "SELECT product_id FROM products WHERE barcode = @barcode;"
        Dim cmd As New MySqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@barcode", barcode)
        Return Convert.ToInt32(cmd.ExecuteScalar())
    End Function

    ' Validate Inputs
    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtQuantity.Text) OrElse Not Integer.TryParse(txtQuantity.Text, Nothing) Then
            MessageBox.Show("Please enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Sub InventoryUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateProductDetails()
    End Sub
End Class