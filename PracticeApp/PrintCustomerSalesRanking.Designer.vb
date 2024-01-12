<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintCustomerSalesRanking
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
        Me.CRVCustomerSalesRanking = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'CRVCustomerSalesRanking
        '
        Me.CRVCustomerSalesRanking.ActiveViewIndex = -1
        Me.CRVCustomerSalesRanking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRVCustomerSalesRanking.DisplayGroupTree = False
        Me.CRVCustomerSalesRanking.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRVCustomerSalesRanking.Location = New System.Drawing.Point(0, 0)
        Me.CRVCustomerSalesRanking.Name = "CRVCustomerSalesRanking"
        Me.CRVCustomerSalesRanking.SelectionFormula = ""
        Me.CRVCustomerSalesRanking.Size = New System.Drawing.Size(1034, 711)
        Me.CRVCustomerSalesRanking.TabIndex = 0
        Me.CRVCustomerSalesRanking.ViewTimeSelectionFormula = ""
        '
        'PrintCustomerSalesRanking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 711)
        Me.Controls.Add(Me.CRVCustomerSalesRanking)
        Me.Name = "PrintCustomerSalesRanking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Customer Sales Ranking"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRVCustomerSalesRanking As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
