<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CurrentAnnouncements
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
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.txtMessage1 = New System.Windows.Forms.TextBox
        Me.txtMessage3 = New System.Windows.Forms.TextBox
        Me.txtMessage4 = New System.Windows.Forms.TextBox
        Me.txtMessage2 = New System.Windows.Forms.TextBox
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(542, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem1})
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'cmdPrint
        '
        Me.cmdPrint.Location = New System.Drawing.Point(382, 371)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 13
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(459, 371)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 12
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'txtMessage1
        '
        Me.txtMessage1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtMessage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessage1.Enabled = False
        Me.txtMessage1.Location = New System.Drawing.Point(12, 49)
        Me.txtMessage1.Multiline = True
        Me.txtMessage1.Name = "txtMessage1"
        Me.txtMessage1.Size = New System.Drawing.Size(518, 69)
        Me.txtMessage1.TabIndex = 14
        '
        'txtMessage3
        '
        Me.txtMessage3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtMessage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessage3.Enabled = False
        Me.txtMessage3.Location = New System.Drawing.Point(12, 207)
        Me.txtMessage3.Multiline = True
        Me.txtMessage3.Name = "txtMessage3"
        Me.txtMessage3.Size = New System.Drawing.Size(518, 69)
        Me.txtMessage3.TabIndex = 15
        '
        'txtMessage4
        '
        Me.txtMessage4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtMessage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessage4.Enabled = False
        Me.txtMessage4.Location = New System.Drawing.Point(12, 286)
        Me.txtMessage4.Multiline = True
        Me.txtMessage4.Name = "txtMessage4"
        Me.txtMessage4.Size = New System.Drawing.Size(518, 69)
        Me.txtMessage4.TabIndex = 16
        '
        'txtMessage2
        '
        Me.txtMessage2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtMessage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessage2.Enabled = False
        Me.txtMessage2.Location = New System.Drawing.Point(12, 128)
        Me.txtMessage2.Multiline = True
        Me.txtMessage2.Name = "txtMessage2"
        Me.txtMessage2.Size = New System.Drawing.Size(518, 69)
        Me.txtMessage2.TabIndex = 17
        '
        'CurrentAnnouncements
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 423)
        Me.Controls.Add(Me.txtMessage2)
        Me.Controls.Add(Me.txtMessage4)
        Me.Controls.Add(Me.txtMessage3)
        Me.Controls.Add(Me.txtMessage1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "CurrentAnnouncements"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Current Announcements"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents txtMessage1 As System.Windows.Forms.TextBox
    Friend WithEvents txtMessage3 As System.Windows.Forms.TextBox
    Friend WithEvents txtMessage4 As System.Windows.Forms.TextBox
    Friend WithEvents txtMessage2 As System.Windows.Forms.TextBox
End Class
