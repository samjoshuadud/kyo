<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogHistoryForm
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
        DGVloghistory = New DataGridView()
        LogID = New DataGridViewTextBoxColumn()
        role = New DataGridViewTextBoxColumn()
        FullName = New DataGridViewTextBoxColumn()
        Action = New DataGridViewTextBoxColumn()
        Column5 = New DataGridViewTextBoxColumn()
        CType(DGVloghistory, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DGVloghistory
        ' 
        DGVloghistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGVloghistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGVloghistory.Columns.AddRange(New DataGridViewColumn() {LogID, role, FullName, Action, Column5})
        DGVloghistory.Location = New Point(3, 77)
        DGVloghistory.Name = "DGVloghistory"
        DGVloghistory.RowHeadersWidth = 62
        DGVloghistory.Size = New Size(1398, 781)
        DGVloghistory.TabIndex = 0
        ' 
        ' LogID
        ' 
        LogID.DataPropertyName = "LogID"
        LogID.HeaderText = "id"
        LogID.MinimumWidth = 8
        LogID.Name = "LogID"
        LogID.Visible = False
        ' 
        ' role
        ' 
        role.DataPropertyName = "Role"
        role.HeaderText = "ROLE"
        role.MinimumWidth = 8
        role.Name = "role"
        ' 
        ' FullName
        ' 
        FullName.DataPropertyName = "FullName"
        FullName.HeaderText = "FULLNAME"
        FullName.MinimumWidth = 8
        FullName.Name = "FullName"
        ' 
        ' Action
        ' 
        Action.DataPropertyName = "Action"
        Action.HeaderText = "LOGIN & LOGOUT"
        Action.MinimumWidth = 8
        Action.Name = "Action"
        ' 
        ' Column5
        ' 
        Column5.DataPropertyName = "Date"
        Column5.HeaderText = "DATE & TIME"
        Column5.MinimumWidth = 8
        Column5.Name = "Column5"
        ' 
        ' LogHistoryForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1292, 820)
        Controls.Add(DGVloghistory)
        FormBorderStyle = FormBorderStyle.None
        Name = "LogHistoryForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "LogHistoryForm"
        CType(DGVloghistory, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DGVloghistory As DataGridView
    Friend WithEvents LogID As DataGridViewTextBoxColumn
    Friend WithEvents role As DataGridViewTextBoxColumn
    Friend WithEvents FullName As DataGridViewTextBoxColumn
    Friend WithEvents Action As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
End Class
