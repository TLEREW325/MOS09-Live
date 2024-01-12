<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintSteelReceiptOfGoods
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
        Me.CRReceiptViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXSteelReceipt1 = New MOS09Program.CRXSteelReceipt
        Me.SuspendLayout()
        '
        'CRReceiptViewer
        '
        Me.CRReceiptViewer.ActiveViewIndex = 0
        Me.CRReceiptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRReceiptViewer.DisplayGroupTree = False
        Me.CRReceiptViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRReceiptViewer.Location = New System.Drawing.Point(0, 0)
        Me.CRReceiptViewer.Name = "CRReceiptViewer"
        Me.CRReceiptViewer.ReportSource = Me.CRXSteelReceipt1
        Me.CRReceiptViewer.Size = New System.Drawing.Size(1030, 632)
        Me.CRReceiptViewer.TabIndex = 0
        '
        'PrintSteelReceiptOfGoods
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 632)
        Me.Controls.Add(Me.CRReceiptViewer)
        Me.Name = "PrintSteelReceiptOfGoods"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Steel Receipt Of Goods"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRReceiptViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXSteelReceipt1 As MOS09Program.CRXSteelReceipt
End Class
