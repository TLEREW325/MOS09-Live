<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaymentTermsMaintenance
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxPaymentTerms = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDiscountPercent = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdEnter = New System.Windows.Forms.Button
        Me.txtDiscountDays = New System.Windows.Forms.TextBox
        Me.txtDueDays = New System.Windows.Forms.TextBox
        Me.txtPaymentTermDescription = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboPaymentTermID = New System.Windows.Forms.ComboBox
        Me.PaymentTermsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label5 = New System.Windows.Forms.Label
        Me.dgvPaymentTerms = New System.Windows.Forms.DataGridView
        Me.PmtTermsIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountPercentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountDaysColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DueDaysColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTermsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PaymentTermsTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxPaymentTerms.SuspendLayout()
        CType(Me.PaymentTermsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPaymentTerms, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
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
        'cmdPrint
        '
        Me.cmdPrint.Location = New System.Drawing.Point(882, 721)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 33
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(959, 721)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 34
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxPaymentTerms
        '
        Me.gpxPaymentTerms.Controls.Add(Me.Label2)
        Me.gpxPaymentTerms.Controls.Add(Me.txtDiscountPercent)
        Me.gpxPaymentTerms.Controls.Add(Me.Label1)
        Me.gpxPaymentTerms.Controls.Add(Me.cmdClear)
        Me.gpxPaymentTerms.Controls.Add(Me.cmdEnter)
        Me.gpxPaymentTerms.Controls.Add(Me.txtDiscountDays)
        Me.gpxPaymentTerms.Controls.Add(Me.txtDueDays)
        Me.gpxPaymentTerms.Controls.Add(Me.txtPaymentTermDescription)
        Me.gpxPaymentTerms.Controls.Add(Me.Label8)
        Me.gpxPaymentTerms.Controls.Add(Me.Label7)
        Me.gpxPaymentTerms.Controls.Add(Me.Label6)
        Me.gpxPaymentTerms.Controls.Add(Me.cboPaymentTermID)
        Me.gpxPaymentTerms.Controls.Add(Me.Label5)
        Me.gpxPaymentTerms.Location = New System.Drawing.Point(29, 41)
        Me.gpxPaymentTerms.Name = "gpxPaymentTerms"
        Me.gpxPaymentTerms.Size = New System.Drawing.Size(300, 552)
        Me.gpxPaymentTerms.TabIndex = 35
        Me.gpxPaymentTerms.TabStop = False
        Me.gpxPaymentTerms.Text = "Payment Terms"
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(19, 253)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(264, 62)
        Me.Label2.TabIndex = 98
        Me.Label2.Text = "Data below must be filled out correctly so that Discounts and Due Dates are calcu" & _
            "lated correctly."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDiscountPercent
        '
        Me.txtDiscountPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscountPercent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDiscountPercent.Location = New System.Drawing.Point(185, 339)
        Me.txtDiscountPercent.Name = "txtDiscountPercent"
        Me.txtDiscountPercent.Size = New System.Drawing.Size(98, 20)
        Me.txtDiscountPercent.TabIndex = 97
        Me.txtDiscountPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 339)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 20)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Discount Percent (as a decimal)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(212, 492)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 95
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdEnter
        '
        Me.cmdEnter.Location = New System.Drawing.Point(135, 492)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(71, 40)
        Me.cmdEnter.TabIndex = 94
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'txtDiscountDays
        '
        Me.txtDiscountDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscountDays.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDiscountDays.Location = New System.Drawing.Point(185, 435)
        Me.txtDiscountDays.Name = "txtDiscountDays"
        Me.txtDiscountDays.Size = New System.Drawing.Size(98, 20)
        Me.txtDiscountDays.TabIndex = 93
        Me.txtDiscountDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDueDays
        '
        Me.txtDueDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDueDays.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDueDays.Location = New System.Drawing.Point(185, 387)
        Me.txtDueDays.Name = "txtDueDays"
        Me.txtDueDays.Size = New System.Drawing.Size(98, 20)
        Me.txtDueDays.TabIndex = 92
        Me.txtDueDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPaymentTermDescription
        '
        Me.txtPaymentTermDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaymentTermDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaymentTermDescription.Location = New System.Drawing.Point(22, 123)
        Me.txtPaymentTermDescription.Multiline = True
        Me.txtPaymentTermDescription.Name = "txtPaymentTermDescription"
        Me.txtPaymentTermDescription.Size = New System.Drawing.Size(261, 127)
        Me.txtPaymentTermDescription.TabIndex = 91
        Me.txtPaymentTermDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(19, 435)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(191, 20)
        Me.Label8.TabIndex = 89
        Me.Label8.Text = "Discount Date - Number of Days"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(19, 387)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(191, 20)
        Me.Label7.TabIndex = 88
        Me.Label7.Text = "Due Date - Number of Days"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(19, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(191, 20)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "Payment Term Description"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPaymentTermID
        '
        Me.cboPaymentTermID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPaymentTermID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentTermID.DataSource = Me.PaymentTermsBindingSource
        Me.cboPaymentTermID.DisplayMember = "PmtTermsID"
        Me.cboPaymentTermID.FormattingEnabled = True
        Me.cboPaymentTermID.Location = New System.Drawing.Point(22, 55)
        Me.cboPaymentTermID.MaxLength = 50
        Me.cboPaymentTermID.Name = "cboPaymentTermID"
        Me.cboPaymentTermID.Size = New System.Drawing.Size(261, 21)
        Me.cboPaymentTermID.TabIndex = 0
        '
        'PaymentTermsBindingSource
        '
        Me.PaymentTermsBindingSource.DataMember = "PaymentTerms"
        Me.PaymentTermsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(19, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(264, 20)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "Payment Term ID (50 Characters MAX)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvPaymentTerms
        '
        Me.dgvPaymentTerms.AllowUserToAddRows = False
        Me.dgvPaymentTerms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPaymentTerms.AutoGenerateColumns = False
        Me.dgvPaymentTerms.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvPaymentTerms.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPaymentTerms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPaymentTerms.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PmtTermsIDColumn, Me.DescriptionColumn, Me.DiscountPercentColumn, Me.DiscountDaysColumn, Me.DueDaysColumn})
        Me.dgvPaymentTerms.DataSource = Me.PaymentTermsBindingSource
        Me.dgvPaymentTerms.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvPaymentTerms.Location = New System.Drawing.Point(351, 44)
        Me.dgvPaymentTerms.Name = "dgvPaymentTerms"
        Me.dgvPaymentTerms.Size = New System.Drawing.Size(679, 667)
        Me.dgvPaymentTerms.TabIndex = 36
        '
        'PmtTermsIDColumn
        '
        Me.PmtTermsIDColumn.DataPropertyName = "PmtTermsID"
        Me.PmtTermsIDColumn.HeaderText = "Payment Terms ID"
        Me.PmtTermsIDColumn.Name = "PmtTermsIDColumn"
        Me.PmtTermsIDColumn.ReadOnly = True
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        Me.DescriptionColumn.Width = 180
        '
        'DiscountPercentColumn
        '
        Me.DiscountPercentColumn.DataPropertyName = "DiscountPercent"
        DataGridViewCellStyle1.Format = "N4"
        DataGridViewCellStyle1.NullValue = "0"
        Me.DiscountPercentColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.DiscountPercentColumn.HeaderText = "Discount Percent"
        Me.DiscountPercentColumn.Name = "DiscountPercentColumn"
        '
        'DiscountDaysColumn
        '
        Me.DiscountDaysColumn.DataPropertyName = "DiscountDays"
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        Me.DiscountDaysColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.DiscountDaysColumn.HeaderText = "Discount Days"
        Me.DiscountDaysColumn.Name = "DiscountDaysColumn"
        '
        'DueDaysColumn
        '
        Me.DueDaysColumn.DataPropertyName = "DueDays"
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.DueDaysColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.DueDaysColumn.HeaderText = "Due Days"
        Me.DueDaysColumn.Name = "DueDaysColumn"
        '
        'PaymentTermsTableAdapter
        '
        Me.PaymentTermsTableAdapter.ClearBeforeFill = True
        '
        'PaymentTermsMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 773)
        Me.Controls.Add(Me.dgvPaymentTerms)
        Me.Controls.Add(Me.gpxPaymentTerms)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "PaymentTermsMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Payment Terms Maintenance"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxPaymentTerms.ResumeLayout(False)
        Me.gpxPaymentTerms.PerformLayout()
        CType(Me.PaymentTermsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPaymentTerms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxPaymentTerms As System.Windows.Forms.GroupBox
    Friend WithEvents cboPaymentTermID As System.Windows.Forms.ComboBox
    Friend WithEvents txtPaymentTermDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDiscountPercent As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents txtDiscountDays As System.Windows.Forms.TextBox
    Friend WithEvents txtDueDays As System.Windows.Forms.TextBox
    Friend WithEvents dgvPaymentTerms As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents PaymentTermsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PaymentTermsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PaymentTermsTableAdapter
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PmtTermsIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountPercentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountDaysColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DueDaysColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
