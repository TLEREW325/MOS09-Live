<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewSteelList
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
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.SteelInventoryTotalsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.gpxSteelData = New System.Windows.Forms.GroupBox
        Me.chkOther = New System.Windows.Forms.CheckBox
        Me.chkABall = New System.Windows.Forms.CheckBox
        Me.chkToolSteel = New System.Windows.Forms.CheckBox
        Me.chkTWESteel = New System.Windows.Forms.CheckBox
        Me.chkTWDSteel = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.chkShowAllTypes = New System.Windows.Forms.CheckBox
        Me.chkOmitZero = New System.Windows.Forms.CheckBox
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboSize = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgvSteelList = New System.Windows.Forms.DataGridView
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarbonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelEndingInventoryColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ValuationQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalCoilQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReceiveTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelUsageTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnYardWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelAdjustTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreationDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelInventoryTotalsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelInventoryTotalsTableAdapter
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblTotalWeight = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblTotalValueWeight = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblTotalCoilWeight = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SteelInventoryTotalsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxSteelData.SuspendLayout()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSteelList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'SteelInventoryTotalsBindingSource
        '
        Me.SteelInventoryTotalsBindingSource.DataMember = "SteelInventoryTotals"
        Me.SteelInventoryTotalsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'gpxSteelData
        '
        Me.gpxSteelData.Controls.Add(Me.Label5)
        Me.gpxSteelData.Controls.Add(Me.Label4)
        Me.gpxSteelData.Controls.Add(Me.txtTextFilter)
        Me.gpxSteelData.Controls.Add(Me.chkOther)
        Me.gpxSteelData.Controls.Add(Me.chkABall)
        Me.gpxSteelData.Controls.Add(Me.chkToolSteel)
        Me.gpxSteelData.Controls.Add(Me.chkTWESteel)
        Me.gpxSteelData.Controls.Add(Me.chkTWDSteel)
        Me.gpxSteelData.Controls.Add(Me.Label7)
        Me.gpxSteelData.Controls.Add(Me.chkShowAllTypes)
        Me.gpxSteelData.Controls.Add(Me.chkOmitZero)
        Me.gpxSteelData.Controls.Add(Me.cboCarbon)
        Me.gpxSteelData.Controls.Add(Me.cboSize)
        Me.gpxSteelData.Controls.Add(Me.Label3)
        Me.gpxSteelData.Controls.Add(Me.cmdView)
        Me.gpxSteelData.Controls.Add(Me.cmdClear)
        Me.gpxSteelData.Controls.Add(Me.Label2)
        Me.gpxSteelData.Location = New System.Drawing.Point(26, 41)
        Me.gpxSteelData.Name = "gpxSteelData"
        Me.gpxSteelData.Size = New System.Drawing.Size(300, 537)
        Me.gpxSteelData.TabIndex = 0
        Me.gpxSteelData.TabStop = False
        Me.gpxSteelData.Text = "View By Filters"
        '
        'chkOther
        '
        Me.chkOther.AutoSize = True
        Me.chkOther.Location = New System.Drawing.Point(25, 452)
        Me.chkOther.Name = "chkOther"
        Me.chkOther.Size = New System.Drawing.Size(52, 17)
        Me.chkOther.TabIndex = 10
        Me.chkOther.Text = "Other"
        Me.chkOther.UseVisualStyleBackColor = True
        '
        'chkABall
        '
        Me.chkABall.AutoSize = True
        Me.chkABall.Location = New System.Drawing.Point(25, 418)
        Me.chkABall.Name = "chkABall"
        Me.chkABall.Size = New System.Drawing.Size(96, 17)
        Me.chkABall.TabIndex = 9
        Me.chkABall.Text = "Aluminum Balls"
        Me.chkABall.UseVisualStyleBackColor = True
        '
        'chkToolSteel
        '
        Me.chkToolSteel.AutoSize = True
        Me.chkToolSteel.Location = New System.Drawing.Point(25, 384)
        Me.chkToolSteel.Name = "chkToolSteel"
        Me.chkToolSteel.Size = New System.Drawing.Size(74, 17)
        Me.chkToolSteel.TabIndex = 8
        Me.chkToolSteel.Text = "Tool Steel"
        Me.chkToolSteel.UseVisualStyleBackColor = True
        '
        'chkTWESteel
        '
        Me.chkTWESteel.AutoSize = True
        Me.chkTWESteel.Location = New System.Drawing.Point(25, 350)
        Me.chkTWESteel.Name = "chkTWESteel"
        Me.chkTWESteel.Size = New System.Drawing.Size(144, 17)
        Me.chkTWESteel.TabIndex = 7
        Me.chkTWESteel.Text = "TWE Steel (Accessories)"
        Me.chkTWESteel.UseVisualStyleBackColor = True
        '
        'chkTWDSteel
        '
        Me.chkTWDSteel.AutoSize = True
        Me.chkTWDSteel.Location = New System.Drawing.Point(25, 316)
        Me.chkTWDSteel.Name = "chkTWDSteel"
        Me.chkTWDSteel.Size = New System.Drawing.Size(132, 17)
        Me.chkTWDSteel.TabIndex = 6
        Me.chkTWDSteel.Text = "TWD Steel (Inventory)"
        Me.chkTWDSteel.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(19, 258)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(266, 20)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Steel Class"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkShowAllTypes
        '
        Me.chkShowAllTypes.AutoSize = True
        Me.chkShowAllTypes.Location = New System.Drawing.Point(98, 69)
        Me.chkShowAllTypes.Name = "chkShowAllTypes"
        Me.chkShowAllTypes.Size = New System.Drawing.Size(94, 17)
        Me.chkShowAllTypes.TabIndex = 2
        Me.chkShowAllTypes.Text = "Show all types"
        Me.chkShowAllTypes.UseVisualStyleBackColor = True
        '
        'chkOmitZero
        '
        Me.chkOmitZero.AutoSize = True
        Me.chkOmitZero.Location = New System.Drawing.Point(98, 131)
        Me.chkOmitZero.Name = "chkOmitZero"
        Me.chkOmitZero.Size = New System.Drawing.Size(119, 17)
        Me.chkOmitZero.TabIndex = 4
        Me.chkOmitZero.Text = "Omit Zero Inventory"
        Me.chkOmitZero.UseVisualStyleBackColor = True
        '
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboCarbon.DisplayMember = "Carbon"
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(98, 36)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(187, 21)
        Me.cboCarbon.TabIndex = 1
        '
        'RawMaterialsTableBindingSource
        '
        Me.RawMaterialsTableBindingSource.DataMember = "RawMaterialsTable"
        Me.RawMaterialsTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboSize
        '
        Me.cboSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSize.DisplayMember = "SteelSize"
        Me.cboSize.FormattingEnabled = True
        Me.cboSize.Location = New System.Drawing.Point(98, 98)
        Me.cboSize.Name = "cboSize"
        Me.cboSize.Size = New System.Drawing.Size(187, 21)
        Me.cboSize.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(19, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Steel Size"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(137, 489)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 11
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 489)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 12
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Carbon"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvSteelList
        '
        Me.dgvSteelList.AllowUserToAddRows = False
        Me.dgvSteelList.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvSteelList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvSteelList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSteelList.AutoGenerateColumns = False
        Me.dgvSteelList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSteelList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RMIDColumn, Me.CarbonColumn, Me.SteelSizeColumn, Me.DescriptionColumn, Me.SteelEndingInventoryColumn, Me.ValuationQuantityColumn, Me.TotalCoilQuantityColumn, Me.SteelReceiveTotalColumn, Me.SteelUsageTotalColumn, Me.ReturnYardWeightColumn, Me.SteelAdjustTotalColumn, Me.SteelClassColumn, Me.CreationDateColumn})
        Me.dgvSteelList.DataSource = Me.SteelInventoryTotalsBindingSource
        Me.dgvSteelList.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvSteelList.Location = New System.Drawing.Point(344, 41)
        Me.dgvSteelList.Name = "dgvSteelList"
        Me.dgvSteelList.Size = New System.Drawing.Size(688, 720)
        Me.dgvSteelList.TabIndex = 17
        Me.dgvSteelList.TabStop = False
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        Me.RMIDColumn.Visible = False
        Me.RMIDColumn.Width = 95
        '
        'CarbonColumn
        '
        Me.CarbonColumn.DataPropertyName = "Carbon"
        Me.CarbonColumn.HeaderText = "Carbon"
        Me.CarbonColumn.Name = "CarbonColumn"
        Me.CarbonColumn.Width = 95
        '
        'SteelSizeColumn
        '
        Me.SteelSizeColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn.HeaderText = "Steel Size"
        Me.SteelSizeColumn.Name = "SteelSizeColumn"
        Me.SteelSizeColumn.Width = 95
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        Me.DescriptionColumn.Width = 170
        '
        'SteelEndingInventoryColumn
        '
        Me.SteelEndingInventoryColumn.DataPropertyName = "SteelEndingInventory"
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle10.Format = "N0"
        DataGridViewCellStyle10.NullValue = "0"
        Me.SteelEndingInventoryColumn.DefaultCellStyle = DataGridViewCellStyle10
        Me.SteelEndingInventoryColumn.HeaderText = "Ending Inventory"
        Me.SteelEndingInventoryColumn.Name = "SteelEndingInventoryColumn"
        Me.SteelEndingInventoryColumn.ReadOnly = True
        Me.SteelEndingInventoryColumn.Width = 80
        '
        'ValuationQuantityColumn
        '
        Me.ValuationQuantityColumn.DataPropertyName = "ValuationQuantity"
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle11.Format = "N0"
        DataGridViewCellStyle11.NullValue = "0"
        Me.ValuationQuantityColumn.DefaultCellStyle = DataGridViewCellStyle11
        Me.ValuationQuantityColumn.HeaderText = "Valuation Qty"
        Me.ValuationQuantityColumn.Name = "ValuationQuantityColumn"
        Me.ValuationQuantityColumn.ReadOnly = True
        '
        'TotalCoilQuantityColumn
        '
        Me.TotalCoilQuantityColumn.DataPropertyName = "TotalCoilQuantity"
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.Format = "N0"
        DataGridViewCellStyle12.NullValue = "0"
        Me.TotalCoilQuantityColumn.DefaultCellStyle = DataGridViewCellStyle12
        Me.TotalCoilQuantityColumn.HeaderText = "Total Coil Qty"
        Me.TotalCoilQuantityColumn.Name = "TotalCoilQuantityColumn"
        Me.TotalCoilQuantityColumn.ReadOnly = True
        '
        'SteelReceiveTotalColumn
        '
        Me.SteelReceiveTotalColumn.DataPropertyName = "SteelReceiveTotal"
        DataGridViewCellStyle13.Format = "N0"
        DataGridViewCellStyle13.NullValue = "0"
        Me.SteelReceiveTotalColumn.DefaultCellStyle = DataGridViewCellStyle13
        Me.SteelReceiveTotalColumn.HeaderText = "Steel Received"
        Me.SteelReceiveTotalColumn.Name = "SteelReceiveTotalColumn"
        Me.SteelReceiveTotalColumn.ReadOnly = True
        Me.SteelReceiveTotalColumn.Width = 80
        '
        'SteelUsageTotalColumn
        '
        Me.SteelUsageTotalColumn.DataPropertyName = "SteelUsageTotal"
        DataGridViewCellStyle14.Format = "N0"
        DataGridViewCellStyle14.NullValue = "0"
        Me.SteelUsageTotalColumn.DefaultCellStyle = DataGridViewCellStyle14
        Me.SteelUsageTotalColumn.HeaderText = "Steel Consumption"
        Me.SteelUsageTotalColumn.Name = "SteelUsageTotalColumn"
        Me.SteelUsageTotalColumn.ReadOnly = True
        Me.SteelUsageTotalColumn.Width = 80
        '
        'ReturnYardWeightColumn
        '
        Me.ReturnYardWeightColumn.DataPropertyName = "ReturnYardWeight"
        DataGridViewCellStyle15.Format = "N0"
        DataGridViewCellStyle15.NullValue = "0"
        Me.ReturnYardWeightColumn.DefaultCellStyle = DataGridViewCellStyle15
        Me.ReturnYardWeightColumn.HeaderText = "Return To Yard"
        Me.ReturnYardWeightColumn.Name = "ReturnYardWeightColumn"
        Me.ReturnYardWeightColumn.ReadOnly = True
        Me.ReturnYardWeightColumn.Width = 80
        '
        'SteelAdjustTotalColumn
        '
        Me.SteelAdjustTotalColumn.DataPropertyName = "SteelAdjustTotal"
        DataGridViewCellStyle16.Format = "N0"
        DataGridViewCellStyle16.NullValue = "0"
        Me.SteelAdjustTotalColumn.DefaultCellStyle = DataGridViewCellStyle16
        Me.SteelAdjustTotalColumn.HeaderText = "Steel Adjustments"
        Me.SteelAdjustTotalColumn.Name = "SteelAdjustTotalColumn"
        Me.SteelAdjustTotalColumn.ReadOnly = True
        Me.SteelAdjustTotalColumn.Width = 80
        '
        'SteelClassColumn
        '
        Me.SteelClassColumn.DataPropertyName = "SteelClass"
        Me.SteelClassColumn.HeaderText = "Steel Class"
        Me.SteelClassColumn.Name = "SteelClassColumn"
        '
        'CreationDateColumn
        '
        Me.CreationDateColumn.DataPropertyName = "CreationDate"
        Me.CreationDateColumn.HeaderText = "CreationDate"
        Me.CreationDateColumn.Name = "CreationDateColumn"
        Me.CreationDateColumn.Visible = False
        Me.CreationDateColumn.Width = 86
        '
        'SteelInventoryTotalsTableAdapter
        '
        Me.SteelInventoryTotalsTableAdapter.ClearBeforeFill = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 19
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 18
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTotalCoilWeight)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lblTotalValueWeight)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblTotalWeight)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 610)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 201)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Total Steel Weight"
        '
        'lblTotalWeight
        '
        Me.lblTotalWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalWeight.Location = New System.Drawing.Point(108, 40)
        Me.lblTotalWeight.Name = "lblTotalWeight"
        Me.lblTotalWeight.Size = New System.Drawing.Size(175, 21)
        Me.lblTotalWeight.TabIndex = 14
        Me.lblTotalWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total QOH"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.Location = New System.Drawing.Point(22, 210)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(263, 20)
        Me.txtTextFilter.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Text Filter"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalValueWeight
        '
        Me.lblTotalValueWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalValueWeight.Location = New System.Drawing.Point(108, 93)
        Me.lblTotalValueWeight.Name = "lblTotalValueWeight"
        Me.lblTotalValueWeight.Size = New System.Drawing.Size(175, 21)
        Me.lblTotalValueWeight.TabIndex = 15
        Me.lblTotalValueWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 23)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Total Value Qty."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalCoilWeight
        '
        Me.lblTotalCoilWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCoilWeight.Location = New System.Drawing.Point(108, 146)
        Me.lblTotalCoilWeight.Name = "lblTotalCoilWeight"
        Me.lblTotalCoilWeight.Size = New System.Drawing.Size(175, 21)
        Me.lblTotalCoilWeight.TabIndex = 16
        Me.lblTotalCoilWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(17, 145)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 23)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Total Coil Qty"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(24, 285)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(261, 20)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "If all are unchecked,  no steel class filter is used."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewSteelList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvSteelList)
        Me.Controls.Add(Me.gpxSteelData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewSteelList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Steel List"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.SteelInventoryTotalsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxSteelData.ResumeLayout(False)
        Me.gpxSteelData.PerformLayout()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSteelList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxSteelData As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvSteelList As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents SteelInventoryTotalsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelInventoryTotalsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelInventoryTotalsTableAdapter
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents cboSize As System.Windows.Forms.ComboBox
    Friend WithEvents chkOmitZero As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotalWeight As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkShowAllTypes As System.Windows.Forms.CheckBox
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelEndingInventoryColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValuationQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCoilQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReceiveTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelUsageTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnYardWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelAdjustTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreationDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents chkABall As System.Windows.Forms.CheckBox
    Friend WithEvents chkToolSteel As System.Windows.Forms.CheckBox
    Friend WithEvents chkTWESteel As System.Windows.Forms.CheckBox
    Friend WithEvents chkTWDSteel As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents chkOther As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalCoilWeight As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblTotalValueWeight As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
