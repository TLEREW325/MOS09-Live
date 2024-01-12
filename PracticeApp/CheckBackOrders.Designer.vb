<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckBackOrders
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.chkIncludeCustomer = New System.Windows.Forms.CheckBox
        Me.chkExcludeCustomer = New System.Windows.Forms.CheckBox
        Me.txtCustomer = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkIncludeShipVia = New System.Windows.Forms.CheckBox
        Me.chkExcludeShipVia = New System.Windows.Forms.CheckBox
        Me.txtShipVia = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cmdViewOpenOrders = New System.Windows.Forms.Button
        Me.dgvOpenPicksWithQOH = New System.Windows.Forms.DataGridView
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvViewOpenPicks = New System.Windows.Forms.DataGridView
        Me.PickListHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OriginalPickDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipViaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingMethodColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SpecialInstructionsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PLStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PickListHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PickListHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListHeaderTableTableAdapter
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdCheckForCompletedBackorders = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.PickTicketNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SONumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Customer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipVia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Comment = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOpenPicksWithQOH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvViewOpenPicks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PickListHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.chkIncludeCustomer)
        Me.GroupBox1.Controls.Add(Me.chkExcludeCustomer)
        Me.GroupBox1.Controls.Add(Me.txtCustomer)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chkIncludeShipVia)
        Me.GroupBox1.Controls.Add(Me.chkExcludeShipVia)
        Me.GroupBox1.Controls.Add(Me.txtShipVia)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.cmdViewOpenOrders)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 489)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter Datagrid"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(265, 23)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Text Filters"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkIncludeCustomer
        '
        Me.chkIncludeCustomer.AutoSize = True
        Me.chkIncludeCustomer.Location = New System.Drawing.Point(114, 309)
        Me.chkIncludeCustomer.Name = "chkIncludeCustomer"
        Me.chkIncludeCustomer.Size = New System.Drawing.Size(91, 17)
        Me.chkIncludeCustomer.TabIndex = 7
        Me.chkIncludeCustomer.Text = "Include (Only)"
        Me.chkIncludeCustomer.UseVisualStyleBackColor = True
        '
        'chkExcludeCustomer
        '
        Me.chkExcludeCustomer.AutoSize = True
        Me.chkExcludeCustomer.Location = New System.Drawing.Point(114, 277)
        Me.chkExcludeCustomer.Name = "chkExcludeCustomer"
        Me.chkExcludeCustomer.Size = New System.Drawing.Size(64, 17)
        Me.chkExcludeCustomer.TabIndex = 6
        Me.chkExcludeCustomer.Text = "Exclude"
        Me.chkExcludeCustomer.UseVisualStyleBackColor = True
        '
        'txtCustomer
        '
        Me.txtCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomer.Location = New System.Drawing.Point(114, 238)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(171, 20)
        Me.txtCustomer.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 238)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 23)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Customer"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkIncludeShipVia
        '
        Me.chkIncludeShipVia.AutoSize = True
        Me.chkIncludeShipVia.Location = New System.Drawing.Point(114, 193)
        Me.chkIncludeShipVia.Name = "chkIncludeShipVia"
        Me.chkIncludeShipVia.Size = New System.Drawing.Size(91, 17)
        Me.chkIncludeShipVia.TabIndex = 4
        Me.chkIncludeShipVia.Text = "Include (Only)"
        Me.chkIncludeShipVia.UseVisualStyleBackColor = True
        '
        'chkExcludeShipVia
        '
        Me.chkExcludeShipVia.AutoSize = True
        Me.chkExcludeShipVia.Location = New System.Drawing.Point(114, 161)
        Me.chkExcludeShipVia.Name = "chkExcludeShipVia"
        Me.chkExcludeShipVia.Size = New System.Drawing.Size(64, 17)
        Me.chkExcludeShipVia.TabIndex = 3
        Me.chkExcludeShipVia.Text = "Exclude"
        Me.chkExcludeShipVia.UseVisualStyleBackColor = True
        '
        'txtShipVia
        '
        Me.txtShipVia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipVia.Location = New System.Drawing.Point(114, 122)
        Me.txtShipVia.Name = "txtShipVia"
        Me.txtShipVia.Size = New System.Drawing.Size(171, 20)
        Me.txtShipVia.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 23)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Ship Via"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 23)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Division"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(114, 34)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(171, 21)
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
        'cmdViewOpenOrders
        '
        Me.cmdViewOpenOrders.Location = New System.Drawing.Point(214, 433)
        Me.cmdViewOpenOrders.Name = "cmdViewOpenOrders"
        Me.cmdViewOpenOrders.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewOpenOrders.TabIndex = 8
        Me.cmdViewOpenOrders.Text = "View"
        Me.cmdViewOpenOrders.UseVisualStyleBackColor = True
        '
        'dgvOpenPicksWithQOH
        '
        Me.dgvOpenPicksWithQOH.AllowUserToAddRows = False
        Me.dgvOpenPicksWithQOH.AllowUserToDeleteRows = False
        Me.dgvOpenPicksWithQOH.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOpenPicksWithQOH.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvOpenPicksWithQOH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOpenPicksWithQOH.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PickTicketNumber, Me.SONumber, Me.Customer, Me.ShipVia, Me.Comment, Me.DateColumn})
        Me.dgvOpenPicksWithQOH.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvOpenPicksWithQOH.Location = New System.Drawing.Point(345, 41)
        Me.dgvOpenPicksWithQOH.Name = "dgvOpenPicksWithQOH"
        Me.dgvOpenPicksWithQOH.Size = New System.Drawing.Size(785, 700)
        Me.dgvOpenPicksWithQOH.TabIndex = 2
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 3
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvViewOpenPicks
        '
        Me.dgvViewOpenPicks.AllowUserToAddRows = False
        Me.dgvViewOpenPicks.AllowUserToDeleteRows = False
        Me.dgvViewOpenPicks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvViewOpenPicks.AutoGenerateColumns = False
        Me.dgvViewOpenPicks.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvViewOpenPicks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvViewOpenPicks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PickListHeaderKeyColumn, Me.SalesOrderHeaderKeyColumn, Me.CustomerIDColumn, Me.OriginalPickDateColumn, Me.ShipViaColumn, Me.ShippingMethodColumn, Me.SpecialInstructionsColumn, Me.CommentColumn, Me.PLStatusColumn, Me.DivisionIDColumn})
        Me.dgvViewOpenPicks.DataSource = Me.PickListHeaderTableBindingSource
        Me.dgvViewOpenPicks.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvViewOpenPicks.Location = New System.Drawing.Point(345, 41)
        Me.dgvViewOpenPicks.Name = "dgvViewOpenPicks"
        Me.dgvViewOpenPicks.Size = New System.Drawing.Size(785, 700)
        Me.dgvViewOpenPicks.TabIndex = 4
        '
        'PickListHeaderKeyColumn
        '
        Me.PickListHeaderKeyColumn.DataPropertyName = "PickListHeaderKey"
        Me.PickListHeaderKeyColumn.HeaderText = "Pick Ticket #"
        Me.PickListHeaderKeyColumn.Name = "PickListHeaderKeyColumn"
        '
        'SalesOrderHeaderKeyColumn
        '
        Me.SalesOrderHeaderKeyColumn.DataPropertyName = "SalesOrderHeaderKey"
        Me.SalesOrderHeaderKeyColumn.HeaderText = "SO #"
        Me.SalesOrderHeaderKeyColumn.Name = "SalesOrderHeaderKeyColumn"
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        '
        'OriginalPickDateColumn
        '
        Me.OriginalPickDateColumn.DataPropertyName = "PickDate"
        Me.OriginalPickDateColumn.HeaderText = "Pick Date"
        Me.OriginalPickDateColumn.Name = "OriginalPickDateColumn"
        '
        'ShipViaColumn
        '
        Me.ShipViaColumn.DataPropertyName = "ShipVia"
        Me.ShipViaColumn.HeaderText = "Ship Via"
        Me.ShipViaColumn.Name = "ShipViaColumn"
        '
        'ShippingMethodColumn
        '
        Me.ShippingMethodColumn.DataPropertyName = "ShippingMethod"
        Me.ShippingMethodColumn.HeaderText = "Method"
        Me.ShippingMethodColumn.Name = "ShippingMethodColumn"
        '
        'SpecialInstructionsColumn
        '
        Me.SpecialInstructionsColumn.DataPropertyName = "SpecialInstructions"
        Me.SpecialInstructionsColumn.HeaderText = "Special Instructions"
        Me.SpecialInstructionsColumn.Name = "SpecialInstructionsColumn"
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'PLStatusColumn
        '
        Me.PLStatusColumn.DataPropertyName = "PLStatus"
        Me.PLStatusColumn.HeaderText = "PLStatus"
        Me.PLStatusColumn.Name = "PLStatusColumn"
        Me.PLStatusColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'PickListHeaderTableBindingSource
        '
        Me.PickListHeaderTableBindingSource.DataMember = "PickListHeaderTable"
        Me.PickListHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'PickListHeaderTableTableAdapter
        '
        Me.PickListHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmdCheckForCompletedBackorders)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 549)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 104)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Check for Completed Backorders"
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(17, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(175, 57)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Checks all open orders and filters list by the ones that have sufficient QOH to s" & _
            "hip."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCheckForCompletedBackorders
        '
        Me.cmdCheckForCompletedBackorders.Location = New System.Drawing.Point(214, 35)
        Me.cmdCheckForCompletedBackorders.Name = "cmdCheckForCompletedBackorders"
        Me.cmdCheckForCompletedBackorders.Size = New System.Drawing.Size(71, 40)
        Me.cmdCheckForCompletedBackorders.TabIndex = 10
        Me.cmdCheckForCompletedBackorders.Text = "Check"
        Me.cmdCheckForCompletedBackorders.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(982, 771)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 6
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'PickTicketNumber
        '
        Me.PickTicketNumber.HeaderText = "Pick #"
        Me.PickTicketNumber.Name = "PickTicketNumber"
        Me.PickTicketNumber.ReadOnly = True
        '
        'SONumber
        '
        Me.SONumber.HeaderText = "SO #"
        Me.SONumber.Name = "SONumber"
        Me.SONumber.ReadOnly = True
        '
        'Customer
        '
        Me.Customer.HeaderText = "Customer"
        Me.Customer.Name = "Customer"
        Me.Customer.ReadOnly = True
        Me.Customer.Width = 150
        '
        'ShipVia
        '
        Me.ShipVia.HeaderText = "Ship Via"
        Me.ShipVia.Name = "ShipVia"
        Me.ShipVia.ReadOnly = True
        Me.ShipVia.Width = 120
        '
        'Comment
        '
        Me.Comment.HeaderText = "Comment"
        Me.Comment.Name = "Comment"
        Me.Comment.Width = 260
        '
        'DateColumn
        '
        Me.DateColumn.HeaderText = "Pick Date"
        Me.DateColumn.Name = "DateColumn"
        Me.DateColumn.ReadOnly = True
        '
        'CheckBackOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvOpenPicksWithQOH)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvViewOpenPicks)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "CheckBackOrders"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Check Back Orders"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOpenPicksWithQOH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvViewOpenPicks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PickListHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvOpenPicksWithQOH As System.Windows.Forms.DataGridView
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvViewOpenPicks As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents PickListHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PickListHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListHeaderTableTableAdapter
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCheckForCompletedBackorders As System.Windows.Forms.Button
    Friend WithEvents cmdViewOpenOrders As System.Windows.Forms.Button
    Friend WithEvents PickListHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OriginalPickDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipViaColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingMethodColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecialInstructionsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PLStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents txtShipVia As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkIncludeCustomer As System.Windows.Forms.CheckBox
    Friend WithEvents chkExcludeCustomer As System.Windows.Forms.CheckBox
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkIncludeShipVia As System.Windows.Forms.CheckBox
    Friend WithEvents chkExcludeShipVia As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PickTicketNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SONumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Customer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipVia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
