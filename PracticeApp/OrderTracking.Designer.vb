<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderTracking
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSalesOrderNumber = New System.Windows.Forms.TextBox
        Me.cmdTrace = New System.Windows.Forms.Button
        Me.gpxTraceResults = New System.Windows.Forms.GroupBox
        Me.lblField4 = New System.Windows.Forms.Label
        Me.lblField3 = New System.Windows.Forms.Label
        Me.lblField2 = New System.Windows.Forms.Label
        Me.lblField1 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvShipments = New System.Windows.Forms.DataGridView
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipViaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingMethodColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.dgvInvoices = New System.Windows.Forms.DataGridView
        Me.InvoiceNumberColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BilledFreightColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceStatusColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentsAppliedColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRONumberColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvReturns = New System.Windows.Forms.DataGridView
        Me.ReturnNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnDateColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnTotalColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnProductHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShipmentHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
        Me.InvoiceHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
        Me.ReturnProductHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReturnProductHeaderTableTableAdapter
        Me.cmdClear = New System.Windows.Forms.Button
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.gpxTraceResults.SuspendLayout()
        CType(Me.dgvShipments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReturns, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReturnProductHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter SO #:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesOrderNumber
        '
        Me.txtSalesOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesOrderNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesOrderNumber.Location = New System.Drawing.Point(153, 28)
        Me.txtSalesOrderNumber.Name = "txtSalesOrderNumber"
        Me.txtSalesOrderNumber.Size = New System.Drawing.Size(160, 20)
        Me.txtSalesOrderNumber.TabIndex = 0
        '
        'cmdTrace
        '
        Me.cmdTrace.Location = New System.Drawing.Point(340, 30)
        Me.cmdTrace.Name = "cmdTrace"
        Me.cmdTrace.Size = New System.Drawing.Size(75, 23)
        Me.cmdTrace.TabIndex = 2
        Me.cmdTrace.Text = "Trace"
        Me.cmdTrace.UseVisualStyleBackColor = True
        '
        'gpxTraceResults
        '
        Me.gpxTraceResults.Controls.Add(Me.lblField4)
        Me.gpxTraceResults.Controls.Add(Me.lblField3)
        Me.gpxTraceResults.Controls.Add(Me.lblField2)
        Me.gpxTraceResults.Controls.Add(Me.lblField1)
        Me.gpxTraceResults.Location = New System.Drawing.Point(12, 107)
        Me.gpxTraceResults.Name = "gpxTraceResults"
        Me.gpxTraceResults.Size = New System.Drawing.Size(567, 604)
        Me.gpxTraceResults.TabIndex = 3
        Me.gpxTraceResults.TabStop = False
        '
        'lblField4
        '
        Me.lblField4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblField4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblField4.ForeColor = System.Drawing.Color.Black
        Me.lblField4.Location = New System.Drawing.Point(14, 499)
        Me.lblField4.Name = "lblField4"
        Me.lblField4.Size = New System.Drawing.Size(540, 90)
        Me.lblField4.TabIndex = 4
        '
        'lblField3
        '
        Me.lblField3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblField3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblField3.ForeColor = System.Drawing.Color.Black
        Me.lblField3.Location = New System.Drawing.Point(14, 301)
        Me.lblField3.Name = "lblField3"
        Me.lblField3.Size = New System.Drawing.Size(540, 190)
        Me.lblField3.TabIndex = 3
        '
        'lblField2
        '
        Me.lblField2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblField2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblField2.ForeColor = System.Drawing.Color.Black
        Me.lblField2.Location = New System.Drawing.Point(14, 103)
        Me.lblField2.Name = "lblField2"
        Me.lblField2.Size = New System.Drawing.Size(540, 190)
        Me.lblField2.TabIndex = 2
        '
        'lblField1
        '
        Me.lblField1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblField1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblField1.ForeColor = System.Drawing.Color.Black
        Me.lblField1.Location = New System.Drawing.Point(14, 16)
        Me.lblField1.Name = "lblField1"
        Me.lblField1.Size = New System.Drawing.Size(539, 79)
        Me.lblField1.TabIndex = 1
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(494, 30)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvShipments
        '
        Me.dgvShipments.AllowUserToAddRows = False
        Me.dgvShipments.AllowUserToDeleteRows = False
        Me.dgvShipments.AllowUserToOrderColumns = True
        Me.dgvShipments.AllowUserToResizeColumns = False
        Me.dgvShipments.AllowUserToResizeRows = False
        Me.dgvShipments.AutoGenerateColumns = False
        Me.dgvShipments.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvShipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShipments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ShipmentNumberColumn, Me.SalesOrderKeyColumn, Me.DivisionIDColumn, Me.ShipDateColumn, Me.ShipViaColumn, Me.ShippingMethodColumn})
        Me.dgvShipments.DataSource = Me.ShipmentHeaderTableBindingSource
        Me.dgvShipments.Location = New System.Drawing.Point(191, 263)
        Me.dgvShipments.Name = "dgvShipments"
        Me.dgvShipments.Size = New System.Drawing.Size(346, 49)
        Me.dgvShipments.TabIndex = 5
        Me.dgvShipments.Visible = False
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "ShipmentNumber"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        '
        'SalesOrderKeyColumn
        '
        Me.SalesOrderKeyColumn.DataPropertyName = "SalesOrderKey"
        Me.SalesOrderKeyColumn.HeaderText = "SalesOrderKey"
        Me.SalesOrderKeyColumn.Name = "SalesOrderKeyColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        '
        'ShipDateColumn
        '
        Me.ShipDateColumn.DataPropertyName = "ShipDate"
        Me.ShipDateColumn.HeaderText = "ShipDate"
        Me.ShipDateColumn.Name = "ShipDateColumn"
        '
        'ShipViaColumn
        '
        Me.ShipViaColumn.DataPropertyName = "ShipVia"
        Me.ShipViaColumn.HeaderText = "ShipVia"
        Me.ShipViaColumn.Name = "ShipViaColumn"
        '
        'ShippingMethodColumn
        '
        Me.ShippingMethodColumn.DataPropertyName = "ShippingMethod"
        Me.ShippingMethodColumn.HeaderText = "ShippingMethod"
        Me.ShippingMethodColumn.Name = "ShippingMethodColumn"
        '
        'ShipmentHeaderTableBindingSource
        '
        Me.ShipmentHeaderTableBindingSource.DataMember = "ShipmentHeaderTable"
        Me.ShipmentHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dgvInvoices
        '
        Me.dgvInvoices.AllowUserToAddRows = False
        Me.dgvInvoices.AllowUserToDeleteRows = False
        Me.dgvInvoices.AutoGenerateColumns = False
        Me.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceNumberColumn1, Me.InvoiceDateColumn1, Me.SalesOrderNumberColumn1, Me.DivisionIDColumn1, Me.CustomerIDColumn1, Me.CustomerPOColumn1, Me.BilledFreightColumn1, Me.InvoiceTotalColumn1, Me.InvoiceStatusColumn1, Me.PaymentsAppliedColumn1, Me.PRONumberColumn1})
        Me.dgvInvoices.DataSource = Me.InvoiceHeaderTableBindingSource
        Me.dgvInvoices.Location = New System.Drawing.Point(191, 318)
        Me.dgvInvoices.Name = "dgvInvoices"
        Me.dgvInvoices.ReadOnly = True
        Me.dgvInvoices.Size = New System.Drawing.Size(240, 43)
        Me.dgvInvoices.TabIndex = 6
        Me.dgvInvoices.Visible = False
        '
        'InvoiceNumberColumn1
        '
        Me.InvoiceNumberColumn1.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn1.HeaderText = "InvoiceNumber"
        Me.InvoiceNumberColumn1.Name = "InvoiceNumberColumn1"
        Me.InvoiceNumberColumn1.ReadOnly = True
        '
        'InvoiceDateColumn1
        '
        Me.InvoiceDateColumn1.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumn1.HeaderText = "InvoiceDate"
        Me.InvoiceDateColumn1.Name = "InvoiceDateColumn1"
        Me.InvoiceDateColumn1.ReadOnly = True
        '
        'SalesOrderNumberColumn1
        '
        Me.SalesOrderNumberColumn1.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberColumn1.HeaderText = "SalesOrderNumber"
        Me.SalesOrderNumberColumn1.Name = "SalesOrderNumberColumn1"
        Me.SalesOrderNumberColumn1.ReadOnly = True
        '
        'DivisionIDColumn1
        '
        Me.DivisionIDColumn1.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn1.HeaderText = "DivisionID"
        Me.DivisionIDColumn1.Name = "DivisionIDColumn1"
        Me.DivisionIDColumn1.ReadOnly = True
        '
        'CustomerIDColumn1
        '
        Me.CustomerIDColumn1.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn1.HeaderText = "CustomerID"
        Me.CustomerIDColumn1.Name = "CustomerIDColumn1"
        Me.CustomerIDColumn1.ReadOnly = True
        '
        'CustomerPOColumn1
        '
        Me.CustomerPOColumn1.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn1.HeaderText = "CustomerPO"
        Me.CustomerPOColumn1.Name = "CustomerPOColumn1"
        Me.CustomerPOColumn1.ReadOnly = True
        '
        'BilledFreightColumn1
        '
        Me.BilledFreightColumn1.DataPropertyName = "BilledFreight"
        Me.BilledFreightColumn1.HeaderText = "BilledFreight"
        Me.BilledFreightColumn1.Name = "BilledFreightColumn1"
        Me.BilledFreightColumn1.ReadOnly = True
        '
        'InvoiceTotalColumn1
        '
        Me.InvoiceTotalColumn1.DataPropertyName = "InvoiceTotal"
        Me.InvoiceTotalColumn1.HeaderText = "InvoiceTotal"
        Me.InvoiceTotalColumn1.Name = "InvoiceTotalColumn1"
        Me.InvoiceTotalColumn1.ReadOnly = True
        '
        'InvoiceStatusColumn1
        '
        Me.InvoiceStatusColumn1.DataPropertyName = "InvoiceStatus"
        Me.InvoiceStatusColumn1.HeaderText = "InvoiceStatus"
        Me.InvoiceStatusColumn1.Name = "InvoiceStatusColumn1"
        Me.InvoiceStatusColumn1.ReadOnly = True
        '
        'PaymentsAppliedColumn1
        '
        Me.PaymentsAppliedColumn1.DataPropertyName = "PaymentsApplied"
        Me.PaymentsAppliedColumn1.HeaderText = "PaymentsApplied"
        Me.PaymentsAppliedColumn1.Name = "PaymentsAppliedColumn1"
        Me.PaymentsAppliedColumn1.ReadOnly = True
        '
        'PRONumberColumn1
        '
        Me.PRONumberColumn1.DataPropertyName = "PRONumber"
        Me.PRONumberColumn1.HeaderText = "PRONumber"
        Me.PRONumberColumn1.Name = "PRONumberColumn1"
        Me.PRONumberColumn1.ReadOnly = True
        '
        'InvoiceHeaderTableBindingSource
        '
        Me.InvoiceHeaderTableBindingSource.DataMember = "InvoiceHeaderTable"
        Me.InvoiceHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvReturns
        '
        Me.dgvReturns.AllowUserToAddRows = False
        Me.dgvReturns.AllowUserToDeleteRows = False
        Me.dgvReturns.AutoGenerateColumns = False
        Me.dgvReturns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReturns.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReturnNumberColumn2, Me.ReturnDateColumn2, Me.DivisionIDColumn2, Me.SalesOrderNumberColumn2, Me.ReturnTotalColumn2})
        Me.dgvReturns.DataSource = Me.ReturnProductHeaderTableBindingSource
        Me.dgvReturns.Location = New System.Drawing.Point(191, 373)
        Me.dgvReturns.Name = "dgvReturns"
        Me.dgvReturns.ReadOnly = True
        Me.dgvReturns.Size = New System.Drawing.Size(240, 40)
        Me.dgvReturns.TabIndex = 7
        Me.dgvReturns.Visible = False
        '
        'ReturnNumberColumn2
        '
        Me.ReturnNumberColumn2.DataPropertyName = "ReturnNumber"
        Me.ReturnNumberColumn2.HeaderText = "ReturnNumber"
        Me.ReturnNumberColumn2.Name = "ReturnNumberColumn2"
        Me.ReturnNumberColumn2.ReadOnly = True
        '
        'ReturnDateColumn2
        '
        Me.ReturnDateColumn2.DataPropertyName = "ReturnDate"
        Me.ReturnDateColumn2.HeaderText = "ReturnDate"
        Me.ReturnDateColumn2.Name = "ReturnDateColumn2"
        Me.ReturnDateColumn2.ReadOnly = True
        '
        'DivisionIDColumn2
        '
        Me.DivisionIDColumn2.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn2.HeaderText = "DivisionID"
        Me.DivisionIDColumn2.Name = "DivisionIDColumn2"
        Me.DivisionIDColumn2.ReadOnly = True
        '
        'SalesOrderNumberColumn2
        '
        Me.SalesOrderNumberColumn2.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberColumn2.HeaderText = "SalesOrderNumber"
        Me.SalesOrderNumberColumn2.Name = "SalesOrderNumberColumn2"
        Me.SalesOrderNumberColumn2.ReadOnly = True
        '
        'ReturnTotalColumn2
        '
        Me.ReturnTotalColumn2.DataPropertyName = "ReturnTotal"
        Me.ReturnTotalColumn2.HeaderText = "ReturnTotal"
        Me.ReturnTotalColumn2.Name = "ReturnTotalColumn2"
        Me.ReturnTotalColumn2.ReadOnly = True
        '
        'ReturnProductHeaderTableBindingSource
        '
        Me.ReturnProductHeaderTableBindingSource.DataMember = "ReturnProductHeaderTable"
        Me.ReturnProductHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ShipmentHeaderTableTableAdapter
        '
        Me.ShipmentHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'InvoiceHeaderTableTableAdapter
        '
        Me.InvoiceHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'ReturnProductHeaderTableTableAdapter
        '
        Me.ReturnProductHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(340, 64)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(75, 23)
        Me.cmdClear.TabIndex = 3
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'txtCustomerPO
        '
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerPO.Location = New System.Drawing.Point(153, 67)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(160, 20)
        Me.txtCustomerPO.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 23)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Enter Customer PO #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OrderTracking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 723)
        Me.Controls.Add(Me.txtCustomerPO)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxTraceResults)
        Me.Controls.Add(Me.cmdTrace)
        Me.Controls.Add(Me.txtSalesOrderNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvShipments)
        Me.Controls.Add(Me.dgvInvoices)
        Me.Controls.Add(Me.dgvReturns)
        Me.Name = "OrderTracking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Order Tracking"
        Me.gpxTraceResults.ResumeLayout(False)
        CType(Me.dgvShipments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReturns, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReturnProductHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSalesOrderNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmdTrace As System.Windows.Forms.Button
    Friend WithEvents gpxTraceResults As System.Windows.Forms.GroupBox
    Friend WithEvents lblField4 As System.Windows.Forms.Label
    Friend WithEvents lblField3 As System.Windows.Forms.Label
    Friend WithEvents lblField2 As System.Windows.Forms.Label
    Friend WithEvents lblField1 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvShipments As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ShipmentHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipViaColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingMethodColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvInvoices As System.Windows.Forms.DataGridView
    Friend WithEvents InvoiceHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
    Friend WithEvents InvoiceNumberColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BilledFreightColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceStatusColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentsAppliedColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRONumberColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvReturns As System.Windows.Forms.DataGridView
    Friend WithEvents ReturnProductHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReturnProductHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReturnProductHeaderTableTableAdapter
    Friend WithEvents ReturnNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnDateColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnTotalColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
