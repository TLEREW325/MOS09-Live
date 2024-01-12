<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateVendorBOL
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
        Me.SaveBOLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintBOLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtFromCountry = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.chkDefaultAsDivision = New System.Windows.Forms.CheckBox
        Me.txtFromPhoneNumber = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtFromZipCode = New System.Windows.Forms.TextBox
        Me.txtFromState = New System.Windows.Forms.TextBox
        Me.txtFromCity = New System.Windows.Forms.TextBox
        Me.txtFromAddress2 = New System.Windows.Forms.TextBox
        Me.txtFromAddress1 = New System.Windows.Forms.TextBox
        Me.txtFromCompanyName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.chkLoadFromVendor = New System.Windows.Forms.CheckBox
        Me.chkLoadFromCustomer = New System.Windows.Forms.CheckBox
        Me.txtToCountry = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.txtToPhoneNumber = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtToZipCode = New System.Windows.Forms.TextBox
        Me.txtToState = New System.Windows.Forms.TextBox
        Me.txtToCity = New System.Windows.Forms.TextBox
        Me.txtToAddress2 = New System.Windows.Forms.TextBox
        Me.txtToAddress1 = New System.Windows.Forms.TextBox
        Me.txtToCompanyName = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Total = New System.Windows.Forms.GroupBox
        Me.txtFOB = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtThirdParty = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboShipMethod = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cboShipVia = New System.Windows.Forms.ComboBox
        Me.ShipMethodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtSpecialInstructions = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdGenerateNewBOL = New System.Windows.Forms.Button
        Me.txtFreightAccountNumber = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.cboBOLNumber = New System.Windows.Forms.ComboBox
        Me.VendorBOLTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label28 = New System.Windows.Forms.Label
        Me.dtpShipDate = New System.Windows.Forms.DateTimePicker
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtPRONUmber = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtFreightQuoteNumber = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtShipmentNumber = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txtTotalOnFloor = New System.Windows.Forms.TextBox
        Me.lblTotalOnFloor = New System.Windows.Forms.Label
        Me.txtDoubleStacks = New System.Windows.Forms.TextBox
        Me.lblDoubleStack = New System.Windows.Forms.Label
        Me.txtMajorUnits = New System.Windows.Forms.TextBox
        Me.lblMajorUnits = New System.Windows.Forms.Label
        Me.txtTotalWeight = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.lblMinorUnits = New System.Windows.Forms.Label
        Me.txtMinorUnits = New System.Windows.Forms.TextBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.cboMajorUnits = New System.Windows.Forms.ComboBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.cboCommodity = New System.Windows.Forms.ComboBox
        Me.txtClassRate = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.cboMinorUnits = New System.Windows.Forms.ComboBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdSaveBOL = New System.Windows.Forms.Button
        Me.cmdPrintBOL = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ShipMethodTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.VendorBOLTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorBOLTableTableAdapter
        Me.DeleteBOLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Total.SuspendLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBOLTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveBOLToolStripMenuItem, Me.DeleteBOLToolStripMenuItem, Me.ClearFormToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveBOLToolStripMenuItem
        '
        Me.SaveBOLToolStripMenuItem.Name = "SaveBOLToolStripMenuItem"
        Me.SaveBOLToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SaveBOLToolStripMenuItem.Text = "Save BOL"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintBOLToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintBOLToolStripMenuItem
        '
        Me.PrintBOLToolStripMenuItem.Name = "PrintBOLToolStripMenuItem"
        Me.PrintBOLToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PrintBOLToolStripMenuItem.Text = "Print BOL"
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
        Me.GroupBox1.Controls.Add(Me.txtFromCountry)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.chkDefaultAsDivision)
        Me.GroupBox1.Controls.Add(Me.txtFromPhoneNumber)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtFromZipCode)
        Me.GroupBox1.Controls.Add(Me.txtFromState)
        Me.GroupBox1.Controls.Add(Me.txtFromCity)
        Me.GroupBox1.Controls.Add(Me.txtFromAddress2)
        Me.GroupBox1.Controls.Add(Me.txtFromAddress1)
        Me.GroupBox1.Controls.Add(Me.txtFromCompanyName)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(365, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(410, 362)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ship From :"
        '
        'txtFromCountry
        '
        Me.txtFromCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFromCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFromCountry.Location = New System.Drawing.Point(305, 332)
        Me.txtFromCountry.Name = "txtFromCountry"
        Me.txtFromCountry.Size = New System.Drawing.Size(90, 20)
        Me.txtFromCountry.TabIndex = 30
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(242, 331)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(69, 23)
        Me.Label30.TabIndex = 30
        Me.Label30.Text = "Country:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDefaultAsDivision
        '
        Me.chkDefaultAsDivision.AutoSize = True
        Me.chkDefaultAsDivision.Checked = True
        Me.chkDefaultAsDivision.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDefaultAsDivision.Location = New System.Drawing.Point(78, 24)
        Me.chkDefaultAsDivision.Name = "chkDefaultAsDivision"
        Me.chkDefaultAsDivision.Size = New System.Drawing.Size(153, 17)
        Me.chkDefaultAsDivision.TabIndex = 22
        Me.chkDefaultAsDivision.Text = "Default as the division"
        Me.chkDefaultAsDivision.UseVisualStyleBackColor = True
        '
        'txtFromPhoneNumber
        '
        Me.txtFromPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFromPhoneNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFromPhoneNumber.Location = New System.Drawing.Point(78, 332)
        Me.txtFromPhoneNumber.Name = "txtFromPhoneNumber"
        Me.txtFromPhoneNumber.Size = New System.Drawing.Size(158, 20)
        Me.txtFromPhoneNumber.TabIndex = 29
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(6, 331)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 23)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Phone # :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFromZipCode
        '
        Me.txtFromZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFromZipCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFromZipCode.Location = New System.Drawing.Point(275, 292)
        Me.txtFromZipCode.Name = "txtFromZipCode"
        Me.txtFromZipCode.Size = New System.Drawing.Size(120, 20)
        Me.txtFromZipCode.TabIndex = 28
        '
        'txtFromState
        '
        Me.txtFromState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFromState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFromState.Location = New System.Drawing.Point(78, 292)
        Me.txtFromState.Name = "txtFromState"
        Me.txtFromState.Size = New System.Drawing.Size(115, 20)
        Me.txtFromState.TabIndex = 27
        '
        'txtFromCity
        '
        Me.txtFromCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFromCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFromCity.Location = New System.Drawing.Point(78, 252)
        Me.txtFromCity.Name = "txtFromCity"
        Me.txtFromCity.Size = New System.Drawing.Size(317, 20)
        Me.txtFromCity.TabIndex = 26
        '
        'txtFromAddress2
        '
        Me.txtFromAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFromAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFromAddress2.Location = New System.Drawing.Point(78, 182)
        Me.txtFromAddress2.Multiline = True
        Me.txtFromAddress2.Name = "txtFromAddress2"
        Me.txtFromAddress2.Size = New System.Drawing.Size(317, 55)
        Me.txtFromAddress2.TabIndex = 25
        '
        'txtFromAddress1
        '
        Me.txtFromAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFromAddress1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFromAddress1.Location = New System.Drawing.Point(78, 91)
        Me.txtFromAddress1.Multiline = True
        Me.txtFromAddress1.Name = "txtFromAddress1"
        Me.txtFromAddress1.Size = New System.Drawing.Size(317, 82)
        Me.txtFromAddress1.TabIndex = 24
        '
        'txtFromCompanyName
        '
        Me.txtFromCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFromCompanyName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFromCompanyName.Location = New System.Drawing.Point(78, 54)
        Me.txtFromCompanyName.Name = "txtFromCompanyName"
        Me.txtFromCompanyName.Size = New System.Drawing.Size(317, 20)
        Me.txtFromCompanyName.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(209, 291)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 23)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Zip Code :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(6, 291)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "State :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 252)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "City :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Address 2 :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Address 1 :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboVendorID)
        Me.GroupBox2.Controls.Add(Me.cboCustomerID)
        Me.GroupBox2.Controls.Add(Me.chkLoadFromVendor)
        Me.GroupBox2.Controls.Add(Me.chkLoadFromCustomer)
        Me.GroupBox2.Controls.Add(Me.txtToCountry)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.txtToPhoneNumber)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtToZipCode)
        Me.GroupBox2.Controls.Add(Me.txtToState)
        Me.GroupBox2.Controls.Add(Me.txtToCity)
        Me.GroupBox2.Controls.Add(Me.txtToAddress2)
        Me.GroupBox2.Controls.Add(Me.txtToAddress1)
        Me.GroupBox2.Controls.Add(Me.txtToCompanyName)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(365, 409)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(410, 400)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ship To :"
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.VendorBindingSource
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.Enabled = False
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(173, 56)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(222, 21)
        Me.cboVendorID.TabIndex = 43
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.Enabled = False
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(173, 25)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(222, 21)
        Me.cboCustomerID.TabIndex = 42
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'chkLoadFromVendor
        '
        Me.chkLoadFromVendor.AutoSize = True
        Me.chkLoadFromVendor.Location = New System.Drawing.Point(9, 58)
        Me.chkLoadFromVendor.Name = "chkLoadFromVendor"
        Me.chkLoadFromVendor.Size = New System.Drawing.Size(129, 17)
        Me.chkLoadFromVendor.TabIndex = 41
        Me.chkLoadFromVendor.Text = "Load From Vendor"
        Me.chkLoadFromVendor.UseVisualStyleBackColor = True
        '
        'chkLoadFromCustomer
        '
        Me.chkLoadFromCustomer.AutoSize = True
        Me.chkLoadFromCustomer.Location = New System.Drawing.Point(9, 27)
        Me.chkLoadFromCustomer.Name = "chkLoadFromCustomer"
        Me.chkLoadFromCustomer.Size = New System.Drawing.Size(141, 17)
        Me.chkLoadFromCustomer.TabIndex = 40
        Me.chkLoadFromCustomer.Text = "Load From Customer"
        Me.chkLoadFromCustomer.UseVisualStyleBackColor = True
        '
        'txtToCountry
        '
        Me.txtToCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtToCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtToCountry.Location = New System.Drawing.Point(305, 369)
        Me.txtToCountry.Name = "txtToCountry"
        Me.txtToCountry.Size = New System.Drawing.Size(90, 20)
        Me.txtToCountry.TabIndex = 39
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(242, 368)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(69, 23)
        Me.Label32.TabIndex = 32
        Me.Label32.Text = "Country:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtToPhoneNumber
        '
        Me.txtToPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtToPhoneNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtToPhoneNumber.Location = New System.Drawing.Point(78, 369)
        Me.txtToPhoneNumber.Name = "txtToPhoneNumber"
        Me.txtToPhoneNumber.Size = New System.Drawing.Size(158, 20)
        Me.txtToPhoneNumber.TabIndex = 38
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(6, 368)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 23)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Phone # :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtToZipCode
        '
        Me.txtToZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtToZipCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtToZipCode.Location = New System.Drawing.Point(275, 331)
        Me.txtToZipCode.Name = "txtToZipCode"
        Me.txtToZipCode.Size = New System.Drawing.Size(120, 20)
        Me.txtToZipCode.TabIndex = 37
        '
        'txtToState
        '
        Me.txtToState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtToState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtToState.Location = New System.Drawing.Point(78, 331)
        Me.txtToState.Name = "txtToState"
        Me.txtToState.Size = New System.Drawing.Size(115, 20)
        Me.txtToState.TabIndex = 36
        '
        'txtToCity
        '
        Me.txtToCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtToCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtToCity.Location = New System.Drawing.Point(78, 291)
        Me.txtToCity.Name = "txtToCity"
        Me.txtToCity.Size = New System.Drawing.Size(317, 20)
        Me.txtToCity.TabIndex = 35
        '
        'txtToAddress2
        '
        Me.txtToAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtToAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtToAddress2.Location = New System.Drawing.Point(78, 222)
        Me.txtToAddress2.Multiline = True
        Me.txtToAddress2.Name = "txtToAddress2"
        Me.txtToAddress2.Size = New System.Drawing.Size(317, 55)
        Me.txtToAddress2.TabIndex = 34
        '
        'txtToAddress1
        '
        Me.txtToAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtToAddress1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtToAddress1.Location = New System.Drawing.Point(78, 131)
        Me.txtToAddress1.Multiline = True
        Me.txtToAddress1.Name = "txtToAddress1"
        Me.txtToAddress1.Size = New System.Drawing.Size(317, 82)
        Me.txtToAddress1.TabIndex = 33
        '
        'txtToCompanyName
        '
        Me.txtToCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtToCompanyName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtToCompanyName.Location = New System.Drawing.Point(78, 94)
        Me.txtToCompanyName.Name = "txtToCompanyName"
        Me.txtToCompanyName.Size = New System.Drawing.Size(317, 20)
        Me.txtToCompanyName.TabIndex = 32
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(206, 330)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 23)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Zip Code :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(6, 330)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 23)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "State :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(6, 291)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 23)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "City :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(6, 222)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 23)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Address 2 :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(6, 128)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 23)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Address 1 :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(6, 91)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 23)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Name:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Total
        '
        Me.Total.Controls.Add(Me.txtFOB)
        Me.Total.Controls.Add(Me.Label33)
        Me.Total.Controls.Add(Me.txtThirdParty)
        Me.Total.Controls.Add(Me.Label17)
        Me.Total.Controls.Add(Me.cboShipMethod)
        Me.Total.Controls.Add(Me.Label16)
        Me.Total.Controls.Add(Me.cboShipVia)
        Me.Total.Controls.Add(Me.Label15)
        Me.Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Total.Location = New System.Drawing.Point(800, 42)
        Me.Total.Name = "Total"
        Me.Total.Size = New System.Drawing.Size(339, 369)
        Me.Total.TabIndex = 40
        Me.Total.TabStop = False
        Me.Total.Text = "Shipping Method and Special Instructios"
        '
        'txtFOB
        '
        Me.txtFOB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFOB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFOB.Location = New System.Drawing.Point(95, 130)
        Me.txtFOB.Name = "txtFOB"
        Me.txtFOB.Size = New System.Drawing.Size(234, 20)
        Me.txtFOB.TabIndex = 45
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(6, 131)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(100, 23)
        Me.Label33.TabIndex = 44
        Me.Label33.Text = "FOB :"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtThirdParty
        '
        Me.txtThirdParty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtThirdParty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtThirdParty.Location = New System.Drawing.Point(9, 239)
        Me.txtThirdParty.Multiline = True
        Me.txtThirdParty.Name = "txtThirdParty"
        Me.txtThirdParty.Size = New System.Drawing.Size(320, 107)
        Me.txtThirdParty.TabIndex = 43
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(6, 213)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(135, 23)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Third Party Billing Info:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipMethod
        '
        Me.cboShipMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipMethod.FormattingEnabled = True
        Me.cboShipMethod.Items.AddRange(New Object() {"PREPAID", "PREPAID/ADD", "COLLECT", "THIRD PARTY", "OTHER"})
        Me.cboShipMethod.Location = New System.Drawing.Point(95, 76)
        Me.cboShipMethod.Name = "cboShipMethod"
        Me.cboShipMethod.Size = New System.Drawing.Size(234, 21)
        Me.cboShipMethod.TabIndex = 42
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(6, 74)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 23)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Ship Method :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipVia
        '
        Me.cboShipVia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipVia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipVia.DataSource = Me.ShipMethodBindingSource
        Me.cboShipVia.DisplayMember = "ShipMethID"
        Me.cboShipVia.FormattingEnabled = True
        Me.cboShipVia.Location = New System.Drawing.Point(95, 38)
        Me.cboShipVia.Name = "cboShipVia"
        Me.cboShipVia.Size = New System.Drawing.Size(234, 21)
        Me.cboShipVia.TabIndex = 41
        '
        'ShipMethodBindingSource
        '
        Me.ShipMethodBindingSource.DataMember = "ShipMethod"
        Me.ShipMethodBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(6, 36)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 23)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Ship Via :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(798, 435)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(135, 23)
        Me.Label18.TabIndex = 9
        Me.Label18.Text = "Special Instructions"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSpecialInstructions
        '
        Me.txtSpecialInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSpecialInstructions.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSpecialInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpecialInstructions.Location = New System.Drawing.Point(801, 461)
        Me.txtSpecialInstructions.Multiline = True
        Me.txtSpecialInstructions.Name = "txtSpecialInstructions"
        Me.txtSpecialInstructions.Size = New System.Drawing.Size(329, 225)
        Me.txtSpecialInstructions.TabIndex = 44
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label35)
        Me.GroupBox4.Controls.Add(Me.cboDivisionID)
        Me.GroupBox4.Controls.Add(Me.cmdGenerateNewBOL)
        Me.GroupBox4.Controls.Add(Me.txtFreightAccountNumber)
        Me.GroupBox4.Controls.Add(Me.Label29)
        Me.GroupBox4.Controls.Add(Me.cboBOLNumber)
        Me.GroupBox4.Controls.Add(Me.Label28)
        Me.GroupBox4.Controls.Add(Me.dtpShipDate)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.txtPRONUmber)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.txtFreightQuoteNumber)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.txtCustomerPO)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.txtShipmentNumber)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(12, 41)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(341, 306)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Shipment Details"
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(15, 61)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(113, 23)
        Me.Label35.TabIndex = 26
        Me.Label35.Text = "Division ID ::"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(149, 60)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(178, 21)
        Me.cboDivisionID.TabIndex = 3
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdGenerateNewBOL
        '
        Me.cmdGenerateNewBOL.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateNewBOL.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateNewBOL.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateNewBOL.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateNewBOL.Location = New System.Drawing.Point(117, 24)
        Me.cmdGenerateNewBOL.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateNewBOL.Name = "cmdGenerateNewBOL"
        Me.cmdGenerateNewBOL.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateNewBOL.TabIndex = 1
        Me.cmdGenerateNewBOL.Text = ">>"
        Me.cmdGenerateNewBOL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateNewBOL.UseVisualStyleBackColor = False
        '
        'txtFreightAccountNumber
        '
        Me.txtFreightAccountNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightAccountNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreightAccountNumber.Location = New System.Drawing.Point(149, 271)
        Me.txtFreightAccountNumber.Name = "txtFreightAccountNumber"
        Me.txtFreightAccountNumber.Size = New System.Drawing.Size(178, 20)
        Me.txtFreightAccountNumber.TabIndex = 9
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(15, 273)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(113, 23)
        Me.Label29.TabIndex = 23
        Me.Label29.Text = "Account # :"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBOLNumber
        '
        Me.cboBOLNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBOLNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBOLNumber.DataSource = Me.VendorBOLTableBindingSource
        Me.cboBOLNumber.DisplayMember = "VendorBOLNumber"
        Me.cboBOLNumber.FormattingEnabled = True
        Me.cboBOLNumber.Location = New System.Drawing.Point(149, 24)
        Me.cboBOLNumber.Name = "cboBOLNumber"
        Me.cboBOLNumber.Size = New System.Drawing.Size(178, 21)
        Me.cboBOLNumber.TabIndex = 2
        '
        'VendorBOLTableBindingSource
        '
        Me.VendorBOLTableBindingSource.DataMember = "VendorBOLTable"
        Me.VendorBOLTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(15, 23)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(113, 23)
        Me.Label28.TabIndex = 21
        Me.Label28.Text = "Bill Of Lading # :"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpShipDate
        '
        Me.dtpShipDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpShipDate.Location = New System.Drawing.Point(149, 96)
        Me.dtpShipDate.Name = "dtpShipDate"
        Me.dtpShipDate.Size = New System.Drawing.Size(178, 20)
        Me.dtpShipDate.TabIndex = 4
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(15, 97)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(113, 23)
        Me.Label23.TabIndex = 19
        Me.Label23.Text = "Shipment Date :"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPRONUmber
        '
        Me.txtPRONUmber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPRONUmber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPRONUmber.Location = New System.Drawing.Point(149, 236)
        Me.txtPRONUmber.Name = "txtPRONUmber"
        Me.txtPRONUmber.Size = New System.Drawing.Size(178, 20)
        Me.txtPRONUmber.TabIndex = 8
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(15, 237)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(113, 23)
        Me.Label22.TabIndex = 17
        Me.Label22.Text = "PRO Number :"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFreightQuoteNumber
        '
        Me.txtFreightQuoteNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightQuoteNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreightQuoteNumber.Location = New System.Drawing.Point(149, 201)
        Me.txtFreightQuoteNumber.Name = "txtFreightQuoteNumber"
        Me.txtFreightQuoteNumber.Size = New System.Drawing.Size(178, 20)
        Me.txtFreightQuoteNumber.TabIndex = 7
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(15, 202)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(113, 23)
        Me.Label21.TabIndex = 15
        Me.Label21.Text = "Freight Quote # :"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCustomerPO
        '
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerPO.Location = New System.Drawing.Point(149, 166)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(178, 20)
        Me.txtCustomerPO.TabIndex = 6
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(15, 167)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(113, 23)
        Me.Label20.TabIndex = 13
        Me.Label20.Text = "Customer PO # :"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShipmentNumber
        '
        Me.txtShipmentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipmentNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipmentNumber.Location = New System.Drawing.Point(149, 131)
        Me.txtShipmentNumber.Name = "txtShipmentNumber"
        Me.txtShipmentNumber.Size = New System.Drawing.Size(178, 20)
        Me.txtShipmentNumber.TabIndex = 5
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(15, 132)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(113, 23)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Shipment # :"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtTotalOnFloor)
        Me.GroupBox5.Controls.Add(Me.lblTotalOnFloor)
        Me.GroupBox5.Controls.Add(Me.txtDoubleStacks)
        Me.GroupBox5.Controls.Add(Me.lblDoubleStack)
        Me.GroupBox5.Controls.Add(Me.txtMajorUnits)
        Me.GroupBox5.Controls.Add(Me.lblMajorUnits)
        Me.GroupBox5.Controls.Add(Me.txtTotalWeight)
        Me.GroupBox5.Controls.Add(Me.Label31)
        Me.GroupBox5.Controls.Add(Me.lblMinorUnits)
        Me.GroupBox5.Controls.Add(Me.txtMinorUnits)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(12, 554)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(341, 255)
        Me.GroupBox5.TabIndex = 15
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Shipment Totals"
        '
        'txtTotalOnFloor
        '
        Me.txtTotalOnFloor.BackColor = System.Drawing.Color.White
        Me.txtTotalOnFloor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalOnFloor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalOnFloor.Location = New System.Drawing.Point(201, 214)
        Me.txtTotalOnFloor.Name = "txtTotalOnFloor"
        Me.txtTotalOnFloor.ReadOnly = True
        Me.txtTotalOnFloor.Size = New System.Drawing.Size(123, 20)
        Me.txtTotalOnFloor.TabIndex = 20
        '
        'lblTotalOnFloor
        '
        Me.lblTotalOnFloor.Location = New System.Drawing.Point(23, 216)
        Me.lblTotalOnFloor.Name = "lblTotalOnFloor"
        Me.lblTotalOnFloor.Size = New System.Drawing.Size(163, 23)
        Me.lblTotalOnFloor.TabIndex = 32
        Me.lblTotalOnFloor.Text = "Total Units on Floor :"
        Me.lblTotalOnFloor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDoubleStacks
        '
        Me.txtDoubleStacks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDoubleStacks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDoubleStacks.Location = New System.Drawing.Point(201, 169)
        Me.txtDoubleStacks.Name = "txtDoubleStacks"
        Me.txtDoubleStacks.Size = New System.Drawing.Size(123, 20)
        Me.txtDoubleStacks.TabIndex = 19
        '
        'lblDoubleStack
        '
        Me.lblDoubleStack.Location = New System.Drawing.Point(23, 170)
        Me.lblDoubleStack.Name = "lblDoubleStack"
        Me.lblDoubleStack.Size = New System.Drawing.Size(163, 23)
        Me.lblDoubleStack.TabIndex = 30
        Me.lblDoubleStack.Text = "Double-Stacked Units"
        Me.lblDoubleStack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMajorUnits
        '
        Me.txtMajorUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMajorUnits.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMajorUnits.Location = New System.Drawing.Point(201, 124)
        Me.txtMajorUnits.Name = "txtMajorUnits"
        Me.txtMajorUnits.Size = New System.Drawing.Size(123, 20)
        Me.txtMajorUnits.TabIndex = 18
        '
        'lblMajorUnits
        '
        Me.lblMajorUnits.Location = New System.Drawing.Point(23, 120)
        Me.lblMajorUnits.Name = "lblMajorUnits"
        Me.lblMajorUnits.Size = New System.Drawing.Size(163, 23)
        Me.lblMajorUnits.TabIndex = 27
        Me.lblMajorUnits.Text = "Number of Major Units :"
        Me.lblMajorUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalWeight
        '
        Me.txtTotalWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalWeight.Location = New System.Drawing.Point(201, 79)
        Me.txtTotalWeight.Name = "txtTotalWeight"
        Me.txtTotalWeight.Size = New System.Drawing.Size(123, 20)
        Me.txtTotalWeight.TabIndex = 17
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(23, 77)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(163, 23)
        Me.Label31.TabIndex = 24
        Me.Label31.Text = "Total Weight :"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMinorUnits
        '
        Me.lblMinorUnits.Location = New System.Drawing.Point(23, 33)
        Me.lblMinorUnits.Name = "lblMinorUnits"
        Me.lblMinorUnits.Size = New System.Drawing.Size(163, 23)
        Me.lblMinorUnits.TabIndex = 23
        Me.lblMinorUnits.Text = "Number of Minor Units :"
        Me.lblMinorUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMinorUnits
        '
        Me.txtMinorUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMinorUnits.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMinorUnits.Location = New System.Drawing.Point(201, 34)
        Me.txtMinorUnits.Name = "txtMinorUnits"
        Me.txtMinorUnits.Size = New System.Drawing.Size(123, 20)
        Me.txtMinorUnits.TabIndex = 16
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cboMajorUnits)
        Me.GroupBox6.Controls.Add(Me.Label27)
        Me.GroupBox6.Controls.Add(Me.cboCommodity)
        Me.GroupBox6.Controls.Add(Me.txtClassRate)
        Me.GroupBox6.Controls.Add(Me.Label26)
        Me.GroupBox6.Controls.Add(Me.Label25)
        Me.GroupBox6.Controls.Add(Me.cboMinorUnits)
        Me.GroupBox6.Controls.Add(Me.Label24)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(12, 363)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(341, 175)
        Me.GroupBox6.TabIndex = 10
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Shipment Handling / Unts"
        '
        'cboMajorUnits
        '
        Me.cboMajorUnits.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMajorUnits.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMajorUnits.FormattingEnabled = True
        Me.cboMajorUnits.Items.AddRange(New Object() {"PALLETS", "METAL TUBS"})
        Me.cboMajorUnits.Location = New System.Drawing.Point(165, 65)
        Me.cboMajorUnits.Name = "cboMajorUnits"
        Me.cboMajorUnits.Size = New System.Drawing.Size(159, 21)
        Me.cboMajorUnits.TabIndex = 12
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(18, 65)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(141, 23)
        Me.Label27.TabIndex = 26
        Me.Label27.Text = "Major Shipping Units :"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCommodity
        '
        Me.cboCommodity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCommodity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCommodity.FormattingEnabled = True
        Me.cboCommodity.Items.AddRange(New Object() {"STEEL BOLTS / WELD STUDS", "WELDING EQUIPMENT", "FERRULES", "OTHER"})
        Me.cboCommodity.Location = New System.Drawing.Point(99, 140)
        Me.cboCommodity.Name = "cboCommodity"
        Me.cboCommodity.Size = New System.Drawing.Size(225, 21)
        Me.cboCommodity.TabIndex = 14
        '
        'txtClassRate
        '
        Me.txtClassRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClassRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClassRate.Location = New System.Drawing.Point(201, 103)
        Me.txtClassRate.Name = "txtClassRate"
        Me.txtClassRate.Size = New System.Drawing.Size(123, 20)
        Me.txtClassRate.TabIndex = 13
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(20, 140)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(105, 23)
        Me.Label26.TabIndex = 23
        Me.Label26.Text = "Commodity :"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(20, 103)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(105, 23)
        Me.Label25.TabIndex = 22
        Me.Label25.Text = "Class Rate :"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboMinorUnits
        '
        Me.cboMinorUnits.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMinorUnits.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMinorUnits.FormattingEnabled = True
        Me.cboMinorUnits.Items.AddRange(New Object() {"UNITS", "BOXES", "BAGS", "CANS"})
        Me.cboMinorUnits.Location = New System.Drawing.Point(165, 27)
        Me.cboMinorUnits.Name = "cboMinorUnits"
        Me.cboMinorUnits.Size = New System.Drawing.Size(159, 21)
        Me.cboMinorUnits.TabIndex = 11
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(20, 27)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(139, 23)
        Me.Label24.TabIndex = 20
        Me.Label24.Text = "Minor Shipping Units :"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(1058, 777)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(71, 40)
        Me.Button1.TabIndex = 48
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(800, 722)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 47
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdSaveBOL
        '
        Me.cmdSaveBOL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSaveBOL.Location = New System.Drawing.Point(886, 777)
        Me.cmdSaveBOL.Name = "cmdSaveBOL"
        Me.cmdSaveBOL.Size = New System.Drawing.Size(71, 40)
        Me.cmdSaveBOL.TabIndex = 46
        Me.cmdSaveBOL.Text = "Save"
        Me.cmdSaveBOL.UseVisualStyleBackColor = True
        '
        'cmdPrintBOL
        '
        Me.cmdPrintBOL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintBOL.Location = New System.Drawing.Point(800, 777)
        Me.cmdPrintBOL.Name = "cmdPrintBOL"
        Me.cmdPrintBOL.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintBOL.TabIndex = 45
        Me.cmdPrintBOL.Text = "Print"
        Me.cmdPrintBOL.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ShipMethodTableAdapter
        '
        Me.ShipMethodTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(972, 777)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 49
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'VendorBOLTableTableAdapter
        '
        Me.VendorBOLTableTableAdapter.ClearBeforeFill = True
        '
        'DeleteBOLToolStripMenuItem
        '
        Me.DeleteBOLToolStripMenuItem.Name = "DeleteBOLToolStripMenuItem"
        Me.DeleteBOLToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteBOLToolStripMenuItem.Text = "Delete BOL"
        '
        'ClearFormToolStripMenuItem
        '
        Me.ClearFormToolStripMenuItem.Name = "ClearFormToolStripMenuItem"
        Me.ClearFormToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ClearFormToolStripMenuItem.Text = "Clear Form"
        '
        'CreateVendorBOL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtSpecialInstructions)
        Me.Controls.Add(Me.cmdPrintBOL)
        Me.Controls.Add(Me.cmdSaveBOL)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Total)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "CreateVendorBOL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Create Vendor / Third Party BOL"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Total.ResumeLayout(False)
        Me.Total.PerformLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBOLTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFromPhoneNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFromZipCode As System.Windows.Forms.TextBox
    Friend WithEvents txtFromState As System.Windows.Forms.TextBox
    Friend WithEvents txtFromCity As System.Windows.Forms.TextBox
    Friend WithEvents txtFromAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtFromAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtFromCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtToPhoneNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtToZipCode As System.Windows.Forms.TextBox
    Friend WithEvents txtToState As System.Windows.Forms.TextBox
    Friend WithEvents txtToCity As System.Windows.Forms.TextBox
    Friend WithEvents txtToAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtToAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtToCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDefaultAsDivision As System.Windows.Forms.CheckBox
    Friend WithEvents Total As System.Windows.Forms.GroupBox
    Friend WithEvents cboShipVia As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtSpecialInstructions As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtThirdParty As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboShipMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtShipmentNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents dtpShipDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtPRONUmber As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtFreightQuoteNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cboMinorUnits As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cboMajorUnits As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cboCommodity As System.Windows.Forms.ComboBox
    Friend WithEvents txtClassRate As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdSaveBOL As System.Windows.Forms.Button
    Friend WithEvents cmdPrintBOL As System.Windows.Forms.Button
    Friend WithEvents cboBOLNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtFreightAccountNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtTotalWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblMinorUnits As System.Windows.Forms.Label
    Friend WithEvents txtMinorUnits As System.Windows.Forms.TextBox
    Friend WithEvents txtMajorUnits As System.Windows.Forms.TextBox
    Friend WithEvents lblMajorUnits As System.Windows.Forms.Label
    Friend WithEvents txtTotalOnFloor As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalOnFloor As System.Windows.Forms.Label
    Friend WithEvents txtDoubleStacks As System.Windows.Forms.TextBox
    Friend WithEvents lblDoubleStack As System.Windows.Forms.Label
    Friend WithEvents cmdGenerateNewBOL As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ShipMethodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipMethodTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
    Friend WithEvents txtFromCountry As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtToCountry As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents chkLoadFromVendor As System.Windows.Forms.CheckBox
    Friend WithEvents chkLoadFromCustomer As System.Windows.Forms.CheckBox
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtFOB As System.Windows.Forms.TextBox
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents VendorBOLTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorBOLTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorBOLTableTableAdapter
    Friend WithEvents SaveBOLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintBOLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteBOLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
