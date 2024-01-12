<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewGLChartOfAccounts
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
        Me.gpxGLChartOfAccounts = New System.Windows.Forms.GroupBox
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.cboGLAccountType = New System.Windows.Forms.ComboBox
        Me.GLAccountTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboGLDescription = New System.Windows.Forms.ComboBox
        Me.GLAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboGLAccount = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintChartOfAccountsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvChartOfAccounts = New System.Windows.Forms.DataGridView
        Me.GLAccountNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountShortDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountTypeIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountCashFlowCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.GLAccountTypesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountTypesTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdClear2 = New System.Windows.Forms.Button
        Me.cmdAddNew = New System.Windows.Forms.Button
        Me.txtCashFlow = New System.Windows.Forms.TextBox
        Me.txtTypeID = New System.Windows.Forms.TextBox
        Me.txtAccountType = New System.Windows.Forms.TextBox
        Me.txtLongDescription = New System.Windows.Forms.TextBox
        Me.txtShortDescription = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtAccountNumber = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.gpxGLChartOfAccounts.SuspendLayout()
        CType(Me.GLAccountTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvChartOfAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpxGLChartOfAccounts
        '
        Me.gpxGLChartOfAccounts.Controls.Add(Me.txtTextFilter)
        Me.gpxGLChartOfAccounts.Controls.Add(Me.Label4)
        Me.gpxGLChartOfAccounts.Controls.Add(Me.cmdViewByFilters)
        Me.gpxGLChartOfAccounts.Controls.Add(Me.cboGLAccountType)
        Me.gpxGLChartOfAccounts.Controls.Add(Me.Label3)
        Me.gpxGLChartOfAccounts.Controls.Add(Me.cboGLDescription)
        Me.gpxGLChartOfAccounts.Controls.Add(Me.cmdClear)
        Me.gpxGLChartOfAccounts.Controls.Add(Me.cboDivisionID)
        Me.gpxGLChartOfAccounts.Controls.Add(Me.Label1)
        Me.gpxGLChartOfAccounts.Controls.Add(Me.cboGLAccount)
        Me.gpxGLChartOfAccounts.Controls.Add(Me.Label2)
        Me.gpxGLChartOfAccounts.Location = New System.Drawing.Point(29, 41)
        Me.gpxGLChartOfAccounts.Name = "gpxGLChartOfAccounts"
        Me.gpxGLChartOfAccounts.Size = New System.Drawing.Size(300, 365)
        Me.gpxGLChartOfAccounts.TabIndex = 0
        Me.gpxGLChartOfAccounts.TabStop = False
        Me.gpxGLChartOfAccounts.Text = "GL Chart Of Accounts"
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextFilter.Location = New System.Drawing.Point(118, 228)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(163, 20)
        Me.txtTextFilter.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(15, 228)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Text Filter"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(137, 320)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 3
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'cboGLAccountType
        '
        Me.cboGLAccountType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGLAccountType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLAccountType.DataSource = Me.GLAccountTypesBindingSource
        Me.cboGLAccountType.DisplayMember = "GLAccountType"
        Me.cboGLAccountType.FormattingEnabled = True
        Me.cboGLAccountType.Location = New System.Drawing.Point(118, 157)
        Me.cboGLAccountType.Name = "cboGLAccountType"
        Me.cboGLAccountType.Size = New System.Drawing.Size(163, 21)
        Me.cboGLAccountType.TabIndex = 5
        '
        'GLAccountTypesBindingSource
        '
        Me.GLAccountTypesBindingSource.DataMember = "GLAccountTypes"
        Me.GLAccountTypesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(15, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Account Type"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboGLDescription
        '
        Me.cboGLDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGLDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLDescription.DataSource = Me.GLAccountsBindingSource
        Me.cboGLDescription.DisplayMember = "GLAccountShortDescription"
        Me.cboGLDescription.FormattingEnabled = True
        Me.cboGLDescription.Location = New System.Drawing.Point(14, 106)
        Me.cboGLDescription.Name = "cboGLDescription"
        Me.cboGLDescription.Size = New System.Drawing.Size(267, 21)
        Me.cboGLDescription.TabIndex = 2
        '
        'GLAccountsBindingSource
        '
        Me.GLAccountsBindingSource.DataMember = "GLAccounts"
        Me.GLAccountsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 320)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 4
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(118, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(163, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboGLAccount
        '
        Me.cboGLAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGLAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLAccount.DataSource = Me.GLAccountsBindingSource
        Me.cboGLAccount.DisplayMember = "GLAccountNumber"
        Me.cboGLAccount.FormattingEnabled = True
        Me.cboGLAccount.Location = New System.Drawing.Point(78, 75)
        Me.cboGLAccount.Name = "cboGLAccount"
        Me.cboGLAccount.Size = New System.Drawing.Size(203, 21)
        Me.cboGLAccount.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(15, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Account #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 4
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintChartOfAccountsToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintChartOfAccountsToolStripMenuItem
        '
        Me.PrintChartOfAccountsToolStripMenuItem.Name = "PrintChartOfAccountsToolStripMenuItem"
        Me.PrintChartOfAccountsToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.PrintChartOfAccountsToolStripMenuItem.Text = "Print Chart of Accounts"
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
        'dgvChartOfAccounts
        '
        Me.dgvChartOfAccounts.AllowUserToAddRows = False
        Me.dgvChartOfAccounts.AllowUserToDeleteRows = False
        Me.dgvChartOfAccounts.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvChartOfAccounts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvChartOfAccounts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvChartOfAccounts.AutoGenerateColumns = False
        Me.dgvChartOfAccounts.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvChartOfAccounts.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvChartOfAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvChartOfAccounts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GLAccountNumberColumn, Me.GLAccountShortDescriptionColumn, Me.GLAccountDescriptionColumn, Me.GLAccountTypeColumn, Me.GLAccountTypeIDColumn, Me.GLAccountCashFlowCodeColumn})
        Me.dgvChartOfAccounts.DataSource = Me.GLAccountsBindingSource
        Me.dgvChartOfAccounts.GridColor = System.Drawing.Color.Navy
        Me.dgvChartOfAccounts.Location = New System.Drawing.Point(346, 41)
        Me.dgvChartOfAccounts.Name = "dgvChartOfAccounts"
        Me.dgvChartOfAccounts.Size = New System.Drawing.Size(784, 723)
        Me.dgvChartOfAccounts.TabIndex = 5
        '
        'GLAccountNumberColumn
        '
        Me.GLAccountNumberColumn.DataPropertyName = "GLAccountNumber"
        Me.GLAccountNumberColumn.HeaderText = "Account #"
        Me.GLAccountNumberColumn.Name = "GLAccountNumberColumn"
        Me.GLAccountNumberColumn.ReadOnly = True
        Me.GLAccountNumberColumn.Width = 104
        '
        'GLAccountShortDescriptionColumn
        '
        Me.GLAccountShortDescriptionColumn.DataPropertyName = "GLAccountShortDescription"
        Me.GLAccountShortDescriptionColumn.HeaderText = "Short Description"
        Me.GLAccountShortDescriptionColumn.Name = "GLAccountShortDescriptionColumn"
        Me.GLAccountShortDescriptionColumn.Width = 105
        '
        'GLAccountDescriptionColumn
        '
        Me.GLAccountDescriptionColumn.DataPropertyName = "GLAccountDescription"
        Me.GLAccountDescriptionColumn.HeaderText = "Long Description"
        Me.GLAccountDescriptionColumn.Name = "GLAccountDescriptionColumn"
        Me.GLAccountDescriptionColumn.Width = 104
        '
        'GLAccountTypeColumn
        '
        Me.GLAccountTypeColumn.DataPropertyName = "GLAccountType"
        Me.GLAccountTypeColumn.HeaderText = "Account Type"
        Me.GLAccountTypeColumn.Name = "GLAccountTypeColumn"
        Me.GLAccountTypeColumn.Width = 105
        '
        'GLAccountTypeIDColumn
        '
        Me.GLAccountTypeIDColumn.DataPropertyName = "GLAccountTypeID"
        Me.GLAccountTypeIDColumn.HeaderText = "Type ID"
        Me.GLAccountTypeIDColumn.Name = "GLAccountTypeIDColumn"
        Me.GLAccountTypeIDColumn.Width = 105
        '
        'GLAccountCashFlowCodeColumn
        '
        Me.GLAccountCashFlowCodeColumn.DataPropertyName = "GLAccountCashFlowCode"
        Me.GLAccountCashFlowCodeColumn.HeaderText = "Cash Flow Code"
        Me.GLAccountCashFlowCodeColumn.Name = "GLAccountCashFlowCodeColumn"
        Me.GLAccountCashFlowCodeColumn.Width = 106
        '
        'GLAccountsTableAdapter
        '
        Me.GLAccountsTableAdapter.ClearBeforeFill = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 776)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 6
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'GLAccountTypesTableAdapter
        '
        Me.GLAccountTypesTableAdapter.ClearBeforeFill = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 776)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 5
        Me.cmdPrint.Text = "Print CoA"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cmdClear2)
        Me.GroupBox2.Controls.Add(Me.cmdAddNew)
        Me.GroupBox2.Controls.Add(Me.txtCashFlow)
        Me.GroupBox2.Controls.Add(Me.txtTypeID)
        Me.GroupBox2.Controls.Add(Me.txtAccountType)
        Me.GroupBox2.Controls.Add(Me.txtLongDescription)
        Me.GroupBox2.Controls.Add(Me.txtShortDescription)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtAccountNumber)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 522)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(304, 294)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Add New GL Account"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(22, 55)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Description"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(19, 224)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Cash Flow Code"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(19, 198)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Account Type ID"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(19, 172)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Account Type"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear2
        '
        Me.cmdClear2.Location = New System.Drawing.Point(218, 255)
        Me.cmdClear2.Name = "cmdClear2"
        Me.cmdClear2.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear2.TabIndex = 15
        Me.cmdClear2.Text = "Clear"
        Me.cmdClear2.UseVisualStyleBackColor = True
        '
        'cmdAddNew
        '
        Me.cmdAddNew.Location = New System.Drawing.Point(141, 255)
        Me.cmdAddNew.Name = "cmdAddNew"
        Me.cmdAddNew.Size = New System.Drawing.Size(71, 30)
        Me.cmdAddNew.TabIndex = 14
        Me.cmdAddNew.Text = "Add"
        Me.cmdAddNew.UseVisualStyleBackColor = True
        '
        'txtCashFlow
        '
        Me.txtCashFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCashFlow.Location = New System.Drawing.Point(125, 224)
        Me.txtCashFlow.Name = "txtCashFlow"
        Me.txtCashFlow.Size = New System.Drawing.Size(164, 20)
        Me.txtCashFlow.TabIndex = 13
        Me.txtCashFlow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTypeID
        '
        Me.txtTypeID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTypeID.Location = New System.Drawing.Point(125, 198)
        Me.txtTypeID.Name = "txtTypeID"
        Me.txtTypeID.Size = New System.Drawing.Size(164, 20)
        Me.txtTypeID.TabIndex = 12
        Me.txtTypeID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAccountType
        '
        Me.txtAccountType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccountType.Location = New System.Drawing.Point(125, 172)
        Me.txtAccountType.Name = "txtAccountType"
        Me.txtAccountType.Size = New System.Drawing.Size(164, 20)
        Me.txtAccountType.TabIndex = 11
        Me.txtAccountType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLongDescription
        '
        Me.txtLongDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLongDescription.Location = New System.Drawing.Point(23, 120)
        Me.txtLongDescription.Multiline = True
        Me.txtLongDescription.Name = "txtLongDescription"
        Me.txtLongDescription.Size = New System.Drawing.Size(266, 42)
        Me.txtLongDescription.TabIndex = 10
        Me.txtLongDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtShortDescription
        '
        Me.txtShortDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShortDescription.Location = New System.Drawing.Point(23, 78)
        Me.txtShortDescription.Multiline = True
        Me.txtShortDescription.Name = "txtShortDescription"
        Me.txtShortDescription.Size = New System.Drawing.Size(266, 36)
        Me.txtShortDescription.TabIndex = 9
        Me.txtShortDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(20, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Account Number"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAccountNumber
        '
        Me.txtAccountNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccountNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAccountNumber.Location = New System.Drawing.Point(125, 30)
        Me.txtAccountNumber.Name = "txtAccountNumber"
        Me.txtAccountNumber.Size = New System.Drawing.Size(164, 20)
        Me.txtAccountNumber.TabIndex = 8
        Me.txtAccountNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(26, 422)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(303, 77)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Changes to GL Accounts may be made in the datagrid and changes are automatically " & _
            "saved."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewGLChartOfAccounts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvChartOfAccounts)
        Me.Controls.Add(Me.gpxGLChartOfAccounts)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewGLChartOfAccounts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation General Ledger Chart of Accounts"
        Me.gpxGLChartOfAccounts.ResumeLayout(False)
        Me.gpxGLChartOfAccounts.PerformLayout()
        CType(Me.GLAccountTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvChartOfAccounts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpxGLChartOfAccounts As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboGLAccountType As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboGLAccount As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvChartOfAccounts As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents GLAccountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents GLAccountTypesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountTypesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountTypesTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cboGLDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClear2 As System.Windows.Forms.Button
    Friend WithEvents cmdAddNew As System.Windows.Forms.Button
    Friend WithEvents txtCashFlow As System.Windows.Forms.TextBox
    Friend WithEvents txtTypeID As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountType As System.Windows.Forms.TextBox
    Friend WithEvents txtLongDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtShortDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAccountNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PrintChartOfAccountsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GLAccountNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountShortDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountTypeIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountCashFlowCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
