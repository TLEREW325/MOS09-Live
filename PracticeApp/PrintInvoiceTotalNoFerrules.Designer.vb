<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintInvoiceTotalNoFerrules
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
        Me.CRDailyViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.CRXInvoiceListingNoFerrule1 = New MOS09Program.CRXInvoiceListingNoFerrule()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmailInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CRDailyViewer
        '
        Me.CRDailyViewer.ActiveViewIndex = 0
        Me.CRDailyViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CRDailyViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRDailyViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRDailyViewer.Location = New System.Drawing.Point(-2, 27)
        Me.CRDailyViewer.Name = "CRDailyViewer"
        Me.CRDailyViewer.ReportSource = Me.CRXInvoiceListingNoFerrule1
        Me.CRDailyViewer.ShowGroupTreeButton = False
        Me.CRDailyViewer.ShowLogo = False
        Me.CRDailyViewer.ShowParameterPanelButton = False
        Me.CRDailyViewer.ShowTextSearchButton = False
        Me.CRDailyViewer.ShowZoomButton = False
        Me.CRDailyViewer.Size = New System.Drawing.Size(1033, 608)
        Me.CRDailyViewer.TabIndex = 2
        Me.CRDailyViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(1030, 24)
        Me.MenuStrip2.TabIndex = 4
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.ToolStripMenuItem1.Text = "File"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmailInvoiceToolStripMenuItem})
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(39, 20)
        Me.ToolStripMenuItem2.Text = "Edit"
        '
        'EmailInvoiceToolStripMenuItem
        '
        Me.EmailInvoiceToolStripMenuItem.Name = "EmailInvoiceToolStripMenuItem"
        Me.EmailInvoiceToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.EmailInvoiceToolStripMenuItem.Text = "Email Invoice"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(59, 20)
        Me.ToolStripMenuItem3.Text = "Reports"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem5})
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(37, 20)
        Me.ToolStripMenuItem4.Text = "Exit"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(92, 22)
        Me.ToolStripMenuItem5.Text = "Exit"
        '
        'PrintInvoiceTotalNoFerrules
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 632)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.CRDailyViewer)
        Me.Name = "PrintInvoiceTotalNoFerrules"
        Me.Text = "PrintInvoiceTotalNoFerrules"
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CRDailyViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXInvoiceListingNoFerrule1 As MOS09Program.CRXInvoiceListingNoFerrule
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmailInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
End Class
