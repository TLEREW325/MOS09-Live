<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewHeatTreatInspectionLog
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
        Me.gpxAPVoucherData = New System.Windows.Forms.GroupBox
        Me.cboAnnealLot = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.chkUseDates = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.cboFinishedSize = New System.Windows.Forms.ComboBox
        Me.cboGrade = New System.Windows.Forms.ComboBox
        Me.lblGrade = New System.Windows.Forms.Label
        Me.cboDAQBatchNumber = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cboProcessType = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboBlueprint = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboHeatNumber = New System.Windows.Forms.ComboBox
        Me.cboFOXNumber = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.cboLotNumber = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdOpenHeatTreatLog = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvHeatTreatLog = New System.Windows.Forms.DataGridView
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdPrintCert = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtWeightTotal = New System.Windows.Forms.TextBox
        Me.gpxAPVoucherData.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvHeatTreatLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpxAPVoucherData
        '
        Me.gpxAPVoucherData.Controls.Add(Me.cboAnnealLot)
        Me.gpxAPVoucherData.Controls.Add(Me.Label15)
        Me.gpxAPVoucherData.Controls.Add(Me.chkUseDates)
        Me.gpxAPVoucherData.Controls.Add(Me.dtpEndDate)
        Me.gpxAPVoucherData.Controls.Add(Me.dtpBeginDate)
        Me.gpxAPVoucherData.Controls.Add(Me.cboFinishedSize)
        Me.gpxAPVoucherData.Controls.Add(Me.cboGrade)
        Me.gpxAPVoucherData.Controls.Add(Me.lblGrade)
        Me.gpxAPVoucherData.Controls.Add(Me.cboDAQBatchNumber)
        Me.gpxAPVoucherData.Controls.Add(Me.Label11)
        Me.gpxAPVoucherData.Controls.Add(Me.cboProcessType)
        Me.gpxAPVoucherData.Controls.Add(Me.Label10)
        Me.gpxAPVoucherData.Controls.Add(Me.cboCustomerName)
        Me.gpxAPVoucherData.Controls.Add(Me.cboCustomerID)
        Me.gpxAPVoucherData.Controls.Add(Me.Label9)
        Me.gpxAPVoucherData.Controls.Add(Me.Label8)
        Me.gpxAPVoucherData.Controls.Add(Me.cboBlueprint)
        Me.gpxAPVoucherData.Controls.Add(Me.Label6)
        Me.gpxAPVoucherData.Controls.Add(Me.cboHeatNumber)
        Me.gpxAPVoucherData.Controls.Add(Me.cboFOXNumber)
        Me.gpxAPVoucherData.Controls.Add(Me.Label7)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdView)
        Me.gpxAPVoucherData.Controls.Add(Me.cboLotNumber)
        Me.gpxAPVoucherData.Controls.Add(Me.Label2)
        Me.gpxAPVoucherData.Controls.Add(Me.Label3)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdClear)
        Me.gpxAPVoucherData.Controls.Add(Me.Label12)
        Me.gpxAPVoucherData.Controls.Add(Me.Label14)
        Me.gpxAPVoucherData.Controls.Add(Me.Label13)
        Me.gpxAPVoucherData.Location = New System.Drawing.Point(29, 41)
        Me.gpxAPVoucherData.Name = "gpxAPVoucherData"
        Me.gpxAPVoucherData.Size = New System.Drawing.Size(300, 685)
        Me.gpxAPVoucherData.TabIndex = 0
        Me.gpxAPVoucherData.TabStop = False
        Me.gpxAPVoucherData.Text = "View By Filters"
        '
        'cboAnnealLot
        '
        Me.cboAnnealLot.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAnnealLot.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAnnealLot.FormattingEnabled = True
        Me.cboAnnealLot.Location = New System.Drawing.Point(103, 435)
        Me.cboAnnealLot.Margin = New System.Windows.Forms.Padding(5)
        Me.cboAnnealLot.Name = "cboAnnealLot"
        Me.cboAnnealLot.Size = New System.Drawing.Size(185, 21)
        Me.cboAnnealLot.TabIndex = 57
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(15, 436)
        Me.Label15.Margin = New System.Windows.Forms.Padding(5)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 20)
        Me.Label15.TabIndex = 58
        Me.Label15.Text = "Anneal Lot"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkUseDates
        '
        Me.chkUseDates.AutoSize = True
        Me.chkUseDates.Location = New System.Drawing.Point(102, 509)
        Me.chkUseDates.Name = "chkUseDates"
        Me.chkUseDates.Size = New System.Drawing.Size(106, 17)
        Me.chkUseDates.TabIndex = 56
        Me.chkUseDates.Text = "Use Date Range"
        Me.chkUseDates.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(102, 580)
        Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(5)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(184, 20)
        Me.dtpEndDate.TabIndex = 53
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(101, 541)
        Me.dtpBeginDate.Margin = New System.Windows.Forms.Padding(5)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(184, 20)
        Me.dtpBeginDate.TabIndex = 52
        '
        'cboFinishedSize
        '
        Me.cboFinishedSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFinishedSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFinishedSize.FormattingEnabled = True
        Me.cboFinishedSize.Location = New System.Drawing.Point(103, 169)
        Me.cboFinishedSize.Margin = New System.Windows.Forms.Padding(5)
        Me.cboFinishedSize.Name = "cboFinishedSize"
        Me.cboFinishedSize.Size = New System.Drawing.Size(185, 21)
        Me.cboFinishedSize.TabIndex = 50
        '
        'cboGrade
        '
        Me.cboGrade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGrade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGrade.FormattingEnabled = True
        Me.cboGrade.Location = New System.Drawing.Point(103, 131)
        Me.cboGrade.Margin = New System.Windows.Forms.Padding(5)
        Me.cboGrade.Name = "cboGrade"
        Me.cboGrade.Size = New System.Drawing.Size(185, 21)
        Me.cboGrade.TabIndex = 48
        '
        'lblGrade
        '
        Me.lblGrade.Location = New System.Drawing.Point(15, 132)
        Me.lblGrade.Margin = New System.Windows.Forms.Padding(5)
        Me.lblGrade.Name = "lblGrade"
        Me.lblGrade.Size = New System.Drawing.Size(100, 20)
        Me.lblGrade.TabIndex = 49
        Me.lblGrade.Text = "Grade"
        Me.lblGrade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDAQBatchNumber
        '
        Me.cboDAQBatchNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDAQBatchNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDAQBatchNumber.FormattingEnabled = True
        Me.cboDAQBatchNumber.Location = New System.Drawing.Point(103, 397)
        Me.cboDAQBatchNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.cboDAQBatchNumber.Name = "cboDAQBatchNumber"
        Me.cboDAQBatchNumber.Size = New System.Drawing.Size(185, 21)
        Me.cboDAQBatchNumber.TabIndex = 46
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(15, 398)
        Me.Label11.Margin = New System.Windows.Forms.Padding(5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 47
        Me.Label11.Text = "DAQ Batch"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboProcessType
        '
        Me.cboProcessType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboProcessType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboProcessType.FormattingEnabled = True
        Me.cboProcessType.Items.AddRange(New Object() {"Anneal", "Top Cool Anneal", "Harden and Draw", "Case Harden", "Case Harden w/Top Cool", "Carbon Restore w/Top Cool", "Other"})
        Me.cboProcessType.Location = New System.Drawing.Point(103, 359)
        Me.cboProcessType.Margin = New System.Windows.Forms.Padding(5)
        Me.cboProcessType.Name = "cboProcessType"
        Me.cboProcessType.Size = New System.Drawing.Size(185, 21)
        Me.cboProcessType.TabIndex = 44
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(15, 360)
        Me.Label10.Margin = New System.Windows.Forms.Padding(5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Process Type"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(19, 86)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(269, 21)
        Me.cboCustomerName.TabIndex = 3
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(76, 59)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(212, 21)
        Me.cboCustomerID.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(13, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "Customer"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(13, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(267, 40)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBlueprint
        '
        Me.cboBlueprint.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBlueprint.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBlueprint.FormattingEnabled = True
        Me.cboBlueprint.Location = New System.Drawing.Point(103, 321)
        Me.cboBlueprint.Margin = New System.Windows.Forms.Padding(5)
        Me.cboBlueprint.Name = "cboBlueprint"
        Me.cboBlueprint.Size = New System.Drawing.Size(185, 21)
        Me.cboBlueprint.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(15, 322)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Blueprint #"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboHeatNumber
        '
        Me.cboHeatNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHeatNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHeatNumber.FormattingEnabled = True
        Me.cboHeatNumber.Location = New System.Drawing.Point(103, 283)
        Me.cboHeatNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.cboHeatNumber.Name = "cboHeatNumber"
        Me.cboHeatNumber.Size = New System.Drawing.Size(185, 21)
        Me.cboHeatNumber.TabIndex = 6
        '
        'cboFOXNumber
        '
        Me.cboFOXNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFOXNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFOXNumber.FormattingEnabled = True
        Me.cboFOXNumber.Location = New System.Drawing.Point(103, 245)
        Me.cboFOXNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.cboFOXNumber.Name = "cboFOXNumber"
        Me.cboFOXNumber.Size = New System.Drawing.Size(185, 21)
        Me.cboFOXNumber.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(15, 284)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Heat Number"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(137, 626)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 40)
        Me.cmdView.TabIndex = 8
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cboLotNumber
        '
        Me.cboLotNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLotNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLotNumber.FormattingEnabled = True
        Me.cboLotNumber.Location = New System.Drawing.Point(104, 207)
        Me.cboLotNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.cboLotNumber.Name = "cboLotNumber"
        Me.cboLotNumber.Size = New System.Drawing.Size(184, 21)
        Me.cboLotNumber.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(15, 208)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Lot Number"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(15, 246)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "FOX Number"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 626)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 9
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(15, 170)
        Me.Label12.Margin = New System.Windows.Forms.Padding(5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 20)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "Finished Size"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(13, 541)
        Me.Label14.Margin = New System.Windows.Forms.Padding(5)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 20)
        Me.Label14.TabIndex = 54
        Me.Label14.Text = "Begin Date"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(14, 580)
        Me.Label13.Margin = New System.Windows.Forms.Padding(5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 20)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "End Date"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(8, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(180, 39)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Loads Heat Treat Form and closes this form..."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdOpenHeatTreatLog
        '
        Me.cmdOpenHeatTreatLog.Location = New System.Drawing.Point(214, 25)
        Me.cmdOpenHeatTreatLog.Name = "cmdOpenHeatTreatLog"
        Me.cmdOpenHeatTreatLog.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenHeatTreatLog.TabIndex = 11
        Me.cmdOpenHeatTreatLog.Text = "Heat Treat Form"
        Me.cmdOpenHeatTreatLog.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 19
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
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'dgvHeatTreatLog
        '
        Me.dgvHeatTreatLog.AllowUserToAddRows = False
        Me.dgvHeatTreatLog.AllowUserToDeleteRows = False
        Me.dgvHeatTreatLog.AllowUserToOrderColumns = True
        Me.dgvHeatTreatLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvHeatTreatLog.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvHeatTreatLog.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvHeatTreatLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHeatTreatLog.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvHeatTreatLog.Location = New System.Drawing.Point(353, 41)
        Me.dgvHeatTreatLog.Name = "dgvHeatTreatLog"
        Me.dgvHeatTreatLog.ReadOnly = True
        Me.dgvHeatTreatLog.Size = New System.Drawing.Size(679, 722)
        Me.dgvHeatTreatLog.TabIndex = 14
        Me.dgvHeatTreatLog.TabStop = False
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(961, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 13
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdOpenHeatTreatLog)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(29, 732)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(300, 79)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Open Heat Treat Inspection Log"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(675, 774)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 40)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Select multiple rows to print a Certificaiton with multiple records."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintCert
        '
        Me.cmdPrintCert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintCert.Location = New System.Drawing.Point(884, 771)
        Me.cmdPrintCert.Name = "cmdPrintCert"
        Me.cmdPrintCert.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintCert.TabIndex = 20
        Me.cmdPrintCert.Text = "Print Cert"
        Me.cmdPrintCert.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label5.Location = New System.Drawing.Point(350, 781)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Load Weight Total"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtWeightTotal
        '
        Me.txtWeightTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtWeightTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWeightTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWeightTotal.Location = New System.Drawing.Point(458, 782)
        Me.txtWeightTotal.Name = "txtWeightTotal"
        Me.txtWeightTotal.Size = New System.Drawing.Size(147, 20)
        Me.txtWeightTotal.TabIndex = 57
        Me.txtWeightTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ViewHeatTreatInspectionLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.txtWeightTotal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdPrintCert)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvHeatTreatLog)
        Me.Controls.Add(Me.gpxAPVoucherData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewHeatTreatInspectionLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Heat Treat Inspection Log Files"
        Me.gpxAPVoucherData.ResumeLayout(False)
        Me.gpxAPVoucherData.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvHeatTreatLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpxAPVoucherData As System.Windows.Forms.GroupBox
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboLotNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdOpenHeatTreatLog As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvHeatTreatLog As System.Windows.Forms.DataGridView
    Friend WithEvents CoreHardnessScaleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboFOXNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboHeatNumber As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboBlueprint As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboProcessType As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboDAQBatchNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintCert As System.Windows.Forms.Button
    Friend WithEvents cboFinishedSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboGrade As System.Windows.Forms.ComboBox
    Friend WithEvents lblGrade As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkUseDates As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboAnnealLot As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtWeightTotal As System.Windows.Forms.TextBox
End Class
