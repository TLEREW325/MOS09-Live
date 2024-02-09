<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintCharterSteelDispatchEntry
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.CRChaterSteelDispatchEntryViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.CRXCharterSteelDispatchEntry1 = New MOS09Program.CRXCharterSteelDispatchEntry()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1030, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuItemExit})
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'mnuItemExit
        '
        Me.mnuItemExit.Name = "mnuItemExit"
        Me.mnuItemExit.Size = New System.Drawing.Size(92, 22)
        Me.mnuItemExit.Text = "Exit"
        '
        'CRChaterSteelDispatchEntryViewer
        '
        Me.CRChaterSteelDispatchEntryViewer.ActiveViewIndex = 0
        Me.CRChaterSteelDispatchEntryViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRChaterSteelDispatchEntryViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRChaterSteelDispatchEntryViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRChaterSteelDispatchEntryViewer.Location = New System.Drawing.Point(0, 24)
        Me.CRChaterSteelDispatchEntryViewer.Name = "CRChaterSteelDispatchEntryViewer"
        Me.CRChaterSteelDispatchEntryViewer.ReportSource = Me.CRXCharterSteelDispatchEntry1
        Me.CRChaterSteelDispatchEntryViewer.ShowGroupTreeButton = False
        Me.CRChaterSteelDispatchEntryViewer.ShowLogo = False
        Me.CRChaterSteelDispatchEntryViewer.ShowParameterPanelButton = False
        Me.CRChaterSteelDispatchEntryViewer.ShowTextSearchButton = False
        Me.CRChaterSteelDispatchEntryViewer.ShowZoomButton = False
        Me.CRChaterSteelDispatchEntryViewer.Size = New System.Drawing.Size(1030, 608)
        Me.CRChaterSteelDispatchEntryViewer.TabIndex = 4
        Me.CRChaterSteelDispatchEntryViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'PrintCharterSteelDispatchEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 632)
        Me.Controls.Add(Me.CRChaterSteelDispatchEntryViewer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "PrintCharterSteelDispatchEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Charter Steel Dispatch Entry"
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
    Friend WithEvents mnuItemExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CRChaterSteelDispatchEntryViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXCharterSteelDispatchEntry1 As MOS09Program.CRXCharterSteelDispatchEntry
End Class
