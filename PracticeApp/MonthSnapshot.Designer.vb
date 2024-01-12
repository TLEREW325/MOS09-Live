<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonthSnapshot
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdLoad = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboYear = New System.Windows.Forms.ComboBox
        Me.cboMonth = New System.Windows.Forms.ComboBox
        Me.MonthTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.MonthTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.MonthTableTableAdapter
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label55 = New System.Windows.Forms.Label
        Me.Label54 = New System.Windows.Forms.Label
        Me.txtLYTotalQuoteAmount = New System.Windows.Forms.TextBox
        Me.txtLYTotalInvoices = New System.Windows.Forms.TextBox
        Me.txtLYTotalCustomerReturns = New System.Windows.Forms.TextBox
        Me.txtLYTotalShipments = New System.Windows.Forms.TextBox
        Me.txtLYTotalOrders = New System.Windows.Forms.TextBox
        Me.Label49 = New System.Windows.Forms.Label
        Me.txtTotalQuoteAmount = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtTotalInvoices = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTotalCustomerReturns = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTotalShipments = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtTotalOrders = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label48 = New System.Windows.Forms.Label
        Me.txtRentalBilled = New System.Windows.Forms.TextBox
        Me.Label47 = New System.Windows.Forms.Label
        Me.txtLaborBilled = New System.Windows.Forms.TextBox
        Me.Label46 = New System.Windows.Forms.Label
        Me.txtFreightBilled = New System.Windows.Forms.TextBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.txtChangeInInventory = New System.Windows.Forms.TextBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.txtTotalAdjustmentNumber = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.txtTotalAdjustmentDollars = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtTotalVendorReturns = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTotalReceived = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTotalPOs = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtAging46 = New System.Windows.Forms.TextBox
        Me.txtAging90 = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtAging31 = New System.Windows.Forms.TextBox
        Me.txtAging61 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtAging30 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtTotalOpenInvoices = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtTotalCashReceipts = New System.Windows.Forms.TextBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtAPAging46 = New System.Windows.Forms.TextBox
        Me.txtAPAging90 = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtAPAging31 = New System.Windows.Forms.TextBox
        Me.txtAPAging61 = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtAPAging30 = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtTotalOpenPayables = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtTotalPayments = New System.Windows.Forms.TextBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.txtSteelUsagenet = New System.Windows.Forms.TextBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.txtSteelYardQuantity = New System.Windows.Forms.TextBox
        Me.txtSteelUsageQuantity = New System.Windows.Forms.TextBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.txtNumberOfSteelReturns = New System.Windows.Forms.TextBox
        Me.Label53 = New System.Windows.Forms.Label
        Me.txtNumberOfSteelAdj = New System.Windows.Forms.TextBox
        Me.txtNumberOfSteelReceipts = New System.Windows.Forms.TextBox
        Me.txtNumberOfSteelPOs = New System.Windows.Forms.TextBox
        Me.Label50 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.txtNumberOfQuotes = New System.Windows.Forms.TextBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtNumberOfPayments = New System.Windows.Forms.TextBox
        Me.txtNumberOfCashReceipts = New System.Windows.Forms.TextBox
        Me.txtNumberOfVendorReturns = New System.Windows.Forms.TextBox
        Me.txtNumberOfReceivers = New System.Windows.Forms.TextBox
        Me.txtNumberOfPOs = New System.Windows.Forms.TextBox
        Me.txtNumberOfInvoices = New System.Windows.Forms.TextBox
        Me.txtNumberOfCustomerReturns = New System.Windows.Forms.TextBox
        Me.txtNumberOfShipments = New System.Windows.Forms.TextBox
        Me.txtNumberOfOrders = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.txtSteelReceivers = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.txtSteelPOs = New System.Windows.Forms.TextBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.txtSteelAdjustments = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.txtSteelReturns = New System.Windows.Forms.TextBox
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.MonthTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
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
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 5
        Me.cmdPrint.Text = "Print Report"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(160, 140)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 4
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdLoad
        '
        Me.cmdLoad.Location = New System.Drawing.Point(83, 140)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(71, 30)
        Me.cmdLoad.TabIndex = 3
        Me.cmdLoad.Text = "Load"
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 6
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboYear)
        Me.GroupBox1.Controls.Add(Me.cboMonth)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdLoad)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(248, 188)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Month Selection"
        '
        'cboYear
        '
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Items.AddRange(New Object() {"2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025"})
        Me.cboYear.Location = New System.Drawing.Point(70, 102)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(161, 21)
        Me.cboYear.TabIndex = 2
        '
        'cboMonth
        '
        Me.cboMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMonth.DataSource = Me.MonthTableBindingSource
        Me.cboMonth.DisplayMember = "MonthName"
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Location = New System.Drawing.Point(70, 65)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(161, 21)
        Me.cboMonth.TabIndex = 1
        '
        'MonthTableBindingSource
        '
        Me.MonthTableBindingSource.DataMember = "MonthTable"
        Me.MonthTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(70, 27)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(161, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(15, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Year"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(15, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Month"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Division"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'MonthTableTableAdapter
        '
        Me.MonthTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label55)
        Me.GroupBox2.Controls.Add(Me.Label54)
        Me.GroupBox2.Controls.Add(Me.txtLYTotalQuoteAmount)
        Me.GroupBox2.Controls.Add(Me.txtLYTotalInvoices)
        Me.GroupBox2.Controls.Add(Me.txtLYTotalCustomerReturns)
        Me.GroupBox2.Controls.Add(Me.txtLYTotalShipments)
        Me.GroupBox2.Controls.Add(Me.txtLYTotalOrders)
        Me.GroupBox2.Controls.Add(Me.Label49)
        Me.GroupBox2.Controls.Add(Me.txtTotalQuoteAmount)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtTotalInvoices)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtTotalCustomerReturns)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtTotalShipments)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtTotalOrders)
        Me.GroupBox2.Location = New System.Drawing.Point(294, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(465, 220)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sales Totals (Dollars)"
        '
        'Label55
        '
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.Black
        Me.Label55.Location = New System.Drawing.Point(317, 16)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(132, 20)
        Me.Label55.TabIndex = 34
        Me.Label55.Text = "Month (Prev. Year)"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label54
        '
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.Color.Black
        Me.Label54.Location = New System.Drawing.Point(170, 16)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(132, 20)
        Me.Label54.TabIndex = 33
        Me.Label54.Text = "Current Month"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtLYTotalQuoteAmount
        '
        Me.txtLYTotalQuoteAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLYTotalQuoteAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLYTotalQuoteAmount.Location = New System.Drawing.Point(320, 46)
        Me.txtLYTotalQuoteAmount.Name = "txtLYTotalQuoteAmount"
        Me.txtLYTotalQuoteAmount.Size = New System.Drawing.Size(129, 20)
        Me.txtLYTotalQuoteAmount.TabIndex = 15
        Me.txtLYTotalQuoteAmount.TabStop = False
        Me.txtLYTotalQuoteAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLYTotalInvoices
        '
        Me.txtLYTotalInvoices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLYTotalInvoices.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLYTotalInvoices.Location = New System.Drawing.Point(320, 178)
        Me.txtLYTotalInvoices.Name = "txtLYTotalInvoices"
        Me.txtLYTotalInvoices.Size = New System.Drawing.Size(129, 20)
        Me.txtLYTotalInvoices.TabIndex = 14
        Me.txtLYTotalInvoices.TabStop = False
        Me.txtLYTotalInvoices.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLYTotalCustomerReturns
        '
        Me.txtLYTotalCustomerReturns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLYTotalCustomerReturns.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLYTotalCustomerReturns.Location = New System.Drawing.Point(320, 145)
        Me.txtLYTotalCustomerReturns.Name = "txtLYTotalCustomerReturns"
        Me.txtLYTotalCustomerReturns.Size = New System.Drawing.Size(129, 20)
        Me.txtLYTotalCustomerReturns.TabIndex = 13
        Me.txtLYTotalCustomerReturns.TabStop = False
        Me.txtLYTotalCustomerReturns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLYTotalShipments
        '
        Me.txtLYTotalShipments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLYTotalShipments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLYTotalShipments.Location = New System.Drawing.Point(320, 112)
        Me.txtLYTotalShipments.Name = "txtLYTotalShipments"
        Me.txtLYTotalShipments.Size = New System.Drawing.Size(129, 20)
        Me.txtLYTotalShipments.TabIndex = 12
        Me.txtLYTotalShipments.TabStop = False
        Me.txtLYTotalShipments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLYTotalOrders
        '
        Me.txtLYTotalOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLYTotalOrders.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLYTotalOrders.Location = New System.Drawing.Point(320, 79)
        Me.txtLYTotalOrders.Name = "txtLYTotalOrders"
        Me.txtLYTotalOrders.Size = New System.Drawing.Size(129, 20)
        Me.txtLYTotalOrders.TabIndex = 11
        Me.txtLYTotalOrders.TabStop = False
        Me.txtLYTotalOrders.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label49
        '
        Me.Label49.Location = New System.Drawing.Point(15, 46)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(152, 20)
        Me.Label49.TabIndex = 10
        Me.Label49.Text = "Total Open Quotes for Month"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalQuoteAmount
        '
        Me.txtTotalQuoteAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalQuoteAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalQuoteAmount.Location = New System.Drawing.Point(173, 46)
        Me.txtTotalQuoteAmount.Name = "txtTotalQuoteAmount"
        Me.txtTotalQuoteAmount.Size = New System.Drawing.Size(129, 20)
        Me.txtTotalQuoteAmount.TabIndex = 9
        Me.txtTotalQuoteAmount.TabStop = False
        Me.txtTotalQuoteAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(15, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(134, 20)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Total Invoices for Month"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalInvoices
        '
        Me.txtTotalInvoices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalInvoices.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalInvoices.Location = New System.Drawing.Point(173, 178)
        Me.txtTotalInvoices.Name = "txtTotalInvoices"
        Me.txtTotalInvoices.Size = New System.Drawing.Size(129, 20)
        Me.txtTotalInvoices.TabIndex = 7
        Me.txtTotalInvoices.TabStop = False
        Me.txtTotalInvoices.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(15, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 20)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Total Returns for Month"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalCustomerReturns
        '
        Me.txtTotalCustomerReturns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCustomerReturns.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalCustomerReturns.Location = New System.Drawing.Point(173, 145)
        Me.txtTotalCustomerReturns.Name = "txtTotalCustomerReturns"
        Me.txtTotalCustomerReturns.Size = New System.Drawing.Size(129, 20)
        Me.txtTotalCustomerReturns.TabIndex = 5
        Me.txtTotalCustomerReturns.TabStop = False
        Me.txtTotalCustomerReturns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(15, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Total Shipments for Month"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalShipments
        '
        Me.txtTotalShipments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalShipments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalShipments.Location = New System.Drawing.Point(173, 112)
        Me.txtTotalShipments.Name = "txtTotalShipments"
        Me.txtTotalShipments.Size = New System.Drawing.Size(129, 20)
        Me.txtTotalShipments.TabIndex = 3
        Me.txtTotalShipments.TabStop = False
        Me.txtTotalShipments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(15, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 20)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Total Orders for Month"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalOrders
        '
        Me.txtTotalOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalOrders.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalOrders.Location = New System.Drawing.Point(173, 79)
        Me.txtTotalOrders.Name = "txtTotalOrders"
        Me.txtTotalOrders.Size = New System.Drawing.Size(129, 20)
        Me.txtTotalOrders.TabIndex = 0
        Me.txtTotalOrders.TabStop = False
        Me.txtTotalOrders.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label48)
        Me.GroupBox3.Controls.Add(Me.txtRentalBilled)
        Me.GroupBox3.Controls.Add(Me.Label47)
        Me.GroupBox3.Controls.Add(Me.txtLaborBilled)
        Me.GroupBox3.Controls.Add(Me.Label46)
        Me.GroupBox3.Controls.Add(Me.txtFreightBilled)
        Me.GroupBox3.Controls.Add(Me.Label44)
        Me.GroupBox3.Controls.Add(Me.txtChangeInInventory)
        Me.GroupBox3.Controls.Add(Me.Label42)
        Me.GroupBox3.Controls.Add(Me.txtTotalAdjustmentNumber)
        Me.GroupBox3.Controls.Add(Me.Label41)
        Me.GroupBox3.Controls.Add(Me.txtTotalAdjustmentDollars)
        Me.GroupBox3.Location = New System.Drawing.Point(779, 197)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(350, 225)
        Me.GroupBox3.TabIndex = 26
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Misc. Totals"
        '
        'Label48
        '
        Me.Label48.Location = New System.Drawing.Point(15, 190)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(152, 20)
        Me.Label48.TabIndex = 26
        Me.Label48.Text = "Rental Billed ($)"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRentalBilled
        '
        Me.txtRentalBilled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRentalBilled.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRentalBilled.Location = New System.Drawing.Point(173, 190)
        Me.txtRentalBilled.Name = "txtRentalBilled"
        Me.txtRentalBilled.Size = New System.Drawing.Size(160, 20)
        Me.txtRentalBilled.TabIndex = 25
        Me.txtRentalBilled.TabStop = False
        Me.txtRentalBilled.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(15, 156)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(152, 20)
        Me.Label47.TabIndex = 24
        Me.Label47.Text = "Labor/Repair Billed ($)"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLaborBilled
        '
        Me.txtLaborBilled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLaborBilled.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLaborBilled.Location = New System.Drawing.Point(173, 156)
        Me.txtLaborBilled.Name = "txtLaborBilled"
        Me.txtLaborBilled.Size = New System.Drawing.Size(160, 20)
        Me.txtLaborBilled.TabIndex = 23
        Me.txtLaborBilled.TabStop = False
        Me.txtLaborBilled.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label46
        '
        Me.Label46.Location = New System.Drawing.Point(15, 122)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(152, 20)
        Me.Label46.TabIndex = 22
        Me.Label46.Text = "Freight Billed ($)"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFreightBilled
        '
        Me.txtFreightBilled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightBilled.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreightBilled.Location = New System.Drawing.Point(173, 122)
        Me.txtFreightBilled.Name = "txtFreightBilled"
        Me.txtFreightBilled.Size = New System.Drawing.Size(160, 20)
        Me.txtFreightBilled.TabIndex = 21
        Me.txtFreightBilled.TabStop = False
        Me.txtFreightBilled.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(15, 88)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(152, 20)
        Me.Label44.TabIndex = 20
        Me.Label44.Text = "Change in Inventory Value"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtChangeInInventory
        '
        Me.txtChangeInInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChangeInInventory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChangeInInventory.Location = New System.Drawing.Point(173, 88)
        Me.txtChangeInInventory.Name = "txtChangeInInventory"
        Me.txtChangeInInventory.Size = New System.Drawing.Size(160, 20)
        Me.txtChangeInInventory.TabIndex = 19
        Me.txtChangeInInventory.TabStop = False
        Me.txtChangeInInventory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(15, 54)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(152, 20)
        Me.Label42.TabIndex = 18
        Me.Label42.Text = "# of Adj. for Month (#)"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalAdjustmentNumber
        '
        Me.txtTotalAdjustmentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalAdjustmentNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalAdjustmentNumber.Location = New System.Drawing.Point(173, 54)
        Me.txtTotalAdjustmentNumber.Name = "txtTotalAdjustmentNumber"
        Me.txtTotalAdjustmentNumber.Size = New System.Drawing.Size(160, 20)
        Me.txtTotalAdjustmentNumber.TabIndex = 17
        Me.txtTotalAdjustmentNumber.TabStop = False
        Me.txtTotalAdjustmentNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label41
        '
        Me.Label41.Location = New System.Drawing.Point(15, 20)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(152, 20)
        Me.Label41.TabIndex = 16
        Me.Label41.Text = "Total Adj. for Month ($)"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalAdjustmentDollars
        '
        Me.txtTotalAdjustmentDollars.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalAdjustmentDollars.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalAdjustmentDollars.Location = New System.Drawing.Point(173, 20)
        Me.txtTotalAdjustmentDollars.Name = "txtTotalAdjustmentDollars"
        Me.txtTotalAdjustmentDollars.Size = New System.Drawing.Size(160, 20)
        Me.txtTotalAdjustmentDollars.TabIndex = 15
        Me.txtTotalAdjustmentDollars.TabStop = False
        Me.txtTotalAdjustmentDollars.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.txtTotalVendorReturns)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txtTotalReceived)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.txtTotalPOs)
        Me.GroupBox4.Location = New System.Drawing.Point(779, 44)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(350, 142)
        Me.GroupBox4.TabIndex = 27
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Purchase Totals (Dollars)"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(15, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(134, 20)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Total Returns for Month"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalVendorReturns
        '
        Me.txtTotalVendorReturns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalVendorReturns.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalVendorReturns.Location = New System.Drawing.Point(173, 105)
        Me.txtTotalVendorReturns.Name = "txtTotalVendorReturns"
        Me.txtTotalVendorReturns.Size = New System.Drawing.Size(160, 20)
        Me.txtTotalVendorReturns.TabIndex = 13
        Me.txtTotalVendorReturns.TabStop = False
        Me.txtTotalVendorReturns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(15, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 20)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Total Received for Month"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalReceived
        '
        Me.txtTotalReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalReceived.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalReceived.Location = New System.Drawing.Point(173, 67)
        Me.txtTotalReceived.Name = "txtTotalReceived"
        Me.txtTotalReceived.Size = New System.Drawing.Size(160, 20)
        Me.txtTotalReceived.TabIndex = 11
        Me.txtTotalReceived.TabStop = False
        Me.txtTotalReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(15, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(134, 20)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Total PO's for Month"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalPOs
        '
        Me.txtTotalPOs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPOs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalPOs.Location = New System.Drawing.Point(173, 29)
        Me.txtTotalPOs.Name = "txtTotalPOs"
        Me.txtTotalPOs.Size = New System.Drawing.Size(160, 20)
        Me.txtTotalPOs.TabIndex = 9
        Me.txtTotalPOs.TabStop = False
        Me.txtTotalPOs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.txtAging46)
        Me.GroupBox5.Controls.Add(Me.txtAging90)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.txtAging31)
        Me.GroupBox5.Controls.Add(Me.txtAging61)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.txtAging30)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.txtTotalOpenInvoices)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.txtTotalCashReceipts)
        Me.GroupBox5.Location = New System.Drawing.Point(294, 269)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(357, 256)
        Me.GroupBox5.TabIndex = 28
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "A/R Totals (Aging is current to today's date only)"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(15, 157)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(171, 20)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Aging 46 to 60"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(15, 221)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(171, 20)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "Aging > 90"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAging46
        '
        Me.txtAging46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAging46.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAging46.Location = New System.Drawing.Point(192, 157)
        Me.txtAging46.Name = "txtAging46"
        Me.txtAging46.Size = New System.Drawing.Size(141, 20)
        Me.txtAging46.TabIndex = 31
        Me.txtAging46.TabStop = False
        Me.txtAging46.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAging90
        '
        Me.txtAging90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAging90.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAging90.Location = New System.Drawing.Point(192, 221)
        Me.txtAging90.Name = "txtAging90"
        Me.txtAging90.Size = New System.Drawing.Size(141, 20)
        Me.txtAging90.TabIndex = 23
        Me.txtAging90.TabStop = False
        Me.txtAging90.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(15, 125)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(171, 20)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "Aging 31 to 45"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(15, 189)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(171, 20)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Aging 61 to 90"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAging31
        '
        Me.txtAging31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAging31.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAging31.Location = New System.Drawing.Point(192, 125)
        Me.txtAging31.Name = "txtAging31"
        Me.txtAging31.Size = New System.Drawing.Size(141, 20)
        Me.txtAging31.TabIndex = 29
        Me.txtAging31.TabStop = False
        Me.txtAging31.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAging61
        '
        Me.txtAging61.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAging61.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAging61.Location = New System.Drawing.Point(192, 189)
        Me.txtAging61.Name = "txtAging61"
        Me.txtAging61.Size = New System.Drawing.Size(141, 20)
        Me.txtAging61.TabIndex = 21
        Me.txtAging61.TabStop = False
        Me.txtAging61.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(15, 93)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(171, 20)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Aging <= 30"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAging30
        '
        Me.txtAging30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAging30.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAging30.Location = New System.Drawing.Point(192, 93)
        Me.txtAging30.Name = "txtAging30"
        Me.txtAging30.Size = New System.Drawing.Size(141, 20)
        Me.txtAging30.TabIndex = 19
        Me.txtAging30.TabStop = False
        Me.txtAging30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(15, 61)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(171, 20)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Total Open Invoices"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalOpenInvoices
        '
        Me.txtTotalOpenInvoices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalOpenInvoices.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalOpenInvoices.Location = New System.Drawing.Point(192, 61)
        Me.txtTotalOpenInvoices.Name = "txtTotalOpenInvoices"
        Me.txtTotalOpenInvoices.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalOpenInvoices.TabIndex = 17
        Me.txtTotalOpenInvoices.TabStop = False
        Me.txtTotalOpenInvoices.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(15, 29)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(171, 20)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Total Cash Receipts for Month"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalCashReceipts
        '
        Me.txtTotalCashReceipts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCashReceipts.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalCashReceipts.Location = New System.Drawing.Point(192, 29)
        Me.txtTotalCashReceipts.Name = "txtTotalCashReceipts"
        Me.txtTotalCashReceipts.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalCashReceipts.TabIndex = 15
        Me.txtTotalCashReceipts.TabStop = False
        Me.txtTotalCashReceipts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label18)
        Me.GroupBox6.Controls.Add(Me.Label19)
        Me.GroupBox6.Controls.Add(Me.txtAPAging46)
        Me.GroupBox6.Controls.Add(Me.txtAPAging90)
        Me.GroupBox6.Controls.Add(Me.Label20)
        Me.GroupBox6.Controls.Add(Me.Label21)
        Me.GroupBox6.Controls.Add(Me.txtAPAging31)
        Me.GroupBox6.Controls.Add(Me.txtAPAging61)
        Me.GroupBox6.Controls.Add(Me.Label22)
        Me.GroupBox6.Controls.Add(Me.txtAPAging30)
        Me.GroupBox6.Controls.Add(Me.Label23)
        Me.GroupBox6.Controls.Add(Me.txtTotalOpenPayables)
        Me.GroupBox6.Controls.Add(Me.Label24)
        Me.GroupBox6.Controls.Add(Me.txtTotalPayments)
        Me.GroupBox6.Location = New System.Drawing.Point(294, 531)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(357, 286)
        Me.GroupBox6.TabIndex = 29
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "A/P Totals (Aging is currect to today's date only)"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(15, 173)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(134, 20)
        Me.Label18.TabIndex = 32
        Me.Label18.Text = "Aging 46 to 60"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(15, 245)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(134, 20)
        Me.Label19.TabIndex = 24
        Me.Label19.Text = "Aging > 90"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAPAging46
        '
        Me.txtAPAging46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAPAging46.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAPAging46.Location = New System.Drawing.Point(173, 173)
        Me.txtAPAging46.Name = "txtAPAging46"
        Me.txtAPAging46.Size = New System.Drawing.Size(160, 20)
        Me.txtAPAging46.TabIndex = 31
        Me.txtAPAging46.TabStop = False
        Me.txtAPAging46.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAPAging90
        '
        Me.txtAPAging90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAPAging90.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAPAging90.Location = New System.Drawing.Point(173, 245)
        Me.txtAPAging90.Name = "txtAPAging90"
        Me.txtAPAging90.Size = New System.Drawing.Size(160, 20)
        Me.txtAPAging90.TabIndex = 23
        Me.txtAPAging90.TabStop = False
        Me.txtAPAging90.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(15, 137)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(134, 20)
        Me.Label20.TabIndex = 30
        Me.Label20.Text = "Aging 31 to 45"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(15, 209)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(134, 20)
        Me.Label21.TabIndex = 22
        Me.Label21.Text = "Aging 61 to 90"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAPAging31
        '
        Me.txtAPAging31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAPAging31.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAPAging31.Location = New System.Drawing.Point(173, 137)
        Me.txtAPAging31.Name = "txtAPAging31"
        Me.txtAPAging31.Size = New System.Drawing.Size(160, 20)
        Me.txtAPAging31.TabIndex = 29
        Me.txtAPAging31.TabStop = False
        Me.txtAPAging31.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAPAging61
        '
        Me.txtAPAging61.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAPAging61.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAPAging61.Location = New System.Drawing.Point(173, 209)
        Me.txtAPAging61.Name = "txtAPAging61"
        Me.txtAPAging61.Size = New System.Drawing.Size(160, 20)
        Me.txtAPAging61.TabIndex = 21
        Me.txtAPAging61.TabStop = False
        Me.txtAPAging61.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(15, 101)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(134, 20)
        Me.Label22.TabIndex = 20
        Me.Label22.Text = "Aging <= 30"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAPAging30
        '
        Me.txtAPAging30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAPAging30.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAPAging30.Location = New System.Drawing.Point(173, 101)
        Me.txtAPAging30.Name = "txtAPAging30"
        Me.txtAPAging30.Size = New System.Drawing.Size(160, 20)
        Me.txtAPAging30.TabIndex = 19
        Me.txtAPAging30.TabStop = False
        Me.txtAPAging30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(15, 65)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(152, 20)
        Me.Label23.TabIndex = 18
        Me.Label23.Text = "Total Open Payables"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalOpenPayables
        '
        Me.txtTotalOpenPayables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalOpenPayables.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalOpenPayables.Location = New System.Drawing.Point(173, 65)
        Me.txtTotalOpenPayables.Name = "txtTotalOpenPayables"
        Me.txtTotalOpenPayables.Size = New System.Drawing.Size(160, 20)
        Me.txtTotalOpenPayables.TabIndex = 17
        Me.txtTotalOpenPayables.TabStop = False
        Me.txtTotalOpenPayables.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(15, 29)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(158, 20)
        Me.Label24.TabIndex = 16
        Me.Label24.Text = "Total Payments for Month"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalPayments
        '
        Me.txtTotalPayments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPayments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalPayments.Location = New System.Drawing.Point(173, 29)
        Me.txtTotalPayments.Name = "txtTotalPayments"
        Me.txtTotalPayments.Size = New System.Drawing.Size(160, 20)
        Me.txtTotalPayments.TabIndex = 15
        Me.txtTotalPayments.TabStop = False
        Me.txtTotalPayments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txtSteelUsagenet)
        Me.GroupBox7.Controls.Add(Me.Label43)
        Me.GroupBox7.Controls.Add(Me.txtSteelYardQuantity)
        Me.GroupBox7.Controls.Add(Me.txtSteelUsageQuantity)
        Me.GroupBox7.Controls.Add(Me.Label40)
        Me.GroupBox7.Controls.Add(Me.Label39)
        Me.GroupBox7.Location = New System.Drawing.Point(779, 615)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(350, 143)
        Me.GroupBox7.TabIndex = 30
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Steel Totals (Quantity)"
        '
        'txtSteelUsagenet
        '
        Me.txtSteelUsagenet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelUsagenet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelUsagenet.Location = New System.Drawing.Point(193, 103)
        Me.txtSteelUsagenet.Name = "txtSteelUsagenet"
        Me.txtSteelUsagenet.Size = New System.Drawing.Size(140, 20)
        Me.txtSteelUsagenet.TabIndex = 31
        Me.txtSteelUsagenet.TabStop = False
        Me.txtSteelUsagenet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(9, 102)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(178, 20)
        Me.Label43.TabIndex = 32
        Me.Label43.Text = "Steel Net Amt. Used for Month (Qty)"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSteelYardQuantity
        '
        Me.txtSteelYardQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelYardQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelYardQuantity.Location = New System.Drawing.Point(193, 28)
        Me.txtSteelYardQuantity.Name = "txtSteelYardQuantity"
        Me.txtSteelYardQuantity.Size = New System.Drawing.Size(140, 20)
        Me.txtSteelYardQuantity.TabIndex = 29
        Me.txtSteelYardQuantity.TabStop = False
        Me.txtSteelYardQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSteelUsageQuantity
        '
        Me.txtSteelUsageQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelUsageQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelUsageQuantity.Location = New System.Drawing.Point(193, 65)
        Me.txtSteelUsageQuantity.Name = "txtSteelUsageQuantity"
        Me.txtSteelUsageQuantity.Size = New System.Drawing.Size(140, 20)
        Me.txtSteelUsageQuantity.TabIndex = 25
        Me.txtSteelUsageQuantity.TabStop = False
        Me.txtSteelUsageQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(9, 28)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(187, 20)
        Me.Label40.TabIndex = 30
        Me.Label40.Text = "Steel Ret. to Yard for Month (Qty)"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(9, 65)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(152, 20)
        Me.Label39.TabIndex = 26
        Me.Label39.Text = "Steel Used for Month (Qty)"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.txtNumberOfSteelReturns)
        Me.GroupBox8.Controls.Add(Me.Label53)
        Me.GroupBox8.Controls.Add(Me.txtNumberOfSteelAdj)
        Me.GroupBox8.Controls.Add(Me.txtNumberOfSteelReceipts)
        Me.GroupBox8.Controls.Add(Me.txtNumberOfSteelPOs)
        Me.GroupBox8.Controls.Add(Me.Label50)
        Me.GroupBox8.Controls.Add(Me.Label51)
        Me.GroupBox8.Controls.Add(Me.Label52)
        Me.GroupBox8.Controls.Add(Me.txtNumberOfQuotes)
        Me.GroupBox8.Controls.Add(Me.Label45)
        Me.GroupBox8.Controls.Add(Me.Label33)
        Me.GroupBox8.Controls.Add(Me.txtNumberOfPayments)
        Me.GroupBox8.Controls.Add(Me.txtNumberOfCashReceipts)
        Me.GroupBox8.Controls.Add(Me.txtNumberOfVendorReturns)
        Me.GroupBox8.Controls.Add(Me.txtNumberOfReceivers)
        Me.GroupBox8.Controls.Add(Me.txtNumberOfPOs)
        Me.GroupBox8.Controls.Add(Me.txtNumberOfInvoices)
        Me.GroupBox8.Controls.Add(Me.txtNumberOfCustomerReturns)
        Me.GroupBox8.Controls.Add(Me.txtNumberOfShipments)
        Me.GroupBox8.Controls.Add(Me.txtNumberOfOrders)
        Me.GroupBox8.Controls.Add(Me.Label34)
        Me.GroupBox8.Controls.Add(Me.Label31)
        Me.GroupBox8.Controls.Add(Me.Label32)
        Me.GroupBox8.Controls.Add(Me.Label29)
        Me.GroupBox8.Controls.Add(Me.Label30)
        Me.GroupBox8.Controls.Add(Me.Label27)
        Me.GroupBox8.Controls.Add(Me.Label28)
        Me.GroupBox8.Controls.Add(Me.Label25)
        Me.GroupBox8.Controls.Add(Me.Label26)
        Me.GroupBox8.Location = New System.Drawing.Point(29, 244)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(248, 571)
        Me.GroupBox8.TabIndex = 31
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Month Quantity Details"
        '
        'txtNumberOfSteelReturns
        '
        Me.txtNumberOfSteelReturns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfSteelReturns.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberOfSteelReturns.Location = New System.Drawing.Point(129, 503)
        Me.txtNumberOfSteelReturns.Name = "txtNumberOfSteelReturns"
        Me.txtNumberOfSteelReturns.Size = New System.Drawing.Size(102, 20)
        Me.txtNumberOfSteelReturns.TabIndex = 42
        Me.txtNumberOfSteelReturns.TabStop = False
        Me.txtNumberOfSteelReturns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label53
        '
        Me.Label53.Location = New System.Drawing.Point(14, 503)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(121, 20)
        Me.Label53.TabIndex = 43
        Me.Label53.Text = "# of Steel  Returns"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumberOfSteelAdj
        '
        Me.txtNumberOfSteelAdj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfSteelAdj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberOfSteelAdj.Location = New System.Drawing.Point(129, 539)
        Me.txtNumberOfSteelAdj.Name = "txtNumberOfSteelAdj"
        Me.txtNumberOfSteelAdj.Size = New System.Drawing.Size(102, 20)
        Me.txtNumberOfSteelAdj.TabIndex = 40
        Me.txtNumberOfSteelAdj.TabStop = False
        Me.txtNumberOfSteelAdj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumberOfSteelReceipts
        '
        Me.txtNumberOfSteelReceipts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfSteelReceipts.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberOfSteelReceipts.Location = New System.Drawing.Point(129, 467)
        Me.txtNumberOfSteelReceipts.Name = "txtNumberOfSteelReceipts"
        Me.txtNumberOfSteelReceipts.Size = New System.Drawing.Size(102, 20)
        Me.txtNumberOfSteelReceipts.TabIndex = 38
        Me.txtNumberOfSteelReceipts.TabStop = False
        Me.txtNumberOfSteelReceipts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumberOfSteelPOs
        '
        Me.txtNumberOfSteelPOs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfSteelPOs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberOfSteelPOs.Location = New System.Drawing.Point(129, 431)
        Me.txtNumberOfSteelPOs.Name = "txtNumberOfSteelPOs"
        Me.txtNumberOfSteelPOs.Size = New System.Drawing.Size(102, 20)
        Me.txtNumberOfSteelPOs.TabIndex = 36
        Me.txtNumberOfSteelPOs.TabStop = False
        Me.txtNumberOfSteelPOs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label50
        '
        Me.Label50.Location = New System.Drawing.Point(14, 539)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(121, 20)
        Me.Label50.TabIndex = 41
        Me.Label50.Text = "# of Steel Adjust."
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label51
        '
        Me.Label51.Location = New System.Drawing.Point(14, 467)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(121, 20)
        Me.Label51.TabIndex = 39
        Me.Label51.Text = "# of Steel  Receipts"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label52
        '
        Me.Label52.Location = New System.Drawing.Point(14, 431)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(121, 20)
        Me.Label52.TabIndex = 37
        Me.Label52.Text = "# of Steel PO's"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumberOfQuotes
        '
        Me.txtNumberOfQuotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfQuotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberOfQuotes.Location = New System.Drawing.Point(129, 71)
        Me.txtNumberOfQuotes.Name = "txtNumberOfQuotes"
        Me.txtNumberOfQuotes.Size = New System.Drawing.Size(102, 20)
        Me.txtNumberOfQuotes.TabIndex = 34
        Me.txtNumberOfQuotes.TabStop = False
        Me.txtNumberOfQuotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label45
        '
        Me.Label45.Location = New System.Drawing.Point(14, 71)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(121, 20)
        Me.Label45.TabIndex = 35
        Me.Label45.Text = "# of Quotes"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.ForeColor = System.Drawing.Color.Blue
        Me.Label33.Location = New System.Drawing.Point(17, 17)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(205, 41)
        Me.Label33.TabIndex = 33
        Me.Label33.Text = "Total number of each item put on in the selected month."
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumberOfPayments
        '
        Me.txtNumberOfPayments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfPayments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberOfPayments.Location = New System.Drawing.Point(129, 395)
        Me.txtNumberOfPayments.Name = "txtNumberOfPayments"
        Me.txtNumberOfPayments.Size = New System.Drawing.Size(102, 20)
        Me.txtNumberOfPayments.TabIndex = 31
        Me.txtNumberOfPayments.TabStop = False
        Me.txtNumberOfPayments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumberOfCashReceipts
        '
        Me.txtNumberOfCashReceipts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfCashReceipts.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberOfCashReceipts.Location = New System.Drawing.Point(129, 359)
        Me.txtNumberOfCashReceipts.Name = "txtNumberOfCashReceipts"
        Me.txtNumberOfCashReceipts.Size = New System.Drawing.Size(102, 20)
        Me.txtNumberOfCashReceipts.TabIndex = 29
        Me.txtNumberOfCashReceipts.TabStop = False
        Me.txtNumberOfCashReceipts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumberOfVendorReturns
        '
        Me.txtNumberOfVendorReturns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfVendorReturns.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberOfVendorReturns.Location = New System.Drawing.Point(129, 323)
        Me.txtNumberOfVendorReturns.Name = "txtNumberOfVendorReturns"
        Me.txtNumberOfVendorReturns.Size = New System.Drawing.Size(102, 20)
        Me.txtNumberOfVendorReturns.TabIndex = 27
        Me.txtNumberOfVendorReturns.TabStop = False
        Me.txtNumberOfVendorReturns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumberOfReceivers
        '
        Me.txtNumberOfReceivers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfReceivers.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberOfReceivers.Location = New System.Drawing.Point(129, 287)
        Me.txtNumberOfReceivers.Name = "txtNumberOfReceivers"
        Me.txtNumberOfReceivers.Size = New System.Drawing.Size(102, 20)
        Me.txtNumberOfReceivers.TabIndex = 25
        Me.txtNumberOfReceivers.TabStop = False
        Me.txtNumberOfReceivers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumberOfPOs
        '
        Me.txtNumberOfPOs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfPOs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberOfPOs.Location = New System.Drawing.Point(129, 251)
        Me.txtNumberOfPOs.Name = "txtNumberOfPOs"
        Me.txtNumberOfPOs.Size = New System.Drawing.Size(102, 20)
        Me.txtNumberOfPOs.TabIndex = 23
        Me.txtNumberOfPOs.TabStop = False
        Me.txtNumberOfPOs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumberOfInvoices
        '
        Me.txtNumberOfInvoices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfInvoices.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberOfInvoices.Location = New System.Drawing.Point(129, 215)
        Me.txtNumberOfInvoices.Name = "txtNumberOfInvoices"
        Me.txtNumberOfInvoices.Size = New System.Drawing.Size(102, 20)
        Me.txtNumberOfInvoices.TabIndex = 21
        Me.txtNumberOfInvoices.TabStop = False
        Me.txtNumberOfInvoices.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumberOfCustomerReturns
        '
        Me.txtNumberOfCustomerReturns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfCustomerReturns.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberOfCustomerReturns.Location = New System.Drawing.Point(129, 179)
        Me.txtNumberOfCustomerReturns.Name = "txtNumberOfCustomerReturns"
        Me.txtNumberOfCustomerReturns.Size = New System.Drawing.Size(102, 20)
        Me.txtNumberOfCustomerReturns.TabIndex = 19
        Me.txtNumberOfCustomerReturns.TabStop = False
        Me.txtNumberOfCustomerReturns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumberOfShipments
        '
        Me.txtNumberOfShipments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfShipments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberOfShipments.Location = New System.Drawing.Point(129, 143)
        Me.txtNumberOfShipments.Name = "txtNumberOfShipments"
        Me.txtNumberOfShipments.Size = New System.Drawing.Size(102, 20)
        Me.txtNumberOfShipments.TabIndex = 17
        Me.txtNumberOfShipments.TabStop = False
        Me.txtNumberOfShipments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumberOfOrders
        '
        Me.txtNumberOfOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfOrders.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberOfOrders.Location = New System.Drawing.Point(129, 107)
        Me.txtNumberOfOrders.Name = "txtNumberOfOrders"
        Me.txtNumberOfOrders.Size = New System.Drawing.Size(102, 20)
        Me.txtNumberOfOrders.TabIndex = 15
        Me.txtNumberOfOrders.TabStop = False
        Me.txtNumberOfOrders.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(14, 395)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(121, 20)
        Me.Label34.TabIndex = 32
        Me.Label34.Text = "# of Payments Made"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(14, 359)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(121, 20)
        Me.Label31.TabIndex = 30
        Me.Label31.Text = "# of Cash Receipts"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(14, 323)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(121, 20)
        Me.Label32.TabIndex = 28
        Me.Label32.Text = "# of Vendor Returns"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(14, 287)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(121, 20)
        Me.Label29.TabIndex = 26
        Me.Label29.Text = "# of Receivers"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(14, 251)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(121, 20)
        Me.Label30.TabIndex = 24
        Me.Label30.Text = "# of PO's"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(14, 215)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(121, 20)
        Me.Label27.TabIndex = 22
        Me.Label27.Text = "# of Invoices"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(14, 179)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(121, 20)
        Me.Label28.TabIndex = 20
        Me.Label28.Text = "# of Cust. Returns"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(14, 143)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(121, 20)
        Me.Label25.TabIndex = 18
        Me.Label25.Text = "# of Shipments"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(14, 107)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(121, 20)
        Me.Label26.TabIndex = 16
        Me.Label26.Text = "# of Orders"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(15, 58)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(159, 20)
        Me.Label35.TabIndex = 22
        Me.Label35.Text = "Steel Receipts for Month ($)"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSteelReceivers
        '
        Me.txtSteelReceivers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelReceivers.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelReceivers.Location = New System.Drawing.Point(179, 59)
        Me.txtSteelReceivers.Name = "txtSteelReceivers"
        Me.txtSteelReceivers.Size = New System.Drawing.Size(160, 20)
        Me.txtSteelReceivers.TabIndex = 21
        Me.txtSteelReceivers.TabStop = False
        Me.txtSteelReceivers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(15, 22)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(159, 20)
        Me.Label36.TabIndex = 20
        Me.Label36.Text = "Steel Purchases for Month ($)"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSteelPOs
        '
        Me.txtSteelPOs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelPOs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelPOs.Location = New System.Drawing.Point(179, 22)
        Me.txtSteelPOs.Name = "txtSteelPOs"
        Me.txtSteelPOs.Size = New System.Drawing.Size(160, 20)
        Me.txtSteelPOs.TabIndex = 19
        Me.txtSteelPOs.TabStop = False
        Me.txtSteelPOs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(15, 97)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(159, 20)
        Me.Label37.TabIndex = 24
        Me.Label37.Text = "Steel Adjustments for Month ($)"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSteelAdjustments
        '
        Me.txtSteelAdjustments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelAdjustments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelAdjustments.Location = New System.Drawing.Point(180, 96)
        Me.txtSteelAdjustments.Name = "txtSteelAdjustments"
        Me.txtSteelAdjustments.Size = New System.Drawing.Size(160, 20)
        Me.txtSteelAdjustments.TabIndex = 23
        Me.txtSteelAdjustments.TabStop = False
        Me.txtSteelAdjustments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(15, 135)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(159, 20)
        Me.Label38.TabIndex = 28
        Me.Label38.Text = "Steel Returns for Month ($)"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSteelReturns
        '
        Me.txtSteelReturns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelReturns.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelReturns.Location = New System.Drawing.Point(179, 133)
        Me.txtSteelReturns.Name = "txtSteelReturns"
        Me.txtSteelReturns.Size = New System.Drawing.Size(160, 20)
        Me.txtSteelReturns.TabIndex = 27
        Me.txtSteelReturns.TabStop = False
        Me.txtSteelReturns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.Label36)
        Me.GroupBox9.Controls.Add(Me.txtSteelPOs)
        Me.GroupBox9.Controls.Add(Me.txtSteelReceivers)
        Me.GroupBox9.Controls.Add(Me.Label38)
        Me.GroupBox9.Controls.Add(Me.Label35)
        Me.GroupBox9.Controls.Add(Me.txtSteelReturns)
        Me.GroupBox9.Controls.Add(Me.txtSteelAdjustments)
        Me.GroupBox9.Controls.Add(Me.Label37)
        Me.GroupBox9.Location = New System.Drawing.Point(779, 433)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(350, 171)
        Me.GroupBox9.TabIndex = 32
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Steel Totals (Dollars)"
        '
        'MonthSnapshot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MonthSnapshot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Month Details"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.MonthTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdLoad As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents MonthTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MonthTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.MonthTableTableAdapter
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotalInvoices As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCustomerReturns As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotalShipments As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTotalOrders As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalVendorReturns As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotalReceived As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPOs As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtAging30 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTotalOpenInvoices As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCashReceipts As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtAging46 As System.Windows.Forms.TextBox
    Friend WithEvents txtAging90 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtAging31 As System.Windows.Forms.TextBox
    Friend WithEvents txtAging61 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtAPAging46 As System.Windows.Forms.TextBox
    Friend WithEvents txtAPAging90 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtAPAging31 As System.Windows.Forms.TextBox
    Friend WithEvents txtAPAging61 As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtAPAging30 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtTotalOpenPayables As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPayments As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtNumberOfPayments As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtNumberOfCashReceipts As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtNumberOfVendorReturns As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtNumberOfReceivers As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtNumberOfPOs As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtNumberOfInvoices As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtNumberOfCustomerReturns As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtNumberOfShipments As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtNumberOfOrders As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtSteelReturns As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtSteelUsageQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtSteelAdjustments As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtSteelReceivers As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtSteelPOs As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtSteelYardQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtTotalAdjustmentNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtTotalAdjustmentDollars As System.Windows.Forms.TextBox
    Friend WithEvents txtSteelUsagenet As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents txtChangeInInventory As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtNumberOfQuotes As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents txtRentalBilled As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txtLaborBilled As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtFreightBilled As System.Windows.Forms.TextBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents txtTotalQuoteAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtNumberOfSteelReturns As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents txtNumberOfSteelAdj As System.Windows.Forms.TextBox
    Friend WithEvents txtNumberOfSteelReceipts As System.Windows.Forms.TextBox
    Friend WithEvents txtNumberOfSteelPOs As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txtLYTotalQuoteAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtLYTotalInvoices As System.Windows.Forms.TextBox
    Friend WithEvents txtLYTotalCustomerReturns As System.Windows.Forms.TextBox
    Friend WithEvents txtLYTotalShipments As System.Windows.Forms.TextBox
    Friend WithEvents txtLYTotalOrders As System.Windows.Forms.TextBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
End Class
