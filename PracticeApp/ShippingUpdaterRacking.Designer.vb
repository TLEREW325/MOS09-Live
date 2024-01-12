<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShippingUpdaterRacking
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
        Me.dgvPickPulledLines = New System.Windows.Forms.DataGridView
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblPickTicketNumber = New System.Windows.Forms.Label
        Me.lblPartNumber = New System.Windows.Forms.Label
        Me.cmdAddBackToRack = New System.Windows.Forms.Button
        Me.PickListPulledLinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.PickListPulledLinesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListPulledLinesTableAdapter
        Me.PickListLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BinNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PiecesPerBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalPiecesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackingWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackingKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PickListHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvPickPulledLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PickListPulledLinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvPickPulledLines
        '
        Me.dgvPickPulledLines.AllowUserToAddRows = False
        Me.dgvPickPulledLines.AllowUserToDeleteRows = False
        Me.dgvPickPulledLines.AutoGenerateColumns = False
        Me.dgvPickPulledLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPickPulledLines.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPickPulledLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPickPulledLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PickListLineKeyColumn, Me.BinNumberColumn, Me.BoxQuantityColumn, Me.PiecesPerBoxColumn, Me.TotalPiecesColumn, Me.LotNumberColumn, Me.HeatNumberColumn, Me.RackingWeightColumn, Me.RackingKeyColumn, Me.PickListHeaderKeyColumn, Me.LineKeyColumn})
        Me.dgvPickPulledLines.DataSource = Me.PickListPulledLinesBindingSource
        Me.dgvPickPulledLines.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvPickPulledLines.Location = New System.Drawing.Point(12, 51)
        Me.dgvPickPulledLines.Name = "dgvPickPulledLines"
        Me.dgvPickPulledLines.ReadOnly = True
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvPickPulledLines.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPickPulledLines.Size = New System.Drawing.Size(668, 353)
        Me.dgvPickPulledLines.TabIndex = 0
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Enabled = False
        Me.cmdPrint.Location = New System.Drawing.Point(532, 422)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 46
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(609, 422)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 47
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 28)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Pick Ticket #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPickTicketNumber
        '
        Me.lblPickTicketNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPickTicketNumber.ForeColor = System.Drawing.Color.Blue
        Me.lblPickTicketNumber.Location = New System.Drawing.Point(114, 20)
        Me.lblPickTicketNumber.Name = "lblPickTicketNumber"
        Me.lblPickTicketNumber.Size = New System.Drawing.Size(217, 28)
        Me.lblPickTicketNumber.TabIndex = 49
        Me.lblPickTicketNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPartNumber
        '
        Me.lblPartNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartNumber.ForeColor = System.Drawing.Color.Blue
        Me.lblPartNumber.Location = New System.Drawing.Point(12, 428)
        Me.lblPartNumber.Name = "lblPartNumber"
        Me.lblPartNumber.Size = New System.Drawing.Size(373, 28)
        Me.lblPartNumber.TabIndex = 50
        Me.lblPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAddBackToRack
        '
        Me.cmdAddBackToRack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddBackToRack.ForeColor = System.Drawing.Color.Blue
        Me.cmdAddBackToRack.Location = New System.Drawing.Point(406, 422)
        Me.cmdAddBackToRack.Name = "cmdAddBackToRack"
        Me.cmdAddBackToRack.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddBackToRack.TabIndex = 51
        Me.cmdAddBackToRack.Text = "Add To Rack"
        Me.cmdAddBackToRack.UseVisualStyleBackColor = True
        '
        'PickListPulledLinesBindingSource
        '
        Me.PickListPulledLinesBindingSource.DataMember = "PickListPulledLines"
        Me.PickListPulledLinesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PickListPulledLinesTableAdapter
        '
        Me.PickListPulledLinesTableAdapter.ClearBeforeFill = True
        '
        'PickListLineKeyColumn
        '
        Me.PickListLineKeyColumn.DataPropertyName = "PickListLineKey"
        Me.PickListLineKeyColumn.HeaderText = "Line #"
        Me.PickListLineKeyColumn.Name = "PickListLineKeyColumn"
        Me.PickListLineKeyColumn.ReadOnly = True
        Me.PickListLineKeyColumn.Width = 50
        '
        'BinNumberColumn
        '
        Me.BinNumberColumn.DataPropertyName = "BinNumber"
        Me.BinNumberColumn.HeaderText = "Bin #"
        Me.BinNumberColumn.Name = "BinNumberColumn"
        Me.BinNumberColumn.ReadOnly = True
        Me.BinNumberColumn.Width = 80
        '
        'BoxQuantityColumn
        '
        Me.BoxQuantityColumn.DataPropertyName = "BoxQuantity"
        Me.BoxQuantityColumn.HeaderText = "Box Qty"
        Me.BoxQuantityColumn.Name = "BoxQuantityColumn"
        Me.BoxQuantityColumn.ReadOnly = True
        Me.BoxQuantityColumn.Width = 90
        '
        'PiecesPerBoxColumn
        '
        Me.PiecesPerBoxColumn.DataPropertyName = "PiecesPerBox"
        Me.PiecesPerBoxColumn.HeaderText = "Pieces/Box"
        Me.PiecesPerBoxColumn.Name = "PiecesPerBoxColumn"
        Me.PiecesPerBoxColumn.ReadOnly = True
        Me.PiecesPerBoxColumn.Width = 90
        '
        'TotalPiecesColumn
        '
        Me.TotalPiecesColumn.DataPropertyName = "TotalPieces"
        Me.TotalPiecesColumn.HeaderText = "Total Pieces"
        Me.TotalPiecesColumn.Name = "TotalPiecesColumn"
        Me.TotalPiecesColumn.ReadOnly = True
        Me.TotalPiecesColumn.Width = 90
        '
        'LotNumberColumn
        '
        Me.LotNumberColumn.DataPropertyName = "LotNumber"
        Me.LotNumberColumn.HeaderText = "Lot #"
        Me.LotNumberColumn.Name = "LotNumberColumn"
        Me.LotNumberColumn.ReadOnly = True
        '
        'HeatNumberColumn
        '
        Me.HeatNumberColumn.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumn.HeaderText = "Heat #"
        Me.HeatNumberColumn.Name = "HeatNumberColumn"
        Me.HeatNumberColumn.ReadOnly = True
        '
        'RackingWeightColumn
        '
        Me.RackingWeightColumn.DataPropertyName = "RackingWeight"
        Me.RackingWeightColumn.HeaderText = "Weight"
        Me.RackingWeightColumn.Name = "RackingWeightColumn"
        Me.RackingWeightColumn.ReadOnly = True
        '
        'RackingKeyColumn
        '
        Me.RackingKeyColumn.DataPropertyName = "RackingKey"
        Me.RackingKeyColumn.HeaderText = "RackingKey"
        Me.RackingKeyColumn.Name = "RackingKeyColumn"
        Me.RackingKeyColumn.ReadOnly = True
        Me.RackingKeyColumn.Visible = False
        '
        'PickListHeaderKeyColumn
        '
        Me.PickListHeaderKeyColumn.DataPropertyName = "PickListHeaderKey"
        Me.PickListHeaderKeyColumn.HeaderText = "PickListHeaderKey"
        Me.PickListHeaderKeyColumn.Name = "PickListHeaderKeyColumn"
        Me.PickListHeaderKeyColumn.ReadOnly = True
        Me.PickListHeaderKeyColumn.Visible = False
        '
        'LineKeyColumn
        '
        Me.LineKeyColumn.DataPropertyName = "LineKey"
        Me.LineKeyColumn.HeaderText = "LineKey"
        Me.LineKeyColumn.Name = "LineKeyColumn"
        Me.LineKeyColumn.ReadOnly = True
        Me.LineKeyColumn.Visible = False
        '
        'ShippingUpdaterRacking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 473)
        Me.Controls.Add(Me.cmdAddBackToRack)
        Me.Controls.Add(Me.lblPartNumber)
        Me.Controls.Add(Me.lblPickTicketNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvPickPulledLines)
        Me.Name = "ShippingUpdaterRacking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Racking"
        CType(Me.dgvPickPulledLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PickListPulledLinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvPickPulledLines As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents PickListPulledLinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PickListPulledLinesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListPulledLinesTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPickTicketNumber As System.Windows.Forms.Label
    Friend WithEvents lblPartNumber As System.Windows.Forms.Label
    Friend WithEvents cmdAddBackToRack As System.Windows.Forms.Button
    Friend WithEvents PickListLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BinNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PiecesPerBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalPiecesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackingWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackingKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickListHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
