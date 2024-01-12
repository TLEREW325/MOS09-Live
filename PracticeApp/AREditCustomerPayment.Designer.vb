<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AREditCustomerPayment
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
        Me.ClearAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintPaymentRecordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdClearForm = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkCustomerOnly = New System.Windows.Forms.CheckBox
        Me.dtpSelectDate = New System.Windows.Forms.DateTimePicker
        Me.Label31 = New System.Windows.Forms.Label
        Me.cboARTransactionNumber = New System.Windows.Forms.ComboBox
        Me.ARCustomerPaymentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.ARCustomerPaymentTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARCustomerPaymentTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtInvoiceNumber = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtPaymentLine = New System.Windows.Forms.TextBox
        Me.txtPaymentType = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtPaymentID = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtBankAccount = New System.Windows.Forms.TextBox
        Me.txtPaymentDate = New System.Windows.Forms.TextBox
        Me.txtBatchNumber = New System.Windows.Forms.TextBox
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtAuthorizationNumber = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtCardDate = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtCardNumber = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtCheckNumber = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPaymentAmount = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtDiscountAmount = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtInvoiceAmount = New System.Windows.Forms.TextBox
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtCardType = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtTenderType = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtCreditComment = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtCheckComment = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtReferenceNumber = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.txtDebitDescription = New System.Windows.Forms.TextBox
        Me.txtCreditDescription = New System.Windows.Forms.TextBox
        Me.txtCreditAccount = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.txtCreditAmount = New System.Windows.Forms.TextBox
        Me.txtPostDate = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtDebitAccount = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtDebitAmount = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ARCustomerPaymentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearAllToolStripMenuItem, Me.SaveToolStripMenuItem, Me.PrintPaymentRecordToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ClearAllToolStripMenuItem
        '
        Me.ClearAllToolStripMenuItem.Name = "ClearAllToolStripMenuItem"
        Me.ClearAllToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ClearAllToolStripMenuItem.Text = "Clear All"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'PrintPaymentRecordToolStripMenuItem
        '
        Me.PrintPaymentRecordToolStripMenuItem.Name = "PrintPaymentRecordToolStripMenuItem"
        Me.PrintPaymentRecordToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.PrintPaymentRecordToolStripMenuItem.Text = "Print Payment Record"
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
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(787, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 36
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdClearForm
        '
        Me.cmdClearForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearForm.Location = New System.Drawing.Point(701, 771)
        Me.cmdClearForm.Name = "cmdClearForm"
        Me.cmdClearForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearForm.TabIndex = 38
        Me.cmdClearForm.Text = "Clear All"
        Me.cmdClearForm.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(873, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 39
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 40
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkCustomerOnly)
        Me.GroupBox1.Controls.Add(Me.dtpSelectDate)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.cboARTransactionNumber)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboCustomerName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboCustomerID)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 304)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Customer"
        '
        'chkCustomerOnly
        '
        Me.chkCustomerOnly.AutoSize = True
        Me.chkCustomerOnly.Location = New System.Drawing.Point(22, 168)
        Me.chkCustomerOnly.Name = "chkCustomerOnly"
        Me.chkCustomerOnly.Size = New System.Drawing.Size(266, 17)
        Me.chkCustomerOnly.TabIndex = 4
        Me.chkCustomerOnly.Text = "Check box to select all payments by customer only."
        Me.chkCustomerOnly.UseVisualStyleBackColor = True
        '
        'dtpSelectDate
        '
        Me.dtpSelectDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSelectDate.Location = New System.Drawing.Point(104, 60)
        Me.dtpSelectDate.Name = "dtpSelectDate"
        Me.dtpSelectDate.Size = New System.Drawing.Size(182, 20)
        Me.dtpSelectDate.TabIndex = 1
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(19, 59)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(133, 23)
        Me.Label31.TabIndex = 49
        Me.Label31.Text = "Post Date"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboARTransactionNumber
        '
        Me.cboARTransactionNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboARTransactionNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboARTransactionNumber.DataSource = Me.ARCustomerPaymentBindingSource
        Me.cboARTransactionNumber.DisplayMember = "ARTransactionKey"
        Me.cboARTransactionNumber.FormattingEnabled = True
        Me.cboARTransactionNumber.Location = New System.Drawing.Point(122, 264)
        Me.cboARTransactionNumber.Name = "cboARTransactionNumber"
        Me.cboARTransactionNumber.Size = New System.Drawing.Size(164, 21)
        Me.cboARTransactionNumber.TabIndex = 5
        '
        'ARCustomerPaymentBindingSource
        '
        Me.ARCustomerPaymentBindingSource.DataMember = "ARCustomerPayment"
        Me.ARCustomerPaymentBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 264)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Payment Trans. #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(22, 132)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(264, 21)
        Me.cboCustomerName.TabIndex = 3
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(19, 199)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(267, 32)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Select Customer and post date to view all customer payments by transaction number" & _
            "."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(104, 96)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(182, 21)
        Me.cboCustomerID.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Customer ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(104, 25)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(182, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ARCustomerPaymentTableAdapter
        '
        Me.ARCustomerPaymentTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtInvoiceNumber)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtPaymentLine)
        Me.GroupBox2.Controls.Add(Me.txtPaymentType)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtPaymentID)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtBankAccount)
        Me.GroupBox2.Controls.Add(Me.txtPaymentDate)
        Me.GroupBox2.Controls.Add(Me.txtBatchNumber)
        Me.GroupBox2.Controls.Add(Me.txtStatus)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Location = New System.Drawing.Point(32, 403)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 309)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Payment Details"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 130)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 23)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Invoice Number"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInvoiceNumber
        '
        Me.txtInvoiceNumber.BackColor = System.Drawing.Color.White
        Me.txtInvoiceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceNumber.Location = New System.Drawing.Point(122, 130)
        Me.txtInvoiceNumber.Name = "txtInvoiceNumber"
        Me.txtInvoiceNumber.ReadOnly = True
        Me.txtInvoiceNumber.Size = New System.Drawing.Size(161, 20)
        Me.txtInvoiceNumber.TabIndex = 9
        Me.txtInvoiceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(16, 270)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 23)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "Payment Type"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(16, 200)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 23)
        Me.Label15.TabIndex = 83
        Me.Label15.Text = "Payment Line #"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(16, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 23)
        Me.Label17.TabIndex = 79
        Me.Label17.Text = "Batch Number"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPaymentLine
        '
        Me.txtPaymentLine.BackColor = System.Drawing.Color.White
        Me.txtPaymentLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaymentLine.Location = New System.Drawing.Point(122, 200)
        Me.txtPaymentLine.Name = "txtPaymentLine"
        Me.txtPaymentLine.ReadOnly = True
        Me.txtPaymentLine.Size = New System.Drawing.Size(161, 20)
        Me.txtPaymentLine.TabIndex = 11
        Me.txtPaymentLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPaymentType
        '
        Me.txtPaymentType.BackColor = System.Drawing.Color.White
        Me.txtPaymentType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaymentType.Location = New System.Drawing.Point(122, 270)
        Me.txtPaymentType.Name = "txtPaymentType"
        Me.txtPaymentType.Size = New System.Drawing.Size(161, 20)
        Me.txtPaymentType.TabIndex = 13
        Me.txtPaymentType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(16, 165)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 23)
        Me.Label16.TabIndex = 81
        Me.Label16.Text = "Payment ID"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(16, 95)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 23)
        Me.Label18.TabIndex = 77
        Me.Label18.Text = "Bank Account"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPaymentID
        '
        Me.txtPaymentID.BackColor = System.Drawing.Color.White
        Me.txtPaymentID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaymentID.Location = New System.Drawing.Point(122, 165)
        Me.txtPaymentID.Name = "txtPaymentID"
        Me.txtPaymentID.ReadOnly = True
        Me.txtPaymentID.Size = New System.Drawing.Size(161, 20)
        Me.txtPaymentID.TabIndex = 10
        Me.txtPaymentID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(16, 235)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Payment Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBankAccount
        '
        Me.txtBankAccount.BackColor = System.Drawing.Color.White
        Me.txtBankAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBankAccount.Location = New System.Drawing.Point(122, 95)
        Me.txtBankAccount.Name = "txtBankAccount"
        Me.txtBankAccount.ReadOnly = True
        Me.txtBankAccount.Size = New System.Drawing.Size(161, 20)
        Me.txtBankAccount.TabIndex = 8
        Me.txtBankAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPaymentDate
        '
        Me.txtPaymentDate.BackColor = System.Drawing.Color.White
        Me.txtPaymentDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaymentDate.Location = New System.Drawing.Point(122, 235)
        Me.txtPaymentDate.Name = "txtPaymentDate"
        Me.txtPaymentDate.Size = New System.Drawing.Size(161, 20)
        Me.txtPaymentDate.TabIndex = 12
        Me.txtPaymentDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBatchNumber
        '
        Me.txtBatchNumber.BackColor = System.Drawing.Color.White
        Me.txtBatchNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchNumber.Location = New System.Drawing.Point(122, 25)
        Me.txtBatchNumber.Name = "txtBatchNumber"
        Me.txtBatchNumber.ReadOnly = True
        Me.txtBatchNumber.Size = New System.Drawing.Size(161, 20)
        Me.txtBatchNumber.TabIndex = 6
        Me.txtBatchNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.White
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStatus.Location = New System.Drawing.Point(122, 60)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(161, 20)
        Me.txtStatus.TabIndex = 7
        Me.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(16, 60)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(100, 23)
        Me.Label21.TabIndex = 71
        Me.Label21.Text = "Status"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(22, 87)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(105, 23)
        Me.Label13.TabIndex = 63
        Me.Label13.Text = "Auth. #"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAuthorizationNumber
        '
        Me.txtAuthorizationNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAuthorizationNumber.Location = New System.Drawing.Point(131, 87)
        Me.txtAuthorizationNumber.Name = "txtAuthorizationNumber"
        Me.txtAuthorizationNumber.Size = New System.Drawing.Size(187, 20)
        Me.txtAuthorizationNumber.TabIndex = 20
        Me.txtAuthorizationNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(22, 56)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(105, 23)
        Me.Label14.TabIndex = 61
        Me.Label14.Text = "Card Date"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCardDate
        '
        Me.txtCardDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCardDate.Location = New System.Drawing.Point(130, 56)
        Me.txtCardDate.Name = "txtCardDate"
        Me.txtCardDate.Size = New System.Drawing.Size(187, 20)
        Me.txtCardDate.TabIndex = 19
        Me.txtCardDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(22, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 23)
        Me.Label11.TabIndex = 59
        Me.Label11.Text = "Card Number"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCardNumber
        '
        Me.txtCardNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCardNumber.Location = New System.Drawing.Point(131, 25)
        Me.txtCardNumber.Name = "txtCardNumber"
        Me.txtCardNumber.Size = New System.Drawing.Size(187, 20)
        Me.txtCardNumber.TabIndex = 18
        Me.txtCardNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(22, 57)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 23)
        Me.Label12.TabIndex = 57
        Me.Label12.Text = "Check Number"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCheckNumber
        '
        Me.txtCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckNumber.Location = New System.Drawing.Point(128, 60)
        Me.txtCheckNumber.Name = "txtCheckNumber"
        Me.txtCheckNumber.Size = New System.Drawing.Size(190, 20)
        Me.txtCheckNumber.TabIndex = 15
        Me.txtCheckNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(21, 81)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 23)
        Me.Label9.TabIndex = 55
        Me.Label9.Text = "Payment Amount"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPaymentAmount
        '
        Me.txtPaymentAmount.BackColor = System.Drawing.Color.White
        Me.txtPaymentAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaymentAmount.Location = New System.Drawing.Point(181, 81)
        Me.txtPaymentAmount.Name = "txtPaymentAmount"
        Me.txtPaymentAmount.Size = New System.Drawing.Size(136, 20)
        Me.txtPaymentAmount.TabIndex = 23
        Me.txtPaymentAmount.TabStop = False
        Me.txtPaymentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(21, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 23)
        Me.Label10.TabIndex = 53
        Me.Label10.Text = "Discount Amount"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDiscountAmount
        '
        Me.txtDiscountAmount.BackColor = System.Drawing.Color.White
        Me.txtDiscountAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscountAmount.Location = New System.Drawing.Point(181, 53)
        Me.txtDiscountAmount.Name = "txtDiscountAmount"
        Me.txtDiscountAmount.Size = New System.Drawing.Size(136, 20)
        Me.txtDiscountAmount.TabIndex = 23
        Me.txtDiscountAmount.TabStop = False
        Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(21, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 23)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Invoice Amount"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInvoiceAmount
        '
        Me.txtInvoiceAmount.BackColor = System.Drawing.Color.White
        Me.txtInvoiceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceAmount.Location = New System.Drawing.Point(181, 25)
        Me.txtInvoiceAmount.Name = "txtInvoiceAmount"
        Me.txtInvoiceAmount.Size = New System.Drawing.Size(136, 20)
        Me.txtInvoiceAmount.TabIndex = 23
        Me.txtInvoiceAmount.TabStop = False
        Me.txtInvoiceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'Label19
        '
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(22, 115)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(105, 23)
        Me.Label19.TabIndex = 75
        Me.Label19.Text = "Card Type"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCardType
        '
        Me.txtCardType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCardType.Location = New System.Drawing.Point(131, 118)
        Me.txtCardType.Name = "txtCardType"
        Me.txtCardType.Size = New System.Drawing.Size(187, 20)
        Me.txtCardType.TabIndex = 21
        Me.txtCardType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(22, 25)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(100, 23)
        Me.Label20.TabIndex = 73
        Me.Label20.Text = "Tender Type"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTenderType
        '
        Me.txtTenderType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTenderType.Location = New System.Drawing.Point(128, 25)
        Me.txtTenderType.Name = "txtTenderType"
        Me.txtTenderType.Size = New System.Drawing.Size(190, 20)
        Me.txtTenderType.TabIndex = 14
        Me.txtTenderType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.ForeColor = System.Drawing.Color.Blue
        Me.Label22.Location = New System.Drawing.Point(22, 141)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(105, 23)
        Me.Label22.TabIndex = 69
        Me.Label22.Text = "Credit Comment"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCreditComment
        '
        Me.txtCreditComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreditComment.Location = New System.Drawing.Point(22, 167)
        Me.txtCreditComment.Multiline = True
        Me.txtCreditComment.Name = "txtCreditComment"
        Me.txtCreditComment.Size = New System.Drawing.Size(301, 81)
        Me.txtCreditComment.TabIndex = 22
        Me.txtCreditComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.ForeColor = System.Drawing.Color.Blue
        Me.Label23.Location = New System.Drawing.Point(22, 132)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(100, 23)
        Me.Label23.TabIndex = 67
        Me.Label23.Text = "Check Comment"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCheckComment
        '
        Me.txtCheckComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckComment.ForeColor = System.Drawing.Color.Black
        Me.txtCheckComment.Location = New System.Drawing.Point(22, 158)
        Me.txtCheckComment.Multiline = True
        Me.txtCheckComment.Name = "txtCheckComment"
        Me.txtCheckComment.Size = New System.Drawing.Size(296, 81)
        Me.txtCheckComment.TabIndex = 17
        Me.txtCheckComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.ForeColor = System.Drawing.Color.Blue
        Me.Label24.Location = New System.Drawing.Point(22, 95)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(100, 23)
        Me.Label24.TabIndex = 65
        Me.Label24.Text = "Reference #"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReferenceNumber
        '
        Me.txtReferenceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenceNumber.Location = New System.Drawing.Point(128, 95)
        Me.txtReferenceNumber.Name = "txtReferenceNumber"
        Me.txtReferenceNumber.Size = New System.Drawing.Size(190, 20)
        Me.txtReferenceNumber.TabIndex = 16
        Me.txtReferenceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtTenderType)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.txtCheckComment)
        Me.GroupBox3.Controls.Add(Me.txtCheckNumber)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.txtReferenceNumber)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Location = New System.Drawing.Point(352, 41)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(336, 256)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "AR Check Details"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtCardNumber)
        Me.GroupBox4.Controls.Add(Me.txtCreditComment)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.txtCardType)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.txtCardDate)
        Me.GroupBox4.Controls.Add(Me.txtAuthorizationNumber)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Location = New System.Drawing.Point(352, 316)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(336, 264)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "AR Credit Details"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtInvoiceAmount)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.txtDiscountAmount)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.txtPaymentAmount)
        Me.GroupBox5.Location = New System.Drawing.Point(701, 638)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(329, 119)
        Me.GroupBox5.TabIndex = 23
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Payment Totals"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtDebitDescription)
        Me.GroupBox6.Controls.Add(Me.txtCreditDescription)
        Me.GroupBox6.Controls.Add(Me.txtCreditAccount)
        Me.GroupBox6.Controls.Add(Me.Label29)
        Me.GroupBox6.Controls.Add(Me.Label30)
        Me.GroupBox6.Controls.Add(Me.txtCreditAmount)
        Me.GroupBox6.Controls.Add(Me.txtPostDate)
        Me.GroupBox6.Controls.Add(Me.Label25)
        Me.GroupBox6.Controls.Add(Me.txtDebitAccount)
        Me.GroupBox6.Controls.Add(Me.Label26)
        Me.GroupBox6.Controls.Add(Me.Label27)
        Me.GroupBox6.Controls.Add(Me.txtDebitAmount)
        Me.GroupBox6.Location = New System.Drawing.Point(699, 41)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(330, 304)
        Me.GroupBox6.TabIndex = 24
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "GL Posting"
        '
        'txtDebitDescription
        '
        Me.txtDebitDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDebitDescription.Location = New System.Drawing.Point(15, 115)
        Me.txtDebitDescription.Name = "txtDebitDescription"
        Me.txtDebitDescription.Size = New System.Drawing.Size(293, 20)
        Me.txtDebitDescription.TabIndex = 69
        Me.txtDebitDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCreditDescription
        '
        Me.txtCreditDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreditDescription.Location = New System.Drawing.Point(15, 232)
        Me.txtCreditDescription.Name = "txtCreditDescription"
        Me.txtCreditDescription.Size = New System.Drawing.Size(293, 20)
        Me.txtCreditDescription.TabIndex = 68
        Me.txtCreditDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCreditAccount
        '
        Me.txtCreditAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreditAccount.Location = New System.Drawing.Point(145, 199)
        Me.txtCreditAccount.Name = "txtCreditAccount"
        Me.txtCreditAccount.Size = New System.Drawing.Size(163, 20)
        Me.txtCreditAccount.TabIndex = 27
        Me.txtCreditAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(12, 266)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(127, 23)
        Me.Label29.TabIndex = 67
        Me.Label29.Text = "Credit Amount"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(12, 201)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(127, 23)
        Me.Label30.TabIndex = 65
        Me.Label30.Text = "Credit Account"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCreditAmount
        '
        Me.txtCreditAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreditAmount.Location = New System.Drawing.Point(145, 265)
        Me.txtCreditAmount.Name = "txtCreditAmount"
        Me.txtCreditAmount.Size = New System.Drawing.Size(163, 20)
        Me.txtCreditAmount.TabIndex = 28
        Me.txtCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPostDate
        '
        Me.txtPostDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPostDate.Location = New System.Drawing.Point(145, 28)
        Me.txtPostDate.Name = "txtPostDate"
        Me.txtPostDate.Size = New System.Drawing.Size(163, 20)
        Me.txtPostDate.TabIndex = 24
        Me.txtPostDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(12, 28)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(127, 23)
        Me.Label25.TabIndex = 57
        Me.Label25.Text = "Post Date"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDebitAccount
        '
        Me.txtDebitAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDebitAccount.Location = New System.Drawing.Point(145, 83)
        Me.txtDebitAccount.Name = "txtDebitAccount"
        Me.txtDebitAccount.Size = New System.Drawing.Size(163, 20)
        Me.txtDebitAccount.TabIndex = 25
        Me.txtDebitAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(12, 147)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(127, 23)
        Me.Label26.TabIndex = 61
        Me.Label26.Text = "Debit Amount"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(12, 85)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(127, 23)
        Me.Label27.TabIndex = 59
        Me.Label27.Text = "Debit Account"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDebitAmount
        '
        Me.txtDebitAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDebitAmount.Location = New System.Drawing.Point(145, 147)
        Me.txtDebitAmount.Name = "txtDebitAmount"
        Me.txtDebitAmount.Size = New System.Drawing.Size(163, 20)
        Me.txtDebitAmount.TabIndex = 26
        Me.txtDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.ForeColor = System.Drawing.Color.Blue
        Me.Label28.Location = New System.Drawing.Point(32, 363)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(300, 29)
        Me.Label28.TabIndex = 88
        Me.Label28.Text = "You may change / edit any of the fields in blue. "
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AREditCustomerPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdClearForm)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "AREditCustomerPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation View / Edit Customer Payment Details"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ARCustomerPaymentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdClearForm As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ARCustomerPaymentBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ARCustomerPaymentTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARCustomerPaymentTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cboARTransactionNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtAuthorizationNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtCardDate As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCardNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCheckNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPaymentAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDiscountAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPaymentType As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPaymentDate As System.Windows.Forms.TextBox
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPaymentLine As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPaymentID As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtBatchNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtBankAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCardType As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtTenderType As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtCreditComment As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtCheckComment As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtReferenceNumber As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCreditAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtCreditAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtPostDate As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtDebitAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtDebitAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtDebitDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtCreditDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents ClearAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPaymentRecordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtpSelectDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkCustomerOnly As System.Windows.Forms.CheckBox
End Class
