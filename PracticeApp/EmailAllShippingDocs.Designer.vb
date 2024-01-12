<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmailAllShippingDocs
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CRShippingViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXPackingSlip1 = New MOS09Program.CRXPackingSlip
        Me.CRXTWCert011 = New MOS09Program.CRXTWCert01
        Me.CRXBOL1 = New MOS09Program.CRXBOL
        Me.CRXTruweldNOCERT1 = New MOS09Program.CRXTruweldNOCERT
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(468, 249)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(410, 49)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Attaching to email... Please wait."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CRShippingViewer
        '
        Me.CRShippingViewer.ActiveViewIndex = 0
        Me.CRShippingViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRShippingViewer.Location = New System.Drawing.Point(104, 47)
        Me.CRShippingViewer.Name = "CRShippingViewer"
        Me.CRShippingViewer.ReportSource = Me.CRXTruweldNOCERT1
        Me.CRShippingViewer.Size = New System.Drawing.Size(150, 150)
        Me.CRShippingViewer.TabIndex = 6
        '
        'EmailAllShippingDocs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 273)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CRShippingViewer)
        Me.Name = "EmailAllShippingDocs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Shipping Documents"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CRShippingViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXPackingSlip1 As MOS09Program.CRXPackingSlip
    Friend WithEvents CRXBOL1 As MOS09Program.CRXBOL
    Friend WithEvents CRXTWCert011 As MOS09Program.CRXTWCert01
    Friend WithEvents CRXTruweldNOCERT1 As MOS09Program.CRXTruweldNOCERT
End Class
