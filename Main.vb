Imports Emgu.CV.Features2D
Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class Main
    Private Shared ReadOnly connectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"
    Private role As String

    ' Constructor to initialize the role
    Public Sub New(userRole As String)
        role = userRole
        InitializeComponent()
    End Sub

    ' Event handler when the Main form is loaded
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Initialize Panels
            InitializePanels()

            ' Configure role-based access
            ConfigureAccessByRole()

            ' Load the POS form when the Main form is loaded
            LoadPOSForm()


            ' Keep the Main form visible as the main window
            Me.Show()
        Catch ex As Exception
            MessageBox.Show("Error loading the Main form: " & ex.Message)
        End Try


    End Sub

    ' Initialize Panels (Left and Center)
    Private Sub InitializePanels()
        If CentralPanel IsNot Nothing Then
            CentralPanel.Visible = True
            CentralPanel.BackColor = Color.White ' Set to #FFFFFF
        End If

        If PanelMaintenance IsNot Nothing Then
            PanelMaintenance.BackColor = Color.White ' Set to #FFFFFF
        End If
    End Sub

    ' Function to configure role-based access
    ' Function to configure role-based access
    Private Sub ConfigureAccessByRole()
        Try
            ' Enable all controls first to reset previous states


            Select Case role
                Case "Cashier"
                    ' Show POS form for cashiers
                    LoadPOSForm()
                    PanelButtons.Visible = False
                    MainPanel.Visible = False
                    ' Ensure Log Out button is always enabled
                    'btnLogOut.Enabled = True

                Case "Staff"
                    ' Show POS form for staff
                    LoadPOSForm()
                    PanelButtons.Visible = False
                    ' Ensure Log Out button is enabled
                    'btnLogOut.Enabled = True
                Case "Admin"
                    ' Do not load the POS form for admin
                    HidePOSForm()
                    ' Hide the CentralPanel when admin logs in
                    CentralPanel.Visible = False
                Case Else
                    ' If role is unknown, disable everything except logout

                    'btnLogOut.Enabled = True
            End Select


        Catch ex As Exception
            MessageBox.Show("Error configuring access by role: " & ex.Message)
        End Try
    End Sub

    ' Hide POS form
    Private Sub HidePOSForm()
        CentralPanel.Controls.Clear()
    End Sub

    ' Open POS Form into Central Panel (only for non-admin users)
    Private Sub LoadPOSForm()
        Try
            ' Check if the role is not Admin
            If role <> "Admin" Then
                Dim posForm As New POS(SessionData.CurrentUserId) With {
                .TopLevel = False,
                .Dock = DockStyle.Fill
            }
                CentralPanel.Controls.Clear()
                CentralPanel.Controls.Add(posForm)
                posForm.Show()
            Else
                ' If Admin, clear the Central Panel and do not load POS form
                CentralPanel.Controls.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading POS form: " & ex.Message)
        End Try
    End Sub


    ' Apply color and style customization for buttons (without altering button size)
    Private Sub CentralPanel_Paint(sender As Object, e As PaintEventArgs) Handles CentralPanel.Paint
        CentralPanel.Size = New Size(1222, 673)

        ' Center CentralPanel on the form
        CentralPanel.Location = New Point((Me.ClientSize.Width - CentralPanel.Width) / 2, (Me.ClientSize.Height - CentralPanel.Height) / 2)
    End Sub

    Private Sub Logaudittrail(ByVal role As String, ByVal fullName As String, ByVal action As String)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "INSERT INTO audittrail (Role, FullName, Action, Form, Date) VALUES (@Role, @FullName, @Action, @Form, @Date)"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@Role", role)
                    cmd.Parameters.AddWithValue("@FullName", fullName)
                    cmd.Parameters.AddWithValue("@Action", action)
                    cmd.Parameters.AddWithValue("@Form", "Logout") ' Form name
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




    '================BUTTONS====================='
    Private Sub btnFileMaintenance_Click(sender As Object, e As EventArgs) Handles btnFileMaintenance.Click
        ' Show context menu for File Maintenance
        ContextMenuStrip1.Show(btnFileMaintenance, 0, btnFileMaintenance.Height)

    End Sub





    Private Sub Button_MouseEnter(sender As Object, e As EventArgs) Handles btnFileMaintenance.MouseEnter, btnReports.MouseEnter, btnSettings.MouseEnter, btnLogout.MouseEnter
        DirectCast(sender, Button).Refresh()
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        ' Create an instance of the Reports form and show it
        ContextMenuStrip2.Show(btnReports, 0, btnReports.Height)
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        ' Create an instance of the Settings form and show it
        ContextMenuStrip3.Show(btnSettings, 0, btnSettings.Height)
    End Sub

    Private Sub btnLogout_Click_1(sender As Object, e As EventArgs) Handles btnLogout.Click
        ' Optionally confirm logout
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Log Audit Trail for the logout event
            Logaudittrail(SessionData.role, SessionData.fullName, "Logged out.")

            ' Close the current form
            Me.Close()

            ' Restart the application by starting the main form again (you could also use Application.Restart)
            Application.Restart()
        End If
    End Sub


    Private Sub Button_MouseLeave(sender As Object, e As EventArgs) Handles btnFileMaintenance.MouseLeave, btnReports.MouseLeave, btnSettings.MouseLeave, btnLogout.MouseLeave
        DirectCast(sender, Button).Refresh()
    End Sub

    Private Sub Button_Paint(sender As Object, e As PaintEventArgs) Handles btnFileMaintenance.Paint, btnReports.Paint, btnSettings.Paint, btnLogout.Paint
        Dim btn As Button = DirectCast(sender, Button)
        Dim g As Graphics = e.Graphics

        ' Check if the mouse is hovering over the button
        If btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position)) Then
            Dim leftBorder As New Rectangle(0, 0, 5, btn.Height) ' 5px white left border
            g.FillRectangle(Brushes.White, leftBorder)
        End If
    End Sub



    Private currentForm As Form = Nothing ' Para matandaan ang kasalukuyang form

    Private Sub LoadFormToPanel(ByVal childForm As Form)
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        MainPanel.Controls.Add(childForm)
        childForm.BringToFront()
        childForm.Show()
    End Sub





    Private Sub UserMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserMaintenanceToolStripMenuItem.Click
        ' Tawagin ang function para i-load ang UserMain form sa panel
        LoadFormToPanel(New UserMain())
    End Sub

    Private Sub DeliveryMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeliveryMaintenanceToolStripMenuItem.Click
        LoadFormToPanel(New DeliveryMain())
    End Sub

    Private Sub DiscountMaintenaceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiscountMaintenaceToolStripMenuItem.Click
        LoadFormToPanel(New DiscountMain())
    End Sub

    'Private Sub ExpirationMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExpirationMaintenanceToolStripMenuItem.Click
    '    Dim inventoryForm As New InventoryMain()
    '    inventoryForm.Show()
    'End Sub

    Private Sub InventoryMaintenanceToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles InventoryMaintenanceToolStripMenuItem1.Click
        LoadFormToPanel(New InventoryMain())
    End Sub

    Private Sub CategoryMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoryMaintenanceToolStripMenuItem.Click
        LoadFormToPanel(New CategoryMain())
    End Sub

    Private Sub SalesReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesReportsToolStripMenuItem.Click
        LoadFormToPanel(New SalesReportForm())
    End Sub

    Private Sub InventoryReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventoryReportsToolStripMenuItem.Click
        LoadFormToPanel(New InventoryReportForm())
    End Sub

    Private Sub LogHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogHistoryToolStripMenuItem.Click
        LoadFormToPanel(New LogHistoryForm())
    End Sub

    Private Sub AuditTrailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AuditTrailToolStripMenuItem.Click
        LoadFormToPanel(New AuditTrailForm())
    End Sub

    Private Sub ProductMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductMaintenanceToolStripMenuItem.Click
        LoadFormToPanel(New ProductMain())
    End Sub

    Private Sub ExpirationMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExpirationMaintenanceToolStripMenuItem.Click
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem.Click
        LoadFormToPanel(New SupplierMain())
    End Sub

    Private Sub PanelButtons_Paint(sender As Object, e As PaintEventArgs) Handles PanelButtons.Paint

    End Sub
End Class