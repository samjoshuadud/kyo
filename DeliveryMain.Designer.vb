<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DeliveryMain
    Inherits System.Windows.Forms.Form

    ' Dispose method to clean up resources
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

    ' Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    ' Form controls
    Private lblTransactionTitle As System.Windows.Forms.Label
    Private lblTransactionNumber As System.Windows.Forms.Label
    Private lblSupplier As System.Windows.Forms.Label
    Private cmbSupplier As System.Windows.Forms.ComboBox
    Private lblDeliveryDate As System.Windows.Forms.Label
    Private dtpDeliveryDate As System.Windows.Forms.DateTimePicker
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private btnClose As System.Windows.Forms.Button

    ' Designer method for UI initialization
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblTransactionTitle = New Label()
        lblTransactionNumber = New Label()
        lblSupplier = New Label()
        cmbSupplier = New ComboBox()
        lblDeliveryDate = New Label()
        dtpDeliveryDate = New DateTimePicker()
        btnSave = New Button()
        btnClose = New Button()
        SuspendLayout()
        ' 
        ' lblTransactionTitle
        ' 
        lblTransactionTitle.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblTransactionTitle.Location = New Point(20, 20)
        lblTransactionTitle.Name = "lblTransactionTitle"
        lblTransactionTitle.Size = New Size(100, 23)
        lblTransactionTitle.TabIndex = 0
        lblTransactionTitle.Text = "Transaction Number:"
        ' 
        ' lblTransactionNumber
        ' 
        lblTransactionNumber.BorderStyle = BorderStyle.FixedSingle
        lblTransactionNumber.Font = New Font("Segoe UI", 10F)
        lblTransactionNumber.Location = New Point(180, 20)
        lblTransactionNumber.Name = "lblTransactionNumber"
        lblTransactionNumber.Size = New Size(280, 23)
        lblTransactionNumber.TabIndex = 1
        lblTransactionNumber.Text = "Generating..."
        ' 
        ' lblSupplier
        ' 
        lblSupplier.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblSupplier.Location = New Point(20, 60)
        lblSupplier.Name = "lblSupplier"
        lblSupplier.Size = New Size(100, 23)
        lblSupplier.TabIndex = 2
        lblSupplier.Text = "Supplier:"
        ' 
        ' cmbSupplier
        ' 
        cmbSupplier.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSupplier.Location = New Point(180, 60)
        cmbSupplier.Name = "cmbSupplier"
        cmbSupplier.Size = New Size(280, 23)
        cmbSupplier.TabIndex = 3
        ' 
        ' lblDeliveryDate
        ' 
        lblDeliveryDate.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblDeliveryDate.Location = New Point(20, 100)
        lblDeliveryDate.Name = "lblDeliveryDate"
        lblDeliveryDate.Size = New Size(100, 23)
        lblDeliveryDate.TabIndex = 4
        lblDeliveryDate.Text = "Delivery Date:"
        ' 
        ' dtpDeliveryDate
        ' 
        dtpDeliveryDate.Format = DateTimePickerFormat.Short
        dtpDeliveryDate.Location = New Point(180, 100)
        dtpDeliveryDate.Name = "dtpDeliveryDate"
        dtpDeliveryDate.Size = New Size(280, 23)
        dtpDeliveryDate.TabIndex = 5
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.DarkRed
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(104, 515)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(120, 39)
        btnSave.TabIndex = 6
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.DarkRed
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(274, 515)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(120, 39)
        btnClose.TabIndex = 7
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' DeliveryMain
        ' 
        BackColor = SystemColors.Control
        ClientSize = New Size(484, 584)
        Controls.Add(lblTransactionTitle)
        Controls.Add(lblTransactionNumber)
        Controls.Add(lblSupplier)
        Controls.Add(cmbSupplier)
        Controls.Add(lblDeliveryDate)
        Controls.Add(dtpDeliveryDate)
        Controls.Add(btnSave)
        Controls.Add(btnClose)
        Name = "DeliveryMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Delivery Maintenance"
        ResumeLayout(False)
    End Sub
End Class
