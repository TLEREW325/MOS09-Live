<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class APDesignatePayables
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
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvPayables = New System.Windows.Forms.DataGridView
        Me.ReceiptOfInvoiceBatchLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.ReceiptOfInvoiceBatchLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
        Me.gpxAPHeader = New System.Windows.Forms.GroupBox
        Me.nbrDaysOutACH = New System.Windows.Forms.NumericUpDown
        Me.Label18 = New System.Windows.Forms.Label
        Me.cboVendorClass = New System.Windows.Forms.ComboBox
        Me.dtpDueDate = New System.Windows.Forms.DateTimePicker
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdSelectLines = New System.Windows.Forms.Button
        Me.cmdClearGrid = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxDesignatePayables = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdPostPayables = New System.Windows.Forms.Button
        Me.gpxTotalOpenPayables = New System.Windows.Forms.GroupBox
        Me.lblTotalOpenPayables = New System.Windows.Forms.Label
        Me.lblTotalPending = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblGrandTotal = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.grpCompanyTotals = New System.Windows.Forms.GroupBox
        Me.lblCompanyTotalRemaining = New System.Windows.Forms.Label
        Me.lblCompanyTotalPending = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblCompanyOpenPayables = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.gpxPostOff = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdPostOff = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.SelectForPayment = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DueDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OnHoldColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.CheckTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiptDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceFreightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceSalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTermsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherSourceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DeleteReferenceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WhitePaperColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Checked1099Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvPayables, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxAPHeader.SuspendLayout()
        CType(Me.nbrDaysOutACH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxDesignatePayables.SuspendLayout()
        Me.gpxTotalOpenPayables.SuspendLayout()
        Me.grpCompanyTotals.SuspendLayout()
        Me.gpxPostOff.SuspendLayout()
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
        'dgvPayables
        '
        Me.dgvPayables.AllowUserToAddRows = False
        Me.dgvPayables.AllowUserToDeleteRows = False
        Me.dgvPayables.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPayables.AutoGenerateColumns = False
        Me.dgvPayables.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvPayables.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPayables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPayables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectForPayment, Me.DivisionIDColumn, Me.VendorIDColumn, Me.PONumberColumn, Me.InvoiceDateColumn, Me.InvoiceNumberColumn, Me.InvoiceTotalColumn, Me.DueDateColumn, Me.DiscountDateColumn, Me.OnHoldColumn, Me.CheckTypeColumn, Me.CommentColumn, Me.ReceiptDateColumn, Me.ProductTotalColumn, Me.InvoiceFreightColumn, Me.InvoiceSalesTaxColumn, Me.PaymentTermsColumn, Me.DiscountAmountColumn, Me.VoucherStatusColumn, Me.VoucherSourceColumn, Me.DeleteReferenceNumberColumn, Me.VoucherNumberColumn, Me.BatchNumberColumn, Me.VendorClassColumn, Me.WhitePaperColumn, Me.Checked1099Column})
        Me.dgvPayables.DataSource = Me.ReceiptOfInvoiceBatchLineBindingSource
        Me.dgvPayables.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvPayables.Location = New System.Drawing.Point(297, 12)
        Me.dgvPayables.Name = "dgvPayables"
        Me.dgvPayables.Size = New System.Drawing.Size(833, 697)
        Me.dgvPayables.TabIndex = 13
        Me.dgvPayables.TabStop = False
        '
        'ReceiptOfInvoiceBatchLineBindingSource
        '
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataMember = "ReceiptOfInvoiceBatchLine"
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReceiptOfInvoiceBatchLineTableAdapter
        '
        Me.ReceiptOfInvoiceBatchLineTableAdapter.ClearBeforeFill = True
        '
        'gpxAPHeader
        '
        Me.gpxAPHeader.Controls.Add(Me.nbrDaysOutACH)
        Me.gpxAPHeader.Controls.Add(Me.Label18)
        Me.gpxAPHeader.Controls.Add(Me.cboVendorClass)
        Me.gpxAPHeader.Controls.Add(Me.dtpDueDate)
        Me.gpxAPHeader.Controls.Add(Me.cboDivisionID)
        Me.gpxAPHeader.Controls.Add(Me.Label7)
        Me.gpxAPHeader.Controls.Add(Me.cmdSelectLines)
        Me.gpxAPHeader.Controls.Add(Me.cmdClearGrid)
        Me.gpxAPHeader.Controls.Add(Me.Label2)
        Me.gpxAPHeader.Controls.Add(Me.Label11)
        Me.gpxAPHeader.Controls.Add(Me.Label5)
        Me.gpxAPHeader.Location = New System.Drawing.Point(29, 41)
        Me.gpxAPHeader.Name = "gpxAPHeader"
        Me.gpxAPHeader.Size = New System.Drawing.Size(259, 237)
        Me.gpxAPHeader.TabIndex = 0
        Me.gpxAPHeader.TabStop = False
        Me.gpxAPHeader.Text = "AP Invoice Selection"
        '
        'nbrDaysOutACH
        '
        Me.nbrDaysOutACH.Location = New System.Drawing.Point(150, 94)
        Me.nbrDaysOutACH.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nbrDaysOutACH.Name = "nbrDaysOutACH"
        Me.nbrDaysOutACH.Size = New System.Drawing.Size(91, 20)
        Me.nbrDaysOutACH.TabIndex = 2
        Me.nbrDaysOutACH.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(14, 94)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(130, 20)
        Me.Label18.TabIndex = 47
        Me.Label18.Text = "Days Out (ACH Only)"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorClass
        '
        Me.cboVendorClass.FormattingEnabled = True
        Me.cboVendorClass.Items.AddRange(New Object() {"American", "Canadian"})
        Me.cboVendorClass.Location = New System.Drawing.Point(89, 131)
        Me.cboVendorClass.Name = "cboVendorClass"
        Me.cboVendorClass.Size = New System.Drawing.Size(154, 21)
        Me.cboVendorClass.TabIndex = 3
        '
        'dtpDueDate
        '
        Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDueDate.Location = New System.Drawing.Point(90, 57)
        Me.dtpDueDate.Name = "dtpDueDate"
        Me.dtpDueDate.Size = New System.Drawing.Size(153, 20)
        Me.dtpDueDate.TabIndex = 1
        '
        'cboDivisionID
        '
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(90, 19)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(154, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(14, 132)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 20)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "Vendor Class"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSelectLines
        '
        Me.cmdSelectLines.Location = New System.Drawing.Point(97, 197)
        Me.cmdSelectLines.Name = "cmdSelectLines"
        Me.cmdSelectLines.Size = New System.Drawing.Size(71, 30)
        Me.cmdSelectLines.TabIndex = 4
        Me.cmdSelectLines.Text = "Select"
        Me.cmdSelectLines.UseVisualStyleBackColor = True
        '
        'cmdClearGrid
        '
        Me.cmdClearGrid.Location = New System.Drawing.Point(172, 197)
        Me.cmdClearGrid.Name = "cmdClearGrid"
        Me.cmdClearGrid.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearGrid.TabIndex = 5
        Me.cmdClearGrid.Text = "Clear All"
        Me.cmdClearGrid.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(14, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 20)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Due Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(14, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 20)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Division ID"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(14, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(227, 29)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Select Due Date and hit Select to auto-check payables."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 773)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 11
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 773)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 12
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxDesignatePayables
        '
        Me.gpxDesignatePayables.Controls.Add(Me.Label4)
        Me.gpxDesignatePayables.Controls.Add(Me.Label1)
        Me.gpxDesignatePayables.Controls.Add(Me.Label3)
        Me.gpxDesignatePayables.Controls.Add(Me.cmdPostPayables)
        Me.gpxDesignatePayables.Location = New System.Drawing.Point(29, 284)
        Me.gpxDesignatePayables.Name = "gpxDesignatePayables"
        Me.gpxDesignatePayables.Size = New System.Drawing.Size(259, 187)
        Me.gpxDesignatePayables.TabIndex = 6
        Me.gpxDesignatePayables.TabStop = False
        Me.gpxDesignatePayables.Text = "Designate Invoices to be Paid"
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(10, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(234, 38)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Designated Vouchers to be paid will disappear from the list once posted."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(10, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(243, 32)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "After selecting payables in the datagrid, you must Designate Payables to complete" & _
            " the process."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(10, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(243, 48)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Log in as Administrator to view payables by all different divisions by selecting " & _
            "the Division ID in the combo box."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPostPayables
        '
        Me.cmdPostPayables.Location = New System.Drawing.Point(173, 141)
        Me.cmdPostPayables.Name = "cmdPostPayables"
        Me.cmdPostPayables.Size = New System.Drawing.Size(71, 40)
        Me.cmdPostPayables.TabIndex = 7
        Me.cmdPostPayables.Text = "Designate Payables"
        Me.cmdPostPayables.UseVisualStyleBackColor = True
        '
        'gpxTotalOpenPayables
        '
        Me.gpxTotalOpenPayables.Controls.Add(Me.lblTotalOpenPayables)
        Me.gpxTotalOpenPayables.Controls.Add(Me.lblTotalPending)
        Me.gpxTotalOpenPayables.Controls.Add(Me.Label10)
        Me.gpxTotalOpenPayables.Controls.Add(Me.lblGrandTotal)
        Me.gpxTotalOpenPayables.Controls.Add(Me.Label8)
        Me.gpxTotalOpenPayables.Controls.Add(Me.Label6)
        Me.gpxTotalOpenPayables.Location = New System.Drawing.Point(29, 596)
        Me.gpxTotalOpenPayables.Name = "gpxTotalOpenPayables"
        Me.gpxTotalOpenPayables.Size = New System.Drawing.Size(262, 100)
        Me.gpxTotalOpenPayables.TabIndex = 7
        Me.gpxTotalOpenPayables.TabStop = False
        Me.gpxTotalOpenPayables.Text = "Division Totals"
        '
        'lblTotalOpenPayables
        '
        Me.lblTotalOpenPayables.BackColor = System.Drawing.Color.White
        Me.lblTotalOpenPayables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalOpenPayables.ForeColor = System.Drawing.Color.Red
        Me.lblTotalOpenPayables.Location = New System.Drawing.Point(116, 70)
        Me.lblTotalOpenPayables.Name = "lblTotalOpenPayables"
        Me.lblTotalOpenPayables.Size = New System.Drawing.Size(137, 20)
        Me.lblTotalOpenPayables.TabIndex = 10
        Me.lblTotalOpenPayables.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalPending
        '
        Me.lblTotalPending.BackColor = System.Drawing.Color.White
        Me.lblTotalPending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalPending.ForeColor = System.Drawing.Color.Red
        Me.lblTotalPending.Location = New System.Drawing.Point(116, 45)
        Me.lblTotalPending.Name = "lblTotalPending"
        Me.lblTotalPending.Size = New System.Drawing.Size(137, 20)
        Me.lblTotalPending.TabIndex = 9
        Me.lblTotalPending.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(172, 20)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Total Pending"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.BackColor = System.Drawing.Color.White
        Me.lblGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGrandTotal.ForeColor = System.Drawing.Color.Red
        Me.lblGrandTotal.Location = New System.Drawing.Point(116, 20)
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Size = New System.Drawing.Size(137, 20)
        Me.lblGrandTotal.TabIndex = 8
        Me.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(172, 20)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "Open Payables"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(172, 20)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Total Remaining"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpCompanyTotals
        '
        Me.grpCompanyTotals.Controls.Add(Me.lblCompanyTotalRemaining)
        Me.grpCompanyTotals.Controls.Add(Me.lblCompanyTotalPending)
        Me.grpCompanyTotals.Controls.Add(Me.Label13)
        Me.grpCompanyTotals.Controls.Add(Me.lblCompanyOpenPayables)
        Me.grpCompanyTotals.Controls.Add(Me.Label15)
        Me.grpCompanyTotals.Controls.Add(Me.Label16)
        Me.grpCompanyTotals.Location = New System.Drawing.Point(29, 712)
        Me.grpCompanyTotals.Name = "grpCompanyTotals"
        Me.grpCompanyTotals.Size = New System.Drawing.Size(262, 101)
        Me.grpCompanyTotals.TabIndex = 46
        Me.grpCompanyTotals.TabStop = False
        Me.grpCompanyTotals.Text = "Company Totals"
        '
        'lblCompanyTotalRemaining
        '
        Me.lblCompanyTotalRemaining.BackColor = System.Drawing.Color.White
        Me.lblCompanyTotalRemaining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCompanyTotalRemaining.ForeColor = System.Drawing.Color.Red
        Me.lblCompanyTotalRemaining.Location = New System.Drawing.Point(115, 70)
        Me.lblCompanyTotalRemaining.Name = "lblCompanyTotalRemaining"
        Me.lblCompanyTotalRemaining.Size = New System.Drawing.Size(138, 20)
        Me.lblCompanyTotalRemaining.TabIndex = 10
        Me.lblCompanyTotalRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCompanyTotalPending
        '
        Me.lblCompanyTotalPending.BackColor = System.Drawing.Color.White
        Me.lblCompanyTotalPending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCompanyTotalPending.ForeColor = System.Drawing.Color.Red
        Me.lblCompanyTotalPending.Location = New System.Drawing.Point(115, 45)
        Me.lblCompanyTotalPending.Name = "lblCompanyTotalPending"
        Me.lblCompanyTotalPending.Size = New System.Drawing.Size(138, 20)
        Me.lblCompanyTotalPending.TabIndex = 9
        Me.lblCompanyTotalPending.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 45)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(172, 20)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "Total Pending"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCompanyOpenPayables
        '
        Me.lblCompanyOpenPayables.BackColor = System.Drawing.Color.White
        Me.lblCompanyOpenPayables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCompanyOpenPayables.ForeColor = System.Drawing.Color.Red
        Me.lblCompanyOpenPayables.Location = New System.Drawing.Point(115, 20)
        Me.lblCompanyOpenPayables.Name = "lblCompanyOpenPayables"
        Me.lblCompanyOpenPayables.Size = New System.Drawing.Size(138, 20)
        Me.lblCompanyOpenPayables.TabIndex = 8
        Me.lblCompanyOpenPayables.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(10, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(172, 20)
        Me.Label15.TabIndex = 43
        Me.Label15.Text = "Open Payables"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(10, 70)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(172, 20)
        Me.Label16.TabIndex = 41
        Me.Label16.Text = "Total Remaining"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxPostOff
        '
        Me.gpxPostOff.Controls.Add(Me.Label9)
        Me.gpxPostOff.Controls.Add(Me.cmdPostOff)
        Me.gpxPostOff.Location = New System.Drawing.Point(29, 477)
        Me.gpxPostOff.Name = "gpxPostOff"
        Me.gpxPostOff.Size = New System.Drawing.Size(262, 113)
        Me.gpxPostOff.TabIndex = 8
        Me.gpxPostOff.TabStop = False
        Me.gpxPostOff.Text = "Post-Off Credits"
        Me.gpxPostOff.Visible = False
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(14, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(230, 41)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "Select payables to post off against a credit. Net total has to be zero."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPostOff
        '
        Me.cmdPostOff.Location = New System.Drawing.Point(172, 60)
        Me.cmdPostOff.Name = "cmdPostOff"
        Me.cmdPostOff.Size = New System.Drawing.Size(71, 40)
        Me.cmdPostOff.TabIndex = 9
        Me.cmdPostOff.Text = "Post Off"
        Me.cmdPostOff.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(297, 737)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(565, 25)
        Me.Label12.TabIndex = 48
        Me.Label12.Text = "Shaded lines with blue text are FEDEX ACH's."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(297, 762)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(565, 25)
        Me.Label14.TabIndex = 49
        Me.Label14.Text = "Shaded lines with red text are INTERCOMPANY ACH's."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Purple
        Me.Label17.Location = New System.Drawing.Point(297, 787)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(565, 25)
        Me.Label17.TabIndex = 50
        Me.Label17.Text = "Shaded lines with purple text are OTHER ACH's."
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(297, 712)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(565, 25)
        Me.Label19.TabIndex = 51
        Me.Label19.Text = "Unshaded lines with blue text are STANDARD White Paper Checks."
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SelectForPayment
        '
        Me.SelectForPayment.FalseValue = "UNSELECTED"
        Me.SelectForPayment.HeaderText = "Select"
        Me.SelectForPayment.Name = "SelectForPayment"
        Me.SelectForPayment.TrueValue = "SELECTED"
        Me.SelectForPayment.Width = 65
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        Me.DivisionIDColumn.Width = 80
        '
        'VendorIDColumn
        '
        Me.VendorIDColumn.DataPropertyName = "VendorID"
        Me.VendorIDColumn.HeaderText = "Vendor"
        Me.VendorIDColumn.Name = "VendorIDColumn"
        Me.VendorIDColumn.Width = 145
        '
        'PONumberColumn
        '
        Me.PONumberColumn.DataPropertyName = "PONumber"
        Me.PONumberColumn.HeaderText = "PO #"
        Me.PONumberColumn.Name = "PONumberColumn"
        Me.PONumberColumn.Width = 80
        '
        'InvoiceDateColumn
        '
        Me.InvoiceDateColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumn.HeaderText = "Invoice Date"
        Me.InvoiceDateColumn.Name = "InvoiceDateColumn"
        Me.InvoiceDateColumn.Width = 80
        '
        'InvoiceNumberColumn
        '
        Me.InvoiceNumberColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn.HeaderText = "Invoice #"
        Me.InvoiceNumberColumn.Name = "InvoiceNumberColumn"
        Me.InvoiceNumberColumn.Width = 90
        '
        'InvoiceTotalColumn
        '
        Me.InvoiceTotalColumn.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.InvoiceTotalColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.InvoiceTotalColumn.HeaderText = "Invoice Total"
        Me.InvoiceTotalColumn.Name = "InvoiceTotalColumn"
        Me.InvoiceTotalColumn.Width = 85
        '
        'DueDateColumn
        '
        Me.DueDateColumn.DataPropertyName = "DueDate"
        Me.DueDateColumn.HeaderText = "Due Date"
        Me.DueDateColumn.Name = "DueDateColumn"
        Me.DueDateColumn.Width = 80
        '
        'DiscountDateColumn
        '
        Me.DiscountDateColumn.DataPropertyName = "DiscountDate"
        Me.DiscountDateColumn.HeaderText = "Discount Date"
        Me.DiscountDateColumn.Name = "DiscountDateColumn"
        Me.DiscountDateColumn.Width = 80
        '
        'OnHoldColumn
        '
        Me.OnHoldColumn.DataPropertyName = "OnHold"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.NullValue = False
        Me.OnHoldColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.OnHoldColumn.FalseValue = "NO"
        Me.OnHoldColumn.HeaderText = "On Hold?"
        Me.OnHoldColumn.IndeterminateValue = "NO"
        Me.OnHoldColumn.Name = "OnHoldColumn"
        Me.OnHoldColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OnHoldColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.OnHoldColumn.TrueValue = "YES"
        Me.OnHoldColumn.Width = 65
        '
        'CheckTypeColumn
        '
        Me.CheckTypeColumn.DataPropertyName = "CheckType"
        Me.CheckTypeColumn.HeaderText = "Check Type"
        Me.CheckTypeColumn.Name = "CheckTypeColumn"
        Me.CheckTypeColumn.ReadOnly = True
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'ReceiptDateColumn
        '
        Me.ReceiptDateColumn.DataPropertyName = "ReceiptDate"
        Me.ReceiptDateColumn.HeaderText = "Receipt Date"
        Me.ReceiptDateColumn.Name = "ReceiptDateColumn"
        Me.ReceiptDateColumn.Visible = False
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        Me.ProductTotalColumn.HeaderText = "Product Total"
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        Me.ProductTotalColumn.Visible = False
        '
        'InvoiceFreightColumn
        '
        Me.InvoiceFreightColumn.DataPropertyName = "InvoiceFreight"
        Me.InvoiceFreightColumn.HeaderText = "Invoice Freight"
        Me.InvoiceFreightColumn.Name = "InvoiceFreightColumn"
        Me.InvoiceFreightColumn.Visible = False
        '
        'InvoiceSalesTaxColumn
        '
        Me.InvoiceSalesTaxColumn.DataPropertyName = "InvoiceSalesTax"
        Me.InvoiceSalesTaxColumn.HeaderText = "InvoiceSalesTax"
        Me.InvoiceSalesTaxColumn.Name = "InvoiceSalesTaxColumn"
        Me.InvoiceSalesTaxColumn.Visible = False
        '
        'PaymentTermsColumn
        '
        Me.PaymentTermsColumn.DataPropertyName = "PaymentTerms"
        Me.PaymentTermsColumn.HeaderText = "PaymentTerms"
        Me.PaymentTermsColumn.Name = "PaymentTermsColumn"
        Me.PaymentTermsColumn.Visible = False
        '
        'DiscountAmountColumn
        '
        Me.DiscountAmountColumn.DataPropertyName = "DiscountAmount"
        Me.DiscountAmountColumn.HeaderText = "DiscountAmount"
        Me.DiscountAmountColumn.Name = "DiscountAmountColumn"
        Me.DiscountAmountColumn.Visible = False
        '
        'VoucherStatusColumn
        '
        Me.VoucherStatusColumn.DataPropertyName = "VoucherStatus"
        Me.VoucherStatusColumn.HeaderText = "VoucherStatus"
        Me.VoucherStatusColumn.Name = "VoucherStatusColumn"
        Me.VoucherStatusColumn.Visible = False
        '
        'VoucherSourceColumn
        '
        Me.VoucherSourceColumn.DataPropertyName = "VoucherSource"
        Me.VoucherSourceColumn.HeaderText = "VoucherSource"
        Me.VoucherSourceColumn.Name = "VoucherSourceColumn"
        Me.VoucherSourceColumn.Visible = False
        '
        'DeleteReferenceNumberColumn
        '
        Me.DeleteReferenceNumberColumn.DataPropertyName = "DeleteReferenceNumber"
        Me.DeleteReferenceNumberColumn.HeaderText = "DeleteReferenceNumber"
        Me.DeleteReferenceNumberColumn.Name = "DeleteReferenceNumberColumn"
        Me.DeleteReferenceNumberColumn.Visible = False
        '
        'VoucherNumberColumn
        '
        Me.VoucherNumberColumn.DataPropertyName = "VoucherNumber"
        Me.VoucherNumberColumn.HeaderText = "VoucherNumber"
        Me.VoucherNumberColumn.Name = "VoucherNumberColumn"
        Me.VoucherNumberColumn.Visible = False
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "BatchNumber"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.Visible = False
        '
        'VendorClassColumn
        '
        Me.VendorClassColumn.DataPropertyName = "VendorClass"
        Me.VendorClassColumn.HeaderText = "VendorClass"
        Me.VendorClassColumn.Name = "VendorClassColumn"
        Me.VendorClassColumn.Visible = False
        '
        'WhitePaperColumn
        '
        Me.WhitePaperColumn.DataPropertyName = "WhitePaper"
        Me.WhitePaperColumn.HeaderText = "White Paper?"
        Me.WhitePaperColumn.Name = "WhitePaperColumn"
        Me.WhitePaperColumn.ReadOnly = True
        '
        'Checked1099Column
        '
        Me.Checked1099Column.DataPropertyName = "Checked1099"
        Me.Checked1099Column.HeaderText = "Checked1099"
        Me.Checked1099Column.Name = "Checked1099Column"
        Me.Checked1099Column.Visible = False
        '
        'APDesignatePayables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.gpxPostOff)
        Me.Controls.Add(Me.grpCompanyTotals)
        Me.Controls.Add(Me.gpxTotalOpenPayables)
        Me.Controls.Add(Me.gpxDesignatePayables)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxAPHeader)
        Me.Controls.Add(Me.dgvPayables)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "APDesignatePayables"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation AP Designation"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvPayables, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxAPHeader.ResumeLayout(False)
        CType(Me.nbrDaysOutACH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxDesignatePayables.ResumeLayout(False)
        Me.gpxTotalOpenPayables.ResumeLayout(False)
        Me.grpCompanyTotals.ResumeLayout(False)
        Me.gpxPostOff.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvPayables As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ReceiptOfInvoiceBatchLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceBatchLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
    Friend WithEvents gpxAPHeader As System.Windows.Forms.GroupBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdSelectLines As System.Windows.Forms.Button
    Friend WithEvents cmdClearGrid As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxDesignatePayables As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPostPayables As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gpxTotalOpenPayables As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotalOpenPayables As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPending As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblGrandTotal As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboVendorClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents grpCompanyTotals As System.Windows.Forms.GroupBox
    Friend WithEvents lblCompanyTotalRemaining As System.Windows.Forms.Label
    Friend WithEvents lblCompanyTotalPending As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblCompanyOpenPayables As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents gpxPostOff As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdPostOff As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents nbrDaysOutACH As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents SelectForPayment As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DueDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OnHoldColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CheckTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiptDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceFreightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceSalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTermsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherSourceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeleteReferenceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WhitePaperColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Checked1099Column As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
