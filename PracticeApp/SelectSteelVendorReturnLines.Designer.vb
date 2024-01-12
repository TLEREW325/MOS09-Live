<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectSteelVendorReturnLines
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdAddLines = New System.Windows.Forms.Button
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.dgvSteelReturnLines = New System.Windows.Forms.DataGridView
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.SteelReturnLineQuery2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SteelReturnLineQuery2TableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReturnLineQuery2TableAdapter
        Me.SelectedColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.SteelReturnNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReturnLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLDebitAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLCreditAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvSteelReturnLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelReturnLineQuery2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(612, 321)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(70, 40)
        Me.cmdExit.TabIndex = 1
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdAddLines
        '
        Me.cmdAddLines.Location = New System.Drawing.Point(536, 321)
        Me.cmdAddLines.Name = "cmdAddLines"
        Me.cmdAddLines.Size = New System.Drawing.Size(70, 40)
        Me.cmdAddLines.TabIndex = 2
        Me.cmdAddLines.Text = "Add Lines"
        Me.cmdAddLines.UseVisualStyleBackColor = True
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Location = New System.Drawing.Point(12, 321)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(70, 40)
        Me.cmdSelectAll.TabIndex = 3
        Me.cmdSelectAll.Text = "Select All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Location = New System.Drawing.Point(88, 321)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(70, 40)
        Me.cmdClearAll.TabIndex = 4
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'dgvSteelReturnLines
        '
        Me.dgvSteelReturnLines.AllowUserToAddRows = False
        Me.dgvSteelReturnLines.AutoGenerateColumns = False
        Me.dgvSteelReturnLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelReturnLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelReturnLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectedColumn, Me.SteelReturnNumberColumn, Me.SteelReturnLineColumn, Me.RMIDColumn, Me.ReturnQuantityColumn, Me.UnitCostColumn, Me.ExtendedCostColumn, Me.ReturnDateColumn, Me.LineCommentColumn, Me.DivisionIDColumn, Me.LineStatusColumn, Me.GLDebitAccountColumn, Me.GLCreditAccountColumn})
        Me.dgvSteelReturnLines.DataSource = Me.SteelReturnLineQuery2BindingSource
        Me.dgvSteelReturnLines.GridColor = System.Drawing.Color.Maroon
        Me.dgvSteelReturnLines.Location = New System.Drawing.Point(12, 12)
        Me.dgvSteelReturnLines.Name = "dgvSteelReturnLines"
        Me.dgvSteelReturnLines.Size = New System.Drawing.Size(670, 303)
        Me.dgvSteelReturnLines.TabIndex = 5
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SteelReturnLineQuery2BindingSource
        '
        Me.SteelReturnLineQuery2BindingSource.DataMember = "SteelReturnLineQuery2"
        Me.SteelReturnLineQuery2BindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SteelReturnLineQuery2TableAdapter
        '
        Me.SteelReturnLineQuery2TableAdapter.ClearBeforeFill = True
        '
        'SelectedColumn
        '
        Me.SelectedColumn.FalseValue = "UNSELECTED"
        Me.SelectedColumn.HeaderText = "Select?"
        Me.SelectedColumn.Name = "SelectedColumn"
        Me.SelectedColumn.TrueValue = "SELECTED"
        Me.SelectedColumn.Width = 60
        '
        'SteelReturnNumberColumn
        '
        Me.SteelReturnNumberColumn.DataPropertyName = "SteelReturnNumber"
        Me.SteelReturnNumberColumn.HeaderText = "Return #"
        Me.SteelReturnNumberColumn.Name = "SteelReturnNumberColumn"
        Me.SteelReturnNumberColumn.Width = 80
        '
        'SteelReturnLineColumn
        '
        Me.SteelReturnLineColumn.DataPropertyName = "SteelReturnLine"
        Me.SteelReturnLineColumn.HeaderText = "Line #"
        Me.SteelReturnLineColumn.Name = "SteelReturnLineColumn"
        Me.SteelReturnLineColumn.Width = 65
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        '
        'ReturnQuantityColumn
        '
        Me.ReturnQuantityColumn.DataPropertyName = "ReturnQuantity"
        Me.ReturnQuantityColumn.HeaderText = "Quantity"
        Me.ReturnQuantityColumn.Name = "ReturnQuantityColumn"
        Me.ReturnQuantityColumn.Width = 80
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.Width = 80
        '
        'ExtendedCostColumn
        '
        Me.ExtendedCostColumn.DataPropertyName = "ExtendedCost"
        Me.ExtendedCostColumn.HeaderText = "Ext. Cost"
        Me.ExtendedCostColumn.Name = "ExtendedCostColumn"
        Me.ExtendedCostColumn.Width = 80
        '
        'ReturnDateColumn
        '
        Me.ReturnDateColumn.DataPropertyName = "ReturnDate"
        Me.ReturnDateColumn.HeaderText = "Date"
        Me.ReturnDateColumn.Name = "ReturnDateColumn"
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "LineStatus"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.Visible = False
        '
        'GLDebitAccountColumn
        '
        Me.GLDebitAccountColumn.DataPropertyName = "GLDebitAccount"
        Me.GLDebitAccountColumn.HeaderText = "GLDebitAccount"
        Me.GLDebitAccountColumn.Name = "GLDebitAccountColumn"
        Me.GLDebitAccountColumn.Visible = False
        '
        'GLCreditAccountColumn
        '
        Me.GLCreditAccountColumn.DataPropertyName = "GLCreditAccount"
        Me.GLCreditAccountColumn.HeaderText = "GLCreditAccount"
        Me.GLCreditAccountColumn.Name = "GLCreditAccountColumn"
        Me.GLCreditAccountColumn.Visible = False
        '
        'SelectSteelVendorReturnLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 375)
        Me.Controls.Add(Me.dgvSteelReturnLines)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.cmdAddLines)
        Me.Controls.Add(Me.cmdExit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "SelectSteelVendorReturnLines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Steel Vendor Return Lines"
        CType(Me.dgvSteelReturnLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelReturnLineQuery2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdAddLines As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents dgvSteelReturnLines As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents SteelReturnLineQuery2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelReturnLineQuery2TableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReturnLineQuery2TableAdapter
    Friend WithEvents SelectedColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SteelReturnNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReturnLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDebitAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCreditAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
