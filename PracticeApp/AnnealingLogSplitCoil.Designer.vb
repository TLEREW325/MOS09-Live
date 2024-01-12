<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnnealingLogSplitCoil
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
        Me.cboFirstWhere = New System.Windows.Forms.ComboBox
        Me.lblFirstToWhere = New System.Windows.Forms.Label
        Me.grpPartOne = New System.Windows.Forms.GroupBox
        Me.chkFirstPrintLabel = New System.Windows.Forms.CheckBox
        Me.lblFirstWeight = New System.Windows.Forms.Label
        Me.txtFirstWeight = New System.Windows.Forms.TextBox
        Me.lblCurrentLotNumber = New System.Windows.Forms.Label
        Me.txtCurrentLotNumber = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkSecondPrintLabel = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSecondWeight = New System.Windows.Forms.TextBox
        Me.cboSecondWhere = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdSplitCoil = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.tmrWaitToPrint = New System.Windows.Forms.Timer(Me.components)
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdEnter = New System.Windows.Forms.Button
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
        Me.cmdDecimal = New System.Windows.Forms.Button
        Me.cmdZero = New System.Windows.Forms.Button
        Me.txtCurrentCoilID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.grpPartOne.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboFirstWhere
        '
        Me.cboFirstWhere.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFirstWhere.FormattingEnabled = True
        Me.cboFirstWhere.Items.AddRange(New Object() {"Current Annealing  Lot", "Header", "Yard", "Next Annealing Lot"})
        Me.cboFirstWhere.Location = New System.Drawing.Point(30, 42)
        Me.cboFirstWhere.Name = "cboFirstWhere"
        Me.cboFirstWhere.Size = New System.Drawing.Size(229, 28)
        Me.cboFirstWhere.TabIndex = 1
        '
        'lblFirstToWhere
        '
        Me.lblFirstToWhere.AutoSize = True
        Me.lblFirstToWhere.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstToWhere.Location = New System.Drawing.Point(9, 22)
        Me.lblFirstToWhere.Name = "lblFirstToWhere"
        Me.lblFirstToWhere.Size = New System.Drawing.Size(71, 17)
        Me.lblFirstToWhere.TabIndex = 1
        Me.lblFirstToWhere.Text = "To Where"
        '
        'grpPartOne
        '
        Me.grpPartOne.Controls.Add(Me.chkFirstPrintLabel)
        Me.grpPartOne.Controls.Add(Me.lblFirstWeight)
        Me.grpPartOne.Controls.Add(Me.txtFirstWeight)
        Me.grpPartOne.Controls.Add(Me.cboFirstWhere)
        Me.grpPartOne.Controls.Add(Me.lblFirstToWhere)
        Me.grpPartOne.Location = New System.Drawing.Point(12, 87)
        Me.grpPartOne.Name = "grpPartOne"
        Me.grpPartOne.Size = New System.Drawing.Size(268, 169)
        Me.grpPartOne.TabIndex = 2
        Me.grpPartOne.TabStop = False
        Me.grpPartOne.Text = "First Part"
        '
        'chkFirstPrintLabel
        '
        Me.chkFirstPrintLabel.AutoSize = True
        Me.chkFirstPrintLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFirstPrintLabel.Location = New System.Drawing.Point(75, 130)
        Me.chkFirstPrintLabel.Name = "chkFirstPrintLabel"
        Me.chkFirstPrintLabel.Size = New System.Drawing.Size(103, 24)
        Me.chkFirstPrintLabel.TabIndex = 4
        Me.chkFirstPrintLabel.Text = "Print Label"
        Me.chkFirstPrintLabel.UseVisualStyleBackColor = True
        '
        'lblFirstWeight
        '
        Me.lblFirstWeight.AutoSize = True
        Me.lblFirstWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstWeight.Location = New System.Drawing.Point(9, 91)
        Me.lblFirstWeight.Name = "lblFirstWeight"
        Me.lblFirstWeight.Size = New System.Drawing.Size(52, 17)
        Me.lblFirstWeight.TabIndex = 3
        Me.lblFirstWeight.Text = "Weight"
        '
        'txtFirstWeight
        '
        Me.txtFirstWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstWeight.Location = New System.Drawing.Point(108, 85)
        Me.txtFirstWeight.Name = "txtFirstWeight"
        Me.txtFirstWeight.Size = New System.Drawing.Size(151, 26)
        Me.txtFirstWeight.TabIndex = 0
        '
        'lblCurrentLotNumber
        '
        Me.lblCurrentLotNumber.AutoSize = True
        Me.lblCurrentLotNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentLotNumber.Location = New System.Drawing.Point(12, 15)
        Me.lblCurrentLotNumber.Name = "lblCurrentLotNumber"
        Me.lblCurrentLotNumber.Size = New System.Drawing.Size(133, 17)
        Me.lblCurrentLotNumber.TabIndex = 3
        Me.lblCurrentLotNumber.Text = "Current Lot Number"
        '
        'txtCurrentLotNumber
        '
        Me.txtCurrentLotNumber.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCurrentLotNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrentLotNumber.Location = New System.Drawing.Point(151, 15)
        Me.txtCurrentLotNumber.Name = "txtCurrentLotNumber"
        Me.txtCurrentLotNumber.ReadOnly = True
        Me.txtCurrentLotNumber.Size = New System.Drawing.Size(190, 19)
        Me.txtCurrentLotNumber.TabIndex = 4
        Me.txtCurrentLotNumber.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkSecondPrintLabel)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtSecondWeight)
        Me.GroupBox1.Controls.Add(Me.cboSecondWhere)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 262)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(268, 169)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Second Part"
        '
        'chkSecondPrintLabel
        '
        Me.chkSecondPrintLabel.AutoSize = True
        Me.chkSecondPrintLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSecondPrintLabel.Location = New System.Drawing.Point(75, 127)
        Me.chkSecondPrintLabel.Name = "chkSecondPrintLabel"
        Me.chkSecondPrintLabel.Size = New System.Drawing.Size(103, 24)
        Me.chkSecondPrintLabel.TabIndex = 4
        Me.chkSecondPrintLabel.Text = "Print Label"
        Me.chkSecondPrintLabel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Weight"
        '
        'txtSecondWeight
        '
        Me.txtSecondWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSecondWeight.Location = New System.Drawing.Point(108, 86)
        Me.txtSecondWeight.Name = "txtSecondWeight"
        Me.txtSecondWeight.Size = New System.Drawing.Size(151, 26)
        Me.txtSecondWeight.TabIndex = 2
        '
        'cboSecondWhere
        '
        Me.cboSecondWhere.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSecondWhere.FormattingEnabled = True
        Me.cboSecondWhere.Items.AddRange(New Object() {"Current Annealing  Lot", "Header", "Yard", "Next Annealing Lot"})
        Me.cboSecondWhere.Location = New System.Drawing.Point(43, 42)
        Me.cboSecondWhere.Name = "cboSecondWhere"
        Me.cboSecondWhere.Size = New System.Drawing.Size(216, 28)
        Me.cboSecondWhere.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "To Where"
        '
        'cmdSplitCoil
        '
        Me.cmdSplitCoil.Location = New System.Drawing.Point(15, 437)
        Me.cmdSplitCoil.Name = "cmdSplitCoil"
        Me.cmdSplitCoil.Size = New System.Drawing.Size(100, 100)
        Me.cmdSplitCoil.TabIndex = 76
        Me.cmdSplitCoil.Text = "Split Coil"
        Me.cmdSplitCoil.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(180, 437)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 100)
        Me.cmdCancel.TabIndex = 77
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'tmrWaitToPrint
        '
        Me.tmrWaitToPrint.Interval = 5000
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(634, 118)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(100, 205)
        Me.cmdClear.TabIndex = 93
        Me.cmdClear.TabStop = False
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdEnter
        '
        Me.cmdEnter.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEnter.Location = New System.Drawing.Point(634, 334)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(100, 205)
        Me.cmdEnter.TabIndex = 92
        Me.cmdEnter.TabStop = False
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'cmdBackspace
        '
        Me.cmdBackspace.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdBackspace.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBackspace.Location = New System.Drawing.Point(529, 12)
        Me.cmdBackspace.Name = "cmdBackspace"
        Me.cmdBackspace.Size = New System.Drawing.Size(205, 100)
        Me.cmdBackspace.TabIndex = 90
        Me.cmdBackspace.TabStop = False
        Me.cmdBackspace.Text = "Backspace"
        Me.cmdBackspace.UseVisualStyleBackColor = True
        '
        'cmdNine
        '
        Me.cmdNine.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdNine.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNine.Location = New System.Drawing.Point(528, 118)
        Me.cmdNine.Name = "cmdNine"
        Me.cmdNine.Size = New System.Drawing.Size(100, 100)
        Me.cmdNine.TabIndex = 89
        Me.cmdNine.TabStop = False
        Me.cmdNine.Text = "9"
        Me.cmdNine.UseVisualStyleBackColor = True
        '
        'cmdEight
        '
        Me.cmdEight.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdEight.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEight.Location = New System.Drawing.Point(422, 118)
        Me.cmdEight.Name = "cmdEight"
        Me.cmdEight.Size = New System.Drawing.Size(100, 100)
        Me.cmdEight.TabIndex = 88
        Me.cmdEight.TabStop = False
        Me.cmdEight.Text = "8"
        Me.cmdEight.UseVisualStyleBackColor = True
        '
        'cmdSeven
        '
        Me.cmdSeven.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdSeven.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSeven.Location = New System.Drawing.Point(316, 118)
        Me.cmdSeven.Name = "cmdSeven"
        Me.cmdSeven.Size = New System.Drawing.Size(100, 100)
        Me.cmdSeven.TabIndex = 87
        Me.cmdSeven.TabStop = False
        Me.cmdSeven.Text = "7"
        Me.cmdSeven.UseVisualStyleBackColor = True
        '
        'cmdSix
        '
        Me.cmdSix.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdSix.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSix.Location = New System.Drawing.Point(528, 224)
        Me.cmdSix.Name = "cmdSix"
        Me.cmdSix.Size = New System.Drawing.Size(100, 100)
        Me.cmdSix.TabIndex = 86
        Me.cmdSix.TabStop = False
        Me.cmdSix.Text = "6"
        Me.cmdSix.UseVisualStyleBackColor = True
        '
        'cmdFive
        '
        Me.cmdFive.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdFive.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFive.Location = New System.Drawing.Point(422, 224)
        Me.cmdFive.Name = "cmdFive"
        Me.cmdFive.Size = New System.Drawing.Size(100, 100)
        Me.cmdFive.TabIndex = 85
        Me.cmdFive.TabStop = False
        Me.cmdFive.Text = "5"
        Me.cmdFive.UseVisualStyleBackColor = True
        '
        'cmdFour
        '
        Me.cmdFour.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdFour.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFour.Location = New System.Drawing.Point(316, 224)
        Me.cmdFour.Name = "cmdFour"
        Me.cmdFour.Size = New System.Drawing.Size(100, 100)
        Me.cmdFour.TabIndex = 84
        Me.cmdFour.TabStop = False
        Me.cmdFour.Text = "4"
        Me.cmdFour.UseVisualStyleBackColor = True
        '
        'cmdThree
        '
        Me.cmdThree.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdThree.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThree.Location = New System.Drawing.Point(528, 334)
        Me.cmdThree.Name = "cmdThree"
        Me.cmdThree.Size = New System.Drawing.Size(100, 100)
        Me.cmdThree.TabIndex = 83
        Me.cmdThree.TabStop = False
        Me.cmdThree.Text = "3"
        Me.cmdThree.UseVisualStyleBackColor = True
        '
        'cmdTwo
        '
        Me.cmdTwo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdTwo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTwo.Location = New System.Drawing.Point(422, 334)
        Me.cmdTwo.Name = "cmdTwo"
        Me.cmdTwo.Size = New System.Drawing.Size(100, 100)
        Me.cmdTwo.TabIndex = 82
        Me.cmdTwo.TabStop = False
        Me.cmdTwo.Text = "2"
        Me.cmdTwo.UseVisualStyleBackColor = True
        '
        'cmdOne
        '
        Me.cmdOne.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOne.Location = New System.Drawing.Point(316, 334)
        Me.cmdOne.Name = "cmdOne"
        Me.cmdOne.Size = New System.Drawing.Size(100, 100)
        Me.cmdOne.TabIndex = 81
        Me.cmdOne.TabStop = False
        Me.cmdOne.Text = "1"
        Me.cmdOne.UseVisualStyleBackColor = True
        '
        'cmdDecimal
        '
        Me.cmdDecimal.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdDecimal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDecimal.Location = New System.Drawing.Point(528, 440)
        Me.cmdDecimal.Name = "cmdDecimal"
        Me.cmdDecimal.Size = New System.Drawing.Size(100, 100)
        Me.cmdDecimal.TabIndex = 79
        Me.cmdDecimal.TabStop = False
        Me.cmdDecimal.Text = "."
        Me.cmdDecimal.UseVisualStyleBackColor = True
        '
        'cmdZero
        '
        Me.cmdZero.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdZero.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdZero.Location = New System.Drawing.Point(316, 440)
        Me.cmdZero.Name = "cmdZero"
        Me.cmdZero.Size = New System.Drawing.Size(205, 100)
        Me.cmdZero.TabIndex = 78
        Me.cmdZero.TabStop = False
        Me.cmdZero.Text = "0"
        Me.cmdZero.UseVisualStyleBackColor = True
        '
        'txtCurrentCoilID
        '
        Me.txtCurrentCoilID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCurrentCoilID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrentCoilID.Location = New System.Drawing.Point(151, 54)
        Me.txtCurrentCoilID.Name = "txtCurrentCoilID"
        Me.txtCurrentCoilID.ReadOnly = True
        Me.txtCurrentCoilID.Size = New System.Drawing.Size(190, 19)
        Me.txtCurrentCoilID.TabIndex = 95
        Me.txtCurrentCoilID.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 17)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "Current Coil ID"
        '
        'AnnealingLogSplitCoil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 549)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtCurrentCoilID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdEnter)
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
        Me.Controls.Add(Me.cmdDecimal)
        Me.Controls.Add(Me.cmdZero)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSplitCoil)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtCurrentLotNumber)
        Me.Controls.Add(Me.lblCurrentLotNumber)
        Me.Controls.Add(Me.grpPartOne)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "AnnealingLogSplitCoil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Steel Coil Split"
        Me.grpPartOne.ResumeLayout(False)
        Me.grpPartOne.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboFirstWhere As System.Windows.Forms.ComboBox
    Friend WithEvents lblFirstToWhere As System.Windows.Forms.Label
    Friend WithEvents grpPartOne As System.Windows.Forms.GroupBox
    Friend WithEvents lblFirstWeight As System.Windows.Forms.Label
    Friend WithEvents txtFirstWeight As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrentLotNumber As System.Windows.Forms.Label
    Friend WithEvents txtCurrentLotNumber As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSecondWeight As System.Windows.Forms.TextBox
    Friend WithEvents cboSecondWhere As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdSplitCoil As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents tmrWaitToPrint As System.Windows.Forms.Timer
    Friend WithEvents chkFirstPrintLabel As System.Windows.Forms.CheckBox
    Friend WithEvents chkSecondPrintLabel As System.Windows.Forms.CheckBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
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
    Friend WithEvents cmdDecimal As System.Windows.Forms.Button
    Friend WithEvents cmdZero As System.Windows.Forms.Button
    Friend WithEvents txtCurrentCoilID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
