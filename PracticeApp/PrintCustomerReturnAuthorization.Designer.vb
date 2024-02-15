<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintCustomerReturnAuthorization
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
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteCurrentRMAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmailAuthorizationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewAllRMAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CRCustomerYTDViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.CRXCustReturnGoods1 = New MOS09Program.CRXCustReturnGoods()
        Me.cboCustomer = New System.Windows.Forms.ComboBox()
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet()
        Me.cmdViewByFilters = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCustomerName = New System.Windows.Forms.ComboBox()
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.cboDivision = New System.Windows.Forms.ComboBox()
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblFoxNum = New System.Windows.Forms.Label()
        Me.cboFox = New System.Windows.Forms.ComboBox()
        Me.FOXTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblNumberOfParts = New System.Windows.Forms.Label()
        Me.txtNumberofParts = New System.Windows.Forms.TextBox()
        Me.lblType = New System.Windows.Forms.Label()
        Me.cboReturnType = New System.Windows.Forms.ComboBox()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.txtRemark = New System.Windows.Forms.RichTextBox()
        Me.txtDelivery = New System.Windows.Forms.TextBox()
        Me.lblDelivery = New System.Windows.Forms.Label()
        Me.lblPurchaseOrder = New System.Windows.Forms.Label()
        Me.txtReason = New System.Windows.Forms.RichTextBox()
        Me.lblReason = New System.Windows.Forms.Label()
        Me.cmdGenerateNewSO = New System.Windows.Forms.Button()
        Me.cboReturnGoodNum = New System.Windows.Forms.ComboBox()
        Me.RMATableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label700 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter()
        Me.FOXTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter()
        Me.PurchaseOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PurchaseOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter()
        Me.txtPO = New System.Windows.Forms.TextBox()
        Me.RMATableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RMATableTableAdapter()
        Me.txtPartsBy = New System.Windows.Forms.TextBox()
        Me.lblCustNeedParts = New System.Windows.Forms.Label()
        Me.lblSignature = New System.Windows.Forms.Label()
        Me.lblSignDate = New System.Windows.Forms.Label()
        Me.txtSignatureDate = New System.Windows.Forms.DateTimePicker()
        Me.txtSignature = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RMATableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1084, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteCurrentRMAToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteCurrentRMAToolStripMenuItem
        '
        Me.DeleteCurrentRMAToolStripMenuItem.Name = "DeleteCurrentRMAToolStripMenuItem"
        Me.DeleteCurrentRMAToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.DeleteCurrentRMAToolStripMenuItem.Text = "Delete Current RMA"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmailAuthorizationToolStripMenuItem, Me.ViewAllRMAsToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'EmailAuthorizationToolStripMenuItem
        '
        Me.EmailAuthorizationToolStripMenuItem.Name = "EmailAuthorizationToolStripMenuItem"
        Me.EmailAuthorizationToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.EmailAuthorizationToolStripMenuItem.Text = "Email Authorization"
        '
        'ViewAllRMAsToolStripMenuItem
        '
        Me.ViewAllRMAsToolStripMenuItem.Name = "ViewAllRMAsToolStripMenuItem"
        Me.ViewAllRMAsToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ViewAllRMAsToolStripMenuItem.Text = "View All RMAs"
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
        'CRCustomerYTDViewer
        '
        Me.CRCustomerYTDViewer.ActiveViewIndex = -1
        Me.CRCustomerYTDViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CRCustomerYTDViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRCustomerYTDViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRCustomerYTDViewer.Location = New System.Drawing.Point(183, 24)
        Me.CRCustomerYTDViewer.Name = "CRCustomerYTDViewer"
        Me.CRCustomerYTDViewer.SelectionFormula = ""
        Me.CRCustomerYTDViewer.ShowGroupTreeButton = False
        Me.CRCustomerYTDViewer.ShowLogo = False
        Me.CRCustomerYTDViewer.ShowParameterPanelButton = False
        Me.CRCustomerYTDViewer.ShowTextSearchButton = False
        Me.CRCustomerYTDViewer.ShowZoomButton = False
        Me.CRCustomerYTDViewer.Size = New System.Drawing.Size(901, 710)
        Me.CRCustomerYTDViewer.TabIndex = 1
        Me.CRCustomerYTDViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.CRCustomerYTDViewer.ViewTimeSelectionFormula = ""
        '
        'cboCustomer
        '
        Me.cboCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomer.DataSource = Me.CustomerListBindingSource
        Me.cboCustomer.DisplayMember = "CustomerID"
        Me.cboCustomer.FormattingEnabled = True
        Me.cboCustomer.Location = New System.Drawing.Point(2, 115)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(156, 21)
        Me.cboCustomer.TabIndex = 3
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(5, 676)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(75, 23)
        Me.cmdViewByFilters.TabIndex = 12
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(87, 676)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(75, 23)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Customer"
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Customer Contact"
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "APContactName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(2, 151)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(156, 21)
        Me.cboCustomerName.TabIndex = 4
        '
        'EmployeeDataBindingSource
        '
        Me.EmployeeDataBindingSource.DataMember = "EmployeeData"
        Me.EmployeeDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'EmployeeDataTableAdapter
        '
        Me.EmployeeDataTableAdapter.ClearBeforeFill = True
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Location = New System.Drawing.Point(2, 65)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(44, 13)
        Me.lblDivision.TabIndex = 34
        Me.lblDivision.Text = "Division"
        '
        'cboDivision
        '
        Me.cboDivision.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivision.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivision.FormattingEnabled = True
        Me.cboDivision.Location = New System.Drawing.Point(2, 79)
        Me.cboDivision.Name = "cboDivision"
        Me.cboDivision.Size = New System.Drawing.Size(156, 21)
        Me.cboDivision.TabIndex = 2
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'lblFoxNum
        '
        Me.lblFoxNum.AutoSize = True
        Me.lblFoxNum.Location = New System.Drawing.Point(2, 173)
        Me.lblFoxNum.Name = "lblFoxNum"
        Me.lblFoxNum.Size = New System.Drawing.Size(64, 13)
        Me.lblFoxNum.TabIndex = 36
        Me.lblFoxNum.Text = "Fox Number"
        '
        'cboFox
        '
        Me.cboFox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFox.DataSource = Me.FOXTableBindingSource
        Me.cboFox.DisplayMember = "FOXNumber"
        Me.cboFox.FormattingEnabled = True
        Me.cboFox.Location = New System.Drawing.Point(2, 187)
        Me.cboFox.Name = "cboFox"
        Me.cboFox.Size = New System.Drawing.Size(156, 21)
        Me.cboFox.TabIndex = 5
        '
        'FOXTableBindingSource
        '
        Me.FOXTableBindingSource.DataMember = "FOXTable"
        Me.FOXTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'lblNumberOfParts
        '
        Me.lblNumberOfParts.AutoSize = True
        Me.lblNumberOfParts.Location = New System.Drawing.Point(2, 209)
        Me.lblNumberOfParts.Name = "lblNumberOfParts"
        Me.lblNumberOfParts.Size = New System.Drawing.Size(85, 13)
        Me.lblNumberOfParts.TabIndex = 37
        Me.lblNumberOfParts.Text = "Number Of Parts"
        '
        'txtNumberofParts
        '
        Me.txtNumberofParts.Location = New System.Drawing.Point(2, 223)
        Me.txtNumberofParts.Name = "txtNumberofParts"
        Me.txtNumberofParts.Size = New System.Drawing.Size(156, 20)
        Me.txtNumberofParts.TabIndex = 6
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(2, 344)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(61, 13)
        Me.lblType.TabIndex = 40
        Me.lblType.Text = "How To Fix"
        '
        'cboReturnType
        '
        Me.cboReturnType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReturnType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReturnType.FormattingEnabled = True
        Me.cboReturnType.Items.AddRange(New Object() {"Rework", "Scrap", "Other"})
        Me.cboReturnType.Location = New System.Drawing.Point(2, 358)
        Me.cboReturnType.Name = "cboReturnType"
        Me.cboReturnType.Size = New System.Drawing.Size(156, 21)
        Me.cboReturnType.TabIndex = 8
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Location = New System.Drawing.Point(2, 380)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(49, 13)
        Me.lblRemarks.TabIndex = 41
        Me.lblRemarks.Text = "Remarks"
        '
        'txtRemark
        '
        Me.txtRemark.Location = New System.Drawing.Point(2, 394)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(156, 85)
        Me.txtRemark.TabIndex = 9
        Me.txtRemark.Text = ""
        '
        'txtDelivery
        '
        Me.txtDelivery.Location = New System.Drawing.Point(2, 494)
        Me.txtDelivery.Name = "txtDelivery"
        Me.txtDelivery.Size = New System.Drawing.Size(156, 20)
        Me.txtDelivery.TabIndex = 10
        '
        'lblDelivery
        '
        Me.lblDelivery.AutoSize = True
        Me.lblDelivery.Location = New System.Drawing.Point(2, 480)
        Me.lblDelivery.Name = "lblDelivery"
        Me.lblDelivery.Size = New System.Drawing.Size(124, 13)
        Me.lblDelivery.TabIndex = 44
        Me.lblDelivery.Text = "Authorized Trucking Firm"
        '
        'lblPurchaseOrder
        '
        Me.lblPurchaseOrder.AutoSize = True
        Me.lblPurchaseOrder.Location = New System.Drawing.Point(2, 515)
        Me.lblPurchaseOrder.Name = "lblPurchaseOrder"
        Me.lblPurchaseOrder.Size = New System.Drawing.Size(121, 13)
        Me.lblPurchaseOrder.TabIndex = 47
        Me.lblPurchaseOrder.Text = "Purchase Order Number"
        '
        'txtReason
        '
        Me.txtReason.Location = New System.Drawing.Point(2, 258)
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(156, 85)
        Me.txtReason.TabIndex = 7
        Me.txtReason.Text = ""
        '
        'lblReason
        '
        Me.lblReason.AutoSize = True
        Me.lblReason.Location = New System.Drawing.Point(2, 244)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(97, 13)
        Me.lblReason.TabIndex = 48
        Me.lblReason.Text = "Reason For Return"
        '
        'cmdGenerateNewSO
        '
        Me.cmdGenerateNewSO.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateNewSO.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateNewSO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateNewSO.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateNewSO.Location = New System.Drawing.Point(2, 44)
        Me.cmdGenerateNewSO.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateNewSO.Name = "cmdGenerateNewSO"
        Me.cmdGenerateNewSO.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateNewSO.TabIndex = 0
        Me.cmdGenerateNewSO.Text = ">>"
        Me.cmdGenerateNewSO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateNewSO.UseVisualStyleBackColor = False
        '
        'cboReturnGoodNum
        '
        Me.cboReturnGoodNum.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReturnGoodNum.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReturnGoodNum.DataSource = Me.RMATableBindingSource
        Me.cboReturnGoodNum.DisplayMember = "AuthorizationNumber"
        Me.cboReturnGoodNum.FormattingEnabled = True
        Me.cboReturnGoodNum.Location = New System.Drawing.Point(34, 44)
        Me.cboReturnGoodNum.Name = "cboReturnGoodNum"
        Me.cboReturnGoodNum.Size = New System.Drawing.Size(124, 21)
        Me.cboReturnGoodNum.TabIndex = 1
        '
        'RMATableBindingSource
        '
        Me.RMATableBindingSource.DataMember = "RMATable"
        Me.RMATableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label700
        '
        Me.Label700.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label700.Location = New System.Drawing.Point(2, 24)
        Me.Label700.Name = "Label700"
        Me.Label700.Size = New System.Drawing.Size(160, 19)
        Me.Label700.TabIndex = 52
        Me.Label700.Text = "Return Goods Authorization #"
        Me.Label700.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(5, 705)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(87, 705)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'FOXTableTableAdapter
        '
        Me.FOXTableTableAdapter.ClearBeforeFill = True
        '
        'PurchaseOrderHeaderTableBindingSource
        '
        Me.PurchaseOrderHeaderTableBindingSource.DataMember = "PurchaseOrderHeaderTable"
        Me.PurchaseOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'PurchaseOrderHeaderTableTableAdapter
        '
        Me.PurchaseOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'txtPO
        '
        Me.txtPO.Location = New System.Drawing.Point(2, 529)
        Me.txtPO.Name = "txtPO"
        Me.txtPO.Size = New System.Drawing.Size(156, 20)
        Me.txtPO.TabIndex = 11
        '
        'RMATableTableAdapter
        '
        Me.RMATableTableAdapter.ClearBeforeFill = True
        '
        'txtPartsBy
        '
        Me.txtPartsBy.Location = New System.Drawing.Point(2, 566)
        Me.txtPartsBy.Name = "txtPartsBy"
        Me.txtPartsBy.Size = New System.Drawing.Size(156, 20)
        Me.txtPartsBy.TabIndex = 53
        '
        'lblCustNeedParts
        '
        Me.lblCustNeedParts.AutoSize = True
        Me.lblCustNeedParts.Location = New System.Drawing.Point(2, 552)
        Me.lblCustNeedParts.Name = "lblCustNeedParts"
        Me.lblCustNeedParts.Size = New System.Drawing.Size(75, 13)
        Me.lblCustNeedParts.TabIndex = 54
        Me.lblCustNeedParts.Text = "Need Parts By"
        '
        'lblSignature
        '
        Me.lblSignature.AutoSize = True
        Me.lblSignature.Location = New System.Drawing.Point(2, 589)
        Me.lblSignature.Name = "lblSignature"
        Me.lblSignature.Size = New System.Drawing.Size(103, 13)
        Me.lblSignature.TabIndex = 56
        Me.lblSignature.Text = "Q.A. Representative"
        '
        'lblSignDate
        '
        Me.lblSignDate.AutoSize = True
        Me.lblSignDate.Location = New System.Drawing.Point(2, 629)
        Me.lblSignDate.Name = "lblSignDate"
        Me.lblSignDate.Size = New System.Drawing.Size(129, 13)
        Me.lblSignDate.TabIndex = 58
        Me.lblSignDate.Text = "Q.A. Representative Date"
        '
        'txtSignatureDate
        '
        Me.txtSignatureDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtSignatureDate.Location = New System.Drawing.Point(2, 645)
        Me.txtSignatureDate.Name = "txtSignatureDate"
        Me.txtSignatureDate.Size = New System.Drawing.Size(156, 20)
        Me.txtSignatureDate.TabIndex = 59
        '
        'txtSignature
        '
        Me.txtSignature.FormattingEnabled = True
        Me.txtSignature.Items.AddRange(New Object() {"Sue Balliet", "Samuel T. Ray"})
        Me.txtSignature.Location = New System.Drawing.Point(2, 605)
        Me.txtSignature.Name = "txtSignature"
        Me.txtSignature.Size = New System.Drawing.Size(156, 21)
        Me.txtSignature.TabIndex = 60
        '
        'PrintCustomerReturnAuthorization
        '
        Me.AcceptButton = Me.cmdViewByFilters
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1084, 734)
        Me.Controls.Add(Me.txtSignature)
        Me.Controls.Add(Me.txtSignatureDate)
        Me.Controls.Add(Me.lblSignDate)
        Me.Controls.Add(Me.lblSignature)
        Me.Controls.Add(Me.txtPartsBy)
        Me.Controls.Add(Me.lblCustNeedParts)
        Me.Controls.Add(Me.txtPO)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cmdGenerateNewSO)
        Me.Controls.Add(Me.cboReturnGoodNum)
        Me.Controls.Add(Me.Label700)
        Me.Controls.Add(Me.txtReason)
        Me.Controls.Add(Me.lblReason)
        Me.Controls.Add(Me.lblPurchaseOrder)
        Me.Controls.Add(Me.txtDelivery)
        Me.Controls.Add(Me.lblDelivery)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.cboReturnType)
        Me.Controls.Add(Me.txtNumberofParts)
        Me.Controls.Add(Me.lblNumberOfParts)
        Me.Controls.Add(Me.lblFoxNum)
        Me.Controls.Add(Me.cboFox)
        Me.Controls.Add(Me.lblDivision)
        Me.Controls.Add(Me.cboDivision)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboCustomerName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdViewByFilters)
        Me.Controls.Add(Me.cboCustomer)
        Me.Controls.Add(Me.CRCustomerYTDViewer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "PrintCustomerReturnAuthorization"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Return Goods Authorization Form"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RMATableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CRCustomerYTDViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents lblDivision As System.Windows.Forms.Label
    Friend WithEvents cboDivision As System.Windows.Forms.ComboBox
    Friend WithEvents lblFoxNum As System.Windows.Forms.Label
    Friend WithEvents cboFox As System.Windows.Forms.ComboBox
    Friend WithEvents lblNumberOfParts As System.Windows.Forms.Label
    Friend WithEvents txtNumberofParts As System.Windows.Forms.TextBox
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents cboReturnType As System.Windows.Forms.ComboBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.RichTextBox
    Friend WithEvents txtDelivery As System.Windows.Forms.TextBox
    Friend WithEvents lblDelivery As System.Windows.Forms.Label
    Friend WithEvents lblPurchaseOrder As System.Windows.Forms.Label
    Friend WithEvents txtReason As System.Windows.Forms.RichTextBox
    Friend WithEvents lblReason As System.Windows.Forms.Label
    Friend WithEvents cmdGenerateNewSO As System.Windows.Forms.Button
    Friend WithEvents cboReturnGoodNum As System.Windows.Forms.ComboBox
    Friend WithEvents Label700 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents CRXCustReturnGoods1 As MOS09Program.CRXCustReturnGoods
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents FOXTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FOXTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
    Friend WithEvents cboPurchaseOrder As System.Windows.Forms.ComboBox
    Friend WithEvents PurchaseOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
    Friend WithEvents txtPO As System.Windows.Forms.TextBox
    Friend WithEvents EmailAuthorizationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RMATableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RMATableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RMATableTableAdapter
    Friend WithEvents txtPartsBy As System.Windows.Forms.TextBox
    Friend WithEvents lblCustNeedParts As System.Windows.Forms.Label
    Friend WithEvents lblSignature As System.Windows.Forms.Label
    Friend WithEvents lblSignDate As System.Windows.Forms.Label
    Friend WithEvents txtSignatureDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSignature As System.Windows.Forms.ComboBox
    Friend WithEvents ViewAllRMAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteCurrentRMAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
