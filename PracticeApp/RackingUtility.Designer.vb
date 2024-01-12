<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RackingUtility
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
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdViewRacks = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdClearBinReference = New System.Windows.Forms.Button
        Me.cmdViewBinPreference = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSearchBinPreference = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cboRackPosition = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtAddRackLevel = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtAddMaxUprightWeight = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtAddMaxBarWeight = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtAddPartnerBin = New System.Windows.Forms.TextBox
        Me.cmdClearAddRacks = New System.Windows.Forms.Button
        Me.cmdAddRacks = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtAddLastNumber = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtAddFirstNumber = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtAddRackPrefix = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cmdDeleteRack = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDeleteRack = New System.Windows.Forms.TextBox
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvBinNumbers = New System.Windows.Forms.DataGridView
        Me.BinNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartnerBinNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaxBarWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaxUprightWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackPositionColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.RackLevelColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BinNumberBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BinNumberTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BinNumberTableAdapter
        Me.Label13 = New System.Windows.Forms.Label
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
        Me.DivisionIDColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BinPrefLocationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BinPrefLocationTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BinPrefLocationTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvBinNumbers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BinNumberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBinPreferences, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BinPrefLocationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.cmdViewRacks)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtFilter)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 157)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View Racks"
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(208, 112)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 4
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdViewRacks
        '
        Me.cmdViewRacks.Location = New System.Drawing.Point(131, 112)
        Me.cmdViewRacks.Name = "cmdViewRacks"
        Me.cmdViewRacks.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewRacks.TabIndex = 3
        Me.cmdViewRacks.Text = "View"
        Me.cmdViewRacks.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Text Filter"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFilter
        '
        Me.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFilter.Location = New System.Drawing.Point(106, 73)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(173, 20)
        Me.txtFilter.TabIndex = 2
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(106, 33)
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
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Division"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdClearBinReference)
        Me.GroupBox2.Controls.Add(Me.cmdViewBinPreference)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtSearchBinPreference)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 701)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 110)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "View Bin Preferences"
        '
        'cmdClearBinReference
        '
        Me.cmdClearBinReference.Location = New System.Drawing.Point(208, 64)
        Me.cmdClearBinReference.Name = "cmdClearBinReference"
        Me.cmdClearBinReference.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearBinReference.TabIndex = 22
        Me.cmdClearBinReference.Text = "Clear"
        Me.cmdClearBinReference.UseVisualStyleBackColor = True
        '
        'cmdViewBinPreference
        '
        Me.cmdViewBinPreference.Location = New System.Drawing.Point(131, 64)
        Me.cmdViewBinPreference.Name = "cmdViewBinPreference"
        Me.cmdViewBinPreference.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewBinPreference.TabIndex = 21
        Me.cmdViewBinPreference.Text = "View"
        Me.cmdViewBinPreference.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(18, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 23)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Text Filter"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSearchBinPreference
        '
        Me.txtSearchBinPreference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchBinPreference.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchBinPreference.Location = New System.Drawing.Point(106, 25)
        Me.txtSearchBinPreference.Name = "txtSearchBinPreference"
        Me.txtSearchBinPreference.Size = New System.Drawing.Size(173, 20)
        Me.txtSearchBinPreference.TabIndex = 20
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboRackPosition)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txtAddRackLevel)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtAddMaxUprightWeight)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtAddMaxBarWeight)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtAddPartnerBin)
        Me.GroupBox3.Controls.Add(Me.cmdClearAddRacks)
        Me.GroupBox3.Controls.Add(Me.cmdAddRacks)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtAddLastNumber)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtAddFirstNumber)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtAddRackPrefix)
        Me.GroupBox3.Location = New System.Drawing.Point(29, 204)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(300, 375)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Add Racks (Single / Range)"
        '
        'cboRackPosition
        '
        Me.cboRackPosition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRackPosition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRackPosition.FormattingEnabled = True
        Me.cboRackPosition.Items.AddRange(New Object() {"FLOOR", "NONFLOOR", "UNAVAILABLE"})
        Me.cboRackPosition.Location = New System.Drawing.Point(131, 255)
        Me.cboRackPosition.Name = "cboRackPosition"
        Me.cboRackPosition.Size = New System.Drawing.Size(148, 21)
        Me.cboRackPosition.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(18, 293)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 23)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Rack Level"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAddRackLevel
        '
        Me.txtAddRackLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddRackLevel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddRackLevel.Location = New System.Drawing.Point(131, 293)
        Me.txtAddRackLevel.Name = "txtAddRackLevel"
        Me.txtAddRackLevel.Size = New System.Drawing.Size(148, 20)
        Me.txtAddRackLevel.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(18, 255)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 23)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Rack Position"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(18, 218)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 23)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Max Upright Wt."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAddMaxUprightWeight
        '
        Me.txtAddMaxUprightWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddMaxUprightWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddMaxUprightWeight.Location = New System.Drawing.Point(131, 218)
        Me.txtAddMaxUprightWeight.Name = "txtAddMaxUprightWeight"
        Me.txtAddMaxUprightWeight.Size = New System.Drawing.Size(148, 20)
        Me.txtAddMaxUprightWeight.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(18, 181)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 23)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Max Bar Weight"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAddMaxBarWeight
        '
        Me.txtAddMaxBarWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddMaxBarWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddMaxBarWeight.Location = New System.Drawing.Point(131, 181)
        Me.txtAddMaxBarWeight.Name = "txtAddMaxBarWeight"
        Me.txtAddMaxBarWeight.Size = New System.Drawing.Size(148, 20)
        Me.txtAddMaxBarWeight.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(18, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 23)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Partner Bin #"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAddPartnerBin
        '
        Me.txtAddPartnerBin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddPartnerBin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddPartnerBin.Location = New System.Drawing.Point(131, 144)
        Me.txtAddPartnerBin.Name = "txtAddPartnerBin"
        Me.txtAddPartnerBin.Size = New System.Drawing.Size(148, 20)
        Me.txtAddPartnerBin.TabIndex = 9
        '
        'cmdClearAddRacks
        '
        Me.cmdClearAddRacks.Location = New System.Drawing.Point(208, 330)
        Me.cmdClearAddRacks.Name = "cmdClearAddRacks"
        Me.cmdClearAddRacks.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearAddRacks.TabIndex = 15
        Me.cmdClearAddRacks.Text = "Clear"
        Me.cmdClearAddRacks.UseVisualStyleBackColor = True
        '
        'cmdAddRacks
        '
        Me.cmdAddRacks.Location = New System.Drawing.Point(131, 330)
        Me.cmdAddRacks.Name = "cmdAddRacks"
        Me.cmdAddRacks.Size = New System.Drawing.Size(71, 30)
        Me.cmdAddRacks.TabIndex = 14
        Me.cmdAddRacks.Text = "Add"
        Me.cmdAddRacks.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(18, 107)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(132, 23)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Last # (Multiple Racks)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAddLastNumber
        '
        Me.txtAddLastNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddLastNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddLastNumber.Location = New System.Drawing.Point(156, 107)
        Me.txtAddLastNumber.Name = "txtAddLastNumber"
        Me.txtAddLastNumber.Size = New System.Drawing.Size(123, 20)
        Me.txtAddLastNumber.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(18, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 23)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "First # (Single Rack)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAddFirstNumber
        '
        Me.txtAddFirstNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddFirstNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddFirstNumber.Location = New System.Drawing.Point(156, 70)
        Me.txtAddFirstNumber.Name = "txtAddFirstNumber"
        Me.txtAddFirstNumber.Size = New System.Drawing.Size(123, 20)
        Me.txtAddFirstNumber.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(18, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 23)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Rack Prefix (2 Characters)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAddRackPrefix
        '
        Me.txtAddRackPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddRackPrefix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddRackPrefix.Location = New System.Drawing.Point(156, 33)
        Me.txtAddRackPrefix.Name = "txtAddRackPrefix"
        Me.txtAddRackPrefix.Size = New System.Drawing.Size(123, 20)
        Me.txtAddRackPrefix.TabIndex = 6
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdDeleteRack)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.txtDeleteRack)
        Me.GroupBox4.Location = New System.Drawing.Point(29, 585)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(300, 110)
        Me.GroupBox4.TabIndex = 16
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Delete Rack"
        '
        'cmdDeleteRack
        '
        Me.cmdDeleteRack.Location = New System.Drawing.Point(208, 64)
        Me.cmdDeleteRack.Name = "cmdDeleteRack"
        Me.cmdDeleteRack.Size = New System.Drawing.Size(71, 30)
        Me.cmdDeleteRack.TabIndex = 18
        Me.cmdDeleteRack.Text = "Delete"
        Me.cmdDeleteRack.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 23)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Rack Number"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDeleteRack
        '
        Me.txtDeleteRack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDeleteRack.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDeleteRack.Location = New System.Drawing.Point(106, 25)
        Me.txtDeleteRack.Name = "txtDeleteRack"
        Me.txtDeleteRack.Size = New System.Drawing.Size(173, 20)
        Me.txtDeleteRack.TabIndex = 17
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 5
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvBinNumbers
        '
        Me.dgvBinNumbers.AllowUserToAddRows = False
        Me.dgvBinNumbers.AllowUserToDeleteRows = False
        Me.dgvBinNumbers.AutoGenerateColumns = False
        Me.dgvBinNumbers.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvBinNumbers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvBinNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBinNumbers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BinNumberColumn, Me.PartnerBinNumberColumn, Me.MaxBarWeightColumn, Me.MaxUprightWeightColumn, Me.RackPositionColumn, Me.RackLevelColumn, Me.DivisionIDColumn})
        Me.dgvBinNumbers.DataSource = Me.BinNumberBindingSource
        Me.dgvBinNumbers.GridColor = System.Drawing.Color.Blue
        Me.dgvBinNumbers.Location = New System.Drawing.Point(344, 48)
        Me.dgvBinNumbers.Name = "dgvBinNumbers"
        Me.dgvBinNumbers.Size = New System.Drawing.Size(786, 701)
        Me.dgvBinNumbers.TabIndex = 6
        '
        'BinNumberColumn
        '
        Me.BinNumberColumn.DataPropertyName = "BinNumber"
        Me.BinNumberColumn.HeaderText = "Bin Number"
        Me.BinNumberColumn.Name = "BinNumberColumn"
        Me.BinNumberColumn.ReadOnly = True
        '
        'PartnerBinNumberColumn
        '
        Me.PartnerBinNumberColumn.DataPropertyName = "PartnerBinNumber"
        Me.PartnerBinNumberColumn.HeaderText = "Partner Bin #"
        Me.PartnerBinNumberColumn.Name = "PartnerBinNumberColumn"
        '
        'MaxBarWeightColumn
        '
        Me.MaxBarWeightColumn.DataPropertyName = "MaxBarWeight"
        Me.MaxBarWeightColumn.HeaderText = "Max Bar Weight"
        Me.MaxBarWeightColumn.Name = "MaxBarWeightColumn"
        '
        'MaxUprightWeightColumn
        '
        Me.MaxUprightWeightColumn.DataPropertyName = "MaxUprightWeight"
        Me.MaxUprightWeightColumn.HeaderText = "Max Upright Weight"
        Me.MaxUprightWeightColumn.Name = "MaxUprightWeightColumn"
        '
        'RackPositionColumn
        '
        Me.RackPositionColumn.DataPropertyName = "RackPosition"
        Me.RackPositionColumn.HeaderText = "Rack Position"
        Me.RackPositionColumn.Items.AddRange(New Object() {"FLOOR", "NONFLOOR", "UNAVAILABLE"})
        Me.RackPositionColumn.Name = "RackPositionColumn"
        Me.RackPositionColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RackPositionColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.RackPositionColumn.Width = 130
        '
        'RackLevelColumn
        '
        Me.RackLevelColumn.DataPropertyName = "RackLevel"
        Me.RackLevelColumn.HeaderText = "Rack Level"
        Me.RackLevelColumn.Name = "RackLevelColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        '
        'BinNumberBindingSource
        '
        Me.BinNumberBindingSource.DataMember = "BinNumber"
        Me.BinNumberBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'BinNumberTableAdapter
        '
        Me.BinNumberTableAdapter.ClearBeforeFill = True
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(341, 752)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(379, 59)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "To de-activate a rack (close), select ""UNAVAILABLE"" for it's rack position."
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvBinPreferences
        '
        Me.dgvBinPreferences.AllowUserToAddRows = False
        Me.dgvBinPreferences.AllowUserToDeleteRows = False
        Me.dgvBinPreferences.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBinPreferences.AutoGenerateColumns = False
        Me.dgvBinPreferences.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvBinPreferences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBinPreferences.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PreferenceKeyColumn, Me.RowNameColumn, Me.Pref01Column, Me.Pref02Column, Me.Pref03Column, Me.Pref04Column, Me.Pref05Column, Me.Pref06Column, Me.Pref07Column, Me.Pref08Column, Me.Pref09Column, Me.Pref10Column, Me.Pref11Column, Me.Pref12Column, Me.Pref13Column, Me.Pref14Column, Me.Pref15Column, Me.Pref16Column, Me.Pref17Column, Me.Pref18Column, Me.DivisionIDColumn2})
        Me.dgvBinPreferences.DataSource = Me.BinPrefLocationBindingSource
        Me.dgvBinPreferences.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvBinPreferences.Location = New System.Drawing.Point(344, 48)
        Me.dgvBinPreferences.Name = "dgvBinPreferences"
        Me.dgvBinPreferences.Size = New System.Drawing.Size(786, 701)
        Me.dgvBinPreferences.TabIndex = 21
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
        Me.RowNameColumn.HeaderText = "Row Name"
        Me.RowNameColumn.Name = "RowNameColumn"
        '
        'Pref01Column
        '
        Me.Pref01Column.DataPropertyName = "Pref01"
        Me.Pref01Column.HeaderText = "Pref 01"
        Me.Pref01Column.Name = "Pref01Column"
        '
        'Pref02Column
        '
        Me.Pref02Column.DataPropertyName = "Pref02"
        Me.Pref02Column.HeaderText = "Pref 02"
        Me.Pref02Column.Name = "Pref02Column"
        '
        'Pref03Column
        '
        Me.Pref03Column.DataPropertyName = "Pref03"
        Me.Pref03Column.HeaderText = "Pref 03"
        Me.Pref03Column.Name = "Pref03Column"
        '
        'Pref04Column
        '
        Me.Pref04Column.DataPropertyName = "Pref04"
        Me.Pref04Column.HeaderText = "Pref 04"
        Me.Pref04Column.Name = "Pref04Column"
        '
        'Pref05Column
        '
        Me.Pref05Column.DataPropertyName = "Pref05"
        Me.Pref05Column.HeaderText = "Pref 05"
        Me.Pref05Column.Name = "Pref05Column"
        '
        'Pref06Column
        '
        Me.Pref06Column.DataPropertyName = "Pref06"
        Me.Pref06Column.HeaderText = "Pref 06"
        Me.Pref06Column.Name = "Pref06Column"
        '
        'Pref07Column
        '
        Me.Pref07Column.DataPropertyName = "Pref07"
        Me.Pref07Column.HeaderText = "Pref 07"
        Me.Pref07Column.Name = "Pref07Column"
        '
        'Pref08Column
        '
        Me.Pref08Column.DataPropertyName = "Pref08"
        Me.Pref08Column.HeaderText = "Pref 08"
        Me.Pref08Column.Name = "Pref08Column"
        '
        'Pref09Column
        '
        Me.Pref09Column.DataPropertyName = "Pref09"
        Me.Pref09Column.HeaderText = "Pref 09"
        Me.Pref09Column.Name = "Pref09Column"
        '
        'Pref10Column
        '
        Me.Pref10Column.DataPropertyName = "Pref10"
        Me.Pref10Column.HeaderText = "Pref 10"
        Me.Pref10Column.Name = "Pref10Column"
        '
        'Pref11Column
        '
        Me.Pref11Column.DataPropertyName = "Pref11"
        Me.Pref11Column.HeaderText = "Pref 11"
        Me.Pref11Column.Name = "Pref11Column"
        '
        'Pref12Column
        '
        Me.Pref12Column.DataPropertyName = "Pref12"
        Me.Pref12Column.HeaderText = "Pref 12"
        Me.Pref12Column.Name = "Pref12Column"
        '
        'Pref13Column
        '
        Me.Pref13Column.DataPropertyName = "Pref13"
        Me.Pref13Column.HeaderText = "Pref 13"
        Me.Pref13Column.Name = "Pref13Column"
        '
        'Pref14Column
        '
        Me.Pref14Column.DataPropertyName = "Pref14"
        Me.Pref14Column.HeaderText = "Pref 14"
        Me.Pref14Column.Name = "Pref14Column"
        '
        'Pref15Column
        '
        Me.Pref15Column.DataPropertyName = "Pref15"
        Me.Pref15Column.HeaderText = "Pref 15"
        Me.Pref15Column.Name = "Pref15Column"
        '
        'Pref16Column
        '
        Me.Pref16Column.DataPropertyName = "Pref16"
        Me.Pref16Column.HeaderText = "Pref 16"
        Me.Pref16Column.Name = "Pref16Column"
        '
        'Pref17Column
        '
        Me.Pref17Column.DataPropertyName = "Pref17"
        Me.Pref17Column.HeaderText = "Pref 17"
        Me.Pref17Column.Name = "Pref17Column"
        '
        'Pref18Column
        '
        Me.Pref18Column.DataPropertyName = "Pref18"
        Me.Pref18Column.HeaderText = "Pref 18"
        Me.Pref18Column.Name = "Pref18Column"
        '
        'DivisionIDColumn2
        '
        Me.DivisionIDColumn2.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn2.HeaderText = "Division"
        Me.DivisionIDColumn2.Name = "DivisionIDColumn2"
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
        'RackingUtility
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.dgvBinNumbers)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvBinPreferences)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "RackingUtility"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation View / Edit Racking"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgvBinNumbers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BinNumberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBinPreferences, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BinPrefLocationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdViewRacks As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClearBinReference As System.Windows.Forms.Button
    Friend WithEvents cmdViewBinPreference As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSearchBinPreference As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClearAddRacks As System.Windows.Forms.Button
    Friend WithEvents cmdAddRacks As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAddLastNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAddFirstNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAddRackPrefix As System.Windows.Forms.TextBox
    Friend WithEvents cmdDeleteRack As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDeleteRack As System.Windows.Forms.TextBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtAddRackLevel As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAddMaxUprightWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAddMaxBarWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAddPartnerBin As System.Windows.Forms.TextBox
    Friend WithEvents cboRackPosition As System.Windows.Forms.ComboBox
    Friend WithEvents dgvBinNumbers As System.Windows.Forms.DataGridView
    Friend WithEvents BinNumberBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BinNumberTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BinNumberTableAdapter
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents BinNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartnerBinNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaxBarWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaxUprightWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackPositionColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents RackLevelColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvBinPreferences As System.Windows.Forms.DataGridView
    Friend WithEvents BinPrefLocationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BinPrefLocationTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BinPrefLocationTableAdapter
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
    Friend WithEvents DivisionIDColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
