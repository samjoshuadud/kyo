Imports MySql.Data.MySqlClient

Public Class ExpirationMain
    Private connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private connection As MySqlConnection
    Private selectedTrackingId As Integer = -1 ' Tracks the selected expiration record ID

    ' Expiration threshold in days (products expiring within this many days will be highlighted)
    Private expirationThresholdDays As Integer = 30

    Private Sub ExpirationMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set up connection
        connection = New MySqlConnection(connectionString)

        ' Configure columns for the DataGridView
        ConfigureDataGridViewColumns()

        ' Load data
        LoadExpirationData()

        ' Check for soon-to-expire products on load
        CheckExpiringProducts()
    End Sub

    Private Sub ConfigureDataGridViewColumns()
        dgvExpiration.AutoGenerateColumns = False

        ' Add columns programmatically
        Dim trackingIdColumn As New DataGridViewTextBoxColumn()
        trackingIdColumn.Name = "tracking_id"
        trackingIdColumn.DataPropertyName = "tracking_id"
        trackingIdColumn.HeaderText = "ID"
        trackingIdColumn.Visible = False
        dgvExpiration.Columns.Add(trackingIdColumn)

        Dim productNameColumn As New DataGridViewTextBoxColumn()
        productNameColumn.Name = "product_name"
        productNameColumn.DataPropertyName = "product_name"
        productNameColumn.HeaderText = "Product Name"
        productNameColumn.Width = 200
        dgvExpiration.Columns.Add(productNameColumn)

        Dim expirationDateColumn As New DataGridViewTextBoxColumn()
        expirationDateColumn.Name = "expiration_date"
        expirationDateColumn.DataPropertyName = "expiration_date"
        expirationDateColumn.HeaderText = "Expiration Date"
        expirationDateColumn.Width = 120
        dgvExpiration.Columns.Add(expirationDateColumn)

        Dim daysRemainingColumn As New DataGridViewTextBoxColumn()
        daysRemainingColumn.Name = "days_remaining"
        daysRemainingColumn.DataPropertyName = "days_remaining"
        daysRemainingColumn.HeaderText = "Days Remaining"
        daysRemainingColumn.Width = 120
        dgvExpiration.Columns.Add(daysRemainingColumn)

        Dim quantityColumn As New DataGridViewTextBoxColumn()
        quantityColumn.Name = "current_quantity"
        quantityColumn.DataPropertyName = "current_quantity"
        quantityColumn.HeaderText = "Quantity"
        quantityColumn.Width = 80
        dgvExpiration.Columns.Add(quantityColumn)

        Dim statusColumn As New DataGridViewTextBoxColumn()
        statusColumn.Name = "status"
        statusColumn.DataPropertyName = "status"
        statusColumn.HeaderText = "Status"
        statusColumn.Width = 100
        dgvExpiration.Columns.Add(statusColumn)
    End Sub

    Private Sub LoadExpirationData()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "
                SELECT 
                    et.tracking_id, 
                    p.product_name, 
                    et.expiration_date, 
                    DATEDIFF(et.expiration_date, CURDATE()) AS days_remaining,
                    et.quantity AS current_quantity,
                    CASE 
                        WHEN et.expiration_date < CURDATE() THEN 'Expired'
                        WHEN DATEDIFF(et.expiration_date, CURDATE()) <= 7 THEN 'Critical'
                        WHEN DATEDIFF(et.expiration_date, CURDATE()) <= 30 THEN 'Warning'
                        ELSE 'Good'
                    END AS status
                FROM expiration_tracking et
                JOIN products p ON et.product_id = p.product_id
                ORDER BY et.expiration_date ASC;"

                Dim dt As New DataTable()
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        dt.Load(reader)
                    End Using
                End Using
                dgvExpiration.DataSource = dt

                ' Apply conditional formatting based on expiration status
                ApplyConditionalFormatting()

                ' Check for expiring products
                CheckExpiringProducts()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading expiration data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ApplyConditionalFormatting()
        For Each row As DataGridViewRow In dgvExpiration.Rows
            If row.Index < 0 Then Continue For

            Dim status As String = If(row.Cells("status").Value IsNot Nothing, row.Cells("status").Value.ToString(), "")

            Select Case status
                Case "Expired"
                    row.DefaultCellStyle.BackColor = Color.Red
                    row.DefaultCellStyle.ForeColor = Color.White
                Case "Critical"
                    row.DefaultCellStyle.BackColor = Color.OrangeRed
                    row.DefaultCellStyle.ForeColor = Color.White
                Case "Warning"
                    row.DefaultCellStyle.BackColor = Color.Yellow
                    row.DefaultCellStyle.ForeColor = Color.Black
                Case "Good"
                    row.DefaultCellStyle.BackColor = Color.LightGreen
                    row.DefaultCellStyle.ForeColor = Color.Black
            End Select
        Next
    End Sub

    Private Sub CheckExpiringProducts()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "
                SELECT 
                    COUNT(*) AS expiring_count,
                    SUM(CASE WHEN DATEDIFF(expiration_date, CURDATE()) < 0 THEN 1 ELSE 0 END) AS expired_count,
                    SUM(CASE WHEN DATEDIFF(expiration_date, CURDATE()) BETWEEN 0 AND 7 THEN 1 ELSE 0 END) AS critical_count,
                    SUM(CASE WHEN DATEDIFF(expiration_date, CURDATE()) BETWEEN 8 AND 30 THEN 1 ELSE 0 END) AS warning_count
                FROM expiration_tracking
                WHERE DATEDIFF(expiration_date, CURDATE()) <= 30;"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim expiringCount As Integer = Convert.ToInt32(reader("expiring_count"))
                            Dim expiredCount As Integer = Convert.ToInt32(reader("expired_count"))
                            Dim criticalCount As Integer = Convert.ToInt32(reader("critical_count"))
                            Dim warningCount As Integer = Convert.ToInt32(reader("warning_count"))

                            If expiringCount > 0 Then
                                lblNotification.Visible = True
                                lblNotification.Text = $"ATTENTION: {expiredCount} expired product(s), {criticalCount} product(s) expiring within 7 days, and {warningCount} product(s) expiring within 30 days."
                                lblNotification.BackColor = If(expiredCount > 0, Color.LightPink, If(criticalCount > 0, Color.LightSalmon, Color.LightYellow))
                            Else
                                lblNotification.Visible = False
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            lblNotification.Visible = True
            lblNotification.Text = "Error checking expiring products."
            lblNotification.BackColor = Color.LightCoral
        End Try
    End Sub

    Private Sub dgvExpiration_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExpiration.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvExpiration.Rows(e.RowIndex)
            selectedTrackingId = If(IsDBNull(row.Cells("tracking_id").Value), -1, Convert.ToInt32(row.Cells("tracking_id").Value))
            txtProductName.Text = row.Cells("product_name").Value.ToString()
            txtQuantity.Text = row.Cells("current_quantity").Value.ToString()
            dtpExpirationDate.Value = If(IsDBNull(row.Cells("expiration_date").Value), DateTime.Now, Convert.ToDateTime(row.Cells("expiration_date").Value))
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Open product selection form
        Dim productSelectionForm As New ProductSelectionForm()
        If productSelectionForm.ShowDialog() = DialogResult.OK Then
            Dim selectedProductId As Integer = productSelectionForm.SelectedProductId
            Dim selectedProductName As String = productSelectionForm.SelectedProductName

            If selectedProductId > 0 Then
                txtProductName.Text = selectedProductName
                txtQuantity.Text = "0"
                dtpExpirationDate.Value = DateTime.Now.AddDays(30) ' Default to 30 days from now
                selectedTrackingId = -1 ' New entry
                End If
                End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If selectedTrackingId = -1 Then
            MessageBox.Show("Please select a record to edit.", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' We don't immediately update - just let the user know they're in edit mode
        MessageBox.Show("Now editing record. Make changes and click Save when done.", "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedTrackingId = -1 Then
            MessageBox.Show("Please select a record to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim confirmResult As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmResult = DialogResult.No Then Exit Sub

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "DELETE FROM expiration_tracking WHERE tracking_id = @tracking_id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@tracking_id", selectedTrackingId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Expiration entry deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            selectedTrackingId = -1
            txtProductName.Clear()
            txtQuantity.Clear()
            dtpExpirationDate.Value = DateTime.Now
            LoadExpirationData()
        Catch ex As Exception
            MessageBox.Show("Error deleting expiration entry: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDispose_Click(sender As Object, e As EventArgs) Handles btnDispose.Click
        If selectedTrackingId = -1 Then
            MessageBox.Show("Please select a record to dispose.", "Dispose Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim confirmResult As DialogResult = MessageBox.Show("Are you sure you want to dispose of this product? This will reduce inventory stock as well.", "Confirm Disposal", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmResult = DialogResult.No Then Exit Sub

        Try
            Dim productId As Integer = -1
            Dim productName As String = String.Empty
            Dim quantityToDispose As Integer = 0
            Dim expirationDate As DateTime

            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                
                ' Get product details from the tracking record
                Dim getDetailsQuery As String = "
                    SELECT et.product_id, p.product_name, et.quantity, et.expiration_date 
                    FROM expiration_tracking et
                    JOIN products p ON et.product_id = p.product_id
                    WHERE et.tracking_id = @tracking_id"
                
                Using cmd As New MySqlCommand(getDetailsQuery, conn)
                    cmd.Parameters.AddWithValue("@tracking_id", selectedTrackingId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            productId = Convert.ToInt32(reader("product_id"))
                            productName = reader("product_name").ToString()
                            quantityToDispose = Convert.ToInt32(reader("quantity"))
                            expirationDate = Convert.ToDateTime(reader("expiration_date"))
                        Else
                            MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End Using
                End Using

                ' Begin transaction to ensure all operations complete or none
                Dim transaction As MySqlTransaction = conn.BeginTransaction()
                
                Try
                    ' 1. Update inventory to reduce stock
                    Dim updateInventoryQuery As String = "
                        UPDATE inventory 
                        SET current_quantity = current_quantity - @quantity,
                            updated_at = NOW()
                        WHERE product_id = @product_id"
                    
                    Using cmd As New MySqlCommand(updateInventoryQuery, conn)
                        cmd.Transaction = transaction
                        cmd.Parameters.AddWithValue("@quantity", quantityToDispose)
                        cmd.Parameters.AddWithValue("@product_id", productId)
                        cmd.ExecuteNonQuery()
                    End Using
                    
                    ' 2. Delete the expiration tracking record
                    Dim deleteQuery As String = "DELETE FROM expiration_tracking WHERE tracking_id = @tracking_id"
                    Using cmd As New MySqlCommand(deleteQuery, conn)
                        cmd.Transaction = transaction
                        cmd.Parameters.AddWithValue("@tracking_id", selectedTrackingId)
                        cmd.ExecuteNonQuery()
                    End Using
                    
                    ' 3. Record in stock movements
                    Dim stockMovementQuery As String = "
                        INSERT INTO stock_movements 
                        (product_id, movement_type, quantity, reference_id, movement_date, performed_by, notes)
                        VALUES 
                        (@product_id, 'disposal', @quantity, @reference_id, NOW(), 8, @notes)"
                    
                    Using cmd As New MySqlCommand(stockMovementQuery, conn)
                        cmd.Transaction = transaction
                        cmd.Parameters.AddWithValue("@product_id", productId)
                        cmd.Parameters.AddWithValue("@quantity", quantityToDispose)
                        cmd.Parameters.AddWithValue("@reference_id", "DISP-" & DateTime.Now.ToString("yyyyMMddHHmmss"))
                        cmd.Parameters.AddWithValue("@notes", "Disposed due to expiration - Date: " & expirationDate.ToString("yyyy-MM-dd"))
                        cmd.ExecuteNonQuery()
                    End Using
                    
                    ' 4. Record in audit trail
                    Dim auditQuery As String = "
                        INSERT INTO audittrail 
                        (Role, FullName, Action, Form, Date)
                        VALUES 
                        (@role, @fullname, @action, @form, NOW())"
                    
                    Using cmd As New MySqlCommand(auditQuery, conn)
                        cmd.Transaction = transaction
                        cmd.Parameters.AddWithValue("@role", "Admin") ' Default to Admin or get from current user
                        cmd.Parameters.AddWithValue("@fullname", "Administrator") ' Default or get from current user
                        cmd.Parameters.AddWithValue("@action", $"Disposed {quantityToDispose} units of '{productName}' with expiration date {expirationDate.ToString("yyyy-MM-dd")}")
                        cmd.Parameters.AddWithValue("@form", "ExpirationMain")
                        cmd.ExecuteNonQuery()
                    End Using
                    
                    ' Commit all changes
                    transaction.Commit()
                    
                    MessageBox.Show($"{quantityToDispose} units of '{productName}' have been disposed successfully. Inventory has been updated.", "Disposal Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    
                    ' Clear selection and refresh
                    selectedTrackingId = -1
                    txtProductName.Clear()
                    txtQuantity.Clear()
                    dtpExpirationDate.Value = DateTime.Now
                    LoadExpirationData()
                    
                Catch ex As Exception
                    ' Roll back all changes if any operation fails
                    transaction.Rollback()
                    MessageBox.Show("Error during disposal process: " & ex.Message, "Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show("Error disposing of product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadExpirationData()
        MessageBox.Show("Expiration data refreshed.", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnCheckExpiring_Click(sender As Object, e As EventArgs) Handles btnCheckExpiring.Click
        ' Filter to show only soon-to-expire products
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "
                SELECT 
                    et.tracking_id, 
                    p.product_name, 
                    et.expiration_date, 
                    DATEDIFF(et.expiration_date, CURDATE()) AS days_remaining,
                    et.quantity AS current_quantity,
                    CASE 
                        WHEN et.expiration_date < CURDATE() THEN 'Expired'
                        WHEN DATEDIFF(et.expiration_date, CURDATE()) <= 7 THEN 'Critical'
                        WHEN DATEDIFF(et.expiration_date, CURDATE()) <= 30 THEN 'Warning'
                        ELSE 'Good'
                    END AS status
                FROM expiration_tracking et
                JOIN products p ON et.product_id = p.product_id
                WHERE DATEDIFF(et.expiration_date, CURDATE()) <= 30
                ORDER BY et.expiration_date ASC;"

                Dim dt As New DataTable()
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        dt.Load(reader)
                    End Using
                End Using

                dgvExpiration.DataSource = dt
                ApplyConditionalFormatting()

                If dt.Rows.Count > 0 Then
                    MessageBox.Show($"Found {dt.Rows.Count} products expiring within 30 days.", "Expiration Check", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("No products are expiring within the next 30 days.", "Expiration Check", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking expiring products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInputs() Then Exit Sub

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Get product ID from product name
                Dim productId As Integer = -1
                Dim getProductQuery As String = "SELECT product_id FROM products WHERE product_name = @product_name"
                Using cmd As New MySqlCommand(getProductQuery, conn)
                    cmd.Parameters.AddWithValue("@product_name", txtProductName.Text)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing Then productId = Convert.ToInt32(result)
                End Using

                If productId = -1 Then
                    MessageBox.Show("Product not found in database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                If selectedTrackingId = -1 Then
                    ' New record - check if it already exists with same date
                    Dim checkQuery As String = "SELECT COUNT(*) FROM expiration_tracking WHERE product_id = @product_id AND expiration_date = @expiration_date"
                    Dim recordExists As Boolean = False

                    Using cmd As New MySqlCommand(checkQuery, conn)
                        cmd.Parameters.AddWithValue("@product_id", productId)
                        cmd.Parameters.AddWithValue("@expiration_date", dtpExpirationDate.Value.Date)
                        recordExists = Convert.ToInt32(cmd.ExecuteScalar()) > 0
                    End Using

                    If recordExists Then
                        ' Update existing record quantity
                        Dim updateQuery As String = "UPDATE expiration_tracking SET quantity = quantity + @quantity WHERE product_id = @product_id AND expiration_date = @expiration_date"
                        Using cmd As New MySqlCommand(updateQuery, conn)
                            cmd.Parameters.AddWithValue("@product_id", productId)
                            cmd.Parameters.AddWithValue("@expiration_date", dtpExpirationDate.Value.Date)
                            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text))
                            cmd.ExecuteNonQuery()
                        End Using
                        MessageBox.Show("Existing record updated with additional quantity!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        ' Insert new record
                        Dim insertQuery As String = "INSERT INTO expiration_tracking (product_id, expiration_date, quantity) VALUES (@product_id, @expiration_date, @quantity)"
                        Using cmd As New MySqlCommand(insertQuery, conn)
                            cmd.Parameters.AddWithValue("@product_id", productId)
                            cmd.Parameters.AddWithValue("@expiration_date", dtpExpirationDate.Value.Date)
                            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text))
                            cmd.ExecuteNonQuery()
                        End Using
                        MessageBox.Show("New expiration entry saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    ' Update existing record
                    Dim updateQuery As String = "UPDATE expiration_tracking SET expiration_date = @expiration_date, quantity = @quantity WHERE tracking_id = @tracking_id"
                    Using cmd As New MySqlCommand(updateQuery, conn)
                        cmd.Parameters.AddWithValue("@expiration_date", dtpExpirationDate.Value.Date)
                        cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text))
                        cmd.Parameters.AddWithValue("@tracking_id", selectedTrackingId)
                        cmd.ExecuteNonQuery()
                    End Using
                    MessageBox.Show("Expiration entry updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                ' Refresh the data
                LoadExpirationData()

                ' Clear inputs
                txtProductName.Clear()
                txtQuantity.Clear()
                dtpExpirationDate.Value = DateTime.Now.AddDays(30)
                selectedTrackingId = -1
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving expiration entry: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Validate user inputs
    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtProductName.Text) Then
            MessageBox.Show("Please select a valid product.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtQuantity.Text) OrElse Not Integer.TryParse(txtQuantity.Text, Nothing) Then
            MessageBox.Show("Please enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Sub lblProductName_Click(sender As Object, e As EventArgs) Handles lblProductName.Click

    End Sub
End Class

' Product Selection Form for adding new expiration entries
Public Class ProductSelectionForm
    Inherits System.Windows.Forms.Form
    
    Private connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Public SelectedProductId As Integer = -1
    Public SelectedProductName As String = ""
    
    Private dgvProducts As DataGridView
    Private txtSearch As TextBox
    Private btnSelect, btnCancel As Button
    
    Public Sub New()
        ' Initialize form
        Me.Text = "Select Product"
        Me.Width = 600
        Me.Height = 500
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        
        ' Search box
        Dim lblSearch As New Label With {
            .Text = "Search Product:",
            .Location = New Point(20, 20),
            .Size = New Size(100, 25)
        }
        
        txtSearch = New TextBox With {
            .Location = New Point(130, 20),
            .Size = New Size(280, 25)
        }
        AddHandler txtSearch.TextChanged, AddressOf TxtSearch_TextChanged
        
        ' Products grid
        dgvProducts = New DataGridView With {
            .Location = New Point(20, 60),
            .Size = New Size(540, 350),
            .ReadOnly = True,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .MultiSelect = False,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        }
        AddHandler dgvProducts.CellDoubleClick, AddressOf DgvProducts_CellDoubleClick
        
        ' Buttons
        btnSelect = New Button With {
            .Text = "Select",
            .Location = New Point(300, 420),
            .Size = New Size(120, 30)
        }
        AddHandler btnSelect.Click, AddressOf BtnSelect_Click
        
        btnCancel = New Button With {
            .Text = "Cancel",
            .Location = New Point(440, 420),
            .Size = New Size(120, 30)
        }
        AddHandler btnCancel.Click, AddressOf BtnCancel_Click
        
        ' Add controls to form
        Me.Controls.AddRange(New Control() {lblSearch, txtSearch, dgvProducts, btnSelect, btnCancel})
        
        ' Load products
        LoadProducts()
    End Sub
    
    Private Sub LoadProducts()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "
                SELECT 
                    p.product_id, 
                    p.product_name,
                    p.barcode,
                    p.expiration_option,
                    IFNULL(SUM(i.current_quantity), 0) AS stock_level
                FROM products p
                LEFT JOIN inventory i ON p.product_id = i.product_id
                WHERE p.expiration_option = 'With Expiration'
                GROUP BY p.product_id, p.product_name, p.barcode, p.expiration_option
                HAVING stock_level > 0
                ORDER BY p.product_name;"
                
                Dim dt As New DataTable()
                Using cmd As New MySqlCommand(query, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
                
                dgvProducts.DataSource = dt
                
                ' Hide product_id column
                If dgvProducts.Columns.Contains("product_id") Then
                    dgvProducts.Columns("product_id").Visible = False
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs)
        ' Filter the DataGridView based on search text
        If dgvProducts.DataSource IsNot Nothing Then
            Dim dt As DataTable = DirectCast(dgvProducts.DataSource, DataTable)
            Dim dv As New DataView(dt)
            
            If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
                dv.RowFilter = $"product_name LIKE '%{txtSearch.Text}%' OR barcode LIKE '%{txtSearch.Text}%'"
            Else
                dv.RowFilter = String.Empty
            End If
            
            dgvProducts.DataSource = dv.ToTable()
        End If
    End Sub
    
    Private Sub DgvProducts_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            SelectProduct()
        End If
    End Sub
    
    Private Sub BtnSelect_Click(sender As Object, e As EventArgs)
        SelectProduct()
    End Sub
    
    Private Sub SelectProduct()
        If dgvProducts.CurrentRow IsNot Nothing Then
            SelectedProductId = Convert.ToInt32(dgvProducts.CurrentRow.Cells("product_id").Value)
            SelectedProductName = dgvProducts.CurrentRow.Cells("product_name").Value.ToString()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Please select a product.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
