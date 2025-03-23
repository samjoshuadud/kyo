<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InventoryMain
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
        dgvInventory = New DataGridView()
        btnAdd = New Button()
        btnEdit = New Button()
        btnDelete = New Button()
        btnRefresh = New Button()
        txtSearch = New TextBox()
        lblSearch = New Label()
        txtProductName = New TextBox()
        lblProduct = New Label()
        txtQuantity = New TextBox()
        lblQuantity = New Label()
        CType(dgvInventory, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvInventory
        ' 
        dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvInventory.Location = New Point(21, 72)
        dgvInventory.Margin = New Padding(2, 2, 2, 2)
        dgvInventory.Name = "dgvInventory"
        dgvInventory.Size = New Size(560, 216)
        dgvInventory.TabIndex = 0
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(595, 72)
        btnAdd.Margin = New Padding(2, 2, 2, 2)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(70, 24)
        btnAdd.TabIndex = 1
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' btnEdit
        ' 
        btnEdit.Location = New Point(595, 102)
        btnEdit.Margin = New Padding(2, 2, 2, 2)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(70, 24)
        btnEdit.TabIndex = 2
        btnEdit.Text = "Edit"
        btnEdit.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(595, 132)
        btnDelete.Margin = New Padding(2, 2, 2, 2)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(70, 24)
        btnDelete.TabIndex = 3
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Location = New Point(595, 162)
        btnRefresh.Margin = New Padding(2, 2, 2, 2)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(70, 24)
        btnRefresh.TabIndex = 4
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(84, 18)
        txtSearch.Margin = New Padding(2, 2, 2, 2)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(211, 23)
        txtSearch.TabIndex = 5
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Location = New Point(21, 21)
        lblSearch.Margin = New Padding(2, 0, 2, 0)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(45, 15)
        lblSearch.TabIndex = 6
        lblSearch.Text = "Search:"
        ' 
        ' txtProductName
        ' 
        txtProductName.Location = New Point(84, 42)
        txtProductName.Margin = New Padding(2, 2, 2, 2)
        txtProductName.Name = "txtProductName"
        txtProductName.Size = New Size(141, 23)
        txtProductName.TabIndex = 6
        ' 
        ' lblProduct
        ' 
        lblProduct.AutoSize = True
        lblProduct.Location = New Point(21, 45)
        lblProduct.Margin = New Padding(2, 0, 2, 0)
        lblProduct.Name = "lblProduct"
        lblProduct.Size = New Size(52, 15)
        lblProduct.TabIndex = 7
        lblProduct.Text = "Product:"
        ' 
        ' txtQuantity
        ' 
        txtQuantity.Location = New Point(308, 42)
        txtQuantity.Margin = New Padding(2, 2, 2, 2)
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(71, 23)
        txtQuantity.TabIndex = 7
        ' 
        ' lblQuantity
        ' 
        lblQuantity.AutoSize = True
        lblQuantity.Location = New Point(245, 45)
        lblQuantity.Margin = New Padding(2, 0, 2, 0)
        lblQuantity.Name = "lblQuantity"
        lblQuantity.Size = New Size(56, 15)
        lblQuantity.TabIndex = 8
        lblQuantity.Text = "Quantity:"
        ' 
        ' InventoryMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(812, 422)
        Controls.Add(dgvInventory)
        Controls.Add(btnAdd)
        Controls.Add(btnEdit)
        Controls.Add(btnDelete)
        Controls.Add(btnRefresh)
        Controls.Add(txtSearch)
        Controls.Add(lblSearch)
        Controls.Add(txtProductName)
        Controls.Add(lblProduct)
        Controls.Add(txtQuantity)
        Controls.Add(lblQuantity)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Margin = New Padding(2, 2, 2, 2)
        Name = "InventoryMain"
        Text = "Inventory Management"
        CType(dgvInventory, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvInventory As DataGridView
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents lblProduct As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents lblQuantity As Label
End Class
