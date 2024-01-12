<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintPurchaseOrderBarcode
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
        Me.CRPOViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.EmailPurchaseOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.CRXPurchaseOrderBarcode1 = New MOS09Program.CRXPurchaseOrderBarcode
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CRPOViewer
        '
        Me.CRPOViewer.ActiveViewIndex = 0
        Me.CRPOViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CRPOViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRPOViewer.DisplayGroupTree = False
        Me.CRPOViewer.Location = New System.Drawing.Point(1, 23)
        Me.CRPOViewer.Name = "CRPOViewer"
        Me.CRPOViewer.ReportSource = Me.CRXPurchaseOrderBarcode1
        Me.CRPOViewer.Size = New System.Drawing.Size(1030, 608)
        Me.CRPOViewer.TabIndex = 2
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem1, Me.EditToolStripMenuItem1, Me.ReportsToolStripMenuItem1, Me.ExitToolStripMenuItem2})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1030, 24)
        Me.MenuStrip1.TabIndex = 3
        '
        'FileToolStripMenuItem1
        '
        Me.FileToolStripMenuItem1.Name = "FileToolStripMenuItem1"
        Me.FileToolStripMenuItem1.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem1.Text = "File"
        '
        'EditToolStripMenuItem1
        '
        Me.EditToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmailPurchaseOrderToolStripMenuItem})
        Me.EditToolStripMenuItem1.Name = "EditToolStripMenuItem1"
        Me.EditToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem1.Text = "Edit"
        '
        'EmailPurchaseOrderToolStripMenuItem
        '
        Me.EmailPurchaseOrderToolStripMenuItem.Enabled = False
        Me.EmailPurchaseOrderToolStripMenuItem.Name = "EmailPurchaseOrderToolStripMenuItem"
        Me.EmailPurchaseOrderToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.EmailPurchaseOrderToolStripMenuItem.Text = "Email Purchase Order"
        '
        'ReportsToolStripMenuItem1
        '
        Me.ReportsToolStripMenuItem1.Name = "ReportsToolStripMenuItem1"
        Me.ReportsToolStripMenuItem1.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem1.Text = "Reports"
        '
        'ExitToolStripMenuItem2
        '
        Me.ExitToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem3})
        Me.ExitToolStripMenuItem2.Name = "ExitToolStripMenuItem2"
        Me.ExitToolStripMenuItem2.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem2.Text = "Exit"
        '
        'ExitToolStripMenuItem3
        '
        Me.ExitToolStripMenuItem3.Name = "ExitToolStripMenuItem3"
        Me.ExitToolStripMenuItem3.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem3.Text = "Exit"
        '
        'PrintPurchaseOrderBarcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 632)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.CRPOViewer)
        Me.Name = "PrintPurchaseOrderBarcode"
        Me.Text = "PrintPurchaseOrderBarcode"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CRPOViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXPurchaseOrderBarcode1 As MOS09Program.CRXPurchaseOrderBarcode
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmailPurchaseOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
End Class
