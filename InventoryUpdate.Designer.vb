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
        Me.lblBarcode = New Label()
        Me.txtBarcode = New TextBox()
        Me.lblProductName = New Label()
        Me.lblDescription = New Label()
        Me.lblSellingPrice = New Label()
        Me.lblCostPrice = New Label()
        Me.lblCategory = New Label()
        Me.lblDate = New Label()
        Me.dtpDate = New DateTimePicker()
        Me.lblQuantity = New Label()
        Me.txtQuantity = New TextBox()
        Me.btnSubmit = New Button()

        ' SuspendLayout allows batch setting controls for better performance
        Me.SuspendLayout()

        ' Form settings
        Me.AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(800, 450)
        Me.Name = "InventoryUpdate"
        Me.Text = "Inventory Update"

        ' Set properties for lblBarcode
        Me.lblBarcode.AutoSize = True
        Me.lblBarcode.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point)
        Me.lblBarcode.ForeColor = ColorTranslator.FromHtml("#0D47A1")
        Me.lblBarcode.Location = New Point(20, 20)
        Me.lblBarcode.Name = "lblBarcode"
        Me.lblBarcode.Text = "Barcode:"

        ' Set properties for txtBarcode
        Me.txtBarcode.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        Me.txtBarcode.Location = New Point(150, 20)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New Size(200, 30)
        Me.txtBarcode.ReadOnly = True
        Me.txtBarcode.BackColor = ColorTranslator.FromHtml("#FFFFFF")

        ' Set properties for lblProductName
        Me.lblProductName.AutoSize = True
        Me.lblProductName.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        Me.lblProductName.ForeColor = ColorTranslator.FromHtml("#0D47A1")
        Me.lblProductName.Location = New Point(20, 80)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Text = "Product Name: "

        ' Set properties for lblDescription
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        Me.lblDescription.ForeColor = ColorTranslator.FromHtml("#0D47A1")
        Me.lblDescription.Location = New Point(20, 120)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Text = "Description: "

        ' Set properties for lblSellingPrice
        Me.lblSellingPrice.AutoSize = True
        Me.lblSellingPrice.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        Me.lblSellingPrice.ForeColor = ColorTranslator.FromHtml("#0D47A1")
        Me.lblSellingPrice.Location = New Point(20, 160)
        Me.lblSellingPrice.Name = "lblSellingPrice"
        Me.lblSellingPrice.Text = "Selling Price: "

        ' Set properties for lblCostPrice
        Me.lblCostPrice.AutoSize = True
        Me.lblCostPrice.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        Me.lblCostPrice.ForeColor = ColorTranslator.FromHtml("#0D47A1")
        Me.lblCostPrice.Location = New Point(20, 200)
        Me.lblCostPrice.Name = "lblCostPrice"
        Me.lblCostPrice.Text = "Cost Price: "

        ' Set properties for lblCategory
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        Me.lblCategory.ForeColor = ColorTranslator.FromHtml("#0D47A1")
        Me.lblCategory.Location = New Point(20, 240)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Text = "Category: "

        ' Set properties for lblDate
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point)
        Me.lblDate.ForeColor = ColorTranslator.FromHtml("#0D47A1")
        Me.lblDate.Location = New Point(20, 280)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Text = "Date:"

        ' Set properties for dtpDate
        Me.dtpDate.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        Me.dtpDate.Location = New Point(150, 280)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Format = DateTimePickerFormat.Short
        Me.dtpDate.Size = New Size(200, 30)

        ' Set properties for lblQuantity
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point)
        Me.lblQuantity.ForeColor = ColorTranslator.FromHtml("#0D47A1")
        Me.lblQuantity.Location = New Point(20, 320)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Text = "Quantity:"

        ' Set properties for txtQuantity
        Me.txtQuantity.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        Me.txtQuantity.Location = New Point(150, 320)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New Size(200, 30)
        Me.txtQuantity.BackColor = ColorTranslator.FromHtml("#FFFFFF")

        ' Set properties for btnSubmit
        Me.btnSubmit.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point)
        Me.btnSubmit.BackColor = ColorTranslator.FromHtml("#4CAF50")
        Me.btnSubmit.ForeColor = Color.White
        Me.btnSubmit.Location = New Point(150, 360)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New Size(150, 40)
        Me.btnSubmit.FlatStyle = FlatStyle.Flat
        Me.btnSubmit.Text = "Submit"

        ' Add event handler for the submit button
        AddHandler btnSubmit.Click, AddressOf BtnSubmit_Click

        ' Add controls to the form
        Me.Controls.Add(Me.lblBarcode)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.lblProductName)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblSellingPrice)
        Me.Controls.Add(Me.lblCostPrice)
        Me.Controls.Add(Me.lblCategory)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.btnSubmit)

        ' Resume layout for performance
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

End Class
