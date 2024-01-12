<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectPOLines
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdSaveLines = New System.Windows.Forms.Button
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.dgvLineQuery = New System.Windows.Forms.DataGridView
        Me.ReceivingLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.ReceivingLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingLineQueryTableAdapter
        Me.SelectForProcessing = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ReceivingDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityReceivedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalQuantityVouchedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityReturnedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalAmountOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineComment = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalAmountVouchedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectForInvoiceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvLineQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceivingLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(709, 521)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 1
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdSaveLines
        '
        Me.cmdSaveLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSaveLines.Location = New System.Drawing.Point(632, 521)
        Me.cmdSaveLines.Name = "cmdSaveLines"
        Me.cmdSaveLines.Size = New System.Drawing.Size(71, 40)
        Me.cmdSaveLines.TabIndex = 2
        Me.cmdSaveLines.Text = "Save"
        Me.cmdSaveLines.UseVisualStyleBackColor = True
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectAll.Location = New System.Drawing.Point(12, 521)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectAll.TabIndex = 3
        Me.cmdSelectAll.Text = "Check All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(89, 521)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 5
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'dgvLineQuery
        '
        Me.dgvLineQuery.AllowUserToAddRows = False
        Me.dgvLineQuery.AllowUserToDeleteRows = False
        Me.dgvLineQuery.AllowUserToOrderColumns = True
        Me.dgvLineQuery.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLineQuery.AutoGenerateColumns = False
        Me.dgvLineQuery.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvLineQuery.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvLineQuery.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvLineQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLineQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectForProcessing, Me.ReceivingDateColumn, Me.ReceivingLineKeyColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityReceivedColumn, Me.TotalQuantityVouchedColumn, Me.QuantityOpenColumn, Me.QuantityReturnedColumn, Me.UnitCostColumn, Me.TotalAmountOpenColumn, Me.LineComment, Me.ReceivingHeaderKeyColumn, Me.ExtendedAmountColumn, Me.TotalAmountVouchedColumn, Me.VendorCodeColumn, Me.StatusColumn, Me.SelectForInvoiceColumn, Me.DebitGLAccountColumn, Me.CreditGLAccountColumn, Me.DivisionIDColumn, Me.LineStatusColumn, Me.PONumberColumn})
        Me.dgvLineQuery.DataSource = Me.ReceivingLineQueryBindingSource
        Me.dgvLineQuery.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvLineQuery.Location = New System.Drawing.Point(2, 0)
        Me.dgvLineQuery.Name = "dgvLineQuery"
        Me.dgvLineQuery.Size = New System.Drawing.Size(793, 506)
        Me.dgvLineQuery.TabIndex = 6
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
        'SelectForProcessing
        '
        Me.SelectForProcessing.FalseValue = "UNSELECTED"
        Me.SelectForProcessing.HeaderText = "Select"
        Me.SelectForProcessing.Name = "SelectForProcessing"
        Me.SelectForProcessing.TrueValue = "SELECTED"
        Me.SelectForProcessing.Width = 45
        '
        'ReceivingDateColumn
        '
        Me.ReceivingDateColumn.DataPropertyName = "ReceivingDate"
        Me.ReceivingDateColumn.HeaderText = "Rcd Date"
        Me.ReceivingDateColumn.Name = "ReceivingDateColumn"
        Me.ReceivingDateColumn.Width = 65
        '
        'ReceivingLineKeyColumn
        '
        Me.ReceivingLineKeyColumn.DataPropertyName = "ReceivingLineKey"
        Me.ReceivingLineKeyColumn.HeaderText = "Line #"
        Me.ReceivingLineKeyColumn.Name = "ReceivingLineKeyColumn"
        Me.ReceivingLineKeyColumn.Width = 40
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.Width = 120
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.Width = 150
        '
        'QuantityReceivedColumn
        '
        Me.QuantityReceivedColumn.DataPropertyName = "QuantityReceived"
        DataGridViewCellStyle1.NullValue = "0"
        Me.QuantityReceivedColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.QuantityReceivedColumn.HeaderText = "Qty Rcd"
        Me.QuantityReceivedColumn.Name = "QuantityReceivedColumn"
        Me.QuantityReceivedColumn.Visible = False
        Me.QuantityReceivedColumn.Width = 80
        '
        'TotalQuantityVouchedColumn
        '
        Me.TotalQuantityVouchedColumn.DataPropertyName = "TotalQuantityVouched"
        DataGridViewCellStyle2.NullValue = "0"
        Me.TotalQuantityVouchedColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.TotalQuantityVouchedColumn.HeaderText = "Qty Vouched"
        Me.TotalQuantityVouchedColumn.Name = "TotalQuantityVouchedColumn"
        Me.TotalQuantityVouchedColumn.ReadOnly = True
        Me.TotalQuantityVouchedColumn.Visible = False
        Me.TotalQuantityVouchedColumn.Width = 80
        '
        'QuantityOpenColumn
        '
        Me.QuantityOpenColumn.DataPropertyName = "QuantityOpen"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle3.NullValue = "0"
        Me.QuantityOpenColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.QuantityOpenColumn.HeaderText = "Qty Open"
        Me.QuantityOpenColumn.Name = "QuantityOpenColumn"
        Me.QuantityOpenColumn.ReadOnly = True
        Me.QuantityOpenColumn.Width = 80
        '
        'QuantityReturnedColumn
        '
        Me.QuantityReturnedColumn.DataPropertyName = "QuantityReturned"
        Me.QuantityReturnedColumn.HeaderText = "Qty Returned"
        Me.QuantityReturnedColumn.Name = "QuantityReturnedColumn"
        Me.QuantityReturnedColumn.ReadOnly = True
        Me.QuantityReturnedColumn.Width = 80
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle4.Format = "N5"
        DataGridViewCellStyle4.NullValue = "0"
        Me.UnitCostColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.Width = 80
        '
        'TotalAmountOpenColumn
        '
        Me.TotalAmountOpenColumn.DataPropertyName = "TotalAmountOpen"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.TotalAmountOpenColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.TotalAmountOpenColumn.HeaderText = "Extended Amount"
        Me.TotalAmountOpenColumn.Name = "TotalAmountOpenColumn"
        Me.TotalAmountOpenColumn.ReadOnly = True
        Me.TotalAmountOpenColumn.Width = 80
        '
        'LineComment
        '
        Me.LineComment.DataPropertyName = "LineComment"
        Me.LineComment.HeaderText = "Line Comment"
        Me.LineComment.Name = "LineComment"
        '
        'ReceivingHeaderKeyColumn
        '
        Me.ReceivingHeaderKeyColumn.DataPropertyName = "ReceivingHeaderKey"
        Me.ReceivingHeaderKeyColumn.HeaderText = "Receiver #"
        Me.ReceivingHeaderKeyColumn.Name = "ReceivingHeaderKeyColumn"
        Me.ReceivingHeaderKeyColumn.Width = 80
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.ExtendedAmountColumn.HeaderText = "Extended Amount 2"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.Visible = False
        Me.ExtendedAmountColumn.Width = 80
        '
        'TotalAmountVouchedColumn
        '
        Me.TotalAmountVouchedColumn.DataPropertyName = "TotalAmountVouched"
        Me.TotalAmountVouchedColumn.HeaderText = "TotalAmountVouched"
        Me.TotalAmountVouchedColumn.Name = "TotalAmountVouchedColumn"
        Me.TotalAmountVouchedColumn.ReadOnly = True
        Me.TotalAmountVouchedColumn.Visible = False
        '
        'VendorCodeColumn
        '
        Me.VendorCodeColumn.DataPropertyName = "VendorCode"
        Me.VendorCodeColumn.HeaderText = "VendorCode"
        Me.VendorCodeColumn.Name = "VendorCodeColumn"
        Me.VendorCodeColumn.Visible = False
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.Visible = False
        '
        'SelectForInvoiceColumn
        '
        Me.SelectForInvoiceColumn.DataPropertyName = "SelectForInvoice"
        Me.SelectForInvoiceColumn.HeaderText = "SelectForInvoice"
        Me.SelectForInvoiceColumn.Name = "SelectForInvoiceColumn"
        Me.SelectForInvoiceColumn.Visible = False
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "DebitGLAccount"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        Me.DebitGLAccountColumn.Visible = False
        '
        'CreditGLAccountColumn
        '
        Me.CreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumn.HeaderText = "CreditGLAccount"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
        Me.CreditGLAccountColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "LineStatus"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.Visible = False
        '
        'PONumberColumn
        '
        Me.PONumberColumn.DataPropertyName = "PONumber"
        Me.PONumberColumn.HeaderText = "PONumber"
        Me.PONumberColumn.Name = "PONumberColumn"
        Me.PONumberColumn.Visible = False
        '
        'SelectPOLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.dgvLineQuery)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.cmdSaveLines)
        Me.Controls.Add(Me.cmdExit)
        Me.Name = "SelectPOLines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Select PO Lines"
        CType(Me.dgvLineQuery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceivingLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdSaveLines As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents dgvLineQuery As System.Windows.Forms.DataGridView
    Friend WithEvents ReceivingLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceivingLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingLineQueryTableAdapter
    Friend WithEvents SelectForProcessing As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ReceivingDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityReceivedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalQuantityVouchedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityReturnedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalAmountOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineComment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalAmountVouchedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForInvoiceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
