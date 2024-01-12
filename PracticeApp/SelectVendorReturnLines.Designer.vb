<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectVendorReturnLines
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
        Me.cmdSaveLines = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.dgvVendorReturnLines = New System.Windows.Forms.DataGridView
        Me.VendorReturnPurchaseClearingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.VendorReturnPurchaseClearingTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorReturnPurchaseClearingTableAdapter
        Me.SelectForInvoicing = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ReturnNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiverNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiverLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityVouchedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountVouchedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvVendorReturnLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorReturnPurchaseClearingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdSaveLines
        '
        Me.cmdSaveLines.Location = New System.Drawing.Point(502, 326)
        Me.cmdSaveLines.Name = "cmdSaveLines"
        Me.cmdSaveLines.Size = New System.Drawing.Size(71, 40)
        Me.cmdSaveLines.TabIndex = 21
        Me.cmdSaveLines.Text = "Process For Receipt"
        Me.cmdSaveLines.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(579, 326)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 20
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Location = New System.Drawing.Point(94, 326)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 19
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Location = New System.Drawing.Point(17, 326)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectAll.TabIndex = 18
        Me.cmdSelectAll.Text = "Check All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'dgvVendorReturnLines
        '
        Me.dgvVendorReturnLines.AllowUserToAddRows = False
        Me.dgvVendorReturnLines.AllowUserToDeleteRows = False
        Me.dgvVendorReturnLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvVendorReturnLines.AutoGenerateColumns = False
        Me.dgvVendorReturnLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvVendorReturnLines.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvVendorReturnLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVendorReturnLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectForInvoicing, Me.ReturnNumberColumn, Me.ReturnLineNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityOpenColumn, Me.CostColumn, Me.ExtendedAmountOpenColumn, Me.ReturnDateColumn, Me.LineCommentColumn, Me.DebitGLAccountColumn, Me.CreditGLAccountColumn, Me.LineStatusColumn, Me.PONumberColumn, Me.VendorIDColumn, Me.ReturnStatusColumn, Me.ReceiverNumberColumn, Me.ReceiverLineNumberColumn, Me.QuantityVouchedColumn, Me.ExtendedAmountVouchedColumn, Me.QuantityColumn, Me.ExtendedAmountColumn, Me.DivisionIDColumn})
        Me.dgvVendorReturnLines.DataSource = Me.VendorReturnPurchaseClearingBindingSource
        Me.dgvVendorReturnLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvVendorReturnLines.Location = New System.Drawing.Point(17, 12)
        Me.dgvVendorReturnLines.Name = "dgvVendorReturnLines"
        Me.dgvVendorReturnLines.Size = New System.Drawing.Size(633, 295)
        Me.dgvVendorReturnLines.TabIndex = 22
        '
        'VendorReturnPurchaseClearingBindingSource
        '
        Me.VendorReturnPurchaseClearingBindingSource.DataMember = "VendorReturnPurchaseClearing"
        Me.VendorReturnPurchaseClearingBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'VendorReturnPurchaseClearingTableAdapter
        '
        Me.VendorReturnPurchaseClearingTableAdapter.ClearBeforeFill = True
        '
        'SelectForInvoicing
        '
        Me.SelectForInvoicing.FalseValue = "UNSELECTED"
        Me.SelectForInvoicing.HeaderText = "Select"
        Me.SelectForInvoicing.Name = "SelectForInvoicing"
        Me.SelectForInvoicing.TrueValue = "SELECTED"
        Me.SelectForInvoicing.Width = 65
        '
        'ReturnNumberColumn
        '
        Me.ReturnNumberColumn.DataPropertyName = "ReturnNumber"
        Me.ReturnNumberColumn.HeaderText = "ReturnNumber"
        Me.ReturnNumberColumn.Name = "ReturnNumberColumn"
        Me.ReturnNumberColumn.Visible = False
        '
        'ReturnLineNumberColumn
        '
        Me.ReturnLineNumberColumn.DataPropertyName = "ReturnLineNumber"
        Me.ReturnLineNumberColumn.HeaderText = "Line #"
        Me.ReturnLineNumberColumn.Name = "ReturnLineNumberColumn"
        Me.ReturnLineNumberColumn.ReadOnly = True
        Me.ReturnLineNumberColumn.Width = 65
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.ReadOnly = True
        '
        'QuantityOpenColumn
        '
        Me.QuantityOpenColumn.DataPropertyName = "QuantityOpen"
        Me.QuantityOpenColumn.HeaderText = "Qty. Open"
        Me.QuantityOpenColumn.Name = "QuantityOpenColumn"
        Me.QuantityOpenColumn.ReadOnly = True
        Me.QuantityOpenColumn.Width = 85
        '
        'CostColumn
        '
        Me.CostColumn.DataPropertyName = "Cost"
        Me.CostColumn.HeaderText = "Cost"
        Me.CostColumn.Name = "CostColumn"
        Me.CostColumn.Width = 85
        '
        'ExtendedAmountOpenColumn
        '
        Me.ExtendedAmountOpenColumn.DataPropertyName = "ExtendedAmountOpen"
        Me.ExtendedAmountOpenColumn.HeaderText = "Ext. Amt. Open"
        Me.ExtendedAmountOpenColumn.Name = "ExtendedAmountOpenColumn"
        Me.ExtendedAmountOpenColumn.ReadOnly = True
        Me.ExtendedAmountOpenColumn.Width = 85
        '
        'ReturnDateColumn
        '
        Me.ReturnDateColumn.DataPropertyName = "ReturnDate"
        Me.ReturnDateColumn.HeaderText = "Return Date"
        Me.ReturnDateColumn.Name = "ReturnDateColumn"
        Me.ReturnDateColumn.ReadOnly = True
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "Debit Account"
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
        'VendorIDColumn
        '
        Me.VendorIDColumn.DataPropertyName = "VendorID"
        Me.VendorIDColumn.HeaderText = "VendorID"
        Me.VendorIDColumn.Name = "VendorIDColumn"
        Me.VendorIDColumn.Visible = False
        '
        'ReturnStatusColumn
        '
        Me.ReturnStatusColumn.DataPropertyName = "ReturnStatus"
        Me.ReturnStatusColumn.HeaderText = "ReturnStatus"
        Me.ReturnStatusColumn.Name = "ReturnStatusColumn"
        Me.ReturnStatusColumn.Visible = False
        '
        'ReceiverNumberColumn
        '
        Me.ReceiverNumberColumn.DataPropertyName = "ReceiverNumber"
        Me.ReceiverNumberColumn.HeaderText = "ReceiverNumber"
        Me.ReceiverNumberColumn.Name = "ReceiverNumberColumn"
        Me.ReceiverNumberColumn.Visible = False
        '
        'ReceiverLineNumberColumn
        '
        Me.ReceiverLineNumberColumn.DataPropertyName = "ReceiverLineNumber"
        Me.ReceiverLineNumberColumn.HeaderText = "ReceiverLineNumber"
        Me.ReceiverLineNumberColumn.Name = "ReceiverLineNumberColumn"
        Me.ReceiverLineNumberColumn.Visible = False
        '
        'QuantityVouchedColumn
        '
        Me.QuantityVouchedColumn.DataPropertyName = "QuantityVouched"
        Me.QuantityVouchedColumn.HeaderText = "QuantityVouched"
        Me.QuantityVouchedColumn.Name = "QuantityVouchedColumn"
        Me.QuantityVouchedColumn.ReadOnly = True
        Me.QuantityVouchedColumn.Visible = False
        '
        'ExtendedAmountVouchedColumn
        '
        Me.ExtendedAmountVouchedColumn.DataPropertyName = "ExtendedAmountVouched"
        Me.ExtendedAmountVouchedColumn.HeaderText = "ExtendedAmountVouched"
        Me.ExtendedAmountVouchedColumn.Name = "ExtendedAmountVouchedColumn"
        Me.ExtendedAmountVouchedColumn.ReadOnly = True
        Me.ExtendedAmountVouchedColumn.Visible = False
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.Visible = False
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        Me.ExtendedAmountColumn.HeaderText = "ExtendedAmount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'SelectVendorReturnLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 378)
        Me.Controls.Add(Me.dgvVendorReturnLines)
        Me.Controls.Add(Me.cmdSaveLines)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Name = "SelectVendorReturnLines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Vendor Return Lines"
        CType(Me.dgvVendorReturnLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorReturnPurchaseClearingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdSaveLines As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents dgvVendorReturnLines As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents VendorReturnPurchaseClearingBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorReturnPurchaseClearingTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorReturnPurchaseClearingTableAdapter
    Friend WithEvents SelectForInvoicing As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ReturnNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiverNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiverLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityVouchedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountVouchedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
