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
        Me.dgvInventory = New System.Windows.Forms.DataGridView()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtProductName = New System.Windows.Forms.TextBox()
        Me.lblProduct = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.lblQuantity = New System.Windows.Forms.Label()

        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        ' DataGridView
        Me.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventory.Location = New System.Drawing.Point(30, 120)
        Me.dgvInventory.Name = "dgvInventory"
        Me.dgvInventory.Size = New System.Drawing.Size(800, 360)
        Me.dgvInventory.TabIndex = 0

        ' Buttons
        Me.btnAdd.Location = New System.Drawing.Point(850, 120)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 40)
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True

        Me.btnEdit.Location = New System.Drawing.Point(850, 170)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 40)
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True

        Me.btnDelete.Location = New System.Drawing.Point(850, 220)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(100, 40)
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True

        Me.btnRefresh.Location = New System.Drawing.Point(850, 270)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(100, 40)
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True

        ' Search
        Me.txtSearch.Location = New System.Drawing.Point(120, 30)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(300, 30)
        Me.txtSearch.TabIndex = 5

        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(30, 35)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(70, 25)
        Me.lblSearch.Text = "Search:"

        ' Product
        Me.lblProduct.AutoSize = True
        Me.lblProduct.Location = New System.Drawing.Point(30, 75)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(78, 25)
        Me.lblProduct.Text = "Product:"

        Me.txtProductName.Location = New System.Drawing.Point(120, 70)
        Me.txtProductName.Name = "txtProduct"
        Me.txtProductName.Size = New System.Drawing.Size(200, 30)
        Me.txtProductName.TabIndex = 6

        ' Quantity
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Location = New System.Drawing.Point(350, 75)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(85, 25)
        Me.lblQuantity.Text = "Quantity:"

        Me.txtQuantity.Location = New System.Drawing.Point(440, 70)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(100, 30)
        Me.txtQuantity.TabIndex = 7

        ' Form
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 550)
        Me.Controls.Add(Me.dgvInventory)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.txtProductName)
        Me.Controls.Add(Me.lblProduct)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.lblQuantity)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "InventoryMain"
        Me.Text = "Inventory Management"

        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
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
