<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeeData
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.txtEmpLastName = New System.Windows.Forms.TextBox
        Me.txtEmpState = New System.Windows.Forms.TextBox
        Me.txtEmpCity = New System.Windows.Forms.TextBox
        Me.txtEmpAddress = New System.Windows.Forms.TextBox
        Me.txtEmpFirstName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtEmpEmergencyContact = New System.Windows.Forms.TextBox
        Me.txtEmpEmail = New System.Windows.Forms.TextBox
        Me.txtEmpPhone = New System.Windows.Forms.TextBox
        Me.txtEmpZipCode = New System.Windows.Forms.TextBox
        Me.gpxEmpPersonalData = New System.Windows.Forms.GroupBox
        Me.cmdEnter = New System.Windows.Forms.Button
        Me.txtSalesPersonID = New System.Windows.Forms.TextBox
        Me.chkSalesPerson = New System.Windows.Forms.CheckBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.gpxTFPEmployeeData = New System.Windows.Forms.GroupBox
        Me.cboLoginType = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.cmdDeactivateEmployee = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtDepartmentID = New System.Windows.Forms.TextBox
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.txtLoginPassword = New System.Windows.Forms.TextBox
        Me.txtLoginName = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboSecurityGroup = New System.Windows.Forms.ComboBox
        Me.SecurityGroupBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboDepartmentName = New System.Windows.Forms.ComboBox
        Me.DepartmentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboDivisionKey = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpHireDate = New System.Windows.Forms.DateTimePicker
        Me.cboEmployeeNumber = New System.Windows.Forms.ComboBox
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileEditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintEmployeeRosterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintEmailListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintPhoneListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrintPhoneList = New System.Windows.Forms.Button
        Me.cmdPrintEmailList = New System.Windows.Forms.Button
        Me.dgvEmployeeData = New System.Windows.Forms.DataGridView
        Me.EmployeeIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmployeeLastColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmployeeFirstColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SecurityGroupIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LoginNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LoginPasswordColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DepartmentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesPersonIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmailAddressColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AddressColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ZipCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PhoneNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmergencyContactColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HireDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShiftColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MOSLoginTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.DepartmentsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DepartmentsTableAdapter
        Me.SecurityGroupTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SecurityGroupTableAdapter
        Me.cmdLogonRecord = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.gpxEmpPersonalData.SuspendLayout()
        Me.gpxTFPEmployeeData.SuspendLayout()
        CType(Me.SecurityGroupBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DepartmentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvEmployeeData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 26
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'txtEmpLastName
        '
        Me.txtEmpLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpLastName.Location = New System.Drawing.Point(127, 29)
        Me.txtEmpLastName.Name = "txtEmpLastName"
        Me.txtEmpLastName.Size = New System.Drawing.Size(205, 20)
        Me.txtEmpLastName.TabIndex = 12
        Me.txtEmpLastName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEmpState
        '
        Me.txtEmpState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpState.Location = New System.Drawing.Point(127, 145)
        Me.txtEmpState.Name = "txtEmpState"
        Me.txtEmpState.Size = New System.Drawing.Size(205, 20)
        Me.txtEmpState.TabIndex = 16
        Me.txtEmpState.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEmpCity
        '
        Me.txtEmpCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpCity.Location = New System.Drawing.Point(127, 116)
        Me.txtEmpCity.Name = "txtEmpCity"
        Me.txtEmpCity.Size = New System.Drawing.Size(205, 20)
        Me.txtEmpCity.TabIndex = 15
        Me.txtEmpCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEmpAddress
        '
        Me.txtEmpAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpAddress.Location = New System.Drawing.Point(127, 87)
        Me.txtEmpAddress.Name = "txtEmpAddress"
        Me.txtEmpAddress.Size = New System.Drawing.Size(205, 20)
        Me.txtEmpAddress.TabIndex = 14
        Me.txtEmpAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEmpFirstName
        '
        Me.txtEmpFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpFirstName.Location = New System.Drawing.Point(127, 58)
        Me.txtEmpFirstName.Name = "txtEmpFirstName"
        Me.txtEmpFirstName.Size = New System.Drawing.Size(205, 20)
        Me.txtEmpFirstName.TabIndex = 13
        Me.txtEmpFirstName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Last Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "State"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "City"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Address"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "First Name"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 261)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 20)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Emergency Contact"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 232)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 20)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Email Address"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 203)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 20)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Phone Number"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(17, 174)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 20)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Zip Code"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmpEmergencyContact
        '
        Me.txtEmpEmergencyContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpEmergencyContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpEmergencyContact.Location = New System.Drawing.Point(127, 261)
        Me.txtEmpEmergencyContact.Name = "txtEmpEmergencyContact"
        Me.txtEmpEmergencyContact.Size = New System.Drawing.Size(205, 20)
        Me.txtEmpEmergencyContact.TabIndex = 20
        Me.txtEmpEmergencyContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEmpEmail
        '
        Me.txtEmpEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpEmail.Location = New System.Drawing.Point(127, 232)
        Me.txtEmpEmail.Name = "txtEmpEmail"
        Me.txtEmpEmail.Size = New System.Drawing.Size(205, 20)
        Me.txtEmpEmail.TabIndex = 19
        Me.txtEmpEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEmpPhone
        '
        Me.txtEmpPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpPhone.Location = New System.Drawing.Point(127, 203)
        Me.txtEmpPhone.Name = "txtEmpPhone"
        Me.txtEmpPhone.Size = New System.Drawing.Size(205, 20)
        Me.txtEmpPhone.TabIndex = 18
        Me.txtEmpPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEmpZipCode
        '
        Me.txtEmpZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpZipCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpZipCode.Location = New System.Drawing.Point(127, 174)
        Me.txtEmpZipCode.Name = "txtEmpZipCode"
        Me.txtEmpZipCode.Size = New System.Drawing.Size(205, 20)
        Me.txtEmpZipCode.TabIndex = 17
        Me.txtEmpZipCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gpxEmpPersonalData
        '
        Me.gpxEmpPersonalData.Controls.Add(Me.cmdEnter)
        Me.gpxEmpPersonalData.Controls.Add(Me.txtSalesPersonID)
        Me.gpxEmpPersonalData.Controls.Add(Me.chkSalesPerson)
        Me.gpxEmpPersonalData.Controls.Add(Me.Label17)
        Me.gpxEmpPersonalData.Controls.Add(Me.cmdClear)
        Me.gpxEmpPersonalData.Controls.Add(Me.txtEmpLastName)
        Me.gpxEmpPersonalData.Controls.Add(Me.txtEmpZipCode)
        Me.gpxEmpPersonalData.Controls.Add(Me.txtEmpState)
        Me.gpxEmpPersonalData.Controls.Add(Me.txtEmpPhone)
        Me.gpxEmpPersonalData.Controls.Add(Me.txtEmpCity)
        Me.gpxEmpPersonalData.Controls.Add(Me.txtEmpEmail)
        Me.gpxEmpPersonalData.Controls.Add(Me.txtEmpAddress)
        Me.gpxEmpPersonalData.Controls.Add(Me.txtEmpEmergencyContact)
        Me.gpxEmpPersonalData.Controls.Add(Me.txtEmpFirstName)
        Me.gpxEmpPersonalData.Controls.Add(Me.Label9)
        Me.gpxEmpPersonalData.Controls.Add(Me.Label1)
        Me.gpxEmpPersonalData.Controls.Add(Me.Label8)
        Me.gpxEmpPersonalData.Controls.Add(Me.Label2)
        Me.gpxEmpPersonalData.Controls.Add(Me.Label7)
        Me.gpxEmpPersonalData.Controls.Add(Me.Label3)
        Me.gpxEmpPersonalData.Controls.Add(Me.Label6)
        Me.gpxEmpPersonalData.Controls.Add(Me.Label4)
        Me.gpxEmpPersonalData.Controls.Add(Me.Label5)
        Me.gpxEmpPersonalData.Location = New System.Drawing.Point(14, 383)
        Me.gpxEmpPersonalData.Name = "gpxEmpPersonalData"
        Me.gpxEmpPersonalData.Size = New System.Drawing.Size(353, 428)
        Me.gpxEmpPersonalData.TabIndex = 11
        Me.gpxEmpPersonalData.TabStop = False
        Me.gpxEmpPersonalData.Text = "Personal Data"
        '
        'cmdEnter
        '
        Me.cmdEnter.ForeColor = System.Drawing.Color.Black
        Me.cmdEnter.Location = New System.Drawing.Point(183, 378)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(71, 30)
        Me.cmdEnter.TabIndex = 23
        Me.cmdEnter.Text = "Enter/Save"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'txtSalesPersonID
        '
        Me.txtSalesPersonID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesPersonID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesPersonID.Location = New System.Drawing.Point(20, 344)
        Me.txtSalesPersonID.Name = "txtSalesPersonID"
        Me.txtSalesPersonID.Size = New System.Drawing.Size(311, 20)
        Me.txtSalesPersonID.TabIndex = 22
        Me.txtSalesPersonID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkSalesPerson
        '
        Me.chkSalesPerson.AutoSize = True
        Me.chkSalesPerson.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSalesPerson.Location = New System.Drawing.Point(20, 301)
        Me.chkSalesPerson.Name = "chkSalesPerson"
        Me.chkSalesPerson.Size = New System.Drawing.Size(208, 17)
        Me.chkSalesPerson.TabIndex = 21
        Me.chkSalesPerson.Text = "Is this employee a Salesperson?"
        Me.chkSalesPerson.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(17, 321)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(107, 20)
        Me.Label17.TabIndex = 17
        Me.Label17.Text = "Salesperson ID"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(260, 378)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 24
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(19, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 20)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Hire Date"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(19, 118)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(107, 20)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "Department Name"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(21, 181)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(107, 20)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "Security Access"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(19, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(107, 20)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "Employee Number"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxTFPEmployeeData
        '
        Me.gpxTFPEmployeeData.Controls.Add(Me.cboLoginType)
        Me.gpxTFPEmployeeData.Controls.Add(Me.Label19)
        Me.gpxTFPEmployeeData.Controls.Add(Me.cmdDeactivateEmployee)
        Me.gpxTFPEmployeeData.Controls.Add(Me.Label18)
        Me.gpxTFPEmployeeData.Controls.Add(Me.txtDepartmentID)
        Me.gpxTFPEmployeeData.Controls.Add(Me.txtStatus)
        Me.gpxTFPEmployeeData.Controls.Add(Me.lblStatus)
        Me.gpxTFPEmployeeData.Controls.Add(Me.txtLoginPassword)
        Me.gpxTFPEmployeeData.Controls.Add(Me.txtLoginName)
        Me.gpxTFPEmployeeData.Controls.Add(Me.Label11)
        Me.gpxTFPEmployeeData.Controls.Add(Me.Label12)
        Me.gpxTFPEmployeeData.Controls.Add(Me.cboSecurityGroup)
        Me.gpxTFPEmployeeData.Controls.Add(Me.cboDepartmentName)
        Me.gpxTFPEmployeeData.Controls.Add(Me.cboDivisionKey)
        Me.gpxTFPEmployeeData.Controls.Add(Me.dtpHireDate)
        Me.gpxTFPEmployeeData.Controls.Add(Me.cboEmployeeNumber)
        Me.gpxTFPEmployeeData.Controls.Add(Me.Label10)
        Me.gpxTFPEmployeeData.Controls.Add(Me.Label15)
        Me.gpxTFPEmployeeData.Controls.Add(Me.Label16)
        Me.gpxTFPEmployeeData.Controls.Add(Me.Label13)
        Me.gpxTFPEmployeeData.Controls.Add(Me.Label14)
        Me.gpxTFPEmployeeData.Location = New System.Drawing.Point(12, 35)
        Me.gpxTFPEmployeeData.Name = "gpxTFPEmployeeData"
        Me.gpxTFPEmployeeData.Size = New System.Drawing.Size(353, 342)
        Me.gpxTFPEmployeeData.TabIndex = 0
        Me.gpxTFPEmployeeData.TabStop = False
        Me.gpxTFPEmployeeData.Text = "TFP Employee Data"
        '
        'cboLoginType
        '
        Me.cboLoginType.FormattingEnabled = True
        Me.cboLoginType.Items.AddRange(New Object() {"REMOTE", "LOCAL"})
        Me.cboLoginType.Location = New System.Drawing.Point(129, 274)
        Me.cboLoginType.Name = "cboLoginType"
        Me.cboLoginType.Size = New System.Drawing.Size(209, 21)
        Me.cboLoginType.TabIndex = 8
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(19, 275)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(107, 20)
        Me.Label19.TabIndex = 44
        Me.Label19.Text = "Login Type"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeactivateEmployee
        '
        Me.cmdDeactivateEmployee.ForeColor = System.Drawing.Color.Blue
        Me.cmdDeactivateEmployee.Location = New System.Drawing.Point(78, 306)
        Me.cmdDeactivateEmployee.Name = "cmdDeactivateEmployee"
        Me.cmdDeactivateEmployee.Size = New System.Drawing.Size(45, 20)
        Me.cmdDeactivateEmployee.TabIndex = 9
        Me.cmdDeactivateEmployee.Text = "Close"
        Me.cmdDeactivateEmployee.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.Enabled = False
        Me.Label18.Location = New System.Drawing.Point(19, 149)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(107, 20)
        Me.Label18.TabIndex = 42
        Me.Label18.Text = "Department ID"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDepartmentID
        '
        Me.txtDepartmentID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepartmentID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDepartmentID.Location = New System.Drawing.Point(127, 149)
        Me.txtDepartmentID.Name = "txtDepartmentID"
        Me.txtDepartmentID.Size = New System.Drawing.Size(207, 20)
        Me.txtDepartmentID.TabIndex = 4
        Me.txtDepartmentID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtStatus
        '
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStatus.Enabled = False
        Me.txtStatus.Location = New System.Drawing.Point(129, 306)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(207, 20)
        Me.txtStatus.TabIndex = 10
        Me.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(21, 306)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(107, 20)
        Me.lblStatus.TabIndex = 40
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLoginPassword
        '
        Me.txtLoginPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoginPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLoginPassword.Location = New System.Drawing.Point(127, 243)
        Me.txtLoginPassword.Name = "txtLoginPassword"
        Me.txtLoginPassword.Size = New System.Drawing.Size(207, 20)
        Me.txtLoginPassword.TabIndex = 7
        Me.txtLoginPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLoginName
        '
        Me.txtLoginName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoginName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLoginName.Location = New System.Drawing.Point(127, 212)
        Me.txtLoginName.Name = "txtLoginName"
        Me.txtLoginName.Size = New System.Drawing.Size(207, 20)
        Me.txtLoginName.TabIndex = 6
        Me.txtLoginName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(19, 243)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 20)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Password"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(19, 212)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(107, 20)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "Login Name"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSecurityGroup
        '
        Me.cboSecurityGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSecurityGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSecurityGroup.DataSource = Me.SecurityGroupBindingSource
        Me.cboSecurityGroup.DisplayMember = "SecurityGroupID"
        Me.cboSecurityGroup.FormattingEnabled = True
        Me.cboSecurityGroup.Location = New System.Drawing.Point(127, 180)
        Me.cboSecurityGroup.Name = "cboSecurityGroup"
        Me.cboSecurityGroup.Size = New System.Drawing.Size(207, 21)
        Me.cboSecurityGroup.TabIndex = 5
        '
        'SecurityGroupBindingSource
        '
        Me.SecurityGroupBindingSource.DataMember = "SecurityGroup"
        Me.SecurityGroupBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboDepartmentName
        '
        Me.cboDepartmentName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDepartmentName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDepartmentName.DataSource = Me.DepartmentsBindingSource
        Me.cboDepartmentName.DisplayMember = "DepartmentName"
        Me.cboDepartmentName.FormattingEnabled = True
        Me.cboDepartmentName.Location = New System.Drawing.Point(127, 117)
        Me.cboDepartmentName.Name = "cboDepartmentName"
        Me.cboDepartmentName.Size = New System.Drawing.Size(207, 21)
        Me.cboDepartmentName.TabIndex = 3
        '
        'DepartmentsBindingSource
        '
        Me.DepartmentsBindingSource.DataMember = "Departments"
        Me.DepartmentsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboDivisionKey
        '
        Me.cboDivisionKey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionKey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionKey.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionKey.DisplayMember = "DivisionKey"
        Me.cboDivisionKey.FormattingEnabled = True
        Me.cboDivisionKey.Location = New System.Drawing.Point(127, 85)
        Me.cboDivisionKey.Name = "cboDivisionKey"
        Me.cboDivisionKey.Size = New System.Drawing.Size(207, 21)
        Me.cboDivisionKey.TabIndex = 2
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpHireDate
        '
        Me.dtpHireDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHireDate.Location = New System.Drawing.Point(127, 54)
        Me.dtpHireDate.Name = "dtpHireDate"
        Me.dtpHireDate.Size = New System.Drawing.Size(207, 20)
        Me.dtpHireDate.TabIndex = 1
        '
        'cboEmployeeNumber
        '
        Me.cboEmployeeNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboEmployeeNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEmployeeNumber.DataSource = Me.EmployeeDataBindingSource
        Me.cboEmployeeNumber.DisplayMember = "EmployeeID"
        Me.cboEmployeeNumber.FormattingEnabled = True
        Me.cboEmployeeNumber.Location = New System.Drawing.Point(127, 22)
        Me.cboEmployeeNumber.Name = "cboEmployeeNumber"
        Me.cboEmployeeNumber.Size = New System.Drawing.Size(207, 21)
        Me.cboEmployeeNumber.TabIndex = 0
        '
        'EmployeeDataBindingSource
        '
        Me.EmployeeDataBindingSource.DataMember = "EmployeeData"
        Me.EmployeeDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(19, 86)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 20)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Division"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Enabled = False
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 25
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileEditToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 38
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileEditToolStripMenuItem
        '
        Me.FileEditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearFormToolStripMenuItem})
        Me.FileEditToolStripMenuItem.Name = "FileEditToolStripMenuItem"
        Me.FileEditToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileEditToolStripMenuItem.Text = "File"
        '
        'ClearFormToolStripMenuItem
        '
        Me.ClearFormToolStripMenuItem.Name = "ClearFormToolStripMenuItem"
        Me.ClearFormToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.ClearFormToolStripMenuItem.Text = "Clear Form"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintEmployeeRosterToolStripMenuItem, Me.PrintEmailListToolStripMenuItem, Me.PrintPhoneListToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintEmployeeRosterToolStripMenuItem
        '
        Me.PrintEmployeeRosterToolStripMenuItem.Name = "PrintEmployeeRosterToolStripMenuItem"
        Me.PrintEmployeeRosterToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PrintEmployeeRosterToolStripMenuItem.Text = "Print Employee Roster"
        '
        'PrintEmailListToolStripMenuItem
        '
        Me.PrintEmailListToolStripMenuItem.Name = "PrintEmailListToolStripMenuItem"
        Me.PrintEmailListToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PrintEmailListToolStripMenuItem.Text = "Print Email List"
        '
        'PrintPhoneListToolStripMenuItem
        '
        Me.PrintPhoneListToolStripMenuItem.Name = "PrintPhoneListToolStripMenuItem"
        Me.PrintPhoneListToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PrintPhoneListToolStripMenuItem.Text = "Print Phone List"
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
        'cmdPrintPhoneList
        '
        Me.cmdPrintPhoneList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintPhoneList.Location = New System.Drawing.Point(376, 771)
        Me.cmdPrintPhoneList.Name = "cmdPrintPhoneList"
        Me.cmdPrintPhoneList.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintPhoneList.TabIndex = 20
        Me.cmdPrintPhoneList.Text = "Print Phone List"
        Me.cmdPrintPhoneList.UseVisualStyleBackColor = True
        '
        'cmdPrintEmailList
        '
        Me.cmdPrintEmailList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintEmailList.Location = New System.Drawing.Point(453, 771)
        Me.cmdPrintEmailList.Name = "cmdPrintEmailList"
        Me.cmdPrintEmailList.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintEmailList.TabIndex = 21
        Me.cmdPrintEmailList.Text = "Print Email List"
        Me.cmdPrintEmailList.UseVisualStyleBackColor = True
        '
        'dgvEmployeeData
        '
        Me.dgvEmployeeData.AllowUserToAddRows = False
        Me.dgvEmployeeData.AllowUserToDeleteRows = False
        Me.dgvEmployeeData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEmployeeData.AutoGenerateColumns = False
        Me.dgvEmployeeData.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvEmployeeData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvEmployeeData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmployeeData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EmployeeIDColumn, Me.EmployeeLastColumn, Me.EmployeeFirstColumn, Me.SecurityGroupIDColumn, Me.LoginNameColumn, Me.LoginPasswordColumn, Me.DepartmentColumn, Me.SalesPersonIDColumn, Me.EmailAddressColumn, Me.DivisionKeyColumn, Me.AddressColumn, Me.CityColumn, Me.StateColumn, Me.ZipCodeColumn, Me.PhoneNumberColumn, Me.EmergencyContactColumn, Me.HireDateColumn, Me.ShiftColumn, Me.CustomCodeColumn, Me.StatusColumn, Me.MOSLoginTypeColumn})
        Me.dgvEmployeeData.DataSource = Me.EmployeeDataBindingSource
        Me.dgvEmployeeData.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvEmployeeData.Location = New System.Drawing.Point(373, 35)
        Me.dgvEmployeeData.Name = "dgvEmployeeData"
        Me.dgvEmployeeData.Size = New System.Drawing.Size(757, 720)
        Me.dgvEmployeeData.TabIndex = 39
        Me.dgvEmployeeData.TabStop = False
        '
        'EmployeeIDColumn
        '
        Me.EmployeeIDColumn.DataPropertyName = "EmployeeID"
        Me.EmployeeIDColumn.HeaderText = "Employee ID"
        Me.EmployeeIDColumn.Name = "EmployeeIDColumn"
        Me.EmployeeIDColumn.ReadOnly = True
        '
        'EmployeeLastColumn
        '
        Me.EmployeeLastColumn.DataPropertyName = "EmployeeLast"
        Me.EmployeeLastColumn.HeaderText = "Last Name"
        Me.EmployeeLastColumn.Name = "EmployeeLastColumn"
        '
        'EmployeeFirstColumn
        '
        Me.EmployeeFirstColumn.DataPropertyName = "EmployeeFirst"
        Me.EmployeeFirstColumn.HeaderText = "First Name"
        Me.EmployeeFirstColumn.Name = "EmployeeFirstColumn"
        '
        'SecurityGroupIDColumn
        '
        Me.SecurityGroupIDColumn.DataPropertyName = "SecurityGroupID"
        Me.SecurityGroupIDColumn.HeaderText = "Security ID"
        Me.SecurityGroupIDColumn.Name = "SecurityGroupIDColumn"
        '
        'LoginNameColumn
        '
        Me.LoginNameColumn.DataPropertyName = "LoginName"
        Me.LoginNameColumn.HeaderText = "Login Name"
        Me.LoginNameColumn.Name = "LoginNameColumn"
        '
        'LoginPasswordColumn
        '
        Me.LoginPasswordColumn.DataPropertyName = "LoginPassword"
        Me.LoginPasswordColumn.HeaderText = "Login Password"
        Me.LoginPasswordColumn.Name = "LoginPasswordColumn"
        '
        'DepartmentColumn
        '
        Me.DepartmentColumn.DataPropertyName = "Department"
        Me.DepartmentColumn.HeaderText = "Department"
        Me.DepartmentColumn.Name = "DepartmentColumn"
        '
        'SalesPersonIDColumn
        '
        Me.SalesPersonIDColumn.DataPropertyName = "SalesPersonID"
        Me.SalesPersonIDColumn.HeaderText = "Sales ID"
        Me.SalesPersonIDColumn.Name = "SalesPersonIDColumn"
        '
        'EmailAddressColumn
        '
        Me.EmailAddressColumn.DataPropertyName = "EmailAddress"
        Me.EmailAddressColumn.HeaderText = "Email Address"
        Me.EmailAddressColumn.Name = "EmailAddressColumn"
        '
        'DivisionKeyColumn
        '
        Me.DivisionKeyColumn.DataPropertyName = "DivisionKey"
        Me.DivisionKeyColumn.HeaderText = "Division"
        Me.DivisionKeyColumn.Name = "DivisionKeyColumn"
        '
        'AddressColumn
        '
        Me.AddressColumn.DataPropertyName = "Address"
        Me.AddressColumn.HeaderText = "Address"
        Me.AddressColumn.Name = "AddressColumn"
        '
        'CityColumn
        '
        Me.CityColumn.DataPropertyName = "City"
        Me.CityColumn.HeaderText = "City"
        Me.CityColumn.Name = "CityColumn"
        '
        'StateColumn
        '
        Me.StateColumn.DataPropertyName = "State"
        Me.StateColumn.HeaderText = "State"
        Me.StateColumn.Name = "StateColumn"
        '
        'ZipCodeColumn
        '
        Me.ZipCodeColumn.DataPropertyName = "ZipCode"
        Me.ZipCodeColumn.HeaderText = "Zip Code"
        Me.ZipCodeColumn.Name = "ZipCodeColumn"
        '
        'PhoneNumberColumn
        '
        Me.PhoneNumberColumn.DataPropertyName = "PhoneNumber"
        Me.PhoneNumberColumn.HeaderText = "Phone Number"
        Me.PhoneNumberColumn.Name = "PhoneNumberColumn"
        '
        'EmergencyContactColumn
        '
        Me.EmergencyContactColumn.DataPropertyName = "EmergencyContact"
        Me.EmergencyContactColumn.HeaderText = "Emergency Contact"
        Me.EmergencyContactColumn.Name = "EmergencyContactColumn"
        '
        'HireDateColumn
        '
        Me.HireDateColumn.DataPropertyName = "HireDate"
        Me.HireDateColumn.HeaderText = "Hire Date"
        Me.HireDateColumn.Name = "HireDateColumn"
        '
        'ShiftColumn
        '
        Me.ShiftColumn.DataPropertyName = "Shift"
        Me.ShiftColumn.HeaderText = "Shift"
        Me.ShiftColumn.Name = "ShiftColumn"
        '
        'CustomCodeColumn
        '
        Me.CustomCodeColumn.DataPropertyName = "CustomCode"
        Me.CustomCodeColumn.HeaderText = "Custom Code"
        Me.CustomCodeColumn.Name = "CustomCodeColumn"
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "EmployeeStatus"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        '
        'MOSLoginTypeColumn
        '
        Me.MOSLoginTypeColumn.DataPropertyName = "MOSLoginType"
        Me.MOSLoginTypeColumn.HeaderText = "Login Type"
        Me.MOSLoginTypeColumn.Name = "MOSLoginTypeColumn"
        '
        'EmployeeDataTableAdapter
        '
        Me.EmployeeDataTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'DepartmentsTableAdapter
        '
        Me.DepartmentsTableAdapter.ClearBeforeFill = True
        '
        'SecurityGroupTableAdapter
        '
        Me.SecurityGroupTableAdapter.ClearBeforeFill = True
        '
        'cmdLogonRecord
        '
        Me.cmdLogonRecord.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdLogonRecord.Location = New System.Drawing.Point(530, 771)
        Me.cmdLogonRecord.Name = "cmdLogonRecord"
        Me.cmdLogonRecord.Size = New System.Drawing.Size(71, 40)
        Me.cmdLogonRecord.TabIndex = 22
        Me.cmdLogonRecord.Text = "View Logon Record"
        Me.cmdLogonRecord.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRefresh.Location = New System.Drawing.Point(905, 771)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(71, 40)
        Me.cmdRefresh.TabIndex = 40
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'EmployeeData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.cmdLogonRecord)
        Me.Controls.Add(Me.dgvEmployeeData)
        Me.Controls.Add(Me.cmdPrintPhoneList)
        Me.Controls.Add(Me.cmdPrintEmailList)
        Me.Controls.Add(Me.gpxEmpPersonalData)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.gpxTFPEmployeeData)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "EmployeeData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Employee Data Form"
        Me.gpxEmpPersonalData.ResumeLayout(False)
        Me.gpxEmpPersonalData.PerformLayout()
        Me.gpxTFPEmployeeData.ResumeLayout(False)
        Me.gpxTFPEmployeeData.PerformLayout()
        CType(Me.SecurityGroupBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DepartmentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvEmployeeData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents txtEmpLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpState As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpCity As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpFirstName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtEmpEmergencyContact As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpZipCode As System.Windows.Forms.TextBox
    Friend WithEvents gpxEmpPersonalData As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents gpxTFPEmployeeData As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileEditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboEmployeeNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpHireDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboSecurityGroup As System.Windows.Forms.ComboBox
    Friend WithEvents cboDepartmentName As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionKey As System.Windows.Forms.ComboBox
    Friend WithEvents PrintEmployeeRosterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintEmailListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPhoneListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrintPhoneList As System.Windows.Forms.Button
    Friend WithEvents cmdPrintEmailList As System.Windows.Forms.Button
    Friend WithEvents txtLoginPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtLoginName As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dgvEmployeeData As System.Windows.Forms.DataGridView
    Friend WithEvents chkSalesPerson As System.Windows.Forms.CheckBox
    Friend WithEvents txtSalesPersonID As System.Windows.Forms.TextBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents DepartmentsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DepartmentsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DepartmentsTableAdapter
    Friend WithEvents SecurityGroupBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SecurityGroupTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SecurityGroupTableAdapter
    Friend WithEvents cmdLogonRecord As System.Windows.Forms.Button
    Friend WithEvents ClearFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtDepartmentID As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmdDeactivateEmployee As System.Windows.Forms.Button
    Friend WithEvents cboLoginType As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents EmployeeIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeLastColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeFirstColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SecurityGroupIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoginNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoginPasswordColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DepartmentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesPersonIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmailAddressColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddressColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ZipCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PhoneNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmergencyContactColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HireDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShiftColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOSLoginTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
End Class
