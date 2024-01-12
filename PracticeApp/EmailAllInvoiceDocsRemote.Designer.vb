<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmailAllInvoiceDocsRemote
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
        Me.CRInvoiceViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXTruweldNOCERT1 = New MOS09Program.CRXTruweldNOCERT
        Me.CRXInvoiceTFP1 = New MOS09Program.CRXInvoiceTFP
        Me.CRXTWCert011 = New MOS09Program.CRXTWCert01
        Me.CRXInvoiceTFF1 = New MOS09Program.CRXInvoiceTFF
        Me.CRXInvoice1 = New MOS09Program.CRXInvoice
        Me.CRXInvoiceBillOnly1 = New MOS09Program.CRXInvoiceBillOnly
        Me.CRXInvoiceTFFBillOnly1 = New MOS09Program.CRXInvoiceTFFBillOnly
        Me.CRXInvoiceBillOnlyTFP1 = New MOS09Program.CRXInvoiceBillOnlyTFP
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(468, 249)
        Me.GroupBox1.TabIndex = 6
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
        'CRInvoiceViewer
        '
        Me.CRInvoiceViewer.ActiveViewIndex = 0
        Me.CRInvoiceViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRInvoiceViewer.DisplayGroupTree = False
        Me.CRInvoiceViewer.Location = New System.Drawing.Point(149, 73)
        Me.CRInvoiceViewer.Name = "CRInvoiceViewer"
        Me.CRInvoiceViewer.ReportSource = Me.CRXTruweldNOCERT1
        Me.CRInvoiceViewer.ShowGroupTreeButton = False
        Me.CRInvoiceViewer.ShowTextSearchButton = False
        Me.CRInvoiceViewer.ShowZoomButton = False
        Me.CRInvoiceViewer.Size = New System.Drawing.Size(185, 110)
        Me.CRInvoiceViewer.TabIndex = 0
        '
        'EmailAllInvoiceDocsRemote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 273)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CRInvoiceViewer)
        Me.Name = "EmailAllInvoiceDocsRemote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Invoice and Certs"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRInvoiceViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXInvoice1 As MOS09Program.CRXInvoice
    Friend WithEvents CRXInvoiceTFF1 As MOS09Program.CRXInvoiceTFF
    Friend WithEvents CRXInvoiceBillOnly1 As MOS09Program.CRXInvoiceBillOnly
    Friend WithEvents CRXInvoiceTFFBillOnly1 As MOS09Program.CRXInvoiceTFFBillOnly
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CRXTWCert011 As MOS09Program.CRXTWCert01
    Friend WithEvents CRXInvoiceTFP1 As MOS09Program.CRXInvoiceTFP
    Friend WithEvents CRXInvoiceBillOnlyTFP1 As MOS09Program.CRXInvoiceBillOnlyTFP
    Friend WithEvents CRXTruweldNOCERT1 As MOS09Program.CRXTruweldNOCERT
End Class
