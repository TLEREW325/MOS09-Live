<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewItemListing
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
        Me.gpxItemSearchFields = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdCopyPartNumber = New System.Windows.Forms.Button
        Me.cboOtherDivision = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HideItemClass = New System.Windows.Forms.ToolStripMenuItem
        Me.HidePieceWeight = New System.Windows.Forms.ToolStripMenuItem
        Me.HideBoxCount = New System.Windows.Forms.ToolStripMenuItem
        Me.HidePalletCount = New System.Windows.Forms.ToolStripMenuItem
        Me.HideStandardCost = New System.Windows.Forms.ToolStripMenuItem
        Me.HideStandardPrice = New System.Windows.Forms.ToolStripMenuItem
        Me.HideMinStock = New System.Windows.Forms.ToolStripMenuItem
        Me.HideMaxStock = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvItemList = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShortDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PieceWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxCountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletCountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StandardCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StandardPriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MinimumStockColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaximumStockColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LeadTimeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AddAccessoryColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchProdLineIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesProdLineIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OldPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NominalDiameterColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NominalLengthColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LongDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BinPreferenceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.cmdItemForm = New System.Windows.Forms.Button
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.PurchaseProductLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseProductLineTableAdapter
        Me.SalesProductLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesProductLineTableAdapter
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmdPrintQCListingType = New System.Windows.Forms.Button
        Me.gpxItemSearchFields.SuspendLayout()
        CType(Me.PurchaseProductLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesProductLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpxItemSearchFields
        '
        Me.gpxItemSearchFields.Controls.Add(Me.Label16)
        Me.gpxItemSearchFields.Controls.Add(Me.cmdCopyPartNumber)
        Me.gpxItemSearchFields.Controls.Add(Me.cboOtherDivision)
        Me.gpxItemSearchFields.Controls.Add(Me.Label15)
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
        Me.gpxItemSearchFields.TabIndex = 0
        Me.gpxItemSearchFields.TabStop = False
        Me.gpxItemSearchFields.Text = "View By Filters"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(16, 417)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(155, 30)
        Me.Label16.TabIndex = 54
        Me.Label16.Text = "Select part number in datagrid to copy it to your division."
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCopyPartNumber
        '
        Me.cmdCopyPartNumber.Location = New System.Drawing.Point(214, 417)
        Me.cmdCopyPartNumber.Name = "cmdCopyPartNumber"
        Me.cmdCopyPartNumber.Size = New System.Drawing.Size(71, 30)
        Me.cmdCopyPartNumber.TabIndex = 53
        Me.cmdCopyPartNumber.Text = "Copy"
        Me.cmdCopyPartNumber.UseVisualStyleBackColor = True
        '
        'cboOtherDivision
        '
        Me.cboOtherDivision.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboOtherDivision.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboOtherDivision.FormattingEnabled = True
        Me.cboOtherDivision.Items.AddRange(New Object() {"ALB", "ATL", "CBS", "CGO", "CHT", "DEN", "HOU", "SLC", "TFF", "TFJ", "TFT", "TFP", "TOR", "TWD", "TWE"})
        Me.cboOtherDivision.Location = New System.Drawing.Point(95, 379)
        Me.cboOtherDivision.Name = "cboOtherDivision"
        Me.cboOtherDivision.Size = New System.Drawing.Size(190, 21)
        Me.cboOtherDivision.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(16, 380)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 20)
        Me.Label15.TabIndex = 52
        Me.Label15.Text = "Other Division"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkOmitNonInventory
        '
        Me.chkOmitNonInventory.AutoSize = True
        Me.chkOmitNonInventory.Checked = True
        Me.chkOmitNonInventory.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOmitNonInventory.Location = New System.Drawing.Point(95, 176)
        Me.chkOmitNonInventory.Name = "chkOmitNonInventory"
        Me.chkOmitNonInventory.Size = New System.Drawing.Size(145, 17)
        Me.chkOmitNonInventory.TabIndex = 3
        Me.chkOmitNonInventory.Text = "Omit Non-Inventory Items"
        Me.chkOmitNonInventory.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(16, 473)
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
        Me.txtTextFilter5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextFilter5.Location = New System.Drawing.Point(95, 693)
        Me.txtTextFilter5.Name = "txtTextFilter5"
        Me.txtTextFilter5.Size = New System.Drawing.Size(190, 20)
        Me.txtTextFilter5.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 693)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "Contains;"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter4
        '
        Me.txtTextFilter4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextFilter4.Location = New System.Drawing.Point(95, 652)
        Me.txtTextFilter4.Name = "txtTextFilter4"
        Me.txtTextFilter4.Size = New System.Drawing.Size(190, 20)
        Me.txtTextFilter4.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 652)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "Contains;"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter3
        '
        Me.txtTextFilter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextFilter3.Location = New System.Drawing.Point(95, 611)
        Me.txtTextFilter3.Name = "txtTextFilter3"
        Me.txtTextFilter3.Size = New System.Drawing.Size(190, 20)
        Me.txtTextFilter3.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 611)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "Contains;"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter2
        '
        Me.txtTextFilter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextFilter2.Location = New System.Drawing.Point(95, 570)
        Me.txtTextFilter2.Name = "txtTextFilter2"
        Me.txtTextFilter2.Size = New System.Drawing.Size(190, 20)
        Me.txtTextFilter2.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 570)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Contains;"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(16, 63)
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
        Me.cboPurchaseProductLine.Location = New System.Drawing.Point(95, 314)
        Me.cboPurchaseProductLine.Name = "cboPurchaseProductLine"
        Me.cboPurchaseProductLine.Size = New System.Drawing.Size(190, 21)
        Me.cboPurchaseProductLine.TabIndex = 6
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
        Me.cmdViewByFilter.Location = New System.Drawing.Point(137, 729)
        Me.cmdViewByFilter.Name = "cmdViewByFilter"
        Me.cmdViewByFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilter.TabIndex = 13
        Me.cmdViewByFilter.Text = "View"
        Me.cmdViewByFilter.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 315)
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
        Me.cboSalesProdLine.Location = New System.Drawing.Point(95, 273)
        Me.cboSalesProdLine.Name = "cboSalesProdLine"
        Me.cboSalesProdLine.Size = New System.Drawing.Size(190, 21)
        Me.cboSalesProdLine.TabIndex = 5
        '
        'SalesProductLineBindingSource
        '
        Me.SalesProductLineBindingSource.DataMember = "SalesProductLine"
        Me.SalesProductLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 729)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 274)
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
        Me.cboPartNumber.Location = New System.Drawing.Point(58, 106)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(227, 21)
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
        Me.cboPartDescription.Location = New System.Drawing.Point(16, 140)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(266, 21)
        Me.cboPartDescription.TabIndex = 2
        '
        'txtTextFilter1
        '
        Me.txtTextFilter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextFilter1.Location = New System.Drawing.Point(95, 529)
        Me.txtTextFilter1.Name = "txtTextFilter1"
        Me.txtTextFilter1.Size = New System.Drawing.Size(190, 20)
        Me.txtTextFilter1.TabIndex = 8
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
        Me.Label8.Location = New System.Drawing.Point(16, 529)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Begins with;"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Part #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(95, 232)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(190, 21)
        Me.cboItemClass.TabIndex = 4
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 233)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Item Class"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HideItemClass, Me.HidePieceWeight, Me.HideBoxCount, Me.HidePalletCount, Me.HideStandardCost, Me.HideStandardPrice, Me.HideMinStock, Me.HideMaxStock})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'HideItemClass
        '
        Me.HideItemClass.CheckOnClick = True
        Me.HideItemClass.Name = "HideItemClass"
        Me.HideItemClass.Size = New System.Drawing.Size(198, 22)
        Me.HideItemClass.Text = "Hide Item Class Column"
        '
        'HidePieceWeight
        '
        Me.HidePieceWeight.CheckOnClick = True
        Me.HidePieceWeight.Name = "HidePieceWeight"
        Me.HidePieceWeight.Size = New System.Drawing.Size(198, 22)
        Me.HidePieceWeight.Text = "Hide Piece Weight Column"
        '
        'HideBoxCount
        '
        Me.HideBoxCount.CheckOnClick = True
        Me.HideBoxCount.Name = "HideBoxCount"
        Me.HideBoxCount.Size = New System.Drawing.Size(198, 22)
        Me.HideBoxCount.Text = "Hide Box Count Column"
        '
        'HidePalletCount
        '
        Me.HidePalletCount.CheckOnClick = True
        Me.HidePalletCount.Name = "HidePalletCount"
        Me.HidePalletCount.Size = New System.Drawing.Size(198, 22)
        Me.HidePalletCount.Text = "Hide Pallet Count Column"
        '
        'HideStandardCost
        '
        Me.HideStandardCost.CheckOnClick = True
        Me.HideStandardCost.Name = "HideStandardCost"
        Me.HideStandardCost.Size = New System.Drawing.Size(198, 22)
        Me.HideStandardCost.Text = "Hide Standard Cost"
        '
        'HideStandardPrice
        '
        Me.HideStandardPrice.CheckOnClick = True
        Me.HideStandardPrice.Name = "HideStandardPrice"
        Me.HideStandardPrice.Size = New System.Drawing.Size(198, 22)
        Me.HideStandardPrice.Text = "Hide Standard Price"
        '
        'HideMinStock
        '
        Me.HideMinStock.CheckOnClick = True
        Me.HideMinStock.Name = "HideMinStock"
        Me.HideMinStock.Size = New System.Drawing.Size(198, 22)
        Me.HideMinStock.Text = "Hide Min Stock Column"
        '
        'HideMaxStock
        '
        Me.HideMaxStock.CheckOnClick = True
        Me.HideMaxStock.Name = "HideMaxStock"
        Me.HideMaxStock.Size = New System.Drawing.Size(198, 22)
        Me.HideMaxStock.Text = "Hide Max Stock Column"
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
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(984, 776)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 15
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1061, 776)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 16
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvItemList
        '
        Me.dgvItemList.AllowUserToAddRows = False
        Me.dgvItemList.AllowUserToDeleteRows = False
        Me.dgvItemList.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvItemList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvItemList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvItemList.AutoGenerateColumns = False
        Me.dgvItemList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvItemList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.ItemIDColumn, Me.ShortDescriptionColumn, Me.ItemClassColumn, Me.PieceWeightColumn, Me.BoxCountColumn, Me.BoxWeightColumn, Me.PalletCountColumn, Me.StandardCostColumn, Me.StandardPriceColumn, Me.MinimumStockColumn, Me.MaximumStockColumn, Me.LeadTimeColumn, Me.CommentsColumn, Me.FOXNumberColumn, Me.BoxTypeColumn, Me.AddAccessoryColumn, Me.PurchProdLineIDColumn, Me.SalesProdLineIDColumn, Me.OldPartNumberColumn, Me.NominalDiameterColumn, Me.NominalLengthColumn, Me.LongDescriptionColumn, Me.BinPreferenceColumn})
        Me.dgvItemList.DataSource = Me.ItemListBindingSource
        Me.dgvItemList.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvItemList.Location = New System.Drawing.Point(347, 41)
        Me.dgvItemList.Name = "dgvItemList"
        Me.dgvItemList.Size = New System.Drawing.Size(785, 722)
        Me.dgvItemList.TabIndex = 15
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'ItemIDColumn
        '
        Me.ItemIDColumn.DataPropertyName = "ItemID"
        Me.ItemIDColumn.HeaderText = "Part #"
        Me.ItemIDColumn.Name = "ItemIDColumn"
        Me.ItemIDColumn.ReadOnly = True
        '
        'ShortDescriptionColumn
        '
        Me.ShortDescriptionColumn.DataPropertyName = "ShortDescription"
        Me.ShortDescriptionColumn.HeaderText = "Description"
        Me.ShortDescriptionColumn.Name = "ShortDescriptionColumn"
        '
        'ItemClassColumn
        '
        Me.ItemClassColumn.DataPropertyName = "ItemClass"
        Me.ItemClassColumn.HeaderText = "Item Class"
        Me.ItemClassColumn.Name = "ItemClassColumn"
        Me.ItemClassColumn.ReadOnly = True
        '
        'PieceWeightColumn
        '
        Me.PieceWeightColumn.DataPropertyName = "PieceWeight"
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = "0"
        Me.PieceWeightColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.PieceWeightColumn.HeaderText = "Piece Weight"
        Me.PieceWeightColumn.Name = "PieceWeightColumn"
        Me.PieceWeightColumn.Width = 80
        '
        'BoxCountColumn
        '
        Me.BoxCountColumn.DataPropertyName = "BoxCount"
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.BoxCountColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.BoxCountColumn.HeaderText = "Box Count"
        Me.BoxCountColumn.Name = "BoxCountColumn"
        Me.BoxCountColumn.Width = 80
        '
        'BoxWeightColumn
        '
        Me.BoxWeightColumn.DataPropertyName = "BoxWeight"
        Me.BoxWeightColumn.HeaderText = "Box Weight"
        Me.BoxWeightColumn.Name = "BoxWeightColumn"
        '
        'PalletCountColumn
        '
        Me.PalletCountColumn.DataPropertyName = "PalletCount"
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = "0"
        Me.PalletCountColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.PalletCountColumn.HeaderText = "Pallet Count"
        Me.PalletCountColumn.Name = "PalletCountColumn"
        Me.PalletCountColumn.Width = 80
        '
        'StandardCostColumn
        '
        Me.StandardCostColumn.DataPropertyName = "StandardCost"
        DataGridViewCellStyle5.Format = "N4"
        DataGridViewCellStyle5.NullValue = "0"
        Me.StandardCostColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.StandardCostColumn.HeaderText = "Std. Cost"
        Me.StandardCostColumn.Name = "StandardCostColumn"
        Me.StandardCostColumn.Width = 80
        '
        'StandardPriceColumn
        '
        Me.StandardPriceColumn.DataPropertyName = "StandardPrice"
        DataGridViewCellStyle6.Format = "C4"
        DataGridViewCellStyle6.NullValue = "0"
        Me.StandardPriceColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.StandardPriceColumn.HeaderText = "Std. Price"
        Me.StandardPriceColumn.Name = "StandardPriceColumn"
        Me.StandardPriceColumn.Width = 80
        '
        'MinimumStockColumn
        '
        Me.MinimumStockColumn.DataPropertyName = "MinimumStock"
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = "0"
        Me.MinimumStockColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.MinimumStockColumn.HeaderText = "Min. Stock"
        Me.MinimumStockColumn.Name = "MinimumStockColumn"
        Me.MinimumStockColumn.Width = 80
        '
        'MaximumStockColumn
        '
        Me.MaximumStockColumn.DataPropertyName = "MaximumStock"
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = "0"
        Me.MaximumStockColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.MaximumStockColumn.HeaderText = "Max. Stock"
        Me.MaximumStockColumn.Name = "MaximumStockColumn"
        Me.MaximumStockColumn.Width = 80
        '
        'LeadTimeColumn
        '
        Me.LeadTimeColumn.DataPropertyName = "LeadTime"
        Me.LeadTimeColumn.HeaderText = "Lead Time"
        Me.LeadTimeColumn.Name = "LeadTimeColumn"
        '
        'CommentsColumn
        '
        Me.CommentsColumn.DataPropertyName = "Comments"
        Me.CommentsColumn.HeaderText = "Comments"
        Me.CommentsColumn.Name = "CommentsColumn"
        '
        'FOXNumberColumn
        '
        Me.FOXNumberColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumn.HeaderText = "FOX #"
        Me.FOXNumberColumn.Name = "FOXNumberColumn"
        Me.FOXNumberColumn.ReadOnly = True
        Me.FOXNumberColumn.Width = 80
        '
        'BoxTypeColumn
        '
        Me.BoxTypeColumn.DataPropertyName = "BoxType"
        Me.BoxTypeColumn.HeaderText = "Box Type"
        Me.BoxTypeColumn.Name = "BoxTypeColumn"
        '
        'AddAccessoryColumn
        '
        Me.AddAccessoryColumn.DataPropertyName = "AddAccessory"
        Me.AddAccessoryColumn.HeaderText = "Add Accessory?"
        Me.AddAccessoryColumn.Name = "AddAccessoryColumn"
        '
        'PurchProdLineIDColumn
        '
        Me.PurchProdLineIDColumn.DataPropertyName = "PurchProdLineID"
        Me.PurchProdLineIDColumn.HeaderText = "PPL ID"
        Me.PurchProdLineIDColumn.Name = "PurchProdLineIDColumn"
        Me.PurchProdLineIDColumn.ReadOnly = True
        '
        'SalesProdLineIDColumn
        '
        Me.SalesProdLineIDColumn.DataPropertyName = "SalesProdLineID"
        Me.SalesProdLineIDColumn.HeaderText = "SPL ID"
        Me.SalesProdLineIDColumn.Name = "SalesProdLineIDColumn"
        Me.SalesProdLineIDColumn.ReadOnly = True
        '
        'OldPartNumberColumn
        '
        Me.OldPartNumberColumn.DataPropertyName = "OldPartNumber"
        Me.OldPartNumberColumn.HeaderText = "Old Part #"
        Me.OldPartNumberColumn.Name = "OldPartNumberColumn"
        '
        'NominalDiameterColumn
        '
        Me.NominalDiameterColumn.DataPropertyName = "NominalDiameter"
        Me.NominalDiameterColumn.HeaderText = "Nom. Diameter"
        Me.NominalDiameterColumn.Name = "NominalDiameterColumn"
        Me.NominalDiameterColumn.Width = 80
        '
        'NominalLengthColumn
        '
        Me.NominalLengthColumn.DataPropertyName = "NominalLength"
        Me.NominalLengthColumn.HeaderText = "Nom. Length"
        Me.NominalLengthColumn.Name = "NominalLengthColumn"
        Me.NominalLengthColumn.Width = 80
        '
        'LongDescriptionColumn
        '
        Me.LongDescriptionColumn.DataPropertyName = "LongDescription"
        Me.LongDescriptionColumn.HeaderText = "LongDescription"
        Me.LongDescriptionColumn.Name = "LongDescriptionColumn"
        '
        'BinPreferenceColumn
        '
        Me.BinPreferenceColumn.DataPropertyName = "BinPreference"
        Me.BinPreferenceColumn.HeaderText = "Bin Preference Code"
        Me.BinPreferenceColumn.Name = "BinPreferenceColumn"
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'cmdItemForm
        '
        Me.cmdItemForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdItemForm.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemForm.Location = New System.Drawing.Point(346, 776)
        Me.cmdItemForm.Name = "cmdItemForm"
        Me.cmdItemForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdItemForm.TabIndex = 13
        Me.cmdItemForm.Text = "Item Form"
        Me.cmdItemForm.UseVisualStyleBackColor = True
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'PurchaseProductLineTableAdapter
        '
        Me.PurchaseProductLineTableAdapter.ClearBeforeFill = True
        '
        'SalesProductLineTableAdapter
        '
        Me.SalesProductLineTableAdapter.ClearBeforeFill = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(423, 781)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(155, 30)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Open Item Maintenance Form"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(705, 776)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(155, 30)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Changes made in the datagrid are automatically saved."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintQCListingType
        '
        Me.cmdPrintQCListingType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintQCListingType.Location = New System.Drawing.Point(907, 776)
        Me.cmdPrintQCListingType.Name = "cmdPrintQCListingType"
        Me.cmdPrintQCListingType.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintQCListingType.TabIndex = 18
        Me.cmdPrintQCListingType.Text = "Print Listing For QC"
        Me.cmdPrintQCListingType.UseVisualStyleBackColor = True
        '
        'ViewItemListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdPrintQCListingType)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdItemForm)
        Me.Controls.Add(Me.dgvItemList)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxItemSearchFields)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewItemListing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Item Listing"
        Me.gpxItemSearchFields.ResumeLayout(False)
        Me.gpxItemSearchFields.PerformLayout()
        CType(Me.PurchaseProductLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesProductLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpxItemSearchFields As System.Windows.Forms.GroupBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvItemList As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cmdItemForm As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboPurchaseProductLine As System.Windows.Forms.ComboBox
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents PurchaseProductLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseProductLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseProductLineTableAdapter
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdViewByFilter As System.Windows.Forms.Button
    Friend WithEvents cboSalesProdLine As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents SalesProductLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesProductLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesProductLineTableAdapter
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter5 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter4 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter3 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkOmitNonInventory As System.Windows.Forms.CheckBox
    Friend WithEvents cmdPrintQCListingType As System.Windows.Forms.Button
    Friend WithEvents cboOtherDivision As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmdCopyPartNumber As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents HideItemClass As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HidePieceWeight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideBoxCount As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HidePalletCount As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideStandardCost As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideStandardPrice As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideMinStock As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideMaxStock As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShortDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PieceWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxCountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletCountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardPriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinimumStockColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaximumStockColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeadTimeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddAccessoryColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchProdLineIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesProdLineIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OldPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NominalDiameterColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NominalLengthColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LongDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BinPreferenceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
