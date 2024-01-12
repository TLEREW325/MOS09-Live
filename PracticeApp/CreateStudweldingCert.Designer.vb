<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateStudweldingCert
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtpCertDate = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cmdCreate = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTrainerCompany = New System.Windows.Forms.TextBox
        Me.txtTraineeCompany = New System.Windows.Forms.TextBox
        Me.txtTraineeName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtTrainerName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.dgvStudweldingCertificate = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IndividualNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CompanyNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CertificationDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CertificationTrainerColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CertificationCompanyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrintDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StudweldingCertificationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StudweldingCertificationTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StudweldingCertificationTableAdapter
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdPrintMultiple = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvStudweldingCertificate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StudweldingCertificationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem1})
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 22
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 23
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpCertDate)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.cmdCreate)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtTrainerCompany)
        Me.GroupBox1.Controls.Add(Me.txtTraineeCompany)
        Me.GroupBox1.Controls.Add(Me.txtTraineeName)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtTrainerName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(472, 770)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fill in fields to create a stud welding certificate"
        '
        'dtpCertDate
        '
        Me.dtpCertDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCertDate.Location = New System.Drawing.Point(244, 418)
        Me.dtpCertDate.Name = "dtpCertDate"
        Me.dtpCertDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpCertDate.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(23, 119)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(421, 37)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "To create a stud welding certificate, type into all fields exactly how they will " & _
            "appear on the certificate."
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 23)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Division"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(271, 46)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(173, 21)
        Me.cboDivisionID.TabIndex = 1
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmdCreate
        '
        Me.cmdCreate.Location = New System.Drawing.Point(301, 704)
        Me.cmdCreate.Name = "cmdCreate"
        Me.cmdCreate.Size = New System.Drawing.Size(71, 40)
        Me.cmdCreate.TabIndex = 7
        Me.cmdCreate.Text = "Create"
        Me.cmdCreate.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(378, 704)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 8
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(127, 418)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Date of Training"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 575)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(284, 19)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Company Name / Division Name"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTrainerCompany
        '
        Me.txtTrainerCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTrainerCompany.Location = New System.Drawing.Point(23, 594)
        Me.txtTrainerCompany.Name = "txtTrainerCompany"
        Me.txtTrainerCompany.Size = New System.Drawing.Size(428, 20)
        Me.txtTrainerCompany.TabIndex = 6
        Me.txtTrainerCompany.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTraineeCompany
        '
        Me.txtTraineeCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTraineeCompany.Location = New System.Drawing.Point(23, 331)
        Me.txtTraineeCompany.Name = "txtTraineeCompany"
        Me.txtTraineeCompany.Size = New System.Drawing.Size(421, 20)
        Me.txtTraineeCompany.TabIndex = 3
        Me.txtTraineeCompany.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTraineeName
        '
        Me.txtTraineeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTraineeName.Location = New System.Drawing.Point(23, 252)
        Me.txtTraineeName.Name = "txtTraineeName"
        Me.txtTraineeName.Size = New System.Drawing.Size(421, 20)
        Me.txtTraineeName.TabIndex = 2
        Me.txtTraineeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 489)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(374, 23)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Trainer / Truweld Representative"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTrainerName
        '
        Me.txtTrainerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTrainerName.Location = New System.Drawing.Point(23, 515)
        Me.txtTrainerName.Name = "txtTrainerName"
        Me.txtTrainerName.Size = New System.Drawing.Size(428, 20)
        Me.txtTrainerName.TabIndex = 5
        Me.txtTrainerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 226)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(424, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Trainee Name (First/Last - this is how it will appear on the certificate)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 305)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(424, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Company Name of the Trainee"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'dgvStudweldingCertificate
        '
        Me.dgvStudweldingCertificate.AllowUserToAddRows = False
        Me.dgvStudweldingCertificate.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvStudweldingCertificate.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvStudweldingCertificate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvStudweldingCertificate.AutoGenerateColumns = False
        Me.dgvStudweldingCertificate.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvStudweldingCertificate.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvStudweldingCertificate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStudweldingCertificate.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.IndividualNameColumn, Me.CompanyNameColumn, Me.CertificationDateColumn, Me.CertificationTrainerColumn, Me.CertificationCompanyColumn, Me.PrintDateColumn, Me.CommentColumn})
        Me.dgvStudweldingCertificate.DataSource = Me.StudweldingCertificationBindingSource
        Me.dgvStudweldingCertificate.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvStudweldingCertificate.Location = New System.Drawing.Point(526, 41)
        Me.dgvStudweldingCertificate.Name = "dgvStudweldingCertificate"
        Me.dgvStudweldingCertificate.ReadOnly = True
        Me.dgvStudweldingCertificate.Size = New System.Drawing.Size(604, 594)
        Me.dgvStudweldingCertificate.TabIndex = 25
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Width = 65
        '
        'IndividualNameColumn
        '
        Me.IndividualNameColumn.DataPropertyName = "IndividualName"
        Me.IndividualNameColumn.HeaderText = "Trainee Name"
        Me.IndividualNameColumn.Name = "IndividualNameColumn"
        Me.IndividualNameColumn.ReadOnly = True
        Me.IndividualNameColumn.Width = 200
        '
        'CompanyNameColumn
        '
        Me.CompanyNameColumn.DataPropertyName = "CompanyName"
        Me.CompanyNameColumn.HeaderText = "Company Name"
        Me.CompanyNameColumn.Name = "CompanyNameColumn"
        Me.CompanyNameColumn.ReadOnly = True
        Me.CompanyNameColumn.Width = 200
        '
        'CertificationDateColumn
        '
        Me.CertificationDateColumn.DataPropertyName = "CertificationDate"
        Me.CertificationDateColumn.HeaderText = "Certification Date"
        Me.CertificationDateColumn.Name = "CertificationDateColumn"
        Me.CertificationDateColumn.ReadOnly = True
        Me.CertificationDateColumn.Visible = False
        '
        'CertificationTrainerColumn
        '
        Me.CertificationTrainerColumn.DataPropertyName = "CertificationTrainer"
        Me.CertificationTrainerColumn.HeaderText = "Certification Trainer"
        Me.CertificationTrainerColumn.Name = "CertificationTrainerColumn"
        Me.CertificationTrainerColumn.ReadOnly = True
        Me.CertificationTrainerColumn.Visible = False
        '
        'CertificationCompanyColumn
        '
        Me.CertificationCompanyColumn.DataPropertyName = "CertificationCompany"
        Me.CertificationCompanyColumn.HeaderText = "Certification Company"
        Me.CertificationCompanyColumn.Name = "CertificationCompanyColumn"
        Me.CertificationCompanyColumn.ReadOnly = True
        Me.CertificationCompanyColumn.Visible = False
        '
        'PrintDateColumn
        '
        Me.PrintDateColumn.DataPropertyName = "PrintDate"
        Me.PrintDateColumn.HeaderText = "Print Date"
        Me.PrintDateColumn.Name = "PrintDateColumn"
        Me.PrintDateColumn.ReadOnly = True
        Me.PrintDateColumn.Visible = False
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        Me.CommentColumn.ReadOnly = True
        Me.CommentColumn.Visible = False
        '
        'StudweldingCertificationBindingSource
        '
        Me.StudweldingCertificationBindingSource.DataMember = "StudweldingCertification"
        Me.StudweldingCertificationBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'StudweldingCertificationTableAdapter
        '
        Me.StudweldingCertificationTableAdapter.ClearBeforeFill = True
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(523, 651)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(504, 30)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "To reprint an existing stud welding certificate, double click on the selection in" & _
            " the datagrid."
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(905, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 30
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(523, 692)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(501, 19)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "To delete an existing certificate, select it in the datagrid and press delete."
        '
        'cmdPrintMultiple
        '
        Me.cmdPrintMultiple.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintMultiple.ForeColor = System.Drawing.Color.Blue
        Me.cmdPrintMultiple.Location = New System.Drawing.Point(526, 772)
        Me.cmdPrintMultiple.Name = "cmdPrintMultiple"
        Me.cmdPrintMultiple.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintMultiple.TabIndex = 32
        Me.cmdPrintMultiple.Text = "Print Multiple"
        Me.cmdPrintMultiple.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(523, 722)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(501, 37)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "To print/email multiple certificates, hold down control key a select in datagrid " & _
            "and then press ""Print Multiple""."
        '
        'CreateStudweldingCert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmdPrintMultiple)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dgvStudweldingCertificate)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "CreateStudweldingCert"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Create Studwelding Certification"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvStudweldingCertificate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StudweldingCertificationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTraineeCompany As System.Windows.Forms.TextBox
    Friend WithEvents txtTraineeName As System.Windows.Forms.TextBox
    Friend WithEvents cmdCreate As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTrainerCompany As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTrainerName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgvStudweldingCertificate As System.Windows.Forms.DataGridView
    Friend WithEvents StudweldingCertificationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StudweldingCertificationTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StudweldingCertificationTableAdapter
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IndividualNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CompanyNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CertificationDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CertificationTrainerColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CertificationCompanyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpCertDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintMultiple As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
