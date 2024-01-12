<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemMaintenanceFoxProcesses
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
        Me.dgvFoxProcesses = New System.Windows.Forms.DataGridView
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.FoxSchedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FoxSchedTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FoxSchedTableAdapter
        Me.FOXNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProcessStepDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProcessIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProcessRemoveRMDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProcessAddFGDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdExit = New System.Windows.Forms.Button
        CType(Me.dgvFoxProcesses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FoxSchedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvFoxProcesses
        '
        Me.dgvFoxProcesses.AllowUserToAddRows = False
        Me.dgvFoxProcesses.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvFoxProcesses.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFoxProcesses.AutoGenerateColumns = False
        Me.dgvFoxProcesses.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvFoxProcesses.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvFoxProcesses.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvFoxProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFoxProcesses.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FOXNumberDataGridViewTextBoxColumn, Me.ProcessStepDataGridViewTextBoxColumn, Me.ProcessIDDataGridViewTextBoxColumn, Me.ProcessRemoveRMDataGridViewTextBoxColumn, Me.ProcessAddFGDataGridViewTextBoxColumn})
        Me.dgvFoxProcesses.DataSource = Me.FoxSchedBindingSource
        Me.dgvFoxProcesses.GridColor = System.Drawing.Color.Blue
        Me.dgvFoxProcesses.Location = New System.Drawing.Point(27, 12)
        Me.dgvFoxProcesses.Name = "dgvFoxProcesses"
        Me.dgvFoxProcesses.Size = New System.Drawing.Size(453, 199)
        Me.dgvFoxProcesses.TabIndex = 0
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FoxSchedBindingSource
        '
        Me.FoxSchedBindingSource.DataMember = "FoxSched"
        Me.FoxSchedBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'FoxSchedTableAdapter
        '
        Me.FoxSchedTableAdapter.ClearBeforeFill = True
        '
        'FOXNumberDataGridViewTextBoxColumn
        '
        Me.FOXNumberDataGridViewTextBoxColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberDataGridViewTextBoxColumn.HeaderText = "FOXNumber"
        Me.FOXNumberDataGridViewTextBoxColumn.Name = "FOXNumberDataGridViewTextBoxColumn"
        Me.FOXNumberDataGridViewTextBoxColumn.Visible = False
        '
        'ProcessStepDataGridViewTextBoxColumn
        '
        Me.ProcessStepDataGridViewTextBoxColumn.DataPropertyName = "ProcessStep"
        Me.ProcessStepDataGridViewTextBoxColumn.HeaderText = "Process Step"
        Me.ProcessStepDataGridViewTextBoxColumn.Name = "ProcessStepDataGridViewTextBoxColumn"
        '
        'ProcessIDDataGridViewTextBoxColumn
        '
        Me.ProcessIDDataGridViewTextBoxColumn.DataPropertyName = "ProcessID"
        Me.ProcessIDDataGridViewTextBoxColumn.HeaderText = "Process ID"
        Me.ProcessIDDataGridViewTextBoxColumn.Name = "ProcessIDDataGridViewTextBoxColumn"
        Me.ProcessIDDataGridViewTextBoxColumn.Width = 200
        '
        'ProcessRemoveRMDataGridViewTextBoxColumn
        '
        Me.ProcessRemoveRMDataGridViewTextBoxColumn.DataPropertyName = "ProcessRemoveRM"
        Me.ProcessRemoveRMDataGridViewTextBoxColumn.HeaderText = "ProcessRemoveRM"
        Me.ProcessRemoveRMDataGridViewTextBoxColumn.Name = "ProcessRemoveRMDataGridViewTextBoxColumn"
        Me.ProcessRemoveRMDataGridViewTextBoxColumn.Visible = False
        '
        'ProcessAddFGDataGridViewTextBoxColumn
        '
        Me.ProcessAddFGDataGridViewTextBoxColumn.DataPropertyName = "ProcessAddFG"
        Me.ProcessAddFGDataGridViewTextBoxColumn.HeaderText = "Add to FG?"
        Me.ProcessAddFGDataGridViewTextBoxColumn.Name = "ProcessAddFGDataGridViewTextBoxColumn"
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(409, 231)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 30)
        Me.cmdExit.TabIndex = 1
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'ItemMaintenanceFoxProcesses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 273)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvFoxProcesses)
        Me.Name = "ItemMaintenanceFoxProcesses"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FOX Processes"
        CType(Me.dgvFoxProcesses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FoxSchedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvFoxProcesses As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents FoxSchedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FoxSchedTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FoxSchedTableAdapter
    Friend WithEvents FOXNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessStepDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessRemoveRMDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessAddFGDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdExit As System.Windows.Forms.Button
End Class
