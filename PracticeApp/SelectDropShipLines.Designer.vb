<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectDropShipLines
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
        Me.dgvDropShipLines = New System.Windows.Forms.DataGridView
        Me.PurchaseOrderLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.cmdSaveLines = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.PurchaseOrderLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderLineTableTableAdapter
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.PurchaseOrderHeaderKeyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectForInvoiceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.PurchaseOrderLineNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrderQuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvDropShipLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDropShipLines
        '
        Me.dgvDropShipLines.AllowUserToAddRows = False
        Me.dgvDropShipLines.AllowUserToDeleteRows = False
        Me.dgvDropShipLines.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDropShipLines.AutoGenerateColumns = False
        Me.dgvDropShipLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvDropShipLines.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDropShipLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDropShipLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PurchaseOrderHeaderKeyDataGridViewTextBoxColumn, Me.SelectForInvoiceDataGridViewTextBoxColumn, Me.PurchaseOrderLineNumberDataGridViewTextBoxColumn, Me.PartNumberDataGridViewTextBoxColumn, Me.PartDescriptionDataGridViewTextBoxColumn, Me.OrderQuantityDataGridViewTextBoxColumn, Me.UnitCostDataGridViewTextBoxColumn, Me.ExtendedAmountDataGridViewTextBoxColumn, Me.LineStatusDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn, Me.DebitGLAccountDataGridViewTextBoxColumn, Me.CreditGLAccountDataGridViewTextBoxColumn})
        Me.dgvDropShipLines.DataSource = Me.PurchaseOrderLineTableBindingSource
        Me.dgvDropShipLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvDropShipLines.Location = New System.Drawing.Point(12, 6)
        Me.dgvDropShipLines.Name = "dgvDropShipLines"
        Me.dgvDropShipLines.Size = New System.Drawing.Size(633, 310)
        Me.dgvDropShipLines.TabIndex = 8
        '
        'PurchaseOrderLineTableBindingSource
        '
        Me.PurchaseOrderLineTableBindingSource.DataMember = "PurchaseOrderLineTable"
        Me.PurchaseOrderLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectAll.Location = New System.Drawing.Point(11, 332)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectAll.TabIndex = 7
        Me.cmdSelectAll.Text = "Check All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'cmdSaveLines
        '
        Me.cmdSaveLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSaveLines.Location = New System.Drawing.Point(496, 332)
        Me.cmdSaveLines.Name = "cmdSaveLines"
        Me.cmdSaveLines.Size = New System.Drawing.Size(71, 40)
        Me.cmdSaveLines.TabIndex = 6
        Me.cmdSaveLines.Text = "Save"
        Me.cmdSaveLines.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(573, 332)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 5
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'PurchaseOrderLineTableTableAdapter
        '
        Me.PurchaseOrderLineTableTableAdapter.ClearBeforeFill = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(88, 332)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 9
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'PurchaseOrderHeaderKeyDataGridViewTextBoxColumn
        '
        Me.PurchaseOrderHeaderKeyDataGridViewTextBoxColumn.DataPropertyName = "PurchaseOrderHeaderKey"
        Me.PurchaseOrderHeaderKeyDataGridViewTextBoxColumn.HeaderText = "PurchaseOrderHeaderKey"
        Me.PurchaseOrderHeaderKeyDataGridViewTextBoxColumn.Name = "PurchaseOrderHeaderKeyDataGridViewTextBoxColumn"
        Me.PurchaseOrderHeaderKeyDataGridViewTextBoxColumn.Visible = False
        '
        'SelectForInvoiceDataGridViewTextBoxColumn
        '
        Me.SelectForInvoiceDataGridViewTextBoxColumn.DataPropertyName = "SelectForInvoice"
        Me.SelectForInvoiceDataGridViewTextBoxColumn.FalseValue = "OPEN"
        Me.SelectForInvoiceDataGridViewTextBoxColumn.HeaderText = "Select"
        Me.SelectForInvoiceDataGridViewTextBoxColumn.Name = "SelectForInvoiceDataGridViewTextBoxColumn"
        Me.SelectForInvoiceDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SelectForInvoiceDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.SelectForInvoiceDataGridViewTextBoxColumn.TrueValue = "RECEIVED"
        Me.SelectForInvoiceDataGridViewTextBoxColumn.Width = 65
        '
        'PurchaseOrderLineNumberDataGridViewTextBoxColumn
        '
        Me.PurchaseOrderLineNumberDataGridViewTextBoxColumn.DataPropertyName = "PurchaseOrderLineNumber"
        Me.PurchaseOrderLineNumberDataGridViewTextBoxColumn.HeaderText = "Line #"
        Me.PurchaseOrderLineNumberDataGridViewTextBoxColumn.Name = "PurchaseOrderLineNumberDataGridViewTextBoxColumn"
        Me.PurchaseOrderLineNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.PurchaseOrderLineNumberDataGridViewTextBoxColumn.Width = 65
        '
        'PartNumberDataGridViewTextBoxColumn
        '
        Me.PartNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn.HeaderText = "Part Number"
        Me.PartNumberDataGridViewTextBoxColumn.Name = "PartNumberDataGridViewTextBoxColumn"
        Me.PartNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PartDescriptionDataGridViewTextBoxColumn
        '
        Me.PartDescriptionDataGridViewTextBoxColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionDataGridViewTextBoxColumn.HeaderText = "Part Description"
        Me.PartDescriptionDataGridViewTextBoxColumn.Name = "PartDescriptionDataGridViewTextBoxColumn"
        Me.PartDescriptionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'OrderQuantityDataGridViewTextBoxColumn
        '
        Me.OrderQuantityDataGridViewTextBoxColumn.DataPropertyName = "OrderQuantity"
        DataGridViewCellStyle1.NullValue = "0"
        Me.OrderQuantityDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.OrderQuantityDataGridViewTextBoxColumn.HeaderText = "Order Quantity"
        Me.OrderQuantityDataGridViewTextBoxColumn.Name = "OrderQuantityDataGridViewTextBoxColumn"
        Me.OrderQuantityDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrderQuantityDataGridViewTextBoxColumn.Width = 95
        '
        'UnitCostDataGridViewTextBoxColumn
        '
        Me.UnitCostDataGridViewTextBoxColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = "0"
        Me.UnitCostDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.UnitCostDataGridViewTextBoxColumn.HeaderText = "Unit Cost"
        Me.UnitCostDataGridViewTextBoxColumn.Name = "UnitCostDataGridViewTextBoxColumn"
        Me.UnitCostDataGridViewTextBoxColumn.ReadOnly = True
        Me.UnitCostDataGridViewTextBoxColumn.Width = 95
        '
        'ExtendedAmountDataGridViewTextBoxColumn
        '
        Me.ExtendedAmountDataGridViewTextBoxColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.ExtendedAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ExtendedAmountDataGridViewTextBoxColumn.HeaderText = "Extended Amount"
        Me.ExtendedAmountDataGridViewTextBoxColumn.Name = "ExtendedAmountDataGridViewTextBoxColumn"
        Me.ExtendedAmountDataGridViewTextBoxColumn.ReadOnly = True
        Me.ExtendedAmountDataGridViewTextBoxColumn.Width = 95
        '
        'LineStatusDataGridViewTextBoxColumn
        '
        Me.LineStatusDataGridViewTextBoxColumn.DataPropertyName = "LineStatus"
        Me.LineStatusDataGridViewTextBoxColumn.HeaderText = "LineStatus"
        Me.LineStatusDataGridViewTextBoxColumn.Name = "LineStatusDataGridViewTextBoxColumn"
        Me.LineStatusDataGridViewTextBoxColumn.Visible = False
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.Visible = False
        '
        'DebitGLAccountDataGridViewTextBoxColumn
        '
        Me.DebitGLAccountDataGridViewTextBoxColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountDataGridViewTextBoxColumn.HeaderText = "DebitGLAccount"
        Me.DebitGLAccountDataGridViewTextBoxColumn.Name = "DebitGLAccountDataGridViewTextBoxColumn"
        Me.DebitGLAccountDataGridViewTextBoxColumn.Visible = False
        '
        'CreditGLAccountDataGridViewTextBoxColumn
        '
        Me.CreditGLAccountDataGridViewTextBoxColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountDataGridViewTextBoxColumn.HeaderText = "CreditGLAccount"
        Me.CreditGLAccountDataGridViewTextBoxColumn.Name = "CreditGLAccountDataGridViewTextBoxColumn"
        Me.CreditGLAccountDataGridViewTextBoxColumn.Visible = False
        '
        'SelectDropShipLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 378)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.dgvDropShipLines)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.cmdSaveLines)
        Me.Controls.Add(Me.cmdExit)
        Me.Name = "SelectDropShipLines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Drop Ship Lines"
        CType(Me.dgvDropShipLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvDropShipLines As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdSaveLines As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents PurchaseOrderLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderLineTableTableAdapter
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents PurchaseOrderHeaderKeyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForInvoiceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PurchaseOrderLineNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
