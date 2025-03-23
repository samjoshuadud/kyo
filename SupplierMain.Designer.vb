<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SupplierMain
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
        dgvSuppliers = New DataGridView()
        txtSupplierID = New TextBox()
        txtSupplierName = New TextBox()
        txtAddress = New TextBox()
        txtContactNumber = New TextBox()
        txtEmail = New TextBox()
        lblSupplierID = New Label()
        lblSupplierName = New Label()
        lblAddress = New Label()
        lblContactNumber = New Label()
        lblEmail = New Label()
        btnAdd = New Button()
        btnEdit = New Button()
        btnDelete = New Button()
        btnSearch = New Button()
        CType(dgvSuppliers, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvSuppliers
        ' 
        dgvSuppliers.ColumnHeadersHeight = 34
        dgvSuppliers.Location = New Point(14, 138)
        dgvSuppliers.Margin = New Padding(2, 2, 2, 2)
        dgvSuppliers.Name = "dgvSuppliers"
        dgvSuppliers.RowHeadersWidth = 62
        dgvSuppliers.Size = New Size(698, 314)
        dgvSuppliers.TabIndex = 0
        ' 
        ' txtSupplierID
        ' 
        txtSupplierID.Location = New Point(145, 12)
        txtSupplierID.Margin = New Padding(2, 2, 2, 2)
        txtSupplierID.Name = "txtSupplierID"
        txtSupplierID.ReadOnly = True
        txtSupplierID.Size = New Size(71, 23)
        txtSupplierID.TabIndex = 1
        ' 
        ' txtSupplierName
        ' 
        txtSupplierName.Location = New Point(145, 30)
        txtSupplierName.Margin = New Padding(2, 2, 2, 2)
        txtSupplierName.Name = "txtSupplierName"
        txtSupplierName.Size = New Size(71, 23)
        txtSupplierName.TabIndex = 2
        ' 
        ' txtAddress
        ' 
        txtAddress.Location = New Point(145, 48)
        txtAddress.Margin = New Padding(2, 2, 2, 2)
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(71, 23)
        txtAddress.TabIndex = 3
        ' 
        ' txtContactNumber
        ' 
        txtContactNumber.Location = New Point(145, 66)
        txtContactNumber.Margin = New Padding(2, 2, 2, 2)
        txtContactNumber.Name = "txtContactNumber"
        txtContactNumber.Size = New Size(71, 23)
        txtContactNumber.TabIndex = 4
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(145, 84)
        txtEmail.Margin = New Padding(2, 2, 2, 2)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(71, 23)
        txtEmail.TabIndex = 5
        ' 
        ' lblSupplierID
        ' 
        lblSupplierID.Location = New Point(14, 12)
        lblSupplierID.Margin = New Padding(2, 0, 2, 0)
        lblSupplierID.Name = "lblSupplierID"
        lblSupplierID.Size = New Size(110, 14)
        lblSupplierID.TabIndex = 6
        lblSupplierID.Text = "Supplier ID:"
        ' 
        ' lblSupplierName
        ' 
        lblSupplierName.Location = New Point(14, 30)
        lblSupplierName.Margin = New Padding(2, 0, 2, 0)
        lblSupplierName.Name = "lblSupplierName"
        lblSupplierName.Size = New Size(110, 14)
        lblSupplierName.TabIndex = 7
        lblSupplierName.Text = "Supplier Name:"
        ' 
        ' lblAddress
        ' 
        lblAddress.Location = New Point(14, 48)
        lblAddress.Margin = New Padding(2, 0, 2, 0)
        lblAddress.Name = "lblAddress"
        lblAddress.Size = New Size(110, 14)
        lblAddress.TabIndex = 8
        lblAddress.Text = "Address:"
        ' 
        ' lblContactNumber
        ' 
        lblContactNumber.Location = New Point(14, 66)
        lblContactNumber.Margin = New Padding(2, 0, 2, 0)
        lblContactNumber.Name = "lblContactNumber"
        lblContactNumber.Size = New Size(110, 14)
        lblContactNumber.TabIndex = 9
        lblContactNumber.Text = "Contact Number:"
        ' 
        ' lblEmail
        ' 
        lblEmail.Location = New Point(14, 84)
        lblEmail.Margin = New Padding(2, 0, 2, 0)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(110, 14)
        lblEmail.TabIndex = 10
        lblEmail.Text = "Email:"
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(248, 68)
        btnAdd.Margin = New Padding(2, 2, 2, 2)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(52, 29)
        btnAdd.TabIndex = 11
        btnAdd.Text = "Add"
        ' 
        ' btnEdit
        ' 
        btnEdit.Location = New Point(304, 68)
        btnEdit.Margin = New Padding(2, 2, 2, 2)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(52, 29)
        btnEdit.TabIndex = 12
        btnEdit.Text = "Edit"
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(360, 68)
        btnDelete.Margin = New Padding(2, 2, 2, 2)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(52, 29)
        btnDelete.TabIndex = 13
        btnDelete.Text = "Delete"
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(416, 68)
        btnSearch.Margin = New Padding(2, 2, 2, 2)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(52, 29)
        btnSearch.TabIndex = 14
        btnSearch.Text = "Search"
        ' 
        ' SupplierMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(723, 510)
        Controls.Add(dgvSuppliers)
        Controls.Add(txtSupplierID)
        Controls.Add(txtSupplierName)
        Controls.Add(txtAddress)
        Controls.Add(txtContactNumber)
        Controls.Add(txtEmail)
        Controls.Add(lblSupplierID)
        Controls.Add(lblSupplierName)
        Controls.Add(lblAddress)
        Controls.Add(lblContactNumber)
        Controls.Add(lblEmail)
        Controls.Add(btnAdd)
        Controls.Add(btnEdit)
        Controls.Add(btnDelete)
        Controls.Add(btnSearch)
        Margin = New Padding(2, 2, 2, 2)
        Name = "SupplierMain"
        Text = "Supplier Management"
        CType(dgvSuppliers, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvSuppliers As System.Windows.Forms.DataGridView
    Friend WithEvents txtSupplierID As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtContactNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplierID As System.Windows.Forms.Label
    Friend WithEvents lblSupplierName As System.Windows.Forms.Label
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents lblContactNumber As System.Windows.Forms.Label
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button

End Class
