<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintDropShipPackList
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
        Me.EmailPackingListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EmailPackingListAndPOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.CRDropShipViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXDropShipPackingSlip1 = New MOS09Program.CRXDropShipPackingSlip
        Me.CRDropShipPOViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXPurchaseOrder1 = New MOS09Program.CRXPurchaseOrder
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
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmailPackingListToolStripMenuItem, Me.EmailPackingListAndPOToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'EmailPackingListToolStripMenuItem
        '
        Me.EmailPackingListToolStripMenuItem.Name = "EmailPackingListToolStripMenuItem"
        Me.EmailPackingListToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.EmailPackingListToolStripMenuItem.Text = "Email Packing List"
        '
        'EmailPackingListAndPOToolStripMenuItem
        '
        Me.EmailPackingListAndPOToolStripMenuItem.Name = "EmailPackingListAndPOToolStripMenuItem"
        Me.EmailPackingListAndPOToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.EmailPackingListAndPOToolStripMenuItem.Text = "Email Packing List and PO"
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
        'CRDropShipViewer
        '
        Me.CRDropShipViewer.ActiveViewIndex = 0
        Me.CRDropShipViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CRDropShipViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRDropShipViewer.DisplayGroupTree = False
        Me.CRDropShipViewer.Location = New System.Drawing.Point(0, 27)
        Me.CRDropShipViewer.Name = "CRDropShipViewer"
        Me.CRDropShipViewer.ReportSource = Me.CRXDropShipPackingSlip1
        Me.CRDropShipViewer.ShowGroupTreeButton = False
        Me.CRDropShipViewer.ShowTextSearchButton = False
        Me.CRDropShipViewer.ShowZoomButton = False
        Me.CRDropShipViewer.Size = New System.Drawing.Size(1030, 605)
        Me.CRDropShipViewer.TabIndex = 1
        '
        'CRDropShipPOViewer
        '
        Me.CRDropShipPOViewer.ActiveViewIndex = 0
        Me.CRDropShipPOViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRDropShipPOViewer.Location = New System.Drawing.Point(134, 366)
        Me.CRDropShipPOViewer.Name = "CRDropShipPOViewer"
        Me.CRDropShipPOViewer.ReportSource = Me.CRXPurchaseOrder1
        Me.CRDropShipPOViewer.Size = New System.Drawing.Size(96, 64)
        Me.CRDropShipPOViewer.TabIndex = 2
        '
        'PrintDropShipPackList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 632)
        Me.Controls.Add(Me.CRDropShipViewer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.CRDropShipPOViewer)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "PrintDropShipPackList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Drop Ship Packing List"
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
    Friend WithEvents CRDropShipViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXDropShipPackingSlip1 As MOS09Program.CRXDropShipPackingSlip
    Friend WithEvents EmailPackingListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmailPackingListAndPOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CRDropShipPOViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXPurchaseOrder1 As MOS09Program.CRXPurchaseOrder
End Class
