<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewMillCertPopup
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
        Me.cboHeatNumber = New System.Windows.Forms.ComboBox
        Me.HeatNumberLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.HeatNumberLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
        Me.cmdViewFiles = New System.Windows.Forms.Button
        Me.cmdUploadMillCert = New System.Windows.Forms.Button
        Me.cmdLoadMillCert = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvMillCerts = New System.Windows.Forms.DataGridView
        Me.VendorColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FilenameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cboSteelVendor = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.ofdUploadMillCert = New System.Windows.Forms.OpenFileDialog
        Me.txtSteelDiameter = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMillCerts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboHeatNumber
        '
        Me.cboHeatNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHeatNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHeatNumber.DataSource = Me.HeatNumberLogBindingSource
        Me.cboHeatNumber.DisplayMember = "HeatNumber"
        Me.cboHeatNumber.FormattingEnabled = True
        Me.cboHeatNumber.Location = New System.Drawing.Point(123, 60)
        Me.cboHeatNumber.Name = "cboHeatNumber"
        Me.cboHeatNumber.Size = New System.Drawing.Size(230, 21)
        Me.cboHeatNumber.TabIndex = 1
        '
        'HeatNumberLogBindingSource
        '
        Me.HeatNumberLogBindingSource.DataMember = "HeatNumberLog"
        Me.HeatNumberLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'HeatNumberLogTableAdapter
        '
        Me.HeatNumberLogTableAdapter.ClearBeforeFill = True
        '
        'cmdViewFiles
        '
        Me.cmdViewFiles.Location = New System.Drawing.Point(400, 52)
        Me.cmdViewFiles.Name = "cmdViewFiles"
        Me.cmdViewFiles.Size = New System.Drawing.Size(78, 30)
        Me.cmdViewFiles.TabIndex = 3
        Me.cmdViewFiles.Text = "View"
        Me.cmdViewFiles.UseVisualStyleBackColor = True
        '
        'cmdUploadMillCert
        '
        Me.cmdUploadMillCert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdUploadMillCert.Location = New System.Drawing.Point(94, 671)
        Me.cmdUploadMillCert.Name = "cmdUploadMillCert"
        Me.cmdUploadMillCert.Size = New System.Drawing.Size(71, 40)
        Me.cmdUploadMillCert.TabIndex = 6
        Me.cmdUploadMillCert.Text = "Upload Mill Cert"
        Me.cmdUploadMillCert.UseVisualStyleBackColor = True
        '
        'cmdLoadMillCert
        '
        Me.cmdLoadMillCert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLoadMillCert.Location = New System.Drawing.Point(17, 671)
        Me.cmdLoadMillCert.Name = "cmdLoadMillCert"
        Me.cmdLoadMillCert.Size = New System.Drawing.Size(71, 40)
        Me.cmdLoadMillCert.TabIndex = 5
        Me.cmdLoadMillCert.Text = "Load Mill Cert"
        Me.cmdLoadMillCert.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(325, 671)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 7
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(402, 671)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 8
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvMillCerts
        '
        Me.dgvMillCerts.AllowUserToAddRows = False
        Me.dgvMillCerts.AllowUserToDeleteRows = False
        Me.dgvMillCerts.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvMillCerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMillCerts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VendorColumn, Me.FilenameColumn})
        Me.dgvMillCerts.GridColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dgvMillCerts.Location = New System.Drawing.Point(14, 157)
        Me.dgvMillCerts.Name = "dgvMillCerts"
        Me.dgvMillCerts.ReadOnly = True
        Me.dgvMillCerts.Size = New System.Drawing.Size(462, 461)
        Me.dgvMillCerts.TabIndex = 4
        '
        'VendorColumn
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VendorColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.VendorColumn.HeaderText = "Steel Vendor"
        Me.VendorColumn.Name = "VendorColumn"
        Me.VendorColumn.ReadOnly = True
        Me.VendorColumn.Width = 200
        '
        'FilenameColumn
        '
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FilenameColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.FilenameColumn.HeaderText = "Filename"
        Me.FilenameColumn.Name = "FilenameColumn"
        Me.FilenameColumn.ReadOnly = True
        Me.FilenameColumn.Width = 200
        '
        'cboSteelVendor
        '
        Me.cboSteelVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelVendor.DataSource = Me.VendorBindingSource
        Me.cboSteelVendor.DisplayMember = "VendorCode"
        Me.cboSteelVendor.FormattingEnabled = True
        Me.cboSteelVendor.Location = New System.Drawing.Point(123, 20)
        Me.cboSteelVendor.Name = "cboSteelVendor"
        Me.cboSteelVendor.Size = New System.Drawing.Size(230, 21)
        Me.cboSteelVendor.TabIndex = 0
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(22, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 23)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Steel Vendor"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(22, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 23)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Heat #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(14, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(459, 23)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Select correct heat/diameter in datagrid and press Load Mill Cert (or double-clic" & _
            "k in datagrid)."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'ofdUploadMillCert
        '
        Me.ofdUploadMillCert.FileName = "Select File"
        Me.ofdUploadMillCert.Filter = "PDF Files|*.pdf|All Files|*.*"
        '
        'txtSteelDiameter
        '
        Me.txtSteelDiameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelDiameter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelDiameter.Location = New System.Drawing.Point(218, 100)
        Me.txtSteelDiameter.Name = "txtSteelDiameter"
        Me.txtSteelDiameter.Size = New System.Drawing.Size(135, 20)
        Me.txtSteelDiameter.TabIndex = 2
        Me.txtSteelDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(22, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 23)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Steel Size / Diameter"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewMillCertPopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 723)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSteelDiameter)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboSteelVendor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvMillCerts)
        Me.Controls.Add(Me.cmdUploadMillCert)
        Me.Controls.Add(Me.cmdLoadMillCert)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdViewFiles)
        Me.Controls.Add(Me.cboHeatNumber)
        Me.Name = "ViewMillCertPopup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation View Mill Cert"
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMillCerts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboHeatNumber As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents HeatNumberLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HeatNumberLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
    Friend WithEvents cmdViewFiles As System.Windows.Forms.Button
    Friend WithEvents cmdUploadMillCert As System.Windows.Forms.Button
    Friend WithEvents cmdLoadMillCert As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvMillCerts As System.Windows.Forms.DataGridView
    Friend WithEvents VendorColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FilenameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboSteelVendor As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents ofdUploadMillCert As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtSteelDiameter As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
