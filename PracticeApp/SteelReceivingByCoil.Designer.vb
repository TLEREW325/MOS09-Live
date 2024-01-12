<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SteelReceivingByCoil
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
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtpReceiverDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboSteelPONumber = New System.Windows.Forms.ComboBox
        Me.SteelPurchaseOrderHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboSteelReceivingNumber = New System.Windows.Forms.ComboBox
        Me.SteelReceivingHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdGenerateNewReceipt = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtSteelVendorID = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboSteelBOLNumber = New System.Windows.Forms.ComboBox
        Me.CharterSteelCoilIdentificationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.SteelPurchaseOrderHeaderTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelPurchaseOrderHeaderTableAdapter
        Me.SteelReceivingHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingHeaderTableTableAdapter
        Me.cmdSelectCoils = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dgvSteelReceivingLines = New System.Windows.Forms.DataGridView
        Me.SteelReceivingHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReceivingLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiveWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectForInvoiceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelPONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelPOLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReceivingLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SteelReceivingLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingLineTableTableAdapter
        Me.cmdClearAllData = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtTotalShipmentWeight = New System.Windows.Forms.TextBox
        Me.txtCoilsInShipment = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblSteelTotal = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblInvoiceTotal = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtOtherTotal = New System.Windows.Forms.TextBox
        Me.txtFreightTotal = New System.Windows.Forms.TextBox
        Me.gpxPostReceipt = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmdPostReceiver = New System.Windows.Forms.Button
        Me.SteelReturnCoilLinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SteelReturnCoilLinesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReturnCoilLinesTableAdapter
        Me.dgvSteelCoils = New System.Windows.Forms.DataGridView
        Me.SteelReceivingHeaderKeyColumnCL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReceivingLineKeyColumnCL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CoilIDColumnCL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CoilWeightColumnCL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumnCL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberColumnCL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POLineNumberColumnCL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCostPerPoundColumnCL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelExtendedAmountColumnCL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReceivingCoilLinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SteelReceivingCoilLinesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingCoilLinesTableAdapter
        Me.CharterSteelCoilIdentificationTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CharterSteelCoilIdentificationTableAdapter
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboDeleteLineNumber = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SteelPurchaseOrderHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.CharterSteelCoilIdentificationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvSteelReceivingLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelReceivingLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.gpxPostReceipt.SuspendLayout()
        CType(Me.SteelReturnCoilLinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSteelCoils, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelReceivingCoilLinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 0
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
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.ReportToolStripMenuItem.Text = "Report"
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpReceiverDate)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboSteelPONumber)
        Me.GroupBox1.Controls.Add(Me.txtStatus)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboSteelReceivingNumber)
        Me.GroupBox1.Controls.Add(Me.cmdGenerateNewReceipt)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 205)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Steel Receiving"
        '
        'dtpReceiverDate
        '
        Me.dtpReceiverDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReceiverDate.Location = New System.Drawing.Point(106, 99)
        Me.dtpReceiverDate.Name = "dtpReceiverDate"
        Me.dtpReceiverDate.Size = New System.Drawing.Size(177, 20)
        Me.dtpReceiverDate.TabIndex = 36
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(15, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 20)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Receiver Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(14, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 20)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Steel PO #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelPONumber
        '
        Me.cboSteelPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelPONumber.DataSource = Me.SteelPurchaseOrderHeaderBindingSource
        Me.cboSteelPONumber.DisplayMember = "SteelPurchaseOrderKey"
        Me.cboSteelPONumber.FormattingEnabled = True
        Me.cboSteelPONumber.Location = New System.Drawing.Point(106, 133)
        Me.cboSteelPONumber.Name = "cboSteelPONumber"
        Me.cboSteelPONumber.Size = New System.Drawing.Size(177, 21)
        Me.cboSteelPONumber.TabIndex = 35
        '
        'SteelPurchaseOrderHeaderBindingSource
        '
        Me.SteelPurchaseOrderHeaderBindingSource.DataMember = "SteelPurchaseOrderHeader"
        Me.SteelPurchaseOrderHeaderBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.White
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStatus.Location = New System.Drawing.Point(106, 168)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(177, 20)
        Me.txtStatus.TabIndex = 34
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 20)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Status"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelReceivingNumber
        '
        Me.cboSteelReceivingNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelReceivingNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelReceivingNumber.DataSource = Me.SteelReceivingHeaderTableBindingSource
        Me.cboSteelReceivingNumber.DisplayMember = "SteelReceivingHeaderKey"
        Me.cboSteelReceivingNumber.FormattingEnabled = True
        Me.cboSteelReceivingNumber.Location = New System.Drawing.Point(106, 64)
        Me.cboSteelReceivingNumber.Name = "cboSteelReceivingNumber"
        Me.cboSteelReceivingNumber.Size = New System.Drawing.Size(177, 21)
        Me.cboSteelReceivingNumber.TabIndex = 31
        '
        'SteelReceivingHeaderTableBindingSource
        '
        Me.SteelReceivingHeaderTableBindingSource.DataMember = "SteelReceivingHeaderTable"
        Me.SteelReceivingHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdGenerateNewReceipt
        '
        Me.cmdGenerateNewReceipt.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateNewReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateNewReceipt.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateNewReceipt.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateNewReceipt.Location = New System.Drawing.Point(74, 65)
        Me.cmdGenerateNewReceipt.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateNewReceipt.Name = "cmdGenerateNewReceipt"
        Me.cmdGenerateNewReceipt.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateNewReceipt.TabIndex = 30
        Me.cmdGenerateNewReceipt.TabStop = False
        Me.cmdGenerateNewReceipt.Text = ">>"
        Me.cmdGenerateNewReceipt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateNewReceipt.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(15, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 20)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Receipt #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(106, 29)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(177, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(14, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 20)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Division ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSteelVendorID)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cboSteelBOLNumber)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtComment)
        Me.GroupBox2.Controls.Add(Me.txtVendorName)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 252)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 342)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Steel PO Data"
        '
        'txtSteelVendorID
        '
        Me.txtSteelVendorID.BackColor = System.Drawing.Color.White
        Me.txtSteelVendorID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelVendorID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelVendorID.Location = New System.Drawing.Point(74, 29)
        Me.txtSteelVendorID.Name = "txtSteelVendorID"
        Me.txtSteelVendorID.ReadOnly = True
        Me.txtSteelVendorID.Size = New System.Drawing.Size(209, 20)
        Me.txtSteelVendorID.TabIndex = 41
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 305)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 20)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "BOL #"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelBOLNumber
        '
        Me.cboSteelBOLNumber.DataSource = Me.CharterSteelCoilIdentificationBindingSource
        Me.cboSteelBOLNumber.DisplayMember = "DespatchNumber"
        Me.cboSteelBOLNumber.FormattingEnabled = True
        Me.cboSteelBOLNumber.Location = New System.Drawing.Point(107, 304)
        Me.cboSteelBOLNumber.Name = "cboSteelBOLNumber"
        Me.cboSteelBOLNumber.Size = New System.Drawing.Size(177, 21)
        Me.cboSteelBOLNumber.TabIndex = 39
        '
        'CharterSteelCoilIdentificationBindingSource
        '
        Me.CharterSteelCoilIdentificationBindingSource.DataMember = "CharterSteelCoilIdentification"
        Me.CharterSteelCoilIdentificationBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(15, 144)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 20)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Comment"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComment
        '
        Me.txtComment.BackColor = System.Drawing.Color.White
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.Location = New System.Drawing.Point(18, 167)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(265, 115)
        Me.txtComment.TabIndex = 37
        '
        'txtVendorName
        '
        Me.txtVendorName.BackColor = System.Drawing.Color.White
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Location = New System.Drawing.Point(18, 67)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.ReadOnly = True
        Me.txtVendorName.Size = New System.Drawing.Size(265, 60)
        Me.txtVendorName.TabIndex = 36
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(15, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 20)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Vendor"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SteelPurchaseOrderHeaderTableAdapter
        '
        Me.SteelPurchaseOrderHeaderTableAdapter.ClearBeforeFill = True
        '
        'SteelReceivingHeaderTableTableAdapter
        '
        Me.SteelReceivingHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'cmdSelectCoils
        '
        Me.cmdSelectCoils.Location = New System.Drawing.Point(213, 19)
        Me.cmdSelectCoils.Name = "cmdSelectCoils"
        Me.cmdSelectCoils.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectCoils.TabIndex = 41
        Me.cmdSelectCoils.Text = "Select Coils"
        Me.cmdSelectCoils.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdSelectCoils)
        Me.GroupBox3.Location = New System.Drawing.Point(29, 606)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(300, 74)
        Me.GroupBox3.TabIndex = 42
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Select Coils"
        '
        'dgvSteelReceivingLines
        '
        Me.dgvSteelReceivingLines.AllowUserToAddRows = False
        Me.dgvSteelReceivingLines.AutoGenerateColumns = False
        Me.dgvSteelReceivingLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelReceivingLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelReceivingLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SteelReceivingHeaderKeyColumn, Me.SteelReceivingLineKeyColumn, Me.RMIDColumn, Me.ReceiveWeightColumn, Me.SteelExtendedCostColumn, Me.LineCommentColumn, Me.LineStatusColumn, Me.SelectForInvoiceColumn, Me.DebitGLAccountColumn, Me.CreditGLAccountColumn, Me.SteelPONumberColumn, Me.SteelPOLineNumberColumn})
        Me.dgvSteelReceivingLines.DataSource = Me.SteelReceivingLineTableBindingSource
        Me.dgvSteelReceivingLines.Location = New System.Drawing.Point(335, 45)
        Me.dgvSteelReceivingLines.Name = "dgvSteelReceivingLines"
        Me.dgvSteelReceivingLines.Size = New System.Drawing.Size(695, 355)
        Me.dgvSteelReceivingLines.TabIndex = 43
        '
        'SteelReceivingHeaderKeyColumn
        '
        Me.SteelReceivingHeaderKeyColumn.DataPropertyName = "SteelReceivingHeaderKey"
        Me.SteelReceivingHeaderKeyColumn.HeaderText = "SteelReceivingHeaderKey"
        Me.SteelReceivingHeaderKeyColumn.Name = "SteelReceivingHeaderKeyColumn"
        Me.SteelReceivingHeaderKeyColumn.Visible = False
        '
        'SteelReceivingLineKeyColumn
        '
        Me.SteelReceivingLineKeyColumn.DataPropertyName = "SteelReceivingLineKey"
        Me.SteelReceivingLineKeyColumn.HeaderText = "Line #"
        Me.SteelReceivingLineKeyColumn.Name = "SteelReceivingLineKeyColumn"
        Me.SteelReceivingLineKeyColumn.ReadOnly = True
        Me.SteelReceivingLineKeyColumn.Width = 60
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        Me.RMIDColumn.ReadOnly = True
        Me.RMIDColumn.Width = 150
        '
        'ReceiveWeightColumn
        '
        Me.ReceiveWeightColumn.DataPropertyName = "ReceiveWeight"
        Me.ReceiveWeightColumn.HeaderText = "Weight Received"
        Me.ReceiveWeightColumn.Name = "ReceiveWeightColumn"
        '
        'SteelExtendedCostColumn
        '
        Me.SteelExtendedCostColumn.DataPropertyName = "SteelExtendedCost"
        Me.SteelExtendedCostColumn.HeaderText = "Ext. Cost"
        Me.SteelExtendedCostColumn.Name = "SteelExtendedCostColumn"
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        Me.LineCommentColumn.Width = 150
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "Line Status"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.ReadOnly = True
        '
        'SelectForInvoiceColumn
        '
        Me.SelectForInvoiceColumn.DataPropertyName = "SelectForInvoice"
        Me.SelectForInvoiceColumn.HeaderText = "SelectForInvoice"
        Me.SelectForInvoiceColumn.Name = "SelectForInvoiceColumn"
        Me.SelectForInvoiceColumn.Visible = False
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "DebitGLAccount"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        Me.DebitGLAccountColumn.Visible = False
        '
        'CreditGLAccountColumn
        '
        Me.CreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumn.HeaderText = "CreditGLAccount"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
        Me.CreditGLAccountColumn.Visible = False
        '
        'SteelPONumberColumn
        '
        Me.SteelPONumberColumn.DataPropertyName = "SteelPONumber"
        Me.SteelPONumberColumn.HeaderText = "SteelPONumber"
        Me.SteelPONumberColumn.Name = "SteelPONumberColumn"
        Me.SteelPONumberColumn.Visible = False
        '
        'SteelPOLineNumberColumn
        '
        Me.SteelPOLineNumberColumn.DataPropertyName = "SteelPOLineNumber"
        Me.SteelPOLineNumberColumn.HeaderText = "SteelPOLineNumber"
        Me.SteelPOLineNumberColumn.Name = "SteelPOLineNumberColumn"
        Me.SteelPOLineNumberColumn.Visible = False
        '
        'SteelReceivingLineTableBindingSource
        '
        Me.SteelReceivingLineTableBindingSource.DataMember = "SteelReceivingLineTable"
        Me.SteelReceivingLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SteelReceivingLineTableTableAdapter
        '
        Me.SteelReceivingLineTableTableAdapter.ClearBeforeFill = True
        '
        'cmdClearAllData
        '
        Me.cmdClearAllData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAllData.Location = New System.Drawing.Point(809, 771)
        Me.cmdClearAllData.Name = "cmdClearAllData"
        Me.cmdClearAllData.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAllData.TabIndex = 45
        Me.cmdClearAllData.Text = "Clear All"
        Me.cmdClearAllData.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(886, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 46
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(732, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 44
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(963, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 47
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.txtTotalShipmentWeight)
        Me.GroupBox4.Controls.Add(Me.txtCoilsInShipment)
        Me.GroupBox4.Location = New System.Drawing.Point(29, 694)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(300, 117)
        Me.GroupBox4.TabIndex = 48
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Receiver Steel Totals"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(16, 66)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(116, 20)
        Me.Label13.TabIndex = 41
        Me.Label13.Text = "# of Coils"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(16, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(116, 20)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "Total Weight"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalShipmentWeight
        '
        Me.txtTotalShipmentWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalShipmentWeight.Location = New System.Drawing.Point(138, 31)
        Me.txtTotalShipmentWeight.Name = "txtTotalShipmentWeight"
        Me.txtTotalShipmentWeight.ReadOnly = True
        Me.txtTotalShipmentWeight.Size = New System.Drawing.Size(146, 20)
        Me.txtTotalShipmentWeight.TabIndex = 40
        Me.txtTotalShipmentWeight.TabStop = False
        Me.txtTotalShipmentWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCoilsInShipment
        '
        Me.txtCoilsInShipment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilsInShipment.Location = New System.Drawing.Point(138, 66)
        Me.txtCoilsInShipment.Name = "txtCoilsInShipment"
        Me.txtCoilsInShipment.ReadOnly = True
        Me.txtCoilsInShipment.Size = New System.Drawing.Size(146, 20)
        Me.txtCoilsInShipment.TabIndex = 39
        Me.txtCoilsInShipment.TabStop = False
        Me.txtCoilsInShipment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.lblSteelTotal)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.lblInvoiceTotal)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.txtOtherTotal)
        Me.GroupBox5.Controls.Add(Me.txtFreightTotal)
        Me.GroupBox5.Location = New System.Drawing.Point(732, 512)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(302, 153)
        Me.GroupBox5.TabIndex = 49
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Totals"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Location = New System.Drawing.Point(21, 22)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 20)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Steel Total"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSteelTotal
        '
        Me.lblSteelTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSteelTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSteelTotal.Location = New System.Drawing.Point(115, 22)
        Me.lblSteelTotal.Margin = New System.Windows.Forms.Padding(5)
        Me.lblSteelTotal.Name = "lblSteelTotal"
        Me.lblSteelTotal.Size = New System.Drawing.Size(170, 20)
        Me.lblSteelTotal.TabIndex = 34
        Me.lblSteelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.Location = New System.Drawing.Point(21, 88)
        Me.Label10.Margin = New System.Windows.Forms.Padding(5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 20)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Other Total"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInvoiceTotal
        '
        Me.lblInvoiceTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInvoiceTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInvoiceTotal.Location = New System.Drawing.Point(115, 121)
        Me.lblInvoiceTotal.Margin = New System.Windows.Forms.Padding(5)
        Me.lblInvoiceTotal.Name = "lblInvoiceTotal"
        Me.lblInvoiceTotal.Size = New System.Drawing.Size(170, 20)
        Me.lblInvoiceTotal.TabIndex = 33
        Me.lblInvoiceTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.Location = New System.Drawing.Point(21, 55)
        Me.Label11.Margin = New System.Windows.Forms.Padding(5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 20)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Freight Total"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.Location = New System.Drawing.Point(21, 121)
        Me.Label12.Margin = New System.Windows.Forms.Padding(5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 20)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Invoice Total"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOtherTotal
        '
        Me.txtOtherTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOtherTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOtherTotal.Location = New System.Drawing.Point(115, 88)
        Me.txtOtherTotal.Margin = New System.Windows.Forms.Padding(5)
        Me.txtOtherTotal.Name = "txtOtherTotal"
        Me.txtOtherTotal.Size = New System.Drawing.Size(170, 20)
        Me.txtOtherTotal.TabIndex = 29
        Me.txtOtherTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFreightTotal
        '
        Me.txtFreightTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFreightTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightTotal.Location = New System.Drawing.Point(115, 55)
        Me.txtFreightTotal.Margin = New System.Windows.Forms.Padding(5)
        Me.txtFreightTotal.Name = "txtFreightTotal"
        Me.txtFreightTotal.Size = New System.Drawing.Size(170, 20)
        Me.txtFreightTotal.TabIndex = 30
        Me.txtFreightTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gpxPostReceipt
        '
        Me.gpxPostReceipt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxPostReceipt.Controls.Add(Me.Label15)
        Me.gpxPostReceipt.Controls.Add(Me.cmdPostReceiver)
        Me.gpxPostReceipt.Location = New System.Drawing.Point(732, 678)
        Me.gpxPostReceipt.Name = "gpxPostReceipt"
        Me.gpxPostReceipt.Size = New System.Drawing.Size(302, 76)
        Me.gpxPostReceipt.TabIndex = 50
        Me.gpxPostReceipt.TabStop = False
        Me.gpxPostReceipt.Text = "Post Steel Receiving"
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(16, 27)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(184, 32)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Post Steel Receipt when completed"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPostReceiver
        '
        Me.cmdPostReceiver.ForeColor = System.Drawing.Color.Blue
        Me.cmdPostReceiver.Location = New System.Drawing.Point(206, 23)
        Me.cmdPostReceiver.Name = "cmdPostReceiver"
        Me.cmdPostReceiver.Size = New System.Drawing.Size(71, 40)
        Me.cmdPostReceiver.TabIndex = 22
        Me.cmdPostReceiver.Text = "Post Receiver"
        Me.cmdPostReceiver.UseVisualStyleBackColor = True
        '
        'SteelReturnCoilLinesBindingSource
        '
        Me.SteelReturnCoilLinesBindingSource.DataMember = "SteelReturnCoilLines"
        Me.SteelReturnCoilLinesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SteelReturnCoilLinesTableAdapter
        '
        Me.SteelReturnCoilLinesTableAdapter.ClearBeforeFill = True
        '
        'dgvSteelCoils
        '
        Me.dgvSteelCoils.AllowUserToAddRows = False
        Me.dgvSteelCoils.AllowUserToDeleteRows = False
        Me.dgvSteelCoils.AutoGenerateColumns = False
        Me.dgvSteelCoils.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelCoils.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSteelCoils.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelCoils.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SteelReceivingHeaderKeyColumnCL, Me.SteelReceivingLineKeyColumnCL, Me.CoilIDColumnCL, Me.CoilWeightColumnCL, Me.HeatNumberColumnCL, Me.PONumberColumnCL, Me.POLineNumberColumnCL, Me.SteelCostPerPoundColumnCL, Me.SteelExtendedAmountColumnCL})
        Me.dgvSteelCoils.DataSource = Me.SteelReceivingCoilLinesBindingSource
        Me.dgvSteelCoils.Location = New System.Drawing.Point(335, 446)
        Me.dgvSteelCoils.Name = "dgvSteelCoils"
        Me.dgvSteelCoils.Size = New System.Drawing.Size(382, 365)
        Me.dgvSteelCoils.TabIndex = 51
        '
        'SteelReceivingHeaderKeyColumnCL
        '
        Me.SteelReceivingHeaderKeyColumnCL.DataPropertyName = "SteelReceivingHeaderKey"
        Me.SteelReceivingHeaderKeyColumnCL.HeaderText = "SteelReceivingHeaderKey"
        Me.SteelReceivingHeaderKeyColumnCL.Name = "SteelReceivingHeaderKeyColumnCL"
        Me.SteelReceivingHeaderKeyColumnCL.ReadOnly = True
        Me.SteelReceivingHeaderKeyColumnCL.Visible = False
        '
        'SteelReceivingLineKeyColumnCL
        '
        Me.SteelReceivingLineKeyColumnCL.DataPropertyName = "SteelReceivingLineKey"
        Me.SteelReceivingLineKeyColumnCL.HeaderText = "SteelReceivingLineKey"
        Me.SteelReceivingLineKeyColumnCL.Name = "SteelReceivingLineKeyColumnCL"
        Me.SteelReceivingLineKeyColumnCL.Visible = False
        '
        'CoilIDColumnCL
        '
        Me.CoilIDColumnCL.DataPropertyName = "CoilID"
        Me.CoilIDColumnCL.HeaderText = "Coil ID"
        Me.CoilIDColumnCL.Name = "CoilIDColumnCL"
        Me.CoilIDColumnCL.ReadOnly = True
        '
        'CoilWeightColumnCL
        '
        Me.CoilWeightColumnCL.DataPropertyName = "CoilWeight"
        Me.CoilWeightColumnCL.HeaderText = "Coil Weight"
        Me.CoilWeightColumnCL.Name = "CoilWeightColumnCL"
        Me.CoilWeightColumnCL.ReadOnly = True
        '
        'HeatNumberColumnCL
        '
        Me.HeatNumberColumnCL.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumnCL.HeaderText = "Heat Number"
        Me.HeatNumberColumnCL.Name = "HeatNumberColumnCL"
        Me.HeatNumberColumnCL.ReadOnly = True
        '
        'PONumberColumnCL
        '
        Me.PONumberColumnCL.DataPropertyName = "PONumber"
        Me.PONumberColumnCL.HeaderText = "PONumber"
        Me.PONumberColumnCL.Name = "PONumberColumnCL"
        Me.PONumberColumnCL.Visible = False
        '
        'POLineNumberColumnCL
        '
        Me.POLineNumberColumnCL.DataPropertyName = "POLineNumber"
        Me.POLineNumberColumnCL.HeaderText = "POLineNumber"
        Me.POLineNumberColumnCL.Name = "POLineNumberColumnCL"
        Me.POLineNumberColumnCL.Visible = False
        '
        'SteelCostPerPoundColumnCL
        '
        Me.SteelCostPerPoundColumnCL.DataPropertyName = "SteelCostPerPound"
        Me.SteelCostPerPoundColumnCL.HeaderText = "SteelCostPerPound"
        Me.SteelCostPerPoundColumnCL.Name = "SteelCostPerPoundColumnCL"
        Me.SteelCostPerPoundColumnCL.Visible = False
        '
        'SteelExtendedAmountColumnCL
        '
        Me.SteelExtendedAmountColumnCL.DataPropertyName = "SteelExtendedAmount"
        Me.SteelExtendedAmountColumnCL.HeaderText = "SteelExtendedAmount"
        Me.SteelExtendedAmountColumnCL.Name = "SteelExtendedAmountColumnCL"
        Me.SteelExtendedAmountColumnCL.Visible = False
        '
        'SteelReceivingCoilLinesBindingSource
        '
        Me.SteelReceivingCoilLinesBindingSource.DataMember = "SteelReceivingCoilLines"
        Me.SteelReceivingCoilLinesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SteelReceivingCoilLinesTableAdapter
        '
        Me.SteelReceivingCoilLinesTableAdapter.ClearBeforeFill = True
        '
        'CharterSteelCoilIdentificationTableAdapter
        '
        Me.CharterSteelCoilIdentificationTableAdapter.ClearBeforeFill = True
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.ForeColor = System.Drawing.Color.Black
        Me.cmdDeleteLine.Location = New System.Drawing.Point(214, 47)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteLine.TabIndex = 52
        Me.cmdDeleteLine.Text = "Delete Line"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label17)
        Me.GroupBox6.Controls.Add(Me.cboDeleteLineNumber)
        Me.GroupBox6.Controls.Add(Me.Label16)
        Me.GroupBox6.Controls.Add(Me.cmdDeleteLine)
        Me.GroupBox6.Location = New System.Drawing.Point(732, 406)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(302, 100)
        Me.GroupBox6.TabIndex = 53
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Delete Line From Receiver"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.Location = New System.Drawing.Point(14, 59)
        Me.Label17.Margin = New System.Windows.Forms.Padding(5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(55, 20)
        Me.Label17.TabIndex = 54
        Me.Label17.Text = "Line #"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDeleteLineNumber
        '
        Me.cboDeleteLineNumber.DataSource = Me.SteelReceivingLineTableBindingSource
        Me.cboDeleteLineNumber.DisplayMember = "SteelReceivingLineKey"
        Me.cboDeleteLineNumber.FormattingEnabled = True
        Me.cboDeleteLineNumber.Location = New System.Drawing.Point(77, 58)
        Me.cboDeleteLineNumber.Name = "cboDeleteLineNumber"
        Me.cboDeleteLineNumber.Size = New System.Drawing.Size(121, 21)
        Me.cboDeleteLineNumber.TabIndex = 54
        '
        'Label16
        '
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(16, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(269, 31)
        Me.Label16.TabIndex = 53
        Me.Label16.Text = "Select line to delte from receiver and reset all coils."
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(335, 411)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(382, 32)
        Me.Label18.TabIndex = 54
        Me.Label18.Text = "Coils on Receiver"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SteelReceivingByCoil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.dgvSteelCoils)
        Me.Controls.Add(Me.gpxPostReceipt)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.cmdClearAllData)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvSteelReceivingLines)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "SteelReceivingByCoil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Steel Receiving By Coil"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.SteelPurchaseOrderHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.CharterSteelCoilIdentificationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvSteelReceivingLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelReceivingLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.gpxPostReceipt.ResumeLayout(False)
        CType(Me.SteelReturnCoilLinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSteelCoils, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelReceivingCoilLinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboSteelReceivingNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdGenerateNewReceipt As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboSteelPONumber As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SteelPurchaseOrderHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelPurchaseOrderHeaderTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelPurchaseOrderHeaderTableAdapter
    Friend WithEvents SteelReceivingHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelReceivingHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingHeaderTableTableAdapter
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpReceiverDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboSteelBOLNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents cmdSelectCoils As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvSteelReceivingLines As System.Windows.Forms.DataGridView
    Friend WithEvents SteelReceivingLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelReceivingLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingLineTableTableAdapter
    Friend WithEvents cmdClearAllData As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblSteelTotal As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblInvoiceTotal As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtOtherTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtFreightTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTotalShipmentWeight As System.Windows.Forms.TextBox
    Friend WithEvents txtCoilsInShipment As System.Windows.Forms.TextBox
    Friend WithEvents gpxPostReceipt As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmdPostReceiver As System.Windows.Forms.Button
    Friend WithEvents SteelReturnCoilLinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelReturnCoilLinesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReturnCoilLinesTableAdapter
    Friend WithEvents dgvSteelCoils As System.Windows.Forms.DataGridView
    Friend WithEvents SteelReceivingCoilLinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelReceivingCoilLinesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingCoilLinesTableAdapter
    Friend WithEvents CharterSteelCoilIdentificationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CharterSteelCoilIdentificationTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CharterSteelCoilIdentificationTableAdapter
    Friend WithEvents txtSteelVendorID As System.Windows.Forms.TextBox
    Friend WithEvents SteelReceivingHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReceivingLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiveWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForInvoiceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelPONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelPOLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReceivingHeaderKeyColumnCL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReceivingLineKeyColumnCL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoilIDColumnCL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoilWeightColumnCL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumnCL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberColumnCL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POLineNumberColumnCL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCostPerPoundColumnCL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelExtendedAmountColumnCL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboDeleteLineNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
End Class
