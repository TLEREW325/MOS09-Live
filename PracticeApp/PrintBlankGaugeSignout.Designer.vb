<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintBlankGaugeSignout
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
        Me.crvBlankGaugeSignout = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.CRXBlankGaugeSignout1 = New MOS09Program.CRXBlankGaugeSignout()
        Me.SuspendLayout()
        '
        'crvBlankGaugeSignout
        '
        Me.crvBlankGaugeSignout.ActiveViewIndex = 0
        Me.crvBlankGaugeSignout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvBlankGaugeSignout.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvBlankGaugeSignout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvBlankGaugeSignout.Location = New System.Drawing.Point(0, 0)
        Me.crvBlankGaugeSignout.Name = "crvBlankGaugeSignout"
        Me.crvBlankGaugeSignout.ReportSource = Me.CRXBlankGaugeSignout1
        Me.crvBlankGaugeSignout.ShowGroupTreeButton = False
        Me.crvBlankGaugeSignout.ShowLogo = False
        Me.crvBlankGaugeSignout.ShowTextSearchButton = False
        Me.crvBlankGaugeSignout.ShowZoomButton = False
        Me.crvBlankGaugeSignout.Size = New System.Drawing.Size(1034, 711)
        Me.crvBlankGaugeSignout.TabIndex = 0
        Me.crvBlankGaugeSignout.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'PrintBlankGaugeSignout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 711)
        Me.Controls.Add(Me.crvBlankGaugeSignout)
        Me.Name = "PrintBlankGaugeSignout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Print Blank Gauge Sign-out"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvBlankGaugeSignout As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXBlankGaugeSignout1 As MOS09Program.CRXBlankGaugeSignout
End Class
