<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProductScan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'Define UI controls
    Friend WithEvents lblTransaction As Label
    Friend WithEvents lblSupplier As Label
    Friend WithEvents lblDeliveryDate As Label
    Friend WithEvents lblBarcodeTitle As Label
    Friend WithEvents txtBarcode As TextBox

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblTransaction = New Label()
        lblSupplier = New Label()
        lblDeliveryDate = New Label()
        lblBarcodeTitle = New Label()
        txtBarcode = New TextBox()
        SuspendLayout()
        ' 
        ' lblTransaction
        ' 
        lblTransaction.AutoSize = True
        lblTransaction.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblTransaction.Location = New Point(20, 20)
        lblTransaction.Name = "lblTransaction"
        lblTransaction.Size = New Size(262, 32)
        lblTransaction.TabIndex = 0
        lblTransaction.Text = "Transaction Number: "
        ' 
        ' lblSupplier
        ' 
        lblSupplier.AutoSize = True
        lblSupplier.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblSupplier.Location = New Point(20, 60)
        lblSupplier.Name = "lblSupplier"
        lblSupplier.Size = New Size(124, 32)
        lblSupplier.TabIndex = 1
        lblSupplier.Text = "Supplier: "
        ' 
        ' lblDeliveryDate
        ' 
        lblDeliveryDate.AutoSize = True
        lblDeliveryDate.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblDeliveryDate.Location = New Point(20, 100)
        lblDeliveryDate.Name = "lblDeliveryDate"
        lblDeliveryDate.Size = New Size(183, 32)
        lblDeliveryDate.TabIndex = 2
        lblDeliveryDate.Text = "Delivery Date: "
        ' 
        ' lblBarcodeTitle
        ' 
        lblBarcodeTitle.AutoSize = True
        lblBarcodeTitle.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblBarcodeTitle.Location = New Point(20, 160)
        lblBarcodeTitle.Name = "lblBarcodeTitle"
        lblBarcodeTitle.Size = New Size(273, 32)
        lblBarcodeTitle.TabIndex = 3
        lblBarcodeTitle.Text = "Scan or Enter Barcode:"
        ' 
        ' txtBarcode
        ' 
        txtBarcode.Location = New Point(20, 200)
        txtBarcode.Name = "txtBarcode"
        txtBarcode.Size = New Size(400, 31)
        txtBarcode.TabIndex = 4
        ' 
        ' ProductScan
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(txtBarcode)
        Controls.Add(lblBarcodeTitle)
        Controls.Add(lblDeliveryDate)
        Controls.Add(lblSupplier)
        Controls.Add(lblTransaction)
        Name = "ProductScan"
        Text = "ProductScan"
        ResumeLayout(False)
        PerformLayout()

    End Sub
End Class
