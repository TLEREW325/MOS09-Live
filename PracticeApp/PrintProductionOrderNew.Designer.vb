<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintProductionOrderNew
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
        Me.CRProductionViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXProductionOrder0331 = New MOS09Program.CRXProductionOrder033
        Me.CRXProductionOrder0221 = New MOS09Program.CRXProductionOrder022
        Me.SuspendLayout()
        '
        'CRProductionViewer
        '
        Me.CRProductionViewer.ActiveViewIndex = 0
        Me.CRProductionViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRProductionViewer.DisplayGroupTree = False
        Me.CRProductionViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRProductionViewer.Location = New System.Drawing.Point(0, 0)
        Me.CRProductionViewer.Name = "CRProductionViewer"
        Me.CRProductionViewer.ReportSource = Me.CRXProductionOrder0331
        Me.CRProductionViewer.ShowGroupTreeButton = False
        Me.CRProductionViewer.ShowTextSearchButton = False
        Me.CRProductionViewer.Size = New System.Drawing.Size(1030, 632)
        Me.CRProductionViewer.TabIndex = 0
        '
        'PrintProductionOrderNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 632)
        Me.Controls.Add(Me.CRProductionViewer)
        Me.Name = "PrintProductionOrderNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Production Order"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRProductionViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXProductionOrder0331 As MOS09Program.CRXProductionOrder033
    Friend WithEvents CRXProductionOrder0221 As MOS09Program.CRXProductionOrder022
End Class
