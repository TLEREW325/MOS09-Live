<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewBinPreferences
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
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cmdViewByDivision = New System.Windows.Forms.Button
        Me.lblDivision = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.dgvBinPreferences = New System.Windows.Forms.DataGridView
        Me.PreferenceKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RowNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pref01Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pref02Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pref03Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pref04Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pref05Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pref06Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pref07Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pref08Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pref09Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pref10Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pref11Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pref12Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pref13Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pref14Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pref15Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pref16Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pref17Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pref18Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BinPrefLocationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BinPrefLocationTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BinPrefLocationTableAdapter
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtPref18 = New System.Windows.Forms.TextBox
        Me.txtPref16 = New System.Windows.Forms.TextBox
        Me.txtPref17 = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtPref14 = New System.Windows.Forms.TextBox
        Me.txtPref15 = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtPref12 = New System.Windows.Forms.TextBox
        Me.txtPref13 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtPref10 = New System.Windows.Forms.TextBox
        Me.txtPref11 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtPref8 = New System.Windows.Forms.TextBox
        Me.txtPref9 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtPref6 = New System.Windows.Forms.TextBox
        Me.txtPref7 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtPref4 = New System.Windows.Forms.TextBox
        Me.txtPref5 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtPref2 = New System.Windows.Forms.TextBox
        Me.txtPref3 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPrefCode = New System.Windows.Forms.TextBox
        Me.txtPref1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdClearFields = New System.Windows.Forms.Button
        Me.cmdAddPreference = New System.Windows.Forms.Button
        Me.cmdDeletePreference = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBinPreferences, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BinPrefLocationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.cmdViewByDivision)
        Me.GroupBox1.Controls.Add(Me.lblDivision)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 111)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View By Filters"
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(110, 30)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(173, 21)
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
        'cmdViewByDivision
        '
        Me.cmdViewByDivision.Location = New System.Drawing.Point(212, 65)
        Me.cmdViewByDivision.Name = "cmdViewByDivision"
        Me.cmdViewByDivision.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByDivision.TabIndex = 2
        Me.cmdViewByDivision.Text = "View"
        Me.cmdViewByDivision.UseVisualStyleBackColor = True
        '
        'lblDivision
        '
        Me.lblDivision.Location = New System.Drawing.Point(17, 29)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(76, 23)
        Me.lblDivision.TabIndex = 1
        Me.lblDivision.Text = "Division"
        Me.lblDivision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'dgvBinPreferences
        '
        Me.dgvBinPreferences.AllowUserToAddRows = False
        Me.dgvBinPreferences.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBinPreferences.AutoGenerateColumns = False
        Me.dgvBinPreferences.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvBinPreferences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBinPreferences.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PreferenceKeyColumn, Me.RowNameColumn, Me.Pref01Column, Me.Pref02Column, Me.Pref03Column, Me.Pref04Column, Me.Pref05Column, Me.Pref06Column, Me.Pref07Column, Me.Pref08Column, Me.Pref09Column, Me.Pref10Column, Me.Pref11Column, Me.Pref12Column, Me.Pref13Column, Me.Pref14Column, Me.Pref15Column, Me.Pref16Column, Me.Pref17Column, Me.Pref18Column, Me.DivisionIDColumn})
        Me.dgvBinPreferences.DataSource = Me.BinPrefLocationBindingSource
        Me.dgvBinPreferences.GridColor = System.Drawing.Color.Green
        Me.dgvBinPreferences.Location = New System.Drawing.Point(344, 41)
        Me.dgvBinPreferences.Name = "dgvBinPreferences"
        Me.dgvBinPreferences.Size = New System.Drawing.Size(786, 710)
        Me.dgvBinPreferences.TabIndex = 25
        '
        'PreferenceKeyColumn
        '
        Me.PreferenceKeyColumn.DataPropertyName = "PreferenceKey"
        Me.PreferenceKeyColumn.HeaderText = "PreferenceKey"
        Me.PreferenceKeyColumn.Name = "PreferenceKeyColumn"
        Me.PreferenceKeyColumn.Visible = False
        '
        'RowNameColumn
        '
        Me.RowNameColumn.DataPropertyName = "RowName"
        Me.RowNameColumn.HeaderText = "Preference Code"
        Me.RowNameColumn.Name = "RowNameColumn"
        '
        'Pref01Column
        '
        Me.Pref01Column.DataPropertyName = "Pref01"
        Me.Pref01Column.HeaderText = "Pref01"
        Me.Pref01Column.Name = "Pref01Column"
        '
        'Pref02Column
        '
        Me.Pref02Column.DataPropertyName = "Pref02"
        Me.Pref02Column.HeaderText = "Pref02"
        Me.Pref02Column.Name = "Pref02Column"
        '
        'Pref03Column
        '
        Me.Pref03Column.DataPropertyName = "Pref03"
        Me.Pref03Column.HeaderText = "Pref03"
        Me.Pref03Column.Name = "Pref03Column"
        '
        'Pref04Column
        '
        Me.Pref04Column.DataPropertyName = "Pref04"
        Me.Pref04Column.HeaderText = "Pref04"
        Me.Pref04Column.Name = "Pref04Column"
        '
        'Pref05Column
        '
        Me.Pref05Column.DataPropertyName = "Pref05"
        Me.Pref05Column.HeaderText = "Pref05"
        Me.Pref05Column.Name = "Pref05Column"
        '
        'Pref06Column
        '
        Me.Pref06Column.DataPropertyName = "Pref06"
        Me.Pref06Column.HeaderText = "Pref06"
        Me.Pref06Column.Name = "Pref06Column"
        '
        'Pref07Column
        '
        Me.Pref07Column.DataPropertyName = "Pref07"
        Me.Pref07Column.HeaderText = "Pref07"
        Me.Pref07Column.Name = "Pref07Column"
        '
        'Pref08Column
        '
        Me.Pref08Column.DataPropertyName = "Pref08"
        Me.Pref08Column.HeaderText = "Pref08"
        Me.Pref08Column.Name = "Pref08Column"
        '
        'Pref09Column
        '
        Me.Pref09Column.DataPropertyName = "Pref09"
        Me.Pref09Column.HeaderText = "Pref09"
        Me.Pref09Column.Name = "Pref09Column"
        '
        'Pref10Column
        '
        Me.Pref10Column.DataPropertyName = "Pref10"
        Me.Pref10Column.HeaderText = "Pref10"
        Me.Pref10Column.Name = "Pref10Column"
        '
        'Pref11Column
        '
        Me.Pref11Column.DataPropertyName = "Pref11"
        Me.Pref11Column.HeaderText = "Pref11"
        Me.Pref11Column.Name = "Pref11Column"
        '
        'Pref12Column
        '
        Me.Pref12Column.DataPropertyName = "Pref12"
        Me.Pref12Column.HeaderText = "Pref12"
        Me.Pref12Column.Name = "Pref12Column"
        '
        'Pref13Column
        '
        Me.Pref13Column.DataPropertyName = "Pref13"
        Me.Pref13Column.HeaderText = "Pref13"
        Me.Pref13Column.Name = "Pref13Column"
        '
        'Pref14Column
        '
        Me.Pref14Column.DataPropertyName = "Pref14"
        Me.Pref14Column.HeaderText = "Pref14"
        Me.Pref14Column.Name = "Pref14Column"
        '
        'Pref15Column
        '
        Me.Pref15Column.DataPropertyName = "Pref15"
        Me.Pref15Column.HeaderText = "Pref15"
        Me.Pref15Column.Name = "Pref15Column"
        '
        'Pref16Column
        '
        Me.Pref16Column.DataPropertyName = "Pref16"
        Me.Pref16Column.HeaderText = "Pref16"
        Me.Pref16Column.Name = "Pref16Column"
        '
        'Pref17Column
        '
        Me.Pref17Column.DataPropertyName = "Pref17"
        Me.Pref17Column.HeaderText = "Pref17"
        Me.Pref17Column.Name = "Pref17Column"
        '
        'Pref18Column
        '
        Me.Pref18Column.DataPropertyName = "Pref18"
        Me.Pref18Column.HeaderText = "Pref18"
        Me.Pref18Column.Name = "Pref18Column"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'BinPrefLocationBindingSource
        '
        Me.BinPrefLocationBindingSource.DataMember = "BinPrefLocation"
        Me.BinPrefLocationBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'BinPrefLocationTableAdapter
        '
        Me.BinPrefLocationTableAdapter.ClearBeforeFill = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(982, 771)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 27
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 28
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPref18)
        Me.GroupBox2.Controls.Add(Me.txtPref16)
        Me.GroupBox2.Controls.Add(Me.txtPref17)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtPref14)
        Me.GroupBox2.Controls.Add(Me.txtPref15)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtPref12)
        Me.GroupBox2.Controls.Add(Me.txtPref13)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtPref10)
        Me.GroupBox2.Controls.Add(Me.txtPref11)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtPref8)
        Me.GroupBox2.Controls.Add(Me.txtPref9)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtPref6)
        Me.GroupBox2.Controls.Add(Me.txtPref7)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtPref4)
        Me.GroupBox2.Controls.Add(Me.txtPref5)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtPref2)
        Me.GroupBox2.Controls.Add(Me.txtPref3)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtPrefCode)
        Me.GroupBox2.Controls.Add(Me.txtPref1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cmdClearFields)
        Me.GroupBox2.Controls.Add(Me.cmdAddPreference)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 157)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 654)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Add Preference"
        '
        'txtPref18
        '
        Me.txtPref18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPref18.Location = New System.Drawing.Point(129, 572)
        Me.txtPref18.Name = "txtPref18"
        Me.txtPref18.Size = New System.Drawing.Size(154, 20)
        Me.txtPref18.TabIndex = 22
        '
        'txtPref16
        '
        Me.txtPref16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPref16.Location = New System.Drawing.Point(129, 512)
        Me.txtPref16.Name = "txtPref16"
        Me.txtPref16.Size = New System.Drawing.Size(154, 20)
        Me.txtPref16.TabIndex = 20
        '
        'txtPref17
        '
        Me.txtPref17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPref17.Location = New System.Drawing.Point(129, 542)
        Me.txtPref17.Name = "txtPref17"
        Me.txtPref17.Size = New System.Drawing.Size(154, 20)
        Me.txtPref17.TabIndex = 21
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(17, 542)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(106, 23)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "Pref. #17"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(17, 512)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(106, 23)
        Me.Label18.TabIndex = 39
        Me.Label18.Text = "Pref. #16"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPref14
        '
        Me.txtPref14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPref14.Location = New System.Drawing.Point(129, 452)
        Me.txtPref14.Name = "txtPref14"
        Me.txtPref14.Size = New System.Drawing.Size(154, 20)
        Me.txtPref14.TabIndex = 18
        '
        'txtPref15
        '
        Me.txtPref15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPref15.Location = New System.Drawing.Point(129, 482)
        Me.txtPref15.Name = "txtPref15"
        Me.txtPref15.Size = New System.Drawing.Size(154, 20)
        Me.txtPref15.TabIndex = 19
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(17, 572)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(106, 23)
        Me.Label20.TabIndex = 37
        Me.Label20.Text = "Pref. #18"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(17, 482)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(106, 23)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "Pref. #15"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(17, 452)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(106, 23)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "Pref. #14"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPref12
        '
        Me.txtPref12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPref12.Location = New System.Drawing.Point(129, 392)
        Me.txtPref12.Name = "txtPref12"
        Me.txtPref12.Size = New System.Drawing.Size(154, 20)
        Me.txtPref12.TabIndex = 16
        '
        'txtPref13
        '
        Me.txtPref13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPref13.Location = New System.Drawing.Point(129, 422)
        Me.txtPref13.Name = "txtPref13"
        Me.txtPref13.Size = New System.Drawing.Size(154, 20)
        Me.txtPref13.TabIndex = 17
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(17, 422)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(106, 23)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Pref. #13"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(17, 392)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(106, 23)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Pref. #12"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPref10
        '
        Me.txtPref10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPref10.Location = New System.Drawing.Point(129, 332)
        Me.txtPref10.Name = "txtPref10"
        Me.txtPref10.Size = New System.Drawing.Size(154, 20)
        Me.txtPref10.TabIndex = 14
        '
        'txtPref11
        '
        Me.txtPref11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPref11.Location = New System.Drawing.Point(129, 362)
        Me.txtPref11.Name = "txtPref11"
        Me.txtPref11.Size = New System.Drawing.Size(154, 20)
        Me.txtPref11.TabIndex = 15
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(17, 362)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(106, 23)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Pref. #11"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(17, 332)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(106, 23)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Pref. #10"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPref8
        '
        Me.txtPref8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPref8.Location = New System.Drawing.Point(129, 272)
        Me.txtPref8.Name = "txtPref8"
        Me.txtPref8.Size = New System.Drawing.Size(154, 20)
        Me.txtPref8.TabIndex = 12
        '
        'txtPref9
        '
        Me.txtPref9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPref9.Location = New System.Drawing.Point(129, 302)
        Me.txtPref9.Name = "txtPref9"
        Me.txtPref9.Size = New System.Drawing.Size(154, 20)
        Me.txtPref9.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(17, 302)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 23)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Pref. #9"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(17, 272)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 23)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Pref. #8"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPref6
        '
        Me.txtPref6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPref6.Location = New System.Drawing.Point(129, 212)
        Me.txtPref6.Name = "txtPref6"
        Me.txtPref6.Size = New System.Drawing.Size(154, 20)
        Me.txtPref6.TabIndex = 10
        '
        'txtPref7
        '
        Me.txtPref7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPref7.Location = New System.Drawing.Point(129, 242)
        Me.txtPref7.Name = "txtPref7"
        Me.txtPref7.Size = New System.Drawing.Size(154, 20)
        Me.txtPref7.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 242)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 23)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Pref. #7"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 212)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 23)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Pref. #6"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPref4
        '
        Me.txtPref4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPref4.Location = New System.Drawing.Point(129, 152)
        Me.txtPref4.Name = "txtPref4"
        Me.txtPref4.Size = New System.Drawing.Size(154, 20)
        Me.txtPref4.TabIndex = 8
        '
        'txtPref5
        '
        Me.txtPref5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPref5.Location = New System.Drawing.Point(129, 182)
        Me.txtPref5.Name = "txtPref5"
        Me.txtPref5.Size = New System.Drawing.Size(154, 20)
        Me.txtPref5.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 182)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 23)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Pref. #5"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 23)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Pref. #4"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPref2
        '
        Me.txtPref2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPref2.Location = New System.Drawing.Point(129, 92)
        Me.txtPref2.Name = "txtPref2"
        Me.txtPref2.Size = New System.Drawing.Size(154, 20)
        Me.txtPref2.TabIndex = 6
        '
        'txtPref3
        '
        Me.txtPref3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPref3.Location = New System.Drawing.Point(129, 122)
        Me.txtPref3.Name = "txtPref3"
        Me.txtPref3.Size = New System.Drawing.Size(154, 20)
        Me.txtPref3.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 23)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Pref. #3"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 23)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Pref. #2"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrefCode
        '
        Me.txtPrefCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrefCode.Location = New System.Drawing.Point(129, 32)
        Me.txtPrefCode.Name = "txtPrefCode"
        Me.txtPrefCode.Size = New System.Drawing.Size(154, 20)
        Me.txtPrefCode.TabIndex = 4
        '
        'txtPref1
        '
        Me.txtPref1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPref1.Location = New System.Drawing.Point(129, 62)
        Me.txtPref1.Name = "txtPref1"
        Me.txtPref1.Size = New System.Drawing.Size(154, 20)
        Me.txtPref1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 23)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Pref. #1"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 23)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Pref. Code"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearFields
        '
        Me.cmdClearFields.Location = New System.Drawing.Point(212, 605)
        Me.cmdClearFields.Name = "cmdClearFields"
        Me.cmdClearFields.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearFields.TabIndex = 24
        Me.cmdClearFields.Text = "Clear"
        Me.cmdClearFields.UseVisualStyleBackColor = True
        '
        'cmdAddPreference
        '
        Me.cmdAddPreference.Location = New System.Drawing.Point(135, 605)
        Me.cmdAddPreference.Name = "cmdAddPreference"
        Me.cmdAddPreference.Size = New System.Drawing.Size(71, 30)
        Me.cmdAddPreference.TabIndex = 23
        Me.cmdAddPreference.Text = "Add"
        Me.cmdAddPreference.UseVisualStyleBackColor = True
        '
        'cmdDeletePreference
        '
        Me.cmdDeletePreference.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeletePreference.Location = New System.Drawing.Point(344, 771)
        Me.cmdDeletePreference.Name = "cmdDeletePreference"
        Me.cmdDeletePreference.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeletePreference.TabIndex = 26
        Me.cmdDeletePreference.Text = "Delete Preference"
        Me.cmdDeletePreference.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(442, 771)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(214, 43)
        Me.Label19.TabIndex = 27
        Me.Label19.Text = "Select line item in the datagrid to delete a bin/rack preference."
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewBinPreferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cmdDeletePreference)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.dgvBinPreferences)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewBinPreferences"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Bin/Rack Preferences"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBinPreferences, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BinPrefLocationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents lblDivision As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents dgvBinPreferences As System.Windows.Forms.DataGridView
    Friend WithEvents BinPrefLocationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BinPrefLocationTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BinPrefLocationTableAdapter
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdViewByDivision As System.Windows.Forms.Button
    Friend WithEvents PreferenceKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RowNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pref01Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pref02Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pref03Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pref04Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pref05Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pref06Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pref07Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pref08Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pref09Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pref10Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pref11Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pref12Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pref13Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pref14Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pref15Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pref16Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pref17Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pref18Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClearFields As System.Windows.Forms.Button
    Friend WithEvents cmdAddPreference As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPref18 As System.Windows.Forms.TextBox
    Friend WithEvents txtPref16 As System.Windows.Forms.TextBox
    Friend WithEvents txtPref17 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtPref14 As System.Windows.Forms.TextBox
    Friend WithEvents txtPref15 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPref12 As System.Windows.Forms.TextBox
    Friend WithEvents txtPref13 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPref10 As System.Windows.Forms.TextBox
    Friend WithEvents txtPref11 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPref8 As System.Windows.Forms.TextBox
    Friend WithEvents txtPref9 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPref6 As System.Windows.Forms.TextBox
    Friend WithEvents txtPref7 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPref4 As System.Windows.Forms.TextBox
    Friend WithEvents txtPref5 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPref2 As System.Windows.Forms.TextBox
    Friend WithEvents txtPref3 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPrefCode As System.Windows.Forms.TextBox
    Friend WithEvents txtPref1 As System.Windows.Forms.TextBox
    Friend WithEvents cmdDeletePreference As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
