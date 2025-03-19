Imports MySql.Data.MySqlClient

Public Class AuditLogger
    Private Shared connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"

    Public Shared Sub LogAudit(UserID As Integer, Username As String, ActionType As String, Description As String)
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "INSERT INTO AuditTrail (UserID, Username, ActionType, Description) VALUES (@UserID, @Username, @ActionType, @Description)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@UserID", UserID)
                    cmd.Parameters.AddWithValue("@Username", Username)
                    cmd.Parameters.AddWithValue("@ActionType", ActionType)
                    cmd.Parameters.AddWithValue("@Description", Description)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message)
        End Try
    End Sub
End Class

