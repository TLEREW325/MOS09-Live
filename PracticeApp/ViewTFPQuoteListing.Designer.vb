<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewTFPQuoteListing
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
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintQuoteListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReprintQuoteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxQuotationFilter = New System.Windows.Forms.GroupBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboFOXNumber = New System.Windows.Forms.ComboBox
        Me.FOXTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboQuoteNumber = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtCustomerInquiryNumber = New System.Windows.Forms.TextBox
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.cboPreparer = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdReprintQuote = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdOpenQuoteForm = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.FOXTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
        Me.dgvQuoteListing = New System.Windows.Forms.DataGridView
        Me.FOXNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuoteIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuoteDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PreparerColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContactNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PhoneColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmailColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustPartNoColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TFPPartNoColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DeliveryRequirementsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolingChargeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SetupChargeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WtPerMColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ScrapPercentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtensionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NotesCommentsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerInqueryColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InternalNotesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevisionLevelColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXItemCreatedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RepAgencyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RFQSourceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReferenceQuoteNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TFPQuotationQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TFPQuotationQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TFPQuotationQueryTableAdapter
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.gpxQuotationFilter.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvQuoteListing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TFPQuotationQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 16
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintQuoteListingToolStripMenuItem, Me.ReprintQuoteToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintQuoteListingToolStripMenuItem
        '
        Me.PrintQuoteListingToolStripMenuItem.Name = "PrintQuoteListingToolStripMenuItem"
        Me.PrintQuoteListingToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.PrintQuoteListingToolStripMenuItem.Text = "Print Quote Listing"
        '
        'ReprintQuoteToolStripMenuItem
        '
        Me.ReprintQuoteToolStripMenuItem.Name = "ReprintQuoteToolStripMenuItem"
        Me.ReprintQuoteToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ReprintQuoteToolStripMenuItem.Text = "Reprint Quote"
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
        'gpxQuotationFilter
        '
        Me.gpxQuotationFilter.Controls.Add(Me.cboDivisionID)
        Me.gpxQuotationFilter.Controls.Add(Me.cboPartNumber)
        Me.gpxQuotationFilter.Controls.Add(Me.Label9)
        Me.gpxQuotationFilter.Controls.Add(Me.cboFOXNumber)
        Me.gpxQuotationFilter.Controls.Add(Me.Label4)
        Me.gpxQuotationFilter.Controls.Add(Me.cboQuoteNumber)
        Me.gpxQuotationFilter.Controls.Add(Me.Label14)
        Me.gpxQuotationFilter.Controls.Add(Me.Label1)
        Me.gpxQuotationFilter.Controls.Add(Me.chkDateRange)
        Me.gpxQuotationFilter.Controls.Add(Me.dtpEndDate)
        Me.gpxQuotationFilter.Controls.Add(Me.cboCustomerName)
        Me.gpxQuotationFilter.Controls.Add(Me.txtCustomerInquiryNumber)
        Me.gpxQuotationFilter.Controls.Add(Me.cboCustomerID)
        Me.gpxQuotationFilter.Controls.Add(Me.dtpBeginDate)
        Me.gpxQuotationFilter.Controls.Add(Me.Label8)
        Me.gpxQuotationFilter.Controls.Add(Me.Label5)
        Me.gpxQuotationFilter.Controls.Add(Me.Label7)
        Me.gpxQuotationFilter.Controls.Add(Me.cmdClear)
        Me.gpxQuotationFilter.Controls.Add(Me.Label11)
        Me.gpxQuotationFilter.Controls.Add(Me.cmdView)
        Me.gpxQuotationFilter.Controls.Add(Me.cboPreparer)
        Me.gpxQuotationFilter.Controls.Add(Me.Label3)
        Me.gpxQuotationFilter.Controls.Add(Me.Label10)
        Me.gpxQuotationFilter.Location = New System.Drawing.Point(29, 41)
        Me.gpxQuotationFilter.Name = "gpxQuotationFilter"
        Me.gpxQuotationFilter.Size = New System.Drawing.Size(300, 626)
        Me.gpxQuotationFilter.TabIndex = 0
        Me.gpxQuotationFilter.TabStop = False
        Me.gpxQuotationFilter.Text = "View By Filters"
        '
        'cboDivisionID
        '
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(106, 31)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(179, 21)
        Me.cboDivisionID.TabIndex = 1
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(61, 383)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(225, 21)
        Me.cboPartNumber.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(15, 384)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 20)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Part #"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboFOXNumber
        '
        Me.cboFOXNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFOXNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFOXNumber.DataSource = Me.FOXTableBindingSource
        Me.cboFOXNumber.DisplayMember = "FOXNumber"
        Me.cboFOXNumber.FormattingEnabled = True
        Me.cboFOXNumber.Location = New System.Drawing.Point(108, 334)
        Me.cboFOXNumber.Name = "cboFOXNumber"
        Me.cboFOXNumber.Size = New System.Drawing.Size(178, 21)
        Me.cboFOXNumber.TabIndex = 7
        '
        'FOXTableBindingSource
        '
        Me.FOXTableBindingSource.DataMember = "FOXTable"
        Me.FOXTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(14, 335)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 20)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "FOX"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboQuoteNumber
        '
        Me.cboQuoteNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboQuoteNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboQuoteNumber.DisplayMember = "SalesOrderKey"
        Me.cboQuoteNumber.FormattingEnabled = True
        Me.cboQuoteNumber.Location = New System.Drawing.Point(108, 285)
        Me.cboQuoteNumber.Name = "cboQuoteNumber"
        Me.cboQuoteNumber.Size = New System.Drawing.Size(178, 21)
        Me.cboQuoteNumber.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(25, 431)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(269, 33)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 286)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 20)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Quote #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(106, 467)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 9
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(118, 536)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(168, 20)
        Me.dtpEndDate.TabIndex = 11
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(17, 117)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(268, 21)
        Me.cboCustomerName.TabIndex = 3
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtCustomerInquiryNumber
        '
        Me.txtCustomerInquiryNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerInquiryNumber.Location = New System.Drawing.Point(108, 237)
        Me.txtCustomerInquiryNumber.Name = "txtCustomerInquiryNumber"
        Me.txtCustomerInquiryNumber.Size = New System.Drawing.Size(178, 20)
        Me.txtCustomerInquiryNumber.TabIndex = 5
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(76, 86)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(209, 21)
        Me.cboCustomerID.TabIndex = 2
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(118, 500)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(168, 20)
        Me.dtpBeginDate.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(27, 536)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "End Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Customer"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(27, 500)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Begin Date"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(215, 579)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 13
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 237)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Cust. Inquiry #"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(138, 579)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 12
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cboPreparer
        '
        Me.cboPreparer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPreparer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPreparer.FormattingEnabled = True
        Me.cboPreparer.Location = New System.Drawing.Point(108, 188)
        Me.cboPreparer.Name = "cboPreparer"
        Me.cboPreparer.Size = New System.Drawing.Size(178, 21)
        Me.cboPreparer.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 189)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Preparer"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Division"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmdReprintQuote)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cmdOpenQuoteForm)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 673)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 138)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Open Quote Form"
        '
        'cmdReprintQuote
        '
        Me.cmdReprintQuote.Location = New System.Drawing.Point(215, 72)
        Me.cmdReprintQuote.Name = "cmdReprintQuote"
        Me.cmdReprintQuote.Size = New System.Drawing.Size(71, 40)
        Me.cmdReprintQuote.TabIndex = 16
        Me.cmdReprintQuote.Text = "Reprint Quote"
        Me.cmdReprintQuote.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(15, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(270, 53)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Select Quote from datagrid to reprint or go to Quote Form."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdOpenQuoteForm
        '
        Me.cmdOpenQuoteForm.Location = New System.Drawing.Point(138, 72)
        Me.cmdOpenQuoteForm.Name = "cmdOpenQuoteForm"
        Me.cmdOpenQuoteForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenQuoteForm.TabIndex = 15
        Me.cmdOpenQuoteForm.Text = "Quote Form"
        Me.cmdOpenQuoteForm.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 23
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 24
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(464, 772)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(270, 42)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Double clicking a row will open the Quote"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'FOXTableTableAdapter
        '
        Me.FOXTableTableAdapter.ClearBeforeFill = True
        '
        'dgvQuoteListing
        '
        Me.dgvQuoteListing.AllowUserToAddRows = False
        Me.dgvQuoteListing.AllowUserToDeleteRows = False
        Me.dgvQuoteListing.AutoGenerateColumns = False
        Me.dgvQuoteListing.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvQuoteListing.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvQuoteListing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvQuoteListing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FOXNumberColumn, Me.QuoteIDColumn, Me.QuoteDateColumn, Me.PreparerColumn, Me.CustomerIDColumn, Me.ContactNameColumn, Me.PhoneColumn, Me.FaxColumn, Me.EmailColumn, Me.CustPartNoColumn, Me.TFPPartNoColumn, Me.PartDescriptionColumn, Me.PartSizeColumn, Me.DeliveryRequirementsColumn, Me.ToolingChargeColumn, Me.SetupChargeColumn, Me.WtPerMColumn, Me.ScrapPercentColumn, Me.ExtensionColumn, Me.NotesCommentsColumn, Me.CustomerInqueryColumn, Me.InternalNotesColumn, Me.RevisionLevelColumn, Me.RMIDColumn, Me.CustomerNameColumn, Me.DivisionIDColumn, Me.FOXItemCreatedColumn, Me.RepAgencyColumn, Me.RFQSourceColumn, Me.ReferenceQuoteNumberColumn})
        Me.dgvQuoteListing.DataSource = Me.TFPQuotationQueryBindingSource
        Me.dgvQuoteListing.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvQuoteListing.Location = New System.Drawing.Point(348, 41)
        Me.dgvQuoteListing.Name = "dgvQuoteListing"
        Me.dgvQuoteListing.Size = New System.Drawing.Size(682, 715)
        Me.dgvQuoteListing.TabIndex = 25
        '
        'FOXNumberColumn
        '
        Me.FOXNumberColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumn.HeaderText = "FOX #"
        Me.FOXNumberColumn.Name = "FOXNumberColumn"
        Me.FOXNumberColumn.Width = 80
        '
        'QuoteIDColumn
        '
        Me.QuoteIDColumn.DataPropertyName = "QuoteID"
        Me.QuoteIDColumn.HeaderText = "Quote #"
        Me.QuoteIDColumn.Name = "QuoteIDColumn"
        Me.QuoteIDColumn.Width = 80
        '
        'QuoteDateColumn
        '
        Me.QuoteDateColumn.DataPropertyName = "QuoteDate"
        Me.QuoteDateColumn.HeaderText = "Quote Date"
        Me.QuoteDateColumn.Name = "QuoteDateColumn"
        Me.QuoteDateColumn.Width = 80
        '
        'PreparerColumn
        '
        Me.PreparerColumn.DataPropertyName = "Preparer"
        Me.PreparerColumn.HeaderText = "Preparer"
        Me.PreparerColumn.Name = "PreparerColumn"
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        '
        'ContactNameColumn
        '
        Me.ContactNameColumn.DataPropertyName = "ContactName"
        Me.ContactNameColumn.HeaderText = "Contact Name"
        Me.ContactNameColumn.Name = "ContactNameColumn"
        '
        'PhoneColumn
        '
        Me.PhoneColumn.DataPropertyName = "Phone"
        Me.PhoneColumn.HeaderText = "Phone"
        Me.PhoneColumn.Name = "PhoneColumn"
        '
        'FaxColumn
        '
        Me.FaxColumn.DataPropertyName = "Fax"
        Me.FaxColumn.HeaderText = "Fax"
        Me.FaxColumn.Name = "FaxColumn"
        '
        'EmailColumn
        '
        Me.EmailColumn.DataPropertyName = "Email"
        Me.EmailColumn.HeaderText = "Email"
        Me.EmailColumn.Name = "EmailColumn"
        '
        'CustPartNoColumn
        '
        Me.CustPartNoColumn.DataPropertyName = "CustPartNo"
        Me.CustPartNoColumn.HeaderText = "Cust Part #"
        Me.CustPartNoColumn.Name = "CustPartNoColumn"
        '
        'TFPPartNoColumn
        '
        Me.TFPPartNoColumn.DataPropertyName = "TFPPartNo"
        Me.TFPPartNoColumn.HeaderText = "TFP Part #"
        Me.TFPPartNoColumn.Name = "TFPPartNoColumn"
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        '
        'PartSizeColumn
        '
        Me.PartSizeColumn.DataPropertyName = "PartSize"
        Me.PartSizeColumn.HeaderText = "Part Size"
        Me.PartSizeColumn.Name = "PartSizeColumn"
        '
        'DeliveryRequirementsColumn
        '
        Me.DeliveryRequirementsColumn.DataPropertyName = "DeliveryRequirements"
        Me.DeliveryRequirementsColumn.HeaderText = "Delivery Requirements"
        Me.DeliveryRequirementsColumn.Name = "DeliveryRequirementsColumn"
        '
        'ToolingChargeColumn
        '
        Me.ToolingChargeColumn.DataPropertyName = "ToolingCharge"
        Me.ToolingChargeColumn.HeaderText = "Tooling Charge"
        Me.ToolingChargeColumn.Name = "ToolingChargeColumn"
        Me.ToolingChargeColumn.Width = 80
        '
        'SetupChargeColumn
        '
        Me.SetupChargeColumn.DataPropertyName = "SetupCharge"
        Me.SetupChargeColumn.HeaderText = "Setup Charge"
        Me.SetupChargeColumn.Name = "SetupChargeColumn"
        Me.SetupChargeColumn.Width = 80
        '
        'WtPerMColumn
        '
        Me.WtPerMColumn.DataPropertyName = "WtPerM"
        Me.WtPerMColumn.HeaderText = "Weight Per 1000"
        Me.WtPerMColumn.Name = "WtPerMColumn"
        '
        'ScrapPercentColumn
        '
        Me.ScrapPercentColumn.DataPropertyName = "ScrapPercent"
        Me.ScrapPercentColumn.HeaderText = "Scrap Percent"
        Me.ScrapPercentColumn.Name = "ScrapPercentColumn"
        '
        'ExtensionColumn
        '
        Me.ExtensionColumn.DataPropertyName = "Extension"
        Me.ExtensionColumn.HeaderText = "Extension"
        Me.ExtensionColumn.Name = "ExtensionColumn"
        '
        'NotesCommentsColumn
        '
        Me.NotesCommentsColumn.DataPropertyName = "NotesComments"
        Me.NotesCommentsColumn.HeaderText = "Notes"
        Me.NotesCommentsColumn.Name = "NotesCommentsColumn"
        '
        'CustomerInqueryColumn
        '
        Me.CustomerInqueryColumn.DataPropertyName = "CustomerInqueryNumber"
        Me.CustomerInqueryColumn.HeaderText = "Customer Inquiry #"
        Me.CustomerInqueryColumn.Name = "CustomerInqueryColumn"
        '
        'InternalNotesColumn
        '
        Me.InternalNotesColumn.DataPropertyName = "InternalNotes"
        Me.InternalNotesColumn.HeaderText = "Internal Notes"
        Me.InternalNotesColumn.Name = "InternalNotesColumn"
        '
        'RevisionLevelColumn
        '
        Me.RevisionLevelColumn.DataPropertyName = "RevisionLevel"
        Me.RevisionLevelColumn.HeaderText = "Revision Level"
        Me.RevisionLevelColumn.Name = "RevisionLevelColumn"
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        '
        'CustomerNameColumn
        '
        Me.CustomerNameColumn.DataPropertyName = "CustomerName"
        Me.CustomerNameColumn.HeaderText = "CustomerName"
        Me.CustomerNameColumn.Name = "CustomerNameColumn"
        Me.CustomerNameColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'FOXItemCreatedColumn
        '
        Me.FOXItemCreatedColumn.DataPropertyName = "FOXItemCreated"
        Me.FOXItemCreatedColumn.HeaderText = "FOXItemCreated"
        Me.FOXItemCreatedColumn.Name = "FOXItemCreatedColumn"
        Me.FOXItemCreatedColumn.Visible = False
        '
        'RepAgencyColumn
        '
        Me.RepAgencyColumn.DataPropertyName = "RepAgency"
        Me.RepAgencyColumn.HeaderText = "RepAgency"
        Me.RepAgencyColumn.Name = "RepAgencyColumn"
        Me.RepAgencyColumn.Visible = False
        '
        'RFQSourceColumn
        '
        Me.RFQSourceColumn.DataPropertyName = "RFQSource"
        Me.RFQSourceColumn.HeaderText = "RFQSource"
        Me.RFQSourceColumn.Name = "RFQSourceColumn"
        Me.RFQSourceColumn.Visible = False
        '
        'ReferenceQuoteNumberColumn
        '
        Me.ReferenceQuoteNumberColumn.DataPropertyName = "ReferenceQuoteNumber"
        Me.ReferenceQuoteNumberColumn.HeaderText = "ReferenceQuoteNumber"
        Me.ReferenceQuoteNumberColumn.Name = "ReferenceQuoteNumberColumn"
        Me.ReferenceQuoteNumberColumn.Visible = False
        '
        'TFPQuotationQueryBindingSource
        '
        Me.TFPQuotationQueryBindingSource.DataMember = "TFPQuotationQuery"
        Me.TFPQuotationQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'TFPQuotationQueryTableAdapter
        '
        Me.TFPQuotationQueryTableAdapter.ClearBeforeFill = True
        '
        'ViewTFPQuoteListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.dgvQuoteListing)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gpxQuotationFilter)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "ViewTFPQuoteListing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Quote Listing"
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxQuotationFilter.ResumeLayout(False)
        Me.gpxQuotationFilter.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvQuoteListing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TFPQuotationQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintQuoteListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReprintQuoteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxQuotationFilter As System.Windows.Forms.GroupBox
    Friend WithEvents cboQuoteNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents txtCustomerInquiryNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cboPreparer As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdReprintQuote As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdOpenQuoteForm As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboFOXNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents FOXTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FOXTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
    Friend WithEvents dgvQuoteListing As System.Windows.Forms.DataGridView
    Friend WithEvents TFPQuotationQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TFPQuotationQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TFPQuotationQueryTableAdapter
    Friend WithEvents FOXNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuoteIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuoteDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PreparerColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PhoneColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmailColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustPartNoColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TFPPartNoColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeliveryRequirementsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolingChargeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SetupChargeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WtPerMColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScrapPercentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtensionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NotesCommentsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerInqueryColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InternalNotesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevisionLevelColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXItemCreatedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepAgencyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RFQSourceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceQuoteNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
