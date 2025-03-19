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
        Dim lblCashier As New Label() ' Make sure this is declared in the form's designer

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
        If String.IsNullOrWhiteSpace(barcode) Then Return ' Exit if barcode is empty or null

        ' Initialize the cart DataTable if it's not already done
        If cart Is Nothing Then InitializeCart()

        Try
            ' Query to fetch product details based on the scanned barcode
            Dim query As String = "SELECT p.product_name, p.selling_price, i.current_quantity 
                               FROM products p
                               INNER JOIN delivery_items di ON p.product_id = di.product_id
                               INNER JOIN inventory i ON i.product_id = p.product_id
                               WHERE p.barcode = @barcode"
            Dim parameters As MySqlParameter() = {New MySqlParameter("@barcode", barcode)}
            Dim productTable As DataTable = dbHelper.ExecuteQuery(query, parameters)

            ' Check if product exists
            If productTable.Rows.Count = 0 Then
                MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Extract product details from the database result
            Dim productName As String = productTable.Rows(0)("product_name").ToString()
            Dim unitPrice As Decimal = Convert.ToDecimal(productTable.Rows(0)("selling_price"))
            Dim availableQuantity As Integer = Convert.ToInt32(productTable.Rows(0)("current_quantity"))
            Dim discount As Decimal = 0 ' Add discount logic if needed

            ' Get the manual quantity from the txtQuantity TextBox or set default to 1
            Dim manualQuantity As Integer = 1
            If Not String.IsNullOrWhiteSpace(txtQuantity.Text) Then
                manualQuantity = Convert.ToInt32(txtQuantity.Text)
            End If

            ' Check if the requested quantity exceeds the available quantity in inventory
            If manualQuantity > availableQuantity Then
                MessageBox.Show("Insufficient stock. Only " & availableQuantity.ToString() & " items are available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Check if the product already exists in the cart (by barcode)
            Dim existingRow = cart.AsEnumerable().FirstOrDefault(Function(row) row.Field(Of String)("Barcode") = barcode)
            If existingRow IsNot Nothing Then
                ' If the product exists, increment the quantity and update the total
                existingRow("Quantity") += manualQuantity
                existingRow("Total") = existingRow("Quantity") * existingRow("UnitPrice")
            Else
                ' If the product is not yet in the cart, add a new row
                Dim rowIndex As Integer = cart.Rows.Count + 1
                cart.Rows.Add(rowIndex, barcode, productName, manualQuantity, unitPrice, discount, manualQuantity * unitPrice)
            End If

            ' Refresh the DataGridView to show the updated cart
            dgvCart.DataSource = Nothing
            dgvCart.DataSource = cart

            ' Update the cart summary, such as total price, item count, etc.
            UpdateCartSummary()

            ' Clear the quantity input after adding the product to the cart
            txtQuantity.Clear()

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
        Dim amountPaid As Decimal

        ' Validate the amount paid
        If Not Decimal.TryParse(txtAmountPaid.Text, amountPaid) OrElse amountPaid < Convert.ToDecimal(lblTotal.Text) Then
            MessageBox.Show("Insufficient amount paid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get the selected discount (Ensure ComboBox is properly bound)
        Dim selectedDiscountRate = Convert.ToDecimal(CType(cmbDiscount.SelectedItem, DataRowView)("discount_rate")) / 100
        Dim totalAmount = Convert.ToDecimal(lblTotal.Text)
        Dim discountAmount = totalAmount * selectedDiscountRate
        Dim netAmount = totalAmount - discountAmount

        ' Update UI for discount and total
        lblDiscount.Text = discountAmount.ToString("0.00")
        lblTotal.Text = netAmount.ToString("0.00")

        ' Stock and Payment Process
        For Each row As DataRow In cart.Rows
            Dim productId = GetProductId(row("Barcode"))
            Dim quantityRequested = Convert.ToInt32(row("Quantity"))

            ' Check stock availability
            Dim stockQuery = "SELECT current_quantity FROM inventory WHERE product_id = @product_id"
            Dim stockParams = {New MySqlParameter("@product_id", productId)}
            Dim currentStock = Convert.ToInt32(dbHelper.ExecuteScalar(stockQuery, stockParams))

            If quantityRequested > currentStock Then
                MessageBox.Show($"Insufficient stock for product: {row("ItemName").ToString}. Only {currentStock} available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ' Exit the process if stock is insufficient
            End If
        Next

        ' Calculate the change
        Dim change = amountPaid - netAmount
        lblChange.Text = change.ToString("0.00")

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
            New MySqlParameter("@vat_amount", lblVAT.Text), ' Add VAT calculation before this if needed
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
                Dim productId = GetProductId(row("Barcode"))
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

            dbHelper.CommitTransaction()

            ' Success message
            MessageBox.Show("Payment processed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Print receipt and reset POS form
            PrintReceipt()
            BtnClearCart_Click(sender, e)
            GenerateTransactionNumber()
            txtAmountPaid.Clear()
            lblChange.Text = "0.00"

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

        btnClearcart.BackColor = Color.White
        btnClearcart.ForeColor = Color.Black
        btnProcessPayment.BackColor = Color.White  ' Set color for Process Payment button
        btnProcessPayment.ForeColor = Color.Black

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

    Private Sub PrintReceipt()
        Try
            ' Set up print document settings
            AddHandler PrintDocument.PrintPage, AddressOf PrintDocument_PrintPage
            PrintDocument.PrinterSettings = PrinterSettings
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
        ' Header
        sb.AppendLine("      RECEIPT      ")
        sb.AppendLine("  ----------------  ")
        sb.AppendLine($"Transaction #:")
        sb.AppendLine($"{transactionNumber}")
        sb.AppendLine($"Date: {DateTime.Now:yyyy-MM-dd HH:mm}")
        sb.AppendLine($"Cashier: {fullName}")
        sb.AppendLine()

        ' Table Header
        sb.AppendLine("Item      Qty  Price   Total")
        sb.AppendLine("------------------------------")

        ' Items
        For Each row As DataRow In cart.Rows
            Dim itemName As String = row("ItemName").ToString()
            Dim quantity As Integer = row("Quantity")
            Dim unitPrice As Decimal = row("UnitPrice")
            Dim totalPrice As Decimal = row("Total")
            sb.AppendLine($"{itemName.PadRight(10).Substring(0, 10),-10} {quantity,3} {unitPrice,6:0.00} {totalPrice,6:0.00}")
        Next

        sb.AppendLine("------------------------------")

        ' Summary
        sb.AppendLine($"Subtotal:".PadRight(12) & lblSubtotal.Text.PadLeft(0))
        sb.AppendLine($"Discount:".PadRight(12) & lblDiscount.Text.PadLeft(0))
        sb.AppendLine($"VAT:".PadRight(12) & lblVAT.Text.PadLeft(0))
        sb.AppendLine($"Total:".PadRight(12) & lblTotal.Text.PadLeft(0))
        sb.AppendLine($"Paid:".PadRight(12) & txtAmountPaid.Text.PadLeft(0))
        sb.AppendLine($"Change:".PadRight(12) & lblChange.Text.PadLeft(0))
        sb.AppendLine("------------------------------")
        sb.AppendLine("Thank you for shopping!")
        sb.AppendLine("  Visit us again!")

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

End Class
