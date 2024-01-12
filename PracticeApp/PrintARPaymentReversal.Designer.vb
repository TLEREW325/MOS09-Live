<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintARPaymentReversal
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
        Me.CRPaymentViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXARPaymentReversal1 = New MOS09Program.CRXARPaymentReversal
        Me.SuspendLayout()
        '
        'CRPaymentViewer
        '
        Me.CRPaymentViewer.ActiveViewIndex = 0
        Me.CRPaymentViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRPaymentViewer.DisplayGroupTree = False
        Me.CRPaymentViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRPaymentViewer.Location = New System.Drawing.Point(0, 0)
        Me.CRPaymentViewer.Name = "CRPaymentViewer"
        Me.CRPaymentViewer.ReportSource = Me.CRXARPaymentReversal1
        Me.CRPaymentViewer.Size = New System.Drawing.Size(104, 23)
        Me.CRPaymentViewer.TabIndex = 0
        '
        'PrintARPaymentReversal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(104, 23)
        Me.Controls.Add(Me.CRPaymentViewer)
        Me.Name = "PrintARPaymentReversal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PrintARPaymentReversal"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRPaymentViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXARPaymentReversal1 As MOS09Program.CRXARPaymentReversal
End Class
