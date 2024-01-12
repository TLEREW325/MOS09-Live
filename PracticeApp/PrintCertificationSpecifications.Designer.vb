<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintCertificationSpecifications
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
        Me.CRVCertificaitonSpecifications = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'CRVCertificaitonSpecifications
        '
        Me.CRVCertificaitonSpecifications.ActiveViewIndex = -1
        Me.CRVCertificaitonSpecifications.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRVCertificaitonSpecifications.DisplayGroupTree = False
        Me.CRVCertificaitonSpecifications.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRVCertificaitonSpecifications.Location = New System.Drawing.Point(0, 0)
        Me.CRVCertificaitonSpecifications.Name = "CRVCertificaitonSpecifications"
        Me.CRVCertificaitonSpecifications.SelectionFormula = ""
        Me.CRVCertificaitonSpecifications.ShowGroupTreeButton = False
        Me.CRVCertificaitonSpecifications.ShowTextSearchButton = False
        Me.CRVCertificaitonSpecifications.Size = New System.Drawing.Size(1030, 632)
        Me.CRVCertificaitonSpecifications.TabIndex = 0
        Me.CRVCertificaitonSpecifications.ViewTimeSelectionFormula = ""
        '
        'PrintCertificationSpecifications
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 632)
        Me.Controls.Add(Me.CRVCertificaitonSpecifications)
        Me.Name = "PrintCertificationSpecifications"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Certification Specs"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRVCertificaitonSpecifications As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
