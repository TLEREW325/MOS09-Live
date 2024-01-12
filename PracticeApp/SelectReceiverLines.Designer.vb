<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectReceiverLines
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgvReceiverLines = New System.Windows.Forms.DataGridView
        Me.SelectForReceipt = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.PurchaseOrderLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrderQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POQuantityReceivedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POQuantityOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PODateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PODropShipCustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderQuantityStatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.cmdSaveLines = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.PurchaseOrderQuantityStatusTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderQuantityStatusTableAdapter
        CType(Me.dgvReceiverLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderQuantityStatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvReceiverLines
        '
        Me.dgvReceiverLines.AllowUserToAddRows = False
        Me.dgvReceiverLines.AllowUserToDeleteRows = False
        Me.dgvReceiverLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReceiverLines.AutoGenerateColumns = False
        Me.dgvReceiverLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvReceiverLines.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvReceiverLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReceiverLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectForReceipt, Me.PurchaseOrderLineNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.LineCommentColumn, Me.OrderQuantityColumn, Me.POQuantityReceivedColumn, Me.POQuantityOpenColumn, Me.UnitCostColumn, Me.ExtendedAmountColumn, Me.ReceivedAmountColumn, Me.OpenAmountColumn, Me.DivisionIDColumn, Me.PODateColumn, Me.VendorIDColumn, Me.PODropShipCustomerIDColumn, Me.ShipDateColumn, Me.StatusColumn, Me.CreditGLAccountColumn, Me.DebitGLAccountColumn, Me.PurchaseOrderHeaderKeyColumn})
        Me.dgvReceiverLines.DataSource = Me.PurchaseOrderQuantityStatusBindingSource
        Me.dgvReceiverLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvReceiverLines.Location = New System.Drawing.Point(12, 6)
        Me.dgvReceiverLines.Name = "dgvReceiverLines"
        Me.dgvReceiverLines.Size = New System.Drawing.Size(633, 310)
        Me.dgvReceiverLines.TabIndex = 8
        '
        'SelectForReceipt
        '
        Me.SelectForReceipt.FalseValue = "UNSELECTED"
        Me.SelectForReceipt.HeaderText = "Select"
        Me.SelectForReceipt.Name = "SelectForReceipt"
        Me.SelectForReceipt.TrueValue = "SELECTED"
        Me.SelectForReceipt.Width = 65
        '
        'PurchaseOrderLineNumberColumn
        '
        Me.PurchaseOrderLineNumberColumn.DataPropertyName = "PurchaseOrderLineNumber"
        Me.PurchaseOrderLineNumberColumn.HeaderText = "Line #"
        Me.PurchaseOrderLineNumberColumn.Name = "PurchaseOrderLineNumberColumn"
        Me.PurchaseOrderLineNumberColumn.Visible = False
        Me.PurchaseOrderLineNumberColumn.Width = 65
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part Number"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Part Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.ReadOnly = True
        Me.PartDescriptionColumn.Width = 87
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        '
        'OrderQuantityColumn
        '
        Me.OrderQuantityColumn.DataPropertyName = "OrderQuantity"
        DataGridViewCellStyle1.NullValue = "0"
        Me.OrderQuantityColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.OrderQuantityColumn.HeaderText = "Order Quantity"
        Me.OrderQuantityColumn.Name = "OrderQuantityColumn"
        Me.OrderQuantityColumn.ReadOnly = True
        Me.OrderQuantityColumn.Width = 80
        '
        'POQuantityReceivedColumn
        '
        Me.POQuantityReceivedColumn.DataPropertyName = "POQuantityReceived"
        DataGridViewCellStyle2.NullValue = "0"
        Me.POQuantityReceivedColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.POQuantityReceivedColumn.HeaderText = "Quantity Received"
        Me.POQuantityReceivedColumn.Name = "POQuantityReceivedColumn"
        Me.POQuantityReceivedColumn.ReadOnly = True
        Me.POQuantityReceivedColumn.Width = 80
        '
        'POQuantityOpenColumn
        '
        Me.POQuantityOpenColumn.DataPropertyName = "POQuantityOpen"
        DataGridViewCellStyle3.NullValue = "0"
        Me.POQuantityOpenColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.POQuantityOpenColumn.HeaderText = "Quantity Open"
        Me.POQuantityOpenColumn.Name = "POQuantityOpenColumn"
        Me.POQuantityOpenColumn.ReadOnly = True
        Me.POQuantityOpenColumn.Width = 80
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle4.Format = "N4"
        DataGridViewCellStyle4.NullValue = "0"
        Me.UnitCostColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.UnitCostColumn.HeaderText = "UnitCost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.Visible = False
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.ExtendedAmountColumn.HeaderText = "ExtendedAmount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.Visible = False
        '
        'ReceivedAmountColumn
        '
        Me.ReceivedAmountColumn.DataPropertyName = "ReceivedAmount"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.ReceivedAmountColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.ReceivedAmountColumn.HeaderText = "ReceivedAmount"
        Me.ReceivedAmountColumn.Name = "ReceivedAmountColumn"
        Me.ReceivedAmountColumn.ReadOnly = True
        Me.ReceivedAmountColumn.Visible = False
        '
        'OpenAmountColumn
        '
        Me.OpenAmountColumn.DataPropertyName = "OpenAmount"
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.OpenAmountColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.OpenAmountColumn.HeaderText = "OpenAmount"
        Me.OpenAmountColumn.Name = "OpenAmountColumn"
        Me.OpenAmountColumn.ReadOnly = True
        Me.OpenAmountColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'PODateColumn
        '
        Me.PODateColumn.DataPropertyName = "PODate"
        Me.PODateColumn.HeaderText = "PO Date"
        Me.PODateColumn.Name = "PODateColumn"
        Me.PODateColumn.Visible = False
        '
        'VendorIDColumn
        '
        Me.VendorIDColumn.DataPropertyName = "VendorID"
        Me.VendorIDColumn.HeaderText = "Vendor ID"
        Me.VendorIDColumn.Name = "VendorIDColumn"
        Me.VendorIDColumn.Visible = False
        '
        'PODropShipCustomerIDColumn
        '
        Me.PODropShipCustomerIDColumn.DataPropertyName = "PODropShipCustomerID"
        Me.PODropShipCustomerIDColumn.HeaderText = "PODropShipCustomerID"
        Me.PODropShipCustomerIDColumn.Name = "PODropShipCustomerIDColumn"
        Me.PODropShipCustomerIDColumn.Visible = False
        '
        'ShipDateColumn
        '
        Me.ShipDateColumn.DataPropertyName = "ShipDate"
        Me.ShipDateColumn.HeaderText = "ShipDate"
        Me.ShipDateColumn.Name = "ShipDateColumn"
        Me.ShipDateColumn.Visible = False
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.Visible = False
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
        'PurchaseOrderHeaderKeyColumn
        '
        Me.PurchaseOrderHeaderKeyColumn.DataPropertyName = "PurchaseOrderHeaderKey"
        Me.PurchaseOrderHeaderKeyColumn.HeaderText = "PurchaseOrderHeaderKey"
        Me.PurchaseOrderHeaderKeyColumn.Name = "PurchaseOrderHeaderKeyColumn"
        Me.PurchaseOrderHeaderKeyColumn.Visible = False
        '
        'PurchaseOrderQuantityStatusBindingSource
        '
        Me.PurchaseOrderQuantityStatusBindingSource.DataMember = "PurchaseOrderQuantityStatus"
        Me.PurchaseOrderQuantityStatusBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(89, 326)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 13
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectAll.Location = New System.Drawing.Point(12, 326)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectAll.TabIndex = 12
        Me.cmdSelectAll.Text = "Check All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'cmdSaveLines
        '
        Me.cmdSaveLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSaveLines.Location = New System.Drawing.Point(497, 326)
        Me.cmdSaveLines.Name = "cmdSaveLines"
        Me.cmdSaveLines.Size = New System.Drawing.Size(71, 40)
        Me.cmdSaveLines.TabIndex = 11
        Me.cmdSaveLines.Text = "Process For Receiving"
        Me.cmdSaveLines.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(574, 326)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 10
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'PurchaseOrderQuantityStatusTableAdapter
        '
        Me.PurchaseOrderQuantityStatusTableAdapter.ClearBeforeFill = True
        '
        'SelectReceiverLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 378)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.cmdSaveLines)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvReceiverLines)
        Me.Name = "SelectReceiverLines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Receiving Lines"
        CType(Me.dgvReceiverLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderQuantityStatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvReceiverLines As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdSaveLines As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents PurchaseOrderQuantityStatusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderQuantityStatusTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderQuantityStatusTableAdapter
    Friend WithEvents ReceivingDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForReceipt As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PurchaseOrderLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POQuantityReceivedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POQuantityOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODropShipCustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseOrderHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
