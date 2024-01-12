<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewGaugeSignouts
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadSheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.bsrGaugeSignout = New System.Windows.Forms.WebBrowser
        Me.lstbxGaugeSignouts = New System.Windows.Forms.ListBox
        Me.lblGaugesignoutLabel = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1034, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UploadSheetToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'UploadSheetToolStripMenuItem
        '
        Me.UploadSheetToolStripMenuItem.Name = "UploadSheetToolStripMenuItem"
        Me.UploadSheetToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.UploadSheetToolStripMenuItem.Text = "Upload Sheet"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'bsrGaugeSignout
        '
        Me.bsrGaugeSignout.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bsrGaugeSignout.Location = New System.Drawing.Point(233, 27)
        Me.bsrGaugeSignout.MinimumSize = New System.Drawing.Size(20, 20)
        Me.bsrGaugeSignout.Name = "bsrGaugeSignout"
        Me.bsrGaugeSignout.Size = New System.Drawing.Size(801, 683)
        Me.bsrGaugeSignout.TabIndex = 1
        '
        'lstbxGaugeSignouts
        '
        Me.lstbxGaugeSignouts.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lstbxGaugeSignouts.FormattingEnabled = True
        Me.lstbxGaugeSignouts.ItemHeight = 16
        Me.lstbxGaugeSignouts.Location = New System.Drawing.Point(4, 71)
        Me.lstbxGaugeSignouts.Name = "lstbxGaugeSignouts"
        Me.lstbxGaugeSignouts.Size = New System.Drawing.Size(223, 628)
        Me.lstbxGaugeSignouts.TabIndex = 2
        '
        'lblGaugesignoutLabel
        '
        Me.lblGaugesignoutLabel.AutoSize = True
        Me.lblGaugesignoutLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGaugesignoutLabel.Location = New System.Drawing.Point(12, 55)
        Me.lblGaugesignoutLabel.Name = "lblGaugesignoutLabel"
        Me.lblGaugesignoutLabel.Size = New System.Drawing.Size(136, 13)
        Me.lblGaugesignoutLabel.TabIndex = 3
        Me.lblGaugesignoutLabel.Text = "Gauge Sign-out sheets"
        '
        'ViewGaugeSignouts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 711)
        Me.Controls.Add(Me.lblGaugesignoutLabel)
        Me.Controls.Add(Me.lstbxGaugeSignouts)
        Me.Controls.Add(Me.bsrGaugeSignout)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewGaugeSignouts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Gauge Sign-outs"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bsrGaugeSignout As System.Windows.Forms.WebBrowser
    Friend WithEvents lstbxGaugeSignouts As System.Windows.Forms.ListBox
    Friend WithEvents lblGaugesignoutLabel As System.Windows.Forms.Label
    Friend WithEvents UploadSheetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
