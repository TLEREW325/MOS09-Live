<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemClassMaintenance
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintItemClassToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cboItemClassID = New System.Windows.Forms.ComboBox
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.gpxItemClass = New System.Windows.Forms.GroupBox
        Me.chkInventory = New System.Windows.Forms.CheckBox
        Me.cboItemClassName = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtGLIssues = New System.Windows.Forms.TextBox
        Me.txtGLAdjustments = New System.Windows.Forms.TextBox
        Me.txtGLSalesOffset = New System.Windows.Forms.TextBox
        Me.txtGLPurchases = New System.Windows.Forms.TextBox
        Me.txtGLCOGS = New System.Windows.Forms.TextBox
        Me.txtGLInventory = New System.Windows.Forms.TextBox
        Me.txtGLReturns = New System.Windows.Forms.TextBox
        Me.txtGLSales = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdClearItemClass = New System.Windows.Forms.Button
        Me.cmdAddNewItemClass = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.gpxSalesProductLine = New System.Windows.Forms.GroupBox
        Me.cmdClearSPL = New System.Windows.Forms.Button
        Me.cmdAddNewSPL = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSalesClassName = New System.Windows.Forms.TextBox
        Me.SalesProductLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboSalesClassID = New System.Windows.Forms.ComboBox
        Me.gpxPurchaseProductLine = New System.Windows.Forms.GroupBox
        Me.cmdClearPPL = New System.Windows.Forms.Button
        Me.cmdAddNewPPL = New System.Windows.Forms.Button
        Me.txtPurchaseClassName = New System.Windows.Forms.TextBox
        Me.PurchaseProductLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPurchaseClassID = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.dgvItemClassList = New System.Windows.Forms.DataGridView
        Me.Label16 = New System.Windows.Forms.Label
        Me.PurchaseProductLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseProductLineTableAdapter
        Me.SalesProductLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesProductLineTableAdapter
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.ItemClassIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLSalesAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLReturnsAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLInventoryAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLCOGSAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLPurchasesAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLSalesOffsetAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAdjustmentAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLIssuesAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryItemColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxItemClass.SuspendLayout()
        Me.gpxSalesProductLine.SuspendLayout()
        CType(Me.SalesProductLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxPurchaseProductLine.SuspendLayout()
        CType(Me.PurchaseProductLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvItemClassList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(961, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 23
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintItemClassToolStripMenuItem, Me.ClearFormToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'PrintItemClassToolStripMenuItem
        '
        Me.PrintItemClassToolStripMenuItem.Name = "PrintItemClassToolStripMenuItem"
        Me.PrintItemClassToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.PrintItemClassToolStripMenuItem.Text = "Print Item Class"
        '
        'ClearFormToolStripMenuItem
        '
        Me.ClearFormToolStripMenuItem.Name = "ClearFormToolStripMenuItem"
        Me.ClearFormToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
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
        'cboItemClassID
        '
        Me.cboItemClassID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClassID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClassID.DataSource = Me.ItemClassBindingSource
        Me.cboItemClassID.DisplayMember = "ItemClassID"
        Me.cboItemClassID.FormattingEnabled = True
        Me.cboItemClassID.Location = New System.Drawing.Point(86, 31)
        Me.cboItemClassID.Name = "cboItemClassID"
        Me.cboItemClassID.Size = New System.Drawing.Size(216, 21)
        Me.cboItemClassID.TabIndex = 0
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Item Class ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxItemClass
        '
        Me.gpxItemClass.Controls.Add(Me.cboItemClassName)
        Me.gpxItemClass.Controls.Add(Me.cboItemClassID)
        Me.gpxItemClass.Controls.Add(Me.chkInventory)
        Me.gpxItemClass.Controls.Add(Me.Label15)
        Me.gpxItemClass.Controls.Add(Me.txtGLIssues)
        Me.gpxItemClass.Controls.Add(Me.txtGLAdjustments)
        Me.gpxItemClass.Controls.Add(Me.txtGLSalesOffset)
        Me.gpxItemClass.Controls.Add(Me.txtGLPurchases)
        Me.gpxItemClass.Controls.Add(Me.txtGLCOGS)
        Me.gpxItemClass.Controls.Add(Me.txtGLInventory)
        Me.gpxItemClass.Controls.Add(Me.txtGLReturns)
        Me.gpxItemClass.Controls.Add(Me.txtGLSales)
        Me.gpxItemClass.Controls.Add(Me.Label13)
        Me.gpxItemClass.Controls.Add(Me.Label14)
        Me.gpxItemClass.Controls.Add(Me.Label11)
        Me.gpxItemClass.Controls.Add(Me.Label12)
        Me.gpxItemClass.Controls.Add(Me.Label9)
        Me.gpxItemClass.Controls.Add(Me.Label10)
        Me.gpxItemClass.Controls.Add(Me.Label7)
        Me.gpxItemClass.Controls.Add(Me.Label8)
        Me.gpxItemClass.Controls.Add(Me.cmdClearItemClass)
        Me.gpxItemClass.Controls.Add(Me.cmdAddNewItemClass)
        Me.gpxItemClass.Controls.Add(Me.Label2)
        Me.gpxItemClass.Controls.Add(Me.Label1)
        Me.gpxItemClass.Location = New System.Drawing.Point(29, 41)
        Me.gpxItemClass.Name = "gpxItemClass"
        Me.gpxItemClass.Size = New System.Drawing.Size(318, 461)
        Me.gpxItemClass.TabIndex = 0
        Me.gpxItemClass.TabStop = False
        Me.gpxItemClass.Text = "Item Class Information"
        '
        'chkInventory
        '
        Me.chkInventory.AutoSize = True
        Me.chkInventory.Location = New System.Drawing.Point(121, 367)
        Me.chkInventory.Name = "chkInventory"
        Me.chkInventory.Size = New System.Drawing.Size(104, 17)
        Me.chkInventory.TabIndex = 10
        Me.chkInventory.Text = "Inventory Class?"
        Me.chkInventory.UseVisualStyleBackColor = True
        '
        'cboItemClassName
        '
        Me.cboItemClassName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClassName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClassName.DataSource = Me.ItemClassBindingSource
        Me.cboItemClassName.DisplayMember = "ItemClassName"
        Me.cboItemClassName.FormattingEnabled = True
        Me.cboItemClassName.Location = New System.Drawing.Point(86, 58)
        Me.cboItemClassName.Name = "cboItemClassName"
        Me.cboItemClassName.Size = New System.Drawing.Size(217, 21)
        Me.cboItemClassName.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(11, 99)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(290, 20)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "General Ledger Accounts"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtGLIssues
        '
        Me.txtGLIssues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLIssues.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGLIssues.Location = New System.Drawing.Point(120, 324)
        Me.txtGLIssues.Name = "txtGLIssues"
        Me.txtGLIssues.Size = New System.Drawing.Size(181, 20)
        Me.txtGLIssues.TabIndex = 9
        '
        'txtGLAdjustments
        '
        Me.txtGLAdjustments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLAdjustments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGLAdjustments.Location = New System.Drawing.Point(120, 296)
        Me.txtGLAdjustments.Name = "txtGLAdjustments"
        Me.txtGLAdjustments.Size = New System.Drawing.Size(181, 20)
        Me.txtGLAdjustments.TabIndex = 8
        '
        'txtGLSalesOffset
        '
        Me.txtGLSalesOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLSalesOffset.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGLSalesOffset.Location = New System.Drawing.Point(120, 268)
        Me.txtGLSalesOffset.Name = "txtGLSalesOffset"
        Me.txtGLSalesOffset.Size = New System.Drawing.Size(181, 20)
        Me.txtGLSalesOffset.TabIndex = 7
        '
        'txtGLPurchases
        '
        Me.txtGLPurchases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLPurchases.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGLPurchases.Location = New System.Drawing.Point(120, 241)
        Me.txtGLPurchases.Name = "txtGLPurchases"
        Me.txtGLPurchases.Size = New System.Drawing.Size(181, 20)
        Me.txtGLPurchases.TabIndex = 6
        '
        'txtGLCOGS
        '
        Me.txtGLCOGS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLCOGS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGLCOGS.Location = New System.Drawing.Point(120, 215)
        Me.txtGLCOGS.Name = "txtGLCOGS"
        Me.txtGLCOGS.Size = New System.Drawing.Size(181, 20)
        Me.txtGLCOGS.TabIndex = 5
        '
        'txtGLInventory
        '
        Me.txtGLInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLInventory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGLInventory.Location = New System.Drawing.Point(120, 187)
        Me.txtGLInventory.Name = "txtGLInventory"
        Me.txtGLInventory.Size = New System.Drawing.Size(181, 20)
        Me.txtGLInventory.TabIndex = 4
        '
        'txtGLReturns
        '
        Me.txtGLReturns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLReturns.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGLReturns.Location = New System.Drawing.Point(120, 159)
        Me.txtGLReturns.Name = "txtGLReturns"
        Me.txtGLReturns.Size = New System.Drawing.Size(181, 20)
        Me.txtGLReturns.TabIndex = 3
        '
        'txtGLSales
        '
        Me.txtGLSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLSales.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGLSales.Location = New System.Drawing.Point(120, 132)
        Me.txtGLSales.Name = "txtGLSales"
        Me.txtGLSales.Size = New System.Drawing.Size(181, 20)
        Me.txtGLSales.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(10, 327)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 20)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Issues"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(10, 299)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 20)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Adjustments"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(10, 271)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 20)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Sales Offset"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(10, 243)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 20)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Purchases"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(10, 215)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 20)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "COGS"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(10, 187)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 20)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Inventory"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(10, 159)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 20)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Returns"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label8.Location = New System.Drawing.Point(10, 131)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 20)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Sales"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearItemClass
        '
        Me.cmdClearItemClass.Location = New System.Drawing.Point(230, 404)
        Me.cmdClearItemClass.Name = "cmdClearItemClass"
        Me.cmdClearItemClass.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearItemClass.TabIndex = 12
        Me.cmdClearItemClass.Text = "Clear"
        Me.cmdClearItemClass.UseVisualStyleBackColor = True
        '
        'cmdAddNewItemClass
        '
        Me.cmdAddNewItemClass.Location = New System.Drawing.Point(153, 404)
        Me.cmdAddNewItemClass.Name = "cmdAddNewItemClass"
        Me.cmdAddNewItemClass.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddNewItemClass.TabIndex = 11
        Me.cmdAddNewItemClass.Text = "Save"
        Me.cmdAddNewItemClass.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(9, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Class Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(884, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 22
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'gpxSalesProductLine
        '
        Me.gpxSalesProductLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxSalesProductLine.Controls.Add(Me.cmdClearSPL)
        Me.gpxSalesProductLine.Controls.Add(Me.cmdAddNewSPL)
        Me.gpxSalesProductLine.Controls.Add(Me.Label3)
        Me.gpxSalesProductLine.Controls.Add(Me.txtSalesClassName)
        Me.gpxSalesProductLine.Controls.Add(Me.Label4)
        Me.gpxSalesProductLine.Controls.Add(Me.cboSalesClassID)
        Me.gpxSalesProductLine.Location = New System.Drawing.Point(365, 658)
        Me.gpxSalesProductLine.Name = "gpxSalesProductLine"
        Me.gpxSalesProductLine.Size = New System.Drawing.Size(318, 153)
        Me.gpxSalesProductLine.TabIndex = 17
        Me.gpxSalesProductLine.TabStop = False
        Me.gpxSalesProductLine.Text = "Sales Product Class Information"
        '
        'cmdClearSPL
        '
        Me.cmdClearSPL.Location = New System.Drawing.Point(229, 100)
        Me.cmdClearSPL.Name = "cmdClearSPL"
        Me.cmdClearSPL.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearSPL.TabIndex = 20
        Me.cmdClearSPL.Text = "Clear"
        Me.cmdClearSPL.UseVisualStyleBackColor = True
        '
        'cmdAddNewSPL
        '
        Me.cmdAddNewSPL.Location = New System.Drawing.Point(152, 100)
        Me.cmdAddNewSPL.Name = "cmdAddNewSPL"
        Me.cmdAddNewSPL.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddNewSPL.TabIndex = 19
        Me.cmdAddNewSPL.Text = "Add New"
        Me.cmdAddNewSPL.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(9, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Sales Class Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesClassName
        '
        Me.txtSalesClassName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesClassName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesClassName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SalesProductLineBindingSource, "SalesProdLineDescription", True))
        Me.txtSalesClassName.Location = New System.Drawing.Point(120, 64)
        Me.txtSalesClassName.Name = "txtSalesClassName"
        Me.txtSalesClassName.Size = New System.Drawing.Size(181, 20)
        Me.txtSalesClassName.TabIndex = 18
        '
        'SalesProductLineBindingSource
        '
        Me.SalesProductLineBindingSource.DataMember = "SalesProductLine"
        Me.SalesProductLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(9, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Sales Class ID"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSalesClassID
        '
        Me.cboSalesClassID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesClassID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesClassID.DataSource = Me.SalesProductLineBindingSource
        Me.cboSalesClassID.DisplayMember = "SalesProdLineID"
        Me.cboSalesClassID.FormattingEnabled = True
        Me.cboSalesClassID.Location = New System.Drawing.Point(120, 34)
        Me.cboSalesClassID.Name = "cboSalesClassID"
        Me.cboSalesClassID.Size = New System.Drawing.Size(182, 21)
        Me.cboSalesClassID.TabIndex = 17
        '
        'gpxPurchaseProductLine
        '
        Me.gpxPurchaseProductLine.Controls.Add(Me.cmdClearPPL)
        Me.gpxPurchaseProductLine.Controls.Add(Me.cmdAddNewPPL)
        Me.gpxPurchaseProductLine.Controls.Add(Me.txtPurchaseClassName)
        Me.gpxPurchaseProductLine.Controls.Add(Me.cboPurchaseClassID)
        Me.gpxPurchaseProductLine.Controls.Add(Me.Label5)
        Me.gpxPurchaseProductLine.Controls.Add(Me.Label6)
        Me.gpxPurchaseProductLine.Location = New System.Drawing.Point(29, 658)
        Me.gpxPurchaseProductLine.Name = "gpxPurchaseProductLine"
        Me.gpxPurchaseProductLine.Size = New System.Drawing.Size(318, 152)
        Me.gpxPurchaseProductLine.TabIndex = 13
        Me.gpxPurchaseProductLine.TabStop = False
        Me.gpxPurchaseProductLine.Text = "Purchase Product Class Information"
        '
        'cmdClearPPL
        '
        Me.cmdClearPPL.Location = New System.Drawing.Point(231, 99)
        Me.cmdClearPPL.Name = "cmdClearPPL"
        Me.cmdClearPPL.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearPPL.TabIndex = 16
        Me.cmdClearPPL.Text = "Clear"
        Me.cmdClearPPL.UseVisualStyleBackColor = True
        '
        'cmdAddNewPPL
        '
        Me.cmdAddNewPPL.Location = New System.Drawing.Point(154, 99)
        Me.cmdAddNewPPL.Name = "cmdAddNewPPL"
        Me.cmdAddNewPPL.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddNewPPL.TabIndex = 15
        Me.cmdAddNewPPL.Text = "Add New"
        Me.cmdAddNewPPL.UseVisualStyleBackColor = True
        '
        'txtPurchaseClassName
        '
        Me.txtPurchaseClassName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPurchaseClassName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPurchaseClassName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PurchaseProductLineBindingSource, "PurchaseProductLineDescription", True))
        Me.txtPurchaseClassName.Location = New System.Drawing.Point(121, 63)
        Me.txtPurchaseClassName.Name = "txtPurchaseClassName"
        Me.txtPurchaseClassName.Size = New System.Drawing.Size(181, 20)
        Me.txtPurchaseClassName.TabIndex = 14
        '
        'PurchaseProductLineBindingSource
        '
        Me.PurchaseProductLineBindingSource.DataMember = "PurchaseProductLine"
        Me.PurchaseProductLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPurchaseClassID
        '
        Me.cboPurchaseClassID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPurchaseClassID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPurchaseClassID.DataSource = Me.PurchaseProductLineBindingSource
        Me.cboPurchaseClassID.DisplayMember = "PurchaseProductLineID"
        Me.cboPurchaseClassID.FormattingEnabled = True
        Me.cboPurchaseClassID.Location = New System.Drawing.Point(121, 32)
        Me.cboPurchaseClassID.Name = "cboPurchaseClassID"
        Me.cboPurchaseClassID.Size = New System.Drawing.Size(183, 21)
        Me.cboPurchaseClassID.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(9, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Purchase Class Name"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(9, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Purchase Class ID"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvItemClassList
        '
        Me.dgvItemClassList.AllowUserToAddRows = False
        Me.dgvItemClassList.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvItemClassList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvItemClassList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvItemClassList.AutoGenerateColumns = False
        Me.dgvItemClassList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvItemClassList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvItemClassList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItemClassList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemClassIDColumn, Me.ItemClassNameColumn, Me.GLSalesAccountColumn, Me.GLReturnsAccountColumn, Me.GLInventoryAccountColumn, Me.GLCOGSAccountColumn, Me.GLPurchasesAccountColumn, Me.GLSalesOffsetAccountColumn, Me.GLAdjustmentAccountColumn, Me.GLIssuesAccountColumn, Me.InventoryItemColumn})
        Me.dgvItemClassList.DataSource = Me.ItemClassBindingSource
        Me.dgvItemClassList.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvItemClassList.Location = New System.Drawing.Point(365, 41)
        Me.dgvItemClassList.Name = "dgvItemClassList"
        Me.dgvItemClassList.ReadOnly = True
        Me.dgvItemClassList.Size = New System.Drawing.Size(667, 600)
        Me.dgvItemClassList.TabIndex = 11
        Me.dgvItemClassList.TabStop = False
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label16.Location = New System.Drawing.Point(26, 556)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(291, 85)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Product Class ID and Sales Product ID are independent of Item Class and are used " & _
            "to sort or group items only."
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PurchaseProductLineTableAdapter
        '
        Me.PurchaseProductLineTableAdapter.ClearBeforeFill = True
        '
        'SalesProductLineTableAdapter
        '
        Me.SalesProductLineTableAdapter.ClearBeforeFill = True
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'ItemClassIDColumn
        '
        Me.ItemClassIDColumn.DataPropertyName = "ItemClassID"
        Me.ItemClassIDColumn.HeaderText = "Class ID"
        Me.ItemClassIDColumn.Name = "ItemClassIDColumn"
        Me.ItemClassIDColumn.ReadOnly = True
        '
        'ItemClassNameColumn
        '
        Me.ItemClassNameColumn.DataPropertyName = "ItemClassName"
        Me.ItemClassNameColumn.HeaderText = "Class Name"
        Me.ItemClassNameColumn.Name = "ItemClassNameColumn"
        Me.ItemClassNameColumn.ReadOnly = True
        '
        'GLSalesAccountColumn
        '
        Me.GLSalesAccountColumn.DataPropertyName = "GLSalesAccount"
        Me.GLSalesAccountColumn.HeaderText = "Sales Account"
        Me.GLSalesAccountColumn.Name = "GLSalesAccountColumn"
        Me.GLSalesAccountColumn.ReadOnly = True
        '
        'GLReturnsAccountColumn
        '
        Me.GLReturnsAccountColumn.DataPropertyName = "GLReturnsAccount"
        Me.GLReturnsAccountColumn.HeaderText = "Returns Account"
        Me.GLReturnsAccountColumn.Name = "GLReturnsAccountColumn"
        Me.GLReturnsAccountColumn.ReadOnly = True
        '
        'GLInventoryAccountColumn
        '
        Me.GLInventoryAccountColumn.DataPropertyName = "GLInventoryAccount"
        Me.GLInventoryAccountColumn.HeaderText = "Inventory Account"
        Me.GLInventoryAccountColumn.Name = "GLInventoryAccountColumn"
        Me.GLInventoryAccountColumn.ReadOnly = True
        '
        'GLCOGSAccountColumn
        '
        Me.GLCOGSAccountColumn.DataPropertyName = "GLCOGSAccount"
        Me.GLCOGSAccountColumn.HeaderText = "COGS Account"
        Me.GLCOGSAccountColumn.Name = "GLCOGSAccountColumn"
        Me.GLCOGSAccountColumn.ReadOnly = True
        '
        'GLPurchasesAccountColumn
        '
        Me.GLPurchasesAccountColumn.DataPropertyName = "GLPurchasesAccount"
        Me.GLPurchasesAccountColumn.HeaderText = "Purchases Account"
        Me.GLPurchasesAccountColumn.Name = "GLPurchasesAccountColumn"
        Me.GLPurchasesAccountColumn.ReadOnly = True
        '
        'GLSalesOffsetAccountColumn
        '
        Me.GLSalesOffsetAccountColumn.DataPropertyName = "GLSalesOffsetAccount"
        Me.GLSalesOffsetAccountColumn.HeaderText = "Sales Offset Account"
        Me.GLSalesOffsetAccountColumn.Name = "GLSalesOffsetAccountColumn"
        Me.GLSalesOffsetAccountColumn.ReadOnly = True
        '
        'GLAdjustmentAccountColumn
        '
        Me.GLAdjustmentAccountColumn.DataPropertyName = "GLAdjustmentAccount"
        Me.GLAdjustmentAccountColumn.HeaderText = "Adjustment Account"
        Me.GLAdjustmentAccountColumn.Name = "GLAdjustmentAccountColumn"
        Me.GLAdjustmentAccountColumn.ReadOnly = True
        '
        'GLIssuesAccountColumn
        '
        Me.GLIssuesAccountColumn.DataPropertyName = "GLIssuesAccount"
        Me.GLIssuesAccountColumn.HeaderText = "Issues Account"
        Me.GLIssuesAccountColumn.Name = "GLIssuesAccountColumn"
        Me.GLIssuesAccountColumn.ReadOnly = True
        '
        'InventoryItemColumn
        '
        Me.InventoryItemColumn.DataPropertyName = "InventoryItem"
        Me.InventoryItemColumn.HeaderText = "Inventory Item?"
        Me.InventoryItemColumn.Name = "InventoryItemColumn"
        Me.InventoryItemColumn.ReadOnly = True
        '
        'ItemClassMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.dgvItemClassList)
        Me.Controls.Add(Me.gpxPurchaseProductLine)
        Me.Controls.Add(Me.gpxSalesProductLine)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.gpxItemClass)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ItemClassMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Item Grouping Maintenance"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxItemClass.ResumeLayout(False)
        Me.gpxItemClass.PerformLayout()
        Me.gpxSalesProductLine.ResumeLayout(False)
        Me.gpxSalesProductLine.PerformLayout()
        CType(Me.SalesProductLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxPurchaseProductLine.ResumeLayout(False)
        Me.gpxPurchaseProductLine.PerformLayout()
        CType(Me.PurchaseProductLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvItemClassList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboItemClassID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gpxItemClass As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClearItemClass As System.Windows.Forms.Button
    Friend WithEvents cmdAddNewItemClass As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents gpxSalesProductLine As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClearSPL As System.Windows.Forms.Button
    Friend WithEvents cmdAddNewSPL As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSalesClassName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboSalesClassID As System.Windows.Forms.ComboBox
    Friend WithEvents gpxPurchaseProductLine As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClearPPL As System.Windows.Forms.Button
    Friend WithEvents cmdAddNewPPL As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPurchaseClassName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboPurchaseClassID As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtGLCOGS As System.Windows.Forms.TextBox
    Friend WithEvents txtGLInventory As System.Windows.Forms.TextBox
    Friend WithEvents txtGLReturns As System.Windows.Forms.TextBox
    Friend WithEvents txtGLSales As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtGLIssues As System.Windows.Forms.TextBox
    Friend WithEvents txtGLAdjustments As System.Windows.Forms.TextBox
    Friend WithEvents txtGLSalesOffset As System.Windows.Forms.TextBox
    Friend WithEvents txtGLPurchases As System.Windows.Forms.TextBox
    Friend WithEvents dgvItemClassList As System.Windows.Forms.DataGridView
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboItemClassName As System.Windows.Forms.ComboBox
    Friend WithEvents PurchaseProductLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseProductLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseProductLineTableAdapter
    Friend WithEvents SalesProductLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesProductLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesProductLineTableAdapter
    Friend WithEvents PrintItemClassToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkInventory As System.Windows.Forms.CheckBox
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents ItemClassIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLSalesAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLReturnsAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLInventoryAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCOGSAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLPurchasesAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLSalesOffsetAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAdjustmentAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLIssuesAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InventoryItemColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
