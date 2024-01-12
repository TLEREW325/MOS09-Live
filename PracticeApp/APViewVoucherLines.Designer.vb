<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class APViewVoucherLines
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gpxShipmentDetails = New System.Windows.Forms.GroupBox
        Me.cboCheckType = New System.Windows.Forms.ComboBox
        Me.chkWhitePaper = New System.Windows.Forms.CheckBox
        Me.chkChangePostDate = New System.Windows.Forms.CheckBox
        Me.cboVendorClass = New System.Windows.Forms.ComboBox
        Me.VendorClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtBatchNumber = New System.Windows.Forms.TextBox
        Me.txtPONumber = New System.Windows.Forms.TextBox
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker
        Me.dtpDiscountDate = New System.Windows.Forms.DateTimePicker
        Me.dtpReceiptDate = New System.Windows.Forms.DateTimePicker
        Me.dtpDueDate = New System.Windows.Forms.DateTimePicker
        Me.cboPaymentTerms = New System.Windows.Forms.ComboBox
        Me.PaymentTermsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.txtInvoiceNumber = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboVoucherNumber = New System.Windows.Forms.ComboBox
        Me.ReceiptOfInvoiceBatchLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblVoucherSource = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblVoucherStatus = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveVoucherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintVoucherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.ReceiptOfInvoiceBatchLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
        Me.FKReceiptOfInvoiceVoucherLinesReceiptOfInvoiceVoucherLinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReceiptOfInvoiceVoucherLinesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceVoucherLinesTableAdapter
        Me.dgvVoucherLines = New System.Windows.Forms.DataGridView
        Me.VoucherNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLDebitAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLCreditAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectForInvoiceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiverNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiverLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiptOfInvoiceVoucherLinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.PaymentTermsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PaymentTermsTableAdapter
        Me.Note = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdReverse = New System.Windows.Forms.Button
        Me.cmdPost = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtDiscountAmount = New System.Windows.Forms.TextBox
        Me.txtInvoiceTotal = New System.Windows.Forms.TextBox
        Me.txtSalesTax = New System.Windows.Forms.TextBox
        Me.txtFreight = New System.Windows.Forms.TextBox
        Me.txtProductTotal = New System.Windows.Forms.TextBox
        Me.cmdClearForm = New System.Windows.Forms.Button
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.VendorClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorClassTableAdapter
        Me.VendorReturnLineQueryTableAdapter1 = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorReturnLineQueryTableAdapter
        Me.gpxShipmentDetails.SuspendLayout()
        CType(Me.VendorClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymentTermsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.FKReceiptOfInvoiceVoucherLinesReceiptOfInvoiceVoucherLinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvVoucherLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptOfInvoiceVoucherLinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Note.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpxShipmentDetails
        '
        Me.gpxShipmentDetails.Controls.Add(Me.cboCheckType)
        Me.gpxShipmentDetails.Controls.Add(Me.chkWhitePaper)
        Me.gpxShipmentDetails.Controls.Add(Me.chkChangePostDate)
        Me.gpxShipmentDetails.Controls.Add(Me.cboVendorClass)
        Me.gpxShipmentDetails.Controls.Add(Me.Label13)
        Me.gpxShipmentDetails.Controls.Add(Me.txtBatchNumber)
        Me.gpxShipmentDetails.Controls.Add(Me.txtPONumber)
        Me.gpxShipmentDetails.Controls.Add(Me.txtVendorName)
        Me.gpxShipmentDetails.Controls.Add(Me.cboVendorID)
        Me.gpxShipmentDetails.Controls.Add(Me.dtpInvoiceDate)
        Me.gpxShipmentDetails.Controls.Add(Me.dtpDiscountDate)
        Me.gpxShipmentDetails.Controls.Add(Me.dtpReceiptDate)
        Me.gpxShipmentDetails.Controls.Add(Me.dtpDueDate)
        Me.gpxShipmentDetails.Controls.Add(Me.cboPaymentTerms)
        Me.gpxShipmentDetails.Controls.Add(Me.txtComment)
        Me.gpxShipmentDetails.Controls.Add(Me.txtInvoiceNumber)
        Me.gpxShipmentDetails.Controls.Add(Me.Label1)
        Me.gpxShipmentDetails.Controls.Add(Me.Label4)
        Me.gpxShipmentDetails.Controls.Add(Me.Label29)
        Me.gpxShipmentDetails.Controls.Add(Me.Label6)
        Me.gpxShipmentDetails.Controls.Add(Me.Label18)
        Me.gpxShipmentDetails.Controls.Add(Me.Label19)
        Me.gpxShipmentDetails.Controls.Add(Me.Label20)
        Me.gpxShipmentDetails.Controls.Add(Me.Label22)
        Me.gpxShipmentDetails.Controls.Add(Me.Label21)
        Me.gpxShipmentDetails.Controls.Add(Me.Label23)
        Me.gpxShipmentDetails.Controls.Add(Me.Label14)
        Me.gpxShipmentDetails.Location = New System.Drawing.Point(29, 201)
        Me.gpxShipmentDetails.Name = "gpxShipmentDetails"
        Me.gpxShipmentDetails.Size = New System.Drawing.Size(300, 610)
        Me.gpxShipmentDetails.TabIndex = 4
        Me.gpxShipmentDetails.TabStop = False
        Me.gpxShipmentDetails.Text = "Voucher Details"
        '
        'cboCheckType
        '
        Me.cboCheckType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCheckType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCheckType.FormattingEnabled = True
        Me.cboCheckType.Items.AddRange(New Object() {"STANDARD", "FEDEX", "INTERCOMPANY", "ACH"})
        Me.cboCheckType.Location = New System.Drawing.Point(109, 157)
        Me.cboCheckType.Name = "cboCheckType"
        Me.cboCheckType.Size = New System.Drawing.Size(176, 21)
        Me.cboCheckType.TabIndex = 93
        '
        'chkWhitePaper
        '
        Me.chkWhitePaper.AutoSize = True
        Me.chkWhitePaper.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkWhitePaper.ForeColor = System.Drawing.Color.Blue
        Me.chkWhitePaper.Location = New System.Drawing.Point(19, 457)
        Me.chkWhitePaper.Name = "chkWhitePaper"
        Me.chkWhitePaper.Size = New System.Drawing.Size(183, 17)
        Me.chkWhitePaper.TabIndex = 92
        Me.chkWhitePaper.Text = "Check if it is a white paper check"
        Me.chkWhitePaper.UseVisualStyleBackColor = True
        '
        'chkChangePostDate
        '
        Me.chkChangePostDate.AutoSize = True
        Me.chkChangePostDate.ForeColor = System.Drawing.Color.Blue
        Me.chkChangePostDate.Location = New System.Drawing.Point(19, 429)
        Me.chkChangePostDate.Name = "chkChangePostDate"
        Me.chkChangePostDate.Size = New System.Drawing.Size(184, 17)
        Me.chkChangePostDate.TabIndex = 35
        Me.chkChangePostDate.Text = "Change Voucher Date/Post Date"
        Me.chkChangePostDate.UseVisualStyleBackColor = True
        '
        'cboVendorClass
        '
        Me.cboVendorClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorClass.DataSource = Me.VendorClassBindingSource
        Me.cboVendorClass.DisplayMember = "VendClassID"
        Me.cboVendorClass.FormattingEnabled = True
        Me.cboVendorClass.Location = New System.Drawing.Point(109, 127)
        Me.cboVendorClass.Name = "cboVendorClass"
        Me.cboVendorClass.Size = New System.Drawing.Size(176, 21)
        Me.cboVendorClass.TabIndex = 6
        '
        'VendorClassBindingSource
        '
        Me.VendorClassBindingSource.DataMember = "VendorClass"
        Me.VendorClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(19, 128)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(103, 20)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "Vendor Class"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBatchNumber
        '
        Me.txtBatchNumber.BackColor = System.Drawing.Color.White
        Me.txtBatchNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchNumber.Location = New System.Drawing.Point(109, 216)
        Me.txtBatchNumber.Name = "txtBatchNumber"
        Me.txtBatchNumber.ReadOnly = True
        Me.txtBatchNumber.Size = New System.Drawing.Size(176, 20)
        Me.txtBatchNumber.TabIndex = 7
        Me.txtBatchNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPONumber
        '
        Me.txtPONumber.BackColor = System.Drawing.Color.White
        Me.txtPONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPONumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPONumber.Location = New System.Drawing.Point(109, 187)
        Me.txtPONumber.Name = "txtPONumber"
        Me.txtPONumber.ReadOnly = True
        Me.txtPONumber.Size = New System.Drawing.Size(176, 20)
        Me.txtPONumber.TabIndex = 6
        Me.txtPONumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorName.Location = New System.Drawing.Point(19, 55)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(266, 52)
        Me.txtVendorName.TabIndex = 5
        Me.txtVendorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.VendorBindingSource
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(69, 24)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(216, 21)
        Me.cboVendorID.TabIndex = 4
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpInvoiceDate
        '
        Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(109, 304)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(176, 20)
        Me.dtpInvoiceDate.TabIndex = 10
        Me.dtpInvoiceDate.Value = New Date(2023, 11, 9, 0, 0, 0, 0)
        '
        'dtpDiscountDate
        '
        Me.dtpDiscountDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDiscountDate.Location = New System.Drawing.Point(109, 362)
        Me.dtpDiscountDate.Name = "dtpDiscountDate"
        Me.dtpDiscountDate.Size = New System.Drawing.Size(176, 20)
        Me.dtpDiscountDate.TabIndex = 12
        '
        'dtpReceiptDate
        '
        Me.dtpReceiptDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReceiptDate.Location = New System.Drawing.Point(109, 333)
        Me.dtpReceiptDate.Name = "dtpReceiptDate"
        Me.dtpReceiptDate.Size = New System.Drawing.Size(176, 20)
        Me.dtpReceiptDate.TabIndex = 11
        '
        'dtpDueDate
        '
        Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDueDate.Location = New System.Drawing.Point(109, 391)
        Me.dtpDueDate.Name = "dtpDueDate"
        Me.dtpDueDate.Size = New System.Drawing.Size(176, 20)
        Me.dtpDueDate.TabIndex = 13
        '
        'cboPaymentTerms
        '
        Me.cboPaymentTerms.DataSource = Me.PaymentTermsBindingSource
        Me.cboPaymentTerms.DisplayMember = "PmtTermsID"
        Me.cboPaymentTerms.FormattingEnabled = True
        Me.cboPaymentTerms.Location = New System.Drawing.Point(109, 274)
        Me.cboPaymentTerms.Name = "cboPaymentTerms"
        Me.cboPaymentTerms.Size = New System.Drawing.Size(176, 21)
        Me.cboPaymentTerms.TabIndex = 9
        '
        'PaymentTermsBindingSource
        '
        Me.PaymentTermsBindingSource.DataMember = "PaymentTerms"
        Me.PaymentTermsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtComment
        '
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(19, 508)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(266, 89)
        Me.txtComment.TabIndex = 14
        Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInvoiceNumber
        '
        Me.txtInvoiceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceNumber.Location = New System.Drawing.Point(109, 245)
        Me.txtInvoiceNumber.Name = "txtInvoiceNumber"
        Me.txtInvoiceNumber.Size = New System.Drawing.Size(176, 20)
        Me.txtInvoiceNumber.TabIndex = 8
        Me.txtInvoiceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(19, 391)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 20)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Due Date"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(19, 485)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Comment"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.ForeColor = System.Drawing.Color.Blue
        Me.Label29.Location = New System.Drawing.Point(19, 274)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(103, 20)
        Me.Label29.TabIndex = 23
        Me.Label29.Text = "Payment Terms"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(19, 362)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 20)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Discount Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(19, 25)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 20)
        Me.Label18.TabIndex = 20
        Me.Label18.Text = "Vendor"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(19, 245)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(103, 20)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "Invoice #"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(19, 304)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(103, 20)
        Me.Label20.TabIndex = 19
        Me.Label20.Text = "Invoice Date"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(19, 186)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(103, 20)
        Me.Label22.TabIndex = 23
        Me.Label22.Text = "PO #"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.ForeColor = System.Drawing.Color.Blue
        Me.Label21.Location = New System.Drawing.Point(19, 333)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(103, 20)
        Me.Label21.TabIndex = 20
        Me.Label21.Text = "Receipt Date"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(19, 217)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(103, 20)
        Me.Label23.TabIndex = 21
        Me.Label23.Text = "Batch #"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(19, 158)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(103, 20)
        Me.Label14.TabIndex = 94
        Me.Label14.Text = "Check Type"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(17, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Discount Amount"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(17, 117)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(100, 20)
        Me.Label28.TabIndex = 22
        Me.Label28.Text = "Invoice Total"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(17, 84)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(100, 20)
        Me.Label30.TabIndex = 24
        Me.Label30.Text = "Invoice Sales Tax"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(17, 51)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 20)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Invoice Freight"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(17, 18)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 20)
        Me.Label17.TabIndex = 19
        Me.Label17.Text = "Product Total"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(10, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Voucher Number"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVoucherNumber
        '
        Me.cboVoucherNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVoucherNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVoucherNumber.DataSource = Me.ReceiptOfInvoiceBatchLineBindingSource
        Me.cboVoucherNumber.DisplayMember = "VoucherNumber"
        Me.cboVoucherNumber.Location = New System.Drawing.Point(109, 25)
        Me.cboVoucherNumber.Name = "cboVoucherNumber"
        Me.cboVoucherNumber.Size = New System.Drawing.Size(176, 21)
        Me.cboVoucherNumber.TabIndex = 0
        '
        'ReceiptOfInvoiceBatchLineBindingSource
        '
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataMember = "ReceiptOfInvoiceBatchLine"
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblVoucherSource)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.lblVoucherStatus)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.cboVoucherNumber)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 154)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Voucher"
        '
        'lblVoucherSource
        '
        Me.lblVoucherSource.BackColor = System.Drawing.Color.White
        Me.lblVoucherSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVoucherSource.Location = New System.Drawing.Point(109, 117)
        Me.lblVoucherSource.Name = "lblVoucherSource"
        Me.lblVoucherSource.Size = New System.Drawing.Size(176, 20)
        Me.lblVoucherSource.TabIndex = 3
        Me.lblVoucherSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(10, 117)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Voucher Source"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVoucherStatus
        '
        Me.lblVoucherStatus.BackColor = System.Drawing.Color.White
        Me.lblVoucherStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVoucherStatus.Location = New System.Drawing.Point(109, 87)
        Me.lblVoucherStatus.Name = "lblVoucherStatus"
        Me.lblVoucherStatus.Size = New System.Drawing.Size(176, 20)
        Me.lblVoucherStatus.TabIndex = 2
        Me.lblVoucherStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(109, 56)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(176, 21)
        Me.cboDivisionID.TabIndex = 1
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Voucher Status"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(10, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Division ID"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearFormToolStripMenuItem, Me.SaveVoucherToolStripMenuItem, Me.PrintVoucherToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ClearFormToolStripMenuItem
        '
        Me.ClearFormToolStripMenuItem.Name = "ClearFormToolStripMenuItem"
        Me.ClearFormToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.ClearFormToolStripMenuItem.Text = "Clear Form"
        '
        'SaveVoucherToolStripMenuItem
        '
        Me.SaveVoucherToolStripMenuItem.Name = "SaveVoucherToolStripMenuItem"
        Me.SaveVoucherToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.SaveVoucherToolStripMenuItem.Text = "Save Voucher"
        '
        'PrintVoucherToolStripMenuItem
        '
        Me.PrintVoucherToolStripMenuItem.Name = "PrintVoucherToolStripMenuItem"
        Me.PrintVoucherToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.PrintVoucherToolStripMenuItem.Text = "Print Voucher"
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
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(905, 773)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 24
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 773)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 26
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'ReceiptOfInvoiceBatchLineTableAdapter
        '
        Me.ReceiptOfInvoiceBatchLineTableAdapter.ClearBeforeFill = True
        '
        'FKReceiptOfInvoiceVoucherLinesReceiptOfInvoiceVoucherLinesBindingSource
        '
        Me.FKReceiptOfInvoiceVoucherLinesReceiptOfInvoiceVoucherLinesBindingSource.DataMember = "FK_ReceiptOfInvoiceVoucherLines_ReceiptOfInvoiceVoucherLines"
        Me.FKReceiptOfInvoiceVoucherLinesReceiptOfInvoiceVoucherLinesBindingSource.DataSource = Me.ReceiptOfInvoiceBatchLineBindingSource
        '
        'ReceiptOfInvoiceVoucherLinesTableAdapter
        '
        Me.ReceiptOfInvoiceVoucherLinesTableAdapter.ClearBeforeFill = True
        '
        'dgvVoucherLines
        '
        Me.dgvVoucherLines.AllowUserToAddRows = False
        Me.dgvVoucherLines.AllowUserToDeleteRows = False
        Me.dgvVoucherLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvVoucherLines.AutoGenerateColumns = False
        Me.dgvVoucherLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvVoucherLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvVoucherLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVoucherLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VoucherNumberColumn, Me.VoucherLineColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityColumn, Me.UnitCostColumn, Me.ExtendedAmountColumn, Me.GLDebitAccountColumn, Me.GLCreditAccountColumn, Me.SelectForInvoiceColumn, Me.ReceiverNumberColumn, Me.ReceiverLineColumn})
        Me.dgvVoucherLines.DataSource = Me.ReceiptOfInvoiceVoucherLinesBindingSource
        Me.dgvVoucherLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvVoucherLines.Location = New System.Drawing.Point(345, 41)
        Me.dgvVoucherLines.Name = "dgvVoucherLines"
        Me.dgvVoucherLines.Size = New System.Drawing.Size(785, 524)
        Me.dgvVoucherLines.TabIndex = 2
        Me.dgvVoucherLines.TabStop = False
        '
        'VoucherNumberColumn
        '
        Me.VoucherNumberColumn.DataPropertyName = "VoucherNumber"
        Me.VoucherNumberColumn.HeaderText = "Voucher #"
        Me.VoucherNumberColumn.Name = "VoucherNumberColumn"
        Me.VoucherNumberColumn.Visible = False
        '
        'VoucherLineColumn
        '
        Me.VoucherLineColumn.DataPropertyName = "VoucherLine"
        Me.VoucherLineColumn.HeaderText = "Line #"
        Me.VoucherLineColumn.Name = "VoucherLineColumn"
        Me.VoucherLineColumn.ReadOnly = True
        Me.VoucherLineColumn.Width = 65
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Part Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        DataGridViewCellStyle1.NullValue = "0"
        Me.QuantityColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.Width = 90
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = "0"
        Me.UnitCostColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.Width = 90
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ExtendedAmountColumn.HeaderText = "Extended Amount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
        Me.ExtendedAmountColumn.Width = 90
        '
        'GLDebitAccountColumn
        '
        Me.GLDebitAccountColumn.DataPropertyName = "GLDebitAccount"
        Me.GLDebitAccountColumn.HeaderText = "GL Debit Account"
        Me.GLDebitAccountColumn.Name = "GLDebitAccountColumn"
        '
        'GLCreditAccountColumn
        '
        Me.GLCreditAccountColumn.DataPropertyName = "GLCreditAccount"
        Me.GLCreditAccountColumn.HeaderText = "GL Credit Account"
        Me.GLCreditAccountColumn.Name = "GLCreditAccountColumn"
        '
        'SelectForInvoiceColumn
        '
        Me.SelectForInvoiceColumn.DataPropertyName = "SelectForInvoice"
        Me.SelectForInvoiceColumn.HeaderText = "Select For Invoice"
        Me.SelectForInvoiceColumn.Name = "SelectForInvoiceColumn"
        Me.SelectForInvoiceColumn.Visible = False
        '
        'ReceiverNumberColumn
        '
        Me.ReceiverNumberColumn.DataPropertyName = "ReceiverNumber"
        Me.ReceiverNumberColumn.HeaderText = "ReceiverNumber"
        Me.ReceiverNumberColumn.Name = "ReceiverNumberColumn"
        Me.ReceiverNumberColumn.Visible = False
        '
        'ReceiverLineColumn
        '
        Me.ReceiverLineColumn.DataPropertyName = "ReceiverLine"
        Me.ReceiverLineColumn.HeaderText = "ReceiverLine"
        Me.ReceiverLineColumn.Name = "ReceiverLineColumn"
        Me.ReceiverLineColumn.Visible = False
        '
        'ReceiptOfInvoiceVoucherLinesBindingSource
        '
        Me.ReceiptOfInvoiceVoucherLinesBindingSource.DataMember = "ReceiptOfInvoiceVoucherLines"
        Me.ReceiptOfInvoiceVoucherLinesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
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
        Me.cmdPrint.TabIndex = 25
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'PaymentTermsTableAdapter
        '
        Me.PaymentTermsTableAdapter.ClearBeforeFill = True
        '
        'Note
        '
        Me.Note.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Note.Controls.Add(Me.Label12)
        Me.Note.Controls.Add(Me.cmdReverse)
        Me.Note.Controls.Add(Me.cmdPost)
        Me.Note.Controls.Add(Me.cmdDelete)
        Me.Note.Controls.Add(Me.Label10)
        Me.Note.Controls.Add(Me.Label8)
        Me.Note.Controls.Add(Me.Label9)
        Me.Note.Location = New System.Drawing.Point(345, 578)
        Me.Note.Name = "Note"
        Me.Note.Size = New System.Drawing.Size(355, 235)
        Me.Note.TabIndex = 15
        Me.Note.TabStop = False
        Me.Note.Text = "Edit / Reverse / Delete Voucher"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(23, 131)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(315, 31)
        Me.Label12.TabIndex = 59
        Me.Label12.Text = "If the voucher is reversed and re-opened, it may be deleted."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdReverse
        '
        Me.cmdReverse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReverse.Location = New System.Drawing.Point(73, 180)
        Me.cmdReverse.Name = "cmdReverse"
        Me.cmdReverse.Size = New System.Drawing.Size(71, 40)
        Me.cmdReverse.TabIndex = 15
        Me.cmdReverse.Text = "Reverse Posting"
        Me.cmdReverse.UseVisualStyleBackColor = True
        '
        'cmdPost
        '
        Me.cmdPost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPost.Location = New System.Drawing.Point(227, 180)
        Me.cmdPost.Name = "cmdPost"
        Me.cmdPost.Size = New System.Drawing.Size(71, 40)
        Me.cmdPost.TabIndex = 17
        Me.cmdPost.Text = "Re-Post Voucher"
        Me.cmdPost.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(150, 180)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 16
        Me.cmdDelete.Text = "Delete Voucher"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(23, 79)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(315, 44)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "If Voucher Source is VOUCHER RECEIPT and voucher is not closed, you may re-open v" & _
            "oucher to make changes, and re-post."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(23, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(315, 31)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "If the Voucher is POSTED, you may make changes to the fields in blue."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(23, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(315, 31)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "If the Voucher is CLOSED, no changes may be made."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.txtDiscountAmount)
        Me.GroupBox2.Controls.Add(Me.txtInvoiceTotal)
        Me.GroupBox2.Controls.Add(Me.txtSalesTax)
        Me.GroupBox2.Controls.Add(Me.txtFreight)
        Me.GroupBox2.Controls.Add(Me.txtProductTotal)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Location = New System.Drawing.Point(828, 576)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(302, 184)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Voucher Totals"
        '
        'txtDiscountAmount
        '
        Me.txtDiscountAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscountAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDiscountAmount.Location = New System.Drawing.Point(123, 150)
        Me.txtDiscountAmount.Name = "txtDiscountAmount"
        Me.txtDiscountAmount.Size = New System.Drawing.Size(163, 20)
        Me.txtDiscountAmount.TabIndex = 22
        Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInvoiceTotal
        '
        Me.txtInvoiceTotal.BackColor = System.Drawing.Color.White
        Me.txtInvoiceTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceTotal.Location = New System.Drawing.Point(123, 117)
        Me.txtInvoiceTotal.Name = "txtInvoiceTotal"
        Me.txtInvoiceTotal.ReadOnly = True
        Me.txtInvoiceTotal.Size = New System.Drawing.Size(163, 20)
        Me.txtInvoiceTotal.TabIndex = 21
        Me.txtInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSalesTax
        '
        Me.txtSalesTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesTax.Location = New System.Drawing.Point(123, 84)
        Me.txtSalesTax.Name = "txtSalesTax"
        Me.txtSalesTax.Size = New System.Drawing.Size(163, 20)
        Me.txtSalesTax.TabIndex = 20
        Me.txtSalesTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFreight
        '
        Me.txtFreight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreight.Location = New System.Drawing.Point(123, 51)
        Me.txtFreight.Name = "txtFreight"
        Me.txtFreight.Size = New System.Drawing.Size(163, 20)
        Me.txtFreight.TabIndex = 19
        Me.txtFreight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtProductTotal
        '
        Me.txtProductTotal.BackColor = System.Drawing.Color.White
        Me.txtProductTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductTotal.Location = New System.Drawing.Point(123, 18)
        Me.txtProductTotal.Name = "txtProductTotal"
        Me.txtProductTotal.ReadOnly = True
        Me.txtProductTotal.Size = New System.Drawing.Size(163, 20)
        Me.txtProductTotal.TabIndex = 18
        Me.txtProductTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdClearForm
        '
        Me.cmdClearForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearForm.Location = New System.Drawing.Point(828, 773)
        Me.cmdClearForm.Name = "cmdClearForm"
        Me.cmdClearForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearForm.TabIndex = 23
        Me.cmdClearForm.Text = "Clear All"
        Me.cmdClearForm.UseVisualStyleBackColor = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'VendorClassTableAdapter
        '
        Me.VendorClassTableAdapter.ClearBeforeFill = True
        '
        'VendorReturnLineQueryTableAdapter1
        '
        Me.VendorReturnLineQueryTableAdapter1.ClearBeforeFill = True
        '
        'APViewVoucherLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdClearForm)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Note)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.dgvVoucherLines)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpxShipmentDetails)
        Me.Name = "APViewVoucherLines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation AP Voucher Lines"
        Me.gpxShipmentDetails.ResumeLayout(False)
        Me.gpxShipmentDetails.PerformLayout()
        CType(Me.VendorClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymentTermsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.FKReceiptOfInvoiceVoucherLinesReceiptOfInvoiceVoucherLinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvVoucherLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptOfInvoiceVoucherLinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Note.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpxShipmentDetails As System.Windows.Forms.GroupBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboVoucherNumber As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents txtInvoiceNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ReceiptOfInvoiceBatchLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceBatchLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
    Friend WithEvents FKReceiptOfInvoiceVoucherLinesReceiptOfInvoiceVoucherLinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceVoucherLinesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceVoucherLinesTableAdapter
    Friend WithEvents dgvVoucherLines As System.Windows.Forms.DataGridView
    Friend WithEvents ReceiptOfInvoiceVoucherLinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cboPaymentTerms As System.Windows.Forms.ComboBox
    Friend WithEvents PaymentTermsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PaymentTermsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PaymentTermsTableAdapter
    Friend WithEvents dtpDiscountDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpReceiptDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Note As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClearForm As System.Windows.Forms.Button
    Friend WithEvents lblVoucherStatus As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ClearFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveVoucherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintVoucherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents txtDiscountAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtInvoiceTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtSalesTax As System.Windows.Forms.TextBox
    Friend WithEvents txtFreight As System.Windows.Forms.TextBox
    Friend WithEvents txtProductTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtBatchNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtPONumber As System.Windows.Forms.TextBox
    Friend WithEvents lblVoucherSource As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdReverse As System.Windows.Forms.Button
    Friend WithEvents cmdPost As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboVendorClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents VendorClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorClassTableAdapter
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
    Friend WithEvents chkChangePostDate As System.Windows.Forms.CheckBox
    Friend WithEvents VendorReturnLineQueryTableAdapter1 As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorReturnLineQueryTableAdapter
    Friend WithEvents chkWhitePaper As System.Windows.Forms.CheckBox
    Friend WithEvents cboCheckType As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
