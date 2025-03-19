Imports MySql.Data.MySqlClient



Public Class DeliveryMain
    ' Connection String for the database
    Private connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private connection As MySqlConnection



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

    ' Initialize UI Components



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

    ' Save Button Click Event Handler

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
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



    Private Sub DeliveryMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSuppliers()
    End Sub
End Class