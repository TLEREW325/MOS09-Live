<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MachinePopup
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
        Me.dgvMachineTable = New System.Windows.Forms.DataGridView
        Me.MachineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.MachineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.MachineTableTableAdapter
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MachineIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MachineClassDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MachineCostPerHourDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaxPiecesPerHourDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MinDiameterDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaxDiameterDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MinLengthDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaxLengthDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TonnageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvMachineTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MachineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvMachineTable
        '
        Me.dgvMachineTable.AllowUserToAddRows = False
        Me.dgvMachineTable.AllowUserToDeleteRows = False
        Me.dgvMachineTable.AutoGenerateColumns = False
        Me.dgvMachineTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvMachineTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMachineTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MachineIDDataGridViewTextBoxColumn, Me.DescriptionDataGridViewTextBoxColumn, Me.MachineClassDataGridViewTextBoxColumn, Me.MachineCostPerHourDataGridViewTextBoxColumn, Me.MaxPiecesPerHourDataGridViewTextBoxColumn, Me.MinDiameterDataGridViewTextBoxColumn, Me.MaxDiameterDataGridViewTextBoxColumn, Me.MinLengthDataGridViewTextBoxColumn, Me.MaxLengthDataGridViewTextBoxColumn, Me.TonnageDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn})
        Me.dgvMachineTable.DataSource = Me.MachineTableBindingSource
        Me.dgvMachineTable.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvMachineTable.Location = New System.Drawing.Point(12, 12)
        Me.dgvMachineTable.Name = "dgvMachineTable"
        Me.dgvMachineTable.ReadOnly = True
        Me.dgvMachineTable.Size = New System.Drawing.Size(568, 295)
        Me.dgvMachineTable.TabIndex = 0
        '
        'MachineTableBindingSource
        '
        Me.MachineTableBindingSource.DataMember = "MachineTable"
        Me.MachineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MachineTableTableAdapter
        '
        Me.MachineTableTableAdapter.ClearBeforeFill = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(509, 321)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 1
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'MachineIDDataGridViewTextBoxColumn
        '
        Me.MachineIDDataGridViewTextBoxColumn.DataPropertyName = "MachineID"
        Me.MachineIDDataGridViewTextBoxColumn.HeaderText = "Machine ID"
        Me.MachineIDDataGridViewTextBoxColumn.Name = "MachineIDDataGridViewTextBoxColumn"
        Me.MachineIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DescriptionDataGridViewTextBoxColumn
        '
        Me.DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        Me.DescriptionDataGridViewTextBoxColumn.ReadOnly = True
        Me.DescriptionDataGridViewTextBoxColumn.Width = 150
        '
        'MachineClassDataGridViewTextBoxColumn
        '
        Me.MachineClassDataGridViewTextBoxColumn.DataPropertyName = "MachineClass"
        Me.MachineClassDataGridViewTextBoxColumn.HeaderText = "Machine Class"
        Me.MachineClassDataGridViewTextBoxColumn.Name = "MachineClassDataGridViewTextBoxColumn"
        Me.MachineClassDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MachineCostPerHourDataGridViewTextBoxColumn
        '
        Me.MachineCostPerHourDataGridViewTextBoxColumn.DataPropertyName = "MachineCostPerHour"
        Me.MachineCostPerHourDataGridViewTextBoxColumn.HeaderText = "Machine Cost Per Hour"
        Me.MachineCostPerHourDataGridViewTextBoxColumn.Name = "MachineCostPerHourDataGridViewTextBoxColumn"
        Me.MachineCostPerHourDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MaxPiecesPerHourDataGridViewTextBoxColumn
        '
        Me.MaxPiecesPerHourDataGridViewTextBoxColumn.DataPropertyName = "MaxPiecesPerHour"
        Me.MaxPiecesPerHourDataGridViewTextBoxColumn.HeaderText = "Max Pieces Per Hour"
        Me.MaxPiecesPerHourDataGridViewTextBoxColumn.Name = "MaxPiecesPerHourDataGridViewTextBoxColumn"
        Me.MaxPiecesPerHourDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MinDiameterDataGridViewTextBoxColumn
        '
        Me.MinDiameterDataGridViewTextBoxColumn.DataPropertyName = "MinDiameter"
        Me.MinDiameterDataGridViewTextBoxColumn.HeaderText = "Min Diameter"
        Me.MinDiameterDataGridViewTextBoxColumn.Name = "MinDiameterDataGridViewTextBoxColumn"
        Me.MinDiameterDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MaxDiameterDataGridViewTextBoxColumn
        '
        Me.MaxDiameterDataGridViewTextBoxColumn.DataPropertyName = "MaxDiameter"
        Me.MaxDiameterDataGridViewTextBoxColumn.HeaderText = "Max Diameter"
        Me.MaxDiameterDataGridViewTextBoxColumn.Name = "MaxDiameterDataGridViewTextBoxColumn"
        Me.MaxDiameterDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MinLengthDataGridViewTextBoxColumn
        '
        Me.MinLengthDataGridViewTextBoxColumn.DataPropertyName = "MinLength"
        Me.MinLengthDataGridViewTextBoxColumn.HeaderText = "Min Length"
        Me.MinLengthDataGridViewTextBoxColumn.Name = "MinLengthDataGridViewTextBoxColumn"
        Me.MinLengthDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MaxLengthDataGridViewTextBoxColumn
        '
        Me.MaxLengthDataGridViewTextBoxColumn.DataPropertyName = "MaxLength"
        Me.MaxLengthDataGridViewTextBoxColumn.HeaderText = "Max Length"
        Me.MaxLengthDataGridViewTextBoxColumn.Name = "MaxLengthDataGridViewTextBoxColumn"
        Me.MaxLengthDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TonnageDataGridViewTextBoxColumn
        '
        Me.TonnageDataGridViewTextBoxColumn.DataPropertyName = "Tonnage"
        Me.TonnageDataGridViewTextBoxColumn.HeaderText = "Tonnage"
        Me.TonnageDataGridViewTextBoxColumn.Name = "TonnageDataGridViewTextBoxColumn"
        Me.TonnageDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.DivisionIDDataGridViewTextBoxColumn.Visible = False
        '
        'MachinePopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 373)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvMachineTable)
        Me.Name = "MachinePopup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Machine List"
        CType(Me.dgvMachineTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MachineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvMachineTable As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents MachineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MachineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.MachineTableTableAdapter
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents MachineIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MachineClassDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MachineCostPerHourDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaxPiecesPerHourDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinDiameterDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaxDiameterDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinLengthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaxLengthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TonnageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
