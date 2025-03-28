<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DeliveryMain
    Inherits System.Windows.Forms.Form

    ' Dispose method to clean up resources
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

    ' Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    ' Form controls
    Private lblTransactionTitle As System.Windows.Forms.Label
    Private lblTransactionNumber As System.Windows.Forms.Label
    Private lblSupplier As System.Windows.Forms.Label
    Private cmbSupplier As System.Windows.Forms.ComboBox
    Private lblDeliveryDate As System.Windows.Forms.Label
    Private dtpDeliveryDate As System.Windows.Forms.DateTimePicker
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private lblProduct As System.Windows.Forms.Label
    Private lblStock As System.Windows.Forms.Label
    Private lblQuantity As System.Windows.Forms.Label
    Private txtQuantity As System.Windows.Forms.TextBox
    Private lblUnitPrice As System.Windows.Forms.Label
    Private txtUnitPrice As System.Windows.Forms.TextBox
    Private lblBatchNumber As System.Windows.Forms.Label
    Private txtBatchNumber As System.Windows.Forms.TextBox
    Private lblExpirationDate As System.Windows.Forms.Label
    Private dtpExpirationDate As System.Windows.Forms.DateTimePicker
    Private lblNotes As System.Windows.Forms.Label
    Private txtNotes As System.Windows.Forms.TextBox
    Private WithEvents btnReturn As System.Windows.Forms.Button

    ' Designer method for UI initialization
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblTransactionTitle = New Label()
        lblTransactionNumber = New Label()
        lblSupplier = New Label()
        cmbSupplier = New ComboBox()
        lblDeliveryDate = New Label()
        dtpDeliveryDate = New DateTimePicker()
        btnSave = New Button()
        btnClose = New Button()
        lblProduct = New Label()
        lblStock = New Label()
        lblQuantity = New Label()
        txtQuantity = New TextBox()
        lblUnitPrice = New Label()
        txtUnitPrice = New TextBox()
        lblBatchNumber = New Label()
        txtBatchNumber = New TextBox()
        lblExpirationDate = New Label()
        dtpExpirationDate = New DateTimePicker()
        lblNotes = New Label()
        txtNotes = New TextBox()
        btnReturn = New Button()
        SuspendLayout()
        ' 
        ' lblTransactionTitle
        ' 
        lblTransactionTitle.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblTransactionTitle.Location = New Point(20, 20)
        lblTransactionTitle.Name = "lblTransactionTitle"
        lblTransactionTitle.Size = New Size(150, 23)
        lblTransactionTitle.TabIndex = 0
        lblTransactionTitle.Text = "Transaction Number:"
        ' 
        ' lblTransactionNumber
        ' 
        lblTransactionNumber.BorderStyle = BorderStyle.FixedSingle
        lblTransactionNumber.Font = New Font("Segoe UI", 10F)
        lblTransactionNumber.Location = New Point(180, 20)
        lblTransactionNumber.Name = "lblTransactionNumber"
        lblTransactionNumber.Size = New Size(280, 23)
        lblTransactionNumber.TabIndex = 1
        lblTransactionNumber.Text = "Generating..."
        ' 
        ' lblSupplier
        ' 
        lblSupplier.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblSupplier.Location = New Point(20, 60)
        lblSupplier.Name = "lblSupplier"
        lblSupplier.Size = New Size(150, 23)
        lblSupplier.TabIndex = 2
        lblSupplier.Text = "Supplier:"
        ' 
        ' cmbSupplier
        ' 
        cmbSupplier.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSupplier.Font = New Font("Segoe UI", 10F)
        cmbSupplier.Location = New Point(180, 60)
        cmbSupplier.Name = "cmbSupplier"
        cmbSupplier.Size = New Size(280, 25)
        cmbSupplier.TabIndex = 3
        ' 
        ' lblDeliveryDate
        ' 
        lblDeliveryDate.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblDeliveryDate.Location = New Point(20, 100)
        lblDeliveryDate.Name = "lblDeliveryDate"
        lblDeliveryDate.Size = New Size(150, 23)
        lblDeliveryDate.TabIndex = 4
        lblDeliveryDate.Text = "Delivery Date:"
        ' 
        ' dtpDeliveryDate
        ' 
        dtpDeliveryDate.Font = New Font("Segoe UI", 10F)
        dtpDeliveryDate.Format = DateTimePickerFormat.Short
        dtpDeliveryDate.Location = New Point(180, 100)
        dtpDeliveryDate.Name = "dtpDeliveryDate"
        dtpDeliveryDate.Size = New Size(280, 25)
        dtpDeliveryDate.TabIndex = 5
        ' 
        ' btnSave
        ' 
        btnSave.Anchor = AnchorStyles.Bottom
        btnSave.BackColor = Color.DarkRed
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(150, 600)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(120, 40)
        btnSave.TabIndex = 6
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Bottom
        btnClose.BackColor = Color.DarkRed
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(320, 600)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(120, 40)
        btnClose.TabIndex = 7
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' lblProduct
        ' 
        lblProduct.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblProduct.Location = New Point(20, 150)
        lblProduct.Name = "lblProduct"
        lblProduct.Size = New Size(400, 23)
        lblProduct.TabIndex = 8
        lblProduct.Text = "Product:"
        ' 
        ' lblStock
        ' 
        lblStock.Font = New Font("Segoe UI", 9F)
        lblStock.Location = New Point(20, 180)
        lblStock.Name = "lblStock"
        lblStock.Size = New Size(200, 23)
        lblStock.TabIndex = 9
        lblStock.Text = "Current Stock:"
        ' 
        ' lblQuantity
        ' 
        lblQuantity.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblQuantity.Location = New Point(20, 220)
        lblQuantity.Name = "lblQuantity"
        lblQuantity.Size = New Size(150, 23)
        lblQuantity.TabIndex = 10
        lblQuantity.Text = "Quantity to Receive:"
        ' 
        ' txtQuantity
        ' 
        txtQuantity.Font = New Font("Segoe UI", 10F)
        txtQuantity.Location = New Point(180, 220)
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(150, 25)
        txtQuantity.TabIndex = 11
        txtQuantity.Text = "1"
        ' 
        ' lblUnitPrice
        ' 
        lblUnitPrice.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblUnitPrice.Location = New Point(20, 260)
        lblUnitPrice.Name = "lblUnitPrice"
        lblUnitPrice.Size = New Size(150, 23)
        lblUnitPrice.TabIndex = 12
        lblUnitPrice.Text = "Unit Price:"
        ' 
        ' txtUnitPrice
        ' 
        txtUnitPrice.Font = New Font("Segoe UI", 10F)
        txtUnitPrice.Location = New Point(180, 260)
        txtUnitPrice.Name = "txtUnitPrice"
        txtUnitPrice.Size = New Size(150, 25)
        txtUnitPrice.TabIndex = 13
        ' 
        ' lblBatchNumber
        ' 
        lblBatchNumber.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblBatchNumber.Location = New Point(20, 300)
        lblBatchNumber.Name = "lblBatchNumber"
        lblBatchNumber.Size = New Size(150, 23)
        lblBatchNumber.TabIndex = 14
        lblBatchNumber.Text = "Batch Number:"
        ' 
        ' txtBatchNumber
        ' 
        txtBatchNumber.Font = New Font("Segoe UI", 10F)
        txtBatchNumber.Location = New Point(180, 300)
        txtBatchNumber.Name = "txtBatchNumber"
        txtBatchNumber.Size = New Size(150, 25)
        txtBatchNumber.TabIndex = 15
        ' 
        ' lblExpirationDate
        ' 
        lblExpirationDate.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblExpirationDate.Location = New Point(20, 340)
        lblExpirationDate.Name = "lblExpirationDate"
        lblExpirationDate.Size = New Size(150, 23)
        lblExpirationDate.TabIndex = 19
        lblExpirationDate.Text = "Expiration Date:"
        ' 
        ' dtpExpirationDate
        ' 
        dtpExpirationDate.Font = New Font("Segoe UI", 10F)
        dtpExpirationDate.Format = DateTimePickerFormat.Short
        dtpExpirationDate.Location = New Point(180, 340)
        dtpExpirationDate.Name = "dtpExpirationDate"
        dtpExpirationDate.Size = New Size(280, 25)
        dtpExpirationDate.TabIndex = 20
        ' 
        ' lblNotes
        ' 
        lblNotes.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblNotes.Location = New Point(20, 380)
        lblNotes.Name = "lblNotes"
        lblNotes.Size = New Size(150, 23)
        lblNotes.TabIndex = 16
        lblNotes.Text = "Notes:"
        ' 
        ' txtNotes
        ' 
        txtNotes.Font = New Font("Segoe UI", 10F)
        txtNotes.Location = New Point(176, 380)
        txtNotes.Multiline = True
        txtNotes.Name = "txtNotes"
        txtNotes.Size = New Size(400, 100)
        txtNotes.TabIndex = 17
        ' 
        ' btnReturn
        ' 
        btnReturn.BackColor = Color.LightGray
        btnReturn.FlatStyle = FlatStyle.Flat
        btnReturn.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnReturn.Location = New Point(20, 530)
        btnReturn.Name = "btnReturn"
        btnReturn.Size = New Size(150, 35)
        btnReturn.TabIndex = 18
        btnReturn.Text = "Return to Products"
        btnReturn.UseVisualStyleBackColor = False
        btnReturn.Visible = False
        ' 
        ' DeliveryMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.Control
        ClientSize = New Size(600, 700)
        Controls.Add(lblTransactionTitle)
        Controls.Add(lblTransactionNumber)
        Controls.Add(lblSupplier)
        Controls.Add(cmbSupplier)
        Controls.Add(lblDeliveryDate)
        Controls.Add(dtpDeliveryDate)
        Controls.Add(btnSave)
        Controls.Add(btnClose)
        Controls.Add(lblProduct)
        Controls.Add(lblStock)
        Controls.Add(lblQuantity)
        Controls.Add(txtQuantity)
        Controls.Add(lblUnitPrice)
        Controls.Add(txtUnitPrice)
        Controls.Add(lblBatchNumber)
        Controls.Add(txtBatchNumber)
        Controls.Add(lblExpirationDate)
        Controls.Add(dtpExpirationDate)
        Controls.Add(lblNotes)
        Controls.Add(txtNotes)
        Controls.Add(btnReturn)
        MaximumSize = New Size(800, 800)
        MinimumSize = New Size(500, 600)
        Name = "DeliveryMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Delivery Maintenance"
        ResumeLayout(False)
        PerformLayout()
    End Sub
End Class
