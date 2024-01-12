<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewTimeSlipTotals
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
        Me.ExportTotalMaterialConsumedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitrToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cboEmployeeID = New System.Windows.Forms.ComboBox
        Me.cboMachineNumber = New System.Windows.Forms.ComboBox
        Me.cboShiftNumber = New System.Windows.Forms.ComboBox
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.cboFOXNumber = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.dgvTimeSlipPostings = New System.Windows.Forms.DataGridView
        Me.cmdViewByFilter = New System.Windows.Forms.Button
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.gpxFilters = New System.Windows.Forms.GroupBox
        Me.chkAllTypes = New System.Windows.Forms.CheckBox
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.txtPartDescription = New System.Windows.Forms.TextBox
        Me.txtEmployeeName = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdPrintListingWithTotals = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.reversedColor = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblTotalWeight = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.lblTotalInventoryPieces = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.lblTotalBlanks = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Button2 = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvTimeSlipPostings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxFilters.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
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
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportTotalMaterialConsumedToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ExportTotalMaterialConsumedToolStripMenuItem
        '
        Me.ExportTotalMaterialConsumedToolStripMenuItem.Name = "ExportTotalMaterialConsumedToolStripMenuItem"
        Me.ExportTotalMaterialConsumedToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ExportTotalMaterialConsumedToolStripMenuItem.Text = "Export Total Material Consumed"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem
        '
        Me.PrintListingToolStripMenuItem.Name = "PrintListingToolStripMenuItem"
        Me.PrintListingToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.PrintListingToolStripMenuItem.Text = "Print Listing"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitrToolStripMenuItem})
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ExitrToolStripMenuItem
        '
        Me.ExitrToolStripMenuItem.Name = "ExitrToolStripMenuItem"
        Me.ExitrToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitrToolStripMenuItem.Text = "Exit"
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1057, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 16
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cboEmployeeID
        '
        Me.cboEmployeeID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboEmployeeID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEmployeeID.FormattingEnabled = True
        Me.cboEmployeeID.Location = New System.Drawing.Point(89, 421)
        Me.cboEmployeeID.Name = "cboEmployeeID"
        Me.cboEmployeeID.Size = New System.Drawing.Size(193, 21)
        Me.cboEmployeeID.TabIndex = 8
        '
        'cboMachineNumber
        '
        Me.cboMachineNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMachineNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMachineNumber.FormattingEnabled = True
        Me.cboMachineNumber.Location = New System.Drawing.Point(89, 340)
        Me.cboMachineNumber.Name = "cboMachineNumber"
        Me.cboMachineNumber.Size = New System.Drawing.Size(193, 21)
        Me.cboMachineNumber.TabIndex = 6
        '
        'cboShiftNumber
        '
        Me.cboShiftNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShiftNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShiftNumber.FormattingEnabled = True
        Me.cboShiftNumber.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboShiftNumber.Location = New System.Drawing.Point(89, 378)
        Me.cboShiftNumber.Name = "cboShiftNumber"
        Me.cboShiftNumber.Size = New System.Drawing.Size(193, 21)
        Me.cboShiftNumber.TabIndex = 7
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(93, 100)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(193, 21)
        Me.cboPartNumber.TabIndex = 2
        '
        'cboFOXNumber
        '
        Me.cboFOXNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFOXNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFOXNumber.FormattingEnabled = True
        Me.cboFOXNumber.Location = New System.Drawing.Point(93, 68)
        Me.cboFOXNumber.Name = "cboFOXNumber"
        Me.cboFOXNumber.Size = New System.Drawing.Size(193, 21)
        Me.cboFOXNumber.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Part Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 378)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Shift"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 421)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 20)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Employee ID"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 20)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "FOX Number"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 340)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 20)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Machine #"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(980, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 15
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'dgvTimeSlipPostings
        '
        Me.dgvTimeSlipPostings.AllowUserToAddRows = False
        Me.dgvTimeSlipPostings.AllowUserToDeleteRows = False
        Me.dgvTimeSlipPostings.AllowUserToOrderColumns = True
        Me.dgvTimeSlipPostings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTimeSlipPostings.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvTimeSlipPostings.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTimeSlipPostings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTimeSlipPostings.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvTimeSlipPostings.Location = New System.Drawing.Point(335, 41)
        Me.dgvTimeSlipPostings.Name = "dgvTimeSlipPostings"
        Me.dgvTimeSlipPostings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvTimeSlipPostings.Size = New System.Drawing.Size(799, 615)
        Me.dgvTimeSlipPostings.TabIndex = 15
        Me.dgvTimeSlipPostings.TabStop = False
        '
        'cmdViewByFilter
        '
        Me.cmdViewByFilter.Location = New System.Drawing.Point(139, 728)
        Me.cmdViewByFilter.Name = "cmdViewByFilter"
        Me.cmdViewByFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilter.TabIndex = 13
        Me.cmdViewByFilter.Text = "View"
        Me.cmdViewByFilter.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(94, 686)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(193, 20)
        Me.dtpEndDate.TabIndex = 12
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(94, 649)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(193, 20)
        Me.dtpBeginDate.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(19, 686)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 20)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "End Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(19, 649)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 20)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Start Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxFilters
        '
        Me.gpxFilters.Controls.Add(Me.chkAllTypes)
        Me.gpxFilters.Controls.Add(Me.cboStatus)
        Me.gpxFilters.Controls.Add(Me.Label10)
        Me.gpxFilters.Controls.Add(Me.cboCarbon)
        Me.gpxFilters.Controls.Add(Me.cboSteelSize)
        Me.gpxFilters.Controls.Add(Me.Label2)
        Me.gpxFilters.Controls.Add(Me.Label7)
        Me.gpxFilters.Controls.Add(Me.cboPartDescription)
        Me.gpxFilters.Controls.Add(Me.txtPartDescription)
        Me.gpxFilters.Controls.Add(Me.txtEmployeeName)
        Me.gpxFilters.Controls.Add(Me.Label14)
        Me.gpxFilters.Controls.Add(Me.chkDateRange)
        Me.gpxFilters.Controls.Add(Me.Label12)
        Me.gpxFilters.Controls.Add(Me.cmdClear)
        Me.gpxFilters.Controls.Add(Me.cmdViewByFilter)
        Me.gpxFilters.Controls.Add(Me.cboFOXNumber)
        Me.gpxFilters.Controls.Add(Me.cboEmployeeID)
        Me.gpxFilters.Controls.Add(Me.dtpBeginDate)
        Me.gpxFilters.Controls.Add(Me.dtpEndDate)
        Me.gpxFilters.Controls.Add(Me.cboMachineNumber)
        Me.gpxFilters.Controls.Add(Me.Label9)
        Me.gpxFilters.Controls.Add(Me.cboPartNumber)
        Me.gpxFilters.Controls.Add(Me.Label8)
        Me.gpxFilters.Controls.Add(Me.cboShiftNumber)
        Me.gpxFilters.Controls.Add(Me.Label3)
        Me.gpxFilters.Controls.Add(Me.Label1)
        Me.gpxFilters.Controls.Add(Me.Label4)
        Me.gpxFilters.Controls.Add(Me.Label5)
        Me.gpxFilters.Controls.Add(Me.Label6)
        Me.gpxFilters.Location = New System.Drawing.Point(29, 41)
        Me.gpxFilters.Name = "gpxFilters"
        Me.gpxFilters.Size = New System.Drawing.Size(300, 770)
        Me.gpxFilters.TabIndex = 0
        Me.gpxFilters.TabStop = False
        Me.gpxFilters.Text = "View By Filters"
        '
        'chkAllTypes
        '
        Me.chkAllTypes.AutoSize = True
        Me.chkAllTypes.Location = New System.Drawing.Point(118, 271)
        Me.chkAllTypes.Margin = New System.Windows.Forms.Padding(5)
        Me.chkAllTypes.Name = "chkAllTypes"
        Me.chkAllTypes.Size = New System.Drawing.Size(168, 17)
        Me.chkAllTypes.TabIndex = 75
        Me.chkAllTypes.Text = "Show all types for given grade"
        Me.chkAllTypes.UseVisualStyleBackColor = True
        '
        'cboStatus
        '
        Me.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OPEN", "POSTED"})
        Me.cboStatus.Location = New System.Drawing.Point(89, 541)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(193, 21)
        Me.cboStatus.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(12, 541)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(115, 20)
        Me.Label10.TabIndex = 53
        Me.Label10.Text = "Status"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(93, 242)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(193, 21)
        Me.cboCarbon.TabIndex = 4
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboSteelSize.Location = New System.Drawing.Point(89, 300)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(193, 21)
        Me.cboSteelSize.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 301)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 20)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Material Size"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 241)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 20)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "Material Grade"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(16, 132)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(270, 21)
        Me.cboPartDescription.TabIndex = 3
        '
        'txtPartDescription
        '
        Me.txtPartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartDescription.Location = New System.Drawing.Point(16, 171)
        Me.txtPartDescription.Multiline = True
        Me.txtPartDescription.Name = "txtPartDescription"
        Me.txtPartDescription.ReadOnly = True
        Me.txtPartDescription.Size = New System.Drawing.Size(270, 52)
        Me.txtPartDescription.TabIndex = 47
        Me.txtPartDescription.TabStop = False
        '
        'txtEmployeeName
        '
        Me.txtEmployeeName.BackColor = System.Drawing.SystemColors.Control
        Me.txtEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmployeeName.Location = New System.Drawing.Point(15, 457)
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.ReadOnly = True
        Me.txtEmployeeName.Size = New System.Drawing.Size(267, 20)
        Me.txtEmployeeName.TabIndex = 7
        Me.txtEmployeeName.TabStop = False
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(19, 582)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(267, 33)
        Me.Label14.TabIndex = 46
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(94, 618)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 10
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(16, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(266, 49)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(216, 728)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdPrintListingWithTotals
        '
        Me.cmdPrintListingWithTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintListingWithTotals.Location = New System.Drawing.Point(903, 771)
        Me.cmdPrintListingWithTotals.Name = "cmdPrintListingWithTotals"
        Me.cmdPrintListingWithTotals.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintListingWithTotals.TabIndex = 17
        Me.cmdPrintListingWithTotals.Text = "Print Listing W/ Totals"
        Me.cmdPrintListingWithTotals.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(857, 720)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(209, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = " - posting ADMIN added to Finished Goods"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.LightGreen
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(826, 714)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(25, 25)
        Me.Button1.TabIndex = 2
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(857, 681)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(135, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = " - posting ADMIN reversed."
        '
        'reversedColor
        '
        Me.reversedColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.reversedColor.BackColor = System.Drawing.Color.LightCoral
        Me.reversedColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reversedColor.Location = New System.Drawing.Point(826, 672)
        Me.reversedColor.Name = "reversedColor"
        Me.reversedColor.Size = New System.Drawing.Size(25, 25)
        Me.reversedColor.TabIndex = 0
        Me.reversedColor.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblTotalWeight)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.lblTotalInventoryPieces)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.lblTotalBlanks)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Location = New System.Drawing.Point(335, 662)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(364, 149)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Totals"
        '
        'lblTotalWeight
        '
        Me.lblTotalWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalWeight.Location = New System.Drawing.Point(189, 104)
        Me.lblTotalWeight.Name = "lblTotalWeight"
        Me.lblTotalWeight.Size = New System.Drawing.Size(160, 23)
        Me.lblTotalWeight.TabIndex = 5
        Me.lblTotalWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(16, 105)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(167, 20)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = "Total Steel Consumed"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalInventoryPieces
        '
        Me.lblTotalInventoryPieces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalInventoryPieces.Location = New System.Drawing.Point(189, 68)
        Me.lblTotalInventoryPieces.Name = "lblTotalInventoryPieces"
        Me.lblTotalInventoryPieces.Size = New System.Drawing.Size(160, 23)
        Me.lblTotalInventoryPieces.TabIndex = 3
        Me.lblTotalInventoryPieces.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(16, 70)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(167, 20)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "Total Inventory Pieces"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalBlanks
        '
        Me.lblTotalBlanks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalBlanks.Location = New System.Drawing.Point(189, 32)
        Me.lblTotalBlanks.Name = "lblTotalBlanks"
        Me.lblTotalBlanks.Size = New System.Drawing.Size(160, 23)
        Me.lblTotalBlanks.TabIndex = 1
        Me.lblTotalBlanks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(16, 35)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(167, 20)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Total Processed by FOX Step"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(826, 771)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(71, 40)
        Me.Button2.TabIndex = 20
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ViewTimeSlipTotals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.reversedColor)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgvTimeSlipPostings)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdPrintListingWithTotals)
        Me.Controls.Add(Me.gpxFilters)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewTimeSlipTotals"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Time Slip Postings"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvTimeSlipPostings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxFilters.ResumeLayout(False)
        Me.gpxFilters.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitrToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboShiftNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvTimeSlipPostings As System.Windows.Forms.DataGridView
    Friend WithEvents cboEmployeeID As System.Windows.Forms.ComboBox
    Friend WithEvents cboFOXNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboMachineNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdViewByFilter As System.Windows.Forms.Button
    Friend WithEvents gpxFilters As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents txtEmployeeName As System.Windows.Forms.TextBox
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FOXNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShiftColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PostingDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents TimeSlipKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtPartDescription As System.Windows.Forms.TextBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintListingWithTotals As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents reversedColor As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotalWeight As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblTotalInventoryPieces As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblTotalBlanks As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ExportTotalMaterialConsumedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkAllTypes As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
