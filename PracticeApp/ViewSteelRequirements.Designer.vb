<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewSteelRequirements
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxSteelRequirements = New System.Windows.Forms.GroupBox
        Me.lblLoadingMessage = New System.Windows.Forms.Label
        Me.pbProgressBar = New System.Windows.Forms.ProgressBar
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkAllTypes = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtSteelRequired = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgvSteelFOXQuery = New System.Windows.Forms.DataGridView
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarbonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelEndingInventoryColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BlanksColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelRequirementsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCommittedToFoxTWD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCommittedToFoxTFP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCommittedToMaximum = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelFOXReportQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SteelFOXReportQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelFOXReportQueryTableAdapter
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxSteelRequirements.SuspendLayout()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSteelFOXQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelFOXReportQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintReportToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintReportToolStripMenuItem
        '
        Me.PrintReportToolStripMenuItem.Name = "PrintReportToolStripMenuItem"
        Me.PrintReportToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.PrintReportToolStripMenuItem.Text = "Print Reports"
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
        'gpxSteelRequirements
        '
        Me.gpxSteelRequirements.Controls.Add(Me.lblLoadingMessage)
        Me.gpxSteelRequirements.Controls.Add(Me.pbProgressBar)
        Me.gpxSteelRequirements.Controls.Add(Me.Label7)
        Me.gpxSteelRequirements.Controls.Add(Me.txtTextFilter)
        Me.gpxSteelRequirements.Controls.Add(Me.Label5)
        Me.gpxSteelRequirements.Controls.Add(Me.chkAllTypes)
        Me.gpxSteelRequirements.Controls.Add(Me.Label4)
        Me.gpxSteelRequirements.Controls.Add(Me.cboSteelSize)
        Me.gpxSteelRequirements.Controls.Add(Me.txtSteelRequired)
        Me.gpxSteelRequirements.Controls.Add(Me.Label6)
        Me.gpxSteelRequirements.Controls.Add(Me.cmdView)
        Me.gpxSteelRequirements.Controls.Add(Me.cmdClear)
        Me.gpxSteelRequirements.Controls.Add(Me.Label2)
        Me.gpxSteelRequirements.Controls.Add(Me.cboCarbon)
        Me.gpxSteelRequirements.Controls.Add(Me.Label1)
        Me.gpxSteelRequirements.Location = New System.Drawing.Point(29, 41)
        Me.gpxSteelRequirements.Name = "gpxSteelRequirements"
        Me.gpxSteelRequirements.Size = New System.Drawing.Size(283, 574)
        Me.gpxSteelRequirements.TabIndex = 0
        Me.gpxSteelRequirements.TabStop = False
        Me.gpxSteelRequirements.Text = "Steel Requirements"
        '
        'lblLoadingMessage
        '
        Me.lblLoadingMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadingMessage.ForeColor = System.Drawing.Color.Blue
        Me.lblLoadingMessage.Location = New System.Drawing.Point(17, 435)
        Me.lblLoadingMessage.Name = "lblLoadingMessage"
        Me.lblLoadingMessage.Size = New System.Drawing.Size(251, 18)
        Me.lblLoadingMessage.TabIndex = 0
        Me.lblLoadingMessage.Text = "Loading blanks, please wait..."
        Me.lblLoadingMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblLoadingMessage.Visible = False
        '
        'pbProgressBar
        '
        Me.pbProgressBar.ForeColor = System.Drawing.Color.Lime
        Me.pbProgressBar.Location = New System.Drawing.Point(20, 409)
        Me.pbProgressBar.Maximum = 1280
        Me.pbProgressBar.Name = "pbProgressBar"
        Me.pbProgressBar.Size = New System.Drawing.Size(248, 23)
        Me.pbProgressBar.TabIndex = 17
        Me.pbProgressBar.Visible = False
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(17, 295)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(251, 32)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "This will search carbon, size that matches the entry"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.Location = New System.Drawing.Point(91, 262)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(177, 20)
        Me.txtTextFilter.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 262)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(137, 20)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Text Filter"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkAllTypes
        '
        Me.chkAllTypes.AutoSize = True
        Me.chkAllTypes.Location = New System.Drawing.Point(79, 68)
        Me.chkAllTypes.Name = "chkAllTypes"
        Me.chkAllTypes.Size = New System.Drawing.Size(69, 17)
        Me.chkAllTypes.TabIndex = 13
        Me.chkAllTypes.Text = "All Types"
        Me.chkAllTypes.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(17, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(251, 32)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Enter a value to view all steel required above a certain value."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSteelSize.DisplayMember = "SteelSize"
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(79, 95)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(189, 21)
        Me.cboSteelSize.TabIndex = 1
        '
        'RawMaterialsTableBindingSource
        '
        Me.RawMaterialsTableBindingSource.DataMember = "RawMaterialsTable"
        Me.RawMaterialsTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtSteelRequired
        '
        Me.txtSteelRequired.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelRequired.Location = New System.Drawing.Point(120, 143)
        Me.txtSteelRequired.Name = "txtSteelRequired"
        Me.txtSteelRequired.Size = New System.Drawing.Size(148, 20)
        Me.txtSteelRequired.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(137, 20)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Steel Required >"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(120, 516)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 40)
        Me.cmdView.TabIndex = 3
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(197, 516)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 4
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Steel Size"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboCarbon.DisplayMember = "Carbon"
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(79, 36)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(189, 21)
        Me.cboCarbon.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Carbon"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 3
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(350, 771)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(368, 44)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Double click in the DataGrid to view details about the line."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvSteelFOXQuery
        '
        Me.dgvSteelFOXQuery.AllowUserToAddRows = False
        Me.dgvSteelFOXQuery.AllowUserToDeleteRows = False
        Me.dgvSteelFOXQuery.AllowUserToOrderColumns = True
        Me.dgvSteelFOXQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSteelFOXQuery.AutoGenerateColumns = False
        Me.dgvSteelFOXQuery.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelFOXQuery.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSteelFOXQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelFOXQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RMIDColumn, Me.CarbonColumn, Me.SteelSizeColumn, Me.DescriptionColumn, Me.SteelEndingInventoryColumn, Me.BlanksColumn, Me.SteelRequirementsColumn, Me.SteelCommittedToFoxTWD, Me.SteelCommittedToFoxTFP, Me.SteelCommittedToMaximum, Me.QuantityOpenColumn})
        Me.dgvSteelFOXQuery.DataSource = Me.SteelFOXReportQueryBindingSource
        Me.dgvSteelFOXQuery.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvSteelFOXQuery.Location = New System.Drawing.Point(335, 41)
        Me.dgvSteelFOXQuery.Name = "dgvSteelFOXQuery"
        Me.dgvSteelFOXQuery.Size = New System.Drawing.Size(695, 724)
        Me.dgvSteelFOXQuery.TabIndex = 14
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        Me.RMIDColumn.Visible = False
        '
        'CarbonColumn
        '
        Me.CarbonColumn.DataPropertyName = "Carbon"
        Me.CarbonColumn.HeaderText = "Carbon"
        Me.CarbonColumn.Name = "CarbonColumn"
        '
        'SteelSizeColumn
        '
        Me.SteelSizeColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn.HeaderText = "Steel Size"
        Me.SteelSizeColumn.Name = "SteelSizeColumn"
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        '
        'SteelEndingInventoryColumn
        '
        Me.SteelEndingInventoryColumn.DataPropertyName = "SteelEndingInventory"
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = "0"
        Me.SteelEndingInventoryColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.SteelEndingInventoryColumn.HeaderText = "QOH"
        Me.SteelEndingInventoryColumn.Name = "SteelEndingInventoryColumn"
        Me.SteelEndingInventoryColumn.ReadOnly = True
        Me.SteelEndingInventoryColumn.Width = 80
        '
        'BlanksColumn
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        Me.BlanksColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.BlanksColumn.HeaderText = "Blanks (lbs.)"
        Me.BlanksColumn.Name = "BlanksColumn"
        Me.BlanksColumn.Width = 80
        '
        'SteelRequirementsColumn
        '
        Me.SteelRequirementsColumn.DataPropertyName = "SteelRequirements"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.SteelRequirementsColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.SteelRequirementsColumn.HeaderText = "Steel Requirements"
        Me.SteelRequirementsColumn.Name = "SteelRequirementsColumn"
        Me.SteelRequirementsColumn.ReadOnly = True
        '
        'SteelCommittedToFoxTWD
        '
        Me.SteelCommittedToFoxTWD.DataPropertyName = "SteelCommittedToFoxTWD"
        DataGridViewCellStyle4.Format = "N0"
        Me.SteelCommittedToFoxTWD.DefaultCellStyle = DataGridViewCellStyle4
        Me.SteelCommittedToFoxTWD.HeaderText = "TWD Sales Order Weight"
        Me.SteelCommittedToFoxTWD.Name = "SteelCommittedToFoxTWD"
        Me.SteelCommittedToFoxTWD.ReadOnly = True
        '
        'SteelCommittedToFoxTFP
        '
        Me.SteelCommittedToFoxTFP.DataPropertyName = "SteelCommittedToFoxTFP"
        DataGridViewCellStyle5.Format = "N0"
        Me.SteelCommittedToFoxTFP.DefaultCellStyle = DataGridViewCellStyle5
        Me.SteelCommittedToFoxTFP.HeaderText = "TFP Sales Order Weight"
        Me.SteelCommittedToFoxTFP.Name = "SteelCommittedToFoxTFP"
        Me.SteelCommittedToFoxTFP.ReadOnly = True
        '
        'SteelCommittedToMaximum
        '
        Me.SteelCommittedToMaximum.DataPropertyName = "SteelCommittedToMaximum"
        DataGridViewCellStyle6.Format = "N0"
        Me.SteelCommittedToMaximum.DefaultCellStyle = DataGridViewCellStyle6
        Me.SteelCommittedToMaximum.HeaderText = "Steel Committed To Maximum"
        Me.SteelCommittedToMaximum.Name = "SteelCommittedToMaximum"
        Me.SteelCommittedToMaximum.ReadOnly = True
        '
        'QuantityOpenColumn
        '
        Me.QuantityOpenColumn.DataPropertyName = "QuantityOpen"
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = "0"
        Me.QuantityOpenColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.QuantityOpenColumn.HeaderText = "PO Quantity Open"
        Me.QuantityOpenColumn.Name = "QuantityOpenColumn"
        Me.QuantityOpenColumn.ReadOnly = True
        '
        'SteelFOXReportQueryBindingSource
        '
        Me.SteelFOXReportQueryBindingSource.DataMember = "SteelFOXReportQuery"
        Me.SteelFOXReportQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SteelFOXReportQueryTableAdapter
        '
        Me.SteelFOXReportQueryTableAdapter.ClearBeforeFill = True
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'ViewSteelRequirements
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.dgvSteelFOXQuery)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxSteelRequirements)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewSteelRequirements"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Steel Requirements"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxSteelRequirements.ResumeLayout(False)
        Me.gpxSteelRequirements.PerformLayout()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSteelFOXQuery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelFOXReportQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxSteelRequirements As System.Windows.Forms.GroupBox
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSteelRequired As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvSteelFOXQuery As System.Windows.Forms.DataGridView
    Friend WithEvents SteelFOXReportQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelFOXReportQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelFOXReportQueryTableAdapter
    Friend WithEvents chkAllTypes As System.Windows.Forms.CheckBox
    Friend WithEvents lblLoadingMessage As System.Windows.Forms.Label
    Friend WithEvents PrintReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelEndingInventoryColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BlanksColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelRequirementsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCommittedToFoxTWD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCommittedToFoxTFP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCommittedToMaximum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pbProgressBar As System.Windows.Forms.ProgressBar
End Class
