<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectShipmentsForInvoicing
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
        Me.cmdProcessForInvoicing = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdCheckAll = New System.Windows.Forms.Button
        Me.cmdUnCheckAll = New System.Windows.Forms.Button
        Me.dgvShipmentHeader = New System.Windows.Forms.DataGridView
        Me.ShipmentHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.ShipmentHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
        Me.SelectForInvoicing = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TaxTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tax2TotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tax3TotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightActualAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipViaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipAddress1Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipAddress2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipCityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipStateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipZipColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipCountryColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumberOfPalletsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightQuoteNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightQuoteAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PickTicketNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOBColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SpecialInstructionsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingMethodColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ThirdPartyShipperColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvShipmentHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdProcessForInvoicing
        '
        Me.cmdProcessForInvoicing.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdProcessForInvoicing.Location = New System.Drawing.Point(497, 326)
        Me.cmdProcessForInvoicing.Name = "cmdProcessForInvoicing"
        Me.cmdProcessForInvoicing.Size = New System.Drawing.Size(71, 40)
        Me.cmdProcessForInvoicing.TabIndex = 31
        Me.cmdProcessForInvoicing.Text = "Process For Invoicing"
        Me.cmdProcessForInvoicing.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(574, 326)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 30
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdCheckAll
        '
        Me.cmdCheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCheckAll.Location = New System.Drawing.Point(12, 326)
        Me.cmdCheckAll.Name = "cmdCheckAll"
        Me.cmdCheckAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdCheckAll.TabIndex = 28
        Me.cmdCheckAll.Text = "Check All"
        Me.cmdCheckAll.UseVisualStyleBackColor = True
        '
        'cmdUnCheckAll
        '
        Me.cmdUnCheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdUnCheckAll.Location = New System.Drawing.Point(89, 326)
        Me.cmdUnCheckAll.Name = "cmdUnCheckAll"
        Me.cmdUnCheckAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdUnCheckAll.TabIndex = 29
        Me.cmdUnCheckAll.Text = "Uncheck All"
        Me.cmdUnCheckAll.UseVisualStyleBackColor = True
        '
        'dgvShipmentHeader
        '
        Me.dgvShipmentHeader.AllowUserToAddRows = False
        Me.dgvShipmentHeader.AllowUserToDeleteRows = False
        Me.dgvShipmentHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvShipmentHeader.AutoGenerateColumns = False
        Me.dgvShipmentHeader.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvShipmentHeader.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvShipmentHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShipmentHeader.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectForInvoicing, Me.ShipmentNumberColumn, Me.SalesOrderKeyColumn, Me.ShipDateColumn, Me.CustomerIDColumn, Me.CustomerPOColumn, Me.ProductTotalColumn, Me.TaxTotalColumn, Me.Tax2TotalColumn, Me.Tax3TotalColumn, Me.FreightActualAmountColumn, Me.ShipmentTotalColumn, Me.ShipViaColumn, Me.PRONumberColumn, Me.ShipToIDColumn, Me.ShipAddress1Column, Me.ShipAddress2Column, Me.ShipCityColumn, Me.ShipStateColumn, Me.ShipZipColumn, Me.ShipCountryColumn, Me.ShippingWeightColumn, Me.NumberOfPalletsColumn, Me.FreightQuoteNumberColumn, Me.FreightQuoteAmountColumn, Me.CommentColumn, Me.DivisionIDColumn, Me.PickTicketNumberColumn, Me.ShipmentStatusColumn, Me.FOBColumn, Me.CustomerClassColumn, Me.SpecialInstructionsColumn, Me.ShippingMethodColumn, Me.ThirdPartyShipperColumn})
        Me.dgvShipmentHeader.DataSource = Me.ShipmentHeaderTableBindingSource
        Me.dgvShipmentHeader.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvShipmentHeader.Location = New System.Drawing.Point(12, 6)
        Me.dgvShipmentHeader.Name = "dgvShipmentHeader"
        Me.dgvShipmentHeader.Size = New System.Drawing.Size(633, 310)
        Me.dgvShipmentHeader.TabIndex = 32
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
        'ShipmentHeaderTableTableAdapter
        '
        Me.ShipmentHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'SelectForInvoicing
        '
        Me.SelectForInvoicing.FalseValue = "UNSELECTED"
        Me.SelectForInvoicing.HeaderText = "Select"
        Me.SelectForInvoicing.Name = "SelectForInvoicing"
        Me.SelectForInvoicing.TrueValue = "SELECTED"
        Me.SelectForInvoicing.Width = 65
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "Shipment #"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        Me.ShipmentNumberColumn.Width = 65
        '
        'SalesOrderKeyColumn
        '
        Me.SalesOrderKeyColumn.DataPropertyName = "SalesOrderKey"
        Me.SalesOrderKeyColumn.HeaderText = "SO #"
        Me.SalesOrderKeyColumn.Name = "SalesOrderKeyColumn"
        Me.SalesOrderKeyColumn.Width = 65
        '
        'ShipDateColumn
        '
        Me.ShipDateColumn.DataPropertyName = "ShipDate"
        Me.ShipDateColumn.HeaderText = "Ship Date"
        Me.ShipDateColumn.Name = "ShipDateColumn"
        Me.ShipDateColumn.Width = 80
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer ID"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.Width = 80
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.HeaderText = "Customer PO"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        Me.CustomerPOColumn.Width = 80
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.ProductTotalColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.ProductTotalColumn.HeaderText = "Product Total"
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        '
        'TaxTotalColumn
        '
        Me.TaxTotalColumn.DataPropertyName = "TaxTotal"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.TaxTotalColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.TaxTotalColumn.HeaderText = "Tax Total"
        Me.TaxTotalColumn.Name = "TaxTotalColumn"
        Me.TaxTotalColumn.Visible = False
        '
        'Tax2TotalColumn
        '
        Me.Tax2TotalColumn.DataPropertyName = "Tax2Total"
        Me.Tax2TotalColumn.HeaderText = "Tax2Total"
        Me.Tax2TotalColumn.Name = "Tax2TotalColumn"
        Me.Tax2TotalColumn.Visible = False
        '
        'Tax3TotalColumn
        '
        Me.Tax3TotalColumn.DataPropertyName = "Tax3Total"
        Me.Tax3TotalColumn.HeaderText = "Tax3Total"
        Me.Tax3TotalColumn.Name = "Tax3TotalColumn"
        Me.Tax3TotalColumn.Visible = False
        '
        'FreightActualAmountColumn
        '
        Me.FreightActualAmountColumn.DataPropertyName = "FreightActualAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.FreightActualAmountColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.FreightActualAmountColumn.HeaderText = "Freight Total"
        Me.FreightActualAmountColumn.Name = "FreightActualAmountColumn"
        Me.FreightActualAmountColumn.Visible = False
        '
        'ShipmentTotalColumn
        '
        Me.ShipmentTotalColumn.DataPropertyName = "ShipmentTotal"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.ShipmentTotalColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.ShipmentTotalColumn.HeaderText = "Shipment Total"
        Me.ShipmentTotalColumn.Name = "ShipmentTotalColumn"
        '
        'ShipViaColumn
        '
        Me.ShipViaColumn.DataPropertyName = "ShipVia"
        Me.ShipViaColumn.HeaderText = "Ship Via"
        Me.ShipViaColumn.Name = "ShipViaColumn"
        Me.ShipViaColumn.Visible = False
        Me.ShipViaColumn.Width = 80
        '
        'PRONumberColumn
        '
        Me.PRONumberColumn.DataPropertyName = "PRONumber"
        Me.PRONumberColumn.HeaderText = "PRO Number"
        Me.PRONumberColumn.Name = "PRONumberColumn"
        Me.PRONumberColumn.Visible = False
        Me.PRONumberColumn.Width = 80
        '
        'ShipToIDColumn
        '
        Me.ShipToIDColumn.DataPropertyName = "ShipToID"
        Me.ShipToIDColumn.HeaderText = "Ship To ID"
        Me.ShipToIDColumn.Name = "ShipToIDColumn"
        Me.ShipToIDColumn.Visible = False
        Me.ShipToIDColumn.Width = 80
        '
        'ShipAddress1Column
        '
        Me.ShipAddress1Column.DataPropertyName = "ShipAddress1"
        Me.ShipAddress1Column.HeaderText = "ShipAddress1"
        Me.ShipAddress1Column.Name = "ShipAddress1Column"
        Me.ShipAddress1Column.Visible = False
        '
        'ShipAddress2Column
        '
        Me.ShipAddress2Column.DataPropertyName = "ShipAddress2"
        Me.ShipAddress2Column.HeaderText = "ShipAddress2"
        Me.ShipAddress2Column.Name = "ShipAddress2Column"
        Me.ShipAddress2Column.Visible = False
        '
        'ShipCityColumn
        '
        Me.ShipCityColumn.DataPropertyName = "ShipCity"
        Me.ShipCityColumn.HeaderText = "ShipCity"
        Me.ShipCityColumn.Name = "ShipCityColumn"
        Me.ShipCityColumn.Visible = False
        '
        'ShipStateColumn
        '
        Me.ShipStateColumn.DataPropertyName = "ShipState"
        Me.ShipStateColumn.HeaderText = "ShipState"
        Me.ShipStateColumn.Name = "ShipStateColumn"
        Me.ShipStateColumn.Visible = False
        '
        'ShipZipColumn
        '
        Me.ShipZipColumn.DataPropertyName = "ShipZip"
        Me.ShipZipColumn.HeaderText = "ShipZip"
        Me.ShipZipColumn.Name = "ShipZipColumn"
        Me.ShipZipColumn.Visible = False
        '
        'ShipCountryColumn
        '
        Me.ShipCountryColumn.DataPropertyName = "ShipCountry"
        Me.ShipCountryColumn.HeaderText = "ShipCountry"
        Me.ShipCountryColumn.Name = "ShipCountryColumn"
        Me.ShipCountryColumn.Visible = False
        '
        'ShippingWeightColumn
        '
        Me.ShippingWeightColumn.DataPropertyName = "ShippingWeight"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.ShippingWeightColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.ShippingWeightColumn.HeaderText = "ShippingWeight"
        Me.ShippingWeightColumn.Name = "ShippingWeightColumn"
        Me.ShippingWeightColumn.Visible = False
        '
        'NumberOfPalletsColumn
        '
        Me.NumberOfPalletsColumn.DataPropertyName = "NumberOfPallets"
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = "0"
        Me.NumberOfPalletsColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.NumberOfPalletsColumn.HeaderText = "NumberOfPallets"
        Me.NumberOfPalletsColumn.Name = "NumberOfPalletsColumn"
        Me.NumberOfPalletsColumn.Visible = False
        '
        'FreightQuoteNumberColumn
        '
        Me.FreightQuoteNumberColumn.DataPropertyName = "FreightQuoteNumber"
        Me.FreightQuoteNumberColumn.HeaderText = "FreightQuoteNumber"
        Me.FreightQuoteNumberColumn.Name = "FreightQuoteNumberColumn"
        Me.FreightQuoteNumberColumn.Visible = False
        '
        'FreightQuoteAmountColumn
        '
        Me.FreightQuoteAmountColumn.DataPropertyName = "FreightQuoteAmount"
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.FreightQuoteAmountColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.FreightQuoteAmountColumn.HeaderText = "FreightQuoteAmount"
        Me.FreightQuoteAmountColumn.Name = "FreightQuoteAmountColumn"
        Me.FreightQuoteAmountColumn.Visible = False
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        Me.CommentColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'PickTicketNumberColumn
        '
        Me.PickTicketNumberColumn.DataPropertyName = "PickTicketNumber"
        Me.PickTicketNumberColumn.HeaderText = "PickTicketNumber"
        Me.PickTicketNumberColumn.Name = "PickTicketNumberColumn"
        Me.PickTicketNumberColumn.Visible = False
        '
        'ShipmentStatusColumn
        '
        Me.ShipmentStatusColumn.DataPropertyName = "ShipmentStatus"
        Me.ShipmentStatusColumn.HeaderText = "ShipmentStatus"
        Me.ShipmentStatusColumn.Name = "ShipmentStatusColumn"
        Me.ShipmentStatusColumn.Visible = False
        '
        'FOBColumn
        '
        Me.FOBColumn.DataPropertyName = "FOB"
        Me.FOBColumn.HeaderText = "FOB"
        Me.FOBColumn.Name = "FOBColumn"
        Me.FOBColumn.Visible = False
        '
        'CustomerClassColumn
        '
        Me.CustomerClassColumn.DataPropertyName = "CustomerClass"
        Me.CustomerClassColumn.HeaderText = "CustomerClass"
        Me.CustomerClassColumn.Name = "CustomerClassColumn"
        Me.CustomerClassColumn.Visible = False
        '
        'SpecialInstructionsColumn
        '
        Me.SpecialInstructionsColumn.DataPropertyName = "SpecialInstructions"
        Me.SpecialInstructionsColumn.HeaderText = "SpecialInstructions"
        Me.SpecialInstructionsColumn.Name = "SpecialInstructionsColumn"
        Me.SpecialInstructionsColumn.Visible = False
        '
        'ShippingMethodColumn
        '
        Me.ShippingMethodColumn.DataPropertyName = "ShippingMethod"
        Me.ShippingMethodColumn.HeaderText = "ShippingMethod"
        Me.ShippingMethodColumn.Name = "ShippingMethodColumn"
        Me.ShippingMethodColumn.Visible = False
        '
        'ThirdPartyShipperColumn
        '
        Me.ThirdPartyShipperColumn.DataPropertyName = "ThirdPartyShipper"
        Me.ThirdPartyShipperColumn.HeaderText = "ThirdPartyShipper"
        Me.ThirdPartyShipperColumn.Name = "ThirdPartyShipperColumn"
        Me.ThirdPartyShipperColumn.Visible = False
        '
        'SelectShipmentsForInvoicing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 378)
        Me.Controls.Add(Me.dgvShipmentHeader)
        Me.Controls.Add(Me.cmdProcessForInvoicing)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdCheckAll)
        Me.Controls.Add(Me.cmdUnCheckAll)
        Me.Name = "SelectShipmentsForInvoicing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Select Shipments For Invoicing"
        CType(Me.dgvShipmentHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdProcessForInvoicing As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdCheckAll As System.Windows.Forms.Button
    Friend WithEvents cmdUnCheckAll As System.Windows.Forms.Button
    Friend WithEvents dgvShipmentHeader As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ShipmentHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
    Friend WithEvents SelectForInvoicing As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TaxTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tax2TotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tax3TotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightActualAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipViaColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipAddress1Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipAddress2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipCityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipStateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipZipColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipCountryColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumberOfPalletsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightQuoteNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightQuoteAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickTicketNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOBColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecialInstructionsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingMethodColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ThirdPartyShipperColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
