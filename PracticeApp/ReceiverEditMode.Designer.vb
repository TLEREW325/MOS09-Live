<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReceiverEditMode
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveChangesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteReceiverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintReceiverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReOpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseReceiverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxReceiverTotals = New System.Windows.Forms.GroupBox
        Me.txtReceiverTotal = New System.Windows.Forms.TextBox
        Me.txtProductTotal = New System.Windows.Forms.TextBox
        Me.txtFreightCharge = New System.Windows.Forms.TextBox
        Me.txtSalesTax = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.gpxPOHeader = New System.Windows.Forms.GroupBox
        Me.cboShipVia = New System.Windows.Forms.ComboBox
        Me.ShipMethodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtVendorID = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtpPODate = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblVendorName = New System.Windows.Forms.Label
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.gpxReceivingHeaderInfo = New System.Windows.Forms.GroupBox
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtPONumber = New System.Windows.Forms.TextBox
        Me.cboReceivingTicketNumber = New System.Windows.Forms.ComboBox
        Me.ReceivingHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpReceivingDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblPONumber = New System.Windows.Forms.Label
        Me.lblReceivingDate = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ReceivingHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingHeaderTableTableAdapter
        Me.ShipMethodTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
        Me.dgvReceiverLines = New System.Windows.Forms.DataGridView
        Me.ReceivingHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityReceivedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectForInvoiceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReceivingLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingLineTableTableAdapter
        Me.gpxLineDetails = New System.Windows.Forms.GroupBox
        Me.txtQuantityReturned = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtAPLineStatus = New System.Windows.Forms.TextBox
        Me.txtQuantityOnPO = New System.Windows.Forms.TextBox
        Me.txtQuantityVouched = New System.Windows.Forms.TextBox
        Me.txtQuantityReceived = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtPartNumber = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cboReceiverLine = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.gpxCloseLine = New System.Windows.Forms.GroupBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.cmdOpenLine = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmdCloseLine = New System.Windows.Forms.Button
        Me.gpxCloseReceiver = New System.Windows.Forms.GroupBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.cmdCloseReceiver = New System.Windows.Forms.Button
        Me.dgvReceiverPurchaseClearing = New System.Windows.Forms.DataGridView
        Me.RKColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RLColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QRColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LSColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SFIColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QVColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiverPurchaseClearingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReceiverPurchaseClearingTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiverPurchaseClearingTableAdapter
        Me.ScanPackingSkipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewPackingSlipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.gpxReceiverTotals.SuspendLayout()
        Me.gpxPOHeader.SuspendLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxReceivingHeaderInfo.SuspendLayout()
        CType(Me.ReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReceiverLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceivingLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxLineDetails.SuspendLayout()
        Me.gpxCloseLine.SuspendLayout()
        Me.gpxCloseReceiver.SuspendLayout()
        CType(Me.dgvReceiverPurchaseClearing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiverPurchaseClearingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearFormToolStripMenuItem, Me.SaveChangesToolStripMenuItem, Me.DeleteReceiverToolStripMenuItem, Me.PrintReceiverToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ClearFormToolStripMenuItem
        '
        Me.ClearFormToolStripMenuItem.Name = "ClearFormToolStripMenuItem"
        Me.ClearFormToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ClearFormToolStripMenuItem.Text = "Clear Form"
        '
        'SaveChangesToolStripMenuItem
        '
        Me.SaveChangesToolStripMenuItem.Name = "SaveChangesToolStripMenuItem"
        Me.SaveChangesToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.SaveChangesToolStripMenuItem.Text = "Save Receiver"
        '
        'DeleteReceiverToolStripMenuItem
        '
        Me.DeleteReceiverToolStripMenuItem.Name = "DeleteReceiverToolStripMenuItem"
        Me.DeleteReceiverToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.DeleteReceiverToolStripMenuItem.Text = "Delete Receiver"
        '
        'PrintReceiverToolStripMenuItem
        '
        Me.PrintReceiverToolStripMenuItem.Name = "PrintReceiverToolStripMenuItem"
        Me.PrintReceiverToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.PrintReceiverToolStripMenuItem.Text = "Print Receiver"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReOpenToolStripMenuItem, Me.CloseReceiverToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReOpenToolStripMenuItem
        '
        Me.ReOpenToolStripMenuItem.Name = "ReOpenToolStripMenuItem"
        Me.ReOpenToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ReOpenToolStripMenuItem.Text = "Re-Open Receiver"
        '
        'CloseReceiverToolStripMenuItem
        '
        Me.CloseReceiverToolStripMenuItem.Name = "CloseReceiverToolStripMenuItem"
        Me.CloseReceiverToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.CloseReceiverToolStripMenuItem.Text = "Close Receiver"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewPackingSlipToolStripMenuItem, Me.ScanPackingSkipToolStripMenuItem})
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
        Me.cmdSave.Location = New System.Drawing.Point(823, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 23
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(900, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 24
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(977, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 25
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1054, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 26
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxReceiverTotals
        '
        Me.gpxReceiverTotals.Controls.Add(Me.txtReceiverTotal)
        Me.gpxReceiverTotals.Controls.Add(Me.txtProductTotal)
        Me.gpxReceiverTotals.Controls.Add(Me.txtFreightCharge)
        Me.gpxReceiverTotals.Controls.Add(Me.txtSalesTax)
        Me.gpxReceiverTotals.Controls.Add(Me.Label7)
        Me.gpxReceiverTotals.Controls.Add(Me.Label9)
        Me.gpxReceiverTotals.Controls.Add(Me.Label8)
        Me.gpxReceiverTotals.Controls.Add(Me.Label10)
        Me.gpxReceiverTotals.Location = New System.Drawing.Point(29, 677)
        Me.gpxReceiverTotals.Name = "gpxReceiverTotals"
        Me.gpxReceiverTotals.Size = New System.Drawing.Size(300, 134)
        Me.gpxReceiverTotals.TabIndex = 10
        Me.gpxReceiverTotals.TabStop = False
        Me.gpxReceiverTotals.Text = "Receiver Totals"
        '
        'txtReceiverTotal
        '
        Me.txtReceiverTotal.BackColor = System.Drawing.Color.White
        Me.txtReceiverTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReceiverTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReceiverTotal.Location = New System.Drawing.Point(135, 100)
        Me.txtReceiverTotal.Name = "txtReceiverTotal"
        Me.txtReceiverTotal.ReadOnly = True
        Me.txtReceiverTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtReceiverTotal.TabIndex = 13
        Me.txtReceiverTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtProductTotal
        '
        Me.txtProductTotal.BackColor = System.Drawing.Color.White
        Me.txtProductTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductTotal.Location = New System.Drawing.Point(135, 19)
        Me.txtProductTotal.Name = "txtProductTotal"
        Me.txtProductTotal.ReadOnly = True
        Me.txtProductTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtProductTotal.TabIndex = 10
        Me.txtProductTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFreightCharge
        '
        Me.txtFreightCharge.BackColor = System.Drawing.Color.White
        Me.txtFreightCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightCharge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreightCharge.Location = New System.Drawing.Point(135, 73)
        Me.txtFreightCharge.Name = "txtFreightCharge"
        Me.txtFreightCharge.Size = New System.Drawing.Size(148, 20)
        Me.txtFreightCharge.TabIndex = 12
        Me.txtFreightCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSalesTax
        '
        Me.txtSalesTax.BackColor = System.Drawing.Color.White
        Me.txtSalesTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesTax.Location = New System.Drawing.Point(135, 46)
        Me.txtSalesTax.Name = "txtSalesTax"
        Me.txtSalesTax.Size = New System.Drawing.Size(148, 20)
        Me.txtSalesTax.TabIndex = 11
        Me.txtSalesTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(30, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(149, 20)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Sales Tax"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(30, 102)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(149, 20)
        Me.Label9.TabIndex = 57
        Me.Label9.Text = "Receiver Total"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(30, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(149, 20)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "Product Total"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(30, 75)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(149, 20)
        Me.Label10.TabIndex = 56
        Me.Label10.Text = "Freight Charge"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxPOHeader
        '
        Me.gpxPOHeader.Controls.Add(Me.cboShipVia)
        Me.gpxPOHeader.Controls.Add(Me.txtVendorID)
        Me.gpxPOHeader.Controls.Add(Me.Label6)
        Me.gpxPOHeader.Controls.Add(Me.dtpPODate)
        Me.gpxPOHeader.Controls.Add(Me.Label5)
        Me.gpxPOHeader.Controls.Add(Me.lblVendorName)
        Me.gpxPOHeader.Controls.Add(Me.txtVendorName)
        Me.gpxPOHeader.Controls.Add(Me.Label1)
        Me.gpxPOHeader.Location = New System.Drawing.Point(29, 384)
        Me.gpxPOHeader.Name = "gpxPOHeader"
        Me.gpxPOHeader.Size = New System.Drawing.Size(300, 197)
        Me.gpxPOHeader.TabIndex = 6
        Me.gpxPOHeader.TabStop = False
        Me.gpxPOHeader.Text = "Purchase Order Info"
        '
        'cboShipVia
        '
        Me.cboShipVia.BackColor = System.Drawing.Color.White
        Me.cboShipVia.DataSource = Me.ShipMethodBindingSource
        Me.cboShipVia.DisplayMember = "ShipMethID"
        Me.cboShipVia.FormattingEnabled = True
        Me.cboShipVia.Location = New System.Drawing.Point(121, 157)
        Me.cboShipVia.Name = "cboShipVia"
        Me.cboShipVia.Size = New System.Drawing.Size(162, 21)
        Me.cboShipVia.TabIndex = 9
        '
        'ShipMethodBindingSource
        '
        Me.ShipMethodBindingSource.DataMember = "ShipMethod"
        Me.ShipMethodBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtVendorID
        '
        Me.txtVendorID.BackColor = System.Drawing.Color.White
        Me.txtVendorID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorID.Location = New System.Drawing.Point(90, 25)
        Me.txtVendorID.Name = "txtVendorID"
        Me.txtVendorID.ReadOnly = True
        Me.txtVendorID.Size = New System.Drawing.Size(193, 20)
        Me.txtVendorID.TabIndex = 6
        Me.txtVendorID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(30, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Ship Via"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpPODate
        '
        Me.dtpPODate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPODate.Location = New System.Drawing.Point(121, 125)
        Me.dtpPODate.Name = "dtpPODate"
        Me.dtpPODate.Size = New System.Drawing.Size(162, 20)
        Me.dtpPODate.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(30, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "PO Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVendorName
        '
        Me.lblVendorName.Location = New System.Drawing.Point(30, 25)
        Me.lblVendorName.Name = "lblVendorName"
        Me.lblVendorName.Size = New System.Drawing.Size(100, 20)
        Me.lblVendorName.TabIndex = 4
        Me.lblVendorName.Text = "Vendor"
        Me.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVendorName
        '
        Me.txtVendorName.BackColor = System.Drawing.Color.White
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Location = New System.Drawing.Point(30, 69)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.ReadOnly = True
        Me.txtVendorName.Size = New System.Drawing.Size(253, 44)
        Me.txtVendorName.TabIndex = 7
        Me.txtVendorName.TabStop = False
        Me.txtVendorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(30, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Vendor Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxReceivingHeaderInfo
        '
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.txtStatus)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.Label11)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.txtPONumber)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.cboReceivingTicketNumber)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.cboDivisionID)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.dtpReceivingDate)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.Label4)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.txtComment)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.Label3)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.Label2)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.lblPONumber)
        Me.gpxReceivingHeaderInfo.Controls.Add(Me.lblReceivingDate)
        Me.gpxReceivingHeaderInfo.Location = New System.Drawing.Point(29, 41)
        Me.gpxReceivingHeaderInfo.Name = "gpxReceivingHeaderInfo"
        Me.gpxReceivingHeaderInfo.Size = New System.Drawing.Size(300, 297)
        Me.gpxReceivingHeaderInfo.TabIndex = 0
        Me.gpxReceivingHeaderInfo.TabStop = False
        Me.gpxReceivingHeaderInfo.Text = "Receiving Header Info"
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.White
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStatus.Location = New System.Drawing.Point(121, 148)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(162, 20)
        Me.txtStatus.TabIndex = 4
        Me.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(30, 149)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 60
        Me.Label11.Text = "Status"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPONumber
        '
        Me.txtPONumber.BackColor = System.Drawing.Color.White
        Me.txtPONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPONumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPONumber.Location = New System.Drawing.Point(121, 60)
        Me.txtPONumber.Name = "txtPONumber"
        Me.txtPONumber.ReadOnly = True
        Me.txtPONumber.Size = New System.Drawing.Size(162, 20)
        Me.txtPONumber.TabIndex = 1
        Me.txtPONumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboReceivingTicketNumber
        '
        Me.cboReceivingTicketNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReceivingTicketNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReceivingTicketNumber.BackColor = System.Drawing.Color.White
        Me.cboReceivingTicketNumber.DataSource = Me.ReceivingHeaderTableBindingSource
        Me.cboReceivingTicketNumber.DisplayMember = "ReceivingHeaderKey"
        Me.cboReceivingTicketNumber.FormattingEnabled = True
        Me.cboReceivingTicketNumber.Location = New System.Drawing.Point(121, 30)
        Me.cboReceivingTicketNumber.Name = "cboReceivingTicketNumber"
        Me.cboReceivingTicketNumber.Size = New System.Drawing.Size(162, 21)
        Me.cboReceivingTicketNumber.TabIndex = 0
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
        Me.cboDivisionID.BackColor = System.Drawing.Color.White
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(121, 118)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(162, 21)
        Me.cboDivisionID.TabIndex = 3
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpReceivingDate
        '
        Me.dtpReceivingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReceivingDate.Location = New System.Drawing.Point(121, 89)
        Me.dtpReceivingDate.Name = "dtpReceivingDate"
        Me.dtpReceivingDate.Size = New System.Drawing.Size(162, 20)
        Me.dtpReceivingDate.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(30, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Comment"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComment
        '
        Me.txtComment.BackColor = System.Drawing.Color.White
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.Location = New System.Drawing.Point(33, 207)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(250, 73)
        Me.txtComment.TabIndex = 5
        Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(30, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Receipt #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(30, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Division ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPONumber
        '
        Me.lblPONumber.Location = New System.Drawing.Point(30, 62)
        Me.lblPONumber.Name = "lblPONumber"
        Me.lblPONumber.Size = New System.Drawing.Size(100, 20)
        Me.lblPONumber.TabIndex = 26
        Me.lblPONumber.Text = "PO Number"
        Me.lblPONumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReceivingDate
        '
        Me.lblReceivingDate.Location = New System.Drawing.Point(30, 92)
        Me.lblReceivingDate.Name = "lblReceivingDate"
        Me.lblReceivingDate.Size = New System.Drawing.Size(100, 20)
        Me.lblReceivingDate.TabIndex = 1
        Me.lblReceivingDate.Text = "Receiving Date"
        Me.lblReceivingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ReceivingHeaderTableTableAdapter
        '
        Me.ReceivingHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'ShipMethodTableAdapter
        '
        Me.ShipMethodTableAdapter.ClearBeforeFill = True
        '
        'dgvReceiverLines
        '
        Me.dgvReceiverLines.AllowUserToAddRows = False
        Me.dgvReceiverLines.AllowUserToDeleteRows = False
        Me.dgvReceiverLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReceiverLines.AutoGenerateColumns = False
        Me.dgvReceiverLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvReceiverLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvReceiverLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReceiverLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReceivingHeaderKeyColumn, Me.ReceivingLineKeyColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityReceivedColumn, Me.UnitCostColumn, Me.ExtendedAmountColumn, Me.LineStatusColumn, Me.DivisionIDColumn, Me.SelectForInvoiceColumn, Me.DebitGLAccountColumn, Me.CreditGLAccountColumn})
        Me.dgvReceiverLines.DataSource = Me.ReceivingLineTableBindingSource
        Me.dgvReceiverLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvReceiverLines.Location = New System.Drawing.Point(351, 41)
        Me.dgvReceiverLines.Name = "dgvReceiverLines"
        Me.dgvReceiverLines.Size = New System.Drawing.Size(774, 456)
        Me.dgvReceiverLines.TabIndex = 27
        Me.dgvReceiverLines.TabStop = False
        '
        'ReceivingHeaderKeyColumn
        '
        Me.ReceivingHeaderKeyColumn.DataPropertyName = "ReceivingHeaderKey"
        Me.ReceivingHeaderKeyColumn.HeaderText = "ReceivingHeaderKey"
        Me.ReceivingHeaderKeyColumn.Name = "ReceivingHeaderKeyColumn"
        Me.ReceivingHeaderKeyColumn.ReadOnly = True
        Me.ReceivingHeaderKeyColumn.Visible = False
        '
        'ReceivingLineKeyColumn
        '
        Me.ReceivingLineKeyColumn.DataPropertyName = "ReceivingLineKey"
        Me.ReceivingLineKeyColumn.HeaderText = "Line #"
        Me.ReceivingLineKeyColumn.Name = "ReceivingLineKeyColumn"
        Me.ReceivingLineKeyColumn.ReadOnly = True
        Me.ReceivingLineKeyColumn.Width = 65
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
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.ReadOnly = True
        '
        'QuantityReceivedColumn
        '
        Me.QuantityReceivedColumn.DataPropertyName = "QuantityReceived"
        DataGridViewCellStyle10.NullValue = "0"
        Me.QuantityReceivedColumn.DefaultCellStyle = DataGridViewCellStyle10
        Me.QuantityReceivedColumn.HeaderText = "Quantity Received"
        Me.QuantityReceivedColumn.Name = "QuantityReceivedColumn"
        Me.QuantityReceivedColumn.ReadOnly = True
        Me.QuantityReceivedColumn.Width = 90
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle11.Format = "N5"
        DataGridViewCellStyle11.NullValue = "0"
        Me.UnitCostColumn.DefaultCellStyle = DataGridViewCellStyle11
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.ReadOnly = True
        Me.UnitCostColumn.Width = 90
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle12.Format = "C2"
        DataGridViewCellStyle12.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle12
        Me.ExtendedAmountColumn.HeaderText = "Extended Amount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
        Me.ExtendedAmountColumn.Width = 90
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "Line Status"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.ReadOnly = True
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'SelectForInvoiceColumn
        '
        Me.SelectForInvoiceColumn.DataPropertyName = "SelectForInvoice"
        Me.SelectForInvoiceColumn.HeaderText = "AP Status"
        Me.SelectForInvoiceColumn.Name = "SelectForInvoiceColumn"
        Me.SelectForInvoiceColumn.ReadOnly = True
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "Debit Account"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        '
        'CreditGLAccountColumn
        '
        Me.CreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumn.HeaderText = "Credit Account"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
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
        'gpxLineDetails
        '
        Me.gpxLineDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxLineDetails.Controls.Add(Me.txtQuantityReturned)
        Me.gpxLineDetails.Controls.Add(Me.Label21)
        Me.gpxLineDetails.Controls.Add(Me.txtDescription)
        Me.gpxLineDetails.Controls.Add(Me.txtAPLineStatus)
        Me.gpxLineDetails.Controls.Add(Me.txtQuantityOnPO)
        Me.gpxLineDetails.Controls.Add(Me.txtQuantityVouched)
        Me.gpxLineDetails.Controls.Add(Me.txtQuantityReceived)
        Me.gpxLineDetails.Controls.Add(Me.Label14)
        Me.gpxLineDetails.Controls.Add(Me.Label15)
        Me.gpxLineDetails.Controls.Add(Me.Label16)
        Me.gpxLineDetails.Controls.Add(Me.Label17)
        Me.gpxLineDetails.Controls.Add(Me.txtPartNumber)
        Me.gpxLineDetails.Controls.Add(Me.Label13)
        Me.gpxLineDetails.Controls.Add(Me.cboReceiverLine)
        Me.gpxLineDetails.Controls.Add(Me.Label12)
        Me.gpxLineDetails.Location = New System.Drawing.Point(351, 509)
        Me.gpxLineDetails.Name = "gpxLineDetails"
        Me.gpxLineDetails.Size = New System.Drawing.Size(351, 302)
        Me.gpxLineDetails.TabIndex = 14
        Me.gpxLineDetails.TabStop = False
        Me.gpxLineDetails.Text = "Line Details"
        '
        'txtQuantityReturned
        '
        Me.txtQuantityReturned.BackColor = System.Drawing.Color.White
        Me.txtQuantityReturned.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantityReturned.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuantityReturned.Location = New System.Drawing.Point(180, 214)
        Me.txtQuantityReturned.Name = "txtQuantityReturned"
        Me.txtQuantityReturned.ReadOnly = True
        Me.txtQuantityReturned.Size = New System.Drawing.Size(148, 20)
        Me.txtQuantityReturned.TabIndex = 66
        Me.txtQuantityReturned.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(16, 214)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(149, 20)
        Me.Label21.TabIndex = 67
        Me.Label21.Text = "Qty. Returned"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.Color.White
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescription.Location = New System.Drawing.Point(19, 82)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(309, 70)
        Me.txtDescription.TabIndex = 16
        Me.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAPLineStatus
        '
        Me.txtAPLineStatus.BackColor = System.Drawing.Color.White
        Me.txtAPLineStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAPLineStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAPLineStatus.Location = New System.Drawing.Point(180, 268)
        Me.txtAPLineStatus.Name = "txtAPLineStatus"
        Me.txtAPLineStatus.ReadOnly = True
        Me.txtAPLineStatus.Size = New System.Drawing.Size(148, 20)
        Me.txtAPLineStatus.TabIndex = 29
        Me.txtAPLineStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuantityOnPO
        '
        Me.txtQuantityOnPO.BackColor = System.Drawing.Color.White
        Me.txtQuantityOnPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantityOnPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuantityOnPO.Location = New System.Drawing.Point(180, 160)
        Me.txtQuantityOnPO.Name = "txtQuantityOnPO"
        Me.txtQuantityOnPO.ReadOnly = True
        Me.txtQuantityOnPO.Size = New System.Drawing.Size(148, 20)
        Me.txtQuantityOnPO.TabIndex = 17
        Me.txtQuantityOnPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuantityVouched
        '
        Me.txtQuantityVouched.BackColor = System.Drawing.Color.White
        Me.txtQuantityVouched.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantityVouched.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuantityVouched.Location = New System.Drawing.Point(180, 241)
        Me.txtQuantityVouched.Name = "txtQuantityVouched"
        Me.txtQuantityVouched.ReadOnly = True
        Me.txtQuantityVouched.Size = New System.Drawing.Size(148, 20)
        Me.txtQuantityVouched.TabIndex = 19
        Me.txtQuantityVouched.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuantityReceived
        '
        Me.txtQuantityReceived.BackColor = System.Drawing.Color.White
        Me.txtQuantityReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantityReceived.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuantityReceived.Location = New System.Drawing.Point(180, 187)
        Me.txtQuantityReceived.Name = "txtQuantityReceived"
        Me.txtQuantityReceived.ReadOnly = True
        Me.txtQuantityReceived.Size = New System.Drawing.Size(148, 20)
        Me.txtQuantityReceived.TabIndex = 18
        Me.txtQuantityReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(16, 187)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(149, 20)
        Me.Label14.TabIndex = 63
        Me.Label14.Text = "Qty. Received"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(16, 268)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(149, 20)
        Me.Label15.TabIndex = 65
        Me.Label15.Text = "Line Status (AP)"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(16, 160)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(149, 20)
        Me.Label16.TabIndex = 62
        Me.Label16.Text = "Qty. on PO"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(16, 241)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(149, 20)
        Me.Label17.TabIndex = 64
        Me.Label17.Text = "Qty. Vouched"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartNumber
        '
        Me.txtPartNumber.BackColor = System.Drawing.Color.White
        Me.txtPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNumber.Location = New System.Drawing.Point(95, 54)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.ReadOnly = True
        Me.txtPartNumber.Size = New System.Drawing.Size(233, 20)
        Me.txtPartNumber.TabIndex = 15
        Me.txtPartNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(16, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 20)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "Part Number"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboReceiverLine
        '
        Me.cboReceiverLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReceiverLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReceiverLine.BackColor = System.Drawing.Color.White
        Me.cboReceiverLine.DataSource = Me.ReceivingLineTableBindingSource
        Me.cboReceiverLine.DisplayMember = "ReceivingLineKey"
        Me.cboReceiverLine.FormattingEnabled = True
        Me.cboReceiverLine.Location = New System.Drawing.Point(166, 25)
        Me.cboReceiverLine.Name = "cboReceiverLine"
        Me.cboReceiverLine.Size = New System.Drawing.Size(162, 21)
        Me.cboReceiverLine.TabIndex = 14
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(16, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 20)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Receiver Line #"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxCloseLine
        '
        Me.gpxCloseLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxCloseLine.Controls.Add(Me.Label20)
        Me.gpxCloseLine.Controls.Add(Me.cmdOpenLine)
        Me.gpxCloseLine.Controls.Add(Me.Label18)
        Me.gpxCloseLine.Controls.Add(Me.cmdCloseLine)
        Me.gpxCloseLine.Location = New System.Drawing.Point(823, 513)
        Me.gpxCloseLine.Name = "gpxCloseLine"
        Me.gpxCloseLine.Size = New System.Drawing.Size(302, 119)
        Me.gpxCloseLine.TabIndex = 21
        Me.gpxCloseLine.TabStop = False
        Me.gpxCloseLine.Text = "Manually Open / Close Receiver Line"
        '
        'Label20
        '
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(19, 71)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(191, 29)
        Me.Label20.TabIndex = 65
        Me.Label20.Text = "This will open line for AP Processing.  Select line to open at the left."
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdOpenLine
        '
        Me.cmdOpenLine.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdOpenLine.Location = New System.Drawing.Point(216, 65)
        Me.cmdOpenLine.Name = "cmdOpenLine"
        Me.cmdOpenLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenLine.TabIndex = 64
        Me.cmdOpenLine.Text = "Open Line"
        Me.cmdOpenLine.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.ForeColor = System.Drawing.Color.Blue
        Me.Label18.Location = New System.Drawing.Point(19, 25)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(191, 29)
        Me.Label18.TabIndex = 63
        Me.Label18.Text = "This will close line for AP Processing.  Select line to close at the left."
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCloseLine
        '
        Me.cmdCloseLine.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdCloseLine.Location = New System.Drawing.Point(216, 19)
        Me.cmdCloseLine.Name = "cmdCloseLine"
        Me.cmdCloseLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdCloseLine.TabIndex = 21
        Me.cmdCloseLine.Text = "Close Line"
        Me.cmdCloseLine.UseVisualStyleBackColor = True
        '
        'gpxCloseReceiver
        '
        Me.gpxCloseReceiver.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxCloseReceiver.Controls.Add(Me.Label19)
        Me.gpxCloseReceiver.Controls.Add(Me.cmdCloseReceiver)
        Me.gpxCloseReceiver.Location = New System.Drawing.Point(823, 648)
        Me.gpxCloseReceiver.Name = "gpxCloseReceiver"
        Me.gpxCloseReceiver.Size = New System.Drawing.Size(302, 97)
        Me.gpxCloseReceiver.TabIndex = 22
        Me.gpxCloseReceiver.TabStop = False
        Me.gpxCloseReceiver.Text = "Manually Close Receiver"
        '
        'Label19
        '
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(19, 27)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(191, 55)
        Me.Label19.TabIndex = 64
        Me.Label19.Text = "This will close all lines for AP Processing. "
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCloseReceiver
        '
        Me.cmdCloseReceiver.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdCloseReceiver.Location = New System.Drawing.Point(216, 39)
        Me.cmdCloseReceiver.Name = "cmdCloseReceiver"
        Me.cmdCloseReceiver.Size = New System.Drawing.Size(71, 40)
        Me.cmdCloseReceiver.TabIndex = 22
        Me.cmdCloseReceiver.Text = "Close Receiver"
        Me.cmdCloseReceiver.UseVisualStyleBackColor = True
        '
        'dgvReceiverPurchaseClearing
        '
        Me.dgvReceiverPurchaseClearing.AllowUserToAddRows = False
        Me.dgvReceiverPurchaseClearing.AllowUserToDeleteRows = False
        Me.dgvReceiverPurchaseClearing.AutoGenerateColumns = False
        Me.dgvReceiverPurchaseClearing.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvReceiverPurchaseClearing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReceiverPurchaseClearing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RKColumn, Me.RLColumn, Me.QRColumn, Me.LSColumn, Me.SFIColumn, Me.QVColumn, Me.QOColumn})
        Me.dgvReceiverPurchaseClearing.DataSource = Me.ReceiverPurchaseClearingBindingSource
        Me.dgvReceiverPurchaseClearing.Location = New System.Drawing.Point(351, 72)
        Me.dgvReceiverPurchaseClearing.Name = "dgvReceiverPurchaseClearing"
        Me.dgvReceiverPurchaseClearing.ReadOnly = True
        Me.dgvReceiverPurchaseClearing.Size = New System.Drawing.Size(674, 180)
        Me.dgvReceiverPurchaseClearing.TabIndex = 28
        Me.dgvReceiverPurchaseClearing.Visible = False
        '
        'RKColumn
        '
        Me.RKColumn.DataPropertyName = "ReceivingHeaderKey"
        Me.RKColumn.HeaderText = "ReceivingHeaderKey"
        Me.RKColumn.Name = "RKColumn"
        Me.RKColumn.ReadOnly = True
        '
        'RLColumn
        '
        Me.RLColumn.DataPropertyName = "ReceivingLineKey"
        Me.RLColumn.HeaderText = "ReceivingLineKey"
        Me.RLColumn.Name = "RLColumn"
        Me.RLColumn.ReadOnly = True
        '
        'QRColumn
        '
        Me.QRColumn.DataPropertyName = "QuantityReceived"
        Me.QRColumn.HeaderText = "QuantityReceived"
        Me.QRColumn.Name = "QRColumn"
        Me.QRColumn.ReadOnly = True
        '
        'LSColumn
        '
        Me.LSColumn.DataPropertyName = "LineStatus"
        Me.LSColumn.HeaderText = "LineStatus"
        Me.LSColumn.Name = "LSColumn"
        Me.LSColumn.ReadOnly = True
        '
        'SFIColumn
        '
        Me.SFIColumn.DataPropertyName = "SelectForInvoice"
        Me.SFIColumn.HeaderText = "SelectForInvoice"
        Me.SFIColumn.Name = "SFIColumn"
        Me.SFIColumn.ReadOnly = True
        '
        'QVColumn
        '
        Me.QVColumn.DataPropertyName = "QuantityVouched"
        Me.QVColumn.HeaderText = "QuantityVouched"
        Me.QVColumn.Name = "QVColumn"
        Me.QVColumn.ReadOnly = True
        '
        'QOColumn
        '
        Me.QOColumn.DataPropertyName = "QuantityOpen"
        Me.QOColumn.HeaderText = "QuantityOpen"
        Me.QOColumn.Name = "QOColumn"
        Me.QOColumn.ReadOnly = True
        '
        'ReceiverPurchaseClearingBindingSource
        '
        Me.ReceiverPurchaseClearingBindingSource.DataMember = "ReceiverPurchaseClearing"
        Me.ReceiverPurchaseClearingBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ReceiverPurchaseClearingTableAdapter
        '
        Me.ReceiverPurchaseClearingTableAdapter.ClearBeforeFill = True
        '
        'ScanPackingSkipToolStripMenuItem
        '
        Me.ScanPackingSkipToolStripMenuItem.Name = "ScanPackingSkipToolStripMenuItem"
        Me.ScanPackingSkipToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ScanPackingSkipToolStripMenuItem.Text = "Scan Packing Skip"
        '
        'ViewPackingSlipToolStripMenuItem
        '
        Me.ViewPackingSlipToolStripMenuItem.Name = "ViewPackingSlipToolStripMenuItem"
        Me.ViewPackingSlipToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ViewPackingSlipToolStripMenuItem.Text = "View Packing Slip"
        '
        'ReceiverEditMode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.dgvReceiverLines)
        Me.Controls.Add(Me.dgvReceiverPurchaseClearing)
        Me.Controls.Add(Me.gpxCloseReceiver)
        Me.Controls.Add(Me.gpxCloseLine)
        Me.Controls.Add(Me.gpxLineDetails)
        Me.Controls.Add(Me.gpxReceiverTotals)
        Me.Controls.Add(Me.gpxPOHeader)
        Me.Controls.Add(Me.gpxReceivingHeaderInfo)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ReceiverEditMode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Receiving (Edit Mode)"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxReceiverTotals.ResumeLayout(False)
        Me.gpxReceiverTotals.PerformLayout()
        Me.gpxPOHeader.ResumeLayout(False)
        Me.gpxPOHeader.PerformLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxReceivingHeaderInfo.ResumeLayout(False)
        Me.gpxReceivingHeaderInfo.PerformLayout()
        CType(Me.ReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReceiverLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceivingLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxLineDetails.ResumeLayout(False)
        Me.gpxLineDetails.PerformLayout()
        Me.gpxCloseLine.ResumeLayout(False)
        Me.gpxCloseReceiver.ResumeLayout(False)
        CType(Me.dgvReceiverPurchaseClearing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiverPurchaseClearingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents gpxReceiverTotals As System.Windows.Forms.GroupBox
    Friend WithEvents txtReceiverTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtProductTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtFreightCharge As System.Windows.Forms.TextBox
    Friend WithEvents txtSalesTax As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents gpxPOHeader As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboShipVia As System.Windows.Forms.ComboBox
    Friend WithEvents dtpPODate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblVendorName As System.Windows.Forms.Label
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gpxReceivingHeaderInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboReceivingTicketNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPONumber As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents dtpReceivingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReceivingDate As System.Windows.Forms.Label
    Friend WithEvents txtVendorID As System.Windows.Forms.TextBox
    Friend WithEvents txtPONumber As System.Windows.Forms.TextBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ReceivingHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceivingHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingHeaderTableTableAdapter
    Friend WithEvents ShipMethodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipMethodTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
    Friend WithEvents dgvReceiverLines As System.Windows.Forms.DataGridView
    Friend WithEvents ReceivingLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceivingLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingLineTableTableAdapter
    Friend WithEvents gpxLineDetails As System.Windows.Forms.GroupBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboReceiverLine As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtAPLineStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantityOnPO As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantityVouched As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantityReceived As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents gpxCloseLine As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCloseLine As System.Windows.Forms.Button
    Friend WithEvents gpxCloseReceiver As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCloseReceiver As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ClearFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveChangesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteReceiverToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintReceiverToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmdOpenLine As System.Windows.Forms.Button
    Friend WithEvents ReOpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseReceiverToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvReceiverPurchaseClearing As System.Windows.Forms.DataGridView
    Friend WithEvents ReceiverPurchaseClearingBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiverPurchaseClearingTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiverPurchaseClearingTableAdapter
    Friend WithEvents RKColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RLColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QRColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LSColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SFIColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QVColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityReceivedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForInvoiceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtQuantityReturned As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ScanPackingSkipToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewPackingSlipToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
