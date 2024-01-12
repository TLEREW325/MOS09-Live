<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewAssemblyListing
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveChangesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxAPAging = New System.Windows.Forms.GroupBox
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.txtAssemblyDescription = New System.Windows.Forms.TextBox
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvAssemblyListing = New System.Windows.Forms.DataGridView
        Me.AssemblyPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerializedStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AssemblyHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblyHeaderTableTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdOpenItemMaintenance = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdPrintBOM = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.gpxAPAging.SuspendLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAssemblyListing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssemblyHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveChangesToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveChangesToolStripMenuItem
        '
        Me.SaveChangesToolStripMenuItem.Name = "SaveChangesToolStripMenuItem"
        Me.SaveChangesToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.SaveChangesToolStripMenuItem.Text = "Save Changes"
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
        'gpxAPAging
        '
        Me.gpxAPAging.Controls.Add(Me.cmdDelete)
        Me.gpxAPAging.Controls.Add(Me.txtAssemblyDescription)
        Me.gpxAPAging.Controls.Add(Me.cboPartDescription)
        Me.gpxAPAging.Controls.Add(Me.cboDivisionID)
        Me.gpxAPAging.Controls.Add(Me.cboPartNumber)
        Me.gpxAPAging.Controls.Add(Me.cmdView)
        Me.gpxAPAging.Controls.Add(Me.cmdClear)
        Me.gpxAPAging.Controls.Add(Me.Label2)
        Me.gpxAPAging.Controls.Add(Me.Label1)
        Me.gpxAPAging.Location = New System.Drawing.Point(29, 41)
        Me.gpxAPAging.Name = "gpxAPAging"
        Me.gpxAPAging.Size = New System.Drawing.Size(300, 289)
        Me.gpxAPAging.TabIndex = 0
        Me.gpxAPAging.TabStop = False
        Me.gpxAPAging.Text = "View By Part Number"
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(136, 242)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 30)
        Me.cmdDelete.TabIndex = 6
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'txtAssemblyDescription
        '
        Me.txtAssemblyDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAssemblyDescription.Location = New System.Drawing.Point(23, 133)
        Me.txtAssemblyDescription.Multiline = True
        Me.txtAssemblyDescription.Name = "txtAssemblyDescription"
        Me.txtAssemblyDescription.Size = New System.Drawing.Size(262, 91)
        Me.txtAssemblyDescription.TabIndex = 3
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(22, 98)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(263, 21)
        Me.cboPartDescription.TabIndex = 2
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
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(83, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(202, 21)
        Me.cboDivisionID.TabIndex = 0
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
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(83, 63)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(202, 21)
        Me.cboPartNumber.TabIndex = 1
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(59, 242)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 4
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(213, 242)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Part #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvAssemblyListing
        '
        Me.dgvAssemblyListing.AllowUserToAddRows = False
        Me.dgvAssemblyListing.AllowUserToDeleteRows = False
        Me.dgvAssemblyListing.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvAssemblyListing.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAssemblyListing.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAssemblyListing.AutoGenerateColumns = False
        Me.dgvAssemblyListing.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAssemblyListing.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAssemblyListing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAssemblyListing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AssemblyPartNumberColumn, Me.AssemblyDescriptionColumn, Me.TotalCostColumn, Me.SerializedStatusColumn, Me.CommentColumn, Me.AssemblyDateColumn, Me.DivisionIDColumn})
        Me.dgvAssemblyListing.DataSource = Me.AssemblyHeaderTableBindingSource
        Me.dgvAssemblyListing.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvAssemblyListing.Location = New System.Drawing.Point(347, 41)
        Me.dgvAssemblyListing.Name = "dgvAssemblyListing"
        Me.dgvAssemblyListing.Size = New System.Drawing.Size(683, 714)
        Me.dgvAssemblyListing.TabIndex = 4
        '
        'AssemblyPartNumberColumn
        '
        Me.AssemblyPartNumberColumn.DataPropertyName = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn.HeaderText = "Assembly Part #"
        Me.AssemblyPartNumberColumn.Name = "AssemblyPartNumberColumn"
        Me.AssemblyPartNumberColumn.Width = 150
        '
        'AssemblyDescriptionColumn
        '
        Me.AssemblyDescriptionColumn.DataPropertyName = "AssemblyDescription"
        Me.AssemblyDescriptionColumn.HeaderText = "Description"
        Me.AssemblyDescriptionColumn.Name = "AssemblyDescriptionColumn"
        Me.AssemblyDescriptionColumn.Width = 200
        '
        'TotalCostColumn
        '
        Me.TotalCostColumn.DataPropertyName = "TotalCost"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.TotalCostColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.TotalCostColumn.HeaderText = "Total Cost"
        Me.TotalCostColumn.Name = "TotalCostColumn"
        '
        'SerializedStatusColumn
        '
        Me.SerializedStatusColumn.DataPropertyName = "SerializedStatus"
        Me.SerializedStatusColumn.HeaderText = "Serialized Status"
        Me.SerializedStatusColumn.Name = "SerializedStatusColumn"
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'AssemblyDateColumn
        '
        Me.AssemblyDateColumn.DataPropertyName = "AssemblyDate"
        Me.AssemblyDateColumn.HeaderText = "Creation Date"
        Me.AssemblyDateColumn.Name = "AssemblyDateColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'AssemblyHeaderTableBindingSource
        '
        Me.AssemblyHeaderTableBindingSource.DataMember = "AssemblyHeaderTable"
        Me.AssemblyHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'AssemblyHeaderTableTableAdapter
        '
        Me.AssemblyHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 8
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 9
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdOpenItemMaintenance)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 669)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 146)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Item Maintenance"
        '
        'cmdOpenItemMaintenance
        '
        Me.cmdOpenItemMaintenance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenItemMaintenance.Location = New System.Drawing.Point(214, 88)
        Me.cmdOpenItemMaintenance.Name = "cmdOpenItemMaintenance"
        Me.cmdOpenItemMaintenance.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenItemMaintenance.TabIndex = 7
        Me.cmdOpenItemMaintenance.Text = "Item Main."
        Me.cmdOpenItemMaintenance.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(19, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(262, 54)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Select a part number at the top to open the Item Maintenance Form to edit the ass" & _
            "emblty components for that assembly."
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdPrintBOM)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 504)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 146)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Print Bill of Materials"
        '
        'cmdPrintBOM
        '
        Me.cmdPrintBOM.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintBOM.Location = New System.Drawing.Point(213, 88)
        Me.cmdPrintBOM.Name = "cmdPrintBOM"
        Me.cmdPrintBOM.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintBOM.TabIndex = 6
        Me.cmdPrintBOM.Text = "Bill Of Materials"
        Me.cmdPrintBOM.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(23, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(262, 54)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Select a part number at the top to view the Bill of Materials for that part, othe" & _
            "rwise it will list the Bill of Materials for all assembly items."
        '
        'ViewAssemblyListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvAssemblyListing)
        Me.Controls.Add(Me.gpxAPAging)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewAssemblyListing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Assembly Listing"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxAPAging.ResumeLayout(False)
        Me.gpxAPAging.PerformLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAssemblyListing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssemblyHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
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
    Friend WithEvents gpxAPAging As System.Windows.Forms.GroupBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvAssemblyListing As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents AssemblyHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AssemblyHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblyHeaderTableTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents txtAssemblyDescription As System.Windows.Forms.TextBox
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOpenItemMaintenance As System.Windows.Forms.Button
    Friend WithEvents cmdPrintBOM As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SaveChangesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssemblyPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssemblyDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerializedStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssemblyDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
End Class
