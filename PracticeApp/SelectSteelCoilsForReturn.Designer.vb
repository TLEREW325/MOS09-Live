<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectSteelCoilsForReturn
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.cmdSaveLines = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvSteelReceivingCoilLines = New System.Windows.Forms.DataGridView
        Me.SteelReceivingCoilLinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.SteelReceivingCoilLinesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingCoilLinesTableAdapter
        Me.dgvCoilListing = New System.Windows.Forms.DataGridView
        Me.CharterSteelCoilIdentificationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CharterSteelCoilIdentificationTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CharterSteelCoilIdentificationTableAdapter
        Me.SelectCoilsColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.SteelReceivingHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReceivingLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CoilIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CoilWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCostPerPoundColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectCoilsColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.CoilIDColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WeightColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarbonColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DespatchNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiveDateColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvSteelReceivingCoilLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelReceivingCoilLinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCoilListing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CharterSteelCoilIdentificationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(89, 326)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 17
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectAll.Location = New System.Drawing.Point(12, 326)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectAll.TabIndex = 16
        Me.cmdSelectAll.Text = "Check All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'cmdSaveLines
        '
        Me.cmdSaveLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSaveLines.Location = New System.Drawing.Point(497, 326)
        Me.cmdSaveLines.Name = "cmdSaveLines"
        Me.cmdSaveLines.Size = New System.Drawing.Size(71, 40)
        Me.cmdSaveLines.TabIndex = 15
        Me.cmdSaveLines.Text = "Process For Return"
        Me.cmdSaveLines.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(574, 326)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvSteelReceivingCoilLines
        '
        Me.dgvSteelReceivingCoilLines.AllowUserToAddRows = False
        Me.dgvSteelReceivingCoilLines.AllowUserToDeleteRows = False
        Me.dgvSteelReceivingCoilLines.AutoGenerateColumns = False
        Me.dgvSteelReceivingCoilLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelReceivingCoilLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelReceivingCoilLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectCoilsColumn, Me.SteelReceivingHeaderKeyColumn, Me.SteelReceivingLineKeyColumn, Me.CoilIDColumn, Me.CoilWeightColumn, Me.SteelCostPerPoundColumn, Me.SteelExtendedAmountColumn, Me.HeatNumberColumn, Me.PONumberColumn, Me.POLineNumberColumn})
        Me.dgvSteelReceivingCoilLines.DataSource = Me.SteelReceivingCoilLinesBindingSource
        Me.dgvSteelReceivingCoilLines.GridColor = System.Drawing.Color.Maroon
        Me.dgvSteelReceivingCoilLines.Location = New System.Drawing.Point(12, 12)
        Me.dgvSteelReceivingCoilLines.Name = "dgvSteelReceivingCoilLines"
        Me.dgvSteelReceivingCoilLines.Size = New System.Drawing.Size(633, 308)
        Me.dgvSteelReceivingCoilLines.TabIndex = 18
        '
        'SteelReceivingCoilLinesBindingSource
        '
        Me.SteelReceivingCoilLinesBindingSource.DataMember = "SteelReceivingCoilLines"
        Me.SteelReceivingCoilLinesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SteelReceivingCoilLinesTableAdapter
        '
        Me.SteelReceivingCoilLinesTableAdapter.ClearBeforeFill = True
        '
        'dgvCoilListing
        '
        Me.dgvCoilListing.AllowUserToAddRows = False
        Me.dgvCoilListing.AllowUserToDeleteRows = False
        Me.dgvCoilListing.AutoGenerateColumns = False
        Me.dgvCoilListing.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvCoilListing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCoilListing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectCoilsColumn2, Me.CoilIDColumn2, Me.HeatNumberColumn2, Me.WeightColumn2, Me.CarbonColumn2, Me.SteelSizeColumn2, Me.PurchaseOrderNumberColumn2, Me.DespatchNumberColumn2, Me.ReceiveDateColumn2, Me.StatusColumn2})
        Me.dgvCoilListing.DataSource = Me.CharterSteelCoilIdentificationBindingSource
        Me.dgvCoilListing.Location = New System.Drawing.Point(12, 12)
        Me.dgvCoilListing.Name = "dgvCoilListing"
        Me.dgvCoilListing.Size = New System.Drawing.Size(633, 308)
        Me.dgvCoilListing.TabIndex = 19
        '
        'CharterSteelCoilIdentificationBindingSource
        '
        Me.CharterSteelCoilIdentificationBindingSource.DataMember = "CharterSteelCoilIdentification"
        Me.CharterSteelCoilIdentificationBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'CharterSteelCoilIdentificationTableAdapter
        '
        Me.CharterSteelCoilIdentificationTableAdapter.ClearBeforeFill = True
        '
        'SelectCoilsColumn
        '
        Me.SelectCoilsColumn.FalseValue = "UNSELECTED"
        Me.SelectCoilsColumn.HeaderText = "Select"
        Me.SelectCoilsColumn.Name = "SelectCoilsColumn"
        Me.SelectCoilsColumn.TrueValue = "SELECTED"
        Me.SelectCoilsColumn.Width = 50
        '
        'SteelReceivingHeaderKeyColumn
        '
        Me.SteelReceivingHeaderKeyColumn.DataPropertyName = "SteelReceivingHeaderKey"
        Me.SteelReceivingHeaderKeyColumn.HeaderText = "Receiver #"
        Me.SteelReceivingHeaderKeyColumn.Name = "SteelReceivingHeaderKeyColumn"
        Me.SteelReceivingHeaderKeyColumn.Width = 80
        '
        'SteelReceivingLineKeyColumn
        '
        Me.SteelReceivingLineKeyColumn.DataPropertyName = "SteelReceivingLineKey"
        Me.SteelReceivingLineKeyColumn.HeaderText = "Line #"
        Me.SteelReceivingLineKeyColumn.Name = "SteelReceivingLineKeyColumn"
        Me.SteelReceivingLineKeyColumn.Width = 60
        '
        'CoilIDColumn
        '
        Me.CoilIDColumn.DataPropertyName = "CoilID"
        Me.CoilIDColumn.HeaderText = "Coil ID"
        Me.CoilIDColumn.Name = "CoilIDColumn"
        Me.CoilIDColumn.Width = 80
        '
        'CoilWeightColumn
        '
        Me.CoilWeightColumn.DataPropertyName = "CoilWeight"
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = "0"
        Me.CoilWeightColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.CoilWeightColumn.HeaderText = "Coil Weight"
        Me.CoilWeightColumn.Name = "CoilWeightColumn"
        Me.CoilWeightColumn.Width = 80
        '
        'SteelCostPerPoundColumn
        '
        Me.SteelCostPerPoundColumn.DataPropertyName = "SteelCostPerPound"
        DataGridViewCellStyle5.Format = "N4"
        DataGridViewCellStyle5.NullValue = "0"
        Me.SteelCostPerPoundColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.SteelCostPerPoundColumn.HeaderText = "Cost/Pound"
        Me.SteelCostPerPoundColumn.Name = "SteelCostPerPoundColumn"
        Me.SteelCostPerPoundColumn.Width = 80
        '
        'SteelExtendedAmountColumn
        '
        Me.SteelExtendedAmountColumn.DataPropertyName = "SteelExtendedAmount"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.SteelExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.SteelExtendedAmountColumn.HeaderText = "Ext. Amt."
        Me.SteelExtendedAmountColumn.Name = "SteelExtendedAmountColumn"
        Me.SteelExtendedAmountColumn.Width = 80
        '
        'HeatNumberColumn
        '
        Me.HeatNumberColumn.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumn.HeaderText = "Heat #"
        Me.HeatNumberColumn.Name = "HeatNumberColumn"
        '
        'PONumberColumn
        '
        Me.PONumberColumn.DataPropertyName = "PONumber"
        Me.PONumberColumn.HeaderText = "PONumber"
        Me.PONumberColumn.Name = "PONumberColumn"
        Me.PONumberColumn.Visible = False
        '
        'POLineNumberColumn
        '
        Me.POLineNumberColumn.DataPropertyName = "POLineNumber"
        Me.POLineNumberColumn.HeaderText = "POLineNumber"
        Me.POLineNumberColumn.Name = "POLineNumberColumn"
        Me.POLineNumberColumn.Visible = False
        '
        'SelectCoilsColumn2
        '
        Me.SelectCoilsColumn2.FalseValue = "UNSELECTED"
        Me.SelectCoilsColumn2.HeaderText = "Select"
        Me.SelectCoilsColumn2.Name = "SelectCoilsColumn2"
        Me.SelectCoilsColumn2.TrueValue = "SELECTED"
        Me.SelectCoilsColumn2.Width = 50
        '
        'CoilIDColumn2
        '
        Me.CoilIDColumn2.DataPropertyName = "CoilID"
        Me.CoilIDColumn2.HeaderText = "Coil ID"
        Me.CoilIDColumn2.Name = "CoilIDColumn2"
        Me.CoilIDColumn2.Width = 90
        '
        'HeatNumberColumn2
        '
        Me.HeatNumberColumn2.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumn2.HeaderText = "Heat #"
        Me.HeatNumberColumn2.Name = "HeatNumberColumn2"
        Me.HeatNumberColumn2.Width = 90
        '
        'WeightColumn2
        '
        Me.WeightColumn2.DataPropertyName = "Weight"
        Me.WeightColumn2.HeaderText = "Weight"
        Me.WeightColumn2.Name = "WeightColumn2"
        Me.WeightColumn2.Width = 90
        '
        'CarbonColumn2
        '
        Me.CarbonColumn2.DataPropertyName = "Carbon"
        Me.CarbonColumn2.HeaderText = "Carbon"
        Me.CarbonColumn2.Name = "CarbonColumn2"
        '
        'SteelSizeColumn2
        '
        Me.SteelSizeColumn2.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn2.HeaderText = "Steel Size"
        Me.SteelSizeColumn2.Name = "SteelSizeColumn2"
        '
        'PurchaseOrderNumberColumn2
        '
        Me.PurchaseOrderNumberColumn2.DataPropertyName = "PurchaseOrderNumber"
        Me.PurchaseOrderNumberColumn2.HeaderText = "PO #"
        Me.PurchaseOrderNumberColumn2.Name = "PurchaseOrderNumberColumn2"
        '
        'DespatchNumberColumn2
        '
        Me.DespatchNumberColumn2.DataPropertyName = "DespatchNumber"
        Me.DespatchNumberColumn2.HeaderText = "BOL #"
        Me.DespatchNumberColumn2.Name = "DespatchNumberColumn2"
        '
        'ReceiveDateColumn2
        '
        Me.ReceiveDateColumn2.DataPropertyName = "ReceiveDate"
        Me.ReceiveDateColumn2.HeaderText = "Receive Date"
        Me.ReceiveDateColumn2.Name = "ReceiveDateColumn2"
        '
        'StatusColumn2
        '
        Me.StatusColumn2.DataPropertyName = "Status"
        Me.StatusColumn2.HeaderText = "Status"
        Me.StatusColumn2.Name = "StatusColumn2"
        Me.StatusColumn2.Visible = False
        '
        'SelectSteelCoilsForReturn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 378)
        Me.Controls.Add(Me.dgvCoilListing)
        Me.Controls.Add(Me.dgvSteelReceivingCoilLines)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.cmdSaveLines)
        Me.Controls.Add(Me.cmdExit)
        Me.Name = "SelectSteelCoilsForReturn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Select Steel Coils"
        CType(Me.dgvSteelReceivingCoilLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelReceivingCoilLinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCoilListing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CharterSteelCoilIdentificationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdSaveLines As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvSteelReceivingCoilLines As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents SteelReceivingCoilLinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelReceivingCoilLinesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingCoilLinesTableAdapter
    Friend WithEvents dgvCoilListing As System.Windows.Forms.DataGridView
    Friend WithEvents CharterSteelCoilIdentificationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CharterSteelCoilIdentificationTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CharterSteelCoilIdentificationTableAdapter
    Friend WithEvents SelectCoilsColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SteelReceivingHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReceivingLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoilIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoilWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCostPerPoundColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectCoilsColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CoilIDColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WeightColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseOrderNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DespatchNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiveDateColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
