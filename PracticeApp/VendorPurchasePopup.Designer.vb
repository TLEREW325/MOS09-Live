<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VendorPurchasePopup
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
        Me.dgvPOLineQuery = New System.Windows.Forms.DataGridView
        Me.PODateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderHeaderKeyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrderQuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderLineNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PODropShipCustomerIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectForInvoiceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POAdditionalShipToDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DropShipSalesOrderNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipMethodIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POHeaderCommentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseAgentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchProdLineIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesProdLineIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.PurchaseOrderLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderLineQueryTableAdapter
        Me.dgvSteelPOQuery = New System.Windows.Forms.DataGridView
        Me.SteelPurchaseOrderDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelPurchaseOrderHeaderKeyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarbonDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseQuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchasePricePerPoundDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelPurchaseLineNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelVendorIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RequireDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstShipDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipViaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelPurchaseLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SteelPurchaseLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelPurchaseLineQueryTableAdapter
        CType(Me.dgvPOLineQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSteelPOQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelPurchaseLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvPOLineQuery
        '
        Me.dgvPOLineQuery.AllowUserToAddRows = False
        Me.dgvPOLineQuery.AllowUserToDeleteRows = False
        Me.dgvPOLineQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPOLineQuery.AutoGenerateColumns = False
        Me.dgvPOLineQuery.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvPOLineQuery.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPOLineQuery.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPOLineQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPOLineQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PODateDataGridViewTextBoxColumn, Me.PurchaseOrderHeaderKeyDataGridViewTextBoxColumn, Me.PartNumberDataGridViewTextBoxColumn, Me.PartDescriptionDataGridViewTextBoxColumn, Me.OrderQuantityDataGridViewTextBoxColumn, Me.UnitCostDataGridViewTextBoxColumn, Me.ExtendedAmountDataGridViewTextBoxColumn, Me.LineStatusDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn, Me.VendorIDDataGridViewTextBoxColumn, Me.PurchaseOrderLineNumberDataGridViewTextBoxColumn, Me.PODropShipCustomerIDDataGridViewTextBoxColumn, Me.ShipDateDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn, Me.DebitGLAccountDataGridViewTextBoxColumn, Me.CreditGLAccountDataGridViewTextBoxColumn, Me.SelectForInvoiceDataGridViewTextBoxColumn, Me.LineCommentDataGridViewTextBoxColumn, Me.POAdditionalShipToDataGridViewTextBoxColumn, Me.DropShipSalesOrderNumberDataGridViewTextBoxColumn, Me.ShipMethodIDDataGridViewTextBoxColumn, Me.POHeaderCommentDataGridViewTextBoxColumn, Me.PaymentCodeDataGridViewTextBoxColumn, Me.PurchaseAgentDataGridViewTextBoxColumn, Me.ItemClassDataGridViewTextBoxColumn, Me.PurchProdLineIDDataGridViewTextBoxColumn, Me.SalesProdLineIDDataGridViewTextBoxColumn})
        Me.dgvPOLineQuery.DataSource = Me.PurchaseOrderLineQueryBindingSource
        Me.dgvPOLineQuery.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvPOLineQuery.Location = New System.Drawing.Point(1, 12)
        Me.dgvPOLineQuery.Name = "dgvPOLineQuery"
        Me.dgvPOLineQuery.ReadOnly = True
        Me.dgvPOLineQuery.Size = New System.Drawing.Size(542, 310)
        Me.dgvPOLineQuery.TabIndex = 0
        '
        'PODateDataGridViewTextBoxColumn
        '
        Me.PODateDataGridViewTextBoxColumn.DataPropertyName = "PODate"
        Me.PODateDataGridViewTextBoxColumn.HeaderText = "PO Date"
        Me.PODateDataGridViewTextBoxColumn.Name = "PODateDataGridViewTextBoxColumn"
        Me.PODateDataGridViewTextBoxColumn.ReadOnly = True
        Me.PODateDataGridViewTextBoxColumn.Width = 65
        '
        'PurchaseOrderHeaderKeyDataGridViewTextBoxColumn
        '
        Me.PurchaseOrderHeaderKeyDataGridViewTextBoxColumn.DataPropertyName = "PurchaseOrderHeaderKey"
        Me.PurchaseOrderHeaderKeyDataGridViewTextBoxColumn.HeaderText = "PO #"
        Me.PurchaseOrderHeaderKeyDataGridViewTextBoxColumn.Name = "PurchaseOrderHeaderKeyDataGridViewTextBoxColumn"
        Me.PurchaseOrderHeaderKeyDataGridViewTextBoxColumn.ReadOnly = True
        Me.PurchaseOrderHeaderKeyDataGridViewTextBoxColumn.Width = 80
        '
        'PartNumberDataGridViewTextBoxColumn
        '
        Me.PartNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn.HeaderText = "Part #"
        Me.PartNumberDataGridViewTextBoxColumn.Name = "PartNumberDataGridViewTextBoxColumn"
        Me.PartNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PartDescriptionDataGridViewTextBoxColumn
        '
        Me.PartDescriptionDataGridViewTextBoxColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.PartDescriptionDataGridViewTextBoxColumn.Name = "PartDescriptionDataGridViewTextBoxColumn"
        Me.PartDescriptionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'OrderQuantityDataGridViewTextBoxColumn
        '
        Me.OrderQuantityDataGridViewTextBoxColumn.DataPropertyName = "OrderQuantity"
        Me.OrderQuantityDataGridViewTextBoxColumn.HeaderText = "Order Qty"
        Me.OrderQuantityDataGridViewTextBoxColumn.Name = "OrderQuantityDataGridViewTextBoxColumn"
        Me.OrderQuantityDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrderQuantityDataGridViewTextBoxColumn.Width = 80
        '
        'UnitCostDataGridViewTextBoxColumn
        '
        Me.UnitCostDataGridViewTextBoxColumn.DataPropertyName = "UnitCost"
        Me.UnitCostDataGridViewTextBoxColumn.HeaderText = "Unit Cost"
        Me.UnitCostDataGridViewTextBoxColumn.Name = "UnitCostDataGridViewTextBoxColumn"
        Me.UnitCostDataGridViewTextBoxColumn.ReadOnly = True
        Me.UnitCostDataGridViewTextBoxColumn.Width = 80
        '
        'ExtendedAmountDataGridViewTextBoxColumn
        '
        Me.ExtendedAmountDataGridViewTextBoxColumn.DataPropertyName = "ExtendedAmount"
        Me.ExtendedAmountDataGridViewTextBoxColumn.HeaderText = "Extended Amt"
        Me.ExtendedAmountDataGridViewTextBoxColumn.Name = "ExtendedAmountDataGridViewTextBoxColumn"
        Me.ExtendedAmountDataGridViewTextBoxColumn.ReadOnly = True
        Me.ExtendedAmountDataGridViewTextBoxColumn.Width = 80
        '
        'LineStatusDataGridViewTextBoxColumn
        '
        Me.LineStatusDataGridViewTextBoxColumn.DataPropertyName = "LineStatus"
        Me.LineStatusDataGridViewTextBoxColumn.HeaderText = "LineStatus"
        Me.LineStatusDataGridViewTextBoxColumn.Name = "LineStatusDataGridViewTextBoxColumn"
        Me.LineStatusDataGridViewTextBoxColumn.ReadOnly = True
        Me.LineStatusDataGridViewTextBoxColumn.Visible = False
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.DivisionIDDataGridViewTextBoxColumn.Visible = False
        '
        'VendorIDDataGridViewTextBoxColumn
        '
        Me.VendorIDDataGridViewTextBoxColumn.DataPropertyName = "VendorID"
        Me.VendorIDDataGridViewTextBoxColumn.HeaderText = "VendorID"
        Me.VendorIDDataGridViewTextBoxColumn.Name = "VendorIDDataGridViewTextBoxColumn"
        Me.VendorIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.VendorIDDataGridViewTextBoxColumn.Visible = False
        '
        'PurchaseOrderLineNumberDataGridViewTextBoxColumn
        '
        Me.PurchaseOrderLineNumberDataGridViewTextBoxColumn.DataPropertyName = "PurchaseOrderLineNumber"
        Me.PurchaseOrderLineNumberDataGridViewTextBoxColumn.HeaderText = "PurchaseOrderLineNumber"
        Me.PurchaseOrderLineNumberDataGridViewTextBoxColumn.Name = "PurchaseOrderLineNumberDataGridViewTextBoxColumn"
        Me.PurchaseOrderLineNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.PurchaseOrderLineNumberDataGridViewTextBoxColumn.Visible = False
        '
        'PODropShipCustomerIDDataGridViewTextBoxColumn
        '
        Me.PODropShipCustomerIDDataGridViewTextBoxColumn.DataPropertyName = "PODropShipCustomerID"
        Me.PODropShipCustomerIDDataGridViewTextBoxColumn.HeaderText = "PODropShipCustomerID"
        Me.PODropShipCustomerIDDataGridViewTextBoxColumn.Name = "PODropShipCustomerIDDataGridViewTextBoxColumn"
        Me.PODropShipCustomerIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.PODropShipCustomerIDDataGridViewTextBoxColumn.Visible = False
        '
        'ShipDateDataGridViewTextBoxColumn
        '
        Me.ShipDateDataGridViewTextBoxColumn.DataPropertyName = "ShipDate"
        Me.ShipDateDataGridViewTextBoxColumn.HeaderText = "ShipDate"
        Me.ShipDateDataGridViewTextBoxColumn.Name = "ShipDateDataGridViewTextBoxColumn"
        Me.ShipDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.ShipDateDataGridViewTextBoxColumn.Visible = False
        '
        'StatusDataGridViewTextBoxColumn
        '
        Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
        Me.StatusDataGridViewTextBoxColumn.HeaderText = "Status"
        Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
        Me.StatusDataGridViewTextBoxColumn.ReadOnly = True
        Me.StatusDataGridViewTextBoxColumn.Visible = False
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
        'SelectForInvoiceDataGridViewTextBoxColumn
        '
        Me.SelectForInvoiceDataGridViewTextBoxColumn.DataPropertyName = "SelectForInvoice"
        Me.SelectForInvoiceDataGridViewTextBoxColumn.HeaderText = "SelectForInvoice"
        Me.SelectForInvoiceDataGridViewTextBoxColumn.Name = "SelectForInvoiceDataGridViewTextBoxColumn"
        Me.SelectForInvoiceDataGridViewTextBoxColumn.ReadOnly = True
        Me.SelectForInvoiceDataGridViewTextBoxColumn.Visible = False
        '
        'LineCommentDataGridViewTextBoxColumn
        '
        Me.LineCommentDataGridViewTextBoxColumn.DataPropertyName = "LineComment"
        Me.LineCommentDataGridViewTextBoxColumn.HeaderText = "LineComment"
        Me.LineCommentDataGridViewTextBoxColumn.Name = "LineCommentDataGridViewTextBoxColumn"
        Me.LineCommentDataGridViewTextBoxColumn.ReadOnly = True
        Me.LineCommentDataGridViewTextBoxColumn.Visible = False
        '
        'POAdditionalShipToDataGridViewTextBoxColumn
        '
        Me.POAdditionalShipToDataGridViewTextBoxColumn.DataPropertyName = "POAdditionalShipTo"
        Me.POAdditionalShipToDataGridViewTextBoxColumn.HeaderText = "POAdditionalShipTo"
        Me.POAdditionalShipToDataGridViewTextBoxColumn.Name = "POAdditionalShipToDataGridViewTextBoxColumn"
        Me.POAdditionalShipToDataGridViewTextBoxColumn.ReadOnly = True
        Me.POAdditionalShipToDataGridViewTextBoxColumn.Visible = False
        '
        'DropShipSalesOrderNumberDataGridViewTextBoxColumn
        '
        Me.DropShipSalesOrderNumberDataGridViewTextBoxColumn.DataPropertyName = "DropShipSalesOrderNumber"
        Me.DropShipSalesOrderNumberDataGridViewTextBoxColumn.HeaderText = "DropShipSalesOrderNumber"
        Me.DropShipSalesOrderNumberDataGridViewTextBoxColumn.Name = "DropShipSalesOrderNumberDataGridViewTextBoxColumn"
        Me.DropShipSalesOrderNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.DropShipSalesOrderNumberDataGridViewTextBoxColumn.Visible = False
        '
        'ShipMethodIDDataGridViewTextBoxColumn
        '
        Me.ShipMethodIDDataGridViewTextBoxColumn.DataPropertyName = "ShipMethodID"
        Me.ShipMethodIDDataGridViewTextBoxColumn.HeaderText = "ShipMethodID"
        Me.ShipMethodIDDataGridViewTextBoxColumn.Name = "ShipMethodIDDataGridViewTextBoxColumn"
        Me.ShipMethodIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.ShipMethodIDDataGridViewTextBoxColumn.Visible = False
        '
        'POHeaderCommentDataGridViewTextBoxColumn
        '
        Me.POHeaderCommentDataGridViewTextBoxColumn.DataPropertyName = "POHeaderComment"
        Me.POHeaderCommentDataGridViewTextBoxColumn.HeaderText = "POHeaderComment"
        Me.POHeaderCommentDataGridViewTextBoxColumn.Name = "POHeaderCommentDataGridViewTextBoxColumn"
        Me.POHeaderCommentDataGridViewTextBoxColumn.ReadOnly = True
        Me.POHeaderCommentDataGridViewTextBoxColumn.Visible = False
        '
        'PaymentCodeDataGridViewTextBoxColumn
        '
        Me.PaymentCodeDataGridViewTextBoxColumn.DataPropertyName = "PaymentCode"
        Me.PaymentCodeDataGridViewTextBoxColumn.HeaderText = "PaymentCode"
        Me.PaymentCodeDataGridViewTextBoxColumn.Name = "PaymentCodeDataGridViewTextBoxColumn"
        Me.PaymentCodeDataGridViewTextBoxColumn.ReadOnly = True
        Me.PaymentCodeDataGridViewTextBoxColumn.Visible = False
        '
        'PurchaseAgentDataGridViewTextBoxColumn
        '
        Me.PurchaseAgentDataGridViewTextBoxColumn.DataPropertyName = "PurchaseAgent"
        Me.PurchaseAgentDataGridViewTextBoxColumn.HeaderText = "PurchaseAgent"
        Me.PurchaseAgentDataGridViewTextBoxColumn.Name = "PurchaseAgentDataGridViewTextBoxColumn"
        Me.PurchaseAgentDataGridViewTextBoxColumn.ReadOnly = True
        Me.PurchaseAgentDataGridViewTextBoxColumn.Visible = False
        '
        'ItemClassDataGridViewTextBoxColumn
        '
        Me.ItemClassDataGridViewTextBoxColumn.DataPropertyName = "ItemClass"
        Me.ItemClassDataGridViewTextBoxColumn.HeaderText = "ItemClass"
        Me.ItemClassDataGridViewTextBoxColumn.Name = "ItemClassDataGridViewTextBoxColumn"
        Me.ItemClassDataGridViewTextBoxColumn.ReadOnly = True
        Me.ItemClassDataGridViewTextBoxColumn.Visible = False
        '
        'PurchProdLineIDDataGridViewTextBoxColumn
        '
        Me.PurchProdLineIDDataGridViewTextBoxColumn.DataPropertyName = "PurchProdLineID"
        Me.PurchProdLineIDDataGridViewTextBoxColumn.HeaderText = "PurchProdLineID"
        Me.PurchProdLineIDDataGridViewTextBoxColumn.Name = "PurchProdLineIDDataGridViewTextBoxColumn"
        Me.PurchProdLineIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.PurchProdLineIDDataGridViewTextBoxColumn.Visible = False
        '
        'SalesProdLineIDDataGridViewTextBoxColumn
        '
        Me.SalesProdLineIDDataGridViewTextBoxColumn.DataPropertyName = "SalesProdLineID"
        Me.SalesProdLineIDDataGridViewTextBoxColumn.HeaderText = "SalesProdLineID"
        Me.SalesProdLineIDDataGridViewTextBoxColumn.Name = "SalesProdLineIDDataGridViewTextBoxColumn"
        Me.SalesProdLineIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.SalesProdLineIDDataGridViewTextBoxColumn.Visible = False
        '
        'PurchaseOrderLineQueryBindingSource
        '
        Me.PurchaseOrderLineQueryBindingSource.DataMember = "PurchaseOrderLineQuery"
        Me.PurchaseOrderLineQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PurchaseOrderLineQueryTableAdapter
        '
        Me.PurchaseOrderLineQueryTableAdapter.ClearBeforeFill = True
        '
        'dgvSteelPOQuery
        '
        Me.dgvSteelPOQuery.AllowUserToAddRows = False
        Me.dgvSteelPOQuery.AllowUserToDeleteRows = False
        Me.dgvSteelPOQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSteelPOQuery.AutoGenerateColumns = False
        Me.dgvSteelPOQuery.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelPOQuery.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSteelPOQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelPOQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SteelPurchaseOrderDateDataGridViewTextBoxColumn, Me.SteelPurchaseOrderHeaderKeyDataGridViewTextBoxColumn, Me.CarbonDataGridViewTextBoxColumn, Me.SteelSizeDataGridViewTextBoxColumn, Me.PurchaseQuantityDataGridViewTextBoxColumn, Me.PurchasePricePerPoundDataGridViewTextBoxColumn, Me.ExtendedAmountDataGridViewTextBoxColumn1, Me.LineStatusDataGridViewTextBoxColumn1, Me.DebitGLAccountDataGridViewTextBoxColumn1, Me.CreditGLAccountDataGridViewTextBoxColumn1, Me.DivisionIDDataGridViewTextBoxColumn1, Me.SteelPurchaseLineNumberDataGridViewTextBoxColumn, Me.SteelVendorIDDataGridViewTextBoxColumn, Me.DescriptionDataGridViewTextBoxColumn, Me.RMIDDataGridViewTextBoxColumn, Me.RequireDateDataGridViewTextBoxColumn, Me.EstShipDateDataGridViewTextBoxColumn, Me.ShipViaDataGridViewTextBoxColumn, Me.LineCommentDataGridViewTextBoxColumn1, Me.StatusDataGridViewTextBoxColumn1})
        Me.dgvSteelPOQuery.DataSource = Me.SteelPurchaseLineQueryBindingSource
        Me.dgvSteelPOQuery.GridColor = System.Drawing.Color.Blue
        Me.dgvSteelPOQuery.Location = New System.Drawing.Point(1, 12)
        Me.dgvSteelPOQuery.Name = "dgvSteelPOQuery"
        Me.dgvSteelPOQuery.ReadOnly = True
        Me.dgvSteelPOQuery.Size = New System.Drawing.Size(542, 310)
        Me.dgvSteelPOQuery.TabIndex = 1
        '
        'SteelPurchaseOrderDateDataGridViewTextBoxColumn
        '
        Me.SteelPurchaseOrderDateDataGridViewTextBoxColumn.DataPropertyName = "SteelPurchaseOrderDate"
        Me.SteelPurchaseOrderDateDataGridViewTextBoxColumn.HeaderText = "PO Date"
        Me.SteelPurchaseOrderDateDataGridViewTextBoxColumn.Name = "SteelPurchaseOrderDateDataGridViewTextBoxColumn"
        Me.SteelPurchaseOrderDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.SteelPurchaseOrderDateDataGridViewTextBoxColumn.Width = 65
        '
        'SteelPurchaseOrderHeaderKeyDataGridViewTextBoxColumn
        '
        Me.SteelPurchaseOrderHeaderKeyDataGridViewTextBoxColumn.DataPropertyName = "SteelPurchaseOrderHeaderKey"
        Me.SteelPurchaseOrderHeaderKeyDataGridViewTextBoxColumn.HeaderText = "PO #"
        Me.SteelPurchaseOrderHeaderKeyDataGridViewTextBoxColumn.Name = "SteelPurchaseOrderHeaderKeyDataGridViewTextBoxColumn"
        Me.SteelPurchaseOrderHeaderKeyDataGridViewTextBoxColumn.ReadOnly = True
        Me.SteelPurchaseOrderHeaderKeyDataGridViewTextBoxColumn.Width = 80
        '
        'CarbonDataGridViewTextBoxColumn
        '
        Me.CarbonDataGridViewTextBoxColumn.DataPropertyName = "Carbon"
        Me.CarbonDataGridViewTextBoxColumn.HeaderText = "Carbon"
        Me.CarbonDataGridViewTextBoxColumn.Name = "CarbonDataGridViewTextBoxColumn"
        Me.CarbonDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SteelSizeDataGridViewTextBoxColumn
        '
        Me.SteelSizeDataGridViewTextBoxColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeDataGridViewTextBoxColumn.HeaderText = "Size"
        Me.SteelSizeDataGridViewTextBoxColumn.Name = "SteelSizeDataGridViewTextBoxColumn"
        Me.SteelSizeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PurchaseQuantityDataGridViewTextBoxColumn
        '
        Me.PurchaseQuantityDataGridViewTextBoxColumn.DataPropertyName = "PurchaseQuantity"
        Me.PurchaseQuantityDataGridViewTextBoxColumn.HeaderText = "Qty"
        Me.PurchaseQuantityDataGridViewTextBoxColumn.Name = "PurchaseQuantityDataGridViewTextBoxColumn"
        Me.PurchaseQuantityDataGridViewTextBoxColumn.ReadOnly = True
        Me.PurchaseQuantityDataGridViewTextBoxColumn.Width = 80
        '
        'PurchasePricePerPoundDataGridViewTextBoxColumn
        '
        Me.PurchasePricePerPoundDataGridViewTextBoxColumn.DataPropertyName = "PurchasePricePerPound"
        Me.PurchasePricePerPoundDataGridViewTextBoxColumn.HeaderText = "Price/Lb."
        Me.PurchasePricePerPoundDataGridViewTextBoxColumn.Name = "PurchasePricePerPoundDataGridViewTextBoxColumn"
        Me.PurchasePricePerPoundDataGridViewTextBoxColumn.ReadOnly = True
        Me.PurchasePricePerPoundDataGridViewTextBoxColumn.Width = 80
        '
        'ExtendedAmountDataGridViewTextBoxColumn1
        '
        Me.ExtendedAmountDataGridViewTextBoxColumn1.DataPropertyName = "ExtendedAmount"
        Me.ExtendedAmountDataGridViewTextBoxColumn1.HeaderText = "Ext. Amt."
        Me.ExtendedAmountDataGridViewTextBoxColumn1.Name = "ExtendedAmountDataGridViewTextBoxColumn1"
        Me.ExtendedAmountDataGridViewTextBoxColumn1.ReadOnly = True
        Me.ExtendedAmountDataGridViewTextBoxColumn1.Width = 80
        '
        'LineStatusDataGridViewTextBoxColumn1
        '
        Me.LineStatusDataGridViewTextBoxColumn1.DataPropertyName = "LineStatus"
        Me.LineStatusDataGridViewTextBoxColumn1.HeaderText = "LineStatus"
        Me.LineStatusDataGridViewTextBoxColumn1.Name = "LineStatusDataGridViewTextBoxColumn1"
        Me.LineStatusDataGridViewTextBoxColumn1.ReadOnly = True
        Me.LineStatusDataGridViewTextBoxColumn1.Visible = False
        '
        'DebitGLAccountDataGridViewTextBoxColumn1
        '
        Me.DebitGLAccountDataGridViewTextBoxColumn1.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountDataGridViewTextBoxColumn1.HeaderText = "DebitGLAccount"
        Me.DebitGLAccountDataGridViewTextBoxColumn1.Name = "DebitGLAccountDataGridViewTextBoxColumn1"
        Me.DebitGLAccountDataGridViewTextBoxColumn1.ReadOnly = True
        Me.DebitGLAccountDataGridViewTextBoxColumn1.Visible = False
        '
        'CreditGLAccountDataGridViewTextBoxColumn1
        '
        Me.CreditGLAccountDataGridViewTextBoxColumn1.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountDataGridViewTextBoxColumn1.HeaderText = "CreditGLAccount"
        Me.CreditGLAccountDataGridViewTextBoxColumn1.Name = "CreditGLAccountDataGridViewTextBoxColumn1"
        Me.CreditGLAccountDataGridViewTextBoxColumn1.ReadOnly = True
        Me.CreditGLAccountDataGridViewTextBoxColumn1.Visible = False
        '
        'DivisionIDDataGridViewTextBoxColumn1
        '
        Me.DivisionIDDataGridViewTextBoxColumn1.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn1.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn1.Name = "DivisionIDDataGridViewTextBoxColumn1"
        Me.DivisionIDDataGridViewTextBoxColumn1.ReadOnly = True
        Me.DivisionIDDataGridViewTextBoxColumn1.Visible = False
        '
        'SteelPurchaseLineNumberDataGridViewTextBoxColumn
        '
        Me.SteelPurchaseLineNumberDataGridViewTextBoxColumn.DataPropertyName = "SteelPurchaseLineNumber"
        Me.SteelPurchaseLineNumberDataGridViewTextBoxColumn.HeaderText = "SteelPurchaseLineNumber"
        Me.SteelPurchaseLineNumberDataGridViewTextBoxColumn.Name = "SteelPurchaseLineNumberDataGridViewTextBoxColumn"
        Me.SteelPurchaseLineNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.SteelPurchaseLineNumberDataGridViewTextBoxColumn.Visible = False
        '
        'SteelVendorIDDataGridViewTextBoxColumn
        '
        Me.SteelVendorIDDataGridViewTextBoxColumn.DataPropertyName = "SteelVendorID"
        Me.SteelVendorIDDataGridViewTextBoxColumn.HeaderText = "SteelVendorID"
        Me.SteelVendorIDDataGridViewTextBoxColumn.Name = "SteelVendorIDDataGridViewTextBoxColumn"
        Me.SteelVendorIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.SteelVendorIDDataGridViewTextBoxColumn.Visible = False
        '
        'DescriptionDataGridViewTextBoxColumn
        '
        Me.DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        Me.DescriptionDataGridViewTextBoxColumn.ReadOnly = True
        Me.DescriptionDataGridViewTextBoxColumn.Visible = False
        '
        'RMIDDataGridViewTextBoxColumn
        '
        Me.RMIDDataGridViewTextBoxColumn.DataPropertyName = "RMID"
        Me.RMIDDataGridViewTextBoxColumn.HeaderText = "RMID"
        Me.RMIDDataGridViewTextBoxColumn.Name = "RMIDDataGridViewTextBoxColumn"
        Me.RMIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.RMIDDataGridViewTextBoxColumn.Visible = False
        '
        'RequireDateDataGridViewTextBoxColumn
        '
        Me.RequireDateDataGridViewTextBoxColumn.DataPropertyName = "RequireDate"
        Me.RequireDateDataGridViewTextBoxColumn.HeaderText = "RequireDate"
        Me.RequireDateDataGridViewTextBoxColumn.Name = "RequireDateDataGridViewTextBoxColumn"
        Me.RequireDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.RequireDateDataGridViewTextBoxColumn.Visible = False
        '
        'EstShipDateDataGridViewTextBoxColumn
        '
        Me.EstShipDateDataGridViewTextBoxColumn.DataPropertyName = "EstShipDate"
        Me.EstShipDateDataGridViewTextBoxColumn.HeaderText = "EstShipDate"
        Me.EstShipDateDataGridViewTextBoxColumn.Name = "EstShipDateDataGridViewTextBoxColumn"
        Me.EstShipDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.EstShipDateDataGridViewTextBoxColumn.Visible = False
        '
        'ShipViaDataGridViewTextBoxColumn
        '
        Me.ShipViaDataGridViewTextBoxColumn.DataPropertyName = "ShipVia"
        Me.ShipViaDataGridViewTextBoxColumn.HeaderText = "ShipVia"
        Me.ShipViaDataGridViewTextBoxColumn.Name = "ShipViaDataGridViewTextBoxColumn"
        Me.ShipViaDataGridViewTextBoxColumn.ReadOnly = True
        Me.ShipViaDataGridViewTextBoxColumn.Visible = False
        '
        'LineCommentDataGridViewTextBoxColumn1
        '
        Me.LineCommentDataGridViewTextBoxColumn1.DataPropertyName = "LineComment"
        Me.LineCommentDataGridViewTextBoxColumn1.HeaderText = "LineComment"
        Me.LineCommentDataGridViewTextBoxColumn1.Name = "LineCommentDataGridViewTextBoxColumn1"
        Me.LineCommentDataGridViewTextBoxColumn1.ReadOnly = True
        Me.LineCommentDataGridViewTextBoxColumn1.Visible = False
        '
        'StatusDataGridViewTextBoxColumn1
        '
        Me.StatusDataGridViewTextBoxColumn1.DataPropertyName = "Status"
        Me.StatusDataGridViewTextBoxColumn1.HeaderText = "Status"
        Me.StatusDataGridViewTextBoxColumn1.Name = "StatusDataGridViewTextBoxColumn1"
        Me.StatusDataGridViewTextBoxColumn1.ReadOnly = True
        Me.StatusDataGridViewTextBoxColumn1.Visible = False
        '
        'SteelPurchaseLineQueryBindingSource
        '
        Me.SteelPurchaseLineQueryBindingSource.DataMember = "SteelPurchaseLineQuery"
        Me.SteelPurchaseLineQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SteelPurchaseLineQueryTableAdapter
        '
        Me.SteelPurchaseLineQueryTableAdapter.ClearBeforeFill = True
        '
        'VendorPurchasePopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 323)
        Me.Controls.Add(Me.dgvSteelPOQuery)
        Me.Controls.Add(Me.dgvPOLineQuery)
        Me.Name = "VendorPurchasePopup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vendor Purchase History"
        CType(Me.dgvPOLineQuery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSteelPOQuery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelPurchaseLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvPOLineQuery As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents PurchaseOrderLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderLineQueryTableAdapter
    Friend WithEvents PODateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseOrderHeaderKeyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseOrderLineNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODropShipCustomerIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForInvoiceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POAdditionalShipToDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DropShipSalesOrderNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipMethodIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POHeaderCommentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseAgentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchProdLineIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesProdLineIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvSteelPOQuery As System.Windows.Forms.DataGridView
    Friend WithEvents SteelPurchaseLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelPurchaseLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelPurchaseLineQueryTableAdapter
    Friend WithEvents SteelPurchaseOrderDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelPurchaseOrderHeaderKeyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchasePricePerPoundDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelPurchaseLineNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelVendorIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RequireDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstShipDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipViaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
