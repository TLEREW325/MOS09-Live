<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplitCoilForm
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
        Me.components = New System.ComponentModel.Container
        Me.lblCoilID = New System.Windows.Forms.Label
        Me.lblSteelCarbon = New System.Windows.Forms.Label
        Me.lblCoilSteelSize = New System.Windows.Forms.Label
        Me.lblCoilWeight = New System.Windows.Forms.Label
        Me.txtCarbon = New System.Windows.Forms.TextBox
        Me.txtSteelSize = New System.Windows.Forms.TextBox
        Me.txtWeight = New System.Windows.Forms.TextBox
        Me.cboPieces = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdSplitCoil = New System.Windows.Forms.Button
        Me.txtPiece3 = New System.Windows.Forms.TextBox
        Me.txtPiece2 = New System.Windows.Forms.TextBox
        Me.txtPiece1 = New System.Windows.Forms.TextBox
        Me.txtPiece5 = New System.Windows.Forms.TextBox
        Me.txtPiece4 = New System.Windows.Forms.TextBox
        Me.lblPiece5 = New System.Windows.Forms.Label
        Me.lblPiece4 = New System.Windows.Forms.Label
        Me.lblPiece3 = New System.Windows.Forms.Label
        Me.lblPiece2 = New System.Windows.Forms.Label
        Me.lblPiece1 = New System.Windows.Forms.Label
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.tmrPrintLabel = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
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
        Me.txtCoilID = New System.Windows.Forms.TextBox
        Me.cmdTWD = New System.Windows.Forms.Button
        Me.bgwkLoadCoilID = New System.ComponentModel.BackgroundWorker
        Me.bgwkCoilIDSuggest = New System.ComponentModel.BackgroundWorker
        Me.lstCoilIDSuggest = New System.Windows.Forms.ListBox
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCoilID
        '
        Me.lblCoilID.AutoSize = True
        Me.lblCoilID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoilID.Location = New System.Drawing.Point(23, 55)
        Me.lblCoilID.Name = "lblCoilID"
        Me.lblCoilID.Size = New System.Drawing.Size(48, 17)
        Me.lblCoilID.TabIndex = 0
        Me.lblCoilID.Text = "Coil ID"
        '
        'lblSteelCarbon
        '
        Me.lblSteelCarbon.AutoSize = True
        Me.lblSteelCarbon.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSteelCarbon.Location = New System.Drawing.Point(23, 95)
        Me.lblSteelCarbon.Name = "lblSteelCarbon"
        Me.lblSteelCarbon.Size = New System.Drawing.Size(90, 17)
        Me.lblSteelCarbon.TabIndex = 2
        Me.lblSteelCarbon.Text = "Steel Carbon"
        '
        'lblCoilSteelSize
        '
        Me.lblCoilSteelSize.AutoSize = True
        Me.lblCoilSteelSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoilSteelSize.Location = New System.Drawing.Point(23, 135)
        Me.lblCoilSteelSize.Name = "lblCoilSteelSize"
        Me.lblCoilSteelSize.Size = New System.Drawing.Size(71, 17)
        Me.lblCoilSteelSize.TabIndex = 3
        Me.lblCoilSteelSize.Text = "Steel Size"
        '
        'lblCoilWeight
        '
        Me.lblCoilWeight.AutoSize = True
        Me.lblCoilWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoilWeight.Location = New System.Drawing.Point(23, 175)
        Me.lblCoilWeight.Name = "lblCoilWeight"
        Me.lblCoilWeight.Size = New System.Drawing.Size(79, 17)
        Me.lblCoilWeight.TabIndex = 4
        Me.lblCoilWeight.Text = "Coil Weight"
        '
        'txtCarbon
        '
        Me.txtCarbon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCarbon.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCarbon.Location = New System.Drawing.Point(115, 90)
        Me.txtCarbon.Name = "txtCarbon"
        Me.txtCarbon.ReadOnly = True
        Me.txtCarbon.Size = New System.Drawing.Size(162, 26)
        Me.txtCarbon.TabIndex = 5
        Me.txtCarbon.TabStop = False
        '
        'txtSteelSize
        '
        Me.txtSteelSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSteelSize.Location = New System.Drawing.Point(115, 130)
        Me.txtSteelSize.Name = "txtSteelSize"
        Me.txtSteelSize.ReadOnly = True
        Me.txtSteelSize.Size = New System.Drawing.Size(162, 26)
        Me.txtSteelSize.TabIndex = 6
        Me.txtSteelSize.TabStop = False
        '
        'txtWeight
        '
        Me.txtWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeight.Location = New System.Drawing.Point(115, 170)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.ReadOnly = True
        Me.txtWeight.Size = New System.Drawing.Size(162, 26)
        Me.txtWeight.TabIndex = 7
        Me.txtWeight.TabStop = False
        '
        'cboPieces
        '
        Me.cboPieces.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPieces.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPieces.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPieces.FormattingEnabled = True
        Me.cboPieces.Items.AddRange(New Object() {"2", "3", "4", "5"})
        Me.cboPieces.Location = New System.Drawing.Point(115, 210)
        Me.cboPieces.Name = "cboPieces"
        Me.cboPieces.Size = New System.Drawing.Size(162, 28)
        Me.cboPieces.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 215)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Split Pieces"
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(729, 459)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(100, 100)
        Me.cmdExit.TabIndex = 9
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdSplitCoil
        '
        Me.cmdSplitCoil.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSplitCoil.Location = New System.Drawing.Point(26, 459)
        Me.cmdSplitCoil.Name = "cmdSplitCoil"
        Me.cmdSplitCoil.Size = New System.Drawing.Size(100, 100)
        Me.cmdSplitCoil.TabIndex = 7
        Me.cmdSplitCoil.Text = "Split Coil"
        Me.cmdSplitCoil.UseVisualStyleBackColor = True
        '
        'txtPiece3
        '
        Me.txtPiece3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPiece3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPiece3.Location = New System.Drawing.Point(115, 336)
        Me.txtPiece3.Name = "txtPiece3"
        Me.txtPiece3.Size = New System.Drawing.Size(162, 26)
        Me.txtPiece3.TabIndex = 4
        '
        'txtPiece2
        '
        Me.txtPiece2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPiece2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPiece2.Location = New System.Drawing.Point(115, 296)
        Me.txtPiece2.Name = "txtPiece2"
        Me.txtPiece2.Size = New System.Drawing.Size(162, 26)
        Me.txtPiece2.TabIndex = 3
        '
        'txtPiece1
        '
        Me.txtPiece1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPiece1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPiece1.Location = New System.Drawing.Point(115, 256)
        Me.txtPiece1.Name = "txtPiece1"
        Me.txtPiece1.Size = New System.Drawing.Size(162, 26)
        Me.txtPiece1.TabIndex = 2
        '
        'txtPiece5
        '
        Me.txtPiece5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPiece5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPiece5.Location = New System.Drawing.Point(115, 416)
        Me.txtPiece5.Name = "txtPiece5"
        Me.txtPiece5.Size = New System.Drawing.Size(162, 26)
        Me.txtPiece5.TabIndex = 6
        '
        'txtPiece4
        '
        Me.txtPiece4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPiece4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPiece4.Location = New System.Drawing.Point(115, 376)
        Me.txtPiece4.Name = "txtPiece4"
        Me.txtPiece4.Size = New System.Drawing.Size(162, 26)
        Me.txtPiece4.TabIndex = 5
        '
        'lblPiece5
        '
        Me.lblPiece5.AutoSize = True
        Me.lblPiece5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPiece5.Location = New System.Drawing.Point(23, 421)
        Me.lblPiece5.Name = "lblPiece5"
        Me.lblPiece5.Size = New System.Drawing.Size(55, 17)
        Me.lblPiece5.TabIndex = 89
        Me.lblPiece5.Text = "Piece 5"
        '
        'lblPiece4
        '
        Me.lblPiece4.AutoSize = True
        Me.lblPiece4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPiece4.Location = New System.Drawing.Point(23, 381)
        Me.lblPiece4.Name = "lblPiece4"
        Me.lblPiece4.Size = New System.Drawing.Size(55, 17)
        Me.lblPiece4.TabIndex = 88
        Me.lblPiece4.Text = "Piece 4"
        '
        'lblPiece3
        '
        Me.lblPiece3.AutoSize = True
        Me.lblPiece3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPiece3.Location = New System.Drawing.Point(23, 341)
        Me.lblPiece3.Name = "lblPiece3"
        Me.lblPiece3.Size = New System.Drawing.Size(55, 17)
        Me.lblPiece3.TabIndex = 87
        Me.lblPiece3.Text = "Piece 3"
        '
        'lblPiece2
        '
        Me.lblPiece2.AutoSize = True
        Me.lblPiece2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPiece2.Location = New System.Drawing.Point(23, 301)
        Me.lblPiece2.Name = "lblPiece2"
        Me.lblPiece2.Size = New System.Drawing.Size(55, 17)
        Me.lblPiece2.TabIndex = 86
        Me.lblPiece2.Text = "Piece 2"
        '
        'lblPiece1
        '
        Me.lblPiece1.AutoSize = True
        Me.lblPiece1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPiece1.Location = New System.Drawing.Point(23, 261)
        Me.lblPiece1.Name = "lblPiece1"
        Me.lblPiece1.Size = New System.Drawing.Size(55, 17)
        Me.lblPiece1.TabIndex = 85
        Me.lblPiece1.Text = "Piece 1"
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClearAll.Location = New System.Drawing.Point(177, 459)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(100, 100)
        Me.cmdClearAll.TabIndex = 8
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'tmrPrintLabel
        '
        Me.tmrPrintLabel.Interval = 5000
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(841, 24)
        Me.MenuStrip1.TabIndex = 90
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
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
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
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(613, 143)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(100, 205)
        Me.cmdClear.TabIndex = 111
        Me.cmdClear.TabStop = False
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdEnter
        '
        Me.cmdEnter.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEnter.Location = New System.Drawing.Point(613, 354)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(100, 205)
        Me.cmdEnter.TabIndex = 110
        Me.cmdEnter.TabStop = False
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'cmdDash
        '
        Me.cmdDash.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdDash.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDash.Location = New System.Drawing.Point(613, 37)
        Me.cmdDash.Name = "cmdDash"
        Me.cmdDash.Size = New System.Drawing.Size(100, 100)
        Me.cmdDash.TabIndex = 109
        Me.cmdDash.TabStop = False
        Me.cmdDash.Text = "-"
        Me.cmdDash.UseVisualStyleBackColor = True
        '
        'cmdBackspace
        '
        Me.cmdBackspace.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdBackspace.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBackspace.Location = New System.Drawing.Point(296, 37)
        Me.cmdBackspace.Name = "cmdBackspace"
        Me.cmdBackspace.Size = New System.Drawing.Size(205, 100)
        Me.cmdBackspace.TabIndex = 108
        Me.cmdBackspace.TabStop = False
        Me.cmdBackspace.Text = "Backspace"
        Me.cmdBackspace.UseVisualStyleBackColor = True
        '
        'cmdNine
        '
        Me.cmdNine.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdNine.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNine.Location = New System.Drawing.Point(507, 143)
        Me.cmdNine.Name = "cmdNine"
        Me.cmdNine.Size = New System.Drawing.Size(100, 100)
        Me.cmdNine.TabIndex = 107
        Me.cmdNine.TabStop = False
        Me.cmdNine.Text = "9"
        Me.cmdNine.UseVisualStyleBackColor = True
        '
        'cmdEight
        '
        Me.cmdEight.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdEight.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEight.Location = New System.Drawing.Point(401, 143)
        Me.cmdEight.Name = "cmdEight"
        Me.cmdEight.Size = New System.Drawing.Size(100, 100)
        Me.cmdEight.TabIndex = 106
        Me.cmdEight.TabStop = False
        Me.cmdEight.Text = "8"
        Me.cmdEight.UseVisualStyleBackColor = True
        '
        'cmdSeven
        '
        Me.cmdSeven.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdSeven.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSeven.Location = New System.Drawing.Point(295, 143)
        Me.cmdSeven.Name = "cmdSeven"
        Me.cmdSeven.Size = New System.Drawing.Size(100, 100)
        Me.cmdSeven.TabIndex = 105
        Me.cmdSeven.TabStop = False
        Me.cmdSeven.Text = "7"
        Me.cmdSeven.UseVisualStyleBackColor = True
        '
        'cmdSix
        '
        Me.cmdSix.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdSix.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSix.Location = New System.Drawing.Point(507, 249)
        Me.cmdSix.Name = "cmdSix"
        Me.cmdSix.Size = New System.Drawing.Size(100, 100)
        Me.cmdSix.TabIndex = 104
        Me.cmdSix.TabStop = False
        Me.cmdSix.Text = "6"
        Me.cmdSix.UseVisualStyleBackColor = True
        '
        'cmdFive
        '
        Me.cmdFive.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdFive.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFive.Location = New System.Drawing.Point(401, 249)
        Me.cmdFive.Name = "cmdFive"
        Me.cmdFive.Size = New System.Drawing.Size(100, 100)
        Me.cmdFive.TabIndex = 103
        Me.cmdFive.TabStop = False
        Me.cmdFive.Text = "5"
        Me.cmdFive.UseVisualStyleBackColor = True
        '
        'cmdFour
        '
        Me.cmdFour.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdFour.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFour.Location = New System.Drawing.Point(295, 249)
        Me.cmdFour.Name = "cmdFour"
        Me.cmdFour.Size = New System.Drawing.Size(100, 100)
        Me.cmdFour.TabIndex = 102
        Me.cmdFour.TabStop = False
        Me.cmdFour.Text = "4"
        Me.cmdFour.UseVisualStyleBackColor = True
        '
        'cmdThree
        '
        Me.cmdThree.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdThree.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThree.Location = New System.Drawing.Point(507, 355)
        Me.cmdThree.Name = "cmdThree"
        Me.cmdThree.Size = New System.Drawing.Size(100, 100)
        Me.cmdThree.TabIndex = 101
        Me.cmdThree.TabStop = False
        Me.cmdThree.Text = "3"
        Me.cmdThree.UseVisualStyleBackColor = True
        '
        'cmdTwo
        '
        Me.cmdTwo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdTwo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTwo.Location = New System.Drawing.Point(400, 355)
        Me.cmdTwo.Name = "cmdTwo"
        Me.cmdTwo.Size = New System.Drawing.Size(100, 100)
        Me.cmdTwo.TabIndex = 100
        Me.cmdTwo.TabStop = False
        Me.cmdTwo.Text = "2"
        Me.cmdTwo.UseVisualStyleBackColor = True
        '
        'cmdOne
        '
        Me.cmdOne.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOne.Location = New System.Drawing.Point(295, 355)
        Me.cmdOne.Name = "cmdOne"
        Me.cmdOne.Size = New System.Drawing.Size(100, 100)
        Me.cmdOne.TabIndex = 99
        Me.cmdOne.TabStop = False
        Me.cmdOne.Text = "1"
        Me.cmdOne.UseVisualStyleBackColor = True
        '
        'cmdForwardSlash
        '
        Me.cmdForwardSlash.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdForwardSlash.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdForwardSlash.Location = New System.Drawing.Point(507, 37)
        Me.cmdForwardSlash.Name = "cmdForwardSlash"
        Me.cmdForwardSlash.Size = New System.Drawing.Size(100, 100)
        Me.cmdForwardSlash.TabIndex = 98
        Me.cmdForwardSlash.TabStop = False
        Me.cmdForwardSlash.Text = "/"
        Me.cmdForwardSlash.UseVisualStyleBackColor = True
        '
        'cmdDecimal
        '
        Me.cmdDecimal.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdDecimal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDecimal.Location = New System.Drawing.Point(507, 459)
        Me.cmdDecimal.Name = "cmdDecimal"
        Me.cmdDecimal.Size = New System.Drawing.Size(100, 100)
        Me.cmdDecimal.TabIndex = 97
        Me.cmdDecimal.TabStop = False
        Me.cmdDecimal.Text = "."
        Me.cmdDecimal.UseVisualStyleBackColor = True
        '
        'cmdZero
        '
        Me.cmdZero.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdZero.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdZero.Location = New System.Drawing.Point(296, 459)
        Me.cmdZero.Name = "cmdZero"
        Me.cmdZero.Size = New System.Drawing.Size(205, 100)
        Me.cmdZero.TabIndex = 96
        Me.cmdZero.TabStop = False
        Me.cmdZero.Text = "0"
        Me.cmdZero.UseVisualStyleBackColor = True
        '
        'txtCoilID
        '
        Me.txtCoilID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilID.Location = New System.Drawing.Point(115, 50)
        Me.txtCoilID.Name = "txtCoilID"
        Me.txtCoilID.Size = New System.Drawing.Size(162, 26)
        Me.txtCoilID.TabIndex = 0
        '
        'cmdTWD
        '
        Me.cmdTWD.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdTWD.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTWD.Location = New System.Drawing.Point(729, 195)
        Me.cmdTWD.Name = "cmdTWD"
        Me.cmdTWD.Size = New System.Drawing.Size(100, 100)
        Me.cmdTWD.TabIndex = 113
        Me.cmdTWD.TabStop = False
        Me.cmdTWD.Text = "TWD"
        Me.cmdTWD.UseVisualStyleBackColor = True
        '
        'bgwkCoilIDSuggest
        '
        '
        'lstCoilIDSuggest
        '
        Me.lstCoilIDSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCoilIDSuggest.FormattingEnabled = True
        Me.lstCoilIDSuggest.ItemHeight = 20
        Me.lstCoilIDSuggest.Location = New System.Drawing.Point(77, 76)
        Me.lstCoilIDSuggest.Name = "lstCoilIDSuggest"
        Me.lstCoilIDSuggest.Size = New System.Drawing.Size(200, 84)
        Me.lstCoilIDSuggest.TabIndex = 114
        Me.lstCoilIDSuggest.TabStop = False
        Me.lstCoilIDSuggest.Visible = False
        '
        'SplitCoilForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 571)
        Me.Controls.Add(Me.lstCoilIDSuggest)
        Me.Controls.Add(Me.cmdTWD)
        Me.Controls.Add(Me.txtCoilID)
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
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.lblPiece5)
        Me.Controls.Add(Me.lblPiece4)
        Me.Controls.Add(Me.lblPiece3)
        Me.Controls.Add(Me.lblPiece2)
        Me.Controls.Add(Me.lblPiece1)
        Me.Controls.Add(Me.txtPiece5)
        Me.Controls.Add(Me.txtPiece4)
        Me.Controls.Add(Me.txtPiece3)
        Me.Controls.Add(Me.txtPiece2)
        Me.Controls.Add(Me.txtPiece1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdSplitCoil)
        Me.Controls.Add(Me.cboPieces)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtWeight)
        Me.Controls.Add(Me.txtSteelSize)
        Me.Controls.Add(Me.txtCarbon)
        Me.Controls.Add(Me.lblCoilWeight)
        Me.Controls.Add(Me.lblCoilSteelSize)
        Me.Controls.Add(Me.lblSteelCarbon)
        Me.Controls.Add(Me.lblCoilID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "SplitCoilForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Split Coil Form"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCoilID As System.Windows.Forms.Label
    Friend WithEvents lblSteelCarbon As System.Windows.Forms.Label
    Friend WithEvents lblCoilSteelSize As System.Windows.Forms.Label
    Friend WithEvents lblCoilWeight As System.Windows.Forms.Label
    Friend WithEvents txtCarbon As System.Windows.Forms.TextBox
    Friend WithEvents txtSteelSize As System.Windows.Forms.TextBox
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents cboPieces As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdSplitCoil As System.Windows.Forms.Button
    Friend WithEvents txtPiece3 As System.Windows.Forms.TextBox
    Friend WithEvents txtPiece2 As System.Windows.Forms.TextBox
    Friend WithEvents txtPiece1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPiece5 As System.Windows.Forms.TextBox
    Friend WithEvents txtPiece4 As System.Windows.Forms.TextBox
    Friend WithEvents lblPiece5 As System.Windows.Forms.Label
    Friend WithEvents lblPiece4 As System.Windows.Forms.Label
    Friend WithEvents lblPiece3 As System.Windows.Forms.Label
    Friend WithEvents lblPiece2 As System.Windows.Forms.Label
    Friend WithEvents lblPiece1 As System.Windows.Forms.Label
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents tmrPrintLabel As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents txtCoilID As System.Windows.Forms.TextBox
    Friend WithEvents cmdTWD As System.Windows.Forms.Button
    Friend WithEvents bgwkLoadCoilID As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwkCoilIDSuggest As System.ComponentModel.BackgroundWorker
    Friend WithEvents lstCoilIDSuggest As System.Windows.Forms.ListBox

End Class
