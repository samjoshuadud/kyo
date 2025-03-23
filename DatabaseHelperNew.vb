Imports MySql.Data.MySqlClient
Imports System.Data

''' <summary>
''' Database Helper Class that provides clean data access for the Inventory and POS system
''' Using Singleton pattern to ensure only one instance throughout the application
''' </summary>
Public Class DatabaseHelperNew
    ' Singleton instance
    Private Shared _instance As DatabaseHelperNew
    
    Public Shared ReadOnly Property Instance As DatabaseHelperNew
        Get
            If _instance Is Nothing Then
                _instance = New DatabaseHelperNew()
            End If
            Return _instance
        End Get
    End Property

    ' Connection string 
    Private ReadOnly connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private connection As MySqlConnection

    ' Private constructor to enforce singleton pattern
    Private Sub New()
        connection = New MySqlConnection(connectionString)
    End Sub

    ''' <summary>
    ''' Opens a database connection if it's not already open
    ''' </summary>
    Private Sub OpenConnection()
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If
    End Sub

    ''' <summary>
    ''' Safely closes a database connection if it's open
    ''' </summary>
    Private Sub CloseConnection()
        If connection.State = ConnectionState.Open Then
            connection.Close()
        End If
    End Sub

    ''' <summary>
    ''' Executes a query that returns a DataTable
    ''' </summary>
    ''' <param name="query">SQL query to execute</param>
    ''' <param name="parameters">Optional parameters for the query</param>
    ''' <returns>DataTable containing the results</returns>
    Public Function ExecuteQuery(query As String, Optional parameters As MySqlParameter() = Nothing) As DataTable
        Dim dataTable As New DataTable()
        
        Try
            OpenConnection()
            
            Using command As New MySqlCommand(query, connection)
                ' Add parameters if provided
                If parameters IsNot Nothing Then
                    command.Parameters.AddRange(parameters)
                End If
                
                ' Execute and fill DataTable
                Using adapter As New MySqlDataAdapter(command)
                    adapter.Fill(dataTable)
                End Using
            End Using
            
        Catch ex As Exception
            Throw New Exception("Database error: " & ex.Message)
        Finally
            CloseConnection()
        End Try
        
        Return dataTable
    End Function

    ''' <summary>
    ''' Executes a non-query command (INSERT, UPDATE, DELETE)
    ''' </summary>
    ''' <param name="query">SQL command to execute</param>
    ''' <param name="parameters">Optional parameters for the command</param>
    ''' <returns>Number of rows affected</returns>
    Public Function ExecuteNonQuery(query As String, Optional parameters As MySqlParameter() = Nothing) As Integer
        Dim rowsAffected As Integer = 0
        
        Try
            OpenConnection()
            
            Using command As New MySqlCommand(query, connection)
                ' Add parameters if provided
                If parameters IsNot Nothing Then
                    command.Parameters.AddRange(parameters)
                End If
                
                ' Execute command
                rowsAffected = command.ExecuteNonQuery()
            End Using
            
        Catch ex As Exception
            Throw New Exception("Database error: " & ex.Message)
        Finally
            CloseConnection()
        End Try
        
        Return rowsAffected
    End Function

    ''' <summary>
    ''' Executes a scalar query (single value result)
    ''' </summary>
    ''' <param name="query">SQL query to execute</param>
    ''' <param name="parameters">Optional parameters for the query</param>
    ''' <returns>Result of the scalar query</returns>
    Public Function ExecuteScalar(query As String, Optional parameters As MySqlParameter() = Nothing) As Object
        Dim result As Object = Nothing
        
        Try
            OpenConnection()
            
            Using command As New MySqlCommand(query, connection)
                ' Add parameters if provided
                If parameters IsNot Nothing Then
                    command.Parameters.AddRange(parameters)
                End If
                
                ' Execute scalar query
                result = command.ExecuteScalar()
            End Using
            
        Catch ex As Exception
            Throw New Exception("Database error: " & ex.Message)
        Finally
            CloseConnection()
        End Try
        
        Return result
    End Function

    ''' <summary>
    ''' Begins a database transaction for operations that need to be atomic
    ''' </summary>
    Public Function BeginTransaction() As MySqlTransaction
        Try
            OpenConnection()
            Return connection.BeginTransaction()
        Catch ex As Exception
            Throw New Exception("Error starting transaction: " & ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Logs an audit trail entry
    ''' </summary>
    Public Sub LogAuditTrail(role As String, fullName As String, action As String, formName As String)
        Try
            Dim query As String = "INSERT INTO audittrail (Role, FullName, Action, Form, Date) VALUES (@Role, @FullName, @Action, @Form, @Date)"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@Role", role),
                New MySqlParameter("@FullName", fullName),
                New MySqlParameter("@Action", action),
                New MySqlParameter("@Form", formName),
                New MySqlParameter("@Date", DateTime.Now)
            }
            
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            ' Just log to console if audit logging fails - don't interrupt normal operation
            Console.WriteLine("Error logging audit trail: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Gets the current VAT rate from the database
    ''' </summary>
    Public Function GetCurrentVATRate() As Decimal
        Try
            Dim query As String = "SELECT vat_rate FROM vat ORDER BY effective_date DESC LIMIT 1"
            Dim result As Object = ExecuteScalar(query)
            
            If result IsNot Nothing AndAlso Not Convert.IsDBNull(result) Then
                Return Convert.ToDecimal(result)
            Else
                Return 0D ' Default to 0 if no VAT rate found
            End If
        Catch ex As Exception
            ' Log error but return default value
            Console.WriteLine("Error retrieving VAT rate: " & ex.Message)
            Return 0D
        End Try
    End Function
End Class 