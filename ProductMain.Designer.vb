<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProductMain
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductMain))
        dgvProducts = New DataGridView()
        txtProductName = New TextBox()
        txtBarcode = New TextBox()
        txtSellingPrice = New TextBox()
        txtCostPrice = New TextBox()
        txtDescription = New TextBox()
        cmbCategories = New ComboBox()
        cmbExpirationOption = New ComboBox()
        lblProductName = New Label()
        lblBarcode = New Label()
        lblSellingPrice = New Label()
        lblCostPrice = New Label()
        lblDescription = New Label()
        lblCategories = New Label()
        lblExpirationOption = New Label()
        PanelProduct = New Panel()
        btnExitPanel = New Button()
        btnDelete = New Button()
        btnEdit = New Button()
        btnSave = New Button()
        btnAddProduct = New Button()
        CType(dgvProducts, ComponentModel.ISupportInitialize).BeginInit()
        PanelProduct.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvProducts
        ' 
        dgvProducts.ColumnHeadersHeight = 34
        dgvProducts.Location = New Point(12, 267)
        dgvProducts.Name = "dgvProducts"
        dgvProducts.ReadOnly = True
        dgvProducts.RowHeadersWidth = 62
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProducts.Size = New Size(1016, 508)
        dgvProducts.TabIndex = 0
        ' 
        ' txtProductName
        ' 
        txtProductName.Font = New Font("Segoe UI", 12F)
        txtProductName.Location = New Point(201, 34)
        txtProductName.Name = "txtProductName"
        txtProductName.Size = New Size(344, 39)
        txtProductName.TabIndex = 1
        ' 
        ' txtBarcode
        ' 
        txtBarcode.Font = New Font("Segoe UI", 12F)
        txtBarcode.Location = New Point(201, 79)
        txtBarcode.Name = "txtBarcode"
        txtBarcode.Size = New Size(344, 39)
        txtBarcode.TabIndex = 2
        ' 
        ' txtSellingPrice
        ' 
        txtSellingPrice.Font = New Font("Segoe UI", 12F)
        txtSellingPrice.Location = New Point(201, 124)
        txtSellingPrice.Name = "txtSellingPrice"
        txtSellingPrice.Size = New Size(344, 39)
        txtSellingPrice.TabIndex = 3
        ' 
        ' txtCostPrice
        ' 
        txtCostPrice.Font = New Font("Segoe UI", 12F)
        txtCostPrice.Location = New Point(201, 169)
        txtCostPrice.Name = "txtCostPrice"
        txtCostPrice.Size = New Size(344, 39)
        txtCostPrice.TabIndex = 4
        ' 
        ' txtDescription
        ' 
        txtDescription.Font = New Font("Segoe UI", 12F)
        txtDescription.Location = New Point(201, 214)
        txtDescription.Multiline = True
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(344, 80)
        txtDescription.TabIndex = 5
        ' 
        ' cmbCategories
        ' 
        cmbCategories.DropDownStyle = ComboBoxStyle.DropDownList
        cmbCategories.Font = New Font("Segoe UI", 12F)
        cmbCategories.Location = New Point(201, 310)
        cmbCategories.Name = "cmbCategories"
        cmbCategories.Size = New Size(344, 40)
        cmbCategories.TabIndex = 6
        ' 
        ' cmbExpirationOption
        ' 
        cmbExpirationOption.DropDownStyle = ComboBoxStyle.DropDownList
        cmbExpirationOption.Font = New Font("Segoe UI", 12F)
        cmbExpirationOption.Items.AddRange(New Object() {"With Expiration", "Without Expiration"})
        cmbExpirationOption.Location = New Point(201, 360)
        cmbExpirationOption.Name = "cmbExpirationOption"
        cmbExpirationOption.Size = New Size(344, 40)
        cmbExpirationOption.TabIndex = 7
        ' 
        ' lblProductName
        ' 
        lblProductName.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblProductName.Location = New Point(37, 34)
        lblProductName.Name = "lblProductName"
        lblProductName.Size = New Size(195, 36)
        lblProductName.TabIndex = 8
        lblProductName.Text = "PRODUCT NAME :"
        ' 
        ' lblBarcode
        ' 
        lblBarcode.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblBarcode.Location = New Point(37, 79)
        lblBarcode.Name = "lblBarcode"
        lblBarcode.Size = New Size(120, 33)
        lblBarcode.TabIndex = 9
        lblBarcode.Text = "BARCODE :"
        ' 
        ' lblSellingPrice
        ' 
        lblSellingPrice.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblSellingPrice.Location = New Point(36, 124)
        lblSellingPrice.Name = "lblSellingPrice"
        lblSellingPrice.Size = New Size(168, 33)
        lblSellingPrice.TabIndex = 10
        lblSellingPrice.Text = "SELLING PRICE :"
        ' 
        ' lblCostPrice
        ' 
        lblCostPrice.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblCostPrice.Location = New Point(37, 169)
        lblCostPrice.Name = "lblCostPrice"
        lblCostPrice.Size = New Size(153, 33)
        lblCostPrice.TabIndex = 11
        lblCostPrice.Text = "COST PRICE :"
        ' 
        ' lblDescription
        ' 
        lblDescription.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblDescription.Location = New Point(36, 214)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(152, 35)
        lblDescription.TabIndex = 12
        lblDescription.Text = "DISCRIPTION :"
        ' 
        ' lblCategories
        ' 
        lblCategories.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblCategories.Location = New Point(42, 310)
        lblCategories.Name = "lblCategories"
        lblCategories.Size = New Size(130, 35)
        lblCategories.TabIndex = 13
        lblCategories.Text = "CATEGORY :"
        ' 
        ' lblExpirationOption
        ' 
        lblExpirationOption.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblExpirationOption.Location = New Point(42, 360)
        lblExpirationOption.Name = "lblExpirationOption"
        lblExpirationOption.Size = New Size(205, 38)
        lblExpirationOption.TabIndex = 14
        lblExpirationOption.Text = "EXPIRATION OPTION :"
        ' 
        ' PanelProduct
        ' 
        PanelProduct.Controls.Add(btnExitPanel)
        PanelProduct.Controls.Add(btnDelete)
        PanelProduct.Controls.Add(cmbExpirationOption)
        PanelProduct.Controls.Add(btnEdit)
        PanelProduct.Controls.Add(txtProductName)
        PanelProduct.Controls.Add(btnSave)
        PanelProduct.Controls.Add(txtBarcode)
        PanelProduct.Controls.Add(txtSellingPrice)
        PanelProduct.Controls.Add(txtCostPrice)
        PanelProduct.Controls.Add(txtDescription)
        PanelProduct.Controls.Add(lblExpirationOption)
        PanelProduct.Controls.Add(cmbCategories)
        PanelProduct.Controls.Add(lblCategories)
        PanelProduct.Controls.Add(lblDescription)
        PanelProduct.Controls.Add(lblProductName)
        PanelProduct.Controls.Add(lblCostPrice)
        PanelProduct.Controls.Add(lblBarcode)
        PanelProduct.Controls.Add(lblSellingPrice)
        PanelProduct.Location = New Point(391, 59)
        PanelProduct.Name = "PanelProduct"
        PanelProduct.Size = New Size(669, 548)
        PanelProduct.TabIndex = 19
        PanelProduct.Visible = False
        ' 
        ' btnExitPanel
        ' 
        btnExitPanel.BackColor = Color.Transparent
        btnExitPanel.FlatAppearance.BorderSize = 0
        btnExitPanel.FlatStyle = FlatStyle.Flat
        btnExitPanel.Image = CType(resources.GetObject("btnExitPanel.Image"), Image)
        btnExitPanel.Location = New Point(604, 3)
        btnExitPanel.Name = "btnExitPanel"
        btnExitPanel.Size = New Size(62, 56)
        btnExitPanel.TabIndex = 69
        btnExitPanel.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = SystemColors.GrayText
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.ForeColor = SystemColors.ButtonHighlight
        btnDelete.Location = New Point(483, 444)
        btnDelete.Name = "btnDelete"
        btnDelete.Padding = New Padding(1, 0, 0, 0)
        btnDelete.Size = New Size(135, 47)
        btnDelete.TabIndex = 27
        btnDelete.Text = "DELETE"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnEdit
        ' 
        btnEdit.BackColor = SystemColors.ActiveCaptionText
        btnEdit.FlatStyle = FlatStyle.Flat
        btnEdit.ForeColor = SystemColors.ButtonHighlight
        btnEdit.Location = New Point(342, 444)
        btnEdit.Name = "btnEdit"
        btnEdit.Padding = New Padding(1, 0, 0, 0)
        btnEdit.Size = New Size(135, 47)
        btnEdit.TabIndex = 26
        btnEdit.Text = "EDIT"
        btnEdit.UseVisualStyleBackColor = False
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = SystemColors.ActiveCaptionText
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.ForeColor = SystemColors.ButtonHighlight
        btnSave.Location = New Point(201, 444)
        btnSave.Name = "btnSave"
        btnSave.Padding = New Padding(1, 0, 0, 0)
        btnSave.Size = New Size(135, 47)
        btnSave.TabIndex = 25
        btnSave.Text = "ADD"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnAddProduct
        ' 
        btnAddProduct.BackColor = Color.Transparent
        btnAddProduct.FlatAppearance.BorderSize = 0
        btnAddProduct.FlatStyle = FlatStyle.Flat
        btnAddProduct.Image = CType(resources.GetObject("btnAddProduct.Image"), Image)
        btnAddProduct.Location = New Point(12, 205)
        btnAddProduct.Name = "btnAddProduct"
        btnAddProduct.Size = New Size(62, 56)
        btnAddProduct.TabIndex = 68
        btnAddProduct.UseVisualStyleBackColor = False
        ' 
        ' ProductMain
        ' 
        ClientSize = New Size(1062, 786)
        Controls.Add(btnAddProduct)
        Controls.Add(PanelProduct)
        Controls.Add(dgvProducts)
        FormBorderStyle = FormBorderStyle.None
        Name = "ProductMain"
        Text = "Product Management"
        CType(dgvProducts, ComponentModel.ISupportInitialize).EndInit()
        PanelProduct.ResumeLayout(False)
        PanelProduct.PerformLayout()
        ResumeLayout(False)

    End Sub

    ' Declare components
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents txtSellingPrice As TextBox
    Friend WithEvents txtCostPrice As TextBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents cmbCategories As ComboBox
    Friend WithEvents cmbExpirationOption As ComboBox

    ' Declare Labels
    Friend WithEvents lblProductName As Label
    Friend WithEvents lblBarcode As Label
    Friend WithEvents lblSellingPrice As Label
    Friend WithEvents lblCostPrice As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblCategories As Label
    Friend WithEvents lblExpirationOption As Label
    Friend WithEvents PanelProduct As Panel
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnAddProduct As Button
    Friend WithEvents btnExitPanel As Button
End Class
