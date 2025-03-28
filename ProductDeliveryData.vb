' ProductDeliveryData.vb
' This class facilitates data transfer between ProductMain and DeliveryMain forms

Public Class ProductDeliveryData
    ' Singleton pattern to ensure only one instance exists
    Private Shared _instance As ProductDeliveryData
    
    ' Flag to track if the instance has been properly initialized with product data
    Private _isInitialized As Boolean = False
    
    ' Product information
    Public Property ProductID As Integer
    Public Property ProductName As String
    Public Property Barcode As String
    Public Property Category As String
    Public Property CurrentStock As Integer = 0
    Public Property ExpirationOption As String = "Without Expiration"
    
    ' Get the single instance of this class
    Public Shared Function GetInstance() As ProductDeliveryData
        If _instance Is Nothing Then
            _instance = New ProductDeliveryData()
        End If
        Return _instance
    End Function
    
    ' Reset the singleton instance to ensure fresh data
    Public Shared Sub ResetInstance()
        _instance = New ProductDeliveryData()
    End Sub
    
    ' Private constructor to enforce singleton pattern
    Private Sub New()
        ' Initialize with default values
        ProductID = 0
        ProductName = ""
        Barcode = ""
        Category = ""
        CurrentStock = 0
        ExpirationOption = "Without Expiration"
        _isInitialized = False
    End Sub
    
    ' Clear all data
    Public Sub ClearData()
        ProductID = 0
        ProductName = ""
        Barcode = ""
        Category = ""
        CurrentStock = 0
        ExpirationOption = "Without Expiration"
        _isInitialized = False
    End Sub

    ' Set product details from ProductMain form
    Public Sub SetProductDetails(productId As Integer, name As String, barcode As String, category As String, expirationOption As String)
        If productId <= 0 Then
            Throw New ArgumentException($"Invalid product ID: {productId}. Cannot set product details with an invalid ID.")
        End If
        
        ProductID = productId
        ProductName = name
        Barcode = barcode
        Category = category
        ExpirationOption = expirationOption
        _isInitialized = True
    End Sub

    ' Update current stock information
    Public Sub UpdateStockInfo(currentQty As Integer)
        CurrentStock = currentQty
    End Sub
    
    ' Check if the data has been properly initialized
    Public Function IsInitialized() As Boolean
        Return _isInitialized
    End Function
    
    ' Save the current state to a backup
    Public Sub SaveState(ByRef productId As Integer, ByRef productName As String, ByRef barcode As String, ByRef category As String, ByRef stock As Integer)
        productId = Me.ProductID
        productName = Me.ProductName
        barcode = Me.Barcode
        category = Me.Category
        stock = Me.CurrentStock
    End Sub
    
    ' Restore state from backup
    Public Sub RestoreState(productId As Integer, productName As String, barcode As String, category As String, stock As Integer)
        Me.ProductID = productId
        Me.ProductName = productName
        Me.Barcode = barcode
        Me.Category = category
        Me.CurrentStock = stock
        _isInitialized = (productId > 0)
    End Sub
End Class 