<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ARRecurringPayment
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
        Me.FielToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvPayments = New System.Windows.Forms.DataGridView
        Me.gpxInvoiceData = New System.Windows.Forms.GroupBox
        Me.lblRemainingTotal = New System.Windows.Forms.TextBox
        Me.lblRemainingTotalLabel = New System.Windows.Forms.Label
        Me.lblPaymentsApplied = New System.Windows.Forms.Label
        Me.lblPaymentsAppliedLabel = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblInvoiceTotal = New System.Windows.Forms.Label
        Me.lblCustomerName = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblCustomerID = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboInvoiceNumber = New System.Windows.Forms.ComboBox
        Me.lblInvoiceNumber = New System.Windows.Forms.Label
        Me.chkFlatFee = New System.Windows.Forms.CheckBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdGenerateRecurringPayments = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.chkPercent = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtPaymentInterest = New System.Windows.Forms.TextBox
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker
        Me.lblInitialDateLabel = New System.Windows.Forms.Label
        Me.lblPaymentsLabel = New System.Windows.Forms.Label
        Me.txtPaymentMonths = New System.Windows.Forms.TextBox
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrintPaymentCoupon = New System.Windows.Forms.Button
        Me.cmdPrintAllPaymentCoupons = New System.Windows.Forms.Button
        Me.dgvInvoiceLines = New System.Windows.Forms.DataGridView
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblMonthlyPayment = New System.Windows.Forms.Label
        Me.lblMonthlyPaymentLabel = New System.Windows.Forms.Label
        Me.lblTotalMonthlyPayment = New System.Windows.Forms.Label
        Me.lblTotalMonthlyPaymentLabel = New System.Windows.Forms.Label
        Me.cmdDeleteSelected = New System.Windows.Forms.Button
        Me.gpxPaymentData = New System.Windows.Forms.GroupBox
        Me.txtNotificationLeadTime = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cboNotificationRecipient = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdGreenIndicator = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.pnlNewDateTime = New System.Windows.Forms.Panel
        Me.lblRowNumber = New System.Windows.Forms.Label
        Me.dtpNotificationTime = New System.Windows.Forms.DateTimePicker
        Me.lblNotificationTime = New System.Windows.Forms.Label
        Me.dtpNotificationDate = New System.Windows.Forms.DateTimePicker
        Me.lblNotificationDate = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxInvoiceData.SuspendLayout()
        CType(Me.dgvInvoiceLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxPaymentData.SuspendLayout()
        Me.pnlNewDateTime.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FielToolStripMenuItem, Me.EditToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FielToolStripMenuItem
        '
        Me.FielToolStripMenuItem.Name = "FielToolStripMenuItem"
        Me.FielToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FielToolStripMenuItem.Text = "File"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'dgvPayments
        '
        Me.dgvPayments.AllowUserToAddRows = False
        Me.dgvPayments.AllowUserToDeleteRows = False
        Me.dgvPayments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPayments.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPayments.Location = New System.Drawing.Point(355, 362)
        Me.dgvPayments.Name = "dgvPayments"
        Me.dgvPayments.Size = New System.Drawing.Size(775, 385)
        Me.dgvPayments.TabIndex = 1
        '
        'gpxInvoiceData
        '
        Me.gpxInvoiceData.Controls.Add(Me.lblRemainingTotal)
        Me.gpxInvoiceData.Controls.Add(Me.lblRemainingTotalLabel)
        Me.gpxInvoiceData.Controls.Add(Me.lblPaymentsApplied)
        Me.gpxInvoiceData.Controls.Add(Me.lblPaymentsAppliedLabel)
        Me.gpxInvoiceData.Controls.Add(Me.cboDivisionID)
        Me.gpxInvoiceData.Controls.Add(Me.Label8)
        Me.gpxInvoiceData.Controls.Add(Me.lblInvoiceTotal)
        Me.gpxInvoiceData.Controls.Add(Me.lblCustomerName)
        Me.gpxInvoiceData.Controls.Add(Me.Label5)
        Me.gpxInvoiceData.Controls.Add(Me.lblCustomerID)
        Me.gpxInvoiceData.Controls.Add(Me.Label3)
        Me.gpxInvoiceData.Controls.Add(Me.cboInvoiceNumber)
        Me.gpxInvoiceData.Controls.Add(Me.lblInvoiceNumber)
        Me.gpxInvoiceData.Location = New System.Drawing.Point(29, 41)
        Me.gpxInvoiceData.Name = "gpxInvoiceData"
        Me.gpxInvoiceData.Size = New System.Drawing.Size(300, 297)
        Me.gpxInvoiceData.TabIndex = 2
        Me.gpxInvoiceData.TabStop = False
        Me.gpxInvoiceData.Text = "Invoice Data"
        '
        'lblRemainingTotal
        '
        Me.lblRemainingTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRemainingTotal.Location = New System.Drawing.Point(162, 257)
        Me.lblRemainingTotal.Margin = New System.Windows.Forms.Padding(7)
        Me.lblRemainingTotal.Name = "lblRemainingTotal"
        Me.lblRemainingTotal.Size = New System.Drawing.Size(127, 20)
        Me.lblRemainingTotal.TabIndex = 30
        Me.lblRemainingTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRemainingTotalLabel
        '
        Me.lblRemainingTotalLabel.AutoSize = True
        Me.lblRemainingTotalLabel.Location = New System.Drawing.Point(6, 257)
        Me.lblRemainingTotalLabel.Name = "lblRemainingTotalLabel"
        Me.lblRemainingTotalLabel.Size = New System.Drawing.Size(84, 13)
        Me.lblRemainingTotalLabel.TabIndex = 25
        Me.lblRemainingTotalLabel.Text = "Remaining Total"
        '
        'lblPaymentsApplied
        '
        Me.lblPaymentsApplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaymentsApplied.Location = New System.Drawing.Point(162, 217)
        Me.lblPaymentsApplied.Margin = New System.Windows.Forms.Padding(7)
        Me.lblPaymentsApplied.Name = "lblPaymentsApplied"
        Me.lblPaymentsApplied.Size = New System.Drawing.Size(127, 21)
        Me.lblPaymentsApplied.TabIndex = 24
        Me.lblPaymentsApplied.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPaymentsAppliedLabel
        '
        Me.lblPaymentsAppliedLabel.AutoSize = True
        Me.lblPaymentsAppliedLabel.Location = New System.Drawing.Point(6, 217)
        Me.lblPaymentsAppliedLabel.Name = "lblPaymentsAppliedLabel"
        Me.lblPaymentsAppliedLabel.Size = New System.Drawing.Size(91, 13)
        Me.lblPaymentsAppliedLabel.TabIndex = 23
        Me.lblPaymentsAppliedLabel.Text = "Payments Applied"
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(141, 24)
        Me.cboDivisionID.Margin = New System.Windows.Forms.Padding(7)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(148, 21)
        Me.cboDivisionID.TabIndex = 18
        Me.cboDivisionID.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Division ID"
        '
        'lblInvoiceTotal
        '
        Me.lblInvoiceTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInvoiceTotal.Location = New System.Drawing.Point(162, 177)
        Me.lblInvoiceTotal.Margin = New System.Windows.Forms.Padding(7)
        Me.lblInvoiceTotal.Name = "lblInvoiceTotal"
        Me.lblInvoiceTotal.Size = New System.Drawing.Size(127, 21)
        Me.lblInvoiceTotal.TabIndex = 8
        Me.lblInvoiceTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCustomerName
        '
        Me.lblCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCustomerName.Location = New System.Drawing.Point(9, 137)
        Me.lblCustomerName.Margin = New System.Windows.Forms.Padding(7, 2, 7, 7)
        Me.lblCustomerName.Name = "lblCustomerName"
        Me.lblCustomerName.Size = New System.Drawing.Size(280, 21)
        Me.lblCustomerName.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Invoice Total"
        '
        'lblCustomerID
        '
        Me.lblCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCustomerID.Location = New System.Drawing.Point(81, 103)
        Me.lblCustomerID.Margin = New System.Windows.Forms.Padding(7, 7, 7, 2)
        Me.lblCustomerID.Name = "lblCustomerID"
        Me.lblCustomerID.Size = New System.Drawing.Size(208, 21)
        Me.lblCustomerID.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Customer ID"
        '
        'cboInvoiceNumber
        '
        Me.cboInvoiceNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInvoiceNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInvoiceNumber.FormattingEnabled = True
        Me.cboInvoiceNumber.Location = New System.Drawing.Point(141, 59)
        Me.cboInvoiceNumber.Margin = New System.Windows.Forms.Padding(7)
        Me.cboInvoiceNumber.Name = "cboInvoiceNumber"
        Me.cboInvoiceNumber.Size = New System.Drawing.Size(148, 21)
        Me.cboInvoiceNumber.TabIndex = 0
        '
        'lblInvoiceNumber
        '
        Me.lblInvoiceNumber.AutoSize = True
        Me.lblInvoiceNumber.Location = New System.Drawing.Point(6, 62)
        Me.lblInvoiceNumber.Name = "lblInvoiceNumber"
        Me.lblInvoiceNumber.Size = New System.Drawing.Size(82, 13)
        Me.lblInvoiceNumber.TabIndex = 0
        Me.lblInvoiceNumber.Text = "Invoice Number"
        '
        'chkFlatFee
        '
        Me.chkFlatFee.AutoSize = True
        Me.chkFlatFee.Location = New System.Drawing.Point(162, 150)
        Me.chkFlatFee.Name = "chkFlatFee"
        Me.chkFlatFee.Size = New System.Drawing.Size(127, 17)
        Me.chkFlatFee.TabIndex = 4
        Me.chkFlatFee.Text = "Flat Fee Per Payment"
        Me.chkFlatFee.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(218, 385)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 8
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdGenerateRecurringPayments
        '
        Me.cmdGenerateRecurringPayments.Location = New System.Drawing.Point(141, 385)
        Me.cmdGenerateRecurringPayments.Name = "cmdGenerateRecurringPayments"
        Me.cmdGenerateRecurringPayments.Size = New System.Drawing.Size(71, 40)
        Me.cmdGenerateRecurringPayments.TabIndex = 7
        Me.cmdGenerateRecurringPayments.Text = "Add Payments"
        Me.cmdGenerateRecurringPayments.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(6, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Ex. 25% = 0.25"
        '
        'chkPercent
        '
        Me.chkPercent.AutoSize = True
        Me.chkPercent.Checked = True
        Me.chkPercent.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPercent.Location = New System.Drawing.Point(162, 128)
        Me.chkPercent.Name = "chkPercent"
        Me.chkPercent.Size = New System.Drawing.Size(63, 17)
        Me.chkPercent.TabIndex = 3
        Me.chkPercent.Text = "Percent"
        Me.chkPercent.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Payment Interest"
        '
        'txtPaymentInterest
        '
        Me.txtPaymentInterest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaymentInterest.Location = New System.Drawing.Point(162, 98)
        Me.txtPaymentInterest.Margin = New System.Windows.Forms.Padding(7)
        Me.txtPaymentInterest.Name = "txtPaymentInterest"
        Me.txtPaymentInterest.Size = New System.Drawing.Size(127, 20)
        Me.txtPaymentInterest.TabIndex = 2
        Me.txtPaymentInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(141, 24)
        Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(7)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(148, 20)
        Me.dtpStartDate.TabIndex = 2
        '
        'lblInitialDateLabel
        '
        Me.lblInitialDateLabel.AutoSize = True
        Me.lblInitialDateLabel.Location = New System.Drawing.Point(6, 30)
        Me.lblInitialDateLabel.Name = "lblInitialDateLabel"
        Me.lblInitialDateLabel.Size = New System.Drawing.Size(101, 13)
        Me.lblInitialDateLabel.TabIndex = 11
        Me.lblInitialDateLabel.Text = "Initial Payment Date"
        '
        'lblPaymentsLabel
        '
        Me.lblPaymentsLabel.AutoSize = True
        Me.lblPaymentsLabel.Location = New System.Drawing.Point(6, 64)
        Me.lblPaymentsLabel.Name = "lblPaymentsLabel"
        Me.lblPaymentsLabel.Size = New System.Drawing.Size(86, 13)
        Me.lblPaymentsLabel.TabIndex = 10
        Me.lblPaymentsLabel.Text = "Payment Months"
        '
        'txtPaymentMonths
        '
        Me.txtPaymentMonths.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaymentMonths.Location = New System.Drawing.Point(162, 64)
        Me.txtPaymentMonths.Margin = New System.Windows.Forms.Padding(7)
        Me.txtPaymentMonths.Name = "txtPaymentMonths"
        Me.txtPaymentMonths.Size = New System.Drawing.Size(127, 20)
        Me.txtPaymentMonths.TabIndex = 1
        Me.txtPaymentMonths.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 18
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrintPaymentCoupon
        '
        Me.cmdPrintPaymentCoupon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintPaymentCoupon.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrintPaymentCoupon.Name = "cmdPrintPaymentCoupon"
        Me.cmdPrintPaymentCoupon.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintPaymentCoupon.TabIndex = 19
        Me.cmdPrintPaymentCoupon.Text = "Print Selected"
        Me.cmdPrintPaymentCoupon.UseVisualStyleBackColor = True
        '
        'cmdPrintAllPaymentCoupons
        '
        Me.cmdPrintAllPaymentCoupons.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintAllPaymentCoupons.Location = New System.Drawing.Point(905, 771)
        Me.cmdPrintAllPaymentCoupons.Name = "cmdPrintAllPaymentCoupons"
        Me.cmdPrintAllPaymentCoupons.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintAllPaymentCoupons.TabIndex = 20
        Me.cmdPrintAllPaymentCoupons.Text = "Print All Coupons"
        Me.cmdPrintAllPaymentCoupons.UseVisualStyleBackColor = True
        '
        'dgvInvoiceLines
        '
        Me.dgvInvoiceLines.AllowUserToAddRows = False
        Me.dgvInvoiceLines.AllowUserToDeleteRows = False
        Me.dgvInvoiceLines.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInvoiceLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInvoiceLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceLines.Location = New System.Drawing.Point(355, 51)
        Me.dgvInvoiceLines.Name = "dgvInvoiceLines"
        Me.dgvInvoiceLines.ReadOnly = True
        Me.dgvInvoiceLines.Size = New System.Drawing.Size(775, 227)
        Me.dgvInvoiceLines.TabIndex = 21
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(361, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 16)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Invoice Lines"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(361, 343)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 16)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Payments"
        '
        'lblMonthlyPayment
        '
        Me.lblMonthlyPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMonthlyPayment.Location = New System.Drawing.Point(162, 178)
        Me.lblMonthlyPayment.Margin = New System.Windows.Forms.Padding(7)
        Me.lblMonthlyPayment.Name = "lblMonthlyPayment"
        Me.lblMonthlyPayment.Size = New System.Drawing.Size(127, 21)
        Me.lblMonthlyPayment.TabIndex = 20
        Me.lblMonthlyPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMonthlyPaymentLabel
        '
        Me.lblMonthlyPaymentLabel.AutoSize = True
        Me.lblMonthlyPaymentLabel.Location = New System.Drawing.Point(6, 182)
        Me.lblMonthlyPaymentLabel.Name = "lblMonthlyPaymentLabel"
        Me.lblMonthlyPaymentLabel.Size = New System.Drawing.Size(115, 13)
        Me.lblMonthlyPaymentLabel.TabIndex = 19
        Me.lblMonthlyPaymentLabel.Text = "Initial Monthly Payment"
        '
        'lblTotalMonthlyPayment
        '
        Me.lblTotalMonthlyPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalMonthlyPayment.Location = New System.Drawing.Point(162, 213)
        Me.lblTotalMonthlyPayment.Margin = New System.Windows.Forms.Padding(7)
        Me.lblTotalMonthlyPayment.Name = "lblTotalMonthlyPayment"
        Me.lblTotalMonthlyPayment.Size = New System.Drawing.Size(127, 21)
        Me.lblTotalMonthlyPayment.TabIndex = 22
        Me.lblTotalMonthlyPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalMonthlyPaymentLabel
        '
        Me.lblTotalMonthlyPaymentLabel.AutoSize = True
        Me.lblTotalMonthlyPaymentLabel.Location = New System.Drawing.Point(6, 213)
        Me.lblTotalMonthlyPaymentLabel.Name = "lblTotalMonthlyPaymentLabel"
        Me.lblTotalMonthlyPaymentLabel.Size = New System.Drawing.Size(115, 13)
        Me.lblTotalMonthlyPaymentLabel.TabIndex = 21
        Me.lblTotalMonthlyPaymentLabel.Text = "Total Monthly Payment"
        '
        'cmdDeleteSelected
        '
        Me.cmdDeleteSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteSelected.Location = New System.Drawing.Point(828, 771)
        Me.cmdDeleteSelected.Name = "cmdDeleteSelected"
        Me.cmdDeleteSelected.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteSelected.TabIndex = 23
        Me.cmdDeleteSelected.Text = "Delete Selected"
        Me.cmdDeleteSelected.UseVisualStyleBackColor = True
        '
        'gpxPaymentData
        '
        Me.gpxPaymentData.Controls.Add(Me.txtNotificationLeadTime)
        Me.gpxPaymentData.Controls.Add(Me.Label11)
        Me.gpxPaymentData.Controls.Add(Me.cboNotificationRecipient)
        Me.gpxPaymentData.Controls.Add(Me.dtpStartDate)
        Me.gpxPaymentData.Controls.Add(Me.Label4)
        Me.gpxPaymentData.Controls.Add(Me.txtPaymentMonths)
        Me.gpxPaymentData.Controls.Add(Me.lblPaymentsLabel)
        Me.gpxPaymentData.Controls.Add(Me.lblInitialDateLabel)
        Me.gpxPaymentData.Controls.Add(Me.lblTotalMonthlyPayment)
        Me.gpxPaymentData.Controls.Add(Me.txtPaymentInterest)
        Me.gpxPaymentData.Controls.Add(Me.lblTotalMonthlyPaymentLabel)
        Me.gpxPaymentData.Controls.Add(Me.Label6)
        Me.gpxPaymentData.Controls.Add(Me.lblMonthlyPayment)
        Me.gpxPaymentData.Controls.Add(Me.chkPercent)
        Me.gpxPaymentData.Controls.Add(Me.lblMonthlyPaymentLabel)
        Me.gpxPaymentData.Controls.Add(Me.Label7)
        Me.gpxPaymentData.Controls.Add(Me.cmdGenerateRecurringPayments)
        Me.gpxPaymentData.Controls.Add(Me.cmdClear)
        Me.gpxPaymentData.Controls.Add(Me.chkFlatFee)
        Me.gpxPaymentData.Location = New System.Drawing.Point(29, 374)
        Me.gpxPaymentData.Name = "gpxPaymentData"
        Me.gpxPaymentData.Size = New System.Drawing.Size(300, 437)
        Me.gpxPaymentData.TabIndex = 24
        Me.gpxPaymentData.TabStop = False
        Me.gpxPaymentData.Text = "Payment"
        '
        'txtNotificationLeadTime
        '
        Me.txtNotificationLeadTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotificationLeadTime.Location = New System.Drawing.Point(162, 264)
        Me.txtNotificationLeadTime.Margin = New System.Windows.Forms.Padding(7)
        Me.txtNotificationLeadTime.Name = "txtNotificationLeadTime"
        Me.txtNotificationLeadTime.Size = New System.Drawing.Size(127, 20)
        Me.txtNotificationLeadTime.TabIndex = 6
        Me.txtNotificationLeadTime.Text = "5"
        Me.txtNotificationLeadTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 267)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(146, 13)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Notification Lead Time (Days)"
        '
        'cboNotificationRecipient
        '
        Me.cboNotificationRecipient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboNotificationRecipient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboNotificationRecipient.FormattingEnabled = True
        Me.cboNotificationRecipient.Location = New System.Drawing.Point(10, 324)
        Me.cboNotificationRecipient.Margin = New System.Windows.Forms.Padding(7)
        Me.cboNotificationRecipient.Name = "cboNotificationRecipient"
        Me.cboNotificationRecipient.Size = New System.Drawing.Size(279, 21)
        Me.cboNotificationRecipient.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 304)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Notification Recipient"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(428, 759)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(267, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Changes made in the Datagrid are automatically saved."
        '
        'cmdGreenIndicator
        '
        Me.cmdGreenIndicator.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdGreenIndicator.BackColor = System.Drawing.Color.LightGreen
        Me.cmdGreenIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGreenIndicator.Location = New System.Drawing.Point(431, 786)
        Me.cmdGreenIndicator.Name = "cmdGreenIndicator"
        Me.cmdGreenIndicator.Size = New System.Drawing.Size(25, 25)
        Me.cmdGreenIndicator.TabIndex = 25
        Me.cmdGreenIndicator.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(462, 792)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(226, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "- Indicates it has been printed from notification."
        '
        'pnlNewDateTime
        '
        Me.pnlNewDateTime.Controls.Add(Me.lblRowNumber)
        Me.pnlNewDateTime.Controls.Add(Me.dtpNotificationTime)
        Me.pnlNewDateTime.Controls.Add(Me.lblNotificationTime)
        Me.pnlNewDateTime.Controls.Add(Me.dtpNotificationDate)
        Me.pnlNewDateTime.Controls.Add(Me.lblNotificationDate)
        Me.pnlNewDateTime.Location = New System.Drawing.Point(517, 513)
        Me.pnlNewDateTime.Name = "pnlNewDateTime"
        Me.pnlNewDateTime.Size = New System.Drawing.Size(200, 111)
        Me.pnlNewDateTime.TabIndex = 27
        Me.pnlNewDateTime.Visible = False
        '
        'lblRowNumber
        '
        Me.lblRowNumber.AutoSize = True
        Me.lblRowNumber.Location = New System.Drawing.Point(136, 14)
        Me.lblRowNumber.Name = "lblRowNumber"
        Me.lblRowNumber.Size = New System.Drawing.Size(0, 13)
        Me.lblRowNumber.TabIndex = 33
        Me.lblRowNumber.Visible = False
        '
        'dtpNotificationTime
        '
        Me.dtpNotificationTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpNotificationTime.Location = New System.Drawing.Point(47, 81)
        Me.dtpNotificationTime.Margin = New System.Windows.Forms.Padding(7)
        Me.dtpNotificationTime.Name = "dtpNotificationTime"
        Me.dtpNotificationTime.ShowUpDown = True
        Me.dtpNotificationTime.Size = New System.Drawing.Size(131, 20)
        Me.dtpNotificationTime.TabIndex = 32
        '
        'lblNotificationTime
        '
        Me.lblNotificationTime.AutoSize = True
        Me.lblNotificationTime.Location = New System.Drawing.Point(16, 61)
        Me.lblNotificationTime.Name = "lblNotificationTime"
        Me.lblNotificationTime.Size = New System.Drawing.Size(86, 13)
        Me.lblNotificationTime.TabIndex = 31
        Me.lblNotificationTime.Text = "Notification Time"
        '
        'dtpNotificationDate
        '
        Me.dtpNotificationDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNotificationDate.Location = New System.Drawing.Point(47, 34)
        Me.dtpNotificationDate.Margin = New System.Windows.Forms.Padding(7)
        Me.dtpNotificationDate.Name = "dtpNotificationDate"
        Me.dtpNotificationDate.Size = New System.Drawing.Size(131, 20)
        Me.dtpNotificationDate.TabIndex = 30
        '
        'lblNotificationDate
        '
        Me.lblNotificationDate.AutoSize = True
        Me.lblNotificationDate.Location = New System.Drawing.Point(16, 14)
        Me.lblNotificationDate.Name = "lblNotificationDate"
        Me.lblNotificationDate.Size = New System.Drawing.Size(86, 13)
        Me.lblNotificationDate.TabIndex = 29
        Me.lblNotificationDate.Text = "Notification Date"
        '
        'ARRecurringPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.pnlNewDateTime)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdGreenIndicator)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gpxPaymentData)
        Me.Controls.Add(Me.cmdDeleteSelected)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dgvInvoiceLines)
        Me.Controls.Add(Me.cmdPrintAllPaymentCoupons)
        Me.Controls.Add(Me.cmdPrintPaymentCoupon)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxInvoiceData)
        Me.Controls.Add(Me.dgvPayments)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ARRecurringPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AR Recurring Payment"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvPayments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxInvoiceData.ResumeLayout(False)
        Me.gpxInvoiceData.PerformLayout()
        CType(Me.dgvInvoiceLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxPaymentData.ResumeLayout(False)
        Me.gpxPaymentData.PerformLayout()
        Me.pnlNewDateTime.ResumeLayout(False)
        Me.pnlNewDateTime.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FielToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvPayments As System.Windows.Forms.DataGridView
    Friend WithEvents gpxInvoiceData As System.Windows.Forms.GroupBox
    Friend WithEvents lblInvoiceNumber As System.Windows.Forms.Label
    Friend WithEvents cboInvoiceNumber As System.Windows.Forms.ComboBox
    Friend WithEvents lblCustomerName As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCustomerID As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblInitialDateLabel As System.Windows.Forms.Label
    Friend WithEvents lblPaymentsLabel As System.Windows.Forms.Label
    Friend WithEvents txtPaymentMonths As System.Windows.Forms.TextBox
    Friend WithEvents lblInvoiceTotal As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPaymentInterest As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkPercent As System.Windows.Forms.CheckBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdGenerateRecurringPayments As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents chkFlatFee As System.Windows.Forms.CheckBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintPaymentCoupon As System.Windows.Forms.Button
    Friend WithEvents cmdPrintAllPaymentCoupons As System.Windows.Forms.Button
    Friend WithEvents dgvInvoiceLines As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblMonthlyPayment As System.Windows.Forms.Label
    Friend WithEvents lblMonthlyPaymentLabel As System.Windows.Forms.Label
    Friend WithEvents lblTotalMonthlyPayment As System.Windows.Forms.Label
    Friend WithEvents lblTotalMonthlyPaymentLabel As System.Windows.Forms.Label
    Friend WithEvents lblRemainingTotalLabel As System.Windows.Forms.Label
    Friend WithEvents lblPaymentsApplied As System.Windows.Forms.Label
    Friend WithEvents lblPaymentsAppliedLabel As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteSelected As System.Windows.Forms.Button
    Friend WithEvents gpxPaymentData As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdGreenIndicator As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboNotificationRecipient As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlNewDateTime As System.Windows.Forms.Panel
    Friend WithEvents lblNotificationTime As System.Windows.Forms.Label
    Friend WithEvents dtpNotificationDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNotificationDate As System.Windows.Forms.Label
    Friend WithEvents dtpNotificationTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRowNumber As System.Windows.Forms.Label
    Friend WithEvents txtNotificationLeadTime As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblRemainingTotal As System.Windows.Forms.TextBox
End Class
