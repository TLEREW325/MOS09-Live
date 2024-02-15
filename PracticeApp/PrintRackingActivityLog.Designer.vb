<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintRackingActivityLog
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
        Me.CRVRackingActivityLog = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.CRXRackingActivityLog1 = New MOS09Program.CRXRackingActivityLog()
        Me.SuspendLayout()
        '
        'CRVRackingActivityLog
        '
        Me.CRVRackingActivityLog.ActiveViewIndex = 0
        Me.CRVRackingActivityLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRVRackingActivityLog.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRVRackingActivityLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRVRackingActivityLog.Location = New System.Drawing.Point(0, 0)
        Me.CRVRackingActivityLog.Name = "CRVRackingActivityLog"
        Me.CRVRackingActivityLog.ReportSource = Me.CRXRackingActivityLog1
        Me.CRVRackingActivityLog.ShowGroupTreeButton = False
        Me.CRVRackingActivityLog.ShowLogo = False
        Me.CRVRackingActivityLog.ShowParameterPanelButton = False
        Me.CRVRackingActivityLog.ShowTextSearchButton = False
        Me.CRVRackingActivityLog.ShowZoomButton = False
        Me.CRVRackingActivityLog.Size = New System.Drawing.Size(1030, 632)
        Me.CRVRackingActivityLog.TabIndex = 0
        Me.CRVRackingActivityLog.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'PrintRackingActivityLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 632)
        Me.Controls.Add(Me.CRVRackingActivityLog)
        Me.Name = "PrintRackingActivityLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Racking Activity"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRVRackingActivityLog As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXRackingActivityLog1 As MOS09Program.CRXRackingActivityLog
End Class
