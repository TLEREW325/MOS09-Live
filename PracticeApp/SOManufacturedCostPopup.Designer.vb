<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SOManufacturedCostPopup
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
        Me.dgvInventoryTransactions = New System.Windows.Forms.DataGridView
        Me.TransactionDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemCostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryTransactionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.InventoryTransactionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryTransactionTableTableAdapter
        CType(Me.dgvInventoryTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventoryTransactionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvInventoryTransactions
        '
        Me.dgvInventoryTransactions.AllowUserToAddRows = False
        Me.dgvInventoryTransactions.AllowUserToDeleteRows = False
        Me.dgvInventoryTransactions.AutoGenerateColumns = False
        Me.dgvInventoryTransactions.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInventoryTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvInventoryTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventoryTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TransactionDateDataGridViewTextBoxColumn, Me.TransactionTypeDataGridViewTextBoxColumn, Me.PartNumberDataGridViewTextBoxColumn, Me.QuantityDataGridViewTextBoxColumn, Me.ItemCostDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn})
        Me.dgvInventoryTransactions.DataSource = Me.InventoryTransactionTableBindingSource
        Me.dgvInventoryTransactions.GridColor = System.Drawing.Color.Cyan
        Me.dgvInventoryTransactions.Location = New System.Drawing.Point(-1, 3)
        Me.dgvInventoryTransactions.Name = "dgvInventoryTransactions"
        Me.dgvInventoryTransactions.ReadOnly = True
        Me.dgvInventoryTransactions.Size = New System.Drawing.Size(539, 267)
        Me.dgvInventoryTransactions.TabIndex = 0
        '
        'TransactionDateDataGridViewTextBoxColumn
        '
        Me.TransactionDateDataGridViewTextBoxColumn.DataPropertyName = "TransactionDate"
        Me.TransactionDateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.TransactionDateDataGridViewTextBoxColumn.Name = "TransactionDateDataGridViewTextBoxColumn"
        Me.TransactionDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TransactionTypeDataGridViewTextBoxColumn
        '
        Me.TransactionTypeDataGridViewTextBoxColumn.DataPropertyName = "TransactionType"
        Me.TransactionTypeDataGridViewTextBoxColumn.HeaderText = "TransactionType"
        Me.TransactionTypeDataGridViewTextBoxColumn.Name = "TransactionTypeDataGridViewTextBoxColumn"
        Me.TransactionTypeDataGridViewTextBoxColumn.ReadOnly = True
        Me.TransactionTypeDataGridViewTextBoxColumn.Visible = False
        '
        'PartNumberDataGridViewTextBoxColumn
        '
        Me.PartNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn.HeaderText = "Part #"
        Me.PartNumberDataGridViewTextBoxColumn.Name = "PartNumberDataGridViewTextBoxColumn"
        Me.PartNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.PartNumberDataGridViewTextBoxColumn.Width = 160
        '
        'QuantityDataGridViewTextBoxColumn
        '
        Me.QuantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity"
        Me.QuantityDataGridViewTextBoxColumn.HeaderText = "Qty. Made"
        Me.QuantityDataGridViewTextBoxColumn.Name = "QuantityDataGridViewTextBoxColumn"
        Me.QuantityDataGridViewTextBoxColumn.ReadOnly = True
        Me.QuantityDataGridViewTextBoxColumn.Width = 110
        '
        'ItemCostDataGridViewTextBoxColumn
        '
        Me.ItemCostDataGridViewTextBoxColumn.DataPropertyName = "ItemCost"
        DataGridViewCellStyle1.Format = "N5"
        DataGridViewCellStyle1.NullValue = "0"
        Me.ItemCostDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.ItemCostDataGridViewTextBoxColumn.HeaderText = "Item Cost"
        Me.ItemCostDataGridViewTextBoxColumn.Name = "ItemCostDataGridViewTextBoxColumn"
        Me.ItemCostDataGridViewTextBoxColumn.ReadOnly = True
        Me.ItemCostDataGridViewTextBoxColumn.Width = 110
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.DivisionIDDataGridViewTextBoxColumn.Visible = False
        '
        'InventoryTransactionTableBindingSource
        '
        Me.InventoryTransactionTableBindingSource.DataMember = "InventoryTransactionTable"
        Me.InventoryTransactionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'InventoryTransactionTableTableAdapter
        '
        Me.InventoryTransactionTableTableAdapter.ClearBeforeFill = True
        '
        'SOManufacturedCostPopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 273)
        Me.Controls.Add(Me.dgvInventoryTransactions)
        Me.Name = "SOManufacturedCostPopup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Manufactured Cost"
        CType(Me.dgvInventoryTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventoryTransactionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvInventoryTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents InventoryTransactionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InventoryTransactionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryTransactionTableTableAdapter
    Friend WithEvents TransactionDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemCostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
