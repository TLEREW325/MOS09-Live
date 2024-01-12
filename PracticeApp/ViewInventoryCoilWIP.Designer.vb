<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewInventoryCoilWIP
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
        Me.CRVInventoryCoilWIP = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'CRVInventoryCoilWIP
        '
        Me.CRVInventoryCoilWIP.ActiveViewIndex = -1
        Me.CRVInventoryCoilWIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRVInventoryCoilWIP.DisplayGroupTree = False
        Me.CRVInventoryCoilWIP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRVInventoryCoilWIP.Location = New System.Drawing.Point(0, 0)
        Me.CRVInventoryCoilWIP.Name = "CRVInventoryCoilWIP"
        Me.CRVInventoryCoilWIP.SelectionFormula = ""
        Me.CRVInventoryCoilWIP.Size = New System.Drawing.Size(1034, 711)
        Me.CRVInventoryCoilWIP.TabIndex = 0
        Me.CRVInventoryCoilWIP.ViewTimeSelectionFormula = ""
        '
        'ViewInventoryCoilWIP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 711)
        Me.Controls.Add(Me.CRVInventoryCoilWIP)
        Me.Name = "ViewInventoryCoilWIP"
        Me.Text = "View Inventory Coil WIP"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRVInventoryCoilWIP As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
