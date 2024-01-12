<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QCNonConformance
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ManuallyReOpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.txtReason = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmdGenerateNewAdjustmentNumber = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.cboAdjustmentNumber = New System.Windows.Forms.ComboBox
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.dtpQCHoldDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtQCAgent = New System.Windows.Forms.TextBox
        Me.txtFOXNumber = New System.Windows.Forms.TextBox
        Me.txtReworkInstructions = New System.Windows.Forms.TextBox
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdoSort = New System.Windows.Forms.RadioButton
        Me.txtMachineOperator = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtMachineNumber = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtReworkHours = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.rdoUseAsIs = New System.Windows.Forms.RadioButton
        Me.rdoScrap = New System.Windows.Forms.RadioButton
        Me.rdoRework = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdPostEntry = New System.Windows.Forms.Button
        Me.gpxQCNotes = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmdCloseEntry = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtAdjustmentQuantity = New System.Windows.Forms.TextBox
        Me.txtTransferPart = New System.Windows.Forms.TextBox
        Me.lblTransferPartNumber = New System.Windows.Forms.Label
        Me.chkDoNothing = New System.Windows.Forms.CheckBox
        Me.chkAddToInventory = New System.Windows.Forms.CheckBox
        Me.chkTransferPart = New System.Windows.Forms.CheckBox
        Me.chkRemoveFromInventory = New System.Windows.Forms.CheckBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdQCRacking = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.tabCtrl = New System.Windows.Forms.TabControl
        Me.tabNotes = New System.Windows.Forms.TabPage
        Me.tabAdjustments = New System.Windows.Forms.TabPage
        Me.dgvAdjustmentLines = New System.Windows.Forms.DataGridView
        Me.tabPictures = New System.Windows.Forms.TabPage
        Me.cmdPrintPicture = New System.Windows.Forms.Button
        Me.cmdFullScreenPicture = New System.Windows.Forms.Button
        Me.cmdDeletePicture = New System.Windows.Forms.Button
        Me.cmdAddPicture = New System.Windows.Forms.Button
        Me.dgvPictures = New System.Windows.Forms.DataGridView
        Me.picture = New System.Windows.Forms.DataGridViewImageColumn
        Me.vscrlPicture = New System.Windows.Forms.VScrollBar
        Me.hscrlPicture = New System.Windows.Forms.HScrollBar
        Me.picbxSelectedPicture = New System.Windows.Forms.PictureBox
        Me.gpxLotNumbers = New System.Windows.Forms.GroupBox
        Me.cmdDeleteLot = New System.Windows.Forms.Button
        Me.dgvLotNumbers = New System.Windows.Forms.DataGridView
        Me.cmdAddLot = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gpxQCNotes.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.tabCtrl.SuspendLayout()
        Me.tabNotes.SuspendLayout()
        Me.tabAdjustments.SuspendLayout()
        CType(Me.dgvAdjustmentLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPictures.SuspendLayout()
        CType(Me.dgvPictures, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picbxSelectedPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxLotNumbers.SuspendLayout()
        CType(Me.dgvLotNumbers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.PrintToolStripMenuItem, Me.ClearToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManuallyReOpenToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ManuallyReOpenToolStripMenuItem
        '
        Me.ManuallyReOpenToolStripMenuItem.Name = "ManuallyReOpenToolStripMenuItem"
        Me.ManuallyReOpenToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ManuallyReOpenToolStripMenuItem.Text = "Manually Re-Open"
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
        Me.cmdPrint.Location = New System.Drawing.Point(805, 764)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 17
        Me.cmdPrint.Text = "Print Report"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 764)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 18
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'txtReason
        '
        Me.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReason.Location = New System.Drawing.Point(24, 39)
        Me.txtReason.MaxLength = 500
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(640, 120)
        Me.txtReason.TabIndex = 17
        Me.txtReason.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 20)
        Me.Label11.TabIndex = 87
        Me.Label11.Text = "Trans. #"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdGenerateNewAdjustmentNumber
        '
        Me.cmdGenerateNewAdjustmentNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateNewAdjustmentNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateNewAdjustmentNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateNewAdjustmentNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateNewAdjustmentNumber.Location = New System.Drawing.Point(70, 27)
        Me.cmdGenerateNewAdjustmentNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateNewAdjustmentNumber.Name = "cmdGenerateNewAdjustmentNumber"
        Me.cmdGenerateNewAdjustmentNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateNewAdjustmentNumber.TabIndex = 0
        Me.cmdGenerateNewAdjustmentNumber.TabStop = False
        Me.cmdGenerateNewAdjustmentNumber.Text = ">>"
        Me.cmdGenerateNewAdjustmentNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateNewAdjustmentNumber.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(16, 233)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 20)
        Me.Label14.TabIndex = 82
        Me.Label14.Text = "Part #"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAdjustmentNumber
        '
        Me.cboAdjustmentNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAdjustmentNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAdjustmentNumber.DisplayMember = "EmployeeID"
        Me.cboAdjustmentNumber.FormattingEnabled = True
        Me.cboAdjustmentNumber.Location = New System.Drawing.Point(102, 27)
        Me.cboAdjustmentNumber.Name = "cboAdjustmentNumber"
        Me.cboAdjustmentNumber.Size = New System.Drawing.Size(177, 21)
        Me.cboAdjustmentNumber.TabIndex = 0
        Me.cboAdjustmentNumber.ValueMember = "EmployeeID"
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DisplayMember = "EmployeeID"
        Me.cboPartDescription.DropDownWidth = 300
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(16, 269)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(266, 21)
        Me.cboPartDescription.TabIndex = 6
        Me.cboPartDescription.ValueMember = "EmployeeID"
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DisplayMember = "EmployeeID"
        Me.cboPartNumber.DropDownWidth = 250
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(60, 233)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(219, 21)
        Me.cboPartNumber.TabIndex = 5
        Me.cboPartNumber.ValueMember = "EmployeeID"
        '
        'dtpQCHoldDate
        '
        Me.dtpQCHoldDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpQCHoldDate.Location = New System.Drawing.Point(102, 60)
        Me.dtpQCHoldDate.Name = "dtpQCHoldDate"
        Me.dtpQCHoldDate.Size = New System.Drawing.Size(177, 20)
        Me.dtpQCHoldDate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 20)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "QC Hold Date"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQCAgent
        '
        Me.txtQCAgent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQCAgent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQCAgent.Location = New System.Drawing.Point(16, 151)
        Me.txtQCAgent.Name = "txtQCAgent"
        Me.txtQCAgent.Size = New System.Drawing.Size(266, 20)
        Me.txtQCAgent.TabIndex = 3
        Me.txtQCAgent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFOXNumber
        '
        Me.txtFOXNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtFOXNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtFOXNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFOXNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFOXNumber.Location = New System.Drawing.Point(152, 192)
        Me.txtFOXNumber.Name = "txtFOXNumber"
        Me.txtFOXNumber.Size = New System.Drawing.Size(127, 20)
        Me.txtFOXNumber.TabIndex = 4
        Me.txtFOXNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReworkInstructions
        '
        Me.txtReworkInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReworkInstructions.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReworkInstructions.Location = New System.Drawing.Point(24, 185)
        Me.txtReworkInstructions.MaxLength = 500
        Me.txtReworkInstructions.Multiline = True
        Me.txtReworkInstructions.Name = "txtReworkInstructions"
        Me.txtReworkInstructions.Size = New System.Drawing.Size(640, 120)
        Me.txtReworkInstructions.TabIndex = 19
        Me.txtReworkInstructions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtComment
        '
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(25, 333)
        Me.txtComment.MaxLength = 500
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(640, 120)
        Me.txtComment.TabIndex = 18
        Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuantity
        '
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuantity.Location = New System.Drawing.Point(152, 440)
        Me.txtQuantity.MaxLength = 10
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(127, 20)
        Me.txtQuantity.TabIndex = 9
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoSort)
        Me.GroupBox1.Controls.Add(Me.txtMachineOperator)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtMachineNumber)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblStatus)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtReworkHours)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.rdoUseAsIs)
        Me.GroupBox1.Controls.Add(Me.rdoScrap)
        Me.GroupBox1.Controls.Add(Me.rdoRework)
        Me.GroupBox1.Controls.Add(Me.txtFOXNumber)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtQuantity)
        Me.GroupBox1.Controls.Add(Me.txtQCAgent)
        Me.GroupBox1.Controls.Add(Me.dtpQCHoldDate)
        Me.GroupBox1.Controls.Add(Me.cboPartNumber)
        Me.GroupBox1.Controls.Add(Me.cboPartDescription)
        Me.GroupBox1.Controls.Add(Me.cboAdjustmentNumber)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.cmdGenerateNewAdjustmentNumber)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 770)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "QC Part Data"
        '
        'rdoSort
        '
        Me.rdoSort.AutoSize = True
        Me.rdoSort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoSort.Location = New System.Drawing.Point(96, 694)
        Me.rdoSort.Name = "rdoSort"
        Me.rdoSort.Size = New System.Drawing.Size(48, 17)
        Me.rdoSort.TabIndex = 14
        Me.rdoSort.TabStop = True
        Me.rdoSort.Text = "Sort"
        Me.rdoSort.UseVisualStyleBackColor = True
        '
        'txtMachineOperator
        '
        Me.txtMachineOperator.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtMachineOperator.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtMachineOperator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMachineOperator.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMachineOperator.Location = New System.Drawing.Point(16, 335)
        Me.txtMachineOperator.Name = "txtMachineOperator"
        Me.txtMachineOperator.Size = New System.Drawing.Size(263, 20)
        Me.txtMachineOperator.TabIndex = 7
        Me.txtMachineOperator.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(16, 391)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 20)
        Me.Label15.TabIndex = 117
        Me.Label15.Text = "Machine #"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMachineNumber
        '
        Me.txtMachineNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtMachineNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtMachineNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMachineNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMachineNumber.Location = New System.Drawing.Point(152, 391)
        Me.txtMachineNumber.Name = "txtMachineNumber"
        Me.txtMachineNumber.Size = New System.Drawing.Size(127, 20)
        Me.txtMachineNumber.TabIndex = 8
        Me.txtMachineNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 312)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 20)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "Machine Operator"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStatus.Location = New System.Drawing.Point(102, 94)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(177, 20)
        Me.lblStatus.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(16, 94)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 20)
        Me.Label13.TabIndex = 111
        Me.Label13.Text = "Status"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReworkHours
        '
        Me.txtReworkHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReworkHours.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReworkHours.Location = New System.Drawing.Point(152, 489)
        Me.txtReworkHours.MaxLength = 10
        Me.txtReworkHours.Name = "txtReworkHours"
        Me.txtReworkHours.Size = New System.Drawing.Size(127, 20)
        Me.txtReworkHours.TabIndex = 10
        Me.txtReworkHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(16, 489)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 20)
        Me.Label12.TabIndex = 109
        Me.Label12.Text = "Rework Hours"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(13, 548)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(266, 20)
        Me.Label6.TabIndex = 105
        Me.Label6.Text = "Corrective Action"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(208, 717)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 15
        Me.cmdClear.Text = "Clear All"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'rdoUseAsIs
        '
        Me.rdoUseAsIs.AutoSize = True
        Me.rdoUseAsIs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoUseAsIs.Location = New System.Drawing.Point(96, 657)
        Me.rdoUseAsIs.Name = "rdoUseAsIs"
        Me.rdoUseAsIs.Size = New System.Drawing.Size(79, 17)
        Me.rdoUseAsIs.TabIndex = 13
        Me.rdoUseAsIs.TabStop = True
        Me.rdoUseAsIs.Text = "Use As Is"
        Me.rdoUseAsIs.UseVisualStyleBackColor = True
        '
        'rdoScrap
        '
        Me.rdoScrap.AutoSize = True
        Me.rdoScrap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoScrap.Location = New System.Drawing.Point(96, 620)
        Me.rdoScrap.Name = "rdoScrap"
        Me.rdoScrap.Size = New System.Drawing.Size(91, 17)
        Me.rdoScrap.TabIndex = 12
        Me.rdoScrap.TabStop = True
        Me.rdoScrap.Text = "Scrap Parts"
        Me.rdoScrap.UseVisualStyleBackColor = True
        '
        'rdoRework
        '
        Me.rdoRework.AutoSize = True
        Me.rdoRework.Checked = True
        Me.rdoRework.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoRework.Location = New System.Drawing.Point(96, 583)
        Me.rdoRework.Name = "rdoRework"
        Me.rdoRework.Size = New System.Drawing.Size(101, 17)
        Me.rdoRework.TabIndex = 11
        Me.rdoRework.TabStop = True
        Me.rdoRework.Text = "Rework Parts"
        Me.rdoRework.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 20)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "QC Agent"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 188)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 20)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "FOX #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 440)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(133, 20)
        Me.Label7.TabIndex = 106
        Me.Label7.Text = "Total Quantity (Pieces)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPostEntry
        '
        Me.cmdPostEntry.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPostEntry.ForeColor = System.Drawing.Color.Blue
        Me.cmdPostEntry.Location = New System.Drawing.Point(593, 110)
        Me.cmdPostEntry.Name = "cmdPostEntry"
        Me.cmdPostEntry.Size = New System.Drawing.Size(71, 40)
        Me.cmdPostEntry.TabIndex = 6
        Me.cmdPostEntry.Text = "Add Adjustment"
        Me.cmdPostEntry.UseVisualStyleBackColor = True
        '
        'gpxQCNotes
        '
        Me.gpxQCNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxQCNotes.Controls.Add(Me.Label10)
        Me.gpxQCNotes.Controls.Add(Me.Label9)
        Me.gpxQCNotes.Controls.Add(Me.Label8)
        Me.gpxQCNotes.Controls.Add(Me.txtReworkInstructions)
        Me.gpxQCNotes.Controls.Add(Me.txtReason)
        Me.gpxQCNotes.Controls.Add(Me.txtComment)
        Me.gpxQCNotes.Location = New System.Drawing.Point(5, 3)
        Me.gpxQCNotes.Name = "gpxQCNotes"
        Me.gpxQCNotes.Size = New System.Drawing.Size(684, 525)
        Me.gpxQCNotes.TabIndex = 16
        Me.gpxQCNotes.TabStop = False
        Me.gpxQCNotes.Text = "QC Notes"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(22, 310)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(382, 20)
        Me.Label10.TabIndex = 103
        Me.Label10.Text = "Notes / Comments"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(21, 162)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(382, 20)
        Me.Label9.TabIndex = 102
        Me.Label9.Text = "Rework Instructions"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(21, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(382, 20)
        Me.Label8.TabIndex = 101
        Me.Label8.Text = "Reason for Nonconformance"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.cmdCloseEntry)
        Me.GroupBox3.Location = New System.Drawing.Point(728, 681)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(302, 77)
        Me.GroupBox3.TabIndex = 98
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Close"
        '
        'Label17
        '
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(16, 23)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(180, 40)
        Me.Label17.TabIndex = 99
        Me.Label17.Text = "Close if no other action will be taken."
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCloseEntry
        '
        Me.cmdCloseEntry.ForeColor = System.Drawing.Color.Blue
        Me.cmdCloseEntry.Location = New System.Drawing.Point(211, 23)
        Me.cmdCloseEntry.Name = "cmdCloseEntry"
        Me.cmdCloseEntry.Size = New System.Drawing.Size(71, 40)
        Me.cmdCloseEntry.TabIndex = 97
        Me.cmdCloseEntry.Text = "Close"
        Me.cmdCloseEntry.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(882, 764)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 99
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.txtAdjustmentQuantity)
        Me.GroupBox4.Controls.Add(Me.txtTransferPart)
        Me.GroupBox4.Controls.Add(Me.cmdPostEntry)
        Me.GroupBox4.Controls.Add(Me.lblTransferPartNumber)
        Me.GroupBox4.Controls.Add(Me.chkDoNothing)
        Me.GroupBox4.Controls.Add(Me.chkAddToInventory)
        Me.GroupBox4.Controls.Add(Me.chkTransferPart)
        Me.GroupBox4.Controls.Add(Me.chkRemoveFromInventory)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(684, 177)
        Me.GroupBox4.TabIndex = 20
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Adjustment Instructions"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(446, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 20)
        Me.Label4.TabIndex = 98
        Me.Label4.Text = "Adjustment Quantity"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAdjustmentQuantity
        '
        Me.txtAdjustmentQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAdjustmentQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdjustmentQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdjustmentQuantity.Location = New System.Drawing.Point(555, 77)
        Me.txtAdjustmentQuantity.Name = "txtAdjustmentQuantity"
        Me.txtAdjustmentQuantity.Size = New System.Drawing.Size(109, 20)
        Me.txtAdjustmentQuantity.TabIndex = 5
        Me.txtAdjustmentQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTransferPart
        '
        Me.txtTransferPart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTransferPart.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtTransferPart.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtTransferPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransferPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransferPart.Enabled = False
        Me.txtTransferPart.Location = New System.Drawing.Point(449, 28)
        Me.txtTransferPart.Name = "txtTransferPart"
        Me.txtTransferPart.Size = New System.Drawing.Size(215, 20)
        Me.txtTransferPart.TabIndex = 4
        Me.txtTransferPart.Visible = False
        '
        'lblTransferPartNumber
        '
        Me.lblTransferPartNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTransferPartNumber.Location = New System.Drawing.Point(359, 26)
        Me.lblTransferPartNumber.Name = "lblTransferPartNumber"
        Me.lblTransferPartNumber.Size = New System.Drawing.Size(84, 20)
        Me.lblTransferPartNumber.TabIndex = 85
        Me.lblTransferPartNumber.Text = "Transfer Part #"
        Me.lblTransferPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTransferPartNumber.Visible = False
        '
        'chkDoNothing
        '
        Me.chkDoNothing.AutoSize = True
        Me.chkDoNothing.Location = New System.Drawing.Point(24, 88)
        Me.chkDoNothing.Name = "chkDoNothing"
        Me.chkDoNothing.Size = New System.Drawing.Size(233, 17)
        Me.chkDoNothing.TabIndex = 2
        Me.chkDoNothing.Text = "No Inventory Adjustment (Work In Progress)"
        Me.chkDoNothing.UseVisualStyleBackColor = True
        '
        'chkAddToInventory
        '
        Me.chkAddToInventory.AutoSize = True
        Me.chkAddToInventory.Location = New System.Drawing.Point(24, 58)
        Me.chkAddToInventory.Name = "chkAddToInventory"
        Me.chkAddToInventory.Size = New System.Drawing.Size(104, 17)
        Me.chkAddToInventory.TabIndex = 1
        Me.chkAddToInventory.Text = "Add to Inventory"
        Me.chkAddToInventory.UseVisualStyleBackColor = True
        '
        'chkTransferPart
        '
        Me.chkTransferPart.AutoSize = True
        Me.chkTransferPart.Location = New System.Drawing.Point(24, 120)
        Me.chkTransferPart.Name = "chkTransferPart"
        Me.chkTransferPart.Size = New System.Drawing.Size(178, 17)
        Me.chkTransferPart.TabIndex = 3
        Me.chkTransferPart.Text = "Transfer to another Part Number"
        Me.chkTransferPart.UseVisualStyleBackColor = True
        '
        'chkRemoveFromInventory
        '
        Me.chkRemoveFromInventory.AutoSize = True
        Me.chkRemoveFromInventory.Location = New System.Drawing.Point(24, 28)
        Me.chkRemoveFromInventory.Name = "chkRemoveFromInventory"
        Me.chkRemoveFromInventory.Size = New System.Drawing.Size(136, 17)
        Me.chkRemoveFromInventory.TabIndex = 0
        Me.chkRemoveFromInventory.Text = "Remove from Inventory"
        Me.chkRemoveFromInventory.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.cmdQCRacking)
        Me.GroupBox5.Location = New System.Drawing.Point(728, 598)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(302, 77)
        Me.GroupBox5.TabIndex = 100
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Add To QC Racking"
        '
        'Label16
        '
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(16, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(189, 40)
        Me.Label16.TabIndex = 98
        Me.Label16.Text = "Opens utility to add product to QC Racks."
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdQCRacking
        '
        Me.cmdQCRacking.ForeColor = System.Drawing.Color.Blue
        Me.cmdQCRacking.Location = New System.Drawing.Point(211, 25)
        Me.cmdQCRacking.Name = "cmdQCRacking"
        Me.cmdQCRacking.Size = New System.Drawing.Size(71, 40)
        Me.cmdQCRacking.TabIndex = 97
        Me.cmdQCRacking.Text = "Add To Rack"
        Me.cmdQCRacking.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(728, 764)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 101
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'tabCtrl
        '
        Me.tabCtrl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabCtrl.Controls.Add(Me.tabNotes)
        Me.tabCtrl.Controls.Add(Me.tabAdjustments)
        Me.tabCtrl.Controls.Add(Me.tabPictures)
        Me.tabCtrl.Location = New System.Drawing.Point(336, 28)
        Me.tabCtrl.Name = "tabCtrl"
        Me.tabCtrl.SelectedIndex = 0
        Me.tabCtrl.Size = New System.Drawing.Size(706, 564)
        Me.tabCtrl.TabIndex = 102
        '
        'tabNotes
        '
        Me.tabNotes.BackColor = System.Drawing.Color.Transparent
        Me.tabNotes.Controls.Add(Me.gpxQCNotes)
        Me.tabNotes.Location = New System.Drawing.Point(4, 22)
        Me.tabNotes.Name = "tabNotes"
        Me.tabNotes.Padding = New System.Windows.Forms.Padding(3)
        Me.tabNotes.Size = New System.Drawing.Size(698, 538)
        Me.tabNotes.TabIndex = 0
        Me.tabNotes.Text = "Notes, Comments or Instructions"
        Me.tabNotes.UseVisualStyleBackColor = True
        '
        'tabAdjustments
        '
        Me.tabAdjustments.BackColor = System.Drawing.Color.Transparent
        Me.tabAdjustments.Controls.Add(Me.dgvAdjustmentLines)
        Me.tabAdjustments.Controls.Add(Me.GroupBox4)
        Me.tabAdjustments.Location = New System.Drawing.Point(4, 22)
        Me.tabAdjustments.Name = "tabAdjustments"
        Me.tabAdjustments.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAdjustments.Size = New System.Drawing.Size(698, 538)
        Me.tabAdjustments.TabIndex = 1
        Me.tabAdjustments.Text = "Adjustments"
        Me.tabAdjustments.UseVisualStyleBackColor = True
        '
        'dgvAdjustmentLines
        '
        Me.dgvAdjustmentLines.AllowUserToAddRows = False
        Me.dgvAdjustmentLines.AllowUserToDeleteRows = False
        Me.dgvAdjustmentLines.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAdjustmentLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAdjustmentLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAdjustmentLines.Location = New System.Drawing.Point(6, 189)
        Me.dgvAdjustmentLines.Name = "dgvAdjustmentLines"
        Me.dgvAdjustmentLines.ReadOnly = True
        Me.dgvAdjustmentLines.Size = New System.Drawing.Size(684, 293)
        Me.dgvAdjustmentLines.TabIndex = 21
        '
        'tabPictures
        '
        Me.tabPictures.BackColor = System.Drawing.SystemColors.Control
        Me.tabPictures.Controls.Add(Me.cmdPrintPicture)
        Me.tabPictures.Controls.Add(Me.cmdFullScreenPicture)
        Me.tabPictures.Controls.Add(Me.cmdDeletePicture)
        Me.tabPictures.Controls.Add(Me.cmdAddPicture)
        Me.tabPictures.Controls.Add(Me.dgvPictures)
        Me.tabPictures.Controls.Add(Me.vscrlPicture)
        Me.tabPictures.Controls.Add(Me.hscrlPicture)
        Me.tabPictures.Controls.Add(Me.picbxSelectedPicture)
        Me.tabPictures.Location = New System.Drawing.Point(4, 22)
        Me.tabPictures.Name = "tabPictures"
        Me.tabPictures.Size = New System.Drawing.Size(698, 538)
        Me.tabPictures.TabIndex = 2
        Me.tabPictures.Text = "Pictures"
        '
        'cmdPrintPicture
        '
        Me.cmdPrintPicture.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintPicture.Location = New System.Drawing.Point(6, 423)
        Me.cmdPrintPicture.Name = "cmdPrintPicture"
        Me.cmdPrintPicture.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintPicture.TabIndex = 109
        Me.cmdPrintPicture.Text = "Print Selected"
        Me.cmdPrintPicture.UseVisualStyleBackColor = True
        '
        'cmdFullScreenPicture
        '
        Me.cmdFullScreenPicture.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdFullScreenPicture.Location = New System.Drawing.Point(120, 423)
        Me.cmdFullScreenPicture.Name = "cmdFullScreenPicture"
        Me.cmdFullScreenPicture.Size = New System.Drawing.Size(71, 40)
        Me.cmdFullScreenPicture.TabIndex = 108
        Me.cmdFullScreenPicture.Text = "Full Screen"
        Me.cmdFullScreenPicture.UseVisualStyleBackColor = True
        '
        'cmdDeletePicture
        '
        Me.cmdDeletePicture.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdDeletePicture.Location = New System.Drawing.Point(120, 362)
        Me.cmdDeletePicture.Name = "cmdDeletePicture"
        Me.cmdDeletePicture.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeletePicture.TabIndex = 107
        Me.cmdDeletePicture.Text = "Delete Selected"
        Me.cmdDeletePicture.UseVisualStyleBackColor = True
        '
        'cmdAddPicture
        '
        Me.cmdAddPicture.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAddPicture.Location = New System.Drawing.Point(6, 362)
        Me.cmdAddPicture.Name = "cmdAddPicture"
        Me.cmdAddPicture.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddPicture.TabIndex = 106
        Me.cmdAddPicture.Text = "Add Picture"
        Me.cmdAddPicture.UseVisualStyleBackColor = True
        '
        'dgvPictures
        '
        Me.dgvPictures.AllowUserToAddRows = False
        Me.dgvPictures.AllowUserToDeleteRows = False
        Me.dgvPictures.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvPictures.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPictures.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvPictures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPictures.ColumnHeadersVisible = False
        Me.dgvPictures.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.picture})
        Me.dgvPictures.Location = New System.Drawing.Point(6, 4)
        Me.dgvPictures.Name = "dgvPictures"
        Me.dgvPictures.ReadOnly = True
        Me.dgvPictures.RowHeadersVisible = False
        Me.dgvPictures.Size = New System.Drawing.Size(185, 352)
        Me.dgvPictures.TabIndex = 3
        '
        'picture
        '
        Me.picture.HeaderText = "picture"
        Me.picture.Name = "picture"
        Me.picture.ReadOnly = True
        '
        'vscrlPicture
        '
        Me.vscrlPicture.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vscrlPicture.Location = New System.Drawing.Point(676, 3)
        Me.vscrlPicture.Name = "vscrlPicture"
        Me.vscrlPicture.Size = New System.Drawing.Size(17, 465)
        Me.vscrlPicture.TabIndex = 2
        '
        'hscrlPicture
        '
        Me.hscrlPicture.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hscrlPicture.Location = New System.Drawing.Point(197, 466)
        Me.hscrlPicture.Name = "hscrlPicture"
        Me.hscrlPicture.Size = New System.Drawing.Size(476, 17)
        Me.hscrlPicture.TabIndex = 1
        '
        'picbxSelectedPicture
        '
        Me.picbxSelectedPicture.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picbxSelectedPicture.Location = New System.Drawing.Point(197, 3)
        Me.picbxSelectedPicture.Name = "picbxSelectedPicture"
        Me.picbxSelectedPicture.Size = New System.Drawing.Size(476, 460)
        Me.picbxSelectedPicture.TabIndex = 0
        Me.picbxSelectedPicture.TabStop = False
        '
        'gpxLotNumbers
        '
        Me.gpxLotNumbers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxLotNumbers.Controls.Add(Me.cmdDeleteLot)
        Me.gpxLotNumbers.Controls.Add(Me.dgvLotNumbers)
        Me.gpxLotNumbers.Controls.Add(Me.cmdAddLot)
        Me.gpxLotNumbers.Location = New System.Drawing.Point(336, 598)
        Me.gpxLotNumbers.Name = "gpxLotNumbers"
        Me.gpxLotNumbers.Size = New System.Drawing.Size(386, 212)
        Me.gpxLotNumbers.TabIndex = 103
        Me.gpxLotNumbers.TabStop = False
        Me.gpxLotNumbers.Text = "Lot Number(s)"
        '
        'cmdDeleteLot
        '
        Me.cmdDeleteLot.Location = New System.Drawing.Point(298, 71)
        Me.cmdDeleteLot.Name = "cmdDeleteLot"
        Me.cmdDeleteLot.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteLot.TabIndex = 105
        Me.cmdDeleteLot.Text = "Delete Lot"
        Me.cmdDeleteLot.UseVisualStyleBackColor = True
        '
        'dgvLotNumbers
        '
        Me.dgvLotNumbers.AllowUserToAddRows = False
        Me.dgvLotNumbers.AllowUserToDeleteRows = False
        Me.dgvLotNumbers.AllowUserToResizeColumns = False
        Me.dgvLotNumbers.AllowUserToResizeRows = False
        Me.dgvLotNumbers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvLotNumbers.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLotNumbers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLotNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLotNumbers.Location = New System.Drawing.Point(10, 25)
        Me.dgvLotNumbers.Name = "dgvLotNumbers"
        Me.dgvLotNumbers.ReadOnly = True
        Me.dgvLotNumbers.RowHeadersVisible = False
        Me.dgvLotNumbers.Size = New System.Drawing.Size(270, 173)
        Me.dgvLotNumbers.TabIndex = 101
        '
        'cmdAddLot
        '
        Me.cmdAddLot.Location = New System.Drawing.Point(298, 25)
        Me.cmdAddLot.Name = "cmdAddLot"
        Me.cmdAddLot.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddLot.TabIndex = 104
        Me.cmdAddLot.Text = "Add Lot"
        Me.cmdAddLot.UseVisualStyleBackColor = True
        '
        'QCNonConformance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.gpxLotNumbers)
        Me.Controls.Add(Me.tabCtrl)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "QCNonConformance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Quality Control Non-Conformance Entry"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gpxQCNotes.ResumeLayout(False)
        Me.gpxQCNotes.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.tabCtrl.ResumeLayout(False)
        Me.tabNotes.ResumeLayout(False)
        Me.tabAdjustments.ResumeLayout(False)
        CType(Me.dgvAdjustmentLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPictures.ResumeLayout(False)
        CType(Me.dgvPictures, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picbxSelectedPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxLotNumbers.ResumeLayout(False)
        CType(Me.dgvLotNumbers, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdGenerateNewAdjustmentNumber As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboAdjustmentNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents dtpQCHoldDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtQCAgent As System.Windows.Forms.TextBox
    Friend WithEvents txtFOXNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtReworkInstructions As System.Windows.Forms.TextBox
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPostEntry As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rdoUseAsIs As System.Windows.Forms.RadioButton
    Friend WithEvents rdoScrap As System.Windows.Forms.RadioButton
    Friend WithEvents rdoRework As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents gpxQCNotes As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkAddToInventory As System.Windows.Forms.CheckBox
    Friend WithEvents chkTransferPart As System.Windows.Forms.CheckBox
    Friend WithEvents chkRemoveFromInventory As System.Windows.Forms.CheckBox
    Friend WithEvents txtReworkHours As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkDoNothing As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents lblTransferPartNumber As System.Windows.Forms.Label
    Friend WithEvents txtTransferPart As System.Windows.Forms.TextBox
    Friend WithEvents cmdCloseEntry As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdQCRacking As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManuallyReOpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabCtrl As System.Windows.Forms.TabControl
    Friend WithEvents tabNotes As System.Windows.Forms.TabPage
    Friend WithEvents tabAdjustments As System.Windows.Forms.TabPage
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents gpxLotNumbers As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAddLot As System.Windows.Forms.Button
    Friend WithEvents dgvLotNumbers As System.Windows.Forms.DataGridView
    Friend WithEvents cmdDeleteLot As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAdjustmentQuantity As System.Windows.Forms.TextBox
    Friend WithEvents dgvAdjustmentLines As System.Windows.Forms.DataGridView
    Friend WithEvents tabPictures As System.Windows.Forms.TabPage
    Friend WithEvents vscrlPicture As System.Windows.Forms.VScrollBar
    Friend WithEvents hscrlPicture As System.Windows.Forms.HScrollBar
    Friend WithEvents picbxSelectedPicture As System.Windows.Forms.PictureBox
    Friend WithEvents cmdPrintPicture As System.Windows.Forms.Button
    Friend WithEvents cmdFullScreenPicture As System.Windows.Forms.Button
    Friend WithEvents cmdDeletePicture As System.Windows.Forms.Button
    Friend WithEvents cmdAddPicture As System.Windows.Forms.Button
    Friend WithEvents dgvPictures As System.Windows.Forms.DataGridView
    Friend WithEvents picture As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents txtMachineOperator As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtMachineNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rdoSort As System.Windows.Forms.RadioButton
End Class
