<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewAssemblyLines
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gpxAPAging = New System.Windows.Forms.GroupBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.chkNonSerial = New System.Windows.Forms.CheckBox
        Me.chkSerialized = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.cboComponentDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboComponentPart = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvAssemblyLineQuery = New System.Windows.Forms.DataGridView
        Me.AssemblyPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComponentLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComponentPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComponentPartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOnHandColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenPOQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenSOQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchProdLineIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerializedStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyLineQuery2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AssemblyLineQuery2TableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblyLineQuery2TableAdapter
        Me.gpxDuplicateBOM = New System.Windows.Forms.GroupBox
        Me.cmdCreateDuplicate = New System.Windows.Forms.Button
        Me.cmdClearTwo = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtNewAssemblyPartNumber = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtOldAssemblyPartNumber = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dgvOldAssemblyLines = New System.Windows.Forms.DataGridView
        Me.AssemblyLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AssemblyLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblyLineTableTableAdapter
        Me.AssemblyPartNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComponentLineNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComponentPartNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComponentPartDescriptionColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCostColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gpxAPAging.SuspendLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvAssemblyLineQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssemblyLineQuery2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxDuplicateBOM.SuspendLayout()
        CType(Me.dgvOldAssemblyLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssemblyLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpxAPAging
        '
        Me.gpxAPAging.Controls.Add(Me.Label14)
        Me.gpxAPAging.Controls.Add(Me.chkDateRange)
        Me.gpxAPAging.Controls.Add(Me.dtpEndDate)
        Me.gpxAPAging.Controls.Add(Me.Label9)
        Me.gpxAPAging.Controls.Add(Me.dtpBeginDate)
        Me.gpxAPAging.Controls.Add(Me.Label8)
        Me.gpxAPAging.Controls.Add(Me.chkNonSerial)
        Me.gpxAPAging.Controls.Add(Me.chkSerialized)
        Me.gpxAPAging.Controls.Add(Me.Label4)
        Me.gpxAPAging.Controls.Add(Me.txtTextFilter)
        Me.gpxAPAging.Controls.Add(Me.cboComponentDescription)
        Me.gpxAPAging.Controls.Add(Me.cboComponentPart)
        Me.gpxAPAging.Controls.Add(Me.Label3)
        Me.gpxAPAging.Controls.Add(Me.Label12)
        Me.gpxAPAging.Controls.Add(Me.cboPartDescription)
        Me.gpxAPAging.Controls.Add(Me.cboDivisionID)
        Me.gpxAPAging.Controls.Add(Me.cboPartNumber)
        Me.gpxAPAging.Controls.Add(Me.cmdView)
        Me.gpxAPAging.Controls.Add(Me.cmdClear)
        Me.gpxAPAging.Controls.Add(Me.Label2)
        Me.gpxAPAging.Controls.Add(Me.Label1)
        Me.gpxAPAging.Location = New System.Drawing.Point(29, 41)
        Me.gpxAPAging.Name = "gpxAPAging"
        Me.gpxAPAging.Size = New System.Drawing.Size(300, 572)
        Me.gpxAPAging.TabIndex = 0
        Me.gpxAPAging.TabStop = False
        Me.gpxAPAging.Text = "View By Filters"
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(17, 395)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(269, 33)
        Me.Label14.TabIndex = 58
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(109, 431)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 8
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(109, 496)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(177, 20)
        Me.dtpEndDate.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(21, 496)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 20)
        Me.Label9.TabIndex = 57
        Me.Label9.Text = "End Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(109, 461)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(177, 20)
        Me.dtpBeginDate.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(21, 461)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 20)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "Begin Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkNonSerial
        '
        Me.chkNonSerial.AutoSize = True
        Me.chkNonSerial.Location = New System.Drawing.Point(85, 366)
        Me.chkNonSerial.Name = "chkNonSerial"
        Me.chkNonSerial.Size = New System.Drawing.Size(149, 17)
        Me.chkNonSerial.TabIndex = 7
        Me.chkNonSerial.Text = "Non-Serialized Assemblies"
        Me.chkNonSerial.UseVisualStyleBackColor = True
        '
        'chkSerialized
        '
        Me.chkSerialized.AutoSize = True
        Me.chkSerialized.Location = New System.Drawing.Point(85, 343)
        Me.chkSerialized.Name = "chkSerialized"
        Me.chkSerialized.Size = New System.Drawing.Size(126, 17)
        Me.chkSerialized.TabIndex = 6
        Me.chkSerialized.Text = "Serialized Assemblies"
        Me.chkSerialized.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 302)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 21)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "Text Filter"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextFilter.Location = New System.Drawing.Point(85, 302)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(200, 20)
        Me.txtTextFilter.TabIndex = 5
        '
        'cboComponentDescription
        '
        Me.cboComponentDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboComponentDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboComponentDescription.DataSource = Me.ItemListBindingSource
        Me.cboComponentDescription.DisplayMember = "ShortDescription"
        Me.cboComponentDescription.FormattingEnabled = True
        Me.cboComponentDescription.Location = New System.Drawing.Point(18, 257)
        Me.cboComponentDescription.Name = "cboComponentDescription"
        Me.cboComponentDescription.Size = New System.Drawing.Size(267, 21)
        Me.cboComponentDescription.TabIndex = 4
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboComponentPart
        '
        Me.cboComponentPart.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboComponentPart.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboComponentPart.DataSource = Me.ItemListBindingSource
        Me.cboComponentPart.DisplayMember = "ItemID"
        Me.cboComponentPart.FormattingEnabled = True
        Me.cboComponentPart.Location = New System.Drawing.Point(18, 222)
        Me.cboComponentPart.Name = "cboComponentPart"
        Me.cboComponentPart.Size = New System.Drawing.Size(267, 21)
        Me.cboComponentPart.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 199)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "ComponentPart #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(15, 64)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(270, 36)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(17, 162)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(267, 21)
        Me.cboPartDescription.TabIndex = 2
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(83, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(202, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(17, 127)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(267, 21)
        Me.cboPartNumber.TabIndex = 1
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(138, 532)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 11
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(215, 532)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 12
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(263, 21)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Assembly Part #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 2
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
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 10
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 11
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvAssemblyLineQuery
        '
        Me.dgvAssemblyLineQuery.AllowUserToAddRows = False
        Me.dgvAssemblyLineQuery.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvAssemblyLineQuery.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAssemblyLineQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAssemblyLineQuery.AutoGenerateColumns = False
        Me.dgvAssemblyLineQuery.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAssemblyLineQuery.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAssemblyLineQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAssemblyLineQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AssemblyPartNumberColumn, Me.ComponentLineNumberColumn, Me.ComponentPartNumberColumn, Me.ComponentPartDescriptionColumn, Me.QuantityColumn, Me.UnitCostColumn, Me.ExtendedCostColumn, Me.QuantityOnHandColumn, Me.OpenPOQuantityColumn, Me.OpenSOQuantityColumn, Me.LineCommentColumn, Me.ItemClassColumn, Me.PurchProdLineIDColumn, Me.SerializedStatusColumn, Me.TotalCostColumn, Me.AssemblyDescriptionColumn, Me.AssemblyDateColumn, Me.CommentColumn, Me.DivisionIDColumn})
        Me.dgvAssemblyLineQuery.DataSource = Me.AssemblyLineQuery2BindingSource
        Me.dgvAssemblyLineQuery.GridColor = System.Drawing.Color.Lime
        Me.dgvAssemblyLineQuery.Location = New System.Drawing.Point(347, 41)
        Me.dgvAssemblyLineQuery.Name = "dgvAssemblyLineQuery"
        Me.dgvAssemblyLineQuery.ReadOnly = True
        Me.dgvAssemblyLineQuery.Size = New System.Drawing.Size(683, 712)
        Me.dgvAssemblyLineQuery.TabIndex = 12
        '
        'AssemblyPartNumberColumn
        '
        Me.AssemblyPartNumberColumn.DataPropertyName = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn.HeaderText = "Assembly Part #"
        Me.AssemblyPartNumberColumn.Name = "AssemblyPartNumberColumn"
        Me.AssemblyPartNumberColumn.ReadOnly = True
        '
        'ComponentLineNumberColumn
        '
        Me.ComponentLineNumberColumn.DataPropertyName = "ComponentLineNumber"
        Me.ComponentLineNumberColumn.HeaderText = "Line #"
        Me.ComponentLineNumberColumn.Name = "ComponentLineNumberColumn"
        Me.ComponentLineNumberColumn.ReadOnly = True
        '
        'ComponentPartNumberColumn
        '
        Me.ComponentPartNumberColumn.DataPropertyName = "ComponentPartNumber"
        Me.ComponentPartNumberColumn.HeaderText = "Component Part #"
        Me.ComponentPartNumberColumn.Name = "ComponentPartNumberColumn"
        Me.ComponentPartNumberColumn.ReadOnly = True
        '
        'ComponentPartDescriptionColumn
        '
        Me.ComponentPartDescriptionColumn.DataPropertyName = "ComponentPartDescription"
        Me.ComponentPartDescriptionColumn.HeaderText = "Component Part Description"
        Me.ComponentPartDescriptionColumn.Name = "ComponentPartDescriptionColumn"
        Me.ComponentPartDescriptionColumn.ReadOnly = True
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.ReadOnly = True
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.ReadOnly = True
        '
        'ExtendedCostColumn
        '
        Me.ExtendedCostColumn.DataPropertyName = "ExtendedCost"
        Me.ExtendedCostColumn.HeaderText = "Extended Cost"
        Me.ExtendedCostColumn.Name = "ExtendedCostColumn"
        Me.ExtendedCostColumn.ReadOnly = True
        '
        'QuantityOnHandColumn
        '
        Me.QuantityOnHandColumn.DataPropertyName = "QuantityOnHand"
        Me.QuantityOnHandColumn.HeaderText = "QOH"
        Me.QuantityOnHandColumn.Name = "QuantityOnHandColumn"
        Me.QuantityOnHandColumn.ReadOnly = True
        '
        'OpenPOQuantityColumn
        '
        Me.OpenPOQuantityColumn.DataPropertyName = "OpenPOQuantity"
        Me.OpenPOQuantityColumn.HeaderText = "Open PO Quantity"
        Me.OpenPOQuantityColumn.Name = "OpenPOQuantityColumn"
        Me.OpenPOQuantityColumn.ReadOnly = True
        '
        'OpenSOQuantityColumn
        '
        Me.OpenSOQuantityColumn.DataPropertyName = "OpenSOQuantity"
        Me.OpenSOQuantityColumn.HeaderText = "Open SO Quantity"
        Me.OpenSOQuantityColumn.Name = "OpenSOQuantityColumn"
        Me.OpenSOQuantityColumn.ReadOnly = True
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        Me.LineCommentColumn.ReadOnly = True
        '
        'ItemClassColumn
        '
        Me.ItemClassColumn.DataPropertyName = "ItemClass"
        Me.ItemClassColumn.HeaderText = "Item Class"
        Me.ItemClassColumn.Name = "ItemClassColumn"
        Me.ItemClassColumn.ReadOnly = True
        '
        'PurchProdLineIDColumn
        '
        Me.PurchProdLineIDColumn.DataPropertyName = "PurchProdLineID"
        Me.PurchProdLineIDColumn.HeaderText = "PPL"
        Me.PurchProdLineIDColumn.Name = "PurchProdLineIDColumn"
        Me.PurchProdLineIDColumn.ReadOnly = True
        '
        'SerializedStatusColumn
        '
        Me.SerializedStatusColumn.DataPropertyName = "SerializedStatus"
        Me.SerializedStatusColumn.HeaderText = "Serialized Status"
        Me.SerializedStatusColumn.Name = "SerializedStatusColumn"
        Me.SerializedStatusColumn.ReadOnly = True
        '
        'TotalCostColumn
        '
        Me.TotalCostColumn.DataPropertyName = "TotalCost"
        Me.TotalCostColumn.HeaderText = "Assembly Total Cost"
        Me.TotalCostColumn.Name = "TotalCostColumn"
        Me.TotalCostColumn.ReadOnly = True
        '
        'AssemblyDescriptionColumn
        '
        Me.AssemblyDescriptionColumn.DataPropertyName = "AssemblyDescription"
        Me.AssemblyDescriptionColumn.HeaderText = "Assembly Description"
        Me.AssemblyDescriptionColumn.Name = "AssemblyDescriptionColumn"
        Me.AssemblyDescriptionColumn.ReadOnly = True
        '
        'AssemblyDateColumn
        '
        Me.AssemblyDateColumn.DataPropertyName = "AssemblyDate"
        Me.AssemblyDateColumn.HeaderText = "Assembly Date"
        Me.AssemblyDateColumn.Name = "AssemblyDateColumn"
        Me.AssemblyDateColumn.ReadOnly = True
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        Me.CommentColumn.ReadOnly = True
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        '
        'AssemblyLineQuery2BindingSource
        '
        Me.AssemblyLineQuery2BindingSource.DataMember = "AssemblyLineQuery2"
        Me.AssemblyLineQuery2BindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'AssemblyLineQuery2TableAdapter
        '
        Me.AssemblyLineQuery2TableAdapter.ClearBeforeFill = True
        '
        'gpxDuplicateBOM
        '
        Me.gpxDuplicateBOM.Controls.Add(Me.cmdCreateDuplicate)
        Me.gpxDuplicateBOM.Controls.Add(Me.cmdClearTwo)
        Me.gpxDuplicateBOM.Controls.Add(Me.Label7)
        Me.gpxDuplicateBOM.Controls.Add(Me.txtNewAssemblyPartNumber)
        Me.gpxDuplicateBOM.Controls.Add(Me.Label6)
        Me.gpxDuplicateBOM.Controls.Add(Me.txtOldAssemblyPartNumber)
        Me.gpxDuplicateBOM.Controls.Add(Me.Label5)
        Me.gpxDuplicateBOM.Location = New System.Drawing.Point(29, 619)
        Me.gpxDuplicateBOM.Name = "gpxDuplicateBOM"
        Me.gpxDuplicateBOM.Size = New System.Drawing.Size(300, 192)
        Me.gpxDuplicateBOM.TabIndex = 13
        Me.gpxDuplicateBOM.TabStop = False
        Me.gpxDuplicateBOM.Text = "Duplicate BOM"
        '
        'cmdCreateDuplicate
        '
        Me.cmdCreateDuplicate.Location = New System.Drawing.Point(140, 145)
        Me.cmdCreateDuplicate.Name = "cmdCreateDuplicate"
        Me.cmdCreateDuplicate.Size = New System.Drawing.Size(71, 30)
        Me.cmdCreateDuplicate.TabIndex = 64
        Me.cmdCreateDuplicate.Text = "Create New"
        Me.cmdCreateDuplicate.UseVisualStyleBackColor = True
        '
        'cmdClearTwo
        '
        Me.cmdClearTwo.Location = New System.Drawing.Point(215, 145)
        Me.cmdClearTwo.Name = "cmdClearTwo"
        Me.cmdClearTwo.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearTwo.TabIndex = 65
        Me.cmdClearTwo.Text = "Clear"
        Me.cmdClearTwo.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(9, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 21)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "New Part #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNewAssemblyPartNumber
        '
        Me.txtNewAssemblyPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNewAssemblyPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNewAssemblyPartNumber.Location = New System.Drawing.Point(83, 104)
        Me.txtNewAssemblyPartNumber.Name = "txtNewAssemblyPartNumber"
        Me.txtNewAssemblyPartNumber.Size = New System.Drawing.Size(203, 20)
        Me.txtNewAssemblyPartNumber.TabIndex = 62
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(9, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 21)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "Old Part #"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOldAssemblyPartNumber
        '
        Me.txtOldAssemblyPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOldAssemblyPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOldAssemblyPartNumber.Location = New System.Drawing.Point(83, 65)
        Me.txtOldAssemblyPartNumber.Name = "txtOldAssemblyPartNumber"
        Me.txtOldAssemblyPartNumber.Size = New System.Drawing.Size(203, 20)
        Me.txtOldAssemblyPartNumber.TabIndex = 60
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(16, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(269, 46)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "To re-create an assembly with a new part # and an existing BOM, select new and ol" & _
            "d part # below."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvOldAssemblyLines
        '
        Me.dgvOldAssemblyLines.AllowUserToAddRows = False
        Me.dgvOldAssemblyLines.AutoGenerateColumns = False
        Me.dgvOldAssemblyLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvOldAssemblyLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOldAssemblyLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AssemblyPartNumberColumn2, Me.ComponentLineNumberColumn2, Me.DivisionIDColumn2, Me.ComponentPartNumberColumn2, Me.ComponentPartDescriptionColumn2, Me.QuantityColumn2, Me.UnitCostColumn2, Me.ExtendedCostColumn2, Me.LineCommentColumn2})
        Me.dgvOldAssemblyLines.DataSource = Me.AssemblyLineTableBindingSource
        Me.dgvOldAssemblyLines.Location = New System.Drawing.Point(347, 41)
        Me.dgvOldAssemblyLines.Name = "dgvOldAssemblyLines"
        Me.dgvOldAssemblyLines.Size = New System.Drawing.Size(240, 150)
        Me.dgvOldAssemblyLines.TabIndex = 14
        Me.dgvOldAssemblyLines.Visible = False
        '
        'AssemblyLineTableBindingSource
        '
        Me.AssemblyLineTableBindingSource.DataMember = "AssemblyLineTable"
        Me.AssemblyLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'AssemblyLineTableTableAdapter
        '
        Me.AssemblyLineTableTableAdapter.ClearBeforeFill = True
        '
        'AssemblyPartNumberColumn2
        '
        Me.AssemblyPartNumberColumn2.DataPropertyName = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn2.HeaderText = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn2.Name = "AssemblyPartNumberColumn2"
        '
        'ComponentLineNumberColumn2
        '
        Me.ComponentLineNumberColumn2.DataPropertyName = "ComponentLineNumber"
        Me.ComponentLineNumberColumn2.HeaderText = "ComponentLineNumber"
        Me.ComponentLineNumberColumn2.Name = "ComponentLineNumberColumn2"
        '
        'DivisionIDColumn2
        '
        Me.DivisionIDColumn2.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn2.HeaderText = "DivisionID"
        Me.DivisionIDColumn2.Name = "DivisionIDColumn2"
        '
        'ComponentPartNumberColumn2
        '
        Me.ComponentPartNumberColumn2.DataPropertyName = "ComponentPartNumber"
        Me.ComponentPartNumberColumn2.HeaderText = "ComponentPartNumber"
        Me.ComponentPartNumberColumn2.Name = "ComponentPartNumberColumn2"
        '
        'ComponentPartDescriptionColumn2
        '
        Me.ComponentPartDescriptionColumn2.DataPropertyName = "ComponentPartDescription"
        Me.ComponentPartDescriptionColumn2.HeaderText = "ComponentPartDescription"
        Me.ComponentPartDescriptionColumn2.Name = "ComponentPartDescriptionColumn2"
        '
        'QuantityColumn2
        '
        Me.QuantityColumn2.DataPropertyName = "Quantity"
        Me.QuantityColumn2.HeaderText = "Quantity"
        Me.QuantityColumn2.Name = "QuantityColumn2"
        '
        'UnitCostColumn2
        '
        Me.UnitCostColumn2.DataPropertyName = "UnitCost"
        Me.UnitCostColumn2.HeaderText = "UnitCost"
        Me.UnitCostColumn2.Name = "UnitCostColumn2"
        '
        'ExtendedCostColumn2
        '
        Me.ExtendedCostColumn2.DataPropertyName = "ExtendedCost"
        Me.ExtendedCostColumn2.HeaderText = "ExtendedCost"
        Me.ExtendedCostColumn2.Name = "ExtendedCostColumn2"
        '
        'LineCommentColumn2
        '
        Me.LineCommentColumn2.DataPropertyName = "LineComment"
        Me.LineCommentColumn2.HeaderText = "LineComment"
        Me.LineCommentColumn2.Name = "LineCommentColumn2"
        '
        'ViewAssemblyLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.gpxDuplicateBOM)
        Me.Controls.Add(Me.dgvAssemblyLineQuery)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxAPAging)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvOldAssemblyLines)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewAssemblyLines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation View Assembly Lines"
        Me.gpxAPAging.ResumeLayout(False)
        Me.gpxAPAging.PerformLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvAssemblyLineQuery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssemblyLineQuery2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxDuplicateBOM.ResumeLayout(False)
        Me.gpxDuplicateBOM.PerformLayout()
        CType(Me.dgvOldAssemblyLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssemblyLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpxAPAging As System.Windows.Forms.GroupBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvAssemblyLineQuery As System.Windows.Forms.DataGridView
    Friend WithEvents cboComponentDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboComponentPart As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkNonSerial As System.Windows.Forms.CheckBox
    Friend WithEvents chkSerialized As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents AssemblyLineQuery2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AssemblyLineQuery2TableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblyLineQuery2TableAdapter
    Friend WithEvents AssemblyPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentPartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOnHandColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenPOQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenSOQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchProdLineIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerializedStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssemblyDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssemblyDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gpxDuplicateBOM As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdCreateDuplicate As System.Windows.Forms.Button
    Friend WithEvents cmdClearTwo As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtNewAssemblyPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtOldAssemblyPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents dgvOldAssemblyLines As System.Windows.Forms.DataGridView
    Friend WithEvents AssemblyLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AssemblyLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblyLineTableTableAdapter
    Friend WithEvents AssemblyPartNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentLineNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentPartNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentPartDescriptionColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCostColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
