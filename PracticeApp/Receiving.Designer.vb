<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Receiving
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
        Me.dtpReceivingDate = New System.Windows.Forms.DateTimePicker
        Me.lblReceivingDate = New System.Windows.Forms.Label
        Me.lblVendorName = New System.Windows.Forms.Label
        Me.PurchaseOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PurchaseOrderQuantityStatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxReceivingHeaderInfo = New System.Windows.Forms.GroupBox
        Me.txtReceivingAgent = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboPONumber = New System.Windows.Forms.ComboBox
        Me.cboReceivingTicketNumber = New System.Windows.Forms.ComboBox
        Me.ReceivingHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.cmdGenerateNewReceipt = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblPONumber = New System.Windows.Forms.Label
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnLockReceiverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ReUploadPackingSlipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AppendUploadedPickTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.PurchaseOrderQuantityStatusTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderQuantityStatusTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.PurchaseOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
        Me.Label5 = New System.Windows.Forms.Label
        Me.gpxPOHeader = New System.Windows.Forms.GroupBox
        Me.txtVendorID = New System.Windows.Forms.TextBox
        Me.cboShipVia = New System.Windows.Forms.ComboBox
        Me.ShipMethodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpPODate = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtReceiverTotal = New System.Windows.Forms.TextBox
        Me.txtFreightCharge = New System.Windows.Forms.TextBox
        Me.txtSalesTax = New System.Windows.Forms.TextBox
        Me.txtProductTotal = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.dgvReceivingLines = New System.Windows.Forms.DataGridView
        Me.ReceivingHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityReceivedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineComment = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectForInvoiceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReceivingLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingLineTableTableAdapter
        Me.gpxReceiverTotals = New System.Windows.Forms.GroupBox
        Me.ReceivingHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingHeaderTableTableAdapter
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.cmdSelectLinesFromPO = New System.Windows.Forms.Button
        Me.ShipMethodTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
        Me.cmdPostReceiver = New System.Windows.Forms.Button
        Me.gpxPostReceipt = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.gpxSelectLines = New System.Windows.Forms.GroupBox
        Me.lblOpenReceivers = New System.Windows.Forms.Label
        Me.cmdUploadPackingSlip = New System.Windows.Forms.Button
        Me.cmdViewPackingList = New System.Windows.Forms.Button
        Me.cmdRemoteScan = New System.Windows.Forms.Button
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderQuantityStatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxReceivingHeaderInfo.SuspendLayout()
        CType(Me.ReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.gpxPOHeader.SuspendLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReceivingLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceivingLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxReceiverTotals.SuspendLayout()
        Me.gpxPostReceipt.SuspendLayout()
        Me.gpxSelectLines.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpReceivingDate
        '
        Me.dtpReceivingDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpReceivingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReceivingDate.Location = New System.Drawing.Point(116, 92)
        Me.dtpReceivingDate.Name = "dtpReceivingDate"
        Me.dtpReceivingDate.Size = New System.Drawing.Size(171, 20)
        Me.dtpReceivingDate.TabIndex = 4
        '
        'lblReceivingDate
        '
        Me.lblReceivingDate.Location = New System.Drawing.Point(17, 92)
        Me.lblReceivingDate.Name = "lblReceivingDate"
        Me.lblReceivingDate.Size = New System.Drawing.Size(113, 20)
        Me.lblReceivingDate.TabIndex = 1
        Me.lblReceivingDate.Text = "Receiving Date"
        Me.lblReceivingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVendorName
        '
        Me.lblVendorName.Location = New System.Drawing.Point(17, 25)
        Me.lblVendorName.Name = "lblVendorName"
        Me.lblVendorName.Size = New System.Drawing.Size(100, 20)
        Me.lblVendorName.TabIndex = 4
        Me.lblVendorName.Text = "Vendor"
        Me.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PurchaseOrderHeaderTableBindingSource
        '
        Me.PurchaseOrderHeaderTableBindingSource.DataMember = "PurchaseOrderHeaderTable"
        Me.PurchaseOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'PurchaseOrderQuantityStatusBindingSource
        '
        Me.PurchaseOrderQuantityStatusBindingSource.DataMember = "PurchaseOrderQuantityStatus"
        Me.PurchaseOrderQuantityStatusBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1053, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 21
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxReceivingHeaderInfo
        '
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.txtReceivingAgent)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.Label1)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.cboPONumber)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.cboReceivingTicketNumber)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.cboDivisionID)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.dtpReceivingDate)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.Label4)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.txtComment)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.cmdGenerateNewReceipt)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.Label3)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.Label2)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.lblPONumber)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.lblReceivingDate)
        Me.gpxReceivingHeaderInfo.Location = New System.Drawing.Point(22, 41)
        Me.gpxReceivingHeaderInfo.Name = "gpxReceivingHeaderInfo"
        Me.gpxReceivingHeaderInfo.Size = New System.Drawing.Size(300, 282)
        Me.gpxReceivingHeaderInfo.TabIndex = 0
        Me.gpxReceivingHeaderInfo.TabStop = False
        Me.gpxReceivingHeaderInfo.Text = "Receiving Header Info"
        '
        'txtReceivingAgent
        '
        Me.txtReceivingAgent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReceivingAgent.Enabled = False
        Me.txtReceivingAgent.Location = New System.Drawing.Point(119, 250)
        Me.txtReceivingAgent.Name = "txtReceivingAgent"
        Me.txtReceivingAgent.Size = New System.Drawing.Size(168, 20)
        Me.txtReceivingAgent.TabIndex = 51
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 250)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 20)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Received  by?"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPONumber
        '
        Me.cboPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPONumber.DataSource = Me.PurchaseOrderHeaderTableBindingSource
        Me.cboPONumber.DisplayMember = "PurchaseOrderHeaderKey"
        Me.cboPONumber.FormattingEnabled = True
        Me.cboPONumber.Location = New System.Drawing.Point(116, 61)
        Me.cboPONumber.Name = "cboPONumber"
        Me.cboPONumber.Size = New System.Drawing.Size(171, 21)
        Me.cboPONumber.TabIndex = 3
        '
        'cboReceivingTicketNumber
        '
        Me.cboReceivingTicketNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReceivingTicketNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReceivingTicketNumber.DataSource = Me.ReceivingHeaderTableBindingSource
        Me.cboReceivingTicketNumber.DisplayMember = "ReceivingHeaderKey"
        Me.cboReceivingTicketNumber.FormattingEnabled = True
        Me.cboReceivingTicketNumber.Location = New System.Drawing.Point(116, 30)
        Me.cboReceivingTicketNumber.Name = "cboReceivingTicketNumber"
        Me.cboReceivingTicketNumber.Size = New System.Drawing.Size(171, 21)
        Me.cboReceivingTicketNumber.TabIndex = 2
        '
        'ReceivingHeaderTableBindingSource
        '
        Me.ReceivingHeaderTableBindingSource.DataMember = "ReceivingHeaderTable"
        Me.ReceivingHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PurchaseOrderHeaderTableBindingSource, "DivisionID", True))
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(116, 122)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(171, 21)
        Me.cboDivisionID.TabIndex = 5
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 20)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Comment"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComment
        '
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.Location = New System.Drawing.Point(20, 169)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(267, 71)
        Me.txtComment.TabIndex = 6
        Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdGenerateNewReceipt
        '
        Me.cmdGenerateNewReceipt.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateNewReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateNewReceipt.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateNewReceipt.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateNewReceipt.Location = New System.Drawing.Point(84, 30)
        Me.cmdGenerateNewReceipt.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateNewReceipt.Name = "cmdGenerateNewReceipt"
        Me.cmdGenerateNewReceipt.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateNewReceipt.TabIndex = 1
        Me.cmdGenerateNewReceipt.TabStop = False
        Me.cmdGenerateNewReceipt.Text = ">>"
        Me.cmdGenerateNewReceipt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateNewReceipt.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 20)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Receipt #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 20)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Division ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPONumber
        '
        Me.lblPONumber.Location = New System.Drawing.Point(17, 62)
        Me.lblPONumber.Name = "lblPONumber"
        Me.lblPONumber.Size = New System.Drawing.Size(113, 20)
        Me.lblPONumber.TabIndex = 26
        Me.lblPONumber.Text = "PO Number"
        Me.lblPONumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVendorName
        '
        Me.txtVendorName.BackColor = System.Drawing.Color.White
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VendorBindingSource, "VendorName", True))
        Me.txtVendorName.Enabled = False
        Me.txtVendorName.Location = New System.Drawing.Point(13, 51)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.ReadOnly = True
        Me.txtVendorName.Size = New System.Drawing.Size(274, 80)
        Me.txtVendorName.TabIndex = 8
        Me.txtVendorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(822, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 18
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(738, 771)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 17
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(976, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 20
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ReportsToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 29
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveReceiptToolStripMenuItem, Me.PrintReceiptToolStripMenuItem, Me.DeleteReceiptToolStripMenuItem, Me.ClearReceiptToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveReceiptToolStripMenuItem
        '
        Me.SaveReceiptToolStripMenuItem.Name = "SaveReceiptToolStripMenuItem"
        Me.SaveReceiptToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.SaveReceiptToolStripMenuItem.Text = "Save Receipt"
        '
        'PrintReceiptToolStripMenuItem
        '
        Me.PrintReceiptToolStripMenuItem.Name = "PrintReceiptToolStripMenuItem"
        Me.PrintReceiptToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.PrintReceiptToolStripMenuItem.Text = "Print Receipt"
        '
        'DeleteReceiptToolStripMenuItem
        '
        Me.DeleteReceiptToolStripMenuItem.Name = "DeleteReceiptToolStripMenuItem"
        Me.DeleteReceiptToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.DeleteReceiptToolStripMenuItem.Text = "Delete Receipt"
        '
        'ClearReceiptToolStripMenuItem
        '
        Me.ClearReceiptToolStripMenuItem.Name = "ClearReceiptToolStripMenuItem"
        Me.ClearReceiptToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.ClearReceiptToolStripMenuItem.Text = "Clear Receipt"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UnLockReceiverToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ReportsToolStripMenuItem.Text = "Edit"
        '
        'UnLockReceiverToolStripMenuItem
        '
        Me.UnLockReceiverToolStripMenuItem.Name = "UnLockReceiverToolStripMenuItem"
        Me.UnLockReceiverToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.UnLockReceiverToolStripMenuItem.Text = "Un-Lock Receiver"
        '
        'ReportsToolStripMenuItem1
        '
        Me.ReportsToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReUploadPackingSlipToolStripMenuItem, Me.AppendUploadedPickTicketToolStripMenuItem})
        Me.ReportsToolStripMenuItem1.Name = "ReportsToolStripMenuItem1"
        Me.ReportsToolStripMenuItem1.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem1.Text = "Reports"
        '
        'ReUploadPackingSlipToolStripMenuItem
        '
        Me.ReUploadPackingSlipToolStripMenuItem.Name = "ReUploadPackingSlipToolStripMenuItem"
        Me.ReUploadPackingSlipToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.ReUploadPackingSlipToolStripMenuItem.Text = "Re-Upload Packing Slip"
        '
        'AppendUploadedPickTicketToolStripMenuItem
        '
        Me.AppendUploadedPickTicketToolStripMenuItem.Name = "AppendUploadedPickTicketToolStripMenuItem"
        Me.AppendUploadedPickTicketToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.AppendUploadedPickTicketToolStripMenuItem.Text = "Append Uploaded Packing Slip"
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
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(899, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 19
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'PurchaseOrderQuantityStatusTableAdapter
        '
        Me.PurchaseOrderQuantityStatusTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'PurchaseOrderHeaderTableTableAdapter
        '
        Me.PurchaseOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(20, 148)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "PO Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxPOHeader
        '
        Me.gpxPOHeader.Controls.Add(Me.txtVendorID)
        Me.gpxPOHeader.Controls.Add(Me.cboShipVia)
        Me.gpxPOHeader.Controls.Add(Me.dtpPODate)
        Me.gpxPOHeader.Controls.Add(Me.txtVendorName)
        Me.gpxPOHeader.Controls.Add(Me.Label6)
        Me.gpxPOHeader.Controls.Add(Me.Label5)
        Me.gpxPOHeader.Controls.Add(Me.lblVendorName)
        Me.gpxPOHeader.Location = New System.Drawing.Point(22, 344)
        Me.gpxPOHeader.Name = "gpxPOHeader"
        Me.gpxPOHeader.Size = New System.Drawing.Size(300, 220)
        Me.gpxPOHeader.TabIndex = 7
        Me.gpxPOHeader.TabStop = False
        Me.gpxPOHeader.Text = "Purchase Order Info"
        '
        'txtVendorID
        '
        Me.txtVendorID.BackColor = System.Drawing.Color.White
        Me.txtVendorID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorID.Enabled = False
        Me.txtVendorID.Location = New System.Drawing.Point(66, 25)
        Me.txtVendorID.Name = "txtVendorID"
        Me.txtVendorID.ReadOnly = True
        Me.txtVendorID.Size = New System.Drawing.Size(221, 20)
        Me.txtVendorID.TabIndex = 54
        Me.txtVendorID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboShipVia
        '
        Me.cboShipVia.DataSource = Me.ShipMethodBindingSource
        Me.cboShipVia.DisplayMember = "ShipMethID"
        Me.cboShipVia.FormattingEnabled = True
        Me.cboShipVia.Location = New System.Drawing.Point(87, 185)
        Me.cboShipVia.Name = "cboShipVia"
        Me.cboShipVia.Size = New System.Drawing.Size(200, 21)
        Me.cboShipVia.TabIndex = 10
        '
        'ShipMethodBindingSource
        '
        Me.ShipMethodBindingSource.DataMember = "ShipMethod"
        Me.ShipMethodBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpPODate
        '
        Me.dtpPODate.CustomFormat = "dd/MM/yyyy"
        Me.dtpPODate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPODate.Location = New System.Drawing.Point(119, 148)
        Me.dtpPODate.Name = "dtpPODate"
        Me.dtpPODate.Size = New System.Drawing.Size(168, 20)
        Me.dtpPODate.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(20, 186)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Ship Via"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReceiverTotal
        '
        Me.txtReceiverTotal.BackColor = System.Drawing.Color.White
        Me.txtReceiverTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReceiverTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReceiverTotal.Location = New System.Drawing.Point(136, 100)
        Me.txtReceiverTotal.Name = "txtReceiverTotal"
        Me.txtReceiverTotal.ReadOnly = True
        Me.txtReceiverTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtReceiverTotal.TabIndex = 14
        Me.txtReceiverTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFreightCharge
        '
        Me.txtFreightCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightCharge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreightCharge.Location = New System.Drawing.Point(136, 73)
        Me.txtFreightCharge.Name = "txtFreightCharge"
        Me.txtFreightCharge.Size = New System.Drawing.Size(148, 20)
        Me.txtFreightCharge.TabIndex = 13
        Me.txtFreightCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSalesTax
        '
        Me.txtSalesTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesTax.Location = New System.Drawing.Point(136, 46)
        Me.txtSalesTax.Name = "txtSalesTax"
        Me.txtSalesTax.Size = New System.Drawing.Size(148, 20)
        Me.txtSalesTax.TabIndex = 12
        Me.txtSalesTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtProductTotal
        '
        Me.txtProductTotal.BackColor = System.Drawing.Color.White
        Me.txtProductTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductTotal.Location = New System.Drawing.Point(136, 19)
        Me.txtProductTotal.Name = "txtProductTotal"
        Me.txtProductTotal.ReadOnly = True
        Me.txtProductTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtProductTotal.TabIndex = 11
        Me.txtProductTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(17, 98)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(149, 20)
        Me.Label9.TabIndex = 57
        Me.Label9.Text = "Receiver Total"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(17, 73)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(149, 20)
        Me.Label10.TabIndex = 56
        Me.Label10.Text = "Freight Charge"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(149, 20)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Sales Tax"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(149, 20)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "Product Total"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvReceivingLines
        '
        Me.dgvReceivingLines.AllowUserToAddRows = False
        Me.dgvReceivingLines.AllowUserToDeleteRows = False
        Me.dgvReceivingLines.AllowUserToOrderColumns = True
        Me.dgvReceivingLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReceivingLines.AutoGenerateColumns = False
        Me.dgvReceivingLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvReceivingLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvReceivingLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReceivingLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReceivingHeaderKeyColumn, Me.ReceivingLineKeyColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityReceivedColumn, Me.UnitCostColumn, Me.LineComment, Me.ExtendedAmountColumn, Me.LineStatusColumn, Me.DivisionIDColumn, Me.SelectForInvoiceColumn, Me.CreditGLAccountColumn, Me.DebitGLAccountColumn, Me.POLineNumberColumn})
        Me.dgvReceivingLines.DataSource = Me.ReceivingLineTableBindingSource
        Me.dgvReceivingLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvReceivingLines.Location = New System.Drawing.Point(350, 41)
        Me.dgvReceivingLines.Name = "dgvReceivingLines"
        Me.dgvReceivingLines.Size = New System.Drawing.Size(780, 581)
        Me.dgvReceivingLines.TabIndex = 0
        '
        'ReceivingHeaderKeyColumn
        '
        Me.ReceivingHeaderKeyColumn.DataPropertyName = "ReceivingHeaderKey"
        Me.ReceivingHeaderKeyColumn.HeaderText = "ReceivingHeaderKey"
        Me.ReceivingHeaderKeyColumn.Name = "ReceivingHeaderKeyColumn"
        Me.ReceivingHeaderKeyColumn.Visible = False
        '
        'ReceivingLineKeyColumn
        '
        Me.ReceivingLineKeyColumn.DataPropertyName = "ReceivingLineKey"
        Me.ReceivingLineKeyColumn.HeaderText = "Line #"
        Me.ReceivingLineKeyColumn.Name = "ReceivingLineKeyColumn"
        Me.ReceivingLineKeyColumn.ReadOnly = True
        Me.ReceivingLineKeyColumn.Width = 60
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        Me.PartNumberColumn.Width = 200
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.ReadOnly = True
        Me.PartDescriptionColumn.Width = 200
        '
        'QuantityReceivedColumn
        '
        Me.QuantityReceivedColumn.DataPropertyName = "QuantityReceived"
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.NullValue = "0"
        Me.QuantityReceivedColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.QuantityReceivedColumn.HeaderText = "Qty. Received"
        Me.QuantityReceivedColumn.Name = "QuantityReceivedColumn"
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = "0"
        Me.UnitCostColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.Width = 90
        '
        'LineComment
        '
        Me.LineComment.DataPropertyName = "LineComment"
        Me.LineComment.HeaderText = "Line Comment"
        Me.LineComment.Name = "LineComment"
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ExtendedAmountColumn.HeaderText = "Extended Amount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.Visible = False
        Me.ExtendedAmountColumn.Width = 90
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
        Me.CreditGLAccountColumn.HeaderText = "Credit Account"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
        Me.CreditGLAccountColumn.Visible = False
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "Debit Account"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        Me.DebitGLAccountColumn.Visible = False
        '
        'POLineNumberColumn
        '
        Me.POLineNumberColumn.DataPropertyName = "POLineNumber"
        Me.POLineNumberColumn.HeaderText = "POLineNumber"
        Me.POLineNumberColumn.Name = "POLineNumberColumn"
        Me.POLineNumberColumn.Visible = False
        '
        'ReceivingLineTableBindingSource
        '
        Me.ReceivingLineTableBindingSource.DataMember = "ReceivingLineTable"
        Me.ReceivingLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ReceivingLineTableTableAdapter
        '
        Me.ReceivingLineTableTableAdapter.ClearBeforeFill = True
        '
        'gpxReceiverTotals
        '
        Me.gpxReceiverTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gpxReceiverTotals.Controls.Add(Me.txtReceiverTotal)
        Me.gpxReceiverTotals.Controls.Add(Me.txtProductTotal)
        Me.gpxReceiverTotals.Controls.Add(Me.txtFreightCharge)
        Me.gpxReceiverTotals.Controls.Add(Me.txtSalesTax)
        Me.gpxReceiverTotals.Controls.Add(Me.Label7)
        Me.gpxReceiverTotals.Controls.Add(Me.Label9)
        Me.gpxReceiverTotals.Controls.Add(Me.Label8)
        Me.gpxReceiverTotals.Controls.Add(Me.Label10)
        Me.gpxReceiverTotals.Location = New System.Drawing.Point(22, 678)
        Me.gpxReceiverTotals.Name = "gpxReceiverTotals"
        Me.gpxReceiverTotals.Size = New System.Drawing.Size(300, 134)
        Me.gpxReceiverTotals.TabIndex = 11
        Me.gpxReceiverTotals.TabStop = False
        Me.gpxReceiverTotals.Text = "Receiver Totals"
        '
        'ReceivingHeaderTableTableAdapter
        '
        Me.ReceivingHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(102, 72)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(195, 39)
        Me.Label20.TabIndex = 58
        Me.Label20.Text = "Change quantities for Receiving in grid if necessary, then SAVE."
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(99, 30)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(198, 40)
        Me.Label19.TabIndex = 57
        Me.Label19.Text = "Opens form to select lines to add to the Receiving Ticket."
        '
        'cmdSelectLinesFromPO
        '
        Me.cmdSelectLinesFromPO.ForeColor = System.Drawing.Color.Blue
        Me.cmdSelectLinesFromPO.Location = New System.Drawing.Point(19, 30)
        Me.cmdSelectLinesFromPO.Name = "cmdSelectLinesFromPO"
        Me.cmdSelectLinesFromPO.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectLinesFromPO.TabIndex = 15
        Me.cmdSelectLinesFromPO.Text = "Select Lines"
        Me.cmdSelectLinesFromPO.UseVisualStyleBackColor = True
        '
        'ShipMethodTableAdapter
        '
        Me.ShipMethodTableAdapter.ClearBeforeFill = True
        '
        'cmdPostReceiver
        '
        Me.cmdPostReceiver.ForeColor = System.Drawing.Color.Blue
        Me.cmdPostReceiver.Location = New System.Drawing.Point(19, 32)
        Me.cmdPostReceiver.Name = "cmdPostReceiver"
        Me.cmdPostReceiver.Size = New System.Drawing.Size(71, 40)
        Me.cmdPostReceiver.TabIndex = 16
        Me.cmdPostReceiver.Text = "Post Receipt"
        Me.cmdPostReceiver.UseVisualStyleBackColor = True
        '
        'gpxPostReceipt
        '
        Me.gpxPostReceipt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxPostReceipt.Controls.Add(Me.Label11)
        Me.gpxPostReceipt.Controls.Add(Me.cmdPostReceiver)
        Me.gpxPostReceipt.Location = New System.Drawing.Point(822, 641)
        Me.gpxPostReceipt.Name = "gpxPostReceipt"
        Me.gpxPostReceipt.Size = New System.Drawing.Size(302, 115)
        Me.gpxPostReceipt.TabIndex = 16
        Me.gpxPostReceipt.TabStop = False
        Me.gpxPostReceipt.Text = "Post Receiving Ticket"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(109, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(187, 70)
        Me.Label11.TabIndex = 60
        Me.Label11.Text = "Post Receiving Ticket once Receiving Quantities are correct. Once this ticket is " & _
            "posted, no further changes may be made."
        '
        'gpxSelectLines
        '
        Me.gpxSelectLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxSelectLines.Controls.Add(Me.cmdSelectLinesFromPO)
        Me.gpxSelectLines.Controls.Add(Me.Label19)
        Me.gpxSelectLines.Controls.Add(Me.Label20)
        Me.gpxSelectLines.Location = New System.Drawing.Point(350, 641)
        Me.gpxSelectLines.Name = "gpxSelectLines"
        Me.gpxSelectLines.Size = New System.Drawing.Size(317, 115)
        Me.gpxSelectLines.TabIndex = 15
        Me.gpxSelectLines.TabStop = False
        Me.gpxSelectLines.Text = "Select Lines from PO to Receive"
        '
        'lblOpenReceivers
        '
        Me.lblOpenReceivers.ForeColor = System.Drawing.Color.Red
        Me.lblOpenReceivers.Location = New System.Drawing.Point(32, 595)
        Me.lblOpenReceivers.Name = "lblOpenReceivers"
        Me.lblOpenReceivers.Size = New System.Drawing.Size(264, 49)
        Me.lblOpenReceivers.TabIndex = 55
        Me.lblOpenReceivers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdUploadPackingSlip
        '
        Me.cmdUploadPackingSlip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUploadPackingSlip.Location = New System.Drawing.Point(350, 771)
        Me.cmdUploadPackingSlip.Name = "cmdUploadPackingSlip"
        Me.cmdUploadPackingSlip.Size = New System.Drawing.Size(71, 40)
        Me.cmdUploadPackingSlip.TabIndex = 56
        Me.cmdUploadPackingSlip.Text = "Upload Packing"
        Me.cmdUploadPackingSlip.UseVisualStyleBackColor = True
        '
        'cmdViewPackingList
        '
        Me.cmdViewPackingList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewPackingList.Location = New System.Drawing.Point(427, 771)
        Me.cmdViewPackingList.Name = "cmdViewPackingList"
        Me.cmdViewPackingList.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewPackingList.TabIndex = 57
        Me.cmdViewPackingList.Text = "View Packing"
        Me.cmdViewPackingList.UseVisualStyleBackColor = True
        '
        'cmdRemoteScan
        '
        Me.cmdRemoteScan.Location = New System.Drawing.Point(350, 771)
        Me.cmdRemoteScan.Name = "cmdRemoteScan"
        Me.cmdRemoteScan.Size = New System.Drawing.Size(71, 40)
        Me.cmdRemoteScan.TabIndex = 58
        Me.cmdRemoteScan.Text = "Upload Packing"
        Me.cmdRemoteScan.UseVisualStyleBackColor = True
        '
        'Receiving
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdRemoteScan)
        Me.Controls.Add(Me.cmdViewPackingList)
        Me.Controls.Add(Me.cmdUploadPackingSlip)
        Me.Controls.Add(Me.lblOpenReceivers)
        Me.Controls.Add(Me.gpxSelectLines)
        Me.Controls.Add(Me.gpxPostReceipt)
        Me.Controls.Add(Me.dgvReceivingLines)
        Me.Controls.Add(Me.gpxReceiverTotals)
        Me.Controls.Add(Me.gpxPOHeader)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.gpxReceivingHeaderInfo)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Receiving"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Receiving Form"
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderQuantityStatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxReceivingHeaderInfo.ResumeLayout(False)
        Me.gpxReceivingHeaderInfo.PerformLayout()
        CType(Me.ReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxPOHeader.ResumeLayout(False)
        Me.gpxPOHeader.PerformLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReceivingLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceivingLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxReceiverTotals.ResumeLayout(False)
        Me.gpxReceiverTotals.PerformLayout()
        Me.gpxPostReceipt.ResumeLayout(False)
        Me.gpxSelectLines.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpReceivingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReceivingDate As System.Windows.Forms.Label
    Friend WithEvents lblVendorName As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxReceivingHeaderInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblPONumber As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboReceivingTicketNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdGenerateNewReceipt As System.Windows.Forms.Button
    Friend WithEvents ReceivingHeaderKeyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingLineNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingCostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboPONumber As System.Windows.Forms.ComboBox
    Friend WithEvents ReportsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents RecievedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents PurchaseOrderQuantityStatusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderQuantityStatusTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderQuantityStatusTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents PurchaseOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gpxPOHeader As System.Windows.Forms.GroupBox
    Friend WithEvents dtpPODate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtReceiverTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtFreightCharge As System.Windows.Forms.TextBox
    Friend WithEvents txtSalesTax As System.Windows.Forms.TextBox
    Friend WithEvents txtProductTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboShipVia As System.Windows.Forms.ComboBox
    Friend WithEvents dgvReceivingLines As System.Windows.Forms.DataGridView
    Friend WithEvents ReceivingLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceivingLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingLineTableTableAdapter
    Friend WithEvents gpxReceiverTotals As System.Windows.Forms.GroupBox
    Friend WithEvents ReceivingHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceivingHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingHeaderTableTableAdapter
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmdSelectLinesFromPO As System.Windows.Forms.Button
    Friend WithEvents ShipMethodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipMethodTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
    Friend WithEvents cmdPostReceiver As System.Windows.Forms.Button
    Friend WithEvents gpxPostReceipt As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents gpxSelectLines As System.Windows.Forms.GroupBox
    Friend WithEvents SaveReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnLockReceiverToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblOpenReceivers As System.Windows.Forms.Label
    Friend WithEvents cmdUploadPackingSlip As System.Windows.Forms.Button
    Friend WithEvents ReUploadPackingSlipToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppendUploadedPickTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtVendorID As System.Windows.Forms.TextBox
    Friend WithEvents txtReceivingAgent As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ReceivingHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityReceivedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineComment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForInvoiceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdViewPackingList As System.Windows.Forms.Button
    Friend WithEvents cmdRemoteScan As System.Windows.Forms.Button
End Class
