<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DailyTotals
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MonthSnapshotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxCompanyData = New System.Windows.Forms.GroupBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.dtpDateSelection = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtInventoryUnits = New System.Windows.Forms.TextBox
        Me.txtTransfersOut = New System.Windows.Forms.TextBox
        Me.txtCustomerReturns = New System.Windows.Forms.TextBox
        Me.txtInvoices = New System.Windows.Forms.TextBox
        Me.txtShipments = New System.Windows.Forms.TextBox
        Me.txtSalesOrders = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.gpxSalesData = New System.Windows.Forms.GroupBox
        Me.txtQuotes = New System.Windows.Forms.TextBox
        Me.Label47 = New System.Windows.Forms.Label
        Me.gpxPurchaseData = New System.Windows.Forms.GroupBox
        Me.txtPurchaseOrders = New System.Windows.Forms.TextBox
        Me.txtTransfersIn = New System.Windows.Forms.TextBox
        Me.txtReceipts = New System.Windows.Forms.TextBox
        Me.txtVendorReturns = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtProductionUnits = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.gpxProductionData = New System.Windows.Forms.GroupBox
        Me.gpxAPData = New System.Windows.Forms.GroupBox
        Me.txtPayableTotal = New System.Windows.Forms.TextBox
        Me.Label48 = New System.Windows.Forms.Label
        Me.txtAPMore90 = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtAPPaymentsMade = New System.Windows.Forms.TextBox
        Me.txtAP6190 = New System.Windows.Forms.TextBox
        Me.txtAP4660 = New System.Windows.Forms.TextBox
        Me.txtAPLess30 = New System.Windows.Forms.TextBox
        Me.txtAP3145 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.gpxInventoryData = New System.Windows.Forms.GroupBox
        Me.txtRawMaterialTotal = New System.Windows.Forms.TextBox
        Me.Label46 = New System.Windows.Forms.Label
        Me.txtValueByGL = New System.Windows.Forms.TextBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.txtConsignmentInventory = New System.Windows.Forms.TextBox
        Me.txtInventoryQuantity = New System.Windows.Forms.TextBox
        Me.txtAverageCostInventory = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.gpxTotals = New System.Windows.Forms.GroupBox
        Me.txtYTDReceivers = New System.Windows.Forms.TextBox
        Me.txtMTDReceivers = New System.Windows.Forms.TextBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.txtYTDInvoices = New System.Windows.Forms.TextBox
        Me.txtMTDInvoices = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.txtYTDTransfersOut = New System.Windows.Forms.TextBox
        Me.txtMTDTransfersOut = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.txtYTDShipments = New System.Windows.Forms.TextBox
        Me.txtYTDTransfersIn = New System.Windows.Forms.TextBox
        Me.txtMTDTransfersIn = New System.Windows.Forms.TextBox
        Me.txtMTDProduction = New System.Windows.Forms.TextBox
        Me.txtYTDProduction = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.txtMTDSales = New System.Windows.Forms.TextBox
        Me.txtMTDShipments = New System.Windows.Forms.TextBox
        Me.txtYTDPurchases = New System.Windows.Forms.TextBox
        Me.txtYTDSales = New System.Windows.Forms.TextBox
        Me.txtMTDPurchases = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label49 = New System.Windows.Forms.Label
        Me.txtTotalReceivables = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.txtARMore90 = New System.Windows.Forms.TextBox
        Me.txtARPaymentsReceived = New System.Windows.Forms.TextBox
        Me.txtAR6190 = New System.Windows.Forms.TextBox
        Me.txtAR4660 = New System.Windows.Forms.TextBox
        Me.txtARLess30 = New System.Windows.Forms.TextBox
        Me.txtAR3145 = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxCompanyData.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxSalesData.SuspendLayout()
        Me.gpxPurchaseData.SuspendLayout()
        Me.gpxProductionData.SuspendLayout()
        Me.gpxAPData.SuspendLayout()
        Me.gpxInventoryData.SuspendLayout()
        Me.gpxTotals.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
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
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MonthSnapshotToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'MonthSnapshotToolStripMenuItem
        '
        Me.MonthSnapshotToolStripMenuItem.Name = "MonthSnapshotToolStripMenuItem"
        Me.MonthSnapshotToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.MonthSnapshotToolStripMenuItem.Text = "Month Snapshot"
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
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 721)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 53
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxCompanyData
        '
        Me.gpxCompanyData.Controls.Add(Me.cboDivisionID)
        Me.gpxCompanyData.Controls.Add(Me.dtpDateSelection)
        Me.gpxCompanyData.Controls.Add(Me.Label1)
        Me.gpxCompanyData.Controls.Add(Me.Label8)
        Me.gpxCompanyData.Location = New System.Drawing.Point(29, 41)
        Me.gpxCompanyData.Name = "gpxCompanyData"
        Me.gpxCompanyData.Size = New System.Drawing.Size(320, 102)
        Me.gpxCompanyData.TabIndex = 0
        Me.gpxCompanyData.TabStop = False
        Me.gpxCompanyData.Text = "Company Data and Date"
        '
        'cboDivisionID
        '
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(161, 64)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(140, 21)
        Me.cboDivisionID.TabIndex = 1
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
        'dtpDateSelection
        '
        Me.dtpDateSelection.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateSelection.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateSelection.Location = New System.Drawing.Point(161, 30)
        Me.dtpDateSelection.Name = "dtpDateSelection"
        Me.dtpDateSelection.Size = New System.Drawing.Size(140, 20)
        Me.dtpDateSelection.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 20)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Date"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(19, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 20)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "Division ID"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInventoryUnits
        '
        Me.txtInventoryUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInventoryUnits.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInventoryUnits.Location = New System.Drawing.Point(158, 58)
        Me.txtInventoryUnits.Name = "txtInventoryUnits"
        Me.txtInventoryUnits.Size = New System.Drawing.Size(140, 20)
        Me.txtInventoryUnits.TabIndex = 13
        Me.txtInventoryUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTransfersOut
        '
        Me.txtTransfersOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransfersOut.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransfersOut.Enabled = False
        Me.txtTransfersOut.Location = New System.Drawing.Point(161, 165)
        Me.txtTransfersOut.Name = "txtTransfersOut"
        Me.txtTransfersOut.Size = New System.Drawing.Size(140, 20)
        Me.txtTransfersOut.TabIndex = 7
        Me.txtTransfersOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCustomerReturns
        '
        Me.txtCustomerReturns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerReturns.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerReturns.Location = New System.Drawing.Point(161, 137)
        Me.txtCustomerReturns.Name = "txtCustomerReturns"
        Me.txtCustomerReturns.Size = New System.Drawing.Size(140, 20)
        Me.txtCustomerReturns.TabIndex = 6
        Me.txtCustomerReturns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInvoices
        '
        Me.txtInvoices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoices.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoices.Location = New System.Drawing.Point(161, 109)
        Me.txtInvoices.Name = "txtInvoices"
        Me.txtInvoices.Size = New System.Drawing.Size(140, 20)
        Me.txtInvoices.TabIndex = 5
        Me.txtInvoices.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtShipments
        '
        Me.txtShipments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipments.Location = New System.Drawing.Point(161, 81)
        Me.txtShipments.Name = "txtShipments"
        Me.txtShipments.Size = New System.Drawing.Size(140, 20)
        Me.txtShipments.TabIndex = 4
        Me.txtShipments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSalesOrders
        '
        Me.txtSalesOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesOrders.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesOrders.Location = New System.Drawing.Point(161, 53)
        Me.txtSalesOrders.Name = "txtSalesOrders"
        Me.txtSalesOrders.Size = New System.Drawing.Size(140, 20)
        Me.txtSalesOrders.TabIndex = 3
        Me.txtSalesOrders.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(19, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 20)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Transfers Out"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(19, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 20)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Customer Returns"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(19, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 20)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Invoices"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(19, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 20)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Shipments"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Sales Orders"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 20)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Inventory Units"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxSalesData
        '
        Me.gpxSalesData.Controls.Add(Me.txtQuotes)
        Me.gpxSalesData.Controls.Add(Me.Label47)
        Me.gpxSalesData.Controls.Add(Me.txtSalesOrders)
        Me.gpxSalesData.Controls.Add(Me.txtTransfersOut)
        Me.gpxSalesData.Controls.Add(Me.txtCustomerReturns)
        Me.gpxSalesData.Controls.Add(Me.txtShipments)
        Me.gpxSalesData.Controls.Add(Me.txtInvoices)
        Me.gpxSalesData.Controls.Add(Me.Label2)
        Me.gpxSalesData.Controls.Add(Me.Label3)
        Me.gpxSalesData.Controls.Add(Me.Label4)
        Me.gpxSalesData.Controls.Add(Me.Label5)
        Me.gpxSalesData.Controls.Add(Me.Label6)
        Me.gpxSalesData.Location = New System.Drawing.Point(29, 182)
        Me.gpxSalesData.Name = "gpxSalesData"
        Me.gpxSalesData.Size = New System.Drawing.Size(320, 204)
        Me.gpxSalesData.TabIndex = 2
        Me.gpxSalesData.TabStop = False
        Me.gpxSalesData.Text = "Sales Data"
        '
        'txtQuotes
        '
        Me.txtQuotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuotes.Location = New System.Drawing.Point(161, 25)
        Me.txtQuotes.Name = "txtQuotes"
        Me.txtQuotes.Size = New System.Drawing.Size(140, 20)
        Me.txtQuotes.TabIndex = 2
        Me.txtQuotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(19, 25)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(120, 20)
        Me.Label47.TabIndex = 47
        Me.Label47.Text = "Quotes"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxPurchaseData
        '
        Me.gpxPurchaseData.Controls.Add(Me.txtPurchaseOrders)
        Me.gpxPurchaseData.Controls.Add(Me.txtTransfersIn)
        Me.gpxPurchaseData.Controls.Add(Me.txtReceipts)
        Me.gpxPurchaseData.Controls.Add(Me.txtVendorReturns)
        Me.gpxPurchaseData.Controls.Add(Me.Label9)
        Me.gpxPurchaseData.Controls.Add(Me.Label10)
        Me.gpxPurchaseData.Controls.Add(Me.Label11)
        Me.gpxPurchaseData.Controls.Add(Me.Label12)
        Me.gpxPurchaseData.Location = New System.Drawing.Point(29, 412)
        Me.gpxPurchaseData.Name = "gpxPurchaseData"
        Me.gpxPurchaseData.Size = New System.Drawing.Size(320, 162)
        Me.gpxPurchaseData.TabIndex = 8
        Me.gpxPurchaseData.TabStop = False
        Me.gpxPurchaseData.Text = "Purchase Data"
        '
        'txtPurchaseOrders
        '
        Me.txtPurchaseOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPurchaseOrders.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPurchaseOrders.Location = New System.Drawing.Point(161, 27)
        Me.txtPurchaseOrders.Name = "txtPurchaseOrders"
        Me.txtPurchaseOrders.Size = New System.Drawing.Size(140, 20)
        Me.txtPurchaseOrders.TabIndex = 8
        Me.txtPurchaseOrders.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTransfersIn
        '
        Me.txtTransfersIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransfersIn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransfersIn.Enabled = False
        Me.txtTransfersIn.Location = New System.Drawing.Point(161, 120)
        Me.txtTransfersIn.Name = "txtTransfersIn"
        Me.txtTransfersIn.Size = New System.Drawing.Size(140, 20)
        Me.txtTransfersIn.TabIndex = 11
        Me.txtTransfersIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReceipts
        '
        Me.txtReceipts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReceipts.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReceipts.Location = New System.Drawing.Point(161, 58)
        Me.txtReceipts.Name = "txtReceipts"
        Me.txtReceipts.Size = New System.Drawing.Size(140, 20)
        Me.txtReceipts.TabIndex = 9
        Me.txtReceipts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVendorReturns
        '
        Me.txtVendorReturns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorReturns.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorReturns.Location = New System.Drawing.Point(161, 89)
        Me.txtVendorReturns.Name = "txtVendorReturns"
        Me.txtVendorReturns.Size = New System.Drawing.Size(140, 20)
        Me.txtVendorReturns.TabIndex = 10
        Me.txtVendorReturns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(19, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 20)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Purchase Orders"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(19, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 20)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Receipts"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(19, 89)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 20)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "Vendor Returns"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(19, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 20)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "Transfers In"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProductionUnits
        '
        Me.txtProductionUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductionUnits.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductionUnits.Location = New System.Drawing.Point(158, 28)
        Me.txtProductionUnits.Name = "txtProductionUnits"
        Me.txtProductionUnits.Size = New System.Drawing.Size(140, 20)
        Me.txtProductionUnits.TabIndex = 12
        Me.txtProductionUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(16, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 20)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "Production Units"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxProductionData
        '
        Me.gpxProductionData.Controls.Add(Me.txtProductionUnits)
        Me.gpxProductionData.Controls.Add(Me.Label13)
        Me.gpxProductionData.Controls.Add(Me.txtInventoryUnits)
        Me.gpxProductionData.Controls.Add(Me.Label7)
        Me.gpxProductionData.Location = New System.Drawing.Point(29, 613)
        Me.gpxProductionData.Name = "gpxProductionData"
        Me.gpxProductionData.Size = New System.Drawing.Size(320, 97)
        Me.gpxProductionData.TabIndex = 12
        Me.gpxProductionData.TabStop = False
        Me.gpxProductionData.Text = "Production Data"
        '
        'gpxAPData
        '
        Me.gpxAPData.Controls.Add(Me.txtPayableTotal)
        Me.gpxAPData.Controls.Add(Me.Label48)
        Me.gpxAPData.Controls.Add(Me.txtAPMore90)
        Me.gpxAPData.Controls.Add(Me.Label23)
        Me.gpxAPData.Controls.Add(Me.txtAPPaymentsMade)
        Me.gpxAPData.Controls.Add(Me.txtAP6190)
        Me.gpxAPData.Controls.Add(Me.txtAP4660)
        Me.gpxAPData.Controls.Add(Me.txtAPLess30)
        Me.gpxAPData.Controls.Add(Me.txtAP3145)
        Me.gpxAPData.Controls.Add(Me.Label14)
        Me.gpxAPData.Controls.Add(Me.Label15)
        Me.gpxAPData.Controls.Add(Me.Label16)
        Me.gpxAPData.Controls.Add(Me.Label17)
        Me.gpxAPData.Controls.Add(Me.Label18)
        Me.gpxAPData.Location = New System.Drawing.Point(369, 207)
        Me.gpxAPData.Name = "gpxAPData"
        Me.gpxAPData.Size = New System.Drawing.Size(320, 245)
        Me.gpxAPData.TabIndex = 19
        Me.gpxAPData.TabStop = False
        Me.gpxAPData.Text = "AP Data (Aging is by today's date)"
        '
        'txtPayableTotal
        '
        Me.txtPayableTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayableTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPayableTotal.Location = New System.Drawing.Point(157, 205)
        Me.txtPayableTotal.Name = "txtPayableTotal"
        Me.txtPayableTotal.Size = New System.Drawing.Size(140, 20)
        Me.txtPayableTotal.TabIndex = 25
        Me.txtPayableTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label48
        '
        Me.Label48.Location = New System.Drawing.Point(19, 206)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(120, 20)
        Me.Label48.TabIndex = 53
        Me.Label48.Text = "Payable Total"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAPMore90
        '
        Me.txtAPMore90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAPMore90.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAPMore90.Location = New System.Drawing.Point(157, 175)
        Me.txtAPMore90.Name = "txtAPMore90"
        Me.txtAPMore90.Size = New System.Drawing.Size(140, 20)
        Me.txtAPMore90.TabIndex = 24
        Me.txtAPMore90.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(19, 174)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(120, 20)
        Me.Label23.TabIndex = 51
        Me.Label23.Text = "Aging > 90"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAPPaymentsMade
        '
        Me.txtAPPaymentsMade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAPPaymentsMade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAPPaymentsMade.Location = New System.Drawing.Point(157, 25)
        Me.txtAPPaymentsMade.Name = "txtAPPaymentsMade"
        Me.txtAPPaymentsMade.Size = New System.Drawing.Size(140, 20)
        Me.txtAPPaymentsMade.TabIndex = 19
        Me.txtAPPaymentsMade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAP6190
        '
        Me.txtAP6190.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAP6190.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAP6190.Location = New System.Drawing.Point(157, 145)
        Me.txtAP6190.Name = "txtAP6190"
        Me.txtAP6190.Size = New System.Drawing.Size(140, 20)
        Me.txtAP6190.TabIndex = 23
        Me.txtAP6190.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAP4660
        '
        Me.txtAP4660.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAP4660.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAP4660.Location = New System.Drawing.Point(157, 115)
        Me.txtAP4660.Name = "txtAP4660"
        Me.txtAP4660.Size = New System.Drawing.Size(140, 20)
        Me.txtAP4660.TabIndex = 22
        Me.txtAP4660.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAPLess30
        '
        Me.txtAPLess30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAPLess30.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAPLess30.Location = New System.Drawing.Point(157, 55)
        Me.txtAPLess30.Name = "txtAPLess30"
        Me.txtAPLess30.Size = New System.Drawing.Size(140, 20)
        Me.txtAPLess30.TabIndex = 20
        Me.txtAPLess30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAP3145
        '
        Me.txtAP3145.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAP3145.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAP3145.Location = New System.Drawing.Point(157, 85)
        Me.txtAP3145.Name = "txtAP3145"
        Me.txtAP3145.Size = New System.Drawing.Size(140, 20)
        Me.txtAP3145.TabIndex = 21
        Me.txtAP3145.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(19, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 20)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "Payments Made"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(19, 54)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(120, 20)
        Me.Label15.TabIndex = 42
        Me.Label15.Text = "Aging < 30"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(19, 84)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 20)
        Me.Label16.TabIndex = 43
        Me.Label16.Text = "Aging 31 - 45"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(19, 114)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(120, 20)
        Me.Label17.TabIndex = 44
        Me.Label17.Text = "Aging 46 - 60"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(19, 144)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(120, 20)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "Aging 61 - 90"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxInventoryData
        '
        Me.gpxInventoryData.Controls.Add(Me.txtRawMaterialTotal)
        Me.gpxInventoryData.Controls.Add(Me.Label46)
        Me.gpxInventoryData.Controls.Add(Me.txtValueByGL)
        Me.gpxInventoryData.Controls.Add(Me.Label45)
        Me.gpxInventoryData.Controls.Add(Me.txtConsignmentInventory)
        Me.gpxInventoryData.Controls.Add(Me.txtInventoryQuantity)
        Me.gpxInventoryData.Controls.Add(Me.txtAverageCostInventory)
        Me.gpxInventoryData.Controls.Add(Me.Label19)
        Me.gpxInventoryData.Controls.Add(Me.Label20)
        Me.gpxInventoryData.Controls.Add(Me.Label21)
        Me.gpxInventoryData.Location = New System.Drawing.Point(369, 41)
        Me.gpxInventoryData.Name = "gpxInventoryData"
        Me.gpxInventoryData.Size = New System.Drawing.Size(320, 150)
        Me.gpxInventoryData.TabIndex = 14
        Me.gpxInventoryData.TabStop = False
        Me.gpxInventoryData.Text = "Inventory Data"
        '
        'txtRawMaterialTotal
        '
        Me.txtRawMaterialTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRawMaterialTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRawMaterialTotal.Location = New System.Drawing.Point(157, 94)
        Me.txtRawMaterialTotal.Name = "txtRawMaterialTotal"
        Me.txtRawMaterialTotal.Size = New System.Drawing.Size(140, 20)
        Me.txtRawMaterialTotal.TabIndex = 17
        Me.txtRawMaterialTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label46
        '
        Me.Label46.Location = New System.Drawing.Point(17, 94)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(134, 20)
        Me.Label46.TabIndex = 53
        Me.Label46.Text = "Raw Material Total"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtValueByGL
        '
        Me.txtValueByGL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValueByGL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValueByGL.Location = New System.Drawing.Point(157, 19)
        Me.txtValueByGL.Name = "txtValueByGL"
        Me.txtValueByGL.Size = New System.Drawing.Size(140, 20)
        Me.txtValueByGL.TabIndex = 14
        Me.txtValueByGL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label45
        '
        Me.Label45.Location = New System.Drawing.Point(17, 19)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(134, 20)
        Me.Label45.TabIndex = 52
        Me.Label45.Text = "Inventory Valuation BY GL"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtConsignmentInventory
        '
        Me.txtConsignmentInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConsignmentInventory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConsignmentInventory.Location = New System.Drawing.Point(157, 44)
        Me.txtConsignmentInventory.Name = "txtConsignmentInventory"
        Me.txtConsignmentInventory.Size = New System.Drawing.Size(140, 20)
        Me.txtConsignmentInventory.TabIndex = 15
        Me.txtConsignmentInventory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInventoryQuantity
        '
        Me.txtInventoryQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInventoryQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInventoryQuantity.Enabled = False
        Me.txtInventoryQuantity.Location = New System.Drawing.Point(157, 69)
        Me.txtInventoryQuantity.Name = "txtInventoryQuantity"
        Me.txtInventoryQuantity.Size = New System.Drawing.Size(140, 20)
        Me.txtInventoryQuantity.TabIndex = 16
        Me.txtInventoryQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAverageCostInventory
        '
        Me.txtAverageCostInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAverageCostInventory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAverageCostInventory.Enabled = False
        Me.txtAverageCostInventory.Location = New System.Drawing.Point(157, 119)
        Me.txtAverageCostInventory.Name = "txtAverageCostInventory"
        Me.txtAverageCostInventory.Size = New System.Drawing.Size(140, 20)
        Me.txtAverageCostInventory.TabIndex = 18
        Me.txtAverageCostInventory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(17, 44)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(134, 20)
        Me.Label19.TabIndex = 41
        Me.Label19.Text = "Consignment Inventory"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(17, 69)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(134, 20)
        Me.Label20.TabIndex = 42
        Me.Label20.Text = "Inventory Quantity"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(17, 119)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(134, 20)
        Me.Label21.TabIndex = 43
        Me.Label21.Text = "Average Cost"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxTotals
        '
        Me.gpxTotals.Controls.Add(Me.txtYTDReceivers)
        Me.gpxTotals.Controls.Add(Me.txtMTDReceivers)
        Me.gpxTotals.Controls.Add(Me.Label43)
        Me.gpxTotals.Controls.Add(Me.Label44)
        Me.gpxTotals.Controls.Add(Me.txtYTDInvoices)
        Me.gpxTotals.Controls.Add(Me.txtMTDInvoices)
        Me.gpxTotals.Controls.Add(Me.Label22)
        Me.gpxTotals.Controls.Add(Me.Label42)
        Me.gpxTotals.Controls.Add(Me.txtYTDTransfersOut)
        Me.gpxTotals.Controls.Add(Me.txtMTDTransfersOut)
        Me.gpxTotals.Controls.Add(Me.Label39)
        Me.gpxTotals.Controls.Add(Me.Label40)
        Me.gpxTotals.Controls.Add(Me.txtYTDShipments)
        Me.gpxTotals.Controls.Add(Me.txtYTDTransfersIn)
        Me.gpxTotals.Controls.Add(Me.txtMTDTransfersIn)
        Me.gpxTotals.Controls.Add(Me.txtMTDProduction)
        Me.gpxTotals.Controls.Add(Me.txtYTDProduction)
        Me.gpxTotals.Controls.Add(Me.Label34)
        Me.gpxTotals.Controls.Add(Me.Label35)
        Me.gpxTotals.Controls.Add(Me.Label36)
        Me.gpxTotals.Controls.Add(Me.Label37)
        Me.gpxTotals.Controls.Add(Me.Label38)
        Me.gpxTotals.Controls.Add(Me.txtMTDSales)
        Me.gpxTotals.Controls.Add(Me.txtMTDShipments)
        Me.gpxTotals.Controls.Add(Me.txtYTDPurchases)
        Me.gpxTotals.Controls.Add(Me.txtYTDSales)
        Me.gpxTotals.Controls.Add(Me.txtMTDPurchases)
        Me.gpxTotals.Controls.Add(Me.Label24)
        Me.gpxTotals.Controls.Add(Me.Label25)
        Me.gpxTotals.Controls.Add(Me.Label26)
        Me.gpxTotals.Controls.Add(Me.Label27)
        Me.gpxTotals.Controls.Add(Me.Label28)
        Me.gpxTotals.Location = New System.Drawing.Point(709, 41)
        Me.gpxTotals.Name = "gpxTotals"
        Me.gpxTotals.Size = New System.Drawing.Size(320, 671)
        Me.gpxTotals.TabIndex = 33
        Me.gpxTotals.TabStop = False
        Me.gpxTotals.Text = "Totals To Date"
        '
        'txtYTDReceivers
        '
        Me.txtYTDReceivers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYTDReceivers.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtYTDReceivers.Location = New System.Drawing.Point(159, 378)
        Me.txtYTDReceivers.Name = "txtYTDReceivers"
        Me.txtYTDReceivers.Size = New System.Drawing.Size(140, 20)
        Me.txtYTDReceivers.TabIndex = 42
        Me.txtYTDReceivers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMTDReceivers
        '
        Me.txtMTDReceivers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMTDReceivers.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMTDReceivers.Location = New System.Drawing.Point(159, 346)
        Me.txtMTDReceivers.Name = "txtMTDReceivers"
        Me.txtMTDReceivers.Size = New System.Drawing.Size(140, 20)
        Me.txtMTDReceivers.TabIndex = 41
        Me.txtMTDReceivers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(19, 346)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(134, 20)
        Me.Label43.TabIndex = 69
        Me.Label43.Text = "MTD Product Received"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(19, 378)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(134, 20)
        Me.Label44.TabIndex = 70
        Me.Label44.Text = "YTD Product Received"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtYTDInvoices
        '
        Me.txtYTDInvoices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYTDInvoices.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtYTDInvoices.Location = New System.Drawing.Point(159, 62)
        Me.txtYTDInvoices.Name = "txtYTDInvoices"
        Me.txtYTDInvoices.Size = New System.Drawing.Size(140, 20)
        Me.txtYTDInvoices.TabIndex = 34
        Me.txtYTDInvoices.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMTDInvoices
        '
        Me.txtMTDInvoices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMTDInvoices.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMTDInvoices.Location = New System.Drawing.Point(159, 30)
        Me.txtMTDInvoices.Name = "txtMTDInvoices"
        Me.txtMTDInvoices.Size = New System.Drawing.Size(140, 20)
        Me.txtMTDInvoices.TabIndex = 33
        Me.txtMTDInvoices.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(19, 30)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(134, 20)
        Me.Label22.TabIndex = 65
        Me.Label22.Text = "MTD Invoices"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(19, 62)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(134, 20)
        Me.Label42.TabIndex = 66
        Me.Label42.Text = "YTD Invoices"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtYTDTransfersOut
        '
        Me.txtYTDTransfersOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYTDTransfersOut.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtYTDTransfersOut.Enabled = False
        Me.txtYTDTransfersOut.Location = New System.Drawing.Point(159, 634)
        Me.txtYTDTransfersOut.Name = "txtYTDTransfersOut"
        Me.txtYTDTransfersOut.Size = New System.Drawing.Size(140, 20)
        Me.txtYTDTransfersOut.TabIndex = 48
        Me.txtYTDTransfersOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMTDTransfersOut
        '
        Me.txtMTDTransfersOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMTDTransfersOut.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMTDTransfersOut.Enabled = False
        Me.txtMTDTransfersOut.Location = New System.Drawing.Point(159, 603)
        Me.txtMTDTransfersOut.Name = "txtMTDTransfersOut"
        Me.txtMTDTransfersOut.Size = New System.Drawing.Size(140, 20)
        Me.txtMTDTransfersOut.TabIndex = 47
        Me.txtMTDTransfersOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(19, 603)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(134, 20)
        Me.Label39.TabIndex = 61
        Me.Label39.Text = "MTD Transfers Out"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(19, 634)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(134, 20)
        Me.Label40.TabIndex = 62
        Me.Label40.Text = "YTD Transfers Out"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtYTDShipments
        '
        Me.txtYTDShipments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYTDShipments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtYTDShipments.Location = New System.Drawing.Point(159, 126)
        Me.txtYTDShipments.Name = "txtYTDShipments"
        Me.txtYTDShipments.Size = New System.Drawing.Size(140, 20)
        Me.txtYTDShipments.TabIndex = 36
        Me.txtYTDShipments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtYTDTransfersIn
        '
        Me.txtYTDTransfersIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYTDTransfersIn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtYTDTransfersIn.Enabled = False
        Me.txtYTDTransfersIn.Location = New System.Drawing.Point(159, 572)
        Me.txtYTDTransfersIn.Name = "txtYTDTransfersIn"
        Me.txtYTDTransfersIn.Size = New System.Drawing.Size(140, 20)
        Me.txtYTDTransfersIn.TabIndex = 46
        Me.txtYTDTransfersIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMTDTransfersIn
        '
        Me.txtMTDTransfersIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMTDTransfersIn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMTDTransfersIn.Enabled = False
        Me.txtMTDTransfersIn.Location = New System.Drawing.Point(159, 541)
        Me.txtMTDTransfersIn.Name = "txtMTDTransfersIn"
        Me.txtMTDTransfersIn.Size = New System.Drawing.Size(140, 20)
        Me.txtMTDTransfersIn.TabIndex = 45
        Me.txtMTDTransfersIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMTDProduction
        '
        Me.txtMTDProduction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMTDProduction.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMTDProduction.Location = New System.Drawing.Point(159, 451)
        Me.txtMTDProduction.Name = "txtMTDProduction"
        Me.txtMTDProduction.Size = New System.Drawing.Size(140, 20)
        Me.txtMTDProduction.TabIndex = 43
        Me.txtMTDProduction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtYTDProduction
        '
        Me.txtYTDProduction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYTDProduction.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtYTDProduction.Location = New System.Drawing.Point(159, 482)
        Me.txtYTDProduction.Name = "txtYTDProduction"
        Me.txtYTDProduction.Size = New System.Drawing.Size(140, 20)
        Me.txtYTDProduction.TabIndex = 44
        Me.txtYTDProduction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(19, 126)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(134, 20)
        Me.Label34.TabIndex = 52
        Me.Label34.Text = "YTD Shipments"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(19, 451)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(134, 20)
        Me.Label35.TabIndex = 53
        Me.Label35.Text = "MTD Production"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(19, 482)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(134, 20)
        Me.Label36.TabIndex = 54
        Me.Label36.Text = "YTD Production"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(19, 541)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(134, 20)
        Me.Label37.TabIndex = 55
        Me.Label37.Text = "MTD Transfers In"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(19, 572)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(134, 20)
        Me.Label38.TabIndex = 56
        Me.Label38.Text = "YTD Transfers In"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMTDSales
        '
        Me.txtMTDSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMTDSales.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMTDSales.Location = New System.Drawing.Point(159, 158)
        Me.txtMTDSales.Name = "txtMTDSales"
        Me.txtMTDSales.Size = New System.Drawing.Size(140, 20)
        Me.txtMTDSales.TabIndex = 37
        Me.txtMTDSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMTDShipments
        '
        Me.txtMTDShipments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMTDShipments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMTDShipments.Location = New System.Drawing.Point(159, 94)
        Me.txtMTDShipments.Name = "txtMTDShipments"
        Me.txtMTDShipments.Size = New System.Drawing.Size(140, 20)
        Me.txtMTDShipments.TabIndex = 35
        Me.txtMTDShipments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtYTDPurchases
        '
        Me.txtYTDPurchases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYTDPurchases.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtYTDPurchases.Location = New System.Drawing.Point(159, 314)
        Me.txtYTDPurchases.Name = "txtYTDPurchases"
        Me.txtYTDPurchases.Size = New System.Drawing.Size(140, 20)
        Me.txtYTDPurchases.TabIndex = 40
        Me.txtYTDPurchases.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtYTDSales
        '
        Me.txtYTDSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYTDSales.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtYTDSales.Location = New System.Drawing.Point(159, 190)
        Me.txtYTDSales.Name = "txtYTDSales"
        Me.txtYTDSales.Size = New System.Drawing.Size(140, 20)
        Me.txtYTDSales.TabIndex = 38
        Me.txtYTDSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMTDPurchases
        '
        Me.txtMTDPurchases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMTDPurchases.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMTDPurchases.Location = New System.Drawing.Point(159, 282)
        Me.txtMTDPurchases.Name = "txtMTDPurchases"
        Me.txtMTDPurchases.Size = New System.Drawing.Size(140, 20)
        Me.txtMTDPurchases.TabIndex = 39
        Me.txtMTDPurchases.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(19, 158)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(134, 20)
        Me.Label24.TabIndex = 41
        Me.Label24.Text = "MTD Orders Placed"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(19, 190)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(134, 20)
        Me.Label25.TabIndex = 42
        Me.Label25.Text = "YTD Orders Placed"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(19, 283)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(134, 20)
        Me.Label26.TabIndex = 43
        Me.Label26.Text = "MTD Purchases"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(19, 314)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(134, 20)
        Me.Label27.TabIndex = 44
        Me.Label27.Text = "YTD Purchases"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(19, 94)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(134, 20)
        Me.Label28.TabIndex = 45
        Me.Label28.Text = "MTD Shipments"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label49)
        Me.GroupBox1.Controls.Add(Me.txtTotalReceivables)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.Label32)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.Label41)
        Me.GroupBox1.Controls.Add(Me.txtARMore90)
        Me.GroupBox1.Controls.Add(Me.txtARPaymentsReceived)
        Me.GroupBox1.Controls.Add(Me.txtAR6190)
        Me.GroupBox1.Controls.Add(Me.txtAR4660)
        Me.GroupBox1.Controls.Add(Me.txtARLess30)
        Me.GroupBox1.Controls.Add(Me.txtAR3145)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Location = New System.Drawing.Point(369, 467)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(320, 245)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "AR Data (Aging is by today's date)"
        '
        'Label49
        '
        Me.Label49.Location = New System.Drawing.Point(19, 205)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(120, 20)
        Me.Label49.TabIndex = 65
        Me.Label49.Text = "Receivable Total"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalReceivables
        '
        Me.txtTotalReceivables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalReceivables.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalReceivables.Location = New System.Drawing.Point(157, 205)
        Me.txtTotalReceivables.Name = "txtTotalReceivables"
        Me.txtTotalReceivables.Size = New System.Drawing.Size(140, 20)
        Me.txtTotalReceivables.TabIndex = 32
        Me.txtTotalReceivables.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(19, 175)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(120, 20)
        Me.Label30.TabIndex = 63
        Me.Label30.Text = "Aging > 90"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(19, 55)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(120, 20)
        Me.Label31.TabIndex = 59
        Me.Label31.Text = "Aging < 30"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(19, 85)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(120, 20)
        Me.Label32.TabIndex = 60
        Me.Label32.Text = "Aging 31 - 45"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(19, 115)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(120, 20)
        Me.Label33.TabIndex = 61
        Me.Label33.Text = "Aging 46 - 60"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label41
        '
        Me.Label41.Location = New System.Drawing.Point(19, 145)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(120, 20)
        Me.Label41.TabIndex = 62
        Me.Label41.Text = "Aging 61 - 90"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtARMore90
        '
        Me.txtARMore90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtARMore90.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtARMore90.Location = New System.Drawing.Point(157, 175)
        Me.txtARMore90.Name = "txtARMore90"
        Me.txtARMore90.Size = New System.Drawing.Size(140, 20)
        Me.txtARMore90.TabIndex = 31
        Me.txtARMore90.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtARPaymentsReceived
        '
        Me.txtARPaymentsReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtARPaymentsReceived.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtARPaymentsReceived.Location = New System.Drawing.Point(157, 25)
        Me.txtARPaymentsReceived.Name = "txtARPaymentsReceived"
        Me.txtARPaymentsReceived.Size = New System.Drawing.Size(140, 20)
        Me.txtARPaymentsReceived.TabIndex = 26
        Me.txtARPaymentsReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAR6190
        '
        Me.txtAR6190.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAR6190.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAR6190.Location = New System.Drawing.Point(157, 145)
        Me.txtAR6190.Name = "txtAR6190"
        Me.txtAR6190.Size = New System.Drawing.Size(140, 20)
        Me.txtAR6190.TabIndex = 30
        Me.txtAR6190.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAR4660
        '
        Me.txtAR4660.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAR4660.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAR4660.Location = New System.Drawing.Point(157, 115)
        Me.txtAR4660.Name = "txtAR4660"
        Me.txtAR4660.Size = New System.Drawing.Size(140, 20)
        Me.txtAR4660.TabIndex = 29
        Me.txtAR4660.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtARLess30
        '
        Me.txtARLess30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtARLess30.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtARLess30.Location = New System.Drawing.Point(157, 55)
        Me.txtARLess30.Name = "txtARLess30"
        Me.txtARLess30.Size = New System.Drawing.Size(140, 20)
        Me.txtARLess30.TabIndex = 27
        Me.txtARLess30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAR3145
        '
        Me.txtAR3145.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAR3145.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAR3145.Location = New System.Drawing.Point(157, 85)
        Me.txtAR3145.Name = "txtAR3145"
        Me.txtAR3145.Size = New System.Drawing.Size(140, 20)
        Me.txtAR3145.TabIndex = 28
        Me.txtAR3145.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(19, 25)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(120, 20)
        Me.Label29.TabIndex = 41
        Me.Label29.Text = "Payments Received"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'DailyTotals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 773)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpxTotals)
        Me.Controls.Add(Me.gpxInventoryData)
        Me.Controls.Add(Me.gpxAPData)
        Me.Controls.Add(Me.gpxProductionData)
        Me.Controls.Add(Me.gpxPurchaseData)
        Me.Controls.Add(Me.gpxSalesData)
        Me.Controls.Add(Me.gpxCompanyData)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "DailyTotals"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Daily Totals"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxCompanyData.ResumeLayout(False)
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxSalesData.ResumeLayout(False)
        Me.gpxSalesData.PerformLayout()
        Me.gpxPurchaseData.ResumeLayout(False)
        Me.gpxPurchaseData.PerformLayout()
        Me.gpxProductionData.ResumeLayout(False)
        Me.gpxProductionData.PerformLayout()
        Me.gpxAPData.ResumeLayout(False)
        Me.gpxAPData.PerformLayout()
        Me.gpxInventoryData.ResumeLayout(False)
        Me.gpxInventoryData.PerformLayout()
        Me.gpxTotals.ResumeLayout(False)
        Me.gpxTotals.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxCompanyData As System.Windows.Forms.GroupBox
    Friend WithEvents dtpDateSelection As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSalesOrders As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtInventoryUnits As System.Windows.Forms.TextBox
    Friend WithEvents txtTransfersOut As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerReturns As System.Windows.Forms.TextBox
    Friend WithEvents txtInvoices As System.Windows.Forms.TextBox
    Friend WithEvents txtShipments As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents gpxSalesData As System.Windows.Forms.GroupBox
    Friend WithEvents gpxPurchaseData As System.Windows.Forms.GroupBox
    Friend WithEvents txtPurchaseOrders As System.Windows.Forms.TextBox
    Friend WithEvents txtTransfersIn As System.Windows.Forms.TextBox
    Friend WithEvents txtReceipts As System.Windows.Forms.TextBox
    Friend WithEvents txtVendorReturns As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtProductionUnits As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents gpxProductionData As System.Windows.Forms.GroupBox
    Friend WithEvents gpxAPData As System.Windows.Forms.GroupBox
    Friend WithEvents txtAPPaymentsMade As System.Windows.Forms.TextBox
    Friend WithEvents txtAP6190 As System.Windows.Forms.TextBox
    Friend WithEvents txtAP4660 As System.Windows.Forms.TextBox
    Friend WithEvents txtAPLess30 As System.Windows.Forms.TextBox
    Friend WithEvents txtAP3145 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents gpxInventoryData As System.Windows.Forms.GroupBox
    Friend WithEvents txtConsignmentInventory As System.Windows.Forms.TextBox
    Friend WithEvents txtInventoryQuantity As System.Windows.Forms.TextBox
    Friend WithEvents txtAverageCostInventory As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents gpxTotals As System.Windows.Forms.GroupBox
    Friend WithEvents txtMTDSales As System.Windows.Forms.TextBox
    Friend WithEvents txtMTDShipments As System.Windows.Forms.TextBox
    Friend WithEvents txtYTDPurchases As System.Windows.Forms.TextBox
    Friend WithEvents txtYTDSales As System.Windows.Forms.TextBox
    Friend WithEvents txtMTDPurchases As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents txtYTDTransfersOut As System.Windows.Forms.TextBox
    Friend WithEvents txtMTDTransfersOut As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtYTDShipments As System.Windows.Forms.TextBox
    Friend WithEvents txtYTDTransfersIn As System.Windows.Forms.TextBox
    Friend WithEvents txtMTDTransfersIn As System.Windows.Forms.TextBox
    Friend WithEvents txtMTDProduction As System.Windows.Forms.TextBox
    Friend WithEvents txtYTDProduction As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtAPMore90 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtARMore90 As System.Windows.Forms.TextBox
    Friend WithEvents txtARPaymentsReceived As System.Windows.Forms.TextBox
    Friend WithEvents txtAR6190 As System.Windows.Forms.TextBox
    Friend WithEvents txtAR4660 As System.Windows.Forms.TextBox
    Friend WithEvents txtARLess30 As System.Windows.Forms.TextBox
    Friend WithEvents txtAR3145 As System.Windows.Forms.TextBox
    Friend WithEvents txtYTDReceivers As System.Windows.Forms.TextBox
    Friend WithEvents txtMTDReceivers As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents txtYTDInvoices As System.Windows.Forms.TextBox
    Friend WithEvents txtMTDInvoices As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtValueByGL As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents txtRawMaterialTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtQuotes As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txtPayableTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents txtTotalReceivables As System.Windows.Forms.TextBox
    Friend WithEvents MonthSnapshotToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
