<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SteelVendorReturnForm
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
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ManuallyCloseReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnLockReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxPOHeaderData = New System.Windows.Forms.GroupBox
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.cboReturnNumber = New System.Windows.Forms.ComboBox
        Me.SteelReturnHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpReturnDate = New System.Windows.Forms.DateTimePicker
        Me.cboVendorCode = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdGenerateReturnNumber = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblPaymentTerms = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblPODate = New System.Windows.Forms.Label
        Me.lblVendorName = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.cboPurchaseOrderNumber = New System.Windows.Forms.ComboBox
        Me.SteelPurchaseOrderHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblPONumber = New System.Windows.Forms.Label
        Me.txtExtendedAmount = New System.Windows.Forms.TextBox
        Me.cmdEnter = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.lblExtendedAmount = New System.Windows.Forms.Label
        Me.lblUnitCost = New System.Windows.Forms.Label
        Me.txtUnitCost = New System.Windows.Forms.TextBox
        Me.lblOrderQuantity = New System.Windows.Forms.Label
        Me.txtReturnedQuantity = New System.Windows.Forms.TextBox
        Me.lblSteelSize = New System.Windows.Forms.Label
        Me.lblCarbon = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.gpxReturnTotals = New System.Windows.Forms.GroupBox
        Me.txtOther = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtProductTotal = New System.Windows.Forms.TextBox
        Me.txtReturnTotal = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtFreight = New System.Windows.Forms.TextBox
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdSelectByCoil = New System.Windows.Forms.Button
        Me.cboSelectSteelSize = New System.Windows.Forms.ComboBox
        Me.cboSelectCarbon = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdSelectByPO = New System.Windows.Forms.Button
        Me.gpxPostReturn = New System.Windows.Forms.GroupBox
        Me.cmdPostReturn = New System.Windows.Forms.Button
        Me.Label21 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.cboDeleteLineNumber = New System.Windows.Forms.ComboBox
        Me.SteelReturnLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label23 = New System.Windows.Forms.Label
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.grpManualEntry = New System.Windows.Forms.GroupBox
        Me.cboCoilID = New System.Windows.Forms.ComboBox
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtHeatNumber = New System.Windows.Forms.TextBox
        Me.lblHeat = New System.Windows.Forms.Label
        Me.dgvSteelReturnLines = New System.Windows.Forms.DataGridView
        Me.SteelReturnNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReturnLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLDebitAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLCreditAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReturnLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReturnLineTableTableAdapter
        Me.SteelReturnHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReturnHeaderTableTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.SteelPurchaseOrderHeaderTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelPurchaseOrderHeaderTableAdapter
        Me.CharterSteelCoilIdentificationTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CharterSteelCoilIdentificationTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxPOHeaderData.SuspendLayout()
        CType(Me.SteelReturnHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelPurchaseOrderHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxReturnTotals.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gpxPostReturn.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.SteelReturnLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpManualEntry.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSteelReturnLines, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.PrintToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ClearDataToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.SaveToolStripMenuItem.Text = "Save Return"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.PrintToolStripMenuItem.Text = "Print Return"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete Return"
        '
        'ClearDataToolStripMenuItem
        '
        Me.ClearDataToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ClearDataToolStripMenuItem.Name = "ClearDataToolStripMenuItem"
        Me.ClearDataToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ClearDataToolStripMenuItem.Text = "Clear Data"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManuallyCloseReturnToolStripMenuItem, Me.UnLockReturnToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ManuallyCloseReturnToolStripMenuItem
        '
        Me.ManuallyCloseReturnToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ManuallyCloseReturnToolStripMenuItem.Name = "ManuallyCloseReturnToolStripMenuItem"
        Me.ManuallyCloseReturnToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ManuallyCloseReturnToolStripMenuItem.Text = "Manually Close Return"
        '
        'UnLockReturnToolStripMenuItem
        '
        Me.UnLockReturnToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.UnLockReturnToolStripMenuItem.Name = "UnLockReturnToolStripMenuItem"
        Me.UnLockReturnToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.UnLockReturnToolStripMenuItem.Text = "Un-Lock Return"
        Me.UnLockReturnToolStripMenuItem.Visible = False
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
        Me.ExitToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(947, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 30
        Me.cmdExit.Text = "Exit Return"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxPOHeaderData
        '
        Me.gpxPOHeaderData.Controls.Add(Me.txtVendorName)
        Me.gpxPOHeaderData.Controls.Add(Me.txtStatus)
        Me.gpxPOHeaderData.Controls.Add(Me.cboReturnNumber)
        Me.gpxPOHeaderData.Controls.Add(Me.txtComment)
        Me.gpxPOHeaderData.Controls.Add(Me.cboDivisionID)
        Me.gpxPOHeaderData.Controls.Add(Me.dtpReturnDate)
        Me.gpxPOHeaderData.Controls.Add(Me.cboVendorCode)
        Me.gpxPOHeaderData.Controls.Add(Me.cmdGenerateReturnNumber)
        Me.gpxPOHeaderData.Controls.Add(Me.Label3)
        Me.gpxPOHeaderData.Controls.Add(Me.lblPaymentTerms)
        Me.gpxPOHeaderData.Controls.Add(Me.Label15)
        Me.gpxPOHeaderData.Controls.Add(Me.lblPODate)
        Me.gpxPOHeaderData.Controls.Add(Me.lblVendorName)
        Me.gpxPOHeaderData.Controls.Add(Me.Label22)
        Me.gpxPOHeaderData.Location = New System.Drawing.Point(29, 41)
        Me.gpxPOHeaderData.Name = "gpxPOHeaderData"
        Me.gpxPOHeaderData.Size = New System.Drawing.Size(315, 407)
        Me.gpxPOHeaderData.TabIndex = 0
        Me.gpxPOHeaderData.TabStop = False
        Me.gpxPOHeaderData.Text = "Vendor Return Data"
        '
        'txtVendorName
        '
        Me.txtVendorName.BackColor = System.Drawing.SystemColors.Control
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Location = New System.Drawing.Point(16, 146)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.ReadOnly = True
        Me.txtVendorName.Size = New System.Drawing.Size(282, 59)
        Me.txtVendorName.TabIndex = 5
        Me.txtVendorName.TabStop = False
        Me.txtVendorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtStatus
        '
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStatus.Location = New System.Drawing.Point(109, 215)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(188, 20)
        Me.txtStatus.TabIndex = 6
        Me.txtStatus.TabStop = False
        Me.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboReturnNumber
        '
        Me.cboReturnNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReturnNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReturnNumber.DataSource = Me.SteelReturnHeaderTableBindingSource
        Me.cboReturnNumber.DisplayMember = "SteelReturnNumber"
        Me.cboReturnNumber.FormattingEnabled = True
        Me.cboReturnNumber.Location = New System.Drawing.Point(111, 23)
        Me.cboReturnNumber.Name = "cboReturnNumber"
        Me.cboReturnNumber.Size = New System.Drawing.Size(189, 21)
        Me.cboReturnNumber.TabIndex = 1
        '
        'SteelReturnHeaderTableBindingSource
        '
        Me.SteelReturnHeaderTableBindingSource.DataMember = "SteelReturnHeaderTable"
        Me.SteelReturnHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtComment
        '
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(15, 274)
        Me.txtComment.MaxLength = 200
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(283, 115)
        Me.txtComment.TabIndex = 7
        Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(110, 54)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(189, 21)
        Me.cboDivisionID.TabIndex = 2
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpReturnDate
        '
        Me.dtpReturnDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReturnDate.Location = New System.Drawing.Point(112, 85)
        Me.dtpReturnDate.Name = "dtpReturnDate"
        Me.dtpReturnDate.Size = New System.Drawing.Size(188, 20)
        Me.dtpReturnDate.TabIndex = 3
        '
        'cboVendorCode
        '
        Me.cboVendorCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorCode.DataSource = Me.VendorBindingSource
        Me.cboVendorCode.DisplayMember = "VendorCode"
        Me.cboVendorCode.FormattingEnabled = True
        Me.cboVendorCode.Location = New System.Drawing.Point(110, 115)
        Me.cboVendorCode.Name = "cboVendorCode"
        Me.cboVendorCode.Size = New System.Drawing.Size(190, 21)
        Me.cboVendorCode.TabIndex = 4
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdGenerateReturnNumber
        '
        Me.cmdGenerateReturnNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateReturnNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateReturnNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateReturnNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateReturnNumber.Location = New System.Drawing.Point(77, 24)
        Me.cmdGenerateReturnNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateReturnNumber.Name = "cmdGenerateReturnNumber"
        Me.cmdGenerateReturnNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateReturnNumber.TabIndex = 0
        Me.cmdGenerateReturnNumber.Text = ">>"
        Me.cmdGenerateReturnNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateReturnNumber.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 20)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Vendor ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPaymentTerms
        '
        Me.lblPaymentTerms.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaymentTerms.Location = New System.Drawing.Point(16, 251)
        Me.lblPaymentTerms.Name = "lblPaymentTerms"
        Me.lblPaymentTerms.Size = New System.Drawing.Size(239, 20)
        Me.lblPaymentTerms.TabIndex = 7
        Me.lblPaymentTerms.Text = "Comments (200 characters MAX)"
        Me.lblPaymentTerms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(16, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(98, 20)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "Return #"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPODate
        '
        Me.lblPODate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPODate.Location = New System.Drawing.Point(17, 85)
        Me.lblPODate.Name = "lblPODate"
        Me.lblPODate.Size = New System.Drawing.Size(98, 20)
        Me.lblPODate.TabIndex = 5
        Me.lblPODate.Text = "Date Issued"
        Me.lblPODate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVendorName
        '
        Me.lblVendorName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendorName.Location = New System.Drawing.Point(17, 55)
        Me.lblVendorName.Name = "lblVendorName"
        Me.lblVendorName.Size = New System.Drawing.Size(98, 20)
        Me.lblVendorName.TabIndex = 3
        Me.lblVendorName.Text = "Division ID"
        Me.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(17, 215)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(98, 20)
        Me.Label22.TabIndex = 42
        Me.Label22.Text = "Status"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPurchaseOrderNumber
        '
        Me.cboPurchaseOrderNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPurchaseOrderNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPurchaseOrderNumber.DataSource = Me.SteelPurchaseOrderHeaderBindingSource
        Me.cboPurchaseOrderNumber.DisplayMember = "SteelPurchaseOrderKey"
        Me.cboPurchaseOrderNumber.FormattingEnabled = True
        Me.cboPurchaseOrderNumber.Location = New System.Drawing.Point(92, 21)
        Me.cboPurchaseOrderNumber.Name = "cboPurchaseOrderNumber"
        Me.cboPurchaseOrderNumber.Size = New System.Drawing.Size(221, 21)
        Me.cboPurchaseOrderNumber.TabIndex = 1
        '
        'SteelPurchaseOrderHeaderBindingSource
        '
        Me.SteelPurchaseOrderHeaderBindingSource.DataMember = "SteelPurchaseOrderHeader"
        Me.SteelPurchaseOrderHeaderBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'lblPONumber
        '
        Me.lblPONumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPONumber.Location = New System.Drawing.Point(8, 24)
        Me.lblPONumber.Name = "lblPONumber"
        Me.lblPONumber.Size = New System.Drawing.Size(98, 20)
        Me.lblPONumber.TabIndex = 1
        Me.lblPONumber.Text = "PO #"
        Me.lblPONumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtExtendedAmount
        '
        Me.txtExtendedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExtendedAmount.Location = New System.Drawing.Point(141, 221)
        Me.txtExtendedAmount.Name = "txtExtendedAmount"
        Me.txtExtendedAmount.ReadOnly = True
        Me.txtExtendedAmount.Size = New System.Drawing.Size(157, 20)
        Me.txtExtendedAmount.TabIndex = 14
        Me.txtExtendedAmount.TabStop = False
        Me.txtExtendedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdEnter
        '
        Me.cmdEnter.Location = New System.Drawing.Point(153, 317)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(71, 30)
        Me.cmdEnter.TabIndex = 17
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(229, 317)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 18
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'lblExtendedAmount
        '
        Me.lblExtendedAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExtendedAmount.Location = New System.Drawing.Point(15, 221)
        Me.lblExtendedAmount.Name = "lblExtendedAmount"
        Me.lblExtendedAmount.Size = New System.Drawing.Size(98, 20)
        Me.lblExtendedAmount.TabIndex = 20
        Me.lblExtendedAmount.Text = "Extended Amount"
        Me.lblExtendedAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUnitCost
        '
        Me.lblUnitCost.Location = New System.Drawing.Point(15, 190)
        Me.lblUnitCost.Name = "lblUnitCost"
        Me.lblUnitCost.Size = New System.Drawing.Size(98, 20)
        Me.lblUnitCost.TabIndex = 20
        Me.lblUnitCost.Text = "Unit Cost"
        Me.lblUnitCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnitCost
        '
        Me.txtUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitCost.Location = New System.Drawing.Point(141, 190)
        Me.txtUnitCost.Name = "txtUnitCost"
        Me.txtUnitCost.Size = New System.Drawing.Size(157, 20)
        Me.txtUnitCost.TabIndex = 13
        Me.txtUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOrderQuantity
        '
        Me.lblOrderQuantity.Location = New System.Drawing.Point(15, 159)
        Me.lblOrderQuantity.Name = "lblOrderQuantity"
        Me.lblOrderQuantity.Size = New System.Drawing.Size(98, 20)
        Me.lblOrderQuantity.TabIndex = 21
        Me.lblOrderQuantity.Text = "Return Quantity"
        Me.lblOrderQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReturnedQuantity
        '
        Me.txtReturnedQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnedQuantity.Location = New System.Drawing.Point(141, 159)
        Me.txtReturnedQuantity.Name = "txtReturnedQuantity"
        Me.txtReturnedQuantity.Size = New System.Drawing.Size(157, 20)
        Me.txtReturnedQuantity.TabIndex = 12
        Me.txtReturnedQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSteelSize
        '
        Me.lblSteelSize.Location = New System.Drawing.Point(13, 58)
        Me.lblSteelSize.Name = "lblSteelSize"
        Me.lblSteelSize.Size = New System.Drawing.Size(78, 20)
        Me.lblSteelSize.TabIndex = 20
        Me.lblSteelSize.Text = "Steel Size"
        Me.lblSteelSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCarbon
        '
        Me.lblCarbon.Location = New System.Drawing.Point(13, 26)
        Me.lblCarbon.Name = "lblCarbon"
        Me.lblCarbon.Size = New System.Drawing.Size(78, 20)
        Me.lblCarbon.TabIndex = 19
        Me.lblCarbon.Text = "Carbon"
        Me.lblCarbon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Location = New System.Drawing.Point(13, 89)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(284, 57)
        Me.txtDescription.TabIndex = 11
        Me.txtDescription.TabStop = False
        Me.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSteelSize.DisplayMember = "SteelSize"
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(99, 57)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(200, 21)
        Me.cboSteelSize.TabIndex = 10
        '
        'RawMaterialsTableBindingSource
        '
        Me.RawMaterialsTableBindingSource.DataMember = "RawMaterialsTable"
        Me.RawMaterialsTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboCarbon.DisplayMember = "Carbon"
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(99, 25)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(200, 21)
        Me.cboCarbon.TabIndex = 9
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(716, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 27
        Me.cmdSave.Text = "Save Return"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(793, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 28
        Me.cmdDelete.Text = "Delete Return"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(870, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 29
        Me.cmdPrint.Text = "Print Return"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'gpxReturnTotals
        '
        Me.gpxReturnTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxReturnTotals.Controls.Add(Me.txtOther)
        Me.gpxReturnTotals.Controls.Add(Me.Label5)
        Me.gpxReturnTotals.Controls.Add(Me.Label6)
        Me.gpxReturnTotals.Controls.Add(Me.txtProductTotal)
        Me.gpxReturnTotals.Controls.Add(Me.txtReturnTotal)
        Me.gpxReturnTotals.Controls.Add(Me.Label1)
        Me.gpxReturnTotals.Controls.Add(Me.Label4)
        Me.gpxReturnTotals.Controls.Add(Me.txtFreight)
        Me.gpxReturnTotals.Location = New System.Drawing.Point(714, 568)
        Me.gpxReturnTotals.Name = "gpxReturnTotals"
        Me.gpxReturnTotals.Size = New System.Drawing.Size(304, 137)
        Me.gpxReturnTotals.TabIndex = 22
        Me.gpxReturnTotals.TabStop = False
        Me.gpxReturnTotals.Text = "Return Totals"
        '
        'txtOther
        '
        Me.txtOther.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOther.Location = New System.Drawing.Point(135, 47)
        Me.txtOther.Name = "txtOther"
        Me.txtOther.Size = New System.Drawing.Size(148, 20)
        Me.txtOther.TabIndex = 23
        Me.txtOther.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 20)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Other"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 20)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Product Total"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProductTotal
        '
        Me.txtProductTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtProductTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductTotal.Location = New System.Drawing.Point(135, 20)
        Me.txtProductTotal.Name = "txtProductTotal"
        Me.txtProductTotal.ReadOnly = True
        Me.txtProductTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtProductTotal.TabIndex = 22
        Me.txtProductTotal.TabStop = False
        Me.txtProductTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReturnTotal
        '
        Me.txtReturnTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtReturnTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnTotal.Location = New System.Drawing.Point(135, 101)
        Me.txtReturnTotal.Name = "txtReturnTotal"
        Me.txtReturnTotal.ReadOnly = True
        Me.txtReturnTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtReturnTotal.TabIndex = 25
        Me.txtReturnTotal.TabStop = False
        Me.txtReturnTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 20)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Return Total"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 20)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Freight"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFreight
        '
        Me.txtFreight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreight.Location = New System.Drawing.Point(135, 74)
        Me.txtFreight.Name = "txtFreight"
        Me.txtFreight.Size = New System.Drawing.Size(148, 20)
        Me.txtFreight.TabIndex = 24
        Me.txtFreight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(716, 718)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 26
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdSelectByCoil)
        Me.GroupBox1.Controls.Add(Me.cboSelectSteelSize)
        Me.GroupBox1.Controls.Add(Me.cboSelectCarbon)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboPurchaseOrderNumber)
        Me.GroupBox1.Controls.Add(Me.cmdSelectByPO)
        Me.GroupBox1.Controls.Add(Me.lblPONumber)
        Me.GroupBox1.Location = New System.Drawing.Point(358, 568)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(340, 243)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Coils"
        '
        'cmdSelectByCoil
        '
        Me.cmdSelectByCoil.ForeColor = System.Drawing.Color.Blue
        Me.cmdSelectByCoil.Location = New System.Drawing.Point(242, 188)
        Me.cmdSelectByCoil.Name = "cmdSelectByCoil"
        Me.cmdSelectByCoil.Size = New System.Drawing.Size(70, 41)
        Me.cmdSelectByCoil.TabIndex = 43
        Me.cmdSelectByCoil.Text = "Select By Coil"
        Me.cmdSelectByCoil.UseVisualStyleBackColor = True
        '
        'cboSelectSteelSize
        '
        Me.cboSelectSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSelectSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSelectSteelSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSelectSteelSize.DisplayMember = "SteelSize"
        Me.cboSelectSteelSize.FormattingEnabled = True
        Me.cboSelectSteelSize.Location = New System.Drawing.Point(92, 157)
        Me.cboSelectSteelSize.Name = "cboSelectSteelSize"
        Me.cboSelectSteelSize.Size = New System.Drawing.Size(221, 21)
        Me.cboSelectSteelSize.TabIndex = 42
        '
        'cboSelectCarbon
        '
        Me.cboSelectCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSelectCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSelectCarbon.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSelectCarbon.DisplayMember = "Carbon"
        Me.cboSelectCarbon.FormattingEnabled = True
        Me.cboSelectCarbon.Location = New System.Drawing.Point(92, 126)
        Me.cboSelectCarbon.Name = "cboSelectCarbon"
        Me.cboSelectCarbon.Size = New System.Drawing.Size(221, 21)
        Me.cboSelectCarbon.TabIndex = 38
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 158)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 20)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Steel Size"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 127)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 20)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "Carbon"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(8, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(183, 40)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Select steel from PO to return."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(8, 188)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(188, 40)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Select from Coil List to return."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSelectByPO
        '
        Me.cmdSelectByPO.ForeColor = System.Drawing.Color.Blue
        Me.cmdSelectByPO.Location = New System.Drawing.Point(242, 48)
        Me.cmdSelectByPO.Name = "cmdSelectByPO"
        Me.cmdSelectByPO.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectByPO.TabIndex = 18
        Me.cmdSelectByPO.Text = "Select By PO"
        Me.cmdSelectByPO.UseVisualStyleBackColor = True
        '
        'gpxPostReturn
        '
        Me.gpxPostReturn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxPostReturn.Controls.Add(Me.cmdPostReturn)
        Me.gpxPostReturn.Controls.Add(Me.Label21)
        Me.gpxPostReturn.Location = New System.Drawing.Point(714, 460)
        Me.gpxPostReturn.Name = "gpxPostReturn"
        Me.gpxPostReturn.Size = New System.Drawing.Size(304, 99)
        Me.gpxPostReturn.TabIndex = 21
        Me.gpxPostReturn.TabStop = False
        Me.gpxPostReturn.Text = "Post Return"
        '
        'cmdPostReturn
        '
        Me.cmdPostReturn.ForeColor = System.Drawing.Color.Blue
        Me.cmdPostReturn.Location = New System.Drawing.Point(212, 49)
        Me.cmdPostReturn.Name = "cmdPostReturn"
        Me.cmdPostReturn.Size = New System.Drawing.Size(71, 40)
        Me.cmdPostReturn.TabIndex = 21
        Me.cmdPostReturn.Text = "Post Return"
        Me.cmdPostReturn.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Blue
        Me.Label21.Location = New System.Drawing.Point(16, 26)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(267, 40)
        Me.Label21.TabIndex = 35
        Me.Label21.Text = "Post Return to correct inventory. No changes may be made to return after posting." & _
            ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.cboDeleteLineNumber)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.cmdDeleteLine)
        Me.GroupBox2.Location = New System.Drawing.Point(358, 454)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(340, 105)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Delete Line"
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Blue
        Me.Label24.Location = New System.Drawing.Point(6, 58)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(219, 35)
        Me.Label24.TabIndex = 36
        Me.Label24.Text = "Select Return Line from datagrid or combobox to delete."
        '
        'cboDeleteLineNumber
        '
        Me.cboDeleteLineNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDeleteLineNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDeleteLineNumber.DataSource = Me.SteelReturnLineTableBindingSource
        Me.cboDeleteLineNumber.DisplayMember = "SteelReturnLine"
        Me.cboDeleteLineNumber.FormattingEnabled = True
        Me.cboDeleteLineNumber.Location = New System.Drawing.Point(149, 19)
        Me.cboDeleteLineNumber.Name = "cboDeleteLineNumber"
        Me.cboDeleteLineNumber.Size = New System.Drawing.Size(164, 21)
        Me.cboDeleteLineNumber.TabIndex = 19
        '
        'SteelReturnLineTableBindingSource
        '
        Me.SteelReturnLineTableBindingSource.DataMember = "SteelReturnLineTable"
        Me.SteelReturnLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(17, 20)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(126, 20)
        Me.Label23.TabIndex = 22
        Me.Label23.Text = "Return Line Number"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.ForeColor = System.Drawing.Color.Blue
        Me.cmdDeleteLine.Location = New System.Drawing.Point(242, 53)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteLine.TabIndex = 20
        Me.cmdDeleteLine.Text = "Delete Line"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'grpManualEntry
        '
        Me.grpManualEntry.Controls.Add(Me.cboCoilID)
        Me.grpManualEntry.Controls.Add(Me.Label7)
        Me.grpManualEntry.Controls.Add(Me.txtHeatNumber)
        Me.grpManualEntry.Controls.Add(Me.lblHeat)
        Me.grpManualEntry.Controls.Add(Me.cmdClear)
        Me.grpManualEntry.Controls.Add(Me.cboCarbon)
        Me.grpManualEntry.Controls.Add(Me.cmdEnter)
        Me.grpManualEntry.Controls.Add(Me.lblSteelSize)
        Me.grpManualEntry.Controls.Add(Me.txtExtendedAmount)
        Me.grpManualEntry.Controls.Add(Me.txtReturnedQuantity)
        Me.grpManualEntry.Controls.Add(Me.lblOrderQuantity)
        Me.grpManualEntry.Controls.Add(Me.txtDescription)
        Me.grpManualEntry.Controls.Add(Me.lblCarbon)
        Me.grpManualEntry.Controls.Add(Me.cboSteelSize)
        Me.grpManualEntry.Controls.Add(Me.txtUnitCost)
        Me.grpManualEntry.Controls.Add(Me.lblExtendedAmount)
        Me.grpManualEntry.Controls.Add(Me.lblUnitCost)
        Me.grpManualEntry.Location = New System.Drawing.Point(29, 454)
        Me.grpManualEntry.Name = "grpManualEntry"
        Me.grpManualEntry.Size = New System.Drawing.Size(315, 357)
        Me.grpManualEntry.TabIndex = 8
        Me.grpManualEntry.TabStop = False
        Me.grpManualEntry.Text = "Manual Entry / Update"
        '
        'cboCoilID
        '
        Me.cboCoilID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCoilID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCoilID.DataSource = Me.BindingSource1
        Me.cboCoilID.DisplayMember = "CoilID"
        Me.cboCoilID.FormattingEnabled = True
        Me.cboCoilID.Location = New System.Drawing.Point(76, 283)
        Me.cboCoilID.Name = "cboCoilID"
        Me.cboCoilID.Size = New System.Drawing.Size(223, 21)
        Me.cboCoilID.TabIndex = 16
        '
        'BindingSource1
        '
        Me.BindingSource1.DataMember = "CharterSteelCoilIdentification"
        Me.BindingSource1.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 283)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 20)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Coil ID"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtHeatNumber
        '
        Me.txtHeatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeatNumber.Location = New System.Drawing.Point(76, 252)
        Me.txtHeatNumber.Name = "txtHeatNumber"
        Me.txtHeatNumber.Size = New System.Drawing.Size(221, 20)
        Me.txtHeatNumber.TabIndex = 15
        Me.txtHeatNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblHeat
        '
        Me.lblHeat.Location = New System.Drawing.Point(15, 252)
        Me.lblHeat.Name = "lblHeat"
        Me.lblHeat.Size = New System.Drawing.Size(98, 20)
        Me.lblHeat.TabIndex = 23
        Me.lblHeat.Text = "Heat #"
        Me.lblHeat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvSteelReturnLines
        '
        Me.dgvSteelReturnLines.AllowUserToAddRows = False
        Me.dgvSteelReturnLines.AllowUserToDeleteRows = False
        Me.dgvSteelReturnLines.AutoGenerateColumns = False
        Me.dgvSteelReturnLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelReturnLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSteelReturnLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelReturnLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SteelReturnNumberColumn, Me.SteelReturnLineColumn, Me.RMIDColumn, Me.ReturnQuantityColumn, Me.UnitCostColumn, Me.ExtendedCostColumn, Me.LineCommentColumn, Me.GLDebitAccountColumn, Me.GLCreditAccountColumn, Me.LineStatusColumn})
        Me.dgvSteelReturnLines.DataSource = Me.SteelReturnLineTableBindingSource
        Me.dgvSteelReturnLines.GridColor = System.Drawing.Color.Teal
        Me.dgvSteelReturnLines.Location = New System.Drawing.Point(358, 41)
        Me.dgvSteelReturnLines.Name = "dgvSteelReturnLines"
        Me.dgvSteelReturnLines.Size = New System.Drawing.Size(660, 407)
        Me.dgvSteelReturnLines.TabIndex = 32
        '
        'SteelReturnNumberColumn
        '
        Me.SteelReturnNumberColumn.DataPropertyName = "SteelReturnNumber"
        Me.SteelReturnNumberColumn.HeaderText = "SteelReturnNumber"
        Me.SteelReturnNumberColumn.Name = "SteelReturnNumberColumn"
        Me.SteelReturnNumberColumn.Visible = False
        '
        'SteelReturnLineColumn
        '
        Me.SteelReturnLineColumn.DataPropertyName = "SteelReturnLine"
        Me.SteelReturnLineColumn.HeaderText = "Line #"
        Me.SteelReturnLineColumn.Name = "SteelReturnLineColumn"
        Me.SteelReturnLineColumn.ReadOnly = True
        Me.SteelReturnLineColumn.Width = 65
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        Me.RMIDColumn.ReadOnly = True
        Me.RMIDColumn.Width = 150
        '
        'ReturnQuantityColumn
        '
        Me.ReturnQuantityColumn.DataPropertyName = "ReturnQuantity"
        DataGridViewCellStyle19.Format = "N0"
        DataGridViewCellStyle19.NullValue = "0"
        Me.ReturnQuantityColumn.DefaultCellStyle = DataGridViewCellStyle19
        Me.ReturnQuantityColumn.HeaderText = "Return Qty."
        Me.ReturnQuantityColumn.Name = "ReturnQuantityColumn"
        Me.ReturnQuantityColumn.Width = 90
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle20.Format = "N4"
        DataGridViewCellStyle20.NullValue = "0"
        Me.UnitCostColumn.DefaultCellStyle = DataGridViewCellStyle20
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.Width = 90
        '
        'ExtendedCostColumn
        '
        Me.ExtendedCostColumn.DataPropertyName = "ExtendedCost"
        DataGridViewCellStyle21.Format = "N2"
        DataGridViewCellStyle21.NullValue = "0"
        Me.ExtendedCostColumn.DefaultCellStyle = DataGridViewCellStyle21
        Me.ExtendedCostColumn.HeaderText = "Ext. Cost"
        Me.ExtendedCostColumn.Name = "ExtendedCostColumn"
        Me.ExtendedCostColumn.ReadOnly = True
        Me.ExtendedCostColumn.Width = 90
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        Me.LineCommentColumn.Width = 150
        '
        'GLDebitAccountColumn
        '
        Me.GLDebitAccountColumn.DataPropertyName = "GLDebitAccount"
        Me.GLDebitAccountColumn.HeaderText = "GLDebitAccount"
        Me.GLDebitAccountColumn.Name = "GLDebitAccountColumn"
        Me.GLDebitAccountColumn.Visible = False
        '
        'GLCreditAccountColumn
        '
        Me.GLCreditAccountColumn.DataPropertyName = "GLCreditAccount"
        Me.GLCreditAccountColumn.HeaderText = "GLCreditAccount"
        Me.GLCreditAccountColumn.Name = "GLCreditAccountColumn"
        Me.GLCreditAccountColumn.Visible = False
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "LineStatus"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.ReadOnly = True
        Me.LineStatusColumn.Visible = False
        '
        'SteelReturnLineTableTableAdapter
        '
        Me.SteelReturnLineTableTableAdapter.ClearBeforeFill = True
        '
        'SteelReturnHeaderTableTableAdapter
        '
        Me.SteelReturnHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'SteelPurchaseOrderHeaderTableAdapter
        '
        Me.SteelPurchaseOrderHeaderTableAdapter.ClearBeforeFill = True
        '
        'CharterSteelCoilIdentificationTableAdapter
        '
        Me.CharterSteelCoilIdentificationTableAdapter.ClearBeforeFill = True
        '
        'SteelVendorReturnForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.dgvSteelReturnLines)
        Me.Controls.Add(Me.grpManualEntry)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gpxPostReturn)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpxReturnTotals)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.gpxPOHeaderData)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "SteelVendorReturnForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Steel Vendor Returns"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxPOHeaderData.ResumeLayout(False)
        Me.gpxPOHeaderData.PerformLayout()
        CType(Me.SteelReturnHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelPurchaseOrderHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxReturnTotals.ResumeLayout(False)
        Me.gpxReturnTotals.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.gpxPostReturn.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.SteelReturnLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpManualEntry.ResumeLayout(False)
        Me.grpManualEntry.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSteelReturnLines, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents gpxPOHeaderData As System.Windows.Forms.GroupBox
    Friend WithEvents cboReturnNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdGenerateReturnNumber As System.Windows.Forms.Button
    Friend WithEvents cboPurchaseOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents dtpReturnDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboVendorCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPONumber As System.Windows.Forms.Label
    Friend WithEvents lblPaymentTerms As System.Windows.Forms.Label
    Friend WithEvents lblPODate As System.Windows.Forms.Label
    Friend WithEvents lblVendorName As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents lblExtendedAmount As System.Windows.Forms.Label
    Friend WithEvents lblUnitCost As System.Windows.Forms.Label
    Friend WithEvents lblOrderQuantity As System.Windows.Forms.Label
    Friend WithEvents txtUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents txtReturnedQuantity As System.Windows.Forms.TextBox
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents lblSteelSize As System.Windows.Forms.Label
    Friend WithEvents lblCarbon As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents txtExtendedAmount As System.Windows.Forms.TextBox
    Friend WithEvents gpxReturnTotals As System.Windows.Forms.GroupBox
    Friend WithEvents txtReturnTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFreight As System.Windows.Forms.TextBox
    Friend WithEvents txtOther As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtProductTotal As System.Windows.Forms.TextBox
    Friend WithEvents cmdSelectLinesFromReceiver As System.Windows.Forms.Button
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents ClearDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gpxPostReturn As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmdPostReturn As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cboDeleteLineNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ManuallyCloseReturnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpManualEntry As System.Windows.Forms.GroupBox
    Friend WithEvents txtHeatNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblHeat As System.Windows.Forms.Label
    Friend WithEvents UnLockReturnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdSelectByPO As System.Windows.Forms.Button
    Friend WithEvents dgvSteelReturnLines As System.Windows.Forms.DataGridView
    Friend WithEvents cboCoilID As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CharterSteelCoilIdentificationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboSelectCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSelectSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents SteelReturnLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelReturnLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReturnLineTableTableAdapter
    Friend WithEvents SteelReturnNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReturnLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDebitAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCreditAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReturnHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelReturnHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReturnHeaderTableTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents SteelPurchaseOrderHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelPurchaseOrderHeaderTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelPurchaseOrderHeaderTableAdapter
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents CharterSteelCoilIdentificationTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CharterSteelCoilIdentificationTableAdapter
    Friend WithEvents cmdSelectByCoil As System.Windows.Forms.Button
End Class
