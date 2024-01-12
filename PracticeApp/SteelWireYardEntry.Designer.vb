<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SteelWireYardEntry
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxSteelCoilData = New System.Windows.Forms.GroupBox
        Me.txtInventoryID = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCoilID = New System.Windows.Forms.TextBox
        Me.txtCoilDescription = New System.Windows.Forms.Label
        Me.lblCoilWeightRequired = New System.Windows.Forms.Label
        Me.lblHeatRequired = New System.Windows.Forms.Label
        Me.lblSteelSizeRequired = New System.Windows.Forms.Label
        Me.lblCarbonRequired = New System.Windows.Forms.Label
        Me.cboHeatNumber = New System.Windows.Forms.ComboBox
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtCoilWeight = New System.Windows.Forms.TextBox
        Me.cmdAddToYard = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.dtpReturnDate = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdEnter = New System.Windows.Forms.Button
        Me.cmdBRN = New System.Windows.Forms.Button
        Me.cmdBRS = New System.Windows.Forms.Button
        Me.cmdBRASS = New System.Windows.Forms.Button
        Me.cmdALM = New System.Windows.Forms.Button
        Me.cmdALUM = New System.Windows.Forms.Button
        Me.cmdCDA = New System.Windows.Forms.Button
        Me.cmdSS = New System.Windows.Forms.Button
        Me.cmdDash = New System.Windows.Forms.Button
        Me.cmdTWD = New System.Windows.Forms.Button
        Me.cmdBackspace = New System.Windows.Forms.Button
        Me.cmdFS = New System.Windows.Forms.Button
        Me.cmdSA = New System.Windows.Forms.Button
        Me.cmdA = New System.Windows.Forms.Button
        Me.cmdC = New System.Windows.Forms.Button
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
        Me.gpxPostDate = New System.Windows.Forms.GroupBox
        Me.lstHeatSuggest = New System.Windows.Forms.ListBox
        Me.lstSizeSuggest = New System.Windows.Forms.ListBox
        Me.lstCarbonSuggest = New System.Windows.Forms.ListBox
        Me.lstCoilIDSuggest = New System.Windows.Forms.ListBox
        Me.bgwkCoilIDSuggest = New System.ComponentModel.BackgroundWorker
        Me.tmrScanTime = New System.Windows.Forms.Timer(Me.components)
        Me.lstInventoryIDSuggest = New System.Windows.Forms.ListBox
        Me.MenuStrip1.SuspendLayout()
        Me.gpxSteelCoilData.SuspendLayout()
        Me.gpxPostDate.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1125, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearDataToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ClearDataToolStripMenuItem
        '
        Me.ClearDataToolStripMenuItem.Name = "ClearDataToolStripMenuItem"
        Me.ClearDataToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.ClearDataToolStripMenuItem.Text = "Clear All"
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
        'gpxSteelCoilData
        '
        Me.gpxSteelCoilData.Controls.Add(Me.txtInventoryID)
        Me.gpxSteelCoilData.Controls.Add(Me.Label7)
        Me.gpxSteelCoilData.Controls.Add(Me.txtLocation)
        Me.gpxSteelCoilData.Controls.Add(Me.Label2)
        Me.gpxSteelCoilData.Controls.Add(Me.txtCoilID)
        Me.gpxSteelCoilData.Controls.Add(Me.txtCoilDescription)
        Me.gpxSteelCoilData.Controls.Add(Me.lblCoilWeightRequired)
        Me.gpxSteelCoilData.Controls.Add(Me.lblHeatRequired)
        Me.gpxSteelCoilData.Controls.Add(Me.lblSteelSizeRequired)
        Me.gpxSteelCoilData.Controls.Add(Me.lblCarbonRequired)
        Me.gpxSteelCoilData.Controls.Add(Me.cboHeatNumber)
        Me.gpxSteelCoilData.Controls.Add(Me.cboSteelSize)
        Me.gpxSteelCoilData.Controls.Add(Me.cboCarbon)
        Me.gpxSteelCoilData.Controls.Add(Me.Label8)
        Me.gpxSteelCoilData.Controls.Add(Me.txtCoilWeight)
        Me.gpxSteelCoilData.Controls.Add(Me.cmdAddToYard)
        Me.gpxSteelCoilData.Controls.Add(Me.Label10)
        Me.gpxSteelCoilData.Controls.Add(Me.Label3)
        Me.gpxSteelCoilData.Controls.Add(Me.Label6)
        Me.gpxSteelCoilData.Controls.Add(Me.Label1)
        Me.gpxSteelCoilData.Controls.Add(Me.Label11)
        Me.gpxSteelCoilData.Location = New System.Drawing.Point(21, 92)
        Me.gpxSteelCoilData.Name = "gpxSteelCoilData"
        Me.gpxSteelCoilData.Size = New System.Drawing.Size(343, 468)
        Me.gpxSteelCoilData.TabIndex = 1
        Me.gpxSteelCoilData.TabStop = False
        Me.gpxSteelCoilData.Text = "Steel Coil Information"
        '
        'txtInventoryID
        '
        Me.txtInventoryID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInventoryID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInventoryID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInventoryID.Location = New System.Drawing.Point(170, 254)
        Me.txtInventoryID.Name = "txtInventoryID"
        Me.txtInventoryID.Size = New System.Drawing.Size(158, 26)
        Me.txtInventoryID.TabIndex = 35
        Me.txtInventoryID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 256)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 20)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Inventory ID"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLocation
        '
        Me.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocation.Location = New System.Drawing.Point(170, 218)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(158, 26)
        Me.txtLocation.TabIndex = 33
        Me.txtLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 220)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 20)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Location"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCoilID
        '
        Me.txtCoilID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoilID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilID.Location = New System.Drawing.Point(113, 20)
        Me.txtCoilID.Name = "txtCoilID"
        Me.txtCoilID.Size = New System.Drawing.Size(215, 26)
        Me.txtCoilID.TabIndex = 0
        Me.txtCoilID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCoilDescription
        '
        Me.txtCoilDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilDescription.Location = New System.Drawing.Point(7, 302)
        Me.txtCoilDescription.Name = "txtCoilDescription"
        Me.txtCoilDescription.Size = New System.Drawing.Size(323, 57)
        Me.txtCoilDescription.TabIndex = 32
        Me.txtCoilDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCoilWeightRequired
        '
        Me.lblCoilWeightRequired.AutoSize = True
        Me.lblCoilWeightRequired.ForeColor = System.Drawing.Color.Blue
        Me.lblCoilWeightRequired.Location = New System.Drawing.Point(110, 186)
        Me.lblCoilWeightRequired.Name = "lblCoilWeightRequired"
        Me.lblCoilWeightRequired.Size = New System.Drawing.Size(56, 13)
        Me.lblCoilWeightRequired.TabIndex = 31
        Me.lblCoilWeightRequired.Text = "(Required)"
        '
        'lblHeatRequired
        '
        Me.lblHeatRequired.AutoSize = True
        Me.lblHeatRequired.ForeColor = System.Drawing.Color.Blue
        Me.lblHeatRequired.Location = New System.Drawing.Point(110, 144)
        Me.lblHeatRequired.Name = "lblHeatRequired"
        Me.lblHeatRequired.Size = New System.Drawing.Size(56, 13)
        Me.lblHeatRequired.TabIndex = 30
        Me.lblHeatRequired.Text = "(Required)"
        '
        'lblSteelSizeRequired
        '
        Me.lblSteelSizeRequired.AutoSize = True
        Me.lblSteelSizeRequired.ForeColor = System.Drawing.Color.Blue
        Me.lblSteelSizeRequired.Location = New System.Drawing.Point(108, 107)
        Me.lblSteelSizeRequired.Name = "lblSteelSizeRequired"
        Me.lblSteelSizeRequired.Size = New System.Drawing.Size(56, 13)
        Me.lblSteelSizeRequired.TabIndex = 29
        Me.lblSteelSizeRequired.Text = "(Required)"
        '
        'lblCarbonRequired
        '
        Me.lblCarbonRequired.AutoSize = True
        Me.lblCarbonRequired.ForeColor = System.Drawing.Color.Blue
        Me.lblCarbonRequired.Location = New System.Drawing.Point(108, 66)
        Me.lblCarbonRequired.Name = "lblCarbonRequired"
        Me.lblCarbonRequired.Size = New System.Drawing.Size(56, 13)
        Me.lblCarbonRequired.TabIndex = 28
        Me.lblCarbonRequired.Text = "(Required)"
        '
        'cboHeatNumber
        '
        Me.cboHeatNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHeatNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHeatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHeatNumber.FormattingEnabled = True
        Me.cboHeatNumber.Location = New System.Drawing.Point(170, 136)
        Me.cboHeatNumber.Name = "cboHeatNumber"
        Me.cboHeatNumber.Size = New System.Drawing.Size(158, 28)
        Me.cboHeatNumber.TabIndex = 4
        '
        'cboSteelSize
        '
        Me.cboSteelSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(170, 99)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(158, 28)
        Me.cboSteelSize.TabIndex = 3
        '
        'cboCarbon
        '
        Me.cboCarbon.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(170, 58)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(158, 28)
        Me.cboCarbon.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(4, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 20)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Coil ID"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCoilWeight
        '
        Me.txtCoilWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilWeight.Location = New System.Drawing.Point(170, 179)
        Me.txtCoilWeight.Name = "txtCoilWeight"
        Me.txtCoilWeight.Size = New System.Drawing.Size(158, 26)
        Me.txtCoilWeight.TabIndex = 6
        '
        'cmdAddToYard
        '
        Me.cmdAddToYard.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddToYard.Location = New System.Drawing.Point(64, 362)
        Me.cmdAddToYard.Name = "cmdAddToYard"
        Me.cmdAddToYard.Size = New System.Drawing.Size(100, 100)
        Me.cmdAddToYard.TabIndex = 7
        Me.cmdAddToYard.Text = "Add To Yard"
        Me.cmdAddToYard.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(4, 102)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Size"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 20)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Heat Number"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Carbon"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 181)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Coil Weight"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 282)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Description"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClearAll.Location = New System.Drawing.Point(801, 465)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(100, 100)
        Me.cmdClearAll.TabIndex = 8
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'dtpReturnDate
        '
        Me.dtpReturnDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReturnDate.Location = New System.Drawing.Point(170, 19)
        Me.dtpReturnDate.Name = "dtpReturnDate"
        Me.dtpReturnDate.Size = New System.Drawing.Size(160, 26)
        Me.dtpReturnDate.TabIndex = 24
        Me.dtpReturnDate.TabStop = False
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 20)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Date"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(1013, 465)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(100, 100)
        Me.cmdExit.TabIndex = 23
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(687, 147)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(100, 205)
        Me.cmdClear.TabIndex = 77
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdEnter
        '
        Me.cmdEnter.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEnter.Location = New System.Drawing.Point(687, 363)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(100, 205)
        Me.cmdEnter.TabIndex = 76
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'cmdBRN
        '
        Me.cmdBRN.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdBRN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBRN.Location = New System.Drawing.Point(907, 147)
        Me.cmdBRN.Name = "cmdBRN"
        Me.cmdBRN.Size = New System.Drawing.Size(100, 100)
        Me.cmdBRN.TabIndex = 75
        Me.cmdBRN.Text = "BRN"
        Me.cmdBRN.UseVisualStyleBackColor = True
        '
        'cmdBRS
        '
        Me.cmdBRS.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdBRS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBRS.Location = New System.Drawing.Point(1013, 147)
        Me.cmdBRS.Name = "cmdBRS"
        Me.cmdBRS.Size = New System.Drawing.Size(100, 100)
        Me.cmdBRS.TabIndex = 74
        Me.cmdBRS.Text = "BRS"
        Me.cmdBRS.UseVisualStyleBackColor = True
        '
        'cmdBRASS
        '
        Me.cmdBRASS.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdBRASS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBRASS.Location = New System.Drawing.Point(801, 147)
        Me.cmdBRASS.Name = "cmdBRASS"
        Me.cmdBRASS.Size = New System.Drawing.Size(100, 100)
        Me.cmdBRASS.TabIndex = 73
        Me.cmdBRASS.Text = "BRASS"
        Me.cmdBRASS.UseVisualStyleBackColor = True
        '
        'cmdALM
        '
        Me.cmdALM.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdALM.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdALM.Location = New System.Drawing.Point(907, 41)
        Me.cmdALM.Name = "cmdALM"
        Me.cmdALM.Size = New System.Drawing.Size(100, 100)
        Me.cmdALM.TabIndex = 72
        Me.cmdALM.Text = "ALM"
        Me.cmdALM.UseVisualStyleBackColor = True
        '
        'cmdALUM
        '
        Me.cmdALUM.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdALUM.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdALUM.Location = New System.Drawing.Point(1013, 41)
        Me.cmdALUM.Name = "cmdALUM"
        Me.cmdALUM.Size = New System.Drawing.Size(100, 100)
        Me.cmdALUM.TabIndex = 71
        Me.cmdALUM.Text = "ALUM"
        Me.cmdALUM.UseVisualStyleBackColor = True
        '
        'cmdCDA
        '
        Me.cmdCDA.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdCDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCDA.Location = New System.Drawing.Point(907, 253)
        Me.cmdCDA.Name = "cmdCDA"
        Me.cmdCDA.Size = New System.Drawing.Size(100, 100)
        Me.cmdCDA.TabIndex = 70
        Me.cmdCDA.Text = "CDA"
        Me.cmdCDA.UseVisualStyleBackColor = True
        '
        'cmdSS
        '
        Me.cmdSS.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdSS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSS.Location = New System.Drawing.Point(907, 359)
        Me.cmdSS.Name = "cmdSS"
        Me.cmdSS.Size = New System.Drawing.Size(100, 100)
        Me.cmdSS.TabIndex = 69
        Me.cmdSS.Text = "SS"
        Me.cmdSS.UseVisualStyleBackColor = True
        '
        'cmdDash
        '
        Me.cmdDash.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdDash.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDash.Location = New System.Drawing.Point(687, 41)
        Me.cmdDash.Name = "cmdDash"
        Me.cmdDash.Size = New System.Drawing.Size(100, 100)
        Me.cmdDash.TabIndex = 68
        Me.cmdDash.Text = "-"
        Me.cmdDash.UseVisualStyleBackColor = True
        '
        'cmdTWD
        '
        Me.cmdTWD.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdTWD.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTWD.Location = New System.Drawing.Point(1013, 359)
        Me.cmdTWD.Name = "cmdTWD"
        Me.cmdTWD.Size = New System.Drawing.Size(100, 100)
        Me.cmdTWD.TabIndex = 67
        Me.cmdTWD.Text = "TWD"
        Me.cmdTWD.UseVisualStyleBackColor = True
        '
        'cmdBackspace
        '
        Me.cmdBackspace.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdBackspace.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBackspace.Location = New System.Drawing.Point(369, 43)
        Me.cmdBackspace.Name = "cmdBackspace"
        Me.cmdBackspace.Size = New System.Drawing.Size(205, 100)
        Me.cmdBackspace.TabIndex = 66
        Me.cmdBackspace.Text = "Backspace"
        Me.cmdBackspace.UseVisualStyleBackColor = True
        '
        'cmdFS
        '
        Me.cmdFS.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdFS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFS.Location = New System.Drawing.Point(1013, 253)
        Me.cmdFS.Name = "cmdFS"
        Me.cmdFS.Size = New System.Drawing.Size(100, 100)
        Me.cmdFS.TabIndex = 65
        Me.cmdFS.Text = "FS"
        Me.cmdFS.UseVisualStyleBackColor = True
        '
        'cmdSA
        '
        Me.cmdSA.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdSA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSA.Location = New System.Drawing.Point(801, 359)
        Me.cmdSA.Name = "cmdSA"
        Me.cmdSA.Size = New System.Drawing.Size(100, 100)
        Me.cmdSA.TabIndex = 64
        Me.cmdSA.Text = "SA"
        Me.cmdSA.UseVisualStyleBackColor = True
        '
        'cmdA
        '
        Me.cmdA.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdA.Location = New System.Drawing.Point(801, 41)
        Me.cmdA.Name = "cmdA"
        Me.cmdA.Size = New System.Drawing.Size(100, 100)
        Me.cmdA.TabIndex = 63
        Me.cmdA.Text = "A"
        Me.cmdA.UseVisualStyleBackColor = True
        '
        'cmdC
        '
        Me.cmdC.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdC.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdC.Location = New System.Drawing.Point(801, 253)
        Me.cmdC.Name = "cmdC"
        Me.cmdC.Size = New System.Drawing.Size(100, 100)
        Me.cmdC.TabIndex = 62
        Me.cmdC.Text = "C"
        Me.cmdC.UseVisualStyleBackColor = True
        '
        'cmdNine
        '
        Me.cmdNine.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdNine.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNine.Location = New System.Drawing.Point(581, 147)
        Me.cmdNine.Name = "cmdNine"
        Me.cmdNine.Size = New System.Drawing.Size(100, 100)
        Me.cmdNine.TabIndex = 61
        Me.cmdNine.Text = "9"
        Me.cmdNine.UseVisualStyleBackColor = True
        '
        'cmdEight
        '
        Me.cmdEight.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdEight.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEight.Location = New System.Drawing.Point(475, 147)
        Me.cmdEight.Name = "cmdEight"
        Me.cmdEight.Size = New System.Drawing.Size(100, 100)
        Me.cmdEight.TabIndex = 60
        Me.cmdEight.Text = "8"
        Me.cmdEight.UseVisualStyleBackColor = True
        '
        'cmdSeven
        '
        Me.cmdSeven.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdSeven.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSeven.Location = New System.Drawing.Point(369, 147)
        Me.cmdSeven.Name = "cmdSeven"
        Me.cmdSeven.Size = New System.Drawing.Size(100, 100)
        Me.cmdSeven.TabIndex = 59
        Me.cmdSeven.Text = "7"
        Me.cmdSeven.UseVisualStyleBackColor = True
        '
        'cmdSix
        '
        Me.cmdSix.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdSix.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSix.Location = New System.Drawing.Point(581, 253)
        Me.cmdSix.Name = "cmdSix"
        Me.cmdSix.Size = New System.Drawing.Size(100, 100)
        Me.cmdSix.TabIndex = 58
        Me.cmdSix.Text = "6"
        Me.cmdSix.UseVisualStyleBackColor = True
        '
        'cmdFive
        '
        Me.cmdFive.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdFive.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFive.Location = New System.Drawing.Point(475, 253)
        Me.cmdFive.Name = "cmdFive"
        Me.cmdFive.Size = New System.Drawing.Size(100, 100)
        Me.cmdFive.TabIndex = 57
        Me.cmdFive.Text = "5"
        Me.cmdFive.UseVisualStyleBackColor = True
        '
        'cmdFour
        '
        Me.cmdFour.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdFour.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFour.Location = New System.Drawing.Point(369, 253)
        Me.cmdFour.Name = "cmdFour"
        Me.cmdFour.Size = New System.Drawing.Size(100, 100)
        Me.cmdFour.TabIndex = 56
        Me.cmdFour.Text = "4"
        Me.cmdFour.UseVisualStyleBackColor = True
        '
        'cmdThree
        '
        Me.cmdThree.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdThree.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThree.Location = New System.Drawing.Point(581, 363)
        Me.cmdThree.Name = "cmdThree"
        Me.cmdThree.Size = New System.Drawing.Size(100, 100)
        Me.cmdThree.TabIndex = 55
        Me.cmdThree.Text = "3"
        Me.cmdThree.UseVisualStyleBackColor = True
        '
        'cmdTwo
        '
        Me.cmdTwo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdTwo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTwo.Location = New System.Drawing.Point(475, 363)
        Me.cmdTwo.Name = "cmdTwo"
        Me.cmdTwo.Size = New System.Drawing.Size(100, 100)
        Me.cmdTwo.TabIndex = 54
        Me.cmdTwo.Text = "2"
        Me.cmdTwo.UseVisualStyleBackColor = True
        '
        'cmdOne
        '
        Me.cmdOne.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOne.Location = New System.Drawing.Point(369, 363)
        Me.cmdOne.Name = "cmdOne"
        Me.cmdOne.Size = New System.Drawing.Size(100, 100)
        Me.cmdOne.TabIndex = 53
        Me.cmdOne.Text = "1"
        Me.cmdOne.UseVisualStyleBackColor = True
        '
        'cmdForwardSlash
        '
        Me.cmdForwardSlash.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdForwardSlash.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdForwardSlash.Location = New System.Drawing.Point(581, 41)
        Me.cmdForwardSlash.Name = "cmdForwardSlash"
        Me.cmdForwardSlash.Size = New System.Drawing.Size(100, 100)
        Me.cmdForwardSlash.TabIndex = 52
        Me.cmdForwardSlash.Text = "/"
        Me.cmdForwardSlash.UseVisualStyleBackColor = True
        '
        'cmdDecimal
        '
        Me.cmdDecimal.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdDecimal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDecimal.Location = New System.Drawing.Point(581, 469)
        Me.cmdDecimal.Name = "cmdDecimal"
        Me.cmdDecimal.Size = New System.Drawing.Size(100, 100)
        Me.cmdDecimal.TabIndex = 51
        Me.cmdDecimal.Text = "."
        Me.cmdDecimal.UseVisualStyleBackColor = True
        '
        'cmdZero
        '
        Me.cmdZero.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdZero.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdZero.Location = New System.Drawing.Point(369, 469)
        Me.cmdZero.Name = "cmdZero"
        Me.cmdZero.Size = New System.Drawing.Size(205, 100)
        Me.cmdZero.TabIndex = 50
        Me.cmdZero.Text = "0"
        Me.cmdZero.UseVisualStyleBackColor = True
        '
        'gpxPostDate
        '
        Me.gpxPostDate.Controls.Add(Me.dtpReturnDate)
        Me.gpxPostDate.Controls.Add(Me.Label13)
        Me.gpxPostDate.Location = New System.Drawing.Point(21, 35)
        Me.gpxPostDate.Name = "gpxPostDate"
        Me.gpxPostDate.Size = New System.Drawing.Size(343, 51)
        Me.gpxPostDate.TabIndex = 78
        Me.gpxPostDate.TabStop = False
        Me.gpxPostDate.Text = "Posting Date"
        '
        'lstHeatSuggest
        '
        Me.lstHeatSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstHeatSuggest.FormattingEnabled = True
        Me.lstHeatSuggest.ItemHeight = 20
        Me.lstHeatSuggest.Location = New System.Drawing.Point(191, 256)
        Me.lstHeatSuggest.Name = "lstHeatSuggest"
        Me.lstHeatSuggest.Size = New System.Drawing.Size(158, 84)
        Me.lstHeatSuggest.TabIndex = 82
        Me.lstHeatSuggest.TabStop = False
        Me.lstHeatSuggest.Visible = False
        '
        'lstSizeSuggest
        '
        Me.lstSizeSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSizeSuggest.FormattingEnabled = True
        Me.lstSizeSuggest.ItemHeight = 20
        Me.lstSizeSuggest.Location = New System.Drawing.Point(191, 218)
        Me.lstSizeSuggest.Name = "lstSizeSuggest"
        Me.lstSizeSuggest.Size = New System.Drawing.Size(158, 84)
        Me.lstSizeSuggest.TabIndex = 81
        Me.lstSizeSuggest.TabStop = False
        Me.lstSizeSuggest.Visible = False
        '
        'lstCarbonSuggest
        '
        Me.lstCarbonSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCarbonSuggest.FormattingEnabled = True
        Me.lstCarbonSuggest.ItemHeight = 20
        Me.lstCarbonSuggest.Location = New System.Drawing.Point(191, 177)
        Me.lstCarbonSuggest.Name = "lstCarbonSuggest"
        Me.lstCarbonSuggest.Size = New System.Drawing.Size(158, 84)
        Me.lstCarbonSuggest.TabIndex = 80
        Me.lstCarbonSuggest.TabStop = False
        Me.lstCarbonSuggest.Visible = False
        '
        'lstCoilIDSuggest
        '
        Me.lstCoilIDSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCoilIDSuggest.FormattingEnabled = True
        Me.lstCoilIDSuggest.ItemHeight = 20
        Me.lstCoilIDSuggest.Location = New System.Drawing.Point(149, 137)
        Me.lstCoilIDSuggest.Name = "lstCoilIDSuggest"
        Me.lstCoilIDSuggest.Size = New System.Drawing.Size(200, 84)
        Me.lstCoilIDSuggest.TabIndex = 79
        Me.lstCoilIDSuggest.TabStop = False
        Me.lstCoilIDSuggest.Visible = False
        '
        'bgwkCoilIDSuggest
        '
        Me.bgwkCoilIDSuggest.WorkerSupportsCancellation = True
        '
        'tmrScanTime
        '
        '
        'lstInventoryIDSuggest
        '
        Me.lstInventoryIDSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstInventoryIDSuggest.FormattingEnabled = True
        Me.lstInventoryIDSuggest.ItemHeight = 20
        Me.lstInventoryIDSuggest.Location = New System.Drawing.Point(191, 372)
        Me.lstInventoryIDSuggest.Name = "lstInventoryIDSuggest"
        Me.lstInventoryIDSuggest.Size = New System.Drawing.Size(160, 84)
        Me.lstInventoryIDSuggest.TabIndex = 83
        Me.lstInventoryIDSuggest.TabStop = False
        Me.lstInventoryIDSuggest.Visible = False
        '
        'SteelWireYardEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1125, 578)
        Me.Controls.Add(Me.lstInventoryIDSuggest)
        Me.Controls.Add(Me.lstHeatSuggest)
        Me.Controls.Add(Me.lstSizeSuggest)
        Me.Controls.Add(Me.lstCarbonSuggest)
        Me.Controls.Add(Me.lstCoilIDSuggest)
        Me.Controls.Add(Me.gpxPostDate)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdEnter)
        Me.Controls.Add(Me.cmdBRN)
        Me.Controls.Add(Me.cmdBRS)
        Me.Controls.Add(Me.cmdBRASS)
        Me.Controls.Add(Me.cmdALM)
        Me.Controls.Add(Me.cmdALUM)
        Me.Controls.Add(Me.cmdCDA)
        Me.Controls.Add(Me.cmdSS)
        Me.Controls.Add(Me.cmdDash)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdTWD)
        Me.Controls.Add(Me.cmdBackspace)
        Me.Controls.Add(Me.cmdFS)
        Me.Controls.Add(Me.cmdSA)
        Me.Controls.Add(Me.cmdA)
        Me.Controls.Add(Me.cmdC)
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
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxSteelCoilData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "SteelWireYardEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Steel Wire Yard Entry"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxSteelCoilData.ResumeLayout(False)
        Me.gpxSteelCoilData.PerformLayout()
        Me.gpxPostDate.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxSteelCoilData As System.Windows.Forms.GroupBox
    Friend WithEvents txtCoilWeight As System.Windows.Forms.TextBox
    Friend WithEvents dtpReturnDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdAddToYard As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents ClearDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CoilIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboHeatNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents lblCoilWeightRequired As System.Windows.Forms.Label
    Friend WithEvents lblHeatRequired As System.Windows.Forms.Label
    Friend WithEvents lblSteelSizeRequired As System.Windows.Forms.Label
    Friend WithEvents lblCarbonRequired As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents cmdBRN As System.Windows.Forms.Button
    Friend WithEvents cmdBRS As System.Windows.Forms.Button
    Friend WithEvents cmdBRASS As System.Windows.Forms.Button
    Friend WithEvents cmdALM As System.Windows.Forms.Button
    Friend WithEvents cmdALUM As System.Windows.Forms.Button
    Friend WithEvents cmdCDA As System.Windows.Forms.Button
    Friend WithEvents cmdSS As System.Windows.Forms.Button
    Friend WithEvents cmdDash As System.Windows.Forms.Button
    Friend WithEvents cmdTWD As System.Windows.Forms.Button
    Friend WithEvents cmdBackspace As System.Windows.Forms.Button
    Friend WithEvents cmdFS As System.Windows.Forms.Button
    Friend WithEvents cmdSA As System.Windows.Forms.Button
    Friend WithEvents cmdA As System.Windows.Forms.Button
    Friend WithEvents cmdC As System.Windows.Forms.Button
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
    Friend WithEvents txtCoilDescription As System.Windows.Forms.Label
    Friend WithEvents gpxPostDate As System.Windows.Forms.GroupBox
    Friend WithEvents lstHeatSuggest As System.Windows.Forms.ListBox
    Friend WithEvents lstSizeSuggest As System.Windows.Forms.ListBox
    Friend WithEvents lstCarbonSuggest As System.Windows.Forms.ListBox
    Friend WithEvents lstCoilIDSuggest As System.Windows.Forms.ListBox
    Friend WithEvents bgwkCoilIDSuggest As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtCoilID As System.Windows.Forms.TextBox
    Friend WithEvents tmrScanTime As System.Windows.Forms.Timer
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtInventoryID As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lstInventoryIDSuggest As System.Windows.Forms.ListBox
End Class
