<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewUploadedSaltSprayInspections
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtLotNumber = New System.Windows.Forms.TextBox
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdLoadReport = New System.Windows.Forms.Button
        Me.cmdUploadSaltSpray = New System.Windows.Forms.Button
        Me.ofdSaltSpray = New System.Windows.Forms.OpenFileDialog
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.LotNumberBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LotNumberTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgvSaltSpray = New System.Windows.Forms.DataGridView
        Me.CustomerColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FilenameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSaltSpray, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(123, 20)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(230, 21)
        Me.cboCustomerID.TabIndex = 0
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
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(22, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Customer"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(407, 671)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 7
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(330, 671)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 6
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(22, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "FOX # / Lot #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLotNumber
        '
        Me.txtLotNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLotNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLotNumber.Location = New System.Drawing.Point(123, 60)
        Me.txtLotNumber.Name = "txtLotNumber"
        Me.txtLotNumber.Size = New System.Drawing.Size(230, 20)
        Me.txtLotNumber.TabIndex = 1
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(400, 52)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(78, 30)
        Me.cmdView.TabIndex = 2
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdLoadReport
        '
        Me.cmdLoadReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLoadReport.Location = New System.Drawing.Point(22, 671)
        Me.cmdLoadReport.Name = "cmdLoadReport"
        Me.cmdLoadReport.Size = New System.Drawing.Size(71, 40)
        Me.cmdLoadReport.TabIndex = 4
        Me.cmdLoadReport.Text = "Load Report"
        Me.cmdLoadReport.UseVisualStyleBackColor = True
        '
        'cmdUploadSaltSpray
        '
        Me.cmdUploadSaltSpray.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdUploadSaltSpray.Location = New System.Drawing.Point(99, 671)
        Me.cmdUploadSaltSpray.Name = "cmdUploadSaltSpray"
        Me.cmdUploadSaltSpray.Size = New System.Drawing.Size(71, 40)
        Me.cmdUploadSaltSpray.TabIndex = 5
        Me.cmdUploadSaltSpray.Text = "Upload Salt Spray"
        Me.cmdUploadSaltSpray.UseVisualStyleBackColor = True
        '
        'ofdSaltSpray
        '
        Me.ofdSaltSpray.FileName = "Salt Spray File"
        Me.ofdSaltSpray.Filter = "PDF Files|*.pdf|All Files|*.*"
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'LotNumberBindingSource
        '
        Me.LotNumberBindingSource.DataMember = "LotNumber"
        Me.LotNumberBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'LotNumberTableAdapter
        '
        Me.LotNumberTableAdapter.ClearBeforeFill = True
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(21, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(459, 23)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "To upload a new salt spray inspection, type in a customer and lot # and press upl" & _
            "oad."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvSaltSpray
        '
        Me.dgvSaltSpray.AllowUserToAddRows = False
        Me.dgvSaltSpray.AllowUserToDeleteRows = False
        Me.dgvSaltSpray.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSaltSpray.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSaltSpray.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerColumn, Me.FilenameColumn})
        Me.dgvSaltSpray.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvSaltSpray.Location = New System.Drawing.Point(22, 134)
        Me.dgvSaltSpray.Name = "dgvSaltSpray"
        Me.dgvSaltSpray.Size = New System.Drawing.Size(456, 519)
        Me.dgvSaltSpray.TabIndex = 3
        '
        'CustomerColumn
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomerColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.CustomerColumn.HeaderText = "Customer"
        Me.CustomerColumn.Name = "CustomerColumn"
        Me.CustomerColumn.Width = 200
        '
        'FilenameColumn
        '
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FilenameColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.FilenameColumn.HeaderText = "Filename"
        Me.FilenameColumn.Name = "FilenameColumn"
        Me.FilenameColumn.Width = 200
        '
        'ViewUploadedSaltSprayInspections
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 723)
        Me.Controls.Add(Me.dgvSaltSpray)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdUploadSaltSpray)
        Me.Controls.Add(Me.cmdLoadReport)
        Me.Controls.Add(Me.cmdView)
        Me.Controls.Add(Me.txtLotNumber)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cboCustomerID)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ViewUploadedSaltSprayInspections"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation View Salt Spray Inspections"
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSaltSpray, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LotNumberBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LotNumberTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLotNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdLoadReport As System.Windows.Forms.Button
    Friend WithEvents cmdUploadSaltSpray As System.Windows.Forms.Button
    Friend WithEvents ofdSaltSpray As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvSaltSpray As System.Windows.Forms.DataGridView
    Friend WithEvents CustomerColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FilenameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
