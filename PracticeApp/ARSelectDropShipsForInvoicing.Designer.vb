<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ARSelectDropShipsForInvoicing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ARSelectDropShipsForInvoicing))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxSelectData = New System.Windows.Forms.GroupBox
        Me.dtpShipDate = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdGenerateBatchNumber = New System.Windows.Forms.Button
        Me.cboInvoiceBatchNumber = New System.Windows.Forms.ComboBox
        Me.InvoiceProcessingBatchHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblVendorName = New System.Windows.Forms.Label
        Me.PurchaseOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPurchaseOrderNumber = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdViewByPO = New System.Windows.Forms.Button
        Me.cmdUnselectAll = New System.Windows.Forms.Button
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdProcess = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdOpenBatchForm = New System.Windows.Forms.Button
        Me.PurchaseOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.gpxInstructions = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.gpxGoToInvoiceBatchForm = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.InvoiceProcessingBatchHeaderTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceProcessingBatchHeaderTableAdapter
        Me.cmdClearForm = New System.Windows.Forms.Button
        Me.dgvPurchaseOrderLines = New System.Windows.Forms.DataGridView
        Me.PurchaseOrderQuantityStatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PurchaseOrderQuantityStatusTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderQuantityStatusTableAdapter
        Me.Label11 = New System.Windows.Forms.Label
        Me.CachedCRXDropShipSO1 = New MOS09Program.CachedCRXDropShipSO
        Me.gpxShipment = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cboVendorShipmentNumber = New System.Windows.Forms.ComboBox
        Me.ShipmentHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label12 = New System.Windows.Forms.Label
        Me.ShipmentHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
        Me.dgvLotNumbers = New System.Windows.Forms.DataGridView
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PullTestNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentLineLotNumbersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShipmentLineLotNumbersTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLineLotNumbersTableAdapter
        Me.SelectForInvoice = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DropShipSalesOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PODropShipCustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POQuantityOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOpenEditModeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectForInvoiceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POAdditionalShipToColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipMethodIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POHeaderCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrderQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POQuantityReceivedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PODateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        Me.gpxSelectData.SuspendLayout()
        CType(Me.InvoiceProcessingBatchHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gpxInstructions.SuspendLayout()
        Me.gpxGoToInvoiceBatchForm.SuspendLayout()
        CType(Me.dgvPurchaseOrderLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderQuantityStatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxShipment.SuspendLayout()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLotNumbers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentLineLotNumbersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportToolStripMenuItem, Me.ExitToolStripMenuItem})
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
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.ReportToolStripMenuItem.Text = "Report"
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
        'gpxSelectData
        '
        Me.gpxSelectData.Controls.Add(Me.dtpShipDate)
        Me.gpxSelectData.Controls.Add(Me.Label10)
        Me.gpxSelectData.Controls.Add(Me.cmdGenerateBatchNumber)
        Me.gpxSelectData.Controls.Add(Me.cboInvoiceBatchNumber)
        Me.gpxSelectData.Controls.Add(Me.Label3)
        Me.gpxSelectData.Controls.Add(Me.cboDivisionID)
        Me.gpxSelectData.Controls.Add(Me.lblVendorName)
        Me.gpxSelectData.Location = New System.Drawing.Point(29, 41)
        Me.gpxSelectData.Name = "gpxSelectData"
        Me.gpxSelectData.Size = New System.Drawing.Size(321, 142)
        Me.gpxSelectData.TabIndex = 0
        Me.gpxSelectData.TabStop = False
        Me.gpxSelectData.Text = "Create Invoice Batch"
        '
        'dtpShipDate
        '
        Me.dtpShipDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpShipDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpShipDate.Location = New System.Drawing.Point(138, 65)
        Me.dtpShipDate.Name = "dtpShipDate"
        Me.dtpShipDate.Size = New System.Drawing.Size(168, 20)
        Me.dtpShipDate.TabIndex = 29
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(22, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 20)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Ship / Invoice Date"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdGenerateBatchNumber
        '
        Me.cmdGenerateBatchNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateBatchNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateBatchNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateBatchNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateBatchNumber.Location = New System.Drawing.Point(106, 98)
        Me.cmdGenerateBatchNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateBatchNumber.Name = "cmdGenerateBatchNumber"
        Me.cmdGenerateBatchNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateBatchNumber.TabIndex = 1
        Me.cmdGenerateBatchNumber.TabStop = False
        Me.cmdGenerateBatchNumber.Text = ">>"
        Me.cmdGenerateBatchNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateBatchNumber.UseVisualStyleBackColor = False
        '
        'cboInvoiceBatchNumber
        '
        Me.cboInvoiceBatchNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInvoiceBatchNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInvoiceBatchNumber.DataSource = Me.InvoiceProcessingBatchHeaderBindingSource
        Me.cboInvoiceBatchNumber.DisplayMember = "BatchNumber"
        Me.cboInvoiceBatchNumber.FormattingEnabled = True
        Me.cboInvoiceBatchNumber.Location = New System.Drawing.Point(138, 97)
        Me.cboInvoiceBatchNumber.Name = "cboInvoiceBatchNumber"
        Me.cboInvoiceBatchNumber.Size = New System.Drawing.Size(168, 21)
        Me.cboInvoiceBatchNumber.TabIndex = 2
        '
        'InvoiceProcessingBatchHeaderBindingSource
        '
        Me.InvoiceProcessingBatchHeaderBindingSource.DataMember = "InvoiceProcessingBatchHeader"
        Me.InvoiceProcessingBatchHeaderBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 20)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Invoice Batch #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(138, 30)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(168, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'lblVendorName
        '
        Me.lblVendorName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendorName.Location = New System.Drawing.Point(22, 31)
        Me.lblVendorName.Name = "lblVendorName"
        Me.lblVendorName.Size = New System.Drawing.Size(107, 20)
        Me.lblVendorName.TabIndex = 3
        Me.lblVendorName.Text = "Division ID"
        Me.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PurchaseOrderHeaderTableBindingSource
        '
        Me.PurchaseOrderHeaderTableBindingSource.DataMember = "PurchaseOrderHeaderTable"
        Me.PurchaseOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPurchaseOrderNumber
        '
        Me.cboPurchaseOrderNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPurchaseOrderNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPurchaseOrderNumber.DataSource = Me.PurchaseOrderHeaderTableBindingSource
        Me.cboPurchaseOrderNumber.DisplayMember = "PurchaseOrderHeaderKey"
        Me.cboPurchaseOrderNumber.FormattingEnabled = True
        Me.cboPurchaseOrderNumber.Location = New System.Drawing.Point(140, 32)
        Me.cboPurchaseOrderNumber.Name = "cboPurchaseOrderNumber"
        Me.cboPurchaseOrderNumber.Size = New System.Drawing.Size(165, 21)
        Me.cboPurchaseOrderNumber.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 20)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Purchase Order #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByPO
        '
        Me.cmdViewByPO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdViewByPO.Location = New System.Drawing.Point(234, 68)
        Me.cmdViewByPO.Name = "cmdViewByPO"
        Me.cmdViewByPO.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewByPO.TabIndex = 5
        Me.cmdViewByPO.Text = "Enter"
        Me.cmdViewByPO.UseVisualStyleBackColor = True
        '
        'cmdUnselectAll
        '
        Me.cmdUnselectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUnselectAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUnselectAll.Location = New System.Drawing.Point(447, 572)
        Me.cmdUnselectAll.Name = "cmdUnselectAll"
        Me.cmdUnselectAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdUnselectAll.TabIndex = 7
        Me.cmdUnselectAll.Text = "Clear Lines"
        Me.cmdUnselectAll.UseVisualStyleBackColor = True
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSelectAll.Location = New System.Drawing.Point(370, 572)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectAll.TabIndex = 6
        Me.cmdSelectAll.Text = "Select All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(1061, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 13
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdProcess
        '
        Me.cmdProcess.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProcess.Location = New System.Drawing.Point(233, 62)
        Me.cmdProcess.Name = "cmdProcess"
        Me.cmdProcess.Size = New System.Drawing.Size(71, 40)
        Me.cmdProcess.TabIndex = 9
        Me.cmdProcess.Text = "Process For Invoicing"
        Me.cmdProcess.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Location = New System.Drawing.Point(984, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 12
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdProcess)
        Me.GroupBox1.Location = New System.Drawing.Point(370, 637)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(323, 117)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Release PO Lines for AR Invoicing"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(21, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(283, 22)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Add to Invoice Batch."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdOpenBatchForm
        '
        Me.cmdOpenBatchForm.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOpenBatchForm.Location = New System.Drawing.Point(212, 62)
        Me.cmdOpenBatchForm.Name = "cmdOpenBatchForm"
        Me.cmdOpenBatchForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenBatchForm.TabIndex = 11
        Me.cmdOpenBatchForm.Text = "Batch Form"
        Me.cmdOpenBatchForm.UseVisualStyleBackColor = True
        '
        'PurchaseOrderHeaderTableTableAdapter
        '
        Me.PurchaseOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboPurchaseOrderNumber)
        Me.GroupBox2.Controls.Add(Me.cmdViewByPO)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 189)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(323, 122)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Select Drop Ship PO to Release"
        '
        'gpxInstructions
        '
        Me.gpxInstructions.Controls.Add(Me.Label9)
        Me.gpxInstructions.Controls.Add(Me.Label7)
        Me.gpxInstructions.Controls.Add(Me.Label6)
        Me.gpxInstructions.Controls.Add(Me.Label5)
        Me.gpxInstructions.Controls.Add(Me.Label4)
        Me.gpxInstructions.Location = New System.Drawing.Point(27, 524)
        Me.gpxInstructions.Name = "gpxInstructions"
        Me.gpxInstructions.Size = New System.Drawing.Size(323, 287)
        Me.gpxInstructions.TabIndex = 27
        Me.gpxInstructions.TabStop = False
        Me.gpxInstructions.Text = "Instructions"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(22, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(283, 20)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Select Purchase Order to release to invoicing."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(22, 203)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(283, 65)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = resources.GetString("Label7.Text")
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(22, 149)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(283, 35)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Change quantity in datagrid if necessary, before adding to Invoice Batch."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(22, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(283, 20)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Select lines in datagrid to add to invoice."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(22, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(283, 20)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Create a New Invoice Batch Number"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxGoToInvoiceBatchForm
        '
        Me.gpxGoToInvoiceBatchForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxGoToInvoiceBatchForm.Controls.Add(Me.Label8)
        Me.gpxGoToInvoiceBatchForm.Controls.Add(Me.cmdOpenBatchForm)
        Me.gpxGoToInvoiceBatchForm.Location = New System.Drawing.Point(830, 637)
        Me.gpxGoToInvoiceBatchForm.Name = "gpxGoToInvoiceBatchForm"
        Me.gpxGoToInvoiceBatchForm.Size = New System.Drawing.Size(302, 117)
        Me.gpxGoToInvoiceBatchForm.TabIndex = 10
        Me.gpxGoToInvoiceBatchForm.TabStop = False
        Me.gpxGoToInvoiceBatchForm.Text = "Invoice Processing"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(18, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(265, 35)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Open Invoice Batch Processing and close this form."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InvoiceProcessingBatchHeaderTableAdapter
        '
        Me.InvoiceProcessingBatchHeaderTableAdapter.ClearBeforeFill = True
        '
        'cmdClearForm
        '
        Me.cmdClearForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearForm.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClearForm.Location = New System.Drawing.Point(907, 771)
        Me.cmdClearForm.Name = "cmdClearForm"
        Me.cmdClearForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearForm.TabIndex = 28
        Me.cmdClearForm.Text = "Clear Form"
        Me.cmdClearForm.UseVisualStyleBackColor = True
        '
        'dgvPurchaseOrderLines
        '
        Me.dgvPurchaseOrderLines.AllowUserToAddRows = False
        Me.dgvPurchaseOrderLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPurchaseOrderLines.AutoGenerateColumns = False
        Me.dgvPurchaseOrderLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvPurchaseOrderLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPurchaseOrderLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPurchaseOrderLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectForInvoice, Me.DropShipSalesOrderNumberColumn, Me.VendorIDColumn, Me.PODropShipCustomerIDColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.POQuantityOpenColumn, Me.QuantityOpenEditModeColumn, Me.UnitCostColumn, Me.OpenAmountColumn, Me.StatusColumn, Me.LineStatusColumn, Me.SelectForInvoiceColumn, Me.CreditGLAccountColumn, Me.DebitGLAccountColumn, Me.LineCommentColumn, Me.POAdditionalShipToColumn, Me.ShipMethodIDColumn, Me.POHeaderCommentColumn, Me.PaymentCodeColumn, Me.PurchaseOrderHeaderKeyColumn, Me.PurchaseOrderLineNumberColumn, Me.OrderQuantityColumn, Me.POQuantityReceivedColumn, Me.ExtendedAmountColumn, Me.ReceivedAmountColumn, Me.DivisionIDColumn, Me.PODateColumn, Me.ShipDateColumn})
        Me.dgvPurchaseOrderLines.DataSource = Me.PurchaseOrderQuantityStatusBindingSource
        Me.dgvPurchaseOrderLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvPurchaseOrderLines.Location = New System.Drawing.Point(370, 41)
        Me.dgvPurchaseOrderLines.Name = "dgvPurchaseOrderLines"
        Me.dgvPurchaseOrderLines.Size = New System.Drawing.Size(760, 512)
        Me.dgvPurchaseOrderLines.TabIndex = 29
        '
        'PurchaseOrderQuantityStatusBindingSource
        '
        Me.PurchaseOrderQuantityStatusBindingSource.DataMember = "PurchaseOrderQuantityStatus"
        Me.PurchaseOrderQuantityStatusBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'PurchaseOrderQuantityStatusTableAdapter
        '
        Me.PurchaseOrderQuantityStatusTableAdapter.ClearBeforeFill = True
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(564, 572)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(566, 41)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Make sure to change quantities in the grid before you select ""Process For Invoici" & _
            "ng"""
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gpxShipment
        '
        Me.gpxShipment.Controls.Add(Me.Label13)
        Me.gpxShipment.Controls.Add(Me.cboVendorShipmentNumber)
        Me.gpxShipment.Controls.Add(Me.Label12)
        Me.gpxShipment.Enabled = False
        Me.gpxShipment.Location = New System.Drawing.Point(29, 329)
        Me.gpxShipment.Name = "gpxShipment"
        Me.gpxShipment.Size = New System.Drawing.Size(323, 154)
        Me.gpxShipment.TabIndex = 31
        Me.gpxShipment.TabStop = False
        Me.gpxShipment.Text = "Add Lot Numbers"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(23, 67)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(283, 69)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "To automatically add lot number from the vendor, select the appropriate shipment " & _
            "number."
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorShipmentNumber
        '
        Me.cboVendorShipmentNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorShipmentNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorShipmentNumber.DataSource = Me.ShipmentHeaderTableBindingSource
        Me.cboVendorShipmentNumber.DisplayMember = "ShipmentNumber"
        Me.cboVendorShipmentNumber.FormattingEnabled = True
        Me.cboVendorShipmentNumber.Location = New System.Drawing.Point(143, 35)
        Me.cboVendorShipmentNumber.Name = "cboVendorShipmentNumber"
        Me.cboVendorShipmentNumber.Size = New System.Drawing.Size(163, 21)
        Me.cboVendorShipmentNumber.TabIndex = 27
        '
        'ShipmentHeaderTableBindingSource
        '
        Me.ShipmentHeaderTableBindingSource.DataMember = "ShipmentHeaderTable"
        Me.ShipmentHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(20, 36)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 20)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Vendor Shipment #"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ShipmentHeaderTableTableAdapter
        '
        Me.ShipmentHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'dgvLotNumbers
        '
        Me.dgvLotNumbers.AllowUserToAddRows = False
        Me.dgvLotNumbers.AllowUserToDeleteRows = False
        Me.dgvLotNumbers.AutoGenerateColumns = False
        Me.dgvLotNumbers.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvLotNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLotNumbers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ShipmentNumberColumn, Me.ShipmentLineNumberColumn, Me.LotLineNumberColumn, Me.LotNumberColumn, Me.PullTestNumberColumn, Me.HeatQuantityColumn})
        Me.dgvLotNumbers.DataSource = Me.ShipmentLineLotNumbersBindingSource
        Me.dgvLotNumbers.Location = New System.Drawing.Point(370, 41)
        Me.dgvLotNumbers.Name = "dgvLotNumbers"
        Me.dgvLotNumbers.Size = New System.Drawing.Size(240, 150)
        Me.dgvLotNumbers.TabIndex = 32
        Me.dgvLotNumbers.Visible = False
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "ShipmentNumber"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        '
        'ShipmentLineNumberColumn
        '
        Me.ShipmentLineNumberColumn.DataPropertyName = "ShipmentLineNumber"
        Me.ShipmentLineNumberColumn.HeaderText = "ShipmentLineNumber"
        Me.ShipmentLineNumberColumn.Name = "ShipmentLineNumberColumn"
        '
        'LotLineNumberColumn
        '
        Me.LotLineNumberColumn.DataPropertyName = "LotLineNumber"
        Me.LotLineNumberColumn.HeaderText = "LotLineNumber"
        Me.LotLineNumberColumn.Name = "LotLineNumberColumn"
        '
        'LotNumberColumn
        '
        Me.LotNumberColumn.DataPropertyName = "LotNumber"
        Me.LotNumberColumn.HeaderText = "LotNumber"
        Me.LotNumberColumn.Name = "LotNumberColumn"
        '
        'PullTestNumberColumn
        '
        Me.PullTestNumberColumn.DataPropertyName = "PullTestNumber"
        Me.PullTestNumberColumn.HeaderText = "PullTestNumber"
        Me.PullTestNumberColumn.Name = "PullTestNumberColumn"
        '
        'HeatQuantityColumn
        '
        Me.HeatQuantityColumn.DataPropertyName = "HeatQuantity"
        Me.HeatQuantityColumn.HeaderText = "HeatQuantity"
        Me.HeatQuantityColumn.Name = "HeatQuantityColumn"
        '
        'ShipmentLineLotNumbersBindingSource
        '
        Me.ShipmentLineLotNumbersBindingSource.DataMember = "ShipmentLineLotNumbers"
        Me.ShipmentLineLotNumbersBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ShipmentLineLotNumbersTableAdapter
        '
        Me.ShipmentLineLotNumbersTableAdapter.ClearBeforeFill = True
        '
        'SelectForInvoice
        '
        Me.SelectForInvoice.FalseValue = "UNSELECTED"
        Me.SelectForInvoice.HeaderText = "Select"
        Me.SelectForInvoice.Name = "SelectForInvoice"
        Me.SelectForInvoice.TrueValue = "SELECTED"
        Me.SelectForInvoice.Width = 65
        '
        'DropShipSalesOrderNumberColumn
        '
        Me.DropShipSalesOrderNumberColumn.DataPropertyName = "DropShipSalesOrderNumber"
        Me.DropShipSalesOrderNumberColumn.HeaderText = "SO #"
        Me.DropShipSalesOrderNumberColumn.Name = "DropShipSalesOrderNumberColumn"
        Me.DropShipSalesOrderNumberColumn.Width = 65
        '
        'VendorIDColumn
        '
        Me.VendorIDColumn.DataPropertyName = "VendorID"
        Me.VendorIDColumn.HeaderText = "Vendor ID"
        Me.VendorIDColumn.Name = "VendorIDColumn"
        '
        'PODropShipCustomerIDColumn
        '
        Me.PODropShipCustomerIDColumn.DataPropertyName = "PODropShipCustomerID"
        Me.PODropShipCustomerIDColumn.HeaderText = "Customer"
        Me.PODropShipCustomerIDColumn.Name = "PODropShipCustomerIDColumn"
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part Number"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Part Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        '
        'POQuantityOpenColumn
        '
        Me.POQuantityOpenColumn.DataPropertyName = "POQuantityOpen"
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = "0"
        Me.POQuantityOpenColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.POQuantityOpenColumn.HeaderText = "Quantity Open"
        Me.POQuantityOpenColumn.Name = "POQuantityOpenColumn"
        Me.POQuantityOpenColumn.ReadOnly = True
        Me.POQuantityOpenColumn.Visible = False
        Me.POQuantityOpenColumn.Width = 85
        '
        'QuantityOpenEditModeColumn
        '
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        Me.QuantityOpenEditModeColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.QuantityOpenEditModeColumn.HeaderText = "Quantity Open"
        Me.QuantityOpenEditModeColumn.Name = "QuantityOpenEditModeColumn"
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle3.Format = "N4"
        DataGridViewCellStyle3.NullValue = "0"
        Me.UnitCostColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.Width = 85
        '
        'OpenAmountColumn
        '
        Me.OpenAmountColumn.DataPropertyName = "OpenAmount"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.OpenAmountColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.OpenAmountColumn.HeaderText = "Amount"
        Me.OpenAmountColumn.Name = "OpenAmountColumn"
        Me.OpenAmountColumn.ReadOnly = True
        Me.OpenAmountColumn.Width = 85
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.Visible = False
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "LineStatus"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.Visible = False
        '
        'SelectForInvoiceColumn
        '
        Me.SelectForInvoiceColumn.DataPropertyName = "SelectForInvoice"
        Me.SelectForInvoiceColumn.HeaderText = "SelectForInvoice"
        Me.SelectForInvoiceColumn.Name = "SelectForInvoiceColumn"
        Me.SelectForInvoiceColumn.Visible = False
        '
        'CreditGLAccountColumn
        '
        Me.CreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumn.HeaderText = "CreditGLAccount"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
        Me.CreditGLAccountColumn.Visible = False
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "DebitGLAccount"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        Me.DebitGLAccountColumn.Visible = False
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "LineComment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        Me.LineCommentColumn.Visible = False
        '
        'POAdditionalShipToColumn
        '
        Me.POAdditionalShipToColumn.DataPropertyName = "POAdditionalShipTo"
        Me.POAdditionalShipToColumn.HeaderText = "POAdditionalShipTo"
        Me.POAdditionalShipToColumn.Name = "POAdditionalShipToColumn"
        Me.POAdditionalShipToColumn.Visible = False
        '
        'ShipMethodIDColumn
        '
        Me.ShipMethodIDColumn.DataPropertyName = "ShipMethodID"
        Me.ShipMethodIDColumn.HeaderText = "ShipMethodID"
        Me.ShipMethodIDColumn.Name = "ShipMethodIDColumn"
        Me.ShipMethodIDColumn.Visible = False
        '
        'POHeaderCommentColumn
        '
        Me.POHeaderCommentColumn.DataPropertyName = "POHeaderComment"
        Me.POHeaderCommentColumn.HeaderText = "POHeaderComment"
        Me.POHeaderCommentColumn.Name = "POHeaderCommentColumn"
        Me.POHeaderCommentColumn.Visible = False
        '
        'PaymentCodeColumn
        '
        Me.PaymentCodeColumn.DataPropertyName = "PaymentCode"
        Me.PaymentCodeColumn.HeaderText = "PaymentCode"
        Me.PaymentCodeColumn.Name = "PaymentCodeColumn"
        Me.PaymentCodeColumn.Visible = False
        '
        'PurchaseOrderHeaderKeyColumn
        '
        Me.PurchaseOrderHeaderKeyColumn.DataPropertyName = "PurchaseOrderHeaderKey"
        Me.PurchaseOrderHeaderKeyColumn.HeaderText = "PurchaseOrderHeaderKey"
        Me.PurchaseOrderHeaderKeyColumn.Name = "PurchaseOrderHeaderKeyColumn"
        Me.PurchaseOrderHeaderKeyColumn.Visible = False
        '
        'PurchaseOrderLineNumberColumn
        '
        Me.PurchaseOrderLineNumberColumn.DataPropertyName = "PurchaseOrderLineNumber"
        Me.PurchaseOrderLineNumberColumn.HeaderText = "Line #"
        Me.PurchaseOrderLineNumberColumn.Name = "PurchaseOrderLineNumberColumn"
        Me.PurchaseOrderLineNumberColumn.Visible = False
        '
        'OrderQuantityColumn
        '
        Me.OrderQuantityColumn.DataPropertyName = "OrderQuantity"
        Me.OrderQuantityColumn.HeaderText = "OrderQuantity"
        Me.OrderQuantityColumn.Name = "OrderQuantityColumn"
        Me.OrderQuantityColumn.Visible = False
        '
        'POQuantityReceivedColumn
        '
        Me.POQuantityReceivedColumn.DataPropertyName = "POQuantityReceived"
        Me.POQuantityReceivedColumn.HeaderText = "POQuantityReceived"
        Me.POQuantityReceivedColumn.Name = "POQuantityReceivedColumn"
        Me.POQuantityReceivedColumn.ReadOnly = True
        Me.POQuantityReceivedColumn.Visible = False
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        Me.ExtendedAmountColumn.HeaderText = "ExtendedAmount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.Visible = False
        '
        'ReceivedAmountColumn
        '
        Me.ReceivedAmountColumn.DataPropertyName = "ReceivedAmount"
        Me.ReceivedAmountColumn.HeaderText = "ReceivedAmount"
        Me.ReceivedAmountColumn.Name = "ReceivedAmountColumn"
        Me.ReceivedAmountColumn.ReadOnly = True
        Me.ReceivedAmountColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'PODateColumn
        '
        Me.PODateColumn.DataPropertyName = "PODate"
        Me.PODateColumn.HeaderText = "PODate"
        Me.PODateColumn.Name = "PODateColumn"
        Me.PODateColumn.Visible = False
        '
        'ShipDateColumn
        '
        Me.ShipDateColumn.DataPropertyName = "ShipDate"
        Me.ShipDateColumn.HeaderText = "ShipDate"
        Me.ShipDateColumn.Name = "ShipDateColumn"
        Me.ShipDateColumn.Visible = False
        '
        'ARSelectDropShipsForInvoicing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.gpxShipment)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dgvPurchaseOrderLines)
        Me.Controls.Add(Me.cmdClearForm)
        Me.Controls.Add(Me.gpxGoToInvoiceBatchForm)
        Me.Controls.Add(Me.gpxInstructions)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdUnselectAll)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.gpxSelectData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvLotNumbers)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ARSelectDropShipsForInvoicing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Select Drop Ships For Invoicing"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxSelectData.ResumeLayout(False)
        CType(Me.InvoiceProcessingBatchHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.gpxInstructions.ResumeLayout(False)
        Me.gpxGoToInvoiceBatchForm.ResumeLayout(False)
        CType(Me.dgvPurchaseOrderLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderQuantityStatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxShipment.ResumeLayout(False)
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLotNumbers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentLineLotNumbersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxSelectData As System.Windows.Forms.GroupBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblVendorName As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents cmdUnselectAll As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdProcess As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdViewByPO As System.Windows.Forms.Button
    Friend WithEvents cmdOpenBatchForm As System.Windows.Forms.Button
    Friend WithEvents cboPurchaseOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PurchaseOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
    Friend WithEvents cboInvoiceBatchNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGenerateBatchNumber As System.Windows.Forms.Button
    Friend WithEvents gpxInstructions As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gpxGoToInvoiceBatchForm As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents InvoiceProcessingBatchHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceProcessingBatchHeaderTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceProcessingBatchHeaderTableAdapter
    Friend WithEvents cmdClearForm As System.Windows.Forms.Button
    Friend WithEvents dtpShipDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dgvPurchaseOrderLines As System.Windows.Forms.DataGridView
    Friend WithEvents PurchaseOrderQuantityStatusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderQuantityStatusTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderQuantityStatusTableAdapter
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CachedCRXDropShipSO1 As MOS09Program.CachedCRXDropShipSO
    Friend WithEvents gpxShipment As System.Windows.Forms.GroupBox
    Friend WithEvents cboVendorShipmentNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ShipmentHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
    Friend WithEvents dgvLotNumbers As System.Windows.Forms.DataGridView
    Friend WithEvents ShipmentLineLotNumbersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentLineLotNumbersTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLineLotNumbersTableAdapter
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PullTestNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForInvoice As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DropShipSalesOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODropShipCustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POQuantityOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOpenEditModeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForInvoiceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POAdditionalShipToColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipMethodIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POHeaderCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseOrderHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseOrderLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POQuantityReceivedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
