<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewARRecurringPayment
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
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxFilters = New System.Windows.Forms.GroupBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdView = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.chkUseDates = New System.Windows.Forms.CheckBox
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker
        Me.cboInvoiceNumber = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvRecurringPaymentLineTable = New System.Windows.Forms.DataGridView
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrintSelectedCoupons = New System.Windows.Forms.Button
        Me.gpxUpdateNotifications = New System.Windows.Forms.GroupBox
        Me.cmdUpdateSelected = New System.Windows.Forms.Button
        Me.cboNotificationRecipient = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdOpenPaymentScreen = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdGreenIndicator = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.gpxFilters.SuspendLayout()
        CType(Me.dgvRecurringPaymentLineTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxUpdateNotifications.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ExitToolStripMenuItem, Me.ExitToolStripMenuItem1})
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
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Edit"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem2})
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'ExitToolStripMenuItem2
        '
        Me.ExitToolStripMenuItem2.Name = "ExitToolStripMenuItem2"
        Me.ExitToolStripMenuItem2.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem2.Text = "Exit"
        '
        'gpxFilters
        '
        Me.gpxFilters.Controls.Add(Me.cmdClear)
        Me.gpxFilters.Controls.Add(Me.cmdView)
        Me.gpxFilters.Controls.Add(Me.cboDivisionID)
        Me.gpxFilters.Controls.Add(Me.Label5)
        Me.gpxFilters.Controls.Add(Me.cboCustomerName)
        Me.gpxFilters.Controls.Add(Me.cboCustomerID)
        Me.gpxFilters.Controls.Add(Me.Label4)
        Me.gpxFilters.Controls.Add(Me.Label3)
        Me.gpxFilters.Controls.Add(Me.Label2)
        Me.gpxFilters.Controls.Add(Me.dtpEndDate)
        Me.gpxFilters.Controls.Add(Me.chkUseDates)
        Me.gpxFilters.Controls.Add(Me.dtpStartDate)
        Me.gpxFilters.Controls.Add(Me.cboInvoiceNumber)
        Me.gpxFilters.Controls.Add(Me.Label1)
        Me.gpxFilters.Location = New System.Drawing.Point(29, 41)
        Me.gpxFilters.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.gpxFilters.Name = "gpxFilters"
        Me.gpxFilters.Size = New System.Drawing.Size(300, 418)
        Me.gpxFilters.TabIndex = 1
        Me.gpxFilters.TabStop = False
        Me.gpxFilters.Text = "Filters"
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(215, 362)
        Me.cmdClear.Margin = New System.Windows.Forms.Padding(3, 10, 3, 10)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 13
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(138, 362)
        Me.cmdView.Margin = New System.Windows.Forms.Padding(3, 10, 3, 10)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 40)
        Me.cmdView.TabIndex = 12
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(86, 40)
        Me.cboDivisionID.Margin = New System.Windows.Forms.Padding(3, 10, 3, 10)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(200, 21)
        Me.cboDivisionID.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Division ID"
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(15, 189)
        Me.cboCustomerName.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(271, 21)
        Me.cboCustomerName.TabIndex = 9
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(83, 149)
        Me.cboCustomerID.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(203, 21)
        Me.cboCustomerID.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Customer ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 321)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "End Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 292)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Start Date"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(83, 317)
        Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(3, 5, 3, 10)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(203, 20)
        Me.dtpEndDate.TabIndex = 4
        '
        'chkUseDates
        '
        Me.chkUseDates.AutoSize = True
        Me.chkUseDates.Location = New System.Drawing.Point(83, 248)
        Me.chkUseDates.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.chkUseDates.Name = "chkUseDates"
        Me.chkUseDates.Size = New System.Drawing.Size(106, 17)
        Me.chkUseDates.TabIndex = 3
        Me.chkUseDates.Text = "Use Date Range"
        Me.chkUseDates.UseVisualStyleBackColor = True
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(83, 288)
        Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(3, 10, 3, 5)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(203, 20)
        Me.dtpStartDate.TabIndex = 2
        '
        'cboInvoiceNumber
        '
        Me.cboInvoiceNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInvoiceNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInvoiceNumber.FormattingEnabled = True
        Me.cboInvoiceNumber.Location = New System.Drawing.Point(86, 88)
        Me.cboInvoiceNumber.Margin = New System.Windows.Forms.Padding(3, 10, 3, 10)
        Me.cboInvoiceNumber.Name = "cboInvoiceNumber"
        Me.cboInvoiceNumber.Size = New System.Drawing.Size(200, 21)
        Me.cboInvoiceNumber.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Invoice #"
        '
        'dgvRecurringPaymentLineTable
        '
        Me.dgvRecurringPaymentLineTable.AllowUserToAddRows = False
        Me.dgvRecurringPaymentLineTable.AllowUserToDeleteRows = False
        Me.dgvRecurringPaymentLineTable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRecurringPaymentLineTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvRecurringPaymentLineTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecurringPaymentLineTable.Location = New System.Drawing.Point(346, 41)
        Me.dgvRecurringPaymentLineTable.Name = "dgvRecurringPaymentLineTable"
        Me.dgvRecurringPaymentLineTable.ReadOnly = True
        Me.dgvRecurringPaymentLineTable.Size = New System.Drawing.Size(684, 718)
        Me.dgvRecurringPaymentLineTable.TabIndex = 2
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrintSelectedCoupons
        '
        Me.cmdPrintSelectedCoupons.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintSelectedCoupons.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrintSelectedCoupons.Name = "cmdPrintSelectedCoupons"
        Me.cmdPrintSelectedCoupons.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintSelectedCoupons.TabIndex = 15
        Me.cmdPrintSelectedCoupons.Text = "Print Selected"
        Me.cmdPrintSelectedCoupons.UseVisualStyleBackColor = True
        '
        'gpxUpdateNotifications
        '
        Me.gpxUpdateNotifications.Controls.Add(Me.cmdUpdateSelected)
        Me.gpxUpdateNotifications.Controls.Add(Me.cboNotificationRecipient)
        Me.gpxUpdateNotifications.Controls.Add(Me.Label6)
        Me.gpxUpdateNotifications.Location = New System.Drawing.Point(12, 687)
        Me.gpxUpdateNotifications.Name = "gpxUpdateNotifications"
        Me.gpxUpdateNotifications.Size = New System.Drawing.Size(317, 127)
        Me.gpxUpdateNotifications.TabIndex = 16
        Me.gpxUpdateNotifications.TabStop = False
        Me.gpxUpdateNotifications.Text = "Update Selected"
        '
        'cmdUpdateSelected
        '
        Me.cmdUpdateSelected.Location = New System.Drawing.Point(235, 71)
        Me.cmdUpdateSelected.Margin = New System.Windows.Forms.Padding(3, 10, 3, 10)
        Me.cmdUpdateSelected.Name = "cmdUpdateSelected"
        Me.cmdUpdateSelected.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateSelected.TabIndex = 14
        Me.cmdUpdateSelected.Text = "Update Selected"
        Me.cmdUpdateSelected.UseVisualStyleBackColor = True
        '
        'cboNotificationRecipient
        '
        Me.cboNotificationRecipient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboNotificationRecipient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboNotificationRecipient.FormattingEnabled = True
        Me.cboNotificationRecipient.Location = New System.Drawing.Point(103, 37)
        Me.cboNotificationRecipient.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cboNotificationRecipient.Name = "cboNotificationRecipient"
        Me.cboNotificationRecipient.Size = New System.Drawing.Size(203, 21)
        Me.cboNotificationRecipient.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Notif. Recipient"
        '
        'cmdOpenPaymentScreen
        '
        Me.cmdOpenPaymentScreen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenPaymentScreen.Location = New System.Drawing.Point(805, 771)
        Me.cmdOpenPaymentScreen.Name = "cmdOpenPaymentScreen"
        Me.cmdOpenPaymentScreen.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenPaymentScreen.TabIndex = 17
        Me.cmdOpenPaymentScreen.Text = "Open Payment"
        Me.cmdOpenPaymentScreen.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(377, 777)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(226, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "- Indicates it has been printed from notification."
        '
        'cmdGreenIndicator
        '
        Me.cmdGreenIndicator.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdGreenIndicator.BackColor = System.Drawing.Color.LightGreen
        Me.cmdGreenIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGreenIndicator.Location = New System.Drawing.Point(346, 779)
        Me.cmdGreenIndicator.Name = "cmdGreenIndicator"
        Me.cmdGreenIndicator.Size = New System.Drawing.Size(25, 25)
        Me.cmdGreenIndicator.TabIndex = 27
        Me.cmdGreenIndicator.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(604, 779)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(175, 35)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Double click an item in the datagrid to view the payment coupon"
        '
        'ViewARRecurringPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmdGreenIndicator)
        Me.Controls.Add(Me.cmdOpenPaymentScreen)
        Me.Controls.Add(Me.gpxUpdateNotifications)
        Me.Controls.Add(Me.cmdPrintSelectedCoupons)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvRecurringPaymentLineTable)
        Me.Controls.Add(Me.gpxFilters)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "ViewARRecurringPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View AR Recurring Payment"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxFilters.ResumeLayout(False)
        Me.gpxFilters.PerformLayout()
        CType(Me.dgvRecurringPaymentLineTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxUpdateNotifications.ResumeLayout(False)
        Me.gpxUpdateNotifications.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxFilters As System.Windows.Forms.GroupBox
    Friend WithEvents dgvRecurringPaymentLineTable As System.Windows.Forms.DataGridView
    Friend WithEvents cboInvoiceNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkUseDates As System.Windows.Forms.CheckBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrintSelectedCoupons As System.Windows.Forms.Button
    Friend WithEvents gpxUpdateNotifications As System.Windows.Forms.GroupBox
    Friend WithEvents cboNotificationRecipient As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdUpdateSelected As System.Windows.Forms.Button
    Friend WithEvents cmdOpenPaymentScreen As System.Windows.Forms.Button
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdGreenIndicator As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
