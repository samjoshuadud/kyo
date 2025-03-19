<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
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
        Label1 = New Label()
        Label2 = New Label()
        txtUsername = New TextBox()
        txtPassword = New TextBox()
        chkShowPassword = New CheckBox()
        BtnLogin = New Button()
        BtnExit = New Button()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(116, 129)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(130, 28)
        Label1.TabIndex = 0
        Label1.Text = "👥 Username:"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(116, 180)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(125, 28)
        Label2.TabIndex = 1
        Label2.Text = "🔒 Password:"
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtUsername.Location = New Point(254, 126)
        txtUsername.Margin = New Padding(2)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(184, 27)
        txtUsername.TabIndex = 2
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPassword.Location = New Point(254, 177)
        txtPassword.Margin = New Padding(2)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(184, 27)
        txtPassword.TabIndex = 3
        ' 
        ' chkShowPassword
        ' 
        chkShowPassword.AutoSize = True
        chkShowPassword.Font = New Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkShowPassword.Location = New Point(254, 225)
        chkShowPassword.Margin = New Padding(2)
        chkShowPassword.Name = "chkShowPassword"
        chkShowPassword.Size = New Size(122, 26)
        chkShowPassword.TabIndex = 4
        chkShowPassword.Text = "Show Password"
        chkShowPassword.UseVisualStyleBackColor = True
        ' 
        ' BtnLogin
        ' 
        BtnLogin.Font = New Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BtnLogin.Location = New Point(163, 270)
        BtnLogin.Margin = New Padding(2)
        BtnLogin.Name = "BtnLogin"
        BtnLogin.Size = New Size(106, 51)
        BtnLogin.TabIndex = 5
        BtnLogin.Text = "Login"
        BtnLogin.UseVisualStyleBackColor = True
        ' 
        ' BtnExit
        ' 
        BtnExit.Font = New Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BtnExit.Location = New Point(287, 270)
        BtnExit.Margin = New Padding(2)
        BtnExit.Name = "BtnExit"
        BtnExit.Size = New Size(106, 51)
        BtnExit.TabIndex = 6
        BtnExit.Text = "Exit"
        BtnExit.UseVisualStyleBackColor = True
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.Location = New Point(0, 0)
        FlowLayoutPanel1.Margin = New Padding(2)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(86, 422)
        FlowLayoutPanel1.TabIndex = 7
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(482, 371)
        Controls.Add(FlowLayoutPanel1)
        Controls.Add(BtnExit)
        Controls.Add(BtnLogin)
        Controls.Add(chkShowPassword)
        Controls.Add(txtPassword)
        Controls.Add(txtUsername)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(2)
        Name = "Login"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents chkShowPassword As CheckBox
    Friend WithEvents BtnLogin As Button
    Friend WithEvents BtnExit As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
End Class
