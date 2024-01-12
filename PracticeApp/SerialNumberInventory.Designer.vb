<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SerialNumberInventory
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvSerializedParts = New System.Windows.Forms.DataGridView
        Me.DivisionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QOHColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvAssemblyHeaderTable = New System.Windows.Forms.DataGridView
        Me.AssemblyPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.AssemblyHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblyHeaderTableTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdExport = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdRunReport = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.dgvSerialLog = New System.Windows.Forms.DataGridView
        Me.AssemblyPartNumberColumnSL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerialNumberColumnSL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumnSL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalCostColumnSL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumnSL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildNumberColumnSL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblySerialLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AssemblySerialLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblySerialLogTableAdapter
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvSerializedParts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAssemblyHeaderTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssemblyHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSerialLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssemblySerialLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(38, 20)
        Me.FileToolStripMenuItem.Text = "File "
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem1})
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'dgvSerializedParts
        '
        Me.dgvSerializedParts.AllowUserToAddRows = False
        Me.dgvSerializedParts.AllowUserToDeleteRows = False
        Me.dgvSerializedParts.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSerializedParts.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSerializedParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSerializedParts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionColumn, Me.PartNumberColumn, Me.DescriptionColumn, Me.QOHColumn})
        Me.dgvSerializedParts.GridColor = System.Drawing.Color.Purple
        Me.dgvSerializedParts.Location = New System.Drawing.Point(302, 41)
        Me.dgvSerializedParts.Name = "dgvSerializedParts"
        Me.dgvSerializedParts.Size = New System.Drawing.Size(728, 704)
        Me.dgvSerializedParts.TabIndex = 1
        '
        'DivisionColumn
        '
        Me.DivisionColumn.HeaderText = "Division"
        Me.DivisionColumn.Name = "DivisionColumn"
        Me.DivisionColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PartNumberColumn.Width = 180
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        Me.DescriptionColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DescriptionColumn.Width = 250
        '
        'QOHColumn
        '
        Me.QOHColumn.HeaderText = "QOH"
        Me.QOHColumn.Name = "QOHColumn"
        Me.QOHColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.QOHColumn.Width = 150
        '
        'dgvAssemblyHeaderTable
        '
        Me.dgvAssemblyHeaderTable.AllowUserToAddRows = False
        Me.dgvAssemblyHeaderTable.AllowUserToDeleteRows = False
        Me.dgvAssemblyHeaderTable.AutoGenerateColumns = False
        Me.dgvAssemblyHeaderTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAssemblyHeaderTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAssemblyHeaderTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AssemblyPartNumberColumn, Me.AssemblyDescriptionColumn, Me.DivisionIDColumn})
        Me.dgvAssemblyHeaderTable.DataSource = Me.AssemblyHeaderTableBindingSource
        Me.dgvAssemblyHeaderTable.Location = New System.Drawing.Point(29, 499)
        Me.dgvAssemblyHeaderTable.Name = "dgvAssemblyHeaderTable"
        Me.dgvAssemblyHeaderTable.ReadOnly = True
        Me.dgvAssemblyHeaderTable.Size = New System.Drawing.Size(212, 143)
        Me.dgvAssemblyHeaderTable.TabIndex = 2
        Me.dgvAssemblyHeaderTable.Visible = False
        '
        'AssemblyPartNumberColumn
        '
        Me.AssemblyPartNumberColumn.DataPropertyName = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn.HeaderText = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn.Name = "AssemblyPartNumberColumn"
        Me.AssemblyPartNumberColumn.ReadOnly = True
        '
        'AssemblyDescriptionColumn
        '
        Me.AssemblyDescriptionColumn.DataPropertyName = "AssemblyDescription"
        Me.AssemblyDescriptionColumn.HeaderText = "AssemblyDescription"
        Me.AssemblyDescriptionColumn.Name = "AssemblyDescriptionColumn"
        Me.AssemblyDescriptionColumn.ReadOnly = True
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        '
        'AssemblyHeaderTableBindingSource
        '
        Me.AssemblyHeaderTableBindingSource.DataMember = "AssemblyHeaderTable"
        Me.AssemblyHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AssemblyHeaderTableTableAdapter
        '
        Me.AssemblyHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdExport)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.cmdRunReport)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(250, 165)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Run Report"
        '
        'cmdExport
        '
        Me.cmdExport.Location = New System.Drawing.Point(163, 107)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(71, 40)
        Me.cmdExport.TabIndex = 7
        Me.cmdExport.Text = "Export To Excel"
        Me.cmdExport.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(86, 46)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(148, 21)
        Me.cboDivisionID.TabIndex = 6
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdRunReport
        '
        Me.cmdRunReport.Location = New System.Drawing.Point(86, 107)
        Me.cmdRunReport.Name = "cmdRunReport"
        Me.cmdRunReport.Size = New System.Drawing.Size(71, 40)
        Me.cmdRunReport.TabIndex = 0
        Me.cmdRunReport.Text = "Run Report"
        Me.cmdRunReport.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(21, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 23)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Division"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Location = New System.Drawing.Point(882, 771)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 4
        Me.cmdClearAll.Text = "Clear"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 5
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'dgvSerialLog
        '
        Me.dgvSerialLog.AllowUserToAddRows = False
        Me.dgvSerialLog.AllowUserToDeleteRows = False
        Me.dgvSerialLog.AutoGenerateColumns = False
        Me.dgvSerialLog.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSerialLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSerialLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AssemblyPartNumberColumnSL, Me.SerialNumberColumnSL, Me.DivisionIDColumnSL, Me.TotalCostColumnSL, Me.StatusColumnSL, Me.BuildNumberColumnSL})
        Me.dgvSerialLog.DataSource = Me.AssemblySerialLogBindingSource
        Me.dgvSerialLog.Location = New System.Drawing.Point(29, 676)
        Me.dgvSerialLog.Name = "dgvSerialLog"
        Me.dgvSerialLog.ReadOnly = True
        Me.dgvSerialLog.Size = New System.Drawing.Size(211, 132)
        Me.dgvSerialLog.TabIndex = 6
        Me.dgvSerialLog.Visible = False
        '
        'AssemblyPartNumberColumnSL
        '
        Me.AssemblyPartNumberColumnSL.DataPropertyName = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumnSL.HeaderText = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumnSL.Name = "AssemblyPartNumberColumnSL"
        Me.AssemblyPartNumberColumnSL.ReadOnly = True
        '
        'SerialNumberColumnSL
        '
        Me.SerialNumberColumnSL.DataPropertyName = "SerialNumber"
        Me.SerialNumberColumnSL.HeaderText = "SerialNumber"
        Me.SerialNumberColumnSL.Name = "SerialNumberColumnSL"
        Me.SerialNumberColumnSL.ReadOnly = True
        '
        'DivisionIDColumnSL
        '
        Me.DivisionIDColumnSL.DataPropertyName = "DivisionID"
        Me.DivisionIDColumnSL.HeaderText = "DivisionID"
        Me.DivisionIDColumnSL.Name = "DivisionIDColumnSL"
        Me.DivisionIDColumnSL.ReadOnly = True
        '
        'TotalCostColumnSL
        '
        Me.TotalCostColumnSL.DataPropertyName = "TotalCost"
        Me.TotalCostColumnSL.HeaderText = "TotalCost"
        Me.TotalCostColumnSL.Name = "TotalCostColumnSL"
        Me.TotalCostColumnSL.ReadOnly = True
        '
        'StatusColumnSL
        '
        Me.StatusColumnSL.DataPropertyName = "Status"
        Me.StatusColumnSL.HeaderText = "Status"
        Me.StatusColumnSL.Name = "StatusColumnSL"
        Me.StatusColumnSL.ReadOnly = True
        '
        'BuildNumberColumnSL
        '
        Me.BuildNumberColumnSL.DataPropertyName = "BuildNumber"
        Me.BuildNumberColumnSL.HeaderText = "BuildNumber"
        Me.BuildNumberColumnSL.Name = "BuildNumberColumnSL"
        Me.BuildNumberColumnSL.ReadOnly = True
        '
        'AssemblySerialLogBindingSource
        '
        Me.AssemblySerialLogBindingSource.DataMember = "AssemblySerialLog"
        Me.AssemblySerialLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'AssemblySerialLogTableAdapter
        '
        Me.AssemblySerialLogTableAdapter.ClearBeforeFill = True
        '
        'SerialNumberInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.dgvSerialLog)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvAssemblyHeaderTable)
        Me.Controls.Add(Me.dgvSerializedParts)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "SerialNumberInventory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Serial Number Quantity Om Hand"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvSerializedParts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAssemblyHeaderTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssemblyHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSerialLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssemblySerialLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvSerializedParts As System.Windows.Forms.DataGridView
    Friend WithEvents dgvAssemblyHeaderTable As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents AssemblyHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AssemblyHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblyHeaderTableTableAdapter
    Friend WithEvents AssemblyPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssemblyDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdRunReport As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents dgvSerialLog As System.Windows.Forms.DataGridView
    Friend WithEvents AssemblySerialLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AssemblySerialLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblySerialLogTableAdapter
    Friend WithEvents AssemblyPartNumberColumnSL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNumberColumnSL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumnSL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCostColumnSL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumnSL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildNumberColumnSL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QOHColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdExport As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
