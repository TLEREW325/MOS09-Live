﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintPTCheckAmerican
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
        Me.PrintChecksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CRCheckViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.CRXPTCheckType1 = New MOS09Program.CRXPTCheckType()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdPrint = New System.Windows.Forms.Button()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintChecksToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'PrintChecksToolStripMenuItem
        '
        Me.PrintChecksToolStripMenuItem.Name = "PrintChecksToolStripMenuItem"
        Me.PrintChecksToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.PrintChecksToolStripMenuItem.Text = "Print Checks"
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
        'CRCheckViewer
        '
        Me.CRCheckViewer.ActiveViewIndex = 0
        Me.CRCheckViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRCheckViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRCheckViewer.Dock = System.Windows.Forms.DockStyle.Right
        Me.CRCheckViewer.Location = New System.Drawing.Point(185, 24)
        Me.CRCheckViewer.Name = "CRCheckViewer"
        Me.CRCheckViewer.ReportSource = Me.CRXPTCheckType1
        Me.CRCheckViewer.ShowCloseButton = False
        Me.CRCheckViewer.ShowExportButton = False
        Me.CRCheckViewer.ShowGroupTreeButton = False
        Me.CRCheckViewer.ShowPrintButton = False
        Me.CRCheckViewer.ShowTextSearchButton = False
        Me.CRCheckViewer.ShowZoomButton = False
        Me.CRCheckViewer.Size = New System.Drawing.Size(845, 608)
        Me.CRCheckViewer.TabIndex = 1
        Me.CRCheckViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(12, 236)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 101)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "If you choose to re-print the checks, this viewer will close. You will then hit t" &
    "he Print Checks Button in the main form and enter the new starting Check #."
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 151)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 49)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Review checks before they are printed. You may re-print checks if necessary."
        '
        'cmdPrint
        '
        Me.cmdPrint.ForeColor = System.Drawing.Color.Blue
        Me.cmdPrint.Location = New System.Drawing.Point(47, 83)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 5
        Me.cmdPrint.Text = "Print Checks"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'PrintPTCheckAmerican
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 632)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.CRCheckViewer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "PrintPTCheckAmerican"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation AP Check"
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
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CRCheckViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents CRXPTCheckType1 As MOS09Program.CRXPTCheckType
    Friend WithEvents PrintChecksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
