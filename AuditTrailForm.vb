Imports MySql.Data.MySqlClient

Public Class AuditTrailForm
    Dim conn As New MySqlConnection("server=localhost;database=smgsisbstp;uid=root;pwd=;")

    ' Load Audit Trail Data
    Public Sub LoadAuditTrail()
        Try
            conn.Open()
            Dim query As String = "SELECT AuditID, Role, FullName, Action, Form, Date FROM audittrail ORDER BY Date DESC"
            Dim cmd As New MySqlCommand(query, conn)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()

            ' Fill the DataTable with the data from the database
            adapter.Fill(table)

            ' Check if there are rows in the table
            If table.Rows.Count > 0 Then
                dgvAuditTrail.DataSource = table
            Else
                dgvAuditTrail.DataSource = Nothing
                MessageBox.Show("No audit trail records found.")
            End If

            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading audit trail: " & ex.Message)
        End Try
    End Sub

    ' Form Load Event
    Private Sub AuditTrailForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Use SessionData to get role and full name, not Login
        Me.Text = "Audit Trail - " & SessionData.role & ": " & SessionData.fullName
        LoadAuditTrail()
    End Sub
End Class
