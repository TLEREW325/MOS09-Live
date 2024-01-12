<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewAllRMA
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportToReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdExit = New System.Windows.Forms.Button
        Me.grpCustomerInfo = New System.Windows.Forms.GroupBox
        Me.chkAll = New System.Windows.Forms.CheckBox
        Me.cmdView = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label3 = New System.Windows.Forms.Label
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvCustomerOrders = New System.Windows.Forms.DataGridView
        Me.AuthorizationNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReasonDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RemarksDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AuthorizedTruckingFirmDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TypeFixDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerContactDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NeedPartsByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QARepresentativeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QARepDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMATableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
        Me.RMATableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RMATableTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.grpCustomerInfo.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCustomerOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RMATableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToReportToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'ExportToReportToolStripMenuItem
        '
        Me.ExportToReportToolStripMenuItem.Name = "ExportToReportToolStripMenuItem"
        Me.ExportToReportToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ExportToReportToolStripMenuItem.Text = "Export To Report"
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
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(218, 68)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 30)
        Me.cmdExit.TabIndex = 16
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'grpCustomerInfo
        '
        Me.grpCustomerInfo.Controls.Add(Me.chkAll)
        Me.grpCustomerInfo.Controls.Add(Me.cmdView)
        Me.grpCustomerInfo.Controls.Add(Me.cboDivisionID)
        Me.grpCustomerInfo.Controls.Add(Me.cmdExit)
        Me.grpCustomerInfo.Controls.Add(Me.Label3)
        Me.grpCustomerInfo.Location = New System.Drawing.Point(12, 41)
        Me.grpCustomerInfo.Name = "grpCustomerInfo"
        Me.grpCustomerInfo.Size = New System.Drawing.Size(300, 116)
        Me.grpCustomerInfo.TabIndex = 0
        Me.grpCustomerInfo.TabStop = False
        Me.grpCustomerInfo.Text = "View By Filters"
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(19, 76)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(63, 17)
        Me.chkAll.TabIndex = 33
        Me.chkAll.Text = "View All"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(110, 68)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 12
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(90, 27)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(199, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 20)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Division ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EmployeeDataBindingSource
        '
        Me.EmployeeDataBindingSource.DataMember = "EmployeeData"
        Me.EmployeeDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvCustomerOrders
        '
        Me.dgvCustomerOrders.AllowUserToAddRows = False
        Me.dgvCustomerOrders.AllowUserToDeleteRows = False
        Me.dgvCustomerOrders.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCustomerOrders.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCustomerOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCustomerOrders.AutoGenerateColumns = False
        Me.dgvCustomerOrders.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvCustomerOrders.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCustomerOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCustomerOrders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AuthorizationNumberDataGridViewTextBoxColumn, Me.CustomerDataGridViewTextBoxColumn, Me.DateDataGridViewTextBoxColumn, Me.FOXNumberDataGridViewTextBoxColumn, Me.QuantityDataGridViewTextBoxColumn, Me.ReasonDataGridViewTextBoxColumn, Me.RemarksDataGridViewTextBoxColumn, Me.AuthorizedTruckingFirmDataGridViewTextBoxColumn, Me.PurchaseOrderNumberDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn, Me.TypeFixDataGridViewTextBoxColumn, Me.CustomerContactDataGridViewTextBoxColumn, Me.NeedPartsByDataGridViewTextBoxColumn, Me.QARepresentativeDataGridViewTextBoxColumn, Me.QARepDateDataGridViewTextBoxColumn})
        Me.dgvCustomerOrders.DataSource = Me.RMATableBindingSource
        Me.dgvCustomerOrders.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvCustomerOrders.Location = New System.Drawing.Point(318, 41)
        Me.dgvCustomerOrders.Name = "dgvCustomerOrders"
        Me.dgvCustomerOrders.ReadOnly = True
        Me.dgvCustomerOrders.Size = New System.Drawing.Size(812, 770)
        Me.dgvCustomerOrders.TabIndex = 17
        Me.dgvCustomerOrders.TabStop = False
        '
        'AuthorizationNumberDataGridViewTextBoxColumn
        '
        Me.AuthorizationNumberDataGridViewTextBoxColumn.DataPropertyName = "AuthorizationNumber"
        Me.AuthorizationNumberDataGridViewTextBoxColumn.HeaderText = "Authorization Number"
        Me.AuthorizationNumberDataGridViewTextBoxColumn.Name = "AuthorizationNumberDataGridViewTextBoxColumn"
        Me.AuthorizationNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CustomerDataGridViewTextBoxColumn
        '
        Me.CustomerDataGridViewTextBoxColumn.DataPropertyName = "Customer"
        Me.CustomerDataGridViewTextBoxColumn.HeaderText = "Customer"
        Me.CustomerDataGridViewTextBoxColumn.Name = "CustomerDataGridViewTextBoxColumn"
        Me.CustomerDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DateDataGridViewTextBoxColumn
        '
        Me.DateDataGridViewTextBoxColumn.DataPropertyName = "Date"
        Me.DateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateDataGridViewTextBoxColumn.Name = "DateDataGridViewTextBoxColumn"
        Me.DateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FOXNumberDataGridViewTextBoxColumn
        '
        Me.FOXNumberDataGridViewTextBoxColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberDataGridViewTextBoxColumn.HeaderText = "FOX Number"
        Me.FOXNumberDataGridViewTextBoxColumn.Name = "FOXNumberDataGridViewTextBoxColumn"
        Me.FOXNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'QuantityDataGridViewTextBoxColumn
        '
        Me.QuantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity"
        Me.QuantityDataGridViewTextBoxColumn.HeaderText = "Quantity"
        Me.QuantityDataGridViewTextBoxColumn.Name = "QuantityDataGridViewTextBoxColumn"
        Me.QuantityDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ReasonDataGridViewTextBoxColumn
        '
        Me.ReasonDataGridViewTextBoxColumn.DataPropertyName = "Reason"
        Me.ReasonDataGridViewTextBoxColumn.HeaderText = "Reason"
        Me.ReasonDataGridViewTextBoxColumn.Name = "ReasonDataGridViewTextBoxColumn"
        Me.ReasonDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RemarksDataGridViewTextBoxColumn
        '
        Me.RemarksDataGridViewTextBoxColumn.DataPropertyName = "Remarks"
        Me.RemarksDataGridViewTextBoxColumn.HeaderText = "Remarks"
        Me.RemarksDataGridViewTextBoxColumn.Name = "RemarksDataGridViewTextBoxColumn"
        Me.RemarksDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AuthorizedTruckingFirmDataGridViewTextBoxColumn
        '
        Me.AuthorizedTruckingFirmDataGridViewTextBoxColumn.DataPropertyName = "AuthorizedTruckingFirm"
        Me.AuthorizedTruckingFirmDataGridViewTextBoxColumn.HeaderText = "Authorized Trucking Firm"
        Me.AuthorizedTruckingFirmDataGridViewTextBoxColumn.Name = "AuthorizedTruckingFirmDataGridViewTextBoxColumn"
        Me.AuthorizedTruckingFirmDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PurchaseOrderNumberDataGridViewTextBoxColumn
        '
        Me.PurchaseOrderNumberDataGridViewTextBoxColumn.DataPropertyName = "PurchaseOrderNumber"
        Me.PurchaseOrderNumberDataGridViewTextBoxColumn.HeaderText = "Purchase Order Number"
        Me.PurchaseOrderNumberDataGridViewTextBoxColumn.Name = "PurchaseOrderNumberDataGridViewTextBoxColumn"
        Me.PurchaseOrderNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "Division ID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TypeFixDataGridViewTextBoxColumn
        '
        Me.TypeFixDataGridViewTextBoxColumn.DataPropertyName = "TypeFix"
        Me.TypeFixDataGridViewTextBoxColumn.HeaderText = "Type Fix"
        Me.TypeFixDataGridViewTextBoxColumn.Name = "TypeFixDataGridViewTextBoxColumn"
        Me.TypeFixDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CustomerContactDataGridViewTextBoxColumn
        '
        Me.CustomerContactDataGridViewTextBoxColumn.DataPropertyName = "CustomerContact"
        Me.CustomerContactDataGridViewTextBoxColumn.HeaderText = "Customer Contact"
        Me.CustomerContactDataGridViewTextBoxColumn.Name = "CustomerContactDataGridViewTextBoxColumn"
        Me.CustomerContactDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NeedPartsByDataGridViewTextBoxColumn
        '
        Me.NeedPartsByDataGridViewTextBoxColumn.DataPropertyName = "NeedPartsBy"
        Me.NeedPartsByDataGridViewTextBoxColumn.HeaderText = "Need Parts By"
        Me.NeedPartsByDataGridViewTextBoxColumn.Name = "NeedPartsByDataGridViewTextBoxColumn"
        Me.NeedPartsByDataGridViewTextBoxColumn.ReadOnly = True
        '
        'QARepresentativeDataGridViewTextBoxColumn
        '
        Me.QARepresentativeDataGridViewTextBoxColumn.DataPropertyName = "QARepresentative"
        Me.QARepresentativeDataGridViewTextBoxColumn.HeaderText = "QA Representative"
        Me.QARepresentativeDataGridViewTextBoxColumn.Name = "QARepresentativeDataGridViewTextBoxColumn"
        Me.QARepresentativeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'QARepDateDataGridViewTextBoxColumn
        '
        Me.QARepDateDataGridViewTextBoxColumn.DataPropertyName = "QARepDate"
        Me.QARepDateDataGridViewTextBoxColumn.HeaderText = "QA Rep Date"
        Me.QARepDateDataGridViewTextBoxColumn.Name = "QARepDateDataGridViewTextBoxColumn"
        Me.QARepDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RMATableBindingSource
        '
        Me.RMATableBindingSource.DataMember = "RMATable"
        Me.RMATableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'EmployeeDataTableAdapter
        '
        Me.EmployeeDataTableAdapter.ClearBeforeFill = True
        '
        'RMATableTableAdapter
        '
        Me.RMATableTableAdapter.ClearBeforeFill = True
        '
        'ViewAllRMA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.dgvCustomerOrders)
        Me.Controls.Add(Me.grpCustomerInfo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewAllRMA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View RMA Reports"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.grpCustomerInfo.ResumeLayout(False)
        Me.grpCustomerInfo.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCustomerOrders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RMATableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents grpCustomerInfo As System.Windows.Forms.GroupBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvCustomerOrders As System.Windows.Forms.DataGridView
    Friend WithEvents PiecesManufacturedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents TotalQuantityShippedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents RMATableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RMATableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RMATableTableAdapter
    Friend WithEvents AuthorizationNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReasonDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemarksDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AuthorizedTruckingFirmDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseOrderNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypeFixDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerContactDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NeedPartsByDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QARepresentativeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QARepDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExportToReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
