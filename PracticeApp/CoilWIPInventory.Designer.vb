<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CoilWIPInventory
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtWeight = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboCoilID = New System.Windows.Forms.ComboBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvWIPCoils = New System.Windows.Forms.DataGridView
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.gpxKeyboard = New System.Windows.Forms.GroupBox
        Me.cmdDash = New System.Windows.Forms.Button
        Me.cmdBackspace = New System.Windows.Forms.Button
        Me.cmdClearSelected = New System.Windows.Forms.Button
        Me.cmdNine = New System.Windows.Forms.Button
        Me.cmdEight = New System.Windows.Forms.Button
        Me.cmdSeven = New System.Windows.Forms.Button
        Me.cmdSix = New System.Windows.Forms.Button
        Me.cmdFive = New System.Windows.Forms.Button
        Me.cmdFour = New System.Windows.Forms.Button
        Me.cmdKeyboardEnter = New System.Windows.Forms.Button
        Me.cmdThree = New System.Windows.Forms.Button
        Me.cmdTwo = New System.Windows.Forms.Button
        Me.cmdOne = New System.Windows.Forms.Button
        Me.cmdZero = New System.Windows.Forms.Button
        Me.cmdSpace = New System.Windows.Forms.Button
        Me.cmdM = New System.Windows.Forms.Button
        Me.cmdN = New System.Windows.Forms.Button
        Me.cmdB = New System.Windows.Forms.Button
        Me.cmdV = New System.Windows.Forms.Button
        Me.cmdC = New System.Windows.Forms.Button
        Me.cmdX = New System.Windows.Forms.Button
        Me.cmdL = New System.Windows.Forms.Button
        Me.cmdK = New System.Windows.Forms.Button
        Me.cmdJ = New System.Windows.Forms.Button
        Me.cmdH = New System.Windows.Forms.Button
        Me.cmdG = New System.Windows.Forms.Button
        Me.cmdF = New System.Windows.Forms.Button
        Me.cmdD = New System.Windows.Forms.Button
        Me.cmdS = New System.Windows.Forms.Button
        Me.cmdZ = New System.Windows.Forms.Button
        Me.cmdP = New System.Windows.Forms.Button
        Me.cmdO = New System.Windows.Forms.Button
        Me.cmdI = New System.Windows.Forms.Button
        Me.cmdU = New System.Windows.Forms.Button
        Me.cmdY = New System.Windows.Forms.Button
        Me.cmdT = New System.Windows.Forms.Button
        Me.cmdR = New System.Windows.Forms.Button
        Me.cmdE = New System.Windows.Forms.Button
        Me.cmdW = New System.Windows.Forms.Button
        Me.cmdQ = New System.Windows.Forms.Button
        Me.cmdA = New System.Windows.Forms.Button
        Me.lstCoilSuggest = New System.Windows.Forms.ListBox
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.cmdForwardSlash = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvWIPCoils, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxKeyboard.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboSteelSize)
        Me.GroupBox1.Controls.Add(Me.cboCarbon)
        Me.GroupBox1.Controls.Add(Me.cmdAdd)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtWeight)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboCoilID)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(284, 262)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Coil"
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(118, 203)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(71, 40)
        Me.cmdAdd.TabIndex = 2
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(195, 203)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 3
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Weight"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Size"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Carbon"
        '
        'txtWeight
        '
        Me.txtWeight.Location = New System.Drawing.Point(166, 151)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(100, 20)
        Me.txtWeight.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Coil ID"
        '
        'cboCoilID
        '
        Me.cboCoilID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCoilID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCoilID.FormattingEnabled = True
        Me.cboCoilID.Location = New System.Drawing.Point(108, 43)
        Me.cboCoilID.Name = "cboCoilID"
        Me.cboCoilID.Size = New System.Drawing.Size(158, 21)
        Me.cboCoilID.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1034, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteAllToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'DeleteAllToolStripMenuItem
        '
        Me.DeleteAllToolStripMenuItem.Name = "DeleteAllToolStripMenuItem"
        Me.DeleteAllToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.DeleteAllToolStripMenuItem.Text = "Delete All"
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
        'dgvWIPCoils
        '
        Me.dgvWIPCoils.AllowUserToAddRows = False
        Me.dgvWIPCoils.AllowUserToDeleteRows = False
        Me.dgvWIPCoils.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvWIPCoils.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWIPCoils.Location = New System.Drawing.Point(302, 43)
        Me.dgvWIPCoils.Name = "dgvWIPCoils"
        Me.dgvWIPCoils.ReadOnly = True
        Me.dgvWIPCoils.Size = New System.Drawing.Size(720, 609)
        Me.dgvWIPCoils.TabIndex = 2
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(951, 659)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 10
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(743, 659)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 11
        Me.cmdDelete.Text = "Delete Selected"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(851, 659)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 12
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'gpxKeyboard
        '
        Me.gpxKeyboard.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gpxKeyboard.Controls.Add(Me.cmdForwardSlash)
        Me.gpxKeyboard.Controls.Add(Me.cmdDash)
        Me.gpxKeyboard.Controls.Add(Me.cmdBackspace)
        Me.gpxKeyboard.Controls.Add(Me.cmdClearSelected)
        Me.gpxKeyboard.Controls.Add(Me.cmdNine)
        Me.gpxKeyboard.Controls.Add(Me.cmdEight)
        Me.gpxKeyboard.Controls.Add(Me.cmdSeven)
        Me.gpxKeyboard.Controls.Add(Me.cmdSix)
        Me.gpxKeyboard.Controls.Add(Me.cmdFive)
        Me.gpxKeyboard.Controls.Add(Me.cmdFour)
        Me.gpxKeyboard.Controls.Add(Me.cmdKeyboardEnter)
        Me.gpxKeyboard.Controls.Add(Me.cmdThree)
        Me.gpxKeyboard.Controls.Add(Me.cmdTwo)
        Me.gpxKeyboard.Controls.Add(Me.cmdOne)
        Me.gpxKeyboard.Controls.Add(Me.cmdZero)
        Me.gpxKeyboard.Controls.Add(Me.cmdSpace)
        Me.gpxKeyboard.Controls.Add(Me.cmdM)
        Me.gpxKeyboard.Controls.Add(Me.cmdN)
        Me.gpxKeyboard.Controls.Add(Me.cmdB)
        Me.gpxKeyboard.Controls.Add(Me.cmdV)
        Me.gpxKeyboard.Controls.Add(Me.cmdC)
        Me.gpxKeyboard.Controls.Add(Me.cmdX)
        Me.gpxKeyboard.Controls.Add(Me.cmdL)
        Me.gpxKeyboard.Controls.Add(Me.cmdK)
        Me.gpxKeyboard.Controls.Add(Me.cmdJ)
        Me.gpxKeyboard.Controls.Add(Me.cmdH)
        Me.gpxKeyboard.Controls.Add(Me.cmdG)
        Me.gpxKeyboard.Controls.Add(Me.cmdF)
        Me.gpxKeyboard.Controls.Add(Me.cmdD)
        Me.gpxKeyboard.Controls.Add(Me.cmdS)
        Me.gpxKeyboard.Controls.Add(Me.cmdZ)
        Me.gpxKeyboard.Controls.Add(Me.cmdP)
        Me.gpxKeyboard.Controls.Add(Me.cmdO)
        Me.gpxKeyboard.Controls.Add(Me.cmdI)
        Me.gpxKeyboard.Controls.Add(Me.cmdU)
        Me.gpxKeyboard.Controls.Add(Me.cmdY)
        Me.gpxKeyboard.Controls.Add(Me.cmdT)
        Me.gpxKeyboard.Controls.Add(Me.cmdR)
        Me.gpxKeyboard.Controls.Add(Me.cmdE)
        Me.gpxKeyboard.Controls.Add(Me.cmdW)
        Me.gpxKeyboard.Controls.Add(Me.cmdQ)
        Me.gpxKeyboard.Controls.Add(Me.cmdA)
        Me.gpxKeyboard.Location = New System.Drawing.Point(-76, 414)
        Me.gpxKeyboard.Name = "gpxKeyboard"
        Me.gpxKeyboard.Size = New System.Drawing.Size(1177, 239)
        Me.gpxKeyboard.TabIndex = 177
        Me.gpxKeyboard.TabStop = False
        Me.gpxKeyboard.Text = "Keyboard"
        Me.gpxKeyboard.Visible = False
        '
        'cmdDash
        '
        Me.cmdDash.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDash.Location = New System.Drawing.Point(960, 132)
        Me.cmdDash.Name = "cmdDash"
        Me.cmdDash.Size = New System.Drawing.Size(100, 50)
        Me.cmdDash.TabIndex = 176
        Me.cmdDash.TabStop = False
        Me.cmdDash.Text = "-"
        Me.cmdDash.UseVisualStyleBackColor = True
        '
        'cmdBackspace
        '
        Me.cmdBackspace.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBackspace.Location = New System.Drawing.Point(1066, 19)
        Me.cmdBackspace.Name = "cmdBackspace"
        Me.cmdBackspace.Size = New System.Drawing.Size(100, 50)
        Me.cmdBackspace.TabIndex = 175
        Me.cmdBackspace.TabStop = False
        Me.cmdBackspace.Text = "Backspace"
        Me.cmdBackspace.UseVisualStyleBackColor = True
        '
        'cmdClearSelected
        '
        Me.cmdClearSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClearSelected.Location = New System.Drawing.Point(960, 188)
        Me.cmdClearSelected.Name = "cmdClearSelected"
        Me.cmdClearSelected.Size = New System.Drawing.Size(100, 50)
        Me.cmdClearSelected.TabIndex = 174
        Me.cmdClearSelected.TabStop = False
        Me.cmdClearSelected.Text = "Clear Selection"
        Me.cmdClearSelected.UseVisualStyleBackColor = True
        '
        'cmdNine
        '
        Me.cmdNine.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNine.Location = New System.Drawing.Point(854, 19)
        Me.cmdNine.Name = "cmdNine"
        Me.cmdNine.Size = New System.Drawing.Size(100, 50)
        Me.cmdNine.TabIndex = 173
        Me.cmdNine.TabStop = False
        Me.cmdNine.Text = "9"
        Me.cmdNine.UseVisualStyleBackColor = True
        '
        'cmdEight
        '
        Me.cmdEight.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEight.Location = New System.Drawing.Point(748, 19)
        Me.cmdEight.Name = "cmdEight"
        Me.cmdEight.Size = New System.Drawing.Size(100, 50)
        Me.cmdEight.TabIndex = 172
        Me.cmdEight.TabStop = False
        Me.cmdEight.Text = "8"
        Me.cmdEight.UseVisualStyleBackColor = True
        '
        'cmdSeven
        '
        Me.cmdSeven.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSeven.Location = New System.Drawing.Point(642, 18)
        Me.cmdSeven.Name = "cmdSeven"
        Me.cmdSeven.Size = New System.Drawing.Size(100, 50)
        Me.cmdSeven.TabIndex = 171
        Me.cmdSeven.TabStop = False
        Me.cmdSeven.Text = "7"
        Me.cmdSeven.UseVisualStyleBackColor = True
        '
        'cmdSix
        '
        Me.cmdSix.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSix.Location = New System.Drawing.Point(536, 19)
        Me.cmdSix.Name = "cmdSix"
        Me.cmdSix.Size = New System.Drawing.Size(100, 50)
        Me.cmdSix.TabIndex = 170
        Me.cmdSix.TabStop = False
        Me.cmdSix.Text = "6"
        Me.cmdSix.UseVisualStyleBackColor = True
        '
        'cmdFive
        '
        Me.cmdFive.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFive.Location = New System.Drawing.Point(430, 18)
        Me.cmdFive.Name = "cmdFive"
        Me.cmdFive.Size = New System.Drawing.Size(100, 50)
        Me.cmdFive.TabIndex = 169
        Me.cmdFive.TabStop = False
        Me.cmdFive.Text = "5"
        Me.cmdFive.UseVisualStyleBackColor = True
        '
        'cmdFour
        '
        Me.cmdFour.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFour.Location = New System.Drawing.Point(324, 18)
        Me.cmdFour.Name = "cmdFour"
        Me.cmdFour.Size = New System.Drawing.Size(100, 50)
        Me.cmdFour.TabIndex = 168
        Me.cmdFour.TabStop = False
        Me.cmdFour.Text = "4"
        Me.cmdFour.UseVisualStyleBackColor = True
        '
        'cmdKeyboardEnter
        '
        Me.cmdKeyboardEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdKeyboardEnter.Location = New System.Drawing.Point(1066, 131)
        Me.cmdKeyboardEnter.Name = "cmdKeyboardEnter"
        Me.cmdKeyboardEnter.Size = New System.Drawing.Size(100, 102)
        Me.cmdKeyboardEnter.TabIndex = 167
        Me.cmdKeyboardEnter.TabStop = False
        Me.cmdKeyboardEnter.Text = "Enter"
        Me.cmdKeyboardEnter.UseVisualStyleBackColor = True
        '
        'cmdThree
        '
        Me.cmdThree.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThree.Location = New System.Drawing.Point(218, 19)
        Me.cmdThree.Name = "cmdThree"
        Me.cmdThree.Size = New System.Drawing.Size(100, 50)
        Me.cmdThree.TabIndex = 166
        Me.cmdThree.TabStop = False
        Me.cmdThree.Text = "3"
        Me.cmdThree.UseVisualStyleBackColor = True
        '
        'cmdTwo
        '
        Me.cmdTwo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTwo.Location = New System.Drawing.Point(112, 19)
        Me.cmdTwo.Name = "cmdTwo"
        Me.cmdTwo.Size = New System.Drawing.Size(100, 50)
        Me.cmdTwo.TabIndex = 165
        Me.cmdTwo.TabStop = False
        Me.cmdTwo.Text = "2"
        Me.cmdTwo.UseVisualStyleBackColor = True
        '
        'cmdOne
        '
        Me.cmdOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOne.Location = New System.Drawing.Point(6, 19)
        Me.cmdOne.Name = "cmdOne"
        Me.cmdOne.Size = New System.Drawing.Size(100, 50)
        Me.cmdOne.TabIndex = 164
        Me.cmdOne.TabStop = False
        Me.cmdOne.Text = "1"
        Me.cmdOne.UseVisualStyleBackColor = True
        '
        'cmdZero
        '
        Me.cmdZero.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdZero.Location = New System.Drawing.Point(960, 19)
        Me.cmdZero.Name = "cmdZero"
        Me.cmdZero.Size = New System.Drawing.Size(100, 50)
        Me.cmdZero.TabIndex = 163
        Me.cmdZero.TabStop = False
        Me.cmdZero.Text = "0"
        Me.cmdZero.UseVisualStyleBackColor = True
        '
        'cmdSpace
        '
        Me.cmdSpace.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSpace.Location = New System.Drawing.Point(748, 187)
        Me.cmdSpace.Name = "cmdSpace"
        Me.cmdSpace.Size = New System.Drawing.Size(206, 50)
        Me.cmdSpace.TabIndex = 162
        Me.cmdSpace.TabStop = False
        Me.cmdSpace.Text = "SPACE"
        Me.cmdSpace.UseVisualStyleBackColor = True
        '
        'cmdM
        '
        Me.cmdM.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdM.Location = New System.Drawing.Point(642, 187)
        Me.cmdM.Name = "cmdM"
        Me.cmdM.Size = New System.Drawing.Size(100, 50)
        Me.cmdM.TabIndex = 161
        Me.cmdM.TabStop = False
        Me.cmdM.Text = "M"
        Me.cmdM.UseVisualStyleBackColor = True
        '
        'cmdN
        '
        Me.cmdN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdN.Location = New System.Drawing.Point(536, 187)
        Me.cmdN.Name = "cmdN"
        Me.cmdN.Size = New System.Drawing.Size(100, 50)
        Me.cmdN.TabIndex = 160
        Me.cmdN.TabStop = False
        Me.cmdN.Text = "N"
        Me.cmdN.UseVisualStyleBackColor = True
        '
        'cmdB
        '
        Me.cmdB.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdB.Location = New System.Drawing.Point(430, 187)
        Me.cmdB.Name = "cmdB"
        Me.cmdB.Size = New System.Drawing.Size(100, 50)
        Me.cmdB.TabIndex = 159
        Me.cmdB.TabStop = False
        Me.cmdB.Text = "B"
        Me.cmdB.UseVisualStyleBackColor = True
        '
        'cmdV
        '
        Me.cmdV.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdV.Location = New System.Drawing.Point(324, 188)
        Me.cmdV.Name = "cmdV"
        Me.cmdV.Size = New System.Drawing.Size(100, 50)
        Me.cmdV.TabIndex = 158
        Me.cmdV.TabStop = False
        Me.cmdV.Text = "V"
        Me.cmdV.UseVisualStyleBackColor = True
        '
        'cmdC
        '
        Me.cmdC.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdC.Location = New System.Drawing.Point(218, 187)
        Me.cmdC.Name = "cmdC"
        Me.cmdC.Size = New System.Drawing.Size(100, 50)
        Me.cmdC.TabIndex = 157
        Me.cmdC.TabStop = False
        Me.cmdC.Text = "C"
        Me.cmdC.UseVisualStyleBackColor = True
        '
        'cmdX
        '
        Me.cmdX.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdX.Location = New System.Drawing.Point(112, 187)
        Me.cmdX.Name = "cmdX"
        Me.cmdX.Size = New System.Drawing.Size(100, 50)
        Me.cmdX.TabIndex = 156
        Me.cmdX.TabStop = False
        Me.cmdX.Text = "X"
        Me.cmdX.UseVisualStyleBackColor = True
        '
        'cmdL
        '
        Me.cmdL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdL.Location = New System.Drawing.Point(854, 132)
        Me.cmdL.Name = "cmdL"
        Me.cmdL.Size = New System.Drawing.Size(100, 50)
        Me.cmdL.TabIndex = 155
        Me.cmdL.TabStop = False
        Me.cmdL.Text = "L"
        Me.cmdL.UseVisualStyleBackColor = True
        '
        'cmdK
        '
        Me.cmdK.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdK.Location = New System.Drawing.Point(748, 132)
        Me.cmdK.Name = "cmdK"
        Me.cmdK.Size = New System.Drawing.Size(100, 50)
        Me.cmdK.TabIndex = 154
        Me.cmdK.TabStop = False
        Me.cmdK.Text = "K"
        Me.cmdK.UseVisualStyleBackColor = True
        '
        'cmdJ
        '
        Me.cmdJ.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdJ.Location = New System.Drawing.Point(642, 132)
        Me.cmdJ.Name = "cmdJ"
        Me.cmdJ.Size = New System.Drawing.Size(100, 50)
        Me.cmdJ.TabIndex = 153
        Me.cmdJ.TabStop = False
        Me.cmdJ.Text = "J"
        Me.cmdJ.UseVisualStyleBackColor = True
        '
        'cmdH
        '
        Me.cmdH.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdH.Location = New System.Drawing.Point(536, 132)
        Me.cmdH.Name = "cmdH"
        Me.cmdH.Size = New System.Drawing.Size(100, 50)
        Me.cmdH.TabIndex = 152
        Me.cmdH.TabStop = False
        Me.cmdH.Text = "H"
        Me.cmdH.UseVisualStyleBackColor = True
        '
        'cmdG
        '
        Me.cmdG.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdG.Location = New System.Drawing.Point(430, 132)
        Me.cmdG.Name = "cmdG"
        Me.cmdG.Size = New System.Drawing.Size(100, 50)
        Me.cmdG.TabIndex = 151
        Me.cmdG.TabStop = False
        Me.cmdG.Text = "G"
        Me.cmdG.UseVisualStyleBackColor = True
        '
        'cmdF
        '
        Me.cmdF.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdF.Location = New System.Drawing.Point(324, 132)
        Me.cmdF.Name = "cmdF"
        Me.cmdF.Size = New System.Drawing.Size(100, 50)
        Me.cmdF.TabIndex = 150
        Me.cmdF.TabStop = False
        Me.cmdF.Text = "F"
        Me.cmdF.UseVisualStyleBackColor = True
        '
        'cmdD
        '
        Me.cmdD.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdD.Location = New System.Drawing.Point(218, 131)
        Me.cmdD.Name = "cmdD"
        Me.cmdD.Size = New System.Drawing.Size(100, 50)
        Me.cmdD.TabIndex = 149
        Me.cmdD.TabStop = False
        Me.cmdD.Text = "D"
        Me.cmdD.UseVisualStyleBackColor = True
        '
        'cmdS
        '
        Me.cmdS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdS.Location = New System.Drawing.Point(112, 131)
        Me.cmdS.Name = "cmdS"
        Me.cmdS.Size = New System.Drawing.Size(100, 50)
        Me.cmdS.TabIndex = 148
        Me.cmdS.TabStop = False
        Me.cmdS.Text = "S"
        Me.cmdS.UseVisualStyleBackColor = True
        '
        'cmdZ
        '
        Me.cmdZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdZ.Location = New System.Drawing.Point(6, 187)
        Me.cmdZ.Name = "cmdZ"
        Me.cmdZ.Size = New System.Drawing.Size(100, 50)
        Me.cmdZ.TabIndex = 147
        Me.cmdZ.TabStop = False
        Me.cmdZ.Text = "Z"
        Me.cmdZ.UseVisualStyleBackColor = True
        '
        'cmdP
        '
        Me.cmdP.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdP.Location = New System.Drawing.Point(960, 75)
        Me.cmdP.Name = "cmdP"
        Me.cmdP.Size = New System.Drawing.Size(100, 50)
        Me.cmdP.TabIndex = 146
        Me.cmdP.TabStop = False
        Me.cmdP.Text = "P"
        Me.cmdP.UseVisualStyleBackColor = True
        '
        'cmdO
        '
        Me.cmdO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdO.Location = New System.Drawing.Point(854, 75)
        Me.cmdO.Name = "cmdO"
        Me.cmdO.Size = New System.Drawing.Size(100, 50)
        Me.cmdO.TabIndex = 145
        Me.cmdO.TabStop = False
        Me.cmdO.Text = "O"
        Me.cmdO.UseVisualStyleBackColor = True
        '
        'cmdI
        '
        Me.cmdI.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdI.Location = New System.Drawing.Point(748, 76)
        Me.cmdI.Name = "cmdI"
        Me.cmdI.Size = New System.Drawing.Size(100, 50)
        Me.cmdI.TabIndex = 144
        Me.cmdI.TabStop = False
        Me.cmdI.Text = "I"
        Me.cmdI.UseVisualStyleBackColor = True
        '
        'cmdU
        '
        Me.cmdU.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdU.Location = New System.Drawing.Point(642, 76)
        Me.cmdU.Name = "cmdU"
        Me.cmdU.Size = New System.Drawing.Size(100, 50)
        Me.cmdU.TabIndex = 143
        Me.cmdU.TabStop = False
        Me.cmdU.Text = "U"
        Me.cmdU.UseVisualStyleBackColor = True
        '
        'cmdY
        '
        Me.cmdY.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdY.Location = New System.Drawing.Point(536, 76)
        Me.cmdY.Name = "cmdY"
        Me.cmdY.Size = New System.Drawing.Size(100, 50)
        Me.cmdY.TabIndex = 142
        Me.cmdY.TabStop = False
        Me.cmdY.Text = "Y"
        Me.cmdY.UseVisualStyleBackColor = True
        '
        'cmdT
        '
        Me.cmdT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdT.Location = New System.Drawing.Point(430, 76)
        Me.cmdT.Name = "cmdT"
        Me.cmdT.Size = New System.Drawing.Size(100, 50)
        Me.cmdT.TabIndex = 141
        Me.cmdT.TabStop = False
        Me.cmdT.Text = "T"
        Me.cmdT.UseVisualStyleBackColor = True
        '
        'cmdR
        '
        Me.cmdR.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdR.Location = New System.Drawing.Point(324, 76)
        Me.cmdR.Name = "cmdR"
        Me.cmdR.Size = New System.Drawing.Size(100, 50)
        Me.cmdR.TabIndex = 140
        Me.cmdR.TabStop = False
        Me.cmdR.Text = "R"
        Me.cmdR.UseVisualStyleBackColor = True
        '
        'cmdE
        '
        Me.cmdE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdE.Location = New System.Drawing.Point(218, 75)
        Me.cmdE.Name = "cmdE"
        Me.cmdE.Size = New System.Drawing.Size(100, 50)
        Me.cmdE.TabIndex = 139
        Me.cmdE.TabStop = False
        Me.cmdE.Text = "E"
        Me.cmdE.UseVisualStyleBackColor = True
        '
        'cmdW
        '
        Me.cmdW.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdW.Location = New System.Drawing.Point(112, 75)
        Me.cmdW.Name = "cmdW"
        Me.cmdW.Size = New System.Drawing.Size(100, 50)
        Me.cmdW.TabIndex = 138
        Me.cmdW.TabStop = False
        Me.cmdW.Text = "W"
        Me.cmdW.UseVisualStyleBackColor = True
        '
        'cmdQ
        '
        Me.cmdQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdQ.Location = New System.Drawing.Point(6, 75)
        Me.cmdQ.Name = "cmdQ"
        Me.cmdQ.Size = New System.Drawing.Size(100, 50)
        Me.cmdQ.TabIndex = 137
        Me.cmdQ.TabStop = False
        Me.cmdQ.Text = "Q"
        Me.cmdQ.UseVisualStyleBackColor = True
        '
        'cmdA
        '
        Me.cmdA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdA.Location = New System.Drawing.Point(6, 131)
        Me.cmdA.Name = "cmdA"
        Me.cmdA.Size = New System.Drawing.Size(100, 50)
        Me.cmdA.TabIndex = 134
        Me.cmdA.TabStop = False
        Me.cmdA.Text = "A"
        Me.cmdA.UseVisualStyleBackColor = True
        '
        'lstCoilSuggest
        '
        Me.lstCoilSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCoilSuggest.FormattingEnabled = True
        Me.lstCoilSuggest.ItemHeight = 20
        Me.lstCoilSuggest.Location = New System.Drawing.Point(120, 120)
        Me.lstCoilSuggest.Name = "lstCoilSuggest"
        Me.lstCoilSuggest.Size = New System.Drawing.Size(159, 84)
        Me.lstCoilSuggest.TabIndex = 99
        Me.lstCoilSuggest.TabStop = False
        Me.lstCoilSuggest.Visible = False
        '
        'cboCarbon
        '
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(108, 83)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(158, 21)
        Me.cboCarbon.TabIndex = 8
        '
        'cboSteelSize
        '
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(108, 116)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(158, 21)
        Me.cboSteelSize.TabIndex = 9
        '
        'cmdForwardSlash
        '
        Me.cmdForwardSlash.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdForwardSlash.Location = New System.Drawing.Point(1066, 75)
        Me.cmdForwardSlash.Name = "cmdForwardSlash"
        Me.cmdForwardSlash.Size = New System.Drawing.Size(100, 50)
        Me.cmdForwardSlash.TabIndex = 177
        Me.cmdForwardSlash.TabStop = False
        Me.cmdForwardSlash.Text = "/"
        Me.cmdForwardSlash.UseVisualStyleBackColor = True
        '
        'CoilWIPInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 711)
        Me.Controls.Add(Me.lstCoilSuggest)
        Me.Controls.Add(Me.gpxKeyboard)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvWIPCoils)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "CoilWIPInventory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Coil WIP Inventory"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvWIPCoils, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxKeyboard.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCoilID As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvWIPCoils As System.Windows.Forms.DataGridView
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents gpxKeyboard As System.Windows.Forms.GroupBox
    Friend WithEvents cmdBackspace As System.Windows.Forms.Button
    Friend WithEvents cmdClearSelected As System.Windows.Forms.Button
    Friend WithEvents cmdNine As System.Windows.Forms.Button
    Friend WithEvents cmdEight As System.Windows.Forms.Button
    Friend WithEvents cmdSeven As System.Windows.Forms.Button
    Friend WithEvents cmdSix As System.Windows.Forms.Button
    Friend WithEvents cmdFive As System.Windows.Forms.Button
    Friend WithEvents cmdFour As System.Windows.Forms.Button
    Friend WithEvents cmdKeyboardEnter As System.Windows.Forms.Button
    Friend WithEvents cmdThree As System.Windows.Forms.Button
    Friend WithEvents cmdTwo As System.Windows.Forms.Button
    Friend WithEvents cmdOne As System.Windows.Forms.Button
    Friend WithEvents cmdZero As System.Windows.Forms.Button
    Friend WithEvents cmdSpace As System.Windows.Forms.Button
    Friend WithEvents cmdM As System.Windows.Forms.Button
    Friend WithEvents cmdN As System.Windows.Forms.Button
    Friend WithEvents cmdB As System.Windows.Forms.Button
    Friend WithEvents cmdV As System.Windows.Forms.Button
    Friend WithEvents cmdC As System.Windows.Forms.Button
    Friend WithEvents cmdX As System.Windows.Forms.Button
    Friend WithEvents cmdL As System.Windows.Forms.Button
    Friend WithEvents cmdK As System.Windows.Forms.Button
    Friend WithEvents cmdJ As System.Windows.Forms.Button
    Friend WithEvents cmdH As System.Windows.Forms.Button
    Friend WithEvents cmdG As System.Windows.Forms.Button
    Friend WithEvents cmdF As System.Windows.Forms.Button
    Friend WithEvents cmdD As System.Windows.Forms.Button
    Friend WithEvents cmdS As System.Windows.Forms.Button
    Friend WithEvents cmdZ As System.Windows.Forms.Button
    Friend WithEvents cmdP As System.Windows.Forms.Button
    Friend WithEvents cmdO As System.Windows.Forms.Button
    Friend WithEvents cmdI As System.Windows.Forms.Button
    Friend WithEvents cmdU As System.Windows.Forms.Button
    Friend WithEvents cmdY As System.Windows.Forms.Button
    Friend WithEvents cmdT As System.Windows.Forms.Button
    Friend WithEvents cmdR As System.Windows.Forms.Button
    Friend WithEvents cmdE As System.Windows.Forms.Button
    Friend WithEvents cmdW As System.Windows.Forms.Button
    Friend WithEvents cmdQ As System.Windows.Forms.Button
    Friend WithEvents cmdA As System.Windows.Forms.Button
    Friend WithEvents cmdDash As System.Windows.Forms.Button
    Friend WithEvents lstCoilSuggest As System.Windows.Forms.ListBox
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents cmdForwardSlash As System.Windows.Forms.Button
End Class
