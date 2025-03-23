' ProductDeliveryData.vb
' This class facilitates data transfer between ProductMain and DeliveryMain forms

Public Class ProductDeliveryData
    ' Singleton pattern to ensure only one instance exists
    Private Shared _instance As ProductDeliveryData
    
    ' Product information
    Public Property ProductID As Integer
    Public Property ProductName As String
    Public Property Barcode As String
    Public Property Category As String
    Public Property CurrentStock As Integer = 0
    
    ' Get the single instance of this class
    Public Shared Function GetInstance() As ProductDeliveryData
        If _instance Is Nothing Then
            _instance = New ProductDeliveryData()
        End If
        Return _instance
    End Function
    
    ' Private constructor to enforce singleton pattern
    Private Sub New()
    End Sub
    
    ' Clear all data
    Public Sub ClearData()
        ProductID = 0
        ProductName = ""
        Barcode = ""
        Category = ""
        CurrentStock = 0
    End Sub

    ' Set product details from ProductMain form
    Public Sub SetProductDetails(productId As Integer, name As String, barcode As String, category As String)
        ProductID = productId
        ProductName = name
        Barcode = barcode
        Category = category
    End Sub

    ' Update current stock information
    Public Sub UpdateStockInfo(currentQty As Integer)
        CurrentStock = currentQty
    End Sub
End Class 