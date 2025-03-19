<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class POS
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

    ' Windows Form Designer generated code
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POS))
        Panel2 = New Panel()
        Label8 = New Label()
        Label1 = New Label()
        lblVAT = New Label()
        lblSubtotal = New Label()
        txtBarcode = New TextBox()
        Label9 = New Label()
        pnlCashierItemScan = New Panel()
        lblDate = New Label()
        lblDiscount = New Label()
        Label5 = New Label()
        lblTotal = New Label()
        lbldateandtime = New Label()
        Label7 = New Label()
        lblTransactionNumber = New Label()
        PanelQuantity = New Panel()
        Panel5 = New Panel()
        Button6 = New Button()
        Label4 = New Label()
        txtQuantity = New TextBox()
        DiscountPanel = New Panel()
        Panel3 = New Panel()
        Panel4 = New Panel()
        Button5 = New Button()
        Button2 = New Button()
        Label3 = New Label()
        cmbDiscount = New ComboBox()
        Button1 = New Button()
        btnProcessPayment = New Button()
        btnClearcart = New Button()
        dgvCart = New DataGridView()
        Panel1 = New Panel()
        Label11 = New Label()
        Label10 = New Label()
        lblChange = New Label()
        Label6 = New Label()
        lblTotalItems = New Label()
        lblCashier = New Label()
        PanelPay = New Panel()
        Panel6 = New Panel()
        Button4 = New Button()
        Label2 = New Label()
        txtAmountPaid = New TextBox()
        Button3 = New Button()
        Panel2.SuspendLayout()
        pnlCashierItemScan.SuspendLayout()
        PanelQuantity.SuspendLayout()
        Panel5.SuspendLayout()
        DiscountPanel.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        CType(dgvCart, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        PanelPay.SuspendLayout()
        Panel6.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Transparent
        Panel2.BorderStyle = BorderStyle.Fixed3D
        Panel2.Controls.Add(Label8)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(lblVAT)
        Panel2.Controls.Add(lblSubtotal)
        Panel2.Controls.Add(txtBarcode)
        Panel2.Controls.Add(Label9)
        Panel2.Controls.Add(pnlCashierItemScan)
        Panel2.Controls.Add(lblDiscount)
        Panel2.Controls.Add(Label5)
        Panel2.Controls.Add(lblTotal)
        Panel2.Controls.Add(lbldateandtime)
        Panel2.Controls.Add(Label7)
        Panel2.Controls.Add(lblTransactionNumber)
        Panel2.Font = New Font("Segoe UI Black", 24F, FontStyle.Bold)
        Panel2.Location = New Point(-21, 22)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1298, 132)
        Panel2.TabIndex = 16
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label8.Location = New Point(794, 17)
        Label8.Name = "Label8"
        Label8.Size = New Size(143, 32)
        Label8.TabIndex = 18
        Label8.Text = "DISCOUNT "
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label1.Location = New Point(21, 54)
        Label1.Name = "Label1"
        Label1.Size = New Size(140, 32)
        Label1.TabIndex = 6
        Label1.Text = "BARCODE :"
        ' 
        ' lblVAT
        ' 
        lblVAT.AutoSize = True
        lblVAT.BackColor = Color.Transparent
        lblVAT.Font = New Font("Segoe UI Black", 24F, FontStyle.Bold)
        lblVAT.Location = New Point(648, 43)
        lblVAT.Name = "lblVAT"
        lblVAT.Size = New Size(57, 65)
        lblVAT.TabIndex = 2
        lblVAT.Text = "0"
        ' 
        ' lblSubtotal
        ' 
        lblSubtotal.AutoSize = True
        lblSubtotal.BackColor = Color.Transparent
        lblSubtotal.Font = New Font("Segoe UI Black", 24F, FontStyle.Bold)
        lblSubtotal.Location = New Point(944, 43)
        lblSubtotal.Name = "lblSubtotal"
        lblSubtotal.Size = New Size(57, 65)
        lblSubtotal.TabIndex = 1
        lblSubtotal.Text = "0"
        ' 
        ' txtBarcode
        ' 
        txtBarcode.Font = New Font("Arial", 16F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtBarcode.Location = New Point(131, 51)
        txtBarcode.Multiline = True
        txtBarcode.Name = "txtBarcode"
        txtBarcode.Size = New Size(438, 31)
        txtBarcode.TabIndex = 4
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label9.Location = New Point(943, 17)
        Label9.Name = "Label9"
        Label9.Size = New Size(129, 32)
        Label9.TabIndex = 19
        Label9.Text = "SUBTOTAL"
        ' 
        ' pnlCashierItemScan
        ' 
        pnlCashierItemScan.BackColor = Color.White
        pnlCashierItemScan.BorderStyle = BorderStyle.FixedSingle
        pnlCashierItemScan.Controls.Add(lblDate)
        pnlCashierItemScan.Location = New Point(292, 13)
        pnlCashierItemScan.Name = "pnlCashierItemScan"
        pnlCashierItemScan.Size = New Size(41, 24)
        pnlCashierItemScan.TabIndex = 0
        pnlCashierItemScan.Visible = False
        ' 
        ' lblDate
        ' 
        lblDate.AutoSize = True
        lblDate.Font = New Font("Arial", 12F)
        lblDate.ForeColor = Color.FromArgb(CByte(13), CByte(71), CByte(161))
        lblDate.Location = New Point(628, 3)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(312, 27)
        lblDate.TabIndex = 1
        lblDate.Text = "Date: YYYY-MM-DD HH:MM"
        ' 
        ' lblDiscount
        ' 
        lblDiscount.AutoSize = True
        lblDiscount.BackColor = Color.Transparent
        lblDiscount.Font = New Font("Segoe UI Black", 24F, FontStyle.Bold)
        lblDiscount.Location = New Point(794, 42)
        lblDiscount.Name = "lblDiscount"
        lblDiscount.Size = New Size(57, 65)
        lblDiscount.TabIndex = 3
        lblDiscount.Text = "0"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label5.Location = New Point(1105, 17)
        Label5.Name = "Label5"
        Label5.Size = New Size(85, 32)
        Label5.TabIndex = 15
        Label5.Text = "TOTAL"
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Font = New Font("Segoe UI Black", 24F, FontStyle.Bold)
        lblTotal.Location = New Point(1105, 42)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(179, 65)
        lblTotal.TabIndex = 4
        lblTotal.Text = "Total: "
        ' 
        ' lbldateandtime
        ' 
        lbldateandtime.AutoSize = True
        lbldateandtime.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lbldateandtime.ForeColor = Color.Black
        lbldateandtime.Location = New Point(21, 90)
        lbldateandtime.Name = "lbldateandtime"
        lbldateandtime.Size = New Size(81, 32)
        lbldateandtime.TabIndex = 8
        lbldateandtime.Text = "DATE "
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label7.Location = New Point(648, 17)
        Label7.Name = "Label7"
        Label7.Size = New Size(65, 32)
        Label7.TabIndex = 17
        Label7.Text = "VAT "
        ' 
        ' lblTransactionNumber
        ' 
        lblTransactionNumber.AutoSize = True
        lblTransactionNumber.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblTransactionNumber.ForeColor = Color.Red
        lblTransactionNumber.Location = New Point(19, 13)
        lblTransactionNumber.Name = "lblTransactionNumber"
        lblTransactionNumber.Size = New Size(219, 32)
        lblTransactionNumber.TabIndex = 0
        lblTransactionNumber.Text = "TRANSACTION #: "
        ' 
        ' PanelQuantity
        ' 
        PanelQuantity.Controls.Add(Panel5)
        PanelQuantity.Controls.Add(Label4)
        PanelQuantity.Controls.Add(txtQuantity)
        PanelQuantity.Location = New Point(251, 160)
        PanelQuantity.Name = "PanelQuantity"
        PanelQuantity.Size = New Size(518, 286)
        PanelQuantity.TabIndex = 14
        PanelQuantity.Visible = False
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.Transparent
        Panel5.Controls.Add(Button6)
        Panel5.Dock = DockStyle.Top
        Panel5.Location = New Point(0, 0)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(518, 52)
        Panel5.TabIndex = 69
        ' 
        ' Button6
        ' 
        Button6.BackColor = Color.Transparent
        Button6.FlatAppearance.BorderSize = 0
        Button6.FlatStyle = FlatStyle.Flat
        Button6.Image = CType(resources.GetObject("Button6.Image"), Image)
        Button6.Location = New Point(453, 4)
        Button6.Name = "Button6"
        Button6.Size = New Size(62, 42)
        Button6.TabIndex = 67
        Button6.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(20, 95)
        Label4.Name = "Label4"
        Label4.Size = New Size(186, 43)
        Label4.TabIndex = 11
        Label4.Text = "Quantity :"
        ' 
        ' txtQuantity
        ' 
        txtQuantity.BackColor = SystemColors.GradientActiveCaption
        txtQuantity.Font = New Font("Arial", 28F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtQuantity.Location = New Point(3, 149)
        txtQuantity.Multiline = True
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(512, 94)
        txtQuantity.TabIndex = 9
        txtQuantity.TextAlign = HorizontalAlignment.Center
        ' 
        ' DiscountPanel
        ' 
        DiscountPanel.BackColor = Color.Transparent
        DiscountPanel.Controls.Add(Panel3)
        DiscountPanel.Controls.Add(Label3)
        DiscountPanel.Controls.Add(cmbDiscount)
        DiscountPanel.Location = New Point(241, 163)
        DiscountPanel.Name = "DiscountPanel"
        DiscountPanel.Size = New Size(559, 279)
        DiscountPanel.TabIndex = 13
        DiscountPanel.Visible = False
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.Transparent
        Panel3.Controls.Add(Panel4)
        Panel3.Controls.Add(Button2)
        Panel3.Dock = DockStyle.Top
        Panel3.Location = New Point(0, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(559, 46)
        Panel3.TabIndex = 13
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.Transparent
        Panel4.Controls.Add(Button5)
        Panel4.Dock = DockStyle.Top
        Panel4.Location = New Point(0, 0)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(559, 46)
        Panel4.TabIndex = 68
        ' 
        ' Button5
        ' 
        Button5.BackColor = Color.Transparent
        Button5.FlatAppearance.BorderSize = 0
        Button5.FlatStyle = FlatStyle.Flat
        Button5.Image = CType(resources.GetObject("Button5.Image"), Image)
        Button5.Location = New Point(494, 1)
        Button5.Name = "Button5"
        Button5.Size = New Size(62, 42)
        Button5.TabIndex = 67
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.Transparent
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Image = CType(resources.GetObject("Button2.Image"), Image)
        Button2.Location = New Point(475, 0)
        Button2.Name = "Button2"
        Button2.Size = New Size(62, 42)
        Button2.TabIndex = 67
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(42, 84)
        Label3.Name = "Label3"
        Label3.Size = New Size(299, 48)
        Label3.TabIndex = 12
        Label3.Text = "Select Discount :"
        ' 
        ' cmbDiscount
        ' 
        cmbDiscount.Font = New Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbDiscount.FormattingEnabled = True
        cmbDiscount.Location = New Point(42, 135)
        cmbDiscount.Name = "cmbDiscount"
        cmbDiscount.Size = New Size(445, 56)
        cmbDiscount.TabIndex = 10
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(851, 522)
        Button1.Name = "Button1"
        Button1.Size = New Size(163, 54)
        Button1.TabIndex = 12
        Button1.Text = "🏷️ Discount"
        ' 
        ' btnProcessPayment
        ' 
        btnProcessPayment.Location = New Point(252, 208)
        btnProcessPayment.Name = "btnProcessPayment"
        btnProcessPayment.Size = New Size(192, 59)
        btnProcessPayment.TabIndex = 3
        btnProcessPayment.Text = "Process Payment"
        ' 
        ' btnClearcart
        ' 
        btnClearcart.Location = New Point(851, 574)
        btnClearcart.Name = "btnClearcart"
        btnClearcart.Size = New Size(163, 54)
        btnClearcart.TabIndex = 4
        btnClearcart.Text = "Clear Cart"
        ' 
        ' dgvCart
        ' 
        dgvCart.AllowUserToAddRows = False
        dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCart.ColumnHeadersHeight = 34
        dgvCart.EnableHeadersVisualStyles = False
        dgvCart.GridColor = SystemColors.GrayText
        dgvCart.Location = New Point(2, 153)
        dgvCart.Name = "dgvCart"
        dgvCart.ReadOnly = True
        dgvCart.RowHeadersWidth = 62
        dgvCart.Size = New Size(1246, 361)
        dgvCart.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Transparent
        Panel1.BorderStyle = BorderStyle.Fixed3D
        Panel1.Controls.Add(Label11)
        Panel1.Controls.Add(Label10)
        Panel1.Controls.Add(lblChange)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(lblTotalItems)
        Panel1.Controls.Add(lblCashier)
        Panel1.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Panel1.Location = New Point(2, 515)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(837, 104)
        Panel1.TabIndex = 11
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(352, 10)
        Label11.Name = "Label11"
        Label11.Size = New Size(157, 32)
        Label11.TabIndex = 21
        Label11.Text = "TOTAL ITEM "
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(570, 10)
        Label10.Name = "Label10"
        Label10.Size = New Size(120, 32)
        Label10.TabIndex = 20
        Label10.Text = "CHANGE "
        ' 
        ' lblChange
        ' 
        lblChange.AutoSize = True
        lblChange.Font = New Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblChange.Location = New Point(572, 32)
        lblChange.Name = "lblChange"
        lblChange.Size = New Size(57, 65)
        lblChange.TabIndex = 5
        lblChange.Text = "0"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label6.Location = New Point(8, 13)
        Label6.Name = "Label6"
        Label6.Size = New Size(73, 32)
        Label6.TabIndex = 16
        Label6.Text = "USER"
        ' 
        ' lblTotalItems
        ' 
        lblTotalItems.AutoSize = True
        lblTotalItems.Font = New Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalItems.ForeColor = Color.Black
        lblTotalItems.Location = New Point(358, 32)
        lblTotalItems.Name = "lblTotalItems"
        lblTotalItems.Size = New Size(57, 65)
        lblTotalItems.TabIndex = 5
        lblTotalItems.Text = "0"
        ' 
        ' lblCashier
        ' 
        lblCashier.AutoSize = True
        lblCashier.Font = New Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCashier.ForeColor = Color.Black
        lblCashier.Location = New Point(8, 42)
        lblCashier.Name = "lblCashier"
        lblCashier.Size = New Size(148, 45)
        lblCashier.TabIndex = 2
        lblCashier.Text = "Cashier: "
        ' 
        ' PanelPay
        ' 
        PanelPay.BorderStyle = BorderStyle.Fixed3D
        PanelPay.Controls.Add(Panel6)
        PanelPay.Controls.Add(Label2)
        PanelPay.Controls.Add(txtAmountPaid)
        PanelPay.Controls.Add(btnProcessPayment)
        PanelPay.Location = New Point(320, 160)
        PanelPay.Name = "PanelPay"
        PanelPay.Size = New Size(517, 279)
        PanelPay.TabIndex = 16
        PanelPay.Visible = False
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = Color.Transparent
        Panel6.Controls.Add(Button4)
        Panel6.Dock = DockStyle.Top
        Panel6.Location = New Point(0, 0)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(513, 46)
        Panel6.TabIndex = 8
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.Transparent
        Button4.FlatAppearance.BorderSize = 0
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Image = CType(resources.GetObject("Button4.Image"), Image)
        Button4.Location = New Point(453, 1)
        Button4.Name = "Button4"
        Button4.Size = New Size(62, 42)
        Button4.TabIndex = 67
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(40, 79)
        Label2.Name = "Label2"
        Label2.Size = New Size(294, 48)
        Label2.TabIndex = 7
        Label2.Text = "AMOUNT PAID :"
        ' 
        ' txtAmountPaid
        ' 
        txtAmountPaid.BackColor = SystemColors.InactiveBorder
        txtAmountPaid.Font = New Font("Arial", 28F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtAmountPaid.Location = New Point(40, 130)
        txtAmountPaid.Name = "txtAmountPaid"
        txtAmountPaid.Size = New Size(404, 72)
        txtAmountPaid.TabIndex = 2
        txtAmountPaid.TextAlign = HorizontalAlignment.Center
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(1014, 524)
        Button3.Name = "Button3"
        Button3.Size = New Size(234, 95)
        Button3.TabIndex = 17
        Button3.Text = "PAY"
        ' 
        ' POS
        ' 
        BackColor = Color.White
        ClientSize = New Size(1260, 626)
        Controls.Add(PanelQuantity)
        Controls.Add(DiscountPanel)
        Controls.Add(Button3)
        Controls.Add(PanelPay)
        Controls.Add(btnClearcart)
        Controls.Add(Button1)
        Controls.Add(Panel1)
        Controls.Add(Panel2)
        Controls.Add(dgvCart)
        FormBorderStyle = FormBorderStyle.None
        Name = "POS"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Point of Sale"
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        pnlCashierItemScan.ResumeLayout(False)
        pnlCashierItemScan.PerformLayout()
        PanelQuantity.ResumeLayout(False)
        PanelQuantity.PerformLayout()
        Panel5.ResumeLayout(False)
        DiscountPanel.ResumeLayout(False)
        DiscountPanel.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        CType(dgvCart, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        PanelPay.ResumeLayout(False)
        PanelPay.PerformLayout()
        Panel6.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents PanelQuantity As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents txtQuantity As TextBox
    Private WithEvents Label1 As Label
    Friend WithEvents DiscountPanel As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbDiscount As ComboBox
    Private WithEvents lblVAT As Label
    Private WithEvents lblTransactionNumber As Label
    Private WithEvents txtBarcode As TextBox
    Private WithEvents pnlCashierItemScan As Panel
    Private WithEvents lblDate As Label
    Private WithEvents lblDiscount As Label
    Private WithEvents Label8 As Label
    Private WithEvents Label5 As Label
    Private WithEvents lblTotal As Label
    Private WithEvents lbldateandtime As Label
    Private WithEvents Label7 As Label
    Private WithEvents Button1 As Button
    Private WithEvents btnProcessPayment As Button
    Private WithEvents btnClearcart As Button
    Private WithEvents dgvCart As DataGridView
    Friend WithEvents Panel1 As Panel
    Private WithEvents Label10 As Label
    Private WithEvents lblChange As Label
    Private WithEvents Label6 As Label
    Private WithEvents lblTotalItems As Label
    Private WithEvents lblCashier As Label
    Private WithEvents lblSubtotal As Label
    Private WithEvents Label9 As Label
    Friend WithEvents PanelPay As Panel
    Friend WithEvents Panel6 As Panel
    Private WithEvents Label2 As Label
    Private WithEvents txtAmountPaid As TextBox
    Friend WithEvents Button4 As Button
    Private WithEvents Button3 As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Button2 As Button
    Private WithEvents Label11 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Button6 As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Button5 As Button




End Class

