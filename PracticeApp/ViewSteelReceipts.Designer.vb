<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewSteelReceipts
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker
        Me.dtpBegin = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.gpxSteelReceipts = New System.Windows.Forms.GroupBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label7 = New System.Windows.Forms.Label
        Me.chkAllTypes = New System.Windows.Forms.CheckBox
        Me.cboBOL = New System.Windows.Forms.ComboBox
        Me.SteelReceivingHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblBOL = New System.Windows.Forms.Label
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboPONumber = New System.Windows.Forms.ComboBox
        Me.SteelPurchaseOrderHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.cboSteelVendor = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.lblTotalCost = New System.Windows.Forms.Label
        Me.lblTotalWeight = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.SteelPurchaseOrderHeaderTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelPurchaseOrderHeaderTableAdapter
        Me.SteelReceivingHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingHeaderTableTableAdapter
        Me.SteelReceivingLineQuery2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SteelReceivingLineQuery2TableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingLineQuery2TableAdapter
        Me.dgvSteelReceivingLines = New System.Windows.Forms.DataGridView
        Me.ReceivingDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReceivingHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReceivingLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarbonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiveWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelUnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelVendorColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelBOLNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelPONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RequireDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectForInvoiceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelPOLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        Me.gpxSteelReceipts.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelPurchaseOrderHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SteelReceivingLineQuery2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSteelReceivingLines, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1061, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 12
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(984, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 11
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(137, 723)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 10
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(216, 723)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 11
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'dtpEnd
        '
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEnd.Location = New System.Drawing.Point(98, 684)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(189, 20)
        Me.dtpEnd.TabIndex = 9
        '
        'dtpBegin
        '
        Me.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBegin.Location = New System.Drawing.Point(98, 647)
        Me.dtpBegin.Name = "dtpBegin"
        Me.dtpBegin.Size = New System.Drawing.Size(189, 20)
        Me.dtpBegin.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(18, 684)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "End Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 647)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Begin Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxSteelReceipts
        '
        Me.gpxSteelReceipts.Controls.Add(Me.cboDivisionID)
        Me.gpxSteelReceipts.Controls.Add(Me.Label7)
        Me.gpxSteelReceipts.Controls.Add(Me.chkAllTypes)
        Me.gpxSteelReceipts.Controls.Add(Me.cboBOL)
        Me.gpxSteelReceipts.Controls.Add(Me.lblBOL)
        Me.gpxSteelReceipts.Controls.Add(Me.cboSteelSize)
        Me.gpxSteelReceipts.Controls.Add(Me.cboCarbon)
        Me.gpxSteelReceipts.Controls.Add(Me.Label12)
        Me.gpxSteelReceipts.Controls.Add(Me.cboPONumber)
        Me.gpxSteelReceipts.Controls.Add(Me.Label1)
        Me.gpxSteelReceipts.Controls.Add(Me.txtVendorName)
        Me.gpxSteelReceipts.Controls.Add(Me.cboSteelVendor)
        Me.gpxSteelReceipts.Controls.Add(Me.Label6)
        Me.gpxSteelReceipts.Controls.Add(Me.Label14)
        Me.gpxSteelReceipts.Controls.Add(Me.chkDateRange)
        Me.gpxSteelReceipts.Controls.Add(Me.dtpEnd)
        Me.gpxSteelReceipts.Controls.Add(Me.dtpBegin)
        Me.gpxSteelReceipts.Controls.Add(Me.Label5)
        Me.gpxSteelReceipts.Controls.Add(Me.Label3)
        Me.gpxSteelReceipts.Controls.Add(Me.cmdClear)
        Me.gpxSteelReceipts.Controls.Add(Me.Label4)
        Me.gpxSteelReceipts.Controls.Add(Me.Label2)
        Me.gpxSteelReceipts.Controls.Add(Me.cmdView)
        Me.gpxSteelReceipts.Location = New System.Drawing.Point(29, 41)
        Me.gpxSteelReceipts.Name = "gpxSteelReceipts"
        Me.gpxSteelReceipts.Size = New System.Drawing.Size(300, 770)
        Me.gpxSteelReceipts.TabIndex = 0
        Me.gpxSteelReceipts.TabStop = False
        Me.gpxSteelReceipts.Text = "View By Filters"
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(100, 37)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(187, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 20)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "Division ID"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkAllTypes
        '
        Me.chkAllTypes.AutoSize = True
        Me.chkAllTypes.Location = New System.Drawing.Point(119, 176)
        Me.chkAllTypes.Margin = New System.Windows.Forms.Padding(5)
        Me.chkAllTypes.Name = "chkAllTypes"
        Me.chkAllTypes.Size = New System.Drawing.Size(168, 17)
        Me.chkAllTypes.TabIndex = 51
        Me.chkAllTypes.Text = "Show all types for given grade"
        Me.chkAllTypes.UseVisualStyleBackColor = True
        '
        'cboBOL
        '
        Me.cboBOL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBOL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBOL.DataSource = Me.SteelReceivingHeaderTableBindingSource
        Me.cboBOL.DisplayMember = "SteelBOLNumber"
        Me.cboBOL.FormattingEnabled = True
        Me.cboBOL.Location = New System.Drawing.Point(99, 421)
        Me.cboBOL.Name = "cboBOL"
        Me.cboBOL.Size = New System.Drawing.Size(188, 21)
        Me.cboBOL.TabIndex = 5
        '
        'SteelReceivingHeaderTableBindingSource
        '
        Me.SteelReceivingHeaderTableBindingSource.DataMember = "SteelReceivingHeaderTable"
        Me.SteelReceivingHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'lblBOL
        '
        Me.lblBOL.Location = New System.Drawing.Point(14, 422)
        Me.lblBOL.Name = "lblBOL"
        Me.lblBOL.Size = New System.Drawing.Size(100, 20)
        Me.lblBOL.TabIndex = 50
        Me.lblBOL.Text = "Bill of Lading #"
        Me.lblBOL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSteelSize.DisplayMember = "SteelSize"
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(99, 215)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(188, 21)
        Me.cboSteelSize.TabIndex = 2
        '
        'RawMaterialsTableBindingSource
        '
        Me.RawMaterialsTableBindingSource.DataMember = "RawMaterialsTable"
        Me.RawMaterialsTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboCarbon.DisplayMember = "Carbon"
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(99, 133)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(188, 21)
        Me.cboCarbon.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(17, 73)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(277, 40)
        Me.Label12.TabIndex = 48
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPONumber
        '
        Me.cboPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPONumber.DataSource = Me.SteelPurchaseOrderHeaderBindingSource
        Me.cboPONumber.DisplayMember = "SteelPurchaseOrderKey"
        Me.cboPONumber.FormattingEnabled = True
        Me.cboPONumber.Location = New System.Drawing.Point(99, 485)
        Me.cboPONumber.Name = "cboPONumber"
        Me.cboPONumber.Size = New System.Drawing.Size(188, 21)
        Me.cboPONumber.TabIndex = 6
        '
        'SteelPurchaseOrderHeaderBindingSource
        '
        Me.SteelPurchaseOrderHeaderBindingSource.DataMember = "SteelPurchaseOrderHeader"
        Me.SteelPurchaseOrderHeaderBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(14, 486)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Steel PO #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVendorName
        '
        Me.txtVendorName.BackColor = System.Drawing.Color.White
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Location = New System.Drawing.Point(18, 319)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.ReadOnly = True
        Me.txtVendorName.Size = New System.Drawing.Size(270, 50)
        Me.txtVendorName.TabIndex = 4
        '
        'cboSteelVendor
        '
        Me.cboSteelVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelVendor.DataSource = Me.VendorBindingSource
        Me.cboSteelVendor.DisplayMember = "VendorCode"
        Me.cboSteelVendor.FormattingEnabled = True
        Me.cboSteelVendor.Location = New System.Drawing.Point(100, 282)
        Me.cboSteelVendor.Name = "cboSteelVendor"
        Me.cboSteelVendor.Size = New System.Drawing.Size(188, 21)
        Me.cboSteelVendor.TabIndex = 3
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(18, 283)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 20)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Steel Vendor"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(23, 577)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(264, 33)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(96, 613)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 7
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 217)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Steel Size"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Steel Carbon"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'lblTotalCost
        '
        Me.lblTotalCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCost.Location = New System.Drawing.Point(120, 64)
        Me.lblTotalCost.Name = "lblTotalCost"
        Me.lblTotalCost.Size = New System.Drawing.Size(145, 20)
        Me.lblTotalCost.TabIndex = 51
        Me.lblTotalCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalWeight
        '
        Me.lblTotalWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalWeight.Location = New System.Drawing.Point(120, 27)
        Me.lblTotalWeight.Name = "lblTotalWeight"
        Me.lblTotalWeight.Size = New System.Drawing.Size(145, 20)
        Me.lblTotalWeight.TabIndex = 50
        Me.lblTotalWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(21, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 20)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "Total Cost:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(21, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 20)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = "Total Weight:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblTotalWeight)
        Me.GroupBox1.Controls.Add(Me.lblTotalCost)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(346, 700)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(279, 111)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datagrid Totals"
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'SteelPurchaseOrderHeaderTableAdapter
        '
        Me.SteelPurchaseOrderHeaderTableAdapter.ClearBeforeFill = True
        '
        'SteelReceivingHeaderTableTableAdapter
        '
        Me.SteelReceivingHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'SteelReceivingLineQuery2BindingSource
        '
        Me.SteelReceivingLineQuery2BindingSource.DataMember = "SteelReceivingLineQuery2"
        Me.SteelReceivingLineQuery2BindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SteelReceivingLineQuery2TableAdapter
        '
        Me.SteelReceivingLineQuery2TableAdapter.ClearBeforeFill = True
        '
        'dgvSteelReceivingLines
        '
        Me.dgvSteelReceivingLines.AllowUserToAddRows = False
        Me.dgvSteelReceivingLines.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvSteelReceivingLines.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSteelReceivingLines.AutoGenerateColumns = False
        Me.dgvSteelReceivingLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelReceivingLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSteelReceivingLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelReceivingLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReceivingDateColumn, Me.SteelReceivingHeaderKeyColumn, Me.SteelReceivingLineKeyColumn, Me.CarbonColumn, Me.SteelSizeColumn, Me.ReceiveWeightColumn, Me.SteelUnitCostColumn, Me.SteelExtendedCostColumn, Me.LineCommentColumn, Me.SteelVendorColumn, Me.SteelBOLNumberColumn, Me.SteelPONumberColumn, Me.RequireDateColumn, Me.RMIDColumn, Me.LineStatusColumn, Me.ReceivingStatusColumn, Me.SelectForInvoiceColumn, Me.DebitGLAccountColumn, Me.CreditGLAccountColumn, Me.DivisionIDColumn, Me.SteelPOLineNumberColumn})
        Me.dgvSteelReceivingLines.DataSource = Me.SteelReceivingLineQuery2BindingSource
        Me.dgvSteelReceivingLines.Location = New System.Drawing.Point(346, 45)
        Me.dgvSteelReceivingLines.Name = "dgvSteelReceivingLines"
        Me.dgvSteelReceivingLines.Size = New System.Drawing.Size(784, 638)
        Me.dgvSteelReceivingLines.TabIndex = 52
        '
        'ReceivingDateColumn
        '
        Me.ReceivingDateColumn.DataPropertyName = "ReceivingDate"
        Me.ReceivingDateColumn.HeaderText = "Date"
        Me.ReceivingDateColumn.Name = "ReceivingDateColumn"
        Me.ReceivingDateColumn.ReadOnly = True
        Me.ReceivingDateColumn.Width = 80
        '
        'SteelReceivingHeaderKeyColumn
        '
        Me.SteelReceivingHeaderKeyColumn.DataPropertyName = "SteelReceivingHeaderKey"
        Me.SteelReceivingHeaderKeyColumn.HeaderText = "Receiver #"
        Me.SteelReceivingHeaderKeyColumn.Name = "SteelReceivingHeaderKeyColumn"
        Me.SteelReceivingHeaderKeyColumn.ReadOnly = True
        Me.SteelReceivingHeaderKeyColumn.Width = 80
        '
        'SteelReceivingLineKeyColumn
        '
        Me.SteelReceivingLineKeyColumn.DataPropertyName = "SteelReceivingLineKey"
        Me.SteelReceivingLineKeyColumn.HeaderText = "Line #"
        Me.SteelReceivingLineKeyColumn.Name = "SteelReceivingLineKeyColumn"
        Me.SteelReceivingLineKeyColumn.ReadOnly = True
        Me.SteelReceivingLineKeyColumn.Width = 60
        '
        'CarbonColumn
        '
        Me.CarbonColumn.DataPropertyName = "Carbon"
        Me.CarbonColumn.HeaderText = "Carbon"
        Me.CarbonColumn.Name = "CarbonColumn"
        Me.CarbonColumn.ReadOnly = True
        Me.CarbonColumn.Width = 80
        '
        'SteelSizeColumn
        '
        Me.SteelSizeColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn.HeaderText = "Steel Size"
        Me.SteelSizeColumn.Name = "SteelSizeColumn"
        Me.SteelSizeColumn.ReadOnly = True
        Me.SteelSizeColumn.Width = 80
        '
        'ReceiveWeightColumn
        '
        Me.ReceiveWeightColumn.DataPropertyName = "ReceiveWeight"
        Me.ReceiveWeightColumn.HeaderText = "Weight"
        Me.ReceiveWeightColumn.Name = "ReceiveWeightColumn"
        Me.ReceiveWeightColumn.ReadOnly = True
        Me.ReceiveWeightColumn.Width = 80
        '
        'SteelUnitCostColumn
        '
        Me.SteelUnitCostColumn.DataPropertyName = "SteelUnitCost"
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = "0"
        Me.SteelUnitCostColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.SteelUnitCostColumn.HeaderText = "Unit Cost"
        Me.SteelUnitCostColumn.Name = "SteelUnitCostColumn"
        Me.SteelUnitCostColumn.ReadOnly = True
        Me.SteelUnitCostColumn.Width = 80
        '
        'SteelExtendedCostColumn
        '
        Me.SteelExtendedCostColumn.DataPropertyName = "SteelExtendedCost"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.SteelExtendedCostColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.SteelExtendedCostColumn.HeaderText = "Ext. Cost"
        Me.SteelExtendedCostColumn.Name = "SteelExtendedCostColumn"
        Me.SteelExtendedCostColumn.ReadOnly = True
        Me.SteelExtendedCostColumn.Width = 80
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        '
        'SteelVendorColumn
        '
        Me.SteelVendorColumn.DataPropertyName = "SteelVendor"
        Me.SteelVendorColumn.HeaderText = "Steel Vendor"
        Me.SteelVendorColumn.Name = "SteelVendorColumn"
        Me.SteelVendorColumn.ReadOnly = True
        '
        'SteelBOLNumberColumn
        '
        Me.SteelBOLNumberColumn.DataPropertyName = "SteelBOLNumber"
        Me.SteelBOLNumberColumn.HeaderText = "BOL #"
        Me.SteelBOLNumberColumn.Name = "SteelBOLNumberColumn"
        Me.SteelBOLNumberColumn.ReadOnly = True
        '
        'SteelPONumberColumn
        '
        Me.SteelPONumberColumn.DataPropertyName = "SteelPONumber"
        Me.SteelPONumberColumn.HeaderText = "PO #"
        Me.SteelPONumberColumn.Name = "SteelPONumberColumn"
        Me.SteelPONumberColumn.ReadOnly = True
        '
        'RequireDateColumn
        '
        Me.RequireDateColumn.DataPropertyName = "RequireDate"
        Me.RequireDateColumn.HeaderText = "Require Date"
        Me.RequireDateColumn.Name = "RequireDateColumn"
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        Me.RMIDColumn.ReadOnly = True
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "Line Status"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.ReadOnly = True
        Me.LineStatusColumn.Width = 80
        '
        'ReceivingStatusColumn
        '
        Me.ReceivingStatusColumn.DataPropertyName = "ReceivingStatus"
        Me.ReceivingStatusColumn.HeaderText = "Receiving Status"
        Me.ReceivingStatusColumn.Name = "ReceivingStatusColumn"
        Me.ReceivingStatusColumn.ReadOnly = True
        '
        'SelectForInvoiceColumn
        '
        Me.SelectForInvoiceColumn.DataPropertyName = "SelectForInvoice"
        Me.SelectForInvoiceColumn.HeaderText = "Select For Invoice"
        Me.SelectForInvoiceColumn.Name = "SelectForInvoiceColumn"
        Me.SelectForInvoiceColumn.ReadOnly = True
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "Debit Account"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        Me.DebitGLAccountColumn.ReadOnly = True
        Me.DebitGLAccountColumn.Visible = False
        '
        'CreditGLAccountColumn
        '
        Me.CreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumn.HeaderText = "Credit Account"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
        Me.CreditGLAccountColumn.ReadOnly = True
        Me.CreditGLAccountColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'SteelPOLineNumberColumn
        '
        Me.SteelPOLineNumberColumn.DataPropertyName = "SteelPOLineNumber"
        Me.SteelPOLineNumberColumn.HeaderText = "PO Line #"
        Me.SteelPOLineNumberColumn.Name = "SteelPOLineNumberColumn"
        Me.SteelPOLineNumberColumn.ReadOnly = True
        Me.SteelPOLineNumberColumn.Visible = False
        '
        'ViewSteelReceipts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.dgvSteelReceivingLines)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpxSteelReceipts)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewSteelReceipts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Steel Receipts"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxSteelReceipts.ResumeLayout(False)
        Me.gpxSteelReceipts.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelPurchaseOrderHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.SteelReceivingLineQuery2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSteelReceivingLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBegin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gpxSteelReceipts As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents cboPONumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents cboSteelVendor As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboBOL As System.Windows.Forms.ComboBox
    Friend WithEvents lblBOL As System.Windows.Forms.Label
    Friend WithEvents lblTotalCost As System.Windows.Forms.Label
    Friend WithEvents lblTotalWeight As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkAllTypes As System.Windows.Forms.CheckBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents SteelPurchaseOrderHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelPurchaseOrderHeaderTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelPurchaseOrderHeaderTableAdapter
    Friend WithEvents SteelReceivingHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelReceivingHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingHeaderTableTableAdapter
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents SteelReceivingLineQuery2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelReceivingLineQuery2TableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingLineQuery2TableAdapter
    Friend WithEvents dgvSteelReceivingLines As System.Windows.Forms.DataGridView
    Friend WithEvents ReceivingDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReceivingHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReceivingLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiveWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelUnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelVendorColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelBOLNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelPONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RequireDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForInvoiceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelPOLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
