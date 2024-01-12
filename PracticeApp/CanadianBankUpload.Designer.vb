<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CanadianBankUpload
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxFilterDatagrid = New System.Windows.Forms.GroupBox
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtVendorClass = New System.Windows.Forms.TextBox
        Me.cmdClearFilter = New System.Windows.Forms.Button
        Me.cmdViewByFilter = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.dgvAPChecks = New System.Windows.Forms.DataGridView
        Me.SelectedColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.APBatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UploadStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCheckColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccountNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorAccountNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorRoutingNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorAccountTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RemittanceEmailColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WhitePaperCheckColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APCheckUploadBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.gpxTotals = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtSelectedTotal = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtDatagridTotal = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtUnSelectedTotal = New System.Windows.Forms.TextBox
        Me.gpxCreateFile = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtpUploadDate = New System.Windows.Forms.DateTimePicker
        Me.cmdCreateFile = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.APCheckUploadTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APCheckUploadTableAdapter
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.gpxReset = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtCheckNumber = New System.Windows.Forms.TextBox
        Me.cmdReset = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.gpxFilterDatagrid.SuspendLayout()
        CType(Me.dgvAPChecks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APCheckUploadBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxTotals.SuspendLayout()
        Me.gpxCreateFile.SuspendLayout()
        Me.gpxReset.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 13
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 84
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
        'gpxFilterDatagrid
        '
        Me.gpxFilterDatagrid.Controls.Add(Me.chkDateRange)
        Me.gpxFilterDatagrid.Controls.Add(Me.Label4)
        Me.gpxFilterDatagrid.Controls.Add(Me.txtVendorClass)
        Me.gpxFilterDatagrid.Controls.Add(Me.cmdClearFilter)
        Me.gpxFilterDatagrid.Controls.Add(Me.cmdViewByFilter)
        Me.gpxFilterDatagrid.Controls.Add(Me.Label3)
        Me.gpxFilterDatagrid.Controls.Add(Me.Label2)
        Me.gpxFilterDatagrid.Controls.Add(Me.Label1)
        Me.gpxFilterDatagrid.Controls.Add(Me.dtpEndDate)
        Me.gpxFilterDatagrid.Controls.Add(Me.dtpBeginDate)
        Me.gpxFilterDatagrid.Controls.Add(Me.cboDivisionID)
        Me.gpxFilterDatagrid.Location = New System.Drawing.Point(29, 41)
        Me.gpxFilterDatagrid.Name = "gpxFilterDatagrid"
        Me.gpxFilterDatagrid.Size = New System.Drawing.Size(300, 278)
        Me.gpxFilterDatagrid.TabIndex = 0
        Me.gpxFilterDatagrid.TabStop = False
        Me.gpxFilterDatagrid.Text = "Show Data By Filter"
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Blue
        Me.chkDateRange.Location = New System.Drawing.Point(121, 79)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(160, 17)
        Me.chkDateRange.TabIndex = 1
        Me.chkDateRange.Text = "Check to include date range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(20, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 23)
        Me.Label4.TabIndex = 87
        Me.Label4.Text = "Vendor Class"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVendorClass
        '
        Me.txtVendorClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorClass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorClass.Enabled = False
        Me.txtVendorClass.Location = New System.Drawing.Point(121, 197)
        Me.txtVendorClass.Name = "txtVendorClass"
        Me.txtVendorClass.Size = New System.Drawing.Size(159, 20)
        Me.txtVendorClass.TabIndex = 4
        Me.txtVendorClass.TabStop = False
        '
        'cmdClearFilter
        '
        Me.cmdClearFilter.Location = New System.Drawing.Point(210, 237)
        Me.cmdClearFilter.Name = "cmdClearFilter"
        Me.cmdClearFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearFilter.TabIndex = 6
        Me.cmdClearFilter.Text = "Clear"
        Me.cmdClearFilter.UseVisualStyleBackColor = True
        '
        'cmdViewByFilter
        '
        Me.cmdViewByFilter.Location = New System.Drawing.Point(133, 237)
        Me.cmdViewByFilter.Name = "cmdViewByFilter"
        Me.cmdViewByFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilter.TabIndex = 5
        Me.cmdViewByFilter.Text = "View"
        Me.cmdViewByFilter.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Division"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 23)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "End Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Begin Date"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(121, 147)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(159, 20)
        Me.dtpEndDate.TabIndex = 3
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(121, 112)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(159, 20)
        Me.dtpBeginDate.TabIndex = 2
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Items.AddRange(New Object() {"TFF", "TOR", "ALB", "ALL"})
        Me.cboDivisionID.Location = New System.Drawing.Point(121, 31)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(159, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'dgvAPChecks
        '
        Me.dgvAPChecks.AllowUserToAddRows = False
        Me.dgvAPChecks.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvAPChecks.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAPChecks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAPChecks.AutoGenerateColumns = False
        Me.dgvAPChecks.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAPChecks.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAPChecks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAPChecks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectedColumn, Me.APBatchNumberColumn, Me.VendorIDColumn, Me.CheckNumberColumn, Me.CheckAmountColumn, Me.CheckDateColumn, Me.CheckTypeColumn, Me.UploadStatusColumn, Me.DivisionIDColumn, Me.VendorClassColumn, Me.CheckStatusColumn, Me.ExtendedCheckColumn, Me.AccountNumberColumn, Me.VendorNameColumn, Me.VendorAccountNumberColumn, Me.VendorRoutingNumberColumn, Me.VendorAccountTypeColumn, Me.RemittanceEmailColumn, Me.CheckCodeColumn, Me.WhitePaperCheckColumn})
        Me.dgvAPChecks.DataSource = Me.APCheckUploadBindingSource
        Me.dgvAPChecks.Location = New System.Drawing.Point(344, 41)
        Me.dgvAPChecks.Name = "dgvAPChecks"
        Me.dgvAPChecks.Size = New System.Drawing.Size(786, 711)
        Me.dgvAPChecks.TabIndex = 15
        '
        'SelectedColumn
        '
        Me.SelectedColumn.FalseValue = "UNSELECTED"
        Me.SelectedColumn.HeaderText = "Select"
        Me.SelectedColumn.IndeterminateValue = "UNSELECTED"
        Me.SelectedColumn.Name = "SelectedColumn"
        Me.SelectedColumn.TrueValue = "SELECTED"
        Me.SelectedColumn.Width = 80
        '
        'APBatchNumberColumn
        '
        Me.APBatchNumberColumn.DataPropertyName = "APBatchNumber"
        Me.APBatchNumberColumn.HeaderText = "Batch #"
        Me.APBatchNumberColumn.Name = "APBatchNumberColumn"
        '
        'VendorIDColumn
        '
        Me.VendorIDColumn.DataPropertyName = "VendorID"
        Me.VendorIDColumn.HeaderText = "Vendor"
        Me.VendorIDColumn.Name = "VendorIDColumn"
        '
        'CheckNumberColumn
        '
        Me.CheckNumberColumn.DataPropertyName = "CheckNumber"
        Me.CheckNumberColumn.HeaderText = "Check #"
        Me.CheckNumberColumn.Name = "CheckNumberColumn"
        '
        'CheckAmountColumn
        '
        Me.CheckAmountColumn.DataPropertyName = "CheckAmount"
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.CheckAmountColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.CheckAmountColumn.HeaderText = "Check Amount"
        Me.CheckAmountColumn.Name = "CheckAmountColumn"
        '
        'CheckDateColumn
        '
        Me.CheckDateColumn.DataPropertyName = "CheckDate"
        Me.CheckDateColumn.HeaderText = "Check Date"
        Me.CheckDateColumn.Name = "CheckDateColumn"
        '
        'CheckTypeColumn
        '
        Me.CheckTypeColumn.DataPropertyName = "CheckType"
        Me.CheckTypeColumn.HeaderText = "Check Type"
        Me.CheckTypeColumn.Name = "CheckTypeColumn"
        '
        'UploadStatusColumn
        '
        Me.UploadStatusColumn.DataPropertyName = "UploadStatus"
        Me.UploadStatusColumn.HeaderText = "Upload Status"
        Me.UploadStatusColumn.Name = "UploadStatusColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        '
        'VendorClassColumn
        '
        Me.VendorClassColumn.DataPropertyName = "VendorClass"
        Me.VendorClassColumn.HeaderText = "VendorClass"
        Me.VendorClassColumn.Name = "VendorClassColumn"
        Me.VendorClassColumn.Visible = False
        '
        'CheckStatusColumn
        '
        Me.CheckStatusColumn.DataPropertyName = "CheckStatus"
        Me.CheckStatusColumn.HeaderText = "CheckStatus"
        Me.CheckStatusColumn.Name = "CheckStatusColumn"
        Me.CheckStatusColumn.Visible = False
        '
        'ExtendedCheckColumn
        '
        Me.ExtendedCheckColumn.DataPropertyName = "ExtendedCheck"
        Me.ExtendedCheckColumn.HeaderText = "ExtendedCheck"
        Me.ExtendedCheckColumn.Name = "ExtendedCheckColumn"
        Me.ExtendedCheckColumn.Visible = False
        '
        'AccountNumberColumn
        '
        Me.AccountNumberColumn.DataPropertyName = "AccountNumber"
        Me.AccountNumberColumn.HeaderText = "AccountNumber"
        Me.AccountNumberColumn.Name = "AccountNumberColumn"
        Me.AccountNumberColumn.Visible = False
        '
        'VendorNameColumn
        '
        Me.VendorNameColumn.DataPropertyName = "VendorName"
        Me.VendorNameColumn.HeaderText = "VendorName"
        Me.VendorNameColumn.Name = "VendorNameColumn"
        Me.VendorNameColumn.Visible = False
        '
        'VendorAccountNumberColumn
        '
        Me.VendorAccountNumberColumn.DataPropertyName = "VendorAccountNumber"
        Me.VendorAccountNumberColumn.HeaderText = "VendorAccountNumber"
        Me.VendorAccountNumberColumn.Name = "VendorAccountNumberColumn"
        Me.VendorAccountNumberColumn.Visible = False
        '
        'VendorRoutingNumberColumn
        '
        Me.VendorRoutingNumberColumn.DataPropertyName = "VendorRoutingNumber"
        Me.VendorRoutingNumberColumn.HeaderText = "VendorRoutingNumber"
        Me.VendorRoutingNumberColumn.Name = "VendorRoutingNumberColumn"
        Me.VendorRoutingNumberColumn.Visible = False
        '
        'VendorAccountTypeColumn
        '
        Me.VendorAccountTypeColumn.DataPropertyName = "VendorAccountType"
        Me.VendorAccountTypeColumn.HeaderText = "VendorAccountType"
        Me.VendorAccountTypeColumn.Name = "VendorAccountTypeColumn"
        Me.VendorAccountTypeColumn.Visible = False
        '
        'RemittanceEmailColumn
        '
        Me.RemittanceEmailColumn.DataPropertyName = "RemittanceEmail"
        Me.RemittanceEmailColumn.HeaderText = "RemittanceEmail"
        Me.RemittanceEmailColumn.Name = "RemittanceEmailColumn"
        Me.RemittanceEmailColumn.Visible = False
        '
        'CheckCodeColumn
        '
        Me.CheckCodeColumn.DataPropertyName = "CheckCode"
        Me.CheckCodeColumn.HeaderText = "CheckCode"
        Me.CheckCodeColumn.Name = "CheckCodeColumn"
        Me.CheckCodeColumn.Visible = False
        '
        'WhitePaperCheckColumn
        '
        Me.WhitePaperCheckColumn.DataPropertyName = "WhitePaperCheck"
        Me.WhitePaperCheckColumn.HeaderText = "WhitePaperCheck"
        Me.WhitePaperCheckColumn.Name = "WhitePaperCheckColumn"
        Me.WhitePaperCheckColumn.Visible = False
        '
        'APCheckUploadBindingSource
        '
        Me.APCheckUploadBindingSource.DataMember = "APCheckUpload"
        Me.APCheckUploadBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'gpxTotals
        '
        Me.gpxTotals.Controls.Add(Me.Label8)
        Me.gpxTotals.Controls.Add(Me.txtSelectedTotal)
        Me.gpxTotals.Controls.Add(Me.Label7)
        Me.gpxTotals.Controls.Add(Me.txtDatagridTotal)
        Me.gpxTotals.Controls.Add(Me.Label6)
        Me.gpxTotals.Controls.Add(Me.txtUnSelectedTotal)
        Me.gpxTotals.Location = New System.Drawing.Point(29, 664)
        Me.gpxTotals.Name = "gpxTotals"
        Me.gpxTotals.Size = New System.Drawing.Size(300, 145)
        Me.gpxTotals.TabIndex = 9
        Me.gpxTotals.TabStop = False
        Me.gpxTotals.Text = "Datagrid Totals"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(6, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 23)
        Me.Label8.TabIndex = 93
        Me.Label8.Text = "Total Selected"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSelectedTotal
        '
        Me.txtSelectedTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSelectedTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSelectedTotal.Enabled = False
        Me.txtSelectedTotal.Location = New System.Drawing.Point(122, 29)
        Me.txtSelectedTotal.Name = "txtSelectedTotal"
        Me.txtSelectedTotal.Size = New System.Drawing.Size(159, 20)
        Me.txtSelectedTotal.TabIndex = 10
        Me.txtSelectedTotal.TabStop = False
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(6, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 23)
        Me.Label7.TabIndex = 91
        Me.Label7.Text = "Total In Datagrid"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDatagridTotal
        '
        Me.txtDatagridTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDatagridTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDatagridTotal.Enabled = False
        Me.txtDatagridTotal.Location = New System.Drawing.Point(122, 103)
        Me.txtDatagridTotal.Name = "txtDatagridTotal"
        Me.txtDatagridTotal.Size = New System.Drawing.Size(159, 20)
        Me.txtDatagridTotal.TabIndex = 12
        Me.txtDatagridTotal.TabStop = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(6, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 23)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "Total Unselected"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnSelectedTotal
        '
        Me.txtUnSelectedTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnSelectedTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnSelectedTotal.Enabled = False
        Me.txtUnSelectedTotal.Location = New System.Drawing.Point(122, 66)
        Me.txtUnSelectedTotal.Name = "txtUnSelectedTotal"
        Me.txtUnSelectedTotal.Size = New System.Drawing.Size(159, 20)
        Me.txtUnSelectedTotal.TabIndex = 11
        Me.txtUnSelectedTotal.TabStop = False
        '
        'gpxCreateFile
        '
        Me.gpxCreateFile.Controls.Add(Me.Label9)
        Me.gpxCreateFile.Controls.Add(Me.dtpUploadDate)
        Me.gpxCreateFile.Controls.Add(Me.cmdCreateFile)
        Me.gpxCreateFile.Location = New System.Drawing.Point(29, 401)
        Me.gpxCreateFile.Name = "gpxCreateFile"
        Me.gpxCreateFile.Size = New System.Drawing.Size(300, 147)
        Me.gpxCreateFile.TabIndex = 7
        Me.gpxCreateFile.TabStop = False
        Me.gpxCreateFile.Text = "Create Upload File"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(19, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 23)
        Me.Label9.TabIndex = 88
        Me.Label9.Text = "Upload Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpUploadDate
        '
        Me.dtpUploadDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpUploadDate.Location = New System.Drawing.Point(121, 31)
        Me.dtpUploadDate.Name = "dtpUploadDate"
        Me.dtpUploadDate.Size = New System.Drawing.Size(159, 20)
        Me.dtpUploadDate.TabIndex = 9
        '
        'cmdCreateFile
        '
        Me.cmdCreateFile.Location = New System.Drawing.Point(210, 91)
        Me.cmdCreateFile.Name = "cmdCreateFile"
        Me.cmdCreateFile.Size = New System.Drawing.Size(71, 40)
        Me.cmdCreateFile.TabIndex = 8
        Me.cmdCreateFile.Text = "Create File"
        Me.cmdCreateFile.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(49, 328)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(261, 64)
        Me.Label5.TabIndex = 91
        Me.Label5.Text = "Select lines in datagrid to create the upload file for Canadian Banking. "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'APCheckUploadTableAdapter
        '
        Me.APCheckUploadTableAdapter.ClearBeforeFill = True
        '
        'gpxReset
        '
        Me.gpxReset.Controls.Add(Me.Label10)
        Me.gpxReset.Controls.Add(Me.txtCheckNumber)
        Me.gpxReset.Controls.Add(Me.cmdReset)
        Me.gpxReset.Location = New System.Drawing.Point(29, 557)
        Me.gpxReset.Name = "gpxReset"
        Me.gpxReset.Size = New System.Drawing.Size(299, 98)
        Me.gpxReset.TabIndex = 92
        Me.gpxReset.TabStop = False
        Me.gpxReset.Text = "Reset Check for Upload"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(23, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(159, 27)
        Me.Label10.TabIndex = 89
        Me.Label10.Text = "Check #"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCheckNumber
        '
        Me.txtCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCheckNumber.Location = New System.Drawing.Point(23, 54)
        Me.txtCheckNumber.Name = "txtCheckNumber"
        Me.txtCheckNumber.Size = New System.Drawing.Size(169, 20)
        Me.txtCheckNumber.TabIndex = 11
        Me.txtCheckNumber.TabStop = False
        '
        'cmdReset
        '
        Me.cmdReset.Location = New System.Drawing.Point(209, 34)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(71, 40)
        Me.cmdReset.TabIndex = 9
        Me.cmdReset.Text = "Reset Upload"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'CanadianBankUpload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.gpxReset)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.gpxCreateFile)
        Me.Controls.Add(Me.gpxTotals)
        Me.Controls.Add(Me.dgvAPChecks)
        Me.Controls.Add(Me.gpxFilterDatagrid)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "CanadianBankUpload"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Coporation Canadian Banking Uploader"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxFilterDatagrid.ResumeLayout(False)
        Me.gpxFilterDatagrid.PerformLayout()
        CType(Me.dgvAPChecks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APCheckUploadBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxTotals.ResumeLayout(False)
        Me.gpxTotals.PerformLayout()
        Me.gpxCreateFile.ResumeLayout(False)
        Me.gpxReset.ResumeLayout(False)
        Me.gpxReset.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxFilterDatagrid As System.Windows.Forms.GroupBox
    Friend WithEvents dgvAPChecks As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClearFilter As System.Windows.Forms.Button
    Friend WithEvents cmdViewByFilter As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtVendorClass As System.Windows.Forms.TextBox
    Friend WithEvents gpxTotals As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSelectedTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDatagridTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtUnSelectedTotal As System.Windows.Forms.TextBox
    Friend WithEvents gpxCreateFile As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCreateFile As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents APCheckUploadBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents APCheckUploadTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APCheckUploadTableAdapter
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpUploadDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents SelectedColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents APBatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UploadStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCheckColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorAccountNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorRoutingNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorAccountTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemittanceEmailColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WhitePaperCheckColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents gpxReset As System.Windows.Forms.GroupBox
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCheckNumber As System.Windows.Forms.TextBox
End Class
