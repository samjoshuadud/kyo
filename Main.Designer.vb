<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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



    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        ContextMenuStrip1 = New ContextMenuStrip(components)
        UserMaintenanceToolStripMenuItem = New ToolStripMenuItem()
        ProductMaintenanceToolStripMenuItem = New ToolStripMenuItem()
        DeliveryMaintenanceToolStripMenuItem = New ToolStripMenuItem()
        DiscountMaintenaceToolStripMenuItem = New ToolStripMenuItem()
        ExpirationMaintenanceToolStripMenuItem = New ToolStripMenuItem()
        CategoryMaintenanceToolStripMenuItem = New ToolStripMenuItem()
        InventoryMaintenanceToolStripMenuItem1 = New ToolStripMenuItem()
        SupplierToolStripMenuItem = New ToolStripMenuItem()
        ContextMenuStrip2 = New ContextMenuStrip(components)
        SalesReportsToolStripMenuItem = New ToolStripMenuItem()
        InventoryReportsToolStripMenuItem = New ToolStripMenuItem()
        ContextMenuStrip3 = New ContextMenuStrip(components)
        LogHistoryToolStripMenuItem = New ToolStripMenuItem()
        AuditTrailToolStripMenuItem = New ToolStripMenuItem()
        CentralPanel = New Panel()
        MainPanel = New Panel()
        PanelMaintenance = New Panel()
        PanelButtons = New Panel()
        btnLogout = New Button()
        btnSettings = New Button()
        btnFileMaintenance = New Button()
        btnReports = New Button()
        ContextMenuStrip1.SuspendLayout()
        ContextMenuStrip2.SuspendLayout()
        ContextMenuStrip3.SuspendLayout()
        PanelMaintenance.SuspendLayout()
        PanelButtons.SuspendLayout()
        SuspendLayout()
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.ImageScalingSize = New Size(24, 24)
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {UserMaintenanceToolStripMenuItem, ProductMaintenanceToolStripMenuItem, DeliveryMaintenanceToolStripMenuItem, DiscountMaintenaceToolStripMenuItem, ExpirationMaintenanceToolStripMenuItem, CategoryMaintenanceToolStripMenuItem, InventoryMaintenanceToolStripMenuItem1, SupplierToolStripMenuItem})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(240, 212)
        ' 
        ' UserMaintenanceToolStripMenuItem
        ' 
        UserMaintenanceToolStripMenuItem.Font = New Font("Poppins", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        UserMaintenanceToolStripMenuItem.Name = "UserMaintenanceToolStripMenuItem"
        UserMaintenanceToolStripMenuItem.Size = New Size(239, 26)
        UserMaintenanceToolStripMenuItem.Text = "User Maintenance"
        ' 
        ' ProductMaintenanceToolStripMenuItem
        ' 
        ProductMaintenanceToolStripMenuItem.Font = New Font("PoppinsI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ProductMaintenanceToolStripMenuItem.Name = "ProductMaintenanceToolStripMenuItem"
        ProductMaintenanceToolStripMenuItem.Size = New Size(239, 26)
        ProductMaintenanceToolStripMenuItem.Text = "Product Miantenance"
        ' 
        ' DeliveryMaintenanceToolStripMenuItem
        ' 
        DeliveryMaintenanceToolStripMenuItem.Font = New Font("Poppins", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DeliveryMaintenanceToolStripMenuItem.Name = "DeliveryMaintenanceToolStripMenuItem"
        DeliveryMaintenanceToolStripMenuItem.Size = New Size(239, 26)
        DeliveryMaintenanceToolStripMenuItem.Text = "Delivery Maintenance"
        DeliveryMaintenanceToolStripMenuItem.Visible = False
        ' 
        ' DiscountMaintenaceToolStripMenuItem
        ' 
        DiscountMaintenaceToolStripMenuItem.Font = New Font("Poppins", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DiscountMaintenaceToolStripMenuItem.Name = "DiscountMaintenaceToolStripMenuItem"
        DiscountMaintenaceToolStripMenuItem.Size = New Size(239, 26)
        DiscountMaintenaceToolStripMenuItem.Text = "Discount Maintenace"
        ' 
        ' ExpirationMaintenanceToolStripMenuItem
        ' 
        ExpirationMaintenanceToolStripMenuItem.Font = New Font("Poppins", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ExpirationMaintenanceToolStripMenuItem.Name = "ExpirationMaintenanceToolStripMenuItem"
        ExpirationMaintenanceToolStripMenuItem.Size = New Size(239, 26)
        ExpirationMaintenanceToolStripMenuItem.Text = "Expiration Maintenance"
        ' 
        ' CategoryMaintenanceToolStripMenuItem
        ' 
        CategoryMaintenanceToolStripMenuItem.Font = New Font("Poppins", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CategoryMaintenanceToolStripMenuItem.Name = "CategoryMaintenanceToolStripMenuItem"
        CategoryMaintenanceToolStripMenuItem.Size = New Size(239, 26)
        CategoryMaintenanceToolStripMenuItem.Text = "Category Maintenance"
        ' 
        ' InventoryMaintenanceToolStripMenuItem1
        ' 
        InventoryMaintenanceToolStripMenuItem1.Font = New Font("Poppins", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        InventoryMaintenanceToolStripMenuItem1.Name = "InventoryMaintenanceToolStripMenuItem1"
        InventoryMaintenanceToolStripMenuItem1.Size = New Size(239, 26)
        InventoryMaintenanceToolStripMenuItem1.Text = "Inventory Maintenance"
        InventoryMaintenanceToolStripMenuItem1.Visible = False
        ' 
        ' SupplierToolStripMenuItem
        ' 
        SupplierToolStripMenuItem.Font = New Font("Poppins", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        SupplierToolStripMenuItem.Name = "SupplierToolStripMenuItem"
        SupplierToolStripMenuItem.Size = New Size(239, 26)
        SupplierToolStripMenuItem.Text = "Supplier"
        ' 
        ' ContextMenuStrip2
        ' 
        ContextMenuStrip2.Font = New Font("Poppins", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ContextMenuStrip2.ImageScalingSize = New Size(24, 24)
        ContextMenuStrip2.Items.AddRange(New ToolStripItem() {SalesReportsToolStripMenuItem, InventoryReportsToolStripMenuItem})
        ContextMenuStrip2.Name = "ContextMenuStrip2"
        ContextMenuStrip2.Size = New Size(205, 56)
        ' 
        ' SalesReportsToolStripMenuItem
        ' 
        SalesReportsToolStripMenuItem.Name = "SalesReportsToolStripMenuItem"
        SalesReportsToolStripMenuItem.Size = New Size(204, 26)
        SalesReportsToolStripMenuItem.Text = "Sales Reports"
        ' 
        ' InventoryReportsToolStripMenuItem
        ' 
        InventoryReportsToolStripMenuItem.Name = "InventoryReportsToolStripMenuItem"
        InventoryReportsToolStripMenuItem.Size = New Size(204, 26)
        InventoryReportsToolStripMenuItem.Text = "Inventory Reports"
        ' 
        ' ContextMenuStrip3
        ' 
        ContextMenuStrip3.Font = New Font("Poppins", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ContextMenuStrip3.ImageScalingSize = New Size(24, 24)
        ContextMenuStrip3.Items.AddRange(New ToolStripItem() {LogHistoryToolStripMenuItem, AuditTrailToolStripMenuItem})
        ContextMenuStrip3.Name = "ContextMenuStrip3"
        ContextMenuStrip3.Size = New Size(161, 56)
        ' 
        ' LogHistoryToolStripMenuItem
        ' 
        LogHistoryToolStripMenuItem.Name = "LogHistoryToolStripMenuItem"
        LogHistoryToolStripMenuItem.Size = New Size(160, 26)
        LogHistoryToolStripMenuItem.Text = "Log History"
        ' 
        ' AuditTrailToolStripMenuItem
        ' 
        AuditTrailToolStripMenuItem.Name = "AuditTrailToolStripMenuItem"
        AuditTrailToolStripMenuItem.Size = New Size(160, 26)
        AuditTrailToolStripMenuItem.Text = "Audit Trail"
        ' 
        ' CentralPanel
        ' 
        CentralPanel.Location = New Point(1198, 598)
        CentralPanel.Name = "CentralPanel"
        CentralPanel.Size = New Size(21, 20)
        CentralPanel.TabIndex = 1
        ' 
        ' MainPanel
        ' 
        MainPanel.Location = New Point(224, 0)
        MainPanel.Name = "MainPanel"
        MainPanel.Size = New Size(1036, 628)
        MainPanel.TabIndex = 21
        ' 
        ' PanelMaintenance
        ' 
        PanelMaintenance.Controls.Add(PanelButtons)
        PanelMaintenance.Controls.Add(MainPanel)
        PanelMaintenance.Controls.Add(CentralPanel)
        PanelMaintenance.Font = New Font("Poppins", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        PanelMaintenance.Location = New Point(0, 0)
        PanelMaintenance.Name = "PanelMaintenance"
        PanelMaintenance.Size = New Size(1260, 628)
        PanelMaintenance.TabIndex = 0
        ' 
        ' PanelButtons
        ' 
        PanelButtons.BackColor = Color.DarkRed
        PanelButtons.Controls.Add(btnLogout)
        PanelButtons.Controls.Add(btnSettings)
        PanelButtons.Controls.Add(btnFileMaintenance)
        PanelButtons.Controls.Add(btnReports)
        PanelButtons.Dock = DockStyle.Left
        PanelButtons.ForeColor = SystemColors.ActiveCaptionText
        PanelButtons.Location = New Point(0, 0)
        PanelButtons.Name = "PanelButtons"
        PanelButtons.Size = New Size(218, 628)
        PanelButtons.TabIndex = 18
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.DarkRed
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnLogout.ForeColor = Color.White
        btnLogout.Image = CType(resources.GetObject("btnLogout.Image"), Image)
        btnLogout.ImageAlign = ContentAlignment.MiddleLeft
        btnLogout.Location = New Point(-1, 572)
        btnLogout.Name = "btnLogout"
        btnLogout.Padding = New Padding(25, 0, 0, 0)
        btnLogout.Size = New Size(219, 51)
        btnLogout.TabIndex = 22
        btnLogout.Text = "                 Logout"
        btnLogout.TextAlign = ContentAlignment.MiddleLeft
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' btnSettings
        ' 
        btnSettings.BackColor = Color.DarkRed
        btnSettings.FlatAppearance.BorderSize = 0
        btnSettings.FlatStyle = FlatStyle.Flat
        btnSettings.Font = New Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSettings.ForeColor = Color.White
        btnSettings.Image = CType(resources.GetObject("btnSettings.Image"), Image)
        btnSettings.ImageAlign = ContentAlignment.MiddleLeft
        btnSettings.Location = New Point(-1, 243)
        btnSettings.Name = "btnSettings"
        btnSettings.Padding = New Padding(25, 0, 0, 0)
        btnSettings.Size = New Size(219, 69)
        btnSettings.TabIndex = 21
        btnSettings.Text = "                 Settings"
        btnSettings.TextAlign = ContentAlignment.MiddleLeft
        btnSettings.UseVisualStyleBackColor = False
        ' 
        ' btnFileMaintenance
        ' 
        btnFileMaintenance.BackColor = Color.DarkRed
        btnFileMaintenance.FlatAppearance.BorderSize = 0
        btnFileMaintenance.FlatStyle = FlatStyle.Flat
        btnFileMaintenance.Font = New Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnFileMaintenance.ForeColor = Color.White
        btnFileMaintenance.Image = CType(resources.GetObject("btnFileMaintenance.Image"), Image)
        btnFileMaintenance.ImageAlign = ContentAlignment.MiddleLeft
        btnFileMaintenance.Location = New Point(-1, 92)
        btnFileMaintenance.Name = "btnFileMaintenance"
        btnFileMaintenance.Padding = New Padding(25, 0, 0, 0)
        btnFileMaintenance.Size = New Size(219, 69)
        btnFileMaintenance.TabIndex = 19
        btnFileMaintenance.Text = "                Maintenance"
        btnFileMaintenance.TextAlign = ContentAlignment.MiddleLeft
        btnFileMaintenance.UseVisualStyleBackColor = False
        ' 
        ' btnReports
        ' 
        btnReports.BackColor = Color.DarkRed
        btnReports.FlatAppearance.BorderSize = 0
        btnReports.FlatStyle = FlatStyle.Flat
        btnReports.Font = New Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnReports.ForeColor = Color.White
        btnReports.Image = CType(resources.GetObject("btnReports.Image"), Image)
        btnReports.ImageAlign = ContentAlignment.MiddleLeft
        btnReports.Location = New Point(0, 168)
        btnReports.Name = "btnReports"
        btnReports.Padding = New Padding(25, 0, 0, 0)
        btnReports.Size = New Size(219, 69)
        btnReports.TabIndex = 20
        btnReports.Text = "                 Reports"
        btnReports.TextAlign = ContentAlignment.MiddleLeft
        btnReports.UseVisualStyleBackColor = False
        ' 
        ' Main
        ' 
        AutoScaleMode = AutoScaleMode.Inherit
        ClientSize = New Size(1260, 626)
        Controls.Add(PanelMaintenance)
        FormBorderStyle = FormBorderStyle.None
        Name = "Main"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Main"
        ContextMenuStrip1.ResumeLayout(False)
        ContextMenuStrip2.ResumeLayout(False)
        ContextMenuStrip3.ResumeLayout(False)
        PanelMaintenance.ResumeLayout(False)
        PanelButtons.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents UserMaintenanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductMaintenanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeliveryMaintenanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DiscountMaintenaceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExpirationMaintenanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CategoryMaintenanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents SalesReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventoryReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip3 As ContextMenuStrip
    Friend WithEvents LogHistoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AuditTrailToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventoryMaintenanceToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CentralPanel As Panel
    Friend WithEvents MainPanel As Panel
    Friend WithEvents PanelMaintenance As Panel
    Friend WithEvents PanelButtons As Panel
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents btnFileMaintenance As Button
    Friend WithEvents btnReports As Button
    Friend WithEvents SupplierToolStripMenuItem As ToolStripMenuItem

End Class
