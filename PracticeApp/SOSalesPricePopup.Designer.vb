<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SOSalesPricePopup
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.chkShowAllParts = New System.Windows.Forms.CheckBox
        Me.lblPriceLabel = New System.Windows.Forms.Label
        Me.chkInvoicePricing = New System.Windows.Forms.CheckBox
        Me.dgvInvoicePricing = New System.Windows.Forms.DataGridView
        Me.InvoiceLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.InvoiceLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceLineQueryTableAdapter
        Me.dgvSalesOrderLines = New System.Windows.Forms.DataGridView
        Me.SalesOrderLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SalesOrderLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderLineQueryTableAdapter
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityBilledColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriceColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceHeaderKeyColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceLineKeyColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvInvoicePricing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSalesOrderLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkShowAllParts
        '
        Me.chkShowAllParts.AutoSize = True
        Me.chkShowAllParts.ForeColor = System.Drawing.Color.Blue
        Me.chkShowAllParts.Location = New System.Drawing.Point(12, 268)
        Me.chkShowAllParts.Name = "chkShowAllParts"
        Me.chkShowAllParts.Size = New System.Drawing.Size(257, 17)
        Me.chkShowAllParts.TabIndex = 1
        Me.chkShowAllParts.Text = "Show Sales History for All Customers on this Part."
        Me.chkShowAllParts.UseVisualStyleBackColor = True
        '
        'lblPriceLabel
        '
        Me.lblPriceLabel.ForeColor = System.Drawing.Color.Red
        Me.lblPriceLabel.Location = New System.Drawing.Point(363, 265)
        Me.lblPriceLabel.Name = "lblPriceLabel"
        Me.lblPriceLabel.Size = New System.Drawing.Size(155, 26)
        Me.lblPriceLabel.TabIndex = 2
        Me.lblPriceLabel.Text = "*** Prices from Sales Orders ***"
        Me.lblPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkInvoicePricing
        '
        Me.chkInvoicePricing.AutoSize = True
        Me.chkInvoicePricing.ForeColor = System.Drawing.Color.Blue
        Me.chkInvoicePricing.Location = New System.Drawing.Point(12, 295)
        Me.chkInvoicePricing.Name = "chkInvoicePricing"
        Me.chkInvoicePricing.Size = New System.Drawing.Size(154, 17)
        Me.chkInvoicePricing.TabIndex = 3
        Me.chkInvoicePricing.Text = "Show Pricing from Invoices"
        Me.chkInvoicePricing.UseVisualStyleBackColor = True
        '
        'dgvInvoicePricing
        '
        Me.dgvInvoicePricing.AllowUserToAddRows = False
        Me.dgvInvoicePricing.AllowUserToDeleteRows = False
        Me.dgvInvoicePricing.AutoGenerateColumns = False
        Me.dgvInvoicePricing.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInvoicePricing.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvInvoicePricing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoicePricing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerIDColumn1, Me.CustomerPOColumn1, Me.InvoiceDateColumn1, Me.QuantityBilledColumn1, Me.PriceColumn1, Me.SalesOrderNumberColumn1, Me.DivisionIDColumn1, Me.InvoiceHeaderKeyColumn1, Me.InvoiceLineKeyColumn1, Me.PartNumberColumn1, Me.PartDescriptionColumn1})
        Me.dgvInvoicePricing.DataSource = Me.InvoiceLineQueryBindingSource
        Me.dgvInvoicePricing.GridColor = System.Drawing.Color.Lime
        Me.dgvInvoicePricing.Location = New System.Drawing.Point(12, 12)
        Me.dgvInvoicePricing.Name = "dgvInvoicePricing"
        Me.dgvInvoicePricing.ReadOnly = True
        Me.dgvInvoicePricing.Size = New System.Drawing.Size(506, 250)
        Me.dgvInvoicePricing.TabIndex = 4
        '
        'InvoiceLineQueryBindingSource
        '
        Me.InvoiceLineQueryBindingSource.DataMember = "InvoiceLineQuery"
        Me.InvoiceLineQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'InvoiceLineQueryTableAdapter
        '
        Me.InvoiceLineQueryTableAdapter.ClearBeforeFill = True
        '
        'dgvSalesOrderLines
        '
        Me.dgvSalesOrderLines.AllowUserToAddRows = False
        Me.dgvSalesOrderLines.AllowUserToDeleteRows = False
        Me.dgvSalesOrderLines.AutoGenerateColumns = False
        Me.dgvSalesOrderLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSalesOrderLines.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSalesOrderLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSalesOrderLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerPOColumn, Me.CustomerIDColumn, Me.SalesOrderDateColumn, Me.QuantityColumn, Me.PriceColumn, Me.LineStatusColumn, Me.SalesOrderKeyColumn, Me.SalesOrderLineKeyColumn, Me.DivisionKeyColumn, Me.ItemIDColumn})
        Me.dgvSalesOrderLines.DataSource = Me.SalesOrderLineQueryBindingSource
        Me.dgvSalesOrderLines.GridColor = System.Drawing.Color.Fuchsia
        Me.dgvSalesOrderLines.Location = New System.Drawing.Point(12, 12)
        Me.dgvSalesOrderLines.Name = "dgvSalesOrderLines"
        Me.dgvSalesOrderLines.ReadOnly = True
        Me.dgvSalesOrderLines.Size = New System.Drawing.Size(506, 250)
        Me.dgvSalesOrderLines.TabIndex = 5
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
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.HeaderText = "Cust. PO"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        Me.CustomerPOColumn.ReadOnly = True
        Me.CustomerPOColumn.Width = 110
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        Me.CustomerIDColumn.Visible = False
        Me.CustomerIDColumn.Width = 110
        '
        'SalesOrderDateColumn
        '
        Me.SalesOrderDateColumn.DataPropertyName = "SalesOrderDate"
        Me.SalesOrderDateColumn.HeaderText = "SO Date"
        Me.SalesOrderDateColumn.Name = "SalesOrderDateColumn"
        Me.SalesOrderDateColumn.ReadOnly = True
        Me.SalesOrderDateColumn.Width = 110
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.ReadOnly = True
        Me.QuantityColumn.Width = 110
        '
        'PriceColumn
        '
        Me.PriceColumn.DataPropertyName = "Price"
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = "0"
        Me.PriceColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.PriceColumn.HeaderText = "Price"
        Me.PriceColumn.Name = "PriceColumn"
        Me.PriceColumn.ReadOnly = True
        Me.PriceColumn.Width = 110
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "LineStatus"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.ReadOnly = True
        Me.LineStatusColumn.Visible = False
        '
        'SalesOrderKeyColumn
        '
        Me.SalesOrderKeyColumn.DataPropertyName = "SalesOrderKey"
        Me.SalesOrderKeyColumn.HeaderText = "SalesOrderKey"
        Me.SalesOrderKeyColumn.Name = "SalesOrderKeyColumn"
        Me.SalesOrderKeyColumn.ReadOnly = True
        Me.SalesOrderKeyColumn.Visible = False
        '
        'SalesOrderLineKeyColumn
        '
        Me.SalesOrderLineKeyColumn.DataPropertyName = "SalesOrderLineKey"
        Me.SalesOrderLineKeyColumn.HeaderText = "SalesOrderLineKey"
        Me.SalesOrderLineKeyColumn.Name = "SalesOrderLineKeyColumn"
        Me.SalesOrderLineKeyColumn.ReadOnly = True
        Me.SalesOrderLineKeyColumn.Visible = False
        '
        'DivisionKeyColumn
        '
        Me.DivisionKeyColumn.DataPropertyName = "DivisionKey"
        Me.DivisionKeyColumn.HeaderText = "DivisionKey"
        Me.DivisionKeyColumn.Name = "DivisionKeyColumn"
        Me.DivisionKeyColumn.ReadOnly = True
        Me.DivisionKeyColumn.Visible = False
        '
        'ItemIDColumn
        '
        Me.ItemIDColumn.DataPropertyName = "ItemID"
        Me.ItemIDColumn.HeaderText = "Part #"
        Me.ItemIDColumn.Name = "ItemIDColumn"
        Me.ItemIDColumn.ReadOnly = True
        Me.ItemIDColumn.Visible = False
        '
        'CustomerIDColumn1
        '
        Me.CustomerIDColumn1.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn1.HeaderText = "Customer"
        Me.CustomerIDColumn1.Name = "CustomerIDColumn1"
        Me.CustomerIDColumn1.ReadOnly = True
        Me.CustomerIDColumn1.Visible = False
        '
        'CustomerPOColumn1
        '
        Me.CustomerPOColumn1.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn1.HeaderText = "Cust. PO"
        Me.CustomerPOColumn1.Name = "CustomerPOColumn1"
        Me.CustomerPOColumn1.ReadOnly = True
        Me.CustomerPOColumn1.Width = 125
        '
        'InvoiceDateColumn1
        '
        Me.InvoiceDateColumn1.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumn1.HeaderText = "Invoice Date"
        Me.InvoiceDateColumn1.Name = "InvoiceDateColumn1"
        Me.InvoiceDateColumn1.ReadOnly = True
        Me.InvoiceDateColumn1.Width = 110
        '
        'QuantityBilledColumn1
        '
        Me.QuantityBilledColumn1.DataPropertyName = "QuantityBilled"
        Me.QuantityBilledColumn1.HeaderText = "Quantity Billed"
        Me.QuantityBilledColumn1.Name = "QuantityBilledColumn1"
        Me.QuantityBilledColumn1.ReadOnly = True
        Me.QuantityBilledColumn1.Width = 110
        '
        'PriceColumn1
        '
        Me.PriceColumn1.DataPropertyName = "Price"
        DataGridViewCellStyle1.Format = "N4"
        DataGridViewCellStyle1.NullValue = "0"
        Me.PriceColumn1.DefaultCellStyle = DataGridViewCellStyle1
        Me.PriceColumn1.HeaderText = "Price"
        Me.PriceColumn1.Name = "PriceColumn1"
        Me.PriceColumn1.ReadOnly = True
        Me.PriceColumn1.Width = 110
        '
        'SalesOrderNumberColumn1
        '
        Me.SalesOrderNumberColumn1.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberColumn1.HeaderText = "SalesOrderNumber"
        Me.SalesOrderNumberColumn1.Name = "SalesOrderNumberColumn1"
        Me.SalesOrderNumberColumn1.ReadOnly = True
        Me.SalesOrderNumberColumn1.Visible = False
        '
        'DivisionIDColumn1
        '
        Me.DivisionIDColumn1.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn1.HeaderText = "DivisionID"
        Me.DivisionIDColumn1.Name = "DivisionIDColumn1"
        Me.DivisionIDColumn1.ReadOnly = True
        Me.DivisionIDColumn1.Visible = False
        '
        'InvoiceHeaderKeyColumn1
        '
        Me.InvoiceHeaderKeyColumn1.DataPropertyName = "InvoiceHeaderKey"
        Me.InvoiceHeaderKeyColumn1.HeaderText = "InvoiceHeaderKey"
        Me.InvoiceHeaderKeyColumn1.Name = "InvoiceHeaderKeyColumn1"
        Me.InvoiceHeaderKeyColumn1.ReadOnly = True
        Me.InvoiceHeaderKeyColumn1.Visible = False
        '
        'InvoiceLineKeyColumn1
        '
        Me.InvoiceLineKeyColumn1.DataPropertyName = "InvoiceLineKey"
        Me.InvoiceLineKeyColumn1.HeaderText = "InvoiceLineKey"
        Me.InvoiceLineKeyColumn1.Name = "InvoiceLineKeyColumn1"
        Me.InvoiceLineKeyColumn1.ReadOnly = True
        Me.InvoiceLineKeyColumn1.Visible = False
        '
        'PartNumberColumn1
        '
        Me.PartNumberColumn1.DataPropertyName = "PartNumber"
        Me.PartNumberColumn1.HeaderText = "Part #"
        Me.PartNumberColumn1.Name = "PartNumberColumn1"
        Me.PartNumberColumn1.ReadOnly = True
        Me.PartNumberColumn1.Visible = False
        '
        'PartDescriptionColumn1
        '
        Me.PartDescriptionColumn1.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn1.HeaderText = "PartDescription"
        Me.PartDescriptionColumn1.Name = "PartDescriptionColumn1"
        Me.PartDescriptionColumn1.ReadOnly = True
        Me.PartDescriptionColumn1.Visible = False
        '
        'SOSalesPricePopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 323)
        Me.Controls.Add(Me.dgvSalesOrderLines)
        Me.Controls.Add(Me.chkInvoicePricing)
        Me.Controls.Add(Me.lblPriceLabel)
        Me.Controls.Add(Me.chkShowAllParts)
        Me.Controls.Add(Me.dgvInvoicePricing)
        Me.Name = "SOSalesPricePopup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prices entered on Sales Orders"
        CType(Me.dgvInvoicePricing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSalesOrderLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents chkShowAllParts As System.Windows.Forms.CheckBox
    Friend WithEvents lblPriceLabel As System.Windows.Forms.Label
    Friend WithEvents chkInvoicePricing As System.Windows.Forms.CheckBox
    Friend WithEvents dgvInvoicePricing As System.Windows.Forms.DataGridView
    Friend WithEvents InvoiceLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceLineQueryTableAdapter
    Friend WithEvents dgvSalesOrderLines As System.Windows.Forms.DataGridView
    Friend WithEvents SalesOrderLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderLineQueryTableAdapter
    Friend WithEvents CustomerIDColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityBilledColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceHeaderKeyColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceLineKeyColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
