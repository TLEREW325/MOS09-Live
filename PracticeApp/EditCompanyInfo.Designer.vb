<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditCompanyInfo
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtCompanyName = New System.Windows.Forms.TextBox
        Me.txtCompanyDescription = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboState = New System.Windows.Forms.ComboBox
        Me.StateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtCountry = New System.Windows.Forms.TextBox
        Me.txtZip = New System.Windows.Forms.TextBox
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.txtAddress2 = New System.Windows.Forms.TextBox
        Me.txtAddress1 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtPhone = New System.Windows.Forms.TextBox
        Me.txtTollFree = New System.Windows.Forms.TextBox
        Me.txtFax = New System.Windows.Forms.TextBox
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtRoutingNumber = New System.Windows.Forms.TextBox
        Me.txtAccountNumber = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.StateTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
        Me.cmdOpenDatabaseUtilities = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.gpxSecurity = New System.Windows.Forms.GroupBox
        Me.cmdSecurityManagement = New System.Windows.Forms.Button
        Me.gpxCanadianData = New System.Windows.Forms.GroupBox
        Me.txtInstitution = New System.Windows.Forms.TextBox
        Me.txtTransitNumber = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtCanadianAccount = New System.Windows.Forms.TextBox
        Me.txtPrefix = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.cboDivisionClass = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtEIN = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.gpxSecurity.SuspendLayout()
        Me.gpxCanadianData.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtEIN)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtCompanyName)
        Me.GroupBox1.Controls.Add(Me.txtCompanyDescription)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(309, 244)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Company Name"
        '
        'txtCompanyName
        '
        Me.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCompanyName.Location = New System.Drawing.Point(104, 70)
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.Size = New System.Drawing.Size(190, 20)
        Me.txtCompanyName.TabIndex = 2
        '
        'txtCompanyDescription
        '
        Me.txtCompanyDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCompanyDescription.Location = New System.Drawing.Point(26, 122)
        Me.txtCompanyDescription.Multiline = True
        Me.txtCompanyDescription.Name = "txtCompanyDescription"
        Me.txtCompanyDescription.Size = New System.Drawing.Size(268, 72)
        Me.txtCompanyDescription.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Name"
        '
        'cboDivisionID
        '
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(104, 33)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(190, 21)
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
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Division ID"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearFormToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ClearFormToolStripMenuItem
        '
        Me.ClearFormToolStripMenuItem.Name = "ClearFormToolStripMenuItem"
        Me.ClearFormToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.ClearFormToolStripMenuItem.Text = "Clear Form"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboState)
        Me.GroupBox2.Controls.Add(Me.txtCountry)
        Me.GroupBox2.Controls.Add(Me.txtZip)
        Me.GroupBox2.Controls.Add(Me.txtCity)
        Me.GroupBox2.Controls.Add(Me.txtAddress2)
        Me.GroupBox2.Controls.Add(Me.txtAddress1)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 291)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(309, 520)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Address Info"
        '
        'cboState
        '
        Me.cboState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboState.DataSource = Me.StateTableBindingSource
        Me.cboState.FormattingEnabled = True
        Me.cboState.Location = New System.Drawing.Point(80, 408)
        Me.cboState.Name = "cboState"
        Me.cboState.Size = New System.Drawing.Size(143, 21)
        Me.cboState.TabIndex = 9
        '
        'StateTableBindingSource
        '
        Me.StateTableBindingSource.DataMember = "StateTable"
        Me.StateTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtCountry
        '
        Me.txtCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCountry.Location = New System.Drawing.Point(80, 475)
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.Size = New System.Drawing.Size(212, 20)
        Me.txtCountry.TabIndex = 11
        '
        'txtZip
        '
        Me.txtZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtZip.Location = New System.Drawing.Point(80, 442)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(212, 20)
        Me.txtZip.TabIndex = 10
        '
        'txtCity
        '
        Me.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCity.Location = New System.Drawing.Point(80, 375)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(212, 20)
        Me.txtCity.TabIndex = 8
        '
        'txtAddress2
        '
        Me.txtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress2.Location = New System.Drawing.Point(24, 225)
        Me.txtAddress2.Multiline = True
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(268, 100)
        Me.txtAddress2.TabIndex = 7
        '
        'txtAddress1
        '
        Me.txtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress1.Location = New System.Drawing.Point(24, 52)
        Me.txtAddress1.Multiline = True
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(268, 100)
        Me.txtAddress1.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(21, 482)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Country"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 449)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Zip Code"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 416)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "State"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 382)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "City"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 206)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Address 2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Address 1"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtPhone)
        Me.GroupBox3.Controls.Add(Me.txtTollFree)
        Me.GroupBox3.Controls.Add(Me.txtFax)
        Me.GroupBox3.Controls.Add(Me.txtEmail)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Location = New System.Drawing.Point(356, 41)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(328, 287)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Company Contact Info"
        '
        'txtPhone
        '
        Me.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhone.Location = New System.Drawing.Point(112, 30)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(191, 20)
        Me.txtPhone.TabIndex = 13
        '
        'txtTollFree
        '
        Me.txtTollFree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTollFree.Location = New System.Drawing.Point(112, 66)
        Me.txtTollFree.Name = "txtTollFree"
        Me.txtTollFree.Size = New System.Drawing.Size(192, 20)
        Me.txtTollFree.TabIndex = 14
        '
        'txtFax
        '
        Me.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFax.Location = New System.Drawing.Point(112, 105)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(191, 20)
        Me.txtFax.TabIndex = 15
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Location = New System.Drawing.Point(17, 157)
        Me.txtEmail.Multiline = True
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(286, 105)
        Me.txtEmail.TabIndex = 16
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(14, 141)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 13)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Email"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 105)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 13)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Fax"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 69)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Toll Free Phone #"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Phone #"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtRoutingNumber)
        Me.GroupBox4.Controls.Add(Me.txtAccountNumber)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Location = New System.Drawing.Point(356, 353)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(327, 113)
        Me.GroupBox4.TabIndex = 17
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Banking Info"
        '
        'txtRoutingNumber
        '
        Me.txtRoutingNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRoutingNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRoutingNumber.Location = New System.Drawing.Point(112, 74)
        Me.txtRoutingNumber.Name = "txtRoutingNumber"
        Me.txtRoutingNumber.Size = New System.Drawing.Size(190, 20)
        Me.txtRoutingNumber.TabIndex = 19
        '
        'txtAccountNumber
        '
        Me.txtAccountNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccountNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAccountNumber.Location = New System.Drawing.Point(112, 33)
        Me.txtAccountNumber.Name = "txtAccountNumber"
        Me.txtAccountNumber.Size = New System.Drawing.Size(190, 20)
        Me.txtAccountNumber.TabIndex = 18
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(14, 77)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 13)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Routing Number"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(14, 36)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(87, 13)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "Account Number"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(982, 766)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 28
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(1059, 766)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 29
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Location = New System.Drawing.Point(905, 766)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 27
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'StateTableTableAdapter
        '
        Me.StateTableTableAdapter.ClearBeforeFill = True
        '
        'cmdOpenDatabaseUtilities
        '
        Me.cmdOpenDatabaseUtilities.Enabled = False
        Me.cmdOpenDatabaseUtilities.Location = New System.Drawing.Point(236, 30)
        Me.cmdOpenDatabaseUtilities.Name = "cmdOpenDatabaseUtilities"
        Me.cmdOpenDatabaseUtilities.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenDatabaseUtilities.TabIndex = 28
        Me.cmdOpenDatabaseUtilities.Text = "Database Utilities"
        Me.cmdOpenDatabaseUtilities.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmdOpenDatabaseUtilities)
        Me.GroupBox5.Location = New System.Drawing.Point(801, 41)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(329, 86)
        Me.GroupBox5.TabIndex = 27
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Open Database Utilities"
        '
        'gpxSecurity
        '
        Me.gpxSecurity.Controls.Add(Me.cmdSecurityManagement)
        Me.gpxSecurity.Location = New System.Drawing.Point(801, 133)
        Me.gpxSecurity.Name = "gpxSecurity"
        Me.gpxSecurity.Size = New System.Drawing.Size(329, 86)
        Me.gpxSecurity.TabIndex = 29
        Me.gpxSecurity.TabStop = False
        Me.gpxSecurity.Text = "Open Security Management"
        Me.gpxSecurity.Visible = False
        '
        'cmdSecurityManagement
        '
        Me.cmdSecurityManagement.Location = New System.Drawing.Point(236, 30)
        Me.cmdSecurityManagement.Name = "cmdSecurityManagement"
        Me.cmdSecurityManagement.Size = New System.Drawing.Size(71, 40)
        Me.cmdSecurityManagement.TabIndex = 30
        Me.cmdSecurityManagement.Text = "Security Mgnt"
        Me.cmdSecurityManagement.UseVisualStyleBackColor = True
        '
        'gpxCanadianData
        '
        Me.gpxCanadianData.Controls.Add(Me.txtInstitution)
        Me.gpxCanadianData.Controls.Add(Me.txtTransitNumber)
        Me.gpxCanadianData.Controls.Add(Me.Label18)
        Me.gpxCanadianData.Controls.Add(Me.Label19)
        Me.gpxCanadianData.Controls.Add(Me.txtCanadianAccount)
        Me.gpxCanadianData.Controls.Add(Me.txtPrefix)
        Me.gpxCanadianData.Controls.Add(Me.Label14)
        Me.gpxCanadianData.Controls.Add(Me.Label17)
        Me.gpxCanadianData.Location = New System.Drawing.Point(356, 491)
        Me.gpxCanadianData.Name = "gpxCanadianData"
        Me.gpxCanadianData.Size = New System.Drawing.Size(327, 204)
        Me.gpxCanadianData.TabIndex = 20
        Me.gpxCanadianData.TabStop = False
        Me.gpxCanadianData.Text = "Canadian Banking Data"
        '
        'txtInstitution
        '
        Me.txtInstitution.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInstitution.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInstitution.Location = New System.Drawing.Point(113, 153)
        Me.txtInstitution.Name = "txtInstitution"
        Me.txtInstitution.Size = New System.Drawing.Size(190, 20)
        Me.txtInstitution.TabIndex = 24
        '
        'txtTransitNumber
        '
        Me.txtTransitNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransitNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransitNumber.Location = New System.Drawing.Point(113, 112)
        Me.txtTransitNumber.Name = "txtTransitNumber"
        Me.txtTransitNumber.Size = New System.Drawing.Size(190, 20)
        Me.txtTransitNumber.TabIndex = 23
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(12, 153)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(95, 20)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "Institution"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(12, 110)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(95, 20)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "Transit #"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCanadianAccount
        '
        Me.txtCanadianAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCanadianAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCanadianAccount.Location = New System.Drawing.Point(113, 73)
        Me.txtCanadianAccount.Name = "txtCanadianAccount"
        Me.txtCanadianAccount.Size = New System.Drawing.Size(190, 20)
        Me.txtCanadianAccount.TabIndex = 22
        '
        'txtPrefix
        '
        Me.txtPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrefix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrefix.Location = New System.Drawing.Point(113, 32)
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Size = New System.Drawing.Size(190, 20)
        Me.txtPrefix.TabIndex = 21
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(12, 73)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(95, 20)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Canadian Acct #"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(12, 30)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(95, 20)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "Acct # Prefix"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cboDivisionClass)
        Me.GroupBox6.Controls.Add(Me.Label20)
        Me.GroupBox6.Location = New System.Drawing.Point(356, 720)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(326, 90)
        Me.GroupBox6.TabIndex = 25
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Division Class"
        '
        'cboDivisionClass
        '
        Me.cboDivisionClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionClass.FormattingEnabled = True
        Me.cboDivisionClass.Items.AddRange(New Object() {"AMERICAN", "CANADIAN"})
        Me.cboDivisionClass.Location = New System.Drawing.Point(113, 34)
        Me.cboDivisionClass.Name = "cboDivisionClass"
        Me.cboDivisionClass.Size = New System.Drawing.Size(189, 21)
        Me.cboDivisionClass.TabIndex = 26
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(18, 35)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(95, 20)
        Me.Label20.TabIndex = 23
        Me.Label20.Text = "Class"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEIN
        '
        Me.txtEIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEIN.Location = New System.Drawing.Point(62, 210)
        Me.txtEIN.Name = "txtEIN"
        Me.txtEIN.Size = New System.Drawing.Size(230, 20)
        Me.txtEIN.TabIndex = 4
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(21, 210)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(75, 20)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "EIN"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EditCompanyInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.gpxCanadianData)
        Me.Controls.Add(Me.gpxSecurity)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "EditCompanyInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Company Data"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.gpxSecurity.ResumeLayout(False)
        Me.gpxCanadianData.ResumeLayout(False)
        Me.gpxCanadianData.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents txtCompanyDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCountry As System.Windows.Forms.TextBox
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtTollFree As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRoutingNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboState As System.Windows.Forms.ComboBox
    Friend WithEvents StateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StateTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
    Friend WithEvents ClearFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdOpenDatabaseUtilities As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents gpxSecurity As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSecurityManagement As System.Windows.Forms.Button
    Friend WithEvents gpxCanadianData As System.Windows.Forms.GroupBox
    Friend WithEvents txtCanadianAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtPrefix As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtInstitution As System.Windows.Forms.TextBox
    Friend WithEvents txtTransitNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDivisionClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtEIN As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
End Class
