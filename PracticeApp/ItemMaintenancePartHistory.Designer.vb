<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemMaintenancePartHistory
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvInvoiceLineQuery = New System.Windows.Forms.DataGridView
        Me.CustomerNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityBilledColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCOSColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineBoxesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DropShipPONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerialNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOrderedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTax3Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTax2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceCOSColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalSalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BilledFreightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesProdLineIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.lblTotalPartDollars = New System.Windows.Forms.Label
        Me.InvoiceLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceLineQueryTableAdapter
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvInvoiceLineQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(792, 24)
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
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
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
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(632, 521)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 19
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(709, 521)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 20
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvInvoiceLineQuery
        '
        Me.dgvInvoiceLineQuery.AllowUserToAddRows = False
        Me.dgvInvoiceLineQuery.AllowUserToDeleteRows = False
        Me.dgvInvoiceLineQuery.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvInvoiceLineQuery.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInvoiceLineQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInvoiceLineQuery.AutoGenerateColumns = False
        Me.dgvInvoiceLineQuery.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInvoiceLineQuery.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInvoiceLineQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceLineQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerNameColumn, Me.InvoiceDateColumn, Me.SalesOrderNumberColumn, Me.InvoiceHeaderKeyColumn, Me.PartNumberColumn, Me.QuantityBilledColumn, Me.PriceColumn, Me.ExtendedAmountColumn, Me.UnitCostColumn, Me.ExtendedCOSColumn, Me.CustomerPOColumn, Me.InvoiceLineKeyColumn, Me.PartDescriptionColumn, Me.LineCommentColumn, Me.LineWeightColumn, Me.LineBoxesColumn, Me.SalesTaxColumn, Me.LineStatusColumn, Me.DivisionIDColumn, Me.ShipmentNumberColumn, Me.CustomerIDColumn, Me.CreditGLAccountColumn, Me.DebitGLAccountColumn, Me.DropShipPONumberColumn, Me.SOLineNumberColumn, Me.ItemClassColumn, Me.SerialNumberColumn, Me.QuantityOrderedColumn, Me.QuantityOpenColumn, Me.InvoiceStatusColumn, Me.SalesTax3Column, Me.SalesTax2Column, Me.InvoiceCOSColumn, Me.InvoiceTotalColumn, Me.TotalSalesTaxColumn, Me.BilledFreightColumn, Me.ProductTotalColumn, Me.SalesProdLineIDColumn})
        Me.dgvInvoiceLineQuery.DataSource = Me.InvoiceLineQueryBindingSource
        Me.dgvInvoiceLineQuery.GridColor = System.Drawing.Color.Crimson
        Me.dgvInvoiceLineQuery.Location = New System.Drawing.Point(12, 41)
        Me.dgvInvoiceLineQuery.Name = "dgvInvoiceLineQuery"
        Me.dgvInvoiceLineQuery.Size = New System.Drawing.Size(768, 472)
        Me.dgvInvoiceLineQuery.TabIndex = 21
        '
        'CustomerNameColumn
        '
        Me.CustomerNameColumn.DataPropertyName = "CustomerName"
        Me.CustomerNameColumn.HeaderText = "Customer"
        Me.CustomerNameColumn.Name = "CustomerNameColumn"
        '
        'InvoiceDateColumn
        '
        Me.InvoiceDateColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumn.HeaderText = "Invoice Date"
        Me.InvoiceDateColumn.Name = "InvoiceDateColumn"
        Me.InvoiceDateColumn.Width = 80
        '
        'SalesOrderNumberColumn
        '
        Me.SalesOrderNumberColumn.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberColumn.HeaderText = "Order #"
        Me.SalesOrderNumberColumn.Name = "SalesOrderNumberColumn"
        Me.SalesOrderNumberColumn.Width = 80
        '
        'InvoiceHeaderKeyColumn
        '
        Me.InvoiceHeaderKeyColumn.DataPropertyName = "InvoiceHeaderKey"
        Me.InvoiceHeaderKeyColumn.HeaderText = "Invoice #"
        Me.InvoiceHeaderKeyColumn.Name = "InvoiceHeaderKeyColumn"
        Me.InvoiceHeaderKeyColumn.Width = 80
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        '
        'QuantityBilledColumn
        '
        Me.QuantityBilledColumn.DataPropertyName = "QuantityBilled"
        Me.QuantityBilledColumn.HeaderText = "Qty. Billed"
        Me.QuantityBilledColumn.Name = "QuantityBilledColumn"
        Me.QuantityBilledColumn.Width = 80
        '
        'PriceColumn
        '
        Me.PriceColumn.DataPropertyName = "Price"
        DataGridViewCellStyle2.Format = "N5"
        DataGridViewCellStyle2.NullValue = "0"
        Me.PriceColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.PriceColumn.HeaderText = "Price"
        Me.PriceColumn.Name = "PriceColumn"
        Me.PriceColumn.Width = 80
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ExtendedAmountColumn.HeaderText = "Ext. Amt."
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.Width = 80
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle4.Format = "N5"
        DataGridViewCellStyle4.NullValue = "0"
        Me.UnitCostColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.ReadOnly = True
        Me.UnitCostColumn.Width = 80
        '
        'ExtendedCOSColumn
        '
        Me.ExtendedCOSColumn.DataPropertyName = "ExtendedCOS"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.ExtendedCOSColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.ExtendedCOSColumn.HeaderText = "Ext. COS"
        Me.ExtendedCOSColumn.Name = "ExtendedCOSColumn"
        Me.ExtendedCOSColumn.Width = 80
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.HeaderText = "Cust. PO"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        '
        'InvoiceLineKeyColumn
        '
        Me.InvoiceLineKeyColumn.DataPropertyName = "InvoiceLineKey"
        Me.InvoiceLineKeyColumn.HeaderText = "InvoiceLineKey"
        Me.InvoiceLineKeyColumn.Name = "InvoiceLineKeyColumn"
        Me.InvoiceLineKeyColumn.Visible = False
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "PartDescription"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.Visible = False
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "LineComment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        Me.LineCommentColumn.Visible = False
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
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        Me.SalesTaxColumn.HeaderText = "SalesTax"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        Me.SalesTaxColumn.Visible = False
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
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "ShipmentNumber"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        Me.ShipmentNumberColumn.Visible = False
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "CustomerID"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.Visible = False
        '
        'CreditGLAccountColumn
        '
        Me.CreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumn.HeaderText = "CreditGLAccount"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
        Me.CreditGLAccountColumn.Visible = False
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "DebitGLAccount"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        Me.DebitGLAccountColumn.Visible = False
        '
        'DropShipPONumberColumn
        '
        Me.DropShipPONumberColumn.DataPropertyName = "DropShipPONumber"
        Me.DropShipPONumberColumn.HeaderText = "DropShipPONumber"
        Me.DropShipPONumberColumn.Name = "DropShipPONumberColumn"
        Me.DropShipPONumberColumn.Visible = False
        '
        'SOLineNumberColumn
        '
        Me.SOLineNumberColumn.DataPropertyName = "SOLineNumber"
        Me.SOLineNumberColumn.HeaderText = "SOLineNumber"
        Me.SOLineNumberColumn.Name = "SOLineNumberColumn"
        Me.SOLineNumberColumn.Visible = False
        '
        'ItemClassColumn
        '
        Me.ItemClassColumn.DataPropertyName = "ItemClass"
        Me.ItemClassColumn.HeaderText = "ItemClass"
        Me.ItemClassColumn.Name = "ItemClassColumn"
        Me.ItemClassColumn.Visible = False
        '
        'SerialNumberColumn
        '
        Me.SerialNumberColumn.DataPropertyName = "SerialNumber"
        Me.SerialNumberColumn.HeaderText = "SerialNumber"
        Me.SerialNumberColumn.Name = "SerialNumberColumn"
        Me.SerialNumberColumn.Visible = False
        '
        'QuantityOrderedColumn
        '
        Me.QuantityOrderedColumn.DataPropertyName = "QuantityOrdered"
        Me.QuantityOrderedColumn.HeaderText = "QuantityOrdered"
        Me.QuantityOrderedColumn.Name = "QuantityOrderedColumn"
        Me.QuantityOrderedColumn.ReadOnly = True
        Me.QuantityOrderedColumn.Visible = False
        '
        'QuantityOpenColumn
        '
        Me.QuantityOpenColumn.DataPropertyName = "QuantityOpen"
        Me.QuantityOpenColumn.HeaderText = "QuantityOpen"
        Me.QuantityOpenColumn.Name = "QuantityOpenColumn"
        Me.QuantityOpenColumn.ReadOnly = True
        Me.QuantityOpenColumn.Visible = False
        '
        'InvoiceStatusColumn
        '
        Me.InvoiceStatusColumn.DataPropertyName = "InvoiceStatus"
        Me.InvoiceStatusColumn.HeaderText = "InvoiceStatus"
        Me.InvoiceStatusColumn.Name = "InvoiceStatusColumn"
        Me.InvoiceStatusColumn.Visible = False
        '
        'SalesTax3Column
        '
        Me.SalesTax3Column.DataPropertyName = "SalesTax3"
        Me.SalesTax3Column.HeaderText = "SalesTax3"
        Me.SalesTax3Column.Name = "SalesTax3Column"
        Me.SalesTax3Column.Visible = False
        '
        'SalesTax2Column
        '
        Me.SalesTax2Column.DataPropertyName = "SalesTax2"
        Me.SalesTax2Column.HeaderText = "SalesTax2"
        Me.SalesTax2Column.Name = "SalesTax2Column"
        Me.SalesTax2Column.Visible = False
        '
        'InvoiceCOSColumn
        '
        Me.InvoiceCOSColumn.DataPropertyName = "InvoiceCOS"
        Me.InvoiceCOSColumn.HeaderText = "InvoiceCOS"
        Me.InvoiceCOSColumn.Name = "InvoiceCOSColumn"
        Me.InvoiceCOSColumn.Visible = False
        '
        'InvoiceTotalColumn
        '
        Me.InvoiceTotalColumn.DataPropertyName = "InvoiceTotal"
        Me.InvoiceTotalColumn.HeaderText = "InvoiceTotal"
        Me.InvoiceTotalColumn.Name = "InvoiceTotalColumn"
        Me.InvoiceTotalColumn.Visible = False
        '
        'TotalSalesTaxColumn
        '
        Me.TotalSalesTaxColumn.DataPropertyName = "TotalSalesTax"
        Me.TotalSalesTaxColumn.HeaderText = "TotalSalesTax"
        Me.TotalSalesTaxColumn.Name = "TotalSalesTaxColumn"
        Me.TotalSalesTaxColumn.Visible = False
        '
        'BilledFreightColumn
        '
        Me.BilledFreightColumn.DataPropertyName = "BilledFreight"
        Me.BilledFreightColumn.HeaderText = "BilledFreight"
        Me.BilledFreightColumn.Name = "BilledFreightColumn"
        Me.BilledFreightColumn.Visible = False
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        Me.ProductTotalColumn.HeaderText = "ProductTotal"
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        Me.ProductTotalColumn.Visible = False
        '
        'SalesProdLineIDColumn
        '
        Me.SalesProdLineIDColumn.DataPropertyName = "SalesProdLineID"
        Me.SalesProdLineIDColumn.HeaderText = "SalesProdLineID"
        Me.SalesProdLineIDColumn.Name = "SalesProdLineIDColumn"
        Me.SalesProdLineIDColumn.Visible = False
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
        'lblTotalPartDollars
        '
        Me.lblTotalPartDollars.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalPartDollars.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPartDollars.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalPartDollars.Location = New System.Drawing.Point(12, 530)
        Me.lblTotalPartDollars.Name = "lblTotalPartDollars"
        Me.lblTotalPartDollars.Size = New System.Drawing.Size(569, 31)
        Me.lblTotalPartDollars.TabIndex = 22
        Me.lblTotalPartDollars.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InvoiceLineQueryTableAdapter
        '
        Me.InvoiceLineQueryTableAdapter.ClearBeforeFill = True
        '
        'ItemMaintenancePartHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.lblTotalPartDollars)
        Me.Controls.Add(Me.dgvInvoiceLineQuery)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ItemMaintenancePartHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Part Number History"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvInvoiceLineQuery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvInvoiceLineQuery As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents InvoiceLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceLineQueryTableAdapter
    Friend WithEvents CustomerNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityBilledColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCOSColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineBoxesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DropShipPONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOrderedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTax3Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTax2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceCOSColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalSalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BilledFreightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesProdLineIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblTotalPartDollars As System.Windows.Forms.Label
End Class
