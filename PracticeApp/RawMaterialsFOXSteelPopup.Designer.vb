<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RawMaterialsFOXSteelPopup
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvFOXTable = New System.Windows.Forms.DataGridView
        Me.FOXNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ScheduledRMIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.FOXTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.dgvFOXTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(509, 231)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 30)
        Me.cmdExit.TabIndex = 6
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvFOXTable
        '
        Me.dgvFOXTable.AllowUserToAddRows = False
        Me.dgvFOXTable.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvFOXTable.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvFOXTable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFOXTable.AutoGenerateColumns = False
        Me.dgvFOXTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvFOXTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvFOXTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFOXTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FOXNumberDataGridViewTextBoxColumn, Me.RMIDDataGridViewTextBoxColumn, Me.ScheduledRMIDDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn})
        Me.dgvFOXTable.DataSource = Me.FOXTableBindingSource
        Me.dgvFOXTable.GridColor = System.Drawing.Color.Blue
        Me.dgvFOXTable.Location = New System.Drawing.Point(12, 12)
        Me.dgvFOXTable.Name = "dgvFOXTable"
        Me.dgvFOXTable.ReadOnly = True
        Me.dgvFOXTable.Size = New System.Drawing.Size(568, 213)
        Me.dgvFOXTable.TabIndex = 7
        '
        'FOXNumberDataGridViewTextBoxColumn
        '
        Me.FOXNumberDataGridViewTextBoxColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberDataGridViewTextBoxColumn.HeaderText = "FOX #"
        Me.FOXNumberDataGridViewTextBoxColumn.Name = "FOXNumberDataGridViewTextBoxColumn"
        Me.FOXNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.FOXNumberDataGridViewTextBoxColumn.Width = 80
        '
        'RMIDDataGridViewTextBoxColumn
        '
        Me.RMIDDataGridViewTextBoxColumn.DataPropertyName = "RMID"
        Me.RMIDDataGridViewTextBoxColumn.HeaderText = "Preferred Steel"
        Me.RMIDDataGridViewTextBoxColumn.Name = "RMIDDataGridViewTextBoxColumn"
        Me.RMIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.RMIDDataGridViewTextBoxColumn.Width = 190
        '
        'ScheduledRMIDDataGridViewTextBoxColumn
        '
        Me.ScheduledRMIDDataGridViewTextBoxColumn.DataPropertyName = "ScheduledRMID"
        Me.ScheduledRMIDDataGridViewTextBoxColumn.HeaderText = "Alternate Steel"
        Me.ScheduledRMIDDataGridViewTextBoxColumn.Name = "ScheduledRMIDDataGridViewTextBoxColumn"
        Me.ScheduledRMIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.ScheduledRMIDDataGridViewTextBoxColumn.Width = 190
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "Division"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.DivisionIDDataGridViewTextBoxColumn.Width = 60
        '
        'StatusDataGridViewTextBoxColumn
        '
        Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
        Me.StatusDataGridViewTextBoxColumn.HeaderText = "Status"
        Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
        Me.StatusDataGridViewTextBoxColumn.ReadOnly = True
        Me.StatusDataGridViewTextBoxColumn.Visible = False
        '
        'FOXTableBindingSource
        '
        Me.FOXTableBindingSource.DataMember = "FOXTable"
        Me.FOXTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FOXTableTableAdapter
        '
        Me.FOXTableTableAdapter.ClearBeforeFill = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 238)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(195, 23)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "ACTIVE FOXES ONLY"
        '
        'RawMaterialsFOXSteelPopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 273)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvFOXTable)
        Me.Controls.Add(Me.cmdExit)
        Me.Name = "RawMaterialsFOXSteelPopup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Steel on Active FOXES"
        CType(Me.dgvFOXTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvFOXTable As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents FOXTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FOXTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
    Friend WithEvents FOXNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScheduledRMIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
