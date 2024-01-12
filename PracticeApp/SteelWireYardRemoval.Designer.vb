<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SteelWireYardRemoval
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
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxSteelCoilData = New System.Windows.Forms.GroupBox
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtInventoryID = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtAnnealLot = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCoilDescription = New System.Windows.Forms.Label
        Me.txtCoilID = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboHeatNumber = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.txtCoilWeight = New System.Windows.Forms.TextBox
        Me.cmdAddCoil = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.dtpCoilUsageDate = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.gpxColiIDEnter = New System.Windows.Forms.GroupBox
        Me.bgwkLoadCoilID = New System.ComponentModel.BackgroundWorker
        Me.cmdZero = New System.Windows.Forms.Button
        Me.cmdDecimal = New System.Windows.Forms.Button
        Me.cmdForwardSlash = New System.Windows.Forms.Button
        Me.cmdOne = New System.Windows.Forms.Button
        Me.cmdTwo = New System.Windows.Forms.Button
        Me.cmdThree = New System.Windows.Forms.Button
        Me.cmdFour = New System.Windows.Forms.Button
        Me.cmdFive = New System.Windows.Forms.Button
        Me.cmdSix = New System.Windows.Forms.Button
        Me.cmdSeven = New System.Windows.Forms.Button
        Me.cmdEight = New System.Windows.Forms.Button
        Me.cmdNine = New System.Windows.Forms.Button
        Me.cmdC = New System.Windows.Forms.Button
        Me.cmdA = New System.Windows.Forms.Button
        Me.cmdSA = New System.Windows.Forms.Button
        Me.cmdFS = New System.Windows.Forms.Button
        Me.cmdBackspace = New System.Windows.Forms.Button
        Me.cmdTWD = New System.Windows.Forms.Button
        Me.cmdDash = New System.Windows.Forms.Button
        Me.lstCoilIDSuggest = New System.Windows.Forms.ListBox
        Me.lstCarbonSuggest = New System.Windows.Forms.ListBox
        Me.lstSizeSuggest = New System.Windows.Forms.ListBox
        Me.lstHeatSuggest = New System.Windows.Forms.ListBox
        Me.cmdSS = New System.Windows.Forms.Button
        Me.cmdALM = New System.Windows.Forms.Button
        Me.cmdALUM = New System.Windows.Forms.Button
        Me.cmdCDA = New System.Windows.Forms.Button
        Me.cmdBRN = New System.Windows.Forms.Button
        Me.cmdBRS = New System.Windows.Forms.Button
        Me.cmdBRASS = New System.Windows.Forms.Button
        Me.bgwkCoilIDSuggest = New System.ComponentModel.BackgroundWorker
        Me.cmdEnter = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.tmrScanTime = New System.Windows.Forms.Timer(Me.components)
        Me.lstInventoryIDSuggest = New System.Windows.Forms.ListBox
        Me.cmdOSA = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.gpxSteelCoilData.SuspendLayout()
        Me.gpxColiIDEnter.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1135, 29)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearToolStripMenuItem})
        Me.FileToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(46, 25)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(138, 26)
        Me.ClearToolStripMenuItem.Text = "Clear All"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(48, 25)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem1})
        Me.ExitToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(46, 25)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(104, 26)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(1026, 476)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(100, 100)
        Me.cmdExit.TabIndex = 16
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxSteelCoilData
        '
        Me.gpxSteelCoilData.Controls.Add(Me.txtLocation)
        Me.gpxSteelCoilData.Controls.Add(Me.Label14)
        Me.gpxSteelCoilData.Controls.Add(Me.txtInventoryID)
        Me.gpxSteelCoilData.Controls.Add(Me.Label12)
        Me.gpxSteelCoilData.Controls.Add(Me.txtAnnealLot)
        Me.gpxSteelCoilData.Controls.Add(Me.Label2)
        Me.gpxSteelCoilData.Controls.Add(Me.txtCoilDescription)
        Me.gpxSteelCoilData.Controls.Add(Me.txtCoilID)
        Me.gpxSteelCoilData.Controls.Add(Me.Label9)
        Me.gpxSteelCoilData.Controls.Add(Me.Label7)
        Me.gpxSteelCoilData.Controls.Add(Me.Label5)
        Me.gpxSteelCoilData.Controls.Add(Me.Label4)
        Me.gpxSteelCoilData.Controls.Add(Me.cboHeatNumber)
        Me.gpxSteelCoilData.Controls.Add(Me.Label8)
        Me.gpxSteelCoilData.Controls.Add(Me.cboSteelSize)
        Me.gpxSteelCoilData.Controls.Add(Me.cboCarbon)
        Me.gpxSteelCoilData.Controls.Add(Me.txtCoilWeight)
        Me.gpxSteelCoilData.Controls.Add(Me.cmdAddCoil)
        Me.gpxSteelCoilData.Controls.Add(Me.Label10)
        Me.gpxSteelCoilData.Controls.Add(Me.Label11)
        Me.gpxSteelCoilData.Controls.Add(Me.Label3)
        Me.gpxSteelCoilData.Controls.Add(Me.Label6)
        Me.gpxSteelCoilData.Controls.Add(Me.Label1)
        Me.gpxSteelCoilData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpxSteelCoilData.Location = New System.Drawing.Point(21, 105)
        Me.gpxSteelCoilData.Name = "gpxSteelCoilData"
        Me.gpxSteelCoilData.Size = New System.Drawing.Size(343, 471)
        Me.gpxSteelCoilData.TabIndex = 0
        Me.gpxSteelCoilData.TabStop = False
        Me.gpxSteelCoilData.Text = "Steel Coil Information"
        '
        'txtLocation
        '
        Me.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocation.HideSelection = False
        Me.txtLocation.Location = New System.Drawing.Point(170, 249)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.ReadOnly = True
        Me.txtLocation.Size = New System.Drawing.Size(160, 26)
        Me.txtLocation.TabIndex = 55
        Me.txtLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 248)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(105, 20)
        Me.Label14.TabIndex = 56
        Me.Label14.Text = "Location"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInventoryID
        '
        Me.txtInventoryID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInventoryID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInventoryID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInventoryID.HideSelection = False
        Me.txtInventoryID.Location = New System.Drawing.Point(170, 217)
        Me.txtInventoryID.Name = "txtInventoryID"
        Me.txtInventoryID.Size = New System.Drawing.Size(160, 26)
        Me.txtInventoryID.TabIndex = 53
        Me.txtInventoryID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 216)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(105, 20)
        Me.Label12.TabIndex = 54
        Me.Label12.Text = "Inventory ID"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAnnealLot
        '
        Me.txtAnnealLot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnnealLot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAnnealLot.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnnealLot.HideSelection = False
        Me.txtAnnealLot.Location = New System.Drawing.Point(170, 185)
        Me.txtAnnealLot.Name = "txtAnnealLot"
        Me.txtAnnealLot.ReadOnly = True
        Me.txtAnnealLot.Size = New System.Drawing.Size(160, 26)
        Me.txtAnnealLot.TabIndex = 8
        Me.txtAnnealLot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 184)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 20)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Anneal Lot"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCoilDescription
        '
        Me.txtCoilDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilDescription.Location = New System.Drawing.Point(10, 300)
        Me.txtCoilDescription.Name = "txtCoilDescription"
        Me.txtCoilDescription.Size = New System.Drawing.Size(321, 62)
        Me.txtCoilDescription.TabIndex = 50
        '
        'txtCoilID
        '
        Me.txtCoilID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoilID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilID.HideSelection = False
        Me.txtCoilID.Location = New System.Drawing.Point(170, 19)
        Me.txtCoilID.Name = "txtCoilID"
        Me.txtCoilID.Size = New System.Drawing.Size(160, 26)
        Me.txtCoilID.TabIndex = 3
        Me.txtCoilID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(107, 153)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 20)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "(Required)"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(107, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 20)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "(Required)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(107, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 20)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "(Required)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(107, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 20)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "(Required)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboHeatNumber
        '
        Me.cboHeatNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHeatNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHeatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHeatNumber.FormattingEnabled = True
        Me.cboHeatNumber.Location = New System.Drawing.Point(170, 119)
        Me.cboHeatNumber.Name = "cboHeatNumber"
        Me.cboHeatNumber.Size = New System.Drawing.Size(160, 28)
        Me.cboHeatNumber.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 20)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Coil ID"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(170, 85)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(160, 28)
        Me.cboSteelSize.TabIndex = 5
        '
        'cboCarbon
        '
        Me.cboCarbon.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(170, 51)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(160, 28)
        Me.cboCarbon.TabIndex = 4
        '
        'txtCoilWeight
        '
        Me.txtCoilWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoilWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilWeight.Location = New System.Drawing.Point(170, 153)
        Me.txtCoilWeight.Name = "txtCoilWeight"
        Me.txtCoilWeight.Size = New System.Drawing.Size(160, 26)
        Me.txtCoilWeight.TabIndex = 7
        Me.txtCoilWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdAddCoil
        '
        Me.cmdAddCoil.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddCoil.Location = New System.Drawing.Point(64, 365)
        Me.cmdAddCoil.Name = "cmdAddCoil"
        Me.cmdAddCoil.Size = New System.Drawing.Size(100, 100)
        Me.cmdAddCoil.TabIndex = 9
        Me.cmdAddCoil.Text = "Remove From Yard"
        Me.cmdAddCoil.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(5, 88)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Size"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(7, 275)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Description"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 20)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Heat Number"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Carbon"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Coil Weight"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClearAll.Location = New System.Drawing.Point(814, 476)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(100, 100)
        Me.cmdClearAll.TabIndex = 10
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'dtpCoilUsageDate
        '
        Me.dtpCoilUsageDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpCoilUsageDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCoilUsageDate.Location = New System.Drawing.Point(170, 23)
        Me.dtpCoilUsageDate.Name = "dtpCoilUsageDate"
        Me.dtpCoilUsageDate.Size = New System.Drawing.Size(160, 26)
        Me.dtpCoilUsageDate.TabIndex = 18
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 29)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 20)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Post Date"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxColiIDEnter
        '
        Me.gpxColiIDEnter.Controls.Add(Me.dtpCoilUsageDate)
        Me.gpxColiIDEnter.Controls.Add(Me.Label13)
        Me.gpxColiIDEnter.Location = New System.Drawing.Point(21, 35)
        Me.gpxColiIDEnter.Name = "gpxColiIDEnter"
        Me.gpxColiIDEnter.Size = New System.Drawing.Size(343, 64)
        Me.gpxColiIDEnter.TabIndex = 17
        Me.gpxColiIDEnter.TabStop = False
        Me.gpxColiIDEnter.Text = "Posting Date"
        '
        'bgwkLoadCoilID
        '
        '
        'cmdZero
        '
        Me.cmdZero.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdZero.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdZero.Location = New System.Drawing.Point(382, 474)
        Me.cmdZero.Name = "cmdZero"
        Me.cmdZero.Size = New System.Drawing.Size(205, 100)
        Me.cmdZero.TabIndex = 18
        Me.cmdZero.Text = "0"
        Me.cmdZero.UseVisualStyleBackColor = True
        '
        'cmdDecimal
        '
        Me.cmdDecimal.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdDecimal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDecimal.Location = New System.Drawing.Point(594, 474)
        Me.cmdDecimal.Name = "cmdDecimal"
        Me.cmdDecimal.Size = New System.Drawing.Size(100, 100)
        Me.cmdDecimal.TabIndex = 19
        Me.cmdDecimal.Text = "."
        Me.cmdDecimal.UseVisualStyleBackColor = True
        '
        'cmdForwardSlash
        '
        Me.cmdForwardSlash.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdForwardSlash.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdForwardSlash.Location = New System.Drawing.Point(594, 51)
        Me.cmdForwardSlash.Name = "cmdForwardSlash"
        Me.cmdForwardSlash.Size = New System.Drawing.Size(100, 100)
        Me.cmdForwardSlash.TabIndex = 20
        Me.cmdForwardSlash.Text = "/"
        Me.cmdForwardSlash.UseVisualStyleBackColor = True
        '
        'cmdOne
        '
        Me.cmdOne.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOne.Location = New System.Drawing.Point(382, 368)
        Me.cmdOne.Name = "cmdOne"
        Me.cmdOne.Size = New System.Drawing.Size(100, 100)
        Me.cmdOne.TabIndex = 21
        Me.cmdOne.Text = "1"
        Me.cmdOne.UseVisualStyleBackColor = True
        '
        'cmdTwo
        '
        Me.cmdTwo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdTwo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTwo.Location = New System.Drawing.Point(488, 368)
        Me.cmdTwo.Name = "cmdTwo"
        Me.cmdTwo.Size = New System.Drawing.Size(100, 100)
        Me.cmdTwo.TabIndex = 22
        Me.cmdTwo.Text = "2"
        Me.cmdTwo.UseVisualStyleBackColor = True
        '
        'cmdThree
        '
        Me.cmdThree.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdThree.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThree.Location = New System.Drawing.Point(594, 368)
        Me.cmdThree.Name = "cmdThree"
        Me.cmdThree.Size = New System.Drawing.Size(100, 100)
        Me.cmdThree.TabIndex = 23
        Me.cmdThree.Text = "3"
        Me.cmdThree.UseVisualStyleBackColor = True
        '
        'cmdFour
        '
        Me.cmdFour.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdFour.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFour.Location = New System.Drawing.Point(382, 263)
        Me.cmdFour.Name = "cmdFour"
        Me.cmdFour.Size = New System.Drawing.Size(100, 100)
        Me.cmdFour.TabIndex = 24
        Me.cmdFour.Text = "4"
        Me.cmdFour.UseVisualStyleBackColor = True
        '
        'cmdFive
        '
        Me.cmdFive.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdFive.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFive.Location = New System.Drawing.Point(488, 263)
        Me.cmdFive.Name = "cmdFive"
        Me.cmdFive.Size = New System.Drawing.Size(100, 100)
        Me.cmdFive.TabIndex = 25
        Me.cmdFive.Text = "5"
        Me.cmdFive.UseVisualStyleBackColor = True
        '
        'cmdSix
        '
        Me.cmdSix.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdSix.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSix.Location = New System.Drawing.Point(594, 263)
        Me.cmdSix.Name = "cmdSix"
        Me.cmdSix.Size = New System.Drawing.Size(100, 100)
        Me.cmdSix.TabIndex = 26
        Me.cmdSix.Text = "6"
        Me.cmdSix.UseVisualStyleBackColor = True
        '
        'cmdSeven
        '
        Me.cmdSeven.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdSeven.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSeven.Location = New System.Drawing.Point(382, 157)
        Me.cmdSeven.Name = "cmdSeven"
        Me.cmdSeven.Size = New System.Drawing.Size(100, 100)
        Me.cmdSeven.TabIndex = 27
        Me.cmdSeven.Text = "7"
        Me.cmdSeven.UseVisualStyleBackColor = True
        '
        'cmdEight
        '
        Me.cmdEight.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdEight.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEight.Location = New System.Drawing.Point(488, 157)
        Me.cmdEight.Name = "cmdEight"
        Me.cmdEight.Size = New System.Drawing.Size(100, 100)
        Me.cmdEight.TabIndex = 28
        Me.cmdEight.Text = "8"
        Me.cmdEight.UseVisualStyleBackColor = True
        '
        'cmdNine
        '
        Me.cmdNine.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdNine.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNine.Location = New System.Drawing.Point(594, 157)
        Me.cmdNine.Name = "cmdNine"
        Me.cmdNine.Size = New System.Drawing.Size(100, 100)
        Me.cmdNine.TabIndex = 29
        Me.cmdNine.Text = "9"
        Me.cmdNine.UseVisualStyleBackColor = True
        '
        'cmdC
        '
        Me.cmdC.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdC.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdC.Location = New System.Drawing.Point(814, 262)
        Me.cmdC.Name = "cmdC"
        Me.cmdC.Size = New System.Drawing.Size(100, 100)
        Me.cmdC.TabIndex = 30
        Me.cmdC.Text = "C"
        Me.cmdC.UseVisualStyleBackColor = True
        '
        'cmdA
        '
        Me.cmdA.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdA.Location = New System.Drawing.Point(814, 50)
        Me.cmdA.Name = "cmdA"
        Me.cmdA.Size = New System.Drawing.Size(100, 100)
        Me.cmdA.TabIndex = 31
        Me.cmdA.Text = "A"
        Me.cmdA.UseVisualStyleBackColor = True
        '
        'cmdSA
        '
        Me.cmdSA.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdSA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSA.Location = New System.Drawing.Point(814, 368)
        Me.cmdSA.Name = "cmdSA"
        Me.cmdSA.Size = New System.Drawing.Size(100, 100)
        Me.cmdSA.TabIndex = 32
        Me.cmdSA.Text = "SA"
        Me.cmdSA.UseVisualStyleBackColor = True
        '
        'cmdFS
        '
        Me.cmdFS.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdFS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFS.Location = New System.Drawing.Point(1026, 262)
        Me.cmdFS.Name = "cmdFS"
        Me.cmdFS.Size = New System.Drawing.Size(100, 100)
        Me.cmdFS.TabIndex = 33
        Me.cmdFS.Text = "FS"
        Me.cmdFS.UseVisualStyleBackColor = True
        '
        'cmdBackspace
        '
        Me.cmdBackspace.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdBackspace.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBackspace.Location = New System.Drawing.Point(382, 53)
        Me.cmdBackspace.Name = "cmdBackspace"
        Me.cmdBackspace.Size = New System.Drawing.Size(205, 100)
        Me.cmdBackspace.TabIndex = 34
        Me.cmdBackspace.Text = "Backspace"
        Me.cmdBackspace.UseVisualStyleBackColor = True
        '
        'cmdTWD
        '
        Me.cmdTWD.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdTWD.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTWD.Location = New System.Drawing.Point(1026, 368)
        Me.cmdTWD.Name = "cmdTWD"
        Me.cmdTWD.Size = New System.Drawing.Size(100, 100)
        Me.cmdTWD.TabIndex = 35
        Me.cmdTWD.Text = "TWD"
        Me.cmdTWD.UseVisualStyleBackColor = True
        '
        'cmdDash
        '
        Me.cmdDash.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdDash.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDash.Location = New System.Drawing.Point(700, 51)
        Me.cmdDash.Name = "cmdDash"
        Me.cmdDash.Size = New System.Drawing.Size(100, 100)
        Me.cmdDash.TabIndex = 36
        Me.cmdDash.Text = "-"
        Me.cmdDash.UseVisualStyleBackColor = True
        '
        'lstCoilIDSuggest
        '
        Me.lstCoilIDSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCoilIDSuggest.FormattingEnabled = True
        Me.lstCoilIDSuggest.ItemHeight = 20
        Me.lstCoilIDSuggest.Location = New System.Drawing.Point(191, 150)
        Me.lstCoilIDSuggest.Name = "lstCoilIDSuggest"
        Me.lstCoilIDSuggest.Size = New System.Drawing.Size(200, 84)
        Me.lstCoilIDSuggest.TabIndex = 37
        Me.lstCoilIDSuggest.TabStop = False
        Me.lstCoilIDSuggest.Visible = False
        '
        'lstCarbonSuggest
        '
        Me.lstCarbonSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCarbonSuggest.FormattingEnabled = True
        Me.lstCarbonSuggest.ItemHeight = 20
        Me.lstCarbonSuggest.Location = New System.Drawing.Point(191, 184)
        Me.lstCarbonSuggest.Name = "lstCarbonSuggest"
        Me.lstCarbonSuggest.Size = New System.Drawing.Size(160, 84)
        Me.lstCarbonSuggest.TabIndex = 38
        Me.lstCarbonSuggest.TabStop = False
        Me.lstCarbonSuggest.Visible = False
        '
        'lstSizeSuggest
        '
        Me.lstSizeSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSizeSuggest.FormattingEnabled = True
        Me.lstSizeSuggest.ItemHeight = 20
        Me.lstSizeSuggest.Location = New System.Drawing.Point(191, 218)
        Me.lstSizeSuggest.Name = "lstSizeSuggest"
        Me.lstSizeSuggest.Size = New System.Drawing.Size(160, 84)
        Me.lstSizeSuggest.TabIndex = 39
        Me.lstSizeSuggest.TabStop = False
        Me.lstSizeSuggest.Visible = False
        '
        'lstHeatSuggest
        '
        Me.lstHeatSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstHeatSuggest.FormattingEnabled = True
        Me.lstHeatSuggest.ItemHeight = 20
        Me.lstHeatSuggest.Location = New System.Drawing.Point(191, 252)
        Me.lstHeatSuggest.Name = "lstHeatSuggest"
        Me.lstHeatSuggest.Size = New System.Drawing.Size(160, 84)
        Me.lstHeatSuggest.TabIndex = 40
        Me.lstHeatSuggest.TabStop = False
        Me.lstHeatSuggest.Visible = False
        '
        'cmdSS
        '
        Me.cmdSS.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdSS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSS.Location = New System.Drawing.Point(920, 368)
        Me.cmdSS.Name = "cmdSS"
        Me.cmdSS.Size = New System.Drawing.Size(100, 100)
        Me.cmdSS.TabIndex = 41
        Me.cmdSS.Text = "SS"
        Me.cmdSS.UseVisualStyleBackColor = True
        '
        'cmdALM
        '
        Me.cmdALM.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdALM.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdALM.Location = New System.Drawing.Point(920, 50)
        Me.cmdALM.Name = "cmdALM"
        Me.cmdALM.Size = New System.Drawing.Size(100, 100)
        Me.cmdALM.TabIndex = 44
        Me.cmdALM.Text = "ALM"
        Me.cmdALM.UseVisualStyleBackColor = True
        '
        'cmdALUM
        '
        Me.cmdALUM.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdALUM.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdALUM.Location = New System.Drawing.Point(1026, 50)
        Me.cmdALUM.Name = "cmdALUM"
        Me.cmdALUM.Size = New System.Drawing.Size(100, 100)
        Me.cmdALUM.TabIndex = 43
        Me.cmdALUM.Text = "ALUM"
        Me.cmdALUM.UseVisualStyleBackColor = True
        '
        'cmdCDA
        '
        Me.cmdCDA.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdCDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCDA.Location = New System.Drawing.Point(920, 262)
        Me.cmdCDA.Name = "cmdCDA"
        Me.cmdCDA.Size = New System.Drawing.Size(100, 100)
        Me.cmdCDA.TabIndex = 42
        Me.cmdCDA.Text = "CDA"
        Me.cmdCDA.UseVisualStyleBackColor = True
        '
        'cmdBRN
        '
        Me.cmdBRN.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdBRN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBRN.Location = New System.Drawing.Point(920, 156)
        Me.cmdBRN.Name = "cmdBRN"
        Me.cmdBRN.Size = New System.Drawing.Size(100, 100)
        Me.cmdBRN.TabIndex = 47
        Me.cmdBRN.Text = "BRN"
        Me.cmdBRN.UseVisualStyleBackColor = True
        '
        'cmdBRS
        '
        Me.cmdBRS.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdBRS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBRS.Location = New System.Drawing.Point(1026, 156)
        Me.cmdBRS.Name = "cmdBRS"
        Me.cmdBRS.Size = New System.Drawing.Size(100, 100)
        Me.cmdBRS.TabIndex = 46
        Me.cmdBRS.Text = "BRS"
        Me.cmdBRS.UseVisualStyleBackColor = True
        '
        'cmdBRASS
        '
        Me.cmdBRASS.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdBRASS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBRASS.Location = New System.Drawing.Point(814, 156)
        Me.cmdBRASS.Name = "cmdBRASS"
        Me.cmdBRASS.Size = New System.Drawing.Size(100, 100)
        Me.cmdBRASS.TabIndex = 45
        Me.cmdBRASS.Text = "BRASS"
        Me.cmdBRASS.UseVisualStyleBackColor = True
        '
        'bgwkCoilIDSuggest
        '
        Me.bgwkCoilIDSuggest.WorkerSupportsCancellation = True
        '
        'cmdEnter
        '
        Me.cmdEnter.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEnter.Location = New System.Drawing.Point(700, 368)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(100, 205)
        Me.cmdEnter.TabIndex = 48
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(700, 157)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(100, 205)
        Me.cmdClear.TabIndex = 49
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'tmrScanTime
        '
        '
        'lstInventoryIDSuggest
        '
        Me.lstInventoryIDSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstInventoryIDSuggest.FormattingEnabled = True
        Me.lstInventoryIDSuggest.ItemHeight = 20
        Me.lstInventoryIDSuggest.Location = New System.Drawing.Point(191, 348)
        Me.lstInventoryIDSuggest.Name = "lstInventoryIDSuggest"
        Me.lstInventoryIDSuggest.Size = New System.Drawing.Size(160, 84)
        Me.lstInventoryIDSuggest.TabIndex = 50
        Me.lstInventoryIDSuggest.TabStop = False
        Me.lstInventoryIDSuggest.Visible = False
        '
        'cmdOSA
        '
        Me.cmdOSA.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdOSA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOSA.Location = New System.Drawing.Point(920, 476)
        Me.cmdOSA.Name = "cmdOSA"
        Me.cmdOSA.Size = New System.Drawing.Size(100, 100)
        Me.cmdOSA.TabIndex = 51
        Me.cmdOSA.Text = "OSA"
        Me.cmdOSA.UseVisualStyleBackColor = True
        '
        'SteelWireYardRemoval
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1135, 588)
        Me.Controls.Add(Me.cmdOSA)
        Me.Controls.Add(Me.lstInventoryIDSuggest)
        Me.Controls.Add(Me.lstHeatSuggest)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdEnter)
        Me.Controls.Add(Me.cmdBRN)
        Me.Controls.Add(Me.cmdBRS)
        Me.Controls.Add(Me.cmdBRASS)
        Me.Controls.Add(Me.cmdALM)
        Me.Controls.Add(Me.cmdALUM)
        Me.Controls.Add(Me.cmdCDA)
        Me.Controls.Add(Me.cmdSS)
        Me.Controls.Add(Me.lstSizeSuggest)
        Me.Controls.Add(Me.lstCarbonSuggest)
        Me.Controls.Add(Me.lstCoilIDSuggest)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdDash)
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
        Me.Controls.Add(Me.gpxColiIDEnter)
        Me.Controls.Add(Me.gpxSteelCoilData)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "SteelWireYardRemoval"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Wire Yard  Removal"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxSteelCoilData.ResumeLayout(False)
        Me.gpxSteelCoilData.PerformLayout()
        Me.gpxColiIDEnter.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxSteelCoilData As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAddCoil As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gpxColiIDEnter As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpCoilUsageDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents txtCoilWeight As System.Windows.Forms.TextBox
    Friend WithEvents SteelUsageKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsageDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoilIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsageWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents cboHeatNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents bgwkLoadCoilID As System.ComponentModel.BackgroundWorker
    Friend WithEvents cmdZero As System.Windows.Forms.Button
    Friend WithEvents cmdDecimal As System.Windows.Forms.Button
    Friend WithEvents cmdForwardSlash As System.Windows.Forms.Button
    Friend WithEvents cmdOne As System.Windows.Forms.Button
    Friend WithEvents cmdTwo As System.Windows.Forms.Button
    Friend WithEvents cmdThree As System.Windows.Forms.Button
    Friend WithEvents cmdFour As System.Windows.Forms.Button
    Friend WithEvents cmdFive As System.Windows.Forms.Button
    Friend WithEvents cmdSix As System.Windows.Forms.Button
    Friend WithEvents cmdSeven As System.Windows.Forms.Button
    Friend WithEvents cmdEight As System.Windows.Forms.Button
    Friend WithEvents cmdNine As System.Windows.Forms.Button
    Friend WithEvents cmdC As System.Windows.Forms.Button
    Friend WithEvents cmdA As System.Windows.Forms.Button
    Friend WithEvents cmdSA As System.Windows.Forms.Button
    Friend WithEvents cmdFS As System.Windows.Forms.Button
    Friend WithEvents txtCoilID As System.Windows.Forms.TextBox
    Friend WithEvents cmdBackspace As System.Windows.Forms.Button
    Friend WithEvents txtCoilDescription As System.Windows.Forms.Label
    Friend WithEvents cmdTWD As System.Windows.Forms.Button
    Friend WithEvents cmdDash As System.Windows.Forms.Button
    Friend WithEvents lstCoilIDSuggest As System.Windows.Forms.ListBox
    Friend WithEvents lstCarbonSuggest As System.Windows.Forms.ListBox
    Friend WithEvents lstSizeSuggest As System.Windows.Forms.ListBox
    Friend WithEvents lstHeatSuggest As System.Windows.Forms.ListBox
    Friend WithEvents cmdSS As System.Windows.Forms.Button
    Friend WithEvents cmdALM As System.Windows.Forms.Button
    Friend WithEvents cmdALUM As System.Windows.Forms.Button
    Friend WithEvents cmdCDA As System.Windows.Forms.Button
    Friend WithEvents cmdBRN As System.Windows.Forms.Button
    Friend WithEvents cmdBRS As System.Windows.Forms.Button
    Friend WithEvents cmdBRASS As System.Windows.Forms.Button
    Friend WithEvents bgwkCoilIDSuggest As System.ComponentModel.BackgroundWorker
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents txtAnnealLot As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tmrScanTime As System.Windows.Forms.Timer
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtInventoryID As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lstInventoryIDSuggest As System.Windows.Forms.ListBox
    Friend WithEvents cmdOSA As System.Windows.Forms.Button
End Class
