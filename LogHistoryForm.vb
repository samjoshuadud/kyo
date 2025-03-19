Imports MySql.Data.MySqlClient

Public Class LogHistoryForm
    Private connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private connection As MySqlConnection

    Public Sub New()
        InitializeComponent()
        connection = New MySqlConnection(connectionString)
    End Sub

    ' Load Log History Data
    Private Sub LoadLogHistory()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT LogID, Role, FullName, Action, Date FROM loghistory ORDER BY Date DESC"
                Dim adapter As New MySqlDataAdapter(query, connection)
                Dim table As New DataTable
                adapter.Fill(table)
                DGVloghistory.DataSource = table
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading log history: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Form Load Event
    Private Sub LogHistoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadLogHistory()
    End Sub
End Class
