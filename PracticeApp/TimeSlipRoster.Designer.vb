<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimeSlipRoster
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgvTimeSlipRoster = New System.Windows.Forms.DataGridView
        Me.EmployeeIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmployeeFirstColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmployeeLastColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShiftColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PostingColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.HoursColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReasonColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DepartmentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.dtpPostingDate = New System.Windows.Forms.DateTimePicker
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdProceed = New System.Windows.Forms.Button
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.chkSaturdayPosting = New System.Windows.Forms.CheckBox
        CType(Me.dgvTimeSlipRoster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvTimeSlipRoster
        '
        Me.dgvTimeSlipRoster.AllowUserToAddRows = False
        Me.dgvTimeSlipRoster.AllowUserToDeleteRows = False
        Me.dgvTimeSlipRoster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTimeSlipRoster.AutoGenerateColumns = False
        Me.dgvTimeSlipRoster.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvTimeSlipRoster.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTimeSlipRoster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTimeSlipRoster.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EmployeeIDColumn, Me.EmployeeFirstColumn, Me.EmployeeLastColumn, Me.ShiftColumn, Me.PostingColumn, Me.HoursColumn, Me.ReasonColumn, Me.DepartmentColumn, Me.DivisionKeyColumn})
        Me.dgvTimeSlipRoster.DataSource = Me.EmployeeDataBindingSource
        Me.dgvTimeSlipRoster.GridColor = System.Drawing.Color.Blue
        Me.dgvTimeSlipRoster.Location = New System.Drawing.Point(12, 12)
        Me.dgvTimeSlipRoster.Name = "dgvTimeSlipRoster"
        Me.dgvTimeSlipRoster.Size = New System.Drawing.Size(718, 603)
        Me.dgvTimeSlipRoster.TabIndex = 0
        '
        'EmployeeIDColumn
        '
        Me.EmployeeIDColumn.DataPropertyName = "EmployeeID"
        Me.EmployeeIDColumn.HeaderText = "EID"
        Me.EmployeeIDColumn.Name = "EmployeeIDColumn"
        Me.EmployeeIDColumn.ReadOnly = True
        Me.EmployeeIDColumn.Visible = False
        Me.EmployeeIDColumn.Width = 60
        '
        'EmployeeFirstColumn
        '
        Me.EmployeeFirstColumn.DataPropertyName = "EmployeeFirst"
        Me.EmployeeFirstColumn.HeaderText = "First Name"
        Me.EmployeeFirstColumn.Name = "EmployeeFirstColumn"
        Me.EmployeeFirstColumn.ReadOnly = True
        Me.EmployeeFirstColumn.Width = 130
        '
        'EmployeeLastColumn
        '
        Me.EmployeeLastColumn.DataPropertyName = "EmployeeLast"
        Me.EmployeeLastColumn.HeaderText = "Last Name"
        Me.EmployeeLastColumn.Name = "EmployeeLastColumn"
        Me.EmployeeLastColumn.ReadOnly = True
        Me.EmployeeLastColumn.Width = 130
        '
        'ShiftColumn
        '
        Me.ShiftColumn.DataPropertyName = "Shift"
        Me.ShiftColumn.HeaderText = "Shift"
        Me.ShiftColumn.Name = "ShiftColumn"
        Me.ShiftColumn.ReadOnly = True
        Me.ShiftColumn.Width = 60
        '
        'PostingColumn
        '
        Me.PostingColumn.FalseValue = "UNSELECTED"
        Me.PostingColumn.HeaderText = "Posting?"
        Me.PostingColumn.Name = "PostingColumn"
        Me.PostingColumn.ReadOnly = True
        Me.PostingColumn.TrueValue = "SELECTED"
        Me.PostingColumn.Width = 60
        '
        'HoursColumn
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.HoursColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.HoursColumn.HeaderText = "Hours"
        Me.HoursColumn.Name = "HoursColumn"
        Me.HoursColumn.ReadOnly = True
        Me.HoursColumn.Width = 80
        '
        'ReasonColumn
        '
        Me.ReasonColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.ReasonColumn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ReasonColumn.HeaderText = "Reason?"
        Me.ReasonColumn.Items.AddRange(New Object() {"DID NOT TURN IN", "DAY OFF / VACATION", "TRAINING", "NO FOX AVAILABLE", "N/A", "OTHER"})
        Me.ReasonColumn.Name = "ReasonColumn"
        Me.ReasonColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ReasonColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ReasonColumn.Width = 190
        '
        'DepartmentColumn
        '
        Me.DepartmentColumn.DataPropertyName = "Department"
        Me.DepartmentColumn.HeaderText = "Department"
        Me.DepartmentColumn.Name = "DepartmentColumn"
        Me.DepartmentColumn.ReadOnly = True
        Me.DepartmentColumn.Visible = False
        '
        'DivisionKeyColumn
        '
        Me.DivisionKeyColumn.DataPropertyName = "DivisionKey"
        Me.DivisionKeyColumn.HeaderText = "DivisionKey"
        Me.DivisionKeyColumn.Name = "DivisionKeyColumn"
        Me.DivisionKeyColumn.ReadOnly = True
        Me.DivisionKeyColumn.Visible = False
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
        'dtpPostingDate
        '
        Me.dtpPostingDate.Enabled = False
        Me.dtpPostingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPostingDate.Location = New System.Drawing.Point(12, 639)
        Me.dtpPostingDate.Name = "dtpPostingDate"
        Me.dtpPostingDate.Size = New System.Drawing.Size(156, 20)
        Me.dtpPostingDate.TabIndex = 1
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(659, 621)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 2
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdProceed
        '
        Me.cmdProceed.Location = New System.Drawing.Point(582, 621)
        Me.cmdProceed.Name = "cmdProceed"
        Me.cmdProceed.Size = New System.Drawing.Size(71, 40)
        Me.cmdProceed.TabIndex = 3
        Me.cmdProceed.Text = "Proceed"
        Me.cmdProceed.UseVisualStyleBackColor = True
        '
        'EmployeeDataTableAdapter
        '
        Me.EmployeeDataTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'chkSaturdayPosting
        '
        Me.chkSaturdayPosting.AutoSize = True
        Me.chkSaturdayPosting.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSaturdayPosting.ForeColor = System.Drawing.Color.Blue
        Me.chkSaturdayPosting.Location = New System.Drawing.Point(199, 641)
        Me.chkSaturdayPosting.Name = "chkSaturdayPosting"
        Me.chkSaturdayPosting.Size = New System.Drawing.Size(122, 17)
        Me.chkSaturdayPosting.TabIndex = 4
        Me.chkSaturdayPosting.Text = "Saturday Posting"
        Me.chkSaturdayPosting.UseVisualStyleBackColor = True
        '
        'TimeSlipRoster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 673)
        Me.Controls.Add(Me.chkSaturdayPosting)
        Me.Controls.Add(Me.cmdProceed)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dtpPostingDate)
        Me.Controls.Add(Me.dgvTimeSlipRoster)
        Me.Name = "TimeSlipRoster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Time Slip Roster"
        CType(Me.dgvTimeSlipRoster, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvTimeSlipRoster As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents dtpPostingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cmdProceed As System.Windows.Forms.Button
    Friend WithEvents EmployeeIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeFirstColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeLastColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShiftColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PostingColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents HoursColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReasonColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DepartmentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkSaturdayPosting As System.Windows.Forms.CheckBox
End Class
