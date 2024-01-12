<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GLTransactionEntry
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
        Me.txtDebit = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cboAccountNumber = New System.Windows.Forms.ComboBox
        Me.GLAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label13 = New System.Windows.Forms.Label
        Me.dtpTransactionDate = New System.Windows.Forms.DateTimePicker
        Me.txtGLComment = New System.Windows.Forms.TextBox
        Me.cboJournalID = New System.Windows.Forms.ComboBox
        Me.GLJournalsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtReferenceLine = New System.Windows.Forms.TextBox
        Me.txtReferenceNumber = New System.Windows.Forms.TextBox
        Me.txtBatchNumber = New System.Windows.Forms.TextBox
        Me.txtCredit = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtGLTransactionKey = New System.Windows.Forms.TextBox
        Me.cmdGenerateTransactionNumber = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdAddGLTransaction = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtGLTransactionDescription = New System.Windows.Forms.TextBox
        Me.GLAccountsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.GLJournalsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalsTableAdapter
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLJournalsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(342, 24)
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
        'txtDebit
        '
        Me.txtDebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDebit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDebit.Location = New System.Drawing.Point(154, 325)
        Me.txtDebit.Name = "txtDebit"
        Me.txtDebit.Size = New System.Drawing.Size(145, 20)
        Me.txtDebit.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(37, 325)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(136, 20)
        Me.Label14.TabIndex = 77
        Me.Label14.Text = "Debit Amount"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAccountNumber
        '
        Me.cboAccountNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAccountNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountNumber.DataSource = Me.GLAccountsBindingSource
        Me.cboAccountNumber.DisplayMember = "GLAccountNumber"
        Me.cboAccountNumber.FormattingEnabled = True
        Me.cboAccountNumber.Location = New System.Drawing.Point(120, 152)
        Me.cboAccountNumber.Name = "cboAccountNumber"
        Me.cboAccountNumber.Size = New System.Drawing.Size(179, 21)
        Me.cboAccountNumber.TabIndex = 4
        '
        'GLAccountsBindingSource
        '
        Me.GLAccountsBindingSource.DataMember = "GLAccounts"
        Me.GLAccountsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(37, 397)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(127, 20)
        Me.Label13.TabIndex = 74
        Me.Label13.Text = "GL Transaction Comment"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpTransactionDate
        '
        Me.dtpTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTransactionDate.Location = New System.Drawing.Point(140, 115)
        Me.dtpTransactionDate.Name = "dtpTransactionDate"
        Me.dtpTransactionDate.Size = New System.Drawing.Size(159, 20)
        Me.dtpTransactionDate.TabIndex = 3
        '
        'txtGLComment
        '
        Me.txtGLComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGLComment.Location = New System.Drawing.Point(39, 420)
        Me.txtGLComment.Multiline = True
        Me.txtGLComment.Name = "txtGLComment"
        Me.txtGLComment.Size = New System.Drawing.Size(260, 80)
        Me.txtGLComment.TabIndex = 8
        '
        'cboJournalID
        '
        Me.cboJournalID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboJournalID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboJournalID.DataSource = Me.GLJournalsBindingSource
        Me.cboJournalID.DisplayMember = "GLJournalID"
        Me.cboJournalID.FormattingEnabled = True
        Me.cboJournalID.Location = New System.Drawing.Point(108, 527)
        Me.cboJournalID.Name = "cboJournalID"
        Me.cboJournalID.Size = New System.Drawing.Size(191, 21)
        Me.cboJournalID.TabIndex = 9
        '
        'GLJournalsBindingSource
        '
        Me.GLJournalsBindingSource.DataMember = "GLJournals"
        Me.GLJournalsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtReferenceLine
        '
        Me.txtReferenceLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenceLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferenceLine.Location = New System.Drawing.Point(154, 656)
        Me.txtReferenceLine.Name = "txtReferenceLine"
        Me.txtReferenceLine.Size = New System.Drawing.Size(145, 20)
        Me.txtReferenceLine.TabIndex = 12
        '
        'txtReferenceNumber
        '
        Me.txtReferenceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferenceNumber.Location = New System.Drawing.Point(154, 621)
        Me.txtReferenceNumber.Name = "txtReferenceNumber"
        Me.txtReferenceNumber.Size = New System.Drawing.Size(145, 20)
        Me.txtReferenceNumber.TabIndex = 11
        '
        'txtBatchNumber
        '
        Me.txtBatchNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchNumber.Location = New System.Drawing.Point(154, 586)
        Me.txtBatchNumber.Name = "txtBatchNumber"
        Me.txtBatchNumber.Size = New System.Drawing.Size(145, 20)
        Me.txtBatchNumber.TabIndex = 10
        '
        'txtCredit
        '
        Me.txtCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCredit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCredit.Location = New System.Drawing.Point(154, 360)
        Me.txtCredit.Name = "txtCredit"
        Me.txtCredit.Size = New System.Drawing.Size(145, 20)
        Me.txtCredit.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(37, 528)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 20)
        Me.Label10.TabIndex = 72
        Me.Label10.Text = "GL Journal"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGLTransactionKey
        '
        Me.txtGLTransactionKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLTransactionKey.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGLTransactionKey.Location = New System.Drawing.Point(140, 79)
        Me.txtGLTransactionKey.Name = "txtGLTransactionKey"
        Me.txtGLTransactionKey.Size = New System.Drawing.Size(159, 20)
        Me.txtGLTransactionKey.TabIndex = 2
        '
        'cmdGenerateTransactionNumber
        '
        Me.cmdGenerateTransactionNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateTransactionNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateTransactionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateTransactionNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateTransactionNumber.Location = New System.Drawing.Point(108, 79)
        Me.cmdGenerateTransactionNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateTransactionNumber.Name = "cmdGenerateTransactionNumber"
        Me.cmdGenerateTransactionNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateTransactionNumber.TabIndex = 1
        Me.cmdGenerateTransactionNumber.Text = ">>"
        Me.cmdGenerateTransactionNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateTransactionNumber.UseVisualStyleBackColor = False
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(151, 711)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdAddGLTransaction
        '
        Me.cmdAddGLTransaction.Location = New System.Drawing.Point(74, 711)
        Me.cmdAddGLTransaction.Name = "cmdAddGLTransaction"
        Me.cmdAddGLTransaction.Size = New System.Drawing.Size(71, 30)
        Me.cmdAddGLTransaction.TabIndex = 13
        Me.cmdAddGLTransaction.Text = "Add"
        Me.cmdAddGLTransaction.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(140, 44)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(159, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(37, 195)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(261, 20)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "GL Transaction Description"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(37, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 20)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(37, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 20)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "GL Trans. #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(37, 656)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 20)
        Me.Label9.TabIndex = 71
        Me.Label9.Text = "Ref. Line Number"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(37, 621)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 20)
        Me.Label8.TabIndex = 70
        Me.Label8.Text = "Reference Number"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(37, 586)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 20)
        Me.Label7.TabIndex = 69
        Me.Label7.Text = "Batch Number"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(37, 360)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 20)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Credit Amount"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(37, 115)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 20)
        Me.Label11.TabIndex = 73
        Me.Label11.Text = "GL Trans. Date"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(37, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 20)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "GL Account #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGLTransactionDescription
        '
        Me.txtGLTransactionDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLTransactionDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGLTransactionDescription.Location = New System.Drawing.Point(39, 218)
        Me.txtGLTransactionDescription.Multiline = True
        Me.txtGLTransactionDescription.Name = "txtGLTransactionDescription"
        Me.txtGLTransactionDescription.Size = New System.Drawing.Size(260, 80)
        Me.txtGLTransactionDescription.TabIndex = 5
        '
        'GLAccountsTableAdapter
        '
        Me.GLAccountsTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'GLJournalsTableAdapter
        '
        Me.GLJournalsTableAdapter.ClearBeforeFill = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(228, 711)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 30)
        Me.cmdExit.TabIndex = 78
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GLTransactionEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 753)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.txtGLTransactionDescription)
        Me.Controls.Add(Me.txtDebit)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cboAccountNumber)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.dtpTransactionDate)
        Me.Controls.Add(Me.txtGLComment)
        Me.Controls.Add(Me.cboJournalID)
        Me.Controls.Add(Me.txtReferenceLine)
        Me.Controls.Add(Me.txtReferenceNumber)
        Me.Controls.Add(Me.txtBatchNumber)
        Me.Controls.Add(Me.txtCredit)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtGLTransactionKey)
        Me.Controls.Add(Me.cmdGenerateTransactionNumber)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdAddGLTransaction)
        Me.Controls.Add(Me.cboDivisionID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "GLTransactionEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation GL Transaction Entry"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLJournalsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtDebit As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboAccountNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtpTransactionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtGLComment As System.Windows.Forms.TextBox
    Friend WithEvents cboJournalID As System.Windows.Forms.ComboBox
    Friend WithEvents txtReferenceLine As System.Windows.Forms.TextBox
    Friend WithEvents txtReferenceNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtBatchNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtCredit As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtGLTransactionKey As System.Windows.Forms.TextBox
    Friend WithEvents cmdGenerateTransactionNumber As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdAddGLTransaction As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtGLTransactionDescription As System.Windows.Forms.TextBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents GLAccountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents GLJournalsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLJournalsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalsTableAdapter
    Friend WithEvents cmdExit As System.Windows.Forms.Button
End Class
