<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewCharterSteelCoils
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxSearchFields = New System.Windows.Forms.GroupBox
        Me.chkAllTypes = New System.Windows.Forms.CheckBox
        Me.cboHeatNumber = New System.Windows.Forms.ComboBox
        Me.CharterSteelCoilIdentificationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.lblTotalCoils = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboPONumber = New System.Windows.Forms.ComboBox
        Me.lblTotalWeight = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.txtDespatchNumber = New System.Windows.Forms.TextBox
        Me.txtSteelSize = New System.Windows.Forms.TextBox
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdView = New System.Windows.Forms.Button
        Me.lblPurchaseOrderNumber = New System.Windows.Forms.Label
        Me.lblCoilStatus = New System.Windows.Forms.Label
        Me.lblHeatNumber = New System.Windows.Forms.Label
        Me.lblSteelSize = New System.Windows.Forms.Label
        Me.lblCarbon = New System.Windows.Forms.Label
        Me.lblDespatchNumber = New System.Windows.Forms.Label
        Me.SteelPurchaseOrderHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HeatNumberLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvCharterCoils = New System.Windows.Forms.DataGridView
        Me.CoilID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Carbon = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSize = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Weight = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiveDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AnnealLot = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Comment = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Location = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label7 = New System.Windows.Forms.Label
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.CharterSteelCoilIdentificationTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CharterSteelCoilIdentificationTableAdapter
        Me.HeatNumberLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
        Me.gpxKeyboard = New System.Windows.Forms.GroupBox
        Me.cmdBackspace = New System.Windows.Forms.Button
        Me.cmdKeyboardPrint = New System.Windows.Forms.Button
        Me.cmdKeyboardExit = New System.Windows.Forms.Button
        Me.cmdNine = New System.Windows.Forms.Button
        Me.cmdEnter = New System.Windows.Forms.Button
        Me.cmdEight = New System.Windows.Forms.Button
        Me.cmdSeven = New System.Windows.Forms.Button
        Me.cmdSix = New System.Windows.Forms.Button
        Me.cmdFive = New System.Windows.Forms.Button
        Me.cmdFour = New System.Windows.Forms.Button
        Me.cmdThree = New System.Windows.Forms.Button
        Me.cmdTwo = New System.Windows.Forms.Button
        Me.cmdOne = New System.Windows.Forms.Button
        Me.cmdZero = New System.Windows.Forms.Button
        Me.cmdSpace = New System.Windows.Forms.Button
        Me.cmdM = New System.Windows.Forms.Button
        Me.cmdN = New System.Windows.Forms.Button
        Me.cmdB = New System.Windows.Forms.Button
        Me.cmdV = New System.Windows.Forms.Button
        Me.cmdC = New System.Windows.Forms.Button
        Me.cmdX = New System.Windows.Forms.Button
        Me.cmdL = New System.Windows.Forms.Button
        Me.cmdK = New System.Windows.Forms.Button
        Me.cmdJ = New System.Windows.Forms.Button
        Me.cmdH = New System.Windows.Forms.Button
        Me.cmdG = New System.Windows.Forms.Button
        Me.cmdF = New System.Windows.Forms.Button
        Me.cmdD = New System.Windows.Forms.Button
        Me.cmdS = New System.Windows.Forms.Button
        Me.cmdZ = New System.Windows.Forms.Button
        Me.cmdP = New System.Windows.Forms.Button
        Me.cmdO = New System.Windows.Forms.Button
        Me.cmdI = New System.Windows.Forms.Button
        Me.cmdU = New System.Windows.Forms.Button
        Me.cmdY = New System.Windows.Forms.Button
        Me.cmdT = New System.Windows.Forms.Button
        Me.cmdR = New System.Windows.Forms.Button
        Me.cmdE = New System.Windows.Forms.Button
        Me.cmdW = New System.Windows.Forms.Button
        Me.cmdQ = New System.Windows.Forms.Button
        Me.cmdDash = New System.Windows.Forms.Button
        Me.cmdForwardSlash = New System.Windows.Forms.Button
        Me.cmdA = New System.Windows.Forms.Button
        Me.cmdDecimal = New System.Windows.Forms.Button
        Me.lstCarbonSuggest = New System.Windows.Forms.ListBox
        Me.lstHeatSuggest = New System.Windows.Forms.ListBox
        Me.pnlChangeLocation = New System.Windows.Forms.Panel
        Me.cmdCancelLocationChange = New System.Windows.Forms.Button
        Me.txtLocationValue = New System.Windows.Forms.TextBox
        Me.cmdChangeLocationValue = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.gpxSearchFields.SuspendLayout()
        CType(Me.CharterSteelCoilIdentificationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelPurchaseOrderHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCharterCoils, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxKeyboard.SuspendLayout()
        Me.pnlChangeLocation.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1220, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
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
        'gpxSearchFields
        '
        Me.gpxSearchFields.Controls.Add(Me.chkAllTypes)
        Me.gpxSearchFields.Controls.Add(Me.cboHeatNumber)
        Me.gpxSearchFields.Controls.Add(Me.lblTotalCoils)
        Me.gpxSearchFields.Controls.Add(Me.Label3)
        Me.gpxSearchFields.Controls.Add(Me.cboPONumber)
        Me.gpxSearchFields.Controls.Add(Me.lblTotalWeight)
        Me.gpxSearchFields.Controls.Add(Me.Label1)
        Me.gpxSearchFields.Controls.Add(Me.cboStatus)
        Me.gpxSearchFields.Controls.Add(Me.txtDespatchNumber)
        Me.gpxSearchFields.Controls.Add(Me.txtSteelSize)
        Me.gpxSearchFields.Controls.Add(Me.cboCarbon)
        Me.gpxSearchFields.Controls.Add(Me.cmdClear)
        Me.gpxSearchFields.Controls.Add(Me.cmdView)
        Me.gpxSearchFields.Controls.Add(Me.lblPurchaseOrderNumber)
        Me.gpxSearchFields.Controls.Add(Me.lblCoilStatus)
        Me.gpxSearchFields.Controls.Add(Me.lblHeatNumber)
        Me.gpxSearchFields.Controls.Add(Me.lblSteelSize)
        Me.gpxSearchFields.Controls.Add(Me.lblCarbon)
        Me.gpxSearchFields.Controls.Add(Me.lblDespatchNumber)
        Me.gpxSearchFields.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpxSearchFields.Location = New System.Drawing.Point(3, 41)
        Me.gpxSearchFields.Name = "gpxSearchFields"
        Me.gpxSearchFields.Size = New System.Drawing.Size(287, 430)
        Me.gpxSearchFields.TabIndex = 0
        Me.gpxSearchFields.TabStop = False
        Me.gpxSearchFields.Text = "View By Carbon / Size"
        '
        'chkAllTypes
        '
        Me.chkAllTypes.AutoSize = True
        Me.chkAllTypes.Location = New System.Drawing.Point(102, 54)
        Me.chkAllTypes.Name = "chkAllTypes"
        Me.chkAllTypes.Size = New System.Drawing.Size(163, 24)
        Me.chkAllTypes.TabIndex = 18
        Me.chkAllTypes.Text = "All Types for Grade"
        Me.chkAllTypes.UseVisualStyleBackColor = True
        '
        'cboHeatNumber
        '
        Me.cboHeatNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHeatNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHeatNumber.DataSource = Me.CharterSteelCoilIdentificationBindingSource
        Me.cboHeatNumber.FormattingEnabled = True
        Me.cboHeatNumber.Location = New System.Drawing.Point(102, 116)
        Me.cboHeatNumber.Name = "cboHeatNumber"
        Me.cboHeatNumber.Size = New System.Drawing.Size(178, 28)
        Me.cboHeatNumber.TabIndex = 3
        '
        'CharterSteelCoilIdentificationBindingSource
        '
        Me.CharterSteelCoilIdentificationBindingSource.DataMember = "CharterSteelCoilIdentification"
        Me.CharterSteelCoilIdentificationBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lblTotalCoils
        '
        Me.lblTotalCoils.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCoils.Location = New System.Drawing.Point(114, 337)
        Me.lblTotalCoils.Name = "lblTotalCoils"
        Me.lblTotalCoils.Size = New System.Drawing.Size(166, 33)
        Me.lblTotalCoils.TabIndex = 181
        Me.lblTotalCoils.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 346)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 180
        Me.Label3.Text = "Total Coils"
        '
        'cboPONumber
        '
        Me.cboPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPONumber.FormattingEnabled = True
        Me.cboPONumber.Location = New System.Drawing.Point(102, 216)
        Me.cboPONumber.Name = "cboPONumber"
        Me.cboPONumber.Size = New System.Drawing.Size(178, 28)
        Me.cboPONumber.TabIndex = 6
        '
        'lblTotalWeight
        '
        Me.lblTotalWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalWeight.Location = New System.Drawing.Point(114, 379)
        Me.lblTotalWeight.Name = "lblTotalWeight"
        Me.lblTotalWeight.Size = New System.Drawing.Size(166, 33)
        Me.lblTotalWeight.TabIndex = 179
        Me.lblTotalWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 388)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 16)
        Me.Label1.TabIndex = 178
        Me.Label1.Text = "Total Weight"
        '
        'cboStatus
        '
        Me.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OPEN", "RAW", "WIP", "CLOSED"})
        Me.cboStatus.Location = New System.Drawing.Point(102, 182)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(178, 28)
        Me.cboStatus.TabIndex = 5
        '
        'txtDespatchNumber
        '
        Me.txtDespatchNumber.Location = New System.Drawing.Point(102, 150)
        Me.txtDespatchNumber.Name = "txtDespatchNumber"
        Me.txtDespatchNumber.Size = New System.Drawing.Size(178, 26)
        Me.txtDespatchNumber.TabIndex = 4
        '
        'txtSteelSize
        '
        Me.txtSteelSize.Location = New System.Drawing.Point(102, 84)
        Me.txtSteelSize.Name = "txtSteelSize"
        Me.txtSteelSize.Size = New System.Drawing.Size(178, 26)
        Me.txtSteelSize.TabIndex = 2
        '
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(102, 19)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(178, 28)
        Me.cboCarbon.TabIndex = 1
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(180, 257)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(100, 50)
        Me.cmdClear.TabIndex = 8
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(74, 257)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(100, 50)
        Me.cmdView.TabIndex = 7
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'lblPurchaseOrderNumber
        '
        Me.lblPurchaseOrderNumber.Location = New System.Drawing.Point(3, 217)
        Me.lblPurchaseOrderNumber.Name = "lblPurchaseOrderNumber"
        Me.lblPurchaseOrderNumber.Size = New System.Drawing.Size(97, 25)
        Me.lblPurchaseOrderNumber.TabIndex = 17
        Me.lblPurchaseOrderNumber.Text = "PO #"
        Me.lblPurchaseOrderNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCoilStatus
        '
        Me.lblCoilStatus.Location = New System.Drawing.Point(3, 182)
        Me.lblCoilStatus.Name = "lblCoilStatus"
        Me.lblCoilStatus.Size = New System.Drawing.Size(72, 20)
        Me.lblCoilStatus.TabIndex = 16
        Me.lblCoilStatus.Text = "Status"
        Me.lblCoilStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHeatNumber
        '
        Me.lblHeatNumber.Location = New System.Drawing.Point(3, 116)
        Me.lblHeatNumber.Name = "lblHeatNumber"
        Me.lblHeatNumber.Size = New System.Drawing.Size(65, 20)
        Me.lblHeatNumber.TabIndex = 14
        Me.lblHeatNumber.Text = "Heat #"
        Me.lblHeatNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSteelSize
        '
        Me.lblSteelSize.Location = New System.Drawing.Point(3, 87)
        Me.lblSteelSize.Name = "lblSteelSize"
        Me.lblSteelSize.Size = New System.Drawing.Size(100, 20)
        Me.lblSteelSize.TabIndex = 13
        Me.lblSteelSize.Text = "Steel Size"
        Me.lblSteelSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCarbon
        '
        Me.lblCarbon.Location = New System.Drawing.Point(3, 22)
        Me.lblCarbon.Name = "lblCarbon"
        Me.lblCarbon.Size = New System.Drawing.Size(100, 20)
        Me.lblCarbon.TabIndex = 12
        Me.lblCarbon.Text = "Carbon"
        Me.lblCarbon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDespatchNumber
        '
        Me.lblDespatchNumber.Location = New System.Drawing.Point(3, 150)
        Me.lblDespatchNumber.Name = "lblDespatchNumber"
        Me.lblDespatchNumber.Size = New System.Drawing.Size(100, 20)
        Me.lblDespatchNumber.TabIndex = 15
        Me.lblDespatchNumber.Text = "Despatch #"
        Me.lblDespatchNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RawMaterialsTableBindingSource
        '
        Me.RawMaterialsTableBindingSource.DataMember = "RawMaterialsTable"
        Me.RawMaterialsTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'HeatNumberLogBindingSource
        '
        Me.HeatNumberLogBindingSource.DataMember = "HeatNumberLog"
        Me.HeatNumberLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvCharterCoils
        '
        Me.dgvCharterCoils.AllowUserToAddRows = False
        Me.dgvCharterCoils.AllowUserToDeleteRows = False
        Me.dgvCharterCoils.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCharterCoils.AutoGenerateColumns = False
        Me.dgvCharterCoils.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvCharterCoils.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCharterCoils.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCharterCoils.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CoilID, Me.Carbon, Me.SteelSize, Me.HeatNumber, Me.Weight, Me.ReceiveDate, Me.SalesOrderNumber, Me.Description, Me.AnnealLot, Me.Comment, Me.Location, Me.Status})
        Me.dgvCharterCoils.DataSource = Me.CharterSteelCoilIdentificationBindingSource
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCharterCoils.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCharterCoils.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvCharterCoils.Location = New System.Drawing.Point(296, 41)
        Me.dgvCharterCoils.MultiSelect = False
        Me.dgvCharterCoils.Name = "dgvCharterCoils"
        Me.dgvCharterCoils.ReadOnly = True
        Me.dgvCharterCoils.RowHeadersVisible = False
        Me.dgvCharterCoils.Size = New System.Drawing.Size(914, 434)
        Me.dgvCharterCoils.TabIndex = 7
        Me.dgvCharterCoils.TabStop = False
        '
        'CoilID
        '
        Me.CoilID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CoilID.DataPropertyName = "CoilID"
        Me.CoilID.HeaderText = "Coil ID"
        Me.CoilID.Name = "CoilID"
        Me.CoilID.ReadOnly = True
        Me.CoilID.Width = 63
        '
        'Carbon
        '
        Me.Carbon.DataPropertyName = "Carbon"
        Me.Carbon.HeaderText = "Carbon"
        Me.Carbon.Name = "Carbon"
        Me.Carbon.ReadOnly = True
        Me.Carbon.Width = 72
        '
        'SteelSize
        '
        Me.SteelSize.DataPropertyName = "SteelSize"
        Me.SteelSize.HeaderText = "Steel Size"
        Me.SteelSize.Name = "SteelSize"
        Me.SteelSize.ReadOnly = True
        Me.SteelSize.Width = 71
        '
        'HeatNumber
        '
        Me.HeatNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.HeatNumber.DataPropertyName = "HeatNumber"
        Me.HeatNumber.HeaderText = "Heat Number"
        Me.HeatNumber.Name = "HeatNumber"
        Me.HeatNumber.ReadOnly = True
        Me.HeatNumber.Width = 95
        '
        'Weight
        '
        Me.Weight.DataPropertyName = "Weight"
        Me.Weight.HeaderText = "Weight"
        Me.Weight.Name = "Weight"
        Me.Weight.ReadOnly = True
        Me.Weight.Width = 72
        '
        'ReceiveDate
        '
        Me.ReceiveDate.DataPropertyName = "ReceiveDate"
        Me.ReceiveDate.HeaderText = "Receive Date"
        Me.ReceiveDate.Name = "ReceiveDate"
        Me.ReceiveDate.ReadOnly = True
        Me.ReceiveDate.Width = 71
        '
        'SalesOrderNumber
        '
        Me.SalesOrderNumber.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumber.HeaderText = "SO Number"
        Me.SalesOrderNumber.Name = "SalesOrderNumber"
        Me.SalesOrderNumber.ReadOnly = True
        Me.SalesOrderNumber.Visible = False
        '
        'Description
        '
        Me.Description.DataPropertyName = "Description"
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Visible = False
        '
        'AnnealLot
        '
        Me.AnnealLot.DataPropertyName = "AnnealLot"
        Me.AnnealLot.HeaderText = "Anneal Lot"
        Me.AnnealLot.Name = "AnnealLot"
        Me.AnnealLot.ReadOnly = True
        '
        'Comment
        '
        Me.Comment.DataPropertyName = "Comment"
        Me.Comment.HeaderText = "Comment"
        Me.Comment.Name = "Comment"
        Me.Comment.ReadOnly = True
        '
        'Location
        '
        Me.Location.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Location.DataPropertyName = "Location"
        Me.Location.HeaderText = "Location"
        Me.Location.Name = "Location"
        Me.Location.ReadOnly = True
        Me.Location.Width = 73
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 71
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(510, 124)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 20)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Division ID"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'CharterSteelCoilIdentificationTableAdapter
        '
        Me.CharterSteelCoilIdentificationTableAdapter.ClearBeforeFill = True
        '
        'HeatNumberLogTableAdapter
        '
        Me.HeatNumberLogTableAdapter.ClearBeforeFill = True
        '
        'gpxKeyboard
        '
        Me.gpxKeyboard.Controls.Add(Me.cmdBackspace)
        Me.gpxKeyboard.Controls.Add(Me.cmdKeyboardPrint)
        Me.gpxKeyboard.Controls.Add(Me.cmdKeyboardExit)
        Me.gpxKeyboard.Controls.Add(Me.cmdNine)
        Me.gpxKeyboard.Controls.Add(Me.cmdEnter)
        Me.gpxKeyboard.Controls.Add(Me.cmdEight)
        Me.gpxKeyboard.Controls.Add(Me.cmdSeven)
        Me.gpxKeyboard.Controls.Add(Me.cmdSix)
        Me.gpxKeyboard.Controls.Add(Me.cmdFive)
        Me.gpxKeyboard.Controls.Add(Me.cmdFour)
        Me.gpxKeyboard.Controls.Add(Me.cmdThree)
        Me.gpxKeyboard.Controls.Add(Me.cmdTwo)
        Me.gpxKeyboard.Controls.Add(Me.cmdOne)
        Me.gpxKeyboard.Controls.Add(Me.cmdZero)
        Me.gpxKeyboard.Controls.Add(Me.cmdSpace)
        Me.gpxKeyboard.Controls.Add(Me.cmdM)
        Me.gpxKeyboard.Controls.Add(Me.cmdN)
        Me.gpxKeyboard.Controls.Add(Me.cmdB)
        Me.gpxKeyboard.Controls.Add(Me.cmdV)
        Me.gpxKeyboard.Controls.Add(Me.cmdC)
        Me.gpxKeyboard.Controls.Add(Me.cmdX)
        Me.gpxKeyboard.Controls.Add(Me.cmdL)
        Me.gpxKeyboard.Controls.Add(Me.cmdK)
        Me.gpxKeyboard.Controls.Add(Me.cmdJ)
        Me.gpxKeyboard.Controls.Add(Me.cmdH)
        Me.gpxKeyboard.Controls.Add(Me.cmdG)
        Me.gpxKeyboard.Controls.Add(Me.cmdF)
        Me.gpxKeyboard.Controls.Add(Me.cmdD)
        Me.gpxKeyboard.Controls.Add(Me.cmdS)
        Me.gpxKeyboard.Controls.Add(Me.cmdZ)
        Me.gpxKeyboard.Controls.Add(Me.cmdP)
        Me.gpxKeyboard.Controls.Add(Me.cmdO)
        Me.gpxKeyboard.Controls.Add(Me.cmdI)
        Me.gpxKeyboard.Controls.Add(Me.cmdU)
        Me.gpxKeyboard.Controls.Add(Me.cmdY)
        Me.gpxKeyboard.Controls.Add(Me.cmdT)
        Me.gpxKeyboard.Controls.Add(Me.cmdR)
        Me.gpxKeyboard.Controls.Add(Me.cmdE)
        Me.gpxKeyboard.Controls.Add(Me.cmdW)
        Me.gpxKeyboard.Controls.Add(Me.cmdQ)
        Me.gpxKeyboard.Controls.Add(Me.cmdDash)
        Me.gpxKeyboard.Controls.Add(Me.cmdForwardSlash)
        Me.gpxKeyboard.Controls.Add(Me.cmdA)
        Me.gpxKeyboard.Controls.Add(Me.cmdDecimal)
        Me.gpxKeyboard.Location = New System.Drawing.Point(0, 486)
        Me.gpxKeyboard.Name = "gpxKeyboard"
        Me.gpxKeyboard.Size = New System.Drawing.Size(1171, 241)
        Me.gpxKeyboard.TabIndex = 176
        Me.gpxKeyboard.TabStop = False
        Me.gpxKeyboard.Text = "Keyboard"
        '
        'cmdBackspace
        '
        Me.cmdBackspace.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdBackspace.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBackspace.Location = New System.Drawing.Point(1065, 12)
        Me.cmdBackspace.Name = "cmdBackspace"
        Me.cmdBackspace.Size = New System.Drawing.Size(100, 50)
        Me.cmdBackspace.TabIndex = 176
        Me.cmdBackspace.Text = "Backspace"
        Me.cmdBackspace.UseVisualStyleBackColor = True
        '
        'cmdKeyboardPrint
        '
        Me.cmdKeyboardPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdKeyboardPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdKeyboardPrint.Location = New System.Drawing.Point(1065, 124)
        Me.cmdKeyboardPrint.Name = "cmdKeyboardPrint"
        Me.cmdKeyboardPrint.Size = New System.Drawing.Size(100, 50)
        Me.cmdKeyboardPrint.TabIndex = 174
        Me.cmdKeyboardPrint.Text = "Print"
        Me.cmdKeyboardPrint.UseVisualStyleBackColor = True
        '
        'cmdKeyboardExit
        '
        Me.cmdKeyboardExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdKeyboardExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdKeyboardExit.Location = New System.Drawing.Point(1065, 180)
        Me.cmdKeyboardExit.Name = "cmdKeyboardExit"
        Me.cmdKeyboardExit.Size = New System.Drawing.Size(100, 50)
        Me.cmdKeyboardExit.TabIndex = 175
        Me.cmdKeyboardExit.Text = "Exit"
        Me.cmdKeyboardExit.UseVisualStyleBackColor = True
        '
        'cmdNine
        '
        Me.cmdNine.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNine.Location = New System.Drawing.Point(961, 11)
        Me.cmdNine.Name = "cmdNine"
        Me.cmdNine.Size = New System.Drawing.Size(100, 50)
        Me.cmdNine.TabIndex = 173
        Me.cmdNine.TabStop = False
        Me.cmdNine.Text = "9"
        Me.cmdNine.UseVisualStyleBackColor = True
        '
        'cmdEnter
        '
        Me.cmdEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEnter.Location = New System.Drawing.Point(1065, 68)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(100, 50)
        Me.cmdEnter.TabIndex = 167
        Me.cmdEnter.TabStop = False
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'cmdEight
        '
        Me.cmdEight.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEight.Location = New System.Drawing.Point(854, 12)
        Me.cmdEight.Name = "cmdEight"
        Me.cmdEight.Size = New System.Drawing.Size(100, 50)
        Me.cmdEight.TabIndex = 172
        Me.cmdEight.TabStop = False
        Me.cmdEight.Text = "8"
        Me.cmdEight.UseVisualStyleBackColor = True
        '
        'cmdSeven
        '
        Me.cmdSeven.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSeven.Location = New System.Drawing.Point(748, 11)
        Me.cmdSeven.Name = "cmdSeven"
        Me.cmdSeven.Size = New System.Drawing.Size(100, 50)
        Me.cmdSeven.TabIndex = 171
        Me.cmdSeven.TabStop = False
        Me.cmdSeven.Text = "7"
        Me.cmdSeven.UseVisualStyleBackColor = True
        '
        'cmdSix
        '
        Me.cmdSix.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSix.Location = New System.Drawing.Point(642, 11)
        Me.cmdSix.Name = "cmdSix"
        Me.cmdSix.Size = New System.Drawing.Size(100, 50)
        Me.cmdSix.TabIndex = 170
        Me.cmdSix.TabStop = False
        Me.cmdSix.Text = "6"
        Me.cmdSix.UseVisualStyleBackColor = True
        '
        'cmdFive
        '
        Me.cmdFive.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFive.Location = New System.Drawing.Point(536, 12)
        Me.cmdFive.Name = "cmdFive"
        Me.cmdFive.Size = New System.Drawing.Size(100, 50)
        Me.cmdFive.TabIndex = 169
        Me.cmdFive.TabStop = False
        Me.cmdFive.Text = "5"
        Me.cmdFive.UseVisualStyleBackColor = True
        '
        'cmdFour
        '
        Me.cmdFour.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFour.Location = New System.Drawing.Point(430, 11)
        Me.cmdFour.Name = "cmdFour"
        Me.cmdFour.Size = New System.Drawing.Size(100, 50)
        Me.cmdFour.TabIndex = 168
        Me.cmdFour.TabStop = False
        Me.cmdFour.Text = "4"
        Me.cmdFour.UseVisualStyleBackColor = True
        '
        'cmdThree
        '
        Me.cmdThree.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThree.Location = New System.Drawing.Point(324, 11)
        Me.cmdThree.Name = "cmdThree"
        Me.cmdThree.Size = New System.Drawing.Size(100, 50)
        Me.cmdThree.TabIndex = 166
        Me.cmdThree.TabStop = False
        Me.cmdThree.Text = "3"
        Me.cmdThree.UseVisualStyleBackColor = True
        '
        'cmdTwo
        '
        Me.cmdTwo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTwo.Location = New System.Drawing.Point(218, 12)
        Me.cmdTwo.Name = "cmdTwo"
        Me.cmdTwo.Size = New System.Drawing.Size(100, 50)
        Me.cmdTwo.TabIndex = 165
        Me.cmdTwo.TabStop = False
        Me.cmdTwo.Text = "2"
        Me.cmdTwo.UseVisualStyleBackColor = True
        '
        'cmdOne
        '
        Me.cmdOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOne.Location = New System.Drawing.Point(112, 12)
        Me.cmdOne.Name = "cmdOne"
        Me.cmdOne.Size = New System.Drawing.Size(100, 50)
        Me.cmdOne.TabIndex = 164
        Me.cmdOne.TabStop = False
        Me.cmdOne.Text = "1"
        Me.cmdOne.UseVisualStyleBackColor = True
        '
        'cmdZero
        '
        Me.cmdZero.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdZero.Location = New System.Drawing.Point(6, 12)
        Me.cmdZero.Name = "cmdZero"
        Me.cmdZero.Size = New System.Drawing.Size(100, 50)
        Me.cmdZero.TabIndex = 163
        Me.cmdZero.TabStop = False
        Me.cmdZero.Text = "0"
        Me.cmdZero.UseVisualStyleBackColor = True
        '
        'cmdSpace
        '
        Me.cmdSpace.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSpace.Location = New System.Drawing.Point(960, 180)
        Me.cmdSpace.Name = "cmdSpace"
        Me.cmdSpace.Size = New System.Drawing.Size(100, 50)
        Me.cmdSpace.TabIndex = 162
        Me.cmdSpace.TabStop = False
        Me.cmdSpace.Text = "SPACE"
        Me.cmdSpace.UseVisualStyleBackColor = True
        '
        'cmdM
        '
        Me.cmdM.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdM.Location = New System.Drawing.Point(642, 180)
        Me.cmdM.Name = "cmdM"
        Me.cmdM.Size = New System.Drawing.Size(100, 50)
        Me.cmdM.TabIndex = 161
        Me.cmdM.TabStop = False
        Me.cmdM.Text = "M"
        Me.cmdM.UseVisualStyleBackColor = True
        '
        'cmdN
        '
        Me.cmdN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdN.Location = New System.Drawing.Point(536, 180)
        Me.cmdN.Name = "cmdN"
        Me.cmdN.Size = New System.Drawing.Size(100, 50)
        Me.cmdN.TabIndex = 160
        Me.cmdN.TabStop = False
        Me.cmdN.Text = "N"
        Me.cmdN.UseVisualStyleBackColor = True
        '
        'cmdB
        '
        Me.cmdB.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdB.Location = New System.Drawing.Point(430, 180)
        Me.cmdB.Name = "cmdB"
        Me.cmdB.Size = New System.Drawing.Size(100, 50)
        Me.cmdB.TabIndex = 159
        Me.cmdB.TabStop = False
        Me.cmdB.Text = "B"
        Me.cmdB.UseVisualStyleBackColor = True
        '
        'cmdV
        '
        Me.cmdV.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdV.Location = New System.Drawing.Point(324, 181)
        Me.cmdV.Name = "cmdV"
        Me.cmdV.Size = New System.Drawing.Size(100, 50)
        Me.cmdV.TabIndex = 158
        Me.cmdV.TabStop = False
        Me.cmdV.Text = "V"
        Me.cmdV.UseVisualStyleBackColor = True
        '
        'cmdC
        '
        Me.cmdC.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdC.Location = New System.Drawing.Point(218, 180)
        Me.cmdC.Name = "cmdC"
        Me.cmdC.Size = New System.Drawing.Size(100, 50)
        Me.cmdC.TabIndex = 157
        Me.cmdC.TabStop = False
        Me.cmdC.Text = "C"
        Me.cmdC.UseVisualStyleBackColor = True
        '
        'cmdX
        '
        Me.cmdX.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdX.Location = New System.Drawing.Point(112, 180)
        Me.cmdX.Name = "cmdX"
        Me.cmdX.Size = New System.Drawing.Size(100, 50)
        Me.cmdX.TabIndex = 156
        Me.cmdX.TabStop = False
        Me.cmdX.Text = "X"
        Me.cmdX.UseVisualStyleBackColor = True
        '
        'cmdL
        '
        Me.cmdL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdL.Location = New System.Drawing.Point(854, 125)
        Me.cmdL.Name = "cmdL"
        Me.cmdL.Size = New System.Drawing.Size(100, 50)
        Me.cmdL.TabIndex = 155
        Me.cmdL.TabStop = False
        Me.cmdL.Text = "L"
        Me.cmdL.UseVisualStyleBackColor = True
        '
        'cmdK
        '
        Me.cmdK.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdK.Location = New System.Drawing.Point(748, 125)
        Me.cmdK.Name = "cmdK"
        Me.cmdK.Size = New System.Drawing.Size(100, 50)
        Me.cmdK.TabIndex = 154
        Me.cmdK.TabStop = False
        Me.cmdK.Text = "K"
        Me.cmdK.UseVisualStyleBackColor = True
        '
        'cmdJ
        '
        Me.cmdJ.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdJ.Location = New System.Drawing.Point(642, 125)
        Me.cmdJ.Name = "cmdJ"
        Me.cmdJ.Size = New System.Drawing.Size(100, 50)
        Me.cmdJ.TabIndex = 153
        Me.cmdJ.TabStop = False
        Me.cmdJ.Text = "J"
        Me.cmdJ.UseVisualStyleBackColor = True
        '
        'cmdH
        '
        Me.cmdH.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdH.Location = New System.Drawing.Point(536, 125)
        Me.cmdH.Name = "cmdH"
        Me.cmdH.Size = New System.Drawing.Size(100, 50)
        Me.cmdH.TabIndex = 152
        Me.cmdH.TabStop = False
        Me.cmdH.Text = "H"
        Me.cmdH.UseVisualStyleBackColor = True
        '
        'cmdG
        '
        Me.cmdG.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdG.Location = New System.Drawing.Point(430, 125)
        Me.cmdG.Name = "cmdG"
        Me.cmdG.Size = New System.Drawing.Size(100, 50)
        Me.cmdG.TabIndex = 151
        Me.cmdG.TabStop = False
        Me.cmdG.Text = "G"
        Me.cmdG.UseVisualStyleBackColor = True
        '
        'cmdF
        '
        Me.cmdF.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdF.Location = New System.Drawing.Point(324, 125)
        Me.cmdF.Name = "cmdF"
        Me.cmdF.Size = New System.Drawing.Size(100, 50)
        Me.cmdF.TabIndex = 150
        Me.cmdF.TabStop = False
        Me.cmdF.Text = "F"
        Me.cmdF.UseVisualStyleBackColor = True
        '
        'cmdD
        '
        Me.cmdD.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdD.Location = New System.Drawing.Point(218, 124)
        Me.cmdD.Name = "cmdD"
        Me.cmdD.Size = New System.Drawing.Size(100, 50)
        Me.cmdD.TabIndex = 149
        Me.cmdD.TabStop = False
        Me.cmdD.Text = "D"
        Me.cmdD.UseVisualStyleBackColor = True
        '
        'cmdS
        '
        Me.cmdS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdS.Location = New System.Drawing.Point(112, 124)
        Me.cmdS.Name = "cmdS"
        Me.cmdS.Size = New System.Drawing.Size(100, 50)
        Me.cmdS.TabIndex = 148
        Me.cmdS.TabStop = False
        Me.cmdS.Text = "S"
        Me.cmdS.UseVisualStyleBackColor = True
        '
        'cmdZ
        '
        Me.cmdZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdZ.Location = New System.Drawing.Point(6, 180)
        Me.cmdZ.Name = "cmdZ"
        Me.cmdZ.Size = New System.Drawing.Size(100, 50)
        Me.cmdZ.TabIndex = 147
        Me.cmdZ.TabStop = False
        Me.cmdZ.Text = "Z"
        Me.cmdZ.UseVisualStyleBackColor = True
        '
        'cmdP
        '
        Me.cmdP.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdP.Location = New System.Drawing.Point(961, 69)
        Me.cmdP.Name = "cmdP"
        Me.cmdP.Size = New System.Drawing.Size(100, 50)
        Me.cmdP.TabIndex = 146
        Me.cmdP.TabStop = False
        Me.cmdP.Text = "P"
        Me.cmdP.UseVisualStyleBackColor = True
        '
        'cmdO
        '
        Me.cmdO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdO.Location = New System.Drawing.Point(854, 68)
        Me.cmdO.Name = "cmdO"
        Me.cmdO.Size = New System.Drawing.Size(100, 50)
        Me.cmdO.TabIndex = 145
        Me.cmdO.TabStop = False
        Me.cmdO.Text = "O"
        Me.cmdO.UseVisualStyleBackColor = True
        '
        'cmdI
        '
        Me.cmdI.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdI.Location = New System.Drawing.Point(748, 69)
        Me.cmdI.Name = "cmdI"
        Me.cmdI.Size = New System.Drawing.Size(100, 50)
        Me.cmdI.TabIndex = 144
        Me.cmdI.TabStop = False
        Me.cmdI.Text = "I"
        Me.cmdI.UseVisualStyleBackColor = True
        '
        'cmdU
        '
        Me.cmdU.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdU.Location = New System.Drawing.Point(642, 69)
        Me.cmdU.Name = "cmdU"
        Me.cmdU.Size = New System.Drawing.Size(100, 50)
        Me.cmdU.TabIndex = 143
        Me.cmdU.TabStop = False
        Me.cmdU.Text = "U"
        Me.cmdU.UseVisualStyleBackColor = True
        '
        'cmdY
        '
        Me.cmdY.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdY.Location = New System.Drawing.Point(536, 69)
        Me.cmdY.Name = "cmdY"
        Me.cmdY.Size = New System.Drawing.Size(100, 50)
        Me.cmdY.TabIndex = 142
        Me.cmdY.TabStop = False
        Me.cmdY.Text = "Y"
        Me.cmdY.UseVisualStyleBackColor = True
        '
        'cmdT
        '
        Me.cmdT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdT.Location = New System.Drawing.Point(430, 69)
        Me.cmdT.Name = "cmdT"
        Me.cmdT.Size = New System.Drawing.Size(100, 50)
        Me.cmdT.TabIndex = 141
        Me.cmdT.TabStop = False
        Me.cmdT.Text = "T"
        Me.cmdT.UseVisualStyleBackColor = True
        '
        'cmdR
        '
        Me.cmdR.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdR.Location = New System.Drawing.Point(324, 69)
        Me.cmdR.Name = "cmdR"
        Me.cmdR.Size = New System.Drawing.Size(100, 50)
        Me.cmdR.TabIndex = 140
        Me.cmdR.TabStop = False
        Me.cmdR.Text = "R"
        Me.cmdR.UseVisualStyleBackColor = True
        '
        'cmdE
        '
        Me.cmdE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdE.Location = New System.Drawing.Point(218, 68)
        Me.cmdE.Name = "cmdE"
        Me.cmdE.Size = New System.Drawing.Size(100, 50)
        Me.cmdE.TabIndex = 139
        Me.cmdE.TabStop = False
        Me.cmdE.Text = "E"
        Me.cmdE.UseVisualStyleBackColor = True
        '
        'cmdW
        '
        Me.cmdW.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdW.Location = New System.Drawing.Point(112, 68)
        Me.cmdW.Name = "cmdW"
        Me.cmdW.Size = New System.Drawing.Size(100, 50)
        Me.cmdW.TabIndex = 138
        Me.cmdW.TabStop = False
        Me.cmdW.Text = "W"
        Me.cmdW.UseVisualStyleBackColor = True
        '
        'cmdQ
        '
        Me.cmdQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdQ.Location = New System.Drawing.Point(6, 68)
        Me.cmdQ.Name = "cmdQ"
        Me.cmdQ.Size = New System.Drawing.Size(100, 50)
        Me.cmdQ.TabIndex = 137
        Me.cmdQ.TabStop = False
        Me.cmdQ.Text = "Q"
        Me.cmdQ.UseVisualStyleBackColor = True
        '
        'cmdDash
        '
        Me.cmdDash.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDash.Location = New System.Drawing.Point(854, 180)
        Me.cmdDash.Name = "cmdDash"
        Me.cmdDash.Size = New System.Drawing.Size(100, 50)
        Me.cmdDash.TabIndex = 136
        Me.cmdDash.TabStop = False
        Me.cmdDash.Text = "-"
        Me.cmdDash.UseVisualStyleBackColor = True
        '
        'cmdForwardSlash
        '
        Me.cmdForwardSlash.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdForwardSlash.Location = New System.Drawing.Point(748, 180)
        Me.cmdForwardSlash.Name = "cmdForwardSlash"
        Me.cmdForwardSlash.Size = New System.Drawing.Size(100, 50)
        Me.cmdForwardSlash.TabIndex = 135
        Me.cmdForwardSlash.TabStop = False
        Me.cmdForwardSlash.Text = "/"
        Me.cmdForwardSlash.UseVisualStyleBackColor = True
        '
        'cmdA
        '
        Me.cmdA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdA.Location = New System.Drawing.Point(6, 124)
        Me.cmdA.Name = "cmdA"
        Me.cmdA.Size = New System.Drawing.Size(100, 50)
        Me.cmdA.TabIndex = 134
        Me.cmdA.TabStop = False
        Me.cmdA.Text = "A"
        Me.cmdA.UseVisualStyleBackColor = True
        '
        'cmdDecimal
        '
        Me.cmdDecimal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDecimal.Location = New System.Drawing.Point(961, 125)
        Me.cmdDecimal.Name = "cmdDecimal"
        Me.cmdDecimal.Size = New System.Drawing.Size(100, 50)
        Me.cmdDecimal.TabIndex = 133
        Me.cmdDecimal.TabStop = False
        Me.cmdDecimal.Text = "."
        Me.cmdDecimal.UseVisualStyleBackColor = True
        '
        'lstCarbonSuggest
        '
        Me.lstCarbonSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCarbonSuggest.FormattingEnabled = True
        Me.lstCarbonSuggest.ItemHeight = 20
        Me.lstCarbonSuggest.Location = New System.Drawing.Point(105, 88)
        Me.lstCarbonSuggest.Name = "lstCarbonSuggest"
        Me.lstCarbonSuggest.Size = New System.Drawing.Size(159, 84)
        Me.lstCarbonSuggest.TabIndex = 102
        Me.lstCarbonSuggest.TabStop = False
        Me.lstCarbonSuggest.Visible = False
        '
        'lstHeatSuggest
        '
        Me.lstHeatSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstHeatSuggest.FormattingEnabled = True
        Me.lstHeatSuggest.ItemHeight = 20
        Me.lstHeatSuggest.Location = New System.Drawing.Point(105, 185)
        Me.lstHeatSuggest.Name = "lstHeatSuggest"
        Me.lstHeatSuggest.Size = New System.Drawing.Size(143, 84)
        Me.lstHeatSuggest.TabIndex = 177
        Me.lstHeatSuggest.TabStop = False
        Me.lstHeatSuggest.Visible = False
        '
        'pnlChangeLocation
        '
        Me.pnlChangeLocation.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlChangeLocation.Controls.Add(Me.cmdCancelLocationChange)
        Me.pnlChangeLocation.Controls.Add(Me.txtLocationValue)
        Me.pnlChangeLocation.Controls.Add(Me.cmdChangeLocationValue)
        Me.pnlChangeLocation.Location = New System.Drawing.Point(542, 169)
        Me.pnlChangeLocation.Name = "pnlChangeLocation"
        Me.pnlChangeLocation.Size = New System.Drawing.Size(383, 179)
        Me.pnlChangeLocation.TabIndex = 178
        Me.pnlChangeLocation.Visible = False
        '
        'cmdCancelLocationChange
        '
        Me.cmdCancelLocationChange.Location = New System.Drawing.Point(234, 88)
        Me.cmdCancelLocationChange.Name = "cmdCancelLocationChange"
        Me.cmdCancelLocationChange.Size = New System.Drawing.Size(100, 50)
        Me.cmdCancelLocationChange.TabIndex = 183
        Me.cmdCancelLocationChange.Text = "Cancel"
        Me.cmdCancelLocationChange.UseVisualStyleBackColor = True
        '
        'txtLocationValue
        '
        Me.txtLocationValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtLocationValue.Location = New System.Drawing.Point(58, 28)
        Me.txtLocationValue.Name = "txtLocationValue"
        Me.txtLocationValue.Size = New System.Drawing.Size(276, 26)
        Me.txtLocationValue.TabIndex = 0
        '
        'cmdChangeLocationValue
        '
        Me.cmdChangeLocationValue.Location = New System.Drawing.Point(58, 88)
        Me.cmdChangeLocationValue.Name = "cmdChangeLocationValue"
        Me.cmdChangeLocationValue.Size = New System.Drawing.Size(100, 50)
        Me.cmdChangeLocationValue.TabIndex = 182
        Me.cmdChangeLocationValue.Text = "Change"
        Me.cmdChangeLocationValue.UseVisualStyleBackColor = True
        '
        'ViewCharterSteelCoils
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1220, 723)
        Me.Controls.Add(Me.pnlChangeLocation)
        Me.Controls.Add(Me.lstCarbonSuggest)
        Me.Controls.Add(Me.lstHeatSuggest)
        Me.Controls.Add(Me.gpxKeyboard)
        Me.Controls.Add(Me.dgvCharterCoils)
        Me.Controls.Add(Me.gpxSearchFields)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Label7)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewCharterSteelCoils"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Charter Steel Coil Entry"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxSearchFields.ResumeLayout(False)
        Me.gpxSearchFields.PerformLayout()
        CType(Me.CharterSteelCoilIdentificationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelPurchaseOrderHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCharterCoils, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxKeyboard.ResumeLayout(False)
        Me.pnlChangeLocation.ResumeLayout(False)
        Me.pnlChangeLocation.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxSearchFields As System.Windows.Forms.GroupBox
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents DateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SizeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvCharterCoils As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents cboSteelCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents lblHeatNumber As System.Windows.Forms.Label
    Friend WithEvents lblSteelSize As System.Windows.Forms.Label
    Friend WithEvents lblCarbon As System.Windows.Forms.Label
    Friend WithEvents cmdByShipmentView As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents lblDespatchNumber As System.Windows.Forms.Label
    Friend WithEvents CharterSteelCoilIdentificationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CharterSteelCoilIdentificationTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CharterSteelCoilIdentificationTableAdapter
    Friend WithEvents lblCoilStatus As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents HeatNumberLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HeatNumberLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
    Friend WithEvents lblPurchaseOrderNumber As System.Windows.Forms.Label
    Friend WithEvents txtSteelSize As System.Windows.Forms.TextBox
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents txtDespatchNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboPONumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboHeatNumber As System.Windows.Forms.ComboBox
    Friend WithEvents SteelPurchaseOrderHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents gpxKeyboard As System.Windows.Forms.GroupBox
    Friend WithEvents cmdKeyboardPrint As System.Windows.Forms.Button
    Friend WithEvents cmdKeyboardExit As System.Windows.Forms.Button
    Friend WithEvents cmdNine As System.Windows.Forms.Button
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents cmdEight As System.Windows.Forms.Button
    Friend WithEvents cmdSeven As System.Windows.Forms.Button
    Friend WithEvents cmdSix As System.Windows.Forms.Button
    Friend WithEvents cmdFive As System.Windows.Forms.Button
    Friend WithEvents cmdFour As System.Windows.Forms.Button
    Friend WithEvents cmdThree As System.Windows.Forms.Button
    Friend WithEvents cmdTwo As System.Windows.Forms.Button
    Friend WithEvents cmdOne As System.Windows.Forms.Button
    Friend WithEvents cmdZero As System.Windows.Forms.Button
    Friend WithEvents cmdSpace As System.Windows.Forms.Button
    Friend WithEvents cmdM As System.Windows.Forms.Button
    Friend WithEvents cmdN As System.Windows.Forms.Button
    Friend WithEvents cmdB As System.Windows.Forms.Button
    Friend WithEvents cmdV As System.Windows.Forms.Button
    Friend WithEvents cmdC As System.Windows.Forms.Button
    Friend WithEvents cmdX As System.Windows.Forms.Button
    Friend WithEvents cmdL As System.Windows.Forms.Button
    Friend WithEvents cmdK As System.Windows.Forms.Button
    Friend WithEvents cmdJ As System.Windows.Forms.Button
    Friend WithEvents cmdH As System.Windows.Forms.Button
    Friend WithEvents cmdG As System.Windows.Forms.Button
    Friend WithEvents cmdF As System.Windows.Forms.Button
    Friend WithEvents cmdD As System.Windows.Forms.Button
    Friend WithEvents cmdS As System.Windows.Forms.Button
    Friend WithEvents cmdZ As System.Windows.Forms.Button
    Friend WithEvents cmdP As System.Windows.Forms.Button
    Friend WithEvents cmdO As System.Windows.Forms.Button
    Friend WithEvents cmdI As System.Windows.Forms.Button
    Friend WithEvents cmdU As System.Windows.Forms.Button
    Friend WithEvents cmdY As System.Windows.Forms.Button
    Friend WithEvents cmdT As System.Windows.Forms.Button
    Friend WithEvents cmdR As System.Windows.Forms.Button
    Friend WithEvents cmdE As System.Windows.Forms.Button
    Friend WithEvents cmdW As System.Windows.Forms.Button
    Friend WithEvents cmdQ As System.Windows.Forms.Button
    Friend WithEvents cmdDash As System.Windows.Forms.Button
    Friend WithEvents cmdForwardSlash As System.Windows.Forms.Button
    Friend WithEvents cmdA As System.Windows.Forms.Button
    Friend WithEvents cmdDecimal As System.Windows.Forms.Button
    Friend WithEvents lstCarbonSuggest As System.Windows.Forms.ListBox
    Friend WithEvents cmdBackspace As System.Windows.Forms.Button
    Friend WithEvents lstHeatSuggest As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTotalWeight As System.Windows.Forms.Label
    Friend WithEvents lblTotalCoils As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkAllTypes As System.Windows.Forms.CheckBox
    Friend WithEvents pnlChangeLocation As System.Windows.Forms.Panel
    Friend WithEvents cmdCancelLocationChange As System.Windows.Forms.Button
    Friend WithEvents txtLocationValue As System.Windows.Forms.TextBox
    Friend WithEvents cmdChangeLocationValue As System.Windows.Forms.Button
    Friend WithEvents CoilID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Carbon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Weight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiveDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnnealLot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Location As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
