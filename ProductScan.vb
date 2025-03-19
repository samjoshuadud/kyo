Imports MySql.Data.MySqlClient

Public Class ProductScan
    Private connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private connection As MySqlConnection
    Private transactionNumber As String
    Private supplierName As String
    Private deliveryDate As Date


    ' Reference to the InventoryUpdate form
    Private inventoryUpdateForm As InventoryUpdate = Nothing

    Public Sub New(transactionNumber As String, supplierName As String, deliveryDate As Date)
        InitializeComponent()

        ' Set properties
        Me.transactionNumber = transactionNumber
        Me.supplierName = supplierName
        Me.deliveryDate = deliveryDate

        ' Initialize the database connection
        connection = New MySqlConnection(connectionString)

        ' Set label texts after InitializeComponent
        lblTransaction.Text &= transactionNumber
        lblSupplier.Text &= supplierName
        lblDeliveryDate.Text &= deliveryDate.ToShortDateString()
    End Sub

    ' Initialize UI Components


    ' Handle Enter key press for scanning barcode
    Private Sub TxtBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            SearchProduct()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    ' Handle LostFocus event to search product automatically
    Private Sub TxtBarcode_LostFocus(sender As Object, e As EventArgs)
        If Not String.IsNullOrWhiteSpace(txtBarcode.Text) Then
            SearchProduct()
        End If
    End Sub

    ' Search Product by Barcode
    Private Sub SearchProduct()
        If String.IsNullOrWhiteSpace(txtBarcode.Text) Then
            MessageBox.Show("Please scan a barcode.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' Ensure the connection is closed before opening it
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If

            ' Open Database Connection
            connection.Open()

            ' Query to Fetch Product Details
            Dim query As String = "SELECT p.product_name, p.description, p.selling_price, c.category_name " &
                                  "FROM products p JOIN categories c ON p.category_id = c.category_id " &
                                  "WHERE p.barcode = @barcode"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            ' Check if Product Exists
            If reader.Read() Then
                ' Retrieve Product Details
                Dim productName = reader("product_name").ToString()
                Dim description = reader("description").ToString()
                Dim sellingPrice = Convert.ToDecimal(reader("selling_price"))
                Dim category = reader("category_name").ToString()

                ' Check if the InventoryUpdate form is already open
                If inventoryUpdateForm Is Nothing OrElse inventoryUpdateForm.IsDisposed Then
                    ' Open InventoryUpdate Form and Pass Details
                    inventoryUpdateForm = New InventoryUpdate(transactionNumber, supplierName, deliveryDate, txtBarcode.Text) With {
                        .ProductName = productName,
                        .Description = description,
                        .SellingPrice = sellingPrice,
                        .CategoryName = category
                    }

                    ' Show InventoryUpdate form as dialog
                    Me.Hide()
                    inventoryUpdateForm.ShowDialog()
                    Me.Close() ' Close ProductScan form after InventoryUpdate form is closed
                Else
                    ' If the form is already open, just focus on it
                    inventoryUpdateForm.BringToFront()
                End If

                ' Clear barcode text for next input
                txtBarcode.Clear()
            Else
                ' Show Error if Product Not Found
                MessageBox.Show("Product not found! Please scan a valid barcode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBarcode.Focus()
            End If

            ' Close Reader
            reader.Close()
        Catch ex As Exception
            ' Display Error Message
            MessageBox.Show("Error fetching product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Ensure Database Connection is Closed
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub ProductScan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' No additional actions required on load.
    End Sub
End Class
