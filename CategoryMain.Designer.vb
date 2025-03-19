<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CategoryMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CategoryMain))
        dgvCategories = New DataGridView()
        txtCategoryId = New TextBox()
        txtCategoryName = New TextBox()
        txtDescription = New TextBox()
        lblCategoryName = New Label()
        lblDescription = New Label()
        PanelCategory = New Panel()
        btnDelete = New Button()
        btnEdit = New Button()
        btnAdd = New Button()
        Panel3 = New Panel()
        Button2 = New Button()
        Label1 = New Label()
        Button1 = New Button()
        btnAddcat = New Button()
        CType(dgvCategories, ComponentModel.ISupportInitialize).BeginInit()
        PanelCategory.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvCategories
        ' 
        dgvCategories.ColumnHeadersHeight = 34
        dgvCategories.Location = New Point(0, 238)
        dgvCategories.Name = "dgvCategories"
        dgvCategories.ReadOnly = True
        dgvCategories.RowHeadersWidth = 62
        dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCategories.Size = New Size(1505, 645)
        dgvCategories.TabIndex = 0
        ' 
        ' txtCategoryId
        ' 
        txtCategoryId.Location = New Point(1171, 186)
        txtCategoryId.Name = "txtCategoryId"
        txtCategoryId.Size = New Size(100, 31)
        txtCategoryId.TabIndex = 1
        txtCategoryId.Visible = False
        ' 
        ' txtCategoryName
        ' 
        txtCategoryName.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtCategoryName.Location = New Point(256, 96)
        txtCategoryName.Name = "txtCategoryName"
        txtCategoryName.Size = New Size(438, 39)
        txtCategoryName.TabIndex = 2
        ' 
        ' txtDescription
        ' 
        txtDescription.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtDescription.Location = New Point(256, 157)
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(438, 39)
        txtDescription.TabIndex = 3
        ' 
        ' lblCategoryName
        ' 
        lblCategoryName.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCategoryName.Location = New Point(47, 96)
        lblCategoryName.Name = "lblCategoryName"
        lblCategoryName.Size = New Size(215, 45)
        lblCategoryName.TabIndex = 4
        lblCategoryName.Text = "CATEGORY NAME :"
        ' 
        ' lblDescription
        ' 
        lblDescription.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDescription.Location = New Point(47, 157)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(175, 38)
        lblDescription.TabIndex = 5
        lblDescription.Text = "DISCRIPTION :"
        ' 
        ' PanelCategory
        ' 
        PanelCategory.Controls.Add(btnDelete)
        PanelCategory.Controls.Add(btnEdit)
        PanelCategory.Controls.Add(btnAdd)
        PanelCategory.Controls.Add(Panel3)
        PanelCategory.Controls.Add(txtCategoryName)
        PanelCategory.Controls.Add(lblCategoryName)
        PanelCategory.Controls.Add(txtDescription)
        PanelCategory.Controls.Add(lblDescription)
        PanelCategory.Location = New Point(406, 205)
        PanelCategory.Name = "PanelCategory"
        PanelCategory.Size = New Size(741, 318)
        PanelCategory.TabIndex = 10
        PanelCategory.Visible = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = SystemColors.GrayText
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.ForeColor = SystemColors.ButtonHighlight
        btnDelete.Location = New Point(538, 237)
        btnDelete.Name = "btnDelete"
        btnDelete.Padding = New Padding(1, 0, 0, 0)
        btnDelete.Size = New Size(135, 47)
        btnDelete.TabIndex = 24
        btnDelete.Text = "DELETE"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnEdit
        ' 
        btnEdit.BackColor = SystemColors.ActiveCaptionText
        btnEdit.FlatStyle = FlatStyle.Flat
        btnEdit.ForeColor = SystemColors.ButtonHighlight
        btnEdit.Location = New Point(397, 237)
        btnEdit.Name = "btnEdit"
        btnEdit.Padding = New Padding(1, 0, 0, 0)
        btnEdit.Size = New Size(135, 47)
        btnEdit.TabIndex = 23
        btnEdit.Text = "EDIT"
        btnEdit.UseVisualStyleBackColor = False
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = SystemColors.ActiveCaptionText
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.ForeColor = SystemColors.ButtonHighlight
        btnAdd.Location = New Point(256, 237)
        btnAdd.Name = "btnAdd"
        btnAdd.Padding = New Padding(1, 0, 0, 0)
        btnAdd.Size = New Size(135, 47)
        btnAdd.TabIndex = 22
        btnAdd.Text = "ADD"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.Transparent
        Panel3.Controls.Add(Button2)
        Panel3.Dock = DockStyle.Top
        Panel3.Location = New Point(0, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(741, 56)
        Panel3.TabIndex = 14
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.Transparent
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Image = CType(resources.GetObject("Button2.Image"), Image)
        Button2.Location = New Point(676, 1)
        Button2.Name = "Button2"
        Button2.Size = New Size(62, 56)
        Button2.TabIndex = 67
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(12, 18)
        Label1.Name = "Label1"
        Label1.Size = New Size(222, 38)
        Label1.TabIndex = 11
        Label1.Text = "CATEGORY LIST"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Transparent
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Image = CType(resources.GetObject("Button1.Image"), Image)
        Button1.Location = New Point(1417, 11)
        Button1.Name = "Button1"
        Button1.Size = New Size(74, 61)
        Button1.TabIndex = 68
        Button1.UseVisualStyleBackColor = False
        ' 
        ' btnAddcat
        ' 
        btnAddcat.BackColor = Color.Transparent
        btnAddcat.FlatAppearance.BorderSize = 0
        btnAddcat.FlatStyle = FlatStyle.Flat
        btnAddcat.Image = CType(resources.GetObject("btnAddcat.Image"), Image)
        btnAddcat.Location = New Point(0, 160)
        btnAddcat.Name = "btnAddcat"
        btnAddcat.Size = New Size(67, 57)
        btnAddcat.TabIndex = 69
        btnAddcat.UseVisualStyleBackColor = False
        ' 
        ' CategoryMain
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1503, 816)
        Controls.Add(btnAddcat)
        Controls.Add(Button1)
        Controls.Add(Label1)
        Controls.Add(txtCategoryId)
        Controls.Add(PanelCategory)
        Controls.Add(dgvCategories)
        FormBorderStyle = FormBorderStyle.None
        Name = "CategoryMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Category Management"
        CType(dgvCategories, ComponentModel.ISupportInitialize).EndInit()
        PanelCategory.ResumeLayout(False)
        PanelCategory.PerformLayout()
        Panel3.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvCategories As System.Windows.Forms.DataGridView
    Friend WithEvents txtCategoryId As System.Windows.Forms.TextBox
    Friend WithEvents txtCategoryName As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblCategoryName As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents PanelCategory As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents btnAddcat As Button

End Class
