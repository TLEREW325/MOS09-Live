﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewConsignmentAdjustments
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxVoucherMaintenance = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.gpxAPVoucherData = New System.Windows.Forms.GroupBox
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cboWarehouse = New System.Windows.Forms.ComboBox
        Me.FOBTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.chkUseDateRange = New System.Windows.Forms.CheckBox
        Me.lblEndingDate = New System.Windows.Forms.Label
        Me.lblBeginningDate = New System.Windows.Forms.Label
        Me.dtpEndingDate = New System.Windows.Forms.DateTimePicker
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.lblWarehouse = New System.Windows.Forms.Label
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvConsignmentAdjustments = New System.Windows.Forms.DataGridView
        Me.ConsignmentAdjustmentTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ConsignmentAdjustmentTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ConsignmentAdjustmentTableTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtTotalAmount = New System.Windows.Forms.TextBox
        Me.txtTotalQuantity = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.FOBTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOBTableTableAdapter
        Me.CustomerClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConsignmentAdjustmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        Me.gpxVoucherMaintenance.SuspendLayout()
        Me.gpxAPVoucherData.SuspendLayout()
        CType(Me.FOBTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvConsignmentAdjustments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ConsignmentAdjustmentTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
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
        'gpxVoucherMaintenance
        '
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label15)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label14)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label12)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label5)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label11)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label8)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label10)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label7)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label6)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label4)
        Me.gpxVoucherMaintenance.Location = New System.Drawing.Point(29, 472)
        Me.gpxVoucherMaintenance.Name = "gpxVoucherMaintenance"
        Me.gpxVoucherMaintenance.Size = New System.Drawing.Size(300, 339)
        Me.gpxVoucherMaintenance.TabIndex = 7
        Me.gpxVoucherMaintenance.TabStop = False
        Me.gpxVoucherMaintenance.Text = "Consignment Warehouse Key"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(16, 151)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(147, 21)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "LSCW - Lake Stevens"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(16, 213)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(147, 21)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "RCW - Renton"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(16, 306)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(147, 21)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "SRL - SRL Industries"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(16, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 21)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "LCW -  Lewisville"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(16, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(147, 21)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "DCW - Downey"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(16, 244)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(147, 21)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "SCW - Seattle"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(16, 89)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(147, 21)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "HCW - Hayward"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(16, 182)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 21)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "PCW - Phoenix"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(16, 275)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(147, 21)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "YCW - Lyndhurst"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(16, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 21)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "BCW - Bessemer"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxAPVoucherData
        '
        Me.gpxAPVoucherData.Controls.Add(Me.txtTextFilter)
        Me.gpxAPVoucherData.Controls.Add(Me.Label13)
        Me.gpxAPVoucherData.Controls.Add(Me.cboWarehouse)
        Me.gpxAPVoucherData.Controls.Add(Me.cboPartNumber)
        Me.gpxAPVoucherData.Controls.Add(Me.chkUseDateRange)
        Me.gpxAPVoucherData.Controls.Add(Me.lblEndingDate)
        Me.gpxAPVoucherData.Controls.Add(Me.lblBeginningDate)
        Me.gpxAPVoucherData.Controls.Add(Me.dtpEndingDate)
        Me.gpxAPVoucherData.Controls.Add(Me.dtpBeginDate)
        Me.gpxAPVoucherData.Controls.Add(Me.lblWarehouse)
        Me.gpxAPVoucherData.Controls.Add(Me.cboPartDescription)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdView)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdClear)
        Me.gpxAPVoucherData.Controls.Add(Me.cboDivisionID)
        Me.gpxAPVoucherData.Controls.Add(Me.Label2)
        Me.gpxAPVoucherData.Controls.Add(Me.Label1)
        Me.gpxAPVoucherData.Location = New System.Drawing.Point(29, 41)
        Me.gpxAPVoucherData.Name = "gpxAPVoucherData"
        Me.gpxAPVoucherData.Size = New System.Drawing.Size(300, 375)
        Me.gpxAPVoucherData.TabIndex = 6
        Me.gpxAPVoucherData.TabStop = False
        Me.gpxAPVoucherData.Text = "View By Filters"
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextFilter.Location = New System.Drawing.Point(111, 186)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(175, 20)
        Me.txtTextFilter.TabIndex = 23
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(14, 186)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 20)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "Text Filter"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboWarehouse
        '
        Me.cboWarehouse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboWarehouse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboWarehouse.DataSource = Me.FOBTableBindingSource
        Me.cboWarehouse.DisplayMember = "FOBID"
        Me.cboWarehouse.FormattingEnabled = True
        Me.cboWarehouse.Location = New System.Drawing.Point(111, 141)
        Me.cboWarehouse.Name = "cboWarehouse"
        Me.cboWarehouse.Size = New System.Drawing.Size(175, 21)
        Me.cboWarehouse.TabIndex = 3
        '
        'FOBTableBindingSource
        '
        Me.FOBTableBindingSource.DataMember = "FOBTable"
        Me.FOBTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(63, 69)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(223, 21)
        Me.cboPartNumber.TabIndex = 1
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'chkUseDateRange
        '
        Me.chkUseDateRange.AutoSize = True
        Me.chkUseDateRange.Location = New System.Drawing.Point(110, 229)
        Me.chkUseDateRange.Name = "chkUseDateRange"
        Me.chkUseDateRange.Size = New System.Drawing.Size(106, 17)
        Me.chkUseDateRange.TabIndex = 4
        Me.chkUseDateRange.Text = "Use Date Range"
        Me.chkUseDateRange.UseVisualStyleBackColor = True
        '
        'lblEndingDate
        '
        Me.lblEndingDate.Location = New System.Drawing.Point(13, 297)
        Me.lblEndingDate.Name = "lblEndingDate"
        Me.lblEndingDate.Size = New System.Drawing.Size(91, 20)
        Me.lblEndingDate.TabIndex = 21
        Me.lblEndingDate.Text = "Ending Date"
        Me.lblEndingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBeginningDate
        '
        Me.lblBeginningDate.Location = New System.Drawing.Point(13, 263)
        Me.lblBeginningDate.Name = "lblBeginningDate"
        Me.lblBeginningDate.Size = New System.Drawing.Size(91, 20)
        Me.lblBeginningDate.TabIndex = 19
        Me.lblBeginningDate.Text = "Beginning Date"
        Me.lblBeginningDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndingDate
        '
        Me.dtpEndingDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndingDate.Location = New System.Drawing.Point(110, 295)
        Me.dtpEndingDate.Name = "dtpEndingDate"
        Me.dtpEndingDate.Size = New System.Drawing.Size(176, 20)
        Me.dtpEndingDate.TabIndex = 6
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(110, 261)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(176, 20)
        Me.dtpBeginDate.TabIndex = 5
        '
        'lblWarehouse
        '
        Me.lblWarehouse.Location = New System.Drawing.Point(14, 142)
        Me.lblWarehouse.Name = "lblWarehouse"
        Me.lblWarehouse.Size = New System.Drawing.Size(101, 20)
        Me.lblWarehouse.TabIndex = 20
        Me.lblWarehouse.Text = "Warehouse"
        Me.lblWarehouse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(17, 96)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(269, 21)
        Me.cboPartDescription.TabIndex = 2
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(137, 328)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 7
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 328)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 8
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(111, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(175, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Part #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 11
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 12
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvConsignmentAdjustments
        '
        Me.dgvConsignmentAdjustments.AllowUserToAddRows = False
        Me.dgvConsignmentAdjustments.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvConsignmentAdjustments.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvConsignmentAdjustments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvConsignmentAdjustments.AutoGenerateColumns = False
        Me.dgvConsignmentAdjustments.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvConsignmentAdjustments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConsignmentAdjustments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerClassColumn, Me.ConsignmentAdjustmentNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityColumn, Me.UnitCostColumn, Me.ExtendedAmountColumn, Me.AdjustmentDateColumn, Me.CommentColumn, Me.DivisionIDColumn})
        Me.dgvConsignmentAdjustments.DataSource = Me.ConsignmentAdjustmentTableBindingSource
        Me.dgvConsignmentAdjustments.GridColor = System.Drawing.Color.Purple
        Me.dgvConsignmentAdjustments.Location = New System.Drawing.Point(343, 41)
        Me.dgvConsignmentAdjustments.Name = "dgvConsignmentAdjustments"
        Me.dgvConsignmentAdjustments.Size = New System.Drawing.Size(687, 644)
        Me.dgvConsignmentAdjustments.TabIndex = 13
        '
        'ConsignmentAdjustmentTableBindingSource
        '
        Me.ConsignmentAdjustmentTableBindingSource.DataMember = "ConsignmentAdjustmentTable"
        Me.ConsignmentAdjustmentTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ConsignmentAdjustmentTableTableAdapter
        '
        Me.ConsignmentAdjustmentTableTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtTotalAmount)
        Me.GroupBox1.Controls.Add(Me.txtTotalQuantity)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(343, 702)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(341, 109)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datagrid Totals"
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.BackColor = System.Drawing.Color.White
        Me.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalAmount.Location = New System.Drawing.Point(138, 69)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.Size = New System.Drawing.Size(181, 20)
        Me.txtTotalAmount.TabIndex = 23
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalQuantity
        '
        Me.txtTotalQuantity.BackColor = System.Drawing.Color.White
        Me.txtTotalQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalQuantity.Location = New System.Drawing.Point(138, 29)
        Me.txtTotalQuantity.Name = "txtTotalQuantity"
        Me.txtTotalQuantity.ReadOnly = True
        Me.txtTotalQuantity.Size = New System.Drawing.Size(181, 20)
        Me.txtTotalQuantity.TabIndex = 22
        Me.txtTotalQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(20, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 20)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Total Amount"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 20)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Total Quantity"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FOBTableTableAdapter
        '
        Me.FOBTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerClassColumn
        '
        Me.CustomerClassColumn.DataPropertyName = "CustomerClass"
        Me.CustomerClassColumn.HeaderText = "Warehouse"
        Me.CustomerClassColumn.Name = "CustomerClassColumn"
        Me.CustomerClassColumn.Width = 80
        '
        'ConsignmentAdjustmentNumberColumn
        '
        Me.ConsignmentAdjustmentNumberColumn.DataPropertyName = "ConsignmentAdjustmentNumber"
        Me.ConsignmentAdjustmentNumberColumn.HeaderText = "Adj. #"
        Me.ConsignmentAdjustmentNumberColumn.Name = "ConsignmentAdjustmentNumberColumn"
        Me.ConsignmentAdjustmentNumberColumn.Width = 80
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        Me.QuantityColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.Width = 80
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle3.Format = "N5"
        DataGridViewCellStyle3.NullValue = "0"
        Me.UnitCostColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.Width = 80
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.ExtendedAmountColumn.HeaderText = "Ext. Amt."
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.Width = 80
        '
        'AdjustmentDateColumn
        '
        Me.AdjustmentDateColumn.DataPropertyName = "AdjustmentDate"
        Me.AdjustmentDateColumn.HeaderText = "Adj. Date"
        Me.AdjustmentDateColumn.Name = "AdjustmentDateColumn"
        Me.AdjustmentDateColumn.Width = 80
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'ViewConsignmentAdjustments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvConsignmentAdjustments)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxVoucherMaintenance)
        Me.Controls.Add(Me.gpxAPVoucherData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewConsignmentAdjustments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Coporation Consignment Adjustments"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxVoucherMaintenance.ResumeLayout(False)
        Me.gpxAPVoucherData.ResumeLayout(False)
        Me.gpxAPVoucherData.PerformLayout()
        CType(Me.FOBTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvConsignmentAdjustments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ConsignmentAdjustmentTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxVoucherMaintenance As System.Windows.Forms.GroupBox
    Friend WithEvents gpxAPVoucherData As System.Windows.Forms.GroupBox
    Friend WithEvents cboWarehouse As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents chkUseDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents lblEndingDate As System.Windows.Forms.Label
    Friend WithEvents lblBeginningDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblWarehouse As System.Windows.Forms.Label
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvConsignmentAdjustments As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ConsignmentAdjustmentTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ConsignmentAdjustmentTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ConsignmentAdjustmentTableTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents FOBTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FOBTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOBTableTableAdapter
    Friend WithEvents CustomerClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConsignmentAdjustmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class