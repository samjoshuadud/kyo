Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Drawing

Public Class SalesReportForm
    Inherits Form

    Private connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private connection As MySqlConnection
    Private dgvSalesReport As DataGridView
    Private dtpStartDate, dtpEndDate As DateTimePicker
    Private btnGenerateReport As Button
    Private pnlSummary As Panel
    Private lblTotalSales, lblTotalDiscount, lblTotalVAT, lblNetTotal As Label

    Public Sub New()
        InitializeComponent()
        Me.Width = 1020
        Me.Height = 800 ' Increased the height of the form
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = ColorTranslator.FromHtml("#F5F5F5") ' Light gray background

        InitializeUI()
        connection = New MySqlConnection(connectionString)
    End Sub

    Private Sub InitializeUI()
        ' Common Fonts and Colors
        Dim labelFont As New Font("Segoe UI", 10)
        Dim headerFont As New Font("Segoe UI", 12, FontStyle.Bold)
        Dim labelColor As Color = ColorTranslator.FromHtml("#0D47A1") ' Dark blue for labels

        ' Date Pickers for report range
        Dim pnlDateSelectors As New Panel With {
            .Location = New Point(20, 20),
            .Size = New Size(950, 60), ' Adjusted panel size to reduce height
            .BackColor = ColorTranslator.FromHtml("#E3F2FD"), ' Light blue background for date selector
            .BorderStyle = BorderStyle.FixedSingle
        }

        Dim lblStartDate As New Label With {.Text = "Start Date:", .Location = New Point(20, 20), .Width = 80, .Font = labelFont, .ForeColor = labelColor}
        dtpStartDate = New DateTimePicker With {.Location = New Point(110, 15), .Format = DateTimePickerFormat.Short, .Font = labelFont}

        Dim lblEndDate As New Label With {.Text = "End Date:", .Location = New Point(320, 20), .Width = 80, .Font = labelFont, .ForeColor = labelColor}
        dtpEndDate = New DateTimePicker With {.Location = New Point(410, 15), .Format = DateTimePickerFormat.Short, .Font = labelFont}

        btnGenerateReport = New Button With {
            .Text = "Generate Report",
            .Location = New Point(650, 15),
            .Width = 200,
            .Height = 30,
            .Font = labelFont,
            .BackColor = ColorTranslator.FromHtml("#4CAF50"), ' Green background for button
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        AddHandler btnGenerateReport.Click, AddressOf BtnGenerateReport_Click

        pnlDateSelectors.Controls.AddRange(New Control() {lblStartDate, dtpStartDate, lblEndDate, dtpEndDate, btnGenerateReport})
        Me.Controls.Add(pnlDateSelectors)

        ' DataGridView for Sales Report
        dgvSalesReport = New DataGridView With {
            .Location = New Point(20, 100),
            .Width = 950,
            .Height = 400, ' Reduced height of DataGridView
            .ReadOnly = True,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            .AlternatingRowsDefaultCellStyle = New DataGridViewCellStyle With {
                .BackColor = ColorTranslator.FromHtml("#F1F8E9") ' Light green alternating row color for better readability
            }
        }
        Me.Controls.Add(dgvSalesReport)

        ' Summary Panel
        pnlSummary = New Panel With {
            .Location = New Point(20, 520),
            .Width = 950,
            .Height = 120,
            .BorderStyle = BorderStyle.FixedSingle,
            .BackColor = ColorTranslator.FromHtml("#FFF3E0") ' Light orange background for summary
        }

        lblTotalSales = New Label With {.Text = "Total Sales: 0.00", .Location = New Point(20, 20), .Width = 300, .Font = headerFont, .ForeColor = labelColor}
        lblTotalDiscount = New Label With {.Text = "Total Discount: 0.00", .Location = New Point(320, 20), .Width = 300, .Font = headerFont, .ForeColor = labelColor}
        lblTotalVAT = New Label With {.Text = "Total VAT: 0.00", .Location = New Point(20, 60), .Width = 300, .Font = headerFont, .ForeColor = labelColor}
        lblNetTotal = New Label With {.Text = "Net Total: 0.00", .Location = New Point(320, 60), .Width = 300, .Font = headerFont, .ForeColor = labelColor}

        pnlSummary.Controls.AddRange(New Control() {lblTotalSales, lblTotalDiscount, lblTotalVAT, lblNetTotal})
        Me.Controls.Add(pnlSummary)
    End Sub
    ' Generate Report Button Click Event
    Private Sub BtnGenerateReport_Click(sender As Object, e As EventArgs)
        LoadSalesData()
    End Sub

    ' Load Sales Data from Database
    Private Sub LoadSalesData()
        Try
            ' Ensure the connection is open
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            ' Prepare the SQL query
            Dim query As String = "SELECT sale_date, transaction_number, COALESCE(total_amount, 0) AS total_amount, " &
                              "COALESCE(discount_amount, 0) AS discount_amount, COALESCE(vat_amount, 0) AS vat_amount, " &
                              "COALESCE(net_amount, 0) AS net_amount " &
                              "FROM sales " &
                              "WHERE sale_date BETWEEN @start_date AND @end_date"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@start_date", dtpStartDate.Value.Date)
            cmd.Parameters.AddWithValue("@end_date", dtpEndDate.Value.Date)

            ' Fill the DataTable with query results
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            ' Set the DataGridView DataSource
            dgvSalesReport.DataSource = Nothing ' Clear the old data source
            dgvSalesReport.DataSource = dt

            ' Check if there are any rows in the DataTable
            If dt.Rows.Count = 0 Then
                MessageBox.Show("No records found for the selected date range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ' Update Summary Labels
            Dim totalSales As Decimal = dt.AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("total_amount"))
            Dim totalDiscount As Decimal = dt.AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("discount_amount"))
            Dim totalVAT As Decimal = dt.AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("vat_amount"))
            Dim netTotal As Decimal = dt.AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("net_amount"))

            lblTotalSales.Text = $"Total Sales: ₱{totalSales:N2}"
            lblTotalDiscount.Text = $"Total Discount: ₱{totalDiscount:N2}"
            lblTotalVAT.Text = $"Total VAT: ₱{totalVAT:N2}"
            lblNetTotal.Text = $"Net Total: ₱{netTotal:N2}"


        Catch ex As Exception
            ' Display error message with details
            MessageBox.Show("Error loading sales data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Ensure the connection is closed properly
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub SalesReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class