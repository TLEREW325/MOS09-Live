<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintGLJournalAuto
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
        Me.CRJournalViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.CRXGLJournalFiltered1 = New MOS09Program.CRXGLJournalFiltered()
        Me.SuspendLayout()
        '
        'CRJournalViewer
        '
        Me.CRJournalViewer.ActiveViewIndex = 0
        Me.CRJournalViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRJournalViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRJournalViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRJournalViewer.Location = New System.Drawing.Point(0, 0)
        Me.CRJournalViewer.Name = "CRJournalViewer"
        Me.CRJournalViewer.ReportSource = Me.CRXGLJournalFiltered1
        Me.CRJournalViewer.ShowGroupTreeButton = False
        Me.CRJournalViewer.ShowLogo = False
        Me.CRJournalViewer.ShowParameterPanelButton = False
        Me.CRJournalViewer.ShowTextSearchButton = False
        Me.CRJournalViewer.ShowZoomButton = False
        Me.CRJournalViewer.Size = New System.Drawing.Size(292, 273)
        Me.CRJournalViewer.TabIndex = 0
        Me.CRJournalViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'PrintGLJournalAuto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.CRJournalViewer)
        Me.Name = "PrintGLJournalAuto"
        Me.Text = "PrintGLJournalAuto"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRJournalViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXGLJournalFiltered1 As MOS09Program.CRXGLJournalFiltered
End Class
