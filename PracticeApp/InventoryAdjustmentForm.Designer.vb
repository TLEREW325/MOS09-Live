<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryAdjustmentForm
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteLineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnLockBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxAdjustmentDetails = New System.Windows.Forms.GroupBox
        Me.txtBatchStatus = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdBatchNumber = New System.Windows.Forms.Button
        Me.cboBatchNumber = New System.Windows.Forms.ComboBox
        Me.InventoryAdjustmentTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpAdjustmentDate = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtReason = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdGenerateNewAdjustmentNumber = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.cboAdjustmentNumber = New System.Windows.Forms.ComboBox
        Me.txtLongDescription = New System.Windows.Forms.TextBox
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtLineTotal = New System.Windows.Forms.TextBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdEnter = New System.Windows.Forms.Button
        Me.txtCost = New System.Windows.Forms.TextBox
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.gpxPostAdjustment = New System.Windows.Forms.GroupBox
        Me.cmdPostAdjustment = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.gpxDetails = New System.Windows.Forms.GroupBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtLineComment = New System.Windows.Forms.TextBox
        Me.txtSerialNumber = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.lblQOH = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.gpxBatchTotals = New System.Windows.Forms.GroupBox
        Me.txtBatchNumber = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtBatchItems = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtBatchTotal = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.dgvAdjustmentLines = New System.Windows.Forms.DataGridView
        Me.AdjustmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReasonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentAgentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryAdjustmentTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryAdjustmentTableTableAdapter
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.gpxItemData = New System.Windows.Forms.GroupBox
        Me.cboAccountDescription = New System.Windows.Forms.ComboBox
        Me.GLAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtInventoryAccount = New System.Windows.Forms.TextBox
        Me.txtItemClass = New System.Windows.Forms.TextBox
        Me.cboGLAccountNumber = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.GLAccountsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
        Me.cboDeleteLine = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.dgvTempSerialLines = New System.Windows.Forms.DataGridView
        Me.AssemblyPartNumber2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerialNumber2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionID2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalCost2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Comment2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildDate2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildNumber2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerID2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumber2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionNumber2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblySerialTempTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AssemblySerialTempTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblySerialTempTableTableAdapter
        Me.cmdAddSerialNumber = New System.Windows.Forms.Button
        Me.tabInventoryData = New System.Windows.Forms.TabControl
        Me.tabAdjustmentLines = New System.Windows.Forms.TabPage
        Me.tabSerialLines = New System.Windows.Forms.TabPage
        Me.cmdRemoveSerialNumber = New System.Windows.Forms.Button
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.gpxAdjustmentDetails.SuspendLayout()
        CType(Me.InventoryAdjustmentTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxPostAdjustment.SuspendLayout()
        Me.gpxDetails.SuspendLayout()
        Me.gpxBatchTotals.SuspendLayout()
        CType(Me.dgvAdjustmentLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxItemData.SuspendLayout()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvTempSerialLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssemblySerialTempTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabInventoryData.SuspendLayout()
        Me.tabAdjustmentLines.SuspendLayout()
        Me.tabSerialLines.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1055, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 29
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolStripMenuItem1, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveDataToolStripMenuItem, Me.DeleteLineToolStripMenuItem, Me.DeleteDataToolStripMenuItem, Me.ClearDataToolStripMenuItem, Me.PrintDataToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveDataToolStripMenuItem
        '
        Me.SaveDataToolStripMenuItem.Name = "SaveDataToolStripMenuItem"
        Me.SaveDataToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SaveDataToolStripMenuItem.Text = "Save Data"
        '
        'DeleteLineToolStripMenuItem
        '
        Me.DeleteLineToolStripMenuItem.Name = "DeleteLineToolStripMenuItem"
        Me.DeleteLineToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteLineToolStripMenuItem.Text = "Delete Line"
        '
        'DeleteDataToolStripMenuItem
        '
        Me.DeleteDataToolStripMenuItem.Name = "DeleteDataToolStripMenuItem"
        Me.DeleteDataToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteDataToolStripMenuItem.Text = "Delete Batch"
        '
        'ClearDataToolStripMenuItem
        '
        Me.ClearDataToolStripMenuItem.Name = "ClearDataToolStripMenuItem"
        Me.ClearDataToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ClearDataToolStripMenuItem.Text = "Clear Data"
        '
        'PrintDataToolStripMenuItem
        '
        Me.PrintDataToolStripMenuItem.Name = "PrintDataToolStripMenuItem"
        Me.PrintDataToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PrintDataToolStripMenuItem.Text = "Print Data"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 20)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UnLockBatchToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'UnLockBatchToolStripMenuItem
        '
        Me.UnLockBatchToolStripMenuItem.Name = "UnLockBatchToolStripMenuItem"
        Me.UnLockBatchToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.UnLockBatchToolStripMenuItem.Text = "Un-Lock Batch"
        Me.UnLockBatchToolStripMenuItem.Visible = False
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
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'gpxAdjustmentDetails
        '
        Me.gpxAdjustmentDetails.Controls.Add(Me.txtBatchStatus)
        Me.gpxAdjustmentDetails.Controls.Add(Me.Label1)
        Me.gpxAdjustmentDetails.Controls.Add(Me.Label8)
        Me.gpxAdjustmentDetails.Controls.Add(Me.cmdBatchNumber)
        Me.gpxAdjustmentDetails.Controls.Add(Me.cboBatchNumber)
        Me.gpxAdjustmentDetails.Controls.Add(Me.cboDivisionID)
        Me.gpxAdjustmentDetails.Controls.Add(Me.Label4)
        Me.gpxAdjustmentDetails.Controls.Add(Me.dtpAdjustmentDate)
        Me.gpxAdjustmentDetails.Controls.Add(Me.Label13)
        Me.gpxAdjustmentDetails.Controls.Add(Me.Label16)
        Me.gpxAdjustmentDetails.Controls.Add(Me.txtReason)
        Me.gpxAdjustmentDetails.Controls.Add(Me.Label3)
        Me.gpxAdjustmentDetails.Location = New System.Drawing.Point(29, 41)
        Me.gpxAdjustmentDetails.Name = "gpxAdjustmentDetails"
        Me.gpxAdjustmentDetails.Size = New System.Drawing.Size(300, 297)
        Me.gpxAdjustmentDetails.TabIndex = 0
        Me.gpxAdjustmentDetails.TabStop = False
        Me.gpxAdjustmentDetails.Text = "Inventory Adjustment Details"
        '
        'txtBatchStatus
        '
        Me.txtBatchStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchStatus.Enabled = False
        Me.txtBatchStatus.Location = New System.Drawing.Point(104, 144)
        Me.txtBatchStatus.Name = "txtBatchStatus"
        Me.txtBatchStatus.Size = New System.Drawing.Size(180, 20)
        Me.txtBatchStatus.TabIndex = 4
        Me.txtBatchStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(14, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(267, 29)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Generating a new batch number creates the first transaction #."
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(20, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 20)
        Me.Label8.TabIndex = 109
        Me.Label8.Text = "Batch Status"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdBatchNumber
        '
        Me.cmdBatchNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdBatchNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdBatchNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBatchNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdBatchNumber.Location = New System.Drawing.Point(72, 25)
        Me.cmdBatchNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdBatchNumber.Name = "cmdBatchNumber"
        Me.cmdBatchNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdBatchNumber.TabIndex = 0
        Me.cmdBatchNumber.TabStop = False
        Me.cmdBatchNumber.Text = ">>"
        Me.cmdBatchNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBatchNumber.UseVisualStyleBackColor = False
        '
        'cboBatchNumber
        '
        Me.cboBatchNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBatchNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBatchNumber.DataSource = Me.InventoryAdjustmentTableBindingSource
        Me.cboBatchNumber.DisplayMember = "BatchNumber"
        Me.cboBatchNumber.FormattingEnabled = True
        Me.cboBatchNumber.Location = New System.Drawing.Point(104, 25)
        Me.cboBatchNumber.Name = "cboBatchNumber"
        Me.cboBatchNumber.Size = New System.Drawing.Size(180, 21)
        Me.cboBatchNumber.TabIndex = 1
        '
        'InventoryAdjustmentTableBindingSource
        '
        Me.InventoryAdjustmentTableBindingSource.DataMember = "InventoryAdjustmentTable"
        Me.InventoryAdjustmentTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(104, 112)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(180, 21)
        Me.cboDivisionID.TabIndex = 3
        Me.cboDivisionID.ValueMember = "EmployeeID"
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(20, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 20)
        Me.Label4.TabIndex = 89
        Me.Label4.Text = "Division ID"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpAdjustmentDate
        '
        Me.dtpAdjustmentDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpAdjustmentDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAdjustmentDate.Location = New System.Drawing.Point(104, 81)
        Me.dtpAdjustmentDate.Name = "dtpAdjustmentDate"
        Me.dtpAdjustmentDate.Size = New System.Drawing.Size(180, 20)
        Me.dtpAdjustmentDate.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(20, 83)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 20)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Date"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(20, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 20)
        Me.Label16.TabIndex = 108
        Me.Label16.Text = "Batch #"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReason
        '
        Me.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReason.Location = New System.Drawing.Point(20, 199)
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(264, 83)
        Me.txtReason.TabIndex = 5
        Me.txtReason.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 20)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "Reason"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdGenerateNewAdjustmentNumber
        '
        Me.cmdGenerateNewAdjustmentNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateNewAdjustmentNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateNewAdjustmentNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateNewAdjustmentNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateNewAdjustmentNumber.Location = New System.Drawing.Point(72, 25)
        Me.cmdGenerateNewAdjustmentNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateNewAdjustmentNumber.Name = "cmdGenerateNewAdjustmentNumber"
        Me.cmdGenerateNewAdjustmentNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateNewAdjustmentNumber.TabIndex = 5
        Me.cmdGenerateNewAdjustmentNumber.TabStop = False
        Me.cmdGenerateNewAdjustmentNumber.Text = ">>"
        Me.cmdGenerateNewAdjustmentNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateNewAdjustmentNumber.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(20, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 20)
        Me.Label11.TabIndex = 81
        Me.Label11.Text = "Trans. #"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAdjustmentNumber
        '
        Me.cboAdjustmentNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAdjustmentNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAdjustmentNumber.DataSource = Me.InventoryAdjustmentTableBindingSource
        Me.cboAdjustmentNumber.DisplayMember = "AdjustmentNumber"
        Me.cboAdjustmentNumber.FormattingEnabled = True
        Me.cboAdjustmentNumber.Location = New System.Drawing.Point(104, 25)
        Me.cboAdjustmentNumber.Name = "cboAdjustmentNumber"
        Me.cboAdjustmentNumber.Size = New System.Drawing.Size(180, 21)
        Me.cboAdjustmentNumber.TabIndex = 6
        Me.cboAdjustmentNumber.ValueMember = "EmployeeID"
        '
        'txtLongDescription
        '
        Me.txtLongDescription.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtLongDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLongDescription.Location = New System.Drawing.Point(20, 118)
        Me.txtLongDescription.Multiline = True
        Me.txtLongDescription.Name = "txtLongDescription"
        Me.txtLongDescription.Size = New System.Drawing.Size(261, 53)
        Me.txtLongDescription.TabIndex = 9
        Me.txtLongDescription.TabStop = False
        Me.txtLongDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.DropDownWidth = 300
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(20, 85)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(264, 21)
        Me.cboPartDescription.TabIndex = 8
        Me.cboPartDescription.ValueMember = "EmployeeID"
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
        Me.cboPartNumber.DropDownWidth = 250
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(65, 55)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(219, 21)
        Me.cboPartNumber.TabIndex = 7
        Me.cboPartNumber.ValueMember = "EmployeeID"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(20, 55)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 20)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Part #"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(20, 273)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 20)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "Total"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLineTotal
        '
        Me.txtLineTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineTotal.Enabled = False
        Me.txtLineTotal.Location = New System.Drawing.Point(146, 273)
        Me.txtLineTotal.Name = "txtLineTotal"
        Me.txtLineTotal.Size = New System.Drawing.Size(138, 20)
        Me.txtLineTotal.TabIndex = 12
        Me.txtLineTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(213, 423)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 16
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 242)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 20)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "Adj. Cost"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdEnter
        '
        Me.cmdEnter.Location = New System.Drawing.Point(136, 423)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(71, 30)
        Me.cmdEnter.TabIndex = 15
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'txtCost
        '
        Me.txtCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCost.Enabled = False
        Me.txtCost.Location = New System.Drawing.Point(146, 242)
        Me.txtCost.Name = "txtCost"
        Me.txtCost.Size = New System.Drawing.Size(138, 20)
        Me.txtCost.TabIndex = 11
        Me.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuantity
        '
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantity.Location = New System.Drawing.Point(146, 211)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(138, 20)
        Me.txtQuantity.TabIndex = 10
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(20, 211)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 20)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Quantity"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(821, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 26
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(899, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 27
        Me.cmdDelete.Text = "Delete Batch"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(977, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 28
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'gpxPostAdjustment
        '
        Me.gpxPostAdjustment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxPostAdjustment.Controls.Add(Me.cmdPostAdjustment)
        Me.gpxPostAdjustment.Controls.Add(Me.Label10)
        Me.gpxPostAdjustment.Location = New System.Drawing.Point(820, 676)
        Me.gpxPostAdjustment.Name = "gpxPostAdjustment"
        Me.gpxPostAdjustment.Size = New System.Drawing.Size(308, 78)
        Me.gpxPostAdjustment.TabIndex = 24
        Me.gpxPostAdjustment.TabStop = False
        Me.gpxPostAdjustment.Text = "Post Adjustment"
        '
        'cmdPostAdjustment
        '
        Me.cmdPostAdjustment.ForeColor = System.Drawing.Color.Blue
        Me.cmdPostAdjustment.Location = New System.Drawing.Point(213, 24)
        Me.cmdPostAdjustment.Name = "cmdPostAdjustment"
        Me.cmdPostAdjustment.Size = New System.Drawing.Size(71, 40)
        Me.cmdPostAdjustment.TabIndex = 25
        Me.cmdPostAdjustment.Text = "Post Adjustment"
        Me.cmdPostAdjustment.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(6, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(191, 39)
        Me.Label10.TabIndex = 108
        Me.Label10.Text = "Once posted, an Inventory Adjustment may not be changed or deleted."
        '
        'gpxDetails
        '
        Me.gpxDetails.Controls.Add(Me.Label23)
        Me.gpxDetails.Controls.Add(Me.txtLineComment)
        Me.gpxDetails.Controls.Add(Me.txtSerialNumber)
        Me.gpxDetails.Controls.Add(Me.Label21)
        Me.gpxDetails.Controls.Add(Me.Label22)
        Me.gpxDetails.Controls.Add(Me.txtQuantity)
        Me.gpxDetails.Controls.Add(Me.txtCost)
        Me.gpxDetails.Controls.Add(Me.txtLineTotal)
        Me.gpxDetails.Controls.Add(Me.lblQOH)
        Me.gpxDetails.Controls.Add(Me.Label6)
        Me.gpxDetails.Controls.Add(Me.Label5)
        Me.gpxDetails.Controls.Add(Me.Label15)
        Me.gpxDetails.Controls.Add(Me.txtLongDescription)
        Me.gpxDetails.Controls.Add(Me.cboPartDescription)
        Me.gpxDetails.Controls.Add(Me.cmdEnter)
        Me.gpxDetails.Controls.Add(Me.cmdGenerateNewAdjustmentNumber)
        Me.gpxDetails.Controls.Add(Me.Label2)
        Me.gpxDetails.Controls.Add(Me.Label11)
        Me.gpxDetails.Controls.Add(Me.cmdClear)
        Me.gpxDetails.Controls.Add(Me.cboAdjustmentNumber)
        Me.gpxDetails.Controls.Add(Me.cboPartNumber)
        Me.gpxDetails.Controls.Add(Me.Label14)
        Me.gpxDetails.Location = New System.Drawing.Point(29, 344)
        Me.gpxDetails.Name = "gpxDetails"
        Me.gpxDetails.Size = New System.Drawing.Size(300, 467)
        Me.gpxDetails.TabIndex = 5
        Me.gpxDetails.TabStop = False
        Me.gpxDetails.Text = "Item Details"
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(20, 332)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(261, 20)
        Me.Label23.TabIndex = 115
        Me.Label23.Text = "Line Comment"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLineComment
        '
        Me.txtLineComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineComment.Location = New System.Drawing.Point(20, 355)
        Me.txtLineComment.Multiline = True
        Me.txtLineComment.Name = "txtLineComment"
        Me.txtLineComment.Size = New System.Drawing.Size(264, 60)
        Me.txtLineComment.TabIndex = 14
        Me.txtLineComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerialNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerialNumber.Enabled = False
        Me.txtSerialNumber.Location = New System.Drawing.Point(73, 304)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(211, 20)
        Me.txtSerialNumber.TabIndex = 13
        Me.txtSerialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.ForeColor = System.Drawing.Color.Blue
        Me.Label21.Location = New System.Drawing.Point(70, 269)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(70, 20)
        Me.Label21.TabIndex = 113
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(20, 304)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(58, 20)
        Me.Label22.TabIndex = 111
        Me.Label22.Text = "Serial #"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblQOH
        '
        Me.lblQOH.ForeColor = System.Drawing.Color.Blue
        Me.lblQOH.Location = New System.Drawing.Point(70, 211)
        Me.lblQOH.Name = "lblQOH"
        Me.lblQOH.Size = New System.Drawing.Size(70, 20)
        Me.lblQOH.TabIndex = 110
        Me.lblQOH.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(20, 174)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(261, 34)
        Me.Label6.TabIndex = 93
        Me.Label6.Text = "If you are adjusting the quantity down, you must enter Quantity as a negative num" & _
            "ber."
        '
        'gpxBatchTotals
        '
        Me.gpxBatchTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxBatchTotals.Controls.Add(Me.txtBatchNumber)
        Me.gpxBatchTotals.Controls.Add(Me.Label7)
        Me.gpxBatchTotals.Controls.Add(Me.txtBatchItems)
        Me.gpxBatchTotals.Controls.Add(Me.Label9)
        Me.gpxBatchTotals.Controls.Add(Me.txtBatchTotal)
        Me.gpxBatchTotals.Controls.Add(Me.Label12)
        Me.gpxBatchTotals.Location = New System.Drawing.Point(820, 529)
        Me.gpxBatchTotals.Name = "gpxBatchTotals"
        Me.gpxBatchTotals.Size = New System.Drawing.Size(308, 139)
        Me.gpxBatchTotals.TabIndex = 23
        Me.gpxBatchTotals.TabStop = False
        Me.gpxBatchTotals.Text = "Batch Totals"
        '
        'txtBatchNumber
        '
        Me.txtBatchNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchNumber.Enabled = False
        Me.txtBatchNumber.Location = New System.Drawing.Point(136, 91)
        Me.txtBatchNumber.Name = "txtBatchNumber"
        Me.txtBatchNumber.ReadOnly = True
        Me.txtBatchNumber.Size = New System.Drawing.Size(148, 20)
        Me.txtBatchNumber.TabIndex = 23
        Me.txtBatchNumber.TabStop = False
        Me.txtBatchNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(27, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 20)
        Me.Label7.TabIndex = 96
        Me.Label7.Text = "Batch Number"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBatchItems
        '
        Me.txtBatchItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchItems.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchItems.Location = New System.Drawing.Point(136, 39)
        Me.txtBatchItems.Name = "txtBatchItems"
        Me.txtBatchItems.ReadOnly = True
        Me.txtBatchItems.Size = New System.Drawing.Size(148, 20)
        Me.txtBatchItems.TabIndex = 21
        Me.txtBatchItems.TabStop = False
        Me.txtBatchItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(27, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 20)
        Me.Label9.TabIndex = 91
        Me.Label9.Text = "Batch Items"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBatchTotal
        '
        Me.txtBatchTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchTotal.Enabled = False
        Me.txtBatchTotal.Location = New System.Drawing.Point(136, 65)
        Me.txtBatchTotal.Name = "txtBatchTotal"
        Me.txtBatchTotal.ReadOnly = True
        Me.txtBatchTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtBatchTotal.TabIndex = 22
        Me.txtBatchTotal.TabStop = False
        Me.txtBatchTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(27, 65)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 20)
        Me.Label12.TabIndex = 94
        Me.Label12.Text = "Batch Total"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvAdjustmentLines
        '
        Me.dgvAdjustmentLines.AllowUserToAddRows = False
        Me.dgvAdjustmentLines.AllowUserToDeleteRows = False
        Me.dgvAdjustmentLines.AllowUserToOrderColumns = True
        Me.dgvAdjustmentLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAdjustmentLines.AutoGenerateColumns = False
        Me.dgvAdjustmentLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAdjustmentLines.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAdjustmentLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAdjustmentLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAdjustmentLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AdjustmentNumberColumn, Me.AdjustmentDateColumn, Me.PartNumberColumn, Me.DescriptionColumn, Me.QuantityColumn, Me.CostColumn, Me.TotalColumn, Me.ReasonColumn, Me.LineCommentColumn, Me.InventoryAccountColumn, Me.AdjustmentAccountColumn, Me.AdjustmentAgentColumn, Me.BatchNumberColumn, Me.DivisionIDColumn, Me.StatusColumn})
        Me.dgvAdjustmentLines.DataSource = Me.InventoryAdjustmentTableBindingSource
        Me.dgvAdjustmentLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvAdjustmentLines.Location = New System.Drawing.Point(0, 0)
        Me.dgvAdjustmentLines.Name = "dgvAdjustmentLines"
        Me.dgvAdjustmentLines.Size = New System.Drawing.Size(772, 448)
        Me.dgvAdjustmentLines.TabIndex = 109
        '
        'AdjustmentNumberColumn
        '
        Me.AdjustmentNumberColumn.DataPropertyName = "AdjustmentNumber"
        Me.AdjustmentNumberColumn.HeaderText = "Adj. #"
        Me.AdjustmentNumberColumn.Name = "AdjustmentNumberColumn"
        Me.AdjustmentNumberColumn.ReadOnly = True
        Me.AdjustmentNumberColumn.Width = 80
        '
        'AdjustmentDateColumn
        '
        Me.AdjustmentDateColumn.DataPropertyName = "AdjustmentDate"
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.AdjustmentDateColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.AdjustmentDateColumn.HeaderText = "Date"
        Me.AdjustmentDateColumn.Name = "AdjustmentDateColumn"
        Me.AdjustmentDateColumn.ReadOnly = True
        Me.AdjustmentDateColumn.Width = 80
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part Number"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        Me.DescriptionColumn.ReadOnly = True
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        DataGridViewCellStyle2.NullValue = "0"
        Me.QuantityColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        '
        'CostColumn
        '
        Me.CostColumn.DataPropertyName = "Cost"
        DataGridViewCellStyle3.Format = "N5"
        DataGridViewCellStyle3.NullValue = "0"
        Me.CostColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.CostColumn.HeaderText = "Cost"
        Me.CostColumn.Name = "CostColumn"
        '
        'TotalColumn
        '
        Me.TotalColumn.DataPropertyName = "Total"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.TotalColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.TotalColumn.HeaderText = "Total"
        Me.TotalColumn.Name = "TotalColumn"
        Me.TotalColumn.ReadOnly = True
        '
        'ReasonColumn
        '
        Me.ReasonColumn.DataPropertyName = "Reason"
        Me.ReasonColumn.HeaderText = "Reason"
        Me.ReasonColumn.Name = "ReasonColumn"
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        '
        'InventoryAccountColumn
        '
        Me.InventoryAccountColumn.DataPropertyName = "InventoryAccount"
        Me.InventoryAccountColumn.HeaderText = "Inventory Account"
        Me.InventoryAccountColumn.Name = "InventoryAccountColumn"
        '
        'AdjustmentAccountColumn
        '
        Me.AdjustmentAccountColumn.DataPropertyName = "AdjustmentAccount"
        Me.AdjustmentAccountColumn.HeaderText = "Adjustment Account"
        Me.AdjustmentAccountColumn.Name = "AdjustmentAccountColumn"
        '
        'AdjustmentAgentColumn
        '
        Me.AdjustmentAgentColumn.DataPropertyName = "AdjustmentAgent"
        Me.AdjustmentAgentColumn.HeaderText = "Adjusted By?"
        Me.AdjustmentAgentColumn.Name = "AdjustmentAgentColumn"
        Me.AdjustmentAgentColumn.ReadOnly = True
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "BatchNumber"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.ReadOnly = True
        Me.BatchNumberColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.ReadOnly = True
        Me.StatusColumn.Visible = False
        '
        'InventoryAdjustmentTableTableAdapter
        '
        Me.InventoryAdjustmentTableTableAdapter.ClearBeforeFill = True
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.Location = New System.Drawing.Point(261, 19)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteLine.TabIndex = 18
        Me.cmdDeleteLine.Text = "Delete Line"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'gpxItemData
        '
        Me.gpxItemData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxItemData.Controls.Add(Me.cboAccountDescription)
        Me.gpxItemData.Controls.Add(Me.txtInventoryAccount)
        Me.gpxItemData.Controls.Add(Me.txtItemClass)
        Me.gpxItemData.Controls.Add(Me.cboGLAccountNumber)
        Me.gpxItemData.Controls.Add(Me.Label17)
        Me.gpxItemData.Controls.Add(Me.Label19)
        Me.gpxItemData.Controls.Add(Me.Label18)
        Me.gpxItemData.Controls.Add(Me.Label20)
        Me.gpxItemData.Location = New System.Drawing.Point(352, 609)
        Me.gpxItemData.Name = "gpxItemData"
        Me.gpxItemData.Size = New System.Drawing.Size(354, 202)
        Me.gpxItemData.TabIndex = 19
        Me.gpxItemData.TabStop = False
        Me.gpxItemData.Text = "Item Details"
        '
        'cboAccountDescription
        '
        Me.cboAccountDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAccountDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountDescription.DataSource = Me.GLAccountsBindingSource
        Me.cboAccountDescription.DisplayMember = "GLAccountShortDescription"
        Me.cboAccountDescription.FormattingEnabled = True
        Me.cboAccountDescription.Location = New System.Drawing.Point(28, 167)
        Me.cboAccountDescription.Name = "cboAccountDescription"
        Me.cboAccountDescription.Size = New System.Drawing.Size(305, 21)
        Me.cboAccountDescription.TabIndex = 22
        '
        'GLAccountsBindingSource
        '
        Me.GLAccountsBindingSource.DataMember = "GLAccounts"
        Me.GLAccountsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtInventoryAccount
        '
        Me.txtInventoryAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInventoryAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInventoryAccount.Enabled = False
        Me.txtInventoryAccount.Location = New System.Drawing.Point(125, 47)
        Me.txtInventoryAccount.Name = "txtInventoryAccount"
        Me.txtInventoryAccount.Size = New System.Drawing.Size(208, 20)
        Me.txtInventoryAccount.TabIndex = 20
        Me.txtInventoryAccount.TabStop = False
        Me.txtInventoryAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtItemClass
        '
        Me.txtItemClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemClass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemClass.Enabled = False
        Me.txtItemClass.Location = New System.Drawing.Point(125, 16)
        Me.txtItemClass.Name = "txtItemClass"
        Me.txtItemClass.Size = New System.Drawing.Size(208, 20)
        Me.txtItemClass.TabIndex = 19
        Me.txtItemClass.TabStop = False
        Me.txtItemClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboGLAccountNumber
        '
        Me.cboGLAccountNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGLAccountNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLAccountNumber.DataSource = Me.GLAccountsBindingSource
        Me.cboGLAccountNumber.DisplayMember = "GLAccountNumber"
        Me.cboGLAccountNumber.FormattingEnabled = True
        Me.cboGLAccountNumber.Location = New System.Drawing.Point(100, 136)
        Me.cboGLAccountNumber.Name = "cboGLAccountNumber"
        Me.cboGLAccountNumber.Size = New System.Drawing.Size(233, 21)
        Me.cboGLAccountNumber.TabIndex = 21
        Me.cboGLAccountNumber.ValueMember = "EmployeeID"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(25, 137)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(136, 20)
        Me.Label17.TabIndex = 86
        Me.Label17.Text = "Adj. Account"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(25, 47)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(136, 20)
        Me.Label19.TabIndex = 88
        Me.Label19.Text = "Inventory Account"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(25, 19)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(136, 20)
        Me.Label18.TabIndex = 83
        Me.Label18.Text = "Item Class"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(25, 76)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(308, 58)
        Me.Label20.TabIndex = 109
        Me.Label20.Text = "You may change GL Adjustment Account prior to adding the line to the batch. The i" & _
            "nventory account must be changed in the Item Class prior to the adjustment, if n" & _
            "ecessary."
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'GLAccountsTableAdapter
        '
        Me.GLAccountsTableAdapter.ClearBeforeFill = True
        '
        'cboDeleteLine
        '
        Me.cboDeleteLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDeleteLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDeleteLine.DataSource = Me.InventoryAdjustmentTableBindingSource
        Me.cboDeleteLine.DisplayMember = "AdjustmentNumber"
        Me.cboDeleteLine.FormattingEnabled = True
        Me.cboDeleteLine.Location = New System.Drawing.Point(28, 30)
        Me.cboDeleteLine.Name = "cboDeleteLine"
        Me.cboDeleteLine.Size = New System.Drawing.Size(205, 21)
        Me.cboDeleteLine.TabIndex = 17
        Me.cboDeleteLine.ValueMember = "EmployeeID"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdDeleteLine)
        Me.GroupBox1.Controls.Add(Me.cboDeleteLine)
        Me.GroupBox1.Location = New System.Drawing.Point(352, 529)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(354, 74)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Delete Adjustment from Batch"
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(743, 771)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 110
        Me.cmdClearAll.Text = "Clear Batch"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'dgvTempSerialLines
        '
        Me.dgvTempSerialLines.AllowUserToAddRows = False
        Me.dgvTempSerialLines.AutoGenerateColumns = False
        Me.dgvTempSerialLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvTempSerialLines.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTempSerialLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTempSerialLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AssemblyPartNumber2Column, Me.SerialNumber2Column, Me.DivisionID2Column, Me.TotalCost2Column, Me.Comment2Column, Me.BuildDate2Column, Me.Status2Column, Me.BuildNumber2Column, Me.CustomerID2Column, Me.BatchNumber2Column, Me.TransactionNumber2Column})
        Me.dgvTempSerialLines.DataSource = Me.AssemblySerialTempTableBindingSource
        Me.dgvTempSerialLines.Location = New System.Drawing.Point(3, 0)
        Me.dgvTempSerialLines.Name = "dgvTempSerialLines"
        Me.dgvTempSerialLines.Size = New System.Drawing.Size(669, 387)
        Me.dgvTempSerialLines.TabIndex = 111
        Me.dgvTempSerialLines.Visible = False
        '
        'AssemblyPartNumber2Column
        '
        Me.AssemblyPartNumber2Column.DataPropertyName = "AssemblyPartNumber"
        Me.AssemblyPartNumber2Column.HeaderText = "Part #"
        Me.AssemblyPartNumber2Column.Name = "AssemblyPartNumber2Column"
        '
        'SerialNumber2Column
        '
        Me.SerialNumber2Column.DataPropertyName = "SerialNumber"
        Me.SerialNumber2Column.HeaderText = "Serial #"
        Me.SerialNumber2Column.Name = "SerialNumber2Column"
        '
        'DivisionID2Column
        '
        Me.DivisionID2Column.DataPropertyName = "DivisionID"
        Me.DivisionID2Column.HeaderText = "DivisionID"
        Me.DivisionID2Column.Name = "DivisionID2Column"
        Me.DivisionID2Column.Visible = False
        '
        'TotalCost2Column
        '
        Me.TotalCost2Column.DataPropertyName = "TotalCost"
        Me.TotalCost2Column.HeaderText = "Cost"
        Me.TotalCost2Column.Name = "TotalCost2Column"
        '
        'Comment2Column
        '
        Me.Comment2Column.DataPropertyName = "Comment"
        Me.Comment2Column.HeaderText = "Comment"
        Me.Comment2Column.Name = "Comment2Column"
        '
        'BuildDate2Column
        '
        Me.BuildDate2Column.DataPropertyName = "BuildDate"
        Me.BuildDate2Column.HeaderText = "Build Date"
        Me.BuildDate2Column.Name = "BuildDate2Column"
        '
        'Status2Column
        '
        Me.Status2Column.DataPropertyName = "Status"
        Me.Status2Column.HeaderText = "Status"
        Me.Status2Column.Name = "Status2Column"
        '
        'BuildNumber2Column
        '
        Me.BuildNumber2Column.DataPropertyName = "BuildNumber"
        Me.BuildNumber2Column.HeaderText = "Build #"
        Me.BuildNumber2Column.Name = "BuildNumber2Column"
        '
        'CustomerID2Column
        '
        Me.CustomerID2Column.DataPropertyName = "CustomerID"
        Me.CustomerID2Column.HeaderText = "Customer"
        Me.CustomerID2Column.Name = "CustomerID2Column"
        '
        'BatchNumber2Column
        '
        Me.BatchNumber2Column.DataPropertyName = "BatchNumber"
        Me.BatchNumber2Column.HeaderText = "Batch #"
        Me.BatchNumber2Column.Name = "BatchNumber2Column"
        Me.BatchNumber2Column.Visible = False
        '
        'TransactionNumber2Column
        '
        Me.TransactionNumber2Column.DataPropertyName = "TransactionNumber"
        Me.TransactionNumber2Column.HeaderText = "Adj. #"
        Me.TransactionNumber2Column.Name = "TransactionNumber2Column"
        '
        'AssemblySerialTempTableBindingSource
        '
        Me.AssemblySerialTempTableBindingSource.DataMember = "AssemblySerialTempTable"
        Me.AssemblySerialTempTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'AssemblySerialTempTableTableAdapter
        '
        Me.AssemblySerialTempTableTableAdapter.ClearBeforeFill = True
        '
        'cmdAddSerialNumber
        '
        Me.cmdAddSerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddSerialNumber.Location = New System.Drawing.Point(518, 399)
        Me.cmdAddSerialNumber.Name = "cmdAddSerialNumber"
        Me.cmdAddSerialNumber.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddSerialNumber.TabIndex = 112
        Me.cmdAddSerialNumber.Text = "Add Serial #"
        Me.cmdAddSerialNumber.UseVisualStyleBackColor = True
        '
        'tabInventoryData
        '
        Me.tabInventoryData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabInventoryData.Controls.Add(Me.tabAdjustmentLines)
        Me.tabInventoryData.Controls.Add(Me.tabSerialLines)
        Me.tabInventoryData.Location = New System.Drawing.Point(348, 41)
        Me.tabInventoryData.Name = "tabInventoryData"
        Me.tabInventoryData.SelectedIndex = 0
        Me.tabInventoryData.Size = New System.Drawing.Size(780, 474)
        Me.tabInventoryData.TabIndex = 113
        '
        'tabAdjustmentLines
        '
        Me.tabAdjustmentLines.Controls.Add(Me.dgvAdjustmentLines)
        Me.tabAdjustmentLines.Location = New System.Drawing.Point(4, 22)
        Me.tabAdjustmentLines.Name = "tabAdjustmentLines"
        Me.tabAdjustmentLines.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAdjustmentLines.Size = New System.Drawing.Size(772, 448)
        Me.tabAdjustmentLines.TabIndex = 0
        Me.tabAdjustmentLines.Text = "Adjustment Lines"
        Me.tabAdjustmentLines.UseVisualStyleBackColor = True
        '
        'tabSerialLines
        '
        Me.tabSerialLines.Controls.Add(Me.cmdRemoveSerialNumber)
        Me.tabSerialLines.Controls.Add(Me.dgvTempSerialLines)
        Me.tabSerialLines.Controls.Add(Me.cmdAddSerialNumber)
        Me.tabSerialLines.Location = New System.Drawing.Point(4, 22)
        Me.tabSerialLines.Name = "tabSerialLines"
        Me.tabSerialLines.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSerialLines.Size = New System.Drawing.Size(772, 448)
        Me.tabSerialLines.TabIndex = 1
        Me.tabSerialLines.Text = "Serial Numbers"
        Me.tabSerialLines.UseVisualStyleBackColor = True
        '
        'cmdRemoveSerialNumber
        '
        Me.cmdRemoveSerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRemoveSerialNumber.Location = New System.Drawing.Point(595, 399)
        Me.cmdRemoveSerialNumber.Name = "cmdRemoveSerialNumber"
        Me.cmdRemoveSerialNumber.Size = New System.Drawing.Size(71, 40)
        Me.cmdRemoveSerialNumber.TabIndex = 113
        Me.cmdRemoveSerialNumber.Text = "Remove Serial #"
        Me.cmdRemoveSerialNumber.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'InventoryAdjustmentForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.tabInventoryData)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpxItemData)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.gpxBatchTotals)
        Me.Controls.Add(Me.gpxDetails)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.gpxPostAdjustment)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.gpxAdjustmentDetails)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "InventoryAdjustmentForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Inventory Adjustment Form"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxAdjustmentDetails.ResumeLayout(False)
        Me.gpxAdjustmentDetails.PerformLayout()
        CType(Me.InventoryAdjustmentTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxPostAdjustment.ResumeLayout(False)
        Me.gpxDetails.ResumeLayout(False)
        Me.gpxDetails.PerformLayout()
        Me.gpxBatchTotals.ResumeLayout(False)
        Me.gpxBatchTotals.PerformLayout()
        CType(Me.dgvAdjustmentLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxItemData.ResumeLayout(False)
        Me.gpxItemData.PerformLayout()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvTempSerialLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssemblySerialTempTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabInventoryData.ResumeLayout(False)
        Me.tabAdjustmentLines.ResumeLayout(False)
        Me.tabSerialLines.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxAdjustmentDetails As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGenerateNewAdjustmentNumber As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboAdjustmentNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents dtpAdjustmentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtLongDescription As System.Windows.Forms.TextBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLineTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCost As System.Windows.Forms.TextBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents gpxPostAdjustment As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPostAdjustment As System.Windows.Forms.Button
    Friend WithEvents gpxDetails As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents SaveDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxBatchTotals As System.Windows.Forms.GroupBox
    Friend WithEvents txtBatchItems As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtBatchTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtBatchNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboBatchNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdBatchNumber As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtBatchStatus As System.Windows.Forms.TextBox
    Friend WithEvents dgvAdjustmentLines As System.Windows.Forms.DataGridView
    Friend WithEvents InventoryAdjustmentTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InventoryAdjustmentTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryAdjustmentTableTableAdapter
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents DeleteLineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxItemData As System.Windows.Forms.GroupBox
    Friend WithEvents cboGLAccountNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents GLAccountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
    Friend WithEvents txtItemClass As System.Windows.Forms.TextBox
    Friend WithEvents txtInventoryAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboDeleteLine As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboAccountDescription As System.Windows.Forms.ComboBox
    Friend WithEvents lblQOH As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents UnLockBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvTempSerialLines As System.Windows.Forms.DataGridView
    Friend WithEvents AssemblySerialTempTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AssemblySerialTempTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblySerialTempTableTableAdapter
    Friend WithEvents txtSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmdAddSerialNumber As System.Windows.Forms.Button
    Friend WithEvents tabInventoryData As System.Windows.Forms.TabControl
    Friend WithEvents tabAdjustmentLines As System.Windows.Forms.TabPage
    Friend WithEvents tabSerialLines As System.Windows.Forms.TabPage
    Friend WithEvents AssemblyPartNumber2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNumber2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionID2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCost2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comment2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildDate2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildNumber2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerID2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumber2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionNumber2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdRemoveSerialNumber As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtLineComment As System.Windows.Forms.TextBox
    Friend WithEvents AdjustmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReasonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InventoryAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentAgentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
End Class
