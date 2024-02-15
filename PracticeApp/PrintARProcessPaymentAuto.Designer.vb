<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintARProcessPaymentAuto
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
        Me.CRBatchViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.CRXARCashReceiptBatchSummary1 = New MOS09Program.CRXARCashReceiptBatchSummary()
        Me.lblPrint = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CRBatchViewer
        '
        Me.CRBatchViewer.ActiveViewIndex = 0
        Me.CRBatchViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRBatchViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRBatchViewer.Location = New System.Drawing.Point(12, 12)
        Me.CRBatchViewer.Name = "CRBatchViewer"
        Me.CRBatchViewer.ReportSource = Me.CRXARCashReceiptBatchSummary1
        Me.CRBatchViewer.ShowGroupTreeButton = False
        Me.CRBatchViewer.ShowLogo = False
        Me.CRBatchViewer.ShowParameterPanelButton = False
        Me.CRBatchViewer.ShowTextSearchButton = False
        Me.CRBatchViewer.ShowZoomButton = False
        Me.CRBatchViewer.Size = New System.Drawing.Size(150, 73)
        Me.CRBatchViewer.TabIndex = 0
        Me.CRBatchViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.CRBatchViewer.Visible = False
        '
        'lblPrint
        '
        Me.lblPrint.AutoSize = True
        Me.lblPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrint.ForeColor = System.Drawing.Color.Blue
        Me.lblPrint.Location = New System.Drawing.Point(106, 40)
        Me.lblPrint.Name = "lblPrint"
        Me.lblPrint.Size = New System.Drawing.Size(90, 20)
        Me.lblPrint.TabIndex = 1
        Me.lblPrint.Text = "Printing ..."
        '
        'PrintARProcessPaymentAuto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 104)
        Me.Controls.Add(Me.lblPrint)
        Me.Controls.Add(Me.CRBatchViewer)
        Me.Name = "PrintARProcessPaymentAuto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation AR Batch Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CRBatchViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXARCashReceiptBatchSummary1 As MOS09Program.CRXARCashReceiptBatchSummary
    Friend WithEvents lblPrint As System.Windows.Forms.Label
End Class
