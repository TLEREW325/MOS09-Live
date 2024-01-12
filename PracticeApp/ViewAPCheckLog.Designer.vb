<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewAPCheckLog
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
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxFilterData = New System.Windows.Forms.GroupBox
        Me.chkACH = New System.Windows.Forms.CheckBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkStandard = New System.Windows.Forms.CheckBox
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.cboVendorClass = New System.Windows.Forms.ComboBox
        Me.VendorClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboAPBatchNumber = New System.Windows.Forms.ComboBox
        Me.APCheckUploadBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.gpxExport = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmdCheckRemittance = New System.Windows.Forms.Button
        Me.cmdBatchRemittance = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdExportACH = New System.Windows.Forms.Button
        Me.cmdExport = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCheckTotal = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.VendorClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorClassTableAdapter
        Me.gpxReprint = New System.Windows.Forms.GroupBox
        Me.cmdReprint = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.dgvAPCheckLog = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APBatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCheckColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccountNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorAccountNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorRoutingNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorAccountTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RemittanceEmailColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WhitePaperCheckColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APCheckUploadTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APCheckUploadTableAdapter
        Me.crxapPaymentBatch1 = New MOS09Program.CRXAPPaymentBatch
        Me.crxptRemittance1 = New MOS09Program.CRXPTRemittance
        Me.MenuStrip1.SuspendLayout()
        Me.gpxFilterData.SuspendLayout()
        CType(Me.VendorClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APCheckUploadBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxExport.SuspendLayout()
        Me.gpxReprint.SuspendLayout()
        CType(Me.dgvAPCheckLog, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToExcelToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.ExportToExcelToolStripMenuItem.Text = "Export to Excel"
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
        'gpxFilterData
        '
        Me.gpxFilterData.Controls.Add(Me.chkACH)
        Me.gpxFilterData.Controls.Add(Me.Label14)
        Me.gpxFilterData.Controls.Add(Me.chkStandard)
        Me.gpxFilterData.Controls.Add(Me.chkDateRange)
        Me.gpxFilterData.Controls.Add(Me.cboVendorClass)
        Me.gpxFilterData.Controls.Add(Me.Label10)
        Me.gpxFilterData.Controls.Add(Me.Label12)
        Me.gpxFilterData.Controls.Add(Me.cboAPBatchNumber)
        Me.gpxFilterData.Controls.Add(Me.txtVendorName)
        Me.gpxFilterData.Controls.Add(Me.cboVendorID)
        Me.gpxFilterData.Controls.Add(Me.Label9)
        Me.gpxFilterData.Controls.Add(Me.cboDivisionID)
        Me.gpxFilterData.Controls.Add(Me.dtpEndDate)
        Me.gpxFilterData.Controls.Add(Me.Label3)
        Me.gpxFilterData.Controls.Add(Me.cmdViewByFilters)
        Me.gpxFilterData.Controls.Add(Me.dtpBeginDate)
        Me.gpxFilterData.Controls.Add(Me.Label2)
        Me.gpxFilterData.Controls.Add(Me.cmdClear)
        Me.gpxFilterData.Controls.Add(Me.Label1)
        Me.gpxFilterData.Controls.Add(Me.Label7)
        Me.gpxFilterData.Location = New System.Drawing.Point(29, 41)
        Me.gpxFilterData.Name = "gpxFilterData"
        Me.gpxFilterData.Size = New System.Drawing.Size(300, 513)
        Me.gpxFilterData.TabIndex = 0
        Me.gpxFilterData.TabStop = False
        Me.gpxFilterData.Text = "View By Filters"
        '
        'chkACH
        '
        Me.chkACH.AutoSize = True
        Me.chkACH.ForeColor = System.Drawing.Color.Black
        Me.chkACH.Location = New System.Drawing.Point(100, 309)
        Me.chkACH.Name = "chkACH"
        Me.chkACH.Size = New System.Drawing.Size(62, 17)
        Me.chkACH.TabIndex = 6
        Me.chkACH.Text = "All ACH"
        Me.chkACH.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(19, 338)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(264, 33)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkStandard
        '
        Me.chkStandard.AutoSize = True
        Me.chkStandard.ForeColor = System.Drawing.Color.Black
        Me.chkStandard.Location = New System.Drawing.Point(100, 280)
        Me.chkStandard.Name = "chkStandard"
        Me.chkStandard.Size = New System.Drawing.Size(108, 17)
        Me.chkStandard.TabIndex = 5
        Me.chkStandard.Text = "Standard Checks"
        Me.chkStandard.UseVisualStyleBackColor = True
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(101, 373)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 7
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'cboVendorClass
        '
        Me.cboVendorClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorClass.DataSource = Me.VendorClassBindingSource
        Me.cboVendorClass.DisplayMember = "VendClassID"
        Me.cboVendorClass.FormattingEnabled = True
        Me.cboVendorClass.Location = New System.Drawing.Point(100, 244)
        Me.cboVendorClass.Name = "cboVendorClass"
        Me.cboVendorClass.Size = New System.Drawing.Size(182, 21)
        Me.cboVendorClass.TabIndex = 4
        '
        'VendorClassBindingSource
        '
        Me.VendorClassBindingSource.DataMember = "VendorClass"
        Me.VendorClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(20, 245)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(130, 20)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "Vendor Class"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(20, 61)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(262, 40)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAPBatchNumber
        '
        Me.cboAPBatchNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAPBatchNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAPBatchNumber.DataSource = Me.APCheckUploadBindingSource
        Me.cboAPBatchNumber.DisplayMember = "APBatchNumber"
        Me.cboAPBatchNumber.FormattingEnabled = True
        Me.cboAPBatchNumber.Location = New System.Drawing.Point(100, 208)
        Me.cboAPBatchNumber.Name = "cboAPBatchNumber"
        Me.cboAPBatchNumber.Size = New System.Drawing.Size(182, 21)
        Me.cboAPBatchNumber.TabIndex = 3
        '
        'APCheckUploadBindingSource
        '
        Me.APCheckUploadBindingSource.DataMember = "APCheckUpload"
        Me.APCheckUploadBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Location = New System.Drawing.Point(17, 140)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(265, 53)
        Me.txtVendorName.TabIndex = 2
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.VendorBindingSource
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(100, 104)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(182, 21)
        Me.cboVendorID.TabIndex = 1
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(20, 209)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(130, 20)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "AP Batch #"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(100, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(182, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(101, 439)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(182, 20)
        Me.dtpEndDate.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(19, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Vendor ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(138, 471)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 10
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(101, 404)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(182, 20)
        Me.dtpBeginDate.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 439)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "End Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(212, 471)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 11
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(19, 404)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Begin Date"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 770)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 14
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 770)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 15
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'gpxExport
        '
        Me.gpxExport.Controls.Add(Me.Label15)
        Me.gpxExport.Controls.Add(Me.cmdCheckRemittance)
        Me.gpxExport.Controls.Add(Me.cmdBatchRemittance)
        Me.gpxExport.Controls.Add(Me.Label13)
        Me.gpxExport.Controls.Add(Me.Label11)
        Me.gpxExport.Controls.Add(Me.Label4)
        Me.gpxExport.Controls.Add(Me.cmdExportACH)
        Me.gpxExport.Controls.Add(Me.cmdExport)
        Me.gpxExport.Location = New System.Drawing.Point(29, 560)
        Me.gpxExport.Name = "gpxExport"
        Me.gpxExport.Size = New System.Drawing.Size(300, 170)
        Me.gpxExport.TabIndex = 12
        Me.gpxExport.TabStop = False
        Me.gpxExport.Text = "Export Functions"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(19, 93)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(186, 30)
        Me.Label15.TabIndex = 50
        Me.Label15.Text = "CHECK REMITTANCE"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCheckRemittance
        '
        Me.cmdCheckRemittance.Location = New System.Drawing.Point(211, 93)
        Me.cmdCheckRemittance.Name = "cmdCheckRemittance"
        Me.cmdCheckRemittance.Size = New System.Drawing.Size(71, 30)
        Me.cmdCheckRemittance.TabIndex = 15
        Me.cmdCheckRemittance.Text = "Print"
        Me.cmdCheckRemittance.UseVisualStyleBackColor = True
        '
        'cmdBatchRemittance
        '
        Me.cmdBatchRemittance.Location = New System.Drawing.Point(211, 130)
        Me.cmdBatchRemittance.Name = "cmdBatchRemittance"
        Me.cmdBatchRemittance.Size = New System.Drawing.Size(71, 30)
        Me.cmdBatchRemittance.TabIndex = 16
        Me.cmdBatchRemittance.Text = "Print"
        Me.cmdBatchRemittance.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(19, 130)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(186, 30)
        Me.Label13.TabIndex = 47
        Me.Label13.Text = "BATCH REMITTANCE"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(19, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(186, 30)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "ACH EXPORT"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(19, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(186, 30)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "POSITIVE PAY EXPORT"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExportACH
        '
        Me.cmdExportACH.Location = New System.Drawing.Point(211, 56)
        Me.cmdExportACH.Name = "cmdExportACH"
        Me.cmdExportACH.Size = New System.Drawing.Size(71, 30)
        Me.cmdExportACH.TabIndex = 14
        Me.cmdExportACH.Text = "Export"
        Me.cmdExportACH.UseVisualStyleBackColor = True
        '
        'cmdExport
        '
        Me.cmdExport.Location = New System.Drawing.Point(211, 19)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(71, 30)
        Me.cmdExport.TabIndex = 13
        Me.cmdExport.Text = "Export"
        Me.cmdExport.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Location = New System.Drawing.Point(449, 782)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 20)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Check Total"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCheckTotal
        '
        Me.txtCheckTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCheckTotal.BackColor = System.Drawing.Color.White
        Me.txtCheckTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckTotal.Location = New System.Drawing.Point(526, 782)
        Me.txtCheckTotal.Name = "txtCheckTotal"
        Me.txtCheckTotal.ReadOnly = True
        Me.txtCheckTotal.Size = New System.Drawing.Size(187, 20)
        Me.txtCheckTotal.TabIndex = 11
        Me.txtCheckTotal.TabStop = False
        Me.txtCheckTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(729, 774)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(161, 33)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "(from datagrid - does not include cancelled checks listed)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'VendorClassTableAdapter
        '
        Me.VendorClassTableAdapter.ClearBeforeFill = True
        '
        'gpxReprint
        '
        Me.gpxReprint.Controls.Add(Me.cmdReprint)
        Me.gpxReprint.Controls.Add(Me.Label6)
        Me.gpxReprint.Location = New System.Drawing.Point(29, 736)
        Me.gpxReprint.Name = "gpxReprint"
        Me.gpxReprint.Size = New System.Drawing.Size(300, 75)
        Me.gpxReprint.TabIndex = 17
        Me.gpxReprint.TabStop = False
        Me.gpxReprint.Text = "Reprint a Check (Admin Only)"
        '
        'cmdReprint
        '
        Me.cmdReprint.Location = New System.Drawing.Point(213, 28)
        Me.cmdReprint.Name = "cmdReprint"
        Me.cmdReprint.Size = New System.Drawing.Size(71, 30)
        Me.cmdReprint.TabIndex = 18
        Me.cmdReprint.Text = "Reprint"
        Me.cmdReprint.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(20, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 33)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Select a check number in the datagrid and press ""Reprint""."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvAPCheckLog
        '
        Me.dgvAPCheckLog.AllowUserToAddRows = False
        Me.dgvAPCheckLog.AllowUserToDeleteRows = False
        Me.dgvAPCheckLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAPCheckLog.AutoGenerateColumns = False
        Me.dgvAPCheckLog.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAPCheckLog.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAPCheckLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAPCheckLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.CheckNumberColumn, Me.VendorNameColumn, Me.CheckDateColumn, Me.CheckAmountColumn, Me.APBatchNumberColumn, Me.VendorClassColumn, Me.CheckStatusColumn, Me.ExtendedCheckColumn, Me.CheckTypeColumn, Me.CheckCodeColumn, Me.AccountNumberColumn, Me.VendorAccountNumberColumn, Me.VendorRoutingNumberColumn, Me.VendorAccountTypeColumn, Me.RemittanceEmailColumn, Me.WhitePaperCheckColumn, Me.VendorIDColumn})
        Me.dgvAPCheckLog.DataSource = Me.APCheckUploadBindingSource
        Me.dgvAPCheckLog.GridColor = System.Drawing.Color.Fuchsia
        Me.dgvAPCheckLog.Location = New System.Drawing.Point(352, 47)
        Me.dgvAPCheckLog.Name = "dgvAPCheckLog"
        Me.dgvAPCheckLog.Size = New System.Drawing.Size(778, 705)
        Me.dgvAPCheckLog.TabIndex = 21
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Width = 60
        '
        'CheckNumberColumn
        '
        Me.CheckNumberColumn.DataPropertyName = "CheckNumber"
        Me.CheckNumberColumn.HeaderText = "Check #"
        Me.CheckNumberColumn.Name = "CheckNumberColumn"
        Me.CheckNumberColumn.ReadOnly = True
        Me.CheckNumberColumn.Width = 80
        '
        'VendorNameColumn
        '
        Me.VendorNameColumn.DataPropertyName = "VendorName"
        Me.VendorNameColumn.HeaderText = "Vendor Name"
        Me.VendorNameColumn.Name = "VendorNameColumn"
        Me.VendorNameColumn.ReadOnly = True
        Me.VendorNameColumn.Width = 140
        '
        'CheckDateColumn
        '
        Me.CheckDateColumn.DataPropertyName = "CheckDate"
        Me.CheckDateColumn.HeaderText = "Check Date"
        Me.CheckDateColumn.Name = "CheckDateColumn"
        Me.CheckDateColumn.ReadOnly = True
        Me.CheckDateColumn.Width = 80
        '
        'CheckAmountColumn
        '
        Me.CheckAmountColumn.DataPropertyName = "CheckAmount"
        Me.CheckAmountColumn.HeaderText = "Check Amount"
        Me.CheckAmountColumn.Name = "CheckAmountColumn"
        Me.CheckAmountColumn.ReadOnly = True
        Me.CheckAmountColumn.Width = 80
        '
        'APBatchNumberColumn
        '
        Me.APBatchNumberColumn.DataPropertyName = "APBatchNumber"
        Me.APBatchNumberColumn.HeaderText = "Batch #"
        Me.APBatchNumberColumn.Name = "APBatchNumberColumn"
        Me.APBatchNumberColumn.ReadOnly = True
        Me.APBatchNumberColumn.Width = 80
        '
        'VendorClassColumn
        '
        Me.VendorClassColumn.DataPropertyName = "VendorClass"
        Me.VendorClassColumn.HeaderText = "Vendor Class"
        Me.VendorClassColumn.Name = "VendorClassColumn"
        Me.VendorClassColumn.ReadOnly = True
        '
        'CheckStatusColumn
        '
        Me.CheckStatusColumn.DataPropertyName = "CheckStatus"
        Me.CheckStatusColumn.HeaderText = "Check Status"
        Me.CheckStatusColumn.Name = "CheckStatusColumn"
        Me.CheckStatusColumn.ReadOnly = True
        '
        'ExtendedCheckColumn
        '
        Me.ExtendedCheckColumn.DataPropertyName = "ExtendedCheck"
        Me.ExtendedCheckColumn.HeaderText = "Extended Check"
        Me.ExtendedCheckColumn.Name = "ExtendedCheckColumn"
        Me.ExtendedCheckColumn.ReadOnly = True
        Me.ExtendedCheckColumn.Visible = False
        '
        'CheckTypeColumn
        '
        Me.CheckTypeColumn.DataPropertyName = "CheckType"
        Me.CheckTypeColumn.HeaderText = "Check Type"
        Me.CheckTypeColumn.Name = "CheckTypeColumn"
        Me.CheckTypeColumn.ReadOnly = True
        '
        'CheckCodeColumn
        '
        Me.CheckCodeColumn.DataPropertyName = "CheckCode"
        Me.CheckCodeColumn.HeaderText = "Vendor Check Type"
        Me.CheckCodeColumn.Name = "CheckCodeColumn"
        Me.CheckCodeColumn.ReadOnly = True
        Me.CheckCodeColumn.Width = 80
        '
        'AccountNumberColumn
        '
        Me.AccountNumberColumn.DataPropertyName = "AccountNumber"
        Me.AccountNumberColumn.HeaderText = "Account Number"
        Me.AccountNumberColumn.Name = "AccountNumberColumn"
        Me.AccountNumberColumn.ReadOnly = True
        Me.AccountNumberColumn.Visible = False
        '
        'VendorAccountNumberColumn
        '
        Me.VendorAccountNumberColumn.DataPropertyName = "VendorAccountNumber"
        Me.VendorAccountNumberColumn.HeaderText = "VendorAccountNumber"
        Me.VendorAccountNumberColumn.Name = "VendorAccountNumberColumn"
        Me.VendorAccountNumberColumn.ReadOnly = True
        Me.VendorAccountNumberColumn.Visible = False
        '
        'VendorRoutingNumberColumn
        '
        Me.VendorRoutingNumberColumn.DataPropertyName = "VendorRoutingNumber"
        Me.VendorRoutingNumberColumn.HeaderText = "VendorRoutingNumber"
        Me.VendorRoutingNumberColumn.Name = "VendorRoutingNumberColumn"
        Me.VendorRoutingNumberColumn.ReadOnly = True
        Me.VendorRoutingNumberColumn.Visible = False
        '
        'VendorAccountTypeColumn
        '
        Me.VendorAccountTypeColumn.DataPropertyName = "VendorAccountType"
        Me.VendorAccountTypeColumn.HeaderText = "VendorAccountType"
        Me.VendorAccountTypeColumn.Name = "VendorAccountTypeColumn"
        Me.VendorAccountTypeColumn.Visible = False
        '
        'RemittanceEmailColumn
        '
        Me.RemittanceEmailColumn.DataPropertyName = "RemittanceEmail"
        Me.RemittanceEmailColumn.HeaderText = "RemittanceEmail"
        Me.RemittanceEmailColumn.Name = "RemittanceEmailColumn"
        Me.RemittanceEmailColumn.Visible = False
        '
        'WhitePaperCheckColumn
        '
        Me.WhitePaperCheckColumn.DataPropertyName = "WhitePaperCheck"
        Me.WhitePaperCheckColumn.HeaderText = "WhitePaperCheck"
        Me.WhitePaperCheckColumn.Name = "WhitePaperCheckColumn"
        Me.WhitePaperCheckColumn.Visible = False
        '
        'VendorIDColumn
        '
        Me.VendorIDColumn.DataPropertyName = "VendorID"
        Me.VendorIDColumn.HeaderText = "Vendor"
        Me.VendorIDColumn.Name = "VendorIDColumn"
        Me.VendorIDColumn.Visible = False
        '
        'APCheckUploadTableAdapter
        '
        Me.APCheckUploadTableAdapter.ClearBeforeFill = True
        '
        'ViewAPCheckLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.dgvAPCheckLog)
        Me.Controls.Add(Me.gpxReprint)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtCheckTotal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.gpxExport)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxFilterData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewAPCheckLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation AP Check Log"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxFilterData.ResumeLayout(False)
        Me.gpxFilterData.PerformLayout()
        CType(Me.VendorClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APCheckUploadBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxExport.ResumeLayout(False)
        Me.gpxReprint.ResumeLayout(False)
        CType(Me.dgvAPCheckLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxFilterData As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboAPBatchNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents gpxExport As System.Windows.Forms.GroupBox
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCheckTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboVendorClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents VendorClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorClassTableAdapter
    Friend WithEvents gpxReprint As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdReprint As System.Windows.Forms.Button
    Friend WithEvents cmdExport As System.Windows.Forms.Button
    Friend WithEvents ExportToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdExportACH As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkACH As System.Windows.Forms.CheckBox
    Friend WithEvents chkStandard As System.Windows.Forms.CheckBox
    Friend WithEvents cmdBatchRemittance As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dgvAPCheckLog As System.Windows.Forms.DataGridView
    Friend WithEvents APCheckUploadBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents APCheckUploadTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APCheckUploadTableAdapter
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmdCheckRemittance As System.Windows.Forms.Button
    Friend WithEvents crxapPaymentBatch1 As MOS09Program.CRXAPPaymentBatch
    Friend WithEvents crxptRemittance1 As MOS09Program.CRXPTRemittance
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APBatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCheckColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorAccountNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorRoutingNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorAccountTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemittanceEmailColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WhitePaperCheckColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
