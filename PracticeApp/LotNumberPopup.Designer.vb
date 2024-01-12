<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LotNumberPopup
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvLotNumber = New System.Windows.Forms.DataGridView
        Me.LotNumberBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.LotNumberTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
        Me.LotNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvLotNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(209, 390)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 18
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvLotNumber
        '
        Me.dgvLotNumber.AllowUserToAddRows = False
        Me.dgvLotNumber.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvLotNumber.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLotNumber.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLotNumber.AutoGenerateColumns = False
        Me.dgvLotNumber.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvLotNumber.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvLotNumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLotNumber.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LotNumberColumn, Me.HeatNumberDataGridViewTextBoxColumn, Me.PartNumberDataGridViewTextBoxColumn})
        Me.dgvLotNumber.DataSource = Me.LotNumberBindingSource
        Me.dgvLotNumber.GridColor = System.Drawing.Color.Purple
        Me.dgvLotNumber.Location = New System.Drawing.Point(12, 12)
        Me.dgvLotNumber.MultiSelect = False
        Me.dgvLotNumber.Name = "dgvLotNumber"
        Me.dgvLotNumber.Size = New System.Drawing.Size(268, 372)
        Me.dgvLotNumber.TabIndex = 1
        Me.dgvLotNumber.TabStop = False
        '
        'LotNumberBindingSource
        '
        Me.LotNumberBindingSource.DataMember = "LotNumber"
        Me.LotNumberBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LotNumberTableAdapter
        '
        Me.LotNumberTableAdapter.ClearBeforeFill = True
        '
        'LotNumberColumn
        '
        Me.LotNumberColumn.DataPropertyName = "LotNumber"
        Me.LotNumberColumn.HeaderText = "Lot #"
        Me.LotNumberColumn.Name = "LotNumberColumn"
        '
        'HeatNumberDataGridViewTextBoxColumn
        '
        Me.HeatNumberDataGridViewTextBoxColumn.DataPropertyName = "HeatNumber"
        Me.HeatNumberDataGridViewTextBoxColumn.HeaderText = "Heat #"
        Me.HeatNumberDataGridViewTextBoxColumn.Name = "HeatNumberDataGridViewTextBoxColumn"
        '
        'PartNumberDataGridViewTextBoxColumn
        '
        Me.PartNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn.HeaderText = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn.Name = "PartNumberDataGridViewTextBoxColumn"
        Me.PartNumberDataGridViewTextBoxColumn.Visible = False
        '
        'LotNumberPopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 442)
        Me.Controls.Add(Me.dgvLotNumber)
        Me.Controls.Add(Me.cmdExit)
        Me.Name = "LotNumberPopup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corp Lot Numbers"
        CType(Me.dgvLotNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents LotNumberBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LotNumberTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
    Friend WithEvents dgvLotNumber As System.Windows.Forms.DataGridView
    Friend WithEvents LotNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
