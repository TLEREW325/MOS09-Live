<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LiftTruckRacking
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmdLookupByRack = New System.Windows.Forms.Button
        Me.cmdAddToRack = New System.Windows.Forms.Button
        Me.cmdLookupByPart = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.gpxLookupByRack = New System.Windows.Forms.GroupBox
        Me.cmdAddToRack2 = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmdSubtractFromRack2 = New System.Windows.Forms.Button
        Me.txtEditPieces2 = New System.Windows.Forms.TextBox
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.cmdDeleteRack = New System.Windows.Forms.Button
        Me.dgvRackLookup = New System.Windows.Forms.DataGridView
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PiecesPerBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalPiecesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackingWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BinNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackingKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActivityDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreationDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackingTransactionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtRackNumber = New System.Windows.Forms.TextBox
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxLookupByPart = New System.Windows.Forms.GroupBox
        Me.cmdAddToSelectedRack = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdRemoveFromSelectedRack = New System.Windows.Forms.Button
        Me.txtEditPieces = New System.Windows.Forms.TextBox
        Me.txtQOH = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdDeletedLinePart = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTotalPiecesInRack = New System.Windows.Forms.TextBox
        Me.dgvPartLookup = New System.Windows.Forms.DataGridView
        Me.BinNumberColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxQuantityColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PiecesPerBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalPiecesColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackingWeightColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActivityDateColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackingKeyColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPartNumberLookup = New System.Windows.Forms.TextBox
        Me.gpxAddToRack = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtHeatNumber = New System.Windows.Forms.TextBox
        Me.txtPartDescription = New System.Windows.Forms.TextBox
        Me.cmdAddToRackEntry = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtAddBinNumber = New System.Windows.Forms.TextBox
        Me.txtTotalWeight = New System.Windows.Forms.TextBox
        Me.txtTotalPieces = New System.Windows.Forms.TextBox
        Me.txtNumberOfPieces = New System.Windows.Forms.TextBox
        Me.txtNumberOfBoxes = New System.Windows.Forms.TextBox
        Me.txtPartNumber = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtLotNumber = New System.Windows.Forms.TextBox
        Me.cmdClearFields = New System.Windows.Forms.Button
        Me.txtUpdateDatagrid = New System.Windows.Forms.TextBox
        Me.cmdLookupByOrder = New System.Windows.Forms.Button
        Me.gpxLookupByOrder = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdAddToRack3 = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtRemoveFromRack3 = New System.Windows.Forms.Button
        Me.txtEditPieces3 = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmdDeleteLineFromOrder = New System.Windows.Forms.Button
        Me.dgvRackingByOrder = New System.Windows.Forms.DataGridView
        Me.RackingKeyColumnOE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BinNumberColumnOE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumnOE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumnOE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxQuantityColumnOE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PiecesPerBoxColumnOE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalPiecesColumnOE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackingWeightColumnOE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumnOE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberColumnOE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActivityDateColumnOE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumnOE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreationDateColumnOE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PickTicketColumnOE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PickDateColumnOE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AddedByColumnOE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumnOE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvOrderLines = New System.Windows.Forms.DataGridView
        Me.PickListHeaderKeyColumnOL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PickListLineKeyColumnOL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemIDColumnOL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumnOL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumnOL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumnOL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PickListLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtOrderNumber = New System.Windows.Forms.TextBox
        Me.RackingTransactionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RackingTransactionTableTableAdapter
        Me.PickListLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListLineTableTableAdapter
        Me.gpxLookupByRack.SuspendLayout()
        CType(Me.dgvRackLookup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RackingTransactionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxLookupByPart.SuspendLayout()
        CType(Me.dgvPartLookup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxAddToRack.SuspendLayout()
        Me.gpxLookupByOrder.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvRackingByOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOrderLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PickListLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdLookupByRack
        '
        Me.cmdLookupByRack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLookupByRack.Location = New System.Drawing.Point(12, 31)
        Me.cmdLookupByRack.Name = "cmdLookupByRack"
        Me.cmdLookupByRack.Size = New System.Drawing.Size(160, 70)
        Me.cmdLookupByRack.TabIndex = 0
        Me.cmdLookupByRack.Text = "Lookup By Rack"
        Me.cmdLookupByRack.UseVisualStyleBackColor = True
        '
        'cmdAddToRack
        '
        Me.cmdAddToRack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddToRack.Location = New System.Drawing.Point(12, 319)
        Me.cmdAddToRack.Name = "cmdAddToRack"
        Me.cmdAddToRack.Size = New System.Drawing.Size(160, 70)
        Me.cmdAddToRack.TabIndex = 1
        Me.cmdAddToRack.Text = "Add to Rack"
        Me.cmdAddToRack.UseVisualStyleBackColor = True
        '
        'cmdLookupByPart
        '
        Me.cmdLookupByPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLookupByPart.Location = New System.Drawing.Point(12, 127)
        Me.cmdLookupByPart.Name = "cmdLookupByPart"
        Me.cmdLookupByPart.Size = New System.Drawing.Size(160, 70)
        Me.cmdLookupByPart.TabIndex = 2
        Me.cmdLookupByPart.Text = "Lookup By Part"
        Me.cmdLookupByPart.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(12, 415)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(160, 70)
        Me.cmdClear.TabIndex = 4
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'gpxLookupByRack
        '
        Me.gpxLookupByRack.Controls.Add(Me.cmdAddToRack2)
        Me.gpxLookupByRack.Controls.Add(Me.Label17)
        Me.gpxLookupByRack.Controls.Add(Me.cmdSubtractFromRack2)
        Me.gpxLookupByRack.Controls.Add(Me.txtEditPieces2)
        Me.gpxLookupByRack.Controls.Add(Me.cmdDeleteLine)
        Me.gpxLookupByRack.Controls.Add(Me.cmdDeleteRack)
        Me.gpxLookupByRack.Controls.Add(Me.dgvRackLookup)
        Me.gpxLookupByRack.Controls.Add(Me.Label1)
        Me.gpxLookupByRack.Controls.Add(Me.txtRackNumber)
        Me.gpxLookupByRack.Location = New System.Drawing.Point(190, 0)
        Me.gpxLookupByRack.Name = "gpxLookupByRack"
        Me.gpxLookupByRack.Size = New System.Drawing.Size(1080, 712)
        Me.gpxLookupByRack.TabIndex = 5
        Me.gpxLookupByRack.TabStop = False
        '
        'cmdAddToRack2
        '
        Me.cmdAddToRack2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddToRack2.ForeColor = System.Drawing.Color.Blue
        Me.cmdAddToRack2.Location = New System.Drawing.Point(822, 19)
        Me.cmdAddToRack2.Name = "cmdAddToRack2"
        Me.cmdAddToRack2.Size = New System.Drawing.Size(119, 56)
        Me.cmdAddToRack2.TabIndex = 17
        Me.cmdAddToRack2.Text = "Add Pieces To Rack"
        Me.cmdAddToRack2.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(655, 24)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(161, 20)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "# of Pieces"
        '
        'cmdSubtractFromRack2
        '
        Me.cmdSubtractFromRack2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSubtractFromRack2.ForeColor = System.Drawing.Color.Blue
        Me.cmdSubtractFromRack2.Location = New System.Drawing.Point(947, 19)
        Me.cmdSubtractFromRack2.Name = "cmdSubtractFromRack2"
        Me.cmdSubtractFromRack2.Size = New System.Drawing.Size(119, 56)
        Me.cmdSubtractFromRack2.TabIndex = 15
        Me.cmdSubtractFromRack2.Text = "Subtract Pieces  From  Rack"
        Me.cmdSubtractFromRack2.UseVisualStyleBackColor = True
        '
        'txtEditPieces2
        '
        Me.txtEditPieces2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEditPieces2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEditPieces2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditPieces2.Location = New System.Drawing.Point(655, 49)
        Me.txtEditPieces2.Name = "txtEditPieces2"
        Me.txtEditPieces2.Size = New System.Drawing.Size(161, 26)
        Me.txtEditPieces2.TabIndex = 14
        Me.txtEditPieces2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteLine.Location = New System.Drawing.Point(392, 17)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(119, 56)
        Me.cmdDeleteLine.TabIndex = 4
        Me.cmdDeleteLine.Text = "Delete Selected Line"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'cmdDeleteRack
        '
        Me.cmdDeleteRack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteRack.Location = New System.Drawing.Point(267, 17)
        Me.cmdDeleteRack.Name = "cmdDeleteRack"
        Me.cmdDeleteRack.Size = New System.Drawing.Size(119, 56)
        Me.cmdDeleteRack.TabIndex = 3
        Me.cmdDeleteRack.Text = "Delete Entire Rack"
        Me.cmdDeleteRack.UseVisualStyleBackColor = True
        '
        'dgvRackLookup
        '
        Me.dgvRackLookup.AllowUserToAddRows = False
        Me.dgvRackLookup.AllowUserToDeleteRows = False
        Me.dgvRackLookup.AllowUserToOrderColumns = True
        Me.dgvRackLookup.AutoGenerateColumns = False
        Me.dgvRackLookup.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRackLookup.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRackLookup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRackLookup.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartNumberColumn, Me.BoxQuantityColumn, Me.PiecesPerBoxColumn, Me.TotalPiecesColumn, Me.LotNumberColumn, Me.HeatNumberColumn, Me.RackingWeightColumn, Me.BinNumberColumn, Me.RackingKeyColumn, Me.PartDescriptionColumn, Me.ActivityDateColumn, Me.DivisionIDColumn, Me.CreationDateColumn})
        Me.dgvRackLookup.DataSource = Me.RackingTransactionTableBindingSource
        Me.dgvRackLookup.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvRackLookup.Location = New System.Drawing.Point(15, 85)
        Me.dgvRackLookup.MultiSelect = False
        Me.dgvRackLookup.Name = "dgvRackLookup"
        Me.dgvRackLookup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRackLookup.Size = New System.Drawing.Size(1051, 553)
        Me.dgvRackLookup.TabIndex = 2
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartNumberColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        Me.PartNumberColumn.Width = 260
        '
        'BoxQuantityColumn
        '
        Me.BoxQuantityColumn.DataPropertyName = "BoxQuantity"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxQuantityColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.BoxQuantityColumn.HeaderText = "# Boxes"
        Me.BoxQuantityColumn.Name = "BoxQuantityColumn"
        Me.BoxQuantityColumn.Width = 110
        '
        'PiecesPerBoxColumn
        '
        Me.PiecesPerBoxColumn.DataPropertyName = "PiecesPerBox"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PiecesPerBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.PiecesPerBoxColumn.HeaderText = "Pcs/Box"
        Me.PiecesPerBoxColumn.Name = "PiecesPerBoxColumn"
        Me.PiecesPerBoxColumn.Width = 110
        '
        'TotalPiecesColumn
        '
        Me.TotalPiecesColumn.DataPropertyName = "TotalPieces"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalPiecesColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.TotalPiecesColumn.HeaderText = "Total"
        Me.TotalPiecesColumn.Name = "TotalPiecesColumn"
        Me.TotalPiecesColumn.ReadOnly = True
        '
        'LotNumberColumn
        '
        Me.LotNumberColumn.DataPropertyName = "LotNumber"
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LotNumberColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.LotNumberColumn.HeaderText = "Lot #"
        Me.LotNumberColumn.Name = "LotNumberColumn"
        Me.LotNumberColumn.ReadOnly = True
        Me.LotNumberColumn.Width = 160
        '
        'HeatNumberColumn
        '
        Me.HeatNumberColumn.DataPropertyName = "HeatNumber"
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeatNumberColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.HeatNumberColumn.HeaderText = "Heat #"
        Me.HeatNumberColumn.Name = "HeatNumberColumn"
        Me.HeatNumberColumn.Width = 160
        '
        'RackingWeightColumn
        '
        Me.RackingWeightColumn.DataPropertyName = "RackingWeight"
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RackingWeightColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.RackingWeightColumn.HeaderText = "Weight"
        Me.RackingWeightColumn.Name = "RackingWeightColumn"
        Me.RackingWeightColumn.ReadOnly = True
        '
        'BinNumberColumn
        '
        Me.BinNumberColumn.DataPropertyName = "BinNumber"
        Me.BinNumberColumn.HeaderText = "BinNumber"
        Me.BinNumberColumn.Name = "BinNumberColumn"
        Me.BinNumberColumn.Visible = False
        '
        'RackingKeyColumn
        '
        Me.RackingKeyColumn.DataPropertyName = "RackingKey"
        Me.RackingKeyColumn.HeaderText = "RackingKey"
        Me.RackingKeyColumn.Name = "RackingKeyColumn"
        Me.RackingKeyColumn.Visible = False
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "PartDescription"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.Visible = False
        '
        'ActivityDateColumn
        '
        Me.ActivityDateColumn.DataPropertyName = "ActivityDate"
        Me.ActivityDateColumn.HeaderText = "ActivityDate"
        Me.ActivityDateColumn.Name = "ActivityDateColumn"
        Me.ActivityDateColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'CreationDateColumn
        '
        Me.CreationDateColumn.DataPropertyName = "CreationDate"
        Me.CreationDateColumn.HeaderText = "CreationDate"
        Me.CreationDateColumn.Name = "CreationDateColumn"
        Me.CreationDateColumn.Visible = False
        '
        'RackingTransactionTableBindingSource
        '
        Me.RackingTransactionTableBindingSource.DataMember = "RackingTransactionTable"
        Me.RackingTransactionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Rack Number"
        '
        'txtRackNumber
        '
        Me.txtRackNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRackNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRackNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRackNumber.Location = New System.Drawing.Point(17, 41)
        Me.txtRackNumber.Name = "txtRackNumber"
        Me.txtRackNumber.Size = New System.Drawing.Size(200, 26)
        Me.txtRackNumber.TabIndex = 0
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(12, 511)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(160, 70)
        Me.cmdExit.TabIndex = 6
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxLookupByPart
        '
        Me.gpxLookupByPart.Controls.Add(Me.cmdAddToSelectedRack)
        Me.gpxLookupByPart.Controls.Add(Me.Label16)
        Me.gpxLookupByPart.Controls.Add(Me.cmdRemoveFromSelectedRack)
        Me.gpxLookupByPart.Controls.Add(Me.txtEditPieces)
        Me.gpxLookupByPart.Controls.Add(Me.txtQOH)
        Me.gpxLookupByPart.Controls.Add(Me.Label13)
        Me.gpxLookupByPart.Controls.Add(Me.cmdDeletedLinePart)
        Me.gpxLookupByPart.Controls.Add(Me.Label3)
        Me.gpxLookupByPart.Controls.Add(Me.txtTotalPiecesInRack)
        Me.gpxLookupByPart.Controls.Add(Me.dgvPartLookup)
        Me.gpxLookupByPart.Controls.Add(Me.Label2)
        Me.gpxLookupByPart.Controls.Add(Me.txtPartNumberLookup)
        Me.gpxLookupByPart.Location = New System.Drawing.Point(190, 0)
        Me.gpxLookupByPart.Name = "gpxLookupByPart"
        Me.gpxLookupByPart.Size = New System.Drawing.Size(1080, 712)
        Me.gpxLookupByPart.TabIndex = 7
        Me.gpxLookupByPart.TabStop = False
        '
        'cmdAddToSelectedRack
        '
        Me.cmdAddToSelectedRack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddToSelectedRack.ForeColor = System.Drawing.Color.Blue
        Me.cmdAddToSelectedRack.Location = New System.Drawing.Point(829, 16)
        Me.cmdAddToSelectedRack.Name = "cmdAddToSelectedRack"
        Me.cmdAddToSelectedRack.Size = New System.Drawing.Size(119, 56)
        Me.cmdAddToSelectedRack.TabIndex = 13
        Me.cmdAddToSelectedRack.Text = "Add Pieces To Rack"
        Me.cmdAddToSelectedRack.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(662, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(161, 20)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "# of Pieces"
        '
        'cmdRemoveFromSelectedRack
        '
        Me.cmdRemoveFromSelectedRack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemoveFromSelectedRack.ForeColor = System.Drawing.Color.Blue
        Me.cmdRemoveFromSelectedRack.Location = New System.Drawing.Point(954, 16)
        Me.cmdRemoveFromSelectedRack.Name = "cmdRemoveFromSelectedRack"
        Me.cmdRemoveFromSelectedRack.Size = New System.Drawing.Size(119, 56)
        Me.cmdRemoveFromSelectedRack.TabIndex = 11
        Me.cmdRemoveFromSelectedRack.Text = "Subtract Pieces  From  Rack"
        Me.cmdRemoveFromSelectedRack.UseVisualStyleBackColor = True
        '
        'txtEditPieces
        '
        Me.txtEditPieces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEditPieces.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEditPieces.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditPieces.Location = New System.Drawing.Point(662, 46)
        Me.txtEditPieces.Name = "txtEditPieces"
        Me.txtEditPieces.Size = New System.Drawing.Size(161, 26)
        Me.txtEditPieces.TabIndex = 10
        Me.txtEditPieces.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtQOH
        '
        Me.txtQOH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQOH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQOH.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQOH.Location = New System.Drawing.Point(463, 666)
        Me.txtQOH.Name = "txtQOH"
        Me.txtQOH.ReadOnly = True
        Me.txtQOH.Size = New System.Drawing.Size(183, 26)
        Me.txtQOH.TabIndex = 9
        Me.txtQOH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(652, 668)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(258, 20)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Quantity On Hand"
        '
        'cmdDeletedLinePart
        '
        Me.cmdDeletedLinePart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeletedLinePart.Location = New System.Drawing.Point(310, 13)
        Me.cmdDeletedLinePart.Name = "cmdDeletedLinePart"
        Me.cmdDeletedLinePart.Size = New System.Drawing.Size(119, 56)
        Me.cmdDeletedLinePart.TabIndex = 6
        Me.cmdDeletedLinePart.Text = "Delete Selected Line"
        Me.cmdDeletedLinePart.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(212, 668)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(258, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Total Pieces in Rack"
        '
        'txtTotalPiecesInRack
        '
        Me.txtTotalPiecesInRack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPiecesInRack.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalPiecesInRack.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPiecesInRack.Location = New System.Drawing.Point(15, 665)
        Me.txtTotalPiecesInRack.Name = "txtTotalPiecesInRack"
        Me.txtTotalPiecesInRack.ReadOnly = True
        Me.txtTotalPiecesInRack.Size = New System.Drawing.Size(183, 26)
        Me.txtTotalPiecesInRack.TabIndex = 4
        Me.txtTotalPiecesInRack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvPartLookup
        '
        Me.dgvPartLookup.AllowUserToAddRows = False
        Me.dgvPartLookup.AllowUserToDeleteRows = False
        Me.dgvPartLookup.AllowUserToOrderColumns = True
        Me.dgvPartLookup.AutoGenerateColumns = False
        Me.dgvPartLookup.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPartLookup.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvPartLookup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPartLookup.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BinNumberColumn1, Me.PartNumberColumn1, Me.BoxQuantityColumn1, Me.PiecesPerBoxColumn1, Me.TotalPiecesColumn1, Me.LotNumberColumn1, Me.HeatNumberColumn1, Me.RackingWeightColumn1, Me.ActivityDateColumn1, Me.DivisionIDColumn1, Me.RackingKeyColumn1, Me.PartDescriptionColumn1})
        Me.dgvPartLookup.DataSource = Me.RackingTransactionTableBindingSource
        Me.dgvPartLookup.GridColor = System.Drawing.Color.Fuchsia
        Me.dgvPartLookup.Location = New System.Drawing.Point(15, 80)
        Me.dgvPartLookup.MultiSelect = False
        Me.dgvPartLookup.Name = "dgvPartLookup"
        Me.dgvPartLookup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPartLookup.Size = New System.Drawing.Size(1061, 568)
        Me.dgvPartLookup.TabIndex = 3
        '
        'BinNumberColumn1
        '
        Me.BinNumberColumn1.DataPropertyName = "BinNumber"
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BinNumberColumn1.DefaultCellStyle = DataGridViewCellStyle10
        Me.BinNumberColumn1.HeaderText = "Bin #"
        Me.BinNumberColumn1.Name = "BinNumberColumn1"
        Me.BinNumberColumn1.ReadOnly = True
        '
        'PartNumberColumn1
        '
        Me.PartNumberColumn1.DataPropertyName = "PartNumber"
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartNumberColumn1.DefaultCellStyle = DataGridViewCellStyle11
        Me.PartNumberColumn1.HeaderText = "Part #"
        Me.PartNumberColumn1.Name = "PartNumberColumn1"
        Me.PartNumberColumn1.ReadOnly = True
        Me.PartNumberColumn1.Width = 240
        '
        'BoxQuantityColumn1
        '
        Me.BoxQuantityColumn1.DataPropertyName = "BoxQuantity"
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxQuantityColumn1.DefaultCellStyle = DataGridViewCellStyle12
        Me.BoxQuantityColumn1.HeaderText = "# Boxes"
        Me.BoxQuantityColumn1.Name = "BoxQuantityColumn1"
        '
        'PiecesPerBoxColumn1
        '
        Me.PiecesPerBoxColumn1.DataPropertyName = "PiecesPerBox"
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PiecesPerBoxColumn1.DefaultCellStyle = DataGridViewCellStyle13
        Me.PiecesPerBoxColumn1.HeaderText = "Pcs/Box"
        Me.PiecesPerBoxColumn1.Name = "PiecesPerBoxColumn1"
        '
        'TotalPiecesColumn1
        '
        Me.TotalPiecesColumn1.DataPropertyName = "TotalPieces"
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalPiecesColumn1.DefaultCellStyle = DataGridViewCellStyle14
        Me.TotalPiecesColumn1.HeaderText = "Total"
        Me.TotalPiecesColumn1.Name = "TotalPiecesColumn1"
        Me.TotalPiecesColumn1.ReadOnly = True
        '
        'LotNumberColumn1
        '
        Me.LotNumberColumn1.DataPropertyName = "LotNumber"
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LotNumberColumn1.DefaultCellStyle = DataGridViewCellStyle15
        Me.LotNumberColumn1.HeaderText = "Lot #"
        Me.LotNumberColumn1.Name = "LotNumberColumn1"
        Me.LotNumberColumn1.ReadOnly = True
        Me.LotNumberColumn1.Width = 140
        '
        'HeatNumberColumn1
        '
        Me.HeatNumberColumn1.DataPropertyName = "HeatNumber"
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeatNumberColumn1.DefaultCellStyle = DataGridViewCellStyle16
        Me.HeatNumberColumn1.HeaderText = "Heat #"
        Me.HeatNumberColumn1.Name = "HeatNumberColumn1"
        Me.HeatNumberColumn1.ReadOnly = True
        Me.HeatNumberColumn1.Width = 140
        '
        'RackingWeightColumn1
        '
        Me.RackingWeightColumn1.DataPropertyName = "RackingWeight"
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RackingWeightColumn1.DefaultCellStyle = DataGridViewCellStyle17
        Me.RackingWeightColumn1.HeaderText = "Weight"
        Me.RackingWeightColumn1.Name = "RackingWeightColumn1"
        Me.RackingWeightColumn1.ReadOnly = True
        '
        'ActivityDateColumn1
        '
        Me.ActivityDateColumn1.DataPropertyName = "ActivityDate"
        Me.ActivityDateColumn1.HeaderText = "Activity Date"
        Me.ActivityDateColumn1.Name = "ActivityDateColumn1"
        Me.ActivityDateColumn1.ReadOnly = True
        Me.ActivityDateColumn1.Visible = False
        '
        'DivisionIDColumn1
        '
        Me.DivisionIDColumn1.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn1.HeaderText = "DivisionID"
        Me.DivisionIDColumn1.Name = "DivisionIDColumn1"
        Me.DivisionIDColumn1.Visible = False
        '
        'RackingKeyColumn1
        '
        Me.RackingKeyColumn1.DataPropertyName = "RackingKey"
        Me.RackingKeyColumn1.HeaderText = "RackingKey"
        Me.RackingKeyColumn1.Name = "RackingKeyColumn1"
        Me.RackingKeyColumn1.Visible = False
        '
        'PartDescriptionColumn1
        '
        Me.PartDescriptionColumn1.DataPropertyName = "PartDescription"
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartDescriptionColumn1.DefaultCellStyle = DataGridViewCellStyle18
        Me.PartDescriptionColumn1.HeaderText = "Description"
        Me.PartDescriptionColumn1.Name = "PartDescriptionColumn1"
        Me.PartDescriptionColumn1.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Part Number"
        '
        'txtPartNumberLookup
        '
        Me.txtPartNumberLookup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartNumberLookup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNumberLookup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartNumberLookup.Location = New System.Drawing.Point(15, 43)
        Me.txtPartNumberLookup.Name = "txtPartNumberLookup"
        Me.txtPartNumberLookup.Size = New System.Drawing.Size(275, 26)
        Me.txtPartNumberLookup.TabIndex = 1
        '
        'gpxAddToRack
        '
        Me.gpxAddToRack.Controls.Add(Me.Label12)
        Me.gpxAddToRack.Controls.Add(Me.Label11)
        Me.gpxAddToRack.Controls.Add(Me.txtHeatNumber)
        Me.gpxAddToRack.Controls.Add(Me.txtPartDescription)
        Me.gpxAddToRack.Controls.Add(Me.cmdAddToRackEntry)
        Me.gpxAddToRack.Controls.Add(Me.Label10)
        Me.gpxAddToRack.Controls.Add(Me.Label9)
        Me.gpxAddToRack.Controls.Add(Me.Label8)
        Me.gpxAddToRack.Controls.Add(Me.Label7)
        Me.gpxAddToRack.Controls.Add(Me.Label6)
        Me.gpxAddToRack.Controls.Add(Me.Label5)
        Me.gpxAddToRack.Controls.Add(Me.txtAddBinNumber)
        Me.gpxAddToRack.Controls.Add(Me.txtTotalWeight)
        Me.gpxAddToRack.Controls.Add(Me.txtTotalPieces)
        Me.gpxAddToRack.Controls.Add(Me.txtNumberOfPieces)
        Me.gpxAddToRack.Controls.Add(Me.txtNumberOfBoxes)
        Me.gpxAddToRack.Controls.Add(Me.txtPartNumber)
        Me.gpxAddToRack.Controls.Add(Me.Label4)
        Me.gpxAddToRack.Controls.Add(Me.txtLotNumber)
        Me.gpxAddToRack.Controls.Add(Me.cmdClearFields)
        Me.gpxAddToRack.Location = New System.Drawing.Point(190, 0)
        Me.gpxAddToRack.Name = "gpxAddToRack"
        Me.gpxAddToRack.Size = New System.Drawing.Size(1080, 712)
        Me.gpxAddToRack.TabIndex = 8
        Me.gpxAddToRack.TabStop = False
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(435, 176)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(179, 31)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Description"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(435, 70)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(179, 31)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Heat Number"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtHeatNumber
        '
        Me.txtHeatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeatNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHeatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeatNumber.Location = New System.Drawing.Point(40, 70)
        Me.txtHeatNumber.Name = "txtHeatNumber"
        Me.txtHeatNumber.ReadOnly = True
        Me.txtHeatNumber.Size = New System.Drawing.Size(389, 31)
        Me.txtHeatNumber.TabIndex = 10
        Me.txtHeatNumber.TabStop = False
        Me.txtHeatNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPartDescription
        '
        Me.txtPartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartDescription.Location = New System.Drawing.Point(40, 176)
        Me.txtPartDescription.Name = "txtPartDescription"
        Me.txtPartDescription.ReadOnly = True
        Me.txtPartDescription.Size = New System.Drawing.Size(389, 31)
        Me.txtPartDescription.TabIndex = 10
        Me.txtPartDescription.TabStop = False
        Me.txtPartDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdAddToRackEntry
        '
        Me.cmdAddToRackEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddToRackEntry.Location = New System.Drawing.Point(269, 509)
        Me.cmdAddToRackEntry.Name = "cmdAddToRackEntry"
        Me.cmdAddToRackEntry.Size = New System.Drawing.Size(160, 70)
        Me.cmdAddToRackEntry.TabIndex = 7
        Me.cmdAddToRackEntry.Text = "Add To Rack"
        Me.cmdAddToRackEntry.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(435, 441)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(179, 31)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Bin Number"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(435, 388)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(179, 31)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Weight"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(435, 335)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(179, 31)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Total"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(435, 282)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(179, 31)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Pieces/Box"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(435, 229)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(179, 31)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "# of Boxes"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(435, 123)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(179, 31)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Part Number"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAddBinNumber
        '
        Me.txtAddBinNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddBinNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddBinNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddBinNumber.Location = New System.Drawing.Point(216, 441)
        Me.txtAddBinNumber.Name = "txtAddBinNumber"
        Me.txtAddBinNumber.Size = New System.Drawing.Size(213, 31)
        Me.txtAddBinNumber.TabIndex = 4
        Me.txtAddBinNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalWeight
        '
        Me.txtTotalWeight.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtTotalWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalWeight.Location = New System.Drawing.Point(216, 388)
        Me.txtTotalWeight.Name = "txtTotalWeight"
        Me.txtTotalWeight.ReadOnly = True
        Me.txtTotalWeight.Size = New System.Drawing.Size(213, 31)
        Me.txtTotalWeight.TabIndex = 10
        Me.txtTotalWeight.TabStop = False
        Me.txtTotalWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalPieces
        '
        Me.txtTotalPieces.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtTotalPieces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPieces.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalPieces.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPieces.Location = New System.Drawing.Point(216, 335)
        Me.txtTotalPieces.Name = "txtTotalPieces"
        Me.txtTotalPieces.ReadOnly = True
        Me.txtTotalPieces.Size = New System.Drawing.Size(213, 31)
        Me.txtTotalPieces.TabIndex = 10
        Me.txtTotalPieces.TabStop = False
        Me.txtTotalPieces.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumberOfPieces
        '
        Me.txtNumberOfPieces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfPieces.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberOfPieces.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberOfPieces.Location = New System.Drawing.Point(216, 282)
        Me.txtNumberOfPieces.Name = "txtNumberOfPieces"
        Me.txtNumberOfPieces.Size = New System.Drawing.Size(213, 31)
        Me.txtNumberOfPieces.TabIndex = 3
        Me.txtNumberOfPieces.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumberOfBoxes
        '
        Me.txtNumberOfBoxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfBoxes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberOfBoxes.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberOfBoxes.Location = New System.Drawing.Point(216, 229)
        Me.txtNumberOfBoxes.Name = "txtNumberOfBoxes"
        Me.txtNumberOfBoxes.Size = New System.Drawing.Size(213, 31)
        Me.txtNumberOfBoxes.TabIndex = 2
        Me.txtNumberOfBoxes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPartNumber
        '
        Me.txtPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartNumber.Location = New System.Drawing.Point(40, 123)
        Me.txtPartNumber.MaxLength = 50
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.Size = New System.Drawing.Size(389, 31)
        Me.txtPartNumber.TabIndex = 1
        Me.txtPartNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(435, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(179, 31)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Lot Number"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLotNumber
        '
        Me.txtLotNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLotNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLotNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLotNumber.Location = New System.Drawing.Point(40, 17)
        Me.txtLotNumber.MaxLength = 50
        Me.txtLotNumber.Name = "txtLotNumber"
        Me.txtLotNumber.Size = New System.Drawing.Size(389, 31)
        Me.txtLotNumber.TabIndex = 0
        Me.txtLotNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdClearFields
        '
        Me.cmdClearFields.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClearFields.Location = New System.Drawing.Point(269, 621)
        Me.cmdClearFields.Name = "cmdClearFields"
        Me.cmdClearFields.Size = New System.Drawing.Size(160, 70)
        Me.cmdClearFields.TabIndex = 18
        Me.cmdClearFields.Text = "Clear Fields"
        Me.cmdClearFields.UseVisualStyleBackColor = True
        '
        'txtUpdateDatagrid
        '
        Me.txtUpdateDatagrid.Location = New System.Drawing.Point(40, 647)
        Me.txtUpdateDatagrid.Name = "txtUpdateDatagrid"
        Me.txtUpdateDatagrid.Size = New System.Drawing.Size(100, 20)
        Me.txtUpdateDatagrid.TabIndex = 9
        Me.txtUpdateDatagrid.Visible = False
        '
        'cmdLookupByOrder
        '
        Me.cmdLookupByOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLookupByOrder.Location = New System.Drawing.Point(12, 223)
        Me.cmdLookupByOrder.Name = "cmdLookupByOrder"
        Me.cmdLookupByOrder.Size = New System.Drawing.Size(160, 70)
        Me.cmdLookupByOrder.TabIndex = 10
        Me.cmdLookupByOrder.Text = "Lookup By Order"
        Me.cmdLookupByOrder.UseVisualStyleBackColor = True
        '
        'gpxLookupByOrder
        '
        Me.gpxLookupByOrder.Controls.Add(Me.GroupBox1)
        Me.gpxLookupByOrder.Controls.Add(Me.dgvRackingByOrder)
        Me.gpxLookupByOrder.Controls.Add(Me.dgvOrderLines)
        Me.gpxLookupByOrder.Controls.Add(Me.Label14)
        Me.gpxLookupByOrder.Controls.Add(Me.txtOrderNumber)
        Me.gpxLookupByOrder.Location = New System.Drawing.Point(190, 0)
        Me.gpxLookupByOrder.Name = "gpxLookupByOrder"
        Me.gpxLookupByOrder.Size = New System.Drawing.Size(1080, 712)
        Me.gpxLookupByOrder.TabIndex = 11
        Me.gpxLookupByOrder.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdAddToRack3)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtRemoveFromRack3)
        Me.GroupBox1.Controls.Add(Me.txtEditPieces3)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.cmdDeleteLineFromOrder)
        Me.GroupBox1.Location = New System.Drawing.Point(310, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(756, 83)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'cmdAddToRack3
        '
        Me.cmdAddToRack3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddToRack3.ForeColor = System.Drawing.Color.Blue
        Me.cmdAddToRack3.Location = New System.Drawing.Point(496, 14)
        Me.cmdAddToRack3.Name = "cmdAddToRack3"
        Me.cmdAddToRack3.Size = New System.Drawing.Size(119, 56)
        Me.cmdAddToRack3.TabIndex = 17
        Me.cmdAddToRack3.Text = "Add Pieces To Rack"
        Me.cmdAddToRack3.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(329, 19)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(161, 20)
        Me.Label18.TabIndex = 16
        Me.Label18.Text = "# of Pieces"
        '
        'txtRemoveFromRack3
        '
        Me.txtRemoveFromRack3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemoveFromRack3.ForeColor = System.Drawing.Color.Blue
        Me.txtRemoveFromRack3.Location = New System.Drawing.Point(621, 14)
        Me.txtRemoveFromRack3.Name = "txtRemoveFromRack3"
        Me.txtRemoveFromRack3.Size = New System.Drawing.Size(119, 56)
        Me.txtRemoveFromRack3.TabIndex = 15
        Me.txtRemoveFromRack3.Text = "Subtract Pieces  From  Rack"
        Me.txtRemoveFromRack3.UseVisualStyleBackColor = True
        '
        'txtEditPieces3
        '
        Me.txtEditPieces3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEditPieces3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEditPieces3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditPieces3.Location = New System.Drawing.Point(329, 44)
        Me.txtEditPieces3.Name = "txtEditPieces3"
        Me.txtEditPieces3.Size = New System.Drawing.Size(161, 26)
        Me.txtEditPieces3.TabIndex = 14
        Me.txtEditPieces3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(156, 27)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(148, 41)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "Delete selected line in datagrid."
        '
        'cmdDeleteLineFromOrder
        '
        Me.cmdDeleteLineFromOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteLineFromOrder.Location = New System.Drawing.Point(32, 16)
        Me.cmdDeleteLineFromOrder.Name = "cmdDeleteLineFromOrder"
        Me.cmdDeleteLineFromOrder.Size = New System.Drawing.Size(119, 56)
        Me.cmdDeleteLineFromOrder.TabIndex = 7
        Me.cmdDeleteLineFromOrder.Text = "Delete Selected Line"
        Me.cmdDeleteLineFromOrder.UseVisualStyleBackColor = True
        '
        'dgvRackingByOrder
        '
        Me.dgvRackingByOrder.AllowUserToAddRows = False
        Me.dgvRackingByOrder.AllowUserToDeleteRows = False
        Me.dgvRackingByOrder.AutoGenerateColumns = False
        Me.dgvRackingByOrder.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvRackingByOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRackingByOrder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RackingKeyColumnOE, Me.BinNumberColumnOE, Me.PartNumberColumnOE, Me.PartDescriptionColumnOE, Me.BoxQuantityColumnOE, Me.PiecesPerBoxColumnOE, Me.TotalPiecesColumnOE, Me.RackingWeightColumnOE, Me.HeatNumberColumnOE, Me.LotNumberColumnOE, Me.ActivityDateColumnOE, Me.DivisionIDColumnOE, Me.CreationDateColumnOE, Me.PickTicketColumnOE, Me.PickDateColumnOE, Me.AddedByColumnOE, Me.CommentColumnOE})
        Me.dgvRackingByOrder.DataSource = Me.RackingTransactionTableBindingSource
        Me.dgvRackingByOrder.GridColor = System.Drawing.Color.Blue
        Me.dgvRackingByOrder.Location = New System.Drawing.Point(310, 107)
        Me.dgvRackingByOrder.Name = "dgvRackingByOrder"
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvRackingByOrder.RowsDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvRackingByOrder.Size = New System.Drawing.Size(756, 591)
        Me.dgvRackingByOrder.TabIndex = 3
        '
        'RackingKeyColumnOE
        '
        Me.RackingKeyColumnOE.DataPropertyName = "RackingKey"
        Me.RackingKeyColumnOE.HeaderText = "RackingKey"
        Me.RackingKeyColumnOE.Name = "RackingKeyColumnOE"
        Me.RackingKeyColumnOE.Visible = False
        '
        'BinNumberColumnOE
        '
        Me.BinNumberColumnOE.DataPropertyName = "BinNumber"
        Me.BinNumberColumnOE.HeaderText = "Bin #"
        Me.BinNumberColumnOE.Name = "BinNumberColumnOE"
        Me.BinNumberColumnOE.ReadOnly = True
        Me.BinNumberColumnOE.Width = 80
        '
        'PartNumberColumnOE
        '
        Me.PartNumberColumnOE.DataPropertyName = "PartNumber"
        Me.PartNumberColumnOE.HeaderText = "Part #"
        Me.PartNumberColumnOE.Name = "PartNumberColumnOE"
        Me.PartNumberColumnOE.ReadOnly = True
        Me.PartNumberColumnOE.Width = 150
        '
        'PartDescriptionColumnOE
        '
        Me.PartDescriptionColumnOE.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumnOE.HeaderText = "Description"
        Me.PartDescriptionColumnOE.Name = "PartDescriptionColumnOE"
        Me.PartDescriptionColumnOE.ReadOnly = True
        Me.PartDescriptionColumnOE.Width = 150
        '
        'BoxQuantityColumnOE
        '
        Me.BoxQuantityColumnOE.DataPropertyName = "BoxQuantity"
        Me.BoxQuantityColumnOE.HeaderText = "# Boxes"
        Me.BoxQuantityColumnOE.Name = "BoxQuantityColumnOE"
        Me.BoxQuantityColumnOE.Width = 90
        '
        'PiecesPerBoxColumnOE
        '
        Me.PiecesPerBoxColumnOE.DataPropertyName = "PiecesPerBox"
        Me.PiecesPerBoxColumnOE.HeaderText = "Pcs/Box"
        Me.PiecesPerBoxColumnOE.Name = "PiecesPerBoxColumnOE"
        Me.PiecesPerBoxColumnOE.Width = 90
        '
        'TotalPiecesColumnOE
        '
        Me.TotalPiecesColumnOE.DataPropertyName = "TotalPieces"
        Me.TotalPiecesColumnOE.HeaderText = "Total Pcs"
        Me.TotalPiecesColumnOE.Name = "TotalPiecesColumnOE"
        Me.TotalPiecesColumnOE.ReadOnly = True
        Me.TotalPiecesColumnOE.Width = 90
        '
        'RackingWeightColumnOE
        '
        Me.RackingWeightColumnOE.DataPropertyName = "RackingWeight"
        Me.RackingWeightColumnOE.HeaderText = "Weight"
        Me.RackingWeightColumnOE.Name = "RackingWeightColumnOE"
        Me.RackingWeightColumnOE.ReadOnly = True
        Me.RackingWeightColumnOE.Width = 90
        '
        'HeatNumberColumnOE
        '
        Me.HeatNumberColumnOE.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumnOE.HeaderText = "Heat #"
        Me.HeatNumberColumnOE.Name = "HeatNumberColumnOE"
        Me.HeatNumberColumnOE.ReadOnly = True
        '
        'LotNumberColumnOE
        '
        Me.LotNumberColumnOE.DataPropertyName = "LotNumber"
        Me.LotNumberColumnOE.HeaderText = "Lot #"
        Me.LotNumberColumnOE.Name = "LotNumberColumnOE"
        Me.LotNumberColumnOE.ReadOnly = True
        '
        'ActivityDateColumnOE
        '
        Me.ActivityDateColumnOE.DataPropertyName = "ActivityDate"
        Me.ActivityDateColumnOE.HeaderText = "ActivityDate"
        Me.ActivityDateColumnOE.Name = "ActivityDateColumnOE"
        Me.ActivityDateColumnOE.Visible = False
        '
        'DivisionIDColumnOE
        '
        Me.DivisionIDColumnOE.DataPropertyName = "DivisionID"
        Me.DivisionIDColumnOE.HeaderText = "DivisionID"
        Me.DivisionIDColumnOE.Name = "DivisionIDColumnOE"
        Me.DivisionIDColumnOE.Visible = False
        '
        'CreationDateColumnOE
        '
        Me.CreationDateColumnOE.DataPropertyName = "CreationDate"
        Me.CreationDateColumnOE.HeaderText = "CreationDate"
        Me.CreationDateColumnOE.Name = "CreationDateColumnOE"
        Me.CreationDateColumnOE.Visible = False
        '
        'PickTicketColumnOE
        '
        Me.PickTicketColumnOE.DataPropertyName = "PickTicket"
        Me.PickTicketColumnOE.HeaderText = "PickTicket"
        Me.PickTicketColumnOE.Name = "PickTicketColumnOE"
        Me.PickTicketColumnOE.Visible = False
        '
        'PickDateColumnOE
        '
        Me.PickDateColumnOE.DataPropertyName = "PickDate"
        Me.PickDateColumnOE.HeaderText = "PickDate"
        Me.PickDateColumnOE.Name = "PickDateColumnOE"
        Me.PickDateColumnOE.Visible = False
        '
        'AddedByColumnOE
        '
        Me.AddedByColumnOE.DataPropertyName = "AddedBy"
        Me.AddedByColumnOE.HeaderText = "AddedBy"
        Me.AddedByColumnOE.Name = "AddedByColumnOE"
        Me.AddedByColumnOE.Visible = False
        '
        'CommentColumnOE
        '
        Me.CommentColumnOE.DataPropertyName = "Comment"
        Me.CommentColumnOE.HeaderText = "Comment"
        Me.CommentColumnOE.Name = "CommentColumnOE"
        Me.CommentColumnOE.Visible = False
        '
        'dgvOrderLines
        '
        Me.dgvOrderLines.AllowUserToAddRows = False
        Me.dgvOrderLines.AllowUserToDeleteRows = False
        Me.dgvOrderLines.AutoGenerateColumns = False
        Me.dgvOrderLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvOrderLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvOrderLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrderLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PickListHeaderKeyColumnOL, Me.PickListLineKeyColumnOL, Me.ItemIDColumnOL, Me.DescriptionColumnOL, Me.QuantityColumnOL, Me.DivisionIDColumnOL})
        Me.dgvOrderLines.DataSource = Me.PickListLineTableBindingSource
        Me.dgvOrderLines.GridColor = System.Drawing.Color.Purple
        Me.dgvOrderLines.Location = New System.Drawing.Point(17, 107)
        Me.dgvOrderLines.Name = "dgvOrderLines"
        Me.dgvOrderLines.ReadOnly = True
        Me.dgvOrderLines.Size = New System.Drawing.Size(273, 591)
        Me.dgvOrderLines.TabIndex = 2
        '
        'PickListHeaderKeyColumnOL
        '
        Me.PickListHeaderKeyColumnOL.DataPropertyName = "PickListHeaderKey"
        Me.PickListHeaderKeyColumnOL.HeaderText = "PickListHeaderKey"
        Me.PickListHeaderKeyColumnOL.Name = "PickListHeaderKeyColumnOL"
        Me.PickListHeaderKeyColumnOL.ReadOnly = True
        Me.PickListHeaderKeyColumnOL.Visible = False
        '
        'PickListLineKeyColumnOL
        '
        Me.PickListLineKeyColumnOL.DataPropertyName = "PickListLineKey"
        Me.PickListLineKeyColumnOL.HeaderText = "PickListLineKey"
        Me.PickListLineKeyColumnOL.Name = "PickListLineKeyColumnOL"
        Me.PickListLineKeyColumnOL.ReadOnly = True
        Me.PickListLineKeyColumnOL.Visible = False
        '
        'ItemIDColumnOL
        '
        Me.ItemIDColumnOL.DataPropertyName = "ItemID"
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemIDColumnOL.DefaultCellStyle = DataGridViewCellStyle20
        Me.ItemIDColumnOL.HeaderText = "Part #"
        Me.ItemIDColumnOL.Name = "ItemIDColumnOL"
        Me.ItemIDColumnOL.ReadOnly = True
        Me.ItemIDColumnOL.Width = 140
        '
        'DescriptionColumnOL
        '
        Me.DescriptionColumnOL.DataPropertyName = "Description"
        Me.DescriptionColumnOL.HeaderText = "Description"
        Me.DescriptionColumnOL.Name = "DescriptionColumnOL"
        Me.DescriptionColumnOL.ReadOnly = True
        Me.DescriptionColumnOL.Visible = False
        '
        'QuantityColumnOL
        '
        Me.QuantityColumnOL.DataPropertyName = "Quantity"
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuantityColumnOL.DefaultCellStyle = DataGridViewCellStyle21
        Me.QuantityColumnOL.HeaderText = "Quantity"
        Me.QuantityColumnOL.Name = "QuantityColumnOL"
        Me.QuantityColumnOL.ReadOnly = True
        Me.QuantityColumnOL.Width = 90
        '
        'DivisionIDColumnOL
        '
        Me.DivisionIDColumnOL.DataPropertyName = "DivisionID"
        Me.DivisionIDColumnOL.HeaderText = "DivisionID"
        Me.DivisionIDColumnOL.Name = "DivisionIDColumnOL"
        Me.DivisionIDColumnOL.ReadOnly = True
        Me.DivisionIDColumnOL.Visible = False
        '
        'PickListLineTableBindingSource
        '
        Me.PickListLineTableBindingSource.DataMember = "PickListLineTable"
        Me.PickListLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(13, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(198, 23)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Pick Ticket #"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOrderNumber
        '
        Me.txtOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrderNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrderNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrderNumber.Location = New System.Drawing.Point(15, 54)
        Me.txtOrderNumber.Name = "txtOrderNumber"
        Me.txtOrderNumber.Size = New System.Drawing.Size(275, 26)
        Me.txtOrderNumber.TabIndex = 0
        Me.txtOrderNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RackingTransactionTableTableAdapter
        '
        Me.RackingTransactionTableTableAdapter.ClearBeforeFill = True
        '
        'PickListLineTableTableAdapter
        '
        Me.PickListLineTableTableAdapter.ClearBeforeFill = True
        '
        'LiftTruckRacking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1282, 735)
        Me.Controls.Add(Me.gpxLookupByOrder)
        Me.Controls.Add(Me.gpxLookupByPart)
        Me.Controls.Add(Me.gpxLookupByRack)
        Me.Controls.Add(Me.gpxAddToRack)
        Me.Controls.Add(Me.cmdLookupByOrder)
        Me.Controls.Add(Me.txtUpdateDatagrid)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdLookupByPart)
        Me.Controls.Add(Me.cmdAddToRack)
        Me.Controls.Add(Me.cmdLookupByRack)
        Me.Name = "LiftTruckRacking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Racking"
        Me.gpxLookupByRack.ResumeLayout(False)
        Me.gpxLookupByRack.PerformLayout()
        CType(Me.dgvRackLookup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RackingTransactionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxLookupByPart.ResumeLayout(False)
        Me.gpxLookupByPart.PerformLayout()
        CType(Me.dgvPartLookup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxAddToRack.ResumeLayout(False)
        Me.gpxAddToRack.PerformLayout()
        Me.gpxLookupByOrder.ResumeLayout(False)
        Me.gpxLookupByOrder.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvRackingByOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOrderLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PickListLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdLookupByRack As System.Windows.Forms.Button
    Friend WithEvents cmdAddToRack As System.Windows.Forms.Button
    Friend WithEvents cmdLookupByPart As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents gpxLookupByRack As System.Windows.Forms.GroupBox
    Friend WithEvents txtRackNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvRackLookup As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents RackingTransactionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RackingTransactionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RackingTransactionTableTableAdapter
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteRack As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxLookupByPart As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPartLookup As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPartNumberLookup As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPiecesInRack As System.Windows.Forms.TextBox
    Friend WithEvents cmdDeletedLinePart As System.Windows.Forms.Button
    Friend WithEvents gpxAddToRack As System.Windows.Forms.GroupBox
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLotNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAddBinNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalWeight As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalPieces As System.Windows.Forms.TextBox
    Friend WithEvents txtNumberOfPieces As System.Windows.Forms.TextBox
    Friend WithEvents txtNumberOfBoxes As System.Windows.Forms.TextBox
    Friend WithEvents cmdAddToRackEntry As System.Windows.Forms.Button
    Friend WithEvents txtHeatNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtPartDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdClearFields As System.Windows.Forms.Button
    Friend WithEvents BinNumberColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxQuantityColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PiecesPerBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalPiecesColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumberColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackingWeightColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActivityDateColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackingKeyColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtUpdateDatagrid As System.Windows.Forms.TextBox
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PiecesPerBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalPiecesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackingWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BinNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackingKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActivityDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreationDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtQOH As System.Windows.Forms.TextBox
    Friend WithEvents cmdLookupByOrder As System.Windows.Forms.Button
    Friend WithEvents gpxLookupByOrder As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtOrderNumber As System.Windows.Forms.TextBox
    Friend WithEvents dgvOrderLines As System.Windows.Forms.DataGridView
    Friend WithEvents PickListLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PickListLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListLineTableTableAdapter
    Friend WithEvents dgvRackingByOrder As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDeleteLineFromOrder As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents RackingKeyColumnOE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BinNumberColumnOE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumnOE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumnOE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxQuantityColumnOE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PiecesPerBoxColumnOE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalPiecesColumnOE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackingWeightColumnOE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumnOE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumberColumnOE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActivityDateColumnOE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumnOE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreationDateColumnOE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickTicketColumnOE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickDateColumnOE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddedByColumnOE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumnOE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickListHeaderKeyColumnOL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickListLineKeyColumnOL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemIDColumnOL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumnOL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumnOL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumnOL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdRemoveFromSelectedRack As System.Windows.Forms.Button
    Friend WithEvents txtEditPieces As System.Windows.Forms.TextBox
    Friend WithEvents cmdAddToSelectedRack As System.Windows.Forms.Button
    Friend WithEvents cmdAddToRack2 As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmdSubtractFromRack2 As System.Windows.Forms.Button
    Friend WithEvents txtEditPieces2 As System.Windows.Forms.TextBox
    Friend WithEvents cmdAddToRack3 As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtRemoveFromRack3 As System.Windows.Forms.Button
    Friend WithEvents txtEditPieces3 As System.Windows.Forms.TextBox
End Class
