<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintAPCheckRemittance
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CRRemmittanceViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXPTRemittance1 = New MOS09Program.CRXPTRemittance
        Me.EmailRemittanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1030, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmailRemittanceToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'CRRemmittanceViewer
        '
        Me.CRRemmittanceViewer.ActiveViewIndex = 0
        Me.CRRemmittanceViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRRemmittanceViewer.DisplayGroupTree = False
        Me.CRRemmittanceViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRRemmittanceViewer.Location = New System.Drawing.Point(0, 24)
        Me.CRRemmittanceViewer.Name = "CRRemmittanceViewer"
        Me.CRRemmittanceViewer.ReportSource = Me.CRXPTRemittance1
        Me.CRRemmittanceViewer.ShowGroupTreeButton = False
        Me.CRRemmittanceViewer.ShowTextSearchButton = False
        Me.CRRemmittanceViewer.Size = New System.Drawing.Size(1030, 608)
        Me.CRRemmittanceViewer.TabIndex = 1
        '
        'EmailRemittanceToolStripMenuItem
        '
        Me.EmailRemittanceToolStripMenuItem.Name = "EmailRemittanceToolStripMenuItem"
        Me.EmailRemittanceToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.EmailRemittanceToolStripMenuItem.Text = "Email Remittance"
        '
        'PrintAPCheckRemittance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 632)
        Me.Controls.Add(Me.CRRemmittanceViewer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "PrintAPCheckRemittance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation AP Remmittance"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CRRemmittanceViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXPTRemittance1 As MOS09Program.CRXPTRemittance
    Friend WithEvents EmailRemittanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
