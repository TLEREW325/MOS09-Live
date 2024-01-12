<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewUploadedSteelBOL
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
        Me.cboHeatNumber = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdViewFiles = New System.Windows.Forms.Button
        Me.dgvSteelBOLS = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdLoadBOL = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.HeatNumberLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HeatNumberLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
        Me.HeatColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvSteelBOLS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboHeatNumber
        '
        Me.cboHeatNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHeatNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHeatNumber.DataSource = Me.HeatNumberLogBindingSource
        Me.cboHeatNumber.DisplayMember = "HeatNumber"
        Me.cboHeatNumber.FormattingEnabled = True
        Me.cboHeatNumber.Location = New System.Drawing.Point(99, 37)
        Me.cboHeatNumber.Name = "cboHeatNumber"
        Me.cboHeatNumber.Size = New System.Drawing.Size(256, 21)
        Me.cboHeatNumber.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 23)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Heat Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewFiles
        '
        Me.cmdViewFiles.Location = New System.Drawing.Point(405, 101)
        Me.cmdViewFiles.Name = "cmdViewFiles"
        Me.cmdViewFiles.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewFiles.TabIndex = 21
        Me.cmdViewFiles.Text = "View"
        Me.cmdViewFiles.UseVisualStyleBackColor = True
        '
        'dgvSteelBOLS
        '
        Me.dgvSteelBOLS.AllowUserToAddRows = False
        Me.dgvSteelBOLS.AllowUserToDeleteRows = False
        Me.dgvSteelBOLS.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelBOLS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelBOLS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.HeatColumn})
        Me.dgvSteelBOLS.GridColor = System.Drawing.Color.Red
        Me.dgvSteelBOLS.Location = New System.Drawing.Point(14, 157)
        Me.dgvSteelBOLS.Name = "dgvSteelBOLS"
        Me.dgvSteelBOLS.ReadOnly = True
        Me.dgvSteelBOLS.Size = New System.Drawing.Size(462, 461)
        Me.dgvSteelBOLS.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(15, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(372, 38)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "After datagrid is populated, select the correct BOL # for the specific heat numbe" & _
            "r and press Load BOL (or double-click line in datagrid)."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdLoadBOL
        '
        Me.cmdLoadBOL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLoadBOL.Location = New System.Drawing.Point(11, 671)
        Me.cmdLoadBOL.Name = "cmdLoadBOL"
        Me.cmdLoadBOL.Size = New System.Drawing.Size(71, 40)
        Me.cmdLoadBOL.TabIndex = 26
        Me.cmdLoadBOL.Text = "Load BOL"
        Me.cmdLoadBOL.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(325, 671)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 28
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(402, 671)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 29
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'HeatNumberLogBindingSource
        '
        Me.HeatNumberLogBindingSource.DataMember = "HeatNumberLog"
        Me.HeatNumberLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'HeatNumberLogTableAdapter
        '
        Me.HeatNumberLogTableAdapter.ClearBeforeFill = True
        '
        'HeatColumn
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeatColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.HeatColumn.HeaderText = "File Name (Heat # + BOL #)"
        Me.HeatColumn.Name = "HeatColumn"
        Me.HeatColumn.ReadOnly = True
        Me.HeatColumn.Width = 400
        '
        'ViewUploadedSteelBOL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 723)
        Me.Controls.Add(Me.cmdLoadBOL)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvSteelBOLS)
        Me.Controls.Add(Me.cmdViewFiles)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboHeatNumber)
        Me.Name = "ViewUploadedSteelBOL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation View Steel BOL"
        CType(Me.dgvSteelBOLS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboHeatNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdViewFiles As System.Windows.Forms.Button
    Friend WithEvents dgvSteelBOLS As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdLoadBOL As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents HeatNumberLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HeatNumberLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
    Friend WithEvents HeatColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
