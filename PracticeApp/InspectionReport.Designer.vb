<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InspectionReport
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.txtRevisionLevel = New System.Windows.Forms.TextBox
        Me.txtOperator = New System.Windows.Forms.TextBox
        Me.txtShift = New System.Windows.Forms.TextBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtCustomer = New System.Windows.Forms.TextBox
        Me.lblRevisionLevel = New System.Windows.Forms.Label
        Me.lblOperator = New System.Windows.Forms.Label
        Me.lblMachineNumber = New System.Windows.Forms.Label
        Me.lblShift = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtHeaderComment = New System.Windows.Forms.TextBox
        Me.lblCustomer = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtOperation = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboFoxNumber = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtLineComment = New System.Windows.Forms.TextBox
        Me.cmdAddLine = New System.Windows.Forms.Button
        Me.cmdClearLineInputData = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboInspection = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtPartDetail = New System.Windows.Forms.TextBox
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.dgvInspectionReports = New System.Windows.Forms.DataGridView
        Me.gpxFoxInfo = New System.Windows.Forms.GroupBox
        Me.cboMachineNumber = New System.Windows.Forms.ComboBox
        Me.cboBluePrint = New System.Windows.Forms.ComboBox
        Me.txtLotNumber = New System.Windows.Forms.TextBox
        Me.lblLotNumber = New System.Windows.Forms.Label
        Me.txtPartNumber = New System.Windows.Forms.TextBox
        Me.cboInspectionKey = New System.Windows.Forms.ComboBox
        Me.lblPONumber = New System.Windows.Forms.Label
        Me.gpxDeleteLine = New System.Windows.Forms.GroupBox
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.cboLineNumber = New System.Windows.Forms.ComboBox
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.tabRows = New System.Windows.Forms.TabControl
        Me.tbCurrentRows = New System.Windows.Forms.TabPage
        Me.tbAddNewRow = New System.Windows.Forms.TabPage
        Me.cmdBlankLine = New System.Windows.Forms.Button
        Me.lblNote = New System.Windows.Forms.Label
        Me.cboFrequency = New System.Windows.Forms.ComboBox
        Me.cboSampleSize = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtHighSpec = New System.Windows.Forms.TextBox
        Me.lblHighSpec = New System.Windows.Forms.Label
        Me.lblLowSpec = New System.Windows.Forms.Label
        Me.txtLowSpec = New System.Windows.Forms.TextBox
        Me.txtDataGridNote = New System.Windows.Forms.TextBox
        Me.gpxFirstPieceInspection = New System.Windows.Forms.GroupBox
        Me.cmdFirstInspectionEntry = New System.Windows.Forms.Button
        Me.cmdViewEntries = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.pnlBlueprintJournalEntries = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtPartSpec = New System.Windows.Forms.TextBox
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvInspectionReports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxFoxInfo.SuspendLayout()
        Me.gpxDeleteLine.SuspendLayout()
        Me.tabRows.SuspendLayout()
        Me.tbCurrentRows.SuspendLayout()
        Me.tbAddNewRow.SuspendLayout()
        Me.gpxFirstPieceInspection.SuspendLayout()
        Me.pnlBlueprintJournalEntries.SuspendLayout()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.PrintToolStripMenuItem, Me.DeleteReportToolStripMenuItem, Me.ClearAllToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'DeleteReportToolStripMenuItem
        '
        Me.DeleteReportToolStripMenuItem.Name = "DeleteReportToolStripMenuItem"
        Me.DeleteReportToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.DeleteReportToolStripMenuItem.Text = "Delete Report"
        '
        'ClearAllToolStripMenuItem
        '
        Me.ClearAllToolStripMenuItem.Name = "ClearAllToolStripMenuItem"
        Me.ClearAllToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.ClearAllToolStripMenuItem.Text = "Clear All"
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
        'txtRevisionLevel
        '
        Me.txtRevisionLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRevisionLevel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRevisionLevel.Location = New System.Drawing.Point(654, 36)
        Me.txtRevisionLevel.MaxLength = 3
        Me.txtRevisionLevel.Name = "txtRevisionLevel"
        Me.txtRevisionLevel.Size = New System.Drawing.Size(73, 20)
        Me.txtRevisionLevel.TabIndex = 3
        Me.txtRevisionLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOperator
        '
        Me.txtOperator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOperator.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOperator.Location = New System.Drawing.Point(957, 154)
        Me.txtOperator.MaxLength = 50
        Me.txtOperator.Name = "txtOperator"
        Me.txtOperator.Size = New System.Drawing.Size(145, 20)
        Me.txtOperator.TabIndex = 12
        '
        'txtShift
        '
        Me.txtShift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShift.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShift.Location = New System.Drawing.Point(1063, 36)
        Me.txtShift.MaxLength = 2
        Me.txtShift.Name = "txtShift"
        Me.txtShift.Size = New System.Drawing.Size(39, 20)
        Me.txtShift.TabIndex = 5
        Me.txtShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescription.Enabled = False
        Me.txtDescription.Location = New System.Drawing.Point(13, 109)
        Me.txtDescription.MaxLength = 100
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(261, 20)
        Me.txtDescription.TabIndex = 7
        '
        'txtCustomer
        '
        Me.txtCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomer.Location = New System.Drawing.Point(94, 36)
        Me.txtCustomer.MaxLength = 50
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(180, 20)
        Me.txtCustomer.TabIndex = 1
        '
        'lblRevisionLevel
        '
        Me.lblRevisionLevel.Location = New System.Drawing.Point(563, 36)
        Me.lblRevisionLevel.Name = "lblRevisionLevel"
        Me.lblRevisionLevel.Size = New System.Drawing.Size(85, 20)
        Me.lblRevisionLevel.TabIndex = 32
        Me.lblRevisionLevel.Text = "Blueprint Rev."
        Me.lblRevisionLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOperator
        '
        Me.lblOperator.Location = New System.Drawing.Point(885, 154)
        Me.lblOperator.Name = "lblOperator"
        Me.lblOperator.Size = New System.Drawing.Size(55, 20)
        Me.lblOperator.TabIndex = 30
        Me.lblOperator.Text = "Operator"
        Me.lblOperator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMachineNumber
        '
        Me.lblMachineNumber.Location = New System.Drawing.Point(885, 93)
        Me.lblMachineNumber.Name = "lblMachineNumber"
        Me.lblMachineNumber.Size = New System.Drawing.Size(64, 20)
        Me.lblMachineNumber.TabIndex = 29
        Me.lblMachineNumber.Text = "Machine #"
        Me.lblMachineNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShift
        '
        Me.lblShift.Location = New System.Drawing.Point(1013, 36)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(30, 20)
        Me.lblShift.TabIndex = 28
        Me.lblShift.Text = "Shift"
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(9, 150)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 20)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Comment"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtHeaderComment
        '
        Me.txtHeaderComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeaderComment.Location = New System.Drawing.Point(73, 152)
        Me.txtHeaderComment.MaxLength = 200
        Me.txtHeaderComment.Multiline = True
        Me.txtHeaderComment.Name = "txtHeaderComment"
        Me.txtHeaderComment.Size = New System.Drawing.Size(707, 45)
        Me.txtHeaderComment.TabIndex = 11
        '
        'lblCustomer
        '
        Me.lblCustomer.Location = New System.Drawing.Point(10, 36)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(100, 20)
        Me.lblCustomer.TabIndex = 14
        Me.lblCustomer.Text = "Customer"
        Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(563, 94)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 20)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "Operation"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOperation
        '
        Me.txtOperation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOperation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOperation.Location = New System.Drawing.Point(632, 94)
        Me.txtOperation.MaxLength = 50
        Me.txtOperation.Name = "txtOperation"
        Me.txtOperation.Size = New System.Drawing.Size(222, 20)
        Me.txtOperation.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(785, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 20)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "FOX Number"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboFoxNumber
        '
        Me.cboFoxNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboFoxNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFoxNumber.FormattingEnabled = True
        Me.cboFoxNumber.Location = New System.Drawing.Point(860, 36)
        Me.cboFoxNumber.Name = "cboFoxNumber"
        Me.cboFoxNumber.Size = New System.Drawing.Size(106, 21)
        Me.cboFoxNumber.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Part Number"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(312, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Blueprint #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(36, 372)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Line Comment"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLineComment
        '
        Me.txtLineComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineComment.Location = New System.Drawing.Point(216, 369)
        Me.txtLineComment.MaxLength = 50
        Me.txtLineComment.Name = "txtLineComment"
        Me.txtLineComment.Size = New System.Drawing.Size(150, 20)
        Me.txtLineComment.TabIndex = 7
        Me.txtLineComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdAddLine
        '
        Me.cmdAddLine.Location = New System.Drawing.Point(219, 413)
        Me.cmdAddLine.Name = "cmdAddLine"
        Me.cmdAddLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddLine.TabIndex = 9
        Me.cmdAddLine.Text = "Add Line"
        Me.cmdAddLine.UseVisualStyleBackColor = True
        '
        'cmdClearLineInputData
        '
        Me.cmdClearLineInputData.Location = New System.Drawing.Point(295, 413)
        Me.cmdClearLineInputData.Name = "cmdClearLineInputData"
        Me.cmdClearLineInputData.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearLineInputData.TabIndex = 10
        Me.cmdClearLineInputData.Text = "Clear"
        Me.cmdClearLineInputData.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(36, 292)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Sample Size"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(36, 332)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Inspection Method"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboInspection
        '
        Me.cboInspection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInspection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInspection.FormattingEnabled = True
        Me.cboInspection.Items.AddRange(New Object() {"Caliper", "Comparator", "Dial Indicator", "Go/NoGo Gage - gage verified to print dimension", "Height Gage", "Micrometer", "Profilomiter", "Protracter", "Square", "Tape Measure", "Visual", "Keyence IM"})
        Me.cboInspection.Location = New System.Drawing.Point(216, 330)
        Me.cboInspection.Name = "cboInspection"
        Me.cboInspection.Size = New System.Drawing.Size(150, 21)
        Me.cboInspection.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(36, 212)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Part Detail"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartDetail
        '
        Me.txtPartDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartDetail.Location = New System.Drawing.Point(216, 214)
        Me.txtPartDetail.MaxLength = 50
        Me.txtPartDetail.Name = "txtPartDetail"
        Me.txtPartDetail.Size = New System.Drawing.Size(150, 20)
        Me.txtPartDetail.TabIndex = 3
        Me.txtPartDetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(986, 730)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 4
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1063, 776)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 8
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(909, 775)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 6
        Me.cmdPrint.Text = "Print Report"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'dgvInspectionReports
        '
        Me.dgvInspectionReports.AllowDrop = True
        Me.dgvInspectionReports.AllowUserToAddRows = False
        Me.dgvInspectionReports.AllowUserToDeleteRows = False
        Me.dgvInspectionReports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInspectionReports.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInspectionReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInspectionReports.GridColor = System.Drawing.SystemColors.ControlLight
        Me.dgvInspectionReports.Location = New System.Drawing.Point(0, 0)
        Me.dgvInspectionReports.Name = "dgvInspectionReports"
        Me.dgvInspectionReports.Size = New System.Drawing.Size(852, 518)
        Me.dgvInspectionReports.TabIndex = 9
        Me.dgvInspectionReports.TabStop = False
        '
        'gpxFoxInfo
        '
        Me.gpxFoxInfo.Controls.Add(Me.cboMachineNumber)
        Me.gpxFoxInfo.Controls.Add(Me.cboBluePrint)
        Me.gpxFoxInfo.Controls.Add(Me.txtLotNumber)
        Me.gpxFoxInfo.Controls.Add(Me.lblLotNumber)
        Me.gpxFoxInfo.Controls.Add(Me.txtRevisionLevel)
        Me.gpxFoxInfo.Controls.Add(Me.txtShift)
        Me.gpxFoxInfo.Controls.Add(Me.txtPartNumber)
        Me.gpxFoxInfo.Controls.Add(Me.txtDescription)
        Me.gpxFoxInfo.Controls.Add(Me.txtOperator)
        Me.gpxFoxInfo.Controls.Add(Me.txtCustomer)
        Me.gpxFoxInfo.Controls.Add(Me.lblRevisionLevel)
        Me.gpxFoxInfo.Controls.Add(Me.Label1)
        Me.gpxFoxInfo.Controls.Add(Me.lblShift)
        Me.gpxFoxInfo.Controls.Add(Me.Label2)
        Me.gpxFoxInfo.Controls.Add(Me.lblCustomer)
        Me.gpxFoxInfo.Controls.Add(Me.lblMachineNumber)
        Me.gpxFoxInfo.Controls.Add(Me.cboFoxNumber)
        Me.gpxFoxInfo.Controls.Add(Me.lblOperator)
        Me.gpxFoxInfo.Controls.Add(Me.Label8)
        Me.gpxFoxInfo.Controls.Add(Me.txtOperation)
        Me.gpxFoxInfo.Controls.Add(Me.Label14)
        Me.gpxFoxInfo.Controls.Add(Me.Label13)
        Me.gpxFoxInfo.Controls.Add(Me.txtHeaderComment)
        Me.gpxFoxInfo.Location = New System.Drawing.Point(14, 54)
        Me.gpxFoxInfo.Name = "gpxFoxInfo"
        Me.gpxFoxInfo.Size = New System.Drawing.Size(1120, 215)
        Me.gpxFoxInfo.TabIndex = 1
        Me.gpxFoxInfo.TabStop = False
        Me.gpxFoxInfo.Text = "FOX Information"
        '
        'cboMachineNumber
        '
        Me.cboMachineNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboMachineNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMachineNumber.FormattingEnabled = True
        Me.cboMachineNumber.Location = New System.Drawing.Point(957, 93)
        Me.cboMachineNumber.Name = "cboMachineNumber"
        Me.cboMachineNumber.Size = New System.Drawing.Size(145, 21)
        Me.cboMachineNumber.TabIndex = 10
        '
        'cboBluePrint
        '
        Me.cboBluePrint.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboBluePrint.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBluePrint.FormattingEnabled = True
        Me.cboBluePrint.Location = New System.Drawing.Point(383, 36)
        Me.cboBluePrint.Name = "cboBluePrint"
        Me.cboBluePrint.Size = New System.Drawing.Size(147, 21)
        Me.cboBluePrint.TabIndex = 2
        '
        'txtLotNumber
        '
        Me.txtLotNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLotNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLotNumber.Location = New System.Drawing.Point(383, 98)
        Me.txtLotNumber.Name = "txtLotNumber"
        Me.txtLotNumber.Size = New System.Drawing.Size(147, 20)
        Me.txtLotNumber.TabIndex = 8
        '
        'lblLotNumber
        '
        Me.lblLotNumber.Location = New System.Drawing.Point(312, 96)
        Me.lblLotNumber.Name = "lblLotNumber"
        Me.lblLotNumber.Size = New System.Drawing.Size(65, 20)
        Me.lblLotNumber.TabIndex = 34
        Me.lblLotNumber.Text = "Lot #"
        Me.lblLotNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartNumber
        '
        Me.txtPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNumber.Enabled = False
        Me.txtPartNumber.Location = New System.Drawing.Point(94, 83)
        Me.txtPartNumber.MaxLength = 50
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.Size = New System.Drawing.Size(180, 20)
        Me.txtPartNumber.TabIndex = 6
        '
        'cboInspectionKey
        '
        Me.cboInspectionKey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInspectionKey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInspectionKey.FormattingEnabled = True
        Me.cboInspectionKey.Location = New System.Drawing.Point(108, 27)
        Me.cboInspectionKey.Name = "cboInspectionKey"
        Me.cboInspectionKey.Size = New System.Drawing.Size(250, 21)
        Me.cboInspectionKey.TabIndex = 0
        '
        'lblPONumber
        '
        Me.lblPONumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPONumber.Location = New System.Drawing.Point(23, 28)
        Me.lblPONumber.Name = "lblPONumber"
        Me.lblPONumber.Size = New System.Drawing.Size(79, 20)
        Me.lblPONumber.TabIndex = 25
        Me.lblPONumber.Text = "FOX-Operation"
        Me.lblPONumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxDeleteLine
        '
        Me.gpxDeleteLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxDeleteLine.Controls.Add(Me.cmdDeleteLine)
        Me.gpxDeleteLine.Controls.Add(Me.Label19)
        Me.gpxDeleteLine.Controls.Add(Me.cboLineNumber)
        Me.gpxDeleteLine.Location = New System.Drawing.Point(893, 613)
        Me.gpxDeleteLine.Name = "gpxDeleteLine"
        Me.gpxDeleteLine.Size = New System.Drawing.Size(241, 94)
        Me.gpxDeleteLine.TabIndex = 3
        Me.gpxDeleteLine.TabStop = False
        Me.gpxDeleteLine.Text = "Delete Line"
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteLine.Location = New System.Drawing.Point(161, 28)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteLine.TabIndex = 1
        Me.cmdDeleteLine.Text = "Delete Line"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(6, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 20)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = "Line Number"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLineNumber
        '
        Me.cboLineNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLineNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLineNumber.FormattingEnabled = True
        Me.cboLineNumber.Location = New System.Drawing.Point(9, 39)
        Me.cboLineNumber.Name = "cboLineNumber"
        Me.cboLineNumber.Size = New System.Drawing.Size(135, 21)
        Me.cboLineNumber.TabIndex = 0
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(909, 730)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 5
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(986, 776)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 7
        Me.cmdDelete.Text = "Delete Report"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'tabRows
        '
        Me.tabRows.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabRows.Controls.Add(Me.tbCurrentRows)
        Me.tabRows.Controls.Add(Me.tbAddNewRow)
        Me.tabRows.Location = New System.Drawing.Point(12, 275)
        Me.tabRows.Name = "tabRows"
        Me.tabRows.SelectedIndex = 0
        Me.tabRows.Size = New System.Drawing.Size(860, 544)
        Me.tabRows.TabIndex = 2
        '
        'tbCurrentRows
        '
        Me.tbCurrentRows.Controls.Add(Me.dgvInspectionReports)
        Me.tbCurrentRows.Location = New System.Drawing.Point(4, 22)
        Me.tbCurrentRows.Name = "tbCurrentRows"
        Me.tbCurrentRows.Padding = New System.Windows.Forms.Padding(3)
        Me.tbCurrentRows.Size = New System.Drawing.Size(852, 518)
        Me.tbCurrentRows.TabIndex = 0
        Me.tbCurrentRows.Text = "Current Rows"
        Me.tbCurrentRows.UseVisualStyleBackColor = True
        '
        'tbAddNewRow
        '
        Me.tbAddNewRow.Controls.Add(Me.Label6)
        Me.tbAddNewRow.Controls.Add(Me.txtPartSpec)
        Me.tbAddNewRow.Controls.Add(Me.cmdBlankLine)
        Me.tbAddNewRow.Controls.Add(Me.lblNote)
        Me.tbAddNewRow.Controls.Add(Me.cboFrequency)
        Me.tbAddNewRow.Controls.Add(Me.cboSampleSize)
        Me.tbAddNewRow.Controls.Add(Me.Label5)
        Me.tbAddNewRow.Controls.Add(Me.Label9)
        Me.tbAddNewRow.Controls.Add(Me.txtHighSpec)
        Me.tbAddNewRow.Controls.Add(Me.Label4)
        Me.tbAddNewRow.Controls.Add(Me.txtLineComment)
        Me.tbAddNewRow.Controls.Add(Me.Label3)
        Me.tbAddNewRow.Controls.Add(Me.lblHighSpec)
        Me.tbAddNewRow.Controls.Add(Me.cboInspection)
        Me.tbAddNewRow.Controls.Add(Me.cmdAddLine)
        Me.tbAddNewRow.Controls.Add(Me.lblLowSpec)
        Me.tbAddNewRow.Controls.Add(Me.cmdClearLineInputData)
        Me.tbAddNewRow.Controls.Add(Me.txtLowSpec)
        Me.tbAddNewRow.Controls.Add(Me.Label7)
        Me.tbAddNewRow.Controls.Add(Me.txtPartDetail)
        Me.tbAddNewRow.Location = New System.Drawing.Point(4, 22)
        Me.tbAddNewRow.Name = "tbAddNewRow"
        Me.tbAddNewRow.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAddNewRow.Size = New System.Drawing.Size(852, 518)
        Me.tbAddNewRow.TabIndex = 1
        Me.tbAddNewRow.Text = "Add new line"
        Me.tbAddNewRow.UseVisualStyleBackColor = True
        '
        'cmdBlankLine
        '
        Me.cmdBlankLine.Location = New System.Drawing.Point(141, 413)
        Me.cmdBlankLine.Name = "cmdBlankLine"
        Me.cmdBlankLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdBlankLine.TabIndex = 8
        Me.cmdBlankLine.Text = "Add blank Line"
        Me.cmdBlankLine.UseVisualStyleBackColor = True
        '
        'lblNote
        '
        Me.lblNote.ForeColor = System.Drawing.Color.Blue
        Me.lblNote.Location = New System.Drawing.Point(36, 125)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(306, 36)
        Me.lblNote.TabIndex = 27
        Me.lblNote.Text = "*** If specification is not a measurement input information into the LOW SPECIFIC" & _
            "ATION Field ***"
        Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboFrequency
        '
        Me.cboFrequency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFrequency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFrequency.FormattingEnabled = True
        Me.cboFrequency.Items.AddRange(New Object() {"Hourly", "Die Change", "Each Piece", "Every 15 minutes", "Every 30 minutes", "Final Inspection", "First Piece", "Thread OD", "Tool Change", "Tooling Change", "Setup", "Setup & Tool Change"})
        Me.cboFrequency.Location = New System.Drawing.Point(216, 252)
        Me.cboFrequency.Name = "cboFrequency"
        Me.cboFrequency.Size = New System.Drawing.Size(150, 21)
        Me.cboFrequency.TabIndex = 4
        '
        'cboSampleSize
        '
        Me.cboSampleSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSampleSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSampleSize.FormattingEnabled = True
        Me.cboSampleSize.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.cboSampleSize.Location = New System.Drawing.Point(216, 291)
        Me.cboSampleSize.Name = "cboSampleSize"
        Me.cboSampleSize.Size = New System.Drawing.Size(150, 21)
        Me.cboSampleSize.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(36, 252)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Frequency"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtHighSpec
        '
        Me.txtHighSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHighSpec.Location = New System.Drawing.Point(152, 67)
        Me.txtHighSpec.MaxLength = 50
        Me.txtHighSpec.Name = "txtHighSpec"
        Me.txtHighSpec.Size = New System.Drawing.Size(100, 20)
        Me.txtHighSpec.TabIndex = 1
        Me.txtHighSpec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblHighSpec
        '
        Me.lblHighSpec.Location = New System.Drawing.Point(35, 67)
        Me.lblHighSpec.Name = "lblHighSpec"
        Me.lblHighSpec.Size = New System.Drawing.Size(100, 20)
        Me.lblHighSpec.TabIndex = 21
        Me.lblHighSpec.Text = "High Specification"
        Me.lblHighSpec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLowSpec
        '
        Me.lblLowSpec.Location = New System.Drawing.Point(35, 32)
        Me.lblLowSpec.Name = "lblLowSpec"
        Me.lblLowSpec.Size = New System.Drawing.Size(100, 20)
        Me.lblLowSpec.TabIndex = 22
        Me.lblLowSpec.Text = "Low Specification"
        Me.lblLowSpec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLowSpec
        '
        Me.txtLowSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLowSpec.Location = New System.Drawing.Point(152, 32)
        Me.txtLowSpec.MaxLength = 50
        Me.txtLowSpec.Name = "txtLowSpec"
        Me.txtLowSpec.Size = New System.Drawing.Size(100, 20)
        Me.txtLowSpec.TabIndex = 0
        Me.txtLowSpec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDataGridNote
        '
        Me.txtDataGridNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDataGridNote.BackColor = System.Drawing.SystemColors.Control
        Me.txtDataGridNote.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataGridNote.ForeColor = System.Drawing.Color.Blue
        Me.txtDataGridNote.Location = New System.Drawing.Point(909, 509)
        Me.txtDataGridNote.Multiline = True
        Me.txtDataGridNote.Name = "txtDataGridNote"
        Me.txtDataGridNote.ReadOnly = True
        Me.txtDataGridNote.Size = New System.Drawing.Size(225, 40)
        Me.txtDataGridNote.TabIndex = 26
        Me.txtDataGridNote.TabStop = False
        Me.txtDataGridNote.Text = "***Any changes made in the datagrid are automatically saved***"
        '
        'gpxFirstPieceInspection
        '
        Me.gpxFirstPieceInspection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxFirstPieceInspection.Controls.Add(Me.cmdFirstInspectionEntry)
        Me.gpxFirstPieceInspection.Location = New System.Drawing.Point(893, 297)
        Me.gpxFirstPieceInspection.Name = "gpxFirstPieceInspection"
        Me.gpxFirstPieceInspection.Size = New System.Drawing.Size(241, 94)
        Me.gpxFirstPieceInspection.TabIndex = 5
        Me.gpxFirstPieceInspection.TabStop = False
        Me.gpxFirstPieceInspection.Text = "First Piece Inspection Entry"
        '
        'cmdFirstInspectionEntry
        '
        Me.cmdFirstInspectionEntry.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFirstInspectionEntry.Location = New System.Drawing.Point(97, 32)
        Me.cmdFirstInspectionEntry.Name = "cmdFirstInspectionEntry"
        Me.cmdFirstInspectionEntry.Size = New System.Drawing.Size(71, 40)
        Me.cmdFirstInspectionEntry.TabIndex = 1
        Me.cmdFirstInspectionEntry.Text = "Inspection Entry"
        Me.cmdFirstInspectionEntry.UseVisualStyleBackColor = True
        '
        'cmdViewEntries
        '
        Me.cmdViewEntries.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewEntries.Location = New System.Drawing.Point(161, 3)
        Me.cmdViewEntries.Name = "cmdViewEntries"
        Me.cmdViewEntries.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewEntries.TabIndex = 5
        Me.cmdViewEntries.Text = "View Entries"
        Me.cmdViewEntries.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Red
        Me.TextBox1.Location = New System.Drawing.Point(12, 3)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(145, 40)
        Me.TextBox1.TabIndex = 27
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "Blueprint Journal Entries Found"
        '
        'pnlBlueprintJournalEntries
        '
        Me.pnlBlueprintJournalEntries.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBlueprintJournalEntries.Controls.Add(Me.TextBox1)
        Me.pnlBlueprintJournalEntries.Controls.Add(Me.cmdViewEntries)
        Me.pnlBlueprintJournalEntries.Location = New System.Drawing.Point(893, 450)
        Me.pnlBlueprintJournalEntries.Name = "pnlBlueprintJournalEntries"
        Me.pnlBlueprintJournalEntries.Size = New System.Drawing.Size(235, 53)
        Me.pnlBlueprintJournalEntries.TabIndex = 28
        Me.pnlBlueprintJournalEntries.Visible = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(36, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Specification"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartSpec
        '
        Me.txtPartSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartSpec.Location = New System.Drawing.Point(216, 176)
        Me.txtPartSpec.MaxLength = 50
        Me.txtPartSpec.Name = "txtPartSpec"
        Me.txtPartSpec.Size = New System.Drawing.Size(150, 20)
        Me.txtPartSpec.TabIndex = 2
        Me.txtPartSpec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'InspectionReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.pnlBlueprintJournalEntries)
        Me.Controls.Add(Me.gpxFirstPieceInspection)
        Me.Controls.Add(Me.txtDataGridNote)
        Me.Controls.Add(Me.tabRows)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.gpxDeleteLine)
        Me.Controls.Add(Me.gpxFoxInfo)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.lblPONumber)
        Me.Controls.Add(Me.cboInspectionKey)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "InspectionReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Inspection Report"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvInspectionReports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxFoxInfo.ResumeLayout(False)
        Me.gpxFoxInfo.PerformLayout()
        Me.gpxDeleteLine.ResumeLayout(False)
        Me.tabRows.ResumeLayout(False)
        Me.tbCurrentRows.ResumeLayout(False)
        Me.tbAddNewRow.ResumeLayout(False)
        Me.tbAddNewRow.PerformLayout()
        Me.gpxFirstPieceInspection.ResumeLayout(False)
        Me.pnlBlueprintJournalEntries.ResumeLayout(False)
        Me.pnlBlueprintJournalEntries.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPartDetail As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboInspection As System.Windows.Forms.ComboBox
    Friend WithEvents cmdAddLine As System.Windows.Forms.Button
    Friend WithEvents cmdClearLineInputData As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboFoxNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtLineComment As System.Windows.Forms.TextBox
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtHeaderComment As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtOperation As System.Windows.Forms.TextBox
    Friend WithEvents dgvInspectionReports As System.Windows.Forms.DataGridView
    Friend WithEvents gpxFoxInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtOperator As System.Windows.Forms.TextBox
    Friend WithEvents txtShift As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionLevel As System.Windows.Forms.Label
    Friend WithEvents txtRevisionLevel As System.Windows.Forms.TextBox
    Friend WithEvents lblOperator As System.Windows.Forms.Label
    Friend WithEvents lblMachineNumber As System.Windows.Forms.Label
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents BlueprintNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gpxDeleteLine As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboLineNumber As System.Windows.Forms.ComboBox
    Friend WithEvents FOXNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboInspectionKey As System.Windows.Forms.ComboBox
    Friend WithEvents lblPONumber As System.Windows.Forms.Label
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents SpecificationColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDetailColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FrequencyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SampleSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InspectionMethodColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InspectionLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtLotNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblLotNumber As System.Windows.Forms.Label
    Friend WithEvents tabRows As System.Windows.Forms.TabControl
    Friend WithEvents tbCurrentRows As System.Windows.Forms.TabPage
    Friend WithEvents tbAddNewRow As System.Windows.Forms.TabPage
    Friend WithEvents lblHighSpec As System.Windows.Forms.Label
    Friend WithEvents lblLowSpec As System.Windows.Forms.Label
    Friend WithEvents txtLowSpec As System.Windows.Forms.TextBox
    Friend WithEvents txtHighSpec As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboSampleSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboFrequency As System.Windows.Forms.ComboBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents cboBluePrint As System.Windows.Forms.ComboBox
    Friend WithEvents txtDataGridNote As System.Windows.Forms.TextBox
    Friend WithEvents cmdBlankLine As System.Windows.Forms.Button
    Friend WithEvents gpxFirstPieceInspection As System.Windows.Forms.GroupBox
    Friend WithEvents cmdFirstInspectionEntry As System.Windows.Forms.Button
    Friend WithEvents cboMachineNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdViewEntries As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents pnlBlueprintJournalEntries As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPartSpec As System.Windows.Forms.TextBox
End Class