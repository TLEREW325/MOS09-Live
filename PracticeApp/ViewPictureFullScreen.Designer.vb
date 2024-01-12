<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewPictureFullScreen
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
        Me.hscrlFullScreenPicture = New System.Windows.Forms.HScrollBar
        Me.vscrlFullScreenPicture = New System.Windows.Forms.VScrollBar
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.picbxFullScreenPicture = New System.Windows.Forms.PictureBox
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdDecreaseSize = New System.Windows.Forms.Button
        Me.cmdIncreaseSize = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboScale = New System.Windows.Forms.ComboBox
        Me.MenuStrip1.SuspendLayout()
        CType(Me.picbxFullScreenPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'hscrlFullScreenPicture
        '
        Me.hscrlFullScreenPicture.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hscrlFullScreenPicture.Location = New System.Drawing.Point(9, 739)
        Me.hscrlFullScreenPicture.Name = "hscrlFullScreenPicture"
        Me.hscrlFullScreenPicture.Size = New System.Drawing.Size(1146, 17)
        Me.hscrlFullScreenPicture.TabIndex = 0
        '
        'vscrlFullScreenPicture
        '
        Me.vscrlFullScreenPicture.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vscrlFullScreenPicture.Location = New System.Drawing.Point(1158, 29)
        Me.vscrlFullScreenPicture.Name = "vscrlFullScreenPicture"
        Me.vscrlFullScreenPicture.Size = New System.Drawing.Size(17, 708)
        Me.vscrlFullScreenPicture.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1184, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
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
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'picbxFullScreenPicture
        '
        Me.picbxFullScreenPicture.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picbxFullScreenPicture.Location = New System.Drawing.Point(9, 29)
        Me.picbxFullScreenPicture.Name = "picbxFullScreenPicture"
        Me.picbxFullScreenPicture.Size = New System.Drawing.Size(1146, 707)
        Me.picbxFullScreenPicture.TabIndex = 2
        Me.picbxFullScreenPicture.TabStop = False
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1101, 759)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(1024, 759)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 5
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdDecreaseSize
        '
        Me.cmdDecreaseSize.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdDecreaseSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDecreaseSize.Location = New System.Drawing.Point(442, 759)
        Me.cmdDecreaseSize.Name = "cmdDecreaseSize"
        Me.cmdDecreaseSize.Size = New System.Drawing.Size(71, 40)
        Me.cmdDecreaseSize.TabIndex = 6
        Me.cmdDecreaseSize.Text = "-"
        Me.cmdDecreaseSize.UseVisualStyleBackColor = True
        '
        'cmdIncreaseSize
        '
        Me.cmdIncreaseSize.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdIncreaseSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdIncreaseSize.Location = New System.Drawing.Point(626, 759)
        Me.cmdIncreaseSize.Name = "cmdIncreaseSize"
        Me.cmdIncreaseSize.Size = New System.Drawing.Size(71, 40)
        Me.cmdIncreaseSize.TabIndex = 7
        Me.cmdIncreaseSize.Text = "+"
        Me.cmdIncreaseSize.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(519, 754)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Scale (%)"
        '
        'cboScale
        '
        Me.cboScale.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cboScale.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboScale.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboScale.FormattingEnabled = True
        Me.cboScale.Items.AddRange(New Object() {"25", "50", "75", "100", "125", "150", "175", "200"})
        Me.cboScale.Location = New System.Drawing.Point(519, 770)
        Me.cboScale.Name = "cboScale"
        Me.cboScale.Size = New System.Drawing.Size(101, 21)
        Me.cboScale.TabIndex = 9
        '
        'ViewPictureFullScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 811)
        Me.Controls.Add(Me.cboScale)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdIncreaseSize)
        Me.Controls.Add(Me.cmdDecreaseSize)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.picbxFullScreenPicture)
        Me.Controls.Add(Me.vscrlFullScreenPicture)
        Me.Controls.Add(Me.hscrlFullScreenPicture)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewPictureFullScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Blueprint Journal Picture Full Screen"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.picbxFullScreenPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents hscrlFullScreenPicture As System.Windows.Forms.HScrollBar
    Friend WithEvents vscrlFullScreenPicture As System.Windows.Forms.VScrollBar
    Friend WithEvents picbxFullScreenPicture As System.Windows.Forms.PictureBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdDecreaseSize As System.Windows.Forms.Button
    Friend WithEvents cmdIncreaseSize As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboScale As System.Windows.Forms.ComboBox
End Class
