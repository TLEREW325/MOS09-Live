<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SteelAdjustmentForm
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
        Me.DeleteAdjustmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintAdjustmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnLockBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxAdjustmentEntry = New System.Windows.Forms.GroupBox
        Me.lblOldSteelType = New System.Windows.Forms.Label
        Me.lblSteelTypeLabel = New System.Windows.Forms.Label
        Me.txtCoilID = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkChangeCoilSteelType = New System.Windows.Forms.CheckBox
        Me.lblQOHLabel = New System.Windows.Forms.Label
        Me.lblQOH = New System.Windows.Forms.Label
        Me.cboAdjustSteelSize = New System.Windows.Forms.ComboBox
        Me.cboAdjustCarbon = New System.Windows.Forms.ComboBox
        Me.txtAdjustmentTotal = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtAdjustmentCost = New System.Windows.Forms.TextBox
        Me.txtAdjustmentWeight = New System.Windows.Forms.TextBox
        Me.cmdGenerateAdjustmentNumber = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdEnter = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblAdjustSteelSize = New System.Windows.Forms.Label
        Me.lblAdjustCarbon = New System.Windows.Forms.Label
        Me.cboAdjustmentNumber = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpAdjustmentDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboDeleteLine = New System.Windows.Forms.ComboBox
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.gpxPostData = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmdPostAdjustment = New System.Windows.Forms.Button
        Me.gpxBatchTotals = New System.Windows.Forms.GroupBox
        Me.txtTotalItems = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtTotalCost = New System.Windows.Forms.TextBox
        Me.txtTotalWeight = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.gpxAdjustmentBatch = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtBatchStatus = New System.Windows.Forms.TextBox
        Me.cboAdjustmentBatchNumber = New System.Windows.Forms.ComboBox
        Me.cmdBatchNumber = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdClearBatch = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdDeleteAdjustment = New System.Windows.Forms.Button
        Me.lbDeleteAdjustmentNumber = New System.Windows.Forms.Label
        Me.dgvSteelAdjustmentLines = New System.Windows.Forms.DataGridView
        Me.SteelAdjustmentKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCarbonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ChangeRMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ChangeCoilIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LockedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrintDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelAdjustmentTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.SteelAdjustmentTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelAdjustmentTableTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxAdjustmentEntry.SuspendLayout()
        Me.gpxPostData.SuspendLayout()
        Me.gpxBatchTotals.SuspendLayout()
        Me.gpxAdjustmentBatch.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvSteelAdjustmentLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelAdjustmentTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteAdjustmentToolStripMenuItem, Me.PrintAdjustmentToolStripMenuItem, Me.ClearFormToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'DeleteAdjustmentToolStripMenuItem
        '
        Me.DeleteAdjustmentToolStripMenuItem.Name = "DeleteAdjustmentToolStripMenuItem"
        Me.DeleteAdjustmentToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.DeleteAdjustmentToolStripMenuItem.Text = "Delete Adjustment"
        '
        'PrintAdjustmentToolStripMenuItem
        '
        Me.PrintAdjustmentToolStripMenuItem.Name = "PrintAdjustmentToolStripMenuItem"
        Me.PrintAdjustmentToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.PrintAdjustmentToolStripMenuItem.Text = "Print Adjustment"
        '
        'ClearFormToolStripMenuItem
        '
        Me.ClearFormToolStripMenuItem.Name = "ClearFormToolStripMenuItem"
        Me.ClearFormToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.ClearFormToolStripMenuItem.Text = "Clear Form"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UnLockBatchToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'UnLockBatchToolStripMenuItem
        '
        Me.UnLockBatchToolStripMenuItem.Name = "UnLockBatchToolStripMenuItem"
        Me.UnLockBatchToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.UnLockBatchToolStripMenuItem.Text = "Un-Lock Batch"
        Me.UnLockBatchToolStripMenuItem.Visible = False
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
        'gpxAdjustmentEntry
        '
        Me.gpxAdjustmentEntry.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gpxAdjustmentEntry.Controls.Add(Me.lblOldSteelType)
        Me.gpxAdjustmentEntry.Controls.Add(Me.lblSteelTypeLabel)
        Me.gpxAdjustmentEntry.Controls.Add(Me.txtCoilID)
        Me.gpxAdjustmentEntry.Controls.Add(Me.Label5)
        Me.gpxAdjustmentEntry.Controls.Add(Me.chkChangeCoilSteelType)
        Me.gpxAdjustmentEntry.Controls.Add(Me.lblQOHLabel)
        Me.gpxAdjustmentEntry.Controls.Add(Me.lblQOH)
        Me.gpxAdjustmentEntry.Controls.Add(Me.cboAdjustSteelSize)
        Me.gpxAdjustmentEntry.Controls.Add(Me.cboAdjustCarbon)
        Me.gpxAdjustmentEntry.Controls.Add(Me.txtAdjustmentTotal)
        Me.gpxAdjustmentEntry.Controls.Add(Me.Label10)
        Me.gpxAdjustmentEntry.Controls.Add(Me.txtAdjustmentCost)
        Me.gpxAdjustmentEntry.Controls.Add(Me.txtAdjustmentWeight)
        Me.gpxAdjustmentEntry.Controls.Add(Me.cmdGenerateAdjustmentNumber)
        Me.gpxAdjustmentEntry.Controls.Add(Me.Label8)
        Me.gpxAdjustmentEntry.Controls.Add(Me.cmdClear)
        Me.gpxAdjustmentEntry.Controls.Add(Me.cmdEnter)
        Me.gpxAdjustmentEntry.Controls.Add(Me.Label7)
        Me.gpxAdjustmentEntry.Controls.Add(Me.Label3)
        Me.gpxAdjustmentEntry.Controls.Add(Me.txtComment)
        Me.gpxAdjustmentEntry.Controls.Add(Me.Label6)
        Me.gpxAdjustmentEntry.Controls.Add(Me.lblAdjustSteelSize)
        Me.gpxAdjustmentEntry.Controls.Add(Me.lblAdjustCarbon)
        Me.gpxAdjustmentEntry.Controls.Add(Me.cboAdjustmentNumber)
        Me.gpxAdjustmentEntry.Controls.Add(Me.Label1)
        Me.gpxAdjustmentEntry.Location = New System.Drawing.Point(30, 198)
        Me.gpxAdjustmentEntry.Name = "gpxAdjustmentEntry"
        Me.gpxAdjustmentEntry.Size = New System.Drawing.Size(300, 613)
        Me.gpxAdjustmentEntry.TabIndex = 3
        Me.gpxAdjustmentEntry.TabStop = False
        Me.gpxAdjustmentEntry.Text = "Steel Adjustment Entry/Edit"
        '
        'lblOldSteelType
        '
        Me.lblOldSteelType.ForeColor = System.Drawing.Color.Blue
        Me.lblOldSteelType.Location = New System.Drawing.Point(16, 517)
        Me.lblOldSteelType.Name = "lblOldSteelType"
        Me.lblOldSteelType.Size = New System.Drawing.Size(274, 20)
        Me.lblOldSteelType.TabIndex = 29
        Me.lblOldSteelType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSteelTypeLabel
        '
        Me.lblSteelTypeLabel.Location = New System.Drawing.Point(13, 494)
        Me.lblSteelTypeLabel.Name = "lblSteelTypeLabel"
        Me.lblSteelTypeLabel.Size = New System.Drawing.Size(79, 20)
        Me.lblSteelTypeLabel.TabIndex = 28
        Me.lblSteelTypeLabel.Text = "Old Steel Type"
        Me.lblSteelTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCoilID
        '
        Me.txtCoilID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoilID.Location = New System.Drawing.Point(68, 464)
        Me.txtCoilID.Name = "txtCoilID"
        Me.txtCoilID.ReadOnly = True
        Me.txtCoilID.Size = New System.Drawing.Size(222, 20)
        Me.txtCoilID.TabIndex = 27
        Me.txtCoilID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(13, 465)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 20)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Coil ID:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkChangeCoilSteelType
        '
        Me.chkChangeCoilSteelType.AutoSize = True
        Me.chkChangeCoilSteelType.ForeColor = System.Drawing.Color.Blue
        Me.chkChangeCoilSteelType.Location = New System.Drawing.Point(16, 440)
        Me.chkChangeCoilSteelType.Name = "chkChangeCoilSteelType"
        Me.chkChangeCoilSteelType.Size = New System.Drawing.Size(241, 17)
        Me.chkChangeCoilSteelType.TabIndex = 25
        Me.chkChangeCoilSteelType.Text = "Check to change steel type for a specific coil."
        Me.chkChangeCoilSteelType.UseVisualStyleBackColor = True
        '
        'lblQOHLabel
        '
        Me.lblQOHLabel.ForeColor = System.Drawing.Color.Blue
        Me.lblQOHLabel.Location = New System.Drawing.Point(12, 296)
        Me.lblQOHLabel.Name = "lblQOHLabel"
        Me.lblQOHLabel.Size = New System.Drawing.Size(106, 20)
        Me.lblQOHLabel.TabIndex = 24
        Me.lblQOHLabel.Text = "Quantity on Hand:"
        Me.lblQOHLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblQOHLabel.Visible = False
        '
        'lblQOH
        '
        Me.lblQOH.ForeColor = System.Drawing.Color.Blue
        Me.lblQOH.Location = New System.Drawing.Point(142, 296)
        Me.lblQOH.Name = "lblQOH"
        Me.lblQOH.Size = New System.Drawing.Size(148, 20)
        Me.lblQOH.TabIndex = 23
        '
        'cboAdjustSteelSize
        '
        Me.cboAdjustSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAdjustSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAdjustSteelSize.FormattingEnabled = True
        Me.cboAdjustSteelSize.Location = New System.Drawing.Point(98, 99)
        Me.cboAdjustSteelSize.Name = "cboAdjustSteelSize"
        Me.cboAdjustSteelSize.Size = New System.Drawing.Size(192, 21)
        Me.cboAdjustSteelSize.TabIndex = 7
        '
        'cboAdjustCarbon
        '
        Me.cboAdjustCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAdjustCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAdjustCarbon.DisplayMember = "Carbon"
        Me.cboAdjustCarbon.FormattingEnabled = True
        Me.cboAdjustCarbon.Location = New System.Drawing.Point(98, 64)
        Me.cboAdjustCarbon.Name = "cboAdjustCarbon"
        Me.cboAdjustCarbon.Size = New System.Drawing.Size(192, 21)
        Me.cboAdjustCarbon.TabIndex = 6
        Me.cboAdjustCarbon.ValueMember = "Carbon"
        '
        'txtAdjustmentTotal
        '
        Me.txtAdjustmentTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdjustmentTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdjustmentTotal.Location = New System.Drawing.Point(140, 400)
        Me.txtAdjustmentTotal.Name = "txtAdjustmentTotal"
        Me.txtAdjustmentTotal.ReadOnly = True
        Me.txtAdjustmentTotal.Size = New System.Drawing.Size(150, 20)
        Me.txtAdjustmentTotal.TabIndex = 11
        Me.txtAdjustmentTotal.TabStop = False
        Me.txtAdjustmentTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(13, 401)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 20)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Adjustment Total"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAdjustmentCost
        '
        Me.txtAdjustmentCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdjustmentCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdjustmentCost.Location = New System.Drawing.Point(140, 364)
        Me.txtAdjustmentCost.Name = "txtAdjustmentCost"
        Me.txtAdjustmentCost.ReadOnly = True
        Me.txtAdjustmentCost.Size = New System.Drawing.Size(150, 20)
        Me.txtAdjustmentCost.TabIndex = 10
        Me.txtAdjustmentCost.TabStop = False
        Me.txtAdjustmentCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAdjustmentWeight
        '
        Me.txtAdjustmentWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdjustmentWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdjustmentWeight.Location = New System.Drawing.Point(140, 328)
        Me.txtAdjustmentWeight.Name = "txtAdjustmentWeight"
        Me.txtAdjustmentWeight.Size = New System.Drawing.Size(150, 20)
        Me.txtAdjustmentWeight.TabIndex = 9
        Me.txtAdjustmentWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdGenerateAdjustmentNumber
        '
        Me.cmdGenerateAdjustmentNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateAdjustmentNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateAdjustmentNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateAdjustmentNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateAdjustmentNumber.Location = New System.Drawing.Point(96, 29)
        Me.cmdGenerateAdjustmentNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateAdjustmentNumber.Name = "cmdGenerateAdjustmentNumber"
        Me.cmdGenerateAdjustmentNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateAdjustmentNumber.TabIndex = 3
        Me.cmdGenerateAdjustmentNumber.Text = ">>"
        Me.cmdGenerateAdjustmentNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateAdjustmentNumber.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(13, 242)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(271, 54)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Subtractions to inventory must be entered as a negative number"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(219, 555)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 13
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdEnter
        '
        Me.cmdEnter.Location = New System.Drawing.Point(137, 555)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(71, 40)
        Me.cmdEnter.TabIndex = 12
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(13, 130)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 20)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Reason"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(13, 366)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 20)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Adjustment Unit Cost"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComment
        '
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(13, 153)
        Me.txtComment.MaxLength = 100
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(277, 86)
        Me.txtComment.TabIndex = 8
        Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(13, 329)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 20)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Adjustment Weight"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAdjustSteelSize
        '
        Me.lblAdjustSteelSize.Location = New System.Drawing.Point(13, 101)
        Me.lblAdjustSteelSize.Name = "lblAdjustSteelSize"
        Me.lblAdjustSteelSize.Size = New System.Drawing.Size(103, 20)
        Me.lblAdjustSteelSize.TabIndex = 6
        Me.lblAdjustSteelSize.Text = "Steel Size"
        Me.lblAdjustSteelSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAdjustCarbon
        '
        Me.lblAdjustCarbon.Location = New System.Drawing.Point(13, 66)
        Me.lblAdjustCarbon.Name = "lblAdjustCarbon"
        Me.lblAdjustCarbon.Size = New System.Drawing.Size(103, 20)
        Me.lblAdjustCarbon.TabIndex = 5
        Me.lblAdjustCarbon.Text = "Steel Carbon"
        Me.lblAdjustCarbon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAdjustmentNumber
        '
        Me.cboAdjustmentNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAdjustmentNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAdjustmentNumber.FormattingEnabled = True
        Me.cboAdjustmentNumber.Location = New System.Drawing.Point(128, 29)
        Me.cboAdjustmentNumber.Name = "cboAdjustmentNumber"
        Me.cboAdjustmentNumber.Size = New System.Drawing.Size(162, 21)
        Me.cboAdjustmentNumber.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Adjustment #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpAdjustmentDate
        '
        Me.dtpAdjustmentDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAdjustmentDate.Location = New System.Drawing.Point(132, 55)
        Me.dtpAdjustmentDate.Name = "dtpAdjustmentDate"
        Me.dtpAdjustmentDate.Size = New System.Drawing.Size(158, 20)
        Me.dtpAdjustmentDate.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Batch Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDeleteLine
        '
        Me.cboDeleteLine.FormattingEnabled = True
        Me.cboDeleteLine.Location = New System.Drawing.Point(124, 34)
        Me.cboDeleteLine.Name = "cboDeleteLine"
        Me.cboDeleteLine.Size = New System.Drawing.Size(141, 21)
        Me.cboDeleteLine.TabIndex = 13
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 22
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 18
        Me.cmdPrint.Text = "Print Batch"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(905, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 17
        Me.cmdDelete.Text = "Delete Batch"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'gpxPostData
        '
        Me.gpxPostData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxPostData.Controls.Add(Me.Label17)
        Me.gpxPostData.Controls.Add(Me.cmdPostAdjustment)
        Me.gpxPostData.Location = New System.Drawing.Point(828, 591)
        Me.gpxPostData.Name = "gpxPostData"
        Me.gpxPostData.Size = New System.Drawing.Size(300, 164)
        Me.gpxPostData.TabIndex = 23
        Me.gpxPostData.TabStop = False
        Me.gpxPostData.Text = "Post Steel Adjustment"
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(26, 47)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(236, 40)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "Steel Adjustments must be POSTED. After POSTING, no additional changes may be mad" & _
            "e."
        '
        'cmdPostAdjustment
        '
        Me.cmdPostAdjustment.ForeColor = System.Drawing.Color.Blue
        Me.cmdPostAdjustment.Location = New System.Drawing.Point(206, 103)
        Me.cmdPostAdjustment.Name = "cmdPostAdjustment"
        Me.cmdPostAdjustment.Size = New System.Drawing.Size(71, 40)
        Me.cmdPostAdjustment.TabIndex = 23
        Me.cmdPostAdjustment.Text = "Post Batch"
        Me.cmdPostAdjustment.UseVisualStyleBackColor = True
        '
        'gpxBatchTotals
        '
        Me.gpxBatchTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxBatchTotals.Controls.Add(Me.txtTotalItems)
        Me.gpxBatchTotals.Controls.Add(Me.Label11)
        Me.gpxBatchTotals.Controls.Add(Me.txtTotalCost)
        Me.gpxBatchTotals.Controls.Add(Me.txtTotalWeight)
        Me.gpxBatchTotals.Controls.Add(Me.Label13)
        Me.gpxBatchTotals.Controls.Add(Me.Label14)
        Me.gpxBatchTotals.Location = New System.Drawing.Point(347, 675)
        Me.gpxBatchTotals.Name = "gpxBatchTotals"
        Me.gpxBatchTotals.Size = New System.Drawing.Size(366, 139)
        Me.gpxBatchTotals.TabIndex = 60
        Me.gpxBatchTotals.TabStop = False
        Me.gpxBatchTotals.Text = "Batch Adjustment Totals"
        '
        'txtTotalItems
        '
        Me.txtTotalItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalItems.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalItems.Location = New System.Drawing.Point(168, 99)
        Me.txtTotalItems.Name = "txtTotalItems"
        Me.txtTotalItems.ReadOnly = True
        Me.txtTotalItems.Size = New System.Drawing.Size(178, 20)
        Me.txtTotalItems.TabIndex = 27
        Me.txtTotalItems.TabStop = False
        Me.txtTotalItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(21, 99)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(106, 20)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Total Items"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalCost
        '
        Me.txtTotalCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalCost.Location = New System.Drawing.Point(168, 65)
        Me.txtTotalCost.Name = "txtTotalCost"
        Me.txtTotalCost.ReadOnly = True
        Me.txtTotalCost.Size = New System.Drawing.Size(178, 20)
        Me.txtTotalCost.TabIndex = 24
        Me.txtTotalCost.TabStop = False
        Me.txtTotalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalWeight
        '
        Me.txtTotalWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalWeight.Location = New System.Drawing.Point(168, 31)
        Me.txtTotalWeight.Name = "txtTotalWeight"
        Me.txtTotalWeight.ReadOnly = True
        Me.txtTotalWeight.Size = New System.Drawing.Size(178, 20)
        Me.txtTotalWeight.TabIndex = 23
        Me.txtTotalWeight.TabStop = False
        Me.txtTotalWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(21, 65)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(106, 20)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Total Cost"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(21, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(106, 20)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "Total Weight"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxAdjustmentBatch
        '
        Me.gpxAdjustmentBatch.Controls.Add(Me.Label4)
        Me.gpxAdjustmentBatch.Controls.Add(Me.txtBatchStatus)
        Me.gpxAdjustmentBatch.Controls.Add(Me.cboAdjustmentBatchNumber)
        Me.gpxAdjustmentBatch.Controls.Add(Me.cmdBatchNumber)
        Me.gpxAdjustmentBatch.Controls.Add(Me.Label15)
        Me.gpxAdjustmentBatch.Controls.Add(Me.Label16)
        Me.gpxAdjustmentBatch.Controls.Add(Me.dtpAdjustmentDate)
        Me.gpxAdjustmentBatch.Controls.Add(Me.Label2)
        Me.gpxAdjustmentBatch.Location = New System.Drawing.Point(30, 35)
        Me.gpxAdjustmentBatch.Name = "gpxAdjustmentBatch"
        Me.gpxAdjustmentBatch.Size = New System.Drawing.Size(300, 157)
        Me.gpxAdjustmentBatch.TabIndex = 0
        Me.gpxAdjustmentBatch.TabStop = False
        Me.gpxAdjustmentBatch.Text = "Adjustment Batch Number"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(13, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(277, 28)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Starting a new batch generates the first adjustment number"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBatchStatus
        '
        Me.txtBatchStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchStatus.Location = New System.Drawing.Point(98, 125)
        Me.txtBatchStatus.Name = "txtBatchStatus"
        Me.txtBatchStatus.ReadOnly = True
        Me.txtBatchStatus.Size = New System.Drawing.Size(192, 20)
        Me.txtBatchStatus.TabIndex = 2
        Me.txtBatchStatus.TabStop = False
        Me.txtBatchStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboAdjustmentBatchNumber
        '
        Me.cboAdjustmentBatchNumber.FormattingEnabled = True
        Me.cboAdjustmentBatchNumber.Location = New System.Drawing.Point(130, 28)
        Me.cboAdjustmentBatchNumber.Name = "cboAdjustmentBatchNumber"
        Me.cboAdjustmentBatchNumber.Size = New System.Drawing.Size(160, 21)
        Me.cboAdjustmentBatchNumber.TabIndex = 1
        '
        'cmdBatchNumber
        '
        Me.cmdBatchNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdBatchNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdBatchNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBatchNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdBatchNumber.Location = New System.Drawing.Point(98, 29)
        Me.cmdBatchNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdBatchNumber.Name = "cmdBatchNumber"
        Me.cmdBatchNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdBatchNumber.TabIndex = 0
        Me.cmdBatchNumber.Text = ">>"
        Me.cmdBatchNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBatchNumber.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(13, 29)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(106, 20)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Batch Number"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(13, 125)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(106, 20)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Batch Status"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearBatch
        '
        Me.cmdClearBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearBatch.Location = New System.Drawing.Point(828, 771)
        Me.cmdClearBatch.Name = "cmdClearBatch"
        Me.cmdClearBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearBatch.TabIndex = 15
        Me.cmdClearBatch.Text = "Clear Batch"
        Me.cmdClearBatch.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdDeleteAdjustment)
        Me.GroupBox1.Controls.Add(Me.lbDeleteAdjustmentNumber)
        Me.GroupBox1.Controls.Add(Me.cboDeleteLine)
        Me.GroupBox1.Location = New System.Drawing.Point(347, 591)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(366, 77)
        Me.GroupBox1.TabIndex = 61
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Delete Steel Adjustment Line"
        '
        'cmdDeleteAdjustment
        '
        Me.cmdDeleteAdjustment.Location = New System.Drawing.Point(275, 28)
        Me.cmdDeleteAdjustment.Name = "cmdDeleteAdjustment"
        Me.cmdDeleteAdjustment.Size = New System.Drawing.Size(71, 30)
        Me.cmdDeleteAdjustment.TabIndex = 14
        Me.cmdDeleteAdjustment.Text = "Delete"
        Me.cmdDeleteAdjustment.UseVisualStyleBackColor = True
        '
        'lbDeleteAdjustmentNumber
        '
        Me.lbDeleteAdjustmentNumber.AutoSize = True
        Me.lbDeleteAdjustmentNumber.Location = New System.Drawing.Point(21, 37)
        Me.lbDeleteAdjustmentNumber.Name = "lbDeleteAdjustmentNumber"
        Me.lbDeleteAdjustmentNumber.Size = New System.Drawing.Size(97, 13)
        Me.lbDeleteAdjustmentNumber.TabIndex = 9
        Me.lbDeleteAdjustmentNumber.Text = "Adjustment number"
        '
        'dgvSteelAdjustmentLines
        '
        Me.dgvSteelAdjustmentLines.AllowUserToAddRows = False
        Me.dgvSteelAdjustmentLines.AllowUserToDeleteRows = False
        Me.dgvSteelAdjustmentLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSteelAdjustmentLines.AutoGenerateColumns = False
        Me.dgvSteelAdjustmentLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelAdjustmentLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSteelAdjustmentLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelAdjustmentLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SteelAdjustmentKeyColumn, Me.AdjustmentDateColumn, Me.SteelCarbonColumn, Me.SteelSizeColumn, Me.AdjustmentWeightColumn, Me.AdjustmentCostColumn, Me.AdjustmentTotalColumn, Me.CommentColumn, Me.ChangeRMIDColumn, Me.ChangeCoilIDColumn, Me.UserIDColumn, Me.BatchNumberColumn, Me.DivisionIDColumn, Me.RMIDColumn, Me.StatusColumn, Me.LockedColumn, Me.PrintDateColumn})
        Me.dgvSteelAdjustmentLines.DataSource = Me.SteelAdjustmentTableBindingSource
        Me.dgvSteelAdjustmentLines.Location = New System.Drawing.Point(347, 39)
        Me.dgvSteelAdjustmentLines.Name = "dgvSteelAdjustmentLines"
        Me.dgvSteelAdjustmentLines.Size = New System.Drawing.Size(781, 535)
        Me.dgvSteelAdjustmentLines.TabIndex = 62
        '
        'SteelAdjustmentKeyColumn
        '
        Me.SteelAdjustmentKeyColumn.DataPropertyName = "SteelAdjustmentKey"
        Me.SteelAdjustmentKeyColumn.HeaderText = "Adj. #"
        Me.SteelAdjustmentKeyColumn.Name = "SteelAdjustmentKeyColumn"
        Me.SteelAdjustmentKeyColumn.Width = 80
        '
        'AdjustmentDateColumn
        '
        Me.AdjustmentDateColumn.DataPropertyName = "AdjustmentDate"
        Me.AdjustmentDateColumn.HeaderText = "Date"
        Me.AdjustmentDateColumn.Name = "AdjustmentDateColumn"
        Me.AdjustmentDateColumn.Width = 80
        '
        'SteelCarbonColumn
        '
        Me.SteelCarbonColumn.DataPropertyName = "SteelCarbon"
        Me.SteelCarbonColumn.HeaderText = "Carbon/Alloy"
        Me.SteelCarbonColumn.Name = "SteelCarbonColumn"
        Me.SteelCarbonColumn.Width = 90
        '
        'SteelSizeColumn
        '
        Me.SteelSizeColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn.HeaderText = "Size"
        Me.SteelSizeColumn.Name = "SteelSizeColumn"
        Me.SteelSizeColumn.Width = 90
        '
        'AdjustmentWeightColumn
        '
        Me.AdjustmentWeightColumn.DataPropertyName = "AdjustmentWeight"
        Me.AdjustmentWeightColumn.HeaderText = "Weight"
        Me.AdjustmentWeightColumn.Name = "AdjustmentWeightColumn"
        Me.AdjustmentWeightColumn.Width = 80
        '
        'AdjustmentCostColumn
        '
        Me.AdjustmentCostColumn.DataPropertyName = "AdjustmentCost"
        Me.AdjustmentCostColumn.HeaderText = "Cost/Lb."
        Me.AdjustmentCostColumn.Name = "AdjustmentCostColumn"
        Me.AdjustmentCostColumn.Width = 80
        '
        'AdjustmentTotalColumn
        '
        Me.AdjustmentTotalColumn.DataPropertyName = "AdjustmentTotal"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.AdjustmentTotalColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.AdjustmentTotalColumn.HeaderText = "Ext. Amt."
        Me.AdjustmentTotalColumn.Name = "AdjustmentTotalColumn"
        Me.AdjustmentTotalColumn.Width = 80
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'ChangeRMIDColumn
        '
        Me.ChangeRMIDColumn.DataPropertyName = "ChangeRMID"
        Me.ChangeRMIDColumn.HeaderText = "Old RMID"
        Me.ChangeRMIDColumn.Name = "ChangeRMIDColumn"
        '
        'ChangeCoilIDColumn
        '
        Me.ChangeCoilIDColumn.DataPropertyName = "ChangeCoilID"
        Me.ChangeCoilIDColumn.HeaderText = "Coil ID"
        Me.ChangeCoilIDColumn.Name = "ChangeCoilIDColumn"
        '
        'UserIDColumn
        '
        Me.UserIDColumn.DataPropertyName = "UserID"
        Me.UserIDColumn.HeaderText = "UserID"
        Me.UserIDColumn.Name = "UserIDColumn"
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "BatchNumber"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        Me.RMIDColumn.Visible = False
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.Visible = False
        '
        'LockedColumn
        '
        Me.LockedColumn.DataPropertyName = "Locked"
        Me.LockedColumn.HeaderText = "Locked"
        Me.LockedColumn.Name = "LockedColumn"
        Me.LockedColumn.Visible = False
        '
        'PrintDateColumn
        '
        Me.PrintDateColumn.DataPropertyName = "PrintDate"
        Me.PrintDateColumn.HeaderText = "PrintDate"
        Me.PrintDateColumn.Name = "PrintDateColumn"
        Me.PrintDateColumn.Visible = False
        '
        'SteelAdjustmentTableBindingSource
        '
        Me.SteelAdjustmentTableBindingSource.DataMember = "SteelAdjustmentTable"
        Me.SteelAdjustmentTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SteelAdjustmentTableTableAdapter
        '
        Me.SteelAdjustmentTableTableAdapter.ClearBeforeFill = True
        '
        'SteelAdjustmentForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.dgvSteelAdjustmentLines)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdClearBatch)
        Me.Controls.Add(Me.gpxAdjustmentBatch)
        Me.Controls.Add(Me.gpxBatchTotals)
        Me.Controls.Add(Me.gpxPostData)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxAdjustmentEntry)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "SteelAdjustmentForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Steel Adjustment Form"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxAdjustmentEntry.ResumeLayout(False)
        Me.gpxAdjustmentEntry.PerformLayout()
        Me.gpxPostData.ResumeLayout(False)
        Me.gpxBatchTotals.ResumeLayout(False)
        Me.gpxBatchTotals.PerformLayout()
        Me.gpxAdjustmentBatch.ResumeLayout(False)
        Me.gpxAdjustmentBatch.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvSteelAdjustmentLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelAdjustmentTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxAdjustmentEntry As System.Windows.Forms.GroupBox
    Friend WithEvents dtpAdjustmentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblAdjustSteelSize As System.Windows.Forms.Label
    Friend WithEvents lblAdjustCarbon As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboAdjustmentNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDeleteLine As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdGenerateAdjustmentNumber As System.Windows.Forms.Button
    Friend WithEvents txtAdjustmentCost As System.Windows.Forms.TextBox
    Friend WithEvents txtAdjustmentWeight As System.Windows.Forms.TextBox
    Friend WithEvents DeleteAdjustmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintAdjustmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxPostData As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmdPostAdjustment As System.Windows.Forms.Button
    Friend WithEvents gpxBatchTotals As System.Windows.Forms.GroupBox
    Friend WithEvents txtAdjustmentTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTotalItems As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCost As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents gpxAdjustmentBatch As System.Windows.Forms.GroupBox
    Friend WithEvents cmdBatchNumber As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboAdjustmentBatchNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClearBatch As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtBatchStatus As System.Windows.Forms.TextBox
    Friend WithEvents ClearFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboAdjustSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboAdjustCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents lbDeleteAdjustmentNumber As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteAdjustment As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents UnLockBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblQOHLabel As System.Windows.Forms.Label
    Friend WithEvents lblQOH As System.Windows.Forms.Label
    Friend WithEvents txtCoilID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkChangeCoilSteelType As System.Windows.Forms.CheckBox
    Friend WithEvents lblSteelTypeLabel As System.Windows.Forms.Label
    Friend WithEvents lblOldSteelType As System.Windows.Forms.Label
    Friend WithEvents dgvSteelAdjustmentLines As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents SteelAdjustmentTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelAdjustmentTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelAdjustmentTableTableAdapter
    Friend WithEvents SteelAdjustmentKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChangeRMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChangeCoilIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LockedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
