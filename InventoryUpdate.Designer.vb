<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InventoryUpdate
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

    ' Declare form controls
    Private lblBarcode As Label
    Private txtBarcode As TextBox
    Private lblProductName As Label
    Private lblDescription As Label
    Private lblSellingPrice As Label
    Private lblCostPrice As Label
    Private lblCategory As Label
    Private lblDate As Label
    Private dtpDate As DateTimePicker
    Private lblQuantity As Label
    Private txtQuantity As TextBox
    Private btnSubmit As Button

    ' InitializeComponent: designer-generated method to add UI controls
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblBarcode = New Label()
        txtBarcode = New TextBox()
        lblProductName = New Label()
        lblDescription = New Label()
        lblSellingPrice = New Label()
        lblCostPrice = New Label()
        lblCategory = New Label()
        lblDate = New Label()
        dtpDate = New DateTimePicker()
        lblQuantity = New Label()
        txtQuantity = New TextBox()
        btnSubmit = New Button()
        SuspendLayout()
        ' 
        ' lblBarcode
        ' 
        lblBarcode.AutoSize = True
        lblBarcode.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblBarcode.ForeColor = Color.FromArgb(CByte(13), CByte(71), CByte(161))
        lblBarcode.Location = New Point(14, 12)
        lblBarcode.Margin = New Padding(2, 0, 2, 0)
        lblBarcode.Name = "lblBarcode"
        lblBarcode.Size = New Size(76, 21)
        lblBarcode.TabIndex = 0
        lblBarcode.Text = "Barcode:"
        ' 
        ' txtBarcode
        ' 
        txtBarcode.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        txtBarcode.Font = New Font("Segoe UI", 10F)
        txtBarcode.Location = New Point(105, 12)
        txtBarcode.Margin = New Padding(2, 2, 2, 2)
        txtBarcode.Name = "txtBarcode"
        txtBarcode.ReadOnly = True
        txtBarcode.Size = New Size(141, 25)
        txtBarcode.TabIndex = 1
        ' 
        ' lblProductName
        ' 
        lblProductName.AutoSize = True
        lblProductName.Font = New Font("Segoe UI", 10F)
        lblProductName.ForeColor = Color.FromArgb(CByte(13), CByte(71), CByte(161))
        lblProductName.Location = New Point(14, 48)
        lblProductName.Margin = New Padding(2, 0, 2, 0)
        lblProductName.Name = "lblProductName"
        lblProductName.Size = New Size(104, 19)
        lblProductName.TabIndex = 2
        lblProductName.Text = "Product Name: "
        ' 
        ' lblDescription
        ' 
        lblDescription.AutoSize = True
        lblDescription.Font = New Font("Segoe UI", 10F)
        lblDescription.ForeColor = Color.FromArgb(CByte(13), CByte(71), CByte(161))
        lblDescription.Location = New Point(14, 72)
        lblDescription.Margin = New Padding(2, 0, 2, 0)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(85, 19)
        lblDescription.TabIndex = 3
        lblDescription.Text = "Description: "
        ' 
        ' lblSellingPrice
        ' 
        lblSellingPrice.AutoSize = True
        lblSellingPrice.Font = New Font("Segoe UI", 10F)
        lblSellingPrice.ForeColor = Color.FromArgb(CByte(13), CByte(71), CByte(161))
        lblSellingPrice.Location = New Point(14, 96)
        lblSellingPrice.Margin = New Padding(2, 0, 2, 0)
        lblSellingPrice.Name = "lblSellingPrice"
        lblSellingPrice.Size = New Size(88, 19)
        lblSellingPrice.TabIndex = 4
        lblSellingPrice.Text = "Selling Price: "
        ' 
        ' lblCostPrice
        ' 
        lblCostPrice.AutoSize = True
        lblCostPrice.Font = New Font("Segoe UI", 10F)
        lblCostPrice.ForeColor = Color.FromArgb(CByte(13), CByte(71), CByte(161))
        lblCostPrice.Location = New Point(14, 120)
        lblCostPrice.Margin = New Padding(2, 0, 2, 0)
        lblCostPrice.Name = "lblCostPrice"
        lblCostPrice.Size = New Size(77, 19)
        lblCostPrice.TabIndex = 5
        lblCostPrice.Text = "Cost Price: "
        ' 
        ' lblCategory
        ' 
        lblCategory.AutoSize = True
        lblCategory.Font = New Font("Segoe UI", 10F)
        lblCategory.ForeColor = Color.FromArgb(CByte(13), CByte(71), CByte(161))
        lblCategory.Location = New Point(14, 144)
        lblCategory.Margin = New Padding(2, 0, 2, 0)
        lblCategory.Name = "lblCategory"
        lblCategory.Size = New Size(72, 19)
        lblCategory.TabIndex = 6
        lblCategory.Text = "Category: "
        ' 
        ' lblDate
        ' 
        lblDate.AutoSize = True
        lblDate.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblDate.ForeColor = Color.FromArgb(CByte(13), CByte(71), CByte(161))
        lblDate.Location = New Point(14, 183)
        lblDate.Margin = New Padding(2, 0, 2, 0)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(50, 21)
        lblDate.TabIndex = 7
        lblDate.Text = "Date:"
        ' 
        ' dtpDate
        ' 
        dtpDate.Font = New Font("Segoe UI", 10F)
        dtpDate.Format = DateTimePickerFormat.Short
        dtpDate.Location = New Point(105, 185)
        dtpDate.Margin = New Padding(2, 2, 2, 2)
        dtpDate.Name = "dtpDate"
        dtpDate.Size = New Size(141, 25)
        dtpDate.TabIndex = 8
        ' 
        ' lblQuantity
        ' 
        lblQuantity.AutoSize = True
        lblQuantity.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblQuantity.ForeColor = Color.FromArgb(CByte(13), CByte(71), CByte(161))
        lblQuantity.Location = New Point(14, 214)
        lblQuantity.Margin = New Padding(2, 0, 2, 0)
        lblQuantity.Name = "lblQuantity"
        lblQuantity.Size = New Size(81, 21)
        lblQuantity.TabIndex = 9
        lblQuantity.Text = "Quantity:"
        ' 
        ' txtQuantity
        ' 
        txtQuantity.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        txtQuantity.Font = New Font("Segoe UI", 10F)
        txtQuantity.Location = New Point(105, 214)
        txtQuantity.Margin = New Padding(2, 2, 2, 2)
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(141, 25)
        txtQuantity.TabIndex = 10
        ' 
        ' btnSubmit
        ' 
        btnSubmit.BackColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        btnSubmit.FlatStyle = FlatStyle.Flat
        btnSubmit.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        btnSubmit.ForeColor = Color.White
        btnSubmit.Location = New Point(105, 253)
        btnSubmit.Margin = New Padding(2, 2, 2, 2)
        btnSubmit.Name = "btnSubmit"
        btnSubmit.Size = New Size(105, 44)
        btnSubmit.TabIndex = 11
        btnSubmit.Text = "Submit"
        btnSubmit.UseVisualStyleBackColor = False
        ' 
        ' InventoryUpdate
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(569, 325)
        Controls.Add(lblBarcode)
        Controls.Add(txtBarcode)
        Controls.Add(lblProductName)
        Controls.Add(lblDescription)
        Controls.Add(lblSellingPrice)
        Controls.Add(lblCostPrice)
        Controls.Add(lblCategory)
        Controls.Add(lblDate)
        Controls.Add(dtpDate)
        Controls.Add(lblQuantity)
        Controls.Add(txtQuantity)
        Controls.Add(btnSubmit)
        Margin = New Padding(2, 2, 2, 2)
        Name = "InventoryUpdate"
        Text = "Inventory Update"
        ResumeLayout(False)
        PerformLayout()
    End Sub

End Class
