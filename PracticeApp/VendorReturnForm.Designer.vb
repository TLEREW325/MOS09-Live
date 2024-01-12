<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VendorReturnForm
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ManuallyCloseReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnLockReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.REOpenVendorReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxPOHeaderData = New System.Windows.Forms.GroupBox
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.txtReturnStatus = New System.Windows.Forms.TextBox
        Me.cboReturnNumber = New System.Windows.Forms.ComboBox
        Me.VendorReturnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPurchaseOrderNumber = New System.Windows.Forms.ComboBox
        Me.PurchaseOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpReturnDate = New System.Windows.Forms.DateTimePicker
        Me.cboVendorCode = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdGenerateReturnNumber = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblPaymentTerms = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblPONumber = New System.Windows.Forms.Label
        Me.lblPODate = New System.Windows.Forms.Label
        Me.lblVendorName = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtExtendedAmount = New System.Windows.Forms.TextBox
        Me.cmdEnter = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtUnitCost = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtOrderQuantity = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtLongDescription = New System.Windows.Forms.TextBox
        Me.chkInventoryItem = New System.Windows.Forms.CheckBox
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.gpxReturnTotals = New System.Windows.Forms.GroupBox
        Me.txtSalesTax = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtProductTotal = New System.Windows.Forms.TextBox
        Me.txtReturnTotal = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtFreight = New System.Windows.Forms.TextBox
        Me.VendorReturnTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorReturnTableAdapter
        Me.PurchaseOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.PurchaseOrderLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdSelectLinesFromReceiver = New System.Windows.Forms.Button
        Me.dgvReturnLines = New System.Windows.Forms.DataGridView
        Me.ReturnNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiverNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiverLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorReturnLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PurchaseOrderLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderLineTableTableAdapter
        Me.VendorReturnLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorReturnLineTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.tabPartNumberInfo = New System.Windows.Forms.TabControl
        Me.tabItemEntry = New System.Windows.Forms.TabPage
        Me.tabItemGLInfo = New System.Windows.Forms.TabPage
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtGLPurchases = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtGLCOGS = New System.Windows.Forms.TextBox
        Me.txtGLInventory = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtGLReturns = New System.Windows.Forms.TextBox
        Me.txtGLSales = New System.Windows.Forms.TextBox
        Me.txtItemClassDescription = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.ReturnNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnLineNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.gpxPostReturn = New System.Windows.Forms.GroupBox
        Me.cmdPostReturn = New System.Windows.Forms.Button
        Me.chkApplyAgainst = New System.Windows.Forms.CheckBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.cboDeleteLineNumber = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.dgvSerialLines = New System.Windows.Forms.DataGridView
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
        Me.MenuStrip1.SuspendLayout()
        Me.gpxPOHeaderData.SuspendLayout()
        CType(Me.VendorReturnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxReturnTotals.SuspendLayout()
        CType(Me.PurchaseOrderLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReturnLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorReturnLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPartNumberInfo.SuspendLayout()
        Me.tabItemEntry.SuspendLayout()
        Me.tabItemGLInfo.SuspendLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gpxPostReturn.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvSerialLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssemblySerialTempTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.PrintToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ClearDataToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.SaveToolStripMenuItem.Text = "Save Return"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.PrintToolStripMenuItem.Text = "Print Return"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete Return"
        '
        'ClearDataToolStripMenuItem
        '
        Me.ClearDataToolStripMenuItem.Name = "ClearDataToolStripMenuItem"
        Me.ClearDataToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.ClearDataToolStripMenuItem.Text = "Clear Data"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManuallyCloseReturnToolStripMenuItem, Me.UnLockReturnToolStripMenuItem, Me.REOpenVendorReturnToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ManuallyCloseReturnToolStripMenuItem
        '
        Me.ManuallyCloseReturnToolStripMenuItem.Name = "ManuallyCloseReturnToolStripMenuItem"
        Me.ManuallyCloseReturnToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ManuallyCloseReturnToolStripMenuItem.Text = "Manually Close Return"
        '
        'UnLockReturnToolStripMenuItem
        '
        Me.UnLockReturnToolStripMenuItem.Name = "UnLockReturnToolStripMenuItem"
        Me.UnLockReturnToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.UnLockReturnToolStripMenuItem.Text = "Un-Lock Return"
        '
        'REOpenVendorReturnToolStripMenuItem
        '
        Me.REOpenVendorReturnToolStripMenuItem.Name = "REOpenVendorReturnToolStripMenuItem"
        Me.REOpenVendorReturnToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.REOpenVendorReturnToolStripMenuItem.Text = "Re-Open Vendor Return"
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
        Me.cmdExit.Location = New System.Drawing.Point(1047, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 30
        Me.cmdExit.Text = "Exit Return"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxPOHeaderData
        '
        Me.gpxPOHeaderData.Controls.Add(Me.txtVendorName)
        Me.gpxPOHeaderData.Controls.Add(Me.txtReturnStatus)
        Me.gpxPOHeaderData.Controls.Add(Me.cboReturnNumber)
        Me.gpxPOHeaderData.Controls.Add(Me.txtComment)
        Me.gpxPOHeaderData.Controls.Add(Me.cboDivisionID)
        Me.gpxPOHeaderData.Controls.Add(Me.cboPurchaseOrderNumber)
        Me.gpxPOHeaderData.Controls.Add(Me.dtpReturnDate)
        Me.gpxPOHeaderData.Controls.Add(Me.cboVendorCode)
        Me.gpxPOHeaderData.Controls.Add(Me.cmdGenerateReturnNumber)
        Me.gpxPOHeaderData.Controls.Add(Me.Label3)
        Me.gpxPOHeaderData.Controls.Add(Me.lblPaymentTerms)
        Me.gpxPOHeaderData.Controls.Add(Me.Label15)
        Me.gpxPOHeaderData.Controls.Add(Me.lblPONumber)
        Me.gpxPOHeaderData.Controls.Add(Me.lblPODate)
        Me.gpxPOHeaderData.Controls.Add(Me.lblVendorName)
        Me.gpxPOHeaderData.Controls.Add(Me.Label22)
        Me.gpxPOHeaderData.Location = New System.Drawing.Point(29, 41)
        Me.gpxPOHeaderData.Name = "gpxPOHeaderData"
        Me.gpxPOHeaderData.Size = New System.Drawing.Size(315, 342)
        Me.gpxPOHeaderData.TabIndex = 0
        Me.gpxPOHeaderData.TabStop = False
        Me.gpxPOHeaderData.Text = "Vendor Return Data"
        '
        'txtVendorName
        '
        Me.txtVendorName.BackColor = System.Drawing.SystemColors.Control
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Enabled = False
        Me.txtVendorName.Location = New System.Drawing.Point(16, 134)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.ReadOnly = True
        Me.txtVendorName.Size = New System.Drawing.Size(282, 40)
        Me.txtVendorName.TabIndex = 5
        Me.txtVendorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReturnStatus
        '
        Me.txtReturnStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnStatus.Enabled = False
        Me.txtReturnStatus.Location = New System.Drawing.Point(109, 209)
        Me.txtReturnStatus.Name = "txtReturnStatus"
        Me.txtReturnStatus.Size = New System.Drawing.Size(188, 20)
        Me.txtReturnStatus.TabIndex = 7
        Me.txtReturnStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboReturnNumber
        '
        Me.cboReturnNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReturnNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReturnNumber.DataSource = Me.VendorReturnBindingSource
        Me.cboReturnNumber.DisplayMember = "ReturnNumber"
        Me.cboReturnNumber.FormattingEnabled = True
        Me.cboReturnNumber.Location = New System.Drawing.Point(111, 23)
        Me.cboReturnNumber.Name = "cboReturnNumber"
        Me.cboReturnNumber.Size = New System.Drawing.Size(189, 21)
        Me.cboReturnNumber.TabIndex = 1
        '
        'VendorReturnBindingSource
        '
        Me.VendorReturnBindingSource.DataMember = "VendorReturn"
        Me.VendorReturnBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtComment
        '
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(15, 261)
        Me.txtComment.MaxLength = 200
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(283, 66)
        Me.txtComment.TabIndex = 8
        Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(109, 181)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(189, 21)
        Me.cboDivisionID.TabIndex = 6
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPurchaseOrderNumber
        '
        Me.cboPurchaseOrderNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPurchaseOrderNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPurchaseOrderNumber.DataSource = Me.PurchaseOrderHeaderTableBindingSource
        Me.cboPurchaseOrderNumber.DisplayMember = "PurchaseOrderHeaderKey"
        Me.cboPurchaseOrderNumber.FormattingEnabled = True
        Me.cboPurchaseOrderNumber.Location = New System.Drawing.Point(111, 51)
        Me.cboPurchaseOrderNumber.Name = "cboPurchaseOrderNumber"
        Me.cboPurchaseOrderNumber.Size = New System.Drawing.Size(188, 21)
        Me.cboPurchaseOrderNumber.TabIndex = 2
        '
        'PurchaseOrderHeaderTableBindingSource
        '
        Me.PurchaseOrderHeaderTableBindingSource.DataMember = "PurchaseOrderHeaderTable"
        Me.PurchaseOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpReturnDate
        '
        Me.dtpReturnDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReturnDate.Location = New System.Drawing.Point(112, 79)
        Me.dtpReturnDate.Name = "dtpReturnDate"
        Me.dtpReturnDate.Size = New System.Drawing.Size(188, 20)
        Me.dtpReturnDate.TabIndex = 3
        '
        'cboVendorCode
        '
        Me.cboVendorCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorCode.DataSource = Me.VendorBindingSource
        Me.cboVendorCode.DisplayMember = "VendorCode"
        Me.cboVendorCode.FormattingEnabled = True
        Me.cboVendorCode.Location = New System.Drawing.Point(110, 106)
        Me.cboVendorCode.Name = "cboVendorCode"
        Me.cboVendorCode.Size = New System.Drawing.Size(190, 21)
        Me.cboVendorCode.TabIndex = 4
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdGenerateReturnNumber
        '
        Me.cmdGenerateReturnNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateReturnNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateReturnNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateReturnNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateReturnNumber.Location = New System.Drawing.Point(77, 24)
        Me.cmdGenerateReturnNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateReturnNumber.Name = "cmdGenerateReturnNumber"
        Me.cmdGenerateReturnNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateReturnNumber.TabIndex = 0
        Me.cmdGenerateReturnNumber.TabStop = False
        Me.cmdGenerateReturnNumber.Text = ">>"
        Me.cmdGenerateReturnNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateReturnNumber.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 20)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Vendor ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPaymentTerms
        '
        Me.lblPaymentTerms.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaymentTerms.Location = New System.Drawing.Point(16, 238)
        Me.lblPaymentTerms.Name = "lblPaymentTerms"
        Me.lblPaymentTerms.Size = New System.Drawing.Size(239, 20)
        Me.lblPaymentTerms.TabIndex = 7
        Me.lblPaymentTerms.Text = "Comments (200 characters MAX)"
        Me.lblPaymentTerms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(16, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(98, 20)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "Return #"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPONumber
        '
        Me.lblPONumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPONumber.Location = New System.Drawing.Point(16, 53)
        Me.lblPONumber.Name = "lblPONumber"
        Me.lblPONumber.Size = New System.Drawing.Size(98, 20)
        Me.lblPONumber.TabIndex = 1
        Me.lblPONumber.Text = "PO #"
        Me.lblPONumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPODate
        '
        Me.lblPODate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPODate.Location = New System.Drawing.Point(16, 79)
        Me.lblPODate.Name = "lblPODate"
        Me.lblPODate.Size = New System.Drawing.Size(98, 20)
        Me.lblPODate.TabIndex = 5
        Me.lblPODate.Text = "Date Issued"
        Me.lblPODate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVendorName
        '
        Me.lblVendorName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendorName.Location = New System.Drawing.Point(16, 182)
        Me.lblVendorName.Name = "lblVendorName"
        Me.lblVendorName.Size = New System.Drawing.Size(98, 20)
        Me.lblVendorName.TabIndex = 3
        Me.lblVendorName.Text = "Division ID"
        Me.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(16, 209)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(98, 20)
        Me.Label22.TabIndex = 42
        Me.Label22.Text = "Status"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtExtendedAmount
        '
        Me.txtExtendedAmount.BackColor = System.Drawing.Color.White
        Me.txtExtendedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExtendedAmount.Location = New System.Drawing.Point(136, 204)
        Me.txtExtendedAmount.Name = "txtExtendedAmount"
        Me.txtExtendedAmount.ReadOnly = True
        Me.txtExtendedAmount.Size = New System.Drawing.Size(157, 20)
        Me.txtExtendedAmount.TabIndex = 14
        Me.txtExtendedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdEnter
        '
        Me.cmdEnter.Location = New System.Drawing.Point(147, 239)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(71, 40)
        Me.cmdEnter.TabIndex = 16
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(223, 239)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 17
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 204)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(117, 20)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Extended Amount"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 178)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 20)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Unit Cost"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnitCost
        '
        Me.txtUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitCost.Location = New System.Drawing.Point(136, 178)
        Me.txtUnitCost.Name = "txtUnitCost"
        Me.txtUnitCost.Size = New System.Drawing.Size(157, 20)
        Me.txtUnitCost.TabIndex = 13
        Me.txtUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 150)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(117, 20)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Order Quantity"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOrderQuantity
        '
        Me.txtOrderQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrderQuantity.Location = New System.Drawing.Point(136, 150)
        Me.txtOrderQuantity.Name = "txtOrderQuantity"
        Me.txtOrderQuantity.Size = New System.Drawing.Size(157, 20)
        Me.txtOrderQuantity.TabIndex = 12
        Me.txtOrderQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(9, 55)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 20)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Description"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 20)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Part Number"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLongDescription
        '
        Me.txtLongDescription.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtLongDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLongDescription.Location = New System.Drawing.Point(9, 90)
        Me.txtLongDescription.Multiline = True
        Me.txtLongDescription.Name = "txtLongDescription"
        Me.txtLongDescription.Size = New System.Drawing.Size(284, 43)
        Me.txtLongDescription.TabIndex = 11
        Me.txtLongDescription.TabStop = False
        Me.txtLongDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkInventoryItem
        '
        Me.chkInventoryItem.AutoSize = True
        Me.chkInventoryItem.Checked = True
        Me.chkInventoryItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInventoryItem.Location = New System.Drawing.Point(8, 262)
        Me.chkInventoryItem.Name = "chkInventoryItem"
        Me.chkInventoryItem.Size = New System.Drawing.Size(93, 17)
        Me.chkInventoryItem.TabIndex = 15
        Me.chkInventoryItem.TabStop = False
        Me.chkInventoryItem.Text = "Inventory Item"
        Me.chkInventoryItem.UseVisualStyleBackColor = True
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(95, 54)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(200, 21)
        Me.cboPartDescription.TabIndex = 10
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
        Me.cboPartNumber.Location = New System.Drawing.Point(95, 22)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(200, 21)
        Me.cboPartNumber.TabIndex = 9
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(816, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 27
        Me.cmdSave.Text = "Save Return"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(893, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 28
        Me.cmdDelete.Text = "Delete Return"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(970, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 29
        Me.cmdPrint.Text = "Print Return"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'gpxReturnTotals
        '
        Me.gpxReturnTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxReturnTotals.Controls.Add(Me.txtSalesTax)
        Me.gpxReturnTotals.Controls.Add(Me.Label5)
        Me.gpxReturnTotals.Controls.Add(Me.Label6)
        Me.gpxReturnTotals.Controls.Add(Me.txtProductTotal)
        Me.gpxReturnTotals.Controls.Add(Me.txtReturnTotal)
        Me.gpxReturnTotals.Controls.Add(Me.Label1)
        Me.gpxReturnTotals.Controls.Add(Me.Label4)
        Me.gpxReturnTotals.Controls.Add(Me.txtFreight)
        Me.gpxReturnTotals.Location = New System.Drawing.Point(814, 624)
        Me.gpxReturnTotals.Name = "gpxReturnTotals"
        Me.gpxReturnTotals.Size = New System.Drawing.Size(304, 137)
        Me.gpxReturnTotals.TabIndex = 22
        Me.gpxReturnTotals.TabStop = False
        Me.gpxReturnTotals.Text = "Return Totals"
        '
        'txtSalesTax
        '
        Me.txtSalesTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTax.Location = New System.Drawing.Point(135, 47)
        Me.txtSalesTax.Name = "txtSalesTax"
        Me.txtSalesTax.Size = New System.Drawing.Size(148, 20)
        Me.txtSalesTax.TabIndex = 23
        Me.txtSalesTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 20)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Sales Tax"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 20)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Product Total"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProductTotal
        '
        Me.txtProductTotal.BackColor = System.Drawing.Color.White
        Me.txtProductTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductTotal.Enabled = False
        Me.txtProductTotal.Location = New System.Drawing.Point(135, 20)
        Me.txtProductTotal.Name = "txtProductTotal"
        Me.txtProductTotal.ReadOnly = True
        Me.txtProductTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtProductTotal.TabIndex = 22
        Me.txtProductTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReturnTotal
        '
        Me.txtReturnTotal.BackColor = System.Drawing.Color.White
        Me.txtReturnTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnTotal.Enabled = False
        Me.txtReturnTotal.Location = New System.Drawing.Point(135, 101)
        Me.txtReturnTotal.Name = "txtReturnTotal"
        Me.txtReturnTotal.ReadOnly = True
        Me.txtReturnTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtReturnTotal.TabIndex = 25
        Me.txtReturnTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 20)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Return Total"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 20)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Freight"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFreight
        '
        Me.txtFreight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreight.Location = New System.Drawing.Point(135, 74)
        Me.txtFreight.Name = "txtFreight"
        Me.txtFreight.Size = New System.Drawing.Size(148, 20)
        Me.txtFreight.TabIndex = 24
        Me.txtFreight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'VendorReturnTableAdapter
        '
        Me.VendorReturnTableAdapter.ClearBeforeFill = True
        '
        'PurchaseOrderHeaderTableTableAdapter
        '
        Me.PurchaseOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'PurchaseOrderLineTableBindingSource
        '
        Me.PurchaseOrderLineTableBindingSource.DataMember = "PurchaseOrderLineTable"
        Me.PurchaseOrderLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdSelectLinesFromReceiver
        '
        Me.cmdSelectLinesFromReceiver.ForeColor = System.Drawing.Color.Blue
        Me.cmdSelectLinesFromReceiver.Location = New System.Drawing.Point(20, 23)
        Me.cmdSelectLinesFromReceiver.Name = "cmdSelectLinesFromReceiver"
        Me.cmdSelectLinesFromReceiver.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectLinesFromReceiver.TabIndex = 18
        Me.cmdSelectLinesFromReceiver.Text = "Select Lines"
        Me.cmdSelectLinesFromReceiver.UseVisualStyleBackColor = True
        '
        'dgvReturnLines
        '
        Me.dgvReturnLines.AllowUserToAddRows = False
        Me.dgvReturnLines.AllowUserToDeleteRows = False
        Me.dgvReturnLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReturnLines.AutoGenerateColumns = False
        Me.dgvReturnLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvReturnLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvReturnLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReturnLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReturnNumberColumn, Me.ReturnLineNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityColumn, Me.CostColumn, Me.ExtendedAmountColumn, Me.DebitGLAccountColumn, Me.CreditGLAccountColumn, Me.LineCommentColumn, Me.LineStatusColumn, Me.DivisionIDColumn, Me.ReceiverNumberColumn, Me.ReceiverLineNumberColumn})
        Me.dgvReturnLines.DataSource = Me.VendorReturnLineBindingSource
        Me.dgvReturnLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvReturnLines.Location = New System.Drawing.Point(358, 41)
        Me.dgvReturnLines.Name = "dgvReturnLines"
        Me.dgvReturnLines.Size = New System.Drawing.Size(760, 457)
        Me.dgvReturnLines.TabIndex = 0
        '
        'ReturnNumberColumn
        '
        Me.ReturnNumberColumn.DataPropertyName = "ReturnNumber"
        Me.ReturnNumberColumn.HeaderText = "ReturnNumber"
        Me.ReturnNumberColumn.Name = "ReturnNumberColumn"
        Me.ReturnNumberColumn.Visible = False
        '
        'ReturnLineNumberColumn
        '
        Me.ReturnLineNumberColumn.DataPropertyName = "ReturnLineNumber"
        Me.ReturnLineNumberColumn.HeaderText = "Line #"
        Me.ReturnLineNumberColumn.Name = "ReturnLineNumberColumn"
        Me.ReturnLineNumberColumn.Width = 65
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part Number"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.Width = 120
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Part Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.Width = 150
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        DataGridViewCellStyle1.NullValue = "0"
        Me.QuantityColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.Width = 80
        '
        'CostColumn
        '
        Me.CostColumn.DataPropertyName = "Cost"
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = "0"
        Me.CostColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.CostColumn.HeaderText = "Cost"
        Me.CostColumn.Name = "CostColumn"
        Me.CostColumn.Width = 80
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ExtendedAmountColumn.HeaderText = "Extended Amount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.Width = 80
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "Debit GL Account"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        '
        'CreditGLAccountColumn
        '
        Me.CreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumn.HeaderText = "Credit GL Account"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "LineStatus"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'ReceiverNumberColumn
        '
        Me.ReceiverNumberColumn.DataPropertyName = "ReceiverNumber"
        Me.ReceiverNumberColumn.HeaderText = "Receiver #"
        Me.ReceiverNumberColumn.Name = "ReceiverNumberColumn"
        '
        'ReceiverLineNumberColumn
        '
        Me.ReceiverLineNumberColumn.DataPropertyName = "ReceiverLineNumber"
        Me.ReceiverLineNumberColumn.HeaderText = "Receiver Line #"
        Me.ReceiverLineNumberColumn.Name = "ReceiverLineNumberColumn"
        '
        'VendorReturnLineBindingSource
        '
        Me.VendorReturnLineBindingSource.DataMember = "VendorReturnLine"
        Me.VendorReturnLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'PurchaseOrderLineTableTableAdapter
        '
        Me.PurchaseOrderLineTableTableAdapter.ClearBeforeFill = True
        '
        'VendorReturnLineTableAdapter
        '
        Me.VendorReturnLineTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'tabPartNumberInfo
        '
        Me.tabPartNumberInfo.Controls.Add(Me.tabItemEntry)
        Me.tabPartNumberInfo.Controls.Add(Me.tabItemGLInfo)
        Me.tabPartNumberInfo.Location = New System.Drawing.Point(29, 489)
        Me.tabPartNumberInfo.Name = "tabPartNumberInfo"
        Me.tabPartNumberInfo.SelectedIndex = 0
        Me.tabPartNumberInfo.Size = New System.Drawing.Size(315, 322)
        Me.tabPartNumberInfo.TabIndex = 9
        '
        'tabItemEntry
        '
        Me.tabItemEntry.Controls.Add(Me.cmdClear)
        Me.tabItemEntry.Controls.Add(Me.cmdEnter)
        Me.tabItemEntry.Controls.Add(Me.txtExtendedAmount)
        Me.tabItemEntry.Controls.Add(Me.chkInventoryItem)
        Me.tabItemEntry.Controls.Add(Me.txtLongDescription)
        Me.tabItemEntry.Controls.Add(Me.cboPartNumber)
        Me.tabItemEntry.Controls.Add(Me.txtUnitCost)
        Me.tabItemEntry.Controls.Add(Me.Label12)
        Me.tabItemEntry.Controls.Add(Me.Label13)
        Me.tabItemEntry.Controls.Add(Me.cboPartDescription)
        Me.tabItemEntry.Controls.Add(Me.Label9)
        Me.tabItemEntry.Controls.Add(Me.Label11)
        Me.tabItemEntry.Controls.Add(Me.txtOrderQuantity)
        Me.tabItemEntry.Controls.Add(Me.Label10)
        Me.tabItemEntry.Location = New System.Drawing.Point(4, 22)
        Me.tabItemEntry.Name = "tabItemEntry"
        Me.tabItemEntry.Padding = New System.Windows.Forms.Padding(3)
        Me.tabItemEntry.Size = New System.Drawing.Size(307, 296)
        Me.tabItemEntry.TabIndex = 0
        Me.tabItemEntry.Text = "Manual Item Entry"
        Me.tabItemEntry.UseVisualStyleBackColor = True
        '
        'tabItemGLInfo
        '
        Me.tabItemGLInfo.Controls.Add(Me.Label17)
        Me.tabItemGLInfo.Controls.Add(Me.Label18)
        Me.tabItemGLInfo.Controls.Add(Me.txtGLPurchases)
        Me.tabItemGLInfo.Controls.Add(Me.Label14)
        Me.tabItemGLInfo.Controls.Add(Me.Label16)
        Me.tabItemGLInfo.Controls.Add(Me.txtGLCOGS)
        Me.tabItemGLInfo.Controls.Add(Me.txtGLInventory)
        Me.tabItemGLInfo.Controls.Add(Me.Label7)
        Me.tabItemGLInfo.Controls.Add(Me.Label8)
        Me.tabItemGLInfo.Controls.Add(Me.txtGLReturns)
        Me.tabItemGLInfo.Controls.Add(Me.txtGLSales)
        Me.tabItemGLInfo.Controls.Add(Me.txtItemClassDescription)
        Me.tabItemGLInfo.Controls.Add(Me.Label2)
        Me.tabItemGLInfo.Controls.Add(Me.cboItemClass)
        Me.tabItemGLInfo.Location = New System.Drawing.Point(4, 22)
        Me.tabItemGLInfo.Name = "tabItemGLInfo"
        Me.tabItemGLInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tabItemGLInfo.Size = New System.Drawing.Size(307, 296)
        Me.tabItemGLInfo.TabIndex = 1
        Me.tabItemGLInfo.Text = "Item GL Information"
        Me.tabItemGLInfo.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(15, 62)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(168, 20)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "Item Class Description"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(14, 249)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(127, 20)
        Me.Label18.TabIndex = 39
        Me.Label18.Text = "GLPurchases Account"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGLPurchases
        '
        Me.txtGLPurchases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLPurchases.Location = New System.Drawing.Point(146, 249)
        Me.txtGLPurchases.Name = "txtGLPurchases"
        Me.txtGLPurchases.Size = New System.Drawing.Size(148, 20)
        Me.txtGLPurchases.TabIndex = 36
        Me.txtGLPurchases.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(14, 223)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(127, 20)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "GL COGS Account"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(14, 197)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(127, 20)
        Me.Label16.TabIndex = 35
        Me.Label16.Text = "GL Inventory Account"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGLCOGS
        '
        Me.txtGLCOGS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLCOGS.Location = New System.Drawing.Point(146, 223)
        Me.txtGLCOGS.Name = "txtGLCOGS"
        Me.txtGLCOGS.Size = New System.Drawing.Size(148, 20)
        Me.txtGLCOGS.TabIndex = 33
        Me.txtGLCOGS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGLInventory
        '
        Me.txtGLInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLInventory.Location = New System.Drawing.Point(146, 197)
        Me.txtGLInventory.Name = "txtGLInventory"
        Me.txtGLInventory.Size = New System.Drawing.Size(148, 20)
        Me.txtGLInventory.TabIndex = 32
        Me.txtGLInventory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(127, 20)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "GL Returns Account"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 145)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 20)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "GL Sales Account"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGLReturns
        '
        Me.txtGLReturns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLReturns.Location = New System.Drawing.Point(146, 171)
        Me.txtGLReturns.Name = "txtGLReturns"
        Me.txtGLReturns.Size = New System.Drawing.Size(148, 20)
        Me.txtGLReturns.TabIndex = 23
        Me.txtGLReturns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGLSales
        '
        Me.txtGLSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLSales.Location = New System.Drawing.Point(146, 145)
        Me.txtGLSales.Name = "txtGLSales"
        Me.txtGLSales.Size = New System.Drawing.Size(148, 20)
        Me.txtGLSales.TabIndex = 22
        Me.txtGLSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtItemClassDescription
        '
        Me.txtItemClassDescription.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtItemClassDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemClassDescription.Location = New System.Drawing.Point(15, 85)
        Me.txtItemClassDescription.Multiline = True
        Me.txtItemClassDescription.Name = "txtItemClassDescription"
        Me.txtItemClassDescription.Size = New System.Drawing.Size(278, 39)
        Me.txtItemClassDescription.TabIndex = 21
        Me.txtItemClassDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 20)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Item Class"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(124, 31)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(169, 21)
        Me.cboItemClass.TabIndex = 3
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
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(365, 773)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 26
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'ReturnNumberDataGridViewTextBoxColumn
        '
        Me.ReturnNumberDataGridViewTextBoxColumn.DataPropertyName = "ReturnNumber"
        Me.ReturnNumberDataGridViewTextBoxColumn.HeaderText = "ReturnNumber"
        Me.ReturnNumberDataGridViewTextBoxColumn.Name = "ReturnNumberDataGridViewTextBoxColumn"
        Me.ReturnNumberDataGridViewTextBoxColumn.Visible = False
        '
        'ReturnLineNumberDataGridViewTextBoxColumn
        '
        Me.ReturnLineNumberDataGridViewTextBoxColumn.DataPropertyName = "ReturnLineNumber"
        Me.ReturnLineNumberDataGridViewTextBoxColumn.HeaderText = "Line #"
        Me.ReturnLineNumberDataGridViewTextBoxColumn.Name = "ReturnLineNumberDataGridViewTextBoxColumn"
        Me.ReturnLineNumberDataGridViewTextBoxColumn.Width = 65
        '
        'PartNumberDataGridViewTextBoxColumn1
        '
        Me.PartNumberDataGridViewTextBoxColumn1.DataPropertyName = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn1.HeaderText = "Part Number"
        Me.PartNumberDataGridViewTextBoxColumn1.Name = "PartNumberDataGridViewTextBoxColumn1"
        Me.PartNumberDataGridViewTextBoxColumn1.ToolTipText = " "
        Me.PartNumberDataGridViewTextBoxColumn1.Width = 130
        '
        'PartDescriptionDataGridViewTextBoxColumn1
        '
        Me.PartDescriptionDataGridViewTextBoxColumn1.DataPropertyName = "PartDescription"
        Me.PartDescriptionDataGridViewTextBoxColumn1.HeaderText = "Part Description"
        Me.PartDescriptionDataGridViewTextBoxColumn1.Name = "PartDescriptionDataGridViewTextBoxColumn1"
        Me.PartDescriptionDataGridViewTextBoxColumn1.Width = 150
        '
        'QuantityDataGridViewTextBoxColumn
        '
        Me.QuantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity"
        Me.QuantityDataGridViewTextBoxColumn.HeaderText = "Quantity"
        Me.QuantityDataGridViewTextBoxColumn.Name = "QuantityDataGridViewTextBoxColumn"
        '
        'CostDataGridViewTextBoxColumn
        '
        Me.CostDataGridViewTextBoxColumn.DataPropertyName = "Cost"
        Me.CostDataGridViewTextBoxColumn.HeaderText = "Cost"
        Me.CostDataGridViewTextBoxColumn.Name = "CostDataGridViewTextBoxColumn"
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(112, 26)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(201, 28)
        Me.Label19.TabIndex = 30
        Me.Label19.Text = "Select lines to add to Vendor Return by Receiver."
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(112, 58)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(201, 31)
        Me.Label20.TabIndex = 31
        Me.Label20.Text = "Change quantities for Return in grid if necessary, then SAVE."
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdSelectLinesFromReceiver)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Location = New System.Drawing.Point(365, 511)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(329, 99)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Lines"
        '
        'gpxPostReturn
        '
        Me.gpxPostReturn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxPostReturn.Controls.Add(Me.cmdPostReturn)
        Me.gpxPostReturn.Controls.Add(Me.chkApplyAgainst)
        Me.gpxPostReturn.Controls.Add(Me.Label21)
        Me.gpxPostReturn.Location = New System.Drawing.Point(814, 519)
        Me.gpxPostReturn.Name = "gpxPostReturn"
        Me.gpxPostReturn.Size = New System.Drawing.Size(304, 99)
        Me.gpxPostReturn.TabIndex = 21
        Me.gpxPostReturn.TabStop = False
        Me.gpxPostReturn.Text = "Post Return"
        '
        'cmdPostReturn
        '
        Me.cmdPostReturn.ForeColor = System.Drawing.Color.Blue
        Me.cmdPostReturn.Location = New System.Drawing.Point(212, 49)
        Me.cmdPostReturn.Name = "cmdPostReturn"
        Me.cmdPostReturn.Size = New System.Drawing.Size(71, 40)
        Me.cmdPostReturn.TabIndex = 21
        Me.cmdPostReturn.Text = "Post Return"
        Me.cmdPostReturn.UseVisualStyleBackColor = True
        '
        'chkApplyAgainst
        '
        Me.chkApplyAgainst.AutoSize = True
        Me.chkApplyAgainst.Location = New System.Drawing.Point(19, 69)
        Me.chkApplyAgainst.Name = "chkApplyAgainst"
        Me.chkApplyAgainst.Size = New System.Drawing.Size(154, 17)
        Me.chkApplyAgainst.TabIndex = 36
        Me.chkApplyAgainst.Text = "Close Receiver and Return"
        Me.chkApplyAgainst.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Blue
        Me.Label21.Location = New System.Drawing.Point(16, 26)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(267, 40)
        Me.Label21.TabIndex = 35
        Me.Label21.Text = "Post Return to correct inventory. No changes may be made to return after posting." & _
            ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.cboDeleteLineNumber)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.cmdDeleteLine)
        Me.GroupBox2.Location = New System.Drawing.Point(365, 624)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(329, 136)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Delete Line"
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Blue
        Me.Label24.Location = New System.Drawing.Point(17, 75)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(219, 40)
        Me.Label24.TabIndex = 36
        Me.Label24.Text = "Select Return Line from datagrid or combobox to delete."
        '
        'cboDeleteLineNumber
        '
        Me.cboDeleteLineNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDeleteLineNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDeleteLineNumber.DataSource = Me.VendorReturnLineBindingSource
        Me.cboDeleteLineNumber.DisplayMember = "ReturnLineNumber"
        Me.cboDeleteLineNumber.FormattingEnabled = True
        Me.cboDeleteLineNumber.Location = New System.Drawing.Point(149, 30)
        Me.cboDeleteLineNumber.Name = "cboDeleteLineNumber"
        Me.cboDeleteLineNumber.Size = New System.Drawing.Size(164, 21)
        Me.cboDeleteLineNumber.TabIndex = 19
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(17, 31)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(126, 20)
        Me.Label23.TabIndex = 22
        Me.Label23.Text = "Return Line Number"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.ForeColor = System.Drawing.Color.Blue
        Me.cmdDeleteLine.Location = New System.Drawing.Point(242, 73)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteLine.TabIndex = 20
        Me.cmdDeleteLine.Text = "Delete Line"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Blue
        Me.Label25.Location = New System.Drawing.Point(45, 420)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(281, 40)
        Me.Label25.TabIndex = 37
        Me.Label25.Text = "Enter quantities as a positive number, unless it is a charge against the Customer" & _
            "."
        '
        'dgvSerialLines
        '
        Me.dgvSerialLines.AllowUserToAddRows = False
        Me.dgvSerialLines.AllowUserToDeleteRows = False
        Me.dgvSerialLines.AutoGenerateColumns = False
        Me.dgvSerialLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSerialLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AssemblyPartNumber2Column, Me.SerialNumber2Column, Me.DivisionID2Column, Me.TotalCost2Column, Me.Comment2Column, Me.BuildDate2Column, Me.Status2Column, Me.BuildNumber2Column, Me.CustomerID2Column, Me.BatchNumber2Column, Me.TransactionNumber2Column})
        Me.dgvSerialLines.DataSource = Me.AssemblySerialTempTableBindingSource
        Me.dgvSerialLines.Location = New System.Drawing.Point(688, 41)
        Me.dgvSerialLines.Name = "dgvSerialLines"
        Me.dgvSerialLines.ReadOnly = True
        Me.dgvSerialLines.Size = New System.Drawing.Size(187, 143)
        Me.dgvSerialLines.TabIndex = 38
        Me.dgvSerialLines.Visible = False
        '
        'AssemblyPartNumber2Column
        '
        Me.AssemblyPartNumber2Column.DataPropertyName = "AssemblyPartNumber"
        Me.AssemblyPartNumber2Column.HeaderText = "AssemblyPartNumber"
        Me.AssemblyPartNumber2Column.Name = "AssemblyPartNumber2Column"
        Me.AssemblyPartNumber2Column.ReadOnly = True
        '
        'SerialNumber2Column
        '
        Me.SerialNumber2Column.DataPropertyName = "SerialNumber"
        Me.SerialNumber2Column.HeaderText = "SerialNumber"
        Me.SerialNumber2Column.Name = "SerialNumber2Column"
        Me.SerialNumber2Column.ReadOnly = True
        '
        'DivisionID2Column
        '
        Me.DivisionID2Column.DataPropertyName = "DivisionID"
        Me.DivisionID2Column.HeaderText = "DivisionID"
        Me.DivisionID2Column.Name = "DivisionID2Column"
        Me.DivisionID2Column.ReadOnly = True
        '
        'TotalCost2Column
        '
        Me.TotalCost2Column.DataPropertyName = "TotalCost"
        Me.TotalCost2Column.HeaderText = "TotalCost"
        Me.TotalCost2Column.Name = "TotalCost2Column"
        Me.TotalCost2Column.ReadOnly = True
        '
        'Comment2Column
        '
        Me.Comment2Column.DataPropertyName = "Comment"
        Me.Comment2Column.HeaderText = "Comment"
        Me.Comment2Column.Name = "Comment2Column"
        Me.Comment2Column.ReadOnly = True
        '
        'BuildDate2Column
        '
        Me.BuildDate2Column.DataPropertyName = "BuildDate"
        Me.BuildDate2Column.HeaderText = "BuildDate"
        Me.BuildDate2Column.Name = "BuildDate2Column"
        Me.BuildDate2Column.ReadOnly = True
        '
        'Status2Column
        '
        Me.Status2Column.DataPropertyName = "Status"
        Me.Status2Column.HeaderText = "Status"
        Me.Status2Column.Name = "Status2Column"
        Me.Status2Column.ReadOnly = True
        '
        'BuildNumber2Column
        '
        Me.BuildNumber2Column.DataPropertyName = "BuildNumber"
        Me.BuildNumber2Column.HeaderText = "BuildNumber"
        Me.BuildNumber2Column.Name = "BuildNumber2Column"
        Me.BuildNumber2Column.ReadOnly = True
        '
        'CustomerID2Column
        '
        Me.CustomerID2Column.DataPropertyName = "CustomerID"
        Me.CustomerID2Column.HeaderText = "CustomerID"
        Me.CustomerID2Column.Name = "CustomerID2Column"
        Me.CustomerID2Column.ReadOnly = True
        '
        'BatchNumber2Column
        '
        Me.BatchNumber2Column.DataPropertyName = "BatchNumber"
        Me.BatchNumber2Column.HeaderText = "BatchNumber"
        Me.BatchNumber2Column.Name = "BatchNumber2Column"
        Me.BatchNumber2Column.ReadOnly = True
        '
        'TransactionNumber2Column
        '
        Me.TransactionNumber2Column.DataPropertyName = "TransactionNumber"
        Me.TransactionNumber2Column.HeaderText = "TransactionNumber"
        Me.TransactionNumber2Column.Name = "TransactionNumber2Column"
        Me.TransactionNumber2Column.ReadOnly = True
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
        'VendorReturnForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gpxPostReturn)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvReturnLines)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.tabPartNumberInfo)
        Me.Controls.Add(Me.gpxReturnTotals)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.gpxPOHeaderData)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvSerialLines)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "VendorReturnForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Vendor Returns"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxPOHeaderData.ResumeLayout(False)
        Me.gpxPOHeaderData.PerformLayout()
        CType(Me.VendorReturnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxReturnTotals.ResumeLayout(False)
        Me.gpxReturnTotals.PerformLayout()
        CType(Me.PurchaseOrderLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReturnLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorReturnLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPartNumberInfo.ResumeLayout(False)
        Me.tabItemEntry.ResumeLayout(False)
        Me.tabItemEntry.PerformLayout()
        Me.tabItemGLInfo.ResumeLayout(False)
        Me.tabItemGLInfo.PerformLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.gpxPostReturn.ResumeLayout(False)
        Me.gpxPostReturn.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvSerialLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssemblySerialTempTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents gpxPOHeaderData As System.Windows.Forms.GroupBox
    Friend WithEvents cboReturnNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdGenerateReturnNumber As System.Windows.Forms.Button
    Friend WithEvents cboPurchaseOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents dtpReturnDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboVendorCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPONumber As System.Windows.Forms.Label
    Friend WithEvents lblPaymentTerms As System.Windows.Forms.Label
    Friend WithEvents lblPODate As System.Windows.Forms.Label
    Friend WithEvents lblVendorName As System.Windows.Forms.Label
    Friend WithEvents txtLongDescription As System.Windows.Forms.TextBox
    Friend WithEvents chkInventoryItem As System.Windows.Forms.CheckBox
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents txtOrderQuantity As System.Windows.Forms.TextBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents txtExtendedAmount As System.Windows.Forms.TextBox
    Friend WithEvents gpxReturnTotals As System.Windows.Forms.GroupBox
    Friend WithEvents txtReturnTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFreight As System.Windows.Forms.TextBox
    Friend WithEvents txtSalesTax As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtProductTotal As System.Windows.Forms.TextBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents VendorReturnBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorReturnTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorReturnTableAdapter
    Friend WithEvents PurchaseOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cmdSelectLinesFromReceiver As System.Windows.Forms.Button
    Friend WithEvents PurchaseOrderLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderLineTableTableAdapter
    Friend WithEvents VendorReturnLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorReturnLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorReturnLineTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents tabPartNumberInfo As System.Windows.Forms.TabControl
    Friend WithEvents tabItemEntry As System.Windows.Forms.TabPage
    Friend WithEvents tabItemGLInfo As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents txtGLSales As System.Windows.Forms.TextBox
    Friend WithEvents txtItemClassDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtGLPurchases As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtGLCOGS As System.Windows.Forms.TextBox
    Friend WithEvents txtGLInventory As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtGLReturns As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents dgvReturnLines As System.Windows.Forms.DataGridView
    Friend WithEvents ReturnNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnLineNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ClearDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gpxPostReturn As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmdPostReturn As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtReturnStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cboDeleteLineNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents chkApplyAgainst As System.Windows.Forms.CheckBox
    Friend WithEvents ReturnNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiverNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiverLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ManuallyCloseReturnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnLockReturnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents dgvSerialLines As System.Windows.Forms.DataGridView
    Friend WithEvents AssemblySerialTempTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AssemblySerialTempTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblySerialTempTableTableAdapter
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
    Friend WithEvents REOpenVendorReturnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
