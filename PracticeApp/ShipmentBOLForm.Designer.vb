<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShipmentBOLForm
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveBOLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteBOLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintBOLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearBOLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SelectLast10DaysToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SelectLast20DaysToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SelectLast30DaysToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxSearchFields = New System.Windows.Forms.GroupBox
        Me.cmdGenerateNewBOL = New System.Windows.Forms.Button
        Me.cboBOLNumber = New System.Windows.Forms.ComboBox
        Me.ShipmentBOLTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.dtpShipDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboShipVia = New System.Windows.Forms.ComboBox
        Me.ShipMethodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgvShipmentHeaders = New System.Windows.Forms.DataGridView
        Me.SelectShipments = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.PickTicketNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipViaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumberOfPalletsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DoubleStackedPalletsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletsOnFloorColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesmanIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SpecialInstructionsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightQuoteNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightQuoteAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightActualAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipAddress1Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipAddress2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipCityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipStateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipZipColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipCountryColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ThirdPartyShipperColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TaxTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShipmentHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
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
        Me.gpxShippingDetails = New System.Windows.Forms.GroupBox
        Me.txtNumberOfPalletsOnFloor = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtNumberOfDoublePallets = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtActualWeight = New System.Windows.Forms.TextBox
        Me.txtNumberOfShipments = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtEstimatedWeight = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtTotalPallets = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtTotalBoxes = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtFreightQuoteNumber = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtSpecialInstructions = New System.Windows.Forms.TextBox
        Me.tabShipmentControl = New System.Windows.Forms.TabControl
        Me.tabSelectShipments = New System.Windows.Forms.TabPage
        Me.Label22 = New System.Windows.Forms.Label
        Me.cmdAddLines = New System.Windows.Forms.Button
        Me.tabBOLLines = New System.Windows.Forms.TabPage
        Me.dgvShipmentLineBOL = New System.Windows.Forms.DataGridView
        Me.ShipmentBOLNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalWeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumberOfPalletsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumberOfBoxesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumberOfDoubleStackedPalletsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumberOfPalletsOnFloorDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentBOLLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdRemoveUncheckAll = New System.Windows.Forms.Button
        Me.cmdRemoveCheckAll = New System.Windows.Forms.Button
        Me.Label23 = New System.Windows.Forms.Label
        Me.cmdRemoveShipments = New System.Windows.Forms.Button
        Me.StateTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
        Me.AdditionalShipToTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AdditionalShipToTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.ShipMethodTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
        Me.ShipmentBOLLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentBOLLineTableTableAdapter
        Me.cmdClearForm = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtThirdPartyShipper = New System.Windows.Forms.TextBox
        Me.cboShipMethod = New System.Windows.Forms.ComboBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.ShipmentBOLTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentBOLTableTableAdapter
        Me.cmdPrintShippingLabel = New System.Windows.Forms.Button
        Me.SelectToRemove = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.BOLShipmentBOLNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BOShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BOLDivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BOLTotalWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BOLNumberOfPalletsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumberOfDoubleStackedPallets = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.llAddPresetComments = New System.Windows.Forms.LinkLabel
        Me.MenuStrip1.SuspendLayout()
        Me.gpxSearchFields.SuspendLayout()
        CType(Me.ShipmentBOLTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvShipmentHeaders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxShipTo.SuspendLayout()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdditionalShipToBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxShippingDetails.SuspendLayout()
        Me.tabShipmentControl.SuspendLayout()
        Me.tabSelectShipments.SuspendLayout()
        Me.tabBOLLines.SuspendLayout()
        CType(Me.dgvShipmentLineBOL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentBOLLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveBOLToolStripMenuItem, Me.DeleteBOLToolStripMenuItem, Me.PrintBOLToolStripMenuItem, Me.ClearBOLToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveBOLToolStripMenuItem
        '
        Me.SaveBOLToolStripMenuItem.Name = "SaveBOLToolStripMenuItem"
        Me.SaveBOLToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.SaveBOLToolStripMenuItem.Text = "Save BOL"
        '
        'DeleteBOLToolStripMenuItem
        '
        Me.DeleteBOLToolStripMenuItem.Name = "DeleteBOLToolStripMenuItem"
        Me.DeleteBOLToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.DeleteBOLToolStripMenuItem.Text = "Delete BOL"
        '
        'PrintBOLToolStripMenuItem
        '
        Me.PrintBOLToolStripMenuItem.Name = "PrintBOLToolStripMenuItem"
        Me.PrintBOLToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.PrintBOLToolStripMenuItem.Text = "Print BOL"
        '
        'ClearBOLToolStripMenuItem
        '
        Me.ClearBOLToolStripMenuItem.Name = "ClearBOLToolStripMenuItem"
        Me.ClearBOLToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.ClearBOLToolStripMenuItem.Text = "Clear BOL"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectLast10DaysToolStripMenuItem, Me.SelectLast20DaysToolStripMenuItem, Me.SelectLast30DaysToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'SelectLast10DaysToolStripMenuItem
        '
        Me.SelectLast10DaysToolStripMenuItem.Name = "SelectLast10DaysToolStripMenuItem"
        Me.SelectLast10DaysToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SelectLast10DaysToolStripMenuItem.Text = "Select Last 10 Days"
        '
        'SelectLast20DaysToolStripMenuItem
        '
        Me.SelectLast20DaysToolStripMenuItem.Name = "SelectLast20DaysToolStripMenuItem"
        Me.SelectLast20DaysToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SelectLast20DaysToolStripMenuItem.Text = "Select Last 20 Days"
        '
        'SelectLast30DaysToolStripMenuItem
        '
        Me.SelectLast30DaysToolStripMenuItem.Name = "SelectLast30DaysToolStripMenuItem"
        Me.SelectLast30DaysToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SelectLast30DaysToolStripMenuItem.Text = "Select Last 30 Days"
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
        'gpxSearchFields
        '
        Me.gpxSearchFields.Controls.Add(Me.cmdGenerateNewBOL)
        Me.gpxSearchFields.Controls.Add(Me.cboBOLNumber)
        Me.gpxSearchFields.Controls.Add(Me.cboCustomerName)
        Me.gpxSearchFields.Controls.Add(Me.cboCustomerID)
        Me.gpxSearchFields.Controls.Add(Me.Label2)
        Me.gpxSearchFields.Controls.Add(Me.Label20)
        Me.gpxSearchFields.Controls.Add(Me.dtpShipDate)
        Me.gpxSearchFields.Controls.Add(Me.Label4)
        Me.gpxSearchFields.Controls.Add(Me.cboDivisionID)
        Me.gpxSearchFields.Controls.Add(Me.Label12)
        Me.gpxSearchFields.Location = New System.Drawing.Point(29, 41)
        Me.gpxSearchFields.Name = "gpxSearchFields"
        Me.gpxSearchFields.Size = New System.Drawing.Size(342, 174)
        Me.gpxSearchFields.TabIndex = 0
        Me.gpxSearchFields.TabStop = False
        Me.gpxSearchFields.Text = "Shipment Data"
        '
        'cmdGenerateNewBOL
        '
        Me.cmdGenerateNewBOL.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateNewBOL.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateNewBOL.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateNewBOL.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateNewBOL.Location = New System.Drawing.Point(106, 20)
        Me.cmdGenerateNewBOL.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateNewBOL.Name = "cmdGenerateNewBOL"
        Me.cmdGenerateNewBOL.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateNewBOL.TabIndex = 0
        Me.cmdGenerateNewBOL.Text = ">>"
        Me.cmdGenerateNewBOL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateNewBOL.UseVisualStyleBackColor = False
        '
        'cboBOLNumber
        '
        Me.cboBOLNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBOLNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBOLNumber.DataSource = Me.ShipmentBOLTableBindingSource
        Me.cboBOLNumber.DisplayMember = "ShipmentBOLNumber"
        Me.cboBOLNumber.FormattingEnabled = True
        Me.cboBOLNumber.Location = New System.Drawing.Point(138, 20)
        Me.cboBOLNumber.Name = "cboBOLNumber"
        Me.cboBOLNumber.Size = New System.Drawing.Size(184, 21)
        Me.cboBOLNumber.TabIndex = 1
        Me.cboBOLNumber.ValueMember = "ItemID"
        '
        'ShipmentBOLTableBindingSource
        '
        Me.ShipmentBOLTableBindingSource.DataMember = "ShipmentBOLTable"
        Me.ShipmentBOLTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(19, 138)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(303, 21)
        Me.cboCustomerName.TabIndex = 5
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
        Me.cboCustomerID.TabIndex = 4
        Me.cboCustomerID.ValueMember = "ItemID"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 21)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Customer"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(19, 20)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(103, 21)
        Me.Label20.TabIndex = 17
        Me.Label20.Text = "BOL Number"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpShipDate
        '
        Me.dtpShipDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpShipDate.Location = New System.Drawing.Point(138, 79)
        Me.dtpShipDate.Name = "dtpShipDate"
        Me.dtpShipDate.Size = New System.Drawing.Size(184, 20)
        Me.dtpShipDate.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(19, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 21)
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
        Me.cboDivisionID.Location = New System.Drawing.Point(138, 49)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(184, 21)
        Me.cboDivisionID.TabIndex = 2
        Me.cboDivisionID.ValueMember = "ItemID"
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(19, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(106, 21)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Division ID"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipVia
        '
        Me.cboShipVia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipVia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipVia.DataSource = Me.ShipMethodBindingSource
        Me.cboShipVia.DisplayMember = "ShipMethID"
        Me.cboShipVia.FormattingEnabled = True
        Me.cboShipVia.Location = New System.Drawing.Point(88, 19)
        Me.cboShipVia.MaxLength = 50
        Me.cboShipVia.Name = "cboShipVia"
        Me.cboShipVia.Size = New System.Drawing.Size(234, 21)
        Me.cboShipVia.TabIndex = 7
        Me.cboShipVia.ValueMember = "ItemID"
        '
        'ShipMethodBindingSource
        '
        Me.ShipMethodBindingSource.DataMember = "ShipMethod"
        Me.ShipMethodBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(11, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 21)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Ship Via"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvShipmentHeaders
        '
        Me.dgvShipmentHeaders.AllowUserToAddRows = False
        Me.dgvShipmentHeaders.AllowUserToDeleteRows = False
        Me.dgvShipmentHeaders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvShipmentHeaders.AutoGenerateColumns = False
        Me.dgvShipmentHeaders.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvShipmentHeaders.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvShipmentHeaders.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvShipmentHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShipmentHeaders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectShipments, Me.PickTicketNumberColumn, Me.ShipmentNumberColumn, Me.CustomerIDColumn, Me.SalesOrderKeyColumn, Me.ShipDateColumn, Me.ShipViaColumn, Me.NumberOfPalletsColumn, Me.DoubleStackedPalletsColumn, Me.PalletsOnFloorColumn, Me.ShippingWeightColumn, Me.SalesmanIDColumn, Me.CommentColumn, Me.SpecialInstructionsColumn, Me.PRONumberColumn, Me.DivisionIDColumn, Me.FreightQuoteNumberColumn, Me.FreightQuoteAmountColumn, Me.FreightActualAmountColumn, Me.ShipToIDColumn, Me.ShipToNameColumn, Me.ShipAddress1Column, Me.ShipAddress2Column, Me.ShipCityColumn, Me.ShipStateColumn, Me.ShipZipColumn, Me.ShipCountryColumn, Me.ThirdPartyShipperColumn, Me.CustomerPOColumn, Me.ShipmentStatusColumn, Me.ProductTotalColumn, Me.TaxTotalColumn, Me.ShipmentTotalColumn, Me.BatchNumberColumn})
        Me.dgvShipmentHeaders.DataSource = Me.ShipmentHeaderTableBindingSource
        Me.dgvShipmentHeaders.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvShipmentHeaders.Location = New System.Drawing.Point(0, 0)
        Me.dgvShipmentHeaders.Name = "dgvShipmentHeaders"
        Me.dgvShipmentHeaders.Size = New System.Drawing.Size(733, 437)
        Me.dgvShipmentHeaders.TabIndex = 2
        '
        'SelectShipments
        '
        Me.SelectShipments.FalseValue = "UNSELECTED"
        Me.SelectShipments.HeaderText = "Select"
        Me.SelectShipments.Name = "SelectShipments"
        Me.SelectShipments.TrueValue = "SELECTED"
        Me.SelectShipments.Width = 60
        '
        'PickTicketNumberColumn
        '
        Me.PickTicketNumberColumn.DataPropertyName = "PickTicketNumber"
        Me.PickTicketNumberColumn.HeaderText = "PT #"
        Me.PickTicketNumberColumn.Name = "PickTicketNumberColumn"
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "Shipment #"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        '
        'SalesOrderKeyColumn
        '
        Me.SalesOrderKeyColumn.DataPropertyName = "SalesOrderKey"
        Me.SalesOrderKeyColumn.HeaderText = "SO #"
        Me.SalesOrderKeyColumn.Name = "SalesOrderKeyColumn"
        '
        'ShipDateColumn
        '
        Me.ShipDateColumn.DataPropertyName = "ShipDate"
        Me.ShipDateColumn.HeaderText = "Ship Date"
        Me.ShipDateColumn.Name = "ShipDateColumn"
        '
        'ShipViaColumn
        '
        Me.ShipViaColumn.DataPropertyName = "ShipVia"
        Me.ShipViaColumn.HeaderText = "Ship Via"
        Me.ShipViaColumn.Name = "ShipViaColumn"
        '
        'NumberOfPalletsColumn
        '
        Me.NumberOfPalletsColumn.DataPropertyName = "NumberOfPallets"
        Me.NumberOfPalletsColumn.HeaderText = "# Of Pallets"
        Me.NumberOfPalletsColumn.Name = "NumberOfPalletsColumn"
        '
        'DoubleStackedPalletsColumn
        '
        Me.DoubleStackedPalletsColumn.DataPropertyName = "DoubleStackedPallets"
        Me.DoubleStackedPalletsColumn.HeaderText = "Double Stacked Pallets"
        Me.DoubleStackedPalletsColumn.Name = "DoubleStackedPalletsColumn"
        '
        'PalletsOnFloorColumn
        '
        Me.PalletsOnFloorColumn.DataPropertyName = "PalletsOnFloor"
        Me.PalletsOnFloorColumn.HeaderText = "Pallets On Floor"
        Me.PalletsOnFloorColumn.Name = "PalletsOnFloorColumn"
        '
        'ShippingWeightColumn
        '
        Me.ShippingWeightColumn.DataPropertyName = "ShippingWeight"
        Me.ShippingWeightColumn.HeaderText = "Shipping Weight"
        Me.ShippingWeightColumn.Name = "ShippingWeightColumn"
        '
        'SalesmanIDColumn
        '
        Me.SalesmanIDColumn.DataPropertyName = "SalesmanID"
        Me.SalesmanIDColumn.HeaderText = "Salesman"
        Me.SalesmanIDColumn.Name = "SalesmanIDColumn"
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'SpecialInstructionsColumn
        '
        Me.SpecialInstructionsColumn.DataPropertyName = "SpecialInstructions"
        Me.SpecialInstructionsColumn.HeaderText = "Special Instructions"
        Me.SpecialInstructionsColumn.Name = "SpecialInstructionsColumn"
        '
        'PRONumberColumn
        '
        Me.PRONumberColumn.DataPropertyName = "PRONumber"
        Me.PRONumberColumn.HeaderText = "PRO #"
        Me.PRONumberColumn.Name = "PRONumberColumn"
        Me.PRONumberColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'FreightQuoteNumberColumn
        '
        Me.FreightQuoteNumberColumn.DataPropertyName = "FreightQuoteNumber"
        Me.FreightQuoteNumberColumn.HeaderText = "FreightQuoteNumber"
        Me.FreightQuoteNumberColumn.Name = "FreightQuoteNumberColumn"
        Me.FreightQuoteNumberColumn.Visible = False
        '
        'FreightQuoteAmountColumn
        '
        Me.FreightQuoteAmountColumn.DataPropertyName = "FreightQuoteAmount"
        Me.FreightQuoteAmountColumn.HeaderText = "FreightQuoteAmount"
        Me.FreightQuoteAmountColumn.Name = "FreightQuoteAmountColumn"
        Me.FreightQuoteAmountColumn.Visible = False
        '
        'FreightActualAmountColumn
        '
        Me.FreightActualAmountColumn.DataPropertyName = "FreightActualAmount"
        Me.FreightActualAmountColumn.HeaderText = "FreightActualAmount"
        Me.FreightActualAmountColumn.Name = "FreightActualAmountColumn"
        Me.FreightActualAmountColumn.Visible = False
        '
        'ShipToIDColumn
        '
        Me.ShipToIDColumn.DataPropertyName = "ShipToID"
        Me.ShipToIDColumn.HeaderText = "ShipToID"
        Me.ShipToIDColumn.Name = "ShipToIDColumn"
        Me.ShipToIDColumn.Visible = False
        '
        'ShipToNameColumn
        '
        Me.ShipToNameColumn.DataPropertyName = "ShipToName"
        Me.ShipToNameColumn.HeaderText = "Ship To Name"
        Me.ShipToNameColumn.Name = "ShipToNameColumn"
        Me.ShipToNameColumn.Visible = False
        '
        'ShipAddress1Column
        '
        Me.ShipAddress1Column.DataPropertyName = "ShipAddress1"
        Me.ShipAddress1Column.HeaderText = "ShipAddress1"
        Me.ShipAddress1Column.Name = "ShipAddress1Column"
        Me.ShipAddress1Column.Visible = False
        '
        'ShipAddress2Column
        '
        Me.ShipAddress2Column.DataPropertyName = "ShipAddress2"
        Me.ShipAddress2Column.HeaderText = "ShipAddress2"
        Me.ShipAddress2Column.Name = "ShipAddress2Column"
        Me.ShipAddress2Column.Visible = False
        '
        'ShipCityColumn
        '
        Me.ShipCityColumn.DataPropertyName = "ShipCity"
        Me.ShipCityColumn.HeaderText = "ShipCity"
        Me.ShipCityColumn.Name = "ShipCityColumn"
        Me.ShipCityColumn.Visible = False
        '
        'ShipStateColumn
        '
        Me.ShipStateColumn.DataPropertyName = "ShipState"
        Me.ShipStateColumn.HeaderText = "ShipState"
        Me.ShipStateColumn.Name = "ShipStateColumn"
        Me.ShipStateColumn.Visible = False
        '
        'ShipZipColumn
        '
        Me.ShipZipColumn.DataPropertyName = "ShipZip"
        Me.ShipZipColumn.HeaderText = "ShipZip"
        Me.ShipZipColumn.Name = "ShipZipColumn"
        Me.ShipZipColumn.Visible = False
        '
        'ShipCountryColumn
        '
        Me.ShipCountryColumn.DataPropertyName = "ShipCountry"
        Me.ShipCountryColumn.HeaderText = "ShipCountry"
        Me.ShipCountryColumn.Name = "ShipCountryColumn"
        Me.ShipCountryColumn.Visible = False
        '
        'ThirdPartyShipperColumn
        '
        Me.ThirdPartyShipperColumn.DataPropertyName = "ThirdPartyShipper"
        Me.ThirdPartyShipperColumn.HeaderText = "ThirdPartyShipper"
        Me.ThirdPartyShipperColumn.Name = "ThirdPartyShipperColumn"
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.HeaderText = "CustomerPO"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        Me.CustomerPOColumn.Visible = False
        '
        'ShipmentStatusColumn
        '
        Me.ShipmentStatusColumn.DataPropertyName = "ShipmentStatus"
        Me.ShipmentStatusColumn.HeaderText = "ShipmentStatus"
        Me.ShipmentStatusColumn.Name = "ShipmentStatusColumn"
        Me.ShipmentStatusColumn.Visible = False
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        Me.ProductTotalColumn.HeaderText = "ProductTotal"
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        Me.ProductTotalColumn.Visible = False
        '
        'TaxTotalColumn
        '
        Me.TaxTotalColumn.DataPropertyName = "TaxTotal"
        Me.TaxTotalColumn.HeaderText = "TaxTotal"
        Me.TaxTotalColumn.Name = "TaxTotalColumn"
        Me.TaxTotalColumn.Visible = False
        '
        'ShipmentTotalColumn
        '
        Me.ShipmentTotalColumn.DataPropertyName = "ShipmentTotal"
        Me.ShipmentTotalColumn.HeaderText = "ShipmentTotal"
        Me.ShipmentTotalColumn.Name = "ShipmentTotalColumn"
        Me.ShipmentTotalColumn.Visible = False
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "BatchNumber"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.Visible = False
        '
        'ShipmentHeaderTableBindingSource
        '
        Me.ShipmentHeaderTableBindingSource.DataMember = "ShipmentHeaderTable"
        Me.ShipmentHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ShipmentHeaderTableTableAdapter
        '
        Me.ShipmentHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(979, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 34
        Me.cmdPrint.Text = "Print BOL"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1058, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 35
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.ForeColor = System.Drawing.Color.Black
        Me.cmdSave.Location = New System.Drawing.Point(821, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 32
        Me.cmdSave.Text = "Save BOL"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(900, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 33
        Me.cmdDelete.Text = "Delete BOL"
        Me.cmdDelete.UseVisualStyleBackColor = True
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
        Me.gpxShipTo.Location = New System.Drawing.Point(29, 420)
        Me.gpxShipTo.Name = "gpxShipTo"
        Me.gpxShipTo.Size = New System.Drawing.Size(342, 393)
        Me.gpxShipTo.TabIndex = 10
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
        Me.cboState.Location = New System.Drawing.Point(79, 330)
        Me.cboState.Name = "cboState"
        Me.cboState.Size = New System.Drawing.Size(80, 21)
        Me.cboState.TabIndex = 16
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
        Me.txtZip.Location = New System.Drawing.Point(215, 331)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(111, 20)
        Me.txtZip.TabIndex = 17
        '
        'txtCountry
        '
        Me.txtCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCountry.Location = New System.Drawing.Point(79, 361)
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.Size = New System.Drawing.Size(247, 20)
        Me.txtCountry.TabIndex = 18
        '
        'txtCity
        '
        Me.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCity.Location = New System.Drawing.Point(79, 299)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(247, 20)
        Me.txtCity.TabIndex = 15
        '
        'txtAddress2
        '
        Me.txtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddress2.Location = New System.Drawing.Point(15, 212)
        Me.txtAddress2.Multiline = True
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(311, 71)
        Me.txtAddress2.TabIndex = 14
        '
        'txtAddress1
        '
        Me.txtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddress1.Location = New System.Drawing.Point(15, 109)
        Me.txtAddress1.Multiline = True
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(311, 71)
        Me.txtAddress1.TabIndex = 13
        '
        'txtCustomerName
        '
        Me.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerName.Location = New System.Drawing.Point(88, 62)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(238, 20)
        Me.txtCustomerName.TabIndex = 12
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
        Me.cboShipToID.TabIndex = 11
        Me.cboShipToID.ValueMember = "ItemID"
        '
        'AdditionalShipToBindingSource
        '
        Me.AdditionalShipToBindingSource.DataMember = "AdditionalShipTo"
        Me.AdditionalShipToBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(17, 299)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 21)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "City"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(17, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 21)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Ship To ID"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(17, 330)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 21)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "State"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 21)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Name"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 361)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 21)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Country"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 188)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 21)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Address 2"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 21)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Address 1"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(165, 330)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 21)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "ZIP"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gpxShippingDetails
        '
        Me.gpxShippingDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxShippingDetails.Controls.Add(Me.txtNumberOfPalletsOnFloor)
        Me.gpxShippingDetails.Controls.Add(Me.Label24)
        Me.gpxShippingDetails.Controls.Add(Me.txtNumberOfDoublePallets)
        Me.gpxShippingDetails.Controls.Add(Me.Label1)
        Me.gpxShippingDetails.Controls.Add(Me.txtActualWeight)
        Me.gpxShippingDetails.Controls.Add(Me.txtNumberOfShipments)
        Me.gpxShippingDetails.Controls.Add(Me.Label18)
        Me.gpxShippingDetails.Controls.Add(Me.Label21)
        Me.gpxShippingDetails.Controls.Add(Me.txtEstimatedWeight)
        Me.gpxShippingDetails.Controls.Add(Me.Label17)
        Me.gpxShippingDetails.Controls.Add(Me.txtTotalPallets)
        Me.gpxShippingDetails.Controls.Add(Me.Label16)
        Me.gpxShippingDetails.Controls.Add(Me.txtTotalBoxes)
        Me.gpxShippingDetails.Controls.Add(Me.Label15)
        Me.gpxShippingDetails.Controls.Add(Me.txtFreightQuoteNumber)
        Me.gpxShippingDetails.Controls.Add(Me.Label14)
        Me.gpxShippingDetails.Location = New System.Drawing.Point(393, 561)
        Me.gpxShippingDetails.Name = "gpxShippingDetails"
        Me.gpxShippingDetails.Size = New System.Drawing.Size(324, 252)
        Me.gpxShippingDetails.TabIndex = 20
        Me.gpxShippingDetails.TabStop = False
        Me.gpxShippingDetails.Text = "Shipping Details"
        '
        'txtNumberOfPalletsOnFloor
        '
        Me.txtNumberOfPalletsOnFloor.BackColor = System.Drawing.Color.White
        Me.txtNumberOfPalletsOnFloor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfPalletsOnFloor.Location = New System.Drawing.Point(145, 131)
        Me.txtNumberOfPalletsOnFloor.Name = "txtNumberOfPalletsOnFloor"
        Me.txtNumberOfPalletsOnFloor.ReadOnly = True
        Me.txtNumberOfPalletsOnFloor.Size = New System.Drawing.Size(162, 20)
        Me.txtNumberOfPalletsOnFloor.TabIndex = 25
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(12, 131)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(127, 21)
        Me.Label24.TabIndex = 45
        Me.Label24.Text = "Total Pallets On Floor:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumberOfDoublePallets
        '
        Me.txtNumberOfDoublePallets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfDoublePallets.Location = New System.Drawing.Point(145, 103)
        Me.txtNumberOfDoublePallets.Name = "txtNumberOfDoublePallets"
        Me.txtNumberOfDoublePallets.Size = New System.Drawing.Size(162, 20)
        Me.txtNumberOfDoublePallets.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 21)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Double-Stacked Pallets:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtActualWeight
        '
        Me.txtActualWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActualWeight.Location = New System.Drawing.Point(145, 187)
        Me.txtActualWeight.Name = "txtActualWeight"
        Me.txtActualWeight.Size = New System.Drawing.Size(162, 20)
        Me.txtActualWeight.TabIndex = 27
        '
        'txtNumberOfShipments
        '
        Me.txtNumberOfShipments.BackColor = System.Drawing.Color.White
        Me.txtNumberOfShipments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfShipments.Location = New System.Drawing.Point(145, 215)
        Me.txtNumberOfShipments.Name = "txtNumberOfShipments"
        Me.txtNumberOfShipments.ReadOnly = True
        Me.txtNumberOfShipments.Size = New System.Drawing.Size(162, 20)
        Me.txtNumberOfShipments.TabIndex = 28
        Me.txtNumberOfShipments.TabStop = False
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(12, 187)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(127, 21)
        Me.Label18.TabIndex = 41
        Me.Label18.Text = "Actual Weight"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(12, 215)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(127, 21)
        Me.Label21.TabIndex = 35
        Me.Label21.Text = "# of Shipments"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEstimatedWeight
        '
        Me.txtEstimatedWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEstimatedWeight.Enabled = False
        Me.txtEstimatedWeight.Location = New System.Drawing.Point(145, 159)
        Me.txtEstimatedWeight.Name = "txtEstimatedWeight"
        Me.txtEstimatedWeight.Size = New System.Drawing.Size(162, 20)
        Me.txtEstimatedWeight.TabIndex = 26
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(12, 159)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(127, 21)
        Me.Label17.TabIndex = 39
        Me.Label17.Text = "Estimated Weight"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalPallets
        '
        Me.txtTotalPallets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPallets.Location = New System.Drawing.Point(145, 75)
        Me.txtTotalPallets.Name = "txtTotalPallets"
        Me.txtTotalPallets.Size = New System.Drawing.Size(162, 20)
        Me.txtTotalPallets.TabIndex = 23
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(12, 75)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(127, 21)
        Me.Label16.TabIndex = 37
        Me.Label16.Text = "Total # Of Pallets:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalBoxes
        '
        Me.txtTotalBoxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalBoxes.Location = New System.Drawing.Point(145, 47)
        Me.txtTotalBoxes.Name = "txtTotalBoxes"
        Me.txtTotalBoxes.Size = New System.Drawing.Size(162, 20)
        Me.txtTotalBoxes.TabIndex = 22
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(12, 47)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(127, 21)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "Total Boxes"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFreightQuoteNumber
        '
        Me.txtFreightQuoteNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightQuoteNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreightQuoteNumber.Location = New System.Drawing.Point(104, 19)
        Me.txtFreightQuoteNumber.Name = "txtFreightQuoteNumber"
        Me.txtFreightQuoteNumber.Size = New System.Drawing.Size(203, 20)
        Me.txtFreightQuoteNumber.TabIndex = 21
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(12, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(127, 21)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Freight Quote #"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSpecialInstructions
        '
        Me.txtSpecialInstructions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSpecialInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSpecialInstructions.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSpecialInstructions.Location = New System.Drawing.Point(742, 585)
        Me.txtSpecialInstructions.Multiline = True
        Me.txtSpecialInstructions.Name = "txtSpecialInstructions"
        Me.txtSpecialInstructions.Size = New System.Drawing.Size(388, 134)
        Me.txtSpecialInstructions.TabIndex = 29
        '
        'tabShipmentControl
        '
        Me.tabShipmentControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabShipmentControl.Controls.Add(Me.tabSelectShipments)
        Me.tabShipmentControl.Controls.Add(Me.tabBOLLines)
        Me.tabShipmentControl.Location = New System.Drawing.Point(389, 41)
        Me.tabShipmentControl.Name = "tabShipmentControl"
        Me.tabShipmentControl.SelectedIndex = 0
        Me.tabShipmentControl.Size = New System.Drawing.Size(741, 514)
        Me.tabShipmentControl.TabIndex = 19
        '
        'tabSelectShipments
        '
        Me.tabSelectShipments.Controls.Add(Me.Label22)
        Me.tabSelectShipments.Controls.Add(Me.cmdAddLines)
        Me.tabSelectShipments.Controls.Add(Me.dgvShipmentHeaders)
        Me.tabSelectShipments.Location = New System.Drawing.Point(4, 22)
        Me.tabSelectShipments.Name = "tabSelectShipments"
        Me.tabSelectShipments.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSelectShipments.Size = New System.Drawing.Size(733, 488)
        Me.tabSelectShipments.TabIndex = 0
        Me.tabSelectShipments.Text = "Select Shipments To Add To BOL"
        Me.tabSelectShipments.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label22.ForeColor = System.Drawing.Color.Blue
        Me.Label22.Location = New System.Drawing.Point(83, 445)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(255, 35)
        Me.Label22.TabIndex = 17
        Me.Label22.Text = "Select Shipments in grid to combine into one BOL."
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAddLines
        '
        Me.cmdAddLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAddLines.Location = New System.Drawing.Point(6, 444)
        Me.cmdAddLines.Name = "cmdAddLines"
        Me.cmdAddLines.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddLines.TabIndex = 19
        Me.cmdAddLines.Text = "Add Shipments"
        Me.cmdAddLines.UseVisualStyleBackColor = True
        '
        'tabBOLLines
        '
        Me.tabBOLLines.Controls.Add(Me.dgvShipmentLineBOL)
        Me.tabBOLLines.Controls.Add(Me.cmdRemoveUncheckAll)
        Me.tabBOLLines.Controls.Add(Me.cmdRemoveCheckAll)
        Me.tabBOLLines.Controls.Add(Me.Label23)
        Me.tabBOLLines.Controls.Add(Me.cmdRemoveShipments)
        Me.tabBOLLines.Location = New System.Drawing.Point(4, 22)
        Me.tabBOLLines.Name = "tabBOLLines"
        Me.tabBOLLines.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBOLLines.Size = New System.Drawing.Size(733, 488)
        Me.tabBOLLines.TabIndex = 1
        Me.tabBOLLines.Text = "Shipments on BOL"
        Me.tabBOLLines.UseVisualStyleBackColor = True
        '
        'dgvShipmentLineBOL
        '
        Me.dgvShipmentLineBOL.AllowUserToAddRows = False
        Me.dgvShipmentLineBOL.AllowUserToDeleteRows = False
        Me.dgvShipmentLineBOL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvShipmentLineBOL.AutoGenerateColumns = False
        Me.dgvShipmentLineBOL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvShipmentLineBOL.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvShipmentLineBOL.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvShipmentLineBOL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShipmentLineBOL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ShipmentBOLNumberDataGridViewTextBoxColumn, Me.ShipmentNumberDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn, Me.TotalWeightDataGridViewTextBoxColumn, Me.NumberOfPalletsDataGridViewTextBoxColumn, Me.NumberOfBoxesDataGridViewTextBoxColumn, Me.NumberOfDoubleStackedPalletsDataGridViewTextBoxColumn, Me.NumberOfPalletsOnFloorDataGridViewTextBoxColumn})
        Me.dgvShipmentLineBOL.DataSource = Me.ShipmentBOLLineTableBindingSource
        Me.dgvShipmentLineBOL.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvShipmentLineBOL.Location = New System.Drawing.Point(3, 6)
        Me.dgvShipmentLineBOL.Name = "dgvShipmentLineBOL"
        Me.dgvShipmentLineBOL.Size = New System.Drawing.Size(624, 432)
        Me.dgvShipmentLineBOL.TabIndex = 28
        Me.dgvShipmentLineBOL.TabStop = False
        '
        'ShipmentBOLNumberDataGridViewTextBoxColumn
        '
        Me.ShipmentBOLNumberDataGridViewTextBoxColumn.DataPropertyName = "ShipmentBOLNumber"
        Me.ShipmentBOLNumberDataGridViewTextBoxColumn.HeaderText = "ShipmentBOLNumber"
        Me.ShipmentBOLNumberDataGridViewTextBoxColumn.Name = "ShipmentBOLNumberDataGridViewTextBoxColumn"
        '
        'ShipmentNumberDataGridViewTextBoxColumn
        '
        Me.ShipmentNumberDataGridViewTextBoxColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberDataGridViewTextBoxColumn.HeaderText = "ShipmentNumber"
        Me.ShipmentNumberDataGridViewTextBoxColumn.Name = "ShipmentNumberDataGridViewTextBoxColumn"
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        '
        'TotalWeightDataGridViewTextBoxColumn
        '
        Me.TotalWeightDataGridViewTextBoxColumn.DataPropertyName = "TotalWeight"
        Me.TotalWeightDataGridViewTextBoxColumn.HeaderText = "TotalWeight"
        Me.TotalWeightDataGridViewTextBoxColumn.Name = "TotalWeightDataGridViewTextBoxColumn"
        '
        'NumberOfPalletsDataGridViewTextBoxColumn
        '
        Me.NumberOfPalletsDataGridViewTextBoxColumn.DataPropertyName = "NumberOfPallets"
        Me.NumberOfPalletsDataGridViewTextBoxColumn.HeaderText = "NumberOfPallets"
        Me.NumberOfPalletsDataGridViewTextBoxColumn.Name = "NumberOfPalletsDataGridViewTextBoxColumn"
        '
        'NumberOfBoxesDataGridViewTextBoxColumn
        '
        Me.NumberOfBoxesDataGridViewTextBoxColumn.DataPropertyName = "NumberOfBoxes"
        Me.NumberOfBoxesDataGridViewTextBoxColumn.HeaderText = "NumberOfBoxes"
        Me.NumberOfBoxesDataGridViewTextBoxColumn.Name = "NumberOfBoxesDataGridViewTextBoxColumn"
        '
        'NumberOfDoubleStackedPalletsDataGridViewTextBoxColumn
        '
        Me.NumberOfDoubleStackedPalletsDataGridViewTextBoxColumn.DataPropertyName = "NumberOfDoubleStackedPallets"
        Me.NumberOfDoubleStackedPalletsDataGridViewTextBoxColumn.HeaderText = "NumberOfDoubleStackedPallets"
        Me.NumberOfDoubleStackedPalletsDataGridViewTextBoxColumn.Name = "NumberOfDoubleStackedPalletsDataGridViewTextBoxColumn"
        '
        'NumberOfPalletsOnFloorDataGridViewTextBoxColumn
        '
        Me.NumberOfPalletsOnFloorDataGridViewTextBoxColumn.DataPropertyName = "NumberOfPalletsOnFloor"
        Me.NumberOfPalletsOnFloorDataGridViewTextBoxColumn.HeaderText = "NumberOfPalletsOnFloor"
        Me.NumberOfPalletsOnFloorDataGridViewTextBoxColumn.Name = "NumberOfPalletsOnFloorDataGridViewTextBoxColumn"
        '
        'ShipmentBOLLineTableBindingSource
        '
        Me.ShipmentBOLLineTableBindingSource.DataMember = "ShipmentBOLLineTable"
        Me.ShipmentBOLLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdRemoveUncheckAll
        '
        Me.cmdRemoveUncheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdRemoveUncheckAll.Location = New System.Drawing.Point(84, 445)
        Me.cmdRemoveUncheckAll.Name = "cmdRemoveUncheckAll"
        Me.cmdRemoveUncheckAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdRemoveUncheckAll.TabIndex = 30
        Me.cmdRemoveUncheckAll.Text = "Uncheck All"
        Me.cmdRemoveUncheckAll.UseVisualStyleBackColor = True
        '
        'cmdRemoveCheckAll
        '
        Me.cmdRemoveCheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdRemoveCheckAll.Location = New System.Drawing.Point(6, 445)
        Me.cmdRemoveCheckAll.Name = "cmdRemoveCheckAll"
        Me.cmdRemoveCheckAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdRemoveCheckAll.TabIndex = 29
        Me.cmdRemoveCheckAll.Text = "Check All"
        Me.cmdRemoveCheckAll.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label23.ForeColor = System.Drawing.Color.Blue
        Me.Label23.Location = New System.Drawing.Point(292, 450)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(255, 35)
        Me.Label23.TabIndex = 18
        Me.Label23.Text = "Select Shipments in grid to remove from BOL."
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdRemoveShipments
        '
        Me.cmdRemoveShipments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdRemoveShipments.Location = New System.Drawing.Point(215, 445)
        Me.cmdRemoveShipments.Name = "cmdRemoveShipments"
        Me.cmdRemoveShipments.Size = New System.Drawing.Size(71, 40)
        Me.cmdRemoveShipments.TabIndex = 17
        Me.cmdRemoveShipments.Text = "Remove Shipments"
        Me.cmdRemoveShipments.UseVisualStyleBackColor = True
        '
        'StateTableTableAdapter
        '
        Me.StateTableTableAdapter.ClearBeforeFill = True
        '
        'AdditionalShipToTableAdapter
        '
        Me.AdditionalShipToTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'ShipMethodTableAdapter
        '
        Me.ShipMethodTableAdapter.ClearBeforeFill = True
        '
        'ShipmentBOLLineTableTableAdapter
        '
        Me.ShipmentBOLLineTableTableAdapter.ClearBeforeFill = True
        '
        'cmdClearForm
        '
        Me.cmdClearForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearForm.Location = New System.Drawing.Point(742, 771)
        Me.cmdClearForm.Name = "cmdClearForm"
        Me.cmdClearForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearForm.TabIndex = 30
        Me.cmdClearForm.Text = "Clear Form"
        Me.cmdClearForm.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.txtThirdPartyShipper)
        Me.GroupBox3.Controls.Add(Me.cboShipMethod)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.cboShipVia)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(29, 221)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(342, 193)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Shipping Method"
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(11, 74)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(166, 21)
        Me.Label26.TabIndex = 45
        Me.Label26.Text = "Third Party Shipping"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtThirdPartyShipper
        '
        Me.txtThirdPartyShipper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtThirdPartyShipper.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtThirdPartyShipper.Enabled = False
        Me.txtThirdPartyShipper.Location = New System.Drawing.Point(15, 96)
        Me.txtThirdPartyShipper.Multiline = True
        Me.txtThirdPartyShipper.Name = "txtThirdPartyShipper"
        Me.txtThirdPartyShipper.Size = New System.Drawing.Size(310, 83)
        Me.txtThirdPartyShipper.TabIndex = 9
        '
        'cboShipMethod
        '
        Me.cboShipMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipMethod.DisplayMember = "ItemID"
        Me.cboShipMethod.FormattingEnabled = True
        Me.cboShipMethod.Items.AddRange(New Object() {"COLLECT", "PREPAID", "PREPAID/ADD", "THIRD PARTY", "OTHER"})
        Me.cboShipMethod.Location = New System.Drawing.Point(88, 46)
        Me.cboShipMethod.MaxLength = 50
        Me.cboShipMethod.Name = "cboShipMethod"
        Me.cboShipMethod.Size = New System.Drawing.Size(234, 21)
        Me.cboShipMethod.TabIndex = 8
        Me.cboShipMethod.ValueMember = "ItemID"
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(11, 46)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(103, 21)
        Me.Label25.TabIndex = 17
        Me.Label25.Text = "Ship Method"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ShipmentBOLTableTableAdapter
        '
        Me.ShipmentBOLTableTableAdapter.ClearBeforeFill = True
        '
        'cmdPrintShippingLabel
        '
        Me.cmdPrintShippingLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintShippingLabel.ForeColor = System.Drawing.Color.Black
        Me.cmdPrintShippingLabel.Location = New System.Drawing.Point(742, 725)
        Me.cmdPrintShippingLabel.Name = "cmdPrintShippingLabel"
        Me.cmdPrintShippingLabel.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintShippingLabel.TabIndex = 31
        Me.cmdPrintShippingLabel.Text = "Print Label"
        Me.cmdPrintShippingLabel.UseVisualStyleBackColor = True
        '
        'SelectToRemove
        '
        Me.SelectToRemove.FalseValue = "UNSELECTED"
        Me.SelectToRemove.HeaderText = "Select"
        Me.SelectToRemove.Name = "SelectToRemove"
        Me.SelectToRemove.TrueValue = "SELECTED"
        Me.SelectToRemove.Width = 118
        '
        'BOLShipmentBOLNumberColumn
        '
        Me.BOLShipmentBOLNumberColumn.DataPropertyName = "ShipmentBOLNumber"
        Me.BOLShipmentBOLNumberColumn.HeaderText = "BOLNumber"
        Me.BOLShipmentBOLNumberColumn.Name = "BOLShipmentBOLNumberColumn"
        Me.BOLShipmentBOLNumberColumn.Visible = False
        '
        'BOShipmentNumberColumn
        '
        Me.BOShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.BOShipmentNumberColumn.HeaderText = "Shipment #"
        Me.BOShipmentNumberColumn.Name = "BOShipmentNumberColumn"
        Me.BOShipmentNumberColumn.Width = 119
        '
        'BOLDivisionIDColumn
        '
        Me.BOLDivisionIDColumn.DataPropertyName = "DivisionID"
        Me.BOLDivisionIDColumn.HeaderText = "DivisionID"
        Me.BOLDivisionIDColumn.Name = "BOLDivisionIDColumn"
        Me.BOLDivisionIDColumn.Visible = False
        '
        'BOLTotalWeightColumn
        '
        Me.BOLTotalWeightColumn.DataPropertyName = "TotalWeight"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.BOLTotalWeightColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.BOLTotalWeightColumn.HeaderText = "Total Weight"
        Me.BOLTotalWeightColumn.Name = "BOLTotalWeightColumn"
        Me.BOLTotalWeightColumn.Width = 118
        '
        'BOLNumberOfPalletsColumn
        '
        Me.BOLNumberOfPalletsColumn.DataPropertyName = "NumberOfPallets"
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = "0"
        Me.BOLNumberOfPalletsColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.BOLNumberOfPalletsColumn.HeaderText = "Number Of Pallets"
        Me.BOLNumberOfPalletsColumn.Name = "BOLNumberOfPalletsColumn"
        Me.BOLNumberOfPalletsColumn.Width = 119
        '
        'NumberOfDoubleStackedPallets
        '
        Me.NumberOfDoubleStackedPallets.DataPropertyName = "NumberOfDoubleStackedPallets"
        Me.NumberOfDoubleStackedPallets.HeaderText = "Double Stacked"
        Me.NumberOfDoubleStackedPallets.Name = "NumberOfDoubleStackedPallets"
        '
        'llAddPresetComments
        '
        Me.llAddPresetComments.AutoSize = True
        Me.llAddPresetComments.Location = New System.Drawing.Point(739, 569)
        Me.llAddPresetComments.Name = "llAddPresetComments"
        Me.llAddPresetComments.Size = New System.Drawing.Size(99, 13)
        Me.llAddPresetComments.TabIndex = 36
        Me.llAddPresetComments.TabStop = True
        Me.llAddPresetComments.Text = "Special Instructions"
        '
        'ShipmentBOLForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.llAddPresetComments)
        Me.Controls.Add(Me.cmdPrintShippingLabel)
        Me.Controls.Add(Me.txtSpecialInstructions)
        Me.Controls.Add(Me.cmdClearForm)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.tabShipmentControl)
        Me.Controls.Add(Me.gpxShippingDetails)
        Me.Controls.Add(Me.gpxShipTo)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxSearchFields)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ShipmentBOLForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation BOL Form"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxSearchFields.ResumeLayout(False)
        CType(Me.ShipmentBOLTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvShipmentHeaders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxShipTo.ResumeLayout(False)
        Me.gpxShipTo.PerformLayout()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdditionalShipToBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxShippingDetails.ResumeLayout(False)
        Me.gpxShippingDetails.PerformLayout()
        Me.tabShipmentControl.ResumeLayout(False)
        Me.tabSelectShipments.ResumeLayout(False)
        Me.tabBOLLines.ResumeLayout(False)
        CType(Me.dgvShipmentLineBOL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentBOLLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxSearchFields As System.Windows.Forms.GroupBox
    Friend WithEvents dtpShipDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dgvShipmentHeaders As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ShipmentHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents gpxShipTo As System.Windows.Forms.GroupBox
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboShipVia As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gpxShippingDetails As System.Windows.Forms.GroupBox
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents txtCountry As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents cboShipToID As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboState As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEstimatedWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPallets As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTotalBoxes As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtFreightQuoteNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtActualWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtSpecialInstructions As System.Windows.Forms.TextBox
    Friend WithEvents tabShipmentControl As System.Windows.Forms.TabControl
    Friend WithEvents tabSelectShipments As System.Windows.Forms.TabPage
    Friend WithEvents tabBOLLines As System.Windows.Forms.TabPage
    Friend WithEvents cmdAddLines As System.Windows.Forms.Button
    Friend WithEvents StateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StateTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
    Friend WithEvents AdditionalShipToBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AdditionalShipToTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AdditionalShipToTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents ShipMethodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipMethodTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
    Friend WithEvents txtNumberOfShipments As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents BOLShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BOLEstimatedWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdRemoveShipments As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents dgvShipmentLineBOL As System.Windows.Forms.DataGridView
    Friend WithEvents ShipmentBOLLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentBOLLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentBOLLineTableTableAdapter
    Friend WithEvents cmdClearForm As System.Windows.Forms.Button
    Friend WithEvents SaveBOLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteBOLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintBOLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearBOLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtThirdPartyShipper As System.Windows.Forms.TextBox
    Friend WithEvents cboShipMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmdRemoveUncheckAll As System.Windows.Forms.Button
    Friend WithEvents cmdRemoveCheckAll As System.Windows.Forms.Button
    Friend WithEvents cboBOLNumber As System.Windows.Forms.ComboBox
    Friend WithEvents ShipmentBOLTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentBOLTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentBOLTableTableAdapter
    Friend WithEvents cmdGenerateNewBOL As System.Windows.Forms.Button
    Friend WithEvents cmdPrintShippingLabel As System.Windows.Forms.Button
    Friend WithEvents txtNumberOfPalletsOnFloor As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtNumberOfDoublePallets As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SelectShipments As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PickTicketNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipViaColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumberOfPalletsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DoubleStackedPalletsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletsOnFloorColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesmanIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecialInstructionsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightQuoteNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightQuoteAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightActualAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipAddress1Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipAddress2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipCityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipStateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipZipColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipCountryColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ThirdPartyShipperColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TaxTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectToRemove As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BOLShipmentBOLNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BOShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BOLDivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BOLTotalWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BOLNumberOfPalletsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumberOfDoubleStackedPallets As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentBOLNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumberOfPalletsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumberOfBoxesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumberOfDoubleStackedPalletsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumberOfPalletsOnFloorDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectLast10DaysToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectLast20DaysToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectLast30DaysToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents llAddPresetComments As System.Windows.Forms.LinkLabel
End Class
