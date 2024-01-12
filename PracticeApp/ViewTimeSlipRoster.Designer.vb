<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewTimeSlipRoster
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdViewByFilter = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpPostDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.dgvTimeSlipRoster = New System.Windows.Forms.DataGridView
        Me.TimeSlipPostingRosterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimeSlipPostingRosterTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TimeSlipPostingRosterTableAdapter
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.PostDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmployeeShiftDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmployeeIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmployeeLastDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmployeeFirstDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SumHoursDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReasonDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PostingExistDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTimeSlipRoster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeSlipPostingRosterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdViewByFilter)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpPostDate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 186)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter Fields"
        '
        'cmdViewByFilter
        '
        Me.cmdViewByFilter.Location = New System.Drawing.Point(134, 135)
        Me.cmdViewByFilter.Name = "cmdViewByFilter"
        Me.cmdViewByFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilter.TabIndex = 6
        Me.cmdViewByFilter.Text = "View"
        Me.cmdViewByFilter.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(211, 135)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(15, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Post Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpPostDate
        '
        Me.dtpPostDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPostDate.Location = New System.Drawing.Point(121, 91)
        Me.dtpPostDate.Name = "dtpPostDate"
        Me.dtpPostDate.Size = New System.Drawing.Size(161, 20)
        Me.dtpPostDate.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Division"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(121, 37)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(161, 21)
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
        'dgvTimeSlipRoster
        '
        Me.dgvTimeSlipRoster.AllowUserToAddRows = False
        Me.dgvTimeSlipRoster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTimeSlipRoster.AutoGenerateColumns = False
        Me.dgvTimeSlipRoster.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvTimeSlipRoster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTimeSlipRoster.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PostDateDataGridViewTextBoxColumn, Me.EmployeeShiftDataGridViewTextBoxColumn, Me.EmployeeIDDataGridViewTextBoxColumn, Me.EmployeeLastDataGridViewTextBoxColumn, Me.EmployeeFirstDataGridViewTextBoxColumn, Me.SumHoursDataGridViewTextBoxColumn, Me.ReasonDataGridViewTextBoxColumn, Me.PostingExistDataGridViewTextBoxColumn})
        Me.dgvTimeSlipRoster.DataSource = Me.TimeSlipPostingRosterBindingSource
        Me.dgvTimeSlipRoster.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvTimeSlipRoster.Location = New System.Drawing.Point(346, 41)
        Me.dgvTimeSlipRoster.Name = "dgvTimeSlipRoster"
        Me.dgvTimeSlipRoster.Size = New System.Drawing.Size(684, 725)
        Me.dgvTimeSlipRoster.TabIndex = 2
        '
        'TimeSlipPostingRosterBindingSource
        '
        Me.TimeSlipPostingRosterBindingSource.DataMember = "TimeSlipPostingRoster"
        Me.TimeSlipPostingRosterBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'TimeSlipPostingRosterTableAdapter
        '
        Me.TimeSlipPostingRosterTableAdapter.ClearBeforeFill = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(959, 772)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 3
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Location = New System.Drawing.Point(882, 772)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 4
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'PostDateDataGridViewTextBoxColumn
        '
        Me.PostDateDataGridViewTextBoxColumn.DataPropertyName = "PostDate"
        Me.PostDateDataGridViewTextBoxColumn.HeaderText = "Post Date"
        Me.PostDateDataGridViewTextBoxColumn.Name = "PostDateDataGridViewTextBoxColumn"
        Me.PostDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.PostDateDataGridViewTextBoxColumn.Width = 60
        '
        'EmployeeShiftDataGridViewTextBoxColumn
        '
        Me.EmployeeShiftDataGridViewTextBoxColumn.DataPropertyName = "EmployeeShift"
        Me.EmployeeShiftDataGridViewTextBoxColumn.HeaderText = "Shift"
        Me.EmployeeShiftDataGridViewTextBoxColumn.Name = "EmployeeShiftDataGridViewTextBoxColumn"
        Me.EmployeeShiftDataGridViewTextBoxColumn.Width = 60
        '
        'EmployeeIDDataGridViewTextBoxColumn
        '
        Me.EmployeeIDDataGridViewTextBoxColumn.DataPropertyName = "EmployeeID"
        Me.EmployeeIDDataGridViewTextBoxColumn.HeaderText = "Employee ID"
        Me.EmployeeIDDataGridViewTextBoxColumn.Name = "EmployeeIDDataGridViewTextBoxColumn"
        Me.EmployeeIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.EmployeeIDDataGridViewTextBoxColumn.Width = 80
        '
        'EmployeeLastDataGridViewTextBoxColumn
        '
        Me.EmployeeLastDataGridViewTextBoxColumn.DataPropertyName = "EmployeeLast"
        Me.EmployeeLastDataGridViewTextBoxColumn.HeaderText = "Employee Last"
        Me.EmployeeLastDataGridViewTextBoxColumn.Name = "EmployeeLastDataGridViewTextBoxColumn"
        Me.EmployeeLastDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EmployeeFirstDataGridViewTextBoxColumn
        '
        Me.EmployeeFirstDataGridViewTextBoxColumn.DataPropertyName = "EmployeeFirst"
        Me.EmployeeFirstDataGridViewTextBoxColumn.HeaderText = "Employee First"
        Me.EmployeeFirstDataGridViewTextBoxColumn.Name = "EmployeeFirstDataGridViewTextBoxColumn"
        Me.EmployeeFirstDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SumHoursDataGridViewTextBoxColumn
        '
        Me.SumHoursDataGridViewTextBoxColumn.DataPropertyName = "SumHours"
        Me.SumHoursDataGridViewTextBoxColumn.HeaderText = "Hours"
        Me.SumHoursDataGridViewTextBoxColumn.Name = "SumHoursDataGridViewTextBoxColumn"
        Me.SumHoursDataGridViewTextBoxColumn.ReadOnly = True
        Me.SumHoursDataGridViewTextBoxColumn.Width = 60
        '
        'ReasonDataGridViewTextBoxColumn
        '
        Me.ReasonDataGridViewTextBoxColumn.DataPropertyName = "Reason"
        Me.ReasonDataGridViewTextBoxColumn.HeaderText = "Reason"
        Me.ReasonDataGridViewTextBoxColumn.Name = "ReasonDataGridViewTextBoxColumn"
        Me.ReasonDataGridViewTextBoxColumn.Width = 120
        '
        'PostingExistDataGridViewTextBoxColumn
        '
        Me.PostingExistDataGridViewTextBoxColumn.DataPropertyName = "PostingExist"
        Me.PostingExistDataGridViewTextBoxColumn.FalseValue = "NO"
        Me.PostingExistDataGridViewTextBoxColumn.HeaderText = "Time Slip?"
        Me.PostingExistDataGridViewTextBoxColumn.Name = "PostingExistDataGridViewTextBoxColumn"
        Me.PostingExistDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PostingExistDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.PostingExistDataGridViewTextBoxColumn.TrueValue = "YES"
        Me.PostingExistDataGridViewTextBoxColumn.Width = 60
        '
        'ViewTimeSlipRoster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvTimeSlipRoster)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewTimeSlipRoster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Time Slip Roster"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTimeSlipRoster, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeSlipPostingRosterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvTimeSlipRoster As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents TimeSlipPostingRosterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TimeSlipPostingRosterTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TimeSlipPostingRosterTableAdapter
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpPostDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdViewByFilter As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents PostDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeShiftDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeLastDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeFirstDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SumHoursDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReasonDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PostingExistDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
