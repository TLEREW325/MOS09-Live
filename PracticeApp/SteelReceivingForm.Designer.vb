<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SteelReceivingForm
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnLockReceiverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxHeaderInfo = New System.Windows.Forms.GroupBox
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtReceivingStatus = New System.Windows.Forms.TextBox
        Me.cboSteelPO = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.txtSteelComment = New System.Windows.Forms.TextBox
        Me.txtSteelBOL = New System.Windows.Forms.TextBox
        Me.cmdGenerateReceivingTicket = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.dtpSteelReceivingDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboSteelRecTicket = New System.Windows.Forms.ComboBox
        Me.cboSteelVendor = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.dgvSteelReceiving = New System.Windows.Forms.DataGridView
        Me.cmdSave = New System.Windows.Forms.Button
        Me.SteelReceivingLineKeyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarbonDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiveWeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdSaveAndPost = New System.Windows.Forms.Button
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdSelectLines = New System.Windows.Forms.Button
        Me.gpxPostSteelReceipt = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.gpxSelectLines = New System.Windows.Forms.GroupBox
        Me.tmrWaitToPrint = New System.Windows.Forms.Timer(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtOtherTotal = New System.Windows.Forms.TextBox
        Me.txtFreightTotal = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblInvoiceTotal = New System.Windows.Forms.Label
        Me.lblSteelTotal = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.MenuStrip1.SuspendLayout()
        Me.gpxHeaderInfo.SuspendLayout()
        CType(Me.dgvSteelReceiving, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxPostSteelReceipt.SuspendLayout()
        Me.gpxSelectLines.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1062, 773)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 15
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(983, 773)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 14
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveReceiptToolStripMenuItem, Me.PrintReceiptToolStripMenuItem, Me.DeleteReceiptToolStripMenuItem, Me.ClearFormToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveReceiptToolStripMenuItem
        '
        Me.SaveReceiptToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.SaveReceiptToolStripMenuItem.Name = "SaveReceiptToolStripMenuItem"
        Me.SaveReceiptToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveReceiptToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.SaveReceiptToolStripMenuItem.Text = "Save Receipt"
        '
        'PrintReceiptToolStripMenuItem
        '
        Me.PrintReceiptToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.PrintReceiptToolStripMenuItem.Name = "PrintReceiptToolStripMenuItem"
        Me.PrintReceiptToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.PrintReceiptToolStripMenuItem.Text = "Print Receipt"
        '
        'DeleteReceiptToolStripMenuItem
        '
        Me.DeleteReceiptToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.DeleteReceiptToolStripMenuItem.Name = "DeleteReceiptToolStripMenuItem"
        Me.DeleteReceiptToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.DeleteReceiptToolStripMenuItem.Text = "Delete Receipt"
        '
        'ClearFormToolStripMenuItem
        '
        Me.ClearFormToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ClearFormToolStripMenuItem.Name = "ClearFormToolStripMenuItem"
        Me.ClearFormToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.ClearFormToolStripMenuItem.Text = "Clear Form"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UnLockReceiverToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'UnLockReceiverToolStripMenuItem
        '
        Me.UnLockReceiverToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.UnLockReceiverToolStripMenuItem.Name = "UnLockReceiverToolStripMenuItem"
        Me.UnLockReceiverToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.UnLockReceiverToolStripMenuItem.Text = "Un-Lock Receiver"
        Me.UnLockReceiverToolStripMenuItem.Visible = False
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
        'gpxHeaderInfo
        '
        Me.gpxHeaderInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gpxHeaderInfo.Controls.Add(Me.txtVendorName)
        Me.gpxHeaderInfo.Controls.Add(Me.Label4)
        Me.gpxHeaderInfo.Controls.Add(Me.Label23)
        Me.gpxHeaderInfo.Controls.Add(Me.txtReceivingStatus)
        Me.gpxHeaderInfo.Controls.Add(Me.cboSteelPO)
        Me.gpxHeaderInfo.Controls.Add(Me.Label22)
        Me.gpxHeaderInfo.Controls.Add(Me.cboDivisionID)
        Me.gpxHeaderInfo.Controls.Add(Me.txtSteelComment)
        Me.gpxHeaderInfo.Controls.Add(Me.txtSteelBOL)
        Me.gpxHeaderInfo.Controls.Add(Me.cmdGenerateReceivingTicket)
        Me.gpxHeaderInfo.Controls.Add(Me.Label12)
        Me.gpxHeaderInfo.Controls.Add(Me.dtpSteelReceivingDate)
        Me.gpxHeaderInfo.Controls.Add(Me.Label3)
        Me.gpxHeaderInfo.Controls.Add(Me.cboSteelRecTicket)
        Me.gpxHeaderInfo.Controls.Add(Me.cboSteelVendor)
        Me.gpxHeaderInfo.Controls.Add(Me.Label10)
        Me.gpxHeaderInfo.Controls.Add(Me.Label11)
        Me.gpxHeaderInfo.Controls.Add(Me.Label18)
        Me.gpxHeaderInfo.Location = New System.Drawing.Point(29, 41)
        Me.gpxHeaderInfo.Name = "gpxHeaderInfo"
        Me.gpxHeaderInfo.Size = New System.Drawing.Size(352, 551)
        Me.gpxHeaderInfo.TabIndex = 0
        Me.gpxHeaderInfo.TabStop = False
        Me.gpxHeaderInfo.Text = "Receiving Header Data"
        '
        'txtVendorName
        '
        Me.txtVendorName.BackColor = System.Drawing.Color.White
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorName.Enabled = False
        Me.txtVendorName.Location = New System.Drawing.Point(31, 296)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.ReadOnly = True
        Me.txtVendorName.Size = New System.Drawing.Size(307, 57)
        Me.txtVendorName.TabIndex = 5
        Me.txtVendorName.TabStop = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(29, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 20)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Steel PO #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(28, 213)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(110, 20)
        Me.Label23.TabIndex = 33
        Me.Label23.Text = "Status"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReceivingStatus
        '
        Me.txtReceivingStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReceivingStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReceivingStatus.Location = New System.Drawing.Point(160, 215)
        Me.txtReceivingStatus.Name = "txtReceivingStatus"
        Me.txtReceivingStatus.ReadOnly = True
        Me.txtReceivingStatus.Size = New System.Drawing.Size(178, 20)
        Me.txtReceivingStatus.TabIndex = 3
        Me.txtReceivingStatus.TabStop = False
        Me.txtReceivingStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboSteelPO
        '
        Me.cboSteelPO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelPO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelPO.FormattingEnabled = True
        Me.cboSteelPO.Location = New System.Drawing.Point(160, 167)
        Me.cboSteelPO.Name = "cboSteelPO"
        Me.cboSteelPO.Size = New System.Drawing.Size(178, 21)
        Me.cboSteelPO.TabIndex = 3
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(28, 34)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(110, 20)
        Me.Label22.TabIndex = 31
        Me.Label22.Text = "Division ID"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Items.AddRange(New Object() {"ADM", "TWD", "TST"})
        Me.cboDivisionID.Location = New System.Drawing.Point(160, 33)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(178, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'txtSteelComment
        '
        Me.txtSteelComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelComment.Location = New System.Drawing.Point(31, 435)
        Me.txtSteelComment.Multiline = True
        Me.txtSteelComment.Name = "txtSteelComment"
        Me.txtSteelComment.Size = New System.Drawing.Size(307, 95)
        Me.txtSteelComment.TabIndex = 7
        Me.txtSteelComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSteelBOL
        '
        Me.txtSteelBOL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelBOL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelBOL.Location = New System.Drawing.Point(173, 375)
        Me.txtSteelBOL.MaxLength = 9
        Me.txtSteelBOL.Name = "txtSteelBOL"
        Me.txtSteelBOL.Size = New System.Drawing.Size(165, 20)
        Me.txtSteelBOL.TabIndex = 6
        Me.txtSteelBOL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdGenerateReceivingTicket
        '
        Me.cmdGenerateReceivingTicket.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateReceivingTicket.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateReceivingTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateReceivingTicket.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateReceivingTicket.Location = New System.Drawing.Point(128, 77)
        Me.cmdGenerateReceivingTicket.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateReceivingTicket.Name = "cmdGenerateReceivingTicket"
        Me.cmdGenerateReceivingTicket.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateReceivingTicket.TabIndex = 0
        Me.cmdGenerateReceivingTicket.TabStop = False
        Me.cmdGenerateReceivingTicket.Text = ">>"
        Me.cmdGenerateReceivingTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateReceivingTicket.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(30, 119)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 20)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Receiving Date"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpSteelReceivingDate
        '
        Me.dtpSteelReceivingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSteelReceivingDate.Location = New System.Drawing.Point(160, 119)
        Me.dtpSteelReceivingDate.Name = "dtpSteelReceivingDate"
        Me.dtpSteelReceivingDate.Size = New System.Drawing.Size(178, 20)
        Me.dtpSteelReceivingDate.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(29, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 20)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Receipt Ticket #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelRecTicket
        '
        Me.cboSteelRecTicket.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelRecTicket.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelRecTicket.FormattingEnabled = True
        Me.cboSteelRecTicket.Location = New System.Drawing.Point(160, 76)
        Me.cboSteelRecTicket.Name = "cboSteelRecTicket"
        Me.cboSteelRecTicket.Size = New System.Drawing.Size(178, 21)
        Me.cboSteelRecTicket.TabIndex = 1
        '
        'cboSteelVendor
        '
        Me.cboSteelVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelVendor.Enabled = False
        Me.cboSteelVendor.Location = New System.Drawing.Point(119, 259)
        Me.cboSteelVendor.Name = "cboSteelVendor"
        Me.cboSteelVendor.Size = New System.Drawing.Size(219, 21)
        Me.cboSteelVendor.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(28, 260)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 20)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Steel Vendor ID"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(29, 375)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(138, 20)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "BOL/ Packing Slip Number"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(29, 412)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(110, 20)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Comment"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(904, 773)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 13
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'dgvSteelReceiving
        '
        Me.dgvSteelReceiving.AllowUserToAddRows = False
        Me.dgvSteelReceiving.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSteelReceiving.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSteelReceiving.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelReceiving.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelReceiving.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvSteelReceiving.Location = New System.Drawing.Point(401, 41)
        Me.dgvSteelReceiving.Name = "dgvSteelReceiving"
        Me.dgvSteelReceiving.Size = New System.Drawing.Size(728, 599)
        Me.dgvSteelReceiving.TabIndex = 16
        Me.dgvSteelReceiving.TabStop = False
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(825, 773)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 12
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'SteelReceivingLineKeyDataGridViewTextBoxColumn
        '
        Me.SteelReceivingLineKeyDataGridViewTextBoxColumn.DataPropertyName = "SteelReceivingLineKey"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.SteelReceivingLineKeyDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.SteelReceivingLineKeyDataGridViewTextBoxColumn.FillWeight = 296.9543!
        Me.SteelReceivingLineKeyDataGridViewTextBoxColumn.HeaderText = "Line #"
        Me.SteelReceivingLineKeyDataGridViewTextBoxColumn.Name = "SteelReceivingLineKeyDataGridViewTextBoxColumn"
        Me.SteelReceivingLineKeyDataGridViewTextBoxColumn.ReadOnly = True
        Me.SteelReceivingLineKeyDataGridViewTextBoxColumn.Width = 65
        '
        'ReceivingDateDataGridViewTextBoxColumn
        '
        Me.ReceivingDateDataGridViewTextBoxColumn.DataPropertyName = "ReceivingDate"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ReceivingDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.ReceivingDateDataGridViewTextBoxColumn.FillWeight = 75.38071!
        Me.ReceivingDateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.ReceivingDateDataGridViewTextBoxColumn.Name = "ReceivingDateDataGridViewTextBoxColumn"
        Me.ReceivingDateDataGridViewTextBoxColumn.Visible = False
        Me.ReceivingDateDataGridViewTextBoxColumn.Width = 80
        '
        'CarbonDataGridViewTextBoxColumn
        '
        Me.CarbonDataGridViewTextBoxColumn.DataPropertyName = "Carbon"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.CarbonDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle9
        Me.CarbonDataGridViewTextBoxColumn.FillWeight = 75.38071!
        Me.CarbonDataGridViewTextBoxColumn.HeaderText = "Carbon"
        Me.CarbonDataGridViewTextBoxColumn.Name = "CarbonDataGridViewTextBoxColumn"
        Me.CarbonDataGridViewTextBoxColumn.ReadOnly = True
        Me.CarbonDataGridViewTextBoxColumn.Width = 80
        '
        'SteelSizeDataGridViewTextBoxColumn
        '
        Me.SteelSizeDataGridViewTextBoxColumn.DataPropertyName = "SteelSize"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.SteelSizeDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle10
        Me.SteelSizeDataGridViewTextBoxColumn.FillWeight = 75.38071!
        Me.SteelSizeDataGridViewTextBoxColumn.HeaderText = "Steel Size"
        Me.SteelSizeDataGridViewTextBoxColumn.Name = "SteelSizeDataGridViewTextBoxColumn"
        Me.SteelSizeDataGridViewTextBoxColumn.ReadOnly = True
        Me.SteelSizeDataGridViewTextBoxColumn.Width = 80
        '
        'DescriptionDataGridViewTextBoxColumn
        '
        Me.DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DescriptionDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle11
        Me.DescriptionDataGridViewTextBoxColumn.FillWeight = 75.38071!
        Me.DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        Me.DescriptionDataGridViewTextBoxColumn.ReadOnly = True
        Me.DescriptionDataGridViewTextBoxColumn.Width = 80
        '
        'ReceiveWeightDataGridViewTextBoxColumn
        '
        Me.ReceiveWeightDataGridViewTextBoxColumn.DataPropertyName = "ReceiveWeight"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N0"
        DataGridViewCellStyle12.NullValue = "0"
        Me.ReceiveWeightDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle12
        Me.ReceiveWeightDataGridViewTextBoxColumn.FillWeight = 75.38071!
        Me.ReceiveWeightDataGridViewTextBoxColumn.HeaderText = "Receive Weight"
        Me.ReceiveWeightDataGridViewTextBoxColumn.Name = "ReceiveWeightDataGridViewTextBoxColumn"
        Me.ReceiveWeightDataGridViewTextBoxColumn.Width = 80
        '
        'cmdSaveAndPost
        '
        Me.cmdSaveAndPost.ForeColor = System.Drawing.Color.Blue
        Me.cmdSaveAndPost.Location = New System.Drawing.Point(17, 37)
        Me.cmdSaveAndPost.Name = "cmdSaveAndPost"
        Me.cmdSaveAndPost.Size = New System.Drawing.Size(71, 40)
        Me.cmdSaveAndPost.TabIndex = 10
        Me.cmdSaveAndPost.Text = "Post Receipt"
        Me.cmdSaveAndPost.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(310, 773)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 11
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdSelectLines
        '
        Me.cmdSelectLines.ForeColor = System.Drawing.Color.Blue
        Me.cmdSelectLines.Location = New System.Drawing.Point(22, 37)
        Me.cmdSelectLines.Name = "cmdSelectLines"
        Me.cmdSelectLines.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectLines.TabIndex = 9
        Me.cmdSelectLines.Text = "Select Lines"
        Me.cmdSelectLines.UseVisualStyleBackColor = True
        '
        'gpxPostSteelReceipt
        '
        Me.gpxPostSteelReceipt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxPostSteelReceipt.Controls.Add(Me.Label2)
        Me.gpxPostSteelReceipt.Controls.Add(Me.cmdSaveAndPost)
        Me.gpxPostSteelReceipt.Location = New System.Drawing.Point(826, 658)
        Me.gpxPostSteelReceipt.Name = "gpxPostSteelReceipt"
        Me.gpxPostSteelReceipt.Size = New System.Drawing.Size(307, 101)
        Me.gpxPostSteelReceipt.TabIndex = 10
        Me.gpxPostSteelReceipt.TabStop = False
        Me.gpxPostSteelReceipt.Text = "Post Steel Receipt"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(94, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(195, 61)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Post Receiving Ticket once Receiving Quantities are correct. Once this ticket is " & _
            "posted, no further changes may be made."
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(99, 37)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(169, 40)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Select Lines from Steel PO to receive. "
        '
        'gpxSelectLines
        '
        Me.gpxSelectLines.Controls.Add(Me.cmdSelectLines)
        Me.gpxSelectLines.Controls.Add(Me.Label14)
        Me.gpxSelectLines.Location = New System.Drawing.Point(29, 604)
        Me.gpxSelectLines.Name = "gpxSelectLines"
        Me.gpxSelectLines.Size = New System.Drawing.Size(352, 101)
        Me.gpxSelectLines.TabIndex = 9
        Me.gpxSelectLines.TabStop = False
        Me.gpxSelectLines.Text = "Select Lines From PO's to Receive"
        '
        'tmrWaitToPrint
        '
        Me.tmrWaitToPrint.Interval = 5000
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(19, 86)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 20)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Sales Tax Total"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 56)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 20)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Freight Total"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOtherTotal
        '
        Me.txtOtherTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOtherTotal.Location = New System.Drawing.Point(142, 85)
        Me.txtOtherTotal.Margin = New System.Windows.Forms.Padding(5)
        Me.txtOtherTotal.Name = "txtOtherTotal"
        Me.txtOtherTotal.Size = New System.Drawing.Size(198, 20)
        Me.txtOtherTotal.TabIndex = 21
        Me.txtOtherTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFreightTotal
        '
        Me.txtFreightTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightTotal.Location = New System.Drawing.Point(142, 55)
        Me.txtFreightTotal.Margin = New System.Windows.Forms.Padding(5)
        Me.txtFreightTotal.Name = "txtFreightTotal"
        Me.txtFreightTotal.Size = New System.Drawing.Size(198, 20)
        Me.txtFreightTotal.TabIndex = 22
        Me.txtFreightTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(19, 26)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 20)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Steel Total"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(19, 116)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 20)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Invoice Total"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInvoiceTotal
        '
        Me.lblInvoiceTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInvoiceTotal.Location = New System.Drawing.Point(142, 114)
        Me.lblInvoiceTotal.Margin = New System.Windows.Forms.Padding(5)
        Me.lblInvoiceTotal.Name = "lblInvoiceTotal"
        Me.lblInvoiceTotal.Size = New System.Drawing.Size(197, 20)
        Me.lblInvoiceTotal.TabIndex = 25
        Me.lblInvoiceTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSteelTotal
        '
        Me.lblSteelTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSteelTotal.Location = New System.Drawing.Point(142, 26)
        Me.lblSteelTotal.Margin = New System.Windows.Forms.Padding(5)
        Me.lblSteelTotal.Name = "lblSteelTotal"
        Me.lblSteelTotal.Size = New System.Drawing.Size(197, 20)
        Me.lblSteelTotal.TabIndex = 26
        Me.lblSteelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblSteelTotal)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblInvoiceTotal)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtOtherTotal)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtFreightTotal)
        Me.GroupBox1.Location = New System.Drawing.Point(401, 658)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(357, 153)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Steel Totals"
        '
        'SteelReceivingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpxSelectLines)
        Me.Controls.Add(Me.gpxPostSteelReceipt)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.gpxHeaderInfo)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.dgvSteelReceiving)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "SteelReceivingForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Steel Receiving Program"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxHeaderInfo.ResumeLayout(False)
        Me.gpxHeaderInfo.PerformLayout()
        CType(Me.dgvSteelReceiving, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxPostSteelReceipt.ResumeLayout(False)
        Me.gpxSelectLines.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxHeaderInfo As System.Windows.Forms.GroupBox
    Friend WithEvents dtpSteelReceivingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cboSteelVendor As System.Windows.Forms.ComboBox
    Friend WithEvents cboSteelRecTicket As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvSteelReceiving As System.Windows.Forms.DataGridView
    Friend WithEvents cmdGenerateReceivingTicket As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtSteelComment As System.Windows.Forms.TextBox
    Friend WithEvents txtSteelBOL As System.Windows.Forms.TextBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents SteelReceivingLineKeyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiveWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmdSaveAndPost As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtReceivingStatus As System.Windows.Forms.TextBox
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdSelectLines As System.Windows.Forms.Button
    Friend WithEvents gpxPostSteelReceipt As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents gpxSelectLines As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SaveReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboSteelPO As System.Windows.Forms.ComboBox
    Friend WithEvents SteelReceivingLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiveWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCostPerPoundColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReceivingHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelVendorColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents tmrWaitToPrint As System.Windows.Forms.Timer
    Friend WithEvents UnLockReceiverToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOtherTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtFreightTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblInvoiceTotal As System.Windows.Forms.Label
    Friend WithEvents lblSteelTotal As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
