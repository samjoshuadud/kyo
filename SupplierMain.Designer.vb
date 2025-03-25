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
        txtSupplierName = New TextBox()
        txtAddress = New TextBox()
        txtContactNumber = New TextBox()
        txtEmail = New TextBox()
        lblSupplierName = New Label()
        lblAddress = New Label()
        lblContactNumber = New Label()
        lblEmail = New Label()
        btnAdd = New Button()
        btnEdit = New Button()
        btnDelete = New Button()
        btnReset = New Button()
        pnlInputs = New Panel()
        CType(dgvSuppliers, ComponentModel.ISupportInitialize).BeginInit()
        pnlInputs.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvSuppliers
        ' 
        dgvSuppliers.AllowUserToAddRows = False
        dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvSuppliers.ColumnHeadersHeight = 34
        dgvSuppliers.Location = New Point(14, 200)
        dgvSuppliers.Margin = New Padding(2)
        dgvSuppliers.Name = "dgvSuppliers"
        dgvSuppliers.RowHeadersWidth = 62
        dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSuppliers.Size = New Size(698, 314)
        dgvSuppliers.TabIndex = 0
        ' 
        ' pnlInputs
        ' 
        pnlInputs.Controls.Add(txtSupplierName)
        pnlInputs.Controls.Add(txtAddress)
        pnlInputs.Controls.Add(txtContactNumber)
        pnlInputs.Controls.Add(txtEmail)
        pnlInputs.Controls.Add(lblSupplierName)
        pnlInputs.Controls.Add(lblAddress)
        pnlInputs.Controls.Add(lblContactNumber)
        pnlInputs.Controls.Add(lblEmail)
        pnlInputs.Location = New Point(14, 12)
        pnlInputs.Size = New Size(400, 150)
        pnlInputs.TabIndex = 15
        ' 
        ' txtSupplierName
        ' 
        txtSupplierName.Location = New Point(145, 20)
        txtSupplierName.Margin = New Padding(2)
        txtSupplierName.Name = "txtSupplierName"
        txtSupplierName.Size = New Size(200, 23)
        txtSupplierName.TabIndex = 2
        ' 
        ' txtAddress
        ' 
        txtAddress.Location = New Point(145, 50)
        txtAddress.Margin = New Padding(2)
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(200, 23)
        txtAddress.TabIndex = 3
        ' 
        ' txtContactNumber
        ' 
        txtContactNumber.Location = New Point(145, 80)
        txtContactNumber.Margin = New Padding(2)
        txtContactNumber.Name = "txtContactNumber"
        txtContactNumber.Size = New Size(200, 23)
        txtContactNumber.TabIndex = 4
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(145, 110)
        txtEmail.Margin = New Padding(2)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(200, 23)
        txtEmail.TabIndex = 5
        ' 
        ' lblSupplierName
        ' 
        lblSupplierName.Location = New Point(14, 23)
        lblSupplierName.Margin = New Padding(2, 0, 2, 0)
        lblSupplierName.Name = "lblSupplierName"
        lblSupplierName.Size = New Size(110, 14)
        lblSupplierName.TabIndex = 7
        lblSupplierName.Text = "Supplier Name:"
        ' 
        ' lblAddress
        ' 
        lblAddress.Location = New Point(14, 53)
        lblAddress.Margin = New Padding(2, 0, 2, 0)
        lblAddress.Name = "lblAddress"
        lblAddress.Size = New Size(110, 14)
        lblAddress.TabIndex = 8
        lblAddress.Text = "Address:"
        ' 
        ' lblContactNumber
        ' 
        lblContactNumber.Location = New Point(14, 83)
        lblContactNumber.Margin = New Padding(2, 0, 2, 0)
        lblContactNumber.Name = "lblContactNumber"
        lblContactNumber.Size = New Size(110, 14)
        lblContactNumber.TabIndex = 9
        lblContactNumber.Text = "Contact Number:"
        ' 
        ' lblEmail
        ' 
        lblEmail.Location = New Point(14, 113)
        lblEmail.Margin = New Padding(2, 0, 2, 0)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(110, 14)
        lblEmail.TabIndex = 10
        lblEmail.Text = "Email:"
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(450, 30)
        btnAdd.Margin = New Padding(2)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(80, 29)
        btnAdd.TabIndex = 11
        btnAdd.Text = "Add"
        ' 
        ' btnEdit
        ' 
        btnEdit.Location = New Point(450, 70)
        btnEdit.Margin = New Padding(2)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(80, 29)
        btnEdit.TabIndex = 12
        btnEdit.Text = "Edit"
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(450, 110)
        btnDelete.Margin = New Padding(2)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(80, 29)
        btnDelete.TabIndex = 13
        btnDelete.Text = "Delete"
        ' 
        ' btnReset
        ' 
        btnReset.Location = New Point(450, 150)
        btnReset.Margin = New Padding(2)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(80, 29)
        btnReset.TabIndex = 14
        btnReset.Text = "Reset"
        ' 
        ' SupplierMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(723, 530)
        Controls.Add(pnlInputs)
        Controls.Add(dgvSuppliers)
        Controls.Add(btnAdd)
        Controls.Add(btnEdit)
        Controls.Add(btnDelete)
        Controls.Add(btnReset)
        Margin = New Padding(2)
        Name = "SupplierMain"
        Text = "Supplier Management"
        CType(dgvSuppliers, ComponentModel.ISupportInitialize).EndInit()
        pnlInputs.ResumeLayout(False)
        pnlInputs.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvSuppliers As DataGridView
    Friend WithEvents txtSupplierName As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtContactNumber As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblSupplierName As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents lblContactNumber As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents pnlInputs As Panel

End Class
