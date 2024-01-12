<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewOpenPurchaseLines
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.dgvOpenPOLines = New System.Windows.Forms.DataGridView
        Me.POTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PODateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POQuantityOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DropShipSalesOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectForInvoiceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POQuantityReceivedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrderQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PODropShipCustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderQuantityStatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PurchaseOrderQuantityStatusTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderQuantityStatusTableAdapter
        Me.cmdPOForm = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOpenPOLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderQuantityStatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'cboDivisionID
        '
        Me.cboDivisionID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(90, 790)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(160, 21)
        Me.cboDivisionID.TabIndex = 1
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
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(23, 791)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 20)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(981, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 3
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'dgvOpenPOLines
        '
        Me.dgvOpenPOLines.AllowUserToAddRows = False
        Me.dgvOpenPOLines.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvOpenPOLines.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOpenPOLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOpenPOLines.AutoGenerateColumns = False
        Me.dgvOpenPOLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvOpenPOLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvOpenPOLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOpenPOLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.POTypeColumn, Me.PurchaseOrderHeaderKeyColumn, Me.PODateColumn, Me.VendorIDColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.POQuantityOpenColumn, Me.UnitCostColumn, Me.OpenAmountColumn, Me.DropShipSalesOrderNumberColumn, Me.ShipDateColumn, Me.LineCommentColumn, Me.LineStatusColumn, Me.SelectForInvoiceColumn, Me.CreditGLAccountColumn, Me.DebitGLAccountColumn, Me.PurchaseOrderLineNumberColumn, Me.POQuantityReceivedColumn, Me.OrderQuantityColumn, Me.ExtendedAmountColumn, Me.ReceivedAmountColumn, Me.DivisionIDColumn, Me.PODropShipCustomerIDColumn, Me.StatusColumn})
        Me.dgvOpenPOLines.DataSource = Me.PurchaseOrderQuantityStatusBindingSource
        Me.dgvOpenPOLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvOpenPOLines.Location = New System.Drawing.Point(12, 40)
        Me.dgvOpenPOLines.Name = "dgvOpenPOLines"
        Me.dgvOpenPOLines.Size = New System.Drawing.Size(1118, 725)
        Me.dgvOpenPOLines.TabIndex = 21
        Me.dgvOpenPOLines.TabStop = False
        '
        'POTypeColumn
        '
        Me.POTypeColumn.HeaderText = "Type"
        Me.POTypeColumn.Name = "POTypeColumn"
        Me.POTypeColumn.Width = 80
        '
        'PurchaseOrderHeaderKeyColumn
        '
        Me.PurchaseOrderHeaderKeyColumn.DataPropertyName = "PurchaseOrderHeaderKey"
        Me.PurchaseOrderHeaderKeyColumn.HeaderText = "PO #"
        Me.PurchaseOrderHeaderKeyColumn.Name = "PurchaseOrderHeaderKeyColumn"
        Me.PurchaseOrderHeaderKeyColumn.Width = 85
        '
        'PODateColumn
        '
        Me.PODateColumn.DataPropertyName = "PODate"
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.PODateColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.PODateColumn.HeaderText = "PO Date"
        Me.PODateColumn.Name = "PODateColumn"
        Me.PODateColumn.Width = 85
        '
        'VendorIDColumn
        '
        Me.VendorIDColumn.DataPropertyName = "VendorID"
        Me.VendorIDColumn.HeaderText = "Vendor ID"
        Me.VendorIDColumn.Name = "VendorIDColumn"
        Me.VendorIDColumn.Width = 120
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.Width = 150
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.Width = 150
        '
        'POQuantityOpenColumn
        '
        Me.POQuantityOpenColumn.DataPropertyName = "POQuantityOpen"
        DataGridViewCellStyle3.NullValue = "0"
        Me.POQuantityOpenColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.POQuantityOpenColumn.HeaderText = "Open Qty"
        Me.POQuantityOpenColumn.Name = "POQuantityOpenColumn"
        Me.POQuantityOpenColumn.ReadOnly = True
        Me.POQuantityOpenColumn.Width = 85
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle4.Format = "N4"
        DataGridViewCellStyle4.NullValue = "0"
        Me.UnitCostColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.Width = 85
        '
        'OpenAmountColumn
        '
        Me.OpenAmountColumn.DataPropertyName = "OpenAmount"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.OpenAmountColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.OpenAmountColumn.HeaderText = "Amount"
        Me.OpenAmountColumn.Name = "OpenAmountColumn"
        Me.OpenAmountColumn.ReadOnly = True
        Me.OpenAmountColumn.Width = 85
        '
        'DropShipSalesOrderNumberColumn
        '
        Me.DropShipSalesOrderNumberColumn.DataPropertyName = "DropShipSalesOrderNumber"
        Me.DropShipSalesOrderNumberColumn.HeaderText = "SO #"
        Me.DropShipSalesOrderNumberColumn.Name = "DropShipSalesOrderNumberColumn"
        '
        'ShipDateColumn
        '
        Me.ShipDateColumn.DataPropertyName = "ShipDate"
        DataGridViewCellStyle6.Format = "d"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.ShipDateColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.ShipDateColumn.HeaderText = "Exp. Ship Date"
        Me.ShipDateColumn.Name = "ShipDateColumn"
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        Me.LineCommentColumn.Width = 120
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "LineStatus"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.Visible = False
        '
        'SelectForInvoiceColumn
        '
        Me.SelectForInvoiceColumn.DataPropertyName = "SelectForInvoice"
        Me.SelectForInvoiceColumn.HeaderText = "SelectForInvoice"
        Me.SelectForInvoiceColumn.Name = "SelectForInvoiceColumn"
        Me.SelectForInvoiceColumn.Visible = False
        '
        'CreditGLAccountColumn
        '
        Me.CreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumn.HeaderText = "CreditGLAccount"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
        Me.CreditGLAccountColumn.Visible = False
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "DebitGLAccount"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        Me.DebitGLAccountColumn.Visible = False
        '
        'PurchaseOrderLineNumberColumn
        '
        Me.PurchaseOrderLineNumberColumn.DataPropertyName = "PurchaseOrderLineNumber"
        Me.PurchaseOrderLineNumberColumn.HeaderText = "PurchaseOrderLineNumber"
        Me.PurchaseOrderLineNumberColumn.Name = "PurchaseOrderLineNumberColumn"
        Me.PurchaseOrderLineNumberColumn.Visible = False
        '
        'POQuantityReceivedColumn
        '
        Me.POQuantityReceivedColumn.DataPropertyName = "POQuantityReceived"
        Me.POQuantityReceivedColumn.HeaderText = "POQuantityReceived"
        Me.POQuantityReceivedColumn.Name = "POQuantityReceivedColumn"
        Me.POQuantityReceivedColumn.ReadOnly = True
        Me.POQuantityReceivedColumn.Visible = False
        '
        'OrderQuantityColumn
        '
        Me.OrderQuantityColumn.DataPropertyName = "OrderQuantity"
        Me.OrderQuantityColumn.HeaderText = "OrderQuantity"
        Me.OrderQuantityColumn.Name = "OrderQuantityColumn"
        Me.OrderQuantityColumn.Visible = False
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        Me.ExtendedAmountColumn.HeaderText = "ExtendedAmount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.Visible = False
        '
        'ReceivedAmountColumn
        '
        Me.ReceivedAmountColumn.DataPropertyName = "ReceivedAmount"
        Me.ReceivedAmountColumn.HeaderText = "ReceivedAmount"
        Me.ReceivedAmountColumn.Name = "ReceivedAmountColumn"
        Me.ReceivedAmountColumn.ReadOnly = True
        Me.ReceivedAmountColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'PODropShipCustomerIDColumn
        '
        Me.PODropShipCustomerIDColumn.DataPropertyName = "PODropShipCustomerID"
        Me.PODropShipCustomerIDColumn.HeaderText = "PODropShipCustomerID"
        Me.PODropShipCustomerIDColumn.Name = "PODropShipCustomerIDColumn"
        Me.PODropShipCustomerIDColumn.Visible = False
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.Visible = False
        '
        'PurchaseOrderQuantityStatusBindingSource
        '
        Me.PurchaseOrderQuantityStatusBindingSource.DataMember = "PurchaseOrderQuantityStatus"
        Me.PurchaseOrderQuantityStatusBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'PurchaseOrderQuantityStatusTableAdapter
        '
        Me.PurchaseOrderQuantityStatusTableAdapter.ClearBeforeFill = True
        '
        'cmdPOForm
        '
        Me.cmdPOForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPOForm.Location = New System.Drawing.Point(827, 771)
        Me.cmdPOForm.Name = "cmdPOForm"
        Me.cmdPOForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdPOForm.TabIndex = 2
        Me.cmdPOForm.Text = "Open PO Form"
        Me.cmdPOForm.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRefresh.Location = New System.Drawing.Point(904, 771)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(71, 40)
        Me.cmdRefresh.TabIndex = 22
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'ViewOpenPurchaseLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.cmdPOForm)
        Me.Controls.Add(Me.dgvOpenPOLines)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cboDivisionID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewOpenPurchaseLines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Open Purchase Lines"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOpenPOLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderQuantityStatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents dgvOpenPOLines As System.Windows.Forms.DataGridView
    Friend WithEvents PurchaseOrderQuantityStatusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderQuantityStatusTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderQuantityStatusTableAdapter
    Friend WithEvents ReceivingDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPOForm As System.Windows.Forms.Button
    Friend WithEvents POTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseOrderHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POQuantityOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DropShipSalesOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForInvoiceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseOrderLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POQuantityReceivedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODropShipCustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
End Class
