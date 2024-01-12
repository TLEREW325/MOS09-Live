<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectSteelCoilsForReceiving
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
        Me.dgvCharterCoils = New System.Windows.Forms.DataGridView
        Me.SelectForReceiptColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.CoilIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarbonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DespatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiveDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LocationColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AnnealLotColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CharterSteelCoilIdentificationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.CharterSteelCoilIdentificationTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CharterSteelCoilIdentificationTableAdapter
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.cmdSaveLines = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        CType(Me.dgvCharterCoils, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CharterSteelCoilIdentificationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCharterCoils
        '
        Me.dgvCharterCoils.AllowUserToAddRows = False
        Me.dgvCharterCoils.AllowUserToDeleteRows = False
        Me.dgvCharterCoils.AutoGenerateColumns = False
        Me.dgvCharterCoils.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvCharterCoils.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCharterCoils.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectForReceiptColumn, Me.CoilIDColumn, Me.CarbonColumn, Me.SteelSizeColumn, Me.WeightColumn, Me.HeatNumberColumn, Me.DespatchNumberColumn, Me.PurchaseOrderNumberColumn, Me.LotNumberColumn, Me.ReceiveDateColumn, Me.SalesOrderNumberColumn, Me.DescriptionColumn, Me.StatusColumn, Me.LocationColumn, Me.InventoryIDColumn, Me.AnnealLotColumn, Me.CommentColumn})
        Me.dgvCharterCoils.DataSource = Me.CharterSteelCoilIdentificationBindingSource
        Me.dgvCharterCoils.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvCharterCoils.Location = New System.Drawing.Point(12, 12)
        Me.dgvCharterCoils.Name = "dgvCharterCoils"
        Me.dgvCharterCoils.Size = New System.Drawing.Size(568, 300)
        Me.dgvCharterCoils.TabIndex = 0
        '
        'SelectForReceiptColumn
        '
        Me.SelectForReceiptColumn.FalseValue = "UNSELECTED"
        Me.SelectForReceiptColumn.HeaderText = "Select"
        Me.SelectForReceiptColumn.Name = "SelectForReceiptColumn"
        Me.SelectForReceiptColumn.TrueValue = "SELECTED"
        Me.SelectForReceiptColumn.Width = 50
        '
        'CoilIDColumn
        '
        Me.CoilIDColumn.DataPropertyName = "CoilID"
        Me.CoilIDColumn.HeaderText = "Coil ID"
        Me.CoilIDColumn.Name = "CoilIDColumn"
        '
        'CarbonColumn
        '
        Me.CarbonColumn.DataPropertyName = "Carbon"
        Me.CarbonColumn.HeaderText = "Carbon/Alloy"
        Me.CarbonColumn.Name = "CarbonColumn"
        '
        'SteelSizeColumn
        '
        Me.SteelSizeColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn.HeaderText = "Steel Size"
        Me.SteelSizeColumn.Name = "SteelSizeColumn"
        '
        'WeightColumn
        '
        Me.WeightColumn.DataPropertyName = "Weight"
        Me.WeightColumn.HeaderText = "Weight"
        Me.WeightColumn.Name = "WeightColumn"
        '
        'HeatNumberColumn
        '
        Me.HeatNumberColumn.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumn.HeaderText = "Heat #"
        Me.HeatNumberColumn.Name = "HeatNumberColumn"
        '
        'DespatchNumberColumn
        '
        Me.DespatchNumberColumn.DataPropertyName = "DespatchNumber"
        Me.DespatchNumberColumn.HeaderText = "Despatch #"
        Me.DespatchNumberColumn.Name = "DespatchNumberColumn"
        '
        'PurchaseOrderNumberColumn
        '
        Me.PurchaseOrderNumberColumn.DataPropertyName = "PurchaseOrderNumber"
        Me.PurchaseOrderNumberColumn.HeaderText = "PO #"
        Me.PurchaseOrderNumberColumn.Name = "PurchaseOrderNumberColumn"
        '
        'LotNumberColumn
        '
        Me.LotNumberColumn.DataPropertyName = "LotNumber"
        Me.LotNumberColumn.HeaderText = "Lot #"
        Me.LotNumberColumn.Name = "LotNumberColumn"
        '
        'ReceiveDateColumn
        '
        Me.ReceiveDateColumn.DataPropertyName = "ReceiveDate"
        Me.ReceiveDateColumn.HeaderText = "ReceiveDate"
        Me.ReceiveDateColumn.Name = "ReceiveDateColumn"
        Me.ReceiveDateColumn.Visible = False
        '
        'SalesOrderNumberColumn
        '
        Me.SalesOrderNumberColumn.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberColumn.HeaderText = "SalesOrderNumber"
        Me.SalesOrderNumberColumn.Name = "SalesOrderNumberColumn"
        Me.SalesOrderNumberColumn.Visible = False
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        Me.DescriptionColumn.Visible = False
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.Visible = False
        '
        'LocationColumn
        '
        Me.LocationColumn.DataPropertyName = "Location"
        Me.LocationColumn.HeaderText = "Location"
        Me.LocationColumn.Name = "LocationColumn"
        Me.LocationColumn.Visible = False
        '
        'InventoryIDColumn
        '
        Me.InventoryIDColumn.DataPropertyName = "InventoryID"
        Me.InventoryIDColumn.HeaderText = "InventoryID"
        Me.InventoryIDColumn.Name = "InventoryIDColumn"
        Me.InventoryIDColumn.Visible = False
        '
        'AnnealLotColumn
        '
        Me.AnnealLotColumn.DataPropertyName = "AnnealLot"
        Me.AnnealLotColumn.HeaderText = "AnnealLot"
        Me.AnnealLotColumn.Name = "AnnealLotColumn"
        Me.AnnealLotColumn.Visible = False
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        Me.CommentColumn.Visible = False
        '
        'CharterSteelCoilIdentificationBindingSource
        '
        Me.CharterSteelCoilIdentificationBindingSource.DataMember = "CharterSteelCoilIdentification"
        Me.CharterSteelCoilIdentificationBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CharterSteelCoilIdentificationTableAdapter
        '
        Me.CharterSteelCoilIdentificationTableAdapter.ClearBeforeFill = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(87, 321)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 9
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectAll.Location = New System.Drawing.Point(10, 321)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectAll.TabIndex = 8
        Me.cmdSelectAll.Text = "Check All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'cmdSaveLines
        '
        Me.cmdSaveLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSaveLines.Location = New System.Drawing.Point(432, 321)
        Me.cmdSaveLines.Name = "cmdSaveLines"
        Me.cmdSaveLines.Size = New System.Drawing.Size(71, 40)
        Me.cmdSaveLines.TabIndex = 7
        Me.cmdSaveLines.Text = "Add Coils"
        Me.cmdSaveLines.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(509, 321)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 10
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'SelectSteelCoilsForReceiving
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 373)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.cmdSaveLines)
        Me.Controls.Add(Me.dgvCharterCoils)
        Me.Name = "SelectSteelCoilsForReceiving"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Select Steel Coils"
        CType(Me.dgvCharterCoils, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CharterSteelCoilIdentificationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvCharterCoils As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents CharterSteelCoilIdentificationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CharterSteelCoilIdentificationTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CharterSteelCoilIdentificationTableAdapter
    Friend WithEvents SelectForReceiptColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CoilIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DespatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiveDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LocationColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InventoryIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnnealLotColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdSaveLines As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
End Class
