<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintAllShippingDocs
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
        Me.CRPackListViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXPackingSlipTFP1 = New MOS09Program.CRXPackingSlipTFP
        Me.CRXPackingSlip1 = New MOS09Program.CRXPackingSlip
        Me.CRBOLViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXBOL1 = New MOS09Program.CRXBOL
        Me.CRCertViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXTruweldNOCERT1 = New MOS09Program.CRXTruweldNOCERT
        Me.CRXTWCert011 = New MOS09Program.CRXTWCert01
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdNo = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CRPackListViewer
        '
        Me.CRPackListViewer.ActiveViewIndex = 0
        Me.CRPackListViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRPackListViewer.DisplayGroupTree = False
        Me.CRPackListViewer.Dock = System.Windows.Forms.DockStyle.Top
        Me.CRPackListViewer.Location = New System.Drawing.Point(0, 0)
        Me.CRPackListViewer.Name = "CRPackListViewer"
        Me.CRPackListViewer.ReportSource = Me.CRXPackingSlipTFP1
        Me.CRPackListViewer.Size = New System.Drawing.Size(492, 47)
        Me.CRPackListViewer.TabIndex = 5
        '
        'CRBOLViewer
        '
        Me.CRBOLViewer.ActiveViewIndex = 0
        Me.CRBOLViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRBOLViewer.DisplayGroupTree = False
        Me.CRBOLViewer.Dock = System.Windows.Forms.DockStyle.Top
        Me.CRBOLViewer.Location = New System.Drawing.Point(0, 47)
        Me.CRBOLViewer.Name = "CRBOLViewer"
        Me.CRBOLViewer.ReportSource = Me.CRXBOL1
        Me.CRBOLViewer.Size = New System.Drawing.Size(492, 46)
        Me.CRBOLViewer.TabIndex = 5
        Me.CRBOLViewer.TabStop = False
        '
        'CRCertViewer
        '
        Me.CRCertViewer.ActiveViewIndex = 0
        Me.CRCertViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRCertViewer.DisplayGroupTree = False
        Me.CRCertViewer.Dock = System.Windows.Forms.DockStyle.Top
        Me.CRCertViewer.Location = New System.Drawing.Point(0, 93)
        Me.CRCertViewer.Name = "CRCertViewer"
        Me.CRCertViewer.ReportSource = Me.CRXTruweldNOCERT1
        Me.CRCertViewer.Size = New System.Drawing.Size(492, 47)
        Me.CRCertViewer.TabIndex = 5
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(167, 146)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 41)
        Me.cmdExit.TabIndex = 0
        Me.cmdExit.Text = "YES"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdNo)
        Me.GroupBox1.Controls.Add(Me.cmdExit)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(492, 273)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(6, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(480, 22)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "(YES = EXIT, NO = REPRINT)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(480, 36)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Did the Shipping Documents print ok?"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdNo
        '
        Me.cmdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNo.Location = New System.Drawing.Point(248, 146)
        Me.cmdNo.Name = "cmdNo"
        Me.cmdNo.Size = New System.Drawing.Size(75, 41)
        Me.cmdNo.TabIndex = 1
        Me.cmdNo.Text = "NO"
        Me.cmdNo.UseVisualStyleBackColor = True
        '
        'PrintAllShippingDocs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 273)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CRCertViewer)
        Me.Controls.Add(Me.CRBOLViewer)
        Me.Controls.Add(Me.CRPackListViewer)
        Me.Name = "PrintAllShippingDocs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Shipping Documents"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRPackListViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXPackingSlip1 As MOS09Program.CRXPackingSlip
    Friend WithEvents CRBOLViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXBOL1 As MOS09Program.CRXBOL
    Friend WithEvents CRCertViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdNo As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CRXTWCert011 As MOS09Program.CRXTWCert01
    Friend WithEvents CRXPackingSlipTFP1 As MOS09Program.CRXPackingSlipTFP
    Friend WithEvents CRXTruweldNOCERT1 As MOS09Program.CRXTruweldNOCERT
End Class
