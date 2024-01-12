<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewInvoicesToEmail
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
        Me.gpxInventorySPL = New System.Windows.Forms.GroupBox
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.InvoiceProcessingBatchHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvInvoiceHeaders = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmailDayColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.EmailTimeColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.InvoiceEmailAddressColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CertEmailAddressColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmailStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmailTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SentDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceEmailLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InvoiceProcessingBatchHeaderTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceProcessingBatchHeaderTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.InvoiceEmailLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceEmailLogTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboTime = New System.Windows.Forms.ComboBox
        Me.cboDay = New System.Windows.Forms.ComboBox
        Me.cmdReopenInvoice = New System.Windows.Forms.Button
        Me.cmdCloseInvoice = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.gpxInventorySPL.SuspendLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceProcessingBatchHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInvoiceHeaders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceEmailLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
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
        'gpxInventorySPL
        '
        Me.gpxInventorySPL.Controls.Add(Me.chkDateRange)
        Me.gpxInventorySPL.Controls.Add(Me.dtpEndDate)
        Me.gpxInventorySPL.Controls.Add(Me.Label3)
        Me.gpxInventorySPL.Controls.Add(Me.dtpBeginDate)
        Me.gpxInventorySPL.Controls.Add(Me.Label13)
        Me.gpxInventorySPL.Controls.Add(Me.Label12)
        Me.gpxInventorySPL.Controls.Add(Me.cboCustomerID)
        Me.gpxInventorySPL.Controls.Add(Me.cboCustomerName)
        Me.gpxInventorySPL.Controls.Add(Me.cboStatus)
        Me.gpxInventorySPL.Controls.Add(Me.cboDivisionID)
        Me.gpxInventorySPL.Controls.Add(Me.Label5)
        Me.gpxInventorySPL.Controls.Add(Me.cmdClear)
        Me.gpxInventorySPL.Controls.Add(Me.Label6)
        Me.gpxInventorySPL.Controls.Add(Me.Label4)
        Me.gpxInventorySPL.Controls.Add(Me.cmdView)
        Me.gpxInventorySPL.Location = New System.Drawing.Point(29, 41)
        Me.gpxInventorySPL.Name = "gpxInventorySPL"
        Me.gpxInventorySPL.Size = New System.Drawing.Size(300, 389)
        Me.gpxInventorySPL.TabIndex = 0
        Me.gpxInventorySPL.TabStop = False
        Me.gpxInventorySPL.Text = "View By Filter"
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(109, 243)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 5
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(109, 307)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(175, 20)
        Me.dtpEndDate.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 307)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "End Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(109, 274)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(175, 20)
        Me.dtpBeginDate.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(16, 274)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 20)
        Me.Label13.TabIndex = 66
        Me.Label13.Text = "Begin Date"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(16, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(270, 36)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.DropDownWidth = 250
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(94, 108)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(191, 21)
        Me.cboCustomerID.TabIndex = 2
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.DropDownWidth = 300
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(16, 142)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(268, 21)
        Me.cboCustomerName.TabIndex = 3
        '
        'cboStatus
        '
        Me.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatus.DropDownWidth = 250
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OPEN (Not Sent)", "CLOSED (Sent)"})
        Me.cboStatus.Location = New System.Drawing.Point(99, 189)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(186, 21)
        Me.cboStatus.TabIndex = 4
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(93, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(191, 21)
        Me.cboDivisionID.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Customer ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(213, 341)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 9
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 190)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 20)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Status"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Division ID"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(139, 341)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 8
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'InvoiceProcessingBatchHeaderBindingSource
        '
        Me.InvoiceProcessingBatchHeaderBindingSource.DataMember = "InvoiceProcessingBatchHeader"
        Me.InvoiceProcessingBatchHeaderBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(906, 771)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 29
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Enabled = False
        Me.cmdPrint.Location = New System.Drawing.Point(983, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 31
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 32
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvInvoiceHeaders
        '
        Me.dgvInvoiceHeaders.AllowUserToAddRows = False
        Me.dgvInvoiceHeaders.AllowUserToDeleteRows = False
        Me.dgvInvoiceHeaders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInvoiceHeaders.AutoGenerateColumns = False
        Me.dgvInvoiceHeaders.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInvoiceHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceHeaders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.CustomerIDColumn, Me.InvoiceNumberColumn, Me.ShipmentNumberColumn, Me.EmailDayColumn, Me.EmailTimeColumn, Me.InvoiceEmailAddressColumn, Me.CertEmailAddressColumn, Me.EmailStatusColumn, Me.UserIDColumn, Me.EmailTypeColumn, Me.SentDateColumn})
        Me.dgvInvoiceHeaders.DataSource = Me.InvoiceEmailLogBindingSource
        Me.dgvInvoiceHeaders.GridColor = System.Drawing.Color.Blue
        Me.dgvInvoiceHeaders.Location = New System.Drawing.Point(346, 43)
        Me.dgvInvoiceHeaders.Name = "dgvInvoiceHeaders"
        Me.dgvInvoiceHeaders.Size = New System.Drawing.Size(784, 711)
        Me.dgvInvoiceHeaders.TabIndex = 33
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DivisionIDColumn.Visible = False
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'InvoiceNumberColumn
        '
        Me.InvoiceNumberColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn.HeaderText = "Invoice #"
        Me.InvoiceNumberColumn.Name = "InvoiceNumberColumn"
        Me.InvoiceNumberColumn.ReadOnly = True
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "Shipment #"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        Me.ShipmentNumberColumn.ReadOnly = True
        '
        'EmailDayColumn
        '
        Me.EmailDayColumn.DataPropertyName = "EmailDay"
        Me.EmailDayColumn.HeaderText = "Email Day"
        Me.EmailDayColumn.Items.AddRange(New Object() {"TODAY", "TONIGHT (AFTER MIDNIGHT)"})
        Me.EmailDayColumn.Name = "EmailDayColumn"
        Me.EmailDayColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EmailDayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'EmailTimeColumn
        '
        Me.EmailTimeColumn.DataPropertyName = "EmailTime"
        Me.EmailTimeColumn.HeaderText = "Email Time"
        Me.EmailTimeColumn.Items.AddRange(New Object() {"12:00AM", "1:00AM", "2:00AM", "3:00AM", "4:00AM", "5:00AM", "6:00AM", "7:00AM", "8:00AM", "9:00AM", "10:00AM", "11:00AM", "12:00PM", "1:00PM", "2:00PM", "3:00PM", "4:00PM", "5:00PM", "6:00PM", "7:00PM", "8:00PM", "9:00PM", "10:00PM", "11:00PM"})
        Me.EmailTimeColumn.Name = "EmailTimeColumn"
        Me.EmailTimeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EmailTimeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'InvoiceEmailAddressColumn
        '
        Me.InvoiceEmailAddressColumn.DataPropertyName = "InvoiceEmailAddress"
        Me.InvoiceEmailAddressColumn.HeaderText = "Invoice Email Address"
        Me.InvoiceEmailAddressColumn.Name = "InvoiceEmailAddressColumn"
        '
        'CertEmailAddressColumn
        '
        Me.CertEmailAddressColumn.DataPropertyName = "CertEmailAddress"
        Me.CertEmailAddressColumn.HeaderText = "Cert Email Address"
        Me.CertEmailAddressColumn.Name = "CertEmailAddressColumn"
        '
        'EmailStatusColumn
        '
        Me.EmailStatusColumn.DataPropertyName = "EmailStatus"
        Me.EmailStatusColumn.HeaderText = "Status"
        Me.EmailStatusColumn.Name = "EmailStatusColumn"
        Me.EmailStatusColumn.ReadOnly = True
        Me.EmailStatusColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'UserIDColumn
        '
        Me.UserIDColumn.DataPropertyName = "UserID"
        Me.UserIDColumn.HeaderText = "User"
        Me.UserIDColumn.Name = "UserIDColumn"
        Me.UserIDColumn.ReadOnly = True
        '
        'EmailTypeColumn
        '
        Me.EmailTypeColumn.DataPropertyName = "EmailType"
        Me.EmailTypeColumn.HeaderText = "Email Type"
        Me.EmailTypeColumn.Name = "EmailTypeColumn"
        Me.EmailTypeColumn.ReadOnly = True
        '
        'SentDateColumn
        '
        Me.SentDateColumn.DataPropertyName = "SentDate"
        Me.SentDateColumn.HeaderText = "Schedule Date"
        Me.SentDateColumn.Name = "SentDateColumn"
        Me.SentDateColumn.ReadOnly = True
        '
        'InvoiceEmailLogBindingSource
        '
        Me.InvoiceEmailLogBindingSource.DataMember = "InvoiceEmailLog"
        Me.InvoiceEmailLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'InvoiceProcessingBatchHeaderTableAdapter
        '
        Me.InvoiceProcessingBatchHeaderTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'InvoiceEmailLogTableAdapter
        '
        Me.InvoiceEmailLogTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cboTime)
        Me.GroupBox1.Controls.Add(Me.cboDay)
        Me.GroupBox1.Controls.Add(Me.cmdReopenInvoice)
        Me.GroupBox1.Controls.Add(Me.cmdCloseInvoice)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 512)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 299)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Re-Open or Close Invoices"
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(15, 135)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(270, 40)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "Re-schedule invoices to be sent. Select new time and date."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTime
        '
        Me.cboTime.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTime.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTime.DropDownWidth = 250
        Me.cboTime.FormattingEnabled = True
        Me.cboTime.Items.AddRange(New Object() {"12:00AM", "1:00AM", "2:00AM", "3:00AM", "4:00AM", "5:00AM", "6:00AM", "7:00AM", "8:00AM", "9:00AM", "10:00AM", "11:00AM", "12:00PM", "1:00PM", "2:00PM", "3:00PM", "4:00PM", "5:00PM", "6:00PM", "7:00PM", "8:00PM", "9:00PM", "10:00PM", "11:00PM"})
        Me.cboTime.Location = New System.Drawing.Point(100, 215)
        Me.cboTime.Name = "cboTime"
        Me.cboTime.Size = New System.Drawing.Size(186, 21)
        Me.cboTime.TabIndex = 13
        '
        'cboDay
        '
        Me.cboDay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDay.DropDownWidth = 250
        Me.cboDay.FormattingEnabled = True
        Me.cboDay.Items.AddRange(New Object() {"TODAY", "TONIGHT (AFTER MIDNIGHT)"})
        Me.cboDay.Location = New System.Drawing.Point(99, 178)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Size = New System.Drawing.Size(186, 21)
        Me.cboDay.TabIndex = 12
        '
        'cmdReopenInvoice
        '
        Me.cmdReopenInvoice.Location = New System.Drawing.Point(214, 256)
        Me.cmdReopenInvoice.Name = "cmdReopenInvoice"
        Me.cmdReopenInvoice.Size = New System.Drawing.Size(71, 30)
        Me.cmdReopenInvoice.TabIndex = 14
        Me.cmdReopenInvoice.Text = "Open"
        Me.cmdReopenInvoice.UseVisualStyleBackColor = True
        '
        'cmdCloseInvoice
        '
        Me.cmdCloseInvoice.Location = New System.Drawing.Point(213, 90)
        Me.cmdCloseInvoice.Name = "cmdCloseInvoice"
        Me.cmdCloseInvoice.Size = New System.Drawing.Size(71, 30)
        Me.cmdCloseInvoice.TabIndex = 11
        Me.cmdCloseInvoice.Text = "Close"
        Me.cmdCloseInvoice.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(16, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(270, 48)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "If you want to manually re-open or close an invoice from the datagrid, select eac" & _
            "h invoice from the datagrid, and press the appropriate button. "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 216)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 20)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Time"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 179)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 20)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Day"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewInvoicesToEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvInvoiceHeaders)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxInventorySPL)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewInvoicesToEmail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Invoice Email Scheduler"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxInventorySPL.ResumeLayout(False)
        Me.gpxInventorySPL.PerformLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceProcessingBatchHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInvoiceHeaders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceEmailLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxInventorySPL As System.Windows.Forms.GroupBox
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvInvoiceHeaders As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents InvoiceProcessingBatchHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceProcessingBatchHeaderTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceProcessingBatchHeaderTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents InvoiceEmailLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceEmailLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceEmailLogTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboTime As System.Windows.Forms.ComboBox
    Friend WithEvents cboDay As System.Windows.Forms.ComboBox
    Friend WithEvents cmdReopenInvoice As System.Windows.Forms.Button
    Friend WithEvents cmdCloseInvoice As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmailDayColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents EmailTimeColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents InvoiceEmailAddressColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CertEmailAddressColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmailStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmailTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SentDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
