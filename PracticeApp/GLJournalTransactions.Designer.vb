<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GLJournalTransactions
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
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SelectTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteMultipleLinesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AdminControlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.lblMachineHours = New System.Windows.Forms.Label
        Me.lblSetupHours = New System.Windows.Forms.Label
        Me.gpxJournalTransaction = New System.Windows.Forms.GroupBox
        Me.cboGLBatchNumber = New System.Windows.Forms.ComboBox
        Me.GLJournalHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DTPReversalDate = New System.Windows.Forms.DateTimePicker
        Me.txtGLComment = New System.Windows.Forms.TextBox
        Me.ReversalCheckBox = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboJournalID = New System.Windows.Forms.ComboBox
        Me.GLJournalsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpPostingDate = New System.Windows.Forms.DateTimePicker
        Me.cmdGenerateTransactionNumber = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtGLAccountDescription = New System.Windows.Forms.TextBox
        Me.txtCreditAmount = New System.Windows.Forms.TextBox
        Me.txtGLTransactionDescription = New System.Windows.Forms.TextBox
        Me.txtDebitAmount = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdClearTransaction = New System.Windows.Forms.Button
        Me.cmdEnterTransaction = New System.Windows.Forms.Button
        Me.gpxTransactionDetails = New System.Windows.Forms.GroupBox
        Me.cboGLAccount = New System.Windows.Forms.ComboBox
        Me.GLAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboShortDescription = New System.Windows.Forms.ComboBox
        Me.gpxPostTransactions = New System.Windows.Forms.GroupBox
        Me.chkAdminControl = New System.Windows.Forms.CheckBox
        Me.cmdPostTransactions = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.gpxBatchBalance = New System.Windows.Forms.GroupBox
        Me.txtBatchBalance = New System.Windows.Forms.TextBox
        Me.txtBatchStatus = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtCreditTotal = New System.Windows.Forms.TextBox
        Me.txtDebitTotal = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.GLJournalsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalsTableAdapter
        Me.GLAccountsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
        Me.dgvJournalTransactions = New System.Windows.Forms.DataGridView
        Me.GLJournalTransactionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLDebitAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLCreditAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JournalTransactionDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLBatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLJournalLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GLJournalHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalHeaderTableTableAdapter
        Me.gpxDeleteLines = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmdDeleteTransactionLine = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDeleteLines = New System.Windows.Forms.ComboBox
        Me.GLJournalLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalLineTableTableAdapter
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxJournalTransaction.SuspendLayout()
        CType(Me.GLJournalHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLJournalsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxTransactionDetails.SuspendLayout()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxPostTransactions.SuspendLayout()
        Me.gpxBatchBalance.SuspendLayout()
        CType(Me.dgvJournalTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLJournalLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxDeleteLines.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 29
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(728, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 26
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(805, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 27
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 28
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveBatchToolStripMenuItem, Me.PrintBatchToolStripMenuItem, Me.DeleteBatchToolStripMenuItem, Me.ClearFormToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveBatchToolStripMenuItem
        '
        Me.SaveBatchToolStripMenuItem.Name = "SaveBatchToolStripMenuItem"
        Me.SaveBatchToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.SaveBatchToolStripMenuItem.Text = "Save Batch"
        '
        'PrintBatchToolStripMenuItem
        '
        Me.PrintBatchToolStripMenuItem.Name = "PrintBatchToolStripMenuItem"
        Me.PrintBatchToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.PrintBatchToolStripMenuItem.Text = "Print Batch"
        '
        'DeleteBatchToolStripMenuItem
        '
        Me.DeleteBatchToolStripMenuItem.Name = "DeleteBatchToolStripMenuItem"
        Me.DeleteBatchToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.DeleteBatchToolStripMenuItem.Text = "Delete Batch"
        '
        'ClearFormToolStripMenuItem
        '
        Me.ClearFormToolStripMenuItem.Name = "ClearFormToolStripMenuItem"
        Me.ClearFormToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ClearFormToolStripMenuItem.Text = "Clear Form"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectTemplateToolStripMenuItem, Me.DeleteMultipleLinesToolStripMenuItem, Me.AdminControlToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'SelectTemplateToolStripMenuItem
        '
        Me.SelectTemplateToolStripMenuItem.Name = "SelectTemplateToolStripMenuItem"
        Me.SelectTemplateToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.SelectTemplateToolStripMenuItem.Text = "Select Template"
        '
        'DeleteMultipleLinesToolStripMenuItem
        '
        Me.DeleteMultipleLinesToolStripMenuItem.Name = "DeleteMultipleLinesToolStripMenuItem"
        Me.DeleteMultipleLinesToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.DeleteMultipleLinesToolStripMenuItem.Text = "Delete Multiple Lines"
        '
        'AdminControlToolStripMenuItem
        '
        Me.AdminControlToolStripMenuItem.Name = "AdminControlToolStripMenuItem"
        Me.AdminControlToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.AdminControlToolStripMenuItem.Text = "Admin Control"
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
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(134, 24)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(172, 21)
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
        'lblMachineHours
        '
        Me.lblMachineHours.Location = New System.Drawing.Point(17, 25)
        Me.lblMachineHours.Name = "lblMachineHours"
        Me.lblMachineHours.Size = New System.Drawing.Size(115, 20)
        Me.lblMachineHours.TabIndex = 21
        Me.lblMachineHours.Text = "Division ID"
        Me.lblMachineHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSetupHours
        '
        Me.lblSetupHours.Location = New System.Drawing.Point(16, 54)
        Me.lblSetupHours.Name = "lblSetupHours"
        Me.lblSetupHours.Size = New System.Drawing.Size(115, 20)
        Me.lblSetupHours.TabIndex = 20
        Me.lblSetupHours.Text = "GL Batch #"
        Me.lblSetupHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxJournalTransaction
        '
        Me.gpxJournalTransaction.Controls.Add(Me.cboGLBatchNumber)
        Me.gpxJournalTransaction.Controls.Add(Me.DTPReversalDate)
        Me.gpxJournalTransaction.Controls.Add(Me.txtGLComment)
        Me.gpxJournalTransaction.Controls.Add(Me.ReversalCheckBox)
        Me.gpxJournalTransaction.Controls.Add(Me.Label9)
        Me.gpxJournalTransaction.Controls.Add(Me.Label8)
        Me.gpxJournalTransaction.Controls.Add(Me.cboJournalID)
        Me.gpxJournalTransaction.Controls.Add(Me.Label7)
        Me.gpxJournalTransaction.Controls.Add(Me.dtpPostingDate)
        Me.gpxJournalTransaction.Controls.Add(Me.lblMachineHours)
        Me.gpxJournalTransaction.Controls.Add(Me.cboDivisionID)
        Me.gpxJournalTransaction.Controls.Add(Me.cmdGenerateTransactionNumber)
        Me.gpxJournalTransaction.Controls.Add(Me.lblSetupHours)
        Me.gpxJournalTransaction.Location = New System.Drawing.Point(29, 27)
        Me.gpxJournalTransaction.Name = "gpxJournalTransaction"
        Me.gpxJournalTransaction.Size = New System.Drawing.Size(323, 349)
        Me.gpxJournalTransaction.TabIndex = 0
        Me.gpxJournalTransaction.TabStop = False
        Me.gpxJournalTransaction.Text = "Journal Transaction"
        '
        'cboGLBatchNumber
        '
        Me.cboGLBatchNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGLBatchNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLBatchNumber.DataSource = Me.GLJournalHeaderTableBindingSource
        Me.cboGLBatchNumber.DisplayMember = "GLJournalBatchNumber"
        Me.cboGLBatchNumber.FormattingEnabled = True
        Me.cboGLBatchNumber.Location = New System.Drawing.Point(135, 51)
        Me.cboGLBatchNumber.Name = "cboGLBatchNumber"
        Me.cboGLBatchNumber.Size = New System.Drawing.Size(171, 21)
        Me.cboGLBatchNumber.TabIndex = 2
        '
        'GLJournalHeaderTableBindingSource
        '
        Me.GLJournalHeaderTableBindingSource.DataMember = "GLJournalHeaderTable"
        Me.GLJournalHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'DTPReversalDate
        '
        Me.DTPReversalDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPReversalDate.Location = New System.Drawing.Point(134, 140)
        Me.DTPReversalDate.Name = "DTPReversalDate"
        Me.DTPReversalDate.Size = New System.Drawing.Size(172, 20)
        Me.DTPReversalDate.TabIndex = 6
        '
        'txtGLComment
        '
        Me.txtGLComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGLComment.Location = New System.Drawing.Point(16, 253)
        Me.txtGLComment.MaxLength = 200
        Me.txtGLComment.Multiline = True
        Me.txtGLComment.Name = "txtGLComment"
        Me.txtGLComment.Size = New System.Drawing.Size(290, 78)
        Me.txtGLComment.TabIndex = 7
        Me.txtGLComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ReversalCheckBox
        '
        Me.ReversalCheckBox.AutoSize = True
        Me.ReversalCheckBox.Location = New System.Drawing.Point(17, 142)
        Me.ReversalCheckBox.Name = "ReversalCheckBox"
        Me.ReversalCheckBox.Size = New System.Drawing.Size(92, 17)
        Me.ReversalCheckBox.TabIndex = 5
        Me.ReversalCheckBox.Text = "Post Reversal"
        Me.ReversalCheckBox.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 230)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(290, 20)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Comment (200 characters Max)"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(115, 20)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Journal ID"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboJournalID
        '
        Me.cboJournalID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboJournalID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboJournalID.DataSource = Me.GLJournalsBindingSource
        Me.cboJournalID.DisplayMember = "GLJournalID"
        Me.cboJournalID.FormattingEnabled = True
        Me.cboJournalID.Location = New System.Drawing.Point(134, 111)
        Me.cboJournalID.Name = "cboJournalID"
        Me.cboJournalID.Size = New System.Drawing.Size(172, 21)
        Me.cboJournalID.TabIndex = 4
        '
        'GLJournalsBindingSource
        '
        Me.GLJournalsBindingSource.DataMember = "GLJournals"
        Me.GLJournalsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 20)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Posting Date"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpPostingDate
        '
        Me.dtpPostingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPostingDate.Location = New System.Drawing.Point(134, 80)
        Me.dtpPostingDate.Name = "dtpPostingDate"
        Me.dtpPostingDate.Size = New System.Drawing.Size(172, 20)
        Me.dtpPostingDate.TabIndex = 3
        '
        'cmdGenerateTransactionNumber
        '
        Me.cmdGenerateTransactionNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateTransactionNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateTransactionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateTransactionNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateTransactionNumber.Location = New System.Drawing.Point(103, 51)
        Me.cmdGenerateTransactionNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateTransactionNumber.Name = "cmdGenerateTransactionNumber"
        Me.cmdGenerateTransactionNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateTransactionNumber.TabIndex = 1
        Me.cmdGenerateTransactionNumber.Text = ">>"
        Me.cmdGenerateTransactionNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateTransactionNumber.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(14, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(293, 20)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "GL Account Description"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGLAccountDescription
        '
        Me.txtGLAccountDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLAccountDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGLAccountDescription.Location = New System.Drawing.Point(17, 98)
        Me.txtGLAccountDescription.Multiline = True
        Me.txtGLAccountDescription.Name = "txtGLAccountDescription"
        Me.txtGLAccountDescription.Size = New System.Drawing.Size(290, 35)
        Me.txtGLAccountDescription.TabIndex = 10
        Me.txtGLAccountDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCreditAmount
        '
        Me.txtCreditAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreditAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCreditAmount.Location = New System.Drawing.Point(135, 165)
        Me.txtCreditAmount.Name = "txtCreditAmount"
        Me.txtCreditAmount.Size = New System.Drawing.Size(172, 20)
        Me.txtCreditAmount.TabIndex = 12
        Me.txtCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGLTransactionDescription
        '
        Me.txtGLTransactionDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLTransactionDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGLTransactionDescription.Location = New System.Drawing.Point(17, 229)
        Me.txtGLTransactionDescription.MaxLength = 200
        Me.txtGLTransactionDescription.Multiline = True
        Me.txtGLTransactionDescription.Name = "txtGLTransactionDescription"
        Me.txtGLTransactionDescription.Size = New System.Drawing.Size(290, 106)
        Me.txtGLTransactionDescription.TabIndex = 13
        Me.txtGLTransactionDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDebitAmount
        '
        Me.txtDebitAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDebitAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDebitAmount.Location = New System.Drawing.Point(135, 139)
        Me.txtDebitAmount.Name = "txtDebitAmount"
        Me.txtDebitAmount.Size = New System.Drawing.Size(172, 20)
        Me.txtDebitAmount.TabIndex = 11
        Me.txtDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(14, 206)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(293, 20)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Transaction Description (200 characters Max)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(14, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 20)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Credit Amount"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(14, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 20)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "GL Account"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(14, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 20)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Debit Amount"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearTransaction
        '
        Me.cmdClearTransaction.Location = New System.Drawing.Point(236, 347)
        Me.cmdClearTransaction.Name = "cmdClearTransaction"
        Me.cmdClearTransaction.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearTransaction.TabIndex = 15
        Me.cmdClearTransaction.Text = "Clear"
        Me.cmdClearTransaction.UseVisualStyleBackColor = True
        '
        'cmdEnterTransaction
        '
        Me.cmdEnterTransaction.Location = New System.Drawing.Point(159, 347)
        Me.cmdEnterTransaction.Name = "cmdEnterTransaction"
        Me.cmdEnterTransaction.Size = New System.Drawing.Size(71, 40)
        Me.cmdEnterTransaction.TabIndex = 14
        Me.cmdEnterTransaction.Text = "Enter"
        Me.cmdEnterTransaction.UseVisualStyleBackColor = True
        '
        'gpxTransactionDetails
        '
        Me.gpxTransactionDetails.Controls.Add(Me.cboGLAccount)
        Me.gpxTransactionDetails.Controls.Add(Me.cboShortDescription)
        Me.gpxTransactionDetails.Controls.Add(Me.Label3)
        Me.gpxTransactionDetails.Controls.Add(Me.Label2)
        Me.gpxTransactionDetails.Controls.Add(Me.Label6)
        Me.gpxTransactionDetails.Controls.Add(Me.Label4)
        Me.gpxTransactionDetails.Controls.Add(Me.Label5)
        Me.gpxTransactionDetails.Controls.Add(Me.txtGLAccountDescription)
        Me.gpxTransactionDetails.Controls.Add(Me.cmdClearTransaction)
        Me.gpxTransactionDetails.Controls.Add(Me.txtDebitAmount)
        Me.gpxTransactionDetails.Controls.Add(Me.txtGLTransactionDescription)
        Me.gpxTransactionDetails.Controls.Add(Me.cmdEnterTransaction)
        Me.gpxTransactionDetails.Controls.Add(Me.txtCreditAmount)
        Me.gpxTransactionDetails.Location = New System.Drawing.Point(29, 408)
        Me.gpxTransactionDetails.Name = "gpxTransactionDetails"
        Me.gpxTransactionDetails.Size = New System.Drawing.Size(323, 403)
        Me.gpxTransactionDetails.TabIndex = 8
        Me.gpxTransactionDetails.TabStop = False
        Me.gpxTransactionDetails.Text = "Transaction Details"
        '
        'cboGLAccount
        '
        Me.cboGLAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGLAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLAccount.DataSource = Me.GLAccountsBindingSource
        Me.cboGLAccount.DisplayMember = "GLAccountNumber"
        Me.cboGLAccount.FormattingEnabled = True
        Me.cboGLAccount.Location = New System.Drawing.Point(135, 19)
        Me.cboGLAccount.Name = "cboGLAccount"
        Me.cboGLAccount.Size = New System.Drawing.Size(172, 21)
        Me.cboGLAccount.TabIndex = 8
        '
        'GLAccountsBindingSource
        '
        Me.GLAccountsBindingSource.DataMember = "GLAccounts"
        Me.GLAccountsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboShortDescription
        '
        Me.cboShortDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShortDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShortDescription.DataSource = Me.GLAccountsBindingSource
        Me.cboShortDescription.DisplayMember = "GLAccountShortDescription"
        Me.cboShortDescription.FormattingEnabled = True
        Me.cboShortDescription.Location = New System.Drawing.Point(17, 46)
        Me.cboShortDescription.Name = "cboShortDescription"
        Me.cboShortDescription.Size = New System.Drawing.Size(290, 21)
        Me.cboShortDescription.TabIndex = 9
        '
        'gpxPostTransactions
        '
        Me.gpxPostTransactions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxPostTransactions.Controls.Add(Me.chkAdminControl)
        Me.gpxPostTransactions.Controls.Add(Me.cmdPostTransactions)
        Me.gpxPostTransactions.Controls.Add(Me.Label10)
        Me.gpxPostTransactions.Location = New System.Drawing.Point(728, 561)
        Me.gpxPostTransactions.Name = "gpxPostTransactions"
        Me.gpxPostTransactions.Size = New System.Drawing.Size(302, 149)
        Me.gpxPostTransactions.TabIndex = 23
        Me.gpxPostTransactions.TabStop = False
        Me.gpxPostTransactions.Text = "Post Transactions"
        '
        'chkAdminControl
        '
        Me.chkAdminControl.AutoSize = True
        Me.chkAdminControl.Enabled = False
        Me.chkAdminControl.ForeColor = System.Drawing.Color.Blue
        Me.chkAdminControl.Location = New System.Drawing.Point(18, 111)
        Me.chkAdminControl.Name = "chkAdminControl"
        Me.chkAdminControl.Size = New System.Drawing.Size(91, 17)
        Me.chkAdminControl.TabIndex = 32
        Me.chkAdminControl.Text = "Admin Control"
        Me.chkAdminControl.UseVisualStyleBackColor = True
        '
        'cmdPostTransactions
        '
        Me.cmdPostTransactions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPostTransactions.ForeColor = System.Drawing.Color.Blue
        Me.cmdPostTransactions.Location = New System.Drawing.Point(214, 98)
        Me.cmdPostTransactions.Name = "cmdPostTransactions"
        Me.cmdPostTransactions.Size = New System.Drawing.Size(71, 40)
        Me.cmdPostTransactions.TabIndex = 23
        Me.cmdPostTransactions.Text = "Post"
        Me.cmdPostTransactions.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(15, 36)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(270, 59)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "All transactions in batch will be POSTED to the ledger. Make sure Batch is balanc" & _
            "ed and all line entries are correct before POSTING."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxBatchBalance
        '
        Me.gpxBatchBalance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxBatchBalance.Controls.Add(Me.txtBatchBalance)
        Me.gpxBatchBalance.Controls.Add(Me.txtBatchStatus)
        Me.gpxBatchBalance.Controls.Add(Me.Label14)
        Me.gpxBatchBalance.Controls.Add(Me.txtCreditTotal)
        Me.gpxBatchBalance.Controls.Add(Me.txtDebitTotal)
        Me.gpxBatchBalance.Controls.Add(Me.Label13)
        Me.gpxBatchBalance.Controls.Add(Me.Label12)
        Me.gpxBatchBalance.Controls.Add(Me.Label11)
        Me.gpxBatchBalance.Location = New System.Drawing.Point(372, 676)
        Me.gpxBatchBalance.Name = "gpxBatchBalance"
        Me.gpxBatchBalance.Size = New System.Drawing.Size(323, 135)
        Me.gpxBatchBalance.TabIndex = 19
        Me.gpxBatchBalance.TabStop = False
        Me.gpxBatchBalance.Text = "Batch Totals and Balance"
        '
        'txtBatchBalance
        '
        Me.txtBatchBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchBalance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchBalance.Location = New System.Drawing.Point(161, 99)
        Me.txtBatchBalance.Name = "txtBatchBalance"
        Me.txtBatchBalance.Size = New System.Drawing.Size(144, 20)
        Me.txtBatchBalance.TabIndex = 22
        Me.txtBatchBalance.TabStop = False
        Me.txtBatchBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBatchStatus
        '
        Me.txtBatchStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchStatus.Enabled = False
        Me.txtBatchStatus.Location = New System.Drawing.Point(161, 21)
        Me.txtBatchStatus.Name = "txtBatchStatus"
        Me.txtBatchStatus.Size = New System.Drawing.Size(144, 20)
        Me.txtBatchStatus.TabIndex = 19
        Me.txtBatchStatus.TabStop = False
        Me.txtBatchStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(8, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(161, 20)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Batch Status"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCreditTotal
        '
        Me.txtCreditTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreditTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCreditTotal.Location = New System.Drawing.Point(161, 73)
        Me.txtCreditTotal.Name = "txtCreditTotal"
        Me.txtCreditTotal.Size = New System.Drawing.Size(144, 20)
        Me.txtCreditTotal.TabIndex = 21
        Me.txtCreditTotal.TabStop = False
        Me.txtCreditTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDebitTotal
        '
        Me.txtDebitTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDebitTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDebitTotal.Location = New System.Drawing.Point(161, 47)
        Me.txtDebitTotal.Name = "txtDebitTotal"
        Me.txtDebitTotal.Size = New System.Drawing.Size(144, 20)
        Me.txtDebitTotal.TabIndex = 20
        Me.txtDebitTotal.TabStop = False
        Me.txtDebitTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 99)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(161, 20)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Batch Balance"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(8, 73)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(161, 20)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Batch Credit Total"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(161, 20)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Batch Debit Total"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(728, 725)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 24
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'GLJournalsTableAdapter
        '
        Me.GLJournalsTableAdapter.ClearBeforeFill = True
        '
        'GLAccountsTableAdapter
        '
        Me.GLAccountsTableAdapter.ClearBeforeFill = True
        '
        'dgvJournalTransactions
        '
        Me.dgvJournalTransactions.AllowUserToAddRows = False
        Me.dgvJournalTransactions.AllowUserToDeleteRows = False
        Me.dgvJournalTransactions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvJournalTransactions.AutoGenerateColumns = False
        Me.dgvJournalTransactions.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvJournalTransactions.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvJournalTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvJournalTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GLJournalTransactionNumberColumn, Me.GLAccountNumberColumn, Me.GLAccountDescriptionColumn, Me.GLDebitAmountColumn, Me.GLCreditAmountColumn, Me.JournalTransactionDescriptionColumn, Me.GLBatchNumberColumn})
        Me.dgvJournalTransactions.DataSource = Me.GLJournalLineTableBindingSource
        Me.dgvJournalTransactions.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvJournalTransactions.Location = New System.Drawing.Point(372, 27)
        Me.dgvJournalTransactions.Name = "dgvJournalTransactions"
        Me.dgvJournalTransactions.Size = New System.Drawing.Size(658, 528)
        Me.dgvJournalTransactions.TabIndex = 30
        Me.dgvJournalTransactions.TabStop = False
        '
        'GLJournalTransactionNumberColumn
        '
        Me.GLJournalTransactionNumberColumn.DataPropertyName = "GLJournalTransactionNumber"
        Me.GLJournalTransactionNumberColumn.HeaderText = "Transaction #"
        Me.GLJournalTransactionNumberColumn.Name = "GLJournalTransactionNumberColumn"
        '
        'GLAccountNumberColumn
        '
        Me.GLAccountNumberColumn.DataPropertyName = "GLAccountNumber"
        Me.GLAccountNumberColumn.HeaderText = "Account #"
        Me.GLAccountNumberColumn.Name = "GLAccountNumberColumn"
        '
        'GLAccountDescriptionColumn
        '
        Me.GLAccountDescriptionColumn.DataPropertyName = "GLAccountDescription"
        Me.GLAccountDescriptionColumn.HeaderText = "Account Description"
        Me.GLAccountDescriptionColumn.Name = "GLAccountDescriptionColumn"
        '
        'GLDebitAmountColumn
        '
        Me.GLDebitAmountColumn.DataPropertyName = "GLDebitAmount"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.GLDebitAmountColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.GLDebitAmountColumn.HeaderText = "Debit Amount"
        Me.GLDebitAmountColumn.Name = "GLDebitAmountColumn"
        '
        'GLCreditAmountColumn
        '
        Me.GLCreditAmountColumn.DataPropertyName = "GLCreditAmount"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.GLCreditAmountColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.GLCreditAmountColumn.HeaderText = "Credit Amount"
        Me.GLCreditAmountColumn.Name = "GLCreditAmountColumn"
        '
        'JournalTransactionDescriptionColumn
        '
        Me.JournalTransactionDescriptionColumn.DataPropertyName = "JournalTransactionDescription"
        Me.JournalTransactionDescriptionColumn.HeaderText = "Transaction Description"
        Me.JournalTransactionDescriptionColumn.Name = "JournalTransactionDescriptionColumn"
        '
        'GLBatchNumberColumn
        '
        Me.GLBatchNumberColumn.DataPropertyName = "GLBatchNumber"
        Me.GLBatchNumberColumn.HeaderText = "GLBatchNumber"
        Me.GLBatchNumberColumn.Name = "GLBatchNumberColumn"
        Me.GLBatchNumberColumn.Visible = False
        '
        'GLJournalLineTableBindingSource
        '
        Me.GLJournalLineTableBindingSource.DataMember = "GLJournalLineTable"
        Me.GLJournalLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'GLJournalHeaderTableTableAdapter
        '
        Me.GLJournalHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'gpxDeleteLines
        '
        Me.gpxDeleteLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxDeleteLines.Controls.Add(Me.Label15)
        Me.gpxDeleteLines.Controls.Add(Me.cmdDeleteTransactionLine)
        Me.gpxDeleteLines.Controls.Add(Me.Label1)
        Me.gpxDeleteLines.Controls.Add(Me.cboDeleteLines)
        Me.gpxDeleteLines.Location = New System.Drawing.Point(372, 561)
        Me.gpxDeleteLines.Name = "gpxDeleteLines"
        Me.gpxDeleteLines.Size = New System.Drawing.Size(323, 109)
        Me.gpxDeleteLines.TabIndex = 16
        Me.gpxDeleteLines.TabStop = False
        Me.gpxDeleteLines.Text = "Delete Lines"
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(26, 55)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(202, 40)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Select line in Grid or Drop down box to delete from batch."
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteTransactionLine
        '
        Me.cmdDeleteTransactionLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteTransactionLine.Location = New System.Drawing.Point(234, 55)
        Me.cmdDeleteTransactionLine.Name = "cmdDeleteTransactionLine"
        Me.cmdDeleteTransactionLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteTransactionLine.TabIndex = 18
        Me.cmdDeleteTransactionLine.Text = "Delete Line"
        Me.cmdDeleteTransactionLine.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Transaction #"
        '
        'cboDeleteLines
        '
        Me.cboDeleteLines.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDeleteLines.DataSource = Me.GLJournalLineTableBindingSource
        Me.cboDeleteLines.DisplayMember = "GLJournalTransactionNumber"
        Me.cboDeleteLines.FormattingEnabled = True
        Me.cboDeleteLines.Location = New System.Drawing.Point(118, 25)
        Me.cboDeleteLines.Name = "cboDeleteLines"
        Me.cboDeleteLines.Size = New System.Drawing.Size(187, 21)
        Me.cboDeleteLines.TabIndex = 17
        '
        'GLJournalLineTableTableAdapter
        '
        Me.GLJournalLineTableTableAdapter.ClearBeforeFill = True
        '
        'GLJournalTransactions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.gpxDeleteLines)
        Me.Controls.Add(Me.dgvJournalTransactions)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.gpxBatchBalance)
        Me.Controls.Add(Me.gpxPostTransactions)
        Me.Controls.Add(Me.gpxTransactionDetails)
        Me.Controls.Add(Me.gpxJournalTransaction)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "GLJournalTransactions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation GL Journal Transactions"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxJournalTransaction.ResumeLayout(False)
        Me.gpxJournalTransaction.PerformLayout()
        CType(Me.GLJournalHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLJournalsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxTransactionDetails.ResumeLayout(False)
        Me.gpxTransactionDetails.PerformLayout()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxPostTransactions.ResumeLayout(False)
        Me.gpxPostTransactions.PerformLayout()
        Me.gpxBatchBalance.ResumeLayout(False)
        Me.gpxBatchBalance.PerformLayout()
        CType(Me.dgvJournalTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLJournalLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxDeleteLines.ResumeLayout(False)
        Me.gpxDeleteLines.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblMachineHours As System.Windows.Forms.Label
    Friend WithEvents lblSetupHours As System.Windows.Forms.Label
    Friend WithEvents gpxJournalTransaction As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdGenerateTransactionNumber As System.Windows.Forms.Button
    Friend WithEvents cmdClearTransaction As System.Windows.Forms.Button
    Friend WithEvents cmdEnterTransaction As System.Windows.Forms.Button
    Friend WithEvents txtGLTransactionDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtGLAccountDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtCreditAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtDebitAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpPostingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents gpxTransactionDetails As System.Windows.Forms.GroupBox
    Friend WithEvents gpxPostTransactions As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPostTransactions As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboJournalID As System.Windows.Forms.ComboBox
    Friend WithEvents txtGLComment As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents gpxBatchBalance As System.Windows.Forms.GroupBox
    Friend WithEvents txtCreditTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtDebitTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboShortDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboGLAccount As System.Windows.Forms.ComboBox
    Friend WithEvents SaveBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboGLBatchNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents txtBatchStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtBatchBalance As System.Windows.Forms.TextBox
    Friend WithEvents DTPReversalDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ReversalCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents GLJournalsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLJournalsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalsTableAdapter
    Friend WithEvents GLAccountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
    Friend WithEvents dgvJournalTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents GLJournalHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLJournalHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalHeaderTableTableAdapter
    Friend WithEvents gpxDeleteLines As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDeleteLines As System.Windows.Forms.ComboBox
    Friend WithEvents cmdDeleteTransactionLine As System.Windows.Forms.Button
    Friend WithEvents GLJournalTransactionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDebitAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCreditAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JournalTransactionDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLBatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLJournalLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLJournalLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalLineTableTableAdapter
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents SelectTemplateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteMultipleLinesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdminControlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkAdminControl As System.Windows.Forms.CheckBox
End Class
