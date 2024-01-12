<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintInvoiceCerts
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
        Me.CRCertViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXTWCert011 = New MOS09Program.CRXTWCert01
        Me.SuspendLayout()
        '
        'CRCertViewer
        '
        Me.CRCertViewer.ActiveViewIndex = 0
        Me.CRCertViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRCertViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRCertViewer.Location = New System.Drawing.Point(0, 0)
        Me.CRCertViewer.Name = "CRCertViewer"
        Me.CRCertViewer.ReportSource = Me.CRXTWCert011
        Me.CRCertViewer.Size = New System.Drawing.Size(104, 0)
        Me.CRCertViewer.TabIndex = 0
        '
        'PrintInvoiceCerts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(104, 0)
        Me.Controls.Add(Me.CRCertViewer)
        Me.Name = "PrintInvoiceCerts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PrintInvoiceCerts"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRCertViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXTWCert011 As MOS09Program.CRXTWCert01
End Class
