<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewBlueprintJournalActivity
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvBlueprintJournal = New System.Windows.Forms.DataGridView
        Me.EntryKeyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BlueprintNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EntryTitleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EntryDetailsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EntryDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LastUpdatedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BlueprintJournalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.BlueprintJournalTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BlueprintJournalTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.txtTextSearch = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtBlueprintNumber = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.cmdExit = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtTextDetails = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvBlueprintJournal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BlueprintJournalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'dgvBlueprintJournal
        '
        Me.dgvBlueprintJournal.AllowUserToAddRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvBlueprintJournal.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBlueprintJournal.AutoGenerateColumns = False
        Me.dgvBlueprintJournal.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvBlueprintJournal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBlueprintJournal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EntryKeyDataGridViewTextBoxColumn, Me.BlueprintNumberDataGridViewTextBoxColumn, Me.EntryTitleDataGridViewTextBoxColumn, Me.EntryDetailsDataGridViewTextBoxColumn, Me.EntryDateDataGridViewTextBoxColumn, Me.LastUpdatedDataGridViewTextBoxColumn})
        Me.dgvBlueprintJournal.DataSource = Me.BlueprintJournalBindingSource
        Me.dgvBlueprintJournal.Location = New System.Drawing.Point(348, 41)
        Me.dgvBlueprintJournal.Name = "dgvBlueprintJournal"
        Me.dgvBlueprintJournal.Size = New System.Drawing.Size(682, 724)
        Me.dgvBlueprintJournal.TabIndex = 1
        '
        'EntryKeyDataGridViewTextBoxColumn
        '
        Me.EntryKeyDataGridViewTextBoxColumn.DataPropertyName = "EntryKey"
        Me.EntryKeyDataGridViewTextBoxColumn.HeaderText = "EntryKey"
        Me.EntryKeyDataGridViewTextBoxColumn.Name = "EntryKeyDataGridViewTextBoxColumn"
        Me.EntryKeyDataGridViewTextBoxColumn.Visible = False
        '
        'BlueprintNumberDataGridViewTextBoxColumn
        '
        Me.BlueprintNumberDataGridViewTextBoxColumn.DataPropertyName = "BlueprintNumber"
        Me.BlueprintNumberDataGridViewTextBoxColumn.HeaderText = "Blueprint #"
        Me.BlueprintNumberDataGridViewTextBoxColumn.Name = "BlueprintNumberDataGridViewTextBoxColumn"
        '
        'EntryTitleDataGridViewTextBoxColumn
        '
        Me.EntryTitleDataGridViewTextBoxColumn.DataPropertyName = "EntryTitle"
        Me.EntryTitleDataGridViewTextBoxColumn.HeaderText = "Entry Title"
        Me.EntryTitleDataGridViewTextBoxColumn.Name = "EntryTitleDataGridViewTextBoxColumn"
        Me.EntryTitleDataGridViewTextBoxColumn.Width = 150
        '
        'EntryDetailsDataGridViewTextBoxColumn
        '
        Me.EntryDetailsDataGridViewTextBoxColumn.DataPropertyName = "EntryDetails"
        Me.EntryDetailsDataGridViewTextBoxColumn.HeaderText = "Details"
        Me.EntryDetailsDataGridViewTextBoxColumn.Name = "EntryDetailsDataGridViewTextBoxColumn"
        Me.EntryDetailsDataGridViewTextBoxColumn.Width = 200
        '
        'EntryDateDataGridViewTextBoxColumn
        '
        Me.EntryDateDataGridViewTextBoxColumn.DataPropertyName = "EntryDate"
        Me.EntryDateDataGridViewTextBoxColumn.HeaderText = "Entry Date"
        Me.EntryDateDataGridViewTextBoxColumn.Name = "EntryDateDataGridViewTextBoxColumn"
        '
        'LastUpdatedDataGridViewTextBoxColumn
        '
        Me.LastUpdatedDataGridViewTextBoxColumn.DataPropertyName = "LastUpdated"
        Me.LastUpdatedDataGridViewTextBoxColumn.HeaderText = "Last Updated"
        Me.LastUpdatedDataGridViewTextBoxColumn.Name = "LastUpdatedDataGridViewTextBoxColumn"
        '
        'BlueprintJournalBindingSource
        '
        Me.BlueprintJournalBindingSource.DataMember = "BlueprintJournal"
        Me.BlueprintJournalBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BlueprintJournalTableAdapter
        '
        Me.BlueprintJournalTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTextDetails)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.chkDateRange)
        Me.GroupBox1.Controls.Add(Me.cmdSearch)
        Me.GroupBox1.Controls.Add(Me.txtTextSearch)
        Me.GroupBox1.Controls.Add(Me.dtpEndDate)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtBlueprintNumber)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.dtpBeginDate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 420)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter Details"
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(212, 373)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 8
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(135, 373)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(71, 30)
        Me.cmdSearch.TabIndex = 7
        Me.cmdSearch.Text = "View"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'txtTextSearch
        '
        Me.txtTextSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextSearch.Location = New System.Drawing.Point(123, 133)
        Me.txtTextSearch.Name = "txtTextSearch"
        Me.txtTextSearch.Size = New System.Drawing.Size(160, 20)
        Me.txtTextSearch.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(15, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Text Title Search"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBlueprintNumber
        '
        Me.txtBlueprintNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBlueprintNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBlueprintNumber.Location = New System.Drawing.Point(123, 83)
        Me.txtBlueprintNumber.Name = "txtBlueprintNumber"
        Me.txtBlueprintNumber.Size = New System.Drawing.Size(160, 20)
        Me.txtBlueprintNumber.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(15, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Blueprint #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(123, 33)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(160, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 3
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(26, 228)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(257, 33)
        Me.Label14.TabIndex = 44
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(105, 264)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 39
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(105, 334)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(178, 20)
        Me.dtpEndDate.TabIndex = 41
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(15, 334)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 20)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "End Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(105, 298)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(178, 20)
        Me.dtpBeginDate.TabIndex = 40
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(15, 298)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 20)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Begin Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextDetails
        '
        Me.txtTextDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextDetails.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextDetails.Location = New System.Drawing.Point(123, 183)
        Me.txtTextDetails.Name = "txtTextDetails"
        Me.txtTextDetails.Size = New System.Drawing.Size(160, 20)
        Me.txtTextDetails.TabIndex = 46
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(15, 183)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 20)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Text Details Search"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewBlueprintJournalActivity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvBlueprintJournal)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewBlueprintJournalActivity"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Blueprint Jornal Activity Log"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvBlueprintJournal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BlueprintJournalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvBlueprintJournal As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents BlueprintJournalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BlueprintJournalTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BlueprintJournalTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents EntryKeyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BlueprintNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EntryTitleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EntryDetailsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EntryDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastUpdatedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents txtTextSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBlueprintNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTextDetails As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
