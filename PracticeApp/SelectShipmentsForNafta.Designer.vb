<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectShipmentsForNafta
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
        Me.cmdAddToNafta = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdCheckAll = New System.Windows.Forms.Button
        Me.cmdUnCheckAll = New System.Windows.Forms.Button
        Me.dgvShipmentHeaders = New System.Windows.Forms.DataGridView
        Me.ShipmentHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.ShipmentHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
        Me.SelectForNafta = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipViaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumberOfPalletsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvShipmentHeaders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdAddToNafta
        '
        Me.cmdAddToNafta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddToNafta.Location = New System.Drawing.Point(500, 326)
        Me.cmdAddToNafta.Name = "cmdAddToNafta"
        Me.cmdAddToNafta.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddToNafta.TabIndex = 35
        Me.cmdAddToNafta.Text = "Add To NAFTA"
        Me.cmdAddToNafta.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(577, 326)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 34
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdCheckAll
        '
        Me.cmdCheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCheckAll.Location = New System.Drawing.Point(15, 326)
        Me.cmdCheckAll.Name = "cmdCheckAll"
        Me.cmdCheckAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdCheckAll.TabIndex = 32
        Me.cmdCheckAll.Text = "Check All"
        Me.cmdCheckAll.UseVisualStyleBackColor = True
        '
        'cmdUnCheckAll
        '
        Me.cmdUnCheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdUnCheckAll.Location = New System.Drawing.Point(92, 326)
        Me.cmdUnCheckAll.Name = "cmdUnCheckAll"
        Me.cmdUnCheckAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdUnCheckAll.TabIndex = 33
        Me.cmdUnCheckAll.Text = "Uncheck All"
        Me.cmdUnCheckAll.UseVisualStyleBackColor = True
        '
        'dgvShipmentHeaders
        '
        Me.dgvShipmentHeaders.AllowUserToAddRows = False
        Me.dgvShipmentHeaders.AllowUserToDeleteRows = False
        Me.dgvShipmentHeaders.AutoGenerateColumns = False
        Me.dgvShipmentHeaders.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvShipmentHeaders.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvShipmentHeaders.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvShipmentHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShipmentHeaders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectForNafta, Me.ShipmentNumberColumn, Me.SalesOrderKeyColumn, Me.ShipDateColumn, Me.CustomerPOColumn, Me.ShipViaColumn, Me.ShippingWeightColumn, Me.NumberOfPalletsColumn, Me.CustomerIDColumn, Me.DivisionIDColumn})
        Me.dgvShipmentHeaders.DataSource = Me.ShipmentHeaderTableBindingSource
        Me.dgvShipmentHeaders.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvShipmentHeaders.Location = New System.Drawing.Point(15, 12)
        Me.dgvShipmentHeaders.Name = "dgvShipmentHeaders"
        Me.dgvShipmentHeaders.Size = New System.Drawing.Size(633, 297)
        Me.dgvShipmentHeaders.TabIndex = 36
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
        'SelectForNafta
        '
        Me.SelectForNafta.FalseValue = "UNSELECTED"
        Me.SelectForNafta.HeaderText = "Select"
        Me.SelectForNafta.Name = "SelectForNafta"
        Me.SelectForNafta.TrueValue = "SELECTED"
        Me.SelectForNafta.Width = 70
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "Shipment #"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        '
        'SalesOrderKeyColumn
        '
        Me.SalesOrderKeyColumn.DataPropertyName = "SalesOrderKey"
        Me.SalesOrderKeyColumn.HeaderText = "SO #"
        Me.SalesOrderKeyColumn.Name = "SalesOrderKeyColumn"
        '
        'ShipDateColumn
        '
        Me.ShipDateColumn.DataPropertyName = "ShipDate"
        Me.ShipDateColumn.HeaderText = "Ship Date"
        Me.ShipDateColumn.Name = "ShipDateColumn"
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.HeaderText = "Cust PO#"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        '
        'ShipViaColumn
        '
        Me.ShipViaColumn.DataPropertyName = "ShipVia"
        Me.ShipViaColumn.HeaderText = "Ship Via"
        Me.ShipViaColumn.Name = "ShipViaColumn"
        '
        'ShippingWeightColumn
        '
        Me.ShippingWeightColumn.DataPropertyName = "ShippingWeight"
        Me.ShippingWeightColumn.HeaderText = "ShippingWeight"
        Me.ShippingWeightColumn.Name = "ShippingWeightColumn"
        Me.ShippingWeightColumn.Visible = False
        '
        'NumberOfPalletsColumn
        '
        Me.NumberOfPalletsColumn.DataPropertyName = "NumberOfPallets"
        Me.NumberOfPalletsColumn.HeaderText = "NumberOfPallets"
        Me.NumberOfPalletsColumn.Name = "NumberOfPalletsColumn"
        Me.NumberOfPalletsColumn.Visible = False
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "CustomerID"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'SelectShipmentsForNafta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 378)
        Me.Controls.Add(Me.dgvShipmentHeaders)
        Me.Controls.Add(Me.cmdAddToNafta)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdCheckAll)
        Me.Controls.Add(Me.cmdUnCheckAll)
        Me.Name = "SelectShipmentsForNafta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Shipments to Add to NAFTA Documents"
        CType(Me.dgvShipmentHeaders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdAddToNafta As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdCheckAll As System.Windows.Forms.Button
    Friend WithEvents cmdUnCheckAll As System.Windows.Forms.Button
    Friend WithEvents dgvShipmentHeaders As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ShipmentHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
    Friend WithEvents SelectForNafta As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipViaColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumberOfPalletsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
