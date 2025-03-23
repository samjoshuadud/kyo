Imports MySql.Data.MySqlClient

Public Class DiscountMain
    Private connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private connection As MySqlConnection
    Private selectedDiscountId As Integer = -1 ' Tracks the selected Discount ID

    Public Sub New()
        InitializeComponent()
        ' Initialize form properties
        Me.Text = "Discount Management"
        Me.Width = 700
        Me.Height = 500
        Me.StartPosition = FormStartPosition.CenterScreen


        connection = New MySqlConnection(connectionString)

        ' Load Discount data into the grid
        LoadDiscountData()
    End Sub




    ' Load Discount data into the grid
    Private Sub LoadDiscountData()
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            ' Include discount_id in the query
            Dim query As String = "SELECT discount_id, discount_name, discount_rate FROM discounts"
            Dim cmd As New MySqlCommand(query, connection)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            ' Load data into DataGridView
            Dim dt As New DataTable()
            dt.Load(reader)
            dgvDiscounts.DataSource = dt

            ' Optionally hide the discount_id column (if not needed for display)
            If dgvDiscounts.Columns.Contains("discount_id") Then
                dgvDiscounts.Columns("discount_id").Visible = False
            End If

            ' Format the discount_rate column to show % sign
            If dgvDiscounts.Columns.Contains("discount_rate") Then
                dgvDiscounts.Columns("discount_rate").DefaultCellStyle.Format = "0.##\\%"
            End If

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading Discount data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub DgvDiscounts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDiscounts.CellClick
        Try
            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow = dgvDiscounts.Rows(e.RowIndex)

                ' Ensure the discount_id column exists
                If dgvDiscounts.Columns.Contains("discount_id") Then
                    selectedDiscountId = Convert.ToInt32(row.Cells("discount_id").Value)
                Else
                    selectedDiscountId = -1 ' Reset if column is missing
                    MessageBox.Show("The 'discount_id' column is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                ' Populate input fields with selected row data and format the discount rate with %
                txtDiscountName.Text = row.Cells("discount_name").Value.ToString()
                Dim discountRate As Decimal = Convert.ToDecimal(row.Cells("discount_rate").Value)
                txtDiscountRate.Text = discountRate.ToString("0.##") & "%"
            End If
        Catch ex As Exception
            MessageBox.Show("Error selecting Discount: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Check if the Discount Name already exists in the database
    Private Function IsDiscountNameExists(discountName As String, Optional excludeId As Integer = -1) As Boolean
        Try
            connection.Open()
            Dim query As String
            
            If excludeId > 0 Then
                ' When updating, exclude the current discount from the check
                query = "SELECT COUNT(*) FROM discounts WHERE discount_name = @name AND discount_id <> @id"
            Else
                ' When adding new, check all discounts
                query = "SELECT COUNT(*) FROM discounts WHERE discount_name = @name"
            End If
            
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@name", discountName)
            
            If excludeId > 0 Then
                cmd.Parameters.AddWithValue("@id", excludeId)
            End If
            
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            Return count > 0 ' If count is greater than 0, it means the discount name exists
        Catch ex As Exception
            MessageBox.Show("Error checking for duplicate Discount: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            connection.Close()
        End Try
    End Function

    ' Add new Discount
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Validate input fields
        If Not ValidateInputs() Then Exit Sub

        ' Check if the Discount Name already exists in the database
        If IsDiscountNameExists(txtDiscountName.Text) Then
            MessageBox.Show("A Discount with this name already exists. Please choose a different name.", "Duplicate Discount", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            connection.Open()
            ' Prepare the query and remove % from the rate before saving to the database
            Dim query As String = "INSERT INTO discounts (discount_name, discount_rate) VALUES (@name, @rate)"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@name", txtDiscountName.Text)

            ' Remove % before converting to a decimal
            Dim discountRateText As String = txtDiscountRate.Text.Replace("%", "").Trim()
            Dim discountRate As Decimal = Convert.ToDecimal(discountRateText)
            cmd.Parameters.AddWithValue("@rate", discountRate)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Discount added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDiscountData()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Error adding Discount: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub



    ' Edit selected Discount
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If selectedDiscountId = -1 Then
            MessageBox.Show("Please select a Discount to edit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidateInputs() Then Exit Sub

        ' Check if the discount name exists for other records
        If IsDiscountNameExists(txtDiscountName.Text, selectedDiscountId) Then
            MessageBox.Show("A Discount with this name already exists. Please choose a different name.", "Duplicate Discount", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            connection.Open()
            Dim query As String = "UPDATE discounts SET discount_name = @name, discount_rate = @rate WHERE discount_id = @id"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@name", txtDiscountName.Text)
            
            ' Remove % before converting to a decimal
            Dim discountRateText As String = txtDiscountRate.Text.Replace("%", "").Trim()
            Dim discountRate As Decimal = Convert.ToDecimal(discountRateText)
            cmd.Parameters.AddWithValue("@rate", discountRate)
            cmd.Parameters.AddWithValue("@id", selectedDiscountId)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Discount updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDiscountData()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Error updating Discount: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Delete selected Discount
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedDiscountId = -1 Then
            MessageBox.Show("Please select a Discount to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Ask for confirmation before deleting
        Dim confirmResult = MessageBox.Show("Are you sure you want to delete this discount?", "Confirm Delete", 
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmResult = DialogResult.No Then
            Return
        End If

        Try
            connection.Open()
            
            ' First check if the discount is being used in any sales
            Dim checkQuery As String = "SELECT COUNT(*) FROM sales WHERE discount_id = @id"
            Dim checkCmd As New MySqlCommand(checkQuery, connection)
            checkCmd.Parameters.AddWithValue("@id", selectedDiscountId)
            Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
            
            If count > 0 Then
                MessageBox.Show("This discount is being used in " & count & " sales records. It cannot be deleted.", 
                                "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            
            ' If no sales use this discount, proceed with deletion
            Dim query As String = "DELETE FROM discounts WHERE discount_id = @id"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@id", selectedDiscountId)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Discount deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDiscountData()
            ClearFields()
            selectedDiscountId = -1 ' Reset selection
        Catch ex As Exception
            MessageBox.Show("Error deleting Discount: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Close the form
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' Clear input fields
    Private Sub ClearFields()
        txtDiscountName.Clear()
        txtDiscountRate.Clear()
        selectedDiscountId = -1
    End Sub

    ' Reset button handler - use a standard event handler without the Handles clause
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ClearFields()
    End Sub

    ' Validate user inputs
    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtDiscountName.Text) Then
            MessageBox.Show("Please enter a valid Discount name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Remove % from the input before validation
        Dim discountRateText As String = txtDiscountRate.Text.Replace("%", "").Trim()

        If String.IsNullOrWhiteSpace(discountRateText) OrElse Not Decimal.TryParse(discountRateText, Nothing) Then
            MessageBox.Show("Please enter a valid Discount rate.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim discountRate As Decimal = Convert.ToDecimal(discountRateText)
        If discountRate < 0 OrElse discountRate > 100 Then
            MessageBox.Show("Discount rate must be between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    ' Format rate as percentage when focus is lost - use a standard event handler without the Handles clause
    Private Sub txtDiscountRate_LostFocus(sender As Object, e As EventArgs) Handles txtDiscountRate.LostFocus
        If Not String.IsNullOrWhiteSpace(txtDiscountRate.Text) Then
            ' Remove any existing % sign first
            Dim rateText As String = txtDiscountRate.Text.Replace("%", "").Trim()
            
            If Decimal.TryParse(rateText, Nothing) Then
                ' Format with % sign
                txtDiscountRate.Text = rateText & "%"
            End If
        End If
    End Sub

    Private Sub DiscountMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDiscountData()
    End Sub
End Class
