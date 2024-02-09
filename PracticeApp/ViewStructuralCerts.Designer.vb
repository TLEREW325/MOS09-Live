<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewStructuralCerts
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
        Me.lblLotNumber = New System.Windows.Forms.Label
        Me.txtLotNumber = New System.Windows.Forms.TextBox
        Me.txtHeatNumber = New System.Windows.Forms.TextBox
        Me.lblHeatNumber = New System.Windows.Forms.Label
        Me.lblComment = New System.Windows.Forms.Label
        Me.lblPartDesc = New System.Windows.Forms.Label
        Me.lblPartNum = New System.Windows.Forms.Label
        Me.grpPart = New System.Windows.Forms.GroupBox
        Me.cboVendor = New System.Windows.Forms.ComboBox
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.lblDate = New System.Windows.Forms.Label
        Me.dtpDateEntry = New System.Windows.Forms.DateTimePicker
        Me.lblVendor = New System.Windows.Forms.Label
        Me.cboSalesID = New System.Windows.Forms.ComboBox
        Me.lblSalesId = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.lblEndD = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.lblBeginD = New System.Windows.Forms.Label
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdRemove = New System.Windows.Forms.Button
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClose = New System.Windows.Forms.Button
        Me.grpView = New System.Windows.Forms.GroupBox
        Me.chkPDFScanned = New System.Windows.Forms.CheckBox
        Me.chkOpen = New System.Windows.Forms.CheckBox
        Me.txtLookVendorView = New System.Windows.Forms.TextBox
        Me.lblVendorView = New System.Windows.Forms.Label
        Me.txtLookSalesID = New System.Windows.Forms.RichTextBox
        Me.lblCommentView = New System.Windows.Forms.Label
        Me.lblHeatNum = New System.Windows.Forms.Label
        Me.lblLotNum = New System.Windows.Forms.Label
        Me.txtLookPartDesc = New System.Windows.Forms.TextBox
        Me.txtLookHeatNumber = New System.Windows.Forms.TextBox
        Me.txtLookLotNum = New System.Windows.Forms.TextBox
        Me.lblDescView = New System.Windows.Forms.Label
        Me.txtLookPartNum = New System.Windows.Forms.TextBox
        Me.lblPartView = New System.Windows.Forms.Label
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.lblText = New System.Windows.Forms.Label
        Me.dgvStructCert = New System.Windows.Forms.DataGridView
        Me.StructuralCertTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdViewPDF = New System.Windows.Forms.Button
        Me.cmdViewAll = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ScanCertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadCertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewVsViewAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.KeywordSearchingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EmailPDFOfStructCertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EmailCoCOfCurrentLotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdScan = New System.Windows.Forms.Button
        Me.cmdUpload = New System.Windows.Forms.Button
        Me.cmdRemoteScan = New System.Windows.Forms.Button
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.grpCOC = New System.Windows.Forms.GroupBox
        Me.lblCoC = New System.Windows.Forms.Label
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.StructuralCertTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StructuralCertTableTableAdapter
        Me.LotNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PDFStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grpPart.SuspendLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpView.SuspendLayout()
        CType(Me.dgvStructCert, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StructuralCertTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.grpCOC.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblLotNumber
        '
        Me.lblLotNumber.AutoSize = True
        Me.lblLotNumber.Location = New System.Drawing.Point(28, 23)
        Me.lblLotNumber.Name = "lblLotNumber"
        Me.lblLotNumber.Size = New System.Drawing.Size(65, 13)
        Me.lblLotNumber.TabIndex = 1
        Me.lblLotNumber.Text = "Lot Number:"
        '
        'txtLotNumber
        '
        Me.txtLotNumber.Location = New System.Drawing.Point(114, 19)
        Me.txtLotNumber.Name = "txtLotNumber"
        Me.txtLotNumber.Size = New System.Drawing.Size(155, 20)
        Me.txtLotNumber.TabIndex = 2
        '
        'txtHeatNumber
        '
        Me.txtHeatNumber.Location = New System.Drawing.Point(114, 117)
        Me.txtHeatNumber.Name = "txtHeatNumber"
        Me.txtHeatNumber.Size = New System.Drawing.Size(155, 20)
        Me.txtHeatNumber.TabIndex = 4
        '
        'lblHeatNumber
        '
        Me.lblHeatNumber.AutoSize = True
        Me.lblHeatNumber.Location = New System.Drawing.Point(28, 121)
        Me.lblHeatNumber.Name = "lblHeatNumber"
        Me.lblHeatNumber.Size = New System.Drawing.Size(73, 13)
        Me.lblHeatNumber.TabIndex = 3
        Me.lblHeatNumber.Text = "Heat Number:"
        '
        'lblComment
        '
        Me.lblComment.AutoSize = True
        Me.lblComment.Location = New System.Drawing.Point(28, 153)
        Me.lblComment.Name = "lblComment"
        Me.lblComment.Size = New System.Drawing.Size(58, 13)
        Me.lblComment.TabIndex = 5
        Me.lblComment.Text = "Item Class:"
        '
        'lblPartDesc
        '
        Me.lblPartDesc.AutoSize = True
        Me.lblPartDesc.Location = New System.Drawing.Point(28, 88)
        Me.lblPartDesc.Name = "lblPartDesc"
        Me.lblPartDesc.Size = New System.Drawing.Size(85, 13)
        Me.lblPartDesc.TabIndex = 7
        Me.lblPartDesc.Text = "Part Description:"
        '
        'lblPartNum
        '
        Me.lblPartNum.AutoSize = True
        Me.lblPartNum.Location = New System.Drawing.Point(28, 55)
        Me.lblPartNum.Name = "lblPartNum"
        Me.lblPartNum.Size = New System.Drawing.Size(69, 13)
        Me.lblPartNum.TabIndex = 8
        Me.lblPartNum.Text = "Part Number:"
        '
        'grpPart
        '
        Me.grpPart.Controls.Add(Me.cboVendor)
        Me.grpPart.Controls.Add(Me.cboPartNumber)
        Me.grpPart.Controls.Add(Me.cboPartDescription)
        Me.grpPart.Controls.Add(Me.cboItemClass)
        Me.grpPart.Controls.Add(Me.lblDate)
        Me.grpPart.Controls.Add(Me.dtpDateEntry)
        Me.grpPart.Controls.Add(Me.lblVendor)
        Me.grpPart.Controls.Add(Me.cboSalesID)
        Me.grpPart.Controls.Add(Me.lblSalesId)
        Me.grpPart.Controls.Add(Me.lblLotNumber)
        Me.grpPart.Controls.Add(Me.txtLotNumber)
        Me.grpPart.Controls.Add(Me.lblPartNum)
        Me.grpPart.Controls.Add(Me.lblHeatNumber)
        Me.grpPart.Controls.Add(Me.lblPartDesc)
        Me.grpPart.Controls.Add(Me.txtHeatNumber)
        Me.grpPart.Controls.Add(Me.lblComment)
        Me.grpPart.Location = New System.Drawing.Point(6, 27)
        Me.grpPart.Name = "grpPart"
        Me.grpPart.Size = New System.Drawing.Size(295, 282)
        Me.grpPart.TabIndex = 11
        Me.grpPart.TabStop = False
        Me.grpPart.Text = "Part Information"
        '
        'cboVendor
        '
        Me.cboVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendor.FormattingEnabled = True
        Me.cboVendor.Location = New System.Drawing.Point(114, 216)
        Me.cboVendor.Name = "cboVendor"
        Me.cboVendor.Size = New System.Drawing.Size(155, 21)
        Me.cboVendor.TabIndex = 32
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(114, 51)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(155, 21)
        Me.cboPartNumber.TabIndex = 31
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(114, 84)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(155, 21)
        Me.cboPartDescription.TabIndex = 30
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(114, 149)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(155, 21)
        Me.cboItemClass.TabIndex = 29
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(28, 251)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(33, 13)
        Me.lblDate.TabIndex = 25
        Me.lblDate.Text = "Date:"
        '
        'dtpDateEntry
        '
        Me.dtpDateEntry.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateEntry.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateEntry.Location = New System.Drawing.Point(114, 247)
        Me.dtpDateEntry.Name = "dtpDateEntry"
        Me.dtpDateEntry.Size = New System.Drawing.Size(153, 20)
        Me.dtpDateEntry.TabIndex = 23
        '
        'lblVendor
        '
        Me.lblVendor.AutoSize = True
        Me.lblVendor.Location = New System.Drawing.Point(28, 219)
        Me.lblVendor.Name = "lblVendor"
        Me.lblVendor.Size = New System.Drawing.Size(44, 13)
        Me.lblVendor.TabIndex = 23
        Me.lblVendor.Text = "Vendor:"
        '
        'cboSalesID
        '
        Me.cboSalesID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesID.FormattingEnabled = True
        Me.cboSalesID.Location = New System.Drawing.Point(114, 182)
        Me.cboSalesID.Name = "cboSalesID"
        Me.cboSalesID.Size = New System.Drawing.Size(155, 21)
        Me.cboSalesID.TabIndex = 12
        '
        'lblSalesId
        '
        Me.lblSalesId.AutoSize = True
        Me.lblSalesId.Location = New System.Drawing.Point(28, 186)
        Me.lblSalesId.Name = "lblSalesId"
        Me.lblSalesId.Size = New System.Drawing.Size(50, 13)
        Me.lblSalesId.TabIndex = 11
        Me.lblSalesId.Text = "Sales ID:"
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(104, 19)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 18
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(104, 68)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(153, 20)
        Me.dtpEndDate.TabIndex = 21
        '
        'lblEndD
        '
        Me.lblEndD.Location = New System.Drawing.Point(15, 68)
        Me.lblEndD.Name = "lblEndD"
        Me.lblEndD.Size = New System.Drawing.Size(72, 20)
        Me.lblEndD.TabIndex = 22
        Me.lblEndD.Text = "End Date:"
        Me.lblEndD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(104, 42)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(153, 20)
        Me.dtpBeginDate.TabIndex = 19
        '
        'lblBeginD
        '
        Me.lblBeginD.Location = New System.Drawing.Point(15, 42)
        Me.lblBeginD.Name = "lblBeginD"
        Me.lblBeginD.Size = New System.Drawing.Size(83, 20)
        Me.lblBeginD.TabIndex = 20
        Me.lblBeginD.Text = "Begin Date:"
        Me.lblBeginD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(6, 315)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(87, 36)
        Me.cmdAdd.TabIndex = 12
        Me.cmdAdd.Text = "Add/Update"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmdRemove
        '
        Me.cmdRemove.Location = New System.Drawing.Point(214, 315)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(87, 36)
        Me.cmdRemove.TabIndex = 13
        Me.cmdRemove.Text = "Remove"
        Me.cmdRemove.UseVisualStyleBackColor = True
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(81, 815)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(65, 36)
        Me.cmdView.TabIndex = 14
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(6, 815)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(65, 36)
        Me.cmdClose.TabIndex = 15
        Me.cmdClose.Text = "Exit"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'grpView
        '
        Me.grpView.Controls.Add(Me.chkPDFScanned)
        Me.grpView.Controls.Add(Me.chkOpen)
        Me.grpView.Controls.Add(Me.txtLookVendorView)
        Me.grpView.Controls.Add(Me.lblVendorView)
        Me.grpView.Controls.Add(Me.txtLookSalesID)
        Me.grpView.Controls.Add(Me.lblCommentView)
        Me.grpView.Controls.Add(Me.lblHeatNum)
        Me.grpView.Controls.Add(Me.lblLotNum)
        Me.grpView.Controls.Add(Me.txtLookPartDesc)
        Me.grpView.Controls.Add(Me.txtLookHeatNumber)
        Me.grpView.Controls.Add(Me.txtLookLotNum)
        Me.grpView.Controls.Add(Me.lblDescView)
        Me.grpView.Controls.Add(Me.txtLookPartNum)
        Me.grpView.Controls.Add(Me.lblPartView)
        Me.grpView.Controls.Add(Me.txtSearch)
        Me.grpView.Controls.Add(Me.lblText)
        Me.grpView.Controls.Add(Me.chkDateRange)
        Me.grpView.Controls.Add(Me.lblBeginD)
        Me.grpView.Controls.Add(Me.dtpBeginDate)
        Me.grpView.Controls.Add(Me.dtpEndDate)
        Me.grpView.Controls.Add(Me.lblEndD)
        Me.grpView.Location = New System.Drawing.Point(6, 426)
        Me.grpView.Name = "grpView"
        Me.grpView.Size = New System.Drawing.Size(295, 326)
        Me.grpView.TabIndex = 17
        Me.grpView.TabStop = False
        Me.grpView.Text = "Search Function"
        '
        'chkPDFScanned
        '
        Me.chkPDFScanned.AutoSize = True
        Me.chkPDFScanned.Location = New System.Drawing.Point(154, 291)
        Me.chkPDFScanned.Name = "chkPDFScanned"
        Me.chkPDFScanned.Size = New System.Drawing.Size(113, 17)
        Me.chkPDFScanned.TabIndex = 33
        Me.chkPDFScanned.Text = "PDF Not Scanned"
        Me.chkPDFScanned.UseVisualStyleBackColor = True
        '
        'chkOpen
        '
        Me.chkOpen.AutoSize = True
        Me.chkOpen.Location = New System.Drawing.Point(46, 291)
        Me.chkOpen.Name = "chkOpen"
        Me.chkOpen.Size = New System.Drawing.Size(52, 17)
        Me.chkOpen.TabIndex = 32
        Me.chkOpen.Text = "Open"
        Me.chkOpen.UseVisualStyleBackColor = True
        '
        'txtLookVendorView
        '
        Me.txtLookVendorView.Location = New System.Drawing.Point(104, 265)
        Me.txtLookVendorView.Name = "txtLookVendorView"
        Me.txtLookVendorView.Size = New System.Drawing.Size(153, 20)
        Me.txtLookVendorView.TabIndex = 30
        '
        'lblVendorView
        '
        Me.lblVendorView.AutoSize = True
        Me.lblVendorView.Location = New System.Drawing.Point(17, 269)
        Me.lblVendorView.Name = "lblVendorView"
        Me.lblVendorView.Size = New System.Drawing.Size(44, 13)
        Me.lblVendorView.TabIndex = 29
        Me.lblVendorView.Text = "Vendor:"
        '
        'txtLookSalesID
        '
        Me.txtLookSalesID.Location = New System.Drawing.Point(104, 239)
        Me.txtLookSalesID.Name = "txtLookSalesID"
        Me.txtLookSalesID.Size = New System.Drawing.Size(153, 20)
        Me.txtLookSalesID.TabIndex = 30
        Me.txtLookSalesID.Text = ""
        '
        'lblCommentView
        '
        Me.lblCommentView.AutoSize = True
        Me.lblCommentView.Location = New System.Drawing.Point(17, 243)
        Me.lblCommentView.Name = "lblCommentView"
        Me.lblCommentView.Size = New System.Drawing.Size(50, 13)
        Me.lblCommentView.TabIndex = 29
        Me.lblCommentView.Text = "Sales ID:"
        '
        'lblHeatNum
        '
        Me.lblHeatNum.AutoSize = True
        Me.lblHeatNum.Location = New System.Drawing.Point(17, 217)
        Me.lblHeatNum.Name = "lblHeatNum"
        Me.lblHeatNum.Size = New System.Drawing.Size(73, 13)
        Me.lblHeatNum.TabIndex = 29
        Me.lblHeatNum.Text = "Heat Number:"
        '
        'lblLotNum
        '
        Me.lblLotNum.AutoSize = True
        Me.lblLotNum.Location = New System.Drawing.Point(17, 113)
        Me.lblLotNum.Name = "lblLotNum"
        Me.lblLotNum.Size = New System.Drawing.Size(65, 13)
        Me.lblLotNum.TabIndex = 29
        Me.lblLotNum.Text = "Lot Number:"
        '
        'txtLookPartDesc
        '
        Me.txtLookPartDesc.Location = New System.Drawing.Point(104, 187)
        Me.txtLookPartDesc.Name = "txtLookPartDesc"
        Me.txtLookPartDesc.Size = New System.Drawing.Size(153, 20)
        Me.txtLookPartDesc.TabIndex = 30
        '
        'txtLookHeatNumber
        '
        Me.txtLookHeatNumber.Location = New System.Drawing.Point(104, 213)
        Me.txtLookHeatNumber.Name = "txtLookHeatNumber"
        Me.txtLookHeatNumber.Size = New System.Drawing.Size(155, 20)
        Me.txtLookHeatNumber.TabIndex = 30
        '
        'txtLookLotNum
        '
        Me.txtLookLotNum.Location = New System.Drawing.Point(104, 109)
        Me.txtLookLotNum.Name = "txtLookLotNum"
        Me.txtLookLotNum.Size = New System.Drawing.Size(155, 20)
        Me.txtLookLotNum.TabIndex = 30
        '
        'lblDescView
        '
        Me.lblDescView.AutoSize = True
        Me.lblDescView.Location = New System.Drawing.Point(17, 191)
        Me.lblDescView.Name = "lblDescView"
        Me.lblDescView.Size = New System.Drawing.Size(85, 13)
        Me.lblDescView.TabIndex = 29
        Me.lblDescView.Text = "Part Description:"
        '
        'txtLookPartNum
        '
        Me.txtLookPartNum.Location = New System.Drawing.Point(104, 161)
        Me.txtLookPartNum.Name = "txtLookPartNum"
        Me.txtLookPartNum.Size = New System.Drawing.Size(153, 20)
        Me.txtLookPartNum.TabIndex = 30
        '
        'lblPartView
        '
        Me.lblPartView.AutoSize = True
        Me.lblPartView.Location = New System.Drawing.Point(17, 165)
        Me.lblPartView.Name = "lblPartView"
        Me.lblPartView.Size = New System.Drawing.Size(69, 13)
        Me.lblPartView.TabIndex = 29
        Me.lblPartView.Text = "Part Number:"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(104, 135)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(153, 20)
        Me.txtSearch.TabIndex = 29
        '
        'lblText
        '
        Me.lblText.Location = New System.Drawing.Point(17, 135)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(88, 20)
        Me.lblText.TabIndex = 23
        Me.lblText.Text = "Keyword Search:"
        Me.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvStructCert
        '
        Me.dgvStructCert.AutoGenerateColumns = False
        Me.dgvStructCert.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStructCert.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LotNumberDataGridViewTextBoxColumn, Me.HeatNumberDataGridViewTextBoxColumn, Me.PartNumberDataGridViewTextBoxColumn, Me.PartDescriptionDataGridViewTextBoxColumn, Me.ItemClassDataGridViewTextBoxColumn, Me.SalesIDDataGridViewTextBoxColumn, Me.VendorDataGridViewTextBoxColumn, Me.DateDataGridViewTextBoxColumn, Me.PDFStatusDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn})
        Me.dgvStructCert.DataSource = Me.StructuralCertTableBindingSource
        Me.dgvStructCert.Location = New System.Drawing.Point(306, 36)
        Me.dgvStructCert.Name = "dgvStructCert"
        Me.dgvStructCert.Size = New System.Drawing.Size(889, 829)
        Me.dgvStructCert.TabIndex = 18
        '
        'StructuralCertTableBindingSource
        '
        Me.StructuralCertTableBindingSource.DataMember = "StructuralCertTable"
        Me.StructuralCertTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(110, 315)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(87, 36)
        Me.cmdClear.TabIndex = 19
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdViewPDF
        '
        Me.cmdViewPDF.Location = New System.Drawing.Point(231, 815)
        Me.cmdViewPDF.Name = "cmdViewPDF"
        Me.cmdViewPDF.Size = New System.Drawing.Size(65, 36)
        Me.cmdViewPDF.TabIndex = 24
        Me.cmdViewPDF.Text = "View Struct Cert"
        Me.cmdViewPDF.UseVisualStyleBackColor = True
        '
        'cmdViewAll
        '
        Me.cmdViewAll.Location = New System.Drawing.Point(156, 815)
        Me.cmdViewAll.Name = "cmdViewAll"
        Me.cmdViewAll.Size = New System.Drawing.Size(65, 36)
        Me.cmdViewAll.TabIndex = 25
        Me.cmdViewAll.Text = "View All"
        Me.cmdViewAll.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.HelpToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1192, 24)
        Me.MenuStrip1.TabIndex = 26
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
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddUpdateToolStripMenuItem, Me.ClearToolStripMenuItem, Me.RemoveToolStripMenuItem, Me.ScanCertToolStripMenuItem, Me.UploadCertToolStripMenuItem, Me.ViewVsViewAllToolStripMenuItem, Me.KeywordSearchingToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AddUpdateToolStripMenuItem
        '
        Me.AddUpdateToolStripMenuItem.Name = "AddUpdateToolStripMenuItem"
        Me.AddUpdateToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.AddUpdateToolStripMenuItem.Text = "Add/Update"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'ScanCertToolStripMenuItem
        '
        Me.ScanCertToolStripMenuItem.Name = "ScanCertToolStripMenuItem"
        Me.ScanCertToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ScanCertToolStripMenuItem.Text = "Scan Cert"
        '
        'UploadCertToolStripMenuItem
        '
        Me.UploadCertToolStripMenuItem.Name = "UploadCertToolStripMenuItem"
        Me.UploadCertToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.UploadCertToolStripMenuItem.Text = "Upload Cert"
        '
        'ViewVsViewAllToolStripMenuItem
        '
        Me.ViewVsViewAllToolStripMenuItem.Name = "ViewVsViewAllToolStripMenuItem"
        Me.ViewVsViewAllToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ViewVsViewAllToolStripMenuItem.Text = "View vs. View All"
        '
        'KeywordSearchingToolStripMenuItem
        '
        Me.KeywordSearchingToolStripMenuItem.Name = "KeywordSearchingToolStripMenuItem"
        Me.KeywordSearchingToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.KeywordSearchingToolStripMenuItem.Text = "Keyword Searching"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmailPDFOfStructCertToolStripMenuItem, Me.EmailCoCOfCurrentLotToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'EmailPDFOfStructCertToolStripMenuItem
        '
        Me.EmailPDFOfStructCertToolStripMenuItem.Name = "EmailPDFOfStructCertToolStripMenuItem"
        Me.EmailPDFOfStructCertToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.EmailPDFOfStructCertToolStripMenuItem.Text = "Email PDF of Struct Cert"
        '
        'EmailCoCOfCurrentLotToolStripMenuItem
        '
        Me.EmailCoCOfCurrentLotToolStripMenuItem.Name = "EmailCoCOfCurrentLotToolStripMenuItem"
        Me.EmailCoCOfCurrentLotToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.EmailCoCOfCurrentLotToolStripMenuItem.Text = "Email Cert Of Compliance of"
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
        'cmdScan
        '
        Me.cmdScan.Location = New System.Drawing.Point(5, 367)
        Me.cmdScan.Name = "cmdScan"
        Me.cmdScan.Size = New System.Drawing.Size(87, 36)
        Me.cmdScan.TabIndex = 27
        Me.cmdScan.Text = "Scan Cert"
        Me.cmdScan.UseVisualStyleBackColor = True
        '
        'cmdUpload
        '
        Me.cmdUpload.Location = New System.Drawing.Point(214, 367)
        Me.cmdUpload.Name = "cmdUpload"
        Me.cmdUpload.Size = New System.Drawing.Size(87, 36)
        Me.cmdUpload.TabIndex = 28
        Me.cmdUpload.Text = "Upload Cert"
        Me.cmdUpload.UseVisualStyleBackColor = True
        '
        'cmdRemoteScan
        '
        Me.cmdRemoteScan.Location = New System.Drawing.Point(110, 367)
        Me.cmdRemoteScan.Name = "cmdRemoteScan"
        Me.cmdRemoteScan.Size = New System.Drawing.Size(87, 36)
        Me.cmdRemoteScan.TabIndex = 29
        Me.cmdRemoteScan.Text = "Scan Cert"
        Me.cmdRemoteScan.UseVisualStyleBackColor = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'grpCOC
        '
        Me.grpCOC.Controls.Add(Me.lblCoC)
        Me.grpCOC.Controls.Add(Me.cboCustomerID)
        Me.grpCOC.Location = New System.Drawing.Point(6, 758)
        Me.grpCOC.Name = "grpCOC"
        Me.grpCOC.Size = New System.Drawing.Size(294, 51)
        Me.grpCOC.TabIndex = 30
        Me.grpCOC.TabStop = False
        Me.grpCOC.Text = "CoC Customer (If Emailing CoC)"
        '
        'lblCoC
        '
        Me.lblCoC.AutoSize = True
        Me.lblCoC.Location = New System.Drawing.Point(17, 22)
        Me.lblCoC.Name = "lblCoC"
        Me.lblCoC.Size = New System.Drawing.Size(54, 13)
        Me.lblCoC.TabIndex = 34
        Me.lblCoC.Text = "Customer:"
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(104, 19)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(155, 21)
        Me.cboCustomerID.TabIndex = 30
        '
        'StructuralCertTableTableAdapter
        '
        Me.StructuralCertTableTableAdapter.ClearBeforeFill = True
        '
        'LotNumberDataGridViewTextBoxColumn
        '
        Me.LotNumberDataGridViewTextBoxColumn.DataPropertyName = "LotNumber"
        Me.LotNumberDataGridViewTextBoxColumn.HeaderText = "Lot Number"
        Me.LotNumberDataGridViewTextBoxColumn.Name = "LotNumberDataGridViewTextBoxColumn"
        Me.LotNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'HeatNumberDataGridViewTextBoxColumn
        '
        Me.HeatNumberDataGridViewTextBoxColumn.DataPropertyName = "HeatNumber"
        Me.HeatNumberDataGridViewTextBoxColumn.HeaderText = "Heat Number"
        Me.HeatNumberDataGridViewTextBoxColumn.Name = "HeatNumberDataGridViewTextBoxColumn"
        Me.HeatNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PartNumberDataGridViewTextBoxColumn
        '
        Me.PartNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn.HeaderText = "Part Number"
        Me.PartNumberDataGridViewTextBoxColumn.Name = "PartNumberDataGridViewTextBoxColumn"
        Me.PartNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PartDescriptionDataGridViewTextBoxColumn
        '
        Me.PartDescriptionDataGridViewTextBoxColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionDataGridViewTextBoxColumn.HeaderText = "Part Description"
        Me.PartDescriptionDataGridViewTextBoxColumn.Name = "PartDescriptionDataGridViewTextBoxColumn"
        Me.PartDescriptionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ItemClassDataGridViewTextBoxColumn
        '
        Me.ItemClassDataGridViewTextBoxColumn.DataPropertyName = "ItemClass"
        Me.ItemClassDataGridViewTextBoxColumn.HeaderText = "Item Class"
        Me.ItemClassDataGridViewTextBoxColumn.Name = "ItemClassDataGridViewTextBoxColumn"
        Me.ItemClassDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SalesIDDataGridViewTextBoxColumn
        '
        Me.SalesIDDataGridViewTextBoxColumn.DataPropertyName = "SalesID"
        Me.SalesIDDataGridViewTextBoxColumn.HeaderText = "Sales ID"
        Me.SalesIDDataGridViewTextBoxColumn.Name = "SalesIDDataGridViewTextBoxColumn"
        Me.SalesIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VendorDataGridViewTextBoxColumn
        '
        Me.VendorDataGridViewTextBoxColumn.DataPropertyName = "Vendor"
        Me.VendorDataGridViewTextBoxColumn.HeaderText = "Vendor"
        Me.VendorDataGridViewTextBoxColumn.Name = "VendorDataGridViewTextBoxColumn"
        Me.VendorDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DateDataGridViewTextBoxColumn
        '
        Me.DateDataGridViewTextBoxColumn.DataPropertyName = "Date"
        Me.DateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateDataGridViewTextBoxColumn.Name = "DateDataGridViewTextBoxColumn"
        Me.DateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PDFStatusDataGridViewTextBoxColumn
        '
        Me.PDFStatusDataGridViewTextBoxColumn.DataPropertyName = "PDFStatus"
        Me.PDFStatusDataGridViewTextBoxColumn.HeaderText = "PDF Status"
        Me.PDFStatusDataGridViewTextBoxColumn.Name = "PDFStatusDataGridViewTextBoxColumn"
        Me.PDFStatusDataGridViewTextBoxColumn.ReadOnly = True
        '
        'StatusDataGridViewTextBoxColumn
        '
        Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
        Me.StatusDataGridViewTextBoxColumn.HeaderText = "Status"
        Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
        Me.StatusDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ViewStructuralCerts
        '
        Me.AcceptButton = Me.cmdAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(1192, 863)
        Me.Controls.Add(Me.grpCOC)
        Me.Controls.Add(Me.cmdRemoteScan)
        Me.Controls.Add(Me.cmdUpload)
        Me.Controls.Add(Me.cmdScan)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cmdViewAll)
        Me.Controls.Add(Me.cmdViewPDF)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.dgvStructCert)
        Me.Controls.Add(Me.grpView)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdView)
        Me.Controls.Add(Me.cmdRemove)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.grpPart)
        Me.MaximizeBox = False
        Me.Name = "ViewStructuralCerts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Structural Certification Form"
        Me.grpPart.ResumeLayout(False)
        Me.grpPart.PerformLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpView.ResumeLayout(False)
        Me.grpView.PerformLayout()
        CType(Me.dgvStructCert, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StructuralCertTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.grpCOC.ResumeLayout(False)
        Me.grpCOC.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblLotNumber As System.Windows.Forms.Label
    Friend WithEvents txtLotNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtHeatNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblHeatNumber As System.Windows.Forms.Label
    Friend WithEvents lblComment As System.Windows.Forms.Label
    Friend WithEvents lblPartDesc As System.Windows.Forms.Label
    Friend WithEvents lblPartNum As System.Windows.Forms.Label
    Friend WithEvents grpPart As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdRemove As System.Windows.Forms.Button
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cboSalesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblSalesId As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndD As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblBeginD As System.Windows.Forms.Label
    Friend WithEvents lblVendor As System.Windows.Forms.Label
    Friend WithEvents grpView As System.Windows.Forms.GroupBox
    Friend WithEvents dgvStructCert As System.Windows.Forms.DataGridView
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents dtpDateEntry As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents lblText As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cmdViewPDF As System.Windows.Forms.Button
    Friend WithEvents lblLotNum As System.Windows.Forms.Label
    Friend WithEvents txtLookPartDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtLookLotNum As System.Windows.Forms.TextBox
    Friend WithEvents lblDescView As System.Windows.Forms.Label
    Friend WithEvents txtLookPartNum As System.Windows.Forms.TextBox
    Friend WithEvents lblPartView As System.Windows.Forms.Label
    Friend WithEvents txtLookVendorView As System.Windows.Forms.TextBox
    Friend WithEvents lblVendorView As System.Windows.Forms.Label
    Friend WithEvents txtLookSalesID As System.Windows.Forms.RichTextBox
    Friend WithEvents lblCommentView As System.Windows.Forms.Label
    Friend WithEvents lblHeatNum As System.Windows.Forms.Label
    Friend WithEvents txtLookHeatNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmdViewAll As System.Windows.Forms.Button
    Friend WithEvents chkPDFScanned As System.Windows.Forms.CheckBox
    Friend WithEvents chkOpen As System.Windows.Forms.CheckBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdScan As System.Windows.Forms.Button
    Friend WithEvents cmdUpload As System.Windows.Forms.Button
    Friend WithEvents cboVendor As System.Windows.Forms.ComboBox
    Friend WithEvents cmdRemoteScan As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScanCertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadCertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewVsViewAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeywordSearchingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents EmailPDFOfStructCertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmailCoCOfCurrentLotToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpCOC As System.Windows.Forms.GroupBox
    Friend WithEvents lblCoC As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents StructuralCertTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StructuralCertTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StructuralCertTableTableAdapter
    Friend WithEvents LotNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PDFStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
