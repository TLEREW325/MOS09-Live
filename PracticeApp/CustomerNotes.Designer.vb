<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerNotes
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxAPVoucherData = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdClearFilters = New System.Windows.Forms.Button
        Me.cmdTextSearch = New System.Windows.Forms.Button
        Me.txtTextSearch = New System.Windows.Forms.TextBox
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdAddNote = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtNoteBody = New System.Windows.Forms.TextBox
        Me.txtNoteSubject = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpNoteDate = New System.Windows.Forms.DateTimePicker
        Me.CustomerNotesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvCustomerNotes = New System.Windows.Forms.DataGridView
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NoteIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NoteDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NoteSubjectColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NoteBodyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerNotesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerNotesTableAdapter
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.Label7 = New System.Windows.Forms.Label
        Me.ViewPastYearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.gpxAPVoucherData.SuspendLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.CustomerNotesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCustomerNotes, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveDataToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveDataToolStripMenuItem
        '
        Me.SaveDataToolStripMenuItem.Name = "SaveDataToolStripMenuItem"
        Me.SaveDataToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.SaveDataToolStripMenuItem.Text = "Save Data"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewPastYearToolStripMenuItem, Me.ViewAllToolStripMenuItem})
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
        'gpxAPVoucherData
        '
        Me.gpxAPVoucherData.Controls.Add(Me.Label6)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdClearFilters)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdTextSearch)
        Me.gpxAPVoucherData.Controls.Add(Me.txtTextSearch)
        Me.gpxAPVoucherData.Controls.Add(Me.cboCustomerID)
        Me.gpxAPVoucherData.Controls.Add(Me.cboDivisionID)
        Me.gpxAPVoucherData.Controls.Add(Me.cboCustomerName)
        Me.gpxAPVoucherData.Controls.Add(Me.Label3)
        Me.gpxAPVoucherData.Controls.Add(Me.Label1)
        Me.gpxAPVoucherData.Location = New System.Drawing.Point(29, 41)
        Me.gpxAPVoucherData.Name = "gpxAPVoucherData"
        Me.gpxAPVoucherData.Size = New System.Drawing.Size(299, 197)
        Me.gpxAPVoucherData.TabIndex = 0
        Me.gpxAPVoucherData.TabStop = False
        Me.gpxAPVoucherData.Text = "Select Customer"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(16, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(189, 27)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Clears all fields and datagrid"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearFilters
        '
        Me.cmdClearFilters.Location = New System.Drawing.Point(211, 165)
        Me.cmdClearFilters.Name = "cmdClearFilters"
        Me.cmdClearFilters.Size = New System.Drawing.Size(71, 23)
        Me.cmdClearFilters.TabIndex = 5
        Me.cmdClearFilters.Text = "Clear"
        Me.cmdClearFilters.UseVisualStyleBackColor = True
        '
        'cmdTextSearch
        '
        Me.cmdTextSearch.Location = New System.Drawing.Point(211, 136)
        Me.cmdTextSearch.Name = "cmdTextSearch"
        Me.cmdTextSearch.Size = New System.Drawing.Size(71, 23)
        Me.cmdTextSearch.TabIndex = 4
        Me.cmdTextSearch.Text = "Search"
        Me.cmdTextSearch.UseVisualStyleBackColor = True
        '
        'txtTextSearch
        '
        Me.txtTextSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextSearch.Location = New System.Drawing.Point(16, 137)
        Me.txtTextSearch.Name = "txtTextSearch"
        Me.txtTextSearch.Size = New System.Drawing.Size(189, 20)
        Me.txtTextSearch.TabIndex = 3
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(72, 67)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(210, 21)
        Me.cboCustomerID.TabIndex = 1
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
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(72, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(210, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(16, 100)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(266, 21)
        Me.cboCustomerName.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Customer"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAddNote
        '
        Me.cmdAddNote.Location = New System.Drawing.Point(134, 464)
        Me.cmdAddNote.Name = "cmdAddNote"
        Me.cmdAddNote.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddNote.TabIndex = 9
        Me.cmdAddNote.Text = "Add Note"
        Me.cmdAddNote.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(211, 464)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 10
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNoteBody)
        Me.GroupBox1.Controls.Add(Me.txtNoteSubject)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpNoteDate)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.cmdAddNote)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 244)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(299, 517)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add New Customer Note"
        '
        'txtNoteBody
        '
        Me.txtNoteBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoteBody.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoteBody.Location = New System.Drawing.Point(19, 130)
        Me.txtNoteBody.MaxLength = 500
        Me.txtNoteBody.Multiline = True
        Me.txtNoteBody.Name = "txtNoteBody"
        Me.txtNoteBody.Size = New System.Drawing.Size(263, 313)
        Me.txtNoteBody.TabIndex = 8
        '
        'txtNoteSubject
        '
        Me.txtNoteSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoteSubject.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoteSubject.Location = New System.Drawing.Point(19, 79)
        Me.txtNoteSubject.MaxLength = 100
        Me.txtNoteSubject.Name = "txtNoteSubject"
        Me.txtNoteSubject.Size = New System.Drawing.Size(263, 20)
        Me.txtNoteSubject.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(19, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(266, 20)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Body (Limit 500 Characters)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Subject"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpNoteDate
        '
        Me.dtpNoteDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNoteDate.Location = New System.Drawing.Point(122, 33)
        Me.dtpNoteDate.Name = "dtpNoteDate"
        Me.dtpNoteDate.Size = New System.Drawing.Size(160, 20)
        Me.dtpNoteDate.TabIndex = 6
        '
        'CustomerNotesBindingSource
        '
        Me.CustomerNotesBindingSource.DataMember = "CustomerNotes"
        Me.CustomerNotesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvCustomerNotes
        '
        Me.dgvCustomerNotes.AllowUserToAddRows = False
        Me.dgvCustomerNotes.AllowUserToDeleteRows = False
        Me.dgvCustomerNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCustomerNotes.AutoGenerateColumns = False
        Me.dgvCustomerNotes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCustomerNotes.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvCustomerNotes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCustomerNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCustomerNotes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerIDColumn, Me.DivisionIDColumn, Me.NoteIDColumn, Me.NoteDateColumn, Me.NoteSubjectColumn, Me.NoteBodyColumn})
        Me.dgvCustomerNotes.DataSource = Me.CustomerNotesBindingSource
        Me.dgvCustomerNotes.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvCustomerNotes.Location = New System.Drawing.Point(348, 41)
        Me.dgvCustomerNotes.Name = "dgvCustomerNotes"
        Me.dgvCustomerNotes.RowHeadersWidth = 50
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCustomerNotes.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCustomerNotes.Size = New System.Drawing.Size(782, 661)
        Me.dgvCustomerNotes.TabIndex = 6
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "CustomerID"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        Me.CustomerIDColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'NoteIDColumn
        '
        Me.NoteIDColumn.DataPropertyName = "NoteID"
        Me.NoteIDColumn.HeaderText = "NoteID"
        Me.NoteIDColumn.Name = "NoteIDColumn"
        Me.NoteIDColumn.ReadOnly = True
        Me.NoteIDColumn.Visible = False
        '
        'NoteDateColumn
        '
        Me.NoteDateColumn.DataPropertyName = "NoteDate"
        Me.NoteDateColumn.HeaderText = "Date"
        Me.NoteDateColumn.Name = "NoteDateColumn"
        Me.NoteDateColumn.ReadOnly = True
        Me.NoteDateColumn.Width = 85
        '
        'NoteSubjectColumn
        '
        Me.NoteSubjectColumn.DataPropertyName = "NoteSubject"
        Me.NoteSubjectColumn.HeaderText = "Subject"
        Me.NoteSubjectColumn.Name = "NoteSubjectColumn"
        Me.NoteSubjectColumn.Width = 250
        '
        'NoteBodyColumn
        '
        Me.NoteBodyColumn.DataPropertyName = "NoteBody"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NoteBodyColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.NoteBodyColumn.HeaderText = "Body"
        Me.NoteBodyColumn.Name = "NoteBodyColumn"
        Me.NoteBodyColumn.Width = 300
        '
        'CustomerNotesTableAdapter
        '
        Me.CustomerNotesTableAdapter.ClearBeforeFill = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 721)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 13
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 721)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 12
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(905, 721)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 11
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(511, 721)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(234, 40)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "To delete a Customer Note, select the note in the datagrid and press the delete b" & _
            "utton."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewPastYearToolStripMenuItem
        '
        Me.ViewPastYearToolStripMenuItem.Checked = True
        Me.ViewPastYearToolStripMenuItem.CheckOnClick = True
        Me.ViewPastYearToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ViewPastYearToolStripMenuItem.Name = "ViewPastYearToolStripMenuItem"
        Me.ViewPastYearToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ViewPastYearToolStripMenuItem.Text = "View Past Year"
        '
        'ViewAllToolStripMenuItem
        '
        Me.ViewAllToolStripMenuItem.CheckOnClick = True
        Me.ViewAllToolStripMenuItem.Name = "ViewAllToolStripMenuItem"
        Me.ViewAllToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ViewAllToolStripMenuItem.Text = "View All"
        '
        'CustomerNotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 773)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.dgvCustomerNotes)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpxAPVoucherData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "CustomerNotes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Customer Notes"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxAPVoucherData.ResumeLayout(False)
        Me.gpxAPVoucherData.PerformLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.CustomerNotesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCustomerNotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxAPVoucherData As System.Windows.Forms.GroupBox
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdAddNote As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNoteBody As System.Windows.Forms.TextBox
    Friend WithEvents txtNoteSubject As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpNoteDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvCustomerNotes As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents CustomerNotesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerNotesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerNotesTableAdapter
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents SaveDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdTextSearch As System.Windows.Forms.Button
    Friend WithEvents txtTextSearch As System.Windows.Forms.TextBox
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoteIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoteDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoteSubjectColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoteBodyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdClearFilters As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ViewPastYearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
