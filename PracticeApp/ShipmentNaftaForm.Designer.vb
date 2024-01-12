<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShipmentNaftaForm
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintNAFTADocsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintCustomsInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintNAFTAFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintELFFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtThirdPartyShipper = New System.Windows.Forms.TextBox
        Me.cboShipMethod = New System.Windows.Forms.ComboBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.cboShipVia = New System.Windows.Forms.ComboBox
        Me.ShipMethodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label3 = New System.Windows.Forms.Label
        Me.gpxShipTo = New System.Windows.Forms.GroupBox
        Me.cboState = New System.Windows.Forms.ComboBox
        Me.StateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtZip = New System.Windows.Forms.TextBox
        Me.txtCountry = New System.Windows.Forms.TextBox
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.txtAddress2 = New System.Windows.Forms.TextBox
        Me.txtAddress1 = New System.Windows.Forms.TextBox
        Me.txtCustomerName = New System.Windows.Forms.TextBox
        Me.cboShipToID = New System.Windows.Forms.ComboBox
        Me.AdditionalShipToBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.gpxSearchFields = New System.Windows.Forms.GroupBox
        Me.cboCurrencyType = New System.Windows.Forms.ComboBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.cmdGenerateNew = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboShipmentNaftaKey = New System.Windows.Forms.ComboBox
        Me.ShipmentNaftaTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpShipDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label12 = New System.Windows.Forms.Label
        Me.gpxShippingDetails = New System.Windows.Forms.GroupBox
        Me.txtActualWeight = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtTotalPallets = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtTotalBoxes = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtTotalAmount = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmdClearForm = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ShipmentNaftaTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentNaftaTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.ShipMethodTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
        Me.AdditionalShipToTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AdditionalShipToTableAdapter
        Me.StateTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtLineWeight = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtLineBoxes = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtLineExtendedAmount = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtLinePrice = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtLineQuantity = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.cmdClearLine = New System.Windows.Forms.Button
        Me.cmdAddLine = New System.Windows.Forms.Button
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.dgvShipmentNaftaLines = New System.Windows.Forms.DataGridView
        Me.ShipmentNaftaLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityShippedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitPriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineBoxesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNaftaKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNaftaLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShipmentNaftaLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentNaftaLineTableTableAdapter
        Me.cmdAddShipments = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.txtSpecialInstructions = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.txtBillToAddress = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxShipTo.SuspendLayout()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdditionalShipToBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxSearchFields.SuspendLayout()
        CType(Me.ShipmentNaftaTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxShippingDetails.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvShipmentNaftaLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentNaftaLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintNAFTADocsToolStripMenuItem, Me.PrintCustomsInvoiceToolStripMenuItem, Me.PrintNAFTAFormToolStripMenuItem, Me.PrintELFFormToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintNAFTADocsToolStripMenuItem
        '
        Me.PrintNAFTADocsToolStripMenuItem.Name = "PrintNAFTADocsToolStripMenuItem"
        Me.PrintNAFTADocsToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.PrintNAFTADocsToolStripMenuItem.Text = "Print All Nafta Docs"
        '
        'PrintCustomsInvoiceToolStripMenuItem
        '
        Me.PrintCustomsInvoiceToolStripMenuItem.Name = "PrintCustomsInvoiceToolStripMenuItem"
        Me.PrintCustomsInvoiceToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.PrintCustomsInvoiceToolStripMenuItem.Text = "Print Customs Invoice"
        '
        'PrintNAFTAFormToolStripMenuItem
        '
        Me.PrintNAFTAFormToolStripMenuItem.Name = "PrintNAFTAFormToolStripMenuItem"
        Me.PrintNAFTAFormToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.PrintNAFTAFormToolStripMenuItem.Text = "Print NAFTA Form"
        '
        'PrintELFFormToolStripMenuItem
        '
        Me.PrintELFFormToolStripMenuItem.Name = "PrintELFFormToolStripMenuItem"
        Me.PrintELFFormToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.PrintELFFormToolStripMenuItem.Text = "Print ELF Form"
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
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(14, 262)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(162, 21)
        Me.Label26.TabIndex = 45
        Me.Label26.Text = "Third Party Shipping"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtThirdPartyShipper
        '
        Me.txtThirdPartyShipper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtThirdPartyShipper.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtThirdPartyShipper.Enabled = False
        Me.txtThirdPartyShipper.Location = New System.Drawing.Point(14, 284)
        Me.txtThirdPartyShipper.Multiline = True
        Me.txtThirdPartyShipper.Name = "txtThirdPartyShipper"
        Me.txtThirdPartyShipper.Size = New System.Drawing.Size(307, 70)
        Me.txtThirdPartyShipper.TabIndex = 10
        Me.txtThirdPartyShipper.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboShipMethod
        '
        Me.cboShipMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipMethod.DisplayMember = "ItemID"
        Me.cboShipMethod.FormattingEnabled = True
        Me.cboShipMethod.Items.AddRange(New Object() {"COLLECT", "PREPAID", "PREPAID/ADD", "THIRD PARTY", "OTHER"})
        Me.cboShipMethod.Location = New System.Drawing.Point(111, 228)
        Me.cboShipMethod.MaxLength = 50
        Me.cboShipMethod.Name = "cboShipMethod"
        Me.cboShipMethod.Size = New System.Drawing.Size(211, 21)
        Me.cboShipMethod.TabIndex = 9
        Me.cboShipMethod.ValueMember = "ItemID"
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(14, 228)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(99, 21)
        Me.Label25.TabIndex = 17
        Me.Label25.Text = "Ship Method"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipVia
        '
        Me.cboShipVia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipVia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipVia.DataSource = Me.ShipMethodBindingSource
        Me.cboShipVia.DisplayMember = "ShipMethID"
        Me.cboShipVia.FormattingEnabled = True
        Me.cboShipVia.Location = New System.Drawing.Point(111, 198)
        Me.cboShipVia.MaxLength = 50
        Me.cboShipVia.Name = "cboShipVia"
        Me.cboShipVia.Size = New System.Drawing.Size(211, 21)
        Me.cboShipVia.TabIndex = 8
        Me.cboShipVia.ValueMember = "ItemID"
        '
        'ShipMethodBindingSource
        '
        Me.ShipMethodBindingSource.DataMember = "ShipMethod"
        Me.ShipMethodBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(14, 198)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 21)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Ship Via"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxShipTo
        '
        Me.gpxShipTo.Controls.Add(Me.cboState)
        Me.gpxShipTo.Controls.Add(Me.txtZip)
        Me.gpxShipTo.Controls.Add(Me.txtCountry)
        Me.gpxShipTo.Controls.Add(Me.txtCity)
        Me.gpxShipTo.Controls.Add(Me.txtAddress2)
        Me.gpxShipTo.Controls.Add(Me.txtAddress1)
        Me.gpxShipTo.Controls.Add(Me.txtCustomerName)
        Me.gpxShipTo.Controls.Add(Me.cboShipToID)
        Me.gpxShipTo.Controls.Add(Me.Label13)
        Me.gpxShipTo.Controls.Add(Me.Label11)
        Me.gpxShipTo.Controls.Add(Me.Label10)
        Me.gpxShipTo.Controls.Add(Me.Label5)
        Me.gpxShipTo.Controls.Add(Me.Label8)
        Me.gpxShipTo.Controls.Add(Me.Label7)
        Me.gpxShipTo.Controls.Add(Me.Label6)
        Me.gpxShipTo.Controls.Add(Me.Label9)
        Me.gpxShipTo.Location = New System.Drawing.Point(12, 418)
        Me.gpxShipTo.Name = "gpxShipTo"
        Me.gpxShipTo.Size = New System.Drawing.Size(342, 393)
        Me.gpxShipTo.TabIndex = 11
        Me.gpxShipTo.TabStop = False
        Me.gpxShipTo.Text = "Customer Ship To"
        '
        'cboState
        '
        Me.cboState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboState.DataSource = Me.StateTableBindingSource
        Me.cboState.DisplayMember = "StateCode"
        Me.cboState.FormattingEnabled = True
        Me.cboState.Location = New System.Drawing.Point(80, 326)
        Me.cboState.Name = "cboState"
        Me.cboState.Size = New System.Drawing.Size(80, 21)
        Me.cboState.TabIndex = 17
        Me.cboState.ValueMember = "ItemID"
        '
        'StateTableBindingSource
        '
        Me.StateTableBindingSource.DataMember = "StateTable"
        Me.StateTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtZip
        '
        Me.txtZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtZip.Location = New System.Drawing.Point(214, 327)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(111, 20)
        Me.txtZip.TabIndex = 18
        Me.txtZip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCountry
        '
        Me.txtCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCountry.Location = New System.Drawing.Point(80, 358)
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.Size = New System.Drawing.Size(247, 20)
        Me.txtCountry.TabIndex = 19
        Me.txtCountry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCity
        '
        Me.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCity.Location = New System.Drawing.Point(78, 296)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(247, 20)
        Me.txtCity.TabIndex = 16
        Me.txtCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAddress2
        '
        Me.txtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddress2.Location = New System.Drawing.Point(14, 210)
        Me.txtAddress2.Multiline = True
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(311, 70)
        Me.txtAddress2.TabIndex = 15
        Me.txtAddress2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAddress1
        '
        Me.txtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddress1.Location = New System.Drawing.Point(14, 113)
        Me.txtAddress1.Multiline = True
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(313, 70)
        Me.txtAddress1.TabIndex = 14
        Me.txtAddress1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCustomerName
        '
        Me.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerName.Location = New System.Drawing.Point(89, 62)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(238, 20)
        Me.txtCustomerName.TabIndex = 13
        Me.txtCustomerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboShipToID
        '
        Me.cboShipToID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipToID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipToID.DataSource = Me.AdditionalShipToBindingSource
        Me.cboShipToID.DisplayMember = "ShipToID"
        Me.cboShipToID.FormattingEnabled = True
        Me.cboShipToID.Location = New System.Drawing.Point(88, 28)
        Me.cboShipToID.Name = "cboShipToID"
        Me.cboShipToID.Size = New System.Drawing.Size(238, 21)
        Me.cboShipToID.TabIndex = 12
        Me.cboShipToID.ValueMember = "ItemID"
        '
        'AdditionalShipToBindingSource
        '
        Me.AdditionalShipToBindingSource.DataMember = "AdditionalShipTo"
        Me.AdditionalShipToBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(14, 296)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 21)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "City"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(14, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 21)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Ship To ID"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(14, 327)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 21)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "State"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(14, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 21)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Name"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(14, 358)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 21)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Country"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(14, 186)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 21)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Address 2"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(14, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 21)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Address 1"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(166, 327)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 21)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "ZIP"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gpxSearchFields
        '
        Me.gpxSearchFields.Controls.Add(Me.cboCurrencyType)
        Me.gpxSearchFields.Controls.Add(Me.Label26)
        Me.gpxSearchFields.Controls.Add(Me.Label28)
        Me.gpxSearchFields.Controls.Add(Me.cmdGenerateNew)
        Me.gpxSearchFields.Controls.Add(Me.Label1)
        Me.gpxSearchFields.Controls.Add(Me.txtThirdPartyShipper)
        Me.gpxSearchFields.Controls.Add(Me.cboShipmentNaftaKey)
        Me.gpxSearchFields.Controls.Add(Me.cboShipMethod)
        Me.gpxSearchFields.Controls.Add(Me.cboCustomerName)
        Me.gpxSearchFields.Controls.Add(Me.cboCustomerID)
        Me.gpxSearchFields.Controls.Add(Me.Label25)
        Me.gpxSearchFields.Controls.Add(Me.Label2)
        Me.gpxSearchFields.Controls.Add(Me.dtpShipDate)
        Me.gpxSearchFields.Controls.Add(Me.cboShipVia)
        Me.gpxSearchFields.Controls.Add(Me.Label4)
        Me.gpxSearchFields.Controls.Add(Me.Label3)
        Me.gpxSearchFields.Controls.Add(Me.cboDivisionID)
        Me.gpxSearchFields.Controls.Add(Me.Label12)
        Me.gpxSearchFields.Location = New System.Drawing.Point(12, 41)
        Me.gpxSearchFields.Name = "gpxSearchFields"
        Me.gpxSearchFields.Size = New System.Drawing.Size(342, 371)
        Me.gpxSearchFields.TabIndex = 0
        Me.gpxSearchFields.TabStop = False
        Me.gpxSearchFields.Text = "Shipment Data"
        '
        'cboCurrencyType
        '
        Me.cboCurrencyType.FormattingEnabled = True
        Me.cboCurrencyType.Items.AddRange(New Object() {"US DOLLARS", "CANADIAN DOLLARS"})
        Me.cboCurrencyType.Location = New System.Drawing.Point(111, 168)
        Me.cboCurrencyType.Name = "cboCurrencyType"
        Me.cboCurrencyType.Size = New System.Drawing.Size(211, 21)
        Me.cboCurrencyType.TabIndex = 7
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(14, 168)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(118, 21)
        Me.Label28.TabIndex = 44
        Me.Label28.Text = "Currency"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdGenerateNew
        '
        Me.cmdGenerateNew.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateNew.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateNew.Location = New System.Drawing.Point(109, 50)
        Me.cmdGenerateNew.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateNew.Name = "cmdGenerateNew"
        Me.cmdGenerateNew.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateNew.TabIndex = 2
        Me.cmdGenerateNew.Text = ">>"
        Me.cmdGenerateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateNew.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(14, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 21)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Customs Inv. #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipmentNaftaKey
        '
        Me.cboShipmentNaftaKey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipmentNaftaKey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipmentNaftaKey.DataSource = Me.ShipmentNaftaTableBindingSource
        Me.cboShipmentNaftaKey.DisplayMember = "ShipmentNaftaKey"
        Me.cboShipmentNaftaKey.FormattingEnabled = True
        Me.cboShipmentNaftaKey.Location = New System.Drawing.Point(138, 49)
        Me.cboShipmentNaftaKey.Name = "cboShipmentNaftaKey"
        Me.cboShipmentNaftaKey.Size = New System.Drawing.Size(184, 21)
        Me.cboShipmentNaftaKey.TabIndex = 3
        Me.cboShipmentNaftaKey.ValueMember = "ItemID"
        '
        'ShipmentNaftaTableBindingSource
        '
        Me.ShipmentNaftaTableBindingSource.DataMember = "ShipmentNaftaTable"
        Me.ShipmentNaftaTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(14, 138)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(308, 21)
        Me.cboCustomerName.TabIndex = 6
        Me.cboCustomerName.ValueMember = "ItemID"
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(84, 108)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(238, 21)
        Me.cboCustomerID.TabIndex = 5
        Me.cboCustomerID.ValueMember = "ItemID"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(14, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 21)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Customer"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpShipDate
        '
        Me.dtpShipDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpShipDate.Location = New System.Drawing.Point(138, 79)
        Me.dtpShipDate.Name = "dtpShipDate"
        Me.dtpShipDate.Size = New System.Drawing.Size(184, 20)
        Me.dtpShipDate.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(14, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 21)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Shipping Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(138, 19)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(184, 21)
        Me.cboDivisionID.TabIndex = 1
        Me.cboDivisionID.ValueMember = "ItemID"
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(14, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(106, 21)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Division ID"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxShippingDetails
        '
        Me.gpxShippingDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxShippingDetails.Controls.Add(Me.txtActualWeight)
        Me.gpxShippingDetails.Controls.Add(Me.Label18)
        Me.gpxShippingDetails.Controls.Add(Me.Label27)
        Me.gpxShippingDetails.Controls.Add(Me.txtTotalPallets)
        Me.gpxShippingDetails.Controls.Add(Me.Label16)
        Me.gpxShippingDetails.Controls.Add(Me.txtTotalBoxes)
        Me.gpxShippingDetails.Controls.Add(Me.Label15)
        Me.gpxShippingDetails.Controls.Add(Me.txtTotalAmount)
        Me.gpxShippingDetails.Controls.Add(Me.Label14)
        Me.gpxShippingDetails.Location = New System.Drawing.Point(754, 626)
        Me.gpxShippingDetails.Name = "gpxShippingDetails"
        Me.gpxShippingDetails.Size = New System.Drawing.Size(376, 139)
        Me.gpxShippingDetails.TabIndex = 32
        Me.gpxShippingDetails.TabStop = False
        Me.gpxShippingDetails.Text = "Shipping Details"
        '
        'txtActualWeight
        '
        Me.txtActualWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActualWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtActualWeight.Location = New System.Drawing.Point(101, 106)
        Me.txtActualWeight.Name = "txtActualWeight"
        Me.txtActualWeight.Size = New System.Drawing.Size(149, 20)
        Me.txtActualWeight.TabIndex = 36
        Me.txtActualWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(16, 105)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(118, 21)
        Me.Label18.TabIndex = 41
        Me.Label18.Text = "Total Weight"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.ForeColor = System.Drawing.Color.Blue
        Me.Label27.Location = New System.Drawing.Point(267, 18)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(103, 115)
        Me.Label27.TabIndex = 39
        Me.Label27.Text = "Pallets and weight you may manually enter here. To adjust # of boxes, edit the li" & _
            "nes in the datagrid."
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalPallets
        '
        Me.txtTotalPallets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPallets.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalPallets.Location = New System.Drawing.Point(101, 77)
        Me.txtTotalPallets.Name = "txtTotalPallets"
        Me.txtTotalPallets.Size = New System.Drawing.Size(149, 20)
        Me.txtTotalPallets.TabIndex = 35
        Me.txtTotalPallets.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(16, 76)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(118, 21)
        Me.Label16.TabIndex = 37
        Me.Label16.Text = "Total Pallets"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalBoxes
        '
        Me.txtTotalBoxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalBoxes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalBoxes.Enabled = False
        Me.txtTotalBoxes.Location = New System.Drawing.Point(101, 48)
        Me.txtTotalBoxes.Name = "txtTotalBoxes"
        Me.txtTotalBoxes.Size = New System.Drawing.Size(149, 20)
        Me.txtTotalBoxes.TabIndex = 34
        Me.txtTotalBoxes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(16, 47)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(118, 21)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "Total Boxes"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.BackColor = System.Drawing.Color.White
        Me.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalAmount.Location = New System.Drawing.Point(101, 19)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.Size = New System.Drawing.Size(149, 20)
        Me.txtTotalAmount.TabIndex = 33
        Me.txtTotalAmount.TabStop = False
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(16, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(118, 21)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Total Amount"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearForm
        '
        Me.cmdClearForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearForm.Location = New System.Drawing.Point(753, 771)
        Me.cmdClearForm.Name = "cmdClearForm"
        Me.cmdClearForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearForm.TabIndex = 36
        Me.cmdClearForm.Text = "Clear Form"
        Me.cmdClearForm.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(904, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 39
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(981, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 40
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1058, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 41
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ShipmentNaftaTableTableAdapter
        '
        Me.ShipmentNaftaTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'ShipMethodTableAdapter
        '
        Me.ShipMethodTableAdapter.ClearBeforeFill = True
        '
        'AdditionalShipToTableAdapter
        '
        Me.AdditionalShipToTableAdapter.ClearBeforeFill = True
        '
        'StateTableTableAdapter
        '
        Me.StateTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtLineWeight)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.txtLineBoxes)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.txtLineExtendedAmount)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtLinePrice)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtLineQuantity)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.cmdClearLine)
        Me.GroupBox1.Controls.Add(Me.cmdAddLine)
        Me.GroupBox1.Controls.Add(Me.cboPartNumber)
        Me.GroupBox1.Controls.Add(Me.cboPartDescription)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Location = New System.Drawing.Point(360, 527)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(287, 284)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Line Item"
        '
        'txtLineWeight
        '
        Me.txtLineWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineWeight.Location = New System.Drawing.Point(124, 205)
        Me.txtLineWeight.Name = "txtLineWeight"
        Me.txtLineWeight.Size = New System.Drawing.Size(148, 20)
        Me.txtLineWeight.TabIndex = 28
        Me.txtLineWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(19, 204)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(150, 21)
        Me.Label23.TabIndex = 47
        Me.Label23.Text = "Line Weight"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLineBoxes
        '
        Me.txtLineBoxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineBoxes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineBoxes.Location = New System.Drawing.Point(124, 177)
        Me.txtLineBoxes.Name = "txtLineBoxes"
        Me.txtLineBoxes.Size = New System.Drawing.Size(148, 20)
        Me.txtLineBoxes.TabIndex = 27
        Me.txtLineBoxes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(19, 176)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(150, 21)
        Me.Label24.TabIndex = 46
        Me.Label24.Text = "# of Boxes"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLineExtendedAmount
        '
        Me.txtLineExtendedAmount.BackColor = System.Drawing.Color.White
        Me.txtLineExtendedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineExtendedAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineExtendedAmount.Location = New System.Drawing.Point(124, 149)
        Me.txtLineExtendedAmount.Name = "txtLineExtendedAmount"
        Me.txtLineExtendedAmount.ReadOnly = True
        Me.txtLineExtendedAmount.Size = New System.Drawing.Size(148, 20)
        Me.txtLineExtendedAmount.TabIndex = 26
        Me.txtLineExtendedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(19, 148)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(150, 21)
        Me.Label20.TabIndex = 43
        Me.Label20.Text = "Extended Amount"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLinePrice
        '
        Me.txtLinePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinePrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLinePrice.Location = New System.Drawing.Point(124, 121)
        Me.txtLinePrice.Name = "txtLinePrice"
        Me.txtLinePrice.Size = New System.Drawing.Size(148, 20)
        Me.txtLinePrice.TabIndex = 25
        Me.txtLinePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(19, 120)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(150, 21)
        Me.Label21.TabIndex = 42
        Me.Label21.Text = "Unit Price"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLineQuantity
        '
        Me.txtLineQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineQuantity.Location = New System.Drawing.Point(124, 93)
        Me.txtLineQuantity.Name = "txtLineQuantity"
        Me.txtLineQuantity.Size = New System.Drawing.Size(148, 20)
        Me.txtLineQuantity.TabIndex = 24
        Me.txtLineQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(19, 92)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(150, 21)
        Me.Label22.TabIndex = 41
        Me.Label22.Text = "Quantity"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearLine
        '
        Me.cmdClearLine.Location = New System.Drawing.Point(201, 241)
        Me.cmdClearLine.Name = "cmdClearLine"
        Me.cmdClearLine.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearLine.TabIndex = 30
        Me.cmdClearLine.Text = "Clear"
        Me.cmdClearLine.UseVisualStyleBackColor = True
        '
        'cmdAddLine
        '
        Me.cmdAddLine.Location = New System.Drawing.Point(124, 241)
        Me.cmdAddLine.Name = "cmdAddLine"
        Me.cmdAddLine.Size = New System.Drawing.Size(71, 30)
        Me.cmdAddLine.TabIndex = 29
        Me.cmdAddLine.Text = "Add Line"
        Me.cmdAddLine.UseVisualStyleBackColor = True
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.DropDownWidth = 250
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(65, 30)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(207, 21)
        Me.cboPartNumber.TabIndex = 22
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.DropDownWidth = 300
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(19, 63)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(253, 21)
        Me.cboPartDescription.TabIndex = 23
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(19, 32)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(103, 20)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "Part #"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvShipmentNaftaLines
        '
        Me.dgvShipmentNaftaLines.AllowUserToAddRows = False
        Me.dgvShipmentNaftaLines.AllowUserToDeleteRows = False
        Me.dgvShipmentNaftaLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvShipmentNaftaLines.AutoGenerateColumns = False
        Me.dgvShipmentNaftaLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvShipmentNaftaLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShipmentNaftaLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ShipmentNaftaLineKeyColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityShippedColumn, Me.UnitPriceColumn, Me.ExtendedAmountColumn, Me.LineBoxesColumn, Me.LineWeightColumn, Me.ClassColumn, Me.ShipmentNumberColumn, Me.ShipmentLineNumberColumn, Me.ShipmentNaftaKeyColumn})
        Me.dgvShipmentNaftaLines.DataSource = Me.ShipmentNaftaLineTableBindingSource
        Me.dgvShipmentNaftaLines.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvShipmentNaftaLines.Location = New System.Drawing.Point(360, 41)
        Me.dgvShipmentNaftaLines.Name = "dgvShipmentNaftaLines"
        Me.dgvShipmentNaftaLines.Size = New System.Drawing.Size(769, 371)
        Me.dgvShipmentNaftaLines.TabIndex = 19
        Me.dgvShipmentNaftaLines.TabStop = False
        '
        'ShipmentNaftaLineKeyColumn
        '
        Me.ShipmentNaftaLineKeyColumn.DataPropertyName = "ShipmentNaftaLineKey"
        Me.ShipmentNaftaLineKeyColumn.HeaderText = "Line #"
        Me.ShipmentNaftaLineKeyColumn.Name = "ShipmentNaftaLineKeyColumn"
        Me.ShipmentNaftaLineKeyColumn.ReadOnly = True
        Me.ShipmentNaftaLineKeyColumn.Width = 60
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
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.Width = 150
        '
        'QuantityShippedColumn
        '
        Me.QuantityShippedColumn.DataPropertyName = "QuantityShipped"
        Me.QuantityShippedColumn.HeaderText = "Quantity"
        Me.QuantityShippedColumn.Name = "QuantityShippedColumn"
        Me.QuantityShippedColumn.Width = 80
        '
        'UnitPriceColumn
        '
        Me.UnitPriceColumn.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle1.Format = "N5"
        DataGridViewCellStyle1.NullValue = "0"
        Me.UnitPriceColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.UnitPriceColumn.HeaderText = "Unit Price"
        Me.UnitPriceColumn.Name = "UnitPriceColumn"
        Me.UnitPriceColumn.Width = 80
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.ExtendedAmountColumn.HeaderText = "Ext. Amount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
        Me.ExtendedAmountColumn.Width = 80
        '
        'LineBoxesColumn
        '
        Me.LineBoxesColumn.DataPropertyName = "LineBoxes"
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.LineBoxesColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.LineBoxesColumn.HeaderText = "# Boxes"
        Me.LineBoxesColumn.Name = "LineBoxesColumn"
        Me.LineBoxesColumn.Width = 80
        '
        'LineWeightColumn
        '
        Me.LineWeightColumn.DataPropertyName = "LineWeight"
        DataGridViewCellStyle4.Format = "N1"
        DataGridViewCellStyle4.NullValue = "0"
        Me.LineWeightColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.LineWeightColumn.HeaderText = "Line Weight"
        Me.LineWeightColumn.Name = "LineWeightColumn"
        Me.LineWeightColumn.Width = 80
        '
        'ClassColumn
        '
        Me.ClassColumn.DataPropertyName = "Class"
        Me.ClassColumn.HeaderText = "Class"
        Me.ClassColumn.Name = "ClassColumn"
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "Shipment #"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        Me.ShipmentNumberColumn.ReadOnly = True
        Me.ShipmentNumberColumn.Width = 80
        '
        'ShipmentLineNumberColumn
        '
        Me.ShipmentLineNumberColumn.DataPropertyName = "ShipmentLineNumber"
        Me.ShipmentLineNumberColumn.HeaderText = "ShipmentLineNumber"
        Me.ShipmentLineNumberColumn.Name = "ShipmentLineNumberColumn"
        Me.ShipmentLineNumberColumn.ReadOnly = True
        Me.ShipmentLineNumberColumn.Visible = False
        '
        'ShipmentNaftaKeyColumn
        '
        Me.ShipmentNaftaKeyColumn.DataPropertyName = "ShipmentNaftaKey"
        Me.ShipmentNaftaKeyColumn.HeaderText = "ShipmentNaftaKey"
        Me.ShipmentNaftaKeyColumn.Name = "ShipmentNaftaKeyColumn"
        Me.ShipmentNaftaKeyColumn.ReadOnly = True
        Me.ShipmentNaftaKeyColumn.Visible = False
        '
        'ShipmentNaftaLineTableBindingSource
        '
        Me.ShipmentNaftaLineTableBindingSource.DataMember = "ShipmentNaftaLineTable"
        Me.ShipmentNaftaLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ShipmentNaftaLineTableTableAdapter
        '
        Me.ShipmentNaftaLineTableTableAdapter.ClearBeforeFill = True
        '
        'cmdAddShipments
        '
        Me.cmdAddShipments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddShipments.ForeColor = System.Drawing.Color.Blue
        Me.cmdAddShipments.Location = New System.Drawing.Point(362, 430)
        Me.cmdAddShipments.Name = "cmdAddShipments"
        Me.cmdAddShipments.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddShipments.TabIndex = 20
        Me.cmdAddShipments.Text = "Add Shipments"
        Me.cmdAddShipments.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(827, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 38
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteLine.ForeColor = System.Drawing.Color.Blue
        Me.cmdDeleteLine.Location = New System.Drawing.Point(439, 430)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteLine.TabIndex = 21
        Me.cmdDeleteLine.Text = "Delete Line"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'txtSpecialInstructions
        '
        Me.txtSpecialInstructions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSpecialInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSpecialInstructions.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSpecialInstructions.Location = New System.Drawing.Point(754, 558)
        Me.txtSpecialInstructions.Multiline = True
        Me.txtSpecialInstructions.Name = "txtSpecialInstructions"
        Me.txtSpecialInstructions.Size = New System.Drawing.Size(376, 63)
        Me.txtSpecialInstructions.TabIndex = 31
        Me.txtSpecialInstructions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(751, 534)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(379, 21)
        Me.Label17.TabIndex = 43
        Me.Label17.Text = "Special Instructions (Broker Name, etc.)"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(750, 418)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(379, 21)
        Me.Label29.TabIndex = 45
        Me.Label29.Text = "Billing Address"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBillToAddress
        '
        Me.txtBillToAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBillToAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBillToAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBillToAddress.Location = New System.Drawing.Point(753, 442)
        Me.txtBillToAddress.Multiline = True
        Me.txtBillToAddress.Name = "txtBillToAddress"
        Me.txtBillToAddress.Size = New System.Drawing.Size(376, 86)
        Me.txtBillToAddress.TabIndex = 44
        Me.txtBillToAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label30.ForeColor = System.Drawing.Color.Blue
        Me.Label30.Location = New System.Drawing.Point(516, 433)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(103, 34)
        Me.Label30.TabIndex = 46
        Me.Label30.Text = "Select line in datagrid to delete."
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ShipmentNaftaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.txtBillToAddress)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtSpecialInstructions)
        Me.Controls.Add(Me.cmdDeleteLine)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdAddShipments)
        Me.Controls.Add(Me.dgvShipmentNaftaLines)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdClearForm)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxShippingDetails)
        Me.Controls.Add(Me.gpxShipTo)
        Me.Controls.Add(Me.gpxSearchFields)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ShipmentNaftaForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Customs Commercial Invoice Form"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxShipTo.ResumeLayout(False)
        Me.gpxShipTo.PerformLayout()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdditionalShipToBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxSearchFields.ResumeLayout(False)
        Me.gpxSearchFields.PerformLayout()
        CType(Me.ShipmentNaftaTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxShippingDetails.ResumeLayout(False)
        Me.gpxShippingDetails.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvShipmentNaftaLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentNaftaLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtThirdPartyShipper As System.Windows.Forms.TextBox
    Friend WithEvents cboShipMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cboShipVia As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gpxShipTo As System.Windows.Forms.GroupBox
    Friend WithEvents cboState As System.Windows.Forms.ComboBox
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents txtCountry As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents cboShipToID As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents gpxSearchFields As System.Windows.Forms.GroupBox
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpShipDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents gpxShippingDetails As System.Windows.Forms.GroupBox
    Friend WithEvents txtActualWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPallets As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTotalBoxes As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmdClearForm As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboShipmentNaftaKey As System.Windows.Forms.ComboBox
    Friend WithEvents cmdGenerateNew As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ShipmentNaftaTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentNaftaTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentNaftaTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents ShipMethodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipMethodTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
    Friend WithEvents AdditionalShipToBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AdditionalShipToTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AdditionalShipToTableAdapter
    Friend WithEvents StateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StateTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLineExtendedAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtLinePrice As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtLineQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmdClearLine As System.Windows.Forms.Button
    Friend WithEvents cmdAddLine As System.Windows.Forms.Button
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents dgvShipmentNaftaLines As System.Windows.Forms.DataGridView
    Friend WithEvents ShipmentNaftaLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentNaftaLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentNaftaLineTableTableAdapter
    Friend WithEvents txtLineWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtLineBoxes As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cmdAddShipments As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents PrintNAFTADocsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSpecialInstructions As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cboCurrencyType As System.Windows.Forms.ComboBox
    Friend WithEvents PrintCustomsInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintNAFTAFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtBillToAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents ShipmentNaftaLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityShippedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitPriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineBoxesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNaftaKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintELFFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
