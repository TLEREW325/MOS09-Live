<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SteelReceivingCoilsPopup
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvCoilLines = New System.Windows.Forms.DataGridView
        Me.SteelReceivingHeaderKeyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReceivingLineKeyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CoilIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CoilWeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POLineNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCostPerPoundDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelExtendedAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReceivingCoilLinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.SteelReceivingCoilLinesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingCoilLinesTableAdapter
        Me.lblRMID = New System.Windows.Forms.Label
        Me.lblReceiverNumber = New System.Windows.Forms.Label
        CType(Me.dgvCoilLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelReceivingCoilLinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(281, 353)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 30)
        Me.cmdExit.TabIndex = 0
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvCoilLines
        '
        Me.dgvCoilLines.AllowUserToAddRows = False
        Me.dgvCoilLines.AllowUserToDeleteRows = False
        Me.dgvCoilLines.AutoGenerateColumns = False
        Me.dgvCoilLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvCoilLines.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCoilLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCoilLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SteelReceivingHeaderKeyDataGridViewTextBoxColumn, Me.SteelReceivingLineKeyDataGridViewTextBoxColumn, Me.CoilIDDataGridViewTextBoxColumn, Me.CoilWeightDataGridViewTextBoxColumn, Me.HeatNumberDataGridViewTextBoxColumn, Me.PONumberDataGridViewTextBoxColumn, Me.POLineNumberDataGridViewTextBoxColumn, Me.SteelCostPerPoundDataGridViewTextBoxColumn, Me.SteelExtendedAmountDataGridViewTextBoxColumn})
        Me.dgvCoilLines.DataSource = Me.SteelReceivingCoilLinesBindingSource
        Me.dgvCoilLines.Location = New System.Drawing.Point(12, 21)
        Me.dgvCoilLines.Name = "dgvCoilLines"
        Me.dgvCoilLines.Size = New System.Drawing.Size(344, 293)
        Me.dgvCoilLines.TabIndex = 1
        '
        'SteelReceivingHeaderKeyDataGridViewTextBoxColumn
        '
        Me.SteelReceivingHeaderKeyDataGridViewTextBoxColumn.DataPropertyName = "SteelReceivingHeaderKey"
        Me.SteelReceivingHeaderKeyDataGridViewTextBoxColumn.HeaderText = "SteelReceivingHeaderKey"
        Me.SteelReceivingHeaderKeyDataGridViewTextBoxColumn.Name = "SteelReceivingHeaderKeyDataGridViewTextBoxColumn"
        Me.SteelReceivingHeaderKeyDataGridViewTextBoxColumn.Visible = False
        '
        'SteelReceivingLineKeyDataGridViewTextBoxColumn
        '
        Me.SteelReceivingLineKeyDataGridViewTextBoxColumn.DataPropertyName = "SteelReceivingLineKey"
        Me.SteelReceivingLineKeyDataGridViewTextBoxColumn.HeaderText = "SteelReceivingLineKey"
        Me.SteelReceivingLineKeyDataGridViewTextBoxColumn.Name = "SteelReceivingLineKeyDataGridViewTextBoxColumn"
        Me.SteelReceivingLineKeyDataGridViewTextBoxColumn.Visible = False
        '
        'CoilIDDataGridViewTextBoxColumn
        '
        Me.CoilIDDataGridViewTextBoxColumn.DataPropertyName = "CoilID"
        Me.CoilIDDataGridViewTextBoxColumn.HeaderText = "Coil ID"
        Me.CoilIDDataGridViewTextBoxColumn.Name = "CoilIDDataGridViewTextBoxColumn"
        '
        'CoilWeightDataGridViewTextBoxColumn
        '
        Me.CoilWeightDataGridViewTextBoxColumn.DataPropertyName = "CoilWeight"
        Me.CoilWeightDataGridViewTextBoxColumn.HeaderText = "Weight"
        Me.CoilWeightDataGridViewTextBoxColumn.Name = "CoilWeightDataGridViewTextBoxColumn"
        Me.CoilWeightDataGridViewTextBoxColumn.Width = 80
        '
        'HeatNumberDataGridViewTextBoxColumn
        '
        Me.HeatNumberDataGridViewTextBoxColumn.DataPropertyName = "HeatNumber"
        Me.HeatNumberDataGridViewTextBoxColumn.HeaderText = "Heat #"
        Me.HeatNumberDataGridViewTextBoxColumn.Name = "HeatNumberDataGridViewTextBoxColumn"
        '
        'PONumberDataGridViewTextBoxColumn
        '
        Me.PONumberDataGridViewTextBoxColumn.DataPropertyName = "PONumber"
        Me.PONumberDataGridViewTextBoxColumn.HeaderText = "PONumber"
        Me.PONumberDataGridViewTextBoxColumn.Name = "PONumberDataGridViewTextBoxColumn"
        Me.PONumberDataGridViewTextBoxColumn.Visible = False
        '
        'POLineNumberDataGridViewTextBoxColumn
        '
        Me.POLineNumberDataGridViewTextBoxColumn.DataPropertyName = "POLineNumber"
        Me.POLineNumberDataGridViewTextBoxColumn.HeaderText = "POLineNumber"
        Me.POLineNumberDataGridViewTextBoxColumn.Name = "POLineNumberDataGridViewTextBoxColumn"
        Me.POLineNumberDataGridViewTextBoxColumn.Visible = False
        '
        'SteelCostPerPoundDataGridViewTextBoxColumn
        '
        Me.SteelCostPerPoundDataGridViewTextBoxColumn.DataPropertyName = "SteelCostPerPound"
        Me.SteelCostPerPoundDataGridViewTextBoxColumn.HeaderText = "SteelCostPerPound"
        Me.SteelCostPerPoundDataGridViewTextBoxColumn.Name = "SteelCostPerPoundDataGridViewTextBoxColumn"
        Me.SteelCostPerPoundDataGridViewTextBoxColumn.Visible = False
        '
        'SteelExtendedAmountDataGridViewTextBoxColumn
        '
        Me.SteelExtendedAmountDataGridViewTextBoxColumn.DataPropertyName = "SteelExtendedAmount"
        Me.SteelExtendedAmountDataGridViewTextBoxColumn.HeaderText = "SteelExtendedAmount"
        Me.SteelExtendedAmountDataGridViewTextBoxColumn.Name = "SteelExtendedAmountDataGridViewTextBoxColumn"
        Me.SteelExtendedAmountDataGridViewTextBoxColumn.Visible = False
        '
        'SteelReceivingCoilLinesBindingSource
        '
        Me.SteelReceivingCoilLinesBindingSource.DataMember = "SteelReceivingCoilLines"
        Me.SteelReceivingCoilLinesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SteelReceivingCoilLinesTableAdapter
        '
        Me.SteelReceivingCoilLinesTableAdapter.ClearBeforeFill = True
        '
        'lblRMID
        '
        Me.lblRMID.ForeColor = System.Drawing.Color.Blue
        Me.lblRMID.Location = New System.Drawing.Point(12, 353)
        Me.lblRMID.Name = "lblRMID"
        Me.lblRMID.Size = New System.Drawing.Size(263, 33)
        Me.lblRMID.TabIndex = 2
        Me.lblRMID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReceiverNumber
        '
        Me.lblReceiverNumber.Location = New System.Drawing.Point(12, 317)
        Me.lblReceiverNumber.Name = "lblReceiverNumber"
        Me.lblReceiverNumber.Size = New System.Drawing.Size(344, 23)
        Me.lblReceiverNumber.TabIndex = 3
        '
        'SteelReceivingCoilsPopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 395)
        Me.Controls.Add(Me.lblReceiverNumber)
        Me.Controls.Add(Me.lblRMID)
        Me.Controls.Add(Me.dgvCoilLines)
        Me.Controls.Add(Me.cmdExit)
        Me.Name = "SteelReceivingCoilsPopup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Steel Coils"
        CType(Me.dgvCoilLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelReceivingCoilLinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvCoilLines As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents SteelReceivingCoilLinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelReceivingCoilLinesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingCoilLinesTableAdapter
    Friend WithEvents SteelReceivingHeaderKeyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReceivingLineKeyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoilIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoilWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POLineNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCostPerPoundDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelExtendedAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblRMID As System.Windows.Forms.Label
    Friend WithEvents lblReceiverNumber As System.Windows.Forms.Label
End Class
