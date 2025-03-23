<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    'Required by the Windows Form Designer
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserMain))
        dgvUsers = New DataGridView()
        UserPanel = New Panel()
        btnUser = New Button()
        bntDelete = New Button()
        btnEdit = New Button()
        btnAdd = New Button()
        Panelimage = New Panel()
        Button4 = New Button()
        btnCapture = New Button()
        btnStopWebcam = New Button()
        picWebcam = New PictureBox()
        btnStartWebcam = New Button()
        Button1 = New Button()
        txtMI = New TextBox()
        txtAge = New TextBox()
        cmbGender = New ComboBox()
        txtUsername = New TextBox()
        txtEmail = New TextBox()
        txtPassword = New TextBox()
        txtConfirmPassword = New TextBox()
        cmbRole = New ComboBox()
        chkShowPassword = New CheckBox()
        lblEmail = New Label()
        lblRole = New Label()
        lblGender = New Label()
        lblConfirmPassword = New Label()
        txtAddress = New TextBox()
        lblUsername = New Label()
        txtFirstName = New TextBox()
        txtLastName = New TextBox()
        lblFirstName = New Label()
        lblLastName = New Label()
        lblMI = New Label()
        lblAge = New Label()
        lblAddress = New Label()
        lblPassword = New Label()
        Button7 = New Button()
        Button5 = New Button()
        btnViewRecords = New Button()
        txtSearch = New TextBox()
        Timer1 = New Timer(components)
        Label1 = New Label()
        MySqlCommand1 = New MySqlConnector.MySqlCommand()
        Button2 = New Button()
        CType(dgvUsers, ComponentModel.ISupportInitialize).BeginInit()
        UserPanel.SuspendLayout()
        Panelimage.SuspendLayout()
        CType(picWebcam, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvUsers
        ' 
        dgvUsers.ColumnHeadersHeight = 34
        dgvUsers.Location = New Point(7, 57)
        dgvUsers.Name = "dgvUsers"
        dgvUsers.RowHeadersWidth = 62
        dgvUsers.Size = New Size(1034, 369)
        dgvUsers.TabIndex = 27
        ' 
        ' UserPanel
        ' 
        UserPanel.BorderStyle = BorderStyle.Fixed3D
        UserPanel.Controls.Add(btnUser)
        UserPanel.Controls.Add(bntDelete)
        UserPanel.Controls.Add(btnEdit)
        UserPanel.Controls.Add(btnAdd)
        UserPanel.Controls.Add(Panelimage)
        UserPanel.Controls.Add(Button1)
        UserPanel.Controls.Add(txtMI)
        UserPanel.Controls.Add(txtAge)
        UserPanel.Controls.Add(cmbGender)
        UserPanel.Controls.Add(txtUsername)
        UserPanel.Controls.Add(txtEmail)
        UserPanel.Controls.Add(txtPassword)
        UserPanel.Controls.Add(txtConfirmPassword)
        UserPanel.Controls.Add(cmbRole)
        UserPanel.Controls.Add(chkShowPassword)
        UserPanel.Controls.Add(lblEmail)
        UserPanel.Controls.Add(lblRole)
        UserPanel.Controls.Add(lblGender)
        UserPanel.Controls.Add(lblConfirmPassword)
        UserPanel.Controls.Add(txtAddress)
        UserPanel.Controls.Add(lblUsername)
        UserPanel.Controls.Add(txtFirstName)
        UserPanel.Controls.Add(txtLastName)
        UserPanel.Controls.Add(lblFirstName)
        UserPanel.Controls.Add(lblLastName)
        UserPanel.Controls.Add(lblMI)
        UserPanel.Controls.Add(lblAge)
        UserPanel.Controls.Add(lblAddress)
        UserPanel.Controls.Add(lblPassword)
        UserPanel.Controls.Add(Button7)
        UserPanel.Controls.Add(Button5)
        UserPanel.Controls.Add(btnViewRecords)
        UserPanel.Location = New Point(55, 33)
        UserPanel.Name = "UserPanel"
        UserPanel.Size = New Size(905, 564)
        UserPanel.TabIndex = 5
        UserPanel.Visible = False
        ' 
        ' btnUser
        ' 
        btnUser.BackColor = Color.Transparent
        btnUser.FlatAppearance.BorderSize = 0
        btnUser.FlatStyle = FlatStyle.Flat
        btnUser.Image = CType(resources.GetObject("btnUser.Image"), Image)
        btnUser.Location = New Point(843, 3)
        btnUser.Name = "btnUser"
        btnUser.Size = New Size(62, 42)
        btnUser.TabIndex = 6
        btnUser.UseVisualStyleBackColor = False
        ' 
        ' bntDelete
        ' 
        bntDelete.BackColor = SystemColors.GrayText
        bntDelete.FlatStyle = FlatStyle.Flat
        bntDelete.ForeColor = SystemColors.ButtonHighlight
        bntDelete.Location = New Point(471, 495)
        bntDelete.Name = "bntDelete"
        bntDelete.Padding = New Padding(1, 0, 0, 0)
        bntDelete.Size = New Size(135, 47)
        bntDelete.TabIndex = 21
        bntDelete.Text = "DELETE"
        bntDelete.UseVisualStyleBackColor = False
        ' 
        ' btnEdit
        ' 
        btnEdit.BackColor = SystemColors.ActiveCaptionText
        btnEdit.FlatStyle = FlatStyle.Flat
        btnEdit.ForeColor = SystemColors.ButtonHighlight
        btnEdit.Location = New Point(330, 495)
        btnEdit.Name = "btnEdit"
        btnEdit.Padding = New Padding(1, 0, 0, 0)
        btnEdit.Size = New Size(135, 47)
        btnEdit.TabIndex = 20
        btnEdit.Text = "EDIT"
        btnEdit.UseVisualStyleBackColor = False
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = SystemColors.ActiveCaptionText
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.ForeColor = SystemColors.ButtonHighlight
        btnAdd.Location = New Point(189, 495)
        btnAdd.Name = "btnAdd"
        btnAdd.Padding = New Padding(1, 0, 0, 0)
        btnAdd.Size = New Size(135, 47)
        btnAdd.TabIndex = 19
        btnAdd.Text = "ADD"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' Panelimage
        ' 
        Panelimage.BorderStyle = BorderStyle.Fixed3D
        Panelimage.Controls.Add(Button4)
        Panelimage.Controls.Add(btnCapture)
        Panelimage.Controls.Add(btnStopWebcam)
        Panelimage.Controls.Add(picWebcam)
        Panelimage.Controls.Add(btnStartWebcam)
        Panelimage.ForeColor = SystemColors.ControlLightLight
        Panelimage.Location = New Point(164, 20)
        Panelimage.Name = "Panelimage"
        Panelimage.Size = New Size(620, 398)
        Panelimage.TabIndex = 61
        Panelimage.Visible = False
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.Transparent
        Button4.FlatAppearance.BorderSize = 0
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Image = CType(resources.GetObject("Button4.Image"), Image)
        Button4.Location = New Point(556, 3)
        Button4.Name = "Button4"
        Button4.Size = New Size(62, 42)
        Button4.TabIndex = 66
        Button4.UseVisualStyleBackColor = False
        ' 
        ' btnCapture
        ' 
        btnCapture.BackColor = SystemColors.GrayText
        btnCapture.FlatStyle = FlatStyle.Flat
        btnCapture.Location = New Point(399, 324)
        btnCapture.Name = "btnCapture"
        btnCapture.Padding = New Padding(1, 0, 0, 0)
        btnCapture.Size = New Size(165, 47)
        btnCapture.TabIndex = 61
        btnCapture.Text = "CAPTURE"
        btnCapture.UseVisualStyleBackColor = False
        ' 
        ' btnStopWebcam
        ' 
        btnStopWebcam.BackColor = SystemColors.ActiveCaptionText
        btnStopWebcam.FlatStyle = FlatStyle.Flat
        btnStopWebcam.Location = New Point(228, 324)
        btnStopWebcam.Name = "btnStopWebcam"
        btnStopWebcam.Padding = New Padding(1, 0, 0, 0)
        btnStopWebcam.Size = New Size(165, 47)
        btnStopWebcam.TabIndex = 60
        btnStopWebcam.Text = "STOP WEBCAM"
        btnStopWebcam.UseVisualStyleBackColor = False
        ' 
        ' picWebcam
        ' 
        picWebcam.Location = New Point(57, 61)
        picWebcam.Name = "picWebcam"
        picWebcam.Size = New Size(502, 241)
        picWebcam.TabIndex = 57
        picWebcam.TabStop = False
        ' 
        ' btnStartWebcam
        ' 
        btnStartWebcam.BackColor = SystemColors.ActiveCaptionText
        btnStartWebcam.FlatStyle = FlatStyle.Flat
        btnStartWebcam.Location = New Point(57, 324)
        btnStartWebcam.Name = "btnStartWebcam"
        btnStartWebcam.Padding = New Padding(1, 0, 0, 0)
        btnStartWebcam.Size = New Size(165, 47)
        btnStartWebcam.TabIndex = 58
        btnStartWebcam.Text = "START WEBCAM"
        btnStartWebcam.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(1047, 13)
        Button1.Name = "Button1"
        Button1.Size = New Size(53, 32)
        Button1.TabIndex = 54
        Button1.Text = "❌"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' txtMI
        ' 
        txtMI.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtMI.Location = New Point(189, 102)
        txtMI.Name = "txtMI"
        txtMI.Size = New Size(527, 23)
        txtMI.TabIndex = 9
        ' 
        ' txtAge
        ' 
        txtAge.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtAge.Location = New Point(189, 139)
        txtAge.Name = "txtAge"
        txtAge.Size = New Size(527, 23)
        txtAge.TabIndex = 10
        ' 
        ' cmbGender
        ' 
        cmbGender.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbGender.Items.AddRange(New Object() {"Male ", "Female"})
        cmbGender.Location = New Point(189, 176)
        cmbGender.Name = "cmbGender"
        cmbGender.Size = New Size(527, 23)
        cmbGender.TabIndex = 11
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtUsername.Location = New Point(189, 340)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(527, 23)
        txtUsername.TabIndex = 15
        ' 
        ' txtEmail
        ' 
        txtEmail.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtEmail.Location = New Point(189, 303)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(527, 23)
        txtEmail.TabIndex = 14
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPassword.Location = New Point(189, 374)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(527, 23)
        txtPassword.TabIndex = 16
        ' 
        ' txtConfirmPassword
        ' 
        txtConfirmPassword.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtConfirmPassword.Location = New Point(189, 411)
        txtConfirmPassword.Name = "txtConfirmPassword"
        txtConfirmPassword.Size = New Size(527, 23)
        txtConfirmPassword.TabIndex = 17
        ' 
        ' cmbRole
        ' 
        cmbRole.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbRole.Items.AddRange(New Object() {"Cashier" & vbTab, "Staff"})
        cmbRole.Location = New Point(189, 217)
        cmbRole.Name = "cmbRole"
        cmbRole.Size = New Size(527, 23)
        cmbRole.TabIndex = 12
        ' 
        ' chkShowPassword
        ' 
        chkShowPassword.BackColor = Color.Transparent
        chkShowPassword.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        chkShowPassword.Location = New Point(189, 448)
        chkShowPassword.Name = "chkShowPassword"
        chkShowPassword.Size = New Size(177, 24)
        chkShowPassword.TabIndex = 18
        chkShowPassword.Text = "Show Password:"
        chkShowPassword.UseVisualStyleBackColor = False
        ' 
        ' lblEmail
        ' 
        lblEmail.Font = New Font("Segoe UI", 8F, FontStyle.Bold)
        lblEmail.Location = New Point(75, 300)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(83, 38)
        lblEmail.TabIndex = 39
        lblEmail.Text = "EMAIL :"
        ' 
        ' lblRole
        ' 
        lblRole.Font = New Font("Segoe UI", 8F, FontStyle.Bold)
        lblRole.Location = New Point(75, 217)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(107, 33)
        lblRole.TabIndex = 47
        lblRole.Text = "ROLE :"
        ' 
        ' lblGender
        ' 
        lblGender.Font = New Font("Segoe UI", 8F, FontStyle.Bold)
        lblGender.Location = New Point(75, 176)
        lblGender.Name = "lblGender"
        lblGender.Size = New Size(117, 38)
        lblGender.TabIndex = 27
        lblGender.Text = "GENDER : "
        ' 
        ' lblConfirmPassword
        ' 
        lblConfirmPassword.Font = New Font("Segoe UI", 8F, FontStyle.Bold)
        lblConfirmPassword.Location = New Point(76, 411)
        lblConfirmPassword.Name = "lblConfirmPassword"
        lblConfirmPassword.Size = New Size(107, 43)
        lblConfirmPassword.TabIndex = 43
        lblConfirmPassword.Text = "CONFIRM PASSWORD :"
        ' 
        ' txtAddress
        ' 
        txtAddress.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtAddress.Location = New Point(189, 256)
        txtAddress.Multiline = True
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(527, 41)
        txtAddress.TabIndex = 13
        ' 
        ' lblUsername
        ' 
        lblUsername.Font = New Font("Segoe UI", 8F, FontStyle.Bold)
        lblUsername.Location = New Point(75, 340)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(118, 36)
        lblUsername.TabIndex = 37
        lblUsername.Text = "USER NAME :"
        ' 
        ' txtFirstName
        ' 
        txtFirstName.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtFirstName.Location = New Point(189, 29)
        txtFirstName.Name = "txtFirstName"
        txtFirstName.Size = New Size(527, 23)
        txtFirstName.TabIndex = 7
        ' 
        ' txtLastName
        ' 
        txtLastName.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtLastName.Location = New Point(189, 65)
        txtLastName.Name = "txtLastName"
        txtLastName.Size = New Size(527, 23)
        txtLastName.TabIndex = 8
        ' 
        ' lblFirstName
        ' 
        lblFirstName.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblFirstName.Location = New Point(76, 29)
        lblFirstName.Name = "lblFirstName"
        lblFirstName.Size = New Size(113, 33)
        lblFirstName.TabIndex = 23
        lblFirstName.Text = "FIRST NAME :"
        ' 
        ' lblLastName
        ' 
        lblLastName.Font = New Font("Segoe UI", 8F, FontStyle.Bold)
        lblLastName.Location = New Point(76, 65)
        lblLastName.Name = "lblLastName"
        lblLastName.Size = New Size(107, 37)
        lblLastName.TabIndex = 24
        lblLastName.Text = "LAST NAME :"
        ' 
        ' lblMI
        ' 
        lblMI.Font = New Font("Segoe UI", 8F, FontStyle.Bold)
        lblMI.Location = New Point(75, 102)
        lblMI.Name = "lblMI"
        lblMI.Size = New Size(59, 36)
        lblMI.TabIndex = 25
        lblMI.Text = "M.I :"
        ' 
        ' lblAge
        ' 
        lblAge.Font = New Font("Segoe UI", 8F, FontStyle.Bold)
        lblAge.Location = New Point(76, 139)
        lblAge.Name = "lblAge"
        lblAge.Size = New Size(61, 33)
        lblAge.TabIndex = 26
        lblAge.Text = "AGE :"
        ' 
        ' lblAddress
        ' 
        lblAddress.Font = New Font("Segoe UI", 8F, FontStyle.Bold)
        lblAddress.Location = New Point(76, 253)
        lblAddress.Name = "lblAddress"
        lblAddress.Size = New Size(113, 41)
        lblAddress.TabIndex = 45
        lblAddress.Text = "ADDRESS :"
        ' 
        ' lblPassword
        ' 
        lblPassword.Font = New Font("Segoe UI", 8F, FontStyle.Bold)
        lblPassword.Location = New Point(76, 374)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(117, 37)
        lblPassword.TabIndex = 41
        lblPassword.Text = "PASSWORD :"
        ' 
        ' Button7
        ' 
        Button7.BackColor = SystemColors.ActiveCaptionText
        Button7.FlatStyle = FlatStyle.Flat
        Button7.Font = New Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button7.ForeColor = SystemColors.ButtonHighlight
        Button7.Location = New Point(722, 29)
        Button7.Name = "Button7"
        Button7.Padding = New Padding(1, 0, 0, 0)
        Button7.Size = New Size(111, 33)
        Button7.TabIndex = 22
        Button7.Text = "ADD IMAGE"
        Button7.UseVisualStyleBackColor = False
        ' 
        ' Button5
        ' 
        Button5.BackColor = SystemColors.ActiveCaptionText
        Button5.FlatStyle = FlatStyle.Flat
        Button5.Font = New Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button5.ForeColor = SystemColors.ButtonHighlight
        Button5.Location = New Point(722, 65)
        Button5.Name = "Button5"
        Button5.Padding = New Padding(1, 0, 0, 0)
        Button5.Size = New Size(111, 33)
        Button5.TabIndex = 62
        Button5.Text = "VIEW IMAGE"
        Button5.UseVisualStyleBackColor = False
        ' 
        ' btnViewRecords
        ' 
        btnViewRecords.BackColor = SystemColors.ActiveCaptionText
        btnViewRecords.FlatStyle = FlatStyle.Flat
        btnViewRecords.Font = New Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnViewRecords.ForeColor = SystemColors.ButtonHighlight
        btnViewRecords.Location = New Point(722, 102)
        btnViewRecords.Name = "btnViewRecords"
        btnViewRecords.Padding = New Padding(1, 0, 0, 0)
        btnViewRecords.Size = New Size(111, 33)
        btnViewRecords.TabIndex = 63
        btnViewRecords.Text = "VIEW RECORD"
        btnViewRecords.UseVisualStyleBackColor = False
        ' 
        ' txtSearch
        ' 
        txtSearch.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearch.Location = New Point(635, 12)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(285, 29)
        txtSearch.TabIndex = 2
        ' 
        ' Timer1
        ' 
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(2, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(107, 25)
        Label1.TabIndex = 1
        Label1.Text = "USER LIST "
        ' 
        ' MySqlCommand1
        ' 
        MySqlCommand1.CommandTimeout = 0
        MySqlCommand1.Connection = Nothing
        MySqlCommand1.Transaction = Nothing
        MySqlCommand1.UpdatedRowSource = UpdateRowSource.None
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.Transparent
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Image = CType(resources.GetObject("Button2.Image"), Image)
        Button2.Location = New Point(968, 6)
        Button2.Name = "Button2"
        Button2.Size = New Size(62, 42)
        Button2.TabIndex = 4
        Button2.UseVisualStyleBackColor = False
        ' 
        ' UserMain
        ' 
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1030, 597)
        Controls.Add(Button2)
        Controls.Add(UserPanel)
        Controls.Add(Label1)
        Controls.Add(dgvUsers)
        Controls.Add(txtSearch)
        FormBorderStyle = FormBorderStyle.None
        Name = "UserMain"
        StartPosition = FormStartPosition.CenterScreen
        CType(dgvUsers, ComponentModel.ISupportInitialize).EndInit()
        UserPanel.ResumeLayout(False)
        UserPanel.PerformLayout()
        Panelimage.ResumeLayout(False)
        CType(picWebcam, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    ' Declare Controls
    Friend WithEvents dgvUsers As DataGridView
    Friend WithEvents UserPanel As Panel
    Friend WithEvents lblFirstName As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents lblMI As Label
    Friend WithEvents txtMI As TextBox
    Friend WithEvents lblLastName As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents lblAge As Label
    Friend WithEvents txtAge As TextBox
    Friend WithEvents cmbGender As ComboBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblConfirmPassword As Label
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents cmbRole As ComboBox
    Friend WithEvents chkShowPassword As CheckBox
    Friend WithEvents lblAddress As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblRole As Label
    Friend WithEvents lblGender As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents picWebcam As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents btnStartWebcam As Button
    Friend WithEvents Panelimage As Panel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnCapture As Button
    Friend WithEvents btnStopWebcam As Button
    Friend WithEvents bntDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents MySqlCommand1 As MySqlConnector.MySqlCommand
    Friend WithEvents btnUser As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents btnViewRecords As Button
    Friend WithEvents Button4 As Button
End Class
