Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class CategoryMain
    Inherits Form

    Private connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private connection As MySqlConnection

    Public Sub New()
        InitializeComponent() ' Only calls the designer-generated UI
        connection = New MySqlConnection(connectionString)
    End Sub

    Private Sub CategoryMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set Button Colors
        ' Load Categories
        LoadCategories()
        CustomizeDataGridView()
    End Sub

    ' Load Categories into DataGridView
    ' ✅ Load Categories into DataGridView
    Private Sub LoadCategories()
        Try
            If connection.State = ConnectionState.Closed Then connection.Open()
            Dim query As String = "SELECT category_id, category_name, description, created_at, updated_at FROM categories"
            Dim cmd As New MySqlCommand(query, connection)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            dgvCategories.DataSource = dt

            ' Rename columns
            dgvCategories.Columns("category_id").HeaderText = "Category ID"
            dgvCategories.Columns("category_name").HeaderText = "Category Name"
            dgvCategories.Columns("description").HeaderText = "Description"
            dgvCategories.Columns("created_at").HeaderText = "Created At"
            dgvCategories.Columns("updated_at").HeaderText = "Updated At"

            ' Hide category_id
            dgvCategories.Columns("category_id").Visible = False

            CustomizeDataGridView()
        Catch ex As Exception
            MessageBox.Show("Error loading categories: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub CustomizeDataGridView()
        With dgvCategories
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

            ' Auto-size columns
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Adjust column width manually (Only if columns exist)
            If .Columns.Count > 0 Then
                ' Align numeric values to the right
                .Columns("created_at").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("updated_at").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
        End With
    End Sub



    ' Validate Inputs Function
    Private Function ValidateInputs() As Boolean
        ' Check if the Category Name is empty
        If String.IsNullOrWhiteSpace(txtCategoryName.Text) Then
            MessageBox.Show("Category name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Check if the Category Name is unique
        If Not IsCategoryNameUnique(txtCategoryName.Text) Then
            MessageBox.Show("Category name must be unique.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Check if the Description is empty
        If String.IsNullOrWhiteSpace(txtDescription.Text) Then
            MessageBox.Show("Description is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Check if the Description is unique
        If Not IsDescriptionUnique(txtDescription.Text) Then
            MessageBox.Show("Description must be unique.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function


    ' Check if the description is unique
    Private Function IsDescriptionUnique(description As String) As Boolean
        Try
            If connection.State = ConnectionState.Closed Then connection.Open()
            Dim query As String = "SELECT COUNT(*) FROM categories WHERE description = @description"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@description", description)
            Dim result As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return result = 0
        Catch ex As Exception
            MessageBox.Show("Error checking description uniqueness: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            connection.Close()
        End Try
    End Function



    ' Check if the category name is unique
    Private Function IsCategoryNameUnique(categoryName As String) As Boolean
        Try
            If connection.State = ConnectionState.Closed Then connection.Open()

            ' Query to check for the existence of the category name in the database
            Dim query As String = "SELECT COUNT(*) FROM categories WHERE category_name = @categoryName"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@categoryName", categoryName)

            ' Execute the query and check if the category name exists
            Dim result As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            ' If result > 0, the category name is already taken
            Return result = 0
        Catch ex As Exception
            MessageBox.Show("Error checking category name uniqueness: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            connection.Close()
        End Try
    End Function

    ' Add Category
    ' ✅ Add Category with Audit Trail
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ValidateInputs() Then Exit Sub

        Try
            If connection.State = ConnectionState.Closed Then connection.Open()
            Dim query As String = "INSERT INTO categories (category_name, description) VALUES (@name, @description)"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@name", txtCategoryName.Text.Trim)
                cmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' ✅ Log Audit Trail
            Logaudittrail(SessionData.role, SessionData.fullName, "Added a new category: " & txtCategoryName.Text)

            LoadCategories()
        Catch ex As Exception
            MessageBox.Show("Error adding category: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then connection.Close()
        End Try
        ResetFields()
        PanelCategory.Visible = False
    End Sub

    ' ✅ Edit Category with Audit Trail
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If String.IsNullOrWhiteSpace(txtCategoryId.Text) OrElse String.IsNullOrWhiteSpace(txtCategoryName.Text) OrElse String.IsNullOrWhiteSpace(txtDescription.Text) Then
            MessageBox.Show("Please select a category and fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            If connection.State = ConnectionState.Closed Then connection.Open()

            ' ✅ Get the old category details before updating (for logging purposes)
            Dim oldCategoryName As String = ""
            Dim oldDescription As String = ""
            Dim getOldQuery As String = "SELECT category_name, description FROM categories WHERE category_id = @id"
            Using getCmd As New MySqlCommand(getOldQuery, connection)
                getCmd.Parameters.AddWithValue("@id", txtCategoryId.Text.Trim)
                Using reader As MySqlDataReader = getCmd.ExecuteReader()
                    If reader.Read() Then
                        oldCategoryName = reader("category_name").ToString()
                        oldDescription = reader("description").ToString()
                    Else
                        MessageBox.Show("Category not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End Using
            End Using

            ' ✅ Update category
            Dim query As String = "UPDATE categories SET category_name = @name, description = @description WHERE category_id = @id"
            Dim rowsAffected As Integer
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@id", txtCategoryId.Text.Trim)
                cmd.Parameters.AddWithValue("@name", txtCategoryName.Text.Trim)
                cmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim)
                rowsAffected = cmd.ExecuteNonQuery()
            End Using

            ' ✅ Check if any rows were updated
            If rowsAffected > 0 Then
                MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' ✅ Log Audit Trail (Only log if changes were made)
                Dim changes As String = ""
                If oldCategoryName <> txtCategoryName.Text.Trim Then
                    changes &= $"Name changed from '{oldCategoryName}' to '{txtCategoryName.Text.Trim}'. "
                End If
                If oldDescription <> txtDescription.Text.Trim Then
                    changes &= $"Description changed from '{oldDescription}' to '{txtDescription.Text.Trim}'."
                End If
                If changes <> "" Then
                    Logaudittrail(SessionData.role, SessionData.fullName, "Updated category: " & changes)
                End If

                ' ✅ Refresh the data grid or list
                LoadCategories()
            Else
                MessageBox.Show("No changes detected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error updating category: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then connection.Close()
        End Try
        ResetFields()
        PanelCategory.Visible = False
    End Sub


    ' ✅ Delete Category with Audit Trail
    ' Delete Category with Audit Trail
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Validate if a category is selected
        If String.IsNullOrWhiteSpace(txtCategoryId.Text) Then
            MessageBox.Show("Please select a category to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Confirm delete action
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.No Then
            Exit Sub
        End If

        Try
            If connection.State = ConnectionState.Closed Then connection.Open()

            ' Get the category name before deleting (for logging purposes)
            Dim categoryName As String = ""
            Dim getCategoryNameQuery As String = "SELECT category_name FROM categories WHERE category_id = @id"
            Using getCmd As New MySqlCommand(getCategoryNameQuery, connection)
                getCmd.Parameters.AddWithValue("@id", txtCategoryId.Text.Trim)
                Using reader As MySqlDataReader = getCmd.ExecuteReader()
                    If reader.Read() Then
                        categoryName = reader("category_name").ToString()
                    Else
                        MessageBox.Show("Category not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End Using
            End Using

            ' Delete the category
            Dim deleteQuery As String = "DELETE FROM categories WHERE category_id = @id"
            Using deleteCmd As New MySqlCommand(deleteQuery, connection)
                deleteCmd.Parameters.AddWithValue("@id", txtCategoryId.Text.Trim)
                deleteCmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' ✅ Log Audit Trail
            Logaudittrail(SessionData.role, SessionData.fullName, "Deleted category: " & categoryName)

            ' Reload categories
            LoadCategories()

        Catch ex As Exception
            MessageBox.Show("Error deleting category: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then connection.Close()
        End Try
        ResetFields()
        PanelCategory.Visible = False
    End Sub



    ' Prevent numbers from being entered in Category Name and Description
    Private Sub txtCategoryName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCategoryName.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = True ' Block the key press
        End If
    End Sub

    Private Sub txtDescription_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescription.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = True ' Block the key press
        End If
    End Sub


    ' Reset Fields

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnAddcat.Click
        PanelCategory.Visible = True
    End Sub

    Private Sub PanelCategory_Paint(sender As Object, e As PaintEventArgs) Handles PanelCategory.Paint
        ' Siguraduhin na ang PanelCategory ay nasa gitna ng form
        Dim x As Integer = (Me.ClientSize.Width - PanelCategory.Width) \ 2
        Dim y As Integer = (Me.ClientSize.Height - PanelCategory.Height) \ 2
        PanelCategory.Location = New Point(x, y)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PanelCategory.Visible = False
    End Sub


    ' ✅ Log Audit Trail
    Private Sub Logaudittrail(ByVal role As String, ByVal fullName As String, ByVal action As String)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "INSERT INTO audittrail (Role, FullName, Action, Form, Date) VALUES (@Role, @FullName, @action, @Form, @Date)"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@Role", role)
                    cmd.Parameters.AddWithValue("@FullName", fullName)
                    cmd.Parameters.AddWithValue("@action", action)
                    cmd.Parameters.AddWithValue("@Form", "CategoryMain")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvCategories_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCategories.CellClick
        ' Siguraduhin na ang napiling row ay valid
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvCategories.Rows(e.RowIndex)

            ' Punan ang mga TextBox gamit ang data mula sa napiling row
            txtCategoryId.Text = row.Cells("category_id").Value.ToString()
            txtCategoryName.Text = row.Cells("category_name").Value.ToString()
            txtDescription.Text = row.Cells("description").Value.ToString()
        End If
        PanelCategory.Visible = True
    End Sub
    ' Reset Fields Function
    Private Sub ResetFields()
        txtCategoryId.Clear()
        txtCategoryName.Clear()
        txtDescription.Clear()
        PanelCategory.Visible = False
        dgvCategories.ClearSelection() ' Deselect any selected row
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
