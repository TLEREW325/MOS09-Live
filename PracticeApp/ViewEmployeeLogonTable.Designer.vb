<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewEmployeeLogonTable
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
        Me.gpxFilterByDate = New System.Windows.Forms.GroupBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdClear2 = New System.Windows.Forms.Button
        Me.cmdViewByDateRange = New System.Windows.Forms.Button
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.gpxDivisionID = New System.Windows.Forms.GroupBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cmdViewByDivision = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.gpxViewByEmployee = New System.Windows.Forms.GroupBox
        Me.cboFName = New System.Windows.Forms.ComboBox
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboLName = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboLoginName = New System.Windows.Forms.ComboBox
        Me.cmdViewByEmployees = New System.Windows.Forms.Button
        Me.cmdClear1 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.UserLoginTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvUserLoginTable = New System.Windows.Forms.DataGridView
        Me.LoginNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LoginDateTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogoutDateTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CompanyCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SessionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserLoginTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.UserLoginTableTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.cmdExit = New System.Windows.Forms.Button
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdClearLogonList = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.gpxFilterByDate.SuspendLayout()
        Me.gpxDivisionID.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxViewByEmployee.SuspendLayout()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UserLoginTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvUserLoginTable, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'gpxFilterByDate
        '
        Me.gpxFilterByDate.Controls.Add(Me.dtpEndDate)
        Me.gpxFilterByDate.Controls.Add(Me.Label9)
        Me.gpxFilterByDate.Controls.Add(Me.cmdClear2)
        Me.gpxFilterByDate.Controls.Add(Me.cmdViewByDateRange)
        Me.gpxFilterByDate.Controls.Add(Me.dtpBeginDate)
        Me.gpxFilterByDate.Controls.Add(Me.Label3)
        Me.gpxFilterByDate.Location = New System.Drawing.Point(29, 358)
        Me.gpxFilterByDate.Name = "gpxFilterByDate"
        Me.gpxFilterByDate.Size = New System.Drawing.Size(300, 138)
        Me.gpxFilterByDate.TabIndex = 8
        Me.gpxFilterByDate.TabStop = False
        Me.gpxFilterByDate.Text = "View By Date Range"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(97, 61)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(188, 20)
        Me.dtpEndDate.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(13, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "End Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear2
        '
        Me.cmdClear2.Location = New System.Drawing.Point(213, 96)
        Me.cmdClear2.Name = "cmdClear2"
        Me.cmdClear2.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear2.TabIndex = 10
        Me.cmdClear2.Text = "Clear"
        Me.cmdClear2.UseVisualStyleBackColor = True
        '
        'cmdViewByDateRange
        '
        Me.cmdViewByDateRange.Location = New System.Drawing.Point(136, 96)
        Me.cmdViewByDateRange.Name = "cmdViewByDateRange"
        Me.cmdViewByDateRange.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByDateRange.TabIndex = 10
        Me.cmdViewByDateRange.Text = "View"
        Me.cmdViewByDateRange.UseVisualStyleBackColor = True
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(97, 31)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(188, 20)
        Me.dtpBeginDate.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(13, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Begin Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxDivisionID
        '
        Me.gpxDivisionID.Controls.Add(Me.cboDivisionID)
        Me.gpxDivisionID.Controls.Add(Me.cmdViewByDivision)
        Me.gpxDivisionID.Controls.Add(Me.cmdClear)
        Me.gpxDivisionID.Controls.Add(Me.Label1)
        Me.gpxDivisionID.Location = New System.Drawing.Point(29, 41)
        Me.gpxDivisionID.Name = "gpxDivisionID"
        Me.gpxDivisionID.Size = New System.Drawing.Size(300, 109)
        Me.gpxDivisionID.TabIndex = 0
        Me.gpxDivisionID.TabStop = False
        Me.gpxDivisionID.Text = "View By Company"
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(98, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(187, 21)
        Me.cboDivisionID.TabIndex = 0
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
        'cmdViewByDivision
        '
        Me.cmdViewByDivision.Location = New System.Drawing.Point(136, 65)
        Me.cmdViewByDivision.Name = "cmdViewByDivision"
        Me.cmdViewByDivision.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByDivision.TabIndex = 1
        Me.cmdViewByDivision.Text = "View"
        Me.cmdViewByDivision.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(213, 65)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 2
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
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
        'gpxViewByEmployee
        '
        Me.gpxViewByEmployee.Controls.Add(Me.cboFName)
        Me.gpxViewByEmployee.Controls.Add(Me.Label5)
        Me.gpxViewByEmployee.Controls.Add(Me.cboLName)
        Me.gpxViewByEmployee.Controls.Add(Me.Label4)
        Me.gpxViewByEmployee.Controls.Add(Me.cboLoginName)
        Me.gpxViewByEmployee.Controls.Add(Me.cmdViewByEmployees)
        Me.gpxViewByEmployee.Controls.Add(Me.cmdClear1)
        Me.gpxViewByEmployee.Controls.Add(Me.Label2)
        Me.gpxViewByEmployee.Location = New System.Drawing.Point(29, 166)
        Me.gpxViewByEmployee.Name = "gpxViewByEmployee"
        Me.gpxViewByEmployee.Size = New System.Drawing.Size(300, 176)
        Me.gpxViewByEmployee.TabIndex = 3
        Me.gpxViewByEmployee.TabStop = False
        Me.gpxViewByEmployee.Text = "View By Employee"
        '
        'cboFName
        '
        Me.cboFName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFName.DataSource = Me.EmployeeDataBindingSource
        Me.cboFName.DisplayMember = "EmployeeFirst"
        Me.cboFName.FormattingEnabled = True
        Me.cboFName.Location = New System.Drawing.Point(97, 23)
        Me.cboFName.Name = "cboFName"
        Me.cboFName.Size = New System.Drawing.Size(187, 21)
        Me.cboFName.TabIndex = 3
        '
        'EmployeeDataBindingSource
        '
        Me.EmployeeDataBindingSource.DataMember = "EmployeeData"
        Me.EmployeeDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(13, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "First Name"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLName
        '
        Me.cboLName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLName.DataSource = Me.EmployeeDataBindingSource
        Me.cboLName.DisplayMember = "EmployeeLast"
        Me.cboLName.FormattingEnabled = True
        Me.cboLName.Location = New System.Drawing.Point(97, 59)
        Me.cboLName.Name = "cboLName"
        Me.cboLName.Size = New System.Drawing.Size(187, 21)
        Me.cboLName.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(13, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Last Name"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLoginName
        '
        Me.cboLoginName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLoginName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLoginName.DataSource = Me.EmployeeDataBindingSource
        Me.cboLoginName.DisplayMember = "LoginName"
        Me.cboLoginName.FormattingEnabled = True
        Me.cboLoginName.Location = New System.Drawing.Point(97, 95)
        Me.cboLoginName.Name = "cboLoginName"
        Me.cboLoginName.Size = New System.Drawing.Size(187, 21)
        Me.cboLoginName.TabIndex = 5
        '
        'cmdViewByEmployees
        '
        Me.cmdViewByEmployees.Location = New System.Drawing.Point(136, 132)
        Me.cmdViewByEmployees.Name = "cmdViewByEmployees"
        Me.cmdViewByEmployees.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByEmployees.TabIndex = 6
        Me.cmdViewByEmployees.Text = "View"
        Me.cmdViewByEmployees.UseVisualStyleBackColor = True
        '
        'cmdClear1
        '
        Me.cmdClear1.Location = New System.Drawing.Point(213, 132)
        Me.cmdClear1.Name = "cmdClear1"
        Me.cmdClear1.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear1.TabIndex = 7
        Me.cmdClear1.Text = "Clear"
        Me.cmdClear1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(14, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Employee Login"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UserLoginTableBindingSource
        '
        Me.UserLoginTableBindingSource.DataMember = "UserLoginTable"
        Me.UserLoginTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvUserLoginTable
        '
        Me.dgvUserLoginTable.AllowUserToAddRows = False
        Me.dgvUserLoginTable.AllowUserToDeleteRows = False
        Me.dgvUserLoginTable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvUserLoginTable.AutoGenerateColumns = False
        Me.dgvUserLoginTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUserLoginTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvUserLoginTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvUserLoginTable.ColumnHeadersHeight = 31
        Me.dgvUserLoginTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LoginNameDataGridViewTextBoxColumn, Me.LoginDateTimeDataGridViewTextBoxColumn, Me.LogoutDateTimeDataGridViewTextBoxColumn, Me.CompanyCodeDataGridViewTextBoxColumn, Me.SessionIDDataGridViewTextBoxColumn})
        Me.dgvUserLoginTable.DataSource = Me.UserLoginTableBindingSource
        Me.dgvUserLoginTable.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvUserLoginTable.Location = New System.Drawing.Point(347, 41)
        Me.dgvUserLoginTable.Name = "dgvUserLoginTable"
        Me.dgvUserLoginTable.ReadOnly = True
        Me.dgvUserLoginTable.Size = New System.Drawing.Size(783, 718)
        Me.dgvUserLoginTable.TabIndex = 5
        '
        'LoginNameDataGridViewTextBoxColumn
        '
        Me.LoginNameDataGridViewTextBoxColumn.DataPropertyName = "LoginName"
        Me.LoginNameDataGridViewTextBoxColumn.HeaderText = "Login Name"
        Me.LoginNameDataGridViewTextBoxColumn.Name = "LoginNameDataGridViewTextBoxColumn"
        Me.LoginNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LoginDateTimeDataGridViewTextBoxColumn
        '
        Me.LoginDateTimeDataGridViewTextBoxColumn.DataPropertyName = "LoginDateTime"
        Me.LoginDateTimeDataGridViewTextBoxColumn.HeaderText = "Login Date Time"
        Me.LoginDateTimeDataGridViewTextBoxColumn.Name = "LoginDateTimeDataGridViewTextBoxColumn"
        Me.LoginDateTimeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LogoutDateTimeDataGridViewTextBoxColumn
        '
        Me.LogoutDateTimeDataGridViewTextBoxColumn.DataPropertyName = "LogoutDateTime"
        Me.LogoutDateTimeDataGridViewTextBoxColumn.HeaderText = "Logout Date Time"
        Me.LogoutDateTimeDataGridViewTextBoxColumn.Name = "LogoutDateTimeDataGridViewTextBoxColumn"
        Me.LogoutDateTimeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CompanyCodeDataGridViewTextBoxColumn
        '
        Me.CompanyCodeDataGridViewTextBoxColumn.DataPropertyName = "CompanyCode"
        Me.CompanyCodeDataGridViewTextBoxColumn.HeaderText = "Company Code"
        Me.CompanyCodeDataGridViewTextBoxColumn.Name = "CompanyCodeDataGridViewTextBoxColumn"
        Me.CompanyCodeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SessionIDDataGridViewTextBoxColumn
        '
        Me.SessionIDDataGridViewTextBoxColumn.DataPropertyName = "SessionID"
        Me.SessionIDDataGridViewTextBoxColumn.HeaderText = "Session ID"
        Me.SessionIDDataGridViewTextBoxColumn.Name = "SessionIDDataGridViewTextBoxColumn"
        Me.SessionIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'UserLoginTableTableAdapter
        '
        Me.UserLoginTableTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 12
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'EmployeeDataTableAdapter
        '
        Me.EmployeeDataTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmdClearLogonList)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 512)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 198)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Clear Logon List"
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(19, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(265, 89)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "This procedure will reset the Logon Record for the specific division (Administrat" & _
            "ion only)."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearLogonList
        '
        Me.cmdClearLogonList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearLogonList.Location = New System.Drawing.Point(214, 141)
        Me.cmdClearLogonList.Name = "cmdClearLogonList"
        Me.cmdClearLogonList.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearLogonList.TabIndex = 13
        Me.cmdClearLogonList.Text = "Clear List"
        Me.cmdClearLogonList.UseVisualStyleBackColor = True
        '
        'ViewEmployeeLogonTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvUserLoginTable)
        Me.Controls.Add(Me.gpxViewByEmployee)
        Me.Controls.Add(Me.gpxFilterByDate)
        Me.Controls.Add(Me.gpxDivisionID)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewEmployeeLogonTable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Employee Logons"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxFilterByDate.ResumeLayout(False)
        Me.gpxDivisionID.ResumeLayout(False)
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxViewByEmployee.ResumeLayout(False)
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UserLoginTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvUserLoginTable, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents gpxFilterByDate As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdClear2 As System.Windows.Forms.Button
    Friend WithEvents cmdViewByDateRange As System.Windows.Forms.Button
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gpxDivisionID As System.Windows.Forms.GroupBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdViewByDivision As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gpxViewByEmployee As System.Windows.Forms.GroupBox
    Friend WithEvents cboLoginName As System.Windows.Forms.ComboBox
    Friend WithEvents cmdViewByEmployees As System.Windows.Forms.Button
    Friend WithEvents cmdClear1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents dgvUserLoginTable As System.Windows.Forms.DataGridView
    Friend WithEvents UserLoginTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UserLoginTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.UserLoginTableTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cboFName As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboLName As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents LoginNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoginDateTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogoutDateTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CompanyCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SessionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdClearLogonList As System.Windows.Forms.Button
End Class
