<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewUploadedInspectionReport
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
        Me.cmdUploadInspection = New System.Windows.Forms.Button
        Me.cmdLoadReport = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtFOXNumber = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdViewFiles = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtBlueprint = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgvInspectionReports = New System.Windows.Forms.DataGridView
        Me.CustomerColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FilenameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.txtRevisionLevel = New System.Windows.Forms.TextBox
        Me.ofdInspectionReport = New System.Windows.Forms.OpenFileDialog
        Me.Label5 = New System.Windows.Forms.Label
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInspectionReports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdUploadInspection
        '
        Me.cmdUploadInspection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdUploadInspection.Location = New System.Drawing.Point(91, 671)
        Me.cmdUploadInspection.Name = "cmdUploadInspection"
        Me.cmdUploadInspection.Size = New System.Drawing.Size(71, 40)
        Me.cmdUploadInspection.TabIndex = 7
        Me.cmdUploadInspection.Text = "Upload Inspection"
        Me.cmdUploadInspection.UseVisualStyleBackColor = True
        '
        'cmdLoadReport
        '
        Me.cmdLoadReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLoadReport.Location = New System.Drawing.Point(14, 671)
        Me.cmdLoadReport.Name = "cmdLoadReport"
        Me.cmdLoadReport.Size = New System.Drawing.Size(71, 40)
        Me.cmdLoadReport.TabIndex = 6
        Me.cmdLoadReport.Text = "Load Report"
        Me.cmdLoadReport.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(328, 671)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 8
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(405, 671)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 9
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(12, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(459, 23)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "To upload a new inspection sheet, type in a customer and B/P # and press upload."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFOXNumber
        '
        Me.txtFOXNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFOXNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFOXNumber.Location = New System.Drawing.Point(97, 96)
        Me.txtFOXNumber.Name = "txtFOXNumber"
        Me.txtFOXNumber.Size = New System.Drawing.Size(122, 20)
        Me.txtFOXNumber.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "FOX #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewFiles
        '
        Me.cmdViewFiles.Location = New System.Drawing.Point(400, 92)
        Me.cmdViewFiles.Name = "cmdViewFiles"
        Me.cmdViewFiles.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewFiles.TabIndex = 4
        Me.cmdViewFiles.Text = "View"
        Me.cmdViewFiles.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(230, 23)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Customer"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(97, 21)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(252, 21)
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
        'txtBlueprint
        '
        Me.txtBlueprint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBlueprint.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBlueprint.Location = New System.Drawing.Point(97, 59)
        Me.txtBlueprint.Name = "txtBlueprint"
        Me.txtBlueprint.Size = New System.Drawing.Size(176, 20)
        Me.txtBlueprint.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Blueprint #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvInspectionReports
        '
        Me.dgvInspectionReports.AllowUserToAddRows = False
        Me.dgvInspectionReports.AllowUserToDeleteRows = False
        Me.dgvInspectionReports.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInspectionReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInspectionReports.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerColumn, Me.FilenameColumn})
        Me.dgvInspectionReports.GridColor = System.Drawing.Color.Fuchsia
        Me.dgvInspectionReports.Location = New System.Drawing.Point(14, 157)
        Me.dgvInspectionReports.Name = "dgvInspectionReports"
        Me.dgvInspectionReports.Size = New System.Drawing.Size(462, 461)
        Me.dgvInspectionReports.TabIndex = 5
        '
        'CustomerColumn
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomerColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.CustomerColumn.HeaderText = "Customer"
        Me.CustomerColumn.Name = "CustomerColumn"
        Me.CustomerColumn.Width = 200
        '
        'FilenameColumn
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FilenameColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.FilenameColumn.HeaderText = "File Name"
        Me.FilenameColumn.Name = "FilenameColumn"
        Me.FilenameColumn.Width = 200
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'txtRevisionLevel
        '
        Me.txtRevisionLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRevisionLevel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRevisionLevel.Location = New System.Drawing.Point(277, 59)
        Me.txtRevisionLevel.Name = "txtRevisionLevel"
        Me.txtRevisionLevel.Size = New System.Drawing.Size(72, 20)
        Me.txtRevisionLevel.TabIndex = 2
        Me.txtRevisionLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ofdInspectionReport
        '
        Me.ofdInspectionReport.FileName = "Inspection Report"
        Me.ofdInspectionReport.Filter = "PDF Files|*.pdf|All Files|*.*"
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(355, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 58)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Use TW STOCK as customer for weld studs."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ViewUploadedInspectionReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 723)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtRevisionLevel)
        Me.Controls.Add(Me.dgvInspectionReports)
        Me.Controls.Add(Me.txtBlueprint)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFOXNumber)
        Me.Controls.Add(Me.cmdViewFiles)
        Me.Controls.Add(Me.cboCustomerID)
        Me.Controls.Add(Me.cmdUploadInspection)
        Me.Controls.Add(Me.cmdLoadReport)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ViewUploadedInspectionReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation View Inspection Report"
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInspectionReports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdUploadInspection As System.Windows.Forms.Button
    Friend WithEvents cmdLoadReport As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFOXNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdViewFiles As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents txtBlueprint As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvInspectionReports As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents txtRevisionLevel As System.Windows.Forms.TextBox
    Friend WithEvents CustomerColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FilenameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ofdInspectionReport As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
