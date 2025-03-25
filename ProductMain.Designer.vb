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
        cmbSuppliers = New ComboBox()
        txtReorderPoint = New TextBox()
        txtUnitOfMeasure = New TextBox()
        lblProductName = New Label()
        lblBarcode = New Label()
        lblSellingPrice = New Label()
        lblCostPrice = New Label()
        lblDescription = New Label()
        lblCategories = New Label()
        lblExpirationOption = New Label()
        lblSupplier = New Label()
        lblReorderPoint = New Label()
        lblUnitOfMeasure = New Label()
        PanelProduct = New Panel()
        btnViewDeliveryHistory = New Button()
        btnReceiveDelivery = New Button()
        lblStockStatus = New Label()
        lblStockLevel = New Label()
        btnExitPanel = New Button()
        btnDelete = New Button()
        btnEdit = New Button()
        btnSave = New Button()
        btnRefresh = New Button()
        CType(dgvProducts, ComponentModel.ISupportInitialize).BeginInit()
        PanelProduct.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvProducts
        ' 
        dgvProducts.ColumnHeadersHeight = 34
        dgvProducts.Location = New Point(12, 93)
        dgvProducts.Name = "dgvProducts"
        dgvProducts.ReadOnly = True
        dgvProducts.RowHeadersWidth = 62
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProducts.Size = New Size(1016, 448)
        dgvProducts.TabIndex = 0
        ' 
        ' txtProductName
        ' 
        txtProductName.Font = New Font("Segoe UI", 12F)
        txtProductName.Location = New Point(201, 34)
        txtProductName.Name = "txtProductName"
        txtProductName.Size = New Size(182, 29)
        txtProductName.TabIndex = 1
        ' 
        ' txtBarcode
        ' 
        txtBarcode.Font = New Font("Segoe UI", 12.0F)
        txtBarcode.Location = New Point(201, 79)
        txtBarcode.Name = "txtBarcode"
        txtBarcode.Size = New Size(182, 29)
        txtBarcode.TabIndex = 2
        ' 
        ' txtSellingPrice
        ' 
        txtSellingPrice.Font = New Font("Segoe UI", 12.0F)
        txtSellingPrice.Location = New Point(201, 124)
        txtSellingPrice.Name = "txtSellingPrice"
        txtSellingPrice.Size = New Size(182, 29)
        txtSellingPrice.TabIndex = 3
        ' 
        ' txtCostPrice
        ' 
        txtCostPrice.Font = New Font("Segoe UI", 12.0F)
        txtCostPrice.Location = New Point(201, 169)
        txtCostPrice.Name = "txtCostPrice"
        txtCostPrice.Size = New Size(187, 29)
        txtCostPrice.TabIndex = 4
        ' 
        ' txtDescription
        ' 
        txtDescription.Font = New Font("Segoe UI", 12.0F)
        txtDescription.Location = New Point(415, 73)
        txtDescription.Multiline = True
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(299, 80)
        txtDescription.TabIndex = 5
        ' 
        ' cmbCategories
        ' 
        cmbCategories.DropDownStyle = ComboBoxStyle.DropDownList
        cmbCategories.Font = New Font("Segoe UI", 12.0F)
        cmbCategories.Location = New Point(503, 175)
        cmbCategories.Name = "cmbCategories"
        cmbCategories.Size = New Size(211, 29)
        cmbCategories.TabIndex = 6
        ' 
        ' cmbExpirationOption
        ' 
        cmbExpirationOption.DropDownStyle = ComboBoxStyle.DropDownList
        cmbExpirationOption.Font = New Font("Segoe UI", 12.0F)
        cmbExpirationOption.Items.AddRange(New Object() {"With Expiration", "Without Expiration"})
        cmbExpirationOption.Location = New Point(201, 213)
        cmbExpirationOption.Name = "cmbExpirationOption"
        cmbExpirationOption.Size = New Size(187, 29)
        cmbExpirationOption.TabIndex = 7
        ' 
        ' cmbSuppliers
        ' 
        cmbSuppliers.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSuppliers.Font = New Font("Segoe UI", 12.0F)
        cmbSuppliers.Location = New Point(503, 264)
        cmbSuppliers.Name = "cmbSuppliers"
        cmbSuppliers.Size = New Size(211, 29)
        cmbSuppliers.TabIndex = 10
        ' 
        ' txtReorderPoint
        ' 
        txtReorderPoint.Font = New Font("Segoe UI", 12.0F)
        txtReorderPoint.Location = New Point(201, 319)
        txtReorderPoint.Name = "txtReorderPoint"
        txtReorderPoint.Size = New Size(187, 29)
        txtReorderPoint.TabIndex = 9
        ' 
        ' txtUnitOfMeasure
        ' 
        txtUnitOfMeasure.Font = New Font("Segoe UI", 12.0F)
        txtUnitOfMeasure.Location = New Point(201, 264)
        txtUnitOfMeasure.Name = "txtUnitOfMeasure"
        txtUnitOfMeasure.Size = New Size(187, 29)
        txtUnitOfMeasure.TabIndex = 8
        ' 
        ' lblProductName
        ' 
        lblProductName.Font = New Font("Poppins", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblProductName.Location = New Point(37, 34)
        lblProductName.Name = "lblProductName"
        lblProductName.Size = New Size(195, 36)
        lblProductName.TabIndex = 8
        lblProductName.Text = "PRODUCT NAME :"
        ' 
        ' lblBarcode
        ' 
        lblBarcode.Font = New Font("Poppins", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblBarcode.Location = New Point(37, 79)
        lblBarcode.Name = "lblBarcode"
        lblBarcode.Size = New Size(120, 33)
        lblBarcode.TabIndex = 9
        lblBarcode.Text = "BARCODE :"
        ' 
        ' lblSellingPrice
        ' 
        lblSellingPrice.Font = New Font("Poppins", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSellingPrice.Location = New Point(36, 124)
        lblSellingPrice.Name = "lblSellingPrice"
        lblSellingPrice.Size = New Size(168, 33)
        lblSellingPrice.TabIndex = 10
        lblSellingPrice.Text = "SELLING PRICE :"
        ' 
        ' lblCostPrice
        ' 
        lblCostPrice.Font = New Font("Poppins", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCostPrice.Location = New Point(37, 169)
        lblCostPrice.Name = "lblCostPrice"
        lblCostPrice.Size = New Size(153, 33)
        lblCostPrice.TabIndex = 11
        lblCostPrice.Text = "COST PRICE :"
        ' 
        ' lblDescription
        ' 
        lblDescription.Font = New Font("Poppins", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDescription.Location = New Point(415, 38)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(152, 35)
        lblDescription.TabIndex = 12
        lblDescription.Text = "DESCRIPTION :"
        ' 
        ' lblCategories
        ' 
        lblCategories.Font = New Font("Poppins", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCategories.Location = New Point(415, 169)
        lblCategories.Name = "lblCategories"
        lblCategories.Size = New Size(130, 35)
        lblCategories.TabIndex = 13
        lblCategories.Text = "CATEGORY :"
        lblCategories.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblExpirationOption
        ' 
        lblExpirationOption.Font = New Font("Poppins", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblExpirationOption.Location = New Point(37, 213)
        lblExpirationOption.Name = "lblExpirationOption"
        lblExpirationOption.Size = New Size(205, 38)
        lblExpirationOption.TabIndex = 14
        lblExpirationOption.Text = "EXPIRATION OPTION :"
        ' 
        ' lblSupplier
        ' 
        lblSupplier.Font = New Font("Poppins", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSupplier.Location = New Point(415, 264)
        lblSupplier.Name = "lblSupplier"
        lblSupplier.Size = New Size(130, 35)
        lblSupplier.TabIndex = 17
        lblSupplier.Text = "SUPPLIER :"
        lblSupplier.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblReorderPoint
        ' 
        lblReorderPoint.Font = New Font("Poppins", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblReorderPoint.Location = New Point(37, 313)
        lblReorderPoint.Name = "lblReorderPoint"
        lblReorderPoint.Size = New Size(130, 35)
        lblReorderPoint.TabIndex = 16
        lblReorderPoint.Text = "REORDER POINT :"
        lblReorderPoint.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblUnitOfMeasure
        ' 
        lblUnitOfMeasure.Font = New Font("Poppins", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUnitOfMeasure.Location = New Point(36, 264)
        lblUnitOfMeasure.Name = "lblUnitOfMeasure"
        lblUnitOfMeasure.Size = New Size(130, 35)
        lblUnitOfMeasure.TabIndex = 15
        lblUnitOfMeasure.Text = "UNIT OF MEASURE :"
        lblUnitOfMeasure.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' PanelProduct
        ' 
        PanelProduct.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PanelProduct.BackColor = Color.White
        PanelProduct.Controls.Add(btnViewDeliveryHistory)
        PanelProduct.Controls.Add(btnReceiveDelivery)
        PanelProduct.Controls.Add(lblStockStatus)
        PanelProduct.Controls.Add(lblStockLevel)
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
        PanelProduct.Controls.Add(cmbSuppliers)
        PanelProduct.Controls.Add(txtReorderPoint)
        PanelProduct.Controls.Add(txtUnitOfMeasure)
        PanelProduct.Controls.Add(lblSupplier)
        PanelProduct.Controls.Add(lblReorderPoint)
        PanelProduct.Controls.Add(lblUnitOfMeasure)
        PanelProduct.Location = New Point(12, 93)
        PanelProduct.MinimumSize = New Size(800, 500)
        PanelProduct.MaximumSize = New Size(1200, 800)
        PanelProduct.Name = "PanelProduct"
        PanelProduct.Size = New Size(1016, 650)
        PanelProduct.TabIndex = 19
        PanelProduct.Visible = False
        PanelProduct.AutoScroll = True
        PanelProduct.AutoSize = True
        PanelProduct.AutoSizeMode = AutoSizeMode.GrowAndShrink
        ' 
        ' btnViewDeliveryHistory
        ' 
        btnViewDeliveryHistory.BackColor = Color.RoyalBlue
        btnViewDeliveryHistory.FlatStyle = FlatStyle.Flat
        btnViewDeliveryHistory.ForeColor = Color.White
        btnViewDeliveryHistory.Location = New Point(573, 311)
        btnViewDeliveryHistory.Name = "btnViewDeliveryHistory"
        btnViewDeliveryHistory.Size = New Size(150, 35)
        btnViewDeliveryHistory.TabIndex = 23
        btnViewDeliveryHistory.Text = "View History"
        btnViewDeliveryHistory.UseVisualStyleBackColor = False
        btnViewDeliveryHistory.Visible = False
        ' 
        ' btnReceiveDelivery
        ' 
        btnReceiveDelivery.BackColor = Color.Green
        btnReceiveDelivery.FlatStyle = FlatStyle.Flat
        btnReceiveDelivery.ForeColor = Color.White
        btnReceiveDelivery.Location = New Point(417, 311)
        btnReceiveDelivery.Name = "btnReceiveDelivery"
        btnReceiveDelivery.Size = New Size(150, 35)
        btnReceiveDelivery.TabIndex = 22
        btnReceiveDelivery.Text = "Receive Delivery"
        btnReceiveDelivery.UseVisualStyleBackColor = False
        btnReceiveDelivery.Visible = False
        ' 
        ' lblStockStatus
        ' 
        lblStockStatus.BackColor = Color.LightGray
        lblStockStatus.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStockStatus.Location = New Point(557, 217)
        lblStockStatus.Name = "lblStockStatus"
        lblStockStatus.Size = New Size(130, 25)
        lblStockStatus.TabIndex = 21
        lblStockStatus.Text = "UNKNOWN"
        lblStockStatus.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblStockLevel
        ' 
        lblStockLevel.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStockLevel.Location = New Point(415, 219)
        lblStockLevel.Name = "lblStockLevel"
        lblStockLevel.Size = New Size(200, 25)
        lblStockLevel.TabIndex = 20
        lblStockLevel.Text = "Current Stock: 0"
        ' 
        ' btnExitPanel
        ' 
        btnExitPanel.BackColor = Color.Transparent
        btnExitPanel.FlatAppearance.BorderSize = 0
        btnExitPanel.FlatStyle = FlatStyle.Flat
        btnExitPanel.Image = CType(resources.GetObject("btnExitPanel.Image"), Image)
        btnExitPanel.Location = New Point(781, 3)
        btnExitPanel.Name = "btnExitPanel"
        btnExitPanel.Size = New Size(50, 41)
        btnExitPanel.TabIndex = 69
        btnExitPanel.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.DarkRed
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.ForeColor = SystemColors.ButtonHighlight
        btnDelete.Location = New Point(454, 393)
        btnDelete.Name = "btnDelete"
        btnDelete.Padding = New Padding(1, 0, 0, 0)
        btnDelete.Size = New Size(135, 47)
        btnDelete.TabIndex = 27
        btnDelete.Text = "DELETE"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnEdit
        ' 
        btnEdit.BackColor = Color.DarkRed
        btnEdit.FlatStyle = FlatStyle.Flat
        btnEdit.ForeColor = SystemColors.ButtonHighlight
        btnEdit.Location = New Point(313, 393)
        btnEdit.Name = "btnEdit"
        btnEdit.Padding = New Padding(1, 0, 0, 0)
        btnEdit.Size = New Size(135, 47)
        btnEdit.TabIndex = 26
        btnEdit.Text = "EDIT"
        btnEdit.UseVisualStyleBackColor = False
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.DarkRed
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.ForeColor = SystemColors.ButtonHighlight
        btnSave.Location = New Point(167, 393)
        btnSave.Name = "btnSave"
        btnSave.Padding = New Padding(1, 0, 0, 0)
        btnSave.Size = New Size(135, 47)
        btnSave.TabIndex = 25
        btnSave.Text = "ADD"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.DarkBlue
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.ForeColor = SystemColors.ButtonHighlight
        btnRefresh.Location = New Point(850, 50)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Padding = New Padding(1, 0, 0, 0)
        btnRefresh.Size = New Size(135, 30)
        btnRefresh.TabIndex = 28
        btnRefresh.Text = "REFRESH"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' ProductMain
        ' 
        ClientSize = New Size(1062, 792)
        Controls.Add(PanelProduct)
        Controls.Add(dgvProducts)
        Controls.Add(btnRefresh)
        FormBorderStyle = FormBorderStyle.None
        Name = "ProductMain"
        Text = "Product Management"
        CType(dgvProducts, ComponentModel.ISupportInitialize).EndInit()
        PanelProduct.ResumeLayout(False)
        PanelProduct.PerformLayout()
        ResumeLayout(False)
        '
        ' Adjust the form's properties to allow resizing
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.AutoSizeMode = AutoSizeMode.GrowAndShrink
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
    Friend WithEvents cmbSuppliers As ComboBox
    Friend WithEvents txtReorderPoint As TextBox
    Friend WithEvents txtUnitOfMeasure As TextBox

    ' Declare Labels
    Friend WithEvents lblProductName As Label
    Friend WithEvents lblBarcode As Label
    Friend WithEvents lblSellingPrice As Label
    Friend WithEvents lblCostPrice As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblCategories As Label
    Friend WithEvents lblExpirationOption As Label
    Friend WithEvents lblSupplier As Label
    Friend WithEvents lblReorderPoint As Label
    Friend WithEvents lblUnitOfMeasure As Label
    Friend WithEvents PanelProduct As Panel
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnExitPanel As Button
    
    ' New controls for improved workflow
    Friend WithEvents lblStockLevel As Label
    Friend WithEvents lblStockStatus As Label
    Friend WithEvents btnReceiveDelivery As Button
    Friend WithEvents btnViewDeliveryHistory As Button
    Friend WithEvents btnRefresh As Button
End Class
