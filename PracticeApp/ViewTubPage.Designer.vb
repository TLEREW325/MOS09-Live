<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewTubPage
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
        Me.CRVTubPage = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.crxTubtag1 = New MOS09Program.CRXTubtag()
        Me.SuspendLayout()
        '
        'CRVTubPage
        '
        Me.CRVTubPage.ActiveViewIndex = -1
        Me.CRVTubPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRVTubPage.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRVTubPage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRVTubPage.Location = New System.Drawing.Point(0, 0)
        Me.CRVTubPage.Name = "CRVTubPage"
        Me.CRVTubPage.SelectionFormula = ""
        Me.CRVTubPage.ShowGroupTreeButton = False
        Me.CRVTubPage.ShowLogo = False
        Me.CRVTubPage.ShowParameterPanelButton = False
        Me.CRVTubPage.ShowTextSearchButton = False
        Me.CRVTubPage.ShowZoomButton = False
        Me.CRVTubPage.Size = New System.Drawing.Size(1034, 711)
        Me.CRVTubPage.TabIndex = 0
        Me.CRVTubPage.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.CRVTubPage.ViewTimeSelectionFormula = ""
        '
        'ViewTubPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 711)
        Me.Controls.Add(Me.CRVTubPage)
        Me.Name = "ViewTubPage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation View Tub Page"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRVTubPage As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents crxTubtag1 As MOS09Program.CRXTubtag
End Class
