<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QuoteForm
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.txtContact = New System.Windows.Forms.TextBox
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearQuoteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConvertToSalesOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.PricingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdEnter = New System.Windows.Forms.Button
        Me.Label108 = New System.Windows.Forms.Label
        Me.Label109 = New System.Windows.Forms.Label
        Me.Label113 = New System.Windows.Forms.Label
        Me.Label105 = New System.Windows.Forms.Label
        Me.gpxGeneralInfo = New System.Windows.Forms.GroupBox
        Me.dtpQuoteDate = New System.Windows.Forms.DateTimePicker
        Me.llCustomerID = New System.Windows.Forms.LinkLabel
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.cboQuoteNumber = New System.Windows.Forms.ComboBox
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label13 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.chkNewCustomer = New System.Windows.Forms.CheckBox
        Me.cboSalesperson = New System.Windows.Forms.ComboBox
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdGenerateNewQuote = New System.Windows.Forms.Button
        Me.Label114 = New System.Windows.Forms.Label
        Me.Label112 = New System.Windows.Forms.Label
        Me.lblDivisionID = New System.Windows.Forms.Label
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cboShipVia = New System.Windows.Forms.ComboBox
        Me.ShipMethodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtFreightCharge = New System.Windows.Forms.TextBox
        Me.dtpDeliveryDate = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label222 = New System.Windows.Forms.Label
        Me.Label106 = New System.Windows.Forms.Label
        Me.Label107 = New System.Windows.Forms.Label
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdConvertToSO = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdOpenOrders = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.lblLongDescription = New System.Windows.Forms.Label
        Me.lblLastPurchaseCost = New System.Windows.Forms.Label
        Me.txtTaxRate = New System.Windows.Forms.TextBox
        Me.txtLinePrice = New System.Windows.Forms.TextBox
        Me.txtLeadDate = New System.Windows.Forms.MaskedTextBox
        Me.txtExtendedAmount = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblQOH = New System.Windows.Forms.Label
        Me.txtLineComment = New System.Windows.Forms.TextBox
        Me.chkTaxable = New System.Windows.Forms.CheckBox
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtShipToName = New System.Windows.Forms.TextBox
        Me.txtShipToCountry = New System.Windows.Forms.TextBox
        Me.cboShipToID = New System.Windows.Forms.ComboBox
        Me.AdditionalShipToBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtShipToZip = New System.Windows.Forms.TextBox
        Me.txtShipToState = New System.Windows.Forms.TextBox
        Me.txtShipToCity = New System.Windows.Forms.TextBox
        Me.txtShipToAddress2 = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtShipToAddress1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdCustomerSalesHistory = New System.Windows.Forms.Button
        Me.gpxQuoteTotals = New System.Windows.Forms.GroupBox
        Me.lblHSTExtendedAmount = New System.Windows.Forms.Label
        Me.LabelPSTTotal = New System.Windows.Forms.Label
        Me.cmdRemoveSalesTax = New System.Windows.Forms.Button
        Me.lblFreightCharge = New System.Windows.Forms.Label
        Me.txtHSTRate = New System.Windows.Forms.TextBox
        Me.chkADDHST = New System.Windows.Forms.CheckBox
        Me.chkADDPST = New System.Windows.Forms.CheckBox
        Me.lblPSTExtendedAmount = New System.Windows.Forms.Label
        Me.LabelHSTTotal = New System.Windows.Forms.Label
        Me.lblSalesTax = New System.Windows.Forms.Label
        Me.lblProductTotal = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblQuoteTotal = New System.Windows.Forms.Label
        Me.LabelGSTTotal = New System.Windows.Forms.Label
        Me.lblEstimatedWeight = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.dgvSalesOrderLines = New System.Windows.Forms.DataGridView
        Me.SalesOrderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LeadTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineBoxesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SalesOrderLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderLineTableTableAdapter
        Me.ShipMethodTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
        Me.AdditionalShipToTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AdditionalShipToTableAdapter
        Me.tabQuoteData = New System.Windows.Forms.TabControl
        Me.tabQuoteLines = New System.Windows.Forms.TabPage
        Me.tabAdditionalData = New System.Windows.Forms.TabPage
        Me.txtThirdPartyShipper = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.cboShipMethod = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtSpecialInstructions = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabQuoteLineDetails = New System.Windows.Forms.TabPage
        Me.lblQuantityAvailable = New System.Windows.Forms.Label
        Me.lblUpdatedPrice = New System.Windows.Forms.Label
        Me.llPriceLookup = New System.Windows.Forms.LinkLabel
        Me.tabDeleteLines = New System.Windows.Forms.TabPage
        Me.Label32 = New System.Windows.Forms.Label
        Me.txtQuoteLineLeadTime = New System.Windows.Forms.MaskedTextBox
        Me.txtQuoteLinePrice = New System.Windows.Forms.TextBox
        Me.txtQuoteExtendedAmount = New System.Windows.Forms.TextBox
        Me.txtQuoteLineComment = New System.Windows.Forms.TextBox
        Me.txtQuoteLineQuantity = New System.Windows.Forms.TextBox
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.cmdSaveLine = New System.Windows.Forms.Button
        Me.cboQuoteLineDescription = New System.Windows.Forms.ComboBox
        Me.cboQuoteLinePart = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cboQuoteLineNumber = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.gpxGeneralInfo.SuspendLayout()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.AdditionalShipToBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxQuoteTotals.SuspendLayout()
        CType(Me.dgvSalesOrderLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabQuoteData.SuspendLayout()
        Me.tabQuoteLines.SuspendLayout()
        Me.tabAdditionalData.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabQuoteLineDetails.SuspendLayout()
        Me.tabDeleteLines.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1056, 775)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 68
        Me.cmdExit.Text = "Exit Quote"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'txtContact
        '
        Me.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContact.Location = New System.Drawing.Point(17, 336)
        Me.txtContact.Multiline = True
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(292, 82)
        Me.txtContact.TabIndex = 42
        Me.txtContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtComment
        '
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(339, 33)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(401, 169)
        Me.txtComment.TabIndex = 43
        Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuantity
        '
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantity.Location = New System.Drawing.Point(184, 122)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(127, 20)
        Me.txtQuantity.TabIndex = 10
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem1, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem1, Me.PricingToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripMenuItem, Me.SaveToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ClearQuoteToolStripMenuItem, Me.ConvertToSalesOrderToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.PrintToolStripMenuItem.Text = "Print Quote"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.SaveToolStripMenuItem.Text = "Save Quote"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete Quote"
        '
        'ClearQuoteToolStripMenuItem
        '
        Me.ClearQuoteToolStripMenuItem.Name = "ClearQuoteToolStripMenuItem"
        Me.ClearQuoteToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ClearQuoteToolStripMenuItem.Text = "Clear Quote"
        '
        'ConvertToSalesOrderToolStripMenuItem
        '
        Me.ConvertToSalesOrderToolStripMenuItem.Name = "ConvertToSalesOrderToolStripMenuItem"
        Me.ConvertToSalesOrderToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ConvertToSalesOrderToolStripMenuItem.Text = "Convert to Sales Order"
        '
        'EditToolStripMenuItem1
        '
        Me.EditToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearAllToolStripMenuItem})
        Me.EditToolStripMenuItem1.Name = "EditToolStripMenuItem1"
        Me.EditToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem1.Text = "Edit"
        '
        'ClearAllToolStripMenuItem
        '
        Me.ClearAllToolStripMenuItem.Name = "ClearAllToolStripMenuItem"
        Me.ClearAllToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.ClearAllToolStripMenuItem.Text = "Clear All"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem2})
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'ExitToolStripMenuItem2
        '
        Me.ExitToolStripMenuItem2.Name = "ExitToolStripMenuItem2"
        Me.ExitToolStripMenuItem2.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem2.Text = "Exit"
        '
        'PricingToolStripMenuItem
        '
        Me.PricingToolStripMenuItem.Name = "PricingToolStripMenuItem"
        Me.PricingToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.PricingToolStripMenuItem.Text = "Pricing"
        Me.PricingToolStripMenuItem.Visible = False
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(242, 404)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 17
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdEnter
        '
        Me.cmdEnter.Location = New System.Drawing.Point(165, 404)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(71, 30)
        Me.cmdEnter.TabIndex = 16
        Me.cmdEnter.Text = "Enter Item"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'Label108
        '
        Me.Label108.Location = New System.Drawing.Point(13, 15)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(86, 20)
        Me.Label108.TabIndex = 12
        Me.Label108.Text = "Part Number"
        Me.Label108.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label109
        '
        Me.Label109.Location = New System.Drawing.Point(13, 122)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(86, 20)
        Me.Label109.TabIndex = 11
        Me.Label109.Text = "Quantity"
        Me.Label109.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label113
        '
        Me.Label113.Location = New System.Drawing.Point(13, 93)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(108, 20)
        Me.Label113.TabIndex = 8
        Me.Label113.Text = "Date"
        Me.Label113.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label105
        '
        Me.Label105.Location = New System.Drawing.Point(14, 313)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(293, 20)
        Me.Label105.TabIndex = 13
        Me.Label105.Text = "Contact (adds to customer data)"
        Me.Label105.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxGeneralInfo
        '
        Me.gpxGeneralInfo.Controls.Add(Me.dtpQuoteDate)
        Me.gpxGeneralInfo.Controls.Add(Me.llCustomerID)
        Me.gpxGeneralInfo.Controls.Add(Me.txtCustomerPO)
        Me.gpxGeneralInfo.Controls.Add(Me.cboQuoteNumber)
        Me.gpxGeneralInfo.Controls.Add(Me.Label13)
        Me.gpxGeneralInfo.Controls.Add(Me.cboDivisionID)
        Me.gpxGeneralInfo.Controls.Add(Me.chkNewCustomer)
        Me.gpxGeneralInfo.Controls.Add(Me.cboSalesperson)
        Me.gpxGeneralInfo.Controls.Add(Me.cmdGenerateNewQuote)
        Me.gpxGeneralInfo.Controls.Add(Me.Label114)
        Me.gpxGeneralInfo.Controls.Add(Me.Label112)
        Me.gpxGeneralInfo.Controls.Add(Me.lblDivisionID)
        Me.gpxGeneralInfo.Controls.Add(Me.Label113)
        Me.gpxGeneralInfo.Controls.Add(Me.cboCustomerID)
        Me.gpxGeneralInfo.Controls.Add(Me.cboCustomerName)
        Me.gpxGeneralInfo.Controls.Add(Me.Label16)
        Me.gpxGeneralInfo.Location = New System.Drawing.Point(29, 41)
        Me.gpxGeneralInfo.Name = "gpxGeneralInfo"
        Me.gpxGeneralInfo.Size = New System.Drawing.Size(326, 298)
        Me.gpxGeneralInfo.TabIndex = 0
        Me.gpxGeneralInfo.TabStop = False
        Me.gpxGeneralInfo.Text = "General Information"
        '
        'dtpQuoteDate
        '
        Me.dtpQuoteDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpQuoteDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpQuoteDate.Location = New System.Drawing.Point(105, 93)
        Me.dtpQuoteDate.Name = "dtpQuoteDate"
        Me.dtpQuoteDate.Size = New System.Drawing.Size(206, 20)
        Me.dtpQuoteDate.TabIndex = 2
        '
        'llCustomerID
        '
        Me.llCustomerID.AutoSize = True
        Me.llCustomerID.Location = New System.Drawing.Point(13, 163)
        Me.llCustomerID.Name = "llCustomerID"
        Me.llCustomerID.Size = New System.Drawing.Size(51, 13)
        Me.llCustomerID.TabIndex = 38
        Me.llCustomerID.TabStop = True
        Me.llCustomerID.Text = "Customer"
        '
        'txtCustomerPO
        '
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerPO.Location = New System.Drawing.Point(91, 265)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(220, 20)
        Me.txtCustomerPO.TabIndex = 7
        Me.txtCustomerPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboQuoteNumber
        '
        Me.cboQuoteNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboQuoteNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboQuoteNumber.DataSource = Me.SalesOrderHeaderTableBindingSource
        Me.cboQuoteNumber.DisplayMember = "SalesOrderKey"
        Me.cboQuoteNumber.FormattingEnabled = True
        Me.cboQuoteNumber.Location = New System.Drawing.Point(105, 25)
        Me.cboQuoteNumber.Name = "cboQuoteNumber"
        Me.cboQuoteNumber.Size = New System.Drawing.Size(206, 21)
        Me.cboQuoteNumber.TabIndex = 0
        Me.cboQuoteNumber.ValueMember = "CustID"
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(125, 229)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(186, 30)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "If customer does not exist, check box and new customer will be created."
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(105, 59)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(206, 21)
        Me.cboDivisionID.TabIndex = 1
        Me.cboDivisionID.ValueMember = "CustID"
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'chkNewCustomer
        '
        Me.chkNewCustomer.AutoSize = True
        Me.chkNewCustomer.Location = New System.Drawing.Point(16, 229)
        Me.chkNewCustomer.Name = "chkNewCustomer"
        Me.chkNewCustomer.Size = New System.Drawing.Size(101, 17)
        Me.chkNewCustomer.TabIndex = 6
        Me.chkNewCustomer.Text = "New Customer?"
        Me.chkNewCustomer.UseVisualStyleBackColor = True
        '
        'cboSalesperson
        '
        Me.cboSalesperson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesperson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesperson.DataSource = Me.EmployeeDataBindingSource
        Me.cboSalesperson.DisplayMember = "SalesPersonID"
        Me.cboSalesperson.FormattingEnabled = True
        Me.cboSalesperson.Location = New System.Drawing.Point(88, 126)
        Me.cboSalesperson.Name = "cboSalesperson"
        Me.cboSalesperson.Size = New System.Drawing.Size(223, 21)
        Me.cboSalesperson.TabIndex = 3
        Me.cboSalesperson.ValueMember = "CustID"
        '
        'EmployeeDataBindingSource
        '
        Me.EmployeeDataBindingSource.DataMember = "EmployeeData"
        Me.EmployeeDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdGenerateNewQuote
        '
        Me.cmdGenerateNewQuote.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateNewQuote.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateNewQuote.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateNewQuote.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateNewQuote.Location = New System.Drawing.Point(74, 25)
        Me.cmdGenerateNewQuote.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateNewQuote.Name = "cmdGenerateNewQuote"
        Me.cmdGenerateNewQuote.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateNewQuote.TabIndex = 0
        Me.cmdGenerateNewQuote.TabStop = False
        Me.cmdGenerateNewQuote.Text = ">>"
        Me.cmdGenerateNewQuote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateNewQuote.UseVisualStyleBackColor = False
        '
        'Label114
        '
        Me.Label114.Location = New System.Drawing.Point(13, 25)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(108, 20)
        Me.Label114.TabIndex = 27
        Me.Label114.Text = "Quote #"
        Me.Label114.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label112
        '
        Me.Label112.Location = New System.Drawing.Point(12, 265)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(108, 20)
        Me.Label112.TabIndex = 24
        Me.Label112.Text = "Cust. PO #"
        Me.Label112.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDivisionID
        '
        Me.lblDivisionID.Location = New System.Drawing.Point(13, 60)
        Me.lblDivisionID.Name = "lblDivisionID"
        Me.lblDivisionID.Size = New System.Drawing.Size(108, 20)
        Me.lblDivisionID.TabIndex = 25
        Me.lblDivisionID.Text = "Division ID"
        Me.lblDivisionID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(88, 160)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(223, 21)
        Me.cboCustomerID.TabIndex = 4
        Me.cboCustomerID.ValueMember = "CustID"
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(16, 194)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(295, 21)
        Me.cboCustomerName.TabIndex = 5
        Me.cboCustomerName.ValueMember = "CustID"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(13, 127)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(108, 20)
        Me.Label16.TabIndex = 37
        Me.Label16.Text = "Salesperson"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipVia
        '
        Me.cboShipVia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipVia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipVia.DataSource = Me.ShipMethodBindingSource
        Me.cboShipVia.DisplayMember = "ShipMethID"
        Me.cboShipVia.FormattingEnabled = True
        Me.cboShipVia.Location = New System.Drawing.Point(93, 48)
        Me.cboShipVia.MaxLength = 50
        Me.cboShipVia.Name = "cboShipVia"
        Me.cboShipVia.Size = New System.Drawing.Size(216, 21)
        Me.cboShipVia.TabIndex = 37
        '
        'ShipMethodBindingSource
        '
        Me.ShipMethodBindingSource.DataMember = "ShipMethod"
        Me.ShipMethodBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtFreightCharge
        '
        Me.txtFreightCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightCharge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreightCharge.Location = New System.Drawing.Point(159, 110)
        Me.txtFreightCharge.Name = "txtFreightCharge"
        Me.txtFreightCharge.Size = New System.Drawing.Size(150, 20)
        Me.txtFreightCharge.TabIndex = 39
        Me.txtFreightCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpDeliveryDate
        '
        Me.dtpDeliveryDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDeliveryDate.Location = New System.Drawing.Point(120, 18)
        Me.dtpDeliveryDate.Name = "dtpDeliveryDate"
        Me.dtpDeliveryDate.Size = New System.Drawing.Size(189, 20)
        Me.dtpDeliveryDate.TabIndex = 36
        Me.dtpDeliveryDate.Value = New Date(2016, 11, 2, 16, 17, 46, 0)
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 20)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Ship Via"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label222
        '
        Me.Label222.Location = New System.Drawing.Point(17, 110)
        Me.Label222.Name = "Label222"
        Me.Label222.Size = New System.Drawing.Size(108, 20)
        Me.Label222.TabIndex = 30
        Me.Label222.Text = "Est. Freight"
        Me.Label222.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label106
        '
        Me.Label106.Location = New System.Drawing.Point(17, 18)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(108, 20)
        Me.Label106.TabIndex = 20
        Me.Label106.Text = "Delivery Date"
        Me.Label106.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label107
        '
        Me.Label107.Location = New System.Drawing.Point(336, 13)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(108, 20)
        Me.Label107.TabIndex = 17
        Me.Label107.Text = "Comment"
        Me.Label107.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.DropDownWidth = 250
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(88, 15)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(225, 21)
        Me.cboPartNumber.TabIndex = 8
        Me.cboPartNumber.ValueMember = "ItemID"
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 775)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 67
        Me.cmdPrint.Text = "Print Quote"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdConvertToSO
        '
        Me.cmdConvertToSO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdConvertToSO.Location = New System.Drawing.Point(1056, 729)
        Me.cmdConvertToSO.Name = "cmdConvertToSO"
        Me.cmdConvertToSO.Size = New System.Drawing.Size(71, 40)
        Me.cmdConvertToSO.TabIndex = 64
        Me.cmdConvertToSO.Text = "Convert to SO"
        Me.cmdConvertToSO.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(905, 775)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 66
        Me.cmdDelete.Text = "Delete Quote"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdOpenOrders
        '
        Me.cmdOpenOrders.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenOrders.Location = New System.Drawing.Point(903, 729)
        Me.cmdOpenOrders.Name = "cmdOpenOrders"
        Me.cmdOpenOrders.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenOrders.TabIndex = 62
        Me.cmdOpenOrders.Text = "Open Orders"
        Me.cmdOpenOrders.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(828, 775)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 65
        Me.cmdSave.Text = "Save Quote"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'lblLongDescription
        '
        Me.lblLongDescription.Location = New System.Drawing.Point(13, 73)
        Me.lblLongDescription.Name = "lblLongDescription"
        Me.lblLongDescription.Size = New System.Drawing.Size(298, 40)
        Me.lblLongDescription.TabIndex = 9
        Me.lblLongDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLastPurchaseCost
        '
        Me.lblLastPurchaseCost.ForeColor = System.Drawing.Color.Red
        Me.lblLastPurchaseCost.Location = New System.Drawing.Point(50, 151)
        Me.lblLastPurchaseCost.Name = "lblLastPurchaseCost"
        Me.lblLastPurchaseCost.Size = New System.Drawing.Size(106, 20)
        Me.lblLastPurchaseCost.TabIndex = 12
        Me.lblLastPurchaseCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTaxRate
        '
        Me.txtTaxRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaxRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTaxRate.Location = New System.Drawing.Point(13, 414)
        Me.txtTaxRate.Name = "txtTaxRate"
        Me.txtTaxRate.Size = New System.Drawing.Size(107, 20)
        Me.txtTaxRate.TabIndex = 15
        Me.txtTaxRate.TabStop = False
        Me.txtTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTaxRate.Visible = False
        '
        'txtLinePrice
        '
        Me.txtLinePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinePrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLinePrice.Location = New System.Drawing.Point(184, 151)
        Me.txtLinePrice.Name = "txtLinePrice"
        Me.txtLinePrice.Size = New System.Drawing.Size(127, 20)
        Me.txtLinePrice.TabIndex = 11
        Me.txtLinePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLeadDate
        '
        Me.txtLeadDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLeadDate.Location = New System.Drawing.Point(116, 241)
        Me.txtLeadDate.Mask = "00/00/0000"
        Me.txtLeadDate.Name = "txtLeadDate"
        Me.txtLeadDate.Size = New System.Drawing.Size(195, 20)
        Me.txtLeadDate.TabIndex = 13
        Me.txtLeadDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLeadDate.ValidatingType = GetType(Date)
        '
        'txtExtendedAmount
        '
        Me.txtExtendedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExtendedAmount.Enabled = False
        Me.txtExtendedAmount.Location = New System.Drawing.Point(184, 180)
        Me.txtExtendedAmount.Name = "txtExtendedAmount"
        Me.txtExtendedAmount.Size = New System.Drawing.Size(127, 20)
        Me.txtExtendedAmount.TabIndex = 12
        Me.txtExtendedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(13, 180)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 20)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Extended Amount"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblQOH
        '
        Me.lblQOH.ForeColor = System.Drawing.Color.Blue
        Me.lblQOH.Location = New System.Drawing.Point(74, 122)
        Me.lblQOH.Name = "lblQOH"
        Me.lblQOH.Size = New System.Drawing.Size(104, 20)
        Me.lblQOH.TabIndex = 10
        Me.lblQOH.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLineComment
        '
        Me.txtLineComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineComment.Location = New System.Drawing.Point(13, 297)
        Me.txtLineComment.Multiline = True
        Me.txtLineComment.Name = "txtLineComment"
        Me.txtLineComment.Size = New System.Drawing.Size(300, 81)
        Me.txtLineComment.TabIndex = 14
        Me.txtLineComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkTaxable
        '
        Me.chkTaxable.Location = New System.Drawing.Point(13, 393)
        Me.chkTaxable.Name = "chkTaxable"
        Me.chkTaxable.Size = New System.Drawing.Size(87, 20)
        Me.chkTaxable.TabIndex = 15
        Me.chkTaxable.TabStop = False
        Me.chkTaxable.Text = "Taxable?"
        Me.chkTaxable.UseVisualStyleBackColor = True
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AllowDrop = True
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.DropDownWidth = 500
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(13, 45)
        Me.cboPartDescription.MaxDropDownItems = 20
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(301, 21)
        Me.cboPartDescription.TabIndex = 9
        Me.cboPartDescription.ValueMember = "ItemID"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(13, 241)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 20)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Est. Lead Time"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(13, 274)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 20)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Line Comment"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtShipToName)
        Me.GroupBox1.Controls.Add(Me.txtShipToCountry)
        Me.GroupBox1.Controls.Add(Me.cboShipToID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtShipToZip)
        Me.GroupBox1.Controls.Add(Me.txtShipToState)
        Me.GroupBox1.Controls.Add(Me.txtShipToCity)
        Me.GroupBox1.Controls.Add(Me.txtShipToAddress2)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtShipToAddress1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(369, 497)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(450, 318)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Shipping Address"
        '
        'txtShipToName
        '
        Me.txtShipToName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipToName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipToName.Location = New System.Drawing.Point(94, 74)
        Me.txtShipToName.Name = "txtShipToName"
        Me.txtShipToName.Size = New System.Drawing.Size(333, 20)
        Me.txtShipToName.TabIndex = 29
        Me.txtShipToName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtShipToCountry
        '
        Me.txtShipToCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipToCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipToCountry.Location = New System.Drawing.Point(94, 286)
        Me.txtShipToCountry.Name = "txtShipToCountry"
        Me.txtShipToCountry.Size = New System.Drawing.Size(333, 20)
        Me.txtShipToCountry.TabIndex = 35
        Me.txtShipToCountry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboShipToID
        '
        Me.cboShipToID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipToID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipToID.DataSource = Me.AdditionalShipToBindingSource
        Me.cboShipToID.DisplayMember = "ShipToID"
        Me.cboShipToID.FormattingEnabled = True
        Me.cboShipToID.Location = New System.Drawing.Point(94, 25)
        Me.cboShipToID.Name = "cboShipToID"
        Me.cboShipToID.Size = New System.Drawing.Size(333, 21)
        Me.cboShipToID.TabIndex = 28
        Me.cboShipToID.ValueMember = "CustID"
        '
        'AdditionalShipToBindingSource
        '
        Me.AdditionalShipToBindingSource.DataMember = "AdditionalShipTo"
        Me.AdditionalShipToBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 288)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 20)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Country"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShipToZip
        '
        Me.txtShipToZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipToZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipToZip.Location = New System.Drawing.Point(280, 260)
        Me.txtShipToZip.Name = "txtShipToZip"
        Me.txtShipToZip.Size = New System.Drawing.Size(147, 20)
        Me.txtShipToZip.TabIndex = 34
        Me.txtShipToZip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtShipToState
        '
        Me.txtShipToState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipToState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipToState.Location = New System.Drawing.Point(94, 260)
        Me.txtShipToState.Name = "txtShipToState"
        Me.txtShipToState.Size = New System.Drawing.Size(76, 20)
        Me.txtShipToState.TabIndex = 33
        Me.txtShipToState.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtShipToCity
        '
        Me.txtShipToCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipToCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipToCity.Location = New System.Drawing.Point(94, 234)
        Me.txtShipToCity.Name = "txtShipToCity"
        Me.txtShipToCity.Size = New System.Drawing.Size(333, 20)
        Me.txtShipToCity.TabIndex = 32
        Me.txtShipToCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtShipToAddress2
        '
        Me.txtShipToAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipToAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipToAddress2.Location = New System.Drawing.Point(94, 167)
        Me.txtShipToAddress2.Multiline = True
        Me.txtShipToAddress2.Name = "txtShipToAddress2"
        Me.txtShipToAddress2.Size = New System.Drawing.Size(333, 61)
        Me.txtShipToAddress2.TabIndex = 31
        Me.txtShipToAddress2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(16, 26)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 20)
        Me.Label17.TabIndex = 29
        Me.Label17.Text = "Ship To ID"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShipToAddress1
        '
        Me.txtShipToAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipToAddress1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipToAddress1.Location = New System.Drawing.Point(94, 100)
        Me.txtShipToAddress1.Multiline = True
        Me.txtShipToAddress1.Name = "txtShipToAddress1"
        Me.txtShipToAddress1.Size = New System.Drawing.Size(333, 61)
        Me.txtShipToAddress1.TabIndex = 30
        Me.txtShipToAddress1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(234, 260)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 20)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Zip"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(16, 262)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(72, 20)
        Me.Label19.TabIndex = 25
        Me.Label19.Text = "State"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(16, 236)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(72, 20)
        Me.Label21.TabIndex = 27
        Me.Label21.Text = "City"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(16, 167)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(72, 20)
        Me.Label23.TabIndex = 25
        Me.Label23.Text = "Address 2"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(16, 100)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(72, 20)
        Me.Label25.TabIndex = 23
        Me.Label25.Text = "Address 1"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(16, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 20)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "Ship To Name"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(94, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(343, 20)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "To save new address, Ship To ID cannot be blank"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(827, 729)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 61
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdCustomerSalesHistory
        '
        Me.cmdCustomerSalesHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCustomerSalesHistory.Location = New System.Drawing.Point(979, 729)
        Me.cmdCustomerSalesHistory.Name = "cmdCustomerSalesHistory"
        Me.cmdCustomerSalesHistory.Size = New System.Drawing.Size(71, 40)
        Me.cmdCustomerSalesHistory.TabIndex = 63
        Me.cmdCustomerSalesHistory.Text = "Sales History"
        Me.cmdCustomerSalesHistory.UseVisualStyleBackColor = True
        '
        'gpxQuoteTotals
        '
        Me.gpxQuoteTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxQuoteTotals.Controls.Add(Me.lblHSTExtendedAmount)
        Me.gpxQuoteTotals.Controls.Add(Me.LabelPSTTotal)
        Me.gpxQuoteTotals.Controls.Add(Me.cmdRemoveSalesTax)
        Me.gpxQuoteTotals.Controls.Add(Me.lblFreightCharge)
        Me.gpxQuoteTotals.Controls.Add(Me.txtHSTRate)
        Me.gpxQuoteTotals.Controls.Add(Me.chkADDHST)
        Me.gpxQuoteTotals.Controls.Add(Me.chkADDPST)
        Me.gpxQuoteTotals.Controls.Add(Me.lblPSTExtendedAmount)
        Me.gpxQuoteTotals.Controls.Add(Me.LabelHSTTotal)
        Me.gpxQuoteTotals.Controls.Add(Me.lblSalesTax)
        Me.gpxQuoteTotals.Controls.Add(Me.lblProductTotal)
        Me.gpxQuoteTotals.Controls.Add(Me.Label4)
        Me.gpxQuoteTotals.Controls.Add(Me.Label11)
        Me.gpxQuoteTotals.Controls.Add(Me.Label8)
        Me.gpxQuoteTotals.Controls.Add(Me.lblQuoteTotal)
        Me.gpxQuoteTotals.Controls.Add(Me.LabelGSTTotal)
        Me.gpxQuoteTotals.Location = New System.Drawing.Point(825, 497)
        Me.gpxQuoteTotals.Name = "gpxQuoteTotals"
        Me.gpxQuoteTotals.Size = New System.Drawing.Size(302, 226)
        Me.gpxQuoteTotals.TabIndex = 43
        Me.gpxQuoteTotals.TabStop = False
        Me.gpxQuoteTotals.Text = "Quote Totals"
        '
        'lblHSTExtendedAmount
        '
        Me.lblHSTExtendedAmount.BackColor = System.Drawing.Color.White
        Me.lblHSTExtendedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHSTExtendedAmount.Location = New System.Drawing.Point(173, 151)
        Me.lblHSTExtendedAmount.Name = "lblHSTExtendedAmount"
        Me.lblHSTExtendedAmount.Size = New System.Drawing.Size(118, 20)
        Me.lblHSTExtendedAmount.TabIndex = 50
        Me.lblHSTExtendedAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelPSTTotal
        '
        Me.LabelPSTTotal.Location = New System.Drawing.Point(39, 123)
        Me.LabelPSTTotal.Name = "LabelPSTTotal"
        Me.LabelPSTTotal.Size = New System.Drawing.Size(134, 20)
        Me.LabelPSTTotal.TabIndex = 43
        Me.LabelPSTTotal.Text = "PST"
        Me.LabelPSTTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdRemoveSalesTax
        '
        Me.cmdRemoveSalesTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemoveSalesTax.ForeColor = System.Drawing.Color.Blue
        Me.cmdRemoveSalesTax.Location = New System.Drawing.Point(138, 95)
        Me.cmdRemoveSalesTax.Name = "cmdRemoveSalesTax"
        Me.cmdRemoveSalesTax.Size = New System.Drawing.Size(29, 20)
        Me.cmdRemoveSalesTax.TabIndex = 45
        Me.cmdRemoveSalesTax.Text = "<<"
        Me.cmdRemoveSalesTax.UseVisualStyleBackColor = True
        '
        'lblFreightCharge
        '
        Me.lblFreightCharge.BackColor = System.Drawing.Color.White
        Me.lblFreightCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFreightCharge.Location = New System.Drawing.Point(173, 65)
        Me.lblFreightCharge.Name = "lblFreightCharge"
        Me.lblFreightCharge.Size = New System.Drawing.Size(118, 20)
        Me.lblFreightCharge.TabIndex = 44
        Me.lblFreightCharge.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtHSTRate
        '
        Me.txtHSTRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHSTRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHSTRate.Location = New System.Drawing.Point(96, 151)
        Me.txtHSTRate.Name = "txtHSTRate"
        Me.txtHSTRate.Size = New System.Drawing.Size(71, 20)
        Me.txtHSTRate.TabIndex = 49
        Me.txtHSTRate.TabStop = False
        Me.txtHSTRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHSTRate.Visible = False
        '
        'chkADDHST
        '
        Me.chkADDHST.AutoSize = True
        Me.chkADDHST.Location = New System.Drawing.Point(18, 155)
        Me.chkADDHST.Name = "chkADDHST"
        Me.chkADDHST.Size = New System.Drawing.Size(15, 14)
        Me.chkADDHST.TabIndex = 48
        Me.chkADDHST.TabStop = False
        Me.chkADDHST.UseVisualStyleBackColor = True
        '
        'chkADDPST
        '
        Me.chkADDPST.AutoSize = True
        Me.chkADDPST.Location = New System.Drawing.Point(18, 127)
        Me.chkADDPST.Name = "chkADDPST"
        Me.chkADDPST.Size = New System.Drawing.Size(15, 14)
        Me.chkADDPST.TabIndex = 47
        Me.chkADDPST.TabStop = False
        Me.chkADDPST.UseVisualStyleBackColor = True
        '
        'lblPSTExtendedAmount
        '
        Me.lblPSTExtendedAmount.BackColor = System.Drawing.Color.White
        Me.lblPSTExtendedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPSTExtendedAmount.Location = New System.Drawing.Point(173, 123)
        Me.lblPSTExtendedAmount.Name = "lblPSTExtendedAmount"
        Me.lblPSTExtendedAmount.Size = New System.Drawing.Size(118, 20)
        Me.lblPSTExtendedAmount.TabIndex = 47
        Me.lblPSTExtendedAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelHSTTotal
        '
        Me.LabelHSTTotal.Location = New System.Drawing.Point(39, 151)
        Me.LabelHSTTotal.Name = "LabelHSTTotal"
        Me.LabelHSTTotal.Size = New System.Drawing.Size(134, 20)
        Me.LabelHSTTotal.TabIndex = 42
        Me.LabelHSTTotal.Text = "HST"
        Me.LabelHSTTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSalesTax
        '
        Me.lblSalesTax.BackColor = System.Drawing.Color.White
        Me.lblSalesTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSalesTax.Location = New System.Drawing.Point(173, 95)
        Me.lblSalesTax.Name = "lblSalesTax"
        Me.lblSalesTax.Size = New System.Drawing.Size(118, 20)
        Me.lblSalesTax.TabIndex = 46
        Me.lblSalesTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblProductTotal
        '
        Me.lblProductTotal.BackColor = System.Drawing.Color.White
        Me.lblProductTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProductTotal.Location = New System.Drawing.Point(173, 37)
        Me.lblProductTotal.Name = "lblProductTotal"
        Me.lblProductTotal.Size = New System.Drawing.Size(118, 20)
        Me.lblProductTotal.TabIndex = 43
        Me.lblProductTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(15, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 20)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Product Total"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(15, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(134, 20)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Est. Freight"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(15, 179)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(134, 20)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Quote Total"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblQuoteTotal
        '
        Me.lblQuoteTotal.BackColor = System.Drawing.Color.White
        Me.lblQuoteTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQuoteTotal.Location = New System.Drawing.Point(173, 179)
        Me.lblQuoteTotal.Name = "lblQuoteTotal"
        Me.lblQuoteTotal.Size = New System.Drawing.Size(118, 20)
        Me.lblQuoteTotal.TabIndex = 51
        Me.lblQuoteTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelGSTTotal
        '
        Me.LabelGSTTotal.Location = New System.Drawing.Point(15, 95)
        Me.LabelGSTTotal.Name = "LabelGSTTotal"
        Me.LabelGSTTotal.Size = New System.Drawing.Size(134, 20)
        Me.LabelGSTTotal.TabIndex = 41
        Me.LabelGSTTotal.Text = "Sales Tax"
        Me.LabelGSTTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEstimatedWeight
        '
        Me.lblEstimatedWeight.BackColor = System.Drawing.Color.White
        Me.lblEstimatedWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstimatedWeight.Location = New System.Drawing.Point(159, 140)
        Me.lblEstimatedWeight.Name = "lblEstimatedWeight"
        Me.lblEstimatedWeight.Size = New System.Drawing.Size(150, 20)
        Me.lblEstimatedWeight.TabIndex = 40
        Me.lblEstimatedWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(17, 141)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(152, 20)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Estimated Total Weight"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'EmployeeDataTableAdapter
        '
        Me.EmployeeDataTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'dgvSalesOrderLines
        '
        Me.dgvSalesOrderLines.AllowUserToAddRows = False
        Me.dgvSalesOrderLines.AllowUserToDeleteRows = False
        Me.dgvSalesOrderLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSalesOrderLines.AutoGenerateColumns = False
        Me.dgvSalesOrderLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSalesOrderLines.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSalesOrderLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSalesOrderLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSalesOrderLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SalesOrderKeyColumn, Me.SalesOrderLineKeyColumn, Me.ItemIDColumn, Me.DescriptionColumn, Me.QuantityColumn, Me.PriceColumn, Me.SalesTaxColumn, Me.ExtendedAmountColumn, Me.LeadTime, Me.LineCommentColumn, Me.LineStatusColumn, Me.DivisionIDColumn, Me.LineWeightColumn, Me.LineBoxesColumn})
        Me.dgvSalesOrderLines.DataSource = Me.SalesOrderLineTableBindingSource
        Me.dgvSalesOrderLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvSalesOrderLines.Location = New System.Drawing.Point(0, 0)
        Me.dgvSalesOrderLines.Name = "dgvSalesOrderLines"
        Me.dgvSalesOrderLines.Size = New System.Drawing.Size(754, 424)
        Me.dgvSalesOrderLines.TabIndex = 36
        '
        'SalesOrderKeyColumn
        '
        Me.SalesOrderKeyColumn.DataPropertyName = "SalesOrderKey"
        Me.SalesOrderKeyColumn.HeaderText = "SalesOrderKey"
        Me.SalesOrderKeyColumn.Name = "SalesOrderKeyColumn"
        Me.SalesOrderKeyColumn.Visible = False
        '
        'SalesOrderLineKeyColumn
        '
        Me.SalesOrderLineKeyColumn.DataPropertyName = "SalesOrderLineKey"
        Me.SalesOrderLineKeyColumn.HeaderText = "Line #"
        Me.SalesOrderLineKeyColumn.Name = "SalesOrderLineKeyColumn"
        Me.SalesOrderLineKeyColumn.ReadOnly = True
        Me.SalesOrderLineKeyColumn.Width = 65
        '
        'ItemIDColumn
        '
        Me.ItemIDColumn.DataPropertyName = "ItemID"
        Me.ItemIDColumn.HeaderText = "Part Number"
        Me.ItemIDColumn.Name = "ItemIDColumn"
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Part Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        DataGridViewCellStyle1.NullValue = "0"
        Me.QuantityColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.Width = 90
        '
        'PriceColumn
        '
        Me.PriceColumn.DataPropertyName = "Price"
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = "0"
        Me.PriceColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.PriceColumn.HeaderText = "Price"
        Me.PriceColumn.Name = "PriceColumn"
        Me.PriceColumn.Width = 90
        '
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.SalesTaxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.SalesTaxColumn.HeaderText = "SalesTax"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        Me.SalesTaxColumn.Width = 90
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.ExtendedAmountColumn.HeaderText = "Extended Amount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.Width = 90
        '
        'LeadTime
        '
        Me.LeadTime.DataPropertyName = "LeadTime"
        Me.LeadTime.HeaderText = "Lead Time"
        Me.LeadTime.Name = "LeadTime"
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
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
        'LineWeightColumn
        '
        Me.LineWeightColumn.DataPropertyName = "LineWeight"
        Me.LineWeightColumn.HeaderText = "LineWeight"
        Me.LineWeightColumn.Name = "LineWeightColumn"
        Me.LineWeightColumn.Visible = False
        '
        'LineBoxesColumn
        '
        Me.LineBoxesColumn.DataPropertyName = "LineBoxes"
        Me.LineBoxesColumn.HeaderText = "LineBoxes"
        Me.LineBoxesColumn.Name = "LineBoxesColumn"
        Me.LineBoxesColumn.Visible = False
        '
        'SalesOrderLineTableBindingSource
        '
        Me.SalesOrderLineTableBindingSource.DataMember = "SalesOrderLineTable"
        Me.SalesOrderLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SalesOrderLineTableTableAdapter
        '
        Me.SalesOrderLineTableTableAdapter.ClearBeforeFill = True
        '
        'ShipMethodTableAdapter
        '
        Me.ShipMethodTableAdapter.ClearBeforeFill = True
        '
        'AdditionalShipToTableAdapter
        '
        Me.AdditionalShipToTableAdapter.ClearBeforeFill = True
        '
        'tabQuoteData
        '
        Me.tabQuoteData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabQuoteData.Controls.Add(Me.tabQuoteLines)
        Me.tabQuoteData.Controls.Add(Me.tabAdditionalData)
        Me.tabQuoteData.Location = New System.Drawing.Point(365, 41)
        Me.tabQuoteData.Name = "tabQuoteData"
        Me.tabQuoteData.SelectedIndex = 0
        Me.tabQuoteData.Size = New System.Drawing.Size(762, 450)
        Me.tabQuoteData.TabIndex = 26
        '
        'tabQuoteLines
        '
        Me.tabQuoteLines.Controls.Add(Me.dgvSalesOrderLines)
        Me.tabQuoteLines.Location = New System.Drawing.Point(4, 22)
        Me.tabQuoteLines.Name = "tabQuoteLines"
        Me.tabQuoteLines.Padding = New System.Windows.Forms.Padding(3)
        Me.tabQuoteLines.Size = New System.Drawing.Size(754, 424)
        Me.tabQuoteLines.TabIndex = 0
        Me.tabQuoteLines.Text = "Line Items"
        Me.tabQuoteLines.UseVisualStyleBackColor = True
        '
        'tabAdditionalData
        '
        Me.tabAdditionalData.Controls.Add(Me.txtThirdPartyShipper)
        Me.tabAdditionalData.Controls.Add(Me.Label22)
        Me.tabAdditionalData.Controls.Add(Me.cboShipMethod)
        Me.tabAdditionalData.Controls.Add(Me.Label20)
        Me.tabAdditionalData.Controls.Add(Me.Label15)
        Me.tabAdditionalData.Controls.Add(Me.txtSpecialInstructions)
        Me.tabAdditionalData.Controls.Add(Me.txtFreightCharge)
        Me.tabAdditionalData.Controls.Add(Me.cboShipVia)
        Me.tabAdditionalData.Controls.Add(Me.lblEstimatedWeight)
        Me.tabAdditionalData.Controls.Add(Me.txtComment)
        Me.tabAdditionalData.Controls.Add(Me.dtpDeliveryDate)
        Me.tabAdditionalData.Controls.Add(Me.Label222)
        Me.tabAdditionalData.Controls.Add(Me.Label106)
        Me.tabAdditionalData.Controls.Add(Me.Label5)
        Me.tabAdditionalData.Controls.Add(Me.txtContact)
        Me.tabAdditionalData.Controls.Add(Me.Label10)
        Me.tabAdditionalData.Controls.Add(Me.Label105)
        Me.tabAdditionalData.Controls.Add(Me.Label107)
        Me.tabAdditionalData.Location = New System.Drawing.Point(4, 22)
        Me.tabAdditionalData.Name = "tabAdditionalData"
        Me.tabAdditionalData.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAdditionalData.Size = New System.Drawing.Size(754, 424)
        Me.tabAdditionalData.TabIndex = 1
        Me.tabAdditionalData.Text = "Delivery Info"
        Me.tabAdditionalData.UseVisualStyleBackColor = True
        '
        'txtThirdPartyShipper
        '
        Me.txtThirdPartyShipper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtThirdPartyShipper.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtThirdPartyShipper.Enabled = False
        Me.txtThirdPartyShipper.Location = New System.Drawing.Point(15, 202)
        Me.txtThirdPartyShipper.Multiline = True
        Me.txtThirdPartyShipper.Name = "txtThirdPartyShipper"
        Me.txtThirdPartyShipper.Size = New System.Drawing.Size(292, 92)
        Me.txtThirdPartyShipper.TabIndex = 41
        Me.txtThirdPartyShipper.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(15, 179)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(108, 20)
        Me.Label22.TabIndex = 45
        Me.Label22.Text = "Third Party Shipping"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipMethod
        '
        Me.cboShipMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipMethod.FormattingEnabled = True
        Me.cboShipMethod.Items.AddRange(New Object() {"COLLECT", "PREPAID", "PREPAID/ADD", "PREPAID/NOADD", "THIRD PARTY", "OTHER"})
        Me.cboShipMethod.Location = New System.Drawing.Point(93, 79)
        Me.cboShipMethod.MaxLength = 50
        Me.cboShipMethod.Name = "cboShipMethod"
        Me.cboShipMethod.Size = New System.Drawing.Size(216, 21)
        Me.cboShipMethod.TabIndex = 38
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(17, 80)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(108, 20)
        Me.Label20.TabIndex = 43
        Me.Label20.Text = "Ship Method"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(336, 226)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(295, 20)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "Special Shipping Instructions"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSpecialInstructions
        '
        Me.txtSpecialInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSpecialInstructions.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSpecialInstructions.Location = New System.Drawing.Point(339, 249)
        Me.txtSpecialInstructions.Multiline = True
        Me.txtSpecialInstructions.Name = "txtSpecialInstructions"
        Me.txtSpecialInstructions.Size = New System.Drawing.Size(401, 169)
        Me.txtSpecialInstructions.TabIndex = 44
        Me.txtSpecialInstructions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabQuoteLineDetails)
        Me.TabControl1.Controls.Add(Me.tabDeleteLines)
        Me.TabControl1.Location = New System.Drawing.Point(25, 345)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(330, 470)
        Me.TabControl1.TabIndex = 8
        '
        'tabQuoteLineDetails
        '
        Me.tabQuoteLineDetails.Controls.Add(Me.lblQuantityAvailable)
        Me.tabQuoteLineDetails.Controls.Add(Me.lblUpdatedPrice)
        Me.tabQuoteLineDetails.Controls.Add(Me.cboPartNumber)
        Me.tabQuoteLineDetails.Controls.Add(Me.llPriceLookup)
        Me.tabQuoteLineDetails.Controls.Add(Me.cmdClear)
        Me.tabQuoteLineDetails.Controls.Add(Me.txtLeadDate)
        Me.tabQuoteLineDetails.Controls.Add(Me.cmdEnter)
        Me.tabQuoteLineDetails.Controls.Add(Me.lblLastPurchaseCost)
        Me.tabQuoteLineDetails.Controls.Add(Me.lblLongDescription)
        Me.tabQuoteLineDetails.Controls.Add(Me.txtLinePrice)
        Me.tabQuoteLineDetails.Controls.Add(Me.Label108)
        Me.tabQuoteLineDetails.Controls.Add(Me.cboPartDescription)
        Me.tabQuoteLineDetails.Controls.Add(Me.txtExtendedAmount)
        Me.tabQuoteLineDetails.Controls.Add(Me.txtTaxRate)
        Me.tabQuoteLineDetails.Controls.Add(Me.lblQOH)
        Me.tabQuoteLineDetails.Controls.Add(Me.txtLineComment)
        Me.tabQuoteLineDetails.Controls.Add(Me.Label109)
        Me.tabQuoteLineDetails.Controls.Add(Me.txtQuantity)
        Me.tabQuoteLineDetails.Controls.Add(Me.Label9)
        Me.tabQuoteLineDetails.Controls.Add(Me.Label3)
        Me.tabQuoteLineDetails.Controls.Add(Me.chkTaxable)
        Me.tabQuoteLineDetails.Controls.Add(Me.Label7)
        Me.tabQuoteLineDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabQuoteLineDetails.Name = "tabQuoteLineDetails"
        Me.tabQuoteLineDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabQuoteLineDetails.Size = New System.Drawing.Size(322, 444)
        Me.tabQuoteLineDetails.TabIndex = 0
        Me.tabQuoteLineDetails.Text = "Enter New Line"
        Me.tabQuoteLineDetails.UseVisualStyleBackColor = True
        '
        'lblQuantityAvailable
        '
        Me.lblQuantityAvailable.ForeColor = System.Drawing.Color.Blue
        Me.lblQuantityAvailable.Location = New System.Drawing.Point(13, 210)
        Me.lblQuantityAvailable.Name = "lblQuantityAvailable"
        Me.lblQuantityAvailable.Size = New System.Drawing.Size(298, 20)
        Me.lblQuantityAvailable.TabIndex = 30
        Me.lblQuantityAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUpdatedPrice
        '
        Me.lblUpdatedPrice.ForeColor = System.Drawing.Color.Red
        Me.lblUpdatedPrice.Location = New System.Drawing.Point(162, 151)
        Me.lblUpdatedPrice.Name = "lblUpdatedPrice"
        Me.lblUpdatedPrice.Size = New System.Drawing.Size(22, 20)
        Me.lblUpdatedPrice.TabIndex = 29
        Me.lblUpdatedPrice.Text = "***"
        Me.lblUpdatedPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblUpdatedPrice.Visible = False
        '
        'llPriceLookup
        '
        Me.llPriceLookup.AutoSize = True
        Me.llPriceLookup.Location = New System.Drawing.Point(13, 155)
        Me.llPriceLookup.Name = "llPriceLookup"
        Me.llPriceLookup.Size = New System.Drawing.Size(31, 13)
        Me.llPriceLookup.TabIndex = 28
        Me.llPriceLookup.TabStop = True
        Me.llPriceLookup.Text = "Price"
        '
        'tabDeleteLines
        '
        Me.tabDeleteLines.Controls.Add(Me.Label32)
        Me.tabDeleteLines.Controls.Add(Me.txtQuoteLineLeadTime)
        Me.tabDeleteLines.Controls.Add(Me.txtQuoteLinePrice)
        Me.tabDeleteLines.Controls.Add(Me.txtQuoteExtendedAmount)
        Me.tabDeleteLines.Controls.Add(Me.txtQuoteLineComment)
        Me.tabDeleteLines.Controls.Add(Me.txtQuoteLineQuantity)
        Me.tabDeleteLines.Controls.Add(Me.cmdDeleteLine)
        Me.tabDeleteLines.Controls.Add(Me.cmdSaveLine)
        Me.tabDeleteLines.Controls.Add(Me.cboQuoteLineDescription)
        Me.tabDeleteLines.Controls.Add(Me.cboQuoteLinePart)
        Me.tabDeleteLines.Controls.Add(Me.Label14)
        Me.tabDeleteLines.Controls.Add(Me.cboQuoteLineNumber)
        Me.tabDeleteLines.Controls.Add(Me.Label18)
        Me.tabDeleteLines.Controls.Add(Me.Label31)
        Me.tabDeleteLines.Controls.Add(Me.Label30)
        Me.tabDeleteLines.Controls.Add(Me.Label29)
        Me.tabDeleteLines.Controls.Add(Me.Label28)
        Me.tabDeleteLines.Controls.Add(Me.Label27)
        Me.tabDeleteLines.Location = New System.Drawing.Point(4, 22)
        Me.tabDeleteLines.Name = "tabDeleteLines"
        Me.tabDeleteLines.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDeleteLines.Size = New System.Drawing.Size(322, 444)
        Me.tabDeleteLines.TabIndex = 1
        Me.tabDeleteLines.Text = "Delete/Edit Existing Lines"
        Me.tabDeleteLines.UseVisualStyleBackColor = True
        '
        'Label32
        '
        Me.Label32.ForeColor = System.Drawing.Color.Blue
        Me.Label32.Location = New System.Drawing.Point(12, 337)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(134, 33)
        Me.Label32.TabIndex = 41
        Me.Label32.Text = "Delete line or save changes to existing line."
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQuoteLineLeadTime
        '
        Me.txtQuoteLineLeadTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuoteLineLeadTime.Location = New System.Drawing.Point(149, 205)
        Me.txtQuoteLineLeadTime.Mask = "00/00/0000"
        Me.txtQuoteLineLeadTime.Name = "txtQuoteLineLeadTime"
        Me.txtQuoteLineLeadTime.Size = New System.Drawing.Size(167, 20)
        Me.txtQuoteLineLeadTime.TabIndex = 24
        Me.txtQuoteLineLeadTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtQuoteLineLeadTime.ValidatingType = GetType(Date)
        '
        'txtQuoteLinePrice
        '
        Me.txtQuoteLinePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuoteLinePrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuoteLinePrice.Location = New System.Drawing.Point(149, 145)
        Me.txtQuoteLinePrice.Name = "txtQuoteLinePrice"
        Me.txtQuoteLinePrice.Size = New System.Drawing.Size(167, 20)
        Me.txtQuoteLinePrice.TabIndex = 22
        Me.txtQuoteLinePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuoteExtendedAmount
        '
        Me.txtQuoteExtendedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuoteExtendedAmount.Enabled = False
        Me.txtQuoteExtendedAmount.Location = New System.Drawing.Point(149, 175)
        Me.txtQuoteExtendedAmount.Name = "txtQuoteExtendedAmount"
        Me.txtQuoteExtendedAmount.Size = New System.Drawing.Size(167, 20)
        Me.txtQuoteExtendedAmount.TabIndex = 23
        Me.txtQuoteExtendedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuoteLineComment
        '
        Me.txtQuoteLineComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuoteLineComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuoteLineComment.Location = New System.Drawing.Point(11, 260)
        Me.txtQuoteLineComment.Multiline = True
        Me.txtQuoteLineComment.Name = "txtQuoteLineComment"
        Me.txtQuoteLineComment.Size = New System.Drawing.Size(305, 65)
        Me.txtQuoteLineComment.TabIndex = 25
        Me.txtQuoteLineComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuoteLineQuantity
        '
        Me.txtQuoteLineQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuoteLineQuantity.Location = New System.Drawing.Point(149, 115)
        Me.txtQuoteLineQuantity.Name = "txtQuoteLineQuantity"
        Me.txtQuoteLineQuantity.Size = New System.Drawing.Size(167, 20)
        Me.txtQuoteLineQuantity.TabIndex = 21
        Me.txtQuoteLineQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.Location = New System.Drawing.Point(245, 338)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 30)
        Me.cmdDeleteLine.TabIndex = 27
        Me.cmdDeleteLine.Text = "Delete"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'cmdSaveLine
        '
        Me.cmdSaveLine.Location = New System.Drawing.Point(168, 338)
        Me.cmdSaveLine.Name = "cmdSaveLine"
        Me.cmdSaveLine.Size = New System.Drawing.Size(71, 30)
        Me.cmdSaveLine.TabIndex = 26
        Me.cmdSaveLine.Text = "Save"
        Me.cmdSaveLine.UseVisualStyleBackColor = True
        '
        'cboQuoteLineDescription
        '
        Me.cboQuoteLineDescription.DataSource = Me.ItemListBindingSource
        Me.cboQuoteLineDescription.DisplayMember = "ShortDescription"
        Me.cboQuoteLineDescription.FormattingEnabled = True
        Me.cboQuoteLineDescription.Location = New System.Drawing.Point(11, 84)
        Me.cboQuoteLineDescription.Name = "cboQuoteLineDescription"
        Me.cboQuoteLineDescription.Size = New System.Drawing.Size(305, 21)
        Me.cboQuoteLineDescription.TabIndex = 20
        '
        'cboQuoteLinePart
        '
        Me.cboQuoteLinePart.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboQuoteLinePart.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboQuoteLinePart.DataSource = Me.ItemListBindingSource
        Me.cboQuoteLinePart.DisplayMember = "ItemID"
        Me.cboQuoteLinePart.FormattingEnabled = True
        Me.cboQuoteLinePart.Location = New System.Drawing.Point(62, 53)
        Me.cboQuoteLinePart.Name = "cboQuoteLinePart"
        Me.cboQuoteLinePart.Size = New System.Drawing.Size(254, 21)
        Me.cboQuoteLinePart.TabIndex = 19
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(8, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(108, 20)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "Quote Line #"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboQuoteLineNumber
        '
        Me.cboQuoteLineNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboQuoteLineNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboQuoteLineNumber.DataSource = Me.SalesOrderLineTableBindingSource
        Me.cboQuoteLineNumber.DisplayMember = "SalesOrderLineKey"
        Me.cboQuoteLineNumber.FormattingEnabled = True
        Me.cboQuoteLineNumber.Location = New System.Drawing.Point(149, 22)
        Me.cboQuoteLineNumber.Name = "cboQuoteLineNumber"
        Me.cboQuoteLineNumber.Size = New System.Drawing.Size(167, 21)
        Me.cboQuoteLineNumber.TabIndex = 18
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(8, 54)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(108, 20)
        Me.Label18.TabIndex = 28
        Me.Label18.Text = "Part #"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(9, 237)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(108, 20)
        Me.Label31.TabIndex = 40
        Me.Label31.Text = "Line Comment"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(8, 205)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(108, 20)
        Me.Label30.TabIndex = 39
        Me.Label30.Text = "Lead Time"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(8, 175)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(108, 20)
        Me.Label29.TabIndex = 38
        Me.Label29.Text = "Extended Amount"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(8, 145)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(108, 20)
        Me.Label28.TabIndex = 37
        Me.Label28.Text = "Price"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(8, 115)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(108, 20)
        Me.Label27.TabIndex = 36
        Me.Label27.Text = "Quantity"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'QuoteForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.tabQuoteData)
        Me.Controls.Add(Me.gpxQuoteTotals)
        Me.Controls.Add(Me.cmdCustomerSalesHistory)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdOpenOrders)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdConvertToSO)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.gpxGeneralInfo)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "QuoteForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Quote Form"
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxGeneralInfo.ResumeLayout(False)
        Me.gpxGeneralInfo.PerformLayout()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.AdditionalShipToBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxQuoteTotals.ResumeLayout(False)
        Me.gpxQuoteTotals.PerformLayout()
        CType(Me.dgvSalesOrderLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabQuoteData.ResumeLayout(False)
        Me.tabQuoteLines.ResumeLayout(False)
        Me.tabAdditionalData.ResumeLayout(False)
        Me.tabAdditionalData.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabQuoteLineDetails.ResumeLayout(False)
        Me.tabQuoteLineDetails.PerformLayout()
        Me.tabDeleteLines.ResumeLayout(False)
        Me.tabDeleteLines.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label105 As System.Windows.Forms.Label
    Friend WithEvents Label108 As System.Windows.Forms.Label
    Friend WithEvents Label109 As System.Windows.Forms.Label
    Friend WithEvents Label113 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents gpxGeneralInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label107 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents EditToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdConvertToSO As System.Windows.Forms.Button
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdOpenOrders As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Label106 As System.Windows.Forms.Label
    Friend WithEvents lblDivisionID As System.Windows.Forms.Label
    Friend WithEvents Label112 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cboSalesperson As System.Windows.Forms.ComboBox
    Friend WithEvents dtpDeliveryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label114 As System.Windows.Forms.Label
    Friend WithEvents cboQuoteNumber As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdCustomerSalesHistory As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label222 As System.Windows.Forms.Label
    Friend WithEvents gpxQuoteTotals As System.Windows.Forms.GroupBox
    Friend WithEvents lblProductTotal As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblQuoteTotal As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstimatedWeight As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdGenerateNewQuote As System.Windows.Forms.Button
    Friend WithEvents txtFreightCharge As System.Windows.Forms.TextBox
    Friend WithEvents lblFreightCharge As System.Windows.Forms.Label
    Friend WithEvents chkTaxable As System.Windows.Forms.CheckBox
    Friend WithEvents LabelGSTTotal As System.Windows.Forms.Label
    Friend WithEvents lblSalesTax As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents QuantityOpenDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityShippedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClearAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents dgvSalesOrderLines As System.Windows.Forms.DataGridView
    Friend WithEvents SalesOrderLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderLineTableTableAdapter
    Friend WithEvents ClearQuoteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtShipToCountry As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtShipToZip As System.Windows.Forms.TextBox
    Friend WithEvents txtShipToState As System.Windows.Forms.TextBox
    Friend WithEvents txtShipToCity As System.Windows.Forms.TextBox
    Friend WithEvents txtShipToAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtShipToAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLineComment As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblQOH As System.Windows.Forms.Label
    Friend WithEvents txtExtendedAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkNewCustomer As System.Windows.Forms.CheckBox
    Friend WithEvents txtLeadDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtLinePrice As System.Windows.Forms.TextBox
    Friend WithEvents txtTaxRate As System.Windows.Forms.TextBox
    Friend WithEvents cmdRemoveSalesTax As System.Windows.Forms.Button
    Friend WithEvents lblLastPurchaseCost As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboShipVia As System.Windows.Forms.ComboBox
    Friend WithEvents ShipMethodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipMethodTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
    Friend WithEvents cboShipToID As System.Windows.Forms.ComboBox
    Friend WithEvents txtShipToName As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents AdditionalShipToBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AdditionalShipToTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AdditionalShipToTableAdapter
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tabQuoteData As System.Windows.Forms.TabControl
    Friend WithEvents tabQuoteLines As System.Windows.Forms.TabPage
    Friend WithEvents tabAdditionalData As System.Windows.Forms.TabPage
    Friend WithEvents lblHSTExtendedAmount As System.Windows.Forms.Label
    Friend WithEvents LabelPSTTotal As System.Windows.Forms.Label
    Friend WithEvents lblPSTExtendedAmount As System.Windows.Forms.Label
    Friend WithEvents LabelHSTTotal As System.Windows.Forms.Label
    Friend WithEvents lblLongDescription As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtSpecialInstructions As System.Windows.Forms.TextBox
    Friend WithEvents txtHSTRate As System.Windows.Forms.TextBox
    Friend WithEvents chkADDPST As System.Windows.Forms.CheckBox
    Friend WithEvents chkADDHST As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabQuoteLineDetails As System.Windows.Forms.TabPage
    Friend WithEvents tabDeleteLines As System.Windows.Forms.TabPage
    Friend WithEvents cboQuoteLineDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboQuoteLinePart As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboQuoteLineNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtQuoteLineLeadTime As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtQuoteLinePrice As System.Windows.Forms.TextBox
    Friend WithEvents txtQuoteExtendedAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtQuoteLineComment As System.Windows.Forms.TextBox
    Friend WithEvents txtQuoteLineQuantity As System.Windows.Forms.TextBox
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents cmdSaveLine As System.Windows.Forms.Button
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents ConvertToSalesOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SalesOrderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeadTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineBoxesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents llCustomerID As System.Windows.Forms.LinkLabel
    Friend WithEvents llPriceLookup As System.Windows.Forms.LinkLabel
    Friend WithEvents PricingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboShipMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtThirdPartyShipper As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents dtpQuoteDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblUpdatedPrice As System.Windows.Forms.Label
    Friend WithEvents lblQuantityAvailable As System.Windows.Forms.Label
End Class
