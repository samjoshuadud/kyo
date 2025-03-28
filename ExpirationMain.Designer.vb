<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExpirationMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        dgvExpiration = New DataGridView()
        lblNotification = New Label()
        pnlInputs = New Panel()
        lblQuantity = New Label()
        txtQuantity = New TextBox()
        dtpExpirationDate = New DateTimePicker()
        lblExpirationDate = New Label()
        txtProductName = New TextBox()
        lblProductName = New Label()
        btnAdd = New Button()
        btnEdit = New Button()
        btnDelete = New Button()
        btnDispose = New Button()
        btnSave = New Button()
        btnRefresh = New Button()
        btnClose = New Button()
        btnCheckExpiring = New Button()
        CType(dgvExpiration, ComponentModel.ISupportInitialize).BeginInit()
        pnlInputs.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvExpiration
        ' 
        dgvExpiration.AllowUserToAddRows = False
        dgvExpiration.AllowUserToDeleteRows = False
        dgvExpiration.AllowUserToOrderColumns = True
        dgvExpiration.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvExpiration.Location = New Point(14, 36)
        dgvExpiration.Margin = New Padding(2, 2, 2, 2)
        dgvExpiration.MultiSelect = False
        dgvExpiration.Name = "dgvExpiration"
        dgvExpiration.ReadOnly = True
        dgvExpiration.RowHeadersWidth = 62
        dgvExpiration.RowTemplate.Height = 33
        dgvExpiration.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvExpiration.Size = New Size(790, 150)
        dgvExpiration.TabIndex = 0
        ' 
        ' lblNotification
        ' 
        lblNotification.BackColor = Color.LightYellow
        lblNotification.BorderStyle = BorderStyle.FixedSingle
        lblNotification.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblNotification.Location = New Point(14, 12)
        lblNotification.Margin = New Padding(2, 0, 2, 0)
        lblNotification.Name = "lblNotification"
        lblNotification.Size = New Size(790, 19)
        lblNotification.TabIndex = 1
        lblNotification.TextAlign = ContentAlignment.MiddleCenter
        lblNotification.Visible = False
        ' 
        ' pnlInputs
        ' 
        pnlInputs.BackColor = Color.White
        pnlInputs.BorderStyle = BorderStyle.FixedSingle
        pnlInputs.Controls.Add(btnCheckExpiring)
        pnlInputs.Controls.Add(lblQuantity)
        pnlInputs.Controls.Add(txtQuantity)
        pnlInputs.Controls.Add(dtpExpirationDate)
        pnlInputs.Controls.Add(lblExpirationDate)
        pnlInputs.Controls.Add(txtProductName)
        pnlInputs.Controls.Add(lblProductName)
        pnlInputs.Location = New Point(14, 192)
        pnlInputs.Margin = New Padding(2, 2, 2, 2)
        pnlInputs.Name = "pnlInputs"
        pnlInputs.Size = New Size(790, 132)
        pnlInputs.TabIndex = 2
        ' 
        ' lblQuantity
        ' 
        lblQuantity.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblQuantity.Location = New Point(7, 85)
        lblQuantity.Margin = New Padding(2, 0, 2, 0)
        lblQuantity.Name = "lblQuantity"
        lblQuantity.Size = New Size(94, 23)
        lblQuantity.TabIndex = 5
        lblQuantity.Text = "Quantity:"
        ' 
        ' txtQuantity
        ' 
        txtQuantity.Location = New Point(105, 84)
        txtQuantity.Margin = New Padding(2, 2, 2, 2)
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(176, 23)
        txtQuantity.TabIndex = 4
        ' 
        ' dtpExpirationDate
        ' 
        dtpExpirationDate.Format = DateTimePickerFormat.Short
        dtpExpirationDate.Location = New Point(105, 47)
        dtpExpirationDate.Margin = New Padding(2, 2, 2, 2)
        dtpExpirationDate.Name = "dtpExpirationDate"
        dtpExpirationDate.Size = New Size(176, 23)
        dtpExpirationDate.TabIndex = 3
        ' 
        ' lblExpirationDate
        ' 
        lblExpirationDate.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblExpirationDate.Location = New Point(7, 51)
        lblExpirationDate.Margin = New Padding(2, 0, 2, 0)
        lblExpirationDate.Name = "lblExpirationDate"
        lblExpirationDate.Size = New Size(94, 23)
        lblExpirationDate.TabIndex = 2
        lblExpirationDate.Text = "Expiration Date:"
        ' 
        ' txtProductName
        ' 
        txtProductName.Location = New Point(105, 12)
        txtProductName.Margin = New Padding(2, 2, 2, 2)
        txtProductName.Name = "txtProductName"
        txtProductName.ReadOnly = True
        txtProductName.Size = New Size(176, 23)
        txtProductName.TabIndex = 1
        ' 
        ' lblProductName
        ' 
        lblProductName.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblProductName.Location = New Point(7, 12)
        lblProductName.Margin = New Padding(2, 0, 2, 0)
        lblProductName.Name = "lblProductName"
        lblProductName.Size = New Size(94, 23)
        lblProductName.TabIndex = 0
        lblProductName.Text = "Product Name:"
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.FromArgb(CByte(176), CByte(0), CByte(32))
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(17, 341)
        btnAdd.Margin = New Padding(2, 2, 2, 2)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(98, 39)
        btnAdd.TabIndex = 3
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnEdit
        ' 
        btnEdit.BackColor = Color.FromArgb(CByte(176), CByte(0), CByte(32))
        btnEdit.FlatStyle = FlatStyle.Flat
        btnEdit.ForeColor = Color.White
        btnEdit.Location = New Point(129, 341)
        btnEdit.Margin = New Padding(2, 2, 2, 2)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(98, 39)
        btnEdit.TabIndex = 4
        btnEdit.Text = "Edit"
        btnEdit.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.FromArgb(CByte(176), CByte(0), CByte(32))
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(241, 341)
        btnDelete.Margin = New Padding(2, 2, 2, 2)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(98, 39)
        btnDelete.TabIndex = 5
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnDispose
        ' 
        btnDispose.BackColor = Color.DarkOrange
        btnDispose.FlatStyle = FlatStyle.Flat
        btnDispose.ForeColor = Color.White
        btnDispose.Location = New Point(353, 341)
        btnDispose.Margin = New Padding(2, 2, 2, 2)
        btnDispose.Name = "btnDispose"
        btnDispose.Size = New Size(98, 39)
        btnDispose.TabIndex = 10
        btnDispose.Text = "Dispose"
        btnDispose.UseVisualStyleBackColor = False
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.FromArgb(CByte(176), CByte(0), CByte(32))
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(465, 341)
        btnSave.Margin = New Padding(2, 2, 2, 2)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(98, 39)
        btnSave.TabIndex = 6
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.FromArgb(CByte(176), CByte(0), CByte(32))
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(577, 341)
        btnRefresh.Margin = New Padding(2, 2, 2, 2)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(98, 39)
        btnRefresh.TabIndex = 7
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.FromArgb(CByte(176), CByte(0), CByte(32))
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(689, 341)
        btnClose.Margin = New Padding(2, 2, 2, 2)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(98, 39)
        btnClose.TabIndex = 8
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' btnCheckExpiring
        ' 
        btnCheckExpiring.BackColor = Color.Orange
        btnCheckExpiring.FlatStyle = FlatStyle.Flat
        btnCheckExpiring.ForeColor = Color.White
        btnCheckExpiring.Location = New Point(651, 12)
        btnCheckExpiring.Margin = New Padding(2, 2, 2, 2)
        btnCheckExpiring.Name = "btnCheckExpiring"
        btnCheckExpiring.Size = New Size(126, 39)
        btnCheckExpiring.TabIndex = 9
        btnCheckExpiring.Text = "Check Expiring"
        btnCheckExpiring.UseVisualStyleBackColor = False
        ' 
        ' ExpirationMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(815, 499)
        Controls.Add(btnClose)
        Controls.Add(btnRefresh)
        Controls.Add(btnSave)
        Controls.Add(btnDispose)
        Controls.Add(btnDelete)
        Controls.Add(btnEdit)
        Controls.Add(btnAdd)
        Controls.Add(pnlInputs)
        Controls.Add(lblNotification)
        Controls.Add(dgvExpiration)
        Margin = New Padding(2, 2, 2, 2)
        Name = "ExpirationMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Expiration Management"
        CType(dgvExpiration, ComponentModel.ISupportInitialize).EndInit()
        pnlInputs.ResumeLayout(False)
        pnlInputs.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents dgvExpiration As DataGridView
    Friend WithEvents lblNotification As Label
    Friend WithEvents pnlInputs As Panel
    Friend WithEvents lblProductName As Label
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents lblExpirationDate As Label
    Friend WithEvents dtpExpirationDate As DateTimePicker
    Friend WithEvents lblQuantity As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnDispose As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnCheckExpiring As Button
End Class
