<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryRackingEmptyBins
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvEmptyBinsSLC = New System.Windows.Forms.DataGridView
        Me.BinNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BarWeightOpenDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmptyBinQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.EmptyBinQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmptyBinQueryTableAdapter
        Me.dgvEmptyBinsTWD = New System.Windows.Forms.DataGridView
        Me.EmptyBinQueryTWDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmptyBinQueryTWDTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmptyBinQueryTWDTableAdapter
        Me.BinNumberColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaxBarWeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackPositionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalBoxesInRackDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvEmptyBinsSLC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptyBinQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEmptyBinsTWD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptyBinQueryTWDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(165, 466)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 28
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvEmptyBinsSLC
        '
        Me.dgvEmptyBinsSLC.AllowUserToAddRows = False
        Me.dgvEmptyBinsSLC.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvEmptyBinsSLC.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEmptyBinsSLC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEmptyBinsSLC.AutoGenerateColumns = False
        Me.dgvEmptyBinsSLC.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvEmptyBinsSLC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvEmptyBinsSLC.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvEmptyBinsSLC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmptyBinsSLC.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BinNumberDataGridViewTextBoxColumn, Me.BarWeightOpenDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn})
        Me.dgvEmptyBinsSLC.DataSource = Me.EmptyBinQueryBindingSource
        Me.dgvEmptyBinsSLC.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dgvEmptyBinsSLC.Location = New System.Drawing.Point(12, 12)
        Me.dgvEmptyBinsSLC.Name = "dgvEmptyBinsSLC"
        Me.dgvEmptyBinsSLC.ReadOnly = True
        Me.dgvEmptyBinsSLC.Size = New System.Drawing.Size(224, 448)
        Me.dgvEmptyBinsSLC.TabIndex = 29
        '
        'BinNumberDataGridViewTextBoxColumn
        '
        Me.BinNumberDataGridViewTextBoxColumn.DataPropertyName = "BinNumber"
        Me.BinNumberDataGridViewTextBoxColumn.HeaderText = "Rack #"
        Me.BinNumberDataGridViewTextBoxColumn.Name = "BinNumberDataGridViewTextBoxColumn"
        Me.BinNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.BinNumberDataGridViewTextBoxColumn.Width = 85
        '
        'BarWeightOpenDataGridViewTextBoxColumn
        '
        Me.BarWeightOpenDataGridViewTextBoxColumn.DataPropertyName = "BarWeightOpen"
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        Me.BarWeightOpenDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.BarWeightOpenDataGridViewTextBoxColumn.HeaderText = "Weight Open"
        Me.BarWeightOpenDataGridViewTextBoxColumn.Name = "BarWeightOpenDataGridViewTextBoxColumn"
        Me.BarWeightOpenDataGridViewTextBoxColumn.ReadOnly = True
        Me.BarWeightOpenDataGridViewTextBoxColumn.Width = 90
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.DivisionIDDataGridViewTextBoxColumn.Visible = False
        '
        'EmptyBinQueryBindingSource
        '
        Me.EmptyBinQueryBindingSource.DataMember = "EmptyBinQuery"
        Me.EmptyBinQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EmptyBinQueryTableAdapter
        '
        Me.EmptyBinQueryTableAdapter.ClearBeforeFill = True
        '
        'dgvEmptyBinsTWD
        '
        Me.dgvEmptyBinsTWD.AllowUserToAddRows = False
        Me.dgvEmptyBinsTWD.AllowUserToDeleteRows = False
        Me.dgvEmptyBinsTWD.AutoGenerateColumns = False
        Me.dgvEmptyBinsTWD.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvEmptyBinsTWD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmptyBinsTWD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BinNumberColumn1, Me.MaxBarWeightDataGridViewTextBoxColumn, Me.RackPositionDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn1, Me.TotalBoxesInRackDataGridViewTextBoxColumn})
        Me.dgvEmptyBinsTWD.DataSource = Me.EmptyBinQueryTWDBindingSource
        Me.dgvEmptyBinsTWD.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvEmptyBinsTWD.Location = New System.Drawing.Point(12, 12)
        Me.dgvEmptyBinsTWD.Name = "dgvEmptyBinsTWD"
        Me.dgvEmptyBinsTWD.ReadOnly = True
        Me.dgvEmptyBinsTWD.Size = New System.Drawing.Size(224, 448)
        Me.dgvEmptyBinsTWD.TabIndex = 30
        '
        'EmptyBinQueryTWDBindingSource
        '
        Me.EmptyBinQueryTWDBindingSource.DataMember = "EmptyBinQueryTWD"
        Me.EmptyBinQueryTWDBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'EmptyBinQueryTWDTableAdapter
        '
        Me.EmptyBinQueryTWDTableAdapter.ClearBeforeFill = True
        '
        'BinNumberColumn1
        '
        Me.BinNumberColumn1.DataPropertyName = "BinNumber"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BinNumberColumn1.DefaultCellStyle = DataGridViewCellStyle3
        Me.BinNumberColumn1.HeaderText = "Rack #"
        Me.BinNumberColumn1.Name = "BinNumberColumn1"
        Me.BinNumberColumn1.ReadOnly = True
        Me.BinNumberColumn1.Width = 90
        '
        'MaxBarWeightDataGridViewTextBoxColumn
        '
        Me.MaxBarWeightDataGridViewTextBoxColumn.DataPropertyName = "MaxBarWeight"
        Me.MaxBarWeightDataGridViewTextBoxColumn.HeaderText = "MAX Bar Weight"
        Me.MaxBarWeightDataGridViewTextBoxColumn.Name = "MaxBarWeightDataGridViewTextBoxColumn"
        Me.MaxBarWeightDataGridViewTextBoxColumn.ReadOnly = True
        Me.MaxBarWeightDataGridViewTextBoxColumn.Width = 90
        '
        'RackPositionDataGridViewTextBoxColumn
        '
        Me.RackPositionDataGridViewTextBoxColumn.DataPropertyName = "RackPosition"
        Me.RackPositionDataGridViewTextBoxColumn.HeaderText = "RackPosition"
        Me.RackPositionDataGridViewTextBoxColumn.Name = "RackPositionDataGridViewTextBoxColumn"
        Me.RackPositionDataGridViewTextBoxColumn.ReadOnly = True
        Me.RackPositionDataGridViewTextBoxColumn.Visible = False
        '
        'DivisionIDDataGridViewTextBoxColumn1
        '
        Me.DivisionIDDataGridViewTextBoxColumn1.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn1.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn1.Name = "DivisionIDDataGridViewTextBoxColumn1"
        Me.DivisionIDDataGridViewTextBoxColumn1.ReadOnly = True
        Me.DivisionIDDataGridViewTextBoxColumn1.Visible = False
        '
        'TotalBoxesInRackDataGridViewTextBoxColumn
        '
        Me.TotalBoxesInRackDataGridViewTextBoxColumn.DataPropertyName = "TotalBoxesInRack"
        Me.TotalBoxesInRackDataGridViewTextBoxColumn.HeaderText = "TotalBoxesInRack"
        Me.TotalBoxesInRackDataGridViewTextBoxColumn.Name = "TotalBoxesInRackDataGridViewTextBoxColumn"
        Me.TotalBoxesInRackDataGridViewTextBoxColumn.ReadOnly = True
        Me.TotalBoxesInRackDataGridViewTextBoxColumn.Visible = False
        '
        'InventoryRackingEmptyBins
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(248, 518)
        Me.Controls.Add(Me.dgvEmptyBinsTWD)
        Me.Controls.Add(Me.dgvEmptyBinsSLC)
        Me.Controls.Add(Me.cmdExit)
        Me.Name = "InventoryRackingEmptyBins"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Empty Racks"
        CType(Me.dgvEmptyBinsSLC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptyBinQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEmptyBinsTWD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptyBinQueryTWDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvEmptyBinsSLC As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents EmptyBinQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmptyBinQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmptyBinQueryTableAdapter
    Friend WithEvents BinNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BarWeightOpenDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvEmptyBinsTWD As System.Windows.Forms.DataGridView
    Friend WithEvents EmptyBinQueryTWDBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmptyBinQueryTWDTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmptyBinQueryTWDTableAdapter
    Friend WithEvents BinNumberColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaxBarWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackPositionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalBoxesInRackDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
