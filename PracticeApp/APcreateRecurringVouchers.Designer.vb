<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class APCreateRecurringVouchers
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblDueDate = New System.Windows.Forms.Label
        Me.gpxVoucherHeader = New System.Windows.Forms.GroupBox
        Me.lblVendorClass = New System.Windows.Forms.Label
        Me.cboVendorClass = New System.Windows.Forms.ComboBox
        Me.txtInvoiceNumber = New System.Windows.Forms.TextBox
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtInvoiceAmount = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboPaymentTerms = New System.Windows.Forms.ComboBox
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblMessage = New System.Windows.Forms.Label
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker
        Me.rdoBimonth = New System.Windows.Forms.RadioButton
        Me.rdoQuarterly = New System.Windows.Forms.RadioButton
        Me.rdoSemiAnnual = New System.Windows.Forms.RadioButton
        Me.rdoMonth = New System.Windows.Forms.RadioButton
        Me.txtRepetitions = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dgvVoucherLines = New System.Windows.Forms.DataGridView
        Me.tabLineControls = New System.Windows.Forms.TabControl
        Me.tabEnterNew = New System.Windows.Forms.TabPage
        Me.Label18 = New System.Windows.Forms.Label
        Me.cboItemID = New System.Windows.Forms.ComboBox
        Me.txtExtendedAmount = New System.Windows.Forms.TextBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.txtUnitCost = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdEnterLine = New System.Windows.Forms.Button
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtLongDescription = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.tabDeleteLine = New System.Windows.Forms.TabPage
        Me.Label34 = New System.Windows.Forms.Label
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.txtLinePartDescription = New System.Windows.Forms.TextBox
        Me.txtLinePartNumber = New System.Windows.Forms.TextBox
        Me.cboVoucherLine = New System.Windows.Forms.ComboBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.chkManualDiscount = New System.Windows.Forms.CheckBox
        Me.txtDiscountAmount = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtInvoiceTotal = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtSalesTaxTotal = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtFreightTotal = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPurchaseTotal = New System.Windows.Forms.TextBox
        Me.cmdCreateRecurring = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboCreditAccount = New System.Windows.Forms.ComboBox
        Me.cboCreditDescription = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.cboDebitAccount = New System.Windows.Forms.ComboBox
        Me.cboDebitDescription = New System.Windows.Forms.ComboBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboCheckType = New System.Windows.Forms.ComboBox
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gpxVoucherHeader.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvVoucherLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabLineControls.SuspendLayout()
        Me.tabEnterNew.SuspendLayout()
        Me.tabDeleteLine.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
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
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 36
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 37
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboDivisionID)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(328, 63)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Company Division"
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(136, 25)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(175, 21)
        Me.cboDivisionID.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 20)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Division ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDueDate
        '
        Me.lblDueDate.Location = New System.Drawing.Point(16, 148)
        Me.lblDueDate.Name = "lblDueDate"
        Me.lblDueDate.Size = New System.Drawing.Size(136, 20)
        Me.lblDueDate.TabIndex = 75
        Me.lblDueDate.Text = "Due Date"
        Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxVoucherHeader
        '
        Me.gpxVoucherHeader.Controls.Add(Me.Label1)
        Me.gpxVoucherHeader.Controls.Add(Me.cboCheckType)
        Me.gpxVoucherHeader.Controls.Add(Me.lblVendorClass)
        Me.gpxVoucherHeader.Controls.Add(Me.cboVendorClass)
        Me.gpxVoucherHeader.Controls.Add(Me.txtInvoiceNumber)
        Me.gpxVoucherHeader.Controls.Add(Me.txtVendorName)
        Me.gpxVoucherHeader.Controls.Add(Me.cboVendorID)
        Me.gpxVoucherHeader.Controls.Add(Me.Label15)
        Me.gpxVoucherHeader.Controls.Add(Me.txtInvoiceAmount)
        Me.gpxVoucherHeader.Controls.Add(Me.Label4)
        Me.gpxVoucherHeader.Controls.Add(Me.cboPaymentTerms)
        Me.gpxVoucherHeader.Controls.Add(Me.txtComment)
        Me.gpxVoucherHeader.Controls.Add(Me.Label3)
        Me.gpxVoucherHeader.Controls.Add(Me.Label16)
        Me.gpxVoucherHeader.Controls.Add(Me.Label11)
        Me.gpxVoucherHeader.Location = New System.Drawing.Point(28, 373)
        Me.gpxVoucherHeader.Name = "gpxVoucherHeader"
        Me.gpxVoucherHeader.Size = New System.Drawing.Size(329, 438)
        Me.gpxVoucherHeader.TabIndex = 9
        Me.gpxVoucherHeader.TabStop = False
        Me.gpxVoucherHeader.Text = "Voucher Header Information"
        '
        'lblVendorClass
        '
        Me.lblVendorClass.Location = New System.Drawing.Point(21, 119)
        Me.lblVendorClass.Name = "lblVendorClass"
        Me.lblVendorClass.Size = New System.Drawing.Size(87, 20)
        Me.lblVendorClass.TabIndex = 78
        Me.lblVendorClass.Text = "Vendor Class"
        Me.lblVendorClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorClass
        '
        Me.cboVendorClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorClass.FormattingEnabled = True
        Me.cboVendorClass.Location = New System.Drawing.Point(123, 119)
        Me.cboVendorClass.Name = "cboVendorClass"
        Me.cboVendorClass.Size = New System.Drawing.Size(186, 21)
        Me.cboVendorClass.TabIndex = 11
        '
        'txtInvoiceNumber
        '
        Me.txtInvoiceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceNumber.Location = New System.Drawing.Point(123, 189)
        Me.txtInvoiceNumber.Name = "txtInvoiceNumber"
        Me.txtInvoiceNumber.Size = New System.Drawing.Size(186, 20)
        Me.txtInvoiceNumber.TabIndex = 13
        Me.txtInvoiceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorName.Location = New System.Drawing.Point(18, 65)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.ReadOnly = True
        Me.txtVendorName.Size = New System.Drawing.Size(291, 47)
        Me.txtVendorName.TabIndex = 4
        Me.txtVendorName.TabStop = False
        Me.txtVendorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(93, 31)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(216, 21)
        Me.cboVendorID.TabIndex = 10
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(18, 189)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(124, 20)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Invoice Number"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInvoiceAmount
        '
        Me.txtInvoiceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceAmount.Location = New System.Drawing.Point(123, 223)
        Me.txtInvoiceAmount.Name = "txtInvoiceAmount"
        Me.txtInvoiceAmount.Size = New System.Drawing.Size(186, 20)
        Me.txtInvoiceAmount.TabIndex = 14
        Me.txtInvoiceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 222)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 20)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Invoice Amount"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPaymentTerms
        '
        Me.cboPaymentTerms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPaymentTerms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentTerms.FormattingEnabled = True
        Me.cboPaymentTerms.Location = New System.Drawing.Point(123, 257)
        Me.cboPaymentTerms.Name = "cboPaymentTerms"
        Me.cboPaymentTerms.Size = New System.Drawing.Size(186, 21)
        Me.cboPaymentTerms.TabIndex = 15
        '
        'txtComment
        '
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(18, 318)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(291, 98)
        Me.txtComment.TabIndex = 16
        Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(21, 295)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 20)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Voucher Comment"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(18, 255)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(124, 20)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Payment Terms"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(15, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(124, 20)
        Me.Label11.TabIndex = 76
        Me.Label11.Text = "Vendor ID"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblMessage)
        Me.GroupBox1.Controls.Add(Me.dtpStartDate)
        Me.GroupBox1.Controls.Add(Me.rdoBimonth)
        Me.GroupBox1.Controls.Add(Me.rdoQuarterly)
        Me.GroupBox1.Controls.Add(Me.rdoSemiAnnual)
        Me.GroupBox1.Controls.Add(Me.rdoMonth)
        Me.GroupBox1.Controls.Add(Me.lblDueDate)
        Me.GroupBox1.Controls.Add(Me.txtRepetitions)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(28, 138)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 201)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Recurring Period / Duration"
        '
        'lblMessage
        '
        Me.lblMessage.ForeColor = System.Drawing.Color.Blue
        Me.lblMessage.Location = New System.Drawing.Point(175, 16)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(136, 98)
        Me.lblMessage.TabIndex = 85
        Me.lblMessage.Text = "Date(s) entered will be the day of the month that the recurring Voucher will be s" & _
            "hown to be paid."
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(184, 146)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(125, 20)
        Me.dtpStartDate.TabIndex = 8
        '
        'rdoBimonth
        '
        Me.rdoBimonth.AutoSize = True
        Me.rdoBimonth.Location = New System.Drawing.Point(18, 45)
        Me.rdoBimonth.Name = "rdoBimonth"
        Me.rdoBimonth.Size = New System.Drawing.Size(74, 17)
        Me.rdoBimonth.TabIndex = 4
        Me.rdoBimonth.TabStop = True
        Me.rdoBimonth.Text = "Bi-Monthly"
        Me.rdoBimonth.UseVisualStyleBackColor = True
        '
        'rdoQuarterly
        '
        Me.rdoQuarterly.AutoSize = True
        Me.rdoQuarterly.Location = New System.Drawing.Point(18, 71)
        Me.rdoQuarterly.Name = "rdoQuarterly"
        Me.rdoQuarterly.Size = New System.Drawing.Size(67, 17)
        Me.rdoQuarterly.TabIndex = 5
        Me.rdoQuarterly.TabStop = True
        Me.rdoQuarterly.Text = "Quarterly"
        Me.rdoQuarterly.UseVisualStyleBackColor = True
        '
        'rdoSemiAnnual
        '
        Me.rdoSemiAnnual.AutoSize = True
        Me.rdoSemiAnnual.Location = New System.Drawing.Point(18, 97)
        Me.rdoSemiAnnual.Name = "rdoSemiAnnual"
        Me.rdoSemiAnnual.Size = New System.Drawing.Size(84, 17)
        Me.rdoSemiAnnual.TabIndex = 6
        Me.rdoSemiAnnual.TabStop = True
        Me.rdoSemiAnnual.Text = "Semi-Annual"
        Me.rdoSemiAnnual.UseVisualStyleBackColor = True
        '
        'rdoMonth
        '
        Me.rdoMonth.AutoSize = True
        Me.rdoMonth.Location = New System.Drawing.Point(18, 19)
        Me.rdoMonth.Name = "rdoMonth"
        Me.rdoMonth.Size = New System.Drawing.Size(62, 17)
        Me.rdoMonth.TabIndex = 3
        Me.rdoMonth.TabStop = True
        Me.rdoMonth.Text = "Monthly"
        Me.rdoMonth.UseVisualStyleBackColor = True
        '
        'txtRepetitions
        '
        Me.txtRepetitions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRepetitions.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRepetitions.Location = New System.Drawing.Point(184, 120)
        Me.txtRepetitions.Name = "txtRepetitions"
        Me.txtRepetitions.Size = New System.Drawing.Size(125, 20)
        Me.txtRepetitions.TabIndex = 7
        Me.txtRepetitions.TabStop = False
        Me.txtRepetitions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(18, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 20)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "# of Repetitions"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvVoucherLines
        '
        Me.dgvVoucherLines.AllowUserToAddRows = False
        Me.dgvVoucherLines.AllowUserToDeleteRows = False
        Me.dgvVoucherLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvVoucherLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvVoucherLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVoucherLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvVoucherLines.Location = New System.Drawing.Point(373, 41)
        Me.dgvVoucherLines.Name = "dgvVoucherLines"
        Me.dgvVoucherLines.Size = New System.Drawing.Size(657, 403)
        Me.dgvVoucherLines.TabIndex = 77
        Me.dgvVoucherLines.TabStop = False
        '
        'tabLineControls
        '
        Me.tabLineControls.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.tabLineControls.Controls.Add(Me.tabEnterNew)
        Me.tabLineControls.Controls.Add(Me.tabDeleteLine)
        Me.tabLineControls.Location = New System.Drawing.Point(373, 450)
        Me.tabLineControls.Name = "tabLineControls"
        Me.tabLineControls.SelectedIndex = 0
        Me.tabLineControls.Size = New System.Drawing.Size(332, 304)
        Me.tabLineControls.TabIndex = 17
        '
        'tabEnterNew
        '
        Me.tabEnterNew.BackColor = System.Drawing.SystemColors.Control
        Me.tabEnterNew.Controls.Add(Me.Label18)
        Me.tabEnterNew.Controls.Add(Me.cboItemID)
        Me.tabEnterNew.Controls.Add(Me.txtExtendedAmount)
        Me.tabEnterNew.Controls.Add(Me.cmdClear)
        Me.tabEnterNew.Controls.Add(Me.txtUnitCost)
        Me.tabEnterNew.Controls.Add(Me.Label12)
        Me.tabEnterNew.Controls.Add(Me.cmdEnterLine)
        Me.tabEnterNew.Controls.Add(Me.txtQuantity)
        Me.tabEnterNew.Controls.Add(Me.Label19)
        Me.tabEnterNew.Controls.Add(Me.txtLongDescription)
        Me.tabEnterNew.Controls.Add(Me.Label21)
        Me.tabEnterNew.Controls.Add(Me.Label13)
        Me.tabEnterNew.Location = New System.Drawing.Point(4, 22)
        Me.tabEnterNew.Name = "tabEnterNew"
        Me.tabEnterNew.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEnterNew.Size = New System.Drawing.Size(324, 278)
        Me.tabEnterNew.TabIndex = 0
        Me.tabEnterNew.Text = "Enter Lines"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(18, 198)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(112, 20)
        Me.Label18.TabIndex = 89
        Me.Label18.Text = "Extended Cost"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboItemID
        '
        Me.cboItemID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemID.FormattingEnabled = True
        Me.cboItemID.Location = New System.Drawing.Point(109, 22)
        Me.cboItemID.Name = "cboItemID"
        Me.cboItemID.Size = New System.Drawing.Size(197, 21)
        Me.cboItemID.TabIndex = 18
        '
        'txtExtendedAmount
        '
        Me.txtExtendedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExtendedAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExtendedAmount.Location = New System.Drawing.Point(158, 198)
        Me.txtExtendedAmount.Name = "txtExtendedAmount"
        Me.txtExtendedAmount.ReadOnly = True
        Me.txtExtendedAmount.Size = New System.Drawing.Size(148, 20)
        Me.txtExtendedAmount.TabIndex = 22
        Me.txtExtendedAmount.TabStop = False
        Me.txtExtendedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(235, 237)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 24
        Me.cmdClear.Text = "Clear Lines"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'txtUnitCost
        '
        Me.txtUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnitCost.Location = New System.Drawing.Point(158, 169)
        Me.txtUnitCost.Name = "txtUnitCost"
        Me.txtUnitCost.Size = New System.Drawing.Size(148, 20)
        Me.txtUnitCost.TabIndex = 21
        Me.txtUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(18, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(124, 20)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "Item"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdEnterLine
        '
        Me.cmdEnterLine.Location = New System.Drawing.Point(158, 237)
        Me.cmdEnterLine.Name = "cmdEnterLine"
        Me.cmdEnterLine.Size = New System.Drawing.Size(71, 30)
        Me.cmdEnterLine.TabIndex = 23
        Me.cmdEnterLine.Text = "Enter Line"
        Me.cmdEnterLine.UseVisualStyleBackColor = True
        '
        'txtQuantity
        '
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuantity.Location = New System.Drawing.Point(158, 140)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(148, 20)
        Me.txtQuantity.TabIndex = 20
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(18, 169)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 20)
        Me.Label19.TabIndex = 87
        Me.Label19.Text = "Unit Cost"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLongDescription
        '
        Me.txtLongDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLongDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLongDescription.Location = New System.Drawing.Point(18, 73)
        Me.txtLongDescription.Multiline = True
        Me.txtLongDescription.Name = "txtLongDescription"
        Me.txtLongDescription.Size = New System.Drawing.Size(288, 58)
        Me.txtLongDescription.TabIndex = 19
        Me.txtLongDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(18, 140)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(112, 20)
        Me.Label21.TabIndex = 85
        Me.Label21.Text = "Quantity"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(18, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(124, 20)
        Me.Label13.TabIndex = 77
        Me.Label13.Text = "Description"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabDeleteLine
        '
        Me.tabDeleteLine.BackColor = System.Drawing.SystemColors.Control
        Me.tabDeleteLine.Controls.Add(Me.Label34)
        Me.tabDeleteLine.Controls.Add(Me.cmdDeleteLine)
        Me.tabDeleteLine.Controls.Add(Me.txtLinePartDescription)
        Me.tabDeleteLine.Controls.Add(Me.txtLinePartNumber)
        Me.tabDeleteLine.Controls.Add(Me.cboVoucherLine)
        Me.tabDeleteLine.Controls.Add(Me.Label32)
        Me.tabDeleteLine.Controls.Add(Me.Label33)
        Me.tabDeleteLine.Location = New System.Drawing.Point(4, 22)
        Me.tabDeleteLine.Name = "tabDeleteLine"
        Me.tabDeleteLine.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDeleteLine.Size = New System.Drawing.Size(324, 278)
        Me.tabDeleteLine.TabIndex = 1
        Me.tabDeleteLine.Text = "Delete Line"
        '
        'Label34
        '
        Me.Label34.ForeColor = System.Drawing.Color.Blue
        Me.Label34.Location = New System.Drawing.Point(20, 219)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(290, 46)
        Me.Label34.TabIndex = 94
        Me.Label34.Text = "To delete a line from the voucher, select the line in the datagrid or from the dr" & _
            "op down box and press ""Delete""."
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.Location = New System.Drawing.Point(239, 182)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 30)
        Me.cmdDeleteLine.TabIndex = 40
        Me.cmdDeleteLine.Text = "Delete"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'txtLinePartDescription
        '
        Me.txtLinePartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinePartDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLinePartDescription.Location = New System.Drawing.Point(21, 98)
        Me.txtLinePartDescription.Multiline = True
        Me.txtLinePartDescription.Name = "txtLinePartDescription"
        Me.txtLinePartDescription.ReadOnly = True
        Me.txtLinePartDescription.Size = New System.Drawing.Size(289, 65)
        Me.txtLinePartDescription.TabIndex = 39
        Me.txtLinePartDescription.TabStop = False
        Me.txtLinePartDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLinePartNumber
        '
        Me.txtLinePartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinePartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLinePartNumber.Location = New System.Drawing.Point(87, 64)
        Me.txtLinePartNumber.Name = "txtLinePartNumber"
        Me.txtLinePartNumber.ReadOnly = True
        Me.txtLinePartNumber.Size = New System.Drawing.Size(223, 20)
        Me.txtLinePartNumber.TabIndex = 38
        Me.txtLinePartNumber.TabStop = False
        Me.txtLinePartNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboVoucherLine
        '
        Me.cboVoucherLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVoucherLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVoucherLine.FormattingEnabled = True
        Me.cboVoucherLine.Location = New System.Drawing.Point(197, 26)
        Me.cboVoucherLine.Name = "cboVoucherLine"
        Me.cboVoucherLine.Size = New System.Drawing.Size(113, 21)
        Me.cboVoucherLine.TabIndex = 37
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(21, 27)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(112, 20)
        Me.Label32.TabIndex = 89
        Me.Label32.Text = "Voucher Line #"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(21, 64)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(112, 20)
        Me.Label33.TabIndex = 92
        Me.Label33.Text = "Item ID"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.chkManualDiscount)
        Me.GroupBox4.Controls.Add(Me.txtDiscountAmount)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.txtInvoiceTotal)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.txtSalesTaxTotal)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.txtFreightTotal)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txtPurchaseTotal)
        Me.GroupBox4.Location = New System.Drawing.Point(728, 588)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(302, 166)
        Me.GroupBox4.TabIndex = 29
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Totals"
        '
        'chkManualDiscount
        '
        Me.chkManualDiscount.AutoSize = True
        Me.chkManualDiscount.Location = New System.Drawing.Point(117, 137)
        Me.chkManualDiscount.Name = "chkManualDiscount"
        Me.chkManualDiscount.Size = New System.Drawing.Size(15, 14)
        Me.chkManualDiscount.TabIndex = 34
        Me.chkManualDiscount.UseVisualStyleBackColor = True
        '
        'txtDiscountAmount
        '
        Me.txtDiscountAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscountAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDiscountAmount.Location = New System.Drawing.Point(147, 132)
        Me.txtDiscountAmount.Name = "txtDiscountAmount"
        Me.txtDiscountAmount.ReadOnly = True
        Me.txtDiscountAmount.Size = New System.Drawing.Size(137, 20)
        Me.txtDiscountAmount.TabIndex = 35
        Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(14, 134)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(112, 20)
        Me.Label24.TabIndex = 85
        Me.Label24.Text = "Discount Available"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(14, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 20)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "Invoice Amount"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInvoiceTotal
        '
        Me.txtInvoiceTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceTotal.Location = New System.Drawing.Point(147, 105)
        Me.txtInvoiceTotal.Name = "txtInvoiceTotal"
        Me.txtInvoiceTotal.ReadOnly = True
        Me.txtInvoiceTotal.Size = New System.Drawing.Size(137, 20)
        Me.txtInvoiceTotal.TabIndex = 33
        Me.txtInvoiceTotal.TabStop = False
        Me.txtInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(14, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 20)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "Sales Tax"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesTaxTotal
        '
        Me.txtSalesTaxTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTaxTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesTaxTotal.Location = New System.Drawing.Point(147, 78)
        Me.txtSalesTaxTotal.Name = "txtSalesTaxTotal"
        Me.txtSalesTaxTotal.Size = New System.Drawing.Size(137, 20)
        Me.txtSalesTaxTotal.TabIndex = 32
        Me.txtSalesTaxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(14, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Freight"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFreightTotal
        '
        Me.txtFreightTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreightTotal.Location = New System.Drawing.Point(147, 51)
        Me.txtFreightTotal.Name = "txtFreightTotal"
        Me.txtFreightTotal.Size = New System.Drawing.Size(137, 20)
        Me.txtFreightTotal.TabIndex = 31
        Me.txtFreightTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(14, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 20)
        Me.Label9.TabIndex = 77
        Me.Label9.Text = "Purchase Amount"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPurchaseTotal
        '
        Me.txtPurchaseTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPurchaseTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPurchaseTotal.Location = New System.Drawing.Point(147, 24)
        Me.txtPurchaseTotal.Name = "txtPurchaseTotal"
        Me.txtPurchaseTotal.ReadOnly = True
        Me.txtPurchaseTotal.Size = New System.Drawing.Size(137, 20)
        Me.txtPurchaseTotal.TabIndex = 30
        Me.txtPurchaseTotal.TabStop = False
        Me.txtPurchaseTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdCreateRecurring
        '
        Me.cmdCreateRecurring.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCreateRecurring.ForeColor = System.Drawing.Color.Blue
        Me.cmdCreateRecurring.Location = New System.Drawing.Point(373, 771)
        Me.cmdCreateRecurring.Name = "cmdCreateRecurring"
        Me.cmdCreateRecurring.Size = New System.Drawing.Size(71, 40)
        Me.cmdCreateRecurring.TabIndex = 25
        Me.cmdCreateRecurring.Text = "Create Recurring"
        Me.cmdCreateRecurring.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.Location = New System.Drawing.Point(748, 509)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 20)
        Me.Label10.TabIndex = 95
        Me.Label10.Text = "Credit Account"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCreditAccount
        '
        Me.cboCreditAccount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCreditAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCreditAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCreditAccount.DisplayMember = "GLAccountNumber"
        Me.cboCreditAccount.Enabled = False
        Me.cboCreditAccount.FormattingEnabled = True
        Me.cboCreditAccount.Location = New System.Drawing.Point(830, 508)
        Me.cboCreditAccount.Name = "cboCreditAccount"
        Me.cboCreditAccount.Size = New System.Drawing.Size(182, 21)
        Me.cboCreditAccount.TabIndex = 92
        '
        'cboCreditDescription
        '
        Me.cboCreditDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCreditDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCreditDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCreditDescription.DisplayMember = "GLAccountShortDescription"
        Me.cboCreditDescription.Enabled = False
        Me.cboCreditDescription.FormattingEnabled = True
        Me.cboCreditDescription.Location = New System.Drawing.Point(751, 535)
        Me.cboCreditDescription.Name = "cboCreditDescription"
        Me.cboCreditDescription.Size = New System.Drawing.Size(261, 21)
        Me.cboCreditDescription.TabIndex = 93
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(20, 29)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(112, 20)
        Me.Label22.TabIndex = 85
        Me.Label22.Text = "Debit Account"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDebitAccount
        '
        Me.cboDebitAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDebitAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDebitAccount.FormattingEnabled = True
        Me.cboDebitAccount.Location = New System.Drawing.Point(102, 28)
        Me.cboDebitAccount.Name = "cboDebitAccount"
        Me.cboDebitAccount.Size = New System.Drawing.Size(182, 21)
        Me.cboDebitAccount.TabIndex = 27
        '
        'cboDebitDescription
        '
        Me.cboDebitDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDebitDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDebitDescription.FormattingEnabled = True
        Me.cboDebitDescription.Location = New System.Drawing.Point(23, 56)
        Me.cboDebitDescription.Name = "cboDebitDescription"
        Me.cboDebitDescription.Size = New System.Drawing.Size(261, 21)
        Me.cboDebitDescription.TabIndex = 28
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.cboDebitDescription)
        Me.GroupBox5.Controls.Add(Me.cboDebitAccount)
        Me.GroupBox5.Controls.Add(Me.Label22)
        Me.GroupBox5.Location = New System.Drawing.Point(728, 472)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(302, 100)
        Me.GroupBox5.TabIndex = 26
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "GL Account Information"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 155)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 20)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Check Type"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCheckType
        '
        Me.cboCheckType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCheckType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCheckType.FormattingEnabled = True
        Me.cboCheckType.Items.AddRange(New Object() {"STANDARD", "ACH", "INTERCOMPANY", "FEDEX", "OTHER"})
        Me.cboCheckType.Location = New System.Drawing.Point(123, 154)
        Me.cboCheckType.Name = "cboCheckType"
        Me.cboCheckType.Size = New System.Drawing.Size(186, 21)
        Me.cboCheckType.TabIndex = 12
        '
        'APCreateRecurringVouchers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.cmdCreateRecurring)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.cboCreditDescription)
        Me.Controls.Add(Me.cboCreditAccount)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tabLineControls)
        Me.Controls.Add(Me.dgvVoucherLines)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gpxVoucherHeader)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "APCreateRecurringVouchers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Recurring Vouchers Creation Form"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.gpxVoucherHeader.ResumeLayout(False)
        Me.gpxVoucherHeader.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvVoucherLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabLineControls.ResumeLayout(False)
        Me.tabEnterNew.ResumeLayout(False)
        Me.tabEnterNew.PerformLayout()
        Me.tabDeleteLine.ResumeLayout(False)
        Me.tabDeleteLine.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
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
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDueDate As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gpxVoucherHeader As System.Windows.Forms.GroupBox
    Friend WithEvents txtInvoiceAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtInvoiceNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboPaymentTerms As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRepetitions As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rdoBimonth As System.Windows.Forms.RadioButton
    Friend WithEvents rdoQuarterly As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSemiAnnual As System.Windows.Forms.RadioButton
    Friend WithEvents rdoMonth As System.Windows.Forms.RadioButton
    Friend WithEvents dgvVoucherLines As System.Windows.Forms.DataGridView
    Friend WithEvents VoucherNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDebitAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCreditAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForInvoiceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiverNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiverLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tabLineControls As System.Windows.Forms.TabControl
    Friend WithEvents tabEnterNew As System.Windows.Forms.TabPage
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboItemID As System.Windows.Forms.ComboBox
    Friend WithEvents txtExtendedAmount As System.Windows.Forms.TextBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents txtUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdEnterLine As System.Windows.Forms.Button
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtLongDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tabDeleteLine As System.Windows.Forms.TabPage
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents txtLinePartDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtLinePartNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboVoucherLine As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkManualDiscount As System.Windows.Forms.CheckBox
    Friend WithEvents txtDiscountAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSalesTaxTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFreightTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPurchaseTotal As System.Windows.Forms.TextBox
    Friend WithEvents cmdCreateRecurring As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents lblVendorClass As System.Windows.Forms.Label
    Friend WithEvents cboVendorClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboCreditAccount As System.Windows.Forms.ComboBox
    Friend WithEvents cboCreditDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cboDebitAccount As System.Windows.Forms.ComboBox
    Friend WithEvents cboDebitDescription As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCheckType As System.Windows.Forms.ComboBox
End Class
