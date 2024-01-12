<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemPriceSheetMaintenance
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
        Dim _100To199Label As System.Windows.Forms.Label
        Dim _199To299Label As System.Windows.Forms.Label
        Dim _300To399Label As System.Windows.Forms.Label
        Dim _400To499Label As System.Windows.Forms.Label
        Dim _500To749Label As System.Windows.Forms.Label
        Dim _750To999Label As System.Windows.Forms.Label
        Dim _1000To2499Label As System.Windows.Forms.Label
        Dim _2500To4999Label As System.Windows.Forms.Label
        Dim _5000To9999Label As System.Windows.Forms.Label
        Dim _10000To24999Label As System.Windows.Forms.Label
        Dim _25000To49999Label As System.Windows.Forms.Label
        Dim _50000To99999Label As System.Windows.Forms.Label
        Dim _100000AndUpLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemPriceSheetMaintenance))
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
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.gpxItemInformation = New System.Windows.Forms.GroupBox
        Me.cmdUpdatePrice = New System.Windows.Forms.Button
        Me.cmdUpdateCost = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtStandardUnitPrice = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtStandardUnitCost = New System.Windows.Forms.TextBox
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.gpxPricePercentageCalculation = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtStartPrice = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdCalculatePricing = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtQuantityDiscount = New System.Windows.Forms.TextBox
        Me.gpxPricingBrackets = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdAddNew = New System.Windows.Forms.Button
        Me.txt100000To = New System.Windows.Forms.TextBox
        Me.txt50000To = New System.Windows.Forms.TextBox
        Me.txt25000To = New System.Windows.Forms.TextBox
        Me.txt10000To = New System.Windows.Forms.TextBox
        Me.txt5000To = New System.Windows.Forms.TextBox
        Me.txt2500To = New System.Windows.Forms.TextBox
        Me.txt1000To = New System.Windows.Forms.TextBox
        Me.txt750To = New System.Windows.Forms.TextBox
        Me.txt500To = New System.Windows.Forms.TextBox
        Me.txt400To = New System.Windows.Forms.TextBox
        Me.txt300To = New System.Windows.Forms.TextBox
        Me.txt200To = New System.Windows.Forms.TextBox
        Me.txt100To = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.dgvItemPriceSheets = New System.Windows.Forms.DataGridView
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StandardUnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StandardUnitPriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B100To199Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B200To299Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B300To399Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B400To499Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B500To749Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B750To999Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B1000To2499Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B2500To4999Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B5000To9999Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B10000To24999Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B25000To49999Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B50000To99999Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B100000AndUpColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemPriceSheetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemPriceSheetTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemPriceSheetTableAdapter
        _100To199Label = New System.Windows.Forms.Label
        _199To299Label = New System.Windows.Forms.Label
        _300To399Label = New System.Windows.Forms.Label
        _400To499Label = New System.Windows.Forms.Label
        _500To749Label = New System.Windows.Forms.Label
        _750To999Label = New System.Windows.Forms.Label
        _1000To2499Label = New System.Windows.Forms.Label
        _2500To4999Label = New System.Windows.Forms.Label
        _5000To9999Label = New System.Windows.Forms.Label
        _10000To24999Label = New System.Windows.Forms.Label
        _25000To49999Label = New System.Windows.Forms.Label
        _50000To99999Label = New System.Windows.Forms.Label
        _100000AndUpLabel = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.gpxItemInformation.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxPricePercentageCalculation.SuspendLayout()
        Me.gpxPricingBrackets.SuspendLayout()
        CType(Me.dgvItemPriceSheets, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemPriceSheetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_100To199Label
        '
        _100To199Label.Location = New System.Drawing.Point(33, 33)
        _100To199Label.Name = "_100To199Label"
        _100To199Label.Size = New System.Drawing.Size(111, 20)
        _100To199Label.TabIndex = 0
        _100To199Label.Text = "100 To 199:"
        _100To199Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_199To299Label
        '
        _199To299Label.Location = New System.Drawing.Point(33, 59)
        _199To299Label.Name = "_199To299Label"
        _199To299Label.Size = New System.Drawing.Size(111, 20)
        _199To299Label.TabIndex = 2
        _199To299Label.Text = "200 To 299:"
        _199To299Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_300To399Label
        '
        _300To399Label.Location = New System.Drawing.Point(33, 85)
        _300To399Label.Name = "_300To399Label"
        _300To399Label.Size = New System.Drawing.Size(111, 20)
        _300To399Label.TabIndex = 4
        _300To399Label.Text = "300 To 399:"
        _300To399Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_400To499Label
        '
        _400To499Label.Location = New System.Drawing.Point(33, 111)
        _400To499Label.Name = "_400To499Label"
        _400To499Label.Size = New System.Drawing.Size(111, 20)
        _400To499Label.TabIndex = 6
        _400To499Label.Text = "400 To 499:"
        _400To499Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_500To749Label
        '
        _500To749Label.Location = New System.Drawing.Point(33, 137)
        _500To749Label.Name = "_500To749Label"
        _500To749Label.Size = New System.Drawing.Size(111, 20)
        _500To749Label.TabIndex = 8
        _500To749Label.Text = "500 To 749:"
        _500To749Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_750To999Label
        '
        _750To999Label.Location = New System.Drawing.Point(33, 163)
        _750To999Label.Name = "_750To999Label"
        _750To999Label.Size = New System.Drawing.Size(111, 20)
        _750To999Label.TabIndex = 10
        _750To999Label.Text = "750 To 999:"
        _750To999Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_1000To2499Label
        '
        _1000To2499Label.Location = New System.Drawing.Point(33, 189)
        _1000To2499Label.Name = "_1000To2499Label"
        _1000To2499Label.Size = New System.Drawing.Size(111, 20)
        _1000To2499Label.TabIndex = 12
        _1000To2499Label.Text = "1000 To 2499:"
        _1000To2499Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_2500To4999Label
        '
        _2500To4999Label.Location = New System.Drawing.Point(448, 32)
        _2500To4999Label.Name = "_2500To4999Label"
        _2500To4999Label.Size = New System.Drawing.Size(95, 20)
        _2500To4999Label.TabIndex = 14
        _2500To4999Label.Text = "2500 To 4999:"
        _2500To4999Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_5000To9999Label
        '
        _5000To9999Label.Location = New System.Drawing.Point(448, 58)
        _5000To9999Label.Name = "_5000To9999Label"
        _5000To9999Label.Size = New System.Drawing.Size(95, 20)
        _5000To9999Label.TabIndex = 16
        _5000To9999Label.Text = "5000 To 9999:"
        _5000To9999Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_10000To24999Label
        '
        _10000To24999Label.Location = New System.Drawing.Point(448, 84)
        _10000To24999Label.Name = "_10000To24999Label"
        _10000To24999Label.Size = New System.Drawing.Size(95, 20)
        _10000To24999Label.TabIndex = 18
        _10000To24999Label.Text = "10000 To 24999:"
        _10000To24999Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_25000To49999Label
        '
        _25000To49999Label.Location = New System.Drawing.Point(448, 110)
        _25000To49999Label.Name = "_25000To49999Label"
        _25000To49999Label.Size = New System.Drawing.Size(95, 20)
        _25000To49999Label.TabIndex = 20
        _25000To49999Label.Text = "25000 To 49999:"
        _25000To49999Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_50000To99999Label
        '
        _50000To99999Label.Location = New System.Drawing.Point(448, 136)
        _50000To99999Label.Name = "_50000To99999Label"
        _50000To99999Label.Size = New System.Drawing.Size(95, 20)
        _50000To99999Label.TabIndex = 22
        _50000To99999Label.Text = "50000 To 99999:"
        _50000To99999Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_100000AndUpLabel
        '
        _100000AndUpLabel.Location = New System.Drawing.Point(448, 162)
        _100000AndUpLabel.Name = "_100000AndUpLabel"
        _100000AndUpLabel.Size = New System.Drawing.Size(95, 20)
        _100000AndUpLabel.TabIndex = 24
        _100000AndUpLabel.Text = "100000 And  Up:"
        _100000AndUpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 26
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(642, 212)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 22
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 25
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'gpxItemInformation
        '
        Me.gpxItemInformation.Controls.Add(Me.cmdUpdatePrice)
        Me.gpxItemInformation.Controls.Add(Me.cmdUpdateCost)
        Me.gpxItemInformation.Controls.Add(Me.Label5)
        Me.gpxItemInformation.Controls.Add(Me.cboDivisionID)
        Me.gpxItemInformation.Controls.Add(Me.txtStandardUnitPrice)
        Me.gpxItemInformation.Controls.Add(Me.Label4)
        Me.gpxItemInformation.Controls.Add(Me.Label3)
        Me.gpxItemInformation.Controls.Add(Me.Label1)
        Me.gpxItemInformation.Controls.Add(Me.txtStandardUnitCost)
        Me.gpxItemInformation.Controls.Add(Me.cboPartDescription)
        Me.gpxItemInformation.Controls.Add(Me.cboPartNumber)
        Me.gpxItemInformation.Location = New System.Drawing.Point(29, 41)
        Me.gpxItemInformation.Name = "gpxItemInformation"
        Me.gpxItemInformation.Size = New System.Drawing.Size(322, 265)
        Me.gpxItemInformation.TabIndex = 0
        Me.gpxItemInformation.TabStop = False
        Me.gpxItemInformation.Text = "Item Information"
        '
        'cmdUpdatePrice
        '
        Me.cmdUpdatePrice.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdUpdatePrice.Location = New System.Drawing.Point(127, 189)
        Me.cmdUpdatePrice.Name = "cmdUpdatePrice"
        Me.cmdUpdatePrice.Size = New System.Drawing.Size(54, 21)
        Me.cmdUpdatePrice.TabIndex = 28
        Me.cmdUpdatePrice.Text = "Update"
        Me.cmdUpdatePrice.UseVisualStyleBackColor = True
        '
        'cmdUpdateCost
        '
        Me.cmdUpdateCost.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdUpdateCost.Location = New System.Drawing.Point(127, 163)
        Me.cmdUpdateCost.Name = "cmdUpdateCost"
        Me.cmdUpdateCost.Size = New System.Drawing.Size(54, 21)
        Me.cmdUpdateCost.TabIndex = 27
        Me.cmdUpdateCost.Text = "Update"
        Me.cmdUpdateCost.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 20)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Division ID"
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
        Me.cboDivisionID.Location = New System.Drawing.Point(127, 31)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(176, 21)
        Me.cboDivisionID.TabIndex = 4
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
        'txtStandardUnitPrice
        '
        Me.txtStandardUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStandardUnitPrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStandardUnitPrice.Location = New System.Drawing.Point(187, 190)
        Me.txtStandardUnitPrice.Name = "txtStandardUnitPrice"
        Me.txtStandardUnitPrice.Size = New System.Drawing.Size(116, 20)
        Me.txtStandardUnitPrice.TabIndex = 3
        Me.txtStandardUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 190)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Standard Unit Price"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Standard Unit Cost"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Part #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtStandardUnitCost
        '
        Me.txtStandardUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStandardUnitCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStandardUnitCost.Location = New System.Drawing.Point(187, 163)
        Me.txtStandardUnitCost.Name = "txtStandardUnitCost"
        Me.txtStandardUnitCost.Size = New System.Drawing.Size(116, 20)
        Me.txtStandardUnitCost.TabIndex = 2
        Me.txtStandardUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(20, 111)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(283, 21)
        Me.cboPartDescription.TabIndex = 1
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
        Me.cboPartNumber.Location = New System.Drawing.Point(88, 83)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(215, 21)
        Me.cboPartNumber.TabIndex = 0
        '
        'gpxPricePercentageCalculation
        '
        Me.gpxPricePercentageCalculation.Controls.Add(Me.Label11)
        Me.gpxPricePercentageCalculation.Controls.Add(Me.txtStartPrice)
        Me.gpxPricePercentageCalculation.Controls.Add(Me.Label9)
        Me.gpxPricePercentageCalculation.Controls.Add(Me.cmdCalculatePricing)
        Me.gpxPricePercentageCalculation.Controls.Add(Me.Label6)
        Me.gpxPricePercentageCalculation.Controls.Add(Me.Label8)
        Me.gpxPricePercentageCalculation.Controls.Add(Me.txtQuantityDiscount)
        Me.gpxPricePercentageCalculation.Location = New System.Drawing.Point(31, 323)
        Me.gpxPricePercentageCalculation.Name = "gpxPricePercentageCalculation"
        Me.gpxPricePercentageCalculation.Size = New System.Drawing.Size(320, 255)
        Me.gpxPricePercentageCalculation.TabIndex = 5
        Me.gpxPricePercentageCalculation.TabStop = False
        Me.gpxPricePercentageCalculation.Text = "Price / Percentage Calculation"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(15, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(140, 20)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Starting Price"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtStartPrice
        '
        Me.txtStartPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStartPrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStartPrice.Location = New System.Drawing.Point(161, 80)
        Me.txtStartPrice.Name = "txtStartPrice"
        Me.txtStartPrice.Size = New System.Drawing.Size(140, 20)
        Me.txtStartPrice.TabIndex = 5
        Me.txtStartPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label9.Location = New System.Drawing.Point(15, 184)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(286, 68)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "After calculations based on a set percentage, you may manually change quantity pr" & _
            "ices to the right, before entering new Pricing Table into the database."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCalculatePricing
        '
        Me.cmdCalculatePricing.Location = New System.Drawing.Point(230, 141)
        Me.cmdCalculatePricing.Name = "cmdCalculatePricing"
        Me.cmdCalculatePricing.Size = New System.Drawing.Size(71, 40)
        Me.cmdCalculatePricing.TabIndex = 7
        Me.cmdCalculatePricing.Text = "Calculate"
        Me.cmdCalculatePricing.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Location = New System.Drawing.Point(15, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(286, 40)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "To create price brackets for designated pricing brackets, enter quantity discount" & _
            " as a decimal."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(15, 106)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(140, 20)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Quantity Discount (Decimal)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQuantityDiscount
        '
        Me.txtQuantityDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantityDiscount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuantityDiscount.Location = New System.Drawing.Point(161, 106)
        Me.txtQuantityDiscount.Name = "txtQuantityDiscount"
        Me.txtQuantityDiscount.Size = New System.Drawing.Size(140, 20)
        Me.txtQuantityDiscount.TabIndex = 6
        Me.txtQuantityDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gpxPricingBrackets
        '
        Me.gpxPricingBrackets.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxPricingBrackets.Controls.Add(Me.Label10)
        Me.gpxPricingBrackets.Controls.Add(Me.cmdAddNew)
        Me.gpxPricingBrackets.Controls.Add(_100000AndUpLabel)
        Me.gpxPricingBrackets.Controls.Add(Me.txt100000To)
        Me.gpxPricingBrackets.Controls.Add(_50000To99999Label)
        Me.gpxPricingBrackets.Controls.Add(Me.txt50000To)
        Me.gpxPricingBrackets.Controls.Add(_25000To49999Label)
        Me.gpxPricingBrackets.Controls.Add(Me.txt25000To)
        Me.gpxPricingBrackets.Controls.Add(_10000To24999Label)
        Me.gpxPricingBrackets.Controls.Add(Me.cmdClear)
        Me.gpxPricingBrackets.Controls.Add(Me.txt10000To)
        Me.gpxPricingBrackets.Controls.Add(_5000To9999Label)
        Me.gpxPricingBrackets.Controls.Add(Me.txt5000To)
        Me.gpxPricingBrackets.Controls.Add(_2500To4999Label)
        Me.gpxPricingBrackets.Controls.Add(Me.txt2500To)
        Me.gpxPricingBrackets.Controls.Add(_1000To2499Label)
        Me.gpxPricingBrackets.Controls.Add(Me.txt1000To)
        Me.gpxPricingBrackets.Controls.Add(_750To999Label)
        Me.gpxPricingBrackets.Controls.Add(Me.txt750To)
        Me.gpxPricingBrackets.Controls.Add(_500To749Label)
        Me.gpxPricingBrackets.Controls.Add(Me.txt500To)
        Me.gpxPricingBrackets.Controls.Add(_400To499Label)
        Me.gpxPricingBrackets.Controls.Add(Me.txt400To)
        Me.gpxPricingBrackets.Controls.Add(_300To399Label)
        Me.gpxPricingBrackets.Controls.Add(Me.txt300To)
        Me.gpxPricingBrackets.Controls.Add(_199To299Label)
        Me.gpxPricingBrackets.Controls.Add(Me.txt200To)
        Me.gpxPricingBrackets.Controls.Add(_100To199Label)
        Me.gpxPricingBrackets.Controls.Add(Me.txt100To)
        Me.gpxPricingBrackets.Location = New System.Drawing.Point(372, 41)
        Me.gpxPricingBrackets.Name = "gpxPricingBrackets"
        Me.gpxPricingBrackets.Size = New System.Drawing.Size(758, 265)
        Me.gpxPricingBrackets.TabIndex = 8
        Me.gpxPricingBrackets.TabStop = False
        Me.gpxPricingBrackets.Text = "Pricing Brackets"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label10.Location = New System.Drawing.Point(36, 212)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(403, 51)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "If Pricing Structure already exists for a specific part number, chose Save instea" & _
            "d of Add New after edits."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAddNew
        '
        Me.cmdAddNew.Location = New System.Drawing.Point(565, 212)
        Me.cmdAddNew.Name = "cmdAddNew"
        Me.cmdAddNew.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddNew.TabIndex = 21
        Me.cmdAddNew.Text = "Add New"
        Me.cmdAddNew.UseVisualStyleBackColor = True
        '
        'txt100000To
        '
        Me.txt100000To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt100000To.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt100000To.Location = New System.Drawing.Point(565, 162)
        Me.txt100000To.Name = "txt100000To"
        Me.txt100000To.Size = New System.Drawing.Size(148, 20)
        Me.txt100000To.TabIndex = 20
        Me.txt100000To.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt50000To
        '
        Me.txt50000To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt50000To.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt50000To.Location = New System.Drawing.Point(565, 136)
        Me.txt50000To.Name = "txt50000To"
        Me.txt50000To.Size = New System.Drawing.Size(148, 20)
        Me.txt50000To.TabIndex = 19
        Me.txt50000To.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt25000To
        '
        Me.txt25000To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt25000To.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt25000To.Location = New System.Drawing.Point(565, 110)
        Me.txt25000To.Name = "txt25000To"
        Me.txt25000To.Size = New System.Drawing.Size(148, 20)
        Me.txt25000To.TabIndex = 18
        Me.txt25000To.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt10000To
        '
        Me.txt10000To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt10000To.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt10000To.Location = New System.Drawing.Point(565, 84)
        Me.txt10000To.Name = "txt10000To"
        Me.txt10000To.Size = New System.Drawing.Size(148, 20)
        Me.txt10000To.TabIndex = 17
        Me.txt10000To.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt5000To
        '
        Me.txt5000To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt5000To.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt5000To.Location = New System.Drawing.Point(565, 58)
        Me.txt5000To.Name = "txt5000To"
        Me.txt5000To.Size = New System.Drawing.Size(148, 20)
        Me.txt5000To.TabIndex = 16
        Me.txt5000To.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt2500To
        '
        Me.txt2500To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt2500To.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt2500To.Location = New System.Drawing.Point(565, 32)
        Me.txt2500To.Name = "txt2500To"
        Me.txt2500To.Size = New System.Drawing.Size(148, 20)
        Me.txt2500To.TabIndex = 15
        Me.txt2500To.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt1000To
        '
        Me.txt1000To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt1000To.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt1000To.Location = New System.Drawing.Point(150, 189)
        Me.txt1000To.Name = "txt1000To"
        Me.txt1000To.Size = New System.Drawing.Size(148, 20)
        Me.txt1000To.TabIndex = 14
        Me.txt1000To.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt750To
        '
        Me.txt750To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt750To.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt750To.Location = New System.Drawing.Point(150, 163)
        Me.txt750To.Name = "txt750To"
        Me.txt750To.Size = New System.Drawing.Size(148, 20)
        Me.txt750To.TabIndex = 13
        Me.txt750To.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt500To
        '
        Me.txt500To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt500To.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt500To.Location = New System.Drawing.Point(150, 137)
        Me.txt500To.Name = "txt500To"
        Me.txt500To.Size = New System.Drawing.Size(148, 20)
        Me.txt500To.TabIndex = 12
        Me.txt500To.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt400To
        '
        Me.txt400To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt400To.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt400To.Location = New System.Drawing.Point(150, 111)
        Me.txt400To.Name = "txt400To"
        Me.txt400To.Size = New System.Drawing.Size(148, 20)
        Me.txt400To.TabIndex = 11
        Me.txt400To.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt300To
        '
        Me.txt300To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt300To.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt300To.Location = New System.Drawing.Point(150, 85)
        Me.txt300To.Name = "txt300To"
        Me.txt300To.Size = New System.Drawing.Size(148, 20)
        Me.txt300To.TabIndex = 10
        Me.txt300To.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt200To
        '
        Me.txt200To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt200To.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt200To.Location = New System.Drawing.Point(150, 59)
        Me.txt200To.Name = "txt200To"
        Me.txt200To.Size = New System.Drawing.Size(148, 20)
        Me.txt200To.TabIndex = 9
        Me.txt200To.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt100To
        '
        Me.txt100To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt100To.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt100To.Location = New System.Drawing.Point(150, 33)
        Me.txt100To.Name = "txt100To"
        Me.txt100To.Size = New System.Drawing.Size(148, 20)
        Me.txt100To.TabIndex = 8
        Me.txt100To.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Location = New System.Drawing.Point(32, 645)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(319, 116)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = resources.GetString("Label7.Text")
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvItemPriceSheets
        '
        Me.dgvItemPriceSheets.AllowUserToAddRows = False
        Me.dgvItemPriceSheets.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvItemPriceSheets.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvItemPriceSheets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvItemPriceSheets.AutoGenerateColumns = False
        Me.dgvItemPriceSheets.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvItemPriceSheets.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvItemPriceSheets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItemPriceSheets.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartNumberColumn, Me.PartDescriptionColumn, Me.DivisionIDColumn, Me.StandardUnitCostColumn, Me.StandardUnitPriceColumn, Me.B100To199Column, Me.B200To299Column, Me.B300To399Column, Me.B400To499Column, Me.B500To749Column, Me.B750To999Column, Me.B1000To2499Column, Me.B2500To4999Column, Me.B5000To9999Column, Me.B10000To24999Column, Me.B25000To49999Column, Me.B50000To99999Column, Me.B100000AndUpColumn})
        Me.dgvItemPriceSheets.DataSource = Me.ItemPriceSheetBindingSource
        Me.dgvItemPriceSheets.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvItemPriceSheets.Location = New System.Drawing.Point(372, 323)
        Me.dgvItemPriceSheets.Name = "dgvItemPriceSheets"
        Me.dgvItemPriceSheets.Size = New System.Drawing.Size(758, 427)
        Me.dgvItemPriceSheets.TabIndex = 13
        Me.dgvItemPriceSheets.TabStop = False
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part Number"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'StandardUnitCostColumn
        '
        Me.StandardUnitCostColumn.DataPropertyName = "StandardUnitCost"
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = "0"
        Me.StandardUnitCostColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.StandardUnitCostColumn.HeaderText = "Standard Unit Cost"
        Me.StandardUnitCostColumn.Name = "StandardUnitCostColumn"
        '
        'StandardUnitPriceColumn
        '
        Me.StandardUnitPriceColumn.DataPropertyName = "StandardUnitPrice"
        DataGridViewCellStyle3.Format = "N4"
        DataGridViewCellStyle3.NullValue = "0"
        Me.StandardUnitPriceColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.StandardUnitPriceColumn.HeaderText = "Standard Unit Price"
        Me.StandardUnitPriceColumn.Name = "StandardUnitPriceColumn"
        '
        'B100To199Column
        '
        Me.B100To199Column.DataPropertyName = "B100To199"
        DataGridViewCellStyle4.Format = "N4"
        DataGridViewCellStyle4.NullValue = "0"
        Me.B100To199Column.DefaultCellStyle = DataGridViewCellStyle4
        Me.B100To199Column.HeaderText = "100 To 199"
        Me.B100To199Column.Name = "B100To199Column"
        '
        'B200To299Column
        '
        Me.B200To299Column.DataPropertyName = "B200To299"
        DataGridViewCellStyle5.Format = "N4"
        DataGridViewCellStyle5.NullValue = "0"
        Me.B200To299Column.DefaultCellStyle = DataGridViewCellStyle5
        Me.B200To299Column.HeaderText = "200 To 299"
        Me.B200To299Column.Name = "B200To299Column"
        '
        'B300To399Column
        '
        Me.B300To399Column.DataPropertyName = "B300To399"
        DataGridViewCellStyle6.Format = "N4"
        DataGridViewCellStyle6.NullValue = "0"
        Me.B300To399Column.DefaultCellStyle = DataGridViewCellStyle6
        Me.B300To399Column.HeaderText = "300 To 399"
        Me.B300To399Column.Name = "B300To399Column"
        '
        'B400To499Column
        '
        Me.B400To499Column.DataPropertyName = "B400To499"
        DataGridViewCellStyle7.Format = "N4"
        DataGridViewCellStyle7.NullValue = "0"
        Me.B400To499Column.DefaultCellStyle = DataGridViewCellStyle7
        Me.B400To499Column.HeaderText = "400 To 499"
        Me.B400To499Column.Name = "B400To499Column"
        '
        'B500To749Column
        '
        Me.B500To749Column.DataPropertyName = "B500To749"
        DataGridViewCellStyle8.Format = "N4"
        DataGridViewCellStyle8.NullValue = "0"
        Me.B500To749Column.DefaultCellStyle = DataGridViewCellStyle8
        Me.B500To749Column.HeaderText = "500 To 749"
        Me.B500To749Column.Name = "B500To749Column"
        '
        'B750To999Column
        '
        Me.B750To999Column.DataPropertyName = "B750To999"
        DataGridViewCellStyle9.Format = "N4"
        DataGridViewCellStyle9.NullValue = "0"
        Me.B750To999Column.DefaultCellStyle = DataGridViewCellStyle9
        Me.B750To999Column.HeaderText = "750 To 999"
        Me.B750To999Column.Name = "B750To999Column"
        '
        'B1000To2499Column
        '
        Me.B1000To2499Column.DataPropertyName = "B1000To2499"
        DataGridViewCellStyle10.Format = "N4"
        DataGridViewCellStyle10.NullValue = "0"
        Me.B1000To2499Column.DefaultCellStyle = DataGridViewCellStyle10
        Me.B1000To2499Column.HeaderText = "1000 To 2499"
        Me.B1000To2499Column.Name = "B1000To2499Column"
        '
        'B2500To4999Column
        '
        Me.B2500To4999Column.DataPropertyName = "B2500To4999"
        DataGridViewCellStyle11.Format = "N4"
        DataGridViewCellStyle11.NullValue = "0"
        Me.B2500To4999Column.DefaultCellStyle = DataGridViewCellStyle11
        Me.B2500To4999Column.HeaderText = "2500 To 4999"
        Me.B2500To4999Column.Name = "B2500To4999Column"
        '
        'B5000To9999Column
        '
        Me.B5000To9999Column.DataPropertyName = "B5000To9999"
        DataGridViewCellStyle12.Format = "N4"
        DataGridViewCellStyle12.NullValue = "0"
        Me.B5000To9999Column.DefaultCellStyle = DataGridViewCellStyle12
        Me.B5000To9999Column.HeaderText = "5000 To 9999"
        Me.B5000To9999Column.Name = "B5000To9999Column"
        '
        'B10000To24999Column
        '
        Me.B10000To24999Column.DataPropertyName = "B10000To24999"
        DataGridViewCellStyle13.Format = "N4"
        DataGridViewCellStyle13.NullValue = "0"
        Me.B10000To24999Column.DefaultCellStyle = DataGridViewCellStyle13
        Me.B10000To24999Column.HeaderText = "10000 To 24999"
        Me.B10000To24999Column.Name = "B10000To24999Column"
        '
        'B25000To49999Column
        '
        Me.B25000To49999Column.DataPropertyName = "B25000To49999"
        DataGridViewCellStyle14.Format = "N4"
        DataGridViewCellStyle14.NullValue = "0"
        Me.B25000To49999Column.DefaultCellStyle = DataGridViewCellStyle14
        Me.B25000To49999Column.HeaderText = "25000 To 49999"
        Me.B25000To49999Column.Name = "B25000To49999Column"
        '
        'B50000To99999Column
        '
        Me.B50000To99999Column.DataPropertyName = "B50000To99999"
        DataGridViewCellStyle15.Format = "N4"
        DataGridViewCellStyle15.NullValue = "0"
        Me.B50000To99999Column.DefaultCellStyle = DataGridViewCellStyle15
        Me.B50000To99999Column.HeaderText = "50000 To 99999"
        Me.B50000To99999Column.Name = "B50000To99999Column"
        '
        'B100000AndUpColumn
        '
        Me.B100000AndUpColumn.DataPropertyName = "B100000AndUp"
        DataGridViewCellStyle16.Format = "N4"
        DataGridViewCellStyle16.NullValue = "0"
        Me.B100000AndUpColumn.DefaultCellStyle = DataGridViewCellStyle16
        Me.B100000AndUpColumn.HeaderText = "100000 And Up"
        Me.B100000AndUpColumn.Name = "B100000AndUpColumn"
        '
        'ItemPriceSheetBindingSource
        '
        Me.ItemPriceSheetBindingSource.DataMember = "ItemPriceSheet"
        Me.ItemPriceSheetBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemPriceSheetTableAdapter
        '
        Me.ItemPriceSheetTableAdapter.ClearBeforeFill = True
        '
        'ItemPriceSheetMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.dgvItemPriceSheets)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.gpxPricingBrackets)
        Me.Controls.Add(Me.gpxPricePercentageCalculation)
        Me.Controls.Add(Me.gpxItemInformation)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ItemPriceSheetMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Item Price Sheet Maintenance"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxItemInformation.ResumeLayout(False)
        Me.gpxItemInformation.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxPricePercentageCalculation.ResumeLayout(False)
        Me.gpxPricePercentageCalculation.PerformLayout()
        Me.gpxPricingBrackets.ResumeLayout(False)
        Me.gpxPricingBrackets.PerformLayout()
        CType(Me.dgvItemPriceSheets, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemPriceSheetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents gpxItemInformation As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtStandardUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents txtStandardUnitPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents gpxPricePercentageCalculation As System.Windows.Forms.GroupBox
    Friend WithEvents gpxPricingBrackets As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAddNew As System.Windows.Forms.Button
    Friend WithEvents txt50000To As System.Windows.Forms.TextBox
    Friend WithEvents txt25000To As System.Windows.Forms.TextBox
    Friend WithEvents txt10000To As System.Windows.Forms.TextBox
    Friend WithEvents txt5000To As System.Windows.Forms.TextBox
    Friend WithEvents txt2500To As System.Windows.Forms.TextBox
    Friend WithEvents txt1000To As System.Windows.Forms.TextBox
    Friend WithEvents txt750To As System.Windows.Forms.TextBox
    Friend WithEvents txt500To As System.Windows.Forms.TextBox
    Friend WithEvents txt400To As System.Windows.Forms.TextBox
    Friend WithEvents txt300To As System.Windows.Forms.TextBox
    Friend WithEvents txt200To As System.Windows.Forms.TextBox
    Friend WithEvents txt100To As System.Windows.Forms.TextBox
    Friend WithEvents txt100000To As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtQuantityDiscount As System.Windows.Forms.TextBox
    Friend WithEvents cmdCalculatePricing As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dgvItemPriceSheets As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtStartPrice As System.Windows.Forms.TextBox
    Friend WithEvents cmdUpdatePrice As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateCost As System.Windows.Forms.Button
    Friend WithEvents To199DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To299DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To399DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To499DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To749DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To999DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To2499DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To4999DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To9999DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To24999DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To49999DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To99999DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AndUpDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ItemPriceSheetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemPriceSheetTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemPriceSheetTableAdapter
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardUnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardUnitPriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B100To199Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B200To299Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B300To399Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B400To499Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B500To749Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B750To999Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B1000To2499Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B2500To4999Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B5000To9999Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B10000To24999Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B25000To49999Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B50000To99999Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B100000AndUpColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
