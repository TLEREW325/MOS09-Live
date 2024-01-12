<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewCustomerPaymentActivity
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
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditCashReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AppendToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ScanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReUploadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ScanToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.EditCashBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AppendToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ScanToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ReUploadToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ScanToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxAPVoucherData = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblBatchReceipt = New System.Windows.Forms.Label
        Me.cmdViewBatch = New System.Windows.Forms.Button
        Me.cmdViewReceipts = New System.Windows.Forms.Button
        Me.txtTextSearch = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtPaymentAmount = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtCheckNumber = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboPaymentType = New System.Windows.Forms.ComboBox
        Me.ARCustomerPaymentQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.chkInvoice = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboInvoiceNumber = New System.Windows.Forms.ComboBox
        Me.InvoiceHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkPayment = New System.Windows.Forms.CheckBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvCustomerPayments = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalPaymentsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CardNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CardDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AuthorizationNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReferenceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalDiscountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceAmountOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARTransactionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARCustomerPaymentQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARCustomerPaymentQueryTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.InvoiceHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtTotalPayments = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.gpxAPVoucherData.SuspendLayout()
        CType(Me.ARCustomerPaymentQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCustomerPayments, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem, Me.EditCashReceiptToolStripMenuItem, Me.EditCashBatchToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem
        '
        Me.PrintListingToolStripMenuItem.Name = "PrintListingToolStripMenuItem"
        Me.PrintListingToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.PrintListingToolStripMenuItem.Text = "Print Listing"
        '
        'EditCashReceiptToolStripMenuItem
        '
        Me.EditCashReceiptToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AppendToolStripMenuItem, Me.ReUploadToolStripMenuItem})
        Me.EditCashReceiptToolStripMenuItem.Name = "EditCashReceiptToolStripMenuItem"
        Me.EditCashReceiptToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.EditCashReceiptToolStripMenuItem.Text = "Edit Cash Receipt"
        '
        'AppendToolStripMenuItem
        '
        Me.AppendToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ScanToolStripMenuItem, Me.UploadToolStripMenuItem})
        Me.AppendToolStripMenuItem.Name = "AppendToolStripMenuItem"
        Me.AppendToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AppendToolStripMenuItem.Text = "Append"
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
        'ReUploadToolStripMenuItem
        '
        Me.ReUploadToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ScanToolStripMenuItem1, Me.UploadToolStripMenuItem1})
        Me.ReUploadToolStripMenuItem.Name = "ReUploadToolStripMenuItem"
        Me.ReUploadToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ReUploadToolStripMenuItem.Text = "Re-Upload"
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
        'EditCashBatchToolStripMenuItem
        '
        Me.EditCashBatchToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AppendToolStripMenuItem1, Me.ReUploadToolStripMenuItem1})
        Me.EditCashBatchToolStripMenuItem.Name = "EditCashBatchToolStripMenuItem"
        Me.EditCashBatchToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.EditCashBatchToolStripMenuItem.Text = "Edit Cash Batch"
        '
        'AppendToolStripMenuItem1
        '
        Me.AppendToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ScanToolStripMenuItem2, Me.UploadToolStripMenuItem2})
        Me.AppendToolStripMenuItem1.Name = "AppendToolStripMenuItem1"
        Me.AppendToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.AppendToolStripMenuItem1.Text = "Append"
        '
        'ScanToolStripMenuItem2
        '
        Me.ScanToolStripMenuItem2.Name = "ScanToolStripMenuItem2"
        Me.ScanToolStripMenuItem2.Size = New System.Drawing.Size(152, 22)
        Me.ScanToolStripMenuItem2.Text = "Scan"
        '
        'UploadToolStripMenuItem2
        '
        Me.UploadToolStripMenuItem2.Name = "UploadToolStripMenuItem2"
        Me.UploadToolStripMenuItem2.Size = New System.Drawing.Size(152, 22)
        Me.UploadToolStripMenuItem2.Text = "Upload"
        '
        'ReUploadToolStripMenuItem1
        '
        Me.ReUploadToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ScanToolStripMenuItem3, Me.UploadToolStripMenuItem3})
        Me.ReUploadToolStripMenuItem1.Name = "ReUploadToolStripMenuItem1"
        Me.ReUploadToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ReUploadToolStripMenuItem1.Text = "Re-Upload"
        '
        'ScanToolStripMenuItem3
        '
        Me.ScanToolStripMenuItem3.Name = "ScanToolStripMenuItem3"
        Me.ScanToolStripMenuItem3.Size = New System.Drawing.Size(152, 22)
        Me.ScanToolStripMenuItem3.Text = "Scan"
        '
        'UploadToolStripMenuItem3
        '
        Me.UploadToolStripMenuItem3.Name = "UploadToolStripMenuItem3"
        Me.UploadToolStripMenuItem3.Size = New System.Drawing.Size(152, 22)
        Me.UploadToolStripMenuItem3.Text = "Upload"
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
        'gpxAPVoucherData
        '
        Me.gpxAPVoucherData.Controls.Add(Me.Label17)
        Me.gpxAPVoucherData.Controls.Add(Me.Label16)
        Me.gpxAPVoucherData.Controls.Add(Me.Label15)
        Me.gpxAPVoucherData.Controls.Add(Me.lblBatchReceipt)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdViewBatch)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdViewReceipts)
        Me.gpxAPVoucherData.Controls.Add(Me.txtTextSearch)
        Me.gpxAPVoucherData.Controls.Add(Me.Label11)
        Me.gpxAPVoucherData.Controls.Add(Me.txtPaymentAmount)
        Me.gpxAPVoucherData.Controls.Add(Me.Label10)
        Me.gpxAPVoucherData.Controls.Add(Me.txtCheckNumber)
        Me.gpxAPVoucherData.Controls.Add(Me.Label4)
        Me.gpxAPVoucherData.Controls.Add(Me.Label14)
        Me.gpxAPVoucherData.Controls.Add(Me.chkDateRange)
        Me.gpxAPVoucherData.Controls.Add(Me.Label12)
        Me.gpxAPVoucherData.Controls.Add(Me.cboPaymentType)
        Me.gpxAPVoucherData.Controls.Add(Me.chkInvoice)
        Me.gpxAPVoucherData.Controls.Add(Me.Label7)
        Me.gpxAPVoucherData.Controls.Add(Me.cboCustomerName)
        Me.gpxAPVoucherData.Controls.Add(Me.cboInvoiceNumber)
        Me.gpxAPVoucherData.Controls.Add(Me.Label3)
        Me.gpxAPVoucherData.Controls.Add(Me.chkPayment)
        Me.gpxAPVoucherData.Controls.Add(Me.cboDivisionID)
        Me.gpxAPVoucherData.Controls.Add(Me.dtpEndDate)
        Me.gpxAPVoucherData.Controls.Add(Me.cboCustomerID)
        Me.gpxAPVoucherData.Controls.Add(Me.Label5)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdView)
        Me.gpxAPVoucherData.Controls.Add(Me.dtpBeginDate)
        Me.gpxAPVoucherData.Controls.Add(Me.Label6)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdClear)
        Me.gpxAPVoucherData.Controls.Add(Me.Label2)
        Me.gpxAPVoucherData.Controls.Add(Me.Label1)
        Me.gpxAPVoucherData.Location = New System.Drawing.Point(29, 41)
        Me.gpxAPVoucherData.Name = "gpxAPVoucherData"
        Me.gpxAPVoucherData.Size = New System.Drawing.Size(307, 770)
        Me.gpxAPVoucherData.TabIndex = 0
        Me.gpxAPVoucherData.TabStop = False
        Me.gpxAPVoucherData.Text = "View By Filters"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Yellow
        Me.Label17.Location = New System.Drawing.Point(151, 682)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(107, 13)
        Me.Label17.TabIndex = 49
        Me.Label17.Text = "Cash Batch Receipts"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(151, 701)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 13)
        Me.Label16.TabIndex = 48
        Me.Label16.Text = "Neither Exist"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(151, 663)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 13)
        Me.Label15.TabIndex = 47
        Me.Label15.Text = "Cash Receipt Exists"
        '
        'lblBatchReceipt
        '
        Me.lblBatchReceipt.AutoSize = True
        Me.lblBatchReceipt.ForeColor = System.Drawing.Color.Green
        Me.lblBatchReceipt.Location = New System.Drawing.Point(151, 644)
        Me.lblBatchReceipt.Name = "lblBatchReceipt"
        Me.lblBatchReceipt.Size = New System.Drawing.Size(153, 13)
        Me.lblBatchReceipt.TabIndex = 46
        Me.lblBatchReceipt.Text = "Cash Batch and Receipt Exists"
        '
        'cmdViewBatch
        '
        Me.cmdViewBatch.Enabled = False
        Me.cmdViewBatch.Location = New System.Drawing.Point(80, 723)
        Me.cmdViewBatch.Name = "cmdViewBatch"
        Me.cmdViewBatch.Size = New System.Drawing.Size(73, 39)
        Me.cmdViewBatch.TabIndex = 45
        Me.cmdViewBatch.Text = "View Cash Batch"
        Me.cmdViewBatch.UseVisualStyleBackColor = True
        '
        'cmdViewReceipts
        '
        Me.cmdViewReceipts.Enabled = False
        Me.cmdViewReceipts.Location = New System.Drawing.Point(6, 723)
        Me.cmdViewReceipts.Name = "cmdViewReceipts"
        Me.cmdViewReceipts.Size = New System.Drawing.Size(73, 39)
        Me.cmdViewReceipts.TabIndex = 44
        Me.cmdViewReceipts.Text = "View Cash Receipt"
        Me.cmdViewReceipts.UseVisualStyleBackColor = True
        '
        'txtTextSearch
        '
        Me.txtTextSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextSearch.Location = New System.Drawing.Point(98, 464)
        Me.txtTextSearch.Name = "txtTextSearch"
        Me.txtTextSearch.Size = New System.Drawing.Size(186, 20)
        Me.txtTextSearch.TabIndex = 40
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(18, 464)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "Text Search"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPaymentAmount
        '
        Me.txtPaymentAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaymentAmount.Location = New System.Drawing.Point(98, 406)
        Me.txtPaymentAmount.Name = "txtPaymentAmount"
        Me.txtPaymentAmount.Size = New System.Drawing.Size(186, 20)
        Me.txtPaymentAmount.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(18, 406)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "Payment Amt."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCheckNumber
        '
        Me.txtCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckNumber.Location = New System.Drawing.Point(98, 340)
        Me.txtCheckNumber.Name = "txtCheckNumber"
        Me.txtCheckNumber.Size = New System.Drawing.Size(186, 20)
        Me.txtCheckNumber.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 340)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Check #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(27, 501)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(257, 33)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(97, 549)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 7
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(21, 65)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(263, 42)
        Me.Label12.TabIndex = 34
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPaymentType
        '
        Me.cboPaymentType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPaymentType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentType.DataSource = Me.ARCustomerPaymentQueryBindingSource
        Me.cboPaymentType.DisplayMember = "PaymentType"
        Me.cboPaymentType.FormattingEnabled = True
        Me.cboPaymentType.Location = New System.Drawing.Point(97, 273)
        Me.cboPaymentType.Name = "cboPaymentType"
        Me.cboPaymentType.Size = New System.Drawing.Size(187, 21)
        Me.cboPaymentType.TabIndex = 4
        '
        'ARCustomerPaymentQueryBindingSource
        '
        Me.ARCustomerPaymentQueryBindingSource.DataMember = "ARCustomerPaymentQuery"
        Me.ARCustomerPaymentQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'chkInvoice
        '
        Me.chkInvoice.AutoSize = True
        Me.chkInvoice.Location = New System.Drawing.Point(18, 688)
        Me.chkInvoice.Name = "chkInvoice"
        Me.chkInvoice.Size = New System.Drawing.Size(127, 17)
        Me.chkInvoice.TabIndex = 11
        Me.chkInvoice.Text = "Filter By Invoice Date"
        Me.chkInvoice.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(18, 274)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Payment Type"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.DropDownWidth = 300
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(21, 150)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(263, 21)
        Me.cboCustomerName.TabIndex = 2
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboInvoiceNumber
        '
        Me.cboInvoiceNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInvoiceNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInvoiceNumber.DataSource = Me.InvoiceHeaderTableBindingSource
        Me.cboInvoiceNumber.DisplayMember = "InvoiceNumber"
        Me.cboInvoiceNumber.FormattingEnabled = True
        Me.cboInvoiceNumber.Location = New System.Drawing.Point(97, 206)
        Me.cboInvoiceNumber.Name = "cboInvoiceNumber"
        Me.cboInvoiceNumber.Size = New System.Drawing.Size(187, 21)
        Me.cboInvoiceNumber.TabIndex = 3
        '
        'InvoiceHeaderTableBindingSource
        '
        Me.InvoiceHeaderTableBindingSource.DataMember = "InvoiceHeaderTable"
        Me.InvoiceHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(18, 207)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Invoice #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkPayment
        '
        Me.chkPayment.AutoSize = True
        Me.chkPayment.Checked = True
        Me.chkPayment.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPayment.Location = New System.Drawing.Point(18, 653)
        Me.chkPayment.Name = "chkPayment"
        Me.chkPayment.Size = New System.Drawing.Size(133, 17)
        Me.chkPayment.TabIndex = 10
        Me.chkPayment.Text = "Filter By Payment Date"
        Me.chkPayment.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(96, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(188, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(97, 611)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(187, 20)
        Me.dtpEndDate.TabIndex = 9
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.DropDownWidth = 250
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(96, 119)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(188, 21)
        Me.cboCustomerID.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(15, 611)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "End Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(154, 723)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(73, 39)
        Me.cmdView.TabIndex = 12
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(97, 576)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(187, 20)
        Me.dtpBeginDate.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(15, 576)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Begin Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(228, 723)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(73, 39)
        Me.cmdClear.TabIndex = 13
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Customer ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvCustomerPayments
        '
        Me.dgvCustomerPayments.AllowUserToAddRows = False
        Me.dgvCustomerPayments.AllowUserToDeleteRows = False
        DataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCustomerPayments.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle25
        Me.dgvCustomerPayments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCustomerPayments.AutoGenerateColumns = False
        Me.dgvCustomerPayments.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvCustomerPayments.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCustomerPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCustomerPayments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.BatchNumber, Me.PaymentID, Me.CustomerIDColumn, Me.CheckNumberColumn, Me.InvoiceNumberColumn, Me.InvoiceDateColumn, Me.PaymentDateColumn, Me.InvoiceTotalColumn, Me.PaymentAmountColumn, Me.TotalPaymentsColumn, Me.PaymentTypeColumn, Me.CardNumberColumn, Me.CardDateColumn, Me.AuthorizationNumberColumn, Me.ReferenceNumberColumn, Me.CheckCommentColumn, Me.CreditCommentColumn, Me.StatusColumn, Me.InvoiceStatusColumn, Me.DiscountAmountColumn, Me.TotalDiscountColumn, Me.InvoiceAmountOpenColumn, Me.ARTransactionKeyColumn, Me.InvoiceAmountColumn})
        Me.dgvCustomerPayments.DataSource = Me.ARCustomerPaymentQueryBindingSource
        Me.dgvCustomerPayments.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvCustomerPayments.Location = New System.Drawing.Point(350, 41)
        Me.dgvCustomerPayments.Name = "dgvCustomerPayments"
        Me.dgvCustomerPayments.Size = New System.Drawing.Size(780, 716)
        Me.dgvCustomerPayments.TabIndex = 7
        Me.dgvCustomerPayments.TabStop = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'BatchNumber
        '
        Me.BatchNumber.DataPropertyName = "BatchNumber"
        Me.BatchNumber.HeaderText = "BatchNumber"
        Me.BatchNumber.Name = "BatchNumber"
        Me.BatchNumber.Visible = False
        '
        'PaymentID
        '
        Me.PaymentID.DataPropertyName = "PaymentID"
        Me.PaymentID.HeaderText = "PaymentID"
        Me.PaymentID.Name = "PaymentID"
        Me.PaymentID.Visible = False
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer ID"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'CheckNumberColumn
        '
        Me.CheckNumberColumn.DataPropertyName = "CheckNumber"
        Me.CheckNumberColumn.HeaderText = "Check #"
        Me.CheckNumberColumn.Name = "CheckNumberColumn"
        Me.CheckNumberColumn.Width = 85
        '
        'InvoiceNumberColumn
        '
        Me.InvoiceNumberColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn.HeaderText = "Invoice #"
        Me.InvoiceNumberColumn.Name = "InvoiceNumberColumn"
        Me.InvoiceNumberColumn.ReadOnly = True
        Me.InvoiceNumberColumn.Width = 85
        '
        'InvoiceDateColumn
        '
        Me.InvoiceDateColumn.DataPropertyName = "InvoiceDate"
        DataGridViewCellStyle26.Format = "d"
        DataGridViewCellStyle26.NullValue = Nothing
        Me.InvoiceDateColumn.DefaultCellStyle = DataGridViewCellStyle26
        Me.InvoiceDateColumn.HeaderText = "Invoice Date"
        Me.InvoiceDateColumn.Name = "InvoiceDateColumn"
        Me.InvoiceDateColumn.ReadOnly = True
        Me.InvoiceDateColumn.Width = 85
        '
        'PaymentDateColumn
        '
        Me.PaymentDateColumn.DataPropertyName = "PaymentDate"
        DataGridViewCellStyle27.Format = "d"
        DataGridViewCellStyle27.NullValue = Nothing
        Me.PaymentDateColumn.DefaultCellStyle = DataGridViewCellStyle27
        Me.PaymentDateColumn.HeaderText = "Payment Date"
        Me.PaymentDateColumn.Name = "PaymentDateColumn"
        Me.PaymentDateColumn.ReadOnly = True
        Me.PaymentDateColumn.Width = 85
        '
        'InvoiceTotalColumn
        '
        Me.InvoiceTotalColumn.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle28.Format = "N2"
        DataGridViewCellStyle28.NullValue = "0"
        Me.InvoiceTotalColumn.DefaultCellStyle = DataGridViewCellStyle28
        Me.InvoiceTotalColumn.HeaderText = "Invoice Total"
        Me.InvoiceTotalColumn.Name = "InvoiceTotalColumn"
        Me.InvoiceTotalColumn.ReadOnly = True
        Me.InvoiceTotalColumn.Width = 85
        '
        'PaymentAmountColumn
        '
        Me.PaymentAmountColumn.DataPropertyName = "PaymentAmount"
        DataGridViewCellStyle29.Format = "N2"
        DataGridViewCellStyle29.NullValue = "0"
        Me.PaymentAmountColumn.DefaultCellStyle = DataGridViewCellStyle29
        Me.PaymentAmountColumn.HeaderText = "Payment Amount"
        Me.PaymentAmountColumn.Name = "PaymentAmountColumn"
        Me.PaymentAmountColumn.ReadOnly = True
        Me.PaymentAmountColumn.Width = 85
        '
        'TotalPaymentsColumn
        '
        Me.TotalPaymentsColumn.DataPropertyName = "TotalPayments"
        DataGridViewCellStyle30.Format = "N2"
        DataGridViewCellStyle30.NullValue = "0"
        Me.TotalPaymentsColumn.DefaultCellStyle = DataGridViewCellStyle30
        Me.TotalPaymentsColumn.HeaderText = "Total Payments"
        Me.TotalPaymentsColumn.Name = "TotalPaymentsColumn"
        Me.TotalPaymentsColumn.ReadOnly = True
        Me.TotalPaymentsColumn.Width = 85
        '
        'PaymentTypeColumn
        '
        Me.PaymentTypeColumn.DataPropertyName = "PaymentType"
        Me.PaymentTypeColumn.HeaderText = "Payment Type"
        Me.PaymentTypeColumn.Name = "PaymentTypeColumn"
        Me.PaymentTypeColumn.Width = 85
        '
        'CardNumberColumn
        '
        Me.CardNumberColumn.DataPropertyName = "CardNumber"
        Me.CardNumberColumn.HeaderText = "Card Number"
        Me.CardNumberColumn.Name = "CardNumberColumn"
        '
        'CardDateColumn
        '
        Me.CardDateColumn.DataPropertyName = "CardDate"
        Me.CardDateColumn.HeaderText = "Card Date"
        Me.CardDateColumn.Name = "CardDateColumn"
        '
        'AuthorizationNumberColumn
        '
        Me.AuthorizationNumberColumn.DataPropertyName = "AuthorizationNumber"
        Me.AuthorizationNumberColumn.HeaderText = "Authorization Number"
        Me.AuthorizationNumberColumn.Name = "AuthorizationNumberColumn"
        '
        'ReferenceNumberColumn
        '
        Me.ReferenceNumberColumn.DataPropertyName = "ReferenceNumber"
        Me.ReferenceNumberColumn.HeaderText = "Reference Number"
        Me.ReferenceNumberColumn.Name = "ReferenceNumberColumn"
        '
        'CheckCommentColumn
        '
        Me.CheckCommentColumn.DataPropertyName = "CheckComment"
        Me.CheckCommentColumn.HeaderText = "Check Comment"
        Me.CheckCommentColumn.Name = "CheckCommentColumn"
        '
        'CreditCommentColumn
        '
        Me.CreditCommentColumn.DataPropertyName = "CreditComment"
        Me.CreditCommentColumn.HeaderText = "Credit Comment"
        Me.CreditCommentColumn.Name = "CreditCommentColumn"
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.ReadOnly = True
        Me.StatusColumn.Visible = False
        '
        'InvoiceStatusColumn
        '
        Me.InvoiceStatusColumn.DataPropertyName = "InvoiceStatus"
        Me.InvoiceStatusColumn.HeaderText = "Invoice Status"
        Me.InvoiceStatusColumn.Name = "InvoiceStatusColumn"
        Me.InvoiceStatusColumn.ReadOnly = True
        Me.InvoiceStatusColumn.Visible = False
        '
        'DiscountAmountColumn
        '
        Me.DiscountAmountColumn.DataPropertyName = "DiscountAmount"
        DataGridViewCellStyle31.Format = "N2"
        DataGridViewCellStyle31.NullValue = "0"
        Me.DiscountAmountColumn.DefaultCellStyle = DataGridViewCellStyle31
        Me.DiscountAmountColumn.HeaderText = "Discount Amount"
        Me.DiscountAmountColumn.Name = "DiscountAmountColumn"
        Me.DiscountAmountColumn.ReadOnly = True
        Me.DiscountAmountColumn.Visible = False
        Me.DiscountAmountColumn.Width = 85
        '
        'TotalDiscountColumn
        '
        Me.TotalDiscountColumn.DataPropertyName = "TotalDiscount"
        Me.TotalDiscountColumn.HeaderText = "Total Discount"
        Me.TotalDiscountColumn.Name = "TotalDiscountColumn"
        Me.TotalDiscountColumn.ReadOnly = True
        Me.TotalDiscountColumn.Visible = False
        Me.TotalDiscountColumn.Width = 85
        '
        'InvoiceAmountOpenColumn
        '
        Me.InvoiceAmountOpenColumn.DataPropertyName = "InvoiceAmountOpen"
        Me.InvoiceAmountOpenColumn.HeaderText = "Invoice Amount Open"
        Me.InvoiceAmountOpenColumn.Name = "InvoiceAmountOpenColumn"
        Me.InvoiceAmountOpenColumn.ReadOnly = True
        Me.InvoiceAmountOpenColumn.Visible = False
        Me.InvoiceAmountOpenColumn.Width = 85
        '
        'ARTransactionKeyColumn
        '
        Me.ARTransactionKeyColumn.DataPropertyName = "ARTransactionKey"
        Me.ARTransactionKeyColumn.HeaderText = "AR Trans. #"
        Me.ARTransactionKeyColumn.Name = "ARTransactionKeyColumn"
        Me.ARTransactionKeyColumn.ReadOnly = True
        '
        'InvoiceAmountColumn
        '
        Me.InvoiceAmountColumn.DataPropertyName = "InvoiceAmount"
        DataGridViewCellStyle32.Format = "N2"
        DataGridViewCellStyle32.NullValue = "0"
        Me.InvoiceAmountColumn.DefaultCellStyle = DataGridViewCellStyle32
        Me.InvoiceAmountColumn.HeaderText = "Invoice Amount"
        Me.InvoiceAmountColumn.Name = "InvoiceAmountColumn"
        Me.InvoiceAmountColumn.ReadOnly = True
        Me.InvoiceAmountColumn.Visible = False
        Me.InvoiceAmountColumn.Width = 85
        '
        'ARCustomerPaymentQueryTableAdapter
        '
        Me.ARCustomerPaymentQueryTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'InvoiceHeaderTableTableAdapter
        '
        Me.InvoiceHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 18
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 19
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.Location = New System.Drawing.Point(350, 781)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Total Payments"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalPayments
        '
        Me.txtTotalPayments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalPayments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPayments.Location = New System.Drawing.Point(439, 781)
        Me.txtTotalPayments.Name = "txtTotalPayments"
        Me.txtTotalPayments.Size = New System.Drawing.Size(162, 20)
        Me.txtTotalPayments.TabIndex = 17
        Me.txtTotalPayments.TabStop = False
        Me.txtTotalPayments.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(607, 781)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(139, 20)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "(Total from datagrid)"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewCustomerPaymentActivity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtTotalPayments)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvCustomerPayments)
        Me.Controls.Add(Me.gpxAPVoucherData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewCustomerPaymentActivity"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Customer Payment Activity"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxAPVoucherData.ResumeLayout(False)
        Me.gpxAPVoucherData.PerformLayout()
        CType(Me.ARCustomerPaymentQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCustomerPayments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxAPVoucherData As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboInvoiceNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgvCustomerPayments As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ARCustomerPaymentQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ARCustomerPaymentQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARCustomerPaymentQueryTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents InvoiceHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboPaymentType As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPayments As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkInvoice As System.Windows.Forms.CheckBox
    Friend WithEvents chkPayment As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPaymentAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCheckNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents txtTextSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdViewReceipts As System.Windows.Forms.Button
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalPaymentsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CardNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CardDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AuthorizationNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalDiscountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceAmountOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ARTransactionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdViewBatch As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblBatchReceipt As System.Windows.Forms.Label
    Friend WithEvents EditCashReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppendToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReUploadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditCashBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppendToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReUploadToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScanToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScanToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScanToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
End Class
