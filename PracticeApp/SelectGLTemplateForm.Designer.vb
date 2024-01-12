<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectGLTemplateForm
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
        Me.dgvSelectTemplateLines = New System.Windows.Forms.DataGridView
        Me.GLTemplateNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLDebitAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLCreditAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLJournalTemplateLinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.GLJournalTemplateLinesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalTemplateLinesTableAdapter
        Me.cboTemplateName = New System.Windows.Forms.ComboBox
        Me.GLJournalTemplateHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdClearTransaction = New System.Windows.Forms.Button
        Me.cmdLoadTemplate = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GLJournalTemplateHeaderTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalTemplateHeaderTableAdapter
        CType(Me.dgvSelectTemplateLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLJournalTemplateLinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLJournalTemplateHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvSelectTemplateLines
        '
        Me.dgvSelectTemplateLines.AllowUserToAddRows = False
        Me.dgvSelectTemplateLines.AllowUserToDeleteRows = False
        Me.dgvSelectTemplateLines.AutoGenerateColumns = False
        Me.dgvSelectTemplateLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSelectTemplateLines.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSelectTemplateLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSelectTemplateLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GLTemplateNameColumn, Me.GLLineNumberColumn, Me.GLAccountNumberColumn, Me.GLDebitAmountColumn, Me.GLCreditAmountColumn, Me.GLTransactionDescriptionColumn})
        Me.dgvSelectTemplateLines.DataSource = Me.GLJournalTemplateLinesBindingSource
        Me.dgvSelectTemplateLines.GridColor = System.Drawing.Color.Coral
        Me.dgvSelectTemplateLines.Location = New System.Drawing.Point(12, 12)
        Me.dgvSelectTemplateLines.Name = "dgvSelectTemplateLines"
        Me.dgvSelectTemplateLines.ReadOnly = True
        Me.dgvSelectTemplateLines.Size = New System.Drawing.Size(633, 306)
        Me.dgvSelectTemplateLines.TabIndex = 0
        '
        'GLTemplateNameColumn
        '
        Me.GLTemplateNameColumn.DataPropertyName = "GLTemplateName"
        Me.GLTemplateNameColumn.HeaderText = "GLTemplateName"
        Me.GLTemplateNameColumn.Name = "GLTemplateNameColumn"
        Me.GLTemplateNameColumn.ReadOnly = True
        Me.GLTemplateNameColumn.Visible = False
        '
        'GLLineNumberColumn
        '
        Me.GLLineNumberColumn.DataPropertyName = "GLLineNumber"
        Me.GLLineNumberColumn.HeaderText = "Line #"
        Me.GLLineNumberColumn.Name = "GLLineNumberColumn"
        Me.GLLineNumberColumn.ReadOnly = True
        Me.GLLineNumberColumn.Width = 65
        '
        'GLAccountNumberColumn
        '
        Me.GLAccountNumberColumn.DataPropertyName = "GLAccountNumber"
        Me.GLAccountNumberColumn.HeaderText = "Account Number"
        Me.GLAccountNumberColumn.Name = "GLAccountNumberColumn"
        Me.GLAccountNumberColumn.ReadOnly = True
        '
        'GLDebitAmountColumn
        '
        Me.GLDebitAmountColumn.DataPropertyName = "GLDebitAmount"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.GLDebitAmountColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.GLDebitAmountColumn.HeaderText = "Debit Amount"
        Me.GLDebitAmountColumn.Name = "GLDebitAmountColumn"
        Me.GLDebitAmountColumn.ReadOnly = True
        '
        'GLCreditAmountColumn
        '
        Me.GLCreditAmountColumn.DataPropertyName = "GLCreditAmount"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.GLCreditAmountColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.GLCreditAmountColumn.HeaderText = "Credit Amount"
        Me.GLCreditAmountColumn.Name = "GLCreditAmountColumn"
        Me.GLCreditAmountColumn.ReadOnly = True
        '
        'GLTransactionDescriptionColumn
        '
        Me.GLTransactionDescriptionColumn.DataPropertyName = "GLTransactionDescription"
        Me.GLTransactionDescriptionColumn.HeaderText = "Description"
        Me.GLTransactionDescriptionColumn.Name = "GLTransactionDescriptionColumn"
        Me.GLTransactionDescriptionColumn.ReadOnly = True
        Me.GLTransactionDescriptionColumn.Width = 220
        '
        'GLJournalTemplateLinesBindingSource
        '
        Me.GLJournalTemplateLinesBindingSource.DataMember = "GLJournalTemplateLines"
        Me.GLJournalTemplateLinesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GLJournalTemplateLinesTableAdapter
        '
        Me.GLJournalTemplateLinesTableAdapter.ClearBeforeFill = True
        '
        'cboTemplateName
        '
        Me.cboTemplateName.DataSource = Me.GLJournalTemplateHeaderBindingSource
        Me.cboTemplateName.DisplayMember = "TemplateName"
        Me.cboTemplateName.FormattingEnabled = True
        Me.cboTemplateName.Location = New System.Drawing.Point(164, 337)
        Me.cboTemplateName.Name = "cboTemplateName"
        Me.cboTemplateName.Size = New System.Drawing.Size(183, 21)
        Me.cboTemplateName.TabIndex = 1
        '
        'GLJournalTemplateHeaderBindingSource
        '
        Me.GLJournalTemplateHeaderBindingSource.DataMember = "GLJournalTemplateHeader"
        Me.GLJournalTemplateHeaderBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdClearTransaction
        '
        Me.cmdClearTransaction.Location = New System.Drawing.Point(574, 326)
        Me.cmdClearTransaction.Name = "cmdClearTransaction"
        Me.cmdClearTransaction.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearTransaction.TabIndex = 17
        Me.cmdClearTransaction.Text = "Exit"
        Me.cmdClearTransaction.UseVisualStyleBackColor = True
        '
        'cmdLoadTemplate
        '
        Me.cmdLoadTemplate.Location = New System.Drawing.Point(497, 326)
        Me.cmdLoadTemplate.Name = "cmdLoadTemplate"
        Me.cmdLoadTemplate.Size = New System.Drawing.Size(71, 40)
        Me.cmdLoadTemplate.TabIndex = 16
        Me.cmdLoadTemplate.Text = "Load Template"
        Me.cmdLoadTemplate.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 340)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Select Template Name"
        '
        'GLJournalTemplateHeaderTableAdapter
        '
        Me.GLJournalTemplateHeaderTableAdapter.ClearBeforeFill = True
        '
        'SelectGLTemplateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 378)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdClearTransaction)
        Me.Controls.Add(Me.cmdLoadTemplate)
        Me.Controls.Add(Me.cboTemplateName)
        Me.Controls.Add(Me.dgvSelectTemplateLines)
        Me.Name = "SelectGLTemplateForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Select Template"
        CType(Me.dgvSelectTemplateLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLJournalTemplateLinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLJournalTemplateHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvSelectTemplateLines As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents GLJournalTemplateLinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLJournalTemplateLinesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalTemplateLinesTableAdapter
    Friend WithEvents GLTemplateNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDebitAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCreditAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboTemplateName As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClearTransaction As System.Windows.Forms.Button
    Friend WithEvents cmdLoadTemplate As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GLJournalTemplateHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLJournalTemplateHeaderTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalTemplateHeaderTableAdapter
End Class
