<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintAPPaymentBatch
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
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.CRAPBatchViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRAPPaymentViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXAPPaymentBatch1 = New MOS09Program.CRXAPPaymentBatch
        Me.EmailPaymentBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
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
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmailPaymentBatchToolStripMenuItem})
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
        'CRAPBatchViewer
        '
        Me.CRAPBatchViewer.ActiveViewIndex = -1
        Me.CRAPBatchViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRAPBatchViewer.DisplayGroupTree = False
        Me.CRAPBatchViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRAPBatchViewer.Location = New System.Drawing.Point(0, 24)
        Me.CRAPBatchViewer.Name = "CRAPBatchViewer"
        Me.CRAPBatchViewer.SelectionFormula = ""
        Me.CRAPBatchViewer.Size = New System.Drawing.Size(1030, 608)
        Me.CRAPBatchViewer.TabIndex = 1
        Me.CRAPBatchViewer.ViewTimeSelectionFormula = ""
        '
        'CRAPPaymentViewer
        '
        Me.CRAPPaymentViewer.ActiveViewIndex = 0
        Me.CRAPPaymentViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CRAPPaymentViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRAPPaymentViewer.DisplayGroupTree = False
        Me.CRAPPaymentViewer.Location = New System.Drawing.Point(0, 24)
        Me.CRAPPaymentViewer.Name = "CRAPPaymentViewer"
        Me.CRAPPaymentViewer.ReportSource = Me.CRXAPPaymentBatch1
        Me.CRAPPaymentViewer.ShowGroupTreeButton = False
        Me.CRAPPaymentViewer.ShowTextSearchButton = False
        Me.CRAPPaymentViewer.ShowZoomButton = False
        Me.CRAPPaymentViewer.Size = New System.Drawing.Size(1028, 608)
        Me.CRAPPaymentViewer.TabIndex = 2
        '
        'EmailPaymentBatchToolStripMenuItem
        '
        Me.EmailPaymentBatchToolStripMenuItem.Name = "EmailPaymentBatchToolStripMenuItem"
        Me.EmailPaymentBatchToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.EmailPaymentBatchToolStripMenuItem.Text = "Email Payment Batch"
        '
        'PrintAPPaymentBatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 632)
        Me.Controls.Add(Me.CRAPPaymentViewer)
        Me.Controls.Add(Me.CRAPBatchViewer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "PrintAPPaymentBatch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation AP Payment Batch"
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
    Friend WithEvents CRAPBatchViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRAPPaymentViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXAPPaymentBatch1 As MOS09Program.CRXAPPaymentBatch
    Friend WithEvents EmailPaymentBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
