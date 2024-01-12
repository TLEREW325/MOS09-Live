<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateCurrentAnnouncements
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxMessageOne = New System.Windows.Forms.GroupBox
        Me.cndClear1 = New System.Windows.Forms.Button
        Me.cmdAdd1 = New System.Windows.Forms.Button
        Me.gpxMessageThree = New System.Windows.Forms.GroupBox
        Me.cmdClear3 = New System.Windows.Forms.Button
        Me.cmdAdd3 = New System.Windows.Forms.Button
        Me.gpxMessageFour = New System.Windows.Forms.GroupBox
        Me.cmdClear4 = New System.Windows.Forms.Button
        Me.cmdAdd4 = New System.Windows.Forms.Button
        Me.gpxMessageTwo = New System.Windows.Forms.GroupBox
        Me.cmdClear2 = New System.Windows.Forms.Button
        Me.cmdAdd2 = New System.Windows.Forms.Button
        Me.cmdDeleteAll = New System.Windows.Forms.Button
        Me.cmdSaveAll = New System.Windows.Forms.Button
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.txtMessage3 = New System.Windows.Forms.TextBox
        Me.txtMessage2 = New System.Windows.Forms.TextBox
        Me.txtMessage1 = New System.Windows.Forms.TextBox
        Me.txtMessage4 = New System.Windows.Forms.TextBox
        Me.MenuStrip1.SuspendLayout()
        Me.gpxMessageOne.SuspendLayout()
        Me.gpxMessageThree.SuspendLayout()
        Me.gpxMessageFour.SuspendLayout()
        Me.gpxMessageTwo.SuspendLayout()
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
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(459, 371)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 15
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxMessageOne
        '
        Me.gpxMessageOne.Controls.Add(Me.txtMessage1)
        Me.gpxMessageOne.Controls.Add(Me.cndClear1)
        Me.gpxMessageOne.Controls.Add(Me.cmdAdd1)
        Me.gpxMessageOne.Location = New System.Drawing.Point(10, 39)
        Me.gpxMessageOne.Name = "gpxMessageOne"
        Me.gpxMessageOne.Size = New System.Drawing.Size(520, 75)
        Me.gpxMessageOne.TabIndex = 0
        Me.gpxMessageOne.TabStop = False
        Me.gpxMessageOne.Text = "Message #1"
        '
        'cndClear1
        '
        Me.cndClear1.Location = New System.Drawing.Point(449, 40)
        Me.cndClear1.Name = "cndClear1"
        Me.cndClear1.Size = New System.Drawing.Size(53, 25)
        Me.cndClear1.TabIndex = 2
        Me.cndClear1.Text = "Clear"
        Me.cndClear1.UseVisualStyleBackColor = True
        '
        'cmdAdd1
        '
        Me.cmdAdd1.Location = New System.Drawing.Point(449, 13)
        Me.cmdAdd1.Name = "cmdAdd1"
        Me.cmdAdd1.Size = New System.Drawing.Size(53, 25)
        Me.cmdAdd1.TabIndex = 1
        Me.cmdAdd1.Text = "Add"
        Me.cmdAdd1.UseVisualStyleBackColor = True
        '
        'gpxMessageThree
        '
        Me.gpxMessageThree.Controls.Add(Me.txtMessage3)
        Me.gpxMessageThree.Controls.Add(Me.cmdClear3)
        Me.gpxMessageThree.Controls.Add(Me.cmdAdd3)
        Me.gpxMessageThree.Location = New System.Drawing.Point(10, 205)
        Me.gpxMessageThree.Name = "gpxMessageThree"
        Me.gpxMessageThree.Size = New System.Drawing.Size(520, 75)
        Me.gpxMessageThree.TabIndex = 6
        Me.gpxMessageThree.TabStop = False
        Me.gpxMessageThree.Text = "Message #3"
        '
        'cmdClear3
        '
        Me.cmdClear3.Location = New System.Drawing.Point(449, 40)
        Me.cmdClear3.Name = "cmdClear3"
        Me.cmdClear3.Size = New System.Drawing.Size(53, 25)
        Me.cmdClear3.TabIndex = 8
        Me.cmdClear3.Text = "Clear"
        Me.cmdClear3.UseVisualStyleBackColor = True
        '
        'cmdAdd3
        '
        Me.cmdAdd3.Location = New System.Drawing.Point(449, 13)
        Me.cmdAdd3.Name = "cmdAdd3"
        Me.cmdAdd3.Size = New System.Drawing.Size(53, 25)
        Me.cmdAdd3.TabIndex = 7
        Me.cmdAdd3.Text = "Add"
        Me.cmdAdd3.UseVisualStyleBackColor = True
        '
        'gpxMessageFour
        '
        Me.gpxMessageFour.Controls.Add(Me.txtMessage4)
        Me.gpxMessageFour.Controls.Add(Me.cmdClear4)
        Me.gpxMessageFour.Controls.Add(Me.cmdAdd4)
        Me.gpxMessageFour.Location = New System.Drawing.Point(10, 288)
        Me.gpxMessageFour.Name = "gpxMessageFour"
        Me.gpxMessageFour.Size = New System.Drawing.Size(520, 75)
        Me.gpxMessageFour.TabIndex = 9
        Me.gpxMessageFour.TabStop = False
        Me.gpxMessageFour.Text = "Message #4"
        '
        'cmdClear4
        '
        Me.cmdClear4.Location = New System.Drawing.Point(449, 40)
        Me.cmdClear4.Name = "cmdClear4"
        Me.cmdClear4.Size = New System.Drawing.Size(53, 25)
        Me.cmdClear4.TabIndex = 11
        Me.cmdClear4.Text = "Clear"
        Me.cmdClear4.UseVisualStyleBackColor = True
        '
        'cmdAdd4
        '
        Me.cmdAdd4.Location = New System.Drawing.Point(449, 13)
        Me.cmdAdd4.Name = "cmdAdd4"
        Me.cmdAdd4.Size = New System.Drawing.Size(53, 25)
        Me.cmdAdd4.TabIndex = 10
        Me.cmdAdd4.Text = "Add"
        Me.cmdAdd4.UseVisualStyleBackColor = True
        '
        'gpxMessageTwo
        '
        Me.gpxMessageTwo.Controls.Add(Me.txtMessage2)
        Me.gpxMessageTwo.Controls.Add(Me.cmdClear2)
        Me.gpxMessageTwo.Controls.Add(Me.cmdAdd2)
        Me.gpxMessageTwo.Location = New System.Drawing.Point(10, 122)
        Me.gpxMessageTwo.Name = "gpxMessageTwo"
        Me.gpxMessageTwo.Size = New System.Drawing.Size(520, 75)
        Me.gpxMessageTwo.TabIndex = 3
        Me.gpxMessageTwo.TabStop = False
        Me.gpxMessageTwo.Text = "Message #2"
        '
        'cmdClear2
        '
        Me.cmdClear2.Location = New System.Drawing.Point(449, 40)
        Me.cmdClear2.Name = "cmdClear2"
        Me.cmdClear2.Size = New System.Drawing.Size(53, 25)
        Me.cmdClear2.TabIndex = 5
        Me.cmdClear2.Text = "Clear"
        Me.cmdClear2.UseVisualStyleBackColor = True
        '
        'cmdAdd2
        '
        Me.cmdAdd2.Location = New System.Drawing.Point(449, 13)
        Me.cmdAdd2.Name = "cmdAdd2"
        Me.cmdAdd2.Size = New System.Drawing.Size(53, 25)
        Me.cmdAdd2.TabIndex = 4
        Me.cmdAdd2.Text = "Add"
        Me.cmdAdd2.UseVisualStyleBackColor = True
        '
        'cmdDeleteAll
        '
        Me.cmdDeleteAll.Location = New System.Drawing.Point(382, 371)
        Me.cmdDeleteAll.Name = "cmdDeleteAll"
        Me.cmdDeleteAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteAll.TabIndex = 14
        Me.cmdDeleteAll.Text = "Delete All"
        Me.cmdDeleteAll.UseVisualStyleBackColor = True
        '
        'cmdSaveAll
        '
        Me.cmdSaveAll.Location = New System.Drawing.Point(228, 371)
        Me.cmdSaveAll.Name = "cmdSaveAll"
        Me.cmdSaveAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdSaveAll.TabIndex = 12
        Me.cmdSaveAll.Text = "Save All"
        Me.cmdSaveAll.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Location = New System.Drawing.Point(305, 371)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 13
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'txtMessage3
        '
        Me.txtMessage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessage3.Location = New System.Drawing.Point(21, 19)
        Me.txtMessage3.Multiline = True
        Me.txtMessage3.Name = "txtMessage3"
        Me.txtMessage3.Size = New System.Drawing.Size(411, 46)
        Me.txtMessage3.TabIndex = 6
        '
        'txtMessage2
        '
        Me.txtMessage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessage2.Location = New System.Drawing.Point(21, 19)
        Me.txtMessage2.Multiline = True
        Me.txtMessage2.Name = "txtMessage2"
        Me.txtMessage2.Size = New System.Drawing.Size(411, 46)
        Me.txtMessage2.TabIndex = 3
        '
        'txtMessage1
        '
        Me.txtMessage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessage1.Location = New System.Drawing.Point(21, 19)
        Me.txtMessage1.Multiline = True
        Me.txtMessage1.Name = "txtMessage1"
        Me.txtMessage1.Size = New System.Drawing.Size(411, 46)
        Me.txtMessage1.TabIndex = 0
        '
        'txtMessage4
        '
        Me.txtMessage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessage4.Location = New System.Drawing.Point(21, 17)
        Me.txtMessage4.Multiline = True
        Me.txtMessage4.Name = "txtMessage4"
        Me.txtMessage4.Size = New System.Drawing.Size(411, 46)
        Me.txtMessage4.TabIndex = 9
        '
        'CreateCurrentAnnouncements
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 423)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdSaveAll)
        Me.Controls.Add(Me.cmdDeleteAll)
        Me.Controls.Add(Me.gpxMessageTwo)
        Me.Controls.Add(Me.gpxMessageFour)
        Me.Controls.Add(Me.gpxMessageThree)
        Me.Controls.Add(Me.gpxMessageOne)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "CreateCurrentAnnouncements"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Global Announcements"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxMessageOne.ResumeLayout(False)
        Me.gpxMessageOne.PerformLayout()
        Me.gpxMessageThree.ResumeLayout(False)
        Me.gpxMessageThree.PerformLayout()
        Me.gpxMessageFour.ResumeLayout(False)
        Me.gpxMessageFour.PerformLayout()
        Me.gpxMessageTwo.ResumeLayout(False)
        Me.gpxMessageTwo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxMessageOne As System.Windows.Forms.GroupBox
    Friend WithEvents gpxMessageThree As System.Windows.Forms.GroupBox
    Friend WithEvents gpxMessageFour As System.Windows.Forms.GroupBox
    Friend WithEvents gpxMessageTwo As System.Windows.Forms.GroupBox
    Friend WithEvents cndClear1 As System.Windows.Forms.Button
    Friend WithEvents cmdAdd1 As System.Windows.Forms.Button
    Friend WithEvents cmdClear3 As System.Windows.Forms.Button
    Friend WithEvents cmdAdd3 As System.Windows.Forms.Button
    Friend WithEvents cmdClear4 As System.Windows.Forms.Button
    Friend WithEvents cmdAdd4 As System.Windows.Forms.Button
    Friend WithEvents cmdClear2 As System.Windows.Forms.Button
    Friend WithEvents cmdAdd2 As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteAll As System.Windows.Forms.Button
    Friend WithEvents cmdSaveAll As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents txtMessage1 As System.Windows.Forms.TextBox
    Friend WithEvents txtMessage3 As System.Windows.Forms.TextBox
    Friend WithEvents txtMessage4 As System.Windows.Forms.TextBox
    Friend WithEvents txtMessage2 As System.Windows.Forms.TextBox
End Class
