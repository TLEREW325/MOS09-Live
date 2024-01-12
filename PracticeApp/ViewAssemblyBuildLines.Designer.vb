<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewAssemblyBuildLines
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxAPAging = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtSerialNumber = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
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
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvAssemblyBuildLines = New System.Windows.Forms.DataGridView
        Me.BuildTransactionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyPartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerialNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalAssemblyCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComponentPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComponentPartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComponentUnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComponentExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildLineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CalculatedAssemblyCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyBuildQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AssemblyBuildQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblyBuildQueryTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxAPAging.SuspendLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAssemblyBuildLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssemblyBuildQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditReportsToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
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
        'EditReportsToolStripMenuItem
        '
        Me.EditReportsToolStripMenuItem.Name = "EditReportsToolStripMenuItem"
        Me.EditReportsToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditReportsToolStripMenuItem.Text = "Edit"
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
        'gpxAPAging
        '
        Me.gpxAPAging.Controls.Add(Me.Label5)
        Me.gpxAPAging.Controls.Add(Me.txtSerialNumber)
        Me.gpxAPAging.Controls.Add(Me.Label14)
        Me.gpxAPAging.Controls.Add(Me.chkDateRange)
        Me.gpxAPAging.Controls.Add(Me.dtpEndDate)
        Me.gpxAPAging.Controls.Add(Me.Label9)
        Me.gpxAPAging.Controls.Add(Me.dtpBeginDate)
        Me.gpxAPAging.Controls.Add(Me.Label8)
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
        Me.gpxAPAging.Size = New System.Drawing.Size(300, 770)
        Me.gpxAPAging.TabIndex = 1
        Me.gpxAPAging.TabStop = False
        Me.gpxAPAging.Text = "View By Filters"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(15, 397)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 21)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "Serial #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerialNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerialNumber.Location = New System.Drawing.Point(83, 397)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(200, 20)
        Me.txtSerialNumber.TabIndex = 59
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(14, 589)
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
        Me.chkDateRange.Location = New System.Drawing.Point(106, 625)
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
        Me.dtpEndDate.Location = New System.Drawing.Point(106, 690)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(177, 20)
        Me.dtpEndDate.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(18, 690)
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
        Me.dtpBeginDate.Location = New System.Drawing.Point(106, 655)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(177, 20)
        Me.dtpBeginDate.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(18, 655)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 20)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "Begin Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(15, 342)
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
        Me.txtTextFilter.Location = New System.Drawing.Point(83, 342)
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
        Me.cboComponentDescription.Location = New System.Drawing.Point(18, 278)
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
        Me.cboComponentPart.Location = New System.Drawing.Point(18, 243)
        Me.cboComponentPart.Name = "cboComponentPart"
        Me.cboComponentPart.Size = New System.Drawing.Size(267, 21)
        Me.cboComponentPart.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 220)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Component Part #"
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
        Me.cboPartDescription.Location = New System.Drawing.Point(18, 168)
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
        Me.cboPartNumber.Location = New System.Drawing.Point(18, 133)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(267, 21)
        Me.cboPartNumber.TabIndex = 1
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(135, 726)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 11
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(212, 726)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 12
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 110)
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
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Enabled = False
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
        'dgvAssemblyBuildLines
        '
        Me.dgvAssemblyBuildLines.AllowUserToAddRows = False
        Me.dgvAssemblyBuildLines.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvAssemblyBuildLines.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAssemblyBuildLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAssemblyBuildLines.AutoGenerateColumns = False
        Me.dgvAssemblyBuildLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAssemblyBuildLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAssemblyBuildLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAssemblyBuildLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BuildTransactionNumberColumn, Me.AssemblyPartNumberColumn, Me.AssemblyPartDescriptionColumn, Me.SerialNumberColumn, Me.BuildCommentColumn, Me.BuildDateColumn, Me.TotalAssemblyCostColumn, Me.ComponentPartNumberColumn, Me.ComponentPartDescriptionColumn, Me.BuildQuantityColumn, Me.ComponentUnitCostColumn, Me.ComponentExtendedCostColumn, Me.BuildLineCommentColumn, Me.CalculatedAssemblyCostColumn, Me.DivisionIDColumn, Me.BuildStatusColumn, Me.BuildLineNumberColumn})
        Me.dgvAssemblyBuildLines.DataSource = Me.AssemblyBuildQueryBindingSource
        Me.dgvAssemblyBuildLines.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvAssemblyBuildLines.Location = New System.Drawing.Point(350, 41)
        Me.dgvAssemblyBuildLines.Name = "dgvAssemblyBuildLines"
        Me.dgvAssemblyBuildLines.ReadOnly = True
        Me.dgvAssemblyBuildLines.Size = New System.Drawing.Size(780, 714)
        Me.dgvAssemblyBuildLines.TabIndex = 14
        '
        'BuildTransactionNumberColumn
        '
        Me.BuildTransactionNumberColumn.DataPropertyName = "BuildTransactionNumber"
        Me.BuildTransactionNumberColumn.HeaderText = "Trans. #"
        Me.BuildTransactionNumberColumn.Name = "BuildTransactionNumberColumn"
        Me.BuildTransactionNumberColumn.ReadOnly = True
        '
        'AssemblyPartNumberColumn
        '
        Me.AssemblyPartNumberColumn.DataPropertyName = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn.HeaderText = "Assembly Part #"
        Me.AssemblyPartNumberColumn.Name = "AssemblyPartNumberColumn"
        Me.AssemblyPartNumberColumn.ReadOnly = True
        '
        'AssemblyPartDescriptionColumn
        '
        Me.AssemblyPartDescriptionColumn.DataPropertyName = "AssemblyPartDescription"
        Me.AssemblyPartDescriptionColumn.HeaderText = "Assembly Description"
        Me.AssemblyPartDescriptionColumn.Name = "AssemblyPartDescriptionColumn"
        Me.AssemblyPartDescriptionColumn.ReadOnly = True
        '
        'SerialNumberColumn
        '
        Me.SerialNumberColumn.DataPropertyName = "SerialNumber"
        Me.SerialNumberColumn.HeaderText = "Serial Number"
        Me.SerialNumberColumn.Name = "SerialNumberColumn"
        Me.SerialNumberColumn.ReadOnly = True
        '
        'BuildCommentColumn
        '
        Me.BuildCommentColumn.DataPropertyName = "BuildComment"
        Me.BuildCommentColumn.HeaderText = "Comment"
        Me.BuildCommentColumn.Name = "BuildCommentColumn"
        Me.BuildCommentColumn.ReadOnly = True
        '
        'BuildDateColumn
        '
        Me.BuildDateColumn.DataPropertyName = "BuildDate"
        Me.BuildDateColumn.HeaderText = "Build Date"
        Me.BuildDateColumn.Name = "BuildDateColumn"
        Me.BuildDateColumn.ReadOnly = True
        '
        'TotalAssemblyCostColumn
        '
        Me.TotalAssemblyCostColumn.DataPropertyName = "TotalAssemblyCost"
        Me.TotalAssemblyCostColumn.HeaderText = "Total Cost"
        Me.TotalAssemblyCostColumn.Name = "TotalAssemblyCostColumn"
        Me.TotalAssemblyCostColumn.ReadOnly = True
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
        Me.ComponentPartDescriptionColumn.HeaderText = "Component Description"
        Me.ComponentPartDescriptionColumn.Name = "ComponentPartDescriptionColumn"
        Me.ComponentPartDescriptionColumn.ReadOnly = True
        '
        'BuildQuantityColumn
        '
        Me.BuildQuantityColumn.DataPropertyName = "BuildQuantity"
        Me.BuildQuantityColumn.HeaderText = "Build Quantity"
        Me.BuildQuantityColumn.Name = "BuildQuantityColumn"
        Me.BuildQuantityColumn.ReadOnly = True
        '
        'ComponentUnitCostColumn
        '
        Me.ComponentUnitCostColumn.DataPropertyName = "ComponentUnitCost"
        Me.ComponentUnitCostColumn.HeaderText = "Unit Cost"
        Me.ComponentUnitCostColumn.Name = "ComponentUnitCostColumn"
        Me.ComponentUnitCostColumn.ReadOnly = True
        '
        'ComponentExtendedCostColumn
        '
        Me.ComponentExtendedCostColumn.DataPropertyName = "ComponentExtendedCost"
        Me.ComponentExtendedCostColumn.HeaderText = "Extended Cost"
        Me.ComponentExtendedCostColumn.Name = "ComponentExtendedCostColumn"
        Me.ComponentExtendedCostColumn.ReadOnly = True
        '
        'BuildLineCommentColumn
        '
        Me.BuildLineCommentColumn.DataPropertyName = "BuildLineComment"
        Me.BuildLineCommentColumn.HeaderText = "Line Comment"
        Me.BuildLineCommentColumn.Name = "BuildLineCommentColumn"
        Me.BuildLineCommentColumn.ReadOnly = True
        '
        'CalculatedAssemblyCostColumn
        '
        Me.CalculatedAssemblyCostColumn.DataPropertyName = "CalculatedAssemblyCost"
        Me.CalculatedAssemblyCostColumn.HeaderText = "CalculatedAssemblyCost"
        Me.CalculatedAssemblyCostColumn.Name = "CalculatedAssemblyCostColumn"
        Me.CalculatedAssemblyCostColumn.ReadOnly = True
        Me.CalculatedAssemblyCostColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'BuildStatusColumn
        '
        Me.BuildStatusColumn.DataPropertyName = "BuildStatus"
        Me.BuildStatusColumn.HeaderText = "BuildStatus"
        Me.BuildStatusColumn.Name = "BuildStatusColumn"
        Me.BuildStatusColumn.ReadOnly = True
        Me.BuildStatusColumn.Visible = False
        '
        'BuildLineNumberColumn
        '
        Me.BuildLineNumberColumn.DataPropertyName = "BuildLineNumber"
        Me.BuildLineNumberColumn.HeaderText = "BuildLineNumber"
        Me.BuildLineNumberColumn.Name = "BuildLineNumberColumn"
        Me.BuildLineNumberColumn.ReadOnly = True
        Me.BuildLineNumberColumn.Visible = False
        '
        'AssemblyBuildQueryBindingSource
        '
        Me.AssemblyBuildQueryBindingSource.DataMember = "AssemblyBuildQuery"
        Me.AssemblyBuildQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'AssemblyBuildQueryTableAdapter
        '
        Me.AssemblyBuildQueryTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'ViewAssemblyBuildLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.dgvAssemblyBuildLines)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxAPAging)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewAssemblyBuildLines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Assembly Build Lines"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxAPAging.ResumeLayout(False)
        Me.gpxAPAging.PerformLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAssemblyBuildLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssemblyBuildQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxAPAging As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents cboComponentDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboComponentPart As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvAssemblyBuildLines As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents AssemblyBuildQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AssemblyBuildQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblyBuildQueryTableAdapter
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents BuildTransactionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssemblyPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssemblyPartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalAssemblyCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentPartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentUnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildLineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CalculatedAssemblyCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PreferredVendorColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
End Class
