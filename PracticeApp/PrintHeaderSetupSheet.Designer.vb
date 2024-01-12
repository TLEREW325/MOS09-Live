<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintHeaderSetupSheet
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
        Me.CRVHeaderSetupSheet = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'CRVHeaderSetupSheet
        '
        Me.CRVHeaderSetupSheet.ActiveViewIndex = -1
        Me.CRVHeaderSetupSheet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CRVHeaderSetupSheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRVHeaderSetupSheet.DisplayGroupTree = False
        Me.CRVHeaderSetupSheet.Location = New System.Drawing.Point(0, 0)
        Me.CRVHeaderSetupSheet.Name = "CRVHeaderSetupSheet"
        Me.CRVHeaderSetupSheet.SelectionFormula = ""
        Me.CRVHeaderSetupSheet.Size = New System.Drawing.Size(1034, 711)
        Me.CRVHeaderSetupSheet.TabIndex = 0
        Me.CRVHeaderSetupSheet.ViewTimeSelectionFormula = ""
        '
        'PrintHeaderSetupSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 711)
        Me.Controls.Add(Me.CRVHeaderSetupSheet)
        Me.Name = "PrintHeaderSetupSheet"
        Me.Text = "Print Header Setup Sheet"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRVHeaderSetupSheet As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
