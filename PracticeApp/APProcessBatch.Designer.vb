<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class APProcessBatch
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnLockBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ManuallyCloseBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AppendToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReuploadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxBatchInfo = New System.Windows.Forms.GroupBox
        Me.txtBatchStatus = New System.Windows.Forms.TextBox
        Me.txtBatchTotal = New System.Windows.Forms.TextBox
        Me.txtBatchDescription = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmdGenerateBatchNumber = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpBatchCreationDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboBatchNumber = New System.Windows.Forms.ComboBox
        Me.ReceiptOfInvoiceBatchHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtUndistributedAmount = New System.Windows.Forms.TextBox
        Me.txtCurrentTotal = New System.Windows.Forms.TextBox
        Me.txtEntryNumber = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgvBatchItems = New System.Windows.Forms.DataGridView
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DueDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceFreightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceSalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiptDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTermsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherSourceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DeleteReferenceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiptOfInvoiceBatchLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReceiptOfInvoiceBatchLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ReceiptOfInvoiceBatchHeaderTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchHeaderTableAdapter
        Me.cmdOpenAPVoucherForm = New System.Windows.Forms.Button
        Me.cmdOpenAPPOForm = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.gpxPostingProcedure = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmdPostBatch = New System.Windows.Forms.Button
        Me.gpxSelectForm = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblSelectByRecurring = New System.Windows.Forms.Label
        Me.cmdOpenReturn = New System.Windows.Forms.Button
        Me.cmdSelectRecurring = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdSteelBOL = New System.Windows.Forms.Button
        Me.lblRecurringToSelect = New System.Windows.Forms.Label
        Me.tmrRecurringWarning = New System.Windows.Forms.Timer(Me.components)
        Me.grxSteelVoucherForms = New System.Windows.Forms.GroupBox
        Me.cmdSelectSteelReturn = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblOpenBatches = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdSplitSelected = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.gpxBatchInfo.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptOfInvoiceBatchHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvBatchItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxPostingProcedure.SuspendLayout()
        Me.gpxSelectForm.SuspendLayout()
        Me.grxSteelVoucherForms.SuspendLayout()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveBatchToolStripMenuItem, Me.DeleteBatchToolStripMenuItem, Me.PrintBatchToolStripMenuItem, Me.ClearFormToolStripMenuItem})
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
        'DeleteBatchToolStripMenuItem
        '
        Me.DeleteBatchToolStripMenuItem.Name = "DeleteBatchToolStripMenuItem"
        Me.DeleteBatchToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.DeleteBatchToolStripMenuItem.Text = "Delete Batch"
        '
        'PrintBatchToolStripMenuItem
        '
        Me.PrintBatchToolStripMenuItem.Name = "PrintBatchToolStripMenuItem"
        Me.PrintBatchToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.PrintBatchToolStripMenuItem.Text = "Print Batch"
        '
        'ClearFormToolStripMenuItem
        '
        Me.ClearFormToolStripMenuItem.Name = "ClearFormToolStripMenuItem"
        Me.ClearFormToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ClearFormToolStripMenuItem.Text = "Clear Form"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UnLockBatchToolStripMenuItem, Me.ManuallyCloseBatchToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'UnLockBatchToolStripMenuItem
        '
        Me.UnLockBatchToolStripMenuItem.Name = "UnLockBatchToolStripMenuItem"
        Me.UnLockBatchToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.UnLockBatchToolStripMenuItem.Text = "Un-Lock Batch"
        '
        'ManuallyCloseBatchToolStripMenuItem
        '
        Me.ManuallyCloseBatchToolStripMenuItem.Name = "ManuallyCloseBatchToolStripMenuItem"
        Me.ManuallyCloseBatchToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.ManuallyCloseBatchToolStripMenuItem.Text = "Manually Close Batch"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AppendToolStripMenuItem, Me.ReuploadToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'AppendToolStripMenuItem
        '
        Me.AppendToolStripMenuItem.Name = "AppendToolStripMenuItem"
        Me.AppendToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.AppendToolStripMenuItem.Text = "Append"
        '
        'ReuploadToolStripMenuItem
        '
        Me.ReuploadToolStripMenuItem.Name = "ReuploadToolStripMenuItem"
        Me.ReuploadToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.ReuploadToolStripMenuItem.Text = "Reupload"
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
        Me.gpxBatchInfo.Controls.Add(Me.txtBatchTotal)
        Me.gpxBatchInfo.Controls.Add(Me.txtBatchDescription)
        Me.gpxBatchInfo.Controls.Add(Me.Label14)
        Me.gpxBatchInfo.Controls.Add(Me.cmdGenerateBatchNumber)
        Me.gpxBatchInfo.Controls.Add(Me.cmdClear)
        Me.gpxBatchInfo.Controls.Add(Me.cboDivisionID)
        Me.gpxBatchInfo.Controls.Add(Me.Label6)
        Me.gpxBatchInfo.Controls.Add(Me.Label5)
        Me.gpxBatchInfo.Controls.Add(Me.Label4)
        Me.gpxBatchInfo.Controls.Add(Me.Label3)
        Me.gpxBatchInfo.Controls.Add(Me.dtpBatchCreationDate)
        Me.gpxBatchInfo.Controls.Add(Me.Label1)
        Me.gpxBatchInfo.Controls.Add(Me.cboBatchNumber)
        Me.gpxBatchInfo.Location = New System.Drawing.Point(29, 41)
        Me.gpxBatchInfo.Name = "gpxBatchInfo"
        Me.gpxBatchInfo.Size = New System.Drawing.Size(300, 376)
        Me.gpxBatchInfo.TabIndex = 0
        Me.gpxBatchInfo.TabStop = False
        Me.gpxBatchInfo.Text = "Batch Information"
        '
        'txtBatchStatus
        '
        Me.txtBatchStatus.BackColor = System.Drawing.Color.White
        Me.txtBatchStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchStatus.Enabled = False
        Me.txtBatchStatus.Location = New System.Drawing.Point(108, 244)
        Me.txtBatchStatus.Name = "txtBatchStatus"
        Me.txtBatchStatus.ReadOnly = True
        Me.txtBatchStatus.Size = New System.Drawing.Size(178, 20)
        Me.txtBatchStatus.TabIndex = 4
        Me.txtBatchStatus.TabStop = False
        Me.txtBatchStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBatchTotal
        '
        Me.txtBatchTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchTotal.Location = New System.Drawing.Point(108, 281)
        Me.txtBatchTotal.Name = "txtBatchTotal"
        Me.txtBatchTotal.Size = New System.Drawing.Size(178, 20)
        Me.txtBatchTotal.TabIndex = 5
        Me.txtBatchTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBatchDescription
        '
        Me.txtBatchDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchDescription.Location = New System.Drawing.Point(24, 145)
        Me.txtBatchDescription.Multiline = True
        Me.txtBatchDescription.Name = "txtBatchDescription"
        Me.txtBatchDescription.Size = New System.Drawing.Size(262, 83)
        Me.txtBatchDescription.TabIndex = 3
        Me.txtBatchDescription.Text = "RECEIPT OF INVOICE"
        Me.txtBatchDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(25, 242)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 20)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "Batch Status"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(215, 322)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 6
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
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
        Me.cboDivisionID.Size = New System.Drawing.Size(146, 21)
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
        Me.Label5.Location = New System.Drawing.Point(24, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Batch Description"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 279)
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
        Me.dtpBatchCreationDate.Size = New System.Drawing.Size(146, 20)
        Me.dtpBatchCreationDate.TabIndex = 2
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
        Me.cboBatchNumber.DataSource = Me.ReceiptOfInvoiceBatchHeaderBindingSource
        Me.cboBatchNumber.DisplayMember = "BatchNumber"
        Me.cboBatchNumber.FormattingEnabled = True
        Me.cboBatchNumber.Location = New System.Drawing.Point(140, 59)
        Me.cboBatchNumber.Name = "cboBatchNumber"
        Me.cboBatchNumber.Size = New System.Drawing.Size(146, 21)
        Me.cboBatchNumber.TabIndex = 1
        '
        'ReceiptOfInvoiceBatchHeaderBindingSource
        '
        Me.ReceiptOfInvoiceBatchHeaderBindingSource.DataMember = "ReceiptOfInvoiceBatchHeader"
        Me.ReceiptOfInvoiceBatchHeaderBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtUndistributedAmount)
        Me.GroupBox1.Controls.Add(Me.txtCurrentTotal)
        Me.GroupBox1.Controls.Add(Me.txtEntryNumber)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 538)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 124)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Current Batch Totals"
        '
        'txtUndistributedAmount
        '
        Me.txtUndistributedAmount.BackColor = System.Drawing.Color.White
        Me.txtUndistributedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUndistributedAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUndistributedAmount.Enabled = False
        Me.txtUndistributedAmount.Location = New System.Drawing.Point(143, 89)
        Me.txtUndistributedAmount.Name = "txtUndistributedAmount"
        Me.txtUndistributedAmount.ReadOnly = True
        Me.txtUndistributedAmount.Size = New System.Drawing.Size(143, 20)
        Me.txtUndistributedAmount.TabIndex = 9
        Me.txtUndistributedAmount.TabStop = False
        Me.txtUndistributedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCurrentTotal
        '
        Me.txtCurrentTotal.BackColor = System.Drawing.Color.White
        Me.txtCurrentTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCurrentTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCurrentTotal.Enabled = False
        Me.txtCurrentTotal.Location = New System.Drawing.Point(143, 57)
        Me.txtCurrentTotal.Name = "txtCurrentTotal"
        Me.txtCurrentTotal.ReadOnly = True
        Me.txtCurrentTotal.Size = New System.Drawing.Size(143, 20)
        Me.txtCurrentTotal.TabIndex = 8
        Me.txtCurrentTotal.TabStop = False
        Me.txtCurrentTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEntryNumber
        '
        Me.txtEntryNumber.BackColor = System.Drawing.Color.White
        Me.txtEntryNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEntryNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEntryNumber.Enabled = False
        Me.txtEntryNumber.Location = New System.Drawing.Point(143, 25)
        Me.txtEntryNumber.Name = "txtEntryNumber"
        Me.txtEntryNumber.ReadOnly = True
        Me.txtEntryNumber.Size = New System.Drawing.Size(143, 20)
        Me.txtEntryNumber.TabIndex = 7
        Me.txtEntryNumber.TabStop = False
        Me.txtEntryNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(24, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Current Amount"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(25, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 20)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Undistributed Amount"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "# of Entries"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvBatchItems
        '
        Me.dgvBatchItems.AllowUserToAddRows = False
        Me.dgvBatchItems.AllowUserToDeleteRows = False
        Me.dgvBatchItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBatchItems.AutoGenerateColumns = False
        Me.dgvBatchItems.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvBatchItems.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvBatchItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBatchItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceDateColumn, Me.InvoiceNumberColumn, Me.VendorIDColumn, Me.InvoiceTotalColumn, Me.DueDateColumn, Me.DiscountAmountColumn, Me.DiscountDateColumn, Me.PONumberColumn, Me.VoucherNumberColumn, Me.InvoiceFreightColumn, Me.InvoiceAmountColumn, Me.ProductTotalColumn, Me.InvoiceSalesTaxColumn, Me.BatchNumberColumn, Me.ReceiptDateColumn, Me.DivisionIDColumn, Me.VoucherStatusColumn, Me.PaymentTermsColumn, Me.VoucherSourceColumn, Me.DeleteReferenceNumberColumn, Me.VendorClassColumn, Me.CommentColumn})
        Me.dgvBatchItems.DataSource = Me.ReceiptOfInvoiceBatchLineBindingSource
        Me.dgvBatchItems.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvBatchItems.Location = New System.Drawing.Point(347, 41)
        Me.dgvBatchItems.Name = "dgvBatchItems"
        Me.dgvBatchItems.Size = New System.Drawing.Size(782, 546)
        Me.dgvBatchItems.TabIndex = 18
        Me.dgvBatchItems.TabStop = False
        '
        'InvoiceDateColumn
        '
        Me.InvoiceDateColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumn.HeaderText = "Invoice Date"
        Me.InvoiceDateColumn.Name = "InvoiceDateColumn"
        Me.InvoiceDateColumn.Width = 90
        '
        'InvoiceNumberColumn
        '
        Me.InvoiceNumberColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn.HeaderText = "Invoice Number"
        Me.InvoiceNumberColumn.Name = "InvoiceNumberColumn"
        '
        'VendorIDColumn
        '
        Me.VendorIDColumn.DataPropertyName = "VendorID"
        Me.VendorIDColumn.HeaderText = "Vendor ID"
        Me.VendorIDColumn.Name = "VendorIDColumn"
        Me.VendorIDColumn.ReadOnly = True
        '
        'InvoiceTotalColumn
        '
        Me.InvoiceTotalColumn.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.InvoiceTotalColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.InvoiceTotalColumn.HeaderText = "Invoice Total"
        Me.InvoiceTotalColumn.Name = "InvoiceTotalColumn"
        Me.InvoiceTotalColumn.ReadOnly = True
        Me.InvoiceTotalColumn.Width = 90
        '
        'DueDateColumn
        '
        Me.DueDateColumn.DataPropertyName = "DueDate"
        Me.DueDateColumn.HeaderText = "Due Date"
        Me.DueDateColumn.Name = "DueDateColumn"
        '
        'DiscountAmountColumn
        '
        Me.DiscountAmountColumn.DataPropertyName = "DiscountAmount"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.DiscountAmountColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.DiscountAmountColumn.HeaderText = "Discount Amount"
        Me.DiscountAmountColumn.Name = "DiscountAmountColumn"
        '
        'DiscountDateColumn
        '
        Me.DiscountDateColumn.DataPropertyName = "DiscountDate"
        Me.DiscountDateColumn.HeaderText = "Discount Date"
        Me.DiscountDateColumn.Name = "DiscountDateColumn"
        '
        'PONumberColumn
        '
        Me.PONumberColumn.DataPropertyName = "PONumber"
        Me.PONumberColumn.HeaderText = "PO Number"
        Me.PONumberColumn.Name = "PONumberColumn"
        Me.PONumberColumn.ReadOnly = True
        '
        'VoucherNumberColumn
        '
        Me.VoucherNumberColumn.DataPropertyName = "VoucherNumber"
        Me.VoucherNumberColumn.HeaderText = "Voucher Number"
        Me.VoucherNumberColumn.Name = "VoucherNumberColumn"
        Me.VoucherNumberColumn.ReadOnly = True
        '
        'InvoiceFreightColumn
        '
        Me.InvoiceFreightColumn.DataPropertyName = "InvoiceFreight"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.InvoiceFreightColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.InvoiceFreightColumn.HeaderText = "Invoice Freight"
        Me.InvoiceFreightColumn.Name = "InvoiceFreightColumn"
        Me.InvoiceFreightColumn.ReadOnly = True
        Me.InvoiceFreightColumn.Visible = False
        Me.InvoiceFreightColumn.Width = 90
        '
        'InvoiceAmountColumn
        '
        Me.InvoiceAmountColumn.DataPropertyName = "InvoiceAmount"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.InvoiceAmountColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.InvoiceAmountColumn.HeaderText = "Invoice Amount"
        Me.InvoiceAmountColumn.Name = "InvoiceAmountColumn"
        Me.InvoiceAmountColumn.ReadOnly = True
        Me.InvoiceAmountColumn.Visible = False
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.ProductTotalColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.ProductTotalColumn.HeaderText = "Product Total"
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        Me.ProductTotalColumn.ReadOnly = True
        Me.ProductTotalColumn.Visible = False
        Me.ProductTotalColumn.Width = 90
        '
        'InvoiceSalesTaxColumn
        '
        Me.InvoiceSalesTaxColumn.DataPropertyName = "InvoiceSalesTax"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.InvoiceSalesTaxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.InvoiceSalesTaxColumn.HeaderText = "Invoice Sales Tax"
        Me.InvoiceSalesTaxColumn.Name = "InvoiceSalesTaxColumn"
        Me.InvoiceSalesTaxColumn.ReadOnly = True
        Me.InvoiceSalesTaxColumn.Visible = False
        Me.InvoiceSalesTaxColumn.Width = 90
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "BatchNumber"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.ReadOnly = True
        Me.BatchNumberColumn.Visible = False
        '
        'ReceiptDateColumn
        '
        Me.ReceiptDateColumn.DataPropertyName = "ReceiptDate"
        Me.ReceiptDateColumn.HeaderText = "Receipt Date"
        Me.ReceiptDateColumn.Name = "ReceiptDateColumn"
        Me.ReceiptDateColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'VoucherStatusColumn
        '
        Me.VoucherStatusColumn.DataPropertyName = "VoucherStatus"
        Me.VoucherStatusColumn.HeaderText = "VoucherStatus"
        Me.VoucherStatusColumn.Name = "VoucherStatusColumn"
        Me.VoucherStatusColumn.ReadOnly = True
        Me.VoucherStatusColumn.Visible = False
        '
        'PaymentTermsColumn
        '
        Me.PaymentTermsColumn.DataPropertyName = "PaymentTerms"
        Me.PaymentTermsColumn.HeaderText = "Payment Terms"
        Me.PaymentTermsColumn.Name = "PaymentTermsColumn"
        '
        'VoucherSourceColumn
        '
        Me.VoucherSourceColumn.DataPropertyName = "VoucherSource"
        Me.VoucherSourceColumn.HeaderText = "Source"
        Me.VoucherSourceColumn.Name = "VoucherSourceColumn"
        Me.VoucherSourceColumn.ReadOnly = True
        '
        'DeleteReferenceNumberColumn
        '
        Me.DeleteReferenceNumberColumn.DataPropertyName = "DeleteReferenceNumber"
        Me.DeleteReferenceNumberColumn.HeaderText = "Receiver #"
        Me.DeleteReferenceNumberColumn.Name = "DeleteReferenceNumberColumn"
        Me.DeleteReferenceNumberColumn.ReadOnly = True
        '
        'VendorClassColumn
        '
        Me.VendorClassColumn.DataPropertyName = "VendorClass"
        Me.VendorClassColumn.HeaderText = "Vendor Class"
        Me.VendorClassColumn.Name = "VendorClassColumn"
        Me.VendorClassColumn.ReadOnly = True
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'ReceiptOfInvoiceBatchLineBindingSource
        '
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataMember = "ReceiptOfInvoiceBatchLine"
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ReceiptOfInvoiceBatchLineTableAdapter
        '
        Me.ReceiptOfInvoiceBatchLineTableAdapter.ClearBeforeFill = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(979, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 20
        Me.cmdPrint.Text = "Print Batch"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(902, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 19
        Me.cmdDelete.Text = "Delete Batch"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(825, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 18
        Me.cmdSave.Text = "Save Batch"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1056, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 21
        Me.cmdExit.Text = "Exit Batch"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ReceiptOfInvoiceBatchHeaderTableAdapter
        '
        Me.ReceiptOfInvoiceBatchHeaderTableAdapter.ClearBeforeFill = True
        '
        'cmdOpenAPVoucherForm
        '
        Me.cmdOpenAPVoucherForm.ForeColor = System.Drawing.Color.Blue
        Me.cmdOpenAPVoucherForm.Location = New System.Drawing.Point(23, 76)
        Me.cmdOpenAPVoucherForm.Name = "cmdOpenAPVoucherForm"
        Me.cmdOpenAPVoucherForm.Size = New System.Drawing.Size(71, 30)
        Me.cmdOpenAPVoucherForm.TabIndex = 12
        Me.cmdOpenAPVoucherForm.Text = "Select"
        Me.cmdOpenAPVoucherForm.UseVisualStyleBackColor = True
        '
        'cmdOpenAPPOForm
        '
        Me.cmdOpenAPPOForm.ForeColor = System.Drawing.Color.Blue
        Me.cmdOpenAPPOForm.Location = New System.Drawing.Point(23, 29)
        Me.cmdOpenAPPOForm.Name = "cmdOpenAPPOForm"
        Me.cmdOpenAPPOForm.Size = New System.Drawing.Size(71, 30)
        Me.cmdOpenAPPOForm.TabIndex = 11
        Me.cmdOpenAPPOForm.Text = "Select"
        Me.cmdOpenAPPOForm.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(100, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(166, 29)
        Me.Label9.TabIndex = 77
        Me.Label9.Text = "Receipt By PO"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(100, 76)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(166, 29)
        Me.Label10.TabIndex = 78
        Me.Label10.Text = "Receipt By Voucher"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxPostingProcedure
        '
        Me.gpxPostingProcedure.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxPostingProcedure.Controls.Add(Me.Label11)
        Me.gpxPostingProcedure.Controls.Add(Me.cmdPostBatch)
        Me.gpxPostingProcedure.Location = New System.Drawing.Point(824, 603)
        Me.gpxPostingProcedure.Name = "gpxPostingProcedure"
        Me.gpxPostingProcedure.Size = New System.Drawing.Size(305, 70)
        Me.gpxPostingProcedure.TabIndex = 16
        Me.gpxPostingProcedure.TabStop = False
        Me.gpxPostingProcedure.Text = "Post Batch"
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(6, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(209, 20)
        Me.Label11.TabIndex = 78
        Me.Label11.Text = "Batch will post on selected Batch Date."
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPostBatch
        '
        Me.cmdPostBatch.ForeColor = System.Drawing.Color.Blue
        Me.cmdPostBatch.Location = New System.Drawing.Point(221, 19)
        Me.cmdPostBatch.Name = "cmdPostBatch"
        Me.cmdPostBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdPostBatch.TabIndex = 17
        Me.cmdPostBatch.Text = "Post Batch"
        Me.cmdPostBatch.UseVisualStyleBackColor = True
        '
        'gpxSelectForm
        '
        Me.gpxSelectForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxSelectForm.Controls.Add(Me.Label12)
        Me.gpxSelectForm.Controls.Add(Me.lblSelectByRecurring)
        Me.gpxSelectForm.Controls.Add(Me.cmdOpenReturn)
        Me.gpxSelectForm.Controls.Add(Me.cmdSelectRecurring)
        Me.gpxSelectForm.Controls.Add(Me.cmdOpenAPPOForm)
        Me.gpxSelectForm.Controls.Add(Me.Label9)
        Me.gpxSelectForm.Controls.Add(Me.Label10)
        Me.gpxSelectForm.Controls.Add(Me.cmdOpenAPVoucherForm)
        Me.gpxSelectForm.Location = New System.Drawing.Point(347, 603)
        Me.gpxSelectForm.Name = "gpxSelectForm"
        Me.gpxSelectForm.Size = New System.Drawing.Size(360, 208)
        Me.gpxSelectForm.TabIndex = 10
        Me.gpxSelectForm.TabStop = False
        Me.gpxSelectForm.Text = "Select Receipt Of Invoice Voucher Forms"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(100, 124)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(166, 29)
        Me.Label12.TabIndex = 80
        Me.Label12.Text = "Receipt By Return"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSelectByRecurring
        '
        Me.lblSelectByRecurring.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectByRecurring.Location = New System.Drawing.Point(100, 170)
        Me.lblSelectByRecurring.Name = "lblSelectByRecurring"
        Me.lblSelectByRecurring.Size = New System.Drawing.Size(166, 29)
        Me.lblSelectByRecurring.TabIndex = 84
        Me.lblSelectByRecurring.Text = "Select Recurring Voucher"
        Me.lblSelectByRecurring.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdOpenReturn
        '
        Me.cmdOpenReturn.ForeColor = System.Drawing.Color.Blue
        Me.cmdOpenReturn.Location = New System.Drawing.Point(23, 124)
        Me.cmdOpenReturn.Name = "cmdOpenReturn"
        Me.cmdOpenReturn.Size = New System.Drawing.Size(71, 30)
        Me.cmdOpenReturn.TabIndex = 13
        Me.cmdOpenReturn.Text = "Select"
        Me.cmdOpenReturn.UseVisualStyleBackColor = True
        '
        'cmdSelectRecurring
        '
        Me.cmdSelectRecurring.ForeColor = System.Drawing.Color.Blue
        Me.cmdSelectRecurring.Location = New System.Drawing.Point(23, 170)
        Me.cmdSelectRecurring.Name = "cmdSelectRecurring"
        Me.cmdSelectRecurring.Size = New System.Drawing.Size(71, 30)
        Me.cmdSelectRecurring.TabIndex = 15
        Me.cmdSelectRecurring.Text = "Select"
        Me.cmdSelectRecurring.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(107, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(166, 20)
        Me.Label13.TabIndex = 82
        Me.Label13.Text = "Receipt By Steel BOL"
        '
        'cmdSteelBOL
        '
        Me.cmdSteelBOL.ForeColor = System.Drawing.Color.Blue
        Me.cmdSteelBOL.Location = New System.Drawing.Point(27, 41)
        Me.cmdSteelBOL.Name = "cmdSteelBOL"
        Me.cmdSteelBOL.Size = New System.Drawing.Size(71, 30)
        Me.cmdSteelBOL.TabIndex = 14
        Me.cmdSteelBOL.Text = "Select"
        Me.cmdSteelBOL.UseVisualStyleBackColor = True
        '
        'lblRecurringToSelect
        '
        Me.lblRecurringToSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecurringToSelect.ForeColor = System.Drawing.Color.Red
        Me.lblRecurringToSelect.Location = New System.Drawing.Point(54, 440)
        Me.lblRecurringToSelect.Name = "lblRecurringToSelect"
        Me.lblRecurringToSelect.Size = New System.Drawing.Size(261, 59)
        Me.lblRecurringToSelect.TabIndex = 16
        Me.lblRecurringToSelect.Text = "There are recurring vouchers to select"
        Me.lblRecurringToSelect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRecurringToSelect.Visible = False
        '
        'tmrRecurringWarning
        '
        Me.tmrRecurringWarning.Interval = 2000
        '
        'grxSteelVoucherForms
        '
        Me.grxSteelVoucherForms.Controls.Add(Me.cmdSelectSteelReturn)
        Me.grxSteelVoucherForms.Controls.Add(Me.Label15)
        Me.grxSteelVoucherForms.Controls.Add(Me.cmdSteelBOL)
        Me.grxSteelVoucherForms.Controls.Add(Me.Label13)
        Me.grxSteelVoucherForms.Location = New System.Drawing.Point(29, 679)
        Me.grxSteelVoucherForms.Name = "grxSteelVoucherForms"
        Me.grxSteelVoucherForms.Size = New System.Drawing.Size(300, 132)
        Me.grxSteelVoucherForms.TabIndex = 22
        Me.grxSteelVoucherForms.TabStop = False
        Me.grxSteelVoucherForms.Text = "Select Receipt Of Invoice Steel Voucher Forms"
        '
        'cmdSelectSteelReturn
        '
        Me.cmdSelectSteelReturn.ForeColor = System.Drawing.Color.Blue
        Me.cmdSelectSteelReturn.Location = New System.Drawing.Point(27, 84)
        Me.cmdSelectSteelReturn.Name = "cmdSelectSteelReturn"
        Me.cmdSelectSteelReturn.Size = New System.Drawing.Size(71, 30)
        Me.cmdSelectSteelReturn.TabIndex = 83
        Me.cmdSelectSteelReturn.Text = "Select"
        Me.cmdSelectSteelReturn.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(107, 91)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(166, 20)
        Me.Label15.TabIndex = 84
        Me.Label15.Text = "Receipt by Steel Return"
        '
        'lblOpenBatches
        '
        Me.lblOpenBatches.ForeColor = System.Drawing.Color.Blue
        Me.lblOpenBatches.Location = New System.Drawing.Point(54, 420)
        Me.lblOpenBatches.Name = "lblOpenBatches"
        Me.lblOpenBatches.Size = New System.Drawing.Size(261, 20)
        Me.lblOpenBatches.TabIndex = 10
        Me.lblOpenBatches.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.cmdSplitSelected)
        Me.GroupBox2.Location = New System.Drawing.Point(824, 679)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(305, 70)
        Me.GroupBox2.TabIndex = 79
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Split Selected"
        '
        'Label16
        '
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(6, 29)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(209, 20)
        Me.Label16.TabIndex = 78
        Me.Label16.Text = "Splits the selected lines into a new batch"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSplitSelected
        '
        Me.cmdSplitSelected.ForeColor = System.Drawing.Color.Black
        Me.cmdSplitSelected.Location = New System.Drawing.Point(221, 19)
        Me.cmdSplitSelected.Name = "cmdSplitSelected"
        Me.cmdSplitSelected.Size = New System.Drawing.Size(71, 40)
        Me.cmdSplitSelected.TabIndex = 17
        Me.cmdSplitSelected.Text = "Split Selected"
        Me.cmdSplitSelected.UseVisualStyleBackColor = True
        '
        'APProcessBatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblOpenBatches)
        Me.Controls.Add(Me.grxSteelVoucherForms)
        Me.Controls.Add(Me.lblRecurringToSelect)
        Me.Controls.Add(Me.gpxSelectForm)
        Me.Controls.Add(Me.gpxPostingProcedure)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvBatchItems)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpxBatchInfo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "APProcessBatch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation AP Batch Processing"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxBatchInfo.ResumeLayout(False)
        Me.gpxBatchInfo.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptOfInvoiceBatchHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvBatchItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxPostingProcedure.ResumeLayout(False)
        Me.gpxSelectForm.ResumeLayout(False)
        Me.grxSteelVoucherForms.ResumeLayout(False)
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
    Friend WithEvents gpxBatchInfo As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGenerateBatchNumber As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUndistributedAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrentTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtEntryNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvBatchItems As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ReceiptOfInvoiceBatchLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceBatchLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ReceiptOfInvoiceBatchHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceBatchHeaderTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchHeaderTableAdapter
    Friend WithEvents ReceiverNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdOpenAPVoucherForm As System.Windows.Forms.Button
    Friend WithEvents cmdOpenAPPOForm As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents gpxPostingProcedure As System.Windows.Forms.GroupBox
    Friend WithEvents gpxSelectForm As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPostBatch As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdOpenReturn As System.Windows.Forms.Button
    Friend WithEvents cmdSteelBOL As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtBatchStatus As System.Windows.Forms.TextBox
    Friend WithEvents SaveBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblSelectByRecurring As System.Windows.Forms.Label
    Friend WithEvents cmdSelectRecurring As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblRecurringToSelect As System.Windows.Forms.Label
    Friend WithEvents tmrRecurringWarning As System.Windows.Forms.Timer
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DueDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceFreightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceSalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiptDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTermsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherSourceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeleteReferenceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grxSteelVoucherForms As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSelectSteelReturn As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents UnLockBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblOpenBatches As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdSplitSelected As System.Windows.Forms.Button
    Friend WithEvents ManuallyCloseBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppendToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReuploadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
