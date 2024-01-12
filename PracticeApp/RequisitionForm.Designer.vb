<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RequisitionForm
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveRequisitionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteRequisitionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintRequisitionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxRequisitionData = New System.Windows.Forms.GroupBox
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.RequisitionEntryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.cboRequisitionNumber = New System.Windows.Forms.ComboBox
        Me.cmdGenerateNewReq = New System.Windows.Forms.Button
        Me.cboVendor = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtRequestedBy = New System.Windows.Forms.TextBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpReqDate = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cndEnter = New System.Windows.Forms.Button
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.txtCost = New System.Windows.Forms.TextBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtPartNumber = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdViewOpen = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.dgvRequisitionTable = New System.Windows.Forms.DataGridView
        Me.RequisitionNumberDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReqDateDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RequestedByDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmdViewPending = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdViewClosed = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cboReqNumber = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmdCloseReq = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmdApproveReq = New System.Windows.Forms.Button
        Me.RequisitionNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReqDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RequestedByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RequisitionEntryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RequisitionEntryTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.MenuStrip1.SuspendLayout()
        Me.gpxRequisitionData.SuspendLayout()
        CType(Me.RequisitionEntryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRequisitionTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveRequisitionToolStripMenuItem, Me.DeleteRequisitionToolStripMenuItem, Me.PrintRequisitionToolStripMenuItem, Me.ClearFormToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveRequisitionToolStripMenuItem
        '
        Me.SaveRequisitionToolStripMenuItem.Name = "SaveRequisitionToolStripMenuItem"
        Me.SaveRequisitionToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.SaveRequisitionToolStripMenuItem.Text = "Save Requisition"
        '
        'DeleteRequisitionToolStripMenuItem
        '
        Me.DeleteRequisitionToolStripMenuItem.Name = "DeleteRequisitionToolStripMenuItem"
        Me.DeleteRequisitionToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.DeleteRequisitionToolStripMenuItem.Text = "Delete Requisition"
        '
        'PrintRequisitionToolStripMenuItem
        '
        Me.PrintRequisitionToolStripMenuItem.Name = "PrintRequisitionToolStripMenuItem"
        Me.PrintRequisitionToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.PrintRequisitionToolStripMenuItem.Text = "Print Requisition"
        '
        'ClearFormToolStripMenuItem
        '
        Me.ClearFormToolStripMenuItem.Name = "ClearFormToolStripMenuItem"
        Me.ClearFormToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ClearFormToolStripMenuItem.Text = "Clear Form"
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
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(964, 721)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 25
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxRequisitionData
        '
        Me.gpxRequisitionData.Controls.Add(Me.txtVendorName)
        Me.gpxRequisitionData.Controls.Add(Me.Label18)
        Me.gpxRequisitionData.Controls.Add(Me.txtStatus)
        Me.gpxRequisitionData.Controls.Add(Me.cboRequisitionNumber)
        Me.gpxRequisitionData.Controls.Add(Me.cmdGenerateNewReq)
        Me.gpxRequisitionData.Controls.Add(Me.cboVendor)
        Me.gpxRequisitionData.Controls.Add(Me.Label11)
        Me.gpxRequisitionData.Controls.Add(Me.txtRequestedBy)
        Me.gpxRequisitionData.Controls.Add(Me.cboDivisionID)
        Me.gpxRequisitionData.Controls.Add(Me.dtpReqDate)
        Me.gpxRequisitionData.Controls.Add(Me.Label9)
        Me.gpxRequisitionData.Controls.Add(Me.Label3)
        Me.gpxRequisitionData.Controls.Add(Me.Label2)
        Me.gpxRequisitionData.Controls.Add(Me.Label1)
        Me.gpxRequisitionData.Location = New System.Drawing.Point(29, 41)
        Me.gpxRequisitionData.Name = "gpxRequisitionData"
        Me.gpxRequisitionData.Size = New System.Drawing.Size(352, 297)
        Me.gpxRequisitionData.TabIndex = 0
        Me.gpxRequisitionData.TabStop = False
        Me.gpxRequisitionData.Text = "Requisition Data"
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RequisitionEntryBindingSource, "Description", True))
        Me.txtVendorName.Location = New System.Drawing.Point(24, 211)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(309, 69)
        Me.txtVendorName.TabIndex = 6
        Me.txtVendorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RequisitionEntryBindingSource
        '
        Me.RequisitionEntryBindingSource.DataMember = "RequisitionEntry"
        Me.RequisitionEntryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(21, 251)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 20)
        Me.Label18.TabIndex = 20
        Me.Label18.Text = "Status"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtStatus
        '
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStatus.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RequisitionEntryBindingSource, "PartNumber", True))
        Me.txtStatus.Enabled = False
        Me.txtStatus.Location = New System.Drawing.Point(156, 251)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(177, 20)
        Me.txtStatus.TabIndex = 6
        Me.txtStatus.TabStop = False
        Me.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboRequisitionNumber
        '
        Me.cboRequisitionNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRequisitionNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRequisitionNumber.DataSource = Me.RequisitionEntryBindingSource
        Me.cboRequisitionNumber.DisplayMember = "RequisitionNumber"
        Me.cboRequisitionNumber.FormattingEnabled = True
        Me.cboRequisitionNumber.Location = New System.Drawing.Point(156, 19)
        Me.cboRequisitionNumber.Name = "cboRequisitionNumber"
        Me.cboRequisitionNumber.Size = New System.Drawing.Size(177, 21)
        Me.cboRequisitionNumber.TabIndex = 1
        '
        'cmdGenerateNewReq
        '
        Me.cmdGenerateNewReq.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateNewReq.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateNewReq.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateNewReq.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateNewReq.Location = New System.Drawing.Point(124, 20)
        Me.cmdGenerateNewReq.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateNewReq.Name = "cmdGenerateNewReq"
        Me.cmdGenerateNewReq.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateNewReq.TabIndex = 0
        Me.cmdGenerateNewReq.Text = ">>"
        Me.cmdGenerateNewReq.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateNewReq.UseVisualStyleBackColor = False
        '
        'cboVendor
        '
        Me.cboVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendor.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RequisitionEntryBindingSource, "VendorID", True))
        Me.cboVendor.DataSource = Me.VendorBindingSource
        Me.cboVendor.DisplayMember = "VendorCode"
        Me.cboVendor.FormattingEnabled = True
        Me.cboVendor.Location = New System.Drawing.Point(89, 180)
        Me.cboVendor.Name = "cboVendor"
        Me.cboVendor.Size = New System.Drawing.Size(244, 21)
        Me.cboVendor.TabIndex = 5
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(21, 181)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Vendor"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRequestedBy
        '
        Me.txtRequestedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRequestedBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRequestedBy.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RequisitionEntryBindingSource, "RequestedBy", True))
        Me.txtRequestedBy.Location = New System.Drawing.Point(156, 108)
        Me.txtRequestedBy.Name = "txtRequestedBy"
        Me.txtRequestedBy.Size = New System.Drawing.Size(177, 20)
        Me.txtRequestedBy.TabIndex = 4
        Me.txtRequestedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RequisitionEntryBindingSource, "DivisionID", True))
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(156, 78)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(177, 21)
        Me.cboDivisionID.TabIndex = 3
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpReqDate
        '
        Me.dtpReqDate.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RequisitionEntryBindingSource, "ReqDate", True))
        Me.dtpReqDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReqDate.Location = New System.Drawing.Point(156, 49)
        Me.dtpReqDate.Name = "dtpReqDate"
        Me.dtpReqDate.Size = New System.Drawing.Size(177, 20)
        Me.dtpReqDate.TabIndex = 2
        Me.dtpReqDate.Value = New Date(2011, 9, 22, 0, 0, 0, 0)
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(21, 79)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Division ID"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(21, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Requested By"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(21, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Requisition Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(21, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Requisition Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(262, 347)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cndEnter
        '
        Me.cndEnter.Location = New System.Drawing.Point(185, 347)
        Me.cndEnter.Name = "cndEnter"
        Me.cndEnter.Size = New System.Drawing.Size(71, 40)
        Me.cndEnter.TabIndex = 13
        Me.cndEnter.Text = "Enter"
        Me.cndEnter.UseVisualStyleBackColor = True
        '
        'txtComment
        '
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RequisitionEntryBindingSource, "Comment", True))
        Me.txtComment.Location = New System.Drawing.Point(24, 246)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(309, 81)
        Me.txtComment.TabIndex = 12
        Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(21, 223)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Comment"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotal
        '
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotal.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RequisitionEntryBindingSource, "Total", True))
        Me.txtTotal.Location = New System.Drawing.Point(195, 202)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(138, 20)
        Me.txtTotal.TabIndex = 11
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuantity
        '
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuantity.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RequisitionEntryBindingSource, "Quantity", True))
        Me.txtQuantity.Location = New System.Drawing.Point(195, 140)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(138, 20)
        Me.txtQuantity.TabIndex = 9
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCost
        '
        Me.txtCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCost.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RequisitionEntryBindingSource, "Cost", True))
        Me.txtCost.Location = New System.Drawing.Point(195, 171)
        Me.txtCost.Name = "txtCost"
        Me.txtCost.Size = New System.Drawing.Size(138, 20)
        Me.txtCost.TabIndex = 10
        Me.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescription.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RequisitionEntryBindingSource, "Description", True))
        Me.txtDescription.Location = New System.Drawing.Point(24, 71)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(309, 60)
        Me.txtDescription.TabIndex = 8
        Me.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPartNumber
        '
        Me.txtPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNumber.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RequisitionEntryBindingSource, "PartNumber", True))
        Me.txtPartNumber.Location = New System.Drawing.Point(101, 25)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.Size = New System.Drawing.Size(232, 20)
        Me.txtPartNumber.TabIndex = 7
        Me.txtPartNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(21, 140)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Quantity"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(21, 200)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Total"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(21, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Description"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(21, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Cost"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(21, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Part Number"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewOpen
        '
        Me.cmdViewOpen.Location = New System.Drawing.Point(15, 38)
        Me.cmdViewOpen.Name = "cmdViewOpen"
        Me.cmdViewOpen.Size = New System.Drawing.Size(20, 20)
        Me.cmdViewOpen.TabIndex = 15
        Me.cmdViewOpen.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(733, 721)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 22
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(810, 721)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 23
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(887, 721)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 24
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'dgvRequisitionTable
        '
        Me.dgvRequisitionTable.AllowUserToAddRows = False
        Me.dgvRequisitionTable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRequisitionTable.AutoGenerateColumns = False
        Me.dgvRequisitionTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvRequisitionTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRequisitionTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RequisitionNumberDataGridViewTextBoxColumn1, Me.ReqDateDataGridViewTextBoxColumn1, Me.PartNumberDataGridViewTextBoxColumn1, Me.DescriptionDataGridViewTextBoxColumn1, Me.CommentDataGridViewTextBoxColumn, Me.RequestedByDataGridViewTextBoxColumn1, Me.CostDataGridViewTextBoxColumn1, Me.QuantityDataGridViewTextBoxColumn1, Me.TotalDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn, Me.VendorIDDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn1})
        Me.dgvRequisitionTable.DataSource = Me.RequisitionEntryBindingSource
        Me.dgvRequisitionTable.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvRequisitionTable.Location = New System.Drawing.Point(400, 41)
        Me.dgvRequisitionTable.Name = "dgvRequisitionTable"
        Me.dgvRequisitionTable.Size = New System.Drawing.Size(633, 500)
        Me.dgvRequisitionTable.TabIndex = 7
        Me.dgvRequisitionTable.TabStop = False
        '
        'RequisitionNumberDataGridViewTextBoxColumn1
        '
        Me.RequisitionNumberDataGridViewTextBoxColumn1.DataPropertyName = "RequisitionNumber"
        Me.RequisitionNumberDataGridViewTextBoxColumn1.HeaderText = "Req. #"
        Me.RequisitionNumberDataGridViewTextBoxColumn1.Name = "RequisitionNumberDataGridViewTextBoxColumn1"
        Me.RequisitionNumberDataGridViewTextBoxColumn1.Width = 65
        '
        'ReqDateDataGridViewTextBoxColumn1
        '
        Me.ReqDateDataGridViewTextBoxColumn1.DataPropertyName = "ReqDate"
        Me.ReqDateDataGridViewTextBoxColumn1.HeaderText = "Date"
        Me.ReqDateDataGridViewTextBoxColumn1.Name = "ReqDateDataGridViewTextBoxColumn1"
        Me.ReqDateDataGridViewTextBoxColumn1.Width = 65
        '
        'PartNumberDataGridViewTextBoxColumn1
        '
        Me.PartNumberDataGridViewTextBoxColumn1.DataPropertyName = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn1.HeaderText = "Part Number"
        Me.PartNumberDataGridViewTextBoxColumn1.Name = "PartNumberDataGridViewTextBoxColumn1"
        '
        'DescriptionDataGridViewTextBoxColumn1
        '
        Me.DescriptionDataGridViewTextBoxColumn1.DataPropertyName = "Description"
        Me.DescriptionDataGridViewTextBoxColumn1.HeaderText = "Description"
        Me.DescriptionDataGridViewTextBoxColumn1.Name = "DescriptionDataGridViewTextBoxColumn1"
        '
        'CommentDataGridViewTextBoxColumn
        '
        Me.CommentDataGridViewTextBoxColumn.DataPropertyName = "Comment"
        Me.CommentDataGridViewTextBoxColumn.HeaderText = "Comment"
        Me.CommentDataGridViewTextBoxColumn.Name = "CommentDataGridViewTextBoxColumn"
        '
        'RequestedByDataGridViewTextBoxColumn1
        '
        Me.RequestedByDataGridViewTextBoxColumn1.DataPropertyName = "RequestedBy"
        Me.RequestedByDataGridViewTextBoxColumn1.HeaderText = "Requested By"
        Me.RequestedByDataGridViewTextBoxColumn1.Name = "RequestedByDataGridViewTextBoxColumn1"
        '
        'CostDataGridViewTextBoxColumn1
        '
        Me.CostDataGridViewTextBoxColumn1.DataPropertyName = "Cost"
        Me.CostDataGridViewTextBoxColumn1.HeaderText = "Cost"
        Me.CostDataGridViewTextBoxColumn1.Name = "CostDataGridViewTextBoxColumn1"
        Me.CostDataGridViewTextBoxColumn1.Width = 85
        '
        'QuantityDataGridViewTextBoxColumn1
        '
        Me.QuantityDataGridViewTextBoxColumn1.DataPropertyName = "Quantity"
        Me.QuantityDataGridViewTextBoxColumn1.HeaderText = "Quantity"
        Me.QuantityDataGridViewTextBoxColumn1.Name = "QuantityDataGridViewTextBoxColumn1"
        Me.QuantityDataGridViewTextBoxColumn1.Width = 85
        '
        'TotalDataGridViewTextBoxColumn
        '
        Me.TotalDataGridViewTextBoxColumn.DataPropertyName = "Total"
        Me.TotalDataGridViewTextBoxColumn.HeaderText = "Total"
        Me.TotalDataGridViewTextBoxColumn.Name = "TotalDataGridViewTextBoxColumn"
        Me.TotalDataGridViewTextBoxColumn.Width = 85
        '
        'StatusDataGridViewTextBoxColumn
        '
        Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
        Me.StatusDataGridViewTextBoxColumn.HeaderText = "Status"
        Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
        '
        'VendorIDDataGridViewTextBoxColumn
        '
        Me.VendorIDDataGridViewTextBoxColumn.DataPropertyName = "VendorID"
        Me.VendorIDDataGridViewTextBoxColumn.HeaderText = "VendorID"
        Me.VendorIDDataGridViewTextBoxColumn.Name = "VendorIDDataGridViewTextBoxColumn"
        '
        'DivisionIDDataGridViewTextBoxColumn1
        '
        Me.DivisionIDDataGridViewTextBoxColumn1.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn1.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn1.Name = "DivisionIDDataGridViewTextBoxColumn1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.cmdViewPending)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cmdViewClosed)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cmdViewOpen)
        Me.GroupBox1.Location = New System.Drawing.Point(402, 561)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(294, 143)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "All Requisitions entered into this form are processed by the Main Office"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(41, 105)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(164, 20)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "View Pending Requisitions"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewPending
        '
        Me.cmdViewPending.Location = New System.Drawing.Point(15, 105)
        Me.cmdViewPending.Name = "cmdViewPending"
        Me.cmdViewPending.Size = New System.Drawing.Size(20, 20)
        Me.cmdViewPending.TabIndex = 17
        Me.cmdViewPending.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(41, 71)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(164, 20)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "View Closed Requisitions"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewClosed
        '
        Me.cmdViewClosed.Location = New System.Drawing.Point(15, 71)
        Me.cmdViewClosed.Name = "cmdViewClosed"
        Me.cmdViewClosed.Size = New System.Drawing.Size(20, 20)
        Me.cmdViewClosed.TabIndex = 16
        Me.cmdViewClosed.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(41, 38)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(164, 20)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "View Open Requisitions"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.cboReqNumber)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.cmdCloseReq)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.cmdApproveReq)
        Me.GroupBox2.Location = New System.Drawing.Point(733, 559)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(302, 143)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Approve Requisition"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(23, 27)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 20)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Requisition Number"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboReqNumber
        '
        Me.cboReqNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReqNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReqNumber.DataSource = Me.RequisitionEntryBindingSource
        Me.cboReqNumber.DisplayMember = "RequisitionNumber"
        Me.cboReqNumber.FormattingEnabled = True
        Me.cboReqNumber.Location = New System.Drawing.Point(129, 26)
        Me.cboReqNumber.Name = "cboReqNumber"
        Me.cboReqNumber.Size = New System.Drawing.Size(156, 21)
        Me.cboReqNumber.TabIndex = 19
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(52, 105)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(111, 20)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "Close Requisition"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCloseReq
        '
        Me.cmdCloseReq.Location = New System.Drawing.Point(26, 105)
        Me.cmdCloseReq.Name = "cmdCloseReq"
        Me.cmdCloseReq.Size = New System.Drawing.Size(20, 20)
        Me.cmdCloseReq.TabIndex = 21
        Me.cmdCloseReq.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(52, 71)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(111, 20)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Approve Requisition"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdApproveReq
        '
        Me.cmdApproveReq.Location = New System.Drawing.Point(26, 71)
        Me.cmdApproveReq.Name = "cmdApproveReq"
        Me.cmdApproveReq.Size = New System.Drawing.Size(20, 20)
        Me.cmdApproveReq.TabIndex = 20
        Me.cmdApproveReq.UseVisualStyleBackColor = True
        '
        'RequisitionNumberDataGridViewTextBoxColumn
        '
        Me.RequisitionNumberDataGridViewTextBoxColumn.DataPropertyName = "RequisitionNumber"
        Me.RequisitionNumberDataGridViewTextBoxColumn.HeaderText = "Requisition#"
        Me.RequisitionNumberDataGridViewTextBoxColumn.Name = "RequisitionNumberDataGridViewTextBoxColumn"
        '
        'ReqDateDataGridViewTextBoxColumn
        '
        Me.ReqDateDataGridViewTextBoxColumn.DataPropertyName = "ReqDate"
        Me.ReqDateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.ReqDateDataGridViewTextBoxColumn.Name = "ReqDateDataGridViewTextBoxColumn"
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "Division ID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        '
        'PartNumberDataGridViewTextBoxColumn
        '
        Me.PartNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn.HeaderText = "Part Number"
        Me.PartNumberDataGridViewTextBoxColumn.Name = "PartNumberDataGridViewTextBoxColumn"
        '
        'DescriptionDataGridViewTextBoxColumn
        '
        Me.DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        '
        'RequestedByDataGridViewTextBoxColumn
        '
        Me.RequestedByDataGridViewTextBoxColumn.DataPropertyName = "RequestedBy"
        Me.RequestedByDataGridViewTextBoxColumn.HeaderText = "Requested By"
        Me.RequestedByDataGridViewTextBoxColumn.Name = "RequestedByDataGridViewTextBoxColumn"
        '
        'CostDataGridViewTextBoxColumn
        '
        Me.CostDataGridViewTextBoxColumn.DataPropertyName = "Cost"
        DataGridViewCellStyle1.Format = "C4"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.CostDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.CostDataGridViewTextBoxColumn.HeaderText = "Cost"
        Me.CostDataGridViewTextBoxColumn.Name = "CostDataGridViewTextBoxColumn"
        '
        'QuantityDataGridViewTextBoxColumn
        '
        Me.QuantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity"
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.QuantityDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.QuantityDataGridViewTextBoxColumn.HeaderText = "Quantity"
        Me.QuantityDataGridViewTextBoxColumn.Name = "QuantityDataGridViewTextBoxColumn"
        '
        'RequisitionEntryTableAdapter
        '
        Me.RequisitionEntryTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtPartNumber)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtDescription)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtCost)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtQuantity)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.cmdClear)
        Me.GroupBox3.Controls.Add(Me.txtTotal)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.cndEnter)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtComment)
        Me.GroupBox3.Location = New System.Drawing.Point(29, 359)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(352, 402)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Part Data"
        '
        'RequisitionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 773)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvRequisitionTable)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.gpxRequisitionData)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "RequisitionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Requisition Form"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxRequisitionData.ResumeLayout(False)
        Me.gpxRequisitionData.PerformLayout()
        CType(Me.RequisitionEntryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRequisitionTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxRequisitionData As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpReqDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents txtCost As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtRequestedBy As System.Windows.Forms.TextBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cndEnter As System.Windows.Forms.Button
    Friend WithEvents cmdViewOpen As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cboVendor As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdGenerateNewReq As System.Windows.Forms.Button
    Friend WithEvents cboRequisitionNumber As System.Windows.Forms.ComboBox
    Friend WithEvents dgvRequisitionTable As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmdViewPending As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmdViewClosed As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmdApproveReq As System.Windows.Forms.Button
    Friend WithEvents RequisitionNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReqDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RequestedByDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmdCloseReq As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents RequisitionEntryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RequisitionEntryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RequisitionEntryTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboReqNumber As System.Windows.Forms.ComboBox
    Friend WithEvents SaveRequisitionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteRequisitionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintRequisitionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RequisitionNumberDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReqDateDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RequestedByDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
