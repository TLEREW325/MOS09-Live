<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CertificationSpec
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
        Me.cboCertType = New System.Windows.Forms.ComboBox
        Me.CertificationTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboCertCode = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtLongDescription = New System.Windows.Forms.TextBox
        Me.txtMaterialSpec = New System.Windows.Forms.TextBox
        Me.txtBottomLineSpec = New System.Windows.Forms.TextBox
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.CertificationTypeTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CertificationTypeTableAdapter
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtManufacturingSpec = New System.Windows.Forms.TextBox
        Me.txtMinYield = New System.Windows.Forms.TextBox
        Me.txtMinTensile = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtMaxTensile = New System.Windows.Forms.TextBox
        Me.txtMaxYield = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtElongation = New System.Windows.Forms.TextBox
        Me.txtReduction = New System.Windows.Forms.TextBox
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.CertificationTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
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
        Me.GroupBox1.Controls.Add(Me.cboCertType)
        Me.GroupBox1.Controls.Add(Me.cboCertCode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(397, 91)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Certification Specifications"
        '
        'cboCertType
        '
        Me.cboCertType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCertType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCertType.DataSource = Me.CertificationTypeBindingSource
        Me.cboCertType.DisplayMember = "CertificationType"
        Me.cboCertType.FormattingEnabled = True
        Me.cboCertType.Location = New System.Drawing.Point(19, 58)
        Me.cboCertType.Name = "cboCertType"
        Me.cboCertType.Size = New System.Drawing.Size(363, 21)
        Me.cboCertType.TabIndex = 2
        '
        'CertificationTypeBindingSource
        '
        Me.CertificationTypeBindingSource.DataMember = "CertificationType"
        Me.CertificationTypeBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboCertCode
        '
        Me.cboCertCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCertCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCertCode.DataSource = Me.CertificationTypeBindingSource
        Me.cboCertCode.DisplayMember = "CertificationCode"
        Me.cboCertCode.FormattingEnabled = True
        Me.cboCertCode.Location = New System.Drawing.Point(122, 29)
        Me.cboCertCode.Name = "cboCertCode"
        Me.cboCertCode.Size = New System.Drawing.Size(260, 21)
        Me.cboCertCode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Certification Type"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLongDescription
        '
        Me.txtLongDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLongDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLongDescription.Location = New System.Drawing.Point(29, 370)
        Me.txtLongDescription.MaxLength = 300
        Me.txtLongDescription.Multiline = True
        Me.txtLongDescription.Name = "txtLongDescription"
        Me.txtLongDescription.Size = New System.Drawing.Size(570, 90)
        Me.txtLongDescription.TabIndex = 10
        '
        'txtMaterialSpec
        '
        Me.txtMaterialSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaterialSpec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaterialSpec.Location = New System.Drawing.Point(29, 489)
        Me.txtMaterialSpec.MaxLength = 300
        Me.txtMaterialSpec.Multiline = True
        Me.txtMaterialSpec.Name = "txtMaterialSpec"
        Me.txtMaterialSpec.Size = New System.Drawing.Size(570, 90)
        Me.txtMaterialSpec.TabIndex = 11
        '
        'txtBottomLineSpec
        '
        Me.txtBottomLineSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBottomLineSpec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBottomLineSpec.Location = New System.Drawing.Point(29, 608)
        Me.txtBottomLineSpec.MaxLength = 300
        Me.txtBottomLineSpec.Multiline = True
        Me.txtBottomLineSpec.Name = "txtBottomLineSpec"
        Me.txtBottomLineSpec.Size = New System.Drawing.Size(570, 90)
        Me.txtBottomLineSpec.TabIndex = 12
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(827, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 15
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(904, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 16
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(981, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 17
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1058, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 18
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 344)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 23)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Cert. Description"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 463)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 23)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Material Spec."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 582)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 23)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Footer Spec."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(163, 344)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 23)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "(300 characters MAX)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(163, 466)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(135, 23)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "(300 characters MAX)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(163, 582)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(135, 23)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "(300 characters MAX)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.Label35)
        Me.GroupBox2.Controls.Add(Me.Label36)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(626, 27)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(496, 720)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cert. Types"
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(20, 567)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(456, 23)
        Me.Label34.TabIndex = 52
        Me.Label34.Text = "20 -- ASME SA-675-60/ASTM A-675 GRADE 60"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(20, 540)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(456, 23)
        Me.Label35.TabIndex = 51
        Me.Label35.Text = "19 -- ASTM F1554-18"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label36
        '
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(20, 513)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(456, 23)
        Me.Label36.TabIndex = 50
        Me.Label36.Text = "18 -- ASTM F1554-18"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(20, 486)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(456, 23)
        Me.Label31.TabIndex = 49
        Me.Label31.Text = "17 -- AWS D1.1-2020 ASTM-A706"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(20, 459)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(456, 23)
        Me.Label30.TabIndex = 48
        Me.Label30.Text = "16 -- AWS D1.6-2017 ASTM-A493 (Headed Studs - USA ONLY)"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(20, 432)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(456, 23)
        Me.Label29.TabIndex = 47
        Me.Label29.Text = "15 -- AWS D1.6-2017 ASTM-A493 (Threaded Studs - USA ONLY)"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(20, 405)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(456, 23)
        Me.Label28.TabIndex = 46
        Me.Label28.Text = "14 -- AWS D1.2/D1.2M-2014"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(20, 378)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(456, 23)
        Me.Label21.TabIndex = 44
        Me.Label21.Text = "13 -- AWS D1.1-2010 SA307"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(20, 324)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(456, 23)
        Me.Label20.TabIndex = 45
        Me.Label20.Text = "11 -- ASTM-A307 / ASTM-A36 (DE's)"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(20, 216)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(456, 23)
        Me.Label19.TabIndex = 44
        Me.Label19.Text = "7 -- AWS D1.6-2017 ASTM-A493 (Threaded Studs)"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(20, 351)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(456, 23)
        Me.Label18.TabIndex = 43
        Me.Label18.Text = "12 -- ST 37-3K European Standard"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(20, 270)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(456, 23)
        Me.Label17.TabIndex = 42
        Me.Label17.Text = "9 -- DIN 50049-2.2 / EN 10204-2.2"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(20, 297)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(456, 23)
        Me.Label16.TabIndex = 41
        Me.Label16.Text = "10 -- Not Available"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(20, 162)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(456, 23)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "5 -- British Standard CP117 (5400)"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(20, 189)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(456, 23)
        Me.Label14.TabIndex = 39
        Me.Label14.Text = "6 -- Threaded Studs"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(20, 243)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(456, 23)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "8 -- AWS D1.6-2017 ASTM-A493 (Headed Studs)"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(20, 135)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(456, 23)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "4 -- British Standard BS5950"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(20, 54)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(456, 23)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "1 -- AWS D1.1-2020 ASTM-A108"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(20, 81)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(456, 23)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "2 -- AWS D1.1-2020 ASTM-A496"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(20, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(456, 23)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "3 -- AWS D1.6-2017 ASTM-A276 (Stainless Bar)"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(20, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(456, 23)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "0 -- No requirement"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CertificationTypeTableAdapter
        '
        Me.CertificationTypeTableAdapter.ClearBeforeFill = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(626, 771)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 14
        Me.cmdClearAll.Text = "Clear"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(168, 701)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(135, 23)
        Me.Label22.TabIndex = 41
        Me.Label22.Text = "(300 characters MAX)"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(29, 701)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(134, 23)
        Me.Label23.TabIndex = 40
        Me.Label23.Text = "Manufacturing Spec."
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtManufacturingSpec
        '
        Me.txtManufacturingSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtManufacturingSpec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtManufacturingSpec.Location = New System.Drawing.Point(29, 727)
        Me.txtManufacturingSpec.MaxLength = 300
        Me.txtManufacturingSpec.Multiline = True
        Me.txtManufacturingSpec.Name = "txtManufacturingSpec"
        Me.txtManufacturingSpec.Size = New System.Drawing.Size(570, 90)
        Me.txtManufacturingSpec.TabIndex = 13
        '
        'txtMinYield
        '
        Me.txtMinYield.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMinYield.Location = New System.Drawing.Point(237, 19)
        Me.txtMinYield.Name = "txtMinYield"
        Me.txtMinYield.Size = New System.Drawing.Size(145, 20)
        Me.txtMinYield.TabIndex = 4
        Me.txtMinYield.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMinTensile
        '
        Me.txtMinTensile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMinTensile.Location = New System.Drawing.Point(237, 47)
        Me.txtMinTensile.Name = "txtMinTensile"
        Me.txtMinTensile.Size = New System.Drawing.Size(145, 20)
        Me.txtMinTensile.TabIndex = 5
        Me.txtMinTensile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label32)
        Me.GroupBox3.Controls.Add(Me.Label33)
        Me.GroupBox3.Controls.Add(Me.txtMaxTensile)
        Me.GroupBox3.Controls.Add(Me.txtMaxYield)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.txtElongation)
        Me.GroupBox3.Controls.Add(Me.txtReduction)
        Me.GroupBox3.Controls.Add(Me.txtMinTensile)
        Me.GroupBox3.Controls.Add(Me.txtMinYield)
        Me.GroupBox3.Location = New System.Drawing.Point(30, 143)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(397, 193)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Requirements"
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(16, 159)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(100, 23)
        Me.Label32.TabIndex = 11
        Me.Label32.Text = "Max Tensile"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(16, 131)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(100, 23)
        Me.Label33.TabIndex = 10
        Me.Label33.Text = "Max Yield"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMaxTensile
        '
        Me.txtMaxTensile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaxTensile.Location = New System.Drawing.Point(237, 159)
        Me.txtMaxTensile.Name = "txtMaxTensile"
        Me.txtMaxTensile.Size = New System.Drawing.Size(145, 20)
        Me.txtMaxTensile.TabIndex = 9
        Me.txtMaxTensile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMaxYield
        '
        Me.txtMaxYield.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaxYield.Location = New System.Drawing.Point(237, 131)
        Me.txtMaxYield.Name = "txtMaxYield"
        Me.txtMaxYield.Size = New System.Drawing.Size(145, 20)
        Me.txtMaxYield.TabIndex = 8
        Me.txtMaxYield.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(16, 103)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(100, 23)
        Me.Label27.TabIndex = 7
        Me.Label27.Text = "Elongation Percent"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(16, 75)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(100, 23)
        Me.Label26.TabIndex = 6
        Me.Label26.Text = "Reduction Percent"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(16, 47)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(100, 23)
        Me.Label25.TabIndex = 5
        Me.Label25.Text = "Min. Tensile"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(16, 19)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(100, 23)
        Me.Label24.TabIndex = 4
        Me.Label24.Text = "Min. Yield"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtElongation
        '
        Me.txtElongation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtElongation.Location = New System.Drawing.Point(237, 103)
        Me.txtElongation.Name = "txtElongation"
        Me.txtElongation.Size = New System.Drawing.Size(145, 20)
        Me.txtElongation.TabIndex = 7
        Me.txtElongation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReduction
        '
        Me.txtReduction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReduction.Location = New System.Drawing.Point(237, 75)
        Me.txtReduction.Name = "txtReduction"
        Me.txtReduction.Size = New System.Drawing.Size(145, 20)
        Me.txtReduction.TabIndex = 6
        Me.txtReduction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CertificationSpec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtManufacturingSpec)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.txtBottomLineSpec)
        Me.Controls.Add(Me.txtMaterialSpec)
        Me.Controls.Add(Me.txtLongDescription)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "CertificationSpec"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Certification Specifications"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.CertificationTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
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
    Friend WithEvents cboCertType As System.Windows.Forms.ComboBox
    Friend WithEvents cboCertCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLongDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtMaterialSpec As System.Windows.Forms.TextBox
    Friend WithEvents txtBottomLineSpec As System.Windows.Forms.TextBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents CertificationTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CertificationTypeTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CertificationTypeTableAdapter
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtManufacturingSpec As System.Windows.Forms.TextBox
    Friend WithEvents txtMinYield As System.Windows.Forms.TextBox
    Friend WithEvents txtMinTensile As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtElongation As System.Windows.Forms.TextBox
    Friend WithEvents txtReduction As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtMaxTensile As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxYield As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
End Class
