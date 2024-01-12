<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewWIPValue
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
        Me.gpxWIPBreakdown = New System.Windows.Forms.GroupBox
        Me.chkViewClosedProduction = New System.Windows.Forms.CheckBox
        Me.chkViewClosedFoxs = New System.Windows.Forms.CheckBox
        Me.chkTruWeldOnly = New System.Windows.Forms.CheckBox
        Me.chkTruFitOnly = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker
        Me.lblMonth = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboFOXNumber = New System.Windows.Forms.ComboBox
        Me.lblFOXNumber = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvWIPEntries = New System.Windows.Forms.DataGridView
        Me.grpTotals = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTotalMachineOverhead = New System.Windows.Forms.TextBox
        Me.txtTotalWIPValue = New System.Windows.Forms.TextBox
        Me.lblTotalPieceValue = New System.Windows.Forms.Label
        Me.txtTotalLaborCost = New System.Windows.Forms.TextBox
        Me.txtTotalSteelValue = New System.Windows.Forms.TextBox
        Me.lblTotalSteelValue = New System.Windows.Forms.Label
        Me.lblTotalLaborCost = New System.Windows.Forms.Label
        Me.lblTotalMachineOverhead = New System.Windows.Forms.Label
        Me.bgwkCalculateCosts = New System.ComponentModel.BackgroundWorker
        Me.pnlCancelBGWK = New System.Windows.Forms.Panel
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.lblBGWKWaitMessage = New System.Windows.Forms.Label
        Me.tmrChangeText = New System.Windows.Forms.Timer(Me.components)
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.gpxWIPTotals = New System.Windows.Forms.GroupBox
        Me.cmdViewWIPTotals = New System.Windows.Forms.Button
        Me.cmdClearWIPTotals = New System.Windows.Forms.Button
        Me.cboWIPTotalFOX = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.bgwkGenerateWIPTotals = New System.ComponentModel.BackgroundWorker
        Me.gpxWIPBreakdown.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvWIPEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTotals.SuspendLayout()
        Me.pnlCancelBGWK.SuspendLayout()
        Me.gpxWIPTotals.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpxWIPBreakdown
        '
        Me.gpxWIPBreakdown.Controls.Add(Me.chkViewClosedProduction)
        Me.gpxWIPBreakdown.Controls.Add(Me.chkViewClosedFoxs)
        Me.gpxWIPBreakdown.Controls.Add(Me.chkTruWeldOnly)
        Me.gpxWIPBreakdown.Controls.Add(Me.chkTruFitOnly)
        Me.gpxWIPBreakdown.Controls.Add(Me.dtpEndDate)
        Me.gpxWIPBreakdown.Controls.Add(Me.Label2)
        Me.gpxWIPBreakdown.Controls.Add(Me.dtpStartDate)
        Me.gpxWIPBreakdown.Controls.Add(Me.lblMonth)
        Me.gpxWIPBreakdown.Controls.Add(Me.cmdView)
        Me.gpxWIPBreakdown.Controls.Add(Me.cmdClear)
        Me.gpxWIPBreakdown.Controls.Add(Me.cboFOXNumber)
        Me.gpxWIPBreakdown.Controls.Add(Me.lblFOXNumber)
        Me.gpxWIPBreakdown.Location = New System.Drawing.Point(29, 41)
        Me.gpxWIPBreakdown.Name = "gpxWIPBreakdown"
        Me.gpxWIPBreakdown.Size = New System.Drawing.Size(254, 366)
        Me.gpxWIPBreakdown.TabIndex = 0
        Me.gpxWIPBreakdown.TabStop = False
        Me.gpxWIPBreakdown.Text = "View WIP Breakdown By Filter"
        '
        'chkViewClosedProduction
        '
        Me.chkViewClosedProduction.AutoSize = True
        Me.chkViewClosedProduction.Location = New System.Drawing.Point(94, 234)
        Me.chkViewClosedProduction.Name = "chkViewClosedProduction"
        Me.chkViewClosedProduction.Size = New System.Drawing.Size(149, 17)
        Me.chkViewClosedProduction.TabIndex = 57
        Me.chkViewClosedProduction.Text = "View CLOSED Production"
        Me.chkViewClosedProduction.UseVisualStyleBackColor = True
        '
        'chkViewClosedFoxs
        '
        Me.chkViewClosedFoxs.AutoSize = True
        Me.chkViewClosedFoxs.Location = New System.Drawing.Point(94, 210)
        Me.chkViewClosedFoxs.Name = "chkViewClosedFoxs"
        Me.chkViewClosedFoxs.Size = New System.Drawing.Size(125, 17)
        Me.chkViewClosedFoxs.TabIndex = 56
        Me.chkViewClosedFoxs.Text = "View INACTIVE FOX"
        Me.chkViewClosedFoxs.UseVisualStyleBackColor = True
        '
        'chkTruWeldOnly
        '
        Me.chkTruWeldOnly.AutoSize = True
        Me.chkTruWeldOnly.Location = New System.Drawing.Point(94, 186)
        Me.chkTruWeldOnly.Name = "chkTruWeldOnly"
        Me.chkTruWeldOnly.Size = New System.Drawing.Size(94, 17)
        Me.chkTruWeldOnly.TabIndex = 55
        Me.chkTruWeldOnly.Text = "Tru-Weld Only"
        Me.chkTruWeldOnly.UseVisualStyleBackColor = True
        '
        'chkTruFitOnly
        '
        Me.chkTruFitOnly.AutoSize = True
        Me.chkTruFitOnly.Location = New System.Drawing.Point(94, 162)
        Me.chkTruFitOnly.Name = "chkTruFitOnly"
        Me.chkTruFitOnly.Size = New System.Drawing.Size(80, 17)
        Me.chkTruFitOnly.TabIndex = 54
        Me.chkTruFitOnly.Text = "Tru-Fit Only"
        Me.chkTruFitOnly.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = ""
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(92, 123)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(147, 20)
        Me.dtpEndDate.TabIndex = 50
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(9, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 20)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "End Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = ""
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(92, 77)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(147, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'lblMonth
        '
        Me.lblMonth.Location = New System.Drawing.Point(9, 77)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(55, 20)
        Me.lblMonth.TabIndex = 49
        Me.lblMonth.Text = "Start Date"
        Me.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdView.Location = New System.Drawing.Point(94, 308)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 40)
        Me.cmdView.TabIndex = 4
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(170, 308)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cboFOXNumber
        '
        Me.cboFOXNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFOXNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFOXNumber.FormattingEnabled = True
        Me.cboFOXNumber.Location = New System.Drawing.Point(93, 37)
        Me.cboFOXNumber.Name = "cboFOXNumber"
        Me.cboFOXNumber.Size = New System.Drawing.Size(147, 21)
        Me.cboFOXNumber.TabIndex = 0
        '
        'lblFOXNumber
        '
        Me.lblFOXNumber.AutoSize = True
        Me.lblFOXNumber.Location = New System.Drawing.Point(9, 40)
        Me.lblFOXNumber.Name = "lblFOXNumber"
        Me.lblFOXNumber.Size = New System.Drawing.Size(68, 13)
        Me.lblFOXNumber.TabIndex = 0
        Me.lblFOXNumber.Text = "FOX Number"
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(963, 778)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 45
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1044, 24)
        Me.MenuStrip1.TabIndex = 46
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
        'dgvWIPEntries
        '
        Me.dgvWIPEntries.AllowUserToAddRows = False
        Me.dgvWIPEntries.AllowUserToDeleteRows = False
        Me.dgvWIPEntries.AllowUserToOrderColumns = True
        Me.dgvWIPEntries.AllowUserToResizeColumns = False
        Me.dgvWIPEntries.AllowUserToResizeRows = False
        Me.dgvWIPEntries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvWIPEntries.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvWIPEntries.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvWIPEntries.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvWIPEntries.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvWIPEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvWIPEntries.ColumnHeadersVisible = False
        Me.dgvWIPEntries.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvWIPEntries.Location = New System.Drawing.Point(289, 41)
        Me.dgvWIPEntries.Name = "dgvWIPEntries"
        Me.dgvWIPEntries.ReadOnly = True
        Me.dgvWIPEntries.RowHeadersVisible = False
        Me.dgvWIPEntries.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvWIPEntries.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvWIPEntries.ShowCellErrors = False
        Me.dgvWIPEntries.ShowCellToolTips = False
        Me.dgvWIPEntries.ShowEditingIcon = False
        Me.dgvWIPEntries.ShowRowErrors = False
        Me.dgvWIPEntries.Size = New System.Drawing.Size(743, 731)
        Me.dgvWIPEntries.TabIndex = 47
        '
        'grpTotals
        '
        Me.grpTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpTotals.Controls.Add(Me.Label1)
        Me.grpTotals.Controls.Add(Me.txtTotalMachineOverhead)
        Me.grpTotals.Controls.Add(Me.txtTotalWIPValue)
        Me.grpTotals.Controls.Add(Me.lblTotalPieceValue)
        Me.grpTotals.Controls.Add(Me.txtTotalLaborCost)
        Me.grpTotals.Controls.Add(Me.txtTotalSteelValue)
        Me.grpTotals.Controls.Add(Me.lblTotalSteelValue)
        Me.grpTotals.Controls.Add(Me.lblTotalLaborCost)
        Me.grpTotals.Controls.Add(Me.lblTotalMachineOverhead)
        Me.grpTotals.Location = New System.Drawing.Point(29, 618)
        Me.grpTotals.Name = "grpTotals"
        Me.grpTotals.Size = New System.Drawing.Size(254, 200)
        Me.grpTotals.TabIndex = 50
        Me.grpTotals.TabStop = False
        Me.grpTotals.Text = "Totals"
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(21, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 23)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Totals are for displayed FOX Data"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalMachineOverhead
        '
        Me.txtTotalMachineOverhead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalMachineOverhead.Location = New System.Drawing.Point(109, 93)
        Me.txtTotalMachineOverhead.Name = "txtTotalMachineOverhead"
        Me.txtTotalMachineOverhead.ReadOnly = True
        Me.txtTotalMachineOverhead.Size = New System.Drawing.Size(130, 20)
        Me.txtTotalMachineOverhead.TabIndex = 55
        Me.txtTotalMachineOverhead.TabStop = False
        Me.txtTotalMachineOverhead.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTotalWIPValue
        '
        Me.txtTotalWIPValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalWIPValue.Location = New System.Drawing.Point(109, 119)
        Me.txtTotalWIPValue.Name = "txtTotalWIPValue"
        Me.txtTotalWIPValue.ReadOnly = True
        Me.txtTotalWIPValue.Size = New System.Drawing.Size(130, 20)
        Me.txtTotalWIPValue.TabIndex = 52
        Me.txtTotalWIPValue.TabStop = False
        Me.txtTotalWIPValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTotalPieceValue
        '
        Me.lblTotalPieceValue.Location = New System.Drawing.Point(6, 119)
        Me.lblTotalPieceValue.Name = "lblTotalPieceValue"
        Me.lblTotalPieceValue.Size = New System.Drawing.Size(106, 20)
        Me.lblTotalPieceValue.TabIndex = 0
        Me.lblTotalPieceValue.Text = "Total WIP Value"
        Me.lblTotalPieceValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalLaborCost
        '
        Me.txtTotalLaborCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalLaborCost.Location = New System.Drawing.Point(110, 67)
        Me.txtTotalLaborCost.Name = "txtTotalLaborCost"
        Me.txtTotalLaborCost.ReadOnly = True
        Me.txtTotalLaborCost.Size = New System.Drawing.Size(129, 20)
        Me.txtTotalLaborCost.TabIndex = 54
        Me.txtTotalLaborCost.TabStop = False
        Me.txtTotalLaborCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTotalSteelValue
        '
        Me.txtTotalSteelValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalSteelValue.Location = New System.Drawing.Point(109, 41)
        Me.txtTotalSteelValue.Name = "txtTotalSteelValue"
        Me.txtTotalSteelValue.ReadOnly = True
        Me.txtTotalSteelValue.Size = New System.Drawing.Size(130, 20)
        Me.txtTotalSteelValue.TabIndex = 53
        Me.txtTotalSteelValue.TabStop = False
        Me.txtTotalSteelValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTotalSteelValue
        '
        Me.lblTotalSteelValue.Location = New System.Drawing.Point(6, 41)
        Me.lblTotalSteelValue.Name = "lblTotalSteelValue"
        Me.lblTotalSteelValue.Size = New System.Drawing.Size(106, 20)
        Me.lblTotalSteelValue.TabIndex = 49
        Me.lblTotalSteelValue.Text = "Total Steel Cost"
        Me.lblTotalSteelValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalLaborCost
        '
        Me.lblTotalLaborCost.Location = New System.Drawing.Point(6, 67)
        Me.lblTotalLaborCost.Name = "lblTotalLaborCost"
        Me.lblTotalLaborCost.Size = New System.Drawing.Size(106, 20)
        Me.lblTotalLaborCost.TabIndex = 50
        Me.lblTotalLaborCost.Text = "Total Labor Cost"
        Me.lblTotalLaborCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalMachineOverhead
        '
        Me.lblTotalMachineOverhead.Location = New System.Drawing.Point(6, 93)
        Me.lblTotalMachineOverhead.Name = "lblTotalMachineOverhead"
        Me.lblTotalMachineOverhead.Size = New System.Drawing.Size(106, 20)
        Me.lblTotalMachineOverhead.TabIndex = 51
        Me.lblTotalMachineOverhead.Text = "Total Machine O/H"
        Me.lblTotalMachineOverhead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'bgwkCalculateCosts
        '
        Me.bgwkCalculateCosts.WorkerSupportsCancellation = True
        '
        'pnlCancelBGWK
        '
        Me.pnlCancelBGWK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlCancelBGWK.Controls.Add(Me.cmdCancel)
        Me.pnlCancelBGWK.Controls.Add(Me.lblBGWKWaitMessage)
        Me.pnlCancelBGWK.Location = New System.Drawing.Point(530, 323)
        Me.pnlCancelBGWK.Name = "pnlCancelBGWK"
        Me.pnlCancelBGWK.Size = New System.Drawing.Size(349, 100)
        Me.pnlCancelBGWK.TabIndex = 51
        Me.pnlCancelBGWK.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(131, 44)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(71, 40)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'lblBGWKWaitMessage
        '
        Me.lblBGWKWaitMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBGWKWaitMessage.AutoSize = True
        Me.lblBGWKWaitMessage.ForeColor = System.Drawing.Color.Blue
        Me.lblBGWKWaitMessage.Location = New System.Drawing.Point(102, 19)
        Me.lblBGWKWaitMessage.Name = "lblBGWKWaitMessage"
        Me.lblBGWKWaitMessage.Size = New System.Drawing.Size(139, 13)
        Me.lblBGWKWaitMessage.TabIndex = 0
        Me.lblBGWKWaitMessage.Text = "Building Report Please Wait"
        '
        'tmrChangeText
        '
        Me.tmrChangeText.Interval = 1000
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Location = New System.Drawing.Point(886, 778)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 52
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'gpxWIPTotals
        '
        Me.gpxWIPTotals.Controls.Add(Me.cmdViewWIPTotals)
        Me.gpxWIPTotals.Controls.Add(Me.cmdClearWIPTotals)
        Me.gpxWIPTotals.Controls.Add(Me.cboWIPTotalFOX)
        Me.gpxWIPTotals.Controls.Add(Me.Label5)
        Me.gpxWIPTotals.Location = New System.Drawing.Point(29, 420)
        Me.gpxWIPTotals.Name = "gpxWIPTotals"
        Me.gpxWIPTotals.Size = New System.Drawing.Size(254, 133)
        Me.gpxWIPTotals.TabIndex = 52
        Me.gpxWIPTotals.TabStop = False
        Me.gpxWIPTotals.Text = "View WIP Totals BY Filter"
        '
        'cmdViewWIPTotals
        '
        Me.cmdViewWIPTotals.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdViewWIPTotals.Location = New System.Drawing.Point(93, 78)
        Me.cmdViewWIPTotals.Name = "cmdViewWIPTotals"
        Me.cmdViewWIPTotals.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewWIPTotals.TabIndex = 4
        Me.cmdViewWIPTotals.Text = "View"
        Me.cmdViewWIPTotals.UseVisualStyleBackColor = True
        '
        'cmdClearWIPTotals
        '
        Me.cmdClearWIPTotals.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClearWIPTotals.Location = New System.Drawing.Point(169, 78)
        Me.cmdClearWIPTotals.Name = "cmdClearWIPTotals"
        Me.cmdClearWIPTotals.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearWIPTotals.TabIndex = 5
        Me.cmdClearWIPTotals.Text = "Clear"
        Me.cmdClearWIPTotals.UseVisualStyleBackColor = True
        '
        'cboWIPTotalFOX
        '
        Me.cboWIPTotalFOX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboWIPTotalFOX.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboWIPTotalFOX.FormattingEnabled = True
        Me.cboWIPTotalFOX.Location = New System.Drawing.Point(92, 41)
        Me.cboWIPTotalFOX.Name = "cboWIPTotalFOX"
        Me.cboWIPTotalFOX.Size = New System.Drawing.Size(147, 21)
        Me.cboWIPTotalFOX.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "FOX Number"
        '
        'bgwkGenerateWIPTotals
        '
        Me.bgwkGenerateWIPTotals.WorkerSupportsCancellation = True
        '
        'ViewWIPValue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1044, 825)
        Me.Controls.Add(Me.gpxWIPTotals)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.pnlCancelBGWK)
        Me.Controls.Add(Me.grpTotals)
        Me.Controls.Add(Me.dgvWIPEntries)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxWIPBreakdown)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "ViewWIPValue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View WIP Value"
        Me.gpxWIPBreakdown.ResumeLayout(False)
        Me.gpxWIPBreakdown.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvWIPEntries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTotals.ResumeLayout(False)
        Me.grpTotals.PerformLayout()
        Me.pnlCancelBGWK.ResumeLayout(False)
        Me.pnlCancelBGWK.PerformLayout()
        Me.gpxWIPTotals.ResumeLayout(False)
        Me.gpxWIPTotals.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpxWIPBreakdown As System.Windows.Forms.GroupBox
    Friend WithEvents cboFOXNumber As System.Windows.Forms.ComboBox
    Friend WithEvents lblFOXNumber As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvWIPEntries As System.Windows.Forms.DataGridView
    Friend WithEvents grpTotals As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotalSteelValue As System.Windows.Forms.Label
    Friend WithEvents lblTotalPieceValue As System.Windows.Forms.Label
    Friend WithEvents lblTotalMachineOverhead As System.Windows.Forms.Label
    Friend WithEvents lblTotalLaborCost As System.Windows.Forms.Label
    Friend WithEvents txtTotalMachineOverhead As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalLaborCost As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalSteelValue As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalWIPValue As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents bgwkCalculateCosts As System.ComponentModel.BackgroundWorker
    Friend WithEvents pnlCancelBGWK As System.Windows.Forms.Panel
    Friend WithEvents lblBGWKWaitMessage As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents tmrChangeText As System.Windows.Forms.Timer
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents gpxWIPTotals As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewWIPTotals As System.Windows.Forms.Button
    Friend WithEvents cmdClearWIPTotals As System.Windows.Forms.Button
    Friend WithEvents cboWIPTotalFOX As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents bgwkGenerateWIPTotals As System.ComponentModel.BackgroundWorker
    Friend WithEvents chkTruWeldOnly As System.Windows.Forms.CheckBox
    Friend WithEvents chkTruFitOnly As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewClosedFoxs As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewClosedProduction As System.Windows.Forms.CheckBox

End Class
