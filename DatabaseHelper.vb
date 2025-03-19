Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO


' Session Data Module
Module SessionData
    ' Stores the ID of the currently logged-in user
    Public CurrentUserId As Integer

    ' Stores the role of the currently logged-in user (e.g., "Cashier", "Admin")
    Public role As String

    ' Stores the full name of the logged-in user
    Public fullName As String
End Module

' User Entity (Domain Layer)
Public Class User

    Public Property UserId As Integer
    Public Property Username As String
    Public Property FullName As String
    Public Property Email As String
    Public Property PasswordHash As String
    Public Property Role As String
End Class

' User Repository (Data Access Layer)
Public Class UserRepository
    Private ReadOnly _dbHelper As DatabaseHelper = DatabaseHelper.Instance

    ' Retrieve all users from the database
    Public Function GetAllUsers() As List(Of User)
        Dim users As New List(Of User)
        Dim query As String = "SELECT * FROM users"
        Dim dataTable As DataTable = _dbHelper.ExecuteQuery(query)

        For Each row As DataRow In dataTable.Rows
            users.Add(New User With {
                .UserId = Convert.ToInt32(row("user_id")),
                .Username = row("username").ToString(),
                .FullName = row("full_name").ToString(),
                .Email = row("email").ToString(),
                .PasswordHash = row("password_hash").ToString(),
                .Role = row("role").ToString()
            })
        Next

        Return users
    End Function

    ' Add a new user to the database
    Public Sub AddUser(user As User)
        Dim query As String = "INSERT INTO users (username, full_name, email, password_hash, role) VALUES (@username, @full_name, @email, @password, @role)"
        Dim parameters As MySqlParameter() = {
            New MySqlParameter("@username", user.Username),
            New MySqlParameter("@full_name", user.FullName),
            New MySqlParameter("@email", user.Email),
            New MySqlParameter("@password", user.PasswordHash),
            New MySqlParameter("@role", user.Role)
        }
        _dbHelper.ExecuteNonQuery(query, parameters)
    End Sub

    ' Update an existing user in the database
    Public Sub UpdateUser(user As User)
        Dim query As String = "UPDATE users SET username = @username, full_name = @full_name, email = @email, password_hash = @password, role = @role WHERE user_id = @user_id"
        Dim parameters As MySqlParameter() = {
            New MySqlParameter("@username", user.Username),
            New MySqlParameter("@full_name", user.FullName),
            New MySqlParameter("@email", user.Email),
            New MySqlParameter("@password", user.PasswordHash),
            New MySqlParameter("@role", user.Role),
            New MySqlParameter("@user_id", user.UserId)
        }
        _dbHelper.ExecuteNonQuery(query, parameters)
    End Sub

    ' Delete a user from the database
    Public Sub DeleteUser(userId As Integer)
        Dim query As String = "DELETE FROM users WHERE user_id = @user_id"
        Dim parameters As MySqlParameter() = {
            New MySqlParameter("@user_id", userId)
        }
        _dbHelper.ExecuteNonQuery(query, parameters)
    End Sub
End Class

' User Service (Application Layer)
Public Class UserService
    Private ReadOnly _userRepository As New UserRepository()

    ' Retrieve all users
    Public Function GetAllUsers() As List(Of User)
        Return _userRepository.GetAllUsers()
    End Function

    ' Add a new user
    Public Sub AddUser(user As User)
        If String.IsNullOrWhiteSpace(user.Username) OrElse String.IsNullOrWhiteSpace(user.FullName) Then
            Throw New ArgumentException("Username and Full Name cannot be empty.")
        End If
        _userRepository.AddUser(user)
    End Sub

    ' Update an existing user
    Public Sub UpdateUser(user As User)
        If String.IsNullOrWhiteSpace(user.Username) OrElse String.IsNullOrWhiteSpace(user.FullName) Then
            Throw New ArgumentException("Username and Full Name cannot be empty.")
        End If
        _userRepository.UpdateUser(user)
    End Sub

    ' Delete a user by ID
    Public Sub DeleteUser(userId As Integer)
        _userRepository.DeleteUser(userId)
    End Sub
End Class

' Database Helper Class (Singleton for Database Access)
Public Class DatabaseHelper
    ' Singleton instance
    Private Shared _instance As DatabaseHelper
    Public Shared ReadOnly Property Instance As DatabaseHelper
        Get
            If _instance Is Nothing Then
                _instance = New DatabaseHelper()
            End If
            Return _instance
        End Get
    End Property

    ' Private constructor to enforce singleton pattern
    Private Sub New()
        connection = New MySqlConnection(connectionString)
    End Sub

    ' Connection string (adjust for your database)
    Private connectionString As String = "Server=localhost;Database=smgsisbstp;User ID=root;Password=;Pooling=true;"
    Private connection As MySqlConnection
    Private transaction As MySqlTransaction


    ' Open the database connection
    Private Sub OpenConnection()
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If
    End Sub

    ' Close the database connection
    Private Sub CloseConnection()
        If connection.State = ConnectionState.Open AndAlso transaction Is Nothing Then
            connection.Close()
        End If
    End Sub

    ' Log errors to a file
    Private Sub LogError(message As String)
        Dim logFile As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.log")
        File.AppendAllText(logFile, $"{DateTime.Now}: {message}{Environment.NewLine}")
    End Sub

    ' Execute scalar queries (e.g., SELECT single value)
    Public Function ExecuteScalar(query As String, Optional parameters As MySqlParameter() = Nothing) As Object
        Dim result As Object = Nothing
        Using command As New MySqlCommand(query, connection)
            If parameters IsNot Nothing Then
                command.Parameters.AddRange(parameters)
            End If
            If transaction IsNot Nothing Then
                command.Transaction = transaction
            End If
            Try
                OpenConnection()
                result = command.ExecuteScalar()
            Catch ex As Exception
                LogError(ex.Message)
                Throw
            Finally
                CloseConnection()
            End Try
        End Using
        Return result
    End Function

    ' Execute non-query commands (INSERT, UPDATE, DELETE)
    Public Function ExecuteNonQuery(query As String, Optional parameters As MySqlParameter() = Nothing) As Integer
        Dim affectedRows As Integer = 0
        Using command As New MySqlCommand(query, connection)
            If parameters IsNot Nothing Then
                command.Parameters.AddRange(parameters)
            End If
            If transaction IsNot Nothing Then
                command.Transaction = transaction
            End If
            Try
                OpenConnection()
                affectedRows = command.ExecuteNonQuery()
            Catch ex As Exception
                LogError(ex.Message)
                Throw
            Finally
                CloseConnection()
            End Try
        End Using
        Return affectedRows
    End Function

    ' Execute queries and return a DataTable (SELECT queries)
    Public Function ExecuteQuery(query As String, Optional parameters As MySqlParameter() = Nothing) As DataTable
        Dim dataTable As New DataTable()
        Using command As New MySqlCommand(query, connection)
            If parameters IsNot Nothing Then
                command.Parameters.AddRange(parameters)
            End If
            If transaction IsNot Nothing Then
                command.Transaction = transaction
            End If
            Try
                OpenConnection()
                Using adapter As New MySqlDataAdapter(command)
                    adapter.Fill(dataTable)
                End Using
            Catch ex As Exception
                LogError(ex.Message)
                Throw
            Finally
                CloseConnection()
            End Try
        End Using
        Return dataTable
    End Function

    ' Transaction management
    Public Sub BeginTransaction()
        Try
            OpenConnection()
            transaction = connection.BeginTransaction()
        Catch ex As Exception
            LogError("Failed to start transaction: " & ex.Message)
            Throw
        End Try
    End Sub

    Public Sub CommitTransaction()
        Try
            transaction?.Commit()
        Catch ex As Exception
            LogError("Failed to commit transaction: " & ex.Message)
            Throw
        Finally
            transaction = Nothing
            CloseConnection()
        End Try
    End Sub

    Public Sub RollbackTransaction()
        Try
            transaction?.Rollback()
        Catch ex As Exception
            LogError("Failed to rollback transaction: " & ex.Message)
            Throw
        Finally
            transaction = Nothing
            CloseConnection()
        End Try
    End Sub

    ' Get the last inserted ID
    Public Function GetLastInsertId() As Integer
        Return Convert.ToInt32(ExecuteScalar("SELECT LAST_INSERT_ID()"))
    End Function

    ' Get a DataTable from a query
    Public Function GetDataTable(query As String, Optional parameters As MySqlParameter() = Nothing) As DataTable
        Dim dt As New DataTable()

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Using cmd As New MySqlCommand(query, conn)
                    ' Add parameters if any
                    If parameters IsNot Nothing Then
                        cmd.Parameters.AddRange(parameters)
                    End If

                    ' Use a DataReader to fill the DataTable
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        dt.Load(reader)
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error executing query: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dt
    End Function
End Class


