<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SOPurchaseCostPopup
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgvLastPurchaseCost = New System.Windows.Forms.DataGridView
        Me.ReceivingLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.ReceivingLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingLineQueryTableAdapter
        Me.VendorCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityReceivedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingHeaderKeyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingLineKeyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalQuantityVouchedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectForInvoiceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOpenDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalAmountOpenDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalAmountVouchedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvLastPurchaseCost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceivingLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvLastPurchaseCost
        '
        Me.dgvLastPurchaseCost.AllowUserToAddRows = False
        Me.dgvLastPurchaseCost.AllowUserToDeleteRows = False
        Me.dgvLastPurchaseCost.AutoGenerateColumns = False
        Me.dgvLastPurchaseCost.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvLastPurchaseCost.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvLastPurchaseCost.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvLastPurchaseCost.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvLastPurchaseCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLastPurchaseCost.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VendorCodeDataGridViewTextBoxColumn, Me.PartNumberDataGridViewTextBoxColumn, Me.QuantityReceivedDataGridViewTextBoxColumn, Me.UnitCostDataGridViewTextBoxColumn, Me.POCostColumn, Me.ReceivingDateDataGridViewTextBoxColumn, Me.ReceivingHeaderKeyDataGridViewTextBoxColumn, Me.ReceivingLineKeyDataGridViewTextBoxColumn, Me.PartDescriptionDataGridViewTextBoxColumn, Me.PONumberColumn, Me.POLineNumberColumn, Me.DivisionIDDataGridViewTextBoxColumn, Me.TotalQuantityVouchedDataGridViewTextBoxColumn, Me.ExtendedAmountDataGridViewTextBoxColumn, Me.LineStatusDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn, Me.SelectForInvoiceDataGridViewTextBoxColumn, Me.DebitGLAccountDataGridViewTextBoxColumn, Me.CreditGLAccountDataGridViewTextBoxColumn, Me.LineCommentDataGridViewTextBoxColumn, Me.QuantityOpenDataGridViewTextBoxColumn, Me.TotalAmountOpenDataGridViewTextBoxColumn, Me.TotalAmountVouchedDataGridViewTextBoxColumn})
        Me.dgvLastPurchaseCost.DataSource = Me.ReceivingLineQueryBindingSource
        Me.dgvLastPurchaseCost.GridColor = System.Drawing.Color.Blue
        Me.dgvLastPurchaseCost.Location = New System.Drawing.Point(3, 12)
        Me.dgvLastPurchaseCost.Name = "dgvLastPurchaseCost"
        Me.dgvLastPurchaseCost.ReadOnly = True
        Me.dgvLastPurchaseCost.Size = New System.Drawing.Size(587, 260)
        Me.dgvLastPurchaseCost.TabIndex = 0
        '
        'ReceivingLineQueryBindingSource
        '
        Me.ReceivingLineQueryBindingSource.DataMember = "ReceivingLineQuery"
        Me.ReceivingLineQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReceivingLineQueryTableAdapter
        '
        Me.ReceivingLineQueryTableAdapter.ClearBeforeFill = True
        '
        'VendorCodeDataGridViewTextBoxColumn
        '
        Me.VendorCodeDataGridViewTextBoxColumn.DataPropertyName = "VendorCode"
        Me.VendorCodeDataGridViewTextBoxColumn.HeaderText = "Vendor"
        Me.VendorCodeDataGridViewTextBoxColumn.Name = "VendorCodeDataGridViewTextBoxColumn"
        Me.VendorCodeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PartNumberDataGridViewTextBoxColumn
        '
        Me.PartNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn.HeaderText = "Part #"
        Me.PartNumberDataGridViewTextBoxColumn.Name = "PartNumberDataGridViewTextBoxColumn"
        Me.PartNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.PartNumberDataGridViewTextBoxColumn.Visible = False
        '
        'QuantityReceivedDataGridViewTextBoxColumn
        '
        Me.QuantityReceivedDataGridViewTextBoxColumn.DataPropertyName = "QuantityReceived"
        Me.QuantityReceivedDataGridViewTextBoxColumn.HeaderText = "Qty"
        Me.QuantityReceivedDataGridViewTextBoxColumn.Name = "QuantityReceivedDataGridViewTextBoxColumn"
        Me.QuantityReceivedDataGridViewTextBoxColumn.ReadOnly = True
        '
        'UnitCostDataGridViewTextBoxColumn
        '
        Me.UnitCostDataGridViewTextBoxColumn.DataPropertyName = "UnitCost"
        Me.UnitCostDataGridViewTextBoxColumn.HeaderText = "Receiver Cost"
        Me.UnitCostDataGridViewTextBoxColumn.Name = "UnitCostDataGridViewTextBoxColumn"
        Me.UnitCostDataGridViewTextBoxColumn.ReadOnly = True
        '
        'POCostColumn
        '
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle4.Format = "N5"
        DataGridViewCellStyle4.NullValue = "0"
        Me.POCostColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.POCostColumn.HeaderText = "PO Cost"
        Me.POCostColumn.Name = "POCostColumn"
        Me.POCostColumn.ReadOnly = True
        '
        'ReceivingDateDataGridViewTextBoxColumn
        '
        Me.ReceivingDateDataGridViewTextBoxColumn.DataPropertyName = "ReceivingDate"
        Me.ReceivingDateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.ReceivingDateDataGridViewTextBoxColumn.Name = "ReceivingDateDataGridViewTextBoxColumn"
        Me.ReceivingDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ReceivingHeaderKeyDataGridViewTextBoxColumn
        '
        Me.ReceivingHeaderKeyDataGridViewTextBoxColumn.DataPropertyName = "ReceivingHeaderKey"
        Me.ReceivingHeaderKeyDataGridViewTextBoxColumn.HeaderText = "ReceivingHeaderKey"
        Me.ReceivingHeaderKeyDataGridViewTextBoxColumn.Name = "ReceivingHeaderKeyDataGridViewTextBoxColumn"
        Me.ReceivingHeaderKeyDataGridViewTextBoxColumn.ReadOnly = True
        Me.ReceivingHeaderKeyDataGridViewTextBoxColumn.Visible = False
        '
        'ReceivingLineKeyDataGridViewTextBoxColumn
        '
        Me.ReceivingLineKeyDataGridViewTextBoxColumn.DataPropertyName = "ReceivingLineKey"
        Me.ReceivingLineKeyDataGridViewTextBoxColumn.HeaderText = "ReceivingLineKey"
        Me.ReceivingLineKeyDataGridViewTextBoxColumn.Name = "ReceivingLineKeyDataGridViewTextBoxColumn"
        Me.ReceivingLineKeyDataGridViewTextBoxColumn.ReadOnly = True
        Me.ReceivingLineKeyDataGridViewTextBoxColumn.Visible = False
        '
        'PartDescriptionDataGridViewTextBoxColumn
        '
        Me.PartDescriptionDataGridViewTextBoxColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionDataGridViewTextBoxColumn.HeaderText = "PartDescription"
        Me.PartDescriptionDataGridViewTextBoxColumn.Name = "PartDescriptionDataGridViewTextBoxColumn"
        Me.PartDescriptionDataGridViewTextBoxColumn.ReadOnly = True
        Me.PartDescriptionDataGridViewTextBoxColumn.Visible = False
        '
        'PONumberColumn
        '
        Me.PONumberColumn.DataPropertyName = "PONumber"
        Me.PONumberColumn.HeaderText = "PONumber"
        Me.PONumberColumn.Name = "PONumberColumn"
        Me.PONumberColumn.ReadOnly = True
        Me.PONumberColumn.Visible = False
        '
        'POLineNumberColumn
        '
        Me.POLineNumberColumn.DataPropertyName = "POLineNumber"
        Me.POLineNumberColumn.HeaderText = "POLineNumber"
        Me.POLineNumberColumn.Name = "POLineNumberColumn"
        Me.POLineNumberColumn.ReadOnly = True
        Me.POLineNumberColumn.Visible = False
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.DivisionIDDataGridViewTextBoxColumn.Visible = False
        '
        'TotalQuantityVouchedDataGridViewTextBoxColumn
        '
        Me.TotalQuantityVouchedDataGridViewTextBoxColumn.DataPropertyName = "TotalQuantityVouched"
        Me.TotalQuantityVouchedDataGridViewTextBoxColumn.HeaderText = "TotalQuantityVouched"
        Me.TotalQuantityVouchedDataGridViewTextBoxColumn.Name = "TotalQuantityVouchedDataGridViewTextBoxColumn"
        Me.TotalQuantityVouchedDataGridViewTextBoxColumn.ReadOnly = True
        Me.TotalQuantityVouchedDataGridViewTextBoxColumn.Visible = False
        '
        'ExtendedAmountDataGridViewTextBoxColumn
        '
        Me.ExtendedAmountDataGridViewTextBoxColumn.DataPropertyName = "ExtendedAmount"
        Me.ExtendedAmountDataGridViewTextBoxColumn.HeaderText = "ExtendedAmount"
        Me.ExtendedAmountDataGridViewTextBoxColumn.Name = "ExtendedAmountDataGridViewTextBoxColumn"
        Me.ExtendedAmountDataGridViewTextBoxColumn.ReadOnly = True
        Me.ExtendedAmountDataGridViewTextBoxColumn.Visible = False
        '
        'LineStatusDataGridViewTextBoxColumn
        '
        Me.LineStatusDataGridViewTextBoxColumn.DataPropertyName = "LineStatus"
        Me.LineStatusDataGridViewTextBoxColumn.HeaderText = "LineStatus"
        Me.LineStatusDataGridViewTextBoxColumn.Name = "LineStatusDataGridViewTextBoxColumn"
        Me.LineStatusDataGridViewTextBoxColumn.ReadOnly = True
        Me.LineStatusDataGridViewTextBoxColumn.Visible = False
        '
        'StatusDataGridViewTextBoxColumn
        '
        Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
        Me.StatusDataGridViewTextBoxColumn.HeaderText = "Status"
        Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
        Me.StatusDataGridViewTextBoxColumn.ReadOnly = True
        Me.StatusDataGridViewTextBoxColumn.Visible = False
        '
        'SelectForInvoiceDataGridViewTextBoxColumn
        '
        Me.SelectForInvoiceDataGridViewTextBoxColumn.DataPropertyName = "SelectForInvoice"
        Me.SelectForInvoiceDataGridViewTextBoxColumn.HeaderText = "SelectForInvoice"
        Me.SelectForInvoiceDataGridViewTextBoxColumn.Name = "SelectForInvoiceDataGridViewTextBoxColumn"
        Me.SelectForInvoiceDataGridViewTextBoxColumn.ReadOnly = True
        Me.SelectForInvoiceDataGridViewTextBoxColumn.Visible = False
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
        'LineCommentDataGridViewTextBoxColumn
        '
        Me.LineCommentDataGridViewTextBoxColumn.DataPropertyName = "LineComment"
        Me.LineCommentDataGridViewTextBoxColumn.HeaderText = "LineComment"
        Me.LineCommentDataGridViewTextBoxColumn.Name = "LineCommentDataGridViewTextBoxColumn"
        Me.LineCommentDataGridViewTextBoxColumn.ReadOnly = True
        Me.LineCommentDataGridViewTextBoxColumn.Visible = False
        '
        'QuantityOpenDataGridViewTextBoxColumn
        '
        Me.QuantityOpenDataGridViewTextBoxColumn.DataPropertyName = "QuantityOpen"
        Me.QuantityOpenDataGridViewTextBoxColumn.HeaderText = "QuantityOpen"
        Me.QuantityOpenDataGridViewTextBoxColumn.Name = "QuantityOpenDataGridViewTextBoxColumn"
        Me.QuantityOpenDataGridViewTextBoxColumn.ReadOnly = True
        Me.QuantityOpenDataGridViewTextBoxColumn.Visible = False
        '
        'TotalAmountOpenDataGridViewTextBoxColumn
        '
        Me.TotalAmountOpenDataGridViewTextBoxColumn.DataPropertyName = "TotalAmountOpen"
        Me.TotalAmountOpenDataGridViewTextBoxColumn.HeaderText = "TotalAmountOpen"
        Me.TotalAmountOpenDataGridViewTextBoxColumn.Name = "TotalAmountOpenDataGridViewTextBoxColumn"
        Me.TotalAmountOpenDataGridViewTextBoxColumn.ReadOnly = True
        Me.TotalAmountOpenDataGridViewTextBoxColumn.Visible = False
        '
        'TotalAmountVouchedDataGridViewTextBoxColumn
        '
        Me.TotalAmountVouchedDataGridViewTextBoxColumn.DataPropertyName = "TotalAmountVouched"
        Me.TotalAmountVouchedDataGridViewTextBoxColumn.HeaderText = "TotalAmountVouched"
        Me.TotalAmountVouchedDataGridViewTextBoxColumn.Name = "TotalAmountVouchedDataGridViewTextBoxColumn"
        Me.TotalAmountVouchedDataGridViewTextBoxColumn.ReadOnly = True
        Me.TotalAmountVouchedDataGridViewTextBoxColumn.Visible = False
        '
        'SOPurchaseCostPopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 273)
        Me.Controls.Add(Me.dgvLastPurchaseCost)
        Me.Name = "SOPurchaseCostPopup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Last Purchase Cost"
        CType(Me.dgvLastPurchaseCost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceivingLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvLastPurchaseCost As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ReceivingLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceivingLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingLineQueryTableAdapter
    Friend WithEvents VendorCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityReceivedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingHeaderKeyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingLineKeyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalQuantityVouchedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForInvoiceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOpenDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalAmountOpenDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalAmountVouchedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
