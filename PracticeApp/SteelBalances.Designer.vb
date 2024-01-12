<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SteelBalances
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.gpxSearchFields = New System.Windows.Forms.GroupBox
        Me.chkQOH = New System.Windows.Forms.CheckBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtSteelDescription = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.cboSteelCarbon = New System.Windows.Forms.ComboBox
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SteelInventoryTotalsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvSteelBalances = New System.Windows.Forms.DataGridView
        Me.SteelInventoryTotalsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelInventoryTotalsTableAdapter
        Me.gpxRawMaterialForm = New System.Windows.Forms.GroupBox
        Me.cmdOpenVoucherForm = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarbonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelEndingInventoryColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ValuationQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReceiveTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelUsageTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelAdjustTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelBeginningBalanceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreationDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        Me.gpxSearchFields.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelInventoryTotalsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSteelBalances, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxRawMaterialForm.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 5
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 1
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
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 4
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'gpxSearchFields
        '
        Me.gpxSearchFields.Controls.Add(Me.chkQOH)
        Me.gpxSearchFields.Controls.Add(Me.cboDivisionID)
        Me.gpxSearchFields.Controls.Add(Me.txtSteelDescription)
        Me.gpxSearchFields.Controls.Add(Me.Label5)
        Me.gpxSearchFields.Controls.Add(Me.cboSteelSize)
        Me.gpxSearchFields.Controls.Add(Me.cboSteelCarbon)
        Me.gpxSearchFields.Controls.Add(Me.cmdSearch)
        Me.gpxSearchFields.Controls.Add(Me.Label2)
        Me.gpxSearchFields.Controls.Add(Me.cmdClear)
        Me.gpxSearchFields.Controls.Add(Me.Label1)
        Me.gpxSearchFields.Location = New System.Drawing.Point(29, 41)
        Me.gpxSearchFields.Name = "gpxSearchFields"
        Me.gpxSearchFields.Size = New System.Drawing.Size(300, 362)
        Me.gpxSearchFields.TabIndex = 0
        Me.gpxSearchFields.TabStop = False
        Me.gpxSearchFields.Text = "View By Filters"
        '
        'chkQOH
        '
        Me.chkQOH.AutoSize = True
        Me.chkQOH.Location = New System.Drawing.Point(95, 171)
        Me.chkQOH.Name = "chkQOH"
        Me.chkQOH.Size = New System.Drawing.Size(142, 17)
        Me.chkQOH.TabIndex = 17
        Me.chkQOH.Text = "Omit 0 Quantity on Hand"
        Me.chkQOH.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(95, 37)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(190, 21)
        Me.cboDivisionID.TabIndex = 13
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
        'txtSteelDescription
        '
        Me.txtSteelDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelDescription.Location = New System.Drawing.Point(20, 214)
        Me.txtSteelDescription.Multiline = True
        Me.txtSteelDescription.Name = "txtSteelDescription"
        Me.txtSteelDescription.ReadOnly = True
        Me.txtSteelDescription.Size = New System.Drawing.Size(266, 75)
        Me.txtSteelDescription.TabIndex = 15
        Me.txtSteelDescription.TabStop = False
        Me.txtSteelDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(15, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Division ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(95, 129)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(191, 21)
        Me.cboSteelSize.TabIndex = 12
        '
        'cboSteelCarbon
        '
        Me.cboSteelCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelCarbon.FormattingEnabled = True
        Me.cboSteelCarbon.Location = New System.Drawing.Point(95, 83)
        Me.cboSteelCarbon.Name = "cboSteelCarbon"
        Me.cboSteelCarbon.Size = New System.Drawing.Size(191, 21)
        Me.cboSteelCarbon.TabIndex = 11
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(138, 318)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(71, 30)
        Me.cmdSearch.TabIndex = 2
        Me.cmdSearch.Text = "View"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(15, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 20)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Carbon"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(215, 318)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 3
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Size"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RawMaterialsTableBindingSource
        '
        Me.RawMaterialsTableBindingSource.DataMember = "RawMaterialsTable"
        Me.RawMaterialsTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SteelInventoryTotalsBindingSource
        '
        Me.SteelInventoryTotalsBindingSource.DataMember = "SteelInventoryTotals"
        Me.SteelInventoryTotalsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvSteelBalances
        '
        Me.dgvSteelBalances.AllowUserToAddRows = False
        Me.dgvSteelBalances.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvSteelBalances.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSteelBalances.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSteelBalances.AutoGenerateColumns = False
        Me.dgvSteelBalances.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelBalances.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSteelBalances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelBalances.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RMIDColumn, Me.CarbonColumn, Me.SteelSizeColumn, Me.DescriptionColumn, Me.SteelEndingInventoryColumn, Me.ValuationQuantityColumn, Me.SteelReceiveTotalColumn, Me.SteelUsageTotalColumn, Me.SteelAdjustTotalColumn, Me.SteelBeginningBalanceColumn, Me.CreationDateColumn})
        Me.dgvSteelBalances.DataSource = Me.SteelInventoryTotalsBindingSource
        Me.dgvSteelBalances.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvSteelBalances.Location = New System.Drawing.Point(352, 41)
        Me.dgvSteelBalances.Name = "dgvSteelBalances"
        Me.dgvSteelBalances.Size = New System.Drawing.Size(678, 715)
        Me.dgvSteelBalances.TabIndex = 8
        '
        'SteelInventoryTotalsTableAdapter
        '
        Me.SteelInventoryTotalsTableAdapter.ClearBeforeFill = True
        '
        'gpxRawMaterialForm
        '
        Me.gpxRawMaterialForm.Controls.Add(Me.cmdOpenVoucherForm)
        Me.gpxRawMaterialForm.Controls.Add(Me.Label4)
        Me.gpxRawMaterialForm.Location = New System.Drawing.Point(29, 727)
        Me.gpxRawMaterialForm.Name = "gpxRawMaterialForm"
        Me.gpxRawMaterialForm.Size = New System.Drawing.Size(300, 84)
        Me.gpxRawMaterialForm.TabIndex = 18
        Me.gpxRawMaterialForm.TabStop = False
        Me.gpxRawMaterialForm.Text = "Raw Material Maintenance"
        '
        'cmdOpenVoucherForm
        '
        Me.cmdOpenVoucherForm.Location = New System.Drawing.Point(214, 27)
        Me.cmdOpenVoucherForm.Name = "cmdOpenVoucherForm"
        Me.cmdOpenVoucherForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenVoucherForm.TabIndex = 15
        Me.cmdOpenVoucherForm.Text = "Raw Materials"
        Me.cmdOpenVoucherForm.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(15, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(165, 38)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Loads Raw Materials Form and closes this form..."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        Me.RMIDColumn.ReadOnly = True
        Me.RMIDColumn.Visible = False
        Me.RMIDColumn.Width = 70
        '
        'CarbonColumn
        '
        Me.CarbonColumn.DataPropertyName = "Carbon"
        Me.CarbonColumn.HeaderText = "Carbon"
        Me.CarbonColumn.Name = "CarbonColumn"
        Me.CarbonColumn.ReadOnly = True
        Me.CarbonColumn.Width = 70
        '
        'SteelSizeColumn
        '
        Me.SteelSizeColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn.HeaderText = "Steel Size"
        Me.SteelSizeColumn.Name = "SteelSizeColumn"
        Me.SteelSizeColumn.ReadOnly = True
        Me.SteelSizeColumn.Width = 85
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        Me.DescriptionColumn.ReadOnly = True
        '
        'SteelEndingInventoryColumn
        '
        Me.SteelEndingInventoryColumn.DataPropertyName = "SteelEndingInventory"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        Me.SteelEndingInventoryColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.SteelEndingInventoryColumn.HeaderText = "QOH"
        Me.SteelEndingInventoryColumn.Name = "SteelEndingInventoryColumn"
        Me.SteelEndingInventoryColumn.ReadOnly = True
        Me.SteelEndingInventoryColumn.Width = 85
        '
        'ValuationQuantityColumn
        '
        Me.ValuationQuantityColumn.DataPropertyName = "ValuationQuantity"
        Me.ValuationQuantityColumn.HeaderText = "Valuation QOH"
        Me.ValuationQuantityColumn.Name = "ValuationQuantityColumn"
        Me.ValuationQuantityColumn.ReadOnly = True
        '
        'SteelReceiveTotalColumn
        '
        Me.SteelReceiveTotalColumn.DataPropertyName = "SteelReceiveTotal"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.SteelReceiveTotalColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.SteelReceiveTotalColumn.HeaderText = "Total Received"
        Me.SteelReceiveTotalColumn.Name = "SteelReceiveTotalColumn"
        Me.SteelReceiveTotalColumn.ReadOnly = True
        Me.SteelReceiveTotalColumn.Width = 85
        '
        'SteelUsageTotalColumn
        '
        Me.SteelUsageTotalColumn.DataPropertyName = "SteelUsageTotal"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = "0"
        Me.SteelUsageTotalColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.SteelUsageTotalColumn.HeaderText = "Total Used"
        Me.SteelUsageTotalColumn.Name = "SteelUsageTotalColumn"
        Me.SteelUsageTotalColumn.ReadOnly = True
        Me.SteelUsageTotalColumn.Width = 85
        '
        'SteelAdjustTotalColumn
        '
        Me.SteelAdjustTotalColumn.DataPropertyName = "SteelAdjustTotal"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = "0"
        Me.SteelAdjustTotalColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.SteelAdjustTotalColumn.HeaderText = "Adjustments"
        Me.SteelAdjustTotalColumn.Name = "SteelAdjustTotalColumn"
        Me.SteelAdjustTotalColumn.ReadOnly = True
        Me.SteelAdjustTotalColumn.Width = 85
        '
        'SteelBeginningBalanceColumn
        '
        Me.SteelBeginningBalanceColumn.DataPropertyName = "SteelBeginningBalance"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = "0"
        Me.SteelBeginningBalanceColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.SteelBeginningBalanceColumn.HeaderText = "Beginning Balance"
        Me.SteelBeginningBalanceColumn.Name = "SteelBeginningBalanceColumn"
        Me.SteelBeginningBalanceColumn.ReadOnly = True
        Me.SteelBeginningBalanceColumn.Visible = False
        Me.SteelBeginningBalanceColumn.Width = 85
        '
        'CreationDateColumn
        '
        Me.CreationDateColumn.DataPropertyName = "CreationDate"
        Me.CreationDateColumn.HeaderText = "Creation Date"
        Me.CreationDateColumn.Name = "CreationDateColumn"
        Me.CreationDateColumn.Visible = False
        Me.CreationDateColumn.Width = 63
        '
        'SteelBalances
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.gpxRawMaterialForm)
        Me.Controls.Add(Me.dgvSteelBalances)
        Me.Controls.Add(Me.gpxSearchFields)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "SteelBalances"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Steel Balances"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxSearchFields.ResumeLayout(False)
        Me.gpxSearchFields.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelInventoryTotalsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSteelBalances, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxRawMaterialForm.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents RawMaterialsTableRMIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SumOfAdjustmentWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SumOfReceiveWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SumOfUsageWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gpxSearchFields As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents dgvSteelBalances As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents SteelInventoryTotalsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelInventoryTotalsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelInventoryTotalsTableAdapter
    Friend WithEvents cboSteelCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents gpxRawMaterialForm As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdOpenVoucherForm As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSteelDescription As System.Windows.Forms.TextBox
    Friend WithEvents chkQOH As System.Windows.Forms.CheckBox
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelEndingInventoryColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValuationQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReceiveTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelUsageTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelAdjustTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelBeginningBalanceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreationDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
