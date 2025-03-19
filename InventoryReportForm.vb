Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Drawing

Public Class InventoryReportForm
    Inherits Form

    Private connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private dgvInventoryReport As DataGridView
    Private btnRefresh As Button
    Private lblLowStockItems As Label

    Public Sub New()
        InitializeComponent()
        Me.Text = "Inventory Report"
        Me.Width = 800
        Me.Height = 600
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = ColorTranslator.FromHtml("#F5F5F5")

        InitializeUI()
        LoadInventoryData() ' Load inventory data initially
    End Sub

    Private Sub InitializeUI()
        ' Panel for Controls and Refresh Button
        Dim pnlTop As New Panel With {
            .Location = New Point(20, 20),
            .Size = New Size(740, 50),
            .BackColor = ColorTranslator.FromHtml("#E3F2FD")
        }

        ' Refresh Button
        btnRefresh = New Button With {
            .Text = "Refresh",
            .Location = New Point(600, 10),
            .Width = 120,
            .Height = 30,
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .BackColor = ColorTranslator.FromHtml("#4CAF50"),
            .ForeColor = Color.White
        }
        AddHandler btnRefresh.Click, AddressOf BtnRefresh_Click
        pnlTop.Controls.Add(btnRefresh)

        ' DataGridView for Inventory Report
        dgvInventoryReport = New DataGridView With {
            .Location = New Point(20, 90),
            .Width = 740,
            .Height = 400,
            .ReadOnly = True,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False
        }

        ' Label for Low Stock Alert
        lblLowStockItems = New Label With {
            .Text = "Low Stock Items: ",
            .Location = New Point(20, 510),
            .Width = 740,
            .Font = New Font("Segoe UI", 10, FontStyle.Bold)
        }

        ' Add Controls to Form
        Me.Controls.AddRange(New Control() {pnlTop, dgvInventoryReport, lblLowStockItems})
    End Sub

    ' Refresh Button Click Event
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs)
        LoadInventoryData()
    End Sub

    ' Load Inventory Data from Database
    ' Load Inventory Data from Database
    Private Sub LoadInventoryData()
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                ' Query to get inventory data with product name, quantity, and category
                Dim query As String = "SELECT p.product_name AS 'Product Name', i.current_quantity AS 'Current Quantity', c.category_name AS 'Category' 
                                   FROM inventory i
                                   JOIN products p ON i.product_id = p.product_id
                                   JOIN categories c ON p.category_id = c.category_id
                                   ORDER BY p.product_name ASC"
                Dim cmd As New MySqlCommand(query, connection)
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                ' Set the DataGridView DataSource
                dgvInventoryReport.DataSource = dt

                ' Create a list to hold low stock items
                Dim lowStockItems As New List(Of String)

                ' Highlight rows with low stock and collect low stock products
                For Each row As DataGridViewRow In dgvInventoryReport.Rows
                    If Convert.ToInt32(row.Cells("Current Quantity").Value) < 5 Then
                        row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFCDD2") ' Light red for low stock items
                        lowStockItems.Add(row.Cells("Product Name").Value.ToString()) ' Add product to low stock list
                    End If
                Next

                ' Update the label to show the list of low stock products
                If lowStockItems.Count > 0 Then
                    lblLowStockItems.Text = "Low Stock Items: " & String.Join(", ", lowStockItems)
                Else
                    lblLowStockItems.Text = "No low stock items."
                End If

            Catch ex As Exception
                MessageBox.Show("Error loading inventory data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub InventoryReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
