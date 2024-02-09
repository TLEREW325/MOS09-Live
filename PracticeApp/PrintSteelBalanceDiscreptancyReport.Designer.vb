<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintSteelBalanceDiscreptancyReport
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
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CRVSteelDoubleCheck = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.CRXSteelBalanceDiscreptancyReport1 = New MOS09Program.CRXSteelBalanceDiscreptancyReport()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ExitToolStripMenuItem})
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
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem1})
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'CRVSteelDoubleCheck
        '
        Me.CRVSteelDoubleCheck.ActiveViewIndex = 0
        Me.CRVSteelDoubleCheck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRVSteelDoubleCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRVSteelDoubleCheck.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRVSteelDoubleCheck.Location = New System.Drawing.Point(0, 24)
        Me.CRVSteelDoubleCheck.Name = "CRVSteelDoubleCheck"
        Me.CRVSteelDoubleCheck.ReportSource = Me.CRXSteelBalanceDiscreptancyReport1
        Me.CRVSteelDoubleCheck.ShowGroupTreeButton = False
        Me.CRVSteelDoubleCheck.ShowLogo = False
        Me.CRVSteelDoubleCheck.ShowParameterPanelButton = False
        Me.CRVSteelDoubleCheck.ShowTextSearchButton = False
        Me.CRVSteelDoubleCheck.ShowZoomButton = False
        Me.CRVSteelDoubleCheck.Size = New System.Drawing.Size(1030, 608)
        Me.CRVSteelDoubleCheck.TabIndex = 4
        Me.CRVSteelDoubleCheck.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'PrintSteelBalanceDiscreptancyReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 632)
        Me.Controls.Add(Me.CRVSteelDoubleCheck)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "PrintSteelBalanceDiscreptancyReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Steel Discrepancy Report"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CRVSteelDoubleCheck As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXSteelBalanceDiscreptancyReport1 As MOS09Program.CRXSteelBalanceDiscreptancyReport
End Class
