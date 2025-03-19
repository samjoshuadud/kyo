Imports MySql.Data.MySqlClient

Public Class VatMain
    Private connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private connection As MySqlConnection
    Private selectedVatId As Integer = -1 ' Tracks the selected VAT ID

    ' UI Controls
    Private dgvVat As DataGridView
    Private txtVatRate As TextBox

    Private btnAdd, btnEdit, btnDelete, btnClose As Button
    Private pnlInputs As Panel ' Panel for input fields

    Public Sub New()
        InitializeComponent()
        ' Initialize form properties
        Me.Text = "VAT Management"
        Me.Width = 600
        Me.Height = 500
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = ColorTranslator.FromHtml("#B2DFEE") ' Light blue for styling

        InitializeUI()
        connection = New MySqlConnection(connectionString)

        ' Load VAT data into the grid
        LoadVATData()
    End Sub

    Private Sub InitializeUI()
        ' DataGridView for VAT rates
        dgvVat = New DataGridView With {
        .Location = New Point(20, 20),
        .Width = 540,
        .Height = 200,
        .ReadOnly = True,
        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    }
        AddHandler dgvVat.CellClick, AddressOf DgvVat_CellClick

        ' Panel to encapsulate input fields
        pnlInputs = New Panel With {
        .Location = New Point(20, 240),
        .Width = 540,
        .Height = 100,  ' Reduce height to fit only VAT Rate input
        .BorderStyle = BorderStyle.FixedSingle,
        .BackColor = ColorTranslator.FromHtml("#FFFFFF") ' Baseline surface color for inputs panel
    }

        ' VAT Rate Input
        Dim lblVatRate As New Label With {
        .Text = "VAT Rate (%):",
        .Location = New Point(10, 20),
        .Font = New Font("Segoe UI", 10, FontStyle.Bold)
    }
        txtVatRate = New TextBox With {
        .Location = New Point(150, 20),
        .Width = 200
    }

        ' Add VAT Rate input to the panel
        pnlInputs.Controls.AddRange(New Control() {lblVatRate, txtVatRate})

        ' Buttons
        btnAdd = New Button With {
        .Text = "Add",
        .Location = New Point(20, 410),
        .Width = 100,
        .BackColor = ColorTranslator.FromHtml("#B00020"), ' Baseline error color for adding
        .FlatStyle = FlatStyle.Flat,
        .ForeColor = Color.White
    }
        AddHandler btnAdd.Click, AddressOf BtnAdd_Click

        btnEdit = New Button With {
        .Text = "Edit",
        .Location = New Point(140, 410),
        .Width = 100,
        .BackColor = ColorTranslator.FromHtml("#B00020"), ' Baseline error color for editing
        .FlatStyle = FlatStyle.Flat,
        .ForeColor = Color.White
    }
        AddHandler btnEdit.Click, AddressOf BtnEdit_Click

        btnDelete = New Button With {
        .Text = "Delete",
        .Location = New Point(260, 410),
        .Width = 100,
        .BackColor = ColorTranslator.FromHtml("#B00020"), ' Baseline error color for deleting
        .FlatStyle = FlatStyle.Flat,
        .ForeColor = Color.White
    }
        AddHandler btnDelete.Click, AddressOf BtnDelete_Click

        btnClose = New Button With {
        .Text = "Close",
        .Location = New Point(380, 410),
        .Width = 100,
        .BackColor = ColorTranslator.FromHtml("#B00020"), ' Baseline error color for closing
        .FlatStyle = FlatStyle.Flat,
        .ForeColor = Color.White
    }
        AddHandler btnClose.Click, AddressOf BtnClose_Click

        ' Add controls to the form
        Me.Controls.AddRange(New Control() {dgvVat, pnlInputs, btnAdd, btnEdit, btnDelete, btnClose})

        ' Apply Baseline background color
        Me.BackColor = ColorTranslator.FromHtml("#FFFFFF") ' Baseline background color for the form
    End Sub



    ' Load VAT data into the grid
    ' Load VAT data into the grid
    Private Sub LoadVATData()
        Try
            ' Open the connection if it's closed
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            ' Modify the SELECT statement to exclude effective_date and only select vat_id and vat_rate
            Dim query As String = "SELECT vat_id, vat_rate FROM vat"
            Dim cmd As New MySqlCommand(query, connection)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            ' Load data into DataTable
            Dim dt As New DataTable()
            dt.Load(reader)
            dgvVat.DataSource = dt

            ' Close the reader
            reader.Close()

            ' Hide the vat_id column after loading the data
            If dgvVat.Columns.Contains("vat_id") Then
                dgvVat.Columns("vat_id").Visible = False
            End If

        Catch ex As Exception
            ' Show an error message if an exception occurs
            MessageBox.Show("Error loading VAT data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Ensure the connection is closed after the operation
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub






    ' Handle row selection in the grid
    Private Sub DgvVat_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvVat.Rows(e.RowIndex)
            selectedVatId = Convert.ToInt32(row.Cells("vat_id").Value)
            txtVatRate.Text = row.Cells("vat_rate").Value.ToString()

        End If
    End Sub

    ' Add new VAT rate
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs)
        If Not ValidateInputs() Then Exit Sub

        Try
            connection.Open()
            Dim query As String = "INSERT INTO vat (vat_rate) VALUES (@vat_rate)" ' No effective_date now
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@vat_rate", Convert.ToDecimal(txtVatRate.Text))
            cmd.ExecuteNonQuery()

            MessageBox.Show("VAT rate added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadVATData()
        Catch ex As Exception
            MessageBox.Show("Error adding VAT rate: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub


    ' Edit selected VAT rate
    ' Edit selected VAT rate
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs)
        If selectedVatId = -1 Then
            MessageBox.Show("Please select a VAT rate to edit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidateInputs() Then Exit Sub

        Try
            connection.Open()
            ' Update query to exclude effective_date
            Dim query As String = "UPDATE vat SET vat_rate = @vat_rate WHERE vat_id = @vat_id"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@vat_rate", Convert.ToDecimal(txtVatRate.Text))
            cmd.Parameters.AddWithValue("@vat_id", selectedVatId)
            cmd.ExecuteNonQuery()

            MessageBox.Show("VAT rate updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadVATData()
        Catch ex As Exception
            MessageBox.Show("Error updating VAT rate: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub


    ' Delete selected VAT rate
    ' Delete selected VAT rate
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs)
        If selectedVatId = -1 Then
            MessageBox.Show("Please select a VAT rate to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            connection.Open()
            Dim query As String = "DELETE FROM vat WHERE vat_id = @vat_id"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@vat_id", selectedVatId)
            cmd.ExecuteNonQuery()

            MessageBox.Show("VAT rate deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadVATData()
        Catch ex As Exception
            MessageBox.Show("Error deleting VAT rate: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub


    ' Close the form
    Private Sub BtnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    ' Validate user inputs
    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtVatRate.Text) OrElse Not Decimal.TryParse(txtVatRate.Text, Nothing) Then
            MessageBox.Show("Please enter a valid VAT rate.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If Convert.ToDecimal(txtVatRate.Text) < 0 OrElse Convert.ToDecimal(txtVatRate.Text) > 100 Then
            MessageBox.Show("VAT rate must be between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Sub VatMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadVATData()
    End Sub
End Class
