<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReturnProductForm
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ManuallyCloseReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnLockReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cboReturnSalesperson = New System.Windows.Forms.ComboBox
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.lblComment = New System.Windows.Forms.Label
        Me.cboReturnCustomer = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblCustomer = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblContact = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtReturnQuantity = New System.Windows.Forms.TextBox
        Me.lblPartNumber = New System.Windows.Forms.Label
        Me.txtLineTotal = New System.Windows.Forms.TextBox
        Me.txtReturnReason = New System.Windows.Forms.TextBox
        Me.gpxReturnHeader = New System.Windows.Forms.GroupBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.dtpReturnDate = New System.Windows.Forms.DateTimePicker
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtReturnStatus = New System.Windows.Forms.TextBox
        Me.cboSalesOrderNumber = New System.Windows.Forms.ComboBox
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.cmdGenerateNewReturnNumber = New System.Windows.Forms.Button
        Me.cboReturnNumber = New System.Windows.Forms.ComboBox
        Me.ReturnProductHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblCustomerClass = New System.Windows.Forms.Label
        Me.cboCustomerClass = New System.Windows.Forms.ComboBox
        Me.CustomerClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdEnter = New System.Windows.Forms.Button
        Me.txtReturnPrice = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboReturnPartNumber = New System.Windows.Forms.ComboBox
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.gpxReturnTotals = New System.Windows.Forms.GroupBox
        Me.cmdRemoveSalesTax = New System.Windows.Forms.Button
        Me.lblReturnTotal = New System.Windows.Forms.Label
        Me.txtReturnSalesTax3 = New System.Windows.Forms.TextBox
        Me.LabelHST = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.lblProductTotal = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtReturnSalesTax2 = New System.Windows.Forms.TextBox
        Me.LabelPST = New System.Windows.Forms.Label
        Me.txtReturnSalesTax = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtReturnFreight = New System.Windows.Forms.TextBox
        Me.LabelGST = New System.Windows.Forms.Label
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdViewOpenReturns = New System.Windows.Forms.Button
        Me.SalesOrderLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvReturnLines = New System.Windows.Forms.DataGridView
        Me.ReturnNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitPriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnProductLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReturnProductHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReturnProductHeaderTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.SalesOrderLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderLineTableTableAdapter
        Me.ReturnProductLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReturnProductLineTableTableAdapter
        Me.cmdCustomerForm = New System.Windows.Forms.Button
        Me.tabItemInfo = New System.Windows.Forms.TabControl
        Me.tabPartNumberEntry = New System.Windows.Forms.TabPage
        Me.txtLineComment = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtSalesTaxLineRate = New System.Windows.Forms.TextBox
        Me.chkAddLineTax = New System.Windows.Forms.CheckBox
        Me.tabPartNumberData = New System.Windows.Forms.TabPage
        Me.txtSalesOffset = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtGLCOGSAccount = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtGLInventoryAccount = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtGLReturnsAccount = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtGLSalesAccount = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtItemClassDescription = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tabDeleteLine = New System.Windows.Forms.TabPage
        Me.Label24 = New System.Windows.Forms.Label
        Me.cboLineNumber = New System.Windows.Forms.ComboBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.cboLinePartNumber = New System.Windows.Forms.ComboBox
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label30 = New System.Windows.Forms.Label
        Me.cmdDeleteSN = New System.Windows.Forms.Button
        Me.dgvSerialLogTemp = New System.Windows.Forms.DataGridView
        Me.AssemblyPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerialNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionID2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblySerialTempTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.cmdItemForm = New System.Windows.Forms.Button
        Me.cmdSelectLinesFromSO = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.gpxPostData = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmdPostReturn = New System.Windows.Forms.Button
        Me.CustomerClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerClassTableAdapter
        Me.CachedCRXInvoiceCosting1 = New MOS09Program.CachedCRXInvoiceCosting
        Me.AssemblySerialTempTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblySerialTempTableTableAdapter
        Me.AssemblySerialTempTableBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.tabReturnData = New System.Windows.Forms.TabControl
        Me.tabLines = New System.Windows.Forms.TabPage
        Me.tabOtherData = New System.Windows.Forms.TabPage
        Me.gpxConsignmentBox = New System.Windows.Forms.GroupBox
        Me.txtFOBName = New System.Windows.Forms.TextBox
        Me.cboFOB = New System.Windows.Forms.ComboBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxReturnHeader.SuspendLayout()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReturnProductHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxReturnTotals.SuspendLayout()
        CType(Me.SalesOrderLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReturnLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReturnProductLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabItemInfo.SuspendLayout()
        Me.tabPartNumberEntry.SuspendLayout()
        Me.tabPartNumberData.SuspendLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDeleteLine.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvSerialLogTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssemblySerialTempTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxPostData.SuspendLayout()
        CType(Me.AssemblySerialTempTableBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabReturnData.SuspendLayout()
        Me.tabLines.SuspendLayout()
        Me.tabOtherData.SuspendLayout()
        Me.gpxConsignmentBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1062, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 32
        Me.cmdExit.Text = "Exit Return"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveReturnToolStripMenuItem, Me.DeleteReturnToolStripMenuItem, Me.PrintReturnToolStripMenuItem, Me.ClearFormToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveReturnToolStripMenuItem
        '
        Me.SaveReturnToolStripMenuItem.Name = "SaveReturnToolStripMenuItem"
        Me.SaveReturnToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.SaveReturnToolStripMenuItem.Text = "Save Return"
        '
        'DeleteReturnToolStripMenuItem
        '
        Me.DeleteReturnToolStripMenuItem.Name = "DeleteReturnToolStripMenuItem"
        Me.DeleteReturnToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.DeleteReturnToolStripMenuItem.Text = "Delete Return"
        '
        'PrintReturnToolStripMenuItem
        '
        Me.PrintReturnToolStripMenuItem.Name = "PrintReturnToolStripMenuItem"
        Me.PrintReturnToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.PrintReturnToolStripMenuItem.Text = "Print Return"
        '
        'ClearFormToolStripMenuItem
        '
        Me.ClearFormToolStripMenuItem.Name = "ClearFormToolStripMenuItem"
        Me.ClearFormToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.ClearFormToolStripMenuItem.Text = "Clear Form"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManuallyCloseReturnToolStripMenuItem, Me.UnLockReturnToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ManuallyCloseReturnToolStripMenuItem
        '
        Me.ManuallyCloseReturnToolStripMenuItem.Name = "ManuallyCloseReturnToolStripMenuItem"
        Me.ManuallyCloseReturnToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ManuallyCloseReturnToolStripMenuItem.Text = "Manually Close Return"
        '
        'UnLockReturnToolStripMenuItem
        '
        Me.UnLockReturnToolStripMenuItem.Name = "UnLockReturnToolStripMenuItem"
        Me.UnLockReturnToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.UnLockReturnToolStripMenuItem.Text = "Un-Lock Return"
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
        'cboReturnSalesperson
        '
        Me.cboReturnSalesperson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReturnSalesperson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReturnSalesperson.DataSource = Me.EmployeeDataBindingSource
        Me.cboReturnSalesperson.DisplayMember = "SalesPersonID"
        Me.cboReturnSalesperson.DropDownWidth = 300
        Me.cboReturnSalesperson.FormattingEnabled = True
        Me.cboReturnSalesperson.Location = New System.Drawing.Point(128, 233)
        Me.cboReturnSalesperson.Name = "cboReturnSalesperson"
        Me.cboReturnSalesperson.Size = New System.Drawing.Size(205, 21)
        Me.cboReturnSalesperson.TabIndex = 7
        Me.cboReturnSalesperson.ValueMember = "ItemID"
        '
        'EmployeeDataBindingSource
        '
        Me.EmployeeDataBindingSource.DataMember = "EmployeeData"
        Me.EmployeeDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lblComment
        '
        Me.lblComment.Location = New System.Drawing.Point(28, 153)
        Me.lblComment.Name = "lblComment"
        Me.lblComment.Size = New System.Drawing.Size(103, 20)
        Me.lblComment.TabIndex = 31
        Me.lblComment.Text = "Return Quantity"
        Me.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboReturnCustomer
        '
        Me.cboReturnCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReturnCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReturnCustomer.DataSource = Me.CustomerListBindingSource
        Me.cboReturnCustomer.DisplayMember = "CustomerID"
        Me.cboReturnCustomer.DropDownWidth = 300
        Me.cboReturnCustomer.FormattingEnabled = True
        Me.cboReturnCustomer.Location = New System.Drawing.Point(78, 108)
        Me.cboReturnCustomer.Name = "cboReturnCustomer"
        Me.cboReturnCustomer.Size = New System.Drawing.Size(255, 21)
        Me.cboReturnCustomer.TabIndex = 3
        Me.cboReturnCustomer.ValueMember = "CustID"
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 233)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 20)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Salesperson"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCustomer
        '
        Me.lblCustomer.Location = New System.Drawing.Point(21, 109)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(104, 20)
        Me.lblCustomer.TabIndex = 25
        Me.lblCustomer.Text = "Customer"
        Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(28, 215)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 20)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Extended Amount"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblContact
        '
        Me.lblContact.Location = New System.Drawing.Point(15, 282)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(355, 20)
        Me.lblContact.TabIndex = 29
        Me.lblContact.Text = "Reason / Comment"
        Me.lblContact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(21, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 20)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Return #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReturnQuantity
        '
        Me.txtReturnQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnQuantity.Location = New System.Drawing.Point(177, 153)
        Me.txtReturnQuantity.Name = "txtReturnQuantity"
        Me.txtReturnQuantity.Size = New System.Drawing.Size(148, 20)
        Me.txtReturnQuantity.TabIndex = 12
        Me.txtReturnQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPartNumber
        '
        Me.lblPartNumber.Location = New System.Drawing.Point(21, 79)
        Me.lblPartNumber.Name = "lblPartNumber"
        Me.lblPartNumber.Size = New System.Drawing.Size(104, 20)
        Me.lblPartNumber.TabIndex = 24
        Me.lblPartNumber.Text = "Return Date"
        Me.lblPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLineTotal
        '
        Me.txtLineTotal.BackColor = System.Drawing.Color.White
        Me.txtLineTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineTotal.Enabled = False
        Me.txtLineTotal.Location = New System.Drawing.Point(177, 215)
        Me.txtLineTotal.Name = "txtLineTotal"
        Me.txtLineTotal.ReadOnly = True
        Me.txtLineTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtLineTotal.TabIndex = 14
        Me.txtLineTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReturnReason
        '
        Me.txtReturnReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReturnReason.Location = New System.Drawing.Point(18, 305)
        Me.txtReturnReason.MaxLength = 200
        Me.txtReturnReason.Multiline = True
        Me.txtReturnReason.Name = "txtReturnReason"
        Me.txtReturnReason.Size = New System.Drawing.Size(352, 152)
        Me.txtReturnReason.TabIndex = 32
        Me.txtReturnReason.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gpxReturnHeader
        '
        Me.gpxReturnHeader.Controls.Add(Me.Label32)
        Me.gpxReturnHeader.Controls.Add(Me.txtCustomerPO)
        Me.gpxReturnHeader.Controls.Add(Me.dtpReturnDate)
        Me.gpxReturnHeader.Controls.Add(Me.Label23)
        Me.gpxReturnHeader.Controls.Add(Me.txtReturnStatus)
        Me.gpxReturnHeader.Controls.Add(Me.cboSalesOrderNumber)
        Me.gpxReturnHeader.Controls.Add(Me.cboCustomerName)
        Me.gpxReturnHeader.Controls.Add(Me.cmdGenerateNewReturnNumber)
        Me.gpxReturnHeader.Controls.Add(Me.cboReturnNumber)
        Me.gpxReturnHeader.Controls.Add(Me.Label6)
        Me.gpxReturnHeader.Controls.Add(Me.cboReturnSalesperson)
        Me.gpxReturnHeader.Controls.Add(Me.cboReturnCustomer)
        Me.gpxReturnHeader.Controls.Add(Me.cboDivisionID)
        Me.gpxReturnHeader.Controls.Add(Me.Label5)
        Me.gpxReturnHeader.Controls.Add(Me.lblPartNumber)
        Me.gpxReturnHeader.Controls.Add(Me.Label4)
        Me.gpxReturnHeader.Controls.Add(Me.Label2)
        Me.gpxReturnHeader.Controls.Add(Me.lblCustomer)
        Me.gpxReturnHeader.Location = New System.Drawing.Point(29, 41)
        Me.gpxReturnHeader.Name = "gpxReturnHeader"
        Me.gpxReturnHeader.Size = New System.Drawing.Size(349, 300)
        Me.gpxReturnHeader.TabIndex = 0
        Me.gpxReturnHeader.TabStop = False
        Me.gpxReturnHeader.Text = "Return Information"
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(18, 202)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(104, 20)
        Me.Label32.TabIndex = 64
        Me.Label32.Text = "Customer PO#"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCustomerPO
        '
        Me.txtCustomerPO.BackColor = System.Drawing.Color.White
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.Location = New System.Drawing.Point(128, 202)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(205, 20)
        Me.txtCustomerPO.TabIndex = 6
        Me.txtCustomerPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpReturnDate
        '
        Me.dtpReturnDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReturnDate.Location = New System.Drawing.Point(128, 79)
        Me.dtpReturnDate.Name = "dtpReturnDate"
        Me.dtpReturnDate.Size = New System.Drawing.Size(205, 20)
        Me.dtpReturnDate.TabIndex = 2
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(18, 264)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(104, 20)
        Me.Label23.TabIndex = 62
        Me.Label23.Text = "Return Status"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReturnStatus
        '
        Me.txtReturnStatus.BackColor = System.Drawing.Color.White
        Me.txtReturnStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnStatus.Enabled = False
        Me.txtReturnStatus.Location = New System.Drawing.Point(128, 265)
        Me.txtReturnStatus.Name = "txtReturnStatus"
        Me.txtReturnStatus.ReadOnly = True
        Me.txtReturnStatus.Size = New System.Drawing.Size(205, 20)
        Me.txtReturnStatus.TabIndex = 8
        Me.txtReturnStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboSalesOrderNumber
        '
        Me.cboSalesOrderNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesOrderNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesOrderNumber.DataSource = Me.SalesOrderHeaderTableBindingSource
        Me.cboSalesOrderNumber.DisplayMember = "SalesOrderKey"
        Me.cboSalesOrderNumber.FormattingEnabled = True
        Me.cboSalesOrderNumber.Location = New System.Drawing.Point(128, 170)
        Me.cboSalesOrderNumber.Name = "cboSalesOrderNumber"
        Me.cboSalesOrderNumber.Size = New System.Drawing.Size(205, 21)
        Me.cboSalesOrderNumber.TabIndex = 5
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.DropDownWidth = 300
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(21, 137)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(312, 21)
        Me.cboCustomerName.TabIndex = 4
        '
        'cmdGenerateNewReturnNumber
        '
        Me.cmdGenerateNewReturnNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateNewReturnNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateNewReturnNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateNewReturnNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateNewReturnNumber.Location = New System.Drawing.Point(96, 50)
        Me.cmdGenerateNewReturnNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateNewReturnNumber.Name = "cmdGenerateNewReturnNumber"
        Me.cmdGenerateNewReturnNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateNewReturnNumber.TabIndex = 1
        Me.cmdGenerateNewReturnNumber.Text = ">>"
        Me.cmdGenerateNewReturnNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateNewReturnNumber.UseVisualStyleBackColor = False
        '
        'cboReturnNumber
        '
        Me.cboReturnNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReturnNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReturnNumber.DataSource = Me.ReturnProductHeaderTableBindingSource
        Me.cboReturnNumber.DisplayMember = "ReturnNumber"
        Me.cboReturnNumber.FormattingEnabled = True
        Me.cboReturnNumber.Location = New System.Drawing.Point(128, 49)
        Me.cboReturnNumber.Name = "cboReturnNumber"
        Me.cboReturnNumber.Size = New System.Drawing.Size(205, 21)
        Me.cboReturnNumber.TabIndex = 1
        Me.cboReturnNumber.ValueMember = "ItemID"
        '
        'ReturnProductHeaderTableBindingSource
        '
        Me.ReturnProductHeaderTableBindingSource.DataMember = "ReturnProductHeaderTable"
        Me.ReturnProductHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(21, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 20)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Division ID"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(128, 19)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(205, 21)
        Me.cboDivisionID.TabIndex = 0
        Me.cboDivisionID.ValueMember = "ItemID"
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(18, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 20)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Sales Order #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCustomerClass
        '
        Me.lblCustomerClass.Location = New System.Drawing.Point(15, 32)
        Me.lblCustomerClass.Name = "lblCustomerClass"
        Me.lblCustomerClass.Size = New System.Drawing.Size(104, 20)
        Me.lblCustomerClass.TabIndex = 64
        Me.lblCustomerClass.Text = "Customer Class"
        Me.lblCustomerClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerClass
        '
        Me.cboCustomerClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerClass.DataSource = Me.CustomerClassBindingSource
        Me.cboCustomerClass.DisplayMember = "CustomerClassID"
        Me.cboCustomerClass.DropDownWidth = 300
        Me.cboCustomerClass.FormattingEnabled = True
        Me.cboCustomerClass.Location = New System.Drawing.Point(125, 33)
        Me.cboCustomerClass.Name = "cboCustomerClass"
        Me.cboCustomerClass.Size = New System.Drawing.Size(197, 21)
        Me.cboCustomerClass.TabIndex = 30
        '
        'CustomerClassBindingSource
        '
        Me.CustomerClassBindingSource.DataMember = "CustomerClass"
        Me.CustomerClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboDescription
        '
        Me.cboDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDescription.DataSource = Me.ItemListBindingSource
        Me.cboDescription.DisplayMember = "ShortDescription"
        Me.cboDescription.DropDownWidth = 350
        Me.cboDescription.FormattingEnabled = True
        Me.cboDescription.Location = New System.Drawing.Point(23, 58)
        Me.cboDescription.Name = "cboDescription"
        Me.cboDescription.Size = New System.Drawing.Size(298, 21)
        Me.cboDescription.TabIndex = 11
        Me.cboDescription.ValueMember = "CustID"
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(254, 398)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 19
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdEnter
        '
        Me.cmdEnter.Location = New System.Drawing.Point(177, 398)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(71, 30)
        Me.cmdEnter.TabIndex = 18
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'txtReturnPrice
        '
        Me.txtReturnPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnPrice.Location = New System.Drawing.Point(177, 184)
        Me.txtReturnPrice.Name = "txtReturnPrice"
        Me.txtReturnPrice.Size = New System.Drawing.Size(148, 20)
        Me.txtReturnPrice.TabIndex = 13
        Me.txtReturnPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(23, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 20)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "Part #"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(28, 184)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 20)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Unit Price"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboReturnPartNumber
        '
        Me.cboReturnPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReturnPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReturnPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboReturnPartNumber.DisplayMember = "ItemID"
        Me.cboReturnPartNumber.DropDownWidth = 250
        Me.cboReturnPartNumber.FormattingEnabled = True
        Me.cboReturnPartNumber.Location = New System.Drawing.Point(66, 27)
        Me.cboReturnPartNumber.Name = "cboReturnPartNumber"
        Me.cboReturnPartNumber.Size = New System.Drawing.Size(255, 21)
        Me.cboReturnPartNumber.TabIndex = 10
        Me.cboReturnPartNumber.ValueMember = "CustID"
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(831, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 29
        Me.cmdSave.Text = "Save Return"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(908, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 30
        Me.cmdDelete.Text = "Delete Return"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(985, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 31
        Me.cmdPrint.Text = "Print Return"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'gpxReturnTotals
        '
        Me.gpxReturnTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxReturnTotals.Controls.Add(Me.cmdRemoveSalesTax)
        Me.gpxReturnTotals.Controls.Add(Me.lblReturnTotal)
        Me.gpxReturnTotals.Controls.Add(Me.txtReturnSalesTax3)
        Me.gpxReturnTotals.Controls.Add(Me.LabelHST)
        Me.gpxReturnTotals.Controls.Add(Me.Label19)
        Me.gpxReturnTotals.Controls.Add(Me.lblProductTotal)
        Me.gpxReturnTotals.Controls.Add(Me.Label16)
        Me.gpxReturnTotals.Controls.Add(Me.txtReturnSalesTax2)
        Me.gpxReturnTotals.Controls.Add(Me.LabelPST)
        Me.gpxReturnTotals.Controls.Add(Me.txtReturnSalesTax)
        Me.gpxReturnTotals.Controls.Add(Me.Label21)
        Me.gpxReturnTotals.Controls.Add(Me.txtReturnFreight)
        Me.gpxReturnTotals.Controls.Add(Me.LabelGST)
        Me.gpxReturnTotals.Location = New System.Drawing.Point(399, 619)
        Me.gpxReturnTotals.Name = "gpxReturnTotals"
        Me.gpxReturnTotals.Size = New System.Drawing.Size(308, 195)
        Me.gpxReturnTotals.TabIndex = 21
        Me.gpxReturnTotals.TabStop = False
        Me.gpxReturnTotals.Text = "Return Totals"
        '
        'cmdRemoveSalesTax
        '
        Me.cmdRemoveSalesTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemoveSalesTax.ForeColor = System.Drawing.Color.Blue
        Me.cmdRemoveSalesTax.Location = New System.Drawing.Point(137, 77)
        Me.cmdRemoveSalesTax.Name = "cmdRemoveSalesTax"
        Me.cmdRemoveSalesTax.Size = New System.Drawing.Size(29, 20)
        Me.cmdRemoveSalesTax.TabIndex = 22
        Me.cmdRemoveSalesTax.Text = "<<"
        Me.cmdRemoveSalesTax.UseVisualStyleBackColor = True
        '
        'lblReturnTotal
        '
        Me.lblReturnTotal.BackColor = System.Drawing.Color.White
        Me.lblReturnTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReturnTotal.Location = New System.Drawing.Point(172, 161)
        Me.lblReturnTotal.Name = "lblReturnTotal"
        Me.lblReturnTotal.Size = New System.Drawing.Size(120, 21)
        Me.lblReturnTotal.TabIndex = 57
        Me.lblReturnTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtReturnSalesTax3
        '
        Me.txtReturnSalesTax3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnSalesTax3.Location = New System.Drawing.Point(172, 133)
        Me.txtReturnSalesTax3.Name = "txtReturnSalesTax3"
        Me.txtReturnSalesTax3.Size = New System.Drawing.Size(120, 20)
        Me.txtReturnSalesTax3.TabIndex = 33
        Me.txtReturnSalesTax3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelHST
        '
        Me.LabelHST.Location = New System.Drawing.Point(19, 133)
        Me.LabelHST.Name = "LabelHST"
        Me.LabelHST.Size = New System.Drawing.Size(103, 20)
        Me.LabelHST.TabIndex = 56
        Me.LabelHST.Text = "HST"
        Me.LabelHST.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(19, 161)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(103, 20)
        Me.Label19.TabIndex = 52
        Me.Label19.Text = "Return Total"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProductTotal
        '
        Me.lblProductTotal.BackColor = System.Drawing.Color.White
        Me.lblProductTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProductTotal.ForeColor = System.Drawing.Color.Black
        Me.lblProductTotal.Location = New System.Drawing.Point(172, 21)
        Me.lblProductTotal.Name = "lblProductTotal"
        Me.lblProductTotal.Size = New System.Drawing.Size(120, 20)
        Me.lblProductTotal.TabIndex = 29
        Me.lblProductTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(19, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(103, 20)
        Me.Label16.TabIndex = 50
        Me.Label16.Text = "Product Total"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReturnSalesTax2
        '
        Me.txtReturnSalesTax2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnSalesTax2.Location = New System.Drawing.Point(172, 105)
        Me.txtReturnSalesTax2.Name = "txtReturnSalesTax2"
        Me.txtReturnSalesTax2.Size = New System.Drawing.Size(120, 20)
        Me.txtReturnSalesTax2.TabIndex = 32
        Me.txtReturnSalesTax2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelPST
        '
        Me.LabelPST.Location = New System.Drawing.Point(19, 105)
        Me.LabelPST.Name = "LabelPST"
        Me.LabelPST.Size = New System.Drawing.Size(103, 20)
        Me.LabelPST.TabIndex = 55
        Me.LabelPST.Text = "PST"
        Me.LabelPST.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReturnSalesTax
        '
        Me.txtReturnSalesTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnSalesTax.Location = New System.Drawing.Point(172, 77)
        Me.txtReturnSalesTax.Name = "txtReturnSalesTax"
        Me.txtReturnSalesTax.Size = New System.Drawing.Size(120, 20)
        Me.txtReturnSalesTax.TabIndex = 31
        Me.txtReturnSalesTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(19, 49)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(103, 20)
        Me.Label21.TabIndex = 39
        Me.Label21.Text = "Return Freight"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReturnFreight
        '
        Me.txtReturnFreight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnFreight.Location = New System.Drawing.Point(172, 49)
        Me.txtReturnFreight.Name = "txtReturnFreight"
        Me.txtReturnFreight.Size = New System.Drawing.Size(120, 20)
        Me.txtReturnFreight.TabIndex = 30
        Me.txtReturnFreight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelGST
        '
        Me.LabelGST.Location = New System.Drawing.Point(19, 77)
        Me.LabelGST.Name = "LabelGST"
        Me.LabelGST.Size = New System.Drawing.Size(103, 20)
        Me.LabelGST.TabIndex = 41
        Me.LabelGST.Text = "Return Sales Tax"
        Me.LabelGST.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(831, 725)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 25
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdViewOpenReturns
        '
        Me.cmdViewOpenReturns.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewOpenReturns.Location = New System.Drawing.Point(1062, 725)
        Me.cmdViewOpenReturns.Name = "cmdViewOpenReturns"
        Me.cmdViewOpenReturns.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewOpenReturns.TabIndex = 28
        Me.cmdViewOpenReturns.Text = "View Open Returns"
        Me.cmdViewOpenReturns.UseVisualStyleBackColor = True
        '
        'SalesOrderLineTableBindingSource
        '
        Me.SalesOrderLineTableBindingSource.DataMember = "SalesOrderLineTable"
        Me.SalesOrderLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvReturnLines
        '
        Me.dgvReturnLines.AllowUserToAddRows = False
        Me.dgvReturnLines.AllowUserToDeleteRows = False
        Me.dgvReturnLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReturnLines.AutoGenerateColumns = False
        Me.dgvReturnLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvReturnLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvReturnLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReturnLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReturnNumberColumn, Me.ReturnLineNumberColumn, Me.PartNumberColumn, Me.DescriptionColumn, Me.QuantityColumn, Me.UnitPriceColumn, Me.ExtendedAmountColumn, Me.LineCommentColumn, Me.DivisionIDColumn, Me.SalesTaxColumn, Me.CreditGLAccountColumn, Me.DebitGLAccountColumn, Me.SOLineNumberColumn})
        Me.dgvReturnLines.DataSource = Me.ReturnProductLineTableBindingSource
        Me.dgvReturnLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvReturnLines.Location = New System.Drawing.Point(0, 0)
        Me.dgvReturnLines.Name = "dgvReturnLines"
        Me.dgvReturnLines.Size = New System.Drawing.Size(723, 477)
        Me.dgvReturnLines.TabIndex = 42
        Me.dgvReturnLines.TabStop = False
        '
        'ReturnNumberColumn
        '
        Me.ReturnNumberColumn.DataPropertyName = "ReturnNumber"
        Me.ReturnNumberColumn.HeaderText = "ReturnNumber"
        Me.ReturnNumberColumn.Name = "ReturnNumberColumn"
        Me.ReturnNumberColumn.ReadOnly = True
        Me.ReturnNumberColumn.Visible = False
        '
        'ReturnLineNumberColumn
        '
        Me.ReturnLineNumberColumn.DataPropertyName = "ReturnLineNumber"
        Me.ReturnLineNumberColumn.HeaderText = "Line #"
        Me.ReturnLineNumberColumn.Name = "ReturnLineNumberColumn"
        Me.ReturnLineNumberColumn.ReadOnly = True
        Me.ReturnLineNumberColumn.Width = 65
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part Number"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        Me.DescriptionColumn.Width = 125
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        DataGridViewCellStyle1.NullValue = "0"
        Me.QuantityColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        '
        'UnitPriceColumn
        '
        Me.UnitPriceColumn.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = "0"
        Me.UnitPriceColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.UnitPriceColumn.HeaderText = "Unit Price"
        Me.UnitPriceColumn.Name = "UnitPriceColumn"
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ExtendedAmountColumn.HeaderText = "Extended Amount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
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
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        Me.SalesTaxColumn.HeaderText = "SalesTax"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        Me.SalesTaxColumn.ReadOnly = True
        Me.SalesTaxColumn.Visible = False
        '
        'CreditGLAccountColumn
        '
        Me.CreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumn.HeaderText = "CreditGLAccount"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
        Me.CreditGLAccountColumn.Visible = False
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "DebitGLAccount"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        Me.DebitGLAccountColumn.Visible = False
        '
        'SOLineNumberColumn
        '
        Me.SOLineNumberColumn.DataPropertyName = "SOLineNumber"
        Me.SOLineNumberColumn.HeaderText = "SOLineNumber"
        Me.SOLineNumberColumn.Name = "SOLineNumberColumn"
        Me.SOLineNumberColumn.Visible = False
        '
        'ReturnProductLineTableBindingSource
        '
        Me.ReturnProductLineTableBindingSource.DataMember = "ReturnProductLineTable"
        Me.ReturnProductLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ReturnProductHeaderTableTableAdapter
        '
        Me.ReturnProductHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'EmployeeDataTableAdapter
        '
        Me.EmployeeDataTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'SalesOrderLineTableTableAdapter
        '
        Me.SalesOrderLineTableTableAdapter.ClearBeforeFill = True
        '
        'ReturnProductLineTableTableAdapter
        '
        Me.ReturnProductLineTableTableAdapter.ClearBeforeFill = True
        '
        'cmdCustomerForm
        '
        Me.cmdCustomerForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCustomerForm.Location = New System.Drawing.Point(908, 725)
        Me.cmdCustomerForm.Name = "cmdCustomerForm"
        Me.cmdCustomerForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdCustomerForm.TabIndex = 26
        Me.cmdCustomerForm.Text = "Customer Form"
        Me.cmdCustomerForm.UseVisualStyleBackColor = True
        '
        'tabItemInfo
        '
        Me.tabItemInfo.Controls.Add(Me.tabPartNumberEntry)
        Me.tabItemInfo.Controls.Add(Me.tabPartNumberData)
        Me.tabItemInfo.Controls.Add(Me.tabDeleteLine)
        Me.tabItemInfo.Controls.Add(Me.TabPage1)
        Me.tabItemInfo.Location = New System.Drawing.Point(29, 347)
        Me.tabItemInfo.Name = "tabItemInfo"
        Me.tabItemInfo.SelectedIndex = 0
        Me.tabItemInfo.Size = New System.Drawing.Size(349, 464)
        Me.tabItemInfo.TabIndex = 10
        '
        'tabPartNumberEntry
        '
        Me.tabPartNumberEntry.Controls.Add(Me.txtLineComment)
        Me.tabPartNumberEntry.Controls.Add(Me.Label26)
        Me.tabPartNumberEntry.Controls.Add(Me.Label20)
        Me.tabPartNumberEntry.Controls.Add(Me.Label7)
        Me.tabPartNumberEntry.Controls.Add(Me.txtSalesTaxLineRate)
        Me.tabPartNumberEntry.Controls.Add(Me.chkAddLineTax)
        Me.tabPartNumberEntry.Controls.Add(Me.cboDescription)
        Me.tabPartNumberEntry.Controls.Add(Me.cboReturnPartNumber)
        Me.tabPartNumberEntry.Controls.Add(Me.cmdClear)
        Me.tabPartNumberEntry.Controls.Add(Me.cmdEnter)
        Me.tabPartNumberEntry.Controls.Add(Me.txtReturnPrice)
        Me.tabPartNumberEntry.Controls.Add(Me.Label11)
        Me.tabPartNumberEntry.Controls.Add(Me.Label3)
        Me.tabPartNumberEntry.Controls.Add(Me.Label1)
        Me.tabPartNumberEntry.Controls.Add(Me.lblComment)
        Me.tabPartNumberEntry.Controls.Add(Me.txtLineTotal)
        Me.tabPartNumberEntry.Controls.Add(Me.txtReturnQuantity)
        Me.tabPartNumberEntry.Location = New System.Drawing.Point(4, 22)
        Me.tabPartNumberEntry.Name = "tabPartNumberEntry"
        Me.tabPartNumberEntry.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPartNumberEntry.Size = New System.Drawing.Size(341, 438)
        Me.tabPartNumberEntry.TabIndex = 0
        Me.tabPartNumberEntry.Text = "Manual Data Entry"
        Me.tabPartNumberEntry.UseVisualStyleBackColor = True
        '
        'txtLineComment
        '
        Me.txtLineComment.BackColor = System.Drawing.Color.White
        Me.txtLineComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineComment.Location = New System.Drawing.Point(27, 280)
        Me.txtLineComment.Multiline = True
        Me.txtLineComment.Name = "txtLineComment"
        Me.txtLineComment.Size = New System.Drawing.Size(298, 80)
        Me.txtLineComment.TabIndex = 15
        Me.txtLineComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(28, 257)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(103, 20)
        Me.Label26.TabIndex = 61
        Me.Label26.Text = "Line Comment"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(28, 123)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(299, 22)
        Me.Label20.TabIndex = 60
        Me.Label20.Text = "Charges for the customer, enter quantity as a negative."
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(28, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(299, 22)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "For returned items, enter quantity as a positive number. "
        '
        'txtSalesTaxLineRate
        '
        Me.txtSalesTaxLineRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTaxLineRate.Location = New System.Drawing.Point(27, 408)
        Me.txtSalesTaxLineRate.Name = "txtSalesTaxLineRate"
        Me.txtSalesTaxLineRate.Size = New System.Drawing.Size(104, 20)
        Me.txtSalesTaxLineRate.TabIndex = 17
        Me.txtSalesTaxLineRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSalesTaxLineRate.Visible = False
        Me.txtSalesTaxLineRate.WordWrap = False
        '
        'chkAddLineTax
        '
        Me.chkAddLineTax.AutoSize = True
        Me.chkAddLineTax.Location = New System.Drawing.Point(27, 385)
        Me.chkAddLineTax.Name = "chkAddLineTax"
        Me.chkAddLineTax.Size = New System.Drawing.Size(70, 17)
        Me.chkAddLineTax.TabIndex = 16
        Me.chkAddLineTax.Text = "Taxable?"
        Me.chkAddLineTax.UseVisualStyleBackColor = True
        '
        'tabPartNumberData
        '
        Me.tabPartNumberData.Controls.Add(Me.txtSalesOffset)
        Me.tabPartNumberData.Controls.Add(Me.Label18)
        Me.tabPartNumberData.Controls.Add(Me.txtGLCOGSAccount)
        Me.tabPartNumberData.Controls.Add(Me.Label22)
        Me.tabPartNumberData.Controls.Add(Me.txtGLInventoryAccount)
        Me.tabPartNumberData.Controls.Add(Me.Label14)
        Me.tabPartNumberData.Controls.Add(Me.txtGLReturnsAccount)
        Me.tabPartNumberData.Controls.Add(Me.Label15)
        Me.tabPartNumberData.Controls.Add(Me.txtGLSalesAccount)
        Me.tabPartNumberData.Controls.Add(Me.Label12)
        Me.tabPartNumberData.Controls.Add(Me.txtItemClassDescription)
        Me.tabPartNumberData.Controls.Add(Me.Label13)
        Me.tabPartNumberData.Controls.Add(Me.Label10)
        Me.tabPartNumberData.Controls.Add(Me.cboItemClass)
        Me.tabPartNumberData.Location = New System.Drawing.Point(4, 22)
        Me.tabPartNumberData.Name = "tabPartNumberData"
        Me.tabPartNumberData.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPartNumberData.Size = New System.Drawing.Size(341, 438)
        Me.tabPartNumberData.TabIndex = 1
        Me.tabPartNumberData.Text = "Item Data"
        Me.tabPartNumberData.UseVisualStyleBackColor = True
        '
        'txtSalesOffset
        '
        Me.txtSalesOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesOffset.Location = New System.Drawing.Point(140, 187)
        Me.txtSalesOffset.Name = "txtSalesOffset"
        Me.txtSalesOffset.Size = New System.Drawing.Size(168, 20)
        Me.txtSalesOffset.TabIndex = 23
        Me.txtSalesOffset.TabStop = False
        Me.txtSalesOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(16, 187)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(103, 20)
        Me.Label18.TabIndex = 53
        Me.Label18.Text = "GL Sales Offset"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGLCOGSAccount
        '
        Me.txtGLCOGSAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLCOGSAccount.Location = New System.Drawing.Point(140, 159)
        Me.txtGLCOGSAccount.Name = "txtGLCOGSAccount"
        Me.txtGLCOGSAccount.Size = New System.Drawing.Size(168, 20)
        Me.txtGLCOGSAccount.TabIndex = 22
        Me.txtGLCOGSAccount.TabStop = False
        Me.txtGLCOGSAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(16, 159)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(103, 20)
        Me.Label22.TabIndex = 52
        Me.Label22.Text = "GL COGS"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGLInventoryAccount
        '
        Me.txtGLInventoryAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLInventoryAccount.Location = New System.Drawing.Point(140, 131)
        Me.txtGLInventoryAccount.Name = "txtGLInventoryAccount"
        Me.txtGLInventoryAccount.Size = New System.Drawing.Size(168, 20)
        Me.txtGLInventoryAccount.TabIndex = 21
        Me.txtGLInventoryAccount.TabStop = False
        Me.txtGLInventoryAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(16, 131)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(103, 20)
        Me.Label14.TabIndex = 49
        Me.Label14.Text = "GL Inventory"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGLReturnsAccount
        '
        Me.txtGLReturnsAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLReturnsAccount.Location = New System.Drawing.Point(140, 103)
        Me.txtGLReturnsAccount.Name = "txtGLReturnsAccount"
        Me.txtGLReturnsAccount.Size = New System.Drawing.Size(168, 20)
        Me.txtGLReturnsAccount.TabIndex = 20
        Me.txtGLReturnsAccount.TabStop = False
        Me.txtGLReturnsAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(16, 103)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(103, 20)
        Me.Label15.TabIndex = 48
        Me.Label15.Text = "GL Returns"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGLSalesAccount
        '
        Me.txtGLSalesAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLSalesAccount.Location = New System.Drawing.Point(140, 75)
        Me.txtGLSalesAccount.Name = "txtGLSalesAccount"
        Me.txtGLSalesAccount.Size = New System.Drawing.Size(168, 20)
        Me.txtGLSalesAccount.TabIndex = 19
        Me.txtGLSalesAccount.TabStop = False
        Me.txtGLSalesAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(16, 75)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 20)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "GL Sales"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtItemClassDescription
        '
        Me.txtItemClassDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemClassDescription.Location = New System.Drawing.Point(140, 47)
        Me.txtItemClassDescription.Name = "txtItemClassDescription"
        Me.txtItemClassDescription.Size = New System.Drawing.Size(168, 20)
        Me.txtItemClassDescription.TabIndex = 18
        Me.txtItemClassDescription.TabStop = False
        Me.txtItemClassDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(16, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(103, 20)
        Me.Label13.TabIndex = 44
        Me.Label13.Text = "Description"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 20)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Item Class"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(140, 18)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(168, 21)
        Me.cboItemClass.TabIndex = 17
        Me.cboItemClass.TabStop = False
        Me.cboItemClass.ValueMember = "ItemID"
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'tabDeleteLine
        '
        Me.tabDeleteLine.Controls.Add(Me.Label24)
        Me.tabDeleteLine.Controls.Add(Me.cboLineNumber)
        Me.tabDeleteLine.Controls.Add(Me.Label29)
        Me.tabDeleteLine.Controls.Add(Me.cboLinePartNumber)
        Me.tabDeleteLine.Controls.Add(Me.cmdDeleteLine)
        Me.tabDeleteLine.Controls.Add(Me.Label25)
        Me.tabDeleteLine.Location = New System.Drawing.Point(4, 22)
        Me.tabDeleteLine.Name = "tabDeleteLine"
        Me.tabDeleteLine.Size = New System.Drawing.Size(341, 438)
        Me.tabDeleteLine.TabIndex = 2
        Me.tabDeleteLine.Text = "Delete Line"
        Me.tabDeleteLine.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Blue
        Me.Label24.Location = New System.Drawing.Point(19, 170)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(298, 87)
        Me.Label24.TabIndex = 65
        Me.Label24.Text = "To delete a line from a Customer Return, select the line number from the drop dow" & _
            "n box or select the line in the datagrid and Press ""Delete Line""."
        '
        'cboLineNumber
        '
        Me.cboLineNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLineNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLineNumber.DataSource = Me.ReturnProductLineTableBindingSource
        Me.cboLineNumber.DisplayMember = "ReturnLineNumber"
        Me.cboLineNumber.FormattingEnabled = True
        Me.cboLineNumber.Location = New System.Drawing.Point(169, 24)
        Me.cboLineNumber.Name = "cboLineNumber"
        Me.cboLineNumber.Size = New System.Drawing.Size(148, 21)
        Me.cboLineNumber.TabIndex = 24
        Me.cboLineNumber.ValueMember = "CustID"
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(15, 25)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(103, 20)
        Me.Label29.TabIndex = 64
        Me.Label29.Text = "Line Number"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLinePartNumber
        '
        Me.cboLinePartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLinePartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLinePartNumber.DataSource = Me.ReturnProductLineTableBindingSource
        Me.cboLinePartNumber.DisplayMember = "PartNumber"
        Me.cboLinePartNumber.FormattingEnabled = True
        Me.cboLinePartNumber.Location = New System.Drawing.Point(108, 59)
        Me.cboLinePartNumber.Name = "cboLinePartNumber"
        Me.cboLinePartNumber.Size = New System.Drawing.Size(209, 21)
        Me.cboLinePartNumber.TabIndex = 25
        Me.cboLinePartNumber.ValueMember = "CustID"
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.Location = New System.Drawing.Point(246, 100)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteLine.TabIndex = 26
        Me.cmdDeleteLine.Text = "Delete Line"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(15, 60)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(103, 20)
        Me.Label25.TabIndex = 61
        Me.Label25.Text = "Part Number"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label30)
        Me.TabPage1.Controls.Add(Me.cmdDeleteSN)
        Me.TabPage1.Controls.Add(Me.dgvSerialLogTemp)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(341, 438)
        Me.TabPage1.TabIndex = 3
        Me.TabPage1.Text = "Serial #'s"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.ForeColor = System.Drawing.Color.Blue
        Me.Label30.Location = New System.Drawing.Point(38, 397)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(214, 31)
        Me.Label30.TabIndex = 60
        Me.Label30.Text = "To remove a serial number from this returm, select in datagrid and press delete."
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteSN
        '
        Me.cmdDeleteSN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteSN.ForeColor = System.Drawing.Color.Blue
        Me.cmdDeleteSN.Location = New System.Drawing.Point(258, 398)
        Me.cmdDeleteSN.Name = "cmdDeleteSN"
        Me.cmdDeleteSN.Size = New System.Drawing.Size(71, 30)
        Me.cmdDeleteSN.TabIndex = 59
        Me.cmdDeleteSN.Text = "Delete"
        Me.cmdDeleteSN.UseVisualStyleBackColor = True
        '
        'dgvSerialLogTemp
        '
        Me.dgvSerialLogTemp.AllowUserToAddRows = False
        Me.dgvSerialLogTemp.AllowUserToDeleteRows = False
        Me.dgvSerialLogTemp.AutoGenerateColumns = False
        Me.dgvSerialLogTemp.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSerialLogTemp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSerialLogTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSerialLogTemp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AssemblyPartNumberColumn, Me.SerialNumberColumn, Me.DivisionID2Column, Me.TotalCostColumn, Me.CommentColumn, Me.BuildDateColumn, Me.StatusColumn, Me.BuildNumberColumn, Me.CustomerIDColumn, Me.BatchNumberColumn, Me.TransactionNumberColumn})
        Me.dgvSerialLogTemp.DataSource = Me.AssemblySerialTempTableBindingSource
        Me.dgvSerialLogTemp.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvSerialLogTemp.Location = New System.Drawing.Point(13, 8)
        Me.dgvSerialLogTemp.Name = "dgvSerialLogTemp"
        Me.dgvSerialLogTemp.ReadOnly = True
        Me.dgvSerialLogTemp.Size = New System.Drawing.Size(316, 372)
        Me.dgvSerialLogTemp.TabIndex = 58
        '
        'AssemblyPartNumberColumn
        '
        Me.AssemblyPartNumberColumn.DataPropertyName = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn.HeaderText = "Part #"
        Me.AssemblyPartNumberColumn.Name = "AssemblyPartNumberColumn"
        Me.AssemblyPartNumberColumn.ReadOnly = True
        Me.AssemblyPartNumberColumn.Width = 120
        '
        'SerialNumberColumn
        '
        Me.SerialNumberColumn.DataPropertyName = "SerialNumber"
        Me.SerialNumberColumn.HeaderText = "Serial #"
        Me.SerialNumberColumn.Name = "SerialNumberColumn"
        Me.SerialNumberColumn.ReadOnly = True
        Me.SerialNumberColumn.Width = 150
        '
        'DivisionID2Column
        '
        Me.DivisionID2Column.DataPropertyName = "DivisionID"
        Me.DivisionID2Column.HeaderText = "DivisionID"
        Me.DivisionID2Column.Name = "DivisionID2Column"
        Me.DivisionID2Column.ReadOnly = True
        Me.DivisionID2Column.Visible = False
        '
        'TotalCostColumn
        '
        Me.TotalCostColumn.DataPropertyName = "TotalCost"
        Me.TotalCostColumn.HeaderText = "TotalCost"
        Me.TotalCostColumn.Name = "TotalCostColumn"
        Me.TotalCostColumn.ReadOnly = True
        Me.TotalCostColumn.Visible = False
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        Me.CommentColumn.ReadOnly = True
        Me.CommentColumn.Visible = False
        '
        'BuildDateColumn
        '
        Me.BuildDateColumn.DataPropertyName = "BuildDate"
        Me.BuildDateColumn.HeaderText = "BuildDate"
        Me.BuildDateColumn.Name = "BuildDateColumn"
        Me.BuildDateColumn.ReadOnly = True
        Me.BuildDateColumn.Visible = False
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.ReadOnly = True
        Me.StatusColumn.Visible = False
        '
        'BuildNumberColumn
        '
        Me.BuildNumberColumn.DataPropertyName = "BuildNumber"
        Me.BuildNumberColumn.HeaderText = "BuildNumber"
        Me.BuildNumberColumn.Name = "BuildNumberColumn"
        Me.BuildNumberColumn.ReadOnly = True
        Me.BuildNumberColumn.Visible = False
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "CustomerID"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        Me.CustomerIDColumn.Visible = False
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "BatchNumber"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.ReadOnly = True
        Me.BatchNumberColumn.Visible = False
        '
        'TransactionNumberColumn
        '
        Me.TransactionNumberColumn.DataPropertyName = "TransactionNumber"
        Me.TransactionNumberColumn.HeaderText = "TransactionNumber"
        Me.TransactionNumberColumn.Name = "TransactionNumberColumn"
        Me.TransactionNumberColumn.ReadOnly = True
        Me.TransactionNumberColumn.Visible = False
        '
        'AssemblySerialTempTableBindingSource
        '
        Me.AssemblySerialTempTableBindingSource.DataMember = "AssemblySerialTempTable"
        Me.AssemblySerialTempTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'cmdItemForm
        '
        Me.cmdItemForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdItemForm.Location = New System.Drawing.Point(985, 725)
        Me.cmdItemForm.Name = "cmdItemForm"
        Me.cmdItemForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdItemForm.TabIndex = 27
        Me.cmdItemForm.Text = "Item Form"
        Me.cmdItemForm.UseVisualStyleBackColor = True
        '
        'cmdSelectLinesFromSO
        '
        Me.cmdSelectLinesFromSO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectLinesFromSO.ForeColor = System.Drawing.Color.Blue
        Me.cmdSelectLinesFromSO.Location = New System.Drawing.Point(399, 564)
        Me.cmdSelectLinesFromSO.Name = "cmdSelectLinesFromSO"
        Me.cmdSelectLinesFromSO.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectLinesFromSO.TabIndex = 20
        Me.cmdSelectLinesFromSO.Text = "Select Lines"
        Me.cmdSelectLinesFromSO.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(481, 568)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(201, 27)
        Me.Label9.TabIndex = 57
        Me.Label9.Text = "Select lines to add to Customer Return by Sales Order."
        '
        'gpxPostData
        '
        Me.gpxPostData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxPostData.Controls.Add(Me.Label17)
        Me.gpxPostData.Controls.Add(Me.cmdPostReturn)
        Me.gpxPostData.Location = New System.Drawing.Point(831, 565)
        Me.gpxPostData.Name = "gpxPostData"
        Me.gpxPostData.Size = New System.Drawing.Size(302, 144)
        Me.gpxPostData.TabIndex = 23
        Me.gpxPostData.TabStop = False
        Me.gpxPostData.Text = "Post Customer Return"
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(23, 37)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(260, 27)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "Customer Returns must be POSTED. After POSTING, no additional changes may be made" & _
            "."
        '
        'cmdPostReturn
        '
        Me.cmdPostReturn.ForeColor = System.Drawing.Color.Blue
        Me.cmdPostReturn.Location = New System.Drawing.Point(212, 84)
        Me.cmdPostReturn.Name = "cmdPostReturn"
        Me.cmdPostReturn.Size = New System.Drawing.Size(71, 40)
        Me.cmdPostReturn.TabIndex = 24
        Me.cmdPostReturn.Text = "Post Return"
        Me.cmdPostReturn.UseVisualStyleBackColor = True
        '
        'CustomerClassTableAdapter
        '
        Me.CustomerClassTableAdapter.ClearBeforeFill = True
        '
        'AssemblySerialTempTableTableAdapter
        '
        Me.AssemblySerialTempTableTableAdapter.ClearBeforeFill = True
        '
        'AssemblySerialTempTableBindingSource1
        '
        Me.AssemblySerialTempTableBindingSource1.DataMember = "AssemblySerialTempTable"
        Me.AssemblySerialTempTableBindingSource1.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'tabReturnData
        '
        Me.tabReturnData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabReturnData.Controls.Add(Me.tabLines)
        Me.tabReturnData.Controls.Add(Me.tabOtherData)
        Me.tabReturnData.Location = New System.Drawing.Point(399, 42)
        Me.tabReturnData.Name = "tabReturnData"
        Me.tabReturnData.SelectedIndex = 0
        Me.tabReturnData.Size = New System.Drawing.Size(731, 500)
        Me.tabReturnData.TabIndex = 58
        '
        'tabLines
        '
        Me.tabLines.Controls.Add(Me.dgvReturnLines)
        Me.tabLines.Location = New System.Drawing.Point(4, 22)
        Me.tabLines.Name = "tabLines"
        Me.tabLines.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLines.Size = New System.Drawing.Size(723, 474)
        Me.tabLines.TabIndex = 0
        Me.tabLines.Text = "Return Lines"
        Me.tabLines.UseVisualStyleBackColor = True
        '
        'tabOtherData
        '
        Me.tabOtherData.Controls.Add(Me.gpxConsignmentBox)
        Me.tabOtherData.Controls.Add(Me.txtReturnReason)
        Me.tabOtherData.Controls.Add(Me.lblContact)
        Me.tabOtherData.Location = New System.Drawing.Point(4, 22)
        Me.tabOtherData.Name = "tabOtherData"
        Me.tabOtherData.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOtherData.Size = New System.Drawing.Size(623, 474)
        Me.tabOtherData.TabIndex = 1
        Me.tabOtherData.Text = "Reason / Comment"
        Me.tabOtherData.UseVisualStyleBackColor = True
        '
        'gpxConsignmentBox
        '
        Me.gpxConsignmentBox.Controls.Add(Me.txtFOBName)
        Me.gpxConsignmentBox.Controls.Add(Me.cboFOB)
        Me.gpxConsignmentBox.Controls.Add(Me.cboCustomerClass)
        Me.gpxConsignmentBox.Controls.Add(Me.Label31)
        Me.gpxConsignmentBox.Controls.Add(Me.Label28)
        Me.gpxConsignmentBox.Controls.Add(Me.Label27)
        Me.gpxConsignmentBox.Controls.Add(Me.lblCustomerClass)
        Me.gpxConsignmentBox.Controls.Add(Me.Label8)
        Me.gpxConsignmentBox.Location = New System.Drawing.Point(18, 15)
        Me.gpxConsignmentBox.Name = "gpxConsignmentBox"
        Me.gpxConsignmentBox.Size = New System.Drawing.Size(352, 254)
        Me.gpxConsignmentBox.TabIndex = 67
        Me.gpxConsignmentBox.TabStop = False
        Me.gpxConsignmentBox.Text = "For Consignment Returns Only."
        '
        'txtFOBName
        '
        Me.txtFOBName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFOBName.Enabled = False
        Me.txtFOBName.Location = New System.Drawing.Point(125, 95)
        Me.txtFOBName.Name = "txtFOBName"
        Me.txtFOBName.ReadOnly = True
        Me.txtFOBName.Size = New System.Drawing.Size(197, 20)
        Me.txtFOBName.TabIndex = 69
        '
        'cboFOB
        '
        Me.cboFOB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFOB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFOB.DropDownWidth = 300
        Me.cboFOB.FormattingEnabled = True
        Me.cboFOB.Items.AddRange(New Object() {"BCW", "DCW", "HCW", "LCW", "LSCW", "PCW", "RCW", "SCW", "YCW", "SRL", "TWD", "TWE", "TFF", "TFP", "CGO", "CHT", "CBS", "DEN", "HOU", "ATL", "TFT", "TOR", "SLC"})
        Me.cboFOB.Location = New System.Drawing.Point(125, 64)
        Me.cboFOB.Name = "cboFOB"
        Me.cboFOB.Size = New System.Drawing.Size(197, 21)
        Me.cboFOB.TabIndex = 31
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(15, 95)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(104, 20)
        Me.Label31.TabIndex = 70
        Me.Label31.Text = "FOB Name"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Blue
        Me.Label28.Location = New System.Drawing.Point(15, 186)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(318, 57)
        Me.Label28.TabIndex = 68
        Me.Label28.Text = "For a return from a comsignment warehouse to a division, Customer Class should be" & _
            " the Consignment Warehouse ID and FOB will be the Division ID."
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Blue
        Me.Label27.Location = New System.Drawing.Point(15, 132)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(318, 54)
        Me.Label27.TabIndex = 67
        Me.Label27.Text = "For a return from a customer to a consignment warehouse, FOB and Customer Class s" & _
            "hould be the consignment warehouse ID."
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(15, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 20)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "FOB"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ReturnProductForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.tabReturnData)
        Me.Controls.Add(Me.gpxPostData)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmdSelectLinesFromSO)
        Me.Controls.Add(Me.cmdItemForm)
        Me.Controls.Add(Me.tabItemInfo)
        Me.Controls.Add(Me.cmdCustomerForm)
        Me.Controls.Add(Me.cmdViewOpenReturns)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.gpxReturnTotals)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.gpxReturnHeader)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ReturnProductForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Customer Product Return Form"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxReturnHeader.ResumeLayout(False)
        Me.gpxReturnHeader.PerformLayout()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReturnProductHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxReturnTotals.ResumeLayout(False)
        Me.gpxReturnTotals.PerformLayout()
        CType(Me.SalesOrderLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReturnLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReturnProductLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabItemInfo.ResumeLayout(False)
        Me.tabPartNumberEntry.ResumeLayout(False)
        Me.tabPartNumberEntry.PerformLayout()
        Me.tabPartNumberData.ResumeLayout(False)
        Me.tabPartNumberData.PerformLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDeleteLine.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvSerialLogTemp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssemblySerialTempTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxPostData.ResumeLayout(False)
        CType(Me.AssemblySerialTempTableBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabReturnData.ResumeLayout(False)
        Me.tabLines.ResumeLayout(False)
        Me.tabOtherData.ResumeLayout(False)
        Me.tabOtherData.PerformLayout()
        Me.gpxConsignmentBox.ResumeLayout(False)
        Me.gpxConsignmentBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboReturnSalesperson As System.Windows.Forms.ComboBox
    Friend WithEvents lblComment As System.Windows.Forms.Label
    Friend WithEvents cboReturnCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblContact As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtReturnQuantity As System.Windows.Forms.TextBox
    Friend WithEvents lblPartNumber As System.Windows.Forms.Label
    Friend WithEvents txtLineTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtReturnReason As System.Windows.Forms.TextBox
    Friend WithEvents gpxReturnHeader As System.Windows.Forms.GroupBox
    Friend WithEvents txtReturnPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboReturnPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboReturnNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboDescription As System.Windows.Forms.ComboBox
    Friend WithEvents gpxReturnTotals As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblProductTotal As System.Windows.Forms.Label
    Friend WithEvents txtReturnSalesTax As System.Windows.Forms.TextBox
    Friend WithEvents LabelGST As System.Windows.Forms.Label
    Friend WithEvents txtReturnFreight As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdViewOpenReturns As System.Windows.Forms.Button
    Friend WithEvents cmdGenerateNewReturnNumber As System.Windows.Forms.Button
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents cboSalesOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents ReturnProductHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReturnProductHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReturnProductHeaderTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents SalesOrderLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderLineTableTableAdapter
    Friend WithEvents dgvReturnLines As System.Windows.Forms.DataGridView
    Friend WithEvents ReturnProductLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReturnProductLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReturnProductLineTableTableAdapter
    Friend WithEvents cmdCustomerForm As System.Windows.Forms.Button
    Friend WithEvents tabItemInfo As System.Windows.Forms.TabControl
    Friend WithEvents tabPartNumberEntry As System.Windows.Forms.TabPage
    Friend WithEvents tabPartNumberData As System.Windows.Forms.TabPage
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents txtSalesOffset As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtGLCOGSAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtGLInventoryAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtGLReturnsAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtGLSalesAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtItemClassDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents cmdItemForm As System.Windows.Forms.Button
    Friend WithEvents cmdSelectLinesFromSO As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents gpxPostData As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPostReturn As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents SaveReturnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteReturnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintReturnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtReturnStatus As System.Windows.Forms.TextBox
    Friend WithEvents ClearFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabDeleteLine As System.Windows.Forms.TabPage
    Friend WithEvents cboLinePartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cboLineNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents LabelHST As System.Windows.Forms.Label
    Friend WithEvents txtReturnSalesTax2 As System.Windows.Forms.TextBox
    Friend WithEvents LabelPST As System.Windows.Forms.Label
    Friend WithEvents txtReturnSalesTax3 As System.Windows.Forms.TextBox
    Friend WithEvents txtSalesTaxLineRate As System.Windows.Forms.TextBox
    Friend WithEvents chkAddLineTax As System.Windows.Forms.CheckBox
    Friend WithEvents lblReturnTotal As System.Windows.Forms.Label
    Friend WithEvents cmdRemoveSalesTax As System.Windows.Forms.Button
    Friend WithEvents ManuallyCloseReturnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblCustomerClass As System.Windows.Forms.Label
    Friend WithEvents cboCustomerClass As System.Windows.Forms.ComboBox
    Friend WithEvents UnLockReturnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtpReturnDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents CustomerClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerClassTableAdapter
    Friend WithEvents CachedCRXInvoiceCosting1 As MOS09Program.CachedCRXInvoiceCosting
    Friend WithEvents dgvSerialLogTemp As System.Windows.Forms.DataGridView
    Friend WithEvents AssemblySerialTempTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AssemblySerialTempTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblySerialTempTableTableAdapter
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents AssemblySerialTempTableBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents cmdDeleteSN As System.Windows.Forms.Button
    Friend WithEvents AssemblyPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionID2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtLineComment As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents ReturnNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitPriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tabReturnData As System.Windows.Forms.TabControl
    Friend WithEvents tabLines As System.Windows.Forms.TabPage
    Friend WithEvents tabOtherData As System.Windows.Forms.TabPage
    Friend WithEvents cboFOB As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents gpxConsignmentBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtFOBName As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
End Class
