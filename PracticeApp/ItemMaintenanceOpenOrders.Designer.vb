<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemMaintenanceOpenOrders
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
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvOpenLines = New System.Windows.Forms.DataGridView
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOrderedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityShippedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenLineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalespersonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LeadTimeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderQuantityStatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.SalesOrderQuantityStatusTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderQuantityStatusTableAdapter
        Me.lblTotalPartQuantity = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvOpenLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderQuantityStatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Enabled = False
        Me.cmdPrint.Location = New System.Drawing.Point(632, 521)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 21
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(709, 521)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 22
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(792, 24)
        Me.MenuStrip1.TabIndex = 23
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
        'dgvOpenLines
        '
        Me.dgvOpenLines.AllowUserToAddRows = False
        Me.dgvOpenLines.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvOpenLines.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOpenLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOpenLines.AutoGenerateColumns = False
        Me.dgvOpenLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvOpenLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvOpenLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOpenLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerIDColumn, Me.SalesOrderKeyColumn, Me.SalesOrderDateColumn, Me.QuantityOrderedColumn, Me.QuantityShippedColumn, Me.QuantityOpenColumn, Me.PriceColumn, Me.OpenLineWeightColumn, Me.CustomerPOColumn, Me.SalespersonColumn, Me.LeadTimeColumn, Me.LineCommentColumn, Me.SalesOrderLineKeyColumn, Me.DivisionKeyColumn, Me.LineStatusColumn, Me.ItemIDColumn})
        Me.dgvOpenLines.DataSource = Me.SalesOrderQuantityStatusBindingSource
        Me.dgvOpenLines.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvOpenLines.Location = New System.Drawing.Point(12, 41)
        Me.dgvOpenLines.Name = "dgvOpenLines"
        Me.dgvOpenLines.ReadOnly = True
        Me.dgvOpenLines.Size = New System.Drawing.Size(768, 472)
        Me.dgvOpenLines.TabIndex = 24
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'SalesOrderKeyColumn
        '
        Me.SalesOrderKeyColumn.DataPropertyName = "SalesOrderKey"
        Me.SalesOrderKeyColumn.HeaderText = "SO #"
        Me.SalesOrderKeyColumn.Name = "SalesOrderKeyColumn"
        Me.SalesOrderKeyColumn.ReadOnly = True
        Me.SalesOrderKeyColumn.Width = 80
        '
        'SalesOrderDateColumn
        '
        Me.SalesOrderDateColumn.DataPropertyName = "SalesOrderDate"
        Me.SalesOrderDateColumn.HeaderText = "Order Date"
        Me.SalesOrderDateColumn.Name = "SalesOrderDateColumn"
        Me.SalesOrderDateColumn.ReadOnly = True
        Me.SalesOrderDateColumn.Width = 80
        '
        'QuantityOrderedColumn
        '
        Me.QuantityOrderedColumn.DataPropertyName = "QuantityOrdered"
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        Me.QuantityOrderedColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.QuantityOrderedColumn.HeaderText = "Qty. Ordered"
        Me.QuantityOrderedColumn.Name = "QuantityOrderedColumn"
        Me.QuantityOrderedColumn.ReadOnly = True
        Me.QuantityOrderedColumn.Width = 80
        '
        'QuantityShippedColumn
        '
        Me.QuantityShippedColumn.DataPropertyName = "QuantityShipped"
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.QuantityShippedColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.QuantityShippedColumn.HeaderText = "Qty. Shipped"
        Me.QuantityShippedColumn.Name = "QuantityShippedColumn"
        Me.QuantityShippedColumn.ReadOnly = True
        Me.QuantityShippedColumn.Width = 80
        '
        'QuantityOpenColumn
        '
        Me.QuantityOpenColumn.DataPropertyName = "QuantityOpen"
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = "0"
        Me.QuantityOpenColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.QuantityOpenColumn.HeaderText = "Qty. Open"
        Me.QuantityOpenColumn.Name = "QuantityOpenColumn"
        Me.QuantityOpenColumn.ReadOnly = True
        Me.QuantityOpenColumn.Width = 80
        '
        'PriceColumn
        '
        Me.PriceColumn.DataPropertyName = "Price"
        DataGridViewCellStyle5.Format = "N5"
        DataGridViewCellStyle5.NullValue = "0"
        Me.PriceColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.PriceColumn.HeaderText = "Price"
        Me.PriceColumn.Name = "PriceColumn"
        Me.PriceColumn.ReadOnly = True
        Me.PriceColumn.Width = 80
        '
        'OpenLineWeightColumn
        '
        Me.OpenLineWeightColumn.DataPropertyName = "OpenLineWeight"
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = "0"
        Me.OpenLineWeightColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.OpenLineWeightColumn.HeaderText = "Open Weight"
        Me.OpenLineWeightColumn.Name = "OpenLineWeightColumn"
        Me.OpenLineWeightColumn.ReadOnly = True
        Me.OpenLineWeightColumn.Width = 80
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.HeaderText = "Cust. PO"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        Me.CustomerPOColumn.ReadOnly = True
        Me.CustomerPOColumn.Width = 80
        '
        'SalespersonColumn
        '
        Me.SalespersonColumn.DataPropertyName = "Salesperson"
        Me.SalespersonColumn.HeaderText = "Salesperson"
        Me.SalespersonColumn.Name = "SalespersonColumn"
        Me.SalespersonColumn.ReadOnly = True
        '
        'LeadTimeColumn
        '
        Me.LeadTimeColumn.DataPropertyName = "LeadTime"
        Me.LeadTimeColumn.HeaderText = "Lead Time"
        Me.LeadTimeColumn.Name = "LeadTimeColumn"
        Me.LeadTimeColumn.ReadOnly = True
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        Me.LineCommentColumn.ReadOnly = True
        '
        'SalesOrderLineKeyColumn
        '
        Me.SalesOrderLineKeyColumn.DataPropertyName = "SalesOrderLineKey"
        Me.SalesOrderLineKeyColumn.HeaderText = "SalesOrderLineKey"
        Me.SalesOrderLineKeyColumn.Name = "SalesOrderLineKeyColumn"
        Me.SalesOrderLineKeyColumn.ReadOnly = True
        Me.SalesOrderLineKeyColumn.Visible = False
        '
        'DivisionKeyColumn
        '
        Me.DivisionKeyColumn.DataPropertyName = "DivisionKey"
        Me.DivisionKeyColumn.HeaderText = "DivisionKey"
        Me.DivisionKeyColumn.Name = "DivisionKeyColumn"
        Me.DivisionKeyColumn.ReadOnly = True
        Me.DivisionKeyColumn.Visible = False
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "LineStatus"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.ReadOnly = True
        Me.LineStatusColumn.Visible = False
        '
        'ItemIDColumn
        '
        Me.ItemIDColumn.DataPropertyName = "ItemID"
        Me.ItemIDColumn.HeaderText = "ItemID"
        Me.ItemIDColumn.Name = "ItemIDColumn"
        Me.ItemIDColumn.ReadOnly = True
        Me.ItemIDColumn.Visible = False
        '
        'SalesOrderQuantityStatusBindingSource
        '
        Me.SalesOrderQuantityStatusBindingSource.DataMember = "SalesOrderQuantityStatus"
        Me.SalesOrderQuantityStatusBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SalesOrderQuantityStatusTableAdapter
        '
        Me.SalesOrderQuantityStatusTableAdapter.ClearBeforeFill = True
        '
        'lblTotalPartQuantity
        '
        Me.lblTotalPartQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalPartQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPartQuantity.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalPartQuantity.Location = New System.Drawing.Point(12, 526)
        Me.lblTotalPartQuantity.Name = "lblTotalPartQuantity"
        Me.lblTotalPartQuantity.Size = New System.Drawing.Size(569, 31)
        Me.lblTotalPartQuantity.TabIndex = 25
        Me.lblTotalPartQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ItemMaintenanceOpenOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.lblTotalPartQuantity)
        Me.Controls.Add(Me.dgvOpenLines)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ItemMaintenanceOpenOrders"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Open Orders"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvOpenLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderQuantityStatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvOpenLines As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents SalesOrderQuantityStatusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderQuantityStatusTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderQuantityStatusTableAdapter
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOrderedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityShippedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenLineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalespersonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeadTimeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblTotalPartQuantity As System.Windows.Forms.Label
End Class
