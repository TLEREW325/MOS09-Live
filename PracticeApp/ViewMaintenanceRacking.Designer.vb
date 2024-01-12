<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewMaintenanceRacking
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
        Me.lblRackLocation = New System.Windows.Forms.Label
        Me.txtRackLocation = New System.Windows.Forms.TextBox
        Me.txtWeight = New System.Windows.Forms.TextBox
        Me.lblWeight = New System.Windows.Forms.Label
        Me.lblComment = New System.Windows.Forms.Label
        Me.rchComment = New System.Windows.Forms.RichTextBox
        Me.lblPartDesc = New System.Windows.Forms.Label
        Me.lblPartNum = New System.Windows.Forms.Label
        Me.grpPart = New System.Windows.Forms.GroupBox
        Me.txtVendor = New System.Windows.Forms.TextBox
        Me.txtDesc = New System.Windows.Forms.TextBox
        Me.txtPartNum = New System.Windows.Forms.TextBox
        Me.lblDate = New System.Windows.Forms.Label
        Me.dtpDateEntry = New System.Windows.Forms.DateTimePicker
        Me.lblVendor = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.lblDivision = New System.Windows.Forms.Label
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
        Me.txtVendorView = New System.Windows.Forms.TextBox
        Me.lblVendorView = New System.Windows.Forms.Label
        Me.txtCommentView = New System.Windows.Forms.RichTextBox
        Me.lblCommentView = New System.Windows.Forms.Label
        Me.lblWeightView = New System.Windows.Forms.Label
        Me.lblBinView = New System.Windows.Forms.Label
        Me.txtPartDescView = New System.Windows.Forms.TextBox
        Me.txtWeightView = New System.Windows.Forms.TextBox
        Me.txtBinNumView = New System.Windows.Forms.TextBox
        Me.lblDescView = New System.Windows.Forms.Label
        Me.txtPartNumView = New System.Windows.Forms.TextBox
        Me.lblPartView = New System.Windows.Forms.Label
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.lblKeywordExplain = New System.Windows.Forms.Label
        Me.lblText = New System.Windows.Forms.Label
        Me.dgvMainRack = New System.Windows.Forms.DataGridView
        Me.PartNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BinNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaintenanceRackingTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.MaintenanceRackingTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.MaintenanceRackingTableTableAdapter
        Me.TableAdapterManager = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TableAdapterManager
        Me.cmdClear = New System.Windows.Forms.Button
        Me.rchNote = New System.Windows.Forms.RichTextBox
        Me.cmdViewReport = New System.Windows.Forms.Button
        Me.cmdViewAll = New System.Windows.Forms.Button
        Me.grpPart.SuspendLayout()
        Me.grpView.SuspendLayout()
        CType(Me.dgvMainRack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaintenanceRackingTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRackLocation
        '
        Me.lblRackLocation.AutoSize = True
        Me.lblRackLocation.Location = New System.Drawing.Point(18, 90)
        Me.lblRackLocation.Name = "lblRackLocation"
        Me.lblRackLocation.Size = New System.Drawing.Size(65, 13)
        Me.lblRackLocation.TabIndex = 1
        Me.lblRackLocation.Text = "Bin Number:"
        '
        'txtRackLocation
        '
        Me.txtRackLocation.Location = New System.Drawing.Point(104, 86)
        Me.txtRackLocation.Name = "txtRackLocation"
        Me.txtRackLocation.Size = New System.Drawing.Size(155, 20)
        Me.txtRackLocation.TabIndex = 2
        '
        'txtWeight
        '
        Me.txtWeight.Location = New System.Drawing.Point(104, 118)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(155, 20)
        Me.txtWeight.TabIndex = 4
        '
        'lblWeight
        '
        Me.lblWeight.AutoSize = True
        Me.lblWeight.Location = New System.Drawing.Point(18, 122)
        Me.lblWeight.Name = "lblWeight"
        Me.lblWeight.Size = New System.Drawing.Size(44, 13)
        Me.lblWeight.TabIndex = 3
        Me.lblWeight.Text = "Weight:"
        '
        'lblComment
        '
        Me.lblComment.AutoSize = True
        Me.lblComment.Location = New System.Drawing.Point(18, 153)
        Me.lblComment.Name = "lblComment"
        Me.lblComment.Size = New System.Drawing.Size(54, 13)
        Me.lblComment.TabIndex = 5
        Me.lblComment.Text = "Comment:"
        '
        'rchComment
        '
        Me.rchComment.Location = New System.Drawing.Point(104, 150)
        Me.rchComment.Name = "rchComment"
        Me.rchComment.Size = New System.Drawing.Size(155, 97)
        Me.rchComment.TabIndex = 6
        Me.rchComment.Text = ""
        '
        'lblPartDesc
        '
        Me.lblPartDesc.AutoSize = True
        Me.lblPartDesc.Location = New System.Drawing.Point(18, 58)
        Me.lblPartDesc.Name = "lblPartDesc"
        Me.lblPartDesc.Size = New System.Drawing.Size(85, 13)
        Me.lblPartDesc.TabIndex = 7
        Me.lblPartDesc.Text = "Part Description:"
        '
        'lblPartNum
        '
        Me.lblPartNum.AutoSize = True
        Me.lblPartNum.Location = New System.Drawing.Point(18, 26)
        Me.lblPartNum.Name = "lblPartNum"
        Me.lblPartNum.Size = New System.Drawing.Size(69, 13)
        Me.lblPartNum.TabIndex = 8
        Me.lblPartNum.Text = "Part Number:"
        '
        'grpPart
        '
        Me.grpPart.Controls.Add(Me.txtVendor)
        Me.grpPart.Controls.Add(Me.txtDesc)
        Me.grpPart.Controls.Add(Me.txtPartNum)
        Me.grpPart.Controls.Add(Me.lblDate)
        Me.grpPart.Controls.Add(Me.dtpDateEntry)
        Me.grpPart.Controls.Add(Me.lblVendor)
        Me.grpPart.Controls.Add(Me.cboDivisionID)
        Me.grpPart.Controls.Add(Me.lblDivision)
        Me.grpPart.Controls.Add(Me.lblRackLocation)
        Me.grpPart.Controls.Add(Me.txtRackLocation)
        Me.grpPart.Controls.Add(Me.lblPartNum)
        Me.grpPart.Controls.Add(Me.lblWeight)
        Me.grpPart.Controls.Add(Me.lblPartDesc)
        Me.grpPart.Controls.Add(Me.txtWeight)
        Me.grpPart.Controls.Add(Me.rchComment)
        Me.grpPart.Controls.Add(Me.lblComment)
        Me.grpPart.Location = New System.Drawing.Point(5, 3)
        Me.grpPart.Name = "grpPart"
        Me.grpPart.Size = New System.Drawing.Size(295, 354)
        Me.grpPart.TabIndex = 11
        Me.grpPart.TabStop = False
        Me.grpPart.Text = "Part Information"
        '
        'txtVendor
        '
        Me.txtVendor.Location = New System.Drawing.Point(104, 292)
        Me.txtVendor.Name = "txtVendor"
        Me.txtVendor.Size = New System.Drawing.Size(153, 20)
        Me.txtVendor.TabIndex = 28
        '
        'txtDesc
        '
        Me.txtDesc.Location = New System.Drawing.Point(104, 54)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(153, 20)
        Me.txtDesc.TabIndex = 27
        '
        'txtPartNum
        '
        Me.txtPartNum.Location = New System.Drawing.Point(104, 22)
        Me.txtPartNum.Name = "txtPartNum"
        Me.txtPartNum.Size = New System.Drawing.Size(153, 20)
        Me.txtPartNum.TabIndex = 26
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(18, 328)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(33, 13)
        Me.lblDate.TabIndex = 25
        Me.lblDate.Text = "Date:"
        '
        'dtpDateEntry
        '
        Me.dtpDateEntry.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateEntry.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateEntry.Location = New System.Drawing.Point(104, 324)
        Me.dtpDateEntry.Name = "dtpDateEntry"
        Me.dtpDateEntry.Size = New System.Drawing.Size(153, 20)
        Me.dtpDateEntry.TabIndex = 23
        '
        'lblVendor
        '
        Me.lblVendor.AutoSize = True
        Me.lblVendor.Location = New System.Drawing.Point(18, 296)
        Me.lblVendor.Name = "lblVendor"
        Me.lblVendor.Size = New System.Drawing.Size(44, 13)
        Me.lblVendor.TabIndex = 23
        Me.lblVendor.Text = "Vendor:"
        '
        'cboDivisionID
        '
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(104, 259)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(155, 21)
        Me.cboDivisionID.TabIndex = 12
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Location = New System.Drawing.Point(18, 263)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(47, 13)
        Me.lblDivision.TabIndex = 11
        Me.lblDivision.Text = "Division:"
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
        Me.dtpEndDate.Location = New System.Drawing.Point(104, 67)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(153, 20)
        Me.dtpEndDate.TabIndex = 21
        '
        'lblEndD
        '
        Me.lblEndD.Location = New System.Drawing.Point(15, 67)
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
        Me.cmdAdd.Location = New System.Drawing.Point(5, 363)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(87, 36)
        Me.cmdAdd.TabIndex = 12
        Me.cmdAdd.Text = "Add/Update"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmdRemove
        '
        Me.cmdRemove.Location = New System.Drawing.Point(213, 363)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(87, 36)
        Me.cmdRemove.TabIndex = 13
        Me.cmdRemove.Text = "Remove"
        Me.cmdRemove.UseVisualStyleBackColor = True
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(82, 795)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(65, 36)
        Me.cmdView.TabIndex = 14
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(5, 795)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(65, 36)
        Me.cmdClose.TabIndex = 15
        Me.cmdClose.Text = "Exit"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'grpView
        '
        Me.grpView.Controls.Add(Me.txtVendorView)
        Me.grpView.Controls.Add(Me.lblVendorView)
        Me.grpView.Controls.Add(Me.txtCommentView)
        Me.grpView.Controls.Add(Me.lblCommentView)
        Me.grpView.Controls.Add(Me.lblWeightView)
        Me.grpView.Controls.Add(Me.lblBinView)
        Me.grpView.Controls.Add(Me.txtPartDescView)
        Me.grpView.Controls.Add(Me.txtWeightView)
        Me.grpView.Controls.Add(Me.txtBinNumView)
        Me.grpView.Controls.Add(Me.lblDescView)
        Me.grpView.Controls.Add(Me.txtPartNumView)
        Me.grpView.Controls.Add(Me.lblPartView)
        Me.grpView.Controls.Add(Me.txtSearch)
        Me.grpView.Controls.Add(Me.lblKeywordExplain)
        Me.grpView.Controls.Add(Me.lblText)
        Me.grpView.Controls.Add(Me.chkDateRange)
        Me.grpView.Controls.Add(Me.lblBeginD)
        Me.grpView.Controls.Add(Me.dtpBeginDate)
        Me.grpView.Controls.Add(Me.dtpEndDate)
        Me.grpView.Controls.Add(Me.lblEndD)
        Me.grpView.Location = New System.Drawing.Point(5, 456)
        Me.grpView.Name = "grpView"
        Me.grpView.Size = New System.Drawing.Size(295, 326)
        Me.grpView.TabIndex = 17
        Me.grpView.TabStop = False
        Me.grpView.Text = "Search Function"
        '
        'txtVendorView
        '
        Me.txtVendorView.Location = New System.Drawing.Point(104, 301)
        Me.txtVendorView.Name = "txtVendorView"
        Me.txtVendorView.Size = New System.Drawing.Size(153, 20)
        Me.txtVendorView.TabIndex = 30
        '
        'lblVendorView
        '
        Me.lblVendorView.AutoSize = True
        Me.lblVendorView.Location = New System.Drawing.Point(15, 304)
        Me.lblVendorView.Name = "lblVendorView"
        Me.lblVendorView.Size = New System.Drawing.Size(44, 13)
        Me.lblVendorView.TabIndex = 29
        Me.lblVendorView.Text = "Vendor:"
        '
        'txtCommentView
        '
        Me.txtCommentView.Location = New System.Drawing.Point(104, 268)
        Me.txtCommentView.Name = "txtCommentView"
        Me.txtCommentView.Size = New System.Drawing.Size(153, 20)
        Me.txtCommentView.TabIndex = 30
        Me.txtCommentView.Text = ""
        '
        'lblCommentView
        '
        Me.lblCommentView.AutoSize = True
        Me.lblCommentView.Location = New System.Drawing.Point(15, 274)
        Me.lblCommentView.Name = "lblCommentView"
        Me.lblCommentView.Size = New System.Drawing.Size(54, 13)
        Me.lblCommentView.TabIndex = 29
        Me.lblCommentView.Text = "Comment:"
        '
        'lblWeightView
        '
        Me.lblWeightView.AutoSize = True
        Me.lblWeightView.Location = New System.Drawing.Point(15, 246)
        Me.lblWeightView.Name = "lblWeightView"
        Me.lblWeightView.Size = New System.Drawing.Size(44, 13)
        Me.lblWeightView.TabIndex = 29
        Me.lblWeightView.Text = "Weight:"
        '
        'lblBinView
        '
        Me.lblBinView.AutoSize = True
        Me.lblBinView.Location = New System.Drawing.Point(15, 220)
        Me.lblBinView.Name = "lblBinView"
        Me.lblBinView.Size = New System.Drawing.Size(65, 13)
        Me.lblBinView.TabIndex = 29
        Me.lblBinView.Text = "Bin Number:"
        '
        'txtPartDescView
        '
        Me.txtPartDescView.Location = New System.Drawing.Point(104, 190)
        Me.txtPartDescView.Name = "txtPartDescView"
        Me.txtPartDescView.Size = New System.Drawing.Size(153, 20)
        Me.txtPartDescView.TabIndex = 30
        '
        'txtWeightView
        '
        Me.txtWeightView.Location = New System.Drawing.Point(104, 242)
        Me.txtWeightView.Name = "txtWeightView"
        Me.txtWeightView.Size = New System.Drawing.Size(155, 20)
        Me.txtWeightView.TabIndex = 30
        '
        'txtBinNumView
        '
        Me.txtBinNumView.Location = New System.Drawing.Point(104, 216)
        Me.txtBinNumView.Name = "txtBinNumView"
        Me.txtBinNumView.Size = New System.Drawing.Size(155, 20)
        Me.txtBinNumView.TabIndex = 30
        '
        'lblDescView
        '
        Me.lblDescView.AutoSize = True
        Me.lblDescView.Location = New System.Drawing.Point(15, 194)
        Me.lblDescView.Name = "lblDescView"
        Me.lblDescView.Size = New System.Drawing.Size(85, 13)
        Me.lblDescView.TabIndex = 29
        Me.lblDescView.Text = "Part Description:"
        '
        'txtPartNumView
        '
        Me.txtPartNumView.Location = New System.Drawing.Point(104, 164)
        Me.txtPartNumView.Name = "txtPartNumView"
        Me.txtPartNumView.Size = New System.Drawing.Size(153, 20)
        Me.txtPartNumView.TabIndex = 30
        '
        'lblPartView
        '
        Me.lblPartView.AutoSize = True
        Me.lblPartView.Location = New System.Drawing.Point(15, 168)
        Me.lblPartView.Name = "lblPartView"
        Me.lblPartView.Size = New System.Drawing.Size(69, 13)
        Me.lblPartView.TabIndex = 29
        Me.lblPartView.Text = "Part Number:"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(104, 138)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(153, 20)
        Me.txtSearch.TabIndex = 29
        '
        'lblKeywordExplain
        '
        Me.lblKeywordExplain.ForeColor = System.Drawing.Color.Blue
        Me.lblKeywordExplain.Location = New System.Drawing.Point(15, 90)
        Me.lblKeywordExplain.Name = "lblKeywordExplain"
        Me.lblKeywordExplain.Size = New System.Drawing.Size(239, 45)
        Me.lblKeywordExplain.TabIndex = 24
        Me.lblKeywordExplain.Text = "Keyword Search will look through each items Part Number and Part Description and " & _
            "displays if they match with what is in the textbox."
        Me.lblKeywordExplain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblText
        '
        Me.lblText.Location = New System.Drawing.Point(15, 138)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(88, 20)
        Me.lblText.TabIndex = 23
        Me.lblText.Text = "Keyword Search:"
        Me.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvMainRack
        '
        Me.dgvMainRack.AutoGenerateColumns = False
        Me.dgvMainRack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMainRack.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartNumberDataGridViewTextBoxColumn, Me.PartDescriptionDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn, Me.BinNumberDataGridViewTextBoxColumn, Me.WeightDataGridViewTextBoxColumn, Me.CommentDataGridViewTextBoxColumn, Me.VendorDataGridViewTextBoxColumn, Me.DateDataGridViewTextBoxColumn})
        Me.dgvMainRack.DataSource = Me.MaintenanceRackingTableBindingSource
        Me.dgvMainRack.Location = New System.Drawing.Point(306, 3)
        Me.dgvMainRack.Name = "dgvMainRack"
        Me.dgvMainRack.Size = New System.Drawing.Size(855, 838)
        Me.dgvMainRack.TabIndex = 18
        '
        'PartNumberDataGridViewTextBoxColumn
        '
        Me.PartNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn.HeaderText = "Part Number"
        Me.PartNumberDataGridViewTextBoxColumn.Name = "PartNumberDataGridViewTextBoxColumn"
        Me.PartNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.PartNumberDataGridViewTextBoxColumn.Width = 120
        '
        'PartDescriptionDataGridViewTextBoxColumn
        '
        Me.PartDescriptionDataGridViewTextBoxColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionDataGridViewTextBoxColumn.HeaderText = "Part Description"
        Me.PartDescriptionDataGridViewTextBoxColumn.Name = "PartDescriptionDataGridViewTextBoxColumn"
        Me.PartDescriptionDataGridViewTextBoxColumn.ReadOnly = True
        Me.PartDescriptionDataGridViewTextBoxColumn.Width = 225
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "Division"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.DivisionIDDataGridViewTextBoxColumn.Width = 50
        '
        'BinNumberDataGridViewTextBoxColumn
        '
        Me.BinNumberDataGridViewTextBoxColumn.DataPropertyName = "BinNumber"
        Me.BinNumberDataGridViewTextBoxColumn.HeaderText = "Bin Number"
        Me.BinNumberDataGridViewTextBoxColumn.Name = "BinNumberDataGridViewTextBoxColumn"
        Me.BinNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.BinNumberDataGridViewTextBoxColumn.Width = 50
        '
        'WeightDataGridViewTextBoxColumn
        '
        Me.WeightDataGridViewTextBoxColumn.DataPropertyName = "Weight"
        Me.WeightDataGridViewTextBoxColumn.HeaderText = "Weight"
        Me.WeightDataGridViewTextBoxColumn.Name = "WeightDataGridViewTextBoxColumn"
        Me.WeightDataGridViewTextBoxColumn.ReadOnly = True
        Me.WeightDataGridViewTextBoxColumn.Width = 50
        '
        'CommentDataGridViewTextBoxColumn
        '
        Me.CommentDataGridViewTextBoxColumn.DataPropertyName = "Comment"
        Me.CommentDataGridViewTextBoxColumn.HeaderText = "Comment"
        Me.CommentDataGridViewTextBoxColumn.Name = "CommentDataGridViewTextBoxColumn"
        Me.CommentDataGridViewTextBoxColumn.ReadOnly = True
        Me.CommentDataGridViewTextBoxColumn.Width = 137
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
        Me.DateDataGridViewTextBoxColumn.Width = 80
        '
        'MaintenanceRackingTableBindingSource
        '
        Me.MaintenanceRackingTableBindingSource.DataMember = "MaintenanceRackingTable"
        Me.MaintenanceRackingTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MaintenanceRackingTableTableAdapter
        '
        Me.MaintenanceRackingTableTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ACHFileCounterTableTableAdapter = Nothing
        Me.TableAdapterManager.AdditionalShipToTableAdapter = Nothing
        Me.TableAdapterManager.AnnealingCoilLinesTableAdapter = Nothing
        Me.TableAdapterManager.AnnealingLogTableAdapter = Nothing
        Me.TableAdapterManager.AnnouncementLineTableTableAdapter = Nothing
        Me.TableAdapterManager.AnnouncementTableTableAdapter = Nothing
        Me.TableAdapterManager.APAgingTempDateTableAdapter = Nothing
        Me.TableAdapterManager.APCheckLinesTableAdapter = Nothing
        Me.TableAdapterManager.APCheckLogTableAdapter = Nothing
        Me.TableAdapterManager.APProcessPaymentBatchTableAdapter = Nothing
        Me.TableAdapterManager.APRecurringVouchersTableAdapter = Nothing
        Me.TableAdapterManager.APVoucherTableTableAdapter = Nothing
        Me.TableAdapterManager.ARAgingTempDateTableAdapter = Nothing
        Me.TableAdapterManager.ARCustomerPaymentTableAdapter = Nothing
        Me.TableAdapterManager.ARPaymentLinesTableAdapter = Nothing
        Me.TableAdapterManager.ARPaymentLogTableAdapter = Nothing
        Me.TableAdapterManager.ARProcessPaymentBatchTableAdapter = Nothing
        Me.TableAdapterManager.AssemblyBuildHeaderTableTableAdapter = Nothing
        Me.TableAdapterManager.AssemblyBuildLineTableTableAdapter = Nothing
        Me.TableAdapterManager.AssemblyHeaderTableTableAdapter = Nothing
        Me.TableAdapterManager.AssemblyLineTableTableAdapter = Nothing
        Me.TableAdapterManager.AssemblySerialLogTableAdapter = Nothing
        Me.TableAdapterManager.AssemblySerialTempTableTableAdapter = Nothing
        Me.TableAdapterManager.AuditTrailTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BankAccountTypesTableAdapter = Nothing
        Me.TableAdapterManager.BankReconciliationBatchHeaderTableAdapter = Nothing
        Me.TableAdapterManager.BankReconciliationLineTableTableAdapter = Nothing
        Me.TableAdapterManager.BankTransactionsBatchHeaderTableAdapter = Nothing
        Me.TableAdapterManager.BankTransactionsTableAdapter = Nothing
        Me.TableAdapterManager.BatchStatusTableAdapter = Nothing
        Me.TableAdapterManager.BinNumberBoxPrefTableAdapter = Nothing
        Me.TableAdapterManager.BinNumberTableAdapter = Nothing
        Me.TableAdapterManager.BinPrefLocationTableAdapter = Nothing
        Me.TableAdapterManager.BlueprintJournalTableAdapter = Nothing
        Me.TableAdapterManager.BoxTypeTableAdapter = Nothing
        Me.TableAdapterManager.CertErrorLogTableAdapter = Nothing
        Me.TableAdapterManager.CertificationTypeTableAdapter = Nothing
        Me.TableAdapterManager.CharterSteelCoilIdentificationTableAdapter = Nothing
        Me.TableAdapterManager.ConsignmentAdjustmentTableTableAdapter = Nothing
        Me.TableAdapterManager.ConsignmentBillingTableTableAdapter = Nothing
        Me.TableAdapterManager.ConsignmentReturnTableTableAdapter = Nothing
        Me.TableAdapterManager.ConsignmentShippingTableTableAdapter = Nothing
        Me.TableAdapterManager.ConsignmentTempTotalsTableAdapter = Nothing
        Me.TableAdapterManager.CorrectiveActionTableTableAdapter = Nothing
        Me.TableAdapterManager.CountryCodesTableAdapter = Nothing
        Me.TableAdapterManager.CurrentAnnouncementTableTableAdapter = Nothing
        Me.TableAdapterManager.CurrentInventoryValuationTableAdapter = Nothing
        Me.TableAdapterManager.CustomerClassTableAdapter = Nothing
        Me.TableAdapterManager.CustomerContactsTableAdapter = Nothing
        Me.TableAdapterManager.CustomerHoldListTableAdapter = Nothing
        Me.TableAdapterManager.CustomerListTableAdapter = Nothing
        Me.TableAdapterManager.CustomerNotesTableAdapter = Nothing
        Me.TableAdapterManager.CustomerSurveyDatesPrintedTableAdapter = Nothing
        Me.TableAdapterManager.DeleteVoucherHeaderTableTableAdapter = Nothing
        Me.TableAdapterManager.DeleteVoucherLineTableTableAdapter = Nothing
        Me.TableAdapterManager.DepartmentsTableAdapter = Nothing
        Me.TableAdapterManager.DivisionDateLinkTableTableAdapter = Nothing
        Me.TableAdapterManager.DivisionSecurityPermissionsTableAdapter = Nothing
        Me.TableAdapterManager.DivisionTableTableAdapter = Nothing
        Me.TableAdapterManager.EmployeeDataTableAdapter = Nothing
        Me.TableAdapterManager.EquipmentProductionTempTableTableAdapter = Nothing
        Me.TableAdapterManager.FerruleProductionHeaderTableTableAdapter = Nothing
        Me.TableAdapterManager.FerruleProductionLinesTableAdapter = Nothing
        Me.TableAdapterManager.FOBTableTableAdapter = Nothing
        Me.TableAdapterManager.FormLoginTableTableAdapter = Nothing
        Me.TableAdapterManager.FOXCertificationsTableAdapter = Nothing
        Me.TableAdapterManager.FOXHeaderTransactionTableAdapter = Nothing
        Me.TableAdapterManager.FOXNumbersAvailableTableAdapter = Nothing
        Me.TableAdapterManager.FOXOutsideOperationsTableAdapter = Nothing
        Me.TableAdapterManager.FOXProductionNumberHeaderTableTableAdapter = Nothing
        Me.TableAdapterManager.FOXProductionNumberSchedTableAdapter = Nothing
        Me.TableAdapterManager.FOXReleaseScheduleTableAdapter = Nothing
        Me.TableAdapterManager.FoxSchedTableAdapter = Nothing
        Me.TableAdapterManager.FOXTableTableAdapter = Nothing
        Me.TableAdapterManager.FOXTempBlanksTableTableAdapter = Nothing
        Me.TableAdapterManager.FryerPartTableTableAdapter = Nothing
        Me.TableAdapterManager.GLAccountsTableAdapter = Nothing
        Me.TableAdapterManager.GLAccountTypesTableAdapter = Nothing
        Me.TableAdapterManager.GLArchivedTotalsTableAdapter = Nothing
        Me.TableAdapterManager.GLBalanceSheetTempSelectDateTableAdapter = Nothing
        Me.TableAdapterManager.GLDivisionBeginningBalanceTableAdapter = Nothing
        Me.TableAdapterManager.GLIncomeStatementTempSelectDateTableAdapter = Nothing
        Me.TableAdapterManager.GLJournalHeaderTableTableAdapter = Nothing
        Me.TableAdapterManager.GLJournalLineTableTableAdapter = Nothing
        Me.TableAdapterManager.GLJournalsTableAdapter = Nothing
        Me.TableAdapterManager.GLJournalTemplateHeaderTableAdapter = Nothing
        Me.TableAdapterManager.GLJournalTemplateLinesTableAdapter = Nothing
        Me.TableAdapterManager.GLTempCreditBeginningTableAdapter = Nothing
        Me.TableAdapterManager.GLTempCreditEndingTableAdapter = Nothing
        Me.TableAdapterManager.GLTempCreditRangeTableAdapter = Nothing
        Me.TableAdapterManager.GLTempDebitBeginningTableAdapter = Nothing
        Me.TableAdapterManager.GLTempDebitEndingTableAdapter = Nothing
        Me.TableAdapterManager.GLTempDebitRangeTableAdapter = Nothing
        Me.TableAdapterManager.GLTempTransactionBalancesTableAdapter = Nothing
        Me.TableAdapterManager.GLTransactionMasterListArchiveTableAdapter = Nothing
        Me.TableAdapterManager.GLTransactionMasterListTableAdapter = Nothing
        Me.TableAdapterManager.HeaderProductionTableTableAdapter = Nothing
        Me.TableAdapterManager.HeaderSetupHeaderTableTableAdapter = Nothing
        Me.TableAdapterManager.HeaderSetupLineTableTableAdapter = Nothing
        Me.TableAdapterManager.HeatNumberLogTableAdapter = Nothing
        Me.TableAdapterManager.HeatTreatInspectionLogTableAdapter = Nothing
        Me.TableAdapterManager.HeatTreatRockwellTestTableAdapter = Nothing
        Me.TableAdapterManager.HeatTreatTemperatureDrawTableAdapter = Nothing
        Me.TableAdapterManager.InventoryActivityTempLogTableAdapter = Nothing
        Me.TableAdapterManager.InventoryAdjustmentBatchNumbersTableAdapter = Nothing
        Me.TableAdapterManager.InventoryAdjustmentTableTableAdapter = Nothing
        Me.TableAdapterManager.InventoryCostingTableAdapter = Nothing
        Me.TableAdapterManager.InventoryFIFOCurrentValueTableAdapter = Nothing
        Me.TableAdapterManager.InventoryFIFOValuationTableAdapter = Nothing
        Me.TableAdapterManager.InventoryFiveYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager.InventoryPriceLevelsTableAdapter = Nothing
        Me.TableAdapterManager.InventorySteelValuationTableAdapter = Nothing
        Me.TableAdapterManager.InventoryTransactionTableTableAdapter = Nothing
        Me.TableAdapterManager.InventoryValuationTempADDTableAdapter = Nothing
        Me.TableAdapterManager.InventoryValuationTempSUBTRACTTableAdapter = Nothing
        Me.TableAdapterManager.InvoiceHeaderTableTableAdapter = Nothing
        Me.TableAdapterManager.InvoiceLineTableTableAdapter = Nothing
        Me.TableAdapterManager.InvoiceLotLineTableTableAdapter = Nothing
        Me.TableAdapterManager.InvoiceProcessingBatchHeaderTableAdapter = Nothing
        Me.TableAdapterManager.InvoiceSerialLineTableTableAdapter = Nothing
        Me.TableAdapterManager.ItemClassTableAdapter = Nothing
        Me.TableAdapterManager.ItemListSalesDataTempTableAdapter = Nothing
        Me.TableAdapterManager.ItemListTableAdapter = Nothing
        Me.TableAdapterManager.ItemPriceChangeTableTableAdapter = Nothing
        Me.TableAdapterManager.ItemPriceSheetTableAdapter = Nothing
        Me.TableAdapterManager.LotNumberTableAdapter = Nothing
        Me.TableAdapterManager.MachineTableTableAdapter = Nothing
        Me.TableAdapterManager.MaintenanceRackingTableTableAdapter = Me.MaintenanceRackingTableTableAdapter
        Me.TableAdapterManager.MonthTableTableAdapter = Nothing
        Me.TableAdapterManager.MonthTotalTempTableTableAdapter = Nothing
        Me.TableAdapterManager.NonInventoryItemListTableAdapter = Nothing
        Me.TableAdapterManager.NotificationTableTableAdapter = Nothing
        Me.TableAdapterManager.PaymentTermsTableAdapter = Nothing
        Me.TableAdapterManager.PickListHeaderTableTableAdapter = Nothing
        Me.TableAdapterManager.PickListLineTableTableAdapter = Nothing
        Me.TableAdapterManager.PickListPulledLinesTableAdapter = Nothing
        Me.TableAdapterManager.POStatusTableAdapter = Nothing
        Me.TableAdapterManager.ProductionRunTableAdapter = Nothing
        Me.TableAdapterManager.PullTestDataTableAdapter = Nothing
        Me.TableAdapterManager.PullTestLineTableTableAdapter = Nothing
        Me.TableAdapterManager.PullTestLogTableAdapter = Nothing
        Me.TableAdapterManager.PurchaseOrderHeaderTableTableAdapter = Nothing
        Me.TableAdapterManager.PurchaseOrderLineTableTableAdapter = Nothing
        Me.TableAdapterManager.PurchaseProductLineTableAdapter = Nothing
        Me.TableAdapterManager.QCHoldAdjustmentLineTableTableAdapter = Nothing
        Me.TableAdapterManager.QCHoldAdjustmentLotNumberTableAdapter = Nothing
        Me.TableAdapterManager.QCHoldAdjustmentTableAdapter = Nothing
        Me.TableAdapterManager.QCInspectionFirstPieceTableTableAdapter = Nothing
        Me.TableAdapterManager.QCInspectionHeaderTableTableAdapter = Nothing
        Me.TableAdapterManager.QCInspectionLineTableTableAdapter = Nothing
        Me.TableAdapterManager.QCRackingTableTableAdapter = Nothing
        Me.TableAdapterManager.QCShipmentAuditTableAdapter = Nothing
        Me.TableAdapterManager.QuotationCostingTableAdapter = Nothing
        Me.TableAdapterManager.QuotationCostSheetTableAdapter = Nothing
        Me.TableAdapterManager.QuotationTableAdapter = Nothing
        Me.TableAdapterManager.QuoteMarkupTableAdapter = Nothing
        Me.TableAdapterManager.QuoteOperationsTableAdapter = Nothing
        Me.TableAdapterManager.QuoteOtherTableAdapter = Nothing
        Me.TableAdapterManager.QuoteSegmentsTableAdapter = Nothing
        Me.TableAdapterManager.RackingMasterListTableAdapter = Nothing
        Me.TableAdapterManager.RackingTransactionTableTableAdapter = Nothing
        Me.TableAdapterManager.RawMaterialsTableTableAdapter = Nothing
        Me.TableAdapterManager.ReceiptOfInvoiceBatchHeaderTableAdapter = Nothing
        Me.TableAdapterManager.ReceiptOfInvoiceBatchLineTableAdapter = Nothing
        Me.TableAdapterManager.ReceiptOfInvoiceVoucherLinesTableAdapter = Nothing
        Me.TableAdapterManager.ReceiptTransactionDescriptionTableAdapter = Nothing
        Me.TableAdapterManager.ReceivingHeaderTableTableAdapter = Nothing
        Me.TableAdapterManager.ReceivingLineTableTableAdapter = Nothing
        Me.TableAdapterManager.RecurringPaymentHeaderTableTableAdapter = Nothing
        Me.TableAdapterManager.RecurringPaymentLineTableTableAdapter = Nothing
        Me.TableAdapterManager.RequisitionEntryTableAdapter = Nothing
        Me.TableAdapterManager.ReturnProductHeaderTableTableAdapter = Nothing
        Me.TableAdapterManager.ReturnProductLineTableTableAdapter = Nothing
        Me.TableAdapterManager.RMATableTableAdapter = Nothing
        Me.TableAdapterManager.SafetyDataSheetsReceivedTableAdapter = Nothing
        Me.TableAdapterManager.SafetyDataSheetsTableAdapter = Nothing
        Me.TableAdapterManager.SalesOrderHeaderTableTableAdapter = Nothing
        Me.TableAdapterManager.SalesOrderLineTableTableAdapter = Nothing
        Me.TableAdapterManager.SalesOrderLotNumbersTableAdapter = Nothing
        Me.TableAdapterManager.SalesProductLineTableAdapter = Nothing
        Me.TableAdapterManager.SalesTerritoryTableAdapter = Nothing
        Me.TableAdapterManager.SaltSprayLogTableAdapter = Nothing
        Me.TableAdapterManager.ScreenShotAnalysisTableTableAdapter = Nothing
        Me.TableAdapterManager.SecurityGroupTableAdapter = Nothing
        Me.TableAdapterManager.ShipmentBOLLineTableTableAdapter = Nothing
        Me.TableAdapterManager.ShipmentBOLTableTableAdapter = Nothing
        Me.TableAdapterManager.ShipmentHeaderTableTableAdapter = Nothing
        Me.TableAdapterManager.ShipmentLineLotNumbersTableAdapter = Nothing
        Me.TableAdapterManager.ShipmentLineSerialNumbersTableAdapter = Nothing
        Me.TableAdapterManager.ShipmentLineTableTableAdapter = Nothing
        Me.TableAdapterManager.ShipmentNaftaLineTableTableAdapter = Nothing
        Me.TableAdapterManager.ShipmentNaftaTableTableAdapter = Nothing
        Me.TableAdapterManager.ShipMethodTableAdapter = Nothing
        Me.TableAdapterManager.ShippingAddressLabelsTableAdapter = Nothing
        Me.TableAdapterManager.ShippingCartonsTableAdapter = Nothing
        Me.TableAdapterManager.SOStatusTableAdapter = Nothing
        Me.TableAdapterManager.SpecialSecurityPermissionsTableAdapter = Nothing
        Me.TableAdapterManager.StandardSecurityPermissionsTableAdapter = Nothing
        Me.TableAdapterManager.StateTableTableAdapter = Nothing
        Me.TableAdapterManager.STaxCodeTableAdapter = Nothing
        Me.TableAdapterManager.SteelAdjustmentTableTableAdapter = Nothing
        Me.TableAdapterManager.SteelChangeCoilAndRMIDTableAdapter = Nothing
        Me.TableAdapterManager.SteelChemistryTolerancesTableAdapter = Nothing
        Me.TableAdapterManager.SteelCostingTableTableAdapter = Nothing
        Me.TableAdapterManager.SteelPurchaseLineTableAdapter = Nothing
        Me.TableAdapterManager.SteelPurchaseOrderHeaderTableAdapter = Nothing
        Me.TableAdapterManager.SteelReceivingCoilLinesTableAdapter = Nothing
        Me.TableAdapterManager.SteelReceivingHeaderTableTableAdapter = Nothing
        Me.TableAdapterManager.SteelReceivingLineTableTableAdapter = Nothing
        Me.TableAdapterManager.SteelReturnCoilLinesTableAdapter = Nothing
        Me.TableAdapterManager.SteelReturnHeaderTableTableAdapter = Nothing
        Me.TableAdapterManager.SteelReturnLineTableTableAdapter = Nothing
        Me.TableAdapterManager.SteelSpecialOrdersTableAdapter = Nothing
        Me.TableAdapterManager.SteelTransactionTableTableAdapter = Nothing
        Me.TableAdapterManager.SteelUsageTableTableAdapter = Nothing
        Me.TableAdapterManager.SteelValuationTableTableAdapter = Nothing
        Me.TableAdapterManager.SteelWIPTempTableTableAdapter = Nothing
        Me.TableAdapterManager.SteelYardEntryTableTableAdapter = Nothing
        Me.TableAdapterManager.StockStatusWithPricingTableAdapter = Nothing
        Me.TableAdapterManager.StudweldingCertificationTableAdapter = Nothing
        Me.TableAdapterManager.TempCoilTableTableAdapter = Nothing
        Me.TableAdapterManager.TempCustomerInactivityTableTableAdapter = Nothing
        Me.TableAdapterManager.TempWIPInventoryTagTableTableAdapter = Nothing
        Me.TableAdapterManager.TestLogTableAdapter = Nothing
        Me.TableAdapterManager.TFPComputerInformationTableAdapter = Nothing
        Me.TableAdapterManager.TFPErrorLogTableAdapter = Nothing
        Me.TableAdapterManager.TFPInventoryCoilWIPTableAdapter = Nothing
        Me.TableAdapterManager.TFPInventoryFOXProcessesTableAdapter = Nothing
        Me.TableAdapterManager.TFPInventoryTubsTableAdapter = Nothing
        Me.TableAdapterManager.TFPItemListActivityLogTableAdapter = Nothing
        Me.TableAdapterManager.TFPLotActivityLogTableAdapter = Nothing
        Me.TableAdapterManager.TFPMailAddressBookTableAdapter = Nothing
        Me.TableAdapterManager.TFPRackingActivityLogTableAdapter = Nothing
        Me.TableAdapterManager.TimeSlipHeaderTableTableAdapter = Nothing
        Me.TableAdapterManager.TimeSlipLineItemTableNewTableAdapter = Nothing
        Me.TableAdapterManager.TimeSlipLineItemTableTableAdapter = Nothing
        Me.TableAdapterManager.TimeSlipPostingRosterTableAdapter = Nothing
        Me.TableAdapterManager.ToolInventoryTableAdapter = Nothing
        Me.TableAdapterManager.ToolTypeIDTableAdapter = Nothing
        Me.TableAdapterManager.TrufitCertificationHeatLinesTableAdapter = Nothing
        Me.TableAdapterManager.TrufitCertificationHeatTreatLinesTableAdapter = Nothing
        Me.TableAdapterManager.TrufitCertificationMechanicalTestHeaderTableAdapter = Nothing
        Me.TableAdapterManager.TrufitCertificationMechanicalTestLineTableAdapter = Nothing
        Me.TableAdapterManager.TrufitCertificationMechanicalTestTableAdapter = Nothing
        Me.TableAdapterManager.TrufitCertificationMechanicalTestTolerancesTableAdapter = Nothing
        Me.TableAdapterManager.TrufitCertificationPickTicketTableAdapter = Nothing
        Me.TableAdapterManager.TrufitCertificationTableTableAdapter = Nothing
        Me.TableAdapterManager.TrufitCertificationTorqueTestHeaderTableAdapter = Nothing
        Me.TableAdapterManager.TrufitCertificationTorqueTestLineTableAdapter = Nothing
        Me.TableAdapterManager.TrufitHeatTreatLinesTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.UPSShippingDataTableAdapter = Nothing
        Me.TableAdapterManager.UserFormLoginTableAdapter = Nothing
        Me.TableAdapterManager.UserLoginTableTableAdapter = Nothing
        Me.TableAdapterManager.VendorBOLTableTableAdapter = Nothing
        Me.TableAdapterManager.VendorClassTableAdapter = Nothing
        Me.TableAdapterManager.VendorReturnLineTableAdapter = Nothing
        Me.TableAdapterManager.VendorReturnTableAdapter = Nothing
        Me.TableAdapterManager.VendorTableAdapter = Nothing
        Me.TableAdapterManager.WorkOrderHeaderTableTableAdapter = Nothing
        Me.TableAdapterManager.WorkOrderLineTableTableAdapter = Nothing
        Me.TableAdapterManager.YearlyCyclesTableAdapter = Nothing
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(109, 363)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(87, 36)
        Me.cmdClear.TabIndex = 19
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'rchNote
        '
        Me.rchNote.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.rchNote.Enabled = False
        Me.rchNote.ForeColor = System.Drawing.Color.Blue
        Me.rchNote.Location = New System.Drawing.Point(5, 405)
        Me.rchNote.Name = "rchNote"
        Me.rchNote.Size = New System.Drawing.Size(295, 45)
        Me.rchNote.TabIndex = 22
        Me.rchNote.Text = "Note: Can only update records where the bin number and part number are the same, " & _
            "otherwise, will update information inserted. Clear will repopulate the division " & _
            "ID."
        '
        'cmdViewReport
        '
        Me.cmdViewReport.Location = New System.Drawing.Point(236, 795)
        Me.cmdViewReport.Name = "cmdViewReport"
        Me.cmdViewReport.Size = New System.Drawing.Size(65, 36)
        Me.cmdViewReport.TabIndex = 24
        Me.cmdViewReport.Text = "View Racking Report"
        Me.cmdViewReport.UseVisualStyleBackColor = True
        '
        'cmdViewAll
        '
        Me.cmdViewAll.Location = New System.Drawing.Point(159, 795)
        Me.cmdViewAll.Name = "cmdViewAll"
        Me.cmdViewAll.Size = New System.Drawing.Size(65, 36)
        Me.cmdViewAll.TabIndex = 25
        Me.cmdViewAll.Text = "View All"
        Me.cmdViewAll.UseVisualStyleBackColor = True
        '
        'ViewMaintenanceRacking
        '
        Me.AcceptButton = Me.cmdAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(1162, 843)
        Me.Controls.Add(Me.cmdViewAll)
        Me.Controls.Add(Me.cmdViewReport)
        Me.Controls.Add(Me.rchNote)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.dgvMainRack)
        Me.Controls.Add(Me.grpView)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdView)
        Me.Controls.Add(Me.cmdRemove)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.grpPart)
        Me.MaximizeBox = False
        Me.Name = "ViewMaintenanceRacking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maintenance Racking"
        Me.grpPart.ResumeLayout(False)
        Me.grpPart.PerformLayout()
        Me.grpView.ResumeLayout(False)
        Me.grpView.PerformLayout()
        CType(Me.dgvMainRack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaintenanceRackingTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblRackLocation As System.Windows.Forms.Label
    Friend WithEvents txtRackLocation As System.Windows.Forms.TextBox
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents lblWeight As System.Windows.Forms.Label
    Friend WithEvents lblComment As System.Windows.Forms.Label
    Friend WithEvents rchComment As System.Windows.Forms.RichTextBox
    Friend WithEvents lblPartDesc As System.Windows.Forms.Label
    Friend WithEvents lblPartNum As System.Windows.Forms.Label
    Friend WithEvents grpPart As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdRemove As System.Windows.Forms.Button
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDivision As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndD As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblBeginD As System.Windows.Forms.Label
    Friend WithEvents lblVendor As System.Windows.Forms.Label
    Friend WithEvents grpView As System.Windows.Forms.GroupBox
    Friend WithEvents dgvMainRack As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents MaintenanceRackingTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MaintenanceRackingTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.MaintenanceRackingTableTableAdapter
    Friend WithEvents TableAdapterManager As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TableAdapterManager
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents dtpDateEntry As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents txtVendor As System.Windows.Forms.TextBox
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtPartNum As System.Windows.Forms.TextBox
    Friend WithEvents rchNote As System.Windows.Forms.RichTextBox
    Friend WithEvents lblText As System.Windows.Forms.Label
    Friend WithEvents lblKeywordExplain As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cmdViewReport As System.Windows.Forms.Button
    Friend WithEvents lblBinView As System.Windows.Forms.Label
    Friend WithEvents txtPartDescView As System.Windows.Forms.TextBox
    Friend WithEvents txtBinNumView As System.Windows.Forms.TextBox
    Friend WithEvents lblDescView As System.Windows.Forms.Label
    Friend WithEvents txtPartNumView As System.Windows.Forms.TextBox
    Friend WithEvents lblPartView As System.Windows.Forms.Label
    Friend WithEvents txtVendorView As System.Windows.Forms.TextBox
    Friend WithEvents lblVendorView As System.Windows.Forms.Label
    Friend WithEvents txtCommentView As System.Windows.Forms.RichTextBox
    Friend WithEvents lblCommentView As System.Windows.Forms.Label
    Friend WithEvents lblWeightView As System.Windows.Forms.Label
    Friend WithEvents txtWeightView As System.Windows.Forms.TextBox
    Friend WithEvents cmdViewAll As System.Windows.Forms.Button
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BinNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
