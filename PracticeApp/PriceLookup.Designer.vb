<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PriceLookup
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
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.lblItemNumber = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtYTDQuantity = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtMTDQuantity = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtOpenPOQuantity = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtStdCost = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtQtyPending = New System.Windows.Forms.TextBox
        Me.txtStdPrice = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPalletPieces = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPalletWeight = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBoxWeight = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPalletCount = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.lblLastPurchaseCost = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtLastPurchaseCost = New System.Windows.Forms.TextBox
        Me.txtQuantityOnHand = New System.Windows.Forms.TextBox
        Me.txtBoxCount = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtPieceWeight = New System.Windows.Forms.TextBox
        Me.txtPrice13 = New System.Windows.Forms.TextBox
        Me.txtPrice12 = New System.Windows.Forms.TextBox
        Me.txtPrice11 = New System.Windows.Forms.TextBox
        Me.txtPrice10 = New System.Windows.Forms.TextBox
        Me.txtPrice9 = New System.Windows.Forms.TextBox
        Me.txtPrice8 = New System.Windows.Forms.TextBox
        Me.txtPrice7 = New System.Windows.Forms.TextBox
        Me.txtPrice6 = New System.Windows.Forms.TextBox
        Me.txtPrice5 = New System.Windows.Forms.TextBox
        Me.txtPrice4 = New System.Windows.Forms.TextBox
        Me.txtPrice3 = New System.Windows.Forms.TextBox
        Me.txtPrice2 = New System.Windows.Forms.TextBox
        Me.txtPrice1 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtLastSalesPrice = New System.Windows.Forms.TextBox
        Me.tabPriceControl = New System.Windows.Forms.TabControl
        Me.tabItemdata = New System.Windows.Forms.TabPage
        Me.lblUpdatedPrice = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.tabCustomerPricing = New System.Windows.Forms.TabPage
        Me.dgvSalesHistory = New System.Windows.Forms.DataGridView
        Me.CustomerIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionKeyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineWeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineBoxesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalespersonDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LeadTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipViaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeaderCommentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRONumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdditionalShipToDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CertificationTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DropShipPONumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SpecialInstructionsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstExtendedCOSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOBDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerClassDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippedPreviousDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SalesOrderLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderLineQueryTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.lstPartDescriptionSuggest = New System.Windows.Forms.ListBox
        Me.lblPricingReview = New System.Windows.Forms.Label
        Me.lblPaymentTerms = New System.Windows.Forms.Label
        Me.lblOnHoldStatus = New System.Windows.Forms.Label
        Me.lblAccountingHold = New System.Windows.Forms.Label
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPriceControl.SuspendLayout()
        Me.tabItemdata.SuspendLayout()
        Me.tabCustomerPricing.SuspendLayout()
        CType(Me.dgvSalesHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(6, 42)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(302, 21)
        Me.cboCustomerName.TabIndex = 106
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
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(86, 12)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(222, 21)
        Me.cboCustomerID.TabIndex = 105
        Me.cboCustomerID.ValueMember = "ItemClassID"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(6, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 20)
        Me.Label6.TabIndex = 110
        Me.Label6.Text = "Customer ID"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartDescription
        '
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(358, 41)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(302, 21)
        Me.cboPartDescription.TabIndex = 108
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(438, 12)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(222, 21)
        Me.cboPartNumber.TabIndex = 107
        Me.cboPartNumber.ValueMember = "ItemClassID"
        '
        'lblItemNumber
        '
        Me.lblItemNumber.Location = New System.Drawing.Point(358, 12)
        Me.lblItemNumber.Name = "lblItemNumber"
        Me.lblItemNumber.Size = New System.Drawing.Size(107, 20)
        Me.lblItemNumber.TabIndex = 109
        Me.lblItemNumber.Text = "Part Number"
        Me.lblItemNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(15, 170)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(151, 20)
        Me.Label14.TabIndex = 149
        Me.Label14.Text = "YTD Quantity Sold"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtYTDQuantity
        '
        Me.txtYTDQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYTDQuantity.Location = New System.Drawing.Point(169, 170)
        Me.txtYTDQuantity.Name = "txtYTDQuantity"
        Me.txtYTDQuantity.Size = New System.Drawing.Size(148, 20)
        Me.txtYTDQuantity.TabIndex = 127
        Me.txtYTDQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(15, 145)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(151, 20)
        Me.Label16.TabIndex = 148
        Me.Label16.Text = "MTD Quantity Sold"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMTDQuantity
        '
        Me.txtMTDQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMTDQuantity.Location = New System.Drawing.Point(169, 145)
        Me.txtMTDQuantity.Name = "txtMTDQuantity"
        Me.txtMTDQuantity.Size = New System.Drawing.Size(148, 20)
        Me.txtMTDQuantity.TabIndex = 126
        Me.txtMTDQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(15, 120)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(151, 20)
        Me.Label13.TabIndex = 147
        Me.Label13.Text = "Open PO Qty."
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOpenPOQuantity
        '
        Me.txtOpenPOQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOpenPOQuantity.Location = New System.Drawing.Point(169, 120)
        Me.txtOpenPOQuantity.Name = "txtOpenPOQuantity"
        Me.txtOpenPOQuantity.Size = New System.Drawing.Size(148, 20)
        Me.txtOpenPOQuantity.TabIndex = 125
        Me.txtOpenPOQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(15, 195)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(151, 20)
        Me.Label11.TabIndex = 146
        Me.Label11.Text = "Std Unit Cost"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtStdCost
        '
        Me.txtStdCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStdCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStdCost.ForeColor = System.Drawing.Color.Black
        Me.txtStdCost.Location = New System.Drawing.Point(169, 195)
        Me.txtStdCost.Name = "txtStdCost"
        Me.txtStdCost.Size = New System.Drawing.Size(148, 20)
        Me.txtStdCost.TabIndex = 128
        Me.txtStdCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(15, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(151, 20)
        Me.Label9.TabIndex = 145
        Me.Label9.Text = "Committed Quantity"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(15, 220)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(151, 20)
        Me.Label10.TabIndex = 144
        Me.Label10.Text = "Std Unit Price"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQtyPending
        '
        Me.txtQtyPending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQtyPending.Location = New System.Drawing.Point(169, 95)
        Me.txtQtyPending.Name = "txtQtyPending"
        Me.txtQtyPending.Size = New System.Drawing.Size(148, 20)
        Me.txtQtyPending.TabIndex = 124
        Me.txtQtyPending.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtStdPrice
        '
        Me.txtStdPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStdPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStdPrice.ForeColor = System.Drawing.Color.Black
        Me.txtStdPrice.Location = New System.Drawing.Point(169, 220)
        Me.txtStdPrice.Name = "txtStdPrice"
        Me.txtStdPrice.Size = New System.Drawing.Size(148, 20)
        Me.txtStdPrice.TabIndex = 129
        Me.txtStdPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(15, 345)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(151, 20)
        Me.Label4.TabIndex = 143
        Me.Label4.Text = "Pallet Count (# pieces)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPalletPieces
        '
        Me.txtPalletPieces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPalletPieces.Location = New System.Drawing.Point(169, 345)
        Me.txtPalletPieces.Name = "txtPalletPieces"
        Me.txtPalletPieces.Size = New System.Drawing.Size(148, 20)
        Me.txtPalletPieces.TabIndex = 134
        Me.txtPalletPieces.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(15, 370)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 20)
        Me.Label3.TabIndex = 142
        Me.Label3.Text = "Pallet Weight"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPalletWeight
        '
        Me.txtPalletWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPalletWeight.Location = New System.Drawing.Point(169, 370)
        Me.txtPalletWeight.Name = "txtPalletWeight"
        Me.txtPalletWeight.Size = New System.Drawing.Size(148, 20)
        Me.txtPalletWeight.TabIndex = 135
        Me.txtPalletWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 295)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 20)
        Me.Label1.TabIndex = 141
        Me.Label1.Text = "Box Weight"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBoxWeight
        '
        Me.txtBoxWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxWeight.Location = New System.Drawing.Point(169, 295)
        Me.txtBoxWeight.Name = "txtBoxWeight"
        Me.txtBoxWeight.Size = New System.Drawing.Size(148, 20)
        Me.txtBoxWeight.TabIndex = 132
        Me.txtBoxWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(15, 320)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 20)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "Pallet Count (# boxes)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPalletCount
        '
        Me.txtPalletCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPalletCount.Location = New System.Drawing.Point(169, 320)
        Me.txtPalletCount.Name = "txtPalletCount"
        Me.txtPalletCount.Size = New System.Drawing.Size(148, 20)
        Me.txtPalletCount.TabIndex = 133
        Me.txtPalletCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(15, 270)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(151, 20)
        Me.Label22.TabIndex = 139
        Me.Label22.Text = "Box Count"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLastPurchaseCost
        '
        Me.lblLastPurchaseCost.Location = New System.Drawing.Point(15, 45)
        Me.lblLastPurchaseCost.Name = "lblLastPurchaseCost"
        Me.lblLastPurchaseCost.Size = New System.Drawing.Size(151, 20)
        Me.lblLastPurchaseCost.TabIndex = 138
        Me.lblLastPurchaseCost.Text = "Last Purchase Cost"
        Me.lblLastPurchaseCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(15, 70)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(151, 20)
        Me.Label25.TabIndex = 137
        Me.Label25.Text = "Quantity On Hand"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLastPurchaseCost
        '
        Me.txtLastPurchaseCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastPurchaseCost.Location = New System.Drawing.Point(169, 45)
        Me.txtLastPurchaseCost.Name = "txtLastPurchaseCost"
        Me.txtLastPurchaseCost.Size = New System.Drawing.Size(148, 20)
        Me.txtLastPurchaseCost.TabIndex = 122
        Me.txtLastPurchaseCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuantityOnHand
        '
        Me.txtQuantityOnHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantityOnHand.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantityOnHand.ForeColor = System.Drawing.Color.Black
        Me.txtQuantityOnHand.Location = New System.Drawing.Point(169, 70)
        Me.txtQuantityOnHand.Name = "txtQuantityOnHand"
        Me.txtQuantityOnHand.Size = New System.Drawing.Size(148, 20)
        Me.txtQuantityOnHand.TabIndex = 123
        Me.txtQuantityOnHand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBoxCount
        '
        Me.txtBoxCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxCount.Location = New System.Drawing.Point(169, 270)
        Me.txtBoxCount.Name = "txtBoxCount"
        Me.txtBoxCount.Size = New System.Drawing.Size(148, 20)
        Me.txtBoxCount.TabIndex = 131
        Me.txtBoxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(15, 245)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(151, 20)
        Me.Label17.TabIndex = 136
        Me.Label17.Text = "Piece Weight"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPieceWeight
        '
        Me.txtPieceWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPieceWeight.Location = New System.Drawing.Point(169, 245)
        Me.txtPieceWeight.Name = "txtPieceWeight"
        Me.txtPieceWeight.Size = New System.Drawing.Size(148, 20)
        Me.txtPieceWeight.TabIndex = 130
        Me.txtPieceWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrice13
        '
        Me.txtPrice13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice13.Location = New System.Drawing.Point(487, 368)
        Me.txtPrice13.Name = "txtPrice13"
        Me.txtPrice13.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice13.TabIndex = 174
        Me.txtPrice13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrice12
        '
        Me.txtPrice12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice12.Location = New System.Drawing.Point(487, 342)
        Me.txtPrice12.Name = "txtPrice12"
        Me.txtPrice12.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice12.TabIndex = 172
        Me.txtPrice12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrice11
        '
        Me.txtPrice11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice11.Location = New System.Drawing.Point(487, 316)
        Me.txtPrice11.Name = "txtPrice11"
        Me.txtPrice11.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice11.TabIndex = 170
        Me.txtPrice11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrice10
        '
        Me.txtPrice10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice10.Location = New System.Drawing.Point(487, 290)
        Me.txtPrice10.Name = "txtPrice10"
        Me.txtPrice10.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice10.TabIndex = 168
        Me.txtPrice10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrice9
        '
        Me.txtPrice9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice9.Location = New System.Drawing.Point(487, 264)
        Me.txtPrice9.Name = "txtPrice9"
        Me.txtPrice9.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice9.TabIndex = 166
        Me.txtPrice9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrice8
        '
        Me.txtPrice8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice8.Location = New System.Drawing.Point(487, 238)
        Me.txtPrice8.Name = "txtPrice8"
        Me.txtPrice8.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice8.TabIndex = 164
        Me.txtPrice8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrice7
        '
        Me.txtPrice7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice7.Location = New System.Drawing.Point(487, 212)
        Me.txtPrice7.Name = "txtPrice7"
        Me.txtPrice7.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice7.TabIndex = 162
        Me.txtPrice7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrice6
        '
        Me.txtPrice6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice6.Location = New System.Drawing.Point(487, 186)
        Me.txtPrice6.Name = "txtPrice6"
        Me.txtPrice6.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice6.TabIndex = 160
        Me.txtPrice6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrice5
        '
        Me.txtPrice5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice5.Location = New System.Drawing.Point(487, 160)
        Me.txtPrice5.Name = "txtPrice5"
        Me.txtPrice5.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice5.TabIndex = 158
        Me.txtPrice5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrice4
        '
        Me.txtPrice4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice4.Location = New System.Drawing.Point(487, 134)
        Me.txtPrice4.Name = "txtPrice4"
        Me.txtPrice4.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice4.TabIndex = 156
        Me.txtPrice4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrice3
        '
        Me.txtPrice3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice3.Location = New System.Drawing.Point(487, 108)
        Me.txtPrice3.Name = "txtPrice3"
        Me.txtPrice3.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice3.TabIndex = 154
        Me.txtPrice3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrice2
        '
        Me.txtPrice2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice2.Location = New System.Drawing.Point(487, 82)
        Me.txtPrice2.Name = "txtPrice2"
        Me.txtPrice2.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice2.TabIndex = 152
        Me.txtPrice2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrice1
        '
        Me.txtPrice1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice1.Location = New System.Drawing.Point(487, 56)
        Me.txtPrice1.Name = "txtPrice1"
        Me.txtPrice1.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice1.TabIndex = 150
        Me.txtPrice1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(360, 367)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(145, 23)
        Me.Label5.TabIndex = 175
        Me.Label5.Text = "100,000 and over"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(360, 341)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(145, 23)
        Me.Label7.TabIndex = 173
        Me.Label7.Text = "50,000 to 99,999 pcs."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(360, 315)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(145, 23)
        Me.Label8.TabIndex = 171
        Me.Label8.Text = "25,000 to 49,999 pcs."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(360, 289)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(145, 23)
        Me.Label12.TabIndex = 169
        Me.Label12.Text = "10,000 to 24,999 pcs."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(360, 263)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(145, 23)
        Me.Label15.TabIndex = 167
        Me.Label15.Text = "5,000 to 9,999 pcs."
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(360, 237)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(145, 23)
        Me.Label18.TabIndex = 165
        Me.Label18.Text = "2,500 to 4,999 pcs."
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(360, 211)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(145, 23)
        Me.Label19.TabIndex = 163
        Me.Label19.Text = "1,000 to 2,499 pcs."
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(360, 185)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(145, 23)
        Me.Label20.TabIndex = 161
        Me.Label20.Text = "750 to 999 pcs."
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(360, 159)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(145, 23)
        Me.Label21.TabIndex = 159
        Me.Label21.Text = "500 to 749 pcs."
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(360, 134)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(145, 23)
        Me.Label23.TabIndex = 157
        Me.Label23.Text = "400 to 499 pcs."
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(360, 107)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(145, 23)
        Me.Label24.TabIndex = 155
        Me.Label24.Text = "300 to 399 pcs."
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(360, 81)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(145, 23)
        Me.Label26.TabIndex = 153
        Me.Label26.Text = "200 to 299 pcs."
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(360, 55)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(145, 23)
        Me.Label27.TabIndex = 151
        Me.Label27.Text = "100 to 199 pcs."
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(15, 19)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(151, 20)
        Me.Label28.TabIndex = 177
        Me.Label28.Text = "Last Sales Price"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLastSalesPrice
        '
        Me.txtLastSalesPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastSalesPrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastSalesPrice.Location = New System.Drawing.Point(169, 19)
        Me.txtLastSalesPrice.Name = "txtLastSalesPrice"
        Me.txtLastSalesPrice.Size = New System.Drawing.Size(148, 20)
        Me.txtLastSalesPrice.TabIndex = 176
        Me.txtLastSalesPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tabPriceControl
        '
        Me.tabPriceControl.Controls.Add(Me.tabItemdata)
        Me.tabPriceControl.Controls.Add(Me.tabCustomerPricing)
        Me.tabPriceControl.Location = New System.Drawing.Point(6, 163)
        Me.tabPriceControl.Name = "tabPriceControl"
        Me.tabPriceControl.SelectedIndex = 0
        Me.tabPriceControl.Size = New System.Drawing.Size(662, 449)
        Me.tabPriceControl.TabIndex = 178
        '
        'tabItemdata
        '
        Me.tabItemdata.Controls.Add(Me.lblUpdatedPrice)
        Me.tabItemdata.Controls.Add(Me.Label29)
        Me.tabItemdata.Controls.Add(Me.Label28)
        Me.tabItemdata.Controls.Add(Me.txtLastSalesPrice)
        Me.tabItemdata.Controls.Add(Me.Label14)
        Me.tabItemdata.Controls.Add(Me.txtYTDQuantity)
        Me.tabItemdata.Controls.Add(Me.txtPrice13)
        Me.tabItemdata.Controls.Add(Me.Label16)
        Me.tabItemdata.Controls.Add(Me.txtMTDQuantity)
        Me.tabItemdata.Controls.Add(Me.txtPrice12)
        Me.tabItemdata.Controls.Add(Me.Label13)
        Me.tabItemdata.Controls.Add(Me.txtOpenPOQuantity)
        Me.tabItemdata.Controls.Add(Me.txtPrice11)
        Me.tabItemdata.Controls.Add(Me.Label11)
        Me.tabItemdata.Controls.Add(Me.txtStdCost)
        Me.tabItemdata.Controls.Add(Me.txtPrice10)
        Me.tabItemdata.Controls.Add(Me.Label9)
        Me.tabItemdata.Controls.Add(Me.Label10)
        Me.tabItemdata.Controls.Add(Me.txtPrice9)
        Me.tabItemdata.Controls.Add(Me.txtQtyPending)
        Me.tabItemdata.Controls.Add(Me.txtStdPrice)
        Me.tabItemdata.Controls.Add(Me.txtPrice8)
        Me.tabItemdata.Controls.Add(Me.Label4)
        Me.tabItemdata.Controls.Add(Me.txtPalletPieces)
        Me.tabItemdata.Controls.Add(Me.txtPrice7)
        Me.tabItemdata.Controls.Add(Me.Label3)
        Me.tabItemdata.Controls.Add(Me.txtPalletWeight)
        Me.tabItemdata.Controls.Add(Me.txtPrice6)
        Me.tabItemdata.Controls.Add(Me.Label1)
        Me.tabItemdata.Controls.Add(Me.txtBoxWeight)
        Me.tabItemdata.Controls.Add(Me.txtPrice5)
        Me.tabItemdata.Controls.Add(Me.Label2)
        Me.tabItemdata.Controls.Add(Me.txtPalletCount)
        Me.tabItemdata.Controls.Add(Me.txtPrice4)
        Me.tabItemdata.Controls.Add(Me.Label22)
        Me.tabItemdata.Controls.Add(Me.lblLastPurchaseCost)
        Me.tabItemdata.Controls.Add(Me.txtPrice3)
        Me.tabItemdata.Controls.Add(Me.Label25)
        Me.tabItemdata.Controls.Add(Me.txtPrice1)
        Me.tabItemdata.Controls.Add(Me.txtLastPurchaseCost)
        Me.tabItemdata.Controls.Add(Me.txtPrice2)
        Me.tabItemdata.Controls.Add(Me.txtQuantityOnHand)
        Me.tabItemdata.Controls.Add(Me.txtPieceWeight)
        Me.tabItemdata.Controls.Add(Me.txtBoxCount)
        Me.tabItemdata.Controls.Add(Me.Label17)
        Me.tabItemdata.Controls.Add(Me.Label27)
        Me.tabItemdata.Controls.Add(Me.Label26)
        Me.tabItemdata.Controls.Add(Me.Label24)
        Me.tabItemdata.Controls.Add(Me.Label23)
        Me.tabItemdata.Controls.Add(Me.Label21)
        Me.tabItemdata.Controls.Add(Me.Label20)
        Me.tabItemdata.Controls.Add(Me.Label19)
        Me.tabItemdata.Controls.Add(Me.Label18)
        Me.tabItemdata.Controls.Add(Me.Label15)
        Me.tabItemdata.Controls.Add(Me.Label12)
        Me.tabItemdata.Controls.Add(Me.Label8)
        Me.tabItemdata.Controls.Add(Me.Label7)
        Me.tabItemdata.Controls.Add(Me.Label5)
        Me.tabItemdata.Location = New System.Drawing.Point(4, 22)
        Me.tabItemdata.Name = "tabItemdata"
        Me.tabItemdata.Padding = New System.Windows.Forms.Padding(3)
        Me.tabItemdata.Size = New System.Drawing.Size(654, 423)
        Me.tabItemdata.TabIndex = 0
        Me.tabItemdata.Text = "Item Data"
        Me.tabItemdata.UseVisualStyleBackColor = True
        '
        'lblUpdatedPrice
        '
        Me.lblUpdatedPrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lblUpdatedPrice.ForeColor = System.Drawing.Color.Red
        Me.lblUpdatedPrice.Location = New System.Drawing.Point(130, 20)
        Me.lblUpdatedPrice.Name = "lblUpdatedPrice"
        Me.lblUpdatedPrice.Size = New System.Drawing.Size(36, 20)
        Me.lblUpdatedPrice.TabIndex = 181
        Me.lblUpdatedPrice.Text = "***"
        Me.lblUpdatedPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblUpdatedPrice.Visible = False
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(360, 17)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(268, 23)
        Me.Label29.TabIndex = 178
        Me.Label29.Text = "Price Levels"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabCustomerPricing
        '
        Me.tabCustomerPricing.Controls.Add(Me.dgvSalesHistory)
        Me.tabCustomerPricing.Location = New System.Drawing.Point(4, 22)
        Me.tabCustomerPricing.Name = "tabCustomerPricing"
        Me.tabCustomerPricing.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCustomerPricing.Size = New System.Drawing.Size(654, 423)
        Me.tabCustomerPricing.TabIndex = 1
        Me.tabCustomerPricing.Text = "Sales History"
        Me.tabCustomerPricing.UseVisualStyleBackColor = True
        '
        'dgvSalesHistory
        '
        Me.dgvSalesHistory.AllowUserToAddRows = False
        Me.dgvSalesHistory.AllowUserToDeleteRows = False
        Me.dgvSalesHistory.AutoGenerateColumns = False
        Me.dgvSalesHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSalesHistory.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSalesHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSalesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSalesHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerIDDataGridViewTextBoxColumn, Me.SalesOrderKeyColumn, Me.SalesOrderLineKeyColumn, Me.SalesOrderDateColumn, Me.ItemIDColumn, Me.DescriptionColumn, Me.QuantityColumn, Me.PriceColumn, Me.SalesTaxColumn, Me.ExtendedAmountColumn, Me.LineCommentDataGridViewTextBoxColumn, Me.LineStatusDataGridViewTextBoxColumn, Me.DivisionKeyDataGridViewTextBoxColumn, Me.LineWeightDataGridViewTextBoxColumn, Me.LineBoxesDataGridViewTextBoxColumn, Me.SOStatusDataGridViewTextBoxColumn, Me.DebitGLAccountDataGridViewTextBoxColumn, Me.CreditGLAccountDataGridViewTextBoxColumn, Me.CustomerPODataGridViewTextBoxColumn, Me.SalespersonDataGridViewTextBoxColumn, Me.LeadTimeDataGridViewTextBoxColumn, Me.ShippingDateDataGridViewTextBoxColumn, Me.ShipViaDataGridViewTextBoxColumn, Me.HeaderCommentDataGridViewTextBoxColumn, Me.PRONumberDataGridViewTextBoxColumn, Me.AdditionalShipToDataGridViewTextBoxColumn, Me.CertificationTypeDataGridViewTextBoxColumn, Me.DropShipPONumberDataGridViewTextBoxColumn, Me.SpecialInstructionsDataGridViewTextBoxColumn, Me.CustomerPOTypeDataGridViewTextBoxColumn, Me.EstExtendedCOSDataGridViewTextBoxColumn, Me.FOBDataGridViewTextBoxColumn, Me.CustomerClassDataGridViewTextBoxColumn, Me.ShippedPreviousDataGridViewTextBoxColumn})
        Me.dgvSalesHistory.DataSource = Me.SalesOrderLineQueryBindingSource
        Me.dgvSalesHistory.GridColor = System.Drawing.Color.Purple
        Me.dgvSalesHistory.Location = New System.Drawing.Point(0, 0)
        Me.dgvSalesHistory.Name = "dgvSalesHistory"
        Me.dgvSalesHistory.ReadOnly = True
        Me.dgvSalesHistory.Size = New System.Drawing.Size(654, 423)
        Me.dgvSalesHistory.TabIndex = 0
        '
        'CustomerIDDataGridViewTextBoxColumn
        '
        Me.CustomerIDDataGridViewTextBoxColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDDataGridViewTextBoxColumn.HeaderText = "Customer"
        Me.CustomerIDDataGridViewTextBoxColumn.Name = "CustomerIDDataGridViewTextBoxColumn"
        Me.CustomerIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SalesOrderKeyColumn
        '
        Me.SalesOrderKeyColumn.DataPropertyName = "SalesOrderKey"
        Me.SalesOrderKeyColumn.HeaderText = "SO #"
        Me.SalesOrderKeyColumn.Name = "SalesOrderKeyColumn"
        Me.SalesOrderKeyColumn.ReadOnly = True
        '
        'SalesOrderLineKeyColumn
        '
        Me.SalesOrderLineKeyColumn.DataPropertyName = "SalesOrderLineKey"
        Me.SalesOrderLineKeyColumn.HeaderText = "SalesOrderLineKey"
        Me.SalesOrderLineKeyColumn.Name = "SalesOrderLineKeyColumn"
        Me.SalesOrderLineKeyColumn.ReadOnly = True
        Me.SalesOrderLineKeyColumn.Visible = False
        '
        'SalesOrderDateColumn
        '
        Me.SalesOrderDateColumn.DataPropertyName = "SalesOrderDate"
        Me.SalesOrderDateColumn.HeaderText = "SO Date"
        Me.SalesOrderDateColumn.Name = "SalesOrderDateColumn"
        Me.SalesOrderDateColumn.ReadOnly = True
        '
        'ItemIDColumn
        '
        Me.ItemIDColumn.DataPropertyName = "ItemID"
        Me.ItemIDColumn.HeaderText = "ItemID"
        Me.ItemIDColumn.Name = "ItemIDColumn"
        Me.ItemIDColumn.ReadOnly = True
        Me.ItemIDColumn.Visible = False
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        Me.DescriptionColumn.ReadOnly = True
        Me.DescriptionColumn.Visible = False
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.ReadOnly = True
        '
        'PriceColumn
        '
        Me.PriceColumn.DataPropertyName = "Price"
        Me.PriceColumn.HeaderText = "Price"
        Me.PriceColumn.Name = "PriceColumn"
        Me.PriceColumn.ReadOnly = True
        '
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        Me.SalesTaxColumn.HeaderText = "SalesTax"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        Me.SalesTaxColumn.ReadOnly = True
        Me.SalesTaxColumn.Visible = False
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        Me.ExtendedAmountColumn.HeaderText = "ExtendedAmount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
        Me.ExtendedAmountColumn.Visible = False
        '
        'LineCommentDataGridViewTextBoxColumn
        '
        Me.LineCommentDataGridViewTextBoxColumn.DataPropertyName = "LineComment"
        Me.LineCommentDataGridViewTextBoxColumn.HeaderText = "LineComment"
        Me.LineCommentDataGridViewTextBoxColumn.Name = "LineCommentDataGridViewTextBoxColumn"
        Me.LineCommentDataGridViewTextBoxColumn.ReadOnly = True
        Me.LineCommentDataGridViewTextBoxColumn.Visible = False
        '
        'LineStatusDataGridViewTextBoxColumn
        '
        Me.LineStatusDataGridViewTextBoxColumn.DataPropertyName = "LineStatus"
        Me.LineStatusDataGridViewTextBoxColumn.HeaderText = "LineStatus"
        Me.LineStatusDataGridViewTextBoxColumn.Name = "LineStatusDataGridViewTextBoxColumn"
        Me.LineStatusDataGridViewTextBoxColumn.ReadOnly = True
        Me.LineStatusDataGridViewTextBoxColumn.Visible = False
        '
        'DivisionKeyDataGridViewTextBoxColumn
        '
        Me.DivisionKeyDataGridViewTextBoxColumn.DataPropertyName = "DivisionKey"
        Me.DivisionKeyDataGridViewTextBoxColumn.HeaderText = "DivisionKey"
        Me.DivisionKeyDataGridViewTextBoxColumn.Name = "DivisionKeyDataGridViewTextBoxColumn"
        Me.DivisionKeyDataGridViewTextBoxColumn.ReadOnly = True
        Me.DivisionKeyDataGridViewTextBoxColumn.Visible = False
        '
        'LineWeightDataGridViewTextBoxColumn
        '
        Me.LineWeightDataGridViewTextBoxColumn.DataPropertyName = "LineWeight"
        Me.LineWeightDataGridViewTextBoxColumn.HeaderText = "LineWeight"
        Me.LineWeightDataGridViewTextBoxColumn.Name = "LineWeightDataGridViewTextBoxColumn"
        Me.LineWeightDataGridViewTextBoxColumn.ReadOnly = True
        Me.LineWeightDataGridViewTextBoxColumn.Visible = False
        '
        'LineBoxesDataGridViewTextBoxColumn
        '
        Me.LineBoxesDataGridViewTextBoxColumn.DataPropertyName = "LineBoxes"
        Me.LineBoxesDataGridViewTextBoxColumn.HeaderText = "LineBoxes"
        Me.LineBoxesDataGridViewTextBoxColumn.Name = "LineBoxesDataGridViewTextBoxColumn"
        Me.LineBoxesDataGridViewTextBoxColumn.ReadOnly = True
        Me.LineBoxesDataGridViewTextBoxColumn.Visible = False
        '
        'SOStatusDataGridViewTextBoxColumn
        '
        Me.SOStatusDataGridViewTextBoxColumn.DataPropertyName = "SOStatus"
        Me.SOStatusDataGridViewTextBoxColumn.HeaderText = "SOStatus"
        Me.SOStatusDataGridViewTextBoxColumn.Name = "SOStatusDataGridViewTextBoxColumn"
        Me.SOStatusDataGridViewTextBoxColumn.ReadOnly = True
        Me.SOStatusDataGridViewTextBoxColumn.Visible = False
        '
        'DebitGLAccountDataGridViewTextBoxColumn
        '
        Me.DebitGLAccountDataGridViewTextBoxColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountDataGridViewTextBoxColumn.HeaderText = "DebitGLAccount"
        Me.DebitGLAccountDataGridViewTextBoxColumn.Name = "DebitGLAccountDataGridViewTextBoxColumn"
        Me.DebitGLAccountDataGridViewTextBoxColumn.ReadOnly = True
        Me.DebitGLAccountDataGridViewTextBoxColumn.Visible = False
        '
        'CreditGLAccountDataGridViewTextBoxColumn
        '
        Me.CreditGLAccountDataGridViewTextBoxColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountDataGridViewTextBoxColumn.HeaderText = "CreditGLAccount"
        Me.CreditGLAccountDataGridViewTextBoxColumn.Name = "CreditGLAccountDataGridViewTextBoxColumn"
        Me.CreditGLAccountDataGridViewTextBoxColumn.ReadOnly = True
        Me.CreditGLAccountDataGridViewTextBoxColumn.Visible = False
        '
        'CustomerPODataGridViewTextBoxColumn
        '
        Me.CustomerPODataGridViewTextBoxColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPODataGridViewTextBoxColumn.HeaderText = "CustomerPO"
        Me.CustomerPODataGridViewTextBoxColumn.Name = "CustomerPODataGridViewTextBoxColumn"
        Me.CustomerPODataGridViewTextBoxColumn.ReadOnly = True
        Me.CustomerPODataGridViewTextBoxColumn.Visible = False
        '
        'SalespersonDataGridViewTextBoxColumn
        '
        Me.SalespersonDataGridViewTextBoxColumn.DataPropertyName = "Salesperson"
        Me.SalespersonDataGridViewTextBoxColumn.HeaderText = "Salesperson"
        Me.SalespersonDataGridViewTextBoxColumn.Name = "SalespersonDataGridViewTextBoxColumn"
        Me.SalespersonDataGridViewTextBoxColumn.ReadOnly = True
        Me.SalespersonDataGridViewTextBoxColumn.Visible = False
        '
        'LeadTimeDataGridViewTextBoxColumn
        '
        Me.LeadTimeDataGridViewTextBoxColumn.DataPropertyName = "LeadTime"
        Me.LeadTimeDataGridViewTextBoxColumn.HeaderText = "LeadTime"
        Me.LeadTimeDataGridViewTextBoxColumn.Name = "LeadTimeDataGridViewTextBoxColumn"
        Me.LeadTimeDataGridViewTextBoxColumn.ReadOnly = True
        Me.LeadTimeDataGridViewTextBoxColumn.Visible = False
        '
        'ShippingDateDataGridViewTextBoxColumn
        '
        Me.ShippingDateDataGridViewTextBoxColumn.DataPropertyName = "ShippingDate"
        Me.ShippingDateDataGridViewTextBoxColumn.HeaderText = "ShippingDate"
        Me.ShippingDateDataGridViewTextBoxColumn.Name = "ShippingDateDataGridViewTextBoxColumn"
        Me.ShippingDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.ShippingDateDataGridViewTextBoxColumn.Visible = False
        '
        'ShipViaDataGridViewTextBoxColumn
        '
        Me.ShipViaDataGridViewTextBoxColumn.DataPropertyName = "ShipVia"
        Me.ShipViaDataGridViewTextBoxColumn.HeaderText = "ShipVia"
        Me.ShipViaDataGridViewTextBoxColumn.Name = "ShipViaDataGridViewTextBoxColumn"
        Me.ShipViaDataGridViewTextBoxColumn.ReadOnly = True
        Me.ShipViaDataGridViewTextBoxColumn.Visible = False
        '
        'HeaderCommentDataGridViewTextBoxColumn
        '
        Me.HeaderCommentDataGridViewTextBoxColumn.DataPropertyName = "HeaderComment"
        Me.HeaderCommentDataGridViewTextBoxColumn.HeaderText = "HeaderComment"
        Me.HeaderCommentDataGridViewTextBoxColumn.Name = "HeaderCommentDataGridViewTextBoxColumn"
        Me.HeaderCommentDataGridViewTextBoxColumn.ReadOnly = True
        Me.HeaderCommentDataGridViewTextBoxColumn.Visible = False
        '
        'PRONumberDataGridViewTextBoxColumn
        '
        Me.PRONumberDataGridViewTextBoxColumn.DataPropertyName = "PRONumber"
        Me.PRONumberDataGridViewTextBoxColumn.HeaderText = "PRONumber"
        Me.PRONumberDataGridViewTextBoxColumn.Name = "PRONumberDataGridViewTextBoxColumn"
        Me.PRONumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.PRONumberDataGridViewTextBoxColumn.Visible = False
        '
        'AdditionalShipToDataGridViewTextBoxColumn
        '
        Me.AdditionalShipToDataGridViewTextBoxColumn.DataPropertyName = "AdditionalShipTo"
        Me.AdditionalShipToDataGridViewTextBoxColumn.HeaderText = "AdditionalShipTo"
        Me.AdditionalShipToDataGridViewTextBoxColumn.Name = "AdditionalShipToDataGridViewTextBoxColumn"
        Me.AdditionalShipToDataGridViewTextBoxColumn.ReadOnly = True
        Me.AdditionalShipToDataGridViewTextBoxColumn.Visible = False
        '
        'CertificationTypeDataGridViewTextBoxColumn
        '
        Me.CertificationTypeDataGridViewTextBoxColumn.DataPropertyName = "CertificationType"
        Me.CertificationTypeDataGridViewTextBoxColumn.HeaderText = "CertificationType"
        Me.CertificationTypeDataGridViewTextBoxColumn.Name = "CertificationTypeDataGridViewTextBoxColumn"
        Me.CertificationTypeDataGridViewTextBoxColumn.ReadOnly = True
        Me.CertificationTypeDataGridViewTextBoxColumn.Visible = False
        '
        'DropShipPONumberDataGridViewTextBoxColumn
        '
        Me.DropShipPONumberDataGridViewTextBoxColumn.DataPropertyName = "DropShipPONumber"
        Me.DropShipPONumberDataGridViewTextBoxColumn.HeaderText = "DropShipPONumber"
        Me.DropShipPONumberDataGridViewTextBoxColumn.Name = "DropShipPONumberDataGridViewTextBoxColumn"
        Me.DropShipPONumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.DropShipPONumberDataGridViewTextBoxColumn.Visible = False
        '
        'SpecialInstructionsDataGridViewTextBoxColumn
        '
        Me.SpecialInstructionsDataGridViewTextBoxColumn.DataPropertyName = "SpecialInstructions"
        Me.SpecialInstructionsDataGridViewTextBoxColumn.HeaderText = "SpecialInstructions"
        Me.SpecialInstructionsDataGridViewTextBoxColumn.Name = "SpecialInstructionsDataGridViewTextBoxColumn"
        Me.SpecialInstructionsDataGridViewTextBoxColumn.ReadOnly = True
        Me.SpecialInstructionsDataGridViewTextBoxColumn.Visible = False
        '
        'CustomerPOTypeDataGridViewTextBoxColumn
        '
        Me.CustomerPOTypeDataGridViewTextBoxColumn.DataPropertyName = "CustomerPOType"
        Me.CustomerPOTypeDataGridViewTextBoxColumn.HeaderText = "CustomerPOType"
        Me.CustomerPOTypeDataGridViewTextBoxColumn.Name = "CustomerPOTypeDataGridViewTextBoxColumn"
        Me.CustomerPOTypeDataGridViewTextBoxColumn.ReadOnly = True
        Me.CustomerPOTypeDataGridViewTextBoxColumn.Visible = False
        '
        'EstExtendedCOSDataGridViewTextBoxColumn
        '
        Me.EstExtendedCOSDataGridViewTextBoxColumn.DataPropertyName = "EstExtendedCOS"
        Me.EstExtendedCOSDataGridViewTextBoxColumn.HeaderText = "EstExtendedCOS"
        Me.EstExtendedCOSDataGridViewTextBoxColumn.Name = "EstExtendedCOSDataGridViewTextBoxColumn"
        Me.EstExtendedCOSDataGridViewTextBoxColumn.ReadOnly = True
        Me.EstExtendedCOSDataGridViewTextBoxColumn.Visible = False
        '
        'FOBDataGridViewTextBoxColumn
        '
        Me.FOBDataGridViewTextBoxColumn.DataPropertyName = "FOB"
        Me.FOBDataGridViewTextBoxColumn.HeaderText = "FOB"
        Me.FOBDataGridViewTextBoxColumn.Name = "FOBDataGridViewTextBoxColumn"
        Me.FOBDataGridViewTextBoxColumn.ReadOnly = True
        Me.FOBDataGridViewTextBoxColumn.Visible = False
        '
        'CustomerClassDataGridViewTextBoxColumn
        '
        Me.CustomerClassDataGridViewTextBoxColumn.DataPropertyName = "CustomerClass"
        Me.CustomerClassDataGridViewTextBoxColumn.HeaderText = "CustomerClass"
        Me.CustomerClassDataGridViewTextBoxColumn.Name = "CustomerClassDataGridViewTextBoxColumn"
        Me.CustomerClassDataGridViewTextBoxColumn.ReadOnly = True
        Me.CustomerClassDataGridViewTextBoxColumn.Visible = False
        '
        'ShippedPreviousDataGridViewTextBoxColumn
        '
        Me.ShippedPreviousDataGridViewTextBoxColumn.DataPropertyName = "ShippedPrevious"
        Me.ShippedPreviousDataGridViewTextBoxColumn.HeaderText = "ShippedPrevious"
        Me.ShippedPreviousDataGridViewTextBoxColumn.Name = "ShippedPreviousDataGridViewTextBoxColumn"
        Me.ShippedPreviousDataGridViewTextBoxColumn.ReadOnly = True
        Me.ShippedPreviousDataGridViewTextBoxColumn.Visible = False
        '
        'SalesOrderLineQueryBindingSource
        '
        Me.SalesOrderLineQueryBindingSource.DataMember = "SalesOrderLineQuery"
        Me.SalesOrderLineQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SalesOrderLineQueryTableAdapter
        '
        Me.SalesOrderLineQueryTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'lstPartDescriptionSuggest
        '
        Me.lstPartDescriptionSuggest.FormattingEnabled = True
        Me.lstPartDescriptionSuggest.Location = New System.Drawing.Point(358, 62)
        Me.lstPartDescriptionSuggest.Name = "lstPartDescriptionSuggest"
        Me.lstPartDescriptionSuggest.Size = New System.Drawing.Size(120, 95)
        Me.lstPartDescriptionSuggest.TabIndex = 179
        Me.lstPartDescriptionSuggest.Visible = False
        '
        'lblPricingReview
        '
        Me.lblPricingReview.ForeColor = System.Drawing.Color.Blue
        Me.lblPricingReview.Location = New System.Drawing.Point(358, 83)
        Me.lblPricingReview.Name = "lblPricingReview"
        Me.lblPricingReview.Size = New System.Drawing.Size(302, 23)
        Me.lblPricingReview.TabIndex = 180
        Me.lblPricingReview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPaymentTerms
        '
        Me.lblPaymentTerms.ForeColor = System.Drawing.Color.Blue
        Me.lblPaymentTerms.Location = New System.Drawing.Point(10, 75)
        Me.lblPaymentTerms.Name = "lblPaymentTerms"
        Me.lblPaymentTerms.Size = New System.Drawing.Size(295, 23)
        Me.lblPaymentTerms.TabIndex = 181
        Me.lblPaymentTerms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOnHoldStatus
        '
        Me.lblOnHoldStatus.ForeColor = System.Drawing.Color.Red
        Me.lblOnHoldStatus.Location = New System.Drawing.Point(10, 104)
        Me.lblOnHoldStatus.Name = "lblOnHoldStatus"
        Me.lblOnHoldStatus.Size = New System.Drawing.Size(295, 23)
        Me.lblOnHoldStatus.TabIndex = 182
        Me.lblOnHoldStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccountingHold
        '
        Me.lblAccountingHold.ForeColor = System.Drawing.Color.Red
        Me.lblAccountingHold.Location = New System.Drawing.Point(10, 133)
        Me.lblAccountingHold.Name = "lblAccountingHold"
        Me.lblAccountingHold.Size = New System.Drawing.Size(295, 23)
        Me.lblAccountingHold.TabIndex = 183
        Me.lblAccountingHold.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PriceLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 622)
        Me.Controls.Add(Me.lblAccountingHold)
        Me.Controls.Add(Me.lblOnHoldStatus)
        Me.Controls.Add(Me.lblPaymentTerms)
        Me.Controls.Add(Me.lstPartDescriptionSuggest)
        Me.Controls.Add(Me.tabPriceControl)
        Me.Controls.Add(Me.cboCustomerName)
        Me.Controls.Add(Me.cboCustomerID)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboPartDescription)
        Me.Controls.Add(Me.cboPartNumber)
        Me.Controls.Add(Me.lblItemNumber)
        Me.Controls.Add(Me.lblPricingReview)
        Me.Name = "PriceLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Price Lookup"
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPriceControl.ResumeLayout(False)
        Me.tabItemdata.ResumeLayout(False)
        Me.tabItemdata.PerformLayout()
        Me.tabCustomerPricing.ResumeLayout(False)
        CType(Me.dgvSalesHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents lblItemNumber As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtYTDQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtMTDQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtOpenPOQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtStdCost As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtQtyPending As System.Windows.Forms.TextBox
    Friend WithEvents txtStdPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPalletPieces As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPalletWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBoxWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPalletCount As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblLastPurchaseCost As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtLastPurchaseCost As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantityOnHand As System.Windows.Forms.TextBox
    Friend WithEvents txtBoxCount As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtPieceWeight As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice13 As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice12 As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice11 As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice10 As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice9 As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice8 As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice7 As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice6 As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice5 As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice4 As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice3 As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice2 As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtLastSalesPrice As System.Windows.Forms.TextBox
    Friend WithEvents tabPriceControl As System.Windows.Forms.TabControl
    Friend WithEvents tabItemdata As System.Windows.Forms.TabPage
    Friend WithEvents tabCustomerPricing As System.Windows.Forms.TabPage
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents dgvSalesHistory As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents SalesOrderLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderLineQueryTableAdapter
    Friend WithEvents CustomerIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionKeyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineBoxesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalespersonDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeadTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipViaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeaderCommentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRONumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdditionalShipToDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CertificationTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DropShipPONumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecialInstructionsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstExtendedCOSDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOBDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerClassDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippedPreviousDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents lstPartDescriptionSuggest As System.Windows.Forms.ListBox
    Friend WithEvents lblPricingReview As System.Windows.Forms.Label
    Friend WithEvents lblUpdatedPrice As System.Windows.Forms.Label
    Friend WithEvents lblPaymentTerms As System.Windows.Forms.Label
    Friend WithEvents lblOnHoldStatus As System.Windows.Forms.Label
    Friend WithEvents lblAccountingHold As System.Windows.Forms.Label
End Class
