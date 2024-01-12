<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectSteelPOLines
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.cmdSaveLines = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.dgvSteelReceivingLines = New System.Windows.Forms.DataGridView
        Me.SteelReceivingLineQuery2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SteelReceivingLineQuery2TableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingLineQuery2TableAdapter
        Me.SelectForInvoicing = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.SteelBOLNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReceivingHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReceivingLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiveWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelUnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarbonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelVendorColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectForInvoiceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSteelReceivingLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelReceivingLineQuery2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(89, 321)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 15
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectAll.Location = New System.Drawing.Point(12, 321)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectAll.TabIndex = 14
        Me.cmdSelectAll.Text = "Check All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'cmdSaveLines
        '
        Me.cmdSaveLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSaveLines.Location = New System.Drawing.Point(582, 321)
        Me.cmdSaveLines.Name = "cmdSaveLines"
        Me.cmdSaveLines.Size = New System.Drawing.Size(71, 40)
        Me.cmdSaveLines.TabIndex = 17
        Me.cmdSaveLines.Text = "Process For Receipt"
        Me.cmdSaveLines.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(659, 321)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 16
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dgvSteelReceivingLines
        '
        Me.dgvSteelReceivingLines.AllowUserToAddRows = False
        Me.dgvSteelReceivingLines.AllowUserToDeleteRows = False
        Me.dgvSteelReceivingLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSteelReceivingLines.AutoGenerateColumns = False
        Me.dgvSteelReceivingLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelReceivingLines.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSteelReceivingLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSteelReceivingLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelReceivingLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectForInvoicing, Me.SteelBOLNumberColumn, Me.SteelReceivingHeaderKeyColumn, Me.SteelReceivingLineKeyColumn, Me.RMIDColumn, Me.ReceiveWeightColumn, Me.SteelUnitCostColumn, Me.SteelExtendedCostColumn, Me.ReceivingDateColumn, Me.LineStatusColumn, Me.LineCommentColumn, Me.CarbonColumn, Me.SteelSizeColumn, Me.DebitGLAccountColumn, Me.CreditGLAccountColumn, Me.SteelVendorColumn, Me.ReceivingStatusColumn, Me.DivisionIDColumn, Me.SelectForInvoiceColumn})
        Me.dgvSteelReceivingLines.DataSource = Me.SteelReceivingLineQuery2BindingSource
        Me.dgvSteelReceivingLines.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgvSteelReceivingLines.Location = New System.Drawing.Point(12, 12)
        Me.dgvSteelReceivingLines.Name = "dgvSteelReceivingLines"
        Me.dgvSteelReceivingLines.Size = New System.Drawing.Size(718, 303)
        Me.dgvSteelReceivingLines.TabIndex = 18
        '
        'SteelReceivingLineQuery2BindingSource
        '
        Me.SteelReceivingLineQuery2BindingSource.DataMember = "SteelReceivingLineQuery2"
        Me.SteelReceivingLineQuery2BindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SteelReceivingLineQuery2TableAdapter
        '
        Me.SteelReceivingLineQuery2TableAdapter.ClearBeforeFill = True
        '
        'SelectForInvoicing
        '
        Me.SelectForInvoicing.FalseValue = "UNSELECTED"
        Me.SelectForInvoicing.HeaderText = "Select"
        Me.SelectForInvoicing.Name = "SelectForInvoicing"
        Me.SelectForInvoicing.TrueValue = "SELECTED"
        Me.SelectForInvoicing.Width = 50
        '
        'SteelBOLNumberColumn
        '
        Me.SteelBOLNumberColumn.DataPropertyName = "SteelBOLNumber"
        Me.SteelBOLNumberColumn.HeaderText = "BOL #"
        Me.SteelBOLNumberColumn.Name = "SteelBOLNumberColumn"
        '
        'SteelReceivingHeaderKeyColumn
        '
        Me.SteelReceivingHeaderKeyColumn.DataPropertyName = "SteelReceivingHeaderKey"
        Me.SteelReceivingHeaderKeyColumn.HeaderText = "Receiver #"
        Me.SteelReceivingHeaderKeyColumn.Name = "SteelReceivingHeaderKeyColumn"
        Me.SteelReceivingHeaderKeyColumn.Width = 80
        '
        'SteelReceivingLineKeyColumn
        '
        Me.SteelReceivingLineKeyColumn.DataPropertyName = "SteelReceivingLineKey"
        Me.SteelReceivingLineKeyColumn.HeaderText = "Line #"
        Me.SteelReceivingLineKeyColumn.Name = "SteelReceivingLineKeyColumn"
        Me.SteelReceivingLineKeyColumn.Width = 65
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        '
        'ReceiveWeightColumn
        '
        Me.ReceiveWeightColumn.DataPropertyName = "ReceiveWeight"
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = "0"
        Me.ReceiveWeightColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.ReceiveWeightColumn.HeaderText = "Weight"
        Me.ReceiveWeightColumn.Name = "ReceiveWeightColumn"
        Me.ReceiveWeightColumn.Width = 90
        '
        'SteelUnitCostColumn
        '
        Me.SteelUnitCostColumn.DataPropertyName = "SteelUnitCost"
        DataGridViewCellStyle2.Format = "N5"
        DataGridViewCellStyle2.NullValue = "0"
        Me.SteelUnitCostColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.SteelUnitCostColumn.HeaderText = "Unit Cost"
        Me.SteelUnitCostColumn.Name = "SteelUnitCostColumn"
        Me.SteelUnitCostColumn.ReadOnly = True
        Me.SteelUnitCostColumn.Width = 90
        '
        'SteelExtendedCostColumn
        '
        Me.SteelExtendedCostColumn.DataPropertyName = "SteelExtendedCost"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.SteelExtendedCostColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.SteelExtendedCostColumn.HeaderText = "Ext. Amt."
        Me.SteelExtendedCostColumn.Name = "SteelExtendedCostColumn"
        Me.SteelExtendedCostColumn.Width = 90
        '
        'ReceivingDateColumn
        '
        Me.ReceivingDateColumn.DataPropertyName = "ReceivingDate"
        Me.ReceivingDateColumn.HeaderText = "Receiving Date"
        Me.ReceivingDateColumn.Name = "ReceivingDateColumn"
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "Line Status"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        '
        'CarbonColumn
        '
        Me.CarbonColumn.DataPropertyName = "Carbon"
        Me.CarbonColumn.HeaderText = "Carbon"
        Me.CarbonColumn.Name = "CarbonColumn"
        '
        'SteelSizeColumn
        '
        Me.SteelSizeColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn.HeaderText = "Steel Size"
        Me.SteelSizeColumn.Name = "SteelSizeColumn"
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "DebitGLAccount"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        Me.DebitGLAccountColumn.Visible = False
        '
        'CreditGLAccountColumn
        '
        Me.CreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumn.HeaderText = "CreditGLAccount"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
        Me.CreditGLAccountColumn.Visible = False
        '
        'SteelVendorColumn
        '
        Me.SteelVendorColumn.DataPropertyName = "SteelVendor"
        Me.SteelVendorColumn.HeaderText = "SteelVendor"
        Me.SteelVendorColumn.Name = "SteelVendorColumn"
        Me.SteelVendorColumn.Visible = False
        '
        'ReceivingStatusColumn
        '
        Me.ReceivingStatusColumn.DataPropertyName = "ReceivingStatus"
        Me.ReceivingStatusColumn.HeaderText = "ReceivingStatus"
        Me.ReceivingStatusColumn.Name = "ReceivingStatusColumn"
        Me.ReceivingStatusColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'SelectForInvoiceColumn
        '
        Me.SelectForInvoiceColumn.DataPropertyName = "SelectForInvoice"
        Me.SelectForInvoiceColumn.HeaderText = "SelectForInvoice"
        Me.SelectForInvoiceColumn.Name = "SelectForInvoiceColumn"
        Me.SelectForInvoiceColumn.Visible = False
        '
        'SelectSteelPOLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 373)
        Me.Controls.Add(Me.dgvSteelReceivingLines)
        Me.Controls.Add(Me.cmdSaveLines)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Name = "SelectSteelPOLines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Steel PO Lines"
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSteelReceivingLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelReceivingLineQuery2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdSaveLines As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents dgvSteelReceivingLines As System.Windows.Forms.DataGridView
    Friend WithEvents SteelReceivingLineQuery2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelReceivingLineQuery2TableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingLineQuery2TableAdapter
    Friend WithEvents SelectForInvoicing As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SteelBOLNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReceivingHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReceivingLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiveWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelUnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelVendorColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForInvoiceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
