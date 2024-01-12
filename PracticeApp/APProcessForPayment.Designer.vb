<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class APProcessForPayment
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
        Me.ClearBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnLockBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxBatchInfo = New System.Windows.Forms.GroupBox
        Me.cboCheckType = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cboVendorClass = New System.Windows.Forms.ComboBox
        Me.lblCheckType = New System.Windows.Forms.Label
        Me.txtBatchStatus = New System.Windows.Forms.TextBox
        Me.cmdGenerateBatchNumber = New System.Windows.Forms.Button
        Me.txtBatchTotal = New System.Windows.Forms.TextBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtBatchDescription = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpBatchCreationDate = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboBatchNumber = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtUndistributedAmount = New System.Windows.Forms.TextBox
        Me.txtCurrentTotal = New System.Windows.Forms.TextBox
        Me.txtEntryNumber = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.gpxSelectionCriteria = New System.Windows.Forms.GroupBox
        Me.dtpDueDate = New System.Windows.Forms.DateTimePicker
        Me.cmdSelectLines = New System.Windows.Forms.Button
        Me.cmdClearGrid = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.ReceiptOfInvoiceBatchLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdPrintChecks = New System.Windows.Forms.Button
        Me.cmdCheckRegister = New System.Windows.Forms.Button
        Me.dgvBatchLines = New System.Windows.Forms.DataGridView
        Me.VendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DueDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiptDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaidDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceSalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceFreightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTermsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WhitePaperColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APVoucherTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReceiptOfInvoiceBatchLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
        Me.APVoucherTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APVoucherTableTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.gpxPostBatch = New System.Windows.Forms.GroupBox
        Me.cmdPostBatch = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.gpxDeleteVoucher = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.cboDeleteLines = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.chkExpenseAccount = New System.Windows.Forms.CheckBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdCreateNewBatch = New System.Windows.Forms.Button
        Me.gpxNewBatch = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmdPrintNewChecks = New System.Windows.Forms.Button
        Me.dgvAPCheckLog = New System.Windows.Forms.DataGridView
        Me.LogCheckNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogCheckAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogCheckDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogDivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogVendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogVendorClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogAPBatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogCheckStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogExtendedCheckColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APCheckLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.APCheckLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APCheckLogTableAdapter
        Me.crxptRemittance1 = New MOS09Program.CRXPTRemittance
        Me.crxapPaymentBatch1 = New MOS09Program.CRXAPPaymentBatch
        Me.cmdGet80ByteFile = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.gpxBatchInfo.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gpxSelectionCriteria.SuspendLayout()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBatchLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APVoucherTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxPostBatch.SuspendLayout()
        Me.gpxDeleteVoucher.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gpxNewBatch.SuspendLayout()
        CType(Me.dgvAPCheckLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APCheckLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveBatchToolStripMenuItem, Me.DeleteBatchToolStripMenuItem, Me.PrintBatchToolStripMenuItem, Me.ClearBatchToolStripMenuItem})
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
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(828, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 27
        Me.cmdSave.Text = "Save Batch"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(905, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 28
        Me.cmdDelete.Text = "Delete Batch"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 29
        Me.cmdPrint.Text = "Print Batch"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 30
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxBatchInfo
        '
        Me.gpxBatchInfo.Controls.Add(Me.cboCheckType)
        Me.gpxBatchInfo.Controls.Add(Me.Label16)
        Me.gpxBatchInfo.Controls.Add(Me.cboVendorClass)
        Me.gpxBatchInfo.Controls.Add(Me.lblCheckType)
        Me.gpxBatchInfo.Controls.Add(Me.txtBatchStatus)
        Me.gpxBatchInfo.Controls.Add(Me.cmdGenerateBatchNumber)
        Me.gpxBatchInfo.Controls.Add(Me.txtBatchTotal)
        Me.gpxBatchInfo.Controls.Add(Me.cboDivisionID)
        Me.gpxBatchInfo.Controls.Add(Me.txtBatchDescription)
        Me.gpxBatchInfo.Controls.Add(Me.Label5)
        Me.gpxBatchInfo.Controls.Add(Me.Label4)
        Me.gpxBatchInfo.Controls.Add(Me.dtpBatchCreationDate)
        Me.gpxBatchInfo.Controls.Add(Me.Label11)
        Me.gpxBatchInfo.Controls.Add(Me.Label6)
        Me.gpxBatchInfo.Controls.Add(Me.cboBatchNumber)
        Me.gpxBatchInfo.Controls.Add(Me.Label1)
        Me.gpxBatchInfo.Controls.Add(Me.Label3)
        Me.gpxBatchInfo.Location = New System.Drawing.Point(29, 41)
        Me.gpxBatchInfo.Name = "gpxBatchInfo"
        Me.gpxBatchInfo.Size = New System.Drawing.Size(295, 344)
        Me.gpxBatchInfo.TabIndex = 0
        Me.gpxBatchInfo.TabStop = False
        Me.gpxBatchInfo.Text = "Batch Information"
        '
        'cboCheckType
        '
        Me.cboCheckType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCheckType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCheckType.FormattingEnabled = True
        Me.cboCheckType.Items.AddRange(New Object() {"STANDARD", "FEDEX", "INTERCOMPANY", "ACH"})
        Me.cboCheckType.Location = New System.Drawing.Point(92, 245)
        Me.cboCheckType.Name = "cboCheckType"
        Me.cboCheckType.Size = New System.Drawing.Size(186, 21)
        Me.cboCheckType.TabIndex = 6
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(18, 246)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(113, 20)
        Me.Label16.TabIndex = 41
        Me.Label16.Text = "Check Type"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorClass
        '
        Me.cboVendorClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorClass.FormattingEnabled = True
        Me.cboVendorClass.Items.AddRange(New Object() {"American", "Canadian"})
        Me.cboVendorClass.Location = New System.Drawing.Point(92, 211)
        Me.cboVendorClass.Name = "cboVendorClass"
        Me.cboVendorClass.Size = New System.Drawing.Size(186, 21)
        Me.cboVendorClass.TabIndex = 5
        '
        'lblCheckType
        '
        Me.lblCheckType.Location = New System.Drawing.Point(18, 212)
        Me.lblCheckType.Name = "lblCheckType"
        Me.lblCheckType.Size = New System.Drawing.Size(113, 20)
        Me.lblCheckType.TabIndex = 39
        Me.lblCheckType.Text = "Vendor Class"
        Me.lblCheckType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBatchStatus
        '
        Me.txtBatchStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchStatus.Location = New System.Drawing.Point(92, 312)
        Me.txtBatchStatus.Name = "txtBatchStatus"
        Me.txtBatchStatus.Size = New System.Drawing.Size(186, 20)
        Me.txtBatchStatus.TabIndex = 8
        Me.txtBatchStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdGenerateBatchNumber
        '
        Me.cmdGenerateBatchNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateBatchNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateBatchNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateBatchNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateBatchNumber.Location = New System.Drawing.Point(66, 25)
        Me.cmdGenerateBatchNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateBatchNumber.Name = "cmdGenerateBatchNumber"
        Me.cmdGenerateBatchNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateBatchNumber.TabIndex = 0
        Me.cmdGenerateBatchNumber.TabStop = False
        Me.cmdGenerateBatchNumber.Text = ">>"
        Me.cmdGenerateBatchNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateBatchNumber.UseVisualStyleBackColor = False
        '
        'txtBatchTotal
        '
        Me.txtBatchTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchTotal.Location = New System.Drawing.Point(92, 279)
        Me.txtBatchTotal.Name = "txtBatchTotal"
        Me.txtBatchTotal.Size = New System.Drawing.Size(186, 20)
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
        Me.cboDivisionID.Location = New System.Drawing.Point(97, 59)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(181, 21)
        Me.cboDivisionID.TabIndex = 2
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
        Me.txtBatchDescription.Location = New System.Drawing.Point(15, 147)
        Me.txtBatchDescription.Multiline = True
        Me.txtBatchDescription.Name = "txtBatchDescription"
        Me.txtBatchDescription.Size = New System.Drawing.Size(263, 46)
        Me.txtBatchDescription.TabIndex = 4
        Me.txtBatchDescription.Text = "PROCESS FOR PAYMENT"
        Me.txtBatchDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Description"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 279)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Batch Total"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBatchCreationDate
        '
        Me.dtpBatchCreationDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBatchCreationDate.Location = New System.Drawing.Point(97, 93)
        Me.dtpBatchCreationDate.Name = "dtpBatchCreationDate"
        Me.dtpBatchCreationDate.Size = New System.Drawing.Size(181, 20)
        Me.dtpBatchCreationDate.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(17, 312)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 20)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Batch Status"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 20)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Batch Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBatchNumber
        '
        Me.cboBatchNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBatchNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBatchNumber.DisplayMember = "BatchNumber"
        Me.cboBatchNumber.FormattingEnabled = True
        Me.cboBatchNumber.Location = New System.Drawing.Point(97, 25)
        Me.cboBatchNumber.Name = "cboBatchNumber"
        Me.cboBatchNumber.Size = New System.Drawing.Size(181, 21)
        Me.cboBatchNumber.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Batch #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Division ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(751, 771)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 26
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtUndistributedAmount)
        Me.GroupBox1.Controls.Add(Me.txtCurrentTotal)
        Me.GroupBox1.Controls.Add(Me.txtEntryNumber)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 586)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(295, 110)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Current Batch Totals"
        '
        'txtUndistributedAmount
        '
        Me.txtUndistributedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUndistributedAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUndistributedAmount.Enabled = False
        Me.txtUndistributedAmount.Location = New System.Drawing.Point(130, 76)
        Me.txtUndistributedAmount.Name = "txtUndistributedAmount"
        Me.txtUndistributedAmount.Size = New System.Drawing.Size(149, 20)
        Me.txtUndistributedAmount.TabIndex = 15
        Me.txtUndistributedAmount.TabStop = False
        Me.txtUndistributedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCurrentTotal
        '
        Me.txtCurrentTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCurrentTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCurrentTotal.Enabled = False
        Me.txtCurrentTotal.Location = New System.Drawing.Point(130, 50)
        Me.txtCurrentTotal.Name = "txtCurrentTotal"
        Me.txtCurrentTotal.Size = New System.Drawing.Size(149, 20)
        Me.txtCurrentTotal.TabIndex = 14
        Me.txtCurrentTotal.TabStop = False
        Me.txtCurrentTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEntryNumber
        '
        Me.txtEntryNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEntryNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEntryNumber.Enabled = False
        Me.txtEntryNumber.Location = New System.Drawing.Point(130, 24)
        Me.txtEntryNumber.Name = "txtEntryNumber"
        Me.txtEntryNumber.Size = New System.Drawing.Size(149, 20)
        Me.txtEntryNumber.TabIndex = 13
        Me.txtEntryNumber.TabStop = False
        Me.txtEntryNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 20)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Total Payments"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(123, 20)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Total Discounts"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "# of Entries"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxSelectionCriteria
        '
        Me.gpxSelectionCriteria.Controls.Add(Me.dtpDueDate)
        Me.gpxSelectionCriteria.Controls.Add(Me.cmdSelectLines)
        Me.gpxSelectionCriteria.Controls.Add(Me.cmdClearGrid)
        Me.gpxSelectionCriteria.Controls.Add(Me.Label10)
        Me.gpxSelectionCriteria.Location = New System.Drawing.Point(29, 702)
        Me.gpxSelectionCriteria.Name = "gpxSelectionCriteria"
        Me.gpxSelectionCriteria.Size = New System.Drawing.Size(295, 109)
        Me.gpxSelectionCriteria.TabIndex = 16
        Me.gpxSelectionCriteria.TabStop = False
        Me.gpxSelectionCriteria.Text = "Select By Due Date"
        '
        'dtpDueDate
        '
        Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDueDate.Location = New System.Drawing.Point(112, 22)
        Me.dtpDueDate.Name = "dtpDueDate"
        Me.dtpDueDate.Size = New System.Drawing.Size(165, 20)
        Me.dtpDueDate.TabIndex = 17
        '
        'cmdSelectLines
        '
        Me.cmdSelectLines.Location = New System.Drawing.Point(129, 57)
        Me.cmdSelectLines.Name = "cmdSelectLines"
        Me.cmdSelectLines.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectLines.TabIndex = 18
        Me.cmdSelectLines.Text = "Select Lines"
        Me.cmdSelectLines.UseVisualStyleBackColor = True
        '
        'cmdClearGrid
        '
        Me.cmdClearGrid.Location = New System.Drawing.Point(206, 57)
        Me.cmdClearGrid.Name = "cmdClearGrid"
        Me.cmdClearGrid.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearGrid.TabIndex = 19
        Me.cmdClearGrid.Text = "Clear"
        Me.cmdClearGrid.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(17, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Select Date"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ReceiptOfInvoiceBatchLineBindingSource
        '
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataMember = "ReceiptOfInvoiceBatchLine"
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdPrintChecks
        '
        Me.cmdPrintChecks.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintChecks.ForeColor = System.Drawing.Color.Blue
        Me.cmdPrintChecks.Location = New System.Drawing.Point(421, 602)
        Me.cmdPrintChecks.Name = "cmdPrintChecks"
        Me.cmdPrintChecks.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintChecks.TabIndex = 21
        Me.cmdPrintChecks.Text = "Print Checks"
        Me.cmdPrintChecks.UseVisualStyleBackColor = True
        '
        'cmdCheckRegister
        '
        Me.cmdCheckRegister.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCheckRegister.ForeColor = System.Drawing.Color.Blue
        Me.cmdCheckRegister.Location = New System.Drawing.Point(344, 602)
        Me.cmdCheckRegister.Name = "cmdCheckRegister"
        Me.cmdCheckRegister.Size = New System.Drawing.Size(71, 40)
        Me.cmdCheckRegister.TabIndex = 20
        Me.cmdCheckRegister.Text = "Check Register"
        Me.cmdCheckRegister.UseVisualStyleBackColor = True
        '
        'dgvBatchLines
        '
        Me.dgvBatchLines.AllowUserToAddRows = False
        Me.dgvBatchLines.AllowUserToDeleteRows = False
        Me.dgvBatchLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBatchLines.AutoGenerateColumns = False
        Me.dgvBatchLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvBatchLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvBatchLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBatchLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VendorIDColumn, Me.InvoiceNumberColumn, Me.InvoiceDateColumn, Me.InvoiceTotalColumn, Me.DueDateColumn, Me.DiscountDateColumn, Me.DiscountAmountColumn, Me.PaymentAmountColumn, Me.PONumberColumn, Me.CommentColumn, Me.CheckTypeColumn, Me.ReceiptDateColumn, Me.PaidDateColumn, Me.InvoiceSalesTaxColumn, Me.InvoiceFreightColumn, Me.ProductTotalColumn, Me.PaymentTermsColumn, Me.DivisionIDColumn, Me.VoucherStatusColumn, Me.BatchNumberColumn, Me.VoucherNumberColumn, Me.WhitePaperColumn})
        Me.dgvBatchLines.DataSource = Me.APVoucherTableBindingSource
        Me.dgvBatchLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvBatchLines.Location = New System.Drawing.Point(344, 41)
        Me.dgvBatchLines.Name = "dgvBatchLines"
        Me.dgvBatchLines.Size = New System.Drawing.Size(786, 555)
        Me.dgvBatchLines.TabIndex = 24
        Me.dgvBatchLines.TabStop = False
        '
        'VendorIDColumn
        '
        Me.VendorIDColumn.DataPropertyName = "VendorID"
        Me.VendorIDColumn.HeaderText = "Vendor"
        Me.VendorIDColumn.Name = "VendorIDColumn"
        Me.VendorIDColumn.ReadOnly = True
        '
        'InvoiceNumberColumn
        '
        Me.InvoiceNumberColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn.HeaderText = "Invoice #"
        Me.InvoiceNumberColumn.Name = "InvoiceNumberColumn"
        Me.InvoiceNumberColumn.ReadOnly = True
        Me.InvoiceNumberColumn.Width = 80
        '
        'InvoiceDateColumn
        '
        Me.InvoiceDateColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumn.HeaderText = "Invoice Date"
        Me.InvoiceDateColumn.Name = "InvoiceDateColumn"
        Me.InvoiceDateColumn.Width = 80
        '
        'InvoiceTotalColumn
        '
        Me.InvoiceTotalColumn.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.InvoiceTotalColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.InvoiceTotalColumn.HeaderText = "Invoice Total"
        Me.InvoiceTotalColumn.Name = "InvoiceTotalColumn"
        Me.InvoiceTotalColumn.Width = 80
        '
        'DueDateColumn
        '
        Me.DueDateColumn.DataPropertyName = "DueDate"
        Me.DueDateColumn.HeaderText = "Due Date"
        Me.DueDateColumn.Name = "DueDateColumn"
        Me.DueDateColumn.Width = 80
        '
        'DiscountDateColumn
        '
        Me.DiscountDateColumn.DataPropertyName = "DiscountDate"
        Me.DiscountDateColumn.HeaderText = "Discount Date"
        Me.DiscountDateColumn.Name = "DiscountDateColumn"
        Me.DiscountDateColumn.Width = 80
        '
        'DiscountAmountColumn
        '
        Me.DiscountAmountColumn.DataPropertyName = "DiscountAmount"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.DiscountAmountColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.DiscountAmountColumn.HeaderText = "Discount Amt."
        Me.DiscountAmountColumn.Name = "DiscountAmountColumn"
        Me.DiscountAmountColumn.Width = 80
        '
        'PaymentAmountColumn
        '
        Me.PaymentAmountColumn.DataPropertyName = "PaymentAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.PaymentAmountColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.PaymentAmountColumn.HeaderText = "Payment Amt."
        Me.PaymentAmountColumn.Name = "PaymentAmountColumn"
        '
        'PONumberColumn
        '
        Me.PONumberColumn.DataPropertyName = "PONumber"
        Me.PONumberColumn.HeaderText = "PO #"
        Me.PONumberColumn.Name = "PONumberColumn"
        Me.PONumberColumn.ReadOnly = True
        Me.PONumberColumn.Width = 80
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'CheckTypeColumn
        '
        Me.CheckTypeColumn.DataPropertyName = "CheckType"
        Me.CheckTypeColumn.HeaderText = "Check Type"
        Me.CheckTypeColumn.Name = "CheckTypeColumn"
        '
        'ReceiptDateColumn
        '
        Me.ReceiptDateColumn.DataPropertyName = "ReceiptDate"
        Me.ReceiptDateColumn.HeaderText = "Receipt Date"
        Me.ReceiptDateColumn.Name = "ReceiptDateColumn"
        Me.ReceiptDateColumn.Width = 80
        '
        'PaidDateColumn
        '
        Me.PaidDateColumn.DataPropertyName = "PaidDate"
        Me.PaidDateColumn.HeaderText = "Paid Date"
        Me.PaidDateColumn.Name = "PaidDateColumn"
        Me.PaidDateColumn.Visible = False
        '
        'InvoiceSalesTaxColumn
        '
        Me.InvoiceSalesTaxColumn.DataPropertyName = "InvoiceSalesTax"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.InvoiceSalesTaxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.InvoiceSalesTaxColumn.HeaderText = "Invoice Sales Tax"
        Me.InvoiceSalesTaxColumn.Name = "InvoiceSalesTaxColumn"
        Me.InvoiceSalesTaxColumn.Visible = False
        '
        'InvoiceFreightColumn
        '
        Me.InvoiceFreightColumn.DataPropertyName = "InvoiceFreight"
        DataGridViewCellStyle5.Format = "C2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.InvoiceFreightColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.InvoiceFreightColumn.HeaderText = "Invoice Freight"
        Me.InvoiceFreightColumn.Name = "InvoiceFreightColumn"
        Me.InvoiceFreightColumn.Visible = False
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.ProductTotalColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.ProductTotalColumn.HeaderText = "Product Total"
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        Me.ProductTotalColumn.Visible = False
        '
        'PaymentTermsColumn
        '
        Me.PaymentTermsColumn.DataPropertyName = "PaymentTerms"
        Me.PaymentTermsColumn.HeaderText = "PaymentTerms"
        Me.PaymentTermsColumn.Name = "PaymentTermsColumn"
        Me.PaymentTermsColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'VoucherStatusColumn
        '
        Me.VoucherStatusColumn.DataPropertyName = "VoucherStatus"
        Me.VoucherStatusColumn.HeaderText = "VoucherStatus"
        Me.VoucherStatusColumn.Name = "VoucherStatusColumn"
        Me.VoucherStatusColumn.Visible = False
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "BatchNumber"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.Visible = False
        '
        'VoucherNumberColumn
        '
        Me.VoucherNumberColumn.DataPropertyName = "VoucherNumber"
        Me.VoucherNumberColumn.HeaderText = "Voucher Number"
        Me.VoucherNumberColumn.Name = "VoucherNumberColumn"
        '
        'WhitePaperColumn
        '
        Me.WhitePaperColumn.DataPropertyName = "WhitePaper"
        Me.WhitePaperColumn.HeaderText = "WhitePaper"
        Me.WhitePaperColumn.Name = "WhitePaperColumn"
        '
        'APVoucherTableBindingSource
        '
        Me.APVoucherTableBindingSource.DataMember = "APVoucherTable"
        Me.APVoucherTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ReceiptOfInvoiceBatchLineTableAdapter
        '
        Me.ReceiptOfInvoiceBatchLineTableAdapter.ClearBeforeFill = True
        '
        'APVoucherTableTableAdapter
        '
        Me.APVoucherTableTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'gpxPostBatch
        '
        Me.gpxPostBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxPostBatch.Controls.Add(Me.cmdPostBatch)
        Me.gpxPostBatch.Controls.Add(Me.Label9)
        Me.gpxPostBatch.Location = New System.Drawing.Point(828, 659)
        Me.gpxPostBatch.Name = "gpxPostBatch"
        Me.gpxPostBatch.Size = New System.Drawing.Size(302, 93)
        Me.gpxPostBatch.TabIndex = 24
        Me.gpxPostBatch.TabStop = False
        Me.gpxPostBatch.Text = "Post Batch"
        '
        'cmdPostBatch
        '
        Me.cmdPostBatch.ForeColor = System.Drawing.Color.Blue
        Me.cmdPostBatch.Location = New System.Drawing.Point(215, 45)
        Me.cmdPostBatch.Name = "cmdPostBatch"
        Me.cmdPostBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdPostBatch.TabIndex = 25
        Me.cmdPostBatch.Text = "Post Batch"
        Me.cmdPostBatch.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(17, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(269, 36)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Batch will be posted according to the Batch Date selected."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxDeleteVoucher
        '
        Me.gpxDeleteVoucher.Controls.Add(Me.Label13)
        Me.gpxDeleteVoucher.Controls.Add(Me.cmdDeleteLine)
        Me.gpxDeleteVoucher.Controls.Add(Me.cboDeleteLines)
        Me.gpxDeleteVoucher.Controls.Add(Me.Label12)
        Me.gpxDeleteVoucher.Location = New System.Drawing.Point(29, 391)
        Me.gpxDeleteVoucher.Name = "gpxDeleteVoucher"
        Me.gpxDeleteVoucher.Size = New System.Drawing.Size(295, 113)
        Me.gpxDeleteVoucher.TabIndex = 9
        Me.gpxDeleteVoucher.TabStop = False
        Me.gpxDeleteVoucher.Text = "Delete Voucher from Check Batch"
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(18, 62)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(173, 40)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Select Voucher from Grid or Drop Down box to delete."
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.Location = New System.Drawing.Point(210, 62)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteLine.TabIndex = 10
        Me.cmdDeleteLine.Text = "Delete"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'cboDeleteLines
        '
        Me.cboDeleteLines.DataSource = Me.APVoucherTableBindingSource
        Me.cboDeleteLines.DisplayMember = "VoucherNumber"
        Me.cboDeleteLines.FormattingEnabled = True
        Me.cboDeleteLines.Location = New System.Drawing.Point(113, 23)
        Me.cboDeleteLines.Name = "cboDeleteLines"
        Me.cboDeleteLines.Size = New System.Drawing.Size(168, 21)
        Me.cboDeleteLines.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(18, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 20)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Voucher Number"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkExpenseAccount
        '
        Me.chkExpenseAccount.AutoSize = True
        Me.chkExpenseAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkExpenseAccount.ForeColor = System.Drawing.Color.Blue
        Me.chkExpenseAccount.Location = New System.Drawing.Point(18, 23)
        Me.chkExpenseAccount.Name = "chkExpenseAccount"
        Me.chkExpenseAccount.Size = New System.Drawing.Size(248, 17)
        Me.chkExpenseAccount.TabIndex = 23
        Me.chkExpenseAccount.Text = "Check for Expense Account (Credit cards, etc.)"
        Me.chkExpenseAccount.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(37, 43)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(335, 42)
        Me.Label14.TabIndex = 39
        Me.Label14.Text = "Check only if you are not processing an actual check. This will credit the expens" & _
            "e account instead of the checking account."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.chkExpenseAccount)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Location = New System.Drawing.Point(344, 656)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(378, 93)
        Me.GroupBox3.TabIndex = 22
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Process Credit Card/Expense Receipts"
        '
        'cmdCreateNewBatch
        '
        Me.cmdCreateNewBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCreateNewBatch.ForeColor = System.Drawing.Color.Blue
        Me.cmdCreateNewBatch.Location = New System.Drawing.Point(209, 19)
        Me.cmdCreateNewBatch.Name = "cmdCreateNewBatch"
        Me.cmdCreateNewBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdCreateNewBatch.TabIndex = 11
        Me.cmdCreateNewBatch.Text = "Create New"
        Me.cmdCreateNewBatch.UseVisualStyleBackColor = True
        '
        'gpxNewBatch
        '
        Me.gpxNewBatch.Controls.Add(Me.Label15)
        Me.gpxNewBatch.Controls.Add(Me.cmdCreateNewBatch)
        Me.gpxNewBatch.Location = New System.Drawing.Point(29, 510)
        Me.gpxNewBatch.Name = "gpxNewBatch"
        Me.gpxNewBatch.Size = New System.Drawing.Size(295, 70)
        Me.gpxNewBatch.TabIndex = 11
        Me.gpxNewBatch.TabStop = False
        Me.gpxNewBatch.Text = "Create New Batch"
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(14, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(189, 40)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "Select Vouchers from Grid to create a new batch. "
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintNewChecks
        '
        Me.cmdPrintNewChecks.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintNewChecks.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdPrintNewChecks.Location = New System.Drawing.Point(421, 602)
        Me.cmdPrintNewChecks.Name = "cmdPrintNewChecks"
        Me.cmdPrintNewChecks.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintNewChecks.TabIndex = 31
        Me.cmdPrintNewChecks.Text = "Print Checks"
        Me.cmdPrintNewChecks.UseVisualStyleBackColor = True
        Me.cmdPrintNewChecks.Visible = False
        '
        'dgvAPCheckLog
        '
        Me.dgvAPCheckLog.AllowUserToAddRows = False
        Me.dgvAPCheckLog.AllowUserToDeleteRows = False
        Me.dgvAPCheckLog.AutoGenerateColumns = False
        Me.dgvAPCheckLog.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAPCheckLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAPCheckLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LogCheckNumberColumn, Me.LogCheckAmountColumn, Me.LogCheckDateColumn, Me.LogDivisionIDColumn, Me.LogVendorIDColumn, Me.LogVendorClassColumn, Me.LogAPBatchNumberColumn, Me.LogCheckStatusColumn, Me.LogExtendedCheckColumn})
        Me.dgvAPCheckLog.DataSource = Me.APCheckLogBindingSource
        Me.dgvAPCheckLog.Location = New System.Drawing.Point(421, 235)
        Me.dgvAPCheckLog.Name = "dgvAPCheckLog"
        Me.dgvAPCheckLog.Size = New System.Drawing.Size(240, 150)
        Me.dgvAPCheckLog.TabIndex = 32
        Me.dgvAPCheckLog.Visible = False
        '
        'LogCheckNumberColumn
        '
        Me.LogCheckNumberColumn.DataPropertyName = "CheckNumber"
        Me.LogCheckNumberColumn.HeaderText = "CheckNumber"
        Me.LogCheckNumberColumn.Name = "LogCheckNumberColumn"
        '
        'LogCheckAmountColumn
        '
        Me.LogCheckAmountColumn.DataPropertyName = "CheckAmount"
        Me.LogCheckAmountColumn.HeaderText = "CheckAmount"
        Me.LogCheckAmountColumn.Name = "LogCheckAmountColumn"
        '
        'LogCheckDateColumn
        '
        Me.LogCheckDateColumn.DataPropertyName = "CheckDate"
        Me.LogCheckDateColumn.HeaderText = "CheckDate"
        Me.LogCheckDateColumn.Name = "LogCheckDateColumn"
        '
        'LogDivisionIDColumn
        '
        Me.LogDivisionIDColumn.DataPropertyName = "DivisionID"
        Me.LogDivisionIDColumn.HeaderText = "DivisionID"
        Me.LogDivisionIDColumn.Name = "LogDivisionIDColumn"
        '
        'LogVendorIDColumn
        '
        Me.LogVendorIDColumn.DataPropertyName = "VendorID"
        Me.LogVendorIDColumn.HeaderText = "VendorID"
        Me.LogVendorIDColumn.Name = "LogVendorIDColumn"
        '
        'LogVendorClassColumn
        '
        Me.LogVendorClassColumn.DataPropertyName = "VendorClass"
        Me.LogVendorClassColumn.HeaderText = "VendorClass"
        Me.LogVendorClassColumn.Name = "LogVendorClassColumn"
        '
        'LogAPBatchNumberColumn
        '
        Me.LogAPBatchNumberColumn.DataPropertyName = "APBatchNumber"
        Me.LogAPBatchNumberColumn.HeaderText = "APBatchNumber"
        Me.LogAPBatchNumberColumn.Name = "LogAPBatchNumberColumn"
        '
        'LogCheckStatusColumn
        '
        Me.LogCheckStatusColumn.DataPropertyName = "CheckStatus"
        Me.LogCheckStatusColumn.HeaderText = "CheckStatus"
        Me.LogCheckStatusColumn.Name = "LogCheckStatusColumn"
        '
        'LogExtendedCheckColumn
        '
        Me.LogExtendedCheckColumn.DataPropertyName = "ExtendedCheck"
        Me.LogExtendedCheckColumn.HeaderText = "ExtendedCheck"
        Me.LogExtendedCheckColumn.Name = "LogExtendedCheckColumn"
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
        'cmdGet80ByteFile
        '
        Me.cmdGet80ByteFile.Location = New System.Drawing.Point(344, 771)
        Me.cmdGet80ByteFile.Name = "cmdGet80ByteFile"
        Me.cmdGet80ByteFile.Size = New System.Drawing.Size(71, 40)
        Me.cmdGet80ByteFile.TabIndex = 76
        Me.cmdGet80ByteFile.Text = "Create 80B File"
        Me.cmdGet80ByteFile.UseVisualStyleBackColor = True
        '
        'APProcessForPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdGet80ByteFile)
        Me.Controls.Add(Me.gpxNewBatch)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.gpxDeleteVoucher)
        Me.Controls.Add(Me.cmdCheckRegister)
        Me.Controls.Add(Me.gpxPostBatch)
        Me.Controls.Add(Me.gpxSelectionCriteria)
        Me.Controls.Add(Me.dgvBatchLines)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpxBatchInfo)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cmdPrintNewChecks)
        Me.Controls.Add(Me.dgvAPCheckLog)
        Me.Controls.Add(Me.cmdPrintChecks)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "APProcessForPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Process Invoices For Payment"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxBatchInfo.ResumeLayout(False)
        Me.gpxBatchInfo.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gpxSelectionCriteria.ResumeLayout(False)
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBatchLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APVoucherTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxPostBatch.ResumeLayout(False)
        Me.gpxDeleteVoucher.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gpxNewBatch.ResumeLayout(False)
        CType(Me.dgvAPCheckLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APCheckLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
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
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ReceiptOfInvoiceBatchLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceBatchLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
    Friend WithEvents gpxSelectionCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdSelectLines As System.Windows.Forms.Button
    Friend WithEvents cmdClearGrid As System.Windows.Forms.Button
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dgvBatchLines As System.Windows.Forms.DataGridView
    Friend WithEvents APVoucherTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents APVoucherTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APVoucherTableTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents gpxPostBatch As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPostBatch As System.Windows.Forms.Button
    Friend WithEvents cmdCheckRegister As System.Windows.Forms.Button
    Friend WithEvents cmdPrintChecks As System.Windows.Forms.Button
    Friend WithEvents SaveBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtBatchStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents gpxDeleteVoucher As System.Windows.Forms.GroupBox
    Friend WithEvents cboDeleteLines As System.Windows.Forms.ComboBox
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkExpenseAccount As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboVendorClass As System.Windows.Forms.ComboBox
    Friend WithEvents lblCheckType As System.Windows.Forms.Label
    Friend WithEvents UnLockBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdCreateNewBatch As System.Windows.Forms.Button
    Friend WithEvents gpxNewBatch As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintNewChecks As System.Windows.Forms.Button
    Friend WithEvents dgvAPCheckLog As System.Windows.Forms.DataGridView
    Friend WithEvents APCheckLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents APCheckLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APCheckLogTableAdapter
    Friend WithEvents LogCheckNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogCheckAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogCheckDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogDivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogVendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogVendorClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogAPBatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogCheckStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogExtendedCheckColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboCheckType As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents crxptRemittance1 As MOS09Program.CRXPTRemittance
    Friend WithEvents crxapPaymentBatch1 As MOS09Program.CRXAPPaymentBatch
    Friend WithEvents cmdGet80ByteFile As System.Windows.Forms.Button
    Friend WithEvents VendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DueDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiptDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaidDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceSalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceFreightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTermsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WhitePaperColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
