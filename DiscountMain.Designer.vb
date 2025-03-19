<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DiscountMain
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
        dgvDiscounts = New DataGridView()
        pnlInputs = New Panel()
        lblDiscountName = New Label()
        txtDiscountName = New TextBox()
        lblDiscountRate = New Label()
        txtDiscountRate = New TextBox()
        btnAdd = New Button()
        btnEdit = New Button()
        btnDelete = New Button()
        btnClose = New Button()
        CType(dgvDiscounts, ComponentModel.ISupportInitialize).BeginInit()
        pnlInputs.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvDiscounts
        ' 
        dgvDiscounts.ColumnHeadersHeight = 34
        dgvDiscounts.Location = New Point(193, 78)
        dgvDiscounts.Name = "dgvDiscounts"
        dgvDiscounts.ReadOnly = True
        dgvDiscounts.RowHeadersWidth = 62
        dgvDiscounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDiscounts.Size = New Size(640, 200)
        dgvDiscounts.TabIndex = 0
        ' 
        ' pnlInputs
        ' 
        pnlInputs.BorderStyle = BorderStyle.FixedSingle
        pnlInputs.Controls.Add(lblDiscountName)
        pnlInputs.Controls.Add(txtDiscountName)
        pnlInputs.Controls.Add(lblDiscountRate)
        pnlInputs.Controls.Add(txtDiscountRate)
        pnlInputs.Location = New Point(193, 298)
        pnlInputs.Name = "pnlInputs"
        pnlInputs.Size = New Size(640, 150)
        pnlInputs.TabIndex = 1
        ' 
        ' lblDiscountName
        ' 
        lblDiscountName.Location = New Point(10, 20)
        lblDiscountName.Name = "lblDiscountName"
        lblDiscountName.Size = New Size(100, 23)
        lblDiscountName.TabIndex = 0
        lblDiscountName.Text = "Discount Name:"
        ' 
        ' txtDiscountName
        ' 
        txtDiscountName.Location = New Point(150, 20)
        txtDiscountName.Name = "txtDiscountName"
        txtDiscountName.Size = New Size(200, 31)
        txtDiscountName.TabIndex = 1
        ' 
        ' lblDiscountRate
        ' 
        lblDiscountRate.Location = New Point(10, 60)
        lblDiscountRate.Name = "lblDiscountRate"
        lblDiscountRate.Size = New Size(100, 23)
        lblDiscountRate.TabIndex = 2
        lblDiscountRate.Text = "Discount Rate (%):"
        ' 
        ' txtDiscountRate
        ' 
        txtDiscountRate.Location = New Point(150, 60)
        txtDiscountRate.Name = "txtDiscountRate"
        txtDiscountRate.Size = New Size(200, 31)
        txtDiscountRate.TabIndex = 3
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(193, 478)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(120, 40)
        btnAdd.TabIndex = 2
        btnAdd.Text = "Add"
        ' 
        ' btnEdit
        ' 
        btnEdit.Location = New Point(333, 478)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(120, 40)
        btnEdit.TabIndex = 3
        btnEdit.Text = "Edit"
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(473, 478)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(120, 40)
        btnDelete.TabIndex = 4
        btnDelete.Text = "Delete"
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(613, 478)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(120, 40)
        btnClose.TabIndex = 5
        btnClose.Text = "Close"
        ' 
        ' DiscountMain
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1085, 754)
        Controls.Add(dgvDiscounts)
        Controls.Add(pnlInputs)
        Controls.Add(btnAdd)
        Controls.Add(btnEdit)
        Controls.Add(btnDelete)
        Controls.Add(btnClose)
        FormBorderStyle = FormBorderStyle.None
        Name = "DiscountMain"
        Text = "Discount Management"
        CType(dgvDiscounts, ComponentModel.ISupportInitialize).EndInit()
        pnlInputs.ResumeLayout(False)
        pnlInputs.PerformLayout()
        ResumeLayout(False)
    End Sub

    Private WithEvents dgvDiscounts As System.Windows.Forms.DataGridView
    Private pnlInputs As System.Windows.Forms.Panel
    Private lblDiscountName As System.Windows.Forms.Label
    Private txtDiscountName As System.Windows.Forms.TextBox
    Private lblDiscountRate As System.Windows.Forms.Label
    Private txtDiscountRate As System.Windows.Forms.TextBox
    Private WithEvents btnAdd As System.Windows.Forms.Button
    Private WithEvents btnEdit As System.Windows.Forms.Button
    Private WithEvents btnDelete As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button

End Class
