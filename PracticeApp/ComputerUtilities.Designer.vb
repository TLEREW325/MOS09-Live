<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComputerUtilities
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
        Me.txtUserIP = New System.Windows.Forms.TextBox
        Me.cmdGetIP = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdUpdateSteelInFOXES = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboNewRMID = New System.Windows.Forms.ComboBox
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboOldRMID = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdUploadCSV = New System.Windows.Forms.Button
        Me.ofdOpenFlatFile = New System.Windows.Forms.OpenFileDialog
        Me.GroupBox43 = New System.Windows.Forms.GroupBox
        Me.txtNewSteelSize = New System.Windows.Forms.TextBox
        Me.txtNewCarbon = New System.Windows.Forms.TextBox
        Me.txtNewDescription = New System.Windows.Forms.TextBox
        Me.txtNewRMID = New System.Windows.Forms.TextBox
        Me.txtOldRMID = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.cmdClearRMID = New System.Windows.Forms.Button
        Me.cmdUpdateRMID = New System.Windows.Forms.Button
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cmdUploadCoilFlatFiles = New System.Windows.Forms.Button
        Me.GroupBox41 = New System.Windows.Forms.GroupBox
        Me.cmdResetClear = New System.Windows.Forms.Button
        Me.cmdResetShipment = New System.Windows.Forms.Button
        Me.txtShipmentDivision = New System.Windows.Forms.TextBox
        Me.txtShipmentNumber = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.GroupBox15 = New System.Windows.Forms.GroupBox
        Me.cmdChangePart = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtChangeDivision = New System.Windows.Forms.TextBox
        Me.chkChangeAllDivisions = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtPartNumberTwo = New System.Windows.Forms.TextBox
        Me.txtPartNumberOne = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox24 = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.chkChangeAllCustomerDivisions = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtCustomerDivision = New System.Windows.Forms.TextBox
        Me.cmdChangeCustomer = New System.Windows.Forms.Button
        Me.txtNewCustomerID = New System.Windows.Forms.TextBox
        Me.txtOldCustomerID = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.GroupBox18 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.chkChangeAll2 = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtVendorDivision = New System.Windows.Forms.TextBox
        Me.cmdChangeVendor = New System.Windows.Forms.Button
        Me.txtNewVendor = New System.Windows.Forms.TextBox
        Me.txtOldVendor = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.txtCustomerUploadDivision = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtUpdateColumn = New System.Windows.Forms.TextBox
        Me.cmdUploadExcel = New System.Windows.Forms.Button
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.cmdPrintTestLabel = New System.Windows.Forms.Button
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.cmdClearReset = New System.Windows.Forms.Button
        Me.cmdResetShipmentDate = New System.Windows.Forms.Button
        Me.dtpResetDate = New System.Windows.Forms.DateTimePicker
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.txtResetInvoiceNumber = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.txtResetShipmentNumber = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmdTestEmail = New System.Windows.Forms.Button
        Me.cmdTestTrailingZeroes = New System.Windows.Forms.Button
        Me.txtAfterDecimal = New System.Windows.Forms.TextBox
        Me.txtBeforeDecimal = New System.Windows.Forms.TextBox
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.cmdUploadLotNumber = New System.Windows.Forms.Button
        Me.DirectorySearcher1 = New System.DirectoryServices.DirectorySearcher
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.txtSteelSizeUpdate = New System.Windows.Forms.TextBox
        Me.txtCarbonUpdate = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.cboRMIDUpdateSteelSizeAndCarbon = New System.Windows.Forms.ComboBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.cmdUpdateSteelSizeAndCarbon = New System.Windows.Forms.Button
        Me.Label36 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox43.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox41.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox24.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 0
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'txtUserIP
        '
        Me.txtUserIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserIP.Location = New System.Drawing.Point(19, 28)
        Me.txtUserIP.Name = "txtUserIP"
        Me.txtUserIP.Size = New System.Drawing.Size(285, 20)
        Me.txtUserIP.TabIndex = 1
        '
        'cmdGetIP
        '
        Me.cmdGetIP.Location = New System.Drawing.Point(233, 54)
        Me.cmdGetIP.Name = "cmdGetIP"
        Me.cmdGetIP.Size = New System.Drawing.Size(71, 30)
        Me.cmdGetIP.TabIndex = 2
        Me.cmdGetIP.Text = "Get IP"
        Me.cmdGetIP.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmdUpdateSteelInFOXES)
        Me.GroupBox1.Controls.Add(Me.cboNewRMID)
        Me.GroupBox1.Controls.Add(Me.cboOldRMID)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(353, 458)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(371, 162)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Update Steel in FOXES"
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(19, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(256, 55)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "This utility will update the current steel in all FOXES (Preferred and Alternate)" & _
            ""
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdUpdateSteelInFOXES
        '
        Me.cmdUpdateSteelInFOXES.Location = New System.Drawing.Point(281, 117)
        Me.cmdUpdateSteelInFOXES.Name = "cmdUpdateSteelInFOXES"
        Me.cmdUpdateSteelInFOXES.Size = New System.Drawing.Size(71, 30)
        Me.cmdUpdateSteelInFOXES.TabIndex = 8
        Me.cmdUpdateSteelInFOXES.Text = "Update"
        Me.cmdUpdateSteelInFOXES.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "New RMID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboNewRMID
        '
        Me.cboNewRMID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboNewRMID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboNewRMID.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboNewRMID.DisplayMember = "RMID"
        Me.cboNewRMID.FormattingEnabled = True
        Me.cboNewRMID.Location = New System.Drawing.Point(101, 68)
        Me.cboNewRMID.Name = "cboNewRMID"
        Me.cboNewRMID.Size = New System.Drawing.Size(251, 21)
        Me.cboNewRMID.TabIndex = 6
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
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Old RMID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboOldRMID
        '
        Me.cboOldRMID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboOldRMID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboOldRMID.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboOldRMID.DisplayMember = "RMID"
        Me.cboOldRMID.FormattingEnabled = True
        Me.cboOldRMID.Location = New System.Drawing.Point(101, 33)
        Me.cboOldRMID.Name = "cboOldRMID"
        Me.cboOldRMID.Size = New System.Drawing.Size(251, 21)
        Me.cboOldRMID.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtUserIP)
        Me.GroupBox2.Controls.Add(Me.cmdGetIP)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 205)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(323, 95)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Get IP Address of Local Computer"
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdUploadCSV)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 307)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(323, 65)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Upload Mill Cert CSV Files"
        '
        'cmdUploadCSV
        '
        Me.cmdUploadCSV.Location = New System.Drawing.Point(233, 19)
        Me.cmdUploadCSV.Name = "cmdUploadCSV"
        Me.cmdUploadCSV.Size = New System.Drawing.Size(71, 30)
        Me.cmdUploadCSV.TabIndex = 3
        Me.cmdUploadCSV.Text = "Upload File"
        Me.cmdUploadCSV.UseVisualStyleBackColor = True
        '
        'ofdOpenFlatFile
        '
        Me.ofdOpenFlatFile.Filter = "CSV Files|*.csv|Text Files|*.txt|All Files|*.*"
        '
        'GroupBox43
        '
        Me.GroupBox43.Controls.Add(Me.txtNewSteelSize)
        Me.GroupBox43.Controls.Add(Me.txtNewCarbon)
        Me.GroupBox43.Controls.Add(Me.txtNewDescription)
        Me.GroupBox43.Controls.Add(Me.txtNewRMID)
        Me.GroupBox43.Controls.Add(Me.txtOldRMID)
        Me.GroupBox43.Controls.Add(Me.Label24)
        Me.GroupBox43.Controls.Add(Me.Label23)
        Me.GroupBox43.Controls.Add(Me.Label22)
        Me.GroupBox43.Controls.Add(Me.cmdClearRMID)
        Me.GroupBox43.Controls.Add(Me.cmdUpdateRMID)
        Me.GroupBox43.Controls.Add(Me.Label20)
        Me.GroupBox43.Controls.Add(Me.Label21)
        Me.GroupBox43.Location = New System.Drawing.Point(352, 19)
        Me.GroupBox43.Name = "GroupBox43"
        Me.GroupBox43.Size = New System.Drawing.Size(371, 223)
        Me.GroupBox43.TabIndex = 86
        Me.GroupBox43.TabStop = False
        Me.GroupBox43.Text = "Change RMID"
        '
        'txtNewSteelSize
        '
        Me.txtNewSteelSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNewSteelSize.Location = New System.Drawing.Point(77, 148)
        Me.txtNewSteelSize.Name = "txtNewSteelSize"
        Me.txtNewSteelSize.Size = New System.Drawing.Size(275, 20)
        Me.txtNewSteelSize.TabIndex = 72
        '
        'txtNewCarbon
        '
        Me.txtNewCarbon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNewCarbon.Location = New System.Drawing.Point(77, 117)
        Me.txtNewCarbon.Name = "txtNewCarbon"
        Me.txtNewCarbon.Size = New System.Drawing.Size(275, 20)
        Me.txtNewCarbon.TabIndex = 71
        '
        'txtNewDescription
        '
        Me.txtNewDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNewDescription.Location = New System.Drawing.Point(77, 86)
        Me.txtNewDescription.Name = "txtNewDescription"
        Me.txtNewDescription.Size = New System.Drawing.Size(275, 20)
        Me.txtNewDescription.TabIndex = 70
        '
        'txtNewRMID
        '
        Me.txtNewRMID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNewRMID.Location = New System.Drawing.Point(77, 55)
        Me.txtNewRMID.Name = "txtNewRMID"
        Me.txtNewRMID.Size = New System.Drawing.Size(275, 20)
        Me.txtNewRMID.TabIndex = 66
        '
        'txtOldRMID
        '
        Me.txtOldRMID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOldRMID.Location = New System.Drawing.Point(77, 24)
        Me.txtOldRMID.Name = "txtOldRMID"
        Me.txtOldRMID.Size = New System.Drawing.Size(275, 20)
        Me.txtOldRMID.TabIndex = 0
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(6, 148)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(73, 23)
        Me.Label24.TabIndex = 75
        Me.Label24.Text = "Steel Size"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(6, 117)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(73, 23)
        Me.Label23.TabIndex = 74
        Me.Label23.Text = "Carbon"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(6, 86)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(73, 23)
        Me.Label22.TabIndex = 73
        Me.Label22.Text = "Description"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearRMID
        '
        Me.cmdClearRMID.Location = New System.Drawing.Point(281, 184)
        Me.cmdClearRMID.Name = "cmdClearRMID"
        Me.cmdClearRMID.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearRMID.TabIndex = 69
        Me.cmdClearRMID.Text = "Clear"
        Me.cmdClearRMID.UseVisualStyleBackColor = True
        '
        'cmdUpdateRMID
        '
        Me.cmdUpdateRMID.Location = New System.Drawing.Point(204, 184)
        Me.cmdUpdateRMID.Name = "cmdUpdateRMID"
        Me.cmdUpdateRMID.Size = New System.Drawing.Size(71, 30)
        Me.cmdUpdateRMID.TabIndex = 68
        Me.cmdUpdateRMID.Text = "Update"
        Me.cmdUpdateRMID.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(6, 55)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(73, 23)
        Me.Label20.TabIndex = 67
        Me.Label20.Text = "New RMID"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(6, 24)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(73, 23)
        Me.Label21.TabIndex = 65
        Me.Label21.Text = "Old RMID"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdUploadCoilFlatFiles)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 379)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(323, 63)
        Me.GroupBox4.TabIndex = 87
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Upload Charter Steel Coil Flat Files"
        '
        'cmdUploadCoilFlatFiles
        '
        Me.cmdUploadCoilFlatFiles.Location = New System.Drawing.Point(233, 19)
        Me.cmdUploadCoilFlatFiles.Name = "cmdUploadCoilFlatFiles"
        Me.cmdUploadCoilFlatFiles.Size = New System.Drawing.Size(71, 30)
        Me.cmdUploadCoilFlatFiles.TabIndex = 3
        Me.cmdUploadCoilFlatFiles.Text = "Upload File"
        Me.cmdUploadCoilFlatFiles.UseVisualStyleBackColor = True
        '
        'GroupBox41
        '
        Me.GroupBox41.Controls.Add(Me.cmdResetClear)
        Me.GroupBox41.Controls.Add(Me.cmdResetShipment)
        Me.GroupBox41.Controls.Add(Me.txtShipmentDivision)
        Me.GroupBox41.Controls.Add(Me.txtShipmentNumber)
        Me.GroupBox41.Controls.Add(Me.Label19)
        Me.GroupBox41.Controls.Add(Me.Label18)
        Me.GroupBox41.Location = New System.Drawing.Point(786, 523)
        Me.GroupBox41.Name = "GroupBox41"
        Me.GroupBox41.Size = New System.Drawing.Size(344, 138)
        Me.GroupBox41.TabIndex = 88
        Me.GroupBox41.TabStop = False
        Me.GroupBox41.Text = "Reset a Shipment for Posting"
        '
        'cmdResetClear
        '
        Me.cmdResetClear.Location = New System.Drawing.Point(259, 92)
        Me.cmdResetClear.Name = "cmdResetClear"
        Me.cmdResetClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdResetClear.TabIndex = 69
        Me.cmdResetClear.Text = "Clear"
        Me.cmdResetClear.UseVisualStyleBackColor = True
        '
        'cmdResetShipment
        '
        Me.cmdResetShipment.Location = New System.Drawing.Point(182, 92)
        Me.cmdResetShipment.Name = "cmdResetShipment"
        Me.cmdResetShipment.Size = New System.Drawing.Size(71, 30)
        Me.cmdResetShipment.TabIndex = 68
        Me.cmdResetShipment.Text = "Reset"
        Me.cmdResetShipment.UseVisualStyleBackColor = True
        '
        'txtShipmentDivision
        '
        Me.txtShipmentDivision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipmentDivision.Location = New System.Drawing.Point(157, 55)
        Me.txtShipmentDivision.Name = "txtShipmentDivision"
        Me.txtShipmentDivision.Size = New System.Drawing.Size(173, 20)
        Me.txtShipmentDivision.TabIndex = 66
        '
        'txtShipmentNumber
        '
        Me.txtShipmentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipmentNumber.Location = New System.Drawing.Point(157, 24)
        Me.txtShipmentNumber.Name = "txtShipmentNumber"
        Me.txtShipmentNumber.Size = New System.Drawing.Size(173, 20)
        Me.txtShipmentNumber.TabIndex = 0
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(15, 55)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(130, 23)
        Me.Label19.TabIndex = 67
        Me.Label19.Text = "Division"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(15, 24)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(130, 23)
        Me.Label18.TabIndex = 65
        Me.Label18.Text = "Shipment #"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.cmdChangePart)
        Me.GroupBox15.Controls.Add(Me.Label5)
        Me.GroupBox15.Controls.Add(Me.Label4)
        Me.GroupBox15.Controls.Add(Me.txtChangeDivision)
        Me.GroupBox15.Controls.Add(Me.chkChangeAllDivisions)
        Me.GroupBox15.Controls.Add(Me.Label6)
        Me.GroupBox15.Controls.Add(Me.txtPartNumberTwo)
        Me.GroupBox15.Controls.Add(Me.txtPartNumberOne)
        Me.GroupBox15.Controls.Add(Me.Label7)
        Me.GroupBox15.Controls.Add(Me.Label8)
        Me.GroupBox15.Location = New System.Drawing.Point(352, 252)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(372, 200)
        Me.GroupBox15.TabIndex = 89
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Make Part Number Corrections"
        '
        'cmdChangePart
        '
        Me.cmdChangePart.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdChangePart.ForeColor = System.Drawing.Color.Black
        Me.cmdChangePart.Location = New System.Drawing.Point(281, 150)
        Me.cmdChangePart.Name = "cmdChangePart"
        Me.cmdChangePart.Size = New System.Drawing.Size(71, 40)
        Me.cmdChangePart.TabIndex = 63
        Me.cmdChangePart.Text = "Change Part"
        Me.cmdChangePart.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(15, 159)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 23)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "Division"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(157, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 23)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "OR"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtChangeDivision
        '
        Me.txtChangeDivision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChangeDivision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChangeDivision.Location = New System.Drawing.Point(72, 160)
        Me.txtChangeDivision.Name = "txtChangeDivision"
        Me.txtChangeDivision.Size = New System.Drawing.Size(128, 20)
        Me.txtChangeDivision.TabIndex = 6
        '
        'chkChangeAllDivisions
        '
        Me.chkChangeAllDivisions.AutoSize = True
        Me.chkChangeAllDivisions.Enabled = False
        Me.chkChangeAllDivisions.Location = New System.Drawing.Point(15, 126)
        Me.chkChangeAllDivisions.Name = "chkChangeAllDivisions"
        Me.chkChangeAllDivisions.Size = New System.Drawing.Size(122, 17)
        Me.chkChangeAllDivisions.TabIndex = 5
        Me.chkChangeAllDivisions.Text = "Change All Divisions"
        Me.chkChangeAllDivisions.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(15, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(277, 29)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "This process will change all instances of the selected part # to the new one."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartNumberTwo
        '
        Me.txtPartNumberTwo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartNumberTwo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNumberTwo.Location = New System.Drawing.Point(89, 55)
        Me.txtPartNumberTwo.Name = "txtPartNumberTwo"
        Me.txtPartNumberTwo.Size = New System.Drawing.Size(263, 20)
        Me.txtPartNumberTwo.TabIndex = 1
        '
        'txtPartNumberOne
        '
        Me.txtPartNumberOne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartNumberOne.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNumberOne.Location = New System.Drawing.Point(89, 29)
        Me.txtPartNumberOne.Name = "txtPartNumberOne"
        Me.txtPartNumberOne.Size = New System.Drawing.Size(263, 20)
        Me.txtPartNumberOne.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(15, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 23)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "New Part #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(15, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 23)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Old Part #"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox24
        '
        Me.GroupBox24.Controls.Add(Me.Label11)
        Me.GroupBox24.Controls.Add(Me.chkChangeAllCustomerDivisions)
        Me.GroupBox24.Controls.Add(Me.Label12)
        Me.GroupBox24.Controls.Add(Me.Label13)
        Me.GroupBox24.Controls.Add(Me.txtCustomerDivision)
        Me.GroupBox24.Controls.Add(Me.cmdChangeCustomer)
        Me.GroupBox24.Controls.Add(Me.txtNewCustomerID)
        Me.GroupBox24.Controls.Add(Me.txtOldCustomerID)
        Me.GroupBox24.Controls.Add(Me.Label14)
        Me.GroupBox24.Controls.Add(Me.Label15)
        Me.GroupBox24.Location = New System.Drawing.Point(786, 218)
        Me.GroupBox24.Name = "GroupBox24"
        Me.GroupBox24.Size = New System.Drawing.Size(344, 200)
        Me.GroupBox24.TabIndex = 91
        Me.GroupBox24.TabStop = False
        Me.GroupBox24.Text = "Make Customer Corrections"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(157, 122)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 23)
        Me.Label11.TabIndex = 69
        Me.Label11.Text = "OR"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkChangeAllCustomerDivisions
        '
        Me.chkChangeAllCustomerDivisions.AutoSize = True
        Me.chkChangeAllCustomerDivisions.Enabled = False
        Me.chkChangeAllCustomerDivisions.Location = New System.Drawing.Point(15, 126)
        Me.chkChangeAllCustomerDivisions.Name = "chkChangeAllCustomerDivisions"
        Me.chkChangeAllCustomerDivisions.Size = New System.Drawing.Size(122, 17)
        Me.chkChangeAllCustomerDivisions.TabIndex = 68
        Me.chkChangeAllCustomerDivisions.Text = "Change All Divisions"
        Me.chkChangeAllCustomerDivisions.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(17, 86)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(277, 29)
        Me.Label12.TabIndex = 67
        Me.Label12.Text = "This process will change all instances of the selected customer to the new one."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(15, 161)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 23)
        Me.Label13.TabIndex = 66
        Me.Label13.Text = "Division"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCustomerDivision
        '
        Me.txtCustomerDivision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerDivision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerDivision.Location = New System.Drawing.Point(72, 162)
        Me.txtCustomerDivision.Name = "txtCustomerDivision"
        Me.txtCustomerDivision.Size = New System.Drawing.Size(128, 20)
        Me.txtCustomerDivision.TabIndex = 65
        '
        'cmdChangeCustomer
        '
        Me.cmdChangeCustomer.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdChangeCustomer.ForeColor = System.Drawing.Color.Black
        Me.cmdChangeCustomer.Location = New System.Drawing.Point(259, 144)
        Me.cmdChangeCustomer.Name = "cmdChangeCustomer"
        Me.cmdChangeCustomer.Size = New System.Drawing.Size(71, 40)
        Me.cmdChangeCustomer.TabIndex = 64
        Me.cmdChangeCustomer.Text = "Change Customer"
        Me.cmdChangeCustomer.UseVisualStyleBackColor = True
        '
        'txtNewCustomerID
        '
        Me.txtNewCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNewCustomerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNewCustomerID.Location = New System.Drawing.Point(110, 55)
        Me.txtNewCustomerID.Name = "txtNewCustomerID"
        Me.txtNewCustomerID.Size = New System.Drawing.Size(213, 20)
        Me.txtNewCustomerID.TabIndex = 5
        '
        'txtOldCustomerID
        '
        Me.txtOldCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOldCustomerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOldCustomerID.Location = New System.Drawing.Point(110, 29)
        Me.txtOldCustomerID.Name = "txtOldCustomerID"
        Me.txtOldCustomerID.Size = New System.Drawing.Size(213, 20)
        Me.txtOldCustomerID.TabIndex = 4
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(12, 55)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 23)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "New Customer ID"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(12, 29)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 23)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Old Customer ID"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.Label10)
        Me.GroupBox18.Controls.Add(Me.chkChangeAll2)
        Me.GroupBox18.Controls.Add(Me.Label9)
        Me.GroupBox18.Controls.Add(Me.Label16)
        Me.GroupBox18.Controls.Add(Me.txtVendorDivision)
        Me.GroupBox18.Controls.Add(Me.cmdChangeVendor)
        Me.GroupBox18.Controls.Add(Me.txtNewVendor)
        Me.GroupBox18.Controls.Add(Me.txtOldVendor)
        Me.GroupBox18.Controls.Add(Me.Label17)
        Me.GroupBox18.Controls.Add(Me.Label25)
        Me.GroupBox18.Location = New System.Drawing.Point(786, 12)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(344, 200)
        Me.GroupBox18.TabIndex = 90
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "Make Vendor Corrections"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(157, 122)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 23)
        Me.Label10.TabIndex = 69
        Me.Label10.Text = "OR"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkChangeAll2
        '
        Me.chkChangeAll2.AutoSize = True
        Me.chkChangeAll2.Enabled = False
        Me.chkChangeAll2.Location = New System.Drawing.Point(15, 126)
        Me.chkChangeAll2.Name = "chkChangeAll2"
        Me.chkChangeAll2.Size = New System.Drawing.Size(122, 17)
        Me.chkChangeAll2.TabIndex = 68
        Me.chkChangeAll2.Text = "Change All Divisions"
        Me.chkChangeAll2.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(17, 86)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(277, 29)
        Me.Label9.TabIndex = 67
        Me.Label9.Text = "This process will change all instances of the selected part # to the new one."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(15, 161)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 23)
        Me.Label16.TabIndex = 66
        Me.Label16.Text = "Division"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVendorDivision
        '
        Me.txtVendorDivision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorDivision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorDivision.Location = New System.Drawing.Point(72, 162)
        Me.txtVendorDivision.Name = "txtVendorDivision"
        Me.txtVendorDivision.Size = New System.Drawing.Size(128, 20)
        Me.txtVendorDivision.TabIndex = 65
        '
        'cmdChangeVendor
        '
        Me.cmdChangeVendor.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdChangeVendor.ForeColor = System.Drawing.Color.Black
        Me.cmdChangeVendor.Location = New System.Drawing.Point(259, 146)
        Me.cmdChangeVendor.Name = "cmdChangeVendor"
        Me.cmdChangeVendor.Size = New System.Drawing.Size(71, 40)
        Me.cmdChangeVendor.TabIndex = 64
        Me.cmdChangeVendor.Text = "Change Vendor"
        Me.cmdChangeVendor.UseVisualStyleBackColor = True
        '
        'txtNewVendor
        '
        Me.txtNewVendor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNewVendor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNewVendor.Location = New System.Drawing.Point(99, 55)
        Me.txtNewVendor.Name = "txtNewVendor"
        Me.txtNewVendor.Size = New System.Drawing.Size(231, 20)
        Me.txtNewVendor.TabIndex = 5
        '
        'txtOldVendor
        '
        Me.txtOldVendor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOldVendor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOldVendor.Location = New System.Drawing.Point(99, 29)
        Me.txtOldVendor.Name = "txtOldVendor"
        Me.txtOldVendor.Size = New System.Drawing.Size(231, 20)
        Me.txtOldVendor.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(12, 55)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 23)
        Me.Label17.TabIndex = 7
        Me.Label17.Text = "New Vendor ID"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(12, 29)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(100, 23)
        Me.Label25.TabIndex = 6
        Me.Label25.Text = "Old Vendor ID"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label29)
        Me.GroupBox6.Controls.Add(Me.txtCustomerUploadDivision)
        Me.GroupBox6.Controls.Add(Me.Label28)
        Me.GroupBox6.Controls.Add(Me.Label27)
        Me.GroupBox6.Controls.Add(Me.txtUpdateColumn)
        Me.GroupBox6.Controls.Add(Me.cmdUploadExcel)
        Me.GroupBox6.Location = New System.Drawing.Point(352, 628)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(372, 177)
        Me.GroupBox6.TabIndex = 94
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Upload Customer Excel File into Database"
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(15, 34)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(51, 23)
        Me.Label29.TabIndex = 79
        Me.Label29.Text = "Division"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCustomerUploadDivision
        '
        Me.txtCustomerUploadDivision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerUploadDivision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerUploadDivision.Location = New System.Drawing.Point(72, 35)
        Me.txtCustomerUploadDivision.Name = "txtCustomerUploadDivision"
        Me.txtCustomerUploadDivision.Size = New System.Drawing.Size(128, 20)
        Me.txtCustomerUploadDivision.TabIndex = 78
        '
        'Label28
        '
        Me.Label28.ForeColor = System.Drawing.Color.Blue
        Me.Label28.Location = New System.Drawing.Point(23, 119)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(192, 23)
        Me.Label28.TabIndex = 77
        Me.Label28.Text = "(Must match database exactly)"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(20, 68)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(157, 23)
        Me.Label27.TabIndex = 76
        Me.Label27.Text = "Upload Column Name"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUpdateColumn
        '
        Me.txtUpdateColumn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUpdateColumn.Location = New System.Drawing.Point(18, 93)
        Me.txtUpdateColumn.Name = "txtUpdateColumn"
        Me.txtUpdateColumn.Size = New System.Drawing.Size(334, 20)
        Me.txtUpdateColumn.TabIndex = 8
        '
        'cmdUploadExcel
        '
        Me.cmdUploadExcel.Location = New System.Drawing.Point(285, 133)
        Me.cmdUploadExcel.Name = "cmdUploadExcel"
        Me.cmdUploadExcel.Size = New System.Drawing.Size(71, 30)
        Me.cmdUploadExcel.TabIndex = 3
        Me.cmdUploadExcel.Text = "Upload File"
        Me.cmdUploadExcel.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.cmdPrintTestLabel)
        Me.GroupBox7.Location = New System.Drawing.Point(786, 433)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(344, 82)
        Me.GroupBox7.TabIndex = 97
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Print Label Test"
        '
        'cmdPrintTestLabel
        '
        Me.cmdPrintTestLabel.ForeColor = System.Drawing.Color.Black
        Me.cmdPrintTestLabel.Location = New System.Drawing.Point(259, 19)
        Me.cmdPrintTestLabel.Name = "cmdPrintTestLabel"
        Me.cmdPrintTestLabel.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintTestLabel.TabIndex = 65
        Me.cmdPrintTestLabel.Text = "Print Label"
        Me.cmdPrintTestLabel.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.cmdClearReset)
        Me.GroupBox8.Controls.Add(Me.cmdResetShipmentDate)
        Me.GroupBox8.Controls.Add(Me.dtpResetDate)
        Me.GroupBox8.Controls.Add(Me.Label32)
        Me.GroupBox8.Controls.Add(Me.Label31)
        Me.GroupBox8.Controls.Add(Me.txtResetInvoiceNumber)
        Me.GroupBox8.Controls.Add(Me.Label33)
        Me.GroupBox8.Controls.Add(Me.Label30)
        Me.GroupBox8.Controls.Add(Me.txtResetShipmentNumber)
        Me.GroupBox8.Location = New System.Drawing.Point(9, 19)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(326, 175)
        Me.GroupBox8.TabIndex = 108
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Reset Shipment/Invoice Date"
        '
        'cmdClearReset
        '
        Me.cmdClearReset.Location = New System.Drawing.Point(159, 132)
        Me.cmdClearReset.Name = "cmdClearReset"
        Me.cmdClearReset.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearReset.TabIndex = 86
        Me.cmdClearReset.Text = "Clear"
        Me.cmdClearReset.UseVisualStyleBackColor = True
        '
        'cmdResetShipmentDate
        '
        Me.cmdResetShipmentDate.Location = New System.Drawing.Point(236, 131)
        Me.cmdResetShipmentDate.Name = "cmdResetShipmentDate"
        Me.cmdResetShipmentDate.Size = New System.Drawing.Size(71, 30)
        Me.cmdResetShipmentDate.TabIndex = 85
        Me.cmdResetShipmentDate.Text = "Reset Date"
        Me.cmdResetShipmentDate.UseVisualStyleBackColor = True
        '
        'dtpResetDate
        '
        Me.dtpResetDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpResetDate.Location = New System.Drawing.Point(125, 90)
        Me.dtpResetDate.Name = "dtpResetDate"
        Me.dtpResetDate.Size = New System.Drawing.Size(182, 20)
        Me.dtpResetDate.TabIndex = 84
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(17, 90)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(95, 23)
        Me.Label32.TabIndex = 83
        Me.Label32.Text = "Date"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(17, 59)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(95, 23)
        Me.Label31.TabIndex = 82
        Me.Label31.Text = "Invoice Number"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtResetInvoiceNumber
        '
        Me.txtResetInvoiceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResetInvoiceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtResetInvoiceNumber.Location = New System.Drawing.Point(125, 59)
        Me.txtResetInvoiceNumber.Name = "txtResetInvoiceNumber"
        Me.txtResetInvoiceNumber.Size = New System.Drawing.Size(182, 20)
        Me.txtResetInvoiceNumber.TabIndex = 81
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(17, 28)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(95, 23)
        Me.Label30.TabIndex = 80
        Me.Label30.Text = "Shipment Number"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtResetShipmentNumber
        '
        Me.txtResetShipmentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResetShipmentNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtResetShipmentNumber.Location = New System.Drawing.Point(125, 28)
        Me.txtResetShipmentNumber.Name = "txtResetShipmentNumber"
        Me.txtResetShipmentNumber.Size = New System.Drawing.Size(182, 20)
        Me.txtResetShipmentNumber.TabIndex = 8
        '
        'Label33
        '
        Me.Label33.ForeColor = System.Drawing.Color.Blue
        Me.Label33.Location = New System.Drawing.Point(17, 122)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(131, 39)
        Me.Label33.TabIndex = 86
        Me.Label33.Text = "This utility will reset the ship/invoice date and all associated entries."
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1059, 727)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(71, 40)
        Me.Button1.TabIndex = 109
        Me.Button1.Text = "Daily Sales"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdTestEmail
        '
        Me.cmdTestEmail.Location = New System.Drawing.Point(245, 779)
        Me.cmdTestEmail.Name = "cmdTestEmail"
        Me.cmdTestEmail.Size = New System.Drawing.Size(71, 30)
        Me.cmdTestEmail.TabIndex = 113
        Me.cmdTestEmail.Text = "Email Test"
        Me.cmdTestEmail.UseVisualStyleBackColor = True
        '
        'cmdTestTrailingZeroes
        '
        Me.cmdTestTrailingZeroes.Location = New System.Drawing.Point(245, 737)
        Me.cmdTestTrailingZeroes.Name = "cmdTestTrailingZeroes"
        Me.cmdTestTrailingZeroes.Size = New System.Drawing.Size(71, 30)
        Me.cmdTestTrailingZeroes.TabIndex = 112
        Me.cmdTestTrailingZeroes.Text = "Test"
        Me.cmdTestTrailingZeroes.UseVisualStyleBackColor = True
        '
        'txtAfterDecimal
        '
        Me.txtAfterDecimal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAfterDecimal.Location = New System.Drawing.Point(31, 779)
        Me.txtAfterDecimal.Name = "txtAfterDecimal"
        Me.txtAfterDecimal.Size = New System.Drawing.Size(189, 20)
        Me.txtAfterDecimal.TabIndex = 111
        '
        'txtBeforeDecimal
        '
        Me.txtBeforeDecimal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBeforeDecimal.Location = New System.Drawing.Point(31, 737)
        Me.txtBeforeDecimal.Name = "txtBeforeDecimal"
        Me.txtBeforeDecimal.Size = New System.Drawing.Size(189, 20)
        Me.txtBeforeDecimal.TabIndex = 110
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.cmdUploadLotNumber)
        Me.GroupBox9.Location = New System.Drawing.Point(12, 449)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(323, 63)
        Me.GroupBox9.TabIndex = 114
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Upload Lot Number From Excel"
        '
        'cmdUploadLotNumber
        '
        Me.cmdUploadLotNumber.Location = New System.Drawing.Point(233, 19)
        Me.cmdUploadLotNumber.Name = "cmdUploadLotNumber"
        Me.cmdUploadLotNumber.Size = New System.Drawing.Size(71, 30)
        Me.cmdUploadLotNumber.TabIndex = 3
        Me.cmdUploadLotNumber.Text = "Upload File"
        Me.cmdUploadLotNumber.UseVisualStyleBackColor = True
        '
        'DirectorySearcher1
        '
        Me.DirectorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01")
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.Label36)
        Me.GroupBox10.Controls.Add(Me.cmdUpdateSteelSizeAndCarbon)
        Me.GroupBox10.Controls.Add(Me.txtSteelSizeUpdate)
        Me.GroupBox10.Controls.Add(Me.txtCarbonUpdate)
        Me.GroupBox10.Controls.Add(Me.cboRMIDUpdateSteelSizeAndCarbon)
        Me.GroupBox10.Controls.Add(Me.Label35)
        Me.GroupBox10.Controls.Add(Me.Label26)
        Me.GroupBox10.Controls.Add(Me.Label34)
        Me.GroupBox10.Location = New System.Drawing.Point(12, 527)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(323, 192)
        Me.GroupBox10.TabIndex = 115
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Update Steel Size and Carbon For RMID"
        '
        'txtSteelSizeUpdate
        '
        Me.txtSteelSizeUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelSizeUpdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelSizeUpdate.Location = New System.Drawing.Point(94, 106)
        Me.txtSteelSizeUpdate.Name = "txtSteelSizeUpdate"
        Me.txtSteelSizeUpdate.Size = New System.Drawing.Size(210, 20)
        Me.txtSteelSizeUpdate.TabIndex = 9
        '
        'txtCarbonUpdate
        '
        Me.txtCarbonUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCarbonUpdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCarbonUpdate.Location = New System.Drawing.Point(94, 69)
        Me.txtCarbonUpdate.Name = "txtCarbonUpdate"
        Me.txtCarbonUpdate.Size = New System.Drawing.Size(210, 20)
        Me.txtCarbonUpdate.TabIndex = 8
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(16, 31)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(100, 23)
        Me.Label34.TabIndex = 7
        Me.Label34.Text = "RMID"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboRMIDUpdateSteelSizeAndCarbon
        '
        Me.cboRMIDUpdateSteelSizeAndCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRMIDUpdateSteelSizeAndCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRMIDUpdateSteelSizeAndCarbon.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboRMIDUpdateSteelSizeAndCarbon.DisplayMember = "RMID"
        Me.cboRMIDUpdateSteelSizeAndCarbon.FormattingEnabled = True
        Me.cboRMIDUpdateSteelSizeAndCarbon.Location = New System.Drawing.Point(94, 31)
        Me.cboRMIDUpdateSteelSizeAndCarbon.Name = "cboRMIDUpdateSteelSizeAndCarbon"
        Me.cboRMIDUpdateSteelSizeAndCarbon.Size = New System.Drawing.Size(210, 21)
        Me.cboRMIDUpdateSteelSizeAndCarbon.TabIndex = 6
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(16, 69)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(100, 23)
        Me.Label26.TabIndex = 10
        Me.Label26.Text = "Carbon"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(16, 106)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(100, 23)
        Me.Label35.TabIndex = 11
        Me.Label35.Text = "Steel Size"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdUpdateSteelSizeAndCarbon
        '
        Me.cmdUpdateSteelSizeAndCarbon.Location = New System.Drawing.Point(233, 145)
        Me.cmdUpdateSteelSizeAndCarbon.Name = "cmdUpdateSteelSizeAndCarbon"
        Me.cmdUpdateSteelSizeAndCarbon.Size = New System.Drawing.Size(71, 30)
        Me.cmdUpdateSteelSizeAndCarbon.TabIndex = 113
        Me.cmdUpdateSteelSizeAndCarbon.Text = "Update"
        Me.cmdUpdateSteelSizeAndCarbon.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.ForeColor = System.Drawing.Color.Blue
        Me.Label36.Location = New System.Drawing.Point(16, 135)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(192, 48)
        Me.Label36.TabIndex = 114
        Me.Label36.Text = "This utility will change the steel carbon and size to match in all associated tab" & _
            "les."
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComputerUtilities
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.cmdTestEmail)
        Me.Controls.Add(Me.cmdTestTrailingZeroes)
        Me.Controls.Add(Me.txtAfterDecimal)
        Me.Controls.Add(Me.txtBeforeDecimal)
        Me.Controls.Add(Me.GroupBox41)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox24)
        Me.Controls.Add(Me.GroupBox15)
        Me.Controls.Add(Me.GroupBox18)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox43)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdExit)
        Me.Name = "ComputerUtilities"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Computer Utilities"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox43.ResumeLayout(False)
        Me.GroupBox43.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox41.ResumeLayout(False)
        Me.GroupBox41.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.GroupBox24.ResumeLayout(False)
        Me.GroupBox24.PerformLayout()
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents txtUserIP As System.Windows.Forms.TextBox
    Friend WithEvents cmdGetIP As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdUpdateSteelInFOXES As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboNewRMID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboOldRMID As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUploadCSV As System.Windows.Forms.Button
    Friend WithEvents ofdOpenFlatFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox43 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNewSteelSize As System.Windows.Forms.TextBox
    Friend WithEvents txtNewCarbon As System.Windows.Forms.TextBox
    Friend WithEvents txtNewDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtNewRMID As System.Windows.Forms.TextBox
    Friend WithEvents txtOldRMID As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmdClearRMID As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateRMID As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUploadCoilFlatFiles As System.Windows.Forms.Button
    Friend WithEvents GroupBox41 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdResetClear As System.Windows.Forms.Button
    Friend WithEvents cmdResetShipment As System.Windows.Forms.Button
    Friend WithEvents txtShipmentDivision As System.Windows.Forms.TextBox
    Friend WithEvents txtShipmentNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdChangePart As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtChangeDivision As System.Windows.Forms.TextBox
    Friend WithEvents chkChangeAllDivisions As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPartNumberTwo As System.Windows.Forms.TextBox
    Friend WithEvents txtPartNumberOne As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox24 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkChangeAllCustomerDivisions As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerDivision As System.Windows.Forms.TextBox
    Friend WithEvents cmdChangeCustomer As System.Windows.Forms.Button
    Friend WithEvents txtNewCustomerID As System.Windows.Forms.TextBox
    Friend WithEvents txtOldCustomerID As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkChangeAll2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtVendorDivision As System.Windows.Forms.TextBox
    Friend WithEvents cmdChangeVendor As System.Windows.Forms.Button
    Friend WithEvents txtNewVendor As System.Windows.Forms.TextBox
    Friend WithEvents txtOldVendor As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUploadExcel As System.Windows.Forms.Button
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtUpdateColumn As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerUploadDivision As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPrintTestLabel As System.Windows.Forms.Button
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtResetInvoiceNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtResetShipmentNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmdResetShipmentDate As System.Windows.Forms.Button
    Friend WithEvents dtpResetDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cmdClearReset As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdTestEmail As System.Windows.Forms.Button
    Friend WithEvents cmdTestTrailingZeroes As System.Windows.Forms.Button
    Friend WithEvents txtAfterDecimal As System.Windows.Forms.TextBox
    Friend WithEvents txtBeforeDecimal As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUploadLotNumber As System.Windows.Forms.Button
    Friend WithEvents DirectorySearcher1 As System.DirectoryServices.DirectorySearcher
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSteelSizeUpdate As System.Windows.Forms.TextBox
    Friend WithEvents txtCarbonUpdate As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cboRMIDUpdateSteelSizeAndCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmdUpdateSteelSizeAndCarbon As System.Windows.Forms.Button
    Friend WithEvents Label36 As System.Windows.Forms.Label
End Class
