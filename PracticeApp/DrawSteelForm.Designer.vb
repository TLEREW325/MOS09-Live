<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DrawSteelForm
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
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.lblCoilID = New System.Windows.Forms.Label
        Me.lblCarbon = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCoilCarbon = New System.Windows.Forms.TextBox
        Me.txtCoilSteelSize = New System.Windows.Forms.TextBox
        Me.cboNewSteelSize = New System.Windows.Forms.ComboBox
        Me.cmdPostSizeChange = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdEnter = New System.Windows.Forms.Button
        Me.cmdDash = New System.Windows.Forms.Button
        Me.cmdBackspace = New System.Windows.Forms.Button
        Me.cmdNine = New System.Windows.Forms.Button
        Me.cmdEight = New System.Windows.Forms.Button
        Me.cmdSeven = New System.Windows.Forms.Button
        Me.cmdSix = New System.Windows.Forms.Button
        Me.cmdFive = New System.Windows.Forms.Button
        Me.cmdFour = New System.Windows.Forms.Button
        Me.cmdThree = New System.Windows.Forms.Button
        Me.cmdTwo = New System.Windows.Forms.Button
        Me.cmdOne = New System.Windows.Forms.Button
        Me.cmdForwardSlash = New System.Windows.Forms.Button
        Me.cmdDecimal = New System.Windows.Forms.Button
        Me.cmdZero = New System.Windows.Forms.Button
        Me.cmdTWD = New System.Windows.Forms.Button
        Me.lstSizeSuggest = New System.Windows.Forms.ListBox
        Me.lstCoilIDSuggest = New System.Windows.Forms.ListBox
        Me.txtCoilID = New System.Windows.Forms.TextBox
        Me.bgwkLoadCoilID = New System.ComponentModel.BackgroundWorker
        Me.bgwkCoilIDSuggest = New System.ComponentModel.BackgroundWorker
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(774, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
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
        'lblCoilID
        '
        Me.lblCoilID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoilID.Location = New System.Drawing.Point(12, 60)
        Me.lblCoilID.Name = "lblCoilID"
        Me.lblCoilID.Size = New System.Drawing.Size(76, 20)
        Me.lblCoilID.TabIndex = 74
        Me.lblCoilID.Text = "Coil ID"
        Me.lblCoilID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCarbon
        '
        Me.lblCarbon.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarbon.Location = New System.Drawing.Point(12, 119)
        Me.lblCarbon.Name = "lblCarbon"
        Me.lblCarbon.Size = New System.Drawing.Size(85, 20)
        Me.lblCarbon.TabIndex = 75
        Me.lblCarbon.Text = "Coil Carbon"
        Me.lblCarbon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 173)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Coil Steel Size"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 225)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 20)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "New Steel Size"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCoilCarbon
        '
        Me.txtCoilCarbon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilCarbon.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilCarbon.Location = New System.Drawing.Point(115, 116)
        Me.txtCoilCarbon.Name = "txtCoilCarbon"
        Me.txtCoilCarbon.ReadOnly = True
        Me.txtCoilCarbon.Size = New System.Drawing.Size(188, 26)
        Me.txtCoilCarbon.TabIndex = 78
        Me.txtCoilCarbon.TabStop = False
        '
        'txtCoilSteelSize
        '
        Me.txtCoilSteelSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilSteelSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilSteelSize.Location = New System.Drawing.Point(115, 170)
        Me.txtCoilSteelSize.Name = "txtCoilSteelSize"
        Me.txtCoilSteelSize.ReadOnly = True
        Me.txtCoilSteelSize.Size = New System.Drawing.Size(188, 26)
        Me.txtCoilSteelSize.TabIndex = 79
        Me.txtCoilSteelSize.TabStop = False
        '
        'cboNewSteelSize
        '
        Me.cboNewSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboNewSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboNewSteelSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNewSteelSize.FormattingEnabled = True
        Me.cboNewSteelSize.Location = New System.Drawing.Point(115, 221)
        Me.cboNewSteelSize.Name = "cboNewSteelSize"
        Me.cboNewSteelSize.Size = New System.Drawing.Size(188, 28)
        Me.cboNewSteelSize.TabIndex = 1
        '
        'cmdPostSizeChange
        '
        Me.cmdPostSizeChange.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPostSizeChange.ForeColor = System.Drawing.Color.Blue
        Me.cmdPostSizeChange.Location = New System.Drawing.Point(22, 266)
        Me.cmdPostSizeChange.Name = "cmdPostSizeChange"
        Me.cmdPostSizeChange.Size = New System.Drawing.Size(100, 100)
        Me.cmdPostSizeChange.TabIndex = 2
        Me.cmdPostSizeChange.Text = "Post Size Change"
        Me.cmdPostSizeChange.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(203, 449)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(100, 100)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClearAll.Location = New System.Drawing.Point(22, 449)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(100, 100)
        Me.cmdClearAll.TabIndex = 3
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(662, 133)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(100, 205)
        Me.cmdClear.TabIndex = 95
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdEnter
        '
        Me.cmdEnter.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEnter.Location = New System.Drawing.Point(662, 344)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(100, 205)
        Me.cmdEnter.TabIndex = 94
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'cmdDash
        '
        Me.cmdDash.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdDash.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDash.Location = New System.Drawing.Point(662, 27)
        Me.cmdDash.Name = "cmdDash"
        Me.cmdDash.Size = New System.Drawing.Size(100, 100)
        Me.cmdDash.TabIndex = 93
        Me.cmdDash.Text = "-"
        Me.cmdDash.UseVisualStyleBackColor = True
        '
        'cmdBackspace
        '
        Me.cmdBackspace.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdBackspace.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBackspace.Location = New System.Drawing.Point(344, 29)
        Me.cmdBackspace.Name = "cmdBackspace"
        Me.cmdBackspace.Size = New System.Drawing.Size(205, 100)
        Me.cmdBackspace.TabIndex = 92
        Me.cmdBackspace.Text = "Backspace"
        Me.cmdBackspace.UseVisualStyleBackColor = True
        '
        'cmdNine
        '
        Me.cmdNine.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdNine.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNine.Location = New System.Drawing.Point(556, 133)
        Me.cmdNine.Name = "cmdNine"
        Me.cmdNine.Size = New System.Drawing.Size(100, 100)
        Me.cmdNine.TabIndex = 91
        Me.cmdNine.Text = "9"
        Me.cmdNine.UseVisualStyleBackColor = True
        '
        'cmdEight
        '
        Me.cmdEight.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdEight.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEight.Location = New System.Drawing.Point(450, 133)
        Me.cmdEight.Name = "cmdEight"
        Me.cmdEight.Size = New System.Drawing.Size(100, 100)
        Me.cmdEight.TabIndex = 90
        Me.cmdEight.Text = "8"
        Me.cmdEight.UseVisualStyleBackColor = True
        '
        'cmdSeven
        '
        Me.cmdSeven.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdSeven.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSeven.Location = New System.Drawing.Point(344, 133)
        Me.cmdSeven.Name = "cmdSeven"
        Me.cmdSeven.Size = New System.Drawing.Size(100, 100)
        Me.cmdSeven.TabIndex = 89
        Me.cmdSeven.Text = "7"
        Me.cmdSeven.UseVisualStyleBackColor = True
        '
        'cmdSix
        '
        Me.cmdSix.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdSix.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSix.Location = New System.Drawing.Point(556, 239)
        Me.cmdSix.Name = "cmdSix"
        Me.cmdSix.Size = New System.Drawing.Size(100, 100)
        Me.cmdSix.TabIndex = 88
        Me.cmdSix.Text = "6"
        Me.cmdSix.UseVisualStyleBackColor = True
        '
        'cmdFive
        '
        Me.cmdFive.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdFive.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFive.Location = New System.Drawing.Point(450, 239)
        Me.cmdFive.Name = "cmdFive"
        Me.cmdFive.Size = New System.Drawing.Size(100, 100)
        Me.cmdFive.TabIndex = 87
        Me.cmdFive.Text = "5"
        Me.cmdFive.UseVisualStyleBackColor = True
        '
        'cmdFour
        '
        Me.cmdFour.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdFour.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFour.Location = New System.Drawing.Point(344, 239)
        Me.cmdFour.Name = "cmdFour"
        Me.cmdFour.Size = New System.Drawing.Size(100, 100)
        Me.cmdFour.TabIndex = 86
        Me.cmdFour.Text = "4"
        Me.cmdFour.UseVisualStyleBackColor = True
        '
        'cmdThree
        '
        Me.cmdThree.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdThree.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThree.Location = New System.Drawing.Point(556, 345)
        Me.cmdThree.Name = "cmdThree"
        Me.cmdThree.Size = New System.Drawing.Size(100, 100)
        Me.cmdThree.TabIndex = 85
        Me.cmdThree.Text = "3"
        Me.cmdThree.UseVisualStyleBackColor = True
        '
        'cmdTwo
        '
        Me.cmdTwo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdTwo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTwo.Location = New System.Drawing.Point(449, 345)
        Me.cmdTwo.Name = "cmdTwo"
        Me.cmdTwo.Size = New System.Drawing.Size(100, 100)
        Me.cmdTwo.TabIndex = 84
        Me.cmdTwo.Text = "2"
        Me.cmdTwo.UseVisualStyleBackColor = True
        '
        'cmdOne
        '
        Me.cmdOne.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOne.Location = New System.Drawing.Point(344, 345)
        Me.cmdOne.Name = "cmdOne"
        Me.cmdOne.Size = New System.Drawing.Size(100, 100)
        Me.cmdOne.TabIndex = 83
        Me.cmdOne.Text = "1"
        Me.cmdOne.UseVisualStyleBackColor = True
        '
        'cmdForwardSlash
        '
        Me.cmdForwardSlash.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdForwardSlash.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdForwardSlash.Location = New System.Drawing.Point(556, 27)
        Me.cmdForwardSlash.Name = "cmdForwardSlash"
        Me.cmdForwardSlash.Size = New System.Drawing.Size(100, 100)
        Me.cmdForwardSlash.TabIndex = 82
        Me.cmdForwardSlash.Text = "/"
        Me.cmdForwardSlash.UseVisualStyleBackColor = True
        '
        'cmdDecimal
        '
        Me.cmdDecimal.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdDecimal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDecimal.Location = New System.Drawing.Point(556, 449)
        Me.cmdDecimal.Name = "cmdDecimal"
        Me.cmdDecimal.Size = New System.Drawing.Size(100, 100)
        Me.cmdDecimal.TabIndex = 81
        Me.cmdDecimal.Text = "."
        Me.cmdDecimal.UseVisualStyleBackColor = True
        '
        'cmdZero
        '
        Me.cmdZero.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdZero.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdZero.Location = New System.Drawing.Point(345, 449)
        Me.cmdZero.Name = "cmdZero"
        Me.cmdZero.Size = New System.Drawing.Size(205, 100)
        Me.cmdZero.TabIndex = 80
        Me.cmdZero.Text = "0"
        Me.cmdZero.UseVisualStyleBackColor = True
        '
        'cmdTWD
        '
        Me.cmdTWD.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdTWD.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTWD.Location = New System.Drawing.Point(203, 266)
        Me.cmdTWD.Name = "cmdTWD"
        Me.cmdTWD.Size = New System.Drawing.Size(100, 100)
        Me.cmdTWD.TabIndex = 96
        Me.cmdTWD.Text = "TWD"
        Me.cmdTWD.UseVisualStyleBackColor = True
        '
        'lstSizeSuggest
        '
        Me.lstSizeSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSizeSuggest.FormattingEnabled = True
        Me.lstSizeSuggest.ItemHeight = 20
        Me.lstSizeSuggest.Location = New System.Drawing.Point(143, 249)
        Me.lstSizeSuggest.Name = "lstSizeSuggest"
        Me.lstSizeSuggest.Size = New System.Drawing.Size(160, 84)
        Me.lstSizeSuggest.TabIndex = 98
        Me.lstSizeSuggest.TabStop = False
        Me.lstSizeSuggest.Visible = False
        '
        'lstCoilIDSuggest
        '
        Me.lstCoilIDSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCoilIDSuggest.FormattingEnabled = True
        Me.lstCoilIDSuggest.ItemHeight = 20
        Me.lstCoilIDSuggest.Location = New System.Drawing.Point(103, 83)
        Me.lstCoilIDSuggest.Name = "lstCoilIDSuggest"
        Me.lstCoilIDSuggest.Size = New System.Drawing.Size(200, 84)
        Me.lstCoilIDSuggest.TabIndex = 97
        Me.lstCoilIDSuggest.TabStop = False
        Me.lstCoilIDSuggest.Visible = False
        '
        'txtCoilID
        '
        Me.txtCoilID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilID.Location = New System.Drawing.Point(115, 57)
        Me.txtCoilID.Name = "txtCoilID"
        Me.txtCoilID.Size = New System.Drawing.Size(188, 26)
        Me.txtCoilID.TabIndex = 0
        '
        'bgwkLoadCoilID
        '
        '
        'bgwkCoilIDSuggest
        '
        Me.bgwkCoilIDSuggest.WorkerSupportsCancellation = True
        '
        'DrawSteelForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 571)
        Me.Controls.Add(Me.txtCoilID)
        Me.Controls.Add(Me.lstSizeSuggest)
        Me.Controls.Add(Me.lstCoilIDSuggest)
        Me.Controls.Add(Me.cmdTWD)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdEnter)
        Me.Controls.Add(Me.cmdDash)
        Me.Controls.Add(Me.cmdBackspace)
        Me.Controls.Add(Me.cmdNine)
        Me.Controls.Add(Me.cmdEight)
        Me.Controls.Add(Me.cmdSeven)
        Me.Controls.Add(Me.cmdSix)
        Me.Controls.Add(Me.cmdFive)
        Me.Controls.Add(Me.cmdFour)
        Me.Controls.Add(Me.cmdThree)
        Me.Controls.Add(Me.cmdTwo)
        Me.Controls.Add(Me.cmdOne)
        Me.Controls.Add(Me.cmdForwardSlash)
        Me.Controls.Add(Me.cmdDecimal)
        Me.Controls.Add(Me.cmdZero)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdPostSizeChange)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cboNewSteelSize)
        Me.Controls.Add(Me.txtCoilSteelSize)
        Me.Controls.Add(Me.txtCoilCarbon)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblCarbon)
        Me.Controls.Add(Me.lblCoilID)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "DrawSteelForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Draw Steel Form"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblCoilID As System.Windows.Forms.Label
    Friend WithEvents lblCarbon As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCoilCarbon As System.Windows.Forms.TextBox
    Friend WithEvents txtCoilSteelSize As System.Windows.Forms.TextBox
    Friend WithEvents cboNewSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents cmdPostSizeChange As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents cmdDash As System.Windows.Forms.Button
    Friend WithEvents cmdBackspace As System.Windows.Forms.Button
    Friend WithEvents cmdNine As System.Windows.Forms.Button
    Friend WithEvents cmdEight As System.Windows.Forms.Button
    Friend WithEvents cmdSeven As System.Windows.Forms.Button
    Friend WithEvents cmdSix As System.Windows.Forms.Button
    Friend WithEvents cmdFive As System.Windows.Forms.Button
    Friend WithEvents cmdFour As System.Windows.Forms.Button
    Friend WithEvents cmdThree As System.Windows.Forms.Button
    Friend WithEvents cmdTwo As System.Windows.Forms.Button
    Friend WithEvents cmdOne As System.Windows.Forms.Button
    Friend WithEvents cmdForwardSlash As System.Windows.Forms.Button
    Friend WithEvents cmdDecimal As System.Windows.Forms.Button
    Friend WithEvents cmdZero As System.Windows.Forms.Button
    Friend WithEvents cmdTWD As System.Windows.Forms.Button
    Friend WithEvents lstSizeSuggest As System.Windows.Forms.ListBox
    Friend WithEvents lstCoilIDSuggest As System.Windows.Forms.ListBox
    Friend WithEvents txtCoilID As System.Windows.Forms.TextBox
    Friend WithEvents bgwkLoadCoilID As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwkCoilIDSuggest As System.ComponentModel.BackgroundWorker

End Class
