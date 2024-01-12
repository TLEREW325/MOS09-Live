<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ARProcessBatch
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gpxBatchInfo = New System.Windows.Forms.GroupBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.dtpBatchCreationDate = New System.Windows.Forms.DateTimePicker
        Me.cboBatchNumber = New System.Windows.Forms.ComboBox
        Me.txtBatchStatus = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmdGenerateBatchNumber = New System.Windows.Forms.Button
        Me.txtBatchTotal = New System.Windows.Forms.TextBox
        Me.txtBatchDescription = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
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
        Me.gpxBatchTotals = New System.Windows.Forms.GroupBox
        Me.txtUndistributedAmount = New System.Windows.Forms.TextBox
        Me.txtCurrentTotal = New System.Windows.Forms.TextBox
        Me.txtEntryNumber = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.gpxPostingProcedure = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmdPrintAll = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmdPrintCerts = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdPostBatch = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvInvoiceHeaders = New System.Windows.Forms.DataGridView
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SpecialInstructionsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTAddress1Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTAddress2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTCityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTStateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTZipColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTCountryColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BilledFreightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTermsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DropShipPONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTax2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTax3Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOBColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTerms = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShipmentHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShipmentHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.InvoiceHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
        Me.cmdSelectShipments = New System.Windows.Forms.Button
        Me.gpxSelectShipmentsCredits = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdSelectReturns = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdEditInvoices = New System.Windows.Forms.Button
        Me.cmdClearBatch = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblPendingReturns = New System.Windows.Forms.Label
        Me.lblOpenBatches = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.cboInvoiceNumber = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmdDeleteInvoice = New System.Windows.Forms.Button
        Me.lblOpenBillOnly = New System.Windows.Forms.Label
        Me.dgvInvoiceSerialLines = New System.Windows.Forms.DataGridView
        Me.SNInvoiceHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SNInvoiceLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SNPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SNDivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SNCustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SNInvoiceSerialNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SNSerialNumberCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceLineSerialNumberQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InvoiceLineSerialNumberQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceLineSerialNumberQueryTableAdapter
        Me.Label19 = New System.Windows.Forms.Label
        Me.cmdSplitBatch = New System.Windows.Forms.Button
        Me.gpxSplitBatch = New System.Windows.Forms.GroupBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.cboTime = New System.Windows.Forms.ComboBox
        Me.cboDay = New System.Windows.Forms.ComboBox
        Me.cmdSchedule = New System.Windows.Forms.Button
        Me.crxInvoiceTFF1 = New MOS09Program.CRXInvoiceTFF
        Me.crxInvoiceTFP1 = New MOS09Program.CRXInvoiceTFP
        Me.crxInvoice1 = New MOS09Program.CRXInvoice
        Me.gpxBatchInfo.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.gpxBatchTotals.SuspendLayout()
        Me.gpxPostingProcedure.SuspendLayout()
        CType(Me.dgvInvoiceHeaders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxSelectShipmentsCredits.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvInvoiceSerialLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceLineSerialNumberQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxSplitBatch.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpxBatchInfo
        '
        Me.gpxBatchInfo.Controls.Add(Me.cboDivisionID)
        Me.gpxBatchInfo.Controls.Add(Me.dtpBatchCreationDate)
        Me.gpxBatchInfo.Controls.Add(Me.cboBatchNumber)
        Me.gpxBatchInfo.Controls.Add(Me.txtBatchStatus)
        Me.gpxBatchInfo.Controls.Add(Me.Label14)
        Me.gpxBatchInfo.Controls.Add(Me.cmdGenerateBatchNumber)
        Me.gpxBatchInfo.Controls.Add(Me.txtBatchTotal)
        Me.gpxBatchInfo.Controls.Add(Me.txtBatchDescription)
        Me.gpxBatchInfo.Controls.Add(Me.Label6)
        Me.gpxBatchInfo.Controls.Add(Me.Label5)
        Me.gpxBatchInfo.Controls.Add(Me.Label4)
        Me.gpxBatchInfo.Controls.Add(Me.Label3)
        Me.gpxBatchInfo.Controls.Add(Me.Label1)
        Me.gpxBatchInfo.Location = New System.Drawing.Point(29, 41)
        Me.gpxBatchInfo.Name = "gpxBatchInfo"
        Me.gpxBatchInfo.Size = New System.Drawing.Size(300, 303)
        Me.gpxBatchInfo.TabIndex = 0
        Me.gpxBatchInfo.TabStop = False
        Me.gpxBatchInfo.Text = "Batch Information"
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(117, 27)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(166, 21)
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
        'dtpBatchCreationDate
        '
        Me.dtpBatchCreationDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBatchCreationDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBatchCreationDate.Location = New System.Drawing.Point(117, 89)
        Me.dtpBatchCreationDate.Name = "dtpBatchCreationDate"
        Me.dtpBatchCreationDate.Size = New System.Drawing.Size(166, 20)
        Me.dtpBatchCreationDate.TabIndex = 3
        '
        'cboBatchNumber
        '
        Me.cboBatchNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBatchNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBatchNumber.DisplayMember = "BatchNumber"
        Me.cboBatchNumber.FormattingEnabled = True
        Me.cboBatchNumber.Location = New System.Drawing.Point(117, 58)
        Me.cboBatchNumber.Name = "cboBatchNumber"
        Me.cboBatchNumber.Size = New System.Drawing.Size(166, 21)
        Me.cboBatchNumber.TabIndex = 2
        '
        'txtBatchStatus
        '
        Me.txtBatchStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchStatus.Enabled = False
        Me.txtBatchStatus.Location = New System.Drawing.Point(117, 233)
        Me.txtBatchStatus.Name = "txtBatchStatus"
        Me.txtBatchStatus.Size = New System.Drawing.Size(166, 20)
        Me.txtBatchStatus.TabIndex = 5
        Me.txtBatchStatus.TabStop = False
        Me.txtBatchStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(25, 233)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 20)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Batch Status"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdGenerateBatchNumber
        '
        Me.cmdGenerateBatchNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateBatchNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateBatchNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateBatchNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateBatchNumber.Location = New System.Drawing.Point(84, 58)
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
        Me.txtBatchTotal.Location = New System.Drawing.Point(117, 268)
        Me.txtBatchTotal.Name = "txtBatchTotal"
        Me.txtBatchTotal.Size = New System.Drawing.Size(166, 20)
        Me.txtBatchTotal.TabIndex = 5
        Me.txtBatchTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBatchDescription
        '
        Me.txtBatchDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchDescription.Location = New System.Drawing.Point(25, 145)
        Me.txtBatchDescription.Multiline = True
        Me.txtBatchDescription.Name = "txtBatchDescription"
        Me.txtBatchDescription.Size = New System.Drawing.Size(258, 68)
        Me.txtBatchDescription.TabIndex = 4
        Me.txtBatchDescription.Text = "AR INVOICE PROCESSING"
        Me.txtBatchDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(24, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 20)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Batch Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(25, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Batch Description"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(25, 268)
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
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(25, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Batch #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 3
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
        'gpxBatchTotals
        '
        Me.gpxBatchTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gpxBatchTotals.Controls.Add(Me.txtUndistributedAmount)
        Me.gpxBatchTotals.Controls.Add(Me.txtCurrentTotal)
        Me.gpxBatchTotals.Controls.Add(Me.txtEntryNumber)
        Me.gpxBatchTotals.Controls.Add(Me.Label8)
        Me.gpxBatchTotals.Controls.Add(Me.Label7)
        Me.gpxBatchTotals.Controls.Add(Me.Label2)
        Me.gpxBatchTotals.Location = New System.Drawing.Point(29, 678)
        Me.gpxBatchTotals.Name = "gpxBatchTotals"
        Me.gpxBatchTotals.Size = New System.Drawing.Size(300, 129)
        Me.gpxBatchTotals.TabIndex = 5
        Me.gpxBatchTotals.TabStop = False
        Me.gpxBatchTotals.Text = "Current Batch Totals"
        '
        'txtUndistributedAmount
        '
        Me.txtUndistributedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUndistributedAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUndistributedAmount.Enabled = False
        Me.txtUndistributedAmount.Location = New System.Drawing.Point(143, 95)
        Me.txtUndistributedAmount.Name = "txtUndistributedAmount"
        Me.txtUndistributedAmount.Size = New System.Drawing.Size(140, 20)
        Me.txtUndistributedAmount.TabIndex = 8
        Me.txtUndistributedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCurrentTotal
        '
        Me.txtCurrentTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCurrentTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCurrentTotal.Enabled = False
        Me.txtCurrentTotal.Location = New System.Drawing.Point(143, 62)
        Me.txtCurrentTotal.Name = "txtCurrentTotal"
        Me.txtCurrentTotal.Size = New System.Drawing.Size(140, 20)
        Me.txtCurrentTotal.TabIndex = 7
        Me.txtCurrentTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEntryNumber
        '
        Me.txtEntryNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEntryNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEntryNumber.Enabled = False
        Me.txtEntryNumber.Location = New System.Drawing.Point(143, 29)
        Me.txtEntryNumber.Name = "txtEntryNumber"
        Me.txtEntryNumber.Size = New System.Drawing.Size(140, 20)
        Me.txtEntryNumber.TabIndex = 6
        Me.txtEntryNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(25, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 20)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Current Amount"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(25, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(123, 20)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Undistributed Amount"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "# of Entries"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxPostingProcedure
        '
        Me.gpxPostingProcedure.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxPostingProcedure.Controls.Add(Me.Label11)
        Me.gpxPostingProcedure.Controls.Add(Me.cmdPrintAll)
        Me.gpxPostingProcedure.Controls.Add(Me.Label16)
        Me.gpxPostingProcedure.Controls.Add(Me.Label15)
        Me.gpxPostingProcedure.Controls.Add(Me.cmdPrintCerts)
        Me.gpxPostingProcedure.Controls.Add(Me.Label12)
        Me.gpxPostingProcedure.Controls.Add(Me.cmdPrint)
        Me.gpxPostingProcedure.Controls.Add(Me.cmdPostBatch)
        Me.gpxPostingProcedure.Location = New System.Drawing.Point(860, 560)
        Me.gpxPostingProcedure.Name = "gpxPostingProcedure"
        Me.gpxPostingProcedure.Size = New System.Drawing.Size(270, 200)
        Me.gpxPostingProcedure.TabIndex = 85
        Me.gpxPostingProcedure.TabStop = False
        Me.gpxPostingProcedure.Text = "Print Invoices / Certs / Post Batch"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(19, 113)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(173, 29)
        Me.Label11.TabIndex = 94
        Me.Label11.Text = "Auto-print invoices and certs."
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintAll
        '
        Me.cmdPrintAll.ForeColor = System.Drawing.Color.Blue
        Me.cmdPrintAll.Location = New System.Drawing.Point(186, 106)
        Me.cmdPrintAll.Name = "cmdPrintAll"
        Me.cmdPrintAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintAll.TabIndex = 93
        Me.cmdPrintAll.Text = "Print All"
        Me.cmdPrintAll.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(19, 62)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(161, 40)
        Me.Label16.TabIndex = 92
        Me.Label16.Text = "Prints all Certs in Batch (auto-print)."
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(19, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(149, 29)
        Me.Label15.TabIndex = 91
        Me.Label15.Text = "Prints all Invoices in Batch."
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintCerts
        '
        Me.cmdPrintCerts.ForeColor = System.Drawing.Color.Blue
        Me.cmdPrintCerts.Location = New System.Drawing.Point(186, 62)
        Me.cmdPrintCerts.Name = "cmdPrintCerts"
        Me.cmdPrintCerts.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintCerts.TabIndex = 90
        Me.cmdPrintCerts.Text = "Certs"
        Me.cmdPrintCerts.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(19, 157)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(149, 29)
        Me.Label12.TabIndex = 89
        Me.Label12.Text = "No further changes can be made after Batch is posted."
        '
        'cmdPrint
        '
        Me.cmdPrint.ForeColor = System.Drawing.Color.Blue
        Me.cmdPrint.Location = New System.Drawing.Point(186, 18)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 18
        Me.cmdPrint.Text = "Invoices"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdPostBatch
        '
        Me.cmdPostBatch.ForeColor = System.Drawing.Color.Blue
        Me.cmdPostBatch.Location = New System.Drawing.Point(186, 150)
        Me.cmdPostBatch.Name = "cmdPostBatch"
        Me.cmdPostBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdPostBatch.TabIndex = 15
        Me.cmdPostBatch.Text = "Post Batch"
        Me.cmdPostBatch.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(982, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 17
        Me.cmdDelete.Text = "Delete Batch"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(905, 771)
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
        'dgvInvoiceHeaders
        '
        Me.dgvInvoiceHeaders.AllowUserToAddRows = False
        Me.dgvInvoiceHeaders.AllowUserToDeleteRows = False
        Me.dgvInvoiceHeaders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInvoiceHeaders.AutoGenerateColumns = False
        Me.dgvInvoiceHeaders.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInvoiceHeaders.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInvoiceHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceHeaders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BatchNumberColumn, Me.InvoiceNumberColumn, Me.InvoiceDateColumn, Me.SalesOrderNumberColumn, Me.ShipmentNumberColumn, Me.CustomerIDColumn, Me.InvoiceTotalColumn, Me.SpecialInstructionsColumn, Me.BTAddress1Column, Me.BTAddress2Column, Me.BTCityColumn, Me.BTStateColumn, Me.BTZipColumn, Me.BTCountryColumn, Me.ProductTotalColumn, Me.BilledFreightColumn, Me.SalesTaxColumn, Me.DiscountColumn, Me.InvoiceStatusColumn, Me.DivisionIDColumn, Me.CommentColumn, Me.PaymentTermsColumn, Me.DropShipPONumberColumn, Me.SalesTax2Column, Me.SalesTax3Column, Me.FOBColumn, Me.CustomerClassColumn, Me.PaymentTerms})
        Me.dgvInvoiceHeaders.DataSource = Me.InvoiceHeaderTableBindingSource
        Me.dgvInvoiceHeaders.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvInvoiceHeaders.Location = New System.Drawing.Point(348, 48)
        Me.dgvInvoiceHeaders.Name = "dgvInvoiceHeaders"
        Me.dgvInvoiceHeaders.Size = New System.Drawing.Size(782, 506)
        Me.dgvInvoiceHeaders.TabIndex = 20
        Me.dgvInvoiceHeaders.TabStop = False
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "BatchNumber"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.ReadOnly = True
        Me.BatchNumberColumn.Visible = False
        '
        'InvoiceNumberColumn
        '
        Me.InvoiceNumberColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn.HeaderText = "Invoice #"
        Me.InvoiceNumberColumn.Name = "InvoiceNumberColumn"
        Me.InvoiceNumberColumn.ReadOnly = True
        Me.InvoiceNumberColumn.Width = 90
        '
        'InvoiceDateColumn
        '
        Me.InvoiceDateColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumn.HeaderText = "Invoice Date"
        Me.InvoiceDateColumn.Name = "InvoiceDateColumn"
        Me.InvoiceDateColumn.ReadOnly = True
        Me.InvoiceDateColumn.Width = 90
        '
        'SalesOrderNumberColumn
        '
        Me.SalesOrderNumberColumn.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberColumn.HeaderText = "SO #"
        Me.SalesOrderNumberColumn.Name = "SalesOrderNumberColumn"
        Me.SalesOrderNumberColumn.ReadOnly = True
        Me.SalesOrderNumberColumn.Width = 90
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "Shipment #"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        Me.ShipmentNumberColumn.ReadOnly = True
        Me.ShipmentNumberColumn.Width = 90
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        Me.CustomerIDColumn.Width = 125
        '
        'InvoiceTotalColumn
        '
        Me.InvoiceTotalColumn.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.InvoiceTotalColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.InvoiceTotalColumn.HeaderText = "Invoice Total"
        Me.InvoiceTotalColumn.Name = "InvoiceTotalColumn"
        Me.InvoiceTotalColumn.ReadOnly = True
        Me.InvoiceTotalColumn.Width = 90
        '
        'SpecialInstructionsColumn
        '
        Me.SpecialInstructionsColumn.DataPropertyName = "SpecialInstructions"
        Me.SpecialInstructionsColumn.HeaderText = "Other"
        Me.SpecialInstructionsColumn.Name = "SpecialInstructionsColumn"
        Me.SpecialInstructionsColumn.Visible = False
        '
        'BTAddress1Column
        '
        Me.BTAddress1Column.DataPropertyName = "BTAddress1"
        Me.BTAddress1Column.HeaderText = "BTAddress1"
        Me.BTAddress1Column.Name = "BTAddress1Column"
        Me.BTAddress1Column.Visible = False
        '
        'BTAddress2Column
        '
        Me.BTAddress2Column.DataPropertyName = "BTAddress2"
        Me.BTAddress2Column.HeaderText = "BTAddress2"
        Me.BTAddress2Column.Name = "BTAddress2Column"
        Me.BTAddress2Column.Visible = False
        '
        'BTCityColumn
        '
        Me.BTCityColumn.DataPropertyName = "BTCity"
        Me.BTCityColumn.HeaderText = "BTCity"
        Me.BTCityColumn.Name = "BTCityColumn"
        Me.BTCityColumn.Visible = False
        '
        'BTStateColumn
        '
        Me.BTStateColumn.DataPropertyName = "BTState"
        Me.BTStateColumn.HeaderText = "BTState"
        Me.BTStateColumn.Name = "BTStateColumn"
        Me.BTStateColumn.Visible = False
        '
        'BTZipColumn
        '
        Me.BTZipColumn.DataPropertyName = "BTZip"
        Me.BTZipColumn.HeaderText = "BTZip"
        Me.BTZipColumn.Name = "BTZipColumn"
        Me.BTZipColumn.Visible = False
        '
        'BTCountryColumn
        '
        Me.BTCountryColumn.DataPropertyName = "BTCountry"
        Me.BTCountryColumn.HeaderText = "BTCountry"
        Me.BTCountryColumn.Name = "BTCountryColumn"
        Me.BTCountryColumn.Visible = False
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.ProductTotalColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.ProductTotalColumn.HeaderText = "ProductTotal"
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        Me.ProductTotalColumn.Visible = False
        '
        'BilledFreightColumn
        '
        Me.BilledFreightColumn.DataPropertyName = "BilledFreight"
        Me.BilledFreightColumn.HeaderText = "Freight"
        Me.BilledFreightColumn.Name = "BilledFreightColumn"
        '
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        Me.SalesTaxColumn.HeaderText = "SalesTax"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        Me.SalesTaxColumn.Visible = False
        '
        'DiscountColumn
        '
        Me.DiscountColumn.DataPropertyName = "Discount"
        Me.DiscountColumn.HeaderText = "Discount"
        Me.DiscountColumn.Name = "DiscountColumn"
        Me.DiscountColumn.Visible = False
        '
        'InvoiceStatusColumn
        '
        Me.InvoiceStatusColumn.DataPropertyName = "InvoiceStatus"
        Me.InvoiceStatusColumn.HeaderText = "InvoiceStatus"
        Me.InvoiceStatusColumn.Name = "InvoiceStatusColumn"
        Me.InvoiceStatusColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        Me.CommentColumn.Visible = False
        '
        'PaymentTermsColumn
        '
        Me.PaymentTermsColumn.DataPropertyName = "PaymentTerms"
        Me.PaymentTermsColumn.HeaderText = "PaymentTerms"
        Me.PaymentTermsColumn.Name = "PaymentTermsColumn"
        Me.PaymentTermsColumn.Visible = False
        '
        'DropShipPONumberColumn
        '
        Me.DropShipPONumberColumn.DataPropertyName = "DropShipPONumber"
        Me.DropShipPONumberColumn.HeaderText = "DropShipPONumber"
        Me.DropShipPONumberColumn.Name = "DropShipPONumberColumn"
        Me.DropShipPONumberColumn.Visible = False
        '
        'SalesTax2Column
        '
        Me.SalesTax2Column.DataPropertyName = "SalesTax2"
        Me.SalesTax2Column.HeaderText = "SalesTax2"
        Me.SalesTax2Column.Name = "SalesTax2Column"
        Me.SalesTax2Column.Visible = False
        '
        'SalesTax3Column
        '
        Me.SalesTax3Column.DataPropertyName = "SalesTax3"
        Me.SalesTax3Column.HeaderText = "SalesTax3"
        Me.SalesTax3Column.Name = "SalesTax3Column"
        Me.SalesTax3Column.Visible = False
        '
        'FOBColumn
        '
        Me.FOBColumn.DataPropertyName = "FOB"
        Me.FOBColumn.HeaderText = "FOB"
        Me.FOBColumn.Name = "FOBColumn"
        Me.FOBColumn.Visible = False
        '
        'CustomerClassColumn
        '
        Me.CustomerClassColumn.DataPropertyName = "CustomerClass"
        Me.CustomerClassColumn.HeaderText = "CustomerClass"
        Me.CustomerClassColumn.Name = "CustomerClassColumn"
        Me.CustomerClassColumn.Visible = False
        '
        'PaymentTerms
        '
        Me.PaymentTerms.DataPropertyName = "PaymentTerms"
        Me.PaymentTerms.HeaderText = "Pmt. Terms"
        Me.PaymentTerms.Name = "PaymentTerms"
        Me.PaymentTerms.ReadOnly = True
        '
        'InvoiceHeaderTableBindingSource
        '
        Me.InvoiceHeaderTableBindingSource.DataMember = "InvoiceHeaderTable"
        Me.InvoiceHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ShipmentHeaderTableBindingSource
        '
        Me.ShipmentHeaderTableBindingSource.DataMember = "ShipmentHeaderTable"
        Me.ShipmentHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ShipmentHeaderTableTableAdapter
        '
        Me.ShipmentHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'InvoiceHeaderTableTableAdapter
        '
        Me.InvoiceHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'cmdSelectShipments
        '
        Me.cmdSelectShipments.ForeColor = System.Drawing.Color.Blue
        Me.cmdSelectShipments.Location = New System.Drawing.Point(21, 31)
        Me.cmdSelectShipments.Name = "cmdSelectShipments"
        Me.cmdSelectShipments.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectShipments.TabIndex = 11
        Me.cmdSelectShipments.Text = "Select Shipments"
        Me.cmdSelectShipments.UseVisualStyleBackColor = True
        '
        'gpxSelectShipmentsCredits
        '
        Me.gpxSelectShipmentsCredits.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxSelectShipmentsCredits.Controls.Add(Me.Label13)
        Me.gpxSelectShipmentsCredits.Controls.Add(Me.cmdSelectReturns)
        Me.gpxSelectShipmentsCredits.Controls.Add(Me.Label9)
        Me.gpxSelectShipmentsCredits.Controls.Add(Me.cmdSelectShipments)
        Me.gpxSelectShipmentsCredits.Location = New System.Drawing.Point(348, 560)
        Me.gpxSelectShipmentsCredits.Name = "gpxSelectShipmentsCredits"
        Me.gpxSelectShipmentsCredits.Size = New System.Drawing.Size(275, 142)
        Me.gpxSelectShipmentsCredits.TabIndex = 10
        Me.gpxSelectShipmentsCredits.TabStop = False
        Me.gpxSelectShipmentsCredits.Text = "Select Shipments / Returns For Processing"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(98, 88)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(154, 40)
        Me.Label13.TabIndex = 90
        Me.Label13.Text = "Opens form to select Customer Returns for credit."
        '
        'cmdSelectReturns
        '
        Me.cmdSelectReturns.ForeColor = System.Drawing.Color.Blue
        Me.cmdSelectReturns.Location = New System.Drawing.Point(21, 88)
        Me.cmdSelectReturns.Name = "cmdSelectReturns"
        Me.cmdSelectReturns.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectReturns.TabIndex = 89
        Me.cmdSelectReturns.Text = "Select Returns"
        Me.cmdSelectReturns.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(98, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(154, 40)
        Me.Label9.TabIndex = 88
        Me.Label9.Text = "Opens form to select Shipments to be invoiced."
        '
        'cmdEditInvoices
        '
        Me.cmdEditInvoices.ForeColor = System.Drawing.Color.Blue
        Me.cmdEditInvoices.Location = New System.Drawing.Point(21, 24)
        Me.cmdEditInvoices.Name = "cmdEditInvoices"
        Me.cmdEditInvoices.Size = New System.Drawing.Size(71, 40)
        Me.cmdEditInvoices.TabIndex = 13
        Me.cmdEditInvoices.Text = "Edit Invoices"
        Me.cmdEditInvoices.UseVisualStyleBackColor = True
        '
        'cmdClearBatch
        '
        Me.cmdClearBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearBatch.Location = New System.Drawing.Point(828, 771)
        Me.cmdClearBatch.Name = "cmdClearBatch"
        Me.cmdClearBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearBatch.TabIndex = 9
        Me.cmdClearBatch.Text = "Clear Batch"
        Me.cmdClearBatch.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cmdEditInvoices)
        Me.GroupBox1.Location = New System.Drawing.Point(348, 714)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(275, 78)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Invoices for Editing"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(98, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(171, 40)
        Me.Label10.TabIndex = 89
        Me.Label10.Text = "Opens form to view or edit individual Invoices."
        '
        'lblPendingReturns
        '
        Me.lblPendingReturns.ForeColor = System.Drawing.Color.Red
        Me.lblPendingReturns.Location = New System.Drawing.Point(45, 392)
        Me.lblPendingReturns.Name = "lblPendingReturns"
        Me.lblPendingReturns.Size = New System.Drawing.Size(278, 32)
        Me.lblPendingReturns.TabIndex = 86
        Me.lblPendingReturns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPendingReturns.Visible = False
        '
        'lblOpenBatches
        '
        Me.lblOpenBatches.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblOpenBatches.Location = New System.Drawing.Point(45, 359)
        Me.lblOpenBatches.Name = "lblOpenBatches"
        Me.lblOpenBatches.Size = New System.Drawing.Size(278, 32)
        Me.lblOpenBatches.TabIndex = 87
        Me.lblOpenBatches.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblOpenBatches.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.cboInvoiceNumber)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.cmdDeleteInvoice)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 470)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 121)
        Me.GroupBox2.TabIndex = 88
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Delete Invoice From Batch"
        '
        'Label18
        '
        Me.Label18.ForeColor = System.Drawing.Color.Blue
        Me.Label18.Location = New System.Drawing.Point(16, 73)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(188, 30)
        Me.Label18.TabIndex = 91
        Me.Label18.Text = "Select Invoice # from drop down or select invoices from datagrid to delete from b" & _
            "atch."
        '
        'cboInvoiceNumber
        '
        Me.cboInvoiceNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInvoiceNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInvoiceNumber.DataSource = Me.InvoiceHeaderTableBindingSource
        Me.cboInvoiceNumber.DisplayMember = "InvoiceNumber"
        Me.cboInvoiceNumber.FormattingEnabled = True
        Me.cboInvoiceNumber.Location = New System.Drawing.Point(117, 33)
        Me.cboInvoiceNumber.Name = "cboInvoiceNumber"
        Me.cboInvoiceNumber.Size = New System.Drawing.Size(166, 21)
        Me.cboInvoiceNumber.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(25, 34)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(115, 20)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "Invoice #"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteInvoice
        '
        Me.cmdDeleteInvoice.Location = New System.Drawing.Point(210, 67)
        Me.cmdDeleteInvoice.Name = "cmdDeleteInvoice"
        Me.cmdDeleteInvoice.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteInvoice.TabIndex = 10
        Me.cmdDeleteInvoice.Text = "Delete Invoice"
        Me.cmdDeleteInvoice.UseVisualStyleBackColor = True
        '
        'lblOpenBillOnly
        '
        Me.lblOpenBillOnly.ForeColor = System.Drawing.Color.Green
        Me.lblOpenBillOnly.Location = New System.Drawing.Point(45, 425)
        Me.lblOpenBillOnly.Name = "lblOpenBillOnly"
        Me.lblOpenBillOnly.Size = New System.Drawing.Size(278, 32)
        Me.lblOpenBillOnly.TabIndex = 89
        Me.lblOpenBillOnly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblOpenBillOnly.Visible = False
        '
        'dgvInvoiceSerialLines
        '
        Me.dgvInvoiceSerialLines.AllowUserToAddRows = False
        Me.dgvInvoiceSerialLines.AllowUserToDeleteRows = False
        Me.dgvInvoiceSerialLines.AutoGenerateColumns = False
        Me.dgvInvoiceSerialLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInvoiceSerialLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceSerialLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SNInvoiceHeaderKeyColumn, Me.SNInvoiceLineColumn, Me.SNPartNumberColumn, Me.SNDivisionIDColumn, Me.SNCustomerIDColumn, Me.SNInvoiceSerialNumberColumn, Me.SNSerialNumberCostColumn})
        Me.dgvInvoiceSerialLines.DataSource = Me.InvoiceLineSerialNumberQueryBindingSource
        Me.dgvInvoiceSerialLines.GridColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgvInvoiceSerialLines.Location = New System.Drawing.Point(348, 48)
        Me.dgvInvoiceSerialLines.Name = "dgvInvoiceSerialLines"
        Me.dgvInvoiceSerialLines.ReadOnly = True
        Me.dgvInvoiceSerialLines.Size = New System.Drawing.Size(240, 150)
        Me.dgvInvoiceSerialLines.TabIndex = 90
        Me.dgvInvoiceSerialLines.Visible = False
        '
        'SNInvoiceHeaderKeyColumn
        '
        Me.SNInvoiceHeaderKeyColumn.DataPropertyName = "InvoiceHeaderKey"
        Me.SNInvoiceHeaderKeyColumn.HeaderText = "InvoiceHeaderKey"
        Me.SNInvoiceHeaderKeyColumn.Name = "SNInvoiceHeaderKeyColumn"
        Me.SNInvoiceHeaderKeyColumn.ReadOnly = True
        '
        'SNInvoiceLineColumn
        '
        Me.SNInvoiceLineColumn.DataPropertyName = "InvoiceLineKey"
        Me.SNInvoiceLineColumn.HeaderText = "InvoiceLineKey"
        Me.SNInvoiceLineColumn.Name = "SNInvoiceLineColumn"
        Me.SNInvoiceLineColumn.ReadOnly = True
        '
        'SNPartNumberColumn
        '
        Me.SNPartNumberColumn.DataPropertyName = "PartNumber"
        Me.SNPartNumberColumn.HeaderText = "PartNumber"
        Me.SNPartNumberColumn.Name = "SNPartNumberColumn"
        Me.SNPartNumberColumn.ReadOnly = True
        '
        'SNDivisionIDColumn
        '
        Me.SNDivisionIDColumn.DataPropertyName = "DivisionID"
        Me.SNDivisionIDColumn.HeaderText = "DivisionID"
        Me.SNDivisionIDColumn.Name = "SNDivisionIDColumn"
        Me.SNDivisionIDColumn.ReadOnly = True
        '
        'SNCustomerIDColumn
        '
        Me.SNCustomerIDColumn.DataPropertyName = "CustomerID"
        Me.SNCustomerIDColumn.HeaderText = "CustomerID"
        Me.SNCustomerIDColumn.Name = "SNCustomerIDColumn"
        Me.SNCustomerIDColumn.ReadOnly = True
        '
        'SNInvoiceSerialNumberColumn
        '
        Me.SNInvoiceSerialNumberColumn.DataPropertyName = "InvoiceSerialNumber"
        Me.SNInvoiceSerialNumberColumn.HeaderText = "InvoiceSerialNumber"
        Me.SNInvoiceSerialNumberColumn.Name = "SNInvoiceSerialNumberColumn"
        Me.SNInvoiceSerialNumberColumn.ReadOnly = True
        '
        'SNSerialNumberCostColumn
        '
        Me.SNSerialNumberCostColumn.DataPropertyName = "SerialNumberCost"
        Me.SNSerialNumberCostColumn.HeaderText = "SerialNumberCost"
        Me.SNSerialNumberCostColumn.Name = "SNSerialNumberCostColumn"
        Me.SNSerialNumberCostColumn.ReadOnly = True
        '
        'InvoiceLineSerialNumberQueryBindingSource
        '
        Me.InvoiceLineSerialNumberQueryBindingSource.DataMember = "InvoiceLineSerialNumberQuery"
        Me.InvoiceLineSerialNumberQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'InvoiceLineSerialNumberQueryTableAdapter
        '
        Me.InvoiceLineSerialNumberQueryTableAdapter.ClearBeforeFill = True
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(345, 796)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(360, 21)
        Me.Label19.TabIndex = 92
        Me.Label19.Text = "Red in datagrid indicates the pick ticket has not been uploaded."
        '
        'cmdSplitBatch
        '
        Me.cmdSplitBatch.ForeColor = System.Drawing.Color.Black
        Me.cmdSplitBatch.Location = New System.Drawing.Point(212, 19)
        Me.cmdSplitBatch.Name = "cmdSplitBatch"
        Me.cmdSplitBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdSplitBatch.TabIndex = 93
        Me.cmdSplitBatch.Text = "Split Batch"
        Me.cmdSplitBatch.UseVisualStyleBackColor = True
        '
        'gpxSplitBatch
        '
        Me.gpxSplitBatch.Controls.Add(Me.Label20)
        Me.gpxSplitBatch.Controls.Add(Me.cmdSplitBatch)
        Me.gpxSplitBatch.Location = New System.Drawing.Point(29, 598)
        Me.gpxSplitBatch.Name = "gpxSplitBatch"
        Me.gpxSplitBatch.Size = New System.Drawing.Size(300, 73)
        Me.gpxSplitBatch.TabIndex = 90
        Me.gpxSplitBatch.TabStop = False
        Me.gpxSplitBatch.Text = "Split Invoices Into A New Batch"
        '
        'Label20
        '
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(19, 26)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(185, 30)
        Me.Label20.TabIndex = 94
        Me.Label20.Text = "Select lines in datagrid to split into another batch."
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.cboTime)
        Me.GroupBox3.Controls.Add(Me.cboDay)
        Me.GroupBox3.Controls.Add(Me.cmdSchedule)
        Me.GroupBox3.Location = New System.Drawing.Point(629, 560)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(225, 200)
        Me.GroupBox3.TabIndex = 93
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Schedule Invoice Auto-Emailer"
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.ForeColor = System.Drawing.Color.Blue
        Me.Label23.Location = New System.Drawing.Point(20, 94)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(188, 58)
        Me.Label23.TabIndex = 94
        Me.Label23.Text = "Emails with invoices and certs will auto-email at the selected time and day. Do n" & _
            "ot schedule multiple batches at the same time."
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(17, 59)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(47, 21)
        Me.Label22.TabIndex = 93
        Me.Label22.Text = "Time"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(17, 29)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(47, 21)
        Me.Label21.TabIndex = 92
        Me.Label21.Text = "Day"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTime
        '
        Me.cboTime.FormattingEnabled = True
        Me.cboTime.Items.AddRange(New Object() {"12:00AM", "1:00AM", "2:00AM", "3:00AM", "4:00AM", "5:00AM", "6:00AM", "7:00AM", "8:00AM", "9:00AM", "10:00AM", "11:00AM", "12:00PM", "1:00PM", "2:00PM", "3:00PM", "4:00PM", "5:00PM", "6:00PM", "7:00PM", "8:00PM", "9:00PM", "10:00PM", "11:00PM"})
        Me.cboTime.Location = New System.Drawing.Point(65, 59)
        Me.cboTime.Name = "cboTime"
        Me.cboTime.Size = New System.Drawing.Size(143, 21)
        Me.cboTime.TabIndex = 12
        '
        'cboDay
        '
        Me.cboDay.FormattingEnabled = True
        Me.cboDay.Items.AddRange(New Object() {"TODAY", "TONIGHT (AFTER MIDNIGHT)"})
        Me.cboDay.Location = New System.Drawing.Point(65, 29)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Size = New System.Drawing.Size(143, 21)
        Me.cboDay.TabIndex = 11
        '
        'cmdSchedule
        '
        Me.cmdSchedule.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSchedule.Location = New System.Drawing.Point(137, 160)
        Me.cmdSchedule.Name = "cmdSchedule"
        Me.cmdSchedule.Size = New System.Drawing.Size(71, 30)
        Me.cmdSchedule.TabIndex = 10
        Me.cmdSchedule.Text = "Schedule"
        Me.cmdSchedule.UseVisualStyleBackColor = True
        '
        'ARProcessBatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.gpxSplitBatch)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.lblOpenBillOnly)
        Me.Controls.Add(Me.lblOpenBatches)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblPendingReturns)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdClearBatch)
        Me.Controls.Add(Me.dgvInvoiceHeaders)
        Me.Controls.Add(Me.gpxSelectShipmentsCredits)
        Me.Controls.Add(Me.gpxPostingProcedure)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxBatchTotals)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.gpxBatchInfo)
        Me.Controls.Add(Me.dgvInvoiceSerialLines)
        Me.Name = "ARProcessBatch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Invoice Batch Processing"
        Me.gpxBatchInfo.ResumeLayout(False)
        Me.gpxBatchInfo.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxBatchTotals.ResumeLayout(False)
        Me.gpxBatchTotals.PerformLayout()
        Me.gpxPostingProcedure.ResumeLayout(False)
        CType(Me.dgvInvoiceHeaders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxSelectShipmentsCredits.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvInvoiceSerialLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceLineSerialNumberQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxSplitBatch.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxBatchTotals As System.Windows.Forms.GroupBox
    Friend WithEvents txtUndistributedAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrentTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtEntryNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gpxPostingProcedure As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPostBatch As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ShipmentHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents dgvInvoiceHeaders As System.Windows.Forms.DataGridView
    Friend WithEvents InvoiceHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
    Friend WithEvents cmdSelectShipments As System.Windows.Forms.Button
    Friend WithEvents gpxSelectShipmentsCredits As System.Windows.Forms.GroupBox
    Friend WithEvents cmdEditInvoices As System.Windows.Forms.Button
    Friend WithEvents cmdClearBatch As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmdSelectReturns As System.Windows.Forms.Button
    Friend WithEvents SaveBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtBatchStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintCerts As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblPendingReturns As System.Windows.Forms.Label
    Friend WithEvents UnLockBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrintAll As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblOpenBatches As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboInvoiceNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteInvoice As System.Windows.Forms.Button
    Friend WithEvents lblOpenBillOnly As System.Windows.Forms.Label
    Friend WithEvents dgvInvoiceSerialLines As System.Windows.Forms.DataGridView
    Friend WithEvents InvoiceLineSerialNumberQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceLineSerialNumberQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceLineSerialNumberQueryTableAdapter
    Friend WithEvents SNInvoiceHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SNInvoiceLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SNPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SNDivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SNCustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SNInvoiceSerialNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SNSerialNumberCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmdSplitBatch As System.Windows.Forms.Button
    Friend WithEvents gpxSplitBatch As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecialInstructionsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTAddress1Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTAddress2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTCityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTStateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTZipColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTCountryColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BilledFreightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTermsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DropShipPONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTax2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTax3Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOBColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTerms As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSchedule As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboTime As System.Windows.Forms.ComboBox
    Friend WithEvents cboDay As System.Windows.Forms.ComboBox
    Friend WithEvents crxInvoiceTFF1 As MOS09Program.CRXInvoiceTFF
    Friend WithEvents crxInvoiceTFP1 As MOS09Program.CRXInvoiceTFP
    Friend WithEvents crxInvoice1 As MOS09Program.CRXInvoice
End Class
