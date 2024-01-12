<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RackingPopup
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
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.lblItemNumber = New System.Windows.Forms.Label
        Me.dgvRackingTransactions = New System.Windows.Forms.DataGridView
        Me.RackingKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BinNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PiecesPerBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalPiecesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackingWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActivityDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreationDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackingTransactionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RackingTransactionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RackingTransactionTableTableAdapter
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtQtyInRack = New System.Windows.Forms.TextBox
        Me.txtQtyOnHand = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.cmdPrintRacking = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRackingTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RackingTransactionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(12, 41)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(302, 21)
        Me.cboPartDescription.TabIndex = 111
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(92, 12)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(222, 21)
        Me.cboPartNumber.TabIndex = 110
        Me.cboPartNumber.ValueMember = "ItemClassID"
        '
        'lblItemNumber
        '
        Me.lblItemNumber.Location = New System.Drawing.Point(12, 12)
        Me.lblItemNumber.Name = "lblItemNumber"
        Me.lblItemNumber.Size = New System.Drawing.Size(107, 20)
        Me.lblItemNumber.TabIndex = 112
        Me.lblItemNumber.Text = "Part Number"
        Me.lblItemNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvRackingTransactions
        '
        Me.dgvRackingTransactions.AllowUserToAddRows = False
        Me.dgvRackingTransactions.AllowUserToDeleteRows = False
        Me.dgvRackingTransactions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRackingTransactions.AutoGenerateColumns = False
        Me.dgvRackingTransactions.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvRackingTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRackingTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RackingKeyColumn, Me.BinNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.BoxQuantityColumn, Me.PiecesPerBoxColumn, Me.TotalPiecesColumn, Me.HeatNumberColumn, Me.LotNumberColumn, Me.RackingWeightColumn, Me.ActivityDateColumn, Me.DivisionIDColumn, Me.CreationDateColumn})
        Me.dgvRackingTransactions.DataSource = Me.RackingTransactionTableBindingSource
        Me.dgvRackingTransactions.GridColor = System.Drawing.Color.Fuchsia
        Me.dgvRackingTransactions.Location = New System.Drawing.Point(12, 79)
        Me.dgvRackingTransactions.Name = "dgvRackingTransactions"
        Me.dgvRackingTransactions.ReadOnly = True
        Me.dgvRackingTransactions.Size = New System.Drawing.Size(695, 393)
        Me.dgvRackingTransactions.TabIndex = 113
        '
        'RackingKeyColumn
        '
        Me.RackingKeyColumn.DataPropertyName = "RackingKey"
        Me.RackingKeyColumn.HeaderText = "RackingKey"
        Me.RackingKeyColumn.Name = "RackingKeyColumn"
        Me.RackingKeyColumn.ReadOnly = True
        Me.RackingKeyColumn.Visible = False
        '
        'BinNumberColumn
        '
        Me.BinNumberColumn.DataPropertyName = "BinNumber"
        Me.BinNumberColumn.HeaderText = "Bin #"
        Me.BinNumberColumn.Name = "BinNumberColumn"
        Me.BinNumberColumn.ReadOnly = True
        Me.BinNumberColumn.Width = 50
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
        'BoxQuantityColumn
        '
        Me.BoxQuantityColumn.DataPropertyName = "BoxQuantity"
        Me.BoxQuantityColumn.HeaderText = "Box Qty"
        Me.BoxQuantityColumn.Name = "BoxQuantityColumn"
        Me.BoxQuantityColumn.ReadOnly = True
        Me.BoxQuantityColumn.Width = 80
        '
        'PiecesPerBoxColumn
        '
        Me.PiecesPerBoxColumn.DataPropertyName = "PiecesPerBox"
        Me.PiecesPerBoxColumn.HeaderText = "Pieces/Box"
        Me.PiecesPerBoxColumn.Name = "PiecesPerBoxColumn"
        Me.PiecesPerBoxColumn.ReadOnly = True
        Me.PiecesPerBoxColumn.Width = 80
        '
        'TotalPiecesColumn
        '
        Me.TotalPiecesColumn.DataPropertyName = "TotalPieces"
        Me.TotalPiecesColumn.HeaderText = "Total Pieces"
        Me.TotalPiecesColumn.Name = "TotalPiecesColumn"
        Me.TotalPiecesColumn.ReadOnly = True
        Me.TotalPiecesColumn.Width = 80
        '
        'HeatNumberColumn
        '
        Me.HeatNumberColumn.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumn.HeaderText = "Heat #"
        Me.HeatNumberColumn.Name = "HeatNumberColumn"
        Me.HeatNumberColumn.ReadOnly = True
        Me.HeatNumberColumn.Width = 80
        '
        'LotNumberColumn
        '
        Me.LotNumberColumn.DataPropertyName = "LotNumber"
        Me.LotNumberColumn.HeaderText = "Lot #"
        Me.LotNumberColumn.Name = "LotNumberColumn"
        Me.LotNumberColumn.ReadOnly = True
        Me.LotNumberColumn.Width = 80
        '
        'RackingWeightColumn
        '
        Me.RackingWeightColumn.DataPropertyName = "RackingWeight"
        Me.RackingWeightColumn.HeaderText = "RackingWeight"
        Me.RackingWeightColumn.Name = "RackingWeightColumn"
        Me.RackingWeightColumn.ReadOnly = True
        Me.RackingWeightColumn.Visible = False
        '
        'ActivityDateColumn
        '
        Me.ActivityDateColumn.DataPropertyName = "ActivityDate"
        Me.ActivityDateColumn.HeaderText = "ActivityDate"
        Me.ActivityDateColumn.Name = "ActivityDateColumn"
        Me.ActivityDateColumn.ReadOnly = True
        Me.ActivityDateColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'CreationDateColumn
        '
        Me.CreationDateColumn.DataPropertyName = "CreationDate"
        Me.CreationDateColumn.HeaderText = "CreationDate"
        Me.CreationDateColumn.Name = "CreationDateColumn"
        Me.CreationDateColumn.ReadOnly = True
        Me.CreationDateColumn.Visible = False
        '
        'RackingTransactionTableBindingSource
        '
        Me.RackingTransactionTableBindingSource.DataMember = "RackingTransactionTable"
        Me.RackingTransactionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'RackingTransactionTableTableAdapter
        '
        Me.RackingTransactionTableTableAdapter.ClearBeforeFill = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(12, 491)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 20)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "Quantity in Rack"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQtyInRack
        '
        Me.txtQtyInRack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQtyInRack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQtyInRack.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQtyInRack.Location = New System.Drawing.Point(113, 491)
        Me.txtQtyInRack.Name = "txtQtyInRack"
        Me.txtQtyInRack.Size = New System.Drawing.Size(145, 20)
        Me.txtQtyInRack.TabIndex = 115
        Me.txtQtyInRack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQtyOnHand
        '
        Me.txtQtyOnHand.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQtyOnHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQtyOnHand.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQtyOnHand.Location = New System.Drawing.Point(386, 491)
        Me.txtQtyOnHand.Name = "txtQtyOnHand"
        Me.txtQtyOnHand.Size = New System.Drawing.Size(145, 20)
        Me.txtQtyOnHand.TabIndex = 117
        Me.txtQtyOnHand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(285, 491)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 20)
        Me.Label2.TabIndex = 116
        Me.Label2.Text = "Quantity On Hand"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'cmdPrintRacking
        '
        Me.cmdPrintRacking.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintRacking.Location = New System.Drawing.Point(559, 486)
        Me.cmdPrintRacking.Name = "cmdPrintRacking"
        Me.cmdPrintRacking.Size = New System.Drawing.Size(71, 30)
        Me.cmdPrintRacking.TabIndex = 118
        Me.cmdPrintRacking.Text = "Print"
        Me.cmdPrintRacking.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(636, 486)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 30)
        Me.cmdExit.TabIndex = 119
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'RackingPopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 523)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrintRacking)
        Me.Controls.Add(Me.txtQtyOnHand)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtQtyInRack)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvRackingTransactions)
        Me.Controls.Add(Me.cboPartDescription)
        Me.Controls.Add(Me.cboPartNumber)
        Me.Controls.Add(Me.lblItemNumber)
        Me.Name = "RackingPopup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Racking"
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRackingTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RackingTransactionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents lblItemNumber As System.Windows.Forms.Label
    Friend WithEvents dgvRackingTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents RackingTransactionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RackingTransactionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RackingTransactionTableTableAdapter
    Friend WithEvents RackingKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BinNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PiecesPerBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalPiecesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackingWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActivityDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreationDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtQtyInRack As System.Windows.Forms.TextBox
    Friend WithEvents txtQtyOnHand As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents cmdPrintRacking As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
End Class
