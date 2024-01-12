<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QCShipmentDockChecks
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
        Me.ReUploadPickTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AppendPickTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmdViewByCustomer = New System.Windows.Forms.Button
        Me.cmdViewByDivision = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdAddNew = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.chkFail = New System.Windows.Forms.CheckBox
        Me.chkPass = New System.Windows.Forms.CheckBox
        Me.txtPalletCount = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtBoxCount = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtQCComments = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtQCInspector = New System.Windows.Forms.TextBox
        Me.txtShipDate = New System.Windows.Forms.TextBox
        Me.txtShipVia = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtShipmentNumber = New System.Windows.Forms.TextBox
        Me.txtSalesOrderNumber = New System.Windows.Forms.TextBox
        Me.cboPickTicket = New System.Windows.Forms.ComboBox
        Me.PickListHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgvQCShipments = New System.Windows.Forms.DataGridView
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PickTicketNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipViaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumberOfBoxesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumberOfPalletsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ApprovedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QCInspectorColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ScannedDocumentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QCShipmentAuditBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.QCShipmentAuditTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.QCShipmentAuditTableAdapter
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdViewsDocs = New System.Windows.Forms.Button
        Me.cmdScanDocs = New System.Windows.Forms.Button
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.PickListHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListHeaderTableTableAdapter
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cmdPrintListing = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PickListHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvQCShipments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QCShipmentAuditBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
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
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReUploadPickTicketToolStripMenuItem, Me.AppendPickTicketToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReUploadPickTicketToolStripMenuItem
        '
        Me.ReUploadPickTicketToolStripMenuItem.Name = "ReUploadPickTicketToolStripMenuItem"
        Me.ReUploadPickTicketToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.ReUploadPickTicketToolStripMenuItem.Text = "Re-Upload PickTicket"
        '
        'AppendPickTicketToolStripMenuItem
        '
        Me.AppendPickTicketToolStripMenuItem.Name = "AppendPickTicketToolStripMenuItem"
        Me.AppendPickTicketToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.AppendPickTicketToolStripMenuItem.Text = "Append Pick Ticket"
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.cmdViewByCustomer)
        Me.GroupBox1.Controls.Add(Me.cmdViewByDivision)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 143)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View"
        '
        'Label16
        '
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(17, 95)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(190, 37)
        Me.Label16.TabIndex = 59
        Me.Label16.Text = "View by Customer (select below or in datagrid and press View"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(17, 67)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(149, 20)
        Me.Label15.TabIndex = 58
        Me.Label15.Text = "View By Division"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByCustomer
        '
        Me.cmdViewByCustomer.Location = New System.Drawing.Point(213, 98)
        Me.cmdViewByCustomer.Name = "cmdViewByCustomer"
        Me.cmdViewByCustomer.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByCustomer.TabIndex = 3
        Me.cmdViewByCustomer.Text = "View"
        Me.cmdViewByCustomer.UseVisualStyleBackColor = True
        '
        'cmdViewByDivision
        '
        Me.cmdViewByDivision.Location = New System.Drawing.Point(213, 62)
        Me.cmdViewByDivision.Name = "cmdViewByDivision"
        Me.cmdViewByDivision.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByDivision.TabIndex = 2
        Me.cmdViewByDivision.Text = "View"
        Me.cmdViewByDivision.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(116, 25)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(168, 21)
        Me.cboDivisionID.TabIndex = 1
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(149, 20)
        Me.Label8.TabIndex = 55
        Me.Label8.Text = "Division"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(19, 56)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(264, 21)
        Me.cboCustomerName.TabIndex = 6
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(79, 29)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(204, 21)
        Me.cboCustomerID.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 20)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Customer"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 22
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboCustomerName)
        Me.GroupBox2.Controls.Add(Me.cmdAddNew)
        Me.GroupBox2.Controls.Add(Me.cmdClear)
        Me.GroupBox2.Controls.Add(Me.cboCustomerID)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.chkFail)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.chkPass)
        Me.GroupBox2.Controls.Add(Me.txtPalletCount)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtBoxCount)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtQCComments)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtQCInspector)
        Me.GroupBox2.Controls.Add(Me.txtShipDate)
        Me.GroupBox2.Controls.Add(Me.txtShipVia)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtShipmentNumber)
        Me.GroupBox2.Controls.Add(Me.txtSalesOrderNumber)
        Me.GroupBox2.Controls.Add(Me.cboPickTicket)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(30, 190)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(298, 621)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Add New Entry"
        '
        'cmdAddNew
        '
        Me.cmdAddNew.Location = New System.Drawing.Point(135, 569)
        Me.cmdAddNew.Name = "cmdAddNew"
        Me.cmdAddNew.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddNew.TabIndex = 18
        Me.cmdAddNew.Text = "Enter"
        Me.cmdAddNew.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(212, 569)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 19
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(16, 534)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 20)
        Me.Label12.TabIndex = 77
        Me.Label12.Text = "Approval?"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkFail
        '
        Me.chkFail.AutoSize = True
        Me.chkFail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFail.Location = New System.Drawing.Point(185, 537)
        Me.chkFail.Name = "chkFail"
        Me.chkFail.Size = New System.Drawing.Size(46, 17)
        Me.chkFail.TabIndex = 17
        Me.chkFail.Text = "Fail"
        Me.chkFail.UseVisualStyleBackColor = True
        '
        'chkPass
        '
        Me.chkPass.AutoSize = True
        Me.chkPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPass.Location = New System.Drawing.Point(116, 537)
        Me.chkPass.Name = "chkPass"
        Me.chkPass.Size = New System.Drawing.Size(53, 17)
        Me.chkPass.TabIndex = 16
        Me.chkPass.Text = "Pass"
        Me.chkPass.UseVisualStyleBackColor = True
        '
        'txtPalletCount
        '
        Me.txtPalletCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPalletCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPalletCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPalletCount.Location = New System.Drawing.Point(115, 496)
        Me.txtPalletCount.Name = "txtPalletCount"
        Me.txtPalletCount.Size = New System.Drawing.Size(168, 20)
        Me.txtPalletCount.TabIndex = 15
        Me.txtPalletCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 496)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(149, 20)
        Me.Label11.TabIndex = 73
        Me.Label11.Text = "# of Pallets"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBoxCount
        '
        Me.txtBoxCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBoxCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBoxCount.Location = New System.Drawing.Point(115, 470)
        Me.txtBoxCount.Name = "txtBoxCount"
        Me.txtBoxCount.Size = New System.Drawing.Size(168, 20)
        Me.txtBoxCount.TabIndex = 14
        Me.txtBoxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 470)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(149, 20)
        Me.Label10.TabIndex = 71
        Me.Label10.Text = "# of Boxes"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(17, 310)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(149, 20)
        Me.Label9.TabIndex = 70
        Me.Label9.Text = "Comments"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQCComments
        '
        Me.txtQCComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQCComments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQCComments.Location = New System.Drawing.Point(19, 333)
        Me.txtQCComments.Multiline = True
        Me.txtQCComments.Name = "txtQCComments"
        Me.txtQCComments.Size = New System.Drawing.Size(264, 116)
        Me.txtQCComments.TabIndex = 13
        Me.txtQCComments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 256)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(149, 20)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "QC Inspector"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQCInspector
        '
        Me.txtQCInspector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQCInspector.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQCInspector.Location = New System.Drawing.Point(19, 279)
        Me.txtQCInspector.Name = "txtQCInspector"
        Me.txtQCInspector.Size = New System.Drawing.Size(264, 20)
        Me.txtQCInspector.TabIndex = 12
        Me.txtQCInspector.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtShipDate
        '
        Me.txtShipDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipDate.Location = New System.Drawing.Point(115, 228)
        Me.txtShipDate.Name = "txtShipDate"
        Me.txtShipDate.Size = New System.Drawing.Size(168, 20)
        Me.txtShipDate.TabIndex = 11
        Me.txtShipDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtShipVia
        '
        Me.txtShipVia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipVia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipVia.Location = New System.Drawing.Point(115, 196)
        Me.txtShipVia.Name = "txtShipVia"
        Me.txtShipVia.Size = New System.Drawing.Size(168, 20)
        Me.txtShipVia.TabIndex = 10
        Me.txtShipVia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 228)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(149, 20)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Ship Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 196)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(149, 20)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "Ship Via"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShipmentNumber
        '
        Me.txtShipmentNumber.BackColor = System.Drawing.Color.White
        Me.txtShipmentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipmentNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipmentNumber.Location = New System.Drawing.Point(115, 164)
        Me.txtShipmentNumber.Name = "txtShipmentNumber"
        Me.txtShipmentNumber.ReadOnly = True
        Me.txtShipmentNumber.Size = New System.Drawing.Size(168, 20)
        Me.txtShipmentNumber.TabIndex = 9
        Me.txtShipmentNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSalesOrderNumber
        '
        Me.txtSalesOrderNumber.BackColor = System.Drawing.Color.White
        Me.txtSalesOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesOrderNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesOrderNumber.Location = New System.Drawing.Point(115, 132)
        Me.txtSalesOrderNumber.Name = "txtSalesOrderNumber"
        Me.txtSalesOrderNumber.ReadOnly = True
        Me.txtSalesOrderNumber.Size = New System.Drawing.Size(168, 20)
        Me.txtSalesOrderNumber.TabIndex = 8
        Me.txtSalesOrderNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboPickTicket
        '
        Me.cboPickTicket.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPickTicket.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPickTicket.DataSource = Me.PickListHeaderTableBindingSource
        Me.cboPickTicket.DisplayMember = "PickListHeaderKey"
        Me.cboPickTicket.FormattingEnabled = True
        Me.cboPickTicket.Location = New System.Drawing.Point(115, 99)
        Me.cboPickTicket.Name = "cboPickTicket"
        Me.cboPickTicket.Size = New System.Drawing.Size(168, 21)
        Me.cboPickTicket.TabIndex = 7
        '
        'PickListHeaderTableBindingSource
        '
        Me.PickListHeaderTableBindingSource.DataMember = "PickListHeaderTable"
        Me.PickListHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(149, 20)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Shipment #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(149, 20)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Sales Order #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 20)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Pick Ticket #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvQCShipments
        '
        Me.dgvQCShipments.AllowUserToAddRows = False
        Me.dgvQCShipments.AllowUserToDeleteRows = False
        Me.dgvQCShipments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvQCShipments.AutoGenerateColumns = False
        Me.dgvQCShipments.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvQCShipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvQCShipments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ShipmentNumberColumn, Me.PickTicketNumberColumn, Me.SalesOrderNumberColumn, Me.CustomerColumn, Me.ShipViaColumn, Me.ShipDateColumn, Me.NumberOfBoxesColumn, Me.NumberOfPalletsColumn, Me.CommentColumn, Me.ApprovedColumn, Me.QCInspectorColumn, Me.ScannedDocumentColumn})
        Me.dgvQCShipments.DataSource = Me.QCShipmentAuditBindingSource
        Me.dgvQCShipments.Location = New System.Drawing.Point(345, 41)
        Me.dgvQCShipments.Name = "dgvQCShipments"
        Me.dgvQCShipments.Size = New System.Drawing.Size(685, 620)
        Me.dgvQCShipments.TabIndex = 25
        Me.dgvQCShipments.TabStop = False
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "Shipment #"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        '
        'PickTicketNumberColumn
        '
        Me.PickTicketNumberColumn.DataPropertyName = "PickTicketNumber"
        Me.PickTicketNumberColumn.HeaderText = "Pick Ticket #"
        Me.PickTicketNumberColumn.Name = "PickTicketNumberColumn"
        '
        'SalesOrderNumberColumn
        '
        Me.SalesOrderNumberColumn.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberColumn.HeaderText = "Sales Order #"
        Me.SalesOrderNumberColumn.Name = "SalesOrderNumberColumn"
        '
        'CustomerColumn
        '
        Me.CustomerColumn.DataPropertyName = "Customer"
        Me.CustomerColumn.HeaderText = "Customer"
        Me.CustomerColumn.Name = "CustomerColumn"
        '
        'ShipViaColumn
        '
        Me.ShipViaColumn.DataPropertyName = "ShipVia"
        Me.ShipViaColumn.HeaderText = "Ship Via"
        Me.ShipViaColumn.Name = "ShipViaColumn"
        '
        'ShipDateColumn
        '
        Me.ShipDateColumn.DataPropertyName = "ShipDate"
        Me.ShipDateColumn.HeaderText = "Ship Date"
        Me.ShipDateColumn.Name = "ShipDateColumn"
        '
        'NumberOfBoxesColumn
        '
        Me.NumberOfBoxesColumn.DataPropertyName = "NumberOfBoxes"
        Me.NumberOfBoxesColumn.HeaderText = "# Boxes"
        Me.NumberOfBoxesColumn.Name = "NumberOfBoxesColumn"
        '
        'NumberOfPalletsColumn
        '
        Me.NumberOfPalletsColumn.DataPropertyName = "NumberOfPallets"
        Me.NumberOfPalletsColumn.HeaderText = "# Pallets"
        Me.NumberOfPalletsColumn.Name = "NumberOfPalletsColumn"
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'ApprovedColumn
        '
        Me.ApprovedColumn.DataPropertyName = "Approved"
        Me.ApprovedColumn.HeaderText = "Approved"
        Me.ApprovedColumn.Name = "ApprovedColumn"
        '
        'QCInspectorColumn
        '
        Me.QCInspectorColumn.DataPropertyName = "QCInspector"
        Me.QCInspectorColumn.HeaderText = "QC Inspector"
        Me.QCInspectorColumn.Name = "QCInspectorColumn"
        '
        'ScannedDocumentColumn
        '
        Me.ScannedDocumentColumn.DataPropertyName = "ScannedDocument"
        Me.ScannedDocumentColumn.HeaderText = "Document Filename"
        Me.ScannedDocumentColumn.Name = "ScannedDocumentColumn"
        '
        'QCShipmentAuditBindingSource
        '
        Me.QCShipmentAuditBindingSource.DataMember = "QCShipmentAudit"
        Me.QCShipmentAuditBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'QCShipmentAuditTableAdapter
        '
        Me.QCShipmentAuditTableAdapter.ClearBeforeFill = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.cmdViewsDocs)
        Me.GroupBox3.Controls.Add(Me.cmdScanDocs)
        Me.GroupBox3.Location = New System.Drawing.Point(345, 678)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(381, 133)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "View / Scan Shipping Documents"
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(96, 86)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(266, 30)
        Me.Label14.TabIndex = 59
        Me.Label14.Text = "View Shipping Documents for this customer."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(96, 38)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(266, 30)
        Me.Label13.TabIndex = 58
        Me.Label13.Text = "Scan in Shipping Documents for this customer."
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewsDocs
        '
        Me.cmdViewsDocs.Location = New System.Drawing.Point(19, 86)
        Me.cmdViewsDocs.Name = "cmdViewsDocs"
        Me.cmdViewsDocs.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewsDocs.TabIndex = 20
        Me.cmdViewsDocs.Text = "View"
        Me.cmdViewsDocs.UseVisualStyleBackColor = True
        '
        'cmdScanDocs
        '
        Me.cmdScanDocs.Location = New System.Drawing.Point(19, 38)
        Me.cmdScanDocs.Name = "cmdScanDocs"
        Me.cmdScanDocs.Size = New System.Drawing.Size(71, 30)
        Me.cmdScanDocs.TabIndex = 19
        Me.cmdScanDocs.Text = "Scan"
        Me.cmdScanDocs.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(805, 771)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 21
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'PickListHeaderTableTableAdapter
        '
        Me.PickListHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(199, 25)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 30)
        Me.cmdDelete.TabIndex = 26
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(15, 19)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(168, 36)
        Me.Label17.TabIndex = 59
        Me.Label17.Text = "Select record in datagrid to delete"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.cmdDelete)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Location = New System.Drawing.Point(743, 678)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(287, 74)
        Me.GroupBox4.TabIndex = 60
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Delete"
        '
        'cmdPrintListing
        '
        Me.cmdPrintListing.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintListing.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrintListing.Name = "cmdPrintListing"
        Me.cmdPrintListing.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintListing.TabIndex = 61
        Me.cmdPrintListing.Text = "Print Listing"
        Me.cmdPrintListing.UseVisualStyleBackColor = True
        '
        'QCShipmentDockChecks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.cmdPrintListing)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.dgvQCShipments)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "QCShipmentDockChecks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Shipment Dock Checks"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PickListHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvQCShipments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QCShipmentAuditBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSalesOrderNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboPickTicket As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtShipDate As System.Windows.Forms.TextBox
    Friend WithEvents txtShipVia As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtShipmentNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmdAddNew As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkFail As System.Windows.Forms.CheckBox
    Friend WithEvents chkPass As System.Windows.Forms.CheckBox
    Friend WithEvents txtPalletCount As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtBoxCount As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtQCComments As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtQCInspector As System.Windows.Forms.TextBox
    Friend WithEvents dgvQCShipments As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents QCShipmentAuditBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents QCShipmentAuditTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.QCShipmentAuditTableAdapter
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmdViewsDocs As System.Windows.Forms.Button
    Friend WithEvents cmdScanDocs As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents PickListHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PickListHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListHeaderTableTableAdapter
    Friend WithEvents ReUploadPickTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppendPickTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmdViewByCustomer As System.Windows.Forms.Button
    Friend WithEvents cmdViewByDivision As System.Windows.Forms.Button
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickTicketNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipViaColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumberOfBoxesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumberOfPalletsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApprovedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QCInspectorColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScannedDocumentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPrintListing As System.Windows.Forms.Button
End Class
