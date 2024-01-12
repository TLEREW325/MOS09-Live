<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewAssemblyComponents
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.dgvAssemblyComponents = New System.Windows.Forms.DataGridView
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdGetGridData = New System.Windows.Forms.Button
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QOHColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MinStockColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaxStockColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenOrdersColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenPOsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvItemAssemblyList = New System.Windows.Forms.DataGridView
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.ItemIDColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShortDescriptionColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchProdLineIDolumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesProdLineIDColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MinimumStockColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaximumStockColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAssemblyComponents, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvItemAssemblyList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdGetGridData)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 323)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cboDivisionID
        '
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(133, 38)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(150, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'dgvAssemblyComponents
        '
        Me.dgvAssemblyComponents.AllowUserToAddRows = False
        Me.dgvAssemblyComponents.AllowUserToDeleteRows = False
        Me.dgvAssemblyComponents.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAssemblyComponents.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAssemblyComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAssemblyComponents.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.AssemblyPartNumberColumn, Me.DescriptionColumn, Me.QOHColumn, Me.MinStockColumn, Me.MaxStockColumn, Me.OpenOrdersColumn, Me.OpenPOsColumn, Me.ItemClassColumn})
        Me.dgvAssemblyComponents.GridColor = System.Drawing.Color.Purple
        Me.dgvAssemblyComponents.Location = New System.Drawing.Point(347, 41)
        Me.dgvAssemblyComponents.Name = "dgvAssemblyComponents"
        Me.dgvAssemblyComponents.Size = New System.Drawing.Size(783, 705)
        Me.dgvAssemblyComponents.TabIndex = 1
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Enabled = False
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 14
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 15
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Division"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdGetGridData
        '
        Me.cmdGetGridData.Location = New System.Drawing.Point(212, 92)
        Me.cmdGetGridData.Name = "cmdGetGridData"
        Me.cmdGetGridData.Size = New System.Drawing.Size(71, 30)
        Me.cmdGetGridData.TabIndex = 2
        Me.cmdGetGridData.Text = "View"
        Me.cmdGetGridData.UseVisualStyleBackColor = True
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        '
        'AssemblyPartNumberColumn
        '
        Me.AssemblyPartNumberColumn.HeaderText = "Part #"
        Me.AssemblyPartNumberColumn.Name = "AssemblyPartNumberColumn"
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        '
        'QOHColumn
        '
        Me.QOHColumn.HeaderText = "QOH"
        Me.QOHColumn.Name = "QOHColumn"
        '
        'MinStockColumn
        '
        Me.MinStockColumn.HeaderText = "Min Stock"
        Me.MinStockColumn.Name = "MinStockColumn"
        '
        'MaxStockColumn
        '
        Me.MaxStockColumn.HeaderText = "Max Stock"
        Me.MaxStockColumn.Name = "MaxStockColumn"
        '
        'OpenOrdersColumn
        '
        Me.OpenOrdersColumn.HeaderText = "Open Orders"
        Me.OpenOrdersColumn.Name = "OpenOrdersColumn"
        '
        'OpenPOsColumn
        '
        Me.OpenPOsColumn.HeaderText = "Open PO's"
        Me.OpenPOsColumn.Name = "OpenPOsColumn"
        '
        'ItemClassColumn
        '
        Me.ItemClassColumn.HeaderText = "Item Class"
        Me.ItemClassColumn.Name = "ItemClassColumn"
        '
        'dgvItemAssemblyList
        '
        Me.dgvItemAssemblyList.AllowUserToAddRows = False
        Me.dgvItemAssemblyList.AllowUserToDeleteRows = False
        Me.dgvItemAssemblyList.AutoGenerateColumns = False
        Me.dgvItemAssemblyList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvItemAssemblyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItemAssemblyList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemIDColumn1, Me.DivisionIDColumn1, Me.ShortDescriptionColumn1, Me.ItemClassColumn1, Me.PurchProdLineIDolumn1, Me.SalesProdLineIDColumn1, Me.MinimumStockColumn1, Me.MaximumStockColumn1})
        Me.dgvItemAssemblyList.DataSource = Me.ItemListBindingSource
        Me.dgvItemAssemblyList.Location = New System.Drawing.Point(29, 415)
        Me.dgvItemAssemblyList.Name = "dgvItemAssemblyList"
        Me.dgvItemAssemblyList.ReadOnly = True
        Me.dgvItemAssemblyList.Size = New System.Drawing.Size(300, 150)
        Me.dgvItemAssemblyList.TabIndex = 16
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'ItemIDColumn1
        '
        Me.ItemIDColumn1.DataPropertyName = "ItemID"
        Me.ItemIDColumn1.HeaderText = "ItemID"
        Me.ItemIDColumn1.Name = "ItemIDColumn1"
        Me.ItemIDColumn1.ReadOnly = True
        '
        'DivisionIDColumn1
        '
        Me.DivisionIDColumn1.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn1.HeaderText = "DivisionID"
        Me.DivisionIDColumn1.Name = "DivisionIDColumn1"
        Me.DivisionIDColumn1.ReadOnly = True
        '
        'ShortDescriptionColumn1
        '
        Me.ShortDescriptionColumn1.DataPropertyName = "ShortDescription"
        Me.ShortDescriptionColumn1.HeaderText = "ShortDescription"
        Me.ShortDescriptionColumn1.Name = "ShortDescriptionColumn1"
        Me.ShortDescriptionColumn1.ReadOnly = True
        '
        'ItemClassColumn1
        '
        Me.ItemClassColumn1.DataPropertyName = "ItemClass"
        Me.ItemClassColumn1.HeaderText = "ItemClass"
        Me.ItemClassColumn1.Name = "ItemClassColumn1"
        Me.ItemClassColumn1.ReadOnly = True
        '
        'PurchProdLineIDolumn1
        '
        Me.PurchProdLineIDolumn1.DataPropertyName = "PurchProdLineID"
        Me.PurchProdLineIDolumn1.HeaderText = "PurchProdLineID"
        Me.PurchProdLineIDolumn1.Name = "PurchProdLineIDolumn1"
        Me.PurchProdLineIDolumn1.ReadOnly = True
        '
        'SalesProdLineIDColumn1
        '
        Me.SalesProdLineIDColumn1.DataPropertyName = "SalesProdLineID"
        Me.SalesProdLineIDColumn1.HeaderText = "SalesProdLineID"
        Me.SalesProdLineIDColumn1.Name = "SalesProdLineIDColumn1"
        Me.SalesProdLineIDColumn1.ReadOnly = True
        '
        'MinimumStockColumn1
        '
        Me.MinimumStockColumn1.DataPropertyName = "MinimumStock"
        Me.MinimumStockColumn1.HeaderText = "MinimumStock"
        Me.MinimumStockColumn1.Name = "MinimumStockColumn1"
        Me.MinimumStockColumn1.ReadOnly = True
        '
        'MaximumStockColumn1
        '
        Me.MaximumStockColumn1.DataPropertyName = "MaximumStock"
        Me.MaximumStockColumn1.HeaderText = "MaximumStock"
        Me.MaximumStockColumn1.Name = "MaximumStockColumn1"
        Me.MaximumStockColumn1.ReadOnly = True
        '
        'ViewAssemblyComponents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.dgvItemAssemblyList)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvAssemblyComponents)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ViewAssemblyComponents"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation View Assembly Components"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAssemblyComponents, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvItemAssemblyList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents dgvAssemblyComponents As System.Windows.Forms.DataGridView
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdGetGridData As System.Windows.Forms.Button
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssemblyPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QOHColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinStockColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaxStockColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenOrdersColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenPOsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvItemAssemblyList As System.Windows.Forms.DataGridView
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents ItemIDColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShortDescriptionColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchProdLineIDolumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesProdLineIDColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinimumStockColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaximumStockColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
