<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewHeatNumberLog
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxAPVoucherData = New System.Windows.Forms.GroupBox
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.txtSteelPONumber = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.cboSteelVendor = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdView = New System.Windows.Forms.Button
        Me.cboHeatNumber = New System.Windows.Forms.ComboBox
        Me.HeatNumberLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdHeatNumberForm = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.HeatNumberLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.cmdViewInspectionReport = New System.Windows.Forms.Button
        Me.dgvHeatNumberLog = New System.Windows.Forms.DataGridView
        Me.HeatFileNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateReceivedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelPONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CoilsInHeatColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PoundsInHeatColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaterialOriginColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BOLNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CEVValueColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YieldColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReductionOfAreaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ElongationColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarbonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ManganeseColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PhosphorusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SulfurColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SiliconColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NickelColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ChromiumColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MolybdenumColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CopperColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TinColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VanadiumColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AluminumColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NitrogenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoronColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TitaniumColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NiobiumColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CobaltColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ZincColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IronColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LeadColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TungstenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MagnesiumColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UltimateYieldColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdUploadMillCert = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.gpxAPVoucherData.SuspendLayout()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvHeatNumberLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        'gpxAPVoucherData
        '
        Me.gpxAPVoucherData.Controls.Add(Me.cboStatus)
        Me.gpxAPVoucherData.Controls.Add(Me.txtSteelPONumber)
        Me.gpxAPVoucherData.Controls.Add(Me.Label12)
        Me.gpxAPVoucherData.Controls.Add(Me.txtVendorName)
        Me.gpxAPVoucherData.Controls.Add(Me.cboSteelVendor)
        Me.gpxAPVoucherData.Controls.Add(Me.Label5)
        Me.gpxAPVoucherData.Controls.Add(Me.cboSteelSize)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdView)
        Me.gpxAPVoucherData.Controls.Add(Me.cboHeatNumber)
        Me.gpxAPVoucherData.Controls.Add(Me.Label6)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdClear)
        Me.gpxAPVoucherData.Controls.Add(Me.cboCarbon)
        Me.gpxAPVoucherData.Controls.Add(Me.Label3)
        Me.gpxAPVoucherData.Controls.Add(Me.Label2)
        Me.gpxAPVoucherData.Controls.Add(Me.Label7)
        Me.gpxAPVoucherData.Controls.Add(Me.Label1)
        Me.gpxAPVoucherData.Location = New System.Drawing.Point(29, 41)
        Me.gpxAPVoucherData.Name = "gpxAPVoucherData"
        Me.gpxAPVoucherData.Size = New System.Drawing.Size(300, 509)
        Me.gpxAPVoucherData.TabIndex = 0
        Me.gpxAPVoucherData.TabStop = False
        Me.gpxAPVoucherData.Text = "View By Filters"
        '
        'cboStatus
        '
        Me.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OPEN", "CLOSED"})
        Me.cboStatus.Location = New System.Drawing.Point(96, 403)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(187, 21)
        Me.cboStatus.TabIndex = 7
        '
        'txtSteelPONumber
        '
        Me.txtSteelPONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelPONumber.Location = New System.Drawing.Point(96, 351)
        Me.txtSteelPONumber.Name = "txtSteelPONumber"
        Me.txtSteelPONumber.Size = New System.Drawing.Size(187, 20)
        Me.txtSteelPONumber.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(14, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(267, 40)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Location = New System.Drawing.Point(16, 252)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(267, 68)
        Me.txtVendorName.TabIndex = 5
        '
        'cboSteelVendor
        '
        Me.cboSteelVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelVendor.DataSource = Me.VendorBindingSource
        Me.cboSteelVendor.DisplayMember = "VendorCode"
        Me.cboSteelVendor.FormattingEnabled = True
        Me.cboSteelVendor.Location = New System.Drawing.Point(94, 216)
        Me.cboSteelVendor.Name = "cboSteelVendor"
        Me.cboSteelVendor.Size = New System.Drawing.Size(189, 21)
        Me.cboSteelVendor.TabIndex = 4
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 217)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Steel Vendor"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSteelSize.DisplayMember = "SteelSize"
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(94, 111)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(189, 21)
        Me.cboSteelSize.TabIndex = 2
        '
        'RawMaterialsTableBindingSource
        '
        Me.RawMaterialsTableBindingSource.DataMember = "RawMaterialsTable"
        Me.RawMaterialsTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(135, 463)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 8
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cboHeatNumber
        '
        Me.cboHeatNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHeatNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHeatNumber.DataSource = Me.HeatNumberLogBindingSource
        Me.cboHeatNumber.DisplayMember = "HeatNumber"
        Me.cboHeatNumber.FormattingEnabled = True
        Me.cboHeatNumber.Location = New System.Drawing.Point(94, 165)
        Me.cboHeatNumber.Name = "cboHeatNumber"
        Me.cboHeatNumber.Size = New System.Drawing.Size(189, 21)
        Me.cboHeatNumber.TabIndex = 3
        '
        'HeatNumberLogBindingSource
        '
        Me.HeatNumberLogBindingSource.DataMember = "HeatNumberLog"
        Me.HeatNumberLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 166)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Heat Number"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(212, 463)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 9
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboCarbon.DisplayMember = "Carbon"
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(94, 80)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(189, 21)
        Me.cboCarbon.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Steel Size"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Carbon"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 351)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Steel PO #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 404)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Status"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(17, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(266, 40)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "This opens the Heat Number Log Form and closes this form."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdHeatNumberForm
        '
        Me.cmdHeatNumberForm.Location = New System.Drawing.Point(212, 59)
        Me.cmdHeatNumberForm.Name = "cmdHeatNumberForm"
        Me.cmdHeatNumberForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdHeatNumberForm.TabIndex = 11
        Me.cmdHeatNumberForm.Text = "Heat # Log"
        Me.cmdHeatNumberForm.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'HeatNumberLogTableAdapter
        '
        Me.HeatNumberLogTableAdapter.ClearBeforeFill = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 12
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 11
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdHeatNumberForm)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 696)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 115)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Open Heat Log"
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'cmdViewInspectionReport
        '
        Me.cmdViewInspectionReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewInspectionReport.Enabled = False
        Me.cmdViewInspectionReport.Location = New System.Drawing.Point(905, 771)
        Me.cmdViewInspectionReport.Name = "cmdViewInspectionReport"
        Me.cmdViewInspectionReport.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewInspectionReport.TabIndex = 13
        Me.cmdViewInspectionReport.Text = "View Insp. Report"
        Me.cmdViewInspectionReport.UseVisualStyleBackColor = True
        '
        'dgvHeatNumberLog
        '
        Me.dgvHeatNumberLog.AllowUserToAddRows = False
        Me.dgvHeatNumberLog.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvHeatNumberLog.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvHeatNumberLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvHeatNumberLog.AutoGenerateColumns = False
        Me.dgvHeatNumberLog.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvHeatNumberLog.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvHeatNumberLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHeatNumberLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.HeatFileNumberColumn, Me.HeatNumberColumn, Me.SteelTypeColumn, Me.SteelSizeColumn, Me.VendorIDColumn, Me.DateReceivedColumn, Me.SteelPONumberColumn, Me.CommentsColumn, Me.CoilsInHeatColumn, Me.PoundsInHeatColumn, Me.MaterialOriginColumn, Me.BOLNumberColumn, Me.CEVValueColumn, Me.StatusColumn, Me.YieldColumn, Me.ReductionOfAreaColumn, Me.ElongationColumn, Me.CarbonColumn, Me.ManganeseColumn, Me.PhosphorusColumn, Me.SulfurColumn, Me.SiliconColumn, Me.NickelColumn, Me.ChromiumColumn, Me.MolybdenumColumn, Me.CopperColumn, Me.TinColumn, Me.VanadiumColumn, Me.AluminumColumn, Me.NitrogenColumn, Me.BoronColumn, Me.TitaniumColumn, Me.NiobiumColumn, Me.CobaltColumn, Me.ZincColumn, Me.IronColumn, Me.LeadColumn, Me.TungstenColumn, Me.MagnesiumColumn, Me.UltimateYieldColumn})
        Me.dgvHeatNumberLog.DataSource = Me.HeatNumberLogBindingSource
        Me.dgvHeatNumberLog.Location = New System.Drawing.Point(347, 41)
        Me.dgvHeatNumberLog.Name = "dgvHeatNumberLog"
        Me.dgvHeatNumberLog.Size = New System.Drawing.Size(783, 721)
        Me.dgvHeatNumberLog.TabIndex = 14
        '
        'HeatFileNumberColumn
        '
        Me.HeatFileNumberColumn.DataPropertyName = "HeatFileNumber"
        Me.HeatFileNumberColumn.HeaderText = "Heat File #"
        Me.HeatFileNumberColumn.Name = "HeatFileNumberColumn"
        Me.HeatFileNumberColumn.Width = 80
        '
        'HeatNumberColumn
        '
        Me.HeatNumberColumn.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumn.HeaderText = "Heat #"
        Me.HeatNumberColumn.Name = "HeatNumberColumn"
        Me.HeatNumberColumn.Width = 80
        '
        'SteelTypeColumn
        '
        Me.SteelTypeColumn.DataPropertyName = "SteelType"
        Me.SteelTypeColumn.HeaderText = "Steel Type"
        Me.SteelTypeColumn.Name = "SteelTypeColumn"
        Me.SteelTypeColumn.Width = 90
        '
        'SteelSizeColumn
        '
        Me.SteelSizeColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn.HeaderText = "Steel Size"
        Me.SteelSizeColumn.Name = "SteelSizeColumn"
        Me.SteelSizeColumn.Width = 90
        '
        'VendorIDColumn
        '
        Me.VendorIDColumn.DataPropertyName = "VendorID"
        Me.VendorIDColumn.HeaderText = "Vendor"
        Me.VendorIDColumn.Name = "VendorIDColumn"
        '
        'DateReceivedColumn
        '
        Me.DateReceivedColumn.DataPropertyName = "DateReceived"
        Me.DateReceivedColumn.HeaderText = "Date Rcd."
        Me.DateReceivedColumn.Name = "DateReceivedColumn"
        Me.DateReceivedColumn.Width = 80
        '
        'SteelPONumberColumn
        '
        Me.SteelPONumberColumn.DataPropertyName = "SteelPONumber"
        Me.SteelPONumberColumn.HeaderText = "PO #"
        Me.SteelPONumberColumn.Name = "SteelPONumberColumn"
        Me.SteelPONumberColumn.Width = 80
        '
        'CommentsColumn
        '
        Me.CommentsColumn.DataPropertyName = "Comments"
        Me.CommentsColumn.HeaderText = "Comments"
        Me.CommentsColumn.Name = "CommentsColumn"
        '
        'CoilsInHeatColumn
        '
        Me.CoilsInHeatColumn.DataPropertyName = "CoilsInHeat"
        Me.CoilsInHeatColumn.HeaderText = "Coils In Heat"
        Me.CoilsInHeatColumn.Name = "CoilsInHeatColumn"
        Me.CoilsInHeatColumn.Width = 80
        '
        'PoundsInHeatColumn
        '
        Me.PoundsInHeatColumn.DataPropertyName = "PoundsInHeat"
        Me.PoundsInHeatColumn.HeaderText = "Pounds In Heat"
        Me.PoundsInHeatColumn.Name = "PoundsInHeatColumn"
        Me.PoundsInHeatColumn.Width = 80
        '
        'MaterialOriginColumn
        '
        Me.MaterialOriginColumn.DataPropertyName = "MaterialOrigin"
        Me.MaterialOriginColumn.HeaderText = "Material Origin"
        Me.MaterialOriginColumn.Name = "MaterialOriginColumn"
        Me.MaterialOriginColumn.Width = 80
        '
        'BOLNumberColumn
        '
        Me.BOLNumberColumn.DataPropertyName = "BOLNumber"
        Me.BOLNumberColumn.HeaderText = "BOL #"
        Me.BOLNumberColumn.Name = "BOLNumberColumn"
        Me.BOLNumberColumn.Width = 80
        '
        'CEVValueColumn
        '
        Me.CEVValueColumn.DataPropertyName = "CEVValue"
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = "0"
        Me.CEVValueColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.CEVValueColumn.HeaderText = "CEV Value"
        Me.CEVValueColumn.Name = "CEVValueColumn"
        Me.CEVValueColumn.Width = 80
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        '
        'YieldColumn
        '
        Me.YieldColumn.DataPropertyName = "Yield"
        Me.YieldColumn.HeaderText = "Yield"
        Me.YieldColumn.Name = "YieldColumn"
        Me.YieldColumn.Visible = False
        '
        'ReductionOfAreaColumn
        '
        Me.ReductionOfAreaColumn.DataPropertyName = "ReductionOfArea"
        Me.ReductionOfAreaColumn.HeaderText = "ReductionOfArea"
        Me.ReductionOfAreaColumn.Name = "ReductionOfAreaColumn"
        Me.ReductionOfAreaColumn.Visible = False
        '
        'ElongationColumn
        '
        Me.ElongationColumn.DataPropertyName = "Elongation"
        Me.ElongationColumn.HeaderText = "Elongation"
        Me.ElongationColumn.Name = "ElongationColumn"
        Me.ElongationColumn.Visible = False
        '
        'CarbonColumn
        '
        Me.CarbonColumn.DataPropertyName = "Carbon"
        Me.CarbonColumn.HeaderText = "Carbon"
        Me.CarbonColumn.Name = "CarbonColumn"
        '
        'ManganeseColumn
        '
        Me.ManganeseColumn.DataPropertyName = "Manganese"
        Me.ManganeseColumn.HeaderText = "Manganese"
        Me.ManganeseColumn.Name = "ManganeseColumn"
        '
        'PhosphorusColumn
        '
        Me.PhosphorusColumn.DataPropertyName = "Phosphorus"
        Me.PhosphorusColumn.HeaderText = "Phosphorus"
        Me.PhosphorusColumn.Name = "PhosphorusColumn"
        '
        'SulfurColumn
        '
        Me.SulfurColumn.DataPropertyName = "Sulfur"
        Me.SulfurColumn.HeaderText = "Sulfur"
        Me.SulfurColumn.Name = "SulfurColumn"
        '
        'SiliconColumn
        '
        Me.SiliconColumn.DataPropertyName = "Silicon"
        Me.SiliconColumn.HeaderText = "Silicon"
        Me.SiliconColumn.Name = "SiliconColumn"
        '
        'NickelColumn
        '
        Me.NickelColumn.DataPropertyName = "Nickel"
        Me.NickelColumn.HeaderText = "Nickel"
        Me.NickelColumn.Name = "NickelColumn"
        '
        'ChromiumColumn
        '
        Me.ChromiumColumn.DataPropertyName = "Chromium"
        Me.ChromiumColumn.HeaderText = "Chromium"
        Me.ChromiumColumn.Name = "ChromiumColumn"
        '
        'MolybdenumColumn
        '
        Me.MolybdenumColumn.DataPropertyName = "Molybdenum"
        Me.MolybdenumColumn.HeaderText = "Molybdenum"
        Me.MolybdenumColumn.Name = "MolybdenumColumn"
        '
        'CopperColumn
        '
        Me.CopperColumn.DataPropertyName = "Copper"
        Me.CopperColumn.HeaderText = "Copper"
        Me.CopperColumn.Name = "CopperColumn"
        '
        'TinColumn
        '
        Me.TinColumn.DataPropertyName = "Tin"
        Me.TinColumn.HeaderText = "Tin"
        Me.TinColumn.Name = "TinColumn"
        '
        'VanadiumColumn
        '
        Me.VanadiumColumn.DataPropertyName = "Vanadium"
        Me.VanadiumColumn.HeaderText = "Vanadium"
        Me.VanadiumColumn.Name = "VanadiumColumn"
        '
        'AluminumColumn
        '
        Me.AluminumColumn.DataPropertyName = "Aluminum"
        Me.AluminumColumn.HeaderText = "Aluminum"
        Me.AluminumColumn.Name = "AluminumColumn"
        '
        'NitrogenColumn
        '
        Me.NitrogenColumn.DataPropertyName = "Nitrogen"
        Me.NitrogenColumn.HeaderText = "Nitrogen"
        Me.NitrogenColumn.Name = "NitrogenColumn"
        '
        'BoronColumn
        '
        Me.BoronColumn.DataPropertyName = "Boron"
        Me.BoronColumn.HeaderText = "Boron"
        Me.BoronColumn.Name = "BoronColumn"
        '
        'TitaniumColumn
        '
        Me.TitaniumColumn.DataPropertyName = "Titanium"
        Me.TitaniumColumn.HeaderText = "Titanium"
        Me.TitaniumColumn.Name = "TitaniumColumn"
        '
        'NiobiumColumn
        '
        Me.NiobiumColumn.DataPropertyName = "Niobium"
        Me.NiobiumColumn.HeaderText = "Niobium"
        Me.NiobiumColumn.Name = "NiobiumColumn"
        '
        'CobaltColumn
        '
        Me.CobaltColumn.DataPropertyName = "Cobalt"
        Me.CobaltColumn.HeaderText = "Cobalt"
        Me.CobaltColumn.Name = "CobaltColumn"
        '
        'ZincColumn
        '
        Me.ZincColumn.DataPropertyName = "Zinc"
        Me.ZincColumn.HeaderText = "Zinc"
        Me.ZincColumn.Name = "ZincColumn"
        '
        'IronColumn
        '
        Me.IronColumn.DataPropertyName = "Iron"
        Me.IronColumn.HeaderText = "Iron"
        Me.IronColumn.Name = "IronColumn"
        '
        'LeadColumn
        '
        Me.LeadColumn.DataPropertyName = "Lead"
        Me.LeadColumn.HeaderText = "Lead"
        Me.LeadColumn.Name = "LeadColumn"
        '
        'TungstenColumn
        '
        Me.TungstenColumn.DataPropertyName = "Tungsten"
        Me.TungstenColumn.HeaderText = "Tungsten"
        Me.TungstenColumn.Name = "TungstenColumn"
        '
        'MagnesiumColumn
        '
        Me.MagnesiumColumn.DataPropertyName = "Magnesium"
        Me.MagnesiumColumn.HeaderText = "Magnesium"
        Me.MagnesiumColumn.Name = "MagnesiumColumn"
        '
        'UltimateYieldColumn
        '
        Me.UltimateYieldColumn.DataPropertyName = "UltimateYield"
        Me.UltimateYieldColumn.HeaderText = "UltimateYield"
        Me.UltimateYieldColumn.Name = "UltimateYieldColumn"
        '
        'cmdUploadMillCert
        '
        Me.cmdUploadMillCert.Location = New System.Drawing.Point(212, 34)
        Me.cmdUploadMillCert.Name = "cmdUploadMillCert"
        Me.cmdUploadMillCert.Size = New System.Drawing.Size(71, 40)
        Me.cmdUploadMillCert.TabIndex = 15
        Me.cmdUploadMillCert.Text = "U/L Mill Cert"
        Me.cmdUploadMillCert.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cmdUploadMillCert)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 573)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 100)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Upload Mill Cert"
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(17, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(189, 55)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Upload a scanned Mill Cert (.pdf) into the system."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewHeatNumberLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvHeatNumberLog)
        Me.Controls.Add(Me.cmdViewInspectionReport)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxAPVoucherData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewHeatNumberLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Heat Number Log"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxAPVoucherData.ResumeLayout(False)
        Me.gpxAPVoucherData.PerformLayout()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvHeatNumberLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxAPVoucherData As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents cmdHeatNumberForm As System.Windows.Forms.Button
    Friend WithEvents cboHeatNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents HeatNumberLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HeatNumberLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboSteelVendor As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSteelPONumber As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdViewInspectionReport As System.Windows.Forms.Button
    Friend WithEvents dgvHeatNumberLog As System.Windows.Forms.DataGridView
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents HeatFileNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateReceivedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelPONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoilsInHeatColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PoundsInHeatColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaterialOriginColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BOLNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEVValueColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YieldColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReductionOfAreaColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ElongationColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ManganeseColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PhosphorusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SulfurColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SiliconColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NickelColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChromiumColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MolybdenumColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CopperColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TinColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VanadiumColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AluminumColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NitrogenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoronColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TitaniumColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NiobiumColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CobaltColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ZincColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IronColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeadColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TungstenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MagnesiumColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UltimateYieldColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdUploadMillCert As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
