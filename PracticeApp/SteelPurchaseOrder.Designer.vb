<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SteelPurchaseOrder
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
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SavePOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeletePOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintPOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearPOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ManuallyClosePOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ManuallyOpenPOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxSteelHeaderInfo = New System.Windows.Forms.GroupBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.dtpSteelPODate = New System.Windows.Forms.DateTimePicker
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboSteelVendor = New System.Windows.Forms.ComboBox
        Me.cmdGeneratePONumber = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboSteelPONumber = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblPONumber = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.dgvSteelPurchaseLines = New System.Windows.Forms.DataGridView
        Me.gpxPOTotals = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtSteelPOTotal = New System.Windows.Forms.TextBox
        Me.txtOtherTotal = New System.Windows.Forms.TextBox
        Me.txtSteelTotal = New System.Windows.Forms.TextBox
        Me.txtFreightTotal = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdDeleteSelected = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboSteelCarbon = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtCostPerPound = New System.Windows.Forms.TextBox
        Me.txtPurchaseQuantity = New System.Windows.Forms.TextBox
        Me.txtExtendedAmount = New System.Windows.Forms.TextBox
        Me.cmdClearLines = New System.Windows.Forms.Button
        Me.cmdEnterLines = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cboShipMethod = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.dtpEstShipDate = New System.Windows.Forms.DateTimePicker
        Me.dtpRequireDate = New System.Windows.Forms.DateTimePicker
        Me.gpxPurchaseLines = New System.Windows.Forms.GroupBox
        Me.lblSteelDescription = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtLineComment = New System.Windows.Forms.TextBox
        Me.txtLastPurchasePrice = New System.Windows.Forms.TextBox
        Me.lblLastPurchasePrice = New System.Windows.Forms.Label
        Me.txtSuggestedAmount = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.cmdReissue = New System.Windows.Forms.Button
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxSteelHeaderInfo.SuspendLayout()
        CType(Me.dgvSteelPurchaseLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxPOTotals.SuspendLayout()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxPurchaseLines.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(828, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 22
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(905, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 23
        Me.cmdDelete.Text = "Delete PO"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 24
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 25
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 18
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SavePOToolStripMenuItem, Me.DeletePOToolStripMenuItem, Me.PrintPOToolStripMenuItem, Me.ClearPOToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SavePOToolStripMenuItem
        '
        Me.SavePOToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.SavePOToolStripMenuItem.Name = "SavePOToolStripMenuItem"
        Me.SavePOToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SavePOToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.SavePOToolStripMenuItem.Text = "Save"
        '
        'DeletePOToolStripMenuItem
        '
        Me.DeletePOToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.DeletePOToolStripMenuItem.Name = "DeletePOToolStripMenuItem"
        Me.DeletePOToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.DeletePOToolStripMenuItem.Text = "Delete"
        '
        'PrintPOToolStripMenuItem
        '
        Me.PrintPOToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.PrintPOToolStripMenuItem.Name = "PrintPOToolStripMenuItem"
        Me.PrintPOToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.PrintPOToolStripMenuItem.Text = "Print"
        '
        'ClearPOToolStripMenuItem
        '
        Me.ClearPOToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ClearPOToolStripMenuItem.Name = "ClearPOToolStripMenuItem"
        Me.ClearPOToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ClearPOToolStripMenuItem.Text = "Clear All"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManuallyClosePOToolStripMenuItem, Me.ManuallyOpenPOToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ManuallyClosePOToolStripMenuItem
        '
        Me.ManuallyClosePOToolStripMenuItem.Name = "ManuallyClosePOToolStripMenuItem"
        Me.ManuallyClosePOToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ManuallyClosePOToolStripMenuItem.Text = "Manually Close PO"
        '
        'ManuallyOpenPOToolStripMenuItem
        '
        Me.ManuallyOpenPOToolStripMenuItem.Name = "ManuallyOpenPOToolStripMenuItem"
        Me.ManuallyOpenPOToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ManuallyOpenPOToolStripMenuItem.Text = "Manually Open PO"
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
        'gpxSteelHeaderInfo
        '
        Me.gpxSteelHeaderInfo.Controls.Add(Me.cboDivisionID)
        Me.gpxSteelHeaderInfo.Controls.Add(Me.dtpSteelPODate)
        Me.gpxSteelHeaderInfo.Controls.Add(Me.txtStatus)
        Me.gpxSteelHeaderInfo.Controls.Add(Me.Label17)
        Me.gpxSteelHeaderInfo.Controls.Add(Me.cboSteelVendor)
        Me.gpxSteelHeaderInfo.Controls.Add(Me.cmdGeneratePONumber)
        Me.gpxSteelHeaderInfo.Controls.Add(Me.Label3)
        Me.gpxSteelHeaderInfo.Controls.Add(Me.cboSteelPONumber)
        Me.gpxSteelHeaderInfo.Controls.Add(Me.Label2)
        Me.gpxSteelHeaderInfo.Controls.Add(Me.lblPONumber)
        Me.gpxSteelHeaderInfo.Controls.Add(Me.Label22)
        Me.gpxSteelHeaderInfo.Location = New System.Drawing.Point(29, 41)
        Me.gpxSteelHeaderInfo.Name = "gpxSteelHeaderInfo"
        Me.gpxSteelHeaderInfo.Size = New System.Drawing.Size(320, 206)
        Me.gpxSteelHeaderInfo.TabIndex = 0
        Me.gpxSteelHeaderInfo.TabStop = False
        Me.gpxSteelHeaderInfo.Text = "Steel Purchase Header"
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(92, 61)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(209, 21)
        Me.cboDivisionID.TabIndex = 1
        '
        'dtpSteelPODate
        '
        Me.dtpSteelPODate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSteelPODate.Location = New System.Drawing.Point(92, 97)
        Me.dtpSteelPODate.Name = "dtpSteelPODate"
        Me.dtpSteelPODate.Size = New System.Drawing.Size(209, 20)
        Me.dtpSteelPODate.TabIndex = 2
        '
        'txtStatus
        '
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStatus.Location = New System.Drawing.Point(92, 168)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(209, 20)
        Me.txtStatus.TabIndex = 4
        Me.txtStatus.TabStop = False
        Me.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(18, 169)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 20)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "Status"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelVendor
        '
        Me.cboSteelVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelVendor.FormattingEnabled = True
        Me.cboSteelVendor.Location = New System.Drawing.Point(92, 132)
        Me.cboSteelVendor.Name = "cboSteelVendor"
        Me.cboSteelVendor.Size = New System.Drawing.Size(209, 21)
        Me.cboSteelVendor.TabIndex = 3
        '
        'cmdGeneratePONumber
        '
        Me.cmdGeneratePONumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGeneratePONumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGeneratePONumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGeneratePONumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGeneratePONumber.Location = New System.Drawing.Point(92, 25)
        Me.cmdGeneratePONumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGeneratePONumber.Name = "cmdGeneratePONumber"
        Me.cmdGeneratePONumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdGeneratePONumber.TabIndex = 0
        Me.cmdGeneratePONumber.TabStop = False
        Me.cmdGeneratePONumber.Text = ">>"
        Me.cmdGeneratePONumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGeneratePONumber.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(18, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Steel PO #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelPONumber
        '
        Me.cboSteelPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelPONumber.FormattingEnabled = True
        Me.cboSteelPONumber.Location = New System.Drawing.Point(124, 25)
        Me.cboSteelPONumber.Name = "cboSteelPONumber"
        Me.cboSteelPONumber.Size = New System.Drawing.Size(177, 21)
        Me.cboSteelPONumber.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Division ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPONumber
        '
        Me.lblPONumber.Location = New System.Drawing.Point(18, 133)
        Me.lblPONumber.Name = "lblPONumber"
        Me.lblPONumber.Size = New System.Drawing.Size(100, 20)
        Me.lblPONumber.TabIndex = 26
        Me.lblPONumber.Text = "Vendor"
        Me.lblPONumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(18, 97)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(100, 20)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "PO Date"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(364, 603)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Comment"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComment
        '
        Me.txtComment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(367, 626)
        Me.txtComment.MaxLength = 200
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(330, 130)
        Me.txtComment.TabIndex = 16
        Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvSteelPurchaseLines
        '
        Me.dgvSteelPurchaseLines.AllowDrop = True
        Me.dgvSteelPurchaseLines.AllowUserToAddRows = False
        Me.dgvSteelPurchaseLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSteelPurchaseLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelPurchaseLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelPurchaseLines.Location = New System.Drawing.Point(367, 41)
        Me.dgvSteelPurchaseLines.Name = "dgvSteelPurchaseLines"
        Me.dgvSteelPurchaseLines.Size = New System.Drawing.Size(763, 552)
        Me.dgvSteelPurchaseLines.TabIndex = 21
        Me.dgvSteelPurchaseLines.TabStop = False
        '
        'gpxPOTotals
        '
        Me.gpxPOTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxPOTotals.Controls.Add(Me.Label13)
        Me.gpxPOTotals.Controls.Add(Me.txtSteelPOTotal)
        Me.gpxPOTotals.Controls.Add(Me.txtOtherTotal)
        Me.gpxPOTotals.Controls.Add(Me.txtSteelTotal)
        Me.gpxPOTotals.Controls.Add(Me.txtFreightTotal)
        Me.gpxPOTotals.Controls.Add(Me.Label10)
        Me.gpxPOTotals.Controls.Add(Me.Label11)
        Me.gpxPOTotals.Controls.Add(Me.Label12)
        Me.gpxPOTotals.Location = New System.Drawing.Point(751, 613)
        Me.gpxPOTotals.Name = "gpxPOTotals"
        Me.gpxPOTotals.Size = New System.Drawing.Size(379, 143)
        Me.gpxPOTotals.TabIndex = 18
        Me.gpxPOTotals.TabStop = False
        Me.gpxPOTotals.Text = "Steel Purchase Order Totals"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(21, 105)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 20)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "Steel PO Total"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSteelPOTotal
        '
        Me.txtSteelPOTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelPOTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelPOTotal.Location = New System.Drawing.Point(169, 105)
        Me.txtSteelPOTotal.Name = "txtSteelPOTotal"
        Me.txtSteelPOTotal.ReadOnly = True
        Me.txtSteelPOTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtSteelPOTotal.TabIndex = 20
        Me.txtSteelPOTotal.TabStop = False
        Me.txtSteelPOTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOtherTotal
        '
        Me.txtOtherTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOtherTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOtherTotal.Location = New System.Drawing.Point(169, 77)
        Me.txtOtherTotal.Name = "txtOtherTotal"
        Me.txtOtherTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtOtherTotal.TabIndex = 19
        Me.txtOtherTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSteelTotal
        '
        Me.txtSteelTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelTotal.Location = New System.Drawing.Point(169, 21)
        Me.txtSteelTotal.Name = "txtSteelTotal"
        Me.txtSteelTotal.ReadOnly = True
        Me.txtSteelTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtSteelTotal.TabIndex = 17
        Me.txtSteelTotal.TabStop = False
        Me.txtSteelTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFreightTotal
        '
        Me.txtFreightTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreightTotal.Location = New System.Drawing.Point(169, 49)
        Me.txtFreightTotal.Name = "txtFreightTotal"
        Me.txtFreightTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtFreightTotal.TabIndex = 18
        Me.txtFreightTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(21, 77)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Other Charge"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(21, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "Freight Total"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(21, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 20)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Steel Total"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(367, 771)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 21
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdDeleteSelected
        '
        Me.cmdDeleteSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteSelected.Location = New System.Drawing.Point(444, 771)
        Me.cmdDeleteSelected.Name = "cmdDeleteSelected"
        Me.cmdDeleteSelected.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteSelected.TabIndex = 50
        Me.cmdDeleteSelected.Text = "Delete Line"
        Me.cmdDeleteSelected.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Steel Size"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Carbon/Alloy"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSteelSize.DisplayMember = "SteelSize"
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(110, 54)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(189, 21)
        Me.cboSteelSize.TabIndex = 6
        '
        'RawMaterialsTableBindingSource
        '
        Me.RawMaterialsTableBindingSource.DataMember = "RawMaterialsTable"
        Me.RawMaterialsTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboSteelCarbon
        '
        Me.cboSteelCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelCarbon.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSteelCarbon.DisplayMember = "Carbon"
        Me.cboSteelCarbon.FormattingEnabled = True
        Me.cboSteelCarbon.Location = New System.Drawing.Point(110, 25)
        Me.cboSteelCarbon.Name = "cboSteelCarbon"
        Me.cboSteelCarbon.Size = New System.Drawing.Size(189, 21)
        Me.cboSteelCarbon.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 20)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Purchase Quantity"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 221)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 20)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Cost Per Pound"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 253)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 20)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "Extended Amount"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCostPerPound
        '
        Me.txtCostPerPound.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCostPerPound.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCostPerPound.Location = New System.Drawing.Point(151, 221)
        Me.txtCostPerPound.Name = "txtCostPerPound"
        Me.txtCostPerPound.Size = New System.Drawing.Size(148, 20)
        Me.txtCostPerPound.TabIndex = 8
        Me.txtCostPerPound.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPurchaseQuantity
        '
        Me.txtPurchaseQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPurchaseQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPurchaseQuantity.Location = New System.Drawing.Point(151, 128)
        Me.txtPurchaseQuantity.Name = "txtPurchaseQuantity"
        Me.txtPurchaseQuantity.Size = New System.Drawing.Size(148, 20)
        Me.txtPurchaseQuantity.TabIndex = 7
        Me.txtPurchaseQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtExtendedAmount
        '
        Me.txtExtendedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExtendedAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExtendedAmount.Location = New System.Drawing.Point(151, 252)
        Me.txtExtendedAmount.Name = "txtExtendedAmount"
        Me.txtExtendedAmount.ReadOnly = True
        Me.txtExtendedAmount.Size = New System.Drawing.Size(148, 20)
        Me.txtExtendedAmount.TabIndex = 10
        Me.txtExtendedAmount.TabStop = False
        Me.txtExtendedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdClearLines
        '
        Me.cmdClearLines.Location = New System.Drawing.Point(230, 513)
        Me.cmdClearLines.Name = "cmdClearLines"
        Me.cmdClearLines.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearLines.TabIndex = 14
        Me.cmdClearLines.Text = "Clear"
        Me.cmdClearLines.UseVisualStyleBackColor = True
        '
        'cmdEnterLines
        '
        Me.cmdEnterLines.Location = New System.Drawing.Point(153, 513)
        Me.cmdEnterLines.Name = "cmdEnterLines"
        Me.cmdEnterLines.Size = New System.Drawing.Size(71, 30)
        Me.cmdEnterLines.TabIndex = 13
        Me.cmdEnterLines.Text = "Enter"
        Me.cmdEnterLines.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(21, 448)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 20)
        Me.Label14.TabIndex = 39
        Me.Label14.Text = "Require Date"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(21, 478)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 20)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "Est. Ship Date"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipMethod
        '
        Me.cboShipMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipMethod.FormattingEnabled = True
        Me.cboShipMethod.Items.AddRange(New Object() {"TRUCK", "RAIL CAR"})
        Me.cboShipMethod.Location = New System.Drawing.Point(19, 408)
        Me.cboShipMethod.Name = "cboShipMethod"
        Me.cboShipMethod.Size = New System.Drawing.Size(280, 21)
        Me.cboShipMethod.TabIndex = 10
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(16, 385)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 20)
        Me.Label16.TabIndex = 42
        Me.Label16.Text = "Ship Method"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEstShipDate
        '
        Me.dtpEstShipDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEstShipDate.Location = New System.Drawing.Point(153, 478)
        Me.dtpEstShipDate.Name = "dtpEstShipDate"
        Me.dtpEstShipDate.Size = New System.Drawing.Size(148, 20)
        Me.dtpEstShipDate.TabIndex = 12
        '
        'dtpRequireDate
        '
        Me.dtpRequireDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpRequireDate.Location = New System.Drawing.Point(153, 448)
        Me.dtpRequireDate.Name = "dtpRequireDate"
        Me.dtpRequireDate.Size = New System.Drawing.Size(148, 20)
        Me.dtpRequireDate.TabIndex = 11
        '
        'gpxPurchaseLines
        '
        Me.gpxPurchaseLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gpxPurchaseLines.Controls.Add(Me.lblSteelDescription)
        Me.gpxPurchaseLines.Controls.Add(Me.Label18)
        Me.gpxPurchaseLines.Controls.Add(Me.txtLineComment)
        Me.gpxPurchaseLines.Controls.Add(Me.txtLastPurchasePrice)
        Me.gpxPurchaseLines.Controls.Add(Me.lblLastPurchasePrice)
        Me.gpxPurchaseLines.Controls.Add(Me.txtSuggestedAmount)
        Me.gpxPurchaseLines.Controls.Add(Me.Label7)
        Me.gpxPurchaseLines.Controls.Add(Me.dtpRequireDate)
        Me.gpxPurchaseLines.Controls.Add(Me.dtpEstShipDate)
        Me.gpxPurchaseLines.Controls.Add(Me.Label16)
        Me.gpxPurchaseLines.Controls.Add(Me.cboShipMethod)
        Me.gpxPurchaseLines.Controls.Add(Me.Label15)
        Me.gpxPurchaseLines.Controls.Add(Me.Label14)
        Me.gpxPurchaseLines.Controls.Add(Me.cmdEnterLines)
        Me.gpxPurchaseLines.Controls.Add(Me.cmdClearLines)
        Me.gpxPurchaseLines.Controls.Add(Me.txtExtendedAmount)
        Me.gpxPurchaseLines.Controls.Add(Me.txtPurchaseQuantity)
        Me.gpxPurchaseLines.Controls.Add(Me.txtCostPerPound)
        Me.gpxPurchaseLines.Controls.Add(Me.Label9)
        Me.gpxPurchaseLines.Controls.Add(Me.Label8)
        Me.gpxPurchaseLines.Controls.Add(Me.Label6)
        Me.gpxPurchaseLines.Controls.Add(Me.cboSteelCarbon)
        Me.gpxPurchaseLines.Controls.Add(Me.cboSteelSize)
        Me.gpxPurchaseLines.Controls.Add(Me.Label1)
        Me.gpxPurchaseLines.Controls.Add(Me.Label5)
        Me.gpxPurchaseLines.Location = New System.Drawing.Point(29, 253)
        Me.gpxPurchaseLines.Name = "gpxPurchaseLines"
        Me.gpxPurchaseLines.Size = New System.Drawing.Size(320, 558)
        Me.gpxPurchaseLines.TabIndex = 5
        Me.gpxPurchaseLines.TabStop = False
        Me.gpxPurchaseLines.Text = "Steel Purchase Lines"
        '
        'lblSteelDescription
        '
        Me.lblSteelDescription.ForeColor = System.Drawing.Color.Blue
        Me.lblSteelDescription.Location = New System.Drawing.Point(17, 85)
        Me.lblSteelDescription.Name = "lblSteelDescription"
        Me.lblSteelDescription.Size = New System.Drawing.Size(282, 36)
        Me.lblSteelDescription.TabIndex = 53
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(16, 282)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(125, 20)
        Me.Label18.TabIndex = 52
        Me.Label18.Text = "Line Comment"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLineComment
        '
        Me.txtLineComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineComment.Location = New System.Drawing.Point(17, 305)
        Me.txtLineComment.MaxLength = 200
        Me.txtLineComment.Multiline = True
        Me.txtLineComment.Name = "txtLineComment"
        Me.txtLineComment.Size = New System.Drawing.Size(282, 77)
        Me.txtLineComment.TabIndex = 51
        Me.txtLineComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLastPurchasePrice
        '
        Me.txtLastPurchasePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastPurchasePrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastPurchasePrice.Location = New System.Drawing.Point(151, 190)
        Me.txtLastPurchasePrice.Name = "txtLastPurchasePrice"
        Me.txtLastPurchasePrice.ReadOnly = True
        Me.txtLastPurchasePrice.Size = New System.Drawing.Size(148, 20)
        Me.txtLastPurchasePrice.TabIndex = 45
        Me.txtLastPurchasePrice.TabStop = False
        Me.txtLastPurchasePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLastPurchasePrice
        '
        Me.lblLastPurchasePrice.Location = New System.Drawing.Point(16, 190)
        Me.lblLastPurchasePrice.Name = "lblLastPurchasePrice"
        Me.lblLastPurchasePrice.Size = New System.Drawing.Size(125, 20)
        Me.lblLastPurchasePrice.TabIndex = 46
        Me.lblLastPurchasePrice.Text = "Last Purchase Cost"
        Me.lblLastPurchasePrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSuggestedAmount
        '
        Me.txtSuggestedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSuggestedAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSuggestedAmount.Location = New System.Drawing.Point(151, 159)
        Me.txtSuggestedAmount.Name = "txtSuggestedAmount"
        Me.txtSuggestedAmount.ReadOnly = True
        Me.txtSuggestedAmount.Size = New System.Drawing.Size(148, 20)
        Me.txtSuggestedAmount.TabIndex = 43
        Me.txtSuggestedAmount.TabStop = False
        Me.txtSuggestedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 157)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 20)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "Suggested Amount"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(521, 781)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(100, 20)
        Me.Label19.TabIndex = 51
        Me.Label19.Text = "Select Line in grid."
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdReissue
        '
        Me.cmdReissue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReissue.Location = New System.Drawing.Point(751, 771)
        Me.cmdReissue.Name = "cmdReissue"
        Me.cmdReissue.Size = New System.Drawing.Size(71, 40)
        Me.cmdReissue.TabIndex = 52
        Me.cmdReissue.Text = "Re-issue PO"
        Me.cmdReissue.UseVisualStyleBackColor = True
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'SteelPurchaseOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdReissue)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cmdDeleteSelected)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.gpxPOTotals)
        Me.Controls.Add(Me.dgvSteelPurchaseLines)
        Me.Controls.Add(Me.gpxPurchaseLines)
        Me.Controls.Add(Me.gpxSteelHeaderInfo)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "SteelPurchaseOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Steel Purchase Order Program"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxSteelHeaderInfo.ResumeLayout(False)
        Me.gpxSteelHeaderInfo.PerformLayout()
        CType(Me.dgvSteelPurchaseLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxPOTotals.ResumeLayout(False)
        Me.gpxPOTotals.PerformLayout()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxPurchaseLines.ResumeLayout(False)
        Me.gpxPurchaseLines.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxSteelHeaderInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents cboSteelVendor As System.Windows.Forms.ComboBox
    Friend WithEvents cmdGeneratePONumber As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboSteelPONumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPONumber As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents dtpSteelPODate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents dgvSteelPurchaseLines As System.Windows.Forms.DataGridView
    Friend WithEvents gpxPOTotals As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSteelPOTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtOtherTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtSteelTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtFreightTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents SavePOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeletePOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents ClearPOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteSelected As System.Windows.Forms.Button
    Friend WithEvents SteelPurchaseOrderHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelPurchaseLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchasePricePerPoundColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboSteelCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCostPerPound As System.Windows.Forms.TextBox
    Friend WithEvents txtPurchaseQuantity As System.Windows.Forms.TextBox
    Friend WithEvents txtExtendedAmount As System.Windows.Forms.TextBox
    Friend WithEvents cmdClearLines As System.Windows.Forms.Button
    Friend WithEvents cmdEnterLines As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboShipMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dtpEstShipDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpRequireDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents gpxPurchaseLines As System.Windows.Forms.GroupBox
    Friend WithEvents txtSuggestedAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLastPurchasePrice As System.Windows.Forms.TextBox
    Friend WithEvents lblLastPurchasePrice As System.Windows.Forms.Label
    Friend WithEvents ManuallyClosePOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManuallyOpenPOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtLineComment As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmdReissue As System.Windows.Forms.Button
    Friend WithEvents lblSteelDescription As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
End Class
