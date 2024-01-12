<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewWIP
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboItemDiameter = New System.Windows.Forms.ComboBox
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkOrderByPartNumber = New System.Windows.Forms.CheckBox
        Me.chkBeginningOfTime = New System.Windows.Forms.CheckBox
        Me.chkShowTFP = New System.Windows.Forms.CheckBox
        Me.chkShowTWD = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker
        Me.lblEndDate = New System.Windows.Forms.Label
        Me.lblStartDate = New System.Windows.Forms.Label
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
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.bgwkGetWIP = New System.ComponentModel.BackgroundWorker
        Me.pnlCancelBGWK = New System.Windows.Forms.Panel
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.lblBGWKWaitMessage = New System.Windows.Forms.Label
        Me.tmrChangeText = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvWIPEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCancelBGWK.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboItemDiameter)
        Me.GroupBox1.Controls.Add(Me.cboItemClass)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chkOrderByPartNumber)
        Me.GroupBox1.Controls.Add(Me.chkBeginningOfTime)
        Me.GroupBox1.Controls.Add(Me.chkShowTFP)
        Me.GroupBox1.Controls.Add(Me.chkShowTWD)
        Me.GroupBox1.Controls.Add(Me.dtpEndDate)
        Me.GroupBox1.Controls.Add(Me.dtpStartDate)
        Me.GroupBox1.Controls.Add(Me.lblEndDate)
        Me.GroupBox1.Controls.Add(Me.lblStartDate)
        Me.GroupBox1.Controls.Add(Me.cmdView)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.cboFOXNumber)
        Me.GroupBox1.Controls.Add(Me.lblFOXNumber)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 502)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View By Filters"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 220)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 21)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Item Diameter"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboItemDiameter
        '
        Me.cboItemDiameter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemDiameter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemDiameter.FormattingEnabled = True
        Me.cboItemDiameter.Items.AddRange(New Object() {"1/16", "1/8", "3/16", "1/4", "5/16", "3/8", "7/16", "1/2", "9/16", "5/8", "11/16", "3/4", "13/16", "7/8", "15/16", "1", "1-1/16", "1-1/8", "1-3/16", "1-1/4", "1-5/16", "1-3/8", "1-7/16", "1-1/2"})
        Me.cboItemDiameter.Location = New System.Drawing.Point(105, 220)
        Me.cboItemDiameter.Name = "cboItemDiameter"
        Me.cboItemDiameter.Size = New System.Drawing.Size(183, 21)
        Me.cboItemDiameter.TabIndex = 4
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(105, 179)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(183, 21)
        Me.cboItemClass.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 179)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 21)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Item Class"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkOrderByPartNumber
        '
        Me.chkOrderByPartNumber.AutoSize = True
        Me.chkOrderByPartNumber.Location = New System.Drawing.Point(105, 399)
        Me.chkOrderByPartNumber.Name = "chkOrderByPartNumber"
        Me.chkOrderByPartNumber.Size = New System.Drawing.Size(129, 17)
        Me.chkOrderByPartNumber.TabIndex = 8
        Me.chkOrderByPartNumber.Text = "Order By Part Number"
        Me.chkOrderByPartNumber.UseVisualStyleBackColor = True
        '
        'chkBeginningOfTime
        '
        Me.chkBeginningOfTime.AutoSize = True
        Me.chkBeginningOfTime.Location = New System.Drawing.Point(105, 353)
        Me.chkBeginningOfTime.Name = "chkBeginningOfTime"
        Me.chkBeginningOfTime.Size = New System.Drawing.Size(113, 17)
        Me.chkBeginningOfTime.TabIndex = 7
        Me.chkBeginningOfTime.Text = "Beginning Of Time"
        Me.chkBeginningOfTime.UseVisualStyleBackColor = True
        '
        'chkShowTFP
        '
        Me.chkShowTFP.AutoSize = True
        Me.chkShowTFP.Checked = True
        Me.chkShowTFP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowTFP.Location = New System.Drawing.Point(105, 133)
        Me.chkShowTFP.Name = "chkShowTFP"
        Me.chkShowTFP.Size = New System.Drawing.Size(76, 17)
        Me.chkShowTFP.TabIndex = 2
        Me.chkShowTFP.Text = "Show TFP"
        Me.chkShowTFP.UseVisualStyleBackColor = True
        '
        'chkShowTWD
        '
        Me.chkShowTWD.AutoSize = True
        Me.chkShowTWD.Checked = True
        Me.chkShowTWD.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowTWD.Location = New System.Drawing.Point(105, 93)
        Me.chkShowTWD.Name = "chkShowTWD"
        Me.chkShowTWD.Size = New System.Drawing.Size(82, 17)
        Me.chkShowTWD.TabIndex = 1
        Me.chkShowTWD.Text = "Show TWD"
        Me.chkShowTWD.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(105, 298)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(182, 20)
        Me.dtpEndDate.TabIndex = 6
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(105, 261)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(182, 20)
        Me.dtpStartDate.TabIndex = 5
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(6, 298)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(52, 20)
        Me.lblEndDate.TabIndex = 50
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(6, 261)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(55, 20)
        Me.lblStartDate.TabIndex = 49
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdView.Location = New System.Drawing.Point(139, 441)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 40)
        Me.cmdView.TabIndex = 9
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(216, 441)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 10
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cboFOXNumber
        '
        Me.cboFOXNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFOXNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFOXNumber.FormattingEnabled = True
        Me.cboFOXNumber.Location = New System.Drawing.Point(105, 43)
        Me.cboFOXNumber.Name = "cboFOXNumber"
        Me.cboFOXNumber.Size = New System.Drawing.Size(183, 21)
        Me.cboFOXNumber.TabIndex = 0
        '
        'lblFOXNumber
        '
        Me.lblFOXNumber.Location = New System.Drawing.Point(6, 43)
        Me.lblFOXNumber.Name = "lblFOXNumber"
        Me.lblFOXNumber.Size = New System.Drawing.Size(68, 21)
        Me.lblFOXNumber.TabIndex = 0
        Me.lblFOXNumber.Text = "FOX Number"
        Me.lblFOXNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(961, 806)
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
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
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
        Me.dgvWIPEntries.Location = New System.Drawing.Point(347, 27)
        Me.dgvWIPEntries.Name = "dgvWIPEntries"
        Me.dgvWIPEntries.ReadOnly = True
        Me.dgvWIPEntries.RowHeadersVisible = False
        Me.dgvWIPEntries.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvWIPEntries.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvWIPEntries.Size = New System.Drawing.Size(683, 773)
        Me.dgvWIPEntries.TabIndex = 47
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Location = New System.Drawing.Point(884, 806)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 48
        Me.cmdPrint.Text = "Print List"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'bgwkGetWIP
        '
        Me.bgwkGetWIP.WorkerSupportsCancellation = True
        '
        'pnlCancelBGWK
        '
        Me.pnlCancelBGWK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlCancelBGWK.Controls.Add(Me.cmdCancel)
        Me.pnlCancelBGWK.Controls.Add(Me.lblBGWKWaitMessage)
        Me.pnlCancelBGWK.Location = New System.Drawing.Point(598, 321)
        Me.pnlCancelBGWK.Name = "pnlCancelBGWK"
        Me.pnlCancelBGWK.Size = New System.Drawing.Size(266, 100)
        Me.pnlCancelBGWK.TabIndex = 49
        Me.pnlCancelBGWK.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(95, 50)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(71, 40)
        Me.cmdCancel.TabIndex = 51
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'lblBGWKWaitMessage
        '
        Me.lblBGWKWaitMessage.AutoSize = True
        Me.lblBGWKWaitMessage.ForeColor = System.Drawing.Color.Blue
        Me.lblBGWKWaitMessage.Location = New System.Drawing.Point(55, 21)
        Me.lblBGWKWaitMessage.Name = "lblBGWKWaitMessage"
        Me.lblBGWKWaitMessage.Size = New System.Drawing.Size(130, 13)
        Me.lblBGWKWaitMessage.TabIndex = 0
        Me.lblBGWKWaitMessage.Text = "Building report please wait"
        '
        'tmrChangeText
        '
        Me.tmrChangeText.Interval = 1000
        '
        'ViewWIP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 853)
        Me.Controls.Add(Me.pnlCancelBGWK)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.dgvWIPEntries)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ViewWIP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Work In Progress"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvWIPEntries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCancelBGWK.ResumeLayout(False)
        Me.pnlCancelBGWK.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
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
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvWIPEntries As System.Windows.Forms.DataGridView
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents chkShowTFP As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowTWD As System.Windows.Forms.CheckBox
    Friend WithEvents bgwkGetWIP As System.ComponentModel.BackgroundWorker
    Friend WithEvents pnlCancelBGWK As System.Windows.Forms.Panel
    Friend WithEvents lblBGWKWaitMessage As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents tmrChangeText As System.Windows.Forms.Timer
    Friend WithEvents chkBeginningOfTime As System.Windows.Forms.CheckBox
    Friend WithEvents chkOrderByPartNumber As System.Windows.Forms.CheckBox
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboItemDiameter As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
