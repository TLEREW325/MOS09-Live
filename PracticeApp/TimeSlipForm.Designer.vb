<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimeSlipForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dtpTimeSlipDate = New System.Windows.Forms.DateTimePicker
        Me.lblDate = New System.Windows.Forms.Label
        Me.lblEmployeeNumber = New System.Windows.Forms.Label
        Me.lblFOXNumber = New System.Windows.Forms.Label
        Me.lblMachineNumber = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxTimeSlip = New System.Windows.Forms.GroupBox
        Me.cboShiftNumber = New System.Windows.Forms.ComboBox
        Me.lblEmployeeName = New System.Windows.Forms.Label
        Me.cboEmployeeID = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblShift = New System.Windows.Forms.Label
        Me.lblTotalHours = New System.Windows.Forms.Label
        Me.lblOtherHours = New System.Windows.Forms.Label
        Me.lblToolingHours = New System.Windows.Forms.Label
        Me.lblSetupHours = New System.Windows.Forms.Label
        Me.lblMachineHours = New System.Windows.Forms.Label
        Me.lblPartNumber = New System.Windows.Forms.Label
        Me.gbxProductionEntry = New System.Windows.Forms.GroupBox
        Me.chkFromAnotherPart = New System.Windows.Forms.CheckBox
        Me.chkRollerAttached = New System.Windows.Forms.CheckBox
        Me.txtPartDescription = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblPieceWeightSingle = New System.Windows.Forms.Label
        Me.lblPieceWeightPer1000 = New System.Windows.Forms.Label
        Me.txtPartNumber = New System.Windows.Forms.TextBox
        Me.cboDiameter = New System.Windows.Forms.ComboBox
        Me.cboFOXNumber = New System.Windows.Forms.ComboBox
        Me.lblPW = New System.Windows.Forms.Label
        Me.cboMachineNumber = New System.Windows.Forms.ComboBox
        Me.lblPWP1000 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtWeightProduced = New System.Windows.Forms.TextBox
        Me.txtPiecesProduced = New System.Windows.Forms.TextBox
        Me.lblTotalLineHours = New System.Windows.Forms.Label
        Me.txtScrapWeight = New System.Windows.Forms.TextBox
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblScrapWeight = New System.Windows.Forms.Label
        Me.cmdEnterData = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.lblPieceWeight = New System.Windows.Forms.Label
        Me.lblPieces = New System.Windows.Forms.Label
        Me.txtOtherHours = New System.Windows.Forms.TextBox
        Me.txtToolingHours = New System.Windows.Forms.TextBox
        Me.txtSetupHours = New System.Windows.Forms.TextBox
        Me.txtMachineHours = New System.Windows.Forms.TextBox
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.TSMenu01 = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdPrintTimeSlip = New System.Windows.Forms.Button
        Me.gpxFOXRouting = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgvFOXRouting = New System.Windows.Forms.DataGridView
        Me.dgvTimeSlipLines = New System.Windows.Forms.DataGridView
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboDeleteLine = New System.Windows.Forms.ComboBox
        Me.cmdDeleteEntry = New System.Windows.Forms.Button
        Me.gpxTimeSlip.SuspendLayout()
        Me.gbxProductionEntry.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.gpxFOXRouting.SuspendLayout()
        CType(Me.dgvFOXRouting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTimeSlipLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpTimeSlipDate
        '
        Me.dtpTimeSlipDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTimeSlipDate.Location = New System.Drawing.Point(127, 19)
        Me.dtpTimeSlipDate.Name = "dtpTimeSlipDate"
        Me.dtpTimeSlipDate.Size = New System.Drawing.Size(172, 20)
        Me.dtpTimeSlipDate.TabIndex = 3
        Me.dtpTimeSlipDate.TabStop = False
        '
        'lblDate
        '
        Me.lblDate.Location = New System.Drawing.Point(9, 19)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(98, 20)
        Me.lblDate.TabIndex = 1
        Me.lblDate.Text = "Date"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmployeeNumber
        '
        Me.lblEmployeeNumber.Location = New System.Drawing.Point(9, 46)
        Me.lblEmployeeNumber.Name = "lblEmployeeNumber"
        Me.lblEmployeeNumber.Size = New System.Drawing.Size(98, 20)
        Me.lblEmployeeNumber.TabIndex = 2
        Me.lblEmployeeNumber.Text = "Employee Number"
        Me.lblEmployeeNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFOXNumber
        '
        Me.lblFOXNumber.Location = New System.Drawing.Point(9, 22)
        Me.lblFOXNumber.Name = "lblFOXNumber"
        Me.lblFOXNumber.Size = New System.Drawing.Size(98, 20)
        Me.lblFOXNumber.TabIndex = 3
        Me.lblFOXNumber.Text = "FOX Number"
        Me.lblFOXNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMachineNumber
        '
        Me.lblMachineNumber.Location = New System.Drawing.Point(9, 138)
        Me.lblMachineNumber.Name = "lblMachineNumber"
        Me.lblMachineNumber.Size = New System.Drawing.Size(98, 20)
        Me.lblMachineNumber.TabIndex = 6
        Me.lblMachineNumber.Text = "Machine Number"
        Me.lblMachineNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 8
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxTimeSlip
        '
        Me.gpxTimeSlip.Controls.Add(Me.cboShiftNumber)
        Me.gpxTimeSlip.Controls.Add(Me.lblEmployeeName)
        Me.gpxTimeSlip.Controls.Add(Me.cboEmployeeID)
        Me.gpxTimeSlip.Controls.Add(Me.Label8)
        Me.gpxTimeSlip.Controls.Add(Me.lblShift)
        Me.gpxTimeSlip.Controls.Add(Me.dtpTimeSlipDate)
        Me.gpxTimeSlip.Controls.Add(Me.lblDate)
        Me.gpxTimeSlip.Controls.Add(Me.lblEmployeeNumber)
        Me.gpxTimeSlip.Location = New System.Drawing.Point(29, 41)
        Me.gpxTimeSlip.Name = "gpxTimeSlip"
        Me.gpxTimeSlip.Size = New System.Drawing.Size(318, 123)
        Me.gpxTimeSlip.TabIndex = 0
        Me.gpxTimeSlip.TabStop = False
        Me.gpxTimeSlip.Text = "Time Slip Data"
        '
        'cboShiftNumber
        '
        Me.cboShiftNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShiftNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShiftNumber.DisplayMember = "EmployeeID"
        Me.cboShiftNumber.FormattingEnabled = True
        Me.cboShiftNumber.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboShiftNumber.Location = New System.Drawing.Point(127, 93)
        Me.cboShiftNumber.Name = "cboShiftNumber"
        Me.cboShiftNumber.Size = New System.Drawing.Size(172, 21)
        Me.cboShiftNumber.TabIndex = 5
        Me.cboShiftNumber.TabStop = False
        Me.cboShiftNumber.ValueMember = "EmployeeID"
        '
        'lblEmployeeName
        '
        Me.lblEmployeeName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblEmployeeName.Location = New System.Drawing.Point(124, 70)
        Me.lblEmployeeName.Name = "lblEmployeeName"
        Me.lblEmployeeName.Size = New System.Drawing.Size(172, 20)
        Me.lblEmployeeName.TabIndex = 83
        Me.lblEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboEmployeeID
        '
        Me.cboEmployeeID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboEmployeeID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEmployeeID.DisplayMember = "EmployeeID"
        Me.cboEmployeeID.FormattingEnabled = True
        Me.cboEmployeeID.Location = New System.Drawing.Point(127, 46)
        Me.cboEmployeeID.Name = "cboEmployeeID"
        Me.cboEmployeeID.Size = New System.Drawing.Size(172, 21)
        Me.cboEmployeeID.TabIndex = 4
        Me.cboEmployeeID.ValueMember = "EmployeeID"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(9, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(141, 20)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Employee Name"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShift
        '
        Me.lblShift.Location = New System.Drawing.Point(9, 92)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(98, 20)
        Me.lblShift.TabIndex = 6
        Me.lblShift.Text = "Shift"
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalHours
        '
        Me.lblTotalHours.Location = New System.Drawing.Point(9, 283)
        Me.lblTotalHours.Name = "lblTotalHours"
        Me.lblTotalHours.Size = New System.Drawing.Size(98, 20)
        Me.lblTotalHours.TabIndex = 11
        Me.lblTotalHours.Text = "Total Hours"
        Me.lblTotalHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOtherHours
        '
        Me.lblOtherHours.Location = New System.Drawing.Point(9, 254)
        Me.lblOtherHours.Name = "lblOtherHours"
        Me.lblOtherHours.Size = New System.Drawing.Size(98, 20)
        Me.lblOtherHours.TabIndex = 12
        Me.lblOtherHours.Text = "Other Hours"
        Me.lblOtherHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblToolingHours
        '
        Me.lblToolingHours.Location = New System.Drawing.Point(9, 225)
        Me.lblToolingHours.Name = "lblToolingHours"
        Me.lblToolingHours.Size = New System.Drawing.Size(98, 20)
        Me.lblToolingHours.TabIndex = 13
        Me.lblToolingHours.Text = "Tooling Hours"
        Me.lblToolingHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSetupHours
        '
        Me.lblSetupHours.Location = New System.Drawing.Point(9, 196)
        Me.lblSetupHours.Name = "lblSetupHours"
        Me.lblSetupHours.Size = New System.Drawing.Size(98, 20)
        Me.lblSetupHours.TabIndex = 14
        Me.lblSetupHours.Text = "Setup Hours"
        Me.lblSetupHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMachineHours
        '
        Me.lblMachineHours.Location = New System.Drawing.Point(9, 167)
        Me.lblMachineHours.Name = "lblMachineHours"
        Me.lblMachineHours.Size = New System.Drawing.Size(98, 20)
        Me.lblMachineHours.TabIndex = 15
        Me.lblMachineHours.Text = "Machine Hours"
        Me.lblMachineHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPartNumber
        '
        Me.lblPartNumber.Location = New System.Drawing.Point(9, 49)
        Me.lblPartNumber.Name = "lblPartNumber"
        Me.lblPartNumber.Size = New System.Drawing.Size(98, 20)
        Me.lblPartNumber.TabIndex = 16
        Me.lblPartNumber.Text = "Part Number"
        Me.lblPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbxProductionEntry
        '
        Me.gbxProductionEntry.Controls.Add(Me.chkFromAnotherPart)
        Me.gbxProductionEntry.Controls.Add(Me.chkRollerAttached)
        Me.gbxProductionEntry.Controls.Add(Me.txtPartDescription)
        Me.gbxProductionEntry.Controls.Add(Me.Label1)
        Me.gbxProductionEntry.Controls.Add(Me.lblPieceWeightSingle)
        Me.gbxProductionEntry.Controls.Add(Me.lblPieceWeightPer1000)
        Me.gbxProductionEntry.Controls.Add(Me.txtPartNumber)
        Me.gbxProductionEntry.Controls.Add(Me.cboDiameter)
        Me.gbxProductionEntry.Controls.Add(Me.cboFOXNumber)
        Me.gbxProductionEntry.Controls.Add(Me.lblPW)
        Me.gbxProductionEntry.Controls.Add(Me.cboMachineNumber)
        Me.gbxProductionEntry.Controls.Add(Me.lblPWP1000)
        Me.gbxProductionEntry.Controls.Add(Me.Label14)
        Me.gbxProductionEntry.Controls.Add(Me.txtWeightProduced)
        Me.gbxProductionEntry.Controls.Add(Me.txtPiecesProduced)
        Me.gbxProductionEntry.Controls.Add(Me.lblTotalLineHours)
        Me.gbxProductionEntry.Controls.Add(Me.txtScrapWeight)
        Me.gbxProductionEntry.Controls.Add(Me.cboCarbon)
        Me.gbxProductionEntry.Controls.Add(Me.Label13)
        Me.gbxProductionEntry.Controls.Add(Me.lblScrapWeight)
        Me.gbxProductionEntry.Controls.Add(Me.lblFOXNumber)
        Me.gbxProductionEntry.Controls.Add(Me.cmdEnterData)
        Me.gbxProductionEntry.Controls.Add(Me.cmdClear)
        Me.gbxProductionEntry.Controls.Add(Me.lblPieceWeight)
        Me.gbxProductionEntry.Controls.Add(Me.lblPieces)
        Me.gbxProductionEntry.Controls.Add(Me.txtOtherHours)
        Me.gbxProductionEntry.Controls.Add(Me.txtToolingHours)
        Me.gbxProductionEntry.Controls.Add(Me.txtSetupHours)
        Me.gbxProductionEntry.Controls.Add(Me.txtMachineHours)
        Me.gbxProductionEntry.Controls.Add(Me.lblPartNumber)
        Me.gbxProductionEntry.Controls.Add(Me.lblTotalHours)
        Me.gbxProductionEntry.Controls.Add(Me.lblOtherHours)
        Me.gbxProductionEntry.Controls.Add(Me.lblToolingHours)
        Me.gbxProductionEntry.Controls.Add(Me.lblSetupHours)
        Me.gbxProductionEntry.Controls.Add(Me.lblMachineHours)
        Me.gbxProductionEntry.Controls.Add(Me.lblMachineNumber)
        Me.gbxProductionEntry.Location = New System.Drawing.Point(29, 170)
        Me.gbxProductionEntry.Name = "gbxProductionEntry"
        Me.gbxProductionEntry.Size = New System.Drawing.Size(318, 641)
        Me.gbxProductionEntry.TabIndex = 1
        Me.gbxProductionEntry.TabStop = False
        Me.gbxProductionEntry.Text = "Production Entry"
        '
        'chkFromAnotherPart
        '
        Me.chkFromAnotherPart.Enabled = False
        Me.chkFromAnotherPart.Location = New System.Drawing.Point(12, 578)
        Me.chkFromAnotherPart.Name = "chkFromAnotherPart"
        Me.chkFromAnotherPart.Size = New System.Drawing.Size(112, 31)
        Me.chkFromAnotherPart.TabIndex = 88
        Me.chkFromAnotherPart.TabStop = False
        Me.chkFromAnotherPart.Text = "Remove from another part"
        Me.chkFromAnotherPart.UseVisualStyleBackColor = True
        '
        'chkRollerAttached
        '
        Me.chkRollerAttached.Location = New System.Drawing.Point(127, 532)
        Me.chkRollerAttached.Name = "chkRollerAttached"
        Me.chkRollerAttached.Size = New System.Drawing.Size(169, 24)
        Me.chkRollerAttached.TabIndex = 21
        Me.chkRollerAttached.TabStop = False
        Me.chkRollerAttached.Text = "Roller Attached (188)"
        Me.chkRollerAttached.UseVisualStyleBackColor = True
        '
        'txtPartDescription
        '
        Me.txtPartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartDescription.Location = New System.Drawing.Point(127, 78)
        Me.txtPartDescription.Multiline = True
        Me.txtPartDescription.Name = "txtPartDescription"
        Me.txtPartDescription.ReadOnly = True
        Me.txtPartDescription.Size = New System.Drawing.Size(172, 50)
        Me.txtPartDescription.TabIndex = 8
        Me.txtPartDescription.TabStop = False
        Me.txtPartDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 20)
        Me.Label1.TabIndex = 87
        Me.Label1.Text = "Part Description"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPieceWeightSingle
        '
        Me.lblPieceWeightSingle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPieceWeightSingle.Location = New System.Drawing.Point(151, 430)
        Me.lblPieceWeightSingle.Name = "lblPieceWeightSingle"
        Me.lblPieceWeightSingle.Size = New System.Drawing.Size(148, 20)
        Me.lblPieceWeightSingle.TabIndex = 84
        Me.lblPieceWeightSingle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPieceWeightPer1000
        '
        Me.lblPieceWeightPer1000.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPieceWeightPer1000.Location = New System.Drawing.Point(151, 401)
        Me.lblPieceWeightPer1000.Name = "lblPieceWeightPer1000"
        Me.lblPieceWeightPer1000.Size = New System.Drawing.Size(148, 20)
        Me.lblPieceWeightPer1000.TabIndex = 83
        Me.lblPieceWeightPer1000.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPartNumber
        '
        Me.txtPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartNumber.Location = New System.Drawing.Point(127, 49)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.ReadOnly = True
        Me.txtPartNumber.Size = New System.Drawing.Size(172, 20)
        Me.txtPartNumber.TabIndex = 8
        Me.txtPartNumber.TabStop = False
        Me.txtPartNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboDiameter
        '
        Me.cboDiameter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDiameter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDiameter.DisplayMember = "FOX Number"
        Me.cboDiameter.FormattingEnabled = True
        Me.cboDiameter.Location = New System.Drawing.Point(127, 342)
        Me.cboDiameter.Name = "cboDiameter"
        Me.cboDiameter.Size = New System.Drawing.Size(172, 21)
        Me.cboDiameter.TabIndex = 16
        Me.cboDiameter.ValueMember = "FOX Number"
        '
        'cboFOXNumber
        '
        Me.cboFOXNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFOXNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFOXNumber.FormattingEnabled = True
        Me.cboFOXNumber.Location = New System.Drawing.Point(127, 19)
        Me.cboFOXNumber.Name = "cboFOXNumber"
        Me.cboFOXNumber.Size = New System.Drawing.Size(172, 21)
        Me.cboFOXNumber.TabIndex = 7
        '
        'lblPW
        '
        Me.lblPW.Location = New System.Drawing.Point(9, 430)
        Me.lblPW.Name = "lblPW"
        Me.lblPW.Size = New System.Drawing.Size(122, 20)
        Me.lblPW.TabIndex = 86
        Me.lblPW.Text = "Piece Weight"
        Me.lblPW.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboMachineNumber
        '
        Me.cboMachineNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboMachineNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMachineNumber.FormattingEnabled = True
        Me.cboMachineNumber.Location = New System.Drawing.Point(127, 137)
        Me.cboMachineNumber.Name = "cboMachineNumber"
        Me.cboMachineNumber.Size = New System.Drawing.Size(172, 21)
        Me.cboMachineNumber.TabIndex = 9
        '
        'lblPWP1000
        '
        Me.lblPWP1000.Location = New System.Drawing.Point(9, 401)
        Me.lblPWP1000.Name = "lblPWP1000"
        Me.lblPWP1000.Size = New System.Drawing.Size(122, 20)
        Me.lblPWP1000.TabIndex = 85
        Me.lblPWP1000.Text = "Piece Weight Per 1000"
        Me.lblPWP1000.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(9, 343)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 20)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "Sched. Material Size"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtWeightProduced
        '
        Me.txtWeightProduced.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWeightProduced.Location = New System.Drawing.Point(127, 459)
        Me.txtWeightProduced.Name = "txtWeightProduced"
        Me.txtWeightProduced.Size = New System.Drawing.Size(172, 20)
        Me.txtWeightProduced.TabIndex = 19
        Me.txtWeightProduced.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPiecesProduced
        '
        Me.txtPiecesProduced.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPiecesProduced.Location = New System.Drawing.Point(127, 372)
        Me.txtPiecesProduced.Name = "txtPiecesProduced"
        Me.txtPiecesProduced.Size = New System.Drawing.Size(172, 20)
        Me.txtPiecesProduced.TabIndex = 17
        Me.txtPiecesProduced.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalLineHours
        '
        Me.lblTotalLineHours.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblTotalLineHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalLineHours.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblTotalLineHours.Location = New System.Drawing.Point(127, 283)
        Me.lblTotalLineHours.Name = "lblTotalLineHours"
        Me.lblTotalLineHours.Size = New System.Drawing.Size(172, 20)
        Me.lblTotalLineHours.TabIndex = 14
        Me.lblTotalLineHours.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtScrapWeight
        '
        Me.txtScrapWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScrapWeight.Location = New System.Drawing.Point(127, 488)
        Me.txtScrapWeight.Name = "txtScrapWeight"
        Me.txtScrapWeight.Size = New System.Drawing.Size(172, 20)
        Me.txtScrapWeight.TabIndex = 20
        Me.txtScrapWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.DisplayMember = "FOX Number"
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(127, 312)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(172, 21)
        Me.cboCarbon.TabIndex = 15
        Me.cboCarbon.ValueMember = "FOX Number"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(9, 313)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(115, 20)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Sched. Material Grade"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblScrapWeight
        '
        Me.lblScrapWeight.Location = New System.Drawing.Point(9, 489)
        Me.lblScrapWeight.Name = "lblScrapWeight"
        Me.lblScrapWeight.Size = New System.Drawing.Size(98, 20)
        Me.lblScrapWeight.TabIndex = 18
        Me.lblScrapWeight.Text = "Scrap Weight"
        Me.lblScrapWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdEnterData
        '
        Me.cmdEnterData.Location = New System.Drawing.Point(151, 578)
        Me.cmdEnterData.Name = "cmdEnterData"
        Me.cmdEnterData.Size = New System.Drawing.Size(71, 40)
        Me.cmdEnterData.TabIndex = 22
        Me.cmdEnterData.Text = "Enter New"
        Me.cmdEnterData.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(228, 578)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 23
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'lblPieceWeight
        '
        Me.lblPieceWeight.Location = New System.Drawing.Point(9, 459)
        Me.lblPieceWeight.Name = "lblPieceWeight"
        Me.lblPieceWeight.Size = New System.Drawing.Size(98, 20)
        Me.lblPieceWeight.TabIndex = 19
        Me.lblPieceWeight.Text = "Total Piece Weight"
        Me.lblPieceWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPieces
        '
        Me.lblPieces.Location = New System.Drawing.Point(9, 373)
        Me.lblPieces.Name = "lblPieces"
        Me.lblPieces.Size = New System.Drawing.Size(98, 20)
        Me.lblPieces.TabIndex = 20
        Me.lblPieces.Text = "Pieces"
        Me.lblPieces.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOtherHours
        '
        Me.txtOtherHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOtherHours.Location = New System.Drawing.Point(127, 254)
        Me.txtOtherHours.Name = "txtOtherHours"
        Me.txtOtherHours.Size = New System.Drawing.Size(172, 20)
        Me.txtOtherHours.TabIndex = 13
        Me.txtOtherHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtToolingHours
        '
        Me.txtToolingHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtToolingHours.Location = New System.Drawing.Point(127, 225)
        Me.txtToolingHours.Name = "txtToolingHours"
        Me.txtToolingHours.Size = New System.Drawing.Size(172, 20)
        Me.txtToolingHours.TabIndex = 12
        Me.txtToolingHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSetupHours
        '
        Me.txtSetupHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSetupHours.Location = New System.Drawing.Point(127, 196)
        Me.txtSetupHours.Name = "txtSetupHours"
        Me.txtSetupHours.Size = New System.Drawing.Size(172, 20)
        Me.txtSetupHours.TabIndex = 11
        Me.txtSetupHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMachineHours
        '
        Me.txtMachineHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMachineHours.Location = New System.Drawing.Point(127, 167)
        Me.txtMachineHours.Name = "txtMachineHours"
        Me.txtMachineHours.Size = New System.Drawing.Size(172, 20)
        Me.txtMachineHours.TabIndex = 10
        Me.txtMachineHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(907, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 6
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMenu01, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 79
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'TSMenu01
        '
        Me.TSMenu01.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.DeleteDataToolStripMenuItem, Me.PrintDataToolStripMenuItem, Me.ClearDataToolStripMenuItem})
        Me.TSMenu01.Name = "TSMenu01"
        Me.TSMenu01.Size = New System.Drawing.Size(35, 20)
        Me.TSMenu01.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.SaveToolStripMenuItem.Text = "Save Data"
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
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(830, 772)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 5
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdPrintTimeSlip
        '
        Me.cmdPrintTimeSlip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintTimeSlip.Location = New System.Drawing.Point(983, 771)
        Me.cmdPrintTimeSlip.Name = "cmdPrintTimeSlip"
        Me.cmdPrintTimeSlip.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintTimeSlip.TabIndex = 7
        Me.cmdPrintTimeSlip.Text = "Print"
        Me.cmdPrintTimeSlip.UseVisualStyleBackColor = True
        '
        'gpxFOXRouting
        '
        Me.gpxFOXRouting.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxFOXRouting.Controls.Add(Me.Label3)
        Me.gpxFOXRouting.Controls.Add(Me.Label2)
        Me.gpxFOXRouting.Controls.Add(Me.dgvFOXRouting)
        Me.gpxFOXRouting.Location = New System.Drawing.Point(363, 593)
        Me.gpxFOXRouting.Name = "gpxFOXRouting"
        Me.gpxFOXRouting.Size = New System.Drawing.Size(331, 219)
        Me.gpxFOXRouting.TabIndex = 24
        Me.gpxFOXRouting.TabStop = False
        Me.gpxFOXRouting.Text = "FOX Routing"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(64, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = " - Indicates adding to inventory"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightGreen
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(35, 186)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 23)
        Me.Label2.TabIndex = 1
        '
        'dgvFOXRouting
        '
        Me.dgvFOXRouting.AllowUserToAddRows = False
        Me.dgvFOXRouting.AllowUserToDeleteRows = False
        Me.dgvFOXRouting.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvFOXRouting.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvFOXRouting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFOXRouting.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFOXRouting.Location = New System.Drawing.Point(16, 15)
        Me.dgvFOXRouting.Name = "dgvFOXRouting"
        Me.dgvFOXRouting.ReadOnly = True
        Me.dgvFOXRouting.Size = New System.Drawing.Size(296, 156)
        Me.dgvFOXRouting.TabIndex = 0
        '
        'dgvTimeSlipLines
        '
        Me.dgvTimeSlipLines.AllowUserToAddRows = False
        Me.dgvTimeSlipLines.AllowUserToDeleteRows = False
        Me.dgvTimeSlipLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTimeSlipLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvTimeSlipLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTimeSlipLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTimeSlipLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvTimeSlipLines.Location = New System.Drawing.Point(363, 45)
        Me.dgvTimeSlipLines.Name = "dgvTimeSlipLines"
        Me.dgvTimeSlipLines.Size = New System.Drawing.Size(767, 538)
        Me.dgvTimeSlipLines.TabIndex = 80
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(753, 771)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 25
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cboDeleteLine)
        Me.GroupBox1.Controls.Add(Me.cmdDeleteEntry)
        Me.GroupBox1.Location = New System.Drawing.Point(830, 600)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 126)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Delete Line Entry"
        '
        'cboDeleteLine
        '
        Me.cboDeleteLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDeleteLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDeleteLine.FormattingEnabled = True
        Me.cboDeleteLine.Location = New System.Drawing.Point(26, 56)
        Me.cboDeleteLine.Name = "cboDeleteLine"
        Me.cboDeleteLine.Size = New System.Drawing.Size(138, 21)
        Me.cboDeleteLine.TabIndex = 0
        '
        'cmdDeleteEntry
        '
        Me.cmdDeleteEntry.ForeColor = System.Drawing.Color.Black
        Me.cmdDeleteEntry.Location = New System.Drawing.Point(194, 45)
        Me.cmdDeleteEntry.Name = "cmdDeleteEntry"
        Me.cmdDeleteEntry.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteEntry.TabIndex = 1
        Me.cmdDeleteEntry.Text = "Delete Line"
        Me.cmdDeleteEntry.UseVisualStyleBackColor = True
        '
        'TimeSlipForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvTimeSlipLines)
        Me.Controls.Add(Me.gpxFOXRouting)
        Me.Controls.Add(Me.cmdPrintTimeSlip)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.gbxProductionEntry)
        Me.Controls.Add(Me.gpxTimeSlip)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "TimeSlipForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Time Slip Program"
        Me.gpxTimeSlip.ResumeLayout(False)
        Me.gbxProductionEntry.ResumeLayout(False)
        Me.gbxProductionEntry.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxFOXRouting.ResumeLayout(False)
        Me.gpxFOXRouting.PerformLayout()
        CType(Me.dgvFOXRouting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTimeSlipLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpTimeSlipDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblEmployeeNumber As System.Windows.Forms.Label
    Friend WithEvents lblFOXNumber As System.Windows.Forms.Label
    Friend WithEvents lblMachineNumber As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxTimeSlip As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotalHours As System.Windows.Forms.Label
    Friend WithEvents lblOtherHours As System.Windows.Forms.Label
    Friend WithEvents lblToolingHours As System.Windows.Forms.Label
    Friend WithEvents lblSetupHours As System.Windows.Forms.Label
    Friend WithEvents lblMachineHours As System.Windows.Forms.Label
    Friend WithEvents lblPartNumber As System.Windows.Forms.Label
    Friend WithEvents gbxProductionEntry As System.Windows.Forms.GroupBox
    Friend WithEvents txtOtherHours As System.Windows.Forms.TextBox
    Friend WithEvents txtToolingHours As System.Windows.Forms.TextBox
    Friend WithEvents txtSetupHours As System.Windows.Forms.TextBox
    Friend WithEvents txtMachineHours As System.Windows.Forms.TextBox
    Friend WithEvents lblPieces As System.Windows.Forms.Label
    Friend WithEvents lblScrapWeight As System.Windows.Forms.Label
    Friend WithEvents lblPieceWeight As System.Windows.Forms.Label
    Friend WithEvents txtScrapWeight As System.Windows.Forms.TextBox
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents cmdEnterData As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents TSMenu01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdPrintTimeSlip As System.Windows.Forms.Button
    Friend WithEvents cboEmployeeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblTotalLineHours As System.Windows.Forms.Label
    Friend WithEvents gpxFOXRouting As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblPieceWeightPer1000 As System.Windows.Forms.Label
    Friend WithEvents lblPieceWeightSingle As System.Windows.Forms.Label
    Friend WithEvents lblPW As System.Windows.Forms.Label
    Friend WithEvents lblPWP1000 As System.Windows.Forms.Label
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PostingDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtWeightProduced As System.Windows.Forms.TextBox
    Friend WithEvents txtPiecesProduced As System.Windows.Forms.TextBox
    Friend WithEvents TimeSlipHeaderTableTimeSlipKeyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeSlipLineItemTableTimeSlipKeyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvTimeSlipLines As System.Windows.Forms.DataGridView
    Friend WithEvents cboMachineNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboDiameter As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboFOXNumber As System.Windows.Forms.ComboBox
    Friend WithEvents DeleteDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents TimeSlipKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MachineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MachineHoursColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SetupHoursColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolingHoursColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtherHoursColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalHoursColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PiecesProducedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScrapWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblEmployeeName As System.Windows.Forms.Label
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboShiftNumber As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDeleteEntry As System.Windows.Forms.Button
    Friend WithEvents cboDeleteLine As System.Windows.Forms.ComboBox
    Friend WithEvents txtPartDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkRollerAttached As System.Windows.Forms.CheckBox
    Friend WithEvents dgvFOXRouting As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkFromAnotherPart As System.Windows.Forms.CheckBox
End Class
