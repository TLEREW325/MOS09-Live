<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NonInventoryItems
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxItemInformation = New System.Windows.Forms.GroupBox
        Me.chkCreateAll = New System.Windows.Forms.CheckBox
        Me.cmdAddNew = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdClearLines = New System.Windows.Forms.Button
        Me.txtCreditDescription = New System.Windows.Forms.TextBox
        Me.txtDebitDescription = New System.Windows.Forms.TextBox
        Me.cboCreditGLAccount = New System.Windows.Forms.ComboBox
        Me.GLAccountsBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboDebitGLAccount = New System.Windows.Forms.ComboBox
        Me.GLAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboShortDescription = New System.Windows.Forms.ComboBox
        Me.NonInventoryItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.cboPreferredVendor = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPurchaseProductLineID = New System.Windows.Forms.ComboBox
        Me.PurchaseProductLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboSalesProductLineID = New System.Windows.Forms.ComboBox
        Me.SalesProductLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtLongDescription = New System.Windows.Forms.TextBox
        Me.txtStandardOrderQuantity = New System.Windows.Forms.TextBox
        Me.txtStandardCost = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.dgvNonInventoryItemList = New System.Windows.Forms.DataGridView
        Me.ItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShortDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLDebitAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLCreditAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseProductLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesProductLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StandardCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PreferredVendorColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LongDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreationDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StandardOrderQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.SalesProductLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesProductLineTableAdapter
        Me.PurchaseProductLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseProductLineTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.GLAccountsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
        Me.NonInventoryItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.NonInventoryItemListTableAdapter
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxItemInformation.SuspendLayout()
        CType(Me.GLAccountsBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NonInventoryItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseProductLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesProductLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNonInventoryItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(961, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 19
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 1
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem
        '
        Me.PrintListingToolStripMenuItem.Name = "PrintListingToolStripMenuItem"
        Me.PrintListingToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.PrintListingToolStripMenuItem.Text = "Print Listing"
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
        'gpxItemInformation
        '
        Me.gpxItemInformation.Controls.Add(Me.chkCreateAll)
        Me.gpxItemInformation.Controls.Add(Me.cmdAddNew)
        Me.gpxItemInformation.Controls.Add(Me.cmdDelete)
        Me.gpxItemInformation.Controls.Add(Me.cmdClearLines)
        Me.gpxItemInformation.Controls.Add(Me.txtCreditDescription)
        Me.gpxItemInformation.Controls.Add(Me.txtDebitDescription)
        Me.gpxItemInformation.Controls.Add(Me.cboCreditGLAccount)
        Me.gpxItemInformation.Controls.Add(Me.cboDebitGLAccount)
        Me.gpxItemInformation.Controls.Add(Me.cboItemClass)
        Me.gpxItemInformation.Controls.Add(Me.cboShortDescription)
        Me.gpxItemInformation.Controls.Add(Me.cboPartNumber)
        Me.gpxItemInformation.Controls.Add(Me.cboPreferredVendor)
        Me.gpxItemInformation.Controls.Add(Me.cboPurchaseProductLineID)
        Me.gpxItemInformation.Controls.Add(Me.cboDivisionID)
        Me.gpxItemInformation.Controls.Add(Me.Label6)
        Me.gpxItemInformation.Controls.Add(Me.cboSalesProductLineID)
        Me.gpxItemInformation.Controls.Add(Me.Label5)
        Me.gpxItemInformation.Controls.Add(Me.Label7)
        Me.gpxItemInformation.Controls.Add(Me.Label8)
        Me.gpxItemInformation.Controls.Add(Me.txtLongDescription)
        Me.gpxItemInformation.Controls.Add(Me.txtStandardOrderQuantity)
        Me.gpxItemInformation.Controls.Add(Me.txtStandardCost)
        Me.gpxItemInformation.Controls.Add(Me.Label2)
        Me.gpxItemInformation.Controls.Add(Me.Label9)
        Me.gpxItemInformation.Controls.Add(Me.Label10)
        Me.gpxItemInformation.Controls.Add(Me.Label11)
        Me.gpxItemInformation.Controls.Add(Me.Label1)
        Me.gpxItemInformation.Controls.Add(Me.Label4)
        Me.gpxItemInformation.Location = New System.Drawing.Point(29, 41)
        Me.gpxItemInformation.Name = "gpxItemInformation"
        Me.gpxItemInformation.Size = New System.Drawing.Size(300, 770)
        Me.gpxItemInformation.TabIndex = 0
        Me.gpxItemInformation.TabStop = False
        Me.gpxItemInformation.Text = "Non-Inventory Item Information"
        '
        'chkCreateAll
        '
        Me.chkCreateAll.AutoSize = True
        Me.chkCreateAll.Location = New System.Drawing.Point(20, 679)
        Me.chkCreateAll.Name = "chkCreateAll"
        Me.chkCreateAll.Size = New System.Drawing.Size(127, 17)
        Me.chkCreateAll.TabIndex = 30
        Me.chkCreateAll.Text = "Create in All Divisions"
        Me.chkCreateAll.UseVisualStyleBackColor = True
        '
        'cmdAddNew
        '
        Me.cmdAddNew.Location = New System.Drawing.Point(64, 715)
        Me.cmdAddNew.Name = "cmdAddNew"
        Me.cmdAddNew.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddNew.TabIndex = 28
        Me.cmdAddNew.Text = "Save/Add"
        Me.cmdAddNew.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(212, 715)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 17
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdClearLines
        '
        Me.cmdClearLines.Location = New System.Drawing.Point(138, 715)
        Me.cmdClearLines.Name = "cmdClearLines"
        Me.cmdClearLines.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearLines.TabIndex = 29
        Me.cmdClearLines.Text = "Clear"
        Me.cmdClearLines.UseVisualStyleBackColor = True
        '
        'txtCreditDescription
        '
        Me.txtCreditDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreditDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCreditDescription.Location = New System.Drawing.Point(18, 610)
        Me.txtCreditDescription.Multiline = True
        Me.txtCreditDescription.Name = "txtCreditDescription"
        Me.txtCreditDescription.Size = New System.Drawing.Size(265, 44)
        Me.txtCreditDescription.TabIndex = 13
        '
        'txtDebitDescription
        '
        Me.txtDebitDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDebitDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDebitDescription.Location = New System.Drawing.Point(18, 505)
        Me.txtDebitDescription.Multiline = True
        Me.txtDebitDescription.Name = "txtDebitDescription"
        Me.txtDebitDescription.Size = New System.Drawing.Size(265, 44)
        Me.txtDebitDescription.TabIndex = 11
        '
        'cboCreditGLAccount
        '
        Me.cboCreditGLAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCreditGLAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCreditGLAccount.DataSource = Me.GLAccountsBindingSource1
        Me.cboCreditGLAccount.DisplayMember = "GLAccountNumber"
        Me.cboCreditGLAccount.FormattingEnabled = True
        Me.cboCreditGLAccount.Location = New System.Drawing.Point(111, 573)
        Me.cboCreditGLAccount.Name = "cboCreditGLAccount"
        Me.cboCreditGLAccount.Size = New System.Drawing.Size(172, 21)
        Me.cboCreditGLAccount.TabIndex = 12
        '
        'GLAccountsBindingSource1
        '
        Me.GLAccountsBindingSource1.DataMember = "GLAccounts"
        Me.GLAccountsBindingSource1.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboDebitGLAccount
        '
        Me.cboDebitGLAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDebitGLAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDebitGLAccount.DataSource = Me.GLAccountsBindingSource
        Me.cboDebitGLAccount.DisplayMember = "GLAccountNumber"
        Me.cboDebitGLAccount.FormattingEnabled = True
        Me.cboDebitGLAccount.Location = New System.Drawing.Point(111, 469)
        Me.cboDebitGLAccount.Name = "cboDebitGLAccount"
        Me.cboDebitGLAccount.Size = New System.Drawing.Size(172, 21)
        Me.cboDebitGLAccount.TabIndex = 10
        '
        'GLAccountsBindingSource
        '
        Me.GLAccountsBindingSource.DataMember = "GLAccounts"
        Me.GLAccountsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(112, 189)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(172, 21)
        Me.cboItemClass.TabIndex = 4
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboShortDescription
        '
        Me.cboShortDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShortDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShortDescription.DataSource = Me.NonInventoryItemListBindingSource
        Me.cboShortDescription.DisplayMember = "ShortDescription"
        Me.cboShortDescription.FormattingEnabled = True
        Me.cboShortDescription.Location = New System.Drawing.Point(19, 89)
        Me.cboShortDescription.Name = "cboShortDescription"
        Me.cboShortDescription.Size = New System.Drawing.Size(265, 21)
        Me.cboShortDescription.TabIndex = 2
        '
        'NonInventoryItemListBindingSource
        '
        Me.NonInventoryItemListBindingSource.DataMember = "NonInventoryItemList"
        Me.NonInventoryItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.NonInventoryItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(70, 59)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(214, 21)
        Me.cboPartNumber.TabIndex = 1
        Me.cboPartNumber.ValueMember = "ItemClassID"
        '
        'cboPreferredVendor
        '
        Me.cboPreferredVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPreferredVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPreferredVendor.DataSource = Me.VendorBindingSource
        Me.cboPreferredVendor.DisplayMember = "VendorCode"
        Me.cboPreferredVendor.FormattingEnabled = True
        Me.cboPreferredVendor.Location = New System.Drawing.Point(112, 219)
        Me.cboPreferredVendor.Name = "cboPreferredVendor"
        Me.cboPreferredVendor.Size = New System.Drawing.Size(172, 21)
        Me.cboPreferredVendor.TabIndex = 5
        Me.cboPreferredVendor.ValueMember = "ItemClassID"
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPurchaseProductLineID
        '
        Me.cboPurchaseProductLineID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPurchaseProductLineID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPurchaseProductLineID.DataSource = Me.PurchaseProductLineBindingSource
        Me.cboPurchaseProductLineID.DisplayMember = "PurchaseProductLineID"
        Me.cboPurchaseProductLineID.FormattingEnabled = True
        Me.cboPurchaseProductLineID.Location = New System.Drawing.Point(19, 420)
        Me.cboPurchaseProductLineID.Name = "cboPurchaseProductLineID"
        Me.cboPurchaseProductLineID.Size = New System.Drawing.Size(263, 21)
        Me.cboPurchaseProductLineID.TabIndex = 9
        Me.cboPurchaseProductLineID.ValueMember = "ItemClassID"
        '
        'PurchaseProductLineBindingSource
        '
        Me.PurchaseProductLineBindingSource.DataMember = "PurchaseProductLine"
        Me.PurchaseProductLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(112, 29)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(172, 21)
        Me.cboDivisionID.TabIndex = 0
        Me.cboDivisionID.ValueMember = "ItemClassID"
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(19, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 20)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Division ID"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSalesProductLineID
        '
        Me.cboSalesProductLineID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesProductLineID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesProductLineID.DataSource = Me.SalesProductLineBindingSource
        Me.cboSalesProductLineID.DisplayMember = "SalesProdLineID"
        Me.cboSalesProductLineID.FormattingEnabled = True
        Me.cboSalesProductLineID.Location = New System.Drawing.Point(19, 373)
        Me.cboSalesProductLineID.Name = "cboSalesProductLineID"
        Me.cboSalesProductLineID.Size = New System.Drawing.Size(263, 21)
        Me.cboSalesProductLineID.TabIndex = 8
        Me.cboSalesProductLineID.ValueMember = "ItemClassID"
        '
        'SalesProductLineBindingSource
        '
        Me.SalesProductLineBindingSource.DataMember = "SalesProductLine"
        Me.SalesProductLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(19, 190)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Item Class"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 353)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 20)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Sales Product Class"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 404)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 20)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Purchase Product Class"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLongDescription
        '
        Me.txtLongDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLongDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLongDescription.Location = New System.Drawing.Point(19, 119)
        Me.txtLongDescription.Multiline = True
        Me.txtLongDescription.Name = "txtLongDescription"
        Me.txtLongDescription.Size = New System.Drawing.Size(265, 55)
        Me.txtLongDescription.TabIndex = 3
        '
        'txtStandardOrderQuantity
        '
        Me.txtStandardOrderQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStandardOrderQuantity.Location = New System.Drawing.Point(141, 303)
        Me.txtStandardOrderQuantity.Name = "txtStandardOrderQuantity"
        Me.txtStandardOrderQuantity.Size = New System.Drawing.Size(142, 20)
        Me.txtStandardOrderQuantity.TabIndex = 7
        '
        'txtStandardCost
        '
        Me.txtStandardCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStandardCost.Location = New System.Drawing.Point(141, 274)
        Me.txtStandardCost.Name = "txtStandardCost"
        Me.txtStandardCost.Size = New System.Drawing.Size(142, 20)
        Me.txtStandardCost.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Part #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(18, 274)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(118, 20)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Standard Cost"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(18, 303)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(118, 20)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "STD Order Quantity"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(19, 218)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(118, 20)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Pref. Vendor"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 469)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 20)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Debit GL Acct."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 574)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 20)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Credit GL Acct."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComment
        '
        Me.txtComment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.Location = New System.Drawing.Point(346, 740)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(355, 71)
        Me.txtComment.TabIndex = 14
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.Location = New System.Drawing.Point(343, 720)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(122, 17)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Comment"
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(884, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 18
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'dgvNonInventoryItemList
        '
        Me.dgvNonInventoryItemList.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvNonInventoryItemList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvNonInventoryItemList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvNonInventoryItemList.AutoGenerateColumns = False
        Me.dgvNonInventoryItemList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvNonInventoryItemList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvNonInventoryItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNonInventoryItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemIDColumn, Me.ShortDescriptionColumn, Me.ItemClassColumn, Me.GLDebitAccountColumn, Me.GLCreditAccountColumn, Me.PurchaseProductLineColumn, Me.SalesProductLineColumn, Me.CommentColumn, Me.DivisionIDColumn, Me.StandardCostColumn, Me.PreferredVendorColumn, Me.LongDescriptionColumn, Me.CreationDateColumn, Me.StandardOrderQuantityColumn})
        Me.dgvNonInventoryItemList.DataSource = Me.NonInventoryItemListBindingSource
        Me.dgvNonInventoryItemList.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvNonInventoryItemList.Location = New System.Drawing.Point(346, 41)
        Me.dgvNonInventoryItemList.Name = "dgvNonInventoryItemList"
        Me.dgvNonInventoryItemList.Size = New System.Drawing.Size(684, 661)
        Me.dgvNonInventoryItemList.TabIndex = 17
        Me.dgvNonInventoryItemList.TabStop = False
        '
        'ItemIDColumn
        '
        Me.ItemIDColumn.DataPropertyName = "ItemID"
        Me.ItemIDColumn.HeaderText = "Part #"
        Me.ItemIDColumn.Name = "ItemIDColumn"
        Me.ItemIDColumn.ReadOnly = True
        '
        'ShortDescriptionColumn
        '
        Me.ShortDescriptionColumn.DataPropertyName = "ShortDescription"
        Me.ShortDescriptionColumn.HeaderText = "Description"
        Me.ShortDescriptionColumn.Name = "ShortDescriptionColumn"
        '
        'ItemClassColumn
        '
        Me.ItemClassColumn.DataPropertyName = "ItemClass"
        Me.ItemClassColumn.HeaderText = "Item Class"
        Me.ItemClassColumn.Name = "ItemClassColumn"
        '
        'GLDebitAccountColumn
        '
        Me.GLDebitAccountColumn.DataPropertyName = "GLDebitAccount"
        Me.GLDebitAccountColumn.HeaderText = "Debit Account"
        Me.GLDebitAccountColumn.Name = "GLDebitAccountColumn"
        '
        'GLCreditAccountColumn
        '
        Me.GLCreditAccountColumn.DataPropertyName = "GLCreditAccount"
        Me.GLCreditAccountColumn.HeaderText = "Credit Account"
        Me.GLCreditAccountColumn.Name = "GLCreditAccountColumn"
        '
        'PurchaseProductLineColumn
        '
        Me.PurchaseProductLineColumn.DataPropertyName = "PurchaseProductLine"
        Me.PurchaseProductLineColumn.HeaderText = "PPL"
        Me.PurchaseProductLineColumn.Name = "PurchaseProductLineColumn"
        '
        'SalesProductLineColumn
        '
        Me.SalesProductLineColumn.DataPropertyName = "SalesProductLine"
        Me.SalesProductLineColumn.HeaderText = "SPL"
        Me.SalesProductLineColumn.Name = "SalesProductLineColumn"
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        '
        'StandardCostColumn
        '
        Me.StandardCostColumn.DataPropertyName = "StandardCost"
        Me.StandardCostColumn.HeaderText = "Standard Cost"
        Me.StandardCostColumn.Name = "StandardCostColumn"
        '
        'PreferredVendorColumn
        '
        Me.PreferredVendorColumn.DataPropertyName = "PreferredVendor"
        Me.PreferredVendorColumn.HeaderText = "Preferred Vendor"
        Me.PreferredVendorColumn.Name = "PreferredVendorColumn"
        '
        'LongDescriptionColumn
        '
        Me.LongDescriptionColumn.DataPropertyName = "LongDescription"
        Me.LongDescriptionColumn.HeaderText = "LongDescription"
        Me.LongDescriptionColumn.Name = "LongDescriptionColumn"
        Me.LongDescriptionColumn.Visible = False
        '
        'CreationDateColumn
        '
        Me.CreationDateColumn.DataPropertyName = "CreationDate"
        Me.CreationDateColumn.HeaderText = "CreationDate"
        Me.CreationDateColumn.Name = "CreationDateColumn"
        Me.CreationDateColumn.Visible = False
        '
        'StandardOrderQuantityColumn
        '
        Me.StandardOrderQuantityColumn.DataPropertyName = "StandardOrderQuantity"
        Me.StandardOrderQuantityColumn.HeaderText = "StandardOrderQuantity"
        Me.StandardOrderQuantityColumn.Name = "StandardOrderQuantityColumn"
        Me.StandardOrderQuantityColumn.Visible = False
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'SalesProductLineTableAdapter
        '
        Me.SalesProductLineTableAdapter.ClearBeforeFill = True
        '
        'PurchaseProductLineTableAdapter
        '
        Me.PurchaseProductLineTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'GLAccountsTableAdapter
        '
        Me.GLAccountsTableAdapter.ClearBeforeFill = True
        '
        'NonInventoryItemListTableAdapter
        '
        Me.NonInventoryItemListTableAdapter.ClearBeforeFill = True
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'NonInventoryItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.dgvNonInventoryItemList)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.gpxItemInformation)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.Label12)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "NonInventoryItems"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Non-Inventory Items"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxItemInformation.ResumeLayout(False)
        Me.gpxItemInformation.PerformLayout()
        CType(Me.GLAccountsBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NonInventoryItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseProductLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesProductLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNonInventoryItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxItemInformation As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLongDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents txtStandardCost As System.Windows.Forms.TextBox
    Friend WithEvents txtStandardOrderQuantity As System.Windows.Forms.TextBox
    Friend WithEvents cboPurchaseProductLineID As System.Windows.Forms.ComboBox
    Friend WithEvents cboSalesProductLineID As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cboPreferredVendor As System.Windows.Forms.ComboBox
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents dgvNonInventoryItemList As System.Windows.Forms.DataGridView
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents SalesProductLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesProductLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesProductLineTableAdapter
    Friend WithEvents PurchaseProductLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseProductLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseProductLineTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents cboShortDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboDebitGLAccount As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCreditGLAccount As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GLAccountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
    Friend WithEvents GLAccountsBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents txtCreditDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtDebitDescription As System.Windows.Forms.TextBox
    Friend WithEvents NonInventoryItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents NonInventoryItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.NonInventoryItemListTableAdapter
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdAddNew As System.Windows.Forms.Button
    Friend WithEvents cmdClearLines As System.Windows.Forms.Button
    Friend WithEvents chkCreateAll As System.Windows.Forms.CheckBox
    Friend WithEvents ItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShortDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDebitAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCreditAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseProductLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesProductLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PreferredVendorColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LongDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreationDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardOrderQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
