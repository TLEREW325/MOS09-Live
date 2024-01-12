<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewInvoiceListing
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewAllDataMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewLastThreeMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReprintInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintInvoiceListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintInvoiceGLPostingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintSalesByWeekToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintInvoiceDiscrepancyReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintInvoicePaymentReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintByReprintBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxInvoiceData = New System.Windows.Forms.GroupBox
        Me.cboPaymentTerms = New System.Windows.Forms.ComboBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.cboCustomerTerritory = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.cboCustomerClass = New System.Windows.Forms.ComboBox
        Me.CustomerClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label18 = New System.Windows.Forms.Label
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboShipmentNumber = New System.Windows.Forms.ComboBox
        Me.ShipmentHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.cboSONumber = New System.Windows.Forms.ComboBox
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmdInvoiceForm = New System.Windows.Forms.Button
        Me.cboInvoiceNumber = New System.Windows.Forms.ComboBox
        Me.InvoiceHeaderQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.cmdExit = New System.Windows.Forms.Button
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.cmdPrintGrid = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtTotalPosted = New System.Windows.Forms.TextBox
        Me.txtUniqueCustomers = New System.Windows.Forms.TextBox
        Me.txtTotalPending = New System.Windows.Forms.TextBox
        Me.txtTotalInvoiceAmount = New System.Windows.Forms.TextBox
        Me.txtTotalFreight = New System.Windows.Forms.TextBox
        Me.txtTotalTax = New System.Windows.Forms.TextBox
        Me.txtTotalProductSales = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.cmdEmailWithCerts = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdPrintMultiple = New System.Windows.Forms.Button
        Me.dgvInvoiceHeader = New System.Windows.Forms.DataGridView
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BilledFreightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentsAppliedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmailSentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTax2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTax3Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceCOSColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipViaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PostDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTermsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOBColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SpecialInstructionsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTAddress1Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTAddress2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTCityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTStateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTZipColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTCountryColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalDiscountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DropShipPONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalPaymentsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceAmountOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReprintBatchColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceHeaderQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderQueryTableAdapter
        Me.ShipmentHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
        Me.CustomerClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerClassTableAdapter
        Me.Label19 = New System.Windows.Forms.Label
        Me.cmdCloseInvoice = New System.Windows.Forms.Button
        Me.cmdOpenInvoice = New System.Windows.Forms.Button
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.cmdViewPickTicket = New System.Windows.Forms.Button
        Me.cmdAutoEmail = New System.Windows.Forms.Button
        Me.CRInvoiceViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXInvoiceTFP1 = New MOS09Program.CRXInvoiceTFP
        Me.CRXInvoice1 = New MOS09Program.CRXInvoice
        Me.CRXInvoiceTFF1 = New MOS09Program.CRXInvoiceTFF
        Me.cmdAppendPickTicket = New System.Windows.Forms.Button
        Me.cmdReuploadPickTicket = New System.Windows.Forms.Button
        Me.cmdRemoteScan = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.gpxInvoiceData.SuspendLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceHeaderQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgvInvoiceHeader, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewAllDataMenuItem, Me.ViewLastThreeMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ViewAllDataMenuItem
        '
        Me.ViewAllDataMenuItem.CheckOnClick = True
        Me.ViewAllDataMenuItem.Name = "ViewAllDataMenuItem"
        Me.ViewAllDataMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ViewAllDataMenuItem.Text = "View All Data"
        '
        'ViewLastThreeMenuItem
        '
        Me.ViewLastThreeMenuItem.Checked = True
        Me.ViewLastThreeMenuItem.CheckOnClick = True
        Me.ViewLastThreeMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ViewLastThreeMenuItem.Name = "ViewLastThreeMenuItem"
        Me.ViewLastThreeMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ViewLastThreeMenuItem.Text = "View Last 3 Years Data"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReprintInvoiceToolStripMenuItem, Me.PrintInvoiceListingToolStripMenuItem, Me.PrintInvoiceGLPostingsToolStripMenuItem, Me.PrintSalesByWeekToolStripMenuItem, Me.PrintInvoiceDiscrepancyReportToolStripMenuItem, Me.PrintInvoicePaymentReportToolStripMenuItem, Me.PrintByReprintBatchToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'ReprintInvoiceToolStripMenuItem
        '
        Me.ReprintInvoiceToolStripMenuItem.Name = "ReprintInvoiceToolStripMenuItem"
        Me.ReprintInvoiceToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.ReprintInvoiceToolStripMenuItem.Text = "Reprint Invoice"
        '
        'PrintInvoiceListingToolStripMenuItem
        '
        Me.PrintInvoiceListingToolStripMenuItem.Name = "PrintInvoiceListingToolStripMenuItem"
        Me.PrintInvoiceListingToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.PrintInvoiceListingToolStripMenuItem.Text = "Print Invoice Listing"
        '
        'PrintInvoiceGLPostingsToolStripMenuItem
        '
        Me.PrintInvoiceGLPostingsToolStripMenuItem.Name = "PrintInvoiceGLPostingsToolStripMenuItem"
        Me.PrintInvoiceGLPostingsToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.PrintInvoiceGLPostingsToolStripMenuItem.Text = "Print Invoice GL Postings"
        '
        'PrintSalesByWeekToolStripMenuItem
        '
        Me.PrintSalesByWeekToolStripMenuItem.Name = "PrintSalesByWeekToolStripMenuItem"
        Me.PrintSalesByWeekToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.PrintSalesByWeekToolStripMenuItem.Text = "Print Sales By Week"
        '
        'PrintInvoiceDiscrepancyReportToolStripMenuItem
        '
        Me.PrintInvoiceDiscrepancyReportToolStripMenuItem.Enabled = False
        Me.PrintInvoiceDiscrepancyReportToolStripMenuItem.Name = "PrintInvoiceDiscrepancyReportToolStripMenuItem"
        Me.PrintInvoiceDiscrepancyReportToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.PrintInvoiceDiscrepancyReportToolStripMenuItem.Text = "Print Invoice Discrepancy Report"
        '
        'PrintInvoicePaymentReportToolStripMenuItem
        '
        Me.PrintInvoicePaymentReportToolStripMenuItem.Enabled = False
        Me.PrintInvoicePaymentReportToolStripMenuItem.Name = "PrintInvoicePaymentReportToolStripMenuItem"
        Me.PrintInvoicePaymentReportToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.PrintInvoicePaymentReportToolStripMenuItem.Text = "Print Invoice Payment Report"
        '
        'PrintByReprintBatchToolStripMenuItem
        '
        Me.PrintByReprintBatchToolStripMenuItem.Enabled = False
        Me.PrintByReprintBatchToolStripMenuItem.Name = "PrintByReprintBatchToolStripMenuItem"
        Me.PrintByReprintBatchToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.PrintByReprintBatchToolStripMenuItem.Text = "Print By Reprint Batch #"
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
        'gpxInvoiceData
        '
        Me.gpxInvoiceData.Controls.Add(Me.cboPaymentTerms)
        Me.gpxInvoiceData.Controls.Add(Me.Label25)
        Me.gpxInvoiceData.Controls.Add(Me.cboCustomerTerritory)
        Me.gpxInvoiceData.Controls.Add(Me.Label24)
        Me.gpxInvoiceData.Controls.Add(Me.txtTextFilter)
        Me.gpxInvoiceData.Controls.Add(Me.Label23)
        Me.gpxInvoiceData.Controls.Add(Me.cboCustomerID)
        Me.gpxInvoiceData.Controls.Add(Me.cboCustomerClass)
        Me.gpxInvoiceData.Controls.Add(Me.Label18)
        Me.gpxInvoiceData.Controls.Add(Me.cboStatus)
        Me.gpxInvoiceData.Controls.Add(Me.Label17)
        Me.gpxInvoiceData.Controls.Add(Me.cboShipmentNumber)
        Me.gpxInvoiceData.Controls.Add(Me.Label16)
        Me.gpxInvoiceData.Controls.Add(Me.Label15)
        Me.gpxInvoiceData.Controls.Add(Me.chkDateRange)
        Me.gpxInvoiceData.Controls.Add(Me.cboSONumber)
        Me.gpxInvoiceData.Controls.Add(Me.Label2)
        Me.gpxInvoiceData.Controls.Add(Me.txtCustomerPO)
        Me.gpxInvoiceData.Controls.Add(Me.cboCustomerName)
        Me.gpxInvoiceData.Controls.Add(Me.Label8)
        Me.gpxInvoiceData.Controls.Add(Me.dtpEndDate)
        Me.gpxInvoiceData.Controls.Add(Me.cboDivisionID)
        Me.gpxInvoiceData.Controls.Add(Me.dtpBeginDate)
        Me.gpxInvoiceData.Controls.Add(Me.Label4)
        Me.gpxInvoiceData.Controls.Add(Me.Label3)
        Me.gpxInvoiceData.Controls.Add(Me.Label5)
        Me.gpxInvoiceData.Controls.Add(Me.cmdViewByFilters)
        Me.gpxInvoiceData.Controls.Add(Me.cmdClear)
        Me.gpxInvoiceData.Controls.Add(Me.Label1)
        Me.gpxInvoiceData.Controls.Add(Me.Label14)
        Me.gpxInvoiceData.Location = New System.Drawing.Point(29, 41)
        Me.gpxInvoiceData.Name = "gpxInvoiceData"
        Me.gpxInvoiceData.Size = New System.Drawing.Size(300, 584)
        Me.gpxInvoiceData.TabIndex = 0
        Me.gpxInvoiceData.TabStop = False
        Me.gpxInvoiceData.Text = "View By Filters"
        '
        'cboPaymentTerms
        '
        Me.cboPaymentTerms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPaymentTerms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentTerms.FormattingEnabled = True
        Me.cboPaymentTerms.Items.AddRange(New Object() {"COD", "CREDIT CARD", "NET DUE", "N30", "N45", "N60", "PREPAID"})
        Me.cboPaymentTerms.Location = New System.Drawing.Point(92, 390)
        Me.cboPaymentTerms.Name = "cboPaymentTerms"
        Me.cboPaymentTerms.Size = New System.Drawing.Size(195, 21)
        Me.cboPaymentTerms.TabIndex = 10
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(20, 390)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(103, 20)
        Me.Label25.TabIndex = 64
        Me.Label25.Text = "Pmt. Terms"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerTerritory
        '
        Me.cboCustomerTerritory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerTerritory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerTerritory.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerTerritory.DisplayMember = "SalesTerritory"
        Me.cboCustomerTerritory.FormattingEnabled = True
        Me.cboCustomerTerritory.Location = New System.Drawing.Point(92, 357)
        Me.cboCustomerTerritory.Name = "cboCustomerTerritory"
        Me.cboCustomerTerritory.Size = New System.Drawing.Size(195, 21)
        Me.cboCustomerTerritory.TabIndex = 9
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(19, 359)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(103, 20)
        Me.Label24.TabIndex = 62
        Me.Label24.Text = "Territory"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextFilter.Location = New System.Drawing.Point(92, 325)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(195, 20)
        Me.txtTextFilter.TabIndex = 8
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(19, 326)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(103, 20)
        Me.Label23.TabIndex = 60
        Me.Label23.Text = "Text Filter"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(92, 95)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(194, 21)
        Me.cboCustomerID.TabIndex = 1
        '
        'cboCustomerClass
        '
        Me.cboCustomerClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerClass.DataSource = Me.CustomerClassBindingSource
        Me.cboCustomerClass.DisplayMember = "CustomerClassID"
        Me.cboCustomerClass.FormattingEnabled = True
        Me.cboCustomerClass.Location = New System.Drawing.Point(92, 259)
        Me.cboCustomerClass.Name = "cboCustomerClass"
        Me.cboCustomerClass.Size = New System.Drawing.Size(195, 21)
        Me.cboCustomerClass.TabIndex = 6
        '
        'CustomerClassBindingSource
        '
        Me.CustomerClassBindingSource.DataMember = "CustomerClass"
        Me.CustomerClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(19, 261)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(103, 20)
        Me.Label18.TabIndex = 57
        Me.Label18.Text = "Cust. Class"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboStatus
        '
        Me.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OPEN", "CLOSED", "PENDING", "BILL ONLY"})
        Me.cboStatus.Location = New System.Drawing.Point(92, 292)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(195, 21)
        Me.cboStatus.TabIndex = 7
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(19, 294)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(103, 20)
        Me.Label17.TabIndex = 55
        Me.Label17.Text = "Inv. Status"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipmentNumber
        '
        Me.cboShipmentNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipmentNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipmentNumber.DataSource = Me.ShipmentHeaderTableBindingSource
        Me.cboShipmentNumber.DisplayMember = "ShipmentNumber"
        Me.cboShipmentNumber.FormattingEnabled = True
        Me.cboShipmentNumber.Location = New System.Drawing.Point(92, 194)
        Me.cboShipmentNumber.Name = "cboShipmentNumber"
        Me.cboShipmentNumber.Size = New System.Drawing.Size(195, 21)
        Me.cboShipmentNumber.TabIndex = 4
        '
        'ShipmentHeaderTableBindingSource
        '
        Me.ShipmentHeaderTableBindingSource.DataMember = "ShipmentHeaderTable"
        Me.ShipmentHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(19, 197)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(103, 20)
        Me.Label16.TabIndex = 53
        Me.Label16.Text = "Ship. #"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(19, 52)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(267, 40)
        Me.Label15.TabIndex = 52
        Me.Label15.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(91, 456)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 11
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'cboSONumber
        '
        Me.cboSONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSONumber.DataSource = Me.SalesOrderHeaderTableBindingSource
        Me.cboSONumber.DisplayMember = "SalesOrderKey"
        Me.cboSONumber.FormattingEnabled = True
        Me.cboSONumber.Location = New System.Drawing.Point(92, 161)
        Me.cboSONumber.Name = "cboSONumber"
        Me.cboSONumber.Size = New System.Drawing.Size(195, 21)
        Me.cboSONumber.TabIndex = 3
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 163)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "SO #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCustomerPO
        '
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerPO.Location = New System.Drawing.Point(92, 227)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(195, 20)
        Me.txtCustomerPO.TabIndex = 5
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(20, 128)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(266, 21)
        Me.cboCustomerName.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(19, 228)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 20)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Cust. PO"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(91, 513)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(194, 20)
        Me.dtpEndDate.TabIndex = 13
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(91, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(194, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(91, 483)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(194, 20)
        Me.dtpBeginDate.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(19, 483)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Begin Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Customer"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(19, 513)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "End Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(133, 544)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 14
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 544)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 15
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(16, 424)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(269, 30)
        Me.Label14.TabIndex = 51
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdInvoiceForm
        '
        Me.cmdInvoiceForm.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdInvoiceForm.Location = New System.Drawing.Point(137, 55)
        Me.cmdInvoiceForm.Name = "cmdInvoiceForm"
        Me.cmdInvoiceForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdInvoiceForm.TabIndex = 17
        Me.cmdInvoiceForm.Text = "Reprint Invoice"
        Me.cmdInvoiceForm.UseVisualStyleBackColor = True
        '
        'cboInvoiceNumber
        '
        Me.cboInvoiceNumber.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cboInvoiceNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInvoiceNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInvoiceNumber.DataSource = Me.InvoiceHeaderQueryBindingSource
        Me.cboInvoiceNumber.DisplayMember = "InvoiceNumber"
        Me.cboInvoiceNumber.FormattingEnabled = True
        Me.cboInvoiceNumber.Location = New System.Drawing.Point(91, 25)
        Me.cboInvoiceNumber.Name = "cboInvoiceNumber"
        Me.cboInvoiceNumber.Size = New System.Drawing.Size(194, 21)
        Me.cboInvoiceNumber.TabIndex = 16
        '
        'InvoiceHeaderQueryBindingSource
        '
        Me.InvoiceHeaderQueryBindingSource.DataMember = "InvoiceHeaderQuery"
        Me.InvoiceHeaderQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 774)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 24
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'cmdPrintGrid
        '
        Me.cmdPrintGrid.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintGrid.Location = New System.Drawing.Point(983, 774)
        Me.cmdPrintGrid.Name = "cmdPrintGrid"
        Me.cmdPrintGrid.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintGrid.TabIndex = 23
        Me.cmdPrintGrid.Text = "Print Listing"
        Me.cmdPrintGrid.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.txtTotalPosted)
        Me.GroupBox4.Controls.Add(Me.txtUniqueCustomers)
        Me.GroupBox4.Controls.Add(Me.txtTotalPending)
        Me.GroupBox4.Controls.Add(Me.txtTotalInvoiceAmount)
        Me.GroupBox4.Controls.Add(Me.txtTotalFreight)
        Me.GroupBox4.Controls.Add(Me.txtTotalTax)
        Me.GroupBox4.Controls.Add(Me.txtTotalProductSales)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Location = New System.Drawing.Point(344, 601)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(364, 213)
        Me.GroupBox4.TabIndex = 17
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Invoice Totals from Grid"
        '
        'txtTotalPosted
        '
        Me.txtTotalPosted.BackColor = System.Drawing.Color.White
        Me.txtTotalPosted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPosted.Location = New System.Drawing.Point(190, 104)
        Me.txtTotalPosted.Name = "txtTotalPosted"
        Me.txtTotalPosted.ReadOnly = True
        Me.txtTotalPosted.Size = New System.Drawing.Size(150, 20)
        Me.txtTotalPosted.TabIndex = 55
        Me.txtTotalPosted.TabStop = False
        Me.txtTotalPosted.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtUniqueCustomers
        '
        Me.txtUniqueCustomers.BackColor = System.Drawing.Color.White
        Me.txtUniqueCustomers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUniqueCustomers.Location = New System.Drawing.Point(230, 185)
        Me.txtUniqueCustomers.Name = "txtUniqueCustomers"
        Me.txtUniqueCustomers.ReadOnly = True
        Me.txtUniqueCustomers.Size = New System.Drawing.Size(110, 20)
        Me.txtUniqueCustomers.TabIndex = 32
        Me.txtUniqueCustomers.TabStop = False
        Me.txtUniqueCustomers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalPending
        '
        Me.txtTotalPending.BackColor = System.Drawing.Color.White
        Me.txtTotalPending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPending.Location = New System.Drawing.Point(190, 131)
        Me.txtTotalPending.Name = "txtTotalPending"
        Me.txtTotalPending.ReadOnly = True
        Me.txtTotalPending.Size = New System.Drawing.Size(150, 20)
        Me.txtTotalPending.TabIndex = 53
        Me.txtTotalPending.TabStop = False
        Me.txtTotalPending.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalInvoiceAmount
        '
        Me.txtTotalInvoiceAmount.BackColor = System.Drawing.Color.White
        Me.txtTotalInvoiceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalInvoiceAmount.Location = New System.Drawing.Point(190, 158)
        Me.txtTotalInvoiceAmount.Name = "txtTotalInvoiceAmount"
        Me.txtTotalInvoiceAmount.ReadOnly = True
        Me.txtTotalInvoiceAmount.Size = New System.Drawing.Size(150, 20)
        Me.txtTotalInvoiceAmount.TabIndex = 21
        Me.txtTotalInvoiceAmount.TabStop = False
        Me.txtTotalInvoiceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalFreight
        '
        Me.txtTotalFreight.BackColor = System.Drawing.Color.White
        Me.txtTotalFreight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalFreight.Location = New System.Drawing.Point(190, 77)
        Me.txtTotalFreight.Name = "txtTotalFreight"
        Me.txtTotalFreight.ReadOnly = True
        Me.txtTotalFreight.Size = New System.Drawing.Size(150, 20)
        Me.txtTotalFreight.TabIndex = 20
        Me.txtTotalFreight.TabStop = False
        Me.txtTotalFreight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalTax
        '
        Me.txtTotalTax.BackColor = System.Drawing.Color.White
        Me.txtTotalTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalTax.Location = New System.Drawing.Point(190, 50)
        Me.txtTotalTax.Name = "txtTotalTax"
        Me.txtTotalTax.ReadOnly = True
        Me.txtTotalTax.Size = New System.Drawing.Size(150, 20)
        Me.txtTotalTax.TabIndex = 19
        Me.txtTotalTax.TabStop = False
        Me.txtTotalTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalProductSales
        '
        Me.txtTotalProductSales.BackColor = System.Drawing.Color.White
        Me.txtTotalProductSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalProductSales.Location = New System.Drawing.Point(190, 23)
        Me.txtTotalProductSales.Name = "txtTotalProductSales"
        Me.txtTotalProductSales.ReadOnly = True
        Me.txtTotalProductSales.Size = New System.Drawing.Size(150, 20)
        Me.txtTotalProductSales.TabIndex = 18
        Me.txtTotalProductSales.TabStop = False
        Me.txtTotalProductSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(20, 156)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(186, 20)
        Me.Label22.TabIndex = 56
        Me.Label22.Text = "Total Invoice Amount"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(20, 183)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(198, 20)
        Me.Label20.TabIndex = 33
        Me.Label20.Text = "# of Unique Customers"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(20, 129)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(186, 20)
        Me.Label21.TabIndex = 54
        Me.Label21.Text = "Total Pending Invoices"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(20, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(186, 20)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Total Tax Collected"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(20, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(186, 20)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Total Freight Billed"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(20, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(186, 20)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Total Product Sales"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(20, 103)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(186, 20)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Total Posted Invoices"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(19, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(121, 37)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Reprint selected Invoice"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmdEmailWithCerts)
        Me.GroupBox5.Controls.Add(Me.cboInvoiceNumber)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.cmdInvoiceForm)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Location = New System.Drawing.Point(29, 628)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(300, 108)
        Me.GroupBox5.TabIndex = 16
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "View / Print by Invoice Number"
        '
        'cmdEmailWithCerts
        '
        Me.cmdEmailWithCerts.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdEmailWithCerts.Location = New System.Drawing.Point(214, 55)
        Me.cmdEmailWithCerts.Name = "cmdEmailWithCerts"
        Me.cmdEmailWithCerts.Size = New System.Drawing.Size(71, 40)
        Me.cmdEmailWithCerts.TabIndex = 18
        Me.cmdEmailWithCerts.Text = "Email w/Certs"
        Me.cmdEmailWithCerts.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label12.Location = New System.Drawing.Point(19, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 20)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Invoice #"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label13)
        Me.GroupBox6.Controls.Add(Me.cmdPrintMultiple)
        Me.GroupBox6.Location = New System.Drawing.Point(29, 739)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(300, 74)
        Me.GroupBox6.TabIndex = 18
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Print Multiple Invoices"
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(19, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(184, 42)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Select multiple invoices to reprint by clicking them in the grid and holding down" & _
            " the control key."
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintMultiple
        '
        Me.cmdPrintMultiple.Location = New System.Drawing.Point(214, 22)
        Me.cmdPrintMultiple.Name = "cmdPrintMultiple"
        Me.cmdPrintMultiple.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintMultiple.TabIndex = 18
        Me.cmdPrintMultiple.Text = "Print Invoices"
        Me.cmdPrintMultiple.UseVisualStyleBackColor = True
        '
        'dgvInvoiceHeader
        '
        Me.dgvInvoiceHeader.AllowUserToAddRows = False
        Me.dgvInvoiceHeader.AllowUserToDeleteRows = False
        Me.dgvInvoiceHeader.AllowUserToOrderColumns = True
        Me.dgvInvoiceHeader.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInvoiceHeader.AutoGenerateColumns = False
        Me.dgvInvoiceHeader.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInvoiceHeader.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInvoiceHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceHeader.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceNumberColumn, Me.InvoiceDateColumn, Me.SalesOrderNumberColumn, Me.ShipmentNumberColumn, Me.CustomerIDColumn, Me.CustomerPOColumn, Me.ProductTotalColumn, Me.BilledFreightColumn, Me.InvoiceTotalColumn, Me.PaymentsAppliedColumn, Me.EmailSentColumn, Me.SalesTaxColumn, Me.SalesTax2Column, Me.SalesTax3Column, Me.InvoiceCOSColumn, Me.PRONumberColumn, Me.InvoiceStatusColumn, Me.ShipViaColumn, Me.CustomerClassColumn, Me.UserIDColumn, Me.PostDateColumn, Me.PaymentTermsColumn, Me.FOBColumn, Me.CommentColumn, Me.SpecialInstructionsColumn, Me.BTAddress1Column, Me.BTAddress2Column, Me.BTCityColumn, Me.BTStateColumn, Me.BTZipColumn, Me.BTCountryColumn, Me.DiscountColumn, Me.TotalDiscountColumn, Me.DropShipPONumberColumn, Me.TotalPaymentsColumn, Me.InvoiceAmountOpenColumn, Me.CustomerNameColumn, Me.BatchNumberColumn, Me.ReprintBatchColumn, Me.DivisionIDColumn})
        Me.dgvInvoiceHeader.DataSource = Me.InvoiceHeaderQueryBindingSource
        Me.dgvInvoiceHeader.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvInvoiceHeader.Location = New System.Drawing.Point(344, 41)
        Me.dgvInvoiceHeader.Name = "dgvInvoiceHeader"
        Me.dgvInvoiceHeader.Size = New System.Drawing.Size(786, 554)
        Me.dgvInvoiceHeader.TabIndex = 25
        Me.dgvInvoiceHeader.TabStop = False
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
        'SalesOrderNumberColumn
        '
        Me.SalesOrderNumberColumn.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberColumn.HeaderText = "SO#"
        Me.SalesOrderNumberColumn.Name = "SalesOrderNumberColumn"
        Me.SalesOrderNumberColumn.ReadOnly = True
        Me.SalesOrderNumberColumn.Width = 85
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "Ship. #"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        Me.ShipmentNumberColumn.ReadOnly = True
        Me.ShipmentNumberColumn.Width = 85
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.HeaderText = "Cust. PO"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.ProductTotalColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.ProductTotalColumn.HeaderText = "Product Total"
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        Me.ProductTotalColumn.ReadOnly = True
        Me.ProductTotalColumn.Width = 90
        '
        'BilledFreightColumn
        '
        Me.BilledFreightColumn.DataPropertyName = "BilledFreight"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.BilledFreightColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.BilledFreightColumn.HeaderText = "Billed Freight"
        Me.BilledFreightColumn.Name = "BilledFreightColumn"
        Me.BilledFreightColumn.ReadOnly = True
        '
        'InvoiceTotalColumn
        '
        Me.InvoiceTotalColumn.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.InvoiceTotalColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.InvoiceTotalColumn.HeaderText = "Invoice Total"
        Me.InvoiceTotalColumn.Name = "InvoiceTotalColumn"
        Me.InvoiceTotalColumn.ReadOnly = True
        '
        'PaymentsAppliedColumn
        '
        Me.PaymentsAppliedColumn.DataPropertyName = "PaymentsApplied"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.PaymentsAppliedColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.PaymentsAppliedColumn.HeaderText = "Pmt. Applied"
        Me.PaymentsAppliedColumn.Name = "PaymentsAppliedColumn"
        Me.PaymentsAppliedColumn.ReadOnly = True
        '
        'EmailSentColumn
        '
        Me.EmailSentColumn.DataPropertyName = "EmailSent"
        Me.EmailSentColumn.HeaderText = "Email Sent?"
        Me.EmailSentColumn.Name = "EmailSentColumn"
        Me.EmailSentColumn.ReadOnly = True
        '
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.SalesTaxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.SalesTaxColumn.HeaderText = "Sales Tax 1"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        Me.SalesTaxColumn.ReadOnly = True
        Me.SalesTaxColumn.Width = 80
        '
        'SalesTax2Column
        '
        Me.SalesTax2Column.DataPropertyName = "SalesTax2"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.SalesTax2Column.DefaultCellStyle = DataGridViewCellStyle6
        Me.SalesTax2Column.HeaderText = "Sales Tax 2"
        Me.SalesTax2Column.Name = "SalesTax2Column"
        Me.SalesTax2Column.ReadOnly = True
        Me.SalesTax2Column.Width = 80
        '
        'SalesTax3Column
        '
        Me.SalesTax3Column.DataPropertyName = "SalesTax3"
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.SalesTax3Column.DefaultCellStyle = DataGridViewCellStyle7
        Me.SalesTax3Column.HeaderText = "Sales Tax 3"
        Me.SalesTax3Column.Name = "SalesTax3Column"
        Me.SalesTax3Column.ReadOnly = True
        Me.SalesTax3Column.Width = 80
        '
        'InvoiceCOSColumn
        '
        Me.InvoiceCOSColumn.DataPropertyName = "InvoiceCOS"
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = "0"
        Me.InvoiceCOSColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.InvoiceCOSColumn.HeaderText = "Invoice COS"
        Me.InvoiceCOSColumn.Name = "InvoiceCOSColumn"
        Me.InvoiceCOSColumn.ReadOnly = True
        '
        'PRONumberColumn
        '
        Me.PRONumberColumn.DataPropertyName = "PRONumber"
        Me.PRONumberColumn.HeaderText = "PRO #"
        Me.PRONumberColumn.Name = "PRONumberColumn"
        '
        'InvoiceStatusColumn
        '
        Me.InvoiceStatusColumn.DataPropertyName = "InvoiceStatus"
        Me.InvoiceStatusColumn.HeaderText = "Inv. Status"
        Me.InvoiceStatusColumn.Name = "InvoiceStatusColumn"
        Me.InvoiceStatusColumn.ReadOnly = True
        '
        'ShipViaColumn
        '
        Me.ShipViaColumn.DataPropertyName = "ShipVia"
        Me.ShipViaColumn.HeaderText = "Ship Via"
        Me.ShipViaColumn.Name = "ShipViaColumn"
        '
        'CustomerClassColumn
        '
        Me.CustomerClassColumn.DataPropertyName = "CustomerClass"
        Me.CustomerClassColumn.HeaderText = "Customer Class"
        Me.CustomerClassColumn.Name = "CustomerClassColumn"
        Me.CustomerClassColumn.ReadOnly = True
        '
        'UserIDColumn
        '
        Me.UserIDColumn.DataPropertyName = "UserID"
        Me.UserIDColumn.HeaderText = "Posted By?"
        Me.UserIDColumn.Name = "UserIDColumn"
        Me.UserIDColumn.ReadOnly = True
        '
        'PostDateColumn
        '
        Me.PostDateColumn.DataPropertyName = "PostDate"
        Me.PostDateColumn.HeaderText = "Date Posted"
        Me.PostDateColumn.Name = "PostDateColumn"
        Me.PostDateColumn.ReadOnly = True
        '
        'PaymentTermsColumn
        '
        Me.PaymentTermsColumn.DataPropertyName = "PaymentTerms"
        Me.PaymentTermsColumn.HeaderText = "Pmt. Terms"
        Me.PaymentTermsColumn.Name = "PaymentTermsColumn"
        '
        'FOBColumn
        '
        Me.FOBColumn.DataPropertyName = "FOB"
        Me.FOBColumn.HeaderText = "FOB"
        Me.FOBColumn.Name = "FOBColumn"
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'SpecialInstructionsColumn
        '
        Me.SpecialInstructionsColumn.DataPropertyName = "SpecialInstructions"
        Me.SpecialInstructionsColumn.HeaderText = "Instructions"
        Me.SpecialInstructionsColumn.Name = "SpecialInstructionsColumn"
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
        'DiscountColumn
        '
        Me.DiscountColumn.DataPropertyName = "Discount"
        Me.DiscountColumn.HeaderText = "Discount"
        Me.DiscountColumn.Name = "DiscountColumn"
        Me.DiscountColumn.Visible = False
        '
        'TotalDiscountColumn
        '
        Me.TotalDiscountColumn.DataPropertyName = "TotalDiscount"
        Me.TotalDiscountColumn.HeaderText = "TotalDiscount"
        Me.TotalDiscountColumn.Name = "TotalDiscountColumn"
        Me.TotalDiscountColumn.ReadOnly = True
        Me.TotalDiscountColumn.Visible = False
        '
        'DropShipPONumberColumn
        '
        Me.DropShipPONumberColumn.DataPropertyName = "DropShipPONumber"
        Me.DropShipPONumberColumn.HeaderText = "DropShipPONumber"
        Me.DropShipPONumberColumn.Name = "DropShipPONumberColumn"
        Me.DropShipPONumberColumn.Visible = False
        '
        'TotalPaymentsColumn
        '
        Me.TotalPaymentsColumn.DataPropertyName = "TotalPayments"
        Me.TotalPaymentsColumn.HeaderText = "TotalPayments"
        Me.TotalPaymentsColumn.Name = "TotalPaymentsColumn"
        Me.TotalPaymentsColumn.ReadOnly = True
        Me.TotalPaymentsColumn.Visible = False
        '
        'InvoiceAmountOpenColumn
        '
        Me.InvoiceAmountOpenColumn.DataPropertyName = "InvoiceAmountOpen"
        Me.InvoiceAmountOpenColumn.HeaderText = "InvoiceAmountOpen"
        Me.InvoiceAmountOpenColumn.Name = "InvoiceAmountOpenColumn"
        Me.InvoiceAmountOpenColumn.ReadOnly = True
        Me.InvoiceAmountOpenColumn.Visible = False
        '
        'CustomerNameColumn
        '
        Me.CustomerNameColumn.DataPropertyName = "CustomerName"
        Me.CustomerNameColumn.HeaderText = "CustomerName"
        Me.CustomerNameColumn.Name = "CustomerNameColumn"
        Me.CustomerNameColumn.Visible = False
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "BatchNumber"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.Visible = False
        '
        'ReprintBatchColumn
        '
        Me.ReprintBatchColumn.DataPropertyName = "ReprintBatch"
        Me.ReprintBatchColumn.HeaderText = "Reprint #"
        Me.ReprintBatchColumn.Name = "ReprintBatchColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'InvoiceHeaderQueryTableAdapter
        '
        Me.InvoiceHeaderQueryTableAdapter.ClearBeforeFill = True
        '
        'ShipmentHeaderTableTableAdapter
        '
        Me.ShipmentHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerClassTableAdapter
        '
        Me.CustomerClassTableAdapter.ClearBeforeFill = True
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(714, 621)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(227, 75)
        Me.Label19.TabIndex = 52
        Me.Label19.Text = "You may make changes to PRO#, Ship Via, Comments, Special Instructions, and Custo" & _
            "mer PO. Changes are saved automatically when typed in the grid."
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCloseInvoice
        '
        Me.cmdCloseInvoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCloseInvoice.ForeColor = System.Drawing.Color.Red
        Me.cmdCloseInvoice.Location = New System.Drawing.Point(1059, 631)
        Me.cmdCloseInvoice.Name = "cmdCloseInvoice"
        Me.cmdCloseInvoice.Size = New System.Drawing.Size(71, 40)
        Me.cmdCloseInvoice.TabIndex = 53
        Me.cmdCloseInvoice.Text = "Close Invoice"
        Me.cmdCloseInvoice.UseVisualStyleBackColor = True
        Me.cmdCloseInvoice.Visible = False
        '
        'cmdOpenInvoice
        '
        Me.cmdOpenInvoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenInvoice.ForeColor = System.Drawing.Color.Red
        Me.cmdOpenInvoice.Location = New System.Drawing.Point(982, 631)
        Me.cmdOpenInvoice.Name = "cmdOpenInvoice"
        Me.cmdOpenInvoice.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenInvoice.TabIndex = 54
        Me.cmdOpenInvoice.Text = "Open Invoice"
        Me.cmdOpenInvoice.UseVisualStyleBackColor = True
        Me.cmdOpenInvoice.Visible = False
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'cmdViewPickTicket
        '
        Me.cmdViewPickTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewPickTicket.ForeColor = System.Drawing.Color.Black
        Me.cmdViewPickTicket.Location = New System.Drawing.Point(1059, 728)
        Me.cmdViewPickTicket.Name = "cmdViewPickTicket"
        Me.cmdViewPickTicket.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewPickTicket.TabIndex = 55
        Me.cmdViewPickTicket.Text = "View Pick Ticket"
        Me.cmdViewPickTicket.UseVisualStyleBackColor = True
        '
        'cmdAutoEmail
        '
        Me.cmdAutoEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAutoEmail.Enabled = False
        Me.cmdAutoEmail.ForeColor = System.Drawing.Color.Black
        Me.cmdAutoEmail.Location = New System.Drawing.Point(907, 774)
        Me.cmdAutoEmail.Name = "cmdAutoEmail"
        Me.cmdAutoEmail.Size = New System.Drawing.Size(71, 40)
        Me.cmdAutoEmail.TabIndex = 56
        Me.cmdAutoEmail.Text = "Auto Email"
        Me.cmdAutoEmail.UseVisualStyleBackColor = True
        '
        'CRInvoiceViewer
        '
        Me.CRInvoiceViewer.ActiveViewIndex = 0
        Me.CRInvoiceViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRInvoiceViewer.Location = New System.Drawing.Point(601, 373)
        Me.CRInvoiceViewer.Name = "CRInvoiceViewer"
        Me.CRInvoiceViewer.ReportSource = Me.CRXInvoiceTFP1
        Me.CRInvoiceViewer.Size = New System.Drawing.Size(141, 78)
        Me.CRInvoiceViewer.TabIndex = 57
        Me.CRInvoiceViewer.Visible = False
        '
        'cmdAppendPickTicket
        '
        Me.cmdAppendPickTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAppendPickTicket.ForeColor = System.Drawing.Color.Black
        Me.cmdAppendPickTicket.Location = New System.Drawing.Point(983, 728)
        Me.cmdAppendPickTicket.Name = "cmdAppendPickTicket"
        Me.cmdAppendPickTicket.Size = New System.Drawing.Size(71, 40)
        Me.cmdAppendPickTicket.TabIndex = 58
        Me.cmdAppendPickTicket.Text = "Append Pick Ticket"
        Me.cmdAppendPickTicket.UseVisualStyleBackColor = True
        '
        'cmdReuploadPickTicket
        '
        Me.cmdReuploadPickTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReuploadPickTicket.ForeColor = System.Drawing.Color.Black
        Me.cmdReuploadPickTicket.Location = New System.Drawing.Point(906, 730)
        Me.cmdReuploadPickTicket.Name = "cmdReuploadPickTicket"
        Me.cmdReuploadPickTicket.Size = New System.Drawing.Size(71, 40)
        Me.cmdReuploadPickTicket.TabIndex = 59
        Me.cmdReuploadPickTicket.Text = "Reupload Pick Ticket"
        Me.cmdReuploadPickTicket.UseVisualStyleBackColor = True
        '
        'cmdRemoteScan
        '
        Me.cmdRemoteScan.Location = New System.Drawing.Point(983, 728)
        Me.cmdRemoteScan.Name = "cmdRemoteScan"
        Me.cmdRemoteScan.Size = New System.Drawing.Size(71, 40)
        Me.cmdRemoteScan.TabIndex = 60
        Me.cmdRemoteScan.Text = "Upload Pick Ticket"
        Me.cmdRemoteScan.UseVisualStyleBackColor = True
        '
        'ViewInvoiceListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdRemoteScan)
        Me.Controls.Add(Me.cmdReuploadPickTicket)
        Me.Controls.Add(Me.cmdAppendPickTicket)
        Me.Controls.Add(Me.cmdAutoEmail)
        Me.Controls.Add(Me.cmdViewPickTicket)
        Me.Controls.Add(Me.cmdOpenInvoice)
        Me.Controls.Add(Me.cmdCloseInvoice)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.dgvInvoiceHeader)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.cmdPrintGrid)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxInvoiceData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.CRInvoiceViewer)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewInvoiceListing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Invoice Listing"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxInvoiceData.ResumeLayout(False)
        Me.gpxInvoiceData.PerformLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceHeaderQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dgvInvoiceHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxInvoiceData As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSONumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdInvoiceForm As System.Windows.Forms.Button
    Friend WithEvents cboInvoiceNumber As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintGrid As System.Windows.Forms.Button
    Friend WithEvents ReprintInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintInvoiceListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents PrintInvoiceGLPostingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintSalesByWeekToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtTotalProductSales As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotalInvoiceAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalFreight As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalTax As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPrintMultiple As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dgvInvoiceHeader As System.Windows.Forms.DataGridView
    Friend WithEvents InvoiceHeaderQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceHeaderQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderQueryTableAdapter
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboShipmentNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ShipmentHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
    Friend WithEvents CustomerClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerClassTableAdapter
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdEmailWithCerts As System.Windows.Forms.Button
    Friend WithEvents txtUniqueCustomers As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPosted As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPending As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents PrintInvoiceDiscrepancyReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintInvoicePaymentReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdCloseInvoice As System.Windows.Forms.Button
    Friend WithEvents cmdOpenInvoice As System.Windows.Forms.Button
    Friend WithEvents cboCustomerTerritory As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents cmdViewPickTicket As System.Windows.Forms.Button
    Friend WithEvents cmdAutoEmail As System.Windows.Forms.Button
    Friend WithEvents CRInvoiceViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXInvoice1 As MOS09Program.CRXInvoice
    Friend WithEvents CRXInvoiceTFP1 As MOS09Program.CRXInvoiceTFP
    Friend WithEvents CRXInvoiceTFF1 As MOS09Program.CRXInvoiceTFF
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents PrintByReprintBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewAllDataMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewLastThreeMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdAppendPickTicket As System.Windows.Forms.Button
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BilledFreightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentsAppliedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmailSentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTax2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTax3Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceCOSColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipViaColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PostDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTermsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOBColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecialInstructionsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTAddress1Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTAddress2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTCityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTStateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTZipColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTCountryColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalDiscountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DropShipPONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalPaymentsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceAmountOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReprintBatchColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdReuploadPickTicket As System.Windows.Forms.Button
    Friend WithEvents cmdRemoteScan As System.Windows.Forms.Button
    Friend WithEvents cboPaymentTerms As System.Windows.Forms.ComboBox
End Class
