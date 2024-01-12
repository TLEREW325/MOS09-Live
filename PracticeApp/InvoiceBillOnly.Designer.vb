<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InvoiceBillOnly
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvoiceBillOnly))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnLockInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxInvoiceHeaderInfo = New System.Windows.Forms.GroupBox
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.cboCustomerClass = New System.Windows.Forms.ComboBox
        Me.CustomerClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker
        Me.cboInvoiceNumber = New System.Windows.Forms.ComboBox
        Me.InvoiceHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label56 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdGenerateNewInvoiceNumber = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboConsignmentWarehouse = New System.Windows.Forms.ComboBox
        Me.FOBTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabCustomerDetails = New System.Windows.Forms.TabPage
        Me.cboShipMethod = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label55 = New System.Windows.Forms.Label
        Me.txtSpecialInstructions = New System.Windows.Forms.TextBox
        Me.cboShipVia = New System.Windows.Forms.ComboBox
        Me.ShipMethodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.cboPaymentTerms = New System.Windows.Forms.ComboBox
        Me.txtBilledFreightEdit = New System.Windows.Forms.TextBox
        Me.txtCustomerPONumber = New System.Windows.Forms.TextBox
        Me.dtpShipDate = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtProNumber = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.tabBillingAddress = New System.Windows.Forms.TabPage
        Me.txtThirdParty = New System.Windows.Forms.TextBox
        Me.Label57 = New System.Windows.Forms.Label
        Me.txtBTAddress1 = New System.Windows.Forms.TextBox
        Me.txtBTAddress2 = New System.Windows.Forms.TextBox
        Me.txtBTCity = New System.Windows.Forms.TextBox
        Me.txtBTZip = New System.Windows.Forms.TextBox
        Me.txtBTCountry = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboBTState = New System.Windows.Forms.ComboBox
        Me.StateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.tabAddDiscount = New System.Windows.Forms.TabPage
        Me.Label19 = New System.Windows.Forms.Label
        Me.chkRemoveAllTaxes = New System.Windows.Forms.CheckBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.cmdDeleteDiscount = New System.Windows.Forms.Button
        Me.txtDiscountAmount = New System.Windows.Forms.TextBox
        Me.txtDiscountPercent = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.cmdAddDiscount = New System.Windows.Forms.Button
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.tabLineDetails = New System.Windows.Forms.TabControl
        Me.tabInvoiceLineDetails = New System.Windows.Forms.TabPage
        Me.txtLineSalesTaxRate = New System.Windows.Forms.TextBox
        Me.chkTaxable = New System.Windows.Forms.CheckBox
        Me.cmdAddLine = New System.Windows.Forms.Button
        Me.cmdClearLine = New System.Windows.Forms.Button
        Me.txtLineComment = New System.Windows.Forms.TextBox
        Me.txtExtendedAmount = New System.Windows.Forms.TextBox
        Me.txtLineSalesTax = New System.Windows.Forms.TextBox
        Me.txtPrice = New System.Windows.Forms.TextBox
        Me.txtQuantityBilled = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.tabInvoiceLineOther = New System.Windows.Forms.TabPage
        Me.txtGLPurchasesAccount = New System.Windows.Forms.TextBox
        Me.txtGLCOGSAccount = New System.Windows.Forms.TextBox
        Me.txtGLIssuesAccount = New System.Windows.Forms.TextBox
        Me.txtGLAdjustmentAccount = New System.Windows.Forms.TextBox
        Me.txtGLSalesOffsetAccount = New System.Windows.Forms.TextBox
        Me.txtGLInventoryAccount = New System.Windows.Forms.TextBox
        Me.txtGLReturnsAccount = New System.Windows.Forms.TextBox
        Me.txtGLSalesAccount = New System.Windows.Forms.TextBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label39 = New System.Windows.Forms.Label
        Me.tabDeleteLine = New System.Windows.Forms.TabPage
        Me.Label53 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.cboInvoiceLineNumber = New System.Windows.Forms.ComboBox
        Me.InvoiceLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdSaveLineChanges = New System.Windows.Forms.Button
        Me.cmdDeleteInvoiceLine = New System.Windows.Forms.Button
        Me.txtLineComment2 = New System.Windows.Forms.TextBox
        Me.txtLineExtendedAmount = New System.Windows.Forms.TextBox
        Me.txtLineSalesTax2 = New System.Windows.Forms.TextBox
        Me.txtLinePrice = New System.Windows.Forms.TextBox
        Me.txtLineQuantityBilled = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.cboLinePartDescription = New System.Windows.Forms.ComboBox
        Me.cboLinePartNumber = New System.Windows.Forms.ComboBox
        Me.Label50 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdRemoveSalesTax = New System.Windows.Forms.Button
        Me.txtHSTRate = New System.Windows.Forms.TextBox
        Me.chkAddPST = New System.Windows.Forms.CheckBox
        Me.chkAddHST = New System.Windows.Forms.CheckBox
        Me.txtSalesTax2 = New System.Windows.Forms.TextBox
        Me.LabelPST = New System.Windows.Forms.Label
        Me.txtSalesTax3 = New System.Windows.Forms.TextBox
        Me.LabelHST = New System.Windows.Forms.Label
        Me.txtInvoiceTotal = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtSalesTax = New System.Windows.Forms.TextBox
        Me.LabelSalesTax = New System.Windows.Forms.Label
        Me.txtDiscount = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtFreightBilled = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtProductSales = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvInvoiceLines = New System.Windows.Forms.DataGridView
        Me.InvoiceHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityBilledColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineBoxesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCOSColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdPostInvoice = New System.Windows.Forms.Button
        Me.txtBatchNumber = New System.Windows.Forms.TextBox
        Me.InvoiceLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceLineTableTableAdapter
        Me.CustomerClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerClassTableAdapter
        Me.InvoiceHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.ShipMethodTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
        Me.StateTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label54 = New System.Windows.Forms.Label
        Me.FOBTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOBTableTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxInvoiceHeaderInfo.SuspendLayout()
        CType(Me.CustomerClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FOBTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tabCustomerDetails.SuspendLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBillingAddress.SuspendLayout()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAddDiscount.SuspendLayout()
        Me.tabLineDetails.SuspendLayout()
        Me.tabInvoiceLineDetails.SuspendLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabInvoiceLineOther.SuspendLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDeleteLine.SuspendLayout()
        CType(Me.InvoiceLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvInvoiceLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveInvoiceToolStripMenuItem, Me.DeleteInvoiceToolStripMenuItem, Me.ClearInvoiceToolStripMenuItem, Me.PrintInvoiceToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveInvoiceToolStripMenuItem
        '
        Me.SaveInvoiceToolStripMenuItem.Name = "SaveInvoiceToolStripMenuItem"
        Me.SaveInvoiceToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.SaveInvoiceToolStripMenuItem.Text = "Save Invoice"
        '
        'DeleteInvoiceToolStripMenuItem
        '
        Me.DeleteInvoiceToolStripMenuItem.Name = "DeleteInvoiceToolStripMenuItem"
        Me.DeleteInvoiceToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.DeleteInvoiceToolStripMenuItem.Text = "Delete Invoice"
        '
        'ClearInvoiceToolStripMenuItem
        '
        Me.ClearInvoiceToolStripMenuItem.Name = "ClearInvoiceToolStripMenuItem"
        Me.ClearInvoiceToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.ClearInvoiceToolStripMenuItem.Text = "Clear Invoice"
        '
        'PrintInvoiceToolStripMenuItem
        '
        Me.PrintInvoiceToolStripMenuItem.Name = "PrintInvoiceToolStripMenuItem"
        Me.PrintInvoiceToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.PrintInvoiceToolStripMenuItem.Text = "Print Invoice"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UnLockInvoiceToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'UnLockInvoiceToolStripMenuItem
        '
        Me.UnLockInvoiceToolStripMenuItem.Name = "UnLockInvoiceToolStripMenuItem"
        Me.UnLockInvoiceToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.UnLockInvoiceToolStripMenuItem.Text = "Un-Lock Invoice"
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
        'gpxInvoiceHeaderInfo
        '
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.txtStatus)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.cboCustomerClass)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.cboDivisionID)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.dtpInvoiceDate)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.cboInvoiceNumber)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.Label56)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.Label6)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.cmdGenerateNewInvoiceNumber)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.Label12)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.Label4)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.Label5)
        Me.gpxInvoiceHeaderInfo.Location = New System.Drawing.Point(29, 44)
        Me.gpxInvoiceHeaderInfo.Name = "gpxInvoiceHeaderInfo"
        Me.gpxInvoiceHeaderInfo.Size = New System.Drawing.Size(309, 176)
        Me.gpxInvoiceHeaderInfo.TabIndex = 0
        Me.gpxInvoiceHeaderInfo.TabStop = False
        Me.gpxInvoiceHeaderInfo.Text = "Invoice Information"
        '
        'txtStatus
        '
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStatus.Enabled = False
        Me.txtStatus.Location = New System.Drawing.Point(114, 142)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(178, 20)
        Me.txtStatus.TabIndex = 5
        Me.txtStatus.TabStop = False
        Me.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboCustomerClass
        '
        Me.cboCustomerClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerClass.DataSource = Me.CustomerClassBindingSource
        Me.cboCustomerClass.DisplayMember = "CustomerClassID"
        Me.cboCustomerClass.Enabled = False
        Me.cboCustomerClass.FormattingEnabled = True
        Me.cboCustomerClass.Location = New System.Drawing.Point(114, 111)
        Me.cboCustomerClass.Name = "cboCustomerClass"
        Me.cboCustomerClass.Size = New System.Drawing.Size(178, 21)
        Me.cboCustomerClass.TabIndex = 4
        Me.cboCustomerClass.ValueMember = "ItemID"
        '
        'CustomerClassBindingSource
        '
        Me.CustomerClassBindingSource.DataMember = "CustomerClass"
        Me.CustomerClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
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
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(114, 80)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(178, 21)
        Me.cboDivisionID.TabIndex = 3
        Me.cboDivisionID.ValueMember = "ItemID"
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpInvoiceDate
        '
        Me.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(114, 50)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(178, 20)
        Me.dtpInvoiceDate.TabIndex = 2
        '
        'cboInvoiceNumber
        '
        Me.cboInvoiceNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInvoiceNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInvoiceNumber.DataSource = Me.InvoiceHeaderTableBindingSource
        Me.cboInvoiceNumber.DisplayMember = "InvoiceNumber"
        Me.cboInvoiceNumber.FormattingEnabled = True
        Me.cboInvoiceNumber.Location = New System.Drawing.Point(114, 19)
        Me.cboInvoiceNumber.Name = "cboInvoiceNumber"
        Me.cboInvoiceNumber.Size = New System.Drawing.Size(178, 21)
        Me.cboInvoiceNumber.TabIndex = 1
        Me.cboInvoiceNumber.ValueMember = "ItemID"
        '
        'InvoiceHeaderTableBindingSource
        '
        Me.InvoiceHeaderTableBindingSource.DataMember = "InvoiceHeaderTable"
        Me.InvoiceHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label56
        '
        Me.Label56.Location = New System.Drawing.Point(18, 111)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(105, 21)
        Me.Label56.TabIndex = 83
        Me.Label56.Text = "Customer Class"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(18, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 21)
        Me.Label6.TabIndex = 85
        Me.Label6.Text = "Status"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdGenerateNewInvoiceNumber
        '
        Me.cmdGenerateNewInvoiceNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateNewInvoiceNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateNewInvoiceNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateNewInvoiceNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateNewInvoiceNumber.Location = New System.Drawing.Point(83, 19)
        Me.cmdGenerateNewInvoiceNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateNewInvoiceNumber.Name = "cmdGenerateNewInvoiceNumber"
        Me.cmdGenerateNewInvoiceNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateNewInvoiceNumber.TabIndex = 0
        Me.cmdGenerateNewInvoiceNumber.TabStop = False
        Me.cmdGenerateNewInvoiceNumber.Text = ">>"
        Me.cmdGenerateNewInvoiceNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateNewInvoiceNumber.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(18, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(105, 21)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Division ID"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 21)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Invoice Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(18, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 21)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Invoice #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(14, 529)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 21)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "FOB"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboConsignmentWarehouse
        '
        Me.cboConsignmentWarehouse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboConsignmentWarehouse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboConsignmentWarehouse.DataSource = Me.FOBTableBindingSource
        Me.cboConsignmentWarehouse.DisplayMember = "FOBID"
        Me.cboConsignmentWarehouse.FormattingEnabled = True
        Me.cboConsignmentWarehouse.Location = New System.Drawing.Point(122, 527)
        Me.cboConsignmentWarehouse.Name = "cboConsignmentWarehouse"
        Me.cboConsignmentWarehouse.Size = New System.Drawing.Size(166, 21)
        Me.cboConsignmentWarehouse.TabIndex = 4
        Me.cboConsignmentWarehouse.ValueMember = "ItemID"
        '
        'FOBTableBindingSource
        '
        Me.FOBTableBindingSource.DataMember = "FOBTable"
        Me.FOBTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabCustomerDetails)
        Me.TabControl1.Controls.Add(Me.tabBillingAddress)
        Me.TabControl1.Controls.Add(Me.tabAddDiscount)
        Me.TabControl1.Location = New System.Drawing.Point(29, 223)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(309, 588)
        Me.TabControl1.TabIndex = 6
        '
        'tabCustomerDetails
        '
        Me.tabCustomerDetails.Controls.Add(Me.cboShipMethod)
        Me.tabCustomerDetails.Controls.Add(Me.Label22)
        Me.tabCustomerDetails.Controls.Add(Me.Label55)
        Me.tabCustomerDetails.Controls.Add(Me.txtSpecialInstructions)
        Me.tabCustomerDetails.Controls.Add(Me.cboShipVia)
        Me.tabCustomerDetails.Controls.Add(Me.cboCustomerID)
        Me.tabCustomerDetails.Controls.Add(Me.cboCustomerName)
        Me.tabCustomerDetails.Controls.Add(Me.Label3)
        Me.tabCustomerDetails.Controls.Add(Me.txtComment)
        Me.tabCustomerDetails.Controls.Add(Me.cboPaymentTerms)
        Me.tabCustomerDetails.Controls.Add(Me.txtBilledFreightEdit)
        Me.tabCustomerDetails.Controls.Add(Me.txtCustomerPONumber)
        Me.tabCustomerDetails.Controls.Add(Me.dtpShipDate)
        Me.tabCustomerDetails.Controls.Add(Me.Label7)
        Me.tabCustomerDetails.Controls.Add(Me.txtProNumber)
        Me.tabCustomerDetails.Controls.Add(Me.Label25)
        Me.tabCustomerDetails.Controls.Add(Me.Label26)
        Me.tabCustomerDetails.Controls.Add(Me.Label2)
        Me.tabCustomerDetails.Controls.Add(Me.Label24)
        Me.tabCustomerDetails.Controls.Add(Me.Label23)
        Me.tabCustomerDetails.Controls.Add(Me.Label21)
        Me.tabCustomerDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabCustomerDetails.Name = "tabCustomerDetails"
        Me.tabCustomerDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCustomerDetails.Size = New System.Drawing.Size(301, 562)
        Me.tabCustomerDetails.TabIndex = 0
        Me.tabCustomerDetails.Text = "Order Details"
        Me.tabCustomerDetails.UseVisualStyleBackColor = True
        '
        'cboShipMethod
        '
        Me.cboShipMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipMethod.FormattingEnabled = True
        Me.cboShipMethod.Items.AddRange(New Object() {"COLLECT", "PREPAID", "PREPAID/ADD", "PREPAID/NOADD", "THIRD PARTY", "OTHER"})
        Me.cboShipMethod.Location = New System.Drawing.Point(106, 245)
        Me.cboShipMethod.MaxLength = 50
        Me.cboShipMethod.Name = "cboShipMethod"
        Me.cboShipMethod.Size = New System.Drawing.Size(181, 21)
        Me.cboShipMethod.TabIndex = 13
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(17, 245)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(110, 21)
        Me.Label22.TabIndex = 89
        Me.Label22.Text = "Ship Method"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label55
        '
        Me.Label55.Location = New System.Drawing.Point(14, 420)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(270, 21)
        Me.Label55.TabIndex = 87
        Me.Label55.Text = "Special Instructions (Prints on Invoice)"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSpecialInstructions
        '
        Me.txtSpecialInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSpecialInstructions.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSpecialInstructions.Location = New System.Drawing.Point(17, 444)
        Me.txtSpecialInstructions.MaxLength = 200
        Me.txtSpecialInstructions.Multiline = True
        Me.txtSpecialInstructions.Name = "txtSpecialInstructions"
        Me.txtSpecialInstructions.Size = New System.Drawing.Size(270, 102)
        Me.txtSpecialInstructions.TabIndex = 16
        Me.txtSpecialInstructions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboShipVia
        '
        Me.cboShipVia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipVia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipVia.DataSource = Me.ShipMethodBindingSource
        Me.cboShipVia.DisplayMember = "ShipMethID"
        Me.cboShipVia.FormattingEnabled = True
        Me.cboShipVia.Location = New System.Drawing.Point(106, 212)
        Me.cboShipVia.MaxLength = 50
        Me.cboShipVia.Name = "cboShipVia"
        Me.cboShipVia.Size = New System.Drawing.Size(181, 21)
        Me.cboShipVia.TabIndex = 12
        '
        'ShipMethodBindingSource
        '
        Me.ShipMethodBindingSource.DataMember = "ShipMethod"
        Me.ShipMethodBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.DropDownWidth = 250
        Me.cboCustomerID.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(74, 20)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(214, 21)
        Me.cboCustomerID.TabIndex = 6
        Me.cboCustomerID.ValueMember = "ItemID"
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.DropDownWidth = 300
        Me.cboCustomerName.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(17, 47)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(271, 21)
        Me.cboCustomerName.TabIndex = 7
        Me.cboCustomerName.ValueMember = "ItemID"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 321)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(270, 21)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "Comment (Does not print on Invoice)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComment
        '
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(17, 345)
        Me.txtComment.MaxLength = 200
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(270, 70)
        Me.txtComment.TabIndex = 15
        Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboPaymentTerms
        '
        Me.cboPaymentTerms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPaymentTerms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentTerms.DisplayMember = "ItemID"
        Me.cboPaymentTerms.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboPaymentTerms.FormattingEnabled = True
        Me.cboPaymentTerms.Items.AddRange(New Object() {"N30", "COD", "CREDIT CARD", "Prepaid", "NetDue"})
        Me.cboPaymentTerms.Location = New System.Drawing.Point(106, 115)
        Me.cboPaymentTerms.MaxLength = 50
        Me.cboPaymentTerms.Name = "cboPaymentTerms"
        Me.cboPaymentTerms.Size = New System.Drawing.Size(181, 21)
        Me.cboPaymentTerms.TabIndex = 9
        Me.cboPaymentTerms.ValueMember = "ItemID"
        '
        'txtBilledFreightEdit
        '
        Me.txtBilledFreightEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBilledFreightEdit.Location = New System.Drawing.Point(144, 278)
        Me.txtBilledFreightEdit.Name = "txtBilledFreightEdit"
        Me.txtBilledFreightEdit.Size = New System.Drawing.Size(143, 20)
        Me.txtBilledFreightEdit.TabIndex = 14
        Me.txtBilledFreightEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCustomerPONumber
        '
        Me.txtCustomerPONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPONumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerPONumber.Location = New System.Drawing.Point(106, 83)
        Me.txtCustomerPONumber.Name = "txtCustomerPONumber"
        Me.txtCustomerPONumber.Size = New System.Drawing.Size(181, 20)
        Me.txtCustomerPONumber.TabIndex = 8
        Me.txtCustomerPONumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpShipDate
        '
        Me.dtpShipDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpShipDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpShipDate.Location = New System.Drawing.Point(106, 148)
        Me.dtpShipDate.Name = "dtpShipDate"
        Me.dtpShipDate.Size = New System.Drawing.Size(181, 20)
        Me.dtpShipDate.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(14, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 21)
        Me.Label7.TabIndex = 69
        Me.Label7.Text = "Customer"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProNumber
        '
        Me.txtProNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProNumber.Location = New System.Drawing.Point(106, 180)
        Me.txtProNumber.Name = "txtProNumber"
        Me.txtProNumber.Size = New System.Drawing.Size(181, 20)
        Me.txtProNumber.TabIndex = 11
        Me.txtProNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(17, 83)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(110, 21)
        Me.Label25.TabIndex = 83
        Me.Label25.Text = "Customer PO#"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(17, 278)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(110, 21)
        Me.Label26.TabIndex = 79
        Me.Label26.Text = "Billed Freight"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 21)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Payment Terms"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(17, 212)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(110, 23)
        Me.Label24.TabIndex = 77
        Me.Label24.Text = "Ship Via"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(17, 147)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(110, 21)
        Me.Label23.TabIndex = 76
        Me.Label23.Text = "Ship Date"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(17, 180)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(110, 21)
        Me.Label21.TabIndex = 74
        Me.Label21.Text = "PRO Number"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabBillingAddress
        '
        Me.tabBillingAddress.Controls.Add(Me.txtThirdParty)
        Me.tabBillingAddress.Controls.Add(Me.Label57)
        Me.tabBillingAddress.Controls.Add(Me.Label1)
        Me.tabBillingAddress.Controls.Add(Me.txtBTAddress1)
        Me.tabBillingAddress.Controls.Add(Me.cboConsignmentWarehouse)
        Me.tabBillingAddress.Controls.Add(Me.txtBTAddress2)
        Me.tabBillingAddress.Controls.Add(Me.txtBTCity)
        Me.tabBillingAddress.Controls.Add(Me.txtBTZip)
        Me.tabBillingAddress.Controls.Add(Me.txtBTCountry)
        Me.tabBillingAddress.Controls.Add(Me.Label10)
        Me.tabBillingAddress.Controls.Add(Me.Label9)
        Me.tabBillingAddress.Controls.Add(Me.cboBTState)
        Me.tabBillingAddress.Controls.Add(Me.Label13)
        Me.tabBillingAddress.Controls.Add(Me.Label15)
        Me.tabBillingAddress.Controls.Add(Me.Label11)
        Me.tabBillingAddress.Controls.Add(Me.Label14)
        Me.tabBillingAddress.Location = New System.Drawing.Point(4, 22)
        Me.tabBillingAddress.Name = "tabBillingAddress"
        Me.tabBillingAddress.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBillingAddress.Size = New System.Drawing.Size(301, 562)
        Me.tabBillingAddress.TabIndex = 1
        Me.tabBillingAddress.Text = "Billing Address"
        Me.tabBillingAddress.UseVisualStyleBackColor = True
        '
        'txtThirdParty
        '
        Me.txtThirdParty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtThirdParty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtThirdParty.Location = New System.Drawing.Point(17, 412)
        Me.txtThirdParty.Multiline = True
        Me.txtThirdParty.Name = "txtThirdParty"
        Me.txtThirdParty.Size = New System.Drawing.Size(270, 96)
        Me.txtThirdParty.TabIndex = 82
        Me.txtThirdParty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label57
        '
        Me.Label57.Location = New System.Drawing.Point(15, 388)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(272, 21)
        Me.Label57.TabIndex = 83
        Me.Label57.Text = "Third Party Freight Billing Info"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBTAddress1
        '
        Me.txtBTAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBTAddress1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBTAddress1.Location = New System.Drawing.Point(18, 42)
        Me.txtBTAddress1.Multiline = True
        Me.txtBTAddress1.Name = "txtBTAddress1"
        Me.txtBTAddress1.Size = New System.Drawing.Size(270, 62)
        Me.txtBTAddress1.TabIndex = 15
        Me.txtBTAddress1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBTAddress2
        '
        Me.txtBTAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBTAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBTAddress2.Location = New System.Drawing.Point(18, 131)
        Me.txtBTAddress2.Multiline = True
        Me.txtBTAddress2.Name = "txtBTAddress2"
        Me.txtBTAddress2.Size = New System.Drawing.Size(270, 73)
        Me.txtBTAddress2.TabIndex = 16
        Me.txtBTAddress2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBTCity
        '
        Me.txtBTCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBTCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBTCity.Location = New System.Drawing.Point(79, 236)
        Me.txtBTCity.Name = "txtBTCity"
        Me.txtBTCity.Size = New System.Drawing.Size(205, 20)
        Me.txtBTCity.TabIndex = 17
        Me.txtBTCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBTZip
        '
        Me.txtBTZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBTZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBTZip.Location = New System.Drawing.Point(79, 305)
        Me.txtBTZip.Name = "txtBTZip"
        Me.txtBTZip.Size = New System.Drawing.Size(119, 20)
        Me.txtBTZip.TabIndex = 19
        Me.txtBTZip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBTCountry
        '
        Me.txtBTCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBTCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBTCountry.Location = New System.Drawing.Point(79, 339)
        Me.txtBTCountry.Name = "txtBTCountry"
        Me.txtBTCountry.Size = New System.Drawing.Size(205, 20)
        Me.txtBTCountry.TabIndex = 20
        Me.txtBTCountry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(18, 107)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 21)
        Me.Label10.TabIndex = 75
        Me.Label10.Text = "Address 2"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(18, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 21)
        Me.Label9.TabIndex = 73
        Me.Label9.Text = "Address 1"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBTState
        '
        Me.cboBTState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBTState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBTState.DataSource = Me.StateTableBindingSource
        Me.cboBTState.DisplayMember = "StateCode"
        Me.cboBTState.FormattingEnabled = True
        Me.cboBTState.Location = New System.Drawing.Point(79, 270)
        Me.cboBTState.Name = "cboBTState"
        Me.cboBTState.Size = New System.Drawing.Size(119, 21)
        Me.cboBTState.TabIndex = 18
        Me.cboBTState.ValueMember = "ItemID"
        '
        'StateTableBindingSource
        '
        Me.StateTableBindingSource.DataMember = "StateTable"
        Me.StateTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(18, 236)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 21)
        Me.Label13.TabIndex = 77
        Me.Label13.Text = "City"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(18, 338)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(66, 21)
        Me.Label15.TabIndex = 81
        Me.Label15.Text = "Country"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(18, 270)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 21)
        Me.Label11.TabIndex = 79
        Me.Label11.Text = "State"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(18, 305)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(26, 21)
        Me.Label14.TabIndex = 78
        Me.Label14.Text = "ZIP"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabAddDiscount
        '
        Me.tabAddDiscount.Controls.Add(Me.Label19)
        Me.tabAddDiscount.Controls.Add(Me.chkRemoveAllTaxes)
        Me.tabAddDiscount.Controls.Add(Me.Label45)
        Me.tabAddDiscount.Controls.Add(Me.cmdDeleteDiscount)
        Me.tabAddDiscount.Controls.Add(Me.txtDiscountAmount)
        Me.tabAddDiscount.Controls.Add(Me.txtDiscountPercent)
        Me.tabAddDiscount.Controls.Add(Me.Label28)
        Me.tabAddDiscount.Controls.Add(Me.Label27)
        Me.tabAddDiscount.Controls.Add(Me.cmdAddDiscount)
        Me.tabAddDiscount.Location = New System.Drawing.Point(4, 22)
        Me.tabAddDiscount.Name = "tabAddDiscount"
        Me.tabAddDiscount.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAddDiscount.Size = New System.Drawing.Size(301, 562)
        Me.tabAddDiscount.TabIndex = 2
        Me.tabAddDiscount.Text = "Add Discount"
        Me.tabAddDiscount.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(21, 405)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(253, 45)
        Me.Label19.TabIndex = 87
        Me.Label19.Text = "To remove all applicable taxes, select this box and it will not recalculate Taxes" & _
            " on Save or Post."
        '
        'chkRemoveAllTaxes
        '
        Me.chkRemoveAllTaxes.AutoSize = True
        Me.chkRemoveAllTaxes.Location = New System.Drawing.Point(24, 375)
        Me.chkRemoveAllTaxes.Name = "chkRemoveAllTaxes"
        Me.chkRemoveAllTaxes.Size = New System.Drawing.Size(112, 17)
        Me.chkRemoveAllTaxes.TabIndex = 86
        Me.chkRemoveAllTaxes.Text = "Remove All Taxes"
        Me.chkRemoveAllTaxes.UseVisualStyleBackColor = True
        '
        'Label45
        '
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.Blue
        Me.Label45.Location = New System.Drawing.Point(21, 24)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(253, 116)
        Me.Label45.TabIndex = 85
        Me.Label45.Text = resources.GetString("Label45.Text")
        '
        'cmdDeleteDiscount
        '
        Me.cmdDeleteDiscount.Location = New System.Drawing.Point(203, 212)
        Me.cmdDeleteDiscount.Name = "cmdDeleteDiscount"
        Me.cmdDeleteDiscount.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteDiscount.TabIndex = 24
        Me.cmdDeleteDiscount.Text = "Delete Discount"
        Me.cmdDeleteDiscount.UseVisualStyleBackColor = True
        '
        'txtDiscountAmount
        '
        Me.txtDiscountAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscountAmount.Location = New System.Drawing.Point(126, 143)
        Me.txtDiscountAmount.Name = "txtDiscountAmount"
        Me.txtDiscountAmount.Size = New System.Drawing.Size(148, 20)
        Me.txtDiscountAmount.TabIndex = 21
        Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiscountPercent
        '
        Me.txtDiscountPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscountPercent.Location = New System.Drawing.Point(126, 169)
        Me.txtDiscountPercent.Name = "txtDiscountPercent"
        Me.txtDiscountPercent.Size = New System.Drawing.Size(148, 20)
        Me.txtDiscountPercent.TabIndex = 22
        Me.txtDiscountPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(18, 142)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(101, 21)
        Me.Label28.TabIndex = 83
        Me.Label28.Text = "Discount Rate ($)"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(18, 169)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(101, 21)
        Me.Label27.TabIndex = 80
        Me.Label27.Text = "Discount Rate (%)"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAddDiscount
        '
        Me.cmdAddDiscount.Location = New System.Drawing.Point(126, 212)
        Me.cmdAddDiscount.Name = "cmdAddDiscount"
        Me.cmdAddDiscount.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddDiscount.TabIndex = 23
        Me.cmdAddDiscount.Text = "Add Discount"
        Me.cmdAddDiscount.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(743, 773)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 17
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'tabLineDetails
        '
        Me.tabLineDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabLineDetails.Controls.Add(Me.tabInvoiceLineDetails)
        Me.tabLineDetails.Controls.Add(Me.tabInvoiceLineOther)
        Me.tabLineDetails.Controls.Add(Me.tabDeleteLine)
        Me.tabLineDetails.Location = New System.Drawing.Point(353, 457)
        Me.tabLineDetails.Name = "tabLineDetails"
        Me.tabLineDetails.SelectedIndex = 0
        Me.tabLineDetails.Size = New System.Drawing.Size(372, 356)
        Me.tabLineDetails.TabIndex = 17
        Me.tabLineDetails.TabStop = False
        '
        'tabInvoiceLineDetails
        '
        Me.tabInvoiceLineDetails.Controls.Add(Me.txtLineSalesTaxRate)
        Me.tabInvoiceLineDetails.Controls.Add(Me.chkTaxable)
        Me.tabInvoiceLineDetails.Controls.Add(Me.cmdAddLine)
        Me.tabInvoiceLineDetails.Controls.Add(Me.cmdClearLine)
        Me.tabInvoiceLineDetails.Controls.Add(Me.txtLineComment)
        Me.tabInvoiceLineDetails.Controls.Add(Me.txtExtendedAmount)
        Me.tabInvoiceLineDetails.Controls.Add(Me.txtLineSalesTax)
        Me.tabInvoiceLineDetails.Controls.Add(Me.txtPrice)
        Me.tabInvoiceLineDetails.Controls.Add(Me.txtQuantityBilled)
        Me.tabInvoiceLineDetails.Controls.Add(Me.Label8)
        Me.tabInvoiceLineDetails.Controls.Add(Me.Label29)
        Me.tabInvoiceLineDetails.Controls.Add(Me.Label30)
        Me.tabInvoiceLineDetails.Controls.Add(Me.Label33)
        Me.tabInvoiceLineDetails.Controls.Add(Me.Label34)
        Me.tabInvoiceLineDetails.Controls.Add(Me.cboPartDescription)
        Me.tabInvoiceLineDetails.Controls.Add(Me.cboPartNumber)
        Me.tabInvoiceLineDetails.Controls.Add(Me.Label35)
        Me.tabInvoiceLineDetails.Controls.Add(Me.Label32)
        Me.tabInvoiceLineDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabInvoiceLineDetails.Name = "tabInvoiceLineDetails"
        Me.tabInvoiceLineDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabInvoiceLineDetails.Size = New System.Drawing.Size(364, 330)
        Me.tabInvoiceLineDetails.TabIndex = 0
        Me.tabInvoiceLineDetails.Text = "Invoice Line Details"
        Me.tabInvoiceLineDetails.UseVisualStyleBackColor = True
        '
        'txtLineSalesTaxRate
        '
        Me.txtLineSalesTaxRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineSalesTaxRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineSalesTaxRate.Location = New System.Drawing.Point(115, 133)
        Me.txtLineSalesTaxRate.Name = "txtLineSalesTaxRate"
        Me.txtLineSalesTaxRate.Size = New System.Drawing.Size(79, 20)
        Me.txtLineSalesTaxRate.TabIndex = 92
        Me.txtLineSalesTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLineSalesTaxRate.Visible = False
        '
        'chkTaxable
        '
        Me.chkTaxable.AutoSize = True
        Me.chkTaxable.Location = New System.Drawing.Point(74, 137)
        Me.chkTaxable.Name = "chkTaxable"
        Me.chkTaxable.Size = New System.Drawing.Size(15, 14)
        Me.chkTaxable.TabIndex = 21
        Me.chkTaxable.UseVisualStyleBackColor = True
        '
        'cmdAddLine
        '
        Me.cmdAddLine.Location = New System.Drawing.Point(193, 284)
        Me.cmdAddLine.Name = "cmdAddLine"
        Me.cmdAddLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddLine.TabIndex = 25
        Me.cmdAddLine.Text = "Add"
        Me.cmdAddLine.UseVisualStyleBackColor = True
        '
        'cmdClearLine
        '
        Me.cmdClearLine.Location = New System.Drawing.Point(270, 284)
        Me.cmdClearLine.Name = "cmdClearLine"
        Me.cmdClearLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearLine.TabIndex = 26
        Me.cmdClearLine.Text = "Clear"
        Me.cmdClearLine.UseVisualStyleBackColor = True
        '
        'txtLineComment
        '
        Me.txtLineComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineComment.Location = New System.Drawing.Point(29, 220)
        Me.txtLineComment.MaxLength = 500
        Me.txtLineComment.Multiline = True
        Me.txtLineComment.Name = "txtLineComment"
        Me.txtLineComment.Size = New System.Drawing.Size(312, 56)
        Me.txtLineComment.TabIndex = 24
        Me.txtLineComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtExtendedAmount
        '
        Me.txtExtendedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExtendedAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExtendedAmount.Location = New System.Drawing.Point(205, 165)
        Me.txtExtendedAmount.Name = "txtExtendedAmount"
        Me.txtExtendedAmount.Size = New System.Drawing.Size(136, 20)
        Me.txtExtendedAmount.TabIndex = 23
        Me.txtExtendedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLineSalesTax
        '
        Me.txtLineSalesTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineSalesTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineSalesTax.Enabled = False
        Me.txtLineSalesTax.Location = New System.Drawing.Point(205, 133)
        Me.txtLineSalesTax.Name = "txtLineSalesTax"
        Me.txtLineSalesTax.Size = New System.Drawing.Size(136, 20)
        Me.txtLineSalesTax.TabIndex = 22
        Me.txtLineSalesTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrice
        '
        Me.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrice.Location = New System.Drawing.Point(205, 104)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(136, 20)
        Me.txtPrice.TabIndex = 20
        Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuantityBilled
        '
        Me.txtQuantityBilled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantityBilled.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuantityBilled.Location = New System.Drawing.Point(205, 78)
        Me.txtQuantityBilled.Name = "txtQuantityBilled"
        Me.txtQuantityBilled.Size = New System.Drawing.Size(136, 20)
        Me.txtQuantityBilled.TabIndex = 19
        Me.txtQuantityBilled.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(25, 164)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 21)
        Me.Label8.TabIndex = 90
        Me.Label8.Text = "Extended Amount"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(25, 133)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(98, 21)
        Me.Label29.TabIndex = 89
        Me.Label29.Text = "Sales Tax"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(25, 103)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(98, 21)
        Me.Label30.TabIndex = 88
        Me.Label30.Text = "Price"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(25, 77)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(98, 21)
        Me.Label33.TabIndex = 86
        Me.Label33.Text = "Quantity Billed"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(25, 24)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(98, 21)
        Me.Label34.TabIndex = 85
        Me.Label34.Text = "Part Number"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.DropDownWidth = 300
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(129, 51)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(212, 21)
        Me.cboPartDescription.TabIndex = 18
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
        Me.cboPartNumber.DropDownWidth = 300
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(129, 24)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(212, 21)
        Me.cboPartNumber.TabIndex = 17
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(25, 196)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(98, 21)
        Me.Label35.TabIndex = 91
        Me.Label35.Text = "Line Comment"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(25, 51)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(98, 21)
        Me.Label32.TabIndex = 87
        Me.Label32.Text = "Part Description"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabInvoiceLineOther
        '
        Me.tabInvoiceLineOther.Controls.Add(Me.txtGLPurchasesAccount)
        Me.tabInvoiceLineOther.Controls.Add(Me.txtGLCOGSAccount)
        Me.tabInvoiceLineOther.Controls.Add(Me.txtGLIssuesAccount)
        Me.tabInvoiceLineOther.Controls.Add(Me.txtGLAdjustmentAccount)
        Me.tabInvoiceLineOther.Controls.Add(Me.txtGLSalesOffsetAccount)
        Me.tabInvoiceLineOther.Controls.Add(Me.txtGLInventoryAccount)
        Me.tabInvoiceLineOther.Controls.Add(Me.txtGLReturnsAccount)
        Me.tabInvoiceLineOther.Controls.Add(Me.txtGLSalesAccount)
        Me.tabInvoiceLineOther.Controls.Add(Me.Label44)
        Me.tabInvoiceLineOther.Controls.Add(Me.Label36)
        Me.tabInvoiceLineOther.Controls.Add(Me.Label37)
        Me.tabInvoiceLineOther.Controls.Add(Me.Label38)
        Me.tabInvoiceLineOther.Controls.Add(Me.Label40)
        Me.tabInvoiceLineOther.Controls.Add(Me.Label41)
        Me.tabInvoiceLineOther.Controls.Add(Me.Label42)
        Me.tabInvoiceLineOther.Controls.Add(Me.Label43)
        Me.tabInvoiceLineOther.Controls.Add(Me.cboItemClass)
        Me.tabInvoiceLineOther.Controls.Add(Me.Label39)
        Me.tabInvoiceLineOther.Location = New System.Drawing.Point(4, 22)
        Me.tabInvoiceLineOther.Name = "tabInvoiceLineOther"
        Me.tabInvoiceLineOther.Padding = New System.Windows.Forms.Padding(3)
        Me.tabInvoiceLineOther.Size = New System.Drawing.Size(364, 330)
        Me.tabInvoiceLineOther.TabIndex = 1
        Me.tabInvoiceLineOther.Text = "Line Accounts"
        Me.tabInvoiceLineOther.UseVisualStyleBackColor = True
        '
        'txtGLPurchasesAccount
        '
        Me.txtGLPurchasesAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLPurchasesAccount.Location = New System.Drawing.Point(165, 179)
        Me.txtGLPurchasesAccount.Name = "txtGLPurchasesAccount"
        Me.txtGLPurchasesAccount.Size = New System.Drawing.Size(153, 20)
        Me.txtGLPurchasesAccount.TabIndex = 32
        Me.txtGLPurchasesAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGLCOGSAccount
        '
        Me.txtGLCOGSAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLCOGSAccount.Location = New System.Drawing.Point(165, 154)
        Me.txtGLCOGSAccount.Name = "txtGLCOGSAccount"
        Me.txtGLCOGSAccount.Size = New System.Drawing.Size(153, 20)
        Me.txtGLCOGSAccount.TabIndex = 31
        Me.txtGLCOGSAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGLIssuesAccount
        '
        Me.txtGLIssuesAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLIssuesAccount.Location = New System.Drawing.Point(165, 254)
        Me.txtGLIssuesAccount.Name = "txtGLIssuesAccount"
        Me.txtGLIssuesAccount.Size = New System.Drawing.Size(153, 20)
        Me.txtGLIssuesAccount.TabIndex = 35
        Me.txtGLIssuesAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGLAdjustmentAccount
        '
        Me.txtGLAdjustmentAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLAdjustmentAccount.Location = New System.Drawing.Point(165, 229)
        Me.txtGLAdjustmentAccount.Name = "txtGLAdjustmentAccount"
        Me.txtGLAdjustmentAccount.Size = New System.Drawing.Size(153, 20)
        Me.txtGLAdjustmentAccount.TabIndex = 34
        Me.txtGLAdjustmentAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGLSalesOffsetAccount
        '
        Me.txtGLSalesOffsetAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLSalesOffsetAccount.Location = New System.Drawing.Point(165, 204)
        Me.txtGLSalesOffsetAccount.Name = "txtGLSalesOffsetAccount"
        Me.txtGLSalesOffsetAccount.Size = New System.Drawing.Size(153, 20)
        Me.txtGLSalesOffsetAccount.TabIndex = 33
        Me.txtGLSalesOffsetAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGLInventoryAccount
        '
        Me.txtGLInventoryAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLInventoryAccount.Location = New System.Drawing.Point(165, 129)
        Me.txtGLInventoryAccount.Name = "txtGLInventoryAccount"
        Me.txtGLInventoryAccount.Size = New System.Drawing.Size(153, 20)
        Me.txtGLInventoryAccount.TabIndex = 30
        Me.txtGLInventoryAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGLReturnsAccount
        '
        Me.txtGLReturnsAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLReturnsAccount.Location = New System.Drawing.Point(165, 104)
        Me.txtGLReturnsAccount.Name = "txtGLReturnsAccount"
        Me.txtGLReturnsAccount.Size = New System.Drawing.Size(153, 20)
        Me.txtGLReturnsAccount.TabIndex = 29
        Me.txtGLReturnsAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGLSalesAccount
        '
        Me.txtGLSalesAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLSalesAccount.Location = New System.Drawing.Point(165, 79)
        Me.txtGLSalesAccount.Name = "txtGLSalesAccount"
        Me.txtGLSalesAccount.Size = New System.Drawing.Size(153, 20)
        Me.txtGLSalesAccount.TabIndex = 28
        Me.txtGLSalesAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(13, 254)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(136, 21)
        Me.Label44.TabIndex = 101
        Me.Label44.Text = "GL Issues Account"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(13, 204)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(136, 21)
        Me.Label36.TabIndex = 98
        Me.Label36.Text = "GL Sales Offset Account"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(13, 179)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(136, 21)
        Me.Label37.TabIndex = 97
        Me.Label37.Text = "GL Purchases Account"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(13, 154)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(136, 21)
        Me.Label38.TabIndex = 96
        Me.Label38.Text = "GL COGS Account"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(13, 129)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(136, 21)
        Me.Label40.TabIndex = 94
        Me.Label40.Text = "GL Inventory Account"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label41
        '
        Me.Label41.Location = New System.Drawing.Point(13, 79)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(136, 21)
        Me.Label41.TabIndex = 93
        Me.Label41.Text = "GL Sales Account"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(13, 229)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(136, 21)
        Me.Label42.TabIndex = 99
        Me.Label42.Text = "GL Adjustment Account"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(13, 105)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(136, 21)
        Me.Label43.TabIndex = 95
        Me.Label43.Text = "GL Returns Account"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(103, 22)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(215, 21)
        Me.cboItemClass.TabIndex = 27
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label39
        '
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(13, 22)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(136, 21)
        Me.Label39.TabIndex = 92
        Me.Label39.Text = "Item Class"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabDeleteLine
        '
        Me.tabDeleteLine.Controls.Add(Me.Label53)
        Me.tabDeleteLine.Controls.Add(Me.Label52)
        Me.tabDeleteLine.Controls.Add(Me.cboInvoiceLineNumber)
        Me.tabDeleteLine.Controls.Add(Me.cmdSaveLineChanges)
        Me.tabDeleteLine.Controls.Add(Me.cmdDeleteInvoiceLine)
        Me.tabDeleteLine.Controls.Add(Me.txtLineComment2)
        Me.tabDeleteLine.Controls.Add(Me.txtLineExtendedAmount)
        Me.tabDeleteLine.Controls.Add(Me.txtLineSalesTax2)
        Me.tabDeleteLine.Controls.Add(Me.txtLinePrice)
        Me.tabDeleteLine.Controls.Add(Me.txtLineQuantityBilled)
        Me.tabDeleteLine.Controls.Add(Me.Label31)
        Me.tabDeleteLine.Controls.Add(Me.Label46)
        Me.tabDeleteLine.Controls.Add(Me.Label47)
        Me.tabDeleteLine.Controls.Add(Me.Label48)
        Me.tabDeleteLine.Controls.Add(Me.Label49)
        Me.tabDeleteLine.Controls.Add(Me.cboLinePartDescription)
        Me.tabDeleteLine.Controls.Add(Me.cboLinePartNumber)
        Me.tabDeleteLine.Controls.Add(Me.Label50)
        Me.tabDeleteLine.Controls.Add(Me.Label51)
        Me.tabDeleteLine.Location = New System.Drawing.Point(4, 22)
        Me.tabDeleteLine.Name = "tabDeleteLine"
        Me.tabDeleteLine.Size = New System.Drawing.Size(364, 330)
        Me.tabDeleteLine.TabIndex = 2
        Me.tabDeleteLine.Text = "Delete Line / Edit Details"
        Me.tabDeleteLine.UseVisualStyleBackColor = True
        '
        'Label53
        '
        Me.Label53.ForeColor = System.Drawing.Color.Blue
        Me.Label53.Location = New System.Drawing.Point(13, 285)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(159, 40)
        Me.Label53.TabIndex = 114
        Me.Label53.Text = "Select Line # to edit data or delete the line from the invoice."
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label52
        '
        Me.Label52.Location = New System.Drawing.Point(11, 14)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(159, 21)
        Me.Label52.TabIndex = 113
        Me.Label52.Text = "Invoice Line Number"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboInvoiceLineNumber
        '
        Me.cboInvoiceLineNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInvoiceLineNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInvoiceLineNumber.DataSource = Me.InvoiceLineTableBindingSource
        Me.cboInvoiceLineNumber.DisplayMember = "InvoiceLineKey"
        Me.cboInvoiceLineNumber.FormattingEnabled = True
        Me.cboInvoiceLineNumber.Location = New System.Drawing.Point(201, 12)
        Me.cboInvoiceLineNumber.Name = "cboInvoiceLineNumber"
        Me.cboInvoiceLineNumber.Size = New System.Drawing.Size(136, 21)
        Me.cboInvoiceLineNumber.TabIndex = 36
        '
        'InvoiceLineTableBindingSource
        '
        Me.InvoiceLineTableBindingSource.DataMember = "InvoiceLineTable"
        Me.InvoiceLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdSaveLineChanges
        '
        Me.cmdSaveLineChanges.Location = New System.Drawing.Point(189, 283)
        Me.cmdSaveLineChanges.Name = "cmdSaveLineChanges"
        Me.cmdSaveLineChanges.Size = New System.Drawing.Size(71, 40)
        Me.cmdSaveLineChanges.TabIndex = 44
        Me.cmdSaveLineChanges.Text = "Save Changes"
        Me.cmdSaveLineChanges.UseVisualStyleBackColor = True
        '
        'cmdDeleteInvoiceLine
        '
        Me.cmdDeleteInvoiceLine.Location = New System.Drawing.Point(266, 283)
        Me.cmdDeleteInvoiceLine.Name = "cmdDeleteInvoiceLine"
        Me.cmdDeleteInvoiceLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteInvoiceLine.TabIndex = 45
        Me.cmdDeleteInvoiceLine.Text = "Delete Line"
        Me.cmdDeleteInvoiceLine.UseVisualStyleBackColor = True
        '
        'txtLineComment2
        '
        Me.txtLineComment2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineComment2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineComment2.Location = New System.Drawing.Point(25, 218)
        Me.txtLineComment2.Multiline = True
        Me.txtLineComment2.Name = "txtLineComment2"
        Me.txtLineComment2.Size = New System.Drawing.Size(312, 57)
        Me.txtLineComment2.TabIndex = 43
        Me.txtLineComment2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLineExtendedAmount
        '
        Me.txtLineExtendedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineExtendedAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineExtendedAmount.Enabled = False
        Me.txtLineExtendedAmount.Location = New System.Drawing.Point(201, 177)
        Me.txtLineExtendedAmount.Name = "txtLineExtendedAmount"
        Me.txtLineExtendedAmount.Size = New System.Drawing.Size(136, 20)
        Me.txtLineExtendedAmount.TabIndex = 42
        Me.txtLineExtendedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLineSalesTax2
        '
        Me.txtLineSalesTax2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineSalesTax2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineSalesTax2.Enabled = False
        Me.txtLineSalesTax2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLineSalesTax2.Location = New System.Drawing.Point(201, 149)
        Me.txtLineSalesTax2.Name = "txtLineSalesTax2"
        Me.txtLineSalesTax2.Size = New System.Drawing.Size(136, 20)
        Me.txtLineSalesTax2.TabIndex = 41
        Me.txtLineSalesTax2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLinePrice
        '
        Me.txtLinePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinePrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLinePrice.Location = New System.Drawing.Point(201, 121)
        Me.txtLinePrice.Name = "txtLinePrice"
        Me.txtLinePrice.Size = New System.Drawing.Size(136, 20)
        Me.txtLinePrice.TabIndex = 40
        Me.txtLinePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLineQuantityBilled
        '
        Me.txtLineQuantityBilled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineQuantityBilled.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineQuantityBilled.Location = New System.Drawing.Point(201, 93)
        Me.txtLineQuantityBilled.Name = "txtLineQuantityBilled"
        Me.txtLineQuantityBilled.Size = New System.Drawing.Size(136, 20)
        Me.txtLineQuantityBilled.TabIndex = 39
        Me.txtLineQuantityBilled.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(11, 179)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(98, 21)
        Me.Label31.TabIndex = 109
        Me.Label31.Text = "Extended Amount"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label46
        '
        Me.Label46.Location = New System.Drawing.Point(11, 151)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(98, 21)
        Me.Label46.TabIndex = 108
        Me.Label46.Text = "Sales Tax"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(11, 123)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(98, 21)
        Me.Label47.TabIndex = 107
        Me.Label47.Text = "Price"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label48
        '
        Me.Label48.Location = New System.Drawing.Point(11, 95)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(98, 21)
        Me.Label48.TabIndex = 105
        Me.Label48.Text = "Quantity Billed"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label49
        '
        Me.Label49.Location = New System.Drawing.Point(11, 41)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(98, 21)
        Me.Label49.TabIndex = 104
        Me.Label49.Text = "Part Number"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLinePartDescription
        '
        Me.cboLinePartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLinePartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLinePartDescription.DataSource = Me.InvoiceLineTableBindingSource
        Me.cboLinePartDescription.DisplayMember = "PartDescription"
        Me.cboLinePartDescription.DropDownWidth = 300
        Me.cboLinePartDescription.FormattingEnabled = True
        Me.cboLinePartDescription.Location = New System.Drawing.Point(125, 66)
        Me.cboLinePartDescription.Name = "cboLinePartDescription"
        Me.cboLinePartDescription.Size = New System.Drawing.Size(212, 21)
        Me.cboLinePartDescription.TabIndex = 38
        '
        'cboLinePartNumber
        '
        Me.cboLinePartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLinePartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLinePartNumber.DataSource = Me.InvoiceLineTableBindingSource
        Me.cboLinePartNumber.DisplayMember = "PartNumber"
        Me.cboLinePartNumber.DropDownWidth = 300
        Me.cboLinePartNumber.FormattingEnabled = True
        Me.cboLinePartNumber.Location = New System.Drawing.Point(125, 39)
        Me.cboLinePartNumber.Name = "cboLinePartNumber"
        Me.cboLinePartNumber.Size = New System.Drawing.Size(212, 21)
        Me.cboLinePartNumber.TabIndex = 37
        '
        'Label50
        '
        Me.Label50.Location = New System.Drawing.Point(11, 200)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(98, 21)
        Me.Label50.TabIndex = 110
        Me.Label50.Text = "Line Comment"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label51
        '
        Me.Label51.Location = New System.Drawing.Point(11, 68)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(98, 21)
        Me.Label51.TabIndex = 106
        Me.Label51.Text = "Part Description"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdRemoveSalesTax)
        Me.GroupBox1.Controls.Add(Me.txtHSTRate)
        Me.GroupBox1.Controls.Add(Me.chkAddPST)
        Me.GroupBox1.Controls.Add(Me.chkAddHST)
        Me.GroupBox1.Controls.Add(Me.txtSalesTax2)
        Me.GroupBox1.Controls.Add(Me.LabelPST)
        Me.GroupBox1.Controls.Add(Me.txtSalesTax3)
        Me.GroupBox1.Controls.Add(Me.LabelHST)
        Me.GroupBox1.Controls.Add(Me.txtInvoiceTotal)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtSalesTax)
        Me.GroupBox1.Controls.Add(Me.LabelSalesTax)
        Me.GroupBox1.Controls.Add(Me.txtDiscount)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtFreightBilled)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtProductSales)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Location = New System.Drawing.Point(743, 462)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(385, 213)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Invoice Totals"
        '
        'cmdRemoveSalesTax
        '
        Me.cmdRemoveSalesTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemoveSalesTax.ForeColor = System.Drawing.Color.Blue
        Me.cmdRemoveSalesTax.Location = New System.Drawing.Point(182, 103)
        Me.cmdRemoveSalesTax.Name = "cmdRemoveSalesTax"
        Me.cmdRemoveSalesTax.Size = New System.Drawing.Size(29, 20)
        Me.cmdRemoveSalesTax.TabIndex = 67
        Me.cmdRemoveSalesTax.Text = "<<"
        Me.cmdRemoveSalesTax.UseVisualStyleBackColor = True
        '
        'txtHSTRate
        '
        Me.txtHSTRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHSTRate.Location = New System.Drawing.Point(90, 153)
        Me.txtHSTRate.Name = "txtHSTRate"
        Me.txtHSTRate.Size = New System.Drawing.Size(71, 20)
        Me.txtHSTRate.TabIndex = 86
        Me.txtHSTRate.Visible = False
        '
        'chkAddPST
        '
        Me.chkAddPST.AutoSize = True
        Me.chkAddPST.Location = New System.Drawing.Point(25, 132)
        Me.chkAddPST.Name = "chkAddPST"
        Me.chkAddPST.Size = New System.Drawing.Size(15, 14)
        Me.chkAddPST.TabIndex = 85
        Me.chkAddPST.UseVisualStyleBackColor = True
        '
        'chkAddHST
        '
        Me.chkAddHST.AutoSize = True
        Me.chkAddHST.Location = New System.Drawing.Point(25, 157)
        Me.chkAddHST.Name = "chkAddHST"
        Me.chkAddHST.Size = New System.Drawing.Size(15, 14)
        Me.chkAddHST.TabIndex = 84
        Me.chkAddHST.UseVisualStyleBackColor = True
        '
        'txtSalesTax2
        '
        Me.txtSalesTax2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTax2.Enabled = False
        Me.txtSalesTax2.Location = New System.Drawing.Point(217, 128)
        Me.txtSalesTax2.Name = "txtSalesTax2"
        Me.txtSalesTax2.Size = New System.Drawing.Size(143, 20)
        Me.txtSalesTax2.TabIndex = 82
        Me.txtSalesTax2.TabStop = False
        Me.txtSalesTax2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelPST
        '
        Me.LabelPST.Location = New System.Drawing.Point(46, 127)
        Me.LabelPST.Name = "LabelPST"
        Me.LabelPST.Size = New System.Drawing.Size(34, 21)
        Me.LabelPST.TabIndex = 83
        Me.LabelPST.Text = "PST"
        Me.LabelPST.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesTax3
        '
        Me.txtSalesTax3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTax3.Enabled = False
        Me.txtSalesTax3.Location = New System.Drawing.Point(217, 153)
        Me.txtSalesTax3.Name = "txtSalesTax3"
        Me.txtSalesTax3.Size = New System.Drawing.Size(143, 20)
        Me.txtSalesTax3.TabIndex = 80
        Me.txtSalesTax3.TabStop = False
        Me.txtSalesTax3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelHST
        '
        Me.LabelHST.Location = New System.Drawing.Point(46, 153)
        Me.LabelHST.Name = "LabelHST"
        Me.LabelHST.Size = New System.Drawing.Size(43, 21)
        Me.LabelHST.TabIndex = 81
        Me.LabelHST.Text = "HST"
        Me.LabelHST.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInvoiceTotal
        '
        Me.txtInvoiceTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceTotal.Enabled = False
        Me.txtInvoiceTotal.Location = New System.Drawing.Point(217, 178)
        Me.txtInvoiceTotal.Name = "txtInvoiceTotal"
        Me.txtInvoiceTotal.Size = New System.Drawing.Size(143, 20)
        Me.txtInvoiceTotal.TabIndex = 50
        Me.txtInvoiceTotal.TabStop = False
        Me.txtInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(22, 178)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(101, 21)
        Me.Label20.TabIndex = 79
        Me.Label20.Text = "Invoice Total"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesTax
        '
        Me.txtSalesTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTax.Enabled = False
        Me.txtSalesTax.Location = New System.Drawing.Point(217, 103)
        Me.txtSalesTax.Name = "txtSalesTax"
        Me.txtSalesTax.Size = New System.Drawing.Size(143, 20)
        Me.txtSalesTax.TabIndex = 49
        Me.txtSalesTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelSalesTax
        '
        Me.LabelSalesTax.Location = New System.Drawing.Point(22, 103)
        Me.LabelSalesTax.Name = "LabelSalesTax"
        Me.LabelSalesTax.Size = New System.Drawing.Size(101, 21)
        Me.LabelSalesTax.TabIndex = 77
        Me.LabelSalesTax.Text = "Sales Tax"
        Me.LabelSalesTax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDiscount
        '
        Me.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscount.Enabled = False
        Me.txtDiscount.Location = New System.Drawing.Point(217, 78)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.Size = New System.Drawing.Size(143, 20)
        Me.txtDiscount.TabIndex = 48
        Me.txtDiscount.TabStop = False
        Me.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(22, 78)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(101, 21)
        Me.Label18.TabIndex = 75
        Me.Label18.Text = "Discount"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFreightBilled
        '
        Me.txtFreightBilled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightBilled.Enabled = False
        Me.txtFreightBilled.Location = New System.Drawing.Point(217, 53)
        Me.txtFreightBilled.Name = "txtFreightBilled"
        Me.txtFreightBilled.Size = New System.Drawing.Size(143, 20)
        Me.txtFreightBilled.TabIndex = 47
        Me.txtFreightBilled.TabStop = False
        Me.txtFreightBilled.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(22, 53)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(101, 21)
        Me.Label17.TabIndex = 73
        Me.Label17.Text = "Freight Billed"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProductSales
        '
        Me.txtProductSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductSales.Enabled = False
        Me.txtProductSales.Location = New System.Drawing.Point(217, 28)
        Me.txtProductSales.Name = "txtProductSales"
        Me.txtProductSales.Size = New System.Drawing.Size(143, 20)
        Me.txtProductSales.TabIndex = 46
        Me.txtProductSales.TabStop = False
        Me.txtProductSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(22, 28)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(101, 21)
        Me.Label16.TabIndex = 71
        Me.Label16.Text = "Product Sales"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(978, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 54
        Me.cmdPrint.Text = "Print Invoice"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(899, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 53
        Me.cmdDelete.Text = "Delete Invoice"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(820, 772)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 52
        Me.cmdSave.Text = "Save Invoice"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1057, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 55
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvInvoiceLines
        '
        Me.dgvInvoiceLines.AllowUserToAddRows = False
        Me.dgvInvoiceLines.AllowUserToDeleteRows = False
        Me.dgvInvoiceLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInvoiceLines.AutoGenerateColumns = False
        Me.dgvInvoiceLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInvoiceLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInvoiceLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceHeaderKeyColumn, Me.InvoiceLineKeyColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityBilledColumn, Me.PriceColumn, Me.ExtendedAmountColumn, Me.LineCommentColumn, Me.SalesTaxColumn, Me.LineWeightColumn, Me.LineBoxesColumn, Me.LineStatusColumn, Me.DivisionIDColumn, Me.DebitGLAccountColumn, Me.CreditGLAccountColumn, Me.ExtendedCOSColumn})
        Me.dgvInvoiceLines.DataSource = Me.InvoiceLineTableBindingSource
        Me.dgvInvoiceLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvInvoiceLines.Location = New System.Drawing.Point(353, 44)
        Me.dgvInvoiceLines.Name = "dgvInvoiceLines"
        Me.dgvInvoiceLines.Size = New System.Drawing.Size(775, 405)
        Me.dgvInvoiceLines.TabIndex = 61
        '
        'InvoiceHeaderKeyColumn
        '
        Me.InvoiceHeaderKeyColumn.DataPropertyName = "InvoiceHeaderKey"
        Me.InvoiceHeaderKeyColumn.HeaderText = "InvoiceHeaderKey"
        Me.InvoiceHeaderKeyColumn.Name = "InvoiceHeaderKeyColumn"
        Me.InvoiceHeaderKeyColumn.Visible = False
        '
        'InvoiceLineKeyColumn
        '
        Me.InvoiceLineKeyColumn.DataPropertyName = "InvoiceLineKey"
        Me.InvoiceLineKeyColumn.HeaderText = "Line #"
        Me.InvoiceLineKeyColumn.Name = "InvoiceLineKeyColumn"
        Me.InvoiceLineKeyColumn.ReadOnly = True
        Me.InvoiceLineKeyColumn.Width = 62
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part Number"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Part Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.ReadOnly = True
        '
        'QuantityBilledColumn
        '
        Me.QuantityBilledColumn.DataPropertyName = "QuantityBilled"
        DataGridViewCellStyle1.NullValue = "0"
        Me.QuantityBilledColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.QuantityBilledColumn.HeaderText = "Quantity Billed"
        Me.QuantityBilledColumn.Name = "QuantityBilledColumn"
        Me.QuantityBilledColumn.Width = 90
        '
        'PriceColumn
        '
        Me.PriceColumn.DataPropertyName = "Price"
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = "0"
        Me.PriceColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.PriceColumn.HeaderText = "Price"
        Me.PriceColumn.Name = "PriceColumn"
        Me.PriceColumn.Width = 90
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ExtendedAmountColumn.HeaderText = "Extended Amount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
        Me.ExtendedAmountColumn.Width = 90
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        '
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.SalesTaxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.SalesTaxColumn.HeaderText = "Sales Tax"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        Me.SalesTaxColumn.ReadOnly = True
        Me.SalesTaxColumn.Width = 90
        '
        'LineWeightColumn
        '
        Me.LineWeightColumn.DataPropertyName = "LineWeight"
        Me.LineWeightColumn.HeaderText = "Line Weight"
        Me.LineWeightColumn.Name = "LineWeightColumn"
        Me.LineWeightColumn.Visible = False
        '
        'LineBoxesColumn
        '
        Me.LineBoxesColumn.DataPropertyName = "LineBoxes"
        Me.LineBoxesColumn.HeaderText = "Line Boxes"
        Me.LineBoxesColumn.Name = "LineBoxesColumn"
        Me.LineBoxesColumn.Visible = False
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "Line Status"
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
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "DebitGLAccount"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        Me.DebitGLAccountColumn.Visible = False
        '
        'CreditGLAccountColumn
        '
        Me.CreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumn.HeaderText = "CreditGLAccount"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
        Me.CreditGLAccountColumn.Visible = False
        '
        'ExtendedCOSColumn
        '
        Me.ExtendedCOSColumn.DataPropertyName = "ExtendedCOS"
        Me.ExtendedCOSColumn.HeaderText = "ExtendedCOS"
        Me.ExtendedCOSColumn.Name = "ExtendedCOSColumn"
        Me.ExtendedCOSColumn.Visible = False
        '
        'cmdPostInvoice
        '
        Me.cmdPostInvoice.ForeColor = System.Drawing.Color.Blue
        Me.cmdPostInvoice.Location = New System.Drawing.Point(289, 25)
        Me.cmdPostInvoice.Name = "cmdPostInvoice"
        Me.cmdPostInvoice.Size = New System.Drawing.Size(71, 40)
        Me.cmdPostInvoice.TabIndex = 51
        Me.cmdPostInvoice.Text = "Post Invoice"
        Me.cmdPostInvoice.UseVisualStyleBackColor = True
        '
        'txtBatchNumber
        '
        Me.txtBatchNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchNumber.Enabled = False
        Me.txtBatchNumber.Location = New System.Drawing.Point(103, 102)
        Me.txtBatchNumber.Name = "txtBatchNumber"
        Me.txtBatchNumber.Size = New System.Drawing.Size(162, 20)
        Me.txtBatchNumber.TabIndex = 65
        '
        'InvoiceLineTableTableAdapter
        '
        Me.InvoiceLineTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerClassTableAdapter
        '
        Me.CustomerClassTableAdapter.ClearBeforeFill = True
        '
        'InvoiceHeaderTableTableAdapter
        '
        Me.InvoiceHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'ShipMethodTableAdapter
        '
        Me.ShipMethodTableAdapter.ClearBeforeFill = True
        '
        'StateTableTableAdapter
        '
        Me.StateTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label54)
        Me.GroupBox2.Controls.Add(Me.cmdPostInvoice)
        Me.GroupBox2.Location = New System.Drawing.Point(743, 681)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(385, 81)
        Me.GroupBox2.TabIndex = 51
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Post Invoice"
        '
        'Label54
        '
        Me.Label54.ForeColor = System.Drawing.Color.Blue
        Me.Label54.Location = New System.Drawing.Point(22, 19)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(261, 53)
        Me.Label54.TabIndex = 115
        Me.Label54.Text = "You must POST this Invoice. Bill Only's do not affect Inventory, COS, or Sales Cl" & _
            "earing Accounts, only Revenues and Receivables."
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FOBTableTableAdapter
        '
        Me.FOBTableTableAdapter.ClearBeforeFill = True
        '
        'InvoiceBillOnly
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgvInvoiceLines)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.tabLineDetails)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.gpxInvoiceHeaderInfo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.txtBatchNumber)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "InvoiceBillOnly"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Invoicing Form (Bill Only)"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxInvoiceHeaderInfo.ResumeLayout(False)
        Me.gpxInvoiceHeaderInfo.PerformLayout()
        CType(Me.CustomerClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FOBTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tabCustomerDetails.ResumeLayout(False)
        Me.tabCustomerDetails.PerformLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBillingAddress.ResumeLayout(False)
        Me.tabBillingAddress.PerformLayout()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAddDiscount.ResumeLayout(False)
        Me.tabAddDiscount.PerformLayout()
        Me.tabLineDetails.ResumeLayout(False)
        Me.tabInvoiceLineDetails.ResumeLayout(False)
        Me.tabInvoiceLineDetails.PerformLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabInvoiceLineOther.ResumeLayout(False)
        Me.tabInvoiceLineOther.PerformLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDeleteLine.ResumeLayout(False)
        Me.tabDeleteLine.PerformLayout()
        CType(Me.InvoiceLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvInvoiceLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxInvoiceHeaderInfo As System.Windows.Forms.GroupBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents dtpInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboInvoiceNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabCustomerDetails As System.Windows.Forms.TabPage
    Friend WithEvents cboShipVia As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents cboPaymentTerms As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBilledFreightEdit As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerPONumber As System.Windows.Forms.TextBox
    Friend WithEvents dtpShipDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtProNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents tabBillingAddress As System.Windows.Forms.TabPage
    Friend WithEvents txtBTAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtBTAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtBTCity As System.Windows.Forms.TextBox
    Friend WithEvents txtBTZip As System.Windows.Forms.TextBox
    Friend WithEvents txtBTCountry As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboBTState As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tabAddDiscount As System.Windows.Forms.TabPage
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteDiscount As System.Windows.Forms.Button
    Friend WithEvents txtDiscountAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtDiscountPercent As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cmdAddDiscount As System.Windows.Forms.Button
    Friend WithEvents tabLineDetails As System.Windows.Forms.TabControl
    Friend WithEvents tabInvoiceLineDetails As System.Windows.Forms.TabPage
    Friend WithEvents txtLineComment As System.Windows.Forms.TextBox
    Friend WithEvents txtExtendedAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtLineSalesTax As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantityBilled As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents tabInvoiceLineOther As System.Windows.Forms.TabPage
    Friend WithEvents txtGLPurchasesAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtGLCOGSAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtGLIssuesAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtGLAdjustmentAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtGLSalesOffsetAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtGLInventoryAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtGLReturnsAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtGLSalesAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClearLine As System.Windows.Forms.Button
    Friend WithEvents cmdAddLine As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtInvoiceTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtSalesTax As System.Windows.Forms.TextBox
    Friend WithEvents LabelSalesTax As System.Windows.Forms.Label
    Friend WithEvents txtDiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtFreightBilled As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtProductSales As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdGenerateNewInvoiceNumber As System.Windows.Forms.Button
    Friend WithEvents dgvInvoiceLines As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents InvoiceLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceLineTableTableAdapter
    Friend WithEvents chkTaxable As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboConsignmentWarehouse As System.Windows.Forms.ComboBox
    Friend WithEvents CustomerClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerClassTableAdapter
    Friend WithEvents InvoiceHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents ShipMethodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipMethodTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
    Friend WithEvents StateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StateTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SaveInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPostInvoice As System.Windows.Forms.Button
    Friend WithEvents txtBatchNumber As System.Windows.Forms.TextBox
    Friend WithEvents tabDeleteLine As System.Windows.Forms.TabPage
    Friend WithEvents cmdSaveLineChanges As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteInvoiceLine As System.Windows.Forms.Button
    Friend WithEvents txtLineComment2 As System.Windows.Forms.TextBox
    Friend WithEvents txtLineExtendedAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtLineSalesTax2 As System.Windows.Forms.TextBox
    Friend WithEvents txtLinePrice As System.Windows.Forms.TextBox
    Friend WithEvents txtLineQuantityBilled As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents cboLinePartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboLinePartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents cboInvoiceLineNumber As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents txtSalesTax2 As System.Windows.Forms.TextBox
    Friend WithEvents LabelPST As System.Windows.Forms.Label
    Friend WithEvents txtSalesTax3 As System.Windows.Forms.TextBox
    Friend WithEvents LabelHST As System.Windows.Forms.Label
    Friend WithEvents chkAddPST As System.Windows.Forms.CheckBox
    Friend WithEvents chkAddHST As System.Windows.Forms.CheckBox
    Friend WithEvents txtHSTRate As System.Windows.Forms.TextBox
    Friend WithEvents txtLineSalesTaxRate As System.Windows.Forms.TextBox
    Friend WithEvents cmdRemoveSalesTax As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents chkRemoveAllTaxes As System.Windows.Forms.CheckBox
    Friend WithEvents InvoiceHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityBilledColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineBoxesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCOSColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnLockInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents txtSpecialInstructions As System.Windows.Forms.TextBox
    Friend WithEvents cboShipMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerClass As System.Windows.Forms.ComboBox
    Friend WithEvents FOBTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FOBTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOBTableTableAdapter
    Friend WithEvents txtThirdParty As System.Windows.Forms.TextBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
End Class
