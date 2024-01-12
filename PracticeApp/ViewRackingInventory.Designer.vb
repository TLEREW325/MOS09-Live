<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewRackingInventory
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
        Me.CRRackingViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'CRRackingViewer
        '
        Me.CRRackingViewer.ActiveViewIndex = -1
        Me.CRRackingViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRRackingViewer.DisplayGroupTree = False
        Me.CRRackingViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRRackingViewer.Location = New System.Drawing.Point(0, 0)
        Me.CRRackingViewer.Name = "CRRackingViewer"
        Me.CRRackingViewer.SelectionFormula = ""
        Me.CRRackingViewer.Size = New System.Drawing.Size(1192, 723)
        Me.CRRackingViewer.TabIndex = 0
        Me.CRRackingViewer.ViewTimeSelectionFormula = ""
        '
        'ViewRackingInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1192, 723)
        Me.Controls.Add(Me.CRRackingViewer)
        Me.Name = "ViewRackingInventory"
        Me.Text = "View Racking Inventory"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRRackingViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
