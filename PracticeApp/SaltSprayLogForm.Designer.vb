<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaltSprayLogForm
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
        Me.dgvSaltSprayLog = New System.Windows.Forms.DataGridView
        Me.SaltSprayIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SaltSprayDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SaltSprayTimeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TemperatureDryColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TemperatureWetColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CentralCollectColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CornerCollectColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PHRangeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TowerTemperatureColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TowerPressureColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SaltSprayLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdAddData = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpLogDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtLogTime = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdAddNew = New System.Windows.Forms.Button
        Me.cboSaltSprayID = New System.Windows.Forms.ComboBox
        Me.txtDivisionID = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtUserID = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtComments = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTowerPressure = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTowerTemperature = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtPHRange = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtCornerCollect = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtCentralCollect = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTemperatureWet = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtTemperatureDry = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.SaltSprayLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SaltSprayLogTableAdapter
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvSaltSprayLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SaltSprayLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.cmdPrint.Enabled = False
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 17
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 18
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvSaltSprayLog
        '
        Me.dgvSaltSprayLog.AllowUserToAddRows = False
        Me.dgvSaltSprayLog.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvSaltSprayLog.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSaltSprayLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSaltSprayLog.AutoGenerateColumns = False
        Me.dgvSaltSprayLog.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSaltSprayLog.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSaltSprayLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSaltSprayLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SaltSprayIDColumn, Me.SaltSprayDateColumn, Me.SaltSprayTimeColumn, Me.TemperatureDryColumn, Me.TemperatureWetColumn, Me.CentralCollectColumn, Me.CornerCollectColumn, Me.PHRangeColumn, Me.TowerTemperatureColumn, Me.TowerPressureColumn, Me.CommentsColumn, Me.DivisionIDColumn, Me.UserIDColumn})
        Me.dgvSaltSprayLog.DataSource = Me.SaltSprayLogBindingSource
        Me.dgvSaltSprayLog.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvSaltSprayLog.Location = New System.Drawing.Point(347, 41)
        Me.dgvSaltSprayLog.Name = "dgvSaltSprayLog"
        Me.dgvSaltSprayLog.Size = New System.Drawing.Size(783, 713)
        Me.dgvSaltSprayLog.TabIndex = 19
        '
        'SaltSprayIDColumn
        '
        Me.SaltSprayIDColumn.DataPropertyName = "SaltSprayID"
        Me.SaltSprayIDColumn.HeaderText = "ID #"
        Me.SaltSprayIDColumn.Name = "SaltSprayIDColumn"
        Me.SaltSprayIDColumn.ReadOnly = True
        Me.SaltSprayIDColumn.Width = 80
        '
        'SaltSprayDateColumn
        '
        Me.SaltSprayDateColumn.DataPropertyName = "SaltSprayDate"
        Me.SaltSprayDateColumn.HeaderText = "Date"
        Me.SaltSprayDateColumn.Name = "SaltSprayDateColumn"
        Me.SaltSprayDateColumn.Width = 80
        '
        'SaltSprayTimeColumn
        '
        Me.SaltSprayTimeColumn.DataPropertyName = "SaltSprayTime"
        Me.SaltSprayTimeColumn.HeaderText = "Time"
        Me.SaltSprayTimeColumn.Name = "SaltSprayTimeColumn"
        Me.SaltSprayTimeColumn.Width = 80
        '
        'TemperatureDryColumn
        '
        Me.TemperatureDryColumn.DataPropertyName = "TemperatureDry"
        Me.TemperatureDryColumn.HeaderText = "Temp/Dry"
        Me.TemperatureDryColumn.Name = "TemperatureDryColumn"
        '
        'TemperatureWetColumn
        '
        Me.TemperatureWetColumn.DataPropertyName = "TemperatureWet"
        Me.TemperatureWetColumn.HeaderText = "Temp/Wet"
        Me.TemperatureWetColumn.Name = "TemperatureWetColumn"
        '
        'CentralCollectColumn
        '
        Me.CentralCollectColumn.DataPropertyName = "CentralCollect"
        Me.CentralCollectColumn.HeaderText = "Central Collect"
        Me.CentralCollectColumn.Name = "CentralCollectColumn"
        '
        'CornerCollectColumn
        '
        Me.CornerCollectColumn.DataPropertyName = "CornerCollect"
        Me.CornerCollectColumn.HeaderText = "Corner Collect"
        Me.CornerCollectColumn.Name = "CornerCollectColumn"
        '
        'PHRangeColumn
        '
        Me.PHRangeColumn.DataPropertyName = "PHRange"
        Me.PHRangeColumn.HeaderText = "PH Range"
        Me.PHRangeColumn.Name = "PHRangeColumn"
        '
        'TowerTemperatureColumn
        '
        Me.TowerTemperatureColumn.DataPropertyName = "TowerTemperature"
        Me.TowerTemperatureColumn.HeaderText = "Tower Temp."
        Me.TowerTemperatureColumn.Name = "TowerTemperatureColumn"
        '
        'TowerPressureColumn
        '
        Me.TowerPressureColumn.DataPropertyName = "TowerPressure"
        Me.TowerPressureColumn.HeaderText = "Tower Pressure"
        Me.TowerPressureColumn.Name = "TowerPressureColumn"
        '
        'CommentsColumn
        '
        Me.CommentsColumn.DataPropertyName = "Comments"
        Me.CommentsColumn.HeaderText = "Comments"
        Me.CommentsColumn.Name = "CommentsColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'UserIDColumn
        '
        Me.UserIDColumn.DataPropertyName = "UserID"
        Me.UserIDColumn.HeaderText = "UserID"
        Me.UserIDColumn.Name = "UserIDColumn"
        Me.UserIDColumn.ReadOnly = True
        Me.UserIDColumn.Visible = False
        '
        'SaltSprayLogBindingSource
        '
        Me.SaltSprayLogBindingSource.DataMember = "SaltSprayLog"
        Me.SaltSprayLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(140, 718)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 15
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdAddData
        '
        Me.cmdAddData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddData.Location = New System.Drawing.Point(63, 718)
        Me.cmdAddData.Name = "cmdAddData"
        Me.cmdAddData.Size = New System.Drawing.Size(71, 30)
        Me.cmdAddData.TabIndex = 14
        Me.cmdAddData.Text = "Add/Save"
        Me.cmdAddData.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Date"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpLogDate
        '
        Me.dtpLogDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpLogDate.Location = New System.Drawing.Point(112, 77)
        Me.dtpLogDate.Name = "dtpLogDate"
        Me.dtpLogDate.Size = New System.Drawing.Size(169, 20)
        Me.dtpLogDate.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Time"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLogTime
        '
        Me.txtLogTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLogTime.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLogTime.Location = New System.Drawing.Point(112, 119)
        Me.txtLogTime.Name = "txtLogTime"
        Me.txtLogTime.Size = New System.Drawing.Size(169, 20)
        Me.txtLogTime.TabIndex = 3
        Me.txtLogTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdDelete)
        Me.GroupBox1.Controls.Add(Me.cmdAddNew)
        Me.GroupBox1.Controls.Add(Me.cboSaltSprayID)
        Me.GroupBox1.Controls.Add(Me.txtDivisionID)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtUserID)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtComments)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtTowerPressure)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtTowerTemperature)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtPHRange)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtCornerCollect)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtCentralCollect)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtTemperatureWet)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtTemperatureDry)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtLogTime)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpLogDate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdAddData)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 770)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Enter New Data"
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(217, 718)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 30)
        Me.cmdDelete.TabIndex = 20
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdAddNew
        '
        Me.cmdAddNew.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdAddNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddNew.ForeColor = System.Drawing.Color.Crimson
        Me.cmdAddNew.Location = New System.Drawing.Point(80, 34)
        Me.cmdAddNew.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdAddNew.Name = "cmdAddNew"
        Me.cmdAddNew.Size = New System.Drawing.Size(29, 20)
        Me.cmdAddNew.TabIndex = 0
        Me.cmdAddNew.Text = ">>"
        Me.cmdAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAddNew.UseVisualStyleBackColor = False
        '
        'cboSaltSprayID
        '
        Me.cboSaltSprayID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSaltSprayID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSaltSprayID.DataSource = Me.SaltSprayLogBindingSource
        Me.cboSaltSprayID.DisplayMember = "SaltSprayID"
        Me.cboSaltSprayID.FormattingEnabled = True
        Me.cboSaltSprayID.Location = New System.Drawing.Point(112, 34)
        Me.cboSaltSprayID.Name = "cboSaltSprayID"
        Me.cboSaltSprayID.Size = New System.Drawing.Size(169, 21)
        Me.cboSaltSprayID.TabIndex = 1
        '
        'txtDivisionID
        '
        Me.txtDivisionID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDivisionID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDivisionID.Location = New System.Drawing.Point(112, 677)
        Me.txtDivisionID.Name = "txtDivisionID"
        Me.txtDivisionID.ReadOnly = True
        Me.txtDivisionID.Size = New System.Drawing.Size(171, 20)
        Me.txtDivisionID.TabIndex = 13
        Me.txtDivisionID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(17, 677)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 23)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "Division"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUserID
        '
        Me.txtUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUserID.Location = New System.Drawing.Point(63, 637)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.ReadOnly = True
        Me.txtUserID.Size = New System.Drawing.Size(219, 20)
        Me.txtUserID.TabIndex = 12
        Me.txtUserID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 637)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 23)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "User"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComments
        '
        Me.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComments.Location = New System.Drawing.Point(20, 480)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(263, 125)
        Me.txtComments.TabIndex = 11
        Me.txtComments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(17, 454)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 23)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "Comments"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTowerPressure
        '
        Me.txtTowerPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTowerPressure.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTowerPressure.Location = New System.Drawing.Point(112, 413)
        Me.txtTowerPressure.Name = "txtTowerPressure"
        Me.txtTowerPressure.Size = New System.Drawing.Size(169, 20)
        Me.txtTowerPressure.TabIndex = 10
        Me.txtTowerPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(17, 412)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 23)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "Tower Pressure"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTowerTemperature
        '
        Me.txtTowerTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTowerTemperature.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTowerTemperature.Location = New System.Drawing.Point(112, 371)
        Me.txtTowerTemperature.Name = "txtTowerTemperature"
        Me.txtTowerTemperature.Size = New System.Drawing.Size(169, 20)
        Me.txtTowerTemperature.TabIndex = 9
        Me.txtTowerTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 370)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 23)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Tower Temp."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPHRange
        '
        Me.txtPHRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPHRange.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPHRange.Location = New System.Drawing.Point(112, 329)
        Me.txtPHRange.Name = "txtPHRange"
        Me.txtPHRange.Size = New System.Drawing.Size(169, 20)
        Me.txtPHRange.TabIndex = 8
        Me.txtPHRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 328)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 23)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "PH Range"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCornerCollect
        '
        Me.txtCornerCollect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCornerCollect.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCornerCollect.Location = New System.Drawing.Point(112, 287)
        Me.txtCornerCollect.Name = "txtCornerCollect"
        Me.txtCornerCollect.Size = New System.Drawing.Size(169, 20)
        Me.txtCornerCollect.TabIndex = 7
        Me.txtCornerCollect.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 286)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 23)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Corner Collect"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCentralCollect
        '
        Me.txtCentralCollect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCentralCollect.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCentralCollect.Location = New System.Drawing.Point(112, 245)
        Me.txtCentralCollect.Name = "txtCentralCollect"
        Me.txtCentralCollect.Size = New System.Drawing.Size(169, 20)
        Me.txtCentralCollect.TabIndex = 6
        Me.txtCentralCollect.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 244)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Central Collect"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTemperatureWet
        '
        Me.txtTemperatureWet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTemperatureWet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTemperatureWet.Location = New System.Drawing.Point(112, 203)
        Me.txtTemperatureWet.Name = "txtTemperatureWet"
        Me.txtTemperatureWet.Size = New System.Drawing.Size(169, 20)
        Me.txtTemperatureWet.TabIndex = 5
        Me.txtTemperatureWet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 202)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Temperature Wet"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTemperatureDry
        '
        Me.txtTemperatureDry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTemperatureDry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTemperatureDry.Location = New System.Drawing.Point(112, 161)
        Me.txtTemperatureDry.Name = "txtTemperatureDry"
        Me.txtTemperatureDry.Size = New System.Drawing.Size(169, 20)
        Me.txtTemperatureDry.TabIndex = 4
        Me.txtTemperatureDry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Temperature Dry"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(17, 33)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 23)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "ID #"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SaltSprayLogTableAdapter
        '
        Me.SaltSprayLogTableAdapter.ClearBeforeFill = True
        '
        'SaltSprayLogForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.dgvSaltSprayLog)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "SaltSprayLogForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Salt Spray Log"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvSaltSprayLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SaltSprayLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents dgvSaltSprayLog As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents SaltSprayLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SaltSprayLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SaltSprayLogTableAdapter
    Friend WithEvents DateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdAddData As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpLogDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLogTime As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTemperatureDry As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPHRange As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCornerCollect As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCentralCollect As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTemperatureWet As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTowerPressure As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTowerTemperature As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtDivisionID As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboSaltSprayID As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmdAddNew As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents SaltSprayIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SaltSprayDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SaltSprayTimeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TemperatureDryColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TemperatureWetColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CentralCollectColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CornerCollectColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PHRangeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TowerTemperatureColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TowerPressureColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
