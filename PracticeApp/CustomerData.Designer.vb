<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerData
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveCustomerDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteCustomerDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintCustomerDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearCustomerDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomerAccountDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomerOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomerNotesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomerOrderHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomerAccountDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AgedReceivablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomerSalesAnalysisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomerStatementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BackorderReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomerHoldReportAutoprintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.grpCustomerInfo = New System.Windows.Forms.GroupBox
        Me.dtpCustomerSince = New System.Windows.Forms.DateTimePicker
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtOldCustomerNumber = New System.Windows.Forms.TextBox
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboCustomerClass = New System.Windows.Forms.ComboBox
        Me.CustomerClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtCustomerComment = New System.Windows.Forms.TextBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.txtCreditLimit = New System.Windows.Forms.TextBox
        Me.txtSalesTaxRate = New System.Windows.Forms.TextBox
        Me.LabelTax1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboPaymentTerms = New System.Windows.Forms.ComboBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.cmdClearBilling = New System.Windows.Forms.Button
        Me.cboBTState = New System.Windows.Forms.ComboBox
        Me.StateTableBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtBTAddress1 = New System.Windows.Forms.TextBox
        Me.txtBTCountry = New System.Windows.Forms.TextBox
        Me.txtBTZip = New System.Windows.Forms.TextBox
        Me.txtBTCity = New System.Windows.Forms.TextBox
        Me.txtBTAddress2 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.gpxCreditBilling = New System.Windows.Forms.GroupBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.lblCreditLT45 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.lblCreditLimit = New System.Windows.Forms.Label
        Me.lblCreditMT90 = New System.Windows.Forms.Label
        Me.lblCreditLT90 = New System.Windows.Forms.Label
        Me.lblCreditLT60 = New System.Windows.Forms.Label
        Me.lblCreditLT30 = New System.Windows.Forms.Label
        Me.lblCreditBalance = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.chkCreditHold = New System.Windows.Forms.CheckBox
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.gpxCustomerSnapshot = New System.Windows.Forms.GroupBox
        Me.lblAVGDaysToPay = New System.Windows.Forms.Label
        Me.Label61 = New System.Windows.Forms.Label
        Me.lblLastActivityDate = New System.Windows.Forms.Label
        Me.lblAverageOrder = New System.Windows.Forms.Label
        Me.lblYTDSales = New System.Windows.Forms.Label
        Me.lblMTDSales = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.cmdOpenOrders = New System.Windows.Forms.Button
        Me.cmdSalesHistory = New System.Windows.Forms.Button
        Me.cmdCopyToShippingAddress = New System.Windows.Forms.Button
        Me.Label22 = New System.Windows.Forms.Label
        Me.cmdCustomerStatement = New System.Windows.Forms.Button
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtShippingInstructions = New System.Windows.Forms.TextBox
        Me.Label49 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.cboShipper = New System.Windows.Forms.ComboBox
        Me.ShipMethodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tcAddress = New System.Windows.Forms.TabControl
        Me.BillingAddress = New System.Windows.Forms.TabPage
        Me.cboCountryList = New System.Windows.Forms.ComboBox
        Me.CountryCodesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label67 = New System.Windows.Forms.Label
        Me.Label62 = New System.Windows.Forms.Label
        Me.ShippingAddress = New System.Windows.Forms.TabPage
        Me.CRReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXMonthEndCustomerReport1 = New MOS09Program.CRXMonthEndCustomerReport
        Me.Label68 = New System.Windows.Forms.Label
        Me.cboShipToCountry = New System.Windows.Forms.ComboBox
        Me.Label55 = New System.Windows.Forms.Label
        Me.cmdPrintLabel = New System.Windows.Forms.Button
        Me.cmdClearDefaultShipping = New System.Windows.Forms.Button
        Me.txtSTAddress1 = New System.Windows.Forms.TextBox
        Me.txtSTAddress2 = New System.Windows.Forms.TextBox
        Me.txtSTCity = New System.Windows.Forms.TextBox
        Me.cboSTState = New System.Windows.Forms.ComboBox
        Me.StateTableBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtSTZip = New System.Windows.Forms.TextBox
        Me.txtSTCountry = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.AddShipTo = New System.Windows.Forms.TabPage
        Me.Label69 = New System.Windows.Forms.Label
        Me.cboAddShipToCountry = New System.Windows.Forms.ComboBox
        Me.cmdDeleteAddShipTo = New System.Windows.Forms.Button
        Me.txtAddShipToName = New System.Windows.Forms.TextBox
        Me.cmdSaveAdditionalShipTo = New System.Windows.Forms.Button
        Me.cmdClearAdditionalShipTo = New System.Windows.Forms.Button
        Me.cboShipToID = New System.Windows.Forms.ComboBox
        Me.AdditionalShipToBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtAddCountry = New System.Windows.Forms.TextBox
        Me.txtAddZip = New System.Windows.Forms.TextBox
        Me.txtAddCity = New System.Windows.Forms.TextBox
        Me.txtAddAddress2 = New System.Windows.Forms.TextBox
        Me.txtAddAddress1 = New System.Windows.Forms.TextBox
        Me.cboAddState = New System.Windows.Forms.ComboBox
        Me.StateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label50 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.CustomerContactsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ShipMethodTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
        Me.CustomerContactsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerContactsTableAdapter
        Me.AdditionalShipToTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AdditionalShipToTableAdapter
        Me.StateTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
        Me.CustomerClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerClassTableAdapter
        Me.tabMainContact = New System.Windows.Forms.TabPage
        Me.Label79 = New System.Windows.Forms.Label
        Me.Label82 = New System.Windows.Forms.Label
        Me.txtShipEmail = New System.Windows.Forms.TextBox
        Me.Label54 = New System.Windows.Forms.Label
        Me.txtSalesContactEmail = New System.Windows.Forms.TextBox
        Me.txtAPContactName = New System.Windows.Forms.TextBox
        Me.txtAPPhoneNumber = New System.Windows.Forms.TextBox
        Me.txtAPFaxNumber = New System.Windows.Forms.TextBox
        Me.Label58 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.txtAPEmailAddress = New System.Windows.Forms.TextBox
        Me.Label53 = New System.Windows.Forms.Label
        Me.tabAdditionalContacts = New System.Windows.Forms.TabPage
        Me.Label65 = New System.Windows.Forms.Label
        Me.lblContactDepartment = New System.Windows.Forms.Label
        Me.cmdDeleteContact = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmdAddContact = New System.Windows.Forms.Button
        Me.Label24 = New System.Windows.Forms.Label
        Me.cmdClearContact = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboContactDepartment = New System.Windows.Forms.ComboBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.txtContactPhone = New System.Windows.Forms.TextBox
        Me.txtContactEmail = New System.Windows.Forms.TextBox
        Me.txtContactName = New System.Windows.Forms.TextBox
        Me.txtContactFax = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tabContactTabControl = New System.Windows.Forms.TabControl
        Me.tabContactListing = New System.Windows.Forms.TabPage
        Me.Label72 = New System.Windows.Forms.Label
        Me.cmdCCDelete = New System.Windows.Forms.Button
        Me.dgvCustomerContacts = New System.Windows.Forms.DataGridView
        Me.ContactDepartmentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContactNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContactPhoneColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContactFaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContactEmailColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tabEmailContacts = New System.Windows.Forms.TabPage
        Me.Label56 = New System.Windows.Forms.Label
        Me.txtInvoiceCertEmail = New System.Windows.Forms.TextBox
        Me.Label57 = New System.Windows.Forms.Label
        Me.txtInvoiceEmail = New System.Windows.Forms.TextBox
        Me.Label77 = New System.Windows.Forms.Label
        Me.txtEmailPackingLists = New System.Windows.Forms.TextBox
        Me.Label76 = New System.Windows.Forms.Label
        Me.Label75 = New System.Windows.Forms.Label
        Me.txtEmailStatements = New System.Windows.Forms.TextBox
        Me.Label74 = New System.Windows.Forms.Label
        Me.txtEmailCerts = New System.Windows.Forms.TextBox
        Me.Label73 = New System.Windows.Forms.Label
        Me.txtEmailConfirmations = New System.Windows.Forms.TextBox
        Me.tabMiscCustomerData = New System.Windows.Forms.TabControl
        Me.tabMiscData = New System.Windows.Forms.TabPage
        Me.Label70 = New System.Windows.Forms.Label
        Me.txtShippingAccount = New System.Windows.Forms.TextBox
        Me.Label66 = New System.Windows.Forms.Label
        Me.txtSalesTerritory = New System.Windows.Forms.TextBox
        Me.cboSalesTerritory = New System.Windows.Forms.ComboBox
        Me.SalesTerritoryQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.chkAccountingHold = New System.Windows.Forms.CheckBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label81 = New System.Windows.Forms.Label
        Me.tabTaxData = New System.Windows.Forms.TabPage
        Me.lblTaxExempt = New System.Windows.Forms.Label
        Me.cmdViewTaxExemptForm = New System.Windows.Forms.Button
        Me.cboSalesTaxStatus = New System.Windows.Forms.ComboBox
        Me.Label80 = New System.Windows.Forms.Label
        Me.chkAddHST = New System.Windows.Forms.CheckBox
        Me.chkAddPST = New System.Windows.Forms.CheckBox
        Me.chkAddGST = New System.Windows.Forms.CheckBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.LabelTax4 = New System.Windows.Forms.Label
        Me.LabelTax2 = New System.Windows.Forms.Label
        Me.txtSalesTaxRate2 = New System.Windows.Forms.TextBox
        Me.LabelTax3 = New System.Windows.Forms.Label
        Me.txtSalesTaxRate3 = New System.Windows.Forms.TextBox
        Me.Label59 = New System.Windows.Forms.Label
        Me.txtTaxID = New System.Windows.Forms.TextBox
        Me.tabPricing = New System.Windows.Forms.TabPage
        Me.cboBankAccount = New System.Windows.Forms.ComboBox
        Me.Label71 = New System.Windows.Forms.Label
        Me.Label64 = New System.Windows.Forms.Label
        Me.cboBillingType = New System.Windows.Forms.ComboBox
        Me.Label63 = New System.Windows.Forms.Label
        Me.Label60 = New System.Windows.Forms.Label
        Me.txtPricingReview = New System.Windows.Forms.TextBox
        Me.cmdViewSalesTotals = New System.Windows.Forms.Button
        Me.SalesTerritoryQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesTerritoryQueryTableAdapter
        Me.cmdViewFoxes = New System.Windows.Forms.Button
        Me.CountryCodesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CountryCodesTableAdapter
        Me.cmdCreditApp = New System.Windows.Forms.Button
        Me.lblHoldBanner = New System.Windows.Forms.Label
        Me.cmdCustomerPriceSheet = New System.Windows.Forms.Button
        Me.cmdUploadPriceSheet = New System.Windows.Forms.Button
        Me.ofdPriceSheet = New System.Windows.Forms.OpenFileDialog
        Me.cmdCustomerCreditForm = New System.Windows.Forms.Button
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.grpCustomerInfo.SuspendLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StateTableBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxCreditBilling.SuspendLayout()
        Me.gpxCustomerSnapshot.SuspendLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcAddress.SuspendLayout()
        Me.BillingAddress.SuspendLayout()
        CType(Me.CountryCodesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ShippingAddress.SuspendLayout()
        CType(Me.StateTableBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AddShipTo.SuspendLayout()
        CType(Me.AdditionalShipToBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerContactsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMainContact.SuspendLayout()
        Me.tabAdditionalContacts.SuspendLayout()
        Me.tabContactTabControl.SuspendLayout()
        Me.tabContactListing.SuspendLayout()
        CType(Me.dgvCustomerContacts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEmailContacts.SuspendLayout()
        Me.tabMiscCustomerData.SuspendLayout()
        Me.tabMiscData.SuspendLayout()
        CType(Me.SalesTerritoryQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTaxData.SuspendLayout()
        Me.tabPricing.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1061, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 64
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Customer ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 23
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveCustomerDataToolStripMenuItem, Me.DeleteCustomerDataToolStripMenuItem, Me.PrintCustomerDataToolStripMenuItem, Me.ClearCustomerDataToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveCustomerDataToolStripMenuItem
        '
        Me.SaveCustomerDataToolStripMenuItem.Name = "SaveCustomerDataToolStripMenuItem"
        Me.SaveCustomerDataToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SaveCustomerDataToolStripMenuItem.Text = "Save Customer Data"
        '
        'DeleteCustomerDataToolStripMenuItem
        '
        Me.DeleteCustomerDataToolStripMenuItem.Name = "DeleteCustomerDataToolStripMenuItem"
        Me.DeleteCustomerDataToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DeleteCustomerDataToolStripMenuItem.Text = "Delete Customer Data"
        '
        'PrintCustomerDataToolStripMenuItem
        '
        Me.PrintCustomerDataToolStripMenuItem.Name = "PrintCustomerDataToolStripMenuItem"
        Me.PrintCustomerDataToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PrintCustomerDataToolStripMenuItem.Text = "Print Customer Data"
        '
        'ClearCustomerDataToolStripMenuItem
        '
        Me.ClearCustomerDataToolStripMenuItem.Name = "ClearCustomerDataToolStripMenuItem"
        Me.ClearCustomerDataToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ClearCustomerDataToolStripMenuItem.Text = "Clear Customer Data"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomerAccountDataToolStripMenuItem, Me.CustomerOrdersToolStripMenuItem, Me.CustomerNotesToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'CustomerAccountDataToolStripMenuItem
        '
        Me.CustomerAccountDataToolStripMenuItem.Name = "CustomerAccountDataToolStripMenuItem"
        Me.CustomerAccountDataToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.CustomerAccountDataToolStripMenuItem.Text = "Customer Account Data"
        '
        'CustomerOrdersToolStripMenuItem
        '
        Me.CustomerOrdersToolStripMenuItem.Name = "CustomerOrdersToolStripMenuItem"
        Me.CustomerOrdersToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.CustomerOrdersToolStripMenuItem.Text = "Customer Orders"
        '
        'CustomerNotesToolStripMenuItem
        '
        Me.CustomerNotesToolStripMenuItem.Name = "CustomerNotesToolStripMenuItem"
        Me.CustomerNotesToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.CustomerNotesToolStripMenuItem.Text = "Customer Notes"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomerOrderHistoryToolStripMenuItem, Me.CustomerAccountDetailsToolStripMenuItem, Me.AgedReceivablesToolStripMenuItem, Me.CustomerSalesAnalysisToolStripMenuItem, Me.CustomerStatementToolStripMenuItem, Me.BackorderReportToolStripMenuItem, Me.CustomerHoldReportAutoprintToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'CustomerOrderHistoryToolStripMenuItem
        '
        Me.CustomerOrderHistoryToolStripMenuItem.Name = "CustomerOrderHistoryToolStripMenuItem"
        Me.CustomerOrderHistoryToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.CustomerOrderHistoryToolStripMenuItem.Text = "Customer Sales History"
        '
        'CustomerAccountDetailsToolStripMenuItem
        '
        Me.CustomerAccountDetailsToolStripMenuItem.Name = "CustomerAccountDetailsToolStripMenuItem"
        Me.CustomerAccountDetailsToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.CustomerAccountDetailsToolStripMenuItem.Text = "Customer MTD/YTD Totals"
        '
        'AgedReceivablesToolStripMenuItem
        '
        Me.AgedReceivablesToolStripMenuItem.Name = "AgedReceivablesToolStripMenuItem"
        Me.AgedReceivablesToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.AgedReceivablesToolStripMenuItem.Text = "Aged Receivables"
        '
        'CustomerSalesAnalysisToolStripMenuItem
        '
        Me.CustomerSalesAnalysisToolStripMenuItem.Name = "CustomerSalesAnalysisToolStripMenuItem"
        Me.CustomerSalesAnalysisToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.CustomerSalesAnalysisToolStripMenuItem.Text = "Customer Sales Analysis"
        '
        'CustomerStatementToolStripMenuItem
        '
        Me.CustomerStatementToolStripMenuItem.Name = "CustomerStatementToolStripMenuItem"
        Me.CustomerStatementToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.CustomerStatementToolStripMenuItem.Text = "Customer Statement"
        '
        'BackorderReportToolStripMenuItem
        '
        Me.BackorderReportToolStripMenuItem.Name = "BackorderReportToolStripMenuItem"
        Me.BackorderReportToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.BackorderReportToolStripMenuItem.Text = "Backorder Report"
        '
        'CustomerHoldReportAutoprintToolStripMenuItem
        '
        Me.CustomerHoldReportAutoprintToolStripMenuItem.Enabled = False
        Me.CustomerHoldReportAutoprintToolStripMenuItem.Name = "CustomerHoldReportAutoprintToolStripMenuItem"
        Me.CustomerHoldReportAutoprintToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.CustomerHoldReportAutoprintToolStripMenuItem.Text = "Customer Hold Report (Autoprint)"
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
        'grpCustomerInfo
        '
        Me.grpCustomerInfo.Controls.Add(Me.dtpCustomerSince)
        Me.grpCustomerInfo.Controls.Add(Me.cboCustomerName)
        Me.grpCustomerInfo.Controls.Add(Me.txtOldCustomerNumber)
        Me.grpCustomerInfo.Controls.Add(Me.cboCustomerID)
        Me.grpCustomerInfo.Controls.Add(Me.cboDivisionID)
        Me.grpCustomerInfo.Controls.Add(Me.Label48)
        Me.grpCustomerInfo.Controls.Add(Me.Label3)
        Me.grpCustomerInfo.Controls.Add(Me.cboCustomerClass)
        Me.grpCustomerInfo.Controls.Add(Me.Label35)
        Me.grpCustomerInfo.Controls.Add(Me.Label25)
        Me.grpCustomerInfo.Controls.Add(Me.txtCustomerComment)
        Me.grpCustomerInfo.Controls.Add(Me.Label1)
        Me.grpCustomerInfo.Controls.Add(Me.Label42)
        Me.grpCustomerInfo.Location = New System.Drawing.Point(29, 41)
        Me.grpCustomerInfo.Name = "grpCustomerInfo"
        Me.grpCustomerInfo.Size = New System.Drawing.Size(333, 334)
        Me.grpCustomerInfo.TabIndex = 0
        Me.grpCustomerInfo.TabStop = False
        Me.grpCustomerInfo.Text = "Customer Information"
        '
        'dtpCustomerSince
        '
        Me.dtpCustomerSince.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCustomerSince.Location = New System.Drawing.Point(129, 152)
        Me.dtpCustomerSince.Name = "dtpCustomerSince"
        Me.dtpCustomerSince.Size = New System.Drawing.Size(190, 20)
        Me.dtpCustomerSince.TabIndex = 48
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.DropDownWidth = 400
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(19, 56)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(300, 21)
        Me.cboCustomerName.TabIndex = 1
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtOldCustomerNumber
        '
        Me.txtOldCustomerNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOldCustomerNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOldCustomerNumber.Location = New System.Drawing.Point(129, 183)
        Me.txtOldCustomerNumber.Name = "txtOldCustomerNumber"
        Me.txtOldCustomerNumber.Size = New System.Drawing.Size(190, 20)
        Me.txtOldCustomerNumber.TabIndex = 5
        Me.txtOldCustomerNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.DropDownWidth = 300
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(85, 24)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(234, 21)
        Me.cboCustomerID.TabIndex = 0
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(129, 88)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(190, 21)
        Me.cboDivisionID.TabIndex = 2
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label48
        '
        Me.Label48.Location = New System.Drawing.Point(19, 121)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(104, 20)
        Me.Label48.TabIndex = 47
        Me.Label48.Text = "Customer Class"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(19, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 20)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Division ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerClass
        '
        Me.cboCustomerClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerClass.DataSource = Me.CustomerClassBindingSource
        Me.cboCustomerClass.DisplayMember = "CustomerClassID"
        Me.cboCustomerClass.FormattingEnabled = True
        Me.cboCustomerClass.Location = New System.Drawing.Point(129, 120)
        Me.cboCustomerClass.Name = "cboCustomerClass"
        Me.cboCustomerClass.Size = New System.Drawing.Size(190, 21)
        Me.cboCustomerClass.TabIndex = 3
        '
        'CustomerClassBindingSource
        '
        Me.CustomerClassBindingSource.DataMember = "CustomerClass"
        Me.CustomerClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(19, 152)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(104, 20)
        Me.Label35.TabIndex = 29
        Me.Label35.Text = "Customer Since??"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(19, 212)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(104, 20)
        Me.Label25.TabIndex = 26
        Me.Label25.Text = "Comments"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCustomerComment
        '
        Me.txtCustomerComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerComment.Location = New System.Drawing.Point(10, 235)
        Me.txtCustomerComment.Multiline = True
        Me.txtCustomerComment.Name = "txtCustomerComment"
        Me.txtCustomerComment.Size = New System.Drawing.Size(312, 93)
        Me.txtCustomerComment.TabIndex = 6
        Me.txtCustomerComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(19, 183)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(104, 20)
        Me.Label42.TabIndex = 38
        Me.Label42.Text = "Old Customer #"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCreditLimit
        '
        Me.txtCreditLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreditLimit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCreditLimit.Location = New System.Drawing.Point(168, 67)
        Me.txtCreditLimit.Name = "txtCreditLimit"
        Me.txtCreditLimit.Size = New System.Drawing.Size(147, 20)
        Me.txtCreditLimit.TabIndex = 9
        Me.txtCreditLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSalesTaxRate
        '
        Me.txtSalesTaxRate.BackColor = System.Drawing.Color.White
        Me.txtSalesTaxRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTaxRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesTaxRate.Location = New System.Drawing.Point(212, 44)
        Me.txtSalesTaxRate.Name = "txtSalesTaxRate"
        Me.txtSalesTaxRate.Size = New System.Drawing.Size(99, 20)
        Me.txtSalesTaxRate.TabIndex = 13
        Me.txtSalesTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelTax1
        '
        Me.LabelTax1.Location = New System.Drawing.Point(17, 44)
        Me.LabelTax1.Name = "LabelTax1"
        Me.LabelTax1.Size = New System.Drawing.Size(144, 20)
        Me.LabelTax1.TabIndex = 42
        Me.LabelTax1.Text = "Sales Tax Rate / GST"
        Me.LabelTax1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 20)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Credit Limit"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClear.Location = New System.Drawing.Point(377, 771)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 57
        Me.cmdClear.Text = "Clear All"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cboPaymentTerms
        '
        Me.cboPaymentTerms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPaymentTerms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentTerms.FormattingEnabled = True
        Me.cboPaymentTerms.Items.AddRange(New Object() {"N30", "COD", "CREDIT CARD", "Prepaid", "NetDue"})
        Me.cboPaymentTerms.Location = New System.Drawing.Point(114, 100)
        Me.cboPaymentTerms.MaxLength = 50
        Me.cboPaymentTerms.Name = "cboPaymentTerms"
        Me.cboPaymentTerms.Size = New System.Drawing.Size(201, 21)
        Me.cboPaymentTerms.TabIndex = 10
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(16, 100)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(104, 20)
        Me.Label26.TabIndex = 2
        Me.Label26.Text = "Payment Terms"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearBilling
        '
        Me.cmdClearBilling.Location = New System.Drawing.Point(259, 437)
        Me.cmdClearBilling.Name = "cmdClearBilling"
        Me.cmdClearBilling.Size = New System.Drawing.Size(55, 29)
        Me.cmdClearBilling.TabIndex = 24
        Me.cmdClearBilling.Text = "Clear"
        Me.cmdClearBilling.UseVisualStyleBackColor = True
        '
        'cboBTState
        '
        Me.cboBTState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBTState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBTState.DataSource = Me.StateTableBindingSource2
        Me.cboBTState.DisplayMember = "StateCode"
        Me.cboBTState.FormattingEnabled = True
        Me.cboBTState.Location = New System.Drawing.Point(69, 193)
        Me.cboBTState.Name = "cboBTState"
        Me.cboBTState.Size = New System.Drawing.Size(91, 21)
        Me.cboBTState.TabIndex = 20
        '
        'StateTableBindingSource2
        '
        Me.StateTableBindingSource2.DataMember = "StateTable"
        Me.StateTableBindingSource2.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtBTAddress1
        '
        Me.txtBTAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBTAddress1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBTAddress1.Location = New System.Drawing.Point(19, 34)
        Me.txtBTAddress1.MaxLength = 100
        Me.txtBTAddress1.Multiline = True
        Me.txtBTAddress1.Name = "txtBTAddress1"
        Me.txtBTAddress1.Size = New System.Drawing.Size(292, 20)
        Me.txtBTAddress1.TabIndex = 17
        Me.txtBTAddress1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBTCountry
        '
        Me.txtBTCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBTCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBTCountry.Location = New System.Drawing.Point(202, 278)
        Me.txtBTCountry.MaxLength = 100
        Me.txtBTCountry.Name = "txtBTCountry"
        Me.txtBTCountry.ReadOnly = True
        Me.txtBTCountry.Size = New System.Drawing.Size(109, 20)
        Me.txtBTCountry.TabIndex = 22
        Me.txtBTCountry.TabStop = False
        Me.txtBTCountry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBTZip
        '
        Me.txtBTZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBTZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBTZip.Location = New System.Drawing.Point(202, 193)
        Me.txtBTZip.Name = "txtBTZip"
        Me.txtBTZip.Size = New System.Drawing.Size(109, 20)
        Me.txtBTZip.TabIndex = 21
        Me.txtBTZip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBTCity
        '
        Me.txtBTCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBTCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBTCity.Location = New System.Drawing.Point(19, 148)
        Me.txtBTCity.MaxLength = 100
        Me.txtBTCity.Name = "txtBTCity"
        Me.txtBTCity.Size = New System.Drawing.Size(292, 20)
        Me.txtBTCity.TabIndex = 19
        Me.txtBTCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBTAddress2
        '
        Me.txtBTAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBTAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBTAddress2.Location = New System.Drawing.Point(19, 91)
        Me.txtBTAddress2.MaxLength = 100
        Me.txtBTAddress2.Multiline = True
        Me.txtBTAddress2.Name = "txtBTAddress2"
        Me.txtBTAddress2.Size = New System.Drawing.Size(292, 20)
        Me.txtBTAddress2.TabIndex = 18
        Me.txtBTAddress2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(19, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 20)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Address 1"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(19, 69)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 20)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Address 2"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(19, 128)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 20)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "City"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(19, 193)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 20)
        Me.Label21.TabIndex = 15
        Me.Label21.Text = "State"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(19, 238)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 20)
        Me.Label23.TabIndex = 13
        Me.Label23.Text = "Country"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(170, 193)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 20)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Zip"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gpxCreditBilling
        '
        Me.gpxCreditBilling.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxCreditBilling.Controls.Add(Me.Label41)
        Me.gpxCreditBilling.Controls.Add(Me.lblCreditLT45)
        Me.gpxCreditBilling.Controls.Add(Me.Label36)
        Me.gpxCreditBilling.Controls.Add(Me.lblCreditLimit)
        Me.gpxCreditBilling.Controls.Add(Me.lblCreditMT90)
        Me.gpxCreditBilling.Controls.Add(Me.lblCreditLT90)
        Me.gpxCreditBilling.Controls.Add(Me.lblCreditLT60)
        Me.gpxCreditBilling.Controls.Add(Me.lblCreditLT30)
        Me.gpxCreditBilling.Controls.Add(Me.lblCreditBalance)
        Me.gpxCreditBilling.Controls.Add(Me.Label32)
        Me.gpxCreditBilling.Controls.Add(Me.Label28)
        Me.gpxCreditBilling.Controls.Add(Me.Label29)
        Me.gpxCreditBilling.Controls.Add(Me.Label30)
        Me.gpxCreditBilling.Controls.Add(Me.Label31)
        Me.gpxCreditBilling.Location = New System.Drawing.Point(377, 554)
        Me.gpxCreditBilling.Name = "gpxCreditBilling"
        Me.gpxCreditBilling.Size = New System.Drawing.Size(334, 211)
        Me.gpxCreditBilling.TabIndex = 31
        Me.gpxCreditBilling.TabStop = False
        Me.gpxCreditBilling.Text = "Credit Billing Details"
        '
        'Label41
        '
        Me.Label41.Location = New System.Drawing.Point(23, 91)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(97, 20)
        Me.Label41.TabIndex = 49
        Me.Label41.Text = "31 - 45 Days"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreditLT45
        '
        Me.lblCreditLT45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreditLT45.Location = New System.Drawing.Point(153, 91)
        Me.lblCreditLT45.Name = "lblCreditLT45"
        Me.lblCreditLT45.Size = New System.Drawing.Size(134, 20)
        Me.lblCreditLT45.TabIndex = 48
        Me.lblCreditLT45.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(23, 16)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(97, 20)
        Me.Label36.TabIndex = 47
        Me.Label36.Text = "Credit Limit"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreditLimit
        '
        Me.lblCreditLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreditLimit.Location = New System.Drawing.Point(153, 16)
        Me.lblCreditLimit.Name = "lblCreditLimit"
        Me.lblCreditLimit.Size = New System.Drawing.Size(134, 20)
        Me.lblCreditLimit.TabIndex = 46
        Me.lblCreditLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCreditMT90
        '
        Me.lblCreditMT90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreditMT90.Location = New System.Drawing.Point(153, 166)
        Me.lblCreditMT90.Name = "lblCreditMT90"
        Me.lblCreditMT90.Size = New System.Drawing.Size(134, 20)
        Me.lblCreditMT90.TabIndex = 45
        Me.lblCreditMT90.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCreditLT90
        '
        Me.lblCreditLT90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreditLT90.Location = New System.Drawing.Point(153, 141)
        Me.lblCreditLT90.Name = "lblCreditLT90"
        Me.lblCreditLT90.Size = New System.Drawing.Size(134, 20)
        Me.lblCreditLT90.TabIndex = 44
        Me.lblCreditLT90.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCreditLT60
        '
        Me.lblCreditLT60.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreditLT60.Location = New System.Drawing.Point(153, 116)
        Me.lblCreditLT60.Name = "lblCreditLT60"
        Me.lblCreditLT60.Size = New System.Drawing.Size(134, 20)
        Me.lblCreditLT60.TabIndex = 43
        Me.lblCreditLT60.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCreditLT30
        '
        Me.lblCreditLT30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreditLT30.Location = New System.Drawing.Point(153, 66)
        Me.lblCreditLT30.Name = "lblCreditLT30"
        Me.lblCreditLT30.Size = New System.Drawing.Size(134, 20)
        Me.lblCreditLT30.TabIndex = 42
        Me.lblCreditLT30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCreditBalance
        '
        Me.lblCreditBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreditBalance.Location = New System.Drawing.Point(153, 41)
        Me.lblCreditBalance.Name = "lblCreditBalance"
        Me.lblCreditBalance.Size = New System.Drawing.Size(134, 20)
        Me.lblCreditBalance.TabIndex = 41
        Me.lblCreditBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(23, 166)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(97, 20)
        Me.Label32.TabIndex = 28
        Me.Label32.Text = "> 91 Days"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(23, 41)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(97, 20)
        Me.Label28.TabIndex = 16
        Me.Label28.Text = "Current Balance"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(23, 66)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(97, 20)
        Me.Label29.TabIndex = 15
        Me.Label29.Text = "< 30 Days"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(23, 116)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(97, 20)
        Me.Label30.TabIndex = 14
        Me.Label30.Text = "46 - 60 Days"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(23, 141)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(97, 20)
        Me.Label31.TabIndex = 13
        Me.Label31.Text = "61 - 90 Days"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkCreditHold
        '
        Me.chkCreditHold.AutoSize = True
        Me.chkCreditHold.Enabled = False
        Me.chkCreditHold.Location = New System.Drawing.Point(110, 13)
        Me.chkCreditHold.Name = "chkCreditHold"
        Me.chkCreditHold.Size = New System.Drawing.Size(48, 17)
        Me.chkCreditHold.TabIndex = 7
        Me.chkCreditHold.TabStop = False
        Me.chkCreditHold.Text = "Hold"
        Me.chkCreditHold.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(821, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 61
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(901, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 62
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(981, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 63
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(28, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 19)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "YTD Sales (Fiscal)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(28, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(132, 19)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "MTD Sales"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(28, 76)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(132, 19)
        Me.Label33.TabIndex = 34
        Me.Label33.Text = "Average Order"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxCustomerSnapshot
        '
        Me.gpxCustomerSnapshot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxCustomerSnapshot.Controls.Add(Me.lblAVGDaysToPay)
        Me.gpxCustomerSnapshot.Controls.Add(Me.Label61)
        Me.gpxCustomerSnapshot.Controls.Add(Me.lblLastActivityDate)
        Me.gpxCustomerSnapshot.Controls.Add(Me.lblAverageOrder)
        Me.gpxCustomerSnapshot.Controls.Add(Me.lblYTDSales)
        Me.gpxCustomerSnapshot.Controls.Add(Me.lblMTDSales)
        Me.gpxCustomerSnapshot.Controls.Add(Me.Label34)
        Me.gpxCustomerSnapshot.Controls.Add(Me.Label33)
        Me.gpxCustomerSnapshot.Controls.Add(Me.Label6)
        Me.gpxCustomerSnapshot.Controls.Add(Me.Label7)
        Me.gpxCustomerSnapshot.Location = New System.Drawing.Point(17, 495)
        Me.gpxCustomerSnapshot.Name = "gpxCustomerSnapshot"
        Me.gpxCustomerSnapshot.Size = New System.Drawing.Size(365, 161)
        Me.gpxCustomerSnapshot.TabIndex = 11
        Me.gpxCustomerSnapshot.TabStop = False
        Me.gpxCustomerSnapshot.Text = "Customer Financial Snapshot"
        '
        'lblAVGDaysToPay
        '
        Me.lblAVGDaysToPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAVGDaysToPay.Location = New System.Drawing.Point(181, 128)
        Me.lblAVGDaysToPay.Name = "lblAVGDaysToPay"
        Me.lblAVGDaysToPay.Size = New System.Drawing.Size(148, 20)
        Me.lblAVGDaysToPay.TabIndex = 37
        Me.lblAVGDaysToPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label61
        '
        Me.Label61.Location = New System.Drawing.Point(28, 129)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(132, 19)
        Me.Label61.TabIndex = 38
        Me.Label61.Text = "Average Days to Pay"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLastActivityDate
        '
        Me.lblLastActivityDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLastActivityDate.Location = New System.Drawing.Point(180, 102)
        Me.lblLastActivityDate.Name = "lblLastActivityDate"
        Me.lblLastActivityDate.Size = New System.Drawing.Size(148, 20)
        Me.lblLastActivityDate.TabIndex = 11
        Me.lblLastActivityDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAverageOrder
        '
        Me.lblAverageOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAverageOrder.Location = New System.Drawing.Point(180, 75)
        Me.lblAverageOrder.Name = "lblAverageOrder"
        Me.lblAverageOrder.Size = New System.Drawing.Size(148, 20)
        Me.lblAverageOrder.TabIndex = 11
        Me.lblAverageOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblYTDSales
        '
        Me.lblYTDSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYTDSales.Location = New System.Drawing.Point(180, 51)
        Me.lblYTDSales.Name = "lblYTDSales"
        Me.lblYTDSales.Size = New System.Drawing.Size(148, 20)
        Me.lblYTDSales.TabIndex = 11
        Me.lblYTDSales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMTDSales
        '
        Me.lblMTDSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMTDSales.Location = New System.Drawing.Point(180, 26)
        Me.lblMTDSales.Name = "lblMTDSales"
        Me.lblMTDSales.Size = New System.Drawing.Size(148, 20)
        Me.lblMTDSales.TabIndex = 11
        Me.lblMTDSales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(28, 103)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(132, 19)
        Me.Label34.TabIndex = 36
        Me.Label34.Text = "Last Activity Date"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdOpenOrders
        '
        Me.cmdOpenOrders.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenOrders.Location = New System.Drawing.Point(902, 725)
        Me.cmdOpenOrders.Name = "cmdOpenOrders"
        Me.cmdOpenOrders.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenOrders.TabIndex = 58
        Me.cmdOpenOrders.Text = "Open Orders"
        Me.cmdOpenOrders.UseVisualStyleBackColor = True
        '
        'cmdSalesHistory
        '
        Me.cmdSalesHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalesHistory.Location = New System.Drawing.Point(982, 726)
        Me.cmdSalesHistory.Name = "cmdSalesHistory"
        Me.cmdSalesHistory.Size = New System.Drawing.Size(71, 40)
        Me.cmdSalesHistory.TabIndex = 59
        Me.cmdSalesHistory.Text = "Sales History"
        Me.cmdSalesHistory.UseVisualStyleBackColor = True
        '
        'cmdCopyToShippingAddress
        '
        Me.cmdCopyToShippingAddress.Location = New System.Drawing.Point(198, 437)
        Me.cmdCopyToShippingAddress.Name = "cmdCopyToShippingAddress"
        Me.cmdCopyToShippingAddress.Size = New System.Drawing.Size(55, 28)
        Me.cmdCopyToShippingAddress.TabIndex = 23
        Me.cmdCopyToShippingAddress.Text = "Copy"
        Me.cmdCopyToShippingAddress.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Blue
        Me.Label22.Location = New System.Drawing.Point(19, 437)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(142, 28)
        Me.Label22.TabIndex = 37
        Me.Label22.Text = "Copy Billing Address to Shipping Address"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCustomerStatement
        '
        Me.cmdCustomerStatement.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCustomerStatement.Location = New System.Drawing.Point(1062, 725)
        Me.cmdCustomerStatement.Name = "cmdCustomerStatement"
        Me.cmdCustomerStatement.Size = New System.Drawing.Size(71, 40)
        Me.cmdCustomerStatement.TabIndex = 60
        Me.cmdCustomerStatement.Text = "Account Statement"
        Me.cmdCustomerStatement.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(3, 254)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(312, 20)
        Me.Label27.TabIndex = 50
        Me.Label27.Text = "Special Shipping Instructions (prints on Shipping Docs)"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShippingInstructions
        '
        Me.txtShippingInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShippingInstructions.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShippingInstructions.Location = New System.Drawing.Point(6, 277)
        Me.txtShippingInstructions.Multiline = True
        Me.txtShippingInstructions.Name = "txtShippingInstructions"
        Me.txtShippingInstructions.Size = New System.Drawing.Size(312, 118)
        Me.txtShippingInstructions.TabIndex = 14
        Me.txtShippingInstructions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label49
        '
        Me.Label49.Location = New System.Drawing.Point(16, 133)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(104, 20)
        Me.Label49.TabIndex = 48
        Me.Label49.Text = "Sales Territory"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(16, 166)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(104, 20)
        Me.Label40.TabIndex = 45
        Me.Label40.Text = "Preferred Shipper"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipper
        '
        Me.cboShipper.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipper.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipper.DataSource = Me.ShipMethodBindingSource
        Me.cboShipper.DisplayMember = "ShipMethID"
        Me.cboShipper.FormattingEnabled = True
        Me.cboShipper.Location = New System.Drawing.Point(114, 167)
        Me.cboShipper.MaxLength = 50
        Me.cboShipper.Name = "cboShipper"
        Me.cboShipper.Size = New System.Drawing.Size(201, 21)
        Me.cboShipper.TabIndex = 12
        '
        'ShipMethodBindingSource
        '
        Me.ShipMethodBindingSource.DataMember = "ShipMethod"
        Me.ShipMethodBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'tcAddress
        '
        Me.tcAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcAddress.Controls.Add(Me.BillingAddress)
        Me.tcAddress.Controls.Add(Me.ShippingAddress)
        Me.tcAddress.Controls.Add(Me.AddShipTo)
        Me.tcAddress.Location = New System.Drawing.Point(377, 27)
        Me.tcAddress.Name = "tcAddress"
        Me.tcAddress.SelectedIndex = 0
        Me.tcAddress.Size = New System.Drawing.Size(334, 508)
        Me.tcAddress.TabIndex = 17
        '
        'BillingAddress
        '
        Me.BillingAddress.Controls.Add(Me.cboCountryList)
        Me.BillingAddress.Controls.Add(Me.txtBTCountry)
        Me.BillingAddress.Controls.Add(Me.Label67)
        Me.BillingAddress.Controls.Add(Me.Label62)
        Me.BillingAddress.Controls.Add(Me.cmdClearBilling)
        Me.BillingAddress.Controls.Add(Me.cmdCopyToShippingAddress)
        Me.BillingAddress.Controls.Add(Me.cboBTState)
        Me.BillingAddress.Controls.Add(Me.Label22)
        Me.BillingAddress.Controls.Add(Me.txtBTAddress1)
        Me.BillingAddress.Controls.Add(Me.Label5)
        Me.BillingAddress.Controls.Add(Me.txtBTZip)
        Me.BillingAddress.Controls.Add(Me.Label23)
        Me.BillingAddress.Controls.Add(Me.txtBTCity)
        Me.BillingAddress.Controls.Add(Me.Label21)
        Me.BillingAddress.Controls.Add(Me.txtBTAddress2)
        Me.BillingAddress.Controls.Add(Me.Label15)
        Me.BillingAddress.Controls.Add(Me.Label12)
        Me.BillingAddress.Controls.Add(Me.Label14)
        Me.BillingAddress.Location = New System.Drawing.Point(4, 22)
        Me.BillingAddress.Name = "BillingAddress"
        Me.BillingAddress.Padding = New System.Windows.Forms.Padding(3)
        Me.BillingAddress.Size = New System.Drawing.Size(326, 482)
        Me.BillingAddress.TabIndex = 0
        Me.BillingAddress.Text = "Billing Address"
        Me.BillingAddress.UseVisualStyleBackColor = True
        '
        'cboCountryList
        '
        Me.cboCountryList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCountryList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCountryList.DataSource = Me.CountryCodesBindingSource
        Me.cboCountryList.DisplayMember = "Country"
        Me.cboCountryList.FormattingEnabled = True
        Me.cboCountryList.Location = New System.Drawing.Point(69, 239)
        Me.cboCountryList.Name = "cboCountryList"
        Me.cboCountryList.Size = New System.Drawing.Size(242, 21)
        Me.cboCountryList.TabIndex = 22
        '
        'CountryCodesBindingSource
        '
        Me.CountryCodesBindingSource.DataMember = "CountryCodes"
        Me.CountryCodesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label67
        '
        Me.Label67.Location = New System.Drawing.Point(19, 276)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(84, 20)
        Me.Label67.TabIndex = 66
        Me.Label67.Text = "Country Code"
        Me.Label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label62
        '
        Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.ForeColor = System.Drawing.Color.Blue
        Me.Label62.Location = New System.Drawing.Point(16, 347)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(292, 66)
        Me.Label62.TabIndex = 64
        Me.Label62.Text = "Address 1 and Address 2 must be limited to one line so that the Billing Address w" & _
            "ill show correctly on the windowed envelopes when mailing Invoices."
        Me.Label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ShippingAddress
        '
        Me.ShippingAddress.Controls.Add(Me.CRReportViewer)
        Me.ShippingAddress.Controls.Add(Me.Label68)
        Me.ShippingAddress.Controls.Add(Me.cboShipToCountry)
        Me.ShippingAddress.Controls.Add(Me.Label55)
        Me.ShippingAddress.Controls.Add(Me.cmdPrintLabel)
        Me.ShippingAddress.Controls.Add(Me.cmdClearDefaultShipping)
        Me.ShippingAddress.Controls.Add(Me.txtSTAddress1)
        Me.ShippingAddress.Controls.Add(Me.txtSTAddress2)
        Me.ShippingAddress.Controls.Add(Me.txtSTCity)
        Me.ShippingAddress.Controls.Add(Me.cboSTState)
        Me.ShippingAddress.Controls.Add(Me.txtSTZip)
        Me.ShippingAddress.Controls.Add(Me.txtSTCountry)
        Me.ShippingAddress.Controls.Add(Me.Label19)
        Me.ShippingAddress.Controls.Add(Me.Label13)
        Me.ShippingAddress.Controls.Add(Me.Label16)
        Me.ShippingAddress.Controls.Add(Me.Label17)
        Me.ShippingAddress.Controls.Add(Me.Label18)
        Me.ShippingAddress.Controls.Add(Me.Label20)
        Me.ShippingAddress.Location = New System.Drawing.Point(4, 22)
        Me.ShippingAddress.Name = "ShippingAddress"
        Me.ShippingAddress.Padding = New System.Windows.Forms.Padding(3)
        Me.ShippingAddress.Size = New System.Drawing.Size(326, 482)
        Me.ShippingAddress.TabIndex = 1
        Me.ShippingAddress.Text = "Default Shipping Address"
        Me.ShippingAddress.UseVisualStyleBackColor = True
        '
        'CRReportViewer
        '
        Me.CRReportViewer.ActiveViewIndex = 0
        Me.CRReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRReportViewer.Location = New System.Drawing.Point(22, 439)
        Me.CRReportViewer.Name = "CRReportViewer"
        Me.CRReportViewer.ReportSource = Me.CRXMonthEndCustomerReport1
        Me.CRReportViewer.Size = New System.Drawing.Size(34, 25)
        Me.CRReportViewer.TabIndex = 48
        Me.CRReportViewer.Visible = False
        '
        'Label68
        '
        Me.Label68.Location = New System.Drawing.Point(19, 357)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(97, 20)
        Me.Label68.TabIndex = 54
        Me.Label68.Text = "Country Code"
        Me.Label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipToCountry
        '
        Me.cboShipToCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipToCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipToCountry.DataSource = Me.CountryCodesBindingSource
        Me.cboShipToCountry.DisplayMember = "Country"
        Me.cboShipToCountry.FormattingEnabled = True
        Me.cboShipToCountry.Location = New System.Drawing.Point(79, 319)
        Me.cboShipToCountry.Name = "cboShipToCountry"
        Me.cboShipToCountry.Size = New System.Drawing.Size(230, 21)
        Me.cboShipToCountry.TabIndex = 30
        '
        'Label55
        '
        Me.Label55.ForeColor = System.Drawing.Color.Blue
        Me.Label55.Location = New System.Drawing.Point(131, 439)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(117, 20)
        Me.Label55.TabIndex = 52
        Me.Label55.Text = "Print Shipping Label"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintLabel
        '
        Me.cmdPrintLabel.Location = New System.Drawing.Point(254, 435)
        Me.cmdPrintLabel.Name = "cmdPrintLabel"
        Me.cmdPrintLabel.Size = New System.Drawing.Size(55, 29)
        Me.cmdPrintLabel.TabIndex = 33
        Me.cmdPrintLabel.Text = "Print"
        Me.cmdPrintLabel.UseVisualStyleBackColor = True
        '
        'cmdClearDefaultShipping
        '
        Me.cmdClearDefaultShipping.Location = New System.Drawing.Point(254, 396)
        Me.cmdClearDefaultShipping.Name = "cmdClearDefaultShipping"
        Me.cmdClearDefaultShipping.Size = New System.Drawing.Size(55, 29)
        Me.cmdClearDefaultShipping.TabIndex = 32
        Me.cmdClearDefaultShipping.Text = "Clear"
        Me.cmdClearDefaultShipping.UseVisualStyleBackColor = True
        '
        'txtSTAddress1
        '
        Me.txtSTAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSTAddress1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSTAddress1.Location = New System.Drawing.Point(19, 32)
        Me.txtSTAddress1.MaxLength = 200
        Me.txtSTAddress1.Multiline = True
        Me.txtSTAddress1.Name = "txtSTAddress1"
        Me.txtSTAddress1.Size = New System.Drawing.Size(290, 90)
        Me.txtSTAddress1.TabIndex = 25
        Me.txtSTAddress1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSTAddress2
        '
        Me.txtSTAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSTAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSTAddress2.Location = New System.Drawing.Point(19, 148)
        Me.txtSTAddress2.MaxLength = 200
        Me.txtSTAddress2.Multiline = True
        Me.txtSTAddress2.Name = "txtSTAddress2"
        Me.txtSTAddress2.Size = New System.Drawing.Size(290, 90)
        Me.txtSTAddress2.TabIndex = 26
        Me.txtSTAddress2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSTCity
        '
        Me.txtSTCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSTCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSTCity.Location = New System.Drawing.Point(79, 255)
        Me.txtSTCity.MaxLength = 100
        Me.txtSTCity.Name = "txtSTCity"
        Me.txtSTCity.Size = New System.Drawing.Size(230, 20)
        Me.txtSTCity.TabIndex = 27
        Me.txtSTCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboSTState
        '
        Me.cboSTState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSTState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSTState.DataSource = Me.StateTableBindingSource1
        Me.cboSTState.DisplayMember = "StateCode"
        Me.cboSTState.FormattingEnabled = True
        Me.cboSTState.Location = New System.Drawing.Point(79, 287)
        Me.cboSTState.Name = "cboSTState"
        Me.cboSTState.Size = New System.Drawing.Size(79, 21)
        Me.cboSTState.TabIndex = 28
        '
        'StateTableBindingSource1
        '
        Me.StateTableBindingSource1.DataMember = "StateTable"
        Me.StateTableBindingSource1.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtSTZip
        '
        Me.txtSTZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSTZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSTZip.Location = New System.Drawing.Point(200, 287)
        Me.txtSTZip.Name = "txtSTZip"
        Me.txtSTZip.Size = New System.Drawing.Size(109, 20)
        Me.txtSTZip.TabIndex = 29
        Me.txtSTZip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSTCountry
        '
        Me.txtSTCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSTCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSTCountry.Location = New System.Drawing.Point(200, 355)
        Me.txtSTCountry.Name = "txtSTCountry"
        Me.txtSTCountry.ReadOnly = True
        Me.txtSTCountry.Size = New System.Drawing.Size(109, 20)
        Me.txtSTCountry.TabIndex = 31
        Me.txtSTCountry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(165, 287)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(29, 20)
        Me.Label19.TabIndex = 47
        Me.Label19.Text = "Zip"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(19, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 20)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "Address 1"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(19, 128)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 20)
        Me.Label16.TabIndex = 50
        Me.Label16.Text = "Address 2"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(19, 255)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 20)
        Me.Label17.TabIndex = 49
        Me.Label17.Text = "City"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(19, 289)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 20)
        Me.Label18.TabIndex = 48
        Me.Label18.Text = "State"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(19, 323)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(68, 20)
        Me.Label20.TabIndex = 46
        Me.Label20.Text = "Country"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AddShipTo
        '
        Me.AddShipTo.Controls.Add(Me.Label69)
        Me.AddShipTo.Controls.Add(Me.cboAddShipToCountry)
        Me.AddShipTo.Controls.Add(Me.cmdDeleteAddShipTo)
        Me.AddShipTo.Controls.Add(Me.txtAddShipToName)
        Me.AddShipTo.Controls.Add(Me.cmdSaveAdditionalShipTo)
        Me.AddShipTo.Controls.Add(Me.cmdClearAdditionalShipTo)
        Me.AddShipTo.Controls.Add(Me.cboShipToID)
        Me.AddShipTo.Controls.Add(Me.txtAddCountry)
        Me.AddShipTo.Controls.Add(Me.txtAddZip)
        Me.AddShipTo.Controls.Add(Me.txtAddCity)
        Me.AddShipTo.Controls.Add(Me.txtAddAddress2)
        Me.AddShipTo.Controls.Add(Me.txtAddAddress1)
        Me.AddShipTo.Controls.Add(Me.cboAddState)
        Me.AddShipTo.Controls.Add(Me.Label37)
        Me.AddShipTo.Controls.Add(Me.Label50)
        Me.AddShipTo.Controls.Add(Me.Label10)
        Me.AddShipTo.Controls.Add(Me.Label43)
        Me.AddShipTo.Controls.Add(Me.Label44)
        Me.AddShipTo.Controls.Add(Me.Label45)
        Me.AddShipTo.Controls.Add(Me.Label46)
        Me.AddShipTo.Controls.Add(Me.Label47)
        Me.AddShipTo.Location = New System.Drawing.Point(4, 22)
        Me.AddShipTo.Name = "AddShipTo"
        Me.AddShipTo.Padding = New System.Windows.Forms.Padding(3)
        Me.AddShipTo.Size = New System.Drawing.Size(326, 482)
        Me.AddShipTo.TabIndex = 2
        Me.AddShipTo.Text = "Additional Ship To"
        Me.AddShipTo.UseVisualStyleBackColor = True
        '
        'Label69
        '
        Me.Label69.Location = New System.Drawing.Point(22, 414)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(122, 20)
        Me.Label69.TabIndex = 70
        Me.Label69.Text = "Country Code"
        Me.Label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAddShipToCountry
        '
        Me.cboAddShipToCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAddShipToCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAddShipToCountry.DataSource = Me.CountryCodesBindingSource
        Me.cboAddShipToCountry.DisplayMember = "Country"
        Me.cboAddShipToCountry.FormattingEnabled = True
        Me.cboAddShipToCountry.Location = New System.Drawing.Point(80, 386)
        Me.cboAddShipToCountry.Name = "cboAddShipToCountry"
        Me.cboAddShipToCountry.Size = New System.Drawing.Size(230, 21)
        Me.cboAddShipToCountry.TabIndex = 40
        '
        'cmdDeleteAddShipTo
        '
        Me.cmdDeleteAddShipTo.Location = New System.Drawing.Point(255, 447)
        Me.cmdDeleteAddShipTo.Name = "cmdDeleteAddShipTo"
        Me.cmdDeleteAddShipTo.Size = New System.Drawing.Size(55, 29)
        Me.cmdDeleteAddShipTo.TabIndex = 43
        Me.cmdDeleteAddShipTo.Text = "Delete"
        Me.cmdDeleteAddShipTo.UseVisualStyleBackColor = True
        '
        'txtAddShipToName
        '
        Me.txtAddShipToName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddShipToName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddShipToName.Location = New System.Drawing.Point(22, 65)
        Me.txtAddShipToName.Multiline = True
        Me.txtAddShipToName.Name = "txtAddShipToName"
        Me.txtAddShipToName.Size = New System.Drawing.Size(288, 54)
        Me.txtAddShipToName.TabIndex = 34
        Me.txtAddShipToName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdSaveAdditionalShipTo
        '
        Me.cmdSaveAdditionalShipTo.Location = New System.Drawing.Point(129, 447)
        Me.cmdSaveAdditionalShipTo.Name = "cmdSaveAdditionalShipTo"
        Me.cmdSaveAdditionalShipTo.Size = New System.Drawing.Size(55, 29)
        Me.cmdSaveAdditionalShipTo.TabIndex = 41
        Me.cmdSaveAdditionalShipTo.Text = "Save"
        Me.cmdSaveAdditionalShipTo.UseVisualStyleBackColor = True
        '
        'cmdClearAdditionalShipTo
        '
        Me.cmdClearAdditionalShipTo.Location = New System.Drawing.Point(192, 447)
        Me.cmdClearAdditionalShipTo.Name = "cmdClearAdditionalShipTo"
        Me.cmdClearAdditionalShipTo.Size = New System.Drawing.Size(55, 29)
        Me.cmdClearAdditionalShipTo.TabIndex = 42
        Me.cmdClearAdditionalShipTo.Text = "Clear"
        Me.cmdClearAdditionalShipTo.UseVisualStyleBackColor = True
        '
        'cboShipToID
        '
        Me.cboShipToID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipToID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipToID.DataSource = Me.AdditionalShipToBindingSource
        Me.cboShipToID.DisplayMember = "ShipToID"
        Me.cboShipToID.FormattingEnabled = True
        Me.cboShipToID.Location = New System.Drawing.Point(80, 16)
        Me.cboShipToID.Name = "cboShipToID"
        Me.cboShipToID.Size = New System.Drawing.Size(230, 21)
        Me.cboShipToID.TabIndex = 33
        '
        'AdditionalShipToBindingSource
        '
        Me.AdditionalShipToBindingSource.DataMember = "AdditionalShipTo"
        Me.AdditionalShipToBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtAddCountry
        '
        Me.txtAddCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddCountry.Location = New System.Drawing.Point(192, 414)
        Me.txtAddCountry.Name = "txtAddCountry"
        Me.txtAddCountry.ReadOnly = True
        Me.txtAddCountry.Size = New System.Drawing.Size(118, 20)
        Me.txtAddCountry.TabIndex = 41
        Me.txtAddCountry.TabStop = False
        Me.txtAddCountry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAddZip
        '
        Me.txtAddZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddZip.Location = New System.Drawing.Point(189, 359)
        Me.txtAddZip.Name = "txtAddZip"
        Me.txtAddZip.Size = New System.Drawing.Size(121, 20)
        Me.txtAddZip.TabIndex = 39
        Me.txtAddZip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAddCity
        '
        Me.txtAddCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddCity.Location = New System.Drawing.Point(80, 332)
        Me.txtAddCity.MaxLength = 100
        Me.txtAddCity.Name = "txtAddCity"
        Me.txtAddCity.Size = New System.Drawing.Size(230, 20)
        Me.txtAddCity.TabIndex = 37
        Me.txtAddCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAddAddress2
        '
        Me.txtAddAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddAddress2.Location = New System.Drawing.Point(22, 250)
        Me.txtAddAddress2.MaxLength = 200
        Me.txtAddAddress2.Multiline = True
        Me.txtAddAddress2.Name = "txtAddAddress2"
        Me.txtAddAddress2.Size = New System.Drawing.Size(288, 70)
        Me.txtAddAddress2.TabIndex = 36
        Me.txtAddAddress2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAddAddress1
        '
        Me.txtAddAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddAddress1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddAddress1.Location = New System.Drawing.Point(22, 154)
        Me.txtAddAddress1.MaxLength = 200
        Me.txtAddAddress1.Multiline = True
        Me.txtAddAddress1.Name = "txtAddAddress1"
        Me.txtAddAddress1.Size = New System.Drawing.Size(288, 70)
        Me.txtAddAddress1.TabIndex = 35
        Me.txtAddAddress1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboAddState
        '
        Me.cboAddState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAddState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAddState.DataSource = Me.StateTableBindingSource
        Me.cboAddState.DisplayMember = "StateCode"
        Me.cboAddState.FormattingEnabled = True
        Me.cboAddState.Location = New System.Drawing.Point(80, 359)
        Me.cboAddState.Name = "cboAddState"
        Me.cboAddState.Size = New System.Drawing.Size(79, 21)
        Me.cboAddState.TabIndex = 38
        '
        'StateTableBindingSource
        '
        Me.StateTableBindingSource.DataMember = "StateTable"
        Me.StateTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(155, 359)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(29, 20)
        Me.Label37.TabIndex = 66
        Me.Label37.Text = "Zip"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label50
        '
        Me.Label50.Location = New System.Drawing.Point(22, 47)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(68, 20)
        Me.Label50.TabIndex = 68
        Me.Label50.Text = "Name"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(22, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 20)
        Me.Label10.TabIndex = 65
        Me.Label10.Text = "ShipTo ID"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(22, 131)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(68, 20)
        Me.Label43.TabIndex = 60
        Me.Label43.Text = "Address 1"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(22, 227)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(68, 20)
        Me.Label44.TabIndex = 64
        Me.Label44.Text = "Address 2"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label45
        '
        Me.Label45.Location = New System.Drawing.Point(22, 332)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(68, 20)
        Me.Label45.TabIndex = 63
        Me.Label45.Text = "City"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label46
        '
        Me.Label46.Location = New System.Drawing.Point(22, 360)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(68, 20)
        Me.Label46.TabIndex = 62
        Me.Label46.Text = "State"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(22, 386)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(68, 20)
        Me.Label47.TabIndex = 61
        Me.Label47.Text = "Country"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CustomerContactsBindingSource
        '
        Me.CustomerContactsBindingSource.DataMember = "CustomerContacts"
        Me.CustomerContactsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ShipMethodTableAdapter
        '
        Me.ShipMethodTableAdapter.ClearBeforeFill = True
        '
        'CustomerContactsTableAdapter
        '
        Me.CustomerContactsTableAdapter.ClearBeforeFill = True
        '
        'AdditionalShipToTableAdapter
        '
        Me.AdditionalShipToTableAdapter.ClearBeforeFill = True
        '
        'StateTableTableAdapter
        '
        Me.StateTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerClassTableAdapter
        '
        Me.CustomerClassTableAdapter.ClearBeforeFill = True
        '
        'tabMainContact
        '
        Me.tabMainContact.Controls.Add(Me.Label79)
        Me.tabMainContact.Controls.Add(Me.Label82)
        Me.tabMainContact.Controls.Add(Me.txtShipEmail)
        Me.tabMainContact.Controls.Add(Me.Label54)
        Me.tabMainContact.Controls.Add(Me.txtSalesContactEmail)
        Me.tabMainContact.Controls.Add(Me.txtAPContactName)
        Me.tabMainContact.Controls.Add(Me.txtAPPhoneNumber)
        Me.tabMainContact.Controls.Add(Me.txtAPFaxNumber)
        Me.tabMainContact.Controls.Add(Me.Label58)
        Me.tabMainContact.Controls.Add(Me.Label51)
        Me.tabMainContact.Controls.Add(Me.Label52)
        Me.tabMainContact.Controls.Add(Me.txtAPEmailAddress)
        Me.tabMainContact.Controls.Add(Me.Label53)
        Me.tabMainContact.Controls.Add(Me.gpxCustomerSnapshot)
        Me.tabMainContact.Location = New System.Drawing.Point(4, 22)
        Me.tabMainContact.Name = "tabMainContact"
        Me.tabMainContact.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMainContact.Size = New System.Drawing.Size(393, 662)
        Me.tabMainContact.TabIndex = 2
        Me.tabMainContact.Text = "Main Contact"
        Me.tabMainContact.UseVisualStyleBackColor = True
        '
        'Label79
        '
        Me.Label79.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.ForeColor = System.Drawing.Color.Blue
        Me.Label79.Location = New System.Drawing.Point(19, 427)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(348, 49)
        Me.Label79.TabIndex = 72
        Me.Label79.Text = "This will automatically email an Advance Shipment Notice from Fedex/UPS Small Pac" & _
            "kage when processed. FEDEX and UPS only allow one email address to be entered."
        Me.Label79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label82
        '
        Me.Label82.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.ForeColor = System.Drawing.Color.Black
        Me.Label82.Location = New System.Drawing.Point(14, 321)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(368, 22)
        Me.Label82.TabIndex = 71
        Me.Label82.Text = "Email Advance Shipment Notices (UPS/FedEx)"
        Me.Label82.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShipEmail
        '
        Me.txtShipEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipEmail.Location = New System.Drawing.Point(17, 346)
        Me.txtShipEmail.MaxLength = 200
        Me.txtShipEmail.Multiline = True
        Me.txtShipEmail.Name = "txtShipEmail"
        Me.txtShipEmail.Size = New System.Drawing.Size(365, 80)
        Me.txtShipEmail.TabIndex = 6
        Me.txtShipEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label54
        '
        Me.Label54.Location = New System.Drawing.Point(14, 105)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(278, 20)
        Me.Label54.TabIndex = 68
        Me.Label54.Text = "Sales Contact Email Address"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesContactEmail
        '
        Me.txtSalesContactEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesContactEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesContactEmail.Location = New System.Drawing.Point(17, 128)
        Me.txtSalesContactEmail.MaxLength = 500
        Me.txtSalesContactEmail.Multiline = True
        Me.txtSalesContactEmail.Name = "txtSalesContactEmail"
        Me.txtSalesContactEmail.Size = New System.Drawing.Size(365, 80)
        Me.txtSalesContactEmail.TabIndex = 4
        Me.txtSalesContactEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAPContactName
        '
        Me.txtAPContactName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAPContactName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAPContactName.Location = New System.Drawing.Point(86, 16)
        Me.txtAPContactName.Name = "txtAPContactName"
        Me.txtAPContactName.Size = New System.Drawing.Size(296, 20)
        Me.txtAPContactName.TabIndex = 1
        Me.txtAPContactName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAPPhoneNumber
        '
        Me.txtAPPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAPPhoneNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAPPhoneNumber.Location = New System.Drawing.Point(86, 47)
        Me.txtAPPhoneNumber.Name = "txtAPPhoneNumber"
        Me.txtAPPhoneNumber.Size = New System.Drawing.Size(296, 20)
        Me.txtAPPhoneNumber.TabIndex = 2
        Me.txtAPPhoneNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAPFaxNumber
        '
        Me.txtAPFaxNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAPFaxNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAPFaxNumber.Location = New System.Drawing.Point(86, 78)
        Me.txtAPFaxNumber.Name = "txtAPFaxNumber"
        Me.txtAPFaxNumber.Size = New System.Drawing.Size(296, 20)
        Me.txtAPFaxNumber.TabIndex = 3
        Me.txtAPFaxNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label58
        '
        Me.Label58.Location = New System.Drawing.Point(19, 13)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(104, 20)
        Me.Label58.TabIndex = 64
        Me.Label58.Text = "Name"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label51
        '
        Me.Label51.Location = New System.Drawing.Point(19, 75)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(91, 20)
        Me.Label51.TabIndex = 55
        Me.Label51.Text = "Fax #"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label52
        '
        Me.Label52.Location = New System.Drawing.Point(14, 213)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(278, 20)
        Me.Label52.TabIndex = 56
        Me.Label52.Text = "A/P Email Address"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAPEmailAddress
        '
        Me.txtAPEmailAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAPEmailAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAPEmailAddress.Location = New System.Drawing.Point(17, 237)
        Me.txtAPEmailAddress.MaxLength = 500
        Me.txtAPEmailAddress.Multiline = True
        Me.txtAPEmailAddress.Name = "txtAPEmailAddress"
        Me.txtAPEmailAddress.Size = New System.Drawing.Size(365, 80)
        Me.txtAPEmailAddress.TabIndex = 5
        Me.txtAPEmailAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label53
        '
        Me.Label53.Location = New System.Drawing.Point(19, 44)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(104, 20)
        Me.Label53.TabIndex = 54
        Me.Label53.Text = "Phone #"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabAdditionalContacts
        '
        Me.tabAdditionalContacts.Controls.Add(Me.Label65)
        Me.tabAdditionalContacts.Controls.Add(Me.lblContactDepartment)
        Me.tabAdditionalContacts.Controls.Add(Me.cmdDeleteContact)
        Me.tabAdditionalContacts.Controls.Add(Me.Label11)
        Me.tabAdditionalContacts.Controls.Add(Me.cmdAddContact)
        Me.tabAdditionalContacts.Controls.Add(Me.Label24)
        Me.tabAdditionalContacts.Controls.Add(Me.cmdClearContact)
        Me.tabAdditionalContacts.Controls.Add(Me.Label9)
        Me.tabAdditionalContacts.Controls.Add(Me.cboContactDepartment)
        Me.tabAdditionalContacts.Controls.Add(Me.Label39)
        Me.tabAdditionalContacts.Controls.Add(Me.txtContactPhone)
        Me.tabAdditionalContacts.Controls.Add(Me.txtContactEmail)
        Me.tabAdditionalContacts.Controls.Add(Me.txtContactName)
        Me.tabAdditionalContacts.Controls.Add(Me.txtContactFax)
        Me.tabAdditionalContacts.Controls.Add(Me.Label2)
        Me.tabAdditionalContacts.Location = New System.Drawing.Point(4, 22)
        Me.tabAdditionalContacts.Name = "tabAdditionalContacts"
        Me.tabAdditionalContacts.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAdditionalContacts.Size = New System.Drawing.Size(393, 662)
        Me.tabAdditionalContacts.TabIndex = 1
        Me.tabAdditionalContacts.Text = "Add Contact"
        Me.tabAdditionalContacts.UseVisualStyleBackColor = True
        '
        'Label65
        '
        Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.ForeColor = System.Drawing.Color.Blue
        Me.Label65.Location = New System.Drawing.Point(25, 525)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(333, 51)
        Me.Label65.TabIndex = 65
        Me.Label65.Text = "Adding contacts here will display on the Contact List tab (above)."
        Me.Label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblContactDepartment
        '
        Me.lblContactDepartment.ForeColor = System.Drawing.Color.Blue
        Me.lblContactDepartment.Location = New System.Drawing.Point(28, 84)
        Me.lblContactDepartment.Name = "lblContactDepartment"
        Me.lblContactDepartment.Size = New System.Drawing.Size(330, 19)
        Me.lblContactDepartment.TabIndex = 52
        Me.lblContactDepartment.Text = "PURCHASING - will print on FOX"
        Me.lblContactDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteContact
        '
        Me.cmdDeleteContact.Location = New System.Drawing.Point(303, 474)
        Me.cmdDeleteContact.Name = "cmdDeleteContact"
        Me.cmdDeleteContact.Size = New System.Drawing.Size(55, 29)
        Me.cmdDeleteContact.TabIndex = 51
        Me.cmdDeleteContact.Text = "Delete"
        Me.cmdDeleteContact.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(28, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(281, 20)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Contact Department     (**Required)"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAddContact
        '
        Me.cmdAddContact.Location = New System.Drawing.Point(181, 474)
        Me.cmdAddContact.Name = "cmdAddContact"
        Me.cmdAddContact.Size = New System.Drawing.Size(55, 29)
        Me.cmdAddContact.TabIndex = 49
        Me.cmdAddContact.Text = "Save"
        Me.cmdAddContact.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(28, 273)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(83, 20)
        Me.Label24.TabIndex = 34
        Me.Label24.Text = "Fax Number"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearContact
        '
        Me.cmdClearContact.Location = New System.Drawing.Point(242, 474)
        Me.cmdClearContact.Name = "cmdClearContact"
        Me.cmdClearContact.Size = New System.Drawing.Size(55, 29)
        Me.cmdClearContact.TabIndex = 50
        Me.cmdClearContact.Text = "Clear"
        Me.cmdClearContact.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(28, 123)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 20)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Contact Name"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboContactDepartment
        '
        Me.cboContactDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboContactDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboContactDepartment.DataSource = Me.CustomerContactsBindingSource
        Me.cboContactDepartment.DisplayMember = "ContactDepartment"
        Me.cboContactDepartment.FormattingEnabled = True
        Me.cboContactDepartment.Location = New System.Drawing.Point(28, 48)
        Me.cboContactDepartment.Name = "cboContactDepartment"
        Me.cboContactDepartment.Size = New System.Drawing.Size(330, 21)
        Me.cboContactDepartment.TabIndex = 44
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(28, 303)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(96, 20)
        Me.Label39.TabIndex = 36
        Me.Label39.Text = "Email Address"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtContactPhone
        '
        Me.txtContactPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContactPhone.Location = New System.Drawing.Point(124, 241)
        Me.txtContactPhone.Name = "txtContactPhone"
        Me.txtContactPhone.Size = New System.Drawing.Size(234, 20)
        Me.txtContactPhone.TabIndex = 46
        Me.txtContactPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtContactEmail
        '
        Me.txtContactEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContactEmail.Location = New System.Drawing.Point(28, 326)
        Me.txtContactEmail.MaxLength = 200
        Me.txtContactEmail.Multiline = True
        Me.txtContactEmail.Name = "txtContactEmail"
        Me.txtContactEmail.Size = New System.Drawing.Size(330, 120)
        Me.txtContactEmail.TabIndex = 48
        Me.txtContactEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtContactName
        '
        Me.txtContactName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContactName.Location = New System.Drawing.Point(28, 147)
        Me.txtContactName.MaxLength = 50
        Me.txtContactName.Multiline = True
        Me.txtContactName.Name = "txtContactName"
        Me.txtContactName.Size = New System.Drawing.Size(330, 68)
        Me.txtContactName.TabIndex = 45
        Me.txtContactName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtContactFax
        '
        Me.txtContactFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactFax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContactFax.Location = New System.Drawing.Point(124, 273)
        Me.txtContactFax.Name = "txtContactFax"
        Me.txtContactFax.Size = New System.Drawing.Size(234, 20)
        Me.txtContactFax.TabIndex = 47
        Me.txtContactFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(28, 241)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Phone Number"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabContactTabControl
        '
        Me.tabContactTabControl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabContactTabControl.Controls.Add(Me.tabMainContact)
        Me.tabContactTabControl.Controls.Add(Me.tabAdditionalContacts)
        Me.tabContactTabControl.Controls.Add(Me.tabContactListing)
        Me.tabContactTabControl.Controls.Add(Me.tabEmailContacts)
        Me.tabContactTabControl.Location = New System.Drawing.Point(741, 27)
        Me.tabContactTabControl.Name = "tabContactTabControl"
        Me.tabContactTabControl.SelectedIndex = 0
        Me.tabContactTabControl.Size = New System.Drawing.Size(401, 688)
        Me.tabContactTabControl.TabIndex = 44
        '
        'tabContactListing
        '
        Me.tabContactListing.Controls.Add(Me.Label72)
        Me.tabContactListing.Controls.Add(Me.cmdCCDelete)
        Me.tabContactListing.Controls.Add(Me.dgvCustomerContacts)
        Me.tabContactListing.Location = New System.Drawing.Point(4, 22)
        Me.tabContactListing.Name = "tabContactListing"
        Me.tabContactListing.Size = New System.Drawing.Size(393, 662)
        Me.tabContactListing.TabIndex = 3
        Me.tabContactListing.Text = "Contact List"
        Me.tabContactListing.UseVisualStyleBackColor = True
        '
        'Label72
        '
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.ForeColor = System.Drawing.Color.Blue
        Me.Label72.Location = New System.Drawing.Point(72, 629)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(115, 28)
        Me.Label72.TabIndex = 38
        Me.Label72.Text = "Select in grid to delete"
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCCDelete
        '
        Me.cmdCCDelete.Location = New System.Drawing.Point(11, 629)
        Me.cmdCCDelete.Name = "cmdCCDelete"
        Me.cmdCCDelete.Size = New System.Drawing.Size(55, 28)
        Me.cmdCCDelete.TabIndex = 24
        Me.cmdCCDelete.Text = "Delete"
        Me.cmdCCDelete.UseVisualStyleBackColor = True
        '
        'dgvCustomerContacts
        '
        Me.dgvCustomerContacts.AllowUserToAddRows = False
        Me.dgvCustomerContacts.AllowUserToDeleteRows = False
        Me.dgvCustomerContacts.AllowUserToOrderColumns = True
        Me.dgvCustomerContacts.AutoGenerateColumns = False
        Me.dgvCustomerContacts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgvCustomerContacts.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvCustomerContacts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCustomerContacts.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCustomerContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCustomerContacts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ContactDepartmentColumn, Me.ContactNameColumn, Me.ContactPhoneColumn, Me.ContactFaxColumn, Me.ContactEmailColumn, Me.CustomerIDColumn, Me.DivisionIDColumn})
        Me.dgvCustomerContacts.DataSource = Me.CustomerContactsBindingSource
        Me.dgvCustomerContacts.Location = New System.Drawing.Point(5, 7)
        Me.dgvCustomerContacts.Name = "dgvCustomerContacts"
        Me.dgvCustomerContacts.Size = New System.Drawing.Size(371, 609)
        Me.dgvCustomerContacts.TabIndex = 0
        '
        'ContactDepartmentColumn
        '
        Me.ContactDepartmentColumn.DataPropertyName = "ContactDepartment"
        Me.ContactDepartmentColumn.HeaderText = "Dpt."
        Me.ContactDepartmentColumn.Name = "ContactDepartmentColumn"
        Me.ContactDepartmentColumn.ReadOnly = True
        Me.ContactDepartmentColumn.Width = 60
        '
        'ContactNameColumn
        '
        Me.ContactNameColumn.DataPropertyName = "ContactName"
        Me.ContactNameColumn.HeaderText = "Name"
        Me.ContactNameColumn.Name = "ContactNameColumn"
        Me.ContactNameColumn.Width = 90
        '
        'ContactPhoneColumn
        '
        Me.ContactPhoneColumn.DataPropertyName = "ContactPhone"
        Me.ContactPhoneColumn.HeaderText = "Phone"
        Me.ContactPhoneColumn.Name = "ContactPhoneColumn"
        Me.ContactPhoneColumn.Width = 90
        '
        'ContactFaxColumn
        '
        Me.ContactFaxColumn.DataPropertyName = "ContactFax"
        Me.ContactFaxColumn.HeaderText = "Fax"
        Me.ContactFaxColumn.Name = "ContactFaxColumn"
        Me.ContactFaxColumn.Width = 80
        '
        'ContactEmailColumn
        '
        Me.ContactEmailColumn.DataPropertyName = "ContactEmail"
        Me.ContactEmailColumn.HeaderText = "Email"
        Me.ContactEmailColumn.Name = "ContactEmailColumn"
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "CustomerID"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'tabEmailContacts
        '
        Me.tabEmailContacts.Controls.Add(Me.Label56)
        Me.tabEmailContacts.Controls.Add(Me.txtInvoiceCertEmail)
        Me.tabEmailContacts.Controls.Add(Me.Label57)
        Me.tabEmailContacts.Controls.Add(Me.txtInvoiceEmail)
        Me.tabEmailContacts.Controls.Add(Me.Label77)
        Me.tabEmailContacts.Controls.Add(Me.txtEmailPackingLists)
        Me.tabEmailContacts.Controls.Add(Me.Label76)
        Me.tabEmailContacts.Controls.Add(Me.Label75)
        Me.tabEmailContacts.Controls.Add(Me.txtEmailStatements)
        Me.tabEmailContacts.Controls.Add(Me.Label74)
        Me.tabEmailContacts.Controls.Add(Me.txtEmailCerts)
        Me.tabEmailContacts.Controls.Add(Me.Label73)
        Me.tabEmailContacts.Controls.Add(Me.txtEmailConfirmations)
        Me.tabEmailContacts.Location = New System.Drawing.Point(4, 22)
        Me.tabEmailContacts.Name = "tabEmailContacts"
        Me.tabEmailContacts.Size = New System.Drawing.Size(393, 662)
        Me.tabEmailContacts.TabIndex = 4
        Me.tabEmailContacts.Text = "Email"
        Me.tabEmailContacts.UseVisualStyleBackColor = True
        '
        'Label56
        '
        Me.Label56.Location = New System.Drawing.Point(11, 549)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(365, 20)
        Me.Label56.TabIndex = 74
        Me.Label56.Text = "Invoice Cert Email Address (Auto-email on Batch Processing)"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInvoiceCertEmail
        '
        Me.txtInvoiceCertEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceCertEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceCertEmail.Location = New System.Drawing.Point(11, 571)
        Me.txtInvoiceCertEmail.MaxLength = 500
        Me.txtInvoiceCertEmail.Multiline = True
        Me.txtInvoiceCertEmail.Name = "txtInvoiceCertEmail"
        Me.txtInvoiceCertEmail.Size = New System.Drawing.Size(365, 70)
        Me.txtInvoiceCertEmail.TabIndex = 6
        Me.txtInvoiceCertEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label57
        '
        Me.Label57.Location = New System.Drawing.Point(11, 449)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(365, 20)
        Me.Label57.TabIndex = 72
        Me.Label57.Text = "Invoice Email (Auto-email on Batch Processing)"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInvoiceEmail
        '
        Me.txtInvoiceEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceEmail.Location = New System.Drawing.Point(11, 471)
        Me.txtInvoiceEmail.MaxLength = 500
        Me.txtInvoiceEmail.Multiline = True
        Me.txtInvoiceEmail.Name = "txtInvoiceEmail"
        Me.txtInvoiceEmail.Size = New System.Drawing.Size(365, 70)
        Me.txtInvoiceEmail.TabIndex = 5
        Me.txtInvoiceEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label77
        '
        Me.Label77.Location = New System.Drawing.Point(11, 249)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(365, 20)
        Me.Label77.TabIndex = 64
        Me.Label77.Text = "Email Packing Slips (Auto-email on Complete Shipment)"
        Me.Label77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmailPackingLists
        '
        Me.txtEmailPackingLists.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmailPackingLists.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmailPackingLists.Location = New System.Drawing.Point(11, 271)
        Me.txtEmailPackingLists.MaxLength = 500
        Me.txtEmailPackingLists.Multiline = True
        Me.txtEmailPackingLists.Name = "txtEmailPackingLists"
        Me.txtEmailPackingLists.Size = New System.Drawing.Size(365, 70)
        Me.txtEmailPackingLists.TabIndex = 3
        Me.txtEmailPackingLists.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label76
        '
        Me.Label76.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.ForeColor = System.Drawing.Color.Blue
        Me.Label76.Location = New System.Drawing.Point(11, 9)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(340, 37)
        Me.Label76.TabIndex = 62
        Me.Label76.Text = "These addresses will auto-fill the various print forms when you use email functio" & _
            "n. "
        Me.Label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label75
        '
        Me.Label75.Location = New System.Drawing.Point(11, 349)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(365, 20)
        Me.Label75.TabIndex = 61
        Me.Label75.Text = "Email Statements (Auto-email on EOM routine)"
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmailStatements
        '
        Me.txtEmailStatements.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmailStatements.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmailStatements.Location = New System.Drawing.Point(11, 371)
        Me.txtEmailStatements.MaxLength = 500
        Me.txtEmailStatements.Multiline = True
        Me.txtEmailStatements.Name = "txtEmailStatements"
        Me.txtEmailStatements.Size = New System.Drawing.Size(365, 70)
        Me.txtEmailStatements.TabIndex = 4
        Me.txtEmailStatements.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label74
        '
        Me.Label74.Location = New System.Drawing.Point(11, 149)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(365, 20)
        Me.Label74.TabIndex = 59
        Me.Label74.Text = "Email Certs (Auto-email on Complete Shipment)"
        Me.Label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmailCerts
        '
        Me.txtEmailCerts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmailCerts.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmailCerts.Location = New System.Drawing.Point(11, 171)
        Me.txtEmailCerts.MaxLength = 500
        Me.txtEmailCerts.Multiline = True
        Me.txtEmailCerts.Name = "txtEmailCerts"
        Me.txtEmailCerts.Size = New System.Drawing.Size(365, 70)
        Me.txtEmailCerts.TabIndex = 2
        Me.txtEmailCerts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label73
        '
        Me.Label73.Location = New System.Drawing.Point(11, 49)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(365, 20)
        Me.Label73.TabIndex = 57
        Me.Label73.Text = "Email Sales Confirmations (Auto-email on Expedite SO)"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmailConfirmations
        '
        Me.txtEmailConfirmations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmailConfirmations.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmailConfirmations.Location = New System.Drawing.Point(11, 71)
        Me.txtEmailConfirmations.MaxLength = 500
        Me.txtEmailConfirmations.Multiline = True
        Me.txtEmailConfirmations.Name = "txtEmailConfirmations"
        Me.txtEmailConfirmations.Size = New System.Drawing.Size(365, 70)
        Me.txtEmailConfirmations.TabIndex = 1
        Me.txtEmailConfirmations.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tabMiscCustomerData
        '
        Me.tabMiscCustomerData.Controls.Add(Me.tabMiscData)
        Me.tabMiscCustomerData.Controls.Add(Me.tabTaxData)
        Me.tabMiscCustomerData.Controls.Add(Me.tabPricing)
        Me.tabMiscCustomerData.Location = New System.Drawing.Point(29, 384)
        Me.tabMiscCustomerData.Name = "tabMiscCustomerData"
        Me.tabMiscCustomerData.SelectedIndex = 0
        Me.tabMiscCustomerData.Size = New System.Drawing.Size(332, 427)
        Me.tabMiscCustomerData.TabIndex = 7
        '
        'tabMiscData
        '
        Me.tabMiscData.Controls.Add(Me.Label70)
        Me.tabMiscData.Controls.Add(Me.txtShippingAccount)
        Me.tabMiscData.Controls.Add(Me.Label66)
        Me.tabMiscData.Controls.Add(Me.txtSalesTerritory)
        Me.tabMiscData.Controls.Add(Me.cboSalesTerritory)
        Me.tabMiscData.Controls.Add(Me.chkAccountingHold)
        Me.tabMiscData.Controls.Add(Me.cboPaymentTerms)
        Me.tabMiscData.Controls.Add(Me.cboShipper)
        Me.tabMiscData.Controls.Add(Me.chkCreditHold)
        Me.tabMiscData.Controls.Add(Me.Label27)
        Me.tabMiscData.Controls.Add(Me.txtShippingInstructions)
        Me.tabMiscData.Controls.Add(Me.Label4)
        Me.tabMiscData.Controls.Add(Me.Label49)
        Me.tabMiscData.Controls.Add(Me.Label40)
        Me.tabMiscData.Controls.Add(Me.Label26)
        Me.tabMiscData.Controls.Add(Me.txtCreditLimit)
        Me.tabMiscData.Controls.Add(Me.Label38)
        Me.tabMiscData.Controls.Add(Me.Label81)
        Me.tabMiscData.Location = New System.Drawing.Point(4, 22)
        Me.tabMiscData.Name = "tabMiscData"
        Me.tabMiscData.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMiscData.Size = New System.Drawing.Size(324, 401)
        Me.tabMiscData.TabIndex = 0
        Me.tabMiscData.Text = "Misc. Customer Data"
        Me.tabMiscData.UseVisualStyleBackColor = True
        '
        'Label70
        '
        Me.Label70.ForeColor = System.Drawing.Color.Blue
        Me.Label70.Location = New System.Drawing.Point(58, 224)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(238, 20)
        Me.Label70.TabIndex = 71
        Me.Label70.Text = "Will auto-load in Orders for UPS/FEDEX only"
        Me.Label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShippingAccount
        '
        Me.txtShippingAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShippingAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShippingAccount.Location = New System.Drawing.Point(114, 201)
        Me.txtShippingAccount.Name = "txtShippingAccount"
        Me.txtShippingAccount.Size = New System.Drawing.Size(201, 20)
        Me.txtShippingAccount.TabIndex = 13
        Me.txtShippingAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label66
        '
        Me.Label66.Location = New System.Drawing.Point(16, 199)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(104, 20)
        Me.Label66.TabIndex = 69
        Me.Label66.Text = "Ship. Account #"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesTerritory
        '
        Me.txtSalesTerritory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTerritory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesTerritory.Location = New System.Drawing.Point(114, 133)
        Me.txtSalesTerritory.Name = "txtSalesTerritory"
        Me.txtSalesTerritory.Size = New System.Drawing.Size(201, 20)
        Me.txtSalesTerritory.TabIndex = 11
        Me.txtSalesTerritory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboSalesTerritory
        '
        Me.cboSalesTerritory.DataSource = Me.SalesTerritoryQueryBindingSource
        Me.cboSalesTerritory.DisplayMember = "TerritoryDescription"
        Me.cboSalesTerritory.FormattingEnabled = True
        Me.cboSalesTerritory.Location = New System.Drawing.Point(114, 134)
        Me.cboSalesTerritory.Name = "cboSalesTerritory"
        Me.cboSalesTerritory.Size = New System.Drawing.Size(201, 21)
        Me.cboSalesTerritory.TabIndex = 10
        Me.cboSalesTerritory.Visible = False
        '
        'SalesTerritoryQueryBindingSource
        '
        Me.SalesTerritoryQueryBindingSource.DataMember = "SalesTerritoryQuery"
        Me.SalesTerritoryQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'chkAccountingHold
        '
        Me.chkAccountingHold.AutoSize = True
        Me.chkAccountingHold.Enabled = False
        Me.chkAccountingHold.Location = New System.Drawing.Point(110, 39)
        Me.chkAccountingHold.Name = "chkAccountingHold"
        Me.chkAccountingHold.Size = New System.Drawing.Size(48, 17)
        Me.chkAccountingHold.TabIndex = 8
        Me.chkAccountingHold.TabStop = False
        Me.chkAccountingHold.Text = "Hold"
        Me.chkAccountingHold.UseVisualStyleBackColor = True
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(15, 36)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(104, 20)
        Me.Label38.TabIndex = 52
        Me.Label38.Text = "Accounting Hold"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label81
        '
        Me.Label81.Location = New System.Drawing.Point(15, 13)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(104, 20)
        Me.Label81.TabIndex = 7
        Me.Label81.Text = "Credit Hold"
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabTaxData
        '
        Me.tabTaxData.Controls.Add(Me.lblTaxExempt)
        Me.tabTaxData.Controls.Add(Me.cmdViewTaxExemptForm)
        Me.tabTaxData.Controls.Add(Me.cboSalesTaxStatus)
        Me.tabTaxData.Controls.Add(Me.Label80)
        Me.tabTaxData.Controls.Add(Me.chkAddHST)
        Me.tabTaxData.Controls.Add(Me.chkAddPST)
        Me.tabTaxData.Controls.Add(Me.chkAddGST)
        Me.tabTaxData.Controls.Add(Me.Label8)
        Me.tabTaxData.Controls.Add(Me.LabelTax4)
        Me.tabTaxData.Controls.Add(Me.LabelTax2)
        Me.tabTaxData.Controls.Add(Me.txtSalesTaxRate2)
        Me.tabTaxData.Controls.Add(Me.LabelTax3)
        Me.tabTaxData.Controls.Add(Me.txtSalesTaxRate3)
        Me.tabTaxData.Controls.Add(Me.Label59)
        Me.tabTaxData.Controls.Add(Me.txtTaxID)
        Me.tabTaxData.Controls.Add(Me.LabelTax1)
        Me.tabTaxData.Controls.Add(Me.txtSalesTaxRate)
        Me.tabTaxData.Location = New System.Drawing.Point(4, 22)
        Me.tabTaxData.Name = "tabTaxData"
        Me.tabTaxData.Padding = New System.Windows.Forms.Padding(3)
        Me.tabTaxData.Size = New System.Drawing.Size(324, 401)
        Me.tabTaxData.TabIndex = 1
        Me.tabTaxData.Text = "Sales Tax Data"
        Me.tabTaxData.UseVisualStyleBackColor = True
        '
        'lblTaxExempt
        '
        Me.lblTaxExempt.ForeColor = System.Drawing.Color.Blue
        Me.lblTaxExempt.Location = New System.Drawing.Point(18, 359)
        Me.lblTaxExempt.Name = "lblTaxExempt"
        Me.lblTaxExempt.Size = New System.Drawing.Size(169, 29)
        Me.lblTaxExempt.TabIndex = 58
        Me.lblTaxExempt.Text = "Customer has a tax exempt certificate on file."
        Me.lblTaxExempt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewTaxExemptForm
        '
        Me.cmdViewTaxExemptForm.Location = New System.Drawing.Point(239, 359)
        Me.cmdViewTaxExemptForm.Name = "cmdViewTaxExemptForm"
        Me.cmdViewTaxExemptForm.Size = New System.Drawing.Size(75, 29)
        Me.cmdViewTaxExemptForm.TabIndex = 57
        Me.cmdViewTaxExemptForm.Text = "Tax Exempt"
        Me.cmdViewTaxExemptForm.UseVisualStyleBackColor = True
        '
        'cboSalesTaxStatus
        '
        Me.cboSalesTaxStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesTaxStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesTaxStatus.FormattingEnabled = True
        Me.cboSalesTaxStatus.Items.AddRange(New Object() {"TAXABLE", "EXEMPT", "OUT-OF-STATE"})
        Me.cboSalesTaxStatus.Location = New System.Drawing.Point(18, 320)
        Me.cboSalesTaxStatus.Name = "cboSalesTaxStatus"
        Me.cboSalesTaxStatus.Size = New System.Drawing.Size(301, 21)
        Me.cboSalesTaxStatus.TabIndex = 56
        '
        'Label80
        '
        Me.Label80.Location = New System.Drawing.Point(18, 295)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(104, 20)
        Me.Label80.TabIndex = 55
        Me.Label80.Text = "Sales Tax Status"
        Me.Label80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkAddHST
        '
        Me.chkAddHST.AutoSize = True
        Me.chkAddHST.Location = New System.Drawing.Point(152, 101)
        Me.chkAddHST.Name = "chkAddHST"
        Me.chkAddHST.Size = New System.Drawing.Size(45, 17)
        Me.chkAddHST.TabIndex = 54
        Me.chkAddHST.Text = "Add"
        Me.chkAddHST.UseVisualStyleBackColor = True
        '
        'chkAddPST
        '
        Me.chkAddPST.AutoSize = True
        Me.chkAddPST.Location = New System.Drawing.Point(152, 74)
        Me.chkAddPST.Name = "chkAddPST"
        Me.chkAddPST.Size = New System.Drawing.Size(45, 17)
        Me.chkAddPST.TabIndex = 53
        Me.chkAddPST.Text = "Add"
        Me.chkAddPST.UseVisualStyleBackColor = True
        '
        'chkAddGST
        '
        Me.chkAddGST.AutoSize = True
        Me.chkAddGST.Location = New System.Drawing.Point(152, 47)
        Me.chkAddGST.Name = "chkAddGST"
        Me.chkAddGST.Size = New System.Drawing.Size(45, 17)
        Me.chkAddGST.TabIndex = 52
        Me.chkAddGST.Text = "Add"
        Me.chkAddGST.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(17, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(294, 20)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Enter tax rates as a decimal (i.e. .085 = 8-1/2%)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelTax4
        '
        Me.LabelTax4.ForeColor = System.Drawing.Color.Blue
        Me.LabelTax4.Location = New System.Drawing.Point(17, 127)
        Me.LabelTax4.Name = "LabelTax4"
        Me.LabelTax4.Size = New System.Drawing.Size(297, 42)
        Me.LabelTax4.TabIndex = 49
        Me.LabelTax4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelTax2
        '
        Me.LabelTax2.Location = New System.Drawing.Point(17, 71)
        Me.LabelTax2.Name = "LabelTax2"
        Me.LabelTax2.Size = New System.Drawing.Size(144, 20)
        Me.LabelTax2.TabIndex = 48
        Me.LabelTax2.Text = "Sales Tax Rate 2 / PST"
        Me.LabelTax2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesTaxRate2
        '
        Me.txtSalesTaxRate2.BackColor = System.Drawing.Color.White
        Me.txtSalesTaxRate2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTaxRate2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesTaxRate2.Location = New System.Drawing.Point(212, 71)
        Me.txtSalesTaxRate2.Name = "txtSalesTaxRate2"
        Me.txtSalesTaxRate2.Size = New System.Drawing.Size(99, 20)
        Me.txtSalesTaxRate2.TabIndex = 14
        Me.txtSalesTaxRate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelTax3
        '
        Me.LabelTax3.Location = New System.Drawing.Point(17, 98)
        Me.LabelTax3.Name = "LabelTax3"
        Me.LabelTax3.Size = New System.Drawing.Size(144, 20)
        Me.LabelTax3.TabIndex = 46
        Me.LabelTax3.Text = "Sales Tax Rate 3 / HST"
        Me.LabelTax3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesTaxRate3
        '
        Me.txtSalesTaxRate3.BackColor = System.Drawing.Color.White
        Me.txtSalesTaxRate3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTaxRate3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesTaxRate3.Location = New System.Drawing.Point(212, 98)
        Me.txtSalesTaxRate3.Name = "txtSalesTaxRate3"
        Me.txtSalesTaxRate3.Size = New System.Drawing.Size(99, 20)
        Me.txtSalesTaxRate3.TabIndex = 15
        Me.txtSalesTaxRate3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label59
        '
        Me.Label59.Location = New System.Drawing.Point(17, 174)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(104, 20)
        Me.Label59.TabIndex = 44
        Me.Label59.Text = "Tax ID "
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTaxID
        '
        Me.txtTaxID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaxID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTaxID.Location = New System.Drawing.Point(17, 196)
        Me.txtTaxID.Multiline = True
        Me.txtTaxID.Name = "txtTaxID"
        Me.txtTaxID.Size = New System.Drawing.Size(300, 73)
        Me.txtTaxID.TabIndex = 16
        Me.txtTaxID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tabPricing
        '
        Me.tabPricing.Controls.Add(Me.cboBankAccount)
        Me.tabPricing.Controls.Add(Me.Label71)
        Me.tabPricing.Controls.Add(Me.Label64)
        Me.tabPricing.Controls.Add(Me.cboBillingType)
        Me.tabPricing.Controls.Add(Me.Label63)
        Me.tabPricing.Controls.Add(Me.Label60)
        Me.tabPricing.Controls.Add(Me.txtPricingReview)
        Me.tabPricing.Location = New System.Drawing.Point(4, 22)
        Me.tabPricing.Name = "tabPricing"
        Me.tabPricing.Size = New System.Drawing.Size(324, 401)
        Me.tabPricing.TabIndex = 2
        Me.tabPricing.Text = "Pricing Review"
        Me.tabPricing.UseVisualStyleBackColor = True
        '
        'cboBankAccount
        '
        Me.cboBankAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBankAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBankAccount.Enabled = False
        Me.cboBankAccount.FormattingEnabled = True
        Me.cboBankAccount.Items.AddRange(New Object() {"Cash Receipts", "Checking", "Other", "Canadian Checking"})
        Me.cboBankAccount.Location = New System.Drawing.Point(95, 313)
        Me.cboBankAccount.Name = "cboBankAccount"
        Me.cboBankAccount.Size = New System.Drawing.Size(219, 21)
        Me.cboBankAccount.TabIndex = 40
        '
        'Label71
        '
        Me.Label71.Location = New System.Drawing.Point(14, 314)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(86, 20)
        Me.Label71.TabIndex = 39
        Me.Label71.Text = "Bank Account"
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label64
        '
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.ForeColor = System.Drawing.Color.Blue
        Me.Label64.Location = New System.Drawing.Point(15, 214)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(300, 49)
        Me.Label64.TabIndex = 38
        Me.Label64.Text = "Billing Type is used to track serial #'s for equipment. Select 'STANDARD' for all" & _
            " normal customers."
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBillingType
        '
        Me.cboBillingType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBillingType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBillingType.FormattingEnabled = True
        Me.cboBillingType.Items.AddRange(New Object() {"ATL", "CBS", "CGO", "CHT", "DEN", "SLC", "TFF", "TFT", "TFP", "TWE", "TWD", "TOR", "BCW", "DCW", "HCW", "LCW", "PCW", "SCW", "YCW", "SRL", "STANDARD"})
        Me.cboBillingType.Location = New System.Drawing.Point(95, 271)
        Me.cboBillingType.Name = "cboBillingType"
        Me.cboBillingType.Size = New System.Drawing.Size(219, 21)
        Me.cboBillingType.TabIndex = 29
        '
        'Label63
        '
        Me.Label63.Location = New System.Drawing.Point(14, 272)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(64, 20)
        Me.Label63.TabIndex = 28
        Me.Label63.Text = "Billing Type"
        Me.Label63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label60
        '
        Me.Label60.Location = New System.Drawing.Point(15, 12)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(300, 20)
        Me.Label60.TabIndex = 27
        Me.Label60.Text = "Management Pricing Review"
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPricingReview
        '
        Me.txtPricingReview.BackColor = System.Drawing.Color.White
        Me.txtPricingReview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPricingReview.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPricingReview.Location = New System.Drawing.Point(15, 35)
        Me.txtPricingReview.Multiline = True
        Me.txtPricingReview.Name = "txtPricingReview"
        Me.txtPricingReview.Size = New System.Drawing.Size(301, 160)
        Me.txtPricingReview.TabIndex = 7
        Me.txtPricingReview.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdViewSalesTotals
        '
        Me.cmdViewSalesTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewSalesTotals.Location = New System.Drawing.Point(822, 725)
        Me.cmdViewSalesTotals.Name = "cmdViewSalesTotals"
        Me.cmdViewSalesTotals.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewSalesTotals.TabIndex = 66
        Me.cmdViewSalesTotals.Text = "View Sales Totals"
        Me.cmdViewSalesTotals.UseVisualStyleBackColor = True
        '
        'SalesTerritoryQueryTableAdapter
        '
        Me.SalesTerritoryQueryTableAdapter.ClearBeforeFill = True
        '
        'cmdViewFoxes
        '
        Me.cmdViewFoxes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewFoxes.Location = New System.Drawing.Point(741, 772)
        Me.cmdViewFoxes.Name = "cmdViewFoxes"
        Me.cmdViewFoxes.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewFoxes.TabIndex = 67
        Me.cmdViewFoxes.Text = "View FOXES"
        Me.cmdViewFoxes.UseVisualStyleBackColor = True
        Me.cmdViewFoxes.Visible = False
        '
        'CountryCodesTableAdapter
        '
        Me.CountryCodesTableAdapter.ClearBeforeFill = True
        '
        'cmdCreditApp
        '
        Me.cmdCreditApp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCreditApp.Location = New System.Drawing.Point(742, 726)
        Me.cmdCreditApp.Name = "cmdCreditApp"
        Me.cmdCreditApp.Size = New System.Drawing.Size(71, 40)
        Me.cmdCreditApp.TabIndex = 68
        Me.cmdCreditApp.Text = "Credit App"
        Me.cmdCreditApp.UseVisualStyleBackColor = True
        '
        'lblHoldBanner
        '
        Me.lblHoldBanner.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoldBanner.ForeColor = System.Drawing.Color.Red
        Me.lblHoldBanner.Location = New System.Drawing.Point(310, 1)
        Me.lblHoldBanner.Name = "lblHoldBanner"
        Me.lblHoldBanner.Size = New System.Drawing.Size(732, 23)
        Me.lblHoldBanner.TabIndex = 69
        Me.lblHoldBanner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCustomerPriceSheet
        '
        Me.cmdCustomerPriceSheet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCustomerPriceSheet.Location = New System.Drawing.Point(640, 772)
        Me.cmdCustomerPriceSheet.Name = "cmdCustomerPriceSheet"
        Me.cmdCustomerPriceSheet.Size = New System.Drawing.Size(71, 40)
        Me.cmdCustomerPriceSheet.TabIndex = 70
        Me.cmdCustomerPriceSheet.Text = "Customer Price Sheet"
        Me.cmdCustomerPriceSheet.UseVisualStyleBackColor = True
        '
        'cmdUploadPriceSheet
        '
        Me.cmdUploadPriceSheet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUploadPriceSheet.Location = New System.Drawing.Point(563, 772)
        Me.cmdUploadPriceSheet.Name = "cmdUploadPriceSheet"
        Me.cmdUploadPriceSheet.Size = New System.Drawing.Size(71, 40)
        Me.cmdUploadPriceSheet.TabIndex = 71
        Me.cmdUploadPriceSheet.Text = "Upload Price Sheet"
        Me.cmdUploadPriceSheet.UseVisualStyleBackColor = True
        '
        'ofdPriceSheet
        '
        Me.ofdPriceSheet.FileName = "Select File"
        Me.ofdPriceSheet.Filter = "PDF Files|*.pdf|All Files|*.*"
        '
        'cmdCustomerCreditForm
        '
        Me.cmdCustomerCreditForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCustomerCreditForm.Location = New System.Drawing.Point(454, 772)
        Me.cmdCustomerCreditForm.Name = "cmdCustomerCreditForm"
        Me.cmdCustomerCreditForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdCustomerCreditForm.TabIndex = 72
        Me.cmdCustomerCreditForm.Text = "Credit Report"
        Me.cmdCustomerCreditForm.UseVisualStyleBackColor = True
        '
        'CustomerData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdCustomerCreditForm)
        Me.Controls.Add(Me.cmdUploadPriceSheet)
        Me.Controls.Add(Me.cmdCustomerPriceSheet)
        Me.Controls.Add(Me.lblHoldBanner)
        Me.Controls.Add(Me.cmdCreditApp)
        Me.Controls.Add(Me.cmdViewFoxes)
        Me.Controls.Add(Me.cmdViewSalesTotals)
        Me.Controls.Add(Me.tabMiscCustomerData)
        Me.Controls.Add(Me.tabContactTabControl)
        Me.Controls.Add(Me.tcAddress)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdCustomerStatement)
        Me.Controls.Add(Me.cmdSalesHistory)
        Me.Controls.Add(Me.cmdOpenOrders)
        Me.Controls.Add(Me.gpxCreditBilling)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.grpCustomerInfo)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "CustomerData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Data"
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.grpCustomerInfo.ResumeLayout(False)
        Me.grpCustomerInfo.PerformLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StateTableBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxCreditBilling.ResumeLayout(False)
        Me.gpxCustomerSnapshot.ResumeLayout(False)
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcAddress.ResumeLayout(False)
        Me.BillingAddress.ResumeLayout(False)
        Me.BillingAddress.PerformLayout()
        CType(Me.CountryCodesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ShippingAddress.ResumeLayout(False)
        Me.ShippingAddress.PerformLayout()
        CType(Me.StateTableBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AddShipTo.ResumeLayout(False)
        Me.AddShipTo.PerformLayout()
        CType(Me.AdditionalShipToBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerContactsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMainContact.ResumeLayout(False)
        Me.tabMainContact.PerformLayout()
        Me.tabAdditionalContacts.ResumeLayout(False)
        Me.tabAdditionalContacts.PerformLayout()
        Me.tabContactTabControl.ResumeLayout(False)
        Me.tabContactListing.ResumeLayout(False)
        CType(Me.dgvCustomerContacts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEmailContacts.ResumeLayout(False)
        Me.tabEmailContacts.PerformLayout()
        Me.tabMiscCustomerData.ResumeLayout(False)
        Me.tabMiscData.ResumeLayout(False)
        Me.tabMiscData.PerformLayout()
        CType(Me.SalesTerritoryQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTaxData.ResumeLayout(False)
        Me.tabTaxData.PerformLayout()
        Me.tabPricing.ResumeLayout(False)
        Me.tabPricing.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpCustomerInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerComment As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents gpxCreditBilling As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents chkCreditHold As System.Windows.Forms.CheckBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents gpxCustomerSnapshot As System.Windows.Forms.GroupBox
    Friend WithEvents CustomerOrderHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerAccountDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdOpenOrders As System.Windows.Forms.Button
    Friend WithEvents cmdSalesHistory As System.Windows.Forms.Button
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cboPaymentTerms As System.Windows.Forms.ComboBox
    Friend WithEvents AgedReceivablesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerSalesAnalysisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerStatementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cboBTState As System.Windows.Forms.ComboBox
    Friend WithEvents txtBTAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtBTCountry As System.Windows.Forms.TextBox
    Friend WithEvents txtBTZip As System.Windows.Forms.TextBox
    Friend WithEvents txtBTCity As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBTAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents cmdCopyToShippingAddress As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmdClearBilling As System.Windows.Forms.Button
    Friend WithEvents lblLastActivityDate As System.Windows.Forms.Label
    Friend WithEvents lblAverageOrder As System.Windows.Forms.Label
    Friend WithEvents lblYTDSales As System.Windows.Forms.Label
    Friend WithEvents lblMTDSales As System.Windows.Forms.Label
    Friend WithEvents lblCreditMT90 As System.Windows.Forms.Label
    Friend WithEvents lblCreditLT90 As System.Windows.Forms.Label
    Friend WithEvents lblCreditLT60 As System.Windows.Forms.Label
    Friend WithEvents lblCreditLT30 As System.Windows.Forms.Label
    Friend WithEvents lblCreditBalance As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents lblCreditLimit As System.Windows.Forms.Label
    Friend WithEvents cmdCustomerStatement As System.Windows.Forms.Button
    Friend WithEvents LabelTax1 As System.Windows.Forms.Label
    Friend WithEvents txtSalesTaxRate As System.Windows.Forms.TextBox
    Friend WithEvents txtCreditLimit As System.Windows.Forms.TextBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents cboShipper As System.Windows.Forms.ComboBox
    Friend WithEvents txtOldCustomerNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents tcAddress As System.Windows.Forms.TabControl
    Friend WithEvents BillingAddress As System.Windows.Forms.TabPage
    Friend WithEvents ShippingAddress As System.Windows.Forms.TabPage
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtSTAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtSTAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtSTCity As System.Windows.Forms.TextBox
    Friend WithEvents cboSTState As System.Windows.Forms.ComboBox
    Friend WithEvents txtSTZip As System.Windows.Forms.TextBox
    Friend WithEvents txtSTCountry As System.Windows.Forms.TextBox
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents AddShipTo As System.Windows.Forms.TabPage
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents cmdSaveAdditionalShipTo As System.Windows.Forms.Button
    Friend WithEvents cmdClearAdditionalShipTo As System.Windows.Forms.Button
    Friend WithEvents cboShipToID As System.Windows.Forms.ComboBox
    Friend WithEvents txtAddCountry As System.Windows.Forms.TextBox
    Friend WithEvents txtAddZip As System.Windows.Forms.TextBox
    Friend WithEvents txtAddCity As System.Windows.Forms.TextBox
    Friend WithEvents txtAddAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents cboAddState As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClearDefaultShipping As System.Windows.Forms.Button
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ShipMethodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipMethodTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
    Friend WithEvents CustomerContactsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerContactsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerContactsTableAdapter
    Friend WithEvents AdditionalShipToBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AdditionalShipToTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AdditionalShipToTableAdapter
    Friend WithEvents StateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StateTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
    Friend WithEvents StateTableBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents StateTableBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerClass As System.Windows.Forms.ComboBox
    Friend WithEvents CustomerClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerClassTableAdapter
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents SaveCustomerDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteCustomerDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintCustomerDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearCustomerDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents txtAddShipToName As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents lblCreditLT45 As System.Windows.Forms.Label
    Friend WithEvents CustomerAccountDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerOrdersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtShippingInstructions As System.Windows.Forms.TextBox
    Friend WithEvents CustomerNotesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrintLabel As System.Windows.Forms.Button
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents tabMainContact As System.Windows.Forms.TabPage
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txtAPPhoneNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtAPEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtAPFaxNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents tabAdditionalContacts As System.Windows.Forms.TabPage
    Friend WithEvents cmdDeleteContact As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdAddContact As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cmdClearContact As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboContactDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtContactPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtContactEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtContactName As System.Windows.Forms.TextBox
    Friend WithEvents txtContactFax As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tabContactTabControl As System.Windows.Forms.TabControl
    Friend WithEvents txtAPContactName As System.Windows.Forms.TextBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteAddShipTo As System.Windows.Forms.Button
    Friend WithEvents tabMiscCustomerData As System.Windows.Forms.TabControl
    Friend WithEvents tabMiscData As System.Windows.Forms.TabPage
    Friend WithEvents tabTaxData As System.Windows.Forms.TabPage
    Friend WithEvents LabelTax2 As System.Windows.Forms.Label
    Friend WithEvents txtSalesTaxRate2 As System.Windows.Forms.TextBox
    Friend WithEvents LabelTax3 As System.Windows.Forms.Label
    Friend WithEvents txtSalesTaxRate3 As System.Windows.Forms.TextBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents txtTaxID As System.Windows.Forms.TextBox
    Friend WithEvents LabelTax4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tabContactListing As System.Windows.Forms.TabPage
    Friend WithEvents dgvCustomerContacts As System.Windows.Forms.DataGridView
    Friend WithEvents chkAddHST As System.Windows.Forms.CheckBox
    Friend WithEvents chkAddPST As System.Windows.Forms.CheckBox
    Friend WithEvents chkAddGST As System.Windows.Forms.CheckBox
    Friend WithEvents chkAccountingHold As System.Windows.Forms.CheckBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lblAVGDaysToPay As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents BackorderReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdViewSalesTotals As System.Windows.Forms.Button
    Friend WithEvents tabPricing As System.Windows.Forms.TabPage
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents txtPricingReview As System.Windows.Forms.TextBox
    Friend WithEvents cboSalesTerritory As System.Windows.Forms.ComboBox
    Friend WithEvents SalesTerritoryQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesTerritoryQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesTerritoryQueryTableAdapter
    Friend WithEvents txtSalesTerritory As System.Windows.Forms.TextBox
    Friend WithEvents cmdViewFoxes As System.Windows.Forms.Button
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents cboBillingType As System.Windows.Forms.ComboBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents txtShippingAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents cboCountryList As System.Windows.Forms.ComboBox
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents CountryCodesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CountryCodesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CountryCodesTableAdapter
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents cboShipToCountry As System.Windows.Forms.ComboBox
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents cboAddShipToCountry As System.Windows.Forms.ComboBox
    Friend WithEvents cmdCreditApp As System.Windows.Forms.Button
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents cboBankAccount As System.Windows.Forms.ComboBox
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents cmdCCDelete As System.Windows.Forms.Button
    Friend WithEvents lblContactDepartment As System.Windows.Forms.Label
    Friend WithEvents CustomerHoldReportAutoprintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CRReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXMonthEndCustomerReport1 As MOS09Program.CRXMonthEndCustomerReport
    Friend WithEvents tabEmailContacts As System.Windows.Forms.TabPage
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents txtEmailStatements As System.Windows.Forms.TextBox
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents txtEmailCerts As System.Windows.Forms.TextBox
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents txtEmailConfirmations As System.Windows.Forms.TextBox
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents ContactDepartmentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactPhoneColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactFaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactEmailColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents txtEmailPackingLists As System.Windows.Forms.TextBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents txtSalesContactEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblHoldBanner As System.Windows.Forms.Label
    Friend WithEvents dtpCustomerSince As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboSalesTaxStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents lblTaxExempt As System.Windows.Forms.Label
    Friend WithEvents cmdViewTaxExemptForm As System.Windows.Forms.Button
    Friend WithEvents cmdCustomerPriceSheet As System.Windows.Forms.Button
    Friend WithEvents cmdUploadPriceSheet As System.Windows.Forms.Button
    Friend WithEvents ofdPriceSheet As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents cmdCustomerCreditForm As System.Windows.Forms.Button
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceCertEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents txtShipEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label65 As System.Windows.Forms.Label
End Class
