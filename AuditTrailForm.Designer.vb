<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AuditTrailForm
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
        dgvAuditTrail = New DataGridView()
        AuditID = New DataGridViewTextBoxColumn()
        Role = New DataGridViewTextBoxColumn()
        FullName = New DataGridViewTextBoxColumn()
        Action = New DataGridViewTextBoxColumn()
        Form = New DataGridViewTextBoxColumn()
        dates = New DataGridViewTextBoxColumn()
        CType(dgvAuditTrail, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvAuditTrail
        ' 
        dgvAuditTrail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvAuditTrail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvAuditTrail.Columns.AddRange(New DataGridViewColumn() {AuditID, Role, FullName, Action, Form, dates})
        dgvAuditTrail.Location = New Point(1, 127)
        dgvAuditTrail.Name = "dgvAuditTrail"
        dgvAuditTrail.RowHeadersWidth = 62
        dgvAuditTrail.Size = New Size(1636, 626)
        dgvAuditTrail.TabIndex = 0
        ' 
        ' AuditID
        ' 
        AuditID.DataPropertyName = "AuditID"
        AuditID.HeaderText = "id"
        AuditID.MinimumWidth = 8
        AuditID.Name = "AuditID"
        AuditID.Visible = False
        ' 
        ' Role
        ' 
        Role.DataPropertyName = "Role"
        Role.HeaderText = "ROLE"
        Role.MinimumWidth = 8
        Role.Name = "Role"
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
        Action.HeaderText = "ACTION"
        Action.MinimumWidth = 8
        Action.Name = "Action"
        ' 
        ' Form
        ' 
        Form.DataPropertyName = "Form"
        Form.HeaderText = "FORM"
        Form.MinimumWidth = 8
        Form.Name = "Form"
        ' 
        ' dates
        ' 
        dates.DataPropertyName = "date"
        dates.HeaderText = "DATE"
        dates.MinimumWidth = 8
        dates.Name = "dates"
        ' 
        ' AuditTrailForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1297, 756)
        Controls.Add(dgvAuditTrail)
        FormBorderStyle = FormBorderStyle.None
        Name = "AuditTrailForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "AuditTrailForm"
        CType(dgvAuditTrail, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvAuditTrail As DataGridView
    Friend WithEvents AuditID As DataGridViewTextBoxColumn
    Friend WithEvents Role As DataGridViewTextBoxColumn
    Friend WithEvents FullName As DataGridViewTextBoxColumn
    Friend WithEvents Action As DataGridViewTextBoxColumn
    Friend WithEvents Form As DataGridViewTextBoxColumn
    Friend WithEvents dates As DataGridViewTextBoxColumn
End Class
