<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewAssemblySerialLog
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
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddSerialNumbersStringToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintSerialListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxViewByPart = New System.Windows.Forms.GroupBox
        Me.txtTextSearch = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.cboWarehouse = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtSerialNumber = New System.Windows.Forms.TextBox
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtLongDescription = New System.Windows.Forms.TextBox
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvSerialLog = New System.Windows.Forms.DataGridView
        Me.AssemblySerialLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AssemblySerialLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblySerialLogTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.cmdUpdateSerialNumber = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmdDeactivateSN = New System.Windows.Forms.Button
        Me.cmdAddSerialNumber = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmdOpenOrClose = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.cmdDeleteSerialNumber = New System.Windows.Forms.Button
        Me.SerialNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentPriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        Me.gpxViewByPart.SuspendLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSerialLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssemblySerialLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.ClearAllToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'ClearAllToolStripMenuItem
        '
        Me.ClearAllToolStripMenuItem.Name = "ClearAllToolStripMenuItem"
        Me.ClearAllToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.ClearAllToolStripMenuItem.Text = "Clear All"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddSerialNumbersStringToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'AddSerialNumbersStringToolStripMenuItem
        '
        Me.AddSerialNumbersStringToolStripMenuItem.Name = "AddSerialNumbersStringToolStripMenuItem"
        Me.AddSerialNumbersStringToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.AddSerialNumbersStringToolStripMenuItem.Text = "Add Serial Numbers (String)"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintSerialListingToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintSerialListingToolStripMenuItem
        '
        Me.PrintSerialListingToolStripMenuItem.Name = "PrintSerialListingToolStripMenuItem"
        Me.PrintSerialListingToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.PrintSerialListingToolStripMenuItem.Text = "Print Serial Listing"
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
        'gpxViewByPart
        '
        Me.gpxViewByPart.Controls.Add(Me.txtTextSearch)
        Me.gpxViewByPart.Controls.Add(Me.Label19)
        Me.gpxViewByPart.Controls.Add(Me.cboWarehouse)
        Me.gpxViewByPart.Controls.Add(Me.Label17)
        Me.gpxViewByPart.Controls.Add(Me.cboCustomerName)
        Me.gpxViewByPart.Controls.Add(Me.Label10)
        Me.gpxViewByPart.Controls.Add(Me.txtSerialNumber)
        Me.gpxViewByPart.Controls.Add(Me.cboCustomerID)
        Me.gpxViewByPart.Controls.Add(Me.Label11)
        Me.gpxViewByPart.Controls.Add(Me.Label4)
        Me.gpxViewByPart.Controls.Add(Me.Label12)
        Me.gpxViewByPart.Controls.Add(Me.Label14)
        Me.gpxViewByPart.Controls.Add(Me.chkDateRange)
        Me.gpxViewByPart.Controls.Add(Me.dtpEndDate)
        Me.gpxViewByPart.Controls.Add(Me.Label9)
        Me.gpxViewByPart.Controls.Add(Me.Label6)
        Me.gpxViewByPart.Controls.Add(Me.cmdView)
        Me.gpxViewByPart.Controls.Add(Me.Label5)
        Me.gpxViewByPart.Controls.Add(Me.Label8)
        Me.gpxViewByPart.Controls.Add(Me.dtpBeginDate)
        Me.gpxViewByPart.Controls.Add(Me.cmdClear)
        Me.gpxViewByPart.Controls.Add(Me.Label2)
        Me.gpxViewByPart.Controls.Add(Me.cboStatus)
        Me.gpxViewByPart.Controls.Add(Me.Label7)
        Me.gpxViewByPart.Controls.Add(Me.txtLongDescription)
        Me.gpxViewByPart.Controls.Add(Me.cboPartDescription)
        Me.gpxViewByPart.Controls.Add(Me.cboPartNumber)
        Me.gpxViewByPart.Controls.Add(Me.cboDivisionID)
        Me.gpxViewByPart.Controls.Add(Me.Label3)
        Me.gpxViewByPart.Controls.Add(Me.Label1)
        Me.gpxViewByPart.Location = New System.Drawing.Point(29, 41)
        Me.gpxViewByPart.Name = "gpxViewByPart"
        Me.gpxViewByPart.Size = New System.Drawing.Size(300, 770)
        Me.gpxViewByPart.TabIndex = 0
        Me.gpxViewByPart.TabStop = False
        Me.gpxViewByPart.Text = "View By Filters"
        '
        'txtTextSearch
        '
        Me.txtTextSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextSearch.Location = New System.Drawing.Point(91, 415)
        Me.txtTextSearch.Name = "txtTextSearch"
        Me.txtTextSearch.Size = New System.Drawing.Size(197, 20)
        Me.txtTextSearch.TabIndex = 8
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(19, 415)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(100, 20)
        Me.Label19.TabIndex = 48
        Me.Label19.Text = "Text Search"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboWarehouse
        '
        Me.cboWarehouse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboWarehouse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboWarehouse.FormattingEnabled = True
        Me.cboWarehouse.Items.AddRange(New Object() {"Bessemer", "Downey", "Hayward", "Lewisville", "Lyndhurst", "Phoenix", "Seattle", "SRL"})
        Me.cboWarehouse.Location = New System.Drawing.Point(130, 322)
        Me.cboWarehouse.Name = "cboWarehouse"
        Me.cboWarehouse.Size = New System.Drawing.Size(158, 21)
        Me.cboWarehouse.TabIndex = 6
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(19, 323)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 20)
        Me.Label17.TabIndex = 46
        Me.Label17.Text = "Cons. Warehouse"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(23, 284)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(265, 21)
        Me.cboCustomerName.TabIndex = 5
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(19, 505)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(230, 20)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "AVAILABLE = Can be assigned to a build."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerialNumber.Location = New System.Drawing.Point(74, 369)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(214, 20)
        Me.txtSerialNumber.TabIndex = 7
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(74, 251)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(214, 21)
        Me.cboCustomerID.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(19, 250)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "Customer"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(19, 369)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Serial #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(19, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(269, 40)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(19, 588)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(264, 33)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(103, 624)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 10
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(107, 693)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(181, 20)
        Me.dtpEndDate.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(19, 545)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 21)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "CLOSED = Sold"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(19, 693)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "End Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(140, 730)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 13
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(19, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Long Description"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(19, 525)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(207, 20)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "OPEN = In Stock (ready for sale)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(107, 657)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(181, 20)
        Me.dtpBeginDate.TabIndex = 11
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(217, 730)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 657)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Begin Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboStatus
        '
        Me.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"AVAILABLE", "OPEN", "CLOSED"})
        Me.cboStatus.Location = New System.Drawing.Point(91, 461)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(197, 21)
        Me.cboStatus.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(19, 462)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Status"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLongDescription
        '
        Me.txtLongDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLongDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLongDescription.Location = New System.Drawing.Point(23, 180)
        Me.txtLongDescription.Multiline = True
        Me.txtLongDescription.Name = "txtLongDescription"
        Me.txtLongDescription.Size = New System.Drawing.Size(265, 51)
        Me.txtLongDescription.TabIndex = 3
        Me.txtLongDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(23, 134)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(265, 21)
        Me.cboPartDescription.TabIndex = 2
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(74, 101)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(214, 21)
        Me.cboPartNumber.TabIndex = 1
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(91, 25)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(197, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(19, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Part #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvSerialLog
        '
        Me.dgvSerialLog.AllowUserToAddRows = False
        Me.dgvSerialLog.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvSerialLog.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSerialLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSerialLog.AutoGenerateColumns = False
        Me.dgvSerialLog.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSerialLog.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSerialLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSerialLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SerialNumberColumn, Me.StatusColumn, Me.AssemblyPartNumberColumn, Me.TotalCostColumn, Me.CustomerIDColumn, Me.CommentColumn, Me.DivisionIDColumn, Me.BuildNumberColumn, Me.BuildDateColumn, Me.ShipmentNumberColumn, Me.ShipmentPriceColumn, Me.ShipmentDateColumn, Me.InvoiceNumberColumn, Me.InvoiceDateColumn, Me.TransactionNumberColumn, Me.BatchNumberColumn})
        Me.dgvSerialLog.DataSource = Me.AssemblySerialLogBindingSource
        Me.dgvSerialLog.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvSerialLog.Location = New System.Drawing.Point(345, 41)
        Me.dgvSerialLog.Name = "dgvSerialLog"
        Me.dgvSerialLog.Size = New System.Drawing.Size(785, 573)
        Me.dgvSerialLog.TabIndex = 14
        Me.dgvSerialLog.TabStop = False
        '
        'AssemblySerialLogBindingSource
        '
        Me.AssemblySerialLogBindingSource.DataMember = "AssemblySerialLog"
        Me.AssemblySerialLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'AssemblySerialLogTableAdapter
        '
        Me.AssemblySerialLogTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 12
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 13
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'cmdUpdateSerialNumber
        '
        Me.cmdUpdateSerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateSerialNumber.ForeColor = System.Drawing.Color.Blue
        Me.cmdUpdateSerialNumber.Location = New System.Drawing.Point(345, 629)
        Me.cmdUpdateSerialNumber.Name = "cmdUpdateSerialNumber"
        Me.cmdUpdateSerialNumber.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateSerialNumber.TabIndex = 15
        Me.cmdUpdateSerialNumber.Text = "Update S/N"
        Me.cmdUpdateSerialNumber.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(422, 633)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(234, 36)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "This will update an available Serial # with the oldest available build and make i" & _
            "t open for sale."
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(422, 679)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(196, 33)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "This will close an AVAILABLE  Serial #  so it will no longer appear on the list."
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeactivateSN
        '
        Me.cmdDeactivateSN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeactivateSN.ForeColor = System.Drawing.Color.Blue
        Me.cmdDeactivateSN.Location = New System.Drawing.Point(345, 675)
        Me.cmdDeactivateSN.Name = "cmdDeactivateSN"
        Me.cmdDeactivateSN.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeactivateSN.TabIndex = 39
        Me.cmdDeactivateSN.Text = "De-Activate S/N"
        Me.cmdDeactivateSN.UseVisualStyleBackColor = True
        '
        'cmdAddSerialNumber
        '
        Me.cmdAddSerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddSerialNumber.ForeColor = System.Drawing.Color.Blue
        Me.cmdAddSerialNumber.Location = New System.Drawing.Point(345, 722)
        Me.cmdAddSerialNumber.Name = "cmdAddSerialNumber"
        Me.cmdAddSerialNumber.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddSerialNumber.TabIndex = 42
        Me.cmdAddSerialNumber.Text = "Add New Serial #"
        Me.cmdAddSerialNumber.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(422, 726)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(196, 33)
        Me.Label16.TabIndex = 43
        Me.Label16.Text = "This will allow you to manually enter a serial # that is not in the system."
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.ForeColor = System.Drawing.Color.Blue
        Me.Label18.Location = New System.Drawing.Point(422, 775)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(196, 33)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "This will allow you to open or close an existing serial #."
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdOpenOrClose
        '
        Me.cmdOpenOrClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenOrClose.ForeColor = System.Drawing.Color.Blue
        Me.cmdOpenOrClose.Location = New System.Drawing.Point(345, 771)
        Me.cmdOpenOrClose.Name = "cmdOpenOrClose"
        Me.cmdOpenOrClose.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenOrClose.TabIndex = 44
        Me.cmdOpenOrClose.Text = "Open / Close"
        Me.cmdOpenOrClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.cmdDeleteSerialNumber)
        Me.GroupBox1.Location = New System.Drawing.Point(776, 629)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(354, 124)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Delete Serial #"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(118, 34)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(219, 58)
        Me.Label20.TabIndex = 42
        Me.Label20.Text = "This will delete an available serial so the number can be re-used, or will delete" & _
            " a closed serial # with no build."
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteSerialNumber
        '
        Me.cmdDeleteSerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteSerialNumber.ForeColor = System.Drawing.Color.Blue
        Me.cmdDeleteSerialNumber.Location = New System.Drawing.Point(24, 46)
        Me.cmdDeleteSerialNumber.Name = "cmdDeleteSerialNumber"
        Me.cmdDeleteSerialNumber.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteSerialNumber.TabIndex = 41
        Me.cmdDeleteSerialNumber.Text = "Delete S/N"
        Me.cmdDeleteSerialNumber.UseVisualStyleBackColor = True
        '
        'SerialNumberColumn
        '
        Me.SerialNumberColumn.DataPropertyName = "SerialNumber"
        Me.SerialNumberColumn.HeaderText = "Serial #"
        Me.SerialNumberColumn.Name = "SerialNumberColumn"
        Me.SerialNumberColumn.ReadOnly = True
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        '
        'AssemblyPartNumberColumn
        '
        Me.AssemblyPartNumberColumn.DataPropertyName = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn.HeaderText = "Part #"
        Me.AssemblyPartNumberColumn.Name = "AssemblyPartNumberColumn"
        Me.AssemblyPartNumberColumn.ReadOnly = True
        Me.AssemblyPartNumberColumn.Width = 200
        '
        'TotalCostColumn
        '
        Me.TotalCostColumn.DataPropertyName = "TotalCost"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.TotalCostColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.TotalCostColumn.HeaderText = "Total Cost"
        Me.TotalCostColumn.Name = "TotalCostColumn"
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        Me.CommentColumn.Width = 200
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        '
        'BuildNumberColumn
        '
        Me.BuildNumberColumn.DataPropertyName = "BuildNumber"
        Me.BuildNumberColumn.HeaderText = "Build #"
        Me.BuildNumberColumn.Name = "BuildNumberColumn"
        Me.BuildNumberColumn.ReadOnly = True
        '
        'BuildDateColumn
        '
        Me.BuildDateColumn.DataPropertyName = "BuildDate"
        Me.BuildDateColumn.HeaderText = "Build Date"
        Me.BuildDateColumn.Name = "BuildDateColumn"
        Me.BuildDateColumn.ReadOnly = True
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "Ship #"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        Me.ShipmentNumberColumn.ReadOnly = True
        '
        'ShipmentPriceColumn
        '
        Me.ShipmentPriceColumn.DataPropertyName = "ShipmentPrice"
        Me.ShipmentPriceColumn.HeaderText = "Ship Price"
        Me.ShipmentPriceColumn.Name = "ShipmentPriceColumn"
        Me.ShipmentPriceColumn.ReadOnly = True
        '
        'ShipmentDateColumn
        '
        Me.ShipmentDateColumn.DataPropertyName = "ShipmentDate"
        Me.ShipmentDateColumn.HeaderText = "Ship Date"
        Me.ShipmentDateColumn.Name = "ShipmentDateColumn"
        Me.ShipmentDateColumn.ReadOnly = True
        '
        'InvoiceNumberColumn
        '
        Me.InvoiceNumberColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn.HeaderText = "Invoice #"
        Me.InvoiceNumberColumn.Name = "InvoiceNumberColumn"
        Me.InvoiceNumberColumn.ReadOnly = True
        '
        'InvoiceDateColumn
        '
        Me.InvoiceDateColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumn.HeaderText = "Invoice Date"
        Me.InvoiceDateColumn.Name = "InvoiceDateColumn"
        Me.InvoiceDateColumn.ReadOnly = True
        '
        'TransactionNumberColumn
        '
        Me.TransactionNumberColumn.DataPropertyName = "TransactionNumber"
        Me.TransactionNumberColumn.HeaderText = "Transaction #"
        Me.TransactionNumberColumn.Name = "TransactionNumberColumn"
        Me.TransactionNumberColumn.ReadOnly = True
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "Batch/Line #"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.ReadOnly = True
        '
        'ViewAssemblySerialLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cmdOpenOrClose)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cmdAddSerialNumber)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cmdDeactivateSN)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cmdUpdateSerialNumber)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvSerialLog)
        Me.Controls.Add(Me.gpxViewByPart)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewAssemblySerialLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Serialized Assembly Log"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxViewByPart.ResumeLayout(False)
        Me.gpxViewByPart.PerformLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSerialLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssemblySerialLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents gpxViewByPart As System.Windows.Forms.GroupBox
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvSerialLog As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents AssemblySerialLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AssemblySerialLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblySerialLogTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents txtLongDescription As System.Windows.Forms.TextBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintSerialListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents cmdUpdateSerialNumber As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmdDeactivateSN As System.Windows.Forms.Button
    Friend WithEvents cmdAddSerialNumber As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboWarehouse As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents AddSerialNumbersStringToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmdOpenOrClose As System.Windows.Forms.Button
    Friend WithEvents txtTextSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteSerialNumber As System.Windows.Forms.Button
    Friend WithEvents SerialNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssemblyPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentPriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
