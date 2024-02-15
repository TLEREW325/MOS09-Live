<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintLotNumberListFiltered
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
        Me.CRLotViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.CRXLotNumberList1 = New MOS09Program.CRXLotNumberList()
        Me.SuspendLayout()
        '
        'CRLotViewer
        '
        Me.CRLotViewer.ActiveViewIndex = 0
        Me.CRLotViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CRLotViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRLotViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRLotViewer.Location = New System.Drawing.Point(0, 0)
        Me.CRLotViewer.Name = "CRLotViewer"
        Me.CRLotViewer.ReportSource = Me.CRXLotNumberList1
        Me.CRLotViewer.ShowGroupTreeButton = False
        Me.CRLotViewer.ShowLogo = False
        Me.CRLotViewer.ShowParameterPanelButton = False
        Me.CRLotViewer.ShowTextSearchButton = False
        Me.CRLotViewer.ShowZoomButton = False
        Me.CRLotViewer.Size = New System.Drawing.Size(1030, 632)
        Me.CRLotViewer.TabIndex = 0
        Me.CRLotViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'PrintLotNumberListFiltered
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 632)
        Me.Controls.Add(Me.CRLotViewer)
        Me.Name = "PrintLotNumberListFiltered"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Lot Number Listing"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRLotViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXLotNumberList1 As MOS09Program.CRXLotNumberList
End Class
