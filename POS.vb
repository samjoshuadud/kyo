Imports Emgu.CV.Features2D
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Drawing.Printing
Imports System.Text

Public Class POS
    Inherits Form

    ' UI Controls

    ' Add this declaration at the top of the class
    Private lastScanTime As DateTime = DateTime.Now

    ' Database Helper
    Private dbHelper As DatabaseHelper = DatabaseHelper.Instance
    Private cart As DataTable ' To store cart items in memory
    Private transactionNumber As String

    ' Cashier Information
    Private CurrentCashierId As Integer

    Private role As String

    ' Constructor
    Public Sub New(userRole As String)
        role = userRole
        InitializeComponent() ' Automatically initializes the designer elements

    End Sub

    ' Constructor
    Public Sub New(cashierId As Integer)
        InitializeComponent()
        Me.CurrentCashierId = cashierId
        ' Initialize UI and backend
        GenerateTransactionNumber()
        InitializeCashierDetails()
    End Sub


    ' Add Edit and Delete Image Columns
    Private Sub AddImageColumns()
        ' Delete column
        Dim deleteColumn As New DataGridViewImageColumn()
        deleteColumn.HeaderText = ""
        deleteColumn.Name = "Delete"
        'deleteColumn.Image = Image.FromFile("C:\Path\To\Trash.png") ' Update with actual path
        deleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dgvCart.Columns.Insert(0, deleteColumn) ' Insert at first position

        ' Edit column
        Dim editColumn As New DataGridViewImageColumn()
        editColumn.HeaderText = ""
        editColumn.Name = "Edit"
        'editColumn.Image = Image.FromFile("C:\Path\To\Edit.png") ' Update with actual path
        editColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dgvCart.Columns.Insert(1, editColumn) ' Insert at second position
    End Sub

    ' Customize DataGridView appearance

    ' Initialize Cart
    Private Sub InitializeCart()
        If cart Is Nothing Then
            ' Initialize DataTable with necessary columns
            cart = New DataTable()
            cart.Columns.Add("#", GetType(Integer))
            cart.Columns.Add("Barcode", GetType(String))
            cart.Columns.Add("ItemName", GetType(String))
            cart.Columns.Add("Quantity", GetType(Integer))
            cart.Columns.Add("UnitPrice", GetType(Decimal))
            cart.Columns.Add("Discount", GetType(Decimal))
            cart.Columns.Add("Total", GetType(Decimal))

            ' Bind cart DataTable to DataGridView
            dgvCart.DataSource = cart

            ' Move this part AFTER setting DataSource
            AddImageColumns()

            ' Customize DataGridView appearance
            CustomizeDataGridView()
        End If
    End Sub


    ' Customize DataGridView appearance
    Private Sub CustomizeDataGridView()
        With dgvCart
            ' Header Styles
            .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Regular)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Cell Styles
            .DefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False ' Prevent text wrapping
            .GridColor = Color.LightBlue
            .CellBorderStyle = DataGridViewCellBorderStyle.Single

            ' Row Settings
            .RowTemplate.Height = 40
            .RowHeadersVisible = False

            ' Auto-size columns but keep fixed width for images
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        End With
    End Sub



    Private Sub InitializeDate()
        Try
            ' Set the label to show the current date in the desired format
            lblDate.Text = $"Date: {DateTime.Now.ToString("MMMM dd, yyyy")}"
        Catch ex As Exception
            MessageBox.Show($"Error fetching date: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' Fetch and Display Cashier Details
    Private Sub InitializeCashierDetails()
        Try
            Dim query As String = "SELECT full_name, role FROM users WHERE user_id = @userId"
            Dim parameters As MySqlParameter() = {New MySqlParameter("@userId", CurrentCashierId)}
            Dim userData As DataTable = dbHelper.ExecuteQuery(query, parameters)

            If userData.Rows.Count > 0 Then
                Dim fullName As String = userData.Rows(0)("full_name").ToString()
                Dim role As String = userData.Rows(0)("role").ToString()
                lblCashier.Text = $" {fullName} ({role})"
            Else
                Throw New Exception("User details not found!")
            End If
        Catch ex As Exception
            MessageBox.Show($"Error fetching user details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    ' Generate Transaction Number
    Private Sub GenerateTransactionNumber()
        transactionNumber = "TXN-" & DateTime.Now.ToString("yyyyMMddHHmmss")
        lblTransactionNumber.Text = "Transaction #: " & transactionNumber
    End Sub

    ' Add Item to Cart
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtBarcode.Text) Then
            MessageBox.Show("Please enter a barcode.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
            Dim productId As Integer = GetProductId(txtBarcode.Text)
            If Not IsProductDelivered(productId) Then
                MessageBox.Show("This product has not been delivered yet. Please update the delivery records first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

        End If

        AddToCart(txtBarcode.Text.Trim())
    End Sub

    Private Sub AddToCart(barcode As String)
        If String.IsNullOrWhiteSpace(barcode) Then 
            MessageBox.Show("Please enter a valid barcode.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return 
        End If

        ' Initialize the cart DataTable if it's not already done
        If cart Is Nothing Then InitializeCart()

        Try
            ' Improved query to fetch product details based on the scanned barcode
            ' Use LEFT JOIN instead of INNER JOIN to avoid missing products that haven't been delivered yet
            Dim query As String = "SELECT p.product_id, p.product_name, p.selling_price, IFNULL(i.current_quantity, 0) as current_quantity 
                               FROM products p
                               LEFT JOIN inventory i ON p.product_id = i.product_id
                               WHERE p.barcode = @barcode"
            Dim parameters As MySqlParameter() = {New MySqlParameter("@barcode", barcode)}
            Dim productTable As DataTable = dbHelper.ExecuteQuery(query, parameters)

            ' Check if product exists
            If productTable.Rows.Count = 0 Then
                MessageBox.Show("Product not found. Please verify the barcode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Extract product details from the database result
            Dim productId As Integer = Convert.ToInt32(productTable.Rows(0)("product_id"))
            Dim productName As String = productTable.Rows(0)("product_name").ToString()
            Dim unitPrice As Decimal = Convert.ToDecimal(productTable.Rows(0)("selling_price"))
            Dim availableQuantity As Integer = Convert.ToInt32(productTable.Rows(0)("current_quantity"))
            Dim discount As Decimal = 0 ' Add discount logic if needed

            ' Check if the product has been delivered before allowing sale
            If Not IsProductDelivered(productId) Then
                MessageBox.Show("This product has not been delivered yet. Please update the delivery records first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Get the manual quantity from the txtQuantity TextBox or set default to 1
            Dim manualQuantity As Integer = 1
            If Not String.IsNullOrWhiteSpace(txtQuantity.Text) AndAlso Integer.TryParse(txtQuantity.Text, manualQuantity) Then
                ' Validate that quantity is greater than zero
                If manualQuantity <= 0 Then
                    MessageBox.Show("Quantity must be greater than zero.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End If

            ' Check if the requested quantity exceeds the available quantity in inventory
            If manualQuantity > availableQuantity Then
                MessageBox.Show("Insufficient stock. Only " & availableQuantity.ToString() & " items are available.", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Check if the product already exists in the cart (by barcode)
            Dim existingRow = cart.AsEnumerable().FirstOrDefault(Function(row) row.Field(Of String)("Barcode") = barcode)
            If existingRow IsNot Nothing Then
                ' If the product exists, increment the quantity and update the total
                Dim newQuantity As Integer = existingRow("Quantity") + manualQuantity
                
                ' Additional check to ensure we don't exceed stock even when adding to existing items
                If newQuantity > availableQuantity Then
                    MessageBox.Show("Insufficient stock. Cannot add " & manualQuantity & " more items. Only " & (availableQuantity - existingRow("Quantity")) & " additional items can be added.", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                
                existingRow("Quantity") = newQuantity
                existingRow("Total") = newQuantity * existingRow("UnitPrice")
            Else
                ' If the product is not yet in the cart, add a new row
                Dim rowIndex As Integer = cart.Rows.Count + 1
                cart.Rows.Add(rowIndex, barcode, productName, manualQuantity, unitPrice, discount, manualQuantity * unitPrice)
            End If

            ' Refresh the DataGridView to show the updated cart
            dgvCart.DataSource = Nothing
            dgvCart.DataSource = cart
            AddImageColumns() ' Add image columns again after rebinding

            ' Update the cart summary, such as total price, item count, etc.
            UpdateCartSummary()

            ' Clear the quantity input after adding the product to the cart
            txtQuantity.Clear()
            txtBarcode.Clear()
            txtBarcode.Focus() ' Set focus back to barcode for next scan

        Catch ex As Exception
            MessageBox.Show("Error adding item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function IsProductDelivered(productId As Integer) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM delivery_items WHERE product_id = @product_id"
        Dim parameters As MySqlParameter() = {New MySqlParameter("@product_id", productId)}

        Try
            Dim count As Integer = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters))
            Return count > 0
        Catch ex As Exception
            MessageBox.Show("Error checking product delivery status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' Clear Cart
    Private Sub BtnClearCart_Click(sender As Object, e As EventArgs) Handles btnClearcart.Click
        cart.Clear()
        UpdateCartSummary()
        GenerateTransactionNumber()

    End Sub

    ' Process Payment

    Public Class Sale
        Public ID As Integer
        Public Quantity As Integer
    End Class

    Private Sub BtnProcessPayment_Click(sender As Object, e As EventArgs) Handles btnProcessPayment.Click
        ' Check if cart is empty
        If cart Is Nothing OrElse cart.Rows.Count = 0 Then
            MessageBox.Show("Cart is empty. Please add items before processing payment.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim amountPaid As Decimal

        ' Validate the amount paid
        If Not Decimal.TryParse(txtAmountPaid.Text, amountPaid) Then
            MessageBox.Show("Please enter a valid amount.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        
        ' Calculate total amount and discount
        Dim totalAmount As Decimal = Convert.ToDecimal(lblTotal.Text)
        Dim discountRate As Decimal = 0
        
        ' Get the selected discount only if a selection was made
        If cmbDiscount.SelectedItem IsNot Nothing Then
            discountRate = Convert.ToDecimal(CType(cmbDiscount.SelectedItem, DataRowView)("discount_rate")) / 100
        End If
        
        Dim discountAmount As Decimal = totalAmount * discountRate
        Dim netAmount As Decimal = totalAmount - discountAmount
        
        ' Check if amount paid is sufficient
        If amountPaid < netAmount Then
            MessageBox.Show($"Insufficient amount paid. Required: {netAmount:C}", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Update UI for discount and total
        lblDiscount.Text = discountAmount.ToString("0.00")
        lblTotal.Text = netAmount.ToString("0.00")

        ' Validate stock availability for all items before proceeding
        For Each row As DataRow In cart.Rows
            Dim productId = GetProductId(row("Barcode").ToString())
            Dim quantityRequested = Convert.ToInt32(row("Quantity"))

            ' Check stock availability
            Dim stockQuery = "SELECT current_quantity FROM inventory WHERE product_id = @product_id"
            Dim stockParams = {New MySqlParameter("@product_id", productId)}
            Dim result = dbHelper.ExecuteScalar(stockQuery, stockParams)
            
            If result Is Nothing Then
                MessageBox.Show($"Product '{row("ItemName").ToString()}' is not in inventory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            
            Dim currentStock = Convert.ToInt32(result)

            If quantityRequested > currentStock Then
                MessageBox.Show($"Insufficient stock for product: {row("ItemName").ToString()}. Only {currentStock} available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ' Exit the process if stock is insufficient
            End If
        Next

        ' Calculate the change
        Dim change = amountPaid - netAmount
        lblChange.Text = change.ToString("0.00")

        ' Generate receipt number
        Dim receiptNumber = "RCP-" & DateTime.Now.ToString("yyyyMMddHHmmss")

        Try
            dbHelper.BeginTransaction()

            ' Insert the sale details into the sales table
            Dim saleQuery = "INSERT INTO sales (transaction_number, sale_date, cashier_id, total_amount, discount_amount, vat_amount, net_amount) 
                                 VALUES (@transaction_number, NOW(), @cashier_id, @total_amount, @discount_amount, @vat_amount, @net_amount)"
            Dim saleParams = {
                New MySqlParameter("@transaction_number", transactionNumber),
                New MySqlParameter("@cashier_id", CurrentCashierId),
                New MySqlParameter("@total_amount", totalAmount),
                New MySqlParameter("@discount_amount", discountAmount),
                New MySqlParameter("@vat_amount", Convert.ToDecimal(lblVAT.Text)), 
                New MySqlParameter("@net_amount", netAmount)
            }
            dbHelper.ExecuteNonQuery(saleQuery, saleParams)

            ' Get the Sale ID for sale_items
            Dim saleIdQuery = "SELECT LAST_INSERT_ID()"
            Dim saleId = Convert.ToInt32(dbHelper.ExecuteScalar(saleIdQuery))

            ' Declare and initialize the 'order' dictionary to store product IDs and their quantities
            Dim order As New Dictionary(Of Integer, Integer)

            ' Prepare Order Data
            For Each row As DataRow In cart.Rows
                Dim productId = GetProductId(row("Barcode").ToString())
                Dim quantity = Convert.ToInt32(row("Quantity"))

                ' Insert into Sale Items Table
                Dim itemQuery = "INSERT INTO sale_items (sale_id, product_id, quantity, unit_price, total_price) 
                                   VALUES (@sale_id, @product_id, @quantity, @unit_price, @total_price)"
                Dim itemParams = {
                    New MySqlParameter("@sale_id", saleId),
                    New MySqlParameter("@product_id", productId),
                    New MySqlParameter("@quantity", quantity),
                    New MySqlParameter("@unit_price", row("UnitPrice")),
                    New MySqlParameter("@total_price", row("Total"))
                }
                dbHelper.ExecuteNonQuery(itemQuery, itemParams)

                ' Add product to the order dictionary
                If order.ContainsKey(productId) Then
                    order(productId) += quantity ' Sum quantities if the product is already in the dictionary
                Else
                    order.Add(productId, quantity)
                End If
            Next

            ' Update Inventory and Expiration Tracking
            UpdateInventory(order)
            UpdateExpirationTracking(order)
            
            ' Record the transaction in audit trail
            Dim auditQuery = "INSERT INTO audittrail (Role, FullName, Action, Form, Date) VALUES (@role, @fullName, @action, @form, NOW())"
            Dim auditParams = {
                New MySqlParameter("@role", "Cashier"),
                New MySqlParameter("@fullName", lblCashier.Text.Trim()),
                New MySqlParameter("@action", $"Processed sale: {transactionNumber}, Receipt: {receiptNumber}, Items: {cart.Rows.Count}, Total: {netAmount:C}"),
                New MySqlParameter("@form", "POS")
            }
            dbHelper.ExecuteNonQuery(auditQuery, auditParams)

            dbHelper.CommitTransaction()

            ' Success message
            MessageBox.Show($"Payment processed successfully.{Environment.NewLine}Change: {change:C}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Print receipt and reset POS form
            PrintReceipt(receiptNumber)
            btnClearcart.PerformClick() ' Use the existing Clear Cart functionality
            GenerateTransactionNumber()
            txtAmountPaid.Clear()
            lblChange.Text = "0.00"
            
            ' Close payment panel if open
            PanelPay.Visible = False

        Catch ex As Exception
            dbHelper.RollbackTransaction()
            MessageBox.Show("Error processing payment: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Helper Method to Update Expiration Tracking Based on Sale Quantity
    Private Sub UpdateExpirationTracking(orders As Dictionary(Of Integer, Integer))
        Try
            For Each kvp As KeyValuePair(Of Integer, Integer) In orders
                Dim productId As Integer = kvp.Key
                Dim quantityToDeduct As Integer = kvp.Value

                ' Query to get expiration records based on FIFO (earliest expiration first)
                Dim expirationQuery As String = "
                    SELECT tracking_id, quantity
                    FROM expiration_tracking
                    WHERE product_id = @product_id
                    ORDER BY expiration_date ASC"
                Dim expirationParams As MySqlParameter() = {New MySqlParameter("@product_id", productId)}

                Dim expirationData As DataTable = dbHelper.ExecuteQuery(expirationQuery, expirationParams)

                For Each row As DataRow In expirationData.Rows
                    If quantityToDeduct <= 0 Then
                        Exit For
                    End If

                    Dim trackingId As Integer = Convert.ToInt32(row("tracking_id"))
                    Dim availableQuantity As Integer = Convert.ToInt32(row("quantity"))

                    Dim quantityToReduce As Integer = Math.Min(availableQuantity, quantityToDeduct)
                    quantityToDeduct -= quantityToReduce

                    ' Update the quantity in expiration_tracking
                    Dim updateExpirationQuery As String = "
                        UPDATE expiration_tracking
                        SET quantity = quantity - @quantityToReduce
                        WHERE tracking_id = @trackingId"
                    Dim updateParams As MySqlParameter() = {
                        New MySqlParameter("@quantityToReduce", quantityToReduce),
                        New MySqlParameter("@trackingId", trackingId)
                    }

                    dbHelper.ExecuteNonQuery(updateExpirationQuery, updateParams)
                Next
            Next
        Catch ex As Exception
            Throw New Exception($"Error updating expiration tracking: {ex.Message}")
        End Try
    End Sub

    ' Helper Method to Update Inventory Based on Order
    Private Sub UpdateInventory(orders As Dictionary(Of Integer, Integer))
        For Each kvp As KeyValuePair(Of Integer, Integer) In orders
            Try
                Dim productId As Integer = kvp.Key
                Dim quantityToDeduct As Integer = kvp.Value

                Dim inventoryQuery As String = "UPDATE inventory SET current_quantity = current_quantity - @quantity WHERE product_id = @product_id"
                Dim inventoryParams As MySqlParameter() = {
                New MySqlParameter("@quantity", quantityToDeduct),
                New MySqlParameter("@product_id", productId)
            }

                dbHelper.ExecuteNonQuery(inventoryQuery, inventoryParams)
            Catch ex As Exception
                MessageBox.Show($"Error updating inventory for product ID {kvp.Key}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Next
    End Sub

    ' Update Cart Summary
    Private Sub UpdateCartSummary()
        Dim discountRate As Decimal = GetCurrentDiscount()
        Dim vatRate As Decimal = GetCurrentVAT()
        Dim subtotal As Decimal = cart.AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("Total"))

        Dim discount As Decimal = (discountRate / 100) * subtotal

        ' Calculate VAT
        Dim vat As Decimal = ((subtotal - discount) * vatRate) / 100
        Dim total As Decimal = subtotal - discount + vat

        lblSubtotal.Text = subtotal.ToString("0.00")
        lblVAT.Text = vat.ToString("0.00")
        lblDiscount.Text = discount.ToString("0.00")
        lblTotal.Text = total.ToString("0.00")
        lblTotalItems.Text = "0" & cart.Rows.Count
    End Sub

    Private Sub POS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeCart()
        DisplayDateAndTime() ' Initialize the label with the current date and time
        LoadDiscounts()
        PanelQuantity.Visible = False ' Ensure panel is hidden initially
        
        ' Set Form Background Color
        Me.BackColor = Color.White

        ' Set Label Background and Text Color
        lblSubtotal.BackColor = Color.White
        lblTotal.BackColor = Color.White
        lblDiscount.BackColor = Color.White
        lblVAT.BackColor = Color.White

        lblSubtotal.ForeColor = Color.Black
        lblTotal.ForeColor = Color.Black
        lblDiscount.ForeColor = Color.Black
        lblVAT.ForeColor = Color.Black

        ' Set button colors
        btnClearcart.BackColor = Color.White
        btnClearcart.ForeColor = Color.Black
        btnProcessPayment.BackColor = Color.White  ' Set color for Process Payment button
        btnProcessPayment.ForeColor = Color.Black
        btnVoid.BackColor = Color.FromArgb(255, 128, 128)
        btnVoid.ForeColor = Color.Black

        ' Add validation for preventing issues with invalid data
        txtBarcode.Select() ' Set focus to barcode field to start scanning
    End Sub

    Private Function GetProductId(barcode As String) As Integer
        Try
            Dim query As String = "SELECT product_id FROM products WHERE barcode = @barcode"
            Dim parameters As MySqlParameter() = {New MySqlParameter("@barcode", barcode)}
            Dim result = dbHelper.ExecuteScalar(query, parameters)
            If result IsNot Nothing Then
                Return Convert.ToInt32(result)
            Else
                Throw New Exception("Product ID not found for the given barcode.")
            End If
        Catch ex As Exception
            MessageBox.Show($"Error fetching product ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Private WithEvents PrintDocument As New PrintDocument
    Private WithEvents PrintPreviewDialog As New PrintPreviewDialog
    Private PrinterSettings As New PrinterSettings()
    Private currentReceiptNumber As String = "" ' Store receipt number here instead of using Tag

    Private Sub PrintReceipt(receiptNumber As String)
        Try
            ' Set up print document settings
            AddHandler PrintDocument.PrintPage, AddressOf PrintDocument_PrintPage
            PrintDocument.PrinterSettings = PrinterSettings
            currentReceiptNumber = receiptNumber ' Store in variable instead of Tag
            PrintPreviewDialog.Document = PrintDocument
            PrintPreviewDialog.ShowDialog()
            'PrintDocument.Print()
        Catch ex As Exception
            MessageBox.Show("Error printing receipt: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub PrintDocument_PrintPage(sender As Object, e As PrintPageEventArgs)
        Dim receiptContent As String = GenerateReceiptContent()
        Dim printFont As New Font("Courier New", 10) ' Monospace font for alignment
        e.Graphics.DrawString(receiptContent, printFont, Brushes.Black, 10, 10)
    End Sub

    Private Function GenerateReceiptContent() As String
        Dim sb As New StringBuilder()
        
        ' Get the receipt number from our variable instead of Tag property
        Dim receiptNumber As String = currentReceiptNumber
        
        ' Store name and header
        sb.AppendLine("      SALES RECEIPT      ")
        sb.AppendLine("==========================")
        sb.AppendLine($"Receipt #: {receiptNumber}")
        sb.AppendLine($"Transaction #: {transactionNumber}")
        sb.AppendLine($"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}")
        sb.AppendLine($"Cashier: {lblCashier.Text.Trim()}")
        sb.AppendLine("==========================")
        sb.AppendLine()

        ' Table Header with better alignment
        sb.AppendLine("ITEM                QTY   PRICE    TOTAL")
        sb.AppendLine("------------------------------------------")

        ' Items with better formatting
        For Each row As DataRow In cart.Rows
            Dim itemName As String = row("ItemName").ToString()
            ' Truncate long names and pad for alignment
            If itemName.Length > 18 Then
                itemName = itemName.Substring(0, 15) & "..."
            End If
            itemName = itemName.PadRight(20)
            
            Dim quantity As Integer = row("Quantity")
            Dim unitPrice As Decimal = row("UnitPrice")
            Dim totalPrice As Decimal = row("Total")
            
            sb.AppendLine($"{itemName} {quantity,3}  {unitPrice,8:N2}  {totalPrice,8:N2}")
        Next

        sb.AppendLine("------------------------------------------")

        ' Summary section with aligned values
        Dim summaryLabelWidth As Integer = 12
        sb.AppendLine()
        sb.AppendLine($"{"Subtotal:".PadRight(summaryLabelWidth)}{lblSubtotal.Text,10:N2}")
        sb.AppendLine($"{"Discount:".PadRight(summaryLabelWidth)}{lblDiscount.Text,10:N2}")
        sb.AppendLine($"{"VAT:".PadRight(summaryLabelWidth)}{lblVAT.Text,10:N2}")
        sb.AppendLine($"{"Total:".PadRight(summaryLabelWidth)}{lblTotal.Text,10:N2}")
        sb.AppendLine("------------------------------------------")
        sb.AppendLine($"{"Amount Paid:".PadRight(summaryLabelWidth)}{txtAmountPaid.Text,10:N2}")
        sb.AppendLine($"{"Change:".PadRight(summaryLabelWidth)}{lblChange.Text,10:N2}")
        sb.AppendLine("------------------------------------------")
        sb.AppendLine()
        sb.AppendLine("         Thank you for shopping!")
        sb.AppendLine("           Please come again!")
        sb.AppendLine()
        sb.AppendLine("         " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))

        Return sb.ToString()
    End Function

    Private Function GetCurrentDiscount() As Decimal
        Dim discountRate As Decimal = 0
        Try
            ' Fetch the first available discount (if there's only one active discount)
            Dim query As String = "SELECT discount_rate FROM discounts LIMIT 1"
            Dim result As Object = dbHelper.ExecuteScalar(query)
            If result IsNot Nothing Then
                discountRate = Convert.ToDecimal(result)
            End If
        Catch ex As Exception
            MessageBox.Show("Error fetching discount: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return discountRate
    End Function

    Private Sub LoadDiscounts()
        Try
            ' Define the query to fetch active discounts
            Dim query As String = "SELECT discount_name, discount_rate FROM discounts"

            ' Get the discount data
            Dim dt As DataTable = dbHelper.GetDataTable(query)

            ' Bind the ComboBox to the discount data
            cmbDiscount.DataSource = dt
            cmbDiscount.ValueMember = "discount_name"
            cmbDiscount.ValueMember = "discount_rate"   ' The discount_id will be the underlying value

        Catch ex As Exception
            MessageBox.Show("Error loading discounts: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetCurrentVAT() As Decimal
        Dim vatRate As Decimal = 0
        Try
            Dim query As String = "SELECT vat_rate FROM vat ORDER BY effective_date DESC LIMIT 1"
            Dim result As Object = dbHelper.ExecuteScalar(query)
            If result IsNot Nothing Then
                vatRate = Convert.ToDecimal(result)
            End If
        Catch ex As Exception
            MessageBox.Show("Error fetching VAT: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return vatRate
    End Function






    ' This is the function that will update the label with the current date and time
    Private Sub DisplayDateAndTime()
        lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
    End Sub

    Private Sub reset()
        ' Clear the input fields
        txtBarcode.Text = String.Empty
        txtQuantity.Text = String.Empty
        GenerateTransactionNumber()


    End Sub



    Private Sub txtAmountPaid_TextChanged(sender As Object, e As EventArgs) Handles txtAmountPaid.TextChanged
        Dim amountPaid As Decimal

        ' Kunin ang amount paid, at i-check kung valid number
        If Not Decimal.TryParse(txtAmountPaid.Text, amountPaid) Then
            lblChange.Text = "Invalid Amount"
            Return
        End If
    End Sub


    'FOR KEYDOWN
    Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyDown
        ' Check if the Enter key is pressed
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True ' Prevent "ding" sound on Enter key press

            ' Check for scan timeout
            If (DateTime.Now - lastScanTime).TotalMilliseconds > 500 Then
                ' Assume the quantity is 1 for a single scan
                Dim quantity As Integer = 1

                ' Process the barcode by adding it to the cart with the default quantity
                AddToCart(txtBarcode.Text.Trim()) ' Pass only the barcode

                ' Clear the barcode textbox after processing
                txtBarcode.Clear()

                ' Update the last scan time
                lastScanTime = DateTime.Now
            End If
        End If

    End Sub


    ' FOR KEYPRESS
    Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        ' Allow only numbers and control keys (like backspace)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        ' Allow numbers, control keys, and only one hyphen (-) at the beginning
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            ' Allow hyphen (-) only at the start and only once
            If e.KeyChar = "-"c AndAlso txtQuantity.SelectionStart = 0 AndAlso Not txtQuantity.Text.Contains("-") Then
                ' Allow hyphen
            Else
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub txtAmountPaid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmountPaid.KeyPress
        ' Allow only numbers and control keys (like backspace)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtQuantity_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQuantity.KeyDown
        ' Check if Enter key is pressed
        If e.KeyCode = Keys.Enter Then
            ' Call AddToCart to add or update the quantity of the item
            AddToCart(txtBarcode.Text)

            ' Clear the textboxes after adding
            txtBarcode.Clear()
            txtQuantity.Clear()

            ' Set focus back to the barcode text box for scanning next product
            txtBarcode.Focus()

            ' Prevent the beep sound when pressing Enter
            e.SuppressKeyPress = True
        End If
    End Sub


    '===================PANELS========================================='
    Private Sub DiscountPanel_Paint(sender As Object, e As PaintEventArgs) Handles DiscountPanel.Paint
        ' Set the desired width and height for the DiscountPanel
        Dim panelWidth As Integer = 541
        Dim panelHeight As Integer = 268

        ' Calculate the position to center the panel on the screen
        Dim xPos As Integer = (Me.ClientSize.Width - panelWidth) \ 2
        Dim yPos As Integer = (Me.ClientSize.Height - panelHeight) \ 2

        ' Set the size and location of the DiscountPanel to be centered
        DiscountPanel.Size = New Size(panelWidth, panelHeight)
        DiscountPanel.Location = New Point(xPos, yPos)
    End Sub
    Private Sub PanelQuantity_Paint(sender As Object, e As PaintEventArgs) Handles PanelQuantity.Paint
        ' Set the exact size of PanelQuantity
        PanelQuantity.Size = New Size(517, 279)

        ' Center Panel5 on the form
        PanelQuantity.Location = New Point((Me.ClientSize.Width - PanelPay.Width) / 2, (Me.ClientSize.Height - PanelPay.Height) / 2)
    End Sub
    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles PanelPay.Paint
        ' Set the size of Panel5 to 515x287
        PanelPay.Size = New Size(517, 279)

        ' Center Panel5 on the form
        PanelPay.Location = New Point((Me.ClientSize.Width - PanelPay.Width) / 2, (Me.ClientSize.Height - PanelPay.Height) / 2)
    End Sub


    '===================PANEL BUTTONS FUNTIONS ======================='
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DiscountPanel.Visible = True
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DiscountPanel.Visible = False
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PanelPay.Visible = True
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PanelPay.Visible = False
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        DiscountPanel.Visible = False
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        PanelQuantity.Visible = False

    End Sub

    Private Sub dgvCart_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCart.CellClick
        ' Check if the Delete column was clicked
        If e.ColumnIndex = dgvCart.Columns("Delete").Index AndAlso e.RowIndex >= 0 Then
            ' Remove the selected row
            dgvCart.Rows.RemoveAt(e.RowIndex)

            ' Optionally, update the cart summary after deletion
            UpdateCartSummary()

            ' Check if the Edit column was clicked
        ElseIf e.ColumnIndex = dgvCart.Columns("Edit").Index AndAlso e.RowIndex >= 0 Then
            ' Get the selected row data
            Dim selectedRow As DataGridViewRow = dgvCart.Rows(e.RowIndex)

            ' Populate the textboxes for editing
            txtBarcode.Text = selectedRow.Cells("Barcode").Value.ToString()
            txtQuantity.Text = selectedRow.Cells("Quantity").Value.ToString()

            ' Optional: If you want to highlight the editing row, you can add some visual cues
            selectedRow.DefaultCellStyle.BackColor = Color.LightYellow ' Example highlight color
        End If
        ' Ensure a valid row and column index
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim columnName As String = dgvCart.Columns(e.ColumnIndex).Name

            ' Show PanelDiscount when clicking anywhere in the Discount column
            If columnName = "Discount" Then
                DiscountPanel.Visible = True
            Else
                DiscountPanel.Visible = False ' Hide if clicking elsewhere
            End If

            ' Show PanelQuantity when clicking the Edit column (image column)
            If columnName = "Edit" Then
                PanelQuantity.Visible = True
            End If
        End If
        PanelQuantity.Visible = True
    End Sub

    Private Sub btnVoid_Click(sender As Object, e As EventArgs) Handles btnVoid.Click
        ' Check if any row is selected in the cart
        If dgvCart.SelectedRows.Count = 0 AndAlso dgvCart.CurrentRow Is Nothing Then
            MessageBox.Show("Please select an item to void.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get the selected row (either through SelectedRows or CurrentRow)
        Dim selectedRow As DataGridViewRow = If(dgvCart.SelectedRows.Count > 0, dgvCart.SelectedRows(0), dgvCart.CurrentRow)
        
        ' Get the item details for the audit trail
        Dim itemName As String = selectedRow.Cells("ItemName").Value.ToString()
        Dim quantity As Integer = Convert.ToInt32(selectedRow.Cells("Quantity").Value)
        Dim barcode As String = selectedRow.Cells("Barcode").Value.ToString()
        Dim unitPrice As Decimal = Convert.ToDecimal(selectedRow.Cells("UnitPrice").Value)
        Dim totalPrice As Decimal = Convert.ToDecimal(selectedRow.Cells("Total").Value)
        
        ' Ask for confirmation before voiding
        Dim confirmResult As DialogResult = MessageBox.Show(
            $"Are you sure you want to void {quantity} x {itemName}?" & vbCrLf & 
            $"Total: {totalPrice:C}", 
            "Confirm Void", 
            MessageBoxButtons.YesNo, 
            MessageBoxIcon.Question)
        
        If confirmResult = DialogResult.Yes Then
            ' Get the row index in the actual DataTable (may be different from the DataGridView due to filtering)
            Dim rowIndex As Integer = dgvCart.Rows.IndexOf(selectedRow)
            
            ' Log the void action in audit trail
            Try
                Dim query As String = "INSERT INTO audittrail (Role, FullName, Action, Form, Date) VALUES (@role, @fullName, @action, @form, NOW())"
                Dim parameters As MySqlParameter() = {
                    New MySqlParameter("@role", "Cashier"),
                    New MySqlParameter("@fullName", lblCashier.Text.Trim()),
                    New MySqlParameter("@action", $"Voided {quantity} x {itemName} (Barcode: {barcode}) from transaction {transactionNumber}. Total: {totalPrice:C}"),
                    New MySqlParameter("@form", "POS")
                }
                
                dbHelper.ExecuteNonQuery(query, parameters)
                
                ' Remove the item from the cart
                If cart.Rows.Count > rowIndex Then
                    cart.Rows.RemoveAt(rowIndex)
                End If
                
                ' Update the DataGridView and cart summary
                dgvCart.DataSource = Nothing
                dgvCart.DataSource = cart
                UpdateCartSummary()
                
                MessageBox.Show("Item voided successfully.", "Void Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error voiding item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' Add a new Void Transaction function
    Private Sub BtnVoidTransaction_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Check if cart is empty
        If cart Is Nothing OrElse cart.Rows.Count = 0 Then
            MessageBox.Show("There are no items in the transaction to void.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Ask for confirmation with admin password for security
        Dim confirmResult As DialogResult = MessageBox.Show(
            $"Are you sure you want to void the entire transaction ({cart.Rows.Count} items)?" & vbCrLf &
            $"Total: {lblTotal.Text}", 
            "Confirm Void Transaction", 
            MessageBoxButtons.YesNo, 
            MessageBoxIcon.Warning)
        
        If confirmResult = DialogResult.Yes Then
            ' Request admin password for additional security
            Dim adminPassword As String = InputBox("Please enter admin password to void transaction:", "Authorization Required")
            
            ' Validate admin password - in a real system this should check against the database
            Try
                Dim validationQuery As String = "SELECT COUNT(*) FROM users WHERE role = 'Admin' AND password_hash = @passwordHash"
                Dim parameters As MySqlParameter() = {New MySqlParameter("@passwordHash", GetSHA256Hash(adminPassword))}
                Dim isValid As Integer = Convert.ToInt32(dbHelper.ExecuteScalar(validationQuery, parameters))
                
                If isValid > 0 Then
                    ' Log the void transaction in audit trail
                    Dim totalValue As Decimal = Convert.ToDecimal(lblTotal.Text)
                    Dim itemCount As Integer = cart.Rows.Count
                    
                    Dim query As String = "INSERT INTO audittrail (Role, FullName, Action, Form, Date) VALUES (@role, @fullName, @action, @form, NOW())"
                    Dim auditParams As MySqlParameter() = {
                        New MySqlParameter("@role", "Cashier"),
                        New MySqlParameter("@fullName", lblCashier.Text.Trim()),
                        New MySqlParameter("@action", $"Voided entire transaction {transactionNumber} with {itemCount} items. Total value: {totalValue:C}"),
                        New MySqlParameter("@form", "POS")
                    }
                    
                    dbHelper.ExecuteNonQuery(query, auditParams)
                    
                    ' Clear the cart and reset the transaction
                    cart.Clear()
                    dgvCart.DataSource = Nothing
                    dgvCart.DataSource = cart
                    AddImageColumns() ' Add image columns again after rebinding
                    
                    UpdateCartSummary()
                    GenerateTransactionNumber() ' Generate a new transaction number
                    
                    MessageBox.Show("Transaction voided successfully.", "Void Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Invalid administrator password. Transaction void cancelled.", "Authorization Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Error during authorization: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' Helper function to generate SHA256 hash
    Private Function GetSHA256Hash(input As String) As String
        Using hasher As System.Security.Cryptography.SHA256 = System.Security.Cryptography.SHA256.Create()
            ' Convert the input string to a byte array and compute the hash
            Dim bytes As Byte() = hasher.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input))
            
            ' Convert byte array to a string
            Dim builder As New System.Text.StringBuilder()
            For i As Integer = 0 To bytes.Length - 1
                builder.Append(bytes(i).ToString("x2"))
            Next
            
            Return builder.ToString()
        End Using
    End Function

End Class
