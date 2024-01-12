<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewCustomerListing
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintCustomerListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewTWDCLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewTWECLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintCustomersAddressesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintCustomerPhoneListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomerInactivityReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.gpxInventorySPL = New System.Windows.Forms.GroupBox
        Me.cboPaymentTerms = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtBegins = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtNewDivision = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdAddCustomerToDivision = New System.Windows.Forms.Button
        Me.chkAR30 = New System.Windows.Forms.CheckBox
        Me.chkAR60 = New System.Windows.Forms.CheckBox
        Me.chkAR90 = New System.Windows.Forms.CheckBox
        Me.chkAR90Plus = New System.Windows.Forms.CheckBox
        Me.chkAR45 = New System.Windows.Forms.CheckBox
        Me.chkBTState = New System.Windows.Forms.CheckBox
        Me.chkSTState = New System.Windows.Forms.CheckBox
        Me.txtZipCode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboState = New System.Windows.Forms.ComboBox
        Me.StateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.CustomerListWithAgingQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.chkAccountingHold = New System.Windows.Forms.CheckBox
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.cboSalesTerritory = New System.Windows.Forms.ComboBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkViewByHold = New System.Windows.Forms.CheckBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboCustomerClass = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdOpenCustomerForm = New System.Windows.Forms.Button
        Me.cmdPrintCustomerStatement = New System.Windows.Forms.Button
        Me.cmdPrintPhoneList = New System.Windows.Forms.Button
        Me.cmdPrintAddresses = New System.Windows.Forms.Button
        Me.dgvCustomerList = New System.Windows.Forms.DataGridView
        Me.cmdARReport = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CustomerListWithAgingQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListWithAgingQueryTableAdapter
        Me.StateTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
        Me.cmdPrintAddShipTo = New System.Windows.Forms.Button
        Me.cmdAutoEmailStatements = New System.Windows.Forms.Button
        Me.CRStatementViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXCustStatement1 = New MOS09Program.CRXCustStatement
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APContactNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APPhoneNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APFAXNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APEmailAddressColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesContactEmailColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceEmailColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceCertEmailColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToAddress1Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToAddress2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToCityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToStateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToZipColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToCountryColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BillToAddress1Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BillToAddress2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BillToCityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BillToStateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BillToZipColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BillToCountryColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTerritoryColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentsAppliedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceAmountOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AgingLessThan30Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Aging31To45Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Aging46To60Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Aging61To90Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AgingMoreThan90Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OnHoldStatusColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.AccountingHoldColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConfirmationEmailColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PackingListEmailColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatementEmailColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipEmail = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CertEmailColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditLimitColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTermsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OldCustomerNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PreferredShipperColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingDetailsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxStatusColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.SalesTaxIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxRateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxRate2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxRate3Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BankAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        Me.gpxInventorySPL.SuspendLayout()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListWithAgingQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCustomerList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1060, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 36
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintCustomerListToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'PrintCustomerListToolStripMenuItem
        '
        Me.PrintCustomerListToolStripMenuItem.Name = "PrintCustomerListToolStripMenuItem"
        Me.PrintCustomerListToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.PrintCustomerListToolStripMenuItem.Text = "Print Customer List"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewTWDCLToolStripMenuItem, Me.ViewTWECLToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ViewTWDCLToolStripMenuItem
        '
        Me.ViewTWDCLToolStripMenuItem.Name = "ViewTWDCLToolStripMenuItem"
        Me.ViewTWDCLToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.ViewTWDCLToolStripMenuItem.Text = "View TWD CL"
        '
        'ViewTWECLToolStripMenuItem
        '
        Me.ViewTWECLToolStripMenuItem.Name = "ViewTWECLToolStripMenuItem"
        Me.ViewTWECLToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.ViewTWECLToolStripMenuItem.Text = "View TWE CL"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintCustomersAddressesToolStripMenuItem, Me.PrintCustomerPhoneListToolStripMenuItem, Me.CustomerInactivityReportToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintCustomersAddressesToolStripMenuItem
        '
        Me.PrintCustomersAddressesToolStripMenuItem.Name = "PrintCustomersAddressesToolStripMenuItem"
        Me.PrintCustomersAddressesToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.PrintCustomersAddressesToolStripMenuItem.Text = "Print Customer Addresses"
        '
        'PrintCustomerPhoneListToolStripMenuItem
        '
        Me.PrintCustomerPhoneListToolStripMenuItem.Name = "PrintCustomerPhoneListToolStripMenuItem"
        Me.PrintCustomerPhoneListToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.PrintCustomerPhoneListToolStripMenuItem.Text = "Print Customer Phone List"
        '
        'CustomerInactivityReportToolStripMenuItem
        '
        Me.CustomerInactivityReportToolStripMenuItem.Name = "CustomerInactivityReportToolStripMenuItem"
        Me.CustomerInactivityReportToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.CustomerInactivityReportToolStripMenuItem.Text = "Customer Inactivity Report"
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
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(984, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 35
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'gpxInventorySPL
        '
        Me.gpxInventorySPL.Controls.Add(Me.cboPaymentTerms)
        Me.gpxInventorySPL.Controls.Add(Me.Label14)
        Me.gpxInventorySPL.Controls.Add(Me.chkDateRange)
        Me.gpxInventorySPL.Controls.Add(Me.dtpEndDate)
        Me.gpxInventorySPL.Controls.Add(Me.Label3)
        Me.gpxInventorySPL.Controls.Add(Me.dtpBeginDate)
        Me.gpxInventorySPL.Controls.Add(Me.Label13)
        Me.gpxInventorySPL.Controls.Add(Me.txtBegins)
        Me.gpxInventorySPL.Controls.Add(Me.Label11)
        Me.gpxInventorySPL.Controls.Add(Me.Label10)
        Me.gpxInventorySPL.Controls.Add(Me.txtNewDivision)
        Me.gpxInventorySPL.Controls.Add(Me.Label9)
        Me.gpxInventorySPL.Controls.Add(Me.txtSearch)
        Me.gpxInventorySPL.Controls.Add(Me.Label7)
        Me.gpxInventorySPL.Controls.Add(Me.cmdAddCustomerToDivision)
        Me.gpxInventorySPL.Controls.Add(Me.chkAR30)
        Me.gpxInventorySPL.Controls.Add(Me.chkAR60)
        Me.gpxInventorySPL.Controls.Add(Me.chkAR90)
        Me.gpxInventorySPL.Controls.Add(Me.chkAR90Plus)
        Me.gpxInventorySPL.Controls.Add(Me.chkAR45)
        Me.gpxInventorySPL.Controls.Add(Me.chkBTState)
        Me.gpxInventorySPL.Controls.Add(Me.chkSTState)
        Me.gpxInventorySPL.Controls.Add(Me.txtZipCode)
        Me.gpxInventorySPL.Controls.Add(Me.Label2)
        Me.gpxInventorySPL.Controls.Add(Me.cboState)
        Me.gpxInventorySPL.Controls.Add(Me.Label1)
        Me.gpxInventorySPL.Controls.Add(Me.Label12)
        Me.gpxInventorySPL.Controls.Add(Me.cboCustomerID)
        Me.gpxInventorySPL.Controls.Add(Me.chkAccountingHold)
        Me.gpxInventorySPL.Controls.Add(Me.cboCustomerName)
        Me.gpxInventorySPL.Controls.Add(Me.cboSalesTerritory)
        Me.gpxInventorySPL.Controls.Add(Me.cboDivisionID)
        Me.gpxInventorySPL.Controls.Add(Me.Label5)
        Me.gpxInventorySPL.Controls.Add(Me.chkViewByHold)
        Me.gpxInventorySPL.Controls.Add(Me.cmdClear)
        Me.gpxInventorySPL.Controls.Add(Me.Label6)
        Me.gpxInventorySPL.Controls.Add(Me.Label4)
        Me.gpxInventorySPL.Controls.Add(Me.cboCustomerClass)
        Me.gpxInventorySPL.Controls.Add(Me.Label8)
        Me.gpxInventorySPL.Controls.Add(Me.cmdView)
        Me.gpxInventorySPL.Location = New System.Drawing.Point(29, 41)
        Me.gpxInventorySPL.Name = "gpxInventorySPL"
        Me.gpxInventorySPL.Size = New System.Drawing.Size(300, 770)
        Me.gpxInventorySPL.TabIndex = 0
        Me.gpxInventorySPL.TabStop = False
        Me.gpxInventorySPL.Text = "View By Filter"
        '
        'cboPaymentTerms
        '
        Me.cboPaymentTerms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPaymentTerms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentTerms.DropDownWidth = 250
        Me.cboPaymentTerms.FormattingEnabled = True
        Me.cboPaymentTerms.Items.AddRange(New Object() {"N30", "COD", "CREDIT CARD", "PREPAID", "NETDUE"})
        Me.cboPaymentTerms.Location = New System.Drawing.Point(99, 375)
        Me.cboPaymentTerms.Name = "cboPaymentTerms"
        Me.cboPaymentTerms.Size = New System.Drawing.Size(186, 21)
        Me.cboPaymentTerms.TabIndex = 12
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(20, 376)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 20)
        Me.Label14.TabIndex = 71
        Me.Label14.Text = "Pmt. Terms"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(110, 632)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 22
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(110, 696)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(175, 20)
        Me.dtpEndDate.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 696)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "End Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(110, 663)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(175, 20)
        Me.dtpBeginDate.TabIndex = 23
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(17, 663)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 20)
        Me.Label13.TabIndex = 66
        Me.Label13.Text = "Begin Date"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBegins
        '
        Me.txtBegins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBegins.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBegins.Location = New System.Drawing.Point(99, 343)
        Me.txtBegins.Name = "txtBegins"
        Me.txtBegins.Size = New System.Drawing.Size(186, 20)
        Me.txtBegins.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(20, 341)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 65
        Me.Label11.Text = "Begins with;"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(22, 449)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 20)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "Division"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNewDivision
        '
        Me.txtNewDivision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNewDivision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNewDivision.Location = New System.Drawing.Point(98, 449)
        Me.txtNewDivision.Name = "txtNewDivision"
        Me.txtNewDivision.Size = New System.Drawing.Size(107, 20)
        Me.txtNewDivision.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(18, 408)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(267, 31)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "Add existing customer to another division (select in datagrid)"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearch.Location = New System.Drawing.Point(99, 311)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(186, 20)
        Me.txtSearch.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(20, 310)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "Text Search"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAddCustomerToDivision
        '
        Me.cmdAddCustomerToDivision.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddCustomerToDivision.Location = New System.Drawing.Point(214, 444)
        Me.cmdAddCustomerToDivision.Name = "cmdAddCustomerToDivision"
        Me.cmdAddCustomerToDivision.Size = New System.Drawing.Size(71, 30)
        Me.cmdAddCustomerToDivision.TabIndex = 14
        Me.cmdAddCustomerToDivision.Text = "Add"
        Me.cmdAddCustomerToDivision.UseVisualStyleBackColor = True
        '
        'chkAR30
        '
        Me.chkAR30.AutoSize = True
        Me.chkAR30.Location = New System.Drawing.Point(19, 491)
        Me.chkAR30.Name = "chkAR30"
        Me.chkAR30.Size = New System.Drawing.Size(97, 17)
        Me.chkAR30.TabIndex = 15
        Me.chkAR30.Text = "A/R < 30 Days"
        Me.chkAR30.UseVisualStyleBackColor = True
        '
        'chkAR60
        '
        Me.chkAR60.AutoSize = True
        Me.chkAR60.Location = New System.Drawing.Point(19, 543)
        Me.chkAR60.Name = "chkAR60"
        Me.chkAR60.Size = New System.Drawing.Size(115, 17)
        Me.chkAR60.TabIndex = 17
        Me.chkAR60.Text = "A/R 45 to 60 Days"
        Me.chkAR60.UseVisualStyleBackColor = True
        '
        'chkAR90
        '
        Me.chkAR90.AutoSize = True
        Me.chkAR90.Location = New System.Drawing.Point(170, 491)
        Me.chkAR90.Name = "chkAR90"
        Me.chkAR90.Size = New System.Drawing.Size(115, 17)
        Me.chkAR90.TabIndex = 18
        Me.chkAR90.Text = "A/R 61 to 90 Days"
        Me.chkAR90.UseVisualStyleBackColor = True
        '
        'chkAR90Plus
        '
        Me.chkAR90Plus.AutoSize = True
        Me.chkAR90Plus.Location = New System.Drawing.Point(171, 520)
        Me.chkAR90Plus.Name = "chkAR90Plus"
        Me.chkAR90Plus.Size = New System.Drawing.Size(114, 17)
        Me.chkAR90Plus.TabIndex = 19
        Me.chkAR90Plus.Text = "A/R Over 90 Days"
        Me.chkAR90Plus.UseVisualStyleBackColor = True
        '
        'chkAR45
        '
        Me.chkAR45.AutoSize = True
        Me.chkAR45.Location = New System.Drawing.Point(19, 517)
        Me.chkAR45.Name = "chkAR45"
        Me.chkAR45.Size = New System.Drawing.Size(115, 17)
        Me.chkAR45.TabIndex = 16
        Me.chkAR45.Text = "A/R 31 to 45 Days"
        Me.chkAR45.UseVisualStyleBackColor = True
        '
        'chkBTState
        '
        Me.chkBTState.AutoSize = True
        Me.chkBTState.Location = New System.Drawing.Point(126, 256)
        Me.chkBTState.Name = "chkBTState"
        Me.chkBTState.Size = New System.Drawing.Size(55, 17)
        Me.chkBTState.TabIndex = 7
        Me.chkBTState.Text = "Bill To"
        Me.chkBTState.UseVisualStyleBackColor = True
        '
        'chkSTState
        '
        Me.chkSTState.AutoSize = True
        Me.chkSTState.Location = New System.Drawing.Point(198, 256)
        Me.chkSTState.Name = "chkSTState"
        Me.chkSTState.Size = New System.Drawing.Size(63, 17)
        Me.chkSTState.TabIndex = 8
        Me.chkSTState.Text = "Ship To"
        Me.chkSTState.UseVisualStyleBackColor = True
        '
        'txtZipCode
        '
        Me.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtZipCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtZipCode.Location = New System.Drawing.Point(99, 279)
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.Size = New System.Drawing.Size(186, 20)
        Me.txtZipCode.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 279)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Zip Code"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboState
        '
        Me.cboState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboState.DataSource = Me.StateTableBindingSource
        Me.cboState.DisplayMember = "StateCode"
        Me.cboState.DropDownWidth = 250
        Me.cboState.FormattingEnabled = True
        Me.cboState.Location = New System.Drawing.Point(121, 229)
        Me.cboState.Name = "cboState"
        Me.cboState.Size = New System.Drawing.Size(164, 21)
        Me.cboState.TabIndex = 6
        '
        'StateTableBindingSource
        '
        Me.StateTableBindingSource.DataMember = "StateTable"
        Me.StateTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 230)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "State"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(15, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(270, 36)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListWithAgingQueryBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.DropDownWidth = 250
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(94, 97)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(191, 21)
        Me.cboCustomerID.TabIndex = 2
        '
        'CustomerListWithAgingQueryBindingSource
        '
        Me.CustomerListWithAgingQueryBindingSource.DataMember = "CustomerListWithAgingQuery"
        Me.CustomerListWithAgingQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'chkAccountingHold
        '
        Me.chkAccountingHold.AutoSize = True
        Me.chkAccountingHold.Location = New System.Drawing.Point(20, 595)
        Me.chkAccountingHold.Name = "chkAccountingHold"
        Me.chkAccountingHold.Size = New System.Drawing.Size(209, 17)
        Me.chkAccountingHold.TabIndex = 21
        Me.chkAccountingHold.Text = "View Customers on Accounting  HOLD"
        Me.chkAccountingHold.UseVisualStyleBackColor = True
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListWithAgingQueryBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.DropDownWidth = 300
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(18, 128)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(267, 21)
        Me.cboCustomerName.TabIndex = 3
        '
        'cboSalesTerritory
        '
        Me.cboSalesTerritory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesTerritory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesTerritory.DataSource = Me.CustomerListWithAgingQueryBindingSource
        Me.cboSalesTerritory.DisplayMember = "SalesTerritory"
        Me.cboSalesTerritory.DropDownWidth = 250
        Me.cboSalesTerritory.FormattingEnabled = True
        Me.cboSalesTerritory.Location = New System.Drawing.Point(95, 165)
        Me.cboSalesTerritory.Name = "cboSalesTerritory"
        Me.cboSalesTerritory.Size = New System.Drawing.Size(190, 21)
        Me.cboSalesTerritory.TabIndex = 4
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(94, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(191, 21)
        Me.cboDivisionID.TabIndex = 1
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Customer ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkViewByHold
        '
        Me.chkViewByHold.AutoSize = True
        Me.chkViewByHold.Location = New System.Drawing.Point(20, 572)
        Me.chkViewByHold.Name = "chkViewByHold"
        Me.chkViewByHold.Size = New System.Drawing.Size(179, 17)
        Me.chkViewByHold.TabIndex = 20
        Me.chkViewByHold.Text = "View Customers on Credit HOLD"
        Me.chkViewByHold.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 730)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 27
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(20, 166)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Sales Territory"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Division ID"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerClass
        '
        Me.cboCustomerClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerClass.DataSource = Me.CustomerListWithAgingQueryBindingSource
        Me.cboCustomerClass.DisplayMember = "CustomerClass"
        Me.cboCustomerClass.DropDownWidth = 250
        Me.cboCustomerClass.FormattingEnabled = True
        Me.cboCustomerClass.Location = New System.Drawing.Point(94, 197)
        Me.cboCustomerClass.Name = "cboCustomerClass"
        Me.cboCustomerClass.Size = New System.Drawing.Size(191, 21)
        Me.cboCustomerClass.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(20, 198)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Cust. Class"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(140, 730)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 25
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdOpenCustomerForm
        '
        Me.cmdOpenCustomerForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenCustomerForm.Location = New System.Drawing.Point(452, 771)
        Me.cmdOpenCustomerForm.Name = "cmdOpenCustomerForm"
        Me.cmdOpenCustomerForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenCustomerForm.TabIndex = 28
        Me.cmdOpenCustomerForm.Text = "Customer Form"
        Me.cmdOpenCustomerForm.UseVisualStyleBackColor = True
        '
        'cmdPrintCustomerStatement
        '
        Me.cmdPrintCustomerStatement.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintCustomerStatement.Location = New System.Drawing.Point(528, 771)
        Me.cmdPrintCustomerStatement.Name = "cmdPrintCustomerStatement"
        Me.cmdPrintCustomerStatement.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintCustomerStatement.TabIndex = 29
        Me.cmdPrintCustomerStatement.Text = "Customer Statement"
        Me.cmdPrintCustomerStatement.UseVisualStyleBackColor = True
        '
        'cmdPrintPhoneList
        '
        Me.cmdPrintPhoneList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintPhoneList.Location = New System.Drawing.Point(680, 771)
        Me.cmdPrintPhoneList.Name = "cmdPrintPhoneList"
        Me.cmdPrintPhoneList.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintPhoneList.TabIndex = 31
        Me.cmdPrintPhoneList.Text = "Print Phone List"
        Me.cmdPrintPhoneList.UseVisualStyleBackColor = True
        '
        'cmdPrintAddresses
        '
        Me.cmdPrintAddresses.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintAddresses.Location = New System.Drawing.Point(756, 771)
        Me.cmdPrintAddresses.Name = "cmdPrintAddresses"
        Me.cmdPrintAddresses.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintAddresses.TabIndex = 32
        Me.cmdPrintAddresses.Text = "Address Book"
        Me.cmdPrintAddresses.UseVisualStyleBackColor = True
        '
        'dgvCustomerList
        '
        Me.dgvCustomerList.AllowUserToAddRows = False
        Me.dgvCustomerList.AllowUserToDeleteRows = False
        Me.dgvCustomerList.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCustomerList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCustomerList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCustomerList.AutoGenerateColumns = False
        Me.dgvCustomerList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvCustomerList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCustomerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCustomerList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.CustomerNameColumn, Me.APContactNameColumn, Me.APPhoneNumberColumn, Me.APFAXNumberColumn, Me.APEmailAddressColumn, Me.SalesContactEmailColumn, Me.InvoiceEmailColumn, Me.InvoiceCertEmailColumn, Me.CustomerIDColumn, Me.CommentsColumn, Me.ShipToAddress1Column, Me.ShipToAddress2Column, Me.ShipToCityColumn, Me.ShipToStateColumn, Me.ShipToZipColumn, Me.ShipToCountryColumn, Me.BillToAddress1Column, Me.BillToAddress2Column, Me.BillToCityColumn, Me.BillToStateColumn, Me.BillToZipColumn, Me.BillToCountryColumn, Me.SalesTerritoryColumn, Me.InvoiceTotalColumn, Me.PaymentsAppliedColumn, Me.InvoiceAmountOpenColumn, Me.AgingLessThan30Column, Me.Aging31To45Column, Me.Aging46To60Column, Me.Aging61To90Column, Me.AgingMoreThan90Column, Me.OnHoldStatusColumn, Me.AccountingHoldColumn, Me.ConfirmationEmailColumn, Me.PackingListEmailColumn, Me.StatementEmailColumn, Me.ShipEmail, Me.CertEmailColumn, Me.CreditLimitColumn, Me.CustomerClassColumn, Me.PaymentTermsColumn, Me.OldCustomerNumberColumn, Me.PreferredShipperColumn, Me.ShippingDetailsColumn, Me.SalesTaxStatusColumn, Me.SalesTaxIDColumn, Me.SalesTaxRateColumn, Me.SalesTaxRate2Column, Me.SalesTaxRate3Column, Me.ShippingAccountColumn, Me.BankAccountColumn, Me.CustomerDateColumn})
        Me.dgvCustomerList.DataSource = Me.CustomerListWithAgingQueryBindingSource
        Me.dgvCustomerList.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvCustomerList.Location = New System.Drawing.Point(350, 41)
        Me.dgvCustomerList.Name = "dgvCustomerList"
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCustomerList.RowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvCustomerList.Size = New System.Drawing.Size(778, 716)
        Me.dgvCustomerList.TabIndex = 27
        Me.dgvCustomerList.TabStop = False
        '
        'cmdARReport
        '
        Me.cmdARReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdARReport.Location = New System.Drawing.Point(832, 771)
        Me.cmdARReport.Name = "cmdARReport"
        Me.cmdARReport.Size = New System.Drawing.Size(71, 40)
        Me.cmdARReport.TabIndex = 33
        Me.cmdARReport.Text = "Customer A/R Report"
        Me.cmdARReport.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerListWithAgingQueryTableAdapter
        '
        Me.CustomerListWithAgingQueryTableAdapter.ClearBeforeFill = True
        '
        'StateTableTableAdapter
        '
        Me.StateTableTableAdapter.ClearBeforeFill = True
        '
        'cmdPrintAddShipTo
        '
        Me.cmdPrintAddShipTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintAddShipTo.Location = New System.Drawing.Point(908, 771)
        Me.cmdPrintAddShipTo.Name = "cmdPrintAddShipTo"
        Me.cmdPrintAddShipTo.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintAddShipTo.TabIndex = 34
        Me.cmdPrintAddShipTo.Text = "Print Ship To's"
        Me.cmdPrintAddShipTo.UseVisualStyleBackColor = True
        '
        'cmdAutoEmailStatements
        '
        Me.cmdAutoEmailStatements.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAutoEmailStatements.Location = New System.Drawing.Point(604, 771)
        Me.cmdAutoEmailStatements.Name = "cmdAutoEmailStatements"
        Me.cmdAutoEmailStatements.Size = New System.Drawing.Size(71, 40)
        Me.cmdAutoEmailStatements.TabIndex = 30
        Me.cmdAutoEmailStatements.Text = "Auto-Email Statements"
        Me.cmdAutoEmailStatements.UseVisualStyleBackColor = True
        '
        'CRStatementViewer
        '
        Me.CRStatementViewer.ActiveViewIndex = 0
        Me.CRStatementViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRStatementViewer.Location = New System.Drawing.Point(516, 320)
        Me.CRStatementViewer.Name = "CRStatementViewer"
        Me.CRStatementViewer.ReportSource = Me.CRXCustStatement1
        Me.CRStatementViewer.Size = New System.Drawing.Size(150, 150)
        Me.CRStatementViewer.TabIndex = 66
        Me.CRStatementViewer.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'CustomerNameColumn
        '
        Me.CustomerNameColumn.DataPropertyName = "CustomerName"
        Me.CustomerNameColumn.HeaderText = "Name"
        Me.CustomerNameColumn.Name = "CustomerNameColumn"
        Me.CustomerNameColumn.Width = 170
        '
        'APContactNameColumn
        '
        Me.APContactNameColumn.DataPropertyName = "APContactName"
        Me.APContactNameColumn.HeaderText = "Contact Name"
        Me.APContactNameColumn.Name = "APContactNameColumn"
        '
        'APPhoneNumberColumn
        '
        Me.APPhoneNumberColumn.DataPropertyName = "APPhoneNumber"
        Me.APPhoneNumberColumn.HeaderText = "Phone #"
        Me.APPhoneNumberColumn.Name = "APPhoneNumberColumn"
        '
        'APFAXNumberColumn
        '
        Me.APFAXNumberColumn.DataPropertyName = "APFAXNumber"
        Me.APFAXNumberColumn.HeaderText = "FAX #"
        Me.APFAXNumberColumn.Name = "APFAXNumberColumn"
        '
        'APEmailAddressColumn
        '
        Me.APEmailAddressColumn.DataPropertyName = "APEmailAddress"
        Me.APEmailAddressColumn.HeaderText = "Email Address"
        Me.APEmailAddressColumn.Name = "APEmailAddressColumn"
        '
        'SalesContactEmailColumn
        '
        Me.SalesContactEmailColumn.DataPropertyName = "SalesContactEmail"
        Me.SalesContactEmailColumn.HeaderText = "Sales Contact"
        Me.SalesContactEmailColumn.Name = "SalesContactEmailColumn"
        '
        'InvoiceEmailColumn
        '
        Me.InvoiceEmailColumn.DataPropertyName = "InvoiceEmail"
        Me.InvoiceEmailColumn.HeaderText = "Invoice Email"
        Me.InvoiceEmailColumn.Name = "InvoiceEmailColumn"
        '
        'InvoiceCertEmailColumn
        '
        Me.InvoiceCertEmailColumn.DataPropertyName = "InvoiceCertEmail"
        Me.InvoiceCertEmailColumn.HeaderText = "Invoice Cert Email"
        Me.InvoiceCertEmailColumn.Name = "InvoiceCertEmailColumn"
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer ID"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'CommentsColumn
        '
        Me.CommentsColumn.DataPropertyName = "Comments"
        Me.CommentsColumn.HeaderText = "Comments"
        Me.CommentsColumn.Name = "CommentsColumn"
        '
        'ShipToAddress1Column
        '
        Me.ShipToAddress1Column.DataPropertyName = "ShipToAddress1"
        Me.ShipToAddress1Column.HeaderText = "Ship Address1"
        Me.ShipToAddress1Column.Name = "ShipToAddress1Column"
        '
        'ShipToAddress2Column
        '
        Me.ShipToAddress2Column.DataPropertyName = "ShipToAddress2"
        Me.ShipToAddress2Column.HeaderText = "Ship Address2"
        Me.ShipToAddress2Column.Name = "ShipToAddress2Column"
        '
        'ShipToCityColumn
        '
        Me.ShipToCityColumn.DataPropertyName = "ShipToCity"
        Me.ShipToCityColumn.HeaderText = "Ship City"
        Me.ShipToCityColumn.Name = "ShipToCityColumn"
        '
        'ShipToStateColumn
        '
        Me.ShipToStateColumn.DataPropertyName = "ShipToState"
        Me.ShipToStateColumn.HeaderText = "Ship State"
        Me.ShipToStateColumn.Name = "ShipToStateColumn"
        '
        'ShipToZipColumn
        '
        Me.ShipToZipColumn.DataPropertyName = "ShipToZip"
        Me.ShipToZipColumn.HeaderText = "Ship Zip"
        Me.ShipToZipColumn.Name = "ShipToZipColumn"
        '
        'ShipToCountryColumn
        '
        Me.ShipToCountryColumn.DataPropertyName = "ShipToCountry"
        Me.ShipToCountryColumn.HeaderText = "Ship Country"
        Me.ShipToCountryColumn.Name = "ShipToCountryColumn"
        '
        'BillToAddress1Column
        '
        Me.BillToAddress1Column.DataPropertyName = "BillToAddress1"
        Me.BillToAddress1Column.HeaderText = "Bill Address1"
        Me.BillToAddress1Column.Name = "BillToAddress1Column"
        '
        'BillToAddress2Column
        '
        Me.BillToAddress2Column.DataPropertyName = "BillToAddress2"
        Me.BillToAddress2Column.HeaderText = "Bill Address2"
        Me.BillToAddress2Column.Name = "BillToAddress2Column"
        '
        'BillToCityColumn
        '
        Me.BillToCityColumn.DataPropertyName = "BillToCity"
        Me.BillToCityColumn.HeaderText = "Bill City"
        Me.BillToCityColumn.Name = "BillToCityColumn"
        '
        'BillToStateColumn
        '
        Me.BillToStateColumn.DataPropertyName = "BillToState"
        Me.BillToStateColumn.HeaderText = "Bill State"
        Me.BillToStateColumn.Name = "BillToStateColumn"
        '
        'BillToZipColumn
        '
        Me.BillToZipColumn.DataPropertyName = "BillToZip"
        Me.BillToZipColumn.HeaderText = "Bill Zip"
        Me.BillToZipColumn.Name = "BillToZipColumn"
        '
        'BillToCountryColumn
        '
        Me.BillToCountryColumn.DataPropertyName = "BillToCountry"
        Me.BillToCountryColumn.HeaderText = "Bill Country"
        Me.BillToCountryColumn.Name = "BillToCountryColumn"
        '
        'SalesTerritoryColumn
        '
        Me.SalesTerritoryColumn.DataPropertyName = "SalesTerritory"
        Me.SalesTerritoryColumn.HeaderText = "Sales Territory"
        Me.SalesTerritoryColumn.Name = "SalesTerritoryColumn"
        '
        'InvoiceTotalColumn
        '
        Me.InvoiceTotalColumn.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.InvoiceTotalColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.InvoiceTotalColumn.HeaderText = "Tot. Invoiced"
        Me.InvoiceTotalColumn.Name = "InvoiceTotalColumn"
        Me.InvoiceTotalColumn.ReadOnly = True
        '
        'PaymentsAppliedColumn
        '
        Me.PaymentsAppliedColumn.DataPropertyName = "PaymentsApplied"
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.PaymentsAppliedColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.PaymentsAppliedColumn.HeaderText = "Total Payments"
        Me.PaymentsAppliedColumn.Name = "PaymentsAppliedColumn"
        Me.PaymentsAppliedColumn.ReadOnly = True
        '
        'InvoiceAmountOpenColumn
        '
        Me.InvoiceAmountOpenColumn.DataPropertyName = "InvoiceAmountOpen"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.InvoiceAmountOpenColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.InvoiceAmountOpenColumn.HeaderText = "Total Open"
        Me.InvoiceAmountOpenColumn.Name = "InvoiceAmountOpenColumn"
        Me.InvoiceAmountOpenColumn.ReadOnly = True
        '
        'AgingLessThan30Column
        '
        Me.AgingLessThan30Column.DataPropertyName = "AgingLessThan30"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.AgingLessThan30Column.DefaultCellStyle = DataGridViewCellStyle5
        Me.AgingLessThan30Column.HeaderText = "< 30"
        Me.AgingLessThan30Column.Name = "AgingLessThan30Column"
        Me.AgingLessThan30Column.ReadOnly = True
        '
        'Aging31To45Column
        '
        Me.Aging31To45Column.DataPropertyName = "Aging31To45"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.Aging31To45Column.DefaultCellStyle = DataGridViewCellStyle6
        Me.Aging31To45Column.HeaderText = "31 To 45"
        Me.Aging31To45Column.Name = "Aging31To45Column"
        Me.Aging31To45Column.ReadOnly = True
        '
        'Aging46To60Column
        '
        Me.Aging46To60Column.DataPropertyName = "Aging46To60"
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.Aging46To60Column.DefaultCellStyle = DataGridViewCellStyle7
        Me.Aging46To60Column.HeaderText = "46 To 60"
        Me.Aging46To60Column.Name = "Aging46To60Column"
        Me.Aging46To60Column.ReadOnly = True
        '
        'Aging61To90Column
        '
        Me.Aging61To90Column.DataPropertyName = "Aging61To90"
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = "0"
        Me.Aging61To90Column.DefaultCellStyle = DataGridViewCellStyle8
        Me.Aging61To90Column.HeaderText = "61 To 90"
        Me.Aging61To90Column.Name = "Aging61To90Column"
        Me.Aging61To90Column.ReadOnly = True
        '
        'AgingMoreThan90Column
        '
        Me.AgingMoreThan90Column.DataPropertyName = "AgingMoreThan90"
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = "0"
        Me.AgingMoreThan90Column.DefaultCellStyle = DataGridViewCellStyle9
        Me.AgingMoreThan90Column.HeaderText = "> 90"
        Me.AgingMoreThan90Column.Name = "AgingMoreThan90Column"
        Me.AgingMoreThan90Column.ReadOnly = True
        '
        'OnHoldStatusColumn
        '
        Me.OnHoldStatusColumn.DataPropertyName = "OnHoldStatus"
        Me.OnHoldStatusColumn.FalseValue = "NO"
        Me.OnHoldStatusColumn.HeaderText = "Credit Hold"
        Me.OnHoldStatusColumn.IndeterminateValue = "NO"
        Me.OnHoldStatusColumn.Name = "OnHoldStatusColumn"
        Me.OnHoldStatusColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OnHoldStatusColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.OnHoldStatusColumn.TrueValue = "YES"
        '
        'AccountingHoldColumn
        '
        Me.AccountingHoldColumn.DataPropertyName = "AccountingHold"
        Me.AccountingHoldColumn.HeaderText = "Accounting Hold"
        Me.AccountingHoldColumn.Name = "AccountingHoldColumn"
        Me.AccountingHoldColumn.ReadOnly = True
        '
        'ConfirmationEmailColumn
        '
        Me.ConfirmationEmailColumn.DataPropertyName = "ConfirmationEmail"
        Me.ConfirmationEmailColumn.HeaderText = "Confirmation Email"
        Me.ConfirmationEmailColumn.Name = "ConfirmationEmailColumn"
        '
        'PackingListEmailColumn
        '
        Me.PackingListEmailColumn.DataPropertyName = "PackingListEmail"
        Me.PackingListEmailColumn.HeaderText = "Packing List Email"
        Me.PackingListEmailColumn.Name = "PackingListEmailColumn"
        '
        'StatementEmailColumn
        '
        Me.StatementEmailColumn.DataPropertyName = "StatementEmail"
        Me.StatementEmailColumn.HeaderText = "Statement Email"
        Me.StatementEmailColumn.Name = "StatementEmailColumn"
        '
        'ShipEmail
        '
        Me.ShipEmail.DataPropertyName = "ShipEmailColumn"
        Me.ShipEmail.HeaderText = "Ship Email"
        Me.ShipEmail.Name = "ShipEmail"
        '
        'CertEmailColumn
        '
        Me.CertEmailColumn.DataPropertyName = "CertEmail"
        Me.CertEmailColumn.HeaderText = "Cert Email"
        Me.CertEmailColumn.Name = "CertEmailColumn"
        '
        'CreditLimitColumn
        '
        Me.CreditLimitColumn.DataPropertyName = "CreditLimit"
        Me.CreditLimitColumn.HeaderText = "Credit Limit"
        Me.CreditLimitColumn.Name = "CreditLimitColumn"
        '
        'CustomerClassColumn
        '
        Me.CustomerClassColumn.DataPropertyName = "CustomerClass"
        Me.CustomerClassColumn.HeaderText = "Customer Class"
        Me.CustomerClassColumn.Name = "CustomerClassColumn"
        Me.CustomerClassColumn.ReadOnly = True
        '
        'PaymentTermsColumn
        '
        Me.PaymentTermsColumn.DataPropertyName = "PaymentTerms"
        Me.PaymentTermsColumn.HeaderText = "Payment Terms"
        Me.PaymentTermsColumn.Name = "PaymentTermsColumn"
        Me.PaymentTermsColumn.ReadOnly = True
        '
        'OldCustomerNumberColumn
        '
        Me.OldCustomerNumberColumn.DataPropertyName = "OldCustomerNumber"
        Me.OldCustomerNumberColumn.HeaderText = "Old Cust. #"
        Me.OldCustomerNumberColumn.Name = "OldCustomerNumberColumn"
        Me.OldCustomerNumberColumn.Visible = False
        '
        'PreferredShipperColumn
        '
        Me.PreferredShipperColumn.DataPropertyName = "PreferredShipper"
        Me.PreferredShipperColumn.HeaderText = "Preferred Shipper"
        Me.PreferredShipperColumn.Name = "PreferredShipperColumn"
        '
        'ShippingDetailsColumn
        '
        Me.ShippingDetailsColumn.DataPropertyName = "ShippingDetails"
        Me.ShippingDetailsColumn.HeaderText = "Shipping Details"
        Me.ShippingDetailsColumn.Name = "ShippingDetailsColumn"
        '
        'SalesTaxStatusColumn
        '
        Me.SalesTaxStatusColumn.DataPropertyName = "SalesTaxStatus"
        Me.SalesTaxStatusColumn.HeaderText = "Tax Class"
        Me.SalesTaxStatusColumn.Items.AddRange(New Object() {"TAXABLE", "EXEMPT", "OUT-OF-STATE"})
        Me.SalesTaxStatusColumn.Name = "SalesTaxStatusColumn"
        Me.SalesTaxStatusColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SalesTaxStatusColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'SalesTaxIDColumn
        '
        Me.SalesTaxIDColumn.DataPropertyName = "SalesTaxID"
        Me.SalesTaxIDColumn.HeaderText = "Sales Tax ID"
        Me.SalesTaxIDColumn.Name = "SalesTaxIDColumn"
        '
        'SalesTaxRateColumn
        '
        Me.SalesTaxRateColumn.DataPropertyName = "SalesTaxRate"
        DataGridViewCellStyle10.Format = "N5"
        DataGridViewCellStyle10.NullValue = "0"
        Me.SalesTaxRateColumn.DefaultCellStyle = DataGridViewCellStyle10
        Me.SalesTaxRateColumn.HeaderText = "Tax Rate 1"
        Me.SalesTaxRateColumn.Name = "SalesTaxRateColumn"
        '
        'SalesTaxRate2Column
        '
        Me.SalesTaxRate2Column.DataPropertyName = "SalesTaxRate2"
        DataGridViewCellStyle11.Format = "N5"
        DataGridViewCellStyle11.NullValue = "0"
        Me.SalesTaxRate2Column.DefaultCellStyle = DataGridViewCellStyle11
        Me.SalesTaxRate2Column.HeaderText = "Tax Rate 2"
        Me.SalesTaxRate2Column.Name = "SalesTaxRate2Column"
        '
        'SalesTaxRate3Column
        '
        Me.SalesTaxRate3Column.DataPropertyName = "SalesTaxRate3"
        DataGridViewCellStyle12.Format = "N5"
        DataGridViewCellStyle12.NullValue = "0"
        Me.SalesTaxRate3Column.DefaultCellStyle = DataGridViewCellStyle12
        Me.SalesTaxRate3Column.HeaderText = "Tax Rate 3"
        Me.SalesTaxRate3Column.Name = "SalesTaxRate3Column"
        '
        'ShippingAccountColumn
        '
        Me.ShippingAccountColumn.DataPropertyName = "ShippingAccount"
        Me.ShippingAccountColumn.HeaderText = "Shipping Account"
        Me.ShippingAccountColumn.Name = "ShippingAccountColumn"
        '
        'BankAccountColumn
        '
        Me.BankAccountColumn.DataPropertyName = "BankAccount"
        Me.BankAccountColumn.HeaderText = "Bank Account"
        Me.BankAccountColumn.Name = "BankAccountColumn"
        Me.BankAccountColumn.ReadOnly = True
        '
        'CustomerDateColumn
        '
        Me.CustomerDateColumn.DataPropertyName = "CustomerDate"
        Me.CustomerDateColumn.HeaderText = "Customer Since?"
        Me.CustomerDateColumn.Name = "CustomerDateColumn"
        Me.CustomerDateColumn.ReadOnly = True
        '
        'ViewCustomerListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdAutoEmailStatements)
        Me.Controls.Add(Me.cmdPrintAddShipTo)
        Me.Controls.Add(Me.cmdARReport)
        Me.Controls.Add(Me.dgvCustomerList)
        Me.Controls.Add(Me.cmdPrintAddresses)
        Me.Controls.Add(Me.cmdPrintPhoneList)
        Me.Controls.Add(Me.cmdOpenCustomerForm)
        Me.Controls.Add(Me.cmdPrintCustomerStatement)
        Me.Controls.Add(Me.gpxInventorySPL)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.CRStatementViewer)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewCustomerListing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Customer List"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxInventorySPL.ResumeLayout(False)
        Me.gpxInventorySPL.PerformLayout()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListWithAgingQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCustomerList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintCustomersAddressesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintCustomerPhoneListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ContactNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmailDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PhoneDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FaxDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gpxInventorySPL As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdOpenCustomerForm As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboSalesTerritory As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PrintCustomerListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkViewByHold As System.Windows.Forms.CheckBox
    Friend WithEvents chkAccountingHold As System.Windows.Forms.CheckBox
    Friend WithEvents cmdPrintCustomerStatement As System.Windows.Forms.Button
    Friend WithEvents cboState As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintPhoneList As System.Windows.Forms.Button
    Friend WithEvents cmdPrintAddresses As System.Windows.Forms.Button
    Friend WithEvents dgvCustomerList As System.Windows.Forms.DataGridView
    Friend WithEvents CustomerListWithAgingQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListWithAgingQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListWithAgingQueryTableAdapter
    Friend WithEvents chkBTState As System.Windows.Forms.CheckBox
    Friend WithEvents chkSTState As System.Windows.Forms.CheckBox
    Friend WithEvents txtZipCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents StateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StateTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
    Friend WithEvents chkAR30 As System.Windows.Forms.CheckBox
    Friend WithEvents chkAR60 As System.Windows.Forms.CheckBox
    Friend WithEvents chkAR90 As System.Windows.Forms.CheckBox
    Friend WithEvents chkAR90Plus As System.Windows.Forms.CheckBox
    Friend WithEvents chkAR45 As System.Windows.Forms.CheckBox
    Friend WithEvents cmdARReport As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintAddShipTo As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdAddCustomerToDivision As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNewDivision As System.Windows.Forms.TextBox
    Friend WithEvents txtBegins As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CustomerInactivityReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewTWDCLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewTWECLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdAutoEmailStatements As System.Windows.Forms.Button
    Friend WithEvents CRStatementViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXCustStatement1 As MOS09Program.CRXCustStatement
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboPaymentTerms As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APContactNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APPhoneNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APFAXNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APEmailAddressColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesContactEmailColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceEmailColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceCertEmailColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToAddress1Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToAddress2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToCityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToStateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToZipColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToCountryColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillToAddress1Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillToAddress2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillToCityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillToStateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillToZipColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillToCountryColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTerritoryColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentsAppliedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceAmountOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AgingLessThan30Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aging31To45Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aging46To60Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aging61To90Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AgingMoreThan90Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OnHoldStatusColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents AccountingHoldColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConfirmationEmailColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackingListEmailColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatementEmailColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipEmail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CertEmailColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditLimitColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTermsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OldCustomerNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PreferredShipperColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingDetailsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxStatusColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents SalesTaxIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxRateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxRate2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxRate3Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BankAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
