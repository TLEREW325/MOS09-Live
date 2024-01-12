<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewInspectionReportUploadFiles
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtBlueprintNumber = New System.Windows.Forms.TextBox
        Me.txtRevisionLevel = New System.Windows.Forms.TextBox
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.cmdPrevious = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdUploadFiles = New System.Windows.Forms.Button
        Me.txtFOXNumber = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblTotalFiles = New System.Windows.Forms.Label
        Me.pnlWaitMessage = New System.Windows.Forms.Panel
        Me.lblWaitMessage = New System.Windows.Forms.Label
        Me.picPDF = New System.Windows.Forms.PictureBox
        Me.cmdScan = New System.Windows.Forms.Button
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.lblCustomer = New System.Windows.Forms.Label
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.grpOptions = New System.Windows.Forms.GroupBox
        Me.cmdBackRotate = New System.Windows.Forms.Button
        Me.cmdForwRotate = New System.Windows.Forms.Button
        Me.pnlWaitMessage.SuspendLayout()
        CType(Me.picPDF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 273)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Blueprint Number"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 391)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Revision Level"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 509)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 24)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Date"
        '
        'txtBlueprintNumber
        '
        Me.txtBlueprintNumber.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtBlueprintNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBlueprintNumber.Location = New System.Drawing.Point(170, 274)
        Me.txtBlueprintNumber.MaxLength = 50
        Me.txtBlueprintNumber.Name = "txtBlueprintNumber"
        Me.txtBlueprintNumber.Size = New System.Drawing.Size(104, 22)
        Me.txtBlueprintNumber.TabIndex = 2
        '
        'txtRevisionLevel
        '
        Me.txtRevisionLevel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtRevisionLevel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRevisionLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRevisionLevel.Location = New System.Drawing.Point(148, 392)
        Me.txtRevisionLevel.MaxLength = 5
        Me.txtRevisionLevel.Name = "txtRevisionLevel"
        Me.txtRevisionLevel.Size = New System.Drawing.Size(126, 22)
        Me.txtRevisionLevel.TabIndex = 3
        '
        'dtpDate
        '
        Me.dtpDate.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.dtpDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(142, 510)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(132, 22)
        Me.dtpDate.TabIndex = 4
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Enabled = False
        Me.cmdPrevious.Location = New System.Drawing.Point(53, 582)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrevious.TabIndex = 1
        Me.cmdPrevious.Text = "&Previous"
        Me.cmdPrevious.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.Location = New System.Drawing.Point(184, 582)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(71, 40)
        Me.cmdNext.TabIndex = 2
        Me.cmdNext.Text = "&Next"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdUploadFiles
        '
        Me.cmdUploadFiles.Enabled = False
        Me.cmdUploadFiles.Location = New System.Drawing.Point(184, 658)
        Me.cmdUploadFiles.Name = "cmdUploadFiles"
        Me.cmdUploadFiles.Size = New System.Drawing.Size(71, 40)
        Me.cmdUploadFiles.TabIndex = 4
        Me.cmdUploadFiles.Text = "&Upload Files"
        Me.cmdUploadFiles.UseVisualStyleBackColor = True
        '
        'txtFOXNumber
        '
        Me.txtFOXNumber.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtFOXNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFOXNumber.Location = New System.Drawing.Point(142, 38)
        Me.txtFOXNumber.MaxLength = 8
        Me.txtFOXNumber.Name = "txtFOXNumber"
        Me.txtFOXNumber.Size = New System.Drawing.Size(133, 22)
        Me.txtFOXNumber.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 24)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "FOX Number"
        '
        'lblTotalFiles
        '
        Me.lblTotalFiles.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTotalFiles.Location = New System.Drawing.Point(714, 771)
        Me.lblTotalFiles.Name = "lblTotalFiles"
        Me.lblTotalFiles.Size = New System.Drawing.Size(68, 13)
        Me.lblTotalFiles.TabIndex = 15
        Me.lblTotalFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlWaitMessage
        '
        Me.pnlWaitMessage.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlWaitMessage.Controls.Add(Me.lblWaitMessage)
        Me.pnlWaitMessage.Location = New System.Drawing.Point(334, 315)
        Me.pnlWaitMessage.Name = "pnlWaitMessage"
        Me.pnlWaitMessage.Size = New System.Drawing.Size(448, 100)
        Me.pnlWaitMessage.TabIndex = 16
        Me.pnlWaitMessage.Visible = False
        '
        'lblWaitMessage
        '
        Me.lblWaitMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWaitMessage.ForeColor = System.Drawing.Color.Blue
        Me.lblWaitMessage.Location = New System.Drawing.Point(32, 15)
        Me.lblWaitMessage.Name = "lblWaitMessage"
        Me.lblWaitMessage.Size = New System.Drawing.Size(381, 65)
        Me.lblWaitMessage.TabIndex = 0
        '
        'picPDF
        '
        Me.picPDF.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picPDF.Location = New System.Drawing.Point(309, 12)
        Me.picPDF.Name = "picPDF"
        Me.picPDF.Size = New System.Drawing.Size(813, 787)
        Me.picPDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPDF.TabIndex = 17
        Me.picPDF.TabStop = False
        '
        'cmdScan
        '
        Me.cmdScan.Enabled = False
        Me.cmdScan.Location = New System.Drawing.Point(53, 658)
        Me.cmdScan.Name = "cmdScan"
        Me.cmdScan.Size = New System.Drawing.Size(71, 40)
        Me.cmdScan.TabIndex = 3
        Me.cmdScan.Text = "&Scan Files"
        Me.cmdScan.UseVisualStyleBackColor = True
        '
        'cboCustomerID
        '
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(129, 155)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(145, 24)
        Me.cboCustomerID.TabIndex = 1
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
        'lblCustomer
        '
        Me.lblCustomer.AutoSize = True
        Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomer.Location = New System.Drawing.Point(11, 155)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(113, 24)
        Me.lblCustomer.TabIndex = 20
        Me.lblCustomer.Text = "Customer ID"
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'grpOptions
        '
        Me.grpOptions.Controls.Add(Me.dtpDate)
        Me.grpOptions.Controls.Add(Me.lblCustomer)
        Me.grpOptions.Controls.Add(Me.Label1)
        Me.grpOptions.Controls.Add(Me.cboCustomerID)
        Me.grpOptions.Controls.Add(Me.Label2)
        Me.grpOptions.Controls.Add(Me.txtFOXNumber)
        Me.grpOptions.Controls.Add(Me.Label3)
        Me.grpOptions.Controls.Add(Me.Label4)
        Me.grpOptions.Controls.Add(Me.txtBlueprintNumber)
        Me.grpOptions.Controls.Add(Me.txtRevisionLevel)
        Me.grpOptions.Location = New System.Drawing.Point(13, 13)
        Me.grpOptions.Name = "grpOptions"
        Me.grpOptions.Size = New System.Drawing.Size(281, 563)
        Me.grpOptions.TabIndex = 0
        Me.grpOptions.TabStop = False
        Me.grpOptions.Text = "Options"
        '
        'cmdBackRotate
        '
        Me.cmdBackRotate.Enabled = False
        Me.cmdBackRotate.Location = New System.Drawing.Point(53, 734)
        Me.cmdBackRotate.Name = "cmdBackRotate"
        Me.cmdBackRotate.Size = New System.Drawing.Size(71, 40)
        Me.cmdBackRotate.TabIndex = 5
        Me.cmdBackRotate.Text = "Rotate &Backwards"
        Me.cmdBackRotate.UseVisualStyleBackColor = True
        '
        'cmdForwRotate
        '
        Me.cmdForwRotate.Enabled = False
        Me.cmdForwRotate.Location = New System.Drawing.Point(183, 734)
        Me.cmdForwRotate.Name = "cmdForwRotate"
        Me.cmdForwRotate.Size = New System.Drawing.Size(71, 40)
        Me.cmdForwRotate.TabIndex = 6
        Me.cmdForwRotate.Text = "Rotate &Forwards"
        Me.cmdForwRotate.UseVisualStyleBackColor = True
        '
        'ViewInspectionReportUploadFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 811)
        Me.Controls.Add(Me.cmdForwRotate)
        Me.Controls.Add(Me.cmdBackRotate)
        Me.Controls.Add(Me.grpOptions)
        Me.Controls.Add(Me.cmdScan)
        Me.Controls.Add(Me.pnlWaitMessage)
        Me.Controls.Add(Me.lblTotalFiles)
        Me.Controls.Add(Me.cmdUploadFiles)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdPrevious)
        Me.Controls.Add(Me.picPDF)
        Me.Name = "ViewInspectionReportUploadFiles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inspection Report Upload Files"
        Me.pnlWaitMessage.ResumeLayout(False)
        CType(Me.picPDF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpOptions.ResumeLayout(False)
        Me.grpOptions.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBlueprintNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtRevisionLevel As System.Windows.Forms.TextBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdUploadFiles As System.Windows.Forms.Button
    Friend WithEvents txtFOXNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotalFiles As System.Windows.Forms.Label
    Friend WithEvents pnlWaitMessage As System.Windows.Forms.Panel
    Friend WithEvents lblWaitMessage As System.Windows.Forms.Label
    Friend WithEvents picPDF As System.Windows.Forms.PictureBox
    Friend WithEvents cmdScan As System.Windows.Forms.Button
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents grpOptions As System.Windows.Forms.GroupBox
    Friend WithEvents cmdBackRotate As System.Windows.Forms.Button
    Friend WithEvents cmdForwRotate As System.Windows.Forms.Button
End Class
