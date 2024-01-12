<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewUploadedOutsideCerts
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdViewFiles = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboLotNumber = New System.Windows.Forms.ComboBox
        Me.LotNumberBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.LotNumberTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
        Me.dgvViewCerts = New System.Windows.Forms.DataGridView
        Me.FilenameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdLoadCert = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdUploadCert = New System.Windows.Forms.Button
        Me.ofdUploadCert = New System.Windows.Forms.OpenFileDialog
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvViewCerts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(15, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(372, 38)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "After datagrid is populated, select the correct Lot # and Press Load Cert (or dou" & _
            "ble-click line in datagrid)."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewFiles
        '
        Me.cmdViewFiles.Location = New System.Drawing.Point(405, 101)
        Me.cmdViewFiles.Name = "cmdViewFiles"
        Me.cmdViewFiles.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewFiles.TabIndex = 1
        Me.cmdViewFiles.Text = "View"
        Me.cmdViewFiles.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 23)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Lot Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLotNumber
        '
        Me.cboLotNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLotNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLotNumber.DataSource = Me.LotNumberBindingSource
        Me.cboLotNumber.DisplayMember = "LotNumber"
        Me.cboLotNumber.FormattingEnabled = True
        Me.cboLotNumber.Location = New System.Drawing.Point(99, 37)
        Me.cboLotNumber.Name = "cboLotNumber"
        Me.cboLotNumber.Size = New System.Drawing.Size(256, 21)
        Me.cboLotNumber.TabIndex = 0
        '
        'LotNumberBindingSource
        '
        Me.LotNumberBindingSource.DataMember = "LotNumber"
        Me.LotNumberBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LotNumberTableAdapter
        '
        Me.LotNumberTableAdapter.ClearBeforeFill = True
        '
        'dgvViewCerts
        '
        Me.dgvViewCerts.AllowUserToAddRows = False
        Me.dgvViewCerts.AllowUserToDeleteRows = False
        Me.dgvViewCerts.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvViewCerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvViewCerts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FilenameColumn})
        Me.dgvViewCerts.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvViewCerts.Location = New System.Drawing.Point(14, 157)
        Me.dgvViewCerts.Name = "dgvViewCerts"
        Me.dgvViewCerts.Size = New System.Drawing.Size(462, 461)
        Me.dgvViewCerts.TabIndex = 2
        '
        'FilenameColumn
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FilenameColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.FilenameColumn.HeaderText = "File Name"
        Me.FilenameColumn.Name = "FilenameColumn"
        Me.FilenameColumn.Width = 400
        '
        'cmdLoadCert
        '
        Me.cmdLoadCert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLoadCert.Location = New System.Drawing.Point(16, 671)
        Me.cmdLoadCert.Name = "cmdLoadCert"
        Me.cmdLoadCert.Size = New System.Drawing.Size(71, 40)
        Me.cmdLoadCert.TabIndex = 3
        Me.cmdLoadCert.Text = "Load Cert"
        Me.cmdLoadCert.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(330, 671)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(407, 671)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 6
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdUploadCert
        '
        Me.cmdUploadCert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdUploadCert.Location = New System.Drawing.Point(93, 671)
        Me.cmdUploadCert.Name = "cmdUploadCert"
        Me.cmdUploadCert.Size = New System.Drawing.Size(71, 40)
        Me.cmdUploadCert.TabIndex = 4
        Me.cmdUploadCert.Text = "Upload Cert"
        Me.cmdUploadCert.UseVisualStyleBackColor = True
        '
        'ofdUploadCert
        '
        Me.ofdUploadCert.FileName = "Select File"
        Me.ofdUploadCert.Filter = "PDF Files|*.pdf|All Files|*.*"
        '
        'ViewUploadedOutsideCerts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 723)
        Me.Controls.Add(Me.cmdUploadCert)
        Me.Controls.Add(Me.cmdLoadCert)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvViewCerts)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdViewFiles)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboLotNumber)
        Me.Name = "ViewUploadedOutsideCerts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation View Vendor Certs"
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvViewCerts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdViewFiles As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboLotNumber As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents LotNumberBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LotNumberTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
    Friend WithEvents dgvViewCerts As System.Windows.Forms.DataGridView
    Friend WithEvents FilenameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdLoadCert As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdUploadCert As System.Windows.Forms.Button
    Friend WithEvents ofdUploadCert As System.Windows.Forms.OpenFileDialog
End Class
