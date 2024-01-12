<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewInvoiceDetails
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
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gpxShipmentDetails = New System.Windows.Forms.GroupBox
        Me.lblCustomerName = New System.Windows.Forms.Label
        Me.lblInvoiceDate = New System.Windows.Forms.Label
        Me.lblInvoiceStatus = New System.Windows.Forms.Label
        Me.lblCustomerID = New System.Windows.Forms.Label
        Me.lblShipmentNumber = New System.Windows.Forms.Label
        Me.lblSONumber = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCustomerPONumber = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.txtSpecialInstructions = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtPRONumber = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblSalesTax = New System.Windows.Forms.Label
        Me.lblPaymentsApplied = New System.Windows.Forms.Label
        Me.lblDiscount = New System.Windows.Forms.Label
        Me.lblProductTotal = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.lblInvoiceTotal = New System.Windows.Forms.Label
        Me.lblBilledFreight = New System.Windows.Forms.Label
        Me.gpxViewInvoiceLines = New System.Windows.Forms.GroupBox
        Me.cboInvoiceNumber = New System.Windows.Forms.ComboBox
        Me.InvoiceHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveChangesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadPickTicket = New System.Windows.Forms.ToolStripMenuItem
        Me.ReUploadPickTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AppendUploadedPickTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgvInvoiceLines = New System.Windows.Forms.DataGridView
        Me.InvoiceHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityBilledColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCOSColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineBoxesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerialNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InvoiceLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceLineTableTableAdapter
        Me.cmdSaveInvoice = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdPrintInvoice = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtZip = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtState = New System.Windows.Forms.TextBox
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.txtAddress2 = New System.Windows.Forms.TextBox
        Me.txtAddress1 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboPaymentTerms = New System.Windows.Forms.ComboBox
        Me.cboShipVia = New System.Windows.Forms.ComboBox
        Me.ShipMethodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.InvoiceHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
        Me.ShipMethodTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
        Me.Label14 = New System.Windows.Forms.Label
        Me.ScanPickTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxShipmentDetails.SuspendLayout()
        Me.gpxViewInvoiceLines.SuspendLayout()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvInvoiceLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpxShipmentDetails
        '
        Me.gpxShipmentDetails.Controls.Add(Me.lblCustomerName)
        Me.gpxShipmentDetails.Controls.Add(Me.lblInvoiceDate)
        Me.gpxShipmentDetails.Controls.Add(Me.lblInvoiceStatus)
        Me.gpxShipmentDetails.Controls.Add(Me.lblCustomerID)
        Me.gpxShipmentDetails.Controls.Add(Me.lblShipmentNumber)
        Me.gpxShipmentDetails.Controls.Add(Me.lblSONumber)
        Me.gpxShipmentDetails.Controls.Add(Me.Label4)
        Me.gpxShipmentDetails.Controls.Add(Me.Label19)
        Me.gpxShipmentDetails.Controls.Add(Me.Label20)
        Me.gpxShipmentDetails.Controls.Add(Me.Label22)
        Me.gpxShipmentDetails.Controls.Add(Me.Label23)
        Me.gpxShipmentDetails.Location = New System.Drawing.Point(26, 151)
        Me.gpxShipmentDetails.Name = "gpxShipmentDetails"
        Me.gpxShipmentDetails.Size = New System.Drawing.Size(288, 267)
        Me.gpxShipmentDetails.TabIndex = 2
        Me.gpxShipmentDetails.TabStop = False
        Me.gpxShipmentDetails.Text = "Invoice Details"
        '
        'lblCustomerName
        '
        Me.lblCustomerName.BackColor = System.Drawing.Color.White
        Me.lblCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCustomerName.Location = New System.Drawing.Point(22, 122)
        Me.lblCustomerName.Name = "lblCustomerName"
        Me.lblCustomerName.Size = New System.Drawing.Size(250, 65)
        Me.lblCustomerName.TabIndex = 28
        Me.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblInvoiceDate
        '
        Me.lblInvoiceDate.BackColor = System.Drawing.Color.White
        Me.lblInvoiceDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInvoiceDate.Location = New System.Drawing.Point(109, 58)
        Me.lblInvoiceDate.Name = "lblInvoiceDate"
        Me.lblInvoiceDate.Size = New System.Drawing.Size(163, 20)
        Me.lblInvoiceDate.TabIndex = 1
        Me.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblInvoiceStatus
        '
        Me.lblInvoiceStatus.BackColor = System.Drawing.Color.White
        Me.lblInvoiceStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInvoiceStatus.Location = New System.Drawing.Point(109, 26)
        Me.lblInvoiceStatus.Name = "lblInvoiceStatus"
        Me.lblInvoiceStatus.Size = New System.Drawing.Size(163, 20)
        Me.lblInvoiceStatus.TabIndex = 2
        Me.lblInvoiceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCustomerID
        '
        Me.lblCustomerID.BackColor = System.Drawing.Color.White
        Me.lblCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCustomerID.Location = New System.Drawing.Point(109, 90)
        Me.lblCustomerID.Name = "lblCustomerID"
        Me.lblCustomerID.Size = New System.Drawing.Size(163, 20)
        Me.lblCustomerID.TabIndex = 4
        Me.lblCustomerID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblShipmentNumber
        '
        Me.lblShipmentNumber.BackColor = System.Drawing.Color.White
        Me.lblShipmentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblShipmentNumber.Location = New System.Drawing.Point(109, 231)
        Me.lblShipmentNumber.Name = "lblShipmentNumber"
        Me.lblShipmentNumber.Size = New System.Drawing.Size(163, 20)
        Me.lblShipmentNumber.TabIndex = 6
        Me.lblShipmentNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSONumber
        '
        Me.lblSONumber.BackColor = System.Drawing.Color.White
        Me.lblSONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSONumber.Location = New System.Drawing.Point(109, 199)
        Me.lblSONumber.Name = "lblSONumber"
        Me.lblSONumber.Size = New System.Drawing.Size(163, 20)
        Me.lblSONumber.TabIndex = 5
        Me.lblSONumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(19, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Invoice Status"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(19, 231)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(100, 20)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "Shipment #"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(19, 90)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(100, 20)
        Me.Label20.TabIndex = 19
        Me.Label20.Text = "Customer ID"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(19, 199)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(100, 20)
        Me.Label22.TabIndex = 21
        Me.Label22.Text = "SO #"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(19, 58)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(100, 20)
        Me.Label23.TabIndex = 22
        Me.Label23.Text = "Invoice Date"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(16, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Ship Via"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCustomerPONumber
        '
        Me.txtCustomerPONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPONumber.Location = New System.Drawing.Point(109, 25)
        Me.txtCustomerPONumber.Name = "txtCustomerPONumber"
        Me.txtCustomerPONumber.Size = New System.Drawing.Size(163, 20)
        Me.txtCustomerPONumber.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(19, 145)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Special Instructions"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComment
        '
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.Location = New System.Drawing.Point(19, 169)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(253, 100)
        Me.txtComment.TabIndex = 10
        '
        'txtSpecialInstructions
        '
        Me.txtSpecialInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSpecialInstructions.Location = New System.Drawing.Point(22, 171)
        Me.txtSpecialInstructions.Multiline = True
        Me.txtSpecialInstructions.Name = "txtSpecialInstructions"
        Me.txtSpecialInstructions.Size = New System.Drawing.Size(338, 64)
        Me.txtSpecialInstructions.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(19, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Comment"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(16, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "PRO Number"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPRONumber
        '
        Me.txtPRONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPRONumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPRONumber.Location = New System.Drawing.Point(109, 53)
        Me.txtPRONumber.Name = "txtPRONumber"
        Me.txtPRONumber.Size = New System.Drawing.Size(163, 20)
        Me.txtPRONumber.TabIndex = 9
        '
        'Label21
        '
        Me.Label21.ForeColor = System.Drawing.Color.Blue
        Me.Label21.Location = New System.Drawing.Point(16, 25)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(100, 20)
        Me.Label21.TabIndex = 20
        Me.Label21.Text = "Customer PO #"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(18, 145)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(100, 20)
        Me.Label29.TabIndex = 23
        Me.Label29.Text = "Payments Applied"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(18, 115)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(100, 20)
        Me.Label30.TabIndex = 24
        Me.Label30.Text = "Discount"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(18, 55)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 20)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "Sales Tax"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSalesTax
        '
        Me.lblSalesTax.BackColor = System.Drawing.Color.White
        Me.lblSalesTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSalesTax.Location = New System.Drawing.Point(124, 52)
        Me.lblSalesTax.Name = "lblSalesTax"
        Me.lblSalesTax.Size = New System.Drawing.Size(163, 23)
        Me.lblSalesTax.TabIndex = 13
        Me.lblSalesTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPaymentsApplied
        '
        Me.lblPaymentsApplied.BackColor = System.Drawing.Color.White
        Me.lblPaymentsApplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaymentsApplied.Location = New System.Drawing.Point(124, 142)
        Me.lblPaymentsApplied.Name = "lblPaymentsApplied"
        Me.lblPaymentsApplied.Size = New System.Drawing.Size(163, 23)
        Me.lblPaymentsApplied.TabIndex = 16
        Me.lblPaymentsApplied.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDiscount
        '
        Me.lblDiscount.BackColor = System.Drawing.Color.White
        Me.lblDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDiscount.Location = New System.Drawing.Point(124, 112)
        Me.lblDiscount.Name = "lblDiscount"
        Me.lblDiscount.Size = New System.Drawing.Size(163, 23)
        Me.lblDiscount.TabIndex = 15
        Me.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblProductTotal
        '
        Me.lblProductTotal.BackColor = System.Drawing.Color.White
        Me.lblProductTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProductTotal.Location = New System.Drawing.Point(124, 22)
        Me.lblProductTotal.Name = "lblProductTotal"
        Me.lblProductTotal.Size = New System.Drawing.Size(163, 23)
        Me.lblProductTotal.TabIndex = 12
        Me.lblProductTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(18, 175)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(100, 20)
        Me.Label28.TabIndex = 22
        Me.Label28.Text = "Invoice Total"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(18, 85)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 20)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "Billed Freight"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(18, 25)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 20)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Product Total"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInvoiceTotal
        '
        Me.lblInvoiceTotal.BackColor = System.Drawing.Color.White
        Me.lblInvoiceTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInvoiceTotal.Location = New System.Drawing.Point(124, 172)
        Me.lblInvoiceTotal.Name = "lblInvoiceTotal"
        Me.lblInvoiceTotal.Size = New System.Drawing.Size(163, 23)
        Me.lblInvoiceTotal.TabIndex = 17
        Me.lblInvoiceTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBilledFreight
        '
        Me.lblBilledFreight.BackColor = System.Drawing.Color.White
        Me.lblBilledFreight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBilledFreight.Location = New System.Drawing.Point(124, 82)
        Me.lblBilledFreight.Name = "lblBilledFreight"
        Me.lblBilledFreight.Size = New System.Drawing.Size(163, 23)
        Me.lblBilledFreight.TabIndex = 14
        Me.lblBilledFreight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gpxViewInvoiceLines
        '
        Me.gpxViewInvoiceLines.Controls.Add(Me.cboInvoiceNumber)
        Me.gpxViewInvoiceLines.Controls.Add(Me.Label3)
        Me.gpxViewInvoiceLines.Controls.Add(Me.cboDivisionID)
        Me.gpxViewInvoiceLines.Controls.Add(Me.Label1)
        Me.gpxViewInvoiceLines.Location = New System.Drawing.Point(26, 41)
        Me.gpxViewInvoiceLines.Name = "gpxViewInvoiceLines"
        Me.gpxViewInvoiceLines.Size = New System.Drawing.Size(288, 104)
        Me.gpxViewInvoiceLines.TabIndex = 0
        Me.gpxViewInvoiceLines.TabStop = False
        Me.gpxViewInvoiceLines.Text = "Select Invoice"
        '
        'cboInvoiceNumber
        '
        Me.cboInvoiceNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInvoiceNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInvoiceNumber.DataSource = Me.InvoiceHeaderTableBindingSource
        Me.cboInvoiceNumber.DisplayMember = "InvoiceNumber"
        Me.cboInvoiceNumber.FormattingEnabled = True
        Me.cboInvoiceNumber.Location = New System.Drawing.Point(109, 62)
        Me.cboInvoiceNumber.Name = "cboInvoiceNumber"
        Me.cboInvoiceNumber.Size = New System.Drawing.Size(163, 21)
        Me.cboInvoiceNumber.TabIndex = 1
        '
        'InvoiceHeaderTableBindingSource
        '
        Me.InvoiceHeaderTableBindingSource.DataMember = "InvoiceHeaderTable"
        Me.InvoiceHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Invoice #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(109, 30)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(163, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveChangesToolStripMenuItem, Me.PrintInvoiceToolStripMenuItem, Me.ClearAllToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveChangesToolStripMenuItem
        '
        Me.SaveChangesToolStripMenuItem.Name = "SaveChangesToolStripMenuItem"
        Me.SaveChangesToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.SaveChangesToolStripMenuItem.Text = "Save Changes"
        '
        'PrintInvoiceToolStripMenuItem
        '
        Me.PrintInvoiceToolStripMenuItem.Name = "PrintInvoiceToolStripMenuItem"
        Me.PrintInvoiceToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.PrintInvoiceToolStripMenuItem.Text = "Print Invoice"
        '
        'ClearAllToolStripMenuItem
        '
        Me.ClearAllToolStripMenuItem.Name = "ClearAllToolStripMenuItem"
        Me.ClearAllToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.ClearAllToolStripMenuItem.Text = "Clear All"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UploadPickTicket, Me.ReUploadPickTicketToolStripMenuItem, Me.AppendUploadedPickTicketToolStripMenuItem, Me.ScanPickTicketToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'UploadPickTicket
        '
        Me.UploadPickTicket.Name = "UploadPickTicket"
        Me.UploadPickTicket.Size = New System.Drawing.Size(211, 22)
        Me.UploadPickTicket.Text = "Upload Pick Ticket"
        '
        'ReUploadPickTicketToolStripMenuItem
        '
        Me.ReUploadPickTicketToolStripMenuItem.Enabled = False
        Me.ReUploadPickTicketToolStripMenuItem.Name = "ReUploadPickTicketToolStripMenuItem"
        Me.ReUploadPickTicketToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.ReUploadPickTicketToolStripMenuItem.Text = "Re-Upload Pick Ticket"
        '
        'AppendUploadedPickTicketToolStripMenuItem
        '
        Me.AppendUploadedPickTicketToolStripMenuItem.Enabled = False
        Me.AppendUploadedPickTicketToolStripMenuItem.Name = "AppendUploadedPickTicketToolStripMenuItem"
        Me.AppendUploadedPickTicketToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.AppendUploadedPickTicketToolStripMenuItem.Text = "Append Uploaded Pick Ticket"
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
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.lblProductTotal)
        Me.GroupBox1.Controls.Add(Me.lblInvoiceTotal)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.lblBilledFreight)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.lblSalesTax)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.lblPaymentsApplied)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.lblDiscount)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Location = New System.Drawing.Point(828, 558)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(302, 207)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Totals"
        '
        'dgvInvoiceLines
        '
        Me.dgvInvoiceLines.AllowUserToAddRows = False
        Me.dgvInvoiceLines.AllowUserToDeleteRows = False
        Me.dgvInvoiceLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInvoiceLines.AutoGenerateColumns = False
        Me.dgvInvoiceLines.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.dgvInvoiceLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInvoiceLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceHeaderKeyColumn, Me.InvoiceLineKeyColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityBilledColumn, Me.PriceColumn, Me.SalesTaxColumn, Me.ExtendedAmountColumn, Me.ExtendedCOSColumn, Me.LineWeightColumn, Me.LineBoxesColumn, Me.LineCommentColumn, Me.SerialNumberColumn, Me.DebitGLAccountColumn, Me.CreditGLAccountColumn, Me.LineStatusColumn, Me.DivisionIDColumn})
        Me.dgvInvoiceLines.DataSource = Me.InvoiceLineTableBindingSource
        Me.dgvInvoiceLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvInvoiceLines.Location = New System.Drawing.Point(332, 41)
        Me.dgvInvoiceLines.Name = "dgvInvoiceLines"
        Me.dgvInvoiceLines.Size = New System.Drawing.Size(798, 499)
        Me.dgvInvoiceLines.TabIndex = 14
        '
        'InvoiceHeaderKeyColumn
        '
        Me.InvoiceHeaderKeyColumn.DataPropertyName = "InvoiceHeaderKey"
        Me.InvoiceHeaderKeyColumn.HeaderText = "Invoice #"
        Me.InvoiceHeaderKeyColumn.Name = "InvoiceHeaderKeyColumn"
        Me.InvoiceHeaderKeyColumn.ReadOnly = True
        Me.InvoiceHeaderKeyColumn.Visible = False
        '
        'InvoiceLineKeyColumn
        '
        Me.InvoiceLineKeyColumn.DataPropertyName = "InvoiceLineKey"
        Me.InvoiceLineKeyColumn.HeaderText = "Line #"
        Me.InvoiceLineKeyColumn.Name = "InvoiceLineKeyColumn"
        Me.InvoiceLineKeyColumn.ReadOnly = True
        Me.InvoiceLineKeyColumn.Width = 65
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Part Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.ReadOnly = True
        '
        'QuantityBilledColumn
        '
        Me.QuantityBilledColumn.DataPropertyName = "QuantityBilled"
        DataGridViewCellStyle15.NullValue = "0"
        Me.QuantityBilledColumn.DefaultCellStyle = DataGridViewCellStyle15
        Me.QuantityBilledColumn.HeaderText = "Quantity Billed"
        Me.QuantityBilledColumn.Name = "QuantityBilledColumn"
        Me.QuantityBilledColumn.ReadOnly = True
        Me.QuantityBilledColumn.Width = 85
        '
        'PriceColumn
        '
        Me.PriceColumn.DataPropertyName = "Price"
        DataGridViewCellStyle16.Format = "N4"
        DataGridViewCellStyle16.NullValue = "0"
        Me.PriceColumn.DefaultCellStyle = DataGridViewCellStyle16
        Me.PriceColumn.HeaderText = "Price"
        Me.PriceColumn.Name = "PriceColumn"
        Me.PriceColumn.ReadOnly = True
        Me.PriceColumn.Width = 85
        '
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        DataGridViewCellStyle17.Format = "N2"
        DataGridViewCellStyle17.NullValue = "0"
        Me.SalesTaxColumn.DefaultCellStyle = DataGridViewCellStyle17
        Me.SalesTaxColumn.HeaderText = "Sales Tax"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        Me.SalesTaxColumn.ReadOnly = True
        Me.SalesTaxColumn.Width = 85
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle18.Format = "N2"
        DataGridViewCellStyle18.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle18
        Me.ExtendedAmountColumn.HeaderText = "Extended Amount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
        Me.ExtendedAmountColumn.Width = 85
        '
        'ExtendedCOSColumn
        '
        Me.ExtendedCOSColumn.DataPropertyName = "ExtendedCOS"
        DataGridViewCellStyle19.Format = "N2"
        DataGridViewCellStyle19.NullValue = "0"
        Me.ExtendedCOSColumn.DefaultCellStyle = DataGridViewCellStyle19
        Me.ExtendedCOSColumn.HeaderText = "Extended COS"
        Me.ExtendedCOSColumn.Name = "ExtendedCOSColumn"
        Me.ExtendedCOSColumn.Width = 85
        '
        'LineWeightColumn
        '
        Me.LineWeightColumn.DataPropertyName = "LineWeight"
        DataGridViewCellStyle20.Format = "N2"
        DataGridViewCellStyle20.NullValue = "0"
        Me.LineWeightColumn.DefaultCellStyle = DataGridViewCellStyle20
        Me.LineWeightColumn.HeaderText = "Line Weight"
        Me.LineWeightColumn.Name = "LineWeightColumn"
        Me.LineWeightColumn.ReadOnly = True
        Me.LineWeightColumn.Width = 85
        '
        'LineBoxesColumn
        '
        Me.LineBoxesColumn.DataPropertyName = "LineBoxes"
        DataGridViewCellStyle21.Format = "N0"
        DataGridViewCellStyle21.NullValue = "0"
        Me.LineBoxesColumn.DefaultCellStyle = DataGridViewCellStyle21
        Me.LineBoxesColumn.HeaderText = "Line Boxes"
        Me.LineBoxesColumn.Name = "LineBoxesColumn"
        Me.LineBoxesColumn.ReadOnly = True
        Me.LineBoxesColumn.Width = 85
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        '
        'SerialNumberColumn
        '
        Me.SerialNumberColumn.DataPropertyName = "SerialNumber"
        Me.SerialNumberColumn.HeaderText = "Heat# / Lot#"
        Me.SerialNumberColumn.Name = "SerialNumberColumn"
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "Debit GL Account"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        Me.DebitGLAccountColumn.ReadOnly = True
        Me.DebitGLAccountColumn.Visible = False
        '
        'CreditGLAccountColumn
        '
        Me.CreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumn.HeaderText = "Credit GL Account"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
        Me.CreditGLAccountColumn.ReadOnly = True
        Me.CreditGLAccountColumn.Visible = False
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "Line Status"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.ReadOnly = True
        Me.LineStatusColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division ID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'InvoiceLineTableBindingSource
        '
        Me.InvoiceLineTableBindingSource.DataMember = "InvoiceLineTable"
        Me.InvoiceLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'InvoiceLineTableTableAdapter
        '
        Me.InvoiceLineTableTableAdapter.ClearBeforeFill = True
        '
        'cmdSaveInvoice
        '
        Me.cmdSaveInvoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSaveInvoice.Location = New System.Drawing.Point(982, 771)
        Me.cmdSaveInvoice.Name = "cmdSaveInvoice"
        Me.cmdSaveInvoice.Size = New System.Drawing.Size(71, 40)
        Me.cmdSaveInvoice.TabIndex = 20
        Me.cmdSaveInvoice.Text = "Save"
        Me.cmdSaveInvoice.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 21
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(828, 771)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 18
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdPrintInvoice
        '
        Me.cmdPrintInvoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintInvoice.Location = New System.Drawing.Point(905, 771)
        Me.cmdPrintInvoice.Name = "cmdPrintInvoice"
        Me.cmdPrintInvoice.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintInvoice.TabIndex = 19
        Me.cmdPrintInvoice.Text = "Print Invoice"
        Me.cmdPrintInvoice.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.txtZip)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.txtState)
        Me.GroupBox3.Controls.Add(Me.txtCity)
        Me.GroupBox3.Controls.Add(Me.txtAddress2)
        Me.GroupBox3.Controls.Add(Me.txtSpecialInstructions)
        Me.GroupBox3.Controls.Add(Me.txtAddress1)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox3.Location = New System.Drawing.Point(332, 558)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(380, 253)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Customer Billing Address"
        '
        'txtZip
        '
        Me.txtZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtZip.Location = New System.Drawing.Point(258, 117)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(102, 20)
        Me.txtZip.TabIndex = 41
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(226, 117)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 20)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "Zip"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtState
        '
        Me.txtState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtState.Location = New System.Drawing.Point(103, 117)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(102, 20)
        Me.txtState.TabIndex = 35
        '
        'txtCity
        '
        Me.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCity.Location = New System.Drawing.Point(103, 87)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(257, 20)
        Me.txtCity.TabIndex = 34
        '
        'txtAddress2
        '
        Me.txtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddress2.Location = New System.Drawing.Point(103, 57)
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(257, 20)
        Me.txtAddress2.TabIndex = 33
        '
        'txtAddress1
        '
        Me.txtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddress1.Location = New System.Drawing.Point(103, 27)
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(257, 20)
        Me.txtAddress1.TabIndex = 32
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(19, 117)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 20)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "State"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(19, 87)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "City"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(19, 55)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Address 2"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(19, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "Address 1"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboPaymentTerms)
        Me.GroupBox2.Controls.Add(Me.cboShipVia)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtComment)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtCustomerPONumber)
        Me.GroupBox2.Controls.Add(Me.txtPRONumber)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox2.Location = New System.Drawing.Point(26, 523)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(288, 288)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Invoice Fields"
        '
        'cboPaymentTerms
        '
        Me.cboPaymentTerms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPaymentTerms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentTerms.FormattingEnabled = True
        Me.cboPaymentTerms.Items.AddRange(New Object() {"N30", "COD", "CREDIT CARD", "Prepaid", "NetDue"})
        Me.cboPaymentTerms.Location = New System.Drawing.Point(109, 109)
        Me.cboPaymentTerms.Name = "cboPaymentTerms"
        Me.cboPaymentTerms.Size = New System.Drawing.Size(163, 21)
        Me.cboPaymentTerms.TabIndex = 35
        '
        'cboShipVia
        '
        Me.cboShipVia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipVia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipVia.DataSource = Me.ShipMethodBindingSource
        Me.cboShipVia.DisplayMember = "ShipMethID"
        Me.cboShipVia.FormattingEnabled = True
        Me.cboShipVia.Location = New System.Drawing.Point(109, 80)
        Me.cboShipVia.Name = "cboShipVia"
        Me.cboShipVia.Size = New System.Drawing.Size(163, 21)
        Me.cboShipVia.TabIndex = 34
        '
        'ShipMethodBindingSource
        '
        Me.ShipMethodBindingSource.DataMember = "ShipMethod"
        Me.ShipMethodBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(16, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Payment Terms"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InvoiceHeaderTableTableAdapter
        '
        Me.InvoiceHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'ShipMethodTableAdapter
        '
        Me.ShipMethodTableAdapter.ClearBeforeFill = True
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(42, 461)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(269, 20)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Fields in BLUE may be changed and Invoice re-printed."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ScanPickTicketToolStripMenuItem
        '
        Me.ScanPickTicketToolStripMenuItem.Name = "ScanPickTicketToolStripMenuItem"
        Me.ScanPickTicketToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.ScanPickTicketToolStripMenuItem.Text = "Scan Pick Ticket"
        '
        'ViewInvoiceDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdPrintInvoice)
        Me.Controls.Add(Me.cmdSaveInvoice)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.dgvInvoiceLines)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.gpxShipmentDetails)
        Me.Controls.Add(Me.gpxViewInvoiceLines)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Name = "ViewInvoiceDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation View Invoice Details"
        Me.gpxShipmentDetails.ResumeLayout(False)
        Me.gpxViewInvoiceLines.ResumeLayout(False)
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvInvoiceLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpxShipmentDetails As System.Windows.Forms.GroupBox
    Friend WithEvents txtPRONumber As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblSalesTax As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblPaymentsApplied As System.Windows.Forms.Label
    Friend WithEvents lblInvoiceTotal As System.Windows.Forms.Label
    Friend WithEvents lblDiscount As System.Windows.Forms.Label
    Friend WithEvents lblBilledFreight As System.Windows.Forms.Label
    Friend WithEvents lblCustomerID As System.Windows.Forms.Label
    Friend WithEvents lblShipmentNumber As System.Windows.Forms.Label
    Friend WithEvents lblSONumber As System.Windows.Forms.Label
    Friend WithEvents gpxViewInvoiceLines As System.Windows.Forms.GroupBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblInvoiceStatus As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblProductTotal As System.Windows.Forms.Label
    Friend WithEvents txtCustomerPONumber As System.Windows.Forms.TextBox
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents txtSpecialInstructions As System.Windows.Forms.TextBox
    Friend WithEvents lblInvoiceDate As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgvInvoiceLines As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents InvoiceLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceLineTableTableAdapter
    Friend WithEvents cmdSaveInvoice As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cboInvoiceNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdPrintInvoice As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents SaveChangesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvoiceHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
    Friend WithEvents ClearAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblCustomerName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents cboPaymentTerms As System.Windows.Forms.ComboBox
    Friend WithEvents cboShipVia As System.Windows.Forms.ComboBox
    Friend WithEvents ShipMethodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipMethodTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents InvoiceHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityBilledColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCOSColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineBoxesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents UploadPickTicket As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReUploadPickTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppendUploadedPickTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScanPickTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
