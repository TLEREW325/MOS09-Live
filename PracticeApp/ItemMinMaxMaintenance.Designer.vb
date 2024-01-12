<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemMinMaxMaintenance
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdClearForm = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.gpxPartNumberData = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.chkOnHand = New System.Windows.Forms.CheckBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.chkShipped = New System.Windows.Forms.CheckBox
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTextFilter3 = New System.Windows.Forms.TextBox
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.cmdViewAll = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtTextFilter2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdOpenItemForm = New System.Windows.Forms.Button
        Me.cboPartNumberLookup = New System.Windows.Forms.ComboBox
        Me.lblMin = New System.Windows.Forms.Label
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.Label14 = New System.Windows.Forms.Label
        Me.ADMInventoryTotalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ADMInventoryTotalTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ADMInventoryTotalTableAdapter
        Me.dgvItemList = New System.Windows.Forms.DataGridView
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.cmdAutoUpdate = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtMinFormula = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtMaxFormula = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.ItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShortDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MinimumStockColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaximumStockColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOnHandColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LastYearShippedToDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalQuantityShippedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalReceivedQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenSOQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenPOQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorReturnQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerReturnQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductionQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCProductionQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyBuildQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StandardCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StandardPriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        Me.gpxPartNumberData.SuspendLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ADMInventoryTotalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveDataToolStripMenuItem, Me.DeleteDataToolStripMenuItem, Me.ClearDataToolStripMenuItem, Me.PrintDataToolStripMenuItem})
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
        'ClearDataToolStripMenuItem
        '
        Me.ClearDataToolStripMenuItem.Name = "ClearDataToolStripMenuItem"
        Me.ClearDataToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.ClearDataToolStripMenuItem.Text = "Clear Data"
        '
        'PrintDataToolStripMenuItem
        '
        Me.PrintDataToolStripMenuItem.Name = "PrintDataToolStripMenuItem"
        Me.PrintDataToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.PrintDataToolStripMenuItem.Text = "Print Data"
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
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(963, 721)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 20
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdClearForm
        '
        Me.cmdClearForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearForm.Location = New System.Drawing.Point(809, 721)
        Me.cmdClearForm.Name = "cmdClearForm"
        Me.cmdClearForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearForm.TabIndex = 17
        Me.cmdClearForm.Text = "Clear"
        Me.cmdClearForm.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(886, 721)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 19
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'gpxPartNumberData
        '
        Me.gpxPartNumberData.Controls.Add(Me.Label15)
        Me.gpxPartNumberData.Controls.Add(Me.cboItemClass)
        Me.gpxPartNumberData.Controls.Add(Me.chkOnHand)
        Me.gpxPartNumberData.Controls.Add(Me.cboDivisionID)
        Me.gpxPartNumberData.Controls.Add(Me.chkShipped)
        Me.gpxPartNumberData.Controls.Add(Me.cboPartNumber)
        Me.gpxPartNumberData.Controls.Add(Me.Label3)
        Me.gpxPartNumberData.Controls.Add(Me.txtTextFilter3)
        Me.gpxPartNumberData.Controls.Add(Me.cboPartDescription)
        Me.gpxPartNumberData.Controls.Add(Me.cmdViewAll)
        Me.gpxPartNumberData.Controls.Add(Me.Label7)
        Me.gpxPartNumberData.Controls.Add(Me.cmdClear)
        Me.gpxPartNumberData.Controls.Add(Me.Label2)
        Me.gpxPartNumberData.Controls.Add(Me.txtTextFilter2)
        Me.gpxPartNumberData.Controls.Add(Me.Label1)
        Me.gpxPartNumberData.Controls.Add(Me.Label8)
        Me.gpxPartNumberData.Controls.Add(Me.txtTextFilter)
        Me.gpxPartNumberData.Controls.Add(Me.Label5)
        Me.gpxPartNumberData.Location = New System.Drawing.Point(29, 41)
        Me.gpxPartNumberData.Name = "gpxPartNumberData"
        Me.gpxPartNumberData.Size = New System.Drawing.Size(300, 470)
        Me.gpxPartNumberData.TabIndex = 0
        Me.gpxPartNumberData.TabStop = False
        Me.gpxPartNumberData.Text = "Part Number Information"
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(15, 60)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(267, 40)
        Me.Label15.TabIndex = 53
        Me.Label15.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.DropDownWidth = 250
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(88, 188)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(193, 21)
        Me.cboItemClass.TabIndex = 3
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'chkOnHand
        '
        Me.chkOnHand.AutoSize = True
        Me.chkOnHand.ForeColor = System.Drawing.Color.Blue
        Me.chkOnHand.Location = New System.Drawing.Point(15, 388)
        Me.chkOnHand.Name = "chkOnHand"
        Me.chkOnHand.Size = New System.Drawing.Size(213, 17)
        Me.chkOnHand.TabIndex = 8
        Me.chkOnHand.Text = "Omit Items With Zero Quantity On Hand"
        Me.chkOnHand.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(89, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(193, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'chkShipped
        '
        Me.chkShipped.AutoSize = True
        Me.chkShipped.ForeColor = System.Drawing.Color.Blue
        Me.chkShipped.Location = New System.Drawing.Point(15, 355)
        Me.chkShipped.Name = "chkShipped"
        Me.chkShipped.Size = New System.Drawing.Size(209, 17)
        Me.chkShipped.TabIndex = 7
        Me.chkShipped.Text = "Omit Items With Zero Quantity Shipped"
        Me.chkShipped.UseVisualStyleBackColor = True
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.DropDownWidth = 250
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(89, 112)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(193, 21)
        Me.cboPartNumber.TabIndex = 1
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(15, 188)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Item Class"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter3
        '
        Me.txtTextFilter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter3.Location = New System.Drawing.Point(88, 310)
        Me.txtTextFilter3.Name = "txtTextFilter3"
        Me.txtTextFilter3.Size = New System.Drawing.Size(193, 20)
        Me.txtTextFilter3.TabIndex = 6
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.DropDownWidth = 300
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(15, 143)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(266, 21)
        Me.cboPartDescription.TabIndex = 2
        '
        'cmdViewAll
        '
        Me.cmdViewAll.Location = New System.Drawing.Point(133, 424)
        Me.cmdViewAll.Name = "cmdViewAll"
        Me.cmdViewAll.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewAll.TabIndex = 9
        Me.cmdViewAll.Text = "View"
        Me.cmdViewAll.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(15, 310)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Text Filter 3"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(210, 424)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 10
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(15, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Part Number"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter2
        '
        Me.txtTextFilter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter2.Location = New System.Drawing.Point(89, 272)
        Me.txtTextFilter2.Name = "txtTextFilter2"
        Me.txtTextFilter2.Size = New System.Drawing.Size(193, 20)
        Me.txtTextFilter2.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(15, 272)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Text Filter 2"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.Location = New System.Drawing.Point(89, 234)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(193, 20)
        Me.txtTextFilter.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(15, 234)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Text Filter 1"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdOpenItemForm
        '
        Me.cmdOpenItemForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenItemForm.ForeColor = System.Drawing.Color.Black
        Me.cmdOpenItemForm.Location = New System.Drawing.Point(732, 720)
        Me.cmdOpenItemForm.Name = "cmdOpenItemForm"
        Me.cmdOpenItemForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenItemForm.TabIndex = 16
        Me.cmdOpenItemForm.Text = "Item Form"
        Me.cmdOpenItemForm.UseVisualStyleBackColor = True
        '
        'cboPartNumberLookup
        '
        Me.cboPartNumberLookup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumberLookup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumberLookup.DataSource = Me.ItemListBindingSource
        Me.cboPartNumberLookup.DisplayMember = "ItemID"
        Me.cboPartNumberLookup.FormattingEnabled = True
        Me.cboPartNumberLookup.Location = New System.Drawing.Point(450, 559)
        Me.cboPartNumberLookup.Name = "cboPartNumberLookup"
        Me.cboPartNumberLookup.Size = New System.Drawing.Size(160, 21)
        Me.cboPartNumberLookup.TabIndex = 13
        '
        'lblMin
        '
        Me.lblMin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMin.ForeColor = System.Drawing.Color.Blue
        Me.lblMin.Location = New System.Drawing.Point(12, 142)
        Me.lblMin.Name = "lblMin"
        Me.lblMin.Size = New System.Drawing.Size(266, 30)
        Me.lblMin.TabIndex = 16
        Me.lblMin.Text = "To AutoUpdate MIN/MAX for selected filter, enter a value in both fields."
        Me.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(369, 541)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(353, 40)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "You may make changes to the Standard Unit Cost and Standard Unit Price in the dat" & _
            "agrid as well. Any other changes must be made in the Item Maintenance Form."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ADMInventoryTotalBindingSource
        '
        Me.ADMInventoryTotalBindingSource.DataMember = "ADMInventoryTotal"
        Me.ADMInventoryTotalBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ADMInventoryTotalTableAdapter
        '
        Me.ADMInventoryTotalTableAdapter.ClearBeforeFill = True
        '
        'dgvItemList
        '
        Me.dgvItemList.AllowUserToAddRows = False
        Me.dgvItemList.AllowUserToDeleteRows = False
        Me.dgvItemList.AllowUserToOrderColumns = True
        Me.dgvItemList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvItemList.AutoGenerateColumns = False
        Me.dgvItemList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvItemList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemIDColumn, Me.ShortDescriptionColumn, Me.MinimumStockColumn, Me.MaximumStockColumn, Me.QuantityOnHandColumn, Me.LastYearShippedToDateColumn, Me.TotalQuantityShippedColumn, Me.DivisionIDColumn, Me.TotalReceivedQuantityColumn, Me.OpenSOQuantityColumn, Me.OpenPOQuantityColumn, Me.AdjustmentQuantityColumn, Me.VendorReturnQuantityColumn, Me.CustomerReturnQuantityColumn, Me.ProductionQuantityColumn, Me.WCProductionQuantityColumn, Me.AssemblyBuildQuantityColumn, Me.ItemClassColumn, Me.StandardCostColumn, Me.StandardPriceColumn})
        Me.dgvItemList.DataSource = Me.ADMInventoryTotalBindingSource
        Me.dgvItemList.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvItemList.Location = New System.Drawing.Point(335, 41)
        Me.dgvItemList.Name = "dgvItemList"
        Me.dgvItemList.Size = New System.Drawing.Size(699, 659)
        Me.dgvItemList.TabIndex = 15
        Me.dgvItemList.TabStop = False
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'cmdAutoUpdate
        '
        Me.cmdAutoUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAutoUpdate.ForeColor = System.Drawing.Color.Blue
        Me.cmdAutoUpdate.Location = New System.Drawing.Point(210, 188)
        Me.cmdAutoUpdate.Name = "cmdAutoUpdate"
        Me.cmdAutoUpdate.Size = New System.Drawing.Size(71, 40)
        Me.cmdAutoUpdate.TabIndex = 14
        Me.cmdAutoUpdate.Text = "Update Min/Max"
        Me.cmdAutoUpdate.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtMinFormula)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lblMin)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtMaxFormula)
        Me.GroupBox1.Controls.Add(Me.cmdAutoUpdate)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 517)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 244)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Update MIN/MAX with Custom Formula"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(12, 188)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(188, 53)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "MAX Value is Total Qty Shipped in the past year divided by # of turns per year."
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMinFormula
        '
        Me.txtMinFormula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMinFormula.Location = New System.Drawing.Point(186, 107)
        Me.txtMinFormula.Name = "txtMinFormula"
        Me.txtMinFormula.Size = New System.Drawing.Size(95, 20)
        Me.txtMinFormula.TabIndex = 13
        Me.txtMinFormula.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 83)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "MIN Formula"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "MAX Formula"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 20)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Number of turns per year"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMaxFormula
        '
        Me.txtMaxFormula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaxFormula.Location = New System.Drawing.Point(186, 54)
        Me.txtMaxFormula.Name = "txtMaxFormula"
        Me.txtMaxFormula.Size = New System.Drawing.Size(95, 20)
        Me.txtMaxFormula.TabIndex = 12
        Me.txtMaxFormula.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(12, 107)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(269, 20)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "Percentage of the MAX (Decimal)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ItemIDColumn
        '
        Me.ItemIDColumn.DataPropertyName = "ItemID"
        Me.ItemIDColumn.HeaderText = "Part #"
        Me.ItemIDColumn.Name = "ItemIDColumn"
        Me.ItemIDColumn.ReadOnly = True
        Me.ItemIDColumn.Width = 120
        '
        'ShortDescriptionColumn
        '
        Me.ShortDescriptionColumn.DataPropertyName = "ShortDescription"
        Me.ShortDescriptionColumn.HeaderText = "Description"
        Me.ShortDescriptionColumn.Name = "ShortDescriptionColumn"
        Me.ShortDescriptionColumn.ReadOnly = True
        Me.ShortDescriptionColumn.Width = 180
        '
        'MinimumStockColumn
        '
        Me.MinimumStockColumn.DataPropertyName = "MinimumStock"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = "0"
        Me.MinimumStockColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.MinimumStockColumn.HeaderText = "MIN"
        Me.MinimumStockColumn.Name = "MinimumStockColumn"
        Me.MinimumStockColumn.ReadOnly = True
        Me.MinimumStockColumn.Width = 85
        '
        'MaximumStockColumn
        '
        Me.MaximumStockColumn.DataPropertyName = "MaximumStock"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        Me.MaximumStockColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.MaximumStockColumn.HeaderText = "MAX"
        Me.MaximumStockColumn.Name = "MaximumStockColumn"
        Me.MaximumStockColumn.ReadOnly = True
        Me.MaximumStockColumn.Width = 85
        '
        'QuantityOnHandColumn
        '
        Me.QuantityOnHandColumn.DataPropertyName = "QuantityOnHand"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.QuantityOnHandColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.QuantityOnHandColumn.HeaderText = "QOH"
        Me.QuantityOnHandColumn.Name = "QuantityOnHandColumn"
        Me.QuantityOnHandColumn.ReadOnly = True
        Me.QuantityOnHandColumn.Width = 85
        '
        'LastYearShippedToDateColumn
        '
        Me.LastYearShippedToDateColumn.DataPropertyName = "LastYearShippedToDate"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.LastYearShippedToDateColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.LastYearShippedToDateColumn.HeaderText = "Sold To Date (Last Year)"
        Me.LastYearShippedToDateColumn.Name = "LastYearShippedToDateColumn"
        Me.LastYearShippedToDateColumn.ReadOnly = True
        Me.LastYearShippedToDateColumn.Width = 90
        '
        'TotalQuantityShippedColumn
        '
        Me.TotalQuantityShippedColumn.DataPropertyName = "TotalQuantityShipped"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.TotalQuantityShippedColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.TotalQuantityShippedColumn.HeaderText = "Sold To Date (Total)"
        Me.TotalQuantityShippedColumn.Name = "TotalQuantityShippedColumn"
        Me.TotalQuantityShippedColumn.ReadOnly = True
        Me.TotalQuantityShippedColumn.Width = 90
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'TotalReceivedQuantityColumn
        '
        Me.TotalReceivedQuantityColumn.DataPropertyName = "TotalReceivedQuantity"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.TotalReceivedQuantityColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.TotalReceivedQuantityColumn.HeaderText = "TotalReceivedQuantity"
        Me.TotalReceivedQuantityColumn.Name = "TotalReceivedQuantityColumn"
        Me.TotalReceivedQuantityColumn.ReadOnly = True
        Me.TotalReceivedQuantityColumn.Visible = False
        '
        'OpenSOQuantityColumn
        '
        Me.OpenSOQuantityColumn.DataPropertyName = "OpenSOQuantity"
        Me.OpenSOQuantityColumn.HeaderText = "OpenSOQuantity"
        Me.OpenSOQuantityColumn.Name = "OpenSOQuantityColumn"
        Me.OpenSOQuantityColumn.ReadOnly = True
        Me.OpenSOQuantityColumn.Visible = False
        '
        'OpenPOQuantityColumn
        '
        Me.OpenPOQuantityColumn.DataPropertyName = "OpenPOQuantity"
        Me.OpenPOQuantityColumn.HeaderText = "OpenPOQuantity"
        Me.OpenPOQuantityColumn.Name = "OpenPOQuantityColumn"
        Me.OpenPOQuantityColumn.ReadOnly = True
        Me.OpenPOQuantityColumn.Visible = False
        '
        'AdjustmentQuantityColumn
        '
        Me.AdjustmentQuantityColumn.DataPropertyName = "AdjustmentQuantity"
        Me.AdjustmentQuantityColumn.HeaderText = "AdjustmentQuantity"
        Me.AdjustmentQuantityColumn.Name = "AdjustmentQuantityColumn"
        Me.AdjustmentQuantityColumn.ReadOnly = True
        Me.AdjustmentQuantityColumn.Visible = False
        '
        'VendorReturnQuantityColumn
        '
        Me.VendorReturnQuantityColumn.DataPropertyName = "VendorReturnQuantity"
        Me.VendorReturnQuantityColumn.HeaderText = "VendorReturnQuantity"
        Me.VendorReturnQuantityColumn.Name = "VendorReturnQuantityColumn"
        Me.VendorReturnQuantityColumn.ReadOnly = True
        Me.VendorReturnQuantityColumn.Visible = False
        '
        'CustomerReturnQuantityColumn
        '
        Me.CustomerReturnQuantityColumn.DataPropertyName = "CustomerReturnQuantity"
        Me.CustomerReturnQuantityColumn.HeaderText = "CustomerReturnQuantity"
        Me.CustomerReturnQuantityColumn.Name = "CustomerReturnQuantityColumn"
        Me.CustomerReturnQuantityColumn.ReadOnly = True
        Me.CustomerReturnQuantityColumn.Visible = False
        '
        'ProductionQuantityColumn
        '
        Me.ProductionQuantityColumn.DataPropertyName = "ProductionQuantity"
        Me.ProductionQuantityColumn.HeaderText = "ProductionQuantity"
        Me.ProductionQuantityColumn.Name = "ProductionQuantityColumn"
        Me.ProductionQuantityColumn.ReadOnly = True
        Me.ProductionQuantityColumn.Visible = False
        '
        'WCProductionQuantityColumn
        '
        Me.WCProductionQuantityColumn.DataPropertyName = "WCProductionQuantity"
        Me.WCProductionQuantityColumn.HeaderText = "WCProductionQuantity"
        Me.WCProductionQuantityColumn.Name = "WCProductionQuantityColumn"
        Me.WCProductionQuantityColumn.ReadOnly = True
        Me.WCProductionQuantityColumn.Visible = False
        '
        'AssemblyBuildQuantityColumn
        '
        Me.AssemblyBuildQuantityColumn.DataPropertyName = "AssemblyBuildQuantity"
        Me.AssemblyBuildQuantityColumn.HeaderText = "AssemblyBuildQuantity"
        Me.AssemblyBuildQuantityColumn.Name = "AssemblyBuildQuantityColumn"
        Me.AssemblyBuildQuantityColumn.ReadOnly = True
        Me.AssemblyBuildQuantityColumn.Visible = False
        '
        'ItemClassColumn
        '
        Me.ItemClassColumn.DataPropertyName = "ItemClass"
        Me.ItemClassColumn.HeaderText = "ItemClass"
        Me.ItemClassColumn.Name = "ItemClassColumn"
        Me.ItemClassColumn.Visible = False
        '
        'StandardCostColumn
        '
        Me.StandardCostColumn.DataPropertyName = "StandardCost"
        Me.StandardCostColumn.HeaderText = "StandardCost"
        Me.StandardCostColumn.Name = "StandardCostColumn"
        Me.StandardCostColumn.Visible = False
        '
        'StandardPriceColumn
        '
        Me.StandardPriceColumn.DataPropertyName = "StandardPrice"
        Me.StandardPriceColumn.HeaderText = "StandardPrice"
        Me.StandardPriceColumn.Name = "StandardPriceColumn"
        Me.StandardPriceColumn.Visible = False
        '
        'ItemMinMaxMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 773)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvItemList)
        Me.Controls.Add(Me.cmdOpenItemForm)
        Me.Controls.Add(Me.gpxPartNumberData)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdClearForm)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cboPartNumberLookup)
        Me.Controls.Add(Me.Label14)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ItemMinMaxMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Min / Max Maintenance"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxPartNumberData.ResumeLayout(False)
        Me.gpxPartNumberData.PerformLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ADMInventoryTotalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdClearForm As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents gpxPartNumberData As System.Windows.Forms.GroupBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cmdViewAll As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents lblMin As System.Windows.Forms.Label
    Friend WithEvents cmdOpenItemForm As System.Windows.Forms.Button
    Friend WithEvents cboPartNumberLookup As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents SaveDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ADMInventoryTotalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ADMInventoryTotalTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ADMInventoryTotalTableAdapter
    Friend WithEvents dgvItemList As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents chkOnHand As System.Windows.Forms.CheckBox
    Friend WithEvents chkShipped As System.Windows.Forms.CheckBox
    Friend WithEvents txtTextFilter3 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TransferQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdAutoUpdate As System.Windows.Forms.Button
    Friend WithEvents BeginningBalanceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMaxFormula As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtMinFormula As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShortDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinimumStockColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaximumStockColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOnHandColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastYearShippedToDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalQuantityShippedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalReceivedQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenSOQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenPOQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorReturnQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerReturnQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductionQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCProductionQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssemblyBuildQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardPriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
