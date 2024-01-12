<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewPartNumberSalesTotals
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxItemSearchFields = New System.Windows.Forms.GroupBox
        Me.chkOmitNonInventory = New System.Windows.Forms.CheckBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtTextFilter5 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtTextFilter4 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTextFilter3 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTextFilter2 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboPurchaseProductLine = New System.Windows.Forms.ComboBox
        Me.PurchaseProductLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cmdViewByFilter = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboSalesProdLine = New System.Windows.Forms.ComboBox
        Me.SalesProductLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.txtTextFilter1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvItemList = New System.Windows.Forms.DataGridView
        Me.ItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShortDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.SalesProductLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesProductLineTableAdapter
        Me.PurchaseProductLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseProductLineTableAdapter
        Me.ItemListSalesDataTempBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemListSalesDataTempTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListSalesDataTempTableAdapter
        Me.lblLoading = New System.Windows.Forms.Label
        Me.bgLoading = New System.ComponentModel.BackgroundWorker
        Me.PartNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LastSalesPriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AverageSalesPriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LastPurchaseCostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AveragePurchaseCostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalQuantitySoldDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalQOHDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvSalesData = New System.Windows.Forms.DataGridView
        Me.PartNumberDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LastSalesPriceDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AverageSalesPriceDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LastPurchaseCostDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AveragePurchaseCostDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalQuantitySoldDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalSalesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalQOHDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LastActivityDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CurrentDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemListSalesDataTempBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.gpxItemSearchFields.SuspendLayout()
        CType(Me.PurchaseProductLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesProductLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListSalesDataTempBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSalesData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListSalesDataTempBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'gpxItemSearchFields
        '
        Me.gpxItemSearchFields.Controls.Add(Me.chkOmitNonInventory)
        Me.gpxItemSearchFields.Controls.Add(Me.Label13)
        Me.gpxItemSearchFields.Controls.Add(Me.txtTextFilter5)
        Me.gpxItemSearchFields.Controls.Add(Me.Label11)
        Me.gpxItemSearchFields.Controls.Add(Me.txtTextFilter4)
        Me.gpxItemSearchFields.Controls.Add(Me.Label10)
        Me.gpxItemSearchFields.Controls.Add(Me.txtTextFilter3)
        Me.gpxItemSearchFields.Controls.Add(Me.Label9)
        Me.gpxItemSearchFields.Controls.Add(Me.txtTextFilter2)
        Me.gpxItemSearchFields.Controls.Add(Me.Label3)
        Me.gpxItemSearchFields.Controls.Add(Me.Label12)
        Me.gpxItemSearchFields.Controls.Add(Me.cboPurchaseProductLine)
        Me.gpxItemSearchFields.Controls.Add(Me.cmdViewByFilter)
        Me.gpxItemSearchFields.Controls.Add(Me.Label5)
        Me.gpxItemSearchFields.Controls.Add(Me.cboDivisionID)
        Me.gpxItemSearchFields.Controls.Add(Me.cboSalesProdLine)
        Me.gpxItemSearchFields.Controls.Add(Me.cmdClear)
        Me.gpxItemSearchFields.Controls.Add(Me.Label7)
        Me.gpxItemSearchFields.Controls.Add(Me.cboPartNumber)
        Me.gpxItemSearchFields.Controls.Add(Me.cboPartDescription)
        Me.gpxItemSearchFields.Controls.Add(Me.txtTextFilter1)
        Me.gpxItemSearchFields.Controls.Add(Me.Label1)
        Me.gpxItemSearchFields.Controls.Add(Me.Label8)
        Me.gpxItemSearchFields.Controls.Add(Me.Label2)
        Me.gpxItemSearchFields.Controls.Add(Me.cboItemClass)
        Me.gpxItemSearchFields.Controls.Add(Me.Label4)
        Me.gpxItemSearchFields.Location = New System.Drawing.Point(29, 41)
        Me.gpxItemSearchFields.Name = "gpxItemSearchFields"
        Me.gpxItemSearchFields.Size = New System.Drawing.Size(300, 770)
        Me.gpxItemSearchFields.TabIndex = 1
        Me.gpxItemSearchFields.TabStop = False
        Me.gpxItemSearchFields.Text = "View By Filters"
        '
        'chkOmitNonInventory
        '
        Me.chkOmitNonInventory.AutoSize = True
        Me.chkOmitNonInventory.Checked = True
        Me.chkOmitNonInventory.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOmitNonInventory.Location = New System.Drawing.Point(95, 198)
        Me.chkOmitNonInventory.Name = "chkOmitNonInventory"
        Me.chkOmitNonInventory.Size = New System.Drawing.Size(145, 17)
        Me.chkOmitNonInventory.TabIndex = 50
        Me.chkOmitNonInventory.Text = "Omit Non-Inventory Items"
        Me.chkOmitNonInventory.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(16, 454)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(269, 38)
        Me.Label13.TabIndex = 49
        Me.Label13.Text = "Use any or all of the text filters. Text filters filter on the part short descrip" & _
            "tion."
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter5
        '
        Me.txtTextFilter5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter5.Location = New System.Drawing.Point(95, 679)
        Me.txtTextFilter5.Name = "txtTextFilter5"
        Me.txtTextFilter5.Size = New System.Drawing.Size(190, 20)
        Me.txtTextFilter5.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 679)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "Contains;"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter4
        '
        Me.txtTextFilter4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter4.Location = New System.Drawing.Point(95, 638)
        Me.txtTextFilter4.Name = "txtTextFilter4"
        Me.txtTextFilter4.Size = New System.Drawing.Size(190, 20)
        Me.txtTextFilter4.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 638)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "Contains;"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter3
        '
        Me.txtTextFilter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter3.Location = New System.Drawing.Point(95, 597)
        Me.txtTextFilter3.Name = "txtTextFilter3"
        Me.txtTextFilter3.Size = New System.Drawing.Size(190, 20)
        Me.txtTextFilter3.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 597)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "Contain;"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter2
        '
        Me.txtTextFilter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter2.Location = New System.Drawing.Point(95, 556)
        Me.txtTextFilter2.Name = "txtTextFilter2"
        Me.txtTextFilter2.Size = New System.Drawing.Size(190, 20)
        Me.txtTextFilter2.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 556)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Contains;"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(20, 63)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(267, 40)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPurchaseProductLine
        '
        Me.cboPurchaseProductLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPurchaseProductLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPurchaseProductLine.DataSource = Me.PurchaseProductLineBindingSource
        Me.cboPurchaseProductLine.DisplayMember = "PurchaseProductLineID"
        Me.cboPurchaseProductLine.FormattingEnabled = True
        Me.cboPurchaseProductLine.Location = New System.Drawing.Point(95, 352)
        Me.cboPurchaseProductLine.Name = "cboPurchaseProductLine"
        Me.cboPurchaseProductLine.Size = New System.Drawing.Size(190, 21)
        Me.cboPurchaseProductLine.TabIndex = 5
        '
        'PurchaseProductLineBindingSource
        '
        Me.PurchaseProductLineBindingSource.DataMember = "PurchaseProductLine"
        Me.PurchaseProductLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmdViewByFilter
        '
        Me.cmdViewByFilter.Location = New System.Drawing.Point(137, 724)
        Me.cmdViewByFilter.Name = "cmdViewByFilter"
        Me.cmdViewByFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilter.TabIndex = 11
        Me.cmdViewByFilter.Text = "View"
        Me.cmdViewByFilter.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 352)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "PPL"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(95, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(190, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboSalesProdLine
        '
        Me.cboSalesProdLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesProdLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesProdLine.DataSource = Me.SalesProductLineBindingSource
        Me.cboSalesProdLine.DisplayMember = "SalesProdLineID"
        Me.cboSalesProdLine.FormattingEnabled = True
        Me.cboSalesProdLine.Location = New System.Drawing.Point(95, 300)
        Me.cboSalesProdLine.Name = "cboSalesProdLine"
        Me.cboSalesProdLine.Size = New System.Drawing.Size(190, 21)
        Me.cboSalesProdLine.TabIndex = 4
        '
        'SalesProductLineBindingSource
        '
        Me.SalesProductLineBindingSource.DataMember = "SalesProductLine"
        Me.SalesProductLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 724)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 12
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 301)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "SPL"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(95, 120)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(190, 21)
        Me.cboPartNumber.TabIndex = 1
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(19, 154)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(266, 21)
        Me.cboPartDescription.TabIndex = 2
        '
        'txtTextFilter1
        '
        Me.txtTextFilter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter1.Location = New System.Drawing.Point(95, 515)
        Me.txtTextFilter1.Name = "txtTextFilter1"
        Me.txtTextFilter1.Size = New System.Drawing.Size(190, 20)
        Me.txtTextFilter1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 515)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Begins with;"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Part Number"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(95, 247)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(190, 21)
        Me.cboItemClass.TabIndex = 3
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 248)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Item Class"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 17
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 18
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvItemList
        '
        Me.dgvItemList.AllowUserToAddRows = False
        Me.dgvItemList.AllowUserToDeleteRows = False
        Me.dgvItemList.AutoGenerateColumns = False
        Me.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemIDColumn, Me.ShortDescriptionColumn})
        Me.dgvItemList.DataSource = Me.ItemListBindingSource
        Me.dgvItemList.Location = New System.Drawing.Point(346, 41)
        Me.dgvItemList.Name = "dgvItemList"
        Me.dgvItemList.Size = New System.Drawing.Size(240, 150)
        Me.dgvItemList.TabIndex = 19
        Me.dgvItemList.Visible = False
        '
        'ItemIDColumn
        '
        Me.ItemIDColumn.DataPropertyName = "ItemID"
        Me.ItemIDColumn.HeaderText = "ItemID"
        Me.ItemIDColumn.Name = "ItemIDColumn"
        '
        'ShortDescriptionColumn
        '
        Me.ShortDescriptionColumn.DataPropertyName = "ShortDescription"
        Me.ShortDescriptionColumn.HeaderText = "ShortDescription"
        Me.ShortDescriptionColumn.Name = "ShortDescriptionColumn"
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'SalesProductLineTableAdapter
        '
        Me.SalesProductLineTableAdapter.ClearBeforeFill = True
        '
        'PurchaseProductLineTableAdapter
        '
        Me.PurchaseProductLineTableAdapter.ClearBeforeFill = True
        '
        'ItemListSalesDataTempBindingSource
        '
        Me.ItemListSalesDataTempBindingSource.DataMember = "ItemListSalesDataTemp"
        Me.ItemListSalesDataTempBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ItemListSalesDataTempTableAdapter
        '
        Me.ItemListSalesDataTempTableAdapter.ClearBeforeFill = True
        '
        'lblLoading
        '
        Me.lblLoading.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLoading.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoading.ForeColor = System.Drawing.Color.Blue
        Me.lblLoading.Location = New System.Drawing.Point(561, 338)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(380, 125)
        Me.lblLoading.TabIndex = 62
        Me.lblLoading.Text = "LOADING..."
        Me.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblLoading.Visible = False
        '
        'bgLoading
        '
        '
        'PartNumberDataGridViewTextBoxColumn
        '
        Me.PartNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn.HeaderText = "Part #"
        Me.PartNumberDataGridViewTextBoxColumn.Name = "PartNumberDataGridViewTextBoxColumn"
        '
        'PartDescriptionDataGridViewTextBoxColumn
        '
        Me.PartDescriptionDataGridViewTextBoxColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.PartDescriptionDataGridViewTextBoxColumn.Name = "PartDescriptionDataGridViewTextBoxColumn"
        '
        'LastSalesPriceDataGridViewTextBoxColumn
        '
        Me.LastSalesPriceDataGridViewTextBoxColumn.DataPropertyName = "LastSalesPrice"
        DataGridViewCellStyle1.Format = "N5"
        DataGridViewCellStyle1.NullValue = "0"
        Me.LastSalesPriceDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.LastSalesPriceDataGridViewTextBoxColumn.HeaderText = "Last Sales Price"
        Me.LastSalesPriceDataGridViewTextBoxColumn.Name = "LastSalesPriceDataGridViewTextBoxColumn"
        '
        'AverageSalesPriceDataGridViewTextBoxColumn
        '
        Me.AverageSalesPriceDataGridViewTextBoxColumn.DataPropertyName = "AverageSalesPrice"
        DataGridViewCellStyle2.Format = "N5"
        DataGridViewCellStyle2.NullValue = "0"
        Me.AverageSalesPriceDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.AverageSalesPriceDataGridViewTextBoxColumn.HeaderText = "Average Sales Price"
        Me.AverageSalesPriceDataGridViewTextBoxColumn.Name = "AverageSalesPriceDataGridViewTextBoxColumn"
        '
        'LastPurchaseCostDataGridViewTextBoxColumn
        '
        Me.LastPurchaseCostDataGridViewTextBoxColumn.DataPropertyName = "LastPurchaseCost"
        DataGridViewCellStyle3.Format = "N5"
        DataGridViewCellStyle3.NullValue = "0"
        Me.LastPurchaseCostDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.LastPurchaseCostDataGridViewTextBoxColumn.HeaderText = "Last Purchase Cost"
        Me.LastPurchaseCostDataGridViewTextBoxColumn.Name = "LastPurchaseCostDataGridViewTextBoxColumn"
        '
        'AveragePurchaseCostDataGridViewTextBoxColumn
        '
        Me.AveragePurchaseCostDataGridViewTextBoxColumn.DataPropertyName = "AveragePurchaseCost"
        DataGridViewCellStyle4.Format = "N5"
        DataGridViewCellStyle4.NullValue = "0"
        Me.AveragePurchaseCostDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.AveragePurchaseCostDataGridViewTextBoxColumn.HeaderText = "Average Purchase Cost"
        Me.AveragePurchaseCostDataGridViewTextBoxColumn.Name = "AveragePurchaseCostDataGridViewTextBoxColumn"
        '
        'TotalQuantitySoldDataGridViewTextBoxColumn
        '
        Me.TotalQuantitySoldDataGridViewTextBoxColumn.DataPropertyName = "TotalQuantitySold"
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = "0"
        Me.TotalQuantitySoldDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.TotalQuantitySoldDataGridViewTextBoxColumn.HeaderText = "Total Quantity Sold"
        Me.TotalQuantitySoldDataGridViewTextBoxColumn.Name = "TotalQuantitySoldDataGridViewTextBoxColumn"
        '
        'TotalQOHDataGridViewTextBoxColumn
        '
        Me.TotalQOHDataGridViewTextBoxColumn.DataPropertyName = "TotalQOH"
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = "0"
        Me.TotalQOHDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.TotalQOHDataGridViewTextBoxColumn.HeaderText = "Total QOH"
        Me.TotalQOHDataGridViewTextBoxColumn.Name = "TotalQOHDataGridViewTextBoxColumn"
        '
        'dgvSalesData
        '
        Me.dgvSalesData.AllowUserToAddRows = False
        Me.dgvSalesData.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvSalesData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvSalesData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSalesData.AutoGenerateColumns = False
        Me.dgvSalesData.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSalesData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSalesData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSalesData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartNumberDataGridViewTextBoxColumn1, Me.PartDescriptionColumn1, Me.LastSalesPriceDataGridViewTextBoxColumn1, Me.AverageSalesPriceDataGridViewTextBoxColumn1, Me.LastPurchaseCostDataGridViewTextBoxColumn1, Me.AveragePurchaseCostDataGridViewTextBoxColumn1, Me.TotalQuantitySoldDataGridViewTextBoxColumn1, Me.TotalSalesDataGridViewTextBoxColumn, Me.TotalQOHDataGridViewTextBoxColumn1, Me.LastActivityDateDataGridViewTextBoxColumn, Me.CurrentDateDataGridViewTextBoxColumn})
        Me.dgvSalesData.DataSource = Me.ItemListSalesDataTempBindingSource1
        Me.dgvSalesData.GridColor = System.Drawing.Color.Purple
        Me.dgvSalesData.Location = New System.Drawing.Point(346, 41)
        Me.dgvSalesData.Name = "dgvSalesData"
        Me.dgvSalesData.Size = New System.Drawing.Size(784, 709)
        Me.dgvSalesData.TabIndex = 63
        '
        'PartNumberDataGridViewTextBoxColumn1
        '
        Me.PartNumberDataGridViewTextBoxColumn1.DataPropertyName = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn1.HeaderText = "Part #"
        Me.PartNumberDataGridViewTextBoxColumn1.Name = "PartNumberDataGridViewTextBoxColumn1"
        Me.PartNumberDataGridViewTextBoxColumn1.Width = 150
        '
        'PartDescriptionColumn1
        '
        Me.PartDescriptionColumn1.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn1.HeaderText = "Description"
        Me.PartDescriptionColumn1.Name = "PartDescriptionColumn1"
        Me.PartDescriptionColumn1.Width = 200
        '
        'LastSalesPriceDataGridViewTextBoxColumn1
        '
        Me.LastSalesPriceDataGridViewTextBoxColumn1.DataPropertyName = "LastSalesPrice"
        DataGridViewCellStyle8.Format = "N4"
        DataGridViewCellStyle8.NullValue = "0"
        Me.LastSalesPriceDataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle8
        Me.LastSalesPriceDataGridViewTextBoxColumn1.HeaderText = "Last Sales Price"
        Me.LastSalesPriceDataGridViewTextBoxColumn1.Name = "LastSalesPriceDataGridViewTextBoxColumn1"
        '
        'AverageSalesPriceDataGridViewTextBoxColumn1
        '
        Me.AverageSalesPriceDataGridViewTextBoxColumn1.DataPropertyName = "AverageSalesPrice"
        DataGridViewCellStyle9.Format = "N4"
        DataGridViewCellStyle9.NullValue = "0"
        Me.AverageSalesPriceDataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle9
        Me.AverageSalesPriceDataGridViewTextBoxColumn1.HeaderText = "Average Sales Price"
        Me.AverageSalesPriceDataGridViewTextBoxColumn1.Name = "AverageSalesPriceDataGridViewTextBoxColumn1"
        '
        'LastPurchaseCostDataGridViewTextBoxColumn1
        '
        Me.LastPurchaseCostDataGridViewTextBoxColumn1.DataPropertyName = "LastPurchaseCost"
        DataGridViewCellStyle10.Format = "N4"
        DataGridViewCellStyle10.NullValue = "0"
        Me.LastPurchaseCostDataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle10
        Me.LastPurchaseCostDataGridViewTextBoxColumn1.HeaderText = "Last Purchase Cost"
        Me.LastPurchaseCostDataGridViewTextBoxColumn1.Name = "LastPurchaseCostDataGridViewTextBoxColumn1"
        '
        'AveragePurchaseCostDataGridViewTextBoxColumn1
        '
        Me.AveragePurchaseCostDataGridViewTextBoxColumn1.DataPropertyName = "AveragePurchaseCost"
        DataGridViewCellStyle11.Format = "N4"
        DataGridViewCellStyle11.NullValue = "0"
        Me.AveragePurchaseCostDataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle11
        Me.AveragePurchaseCostDataGridViewTextBoxColumn1.HeaderText = "Average Purchase Cost"
        Me.AveragePurchaseCostDataGridViewTextBoxColumn1.Name = "AveragePurchaseCostDataGridViewTextBoxColumn1"
        '
        'TotalQuantitySoldDataGridViewTextBoxColumn1
        '
        Me.TotalQuantitySoldDataGridViewTextBoxColumn1.DataPropertyName = "TotalQuantitySold"
        DataGridViewCellStyle12.Format = "N0"
        DataGridViewCellStyle12.NullValue = "0"
        Me.TotalQuantitySoldDataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle12
        Me.TotalQuantitySoldDataGridViewTextBoxColumn1.HeaderText = "Total Quantity Sold"
        Me.TotalQuantitySoldDataGridViewTextBoxColumn1.Name = "TotalQuantitySoldDataGridViewTextBoxColumn1"
        '
        'TotalSalesDataGridViewTextBoxColumn
        '
        Me.TotalSalesDataGridViewTextBoxColumn.DataPropertyName = "TotalSales"
        DataGridViewCellStyle13.Format = "N2"
        DataGridViewCellStyle13.NullValue = "0"
        Me.TotalSalesDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle13
        Me.TotalSalesDataGridViewTextBoxColumn.HeaderText = "Total Sales"
        Me.TotalSalesDataGridViewTextBoxColumn.Name = "TotalSalesDataGridViewTextBoxColumn"
        '
        'TotalQOHDataGridViewTextBoxColumn1
        '
        Me.TotalQOHDataGridViewTextBoxColumn1.DataPropertyName = "TotalQOH"
        DataGridViewCellStyle14.Format = "N0"
        DataGridViewCellStyle14.NullValue = "0"
        Me.TotalQOHDataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle14
        Me.TotalQOHDataGridViewTextBoxColumn1.HeaderText = "QOH"
        Me.TotalQOHDataGridViewTextBoxColumn1.Name = "TotalQOHDataGridViewTextBoxColumn1"
        '
        'LastActivityDateDataGridViewTextBoxColumn
        '
        Me.LastActivityDateDataGridViewTextBoxColumn.DataPropertyName = "LastActivityDate"
        Me.LastActivityDateDataGridViewTextBoxColumn.HeaderText = "Last Activity Date"
        Me.LastActivityDateDataGridViewTextBoxColumn.Name = "LastActivityDateDataGridViewTextBoxColumn"
        '
        'CurrentDateDataGridViewTextBoxColumn
        '
        Me.CurrentDateDataGridViewTextBoxColumn.DataPropertyName = "CurrentDate"
        Me.CurrentDateDataGridViewTextBoxColumn.HeaderText = "CurrentDate"
        Me.CurrentDateDataGridViewTextBoxColumn.Name = "CurrentDateDataGridViewTextBoxColumn"
        Me.CurrentDateDataGridViewTextBoxColumn.Visible = False
        '
        'ItemListSalesDataTempBindingSource1
        '
        Me.ItemListSalesDataTempBindingSource1.DataMember = "ItemListSalesDataTemp"
        Me.ItemListSalesDataTempBindingSource1.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(443, 771)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(521, 38)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "This process may take up to a few minutes, depending on the number of parts in th" & _
            "e filter that you select. "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewPartNumberSalesTotals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblLoading)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxItemSearchFields)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvSalesData)
        Me.Controls.Add(Me.dgvItemList)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewPartNumberSalesTotals"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Company Sales Data"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxItemSearchFields.ResumeLayout(False)
        Me.gpxItemSearchFields.PerformLayout()
        CType(Me.PurchaseProductLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesProductLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListSalesDataTempBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSalesData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListSalesDataTempBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxItemSearchFields As System.Windows.Forms.GroupBox
    Friend WithEvents chkOmitNonInventory As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter5 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter4 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter3 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboPurchaseProductLine As System.Windows.Forms.ComboBox
    Friend WithEvents cmdViewByFilter As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cboSalesProdLine As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents txtTextFilter1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvItemList As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents ItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShortDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents SalesProductLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesProductLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesProductLineTableAdapter
    Friend WithEvents PurchaseProductLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseProductLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseProductLineTableAdapter
    Friend WithEvents ItemListSalesDataTempBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListSalesDataTempTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListSalesDataTempTableAdapter
    Friend WithEvents lblLoading As System.Windows.Forms.Label
    Friend WithEvents bgLoading As System.ComponentModel.BackgroundWorker
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastSalesPriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AverageSalesPriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastPurchaseCostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AveragePurchaseCostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalQuantitySoldDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalQOHDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvSalesData As System.Windows.Forms.DataGridView
    Friend WithEvents ItemListSalesDataTempBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PartNumberDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastSalesPriceDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AverageSalesPriceDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastPurchaseCostDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AveragePurchaseCostDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalQuantitySoldDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalSalesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalQOHDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastActivityDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurrentDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
