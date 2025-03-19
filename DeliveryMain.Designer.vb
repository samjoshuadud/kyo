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
        Me.components = New System.ComponentModel.Container()
        Me.lblTransactionTitle = New System.Windows.Forms.Label()
        Me.lblTransactionNumber = New System.Windows.Forms.Label()
        Me.lblSupplier = New System.Windows.Forms.Label()
        Me.cmbSupplier = New System.Windows.Forms.ComboBox()
        Me.lblDeliveryDate = New System.Windows.Forms.Label()
        Me.dtpDeliveryDate = New System.Windows.Forms.DateTimePicker()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()

        ' Form properties
        Me.Text = "Delivery Maintenance"
        Me.Width = 500
        Me.Height = 350
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.BackColor = System.Drawing.ColorTranslator.FromHtml("#B2DFEE")

        ' Transaction Number Label
        Me.lblTransactionTitle.Text = "Transaction Number:"
        Me.lblTransactionTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblTransactionTitle.Font = New System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)

        Me.lblTransactionNumber.Text = "Generating..."
        Me.lblTransactionNumber.Location = New System.Drawing.Point(180, 20)
        Me.lblTransactionNumber.Width = 280
        Me.lblTransactionNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTransactionNumber.Font = New System.Drawing.Font("Segoe UI", 10)

        ' Supplier Label and ComboBox
        Me.lblSupplier.Text = "Supplier:"
        Me.lblSupplier.Location = New System.Drawing.Point(20, 60)
        Me.lblSupplier.Font = New System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)

        Me.cmbSupplier.Location = New System.Drawing.Point(180, 60)
        Me.cmbSupplier.Width = 280
        Me.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

        ' Delivery Date Label and DateTimePicker
        Me.lblDeliveryDate.Text = "Delivery Date:"
        Me.lblDeliveryDate.Location = New System.Drawing.Point(20, 100)
        Me.lblDeliveryDate.Font = New System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)

        Me.dtpDeliveryDate.Location = New System.Drawing.Point(180, 100)
        Me.dtpDeliveryDate.Width = 280
        Me.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short

        ' Save Button
        Me.btnSave.Text = "Save"
        Me.btnSave.Location = New System.Drawing.Point(100, 200)
        Me.btnSave.Width = 120
        Me.btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#32CD32") ' Green color for Save
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ForeColor = System.Drawing.Color.White

        ' Close Button
        Me.btnClose.Text = "Close"
        Me.btnClose.Location = New System.Drawing.Point(260, 200)
        Me.btnClose.Width = 120
        Me.btnClose.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF4500") ' Orange color for Close
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.ForeColor = System.Drawing.Color.White

        ' Add controls to the form
        Me.Controls.Add(Me.lblTransactionTitle)
        Me.Controls.Add(Me.lblTransactionNumber)
        Me.Controls.Add(Me.lblSupplier)
        Me.Controls.Add(Me.cmbSupplier)
        Me.Controls.Add(Me.lblDeliveryDate)
        Me.Controls.Add(Me.dtpDeliveryDate)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
    End Sub
End Class
