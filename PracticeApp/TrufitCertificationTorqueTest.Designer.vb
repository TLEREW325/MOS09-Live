<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrufitCertificationTorqueTest
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gpxTestInfo = New System.Windows.Forms.GroupBox
        Me.lblPartDescription = New System.Windows.Forms.Label
        Me.lblHeatNumber = New System.Windows.Forms.Label
        Me.cboLotNumber = New System.Windows.Forms.ComboBox
        Me.cboTestNumber = New System.Windows.Forms.ComboBox
        Me.dtpCreatedDate = New System.Windows.Forms.DateTimePicker
        Me.lblPartNumber = New System.Windows.Forms.Label
        Me.lblHeatDisplay = New System.Windows.Forms.Label
        Me.cmdGenerateTestNumber = New System.Windows.Forms.Button
        Me.lblTestNumber = New System.Windows.Forms.Label
        Me.lblCreationDate = New System.Windows.Forms.Label
        Me.lblLotNumberDisplay = New System.Windows.Forms.Label
        Me.lblPartDisplay = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnLockTestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxSampleEntry = New System.Windows.Forms.GroupBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdAddSample = New System.Windows.Forms.Button
        Me.txtActualTorque = New System.Windows.Forms.TextBox
        Me.txtResults = New System.Windows.Forms.TextBox
        Me.lblResults = New System.Windows.Forms.Label
        Me.lblProofPound = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdFinish = New System.Windows.Forms.Button
        Me.gpxSignOffEntry = New System.Windows.Forms.GroupBox
        Me.lblTestedBy = New System.Windows.Forms.Label
        Me.txtTestedBy = New System.Windows.Forms.TextBox
        Me.txtApprovedBy = New System.Windows.Forms.TextBox
        Me.lblApprovedBy = New System.Windows.Forms.Label
        Me.gpxDeleteRow = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDeleteResultNumber = New System.Windows.Forms.ComboBox
        Me.cmdDeleteRow = New System.Windows.Forms.Button
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.dgvResultData = New System.Windows.Forms.DataGridView
        Me.gpxTestInfo.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.gpxSampleEntry.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gpxSignOffEntry.SuspendLayout()
        Me.gpxDeleteRow.SuspendLayout()
        CType(Me.dgvResultData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpxTestInfo
        '
        Me.gpxTestInfo.Controls.Add(Me.lblPartDescription)
        Me.gpxTestInfo.Controls.Add(Me.lblHeatNumber)
        Me.gpxTestInfo.Controls.Add(Me.cboLotNumber)
        Me.gpxTestInfo.Controls.Add(Me.cboTestNumber)
        Me.gpxTestInfo.Controls.Add(Me.dtpCreatedDate)
        Me.gpxTestInfo.Controls.Add(Me.lblPartNumber)
        Me.gpxTestInfo.Controls.Add(Me.lblHeatDisplay)
        Me.gpxTestInfo.Controls.Add(Me.cmdGenerateTestNumber)
        Me.gpxTestInfo.Controls.Add(Me.lblTestNumber)
        Me.gpxTestInfo.Controls.Add(Me.lblCreationDate)
        Me.gpxTestInfo.Controls.Add(Me.lblLotNumberDisplay)
        Me.gpxTestInfo.Controls.Add(Me.lblPartDisplay)
        Me.gpxTestInfo.Location = New System.Drawing.Point(12, 42)
        Me.gpxTestInfo.Name = "gpxTestInfo"
        Me.gpxTestInfo.Size = New System.Drawing.Size(293, 323)
        Me.gpxTestInfo.TabIndex = 1
        Me.gpxTestInfo.TabStop = False
        Me.gpxTestInfo.Text = "Test Information"
        '
        'lblPartDescription
        '
        Me.lblPartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartDescription.Location = New System.Drawing.Point(20, 217)
        Me.lblPartDescription.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.lblPartDescription.Name = "lblPartDescription"
        Me.lblPartDescription.Size = New System.Drawing.Size(255, 89)
        Me.lblPartDescription.TabIndex = 47
        '
        'lblHeatNumber
        '
        Me.lblHeatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHeatNumber.Location = New System.Drawing.Point(86, 142)
        Me.lblHeatNumber.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.lblHeatNumber.Name = "lblHeatNumber"
        Me.lblHeatNumber.Size = New System.Drawing.Size(188, 21)
        Me.lblHeatNumber.TabIndex = 40
        '
        'cboLotNumber
        '
        Me.cboLotNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLotNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLotNumber.FormattingEnabled = True
        Me.cboLotNumber.Location = New System.Drawing.Point(87, 105)
        Me.cboLotNumber.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.cboLotNumber.Name = "cboLotNumber"
        Me.cboLotNumber.Size = New System.Drawing.Size(188, 21)
        Me.cboLotNumber.TabIndex = 4
        '
        'cboTestNumber
        '
        Me.cboTestNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTestNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTestNumber.FormattingEnabled = True
        Me.cboTestNumber.Location = New System.Drawing.Point(88, 32)
        Me.cboTestNumber.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.cboTestNumber.Name = "cboTestNumber"
        Me.cboTestNumber.Size = New System.Drawing.Size(187, 21)
        Me.cboTestNumber.TabIndex = 1
        '
        'dtpCreatedDate
        '
        Me.dtpCreatedDate.Enabled = False
        Me.dtpCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCreatedDate.Location = New System.Drawing.Point(87, 69)
        Me.dtpCreatedDate.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.dtpCreatedDate.Name = "dtpCreatedDate"
        Me.dtpCreatedDate.Size = New System.Drawing.Size(188, 20)
        Me.dtpCreatedDate.TabIndex = 3
        '
        'lblPartNumber
        '
        Me.lblPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartNumber.Location = New System.Drawing.Point(56, 179)
        Me.lblPartNumber.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.lblPartNumber.Name = "lblPartNumber"
        Me.lblPartNumber.Size = New System.Drawing.Size(218, 21)
        Me.lblPartNumber.TabIndex = 39
        '
        'lblHeatDisplay
        '
        Me.lblHeatDisplay.Location = New System.Drawing.Point(14, 142)
        Me.lblHeatDisplay.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.lblHeatDisplay.Name = "lblHeatDisplay"
        Me.lblHeatDisplay.Size = New System.Drawing.Size(83, 20)
        Me.lblHeatDisplay.TabIndex = 38
        Me.lblHeatDisplay.Text = "Heat #"
        Me.lblHeatDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdGenerateTestNumber
        '
        Me.cmdGenerateTestNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateTestNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateTestNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateTestNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateTestNumber.Location = New System.Drawing.Point(56, 32)
        Me.cmdGenerateTestNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateTestNumber.Name = "cmdGenerateTestNumber"
        Me.cmdGenerateTestNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateTestNumber.TabIndex = 0
        Me.cmdGenerateTestNumber.TabStop = False
        Me.cmdGenerateTestNumber.Text = ">>"
        Me.cmdGenerateTestNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateTestNumber.UseVisualStyleBackColor = False
        '
        'lblTestNumber
        '
        Me.lblTestNumber.Location = New System.Drawing.Point(14, 32)
        Me.lblTestNumber.Name = "lblTestNumber"
        Me.lblTestNumber.Size = New System.Drawing.Size(83, 20)
        Me.lblTestNumber.TabIndex = 4
        Me.lblTestNumber.Text = "Test #"
        Me.lblTestNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreationDate
        '
        Me.lblCreationDate.Location = New System.Drawing.Point(14, 67)
        Me.lblCreationDate.Name = "lblCreationDate"
        Me.lblCreationDate.Size = New System.Drawing.Size(83, 20)
        Me.lblCreationDate.TabIndex = 9
        Me.lblCreationDate.Text = "Testing Date"
        Me.lblCreationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLotNumberDisplay
        '
        Me.lblLotNumberDisplay.Location = New System.Drawing.Point(14, 105)
        Me.lblLotNumberDisplay.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.lblLotNumberDisplay.Name = "lblLotNumberDisplay"
        Me.lblLotNumberDisplay.Size = New System.Drawing.Size(83, 20)
        Me.lblLotNumberDisplay.TabIndex = 24
        Me.lblLotNumberDisplay.Text = "Lot #"
        Me.lblLotNumberDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPartDisplay
        '
        Me.lblPartDisplay.Location = New System.Drawing.Point(14, 179)
        Me.lblPartDisplay.Name = "lblPartDisplay"
        Me.lblPartDisplay.Size = New System.Drawing.Size(83, 20)
        Me.lblPartDisplay.TabIndex = 10
        Me.lblPartDisplay.Text = "Part #"
        Me.lblPartDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveDataToolStripMenuItem, Me.DeleteDataToolStripMenuItem, Me.PrintDataToolStripMenuItem, Me.ClearDataToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveDataToolStripMenuItem
        '
        Me.SaveDataToolStripMenuItem.Name = "SaveDataToolStripMenuItem"
        Me.SaveDataToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.SaveDataToolStripMenuItem.Text = "Save Data"
        '
        'DeleteDataToolStripMenuItem
        '
        Me.DeleteDataToolStripMenuItem.Name = "DeleteDataToolStripMenuItem"
        Me.DeleteDataToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.DeleteDataToolStripMenuItem.Text = "Delete Data"
        '
        'PrintDataToolStripMenuItem
        '
        Me.PrintDataToolStripMenuItem.Name = "PrintDataToolStripMenuItem"
        Me.PrintDataToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.PrintDataToolStripMenuItem.Text = "Print Data"
        '
        'ClearDataToolStripMenuItem
        '
        Me.ClearDataToolStripMenuItem.Name = "ClearDataToolStripMenuItem"
        Me.ClearDataToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.ClearDataToolStripMenuItem.Text = "Clear Data"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UnLockTestToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'UnLockTestToolStripMenuItem
        '
        Me.UnLockTestToolStripMenuItem.Name = "UnLockTestToolStripMenuItem"
        Me.UnLockTestToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.UnLockTestToolStripMenuItem.Text = "Un-Lock Test"
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
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'gpxSampleEntry
        '
        Me.gpxSampleEntry.Controls.Add(Me.cmdClear)
        Me.gpxSampleEntry.Controls.Add(Me.cmdAddSample)
        Me.gpxSampleEntry.Controls.Add(Me.txtActualTorque)
        Me.gpxSampleEntry.Controls.Add(Me.txtResults)
        Me.gpxSampleEntry.Controls.Add(Me.lblResults)
        Me.gpxSampleEntry.Controls.Add(Me.lblProofPound)
        Me.gpxSampleEntry.Location = New System.Drawing.Point(12, 420)
        Me.gpxSampleEntry.Name = "gpxSampleEntry"
        Me.gpxSampleEntry.Size = New System.Drawing.Size(293, 224)
        Me.gpxSampleEntry.TabIndex = 4
        Me.gpxSampleEntry.TabStop = False
        Me.gpxSampleEntry.Text = "Sample Entry"
        '
        'cmdClear
        '
        Me.cmdClear.ForeColor = System.Drawing.Color.Black
        Me.cmdClear.Location = New System.Drawing.Point(201, 163)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdAddSample
        '
        Me.cmdAddSample.Location = New System.Drawing.Point(124, 163)
        Me.cmdAddSample.Name = "cmdAddSample"
        Me.cmdAddSample.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddSample.TabIndex = 13
        Me.cmdAddSample.Text = "Add Sample"
        Me.cmdAddSample.UseVisualStyleBackColor = True
        '
        'txtActualTorque
        '
        Me.txtActualTorque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActualTorque.Location = New System.Drawing.Point(99, 35)
        Me.txtActualTorque.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.txtActualTorque.Name = "txtActualTorque"
        Me.txtActualTorque.Size = New System.Drawing.Size(173, 20)
        Me.txtActualTorque.TabIndex = 6
        Me.txtActualTorque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtResults
        '
        Me.txtResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResults.Location = New System.Drawing.Point(17, 87)
        Me.txtResults.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.txtResults.MaxLength = 200
        Me.txtResults.Multiline = True
        Me.txtResults.Name = "txtResults"
        Me.txtResults.Size = New System.Drawing.Size(255, 66)
        Me.txtResults.TabIndex = 12
        '
        'lblResults
        '
        Me.lblResults.AutoSize = True
        Me.lblResults.Location = New System.Drawing.Point(14, 71)
        Me.lblResults.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.lblResults.Name = "lblResults"
        Me.lblResults.Size = New System.Drawing.Size(49, 13)
        Me.lblResults.TabIndex = 22
        Me.lblResults.Text = "Remarks"
        '
        'lblProofPound
        '
        Me.lblProofPound.Location = New System.Drawing.Point(18, 37)
        Me.lblProofPound.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.lblProofPound.Name = "lblProofPound"
        Me.lblProofPound.Size = New System.Drawing.Size(100, 20)
        Me.lblProofPound.TabIndex = 14
        Me.lblProofPound.Text = "Actual Ft. lbs"
        Me.lblProofPound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmdFinish)
        Me.GroupBox1.Location = New System.Drawing.Point(728, 671)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(302, 81)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Complete"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(22, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 40)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Locks the Test so no more changes can be made."
        '
        'cmdFinish
        '
        Me.cmdFinish.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFinish.Location = New System.Drawing.Point(213, 27)
        Me.cmdFinish.Name = "cmdFinish"
        Me.cmdFinish.Size = New System.Drawing.Size(71, 40)
        Me.cmdFinish.TabIndex = 39
        Me.cmdFinish.Text = "Finish Entry"
        Me.cmdFinish.UseVisualStyleBackColor = True
        '
        'gpxSignOffEntry
        '
        Me.gpxSignOffEntry.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gpxSignOffEntry.Controls.Add(Me.lblTestedBy)
        Me.gpxSignOffEntry.Controls.Add(Me.txtTestedBy)
        Me.gpxSignOffEntry.Controls.Add(Me.txtApprovedBy)
        Me.gpxSignOffEntry.Controls.Add(Me.lblApprovedBy)
        Me.gpxSignOffEntry.Location = New System.Drawing.Point(12, 692)
        Me.gpxSignOffEntry.Name = "gpxSignOffEntry"
        Me.gpxSignOffEntry.Size = New System.Drawing.Size(293, 119)
        Me.gpxSignOffEntry.TabIndex = 44
        Me.gpxSignOffEntry.TabStop = False
        Me.gpxSignOffEntry.Text = "Sign Off Entry"
        '
        'lblTestedBy
        '
        Me.lblTestedBy.AutoSize = True
        Me.lblTestedBy.Location = New System.Drawing.Point(15, 40)
        Me.lblTestedBy.Name = "lblTestedBy"
        Me.lblTestedBy.Size = New System.Drawing.Size(55, 13)
        Me.lblTestedBy.TabIndex = 26
        Me.lblTestedBy.Text = "Tested By"
        '
        'txtTestedBy
        '
        Me.txtTestedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTestedBy.Location = New System.Drawing.Point(86, 40)
        Me.txtTestedBy.Name = "txtTestedBy"
        Me.txtTestedBy.Size = New System.Drawing.Size(189, 20)
        Me.txtTestedBy.TabIndex = 13
        '
        'txtApprovedBy
        '
        Me.txtApprovedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApprovedBy.Location = New System.Drawing.Point(86, 81)
        Me.txtApprovedBy.Name = "txtApprovedBy"
        Me.txtApprovedBy.Size = New System.Drawing.Size(189, 20)
        Me.txtApprovedBy.TabIndex = 14
        '
        'lblApprovedBy
        '
        Me.lblApprovedBy.AutoSize = True
        Me.lblApprovedBy.Location = New System.Drawing.Point(15, 81)
        Me.lblApprovedBy.Name = "lblApprovedBy"
        Me.lblApprovedBy.Size = New System.Drawing.Size(68, 13)
        Me.lblApprovedBy.TabIndex = 28
        Me.lblApprovedBy.Text = "Approved By"
        '
        'gpxDeleteRow
        '
        Me.gpxDeleteRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxDeleteRow.Controls.Add(Me.Label1)
        Me.gpxDeleteRow.Controls.Add(Me.cboDeleteResultNumber)
        Me.gpxDeleteRow.Controls.Add(Me.cmdDeleteRow)
        Me.gpxDeleteRow.Location = New System.Drawing.Point(319, 671)
        Me.gpxDeleteRow.Name = "gpxDeleteRow"
        Me.gpxDeleteRow.Size = New System.Drawing.Size(354, 81)
        Me.gpxDeleteRow.TabIndex = 45
        Me.gpxDeleteRow.TabStop = False
        Me.gpxDeleteRow.Text = "Delete Entry"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Sample Number"
        '
        'cboDeleteResultNumber
        '
        Me.cboDeleteResultNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDeleteResultNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDeleteResultNumber.FormattingEnabled = True
        Me.cboDeleteResultNumber.Location = New System.Drawing.Point(104, 27)
        Me.cboDeleteResultNumber.Name = "cboDeleteResultNumber"
        Me.cboDeleteResultNumber.Size = New System.Drawing.Size(136, 21)
        Me.cboDeleteResultNumber.TabIndex = 42
        '
        'cmdDeleteRow
        '
        Me.cmdDeleteRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteRow.Location = New System.Drawing.Point(267, 17)
        Me.cmdDeleteRow.Name = "cmdDeleteRow"
        Me.cmdDeleteRow.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteRow.TabIndex = 39
        Me.cmdDeleteRow.Text = "Delete Entry"
        Me.cmdDeleteRow.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.ForeColor = System.Drawing.Color.Black
        Me.cmdClearAll.Location = New System.Drawing.Point(319, 773)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 47
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 51
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 50
        Me.cmdPrint.Text = "Print Test"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(805, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 49
        Me.cmdDelete.Text = "Delete Test"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(728, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 48
        Me.cmdSave.Text = "Save Test"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'dgvResultData
        '
        Me.dgvResultData.AllowUserToAddRows = False
        Me.dgvResultData.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvResultData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvResultData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvResultData.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvResultData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvResultData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultData.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvResultData.Location = New System.Drawing.Point(319, 42)
        Me.dgvResultData.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.dgvResultData.Name = "dgvResultData"
        Me.dgvResultData.Size = New System.Drawing.Size(711, 623)
        Me.dgvResultData.TabIndex = 52
        Me.dgvResultData.TabStop = False
        '
        'TrufitCertificationTorqueTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.dgvResultData)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpxSignOffEntry)
        Me.Controls.Add(Me.gpxDeleteRow)
        Me.Controls.Add(Me.gpxSampleEntry)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.gpxTestInfo)
        Me.Name = "TrufitCertificationTorqueTest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Trufit Certification Torque Test"
        Me.gpxTestInfo.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxSampleEntry.ResumeLayout(False)
        Me.gpxSampleEntry.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.gpxSignOffEntry.ResumeLayout(False)
        Me.gpxSignOffEntry.PerformLayout()
        Me.gpxDeleteRow.ResumeLayout(False)
        Me.gpxDeleteRow.PerformLayout()
        CType(Me.dgvResultData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpxTestInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblPartDescription As System.Windows.Forms.Label
    Friend WithEvents lblHeatNumber As System.Windows.Forms.Label
    Friend WithEvents cboLotNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboTestNumber As System.Windows.Forms.ComboBox
    Friend WithEvents dtpCreatedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPartNumber As System.Windows.Forms.Label
    Friend WithEvents lblHeatDisplay As System.Windows.Forms.Label
    Friend WithEvents cmdGenerateTestNumber As System.Windows.Forms.Button
    Friend WithEvents lblTestNumber As System.Windows.Forms.Label
    Friend WithEvents lblCreationDate As System.Windows.Forms.Label
    Friend WithEvents lblLotNumberDisplay As System.Windows.Forms.Label
    Friend WithEvents lblPartDisplay As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnLockTestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxSampleEntry As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdAddSample As System.Windows.Forms.Button
    Friend WithEvents txtActualTorque As System.Windows.Forms.TextBox
    Friend WithEvents txtResults As System.Windows.Forms.TextBox
    Friend WithEvents lblResults As System.Windows.Forms.Label
    Friend WithEvents lblProofPound As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdFinish As System.Windows.Forms.Button
    Friend WithEvents gpxSignOffEntry As System.Windows.Forms.GroupBox
    Friend WithEvents lblTestedBy As System.Windows.Forms.Label
    Friend WithEvents txtTestedBy As System.Windows.Forms.TextBox
    Friend WithEvents txtApprovedBy As System.Windows.Forms.TextBox
    Friend WithEvents lblApprovedBy As System.Windows.Forms.Label
    Friend WithEvents gpxDeleteRow As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDeleteResultNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdDeleteRow As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents dgvResultData As System.Windows.Forms.DataGridView
End Class
