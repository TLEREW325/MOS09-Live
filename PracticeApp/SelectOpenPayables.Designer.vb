<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectOpenPayables
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
        Me.dgvOpenPayables = New System.Windows.Forms.DataGridView
        Me.VoucherNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiptDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceFreightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceSalesTaxDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTermsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DueDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherSourceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DeleteReferenceNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiptOfInvoiceBatchLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.ReceiptOfInvoiceBatchLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
        Me.cmdSaveLines = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cboVoucherNumber = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.dgvOpenPayables, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvOpenPayables
        '
        Me.dgvOpenPayables.AllowUserToAddRows = False
        Me.dgvOpenPayables.AutoGenerateColumns = False
        Me.dgvOpenPayables.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvOpenPayables.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvOpenPayables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOpenPayables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VoucherNumberDataGridViewTextBoxColumn, Me.BatchNumberDataGridViewTextBoxColumn, Me.PONumberDataGridViewTextBoxColumn, Me.InvoiceNumberDataGridViewTextBoxColumn, Me.InvoiceDateDataGridViewTextBoxColumn, Me.ReceiptDateDataGridViewTextBoxColumn, Me.VendorIDDataGridViewTextBoxColumn, Me.ProductTotalDataGridViewTextBoxColumn, Me.InvoiceFreightDataGridViewTextBoxColumn, Me.InvoiceSalesTaxDataGridViewTextBoxColumn, Me.InvoiceTotalDataGridViewTextBoxColumn, Me.PaymentTermsDataGridViewTextBoxColumn, Me.DiscountDateDataGridViewTextBoxColumn, Me.CommentDataGridViewTextBoxColumn, Me.DueDateDataGridViewTextBoxColumn, Me.DiscountAmountDataGridViewTextBoxColumn, Me.VoucherStatusDataGridViewTextBoxColumn, Me.VoucherSourceDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn, Me.DeleteReferenceNumberDataGridViewTextBoxColumn})
        Me.dgvOpenPayables.DataSource = Me.ReceiptOfInvoiceBatchLineBindingSource
        Me.dgvOpenPayables.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvOpenPayables.Location = New System.Drawing.Point(6, 5)
        Me.dgvOpenPayables.Name = "dgvOpenPayables"
        Me.dgvOpenPayables.Size = New System.Drawing.Size(648, 312)
        Me.dgvOpenPayables.TabIndex = 0
        '
        'VoucherNumberDataGridViewTextBoxColumn
        '
        Me.VoucherNumberDataGridViewTextBoxColumn.DataPropertyName = "VoucherNumber"
        Me.VoucherNumberDataGridViewTextBoxColumn.HeaderText = "Voucher #"
        Me.VoucherNumberDataGridViewTextBoxColumn.Name = "VoucherNumberDataGridViewTextBoxColumn"
        '
        'BatchNumberDataGridViewTextBoxColumn
        '
        Me.BatchNumberDataGridViewTextBoxColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberDataGridViewTextBoxColumn.HeaderText = "BatchNumber"
        Me.BatchNumberDataGridViewTextBoxColumn.Name = "BatchNumberDataGridViewTextBoxColumn"
        Me.BatchNumberDataGridViewTextBoxColumn.Visible = False
        '
        'PONumberDataGridViewTextBoxColumn
        '
        Me.PONumberDataGridViewTextBoxColumn.DataPropertyName = "PONumber"
        Me.PONumberDataGridViewTextBoxColumn.HeaderText = "PO #"
        Me.PONumberDataGridViewTextBoxColumn.Name = "PONumberDataGridViewTextBoxColumn"
        '
        'InvoiceNumberDataGridViewTextBoxColumn
        '
        Me.InvoiceNumberDataGridViewTextBoxColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberDataGridViewTextBoxColumn.HeaderText = "Invoice #"
        Me.InvoiceNumberDataGridViewTextBoxColumn.Name = "InvoiceNumberDataGridViewTextBoxColumn"
        '
        'InvoiceDateDataGridViewTextBoxColumn
        '
        Me.InvoiceDateDataGridViewTextBoxColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateDataGridViewTextBoxColumn.HeaderText = "Invoice Date"
        Me.InvoiceDateDataGridViewTextBoxColumn.Name = "InvoiceDateDataGridViewTextBoxColumn"
        '
        'ReceiptDateDataGridViewTextBoxColumn
        '
        Me.ReceiptDateDataGridViewTextBoxColumn.DataPropertyName = "ReceiptDate"
        Me.ReceiptDateDataGridViewTextBoxColumn.HeaderText = "ReceiptDate"
        Me.ReceiptDateDataGridViewTextBoxColumn.Name = "ReceiptDateDataGridViewTextBoxColumn"
        Me.ReceiptDateDataGridViewTextBoxColumn.Visible = False
        '
        'VendorIDDataGridViewTextBoxColumn
        '
        Me.VendorIDDataGridViewTextBoxColumn.DataPropertyName = "VendorID"
        Me.VendorIDDataGridViewTextBoxColumn.HeaderText = "Vendor ID"
        Me.VendorIDDataGridViewTextBoxColumn.Name = "VendorIDDataGridViewTextBoxColumn"
        '
        'ProductTotalDataGridViewTextBoxColumn
        '
        Me.ProductTotalDataGridViewTextBoxColumn.DataPropertyName = "ProductTotal"
        Me.ProductTotalDataGridViewTextBoxColumn.HeaderText = "ProductTotal"
        Me.ProductTotalDataGridViewTextBoxColumn.Name = "ProductTotalDataGridViewTextBoxColumn"
        Me.ProductTotalDataGridViewTextBoxColumn.Visible = False
        '
        'InvoiceFreightDataGridViewTextBoxColumn
        '
        Me.InvoiceFreightDataGridViewTextBoxColumn.DataPropertyName = "InvoiceFreight"
        Me.InvoiceFreightDataGridViewTextBoxColumn.HeaderText = "InvoiceFreight"
        Me.InvoiceFreightDataGridViewTextBoxColumn.Name = "InvoiceFreightDataGridViewTextBoxColumn"
        Me.InvoiceFreightDataGridViewTextBoxColumn.Visible = False
        '
        'InvoiceSalesTaxDataGridViewTextBoxColumn
        '
        Me.InvoiceSalesTaxDataGridViewTextBoxColumn.DataPropertyName = "InvoiceSalesTax"
        Me.InvoiceSalesTaxDataGridViewTextBoxColumn.HeaderText = "InvoiceSalesTax"
        Me.InvoiceSalesTaxDataGridViewTextBoxColumn.Name = "InvoiceSalesTaxDataGridViewTextBoxColumn"
        Me.InvoiceSalesTaxDataGridViewTextBoxColumn.Visible = False
        '
        'InvoiceTotalDataGridViewTextBoxColumn
        '
        Me.InvoiceTotalDataGridViewTextBoxColumn.DataPropertyName = "InvoiceTotal"
        Me.InvoiceTotalDataGridViewTextBoxColumn.HeaderText = "Invoice Total"
        Me.InvoiceTotalDataGridViewTextBoxColumn.Name = "InvoiceTotalDataGridViewTextBoxColumn"
        '
        'PaymentTermsDataGridViewTextBoxColumn
        '
        Me.PaymentTermsDataGridViewTextBoxColumn.DataPropertyName = "PaymentTerms"
        Me.PaymentTermsDataGridViewTextBoxColumn.HeaderText = "PaymentTerms"
        Me.PaymentTermsDataGridViewTextBoxColumn.Name = "PaymentTermsDataGridViewTextBoxColumn"
        Me.PaymentTermsDataGridViewTextBoxColumn.Visible = False
        '
        'DiscountDateDataGridViewTextBoxColumn
        '
        Me.DiscountDateDataGridViewTextBoxColumn.DataPropertyName = "DiscountDate"
        Me.DiscountDateDataGridViewTextBoxColumn.HeaderText = "DiscountDate"
        Me.DiscountDateDataGridViewTextBoxColumn.Name = "DiscountDateDataGridViewTextBoxColumn"
        Me.DiscountDateDataGridViewTextBoxColumn.Visible = False
        '
        'CommentDataGridViewTextBoxColumn
        '
        Me.CommentDataGridViewTextBoxColumn.DataPropertyName = "Comment"
        Me.CommentDataGridViewTextBoxColumn.HeaderText = "Comment"
        Me.CommentDataGridViewTextBoxColumn.Name = "CommentDataGridViewTextBoxColumn"
        Me.CommentDataGridViewTextBoxColumn.Visible = False
        '
        'DueDateDataGridViewTextBoxColumn
        '
        Me.DueDateDataGridViewTextBoxColumn.DataPropertyName = "DueDate"
        Me.DueDateDataGridViewTextBoxColumn.HeaderText = "DueDate"
        Me.DueDateDataGridViewTextBoxColumn.Name = "DueDateDataGridViewTextBoxColumn"
        Me.DueDateDataGridViewTextBoxColumn.Visible = False
        '
        'DiscountAmountDataGridViewTextBoxColumn
        '
        Me.DiscountAmountDataGridViewTextBoxColumn.DataPropertyName = "DiscountAmount"
        Me.DiscountAmountDataGridViewTextBoxColumn.HeaderText = "DiscountAmount"
        Me.DiscountAmountDataGridViewTextBoxColumn.Name = "DiscountAmountDataGridViewTextBoxColumn"
        Me.DiscountAmountDataGridViewTextBoxColumn.Visible = False
        '
        'VoucherStatusDataGridViewTextBoxColumn
        '
        Me.VoucherStatusDataGridViewTextBoxColumn.DataPropertyName = "VoucherStatus"
        Me.VoucherStatusDataGridViewTextBoxColumn.HeaderText = "VoucherStatus"
        Me.VoucherStatusDataGridViewTextBoxColumn.Name = "VoucherStatusDataGridViewTextBoxColumn"
        Me.VoucherStatusDataGridViewTextBoxColumn.Visible = False
        '
        'VoucherSourceDataGridViewTextBoxColumn
        '
        Me.VoucherSourceDataGridViewTextBoxColumn.DataPropertyName = "VoucherSource"
        Me.VoucherSourceDataGridViewTextBoxColumn.HeaderText = "VoucherSource"
        Me.VoucherSourceDataGridViewTextBoxColumn.Name = "VoucherSourceDataGridViewTextBoxColumn"
        Me.VoucherSourceDataGridViewTextBoxColumn.Visible = False
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.Visible = False
        '
        'DeleteReferenceNumberDataGridViewTextBoxColumn
        '
        Me.DeleteReferenceNumberDataGridViewTextBoxColumn.DataPropertyName = "DeleteReferenceNumber"
        Me.DeleteReferenceNumberDataGridViewTextBoxColumn.HeaderText = "DeleteReferenceNumber"
        Me.DeleteReferenceNumberDataGridViewTextBoxColumn.Name = "DeleteReferenceNumberDataGridViewTextBoxColumn"
        Me.DeleteReferenceNumberDataGridViewTextBoxColumn.Visible = False
        '
        'ReceiptOfInvoiceBatchLineBindingSource
        '
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataMember = "ReceiptOfInvoiceBatchLine"
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReceiptOfInvoiceBatchLineTableAdapter
        '
        Me.ReceiptOfInvoiceBatchLineTableAdapter.ClearBeforeFill = True
        '
        'cmdSaveLines
        '
        Me.cmdSaveLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSaveLines.Location = New System.Drawing.Point(497, 326)
        Me.cmdSaveLines.Name = "cmdSaveLines"
        Me.cmdSaveLines.Size = New System.Drawing.Size(71, 40)
        Me.cmdSaveLines.TabIndex = 8
        Me.cmdSaveLines.Text = "Save"
        Me.cmdSaveLines.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(574, 326)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 7
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cboVoucherNumber
        '
        Me.cboVoucherNumber.FormattingEnabled = True
        Me.cboVoucherNumber.Location = New System.Drawing.Point(110, 337)
        Me.cboVoucherNumber.Name = "cboVoucherNumber"
        Me.cboVoucherNumber.Size = New System.Drawing.Size(183, 21)
        Me.cboVoucherNumber.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 337)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 23)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Voucher Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SelectOpenPayables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(657, 378)
        Me.Controls.Add(Me.cboVoucherNumber)
        Me.Controls.Add(Me.cmdSaveLines)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvOpenPayables)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SelectOpenPayables"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Open Payables"
        CType(Me.dgvOpenPayables, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvOpenPayables As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ReceiptOfInvoiceBatchLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceBatchLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
    Friend WithEvents VoucherNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiptDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceFreightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceSalesTaxDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTermsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DueDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherSourceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeleteReferenceNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdSaveLines As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cboVoucherNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
