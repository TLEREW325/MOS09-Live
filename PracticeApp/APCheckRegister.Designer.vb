<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class APCheckRegister
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.dgvAPCheckLog = New System.Windows.Forms.DataGridView
        Me.VendorIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APBatchNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APCheckLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.APCheckLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APCheckLogTableAdapter
        CType(Me.dgvAPCheckLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APCheckLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(574, 326)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 30
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Location = New System.Drawing.Point(497, 326)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 33
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'dgvAPCheckLog
        '
        Me.dgvAPCheckLog.AllowUserToAddRows = False
        Me.dgvAPCheckLog.AllowUserToDeleteRows = False
        Me.dgvAPCheckLog.AutoGenerateColumns = False
        Me.dgvAPCheckLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAPCheckLog.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAPCheckLog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAPCheckLog.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAPCheckLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAPCheckLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VendorIDDataGridViewTextBoxColumn, Me.CheckNumberDataGridViewTextBoxColumn, Me.CheckAmountDataGridViewTextBoxColumn, Me.CheckDateDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn, Me.APBatchNumberDataGridViewTextBoxColumn, Me.CheckStatusDataGridViewTextBoxColumn})
        Me.dgvAPCheckLog.DataSource = Me.APCheckLogBindingSource
        Me.dgvAPCheckLog.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvAPCheckLog.Location = New System.Drawing.Point(12, 12)
        Me.dgvAPCheckLog.Name = "dgvAPCheckLog"
        Me.dgvAPCheckLog.Size = New System.Drawing.Size(633, 297)
        Me.dgvAPCheckLog.TabIndex = 34
        '
        'VendorIDDataGridViewTextBoxColumn
        '
        Me.VendorIDDataGridViewTextBoxColumn.DataPropertyName = "VendorID"
        Me.VendorIDDataGridViewTextBoxColumn.HeaderText = "Vendor ID"
        Me.VendorIDDataGridViewTextBoxColumn.Name = "VendorIDDataGridViewTextBoxColumn"
        '
        'CheckNumberDataGridViewTextBoxColumn
        '
        Me.CheckNumberDataGridViewTextBoxColumn.DataPropertyName = "CheckNumber"
        Me.CheckNumberDataGridViewTextBoxColumn.HeaderText = "Check #"
        Me.CheckNumberDataGridViewTextBoxColumn.Name = "CheckNumberDataGridViewTextBoxColumn"
        '
        'CheckAmountDataGridViewTextBoxColumn
        '
        Me.CheckAmountDataGridViewTextBoxColumn.DataPropertyName = "CheckAmount"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.CheckAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.CheckAmountDataGridViewTextBoxColumn.HeaderText = "Check Amount"
        Me.CheckAmountDataGridViewTextBoxColumn.Name = "CheckAmountDataGridViewTextBoxColumn"
        '
        'CheckDateDataGridViewTextBoxColumn
        '
        Me.CheckDateDataGridViewTextBoxColumn.DataPropertyName = "CheckDate"
        Me.CheckDateDataGridViewTextBoxColumn.HeaderText = "Check Date"
        Me.CheckDateDataGridViewTextBoxColumn.Name = "CheckDateDataGridViewTextBoxColumn"
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.Visible = False
        '
        'APBatchNumberDataGridViewTextBoxColumn
        '
        Me.APBatchNumberDataGridViewTextBoxColumn.DataPropertyName = "APBatchNumber"
        Me.APBatchNumberDataGridViewTextBoxColumn.HeaderText = "APBatchNumber"
        Me.APBatchNumberDataGridViewTextBoxColumn.Name = "APBatchNumberDataGridViewTextBoxColumn"
        Me.APBatchNumberDataGridViewTextBoxColumn.Visible = False
        '
        'CheckStatusDataGridViewTextBoxColumn
        '
        Me.CheckStatusDataGridViewTextBoxColumn.DataPropertyName = "CheckStatus"
        Me.CheckStatusDataGridViewTextBoxColumn.HeaderText = "CheckStatus"
        Me.CheckStatusDataGridViewTextBoxColumn.Name = "CheckStatusDataGridViewTextBoxColumn"
        Me.CheckStatusDataGridViewTextBoxColumn.Visible = False
        '
        'APCheckLogBindingSource
        '
        Me.APCheckLogBindingSource.DataMember = "APCheckLog"
        Me.APCheckLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'APCheckLogTableAdapter
        '
        Me.APCheckLogTableAdapter.ClearBeforeFill = True
        '
        'APCheckRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 378)
        Me.Controls.Add(Me.dgvAPCheckLog)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Name = "APCheckRegister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation AP Check Register"
        CType(Me.dgvAPCheckLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APCheckLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents VoucherNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents dgvAPCheckLog As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents APCheckLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents APCheckLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APCheckLogTableAdapter
    Friend WithEvents VendorIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APBatchNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
