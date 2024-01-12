<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewVendorListing
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxVendorSearchData = New System.Windows.Forms.GroupBox
        Me.txtBeginsWith = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtContactName = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboVendorClass = New System.Windows.Forms.ComboBox
        Me.VendorClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboVendorState = New System.Windows.Forms.ComboBox
        Me.StateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.dgvVendorList = New System.Windows.Forms.DataGridView
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdOpenVendorForm = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.StateTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
        Me.VendorClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorClassTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdCreateVendor = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdViewAllVendors = New System.Windows.Forms.Button
        Me.cmdClearAllVendors = New System.Windows.Forms.Button
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContactNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorPhoneColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorFaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorEmailColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RemittanceEmailColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorAddress1Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorAddress2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorCityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorStateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorZipColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorCountryColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTermsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Checked1099Column = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.VendorCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorPreferredShippingColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditLimitColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ApprovedByColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ApprovalCriteriaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ApprovalDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorTaxIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DefaultGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DefaultItemColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Prop65CompliantColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WhitePaperCheckColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorAccountNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorRoutingNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorAccountTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        Me.gpxVendorSearchData.SuspendLayout()
        CType(Me.VendorClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvVendorList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 15
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.FileToolStripMenuItem1, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'FileToolStripMenuItem1
        '
        Me.FileToolStripMenuItem1.Name = "FileToolStripMenuItem1"
        Me.FileToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem1.Text = "Edit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem
        '
        Me.PrintListingToolStripMenuItem.Name = "PrintListingToolStripMenuItem"
        Me.PrintListingToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.PrintListingToolStripMenuItem.Text = "Print Listing"
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
        'gpxVendorSearchData
        '
        Me.gpxVendorSearchData.Controls.Add(Me.txtBeginsWith)
        Me.gpxVendorSearchData.Controls.Add(Me.Label12)
        Me.gpxVendorSearchData.Controls.Add(Me.Label8)
        Me.gpxVendorSearchData.Controls.Add(Me.txtContactName)
        Me.gpxVendorSearchData.Controls.Add(Me.Label7)
        Me.gpxVendorSearchData.Controls.Add(Me.txtTextFilter)
        Me.gpxVendorSearchData.Controls.Add(Me.Label5)
        Me.gpxVendorSearchData.Controls.Add(Me.cboVendorClass)
        Me.gpxVendorSearchData.Controls.Add(Me.Label2)
        Me.gpxVendorSearchData.Controls.Add(Me.cmdViewByFilters)
        Me.gpxVendorSearchData.Controls.Add(Me.txtVendorName)
        Me.gpxVendorSearchData.Controls.Add(Me.cboDivisionID)
        Me.gpxVendorSearchData.Controls.Add(Me.cmdClear)
        Me.gpxVendorSearchData.Controls.Add(Me.Label1)
        Me.gpxVendorSearchData.Controls.Add(Me.cboVendorID)
        Me.gpxVendorSearchData.Controls.Add(Me.Label3)
        Me.gpxVendorSearchData.Controls.Add(Me.cboVendorState)
        Me.gpxVendorSearchData.Controls.Add(Me.Label6)
        Me.gpxVendorSearchData.Controls.Add(Me.Label10)
        Me.gpxVendorSearchData.Location = New System.Drawing.Point(29, 41)
        Me.gpxVendorSearchData.Name = "gpxVendorSearchData"
        Me.gpxVendorSearchData.Size = New System.Drawing.Size(300, 645)
        Me.gpxVendorSearchData.TabIndex = 0
        Me.gpxVendorSearchData.TabStop = False
        Me.gpxVendorSearchData.Text = "View By Filters"
        '
        'txtBeginsWith
        '
        Me.txtBeginsWith.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBeginsWith.Location = New System.Drawing.Point(136, 550)
        Me.txtBeginsWith.Name = "txtBeginsWith"
        Me.txtBeginsWith.Size = New System.Drawing.Size(149, 20)
        Me.txtBeginsWith.TabIndex = 7
        Me.txtBeginsWith.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(23, 65)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(262, 40)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(23, 412)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(263, 25)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Type in a word or phrase to fiilter the Vendor List."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtContactName
        '
        Me.txtContactName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactName.Location = New System.Drawing.Point(100, 364)
        Me.txtContactName.Name = "txtContactName"
        Me.txtContactName.Size = New System.Drawing.Size(185, 20)
        Me.txtContactName.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(23, 363)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Contact Name"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.Location = New System.Drawing.Point(23, 460)
        Me.txtTextFilter.Multiline = True
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(265, 52)
        Me.txtTextFilter.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(23, 437)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Text Filter"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorClass
        '
        Me.cboVendorClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorClass.DataSource = Me.VendorClassBindingSource
        Me.cboVendorClass.DisplayMember = "VendClassID"
        Me.cboVendorClass.FormattingEnabled = True
        Me.cboVendorClass.Location = New System.Drawing.Point(98, 240)
        Me.cboVendorClass.Name = "cboVendorClass"
        Me.cboVendorClass.Size = New System.Drawing.Size(187, 21)
        Me.cboVendorClass.TabIndex = 3
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
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(23, 241)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Vendor Class"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(137, 598)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 8
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Location = New System.Drawing.Point(23, 149)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(265, 63)
        Me.txtVendorName.TabIndex = 2
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(98, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(187, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 598)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 9
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(23, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.VendorBindingSource
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(82, 114)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(203, 21)
        Me.cboVendorID.TabIndex = 1
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(23, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Vendor ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorState
        '
        Me.cboVendorState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorState.DataSource = Me.StateTableBindingSource
        Me.cboVendorState.DisplayMember = "StateCode"
        Me.cboVendorState.FormattingEnabled = True
        Me.cboVendorState.Location = New System.Drawing.Point(97, 302)
        Me.cboVendorState.Name = "cboVendorState"
        Me.cboVendorState.Size = New System.Drawing.Size(187, 21)
        Me.cboVendorState.TabIndex = 4
        '
        'StateTableBindingSource
        '
        Me.StateTableBindingSource.DataMember = "StateTable"
        Me.StateTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(23, 303)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Vendor State"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(23, 550)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Begins with..."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvVendorList
        '
        Me.dgvVendorList.AllowUserToAddRows = False
        Me.dgvVendorList.AllowUserToDeleteRows = False
        Me.dgvVendorList.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvVendorList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVendorList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvVendorList.AutoGenerateColumns = False
        Me.dgvVendorList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvVendorList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvVendorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVendorList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.VendorCodeColumn, Me.VendorNameColumn, Me.ContactNameColumn, Me.VendorPhoneColumn, Me.VendorFaxColumn, Me.VendorEmailColumn, Me.RemittanceEmailColumn, Me.VendorAddress1Column, Me.VendorAddress2Column, Me.VendorCityColumn, Me.VendorStateColumn, Me.VendorZipColumn, Me.VendorCountryColumn, Me.PaymentTermsColumn, Me.VendorClassColumn, Me.Checked1099Column, Me.VendorCommentColumn, Me.VendorPreferredShippingColumn, Me.CreditLimitColumn, Me.ApprovedByColumn, Me.ApprovalCriteriaColumn, Me.ApprovalDateColumn, Me.VendorTaxIDColumn, Me.DefaultGLAccountColumn, Me.DefaultItemColumn, Me.VendorDateColumn, Me.Prop65CompliantColumn, Me.WhitePaperCheckColumn, Me.CheckCodeColumn, Me.VendorAccountNumberColumn, Me.VendorRoutingNumberColumn, Me.VendorAccountTypeColumn})
        Me.dgvVendorList.DataSource = Me.VendorBindingSource
        Me.dgvVendorList.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvVendorList.Location = New System.Drawing.Point(348, 41)
        Me.dgvVendorList.Name = "dgvVendorList"
        Me.dgvVendorList.Size = New System.Drawing.Size(782, 715)
        Me.dgvVendorList.TabIndex = 15
        Me.dgvVendorList.TabStop = False
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(984, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 14
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(640, 779)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(279, 25)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Changes in the datagrid are saved automatically."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdOpenVendorForm
        '
        Me.cmdOpenVendorForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenVendorForm.Location = New System.Drawing.Point(348, 771)
        Me.cmdOpenVendorForm.Name = "cmdOpenVendorForm"
        Me.cmdOpenVendorForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenVendorForm.TabIndex = 12
        Me.cmdOpenVendorForm.Text = "Vendor Form"
        Me.cmdOpenVendorForm.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'StateTableTableAdapter
        '
        Me.StateTableTableAdapter.ClearBeforeFill = True
        '
        'VendorClassTableAdapter
        '
        Me.VendorClassTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "VendorCode"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Vendor ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "DivisionID"
        Me.DataGridViewTextBoxColumn2.HeaderText = "DivisionID"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "VendorName"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Vendor Name"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ContactName"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Contact Name"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "VendorAddress1"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Vendor Address 1"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "VendorAddress2"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Vendor Address 2"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "VendorCity"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Vendor City"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "VendorState"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Vendor State"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "VendorZip"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Vendor Zip"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "VendorCountry"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Vendor Country"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "VendorPhone"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Vendor Phone"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "VendorFax"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Vendor Fax"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "VendorEmail"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Vendor Email"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "PaymentTerms"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Payment Terms"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "VendorClass"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Vendor Class"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "VendorDate"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Vendor Date"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "VendorComment"
        Me.DataGridViewTextBoxColumn17.HeaderText = "Vendor Comment"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "VendorTaxID"
        Me.DataGridViewTextBoxColumn18.HeaderText = "Vendor Tax ID"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "VendorPreferredShipping"
        Me.DataGridViewTextBoxColumn19.HeaderText = "Vendor Preferred Shipping"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdCreateVendor)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cmdViewAllVendors)
        Me.GroupBox1.Controls.Add(Me.cmdClearAllVendors)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 692)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 119)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View Vendors from All Divisions"
        '
        'cmdCreateVendor
        '
        Me.cmdCreateVendor.ForeColor = System.Drawing.Color.Blue
        Me.cmdCreateVendor.Location = New System.Drawing.Point(59, 79)
        Me.cmdCreateVendor.Name = "cmdCreateVendor"
        Me.cmdCreateVendor.Size = New System.Drawing.Size(71, 30)
        Me.cmdCreateVendor.TabIndex = 9
        Me.cmdCreateVendor.Text = "Create"
        Me.cmdCreateVendor.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(19, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(246, 35)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "To replicate Vendor from another division, select Vendor in datagrid and press ""C" & _
            "reate""."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewAllVendors
        '
        Me.cmdViewAllVendors.Location = New System.Drawing.Point(136, 79)
        Me.cmdViewAllVendors.Name = "cmdViewAllVendors"
        Me.cmdViewAllVendors.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewAllVendors.TabIndex = 10
        Me.cmdViewAllVendors.Text = "View All"
        Me.cmdViewAllVendors.UseVisualStyleBackColor = True
        '
        'cmdClearAllVendors
        '
        Me.cmdClearAllVendors.Location = New System.Drawing.Point(213, 79)
        Me.cmdClearAllVendors.Name = "cmdClearAllVendors"
        Me.cmdClearAllVendors.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearAllVendors.TabIndex = 11
        Me.cmdClearAllVendors.Text = "Clear All"
        Me.cmdClearAllVendors.UseVisualStyleBackColor = True
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'VendorCodeColumn
        '
        Me.VendorCodeColumn.DataPropertyName = "VendorCode"
        Me.VendorCodeColumn.HeaderText = "Vendor ID"
        Me.VendorCodeColumn.Name = "VendorCodeColumn"
        Me.VendorCodeColumn.ReadOnly = True
        '
        'VendorNameColumn
        '
        Me.VendorNameColumn.DataPropertyName = "VendorName"
        Me.VendorNameColumn.HeaderText = "Vendor Name"
        Me.VendorNameColumn.Name = "VendorNameColumn"
        '
        'ContactNameColumn
        '
        Me.ContactNameColumn.DataPropertyName = "ContactName"
        Me.ContactNameColumn.HeaderText = "Contact Name"
        Me.ContactNameColumn.Name = "ContactNameColumn"
        '
        'VendorPhoneColumn
        '
        Me.VendorPhoneColumn.DataPropertyName = "VendorPhone"
        Me.VendorPhoneColumn.HeaderText = "Phone"
        Me.VendorPhoneColumn.Name = "VendorPhoneColumn"
        '
        'VendorFaxColumn
        '
        Me.VendorFaxColumn.DataPropertyName = "VendorFax"
        Me.VendorFaxColumn.HeaderText = "Fax"
        Me.VendorFaxColumn.Name = "VendorFaxColumn"
        '
        'VendorEmailColumn
        '
        Me.VendorEmailColumn.DataPropertyName = "VendorEmail"
        Me.VendorEmailColumn.HeaderText = "Email"
        Me.VendorEmailColumn.Name = "VendorEmailColumn"
        '
        'RemittanceEmailColumn
        '
        Me.RemittanceEmailColumn.DataPropertyName = "RemittanceEmail"
        Me.RemittanceEmailColumn.HeaderText = "Remittance Email"
        Me.RemittanceEmailColumn.Name = "RemittanceEmailColumn"
        '
        'VendorAddress1Column
        '
        Me.VendorAddress1Column.DataPropertyName = "VendorAddress1"
        Me.VendorAddress1Column.HeaderText = "Address 1"
        Me.VendorAddress1Column.Name = "VendorAddress1Column"
        '
        'VendorAddress2Column
        '
        Me.VendorAddress2Column.DataPropertyName = "VendorAddress2"
        Me.VendorAddress2Column.HeaderText = "Address 2"
        Me.VendorAddress2Column.Name = "VendorAddress2Column"
        '
        'VendorCityColumn
        '
        Me.VendorCityColumn.DataPropertyName = "VendorCity"
        Me.VendorCityColumn.HeaderText = "City"
        Me.VendorCityColumn.Name = "VendorCityColumn"
        '
        'VendorStateColumn
        '
        Me.VendorStateColumn.DataPropertyName = "VendorState"
        Me.VendorStateColumn.HeaderText = "State"
        Me.VendorStateColumn.Name = "VendorStateColumn"
        '
        'VendorZipColumn
        '
        Me.VendorZipColumn.DataPropertyName = "VendorZip"
        Me.VendorZipColumn.HeaderText = "Zip"
        Me.VendorZipColumn.Name = "VendorZipColumn"
        '
        'VendorCountryColumn
        '
        Me.VendorCountryColumn.DataPropertyName = "VendorCountry"
        Me.VendorCountryColumn.HeaderText = "Country"
        Me.VendorCountryColumn.Name = "VendorCountryColumn"
        '
        'PaymentTermsColumn
        '
        Me.PaymentTermsColumn.DataPropertyName = "PaymentTerms"
        Me.PaymentTermsColumn.HeaderText = "Payment Terms"
        Me.PaymentTermsColumn.Name = "PaymentTermsColumn"
        '
        'VendorClassColumn
        '
        Me.VendorClassColumn.DataPropertyName = "VendorClass"
        Me.VendorClassColumn.HeaderText = "Vendor Class"
        Me.VendorClassColumn.Name = "VendorClassColumn"
        Me.VendorClassColumn.ReadOnly = True
        '
        'Checked1099Column
        '
        Me.Checked1099Column.DataPropertyName = "Checked1099"
        Me.Checked1099Column.FalseValue = "NO"
        Me.Checked1099Column.HeaderText = "1099?"
        Me.Checked1099Column.IndeterminateValue = "NO"
        Me.Checked1099Column.Name = "Checked1099Column"
        Me.Checked1099Column.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Checked1099Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Checked1099Column.TrueValue = "YES"
        '
        'VendorCommentColumn
        '
        Me.VendorCommentColumn.DataPropertyName = "VendorComment"
        Me.VendorCommentColumn.HeaderText = "Comment"
        Me.VendorCommentColumn.Name = "VendorCommentColumn"
        '
        'VendorPreferredShippingColumn
        '
        Me.VendorPreferredShippingColumn.DataPropertyName = "VendorPreferredShipping"
        Me.VendorPreferredShippingColumn.HeaderText = "Preferred Shipping"
        Me.VendorPreferredShippingColumn.Name = "VendorPreferredShippingColumn"
        '
        'CreditLimitColumn
        '
        Me.CreditLimitColumn.DataPropertyName = "CreditLimit"
        Me.CreditLimitColumn.HeaderText = "Credit Limit"
        Me.CreditLimitColumn.Name = "CreditLimitColumn"
        '
        'ApprovedByColumn
        '
        Me.ApprovedByColumn.DataPropertyName = "ApprovedBy"
        Me.ApprovedByColumn.HeaderText = "Approved By"
        Me.ApprovedByColumn.Name = "ApprovedByColumn"
        Me.ApprovedByColumn.Visible = False
        '
        'ApprovalCriteriaColumn
        '
        Me.ApprovalCriteriaColumn.DataPropertyName = "ApprovalCriteria"
        Me.ApprovalCriteriaColumn.HeaderText = "Approval Criteria"
        Me.ApprovalCriteriaColumn.Name = "ApprovalCriteriaColumn"
        Me.ApprovalCriteriaColumn.Visible = False
        '
        'ApprovalDateColumn
        '
        Me.ApprovalDateColumn.DataPropertyName = "ApprovalDate"
        Me.ApprovalDateColumn.HeaderText = "Approval Date"
        Me.ApprovalDateColumn.Name = "ApprovalDateColumn"
        Me.ApprovalDateColumn.Visible = False
        '
        'VendorTaxIDColumn
        '
        Me.VendorTaxIDColumn.DataPropertyName = "VendorTaxID"
        Me.VendorTaxIDColumn.HeaderText = "VendorTaxID"
        Me.VendorTaxIDColumn.Name = "VendorTaxIDColumn"
        Me.VendorTaxIDColumn.Visible = False
        '
        'DefaultGLAccountColumn
        '
        Me.DefaultGLAccountColumn.DataPropertyName = "DefaultGLAccount"
        Me.DefaultGLAccountColumn.HeaderText = "Default GL Account"
        Me.DefaultGLAccountColumn.Name = "DefaultGLAccountColumn"
        Me.DefaultGLAccountColumn.ReadOnly = True
        Me.DefaultGLAccountColumn.Visible = False
        '
        'DefaultItemColumn
        '
        Me.DefaultItemColumn.DataPropertyName = "DefaultItem"
        Me.DefaultItemColumn.HeaderText = "Default Item"
        Me.DefaultItemColumn.Name = "DefaultItemColumn"
        Me.DefaultItemColumn.ReadOnly = True
        Me.DefaultItemColumn.Visible = False
        '
        'VendorDateColumn
        '
        Me.VendorDateColumn.DataPropertyName = "VendorDate"
        Me.VendorDateColumn.HeaderText = "VendorDate"
        Me.VendorDateColumn.Name = "VendorDateColumn"
        Me.VendorDateColumn.Visible = False
        '
        'Prop65CompliantColumn
        '
        Me.Prop65CompliantColumn.DataPropertyName = "Prop65Compliant"
        Me.Prop65CompliantColumn.HeaderText = "Prop 65?"
        Me.Prop65CompliantColumn.Name = "Prop65CompliantColumn"
        Me.Prop65CompliantColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'WhitePaperCheckColumn
        '
        Me.WhitePaperCheckColumn.DataPropertyName = "WhitePaperCheck"
        Me.WhitePaperCheckColumn.HeaderText = "White Paper Check"
        Me.WhitePaperCheckColumn.Name = "WhitePaperCheckColumn"
        Me.WhitePaperCheckColumn.ReadOnly = True
        '
        'CheckCodeColumn
        '
        Me.CheckCodeColumn.DataPropertyName = "CheckCode"
        Me.CheckCodeColumn.HeaderText = "Check Code"
        Me.CheckCodeColumn.Name = "CheckCodeColumn"
        Me.CheckCodeColumn.ReadOnly = True
        '
        'VendorAccountNumberColumn
        '
        Me.VendorAccountNumberColumn.DataPropertyName = "VendorAccountNumber"
        Me.VendorAccountNumberColumn.HeaderText = "Vendor Account #"
        Me.VendorAccountNumberColumn.Name = "VendorAccountNumberColumn"
        Me.VendorAccountNumberColumn.ReadOnly = True
        Me.VendorAccountNumberColumn.Visible = False
        '
        'VendorRoutingNumberColumn
        '
        Me.VendorRoutingNumberColumn.DataPropertyName = "VendorRoutingNumber"
        Me.VendorRoutingNumberColumn.HeaderText = "Routing #"
        Me.VendorRoutingNumberColumn.Name = "VendorRoutingNumberColumn"
        Me.VendorRoutingNumberColumn.ReadOnly = True
        Me.VendorRoutingNumberColumn.Visible = False
        '
        'VendorAccountTypeColumn
        '
        Me.VendorAccountTypeColumn.DataPropertyName = "VendorAccountType"
        Me.VendorAccountTypeColumn.HeaderText = "Account Type"
        Me.VendorAccountTypeColumn.Name = "VendorAccountTypeColumn"
        Me.VendorAccountTypeColumn.ReadOnly = True
        Me.VendorAccountTypeColumn.Visible = False
        '
        'ViewVendorListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdOpenVendorForm)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.dgvVendorList)
        Me.Controls.Add(Me.gpxVendorSearchData)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewVendorListing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Vendor Listing"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxVendorSearchData.ResumeLayout(False)
        Me.gpxVendorSearchData.PerformLayout()
        CType(Me.VendorClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvVendorList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxVendorSearchData As System.Windows.Forms.GroupBox
    Friend WithEvents dgvVendorList As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdOpenVendorForm As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboVendorState As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboVendorClass As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdClear1 As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents StateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StateTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
    Friend WithEvents VendorClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorClassTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtContactName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewAllVendors As System.Windows.Forms.Button
    Friend WithEvents cmdClearAllVendors As System.Windows.Forms.Button
    Friend WithEvents cmdCreateVendor As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtBeginsWith As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorPhoneColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorFaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorEmailColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemittanceEmailColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorAddress1Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorAddress2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorCityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorStateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorZipColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorCountryColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTermsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Checked1099Column As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents VendorCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorPreferredShippingColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditLimitColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApprovedByColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApprovalCriteriaColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApprovalDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorTaxIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DefaultGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DefaultItemColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prop65CompliantColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WhitePaperCheckColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorAccountNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorRoutingNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorAccountTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
