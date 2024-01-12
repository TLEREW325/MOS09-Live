<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ARCashReceipts
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
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ApplyPaymentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EnableApplyPaymentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AppendCashReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ScanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReUploadReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ScanToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdDistributePayments = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboCardType = New System.Windows.Forms.ComboBox
        Me.cboTenderType = New System.Windows.Forms.ComboBox
        Me.tabCashReceipts = New System.Windows.Forms.TabControl
        Me.tabCheck = New System.Windows.Forms.TabPage
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtCheckNumber = New System.Windows.Forms.TextBox
        Me.txtReferenceNumber = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtCheckComment = New System.Windows.Forms.TextBox
        Me.tabCreditCard = New System.Windows.Forms.TabPage
        Me.txtCardNumber = New System.Windows.Forms.TextBox
        Me.txtCreditCardComment = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtAuthorization = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCardDate = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.tabAdjustment = New System.Windows.Forms.TabPage
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.cboInvoiceAdjustmentNumber = New System.Windows.Forms.ComboBox
        Me.InvoiceHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.chkAdjustment = New System.Windows.Forms.CheckBox
        Me.txtAdjustmentAmount = New System.Windows.Forms.TextBox
        Me.cboGLAccountDescription = New System.Windows.Forms.ComboBox
        Me.GLAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboGLAccountNumber = New System.Windows.Forms.ComboBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.cmdApplyPayment = New System.Windows.Forms.Button
        Me.cmdClearPaymentDetails = New System.Windows.Forms.Button
        Me.gpxApplyFields = New System.Windows.Forms.GroupBox
        Me.lblOnHoldStatus = New System.Windows.Forms.Label
        Me.cboCreditMemo = New System.Windows.Forms.ComboBox
        Me.ReturnProductHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdGeneratePaymentID = New System.Windows.Forms.Button
        Me.txtBatchNumber = New System.Windows.Forms.TextBox
        Me.txtPaymentAmount = New System.Windows.Forms.TextBox
        Me.cboPaymentID = New System.Windows.Forms.ComboBox
        Me.ARPaymentLogBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.rdoCreditMemo = New System.Windows.Forms.RadioButton
        Me.dtpPaymentDate = New System.Windows.Forms.DateTimePicker
        Me.lblPaymentType = New System.Windows.Forms.Label
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.rdoPayment = New System.Windows.Forms.RadioButton
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label14 = New System.Windows.Forms.Label
        Me.cboBankAccount = New System.Windows.Forms.ComboBox
        Me.BankAccountTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label10 = New System.Windows.Forms.Label
        Me.gpxPaymentDetails = New System.Windows.Forms.GroupBox
        Me.txtOpenBalance = New System.Windows.Forms.TextBox
        Me.txtPaymentApplied = New System.Windows.Forms.TextBox
        Me.txtDiscountApplied = New System.Windows.Forms.TextBox
        Me.txtDistributableAmount = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.gpxInvoiceData = New System.Windows.Forms.GroupBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.cmdApplySinglePayment = New System.Windows.Forms.Button
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtInvoiceTotal = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtInvoicePaymentApplied = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtInvoiceDiscountApplied = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtInvoiceAmountOpen = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtInvoiceDate = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboInvoiceNumber = New System.Windows.Forms.ComboBox
        Me.InvoiceHeaderQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.Label27 = New System.Windows.Forms.Label
        Me.dgvInvoiceHeaderQuery = New System.Windows.Forms.DataGridView
        Me.BankAccountColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalPaymentsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceAmountOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.chkCheckPayment = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.PaymentEntryColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentsAppliedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmailSentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label28 = New System.Windows.Forms.Label
        Me.cmdSave = New System.Windows.Forms.Button
        Me.ARPaymentLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.InvoiceHeaderQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderQueryTableAdapter
        Me.ReturnProductHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReturnProductHeaderTableTableAdapter
        Me.ARPaymentLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARPaymentLogTableAdapter
        Me.GLAccountsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
        Me.InvoiceHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
        Me.APCheckLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.APCheckLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APCheckLogTableAdapter
        Me.BankAccountTypesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BankAccountTypesTableAdapter
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdRemoteScan = New System.Windows.Forms.Button
        Me.cmdUploadReceipt = New System.Windows.Forms.Button
        Me.cmdViewReceipt = New System.Windows.Forms.Button
        Me.cmdScan = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.tabCashReceipts.SuspendLayout()
        Me.tabCheck.SuspendLayout()
        Me.tabCreditCard.SuspendLayout()
        Me.tabAdjustment.SuspendLayout()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxApplyFields.SuspendLayout()
        CType(Me.ReturnProductHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ARPaymentLogBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BankAccountTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxPaymentDetails.SuspendLayout()
        Me.gpxInvoiceData.SuspendLayout()
        CType(Me.InvoiceHeaderQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInvoiceHeaderQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ARPaymentLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APCheckLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1252, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ApplyPaymentsToolStripMenuItem, Me.SaveDataToolStripMenuItem, Me.DeleteDataToolStripMenuItem, Me.ClearAllToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ApplyPaymentsToolStripMenuItem
        '
        Me.ApplyPaymentsToolStripMenuItem.Name = "ApplyPaymentsToolStripMenuItem"
        Me.ApplyPaymentsToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.ApplyPaymentsToolStripMenuItem.Text = "Apply Payments"
        '
        'SaveDataToolStripMenuItem
        '
        Me.SaveDataToolStripMenuItem.Name = "SaveDataToolStripMenuItem"
        Me.SaveDataToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.SaveDataToolStripMenuItem.Text = "Save Data"
        '
        'DeleteDataToolStripMenuItem
        '
        Me.DeleteDataToolStripMenuItem.Name = "DeleteDataToolStripMenuItem"
        Me.DeleteDataToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.DeleteDataToolStripMenuItem.Text = "Delete Data"
        '
        'ClearAllToolStripMenuItem
        '
        Me.ClearAllToolStripMenuItem.Name = "ClearAllToolStripMenuItem"
        Me.ClearAllToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.ClearAllToolStripMenuItem.Text = "Clear All"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnableApplyPaymentsToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'EnableApplyPaymentsToolStripMenuItem
        '
        Me.EnableApplyPaymentsToolStripMenuItem.Name = "EnableApplyPaymentsToolStripMenuItem"
        Me.EnableApplyPaymentsToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.EnableApplyPaymentsToolStripMenuItem.Text = "Enable Apply Payments"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AppendCashReceiptToolStripMenuItem, Me.ReUploadReceiptToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'AppendCashReceiptToolStripMenuItem
        '
        Me.AppendCashReceiptToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ScanToolStripMenuItem, Me.UploadToolStripMenuItem})
        Me.AppendCashReceiptToolStripMenuItem.Name = "AppendCashReceiptToolStripMenuItem"
        Me.AppendCashReceiptToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.AppendCashReceiptToolStripMenuItem.Text = "Append Cash Receipt"
        '
        'ScanToolStripMenuItem
        '
        Me.ScanToolStripMenuItem.Name = "ScanToolStripMenuItem"
        Me.ScanToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.ScanToolStripMenuItem.Text = "Scan"
        '
        'UploadToolStripMenuItem
        '
        Me.UploadToolStripMenuItem.Name = "UploadToolStripMenuItem"
        Me.UploadToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.UploadToolStripMenuItem.Text = "Upload"
        '
        'ReUploadReceiptToolStripMenuItem
        '
        Me.ReUploadReceiptToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ScanToolStripMenuItem1, Me.UploadToolStripMenuItem1})
        Me.ReUploadReceiptToolStripMenuItem.Name = "ReUploadReceiptToolStripMenuItem"
        Me.ReUploadReceiptToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ReUploadReceiptToolStripMenuItem.Text = "Re-Upload Receipt"
        '
        'ScanToolStripMenuItem1
        '
        Me.ScanToolStripMenuItem1.Name = "ScanToolStripMenuItem1"
        Me.ScanToolStripMenuItem1.Size = New System.Drawing.Size(107, 22)
        Me.ScanToolStripMenuItem1.Text = "Scan"
        '
        'UploadToolStripMenuItem1
        '
        Me.UploadToolStripMenuItem1.Name = "UploadToolStripMenuItem1"
        Me.UploadToolStripMenuItem1.Size = New System.Drawing.Size(107, 22)
        Me.UploadToolStripMenuItem1.Text = "Upload"
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
        'cmdDistributePayments
        '
        Me.cmdDistributePayments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDistributePayments.Location = New System.Drawing.Point(1094, 531)
        Me.cmdDistributePayments.Name = "cmdDistributePayments"
        Me.cmdDistributePayments.Size = New System.Drawing.Size(71, 40)
        Me.cmdDistributePayments.TabIndex = 29
        Me.cmdDistributePayments.Text = "Distribute Payments"
        Me.cmdDistributePayments.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(1094, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 31
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(1017, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 30
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1171, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 32
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(20, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 20)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Tender Type"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCardType
        '
        Me.cboCardType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCardType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCardType.FormattingEnabled = True
        Me.cboCardType.Items.AddRange(New Object() {"MasterCard", "Visa", "American Express", "Discover", "Other"})
        Me.cboCardType.Location = New System.Drawing.Point(117, 23)
        Me.cboCardType.Name = "cboCardType"
        Me.cboCardType.Size = New System.Drawing.Size(166, 21)
        Me.cboCardType.TabIndex = 11
        '
        'cboTenderType
        '
        Me.cboTenderType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTenderType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTenderType.FormattingEnabled = True
        Me.cboTenderType.Items.AddRange(New Object() {"Check", "Cash", "Wire Transfer"})
        Me.cboTenderType.Location = New System.Drawing.Point(102, 37)
        Me.cboTenderType.Name = "cboTenderType"
        Me.cboTenderType.Size = New System.Drawing.Size(171, 21)
        Me.cboTenderType.TabIndex = 7
        '
        'tabCashReceipts
        '
        Me.tabCashReceipts.Controls.Add(Me.tabCheck)
        Me.tabCashReceipts.Controls.Add(Me.tabCreditCard)
        Me.tabCashReceipts.Controls.Add(Me.tabAdjustment)
        Me.tabCashReceipts.Location = New System.Drawing.Point(29, 435)
        Me.tabCashReceipts.Name = "tabCashReceipts"
        Me.tabCashReceipts.SelectedIndex = 0
        Me.tabCashReceipts.Size = New System.Drawing.Size(300, 376)
        Me.tabCashReceipts.TabIndex = 7
        '
        'tabCheck
        '
        Me.tabCheck.Controls.Add(Me.Label7)
        Me.tabCheck.Controls.Add(Me.cboTenderType)
        Me.tabCheck.Controls.Add(Me.txtCheckNumber)
        Me.tabCheck.Controls.Add(Me.txtReferenceNumber)
        Me.tabCheck.Controls.Add(Me.Label8)
        Me.tabCheck.Controls.Add(Me.Label9)
        Me.tabCheck.Controls.Add(Me.txtCheckComment)
        Me.tabCheck.Controls.Add(Me.Label6)
        Me.tabCheck.Location = New System.Drawing.Point(4, 22)
        Me.tabCheck.Name = "tabCheck"
        Me.tabCheck.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCheck.Size = New System.Drawing.Size(292, 350)
        Me.tabCheck.TabIndex = 0
        Me.tabCheck.Text = "Cash/Check"
        Me.tabCheck.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(20, 169)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(148, 20)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "Comment (200 MAX)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCheckNumber
        '
        Me.txtCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCheckNumber.Location = New System.Drawing.Point(102, 74)
        Me.txtCheckNumber.Name = "txtCheckNumber"
        Me.txtCheckNumber.Size = New System.Drawing.Size(171, 20)
        Me.txtCheckNumber.TabIndex = 8
        Me.txtCheckNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReferenceNumber
        '
        Me.txtReferenceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferenceNumber.Location = New System.Drawing.Point(102, 110)
        Me.txtReferenceNumber.Name = "txtReferenceNumber"
        Me.txtReferenceNumber.Size = New System.Drawing.Size(171, 20)
        Me.txtReferenceNumber.TabIndex = 9
        Me.txtReferenceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(20, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 20)
        Me.Label8.TabIndex = 62
        Me.Label8.Text = "Reference #"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(20, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 20)
        Me.Label9.TabIndex = 63
        Me.Label9.Text = "Check Number"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCheckComment
        '
        Me.txtCheckComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCheckComment.Location = New System.Drawing.Point(20, 192)
        Me.txtCheckComment.Multiline = True
        Me.txtCheckComment.Name = "txtCheckComment"
        Me.txtCheckComment.Size = New System.Drawing.Size(253, 143)
        Me.txtCheckComment.TabIndex = 10
        Me.txtCheckComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tabCreditCard
        '
        Me.tabCreditCard.Controls.Add(Me.txtCardNumber)
        Me.tabCreditCard.Controls.Add(Me.txtCreditCardComment)
        Me.tabCreditCard.Controls.Add(Me.Label12)
        Me.tabCreditCard.Controls.Add(Me.txtAuthorization)
        Me.tabCreditCard.Controls.Add(Me.Label5)
        Me.tabCreditCard.Controls.Add(Me.txtCardDate)
        Me.tabCreditCard.Controls.Add(Me.cboCardType)
        Me.tabCreditCard.Controls.Add(Me.Label13)
        Me.tabCreditCard.Controls.Add(Me.Label15)
        Me.tabCreditCard.Controls.Add(Me.Label16)
        Me.tabCreditCard.Location = New System.Drawing.Point(4, 22)
        Me.tabCreditCard.Name = "tabCreditCard"
        Me.tabCreditCard.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCreditCard.Size = New System.Drawing.Size(292, 350)
        Me.tabCreditCard.TabIndex = 1
        Me.tabCreditCard.Text = "Credit Card"
        Me.tabCreditCard.UseVisualStyleBackColor = True
        '
        'txtCardNumber
        '
        Me.txtCardNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCardNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCardNumber.Location = New System.Drawing.Point(15, 86)
        Me.txtCardNumber.Name = "txtCardNumber"
        Me.txtCardNumber.Size = New System.Drawing.Size(268, 20)
        Me.txtCardNumber.TabIndex = 12
        Me.txtCardNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCreditCardComment
        '
        Me.txtCreditCardComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreditCardComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCreditCardComment.Location = New System.Drawing.Point(15, 230)
        Me.txtCreditCardComment.Multiline = True
        Me.txtCreditCardComment.Name = "txtCreditCardComment"
        Me.txtCreditCardComment.Size = New System.Drawing.Size(268, 108)
        Me.txtCreditCardComment.TabIndex = 15
        Me.txtCreditCardComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(12, 207)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(163, 20)
        Me.Label12.TabIndex = 61
        Me.Label12.Text = "Comment (200 MAX)"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAuthorization
        '
        Me.txtAuthorization.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAuthorization.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAuthorization.Location = New System.Drawing.Point(131, 160)
        Me.txtAuthorization.Name = "txtAuthorization"
        Me.txtAuthorization.Size = New System.Drawing.Size(152, 20)
        Me.txtAuthorization.TabIndex = 14
        Me.txtAuthorization.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 20)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "Card #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCardDate
        '
        Me.txtCardDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCardDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCardDate.Location = New System.Drawing.Point(131, 136)
        Me.txtCardDate.Name = "txtCardDate"
        Me.txtCardDate.Size = New System.Drawing.Size(152, 20)
        Me.txtCardDate.TabIndex = 13
        Me.txtCardDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(12, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 20)
        Me.Label13.TabIndex = 64
        Me.Label13.Text = "Card Type"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(12, 134)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(120, 20)
        Me.Label15.TabIndex = 65
        Me.Label15.Text = "Expiration Date"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(12, 160)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 20)
        Me.Label16.TabIndex = 66
        Me.Label16.Text = "Authorization #"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabAdjustment
        '
        Me.tabAdjustment.Controls.Add(Me.Label2)
        Me.tabAdjustment.Controls.Add(Me.Label34)
        Me.tabAdjustment.Controls.Add(Me.cboInvoiceAdjustmentNumber)
        Me.tabAdjustment.Controls.Add(Me.Label33)
        Me.tabAdjustment.Controls.Add(Me.Label32)
        Me.tabAdjustment.Controls.Add(Me.chkAdjustment)
        Me.tabAdjustment.Controls.Add(Me.txtAdjustmentAmount)
        Me.tabAdjustment.Controls.Add(Me.cboGLAccountDescription)
        Me.tabAdjustment.Controls.Add(Me.cboGLAccountNumber)
        Me.tabAdjustment.Controls.Add(Me.Label30)
        Me.tabAdjustment.Controls.Add(Me.Label31)
        Me.tabAdjustment.Location = New System.Drawing.Point(4, 22)
        Me.tabAdjustment.Name = "tabAdjustment"
        Me.tabAdjustment.Size = New System.Drawing.Size(292, 350)
        Me.tabAdjustment.TabIndex = 2
        Me.tabAdjustment.Text = "Adjustment/Write-off"
        Me.tabAdjustment.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(17, 285)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(266, 50)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Choose from Standard GL Accounts. Canadian accounts will automatically be convert" & _
            "ed based on the customer class. "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(22, 69)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(64, 20)
        Me.Label34.TabIndex = 73
        Me.Label34.Text = "Invoice #"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboInvoiceAdjustmentNumber
        '
        Me.cboInvoiceAdjustmentNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInvoiceAdjustmentNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInvoiceAdjustmentNumber.DataSource = Me.InvoiceHeaderTableBindingSource
        Me.cboInvoiceAdjustmentNumber.DisplayMember = "InvoiceNumber"
        Me.cboInvoiceAdjustmentNumber.Enabled = False
        Me.cboInvoiceAdjustmentNumber.FormattingEnabled = True
        Me.cboInvoiceAdjustmentNumber.Location = New System.Drawing.Point(101, 68)
        Me.cboInvoiceAdjustmentNumber.Name = "cboInvoiceAdjustmentNumber"
        Me.cboInvoiceAdjustmentNumber.Size = New System.Drawing.Size(182, 21)
        Me.cboInvoiceAdjustmentNumber.TabIndex = 72
        '
        'InvoiceHeaderTableBindingSource
        '
        Me.InvoiceHeaderTableBindingSource.DataMember = "InvoiceHeaderTable"
        Me.InvoiceHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label33
        '
        Me.Label33.ForeColor = System.Drawing.Color.Blue
        Me.Label33.Location = New System.Drawing.Point(17, 254)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(266, 20)
        Me.Label33.TabIndex = 25
        Me.Label33.Text = "Adjustments - Use GL Account 59700"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.ForeColor = System.Drawing.Color.Blue
        Me.Label32.Location = New System.Drawing.Point(17, 234)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(266, 20)
        Me.Label32.TabIndex = 24
        Me.Label32.Text = "Bad Debts - Use GL Account 97000"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkAdjustment
        '
        Me.chkAdjustment.AutoSize = True
        Me.chkAdjustment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAdjustment.ForeColor = System.Drawing.Color.Blue
        Me.chkAdjustment.Location = New System.Drawing.Point(20, 27)
        Me.chkAdjustment.Name = "chkAdjustment"
        Me.chkAdjustment.Size = New System.Drawing.Size(249, 17)
        Me.chkAdjustment.TabIndex = 23
        Me.chkAdjustment.Text = "Select to add amount as Adjustment / Write-Off"
        Me.chkAdjustment.UseVisualStyleBackColor = True
        '
        'txtAdjustmentAmount
        '
        Me.txtAdjustmentAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdjustmentAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdjustmentAmount.Enabled = False
        Me.txtAdjustmentAmount.Location = New System.Drawing.Point(161, 185)
        Me.txtAdjustmentAmount.Name = "txtAdjustmentAmount"
        Me.txtAdjustmentAmount.Size = New System.Drawing.Size(122, 20)
        Me.txtAdjustmentAmount.TabIndex = 22
        Me.txtAdjustmentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboGLAccountDescription
        '
        Me.cboGLAccountDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGLAccountDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLAccountDescription.DataSource = Me.GLAccountsBindingSource
        Me.cboGLAccountDescription.DisplayMember = "GLAccountShortDescription"
        Me.cboGLAccountDescription.Enabled = False
        Me.cboGLAccountDescription.FormattingEnabled = True
        Me.cboGLAccountDescription.Location = New System.Drawing.Point(20, 140)
        Me.cboGLAccountDescription.Name = "cboGLAccountDescription"
        Me.cboGLAccountDescription.Size = New System.Drawing.Size(263, 21)
        Me.cboGLAccountDescription.TabIndex = 9
        '
        'GLAccountsBindingSource
        '
        Me.GLAccountsBindingSource.DataMember = "GLAccounts"
        Me.GLAccountsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboGLAccountNumber
        '
        Me.cboGLAccountNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGLAccountNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLAccountNumber.DataSource = Me.GLAccountsBindingSource
        Me.cboGLAccountNumber.DisplayMember = "GLAccountNumber"
        Me.cboGLAccountNumber.Enabled = False
        Me.cboGLAccountNumber.FormattingEnabled = True
        Me.cboGLAccountNumber.Location = New System.Drawing.Point(101, 109)
        Me.cboGLAccountNumber.Name = "cboGLAccountNumber"
        Me.cboGLAccountNumber.Size = New System.Drawing.Size(182, 21)
        Me.cboGLAccountNumber.TabIndex = 7
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(23, 110)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(82, 20)
        Me.Label30.TabIndex = 8
        Me.Label30.Text = "GL Account"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(20, 185)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(151, 20)
        Me.Label31.TabIndex = 21
        Me.Label31.Text = "Adj. / Write-off Amount"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdApplyPayment
        '
        Me.cmdApplyPayment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdApplyPayment.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdApplyPayment.Enabled = False
        Me.cmdApplyPayment.ForeColor = System.Drawing.Color.Purple
        Me.cmdApplyPayment.Location = New System.Drawing.Point(733, 771)
        Me.cmdApplyPayment.Name = "cmdApplyPayment"
        Me.cmdApplyPayment.Size = New System.Drawing.Size(71, 40)
        Me.cmdApplyPayment.TabIndex = 27
        Me.cmdApplyPayment.Text = "Apply Payment"
        Me.cmdApplyPayment.UseVisualStyleBackColor = False
        '
        'cmdClearPaymentDetails
        '
        Me.cmdClearPaymentDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearPaymentDetails.Location = New System.Drawing.Point(1171, 531)
        Me.cmdClearPaymentDetails.Name = "cmdClearPaymentDetails"
        Me.cmdClearPaymentDetails.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearPaymentDetails.TabIndex = 28
        Me.cmdClearPaymentDetails.Text = "Clear Distribution"
        Me.cmdClearPaymentDetails.UseVisualStyleBackColor = True
        '
        'gpxApplyFields
        '
        Me.gpxApplyFields.Controls.Add(Me.lblOnHoldStatus)
        Me.gpxApplyFields.Controls.Add(Me.cboCreditMemo)
        Me.gpxApplyFields.Controls.Add(Me.cmdGeneratePaymentID)
        Me.gpxApplyFields.Controls.Add(Me.txtBatchNumber)
        Me.gpxApplyFields.Controls.Add(Me.txtPaymentAmount)
        Me.gpxApplyFields.Controls.Add(Me.cboPaymentID)
        Me.gpxApplyFields.Controls.Add(Me.rdoCreditMemo)
        Me.gpxApplyFields.Controls.Add(Me.dtpPaymentDate)
        Me.gpxApplyFields.Controls.Add(Me.lblPaymentType)
        Me.gpxApplyFields.Controls.Add(Me.cboCustomerName)
        Me.gpxApplyFields.Controls.Add(Me.rdoPayment)
        Me.gpxApplyFields.Controls.Add(Me.cboCustomerID)
        Me.gpxApplyFields.Controls.Add(Me.Label3)
        Me.gpxApplyFields.Controls.Add(Me.Label4)
        Me.gpxApplyFields.Controls.Add(Me.Label11)
        Me.gpxApplyFields.Controls.Add(Me.Label1)
        Me.gpxApplyFields.Controls.Add(Me.cboDivisionID)
        Me.gpxApplyFields.Controls.Add(Me.Label14)
        Me.gpxApplyFields.Location = New System.Drawing.Point(29, 41)
        Me.gpxApplyFields.Name = "gpxApplyFields"
        Me.gpxApplyFields.Size = New System.Drawing.Size(300, 380)
        Me.gpxApplyFields.TabIndex = 0
        Me.gpxApplyFields.TabStop = False
        Me.gpxApplyFields.Text = "Cash Receipts"
        '
        'lblOnHoldStatus
        '
        Me.lblOnHoldStatus.ForeColor = System.Drawing.Color.Red
        Me.lblOnHoldStatus.Location = New System.Drawing.Point(16, 225)
        Me.lblOnHoldStatus.Name = "lblOnHoldStatus"
        Me.lblOnHoldStatus.Size = New System.Drawing.Size(271, 20)
        Me.lblOnHoldStatus.TabIndex = 47
        Me.lblOnHoldStatus.Text = "Customer is on credit hold"
        Me.lblOnHoldStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblOnHoldStatus.Visible = False
        '
        'cboCreditMemo
        '
        Me.cboCreditMemo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCreditMemo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCreditMemo.DataSource = Me.ReturnProductHeaderTableBindingSource
        Me.cboCreditMemo.DisplayMember = "ReturnNumber"
        Me.cboCreditMemo.FormattingEnabled = True
        Me.cboCreditMemo.Location = New System.Drawing.Point(121, 299)
        Me.cboCreditMemo.Name = "cboCreditMemo"
        Me.cboCreditMemo.Size = New System.Drawing.Size(166, 21)
        Me.cboCreditMemo.TabIndex = 9
        Me.cboCreditMemo.Visible = False
        '
        'ReturnProductHeaderTableBindingSource
        '
        Me.ReturnProductHeaderTableBindingSource.DataMember = "ReturnProductHeaderTable"
        Me.ReturnProductHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdGeneratePaymentID
        '
        Me.cmdGeneratePaymentID.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGeneratePaymentID.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGeneratePaymentID.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGeneratePaymentID.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGeneratePaymentID.Location = New System.Drawing.Point(84, 92)
        Me.cmdGeneratePaymentID.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGeneratePaymentID.Name = "cmdGeneratePaymentID"
        Me.cmdGeneratePaymentID.Size = New System.Drawing.Size(29, 20)
        Me.cmdGeneratePaymentID.TabIndex = 2
        Me.cmdGeneratePaymentID.Text = ">>"
        Me.cmdGeneratePaymentID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGeneratePaymentID.UseVisualStyleBackColor = False
        '
        'txtBatchNumber
        '
        Me.txtBatchNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchNumber.Enabled = False
        Me.txtBatchNumber.Location = New System.Drawing.Point(116, 26)
        Me.txtBatchNumber.Name = "txtBatchNumber"
        Me.txtBatchNumber.Size = New System.Drawing.Size(171, 20)
        Me.txtBatchNumber.TabIndex = 0
        Me.txtBatchNumber.TabStop = False
        '
        'txtPaymentAmount
        '
        Me.txtPaymentAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaymentAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaymentAmount.Location = New System.Drawing.Point(121, 343)
        Me.txtPaymentAmount.Name = "txtPaymentAmount"
        Me.txtPaymentAmount.Size = New System.Drawing.Size(166, 20)
        Me.txtPaymentAmount.TabIndex = 10
        Me.txtPaymentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboPaymentID
        '
        Me.cboPaymentID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPaymentID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentID.DataSource = Me.ARPaymentLogBindingSource1
        Me.cboPaymentID.DisplayMember = "PaymentID"
        Me.cboPaymentID.FormattingEnabled = True
        Me.cboPaymentID.Location = New System.Drawing.Point(116, 92)
        Me.cboPaymentID.Name = "cboPaymentID"
        Me.cboPaymentID.Size = New System.Drawing.Size(171, 21)
        Me.cboPaymentID.TabIndex = 3
        '
        'ARPaymentLogBindingSource1
        '
        Me.ARPaymentLogBindingSource1.DataMember = "ARPaymentLog"
        Me.ARPaymentLogBindingSource1.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'rdoCreditMemo
        '
        Me.rdoCreditMemo.AutoSize = True
        Me.rdoCreditMemo.Location = New System.Drawing.Point(16, 303)
        Me.rdoCreditMemo.Name = "rdoCreditMemo"
        Me.rdoCreditMemo.Size = New System.Drawing.Size(84, 17)
        Me.rdoCreditMemo.TabIndex = 8
        Me.rdoCreditMemo.Text = "Credit Memo"
        Me.rdoCreditMemo.UseVisualStyleBackColor = True
        '
        'dtpPaymentDate
        '
        Me.dtpPaymentDate.Enabled = False
        Me.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPaymentDate.Location = New System.Drawing.Point(116, 124)
        Me.dtpPaymentDate.Name = "dtpPaymentDate"
        Me.dtpPaymentDate.Size = New System.Drawing.Size(171, 20)
        Me.dtpPaymentDate.TabIndex = 4
        '
        'lblPaymentType
        '
        Me.lblPaymentType.Location = New System.Drawing.Point(16, 343)
        Me.lblPaymentType.Name = "lblPaymentType"
        Me.lblPaymentType.Size = New System.Drawing.Size(96, 20)
        Me.lblPaymentType.TabIndex = 9
        Me.lblPaymentType.Text = "Payment Amount"
        Me.lblPaymentType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(16, 201)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(271, 21)
        Me.cboCustomerName.TabIndex = 6
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'rdoPayment
        '
        Me.rdoPayment.AutoSize = True
        Me.rdoPayment.Checked = True
        Me.rdoPayment.Location = New System.Drawing.Point(16, 280)
        Me.rdoPayment.Name = "rdoPayment"
        Me.rdoPayment.Size = New System.Drawing.Size(66, 17)
        Me.rdoPayment.TabIndex = 7
        Me.rdoPayment.TabStop = True
        Me.rdoPayment.Text = "Payment"
        Me.rdoPayment.UseVisualStyleBackColor = True
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(78, 170)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(209, 21)
        Me.cboCustomerID.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Customer"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 20)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Payment Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 20)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "Batch Number"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(116, 58)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(171, 21)
        Me.cboDivisionID.TabIndex = 1
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(16, 92)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 20)
        Me.Label14.TabIndex = 46
        Me.Label14.Text = "Payment ID"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBankAccount
        '
        Me.cboBankAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBankAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBankAccount.DataSource = Me.BankAccountTypesBindingSource
        Me.cboBankAccount.DisplayMember = "BAID"
        Me.cboBankAccount.FormattingEnabled = True
        Me.cboBankAccount.Location = New System.Drawing.Point(154, 194)
        Me.cboBankAccount.Name = "cboBankAccount"
        Me.cboBankAccount.Size = New System.Drawing.Size(154, 21)
        Me.cboBankAccount.TabIndex = 4
        '
        'BankAccountTypesBindingSource
        '
        Me.BankAccountTypesBindingSource.DataMember = "BankAccountTypes"
        Me.BankAccountTypesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(20, 194)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 20)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Bank Account"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxPaymentDetails
        '
        Me.gpxPaymentDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxPaymentDetails.Controls.Add(Me.txtOpenBalance)
        Me.gpxPaymentDetails.Controls.Add(Me.txtPaymentApplied)
        Me.gpxPaymentDetails.Controls.Add(Me.txtDiscountApplied)
        Me.gpxPaymentDetails.Controls.Add(Me.txtDistributableAmount)
        Me.gpxPaymentDetails.Controls.Add(Me.Label20)
        Me.gpxPaymentDetails.Controls.Add(Me.Label21)
        Me.gpxPaymentDetails.Controls.Add(Me.Label22)
        Me.gpxPaymentDetails.Controls.Add(Me.Label23)
        Me.gpxPaymentDetails.Location = New System.Drawing.Point(940, 597)
        Me.gpxPaymentDetails.Name = "gpxPaymentDetails"
        Me.gpxPaymentDetails.Size = New System.Drawing.Size(302, 158)
        Me.gpxPaymentDetails.TabIndex = 22
        Me.gpxPaymentDetails.TabStop = False
        Me.gpxPaymentDetails.Text = "Payment Details"
        '
        'txtOpenBalance
        '
        Me.txtOpenBalance.BackColor = System.Drawing.Color.White
        Me.txtOpenBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOpenBalance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOpenBalance.Location = New System.Drawing.Point(154, 121)
        Me.txtOpenBalance.Name = "txtOpenBalance"
        Me.txtOpenBalance.ReadOnly = True
        Me.txtOpenBalance.Size = New System.Drawing.Size(134, 20)
        Me.txtOpenBalance.TabIndex = 25
        Me.txtOpenBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPaymentApplied
        '
        Me.txtPaymentApplied.BackColor = System.Drawing.Color.White
        Me.txtPaymentApplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaymentApplied.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaymentApplied.Location = New System.Drawing.Point(154, 90)
        Me.txtPaymentApplied.Name = "txtPaymentApplied"
        Me.txtPaymentApplied.ReadOnly = True
        Me.txtPaymentApplied.Size = New System.Drawing.Size(134, 20)
        Me.txtPaymentApplied.TabIndex = 24
        Me.txtPaymentApplied.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiscountApplied
        '
        Me.txtDiscountApplied.BackColor = System.Drawing.Color.White
        Me.txtDiscountApplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscountApplied.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDiscountApplied.Location = New System.Drawing.Point(154, 59)
        Me.txtDiscountApplied.Name = "txtDiscountApplied"
        Me.txtDiscountApplied.ReadOnly = True
        Me.txtDiscountApplied.Size = New System.Drawing.Size(134, 20)
        Me.txtDiscountApplied.TabIndex = 23
        Me.txtDiscountApplied.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDistributableAmount
        '
        Me.txtDistributableAmount.BackColor = System.Drawing.Color.White
        Me.txtDistributableAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDistributableAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDistributableAmount.Location = New System.Drawing.Point(154, 28)
        Me.txtDistributableAmount.Name = "txtDistributableAmount"
        Me.txtDistributableAmount.ReadOnly = True
        Me.txtDistributableAmount.Size = New System.Drawing.Size(134, 20)
        Me.txtDistributableAmount.TabIndex = 22
        Me.txtDistributableAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(27, 121)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(99, 20)
        Me.Label20.TabIndex = 9
        Me.Label20.Text = "New Balance"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(27, 28)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(132, 20)
        Me.Label21.TabIndex = 8
        Me.Label21.Text = "Distributable Amount"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(27, 59)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(99, 20)
        Me.Label22.TabIndex = 9
        Me.Label22.Text = "Discount Applied"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(27, 90)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(99, 20)
        Me.Label23.TabIndex = 7
        Me.Label23.Text = "Payment Applied"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxInvoiceData
        '
        Me.gpxInvoiceData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxInvoiceData.Controls.Add(Me.cboBankAccount)
        Me.gpxInvoiceData.Controls.Add(Me.Label10)
        Me.gpxInvoiceData.Controls.Add(Me.Label29)
        Me.gpxInvoiceData.Controls.Add(Me.cmdApplySinglePayment)
        Me.gpxInvoiceData.Controls.Add(Me.Label26)
        Me.gpxInvoiceData.Controls.Add(Me.txtInvoiceTotal)
        Me.gpxInvoiceData.Controls.Add(Me.Label25)
        Me.gpxInvoiceData.Controls.Add(Me.txtInvoicePaymentApplied)
        Me.gpxInvoiceData.Controls.Add(Me.Label24)
        Me.gpxInvoiceData.Controls.Add(Me.txtInvoiceDiscountApplied)
        Me.gpxInvoiceData.Controls.Add(Me.Label19)
        Me.gpxInvoiceData.Controls.Add(Me.txtInvoiceAmountOpen)
        Me.gpxInvoiceData.Controls.Add(Me.Label18)
        Me.gpxInvoiceData.Controls.Add(Me.txtInvoiceDate)
        Me.gpxInvoiceData.Controls.Add(Me.Label17)
        Me.gpxInvoiceData.Controls.Add(Me.cboInvoiceNumber)
        Me.gpxInvoiceData.Location = New System.Drawing.Point(347, 521)
        Me.gpxInvoiceData.Name = "gpxInvoiceData"
        Me.gpxInvoiceData.Size = New System.Drawing.Size(329, 286)
        Me.gpxInvoiceData.TabIndex = 33
        Me.gpxInvoiceData.TabStop = False
        Me.gpxInvoiceData.Text = "Manual Invoice Payment Data"
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Blue
        Me.Label29.Location = New System.Drawing.Point(20, 240)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(190, 23)
        Me.Label29.TabIndex = 84
        Me.Label29.Text = "Apply payment to single invoice."
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdApplySinglePayment
        '
        Me.cmdApplySinglePayment.Enabled = False
        Me.cmdApplySinglePayment.Location = New System.Drawing.Point(237, 231)
        Me.cmdApplySinglePayment.Name = "cmdApplySinglePayment"
        Me.cmdApplySinglePayment.Size = New System.Drawing.Size(71, 40)
        Me.cmdApplySinglePayment.TabIndex = 82
        Me.cmdApplySinglePayment.Text = "Manual Payment"
        Me.cmdApplySinglePayment.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(20, 78)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(128, 20)
        Me.Label26.TabIndex = 81
        Me.Label26.Text = "Invoice Total"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInvoiceTotal
        '
        Me.txtInvoiceTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceTotal.Location = New System.Drawing.Point(154, 78)
        Me.txtInvoiceTotal.Name = "txtInvoiceTotal"
        Me.txtInvoiceTotal.ReadOnly = True
        Me.txtInvoiceTotal.Size = New System.Drawing.Size(154, 20)
        Me.txtInvoiceTotal.TabIndex = 80
        Me.txtInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(20, 165)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(128, 20)
        Me.Label25.TabIndex = 79
        Me.Label25.Text = "Payment Applied"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInvoicePaymentApplied
        '
        Me.txtInvoicePaymentApplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoicePaymentApplied.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoicePaymentApplied.Location = New System.Drawing.Point(154, 165)
        Me.txtInvoicePaymentApplied.Name = "txtInvoicePaymentApplied"
        Me.txtInvoicePaymentApplied.Size = New System.Drawing.Size(154, 20)
        Me.txtInvoicePaymentApplied.TabIndex = 78
        Me.txtInvoicePaymentApplied.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(20, 136)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(128, 20)
        Me.Label24.TabIndex = 77
        Me.Label24.Text = "Discount Applied"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInvoiceDiscountApplied
        '
        Me.txtInvoiceDiscountApplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceDiscountApplied.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceDiscountApplied.Location = New System.Drawing.Point(154, 136)
        Me.txtInvoiceDiscountApplied.Name = "txtInvoiceDiscountApplied"
        Me.txtInvoiceDiscountApplied.Size = New System.Drawing.Size(154, 20)
        Me.txtInvoiceDiscountApplied.TabIndex = 76
        Me.txtInvoiceDiscountApplied.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(20, 107)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(128, 20)
        Me.Label19.TabIndex = 75
        Me.Label19.Text = "Invoice Amount Open"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInvoiceAmountOpen
        '
        Me.txtInvoiceAmountOpen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceAmountOpen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceAmountOpen.Location = New System.Drawing.Point(154, 107)
        Me.txtInvoiceAmountOpen.Name = "txtInvoiceAmountOpen"
        Me.txtInvoiceAmountOpen.ReadOnly = True
        Me.txtInvoiceAmountOpen.Size = New System.Drawing.Size(154, 20)
        Me.txtInvoiceAmountOpen.TabIndex = 74
        Me.txtInvoiceAmountOpen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(20, 49)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(128, 20)
        Me.Label18.TabIndex = 73
        Me.Label18.Text = "Invoice Date"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInvoiceDate
        '
        Me.txtInvoiceDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceDate.Location = New System.Drawing.Point(154, 49)
        Me.txtInvoiceDate.Name = "txtInvoiceDate"
        Me.txtInvoiceDate.ReadOnly = True
        Me.txtInvoiceDate.Size = New System.Drawing.Size(154, 20)
        Me.txtInvoiceDate.TabIndex = 72
        Me.txtInvoiceDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(20, 20)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(128, 20)
        Me.Label17.TabIndex = 71
        Me.Label17.Text = "Invoice #"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboInvoiceNumber
        '
        Me.cboInvoiceNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInvoiceNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInvoiceNumber.DataSource = Me.InvoiceHeaderQueryBindingSource
        Me.cboInvoiceNumber.DisplayMember = "InvoiceNumber"
        Me.cboInvoiceNumber.FormattingEnabled = True
        Me.cboInvoiceNumber.Location = New System.Drawing.Point(154, 19)
        Me.cboInvoiceNumber.Name = "cboInvoiceNumber"
        Me.cboInvoiceNumber.Size = New System.Drawing.Size(154, 21)
        Me.cboInvoiceNumber.TabIndex = 70
        '
        'InvoiceHeaderQueryBindingSource
        '
        Me.InvoiceHeaderQueryBindingSource.DataMember = "InvoiceHeaderQuery"
        Me.InvoiceHeaderQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdClearAll.ForeColor = System.Drawing.Color.Black
        Me.cmdClearAll.Location = New System.Drawing.Point(810, 771)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 83
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = False
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Navy
        Me.Label27.Location = New System.Drawing.Point(343, 41)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(217, 20)
        Me.Label27.TabIndex = 72
        Me.Label27.Text = "Open Invoices"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvInvoiceHeaderQuery
        '
        Me.dgvInvoiceHeaderQuery.AllowUserToAddRows = False
        Me.dgvInvoiceHeaderQuery.AllowUserToDeleteRows = False
        Me.dgvInvoiceHeaderQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInvoiceHeaderQuery.AutoGenerateColumns = False
        Me.dgvInvoiceHeaderQuery.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInvoiceHeaderQuery.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInvoiceHeaderQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BankAccountColumn, Me.DivisionIDColumn, Me.CustomerPOColumn, Me.SalesOrderNumberColumn, Me.InvoiceDateColumn, Me.InvoiceTotalColumn, Me.TotalPaymentsColumn, Me.InvoiceAmountOpenColumn, Me.InvoiceNumberColumn, Me.chkCheckPayment, Me.PaymentEntryColumn, Me.PaymentsAppliedColumn, Me.InvoiceColumn, Me.CustomerIDColumn, Me.EmailSentColumn})
        Me.dgvInvoiceHeaderQuery.DataSource = Me.InvoiceHeaderQueryBindingSource
        Me.dgvInvoiceHeaderQuery.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvInvoiceHeaderQuery.Location = New System.Drawing.Point(347, 64)
        Me.dgvInvoiceHeaderQuery.Name = "dgvInvoiceHeaderQuery"
        Me.dgvInvoiceHeaderQuery.Size = New System.Drawing.Size(895, 451)
        Me.dgvInvoiceHeaderQuery.TabIndex = 73
        '
        'BankAccountColumn
        '
        Me.BankAccountColumn.HeaderText = "Bank Acct."
        Me.BankAccountColumn.Items.AddRange(New Object() {"Cash Receipts", "Checking", "Canadian Checking", "Other"})
        Me.BankAccountColumn.Name = "BankAccountColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Width = 60
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.HeaderText = "Cust PO"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        Me.CustomerPOColumn.ReadOnly = True
        Me.CustomerPOColumn.Width = 85
        '
        'SalesOrderNumberColumn
        '
        Me.SalesOrderNumberColumn.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberColumn.HeaderText = "SO #"
        Me.SalesOrderNumberColumn.Name = "SalesOrderNumberColumn"
        Me.SalesOrderNumberColumn.ReadOnly = True
        Me.SalesOrderNumberColumn.Width = 60
        '
        'InvoiceDateColumn
        '
        Me.InvoiceDateColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumn.FillWeight = 80.0!
        Me.InvoiceDateColumn.HeaderText = "Inv. Date"
        Me.InvoiceDateColumn.Name = "InvoiceDateColumn"
        Me.InvoiceDateColumn.ReadOnly = True
        Me.InvoiceDateColumn.Width = 65
        '
        'InvoiceTotalColumn
        '
        Me.InvoiceTotalColumn.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle16.Format = "N2"
        DataGridViewCellStyle16.NullValue = "0"
        Me.InvoiceTotalColumn.DefaultCellStyle = DataGridViewCellStyle16
        Me.InvoiceTotalColumn.FillWeight = 90.0!
        Me.InvoiceTotalColumn.HeaderText = "Invoice Total"
        Me.InvoiceTotalColumn.Name = "InvoiceTotalColumn"
        Me.InvoiceTotalColumn.ReadOnly = True
        Me.InvoiceTotalColumn.Width = 85
        '
        'TotalPaymentsColumn
        '
        Me.TotalPaymentsColumn.DataPropertyName = "TotalPayments"
        DataGridViewCellStyle17.Format = "N2"
        DataGridViewCellStyle17.NullValue = "0"
        Me.TotalPaymentsColumn.DefaultCellStyle = DataGridViewCellStyle17
        Me.TotalPaymentsColumn.FillWeight = 90.0!
        Me.TotalPaymentsColumn.HeaderText = "Total Pmts."
        Me.TotalPaymentsColumn.Name = "TotalPaymentsColumn"
        Me.TotalPaymentsColumn.ReadOnly = True
        Me.TotalPaymentsColumn.Width = 85
        '
        'InvoiceAmountOpenColumn
        '
        Me.InvoiceAmountOpenColumn.DataPropertyName = "InvoiceAmountOpen"
        DataGridViewCellStyle18.Format = "N2"
        DataGridViewCellStyle18.NullValue = "0"
        Me.InvoiceAmountOpenColumn.DefaultCellStyle = DataGridViewCellStyle18
        Me.InvoiceAmountOpenColumn.FillWeight = 90.0!
        Me.InvoiceAmountOpenColumn.HeaderText = "Amount Open"
        Me.InvoiceAmountOpenColumn.Name = "InvoiceAmountOpenColumn"
        Me.InvoiceAmountOpenColumn.ReadOnly = True
        Me.InvoiceAmountOpenColumn.Width = 85
        '
        'InvoiceNumberColumn
        '
        Me.InvoiceNumberColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn.HeaderText = "Invoice #"
        Me.InvoiceNumberColumn.Name = "InvoiceNumberColumn"
        Me.InvoiceNumberColumn.ReadOnly = True
        Me.InvoiceNumberColumn.Width = 85
        '
        'chkCheckPayment
        '
        Me.chkCheckPayment.FalseValue = "UNCHECKED"
        Me.chkCheckPayment.HeaderText = "Check"
        Me.chkCheckPayment.Name = "chkCheckPayment"
        Me.chkCheckPayment.TrueValue = "CHECKED"
        Me.chkCheckPayment.Width = 50
        '
        'PaymentEntryColumn
        '
        DataGridViewCellStyle19.Format = "N2"
        DataGridViewCellStyle19.NullValue = "0"
        Me.PaymentEntryColumn.DefaultCellStyle = DataGridViewCellStyle19
        Me.PaymentEntryColumn.FillWeight = 90.0!
        Me.PaymentEntryColumn.HeaderText = "Enter Payment"
        Me.PaymentEntryColumn.Name = "PaymentEntryColumn"
        Me.PaymentEntryColumn.Width = 90
        '
        'PaymentsAppliedColumn
        '
        Me.PaymentsAppliedColumn.DataPropertyName = "PaymentsApplied"
        DataGridViewCellStyle20.Format = "N2"
        DataGridViewCellStyle20.NullValue = "0"
        Me.PaymentsAppliedColumn.DefaultCellStyle = DataGridViewCellStyle20
        Me.PaymentsAppliedColumn.HeaderText = "Payments Applied"
        Me.PaymentsAppliedColumn.Name = "PaymentsAppliedColumn"
        Me.PaymentsAppliedColumn.Visible = False
        '
        'InvoiceColumn
        '
        Me.InvoiceColumn.DataPropertyName = "InvoiceStatus"
        Me.InvoiceColumn.HeaderText = "InvoiceStatus"
        Me.InvoiceColumn.Name = "InvoiceColumn"
        Me.InvoiceColumn.Visible = False
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "CustomerID"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.Visible = False
        '
        'EmailSentColumn
        '
        Me.EmailSentColumn.DataPropertyName = "EmailSent"
        Me.EmailSentColumn.HeaderText = "EmailSent"
        Me.EmailSentColumn.Name = "EmailSentColumn"
        Me.EmailSentColumn.Visible = False
        '
        'Label28
        '
        Me.Label28.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label28.ForeColor = System.Drawing.Color.Blue
        Me.Label28.Location = New System.Drawing.Point(959, 531)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(129, 40)
        Me.Label28.TabIndex = 74
        Me.Label28.Text = "Calculate Open Balance from Payment Amount."
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Enabled = False
        Me.cmdSave.Location = New System.Drawing.Point(940, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 84
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'ARPaymentLogBindingSource
        '
        Me.ARPaymentLogBindingSource.DataMember = "ARPaymentLog"
        Me.ARPaymentLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'InvoiceHeaderQueryTableAdapter
        '
        Me.InvoiceHeaderQueryTableAdapter.ClearBeforeFill = True
        '
        'ReturnProductHeaderTableTableAdapter
        '
        Me.ReturnProductHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'ARPaymentLogTableAdapter
        '
        Me.ARPaymentLogTableAdapter.ClearBeforeFill = True
        '
        'GLAccountsTableAdapter
        '
        Me.GLAccountsTableAdapter.ClearBeforeFill = True
        '
        'InvoiceHeaderTableTableAdapter
        '
        Me.InvoiceHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'APCheckLogBindingSource
        '
        Me.APCheckLogBindingSource.DataMember = "APCheckLog"
        Me.APCheckLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'APCheckLogTableAdapter
        '
        Me.APCheckLogTableAdapter.ClearBeforeFill = True
        '
        'BankAccountTypesTableAdapter
        '
        Me.BankAccountTypesTableAdapter.ClearBeforeFill = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmdRemoteScan)
        Me.GroupBox2.Controls.Add(Me.cmdUploadReceipt)
        Me.GroupBox2.Controls.Add(Me.cmdViewReceipt)
        Me.GroupBox2.Controls.Add(Me.cmdScan)
        Me.GroupBox2.Location = New System.Drawing.Point(714, 521)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(183, 234)
        Me.GroupBox2.TabIndex = 88
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cash Receipt"
        '
        'cmdRemoteScan
        '
        Me.cmdRemoteScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRemoteScan.Location = New System.Drawing.Point(55, 101)
        Me.cmdRemoteScan.Name = "cmdRemoteScan"
        Me.cmdRemoteScan.Size = New System.Drawing.Size(71, 40)
        Me.cmdRemoteScan.TabIndex = 89
        Me.cmdRemoteScan.Text = "Scan"
        Me.cmdRemoteScan.UseVisualStyleBackColor = True
        '
        'cmdUploadReceipt
        '
        Me.cmdUploadReceipt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUploadReceipt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUploadReceipt.Location = New System.Drawing.Point(55, 26)
        Me.cmdUploadReceipt.Name = "cmdUploadReceipt"
        Me.cmdUploadReceipt.Size = New System.Drawing.Size(71, 40)
        Me.cmdUploadReceipt.TabIndex = 21
        Me.cmdUploadReceipt.Text = "Upload "
        Me.cmdUploadReceipt.UseVisualStyleBackColor = True
        '
        'cmdViewReceipt
        '
        Me.cmdViewReceipt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewReceipt.Location = New System.Drawing.Point(55, 176)
        Me.cmdViewReceipt.Name = "cmdViewReceipt"
        Me.cmdViewReceipt.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewReceipt.TabIndex = 23
        Me.cmdViewReceipt.Text = "View Pmt.  Receipt"
        Me.cmdViewReceipt.UseVisualStyleBackColor = True
        '
        'cmdScan
        '
        Me.cmdScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdScan.Location = New System.Drawing.Point(55, 101)
        Me.cmdScan.Name = "cmdScan"
        Me.cmdScan.Size = New System.Drawing.Size(71, 40)
        Me.cmdScan.TabIndex = 22
        Me.cmdScan.Text = "Scan"
        Me.cmdScan.UseVisualStyleBackColor = True
        '
        'ARCashReceipts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1252, 823)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.dgvInvoiceHeaderQuery)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.gpxInvoiceData)
        Me.Controls.Add(Me.tabCashReceipts)
        Me.Controls.Add(Me.cmdApplyPayment)
        Me.Controls.Add(Me.gpxPaymentDetails)
        Me.Controls.Add(Me.cmdClearPaymentDetails)
        Me.Controls.Add(Me.gpxApplyFields)
        Me.Controls.Add(Me.cmdDistributePayments)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ARCashReceipts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Cash Receipts"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.tabCashReceipts.ResumeLayout(False)
        Me.tabCheck.ResumeLayout(False)
        Me.tabCheck.PerformLayout()
        Me.tabCreditCard.ResumeLayout(False)
        Me.tabCreditCard.PerformLayout()
        Me.tabAdjustment.ResumeLayout(False)
        Me.tabAdjustment.PerformLayout()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxApplyFields.ResumeLayout(False)
        Me.gpxApplyFields.PerformLayout()
        CType(Me.ReturnProductHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ARPaymentLogBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BankAccountTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxPaymentDetails.ResumeLayout(False)
        Me.gpxPaymentDetails.PerformLayout()
        Me.gpxInvoiceData.ResumeLayout(False)
        Me.gpxInvoiceData.PerformLayout()
        CType(Me.InvoiceHeaderQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInvoiceHeaderQuery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ARPaymentLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APCheckLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmdDistributePayments As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboCardType As System.Windows.Forms.ComboBox
    Friend WithEvents cboTenderType As System.Windows.Forms.ComboBox
    Friend WithEvents gpxApplyFields As System.Windows.Forms.GroupBox
    Friend WithEvents dtpPaymentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdApplyPayment As System.Windows.Forms.Button
    Friend WithEvents cmdClearPaymentDetails As System.Windows.Forms.Button
    Friend WithEvents tabCashReceipts As System.Windows.Forms.TabControl
    Friend WithEvents tabCheck As System.Windows.Forms.TabPage
    Friend WithEvents tabCreditCard As System.Windows.Forms.TabPage
    Friend WithEvents txtCheckNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtReferenceNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCheckComment As System.Windows.Forms.TextBox
    Friend WithEvents txtCreditCardComment As System.Windows.Forms.TextBox
    Friend WithEvents txtAuthorization As System.Windows.Forms.TextBox
    Friend WithEvents txtCardDate As System.Windows.Forms.TextBox
    Friend WithEvents txtCardNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPaymentAmount As System.Windows.Forms.TextBox
    Friend WithEvents rdoCreditMemo As System.Windows.Forms.RadioButton
    Friend WithEvents lblPaymentType As System.Windows.Forms.Label
    Friend WithEvents rdoPayment As System.Windows.Forms.RadioButton
    Friend WithEvents gpxPaymentDetails As System.Windows.Forms.GroupBox
    Friend WithEvents txtOpenBalance As System.Windows.Forms.TextBox
    Friend WithEvents txtPaymentApplied As System.Windows.Forms.TextBox
    Friend WithEvents txtDiscountApplied As System.Windows.Forms.TextBox
    Friend WithEvents txtDistributableAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents InvoiceHeaderQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceHeaderQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderQueryTableAdapter
    Friend WithEvents cboCreditMemo As System.Windows.Forms.ComboBox
    Friend WithEvents ReturnProductHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReturnProductHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReturnProductHeaderTableTableAdapter
    Friend WithEvents ApplyPaymentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtBatchNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboPaymentID As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdGeneratePaymentID As System.Windows.Forms.Button
    Friend WithEvents ARPaymentLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ARPaymentLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARPaymentLogTableAdapter
    Friend WithEvents gpxInvoiceData As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceDiscountApplied As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceAmountOpen As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceDate As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboInvoiceNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtInvoicePaymentApplied As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents dgvInvoiceHeaderQuery As System.Windows.Forms.DataGridView
    Friend WithEvents cmdApplySinglePayment As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tabAdjustment As System.Windows.Forms.TabPage
    Friend WithEvents txtAdjustmentAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cboGLAccountDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboGLAccountNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents chkAdjustment As System.Windows.Forms.CheckBox
    Friend WithEvents GLAccountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cboInvoiceAdjustmentNumber As System.Windows.Forms.ComboBox
    Friend WithEvents InvoiceHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
    Friend WithEvents APCheckLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents APCheckLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APCheckLogTableAdapter
    Friend WithEvents ARPaymentLogBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnableApplyPaymentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboBankAccount As System.Windows.Forms.ComboBox
    Friend WithEvents BankAccountTypesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BankAccountTypesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BankAccountTypesTableAdapter
    Friend WithEvents lblOnHoldStatus As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BankAccountColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalPaymentsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceAmountOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkCheckPayment As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PaymentEntryColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentsAppliedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmailSentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUploadReceipt As System.Windows.Forms.Button
    Friend WithEvents cmdViewReceipt As System.Windows.Forms.Button
    Friend WithEvents cmdScan As System.Windows.Forms.Button
    Friend WithEvents AppendCashReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReUploadReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScanToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdRemoteScan As System.Windows.Forms.Button
End Class
