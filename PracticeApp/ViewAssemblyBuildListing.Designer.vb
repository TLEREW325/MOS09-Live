<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewAssemblyBuildListing
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
        Me.gpxAPAging = New System.Windows.Forms.GroupBox
        Me.chkShowWithout = New System.Windows.Forms.CheckBox
        Me.txtSerialNumber = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.chkUseDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.txtAssemblyDescription = New System.Windows.Forms.TextBox
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.dgvAssemblyBuildHeader = New System.Windows.Forms.DataGridView
        Me.BuildDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildTransactionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyPartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerialNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyBuildHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AssemblyBuildHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblyBuildHeaderTableTableAdapter
        Me.lblDoubleClick = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdAddSN = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.gpxAPAging.SuspendLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAssemblyBuildHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssemblyBuildHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'gpxAPAging
        '
        Me.gpxAPAging.Controls.Add(Me.chkShowWithout)
        Me.gpxAPAging.Controls.Add(Me.txtSerialNumber)
        Me.gpxAPAging.Controls.Add(Me.Label8)
        Me.gpxAPAging.Controls.Add(Me.chkUseDateRange)
        Me.gpxAPAging.Controls.Add(Me.dtpEndDate)
        Me.gpxAPAging.Controls.Add(Me.txtAssemblyDescription)
        Me.gpxAPAging.Controls.Add(Me.dtpBeginDate)
        Me.gpxAPAging.Controls.Add(Me.cboPartDescription)
        Me.gpxAPAging.Controls.Add(Me.cboDivisionID)
        Me.gpxAPAging.Controls.Add(Me.Label7)
        Me.gpxAPAging.Controls.Add(Me.cboPartNumber)
        Me.gpxAPAging.Controls.Add(Me.Label6)
        Me.gpxAPAging.Controls.Add(Me.cmdView)
        Me.gpxAPAging.Controls.Add(Me.cmdClear)
        Me.gpxAPAging.Controls.Add(Me.Label2)
        Me.gpxAPAging.Controls.Add(Me.Label1)
        Me.gpxAPAging.Location = New System.Drawing.Point(29, 41)
        Me.gpxAPAging.Name = "gpxAPAging"
        Me.gpxAPAging.Size = New System.Drawing.Size(300, 494)
        Me.gpxAPAging.TabIndex = 0
        Me.gpxAPAging.TabStop = False
        Me.gpxAPAging.Text = "View By Assembly Part Number"
        '
        'chkShowWithout
        '
        Me.chkShowWithout.AutoSize = True
        Me.chkShowWithout.ForeColor = System.Drawing.Color.Blue
        Me.chkShowWithout.Location = New System.Drawing.Point(23, 232)
        Me.chkShowWithout.Name = "chkShowWithout"
        Me.chkShowWithout.Size = New System.Drawing.Size(194, 17)
        Me.chkShowWithout.TabIndex = 4
        Me.chkShowWithout.Text = "Show builds without a serial number"
        Me.chkShowWithout.UseVisualStyleBackColor = True
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerialNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerialNumber.Location = New System.Drawing.Point(71, 281)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(214, 20)
        Me.txtSerialNumber.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(20, 281)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 20)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Serial #"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkUseDateRange
        '
        Me.chkUseDateRange.AutoSize = True
        Me.chkUseDateRange.Location = New System.Drawing.Point(111, 345)
        Me.chkUseDateRange.Name = "chkUseDateRange"
        Me.chkUseDateRange.Size = New System.Drawing.Size(106, 17)
        Me.chkUseDateRange.TabIndex = 6
        Me.chkUseDateRange.Text = "Use Date Range"
        Me.chkUseDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(111, 410)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(176, 20)
        Me.dtpEndDate.TabIndex = 8
        '
        'txtAssemblyDescription
        '
        Me.txtAssemblyDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAssemblyDescription.Location = New System.Drawing.Point(23, 133)
        Me.txtAssemblyDescription.Multiline = True
        Me.txtAssemblyDescription.Name = "txtAssemblyDescription"
        Me.txtAssemblyDescription.Size = New System.Drawing.Size(262, 65)
        Me.txtAssemblyDescription.TabIndex = 3
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(111, 378)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(176, 20)
        Me.dtpBeginDate.TabIndex = 7
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(22, 98)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(263, 21)
        Me.cboPartDescription.TabIndex = 2
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(83, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(202, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(20, 410)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "End Date"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(83, 63)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(202, 21)
        Me.cboPartNumber.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(20, 378)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Begin Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(137, 446)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 9
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 446)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 10
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Part #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 13
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'dgvAssemblyBuildHeader
        '
        Me.dgvAssemblyBuildHeader.AllowUserToAddRows = False
        Me.dgvAssemblyBuildHeader.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvAssemblyBuildHeader.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAssemblyBuildHeader.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAssemblyBuildHeader.AutoGenerateColumns = False
        Me.dgvAssemblyBuildHeader.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAssemblyBuildHeader.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAssemblyBuildHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAssemblyBuildHeader.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BuildDateColumn, Me.BuildTransactionNumberColumn, Me.AssemblyPartNumberColumn, Me.AssemblyPartDescriptionColumn, Me.SerialNumberColumn, Me.BuildCommentColumn, Me.BuildCostColumn, Me.BuildStatusColumn, Me.DivisionIDColumn})
        Me.dgvAssemblyBuildHeader.DataSource = Me.AssemblyBuildHeaderTableBindingSource
        Me.dgvAssemblyBuildHeader.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvAssemblyBuildHeader.Location = New System.Drawing.Point(346, 41)
        Me.dgvAssemblyBuildHeader.Name = "dgvAssemblyBuildHeader"
        Me.dgvAssemblyBuildHeader.Size = New System.Drawing.Size(784, 712)
        Me.dgvAssemblyBuildHeader.TabIndex = 13
        '
        'BuildDateColumn
        '
        Me.BuildDateColumn.DataPropertyName = "BuildDate"
        Me.BuildDateColumn.HeaderText = "Build Date"
        Me.BuildDateColumn.Name = "BuildDateColumn"
        Me.BuildDateColumn.ReadOnly = True
        '
        'BuildTransactionNumberColumn
        '
        Me.BuildTransactionNumberColumn.DataPropertyName = "BuildTransactionNumber"
        Me.BuildTransactionNumberColumn.HeaderText = "Build #"
        Me.BuildTransactionNumberColumn.Name = "BuildTransactionNumberColumn"
        Me.BuildTransactionNumberColumn.ReadOnly = True
        '
        'AssemblyPartNumberColumn
        '
        Me.AssemblyPartNumberColumn.DataPropertyName = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn.HeaderText = "Part #"
        Me.AssemblyPartNumberColumn.Name = "AssemblyPartNumberColumn"
        Me.AssemblyPartNumberColumn.ReadOnly = True
        '
        'AssemblyPartDescriptionColumn
        '
        Me.AssemblyPartDescriptionColumn.DataPropertyName = "AssemblyPartDescription"
        Me.AssemblyPartDescriptionColumn.HeaderText = "Description"
        Me.AssemblyPartDescriptionColumn.Name = "AssemblyPartDescriptionColumn"
        Me.AssemblyPartDescriptionColumn.ReadOnly = True
        '
        'SerialNumberColumn
        '
        Me.SerialNumberColumn.DataPropertyName = "SerialNumber"
        Me.SerialNumberColumn.HeaderText = "Serial #"
        Me.SerialNumberColumn.Name = "SerialNumberColumn"
        '
        'BuildCommentColumn
        '
        Me.BuildCommentColumn.DataPropertyName = "BuildComment"
        Me.BuildCommentColumn.HeaderText = "Comment"
        Me.BuildCommentColumn.Name = "BuildCommentColumn"
        '
        'BuildCostColumn
        '
        Me.BuildCostColumn.DataPropertyName = "BuildCost"
        Me.BuildCostColumn.HeaderText = "Cost"
        Me.BuildCostColumn.Name = "BuildCostColumn"
        Me.BuildCostColumn.ReadOnly = True
        '
        'BuildStatusColumn
        '
        Me.BuildStatusColumn.DataPropertyName = "BuildStatus"
        Me.BuildStatusColumn.HeaderText = "Status"
        Me.BuildStatusColumn.Name = "BuildStatusColumn"
        Me.BuildStatusColumn.ReadOnly = True
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'AssemblyBuildHeaderTableBindingSource
        '
        Me.AssemblyBuildHeaderTableBindingSource.DataMember = "AssemblyBuildHeaderTable"
        Me.AssemblyBuildHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'AssemblyBuildHeaderTableTableAdapter
        '
        Me.AssemblyBuildHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'lblDoubleClick
        '
        Me.lblDoubleClick.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDoubleClick.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDoubleClick.ForeColor = System.Drawing.Color.Blue
        Me.lblDoubleClick.Location = New System.Drawing.Point(466, 783)
        Me.lblDoubleClick.Name = "lblDoubleClick"
        Me.lblDoubleClick.Size = New System.Drawing.Size(491, 23)
        Me.lblDoubleClick.TabIndex = 16
        Me.lblDoubleClick.Text = "Double-click on Assembly in the datagrid to view components (BOM)."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmdAddSN)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 551)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(302, 260)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Serial Numbers to Builds"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(22, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(265, 27)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Select Part # from top to add serial #'s."
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(22, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(265, 44)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "You will be able to select multiple serial #'s at one time to make available for " & _
            "sale."
        '
        'cmdAddSN
        '
        Me.cmdAddSN.Location = New System.Drawing.Point(216, 136)
        Me.cmdAddSN.Name = "cmdAddSN"
        Me.cmdAddSN.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddSN.TabIndex = 12
        Me.cmdAddSN.Text = "Add S/N's"
        Me.cmdAddSN.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(19, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(265, 56)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Select a Serialized Assembly Part Number to select serial numbers from a list to " & _
            "assign to a specific Build # / Serial Cost."
        '
        'ViewAssemblyBuildListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblDoubleClick)
        Me.Controls.Add(Me.dgvAssemblyBuildHeader)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxAPAging)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewAssemblyBuildListing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Assembly Build Listing"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxAPAging.ResumeLayout(False)
        Me.gpxAPAging.PerformLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAssemblyBuildHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssemblyBuildHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxAPAging As System.Windows.Forms.GroupBox
    Friend WithEvents txtAssemblyDescription As System.Windows.Forms.TextBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgvAssemblyBuildHeader As System.Windows.Forms.DataGridView
    Friend WithEvents AssemblyBuildHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AssemblyBuildHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblyBuildHeaderTableTableAdapter
    Friend WithEvents lblDoubleClick As System.Windows.Forms.Label
    Friend WithEvents chkUseDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents BuildDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildTransactionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssemblyPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssemblyPartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAddSN As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkShowWithout As System.Windows.Forms.CheckBox
End Class
