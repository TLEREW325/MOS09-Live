<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemLookup
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
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.txtLongDescription = New System.Windows.Forms.TextBox
        Me.lblItemNumber = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtLastPurchaseCost = New System.Windows.Forms.TextBox
        Me.txtQuantityOnHand = New System.Windows.Forms.TextBox
        Me.txtBoxCount = New System.Windows.Forms.TextBox
        Me.txtLastSalePrice = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtPieceWeight = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBoxWeight = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPalletCount = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPalletWeight = New System.Windows.Forms.TextBox
        Me.Label57 = New System.Windows.Forms.Label
        Me.lblHoustonQOH = New System.Windows.Forms.Label
        Me.lblTruweldInventory = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.lblTexasInventory = New System.Windows.Forms.Label
        Me.Label54 = New System.Windows.Forms.Label
        Me.lblAtlantInventory = New System.Windows.Forms.Label
        Me.lblChicagoInventory = New System.Windows.Forms.Label
        Me.lblLasVegasInventory = New System.Windows.Forms.Label
        Me.lblVancouverInventory = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.lblTWEInventory = New System.Windows.Forms.Label
        Me.lblWeldingCeramicsInventory = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.lblSaltLakeInventory = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPalletPieces = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblTrufitQOH = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdClearData = New System.Windows.Forms.Button
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblBought = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtQtyPending = New System.Windows.Forms.TextBox
        Me.txtStdPrice = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtStdCost = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtOpenPOQuantity = New System.Windows.Forms.TextBox
        Me.lblTorontoQOH = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtYTDQuantity = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtMTDQuantity = New System.Windows.Forms.TextBox
        Me.lblBlanks = New System.Windows.Forms.Label
        Me.lblBlankLabel = New System.Windows.Forms.Label
        Me.lblVendor = New System.Windows.Forms.Label
        Me.lblVendorLabel = New System.Windows.Forms.Label
        Me.lblDenverQOH = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.lblPricingReview = New System.Windows.Forms.Label
        Me.chkLoadDivisionQOH = New System.Windows.Forms.CheckBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtOpenSOQuamtity = New System.Windows.Forms.TextBox
        Me.lblUpdatedPrice = New System.Windows.Forms.Label
        Me.lblDENCommitted = New System.Windows.Forms.Label
        Me.lblTORCommitted = New System.Windows.Forms.Label
        Me.lblTFPCommitted = New System.Windows.Forms.Label
        Me.lblHOUCommitted = New System.Windows.Forms.Label
        Me.lblTWDCommitted = New System.Windows.Forms.Label
        Me.lblTFTCommitted = New System.Windows.Forms.Label
        Me.lblATLCommitted = New System.Windows.Forms.Label
        Me.lblCGOCommitted = New System.Windows.Forms.Label
        Me.lblCBSCommitted = New System.Windows.Forms.Label
        Me.lblTFFCommitted = New System.Windows.Forms.Label
        Me.lblTWECommitted = New System.Windows.Forms.Label
        Me.lblCHTCommitted = New System.Windows.Forms.Label
        Me.lblSLCCommitted = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.llLastPurchaseCostPopup = New System.Windows.Forms.LinkLabel
        Me.lblALBCommitted = New System.Windows.Forms.Label
        Me.lblAlbertaQOH = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.lblJerseyCommitted = New System.Windows.Forms.Label
        Me.lblJerseyQOH = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.llLastSalesPrice = New System.Windows.Forms.LinkLabel
        Me.lblOnHoldStatus = New System.Windows.Forms.Label
        Me.lblAccountingHoldStatus = New System.Windows.Forms.Label
        Me.lblPaymentTerms = New System.Windows.Forms.Label
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(10, 130)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(302, 21)
        Me.cboPartDescription.TabIndex = 3
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(89, 101)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(222, 21)
        Me.cboPartNumber.TabIndex = 2
        Me.cboPartNumber.ValueMember = "ItemClassID"
        '
        'txtLongDescription
        '
        Me.txtLongDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLongDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLongDescription.Location = New System.Drawing.Point(10, 157)
        Me.txtLongDescription.Multiline = True
        Me.txtLongDescription.Name = "txtLongDescription"
        Me.txtLongDescription.Size = New System.Drawing.Size(302, 68)
        Me.txtLongDescription.TabIndex = 4
        Me.txtLongDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblItemNumber
        '
        Me.lblItemNumber.Location = New System.Drawing.Point(10, 101)
        Me.lblItemNumber.Name = "lblItemNumber"
        Me.lblItemNumber.Size = New System.Drawing.Size(107, 20)
        Me.lblItemNumber.TabIndex = 18
        Me.lblItemNumber.Text = "Part Number"
        Me.lblItemNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(10, 500)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(151, 20)
        Me.Label22.TabIndex = 30
        Me.Label22.Text = "Box Count"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(10, 284)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(151, 20)
        Me.Label25.TabIndex = 27
        Me.Label25.Text = "Quantity On Hand"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLastPurchaseCost
        '
        Me.txtLastPurchaseCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastPurchaseCost.Location = New System.Drawing.Point(163, 260)
        Me.txtLastPurchaseCost.Name = "txtLastPurchaseCost"
        Me.txtLastPurchaseCost.Size = New System.Drawing.Size(148, 20)
        Me.txtLastPurchaseCost.TabIndex = 6
        Me.txtLastPurchaseCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuantityOnHand
        '
        Me.txtQuantityOnHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantityOnHand.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantityOnHand.ForeColor = System.Drawing.Color.Black
        Me.txtQuantityOnHand.Location = New System.Drawing.Point(163, 284)
        Me.txtQuantityOnHand.Name = "txtQuantityOnHand"
        Me.txtQuantityOnHand.Size = New System.Drawing.Size(148, 20)
        Me.txtQuantityOnHand.TabIndex = 7
        Me.txtQuantityOnHand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBoxCount
        '
        Me.txtBoxCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxCount.Location = New System.Drawing.Point(163, 500)
        Me.txtBoxCount.Name = "txtBoxCount"
        Me.txtBoxCount.Size = New System.Drawing.Size(148, 20)
        Me.txtBoxCount.TabIndex = 15
        Me.txtBoxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLastSalePrice
        '
        Me.txtLastSalePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastSalePrice.Location = New System.Drawing.Point(163, 234)
        Me.txtLastSalePrice.Name = "txtLastSalePrice"
        Me.txtLastSalePrice.Size = New System.Drawing.Size(148, 20)
        Me.txtLastSalePrice.TabIndex = 5
        Me.txtLastSalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(10, 476)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(151, 20)
        Me.Label17.TabIndex = 22
        Me.Label17.Text = "Piece Weight"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPieceWeight
        '
        Me.txtPieceWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPieceWeight.Location = New System.Drawing.Point(163, 476)
        Me.txtPieceWeight.Name = "txtPieceWeight"
        Me.txtPieceWeight.Size = New System.Drawing.Size(148, 20)
        Me.txtPieceWeight.TabIndex = 14
        Me.txtPieceWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(10, 524)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 20)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Box Weight"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBoxWeight
        '
        Me.txtBoxWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxWeight.Location = New System.Drawing.Point(163, 524)
        Me.txtBoxWeight.Name = "txtBoxWeight"
        Me.txtBoxWeight.Size = New System.Drawing.Size(148, 20)
        Me.txtBoxWeight.TabIndex = 16
        Me.txtBoxWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 548)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 20)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Pallet Count (# boxes)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPalletCount
        '
        Me.txtPalletCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPalletCount.Location = New System.Drawing.Point(163, 548)
        Me.txtPalletCount.Name = "txtPalletCount"
        Me.txtPalletCount.Size = New System.Drawing.Size(148, 20)
        Me.txtPalletCount.TabIndex = 17
        Me.txtPalletCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(10, 596)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 20)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Pallet Weight"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPalletWeight
        '
        Me.txtPalletWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPalletWeight.Location = New System.Drawing.Point(163, 596)
        Me.txtPalletWeight.Name = "txtPalletWeight"
        Me.txtPalletWeight.Size = New System.Drawing.Size(148, 20)
        Me.txtPalletWeight.TabIndex = 19
        Me.txtPalletWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label57
        '
        Me.Label57.Location = New System.Drawing.Point(330, 313)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(164, 20)
        Me.Label57.TabIndex = 95
        Me.Label57.Text = "Houston (281-598-2330 )"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHoustonQOH
        '
        Me.lblHoustonQOH.BackColor = System.Drawing.Color.White
        Me.lblHoustonQOH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHoustonQOH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoustonQOH.Location = New System.Drawing.Point(500, 313)
        Me.lblHoustonQOH.Name = "lblHoustonQOH"
        Me.lblHoustonQOH.Size = New System.Drawing.Size(85, 20)
        Me.lblHoustonQOH.TabIndex = 27
        Me.lblHoustonQOH.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTruweldInventory
        '
        Me.lblTruweldInventory.BackColor = System.Drawing.Color.White
        Me.lblTruweldInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTruweldInventory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTruweldInventory.Location = New System.Drawing.Point(500, 70)
        Me.lblTruweldInventory.Name = "lblTruweldInventory"
        Me.lblTruweldInventory.Size = New System.Drawing.Size(85, 20)
        Me.lblTruweldInventory.TabIndex = 18
        Me.lblTruweldInventory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(330, 178)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(164, 20)
        Me.Label38.TabIndex = 84
        Me.Label38.Text = "Salt Lake City (801-280-6611)"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTexasInventory
        '
        Me.lblTexasInventory.BackColor = System.Drawing.Color.White
        Me.lblTexasInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTexasInventory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTexasInventory.Location = New System.Drawing.Point(500, 124)
        Me.lblTexasInventory.Name = "lblTexasInventory"
        Me.lblTexasInventory.Size = New System.Drawing.Size(85, 20)
        Me.lblTexasInventory.TabIndex = 20
        Me.lblTexasInventory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label54
        '
        Me.Label54.Location = New System.Drawing.Point(330, 286)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(164, 20)
        Me.Label54.TabIndex = 93
        Me.Label54.Text = "Chicago (219-513-9572)"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAtlantInventory
        '
        Me.lblAtlantInventory.BackColor = System.Drawing.Color.White
        Me.lblAtlantInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAtlantInventory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAtlantInventory.Location = New System.Drawing.Point(500, 97)
        Me.lblAtlantInventory.Name = "lblAtlantInventory"
        Me.lblAtlantInventory.Size = New System.Drawing.Size(85, 20)
        Me.lblAtlantInventory.TabIndex = 19
        Me.lblAtlantInventory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblChicagoInventory
        '
        Me.lblChicagoInventory.BackColor = System.Drawing.Color.White
        Me.lblChicagoInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChicagoInventory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChicagoInventory.Location = New System.Drawing.Point(500, 286)
        Me.lblChicagoInventory.Name = "lblChicagoInventory"
        Me.lblChicagoInventory.Size = New System.Drawing.Size(85, 20)
        Me.lblChicagoInventory.TabIndex = 26
        Me.lblChicagoInventory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLasVegasInventory
        '
        Me.lblLasVegasInventory.BackColor = System.Drawing.Color.White
        Me.lblLasVegasInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLasVegasInventory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLasVegasInventory.Location = New System.Drawing.Point(500, 151)
        Me.lblLasVegasInventory.Name = "lblLasVegasInventory"
        Me.lblLasVegasInventory.Size = New System.Drawing.Size(85, 20)
        Me.lblLasVegasInventory.TabIndex = 21
        Me.lblLasVegasInventory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVancouverInventory
        '
        Me.lblVancouverInventory.BackColor = System.Drawing.Color.White
        Me.lblVancouverInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVancouverInventory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVancouverInventory.Location = New System.Drawing.Point(500, 232)
        Me.lblVancouverInventory.Name = "lblVancouverInventory"
        Me.lblVancouverInventory.Size = New System.Drawing.Size(85, 20)
        Me.lblVancouverInventory.TabIndex = 24
        Me.lblVancouverInventory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(330, 97)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(164, 20)
        Me.Label27.TabIndex = 79
        Me.Label27.Text = "Atlanta (800-727-7883)"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTWEInventory
        '
        Me.lblTWEInventory.BackColor = System.Drawing.Color.White
        Me.lblTWEInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTWEInventory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTWEInventory.Location = New System.Drawing.Point(500, 205)
        Me.lblTWEInventory.Name = "lblTWEInventory"
        Me.lblTWEInventory.Size = New System.Drawing.Size(85, 20)
        Me.lblTWEInventory.TabIndex = 23
        Me.lblTWEInventory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWeldingCeramicsInventory
        '
        Me.lblWeldingCeramicsInventory.BackColor = System.Drawing.Color.White
        Me.lblWeldingCeramicsInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWeldingCeramicsInventory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeldingCeramicsInventory.Location = New System.Drawing.Point(500, 259)
        Me.lblWeldingCeramicsInventory.Name = "lblWeldingCeramicsInventory"
        Me.lblWeldingCeramicsInventory.Size = New System.Drawing.Size(85, 20)
        Me.lblWeldingCeramicsInventory.TabIndex = 25
        Me.lblWeldingCeramicsInventory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(330, 124)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(164, 20)
        Me.Label28.TabIndex = 78
        Me.Label28.Text = "Texas (972-986-6368)"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(330, 205)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(164, 20)
        Me.Label35.TabIndex = 87
        Me.Label35.Text = "TW Equipment (330-725-7744)"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(330, 70)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(164, 20)
        Me.Label30.TabIndex = 76
        Me.Label30.Text = "Tru-Weld (330-725-7741)"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSaltLakeInventory
        '
        Me.lblSaltLakeInventory.BackColor = System.Drawing.Color.White
        Me.lblSaltLakeInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSaltLakeInventory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaltLakeInventory.Location = New System.Drawing.Point(500, 178)
        Me.lblSaltLakeInventory.Name = "lblSaltLakeInventory"
        Me.lblSaltLakeInventory.Size = New System.Drawing.Size(85, 20)
        Me.lblSaltLakeInventory.TabIndex = 22
        Me.lblSaltLakeInventory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(330, 232)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(164, 20)
        Me.Label36.TabIndex = 86
        Me.Label36.Text = "Vancouver (778-298-1094)"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(330, 151)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(164, 20)
        Me.Label29.TabIndex = 77
        Me.Label29.Text = "Las Vegas (702-737-7940)"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(330, 259)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(164, 20)
        Me.Label37.TabIndex = 85
        Me.Label37.Text = "Weld. Ceramics (423-752-5740)"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(609, 675)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 30
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(10, 572)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(151, 20)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "Pallet Count (# pieces)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPalletPieces
        '
        Me.txtPalletPieces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPalletPieces.Location = New System.Drawing.Point(163, 572)
        Me.txtPalletPieces.Name = "txtPalletPieces"
        Me.txtPalletPieces.Size = New System.Drawing.Size(148, 20)
        Me.txtPalletPieces.TabIndex = 18
        Me.txtPalletPieces.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(330, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 20)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Division"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTrufitQOH
        '
        Me.lblTrufitQOH.BackColor = System.Drawing.Color.White
        Me.lblTrufitQOH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTrufitQOH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrufitQOH.Location = New System.Drawing.Point(500, 340)
        Me.lblTrufitQOH.Name = "lblTrufitQOH"
        Me.lblTrufitQOH.Size = New System.Drawing.Size(85, 20)
        Me.lblTrufitQOH.TabIndex = 28
        Me.lblTrufitQOH.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(330, 340)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(164, 20)
        Me.Label7.TabIndex = 101
        Me.Label7.Text = "Trufit (330-725-7741)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearData
        '
        Me.cmdClearData.Location = New System.Drawing.Point(532, 675)
        Me.cmdClearData.Name = "cmdClearData"
        Me.cmdClearData.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearData.TabIndex = 29
        Me.cmdClearData.Text = "Clear"
        Me.cmdClearData.UseVisualStyleBackColor = True
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(10, 70)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(302, 21)
        Me.cboCustomerName.TabIndex = 1
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(89, 40)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(222, 21)
        Me.cboCustomerID.TabIndex = 0
        Me.cboCustomerID.ValueMember = "ItemClassID"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(10, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 20)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "Customer ID"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(333, 592)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(347, 41)
        Me.Label8.TabIndex = 105
        Me.Label8.Text = "If Customer field is left blank, it will give you the Last Sales Price for any cu" & _
            "stomer."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBought
        '
        Me.lblBought.ForeColor = System.Drawing.Color.Red
        Me.lblBought.Location = New System.Drawing.Point(330, 685)
        Me.lblBought.Name = "lblBought"
        Me.lblBought.Size = New System.Drawing.Size(148, 20)
        Me.lblBought.TabIndex = 106
        Me.lblBought.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(10, 308)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(151, 20)
        Me.Label9.TabIndex = 110
        Me.Label9.Text = "Qty. Pending"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(10, 452)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(151, 20)
        Me.Label10.TabIndex = 109
        Me.Label10.Text = "Std Unit Price"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQtyPending
        '
        Me.txtQtyPending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQtyPending.Location = New System.Drawing.Point(163, 308)
        Me.txtQtyPending.Name = "txtQtyPending"
        Me.txtQtyPending.Size = New System.Drawing.Size(148, 20)
        Me.txtQtyPending.TabIndex = 8
        Me.txtQtyPending.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtStdPrice
        '
        Me.txtStdPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStdPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStdPrice.ForeColor = System.Drawing.Color.Black
        Me.txtStdPrice.Location = New System.Drawing.Point(163, 452)
        Me.txtStdPrice.Name = "txtStdPrice"
        Me.txtStdPrice.Size = New System.Drawing.Size(148, 20)
        Me.txtStdPrice.TabIndex = 13
        Me.txtStdPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(10, 428)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(151, 20)
        Me.Label11.TabIndex = 112
        Me.Label11.Text = "Std Unit Cost"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtStdCost
        '
        Me.txtStdCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStdCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStdCost.ForeColor = System.Drawing.Color.Black
        Me.txtStdCost.Location = New System.Drawing.Point(163, 428)
        Me.txtStdCost.Name = "txtStdCost"
        Me.txtStdCost.Size = New System.Drawing.Size(148, 20)
        Me.txtStdCost.TabIndex = 12
        Me.txtStdCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(333, 551)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(347, 41)
        Me.Label12.TabIndex = 113
        Me.Label12.Text = "If Customer field is filled in, it will give you the Last Sales Price for that Cu" & _
            "stomer."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(10, 356)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(151, 20)
        Me.Label13.TabIndex = 115
        Me.Label13.Text = "Open PO Qty."
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOpenPOQuantity
        '
        Me.txtOpenPOQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOpenPOQuantity.Location = New System.Drawing.Point(163, 356)
        Me.txtOpenPOQuantity.Name = "txtOpenPOQuantity"
        Me.txtOpenPOQuantity.Size = New System.Drawing.Size(148, 20)
        Me.txtOpenPOQuantity.TabIndex = 9
        Me.txtOpenPOQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTorontoQOH
        '
        Me.lblTorontoQOH.BackColor = System.Drawing.Color.White
        Me.lblTorontoQOH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTorontoQOH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTorontoQOH.Location = New System.Drawing.Point(500, 367)
        Me.lblTorontoQOH.Name = "lblTorontoQOH"
        Me.lblTorontoQOH.Size = New System.Drawing.Size(85, 20)
        Me.lblTorontoQOH.TabIndex = 116
        Me.lblTorontoQOH.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(330, 367)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(164, 20)
        Me.Label15.TabIndex = 117
        Me.Label15.Text = "Toronto (905-547-4076)"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(10, 404)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(151, 20)
        Me.Label14.TabIndex = 121
        Me.Label14.Text = "YTD Quantity Sold"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtYTDQuantity
        '
        Me.txtYTDQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYTDQuantity.Location = New System.Drawing.Point(163, 404)
        Me.txtYTDQuantity.Name = "txtYTDQuantity"
        Me.txtYTDQuantity.Size = New System.Drawing.Size(148, 20)
        Me.txtYTDQuantity.TabIndex = 11
        Me.txtYTDQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(10, 380)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(151, 20)
        Me.Label16.TabIndex = 120
        Me.Label16.Text = "MTD Quantity Sold"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMTDQuantity
        '
        Me.txtMTDQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMTDQuantity.Location = New System.Drawing.Point(163, 380)
        Me.txtMTDQuantity.Name = "txtMTDQuantity"
        Me.txtMTDQuantity.Size = New System.Drawing.Size(148, 20)
        Me.txtMTDQuantity.TabIndex = 10
        Me.txtMTDQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBlanks
        '
        Me.lblBlanks.BackColor = System.Drawing.Color.White
        Me.lblBlanks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBlanks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlanks.Location = New System.Drawing.Point(500, 475)
        Me.lblBlanks.Name = "lblBlanks"
        Me.lblBlanks.Size = New System.Drawing.Size(85, 20)
        Me.lblBlanks.TabIndex = 122
        Me.lblBlanks.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblBlanks.Visible = False
        '
        'lblBlankLabel
        '
        Me.lblBlankLabel.Location = New System.Drawing.Point(330, 475)
        Me.lblBlankLabel.Name = "lblBlankLabel"
        Me.lblBlankLabel.Size = New System.Drawing.Size(164, 20)
        Me.lblBlankLabel.TabIndex = 123
        Me.lblBlankLabel.Text = "TWD / TFP Blanks"
        Me.lblBlankLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBlankLabel.Visible = False
        '
        'lblVendor
        '
        Me.lblVendor.BackColor = System.Drawing.Color.White
        Me.lblVendor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVendor.ForeColor = System.Drawing.Color.Blue
        Me.lblVendor.Location = New System.Drawing.Point(500, 512)
        Me.lblVendor.Name = "lblVendor"
        Me.lblVendor.Size = New System.Drawing.Size(154, 20)
        Me.lblVendor.TabIndex = 125
        Me.lblVendor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblVendor.Visible = False
        '
        'lblVendorLabel
        '
        Me.lblVendorLabel.Location = New System.Drawing.Point(330, 512)
        Me.lblVendorLabel.Name = "lblVendorLabel"
        Me.lblVendorLabel.Size = New System.Drawing.Size(160, 20)
        Me.lblVendorLabel.TabIndex = 126
        Me.lblVendorLabel.Text = "Canadian/American Vendor"
        Me.lblVendorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblVendorLabel.Visible = False
        '
        'lblDenverQOH
        '
        Me.lblDenverQOH.BackColor = System.Drawing.Color.White
        Me.lblDenverQOH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDenverQOH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDenverQOH.Location = New System.Drawing.Point(500, 394)
        Me.lblDenverQOH.Name = "lblDenverQOH"
        Me.lblDenverQOH.Size = New System.Drawing.Size(85, 20)
        Me.lblDenverQOH.TabIndex = 127
        Me.lblDenverQOH.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(330, 394)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(164, 20)
        Me.Label19.TabIndex = 128
        Me.Label19.Text = "Denver (303-945-2030)"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPricingReview
        '
        Me.lblPricingReview.ForeColor = System.Drawing.Color.Blue
        Me.lblPricingReview.Location = New System.Drawing.Point(9, 14)
        Me.lblPricingReview.Name = "lblPricingReview"
        Me.lblPricingReview.Size = New System.Drawing.Size(671, 20)
        Me.lblPricingReview.TabIndex = 129
        '
        'chkLoadDivisionQOH
        '
        Me.chkLoadDivisionQOH.AutoSize = True
        Me.chkLoadDivisionQOH.ForeColor = System.Drawing.Color.Blue
        Me.chkLoadDivisionQOH.Location = New System.Drawing.Point(336, 645)
        Me.chkLoadDivisionQOH.Name = "chkLoadDivisionQOH"
        Me.chkLoadDivisionQOH.Size = New System.Drawing.Size(77, 17)
        Me.chkLoadDivisionQOH.TabIndex = 130
        Me.chkLoadDivisionQOH.Text = "Load QOH"
        Me.chkLoadDivisionQOH.UseVisualStyleBackColor = True
        Me.chkLoadDivisionQOH.Visible = False
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(10, 332)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(151, 20)
        Me.Label18.TabIndex = 132
        Me.Label18.Text = "Open SO Qty."
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOpenSOQuamtity
        '
        Me.txtOpenSOQuamtity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOpenSOQuamtity.Location = New System.Drawing.Point(163, 332)
        Me.txtOpenSOQuamtity.Name = "txtOpenSOQuamtity"
        Me.txtOpenSOQuamtity.Size = New System.Drawing.Size(148, 20)
        Me.txtOpenSOQuamtity.TabIndex = 131
        Me.txtOpenSOQuamtity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUpdatedPrice
        '
        Me.lblUpdatedPrice.ForeColor = System.Drawing.Color.Red
        Me.lblUpdatedPrice.Location = New System.Drawing.Point(126, 234)
        Me.lblUpdatedPrice.Name = "lblUpdatedPrice"
        Me.lblUpdatedPrice.Size = New System.Drawing.Size(35, 20)
        Me.lblUpdatedPrice.TabIndex = 133
        Me.lblUpdatedPrice.Text = "***"
        Me.lblUpdatedPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblUpdatedPrice.Visible = False
        '
        'lblDENCommitted
        '
        Me.lblDENCommitted.BackColor = System.Drawing.Color.White
        Me.lblDENCommitted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDENCommitted.ForeColor = System.Drawing.Color.Blue
        Me.lblDENCommitted.Location = New System.Drawing.Point(595, 394)
        Me.lblDENCommitted.Name = "lblDENCommitted"
        Me.lblDENCommitted.Size = New System.Drawing.Size(85, 20)
        Me.lblDENCommitted.TabIndex = 147
        Me.lblDENCommitted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTORCommitted
        '
        Me.lblTORCommitted.BackColor = System.Drawing.Color.White
        Me.lblTORCommitted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTORCommitted.ForeColor = System.Drawing.Color.Blue
        Me.lblTORCommitted.Location = New System.Drawing.Point(595, 367)
        Me.lblTORCommitted.Name = "lblTORCommitted"
        Me.lblTORCommitted.Size = New System.Drawing.Size(85, 20)
        Me.lblTORCommitted.TabIndex = 145
        Me.lblTORCommitted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTFPCommitted
        '
        Me.lblTFPCommitted.BackColor = System.Drawing.Color.White
        Me.lblTFPCommitted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTFPCommitted.ForeColor = System.Drawing.Color.Blue
        Me.lblTFPCommitted.Location = New System.Drawing.Point(595, 340)
        Me.lblTFPCommitted.Name = "lblTFPCommitted"
        Me.lblTFPCommitted.Size = New System.Drawing.Size(85, 20)
        Me.lblTFPCommitted.TabIndex = 144
        Me.lblTFPCommitted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblHOUCommitted
        '
        Me.lblHOUCommitted.BackColor = System.Drawing.Color.White
        Me.lblHOUCommitted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHOUCommitted.ForeColor = System.Drawing.Color.Blue
        Me.lblHOUCommitted.Location = New System.Drawing.Point(595, 313)
        Me.lblHOUCommitted.Name = "lblHOUCommitted"
        Me.lblHOUCommitted.Size = New System.Drawing.Size(85, 20)
        Me.lblHOUCommitted.TabIndex = 143
        Me.lblHOUCommitted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTWDCommitted
        '
        Me.lblTWDCommitted.BackColor = System.Drawing.Color.White
        Me.lblTWDCommitted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTWDCommitted.ForeColor = System.Drawing.Color.Blue
        Me.lblTWDCommitted.Location = New System.Drawing.Point(595, 70)
        Me.lblTWDCommitted.Name = "lblTWDCommitted"
        Me.lblTWDCommitted.Size = New System.Drawing.Size(85, 20)
        Me.lblTWDCommitted.TabIndex = 134
        Me.lblTWDCommitted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTFTCommitted
        '
        Me.lblTFTCommitted.BackColor = System.Drawing.Color.White
        Me.lblTFTCommitted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTFTCommitted.ForeColor = System.Drawing.Color.Blue
        Me.lblTFTCommitted.Location = New System.Drawing.Point(595, 124)
        Me.lblTFTCommitted.Name = "lblTFTCommitted"
        Me.lblTFTCommitted.Size = New System.Drawing.Size(85, 20)
        Me.lblTFTCommitted.TabIndex = 136
        Me.lblTFTCommitted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblATLCommitted
        '
        Me.lblATLCommitted.BackColor = System.Drawing.Color.White
        Me.lblATLCommitted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblATLCommitted.ForeColor = System.Drawing.Color.Blue
        Me.lblATLCommitted.Location = New System.Drawing.Point(595, 97)
        Me.lblATLCommitted.Name = "lblATLCommitted"
        Me.lblATLCommitted.Size = New System.Drawing.Size(85, 20)
        Me.lblATLCommitted.TabIndex = 135
        Me.lblATLCommitted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCGOCommitted
        '
        Me.lblCGOCommitted.BackColor = System.Drawing.Color.White
        Me.lblCGOCommitted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCGOCommitted.ForeColor = System.Drawing.Color.Blue
        Me.lblCGOCommitted.Location = New System.Drawing.Point(595, 286)
        Me.lblCGOCommitted.Name = "lblCGOCommitted"
        Me.lblCGOCommitted.Size = New System.Drawing.Size(85, 20)
        Me.lblCGOCommitted.TabIndex = 142
        Me.lblCGOCommitted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCBSCommitted
        '
        Me.lblCBSCommitted.BackColor = System.Drawing.Color.White
        Me.lblCBSCommitted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCBSCommitted.ForeColor = System.Drawing.Color.Blue
        Me.lblCBSCommitted.Location = New System.Drawing.Point(595, 151)
        Me.lblCBSCommitted.Name = "lblCBSCommitted"
        Me.lblCBSCommitted.Size = New System.Drawing.Size(85, 20)
        Me.lblCBSCommitted.TabIndex = 137
        Me.lblCBSCommitted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTFFCommitted
        '
        Me.lblTFFCommitted.BackColor = System.Drawing.Color.White
        Me.lblTFFCommitted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTFFCommitted.ForeColor = System.Drawing.Color.Blue
        Me.lblTFFCommitted.Location = New System.Drawing.Point(595, 232)
        Me.lblTFFCommitted.Name = "lblTFFCommitted"
        Me.lblTFFCommitted.Size = New System.Drawing.Size(85, 20)
        Me.lblTFFCommitted.TabIndex = 140
        Me.lblTFFCommitted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTWECommitted
        '
        Me.lblTWECommitted.BackColor = System.Drawing.Color.White
        Me.lblTWECommitted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTWECommitted.ForeColor = System.Drawing.Color.Blue
        Me.lblTWECommitted.Location = New System.Drawing.Point(595, 205)
        Me.lblTWECommitted.Name = "lblTWECommitted"
        Me.lblTWECommitted.Size = New System.Drawing.Size(85, 20)
        Me.lblTWECommitted.TabIndex = 139
        Me.lblTWECommitted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCHTCommitted
        '
        Me.lblCHTCommitted.BackColor = System.Drawing.Color.White
        Me.lblCHTCommitted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCHTCommitted.ForeColor = System.Drawing.Color.Blue
        Me.lblCHTCommitted.Location = New System.Drawing.Point(595, 259)
        Me.lblCHTCommitted.Name = "lblCHTCommitted"
        Me.lblCHTCommitted.Size = New System.Drawing.Size(85, 20)
        Me.lblCHTCommitted.TabIndex = 141
        Me.lblCHTCommitted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSLCCommitted
        '
        Me.lblSLCCommitted.BackColor = System.Drawing.Color.White
        Me.lblSLCCommitted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSLCCommitted.ForeColor = System.Drawing.Color.Blue
        Me.lblSLCCommitted.Location = New System.Drawing.Point(595, 178)
        Me.lblSLCCommitted.Name = "lblSLCCommitted"
        Me.lblSLCCommitted.Size = New System.Drawing.Size(85, 20)
        Me.lblSLCCommitted.TabIndex = 138
        Me.lblSLCCommitted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label44
        '
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(497, 41)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(86, 20)
        Me.Label44.TabIndex = 148
        Me.Label44.Text = "QOH"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label45
        '
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(592, 41)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(73, 20)
        Me.Label45.TabIndex = 149
        Me.Label45.Text = "Committed"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'llLastPurchaseCostPopup
        '
        Me.llLastPurchaseCostPopup.Location = New System.Drawing.Point(10, 259)
        Me.llLastPurchaseCostPopup.Name = "llLastPurchaseCostPopup"
        Me.llLastPurchaseCostPopup.Size = New System.Drawing.Size(145, 23)
        Me.llLastPurchaseCostPopup.TabIndex = 150
        Me.llLastPurchaseCostPopup.TabStop = True
        Me.llLastPurchaseCostPopup.Text = "Last Purchase Cost"
        Me.llLastPurchaseCostPopup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblALBCommitted
        '
        Me.lblALBCommitted.BackColor = System.Drawing.Color.White
        Me.lblALBCommitted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblALBCommitted.ForeColor = System.Drawing.Color.Blue
        Me.lblALBCommitted.Location = New System.Drawing.Point(595, 421)
        Me.lblALBCommitted.Name = "lblALBCommitted"
        Me.lblALBCommitted.Size = New System.Drawing.Size(85, 20)
        Me.lblALBCommitted.TabIndex = 153
        Me.lblALBCommitted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAlbertaQOH
        '
        Me.lblAlbertaQOH.BackColor = System.Drawing.Color.White
        Me.lblAlbertaQOH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAlbertaQOH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlbertaQOH.Location = New System.Drawing.Point(500, 421)
        Me.lblAlbertaQOH.Name = "lblAlbertaQOH"
        Me.lblAlbertaQOH.Size = New System.Drawing.Size(85, 20)
        Me.lblAlbertaQOH.TabIndex = 151
        Me.lblAlbertaQOH.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(330, 421)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(164, 20)
        Me.Label23.TabIndex = 152
        Me.Label23.Text = "Alberta (587-350-3926)"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblJerseyCommitted
        '
        Me.lblJerseyCommitted.BackColor = System.Drawing.Color.White
        Me.lblJerseyCommitted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJerseyCommitted.ForeColor = System.Drawing.Color.Blue
        Me.lblJerseyCommitted.Location = New System.Drawing.Point(595, 448)
        Me.lblJerseyCommitted.Name = "lblJerseyCommitted"
        Me.lblJerseyCommitted.Size = New System.Drawing.Size(85, 20)
        Me.lblJerseyCommitted.TabIndex = 156
        Me.lblJerseyCommitted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblJerseyQOH
        '
        Me.lblJerseyQOH.BackColor = System.Drawing.Color.White
        Me.lblJerseyQOH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJerseyQOH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJerseyQOH.Location = New System.Drawing.Point(500, 448)
        Me.lblJerseyQOH.Name = "lblJerseyQOH"
        Me.lblJerseyQOH.Size = New System.Drawing.Size(85, 20)
        Me.lblJerseyQOH.TabIndex = 154
        Me.lblJerseyQOH.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(330, 448)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(164, 20)
        Me.Label24.TabIndex = 155
        Me.Label24.Text = "New Jersey (201-939-6866)"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'llLastSalesPrice
        '
        Me.llLastSalesPrice.Location = New System.Drawing.Point(12, 234)
        Me.llLastSalesPrice.Name = "llLastSalesPrice"
        Me.llLastSalesPrice.Size = New System.Drawing.Size(147, 23)
        Me.llLastSalesPrice.TabIndex = 158
        Me.llLastSalesPrice.TabStop = True
        Me.llLastSalesPrice.Text = "Last Sales Price"
        Me.llLastSalesPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOnHoldStatus
        '
        Me.lblOnHoldStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnHoldStatus.ForeColor = System.Drawing.Color.Red
        Me.lblOnHoldStatus.Location = New System.Drawing.Point(10, 663)
        Me.lblOnHoldStatus.Name = "lblOnHoldStatus"
        Me.lblOnHoldStatus.Size = New System.Drawing.Size(302, 20)
        Me.lblOnHoldStatus.TabIndex = 159
        Me.lblOnHoldStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccountingHoldStatus
        '
        Me.lblAccountingHoldStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountingHoldStatus.ForeColor = System.Drawing.Color.Red
        Me.lblAccountingHoldStatus.Location = New System.Drawing.Point(10, 694)
        Me.lblAccountingHoldStatus.Name = "lblAccountingHoldStatus"
        Me.lblAccountingHoldStatus.Size = New System.Drawing.Size(302, 20)
        Me.lblAccountingHoldStatus.TabIndex = 160
        Me.lblAccountingHoldStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPaymentTerms
        '
        Me.lblPaymentTerms.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaymentTerms.ForeColor = System.Drawing.Color.Blue
        Me.lblPaymentTerms.Location = New System.Drawing.Point(10, 632)
        Me.lblPaymentTerms.Name = "lblPaymentTerms"
        Me.lblPaymentTerms.Size = New System.Drawing.Size(302, 20)
        Me.lblPaymentTerms.TabIndex = 161
        Me.lblPaymentTerms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ItemLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 723)
        Me.Controls.Add(Me.lblPaymentTerms)
        Me.Controls.Add(Me.lblAccountingHoldStatus)
        Me.Controls.Add(Me.lblOnHoldStatus)
        Me.Controls.Add(Me.llLastSalesPrice)
        Me.Controls.Add(Me.lblJerseyCommitted)
        Me.Controls.Add(Me.lblJerseyQOH)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.lblALBCommitted)
        Me.Controls.Add(Me.lblAlbertaQOH)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.llLastPurchaseCostPopup)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.lblDENCommitted)
        Me.Controls.Add(Me.lblTORCommitted)
        Me.Controls.Add(Me.lblTFPCommitted)
        Me.Controls.Add(Me.lblHOUCommitted)
        Me.Controls.Add(Me.lblTWDCommitted)
        Me.Controls.Add(Me.lblTFTCommitted)
        Me.Controls.Add(Me.lblATLCommitted)
        Me.Controls.Add(Me.lblCGOCommitted)
        Me.Controls.Add(Me.lblCBSCommitted)
        Me.Controls.Add(Me.lblTFFCommitted)
        Me.Controls.Add(Me.lblTWECommitted)
        Me.Controls.Add(Me.lblCHTCommitted)
        Me.Controls.Add(Me.lblSLCCommitted)
        Me.Controls.Add(Me.lblUpdatedPrice)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtOpenSOQuamtity)
        Me.Controls.Add(Me.chkLoadDivisionQOH)
        Me.Controls.Add(Me.lblPricingReview)
        Me.Controls.Add(Me.lblDenverQOH)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.lblVendor)
        Me.Controls.Add(Me.lblBlanks)
        Me.Controls.Add(Me.lblBlankLabel)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtYTDQuantity)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtMTDQuantity)
        Me.Controls.Add(Me.lblTorontoQOH)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtOpenPOQuantity)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtStdCost)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtQtyPending)
        Me.Controls.Add(Me.txtStdPrice)
        Me.Controls.Add(Me.lblBought)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboCustomerName)
        Me.Controls.Add(Me.cboCustomerID)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdClearData)
        Me.Controls.Add(Me.lblTrufitQOH)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPalletPieces)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.lblHoustonQOH)
        Me.Controls.Add(Me.lblTruweldInventory)
        Me.Controls.Add(Me.lblTexasInventory)
        Me.Controls.Add(Me.lblAtlantInventory)
        Me.Controls.Add(Me.lblChicagoInventory)
        Me.Controls.Add(Me.lblLasVegasInventory)
        Me.Controls.Add(Me.lblVancouverInventory)
        Me.Controls.Add(Me.lblTWEInventory)
        Me.Controls.Add(Me.lblWeldingCeramicsInventory)
        Me.Controls.Add(Me.lblSaltLakeInventory)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPalletWeight)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtBoxWeight)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPalletCount)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txtLastPurchaseCost)
        Me.Controls.Add(Me.txtQuantityOnHand)
        Me.Controls.Add(Me.txtBoxCount)
        Me.Controls.Add(Me.txtLastSalePrice)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtPieceWeight)
        Me.Controls.Add(Me.cboPartDescription)
        Me.Controls.Add(Me.cboPartNumber)
        Me.Controls.Add(Me.txtLongDescription)
        Me.Controls.Add(Me.lblItemNumber)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.lblVendorLabel)
        Me.Name = "ItemLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Stock / Price Lookup"
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents txtLongDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblItemNumber As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtLastPurchaseCost As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantityOnHand As System.Windows.Forms.TextBox
    Friend WithEvents txtBoxCount As System.Windows.Forms.TextBox
    Friend WithEvents txtLastSalePrice As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtPieceWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBoxWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPalletCount As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPalletWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents lblHoustonQOH As System.Windows.Forms.Label
    Friend WithEvents lblTruweldInventory As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lblTexasInventory As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents lblAtlantInventory As System.Windows.Forms.Label
    Friend WithEvents lblChicagoInventory As System.Windows.Forms.Label
    Friend WithEvents lblLasVegasInventory As System.Windows.Forms.Label
    Friend WithEvents lblVancouverInventory As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lblTWEInventory As System.Windows.Forms.Label
    Friend WithEvents lblWeldingCeramicsInventory As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lblSaltLakeInventory As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPalletPieces As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTrufitQOH As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdClearData As System.Windows.Forms.Button
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblBought As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtQtyPending As System.Windows.Forms.TextBox
    Friend WithEvents txtStdPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtStdCost As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtOpenPOQuantity As System.Windows.Forms.TextBox
    Friend WithEvents lblTorontoQOH As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtYTDQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtMTDQuantity As System.Windows.Forms.TextBox
    Friend WithEvents lblBlanks As System.Windows.Forms.Label
    Friend WithEvents lblBlankLabel As System.Windows.Forms.Label
    Friend WithEvents lblVendor As System.Windows.Forms.Label
    Friend WithEvents lblVendorLabel As System.Windows.Forms.Label
    Friend WithEvents lblDenverQOH As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblPricingReview As System.Windows.Forms.Label
    Friend WithEvents chkLoadDivisionQOH As System.Windows.Forms.CheckBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtOpenSOQuamtity As System.Windows.Forms.TextBox
    Friend WithEvents lblUpdatedPrice As System.Windows.Forms.Label
    Friend WithEvents lblDENCommitted As System.Windows.Forms.Label
    Friend WithEvents lblTORCommitted As System.Windows.Forms.Label
    Friend WithEvents lblTFPCommitted As System.Windows.Forms.Label
    Friend WithEvents lblHOUCommitted As System.Windows.Forms.Label
    Friend WithEvents lblTWDCommitted As System.Windows.Forms.Label
    Friend WithEvents lblTFTCommitted As System.Windows.Forms.Label
    Friend WithEvents lblATLCommitted As System.Windows.Forms.Label
    Friend WithEvents lblCGOCommitted As System.Windows.Forms.Label
    Friend WithEvents lblCBSCommitted As System.Windows.Forms.Label
    Friend WithEvents lblTFFCommitted As System.Windows.Forms.Label
    Friend WithEvents lblTWECommitted As System.Windows.Forms.Label
    Friend WithEvents lblCHTCommitted As System.Windows.Forms.Label
    Friend WithEvents lblSLCCommitted As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents llLastPurchaseCostPopup As System.Windows.Forms.LinkLabel
    Friend WithEvents lblALBCommitted As System.Windows.Forms.Label
    Friend WithEvents lblAlbertaQOH As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblJerseyCommitted As System.Windows.Forms.Label
    Friend WithEvents lblJerseyQOH As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents llLastSalesPrice As System.Windows.Forms.LinkLabel
    Friend WithEvents lblOnHoldStatus As System.Windows.Forms.Label
    Friend WithEvents lblAccountingHoldStatus As System.Windows.Forms.Label
    Friend WithEvents lblPaymentTerms As System.Windows.Forms.Label
End Class
