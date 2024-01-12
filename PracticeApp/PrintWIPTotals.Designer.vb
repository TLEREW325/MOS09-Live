<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintWIPTotals
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
        Me.CRVWIPTotals = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'CRVWIPTotals
        '
        Me.CRVWIPTotals.ActiveViewIndex = -1
        Me.CRVWIPTotals.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRVWIPTotals.DisplayGroupTree = False
        Me.CRVWIPTotals.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRVWIPTotals.Location = New System.Drawing.Point(0, 0)
        Me.CRVWIPTotals.Name = "CRVWIPTotals"
        Me.CRVWIPTotals.SelectionFormula = ""
        Me.CRVWIPTotals.Size = New System.Drawing.Size(1034, 711)
        Me.CRVWIPTotals.TabIndex = 0
        Me.CRVWIPTotals.ViewTimeSelectionFormula = ""
        '
        'PrintWIPTotals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 711)
        Me.Controls.Add(Me.CRVWIPTotals)
        Me.Name = "PrintWIPTotals"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PrintWIPTotals"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRVWIPTotals As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
