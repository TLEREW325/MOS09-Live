<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintPickTicketsAuto
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdNo = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.CRPickViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.CRXPickTicket1 = New MOS09Program.CRXPickTicket()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdNo)
        Me.GroupBox1.Controls.Add(Me.cmdExit)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(492, 273)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(6, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(480, 22)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "(YES = EXIT, NO = REPRINT)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(480, 36)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Did the Pick Tickets print ok?"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdNo
        '
        Me.cmdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNo.Location = New System.Drawing.Point(248, 146)
        Me.cmdNo.Name = "cmdNo"
        Me.cmdNo.Size = New System.Drawing.Size(75, 41)
        Me.cmdNo.TabIndex = 4
        Me.cmdNo.Text = "NO"
        Me.cmdNo.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(167, 146)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 41)
        Me.cmdExit.TabIndex = 3
        Me.cmdExit.Text = "YES"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'CRPickViewer
        '
        Me.CRPickViewer.ActiveViewIndex = 0
        Me.CRPickViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRPickViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRPickViewer.Dock = System.Windows.Forms.DockStyle.Top
        Me.CRPickViewer.Location = New System.Drawing.Point(0, 0)
        Me.CRPickViewer.Name = "CRPickViewer"
        Me.CRPickViewer.ReportSource = Me.CRXPickTicket1
        Me.CRPickViewer.ShowGroupTreeButton = False
        Me.CRPickViewer.ShowLogo = False
        Me.CRPickViewer.ShowParameterPanelButton = False
        Me.CRPickViewer.ShowTextSearchButton = False
        Me.CRPickViewer.ShowZoomButton = False
        Me.CRPickViewer.Size = New System.Drawing.Size(492, 49)
        Me.CRPickViewer.TabIndex = 0
        Me.CRPickViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'PrintPickTicketsAuto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 273)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CRPickViewer)
        Me.Name = "PrintPickTicketsAuto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Pick Tickets"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRPickViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXPickTicket1 As MOS09Program.CRXPickTicket
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdNo As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
End Class
