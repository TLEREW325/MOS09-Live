<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ARProcessPaymentBatch
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
        Me.SaveBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnLockBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AppendBaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ScanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReUploadBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ScanToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxBatchInfo = New System.Windows.Forms.GroupBox
        Me.txtBatchStatus = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdGenerateBatchNumber = New System.Windows.Forms.Button
        Me.txtBatchTotal = New System.Windows.Forms.TextBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtBatchDescription = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpBatchCreationDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboBatchNumber = New System.Windows.Forms.ComboBox
        Me.ARProcessPaymentBatchBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BankAccountTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.gpxBatchTotals = New System.Windows.Forms.GroupBox
        Me.txtUndistributedAmount = New System.Windows.Forms.TextBox
        Me.txtCurrentTotal = New System.Windows.Forms.TextBox
        Me.txtEntryNumber = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdClearBatch = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxPostingProcedure = New System.Windows.Forms.GroupBox
        Me.cmdPostBatch = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.gpxSelectInvoices = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdSelectInvoices = New System.Windows.Forms.Button
        Me.ARCustomerPaymentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ARCustomerPaymentTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARCustomerPaymentTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ARProcessPaymentBatchTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARProcessPaymentBatchTableAdapter
        Me.BankAccountTypesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BankAccountTypesTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboPaymentID = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmdDeletePaymentRecord = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblOpenBatches = New System.Windows.Forms.Label
        Me.cmdUpload = New System.Windows.Forms.Button
        Me.cmdScan = New System.Windows.Forms.Button
        Me.cmdViewReceipt = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdRemoteScan = New System.Windows.Forms.Button
        Me.dgvARCustomerPayments = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BankAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARTransactionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CardNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CardDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AuthorizationNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReferenceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TenderColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CardTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        Me.gpxBatchInfo.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ARProcessPaymentBatchBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BankAccountTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxBatchTotals.SuspendLayout()
        Me.gpxPostingProcedure.SuspendLayout()
        Me.gpxSelectInvoices.SuspendLayout()
        CType(Me.ARCustomerPaymentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvARCustomerPayments, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveBatchToolStripMenuItem, Me.PrintBatchToolStripMenuItem, Me.DeleteBatchToolStripMenuItem, Me.ClearBatchToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveBatchToolStripMenuItem
        '
        Me.SaveBatchToolStripMenuItem.Name = "SaveBatchToolStripMenuItem"
        Me.SaveBatchToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.SaveBatchToolStripMenuItem.Text = "Save Batch"
        '
        'PrintBatchToolStripMenuItem
        '
        Me.PrintBatchToolStripMenuItem.Name = "PrintBatchToolStripMenuItem"
        Me.PrintBatchToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.PrintBatchToolStripMenuItem.Text = "Print Batch"
        '
        'DeleteBatchToolStripMenuItem
        '
        Me.DeleteBatchToolStripMenuItem.Name = "DeleteBatchToolStripMenuItem"
        Me.DeleteBatchToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.DeleteBatchToolStripMenuItem.Text = "Delete Batch"
        '
        'ClearBatchToolStripMenuItem
        '
        Me.ClearBatchToolStripMenuItem.Name = "ClearBatchToolStripMenuItem"
        Me.ClearBatchToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ClearBatchToolStripMenuItem.Text = "Clear Batch"
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
        Me.UnLockBatchToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.UnLockBatchToolStripMenuItem.Text = "Un-Lock Batch"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AppendBaToolStripMenuItem, Me.ReUploadBatchToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'AppendBaToolStripMenuItem
        '
        Me.AppendBaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UploadToolStripMenuItem, Me.ScanToolStripMenuItem})
        Me.AppendBaToolStripMenuItem.Name = "AppendBaToolStripMenuItem"
        Me.AppendBaToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.AppendBaToolStripMenuItem.Text = "Append Batch"
        '
        'UploadToolStripMenuItem
        '
        Me.UploadToolStripMenuItem.Name = "UploadToolStripMenuItem"
        Me.UploadToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.UploadToolStripMenuItem.Text = "Upload"
        '
        'ScanToolStripMenuItem
        '
        Me.ScanToolStripMenuItem.Name = "ScanToolStripMenuItem"
        Me.ScanToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.ScanToolStripMenuItem.Text = "Scan"
        '
        'ReUploadBatchToolStripMenuItem
        '
        Me.ReUploadBatchToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ScanToolStripMenuItem1, Me.UploadToolStripMenuItem1})
        Me.ReUploadBatchToolStripMenuItem.Name = "ReUploadBatchToolStripMenuItem"
        Me.ReUploadBatchToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.ReUploadBatchToolStripMenuItem.Text = "Re-Upload Batch"
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
        'gpxBatchInfo
        '
        Me.gpxBatchInfo.Controls.Add(Me.txtBatchStatus)
        Me.gpxBatchInfo.Controls.Add(Me.Label13)
        Me.gpxBatchInfo.Controls.Add(Me.cmdGenerateBatchNumber)
        Me.gpxBatchInfo.Controls.Add(Me.txtBatchTotal)
        Me.gpxBatchInfo.Controls.Add(Me.cboDivisionID)
        Me.gpxBatchInfo.Controls.Add(Me.txtBatchDescription)
        Me.gpxBatchInfo.Controls.Add(Me.Label6)
        Me.gpxBatchInfo.Controls.Add(Me.Label5)
        Me.gpxBatchInfo.Controls.Add(Me.Label4)
        Me.gpxBatchInfo.Controls.Add(Me.Label3)
        Me.gpxBatchInfo.Controls.Add(Me.dtpBatchCreationDate)
        Me.gpxBatchInfo.Controls.Add(Me.Label1)
        Me.gpxBatchInfo.Controls.Add(Me.cboBatchNumber)
        Me.gpxBatchInfo.Location = New System.Drawing.Point(29, 41)
        Me.gpxBatchInfo.Name = "gpxBatchInfo"
        Me.gpxBatchInfo.Size = New System.Drawing.Size(345, 358)
        Me.gpxBatchInfo.TabIndex = 0
        Me.gpxBatchInfo.TabStop = False
        Me.gpxBatchInfo.Text = "Batch Information"
        '
        'txtBatchStatus
        '
        Me.txtBatchStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchStatus.Enabled = False
        Me.txtBatchStatus.Location = New System.Drawing.Point(144, 263)
        Me.txtBatchStatus.Name = "txtBatchStatus"
        Me.txtBatchStatus.Size = New System.Drawing.Size(178, 20)
        Me.txtBatchStatus.TabIndex = 5
        Me.txtBatchStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(25, 263)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 20)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Batch Status"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdGenerateBatchNumber
        '
        Me.cmdGenerateBatchNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateBatchNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateBatchNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateBatchNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateBatchNumber.Location = New System.Drawing.Point(110, 60)
        Me.cmdGenerateBatchNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateBatchNumber.Name = "cmdGenerateBatchNumber"
        Me.cmdGenerateBatchNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateBatchNumber.TabIndex = 1
        Me.cmdGenerateBatchNumber.TabStop = False
        Me.cmdGenerateBatchNumber.Text = ">>"
        Me.cmdGenerateBatchNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateBatchNumber.UseVisualStyleBackColor = False
        '
        'txtBatchTotal
        '
        Me.txtBatchTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchTotal.Location = New System.Drawing.Point(144, 307)
        Me.txtBatchTotal.Name = "txtBatchTotal"
        Me.txtBatchTotal.Size = New System.Drawing.Size(178, 20)
        Me.txtBatchTotal.TabIndex = 7
        Me.txtBatchTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(140, 27)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(182, 21)
        Me.cboDivisionID.TabIndex = 0
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
        'txtBatchDescription
        '
        Me.txtBatchDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchDescription.Location = New System.Drawing.Point(25, 147)
        Me.txtBatchDescription.Multiline = True
        Me.txtBatchDescription.Name = "txtBatchDescription"
        Me.txtBatchDescription.Size = New System.Drawing.Size(297, 83)
        Me.txtBatchDescription.TabIndex = 4
        Me.txtBatchDescription.Text = "CASH RECEIPTS / CUSTOMER PAYMENTS"
        Me.txtBatchDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(24, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 20)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Batch Creation Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(25, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Batch Description"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(25, 307)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Batch Total"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(24, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Division ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBatchCreationDate
        '
        Me.dtpBatchCreationDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBatchCreationDate.Location = New System.Drawing.Point(140, 91)
        Me.dtpBatchCreationDate.Name = "dtpBatchCreationDate"
        Me.dtpBatchCreationDate.Size = New System.Drawing.Size(182, 20)
        Me.dtpBatchCreationDate.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Batch Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBatchNumber
        '
        Me.cboBatchNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBatchNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBatchNumber.DataSource = Me.ARProcessPaymentBatchBindingSource
        Me.cboBatchNumber.DisplayMember = "BatchNumber"
        Me.cboBatchNumber.FormattingEnabled = True
        Me.cboBatchNumber.Location = New System.Drawing.Point(140, 60)
        Me.cboBatchNumber.Name = "cboBatchNumber"
        Me.cboBatchNumber.Size = New System.Drawing.Size(182, 21)
        Me.cboBatchNumber.TabIndex = 2
        '
        'ARProcessPaymentBatchBindingSource
        '
        Me.ARProcessPaymentBatchBindingSource.DataMember = "ARProcessPaymentBatch"
        Me.ARProcessPaymentBatchBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'BankAccountTypesBindingSource
        '
        Me.BankAccountTypesBindingSource.DataMember = "BankAccountTypes"
        Me.BankAccountTypesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'gpxBatchTotals
        '
        Me.gpxBatchTotals.Controls.Add(Me.txtUndistributedAmount)
        Me.gpxBatchTotals.Controls.Add(Me.txtCurrentTotal)
        Me.gpxBatchTotals.Controls.Add(Me.txtEntryNumber)
        Me.gpxBatchTotals.Controls.Add(Me.Label8)
        Me.gpxBatchTotals.Controls.Add(Me.Label7)
        Me.gpxBatchTotals.Controls.Add(Me.Label9)
        Me.gpxBatchTotals.Location = New System.Drawing.Point(29, 674)
        Me.gpxBatchTotals.Name = "gpxBatchTotals"
        Me.gpxBatchTotals.Size = New System.Drawing.Size(345, 137)
        Me.gpxBatchTotals.TabIndex = 10
        Me.gpxBatchTotals.TabStop = False
        Me.gpxBatchTotals.Text = "Current Batch Totals"
        '
        'txtUndistributedAmount
        '
        Me.txtUndistributedAmount.BackColor = System.Drawing.Color.White
        Me.txtUndistributedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUndistributedAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUndistributedAmount.Enabled = False
        Me.txtUndistributedAmount.Location = New System.Drawing.Point(153, 97)
        Me.txtUndistributedAmount.Name = "txtUndistributedAmount"
        Me.txtUndistributedAmount.ReadOnly = True
        Me.txtUndistributedAmount.Size = New System.Drawing.Size(169, 20)
        Me.txtUndistributedAmount.TabIndex = 12
        Me.txtUndistributedAmount.TabStop = False
        Me.txtUndistributedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCurrentTotal
        '
        Me.txtCurrentTotal.BackColor = System.Drawing.Color.White
        Me.txtCurrentTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCurrentTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCurrentTotal.Enabled = False
        Me.txtCurrentTotal.Location = New System.Drawing.Point(153, 64)
        Me.txtCurrentTotal.Name = "txtCurrentTotal"
        Me.txtCurrentTotal.ReadOnly = True
        Me.txtCurrentTotal.Size = New System.Drawing.Size(169, 20)
        Me.txtCurrentTotal.TabIndex = 11
        Me.txtCurrentTotal.TabStop = False
        Me.txtCurrentTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEntryNumber
        '
        Me.txtEntryNumber.BackColor = System.Drawing.Color.White
        Me.txtEntryNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEntryNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEntryNumber.Enabled = False
        Me.txtEntryNumber.Location = New System.Drawing.Point(153, 31)
        Me.txtEntryNumber.Name = "txtEntryNumber"
        Me.txtEntryNumber.ReadOnly = True
        Me.txtEntryNumber.Size = New System.Drawing.Size(169, 20)
        Me.txtEntryNumber.TabIndex = 10
        Me.txtEntryNumber.TabStop = False
        Me.txtEntryNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(24, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 20)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Current Amount"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(24, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(123, 20)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Undistributed Amount"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(24, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(123, 20)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "# of Entries"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearBatch
        '
        Me.cmdClearBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearBatch.Location = New System.Drawing.Point(520, 771)
        Me.cmdClearBatch.Name = "cmdClearBatch"
        Me.cmdClearBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearBatch.TabIndex = 14
        Me.cmdClearBatch.Text = "Clear Batch"
        Me.cmdClearBatch.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 18
        Me.cmdPrint.Text = "Print Batch"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(905, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 17
        Me.cmdDelete.Text = "Delete Batch"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(828, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 16
        Me.cmdSave.Text = "Save Batch"
        Me.cmdSave.UseVisualStyleBackColor = True
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
        'gpxPostingProcedure
        '
        Me.gpxPostingProcedure.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxPostingProcedure.Controls.Add(Me.cmdPostBatch)
        Me.gpxPostingProcedure.Controls.Add(Me.Label12)
        Me.gpxPostingProcedure.Location = New System.Drawing.Point(828, 636)
        Me.gpxPostingProcedure.Name = "gpxPostingProcedure"
        Me.gpxPostingProcedure.Size = New System.Drawing.Size(302, 121)
        Me.gpxPostingProcedure.TabIndex = 15
        Me.gpxPostingProcedure.TabStop = False
        Me.gpxPostingProcedure.Text = "Post Batch"
        '
        'cmdPostBatch
        '
        Me.cmdPostBatch.ForeColor = System.Drawing.Color.Blue
        Me.cmdPostBatch.Location = New System.Drawing.Point(211, 68)
        Me.cmdPostBatch.Name = "cmdPostBatch"
        Me.cmdPostBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdPostBatch.TabIndex = 15
        Me.cmdPostBatch.Text = "Post Batch"
        Me.cmdPostBatch.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(19, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(263, 61)
        Me.Label12.TabIndex = 89
        Me.Label12.Text = "Batch will post on selected Batch Date. No further changes can be made to Invoice" & _
            "s after Batch is posted."
        '
        'gpxSelectInvoices
        '
        Me.gpxSelectInvoices.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxSelectInvoices.Controls.Add(Me.Label10)
        Me.gpxSelectInvoices.Controls.Add(Me.cmdSelectInvoices)
        Me.gpxSelectInvoices.Location = New System.Drawing.Point(520, 637)
        Me.gpxSelectInvoices.Name = "gpxSelectInvoices"
        Me.gpxSelectInvoices.Size = New System.Drawing.Size(302, 121)
        Me.gpxSelectInvoices.TabIndex = 13
        Me.gpxSelectInvoices.TabStop = False
        Me.gpxSelectInvoices.Text = "Select Invoices to Apply Payments"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(92, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(161, 40)
        Me.Label10.TabIndex = 88
        Me.Label10.Text = "Opens form to select Invoices to apply payments."
        '
        'cmdSelectInvoices
        '
        Me.cmdSelectInvoices.ForeColor = System.Drawing.Color.Blue
        Me.cmdSelectInvoices.Location = New System.Drawing.Point(15, 31)
        Me.cmdSelectInvoices.Name = "cmdSelectInvoices"
        Me.cmdSelectInvoices.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectInvoices.TabIndex = 13
        Me.cmdSelectInvoices.Text = "Select Invoices"
        Me.cmdSelectInvoices.UseVisualStyleBackColor = True
        '
        'ARCustomerPaymentBindingSource
        '
        Me.ARCustomerPaymentBindingSource.DataMember = "ARCustomerPayment"
        Me.ARCustomerPaymentBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ARCustomerPaymentTableAdapter
        '
        Me.ARCustomerPaymentTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ARProcessPaymentBatchTableAdapter
        '
        Me.ARProcessPaymentBatchTableAdapter.ClearBeforeFill = True
        '
        'BankAccountTypesTableAdapter
        '
        Me.BankAccountTypesTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboPaymentID)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.cmdDeletePaymentRecord)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 514)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(345, 143)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Delete Payment From Batch"
        '
        'cboPaymentID
        '
        Me.cboPaymentID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPaymentID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentID.DataSource = Me.ARCustomerPaymentBindingSource
        Me.cboPaymentID.DisplayMember = "ARTransactionKey"
        Me.cboPaymentID.FormattingEnabled = True
        Me.cboPaymentID.Location = New System.Drawing.Point(110, 36)
        Me.cboPaymentID.Name = "cboPaymentID"
        Me.cboPaymentID.Size = New System.Drawing.Size(212, 21)
        Me.cboPaymentID.TabIndex = 8
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(22, 90)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(199, 29)
        Me.Label14.TabIndex = 90
        Me.Label14.Text = "Select Payment Record to delete from Payment Batch."
        '
        'cmdDeletePaymentRecord
        '
        Me.cmdDeletePaymentRecord.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeletePaymentRecord.Location = New System.Drawing.Point(251, 79)
        Me.cmdDeletePaymentRecord.Name = "cmdDeletePaymentRecord"
        Me.cmdDeletePaymentRecord.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeletePaymentRecord.TabIndex = 9
        Me.cmdDeletePaymentRecord.Text = "Delete"
        Me.cmdDeletePaymentRecord.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(25, 37)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Payment ID"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOpenBatches
        '
        Me.lblOpenBatches.ForeColor = System.Drawing.Color.Red
        Me.lblOpenBatches.Location = New System.Drawing.Point(54, 440)
        Me.lblOpenBatches.Name = "lblOpenBatches"
        Me.lblOpenBatches.Size = New System.Drawing.Size(297, 34)
        Me.lblOpenBatches.TabIndex = 20
        Me.lblOpenBatches.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdUpload
        '
        Me.cmdUpload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpload.Location = New System.Drawing.Point(32, 20)
        Me.cmdUpload.Name = "cmdUpload"
        Me.cmdUpload.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpload.TabIndex = 21
        Me.cmdUpload.Text = "Upload Batch"
        Me.cmdUpload.UseVisualStyleBackColor = True
        '
        'cmdScan
        '
        Me.cmdScan.Location = New System.Drawing.Point(32, 71)
        Me.cmdScan.Name = "cmdScan"
        Me.cmdScan.Size = New System.Drawing.Size(71, 40)
        Me.cmdScan.TabIndex = 22
        Me.cmdScan.Text = "Scan Batch"
        Me.cmdScan.UseVisualStyleBackColor = True
        '
        'cmdViewReceipt
        '
        Me.cmdViewReceipt.Location = New System.Drawing.Point(32, 122)
        Me.cmdViewReceipt.Name = "cmdViewReceipt"
        Me.cmdViewReceipt.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewReceipt.TabIndex = 23
        Me.cmdViewReceipt.Text = "View Batch"
        Me.cmdViewReceipt.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmdRemoteScan)
        Me.GroupBox2.Controls.Add(Me.cmdUpload)
        Me.GroupBox2.Controls.Add(Me.cmdViewReceipt)
        Me.GroupBox2.Controls.Add(Me.cmdScan)
        Me.GroupBox2.Location = New System.Drawing.Point(380, 636)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(134, 175)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Batch Receipt"
        '
        'cmdRemoteScan
        '
        Me.cmdRemoteScan.Location = New System.Drawing.Point(32, 71)
        Me.cmdRemoteScan.Name = "cmdRemoteScan"
        Me.cmdRemoteScan.Size = New System.Drawing.Size(71, 40)
        Me.cmdRemoteScan.TabIndex = 25
        Me.cmdRemoteScan.Text = "Scan Batch"
        Me.cmdRemoteScan.UseVisualStyleBackColor = True
        '
        'dgvARCustomerPayments
        '
        Me.dgvARCustomerPayments.AllowUserToAddRows = False
        Me.dgvARCustomerPayments.AllowUserToDeleteRows = False
        Me.dgvARCustomerPayments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvARCustomerPayments.AutoGenerateColumns = False
        Me.dgvARCustomerPayments.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvARCustomerPayments.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvARCustomerPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvARCustomerPayments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.BankAccountColumn, Me.BatchNumberColumn, Me.ARTransactionKeyColumn, Me.CustomerIDColumn, Me.PaymentDateColumn, Me.InvoiceNumberColumn, Me.InvoiceDateColumn, Me.InvoiceAmountColumn, Me.DiscountAmountColumn, Me.PaymentAmountColumn, Me.CheckNumberColumn, Me.CardNumberColumn, Me.CardDateColumn, Me.AuthorizationNumberColumn, Me.ReferenceNumberColumn, Me.CheckCommentColumn, Me.CreditCommentColumn, Me.StatusColumn, Me.TenderColumn, Me.CardTypeColumn, Me.PaymentIDColumn, Me.PaymentTypeColumn})
        Me.dgvARCustomerPayments.DataSource = Me.ARCustomerPaymentBindingSource
        Me.dgvARCustomerPayments.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvARCustomerPayments.Location = New System.Drawing.Point(389, 41)
        Me.dgvARCustomerPayments.Name = "dgvARCustomerPayments"
        Me.dgvARCustomerPayments.Size = New System.Drawing.Size(741, 578)
        Me.dgvARCustomerPayments.TabIndex = 19
        Me.dgvARCustomerPayments.TabStop = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Width = 60
        '
        'BankAccountColumn
        '
        Me.BankAccountColumn.DataPropertyName = "BankAccount"
        Me.BankAccountColumn.HeaderText = "BankAccount"
        Me.BankAccountColumn.Name = "BankAccountColumn"
        Me.BankAccountColumn.Visible = False
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "BatchNumber"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.Visible = False
        '
        'ARTransactionKeyColumn
        '
        Me.ARTransactionKeyColumn.DataPropertyName = "ARTransactionKey"
        Me.ARTransactionKeyColumn.HeaderText = "Payment ID"
        Me.ARTransactionKeyColumn.Name = "ARTransactionKeyColumn"
        Me.ARTransactionKeyColumn.ReadOnly = True
        Me.ARTransactionKeyColumn.Width = 80
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'PaymentDateColumn
        '
        Me.PaymentDateColumn.DataPropertyName = "PaymentDate"
        Me.PaymentDateColumn.HeaderText = "Payment Date"
        Me.PaymentDateColumn.Name = "PaymentDateColumn"
        Me.PaymentDateColumn.ReadOnly = True
        Me.PaymentDateColumn.Width = 85
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
        Me.InvoiceDateColumn.HeaderText = "Invoice Date"
        Me.InvoiceDateColumn.Name = "InvoiceDateColumn"
        Me.InvoiceDateColumn.ReadOnly = True
        Me.InvoiceDateColumn.Width = 85
        '
        'InvoiceAmountColumn
        '
        Me.InvoiceAmountColumn.DataPropertyName = "InvoiceAmount"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.InvoiceAmountColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.InvoiceAmountColumn.HeaderText = "Invoice Amount"
        Me.InvoiceAmountColumn.Name = "InvoiceAmountColumn"
        Me.InvoiceAmountColumn.ReadOnly = True
        Me.InvoiceAmountColumn.Width = 85
        '
        'DiscountAmountColumn
        '
        Me.DiscountAmountColumn.DataPropertyName = "DiscountAmount"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.DiscountAmountColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.DiscountAmountColumn.HeaderText = "Discount Amount"
        Me.DiscountAmountColumn.Name = "DiscountAmountColumn"
        Me.DiscountAmountColumn.ReadOnly = True
        Me.DiscountAmountColumn.Width = 85
        '
        'PaymentAmountColumn
        '
        Me.PaymentAmountColumn.DataPropertyName = "PaymentAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.PaymentAmountColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.PaymentAmountColumn.HeaderText = "Payment Amount"
        Me.PaymentAmountColumn.Name = "PaymentAmountColumn"
        Me.PaymentAmountColumn.ReadOnly = True
        Me.PaymentAmountColumn.Width = 85
        '
        'CheckNumberColumn
        '
        Me.CheckNumberColumn.DataPropertyName = "CheckNumber"
        Me.CheckNumberColumn.HeaderText = "CheckNumber"
        Me.CheckNumberColumn.Name = "CheckNumberColumn"
        Me.CheckNumberColumn.Visible = False
        '
        'CardNumberColumn
        '
        Me.CardNumberColumn.DataPropertyName = "CardNumber"
        Me.CardNumberColumn.HeaderText = "CardNumber"
        Me.CardNumberColumn.Name = "CardNumberColumn"
        Me.CardNumberColumn.Visible = False
        '
        'CardDateColumn
        '
        Me.CardDateColumn.DataPropertyName = "CardDate"
        Me.CardDateColumn.HeaderText = "CardDate"
        Me.CardDateColumn.Name = "CardDateColumn"
        Me.CardDateColumn.Visible = False
        '
        'AuthorizationNumberColumn
        '
        Me.AuthorizationNumberColumn.DataPropertyName = "AuthorizationNumber"
        Me.AuthorizationNumberColumn.HeaderText = "AuthorizationNumber"
        Me.AuthorizationNumberColumn.Name = "AuthorizationNumberColumn"
        Me.AuthorizationNumberColumn.Visible = False
        '
        'ReferenceNumberColumn
        '
        Me.ReferenceNumberColumn.DataPropertyName = "ReferenceNumber"
        Me.ReferenceNumberColumn.HeaderText = "ReferenceNumber"
        Me.ReferenceNumberColumn.Name = "ReferenceNumberColumn"
        Me.ReferenceNumberColumn.Visible = False
        '
        'CheckCommentColumn
        '
        Me.CheckCommentColumn.DataPropertyName = "CheckComment"
        Me.CheckCommentColumn.HeaderText = "CheckComment"
        Me.CheckCommentColumn.Name = "CheckCommentColumn"
        Me.CheckCommentColumn.Visible = False
        '
        'CreditCommentColumn
        '
        Me.CreditCommentColumn.DataPropertyName = "CreditComment"
        Me.CreditCommentColumn.HeaderText = "CreditComment"
        Me.CreditCommentColumn.Name = "CreditCommentColumn"
        Me.CreditCommentColumn.Visible = False
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.Visible = False
        '
        'TenderColumn
        '
        Me.TenderColumn.DataPropertyName = "TenderType"
        Me.TenderColumn.HeaderText = "TenderType"
        Me.TenderColumn.Name = "TenderColumn"
        Me.TenderColumn.Visible = False
        '
        'CardTypeColumn
        '
        Me.CardTypeColumn.DataPropertyName = "CardType"
        Me.CardTypeColumn.HeaderText = "CardType"
        Me.CardTypeColumn.Name = "CardTypeColumn"
        Me.CardTypeColumn.Visible = False
        '
        'PaymentIDColumn
        '
        Me.PaymentIDColumn.DataPropertyName = "PaymentID"
        Me.PaymentIDColumn.HeaderText = "PaymentID"
        Me.PaymentIDColumn.Name = "PaymentIDColumn"
        Me.PaymentIDColumn.Visible = False
        '
        'PaymentTypeColumn
        '
        Me.PaymentTypeColumn.DataPropertyName = "PaymentType"
        Me.PaymentTypeColumn.HeaderText = "PaymentType"
        Me.PaymentTypeColumn.Name = "PaymentTypeColumn"
        Me.PaymentTypeColumn.Visible = False
        '
        'ARProcessPaymentBatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblOpenBatches)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpxSelectInvoices)
        Me.Controls.Add(Me.gpxPostingProcedure)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdClearBatch)
        Me.Controls.Add(Me.gpxBatchTotals)
        Me.Controls.Add(Me.gpxBatchInfo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvARCustomerPayments)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ARProcessPaymentBatch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Process Customer Payment / Cash Receipts Batch"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxBatchInfo.ResumeLayout(False)
        Me.gpxBatchInfo.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ARProcessPaymentBatchBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BankAccountTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxBatchTotals.ResumeLayout(False)
        Me.gpxBatchTotals.PerformLayout()
        Me.gpxPostingProcedure.ResumeLayout(False)
        Me.gpxSelectInvoices.ResumeLayout(False)
        CType(Me.ARCustomerPaymentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvARCustomerPayments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxBatchInfo As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGenerateBatchNumber As System.Windows.Forms.Button
    Friend WithEvents txtBatchTotal As System.Windows.Forms.TextBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents txtBatchDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpBatchCreationDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboBatchNumber As System.Windows.Forms.ComboBox
    Friend WithEvents gpxBatchTotals As System.Windows.Forms.GroupBox
    Friend WithEvents txtUndistributedAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrentTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtEntryNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdClearBatch As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxPostingProcedure As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdPostBatch As System.Windows.Forms.Button
    Friend WithEvents gpxSelectInvoices As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdSelectInvoices As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ARCustomerPaymentBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ARCustomerPaymentTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARCustomerPaymentTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ARProcessPaymentBatchBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ARProcessPaymentBatchTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARProcessPaymentBatchTableAdapter
    Friend WithEvents txtBatchStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents SaveBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BankAccountTypesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BankAccountTypesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BankAccountTypesTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmdDeletePaymentRecord As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboPaymentID As System.Windows.Forms.ComboBox
    Friend WithEvents UnLockBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblOpenBatches As System.Windows.Forms.Label
    Friend WithEvents cmdUpload As System.Windows.Forms.Button
    Friend WithEvents cmdScan As System.Windows.Forms.Button
    Friend WithEvents cmdViewReceipt As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents AppendBaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReUploadBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScanToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvARCustomerPayments As System.Windows.Forms.DataGridView
    Friend WithEvents cmdRemoteScan As System.Windows.Forms.Button
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BankAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ARTransactionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CardNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CardDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AuthorizationNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TenderColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CardTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
